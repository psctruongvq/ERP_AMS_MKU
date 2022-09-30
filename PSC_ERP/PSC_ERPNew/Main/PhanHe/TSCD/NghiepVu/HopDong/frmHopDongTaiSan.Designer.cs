namespace PSC_ERPNew.Main
{
    partial class frmHopDongTaiSan
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmHopDongTaiSan));
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar1 = new DevExpress.XtraBars.Bar();
            this.btnThemMoi = new DevExpress.XtraBars.BarButtonItem();
            this.btnRefresh = new DevExpress.XtraBars.BarButtonItem();
            this.btnThoat = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.btnTim = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.tblHopDongMuaBanBindingSource_Single = new System.Windows.Forms.BindingSource(this.components);
            this.tblHopDongBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tblDoiTacBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.grdHopDong = new DevExpress.XtraGrid.GridControl();
            this.grdViewHopDong = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colSoHopDong = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTenHopDong = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDoiTac = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cbDoiTac_ForGrid = new DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit();
            this.repositoryItemGridLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colMaQLDoiTac1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTenDoiTac1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTenVietTat1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMaSoThue1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDienGiai1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNgayKy = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGhiChu = new DevExpress.XtraGrid.Columns.GridColumn();
            this.txtBlackHole = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblHopDongMuaBanBindingSource_Single)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblHopDongBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblDoiTacBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdHopDong)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdViewHopDong)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbDoiTac_ForGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemGridLookUpEdit1View)).BeginInit();
            this.SuspendLayout();
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
            this.btnThoat,
            this.btnThemMoi,
            this.btnRefresh,
            this.barButtonItem1});
            this.barManager1.MaxItemId = 8;
            // 
            // bar1
            // 
            this.bar1.BarName = "Tools";
            this.bar1.DockCol = 0;
            this.bar1.DockRow = 0;
            this.bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnThemMoi, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnRefresh, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnThoat, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)});
            this.bar1.Text = "Tools";
            // 
            // btnThemMoi
            // 
            this.btnThemMoi.Caption = "Thêm";
            this.btnThemMoi.Id = 2;
            this.btnThemMoi.ImageOptions.ImageIndex = 0;
            this.btnThemMoi.ItemShortcut = new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N));
            this.btnThemMoi.Name = "btnThemMoi";
            toolTipTitleItem1.Text = "Ctrl+N";
            superToolTip1.Items.Add(toolTipTitleItem1);
            this.btnThemMoi.SuperTip = superToolTip1;
            this.btnThemMoi.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnThemMoi_ItemClick);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Caption = "Refresh";
            this.btnRefresh.Id = 5;
            this.btnRefresh.ImageOptions.ImageIndex = 5;
            this.btnRefresh.ItemShortcut = new DevExpress.XtraBars.BarShortcut(System.Windows.Forms.Keys.F5);
            this.btnRefresh.Name = "btnRefresh";
            toolTipTitleItem2.Text = "F5";
            superToolTip2.Items.Add(toolTipTitleItem2);
            this.btnRefresh.SuperTip = superToolTip2;
            this.btnRefresh.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnRefresh_ItemClick);
            // 
            // btnThoat
            // 
            this.btnThoat.Caption = "Thoát";
            this.btnThoat.Id = 1;
            this.btnThoat.ImageOptions.ImageIndex = 9;
            this.btnThoat.ItemShortcut = new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.X));
            this.btnThoat.Name = "btnThoat";
            toolTipTitleItem3.Text = "Alt+X";
            superToolTip3.Items.Add(toolTipTitleItem3);
            this.btnThoat.SuperTip = superToolTip3;
            this.btnThoat.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnThoat_ItemClick);
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.barManager1;
            this.barDockControlTop.Size = new System.Drawing.Size(984, 39);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 661);
            this.barDockControlBottom.Manager = this.barManager1;
            this.barDockControlBottom.Size = new System.Drawing.Size(984, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 39);
            this.barDockControlLeft.Manager = this.barManager1;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 622);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(984, 39);
            this.barDockControlRight.Manager = this.barManager1;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 622);
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
            // btnTim
            // 
            this.btnTim.Caption = "Tìm";
            this.btnTim.Id = 0;
            this.btnTim.ImageOptions.ImageIndex = 6;
            this.btnTim.Name = "btnTim";
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.Caption = "Thêm mới";
            this.barButtonItem1.Id = 7;
            this.barButtonItem1.Name = "barButtonItem1";
            // 
            // tblHopDongMuaBanBindingSource_Single
            // 
            this.tblHopDongMuaBanBindingSource_Single.DataSource = typeof(PSC_ERP_Business.Main.Model.tblHopDongMuaBan);
            // 
            // tblHopDongBindingSource
            // 
            this.tblHopDongBindingSource.DataSource = typeof(PSC_ERP_Business.Main.Model.tblHopDong);
            this.tblHopDongBindingSource.CurrentChanged += new System.EventHandler(this.tblHopDongBindingSource_CurrentChanged);
            // 
            // tblDoiTacBindingSource
            // 
            this.tblDoiTacBindingSource.DataSource = typeof(PSC_ERP_Business.Main.Model.tblDoiTac);
            // 
            // grdHopDong
            // 
            this.grdHopDong.DataSource = this.tblHopDongBindingSource;
            this.grdHopDong.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdHopDong.Location = new System.Drawing.Point(0, 39);
            this.grdHopDong.MainView = this.grdViewHopDong;
            this.grdHopDong.MenuManager = this.barManager1;
            this.grdHopDong.Name = "grdHopDong";
            this.grdHopDong.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.cbDoiTac_ForGrid});
            this.grdHopDong.Size = new System.Drawing.Size(984, 622);
            this.grdHopDong.TabIndex = 0;
            this.grdHopDong.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grdViewHopDong});
            // 
            // grdViewHopDong
            // 
            this.grdViewHopDong.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colSoHopDong,
            this.colTenHopDong,
            this.colDoiTac,
            this.colNgayKy,
            this.colGhiChu});
            this.grdViewHopDong.GridControl = this.grdHopDong;
            this.grdViewHopDong.Name = "grdViewHopDong";
            this.grdViewHopDong.OptionsView.ShowAutoFilterRow = true;
            // 
            // colSoHopDong
            // 
            this.colSoHopDong.Caption = "Số hợp đồng";
            this.colSoHopDong.FieldName = "tblHopDongMuaBan.SoHopDong";
            this.colSoHopDong.Name = "colSoHopDong";
            this.colSoHopDong.OptionsColumn.ReadOnly = true;
            this.colSoHopDong.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colSoHopDong.Visible = true;
            this.colSoHopDong.VisibleIndex = 0;
            // 
            // colTenHopDong
            // 
            this.colTenHopDong.Caption = "Tên hợp đồng";
            this.colTenHopDong.FieldName = "TenHopDong";
            this.colTenHopDong.Name = "colTenHopDong";
            this.colTenHopDong.OptionsColumn.ReadOnly = true;
            this.colTenHopDong.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colTenHopDong.Visible = true;
            this.colTenHopDong.VisibleIndex = 1;
            // 
            // colDoiTac
            // 
            this.colDoiTac.Caption = "Nhà Cung Cấp";
            this.colDoiTac.ColumnEdit = this.cbDoiTac_ForGrid;
            this.colDoiTac.FieldName = "MaDoiTac";
            this.colDoiTac.Name = "colDoiTac";
            this.colDoiTac.OptionsColumn.ReadOnly = true;
            this.colDoiTac.Visible = true;
            this.colDoiTac.VisibleIndex = 2;
            // 
            // cbDoiTac_ForGrid
            // 
            this.cbDoiTac_ForGrid.AutoHeight = false;
            this.cbDoiTac_ForGrid.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbDoiTac_ForGrid.DataSource = this.tblDoiTacBindingSource;
            this.cbDoiTac_ForGrid.DisplayMember = "TenDoiTac";
            this.cbDoiTac_ForGrid.Name = "cbDoiTac_ForGrid";
            this.cbDoiTac_ForGrid.NullText = "<<Không chọn>>";
            this.cbDoiTac_ForGrid.ValueMember = "MaDoiTac";
            this.cbDoiTac_ForGrid.View = this.repositoryItemGridLookUpEdit1View;
            // 
            // repositoryItemGridLookUpEdit1View
            // 
            this.repositoryItemGridLookUpEdit1View.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colMaQLDoiTac1,
            this.colTenDoiTac1,
            this.colTenVietTat1,
            this.colMaSoThue1,
            this.colDienGiai1});
            this.repositoryItemGridLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.repositoryItemGridLookUpEdit1View.Name = "repositoryItemGridLookUpEdit1View";
            this.repositoryItemGridLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.repositoryItemGridLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // colMaQLDoiTac1
            // 
            this.colMaQLDoiTac1.FieldName = "MaQLDoiTac";
            this.colMaQLDoiTac1.Name = "colMaQLDoiTac1";
            this.colMaQLDoiTac1.Visible = true;
            this.colMaQLDoiTac1.VisibleIndex = 0;
            // 
            // colTenDoiTac1
            // 
            this.colTenDoiTac1.FieldName = "TenDoiTac";
            this.colTenDoiTac1.Name = "colTenDoiTac1";
            this.colTenDoiTac1.Visible = true;
            this.colTenDoiTac1.VisibleIndex = 1;
            // 
            // colTenVietTat1
            // 
            this.colTenVietTat1.FieldName = "TenVietTat";
            this.colTenVietTat1.Name = "colTenVietTat1";
            this.colTenVietTat1.Visible = true;
            this.colTenVietTat1.VisibleIndex = 2;
            // 
            // colMaSoThue1
            // 
            this.colMaSoThue1.FieldName = "MaSoThue";
            this.colMaSoThue1.Name = "colMaSoThue1";
            this.colMaSoThue1.Visible = true;
            this.colMaSoThue1.VisibleIndex = 3;
            // 
            // colDienGiai1
            // 
            this.colDienGiai1.FieldName = "DienGiai";
            this.colDienGiai1.Name = "colDienGiai1";
            this.colDienGiai1.Visible = true;
            this.colDienGiai1.VisibleIndex = 4;
            // 
            // colNgayKy
            // 
            this.colNgayKy.Caption = "Ngày ký";
            this.colNgayKy.FieldName = "NgayKy";
            this.colNgayKy.Name = "colNgayKy";
            this.colNgayKy.OptionsColumn.ReadOnly = true;
            this.colNgayKy.Visible = true;
            this.colNgayKy.VisibleIndex = 3;
            // 
            // colGhiChu
            // 
            this.colGhiChu.Caption = "Diễn giải";
            this.colGhiChu.FieldName = "GhiChu";
            this.colGhiChu.Name = "colGhiChu";
            this.colGhiChu.OptionsColumn.ReadOnly = true;
            this.colGhiChu.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colGhiChu.Visible = true;
            this.colGhiChu.VisibleIndex = 4;
            // 
            // txtBlackHole
            // 
            this.txtBlackHole.Location = new System.Drawing.Point(0, 53);
            this.txtBlackHole.Name = "txtBlackHole";
            this.txtBlackHole.Size = new System.Drawing.Size(100, 21);
            this.txtBlackHole.TabIndex = 6;
            this.txtBlackHole.TabStop = false;
            // 
            // frmHopDongTaiSan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 661);
            this.Controls.Add(this.grdHopDong);
            this.Controls.Add(this.txtBlackHole);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "frmHopDongTaiSan";
            this.Text = "Hợp đồng tài sản";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmHopDongTaiSan_FormClosing);
            this.Load += new System.EventHandler(this.frmHopDongTaiSan_Load);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblHopDongMuaBanBindingSource_Single)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblHopDongBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblDoiTacBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdHopDong)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdViewHopDong)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbDoiTac_ForGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemGridLookUpEdit1View)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar1;
        private DevExpress.XtraBars.BarButtonItem btnThemMoi;
        private DevExpress.XtraBars.BarButtonItem btnTim;
        private DevExpress.XtraBars.BarButtonItem btnThoat;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private System.Windows.Forms.ImageList imageList1;
        private DevExpress.XtraBars.BarButtonItem btnRefresh;
        private DevExpress.XtraGrid.GridControl grdHopDong;
        private DevExpress.XtraGrid.Views.Grid.GridView grdViewHopDong;
        private System.Windows.Forms.BindingSource tblHopDongBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colTenHopDong;
        private DevExpress.XtraGrid.Columns.GridColumn colDoiTac;
        private DevExpress.XtraGrid.Columns.GridColumn colNgayKy;
        private DevExpress.XtraGrid.Columns.GridColumn colGhiChu;
        private System.Windows.Forms.TextBox txtBlackHole;
        private System.Windows.Forms.BindingSource tblHopDongMuaBanBindingSource_Single;
        private System.Windows.Forms.BindingSource tblDoiTacBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colSoHopDong;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit cbDoiTac_ForGrid;
        private DevExpress.XtraGrid.Views.Grid.GridView repositoryItemGridLookUpEdit1View;
        private DevExpress.XtraGrid.Columns.GridColumn colMaQLDoiTac1;
        private DevExpress.XtraGrid.Columns.GridColumn colTenDoiTac1;
        private DevExpress.XtraGrid.Columns.GridColumn colTenVietTat1;
        private DevExpress.XtraGrid.Columns.GridColumn colMaSoThue1;
        private DevExpress.XtraGrid.Columns.GridColumn colDienGiai1;
    }
}