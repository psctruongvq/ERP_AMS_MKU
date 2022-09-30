namespace PSC_ERP
{
    partial class frmBaoCaoThuLao_DangPhi
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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Báo Cáo Tổng Hợp");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Báo Cáo Chi Tiết");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Báo Cáo Chi Tiết Nhân Viên");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("Báo Cáo Đảng Phí", new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode3});
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("Báo Cáo Tổng Hợp");
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("Báo Cáo Chi Tiết");
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("Báo Cáo Đảng Phí Điều Chỉnh", new System.Windows.Forms.TreeNode[] {
            treeNode5,
            treeNode6});
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("Báo Cáo Tổng Hợp");
            System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("Báo Cáo Chi Tiết");
            System.Windows.Forms.TreeNode treeNode10 = new System.Windows.Forms.TreeNode("Báo Cáo Tổng Hợp Sau Điều Chỉnh", new System.Windows.Forms.TreeNode[] {
            treeNode8,
            treeNode9});
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand1 = new Infragistics.Win.UltraWinGrid.UltraGridBand("BoPhan", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn1 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("MaBoPhan");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn2 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("MaBoPhanQL");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn3 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("TenBoPhan");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn4 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("NgayTao");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn5 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("MaBoPhanCha");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn6 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("MaLoaiBoPhan");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn7 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("MaCongTy");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn8 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("TangCaGianCa");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn9 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("SoGioTangCa");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn10 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("SoGioGianCa");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn11 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("KhongTinhLuong");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn12 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("KhauHaoHaoMon");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn13 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("MaPhanCap");
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand2 = new Infragistics.Win.UltraWinGrid.UltraGridBand("KyTinhLuong", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn14 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("MaKy");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn15 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("TenKy");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn16 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("NgayBatDau");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn17 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("NgayKetThuc");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn18 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Thang");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn19 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("KhoaSo");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn20 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Nam");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn21 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("SoNgayLVTT");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn22 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("SoCongTinhChuyenCan");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn23 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("DungChung");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn24 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("KhoaSoKy1");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn25 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("KhoaSoKy2");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn26 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("KhoaSoKy3");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn27 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("SoNgay");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn28 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("TruThueTNCN");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn29 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("NgayKhoaThuLao");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn30 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("MaKyChinh");
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand3 = new Infragistics.Win.UltraWinGrid.UltraGridBand("KyTinhLuong", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn31 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("MaKy");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn32 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("TenKy");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn33 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("NgayBatDau");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn34 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("NgayKetThuc");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn35 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Thang");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn36 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("KhoaSo");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn37 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Nam");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn38 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("SoNgayLVTT");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn39 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("SoCongTinhChuyenCan");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn40 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("DungChung");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn41 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("KhoaSoKy1");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn42 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("KhoaSoKy2");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn43 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("KhoaSoKy3");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn44 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("SoNgay");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn45 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("TruThueTNCN");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn46 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("NgayKhoaThuLao");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn47 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("MaKyChinh");
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand4 = new Infragistics.Win.UltraWinGrid.UltraGridBand("TTNhanVienRutGon", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn48 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("MaNhanVien");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn49 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("MaBoPhan");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn50 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("MaChucVu");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn51 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("TenNhanVien");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn52 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("MaQLNhanVien");
            Infragistics.Win.ValueListItem valueListItem1 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem2 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem3 = new Infragistics.Win.ValueListItem();
            this.treeReport = new System.Windows.Forms.TreeView();
            this.pnlDieuKien = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbu_Bophan = new Infragistics.Win.UltraWinGrid.UltraCombo();
            this.BindS_BoPhan = new System.Windows.Forms.BindingSource(this.components);
            this.label9 = new System.Windows.Forms.Label();
            this.cbKyTinhLuong = new Infragistics.Win.UltraWinGrid.UltraCombo();
            this.bindingSource1_KyTinhLuong = new System.Windows.Forms.BindingSource(this.components);
            this.cbDenKy = new Infragistics.Win.UltraWinGrid.UltraCombo();
            this.cbNhanVien = new Infragistics.Win.UltraWinGrid.UltraCombo();
            this.bindingSource2_nhanVien = new System.Windows.Forms.BindingSource(this.components);
            this.lbl_ChiNhanh = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.grpNguoiKy = new Infragistics.Win.Misc.UltraGroupBox();
            this.cmbPTDonVi = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbPTTaiChinh = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbNguoiLap = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.label4 = new System.Windows.Forms.Label();
            this.btnClose = new Infragistics.Win.Misc.UltraButton();
            this.btnReport = new Infragistics.Win.Misc.UltraButton();
            this.pnlDieuKien.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbu_Bophan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BindS_BoPhan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbKyTinhLuong)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1_KyTinhLuong)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbDenKy)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbNhanVien)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource2_nhanVien)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpNguoiKy)).BeginInit();
            this.grpNguoiKy.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbPTDonVi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbPTTaiChinh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbNguoiLap)).BeginInit();
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
            treeNode1.Text = "Báo Cáo Tổng Hợp";
            treeNode2.Name = "Node1";
            treeNode2.Text = "Báo Cáo Chi Tiết";
            treeNode3.Name = "Node2";
            treeNode3.Text = "Báo Cáo Chi Tiết Nhân Viên";
            treeNode4.Name = "Node0";
            treeNode4.Text = "Báo Cáo Đảng Phí";
            treeNode5.Name = "Node5";
            treeNode5.Text = "Báo Cáo Tổng Hợp";
            treeNode6.Name = "Node4";
            treeNode6.Text = "Báo Cáo Chi Tiết";
            treeNode7.Name = "Node3";
            treeNode7.Text = "Báo Cáo Đảng Phí Điều Chỉnh";
            treeNode8.Name = "Node6";
            treeNode8.Text = "Báo Cáo Tổng Hợp";
            treeNode9.Name = "Node7";
            treeNode9.Text = "Báo Cáo Chi Tiết";
            treeNode10.Name = "Node2";
            treeNode10.Text = "Báo Cáo Tổng Hợp Sau Điều Chỉnh";
            this.treeReport.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode4,
            treeNode7,
            treeNode10});
            this.treeReport.Size = new System.Drawing.Size(301, 544);
            this.treeReport.TabIndex = 1;
            this.treeReport.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeReport_AfterSelect);
            // 
            // pnlDieuKien
            // 
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
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cmbu_Bophan);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.cbKyTinhLuong);
            this.groupBox1.Controls.Add(this.cbDenKy);
            this.groupBox1.Controls.Add(this.cbNhanVien);
            this.groupBox1.Controls.Add(this.lbl_ChiNhanh);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(17, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(308, 178);
            this.groupBox1.TabIndex = 21;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Điều Kiện";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(24, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 13);
            this.label2.TabIndex = 36;
            this.label2.Text = "Đến Kỳ";
            // 
            // cmbu_Bophan
            // 
            appearance1.FontData.BoldAsString = "False";
            this.cmbu_Bophan.Appearance = appearance1;
            this.cmbu_Bophan.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.cmbu_Bophan.DataSource = this.BindS_BoPhan;
            ultraGridColumn1.Header.VisiblePosition = 0;
            ultraGridColumn1.Hidden = true;
            ultraGridColumn2.Header.Caption = "Mã  QL";
            ultraGridColumn2.Header.VisiblePosition = 1;
            ultraGridColumn3.Header.Caption = "Tên Bộ Phận";
            ultraGridColumn3.Header.VisiblePosition = 2;
            ultraGridColumn3.Width = 250;
            ultraGridColumn4.Header.VisiblePosition = 3;
            ultraGridColumn4.Hidden = true;
            ultraGridColumn5.Header.VisiblePosition = 4;
            ultraGridColumn5.Hidden = true;
            ultraGridColumn6.Header.VisiblePosition = 5;
            ultraGridColumn6.Hidden = true;
            ultraGridColumn7.Header.VisiblePosition = 6;
            ultraGridColumn7.Hidden = true;
            ultraGridColumn8.Header.VisiblePosition = 7;
            ultraGridColumn8.Hidden = true;
            ultraGridColumn9.Header.VisiblePosition = 8;
            ultraGridColumn9.Hidden = true;
            ultraGridColumn10.Header.VisiblePosition = 9;
            ultraGridColumn10.Hidden = true;
            ultraGridColumn11.Header.VisiblePosition = 10;
            ultraGridColumn11.Hidden = true;
            ultraGridColumn12.Header.VisiblePosition = 11;
            ultraGridColumn12.Hidden = true;
            ultraGridColumn13.Header.VisiblePosition = 12;
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
            ultraGridColumn11,
            ultraGridColumn12,
            ultraGridColumn13});
            this.cmbu_Bophan.DisplayLayout.BandsSerializer.Add(ultraGridBand1);
            this.cmbu_Bophan.DisplayMember = "TenBoPhan";
            this.cmbu_Bophan.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007;
            this.cmbu_Bophan.DropDownStyle = Infragistics.Win.UltraWinGrid.UltraComboStyle.DropDownList;
            this.cmbu_Bophan.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbu_Bophan.Location = new System.Drawing.Point(77, 95);
            this.cmbu_Bophan.Name = "cmbu_Bophan";
            this.cmbu_Bophan.Size = new System.Drawing.Size(191, 22);
            this.cmbu_Bophan.TabIndex = 3;
            this.cmbu_Bophan.ValueMember = "MaBoPhan";
            this.cmbu_Bophan.ValueChanged += new System.EventHandler(this.cmbu_Bophan_ValueChanged);
            this.cmbu_Bophan.InitializeLayout += new Infragistics.Win.UltraWinGrid.InitializeLayoutEventHandler(this.cmbu_Bophan_InitializeLayout);
            // 
            // BindS_BoPhan
            // 
            this.BindS_BoPhan.DataSource = typeof(ERP_Library.BoPhanList);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(16, 137);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(57, 13);
            this.label9.TabIndex = 74;
            this.label9.Text = "Nhân Viên";
            // 
            // cbKyTinhLuong
            // 
            this.cbKyTinhLuong.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.cbKyTinhLuong.DataSource = this.bindingSource1_KyTinhLuong;
            ultraGridColumn14.Header.VisiblePosition = 0;
            ultraGridColumn14.Hidden = true;
            ultraGridColumn15.Header.Caption = "Tên Kỳ Tính Lương";
            ultraGridColumn15.Header.VisiblePosition = 1;
            ultraGridColumn15.Width = 250;
            ultraGridColumn16.Header.VisiblePosition = 2;
            ultraGridColumn16.Hidden = true;
            ultraGridColumn17.Header.VisiblePosition = 3;
            ultraGridColumn17.Hidden = true;
            ultraGridColumn18.Header.VisiblePosition = 4;
            ultraGridColumn18.Hidden = true;
            ultraGridColumn19.Header.VisiblePosition = 5;
            ultraGridColumn19.Hidden = true;
            ultraGridColumn20.Header.VisiblePosition = 6;
            ultraGridColumn20.Hidden = true;
            ultraGridColumn21.Header.VisiblePosition = 7;
            ultraGridColumn21.Hidden = true;
            ultraGridColumn22.Header.VisiblePosition = 8;
            ultraGridColumn22.Hidden = true;
            ultraGridColumn23.Header.VisiblePosition = 9;
            ultraGridColumn23.Hidden = true;
            ultraGridColumn24.Header.VisiblePosition = 10;
            ultraGridColumn24.Hidden = true;
            ultraGridColumn25.Header.VisiblePosition = 11;
            ultraGridColumn25.Hidden = true;
            ultraGridColumn26.Header.VisiblePosition = 12;
            ultraGridColumn26.Hidden = true;
            ultraGridColumn27.Header.VisiblePosition = 13;
            ultraGridColumn27.Hidden = true;
            ultraGridColumn28.Header.VisiblePosition = 14;
            ultraGridColumn28.Hidden = true;
            ultraGridColumn29.Header.VisiblePosition = 15;
            ultraGridColumn29.Hidden = true;
            ultraGridColumn30.Header.VisiblePosition = 16;
            ultraGridColumn30.Hidden = true;
            ultraGridBand2.Columns.AddRange(new object[] {
            ultraGridColumn14,
            ultraGridColumn15,
            ultraGridColumn16,
            ultraGridColumn17,
            ultraGridColumn18,
            ultraGridColumn19,
            ultraGridColumn20,
            ultraGridColumn21,
            ultraGridColumn22,
            ultraGridColumn23,
            ultraGridColumn24,
            ultraGridColumn25,
            ultraGridColumn26,
            ultraGridColumn27,
            ultraGridColumn28,
            ultraGridColumn29,
            ultraGridColumn30});
            this.cbKyTinhLuong.DisplayLayout.BandsSerializer.Add(ultraGridBand2);
            this.cbKyTinhLuong.DisplayMember = "TenKy";
            this.cbKyTinhLuong.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007;
            this.cbKyTinhLuong.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbKyTinhLuong.Location = new System.Drawing.Point(77, 21);
            this.cbKyTinhLuong.Name = "cbKyTinhLuong";
            this.cbKyTinhLuong.Size = new System.Drawing.Size(191, 22);
            this.cbKyTinhLuong.TabIndex = 31;
            this.cbKyTinhLuong.ValueMember = "MaKy";
            this.cbKyTinhLuong.ValueChanged += new System.EventHandler(this.cbKyTinhLuong_ValueChanged_1);
            // 
            // bindingSource1_KyTinhLuong
            // 
            this.bindingSource1_KyTinhLuong.AllowNew = true;
            this.bindingSource1_KyTinhLuong.DataSource = typeof(ERP_Library.KyTinhLuongList);
            // 
            // cbDenKy
            // 
            this.cbDenKy.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.cbDenKy.DataSource = this.bindingSource1_KyTinhLuong;
            ultraGridColumn31.Header.VisiblePosition = 0;
            ultraGridColumn31.Hidden = true;
            ultraGridColumn32.Header.Caption = "Tên Kỳ Tính Lương";
            ultraGridColumn32.Header.VisiblePosition = 1;
            ultraGridColumn32.Width = 250;
            ultraGridColumn33.Header.VisiblePosition = 2;
            ultraGridColumn33.Hidden = true;
            ultraGridColumn34.Header.VisiblePosition = 3;
            ultraGridColumn34.Hidden = true;
            ultraGridColumn35.Header.VisiblePosition = 4;
            ultraGridColumn35.Hidden = true;
            ultraGridColumn36.Header.VisiblePosition = 5;
            ultraGridColumn36.Hidden = true;
            ultraGridColumn37.Header.VisiblePosition = 6;
            ultraGridColumn37.Hidden = true;
            ultraGridColumn38.Header.VisiblePosition = 7;
            ultraGridColumn38.Hidden = true;
            ultraGridColumn39.Header.VisiblePosition = 8;
            ultraGridColumn39.Hidden = true;
            ultraGridColumn40.Header.VisiblePosition = 9;
            ultraGridColumn40.Hidden = true;
            ultraGridColumn41.Header.VisiblePosition = 10;
            ultraGridColumn41.Hidden = true;
            ultraGridColumn42.Header.VisiblePosition = 11;
            ultraGridColumn42.Hidden = true;
            ultraGridColumn43.Header.VisiblePosition = 12;
            ultraGridColumn43.Hidden = true;
            ultraGridColumn44.Header.VisiblePosition = 13;
            ultraGridColumn44.Hidden = true;
            ultraGridColumn45.Header.VisiblePosition = 14;
            ultraGridColumn45.Hidden = true;
            ultraGridColumn46.Header.VisiblePosition = 15;
            ultraGridColumn46.Hidden = true;
            ultraGridColumn47.Header.VisiblePosition = 16;
            ultraGridColumn47.Hidden = true;
            ultraGridBand3.Columns.AddRange(new object[] {
            ultraGridColumn31,
            ultraGridColumn32,
            ultraGridColumn33,
            ultraGridColumn34,
            ultraGridColumn35,
            ultraGridColumn36,
            ultraGridColumn37,
            ultraGridColumn38,
            ultraGridColumn39,
            ultraGridColumn40,
            ultraGridColumn41,
            ultraGridColumn42,
            ultraGridColumn43,
            ultraGridColumn44,
            ultraGridColumn45,
            ultraGridColumn46,
            ultraGridColumn47});
            this.cbDenKy.DisplayLayout.BandsSerializer.Add(ultraGridBand3);
            this.cbDenKy.DisplayMember = "TenKy";
            this.cbDenKy.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007;
            this.cbDenKy.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbDenKy.Location = new System.Drawing.Point(77, 58);
            this.cbDenKy.Name = "cbDenKy";
            this.cbDenKy.Size = new System.Drawing.Size(191, 22);
            this.cbDenKy.TabIndex = 35;
            this.cbDenKy.ValueMember = "MaKy";
            this.cbDenKy.ValueChanged += new System.EventHandler(this.cbDenKy_ValueChanged);
            // 
            // cbNhanVien
            // 
            this.cbNhanVien.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.cbNhanVien.DataSource = this.bindingSource2_nhanVien;
            ultraGridColumn48.Header.VisiblePosition = 0;
            ultraGridColumn48.Hidden = true;
            ultraGridColumn49.Header.VisiblePosition = 1;
            ultraGridColumn49.Hidden = true;
            ultraGridColumn50.Header.VisiblePosition = 2;
            ultraGridColumn50.Hidden = true;
            ultraGridColumn51.Header.Caption = "Tên Nhân Viên";
            ultraGridColumn51.Header.VisiblePosition = 3;
            ultraGridColumn51.Width = 250;
            ultraGridColumn52.Header.VisiblePosition = 4;
            ultraGridColumn52.Hidden = true;
            ultraGridBand4.Columns.AddRange(new object[] {
            ultraGridColumn48,
            ultraGridColumn49,
            ultraGridColumn50,
            ultraGridColumn51,
            ultraGridColumn52});
            this.cbNhanVien.DisplayLayout.BandsSerializer.Add(ultraGridBand4);
            this.cbNhanVien.DisplayMember = "TenNhanVien";
            this.cbNhanVien.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007;
            this.cbNhanVien.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbNhanVien.Location = new System.Drawing.Point(77, 132);
            this.cbNhanVien.Name = "cbNhanVien";
            this.cbNhanVien.Size = new System.Drawing.Size(191, 22);
            this.cbNhanVien.TabIndex = 4;
            this.cbNhanVien.ValueMember = "MaNhanVien";
            this.cbNhanVien.ValueChanged += new System.EventHandler(this.cbNhanVien_ValueChanged);
            this.cbNhanVien.InitializeLayout += new Infragistics.Win.UltraWinGrid.InitializeLayoutEventHandler(this.cbNhanVien_InitializeLayout);
            // 
            // bindingSource2_nhanVien
            // 
            this.bindingSource2_nhanVien.DataSource = typeof(ERP_Library.TTNhanVienRutGonList);
            // 
            // lbl_ChiNhanh
            // 
            this.lbl_ChiNhanh.AutoSize = true;
            this.lbl_ChiNhanh.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_ChiNhanh.Location = new System.Drawing.Point(19, 101);
            this.lbl_ChiNhanh.Name = "lbl_ChiNhanh";
            this.lbl_ChiNhanh.Size = new System.Drawing.Size(47, 13);
            this.lbl_ChiNhanh.TabIndex = 63;
            this.lbl_ChiNhanh.Text = "Bộ phận";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(24, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 32;
            this.label1.Text = "Từ Kỳ";
            // 
            // grpNguoiKy
            // 
            this.grpNguoiKy.Controls.Add(this.cmbPTDonVi);
            this.grpNguoiKy.Controls.Add(this.label6);
            this.grpNguoiKy.Controls.Add(this.cmbPTTaiChinh);
            this.grpNguoiKy.Controls.Add(this.label5);
            this.grpNguoiKy.Controls.Add(this.cmbNguoiLap);
            this.grpNguoiKy.Controls.Add(this.label4);
            this.grpNguoiKy.Location = new System.Drawing.Point(17, 212);
            this.grpNguoiKy.Name = "grpNguoiKy";
            this.grpNguoiKy.Size = new System.Drawing.Size(326, 106);
            this.grpNguoiKy.TabIndex = 16;
            this.grpNguoiKy.Text = "Người ký tên";
            // 
            // cmbPTDonVi
            // 
            this.cmbPTDonVi.DisplayMember = "";
            this.cmbPTDonVi.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007;
            this.cmbPTDonVi.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            valueListItem1.DisplayText = " ";
            this.cmbPTDonVi.Items.AddRange(new Infragistics.Win.ValueListItem[] {
            valueListItem1});
            this.cmbPTDonVi.Location = new System.Drawing.Point(96, 46);
            this.cmbPTDonVi.Name = "cmbPTDonVi";
            this.cmbPTDonVi.Size = new System.Drawing.Size(172, 21);
            this.cmbPTDonVi.TabIndex = 4;
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
            valueListItem2.DisplayText = " ";
            this.cmbPTTaiChinh.Items.AddRange(new Infragistics.Win.ValueListItem[] {
            valueListItem2});
            this.cmbPTTaiChinh.Location = new System.Drawing.Point(96, 73);
            this.cmbPTTaiChinh.Name = "cmbPTTaiChinh";
            this.cmbPTTaiChinh.Size = new System.Drawing.Size(172, 21);
            this.cmbPTTaiChinh.TabIndex = 5;
            this.cmbPTTaiChinh.ValueMember = "";
            this.cmbPTTaiChinh.ValueChanged += new System.EventHandler(this.cmbPTTaiChinh_ValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(24, 81);
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
            valueListItem3.DisplayText = " ";
            this.cmbNguoiLap.Items.AddRange(new Infragistics.Win.ValueListItem[] {
            valueListItem3});
            this.cmbNguoiLap.Location = new System.Drawing.Point(96, 19);
            this.cmbNguoiLap.Name = "cmbNguoiLap";
            this.cmbNguoiLap.Size = new System.Drawing.Size(172, 21);
            this.cmbNguoiLap.TabIndex = 3;
            this.cmbNguoiLap.ValueMember = "";
            this.cmbNguoiLap.ValueChanged += new System.EventHandler(this.cmbNguoiLap_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(24, 27);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Người lập";
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnClose.Location = new System.Drawing.Point(204, 336);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(91, 32);
            this.btnClose.TabIndex = 7;
            this.btnClose.Text = "Đóng";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnReport
            // 
            this.btnReport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnReport.Location = new System.Drawing.Point(99, 336);
            this.btnReport.Name = "btnReport";
            this.btnReport.Size = new System.Drawing.Size(91, 32);
            this.btnReport.TabIndex = 6;
            this.btnReport.Text = "Báo cáo";
            this.btnReport.Click += new System.EventHandler(this.btnReport_Click);
            // 
            // frmBaoCaoThuLao_DangPhi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(681, 544);
            this.Controls.Add(this.pnlDieuKien);
            this.Controls.Add(this.treeReport);
            this.Name = "frmBaoCaoThuLao_DangPhi";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Báo Cáo Đảng Phí";
            this.Load += new System.EventHandler(this.frmBaoCaoThuLao_Load);
            this.pnlDieuKien.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbu_Bophan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BindS_BoPhan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbKyTinhLuong)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1_KyTinhLuong)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbDenKy)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbNhanVien)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource2_nhanVien)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpNguoiKy)).EndInit();
            this.grpNguoiKy.ResumeLayout(false);
            this.grpNguoiKy.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbPTDonVi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbPTTaiChinh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbNguoiLap)).EndInit();
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
        private System.Windows.Forms.GroupBox groupBox1;
        private Infragistics.Win.UltraWinGrid.UltraCombo cmbu_Bophan;
        private System.Windows.Forms.Label lbl_ChiNhanh;
        private System.Windows.Forms.BindingSource BindS_BoPhan;
        private System.Windows.Forms.Label label9;
        private Infragistics.Win.UltraWinGrid.UltraCombo cbNhanVien;
        private System.Windows.Forms.BindingSource bindingSource2_nhanVien;
        private System.Windows.Forms.BindingSource bindingSource1_KyTinhLuong;
        private System.Windows.Forms.Label label1;
        private Infragistics.Win.UltraWinGrid.UltraCombo cbKyTinhLuong;
        private System.Windows.Forms.Label label2;
        private Infragistics.Win.UltraWinGrid.UltraCombo cbDenKy;

    }
}
