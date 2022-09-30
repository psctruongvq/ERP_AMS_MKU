namespace PSC_ERP
{
    partial class frmBaoCaoNangLuong
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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Danh Sách Đến Hạn Nâng Lương");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Báo Cáo Nâng Lương", new System.Windows.Forms.TreeNode[] {
            treeNode1});
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Đủ Điều Kiện Nâng Lương Trước Hạn(Biên Chế)");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("DS Đủ Điều Kiện Nâng  Lương Trước Hạn", new System.Windows.Forms.TreeNode[] {
            treeNode3});
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.ValueListItem valueListItem1 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem2 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem3 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.ValueListItem valueListItem4 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem5 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem6 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand1 = new Infragistics.Win.UltraWinGrid.UltraGridBand("BoPhan", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn1 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("MaBoPhan");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn2 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("MaBoPhanQL");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn3 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("TenBoPhan");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn4 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("NgayTao");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn5 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("MaBoPhanCha");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn6 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("MaLoaiBoPhan");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn7 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("MaCongTy");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn8 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("KhongTinhLuong");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn9 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("KhauHaoHaoMon");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn10 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("MaPhanCap");
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand2 = new Infragistics.Win.UltraWinGrid.UltraGridBand("TTNhanVienRutGon", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn11 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("MaNhanVien");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn12 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("MaBoPhan");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn13 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("MaChucVu");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn14 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("TenNhanVien");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn15 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("MaQLNhanVien");
            Infragistics.Win.ValueListItem valueListItem7 = new Infragistics.Win.ValueListItem();
            this.treeReport = new System.Windows.Forms.TreeView();
            this.pnlDieuKien = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dateTimePicker_NgayLap = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.cbKieuNangLuong = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbLoaiNV = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.lblPhanLoai = new System.Windows.Forms.Label();
            this.cbDanhSach = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.cmbu_Bophan = new Infragistics.Win.UltraWinGrid.UltraCombo();
            this.BindS_BoPhan = new System.Windows.Forms.BindingSource(this.components);
            this.label9 = new System.Windows.Forms.Label();
            this.cbNhanVien = new Infragistics.Win.UltraWinGrid.UltraCombo();
            this.bindingSource2_nhanVien = new System.Windows.Forms.BindingSource(this.components);
            this.lbl_ChiNhanh = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.grpNguoiKy = new Infragistics.Win.Misc.UltraGroupBox();
            this.cmbNguoiLap = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.label4 = new System.Windows.Forms.Label();
            this.btnClose = new Infragistics.Win.Misc.UltraButton();
            this.btnReport = new Infragistics.Win.Misc.UltraButton();
            this.bindingSource1_KyTinhLuong = new System.Windows.Forms.BindingSource(this.components);
            this.pnlDieuKien.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbKieuNangLuong)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbLoaiNV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbDanhSach)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbu_Bophan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BindS_BoPhan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbNhanVien)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource2_nhanVien)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpNguoiKy)).BeginInit();
            this.grpNguoiKy.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbNguoiLap)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1_KyTinhLuong)).BeginInit();
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
            treeNode1.Text = "Danh Sách Đến Hạn Nâng Lương";
            treeNode2.Name = "Node0";
            treeNode2.Text = "Báo Cáo Nâng Lương";
            treeNode3.Name = "Node2";
            treeNode3.Text = "Đủ Điều Kiện Nâng Lương Trước Hạn(Biên Chế)";
            treeNode4.Name = "Node0";
            treeNode4.Text = "DS Đủ Điều Kiện Nâng  Lương Trước Hạn";
            this.treeReport.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode2,
            treeNode4});
            this.treeReport.Size = new System.Drawing.Size(345, 544);
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
            this.pnlDieuKien.Location = new System.Drawing.Point(345, 0);
            this.pnlDieuKien.Name = "pnlDieuKien";
            this.pnlDieuKien.Size = new System.Drawing.Size(412, 544);
            this.pnlDieuKien.TabIndex = 2;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dateTimePicker_NgayLap);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cbKieuNangLuong);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.cmbLoaiNV);
            this.groupBox1.Controls.Add(this.lblPhanLoai);
            this.groupBox1.Controls.Add(this.cbDanhSach);
            this.groupBox1.Controls.Add(this.cmbu_Bophan);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.cbNhanVien);
            this.groupBox1.Controls.Add(this.lbl_ChiNhanh);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(59, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(349, 248);
            this.groupBox1.TabIndex = 21;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Điều Kiện";
            // 
            // dateTimePicker_NgayLap
            // 
            this.dateTimePicker_NgayLap.CustomFormat = "dd/MM/yyyy";
            this.dateTimePicker_NgayLap.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker_NgayLap.Location = new System.Drawing.Point(98, 22);
            this.dateTimePicker_NgayLap.Name = "dateTimePicker_NgayLap";
            this.dateTimePicker_NgayLap.Size = new System.Drawing.Size(191, 20);
            this.dateTimePicker_NgayLap.TabIndex = 96;
            this.dateTimePicker_NgayLap.ValueChanged += new System.EventHandler(this.dateNgayDenHan_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(14, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 13);
            this.label2.TabIndex = 95;
            this.label2.Text = "Ngày Đến Hạn";
            // 
            // cbKieuNangLuong
            // 
            appearance1.BackColor = System.Drawing.SystemColors.Info;
            this.cbKieuNangLuong.Appearance = appearance1;
            this.cbKieuNangLuong.BackColor = System.Drawing.SystemColors.Info;
            this.cbKieuNangLuong.DisplayMember = "";
            this.cbKieuNangLuong.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007;
            this.cbKieuNangLuong.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            valueListItem1.DataValue = 1;
            valueListItem1.DisplayText = "Lương && Lương BH";
            valueListItem2.DataValue = 2;
            valueListItem2.DisplayText = "Nâng Lương";
            valueListItem3.DataValue = 3;
            valueListItem3.DisplayText = "Nâng Lương Bảo Hiểm";
            this.cbKieuNangLuong.Items.AddRange(new Infragistics.Win.ValueListItem[] {
            valueListItem1,
            valueListItem2,
            valueListItem3});
            this.cbKieuNangLuong.Location = new System.Drawing.Point(98, 205);
            this.cbKieuNangLuong.Name = "cbKieuNangLuong";
            this.cbKieuNangLuong.Size = new System.Drawing.Size(191, 21);
            this.cbKieuNangLuong.TabIndex = 93;
            this.cbKieuNangLuong.ValueMember = "";
            this.cbKieuNangLuong.ValueChanged += new System.EventHandler(this.cbKieuNangLuong_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(3, 211);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 13);
            this.label3.TabIndex = 92;
            this.label3.Text = "Kiểu Nâng Lương";
            // 
            // cmbLoaiNV
            // 
            appearance6.BackColor = System.Drawing.SystemColors.Info;
            this.cmbLoaiNV.Appearance = appearance6;
            this.cmbLoaiNV.BackColor = System.Drawing.SystemColors.Info;
            this.cmbLoaiNV.DisplayMember = "";
            this.cmbLoaiNV.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007;
            this.cmbLoaiNV.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            valueListItem4.DataValue = 1;
            valueListItem4.DisplayText = "Biên chế và hợp đồng";
            valueListItem5.DataValue = 2;
            valueListItem5.DisplayText = "Hợp đồng vụ việc";
            this.cmbLoaiNV.Items.AddRange(new Infragistics.Win.ValueListItem[] {
            valueListItem4,
            valueListItem5});
            this.cmbLoaiNV.Location = new System.Drawing.Point(98, 169);
            this.cmbLoaiNV.Name = "cmbLoaiNV";
            this.cmbLoaiNV.Size = new System.Drawing.Size(191, 21);
            this.cmbLoaiNV.TabIndex = 91;
            this.cmbLoaiNV.ValueMember = "";
            this.cmbLoaiNV.ValueChanged += new System.EventHandler(this.cmbLoaiNV_ValueChanged);
            // 
            // lblPhanLoai
            // 
            this.lblPhanLoai.AutoSize = true;
            this.lblPhanLoai.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPhanLoai.Location = new System.Drawing.Point(12, 172);
            this.lblPhanLoai.Name = "lblPhanLoai";
            this.lblPhanLoai.Size = new System.Drawing.Size(80, 13);
            this.lblPhanLoai.TabIndex = 90;
            this.lblPhanLoai.Text = "Loại Nhân Viên";
            // 
            // cbDanhSach
            // 
            this.cbDanhSach.DisplayMember = "";
            this.cbDanhSach.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007;
            this.cbDanhSach.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            valueListItem6.DisplayText = " ";
            this.cbDanhSach.Items.AddRange(new Infragistics.Win.ValueListItem[] {
            valueListItem6});
            this.cbDanhSach.Location = new System.Drawing.Point(98, 59);
            this.cbDanhSach.Name = "cbDanhSach";
            this.cbDanhSach.Size = new System.Drawing.Size(191, 21);
            this.cbDanhSach.TabIndex = 75;
            this.cbDanhSach.ValueMember = "";
            this.cbDanhSach.ValueChanged += new System.EventHandler(this.cbDanhSach_ValueChanged);
            // 
            // cmbu_Bophan
            // 
            appearance2.FontData.BoldAsString = "False";
            this.cmbu_Bophan.Appearance = appearance2;
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
            ultraGridColumn10});
            this.cmbu_Bophan.DisplayLayout.BandsSerializer.Add(ultraGridBand1);
            this.cmbu_Bophan.DisplayMember = "TenBoPhan";
            this.cmbu_Bophan.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007;
            this.cmbu_Bophan.DropDownStyle = Infragistics.Win.UltraWinGrid.UltraComboStyle.DropDownList;
            this.cmbu_Bophan.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbu_Bophan.Location = new System.Drawing.Point(98, 95);
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
            this.label9.Location = new System.Drawing.Point(37, 137);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(57, 13);
            this.label9.TabIndex = 74;
            this.label9.Text = "Nhân Viên";
            // 
            // cbNhanVien
            // 
            this.cbNhanVien.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.cbNhanVien.DataSource = this.bindingSource2_nhanVien;
            ultraGridColumn11.Header.VisiblePosition = 0;
            ultraGridColumn11.Hidden = true;
            ultraGridColumn12.Header.VisiblePosition = 1;
            ultraGridColumn12.Hidden = true;
            ultraGridColumn13.Header.VisiblePosition = 2;
            ultraGridColumn13.Hidden = true;
            ultraGridColumn14.Header.Caption = "Tên Nhân Viên";
            ultraGridColumn14.Header.VisiblePosition = 3;
            ultraGridColumn14.Width = 250;
            ultraGridColumn15.Header.VisiblePosition = 4;
            ultraGridColumn15.Hidden = true;
            ultraGridBand2.Columns.AddRange(new object[] {
            ultraGridColumn11,
            ultraGridColumn12,
            ultraGridColumn13,
            ultraGridColumn14,
            ultraGridColumn15});
            this.cbNhanVien.DisplayLayout.BandsSerializer.Add(ultraGridBand2);
            this.cbNhanVien.DisplayMember = "TenNhanVien";
            this.cbNhanVien.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007;
            this.cbNhanVien.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbNhanVien.Location = new System.Drawing.Point(98, 132);
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
            this.lbl_ChiNhanh.Location = new System.Drawing.Point(40, 101);
            this.lbl_ChiNhanh.Name = "lbl_ChiNhanh";
            this.lbl_ChiNhanh.Size = new System.Drawing.Size(47, 13);
            this.lbl_ChiNhanh.TabIndex = 63;
            this.lbl_ChiNhanh.Text = "Bộ phận";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(31, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 32;
            this.label1.Text = "Danh Sách";
            // 
            // grpNguoiKy
            // 
            this.grpNguoiKy.Controls.Add(this.cmbNguoiLap);
            this.grpNguoiKy.Controls.Add(this.label4);
            this.grpNguoiKy.Location = new System.Drawing.Point(59, 266);
            this.grpNguoiKy.Name = "grpNguoiKy";
            this.grpNguoiKy.Size = new System.Drawing.Size(349, 64);
            this.grpNguoiKy.TabIndex = 16;
            this.grpNguoiKy.Text = "Người ký tên";
            // 
            // cmbNguoiLap
            // 
            this.cmbNguoiLap.DisplayMember = "";
            this.cmbNguoiLap.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007;
            this.cmbNguoiLap.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            valueListItem7.DisplayText = " ";
            this.cmbNguoiLap.Items.AddRange(new Infragistics.Win.ValueListItem[] {
            valueListItem7});
            this.cmbNguoiLap.Location = new System.Drawing.Point(96, 19);
            this.cmbNguoiLap.Name = "cmbNguoiLap";
            this.cmbNguoiLap.Size = new System.Drawing.Size(182, 21);
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
            this.btnClose.Location = new System.Drawing.Point(260, 350);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(91, 32);
            this.btnClose.TabIndex = 7;
            this.btnClose.Text = "Đóng";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnReport
            // 
            this.btnReport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnReport.Location = new System.Drawing.Point(155, 350);
            this.btnReport.Name = "btnReport";
            this.btnReport.Size = new System.Drawing.Size(91, 32);
            this.btnReport.TabIndex = 6;
            this.btnReport.Text = "Báo cáo";
            this.btnReport.Click += new System.EventHandler(this.btnReport_Click);
            // 
            // bindingSource1_KyTinhLuong
            // 
            this.bindingSource1_KyTinhLuong.AllowNew = true;
            this.bindingSource1_KyTinhLuong.DataSource = typeof(ERP_Library.KyTinhLuongList);
            // 
            // frmBaoCaoNangLuong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(757, 544);
            this.Controls.Add(this.pnlDieuKien);
            this.Controls.Add(this.treeReport);
            this.Name = "frmBaoCaoNangLuong";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Báo Cáo Nâng Lương";
            this.Load += new System.EventHandler(this.frmBaoCaoThuLao_Load);
            this.pnlDieuKien.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbKieuNangLuong)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbLoaiNV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbDanhSach)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbu_Bophan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BindS_BoPhan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbNhanVien)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource2_nhanVien)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpNguoiKy)).EndInit();
            this.grpNguoiKy.ResumeLayout(false);
            this.grpNguoiKy.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbNguoiLap)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1_KyTinhLuong)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView treeReport;
        private System.Windows.Forms.Panel pnlDieuKien;
        private Infragistics.Win.Misc.UltraGroupBox grpNguoiKy;
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
        private Infragistics.Win.UltraWinEditors.UltraComboEditor cbDanhSach;
        private Infragistics.Win.UltraWinEditors.UltraComboEditor cbKieuNangLuong;
        private System.Windows.Forms.Label label3;
        private Infragistics.Win.UltraWinEditors.UltraComboEditor cmbLoaiNV;
        private System.Windows.Forms.Label lblPhanLoai;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dateTimePicker_NgayLap;

    }
}
