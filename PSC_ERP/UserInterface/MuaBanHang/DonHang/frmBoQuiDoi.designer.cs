namespace PSC_ERP
{
    partial class frmBoQuiDoi
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
            this.components = new System.ComponentModel.Container();
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand1 = new Infragistics.Win.UltraWinGrid.UltraGridBand("DonViTinh", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn1 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("DienGiai");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn2 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("MaTinhTrang");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn3 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("MaDonViTinh");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn4 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("MaQuanLy");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn5 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("TenDonViTinh");
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand2 = new Infragistics.Win.UltraWinGrid.UltraGridBand("DonViTinh", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn6 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("DienGiai");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn7 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("MaTinhTrang");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn8 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("MaDonViTinh");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn9 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("MaQuanLy");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn10 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("TenDonViTinh");
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand3 = new Infragistics.Win.UltraWinGrid.UltraGridBand("QuyDoiDVT", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn11 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Quydoi12");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn12 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("MaDVT1");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn13 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("MaDVT2");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn14 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("MaQuyDoiChuan");
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBoQuiDoi));
            this.cmbu_DonViTinh = new Infragistics.Win.UltraWinGrid.UltraCombo();
            this.quiDoiDVTListbindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.donViTinhListbindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.cmbu_DonViCanQuiDoi = new Infragistics.Win.UltraWinGrid.UltraCombo();
            this.donViCanBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.grdu_BoQuiDoiDVT = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.tlsMain = new System.Windows.Forms.ToolStrip();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator9 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator10 = new System.Windows.Forms.ToolStripSeparator();
            this.tlslblUndo = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator11 = new System.Windows.Forms.ToolStripSeparator();
            this.tlslblIn = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tlslblTroGiup = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator12 = new System.Windows.Forms.ToolStripSeparator();
            this.tlslblThoat = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.cmbu_DonViTinh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.quiDoiDVTListbindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.donViTinhListbindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbu_DonViCanQuiDoi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.donViCanBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdu_BoQuiDoiDVT)).BeginInit();
            this.tlsMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmbu_DonViTinh
            // 
            this.cmbu_DonViTinh.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.cmbu_DonViTinh.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.quiDoiDVTListbindingSource, "MaDVT1", true));
            this.cmbu_DonViTinh.DataSource = this.donViTinhListbindingSource;
            ultraGridColumn1.Header.VisiblePosition = 0;
            ultraGridColumn2.Header.VisiblePosition = 1;
            ultraGridColumn3.Header.VisiblePosition = 2;
            ultraGridColumn4.Header.VisiblePosition = 3;
            ultraGridColumn5.Header.VisiblePosition = 4;
            ultraGridBand1.Columns.AddRange(new object[] {
            ultraGridColumn1,
            ultraGridColumn2,
            ultraGridColumn3,
            ultraGridColumn4,
            ultraGridColumn5});
            this.cmbu_DonViTinh.DisplayLayout.BandsSerializer.Add(ultraGridBand1);
            this.cmbu_DonViTinh.DisplayMember = "TenDonViTinh";
            this.cmbu_DonViTinh.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007;
            this.cmbu_DonViTinh.Location = new System.Drawing.Point(315, 360);
            this.cmbu_DonViTinh.Name = "cmbu_DonViTinh";
            this.cmbu_DonViTinh.Size = new System.Drawing.Size(87, 22);
            this.cmbu_DonViTinh.TabIndex = 3;
            this.cmbu_DonViTinh.Text = "DVT";
            this.cmbu_DonViTinh.ValueMember = "MaDonViTinh";
            this.cmbu_DonViTinh.InitializeLayout += new Infragistics.Win.UltraWinGrid.InitializeLayoutEventHandler(this.cmbu_DonViTinh_InitializeLayout);
            // 
            // quiDoiDVTListbindingSource
            // 
            this.quiDoiDVTListbindingSource.AllowNew = true;
            this.quiDoiDVTListbindingSource.DataSource = typeof(ERP_Library.QuyDoiDVTList);
            // 
            // donViTinhListbindingSource
            // 
            this.donViTinhListbindingSource.AllowNew = false;
            this.donViTinhListbindingSource.DataSource = typeof(ERP_Library.DonViTinhList);
            // 
            // cmbu_DonViCanQuiDoi
            // 
            this.cmbu_DonViCanQuiDoi.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.cmbu_DonViCanQuiDoi.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.quiDoiDVTListbindingSource, "MaDVT2", true));
            this.cmbu_DonViCanQuiDoi.DataSource = this.donViCanBindingSource;
            ultraGridColumn6.Header.VisiblePosition = 0;
            ultraGridColumn7.Header.VisiblePosition = 1;
            ultraGridColumn8.Header.VisiblePosition = 2;
            ultraGridColumn9.Header.VisiblePosition = 3;
            ultraGridColumn10.Header.VisiblePosition = 4;
            ultraGridBand2.Columns.AddRange(new object[] {
            ultraGridColumn6,
            ultraGridColumn7,
            ultraGridColumn8,
            ultraGridColumn9,
            ultraGridColumn10});
            this.cmbu_DonViCanQuiDoi.DisplayLayout.BandsSerializer.Add(ultraGridBand2);
            this.cmbu_DonViCanQuiDoi.DisplayMember = "TenDonViTinh";
            this.cmbu_DonViCanQuiDoi.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007;
            this.cmbu_DonViCanQuiDoi.Location = new System.Drawing.Point(408, 360);
            this.cmbu_DonViCanQuiDoi.Name = "cmbu_DonViCanQuiDoi";
            this.cmbu_DonViCanQuiDoi.Size = new System.Drawing.Size(87, 22);
            this.cmbu_DonViCanQuiDoi.TabIndex = 3;
            this.cmbu_DonViCanQuiDoi.Text = "DVC";
            this.cmbu_DonViCanQuiDoi.ValueMember = "MaDonViTinh";
            this.cmbu_DonViCanQuiDoi.AfterCloseUp += new System.EventHandler(this.cmbu_DonViCanQuiDoi_AfterCloseUp);
            this.cmbu_DonViCanQuiDoi.InitializeLayout += new Infragistics.Win.UltraWinGrid.InitializeLayoutEventHandler(this.cmbu_DonViCanQuiDoi_InitializeLayout);
            // 
            // donViCanBindingSource
            // 
            this.donViCanBindingSource.AllowNew = false;
            this.donViCanBindingSource.DataSource = typeof(ERP_Library.DonViTinhList);
            // 
            // grdu_BoQuiDoiDVT
            // 
            this.grdu_BoQuiDoiDVT.DataSource = this.quiDoiDVTListbindingSource;
            appearance2.FontData.BoldAsString = "False";
            this.grdu_BoQuiDoiDVT.DisplayLayout.Appearance = appearance2;
            ultraGridColumn11.Header.VisiblePosition = 0;
            ultraGridColumn11.Width = 118;
            ultraGridColumn12.Header.VisiblePosition = 1;
            ultraGridColumn12.Width = 102;
            ultraGridColumn13.Header.VisiblePosition = 2;
            ultraGridColumn13.Width = 98;
            ultraGridColumn14.Header.VisiblePosition = 3;
            ultraGridBand3.Columns.AddRange(new object[] {
            ultraGridColumn11,
            ultraGridColumn12,
            ultraGridColumn13,
            ultraGridColumn14});
            this.grdu_BoQuiDoiDVT.DisplayLayout.BandsSerializer.Add(ultraGridBand3);
            this.grdu_BoQuiDoiDVT.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            appearance7.BackColor = System.Drawing.Color.SteelBlue;
            this.grdu_BoQuiDoiDVT.DisplayLayout.Override.HeaderAppearance = appearance7;
            this.grdu_BoQuiDoiDVT.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand;
            this.grdu_BoQuiDoiDVT.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdu_BoQuiDoiDVT.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdu_BoQuiDoiDVT.Location = new System.Drawing.Point(0, 25);
            this.grdu_BoQuiDoiDVT.Name = "grdu_BoQuiDoiDVT";
            this.grdu_BoQuiDoiDVT.Size = new System.Drawing.Size(526, 379);
            this.grdu_BoQuiDoiDVT.TabIndex = 0;
            this.grdu_BoQuiDoiDVT.InitializeLayout += new Infragistics.Win.UltraWinGrid.InitializeLayoutEventHandler(this.grdu_BoQuiDoiDVT_InitializeLayout);
            this.grdu_BoQuiDoiDVT.KeyDown += new System.Windows.Forms.KeyEventHandler(this.grdu_BoQuiDoiDVT_KeyDown);
            this.grdu_BoQuiDoiDVT.AfterRowUpdate += new Infragistics.Win.UltraWinGrid.RowEventHandler(this.grdu_BoQuiDoiDVT_AfterRowUpdate);
            // 
            // tlsMain
            // 
            this.tlsMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton2,
            this.toolStripSeparator9,
            this.toolStripButton3,
            this.toolStripSeparator10,
            this.tlslblUndo,
            this.toolStripSeparator11,
            this.tlslblIn,
            this.toolStripSeparator1,
            this.tlslblTroGiup,
            this.toolStripSeparator12,
            this.tlslblThoat});
            this.tlsMain.Location = new System.Drawing.Point(0, 0);
            this.tlsMain.Name = "tlsMain";
            this.tlsMain.Size = new System.Drawing.Size(526, 25);
            this.tlsMain.TabIndex = 16;
            this.tlsMain.Text = "toolStrip1";
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(45, 22);
            this.toolStripButton2.Text = "&Lưu";
            this.toolStripButton2.ToolTipText = "Ctr+L";
            this.toolStripButton2.Click += new System.EventHandler(this.tlslbl_Luu_Click);
            // 
            // toolStripSeparator9
            // 
            this.toolStripSeparator9.Name = "toolStripSeparator9";
            this.toolStripSeparator9.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton3.Image")));
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(45, 22);
            this.toolStripButton3.Text = "&Xóa";
            this.toolStripButton3.ToolTipText = "Ctr+X";
            this.toolStripButton3.Click += new System.EventHandler(this.tlslbl_Xoa_Click);
            // 
            // toolStripSeparator10
            // 
            this.toolStripSeparator10.Name = "toolStripSeparator10";
            this.toolStripSeparator10.Size = new System.Drawing.Size(6, 25);
            // 
            // tlslblUndo
            // 
            this.tlslblUndo.Image = ((System.Drawing.Image)(resources.GetObject("tlslblUndo.Image")));
            this.tlslblUndo.Name = "tlslblUndo";
            this.tlslblUndo.Size = new System.Drawing.Size(52, 22);
            this.tlslblUndo.Text = "&Undo";
            this.tlslblUndo.ToolTipText = "Ctr+U";
            this.tlslblUndo.Click += new System.EventHandler(this.tlslbl_TroLai_Click);
            // 
            // toolStripSeparator11
            // 
            this.toolStripSeparator11.Name = "toolStripSeparator11";
            this.toolStripSeparator11.Size = new System.Drawing.Size(6, 25);
            // 
            // tlslblIn
            // 
            this.tlslblIn.Image = ((System.Drawing.Image)(resources.GetObject("tlslblIn.Image")));
            this.tlslblIn.Name = "tlslblIn";
            this.tlslblIn.Size = new System.Drawing.Size(37, 22);
            this.tlslblIn.Text = "&In";
            this.tlslblIn.ToolTipText = "Ctr+I";
            this.tlslblIn.Click += new System.EventHandler(this.tlslblIn_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // tlslblTroGiup
            // 
            this.tlslblTroGiup.Image = ((System.Drawing.Image)(resources.GetObject("tlslblTroGiup.Image")));
            this.tlslblTroGiup.Name = "tlslblTroGiup";
            this.tlslblTroGiup.Size = new System.Drawing.Size(67, 22);
            this.tlslblTroGiup.Text = "Trợ &Giúp";
            this.tlslblTroGiup.ToolTipText = "Ctr+G";
            this.tlslblTroGiup.Click += new System.EventHandler(this.tlslblTroGiup_Click);
            // 
            // toolStripSeparator12
            // 
            this.toolStripSeparator12.Name = "toolStripSeparator12";
            this.toolStripSeparator12.Size = new System.Drawing.Size(6, 25);
            // 
            // tlslblThoat
            // 
            this.tlslblThoat.Image = ((System.Drawing.Image)(resources.GetObject("tlslblThoat.Image")));
            this.tlslblThoat.Name = "tlslblThoat";
            this.tlslblThoat.Size = new System.Drawing.Size(55, 22);
            this.tlslblThoat.Text = "Th&oát";
            this.tlslblThoat.ToolTipText = "Ctr+O";
            this.tlslblThoat.Click += new System.EventHandler(this.tlslbl_Thoat_Click);
            // 
            // frmBoQuiDoi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(526, 404);
            this.Controls.Add(this.grdu_BoQuiDoiDVT);
            this.Controls.Add(this.cmbu_DonViTinh);
            this.Controls.Add(this.cmbu_DonViCanQuiDoi);
            this.Controls.Add(this.tlsMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "frmBoQuiDoi";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bộ Qui Đổi";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmBoQuiDoi_KeyDown);
            this.Leave += new System.EventHandler(this.frmBoQuiDoi_Leave);
            this.Load += new System.EventHandler(this.frmBoQuiDoi_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cmbu_DonViTinh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.quiDoiDVTListbindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.donViTinhListbindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbu_DonViCanQuiDoi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.donViCanBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdu_BoQuiDoiDVT)).EndInit();
            this.tlsMain.ResumeLayout(false);
            this.tlsMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Infragistics.Win.UltraWinGrid.UltraCombo cmbu_DonViTinh;
        private Infragistics.Win.UltraWinGrid.UltraCombo cmbu_DonViCanQuiDoi;
        private System.Windows.Forms.BindingSource donViTinhListbindingSource;
        private System.Windows.Forms.BindingSource quiDoiDVTListbindingSource;
        private Infragistics.Win.UltraWinGrid.UltraGrid grdu_BoQuiDoiDVT;
        private System.Windows.Forms.ToolStrip tlsMain;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator9;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator10;
        private System.Windows.Forms.ToolStripButton tlslblUndo;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator11;
        private System.Windows.Forms.ToolStripButton tlslblIn;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tlslblTroGiup;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator12;
        private System.Windows.Forms.ToolStripButton tlslblThoat;
        private System.Windows.Forms.BindingSource donViCanBindingSource;

    }
}