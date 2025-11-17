namespace WinFormsClient.Forms
{
    partial class DashboardForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DashboardForm));
            pnlHeader = new Panel();
            label1 = new Label();
            toggelButtonDarkMode = new WinFormsClient.CustomControls.ToggleButton();
            ibtnWindowMinimize = new FontAwesome.Sharp.IconButton();
            ibtnWindowNormalOrMaximize = new FontAwesome.Sharp.IconButton();
            ibtnClose = new FontAwesome.Sharp.IconButton();
            ibtnLogOut = new FontAwesome.Sharp.IconButton();
            pnlDashboardMenu = new Panel();
            pnlSettingsSubMenu = new Panel();
            ThemesTSMI = new FontAwesome.Sharp.IconButton();
            ibtnSettings = new FontAwesome.Sharp.IconButton();
            cmsSettingsSubMenu = new ContextMenuStrip(components);
            themesToolStripMenuItem = new ToolStripMenuItem();
            pnlSubscriptionsSubMenu = new Panel();
            ibtnOffersSubMenu = new FontAwesome.Sharp.IconButton();
            ibtnPlansSubMenu = new FontAwesome.Sharp.IconButton();
            ibtnAllSubscriptionsSubMenu = new FontAwesome.Sharp.IconButton();
            ibtnSubscriptions = new FontAwesome.Sharp.IconButton();
            cmsSubscriptionSubMenu = new ContextMenuStrip(components);
            AllSubscriptionTSMI = new ToolStripMenuItem();
            PlansTSMI = new ToolStripMenuItem();
            OffersTSMI = new ToolStripMenuItem();
            pnlPeopleSubMenu = new Panel();
            ibtnTrainersSubMenu = new FontAwesome.Sharp.IconButton();
            ibtnMembersSubMenu = new FontAwesome.Sharp.IconButton();
            ibtnUsersSubMenu = new FontAwesome.Sharp.IconButton();
            ibtnAllPeopleSubMenu = new FontAwesome.Sharp.IconButton();
            ibtnPeople = new FontAwesome.Sharp.IconButton();
            cmsPeopleSubMenu = new ContextMenuStrip(components);
            AllPeopleTSMI = new ToolStripMenuItem();
            UsersTSMI = new ToolStripMenuItem();
            MembersTSMI = new ToolStripMenuItem();
            TrainersTSMI = new ToolStripMenuItem();
            pnlHomeSubMenu = new Panel();
            ibtnHome = new FontAwesome.Sharp.IconButton();
            pnlToggleMenu = new Panel();
            ibtnToggleMenu = new FontAwesome.Sharp.IconButton();
            pnlFormContainer = new Panel();
            tableLayoutPanel1 = new TableLayoutPanel();
            lblTime = new Label();
            lblDate = new Label();
            pbGymLogo = new PictureBox();
            hideContextMenuStripTimer = new System.Windows.Forms.Timer(components);
            updateDateTimeTimer = new System.Windows.Forms.Timer(components);
            pnlHeader.SuspendLayout();
            pnlDashboardMenu.SuspendLayout();
            pnlSettingsSubMenu.SuspendLayout();
            cmsSettingsSubMenu.SuspendLayout();
            pnlSubscriptionsSubMenu.SuspendLayout();
            cmsSubscriptionSubMenu.SuspendLayout();
            pnlPeopleSubMenu.SuspendLayout();
            cmsPeopleSubMenu.SuspendLayout();
            pnlFormContainer.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbGymLogo).BeginInit();
            SuspendLayout();
            // 
            // pnlHeader
            // 
            pnlHeader.BackColor = Color.FromArgb(246, 128, 5);
            pnlHeader.Controls.Add(label1);
            pnlHeader.Controls.Add(toggelButtonDarkMode);
            pnlHeader.Controls.Add(ibtnWindowMinimize);
            pnlHeader.Controls.Add(ibtnWindowNormalOrMaximize);
            pnlHeader.Controls.Add(ibtnClose);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(264, 4);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(1482, 64);
            pnlHeader.TabIndex = 5;
            pnlHeader.Tag = "Window Panel";
            pnlHeader.MouseDown += pnlHeader_MouseDown;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Left;
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(11, 25);
            label1.Name = "label1";
            label1.Size = new Size(100, 23);
            label1.TabIndex = 4;
            label1.Text = "Dark Mode";
            // 
            // toggelButtonDarkMode
            // 
            toggelButtonDarkMode.Anchor = AnchorStyles.Left;
            toggelButtonDarkMode.AutoSize = true;
            toggelButtonDarkMode.Location = new Point(110, 23);
            toggelButtonDarkMode.Name = "toggelButtonDarkMode";
            toggelButtonDarkMode.OffBackColor = Color.Gray;
            toggelButtonDarkMode.OffToggleColor = Color.Gainsboro;
            toggelButtonDarkMode.OnBackColor = Color.FromArgb(44, 44, 44);
            toggelButtonDarkMode.OnToggleColor = Color.White;
            toggelButtonDarkMode.Size = new Size(142, 27);
            toggelButtonDarkMode.TabIndex = 3;
            toggelButtonDarkMode.Text = "toggleButton1";
            toggelButtonDarkMode.UseVisualStyleBackColor = true;
            toggelButtonDarkMode.CheckedChanged += toggelButtonDarkMode_CheckedChanged;
            // 
            // ibtnWindowMinimize
            // 
            ibtnWindowMinimize.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            ibtnWindowMinimize.FlatAppearance.BorderSize = 0;
            ibtnWindowMinimize.FlatStyle = FlatStyle.Flat;
            ibtnWindowMinimize.IconChar = FontAwesome.Sharp.IconChar.WindowMinimize;
            ibtnWindowMinimize.IconColor = Color.Black;
            ibtnWindowMinimize.IconFont = FontAwesome.Sharp.IconFont.Auto;
            ibtnWindowMinimize.IconSize = 25;
            ibtnWindowMinimize.Location = new Point(1379, -1);
            ibtnWindowMinimize.Name = "ibtnWindowMinimize";
            ibtnWindowMinimize.Size = new Size(25, 25);
            ibtnWindowMinimize.TabIndex = 2;
            ibtnWindowMinimize.Tag = "Window Button";
            ibtnWindowMinimize.UseVisualStyleBackColor = true;
            ibtnWindowMinimize.Click += ibtnWindowMinimize_Click;
            // 
            // ibtnWindowNormalOrMaximize
            // 
            ibtnWindowNormalOrMaximize.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            ibtnWindowNormalOrMaximize.FlatAppearance.BorderSize = 0;
            ibtnWindowNormalOrMaximize.FlatStyle = FlatStyle.Flat;
            ibtnWindowNormalOrMaximize.IconChar = FontAwesome.Sharp.IconChar.WindowMaximize;
            ibtnWindowNormalOrMaximize.IconColor = Color.Black;
            ibtnWindowNormalOrMaximize.IconFont = FontAwesome.Sharp.IconFont.Auto;
            ibtnWindowNormalOrMaximize.IconSize = 25;
            ibtnWindowNormalOrMaximize.Location = new Point(1412, -1);
            ibtnWindowNormalOrMaximize.Name = "ibtnWindowNormalOrMaximize";
            ibtnWindowNormalOrMaximize.Size = new Size(25, 25);
            ibtnWindowNormalOrMaximize.TabIndex = 1;
            ibtnWindowNormalOrMaximize.Tag = "Window Button";
            ibtnWindowNormalOrMaximize.UseVisualStyleBackColor = true;
            ibtnWindowNormalOrMaximize.Click += ibtnWindowNormalOrMaximizeClick;
            // 
            // ibtnClose
            // 
            ibtnClose.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            ibtnClose.FlatAppearance.BorderSize = 0;
            ibtnClose.FlatStyle = FlatStyle.Flat;
            ibtnClose.IconChar = FontAwesome.Sharp.IconChar.Close;
            ibtnClose.IconColor = Color.Black;
            ibtnClose.IconFont = FontAwesome.Sharp.IconFont.Auto;
            ibtnClose.IconSize = 25;
            ibtnClose.Location = new Point(1445, -1);
            ibtnClose.Name = "ibtnClose";
            ibtnClose.Size = new Size(25, 25);
            ibtnClose.TabIndex = 0;
            ibtnClose.Tag = "Window Button";
            ibtnClose.UseVisualStyleBackColor = true;
            ibtnClose.Click += ibtnClose_Click;
            // 
            // ibtnLogOut
            // 
            ibtnLogOut.BackColor = Color.FromArgb(24, 11, 4);
            ibtnLogOut.Dock = DockStyle.Bottom;
            ibtnLogOut.FlatAppearance.BorderSize = 0;
            ibtnLogOut.FlatStyle = FlatStyle.Flat;
            ibtnLogOut.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            ibtnLogOut.ForeColor = Color.White;
            ibtnLogOut.IconChar = FontAwesome.Sharp.IconChar.SignOutAlt;
            ibtnLogOut.IconColor = Color.White;
            ibtnLogOut.IconFont = FontAwesome.Sharp.IconFont.Auto;
            ibtnLogOut.ImageAlign = ContentAlignment.MiddleLeft;
            ibtnLogOut.Location = new Point(0, 867);
            ibtnLogOut.Name = "ibtnLogOut";
            ibtnLogOut.Size = new Size(260, 55);
            ibtnLogOut.TabIndex = 13;
            ibtnLogOut.Tag = "Menu Button";
            ibtnLogOut.Text = "Log out           ";
            ibtnLogOut.UseVisualStyleBackColor = false;
            ibtnLogOut.MouseLeave += MenuButtons_MouseLeave;
            ibtnLogOut.MouseHover += MenuButtons_MouseHover;
            // 
            // pnlDashboardMenu
            // 
            pnlDashboardMenu.BackColor = Color.FromArgb(24, 11, 4);
            pnlDashboardMenu.Controls.Add(pnlSettingsSubMenu);
            pnlDashboardMenu.Controls.Add(ibtnSettings);
            pnlDashboardMenu.Controls.Add(pnlSubscriptionsSubMenu);
            pnlDashboardMenu.Controls.Add(ibtnSubscriptions);
            pnlDashboardMenu.Controls.Add(pnlPeopleSubMenu);
            pnlDashboardMenu.Controls.Add(ibtnPeople);
            pnlDashboardMenu.Controls.Add(pnlHomeSubMenu);
            pnlDashboardMenu.Controls.Add(ibtnHome);
            pnlDashboardMenu.Controls.Add(ibtnLogOut);
            pnlDashboardMenu.Controls.Add(pnlToggleMenu);
            pnlDashboardMenu.Controls.Add(ibtnToggleMenu);
            pnlDashboardMenu.Dock = DockStyle.Left;
            pnlDashboardMenu.Location = new Point(4, 4);
            pnlDashboardMenu.Name = "pnlDashboardMenu";
            pnlDashboardMenu.Size = new Size(260, 922);
            pnlDashboardMenu.TabIndex = 7;
            pnlDashboardMenu.Tag = "Menu Panel";
            // 
            // pnlSettingsSubMenu
            // 
            pnlSettingsSubMenu.BackColor = Color.FromArgb(47, 47, 48);
            pnlSettingsSubMenu.Controls.Add(ThemesTSMI);
            pnlSettingsSubMenu.Dock = DockStyle.Top;
            pnlSettingsSubMenu.Location = new Point(0, 723);
            pnlSettingsSubMenu.Name = "pnlSettingsSubMenu";
            pnlSettingsSubMenu.Size = new Size(260, 55);
            pnlSettingsSubMenu.TabIndex = 17;
            pnlSettingsSubMenu.Tag = "Sub Menu Panels";
            pnlSettingsSubMenu.Visible = false;
            // 
            // ThemesTSMI
            // 
            ThemesTSMI.BackColor = Color.FromArgb(47, 47, 48);
            ThemesTSMI.FlatAppearance.BorderSize = 0;
            ThemesTSMI.FlatStyle = FlatStyle.Flat;
            ThemesTSMI.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ThemesTSMI.ForeColor = Color.White;
            ThemesTSMI.IconChar = FontAwesome.Sharp.IconChar.Palette;
            ThemesTSMI.IconColor = Color.White;
            ThemesTSMI.IconFont = FontAwesome.Sharp.IconFont.Auto;
            ThemesTSMI.IconSize = 38;
            ThemesTSMI.ImageAlign = ContentAlignment.MiddleLeft;
            ThemesTSMI.Location = new Point(0, 0);
            ThemesTSMI.Name = "ThemesTSMI";
            ThemesTSMI.Padding = new Padding(25, 0, 0, 0);
            ThemesTSMI.Size = new Size(260, 55);
            ThemesTSMI.TabIndex = 17;
            ThemesTSMI.Tag = "Sub Menu Button";
            ThemesTSMI.Text = "Themes";
            ThemesTSMI.TextImageRelation = TextImageRelation.ImageBeforeText;
            ThemesTSMI.UseVisualStyleBackColor = false;
            ThemesTSMI.Click += SettingsSubMenuButtonsClick;
            ThemesTSMI.MouseLeave += SubMenuButtons_MouseLeave;
            ThemesTSMI.MouseHover += SubMenuButtons_MouseHover;
            // 
            // ibtnSettings
            // 
            ibtnSettings.BackColor = Color.FromArgb(24, 11, 4);
            ibtnSettings.ContextMenuStrip = cmsSettingsSubMenu;
            ibtnSettings.Dock = DockStyle.Top;
            ibtnSettings.FlatAppearance.BorderSize = 0;
            ibtnSettings.FlatStyle = FlatStyle.Flat;
            ibtnSettings.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            ibtnSettings.ForeColor = Color.White;
            ibtnSettings.IconChar = FontAwesome.Sharp.IconChar.Cog;
            ibtnSettings.IconColor = Color.White;
            ibtnSettings.IconFont = FontAwesome.Sharp.IconFont.Auto;
            ibtnSettings.ImageAlign = ContentAlignment.MiddleLeft;
            ibtnSettings.Location = new Point(0, 668);
            ibtnSettings.Name = "ibtnSettings";
            ibtnSettings.Size = new Size(260, 55);
            ibtnSettings.TabIndex = 15;
            ibtnSettings.Tag = "Menu Button";
            ibtnSettings.Text = "Settings";
            ibtnSettings.TextImageRelation = TextImageRelation.ImageBeforeText;
            ibtnSettings.UseVisualStyleBackColor = false;
            ibtnSettings.Click += MenuButtonsClick;
            ibtnSettings.MouseLeave += MenuButtons_MouseLeave;
            ibtnSettings.MouseHover += MenuButtons_MouseHover;
            // 
            // cmsSettingsSubMenu
            // 
            cmsSettingsSubMenu.ImageScalingSize = new Size(20, 20);
            cmsSettingsSubMenu.Items.AddRange(new ToolStripItem[] { themesToolStripMenuItem });
            cmsSettingsSubMenu.Name = "cmsSettingsSubMenu";
            cmsSettingsSubMenu.Size = new Size(155, 42);
            // 
            // themesToolStripMenuItem
            // 
            themesToolStripMenuItem.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            themesToolStripMenuItem.Image = (Image)resources.GetObject("themesToolStripMenuItem.Image");
            themesToolStripMenuItem.ImageScaling = ToolStripItemImageScaling.None;
            themesToolStripMenuItem.Name = "themesToolStripMenuItem";
            themesToolStripMenuItem.Size = new Size(154, 38);
            themesToolStripMenuItem.Text = "Themes";
            themesToolStripMenuItem.Click += themesToolStripMenuItem_Click;
            // 
            // pnlSubscriptionsSubMenu
            // 
            pnlSubscriptionsSubMenu.BackColor = Color.FromArgb(47, 47, 48);
            pnlSubscriptionsSubMenu.Controls.Add(ibtnOffersSubMenu);
            pnlSubscriptionsSubMenu.Controls.Add(ibtnPlansSubMenu);
            pnlSubscriptionsSubMenu.Controls.Add(ibtnAllSubscriptionsSubMenu);
            pnlSubscriptionsSubMenu.Dock = DockStyle.Top;
            pnlSubscriptionsSubMenu.Location = new Point(0, 503);
            pnlSubscriptionsSubMenu.Name = "pnlSubscriptionsSubMenu";
            pnlSubscriptionsSubMenu.Size = new Size(260, 165);
            pnlSubscriptionsSubMenu.TabIndex = 16;
            pnlSubscriptionsSubMenu.Tag = "Sub Menu Panels";
            pnlSubscriptionsSubMenu.Visible = false;
            // 
            // ibtnOffersSubMenu
            // 
            ibtnOffersSubMenu.BackColor = Color.FromArgb(47, 47, 48);
            ibtnOffersSubMenu.Dock = DockStyle.Top;
            ibtnOffersSubMenu.FlatAppearance.BorderSize = 0;
            ibtnOffersSubMenu.FlatStyle = FlatStyle.Flat;
            ibtnOffersSubMenu.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ibtnOffersSubMenu.ForeColor = Color.White;
            ibtnOffersSubMenu.IconChar = FontAwesome.Sharp.IconChar.Tags;
            ibtnOffersSubMenu.IconColor = Color.White;
            ibtnOffersSubMenu.IconFont = FontAwesome.Sharp.IconFont.Auto;
            ibtnOffersSubMenu.IconSize = 38;
            ibtnOffersSubMenu.ImageAlign = ContentAlignment.MiddleLeft;
            ibtnOffersSubMenu.Location = new Point(0, 110);
            ibtnOffersSubMenu.Name = "ibtnOffersSubMenu";
            ibtnOffersSubMenu.Padding = new Padding(25, 0, 0, 0);
            ibtnOffersSubMenu.Size = new Size(260, 55);
            ibtnOffersSubMenu.TabIndex = 16;
            ibtnOffersSubMenu.Tag = "Sub Menu Button";
            ibtnOffersSubMenu.Text = "Offers";
            ibtnOffersSubMenu.TextImageRelation = TextImageRelation.ImageBeforeText;
            ibtnOffersSubMenu.UseVisualStyleBackColor = false;
            ibtnOffersSubMenu.Click += SubscriptionSubMenuButtonClick;
            ibtnOffersSubMenu.MouseLeave += SubMenuButtons_MouseLeave;
            ibtnOffersSubMenu.MouseHover += SubMenuButtons_MouseHover;
            // 
            // ibtnPlansSubMenu
            // 
            ibtnPlansSubMenu.BackColor = Color.FromArgb(47, 47, 48);
            ibtnPlansSubMenu.Dock = DockStyle.Top;
            ibtnPlansSubMenu.FlatAppearance.BorderSize = 0;
            ibtnPlansSubMenu.FlatStyle = FlatStyle.Flat;
            ibtnPlansSubMenu.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ibtnPlansSubMenu.ForeColor = Color.White;
            ibtnPlansSubMenu.IconChar = FontAwesome.Sharp.IconChar.LayerGroup;
            ibtnPlansSubMenu.IconColor = Color.White;
            ibtnPlansSubMenu.IconFont = FontAwesome.Sharp.IconFont.Auto;
            ibtnPlansSubMenu.IconSize = 38;
            ibtnPlansSubMenu.ImageAlign = ContentAlignment.MiddleLeft;
            ibtnPlansSubMenu.Location = new Point(0, 55);
            ibtnPlansSubMenu.Name = "ibtnPlansSubMenu";
            ibtnPlansSubMenu.Padding = new Padding(25, 0, 0, 0);
            ibtnPlansSubMenu.Size = new Size(260, 55);
            ibtnPlansSubMenu.TabIndex = 15;
            ibtnPlansSubMenu.Tag = "Sub Menu Button";
            ibtnPlansSubMenu.Text = "Plans";
            ibtnPlansSubMenu.TextImageRelation = TextImageRelation.ImageBeforeText;
            ibtnPlansSubMenu.UseVisualStyleBackColor = false;
            ibtnPlansSubMenu.Click += SubscriptionSubMenuButtonClick;
            ibtnPlansSubMenu.MouseLeave += SubMenuButtons_MouseLeave;
            ibtnPlansSubMenu.MouseHover += SubMenuButtons_MouseHover;
            // 
            // ibtnAllSubscriptionsSubMenu
            // 
            ibtnAllSubscriptionsSubMenu.BackColor = Color.FromArgb(47, 47, 48);
            ibtnAllSubscriptionsSubMenu.Dock = DockStyle.Top;
            ibtnAllSubscriptionsSubMenu.FlatAppearance.BorderSize = 0;
            ibtnAllSubscriptionsSubMenu.FlatStyle = FlatStyle.Flat;
            ibtnAllSubscriptionsSubMenu.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ibtnAllSubscriptionsSubMenu.ForeColor = Color.White;
            ibtnAllSubscriptionsSubMenu.IconChar = FontAwesome.Sharp.IconChar.TableList;
            ibtnAllSubscriptionsSubMenu.IconColor = Color.White;
            ibtnAllSubscriptionsSubMenu.IconFont = FontAwesome.Sharp.IconFont.Auto;
            ibtnAllSubscriptionsSubMenu.IconSize = 38;
            ibtnAllSubscriptionsSubMenu.ImageAlign = ContentAlignment.MiddleLeft;
            ibtnAllSubscriptionsSubMenu.Location = new Point(0, 0);
            ibtnAllSubscriptionsSubMenu.Name = "ibtnAllSubscriptionsSubMenu";
            ibtnAllSubscriptionsSubMenu.Padding = new Padding(25, 0, 0, 0);
            ibtnAllSubscriptionsSubMenu.Size = new Size(260, 55);
            ibtnAllSubscriptionsSubMenu.TabIndex = 14;
            ibtnAllSubscriptionsSubMenu.Tag = "Sub Menu Button";
            ibtnAllSubscriptionsSubMenu.Text = "All Subscriptions";
            ibtnAllSubscriptionsSubMenu.TextImageRelation = TextImageRelation.ImageBeforeText;
            ibtnAllSubscriptionsSubMenu.UseVisualStyleBackColor = false;
            ibtnAllSubscriptionsSubMenu.Click += SubscriptionSubMenuButtonClick;
            ibtnAllSubscriptionsSubMenu.MouseLeave += SubMenuButtons_MouseLeave;
            ibtnAllSubscriptionsSubMenu.MouseHover += SubMenuButtons_MouseHover;
            // 
            // ibtnSubscriptions
            // 
            ibtnSubscriptions.BackColor = Color.FromArgb(24, 11, 4);
            ibtnSubscriptions.ContextMenuStrip = cmsSubscriptionSubMenu;
            ibtnSubscriptions.Dock = DockStyle.Top;
            ibtnSubscriptions.FlatAppearance.BorderSize = 0;
            ibtnSubscriptions.FlatStyle = FlatStyle.Flat;
            ibtnSubscriptions.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            ibtnSubscriptions.ForeColor = Color.White;
            ibtnSubscriptions.IconChar = FontAwesome.Sharp.IconChar.ClipboardList;
            ibtnSubscriptions.IconColor = Color.White;
            ibtnSubscriptions.IconFont = FontAwesome.Sharp.IconFont.Auto;
            ibtnSubscriptions.ImageAlign = ContentAlignment.MiddleLeft;
            ibtnSubscriptions.Location = new Point(0, 448);
            ibtnSubscriptions.Name = "ibtnSubscriptions";
            ibtnSubscriptions.Size = new Size(260, 55);
            ibtnSubscriptions.TabIndex = 11;
            ibtnSubscriptions.Tag = "Menu Button";
            ibtnSubscriptions.Text = "Subscriptions";
            ibtnSubscriptions.TextImageRelation = TextImageRelation.ImageBeforeText;
            ibtnSubscriptions.UseVisualStyleBackColor = false;
            ibtnSubscriptions.Click += MenuButtonsClick;
            ibtnSubscriptions.MouseLeave += MenuButtons_MouseLeave;
            ibtnSubscriptions.MouseHover += MenuButtons_MouseHover;
            // 
            // cmsSubscriptionSubMenu
            // 
            cmsSubscriptionSubMenu.ImageScalingSize = new Size(20, 20);
            cmsSubscriptionSubMenu.Items.AddRange(new ToolStripItem[] { AllSubscriptionTSMI, PlansTSMI, OffersTSMI });
            cmsSubscriptionSubMenu.Name = "cmsPeopleSubMenu";
            cmsSubscriptionSubMenu.Size = new Size(221, 118);
            // 
            // AllSubscriptionTSMI
            // 
            AllSubscriptionTSMI.Font = new Font("Segoe UI", 10.2F);
            AllSubscriptionTSMI.Image = (Image)resources.GetObject("AllSubscriptionTSMI.Image");
            AllSubscriptionTSMI.ImageScaling = ToolStripItemImageScaling.None;
            AllSubscriptionTSMI.Name = "AllSubscriptionTSMI";
            AllSubscriptionTSMI.Size = new Size(220, 38);
            AllSubscriptionTSMI.Text = "All Subscriptions";
            AllSubscriptionTSMI.Click += AllSubscriptionTSMI_Click;
            // 
            // PlansTSMI
            // 
            PlansTSMI.Font = new Font("Segoe UI", 10.2F);
            PlansTSMI.Image = (Image)resources.GetObject("PlansTSMI.Image");
            PlansTSMI.ImageScaling = ToolStripItemImageScaling.None;
            PlansTSMI.Name = "PlansTSMI";
            PlansTSMI.Size = new Size(220, 38);
            PlansTSMI.Text = "Plans";
            PlansTSMI.Click += PlansTSMI_Click;
            // 
            // OffersTSMI
            // 
            OffersTSMI.Font = new Font("Segoe UI", 10.2F);
            OffersTSMI.Image = (Image)resources.GetObject("OffersTSMI.Image");
            OffersTSMI.ImageScaling = ToolStripItemImageScaling.None;
            OffersTSMI.Name = "OffersTSMI";
            OffersTSMI.Size = new Size(220, 38);
            OffersTSMI.Text = "Offers";
            OffersTSMI.Click += OffersTSMI_Click;
            // 
            // pnlPeopleSubMenu
            // 
            pnlPeopleSubMenu.BackColor = Color.FromArgb(47, 47, 48);
            pnlPeopleSubMenu.Controls.Add(ibtnTrainersSubMenu);
            pnlPeopleSubMenu.Controls.Add(ibtnMembersSubMenu);
            pnlPeopleSubMenu.Controls.Add(ibtnUsersSubMenu);
            pnlPeopleSubMenu.Controls.Add(ibtnAllPeopleSubMenu);
            pnlPeopleSubMenu.Dock = DockStyle.Top;
            pnlPeopleSubMenu.Location = new Point(0, 228);
            pnlPeopleSubMenu.Name = "pnlPeopleSubMenu";
            pnlPeopleSubMenu.Size = new Size(260, 220);
            pnlPeopleSubMenu.TabIndex = 15;
            pnlPeopleSubMenu.Tag = "Sub Menu Panels";
            pnlPeopleSubMenu.Visible = false;
            // 
            // ibtnTrainersSubMenu
            // 
            ibtnTrainersSubMenu.BackColor = Color.FromArgb(47, 47, 48);
            ibtnTrainersSubMenu.Dock = DockStyle.Top;
            ibtnTrainersSubMenu.FlatAppearance.BorderSize = 0;
            ibtnTrainersSubMenu.FlatStyle = FlatStyle.Flat;
            ibtnTrainersSubMenu.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ibtnTrainersSubMenu.ForeColor = Color.White;
            ibtnTrainersSubMenu.IconChar = FontAwesome.Sharp.IconChar.UserFriends;
            ibtnTrainersSubMenu.IconColor = Color.White;
            ibtnTrainersSubMenu.IconFont = FontAwesome.Sharp.IconFont.Auto;
            ibtnTrainersSubMenu.IconSize = 38;
            ibtnTrainersSubMenu.ImageAlign = ContentAlignment.MiddleLeft;
            ibtnTrainersSubMenu.Location = new Point(0, 165);
            ibtnTrainersSubMenu.Name = "ibtnTrainersSubMenu";
            ibtnTrainersSubMenu.Padding = new Padding(25, 0, 0, 0);
            ibtnTrainersSubMenu.Size = new Size(260, 55);
            ibtnTrainersSubMenu.TabIndex = 13;
            ibtnTrainersSubMenu.Tag = "Sub Menu Button";
            ibtnTrainersSubMenu.Text = "Trainers";
            ibtnTrainersSubMenu.TextImageRelation = TextImageRelation.ImageBeforeText;
            ibtnTrainersSubMenu.UseVisualStyleBackColor = false;
            ibtnTrainersSubMenu.Click += PeopleSubMenuButtonClick;
            ibtnTrainersSubMenu.MouseLeave += SubMenuButtons_MouseLeave;
            ibtnTrainersSubMenu.MouseHover += SubMenuButtons_MouseHover;
            // 
            // ibtnMembersSubMenu
            // 
            ibtnMembersSubMenu.BackColor = Color.FromArgb(47, 47, 48);
            ibtnMembersSubMenu.Dock = DockStyle.Top;
            ibtnMembersSubMenu.FlatAppearance.BorderSize = 0;
            ibtnMembersSubMenu.FlatStyle = FlatStyle.Flat;
            ibtnMembersSubMenu.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ibtnMembersSubMenu.ForeColor = Color.White;
            ibtnMembersSubMenu.IconChar = FontAwesome.Sharp.IconChar.UsersViewfinder;
            ibtnMembersSubMenu.IconColor = Color.White;
            ibtnMembersSubMenu.IconFont = FontAwesome.Sharp.IconFont.Auto;
            ibtnMembersSubMenu.IconSize = 38;
            ibtnMembersSubMenu.ImageAlign = ContentAlignment.MiddleLeft;
            ibtnMembersSubMenu.Location = new Point(0, 110);
            ibtnMembersSubMenu.Name = "ibtnMembersSubMenu";
            ibtnMembersSubMenu.Padding = new Padding(25, 0, 0, 0);
            ibtnMembersSubMenu.Size = new Size(260, 55);
            ibtnMembersSubMenu.TabIndex = 12;
            ibtnMembersSubMenu.Tag = "Sub Menu Button";
            ibtnMembersSubMenu.Text = "Members";
            ibtnMembersSubMenu.TextImageRelation = TextImageRelation.ImageBeforeText;
            ibtnMembersSubMenu.UseVisualStyleBackColor = false;
            ibtnMembersSubMenu.Click += PeopleSubMenuButtonClick;
            ibtnMembersSubMenu.MouseLeave += SubMenuButtons_MouseLeave;
            ibtnMembersSubMenu.MouseHover += SubMenuButtons_MouseHover;
            // 
            // ibtnUsersSubMenu
            // 
            ibtnUsersSubMenu.BackColor = Color.FromArgb(47, 47, 48);
            ibtnUsersSubMenu.Dock = DockStyle.Top;
            ibtnUsersSubMenu.FlatAppearance.BorderSize = 0;
            ibtnUsersSubMenu.FlatStyle = FlatStyle.Flat;
            ibtnUsersSubMenu.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ibtnUsersSubMenu.ForeColor = Color.White;
            ibtnUsersSubMenu.IconChar = FontAwesome.Sharp.IconChar.Users;
            ibtnUsersSubMenu.IconColor = Color.White;
            ibtnUsersSubMenu.IconFont = FontAwesome.Sharp.IconFont.Auto;
            ibtnUsersSubMenu.IconSize = 38;
            ibtnUsersSubMenu.ImageAlign = ContentAlignment.MiddleLeft;
            ibtnUsersSubMenu.Location = new Point(0, 55);
            ibtnUsersSubMenu.Name = "ibtnUsersSubMenu";
            ibtnUsersSubMenu.Padding = new Padding(25, 0, 0, 0);
            ibtnUsersSubMenu.Size = new Size(260, 55);
            ibtnUsersSubMenu.TabIndex = 11;
            ibtnUsersSubMenu.Tag = "Sub Menu Button";
            ibtnUsersSubMenu.Text = "Users";
            ibtnUsersSubMenu.TextImageRelation = TextImageRelation.ImageBeforeText;
            ibtnUsersSubMenu.UseVisualStyleBackColor = false;
            ibtnUsersSubMenu.Click += PeopleSubMenuButtonClick;
            ibtnUsersSubMenu.MouseLeave += SubMenuButtons_MouseLeave;
            ibtnUsersSubMenu.MouseHover += SubMenuButtons_MouseHover;
            // 
            // ibtnAllPeopleSubMenu
            // 
            ibtnAllPeopleSubMenu.BackColor = Color.FromArgb(47, 47, 48);
            ibtnAllPeopleSubMenu.Dock = DockStyle.Top;
            ibtnAllPeopleSubMenu.FlatAppearance.BorderSize = 0;
            ibtnAllPeopleSubMenu.FlatStyle = FlatStyle.Flat;
            ibtnAllPeopleSubMenu.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ibtnAllPeopleSubMenu.ForeColor = Color.White;
            ibtnAllPeopleSubMenu.IconChar = FontAwesome.Sharp.IconChar.PeopleGroup;
            ibtnAllPeopleSubMenu.IconColor = Color.White;
            ibtnAllPeopleSubMenu.IconFont = FontAwesome.Sharp.IconFont.Auto;
            ibtnAllPeopleSubMenu.IconSize = 38;
            ibtnAllPeopleSubMenu.ImageAlign = ContentAlignment.MiddleLeft;
            ibtnAllPeopleSubMenu.Location = new Point(0, 0);
            ibtnAllPeopleSubMenu.Name = "ibtnAllPeopleSubMenu";
            ibtnAllPeopleSubMenu.Padding = new Padding(25, 0, 0, 0);
            ibtnAllPeopleSubMenu.Size = new Size(260, 55);
            ibtnAllPeopleSubMenu.TabIndex = 14;
            ibtnAllPeopleSubMenu.Tag = "Sub Menu Button";
            ibtnAllPeopleSubMenu.Text = "All";
            ibtnAllPeopleSubMenu.TextImageRelation = TextImageRelation.ImageBeforeText;
            ibtnAllPeopleSubMenu.UseVisualStyleBackColor = false;
            ibtnAllPeopleSubMenu.Click += PeopleSubMenuButtonClick;
            ibtnAllPeopleSubMenu.MouseLeave += SubMenuButtons_MouseLeave;
            ibtnAllPeopleSubMenu.MouseHover += SubMenuButtons_MouseHover;
            // 
            // ibtnPeople
            // 
            ibtnPeople.BackColor = Color.FromArgb(24, 11, 4);
            ibtnPeople.ContextMenuStrip = cmsPeopleSubMenu;
            ibtnPeople.Dock = DockStyle.Top;
            ibtnPeople.FlatAppearance.BorderSize = 0;
            ibtnPeople.FlatStyle = FlatStyle.Flat;
            ibtnPeople.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            ibtnPeople.ForeColor = Color.White;
            ibtnPeople.IconChar = FontAwesome.Sharp.IconChar.PeopleGroup;
            ibtnPeople.IconColor = Color.White;
            ibtnPeople.IconFont = FontAwesome.Sharp.IconFont.Auto;
            ibtnPeople.ImageAlign = ContentAlignment.MiddleLeft;
            ibtnPeople.Location = new Point(0, 173);
            ibtnPeople.Name = "ibtnPeople";
            ibtnPeople.Size = new Size(260, 55);
            ibtnPeople.TabIndex = 10;
            ibtnPeople.Tag = "Menu Button";
            ibtnPeople.Text = "People";
            ibtnPeople.TextImageRelation = TextImageRelation.ImageBeforeText;
            ibtnPeople.UseVisualStyleBackColor = false;
            ibtnPeople.Click += MenuButtonsClick;
            ibtnPeople.MouseLeave += MenuButtons_MouseLeave;
            ibtnPeople.MouseHover += MenuButtons_MouseHover;
            // 
            // cmsPeopleSubMenu
            // 
            cmsPeopleSubMenu.ImageScalingSize = new Size(20, 20);
            cmsPeopleSubMenu.Items.AddRange(new ToolStripItem[] { AllPeopleTSMI, UsersTSMI, MembersTSMI, TrainersTSMI });
            cmsPeopleSubMenu.Name = "cmsPeopleSubMenu";
            cmsPeopleSubMenu.Size = new Size(167, 156);
            // 
            // AllPeopleTSMI
            // 
            AllPeopleTSMI.Font = new Font("Segoe UI", 10.2F);
            AllPeopleTSMI.Image = (Image)resources.GetObject("AllPeopleTSMI.Image");
            AllPeopleTSMI.ImageScaling = ToolStripItemImageScaling.None;
            AllPeopleTSMI.Name = "AllPeopleTSMI";
            AllPeopleTSMI.Size = new Size(166, 38);
            AllPeopleTSMI.Text = "All";
            AllPeopleTSMI.Click += AllPeopleTSMI_Click;
            // 
            // UsersTSMI
            // 
            UsersTSMI.Font = new Font("Segoe UI", 10.2F);
            UsersTSMI.Image = (Image)resources.GetObject("UsersTSMI.Image");
            UsersTSMI.ImageScaling = ToolStripItemImageScaling.None;
            UsersTSMI.Name = "UsersTSMI";
            UsersTSMI.Size = new Size(166, 38);
            UsersTSMI.Text = "Users";
            UsersTSMI.Click += UsersTSMI_Click;
            // 
            // MembersTSMI
            // 
            MembersTSMI.Font = new Font("Segoe UI", 10.2F);
            MembersTSMI.Image = (Image)resources.GetObject("MembersTSMI.Image");
            MembersTSMI.ImageScaling = ToolStripItemImageScaling.None;
            MembersTSMI.Name = "MembersTSMI";
            MembersTSMI.Size = new Size(166, 38);
            MembersTSMI.Text = "Members";
            MembersTSMI.Click += MembersTSMI_Click;
            // 
            // TrainersTSMI
            // 
            TrainersTSMI.Font = new Font("Segoe UI", 10.2F);
            TrainersTSMI.Image = (Image)resources.GetObject("TrainersTSMI.Image");
            TrainersTSMI.ImageScaling = ToolStripItemImageScaling.None;
            TrainersTSMI.Name = "TrainersTSMI";
            TrainersTSMI.Size = new Size(166, 38);
            TrainersTSMI.Text = "Trainers";
            TrainersTSMI.Click += TrainersTSMI_Click;
            // 
            // pnlHomeSubMenu
            // 
            pnlHomeSubMenu.BackColor = Color.FromArgb(47, 47, 48);
            pnlHomeSubMenu.Dock = DockStyle.Top;
            pnlHomeSubMenu.Location = new Point(0, 173);
            pnlHomeSubMenu.Name = "pnlHomeSubMenu";
            pnlHomeSubMenu.Size = new Size(260, 0);
            pnlHomeSubMenu.TabIndex = 14;
            pnlHomeSubMenu.Tag = "Sub Menu Panels";
            pnlHomeSubMenu.Visible = false;
            // 
            // ibtnHome
            // 
            ibtnHome.BackColor = Color.FromArgb(24, 11, 4);
            ibtnHome.Dock = DockStyle.Top;
            ibtnHome.FlatAppearance.BorderSize = 0;
            ibtnHome.FlatStyle = FlatStyle.Flat;
            ibtnHome.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            ibtnHome.ForeColor = Color.White;
            ibtnHome.IconChar = FontAwesome.Sharp.IconChar.HomeLg;
            ibtnHome.IconColor = Color.White;
            ibtnHome.IconFont = FontAwesome.Sharp.IconFont.Auto;
            ibtnHome.ImageAlign = ContentAlignment.MiddleLeft;
            ibtnHome.Location = new Point(0, 118);
            ibtnHome.Name = "ibtnHome";
            ibtnHome.Size = new Size(260, 55);
            ibtnHome.TabIndex = 9;
            ibtnHome.Tag = "Menu Button";
            ibtnHome.Text = "Home";
            ibtnHome.TextImageRelation = TextImageRelation.ImageBeforeText;
            ibtnHome.UseVisualStyleBackColor = false;
            ibtnHome.Click += MenuButtonsClick;
            ibtnHome.MouseLeave += MenuButtons_MouseLeave;
            ibtnHome.MouseHover += MenuButtons_MouseHover;
            // 
            // pnlToggleMenu
            // 
            pnlToggleMenu.Dock = DockStyle.Top;
            pnlToggleMenu.Location = new Point(0, 64);
            pnlToggleMenu.Name = "pnlToggleMenu";
            pnlToggleMenu.Size = new Size(260, 54);
            pnlToggleMenu.TabIndex = 10;
            pnlToggleMenu.Tag = "Menu Panel";
            // 
            // ibtnToggleMenu
            // 
            ibtnToggleMenu.BackColor = Color.FromArgb(24, 11, 4);
            ibtnToggleMenu.Dock = DockStyle.Top;
            ibtnToggleMenu.FlatAppearance.BorderSize = 0;
            ibtnToggleMenu.FlatStyle = FlatStyle.Flat;
            ibtnToggleMenu.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            ibtnToggleMenu.ForeColor = Color.White;
            ibtnToggleMenu.IconChar = FontAwesome.Sharp.IconChar.Bars;
            ibtnToggleMenu.IconColor = Color.FromArgb(246, 128, 5);
            ibtnToggleMenu.IconFont = FontAwesome.Sharp.IconFont.Auto;
            ibtnToggleMenu.Location = new Point(0, 0);
            ibtnToggleMenu.Name = "ibtnToggleMenu";
            ibtnToggleMenu.Size = new Size(260, 64);
            ibtnToggleMenu.TabIndex = 18;
            ibtnToggleMenu.Tag = "Toggle Menu";
            ibtnToggleMenu.Text = "           ";
            ibtnToggleMenu.UseVisualStyleBackColor = false;
            ibtnToggleMenu.Click += ibtnToggleMenu_Click;
            // 
            // pnlFormContainer
            // 
            pnlFormContainer.BackColor = SystemColors.ControlDark;
            pnlFormContainer.Controls.Add(tableLayoutPanel1);
            pnlFormContainer.Dock = DockStyle.Fill;
            pnlFormContainer.Location = new Point(264, 68);
            pnlFormContainer.Name = "pnlFormContainer";
            pnlFormContainer.Size = new Size(1482, 858);
            pnlFormContainer.TabIndex = 8;
            pnlFormContainer.Tag = "Form Container";
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.BackColor = Color.Transparent;
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(lblTime, 0, 3);
            tableLayoutPanel1.Controls.Add(lblDate, 0, 2);
            tableLayoutPanel1.Controls.Add(pbGymLogo, 0, 1);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 5;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 5F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 74F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 8F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 8F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 5F));
            tableLayoutPanel1.Size = new Size(1482, 858);
            tableLayoutPanel1.TabIndex = 9;
            tableLayoutPanel1.Tag = "Form Container";
            // 
            // lblTime
            // 
            lblTime.Anchor = AnchorStyles.None;
            lblTime.AutoSize = true;
            lblTime.Font = new Font("Segoe UI", 30F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTime.Location = new Point(615, 744);
            lblTime.Name = "lblTime";
            lblTime.Size = new Size(251, 67);
            lblTime.TabIndex = 24;
            lblTime.Tag = "Title";
            lblTime.Text = "HH:mm:ss";
            lblTime.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblDate
            // 
            lblDate.Anchor = AnchorStyles.None;
            lblDate.AutoSize = true;
            lblDate.Font = new Font("Segoe UI", 30F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblDate.Location = new Point(534, 676);
            lblDate.Name = "lblDate";
            lblDate.Size = new Size(414, 67);
            lblDate.TabIndex = 23;
            lblDate.Tag = "Title";
            lblDate.Text = "dd - MMM - yyyy";
            lblDate.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pbGymLogo
            // 
            pbGymLogo.Anchor = AnchorStyles.None;
            pbGymLogo.BackColor = Color.Transparent;
            pbGymLogo.Image = (Image)resources.GetObject("pbGymLogo.Image");
            pbGymLogo.Location = new Point(3, 45);
            pbGymLogo.Margin = new Padding(0);
            pbGymLogo.Name = "pbGymLogo";
            pbGymLogo.Size = new Size(1476, 628);
            pbGymLogo.SizeMode = PictureBoxSizeMode.Zoom;
            pbGymLogo.TabIndex = 22;
            pbGymLogo.TabStop = false;
            pbGymLogo.Tag = "Logo";
            // 
            // hideContextMenuStripTimer
            // 
            hideContextMenuStripTimer.Interval = 200;
            hideContextMenuStripTimer.Tick += hideContextMenuStripTimer_Tick;
            // 
            // updateDateTimeTimer
            // 
            updateDateTimeTimer.Interval = 1000;
            updateDateTimeTimer.Tick += updateDateTimeTimer_Tick;
            // 
            // DashboardForm
            // 
            AutoScaleDimensions = new SizeF(9F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1750, 930);
            Controls.Add(pnlFormContainer);
            Controls.Add(pnlHeader);
            Controls.Add(pnlDashboardMenu);
            Name = "DashboardForm";
            Text = "DashboardForm";
            WindowState = FormWindowState.Maximized;
            Load += DashboardForm_Load;
            Resize += DashboardForm_Resize;
            Controls.SetChildIndex(pnlDashboardMenu, 0);
            Controls.SetChildIndex(pnlHeader, 0);
            Controls.SetChildIndex(pnlFormContainer, 0);
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            pnlDashboardMenu.ResumeLayout(false);
            pnlSettingsSubMenu.ResumeLayout(false);
            cmsSettingsSubMenu.ResumeLayout(false);
            pnlSubscriptionsSubMenu.ResumeLayout(false);
            cmsSubscriptionSubMenu.ResumeLayout(false);
            pnlPeopleSubMenu.ResumeLayout(false);
            cmsPeopleSubMenu.ResumeLayout(false);
            pnlFormContainer.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pbGymLogo).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlHeader;
        private FontAwesome.Sharp.IconButton ibtnLogOut;
        private Panel pnlDashboardMenu;
        private Panel pnlHomeSubMenu;
        private FontAwesome.Sharp.IconButton ibtnHome;
        private Panel pnlSettingsSubMenu;
        private FontAwesome.Sharp.IconButton ibtnSettings;
        private Panel pnlSubscriptionsSubMenu;
        private FontAwesome.Sharp.IconButton ibtnSubscriptions;
        private Panel pnlPeopleSubMenu;
        private FontAwesome.Sharp.IconButton ibtnUsersSubMenu;
        private FontAwesome.Sharp.IconButton ibtnPeople;
        private FontAwesome.Sharp.IconButton ibtnOffersSubMenu;
        private FontAwesome.Sharp.IconButton ibtnPlansSubMenu;
        private FontAwesome.Sharp.IconButton ibtnAllSubscriptionsSubMenu;
        private FontAwesome.Sharp.IconButton ibtnTrainersSubMenu;
        private FontAwesome.Sharp.IconButton ibtnMembersSubMenu;
        private FontAwesome.Sharp.IconButton ThemesTSMI;
        private FontAwesome.Sharp.IconButton ibtnAllPeopleSubMenu;
        private FontAwesome.Sharp.IconButton ibtnToggleMenu;
        private Panel pnlFormContainer;
        private Panel pnlToggleMenu;
        private FontAwesome.Sharp.IconButton ibtnWindowNormalOrMaximize;
        private FontAwesome.Sharp.IconButton ibtnClose;
        private FontAwesome.Sharp.IconButton ibtnWindowMinimize;
        private ContextMenuStrip cmsPeopleSubMenu;
        private ToolStripMenuItem AllPeopleTSMI;
        private ToolStripMenuItem UsersTSMI;
        private ToolStripMenuItem MembersTSMI;
        private ToolStripMenuItem TrainersTSMI;
        private ContextMenuStrip cmsSettingsSubMenu;
        private ToolStripMenuItem themesToolStripMenuItem;
        private ContextMenuStrip cmsSubscriptionSubMenu;
        private ToolStripMenuItem AllSubscriptionTSMI;
        private ToolStripMenuItem PlansTSMI;
        private ToolStripMenuItem OffersTSMI;
        private System.Windows.Forms.Timer hideContextMenuStripTimer;
        private System.Windows.Forms.Timer updateDateTimeTimer;
        private Label lblTime;
        private Label lblDate;
        private PictureBox pbGymLogo;
        private TableLayoutPanel tableLayoutPanel1;
        private CustomControls.ToggleButton toggelButtonDarkMode;
        private Label label1;
    }
}