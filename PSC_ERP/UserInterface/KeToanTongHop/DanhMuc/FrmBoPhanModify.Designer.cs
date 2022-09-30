namespace PSC_ERP
{
    partial class FrmBoPhanModify
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmBoPhanModify));
            DevExpress.Utils.SuperToolTip superToolTip1 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem1 = new DevExpress.Utils.ToolTipTitleItem();
            DevExpress.Utils.SuperToolTip superToolTip2 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem2 = new DevExpress.Utils.ToolTipTitleItem();
            this.mainMenuBarManager = new DevExpress.XtraBars.BarManager(this.components);
            this.mainMenuBar = new DevExpress.XtraBars.Bar();
            this.btnThemMoi = new DevExpress.XtraBars.BarButtonItem();
            this.btnSua = new DevExpress.XtraBars.BarButtonItem();
            this.btnLuu = new DevExpress.XtraBars.BarButtonItem();
            this.btnXoa = new DevExpress.XtraBars.BarButtonItem();
            this.btnRefresh = new DevExpress.XtraBars.BarButtonItem();
            this.btn_XuatRaExcel = new DevExpress.XtraBars.BarButtonItem();
            this.btnThoat = new DevExpress.XtraBars.BarButtonItem();
            this.btnDongBoHRM = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.BoPhanList_bindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.treeList_BoPhan = new DevExpress.XtraTreeList.TreeList();
            this.colMaBoPhan1 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colMaBoPhanQL1 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colTenBoPhan1 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colNgayTao1 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.repoLookUpEditTKKH = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.TaiKhoan_bindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.colMaBoPhanCha1 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colTaiKhoanPBCP = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.repoLookUpEditTKPBCP = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            ((System.ComponentModel.ISupportInitialize)(this.mainMenuBarManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BoPhanList_bindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.treeList_BoPhan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repoLookUpEditTKKH)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TaiKhoan_bindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repoLookUpEditTKPBCP)).BeginInit();
            this.SuspendLayout();
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
            this.mainMenuBarManager.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.btnThemMoi,
            this.btnThoat,
            this.btn_XuatRaExcel,
            this.btnLuu,
            this.btnSua,
            this.btnXoa,
            this.btnRefresh,
            this.btnDongBoHRM});
            this.mainMenuBarManager.MainMenu = this.mainMenuBar;
            this.mainMenuBarManager.MaxItemId = 16;
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
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnThemMoi, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnSua, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnLuu, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnXoa, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnRefresh, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btn_XuatRaExcel, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnThoat, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnDongBoHRM, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)});
            this.mainMenuBar.OptionsBar.MultiLine = true;
            this.mainMenuBar.OptionsBar.UseWholeRow = true;
            this.mainMenuBar.Text = "Main menu";
            // 
            // btnThemMoi
            // 
            this.btnThemMoi.Caption = "Thêm mới";
            this.btnThemMoi.Id = 0;
            this.btnThemMoi.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnThemMoi.ImageOptions.Image")));
            this.btnThemMoi.ItemShortcut = new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N));
            this.btnThemMoi.Name = "btnThemMoi";
            toolTipTitleItem1.Text = "Ctrl+N";
            superToolTip1.Items.Add(toolTipTitleItem1);
            this.btnThemMoi.SuperTip = superToolTip1;
            this.btnThemMoi.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnThemMoi_ItemClick);
            // 
            // btnSua
            // 
            this.btnSua.Caption = "Sửa";
            this.btnSua.Id = 12;
            this.btnSua.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnSua.ImageOptions.Image")));
            this.btnSua.Name = "btnSua";
            this.btnSua.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnSua_ItemClick);
            // 
            // btnLuu
            // 
            this.btnLuu.Caption = "Lưu";
            this.btnLuu.Id = 11;
            this.btnLuu.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnLuu.ImageOptions.Image")));
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnLuu_ItemClick);
            // 
            // btnXoa
            // 
            this.btnXoa.Caption = "Xóa";
            this.btnXoa.Id = 13;
            this.btnXoa.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnXoa.ImageOptions.Image")));
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnXoa_ItemClick);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Caption = "Refresh";
            this.btnRefresh.Id = 14;
            this.btnRefresh.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnRefresh.ImageOptions.Image")));
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnRefresh_ItemClick);
            // 
            // btn_XuatRaExcel
            // 
            this.btn_XuatRaExcel.Caption = "Xuất ra File Excel";
            this.btn_XuatRaExcel.Id = 9;
            this.btn_XuatRaExcel.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_XuatRaExcel.ImageOptions.Image")));
            this.btn_XuatRaExcel.Name = "btn_XuatRaExcel";
            this.btn_XuatRaExcel.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btn_XuatRaExcel_ItemClick);
            // 
            // btnThoat
            // 
            this.btnThoat.Caption = "Thoát";
            this.btnThoat.Id = 6;
            this.btnThoat.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnThoat.ImageOptions.Image")));
            this.btnThoat.ItemShortcut = new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Q));
            this.btnThoat.Name = "btnThoat";
            toolTipTitleItem2.Text = "Ctrl+Q";
            superToolTip2.Items.Add(toolTipTitleItem2);
            this.btnThoat.SuperTip = superToolTip2;
            this.btnThoat.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnThoat_ItemClick);
            // 
            // btnDongBoHRM
            // 
            this.btnDongBoHRM.Caption = "Đồng bộ HRM";
            this.btnDongBoHRM.Id = 15;
            this.btnDongBoHRM.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnDongBoHRM.ImageOptions.Image")));
            this.btnDongBoHRM.Name = "btnDongBoHRM";
            this.btnDongBoHRM.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnDongBoHRM_ItemClick);
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.mainMenuBarManager;
            this.barDockControlTop.Size = new System.Drawing.Size(849, 87);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 502);
            this.barDockControlBottom.Manager = this.mainMenuBarManager;
            this.barDockControlBottom.Size = new System.Drawing.Size(849, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 87);
            this.barDockControlLeft.Manager = this.mainMenuBarManager;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 415);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(849, 87);
            this.barDockControlRight.Manager = this.mainMenuBarManager;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 415);
            // 
            // BoPhanList_bindingSource
            // 
            this.BoPhanList_bindingSource.AllowNew = true;
            this.BoPhanList_bindingSource.DataSource = typeof(ERP_Library.BoPhanList);
            // 
            // treeList_BoPhan
            // 
            this.treeList_BoPhan.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.colMaBoPhan1,
            this.colMaBoPhanQL1,
            this.colTenBoPhan1,
            this.colNgayTao1,
            this.colMaBoPhanCha1,
            this.colTaiKhoanPBCP});
            this.treeList_BoPhan.Cursor = System.Windows.Forms.Cursors.Default;
            this.treeList_BoPhan.CustomizationFormBounds = new System.Drawing.Rectangle(966, 424, 216, 209);
            this.treeList_BoPhan.DataSource = this.BoPhanList_bindingSource;
            this.treeList_BoPhan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeList_BoPhan.IndicatorWidth = 30;
            this.treeList_BoPhan.KeyFieldName = "MaBoPhan";
            this.treeList_BoPhan.Location = new System.Drawing.Point(0, 87);
            this.treeList_BoPhan.Name = "treeList_BoPhan";
            this.treeList_BoPhan.OptionsBehavior.PopulateServiceColumns = true;
            this.treeList_BoPhan.OptionsDragAndDrop.AcceptOuterNodes = true;
            this.treeList_BoPhan.OptionsDragAndDrop.DragNodesMode = DevExpress.XtraTreeList.DragNodesMode.Single;
            this.treeList_BoPhan.OptionsDragAndDrop.DropNodesMode = DevExpress.XtraTreeList.DropNodesMode.Advanced;
            this.treeList_BoPhan.OptionsNavigation.AutoFocusNewNode = true;
            this.treeList_BoPhan.OptionsNavigation.AutoMoveRowFocus = true;
            this.treeList_BoPhan.OptionsNavigation.EnterMovesNextColumn = true;
            this.treeList_BoPhan.OptionsNavigation.UseTabKey = true;
            this.treeList_BoPhan.OptionsSelection.SelectNodesOnRightClick = true;
            this.treeList_BoPhan.ParentFieldName = "MaBoPhanCha";
            this.treeList_BoPhan.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repoLookUpEditTKKH,
            this.repoLookUpEditTKPBCP});
            this.treeList_BoPhan.Size = new System.Drawing.Size(849, 415);
            this.treeList_BoPhan.TabIndex = 18;
            this.treeList_BoPhan.CellValueChanged += new DevExpress.XtraTreeList.CellValueChangedEventHandler(this.treeList_BoPhan_CellValueChanged);
            this.treeList_BoPhan.DoubleClick += new System.EventHandler(this.treeList_BoPhan_DoubleClick);
            this.treeList_BoPhan.KeyDown += new System.Windows.Forms.KeyEventHandler(this.treeList_BoPhan_KeyDown);
            // 
            // colMaBoPhan1
            // 
            this.colMaBoPhan1.FieldName = "MaBoPhan";
            this.colMaBoPhan1.Name = "colMaBoPhan1";
            this.colMaBoPhan1.Width = 38;
            // 
            // colMaBoPhanQL1
            // 
            this.colMaBoPhanQL1.Caption = "Mã quản lý";
            this.colMaBoPhanQL1.FieldName = "MaBoPhanQL";
            this.colMaBoPhanQL1.Name = "colMaBoPhanQL1";
            this.colMaBoPhanQL1.Visible = true;
            this.colMaBoPhanQL1.VisibleIndex = 0;
            this.colMaBoPhanQL1.Width = 70;
            // 
            // colTenBoPhan1
            // 
            this.colTenBoPhan1.Caption = "Tên bộ phận";
            this.colTenBoPhan1.FieldName = "TenBoPhan";
            this.colTenBoPhan1.Name = "colTenBoPhan1";
            this.colTenBoPhan1.Visible = true;
            this.colTenBoPhan1.VisibleIndex = 1;
            this.colTenBoPhan1.Width = 193;
            // 
            // colNgayTao1
            // 
            this.colNgayTao1.Caption = "TK chi phí TSCĐ";
            this.colNgayTao1.ColumnEdit = this.repoLookUpEditTKKH;
            this.colNgayTao1.FieldName = "TaiKhoanKHHM";
            this.colNgayTao1.Name = "colNgayTao1";
            this.colNgayTao1.Visible = true;
            this.colNgayTao1.VisibleIndex = 2;
            this.colNgayTao1.Width = 210;
            // 
            // repoLookUpEditTKKH
            // 
            this.repoLookUpEditTKKH.AutoHeight = false;
            this.repoLookUpEditTKKH.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repoLookUpEditTKKH.CaseSensitiveSearch = true;
            this.repoLookUpEditTKKH.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("SoHieuTK", "Số Hiệu TK", 61, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.Descending, DevExpress.Utils.DefaultBoolean.True),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("TenTaiKhoan", "Tên Tài Khoản", 78, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near)});
            this.repoLookUpEditTKKH.DataSource = this.TaiKhoan_bindingSource;
            this.repoLookUpEditTKKH.DisplayMember = "SoHieuTK";
            this.repoLookUpEditTKKH.KeyMember = "MaTaiKhoan";
            this.repoLookUpEditTKKH.Name = "repoLookUpEditTKKH";
            this.repoLookUpEditTKKH.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains;
            this.repoLookUpEditTKKH.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.OnlyInPopup;
            this.repoLookUpEditTKKH.ValueMember = "MaTaiKhoan";
            // 
            // TaiKhoan_bindingSource
            // 
            this.TaiKhoan_bindingSource.DataSource = typeof(ERP_Library.HeThongTaiKhoan1List);
            this.TaiKhoan_bindingSource.Sort = "SoHieuTK";
            // 
            // colMaBoPhanCha1
            // 
            this.colMaBoPhanCha1.FieldName = "MaBoPhanCha";
            this.colMaBoPhanCha1.Name = "colMaBoPhanCha1";
            this.colMaBoPhanCha1.Width = 38;
            // 
            // colTaiKhoanPBCP
            // 
            this.colTaiKhoanPBCP.Caption = "TK chi phí CCDC";
            this.colTaiKhoanPBCP.ColumnEdit = this.repoLookUpEditTKPBCP;
            this.colTaiKhoanPBCP.FieldName = "TaiKhoanPBCP";
            this.colTaiKhoanPBCP.Name = "colTaiKhoanPBCP";
            this.colTaiKhoanPBCP.Visible = true;
            this.colTaiKhoanPBCP.VisibleIndex = 3;
            this.colTaiKhoanPBCP.Width = 205;
            // 
            // repoLookUpEditTKPBCP
            // 
            this.repoLookUpEditTKPBCP.AutoHeight = false;
            this.repoLookUpEditTKPBCP.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repoLookUpEditTKPBCP.CaseSensitiveSearch = true;
            this.repoLookUpEditTKPBCP.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("SoHieuTK", "Số Hiệu TK", 61, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.Ascending, DevExpress.Utils.DefaultBoolean.True),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("TenTaiKhoan", "Tên Tài Khoản", 78, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near)});
            this.repoLookUpEditTKPBCP.DataSource = this.TaiKhoan_bindingSource;
            this.repoLookUpEditTKPBCP.DisplayMember = "SoHieuTK";
            this.repoLookUpEditTKPBCP.KeyMember = "MaTaiKhoan";
            this.repoLookUpEditTKPBCP.Name = "repoLookUpEditTKPBCP";
            this.repoLookUpEditTKPBCP.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains;
            this.repoLookUpEditTKPBCP.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.AutoComplete;
            this.repoLookUpEditTKPBCP.ValueMember = "MaTaiKhoan";
            // 
            // FrmBoPhanModify
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(849, 502);
            this.Controls.Add(this.treeList_BoPhan);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "FrmBoPhanModify";
            this.Text = " Danh Sách Bộ Phận";
            this.Load += new System.EventHandler(this.FrmBoPhanModify_Load);
            ((System.ComponentModel.ISupportInitialize)(this.mainMenuBarManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BoPhanList_bindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.treeList_BoPhan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repoLookUpEditTKKH)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TaiKhoan_bindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repoLookUpEditTKPBCP)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.BarManager mainMenuBarManager;
        private DevExpress.XtraBars.Bar mainMenuBar;
        private DevExpress.XtraBars.BarButtonItem btnThemMoi;
        private DevExpress.XtraBars.BarButtonItem btn_XuatRaExcel;
        private DevExpress.XtraBars.BarButtonItem btnThoat;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarButtonItem btnLuu;
        private System.Windows.Forms.BindingSource BoPhanList_bindingSource;
        private DevExpress.XtraTreeList.TreeList treeList_BoPhan;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colMaBoPhan1;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colMaBoPhanQL1;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colTenBoPhan1;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colNgayTao1;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colMaBoPhanCha1;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colTaiKhoanPBCP;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repoLookUpEditTKKH;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repoLookUpEditTKPBCP;
        private System.Windows.Forms.BindingSource TaiKhoan_bindingSource;
        private DevExpress.XtraBars.BarButtonItem btnSua;
        private DevExpress.XtraBars.BarButtonItem btnXoa;
        private DevExpress.XtraBars.BarButtonItem btnRefresh;
        private DevExpress.XtraBars.BarButtonItem btnDongBoHRM;
    }
}