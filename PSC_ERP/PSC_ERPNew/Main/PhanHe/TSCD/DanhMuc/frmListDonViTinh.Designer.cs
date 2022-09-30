namespace PSC_ERPNew.Main
{
    partial class frmListDonViTinh
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
            DevExpress.Utils.SuperToolTip superToolTip5 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem5 = new DevExpress.Utils.ToolTipTitleItem();
            DevExpress.Utils.SuperToolTip superToolTip6 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem6 = new DevExpress.Utils.ToolTipTitleItem();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmListDonViTinh));
            DevExpress.Utils.SuperToolTip superToolTip4 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem4 = new DevExpress.Utils.ToolTipTitleItem();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar1 = new DevExpress.XtraBars.Bar();
            this.btnThemMoi = new DevExpress.XtraBars.BarButtonItem();
            this.btSua = new DevExpress.XtraBars.BarButtonItem();
            this.btTroVe = new DevExpress.XtraBars.BarButtonItem();
            this.btnLuu = new DevExpress.XtraBars.BarButtonItem();
            this.btnXoa = new DevExpress.XtraBars.BarButtonItem();
            this.btRefresh = new DevExpress.XtraBars.BarButtonItem();
            this.btnThoat = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.txt_DienGiai = new DevExpress.XtraEditors.TextEdit();
            this.tblDonViTinhBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.txtTenDVT = new DevExpress.XtraEditors.TextEdit();
            this.txtMaQL = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.grdDonViTinh = new DevExpress.XtraGrid.GridControl();
            this.grdViewDonViTinh = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colMaQuanLy = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTenDonViTinh = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDienGiai = new DevExpress.XtraGrid.Columns.GridColumn();
            this.txtBlackHole = new System.Windows.Forms.TextBox();
            this.GrDSDVT = new DevExpress.XtraEditors.GroupControl();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txt_DienGiai.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblDonViTinhBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTenDVT.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaQL.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdDonViTinh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdViewDonViTinh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrDSDVT)).BeginInit();
            this.GrDSDVT.SuspendLayout();
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
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.btnThoat,
            this.btnThemMoi,
            this.btnLuu,
            this.btnXoa,
            this.btSua,
            this.btRefresh,
            this.btTroVe});
            this.barManager1.MaxItemId = 11;
            // 
            // bar1
            // 
            this.bar1.BarName = "Tools";
            this.bar1.DockCol = 0;
            this.bar1.DockRow = 0;
            this.bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnThemMoi, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btSua, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btTroVe, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnLuu, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnXoa, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btRefresh, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnThoat, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)});
            this.bar1.Text = "Tools";
            // 
            // btnThemMoi
            // 
            this.btnThemMoi.Caption = "Thêm";
            this.btnThemMoi.Id = 2;
            this.btnThemMoi.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnThemMoi.ImageOptions.Image")));
            this.btnThemMoi.ItemShortcut = new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N));
            this.btnThemMoi.Name = "btnThemMoi";
            toolTipTitleItem5.Text = "Ctrl+N";
            superToolTip5.Items.Add(toolTipTitleItem5);
            this.btnThemMoi.SuperTip = superToolTip5;
            this.btnThemMoi.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnThemMoi_ItemClick);
            // 
            // btSua
            // 
            this.btSua.Caption = "Sửa";
            this.btSua.Id = 8;
            this.btSua.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barButtonItem1.ImageOptions.Image")));
            this.btSua.Name = "btSua";
            this.btSua.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btSua_ItemClick);
            // 
            // btTroVe
            // 
            this.btTroVe.Caption = "Trở về";
            this.btTroVe.Id = 10;
            this.btTroVe.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barButtonItem3.ImageOptions.Image")));
            this.btTroVe.Name = "btTroVe";
            this.btTroVe.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btTroVe_ItemClick);
            // 
            // btnLuu
            // 
            this.btnLuu.Caption = "Lưu";
            this.btnLuu.Id = 3;
            this.btnLuu.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnLuu.ImageOptions.Image")));
            this.btnLuu.ItemShortcut = new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S));
            this.btnLuu.Name = "btnLuu";
            toolTipTitleItem6.Text = "Ctrl+S";
            superToolTip6.Items.Add(toolTipTitleItem6);
            this.btnLuu.SuperTip = superToolTip6;
            this.btnLuu.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnLuu_ItemClick);
            // 
            // btnXoa
            // 
            this.btnXoa.Caption = "Xóa";
            this.btnXoa.Id = 6;
            this.btnXoa.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnXoa.ImageOptions.Image")));
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnXoa_ItemClick);
            // 
            // btRefresh
            // 
            this.btRefresh.Caption = "Refresh";
            this.btRefresh.Id = 9;
            this.btRefresh.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barButtonItem2.ImageOptions.Image")));
            this.btRefresh.Name = "btRefresh";
            this.btRefresh.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btRefresh_ItemClick);
            // 
            // btnThoat
            // 
            this.btnThoat.Caption = "Thoát";
            this.btnThoat.Id = 1;
            this.btnThoat.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnThoat.ImageOptions.Image")));
            this.btnThoat.ItemShortcut = new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.X));
            this.btnThoat.Name = "btnThoat";
            toolTipTitleItem4.Text = "Alt+X";
            superToolTip4.Items.Add(toolTipTitleItem4);
            this.btnThoat.SuperTip = superToolTip4;
            this.btnThoat.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnThoat_ItemClick);
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.barManager1;
            this.barDockControlTop.Size = new System.Drawing.Size(984, 47);
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
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 47);
            this.barDockControlLeft.Manager = this.barManager1;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 614);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(984, 47);
            this.barDockControlRight.Manager = this.barManager1;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 614);
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.txt_DienGiai);
            this.groupControl1.Controls.Add(this.labelControl3);
            this.groupControl1.Controls.Add(this.txtTenDVT);
            this.groupControl1.Controls.Add(this.txtMaQL);
            this.groupControl1.Controls.Add(this.labelControl2);
            this.groupControl1.Controls.Add(this.labelControl1);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupControl1.Location = new System.Drawing.Point(0, 47);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(984, 87);
            this.groupControl1.TabIndex = 4;
            this.groupControl1.Text = "Thông tin đơn vị tính";
            // 
            // txt_DienGiai
            // 
            this.txt_DienGiai.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.tblDonViTinhBindingSource, "DienGiai", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.txt_DienGiai.Location = new System.Drawing.Point(84, 50);
            this.txt_DienGiai.Name = "txt_DienGiai";
            this.txt_DienGiai.Size = new System.Drawing.Size(431, 20);
            this.txt_DienGiai.TabIndex = 2;
            // 
            // tblDonViTinhBindingSource
            // 
            this.tblDonViTinhBindingSource.DataSource = typeof(PSC_ERP_Business.Main.Model.tblDonViTinh);
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(22, 53);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(44, 13);
            this.labelControl3.TabIndex = 2;
            this.labelControl3.Text = "Diễn giải:";
            // 
            // txtTenDVT
            // 
            this.txtTenDVT.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.tblDonViTinhBindingSource, "TenDonViTinh", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.txtTenDVT.Location = new System.Drawing.Point(343, 24);
            this.txtTenDVT.Name = "txtTenDVT";
            this.txtTenDVT.Size = new System.Drawing.Size(172, 20);
            this.txtTenDVT.TabIndex = 1;
            // 
            // txtMaQL
            // 
            this.txtMaQL.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.tblDonViTinhBindingSource, "MaQuanLy", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.txtMaQL.Location = new System.Drawing.Point(84, 24);
            this.txtMaQL.MenuManager = this.barManager1;
            this.txtMaQL.Name = "txtMaQL";
            this.txtMaQL.Size = new System.Drawing.Size(125, 20);
            this.txtMaQL.TabIndex = 0;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(292, 28);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(45, 13);
            this.labelControl2.TabIndex = 0;
            this.labelControl2.Text = "Tên ĐVT:";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(22, 28);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(56, 13);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Mã quản lý:";
            // 
            // grdDonViTinh
            // 
            this.grdDonViTinh.DataSource = this.tblDonViTinhBindingSource;
            this.grdDonViTinh.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdDonViTinh.Location = new System.Drawing.Point(2, 20);
            this.grdDonViTinh.MainView = this.grdViewDonViTinh;
            this.grdDonViTinh.MenuManager = this.barManager1;
            this.grdDonViTinh.Name = "grdDonViTinh";
            this.grdDonViTinh.Size = new System.Drawing.Size(980, 505);
            this.grdDonViTinh.TabIndex = 3;
            this.grdDonViTinh.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grdViewDonViTinh});
            // 
            // grdViewDonViTinh
            // 
            this.grdViewDonViTinh.Appearance.FooterPanel.Options.UseTextOptions = true;
            this.grdViewDonViTinh.Appearance.FooterPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.grdViewDonViTinh.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colMaQuanLy,
            this.colTenDonViTinh,
            this.colDienGiai});
            this.grdViewDonViTinh.GridControl = this.grdDonViTinh;
            this.grdViewDonViTinh.GroupPanelText = "Danh Mục Đơn Vị Tính";
            this.grdViewDonViTinh.Name = "grdViewDonViTinh";
            this.grdViewDonViTinh.OptionsSelection.MultiSelect = true;
            this.grdViewDonViTinh.OptionsView.ShowAutoFilterRow = true;
            this.grdViewDonViTinh.OptionsView.ShowFooter = true;
            this.grdViewDonViTinh.OptionsView.ShowGroupPanel = false;
            // 
            // colMaQuanLy
            // 
            this.colMaQuanLy.AppearanceHeader.Options.UseTextOptions = true;
            this.colMaQuanLy.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colMaQuanLy.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colMaQuanLy.Caption = "Mã";
            this.colMaQuanLy.FieldName = "MaQuanLy";
            this.colMaQuanLy.Name = "colMaQuanLy";
            this.colMaQuanLy.OptionsColumn.ReadOnly = true;
            this.colMaQuanLy.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colMaQuanLy.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "MaQuanLy", "{0:0.##}")});
            this.colMaQuanLy.Visible = true;
            this.colMaQuanLy.VisibleIndex = 0;
            this.colMaQuanLy.Width = 50;
            // 
            // colTenDonViTinh
            // 
            this.colTenDonViTinh.AppearanceHeader.Options.UseTextOptions = true;
            this.colTenDonViTinh.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colTenDonViTinh.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colTenDonViTinh.Caption = "Tên Đơn Vị Tính";
            this.colTenDonViTinh.FieldName = "TenDonViTinh";
            this.colTenDonViTinh.Name = "colTenDonViTinh";
            this.colTenDonViTinh.OptionsColumn.ReadOnly = true;
            this.colTenDonViTinh.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colTenDonViTinh.Visible = true;
            this.colTenDonViTinh.VisibleIndex = 1;
            this.colTenDonViTinh.Width = 100;
            // 
            // colDienGiai
            // 
            this.colDienGiai.AppearanceHeader.Options.UseTextOptions = true;
            this.colDienGiai.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colDienGiai.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colDienGiai.Caption = "Diễn Giải";
            this.colDienGiai.FieldName = "DienGiai";
            this.colDienGiai.Name = "colDienGiai";
            this.colDienGiai.OptionsColumn.ReadOnly = true;
            this.colDienGiai.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colDienGiai.Visible = true;
            this.colDienGiai.VisibleIndex = 2;
            this.colDienGiai.Width = 120;
            // 
            // txtBlackHole
            // 
            this.txtBlackHole.Location = new System.Drawing.Point(0, 53);
            this.txtBlackHole.Name = "txtBlackHole";
            this.txtBlackHole.Size = new System.Drawing.Size(100, 21);
            this.txtBlackHole.TabIndex = 6;
            this.txtBlackHole.TabStop = false;
            // 
            // GrDSDVT
            // 
            this.GrDSDVT.Controls.Add(this.grdDonViTinh);
            this.GrDSDVT.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GrDSDVT.Location = new System.Drawing.Point(0, 134);
            this.GrDSDVT.Name = "GrDSDVT";
            this.GrDSDVT.Size = new System.Drawing.Size(984, 527);
            this.GrDSDVT.TabIndex = 11;
            this.GrDSDVT.Text = "Danh sách đơn vị tính";
            // 
            // frmListDonViTinh
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 661);
            this.Controls.Add(this.GrDSDVT);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.txtBlackHole);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "frmListDonViTinh";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Danh mục đơn vị tính";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmListDonViTinh_FormClosing);
            this.Load += new System.EventHandler(this.frmHopDongTaiSan_Load);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txt_DienGiai.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblDonViTinhBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTenDVT.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaQL.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdDonViTinh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdViewDonViTinh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrDSDVT)).EndInit();
            this.GrDSDVT.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar1;
        private DevExpress.XtraBars.BarButtonItem btnThemMoi;
        private DevExpress.XtraBars.BarButtonItem btnLuu;
        private DevExpress.XtraBars.BarButtonItem btnThoat;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraGrid.GridControl grdDonViTinh;
        private DevExpress.XtraGrid.Views.Grid.GridView grdViewDonViTinh;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit txtTenDVT;
        private DevExpress.XtraEditors.TextEdit txtMaQL;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private System.Windows.Forms.TextBox txtBlackHole;
        private DevExpress.XtraBars.BarButtonItem btnXoa;
        private System.Windows.Forms.BindingSource tblDonViTinhBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colMaQuanLy;
        private DevExpress.XtraGrid.Columns.GridColumn colTenDonViTinh;
        private DevExpress.XtraGrid.Columns.GridColumn colDienGiai;
        private DevExpress.XtraEditors.TextEdit txt_DienGiai;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraBars.BarButtonItem btSua;
        private DevExpress.XtraBars.BarButtonItem btTroVe;
        private DevExpress.XtraBars.BarButtonItem btRefresh;
        private DevExpress.XtraEditors.GroupControl GrDSDVT;
    }
}