namespace PSC_ERP
{
    partial class Frm_Xe
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_Xe));
            DevExpress.Utils.SuperToolTip superToolTip1 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem1 = new DevExpress.Utils.ToolTipTitleItem();
            this.mainMenuBarManager = new DevExpress.XtraBars.BarManager(this.components);
            this.mainMenuBar = new DevExpress.XtraBars.Bar();
            this.btnThemMoi = new DevExpress.XtraBars.BarButtonItem();
            this.btnXoa = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.btnLuu = new DevExpress.XtraBars.BarButtonItem();
            this.btnPrint = new DevExpress.XtraBars.BarButtonItem();
            this.btnHelp = new DevExpress.XtraBars.BarButtonItem();
            this.btnThoat = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControl1 = new DevExpress.XtraBars.BarDockControl();
            this.grd_DSXe = new DevExpress.XtraGrid.GridControl();
            this.XeListBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView_DMKho = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMaQuanLyXe = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTenXe = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMaBoPhan = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemLookUpEdit_BoPhan = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.BoPhanListbindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.txt_MaQuanLyXe = new DevExpress.XtraEditors.TextEdit();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.txt_TenXe = new DevExpress.XtraEditors.TextEdit();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.GridLookupEdit_BoPhan = new DevExpress.XtraEditors.GridLookUpEdit();
            this.gridView3 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colBP_MaBoPhanQL = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBP_TenBoPhan = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.mainMenuBarManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grd_DSXe)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.XeListBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_DMKho)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit_BoPhan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BoPhanListbindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_MaQuanLyXe.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txt_TenXe.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridLookupEdit_BoPhan.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).BeginInit();
            this.SuspendLayout();
            // 
            // mainMenuBarManager
            // 
            this.mainMenuBarManager.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.mainMenuBar});
            this.mainMenuBarManager.DockControls.Add(this.barDockControlTop);
            this.mainMenuBarManager.DockControls.Add(this.barDockControlBottom);
            this.mainMenuBarManager.DockControls.Add(this.barDockControlLeft);
            this.mainMenuBarManager.DockControls.Add(this.barDockControl1);
            this.mainMenuBarManager.Form = this;
            this.mainMenuBarManager.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.btnThemMoi,
            this.btnXoa,
            this.btnLuu,
            this.btnPrint,
            this.btnThoat,
            this.btnHelp,
            this.barButtonItem1});
            this.mainMenuBarManager.MainMenu = this.mainMenuBar;
            this.mainMenuBarManager.MaxItemId = 9;
            // 
            // mainMenuBar
            // 
            this.mainMenuBar.BarName = "Main menu";
            this.mainMenuBar.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Top;
            this.mainMenuBar.DockCol = 0;
            this.mainMenuBar.DockRow = 0;
            this.mainMenuBar.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.mainMenuBar.FloatLocation = new System.Drawing.Point(668, 233);
            this.mainMenuBar.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnThemMoi, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnXoa, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barButtonItem1, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnLuu, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnPrint, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnHelp, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnThoat, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)});
            this.mainMenuBar.OptionsBar.MultiLine = true;
            this.mainMenuBar.OptionsBar.UseWholeRow = true;
            this.mainMenuBar.Text = "Main menu";
            // 
            // btnThemMoi
            // 
            this.btnThemMoi.Caption = "Thêm mới";
            this.btnThemMoi.Glyph = ((System.Drawing.Image)(resources.GetObject("btnThemMoi.Glyph")));
            this.btnThemMoi.Id = 0;
            this.btnThemMoi.ItemShortcut = new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N));
            this.btnThemMoi.Name = "btnThemMoi";
            this.btnThemMoi.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnThemMoi_ItemClick);
            // 
            // btnXoa
            // 
            this.btnXoa.Caption = "Xóa";
            this.btnXoa.Glyph = ((System.Drawing.Image)(resources.GetObject("btnXoa.Glyph")));
            this.btnXoa.Id = 2;
            this.btnXoa.ItemShortcut = new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D));
            this.btnXoa.Name = "btnXoa";
            toolTipTitleItem1.Text = "Ctrl+D";
            superToolTip1.Items.Add(toolTipTitleItem1);
            this.btnXoa.SuperTip = superToolTip1;
            this.btnXoa.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnXoa_ItemClick);
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.Caption = "Refresh";
            this.barButtonItem1.Glyph = ((System.Drawing.Image)(resources.GetObject("barButtonItem1.Glyph")));
            this.barButtonItem1.Id = 8;
            this.barButtonItem1.ItemShortcut = new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Z));
            this.barButtonItem1.Name = "barButtonItem1";
            this.barButtonItem1.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem1_ItemClick);
            // 
            // btnLuu
            // 
            this.btnLuu.Caption = "Lưu";
            this.btnLuu.Glyph = ((System.Drawing.Image)(resources.GetObject("btnLuu.Glyph")));
            this.btnLuu.Id = 3;
            this.btnLuu.ItemShortcut = new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S));
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnLuu_ItemClick);
            // 
            // btnPrint
            // 
            this.btnPrint.Caption = "In";
            this.btnPrint.Glyph = ((System.Drawing.Image)(resources.GetObject("btnPrint.Glyph")));
            this.btnPrint.Id = 5;
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            // 
            // btnHelp
            // 
            this.btnHelp.Caption = "Trợ giúp";
            this.btnHelp.Glyph = ((System.Drawing.Image)(resources.GetObject("btnHelp.Glyph")));
            this.btnHelp.Id = 7;
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            // 
            // btnThoat
            // 
            this.btnThoat.Caption = "Thoát";
            this.btnThoat.Glyph = ((System.Drawing.Image)(resources.GetObject("btnThoat.Glyph")));
            this.btnThoat.Id = 6;
            this.btnThoat.ItemShortcut = new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.X));
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnThoat_ItemClick);
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(949, 42);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 460);
            this.barDockControlBottom.Size = new System.Drawing.Size(949, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 42);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 418);
            // 
            // barDockControl1
            // 
            this.barDockControl1.CausesValidation = false;
            this.barDockControl1.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControl1.Location = new System.Drawing.Point(949, 42);
            this.barDockControl1.Size = new System.Drawing.Size(0, 418);
            // 
            // grd_DSXe
            // 
            this.grd_DSXe.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.grd_DSXe.DataSource = this.XeListBindingSource;
            this.grd_DSXe.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grd_DSXe.EmbeddedNavigator.Text = "show ra tiêu đề";
            this.grd_DSXe.EmbeddedNavigator.ToolTipTitle = "ToolTipTitle";
            this.grd_DSXe.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grd_DSXe.Location = new System.Drawing.Point(0, 145);
            this.grd_DSXe.LookAndFeel.SkinName = "Office 2010 Silver";
            this.grd_DSXe.LookAndFeel.UseDefaultLookAndFeel = false;
            this.grd_DSXe.MainView = this.gridView_DMKho;
            this.grd_DSXe.Name = "grd_DSXe";
            this.grd_DSXe.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemLookUpEdit_BoPhan});
            this.grd_DSXe.Size = new System.Drawing.Size(949, 315);
            this.grd_DSXe.TabIndex = 1;
            this.grd_DSXe.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView_DMKho});
            // 
            // XeListBindingSource
            // 
            this.XeListBindingSource.DataSource = typeof(ERP_Library.XeList);
            // 
            // gridView_DMKho
            // 
            this.gridView_DMKho.Appearance.ViewCaption.Font = new System.Drawing.Font("Times New Roman", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridView_DMKho.Appearance.ViewCaption.ForeColor = System.Drawing.Color.Red;
            this.gridView_DMKho.Appearance.ViewCaption.Options.UseFont = true;
            this.gridView_DMKho.Appearance.ViewCaption.Options.UseForeColor = true;
            this.gridView_DMKho.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colId,
            this.colMaQuanLyXe,
            this.colTenXe,
            this.colMaBoPhan});
            this.gridView_DMKho.GridControl = this.grd_DSXe;
            this.gridView_DMKho.GroupPanelText = "Danh Mục Biển Số Xe";
            this.gridView_DMKho.Name = "gridView_DMKho";
            this.gridView_DMKho.OptionsBehavior.ReadOnly = true;
            this.gridView_DMKho.OptionsNavigation.AutoFocusNewRow = true;
            this.gridView_DMKho.OptionsView.ShowAutoFilterRow = true;
            // 
            // colId
            // 
            this.colId.FieldName = "Id";
            this.colId.Name = "colId";
            this.colId.OptionsColumn.ReadOnly = true;
            // 
            // colMaQuanLyXe
            // 
            this.colMaQuanLyXe.AppearanceHeader.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colMaQuanLyXe.AppearanceHeader.ForeColor = System.Drawing.Color.RoyalBlue;
            this.colMaQuanLyXe.AppearanceHeader.Options.UseFont = true;
            this.colMaQuanLyXe.AppearanceHeader.Options.UseForeColor = true;
            this.colMaQuanLyXe.AppearanceHeader.Options.UseTextOptions = true;
            this.colMaQuanLyXe.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colMaQuanLyXe.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colMaQuanLyXe.Caption = "Mã Xe";
            this.colMaQuanLyXe.FieldName = "MaQuanLyXe";
            this.colMaQuanLyXe.Name = "colMaQuanLyXe";
            this.colMaQuanLyXe.Visible = true;
            this.colMaQuanLyXe.VisibleIndex = 0;
            this.colMaQuanLyXe.Width = 45;
            // 
            // colTenXe
            // 
            this.colTenXe.AppearanceHeader.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colTenXe.AppearanceHeader.ForeColor = System.Drawing.Color.RoyalBlue;
            this.colTenXe.AppearanceHeader.Options.UseFont = true;
            this.colTenXe.AppearanceHeader.Options.UseForeColor = true;
            this.colTenXe.AppearanceHeader.Options.UseTextOptions = true;
            this.colTenXe.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colTenXe.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colTenXe.Caption = "Biển Số Xe";
            this.colTenXe.FieldName = "TenXe";
            this.colTenXe.Name = "colTenXe";
            this.colTenXe.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colTenXe.Visible = true;
            this.colTenXe.VisibleIndex = 1;
            this.colTenXe.Width = 90;
            // 
            // colMaBoPhan
            // 
            this.colMaBoPhan.AppearanceHeader.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colMaBoPhan.AppearanceHeader.ForeColor = System.Drawing.Color.RoyalBlue;
            this.colMaBoPhan.AppearanceHeader.Options.UseFont = true;
            this.colMaBoPhan.AppearanceHeader.Options.UseForeColor = true;
            this.colMaBoPhan.AppearanceHeader.Options.UseTextOptions = true;
            this.colMaBoPhan.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colMaBoPhan.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colMaBoPhan.Caption = "Thuộc Bộ Phận";
            this.colMaBoPhan.ColumnEdit = this.repositoryItemLookUpEdit_BoPhan;
            this.colMaBoPhan.FieldName = "MaBoPhan";
            this.colMaBoPhan.Name = "colMaBoPhan";
            this.colMaBoPhan.OptionsFilter.AllowAutoFilter = false;
            this.colMaBoPhan.OptionsFilter.AllowFilter = false;
            this.colMaBoPhan.Visible = true;
            this.colMaBoPhan.VisibleIndex = 2;
            this.colMaBoPhan.Width = 90;
            // 
            // repositoryItemLookUpEdit_BoPhan
            // 
            this.repositoryItemLookUpEdit_BoPhan.AutoHeight = false;
            this.repositoryItemLookUpEdit_BoPhan.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemLookUpEdit_BoPhan.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("MaTaiKhoan", "Ma Tai Khoan", 87, DevExpress.Utils.FormatType.Numeric, "", false, DevExpress.Utils.HorzAlignment.Far),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("SoHieuTK", "Tài khoản", 61, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Center),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("TenTaiKhoan", "Tên tài khoản", 78, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Center),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("MaTaiKhoanCha", "Ma Tai Khoan Cha", 96, DevExpress.Utils.FormatType.Numeric, "", false, DevExpress.Utils.HorzAlignment.Far),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("CoDoiTuongTheoDoi", "Co Doi Tuong Theo Doi", 119, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Near),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("LoaiSoDuCo", "Loai So Du Co", 76, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Near),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("LoaiSoDuNo", "Loai So Du No", 76, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Near),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("SoDuNoDauNam", "So Du No Dau Nam", 100, DevExpress.Utils.FormatType.Numeric, "", false, DevExpress.Utils.HorzAlignment.Far),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("SoDuCoDauNam", "So Du Co Dau Nam", 100, DevExpress.Utils.FormatType.Numeric, "", false, DevExpress.Utils.HorzAlignment.Far),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("LoaiTK", "Loai TK", 44, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Near),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("CapTaiKhoan", "Cap Tai Khoan", 79, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Near)});
            this.repositoryItemLookUpEdit_BoPhan.DataSource = this.BoPhanListbindingSource;
            this.repositoryItemLookUpEdit_BoPhan.DisplayMember = "TenBoPhan";
            this.repositoryItemLookUpEdit_BoPhan.Name = "repositoryItemLookUpEdit_BoPhan";
            this.repositoryItemLookUpEdit_BoPhan.ValueMember = "MaBoPhan";
            // 
            // BoPhanListbindingSource
            // 
            this.BoPhanListbindingSource.DataSource = typeof(ERP_Library.BoPhanList);
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl2.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.labelControl2.LineColor = System.Drawing.Color.Lime;
            this.labelControl2.LineVisible = true;
            this.labelControl2.Location = new System.Drawing.Point(210, 23);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(36, 15);
            this.labelControl2.TabIndex = 2;
            this.labelControl2.Text = "Mã xe:";
            // 
            // txt_MaQuanLyXe
            // 
            this.txt_MaQuanLyXe.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.XeListBindingSource, "MaQuanLyXe", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.txt_MaQuanLyXe.Location = new System.Drawing.Point(298, 17);
            this.txt_MaQuanLyXe.Name = "txt_MaQuanLyXe";
            this.txt_MaQuanLyXe.Properties.Appearance.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_MaQuanLyXe.Properties.Appearance.Options.UseFont = true;
            this.txt_MaQuanLyXe.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            this.txt_MaQuanLyXe.Size = new System.Drawing.Size(286, 22);
            this.txt_MaQuanLyXe.TabIndex = 0;
            // 
            // panelControl1
            // 
            this.panelControl1.Appearance.BackColor = System.Drawing.Color.LightCyan;
            this.panelControl1.Appearance.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.panelControl1.Appearance.Options.UseBackColor = true;
            this.panelControl1.Controls.Add(this.txt_TenXe);
            this.panelControl1.Controls.Add(this.labelControl6);
            this.panelControl1.Controls.Add(this.labelControl5);
            this.panelControl1.Controls.Add(this.labelControl2);
            this.panelControl1.Controls.Add(this.txt_MaQuanLyXe);
            this.panelControl1.Controls.Add(this.GridLookupEdit_BoPhan);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 42);
            this.panelControl1.LookAndFeel.SkinName = "Office 2010 Silver";
            this.panelControl1.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.UltraFlat;
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(949, 103);
            this.panelControl1.TabIndex = 0;
            // 
            // txt_TenXe
            // 
            this.txt_TenXe.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.XeListBindingSource, "TenXe", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.txt_TenXe.Location = new System.Drawing.Point(298, 46);
            this.txt_TenXe.Name = "txt_TenXe";
            this.txt_TenXe.Properties.Appearance.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_TenXe.Properties.Appearance.Options.UseFont = true;
            this.txt_TenXe.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            this.txt_TenXe.Size = new System.Drawing.Size(286, 22);
            this.txt_TenXe.TabIndex = 1;
            // 
            // labelControl6
            // 
            this.labelControl6.Appearance.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl6.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.labelControl6.LineColor = System.Drawing.Color.Lime;
            this.labelControl6.Location = new System.Drawing.Point(210, 51);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(60, 15);
            this.labelControl6.TabIndex = 13;
            this.labelControl6.Text = "Biển số xe:";
            // 
            // labelControl5
            // 
            this.labelControl5.Appearance.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl5.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.labelControl5.LineColor = System.Drawing.Color.Lime;
            this.labelControl5.Location = new System.Drawing.Point(210, 76);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(85, 15);
            this.labelControl5.TabIndex = 12;
            this.labelControl5.Text = "Thuộc Bộ phận:";
            // 
            // GridLookupEdit_BoPhan
            // 
            this.GridLookupEdit_BoPhan.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.XeListBindingSource, "MaBoPhan", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.GridLookupEdit_BoPhan.Location = new System.Drawing.Point(298, 73);
            this.GridLookupEdit_BoPhan.Name = "GridLookupEdit_BoPhan";
            this.GridLookupEdit_BoPhan.Properties.Appearance.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GridLookupEdit_BoPhan.Properties.Appearance.Options.UseFont = true;
            this.GridLookupEdit_BoPhan.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            this.GridLookupEdit_BoPhan.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.GridLookupEdit_BoPhan.Properties.DataSource = this.BoPhanListbindingSource;
            this.GridLookupEdit_BoPhan.Properties.DisplayMember = "TenBoPhan";
            this.GridLookupEdit_BoPhan.Properties.NullText = "";
            this.GridLookupEdit_BoPhan.Properties.ValueMember = "MaBoPhan";
            this.GridLookupEdit_BoPhan.Properties.View = this.gridView3;
            this.GridLookupEdit_BoPhan.Size = new System.Drawing.Size(286, 22);
            this.GridLookupEdit_BoPhan.TabIndex = 2;
            // 
            // gridView3
            // 
            this.gridView3.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colBP_MaBoPhanQL,
            this.colBP_TenBoPhan});
            this.gridView3.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView3.Name = "gridView3";
            this.gridView3.OptionsFilter.ShowAllTableValuesInFilterPopup = true;
            this.gridView3.OptionsFilter.UseNewCustomFilterDialog = true;
            this.gridView3.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView3.OptionsView.ShowAutoFilterRow = true;
            this.gridView3.OptionsView.ShowGroupPanel = false;
            // 
            // colBP_MaBoPhanQL
            // 
            this.colBP_MaBoPhanQL.AppearanceHeader.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colBP_MaBoPhanQL.AppearanceHeader.Options.UseFont = true;
            this.colBP_MaBoPhanQL.AppearanceHeader.Options.UseTextOptions = true;
            this.colBP_MaBoPhanQL.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colBP_MaBoPhanQL.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colBP_MaBoPhanQL.Caption = "Mã";
            this.colBP_MaBoPhanQL.FieldName = "MaBoPhanQL";
            this.colBP_MaBoPhanQL.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText;
            this.colBP_MaBoPhanQL.Name = "colBP_MaBoPhanQL";
            this.colBP_MaBoPhanQL.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colBP_MaBoPhanQL.Visible = true;
            this.colBP_MaBoPhanQL.VisibleIndex = 0;
            // 
            // colBP_TenBoPhan
            // 
            this.colBP_TenBoPhan.AppearanceHeader.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colBP_TenBoPhan.AppearanceHeader.Options.UseFont = true;
            this.colBP_TenBoPhan.AppearanceHeader.Options.UseTextOptions = true;
            this.colBP_TenBoPhan.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colBP_TenBoPhan.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colBP_TenBoPhan.Caption = "Tên Bộ Phận";
            this.colBP_TenBoPhan.FieldName = "TenBoPhan";
            this.colBP_TenBoPhan.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText;
            this.colBP_TenBoPhan.Name = "colBP_TenBoPhan";
            this.colBP_TenBoPhan.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Equals;
            this.colBP_TenBoPhan.Visible = true;
            this.colBP_TenBoPhan.VisibleIndex = 1;
            // 
            // Frm_Xe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(949, 460);
            this.Controls.Add(this.grd_DSXe);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControl1);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "Frm_Xe";
            this.Text = "Danh Mục Biển Số Xe";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Frm_Xe_FormClosing);
            this.Load += new System.EventHandler(this.Frm_Xe_Load);
            ((System.ComponentModel.ISupportInitialize)(this.mainMenuBarManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grd_DSXe)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.XeListBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_DMKho)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit_BoPhan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BoPhanListbindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_MaQuanLyXe.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txt_TenXe.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridLookupEdit_BoPhan.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraBars.BarManager mainMenuBarManager;
        private DevExpress.XtraBars.Bar mainMenuBar;
        private DevExpress.XtraBars.BarButtonItem btnThemMoi;
        private DevExpress.XtraBars.BarButtonItem btnXoa;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private DevExpress.XtraBars.BarButtonItem btnLuu;
        private DevExpress.XtraBars.BarButtonItem btnPrint;
        private DevExpress.XtraBars.BarButtonItem btnHelp;
        private DevExpress.XtraBars.BarButtonItem btnThoat;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControl1;
        private DevExpress.XtraGrid.GridControl grd_DSXe;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView_DMKho;
        private DevExpress.XtraGrid.Columns.GridColumn colId;
        private DevExpress.XtraGrid.Columns.GridColumn colMaQuanLyXe;
        private DevExpress.XtraGrid.Columns.GridColumn colTenXe;
        private DevExpress.XtraGrid.Columns.GridColumn colMaBoPhan;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.TextEdit txt_MaQuanLyXe;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.GridLookUpEdit GridLookupEdit_BoPhan;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView3;
        private DevExpress.XtraGrid.Columns.GridColumn colBP_MaBoPhanQL;
        private DevExpress.XtraGrid.Columns.GridColumn colBP_TenBoPhan;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit_BoPhan;
        private DevExpress.XtraEditors.TextEdit txt_TenXe;
        private System.Windows.Forms.BindingSource XeListBindingSource;
        private System.Windows.Forms.BindingSource BoPhanListbindingSource;
    }
}