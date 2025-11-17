using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsClient.Themes
{
    public class Theme
    {
        public string Name { get; set; } = string.Empty;
        public Color PrimaryTextColor { get; set; }
        public Color PrimaryBackgroundColor { get; set; }
        public Color PrimaryColor { get; set; }
        public Color SecondaryColor { get; set; }
        public Color SubMenuButtonBackgroundColor { get; set; }
        public Color IconButtonTextColor { get; set; }
        public Color IconButtonIconColor { get; set; }
        public Color IconButtonPressedIconColor { get; set; }
        public Color ToggleMenuButtonIconColor { get; set; }
        public Color WindowButtonIconColor { get; set; }
        public Color HeaderTextColor { get; set; }
    }
}
