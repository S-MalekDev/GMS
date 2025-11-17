namespace WinFormsClient.Forms.Person
{
    partial class ManagePeopleForm
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
            dgvPersonList = new DataGridView();
            tlpManagePeople = new TableLayoutPanel();
            ibtnClose = new FontAwesome.Sharp.IconButton();
            lblTitle = new Label();
            pnlPersonList = new Panel();
            lblRecordsCount = new Label();
            label1 = new Label();
            dgvPeopleList = new DataGridView();
            cmsPersonList = new ContextMenuStrip(components);
            showDtailsToolStripMenuItem = new ToolStripMenuItem();
            toolStripMenuItem1 = new ToolStripSeparator();
            addNewToolStripMenuItem = new ToolStripMenuItem();
            updateToolStripMenuItem = new ToolStripMenuItem();
            removeToolStripMenuItem = new ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)dgvPersonList).BeginInit();
            tlpManagePeople.SuspendLayout();
            pnlPersonList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPeopleList).BeginInit();
            cmsPersonList.SuspendLayout();
            SuspendLayout();
            // 
            // dgvPersonList
            // 
            dgvPersonList.ColumnHeadersHeight = 29;
            dgvPersonList.Location = new Point(0, 0);
            dgvPersonList.Name = "dgvPersonList";
            dgvPersonList.RowHeadersWidth = 51;
            dgvPersonList.Size = new Size(240, 150);
            dgvPersonList.TabIndex = 0;
            // 
            // tlpManagePeople
            // 
            tlpManagePeople.ColumnCount = 3;
            tlpManagePeople.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 3F));
            tlpManagePeople.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 94F));
            tlpManagePeople.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 3F));
            tlpManagePeople.Controls.Add(ibtnClose, 0, 0);
            tlpManagePeople.Controls.Add(lblTitle, 1, 1);
            tlpManagePeople.Controls.Add(pnlPersonList, 1, 3);
            tlpManagePeople.Dock = DockStyle.Fill;
            tlpManagePeople.Location = new Point(4, 4);
            tlpManagePeople.Name = "tlpManagePeople";
            tlpManagePeople.RowCount = 5;
            tlpManagePeople.RowStyles.Add(new RowStyle(SizeType.Percent, 5F));
            tlpManagePeople.RowStyles.Add(new RowStyle(SizeType.Percent, 8F));
            tlpManagePeople.RowStyles.Add(new RowStyle(SizeType.Percent, 7F));
            tlpManagePeople.RowStyles.Add(new RowStyle(SizeType.Percent, 60F));
            tlpManagePeople.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tlpManagePeople.Size = new Size(1477, 873);
            tlpManagePeople.TabIndex = 8;
            tlpManagePeople.Tag = "Form Container";
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
            ibtnClose.TabIndex = 5;
            ibtnClose.UseVisualStyleBackColor = true;
            ibtnClose.Click += ibtnClose_Click;
            // 
            // lblTitle
            // 
            lblTitle.Anchor = AnchorStyles.Left;
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 30F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.Location = new Point(47, 44);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(393, 67);
            lblTitle.TabIndex = 6;
            lblTitle.Tag = "Title";
            lblTitle.Text = "Manage People";
            // 
            // pnlPersonList
            // 
            pnlPersonList.Controls.Add(lblRecordsCount);
            pnlPersonList.Controls.Add(label1);
            pnlPersonList.Controls.Add(dgvPeopleList);
            pnlPersonList.Dock = DockStyle.Fill;
            pnlPersonList.Location = new Point(47, 176);
            pnlPersonList.Name = "pnlPersonList";
            pnlPersonList.Size = new Size(1382, 517);
            pnlPersonList.TabIndex = 7;
            pnlPersonList.Tag = "List View Container";
            // 
            // lblRecordsCount
            // 
            lblRecordsCount.Anchor = AnchorStyles.None;
            lblRecordsCount.AutoSize = true;
            lblRecordsCount.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblRecordsCount.Location = new Point(122, 477);
            lblRecordsCount.Name = "lblRecordsCount";
            lblRecordsCount.Size = new Size(30, 23);
            lblRecordsCount.TabIndex = 10;
            lblRecordsCount.Text = "00";
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.None;
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(34, 477);
            label1.Name = "label1";
            label1.Size = new Size(93, 23);
            label1.TabIndex = 9;
            label1.Text = "# Records:";
            // 
            // dgvPeopleList
            // 
            dgvPeopleList.AllowUserToAddRows = false;
            dgvPeopleList.AllowUserToDeleteRows = false;
            dgvPeopleList.AllowUserToOrderColumns = true;
            dgvPeopleList.Anchor = AnchorStyles.None;
            dgvPeopleList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPeopleList.ContextMenuStrip = cmsPersonList;
            dgvPeopleList.Location = new Point(34, 44);
            dgvPeopleList.Name = "dgvPeopleList";
            dgvPeopleList.ReadOnly = true;
            dgvPeopleList.RowHeadersWidth = 4;
            dgvPeopleList.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPeopleList.Size = new Size(1315, 429);
            dgvPeopleList.TabIndex = 8;
            dgvPeopleList.Tag = "";
            // 
            // cmsPersonList
            // 
            cmsPersonList.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            cmsPersonList.ImageScalingSize = new Size(20, 20);
            cmsPersonList.Items.AddRange(new ToolStripItem[] { showDtailsToolStripMenuItem, toolStripMenuItem1, addNewToolStripMenuItem, updateToolStripMenuItem, removeToolStripMenuItem });
            cmsPersonList.Name = "cmsPersonList";
            cmsPersonList.Size = new Size(176, 122);
            // 
            // showDtailsToolStripMenuItem
            // 
            showDtailsToolStripMenuItem.Name = "showDtailsToolStripMenuItem";
            showDtailsToolStripMenuItem.Size = new Size(175, 28);
            showDtailsToolStripMenuItem.Text = "Show Dtails";
            showDtailsToolStripMenuItem.Click += showDtailsToolStripMenuItem_Click;
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.Size = new Size(172, 6);
            // 
            // addNewToolStripMenuItem
            // 
            addNewToolStripMenuItem.Name = "addNewToolStripMenuItem";
            addNewToolStripMenuItem.Size = new Size(175, 28);
            addNewToolStripMenuItem.Text = "Add New";
            addNewToolStripMenuItem.Click += addNewToolStripMenuItem_Click;
            // 
            // updateToolStripMenuItem
            // 
            updateToolStripMenuItem.Name = "updateToolStripMenuItem";
            updateToolStripMenuItem.Size = new Size(175, 28);
            updateToolStripMenuItem.Text = "Update";
            updateToolStripMenuItem.Click += updateToolStripMenuItem_Click;
            // 
            // removeToolStripMenuItem
            // 
            removeToolStripMenuItem.Name = "removeToolStripMenuItem";
            removeToolStripMenuItem.Size = new Size(175, 28);
            removeToolStripMenuItem.Text = "Remove";
            removeToolStripMenuItem.Click += removeToolStripMenuItem_Click;
            // 
            // ManagePeopleForm
            // 
            AutoScaleDimensions = new SizeF(9F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1485, 881);
            Controls.Add(tlpManagePeople);
            Name = "ManagePeopleForm";
            Text = "ManagePeopleForm";
            FormClosing += ManagePeopleForm_FormClosing;
            Load += ManagePeopleForm_Load;
            Controls.SetChildIndex(tlpManagePeople, 0);
            ((System.ComponentModel.ISupportInitialize)dgvPersonList).EndInit();
            tlpManagePeople.ResumeLayout(false);
            tlpManagePeople.PerformLayout();
            pnlPersonList.ResumeLayout(false);
            pnlPersonList.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPeopleList).EndInit();
            cmsPersonList.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private DataGridView dgvPersonList;
        protected TableLayoutPanel tlpManagePeople;
        private FontAwesome.Sharp.IconButton ibtnClose;
        public Label lblTitle;
        private Panel pnlPersonList;
        private DataGridView dgvPeopleList;
        private Label lblRecordsCount;
        private Label label1;
        private ContextMenuStrip cmsPersonList;
        private ToolStripMenuItem addNewToolStripMenuItem;
        private ToolStripMenuItem updateToolStripMenuItem;
        private ToolStripMenuItem showDtailsToolStripMenuItem;
        private DataGridViewButtonColumn X;
        private DataGridViewImageColumn Remove;
        private ToolStripMenuItem removeToolStripMenuItem;
        private ToolStripSeparator toolStripMenuItem1;
    }
}