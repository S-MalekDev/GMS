using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinFormsClient.Enums.EnTheme;

namespace WinFormsClient.Themes
{
    public class ThemeSelector
    {
        public static Theme SelectTheme(enTheme theme)
        {
            return theme switch
            {
                enTheme.Dark => Themes.Dark,
                enTheme.DarkOrang => Themes.DarkOrang,
                enTheme.Light => Themes.Light,
                enTheme.BlueMist=> Themes.BlueMist,
                _ => Themes.Dark
            };
        }
    }
}
