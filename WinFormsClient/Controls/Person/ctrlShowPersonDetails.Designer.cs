namespace WinFormsClient.Controls.Person
{
    partial class ctrlShowPersonDetails
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ctrlShowPersonDetails));
            label1 = new Label();
            label2 = new Label();
            label4 = new Label();
            label3 = new Label();
            label6 = new Label();
            lblPersonId = new Label();
            lblFullName = new Label();
            lblEmail = new Label();
            lblGender = new Label();
            lblDateOfBirth = new Label();
            label10 = new Label();
            lblPhoneNumber = new Label();
            pbPersonImage = new PictureBox();
            gbPersonDetails = new GroupBox();
            ((System.ComponentModel.ISupportInitialize)pbPersonImage).BeginInit();
            gbPersonDetails.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            label1.Location = new Point(37, 39);
            label1.Name = "label1";
            label1.Size = new Size(88, 23);
            label1.TabIndex = 0;
            label1.Text = "Person Id:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            label2.Location = new Point(29, 97);
            label2.Name = "label2";
            label2.Size = new Size(96, 23);
            label2.TabIndex = 1;
            label2.Text = "Full Name:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            label4.Location = new Point(66, 133);
            label4.Name = "label4";
            label4.Size = new Size(59, 23);
            label4.TabIndex = 2;
            label4.Text = "Email:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            label3.Location = new Point(51, 169);
            label3.Name = "label3";
            label3.Size = new Size(74, 23);
            label3.TabIndex = 3;
            label3.Text = "Gender:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            label6.Location = new Point(5, 205);
            label6.Name = "label6";
            label6.Size = new Size(120, 23);
            label6.TabIndex = 4;
            label6.Text = "Date of Birth:";
            // 
            // lblPersonId
            // 
            lblPersonId.AutoSize = true;
            lblPersonId.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblPersonId.Location = new Point(122, 39);
            lblPersonId.Name = "lblPersonId";
            lblPersonId.Size = new Size(53, 23);
            lblPersonId.TabIndex = 5;
            lblPersonId.Text = "[ ??? ]";
            // 
            // lblFullName
            // 
            lblFullName.AutoSize = true;
            lblFullName.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblFullName.Location = new Point(122, 97);
            lblFullName.Name = "lblFullName";
            lblFullName.Size = new Size(31, 23);
            lblFullName.TabIndex = 6;
            lblFullName.Text = "???";
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblEmail.Location = new Point(122, 133);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(34, 23);
            lblEmail.TabIndex = 7;
            lblEmail.Text = "???";
            // 
            // lblGender
            // 
            lblGender.AutoSize = true;
            lblGender.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblGender.Location = new Point(122, 169);
            lblGender.Name = "lblGender";
            lblGender.Size = new Size(34, 23);
            lblGender.TabIndex = 8;
            lblGender.Text = "???";
            // 
            // lblDateOfBirth
            // 
            lblDateOfBirth.AutoSize = true;
            lblDateOfBirth.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblDateOfBirth.Location = new Point(122, 205);
            lblDateOfBirth.Name = "lblDateOfBirth";
            lblDateOfBirth.Size = new Size(34, 23);
            lblDateOfBirth.TabIndex = 9;
            lblDateOfBirth.Text = "???";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            label10.Location = new Point(365, 133);
            label10.Name = "label10";
            label10.Size = new Size(136, 23);
            label10.TabIndex = 10;
            label10.Text = "Phone Number:";
            // 
            // lblPhoneNumber
            // 
            lblPhoneNumber.AutoSize = true;
            lblPhoneNumber.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblPhoneNumber.Location = new Point(501, 133);
            lblPhoneNumber.Name = "lblPhoneNumber";
            lblPhoneNumber.Size = new Size(34, 23);
            lblPhoneNumber.TabIndex = 11;
            lblPhoneNumber.Text = "???";
            // 
            // pbPersonImage
            // 
            pbPersonImage.Image = (Image)resources.GetObject("pbPersonImage.Image");
            pbPersonImage.Location = new Point(676, 43);
            pbPersonImage.Name = "pbPersonImage";
            pbPersonImage.Size = new Size(168, 185);
            pbPersonImage.SizeMode = PictureBoxSizeMode.Zoom;
            pbPersonImage.TabIndex = 12;
            pbPersonImage.TabStop = false;
            // 
            // gbPersonDetails
            // 
            gbPersonDetails.Controls.Add(pbPersonImage);
            gbPersonDetails.Controls.Add(lblPhoneNumber);
            gbPersonDetails.Controls.Add(label10);
            gbPersonDetails.Controls.Add(lblDateOfBirth);
            gbPersonDetails.Controls.Add(lblGender);
            gbPersonDetails.Controls.Add(lblEmail);
            gbPersonDetails.Controls.Add(lblFullName);
            gbPersonDetails.Controls.Add(lblPersonId);
            gbPersonDetails.Controls.Add(label6);
            gbPersonDetails.Controls.Add(label3);
            gbPersonDetails.Controls.Add(label4);
            gbPersonDetails.Controls.Add(label2);
            gbPersonDetails.Controls.Add(label1);
            gbPersonDetails.Location = new Point(6, 4);
            gbPersonDetails.Name = "gbPersonDetails";
            gbPersonDetails.Size = new Size(856, 238);
            gbPersonDetails.TabIndex = 1;
            gbPersonDetails.TabStop = false;
            gbPersonDetails.Text = "Person Details";
            // 
            // ctrlShowPersonDetails
            // 
            AutoScaleDimensions = new SizeF(9F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(gbPersonDetails);
            Font = new Font("Segoe UI", 10.2F);
            Name = "ctrlShowPersonDetails";
            Size = new Size(865, 246);
            ((System.ComponentModel.ISupportInitialize)pbPersonImage).EndInit();
            gbPersonDetails.ResumeLayout(false);
            gbPersonDetails.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label4;
        private Label label3;
        private Label label6;
        private Label lblPersonId;
        private Label lblFullName;
        private Label lblEmail;
        private Label lblGender;
        private Label lblDateOfBirth;
        private Label label10;
        private Label lblPhoneNumber;
        private PictureBox pbPersonImage;
        private GroupBox gbPersonDetails;
    }
}
