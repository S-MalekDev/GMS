namespace WinFormsClient.Forms
{
    partial class BaseChildForm
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
            lblChildFormTitle = new Label();
            ibtnClose = new FontAwesome.Sharp.IconButton();
            tableLayoutPanel1 = new TableLayoutPanel();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // lblChildFormTitle
            // 
            lblChildFormTitle.Anchor = AnchorStyles.Left;
            lblChildFormTitle.AutoSize = true;
            lblChildFormTitle.Font = new Font("Segoe UI", 30F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblChildFormTitle.Location = new Point(51, 46);
            lblChildFormTitle.Name = "lblChildFormTitle";
            lblChildFormTitle.Size = new Size(132, 67);
            lblChildFormTitle.TabIndex = 6;
            lblChildFormTitle.Tag = "Title";
            lblChildFormTitle.Text = "Title";
            // 
            // ibtnClose
            // 
            ibtnClose.IconChar = FontAwesome.Sharp.IconChar.Close;
            ibtnClose.IconColor = Color.Black;
            ibtnClose.IconFont = FontAwesome.Sharp.IconFont.Auto;
            ibtnClose.IconSize = 38;
            ibtnClose.Location = new Point(3, 3);
            ibtnClose.Name = "ibtnClose";
            ibtnClose.Size = new Size(40, 40);
            ibtnClose.TabIndex = 5;
            ibtnClose.UseVisualStyleBackColor = true;
            ibtnClose.Click += ibtnClose_Click;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 3.29670334F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 96.7033F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 94F));
            tableLayoutPanel1.Controls.Add(ibtnClose, 0, 0);
            tableLayoutPanel1.Controls.Add(lblChildFormTitle, 1, 1);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(4, 4);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 3;
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(1477, 873);
            tableLayoutPanel1.TabIndex = 7;
            // 
            // BaseChildForm
            // 
            AutoScaleDimensions = new SizeF(9F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1485, 881);
            Controls.Add(tableLayoutPanel1);
            Name = "BaseChildForm";
            Text = "BaseChildForm";
            Controls.SetChildIndex(tableLayoutPanel1, 0);
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        public Label lblChildFormTitle;
        private FontAwesome.Sharp.IconButton ibtnClose;
        public TableLayoutPanel tableLayoutPanel1;
    }
}