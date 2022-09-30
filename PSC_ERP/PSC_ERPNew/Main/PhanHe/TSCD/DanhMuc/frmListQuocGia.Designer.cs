namespace PSC_ERPNew.Main
{
    partial class frmListQuocGia
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmListQuocGia));
            DevExpress.Utils.SuperToolTip superToolTip1 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem1 = new DevExpress.Utils.ToolTipTitleItem();
            DevExpress.Utils.SuperToolTip superToolTip2 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem2 = new DevExpress.Utils.ToolTipTitleItem();
            DevExpress.Utils.SuperToolTip superToolTip3 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem3 = new DevExpress.Utils.ToolTipTitleItem();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar1 = new DevExpress.XtraBars.Bar();
            this.btnThemMoi = new DevExpress.XtraBars.BarButtonItem();
            this.btnLuu = new DevExpress.XtraBars.BarButtonItem();
            this.btnXoa = new DevExpress.XtraBars.BarButtonItem();
            this.btnThoat = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.txt_TenVietTat = new DevExpress.XtraEditors.TextEdit();
            this.tblQuocGiaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.txt_DienGiai = new DevExpress.XtraEditors.TextEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.txtTenQuocGia = new DevExpress.XtraEditors.TextEdit();
            this.txtMaQL = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.grdDonViTinh = new DevExpress.XtraGrid.GridControl();
            this.grdViewQuocGia = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colMaQuocGiaQuanLy = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTenQuocGia = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTenVietTat = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDienGiai = new DevExpress.XtraGrid.Columns.GridColumn();
            this.txtBlackHole = new System.Windows.Forms.TextBox();
            this.btnSua = new DevExpress.XtraBars.BarButtonItem();
            this.btnTroVe = new DevExpress.XtraBars.BarButtonItem();
            this.GrDSQG = new DevExpress.XtraEditors.GroupControl();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txt_TenVietTat.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblQuocGiaBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_DienGiai.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTenQuocGia.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaQL.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdDonViTinh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdViewQuocGia)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrDSQG)).BeginInit();
            this.GrDSQG.SuspendLayout();
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
            this.btnSua,
            this.btnTroVe});
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
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnSua, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnTroVe, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnLuu, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnXoa, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
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
            toolTipTitleItem1.Text = "Ctrl+N";
            superToolTip1.Items.Add(toolTipTitleItem1);
            this.btnThemMoi.SuperTip = superToolTip1;
            this.btnThemMoi.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnThemMoi_ItemClick);
            // 
            // btnLuu
            // 
            this.btnLuu.Caption = "Lưu";
            this.btnLuu.Id = 3;
            this.btnLuu.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnLuu.ImageOptions.Image")));
            this.btnLuu.ItemShortcut = new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S));
            this.btnLuu.Name = "btnLuu";
            toolTipTitleItem2.Text = "Ctrl+S";
            superToolTip2.Items.Add(toolTipTitleItem2);
            this.btnLuu.SuperTip = superToolTip2;
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
            // btnThoat
            // 
            this.btnThoat.Caption = "Thoát";
            this.btnThoat.Id = 1;
            this.btnThoat.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnThoat.ImageOptions.Image")));
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
            this.groupControl1.Controls.Add(this.txt_TenVietTat);
            this.groupControl1.Controls.Add(this.labelControl4);
            this.groupControl1.Controls.Add(this.txt_DienGiai);
            this.groupControl1.Controls.Add(this.labelControl3);
            this.groupControl1.Controls.Add(this.txtTenQuocGia);
            this.groupControl1.Controls.Add(this.txtMaQL);
            this.groupControl1.Controls.Add(this.labelControl2);
            this.groupControl1.Controls.Add(this.labelControl1);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupControl1.Location = new System.Drawing.Point(0, 47);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(984, 87);
            this.groupControl1.TabIndex = 4;
            this.groupControl1.Text = "Thông tin quốc gia";
            // 
            // txt_TenVietTat
            // 
            this.txt_TenVietTat.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.tblQuocGiaBindingSource, "TenVietTat", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.txt_TenVietTat.Location = new System.Drawing.Point(113, 50);
            this.txt_TenVietTat.Name = "txt_TenVietTat";
            this.txt_TenVietTat.Size = new System.Drawing.Size(141, 20);
            this.txt_TenVietTat.TabIndex = 2;
            // 
            // tblQuocGiaBindingSource
            // 
            this.tblQuocGiaBindingSource.DataSource = typeof(PSC_ERP_Business.Main.Model.tblQuocGia);
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(46, 53);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(60, 13);
            this.labelControl4.TabIndex = 4;
            this.labelControl4.Text = "Tên viết tắt:";
            // 
            // txt_DienGiai
            // 
            this.txt_DienGiai.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.tblQuocGiaBindingSource, "DienGiai", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.txt_DienGiai.Location = new System.Drawing.Point(347, 50);
            this.txt_DienGiai.Name = "txt_DienGiai";
            this.txt_DienGiai.Size = new System.Drawing.Size(218, 20);
            this.txt_DienGiai.TabIndex = 3;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(275, 53);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(44, 13);
            this.labelControl3.TabIndex = 2;
            this.labelControl3.Text = "Diễn giải:";
            // 
            // txtTenQuocGia
            // 
            this.txtTenQuocGia.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.tblQuocGiaBindingSource, "TenQuocGia", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.txtTenQuocGia.Location = new System.Drawing.Point(347, 24);
            this.txtTenQuocGia.Name = "txtTenQuocGia";
            this.txtTenQuocGia.Size = new System.Drawing.Size(218, 20);
            this.txtTenQuocGia.TabIndex = 1;
            // 
            // txtMaQL
            // 
            this.txtMaQL.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.tblQuocGiaBindingSource, "MaQuocGiaQuanLy", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.txtMaQL.Location = new System.Drawing.Point(113, 24);
            this.txtMaQL.MenuManager = this.barManager1;
            this.txtMaQL.Name = "txtMaQL";
            this.txtMaQL.Size = new System.Drawing.Size(141, 20);
            this.txtMaQL.TabIndex = 0;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(275, 27);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(65, 13);
            this.labelControl2.TabIndex = 0;
            this.labelControl2.Text = "Tên quốc gia:";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(51, 27);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(56, 13);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Mã quản lý:";
            // 
            // grdDonViTinh
            // 
            this.grdDonViTinh.DataSource = this.tblQuocGiaBindingSource;
            this.grdDonViTinh.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdDonViTinh.Location = new System.Drawing.Point(2, 20);
            this.grdDonViTinh.MainView = this.grdViewQuocGia;
            this.grdDonViTinh.MenuManager = this.barManager1;
            this.grdDonViTinh.Name = "grdDonViTinh";
            this.grdDonViTinh.Size = new System.Drawing.Size(980, 505);
            this.grdDonViTinh.TabIndex = 4;
            this.grdDonViTinh.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grdViewQuocGia});
            // 
            // grdViewQuocGia
            // 
            this.grdViewQuocGia.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colMaQuocGiaQuanLy,
            this.colTenQuocGia,
            this.colTenVietTat,
            this.colDienGiai});
            this.grdViewQuocGia.GridControl = this.grdDonViTinh;
            this.grdViewQuocGia.GroupPanelText = "Danh Mục Đơn Vị TÍnh";
            this.grdViewQuocGia.Name = "grdViewQuocGia";
            this.grdViewQuocGia.OptionsSelection.MultiSelect = true;
            this.grdViewQuocGia.OptionsView.ShowAutoFilterRow = true;
            this.grdViewQuocGia.OptionsView.ShowGroupPanel = false;
            // 
            // colMaQuocGiaQuanLy
            // 
            this.colMaQuocGiaQuanLy.AppearanceHeader.Options.UseTextOptions = true;
            this.colMaQuocGiaQuanLy.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colMaQuocGiaQuanLy.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colMaQuocGiaQuanLy.Caption = "Mã";
            this.colMaQuocGiaQuanLy.FieldName = "MaQuocGiaQuanLy";
            this.colMaQuocGiaQuanLy.Name = "colMaQuocGiaQuanLy";
            this.colMaQuocGiaQuanLy.OptionsColumn.ReadOnly = true;
            this.colMaQuocGiaQuanLy.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colMaQuocGiaQuanLy.Visible = true;
            this.colMaQuocGiaQuanLy.VisibleIndex = 0;
            // 
            // colTenQuocGia
            // 
            this.colTenQuocGia.AppearanceHeader.Options.UseTextOptions = true;
            this.colTenQuocGia.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colTenQuocGia.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colTenQuocGia.Caption = "Tên quốc gia";
            this.colTenQuocGia.FieldName = "TenQuocGia";
            this.colTenQuocGia.Name = "colTenQuocGia";
            this.colTenQuocGia.OptionsColumn.ReadOnly = true;
            this.colTenQuocGia.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colTenQuocGia.Visible = true;
            this.colTenQuocGia.VisibleIndex = 1;
            // 
            // colTenVietTat
            // 
            this.colTenVietTat.AppearanceHeader.Options.UseTextOptions = true;
            this.colTenVietTat.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colTenVietTat.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colTenVietTat.Caption = "Viết tắt";
            this.colTenVietTat.FieldName = "TenVietTat";
            this.colTenVietTat.Name = "colTenVietTat";
            this.colTenVietTat.OptionsColumn.ReadOnly = true;
            this.colTenVietTat.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colTenVietTat.Visible = true;
            this.colTenVietTat.VisibleIndex = 2;
            // 
            // colDienGiai
            // 
            this.colDienGiai.AppearanceHeader.Options.UseTextOptions = true;
            this.colDienGiai.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colDienGiai.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colDienGiai.Caption = "Diễn giải";
            this.colDienGiai.FieldName = "DienGiai";
            this.colDienGiai.Name = "colDienGiai";
            this.colDienGiai.OptionsColumn.ReadOnly = true;
            this.colDienGiai.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colDienGiai.Visible = true;
            this.colDienGiai.VisibleIndex = 3;
            // 
            // txtBlackHole
            // 
            this.txtBlackHole.Location = new System.Drawing.Point(0, 53);
            this.txtBlackHole.Name = "txtBlackHole";
            this.txtBlackHole.Size = new System.Drawing.Size(100, 21);
            this.txtBlackHole.TabIndex = 6;
            this.txtBlackHole.TabStop = false;
            // 
            // btnSua
            // 
            this.btnSua.Caption = "Sửa";
            this.btnSua.Id = 8;
            this.btnSua.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnSua.ImageOptions.Image")));
            this.btnSua.Name = "btnSua";
            this.btnSua.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnSua_ItemClick);
            // 
            // btnTroVe
            // 
            this.btnTroVe.Caption = "Trở về";
            this.btnTroVe.Id = 9;
            this.btnTroVe.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnTroVe.ImageOptions.Image")));
            this.btnTroVe.Name = "btnTroVe";
            this.btnTroVe.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnTroVe_ItemClick);
            // 
            // GrDSQG
            // 
            this.GrDSQG.Controls.Add(this.grdDonViTinh);
            this.GrDSQG.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GrDSQG.Location = new System.Drawing.Point(0, 134);
            this.GrDSQG.Name = "GrDSQG";
            this.GrDSQG.Size = new System.Drawing.Size(984, 527);
            this.GrDSQG.TabIndex = 11;
            this.GrDSQG.Text = "Danh Mục Quốc Gia";
            // 
            // frmListQuocGia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 661);
            this.Controls.Add(this.GrDSQG);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.txtBlackHole);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "frmListQuocGia";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Danh mục quốc gia";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmListDonViTinh_FormClosing);
            this.Load += new System.EventHandler(this.frmHopDongTaiSan_Load);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txt_TenVietTat.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblQuocGiaBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_DienGiai.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTenQuocGia.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaQL.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdDonViTinh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdViewQuocGia)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrDSQG)).EndInit();
            this.GrDSQG.ResumeLayout(false);
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
        private DevExpress.XtraGrid.Views.Grid.GridView grdViewQuocGia;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit txtTenQuocGia;
        private DevExpress.XtraEditors.TextEdit txtMaQL;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private System.Windows.Forms.TextBox txtBlackHole;
        private DevExpress.XtraBars.BarButtonItem btnXoa;
        private DevExpress.XtraEditors.TextEdit txt_DienGiai;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private System.Windows.Forms.BindingSource tblQuocGiaBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colMaQuocGiaQuanLy;
        private DevExpress.XtraGrid.Columns.GridColumn colTenQuocGia;
        private DevExpress.XtraGrid.Columns.GridColumn colTenVietTat;
        private DevExpress.XtraGrid.Columns.GridColumn colDienGiai;
        private DevExpress.XtraEditors.TextEdit txt_TenVietTat;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraBars.BarButtonItem btnSua;
        private DevExpress.XtraBars.BarButtonItem btnTroVe;
        private DevExpress.XtraEditors.GroupControl GrDSQG;
    }
}