namespace PSC_ERPNew.Main.PhanHe.DIGITIZING
{
    partial class frmDigitizing_ChonFilesUpLoad
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDigitizing_ChonFilesUpLoad));
            DevExpress.Utils.SuperToolTip superToolTip1 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem1 = new DevExpress.Utils.ToolTipTitleItem();
            DevExpress.Utils.SuperToolTip superToolTip2 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem2 = new DevExpress.Utils.ToolTipTitleItem();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.digitizingBagBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar1 = new DevExpress.XtraBars.Bar();
            this.btnAddNew = new DevExpress.XtraBars.BarButtonItem();
            this.btnDelete = new DevExpress.XtraBars.BarButtonItem();
            this.btnClose = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.btnTim = new DevExpress.XtraBars.BarButtonItem();
            this.btnRefresh = new DevExpress.XtraBars.BarButtonItem();
            this.btnBienBanGiaoNhanTongHop = new DevExpress.XtraBars.BarButtonItem();
            this.btnBienBanGiaoNhanTSCD4ChuKy = new DevExpress.XtraBars.BarButtonItem();
            this.btnBienBanGiaoNhanTSCD3ChuKy = new DevExpress.XtraBars.BarButtonItem();
            this.btnDungCuPhuTungKemTheo4ChuKy = new DevExpress.XtraBars.BarButtonItem();
            this.btnDungCuPhuTungKemTheo3ChuKy = new DevExpress.XtraBars.BarButtonItem();
            this.btnInPhieuKeToan = new DevExpress.XtraBars.BarButtonItem();
            this.gridControlDanhSachFile = new DevExpress.XtraGrid.GridControl();
            this.gridViewDanhSachFile = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.col_TenTaiLieu = new DevExpress.XtraGrid.Columns.GridColumn();
            this.txtBlackHole = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.digitizingBagBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlDanhSachFile)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewDanhSachFile)).BeginInit();
            this.SuspendLayout();
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "add64.png");
            this.imageList1.Images.SetKeyName(1, "undo64.png");
            this.imageList1.Images.SetKeyName(2, "1337595172_file_edit.png");
            this.imageList1.Images.SetKeyName(3, "1343360966_file_delete.png");
            this.imageList1.Images.SetKeyName(4, "save64.png");
            this.imageList1.Images.SetKeyName(5, "1337595258_Gnome-View-Refresh-64.png");
            this.imageList1.Images.SetKeyName(6, "find64.png");
            this.imageList1.Images.SetKeyName(7, "printer64.png");
            this.imageList1.Images.SetKeyName(8, "help64.png");
            this.imageList1.Images.SetKeyName(9, "exit64.png");
            // 
            // barManager1
            // 
            this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar1});
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Images = this.imageList1;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.btnTim,
            this.btnClose,
            this.btnAddNew,
            this.btnRefresh,
            this.btnDelete,
            this.btnBienBanGiaoNhanTongHop,
            this.btnBienBanGiaoNhanTSCD4ChuKy,
            this.btnBienBanGiaoNhanTSCD3ChuKy,
            this.btnDungCuPhuTungKemTheo4ChuKy,
            this.btnDungCuPhuTungKemTheo3ChuKy,
            this.btnInPhieuKeToan});
            this.barManager1.MaxItemId = 17;
            // 
            // bar1
            // 
            this.bar1.BarName = "Tools";
            this.bar1.DockCol = 0;
            this.bar1.DockRow = 0;
            this.bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnAddNew, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnDelete, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnClose, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)});
            this.bar1.Text = "Tools";
            // 
            // btnAddNew
            // 
            this.btnAddNew.Caption = "Thêm";
            this.btnAddNew.Id = 2;
            this.btnAddNew.ImageIndex = 0;
            this.btnAddNew.ItemShortcut = new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N));
            this.btnAddNew.Name = "btnAddNew";
            toolTipTitleItem1.Text = "Ctrl+N";
            superToolTip1.Items.Add(toolTipTitleItem1);
            this.btnAddNew.SuperTip = superToolTip1;
            this.btnAddNew.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnAddNew_ItemClick);
            // 
            // btnDelete
            // 
            this.btnDelete.Caption = "Xóa";
            this.btnDelete.Id = 6;
            this.btnDelete.ImageIndex = 3;
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnDelete_ItemClick);
            // 
            // btnClose
            // 
            this.btnClose.Caption = "Thoát";
            this.btnClose.Id = 1;
            this.btnClose.ImageIndex = 9;
            this.btnClose.ItemShortcut = new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.X));
            this.btnClose.Name = "btnClose";
            toolTipTitleItem2.Text = "Alt+X";
            superToolTip2.Items.Add(toolTipTitleItem2);
            this.btnClose.SuperTip = superToolTip2;
            this.btnClose.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnClose_ItemClick);
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(880, 39);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 349);
            this.barDockControlBottom.Size = new System.Drawing.Size(880, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 39);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 310);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(880, 39);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 310);
            // 
            // btnTim
            // 
            this.btnTim.Caption = "Tìm";
            this.btnTim.Id = 0;
            this.btnTim.ImageIndex = 6;
            this.btnTim.Name = "btnTim";
            // 
            // btnRefresh
            // 
            this.btnRefresh.Caption = "Refresh";
            this.btnRefresh.Id = 5;
            this.btnRefresh.ImageIndex = 5;
            this.btnRefresh.Name = "btnRefresh";
            // 
            // btnBienBanGiaoNhanTongHop
            // 
            this.btnBienBanGiaoNhanTongHop.Caption = "Biên bản giao nhận tổng hợp";
            this.btnBienBanGiaoNhanTongHop.Id = 9;
            this.btnBienBanGiaoNhanTongHop.Name = "btnBienBanGiaoNhanTongHop";
            // 
            // btnBienBanGiaoNhanTSCD4ChuKy
            // 
            this.btnBienBanGiaoNhanTSCD4ChuKy.Caption = "Biên bản giao nhận TSCĐ 4 chữ ký";
            this.btnBienBanGiaoNhanTSCD4ChuKy.Id = 10;
            this.btnBienBanGiaoNhanTSCD4ChuKy.Name = "btnBienBanGiaoNhanTSCD4ChuKy";
            // 
            // btnBienBanGiaoNhanTSCD3ChuKy
            // 
            this.btnBienBanGiaoNhanTSCD3ChuKy.Caption = "Biên bản giao nhận TSCĐ 3 chữ ký";
            this.btnBienBanGiaoNhanTSCD3ChuKy.Id = 11;
            this.btnBienBanGiaoNhanTSCD3ChuKy.Name = "btnBienBanGiaoNhanTSCD3ChuKy";
            // 
            // btnDungCuPhuTungKemTheo4ChuKy
            // 
            this.btnDungCuPhuTungKemTheo4ChuKy.Caption = "Dụng cụ phụ tùng 4 chữ ký";
            this.btnDungCuPhuTungKemTheo4ChuKy.Id = 12;
            this.btnDungCuPhuTungKemTheo4ChuKy.Name = "btnDungCuPhuTungKemTheo4ChuKy";
            // 
            // btnDungCuPhuTungKemTheo3ChuKy
            // 
            this.btnDungCuPhuTungKemTheo3ChuKy.Caption = "Dụng cụ phụ tùng 3 chữ ký";
            this.btnDungCuPhuTungKemTheo3ChuKy.Id = 13;
            this.btnDungCuPhuTungKemTheo3ChuKy.Name = "btnDungCuPhuTungKemTheo3ChuKy";
            // 
            // btnInPhieuKeToan
            // 
            this.btnInPhieuKeToan.Caption = "Phiếu kế toán";
            this.btnInPhieuKeToan.Id = 16;
            this.btnInPhieuKeToan.Name = "btnInPhieuKeToan";
            // 
            // gridControlDanhSachFile
            // 
            this.gridControlDanhSachFile.DataSource = this.digitizingBagBindingSource;
            this.gridControlDanhSachFile.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControlDanhSachFile.Location = new System.Drawing.Point(0, 39);
            this.gridControlDanhSachFile.MainView = this.gridViewDanhSachFile;
            this.gridControlDanhSachFile.Name = "gridControlDanhSachFile";
            this.gridControlDanhSachFile.Size = new System.Drawing.Size(880, 310);
            this.gridControlDanhSachFile.TabIndex = 11;
            this.gridControlDanhSachFile.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewDanhSachFile});
            // 
            // gridViewDanhSachFile
            // 
            this.gridViewDanhSachFile.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.col_TenTaiLieu});
            this.gridViewDanhSachFile.GridControl = this.gridControlDanhSachFile;
            this.gridViewDanhSachFile.IndicatorWidth = 50;
            this.gridViewDanhSachFile.Name = "gridViewDanhSachFile";
            this.gridViewDanhSachFile.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridViewDanhSachFile.OptionsSelection.MultiSelect = true;
            this.gridViewDanhSachFile.OptionsView.ShowAutoFilterRow = true;
            this.gridViewDanhSachFile.OptionsView.ShowGroupPanel = false;
            this.gridViewDanhSachFile.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.gridViewDanhSachFile_CustomDrawRowIndicator);
            // 
            // col_TenTaiLieu
            // 
            this.col_TenTaiLieu.Caption = "Tên";
            this.col_TenTaiLieu.FieldName = "Name";
            this.col_TenTaiLieu.Name = "col_TenTaiLieu";
            this.col_TenTaiLieu.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.col_TenTaiLieu.Visible = true;
            this.col_TenTaiLieu.VisibleIndex = 0;
            this.col_TenTaiLieu.Width = 291;
            // 
            // txtBlackHole
            // 
            this.txtBlackHole.Location = new System.Drawing.Point(23, -28);
            this.txtBlackHole.Name = "txtBlackHole";
            this.txtBlackHole.Size = new System.Drawing.Size(100, 21);
            this.txtBlackHole.TabIndex = 16;
            this.txtBlackHole.TabStop = false;
            // 
            // frmDigitizing_ChonFilesUpLoad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(880, 349);
            this.Controls.Add(this.txtBlackHole);
            this.Controls.Add(this.gridControlDanhSachFile);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "frmDigitizing_ChonFilesUpLoad";
            this.Text = "Chọn File Cần UpLoad";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmDigitizing_ChonFilesUpLoad_FormClosing);
            this.Load += new System.EventHandler(this.frmDigitizing_ChonFilesUpLoad_Load);
            ((System.ComponentModel.ISupportInitialize)(this.digitizingBagBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlDanhSachFile)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewDanhSachFile)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.BindingSource digitizingBagBindingSource;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar1;
        private DevExpress.XtraBars.BarButtonItem btnAddNew;
        private DevExpress.XtraBars.BarButtonItem btnDelete;
        private DevExpress.XtraBars.BarButtonItem btnBienBanGiaoNhanTongHop;
        private DevExpress.XtraBars.BarButtonItem btnBienBanGiaoNhanTSCD4ChuKy;
        private DevExpress.XtraBars.BarButtonItem btnBienBanGiaoNhanTSCD3ChuKy;
        private DevExpress.XtraBars.BarButtonItem btnDungCuPhuTungKemTheo4ChuKy;
        private DevExpress.XtraBars.BarButtonItem btnDungCuPhuTungKemTheo3ChuKy;
        private DevExpress.XtraBars.BarButtonItem btnInPhieuKeToan;
        private DevExpress.XtraBars.BarButtonItem btnClose;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraGrid.GridControl gridControlDanhSachFile;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewDanhSachFile;
        private DevExpress.XtraGrid.Columns.GridColumn col_TenTaiLieu;
        private DevExpress.XtraBars.BarButtonItem btnTim;
        private DevExpress.XtraBars.BarButtonItem btnRefresh;
        private System.Windows.Forms.TextBox txtBlackHole;
    }
}