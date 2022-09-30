namespace PSC_ERP
{
    partial class XtraFrm_DonViTinh
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
            DevExpress.Utils.SuperToolTip superToolTip1 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem1 = new DevExpress.Utils.ToolTipTitleItem();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(XtraFrm_DonViTinh));
            this.bs_DonViTinhList = new System.Windows.Forms.BindingSource();
            this.mainMenuBarManager = new DevExpress.XtraBars.BarManager();
            this.mainMenuBar = new DevExpress.XtraBars.Bar();
            this.btnThemMoi = new DevExpress.XtraBars.BarButtonItem();
            this.btnXoa = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.btnLuu = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem5 = new DevExpress.XtraBars.BarButtonItem();
            this.btnPrint = new DevExpress.XtraBars.BarButtonItem();
            this.btnHelp = new DevExpress.XtraBars.BarButtonItem();
            this.btnThoat = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.imageList1 = new System.Windows.Forms.ImageList();
            this.defaultLookAndFeel1 = new DevExpress.LookAndFeel.DefaultLookAndFeel();
            this.txt_DienGiai = new DevExpress.XtraEditors.TextEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txtMaQuanLy = new DevExpress.XtraEditors.TextEdit();
            this.checkEdit_TinhTrang = new DevExpress.XtraEditors.CheckEdit();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.labelControl9 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
            this.txt_TenDonViTinh = new DevExpress.XtraEditors.TextEdit();
            this.grd_DVT = new DevExpress.XtraGrid.GridControl();
            this.gridView_DMDonViTinh = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colMaQuanLy = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTenDonViTinh = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMaTinhTrang = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEdit_TinhTrang = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.colDienGiai = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.bs_DonViTinhList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mainMenuBarManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_DienGiai.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaQuanLy.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit_TinhTrang.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txt_TenDonViTinh.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grd_DVT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_DMDonViTinh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit_TinhTrang)).BeginInit();
            this.SuspendLayout();
            // 
            // bs_DonViTinhList
            // 
            this.bs_DonViTinhList.DataSource = typeof(ERP_Library.DonViTinhList);
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
            this.btnXoa,
            this.btnLuu,
            this.barButtonItem5,
            this.btnPrint,
            this.btnThoat,
            this.btnHelp,
            this.barButtonItem1});
            this.mainMenuBarManager.LargeImages = this.imageList1;
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
            this.mainMenuBar.FloatLocation = new System.Drawing.Point(244, 250);
            this.mainMenuBar.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnThemMoi, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnXoa, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barButtonItem1, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
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
            this.btnThemMoi.Id = 0;
            this.btnThemMoi.ImageIndex = 0;
            this.btnThemMoi.ItemShortcut = new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N));
            this.btnThemMoi.Name = "btnThemMoi";
            this.btnThemMoi.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnThemMoi_ItemClick);
            // 
            // btnXoa
            // 
            this.btnXoa.Caption = "Xóa";
            this.btnXoa.Id = 2;
            this.btnXoa.ImageIndex = 2;
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
            this.barButtonItem1.Id = 8;
            this.barButtonItem1.ImageIndex = 9;
            this.barButtonItem1.ItemShortcut = new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Z));
            this.barButtonItem1.Name = "barButtonItem1";
            this.barButtonItem1.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem1_ItemClick);
            // 
            // btnLuu
            // 
            this.btnLuu.Caption = "Lưu";
            this.btnLuu.Id = 3;
            this.btnLuu.ImageIndex = 5;
            this.btnLuu.ItemShortcut = new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S));
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnLuu_ItemClick);
            // 
            // barButtonItem5
            // 
            this.barButtonItem5.Caption = "Refresh";
            this.barButtonItem5.Id = 4;
            this.barButtonItem5.ImageIndex = 9;
            this.barButtonItem5.Name = "barButtonItem5";
            this.barButtonItem5.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            // 
            // btnPrint
            // 
            this.btnPrint.Caption = "In";
            this.btnPrint.Id = 5;
            this.btnPrint.ImageIndex = 7;
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            // 
            // btnHelp
            // 
            this.btnHelp.Caption = "Trợ giúp";
            this.btnHelp.Id = 7;
            this.btnHelp.ImageIndex = 6;
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            // 
            // btnThoat
            // 
            this.btnThoat.Caption = "Thoát";
            this.btnThoat.Id = 6;
            this.btnThoat.ImageIndex = 8;
            this.btnThoat.ItemShortcut = new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.X));
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnThoat_ItemClick);
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(966, 32);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 447);
            this.barDockControlBottom.Size = new System.Drawing.Size(966, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 32);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 415);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(966, 32);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 415);
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
            // defaultLookAndFeel1
            // 
            this.defaultLookAndFeel1.LookAndFeel.SkinName = "Office 2010 Blue";
            // 
            // txt_DienGiai
            // 
            this.txt_DienGiai.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bs_DonViTinhList, "DienGiai", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.txt_DienGiai.Location = new System.Drawing.Point(144, 66);
            this.txt_DienGiai.Name = "txt_DienGiai";
            this.txt_DienGiai.Properties.Appearance.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_DienGiai.Properties.Appearance.Options.UseFont = true;
            this.txt_DienGiai.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            this.txt_DienGiai.Size = new System.Drawing.Size(581, 22);
            this.txt_DienGiai.TabIndex = 3;
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl3.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.labelControl3.LineColor = System.Drawing.Color.Lime;
            this.labelControl3.Location = new System.Drawing.Point(74, 43);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(64, 15);
            this.labelControl3.TabIndex = 4;
            this.labelControl3.Text = "Đơn vị tính:";
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.labelControl1.LineColor = System.Drawing.Color.Lime;
            this.labelControl1.LineVisible = true;
            this.labelControl1.Location = new System.Drawing.Point(74, 18);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(50, 15);
            this.labelControl1.TabIndex = 2;
            this.labelControl1.Text = "Mã ĐVT:";
            // 
            // txtMaQuanLy
            // 
            this.txtMaQuanLy.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bs_DonViTinhList, "MaQuanLy", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.txtMaQuanLy.Location = new System.Drawing.Point(144, 15);
            this.txtMaQuanLy.Name = "txtMaQuanLy";
            this.txtMaQuanLy.Properties.Appearance.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaQuanLy.Properties.Appearance.Options.UseFont = true;
            this.txtMaQuanLy.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            this.txtMaQuanLy.Size = new System.Drawing.Size(162, 22);
            this.txtMaQuanLy.TabIndex = 0;
            // 
            // checkEdit_TinhTrang
            // 
            this.checkEdit_TinhTrang.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bs_DonViTinhList, "MaTinhTrang", true));
            this.checkEdit_TinhTrang.EditValue = true;
            this.checkEdit_TinhTrang.Location = new System.Drawing.Point(399, 13);
            this.checkEdit_TinhTrang.MenuManager = this.mainMenuBarManager;
            this.checkEdit_TinhTrang.Name = "checkEdit_TinhTrang";
            this.checkEdit_TinhTrang.Properties.Appearance.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkEdit_TinhTrang.Properties.Appearance.Options.UseFont = true;
            this.checkEdit_TinhTrang.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            this.checkEdit_TinhTrang.Properties.Caption = "Có sử dụng";
            this.checkEdit_TinhTrang.Properties.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.Style1;
            this.checkEdit_TinhTrang.Properties.DisplayValueChecked = "1";
            this.checkEdit_TinhTrang.Properties.DisplayValueUnchecked = "0";
            this.checkEdit_TinhTrang.Size = new System.Drawing.Size(175, 24);
            this.checkEdit_TinhTrang.TabIndex = 1;
            // 
            // panelControl1
            // 
            this.panelControl1.Appearance.BackColor = System.Drawing.Color.LightCyan;
            this.panelControl1.Appearance.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.panelControl1.Appearance.Options.UseBackColor = true;
            this.panelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.panelControl1.Controls.Add(this.txt_DienGiai);
            this.panelControl1.Controls.Add(this.checkEdit_TinhTrang);
            this.panelControl1.Controls.Add(this.labelControl9);
            this.panelControl1.Controls.Add(this.labelControl8);
            this.panelControl1.Controls.Add(this.txt_TenDonViTinh);
            this.panelControl1.Controls.Add(this.labelControl3);
            this.panelControl1.Controls.Add(this.labelControl1);
            this.panelControl1.Controls.Add(this.txtMaQuanLy);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 32);
            this.panelControl1.LookAndFeel.SkinName = "Office 2010 Silver";
            this.panelControl1.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.UltraFlat;
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(966, 98);
            this.panelControl1.TabIndex = 4;
            // 
            // labelControl9
            // 
            this.labelControl9.Appearance.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl9.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.labelControl9.LineColor = System.Drawing.Color.Lime;
            this.labelControl9.Location = new System.Drawing.Point(74, 69);
            this.labelControl9.Name = "labelControl9";
            this.labelControl9.Size = new System.Drawing.Size(54, 15);
            this.labelControl9.TabIndex = 10;
            this.labelControl9.Text = "Diễn giải:";
            // 
            // labelControl8
            // 
            this.labelControl8.Appearance.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl8.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.labelControl8.LineColor = System.Drawing.Color.Lime;
            this.labelControl8.Location = new System.Drawing.Point(330, 18);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new System.Drawing.Size(63, 15);
            this.labelControl8.TabIndex = 9;
            this.labelControl8.Text = "Tình trạng:";
            // 
            // txt_TenDonViTinh
            // 
            this.txt_TenDonViTinh.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bs_DonViTinhList, "TenDonViTinh", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.txt_TenDonViTinh.Location = new System.Drawing.Point(144, 40);
            this.txt_TenDonViTinh.Name = "txt_TenDonViTinh";
            this.txt_TenDonViTinh.Properties.Appearance.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_TenDonViTinh.Properties.Appearance.Options.UseFont = true;
            this.txt_TenDonViTinh.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            this.txt_TenDonViTinh.Size = new System.Drawing.Size(344, 22);
            this.txt_TenDonViTinh.TabIndex = 2;
            // 
            // grd_DVT
            // 
            this.grd_DVT.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.grd_DVT.DataSource = this.bs_DonViTinhList;
            this.grd_DVT.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grd_DVT.EmbeddedNavigator.Text = "show ra tiêu đề";
            this.grd_DVT.EmbeddedNavigator.ToolTipTitle = "ToolTipTitle";
            this.grd_DVT.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grd_DVT.Location = new System.Drawing.Point(0, 130);
            this.grd_DVT.LookAndFeel.SkinName = "Office 2010 Silver";
            this.grd_DVT.LookAndFeel.UseDefaultLookAndFeel = false;
            this.grd_DVT.MainView = this.gridView_DMDonViTinh;
            this.grd_DVT.MenuManager = this.mainMenuBarManager;
            this.grd_DVT.Name = "grd_DVT";
            this.grd_DVT.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCheckEdit_TinhTrang});
            this.grd_DVT.Size = new System.Drawing.Size(966, 317);
            this.grd_DVT.TabIndex = 0;
            this.grd_DVT.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView_DMDonViTinh});
            // 
            // gridView_DMDonViTinh
            // 
            this.gridView_DMDonViTinh.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridView_DMDonViTinh.Appearance.HeaderPanel.ForeColor = System.Drawing.Color.RoyalBlue;
            this.gridView_DMDonViTinh.Appearance.HeaderPanel.Options.UseFont = true;
            this.gridView_DMDonViTinh.Appearance.HeaderPanel.Options.UseForeColor = true;
            this.gridView_DMDonViTinh.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.gridView_DMDonViTinh.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridView_DMDonViTinh.Appearance.HeaderPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridView_DMDonViTinh.Appearance.ViewCaption.Font = new System.Drawing.Font("Times New Roman", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridView_DMDonViTinh.Appearance.ViewCaption.ForeColor = System.Drawing.Color.Red;
            this.gridView_DMDonViTinh.Appearance.ViewCaption.Options.UseFont = true;
            this.gridView_DMDonViTinh.Appearance.ViewCaption.Options.UseForeColor = true;
            this.gridView_DMDonViTinh.AppearancePrint.GroupFooter.BackColor = System.Drawing.Color.SandyBrown;
            this.gridView_DMDonViTinh.AppearancePrint.GroupFooter.ForeColor = System.Drawing.SystemColors.Desktop;
            this.gridView_DMDonViTinh.AppearancePrint.GroupFooter.Options.UseBackColor = true;
            this.gridView_DMDonViTinh.AppearancePrint.GroupFooter.Options.UseForeColor = true;
            this.gridView_DMDonViTinh.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colMaQuanLy,
            this.colTenDonViTinh,
            this.colMaTinhTrang,
            this.colDienGiai});
            this.gridView_DMDonViTinh.GridControl = this.grd_DVT;
            this.gridView_DMDonViTinh.GroupPanelText = "Danh Mục Đơn Vị Tính";
            this.gridView_DMDonViTinh.Name = "gridView_DMDonViTinh";
            this.gridView_DMDonViTinh.OptionsBehavior.ReadOnly = true;
            this.gridView_DMDonViTinh.OptionsNavigation.AutoFocusNewRow = true;
            this.gridView_DMDonViTinh.OptionsView.ShowAutoFilterRow = true;
            this.gridView_DMDonViTinh.OptionsView.ShowFooter = true;
            // 
            // colMaQuanLy
            // 
            this.colMaQuanLy.Caption = "Mã ĐVT";
            this.colMaQuanLy.FieldName = "MaQuanLy";
            this.colMaQuanLy.Name = "colMaQuanLy";
            this.colMaQuanLy.Visible = true;
            this.colMaQuanLy.VisibleIndex = 0;
            // 
            // colTenDonViTinh
            // 
            this.colTenDonViTinh.Caption = "Tên đơn vị tính";
            this.colTenDonViTinh.FieldName = "TenDonViTinh";
            this.colTenDonViTinh.Name = "colTenDonViTinh";
            this.colTenDonViTinh.Visible = true;
            this.colTenDonViTinh.VisibleIndex = 1;
            // 
            // colMaTinhTrang
            // 
            this.colMaTinhTrang.Caption = "Tình Trạng";
            this.colMaTinhTrang.ColumnEdit = this.repositoryItemCheckEdit_TinhTrang;
            this.colMaTinhTrang.FieldName = "MaTinhTrang";
            this.colMaTinhTrang.Name = "colMaTinhTrang";
            this.colMaTinhTrang.Visible = true;
            this.colMaTinhTrang.VisibleIndex = 2;
            // 
            // repositoryItemCheckEdit_TinhTrang
            // 
            this.repositoryItemCheckEdit_TinhTrang.AppearanceReadOnly.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.repositoryItemCheckEdit_TinhTrang.AppearanceReadOnly.Options.UseFont = true;
            this.repositoryItemCheckEdit_TinhTrang.AutoHeight = false;
            this.repositoryItemCheckEdit_TinhTrang.Caption = "";
            this.repositoryItemCheckEdit_TinhTrang.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.Style1;
            this.repositoryItemCheckEdit_TinhTrang.DisplayValueChecked = "Tình Trạng";
            this.repositoryItemCheckEdit_TinhTrang.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.repositoryItemCheckEdit_TinhTrang.Name = "repositoryItemCheckEdit_TinhTrang";
            this.repositoryItemCheckEdit_TinhTrang.NullText = "Có sử dụng";
            // 
            // colDienGiai
            // 
            this.colDienGiai.Caption = "Diễn Giải";
            this.colDienGiai.FieldName = "DienGiai";
            this.colDienGiai.Name = "colDienGiai";
            this.colDienGiai.Visible = true;
            this.colDienGiai.VisibleIndex = 3;
            // 
            // XtraFrm_DonViTinh
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(966, 447);
            this.Controls.Add(this.grd_DVT);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "XtraFrm_DonViTinh";
            this.Text = "Danh Mục Đơn Vị Tính";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.XtraFrm_DonViTinh_FormClosing);
            this.Load += new System.EventHandler(this.XtraFrm_DonViTinh_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bs_DonViTinhList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mainMenuBarManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_DienGiai.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaQuanLy.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit_TinhTrang.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txt_TenDonViTinh.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grd_DVT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_DMDonViTinh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit_TinhTrang)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.BindingSource bs_DonViTinhList;
        private DevExpress.XtraBars.BarManager mainMenuBarManager;
        private DevExpress.XtraBars.Bar mainMenuBar;
        private DevExpress.XtraBars.BarButtonItem btnThemMoi;
        private DevExpress.XtraBars.BarButtonItem btnXoa;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private DevExpress.XtraBars.BarButtonItem btnLuu;
        private DevExpress.XtraBars.BarButtonItem barButtonItem5;
        private DevExpress.XtraBars.BarButtonItem btnPrint;
        private DevExpress.XtraBars.BarButtonItem btnHelp;
        private DevExpress.XtraBars.BarButtonItem btnThoat;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private System.Windows.Forms.ImageList imageList1;
        private DevExpress.LookAndFeel.DefaultLookAndFeel defaultLookAndFeel1;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.TextEdit txt_DienGiai;
        private DevExpress.XtraEditors.CheckEdit checkEdit_TinhTrang;
        private DevExpress.XtraEditors.LabelControl labelControl9;
        private DevExpress.XtraEditors.LabelControl labelControl8;
        private DevExpress.XtraEditors.TextEdit txt_TenDonViTinh;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit txtMaQuanLy;
        private DevExpress.XtraGrid.GridControl grd_DVT;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView_DMDonViTinh;
        private DevExpress.XtraGrid.Columns.GridColumn colMaQuanLy;
        private DevExpress.XtraGrid.Columns.GridColumn colTenDonViTinh;
        private DevExpress.XtraGrid.Columns.GridColumn colMaTinhTrang;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit_TinhTrang;
        private DevExpress.XtraGrid.Columns.GridColumn colDienGiai;
    }
}