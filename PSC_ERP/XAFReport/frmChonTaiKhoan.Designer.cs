namespace PSC_ERP
{
    partial class frmChonTaiKhoan
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmChonTaiKhoan));
            DevExpress.Utils.SuperToolTip superToolTip5 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem5 = new DevExpress.Utils.ToolTipTitleItem();
            this.defaultLookAndFeel1 = new DevExpress.LookAndFeel.DefaultLookAndFeel(this.components);
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.mainMenuBarManager = new DevExpress.XtraBars.BarManager(this.components);
            this.mainMenuBar = new DevExpress.XtraBars.Bar();
            this.btnChon = new DevExpress.XtraBars.BarButtonItem();
            this.btnExportDataExcell = new DevExpress.XtraBars.BarButtonItem();
            this.btnThoat = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.treeTaiKhoan = new DevExpress.XtraTreeList.TreeList();
            this.colChon = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colSoHieuTK = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colTenTaiKhoan = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.bdTaiKhoan = new System.Windows.Forms.BindingSource(this.components);
            this.bdChuongTrinh = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.mainMenuBarManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.treeTaiKhoan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdTaiKhoan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdChuongTrinh)).BeginInit();
            this.SuspendLayout();
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
            this.imageList1.Images.SetKeyName(12, "export.png");
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
            this.btnThoat,
            this.btnExportDataExcell});
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
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnChon, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnExportDataExcell, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnThoat, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)});
            this.mainMenuBar.OptionsBar.MultiLine = true;
            this.mainMenuBar.OptionsBar.UseWholeRow = true;
            this.mainMenuBar.Text = "Main menu";
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
            // btnExportDataExcell
            // 
            this.btnExportDataExcell.Caption = "Export dữ liệu ra excel";
            this.btnExportDataExcell.Id = 14;
            this.btnExportDataExcell.ImageIndex = 12;
            this.btnExportDataExcell.Name = "btnExportDataExcell";
            this.btnExportDataExcell.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.btnExportDataExcell.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnExportDataExcell_ItemClick);
            // 
            // btnThoat
            // 
            this.btnThoat.Caption = "Thoát";
            this.btnThoat.Id = 6;
            this.btnThoat.ImageIndex = 8;
            this.btnThoat.ItemShortcut = new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Q));
            this.btnThoat.Name = "btnThoat";
            toolTipTitleItem5.Text = "Ctrl+Q";
            superToolTip5.Items.Add(toolTipTitleItem5);
            this.btnThoat.SuperTip = superToolTip5;
            this.btnThoat.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnThoat_ItemClick);
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(704, 34);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 564);
            this.barDockControlBottom.Size = new System.Drawing.Size(704, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 34);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 530);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(704, 34);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 530);
            // 
            // treeTaiKhoan
            // 
            this.treeTaiKhoan.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.colChon,
            this.colSoHieuTK,
            this.colTenTaiKhoan});
            this.treeTaiKhoan.DataSource = this.bdTaiKhoan;
            this.treeTaiKhoan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeTaiKhoan.KeyFieldName = "MaTaiKhoan";
            this.treeTaiKhoan.Location = new System.Drawing.Point(0, 34);
            this.treeTaiKhoan.Name = "treeTaiKhoan";
            this.treeTaiKhoan.OptionsBehavior.EnableFiltering = true;
            this.treeTaiKhoan.OptionsBehavior.PopulateServiceColumns = true;
            this.treeTaiKhoan.OptionsView.AutoWidth = false;
            this.treeTaiKhoan.OptionsView.ShowAutoFilterRow = true;
            this.treeTaiKhoan.ParentFieldName = "MaTaiKhoanCha";
            this.treeTaiKhoan.Size = new System.Drawing.Size(704, 530);
            this.treeTaiKhoan.TabIndex = 4;
            this.treeTaiKhoan.NodeCellStyle += new DevExpress.XtraTreeList.GetCustomNodeCellStyleEventHandler(this.treeTaiKhoan_NodeCellStyle);
            this.treeTaiKhoan.CellValueChanging += new DevExpress.XtraTreeList.CellValueChangedEventHandler(this.treeTaiKhoan_CellValueChanging);
            // 
            // colChon
            // 
            this.colChon.Caption = "Chọn";
            this.colChon.FieldName = "Chon";
            this.colChon.Name = "colChon";
            this.colChon.Visible = true;
            this.colChon.VisibleIndex = 0;
            // 
            // colSoHieuTK
            // 
            this.colSoHieuTK.Caption = "Số hiệu TK";
            this.colSoHieuTK.FieldName = "SoHieuTK";
            this.colSoHieuTK.Name = "colSoHieuTK";
            this.colSoHieuTK.Visible = true;
            this.colSoHieuTK.VisibleIndex = 1;
            this.colSoHieuTK.Width = 110;
            // 
            // colTenTaiKhoan
            // 
            this.colTenTaiKhoan.Caption = "Tên tài khoản";
            this.colTenTaiKhoan.FieldName = "TenTaiKhoan";
            this.colTenTaiKhoan.Name = "colTenTaiKhoan";
            this.colTenTaiKhoan.Visible = true;
            this.colTenTaiKhoan.VisibleIndex = 2;
            this.colTenTaiKhoan.Width = 400;
            // 
            // bdTaiKhoan
            // 
            this.bdTaiKhoan.DataSource = typeof(ERP_Library.HeThongTaiKhoan1List);
            // 
            // bdChuongTrinh
            // 
            this.bdChuongTrinh.DataSource = typeof(ERP_Library.ChuongTrinhList);
            // 
            // frmChonTaiKhoan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(704, 564);
            this.Controls.Add(this.treeTaiKhoan);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "frmChonTaiKhoan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chọn tài khoản";
            this.Load += new System.EventHandler(this.frmShowReportForGrid_Load);
            ((System.ComponentModel.ISupportInitialize)(this.mainMenuBarManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.treeTaiKhoan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdTaiKhoan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdChuongTrinh)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.LookAndFeel.DefaultLookAndFeel defaultLookAndFeel1;
        private System.Windows.Forms.ImageList imageList1;
        private DevExpress.XtraBars.BarManager mainMenuBarManager;
        private DevExpress.XtraBars.Bar mainMenuBar;
        private DevExpress.XtraBars.BarButtonItem btnChon;
        private DevExpress.XtraBars.BarButtonItem btnThoat;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarButtonItem btnExportDataExcell;
        private DevExpress.XtraTreeList.TreeList treeTaiKhoan;
        private System.Windows.Forms.BindingSource bdChuongTrinh;
        private System.Windows.Forms.BindingSource bdTaiKhoan;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colChon;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colSoHieuTK;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colTenTaiKhoan;
    }
}