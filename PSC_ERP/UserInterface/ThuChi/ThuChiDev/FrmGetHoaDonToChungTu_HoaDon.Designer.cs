namespace PSC_ERP
{
    partial class FrmGetHoaDonToChungTu_HoaDon
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmGetHoaDonToChungTu_HoaDon));
            DevExpress.Utils.SuperToolTip superToolTip1 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem1 = new DevExpress.Utils.ToolTipTitleItem();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.mainMenuBarManager = new DevExpress.XtraBars.BarManager(this.components);
            this.mainMenuBar = new DevExpress.XtraBars.Bar();
            this.New_barSubItem = new DevExpress.XtraBars.BarSubItem();
            this.NewVAT_barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.NewNoVAT_barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.NewBanra_barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.btnChon = new DevExpress.XtraBars.BarButtonItem();
            this.btnThemChungTu = new DevExpress.XtraBars.BarButtonItem();
            this.btnThoat = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.btnXoa = new DevExpress.XtraBars.BarButtonItem();
            this.btnLuu = new DevExpress.XtraBars.BarButtonItem();
            this.btnRefresh = new DevExpress.XtraBars.BarButtonItem();
            this.btnPrint = new DevExpress.XtraBars.BarButtonItem();
            this.btnHelp = new DevExpress.XtraBars.BarButtonItem();
            this.btnUndo = new DevExpress.XtraBars.BarButtonItem();
            this.btnChonPhieuNhap = new DevExpress.XtraBars.BarButtonItem();
            this.HoaDonListgridControl = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.repositoryItemLookUpEdit_HangHoa = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.repositoryItemLookUpEdit_DonViTinh = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.repositoryItemLookUpEdit_SoPhieuNhap = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.repositoryItemLookUpEdit_NguonList = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.DSHoaDonDichVu_BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.FocustextBox1 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.mainMenuBarManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.HoaDonListgridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit_HangHoa)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit_DonViTinh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit_SoPhieuNhap)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit_NguonList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DSHoaDonDichVu_BindingSource)).BeginInit();
            this.SuspendLayout();
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
            this.btnChon,
            this.btnXoa,
            this.btnLuu,
            this.btnRefresh,
            this.btnPrint,
            this.btnThoat,
            this.btnHelp,
            this.btnUndo,
            this.btnChonPhieuNhap,
            this.New_barSubItem,
            this.NewVAT_barButtonItem1,
            this.NewNoVAT_barButtonItem1,
            this.NewBanra_barButtonItem1,
            this.btnThemChungTu});
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
            this.mainMenuBar.FloatLocation = new System.Drawing.Point(244, 250);
            this.mainMenuBar.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.New_barSubItem, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnChon, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnThemChungTu, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnThoat, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)});
            this.mainMenuBar.OptionsBar.MultiLine = true;
            this.mainMenuBar.OptionsBar.UseWholeRow = true;
            this.mainMenuBar.Text = "Main menu";
            // 
            // New_barSubItem
            // 
            this.New_barSubItem.Caption = "Thêm mới";
            this.New_barSubItem.Id = 10;
            this.New_barSubItem.ImageIndex = 0;
            this.New_barSubItem.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.NewVAT_barButtonItem1),
            new DevExpress.XtraBars.LinkPersistInfo(this.NewNoVAT_barButtonItem1),
            new DevExpress.XtraBars.LinkPersistInfo(this.NewBanra_barButtonItem1, true)});
            this.New_barSubItem.Name = "New_barSubItem";
            // 
            // NewVAT_barButtonItem1
            // 
            this.NewVAT_barButtonItem1.Caption = "Hóa đơn mua vào có VAT";
            this.NewVAT_barButtonItem1.Id = 11;
            this.NewVAT_barButtonItem1.Name = "NewVAT_barButtonItem1";
            this.NewVAT_barButtonItem1.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.NewVAT_barButtonItem1_ItemClick);
            // 
            // NewNoVAT_barButtonItem1
            // 
            this.NewNoVAT_barButtonItem1.Caption = "Hóa đơn mua vào không có VAT";
            this.NewNoVAT_barButtonItem1.Id = 12;
            this.NewNoVAT_barButtonItem1.Name = "NewNoVAT_barButtonItem1";
            this.NewNoVAT_barButtonItem1.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.NewNoVAT_barButtonItem1_ItemClick);
            // 
            // NewBanra_barButtonItem1
            // 
            this.NewBanra_barButtonItem1.Caption = "Hóa đơn bán ra";
            this.NewBanra_barButtonItem1.Id = 13;
            this.NewBanra_barButtonItem1.Name = "NewBanra_barButtonItem1";
            this.NewBanra_barButtonItem1.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.NewBanra_barButtonItem1_ItemClick);
            // 
            // btnChon
            // 
            this.btnChon.Caption = "Chọn";
            this.btnChon.Id = 0;
            this.btnChon.ImageIndex = 1;
            this.btnChon.ItemShortcut = new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.I));
            this.btnChon.Name = "btnChon";
            this.btnChon.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnChon_ItemClick);
            // 
            // btnThemChungTu
            // 
            this.btnThemChungTu.Caption = "Thêm mới CT mua chưa TT";
            this.btnThemChungTu.Id = 14;
            this.btnThemChungTu.ImageIndex = 0;
            this.btnThemChungTu.Name = "btnThemChungTu";
            this.btnThemChungTu.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.btnThemChungTu.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnThemChungTu_ItemClick);
            // 
            // btnThoat
            // 
            this.btnThoat.Caption = "Thoát";
            this.btnThoat.Id = 6;
            this.btnThoat.ImageIndex = 8;
            this.btnThoat.ItemShortcut = new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Q));
            this.btnThoat.Name = "btnThoat";
            toolTipTitleItem1.Text = "Ctrl+Q";
            superToolTip1.Items.Add(toolTipTitleItem1);
            this.btnThoat.SuperTip = superToolTip1;
            this.btnThoat.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnThoat_ItemClick);
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(1022, 34);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 471);
            this.barDockControlBottom.Size = new System.Drawing.Size(1022, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 34);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 437);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(1022, 34);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 437);
            // 
            // btnXoa
            // 
            this.btnXoa.Caption = "Xóa";
            this.btnXoa.Id = 2;
            this.btnXoa.ImageIndex = 2;
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            // 
            // btnLuu
            // 
            this.btnLuu.Caption = "Lưu";
            this.btnLuu.Id = 3;
            this.btnLuu.ImageIndex = 5;
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.btnLuu.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnLuu_ItemClick);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Caption = "Refresh";
            this.btnRefresh.Id = 4;
            this.btnRefresh.ImageIndex = 9;
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
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
            // btnUndo
            // 
            this.btnUndo.Caption = "Undo";
            this.btnUndo.Id = 8;
            this.btnUndo.ImageIndex = 4;
            this.btnUndo.Name = "btnUndo";
            this.btnUndo.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            // 
            // btnChonPhieuNhap
            // 
            this.btnChonPhieuNhap.Caption = "Chọn Phiếu Nhập";
            this.btnChonPhieuNhap.Id = 9;
            this.btnChonPhieuNhap.Name = "btnChonPhieuNhap";
            this.btnChonPhieuNhap.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            // 
            // HoaDonListgridControl
            // 
            this.HoaDonListgridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.HoaDonListgridControl.Location = new System.Drawing.Point(0, 34);
            this.HoaDonListgridControl.MainView = this.gridView1;
            this.HoaDonListgridControl.Name = "HoaDonListgridControl";
            this.HoaDonListgridControl.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCheckEdit1,
            this.repositoryItemLookUpEdit_HangHoa,
            this.repositoryItemLookUpEdit_DonViTinh,
            this.repositoryItemLookUpEdit_SoPhieuNhap,
            this.repositoryItemLookUpEdit_NguonList});
            this.HoaDonListgridControl.Size = new System.Drawing.Size(1022, 437);
            this.HoaDonListgridControl.TabIndex = 5;
            this.HoaDonListgridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.HoaDonListgridControl;
            this.gridView1.GroupPanelText = "Danh Sách Hóa Đơn";
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.DoubleClick += new System.EventHandler(this.gridView1_DoubleClick);
            // 
            // repositoryItemCheckEdit1
            // 
            this.repositoryItemCheckEdit1.AutoHeight = false;
            this.repositoryItemCheckEdit1.Caption = "Chọn xuất thẳng";
            this.repositoryItemCheckEdit1.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.Style1;
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            this.repositoryItemCheckEdit1.EditValueChanged += new System.EventHandler(this.repositoryItemCheckEdit1_EditValueChanged);
            // 
            // repositoryItemLookUpEdit_HangHoa
            // 
            this.repositoryItemLookUpEdit_HangHoa.AutoHeight = false;
            this.repositoryItemLookUpEdit_HangHoa.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemLookUpEdit_HangHoa.DisplayMember = "TenHangHoa";
            this.repositoryItemLookUpEdit_HangHoa.Name = "repositoryItemLookUpEdit_HangHoa";
            this.repositoryItemLookUpEdit_HangHoa.ReadOnly = true;
            this.repositoryItemLookUpEdit_HangHoa.ValueMember = "MaHangHoa";
            // 
            // repositoryItemLookUpEdit_DonViTinh
            // 
            this.repositoryItemLookUpEdit_DonViTinh.AutoHeight = false;
            this.repositoryItemLookUpEdit_DonViTinh.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemLookUpEdit_DonViTinh.DisplayMember = "TenDonViTinh";
            this.repositoryItemLookUpEdit_DonViTinh.Name = "repositoryItemLookUpEdit_DonViTinh";
            this.repositoryItemLookUpEdit_DonViTinh.ReadOnly = true;
            this.repositoryItemLookUpEdit_DonViTinh.ValueMember = "MaDonViTinh";
            // 
            // repositoryItemLookUpEdit_SoPhieuNhap
            // 
            this.repositoryItemLookUpEdit_SoPhieuNhap.AutoHeight = false;
            this.repositoryItemLookUpEdit_SoPhieuNhap.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemLookUpEdit_SoPhieuNhap.DisplayMember = "SoPhieu";
            this.repositoryItemLookUpEdit_SoPhieuNhap.Name = "repositoryItemLookUpEdit_SoPhieuNhap";
            this.repositoryItemLookUpEdit_SoPhieuNhap.ReadOnly = true;
            this.repositoryItemLookUpEdit_SoPhieuNhap.ValueMember = "MaPhieuNhapXuat";
            // 
            // repositoryItemLookUpEdit_NguonList
            // 
            this.repositoryItemLookUpEdit_NguonList.AutoHeight = false;
            this.repositoryItemLookUpEdit_NguonList.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemLookUpEdit_NguonList.DisplayMember = "TenNguon";
            this.repositoryItemLookUpEdit_NguonList.Name = "repositoryItemLookUpEdit_NguonList";
            this.repositoryItemLookUpEdit_NguonList.ReadOnly = true;
            this.repositoryItemLookUpEdit_NguonList.ValueMember = "MaNguon";
            // 
            // DSHoaDonDichVu_BindingSource
            // 
            this.DSHoaDonDichVu_BindingSource.AllowNew = false;
            this.DSHoaDonDichVu_BindingSource.DataSource = typeof(ERP_Library.HoaDonList);
            // 
            // FocustextBox1
            // 
            this.FocustextBox1.Location = new System.Drawing.Point(376, 180);
            this.FocustextBox1.Name = "FocustextBox1";
            this.FocustextBox1.Size = new System.Drawing.Size(100, 21);
            this.FocustextBox1.TabIndex = 100;
            this.FocustextBox1.TabStop = false;
            // 
            // FrmGetHoaDonToChungTu_HoaDon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1022, 471);
            this.Controls.Add(this.HoaDonListgridControl);
            this.Controls.Add(this.FocustextBox1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "FrmGetHoaDonToChungTu_HoaDon";
            this.Text = "Danh Sách Hóa Đơn";
            ((System.ComponentModel.ISupportInitialize)(this.mainMenuBarManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.HoaDonListgridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit_HangHoa)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit_DonViTinh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit_SoPhieuNhap)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit_NguonList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DSHoaDonDichVu_BindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ImageList imageList1;
        private DevExpress.XtraBars.BarManager mainMenuBarManager;
        private DevExpress.XtraBars.Bar mainMenuBar;
        private DevExpress.XtraBars.BarButtonItem btnChon;
        private DevExpress.XtraBars.BarButtonItem btnXoa;
        private DevExpress.XtraBars.BarButtonItem btnUndo;
        private DevExpress.XtraBars.BarButtonItem btnLuu;
        private DevExpress.XtraBars.BarButtonItem btnRefresh;
        private DevExpress.XtraBars.BarButtonItem btnPrint;
        private DevExpress.XtraBars.BarButtonItem btnHelp;
        private DevExpress.XtraBars.BarButtonItem btnThoat;
        private DevExpress.XtraBars.BarButtonItem btnChonPhieuNhap;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraGrid.GridControl HoaDonListgridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit_HangHoa;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit_DonViTinh;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit_SoPhieuNhap;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit_NguonList;
        private System.Windows.Forms.BindingSource DSHoaDonDichVu_BindingSource;
        private DevExpress.XtraBars.BarSubItem New_barSubItem;
        private DevExpress.XtraBars.BarButtonItem NewVAT_barButtonItem1;
        private DevExpress.XtraBars.BarButtonItem NewNoVAT_barButtonItem1;
        private DevExpress.XtraBars.BarButtonItem NewBanra_barButtonItem1;
        private System.Windows.Forms.TextBox FocustextBox1;
        private DevExpress.XtraBars.BarButtonItem btnThemChungTu;
    }
}