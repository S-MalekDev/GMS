using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormsClient.Controls.Theme;
using WinFormsClient.Enums.EnTheme;

namespace WinFormsClient.Forms.Theme
{
    public partial class ThemeSelectorForm : BaseForm
    {
        public delegate void ThemeChangedEventHandler(object sender, enTheme theme);
        public event ThemeChangedEventHandler? ThemeChanged;

        private enTheme _currentThemeSelected;
        public ThemeSelectorForm()
        {
            InitializeComponent();
            ApplyTheme();
        }
        private void ThemeSelectorForm_Load(object sender, EventArgs e)
        {
            SelectCurrentTheme();
        }

        private void SelectCurrentTheme()
        {
            _currentThemeSelected = (enTheme)Properties.Settings.Default.ThemeValue;

            foreach (var control in this.Controls)
            {
                if (control is ThemeControl themeControl)
                {
                    if (themeControl.Theme == _currentThemeSelected)
                    {
                        themeControl.Checked = true;
                        return;
                    }
                }
            }
        }
        private void SelectOnlyThisThemeControl(enTheme theme)
        {
            foreach (var control in this.Controls)
            {
                if (control is ThemeControl)
                {
                    var themeControl = (ThemeControl)control;
                    themeControl.Checked = themeControl.Theme == theme ? true : false;
                }
            }
        }

        public void OnThemeSelected(object sender, enTheme themeTypeSelected)
        {
            if (themeTypeSelected == _currentThemeSelected)
                return;

            _currentThemeSelected = themeTypeSelected;

            SelectOnlyThisThemeControl(themeTypeSelected);

            Properties.Settings.Default.ThemeValue = (byte)themeTypeSelected;
            Properties.Settings.Default.Save();

            OnThemeChanged(themeTypeSelected);
        }

        private void OnThemeChanged(enTheme theme)
        {
            ThemeChanged?.Invoke(this, theme);
        }

    }
}
