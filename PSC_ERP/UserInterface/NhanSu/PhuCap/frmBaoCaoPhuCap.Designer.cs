namespace PSC_ERP
{
    partial class frmBaoCaoPhuCap
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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Danh sách lĩnh tiền ăn trưa, hành chính, trách nhiệm KVQL");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Chi tiết phụ cấp nhân viên");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Chi tiết phụ cấp nhân viên (có thuế tạm thu)");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("Chi tiết phụ cấp nhân viên cho ngân hàng");
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("Bảng kê chi tiết nhóm phụ cấp");
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("Chi tiết phụ cấp ngoài giờ + TT,TP, ĐH cho ngân hàng", new System.Windows.Forms.TreeNode[] {
            treeNode5});
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("Bảng kê chi tiết nhóm phụ cấp (A4)");
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("Bảng kê chi tiết nhóm phụ cấp (Truy lĩnh - Truy thu)");
            System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("Bảng kê chi tiết nhóm phụ cấp ngoài giờ");
            System.Windows.Forms.TreeNode treeNode10 = new System.Windows.Forms.TreeNode("Bảng kê chi tiết phụ cấp (A4) Trong 200 Gio ");
            System.Windows.Forms.TreeNode treeNode11 = new System.Windows.Forms.TreeNode("Bảng kê chi tiết phụ cấp (A4) lớn hơn 200 Gio ");
            System.Windows.Forms.TreeNode treeNode12 = new System.Windows.Forms.TreeNode("Bảng kê chi tiết", new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode3,
            treeNode4,
            treeNode6,
            treeNode7,
            treeNode8,
            treeNode9,
            treeNode10,
            treeNode11});
            System.Windows.Forms.TreeNode treeNode13 = new System.Windows.Forms.TreeNode("Tổng hợp tiền ăn trưa, hành chính, trách nhiệm KVQL");
            System.Windows.Forms.TreeNode treeNode14 = new System.Windows.Forms.TreeNode("Tổng hợp phụ cấp bộ phận");
            System.Windows.Forms.TreeNode treeNode15 = new System.Windows.Forms.TreeNode("Tổng hợp phụ cấp bộ phận (nhóm ngân hàng)");
            System.Windows.Forms.TreeNode treeNode16 = new System.Windows.Forms.TreeNode("Tổng hợp số tiền chuyển khoản, tiền mặt");
            System.Windows.Forms.TreeNode treeNode17 = new System.Windows.Forms.TreeNode("Bảng kê tổng hợp theo nhóm phụ cấp");
            System.Windows.Forms.TreeNode treeNode18 = new System.Windows.Forms.TreeNode("Bảng kê tổng hợp nhóm phụ cấp (Truy lĩnh - Truy thu)");
            System.Windows.Forms.TreeNode treeNode19 = new System.Windows.Forms.TreeNode("Bảng kê tổng hợp theo nhóm phụ cấp (A4)");
            System.Windows.Forms.TreeNode treeNode20 = new System.Windows.Forms.TreeNode("Bảng kê tổng hợp nhóm phụ cấp ngoài giờ");
            System.Windows.Forms.TreeNode treeNode21 = new System.Windows.Forms.TreeNode("Bảng kê tổng hợp theo nhóm phụ cấp (A4) trong 200 giờ");
            System.Windows.Forms.TreeNode treeNode22 = new System.Windows.Forms.TreeNode("Bảng kê tổng hợp theo nhóm phụ cấp (A4) lớn hơn 200 giờ");
            System.Windows.Forms.TreeNode treeNode23 = new System.Windows.Forms.TreeNode("Báo cáo tổng hợp", new System.Windows.Forms.TreeNode[] {
            treeNode13,
            treeNode14,
            treeNode15,
            treeNode16,
            treeNode17,
            treeNode18,
            treeNode19,
            treeNode20,
            treeNode21,
            treeNode22});
            Infragistics.Win.ValueListItem valueListItem1 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem2 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem3 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem4 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.ValueListItem valueListItem5 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand1 = new Infragistics.Win.UltraWinGrid.UltraGridBand("BoPhan", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn12 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Chon");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn13 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("MaBoPhan");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn14 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("MaBoPhanQL");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn15 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("TenBoPhan");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn16 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("NgayTao");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn17 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("MaBoPhanCha");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn18 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("MaLoaiBoPhan");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn19 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("MaCongTy");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn20 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("KhongTinhLuong");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn21 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("KhauHaoHaoMon");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn22 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("MaPhanCap");
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.ValueListItem valueListItem6 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            Infragistics.Win.ValueListItem valueListItem7 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem8 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem9 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            Infragistics.Win.ValueListItem valueListItem10 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem11 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem12 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem13 = new Infragistics.Win.ValueListItem();
            this.treeReport = new System.Windows.Forms.TreeView();
            this.pnlDieuKien = new System.Windows.Forms.Panel();
            this.cmbKyTen = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbKyPC = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbNhomPC = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.lblNhomPC = new System.Windows.Forms.Label();
            this.cmbPhuCap = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.lblPhuCap = new System.Windows.Forms.Label();
            this.cmbBoPhan = new Infragistics.Win.UltraWinGrid.UltraCombo();
            this.cmbNganHang = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.lblNganHang = new System.Windows.Forms.Label();
            this.cmbHinhThuc = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.lblHinhThuc = new System.Windows.Forms.Label();
            this.btnClose = new Infragistics.Win.Misc.UltraButton();
            this.btnReport = new Infragistics.Win.Misc.UltraButton();
            this.cmbLoaiNV = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.lblPhanLoai = new System.Windows.Forms.Label();
            this.lblBoPhan = new System.Windows.Forms.Label();
            this.cmbKyLuong = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.label1 = new System.Windows.Forms.Label();
            this.boPhanListBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.pnlDieuKien.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbKyTen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbKyPC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbNhomPC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbPhuCap)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbBoPhan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbNganHang)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbHinhThuc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbLoaiNV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbKyLuong)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.boPhanListBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // treeReport
            // 
            this.treeReport.Dock = System.Windows.Forms.DockStyle.Left;
            this.treeReport.FullRowSelect = true;
            this.treeReport.HideSelection = false;
            this.treeReport.Location = new System.Drawing.Point(0, 0);
            this.treeReport.Name = "treeReport";
            treeNode1.Name = "node01";
            treeNode1.Tag = "BoPhan,NganHang,LoaiNV,HinhThuc";
            treeNode1.Text = "Danh sách lĩnh tiền ăn trưa, hành chính, trách nhiệm KVQL";
            treeNode2.Name = "node03";
            treeNode2.Tag = "NhomPC,PhuCap,BoPhan,LoaiNV,NganHang,HinhThuc";
            treeNode2.Text = "Chi tiết phụ cấp nhân viên";
            treeNode3.Name = "nodeChiTietThue";
            treeNode3.Tag = "NhomPC,PhuCap,BoPhan,LoaiNV,NganHang";
            treeNode3.Text = "Chi tiết phụ cấp nhân viên (có thuế tạm thu)";
            treeNode4.Name = "node05";
            treeNode4.Tag = "NhomPC,PhuCap,BoPhan,LoaiNV,NganHang";
            treeNode4.Text = "Chi tiết phụ cấp nhân viên cho ngân hàng";
            treeNode5.Name = "chitiettrichngang";
            treeNode5.Tag = "NhomPC,BoPhan,LoaiNV,NganHang";
            treeNode5.Text = "Bảng kê chi tiết nhóm phụ cấp";
            treeNode6.Name = "chitietnganhang2nhom";
            treeNode6.Tag = "BoPhan,LoaiNV,NganHang,HinhThuc";
            treeNode6.Text = "Chi tiết phụ cấp ngoài giờ + TT,TP, ĐH cho ngân hàng";
            treeNode7.Name = "chitiettrichngangA4";
            treeNode7.Tag = "NhomPC,BoPhan,LoaiNV,NganHang,HinhThuc";
            treeNode7.Text = "Bảng kê chi tiết nhóm phụ cấp (A4)";
            treeNode8.Name = "NodeBangKeTruyLinhTruyThuNhanVien";
            treeNode8.Tag = "BoPhan,LoaiNV,NganHang,HinhThuc";
            treeNode8.Text = "Bảng kê chi tiết nhóm phụ cấp (Truy lĩnh - Truy thu)";
            treeNode9.Name = "node09";
            treeNode9.Tag = "BoPhan,NganHang,NhomPC,LoaiNV,HinhThuc";
            treeNode9.Text = "Bảng kê chi tiết nhóm phụ cấp ngoài giờ";
            treeNode10.Name = "chitiettrichngangA4Trong200Gio";
            treeNode10.Tag = "NhomPC,BoPhan,LoaiNV,NganHang,HinhThuc";
            treeNode10.Text = "Bảng kê chi tiết phụ cấp (A4) Trong 200 Gio ";
            treeNode11.Name = "chitiettrichngangA4LonHon200Gio";
            treeNode11.Tag = "NhomPC,BoPhan,LoaiNV,NganHang,HinhThuc";
            treeNode11.Text = "Bảng kê chi tiết phụ cấp (A4) lớn hơn 200 Gio ";
            treeNode12.Name = "chitietnhanvien";
            treeNode12.NodeFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            treeNode12.Text = "Bảng kê chi tiết";
            treeNode13.Name = "node02";
            treeNode13.Tag = "LoaiNV,HinhThuc";
            treeNode13.Text = "Tổng hợp tiền ăn trưa, hành chính, trách nhiệm KVQL";
            treeNode14.Name = "node04";
            treeNode14.Tag = "NhomPC,PhuCap,LoaiNV,HinhThuc";
            treeNode14.Text = "Tổng hợp phụ cấp bộ phận";
            treeNode15.Name = "node07";
            treeNode15.Tag = "LoaiNV,NhomPC,PhuCap,HinhThuc";
            treeNode15.Text = "Tổng hợp phụ cấp bộ phận (nhóm ngân hàng)";
            treeNode16.Name = "node06";
            treeNode16.Tag = "NhomPC,PhuCap,LoaiNV,BoPhan,HinhThuc";
            treeNode16.Text = "Tổng hợp số tiền chuyển khoản, tiền mặt";
            treeNode17.Name = "node08";
            treeNode17.Tag = "NhomPC,LoaiNV,NganHang,HinhThuc";
            treeNode17.Text = "Bảng kê tổng hợp theo nhóm phụ cấp";
            treeNode18.Name = "NodeBangKeTongHopPhuCapTruyLinhTruyThuNhanVien";
            treeNode18.Tag = "LoaiNV,NganHang,HinhThuc";
            treeNode18.Text = "Bảng kê tổng hợp nhóm phụ cấp (Truy lĩnh - Truy thu)";
            treeNode19.Name = "node11";
            treeNode19.Tag = "NhomPC,LoaiNV,NganHang,HinhThuc";
            treeNode19.Text = "Bảng kê tổng hợp theo nhóm phụ cấp (A4)";
            treeNode20.Name = "node10";
            treeNode20.Tag = "NganHang,NhomPC,LoaiNV,HinhThuc";
            treeNode20.Text = "Bảng kê tổng hợp nhóm phụ cấp ngoài giờ";
            treeNode21.Name = "TongHopTheoNhomPhuCapTrong200";
            treeNode21.Tag = "NhomPC,LoaiNV,NganHang,HinhThuc";
            treeNode21.Text = "Bảng kê tổng hợp theo nhóm phụ cấp (A4) trong 200 giờ";
            treeNode22.Name = "TongHopTheoNhomPhuCapLonHon200";
            treeNode22.Tag = "NhomPC,LoaiNV,NganHang,HinhThuc";
            treeNode22.Text = "Bảng kê tổng hợp theo nhóm phụ cấp (A4) lớn hơn 200 giờ";
            treeNode23.Name = "tonghop";
            treeNode23.NodeFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            treeNode23.Text = "Báo cáo tổng hợp";
            this.treeReport.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode12,
            treeNode23});
            this.treeReport.Size = new System.Drawing.Size(346, 426);
            this.treeReport.TabIndex = 0;
            this.treeReport.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeReport_AfterSelect);
            // 
            // pnlDieuKien
            // 
            this.pnlDieuKien.Controls.Add(this.cmbKyTen);
            this.pnlDieuKien.Controls.Add(this.label3);
            this.pnlDieuKien.Controls.Add(this.cmbKyPC);
            this.pnlDieuKien.Controls.Add(this.label2);
            this.pnlDieuKien.Controls.Add(this.cmbNhomPC);
            this.pnlDieuKien.Controls.Add(this.lblNhomPC);
            this.pnlDieuKien.Controls.Add(this.cmbPhuCap);
            this.pnlDieuKien.Controls.Add(this.lblPhuCap);
            this.pnlDieuKien.Controls.Add(this.cmbBoPhan);
            this.pnlDieuKien.Controls.Add(this.cmbNganHang);
            this.pnlDieuKien.Controls.Add(this.lblNganHang);
            this.pnlDieuKien.Controls.Add(this.cmbHinhThuc);
            this.pnlDieuKien.Controls.Add(this.lblHinhThuc);
            this.pnlDieuKien.Controls.Add(this.btnClose);
            this.pnlDieuKien.Controls.Add(this.btnReport);
            this.pnlDieuKien.Controls.Add(this.cmbLoaiNV);
            this.pnlDieuKien.Controls.Add(this.lblPhanLoai);
            this.pnlDieuKien.Controls.Add(this.lblBoPhan);
            this.pnlDieuKien.Controls.Add(this.cmbKyLuong);
            this.pnlDieuKien.Controls.Add(this.label1);
            this.pnlDieuKien.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDieuKien.Location = new System.Drawing.Point(346, 0);
            this.pnlDieuKien.Name = "pnlDieuKien";
            this.pnlDieuKien.Size = new System.Drawing.Size(313, 426);
            this.pnlDieuKien.TabIndex = 1;
            // 
            // cmbKyTen
            // 
            this.cmbKyTen.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007;
            this.cmbKyTen.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            valueListItem1.DataValue = 0;
            valueListItem1.DisplayText = "Không có";
            valueListItem2.DataValue = 1;
            valueListItem2.DisplayText = "Người lập";
            valueListItem3.DataValue = 2;
            valueListItem3.DisplayText = "Người lập, Thủ trưởng";
            valueListItem4.DataValue = 3;
            valueListItem4.DisplayText = "Người lập, BPT, Thủ trưởng";
            this.cmbKyTen.Items.AddRange(new Infragistics.Win.ValueListItem[] {
            valueListItem1,
            valueListItem2,
            valueListItem3,
            valueListItem4});
            this.cmbKyTen.Location = new System.Drawing.Point(83, 257);
            this.cmbKyTen.Name = "cmbKyTen";
            this.cmbKyTen.Size = new System.Drawing.Size(212, 21);
            this.cmbKyTen.TabIndex = 24;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 265);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 13);
            this.label3.TabIndex = 23;
            this.label3.Text = "Ký tên";
            // 
            // cmbKyPC
            // 
            this.cmbKyPC.DisplayMember = "";
            this.cmbKyPC.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007;
            this.cmbKyPC.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.cmbKyPC.Location = new System.Drawing.Point(83, 37);
            this.cmbKyPC.Name = "cmbKyPC";
            this.cmbKyPC.Size = new System.Drawing.Size(212, 21);
            this.cmbKyPC.TabIndex = 3;
            this.cmbKyPC.ValueMember = "";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Kỳ phụ cấp";
            // 
            // cmbNhomPC
            // 
            appearance1.BackColor = System.Drawing.SystemColors.Info;
            this.cmbNhomPC.Appearance = appearance1;
            this.cmbNhomPC.BackColor = System.Drawing.SystemColors.Info;
            this.cmbNhomPC.DisplayMember = "";
            this.cmbNhomPC.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007;
            this.cmbNhomPC.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            valueListItem5.DataValue = 0;
            valueListItem5.DisplayText = "Tất cả";
            this.cmbNhomPC.Items.AddRange(new Infragistics.Win.ValueListItem[] {
            valueListItem5});
            this.cmbNhomPC.Location = new System.Drawing.Point(102, 199);
            this.cmbNhomPC.Name = "cmbNhomPC";
            this.cmbNhomPC.Size = new System.Drawing.Size(193, 21);
            this.cmbNhomPC.TabIndex = 15;
            this.cmbNhomPC.ValueMember = "";
            this.cmbNhomPC.ValueChanged += new System.EventHandler(this.cmbNhomPC_ValueChanged);
            // 
            // lblNhomPC
            // 
            this.lblNhomPC.AutoSize = true;
            this.lblNhomPC.Location = new System.Drawing.Point(19, 207);
            this.lblNhomPC.Name = "lblNhomPC";
            this.lblNhomPC.Size = new System.Drawing.Size(77, 13);
            this.lblNhomPC.TabIndex = 14;
            this.lblNhomPC.Text = "Nhóm phụ cấp";
            // 
            // cmbPhuCap
            // 
            appearance2.BackColor = System.Drawing.SystemColors.Info;
            this.cmbPhuCap.Appearance = appearance2;
            this.cmbPhuCap.BackColor = System.Drawing.SystemColors.Info;
            this.cmbPhuCap.DisplayMember = "TenLoaiPhuCap";
            this.cmbPhuCap.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007;
            this.cmbPhuCap.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.cmbPhuCap.Location = new System.Drawing.Point(83, 172);
            this.cmbPhuCap.Name = "cmbPhuCap";
            this.cmbPhuCap.Size = new System.Drawing.Size(212, 21);
            this.cmbPhuCap.TabIndex = 13;
            this.cmbPhuCap.ValueMember = "MaLoaiPhuCap";
            // 
            // lblPhuCap
            // 
            this.lblPhuCap.AutoSize = true;
            this.lblPhuCap.Location = new System.Drawing.Point(19, 180);
            this.lblPhuCap.Name = "lblPhuCap";
            this.lblPhuCap.Size = new System.Drawing.Size(47, 13);
            this.lblPhuCap.TabIndex = 12;
            this.lblPhuCap.Text = "Phụ cấp";
            // 
            // cmbBoPhan
            // 
            this.cmbBoPhan.DataSource = this.boPhanListBindingSource;
            appearance3.BackColor = System.Drawing.SystemColors.ControlLight;
            appearance3.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance3.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            this.cmbBoPhan.DisplayLayout.Appearance = appearance3;
            ultraGridColumn12.Header.VisiblePosition = 0;
            ultraGridColumn13.Header.VisiblePosition = 1;
            ultraGridColumn13.Hidden = true;
            ultraGridColumn14.Header.Caption = "Mã BP";
            ultraGridColumn14.Header.VisiblePosition = 2;
            ultraGridColumn14.Width = 59;
            ultraGridColumn15.Header.Caption = "Tên bộ phận";
            ultraGridColumn15.Header.VisiblePosition = 3;
            ultraGridColumn15.Width = 182;
            ultraGridColumn16.Header.VisiblePosition = 5;
            ultraGridColumn16.Hidden = true;
            ultraGridColumn17.Header.VisiblePosition = 6;
            ultraGridColumn17.Hidden = true;
            ultraGridColumn18.Header.VisiblePosition = 7;
            ultraGridColumn18.Hidden = true;
            ultraGridColumn19.Header.VisiblePosition = 8;
            ultraGridColumn19.Hidden = true;
            ultraGridColumn20.Header.VisiblePosition = 10;
            ultraGridColumn20.Hidden = true;
            ultraGridColumn21.Header.VisiblePosition = 4;
            ultraGridColumn22.Header.VisiblePosition = 9;
            ultraGridBand1.Columns.AddRange(new object[] {
            ultraGridColumn12,
            ultraGridColumn13,
            ultraGridColumn14,
            ultraGridColumn15,
            ultraGridColumn16,
            ultraGridColumn17,
            ultraGridColumn18,
            ultraGridColumn19,
            ultraGridColumn20,
            ultraGridColumn21,
            ultraGridColumn22});
            this.cmbBoPhan.DisplayLayout.BandsSerializer.Add(ultraGridBand1);
            this.cmbBoPhan.DisplayLayout.InterBandSpacing = 10;
            this.cmbBoPhan.DisplayLayout.MaxColScrollRegions = 1;
            this.cmbBoPhan.DisplayLayout.MaxRowScrollRegions = 1;
            appearance4.BackColor = System.Drawing.Color.Transparent;
            this.cmbBoPhan.DisplayLayout.Override.CardAreaAppearance = appearance4;
            appearance5.BackColor = System.Drawing.SystemColors.Control;
            appearance5.BackColor2 = System.Drawing.SystemColors.ControlLightLight;
            appearance5.BackGradientStyle = Infragistics.Win.GradientStyle.VerticalBump;
            this.cmbBoPhan.DisplayLayout.Override.CellAppearance = appearance5;
            this.cmbBoPhan.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText;
            appearance6.BackColor = System.Drawing.SystemColors.Control;
            appearance6.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance6.BackGradientStyle = Infragistics.Win.GradientStyle.VerticalBump;
            appearance6.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent;
            this.cmbBoPhan.DisplayLayout.Override.HeaderAppearance = appearance6;
            this.cmbBoPhan.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            appearance7.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.cmbBoPhan.DisplayLayout.Override.RowSelectorAppearance = appearance7;
            appearance8.BackColor = System.Drawing.SystemColors.InactiveCaption;
            appearance8.BackColor2 = System.Drawing.SystemColors.ActiveCaption;
            appearance8.BackGradientStyle = Infragistics.Win.GradientStyle.VerticalBump;
            this.cmbBoPhan.DisplayLayout.Override.SelectedRowAppearance = appearance8;
            this.cmbBoPhan.DisplayLayout.RowConnectorColor = System.Drawing.SystemColors.ControlDarkDark;
            this.cmbBoPhan.DisplayLayout.RowConnectorStyle = Infragistics.Win.UltraWinGrid.RowConnectorStyle.Dashed;
            this.cmbBoPhan.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.cmbBoPhan.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.cmbBoPhan.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy;
            this.cmbBoPhan.DisplayMember = "TenBoPhan";
            this.cmbBoPhan.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007;
            this.cmbBoPhan.DropDownStyle = Infragistics.Win.UltraWinGrid.UltraComboStyle.DropDownList;
            this.cmbBoPhan.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.cmbBoPhan.Location = new System.Drawing.Point(83, 117);
            this.cmbBoPhan.Name = "cmbBoPhan";
            this.cmbBoPhan.Size = new System.Drawing.Size(212, 22);
            this.cmbBoPhan.TabIndex = 9;
            this.cmbBoPhan.ValueMember = "MaBoPhan";
            // 
            // cmbNganHang
            // 
            this.cmbNganHang.DisplayMember = "";
            this.cmbNganHang.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007;
            this.cmbNganHang.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            valueListItem6.DataValue = 0;
            valueListItem6.DisplayText = "Tất cả";
            this.cmbNganHang.Items.AddRange(new Infragistics.Win.ValueListItem[] {
            valueListItem6});
            this.cmbNganHang.Location = new System.Drawing.Point(83, 145);
            this.cmbNganHang.Name = "cmbNganHang";
            this.cmbNganHang.Size = new System.Drawing.Size(212, 21);
            this.cmbNganHang.TabIndex = 11;
            this.cmbNganHang.ValueMember = "";
            // 
            // lblNganHang
            // 
            this.lblNganHang.AutoSize = true;
            this.lblNganHang.Location = new System.Drawing.Point(19, 154);
            this.lblNganHang.Name = "lblNganHang";
            this.lblNganHang.Size = new System.Drawing.Size(60, 13);
            this.lblNganHang.TabIndex = 10;
            this.lblNganHang.Text = "Ngân hàng";
            // 
            // cmbHinhThuc
            // 
            appearance9.BackColor = System.Drawing.SystemColors.Info;
            this.cmbHinhThuc.Appearance = appearance9;
            this.cmbHinhThuc.BackColor = System.Drawing.SystemColors.Info;
            this.cmbHinhThuc.DisplayMember = "";
            this.cmbHinhThuc.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007;
            this.cmbHinhThuc.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            valueListItem7.DataValue = 2;
            valueListItem7.DisplayText = "Tất cả";
            valueListItem8.DataValue = 1;
            valueListItem8.DisplayText = "Chuyển khoản NH";
            valueListItem9.DataValue = 0;
            valueListItem9.DisplayText = "Tiền mặt";
            this.cmbHinhThuc.Items.AddRange(new Infragistics.Win.ValueListItem[] {
            valueListItem7,
            valueListItem8,
            valueListItem9});
            this.cmbHinhThuc.Location = new System.Drawing.Point(83, 91);
            this.cmbHinhThuc.Name = "cmbHinhThuc";
            this.cmbHinhThuc.Size = new System.Drawing.Size(212, 21);
            this.cmbHinhThuc.TabIndex = 7;
            this.cmbHinhThuc.ValueMember = "";
            // 
            // lblHinhThuc
            // 
            this.lblHinhThuc.AutoSize = true;
            this.lblHinhThuc.Location = new System.Drawing.Point(19, 99);
            this.lblHinhThuc.Name = "lblHinhThuc";
            this.lblHinhThuc.Size = new System.Drawing.Size(53, 13);
            this.lblHinhThuc.TabIndex = 6;
            this.lblHinhThuc.Text = "Hình thức";
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnClose.Location = new System.Drawing.Point(167, 372);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(91, 32);
            this.btnClose.TabIndex = 18;
            this.btnClose.Text = "Đóng";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnReport
            // 
            this.btnReport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnReport.Location = new System.Drawing.Point(70, 372);
            this.btnReport.Name = "btnReport";
            this.btnReport.Size = new System.Drawing.Size(91, 32);
            this.btnReport.TabIndex = 17;
            this.btnReport.Text = "Báo cáo";
            this.btnReport.Click += new System.EventHandler(this.btnReport_Click);
            // 
            // cmbLoaiNV
            // 
            appearance10.BackColor = System.Drawing.SystemColors.Info;
            this.cmbLoaiNV.Appearance = appearance10;
            this.cmbLoaiNV.BackColor = System.Drawing.SystemColors.Info;
            this.cmbLoaiNV.DisplayMember = "";
            this.cmbLoaiNV.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007;
            this.cmbLoaiNV.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            valueListItem10.DataValue = 0;
            valueListItem10.DisplayText = "Tất cả";
            valueListItem11.DataValue = 1;
            valueListItem11.DisplayText = "Biên chế và hợp đồng";
            valueListItem12.DataValue = 2;
            valueListItem12.DisplayText = "Hợp đồng vụ việc";
            valueListItem13.DataValue = 3;
            valueListItem13.DisplayText = "Lương khoán";
            this.cmbLoaiNV.Items.AddRange(new Infragistics.Win.ValueListItem[] {
            valueListItem10,
            valueListItem11,
            valueListItem12,
            valueListItem13});
            this.cmbLoaiNV.Location = new System.Drawing.Point(83, 64);
            this.cmbLoaiNV.Name = "cmbLoaiNV";
            this.cmbLoaiNV.Size = new System.Drawing.Size(212, 21);
            this.cmbLoaiNV.TabIndex = 5;
            this.cmbLoaiNV.ValueMember = "";
            // 
            // lblPhanLoai
            // 
            this.lblPhanLoai.AutoSize = true;
            this.lblPhanLoai.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPhanLoai.Location = new System.Drawing.Point(19, 72);
            this.lblPhanLoai.Name = "lblPhanLoai";
            this.lblPhanLoai.Size = new System.Drawing.Size(51, 13);
            this.lblPhanLoai.TabIndex = 4;
            this.lblPhanLoai.Text = "Phân loại";
            // 
            // lblBoPhan
            // 
            this.lblBoPhan.AutoSize = true;
            this.lblBoPhan.Location = new System.Drawing.Point(19, 126);
            this.lblBoPhan.Name = "lblBoPhan";
            this.lblBoPhan.Size = new System.Drawing.Size(47, 13);
            this.lblBoPhan.TabIndex = 8;
            this.lblBoPhan.Text = "Bộ phận";
            // 
            // cmbKyLuong
            // 
            this.cmbKyLuong.DisplayMember = "TenKy";
            this.cmbKyLuong.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007;
            this.cmbKyLuong.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.cmbKyLuong.Location = new System.Drawing.Point(83, 10);
            this.cmbKyLuong.Name = "cmbKyLuong";
            this.cmbKyLuong.Size = new System.Drawing.Size(212, 21);
            this.cmbKyLuong.TabIndex = 1;
            this.cmbKyLuong.ValueMember = "MaKy";
            this.cmbKyLuong.ValueChanged += new System.EventHandler(this.cmbKyLuong_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tháng lương";
            // 
            // boPhanListBindingSource
            // 
            this.boPhanListBindingSource.DataSource = typeof(ERP_Library.BoPhanList);
            // 
            // frmBaoCaoPhuCap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(659, 426);
            this.Controls.Add(this.pnlDieuKien);
            this.Controls.Add(this.treeReport);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmBaoCaoPhuCap";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Báo cáo phụ cấp";
            this.Load += new System.EventHandler(this.frmBaoCaoPhuCap_Load);
            this.pnlDieuKien.ResumeLayout(false);
            this.pnlDieuKien.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbKyTen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbKyPC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbNhomPC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbPhuCap)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbBoPhan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbNganHang)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbHinhThuc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbLoaiNV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbKyLuong)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.boPhanListBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView treeReport;

        private System.Windows.Forms.Panel pnlDieuKien;
        private Infragistics.Win.UltraWinEditors.UltraComboEditor cmbLoaiNV;
        private System.Windows.Forms.Label lblPhanLoai;
        private System.Windows.Forms.Label lblBoPhan;
        private Infragistics.Win.UltraWinEditors.UltraComboEditor cmbKyLuong;
        private System.Windows.Forms.Label label1;
        private Infragistics.Win.Misc.UltraButton btnClose;
        private Infragistics.Win.Misc.UltraButton btnReport;
        private System.Windows.Forms.Label lblNganHang;
        private Infragistics.Win.UltraWinEditors.UltraComboEditor cmbHinhThuc;
        private System.Windows.Forms.Label lblHinhThuc;
        private Infragistics.Win.UltraWinEditors.UltraComboEditor cmbNganHang;
        private Infragistics.Win.UltraWinGrid.UltraCombo cmbBoPhan;
        private System.Windows.Forms.BindingSource boPhanListBindingSource;
        private System.Windows.Forms.Label lblPhuCap;
        private Infragistics.Win.UltraWinEditors.UltraComboEditor cmbPhuCap;
        private Infragistics.Win.UltraWinEditors.UltraComboEditor cmbNhomPC;
        private System.Windows.Forms.Label lblNhomPC;
        private Infragistics.Win.UltraWinEditors.UltraComboEditor cmbKyPC;
        private System.Windows.Forms.Label label2;
        private Infragistics.Win.UltraWinEditors.UltraComboEditor cmbKyTen;
        private System.Windows.Forms.Label label3;
    }
}