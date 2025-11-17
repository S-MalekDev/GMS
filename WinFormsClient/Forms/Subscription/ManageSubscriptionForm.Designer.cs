namespace WinFormsClient.Forms.Subscription
{
    partial class ManageSubscriptionForm
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
            SuspendLayout();
            // 
            // lblChildFormTitle
            // 
            lblChildFormTitle.Size = new Size(375, 46);
            lblChildFormTitle.Text = "Manage Subscriptions";
            // 
            // ManageSubscriptionForm
            // 
            AutoScaleDimensions = new SizeF(9F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1485, 881);
            Name = "ManageSubscriptionForm";
            Text = "ManageSubscriptionForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
    }
}