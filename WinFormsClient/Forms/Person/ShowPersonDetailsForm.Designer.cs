namespace WinFormsClient.Forms.Person
{
    partial class ShowPersonDetailsForm
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
            ctrlShowPersonDetails1 = new WinFormsClient.Controls.Person.ctrlShowPersonDetails();
            lblTitle = new Label();
            ibtnClose = new FontAwesome.Sharp.IconButton();
            ibtnClose2 = new FontAwesome.Sharp.IconButton();
            llblUpdatePerson = new LinkLabel();
            SuspendLayout();
            // 
            // ctrlShowPersonDetails1
            // 
            ctrlShowPersonDetails1.Font = new Font("Segoe UI", 10.2F);
            ctrlShowPersonDetails1.Location = new Point(53, 114);
            ctrlShowPersonDetails1.Name = "ctrlShowPersonDetails1";
            ctrlShowPersonDetails1.Size = new Size(871, 259);
            ctrlShowPersonDetails1.TabIndex = 5;
            // 
            // lblTitle
            // 
            lblTitle.Anchor = AnchorStyles.Left;
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 30F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.Location = new Point(47, 44);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(363, 67);
            lblTitle.TabIndex = 7;
            lblTitle.Tag = "Title";
            lblTitle.Text = "Person Details";
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
            ibtnClose.TabIndex = 8;
            ibtnClose.UseVisualStyleBackColor = true;
            ibtnClose.Click += CloseButton_Click;
            // 
            // ibtnClose2
            // 
            ibtnClose2.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            ibtnClose2.IconChar = FontAwesome.Sharp.IconChar.XmarkCircle;
            ibtnClose2.IconColor = Color.Black;
            ibtnClose2.IconFont = FontAwesome.Sharp.IconFont.Auto;
            ibtnClose2.IconSize = 32;
            ibtnClose2.ImageAlign = ContentAlignment.MiddleLeft;
            ibtnClose2.Location = new Point(775, 379);
            ibtnClose2.Name = "ibtnClose2";
            ibtnClose2.Size = new Size(149, 43);
            ibtnClose2.TabIndex = 12;
            ibtnClose2.Text = "Close";
            ibtnClose2.TextAlign = ContentAlignment.MiddleRight;
            ibtnClose2.TextImageRelation = TextImageRelation.ImageBeforeText;
            ibtnClose2.UseVisualStyleBackColor = true;
            ibtnClose2.Click += CloseButton_Click;
            // 
            // llblUpdatePerson
            // 
            llblUpdatePerson.AutoSize = true;
            llblUpdatePerson.Enabled = false;
            llblUpdatePerson.Location = new Point(767, 86);
            llblUpdatePerson.Name = "llblUpdatePerson";
            llblUpdatePerson.Size = new Size(157, 23);
            llblUpdatePerson.TabIndex = 13;
            llblUpdatePerson.TabStop = true;
            llblUpdatePerson.Text = "Update Person Info";
            llblUpdatePerson.LinkClicked += llblUpdatePerson_LinkClicked;
            // 
            // ShowPersonDetailsForm
            // 
            AutoScaleDimensions = new SizeF(9F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(977, 435);
            Controls.Add(llblUpdatePerson);
            Controls.Add(ibtnClose2);
            Controls.Add(ibtnClose);
            Controls.Add(lblTitle);
            Controls.Add(ctrlShowPersonDetails1);
            Name = "ShowPersonDetailsForm";
            Text = "ShowPersonDetailsForm";
            Load += ShowPersonDetailsForm_Load;
            Controls.SetChildIndex(ctrlShowPersonDetails1, 0);
            Controls.SetChildIndex(lblTitle, 0);
            Controls.SetChildIndex(ibtnClose, 0);
            Controls.SetChildIndex(ibtnClose2, 0);
            Controls.SetChildIndex(llblUpdatePerson, 0);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Controls.Person.ctrlShowPersonDetails ctrlShowPersonDetails1;
        public Label lblTitle;
        private FontAwesome.Sharp.IconButton ibtnClose;
        private FontAwesome.Sharp.IconButton ibtnClose2;
        private LinkLabel llblUpdatePerson;
    }
}