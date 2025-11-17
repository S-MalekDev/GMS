using FontAwesome.Sharp;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Runtime.InteropServices;
using WinFormsClient.Enums.EnTheme;
using WinFormsClient.Forms.Member;
using WinFormsClient.Forms.Offer;
using WinFormsClient.Forms.Person;
using WinFormsClient.Forms.Plans;
using WinFormsClient.Forms.Subscription;
using WinFormsClient.Forms.Theme;
using WinFormsClient.Forms.Trainer;
using WinFormsClient.Forms.User;
using WinFormsClient.Themes;



namespace WinFormsClient.Forms
{
    public partial class DashboardForm : BaseForm
    {
        public delegate void DarkModeCheckedButtonEventHandler(object sender, bool isActive);
        public event DarkModeCheckedButtonEventHandler? DarkModeCheckedButtonChanged;
        protected enum enMenuState { Open = 0, Close = 1 }
        private enMenuState _menuState = enMenuState.Open;
        protected enMenuState MenuState
        {
            get { return _menuState; }
            set
            {
                _menuState = value;

                switch (_menuState)
                {
                    case enMenuState.Open:
                        {
                            OpenMenu();
                            break;
                        }
                    case enMenuState.Close:
                        {
                            CloseMenu();
                            break;
                        }
                }
            }
        }

        private Form? _activeChildForm;
        private Themes.Theme? _currentAppTheme;
        private ContextMenuStrip? _currentOppendCms;
        private IconButton? _currentHoverdButton;

        private readonly IServiceProvider _serviceProvider;
        public DashboardForm(IServiceProvider serviceProvider)
        {
            InitializeComponent();
            ApplyTheme();

            _serviceProvider = serviceProvider;
        }

        private void DashboardForm_Load(object sender, EventArgs e)
        {
            LoadThemeDetails();
            StartCurrentDateTime();
        }


        #region Window Behavior Customization
        [StructLayout(LayoutKind.Sequential)]
        public struct POINT
        {
            public int x;
            public int y;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct MINMAXINFO
        {
            public POINT ptReserved;
            public POINT ptMaxSize;
            public POINT ptMaxPosition;
            public POINT ptMinTrackSize;
            public POINT ptMaxTrackSize;
        }

        protected override void WndProc(ref Message m)
        {
            // الهدف من هذه الدالة هو تكبير واجهة التطبيق عند سحبها للاعلى تماما

            base.WndProc(ref m);

            const int WM_EXITSIZEMOVE = 0x0232;
            const int WM_GETMINMAXINFO = 0x24;

            if (m.Msg == WM_EXITSIZEMOVE)
            {
                if (this.Top <= 0 && this.WindowState != FormWindowState.Maximized)
                {
                    this.WindowState = FormWindowState.Maximized;
                }
            }
            if (m.Msg == WM_GETMINMAXINFO)
            {
                WmGetMinMaxInfo(m.HWnd, m.LParam);
            }
        }

        private void WmGetMinMaxInfo(IntPtr hWnd, IntPtr lParam)
        {
            // احصل على معلومات الشاشة الحالية (بدون شريط المهام)
            Screen screen = Screen.FromHandle(hWnd);
            Rectangle workingArea = screen.WorkingArea;
            Rectangle screenArea = screen.Bounds;

            MINMAXINFO mmi = Marshal.PtrToStructure<MINMAXINFO>(lParam);

            mmi.ptMaxPosition.x = workingArea.Left - screenArea.Left;
            mmi.ptMaxPosition.y = workingArea.Top - screenArea.Top;
            mmi.ptMaxSize.x = workingArea.Width;
            mmi.ptMaxSize.y = workingArea.Height;

            Marshal.StructureToPtr(mmi, lParam, true);
        }
        #endregion

        #region Window Controls
        private void ibtnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void ibtnWindowNormalOrMaximizeClick(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Maximized)
                this.WindowState = FormWindowState.Normal;
            else
                this.WindowState = FormWindowState.Maximized;

        }

        private void ibtnWindowMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void DashboardForm_Resize(object sender, EventArgs e)
        {
            ibtnWindowNormalOrMaximize.IconChar = (this.WindowState == FormWindowState.Maximized) ? IconChar.WindowRestore : IconChar.WindowMaximize;

        }
        #endregion

        #region Form Drag Logic
        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HTCAPTION = 0x2;
        private void pnlHeader_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(this.Handle, WM_NCLBUTTONDOWN, HTCAPTION, 0);
            }
        }
        #endregion

        #region Context Menu Items Click Events
        private void AllPeopleTSMI_Click(object sender, EventArgs e)
        {
            var frm = _serviceProvider.GetRequiredService<ManagePeopleForm>();
            OpenChildForm(frm);
        }

        private void UsersTSMI_Click(object sender, EventArgs e)
        {
            var frm = new ManageUsersForm();
            OpenChildForm(frm);
        }
        private void MembersTSMI_Click(object sender, EventArgs e)
        {
            var frm = new ManageMembersForm();
            OpenChildForm(frm);
        }
        private void TrainersTSMI_Click(object sender, EventArgs e)
        {
            var frm = new ManageTrainersForm();
            OpenChildForm(frm);
        }
        private void AllSubscriptionTSMI_Click(object sender, EventArgs e)
        {
            var frm = new ManageSubscriptionForm();
            OpenChildForm(frm);
        }

        private void PlansTSMI_Click(object sender, EventArgs e)
        {
            var frm = new SubscriptionPlansForm();
            OpenChildForm(frm);
        }

        private void OffersTSMI_Click(object sender, EventArgs e)
        {
            var frm = new SubscriptionOffersForm();
            OpenChildForm(frm);
        }

        private void themesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenThemeSelectorForm();
        }

        #endregion

        private void LoadThemeDetails()
        {
            MenuState = (Properties.Settings.Default.IsMenuClosed)? enMenuState.Close:enMenuState.Open;


            var themeValue = Properties.Settings.Default.ThemeValue;
            _currentAppTheme = ThemeSelector.SelectTheme((enTheme)themeValue);

            if(themeValue == (byte)enTheme.Dark)
            {
                var tempThemeValueBeforeDark = Properties.Settings.Default.ThemeValueBeforeDark;
                toggelButtonDarkMode.Checked = true;
                Properties.Settings.Default.ThemeValueBeforeDark = tempThemeValueBeforeDark;
                Properties.Settings.Default.Save();
            }
        }

        private void CloseMenu()
        {
            pnlDashboardMenu.Width = 120;

            foreach (var control in this.pnlDashboardMenu.Controls)
            {
                if (control is IconButton)
                {
                    var iconButton = (IconButton)control;
                    var tag = iconButton.Tag?.ToString();

                    if (tag == "Menu Button" || tag == "Sub Menu Button")
                    {
                        iconButton.ImageAlign = ContentAlignment.MiddleCenter;
                        iconButton.Text = "";
                    }
                }
            }

            Properties.Settings.Default.IsMenuClosed = true;
            Properties.Settings.Default.Save();
        }

        private void OpenMenu()
        {

            Dictionary<IconButton, string> ButtonsTextMap = new Dictionary<IconButton, string>()
            {
               {ibtnHome,"Home"},{ibtnPeople,"People"},{ibtnSubscriptions,"Subscriptions"},{ibtnSettings,"Settings"},
                {ibtnAllPeopleSubMenu,"All"},{ibtnUsersSubMenu,"Users"},{ibtnMembersSubMenu,"Members"},{ibtnTrainersSubMenu,"Trainers"},
                {ibtnAllSubscriptionsSubMenu,"All Subscriptions"},{ibtnPlansSubMenu,"Plans"},{ibtnOffersSubMenu,"Offers"},
                {ThemesTSMI,"Themes"}
            };


            pnlDashboardMenu.Width = 260;

            foreach (var control in this.pnlDashboardMenu.Controls)
            {
                if (control is IconButton)
                {
                    var iconButton = (IconButton)control;
                    var tag = iconButton.Tag?.ToString();

                    if (tag == "Menu Button" || tag == "Sub Menu Button")
                    {
                        iconButton.ImageAlign = ContentAlignment.MiddleLeft;

                        if (ButtonsTextMap.TryGetValue(iconButton, out var ButtonText))
                            iconButton.Text = ButtonText;
                    }
                }
            }

            Properties.Settings.Default.IsMenuClosed = false;
            Properties.Settings.Default.Save();
        }

        private void OpenChildForm(Form childForm)
        {

            if (_activeChildForm != null)
                _activeChildForm.Close();

            _activeChildForm = childForm;
            childForm.TopLevel = false;
            childForm.Dock = DockStyle.Fill;
            pnlFormContainer.Controls.Add(childForm);
            childForm.BringToFront();
            childForm.Show();

        }

        private void MenuButtonsClick(object sender, EventArgs e)
        {
            // This method is used by all icon menu buttons 

            if (MenuState == enMenuState.Close)
                return;

            // Inboxing the sender
            IconButton iconButtonClicked = (IconButton)sender;


            Dictionary<IconButton, Panel> ButtonsSubMenuPanelMap = new Dictionary<IconButton, Panel>()
            {
                {ibtnHome, pnlHomeSubMenu}, {ibtnPeople, pnlPeopleSubMenu}, {ibtnSubscriptions,
                    pnlSubscriptionsSubMenu},{ibtnSettings, pnlSettingsSubMenu}
            };

            foreach (var bttonSubMenu in ButtonsSubMenuPanelMap)
            {
                if (bttonSubMenu.Key == iconButtonClicked)
                {
                    bttonSubMenu.Value.Visible = !bttonSubMenu.Value.Visible;
                    continue;
                }

                bttonSubMenu.Value.Visible = (bttonSubMenu.Key == iconButtonClicked);
            }
        }

        private void PeopleSubMenuButtonClick(object sender, EventArgs e)
        {
            var ibtn = (IconButton)sender;

            Form frm = ibtn.Text.Trim() switch
            {
                "All" => _serviceProvider.GetRequiredService<ManagePeopleForm>(),
                "Users" => new ManageUsersForm(),
                "Members" => new ManageMembersForm(),
                "Trainers" => new ManageTrainersForm(),
                _ =>  _serviceProvider.GetRequiredService<ManagePeopleForm>()
            };

            OpenChildForm(frm);

            pnlPeopleSubMenu.Visible = false;
        }

        private void SubscriptionSubMenuButtonClick(object sender, EventArgs e)
        {
            var ibtn = (IconButton)sender;
            var ButtonTest = ibtn.Text;
            Form frm = (ButtonTest) switch
            {
                "All Subscriptions" => new ManageSubscriptionForm(),
                "Plans" => new SubscriptionPlansForm(),
                "Offers" => new SubscriptionOffersForm(),
                _ => new ManageSubscriptionForm()
            };

            OpenChildForm(frm);

            pnlSubscriptionsSubMenu.Visible = false;
        }

        public void OnDarkModeCheckedButtonChanged(bool isActive)
        {
            DarkModeCheckedButtonChanged?.Invoke(this, isActive);
        }

        private void OpenThemeSelectorForm()
        {
            var frm = _serviceProvider.GetRequiredService<ThemeSelectorForm>();
            frm.ThemeChanged += OnThemeChanged;
            OpenChildForm(frm);
        }

        private void SettingsSubMenuButtonsClick(object sender, EventArgs e)
        {
            OpenThemeSelectorForm();

            pnlSettingsSubMenu.Visible = false;
        }

        private void OnThemeChanged(object sender, enTheme themeSelected)
        {
          
            if (themeSelected != enTheme.Dark)
            {
                Properties.Settings.Default.ThemeValueBeforeDark = (byte)themeSelected;
            }

            toggelButtonDarkMode.Checked = (themeSelected == enTheme.Dark);

            ApplyTheme();
            LoadThemeDetails();
        }

        private void ibtnToggleMenu_Click(object sender, EventArgs e)
        {
           
            MenuState = (_menuState == enMenuState.Close) ? enMenuState.Open : enMenuState.Close;

            if (MenuState == enMenuState.Open)
                return;

            foreach (var control in pnlDashboardMenu.Controls)
            {
                if (control is Panel)
                {
                    var pnl = (Panel)control;
                    var tag = pnl.Tag?.ToString();

                    if (tag == "Sub Menu Panels")
                        pnl.Visible = false;
                }
            }
        }

        private void MenuButtons_MouseHover(object sender, EventArgs e)
        {
            var ibtn = (IconButton)sender;

            ibtn.IconColor = _currentAppTheme!.IconButtonPressedIconColor;


            if (MenuState == enMenuState.Open)
                return;

            _currentHoverdButton = ibtn;

            if (ibtn == ibtnPeople)
            {
                cmsPeopleSubMenu.Show(ibtnPeople, new Point(ibtnPeople.Width, 0));
                _currentOppendCms = cmsPeopleSubMenu;
            }
            else if (ibtn == ibtnSubscriptions)
            {
                cmsSubscriptionSubMenu.Show(ibtnSubscriptions, new Point(ibtnSubscriptions.Width, 0));
                _currentOppendCms = cmsSubscriptionSubMenu;

            }
            else if (ibtn == ibtnSettings)
            {
                cmsSettingsSubMenu.Show(ibtnSettings, new Point(ibtnSettings.Width, 0));
                _currentOppendCms = cmsSettingsSubMenu;
            }

            hideContextMenuStripTimer.Start();
        }

        private void MenuButtons_MouseLeave(object sender, EventArgs e)
        {
            var ibtn = (IconButton)sender;
            ibtn.IconColor = _currentAppTheme!.IconButtonIconColor;
        }

        private void SubMenuButtons_MouseHover(object sender, EventArgs e)
        {
            var ibtn = (IconButton)sender;
            ibtn.IconColor = _currentAppTheme!.IconButtonPressedIconColor;
        }

        private void SubMenuButtons_MouseLeave(object sender, EventArgs e)
        {
            var ibtn = (IconButton)sender;
            ibtn.IconColor = _currentAppTheme!.IconButtonIconColor;
        }

        private void hideContextMenuStripTimer_Tick(object sender, EventArgs e)
        {
            if (_currentOppendCms is null || _currentHoverdButton is null)
                return;

            Point mousePos = Cursor.Position;

            // نحول الإحداثيات إلى نظام الشاشة
            Rectangle menuRect = _currentOppendCms.Bounds;
            Rectangle buttonRect = _currentHoverdButton.RectangleToScreen(_currentHoverdButton.ClientRectangle);

            if (!menuRect.Contains(mousePos) && !buttonRect.Contains(mousePos))
            {
                _currentOppendCms.Hide();
                hideContextMenuStripTimer.Stop();

                _currentOppendCms = null;
                _currentHoverdButton = null;
            }
        }

        private void StartCurrentDateTime()
        {
            updateDateTimeTimer.Start();
        }

        private void updateDateTimeTimer_Tick(object sender, EventArgs e)
        {
            var CurrentDateTime = DateTime.Now;
            lblDate.Text = CurrentDateTime.ToString("dd - MMM - yyyy");
            lblTime.Text = CurrentDateTime.ToString("HH:mm:ss");
        }

        private void toggelButtonDarkMode_CheckedChanged(object sender, EventArgs e)
        {

            if(toggelButtonDarkMode.Checked)//ON
            {
                byte themeValueBeforeDark = Properties.Settings.Default.ThemeValue;

                if(themeValueBeforeDark == (byte) enTheme.Dark)
                    Properties.Settings.Default.ThemeValueBeforeDark = (byte) enTheme.Light;//Default
                else
                    Properties.Settings.Default.ThemeValueBeforeDark = Properties.Settings.Default.ThemeValue;
                
                Properties.Settings.Default.ThemeValue = (byte)enTheme.Dark;
               
            }
            else//OFF
            {
                Properties.Settings.Default.ThemeValue = Properties.Settings.Default.ThemeValueBeforeDark;
            }

            Properties.Settings.Default.Save();
            LoadThemeDetails();
            RefreshThemeSelectorFormIfOpenAndApplyTheme();
        }

        private void CloseAndOpenNewThemeSelectorForm()
        {
            OpenThemeSelectorForm();
        }

        private void RefreshThemeSelectorFormIfOpenAndApplyTheme()
        {
            ApplyTheme();

            bool isOpen = false;

            foreach (Form frm in Application.OpenForms)
            {
                if (frm is ThemeSelectorForm)
                {
                    isOpen = true;
                    break;
                }
            }

            if(isOpen) CloseAndOpenNewThemeSelectorForm();
        }
    }
}
