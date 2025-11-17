namespace WinFormsClient.Forms.Person
{
    partial class AddAndUpdatePersonForm
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
            lblTitle = new Label();
            ibtnClose = new FontAwesome.Sharp.IconButton();
            panel1 = new Panel();
            ibtnRemoveImage = new FontAwesome.Sharp.IconButton();
            ibtnRemovePhone = new FontAwesome.Sharp.IconButton();
            lblPhoneList = new Label();
            lstPhoneNumbers = new ListBox();
            label2 = new Label();
            ibtnAddPhone = new FontAwesome.Sharp.IconButton();
            gtbPhoneNumber = new WinFormsClient.CustomControls.GeneralTextBox();
            ibtnUploadImage = new FontAwesome.Sharp.IconButton();
            gtbEmail = new WinFormsClient.CustomControls.GeneralTextBox();
            hrbFemale = new ReaLTaiizor.Controls.HopeRadioButton();
            hrbMale = new ReaLTaiizor.Controls.HopeRadioButton();
            gtbDateOfBirth = new WinFormsClient.CustomControls.GeneralTextBox();
            gtbLastName = new WinFormsClient.CustomControls.GeneralTextBox();
            gtbMiddleName = new WinFormsClient.CustomControls.GeneralTextBox();
            lblPersonId = new Label();
            gtbFirstName = new WinFormsClient.CustomControls.GeneralTextBox();
            label5 = new Label();
            pbPersonImage = new PictureBox();
            label7 = new Label();
            label8 = new Label();
            label4 = new Label();
            label1 = new Label();
            ibtnSave = new FontAwesome.Sharp.IconButton();
            ibtnClose2 = new FontAwesome.Sharp.IconButton();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbPersonImage).BeginInit();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.Anchor = AnchorStyles.Left;
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 30F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.Location = new Point(47, 44);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(421, 67);
            lblTitle.TabIndex = 24;
            lblTitle.Tag = "Title";
            lblTitle.Text = "Add New Person";
            // 
            // ibtnClose
            // 
            ibtnClose.IconChar = FontAwesome.Sharp.IconChar.Close;
            ibtnClose.IconColor = Color.Black;
            ibtnClose.IconFont = FontAwesome.Sharp.IconFont.Auto;
            ibtnClose.IconSize = 38;
            ibtnClose.Location = new Point(3, 3);
            ibtnClose.Name = "ibtnClose";
            ibtnClose.Size = new Size(38, 37);
            ibtnClose.TabIndex = 25;
            ibtnClose.TabStop = false;
            ibtnClose.UseVisualStyleBackColor = true;
            ibtnClose.Click += ibtnClose_Click;
            // 
            // panel1
            // 
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(ibtnRemoveImage);
            panel1.Controls.Add(ibtnRemovePhone);
            panel1.Controls.Add(lblPhoneList);
            panel1.Controls.Add(lstPhoneNumbers);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(ibtnAddPhone);
            panel1.Controls.Add(gtbPhoneNumber);
            panel1.Controls.Add(ibtnUploadImage);
            panel1.Controls.Add(gtbEmail);
            panel1.Controls.Add(hrbFemale);
            panel1.Controls.Add(hrbMale);
            panel1.Controls.Add(gtbDateOfBirth);
            panel1.Controls.Add(gtbLastName);
            panel1.Controls.Add(gtbMiddleName);
            panel1.Controls.Add(lblPersonId);
            panel1.Controls.Add(gtbFirstName);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(pbPersonImage);
            panel1.Controls.Add(label7);
            panel1.Controls.Add(label8);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(label1);
            panel1.Font = new Font("Segoe UI", 10.2F);
            panel1.Location = new Point(52, 130);
            panel1.Name = "panel1";
            panel1.Size = new Size(1056, 257);
            panel1.TabIndex = 26;
            panel1.Tag = "Container";
            // 
            // ibtnRemoveImage
            // 
            ibtnRemoveImage.IconChar = FontAwesome.Sharp.IconChar.TrashAlt;
            ibtnRemoveImage.IconColor = Color.Red;
            ibtnRemoveImage.IconFont = FontAwesome.Sharp.IconFont.Auto;
            ibtnRemoveImage.IconSize = 32;
            ibtnRemoveImage.Location = new Point(849, 202);
            ibtnRemoveImage.Name = "ibtnRemoveImage";
            ibtnRemoveImage.Size = new Size(178, 36);
            ibtnRemoveImage.TabIndex = 52;
            ibtnRemoveImage.Text = "Remove Image";
            ibtnRemoveImage.TextImageRelation = TextImageRelation.ImageBeforeText;
            ibtnRemoveImage.UseVisualStyleBackColor = true;
            ibtnRemoveImage.Visible = false;
            ibtnRemoveImage.Click += ibtnRemoveImage_Click;
            // 
            // ibtnRemovePhone
            // 
            ibtnRemovePhone.Enabled = false;
            ibtnRemovePhone.IconChar = FontAwesome.Sharp.IconChar.Trash;
            ibtnRemovePhone.IconColor = Color.Red;
            ibtnRemovePhone.IconFont = FontAwesome.Sharp.IconFont.Auto;
            ibtnRemovePhone.IconSize = 32;
            ibtnRemovePhone.Location = new Point(797, 165);
            ibtnRemovePhone.Name = "ibtnRemovePhone";
            ibtnRemovePhone.Size = new Size(38, 36);
            ibtnRemovePhone.TabIndex = 51;
            ibtnRemovePhone.TextImageRelation = TextImageRelation.TextBeforeImage;
            ibtnRemovePhone.UseVisualStyleBackColor = true;
            ibtnRemovePhone.Visible = false;
            ibtnRemovePhone.Click += ibtnRemovePhone_Click;
            // 
            // lblPhoneList
            // 
            lblPhoneList.AutoSize = true;
            lblPhoneList.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            lblPhoneList.Location = new Point(467, 165);
            lblPhoneList.Name = "lblPhoneList";
            lblPhoneList.Size = new Size(97, 23);
            lblPhoneList.TabIndex = 50;
            lblPhoneList.Text = "Phone List:";
            lblPhoneList.Visible = false;
            // 
            // lstPhoneNumbers
            // 
            lstPhoneNumbers.FormattingEnabled = true;
            lstPhoneNumbers.ItemHeight = 23;
            lstPhoneNumbers.Location = new Point(570, 165);
            lstPhoneNumbers.Name = "lstPhoneNumbers";
            lstPhoneNumbers.Size = new Size(219, 73);
            lstPhoneNumbers.TabIndex = 49;
            lstPhoneNumbers.Visible = false;
            lstPhoneNumbers.SelectedIndexChanged += lstPhoneNumberList_SelectedIndexChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            label2.Location = new Point(505, 123);
            label2.Name = "label2";
            label2.Size = new Size(64, 23);
            label2.TabIndex = 47;
            label2.Text = "Phone:";
            // 
            // ibtnAddPhone
            // 
            ibtnAddPhone.Enabled = false;
            ibtnAddPhone.IconChar = FontAwesome.Sharp.IconChar.Add;
            ibtnAddPhone.IconColor = Color.FromArgb(64, 158, 255);
            ibtnAddPhone.IconFont = FontAwesome.Sharp.IconFont.Auto;
            ibtnAddPhone.IconSize = 32;
            ibtnAddPhone.Location = new Point(797, 116);
            ibtnAddPhone.Name = "ibtnAddPhone";
            ibtnAddPhone.Size = new Size(38, 36);
            ibtnAddPhone.TabIndex = 5;
            ibtnAddPhone.TextImageRelation = TextImageRelation.TextBeforeImage;
            ibtnAddPhone.UseVisualStyleBackColor = true;
            ibtnAddPhone.Click += ibtnAddPhone_Click;
            // 
            // gtbPhoneNumber
            // 
            gtbPhoneNumber.BackColor = Color.White;
            gtbPhoneNumber.BaseColor = Color.FromArgb(44, 55, 66);
            gtbPhoneNumber.BorderColor = Color.Gray;
            gtbPhoneNumber.BorderColorA = Color.FromArgb(64, 158, 255);
            gtbPhoneNumber.BorderColorB = Color.FromArgb(220, 223, 230);
            gtbPhoneNumber.BorderRadius = 13;
            gtbPhoneNumber.BorderThickness = 2;
            gtbPhoneNumber.FieldName = "Phone Number";
            gtbPhoneNumber.Font = new Font("Segoe UI", 10.2F);
            gtbPhoneNumber.ForeColor = Color.FromArgb(48, 49, 51);
            gtbPhoneNumber.Hint = "0555 55 55 55";
            gtbPhoneNumber.InputType = CustomControls.GeneralTextBox.TextboxInputType.Phone;
            gtbPhoneNumber.Location = new Point(570, 115);
            gtbPhoneNumber.MaxLength = 32767;
            gtbPhoneNumber.Multiline = false;
            gtbPhoneNumber.Name = "gtbPhoneNumber";
            gtbPhoneNumber.Padding = new Padding(10, 5, 10, 5);
            gtbPhoneNumber.PasswordChar = '\0';
            gtbPhoneNumber.RequirementMode = CustomControls.GeneralTextBox.RequiredMode.Optional;
            gtbPhoneNumber.ScrollBars = ScrollBars.None;
            gtbPhoneNumber.SelectedText = "";
            gtbPhoneNumber.SelectionLength = 0;
            gtbPhoneNumber.SelectionStart = 0;
            gtbPhoneNumber.Size = new Size(219, 39);
            gtbPhoneNumber.TabIndex = 4;
            gtbPhoneNumber.TabStop = false;
            gtbPhoneNumber.UseSystemPasswordChar = false;
            gtbPhoneNumber.Leave += gtbPhoneNumber_Leave;
            gtbPhoneNumber.TextChanged += gtbPhoneNumber_TextChanged;
            // 
            // ibtnUploadImage
            // 
            ibtnUploadImage.IconChar = FontAwesome.Sharp.IconChar.Upload;
            ibtnUploadImage.IconColor = Color.FromArgb(64, 158, 255);
            ibtnUploadImage.IconFont = FontAwesome.Sharp.IconFont.Auto;
            ibtnUploadImage.IconSize = 32;
            ibtnUploadImage.Location = new Point(849, 202);
            ibtnUploadImage.Name = "ibtnUploadImage";
            ibtnUploadImage.Size = new Size(178, 36);
            ibtnUploadImage.TabIndex = 9;
            ibtnUploadImage.Text = "Uplaod Image";
            ibtnUploadImage.TextImageRelation = TextImageRelation.ImageBeforeText;
            ibtnUploadImage.UseVisualStyleBackColor = true;
            ibtnUploadImage.Click += ibtnUploadImage_Click;
            // 
            // gtbEmail
            // 
            gtbEmail.BackColor = Color.White;
            gtbEmail.BaseColor = Color.FromArgb(44, 55, 66);
            gtbEmail.BorderColor = Color.Gray;
            gtbEmail.BorderColorA = Color.FromArgb(64, 158, 255);
            gtbEmail.BorderColorB = Color.FromArgb(220, 223, 230);
            gtbEmail.BorderRadius = 13;
            gtbEmail.BorderThickness = 2;
            gtbEmail.FieldName = "Email";
            gtbEmail.Font = new Font("Segoe UI", 10.2F);
            gtbEmail.ForeColor = Color.FromArgb(48, 49, 51);
            gtbEmail.Hint = "example@email.com";
            gtbEmail.InputType = CustomControls.GeneralTextBox.TextboxInputType.Email;
            gtbEmail.Location = new Point(125, 199);
            gtbEmail.MaxLength = 32767;
            gtbEmail.Multiline = false;
            gtbEmail.Name = "gtbEmail";
            gtbEmail.Padding = new Padding(10, 5, 10, 5);
            gtbEmail.PasswordChar = '\0';
            gtbEmail.RequirementMode = CustomControls.GeneralTextBox.RequiredMode.Optional;
            gtbEmail.ScrollBars = ScrollBars.None;
            gtbEmail.SelectedText = "";
            gtbEmail.SelectionLength = 0;
            gtbEmail.SelectionStart = 0;
            gtbEmail.Size = new Size(219, 39);
            gtbEmail.TabIndex = 8;
            gtbEmail.TabStop = false;
            gtbEmail.Tag = "Email";
            gtbEmail.UseSystemPasswordChar = false;
            gtbEmail.Leave += gtbEmail_Leave;
            // 
            // hrbFemale
            // 
            hrbFemale.AutoSize = true;
            hrbFemale.CheckedColor = Color.FromArgb(64, 158, 255);
            hrbFemale.DisabledColor = Color.FromArgb(196, 198, 202);
            hrbFemale.DisabledStringColor = Color.FromArgb(186, 187, 189);
            hrbFemale.Enable = true;
            hrbFemale.EnabledCheckedColor = Color.FromArgb(64, 158, 255);
            hrbFemale.EnabledStringColor = Color.FromArgb(146, 146, 146);
            hrbFemale.EnabledUncheckedColor = Color.FromArgb(156, 158, 161);
            hrbFemale.Font = new Font("Segoe UI", 10.2F);
            hrbFemale.ForeColor = Color.Black;
            hrbFemale.Location = new Point(124, 168);
            hrbFemale.Name = "hrbFemale";
            hrbFemale.Size = new Size(89, 20);
            hrbFemale.TabIndex = 7;
            hrbFemale.Text = "Female";
            hrbFemale.UseVisualStyleBackColor = true;
            // 
            // hrbMale
            // 
            hrbMale.AutoSize = true;
            hrbMale.Checked = true;
            hrbMale.CheckedColor = Color.FromArgb(64, 158, 255);
            hrbMale.DisabledColor = Color.FromArgb(196, 198, 202);
            hrbMale.DisabledStringColor = Color.FromArgb(186, 187, 189);
            hrbMale.Enable = true;
            hrbMale.EnabledCheckedColor = Color.FromArgb(64, 158, 255);
            hrbMale.EnabledStringColor = Color.FromArgb(146, 146, 146);
            hrbMale.EnabledUncheckedColor = Color.FromArgb(156, 158, 161);
            hrbMale.Font = new Font("Segoe UI", 10.2F);
            hrbMale.ForeColor = Color.Black;
            hrbMale.Location = new Point(240, 168);
            hrbMale.Name = "hrbMale";
            hrbMale.Size = new Size(72, 20);
            hrbMale.TabIndex = 6;
            hrbMale.TabStop = true;
            hrbMale.Text = "Male";
            hrbMale.UseVisualStyleBackColor = true;
            hrbMale.CheckedChanged += GenderHopeRadioButtonChekedChanged;
            // 
            // gtbDateOfBirth
            // 
            gtbDateOfBirth.BackColor = Color.White;
            gtbDateOfBirth.BaseColor = Color.FromArgb(44, 55, 66);
            gtbDateOfBirth.BorderColor = Color.Gray;
            gtbDateOfBirth.BorderColorA = Color.FromArgb(64, 158, 255);
            gtbDateOfBirth.BorderColorB = Color.FromArgb(220, 223, 230);
            gtbDateOfBirth.BorderRadius = 13;
            gtbDateOfBirth.BorderThickness = 2;
            gtbDateOfBirth.FieldName = "Date of Birth";
            gtbDateOfBirth.Font = new Font("Segoe UI", 10.2F);
            gtbDateOfBirth.ForeColor = Color.FromArgb(48, 49, 51);
            gtbDateOfBirth.Hint = "YYYY-MM-DD";
            gtbDateOfBirth.InputType = CustomControls.GeneralTextBox.TextboxInputType.Date;
            gtbDateOfBirth.Location = new Point(124, 115);
            gtbDateOfBirth.MaxLength = 32767;
            gtbDateOfBirth.Multiline = false;
            gtbDateOfBirth.Name = "gtbDateOfBirth";
            gtbDateOfBirth.Padding = new Padding(10, 5, 10, 5);
            gtbDateOfBirth.PasswordChar = '\0';
            gtbDateOfBirth.RequirementMode = CustomControls.GeneralTextBox.RequiredMode.Required;
            gtbDateOfBirth.ScrollBars = ScrollBars.None;
            gtbDateOfBirth.SelectedText = "";
            gtbDateOfBirth.SelectionLength = 0;
            gtbDateOfBirth.SelectionStart = 0;
            gtbDateOfBirth.Size = new Size(219, 39);
            gtbDateOfBirth.TabIndex = 3;
            gtbDateOfBirth.TabStop = false;
            gtbDateOfBirth.Tag = "Date of Birth";
            gtbDateOfBirth.UseSystemPasswordChar = false;
            gtbDateOfBirth.Leave += gtbDateOfBirth_Leave;
            // 
            // gtbLastName
            // 
            gtbLastName.BackColor = Color.White;
            gtbLastName.BaseColor = Color.FromArgb(44, 55, 66);
            gtbLastName.BorderColor = Color.Gray;
            gtbLastName.BorderColorA = Color.FromArgb(64, 158, 255);
            gtbLastName.BorderColorB = Color.FromArgb(220, 223, 230);
            gtbLastName.BorderRadius = 13;
            gtbLastName.BorderThickness = 2;
            gtbLastName.FieldName = "Last Name";
            gtbLastName.Font = new Font("Segoe UI", 10.2F);
            gtbLastName.ForeColor = Color.FromArgb(48, 49, 51);
            gtbLastName.Hint = "Last Name";
            gtbLastName.InputType = CustomControls.GeneralTextBox.TextboxInputType.Text;
            gtbLastName.Location = new Point(570, 73);
            gtbLastName.MaxLength = 32767;
            gtbLastName.Multiline = false;
            gtbLastName.Name = "gtbLastName";
            gtbLastName.Padding = new Padding(10, 5, 10, 5);
            gtbLastName.PasswordChar = '\0';
            gtbLastName.RequirementMode = CustomControls.GeneralTextBox.RequiredMode.Required;
            gtbLastName.ScrollBars = ScrollBars.None;
            gtbLastName.SelectedText = "";
            gtbLastName.SelectionLength = 0;
            gtbLastName.SelectionStart = 0;
            gtbLastName.Size = new Size(219, 39);
            gtbLastName.TabIndex = 2;
            gtbLastName.TabStop = false;
            gtbLastName.Tag = "Last Name";
            gtbLastName.UseSystemPasswordChar = false;
            gtbLastName.Leave += gtbLastName_Leave;
            // 
            // gtbMiddleName
            // 
            gtbMiddleName.BackColor = Color.White;
            gtbMiddleName.BaseColor = Color.FromArgb(44, 55, 66);
            gtbMiddleName.BorderColor = Color.Gray;
            gtbMiddleName.BorderColorA = Color.FromArgb(64, 158, 255);
            gtbMiddleName.BorderColorB = Color.FromArgb(220, 223, 230);
            gtbMiddleName.BorderRadius = 13;
            gtbMiddleName.BorderThickness = 2;
            gtbMiddleName.FieldName = "Middle Name";
            gtbMiddleName.Font = new Font("Segoe UI", 10.2F);
            gtbMiddleName.ForeColor = Color.FromArgb(48, 49, 51);
            gtbMiddleName.Hint = "Middle Name";
            gtbMiddleName.InputType = CustomControls.GeneralTextBox.TextboxInputType.Text;
            gtbMiddleName.Location = new Point(346, 73);
            gtbMiddleName.MaxLength = 32767;
            gtbMiddleName.Multiline = false;
            gtbMiddleName.Name = "gtbMiddleName";
            gtbMiddleName.Padding = new Padding(10, 5, 10, 5);
            gtbMiddleName.PasswordChar = '\0';
            gtbMiddleName.RequirementMode = CustomControls.GeneralTextBox.RequiredMode.Optional;
            gtbMiddleName.ScrollBars = ScrollBars.None;
            gtbMiddleName.SelectedText = "";
            gtbMiddleName.SelectionLength = 0;
            gtbMiddleName.SelectionStart = 0;
            gtbMiddleName.Size = new Size(219, 39);
            gtbMiddleName.TabIndex = 1;
            gtbMiddleName.TabStop = false;
            gtbMiddleName.Tag = "Middle Name";
            gtbMiddleName.UseSystemPasswordChar = false;
            gtbMiddleName.Leave += gtbMiddleName_Leave;
            // 
            // lblPersonId
            // 
            lblPersonId.AutoSize = true;
            lblPersonId.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblPersonId.Location = new Point(122, 18);
            lblPersonId.Name = "lblPersonId";
            lblPersonId.Size = new Size(53, 23);
            lblPersonId.TabIndex = 36;
            lblPersonId.Text = "[ ??? ]";
            // 
            // gtbFirstName
            // 
            gtbFirstName.BackColor = Color.White;
            gtbFirstName.BaseColor = Color.FromArgb(44, 55, 66);
            gtbFirstName.BorderColor = Color.Gray;
            gtbFirstName.BorderColorA = Color.FromArgb(64, 158, 255);
            gtbFirstName.BorderColorB = Color.FromArgb(220, 223, 230);
            gtbFirstName.BorderRadius = 13;
            gtbFirstName.BorderThickness = 2;
            gtbFirstName.FieldName = "First Name";
            gtbFirstName.Font = new Font("Segoe UI", 10.2F);
            gtbFirstName.ForeColor = Color.FromArgb(48, 49, 51);
            gtbFirstName.Hint = "First Name";
            gtbFirstName.InputType = CustomControls.GeneralTextBox.TextboxInputType.Text;
            gtbFirstName.Location = new Point(124, 73);
            gtbFirstName.MaxLength = 32767;
            gtbFirstName.Multiline = false;
            gtbFirstName.Name = "gtbFirstName";
            gtbFirstName.Padding = new Padding(10, 5, 10, 5);
            gtbFirstName.PasswordChar = '\0';
            gtbFirstName.RequirementMode = CustomControls.GeneralTextBox.RequiredMode.Required;
            gtbFirstName.ScrollBars = ScrollBars.None;
            gtbFirstName.SelectedText = "";
            gtbFirstName.SelectionLength = 0;
            gtbFirstName.SelectionStart = 0;
            gtbFirstName.Size = new Size(219, 39);
            gtbFirstName.TabIndex = 0;
            gtbFirstName.TabStop = false;
            gtbFirstName.Tag = "First Name";
            gtbFirstName.UseSystemPasswordChar = false;
            gtbFirstName.Leave += gtbFirstName_Leave;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(35, 18);
            label5.Name = "label5";
            label5.Size = new Size(88, 23);
            label5.TabIndex = 33;
            label5.Text = "Person Id:";
            // 
            // pbPersonImage
            // 
            pbPersonImage.BorderStyle = BorderStyle.FixedSingle;
            pbPersonImage.Image = Properties.Resources.Man_Default_Pictuer;
            pbPersonImage.Location = new Point(843, 3);
            pbPersonImage.Name = "pbPersonImage";
            pbPersonImage.Size = new Size(191, 197);
            pbPersonImage.SizeMode = PictureBoxSizeMode.Zoom;
            pbPersonImage.TabIndex = 32;
            pbPersonImage.TabStop = false;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            label7.Location = new Point(64, 207);
            label7.Name = "label7";
            label7.Size = new Size(59, 23);
            label7.TabIndex = 31;
            label7.Text = "Email:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            label8.Location = new Point(3, 123);
            label8.Name = "label8";
            label8.Size = new Size(120, 23);
            label8.TabIndex = 30;
            label8.Text = "Date of Birth:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            label4.Location = new Point(49, 165);
            label4.Name = "label4";
            label4.Size = new Size(74, 23);
            label4.TabIndex = 29;
            label4.Text = "Gender:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            label1.Location = new Point(27, 81);
            label1.Name = "label1";
            label1.Size = new Size(96, 23);
            label1.TabIndex = 24;
            label1.Text = "Full Name:";
            // 
            // ibtnSave
            // 
            ibtnSave.Flip = FontAwesome.Sharp.FlipOrientation.Horizontal;
            ibtnSave.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            ibtnSave.IconChar = FontAwesome.Sharp.IconChar.Save;
            ibtnSave.IconColor = Color.Black;
            ibtnSave.IconFont = FontAwesome.Sharp.IconFont.Auto;
            ibtnSave.IconSize = 32;
            ibtnSave.ImageAlign = ContentAlignment.MiddleLeft;
            ibtnSave.Location = new Point(959, 393);
            ibtnSave.Name = "ibtnSave";
            ibtnSave.Size = new Size(149, 43);
            ibtnSave.TabIndex = 10;
            ibtnSave.Text = "Save";
            ibtnSave.TextAlign = ContentAlignment.MiddleRight;
            ibtnSave.TextImageRelation = TextImageRelation.ImageBeforeText;
            ibtnSave.UseVisualStyleBackColor = true;
            ibtnSave.Click += ibtnSave_Click;
            // 
            // ibtnClose2
            // 
            ibtnClose2.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            ibtnClose2.IconChar = FontAwesome.Sharp.IconChar.XmarkCircle;
            ibtnClose2.IconColor = Color.Black;
            ibtnClose2.IconFont = FontAwesome.Sharp.IconFont.Auto;
            ibtnClose2.IconSize = 32;
            ibtnClose2.ImageAlign = ContentAlignment.MiddleLeft;
            ibtnClose2.Location = new Point(804, 393);
            ibtnClose2.Name = "ibtnClose2";
            ibtnClose2.Size = new Size(149, 43);
            ibtnClose2.TabIndex = 11;
            ibtnClose2.Text = "Close";
            ibtnClose2.TextAlign = ContentAlignment.MiddleRight;
            ibtnClose2.TextImageRelation = TextImageRelation.ImageBeforeText;
            ibtnClose2.UseVisualStyleBackColor = true;
            ibtnClose2.Click += ibtnClose_Click;
            // 
            // AddAndUpdatePersonForm
            // 
            AcceptButton = ibtnSave;
            AutoScaleDimensions = new SizeF(9F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = ibtnClose2;
            ClientSize = new Size(1160, 447);
            Controls.Add(ibtnClose2);
            Controls.Add(ibtnSave);
            Controls.Add(panel1);
            Controls.Add(ibtnClose);
            Controls.Add(lblTitle);
            Name = "AddAndUpdatePersonForm";
            StartPosition = FormStartPosition.Manual;
            Text = "AddAndUpdatePersonForm";
            Activated += AddAndUpdatePersonForm_Activated;
            FormClosing += AddAndUpdatePersonForm_FormClosing;
            Load += AddAndUpdatePersonForm_Load;
            Controls.SetChildIndex(lblTitle, 0);
            Controls.SetChildIndex(ibtnClose, 0);
            Controls.SetChildIndex(panel1, 0);
            Controls.SetChildIndex(ibtnSave, 0);
            Controls.SetChildIndex(ibtnClose2, 0);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pbPersonImage).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        public Label lblTitle;
        private FontAwesome.Sharp.IconButton ibtnClose;
        private Panel panel1;
        private CustomControls.GeneralTextBox gtbFirstName;
        private Label label5;
        private Label label7;
        private Label label8;
        private Label label4;
        private Label label1;
        private Label lblPersonId;
        private CustomControls.GeneralTextBox gtbEmail;
        private ReaLTaiizor.Controls.HopeRadioButton hrbFemale;
        private ReaLTaiizor.Controls.HopeRadioButton hrbMale;
        private CustomControls.GeneralTextBox gtbDateOfBirth;
        private CustomControls.GeneralTextBox gtbLastName;
        private CustomControls.GeneralTextBox gtbMiddleName;
        private PictureBox pbPersonImage;
        private FontAwesome.Sharp.IconButton ibtnUploadImage;
        private FontAwesome.Sharp.IconButton ibtnAddPhone;
        private CustomControls.GeneralTextBox gtbPhoneNumber;
        private Label label2;
        private FontAwesome.Sharp.IconButton ibtnSave;
        private FontAwesome.Sharp.IconButton ibtnClose2;
        private ListBox lstPhoneNumbers;
        private Label lblPhoneList;
        private FontAwesome.Sharp.IconButton ibtnRemovePhone;
        private FontAwesome.Sharp.IconButton ibtnRemoveImage;
    }
}