namespace PSC_ERP
{
    partial class frmPhongBan
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPhongBan));
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand1 = new Infragistics.Win.UltraWinGrid.UltraGridBand("BoPhan", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn1 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Chon");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn2 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("MaBoPhan");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn3 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("MaBoPhanQL");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn4 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("TenBoPhan");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn5 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("NgayTao");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn6 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("MaBoPhanCha");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn7 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("MaLoaiBoPhan");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn8 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("MaCongTy");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn9 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("KhongTinhLuong");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn10 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("KhauHaoHaoMon");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn11 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("MaPhanCap");
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            this.tlsMain = new System.Windows.Forms.ToolStrip();
            this.tlslblLuu = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tlslblXoa = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tlslblUndo = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.tlslblTim = new System.Windows.Forms.ToolStripButton();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripSeparator();
            this.tlslblIn = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripSeparator();
            this.tlslblTroGiup = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.tlslblThoat = new System.Windows.Forms.ToolStripButton();
            this.grdu_PhongBan = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.PhongBan_bindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ChiNhanh_bindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ultraComboEditor1 = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.dtmu_NgayLap = new Infragistics.Win.UltraWinEditors.UltraDateTimeEditor();
            this.tlslblExportExcel = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tlsMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdu_PhongBan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PhongBan_bindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ChiNhanh_bindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraComboEditor1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtmu_NgayLap)).BeginInit();
            this.SuspendLayout();
            // 
            // tlsMain
            // 
            this.tlsMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tlslblLuu,
            this.toolStripSeparator2,
            this.tlslblXoa,
            this.toolStripSeparator3,
            this.tlslblUndo,
            this.toolStripSeparator4,
            this.tlslblTim,
            this.toolStripLabel1,
            this.tlslblExportExcel,
            this.toolStripSeparator1,
            this.tlslblIn,
            this.toolStripButton1,
            this.tlslblTroGiup,
            this.toolStripSeparator5,
            this.tlslblThoat});
            this.tlsMain.Location = new System.Drawing.Point(0, 0);
            this.tlsMain.Name = "tlsMain";
            this.tlsMain.Size = new System.Drawing.Size(883, 25);
            this.tlsMain.TabIndex = 41;
            this.tlsMain.Text = "toolStrip1";
            // 
            // tlslblLuu
            // 
            this.tlslblLuu.Image = ((System.Drawing.Image)(resources.GetObject("tlslblLuu.Image")));
            this.tlslblLuu.Name = "tlslblLuu";
            this.tlslblLuu.Size = new System.Drawing.Size(47, 22);
            this.tlslblLuu.Text = "Lưu";
            this.tlslblLuu.Click += new System.EventHandler(this.tlslblLuu_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // tlslblXoa
            // 
            this.tlslblXoa.Image = ((System.Drawing.Image)(resources.GetObject("tlslblXoa.Image")));
            this.tlslblXoa.Name = "tlslblXoa";
            this.tlslblXoa.Size = new System.Drawing.Size(47, 22);
            this.tlslblXoa.Text = "Xóa";
            this.tlslblXoa.Click += new System.EventHandler(this.tlslblXoa_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // tlslblUndo
            // 
            this.tlslblUndo.Image = ((System.Drawing.Image)(resources.GetObject("tlslblUndo.Image")));
            this.tlslblUndo.Name = "tlslblUndo";
            this.tlslblUndo.Size = new System.Drawing.Size(56, 22);
            this.tlslblUndo.Text = "Undo";
            this.tlslblUndo.Click += new System.EventHandler(this.tlslblUndo_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // tlslblTim
            // 
            this.tlslblTim.Image = ((System.Drawing.Image)(resources.GetObject("tlslblTim.Image")));
            this.tlslblTim.Name = "tlslblTim";
            this.tlslblTim.Size = new System.Drawing.Size(48, 22);
            this.tlslblTim.Text = "Tìm";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(6, 25);
            // 
            // tlslblIn
            // 
            this.tlslblIn.Image = ((System.Drawing.Image)(resources.GetObject("tlslblIn.Image")));
            this.tlslblIn.Name = "tlslblIn";
            this.tlslblIn.Size = new System.Drawing.Size(37, 22);
            this.tlslblIn.Text = "In";
            this.tlslblIn.Click += new System.EventHandler(this.tlslblIn_Click);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(6, 25);
            // 
            // tlslblTroGiup
            // 
            this.tlslblTroGiup.Image = ((System.Drawing.Image)(resources.GetObject("tlslblTroGiup.Image")));
            this.tlslblTroGiup.Name = "tlslblTroGiup";
            this.tlslblTroGiup.Size = new System.Drawing.Size(73, 22);
            this.tlslblTroGiup.Text = "Trợ Giúp";
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 25);
            // 
            // tlslblThoat
            // 
            this.tlslblThoat.Image = ((System.Drawing.Image)(resources.GetObject("tlslblThoat.Image")));
            this.tlslblThoat.Name = "tlslblThoat";
            this.tlslblThoat.Size = new System.Drawing.Size(58, 22);
            this.tlslblThoat.Text = "Thoát";
            this.tlslblThoat.Click += new System.EventHandler(this.tlslblThoat_Click);
            // 
            // grdu_PhongBan
            // 
            this.grdu_PhongBan.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grdu_PhongBan.DataSource = this.PhongBan_bindingSource;
            appearance1.BackColor = System.Drawing.Color.White;
            appearance1.FontData.BoldAsString = "False";
            this.grdu_PhongBan.DisplayLayout.Appearance = appearance1;
            ultraGridColumn1.Header.VisiblePosition = 0;
            ultraGridColumn2.Header.VisiblePosition = 1;
            ultraGridColumn3.Header.VisiblePosition = 2;
            ultraGridColumn4.Header.VisiblePosition = 3;
            ultraGridColumn5.Header.VisiblePosition = 4;
            ultraGridColumn6.Header.VisiblePosition = 5;
            ultraGridColumn7.Header.VisiblePosition = 6;
            ultraGridColumn8.Header.VisiblePosition = 7;
            ultraGridColumn9.Header.VisiblePosition = 8;
            ultraGridColumn10.Header.VisiblePosition = 9;
            ultraGridColumn11.Header.VisiblePosition = 10;
            ultraGridBand1.Columns.AddRange(new object[] {
            ultraGridColumn1,
            ultraGridColumn2,
            ultraGridColumn3,
            ultraGridColumn4,
            ultraGridColumn5,
            ultraGridColumn6,
            ultraGridColumn7,
            ultraGridColumn8,
            ultraGridColumn9,
            ultraGridColumn10,
            ultraGridColumn11});
            this.grdu_PhongBan.DisplayLayout.BandsSerializer.Add(ultraGridBand1);
            this.grdu_PhongBan.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            this.grdu_PhongBan.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.Yes;
            appearance2.BackColor = System.Drawing.Color.SteelBlue;
            this.grdu_PhongBan.DisplayLayout.Override.HeaderAppearance = appearance2;
            this.grdu_PhongBan.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand;
            this.grdu_PhongBan.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.grdu_PhongBan.Location = new System.Drawing.Point(0, 25);
            this.grdu_PhongBan.Name = "grdu_PhongBan";
            this.grdu_PhongBan.Size = new System.Drawing.Size(883, 596);
            this.grdu_PhongBan.TabIndex = 42;
            this.grdu_PhongBan.InitializeLayout += new Infragistics.Win.UltraWinGrid.InitializeLayoutEventHandler(this.grdPhongBan_InitializeLayout);
            this.grdu_PhongBan.KeyDown += new System.Windows.Forms.KeyEventHandler(this.grdu_PhongBan_KeyDown);
            this.grdu_PhongBan.Leave += new System.EventHandler(this.grdu_PhongBan_Leave);
            // 
            // PhongBan_bindingSource
            // 
            this.PhongBan_bindingSource.AllowNew = true;
            this.PhongBan_bindingSource.DataSource = typeof(ERP_Library.BoPhanList);
            // 
            // ChiNhanh_bindingSource
            // 
            this.ChiNhanh_bindingSource.AllowNew = true;
            this.ChiNhanh_bindingSource.DataSource = typeof(ERP_Library.CongTyList);
            // 
            // ultraComboEditor1
            // 
            this.ultraComboEditor1.DataSource = this.ChiNhanh_bindingSource;
            this.ultraComboEditor1.DisplayMember = "TenCongTy";
            this.ultraComboEditor1.Location = new System.Drawing.Point(269, 247);
            this.ultraComboEditor1.Name = "ultraComboEditor1";
            this.ultraComboEditor1.Size = new System.Drawing.Size(144, 21);
            this.ultraComboEditor1.TabIndex = 43;
            this.ultraComboEditor1.ValueMember = "MaCongTy";
            // 
            // dtmu_NgayLap
            // 
            this.dtmu_NgayLap.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.PhongBan_bindingSource, "NgayDangKi", true));
            this.dtmu_NgayLap.Location = new System.Drawing.Point(177, 247);
            this.dtmu_NgayLap.Name = "dtmu_NgayLap";
            this.dtmu_NgayLap.Size = new System.Drawing.Size(86, 21);
            this.dtmu_NgayLap.TabIndex = 44;
            // 
            // tlslblExportExcel
            // 
            this.tlslblExportExcel.Image = ((System.Drawing.Image)(resources.GetObject("tlslblExportExcel.Image")));
            this.tlslblExportExcel.Name = "tlslblExportExcel";
            this.tlslblExportExcel.Size = new System.Drawing.Size(80, 22);
            this.tlslblExportExcel.Text = "&Xuất Excel";
            this.tlslblExportExcel.Click += new System.EventHandler(this.tlslblExportExcel_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // frmPhongBan
            // 
            this.ClientSize = new System.Drawing.Size(883, 620);
            this.Controls.Add(this.grdu_PhongBan);
            this.Controls.Add(this.dtmu_NgayLap);
            this.Controls.Add(this.ultraComboEditor1);
            this.Controls.Add(this.tlsMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmPhongBan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Phòng Ban";
            this.tlsMain.ResumeLayout(false);
            this.tlsMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdu_PhongBan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PhongBan_bindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ChiNhanh_bindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraComboEditor1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtmu_NgayLap)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tlsMain;
        private System.Windows.Forms.ToolStripButton tlslblLuu;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton tlslblXoa;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton tlslblUndo;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton tlslblTim;
        private System.Windows.Forms.ToolStripSeparator toolStripLabel1;
        private System.Windows.Forms.ToolStripButton tlslblIn;
        private System.Windows.Forms.ToolStripSeparator toolStripButton1;
        private System.Windows.Forms.ToolStripButton tlslblTroGiup;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripButton tlslblThoat;
        private Infragistics.Win.UltraWinGrid.UltraGrid grdu_PhongBan;
        private System.Windows.Forms.BindingSource PhongBan_bindingSource;
        private System.Windows.Forms.BindingSource ChiNhanh_bindingSource;
        private Infragistics.Win.UltraWinEditors.UltraComboEditor ultraComboEditor1;
        private Infragistics.Win.UltraWinEditors.UltraDateTimeEditor dtmu_NgayLap;
        private System.Windows.Forms.ToolStripButton tlslblExportExcel;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
    }
}