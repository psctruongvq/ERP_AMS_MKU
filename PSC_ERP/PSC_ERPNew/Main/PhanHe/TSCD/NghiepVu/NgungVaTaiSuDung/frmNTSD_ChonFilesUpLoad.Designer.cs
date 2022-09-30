namespace PSC_ERPNew.Main
{
    partial class frmNTSD_ChonFilesUpLoad
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmNTSD_ChonFilesUpLoad));
            DevExpress.Utils.SuperToolTip superToolTip8 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem8 = new DevExpress.Utils.ToolTipTitleItem();
            DevExpress.Utils.SuperToolTip superToolTip7 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem7 = new DevExpress.Utils.ToolTipTitleItem();
            this.btnDownFile = new DevExpress.XtraBars.BarButtonItem();
            this.col_TenTaiLieu = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridViewDanhSachFile = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridControlDanhSachFile = new DevExpress.XtraGrid.GridControl();
            this.ChungTu_HoSoFileLuuTruListSource = new System.Windows.Forms.BindingSource(this.components);
         
            this.txtBlackHole = new System.Windows.Forms.TextBox();
            this.btnRefresh = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar1 = new DevExpress.XtraBars.Bar();
            this.btnAddNew = new DevExpress.XtraBars.BarButtonItem();
            this.btnDelete = new DevExpress.XtraBars.BarButtonItem();
            this.btnClose = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.btnTim = new DevExpress.XtraBars.BarButtonItem();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewDanhSachFile)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlDanhSachFile)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ChungTu_HoSoFileLuuTruListSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnDownFile
            // 
            this.btnDownFile.Caption = "Download file";
            this.btnDownFile.Id = 17;
            this.btnDownFile.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnDownFile.ImageOptions.Image")));
            this.btnDownFile.Name = "btnDownFile";
            this.btnDownFile.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnDownFile_ItemClick);
            // 
            // col_TenTaiLieu
            // 
            this.col_TenTaiLieu.Caption = "Tên";
            this.col_TenTaiLieu.FieldName = "TenFile";
            this.col_TenTaiLieu.Name = "col_TenTaiLieu";
            this.col_TenTaiLieu.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.col_TenTaiLieu.Visible = true;
            this.col_TenTaiLieu.VisibleIndex = 0;
            this.col_TenTaiLieu.Width = 291;
            // 
            // gridViewDanhSachFile
            // 
            this.gridViewDanhSachFile.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.col_TenTaiLieu});
            this.gridViewDanhSachFile.GridControl = this.gridControlDanhSachFile;
            this.gridViewDanhSachFile.IndicatorWidth = 50;
            this.gridViewDanhSachFile.Name = "gridViewDanhSachFile";
            this.gridViewDanhSachFile.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridViewDanhSachFile.OptionsView.ShowAutoFilterRow = true;
            this.gridViewDanhSachFile.OptionsView.ShowGroupPanel = false;
            this.gridViewDanhSachFile.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.gridViewDanhSachFile_CustomDrawRowIndicator);
            this.gridViewDanhSachFile.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gridViewDanhSachFile_FocusedRowChanged);
            // 
            // gridControlDanhSachFile
            // 
            this.gridControlDanhSachFile.DataSource = this.ChungTu_HoSoFileLuuTruListSource;
            this.gridControlDanhSachFile.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControlDanhSachFile.Location = new System.Drawing.Point(0, 47);
            this.gridControlDanhSachFile.MainView = this.gridViewDanhSachFile;
            this.gridControlDanhSachFile.Name = "gridControlDanhSachFile";
            this.gridControlDanhSachFile.Size = new System.Drawing.Size(823, 457);
            this.gridControlDanhSachFile.TabIndex = 17;
            this.gridControlDanhSachFile.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewDanhSachFile});
            // 
            // ChungTu_HoSoFileLuuTruListSource
            // 
            this.ChungTu_HoSoFileLuuTruListSource.AllowNew = true;
            this.ChungTu_HoSoFileLuuTruListSource.DataSource = typeof(ERP_Library.ChungTu_HoSoFileLuuTruList);
           
            // txtBlackHole
            // 
            this.txtBlackHole.Location = new System.Drawing.Point(136, 199);
            this.txtBlackHole.Name = "txtBlackHole";
            this.txtBlackHole.Size = new System.Drawing.Size(100, 21);
            this.txtBlackHole.TabIndex = 18;
            this.txtBlackHole.TabStop = false;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Caption = "Refresh";
            this.btnRefresh.Id = 5;
            this.btnRefresh.ImageOptions.ImageIndex = 5;
            this.btnRefresh.Name = "btnRefresh";
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 47);
            this.barDockControlLeft.Manager = this.barManager1;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 457);
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
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.btnTim,
            this.btnClose,
            this.btnAddNew,
            this.btnRefresh,
            this.btnDelete,           
            this.btnDownFile});
            this.barManager1.MaxItemId = 18;
            // 
            // bar1
            // 
            this.bar1.BarName = "Tools";
            this.bar1.DockCol = 0;
            this.bar1.DockRow = 0;
            this.bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnAddNew, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnDownFile, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnDelete, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnClose, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)});
            this.bar1.Text = "Tools";
            // 
            // btnAddNew
            // 
            this.btnAddNew.Caption = "Upload file";
            this.btnAddNew.Id = 2;
            this.btnAddNew.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnAddNew.ImageOptions.Image")));
            this.btnAddNew.ItemShortcut = new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N));
            this.btnAddNew.Name = "btnAddNew";
            toolTipTitleItem8.Text = "Ctrl+N";
            superToolTip8.Items.Add(toolTipTitleItem8);
            this.btnAddNew.SuperTip = superToolTip8;
            this.btnAddNew.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnAddNew_ItemClick);
            // 
            // btnDelete
            // 
            this.btnDelete.Caption = "Xóa";
            this.btnDelete.Id = 6;
            this.btnDelete.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnDelete.ImageOptions.Image")));
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnDelete_ItemClick);
            // 
            // btnClose
            // 
            this.btnClose.Caption = "Thoát";
            this.btnClose.Id = 1;
            this.btnClose.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.ImageOptions.Image")));
            this.btnClose.ItemShortcut = new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.X));
            this.btnClose.Name = "btnClose";
            toolTipTitleItem7.Text = "Alt+X";
            superToolTip7.Items.Add(toolTipTitleItem7);
            this.btnClose.SuperTip = superToolTip7;
            this.btnClose.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnClose_ItemClick);
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.barManager1;
            this.barDockControlTop.Size = new System.Drawing.Size(823, 47);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 504);
            this.barDockControlBottom.Manager = this.barManager1;
            this.barDockControlBottom.Size = new System.Drawing.Size(823, 0);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(823, 47);
            this.barDockControlRight.Manager = this.barManager1;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 457);
            // 
            // btnTim
            // 
            this.btnTim.Caption = "Tìm";
            this.btnTim.Id = 0;
            this.btnTim.ImageOptions.ImageIndex = 6;
            this.btnTim.Name = "btnTim";
            // 
            // frmNTSD_ChonFilesUpLoad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(823, 504);
            this.Controls.Add(this.gridControlDanhSachFile);
            this.Controls.Add(this.txtBlackHole);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "frmNTSD_ChonFilesUpLoad";
            this.Text = "Chọn File Cần UpLoad";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmNTSD_ChonFilesUpLoad_FormClosing);
            this.Load += new System.EventHandler(this.frmNTSD_ChonFilesUpLoad_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridViewDanhSachFile)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlDanhSachFile)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ChungTu_HoSoFileLuuTruListSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.BarButtonItem btnDownFile;
        private DevExpress.XtraGrid.Columns.GridColumn col_TenTaiLieu;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewDanhSachFile;
        private DevExpress.XtraGrid.GridControl gridControlDanhSachFile;
        private System.Windows.Forms.BindingSource ChungTu_HoSoFileLuuTruListSource;
       
        private System.Windows.Forms.TextBox txtBlackHole;
        private DevExpress.XtraBars.BarButtonItem btnRefresh;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar1;
        private DevExpress.XtraBars.BarButtonItem btnAddNew;
        private DevExpress.XtraBars.BarButtonItem btnDelete;
        private DevExpress.XtraBars.BarButtonItem btnClose;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarButtonItem btnTim;
    }
}