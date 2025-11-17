namespace WinFormsClient.Forms
{
    partial class BaseForm
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
            pnlTopBF = new Panel();
            pnlRightBF = new Panel();
            pntBottomBF = new Panel();
            pnlLeftBF = new Panel();
            SuspendLayout();
            // 
            // pnlTopBF
            // 
            pnlTopBF.BackColor = Color.FromArgb(246, 128, 5);
            pnlTopBF.Dock = DockStyle.Top;
            pnlTopBF.Location = new Point(0, 0);
            pnlTopBF.Name = "pnlTopBF";
            pnlTopBF.Size = new Size(875, 4);
            pnlTopBF.TabIndex = 0;
            pnlTopBF.Tag = "Window Panel";
            // 
            // pnlRightBF
            // 
            pnlRightBF.BackColor = Color.FromArgb(246, 128, 5);
            pnlRightBF.Dock = DockStyle.Right;
            pnlRightBF.Location = new Point(871, 4);
            pnlRightBF.Name = "pnlRightBF";
            pnlRightBF.Size = new Size(4, 486);
            pnlRightBF.TabIndex = 2;
            pnlRightBF.Tag = "Window Panel";
            // 
            // pntBottomBF
            // 
            pntBottomBF.BackColor = Color.FromArgb(246, 128, 5);
            pntBottomBF.Dock = DockStyle.Bottom;
            pntBottomBF.Location = new Point(0, 486);
            pntBottomBF.Name = "pntBottomBF";
            pntBottomBF.Size = new Size(871, 4);
            pntBottomBF.TabIndex = 3;
            pntBottomBF.Tag = "Window Panel";
            // 
            // pnlLeftBF
            // 
            pnlLeftBF.BackColor = Color.FromArgb(246, 128, 5);
            pnlLeftBF.Dock = DockStyle.Left;
            pnlLeftBF.Location = new Point(0, 4);
            pnlLeftBF.Name = "pnlLeftBF";
            pnlLeftBF.Size = new Size(4, 482);
            pnlLeftBF.TabIndex = 4;
            pnlLeftBF.Tag = "Window Panel";
            // 
            // BaseForm
            // 
            AutoScaleDimensions = new SizeF(9F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(875, 490);
            Controls.Add(pnlLeftBF);
            Controls.Add(pntBottomBF);
            Controls.Add(pnlRightBF);
            Controls.Add(pnlTopBF);
            Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.None;
            Name = "BaseForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "BaseForm";
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlTopBF;
        private Panel pnlRightBF;
        private Panel pntBottomBF;
        private Panel pnlLeftBF;
    }
}