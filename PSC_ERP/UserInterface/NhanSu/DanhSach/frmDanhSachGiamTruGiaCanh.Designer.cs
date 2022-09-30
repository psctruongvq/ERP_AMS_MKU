namespace PSC_ERP
{
    partial class frmDanhSachGiamTruGiaCanh
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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Chi Tiết Giảm Trừ Gia Cảnh");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Báo Cáo Mã Số Thuế");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Tình Hình Tăng Giảm Người Phụ Thuộc");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("Tình Hình Tăng Giảm Người Phụ Thuộc (Mẫu 2)");
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("Giảm Trừ Gia Cảnh", new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode3,
            treeNode4});
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand1 = new Infragistics.Win.UltraWinGrid.UltraGridBand("TTNhanVienRutGon", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn1 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("TenBoPhan");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn2 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("MaNhanVien");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn3 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("MaBoPhan");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn4 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("MaChucVu");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn5 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("TenNhanVien");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn6 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("MaQLNhanVien");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn7 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("LoaiNV");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn8 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("TenLoai");
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand2 = new Infragistics.Win.UltraWinGrid.UltraGridBand("BoPhan", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn9 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Chon");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn10 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("MaBoPhan");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn11 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("MaBoPhanQL");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn12 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("TenBoPhan");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn13 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("NgayTao");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn14 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("MaBoPhanCha");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn15 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("MaLoaiBoPhan");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn16 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("MaCongTy");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn17 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("KhongTinhLuong");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn18 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("KhauHaoHaoMon");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn19 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("MaPhanCap");
            this.treeReport = new System.Windows.Forms.TreeView();
            this.pnlDieuKien = new System.Windows.Forms.Panel();
            this.cmbKyLuong = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.lblKyLuong = new System.Windows.Forms.Label();
            this.ultraCombo1 = new Infragistics.Win.UltraWinGrid.UltraCombo();
            this.bindingSource2_nhanVien = new System.Windows.Forms.BindingSource(this.components);
            this.label9 = new System.Windows.Forms.Label();
            this.lbl_ChiNhanh = new System.Windows.Forms.Label();
            this.btnClose = new Infragistics.Win.Misc.UltraButton();
            this.cmbu_Bophan = new Infragistics.Win.UltraWinGrid.UltraCombo();
            this.BindS_BoPhan = new System.Windows.Forms.BindingSource(this.components);
            this.btnReport = new Infragistics.Win.Misc.UltraButton();
            this.bindingSource1_ChiTietGiayXacNhan = new System.Windows.Forms.BindingSource(this.components);
            this.bindingSource1_ChuongTrinh = new System.Windows.Forms.BindingSource(this.components);
            this.bindingSource1_LoaiNhanVien = new System.Windows.Forms.BindingSource(this.components);
            this.cmb_TuKy = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.lblTuKy = new System.Windows.Forms.Label();
            this.pnlDieuKien.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbKyLuong)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraCombo1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource2_nhanVien)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbu_Bophan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BindS_BoPhan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1_ChiTietGiayXacNhan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1_ChuongTrinh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1_LoaiNhanVien)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmb_TuKy)).BeginInit();
            this.SuspendLayout();
            // 
            // treeReport
            // 
            this.treeReport.Dock = System.Windows.Forms.DockStyle.Left;
            this.treeReport.FullRowSelect = true;
            this.treeReport.HideSelection = false;
            this.treeReport.Location = new System.Drawing.Point(0, 0);
            this.treeReport.Name = "treeReport";
            treeNode1.Name = "Node1";
            treeNode1.Text = "Chi Tiết Giảm Trừ Gia Cảnh";
            treeNode2.Name = "Node_BaoCaoMaSoThue";
            treeNode2.Text = "Báo Cáo Mã Số Thuế";
            treeNode3.Name = "TinhHinhTangGiam";
            treeNode3.Text = "Tình Hình Tăng Giảm Người Phụ Thuộc";
            treeNode4.Name = "TinhHinhTangGiam_Mau2";
            treeNode4.Text = "Tình Hình Tăng Giảm Người Phụ Thuộc (Mẫu 2)";
            treeNode5.Name = "Node0";
            treeNode5.Text = "Giảm Trừ Gia Cảnh";
            this.treeReport.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode5});
            this.treeReport.Size = new System.Drawing.Size(301, 586);
            this.treeReport.TabIndex = 1;
            this.treeReport.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeReport_AfterSelect);
            // 
            // pnlDieuKien
            // 
            this.pnlDieuKien.Controls.Add(this.cmb_TuKy);
            this.pnlDieuKien.Controls.Add(this.lblTuKy);
            this.pnlDieuKien.Controls.Add(this.cmbKyLuong);
            this.pnlDieuKien.Controls.Add(this.lblKyLuong);
            this.pnlDieuKien.Controls.Add(this.ultraCombo1);
            this.pnlDieuKien.Controls.Add(this.label9);
            this.pnlDieuKien.Controls.Add(this.lbl_ChiNhanh);
            this.pnlDieuKien.Controls.Add(this.btnClose);
            this.pnlDieuKien.Controls.Add(this.cmbu_Bophan);
            this.pnlDieuKien.Controls.Add(this.btnReport);
            this.pnlDieuKien.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDieuKien.Location = new System.Drawing.Point(301, 0);
            this.pnlDieuKien.Name = "pnlDieuKien";
            this.pnlDieuKien.Size = new System.Drawing.Size(380, 586);
            this.pnlDieuKien.TabIndex = 2;
            // 
            // cmbKyLuong
            // 
            this.cmbKyLuong.DisplayMember = "TenKy";
            this.cmbKyLuong.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007;
            this.cmbKyLuong.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.cmbKyLuong.Location = new System.Drawing.Point(125, 43);
            this.cmbKyLuong.Name = "cmbKyLuong";
            this.cmbKyLuong.Size = new System.Drawing.Size(172, 21);
            this.cmbKyLuong.TabIndex = 77;
            this.cmbKyLuong.ValueMember = "MaKy";
            // 
            // lblKyLuong
            // 
            this.lblKyLuong.AutoSize = true;
            this.lblKyLuong.Location = new System.Drawing.Point(41, 46);
            this.lblKyLuong.Name = "lblKyLuong";
            this.lblKyLuong.Size = new System.Drawing.Size(68, 14);
            this.lblKyLuong.TabIndex = 76;
            this.lblKyLuong.Text = "Tháng lương";
            // 
            // ultraCombo1
            // 
            appearance6.FontData.BoldAsString = "False";
            this.ultraCombo1.Appearance = appearance6;
            this.ultraCombo1.CheckedListSettings.CheckStateMember = "";
            this.ultraCombo1.DataSource = this.bindingSource2_nhanVien;
            ultraGridColumn1.Header.VisiblePosition = 0;
            ultraGridColumn2.Header.VisiblePosition = 1;
            ultraGridColumn2.Hidden = true;
            ultraGridColumn3.Header.VisiblePosition = 2;
            ultraGridColumn3.Hidden = true;
            ultraGridColumn4.Header.VisiblePosition = 3;
            ultraGridColumn4.Hidden = true;
            ultraGridColumn5.Header.VisiblePosition = 4;
            ultraGridColumn5.Width = 200;
            ultraGridColumn6.Header.VisiblePosition = 5;
            ultraGridColumn6.Hidden = true;
            ultraGridColumn7.Header.VisiblePosition = 6;
            ultraGridColumn7.Hidden = true;
            ultraGridColumn8.Header.VisiblePosition = 7;
            ultraGridColumn8.Hidden = true;
            ultraGridBand1.Columns.AddRange(new object[] {
            ultraGridColumn1,
            ultraGridColumn2,
            ultraGridColumn3,
            ultraGridColumn4,
            ultraGridColumn5,
            ultraGridColumn6,
            ultraGridColumn7,
            ultraGridColumn8});
            this.ultraCombo1.DisplayLayout.BandsSerializer.Add(ultraGridBand1);
            this.ultraCombo1.DisplayMember = "TenNhanVien";
            this.ultraCombo1.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007;
            this.ultraCombo1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ultraCombo1.Location = new System.Drawing.Point(125, 106);
            this.ultraCombo1.Name = "ultraCombo1";
            this.ultraCombo1.Size = new System.Drawing.Size(172, 22);
            this.ultraCombo1.TabIndex = 75;
            this.ultraCombo1.ValueMember = "MaNhanVien";
            this.ultraCombo1.ValueChanged += new System.EventHandler(this.ultraCombo1_ValueChanged);
            // 
            // bindingSource2_nhanVien
            // 
            this.bindingSource2_nhanVien.DataSource = typeof(ERP_Library.TTNhanVienRutGonList);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(41, 110);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(57, 14);
            this.label9.TabIndex = 74;
            this.label9.Text = "Nhân Viên";
            // 
            // lbl_ChiNhanh
            // 
            this.lbl_ChiNhanh.AutoSize = true;
            this.lbl_ChiNhanh.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_ChiNhanh.Location = new System.Drawing.Point(41, 78);
            this.lbl_ChiNhanh.Name = "lbl_ChiNhanh";
            this.lbl_ChiNhanh.Size = new System.Drawing.Size(47, 14);
            this.lbl_ChiNhanh.TabIndex = 63;
            this.lbl_ChiNhanh.Text = "Bộ phận";
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnClose.Location = new System.Drawing.Point(206, 155);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(91, 34);
            this.btnClose.TabIndex = 15;
            this.btnClose.Text = "Đóng";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // cmbu_Bophan
            // 
            appearance1.FontData.BoldAsString = "False";
            this.cmbu_Bophan.Appearance = appearance1;
            this.cmbu_Bophan.CheckedListSettings.CheckStateMember = "";
            this.cmbu_Bophan.DataSource = this.BindS_BoPhan;
            ultraGridColumn9.Header.VisiblePosition = 0;
            ultraGridColumn10.Header.VisiblePosition = 1;
            ultraGridColumn10.Hidden = true;
            ultraGridColumn11.Header.Caption = "Mã QL";
            ultraGridColumn11.Header.VisiblePosition = 2;
            ultraGridColumn12.Header.Caption = "Tên Bộ Phận";
            ultraGridColumn12.Header.VisiblePosition = 3;
            ultraGridColumn12.Width = 250;
            ultraGridColumn13.Header.VisiblePosition = 4;
            ultraGridColumn13.Hidden = true;
            ultraGridColumn14.Header.VisiblePosition = 5;
            ultraGridColumn14.Hidden = true;
            ultraGridColumn15.Header.VisiblePosition = 6;
            ultraGridColumn15.Hidden = true;
            ultraGridColumn16.Header.VisiblePosition = 7;
            ultraGridColumn16.Hidden = true;
            ultraGridColumn17.Header.VisiblePosition = 8;
            ultraGridColumn17.Hidden = true;
            ultraGridColumn18.Header.VisiblePosition = 9;
            ultraGridColumn18.Hidden = true;
            ultraGridColumn19.Header.VisiblePosition = 10;
            ultraGridBand2.Columns.AddRange(new object[] {
            ultraGridColumn9,
            ultraGridColumn10,
            ultraGridColumn11,
            ultraGridColumn12,
            ultraGridColumn13,
            ultraGridColumn14,
            ultraGridColumn15,
            ultraGridColumn16,
            ultraGridColumn17,
            ultraGridColumn18,
            ultraGridColumn19});
            this.cmbu_Bophan.DisplayLayout.BandsSerializer.Add(ultraGridBand2);
            this.cmbu_Bophan.DisplayMember = "TenBoPhan";
            this.cmbu_Bophan.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007;
            this.cmbu_Bophan.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbu_Bophan.Location = new System.Drawing.Point(125, 74);
            this.cmbu_Bophan.Name = "cmbu_Bophan";
            this.cmbu_Bophan.Size = new System.Drawing.Size(172, 22);
            this.cmbu_Bophan.TabIndex = 4;
            this.cmbu_Bophan.ValueMember = "MaBoPhan";
            this.cmbu_Bophan.InitializeLayout += new Infragistics.Win.UltraWinGrid.InitializeLayoutEventHandler(this.cmbu_Bophan_InitializeLayout);
            this.cmbu_Bophan.ValueChanged += new System.EventHandler(this.cmbu_Bophan_ValueChanged);
            // 
            // BindS_BoPhan
            // 
            this.BindS_BoPhan.DataSource = typeof(ERP_Library.BoPhanList);
            // 
            // btnReport
            // 
            this.btnReport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnReport.Location = new System.Drawing.Point(101, 155);
            this.btnReport.Name = "btnReport";
            this.btnReport.Size = new System.Drawing.Size(91, 34);
            this.btnReport.TabIndex = 14;
            this.btnReport.Text = "Báo cáo";
            this.btnReport.Click += new System.EventHandler(this.btnReport_Click);
            // 
            // bindingSource1_ChiTietGiayXacNhan
            // 
            this.bindingSource1_ChiTietGiayXacNhan.DataSource = typeof(ERP_Library.ChiTietGiayXacNhanList);
            // 
            // bindingSource1_ChuongTrinh
            // 
            this.bindingSource1_ChuongTrinh.DataSource = typeof(ERP_Library.ChuongTrinhList);
            // 
            // bindingSource1_LoaiNhanVien
            // 
            this.bindingSource1_LoaiNhanVien.DataSource = typeof(ERP_Library.LoaiNhanVienList);
            // 
            // cmb_TuKy
            // 
            this.cmb_TuKy.DisplayMember = "TenKy";
            this.cmb_TuKy.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007;
            this.cmb_TuKy.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.cmb_TuKy.Location = new System.Drawing.Point(125, 12);
            this.cmb_TuKy.Name = "cmb_TuKy";
            this.cmb_TuKy.Size = new System.Drawing.Size(172, 21);
            this.cmb_TuKy.TabIndex = 79;
            this.cmb_TuKy.ValueMember = "MaKy";
            this.cmb_TuKy.Visible = false;
            // 
            // lblTuKy
            // 
            this.lblTuKy.AutoSize = true;
            this.lblTuKy.Location = new System.Drawing.Point(41, 15);
            this.lblTuKy.Name = "lblTuKy";
            this.lblTuKy.Size = new System.Drawing.Size(34, 14);
            this.lblTuKy.TabIndex = 78;
            this.lblTuKy.Text = "Từ kỳ";
            this.lblTuKy.Visible = false;
            // 
            // frmDanhSachGiamTruGiaCanh
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(681, 586);
            this.Controls.Add(this.pnlDieuKien);
            this.Controls.Add(this.treeReport);
            this.Name = "frmDanhSachGiamTruGiaCanh";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Báo Cáo Gia Cảnh";
            this.Load += new System.EventHandler(this.frmBaoCaoThuLao_Load);
            this.pnlDieuKien.ResumeLayout(false);
            this.pnlDieuKien.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbKyLuong)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraCombo1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource2_nhanVien)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbu_Bophan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BindS_BoPhan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1_ChiTietGiayXacNhan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1_ChuongTrinh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1_LoaiNhanVien)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmb_TuKy)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView treeReport;
        private System.Windows.Forms.Panel pnlDieuKien;
        private Infragistics.Win.Misc.UltraButton btnClose;
        private Infragistics.Win.Misc.UltraButton btnReport;
        private Infragistics.Win.UltraWinGrid.UltraCombo cmbu_Bophan;
        private System.Windows.Forms.Label lbl_ChiNhanh;
        private System.Windows.Forms.BindingSource bindingSource1_LoaiNhanVien;
        private System.Windows.Forms.BindingSource BindS_BoPhan;
        private System.Windows.Forms.BindingSource bindingSource1_ChuongTrinh;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.BindingSource bindingSource2_nhanVien;
        private System.Windows.Forms.BindingSource bindingSource1_ChiTietGiayXacNhan;
        private Infragistics.Win.UltraWinGrid.UltraCombo ultraCombo1;
        private Infragistics.Win.UltraWinEditors.UltraComboEditor cmbKyLuong;
        private System.Windows.Forms.Label lblKyLuong;
        private Infragistics.Win.UltraWinEditors.UltraComboEditor cmb_TuKy;
        private System.Windows.Forms.Label lblTuKy;

    }
}