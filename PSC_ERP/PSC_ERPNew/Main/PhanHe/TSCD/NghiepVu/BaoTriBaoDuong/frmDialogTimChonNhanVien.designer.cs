namespace PSC_ERP.Main
{
    partial class frmDialogTimChonNhanVien
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDialogTimChonNhanVien));
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar1 = new DevExpress.XtraBars.Bar();
            this.btnDuaDuLieuVe = new DevExpress.XtraBars.BarButtonItem();
            this.btnThoat = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.txtBlackHole = new System.Windows.Forms.TextBox();
            this.grdNhanVien = new DevExpress.XtraGrid.GridControl();
            this.nhanVienBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.grdViewNhanVien = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colChon = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTenNhanVien1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMaQLNhanVien = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGioiTinhNam = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cbGioiTinh = new DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit();
            this.gioiTinhBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colTen = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTenBoPhan = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cbProjectEmployeeResource = new DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit();
            this.repositoryItemGridLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colDescription1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTenNhanVien = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdNhanVien)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nhanVienBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdViewNhanVien)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbGioiTinh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gioiTinhBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbProjectEmployeeResource)).BeginInit();
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
            this.btnDuaDuLieuVe,
            this.btnThoat});
            this.barManager1.MaxItemId = 8;
            // 
            // bar1
            // 
            this.bar1.BarName = "Tools";
            this.bar1.DockCol = 0;
            this.bar1.DockRow = 0;
            this.bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnDuaDuLieuVe, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnThoat, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)});
            this.bar1.Text = "Tools";
            // 
            // btnDuaDuLieuVe
            // 
            this.btnDuaDuLieuVe.Caption = "Đưa dữ liệu về";
            this.btnDuaDuLieuVe.Id = 6;
            this.btnDuaDuLieuVe.ImageIndex = 10;
            this.btnDuaDuLieuVe.ItemShortcut = new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.B));
            this.btnDuaDuLieuVe.Name = "btnDuaDuLieuVe";
            toolTipTitleItem1.Text = "Ctrl+B";
            superToolTip1.Items.Add(toolTipTitleItem1);
            this.btnDuaDuLieuVe.SuperTip = superToolTip1;
            this.btnDuaDuLieuVe.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnDuaDuLieuVeTask_ItemClick);
            // 
            // btnThoat
            // 
            this.btnThoat.Caption = "Thoát";
            this.btnThoat.Id = 7;
            this.btnThoat.ImageIndex = 9;
            this.btnThoat.ItemShortcut = new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.X));
            this.btnThoat.Name = "btnThoat";
            toolTipTitleItem2.Text = "Alt+X";
            superToolTip2.Items.Add(toolTipTitleItem2);
            this.btnThoat.SuperTip = superToolTip2;
            this.btnThoat.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnThoat_ItemClick);
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(613, 39);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 281);
            this.barDockControlBottom.Size = new System.Drawing.Size(613, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 39);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 242);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(613, 39);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 242);
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
            this.imageList1.Images.SetKeyName(10, "import.png");
            // 
            // txtBlackHole
            // 
            this.txtBlackHole.Location = new System.Drawing.Point(4, 41);
            this.txtBlackHole.Name = "txtBlackHole";
            this.txtBlackHole.Size = new System.Drawing.Size(100, 21);
            this.txtBlackHole.TabIndex = 20;
            this.txtBlackHole.TabStop = false;
            // 
            // grdNhanVien
            // 
            this.grdNhanVien.DataSource = this.nhanVienBindingSource;
            this.grdNhanVien.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdNhanVien.Location = new System.Drawing.Point(0, 39);
            this.grdNhanVien.MainView = this.grdViewNhanVien;
            this.grdNhanVien.Name = "grdNhanVien";
            this.grdNhanVien.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.cbProjectEmployeeResource,
            this.cbGioiTinh});
            this.grdNhanVien.Size = new System.Drawing.Size(613, 242);
            this.grdNhanVien.TabIndex = 25;
            this.grdNhanVien.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grdViewNhanVien});
            // 
            // nhanVienBindingSource
            // 
            this.nhanVienBindingSource.DataSource = typeof(PSC_ERP_Business.Main.Model.tblnsNhanVien);
            // 
            // grdViewNhanVien
            // 
            this.grdViewNhanVien.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colChon,
            this.colTenNhanVien1,
            this.colMaQLNhanVien,
            this.colGioiTinhNam,
            this.colTenBoPhan});
            this.grdViewNhanVien.GridControl = this.grdNhanVien;
            this.grdViewNhanVien.GroupPanelText = "Danh sách nhân viên";
            this.grdViewNhanVien.Name = "grdViewNhanVien";
            this.grdViewNhanVien.OptionsSelection.MultiSelect = true;
            this.grdViewNhanVien.OptionsView.ShowAutoFilterRow = true;
            this.grdViewNhanVien.OptionsView.ShowFooter = true;
            // 
            // colChon
            // 
            this.colChon.Caption = "Chọn";
            this.colChon.FieldName = "Chon";
            this.colChon.Name = "colChon";
            this.colChon.Visible = true;
            this.colChon.VisibleIndex = 0;
            this.colChon.Width = 70;
            // 
            // colTenNhanVien1
            // 
            this.colTenNhanVien1.Caption = "Tên nhân viên";
            this.colTenNhanVien1.FieldName = "TenNhanVien";
            this.colTenNhanVien1.Name = "colTenNhanVien1";
            this.colTenNhanVien1.OptionsColumn.AllowEdit = false;
            this.colTenNhanVien1.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colTenNhanVien1.Visible = true;
            this.colTenNhanVien1.VisibleIndex = 1;
            this.colTenNhanVien1.Width = 131;
            // 
            // colMaQLNhanVien
            // 
            this.colMaQLNhanVien.Caption = "Mã quản lý";
            this.colMaQLNhanVien.FieldName = "MaQLNhanVien";
            this.colMaQLNhanVien.Name = "colMaQLNhanVien";
            this.colMaQLNhanVien.OptionsColumn.AllowEdit = false;
            this.colMaQLNhanVien.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colMaQLNhanVien.Visible = true;
            this.colMaQLNhanVien.VisibleIndex = 2;
            this.colMaQLNhanVien.Width = 131;
            // 
            // colGioiTinhNam
            // 
            this.colGioiTinhNam.Caption = "Nam";
            this.colGioiTinhNam.ColumnEdit = this.cbGioiTinh;
            this.colGioiTinhNam.FieldName = "GioiTinh";
            this.colGioiTinhNam.Name = "colGioiTinhNam";
            this.colGioiTinhNam.OptionsColumn.AllowEdit = false;
            this.colGioiTinhNam.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colGioiTinhNam.Visible = true;
            this.colGioiTinhNam.VisibleIndex = 3;
            this.colGioiTinhNam.Width = 131;
            // 
            // cbGioiTinh
            // 
            this.cbGioiTinh.AutoHeight = false;
            this.cbGioiTinh.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbGioiTinh.DataSource = this.gioiTinhBindingSource;
            this.cbGioiTinh.DisplayMember = "Ten";
            this.cbGioiTinh.Name = "cbGioiTinh";
            this.cbGioiTinh.NullText = "";
            this.cbGioiTinh.ValueMember = "GioiTinhNam";
            this.cbGioiTinh.View = this.gridView1;
            // 
            // gioiTinhBindingSource
            // 
            this.gioiTinhBindingSource.DataSource = typeof(PSC_ERP_Business.Main.Predefined.GioiTinh);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colTen});
            this.gridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView1.OptionsView.ShowColumnHeaders = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // colTen
            // 
            this.colTen.FieldName = "Ten";
            this.colTen.Name = "colTen";
            this.colTen.OptionsColumn.AllowEdit = false;
            this.colTen.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colTen.Visible = true;
            this.colTen.VisibleIndex = 0;
            // 
            // colTenBoPhan
            // 
            this.colTenBoPhan.Caption = "Tên bộ phận";
            this.colTenBoPhan.FieldName = "TenBoPhan";
            this.colTenBoPhan.Name = "colTenBoPhan";
            this.colTenBoPhan.OptionsColumn.AllowEdit = false;
            this.colTenBoPhan.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colTenBoPhan.Visible = true;
            this.colTenBoPhan.VisibleIndex = 4;
            this.colTenBoPhan.Width = 132;
            // 
            // cbProjectEmployeeResource
            // 
            this.cbProjectEmployeeResource.AutoHeight = false;
            this.cbProjectEmployeeResource.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbProjectEmployeeResource.Name = "cbProjectEmployeeResource";
            this.cbProjectEmployeeResource.NullText = "";
            this.cbProjectEmployeeResource.View = this.repositoryItemGridLookUpEdit1View;
            // 
            // repositoryItemGridLookUpEdit1View
            // 
            this.repositoryItemGridLookUpEdit1View.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colDescription1,
            this.colTenNhanVien});
            this.repositoryItemGridLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.repositoryItemGridLookUpEdit1View.Name = "repositoryItemGridLookUpEdit1View";
            this.repositoryItemGridLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.repositoryItemGridLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // colDescription1
            // 
            this.colDescription1.FieldName = "Description";
            this.colDescription1.Name = "colDescription1";
            this.colDescription1.OptionsColumn.AllowEdit = false;
            this.colDescription1.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colDescription1.Visible = true;
            this.colDescription1.VisibleIndex = 0;
            // 
            // colTenNhanVien
            // 
            this.colTenNhanVien.Caption = "Tên nhân viên";
            this.colTenNhanVien.FieldName = "NhanVien.TenNhanVien";
            this.colTenNhanVien.Name = "colTenNhanVien";
            this.colTenNhanVien.OptionsColumn.AllowEdit = false;
            this.colTenNhanVien.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colTenNhanVien.Visible = true;
            this.colTenNhanVien.VisibleIndex = 1;
            // 
            // frmDialogTimChonNhanVien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(613, 281);
            this.ControlBox = false;
            this.Controls.Add(this.grdNhanVien);
            this.Controls.Add(this.txtBlackHole);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "frmDialogTimChonNhanVien";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tìm chọn nhân viên";
            this.Load += new System.EventHandler(this.frmDialogProjectEmployeeResource_Load);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdNhanVien)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nhanVienBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdViewNhanVien)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbGioiTinh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gioiTinhBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbProjectEmployeeResource)).EndInit();
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
        private System.Windows.Forms.ImageList imageList1;
        private DevExpress.XtraBars.BarButtonItem btnDuaDuLieuVe;
        private System.Windows.Forms.TextBox txtBlackHole;
        private DevExpress.XtraGrid.GridControl grdNhanVien;
        private DevExpress.XtraGrid.Views.Grid.GridView grdViewNhanVien;
        private DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit cbProjectEmployeeResource;
        private DevExpress.XtraGrid.Views.Grid.GridView repositoryItemGridLookUpEdit1View;
        private DevExpress.XtraGrid.Columns.GridColumn colDescription1;
        private DevExpress.XtraGrid.Columns.GridColumn colTenNhanVien;
        private DevExpress.XtraBars.BarButtonItem btnThoat;
        private System.Windows.Forms.BindingSource nhanVienBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colTenNhanVien1;
        private DevExpress.XtraGrid.Columns.GridColumn colMaQLNhanVien;
        private DevExpress.XtraGrid.Columns.GridColumn colGioiTinhNam;
        private DevExpress.XtraGrid.Columns.GridColumn colTenBoPhan;
        private DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit cbGioiTinh;
        private System.Windows.Forms.BindingSource gioiTinhBindingSource;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colTen;
        private DevExpress.XtraGrid.Columns.GridColumn colChon;
    }
}