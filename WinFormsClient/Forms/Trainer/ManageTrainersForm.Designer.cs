namespace WinFormsClient.Forms.Trainer
{
    partial class ManageTrainersForm
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
            label2 = new Label();
            SuspendLayout();
            // 
            // lblChildFormTitle
            // 
            lblChildFormTitle.Size = new Size(285, 46);
            lblChildFormTitle.Text = "Manage Trainers";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(692, 331);
            label2.Name = "label2";
            label2.Size = new Size(136, 23);
            label2.TabIndex = 9;
            label2.Text = "Trainers Content";
            // 
            // ManageTrainersForm
            // 
            AutoScaleDimensions = new SizeF(9F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1485, 881);
            Controls.Add(label2);
            Name = "ManageTrainersForm";
            Text = "ManageTrainersForm";
            Controls.SetChildIndex(lblChildFormTitle, 0);
            Controls.SetChildIndex(label2, 0);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label2;
    }
}