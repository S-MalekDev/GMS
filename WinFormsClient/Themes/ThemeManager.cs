using FontAwesome.Sharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls.Primitives;
using WinFormsClient.Controls.Theme;
using WinFormsClient.Enums.EnTheme;


namespace WinFormsClient.Themes
{
    public class ThemeManager
    {
        private static  Theme _currentTheme = Themes.DarkOrang;


        public static void ApplyTheme(Form form)
        {
            byte ThemeValue = Properties.Settings.Default.ThemeValue;
            _currentTheme = ThemeSelector.SelectTheme((enTheme)ThemeValue);



            ApplyThemeToAllControls(form);
        }

        private static void ApplyThemeToAllControls(Control parent)
        {
            if (parent is ThemeControl) return;
            if (parent.Tag?.ToString() == "Non Changeable") return;

            // Apply theme to current control
            ApplyThemeToControl(parent);

            // ثم تابع التكرار على كل الأبناء
            foreach (Control child in parent.Controls)
            {
                ApplyThemeToAllControls(child);  // recursive call
            }
        }
        
        private static void ApplyThemeToIconButton(IconButton ibtn)
        {
            var tag = ibtn.Tag?.ToString();

            if (tag == "Toggle Menu")
            {
                ibtn.BackColor = _currentTheme.SecondaryColor;
                ibtn.IconColor = _currentTheme.ToggleMenuButtonIconColor;
                return;
            }

            if(tag == "Menu Button")
            {
                ibtn.BackColor = _currentTheme.SecondaryColor;
                ibtn.IconColor = _currentTheme.IconButtonIconColor;
                ibtn.ForeColor = _currentTheme.IconButtonTextColor;
                ibtn.FlatAppearance.MouseDownBackColor = Color.Transparent; 
                ibtn.FlatAppearance.MouseOverBackColor = Color.FromArgb(50, _currentTheme.PrimaryColor);
                return;
            }

            if (tag == "Sub Menu Button")
            {
                ibtn.BackColor = _currentTheme.SubMenuButtonBackgroundColor;
                ibtn.IconColor = _currentTheme.IconButtonIconColor;
                ibtn.ForeColor = _currentTheme.IconButtonTextColor;
                return;
            }

            if (tag == "Window Button")
            {
                ibtn.IconColor = _currentTheme.WindowButtonIconColor;
                ibtn.BackColor = _currentTheme.PrimaryColor;
                return;
            }
        }

        private static void ApplyThemeToPanel(Panel pnl)
        {
            pnl.BackColor = (pnl.Tag?.ToString()) switch
            {
                "Menu Panel" => _currentTheme.SecondaryColor,
                "Form Container" or "List View Container" or "Container" => _currentTheme.PrimaryBackgroundColor,
                "Window Panel" => _currentTheme.PrimaryColor,
                _ => _currentTheme.PrimaryColor
            };
        }

        private static void ApplyThemeToLabel(Label lbl)
        {
            if (lbl.Tag?.ToString() == "Title")
                lbl.ForeColor = _currentTheme.HeaderTextColor;
        }

        private static void ApplyThemeToDataGridView(DataGridView dgv)
        {
            dgv.BackgroundColor = _currentTheme.PrimaryBackgroundColor;
            dgv.DefaultCellStyle.BackColor = _currentTheme.PrimaryColor;
            dgv.DefaultCellStyle.ForeColor = _currentTheme.WindowButtonIconColor;
            dgv.GridColor = _currentTheme.SecondaryColor;
            dgv.DefaultCellStyle.SelectionForeColor = _currentTheme.IconButtonTextColor;
            dgv.DefaultCellStyle.SelectionBackColor = _currentTheme.SecondaryColor;
            // Odd Rows Style
            dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray;
            dgv.AlternatingRowsDefaultCellStyle.ForeColor = Color.Black;
            // Column Headers
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = _currentTheme.PrimaryTextColor;
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);

            
        }

        private static void ApplyThemeToControl(Control ctrl)
        {

            if (ctrl is IconButton iconButton)
            {
                ApplyThemeToIconButton(iconButton);
                return;
            }


            if (ctrl is Panel pnl)
            {
                ApplyThemeToPanel(pnl);
                return;
            }

            if (ctrl is Label lbl)
            {
                ApplyThemeToLabel(lbl);
                return;
            }

            if (ctrl is DataGridView dgv)
            {
                ApplyThemeToDataGridView(dgv);
                return;
            }


            ctrl.BackColor = _currentTheme.PrimaryBackgroundColor;
            ctrl.ForeColor = _currentTheme.PrimaryTextColor;
        }
    }
}
