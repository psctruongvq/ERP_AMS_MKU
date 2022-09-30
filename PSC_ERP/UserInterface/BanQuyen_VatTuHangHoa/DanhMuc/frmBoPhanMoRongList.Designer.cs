namespace PSC_ERP
{
    partial class frmBoPhanMoRongList
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
            DevExpress.Utils.SuperToolTip superToolTip2 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem2 = new DevExpress.Utils.ToolTipTitleItem();
            DevExpress.Utils.SuperToolTip superToolTip3 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem3 = new DevExpress.Utils.ToolTipTitleItem();
            DevExpress.Utils.SuperToolTip superToolTip4 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem4 = new DevExpress.Utils.ToolTipTitleItem();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBoPhanMoRongList));
            DevExpress.Utils.SuperToolTip superToolTip5 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem5 = new DevExpress.Utils.ToolTipTitleItem();
            this.defaultLookAndFeel1 = new DevExpress.LookAndFeel.DefaultLookAndFeel(this.components);
            this.mainMenuBarManager = new DevExpress.XtraBars.BarManager(this.components);
            this.mainMenuBar = new DevExpress.XtraBars.Bar();
            this.btnXoa = new DevExpress.XtraBars.BarButtonItem();
            this.btnLuu = new DevExpress.XtraBars.BarButtonItem();
            this.btnHelp = new DevExpress.XtraBars.BarButtonItem();
            this.btnThoat = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.btnThemMoi = new DevExpress.XtraBars.BarButtonItem();
            this.boPhanMoRongListBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridControl_BoPhanMoList = new DevExpress.XtraGrid.GridControl();
            this.gridView_BoPhanMoRongList = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colMaBoPhanMoRong = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMaQuanLy = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTenBoPhanMoRong = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNgayLap = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGhiChu = new DevExpress.XtraGrid.Columns.GridColumn();
            this.txtBlackHole = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.mainMenuBarManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.boPhanMoRongListBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_BoPhanMoList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_BoPhanMoRongList)).BeginInit();
            this.SuspendLayout();
            // 
            // defaultLookAndFeel1
            // 
            this.defaultLookAndFeel1.LookAndFeel.SkinName = "Office 2010 Blue";
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
            this.btnThoat,
            this.btnHelp});
            this.mainMenuBarManager.LargeImages = this.imageList1;
            this.mainMenuBarManager.MainMenu = this.mainMenuBar;
            this.mainMenuBarManager.MaxItemId = 10;
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
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnXoa, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnLuu, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnHelp, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnThoat, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)});
            this.mainMenuBar.OptionsBar.MultiLine = true;
            this.mainMenuBar.OptionsBar.UseWholeRow = true;
            this.mainMenuBar.Text = "Main menu";
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
            // btnLuu
            // 
            this.btnLuu.Caption = "Lưu";
            this.btnLuu.Id = 3;
            this.btnLuu.ImageIndex = 5;
            this.btnLuu.ItemShortcut = new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S));
            this.btnLuu.Name = "btnLuu";
            toolTipTitleItem2.Text = "Ctrl+S";
            superToolTip2.Items.Add(toolTipTitleItem2);
            this.btnLuu.SuperTip = superToolTip2;
            this.btnLuu.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnLuu_ItemClick);
            // 
            // btnHelp
            // 
            this.btnHelp.Caption = "Trợ giúp";
            this.btnHelp.Id = 7;
            this.btnHelp.ImageIndex = 6;
            this.btnHelp.ItemShortcut = new DevExpress.XtraBars.BarShortcut(System.Windows.Forms.Keys.F1);
            this.btnHelp.Name = "btnHelp";
            toolTipTitleItem3.Text = "F1";
            superToolTip3.Items.Add(toolTipTitleItem3);
            this.btnHelp.SuperTip = superToolTip3;
            // 
            // btnThoat
            // 
            this.btnThoat.Caption = "Thoát";
            this.btnThoat.Id = 6;
            this.btnThoat.ImageIndex = 8;
            this.btnThoat.ItemShortcut = new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Q));
            this.btnThoat.Name = "btnThoat";
            toolTipTitleItem4.Text = "Ctrl+Q";
            superToolTip4.Items.Add(toolTipTitleItem4);
            this.btnThoat.SuperTip = superToolTip4;
            this.btnThoat.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnThoat_ItemClick);
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(798, 32);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 458);
            this.barDockControlBottom.Size = new System.Drawing.Size(798, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 32);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 426);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(798, 32);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 426);
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
            // btnThemMoi
            // 
            this.btnThemMoi.Caption = "Thêm mới";
            this.btnThemMoi.Id = 0;
            this.btnThemMoi.ImageIndex = 0;
            this.btnThemMoi.ItemShortcut = new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N));
            this.btnThemMoi.Name = "btnThemMoi";
            toolTipTitleItem5.Text = "Ctrl+N";
            superToolTip5.Items.Add(toolTipTitleItem5);
            this.btnThemMoi.SuperTip = superToolTip5;
            // 
            // boPhanMoRongListBindingSource
            // 
            this.boPhanMoRongListBindingSource.AllowNew = true;
            this.boPhanMoRongListBindingSource.DataSource = typeof(ERP_Library.BoPhanMoRongList);
            // 
            // gridControl_BoPhanMoList
            // 
            this.gridControl_BoPhanMoList.DataSource = this.boPhanMoRongListBindingSource;
            this.gridControl_BoPhanMoList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl_BoPhanMoList.Location = new System.Drawing.Point(0, 32);
            this.gridControl_BoPhanMoList.MainView = this.gridView_BoPhanMoRongList;
            this.gridControl_BoPhanMoList.MenuManager = this.mainMenuBarManager;
            this.gridControl_BoPhanMoList.Name = "gridControl_BoPhanMoList";
            this.gridControl_BoPhanMoList.Size = new System.Drawing.Size(798, 426);
            this.gridControl_BoPhanMoList.TabIndex = 5;
            this.gridControl_BoPhanMoList.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView_BoPhanMoRongList});
            // 
            // gridView_BoPhanMoRongList
            // 
            this.gridView_BoPhanMoRongList.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.gridView_BoPhanMoRongList.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridView_BoPhanMoRongList.Appearance.TopNewRow.Options.UseTextOptions = true;
            this.gridView_BoPhanMoRongList.Appearance.TopNewRow.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.gridView_BoPhanMoRongList.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colMaBoPhanMoRong,
            this.colMaQuanLy,
            this.colTenBoPhanMoRong,
            this.colNgayLap,
            this.colGhiChu});
            this.gridView_BoPhanMoRongList.GridControl = this.gridControl_BoPhanMoList;
            this.gridView_BoPhanMoRongList.Name = "gridView_BoPhanMoRongList";
            this.gridView_BoPhanMoRongList.NewItemRowText = "Click để thêm bộ phận mới";
            this.gridView_BoPhanMoRongList.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;
            this.gridView_BoPhanMoRongList.OptionsView.ShowAutoFilterRow = true;
            this.gridView_BoPhanMoRongList.OptionsView.ShowGroupPanel = false;
            this.gridView_BoPhanMoRongList.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colMaBoPhanMoRong, DevExpress.Data.ColumnSortOrder.Descending)});
            this.gridView_BoPhanMoRongList.DoubleClick += new System.EventHandler(this.grid_BoPhanList_DoubleClick);
            // 
            // colMaBoPhanMoRong
            // 
            this.colMaBoPhanMoRong.FieldName = "MaBoPhanMoRong";
            this.colMaBoPhanMoRong.Name = "colMaBoPhanMoRong";
            this.colMaBoPhanMoRong.OptionsColumn.ReadOnly = true;
            // 
            // colMaQuanLy
            // 
            this.colMaQuanLy.Caption = "Mã quản lý";
            this.colMaQuanLy.FieldName = "MaQuanLy";
            this.colMaQuanLy.Name = "colMaQuanLy";
            this.colMaQuanLy.Visible = true;
            this.colMaQuanLy.VisibleIndex = 0;
            this.colMaQuanLy.Width = 247;
            // 
            // colTenBoPhanMoRong
            // 
            this.colTenBoPhanMoRong.Caption = "Tên bộ phận mở rộng";
            this.colTenBoPhanMoRong.FieldName = "TenBoPhanMoRong";
            this.colTenBoPhanMoRong.Name = "colTenBoPhanMoRong";
            this.colTenBoPhanMoRong.Visible = true;
            this.colTenBoPhanMoRong.VisibleIndex = 1;
            this.colTenBoPhanMoRong.Width = 297;
            // 
            // colNgayLap
            // 
            this.colNgayLap.AppearanceCell.Options.UseTextOptions = true;
            this.colNgayLap.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colNgayLap.Caption = "Ngày lập";
            this.colNgayLap.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.colNgayLap.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colNgayLap.FieldName = "NgayLap";
            this.colNgayLap.Name = "colNgayLap";
            this.colNgayLap.Visible = true;
            this.colNgayLap.VisibleIndex = 2;
            this.colNgayLap.Width = 220;
            // 
            // colGhiChu
            // 
            this.colGhiChu.Caption = "Ghi chú";
            this.colGhiChu.FieldName = "GhiChu";
            this.colGhiChu.Name = "colGhiChu";
            this.colGhiChu.Visible = true;
            this.colGhiChu.VisibleIndex = 3;
            this.colGhiChu.Width = 330;
            // 
            // txtBlackHole
            // 
            this.txtBlackHole.Location = new System.Drawing.Point(353, 195);
            this.txtBlackHole.Name = "txtBlackHole";
            this.txtBlackHole.Size = new System.Drawing.Size(100, 21);
            this.txtBlackHole.TabIndex = 10;
            this.txtBlackHole.TabStop = false;
            this.txtBlackHole.Text = "BlackHole";
            // 
            // frmBoPhanMoRongList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(798, 458);
            this.Controls.Add(this.gridControl_BoPhanMoList);
            this.Controls.Add(this.txtBlackHole);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.MaximizeBox = false;
            this.Name = "frmBoPhanMoRongList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Danh sách bộ phận mở rộng";
            this.Load += new System.EventHandler(this.frmBoPhanMoRongList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.mainMenuBarManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.boPhanMoRongListBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_BoPhanMoList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_BoPhanMoRongList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.LookAndFeel.DefaultLookAndFeel defaultLookAndFeel1;
        private DevExpress.XtraBars.BarManager mainMenuBarManager;
        private DevExpress.XtraBars.Bar mainMenuBar;
        private DevExpress.XtraBars.BarButtonItem btnThemMoi;
        private DevExpress.XtraBars.BarButtonItem btnXoa;
        private DevExpress.XtraBars.BarButtonItem btnLuu;
        private DevExpress.XtraBars.BarButtonItem btnHelp;
        private DevExpress.XtraBars.BarButtonItem btnThoat;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private System.Windows.Forms.ImageList imageList1;
        private DevExpress.XtraGrid.GridControl gridControl_BoPhanMoList;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView_BoPhanMoRongList;
        private DevExpress.XtraGrid.Columns.GridColumn colMaBoPhanMoRong;
        private DevExpress.XtraGrid.Columns.GridColumn colMaQuanLy;
        private DevExpress.XtraGrid.Columns.GridColumn colTenBoPhanMoRong;
        private DevExpress.XtraGrid.Columns.GridColumn colNgayLap;
        private DevExpress.XtraGrid.Columns.GridColumn colGhiChu;
        private System.Windows.Forms.BindingSource boPhanMoRongListBindingSource;
        private System.Windows.Forms.TextBox txtBlackHole;
    }
}