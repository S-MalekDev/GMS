using ReaLTaiizor.Controls;
using System.Drawing.Drawing2D;
using System.Net;
using System.Runtime.CompilerServices;
using System.Windows.Documents;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;


namespace WinFormsClient.CustomControls
{
    public partial class GeneralTextBox : HopeTextBox
    {
        private Dictionary<TextboxInputType, string> _inputTypePlaceholders = new()
        {
            {TextboxInputType.Normal,"Any input" },{TextboxInputType.Email,"example@email.com" },{TextboxInputType.Phone,"0555 55 55 55" },
            {TextboxInputType.Numeric,"1234" },{TextboxInputType.Text,"letters only" },{TextboxInputType.Amount,"00.00" },
            {TextboxInputType.Date,"YYYY-MM-DD" }
        };


        public enum TextboxInputType { Normal ,Email ,Phone ,Numeric , Text, Amount, Date }

        private  TextboxInputType _inputType = TextboxInputType.Normal;
        public TextboxInputType InputType 
        {
            set
            {
                _inputType = value;
                this.Hint = (this.Hint == string.Empty)? _inputTypePlaceholders[_inputType]: this.Hint;
            }
            get { return _inputType; }
        }


        public enum RequiredMode { Optional, Required}
        public  RequiredMode RequirementMode { get; set; } = RequiredMode.Optional;

        private string _LastErrorMessage = string.Empty;

        private bool _hasError;
        private bool HasError
        {
            get => _hasError;
            set
            {
                _LastErrorMessage = string.Empty;

                this._hasError = value;
                this.BorderColor = _hasError ? Color.Red : Color.Gray;
                this.BorderColorA = _hasError ? Color.Red : Color.DeepSkyBlue;
                this.Refresh();
            }
        }

        public string FieldName { get; set; } = "The field";
        public GeneralTextBox()
        {            
            this.Padding = new Padding(10,5,10,5);
            this.Text = string.Empty;
            SubscribeToBaseEvents();

        }

 

        #region Rounded Border Drawing
        public int BorderRadius { get; set; } = 13;
        public Color BorderColor { get; set; } = Color.Gray;
        public int BorderThickness { get; set; } = 2;
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            using (GraphicsPath path = GetRoundedRectanglePath(ClientRectangle, BorderRadius))
            using (Pen pen = new Pen(BorderColor, BorderThickness))
            {
                this.Region = new Region(path);
                e.Graphics.DrawPath(pen, path);
            }
        }

        private GraphicsPath GetRoundedRectanglePath(Rectangle rect, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            int arcSize = radius * 2;

            path.StartFigure();
            path.AddArc(rect.X, rect.Y, arcSize, arcSize, 180, 90);
            path.AddArc(rect.Right - arcSize, rect.Y, arcSize, arcSize, 270, 90);
            path.AddArc(rect.Right - arcSize, rect.Bottom - arcSize, arcSize, arcSize, 0, 90);
            path.AddArc(rect.X, rect.Bottom - arcSize, arcSize, arcSize, 90, 90);
            path.CloseFigure();

            return path;
        }
        #endregion

        #region Base Events Subscription
        private void SubscribeToBaseEvents()
        {
            base.KeyPress += OnKeyPress;
            base.TextChanged += OnTextChanged;
            base.Leave += OnLeave;
        }

        private void OnLeave(object? sender, EventArgs e)
        {
            if (InputType == TextboxInputType.Amount && !string.IsNullOrEmpty(this.Text))
            {
                var textLength = this.Text.Length;

                if (!this.Text.Contains('.'))
                    this.Text = this.Text.Insert(textLength, ".00");

                if ((char)this.Text[textLength - 1] == '.')
                    this.Text = this.Text.Insert(textLength, "00");
            }

            if(InputType == TextboxInputType.Phone)
            {
                var dateLength = this.Text.Length;

                if(dateLength > 0 && dateLength != 13)
                    ShowError($"The phone format is invalid.");

                return;
            }

            if (!IsValid())
            {
                if(_inputType == TextboxInputType.Email && !string.IsNullOrEmpty(this.Text) && !IsEmailValid())
                {
                    ShowError($"The email address format is invalid.");
                    return;
                }

                ShowError($"The {FieldName.ToLower()} is required.");
                return;
            }
            
                ClearError();
        }

        private void OnTextChanged(object? sender, EventArgs e)
        {

            switch (InputType)
            {
                case TextboxInputType.Phone:
                    {
                        FormatPhoneNumber(e);
                        break;
                    }
                case TextboxInputType.Date:
                    {
                        FormatDate(e);
                        break;
                    }
            }

        }

        private void OnKeyPress(object? sender, KeyPressEventArgs e)
        {
            switch (InputType)
            {
                case TextboxInputType.Phone:
                case TextboxInputType.Date:
                case TextboxInputType.Numeric:
                    {
                        // لا تسمح إلا بالأرقام أو Backspace
                        if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
                        {
                            e.Handled = true;
                        }
                        break;
                    }
                
                case TextboxInputType.Text:
                    {
                        if (!char.IsLetter(e.KeyChar) && e.KeyChar != (char)Keys.Back  && e.KeyChar != ' ')
                        {
                            e.Handled = true;
                        }
                        break;
                    }
                case TextboxInputType.Amount:
                    {
                        if (!char.IsDigit(e.KeyChar) 
                            && 
                            !(e.KeyChar == '.' && !string.IsNullOrEmpty(this.Text) && !this.Text.Contains('.') ) 
                            &&
                            e.KeyChar != (char)Keys.Back)
                        {

                            e.Handled = true;

                        }
                        break;
                    }
                
            }

        }

        private void FormatPhoneNumber(EventArgs e)
        {
            // إزالة أي فراغات إضافية أولاً
            string digitsOnly = new string(this.Text.Where(char.IsDigit).ToArray());

            // بناء الشكل: 0555 55 55 55
            if (digitsOnly.Length > 0)
            {
                if (digitsOnly.Length > 4)
                    digitsOnly = digitsOnly.Insert(4, " ");
                if (digitsOnly.Length > 7)
                    digitsOnly = digitsOnly.Insert(7, " ");
                if (digitsOnly.Length > 10)
                    digitsOnly = digitsOnly.Insert(10, " ");
            }

            // منع المزيد من الكتابة فوق الحد المسموح
            if (digitsOnly.Length > 13)
                digitsOnly = digitsOnly.Substring(0, 13);

            this.Text = digitsOnly;

            // إعادة المؤشر دائمًا إلى نهاية النص (حتى لا يرجع للوسط عند التعديل التلقائي)
            this.SelectionStart = this.Text.Length;
        }

        private void FormatDate(EventArgs e)
        {
            // إزالة أي فراغات إضافية أولاً
            string digitsOnly = new string(this.Text.Where(char.IsDigit).ToArray());

            int yearValue = 0;
            int monthValue = 0;
            int dayValue = 0;

            // build the shape yyyy-MM-dd
            if (digitsOnly.Length > 0)
            {
                if (digitsOnly.Length > 4)
                {
                    yearValue = Convert.ToInt32(digitsOnly.Substring(0, 4));
                    digitsOnly = digitsOnly.Insert(4, "-");
                }


                if (digitsOnly.Length > 7)
                {
                    monthValue = Convert.ToInt32(digitsOnly.Substring(5, 2));

                    if (monthValue > 12)
                    {
                        digitsOnly = digitsOnly.Remove(5, 2);
                        digitsOnly = digitsOnly.Insert(5, "12");
                        monthValue = 12;
                    }

                    digitsOnly = digitsOnly.Insert(7, "-");
                }
                if (digitsOnly.Length >= 10)
                {
                    dayValue = Convert.ToInt32(digitsOnly.Substring(8, 2));

                    if (dayValue > DateTime.DaysInMonth(yearValue, monthValue))
                    {
                        digitsOnly = digitsOnly.Insert(8, $"{DateTime.DaysInMonth(yearValue, monthValue)}");
                    }
                }
            }

            // منع المزيد من الكتابة فوق الحد المسموح
            if (digitsOnly.Length > 10)
                digitsOnly = digitsOnly.Substring(0, 10);

            this.Text = digitsOnly;

            // إعادة المؤشر دائمًا إلى نهاية النص (حتى لا يرجع للوسط عند التعديل التلقائي)
            this.SelectionStart = this.Text.Length;
        }
        #endregion

        public void ShowLastError()
        {
            if (HasError)
            {
                ToolTip tooltip = new ToolTip();
                tooltip.ToolTipTitle = "Is not valid!";
                tooltip.ToolTipIcon = ToolTipIcon.Error;
                tooltip.Show(_LastErrorMessage, this, this.Width / 2, this.Height / 2, 5000);
            }
        }

        public void ShowError(string message)
        {
            HasError = true;
            _LastErrorMessage = message;
            ToolTip tooltip = new ToolTip();
            tooltip.ToolTipTitle = "Is not valid!";
            tooltip.ToolTipIcon = ToolTipIcon.Error;
            tooltip.Show(message, this, this.Width / 2, this.Height / 2, 5000);
        }

        public void ShowError()
        {
            if (IsValid())
                return;

            if(!string.IsNullOrEmpty(_LastErrorMessage))
            {
                ShowLastError();
                return;
            }

            this.OnLeave(this, EventArgs.Empty);

        }

        public void ClearError()
        {
            HasError = false;
        }

        private bool IsEmailValid()
        {
            string email = this.Text;
            string pattern = @"^[a-zA-Z0-9._%+-]{2,}@[a-zA-Z0-9.-]{2,}\.[a-zA-Z]{2,}$";
            return System.Text.RegularExpressions.Regex.IsMatch(email, pattern);
        }        

        private bool IsPhoneValid()
        {
            return this.Text.Length == 13 && !HasError;
        }

        public bool IsValid()
        {

            if (string.IsNullOrEmpty(this.Text))
                return RequirementMode == RequiredMode.Optional;

            return InputType switch
            {
                TextboxInputType.Email => IsEmailValid(),
                TextboxInputType.Phone => IsPhoneValid(),
                _ => true
            };
        }
    }
}
