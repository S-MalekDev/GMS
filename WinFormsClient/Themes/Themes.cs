using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsClient.Themes
{
    public static class Themes
    {
        public static Theme Dark = new Theme
        {
            Name = "Dark",
            PrimaryTextColor = Color.White,
            PrimaryBackgroundColor = Color.FromArgb(44, 44, 44),
            PrimaryColor = Color.FromArgb(64, 67, 78),
            SecondaryColor = Color.FromArgb(7, 7, 7),
            SubMenuButtonBackgroundColor = Color.FromArgb(64, 67, 78),
            IconButtonTextColor = Color.FromArgb(224, 224, 224),
            IconButtonIconColor = Color.FromArgb(224, 224, 224),
            IconButtonPressedIconColor = Color.FromArgb(255, 87, 34),
            ToggleMenuButtonIconColor = Color.FromArgb(64, 67, 78),
            WindowButtonIconColor = Color.FromArgb(224, 224, 224),
            HeaderTextColor = Color.FromArgb(176, 176, 176),
        };
        public static Theme DarkOrang = new Theme
        {
            Name = "Dark Orang",
            PrimaryTextColor = Color.Black,
            PrimaryBackgroundColor = SystemColors.Control,
            PrimaryColor = Color.FromArgb(246, 128, 5),
            SecondaryColor = Color.FromArgb(30,30,30),
            SubMenuButtonBackgroundColor = Color.FromArgb(47, 47, 48),
            IconButtonTextColor =Color.White,
            IconButtonIconColor =Color.White,
            IconButtonPressedIconColor = Color.FromArgb(246, 128, 5),
            ToggleMenuButtonIconColor = Color.FromArgb(246, 128, 5),
            WindowButtonIconColor =Color.Black,
            HeaderTextColor = Color.Black,
        };
        public static Theme Light = new Theme
        {
            Name = "Light",
            PrimaryTextColor = Color.FromArgb(33, 33, 33),
            PrimaryBackgroundColor = Color.FromArgb(245, 245, 245),
            PrimaryColor = Color.FromArgb(221, 221, 221),
            SecondaryColor = Color.FromArgb(255, 255, 255),
            SubMenuButtonBackgroundColor = Color.FromArgb(221, 221, 221),
            IconButtonTextColor = Color.FromArgb(33, 33, 33),
            IconButtonIconColor = Color.FromArgb(33, 33, 33),
            IconButtonPressedIconColor = Color.FromArgb(246, 128, 5),
            ToggleMenuButtonIconColor = Color.FromArgb(246, 128, 5),
            WindowButtonIconColor = Color.FromArgb(33, 33, 33),
            HeaderTextColor = Color.FromArgb(117, 117, 117),
        };
        public static Theme BlueMist = new Theme
        {
            Name = "Blue Mist",
            PrimaryTextColor = Color.FromArgb(34, 34, 34),
            PrimaryBackgroundColor = Color.FromArgb(230, 240, 250),
            PrimaryColor = Color.FromArgb(65, 105, 225),
            SecondaryColor = Color.FromArgb(240, 248, 255),
            SubMenuButtonBackgroundColor = Color.FromArgb(230, 240, 250),
            IconButtonTextColor = Color.FromArgb(34, 34, 34),
            IconButtonIconColor = Color.FromArgb(34, 34, 34),
            IconButtonPressedIconColor = Color.FromArgb(39, 64, 139),
            ToggleMenuButtonIconColor = Color.FromArgb(39, 64, 139),
            WindowButtonIconColor = Color.FromArgb(240, 248, 255),
            HeaderTextColor = Color.FromArgb(85, 85, 85),
        };
    }
}
