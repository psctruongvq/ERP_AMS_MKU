namespace PSC_ERP
{
    partial class frmBaoCaoDeNghiChuyenKhoan
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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Báo Cáo Đề Nghị Chuyển Khoản");
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.ValueListItem valueListItem1 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem2 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem3 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand1 = new Infragistics.Win.UltraWinGrid.UltraGridBand("ChiTietGiayXacNhan", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn41 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("MaChiTietGiayXacNhan", -1, null, 0, Infragistics.Win.UltraWinGrid.SortIndicator.Ascending, false);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn42 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("MaGiayXacNhan", -1, null, 1, Infragistics.Win.UltraWinGrid.SortIndicator.Ascending, false);
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn43 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("TenGiayXacNhan", -1, null, 2, Infragistics.Win.UltraWinGrid.SortIndicator.Ascending, false);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn44 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("MaBoPhanDen", -1, null, 3, Infragistics.Win.UltraWinGrid.SortIndicator.Ascending, false);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn45 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("TenBoPhanDen", -1, null, 4, Infragistics.Win.UltraWinGrid.SortIndicator.Ascending, false);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn46 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("SoTien", -1, null, 5, Infragistics.Win.UltraWinGrid.SortIndicator.Ascending, false);
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn47 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("SoTienConLai");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn48 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("NgayHoanTat", -1, null, 6, Infragistics.Win.UltraWinGrid.SortIndicator.Ascending, false);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn49 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("HoanTat", -1, null, 7, Infragistics.Win.UltraWinGrid.SortIndicator.Ascending, false);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn50 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("GhiChu", -1, null, 8, Infragistics.Win.UltraWinGrid.SortIndicator.Ascending, false);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn51 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("MaBoPhanDi", -1, null, 9, Infragistics.Win.UltraWinGrid.SortIndicator.Ascending, false);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn52 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("TenBoPhanDi", -1, null, 10, Infragistics.Win.UltraWinGrid.SortIndicator.Ascending, false);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn53 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ChiTietGiayXacNhan_NhanVienList");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn54 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("NgayLap");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn55 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("DuocNhapHo");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn56 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("KinhPhiBan");
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand2 = new Infragistics.Win.UltraWinGrid.UltraGridBand("ChiTietGiayXacNhan_NhanVienList", 0);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn57 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("MaChiTiet");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn58 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("MaNhanVien");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn59 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("SoTien");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn60 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("MaChiTietGiayXacNhan");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn61 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("GhiChu");
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.ValueListItem valueListItem4 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem5 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem6 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.ValueListItem valueListItem7 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem8 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem9 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem10 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand3 = new Infragistics.Win.UltraWinGrid.UltraGridBand("ChuongTrinh", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn62 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("MaChuongTrinh");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn63 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("MaChuongTrinhCha");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn64 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("MaPhanCap");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn65 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("MaQL");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn66 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("TenChuongTrinh");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn67 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("NgaySanXuat");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn68 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("NgayKetThuc");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn69 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("MaNguoiLap");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn70 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("NgayLap");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn71 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("TenChuongTrinhCha");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn72 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("MaNguon");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn73 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("TenNguon");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn74 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("HoanTat");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn75 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("DungChung");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn76 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("MaCongTy");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn77 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("PhanTramThueTNCN");
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand4 = new Infragistics.Win.UltraWinGrid.UltraGridBand("BoPhan", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn78 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Chon");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn79 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("MaBoPhan");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn80 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("MaBoPhanQL");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn81 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("TenBoPhan");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn82 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("NgayTao");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn83 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("MaBoPhanCha");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn84 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("MaLoaiBoPhan");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn85 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("MaCongTy");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn86 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("TaiKhoanKHHM");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn87 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("KhongTinhLuong");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn88 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("KhauHaoHaoMon");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn89 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("MaPhanCap");
            Infragistics.Win.ValueListItem valueListItem11 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem12 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem13 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem14 = new Infragistics.Win.ValueListItem();
            this.treeReport = new System.Windows.Forms.TreeView();
            this.pnlDieuKien = new System.Windows.Forms.Panel();
            this.gbChiTiet = new System.Windows.Forms.GroupBox();
            this.cbDinhMuc = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbNhanVien = new PSC_ERP.ComboboxNhanVien();
            this.label9 = new System.Windows.Forms.Label();
            this.cbChiTietGiayXacNhan = new Infragistics.Win.UltraWinGrid.UltraCombo();
            this.bindingSource1_ChiTietGiayXacNhan = new System.Windows.Forms.BindingSource(this.components);
            this.label11 = new System.Windows.Forms.Label();
            this.cbNhapHo = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.label10 = new System.Windows.Forms.Label();
            this.cmbLoaiNV = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.lblPhanLoai = new System.Windows.Forms.Label();
            this.lbl_ChiNhanh = new System.Windows.Forms.Label();
            this.cmbu_ChuongTrinh = new Infragistics.Win.UltraWinGrid.UltraCombo();
            this.bindingSource1_ChuongTrinh = new System.Windows.Forms.BindingSource(this.components);
            this.lblNganHang = new System.Windows.Forms.Label();
            this.cmbu_Bophan = new Infragistics.Win.UltraWinGrid.UltraCombo();
            this.BindS_BoPhan = new System.Windows.Forms.BindingSource(this.components);
            this.label8 = new System.Windows.Forms.Label();
            this.cmbNganHang = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dateTimePicker_DenNgay = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.dateTimePicker_TuNgay = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.grpNguoiKy = new Infragistics.Win.Misc.UltraGroupBox();
            this.cmbPTDonVi = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbPTTaiChinh = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbNguoiLap = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.label4 = new System.Windows.Forms.Label();
            this.btnClose = new Infragistics.Win.Misc.UltraButton();
            this.btnReport = new Infragistics.Win.Misc.UltraButton();
            this.bindingSource2_nhanVien = new System.Windows.Forms.BindingSource(this.components);
            this.bindingSource1_LoaiNhanVien = new System.Windows.Forms.BindingSource(this.components);
            this.pnlDieuKien.SuspendLayout();
            this.gbChiTiet.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbDinhMuc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbChiTietGiayXacNhan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1_ChiTietGiayXacNhan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbNhapHo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbLoaiNV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbu_ChuongTrinh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1_ChuongTrinh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbu_Bophan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BindS_BoPhan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbNganHang)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grpNguoiKy)).BeginInit();
            this.grpNguoiKy.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbPTDonVi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbPTTaiChinh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbNguoiLap)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource2_nhanVien)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1_LoaiNhanVien)).BeginInit();
            this.SuspendLayout();
            // 
            // treeReport
            // 
            this.treeReport.Dock = System.Windows.Forms.DockStyle.Left;
            this.treeReport.FullRowSelect = true;
            this.treeReport.HideSelection = false;
            this.treeReport.Location = new System.Drawing.Point(0, 0);
            this.treeReport.Name = "treeReport";
            treeNode1.Name = "Node0";
            treeNode1.Text = "Báo Cáo Đề Nghị Chuyển Khoản";
            this.treeReport.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1});
            this.treeReport.Size = new System.Drawing.Size(301, 544);
            this.treeReport.TabIndex = 1;
            this.treeReport.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeReport_AfterSelect);
            // 
            // pnlDieuKien
            // 
            this.pnlDieuKien.Controls.Add(this.gbChiTiet);
            this.pnlDieuKien.Controls.Add(this.groupBox1);
            this.pnlDieuKien.Controls.Add(this.grpNguoiKy);
            this.pnlDieuKien.Controls.Add(this.btnClose);
            this.pnlDieuKien.Controls.Add(this.btnReport);
            this.pnlDieuKien.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDieuKien.Location = new System.Drawing.Point(301, 0);
            this.pnlDieuKien.Name = "pnlDieuKien";
            this.pnlDieuKien.Size = new System.Drawing.Size(380, 544);
            this.pnlDieuKien.TabIndex = 2;
            // 
            // gbChiTiet
            // 
            this.gbChiTiet.Controls.Add(this.cbDinhMuc);
            this.gbChiTiet.Controls.Add(this.label3);
            this.gbChiTiet.Controls.Add(this.cmbNhanVien);
            this.gbChiTiet.Controls.Add(this.label9);
            this.gbChiTiet.Controls.Add(this.cbChiTietGiayXacNhan);
            this.gbChiTiet.Controls.Add(this.label11);
            this.gbChiTiet.Controls.Add(this.cbNhapHo);
            this.gbChiTiet.Controls.Add(this.label10);
            this.gbChiTiet.Controls.Add(this.cmbLoaiNV);
            this.gbChiTiet.Controls.Add(this.lblPhanLoai);
            this.gbChiTiet.Controls.Add(this.lbl_ChiNhanh);
            this.gbChiTiet.Controls.Add(this.cmbu_ChuongTrinh);
            this.gbChiTiet.Controls.Add(this.lblNganHang);
            this.gbChiTiet.Controls.Add(this.cmbu_Bophan);
            this.gbChiTiet.Controls.Add(this.label8);
            this.gbChiTiet.Controls.Add(this.cmbNganHang);
            this.gbChiTiet.Location = new System.Drawing.Point(17, 104);
            this.gbChiTiet.Name = "gbChiTiet";
            this.gbChiTiet.Size = new System.Drawing.Size(326, 279);
            this.gbChiTiet.TabIndex = 77;
            this.gbChiTiet.TabStop = false;
            this.gbChiTiet.Text = "Điều Kiện Chi Tiết";
            // 
            // cbDinhMuc
            // 
            appearance1.BackColor = System.Drawing.SystemColors.Info;
            this.cbDinhMuc.Appearance = appearance1;
            this.cbDinhMuc.BackColor = System.Drawing.SystemColors.Info;
            this.cbDinhMuc.DisplayMember = "";
            this.cbDinhMuc.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007;
            this.cbDinhMuc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            valueListItem1.DataValue = -1;
            valueListItem1.DisplayText = "Tất Cả";
            valueListItem2.DataValue = 1;
            valueListItem2.DisplayText = "Ngoài ĐM";
            valueListItem3.DataValue = 0;
            valueListItem3.DisplayText = "Trong ĐM";
            this.cbDinhMuc.Items.AddRange(new Infragistics.Win.ValueListItem[] {
            valueListItem1,
            valueListItem2,
            valueListItem3});
            this.cbDinhMuc.Location = new System.Drawing.Point(96, 218);
            this.cbDinhMuc.Name = "cbDinhMuc";
            this.cbDinhMuc.Size = new System.Drawing.Size(172, 21);
            this.cbDinhMuc.TabIndex = 3;
            this.cbDinhMuc.ValueMember = "";
            this.cbDinhMuc.ValueChanged += new System.EventHandler(this.ultraComboEditor2_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(18, 219);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 66;
            this.label3.Text = "Định Mức";
            // 
            // cmbNhanVien
            // 
            this.cmbNhanVien.AutoSize = true;
            this.cmbNhanVien.Location = new System.Drawing.Point(96, 74);
            this.cmbNhanVien.Margin = new System.Windows.Forms.Padding(5);
            this.cmbNhanVien.Name = "cmbNhanVien";
            this.cmbNhanVien.Size = new System.Drawing.Size(172, 22);
            this.cmbNhanVien.TabIndex = 80;
            this.cmbNhanVien.Value = null;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(24, 74);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(57, 13);
            this.label9.TabIndex = 81;
            this.label9.Text = "Nhân Viên";
            // 
            // cbChiTietGiayXacNhan
            // 
            this.cbChiTietGiayXacNhan.DataSource = this.bindingSource1_ChiTietGiayXacNhan;
            ultraGridColumn41.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.True;
            ultraGridColumn41.Header.VisiblePosition = 3;
            ultraGridColumn41.Hidden = true;
            ultraGridColumn41.SortComparisonType = Infragistics.Win.UltraWinGrid.SortComparisonType.CaseInsensitive;
            ultraGridColumn42.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.True;
            appearance2.BackColor = System.Drawing.Color.PowderBlue;
            appearance2.BackColor2 = System.Drawing.SystemColors.GradientInactiveCaption;
            appearance2.FontData.BoldAsString = "True";
            appearance2.TextHAlignAsString = "Center";
            ultraGridColumn42.Header.Appearance = appearance2;
            ultraGridColumn42.Header.VisiblePosition = 5;
            ultraGridColumn42.Hidden = true;
            ultraGridColumn42.SortComparisonType = Infragistics.Win.UltraWinGrid.SortComparisonType.CaseInsensitive;
            ultraGridColumn43.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.True;
            ultraGridColumn43.Header.Caption = "Tên Giấy Xác Nhận";
            ultraGridColumn43.Header.VisiblePosition = 0;
            ultraGridColumn43.SortComparisonType = Infragistics.Win.UltraWinGrid.SortComparisonType.CaseInsensitive;
            ultraGridColumn44.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.True;
            ultraGridColumn44.Header.VisiblePosition = 6;
            ultraGridColumn44.Hidden = true;
            ultraGridColumn44.SortComparisonType = Infragistics.Win.UltraWinGrid.SortComparisonType.CaseInsensitive;
            ultraGridColumn45.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.True;
            ultraGridColumn45.Header.Caption = "Tên Bộ Phận Đến";
            ultraGridColumn45.Header.VisiblePosition = 4;
            ultraGridColumn45.SortComparisonType = Infragistics.Win.UltraWinGrid.SortComparisonType.CaseInsensitive;
            ultraGridColumn46.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.True;
            appearance3.TextHAlignAsString = "Right";
            ultraGridColumn46.CellAppearance = appearance3;
            ultraGridColumn46.Format = "#,###";
            appearance4.BackColor = System.Drawing.Color.PowderBlue;
            appearance4.BackColor2 = System.Drawing.SystemColors.GradientInactiveCaption;
            appearance4.FontData.BoldAsString = "True";
            appearance4.TextHAlignAsString = "Center";
            ultraGridColumn46.Header.Appearance = appearance4;
            ultraGridColumn46.Header.Caption = "Số Tiền";
            ultraGridColumn46.Header.VisiblePosition = 1;
            ultraGridColumn46.SortComparisonType = Infragistics.Win.UltraWinGrid.SortComparisonType.CaseInsensitive;
            ultraGridColumn47.Header.VisiblePosition = 7;
            ultraGridColumn48.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.True;
            ultraGridColumn48.Header.VisiblePosition = 8;
            ultraGridColumn48.Hidden = true;
            ultraGridColumn48.SortComparisonType = Infragistics.Win.UltraWinGrid.SortComparisonType.CaseInsensitive;
            ultraGridColumn49.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.True;
            ultraGridColumn49.Header.Caption = "Hoàn Tất";
            ultraGridColumn49.Header.VisiblePosition = 2;
            ultraGridColumn49.SortComparisonType = Infragistics.Win.UltraWinGrid.SortComparisonType.CaseInsensitive;
            ultraGridColumn50.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.True;
            ultraGridColumn50.Header.Caption = "Ghi Chú";
            ultraGridColumn50.Header.VisiblePosition = 9;
            ultraGridColumn50.SortComparisonType = Infragistics.Win.UltraWinGrid.SortComparisonType.CaseInsensitive;
            ultraGridColumn51.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.True;
            ultraGridColumn51.Header.VisiblePosition = 10;
            ultraGridColumn51.Hidden = true;
            ultraGridColumn51.SortComparisonType = Infragistics.Win.UltraWinGrid.SortComparisonType.CaseInsensitive;
            ultraGridColumn52.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.True;
            ultraGridColumn52.Header.Caption = "Tên Bộ Phận Gửi";
            ultraGridColumn52.Header.VisiblePosition = 11;
            ultraGridColumn52.SortComparisonType = Infragistics.Win.UltraWinGrid.SortComparisonType.CaseInsensitive;
            ultraGridColumn53.Header.VisiblePosition = 15;
            ultraGridColumn54.Header.VisiblePosition = 13;
            ultraGridColumn55.Header.Caption = "Được Nhập Hộ";
            ultraGridColumn55.Header.VisiblePosition = 12;
            ultraGridColumn56.Header.Caption = "Kinh Phí Ban";
            ultraGridColumn56.Header.VisiblePosition = 14;
            ultraGridColumn56.Hidden = true;
            ultraGridBand1.Columns.AddRange(new object[] {
            ultraGridColumn41,
            ultraGridColumn42,
            ultraGridColumn43,
            ultraGridColumn44,
            ultraGridColumn45,
            ultraGridColumn46,
            ultraGridColumn47,
            ultraGridColumn48,
            ultraGridColumn49,
            ultraGridColumn50,
            ultraGridColumn51,
            ultraGridColumn52,
            ultraGridColumn53,
            ultraGridColumn54,
            ultraGridColumn55,
            ultraGridColumn56});
            ultraGridColumn57.Header.VisiblePosition = 0;
            ultraGridColumn58.Header.VisiblePosition = 1;
            ultraGridColumn59.Header.VisiblePosition = 2;
            ultraGridColumn60.Header.VisiblePosition = 3;
            ultraGridColumn61.Header.VisiblePosition = 4;
            ultraGridBand2.Columns.AddRange(new object[] {
            ultraGridColumn57,
            ultraGridColumn58,
            ultraGridColumn59,
            ultraGridColumn60,
            ultraGridColumn61});
            this.cbChiTietGiayXacNhan.DisplayLayout.BandsSerializer.Add(ultraGridBand1);
            this.cbChiTietGiayXacNhan.DisplayLayout.BandsSerializer.Add(ultraGridBand2);
            this.cbChiTietGiayXacNhan.DisplayMember = "TenGiayXacNhan";
            this.cbChiTietGiayXacNhan.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007;
            this.cbChiTietGiayXacNhan.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbChiTietGiayXacNhan.Location = new System.Drawing.Point(96, 129);
            this.cbChiTietGiayXacNhan.Name = "cbChiTietGiayXacNhan";
            this.cbChiTietGiayXacNhan.Size = new System.Drawing.Size(172, 22);
            this.cbChiTietGiayXacNhan.TabIndex = 9;
            this.cbChiTietGiayXacNhan.ValueMember = "MaChiTietGiayXacNhan";
            this.cbChiTietGiayXacNhan.InitializeLayout += new Infragistics.Win.UltraWinGrid.InitializeLayoutEventHandler(this.cbChiTietGiayXacNhan_InitializeLayout);
            this.cbChiTietGiayXacNhan.ValueChanged += new System.EventHandler(this.cbChiTietGiayXacNhan_ValueChanged);
            // 
            // bindingSource1_ChiTietGiayXacNhan
            // 
            this.bindingSource1_ChiTietGiayXacNhan.DataSource = typeof(ERP_Library.ChiTietGiayXacNhanList);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(6, 132);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(79, 13);
            this.label11.TabIndex = 79;
            this.label11.Text = "Giấy Xác Nhận";
            // 
            // cbNhapHo
            // 
            appearance5.BackColor = System.Drawing.SystemColors.Info;
            this.cbNhapHo.Appearance = appearance5;
            this.cbNhapHo.BackColor = System.Drawing.SystemColors.Info;
            this.cbNhapHo.DisplayMember = "";
            this.cbNhapHo.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007;
            this.cbNhapHo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            valueListItem4.DataValue = -1;
            valueListItem4.DisplayText = "Tất Cả";
            valueListItem5.DataValue = 0;
            valueListItem5.DisplayText = "Không";
            valueListItem6.DataValue = 1;
            valueListItem6.DisplayText = "Có";
            this.cbNhapHo.Items.AddRange(new Infragistics.Win.ValueListItem[] {
            valueListItem4,
            valueListItem5,
            valueListItem6});
            this.cbNhapHo.Location = new System.Drawing.Point(96, 189);
            this.cbNhapHo.Name = "cbNhapHo";
            this.cbNhapHo.Size = new System.Drawing.Size(172, 21);
            this.cbNhapHo.TabIndex = 10;
            this.cbNhapHo.ValueMember = "";
            this.cbNhapHo.ValueChanged += new System.EventHandler(this.cbNhapHo_ValueChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(16, 195);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(48, 13);
            this.label10.TabIndex = 77;
            this.label10.Text = "Nhập hộ";
            // 
            // cmbLoaiNV
            // 
            appearance6.BackColor = System.Drawing.SystemColors.Info;
            this.cmbLoaiNV.Appearance = appearance6;
            this.cmbLoaiNV.BackColor = System.Drawing.SystemColors.Info;
            this.cmbLoaiNV.DisplayMember = "";
            this.cmbLoaiNV.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007;
            this.cmbLoaiNV.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            valueListItem7.DataValue = 0;
            valueListItem7.DisplayText = "Tất cả";
            valueListItem8.DataValue = 101;
            valueListItem8.DisplayText = "Biên chế và hợp đồng";
            valueListItem9.DataValue = 102;
            valueListItem9.DisplayText = "Hợp đồng vụ việc";
            valueListItem10.DataValue = 103;
            valueListItem10.DisplayText = "Lương khoán";
            this.cmbLoaiNV.Items.AddRange(new Infragistics.Win.ValueListItem[] {
            valueListItem7,
            valueListItem8,
            valueListItem9,
            valueListItem10});
            this.cmbLoaiNV.Location = new System.Drawing.Point(96, 19);
            this.cmbLoaiNV.Name = "cmbLoaiNV";
            this.cmbLoaiNV.Size = new System.Drawing.Size(172, 21);
            this.cmbLoaiNV.TabIndex = 5;
            this.cmbLoaiNV.ValueMember = "";
            // 
            // lblPhanLoai
            // 
            this.lblPhanLoai.AutoSize = true;
            this.lblPhanLoai.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPhanLoai.Location = new System.Drawing.Point(29, 21);
            this.lblPhanLoai.Name = "lblPhanLoai";
            this.lblPhanLoai.Size = new System.Drawing.Size(51, 13);
            this.lblPhanLoai.TabIndex = 75;
            this.lblPhanLoai.Text = "Phân loại";
            // 
            // lbl_ChiNhanh
            // 
            this.lbl_ChiNhanh.AutoSize = true;
            this.lbl_ChiNhanh.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_ChiNhanh.Location = new System.Drawing.Point(33, 50);
            this.lbl_ChiNhanh.Name = "lbl_ChiNhanh";
            this.lbl_ChiNhanh.Size = new System.Drawing.Size(47, 13);
            this.lbl_ChiNhanh.TabIndex = 63;
            this.lbl_ChiNhanh.Text = "Bộ phận";
            // 
            // cmbu_ChuongTrinh
            // 
            this.cmbu_ChuongTrinh.DataSource = this.bindingSource1_ChuongTrinh;
            ultraGridColumn62.Header.VisiblePosition = 0;
            ultraGridColumn62.Hidden = true;
            ultraGridColumn63.Header.VisiblePosition = 1;
            ultraGridColumn63.Hidden = true;
            ultraGridColumn64.Header.VisiblePosition = 2;
            ultraGridColumn65.Header.VisiblePosition = 3;
            ultraGridColumn65.Hidden = true;
            ultraGridColumn66.Header.Caption = "Tên Chương Trình";
            ultraGridColumn66.Header.VisiblePosition = 4;
            ultraGridColumn67.Header.Caption = "Ngày Sản Xuất";
            ultraGridColumn67.Header.VisiblePosition = 5;
            ultraGridColumn68.Header.VisiblePosition = 6;
            ultraGridColumn68.Hidden = true;
            ultraGridColumn69.Header.VisiblePosition = 7;
            ultraGridColumn69.Hidden = true;
            ultraGridColumn70.Header.Caption = "Ngày Lập";
            ultraGridColumn70.Header.VisiblePosition = 8;
            ultraGridColumn71.Header.VisiblePosition = 9;
            ultraGridColumn71.Hidden = true;
            ultraGridColumn72.Header.VisiblePosition = 10;
            ultraGridColumn72.Hidden = true;
            ultraGridColumn73.Header.Caption = "Tên Nguồn";
            ultraGridColumn73.Header.VisiblePosition = 11;
            ultraGridColumn74.Header.VisiblePosition = 12;
            ultraGridColumn75.Header.VisiblePosition = 13;
            ultraGridColumn76.Header.VisiblePosition = 14;
            ultraGridColumn77.Header.VisiblePosition = 15;
            ultraGridBand3.Columns.AddRange(new object[] {
            ultraGridColumn62,
            ultraGridColumn63,
            ultraGridColumn64,
            ultraGridColumn65,
            ultraGridColumn66,
            ultraGridColumn67,
            ultraGridColumn68,
            ultraGridColumn69,
            ultraGridColumn70,
            ultraGridColumn71,
            ultraGridColumn72,
            ultraGridColumn73,
            ultraGridColumn74,
            ultraGridColumn75,
            ultraGridColumn76,
            ultraGridColumn77});
            this.cmbu_ChuongTrinh.DisplayLayout.BandsSerializer.Add(ultraGridBand3);
            this.cmbu_ChuongTrinh.DisplayMember = "TenChuongTrinh";
            this.cmbu_ChuongTrinh.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007;
            this.cmbu_ChuongTrinh.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbu_ChuongTrinh.Location = new System.Drawing.Point(96, 160);
            this.cmbu_ChuongTrinh.Name = "cmbu_ChuongTrinh";
            this.cmbu_ChuongTrinh.Size = new System.Drawing.Size(172, 22);
            this.cmbu_ChuongTrinh.TabIndex = 9;
            this.cmbu_ChuongTrinh.ValueMember = "MaChuongTrinh";
            this.cmbu_ChuongTrinh.InitializeLayout += new Infragistics.Win.UltraWinGrid.InitializeLayoutEventHandler(this.cmbu_ChuongTrinh_InitializeLayout);
            this.cmbu_ChuongTrinh.ValueChanged += new System.EventHandler(this.cmbu_ChuongTrinh_ValueChanged);
            // 
            // bindingSource1_ChuongTrinh
            // 
            this.bindingSource1_ChuongTrinh.DataSource = typeof(ERP_Library.ChuongTrinhList);
            // 
            // lblNganHang
            // 
            this.lblNganHang.AutoSize = true;
            this.lblNganHang.Location = new System.Drawing.Point(20, 100);
            this.lblNganHang.Name = "lblNganHang";
            this.lblNganHang.Size = new System.Drawing.Size(60, 13);
            this.lblNganHang.TabIndex = 66;
            this.lblNganHang.Text = "Ngân hàng";
            // 
            // cmbu_Bophan
            // 
            appearance7.FontData.BoldAsString = "False";
            this.cmbu_Bophan.Appearance = appearance7;
            this.cmbu_Bophan.DataSource = this.BindS_BoPhan;
            ultraGridColumn78.Header.VisiblePosition = 0;
            ultraGridColumn79.Header.VisiblePosition = 1;
            ultraGridColumn79.Hidden = true;
            ultraGridColumn80.Header.Caption = "Mã QL";
            ultraGridColumn80.Header.VisiblePosition = 2;
            ultraGridColumn81.Header.Caption = "Tên Bộ Phận";
            ultraGridColumn81.Header.VisiblePosition = 3;
            ultraGridColumn81.Width = 250;
            ultraGridColumn82.Header.VisiblePosition = 4;
            ultraGridColumn82.Hidden = true;
            ultraGridColumn83.Header.VisiblePosition = 5;
            ultraGridColumn83.Hidden = true;
            ultraGridColumn84.Header.VisiblePosition = 6;
            ultraGridColumn84.Hidden = true;
            ultraGridColumn85.Header.VisiblePosition = 7;
            ultraGridColumn85.Hidden = true;
            ultraGridColumn86.Header.VisiblePosition = 9;
            ultraGridColumn87.Header.VisiblePosition = 8;
            ultraGridColumn87.Hidden = true;
            ultraGridColumn88.Header.VisiblePosition = 10;
            ultraGridColumn88.Hidden = true;
            ultraGridColumn89.Header.VisiblePosition = 11;
            ultraGridBand4.Columns.AddRange(new object[] {
            ultraGridColumn78,
            ultraGridColumn79,
            ultraGridColumn80,
            ultraGridColumn81,
            ultraGridColumn82,
            ultraGridColumn83,
            ultraGridColumn84,
            ultraGridColumn85,
            ultraGridColumn86,
            ultraGridColumn87,
            ultraGridColumn88,
            ultraGridColumn89});
            this.cmbu_Bophan.DisplayLayout.BandsSerializer.Add(ultraGridBand4);
            this.cmbu_Bophan.DisplayMember = "TenBoPhan";
            this.cmbu_Bophan.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007;
            this.cmbu_Bophan.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbu_Bophan.Location = new System.Drawing.Point(96, 46);
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
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(10, 162);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(71, 13);
            this.label8.TabIndex = 72;
            this.label8.Text = "Chương Trình";
            // 
            // cmbNganHang
            // 
            this.cmbNganHang.DisplayMember = "";
            this.cmbNganHang.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007;
            this.cmbNganHang.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            valueListItem11.DataValue = 0;
            valueListItem11.DisplayText = "Tất cả";
            this.cmbNganHang.Items.AddRange(new Infragistics.Win.ValueListItem[] {
            valueListItem11});
            this.cmbNganHang.Location = new System.Drawing.Point(96, 100);
            this.cmbNganHang.Name = "cmbNganHang";
            this.cmbNganHang.Size = new System.Drawing.Size(172, 21);
            this.cmbNganHang.TabIndex = 6;
            this.cmbNganHang.ValueMember = "";
            this.cmbNganHang.ValueChanged += new System.EventHandler(this.cmbNganHang_ValueChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dateTimePicker_DenNgay);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.dateTimePicker_TuNgay);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(17, 11);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(326, 87);
            this.groupBox1.TabIndex = 21;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Điều Kiện";
            // 
            // dateTimePicker_DenNgay
            // 
            this.dateTimePicker_DenNgay.CustomFormat = "dd/MM/yyyy";
            this.dateTimePicker_DenNgay.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker_DenNgay.Location = new System.Drawing.Point(96, 53);
            this.dateTimePicker_DenNgay.Name = "dateTimePicker_DenNgay";
            this.dateTimePicker_DenNgay.Size = new System.Drawing.Size(172, 20);
            this.dateTimePicker_DenNgay.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 13);
            this.label1.TabIndex = 19;
            this.label1.Text = "Từ Ngày";
            // 
            // dateTimePicker_TuNgay
            // 
            this.dateTimePicker_TuNgay.CustomFormat = "dd/MM/yyyy";
            this.dateTimePicker_TuNgay.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker_TuNgay.Location = new System.Drawing.Point(96, 22);
            this.dateTimePicker_TuNgay.Name = "dateTimePicker_TuNgay";
            this.dateTimePicker_TuNgay.Size = new System.Drawing.Size(172, 20);
            this.dateTimePicker_TuNgay.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 20;
            this.label2.Text = "Đến Ngày";
            // 
            // grpNguoiKy
            // 
            this.grpNguoiKy.Controls.Add(this.cmbPTDonVi);
            this.grpNguoiKy.Controls.Add(this.label6);
            this.grpNguoiKy.Controls.Add(this.cmbPTTaiChinh);
            this.grpNguoiKy.Controls.Add(this.label5);
            this.grpNguoiKy.Controls.Add(this.cmbNguoiLap);
            this.grpNguoiKy.Controls.Add(this.label4);
            this.grpNguoiKy.Location = new System.Drawing.Point(17, 389);
            this.grpNguoiKy.Name = "grpNguoiKy";
            this.grpNguoiKy.Size = new System.Drawing.Size(326, 106);
            this.grpNguoiKy.TabIndex = 78;
            this.grpNguoiKy.Text = "Người ký tên";
            // 
            // cmbPTDonVi
            // 
            this.cmbPTDonVi.DisplayMember = "";
            this.cmbPTDonVi.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007;
            this.cmbPTDonVi.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            valueListItem12.DisplayText = " ";
            this.cmbPTDonVi.Items.AddRange(new Infragistics.Win.ValueListItem[] {
            valueListItem12});
            this.cmbPTDonVi.Location = new System.Drawing.Point(96, 46);
            this.cmbPTDonVi.Name = "cmbPTDonVi";
            this.cmbPTDonVi.Size = new System.Drawing.Size(172, 21);
            this.cmbPTDonVi.TabIndex = 12;
            this.cmbPTDonVi.ValueMember = "";
            this.cmbPTDonVi.ValueChanged += new System.EventHandler(this.cmbPTDonVi_ValueChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(24, 54);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(54, 13);
            this.label6.TabIndex = 4;
            this.label6.Text = "PT đơn vị";
            // 
            // cmbPTTaiChinh
            // 
            this.cmbPTTaiChinh.DisplayMember = "";
            this.cmbPTTaiChinh.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007;
            this.cmbPTTaiChinh.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            valueListItem13.DisplayText = " ";
            this.cmbPTTaiChinh.Items.AddRange(new Infragistics.Win.ValueListItem[] {
            valueListItem13});
            this.cmbPTTaiChinh.Location = new System.Drawing.Point(96, 73);
            this.cmbPTTaiChinh.Name = "cmbPTTaiChinh";
            this.cmbPTTaiChinh.Size = new System.Drawing.Size(172, 21);
            this.cmbPTTaiChinh.TabIndex = 13;
            this.cmbPTTaiChinh.ValueMember = "";
            this.cmbPTTaiChinh.ValueChanged += new System.EventHandler(this.cmbPTTaiChinh_ValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 81);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "BPT Bộ phận";
            // 
            // cmbNguoiLap
            // 
            this.cmbNguoiLap.DisplayMember = "";
            this.cmbNguoiLap.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007;
            this.cmbNguoiLap.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            valueListItem14.DisplayText = " ";
            this.cmbNguoiLap.Items.AddRange(new Infragistics.Win.ValueListItem[] {
            valueListItem14});
            this.cmbNguoiLap.Location = new System.Drawing.Point(96, 19);
            this.cmbNguoiLap.Name = "cmbNguoiLap";
            this.cmbNguoiLap.Size = new System.Drawing.Size(172, 21);
            this.cmbNguoiLap.TabIndex = 11;
            this.cmbNguoiLap.ValueMember = "";
            this.cmbNguoiLap.ValueChanged += new System.EventHandler(this.cmbNguoiLap_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(26, 27);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Người lập";
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnClose.Location = new System.Drawing.Point(215, 498);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(91, 32);
            this.btnClose.TabIndex = 15;
            this.btnClose.Text = "Đóng";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnReport
            // 
            this.btnReport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnReport.Location = new System.Drawing.Point(110, 498);
            this.btnReport.Name = "btnReport";
            this.btnReport.Size = new System.Drawing.Size(91, 32);
            this.btnReport.TabIndex = 14;
            this.btnReport.Text = "Báo cáo";
            this.btnReport.Click += new System.EventHandler(this.btnReport_Click);
            // 
            // bindingSource2_nhanVien
            // 
            this.bindingSource2_nhanVien.DataSource = typeof(ERP_Library.TTNhanVienRutGonList);
            // 
            // bindingSource1_LoaiNhanVien
            // 
            this.bindingSource1_LoaiNhanVien.DataSource = typeof(ERP_Library.LoaiNhanVienList);
            // 
            // frmBaoCaoDeNghiChuyenKhoan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(681, 544);
            this.Controls.Add(this.pnlDieuKien);
            this.Controls.Add(this.treeReport);
            this.Name = "frmBaoCaoDeNghiChuyenKhoan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Báo Cáo Thù Lao Đề Nghị Chuyển Khoản";
            this.Load += new System.EventHandler(this.frmBaoCaoThuLao_Load);
            this.pnlDieuKien.ResumeLayout(false);
            this.gbChiTiet.ResumeLayout(false);
            this.gbChiTiet.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbDinhMuc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbChiTietGiayXacNhan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1_ChiTietGiayXacNhan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbNhapHo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbLoaiNV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbu_ChuongTrinh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1_ChuongTrinh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbu_Bophan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BindS_BoPhan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbNganHang)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grpNguoiKy)).EndInit();
            this.grpNguoiKy.ResumeLayout(false);
            this.grpNguoiKy.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbPTDonVi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbPTTaiChinh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbNguoiLap)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource2_nhanVien)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1_LoaiNhanVien)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView treeReport;
        private System.Windows.Forms.Panel pnlDieuKien;
        private Infragistics.Win.Misc.UltraGroupBox grpNguoiKy;
        private Infragistics.Win.UltraWinEditors.UltraComboEditor cmbPTDonVi;
        private System.Windows.Forms.Label label6;
        private Infragistics.Win.UltraWinEditors.UltraComboEditor cmbPTTaiChinh;
        private System.Windows.Forms.Label label5;
        private Infragistics.Win.UltraWinEditors.UltraComboEditor cmbNguoiLap;
        private System.Windows.Forms.Label label4;
        private Infragistics.Win.Misc.UltraButton btnClose;
        private Infragistics.Win.Misc.UltraButton btnReport;
        private System.Windows.Forms.DateTimePicker dateTimePicker_DenNgay;
        private System.Windows.Forms.DateTimePicker dateTimePicker_TuNgay;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private Infragistics.Win.UltraWinGrid.UltraCombo cmbu_Bophan;
        private System.Windows.Forms.Label lbl_ChiNhanh;
        private Infragistics.Win.UltraWinEditors.UltraComboEditor cmbNganHang;
        private System.Windows.Forms.Label lblNganHang;
        private Infragistics.Win.UltraWinGrid.UltraCombo cmbu_ChuongTrinh;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.BindingSource bindingSource1_LoaiNhanVien;
        private System.Windows.Forms.BindingSource BindS_BoPhan;
        private System.Windows.Forms.BindingSource bindingSource1_ChuongTrinh;
        private System.Windows.Forms.BindingSource bindingSource2_nhanVien;
        private System.Windows.Forms.GroupBox gbChiTiet;
        private Infragistics.Win.UltraWinEditors.UltraComboEditor cbDinhMuc;
        private System.Windows.Forms.Label label3;
        private Infragistics.Win.UltraWinEditors.UltraComboEditor cbNhapHo;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private Infragistics.Win.UltraWinGrid.UltraCombo cbChiTietGiayXacNhan;
        private System.Windows.Forms.BindingSource bindingSource1_ChiTietGiayXacNhan;
        private ComboboxNhanVien cmbNhanVien;
        private System.Windows.Forms.Label label9;
        private Infragistics.Win.UltraWinEditors.UltraComboEditor cmbLoaiNV;
        private System.Windows.Forms.Label lblPhanLoai;

    }
}