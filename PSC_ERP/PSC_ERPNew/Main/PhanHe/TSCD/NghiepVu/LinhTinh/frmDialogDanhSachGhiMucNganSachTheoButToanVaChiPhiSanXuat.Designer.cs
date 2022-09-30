namespace PSC_ERPNew.Main
{//
    partial class frmDialogDanhSachGhiMucNganSachTheoButToanVaChiPhiSanXuat
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDialogDanhSachGhiMucNganSachTheoButToanVaChiPhiSanXuat));
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar1 = new DevExpress.XtraBars.Bar();
            this.btnDuaDuLieuVeChungTu = new DevExpress.XtraBars.BarButtonItem();
            this.btnThem = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.txtBlackHole = new System.Windows.Forms.TextBox();
            this.tblButToanMucNganSachBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tblTieuMucNganSachBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.grdButToanMuc_NganSach = new DevExpress.XtraGrid.GridControl();
            this.grdViewButToan_MucNganSach = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colSoTien = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMaTieuMuc = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cbTieuMucNganSach_ForGrid = new DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit();
            this.repositoryItemGridLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colTenTieuMuc = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMaQuanLy = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDienGiai1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDienGiai = new DevExpress.XtraGrid.Columns.GridColumn();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblButToanMucNganSachBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblTieuMucNganSachBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdButToanMuc_NganSach)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdViewButToan_MucNganSach)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbTieuMucNganSach_ForGrid)).BeginInit();
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
            this.btnDuaDuLieuVeChungTu,
            this.btnThem});
            this.barManager1.MaxItemId = 11;
            // 
            // bar1
            // 
            this.bar1.BarName = "Tools";
            this.bar1.DockCol = 0;
            this.bar1.DockRow = 0;
            this.bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnDuaDuLieuVeChungTu, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnThem, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)});
            this.bar1.Text = "Tools";
            // 
            // btnDuaDuLieuVeChungTu
            // 
            this.btnDuaDuLieuVeChungTu.Caption = "Về chứng từ";
            this.btnDuaDuLieuVeChungTu.Id = 8;
            this.btnDuaDuLieuVeChungTu.ImageIndex = 1;
            this.btnDuaDuLieuVeChungTu.ItemShortcut = new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.B));
            this.btnDuaDuLieuVeChungTu.Name = "btnDuaDuLieuVeChungTu";
            toolTipTitleItem1.Text = "Ctrl+B";
            superToolTip1.Items.Add(toolTipTitleItem1);
            this.btnDuaDuLieuVeChungTu.SuperTip = superToolTip1;
            this.btnDuaDuLieuVeChungTu.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnDuaDuLieuVeChungTu_ItemClick);
            // 
            // btnThem
            // 
            this.btnThem.Caption = "Thêm";
            this.btnThem.Id = 10;
            this.btnThem.ImageIndex = 0;
            this.btnThem.ItemShortcut = new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N));
            this.btnThem.Name = "btnThem";
            toolTipTitleItem2.Text = "Ctrl+N";
            superToolTip2.Items.Add(toolTipTitleItem2);
            this.btnThem.SuperTip = superToolTip2;
            this.btnThem.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnThem_ItemClick);
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(1024, 39);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 661);
            this.barDockControlBottom.Size = new System.Drawing.Size(1024, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 39);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 622);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(1024, 39);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 622);
            // 
            // txtBlackHole
            // 
            this.txtBlackHole.Location = new System.Drawing.Point(0, 53);
            this.txtBlackHole.Name = "txtBlackHole";
            this.txtBlackHole.Size = new System.Drawing.Size(100, 21);
            this.txtBlackHole.TabIndex = 6;
            this.txtBlackHole.TabStop = false;
            // 
            // tblButToanMucNganSachBindingSource
            // 
            this.tblButToanMucNganSachBindingSource.DataSource = typeof(PSC_ERP_Business.Main.Model.tblButToan_MucNganSach);
            // 
            // tblTieuMucNganSachBindingSource
            // 
            this.tblTieuMucNganSachBindingSource.DataSource = typeof(PSC_ERP_Business.Main.Model.tblTieuMucNganSach);
            // 
            // grdButToanMuc_NganSach
            // 
            this.grdButToanMuc_NganSach.DataSource = this.tblButToanMucNganSachBindingSource;
            this.grdButToanMuc_NganSach.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdButToanMuc_NganSach.Location = new System.Drawing.Point(0, 39);
            this.grdButToanMuc_NganSach.MainView = this.grdViewButToan_MucNganSach;
            this.grdButToanMuc_NganSach.MenuManager = this.barManager1;
            this.grdButToanMuc_NganSach.Name = "grdButToanMuc_NganSach";
            this.grdButToanMuc_NganSach.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.cbTieuMucNganSach_ForGrid});
            this.grdButToanMuc_NganSach.Size = new System.Drawing.Size(1024, 622);
            this.grdButToanMuc_NganSach.TabIndex = 18;
            this.grdButToanMuc_NganSach.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grdViewButToan_MucNganSach});
            // 
            // grdViewButToan_MucNganSach
            // 
            this.grdViewButToan_MucNganSach.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colSoTien,
            this.colMaTieuMuc,
            this.colDienGiai});
            this.grdViewButToan_MucNganSach.GridControl = this.grdButToanMuc_NganSach;
            this.grdViewButToan_MucNganSach.Name = "grdViewButToan_MucNganSach";
            this.grdViewButToan_MucNganSach.NewItemRowText = "<<Thêm dòng mới>>";
            this.grdViewButToan_MucNganSach.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
            this.grdViewButToan_MucNganSach.OptionsView.ShowFooter = true;
            this.grdViewButToan_MucNganSach.InitNewRow += new DevExpress.XtraGrid.Views.Grid.InitNewRowEventHandler(this.grdViewButToan_MucNganSach_InitNewRow);
            // 
            // colSoTien
            // 
            this.colSoTien.Caption = "Số tiền";
            this.colSoTien.DisplayFormat.FormatString = "n0";
            this.colSoTien.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colSoTien.FieldName = "SoTien";
            this.colSoTien.Name = "colSoTien";
            this.colSoTien.Visible = true;
            this.colSoTien.VisibleIndex = 1;
            // 
            // colMaTieuMuc
            // 
            this.colMaTieuMuc.Caption = "Tiểu mục ngân sách";
            this.colMaTieuMuc.ColumnEdit = this.cbTieuMucNganSach_ForGrid;
            this.colMaTieuMuc.FieldName = "MaTieuMuc";
            this.colMaTieuMuc.Name = "colMaTieuMuc";
            this.colMaTieuMuc.Visible = true;
            this.colMaTieuMuc.VisibleIndex = 0;
            // 
            // cbTieuMucNganSach_ForGrid
            // 
            this.cbTieuMucNganSach_ForGrid.AutoHeight = false;
            this.cbTieuMucNganSach_ForGrid.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbTieuMucNganSach_ForGrid.DataSource = this.tblTieuMucNganSachBindingSource;
            this.cbTieuMucNganSach_ForGrid.DisplayMember = "TenTieuMuc";
            this.cbTieuMucNganSach_ForGrid.Name = "cbTieuMucNganSach_ForGrid";
            this.cbTieuMucNganSach_ForGrid.NullText = "<<Không chọn>>";
            this.cbTieuMucNganSach_ForGrid.ValueMember = "MaTieuMuc";
            this.cbTieuMucNganSach_ForGrid.View = this.repositoryItemGridLookUpEdit1View;
            // 
            // repositoryItemGridLookUpEdit1View
            // 
            this.repositoryItemGridLookUpEdit1View.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colTenTieuMuc,
            this.colMaQuanLy,
            this.colDienGiai1});
            this.repositoryItemGridLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.repositoryItemGridLookUpEdit1View.Name = "repositoryItemGridLookUpEdit1View";
            this.repositoryItemGridLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.repositoryItemGridLookUpEdit1View.OptionsView.ShowAutoFilterRow = true;
            this.repositoryItemGridLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // colTenTieuMuc
            // 
            this.colTenTieuMuc.Caption = "Tên";
            this.colTenTieuMuc.FieldName = "TenTieuMuc";
            this.colTenTieuMuc.Name = "colTenTieuMuc";
            this.colTenTieuMuc.Visible = true;
            this.colTenTieuMuc.VisibleIndex = 0;
            this.colTenTieuMuc.Width = 200;
            // 
            // colMaQuanLy
            // 
            this.colMaQuanLy.Caption = "Mã";
            this.colMaQuanLy.FieldName = "MaQuanLy";
            this.colMaQuanLy.Name = "colMaQuanLy";
            this.colMaQuanLy.Visible = true;
            this.colMaQuanLy.VisibleIndex = 1;
            this.colMaQuanLy.Width = 92;
            // 
            // colDienGiai1
            // 
            this.colDienGiai1.Caption = "Diễn giải";
            this.colDienGiai1.FieldName = "DienGiai";
            this.colDienGiai1.Name = "colDienGiai1";
            this.colDienGiai1.Visible = true;
            this.colDienGiai1.VisibleIndex = 2;
            this.colDienGiai1.Width = 92;
            // 
            // colDienGiai
            // 
            this.colDienGiai.Caption = "Diễn giải";
            this.colDienGiai.FieldName = "DienGiai";
            this.colDienGiai.Name = "colDienGiai";
            this.colDienGiai.Visible = true;
            this.colDienGiai.VisibleIndex = 2;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "add64.png");
            this.imageList1.Images.SetKeyName(1, "1346734888_import.png");
            // 
            // frmDialogDanhSachGhiMucNganSachTheoButToanVaChiPhiSanXuat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1024, 661);
            this.ControlBox = false;
            this.Controls.Add(this.grdButToanMuc_NganSach);
            this.Controls.Add(this.txtBlackHole);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "frmDialogDanhSachGhiMucNganSachTheoButToanVaChiPhiSanXuat";
            this.Text = "Ghi mục ngân sách theo bút toán và chi phí sản xuất";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmDialogDanhSachGhiMucNganSachTheoButToan_FormClosing);
            this.Load += new System.EventHandler(this.frmDialogDanhSachGhiMucNganSachTheoButToan_Load);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblButToanMucNganSachBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblTieuMucNganSachBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdButToanMuc_NganSach)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdViewButToan_MucNganSach)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbTieuMucNganSach_ForGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemGridLookUpEdit1View)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar1;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private System.Windows.Forms.TextBox txtBlackHole;
        private DevExpress.XtraBars.BarButtonItem btnDuaDuLieuVeChungTu;
        private System.Windows.Forms.BindingSource tblButToanMucNganSachBindingSource;
        private System.Windows.Forms.BindingSource tblTieuMucNganSachBindingSource;
        private DevExpress.XtraGrid.GridControl grdButToanMuc_NganSach;
        private DevExpress.XtraGrid.Views.Grid.GridView grdViewButToan_MucNganSach;
        private DevExpress.XtraGrid.Columns.GridColumn colSoTien;
        private DevExpress.XtraGrid.Columns.GridColumn colMaTieuMuc;
        private DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit cbTieuMucNganSach_ForGrid;
        private DevExpress.XtraGrid.Views.Grid.GridView repositoryItemGridLookUpEdit1View;
        private DevExpress.XtraGrid.Columns.GridColumn colTenTieuMuc;
        private DevExpress.XtraGrid.Columns.GridColumn colMaQuanLy;
        private DevExpress.XtraGrid.Columns.GridColumn colDienGiai1;
        private DevExpress.XtraGrid.Columns.GridColumn colDienGiai;
        private DevExpress.XtraBars.BarButtonItem btnThem;
        private System.Windows.Forms.ImageList imageList1;
    }
}