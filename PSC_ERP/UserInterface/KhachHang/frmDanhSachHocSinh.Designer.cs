namespace PSC_ERP.UserInterface.KhachHang
{
    partial class frmDanhSachHocSinh
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
            DevExpress.Utils.SuperToolTip superToolTip1 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem1 = new DevExpress.Utils.ToolTipTitleItem();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDanhSachHocSinh));
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colCheck = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMaDoiTac = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMaQLDoiTac = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCmnd = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNgayLap = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNgaySinh = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGioiTinh = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTenLop = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTen = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNamHoc = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTenKhoi = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTenTruong = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNoiCap = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTenDoiTac = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTenVietTat = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMaSoThue = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTinhTrang = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLoaiDoiTac = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMaCongTy = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDienGiai = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTenDayDu = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMaBoPhan = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTenBoPhan = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDiaChi = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDienThoai = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNhaCungCap = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKhachHang = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.bindingSource_HocSinh = new System.Windows.Forms.BindingSource(this.components);
            this.mainMenuBarManager = new DevExpress.XtraBars.BarManager(this.components);
            this.mainMenuBar = new DevExpress.XtraBars.Bar();
            this.btnExcel = new DevExpress.XtraBars.BarButtonItem();
            this.btnThoat = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.FocustextBox1 = new System.Windows.Forms.TextBox();
            this.defaultLookAndFeel1 = new DevExpress.LookAndFeel.DefaultLookAndFeel(this.components);
            this.btnSearch = new DevExpress.XtraBars.BarButtonItem();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource_HocSinh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mainMenuBarManager)).BeginInit();
            this.SuspendLayout();
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colCheck,
            this.colMaDoiTac,
            this.colMaQLDoiTac,
            this.colCmnd,
            this.colNgayLap,
            this.colNgaySinh,
            this.colGioiTinh,
            this.colTenLop,
            this.colTen,
            this.colNamHoc,
            this.colTenKhoi,
            this.colTenTruong,
            this.colNoiCap,
            this.colTenDoiTac,
            this.colTenVietTat,
            this.colMaSoThue,
            this.colTinhTrang,
            this.colLoaiDoiTac,
            this.colMaCongTy,
            this.colDienGiai,
            this.colTenDayDu,
            this.colMaBoPhan,
            this.colTenBoPhan,
            this.colDiaChi,
            this.colDienThoai,
            this.colNhaCungCap,
            this.colKhachHang});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsBehavior.ReadOnly = true;
            this.gridView1.OptionsDetail.EnableMasterViewMode = false;
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            this.gridView1.OptionsView.ShowFooter = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // colCheck
            // 
            this.colCheck.FieldName = "Check";
            this.colCheck.Name = "colCheck";
            // 
            // colMaDoiTac
            // 
            this.colMaDoiTac.FieldName = "MaDoiTac";
            this.colMaDoiTac.Name = "colMaDoiTac";
            this.colMaDoiTac.OptionsColumn.ReadOnly = true;
            // 
            // colMaQLDoiTac
            // 
            this.colMaQLDoiTac.AppearanceHeader.Options.UseTextOptions = true;
            this.colMaQLDoiTac.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colMaQLDoiTac.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colMaQLDoiTac.Caption = "Mã QL ";
            this.colMaQLDoiTac.FieldName = "MaQLDoiTac";
            this.colMaQLDoiTac.Name = "colMaQLDoiTac";
            this.colMaQLDoiTac.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colMaQLDoiTac.Visible = true;
            this.colMaQLDoiTac.VisibleIndex = 0;
            // 
            // colCmnd
            // 
            this.colCmnd.FieldName = "Cmnd";
            this.colCmnd.Name = "colCmnd";
            // 
            // colNgayLap
            // 
            this.colNgayLap.FieldName = "NgayLap";
            this.colNgayLap.Name = "colNgayLap";
            // 
            // colNgaySinh
            // 
            this.colNgaySinh.FieldName = "NgaySinh";
            this.colNgaySinh.Name = "colNgaySinh";
            // 
            // colGioiTinh
            // 
            this.colGioiTinh.FieldName = "GioiTinh";
            this.colGioiTinh.Name = "colGioiTinh";
            // 
            // colTenLop
            // 
            this.colTenLop.FieldName = "TenLop";
            this.colTenLop.Name = "colTenLop";
            // 
            // colTen
            // 
            this.colTen.FieldName = "Ten";
            this.colTen.Name = "colTen";
            // 
            // colNamHoc
            // 
            this.colNamHoc.FieldName = "NamHoc";
            this.colNamHoc.Name = "colNamHoc";
            // 
            // colTenKhoi
            // 
            this.colTenKhoi.FieldName = "TenKhoi";
            this.colTenKhoi.Name = "colTenKhoi";
            // 
            // colTenTruong
            // 
            this.colTenTruong.AppearanceHeader.Options.UseTextOptions = true;
            this.colTenTruong.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colTenTruong.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colTenTruong.Caption = "Tên Trường";
            this.colTenTruong.FieldName = "TenTruong";
            this.colTenTruong.Name = "colTenTruong";
            this.colTenTruong.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colTenTruong.Visible = true;
            this.colTenTruong.VisibleIndex = 2;
            // 
            // colNoiCap
            // 
            this.colNoiCap.FieldName = "NoiCap";
            this.colNoiCap.Name = "colNoiCap";
            // 
            // colTenDoiTac
            // 
            this.colTenDoiTac.AppearanceHeader.Options.UseTextOptions = true;
            this.colTenDoiTac.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colTenDoiTac.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colTenDoiTac.Caption = "Tên Đối Tác";
            this.colTenDoiTac.FieldName = "TenDoiTac";
            this.colTenDoiTac.Name = "colTenDoiTac";
            this.colTenDoiTac.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colTenDoiTac.Visible = true;
            this.colTenDoiTac.VisibleIndex = 1;
            // 
            // colTenVietTat
            // 
            this.colTenVietTat.FieldName = "TenVietTat";
            this.colTenVietTat.Name = "colTenVietTat";
            // 
            // colMaSoThue
            // 
            this.colMaSoThue.FieldName = "MaSoThue";
            this.colMaSoThue.Name = "colMaSoThue";
            // 
            // colTinhTrang
            // 
            this.colTinhTrang.FieldName = "TinhTrang";
            this.colTinhTrang.Name = "colTinhTrang";
            // 
            // colLoaiDoiTac
            // 
            this.colLoaiDoiTac.FieldName = "LoaiDoiTac";
            this.colLoaiDoiTac.Name = "colLoaiDoiTac";
            // 
            // colMaCongTy
            // 
            this.colMaCongTy.FieldName = "MaCongTy";
            this.colMaCongTy.Name = "colMaCongTy";
            // 
            // colDienGiai
            // 
            this.colDienGiai.FieldName = "DienGiai";
            this.colDienGiai.Name = "colDienGiai";
            // 
            // colTenDayDu
            // 
            this.colTenDayDu.FieldName = "TenDayDu";
            this.colTenDayDu.Name = "colTenDayDu";
            this.colTenDayDu.OptionsColumn.ReadOnly = true;
            // 
            // colMaBoPhan
            // 
            this.colMaBoPhan.FieldName = "MaBoPhan";
            this.colMaBoPhan.Name = "colMaBoPhan";
            this.colMaBoPhan.OptionsColumn.ReadOnly = true;
            // 
            // colTenBoPhan
            // 
            this.colTenBoPhan.FieldName = "TenBoPhan";
            this.colTenBoPhan.Name = "colTenBoPhan";
            this.colTenBoPhan.OptionsColumn.ReadOnly = true;
            // 
            // colDiaChi
            // 
            this.colDiaChi.FieldName = "DiaChi";
            this.colDiaChi.Name = "colDiaChi";
            this.colDiaChi.OptionsColumn.ReadOnly = true;
            // 
            // colDienThoai
            // 
            this.colDienThoai.FieldName = "DienThoai";
            this.colDienThoai.Name = "colDienThoai";
            this.colDienThoai.OptionsColumn.ReadOnly = true;
            // 
            // colNhaCungCap
            // 
            this.colNhaCungCap.FieldName = "NhaCungCap";
            this.colNhaCungCap.Name = "colNhaCungCap";
            this.colNhaCungCap.OptionsColumn.ReadOnly = true;
            // 
            // colKhachHang
            // 
            this.colKhachHang.FieldName = "KhachHang";
            this.colKhachHang.Name = "colKhachHang";
            this.colKhachHang.OptionsColumn.ReadOnly = true;
            // 
            // gridControl1
            // 
            this.gridControl1.DataSource = this.bindingSource_HocSinh;
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 34);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.MenuManager = this.mainMenuBarManager;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(817, 623);
            this.gridControl1.TabIndex = 109;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // bindingSource_HocSinh
            // 
            this.bindingSource_HocSinh.DataSource = typeof(ERP_Library.DoiTacList);
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
            this.btnExcel,
            this.btnThoat,
            this.btnSearch});
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
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnExcel, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnSearch, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnThoat, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)});
            this.mainMenuBar.OptionsBar.MultiLine = true;
            this.mainMenuBar.OptionsBar.UseWholeRow = true;
            this.mainMenuBar.Text = "Main menu";
            // 
            // btnExcel
            // 
            this.btnExcel.Caption = "Excel";
            this.btnExcel.Id = 0;
            this.btnExcel.ImageIndex = 3;
            this.btnExcel.ItemShortcut = new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.I));
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnExcel_ItemClick);
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
            this.barDockControlTop.Size = new System.Drawing.Size(817, 34);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 657);
            this.barDockControlBottom.Size = new System.Drawing.Size(817, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 34);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 623);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(817, 34);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 623);
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
            // FocustextBox1
            // 
            this.FocustextBox1.Location = new System.Drawing.Point(376, 146);
            this.FocustextBox1.Name = "FocustextBox1";
            this.FocustextBox1.Size = new System.Drawing.Size(100, 21);
            this.FocustextBox1.TabIndex = 110;
            this.FocustextBox1.TabStop = false;
            // 
            // defaultLookAndFeel1
            // 
            this.defaultLookAndFeel1.LookAndFeel.SkinName = "Office 2010 Blue";
            // 
            // btnSearch
            // 
            this.btnSearch.Caption = "Refresh";
            this.btnSearch.Id = 14;
            this.btnSearch.ImageIndex = 4;
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnSearch_ItemClick);
            // 
            // frmDanhSachHocSinh
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(817, 657);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.FocustextBox1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "frmDanhSachHocSinh";
            this.Text = "Danh Sách Học Sinh";
            this.Load += new System.EventHandler(this.frmDanhSachHocSinh_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource_HocSinh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mainMenuBarManager)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraBars.BarManager mainMenuBarManager;
        private DevExpress.XtraBars.Bar mainMenuBar;
        private DevExpress.XtraBars.BarButtonItem btnExcel;
        private DevExpress.XtraBars.BarButtonItem btnThoat;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private System.Windows.Forms.TextBox FocustextBox1;
        private System.Windows.Forms.ImageList imageList1;
        private DevExpress.LookAndFeel.DefaultLookAndFeel defaultLookAndFeel1;
        private DevExpress.XtraGrid.Columns.GridColumn colCheck;
        private DevExpress.XtraGrid.Columns.GridColumn colMaDoiTac;
        private DevExpress.XtraGrid.Columns.GridColumn colMaQLDoiTac;
        private DevExpress.XtraGrid.Columns.GridColumn colCmnd;
        private DevExpress.XtraGrid.Columns.GridColumn colNgayLap;
        private DevExpress.XtraGrid.Columns.GridColumn colNgaySinh;
        private DevExpress.XtraGrid.Columns.GridColumn colGioiTinh;
        private DevExpress.XtraGrid.Columns.GridColumn colTenLop;
        private DevExpress.XtraGrid.Columns.GridColumn colTen;
        private DevExpress.XtraGrid.Columns.GridColumn colNamHoc;
        private DevExpress.XtraGrid.Columns.GridColumn colTenKhoi;
        private DevExpress.XtraGrid.Columns.GridColumn colTenTruong;
        private DevExpress.XtraGrid.Columns.GridColumn colNoiCap;
        private DevExpress.XtraGrid.Columns.GridColumn colTenDoiTac;
        private DevExpress.XtraGrid.Columns.GridColumn colTenVietTat;
        private DevExpress.XtraGrid.Columns.GridColumn colMaSoThue;
        private DevExpress.XtraGrid.Columns.GridColumn colTinhTrang;
        private DevExpress.XtraGrid.Columns.GridColumn colLoaiDoiTac;
        private DevExpress.XtraGrid.Columns.GridColumn colMaCongTy;
        private DevExpress.XtraGrid.Columns.GridColumn colDienGiai;
        private DevExpress.XtraGrid.Columns.GridColumn colTenDayDu;
        private DevExpress.XtraGrid.Columns.GridColumn colMaBoPhan;
        private DevExpress.XtraGrid.Columns.GridColumn colTenBoPhan;
        private DevExpress.XtraGrid.Columns.GridColumn colDiaChi;
        private DevExpress.XtraGrid.Columns.GridColumn colDienThoai;
        private DevExpress.XtraGrid.Columns.GridColumn colNhaCungCap;
        private DevExpress.XtraGrid.Columns.GridColumn colKhachHang;
        private System.Windows.Forms.BindingSource bindingSource_HocSinh;
        private DevExpress.XtraBars.BarButtonItem btnSearch;
    }
}