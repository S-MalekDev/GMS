using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsClient.CustomControls
{
    public partial class ToggleButton : CheckBox
    {
        private Color onBackColor =Color.FromArgb(44, 44, 44);
        private Color onToggleColor = Color.White;
        private Color offBackColor = Color.Gray;
        private Color offToggleColor = Color.Gainsboro;

        public Color OnBackColor
        {
            get => onBackColor;
            set { onBackColor = value; Invalidate(); }
        }

        public Color OnToggleColor
        {
            get => onToggleColor;
            set { onToggleColor = value; Invalidate(); }
        }

        public Color OffBackColor
        {
            get => offBackColor;
            set { offBackColor = value; Invalidate(); }
        }

        public Color OffToggleColor
        {
            get => offToggleColor;
            set { offToggleColor = value; Invalidate(); }
        }
        public ToggleButton()
        {
            //InitializeComponent();
            this.AutoSize = false;
            this.Size = new Size(80, 30);
        }

        private GraphicsPath GetFigurePath()
        {
            int arcSize = this.Height - 1;
            Rectangle leftArc = new Rectangle(0,0, arcSize, arcSize);
            Rectangle rightArc = new Rectangle(this.Width - arcSize -2,0,arcSize, arcSize);
            GraphicsPath path = new GraphicsPath();
            path.StartFigure();
            path.AddArc(leftArc, 90, 180);
            path.AddArc(rightArc, 270, 180);
            path.CloseFigure();

            return path;
        }
        protected override void OnPaint(PaintEventArgs pe)
        {
            int toggleSize = this.Height - 5;
            pe.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            pe.Graphics.Clear(this.Parent!.BackColor);

            if(this.Checked)//ON
            {
                pe.Graphics.FillPath(new SolidBrush(onBackColor), GetFigurePath());
                pe.Graphics.FillEllipse(new SolidBrush(onToggleColor), new Rectangle(this.Width - this.Height - 1, 2, toggleSize, toggleSize));
            }
            else //OFF
            {
                pe.Graphics.FillPath(new SolidBrush(offBackColor), GetFigurePath());
                pe.Graphics.FillEllipse(new SolidBrush(offToggleColor), new Rectangle(2, 2, toggleSize, toggleSize));
            }
        }
    }
}
