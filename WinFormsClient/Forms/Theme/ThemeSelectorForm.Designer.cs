namespace WinFormsClient.Forms.Theme
{
    partial class ThemeSelectorForm
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
            themeControl1 = new WinFormsClient.Controls.Theme.ThemeControl();
            themeControl2 = new WinFormsClient.Controls.Theme.ThemeControl();
            themeControl3 = new WinFormsClient.Controls.Theme.ThemeControl();
            themeControl4 = new WinFormsClient.Controls.Theme.ThemeControl();
            SuspendLayout();

            // 
            // themeControl1
            // 
            themeControl1.Checked = false;
            themeControl1.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            themeControl1.Location = new Point(120, 195);
            themeControl1.Name = "themeControl1";
            themeControl1.Size = new Size(234, 221);
            themeControl1.TabIndex = 5;
            themeControl1.Theme = Enums.EnTheme.enTheme.DarkOrang;
            themeControl1.ThemeSelected += OnThemeSelected;
            // 
            // themeControl2
            // 
            themeControl2.Checked = false;
            themeControl2.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            themeControl2.Location = new Point(451, 195);
            themeControl2.Name = "themeControl2";
            themeControl2.Size = new Size(234, 221);
            themeControl2.TabIndex = 6;
            themeControl2.Theme = Enums.EnTheme.enTheme.Dark;
            themeControl2.ThemeSelected += OnThemeSelected;
            // 
            // themeControl3
            // 
            themeControl3.Checked = false;
            themeControl3.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            themeControl3.Location = new Point(782, 195);
            themeControl3.Name = "themeControl3";
            themeControl3.Size = new Size(234, 221);
            themeControl3.TabIndex = 7;
            themeControl3.Theme = Enums.EnTheme.enTheme.Light;
            themeControl3.ThemeSelected += OnThemeSelected;
            // 
            // themeControl4
            // 
            themeControl4.Checked = false;
            themeControl4.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            themeControl4.Location = new Point(1103, 195);
            themeControl4.Name = "themeControl4";
            themeControl4.Size = new Size(234, 221);
            themeControl4.TabIndex = 8;
            themeControl4.Theme = Enums.EnTheme.enTheme.BlueMist;
            themeControl4.ThemeSelected += OnThemeSelected;
            // 
            // ThemeSelectorForm
            // 
            AutoScaleDimensions = new SizeF(9F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1485, 881);
            Controls.Add(themeControl4);
            Controls.Add(themeControl3);
            Controls.Add(themeControl2);
            Controls.Add(themeControl1);
            Name = "ThemeSelectorForm";
            Text = "ThemeForm";
            Load += ThemeSelectorForm_Load;
            Controls.SetChildIndex(themeControl1, 0);
            Controls.SetChildIndex(themeControl2, 0);
            Controls.SetChildIndex(themeControl3, 0);
            Controls.SetChildIndex(themeControl4, 0);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Controls.Theme.ThemeControl themeControl1;
        private Controls.Theme.ThemeControl themeControl2;
        private Controls.Theme.ThemeControl themeControl3;
        private Controls.Theme.ThemeControl themeControl4;
    }
}