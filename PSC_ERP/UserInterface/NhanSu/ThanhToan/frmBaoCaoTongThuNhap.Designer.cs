namespace PSC_ERP
{
    partial class frmBaoCaoTongThuNhap
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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Báo Cáo Tổng Hợp Có Tính Thuế");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Báo Cáo Chi Tiết Có Tính Thuế");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Chi Tiết Tổng Thu Nhập, Thu Nhập Chịu Thuế và Thuế Thu Nhập Cá Nhân");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("Tổng Hợp Tổng Thu Nhập, Thu Nhập Chịu Thuế và Thuế Thu Nhập Cá Nhân");
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("Chi Tiết Thuế TNCN Theo Tháng");
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("Tổng Hợp Thuế TNCN Theo Tháng");
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("Tổng Hợp Tạm Thu Thuế TNCN");
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
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.ValueListItem valueListItem1 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem2 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem3 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem4 = new Infragistics.Win.ValueListItem();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBaoCaoTongThuNhap));
            DevExpress.Utils.SuperToolTip superToolTip1 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem1 = new DevExpress.Utils.ToolTipTitleItem();
            DevExpress.Utils.SuperToolTip superToolTip2 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem2 = new DevExpress.Utils.ToolTipTitleItem();
            DevExpress.Utils.SuperToolTip superToolTip3 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem3 = new DevExpress.Utils.ToolTipTitleItem();
            this.treeReport = new System.Windows.Forms.TreeView();
            this.pnlDieuKien = new System.Windows.Forms.Panel();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.checkChayTheoNam = new System.Windows.Forms.CheckBox();
            this.cmbBoPhan = new Infragistics.Win.UltraWinGrid.UltraCombo();
            this.boPhanListBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.txtDenNgay = new Infragistics.Win.UltraWinEditors.UltraDateTimeEditor();
            this.txtTuNgay = new Infragistics.Win.UltraWinEditors.UltraDateTimeEditor();
            this.cmbKyTen = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.cmbDenKyLuong = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.cmbKyLuong = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.item_cmbKyLuong = new DevExpress.XtraLayout.LayoutControlItem();
            this.item_cmbDenKyLuong = new DevExpress.XtraLayout.LayoutControlItem();
            this.item_cmbKyTen = new DevExpress.XtraLayout.LayoutControlItem();
            this.item_txtTuNgay = new DevExpress.XtraLayout.LayoutControlItem();
            this.item_txtDenNgay = new DevExpress.XtraLayout.LayoutControlItem();
            this.item_cmbBoPhan = new DevExpress.XtraLayout.LayoutControlItem();
            this.item_checkChayTheoNam = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.defaultLookAndFeel1 = new DevExpress.LookAndFeel.DefaultLookAndFeel(this.components);
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.mainMenuBarManager = new DevExpress.XtraBars.BarManager(this.components);
            this.mainMenuBar = new DevExpress.XtraBars.Bar();
            this.barbt_Xem = new DevExpress.XtraBars.BarButtonItem();
            this.btnThoat = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.btnThemMoi = new DevExpress.XtraBars.BarButtonItem();
            this.pnlDieuKien.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbBoPhan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.boPhanListBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDenNgay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTuNgay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbKyTen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbDenKyLuong)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbKyLuong)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.item_cmbKyLuong)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.item_cmbDenKyLuong)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.item_cmbKyTen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.item_txtTuNgay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.item_txtDenNgay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.item_cmbBoPhan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.item_checkChayTheoNam)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mainMenuBarManager)).BeginInit();
            this.SuspendLayout();
            // 
            // treeReport
            // 
            this.treeReport.Dock = System.Windows.Forms.DockStyle.Left;
            this.treeReport.FullRowSelect = true;
            this.treeReport.HideSelection = false;
            this.treeReport.Location = new System.Drawing.Point(0, 34);
            this.treeReport.Name = "treeReport";
            treeNode1.Name = "NodeBaoCaoTongHopThuNhapCoTinhThue";
            treeNode1.Text = "Báo Cáo Tổng Hợp Có Tính Thuế";
            treeNode2.Name = "NodeBaoCaoChiTietThuNhapCoTinhThue";
            treeNode2.Text = "Báo Cáo Chi Tiết Có Tính Thuế";
            treeNode3.Name = "NodeDanhSachTongHopThueTNCN";
            treeNode3.Text = "Chi Tiết Tổng Thu Nhập, Thu Nhập Chịu Thuế và Thuế Thu Nhập Cá Nhân";
            treeNode4.Name = "NodeTongHopTongThuNhapCaNhan";
            treeNode4.Text = "Tổng Hợp Tổng Thu Nhập, Thu Nhập Chịu Thuế và Thuế Thu Nhập Cá Nhân";
            treeNode5.Name = "NodeChiTietTNCN_TheoThang";
            treeNode5.Text = "Chi Tiết Thuế TNCN Theo Tháng";
            treeNode6.Name = "NodeTongHopTNCN_TheoThang";
            treeNode6.Text = "Tổng Hợp Thuế TNCN Theo Tháng";
            treeNode7.Name = "NodeTongHopThueTNCNTheoThang";
            treeNode7.Text = "Tổng Hợp Tạm Thu Thuế TNCN";
            this.treeReport.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode3,
            treeNode4,
            treeNode5,
            treeNode6,
            treeNode7});
            this.treeReport.Size = new System.Drawing.Size(410, 265);
            this.treeReport.TabIndex = 0;
            this.treeReport.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeReport_AfterSelect);
            // 
            // pnlDieuKien
            // 
            this.pnlDieuKien.Controls.Add(this.layoutControl1);
            this.pnlDieuKien.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlDieuKien.Location = new System.Drawing.Point(410, 34);
            this.pnlDieuKien.Name = "pnlDieuKien";
            this.pnlDieuKien.Size = new System.Drawing.Size(279, 267);
            this.pnlDieuKien.TabIndex = 1;
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.checkChayTheoNam);
            this.layoutControl1.Controls.Add(this.cmbBoPhan);
            this.layoutControl1.Controls.Add(this.txtDenNgay);
            this.layoutControl1.Controls.Add(this.txtTuNgay);
            this.layoutControl1.Controls.Add(this.cmbKyTen);
            this.layoutControl1.Controls.Add(this.cmbDenKyLuong);
            this.layoutControl1.Controls.Add(this.cmbKyLuong);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(279, 267);
            this.layoutControl1.TabIndex = 34;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // checkChayTheoNam
            // 
            this.checkChayTheoNam.Location = new System.Drawing.Point(12, 132);
            this.checkChayTheoNam.Name = "checkChayTheoNam";
            this.checkChayTheoNam.Size = new System.Drawing.Size(255, 20);
            this.checkChayTheoNam.TabIndex = 33;
            this.checkChayTheoNam.Text = "Chạy Theo Năm";
            this.checkChayTheoNam.UseVisualStyleBackColor = true;
            // 
            // cmbBoPhan
            // 
            this.cmbBoPhan.AutoSize = false;
            this.cmbBoPhan.DataSource = this.boPhanListBindingSource;
            appearance1.BackColor = System.Drawing.SystemColors.ControlLight;
            appearance1.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance1.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            this.cmbBoPhan.DisplayLayout.Appearance = appearance1;
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
            ultraGridColumn9.Header.VisiblePosition = 8;
            ultraGridColumn9.Hidden = true;
            ultraGridColumn10.Header.VisiblePosition = 10;
            ultraGridColumn11.Header.VisiblePosition = 9;
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
            appearance2.BackColor = System.Drawing.Color.Transparent;
            this.cmbBoPhan.DisplayLayout.Override.CardAreaAppearance = appearance2;
            appearance3.BackColor = System.Drawing.SystemColors.Control;
            appearance3.BackColor2 = System.Drawing.SystemColors.ControlLightLight;
            appearance3.BackGradientStyle = Infragistics.Win.GradientStyle.VerticalBump;
            this.cmbBoPhan.DisplayLayout.Override.CellAppearance = appearance3;
            this.cmbBoPhan.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText;
            appearance4.BackColor = System.Drawing.SystemColors.Control;
            appearance4.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance4.BackGradientStyle = Infragistics.Win.GradientStyle.VerticalBump;
            appearance4.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent;
            this.cmbBoPhan.DisplayLayout.Override.HeaderAppearance = appearance4;
            this.cmbBoPhan.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            appearance5.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.cmbBoPhan.DisplayLayout.Override.RowSelectorAppearance = appearance5;
            appearance6.BackColor = System.Drawing.SystemColors.InactiveCaption;
            appearance6.BackColor2 = System.Drawing.SystemColors.ActiveCaption;
            appearance6.BackGradientStyle = Infragistics.Win.GradientStyle.VerticalBump;
            this.cmbBoPhan.DisplayLayout.Override.SelectedRowAppearance = appearance6;
            this.cmbBoPhan.DisplayLayout.RowConnectorColor = System.Drawing.SystemColors.ControlDarkDark;
            this.cmbBoPhan.DisplayLayout.RowConnectorStyle = Infragistics.Win.UltraWinGrid.RowConnectorStyle.Dashed;
            this.cmbBoPhan.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.cmbBoPhan.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.cmbBoPhan.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy;
            this.cmbBoPhan.DisplayMember = "TenBoPhan";
            this.cmbBoPhan.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007;
            this.cmbBoPhan.DropDownStyle = Infragistics.Win.UltraWinGrid.UltraComboStyle.DropDownList;
            this.cmbBoPhan.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.cmbBoPhan.Location = new System.Drawing.Point(62, 108);
            this.cmbBoPhan.Name = "cmbBoPhan";
            this.cmbBoPhan.Size = new System.Drawing.Size(205, 20);
            this.cmbBoPhan.TabIndex = 12;
            this.cmbBoPhan.ValueMember = "MaBoPhan";
            this.cmbBoPhan.ValueChanged += new System.EventHandler(this.cmbBoPhan_ValueChanged);
            // 
            // boPhanListBindingSource
            // 
            this.boPhanListBindingSource.DataSource = typeof(ERP_Library.BoPhanList);
            // 
            // txtDenNgay
            // 
            this.txtDenNgay.AutoSize = false;
            this.txtDenNgay.DateTime = new System.DateTime(2012, 1, 5, 0, 0, 0, 0);
            this.txtDenNgay.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007;
            this.txtDenNgay.Location = new System.Drawing.Point(62, 36);
            this.txtDenNgay.Name = "txtDenNgay";
            this.txtDenNgay.Size = new System.Drawing.Size(205, 20);
            this.txtDenNgay.TabIndex = 27;
            this.txtDenNgay.Value = new System.DateTime(2012, 1, 5, 0, 0, 0, 0);
            // 
            // txtTuNgay
            // 
            this.txtTuNgay.AutoSize = false;
            this.txtTuNgay.DateTime = new System.DateTime(2012, 1, 5, 0, 0, 0, 0);
            this.txtTuNgay.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007;
            this.txtTuNgay.Location = new System.Drawing.Point(62, 12);
            this.txtTuNgay.Name = "txtTuNgay";
            this.txtTuNgay.Size = new System.Drawing.Size(205, 20);
            this.txtTuNgay.TabIndex = 25;
            this.txtTuNgay.Value = new System.DateTime(2012, 1, 5, 0, 0, 0, 0);
            // 
            // cmbKyTen
            // 
            this.cmbKyTen.AutoSize = false;
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
            this.cmbKyTen.Location = new System.Drawing.Point(62, 156);
            this.cmbKyTen.Name = "cmbKyTen";
            this.cmbKyTen.Size = new System.Drawing.Size(205, 20);
            this.cmbKyTen.TabIndex = 22;
            this.cmbKyTen.Visible = false;
            // 
            // cmbDenKyLuong
            // 
            this.cmbDenKyLuong.AutoSize = false;
            this.cmbDenKyLuong.DisplayMember = "TenKy";
            this.cmbDenKyLuong.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007;
            this.cmbDenKyLuong.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.cmbDenKyLuong.Location = new System.Drawing.Point(62, 84);
            this.cmbDenKyLuong.Name = "cmbDenKyLuong";
            this.cmbDenKyLuong.Size = new System.Drawing.Size(205, 20);
            this.cmbDenKyLuong.TabIndex = 32;
            this.cmbDenKyLuong.ValueMember = "MaKy";
            // 
            // cmbKyLuong
            // 
            this.cmbKyLuong.AutoSize = false;
            this.cmbKyLuong.DisplayMember = "TenKy";
            this.cmbKyLuong.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007;
            this.cmbKyLuong.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.cmbKyLuong.Location = new System.Drawing.Point(62, 60);
            this.cmbKyLuong.Name = "cmbKyLuong";
            this.cmbKyLuong.Size = new System.Drawing.Size(205, 20);
            this.cmbKyLuong.TabIndex = 29;
            this.cmbKyLuong.ValueMember = "MaKy";
            this.cmbKyLuong.ValueChanged += new System.EventHandler(this.cmbKyLuong_ValueChanged);
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.item_cmbKyLuong,
            this.item_cmbDenKyLuong,
            this.item_cmbKyTen,
            this.item_txtTuNgay,
            this.item_txtDenNgay,
            this.item_cmbBoPhan,
            this.item_checkChayTheoNam,
            this.emptySpaceItem2});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(279, 267);
            this.layoutControlGroup1.Text = "layoutControlGroup1";
            this.layoutControlGroup1.TextVisible = false;
            // 
            // item_cmbKyLuong
            // 
            this.item_cmbKyLuong.Control = this.cmbKyLuong;
            this.item_cmbKyLuong.CustomizationFormText = "Từ kỳ";
            this.item_cmbKyLuong.Location = new System.Drawing.Point(0, 48);
            this.item_cmbKyLuong.Name = "item_cmbKyLuong";
            this.item_cmbKyLuong.Size = new System.Drawing.Size(259, 24);
            this.item_cmbKyLuong.Text = "Từ kỳ";
            this.item_cmbKyLuong.TextSize = new System.Drawing.Size(47, 13);
            // 
            // item_cmbDenKyLuong
            // 
            this.item_cmbDenKyLuong.Control = this.cmbDenKyLuong;
            this.item_cmbDenKyLuong.CustomizationFormText = "Đến kỳ";
            this.item_cmbDenKyLuong.Location = new System.Drawing.Point(0, 72);
            this.item_cmbDenKyLuong.Name = "item_cmbDenKyLuong";
            this.item_cmbDenKyLuong.Size = new System.Drawing.Size(259, 24);
            this.item_cmbDenKyLuong.Text = "Đến kỳ";
            this.item_cmbDenKyLuong.TextSize = new System.Drawing.Size(47, 13);
            // 
            // item_cmbKyTen
            // 
            this.item_cmbKyTen.Control = this.cmbKyTen;
            this.item_cmbKyTen.CustomizationFormText = "Ký tên";
            this.item_cmbKyTen.Location = new System.Drawing.Point(0, 144);
            this.item_cmbKyTen.Name = "item_cmbKyTen";
            this.item_cmbKyTen.Size = new System.Drawing.Size(259, 24);
            this.item_cmbKyTen.Text = "Ký tên";
            this.item_cmbKyTen.TextSize = new System.Drawing.Size(47, 13);
            // 
            // item_txtTuNgay
            // 
            this.item_txtTuNgay.Control = this.txtTuNgay;
            this.item_txtTuNgay.CustomizationFormText = "Từ ngày";
            this.item_txtTuNgay.Location = new System.Drawing.Point(0, 0);
            this.item_txtTuNgay.Name = "item_txtTuNgay";
            this.item_txtTuNgay.Size = new System.Drawing.Size(259, 24);
            this.item_txtTuNgay.Text = "Từ ngày";
            this.item_txtTuNgay.TextSize = new System.Drawing.Size(47, 13);
            // 
            // item_txtDenNgay
            // 
            this.item_txtDenNgay.Control = this.txtDenNgay;
            this.item_txtDenNgay.CustomizationFormText = "Đến ngày";
            this.item_txtDenNgay.Location = new System.Drawing.Point(0, 24);
            this.item_txtDenNgay.Name = "item_txtDenNgay";
            this.item_txtDenNgay.Size = new System.Drawing.Size(259, 24);
            this.item_txtDenNgay.Text = "Đến ngày";
            this.item_txtDenNgay.TextSize = new System.Drawing.Size(47, 13);
            // 
            // item_cmbBoPhan
            // 
            this.item_cmbBoPhan.Control = this.cmbBoPhan;
            this.item_cmbBoPhan.CustomizationFormText = "Bộ phận";
            this.item_cmbBoPhan.Location = new System.Drawing.Point(0, 96);
            this.item_cmbBoPhan.Name = "item_cmbBoPhan";
            this.item_cmbBoPhan.Size = new System.Drawing.Size(259, 24);
            this.item_cmbBoPhan.Text = "Bộ phận";
            this.item_cmbBoPhan.TextSize = new System.Drawing.Size(47, 13);
            // 
            // item_checkChayTheoNam
            // 
            this.item_checkChayTheoNam.Control = this.checkChayTheoNam;
            this.item_checkChayTheoNam.CustomizationFormText = "layoutControlItem1";
            this.item_checkChayTheoNam.Location = new System.Drawing.Point(0, 120);
            this.item_checkChayTheoNam.Name = "item_checkChayTheoNam";
            this.item_checkChayTheoNam.Size = new System.Drawing.Size(259, 24);
            this.item_checkChayTheoNam.Text = "item_checkChayTheoNam";
            this.item_checkChayTheoNam.TextSize = new System.Drawing.Size(0, 0);
            this.item_checkChayTheoNam.TextToControlDistance = 0;
            this.item_checkChayTheoNam.TextVisible = false;
            // 
            // emptySpaceItem2
            // 
            this.emptySpaceItem2.AllowHotTrack = false;
            this.emptySpaceItem2.CustomizationFormText = "emptySpaceItem2";
            this.emptySpaceItem2.Location = new System.Drawing.Point(0, 168);
            this.emptySpaceItem2.Name = "emptySpaceItem2";
            this.emptySpaceItem2.Size = new System.Drawing.Size(259, 79);
            this.emptySpaceItem2.Text = "emptySpaceItem2";
            this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
            // 
            // defaultLookAndFeel1
            // 
            this.defaultLookAndFeel1.LookAndFeel.SkinName = "Office 2010 Blue";
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "1343360963_file_add.png");
            this.imageList1.Images.SetKeyName(1, "1337595172_file_edit.png");
            this.imageList1.Images.SetKeyName(2, "1343360966_file_delete.png");
            this.imageList1.Images.SetKeyName(3, "1343360964_file_search.png");
            this.imageList1.Images.SetKeyName(4, "undo64.png");
            this.imageList1.Images.SetKeyName(5, "save64.png");
            this.imageList1.Images.SetKeyName(6, "help64.png");
            this.imageList1.Images.SetKeyName(7, "printer64.png");
            this.imageList1.Images.SetKeyName(8, "exit64.png");
            this.imageList1.Images.SetKeyName(9, "1337595258_Gnome-View-Refresh-64.png");
            this.imageList1.Images.SetKeyName(10, "utilities64.png");
            this.imageList1.Images.SetKeyName(11, "report64.png");
            // 
            // mainMenuBarManager
            // 
            this.mainMenuBarManager.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.mainMenuBar});
            this.mainMenuBarManager.DockControls.Add(this.barDockControlTop);
            this.mainMenuBarManager.DockControls.Add(this.barDockControlBottom);
            this.mainMenuBarManager.DockControls.Add(this.barDockControlLeft);
            this.mainMenuBarManager.DockControls.Add(this.barDockControlRight);
            this.mainMenuBarManager.Form = this;
            this.mainMenuBarManager.Images = this.imageList1;
            this.mainMenuBarManager.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.btnThemMoi,
            this.btnThoat,
            this.barbt_Xem});
            this.mainMenuBarManager.LargeImages = this.imageList1;
            this.mainMenuBarManager.MainMenu = this.mainMenuBar;
            this.mainMenuBarManager.MaxItemId = 15;
            // 
            // mainMenuBar
            // 
            this.mainMenuBar.BarName = "Main menu";
            this.mainMenuBar.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Top;
            this.mainMenuBar.DockCol = 0;
            this.mainMenuBar.DockRow = 0;
            this.mainMenuBar.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.mainMenuBar.FloatLocation = new System.Drawing.Point(337, 299);
            this.mainMenuBar.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barbt_Xem, "", false, false, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnThoat, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)});
            this.mainMenuBar.OptionsBar.MultiLine = true;
            this.mainMenuBar.OptionsBar.UseWholeRow = true;
            this.mainMenuBar.Text = "Main menu";
            // 
            // barbt_Xem
            // 
            this.barbt_Xem.Caption = "Xem Báo cáo";
            this.barbt_Xem.Id = 8;
            this.barbt_Xem.ImageIndex = 3;
            this.barbt_Xem.ItemShortcut = new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P));
            this.barbt_Xem.Name = "barbt_Xem";
            toolTipTitleItem1.Text = "Ctrl+P";
            superToolTip1.Items.Add(toolTipTitleItem1);
            this.barbt_Xem.SuperTip = superToolTip1;
            this.barbt_Xem.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barbt_Xem_ItemClick);
            // 
            // btnThoat
            // 
            this.btnThoat.Caption = "Thoát";
            this.btnThoat.Id = 6;
            this.btnThoat.ImageIndex = 8;
            this.btnThoat.ItemShortcut = new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.X));
            this.btnThoat.Name = "btnThoat";
            toolTipTitleItem2.Text = "Alt+X";
            superToolTip2.Items.Add(toolTipTitleItem2);
            this.btnThoat.SuperTip = superToolTip2;
            this.btnThoat.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnThoat_ItemClick);
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(689, 34);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 299);
            this.barDockControlBottom.Size = new System.Drawing.Size(689, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 34);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 265);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(689, 34);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 265);
            // 
            // btnThemMoi
            // 
            this.btnThemMoi.Caption = "Thêm mới";
            this.btnThemMoi.Id = 0;
            this.btnThemMoi.ImageIndex = 0;
            this.btnThemMoi.ItemShortcut = new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N));
            this.btnThemMoi.Name = "btnThemMoi";
            toolTipTitleItem3.Text = "Ctrl+N";
            superToolTip3.Items.Add(toolTipTitleItem3);
            this.btnThemMoi.SuperTip = superToolTip3;
            // 
            // frmBaoCaoTongThuNhap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(689, 299);
            this.Controls.Add(this.pnlDieuKien);
            this.Controls.Add(this.treeReport);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmBaoCaoTongThuNhap";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Báo Cáo Tổng Thu Nhập";
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this.Load += new System.EventHandler(this.frmBaoCaoTongThuNhap_Load);
            this.pnlDieuKien.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cmbBoPhan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.boPhanListBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDenNgay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTuNgay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbKyTen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbDenKyLuong)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbKyLuong)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.item_cmbKyLuong)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.item_cmbDenKyLuong)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.item_cmbKyTen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.item_txtTuNgay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.item_txtDenNgay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.item_cmbBoPhan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.item_checkChayTheoNam)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mainMenuBarManager)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView treeReport;
        private System.Windows.Forms.Panel pnlDieuKien;
        private System.Windows.Forms.BindingSource boPhanListBindingSource;
        private Infragistics.Win.UltraWinEditors.UltraComboEditor cmbKyTen;
        private Infragistics.Win.UltraWinEditors.UltraComboEditor cmbDenKyLuong;
        private Infragistics.Win.UltraWinEditors.UltraComboEditor cmbKyLuong;
        private DevExpress.LookAndFeel.DefaultLookAndFeel defaultLookAndFeel1;
        private System.Windows.Forms.ImageList imageList1;
        private DevExpress.XtraBars.BarManager mainMenuBarManager;
        private DevExpress.XtraBars.Bar mainMenuBar;
        private DevExpress.XtraBars.BarButtonItem barbt_Xem;
        private DevExpress.XtraBars.BarButtonItem btnThoat;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarButtonItem btnThemMoi;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem item_cmbKyLuong;
        private DevExpress.XtraLayout.LayoutControlItem item_cmbDenKyLuong;
        private DevExpress.XtraLayout.LayoutControlItem item_cmbKyTen;
        private Infragistics.Win.UltraWinEditors.UltraDateTimeEditor txtTuNgay;
        private DevExpress.XtraLayout.LayoutControlItem item_txtTuNgay;
        private Infragistics.Win.UltraWinEditors.UltraDateTimeEditor txtDenNgay;
        private DevExpress.XtraLayout.LayoutControlItem item_txtDenNgay;
        private Infragistics.Win.UltraWinGrid.UltraCombo cmbBoPhan;
        private DevExpress.XtraLayout.LayoutControlItem item_cmbBoPhan;
        private System.Windows.Forms.CheckBox checkChayTheoNam;
        private DevExpress.XtraLayout.LayoutControlItem item_checkChayTheoNam;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
    }
}