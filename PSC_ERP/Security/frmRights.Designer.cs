namespace PSC_ERP.Security
{
    partial class frmRights
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRights));
            this.label1 = new System.Windows.Forms.Label();
            this.cmbGroup = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.treeMenus = new System.Windows.Forms.TreeView();
            this.toolMain = new System.Windows.Forms.ToolStrip();
            this.itSave = new System.Windows.Forms.ToolStripButton();
            this.itUndo = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.itDong = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.cmbGroup)).BeginInit();
            this.toolMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nhóm người sử dụng";
            // 
            // cmbGroup
            // 
            this.cmbGroup.DisplayMember = "TenChucNang";
            this.cmbGroup.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007;
            this.cmbGroup.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.cmbGroup.Location = new System.Drawing.Point(126, 43);
            this.cmbGroup.Name = "cmbGroup";
            this.cmbGroup.Size = new System.Drawing.Size(188, 21);
            this.cmbGroup.TabIndex = 1;
            this.cmbGroup.ValueMember = "GroupID";
            this.cmbGroup.ValueChanged += new System.EventHandler(this.cmbGroup_ValueChanged);
            // 
            // treeMenus
            // 
            this.treeMenus.CheckBoxes = true;
            this.treeMenus.FullRowSelect = true;
            this.treeMenus.ItemHeight = 18;
            this.treeMenus.Location = new System.Drawing.Point(15, 70);
            this.treeMenus.Name = "treeMenus";
            this.treeMenus.Size = new System.Drawing.Size(519, 466);
            this.treeMenus.TabIndex = 2;
            this.treeMenus.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.treeMenus_AfterCheck);
            // 
            // toolMain
            // 
            this.toolMain.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.itSave,
            this.itUndo,
            this.toolStripSeparator2,
            this.itDong});
            this.toolMain.Location = new System.Drawing.Point(0, 0);
            this.toolMain.Name = "toolMain";
            this.toolMain.Size = new System.Drawing.Size(546, 31);
            this.toolMain.TabIndex = 3;
            this.toolMain.Text = "Cập nhật";
            // 
            // itSave
            // 
            this.itSave.Image = ((System.Drawing.Image)(resources.GetObject("itSave.Image")));
            this.itSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.itSave.Name = "itSave";
            this.itSave.Size = new System.Drawing.Size(57, 28);
            this.itSave.Text = "Lưu";
            this.itSave.Click += new System.EventHandler(this.itSave_Click);
            // 
            // itUndo
            // 
            this.itUndo.Image = ((System.Drawing.Image)(resources.GetObject("itUndo.Image")));
            this.itUndo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.itUndo.Name = "itUndo";
            this.itUndo.Size = new System.Drawing.Size(65, 28);
            this.itUndo.Text = "Undo";
            this.itUndo.Click += new System.EventHandler(this.itUndo_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 31);
            // 
            // itDong
            // 
            this.itDong.Image = ((System.Drawing.Image)(resources.GetObject("itDong.Image")));
            this.itDong.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.itDong.Name = "itDong";
            this.itDong.Size = new System.Drawing.Size(66, 28);
            this.itDong.Text = "Đóng";
            this.itDong.Click += new System.EventHandler(this.itDong_Click);
            // 
            // frmRights
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(546, 548);
            this.Controls.Add(this.toolMain);
            this.Controls.Add(this.treeMenus);
            this.Controls.Add(this.cmbGroup);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.Name = "frmRights";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Phân quyền sử dụng";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmRights_FormClosed);
            this.Load += new System.EventHandler(this.frmRights_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cmbGroup)).EndInit();
            this.toolMain.ResumeLayout(false);
            this.toolMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private Infragistics.Win.UltraWinEditors.UltraComboEditor cmbGroup;
        private System.Windows.Forms.TreeView treeMenus;
        private System.Windows.Forms.ToolStrip toolMain;
        private System.Windows.Forms.ToolStripButton itSave;
        private System.Windows.Forms.ToolStripButton itUndo;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton itDong;
    }
}