namespace PSC_ERP
{
    partial class frmTimKhachHang
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
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand1 = new Infragistics.Win.UltraWinGrid.UltraGridBand("DoiTuongAll", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn1 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("MaLoaiDoiTuong");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn2 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("MaDoiTuong");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn3 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("MaTaiKhoan");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn4 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("MaQLDoiTuong");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn5 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("TenDoiTuong");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn6 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("MaSoThue");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn7 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("DiaChi");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn8 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Check");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn9 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("DaCo");
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTimKhachHang));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.grdu_DSKhachHang = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.DSKhachHang_BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.lbl_NhanVien = new System.Windows.Forms.Label();
            this.btn_Tim = new System.Windows.Forms.Button();
            this.gbx_ThongTinNhanVien = new System.Windows.Forms.GroupBox();
            this.txtu_DieuKienTim = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.tlsMain = new System.Windows.Forms.ToolStrip();
            this.tlslblThem = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tlslblUndo = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdu_DSKhachHang)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DSKhachHang_BindingSource)).BeginInit();
            this.gbx_ThongTinNhanVien.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtu_DieuKienTim)).BeginInit();
            this.tlsMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox1.Controls.Add(this.grdu_DSKhachHang);
            this.groupBox1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(5, 96);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(726, 450);
            this.groupBox1.TabIndex = 36;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông Tin";
            // 
            // grdu_DSKhachHang
            // 
            this.grdu_DSKhachHang.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grdu_DSKhachHang.DataSource = this.DSKhachHang_BindingSource;
            appearance3.BackColor = System.Drawing.Color.White;
            appearance3.FontData.BoldAsString = "False";
            this.grdu_DSKhachHang.DisplayLayout.Appearance = appearance3;
            ultraGridColumn1.Header.VisiblePosition = 0;
            ultraGridColumn2.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            ultraGridColumn2.Header.VisiblePosition = 5;
            ultraGridColumn3.Header.VisiblePosition = 3;
            ultraGridColumn4.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            ultraGridColumn4.Header.VisiblePosition = 4;
            ultraGridColumn5.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            ultraGridColumn5.Header.VisiblePosition = 1;
            ultraGridColumn6.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            ultraGridColumn6.Header.VisiblePosition = 2;
            ultraGridColumn7.Header.VisiblePosition = 6;
            ultraGridColumn8.Header.VisiblePosition = 7;
            ultraGridColumn9.Header.VisiblePosition = 8;
            ultraGridBand1.Columns.AddRange(new object[] {
            ultraGridColumn1,
            ultraGridColumn2,
            ultraGridColumn3,
            ultraGridColumn4,
            ultraGridColumn5,
            ultraGridColumn6,
            ultraGridColumn7,
            ultraGridColumn8,
            ultraGridColumn9});
            this.grdu_DSKhachHang.DisplayLayout.BandsSerializer.Add(ultraGridBand1);
            this.grdu_DSKhachHang.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            this.grdu_DSKhachHang.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.Yes;
            this.grdu_DSKhachHang.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.True;
            this.grdu_DSKhachHang.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains;
            this.grdu_DSKhachHang.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow;
            appearance4.BackColor = System.Drawing.Color.SteelBlue;
            this.grdu_DSKhachHang.DisplayLayout.Override.HeaderAppearance = appearance4;
            this.grdu_DSKhachHang.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand;
            this.grdu_DSKhachHang.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdu_DSKhachHang.Location = new System.Drawing.Point(6, 20);
            this.grdu_DSKhachHang.Name = "grdu_DSKhachHang";
            this.grdu_DSKhachHang.Size = new System.Drawing.Size(714, 429);
            this.grdu_DSKhachHang.TabIndex = 28;
            this.grdu_DSKhachHang.DoubleClickRow += new Infragistics.Win.UltraWinGrid.DoubleClickRowEventHandler(this.grdu_DSKhachHang_DoubleClickRow);
            this.grdu_DSKhachHang.KeyDown += new System.Windows.Forms.KeyEventHandler(this.grdu_DSKhachHang_KeyDown);
            this.grdu_DSKhachHang.DoubleClick += new System.EventHandler(this.grdu_DSKhachHang_DoubleClick);
            this.grdu_DSKhachHang.InitializeLayout += new Infragistics.Win.UltraWinGrid.InitializeLayoutEventHandler(this.grdu_DSKhachHang_InitializeLayout);
            // 
            // DSKhachHang_BindingSource
            // 
            this.DSKhachHang_BindingSource.AllowNew = false;
            this.DSKhachHang_BindingSource.DataSource = typeof(ERP_Library.DoiTuongAllList);
            this.DSKhachHang_BindingSource.CurrentChanged += new System.EventHandler(this.DSKhachHang_BindingSource_CurrentChanged);
            // 
            // lbl_NhanVien
            // 
            this.lbl_NhanVien.AutoSize = true;
            this.lbl_NhanVien.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_NhanVien.Location = new System.Drawing.Point(27, 23);
            this.lbl_NhanVien.Name = "lbl_NhanVien";
            this.lbl_NhanVien.Size = new System.Drawing.Size(50, 14);
            this.lbl_NhanVien.TabIndex = 0;
            this.lbl_NhanVien.Text = "Tìm Theo";
            // 
            // btn_Tim
            // 
            this.btn_Tim.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Tim.Location = new System.Drawing.Point(658, 16);
            this.btn_Tim.Name = "btn_Tim";
            this.btn_Tim.Size = new System.Drawing.Size(62, 25);
            this.btn_Tim.TabIndex = 34;
            this.btn_Tim.Text = "Tìm";
            this.btn_Tim.UseVisualStyleBackColor = true;
            this.btn_Tim.Click += new System.EventHandler(this.btn_Tim_Click);
            // 
            // gbx_ThongTinNhanVien
            // 
            this.gbx_ThongTinNhanVien.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.gbx_ThongTinNhanVien.Controls.Add(this.btn_Tim);
            this.gbx_ThongTinNhanVien.Controls.Add(this.txtu_DieuKienTim);
            this.gbx_ThongTinNhanVien.Controls.Add(this.lbl_NhanVien);
            this.gbx_ThongTinNhanVien.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbx_ThongTinNhanVien.Location = new System.Drawing.Point(5, 40);
            this.gbx_ThongTinNhanVien.Name = "gbx_ThongTinNhanVien";
            this.gbx_ThongTinNhanVien.Size = new System.Drawing.Size(726, 53);
            this.gbx_ThongTinNhanVien.TabIndex = 35;
            this.gbx_ThongTinNhanVien.TabStop = false;
            this.gbx_ThongTinNhanVien.Text = "Thông Tin";
            // 
            // txtu_DieuKienTim
            // 
            this.txtu_DieuKienTim.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007;
            this.txtu_DieuKienTim.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtu_DieuKienTim.Location = new System.Drawing.Point(85, 20);
            this.txtu_DieuKienTim.Name = "txtu_DieuKienTim";
            this.txtu_DieuKienTim.Size = new System.Drawing.Size(549, 21);
            this.txtu_DieuKienTim.TabIndex = 33;
            this.txtu_DieuKienTim.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtu_DieuKienTim_KeyDown);
            // 
            // tlsMain
            // 
            this.tlsMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tlslblThem,
            this.toolStripSeparator1,
            this.tlslblUndo,
            this.toolStripSeparator4});
            this.tlsMain.Location = new System.Drawing.Point(0, 0);
            this.tlsMain.Name = "tlsMain";
            this.tlsMain.Size = new System.Drawing.Size(742, 25);
            this.tlsMain.TabIndex = 45;
            this.tlsMain.Text = "toolStrip1";
            // 
            // tlslblThem
            // 
            this.tlslblThem.Image = ((System.Drawing.Image)(resources.GetObject("tlslblThem.Image")));
            this.tlslblThem.Name = "tlslblThem";
            this.tlslblThem.Size = new System.Drawing.Size(58, 22);
            this.tlslblThem.Text = "&Thêm";
            this.tlslblThem.Click += new System.EventHandler(this.tlslblThem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // tlslblUndo
            // 
            this.tlslblUndo.Image = ((System.Drawing.Image)(resources.GetObject("tlslblUndo.Image")));
            this.tlslblUndo.Name = "tlslblUndo";
            this.tlslblUndo.Size = new System.Drawing.Size(56, 22);
            this.tlslblUndo.Text = "&Undo";
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // frmTimKhachHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(742, 549);
            this.Controls.Add(this.tlsMain);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gbx_ThongTinNhanVien);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmTimKhachHang";
            this.Text = "Tìm Khách Hàng";
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdu_DSKhachHang)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DSKhachHang_BindingSource)).EndInit();
            this.gbx_ThongTinNhanVien.ResumeLayout(false);
            this.gbx_ThongTinNhanVien.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtu_DieuKienTim)).EndInit();
            this.tlsMain.ResumeLayout(false);
            this.tlsMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private Infragistics.Win.UltraWinGrid.UltraGrid grdu_DSKhachHang;
        private System.Windows.Forms.BindingSource DSKhachHang_BindingSource;
        private System.Windows.Forms.Label lbl_NhanVien;
        private System.Windows.Forms.Button btn_Tim;
        private System.Windows.Forms.GroupBox gbx_ThongTinNhanVien;
        private Infragistics.Win.UltraWinEditors.UltraTextEditor txtu_DieuKienTim;
        private System.Windows.Forms.ToolStrip tlsMain;
        private System.Windows.Forms.ToolStripButton tlslblThem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tlslblUndo;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
    }
}