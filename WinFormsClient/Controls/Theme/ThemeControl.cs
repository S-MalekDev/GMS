
using System;
using System.Runtime.CompilerServices;
using WinFormsClient.Enums.EnTheme;

namespace WinFormsClient.Controls.Theme
{
    public partial class ThemeControl : UserControl
    {
        public delegate void ThemeSelectedHandler(object sender, enTheme theme);
        public event ThemeSelectedHandler? ThemeSelected;

        public bool Checked
        {
            get
            {
                return chbThemeSelected.Checked;
            }
            set
            {
                chbThemeSelected.Checked = value;
            }
        }

        private enTheme _Theme = enTheme.Dark;

        public enTheme Theme
        {
            get
            {
                return _Theme;
            }

            set
            {
                _Theme = value;
                _ApplyThemeOnControl();
            }
        }

        public ThemeControl()
        {
            InitializeComponent();

        }

        private void _ApplyThemeOnControl()
        {
            var ThemeSelected = Themes.ThemeSelector.SelectTheme(Theme);

            chbThemeSelected.Text = ThemeSelected.Name;
            pnlHeaderColor.BackColor = ThemeSelected.PrimaryColor;
            pnlMenuColor.BackColor = ThemeSelected.SecondaryColor;
            pnlFormThemDetails.BackColor = ThemeSelected.PrimaryBackgroundColor;
            pnlTitleColor.BackColor = ThemeSelected.HeaderTextColor;
            pnlForeColor1.BackColor = ThemeSelected.PrimaryTextColor;
            pnlForeColor2.BackColor = ThemeSelected.PrimaryTextColor;
            pnlForeColor3.BackColor = ThemeSelected.PrimaryTextColor;
            pnlForColor4.BackColor = ThemeSelected.PrimaryTextColor;
            pnlMenuButton1.BackColor = ThemeSelected.IconButtonTextColor;
            pnlMenuButton2.BackColor = ThemeSelected.IconButtonTextColor;
            pnlMenuButton3.BackColor = ThemeSelected.IconButtonTextColor;
            pnlMenuButton4.BackColor = ThemeSelected.IconButtonTextColor;
            pnlMenuButton5.BackColor = ThemeSelected.IconButtonTextColor;
            pnlToggleButton.BackColor = ThemeSelected.ToggleMenuButtonIconColor;

        }

        private void OnThemeControlClick(object sender, EventArgs e)
        {
            chbThemeSelected.Checked = true;

            OnThemeSelected(Theme);
        }
        
        private void OnThemeSelected(enTheme theme)
        {
            ThemeSelected?.Invoke(this, theme);
        }

    }
}
