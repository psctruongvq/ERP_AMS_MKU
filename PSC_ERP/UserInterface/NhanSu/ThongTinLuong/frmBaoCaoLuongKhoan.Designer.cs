namespace PSC_ERP
{
    partial class frmBaoCaoLuongKhoan
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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Tổng hợp các bộ phận");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Tổng hợp các ngân hàng");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Tổng hợp bộ phận của 1 ngân hàng");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("Tổng hợp thu tiền nhân viên");
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("Báo cáo tổng hợp", new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode3,
            treeNode4});
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("Bảng kê thu nhập nhóm theo bộ phận");
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("Bảng kê thu nhập phân loại theo ngân hàng");
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("Bảng kê lương nhân viên cho ngân hàng");
            System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("Bảng kê lương nhân viên loại khoán, hợp đồng");
            System.Windows.Forms.TreeNode treeNode10 = new System.Windows.Forms.TreeNode("Bảng kê lương nhân viên loại khoán, hợp đồng HTVC");
            System.Windows.Forms.TreeNode treeNode11 = new System.Windows.Forms.TreeNode("Bảng kê thu tiền nhân viên");
            System.Windows.Forms.TreeNode treeNode12 = new System.Windows.Forms.TreeNode("Bảng kê lương nhân viên loại khoán, hợp đồng(Không bảo hiểm)");
            System.Windows.Forms.TreeNode treeNode13 = new System.Windows.Forms.TreeNode("Bảng lương khoán/thử việc");
            System.Windows.Forms.TreeNode treeNode14 = new System.Windows.Forms.TreeNode("Báo cáo chi tiết", new System.Windows.Forms.TreeNode[] {
            treeNode6,
            treeNode7,
            treeNode8,
            treeNode9,
            treeNode10,
            treeNode11,
            treeNode12,
            treeNode13});
            System.Windows.Forms.TreeNode treeNode15 = new System.Windows.Forms.TreeNode("Bảng kê thu nhập", new System.Windows.Forms.TreeNode[] {
            treeNode5,
            treeNode14});
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.ValueListItem valueListItem1 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem2 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem3 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem4 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem5 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem6 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem7 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
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
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.ValueListItem valueListItem8 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem9 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem10 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            Infragistics.Win.ValueListItem valueListItem11 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem12 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem13 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem14 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem15 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem16 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem17 = new Infragistics.Win.ValueListItem();
            this.treeReport = new System.Windows.Forms.TreeView();
            this.pnlDieuKien = new System.Windows.Forms.Panel();
            this.cmbDieuKien = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.lblDieuKien = new System.Windows.Forms.Label();
            this.cmbKyTen = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNam = new System.Windows.Forms.NumericUpDown();
            this.lblNam = new System.Windows.Forms.Label();
            this.txtQui = new System.Windows.Forms.NumericUpDown();
            this.lblQui = new System.Windows.Forms.Label();
            this.cmbBoPhan = new Infragistics.Win.UltraWinGrid.UltraCombo();
            this.cmbNganHang = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.lblNganHang = new System.Windows.Forms.Label();
            this.cmbHinhThuc = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.lblHinhThuc = new System.Windows.Forms.Label();
            this.btnClose = new Infragistics.Win.Misc.UltraButton();
            this.btnReport = new Infragistics.Win.Misc.UltraButton();
            this.cmbLoaiNV = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.lblPhanLoai = new System.Windows.Forms.Label();
            this.txtDenNgay = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.lblDenNgay = new System.Windows.Forms.Label();
            this.lblBoPhan = new System.Windows.Forms.Label();
            this.cmbKyLuong = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.txtTuNgay = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.lblKyLuong = new System.Windows.Forms.Label();
            this.lblTuNgay = new System.Windows.Forms.Label();
            this.boPhanListBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.pnlDieuKien.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbDieuKien)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbKyTen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNam)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtQui)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbBoPhan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbNganHang)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbHinhThuc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbLoaiNV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDenNgay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbKyLuong)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTuNgay)).BeginInit();
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
            treeNode1.Name = "nodeTNTongHopBoPhan";
            treeNode1.Tag = "LoaiNV;HinhThuc;DieuKien";
            treeNode1.Text = "Tổng hợp các bộ phận";
            treeNode2.Name = "nodeTNTongHopNganHang";
            treeNode2.Tag = "LoaiNV;DieuKien";
            treeNode2.Text = "Tổng hợp các ngân hàng";
            treeNode3.Name = "nodeTNTongHopBoPhanNganHang";
            treeNode3.Tag = "LoaiNV;NganHang;DieuKien";
            treeNode3.Text = "Tổng hợp bộ phận của 1 ngân hàng";
            treeNode4.Name = "tonghopthutien";
            treeNode4.Text = "Tổng hợp thu tiền nhân viên";
            treeNode5.Name = "Node21";
            treeNode5.NodeFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            treeNode5.Text = "Báo cáo tổng hợp";
            treeNode6.Name = "nodeTNBoPhan";
            treeNode6.Tag = "LoaiNV;HinhThuc;BoPhan;DieuKien";
            treeNode6.Text = "Bảng kê thu nhập nhóm theo bộ phận";
            treeNode7.Name = "nodeTNNganHang";
            treeNode7.Tag = "LoaiNV;BoPhan;NganHang;DieuKien";
            treeNode7.Text = "Bảng kê thu nhập phân loại theo ngân hàng";
            treeNode8.Name = "nodeSoNganHang";
            treeNode8.Tag = "LoaiNV;BoPhan;NganHang;DieuKien";
            treeNode8.Text = "Bảng kê lương nhân viên cho ngân hàng";
            treeNode9.Name = "nodeLuongKhoan";
            treeNode9.Tag = "BoPhan;LoaiNV;DieuKien";
            treeNode9.Text = "Bảng kê lương nhân viên loại khoán, hợp đồng";
            treeNode10.Name = "nodeLuongKhoanHTVC";
            treeNode10.Tag = "BoPhan;LoaiNV;DieuKien";
            treeNode10.Text = "Bảng kê lương nhân viên loại khoán, hợp đồng HTVC";
            treeNode11.Name = "danhsachthutien";
            treeNode11.Text = "Bảng kê thu tiền nhân viên";
            treeNode12.Name = "nodeLuongKhoanKoCoBH";
            treeNode12.Tag = "BoPhan;LoaiNV";
            treeNode12.Text = "Bảng kê lương nhân viên loại khoán, hợp đồng(Không bảo hiểm)";
            treeNode13.Name = "NodeCTV";
            treeNode13.Tag = "BoPhan;LoaiNV";
            treeNode13.Text = "Bảng lương khoán/thử việc";
            treeNode14.Name = "Node22";
            treeNode14.NodeFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            treeNode14.Text = "Báo cáo chi tiết";
            treeNode15.Name = "Node2";
            treeNode15.NodeFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            treeNode15.Text = "Bảng kê thu nhập";
            this.treeReport.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode15});
            this.treeReport.Size = new System.Drawing.Size(414, 426);
            this.treeReport.TabIndex = 0;
            this.treeReport.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeReport_AfterSelect);
            // 
            // pnlDieuKien
            // 
            this.pnlDieuKien.Controls.Add(this.cmbDieuKien);
            this.pnlDieuKien.Controls.Add(this.lblDieuKien);
            this.pnlDieuKien.Controls.Add(this.cmbKyTen);
            this.pnlDieuKien.Controls.Add(this.label1);
            this.pnlDieuKien.Controls.Add(this.txtNam);
            this.pnlDieuKien.Controls.Add(this.lblNam);
            this.pnlDieuKien.Controls.Add(this.txtQui);
            this.pnlDieuKien.Controls.Add(this.lblQui);
            this.pnlDieuKien.Controls.Add(this.cmbBoPhan);
            this.pnlDieuKien.Controls.Add(this.cmbNganHang);
            this.pnlDieuKien.Controls.Add(this.lblNganHang);
            this.pnlDieuKien.Controls.Add(this.cmbHinhThuc);
            this.pnlDieuKien.Controls.Add(this.lblHinhThuc);
            this.pnlDieuKien.Controls.Add(this.btnClose);
            this.pnlDieuKien.Controls.Add(this.btnReport);
            this.pnlDieuKien.Controls.Add(this.cmbLoaiNV);
            this.pnlDieuKien.Controls.Add(this.lblPhanLoai);
            this.pnlDieuKien.Controls.Add(this.txtDenNgay);
            this.pnlDieuKien.Controls.Add(this.lblDenNgay);
            this.pnlDieuKien.Controls.Add(this.lblBoPhan);
            this.pnlDieuKien.Controls.Add(this.cmbKyLuong);
            this.pnlDieuKien.Controls.Add(this.txtTuNgay);
            this.pnlDieuKien.Controls.Add(this.lblKyLuong);
            this.pnlDieuKien.Controls.Add(this.lblTuNgay);
            this.pnlDieuKien.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDieuKien.Location = new System.Drawing.Point(414, 0);
            this.pnlDieuKien.Name = "pnlDieuKien";
            this.pnlDieuKien.Size = new System.Drawing.Size(331, 426);
            this.pnlDieuKien.TabIndex = 1;
            // 
            // cmbDieuKien
            // 
            appearance1.BackColor = System.Drawing.SystemColors.Info;
            this.cmbDieuKien.Appearance = appearance1;
            this.cmbDieuKien.BackColor = System.Drawing.SystemColors.Info;
            this.cmbDieuKien.DisplayMember = "";
            this.cmbDieuKien.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007;
            this.cmbDieuKien.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            valueListItem1.DataValue = 0;
            valueListItem1.DisplayText = "Tất cả";
            valueListItem2.DataValue = 1;
            valueListItem2.DisplayText = "Thu nhập còn lại >= 0";
            valueListItem3.DataValue = 2;
            valueListItem3.DisplayText = "Thu nhập còn lại < 0";
            this.cmbDieuKien.Items.AddRange(new Infragistics.Win.ValueListItem[] {
            valueListItem1,
            valueListItem2,
            valueListItem3});
            this.cmbDieuKien.Location = new System.Drawing.Point(70, 208);
            this.cmbDieuKien.Name = "cmbDieuKien";
            this.cmbDieuKien.Size = new System.Drawing.Size(212, 21);
            this.cmbDieuKien.TabIndex = 24;
            this.cmbDieuKien.ValueMember = "";
            // 
            // lblDieuKien
            // 
            this.lblDieuKien.AutoSize = true;
            this.lblDieuKien.Location = new System.Drawing.Point(6, 216);
            this.lblDieuKien.Name = "lblDieuKien";
            this.lblDieuKien.Size = new System.Drawing.Size(52, 13);
            this.lblDieuKien.TabIndex = 23;
            this.lblDieuKien.Text = "Điều kiện";
            // 
            // cmbKyTen
            // 
            this.cmbKyTen.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007;
            this.cmbKyTen.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            valueListItem4.DataValue = 0;
            valueListItem4.DisplayText = "Không có";
            valueListItem5.DataValue = 1;
            valueListItem5.DisplayText = "Người lập";
            valueListItem6.DataValue = 2;
            valueListItem6.DisplayText = "Người lập, Thủ trưởng";
            valueListItem7.DataValue = 3;
            valueListItem7.DisplayText = "Người lập, BPT, Thủ trưởng";
            this.cmbKyTen.Items.AddRange(new Infragistics.Win.ValueListItem[] {
            valueListItem4,
            valueListItem5,
            valueListItem6,
            valueListItem7});
            this.cmbKyTen.Location = new System.Drawing.Point(70, 255);
            this.cmbKyTen.Name = "cmbKyTen";
            this.cmbKyTen.Size = new System.Drawing.Size(212, 21);
            this.cmbKyTen.TabIndex = 22;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 263);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 21;
            this.label1.Text = "Ký tên";
            // 
            // txtNam
            // 
            this.txtNam.Location = new System.Drawing.Point(154, 182);
            this.txtNam.Maximum = new decimal(new int[] {
            3000,
            0,
            0,
            0});
            this.txtNam.Minimum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.txtNam.Name = "txtNam";
            this.txtNam.Size = new System.Drawing.Size(63, 20);
            this.txtNam.TabIndex = 20;
            this.txtNam.Value = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            // 
            // lblNam
            // 
            this.lblNam.AutoSize = true;
            this.lblNam.Location = new System.Drawing.Point(123, 189);
            this.lblNam.Name = "lblNam";
            this.lblNam.Size = new System.Drawing.Size(25, 13);
            this.lblNam.TabIndex = 19;
            this.lblNam.Text = "Quí";
            // 
            // txtQui
            // 
            this.txtQui.Location = new System.Drawing.Point(70, 182);
            this.txtQui.Maximum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.txtQui.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.txtQui.Name = "txtQui";
            this.txtQui.Size = new System.Drawing.Size(37, 20);
            this.txtQui.TabIndex = 18;
            this.txtQui.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lblQui
            // 
            this.lblQui.AutoSize = true;
            this.lblQui.Location = new System.Drawing.Point(6, 189);
            this.lblQui.Name = "lblQui";
            this.lblQui.Size = new System.Drawing.Size(25, 13);
            this.lblQui.TabIndex = 17;
            this.lblQui.Text = "Quí";
            // 
            // cmbBoPhan
            // 
            this.cmbBoPhan.DataSource = this.boPhanListBindingSource;
            appearance2.BackColor = System.Drawing.SystemColors.ControlLight;
            appearance2.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance2.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            this.cmbBoPhan.DisplayLayout.Appearance = appearance2;
            ultraGridColumn1.Header.VisiblePosition = 0;
            ultraGridColumn2.Header.VisiblePosition = 1;
            ultraGridColumn2.Hidden = true;
            ultraGridColumn3.Header.Caption = "Mã BP";
            ultraGridColumn3.Header.VisiblePosition = 2;
            ultraGridColumn3.Width = 59;
            ultraGridColumn4.Header.Caption = "Tên bộ phận";
            ultraGridColumn4.Header.VisiblePosition = 3;
            ultraGridColumn4.Width = 182;
            ultraGridColumn5.Header.VisiblePosition = 4;
            ultraGridColumn5.Hidden = true;
            ultraGridColumn6.Header.VisiblePosition = 5;
            ultraGridColumn6.Hidden = true;
            ultraGridColumn7.Header.VisiblePosition = 6;
            ultraGridColumn7.Hidden = true;
            ultraGridColumn8.Header.VisiblePosition = 7;
            ultraGridColumn8.Hidden = true;
            ultraGridColumn9.Header.VisiblePosition = 9;
            ultraGridColumn9.Hidden = true;
            ultraGridColumn10.Header.VisiblePosition = 10;
            ultraGridColumn11.Header.VisiblePosition = 8;
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
            this.cmbBoPhan.DisplayLayout.BandsSerializer.Add(ultraGridBand1);
            this.cmbBoPhan.DisplayLayout.InterBandSpacing = 10;
            this.cmbBoPhan.DisplayLayout.MaxColScrollRegions = 1;
            this.cmbBoPhan.DisplayLayout.MaxRowScrollRegions = 1;
            appearance3.BackColor = System.Drawing.Color.Transparent;
            this.cmbBoPhan.DisplayLayout.Override.CardAreaAppearance = appearance3;
            appearance4.BackColor = System.Drawing.SystemColors.Control;
            appearance4.BackColor2 = System.Drawing.SystemColors.ControlLightLight;
            appearance4.BackGradientStyle = Infragistics.Win.GradientStyle.VerticalBump;
            this.cmbBoPhan.DisplayLayout.Override.CellAppearance = appearance4;
            this.cmbBoPhan.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText;
            appearance5.BackColor = System.Drawing.SystemColors.Control;
            appearance5.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance5.BackGradientStyle = Infragistics.Win.GradientStyle.VerticalBump;
            appearance5.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent;
            this.cmbBoPhan.DisplayLayout.Override.HeaderAppearance = appearance5;
            this.cmbBoPhan.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            appearance6.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.cmbBoPhan.DisplayLayout.Override.RowSelectorAppearance = appearance6;
            appearance7.BackColor = System.Drawing.SystemColors.InactiveCaption;
            appearance7.BackColor2 = System.Drawing.SystemColors.ActiveCaption;
            appearance7.BackGradientStyle = Infragistics.Win.GradientStyle.VerticalBump;
            this.cmbBoPhan.DisplayLayout.Override.SelectedRowAppearance = appearance7;
            this.cmbBoPhan.DisplayLayout.RowConnectorColor = System.Drawing.SystemColors.ControlDarkDark;
            this.cmbBoPhan.DisplayLayout.RowConnectorStyle = Infragistics.Win.UltraWinGrid.RowConnectorStyle.Dashed;
            this.cmbBoPhan.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.cmbBoPhan.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.cmbBoPhan.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy;
            this.cmbBoPhan.DisplayMember = "TenBoPhan";
            this.cmbBoPhan.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007;
            this.cmbBoPhan.DropDownStyle = Infragistics.Win.UltraWinGrid.UltraComboStyle.DropDownList;
            this.cmbBoPhan.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.cmbBoPhan.Location = new System.Drawing.Point(70, 127);
            this.cmbBoPhan.Name = "cmbBoPhan";
            this.cmbBoPhan.Size = new System.Drawing.Size(212, 22);
            this.cmbBoPhan.TabIndex = 11;
            this.cmbBoPhan.ValueMember = "MaBoPhan";
            // 
            // cmbNganHang
            // 
            this.cmbNganHang.DisplayMember = "TenNganHang";
            this.cmbNganHang.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007;
            this.cmbNganHang.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.cmbNganHang.Location = new System.Drawing.Point(70, 155);
            this.cmbNganHang.Name = "cmbNganHang";
            this.cmbNganHang.Size = new System.Drawing.Size(212, 21);
            this.cmbNganHang.TabIndex = 13;
            this.cmbNganHang.ValueMember = "MaNganHang";
            // 
            // lblNganHang
            // 
            this.lblNganHang.AutoSize = true;
            this.lblNganHang.Location = new System.Drawing.Point(6, 164);
            this.lblNganHang.Name = "lblNganHang";
            this.lblNganHang.Size = new System.Drawing.Size(60, 13);
            this.lblNganHang.TabIndex = 12;
            this.lblNganHang.Text = "Ngân hàng";
            // 
            // cmbHinhThuc
            // 
            appearance8.BackColor = System.Drawing.SystemColors.Info;
            this.cmbHinhThuc.Appearance = appearance8;
            this.cmbHinhThuc.BackColor = System.Drawing.SystemColors.Info;
            this.cmbHinhThuc.DisplayMember = "";
            this.cmbHinhThuc.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007;
            this.cmbHinhThuc.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            valueListItem8.DataValue = "All";
            valueListItem8.DisplayText = "Tất cả";
            valueListItem9.DataValue = "CK";
            valueListItem9.DisplayText = "Chuyển khoản NH";
            valueListItem10.DataValue = "TM";
            valueListItem10.DisplayText = "Tiền mặt";
            this.cmbHinhThuc.Items.AddRange(new Infragistics.Win.ValueListItem[] {
            valueListItem8,
            valueListItem9,
            valueListItem10});
            this.cmbHinhThuc.Location = new System.Drawing.Point(70, 101);
            this.cmbHinhThuc.Name = "cmbHinhThuc";
            this.cmbHinhThuc.Size = new System.Drawing.Size(212, 21);
            this.cmbHinhThuc.TabIndex = 9;
            this.cmbHinhThuc.ValueMember = "";
            // 
            // lblHinhThuc
            // 
            this.lblHinhThuc.AutoSize = true;
            this.lblHinhThuc.Location = new System.Drawing.Point(6, 109);
            this.lblHinhThuc.Name = "lblHinhThuc";
            this.lblHinhThuc.Size = new System.Drawing.Size(53, 13);
            this.lblHinhThuc.TabIndex = 8;
            this.lblHinhThuc.Text = "Hình thức";
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnClose.Location = new System.Drawing.Point(154, 382);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(91, 32);
            this.btnClose.TabIndex = 16;
            this.btnClose.Text = "Đóng";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnReport
            // 
            this.btnReport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnReport.Location = new System.Drawing.Point(57, 382);
            this.btnReport.Name = "btnReport";
            this.btnReport.Size = new System.Drawing.Size(91, 32);
            this.btnReport.TabIndex = 15;
            this.btnReport.Text = "Báo cáo";
            this.btnReport.Click += new System.EventHandler(this.btnReport_Click);
            // 
            // cmbLoaiNV
            // 
            appearance9.BackColor = System.Drawing.SystemColors.Info;
            this.cmbLoaiNV.Appearance = appearance9;
            this.cmbLoaiNV.BackColor = System.Drawing.SystemColors.Info;
            this.cmbLoaiNV.DisplayMember = "";
            this.cmbLoaiNV.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007;
            this.cmbLoaiNV.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            valueListItem11.DataValue = "All";
            valueListItem11.DisplayText = "Tất cả";
            valueListItem12.DataValue = "BC";
            valueListItem12.DisplayText = "Biên chế và hợp đồng";
            valueListItem13.DataValue = "VV";
            valueListItem13.DisplayText = "Hợp đồng vụ việc";
            valueListItem14.DataValue = "KhoanTN";
            valueListItem14.DisplayText = "Lương khoán (tính thâm niên)";
            valueListItem15.DataValue = "KhoanKTN";
            valueListItem15.DisplayText = "Lương khoán (không tính thâm niên)";
            valueListItem16.DataValue = "Khoan";
            valueListItem16.DisplayText = "Lương Khoán";
            valueListItem17.DataValue = "CTV";
            valueListItem17.DisplayText = "Cộng tác viên";
            this.cmbLoaiNV.Items.AddRange(new Infragistics.Win.ValueListItem[] {
            valueListItem11,
            valueListItem12,
            valueListItem13,
            valueListItem14,
            valueListItem15,
            valueListItem16,
            valueListItem17});
            this.cmbLoaiNV.Location = new System.Drawing.Point(70, 74);
            this.cmbLoaiNV.Name = "cmbLoaiNV";
            this.cmbLoaiNV.Size = new System.Drawing.Size(212, 21);
            this.cmbLoaiNV.TabIndex = 7;
            this.cmbLoaiNV.ValueMember = "";
            // 
            // lblPhanLoai
            // 
            this.lblPhanLoai.AutoSize = true;
            this.lblPhanLoai.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPhanLoai.Location = new System.Drawing.Point(6, 82);
            this.lblPhanLoai.Name = "lblPhanLoai";
            this.lblPhanLoai.Size = new System.Drawing.Size(51, 13);
            this.lblPhanLoai.TabIndex = 6;
            this.lblPhanLoai.Text = "Phân loại";
            // 
            // txtDenNgay
            // 
            this.txtDenNgay.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007;
            this.txtDenNgay.Enabled = false;
            this.txtDenNgay.Location = new System.Drawing.Point(208, 47);
            this.txtDenNgay.Name = "txtDenNgay";
            this.txtDenNgay.Size = new System.Drawing.Size(74, 21);
            this.txtDenNgay.TabIndex = 5;
            // 
            // lblDenNgay
            // 
            this.lblDenNgay.AutoSize = true;
            this.lblDenNgay.Location = new System.Drawing.Point(150, 55);
            this.lblDenNgay.Name = "lblDenNgay";
            this.lblDenNgay.Size = new System.Drawing.Size(52, 13);
            this.lblDenNgay.TabIndex = 4;
            this.lblDenNgay.Text = "đến ngày";
            // 
            // lblBoPhan
            // 
            this.lblBoPhan.AutoSize = true;
            this.lblBoPhan.Location = new System.Drawing.Point(6, 136);
            this.lblBoPhan.Name = "lblBoPhan";
            this.lblBoPhan.Size = new System.Drawing.Size(47, 13);
            this.lblBoPhan.TabIndex = 10;
            this.lblBoPhan.Text = "Bộ phận";
            // 
            // cmbKyLuong
            // 
            this.cmbKyLuong.DisplayMember = "TenKy";
            this.cmbKyLuong.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007;
            this.cmbKyLuong.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.cmbKyLuong.Location = new System.Drawing.Point(70, 20);
            this.cmbKyLuong.Name = "cmbKyLuong";
            this.cmbKyLuong.Size = new System.Drawing.Size(212, 21);
            this.cmbKyLuong.TabIndex = 1;
            this.cmbKyLuong.ValueMember = "MaKy";
            this.cmbKyLuong.ValueChanged += new System.EventHandler(this.cmbKyLuong_ValueChanged);
            // 
            // txtTuNgay
            // 
            this.txtTuNgay.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007;
            this.txtTuNgay.Enabled = false;
            this.txtTuNgay.Location = new System.Drawing.Point(70, 47);
            this.txtTuNgay.Name = "txtTuNgay";
            this.txtTuNgay.Size = new System.Drawing.Size(74, 21);
            this.txtTuNgay.TabIndex = 3;
            // 
            // lblKyLuong
            // 
            this.lblKyLuong.AutoSize = true;
            this.lblKyLuong.Location = new System.Drawing.Point(6, 28);
            this.lblKyLuong.Name = "lblKyLuong";
            this.lblKyLuong.Size = new System.Drawing.Size(67, 13);
            this.lblKyLuong.TabIndex = 0;
            this.lblKyLuong.Text = "Tháng lương";
            // 
            // lblTuNgay
            // 
            this.lblTuNgay.AutoSize = true;
            this.lblTuNgay.Location = new System.Drawing.Point(6, 55);
            this.lblTuNgay.Name = "lblTuNgay";
            this.lblTuNgay.Size = new System.Drawing.Size(46, 13);
            this.lblTuNgay.TabIndex = 2;
            this.lblTuNgay.Text = "Từ ngày";
            // 
            // boPhanListBindingSource
            // 
            this.boPhanListBindingSource.DataSource = typeof(ERP_Library.BoPhanList);
            // 
            // frmBaoCaoLuongKhoan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(745, 426);
            this.Controls.Add(this.pnlDieuKien);
            this.Controls.Add(this.treeReport);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmBaoCaoLuongKhoan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Báo cáo bảng lương khoán và thử việc";
            this.Load += new System.EventHandler(this.frmBaoCaoBangLuong_Load);
            this.pnlDieuKien.ResumeLayout(false);
            this.pnlDieuKien.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbDieuKien)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbKyTen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNam)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtQui)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbBoPhan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbNganHang)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbHinhThuc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbLoaiNV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDenNgay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbKyLuong)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTuNgay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.boPhanListBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView treeReport;
        private System.Windows.Forms.Panel pnlDieuKien;
        private Infragistics.Win.UltraWinEditors.UltraComboEditor cmbLoaiNV;
        private System.Windows.Forms.Label lblPhanLoai;
        private Infragistics.Win.UltraWinEditors.UltraTextEditor txtDenNgay;
        private System.Windows.Forms.Label lblDenNgay;
        private System.Windows.Forms.Label lblBoPhan;
        private Infragistics.Win.UltraWinEditors.UltraComboEditor cmbKyLuong;
        private Infragistics.Win.UltraWinEditors.UltraTextEditor txtTuNgay;
        private System.Windows.Forms.Label lblKyLuong;
        private System.Windows.Forms.Label lblTuNgay;
        private Infragistics.Win.Misc.UltraButton btnClose;
        private Infragistics.Win.Misc.UltraButton btnReport;
        private System.Windows.Forms.Label lblNganHang;
        private Infragistics.Win.UltraWinEditors.UltraComboEditor cmbHinhThuc;
        private System.Windows.Forms.Label lblHinhThuc;
        private Infragistics.Win.UltraWinEditors.UltraComboEditor cmbNganHang;
        private Infragistics.Win.UltraWinGrid.UltraCombo cmbBoPhan;
        private System.Windows.Forms.BindingSource boPhanListBindingSource;
        private System.Windows.Forms.Label lblQui;
        private System.Windows.Forms.NumericUpDown txtQui;
        private System.Windows.Forms.NumericUpDown txtNam;
        private System.Windows.Forms.Label lblNam;
        private Infragistics.Win.UltraWinEditors.UltraComboEditor cmbKyTen;
        private System.Windows.Forms.Label label1;
        private Infragistics.Win.UltraWinEditors.UltraComboEditor cmbDieuKien;
        private System.Windows.Forms.Label lblDieuKien;
    }
}