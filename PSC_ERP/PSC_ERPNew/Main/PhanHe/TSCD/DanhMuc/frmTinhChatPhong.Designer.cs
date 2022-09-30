namespace PSC_ERPNew.Main
{
    partial class frmTinhChatPhong
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTinhChatPhong));
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar1 = new DevExpress.XtraBars.Bar();
            this.btnThem = new DevExpress.XtraBars.BarButtonItem();
            this.btnSua = new DevExpress.XtraBars.BarButtonItem();
            this.btnXoa = new DevExpress.XtraBars.BarButtonItem();
            this.btnLuu = new DevExpress.XtraBars.BarButtonItem();
            this.btnHuy = new DevExpress.XtraBars.BarButtonItem();
            this.btnXuatExcel = new DevExpress.XtraBars.BarButtonItem();
            this.btnThoat = new DevExpress.XtraBars.BarButtonItem();
            this.bar3 = new DevExpress.XtraBars.Bar();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.gridC_TinhChatPhong = new DevExpress.XtraGrid.GridControl();
            this.bindingSource_TinhChatPhong = new System.Windows.Forms.BindingSource(this.components);
            this.gridV_TinhChatPhong = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colMaTinhChatPhongQL = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTenTinhChatPhong = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repoDienGiai = new DevExpress.XtraEditors.Repository.RepositoryItemMemoExEdit();
            this.tableLayout_TinhChatPhong = new System.Windows.Forms.TableLayoutPanel();
            this.colDienGiaiText = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridC_TinhChatPhong)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource_TinhChatPhong)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridV_TinhChatPhong)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repoDienGiai)).BeginInit();
            this.tableLayout_TinhChatPhong.SuspendLayout();
            this.SuspendLayout();
            // 
            // barManager1
            // 
            this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar1,
            this.bar3});
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.btnThoat,
            this.btnThem,
            this.btnSua,
            this.btnXoa,
            this.btnLuu,
            this.btnXuatExcel,
            this.btnHuy});
            this.barManager1.MaxItemId = 7;
            this.barManager1.StatusBar = this.bar3;
            // 
            // bar1
            // 
            this.bar1.BarName = "Tools";
            this.bar1.DockCol = 0;
            this.bar1.DockRow = 0;
            this.bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnThem, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnSua, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnXoa, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnLuu, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnHuy, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnXuatExcel, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnThoat, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)});
            this.bar1.Text = "Tools";
            // 
            // btnThem
            // 
            this.btnThem.Caption = "Thêm";
            this.btnThem.Id = 1;
            this.btnThem.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnThem.ImageOptions.Image")));
            this.btnThem.Name = "btnThem";
            this.btnThem.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnThem_ItemClick);
            // 
            // btnSua
            // 
            this.btnSua.Caption = "Sửa";
            this.btnSua.Id = 2;
            this.btnSua.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnSua.ImageOptions.Image")));
            this.btnSua.Name = "btnSua";
            this.btnSua.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnSua_ItemClick);
            // 
            // btnXoa
            // 
            this.btnXoa.Caption = "Xóa";
            this.btnXoa.Id = 3;
            this.btnXoa.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnXoa.ImageOptions.Image")));
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnXoa_ItemClick);
            // 
            // btnLuu
            // 
            this.btnLuu.Caption = "Lưu";
            this.btnLuu.Id = 4;
            this.btnLuu.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnLuu.ImageOptions.Image")));
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnLuu_ItemClick);
            // 
            // btnHuy
            // 
            this.btnHuy.Caption = "Hủy";
            this.btnHuy.Id = 6;
            this.btnHuy.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnHuy.ImageOptions.Image")));
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnHuy_ItemClick);
            // 
            // btnXuatExcel
            // 
            this.btnXuatExcel.Caption = "Xuất Excel";
            this.btnXuatExcel.Id = 5;
            this.btnXuatExcel.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnXuatExcel.ImageOptions.Image")));
            this.btnXuatExcel.Name = "btnXuatExcel";
            this.btnXuatExcel.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnXuatExcel_ItemClick);
            // 
            // btnThoat
            // 
            this.btnThoat.Caption = "Thoát";
            this.btnThoat.Id = 0;
            this.btnThoat.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnThoat.ImageOptions.Image")));
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnThoat_ItemClick);
            // 
            // bar3
            // 
            this.bar3.BarName = "Status bar";
            this.bar3.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Bottom;
            this.bar3.DockCol = 0;
            this.bar3.DockRow = 0;
            this.bar3.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom;
            this.bar3.OptionsBar.AllowQuickCustomization = false;
            this.bar3.OptionsBar.DrawDragBorder = false;
            this.bar3.OptionsBar.UseWholeRow = true;
            this.bar3.Text = "Status bar";
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.barManager1;
            this.barDockControlTop.Size = new System.Drawing.Size(1002, 47);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 483);
            this.barDockControlBottom.Manager = this.barManager1;
            this.barDockControlBottom.Size = new System.Drawing.Size(1002, 23);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 47);
            this.barDockControlLeft.Manager = this.barManager1;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 436);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(1002, 47);
            this.barDockControlRight.Manager = this.barManager1;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 436);
            // 
            // gridC_TinhChatPhong
            // 
            this.gridC_TinhChatPhong.DataSource = this.bindingSource_TinhChatPhong;
            this.gridC_TinhChatPhong.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridC_TinhChatPhong.Location = new System.Drawing.Point(3, 3);
            this.gridC_TinhChatPhong.MainView = this.gridV_TinhChatPhong;
            this.gridC_TinhChatPhong.MenuManager = this.barManager1;
            this.gridC_TinhChatPhong.Name = "gridC_TinhChatPhong";
            this.gridC_TinhChatPhong.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repoDienGiai});
            this.gridC_TinhChatPhong.Size = new System.Drawing.Size(996, 430);
            this.gridC_TinhChatPhong.TabIndex = 4;
            this.gridC_TinhChatPhong.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridV_TinhChatPhong});
            this.gridC_TinhChatPhong.ProcessGridKey += new System.Windows.Forms.KeyEventHandler(this.gridC_TinhChatPhong_ProcessGridKey);
            // 
            // bindingSource_TinhChatPhong
            // 
            this.bindingSource_TinhChatPhong.AllowNew = true;
            this.bindingSource_TinhChatPhong.DataSource = typeof(ERP_Library.TinhChatPhongList);
            // 
            // gridV_TinhChatPhong
            // 
            this.gridV_TinhChatPhong.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colMaTinhChatPhongQL,
            this.colTenTinhChatPhong,
            this.colDienGiaiText});
            this.gridV_TinhChatPhong.GridControl = this.gridC_TinhChatPhong;
            this.gridV_TinhChatPhong.IndicatorWidth = 35;
            this.gridV_TinhChatPhong.Name = "gridV_TinhChatPhong";
            this.gridV_TinhChatPhong.NewItemRowText = "Nhấn Vào Đây Để Thêm Dữ Liệu Mới ";
            this.gridV_TinhChatPhong.OptionsSelection.MultiSelect = true;
            this.gridV_TinhChatPhong.OptionsView.ShowAutoFilterRow = true;
            this.gridV_TinhChatPhong.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gridV_TinhChatPhong_CellValueChanged);
            // 
            // colMaTinhChatPhongQL
            // 
            this.colMaTinhChatPhongQL.Caption = "Mã Tính Chất Phòng";
            this.colMaTinhChatPhongQL.FieldName = "MaTinhChatPhongQL";
            this.colMaTinhChatPhongQL.Name = "colMaTinhChatPhongQL";
            this.colMaTinhChatPhongQL.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colMaTinhChatPhongQL.Visible = true;
            this.colMaTinhChatPhongQL.VisibleIndex = 0;
            this.colMaTinhChatPhongQL.Width = 243;
            // 
            // colTenTinhChatPhong
            // 
            this.colTenTinhChatPhong.Caption = "Tên Tính Chất Phòng";
            this.colTenTinhChatPhong.FieldName = "TenTinhChatPhong";
            this.colTenTinhChatPhong.Name = "colTenTinhChatPhong";
            this.colTenTinhChatPhong.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colTenTinhChatPhong.Visible = true;
            this.colTenTinhChatPhong.VisibleIndex = 1;
            this.colTenTinhChatPhong.Width = 589;
            // 
            // repoDienGiai
            // 
            this.repoDienGiai.AutoHeight = false;
            this.repoDienGiai.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repoDienGiai.Name = "repoDienGiai";
            // 
            // tableLayout_TinhChatPhong
            // 
            this.tableLayout_TinhChatPhong.ColumnCount = 1;
            this.tableLayout_TinhChatPhong.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayout_TinhChatPhong.Controls.Add(this.gridC_TinhChatPhong, 0, 0);
            this.tableLayout_TinhChatPhong.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayout_TinhChatPhong.Location = new System.Drawing.Point(0, 47);
            this.tableLayout_TinhChatPhong.Name = "tableLayout_TinhChatPhong";
            this.tableLayout_TinhChatPhong.RowCount = 1;
            this.tableLayout_TinhChatPhong.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayout_TinhChatPhong.Size = new System.Drawing.Size(1002, 436);
            this.tableLayout_TinhChatPhong.TabIndex = 10;
            // 
            // colDienGiaiText
            // 
            this.colDienGiaiText.Caption = "Chú Thích";
            this.colDienGiaiText.FieldName = "DienGiaiText";
            this.colDienGiaiText.Name = "colDienGiaiText";
            this.colDienGiaiText.Visible = true;
            this.colDienGiaiText.VisibleIndex = 2;
            this.colDienGiaiText.Width = 344;
            // 
            // frmTinhChatPhong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1002, 506);
            this.Controls.Add(this.tableLayout_TinhChatPhong);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "frmTinhChatPhong";
            this.Text = "Danh Mục Tính Chát Phòng";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmTinhChatPhong_FormClosing);
            this.Load += new System.EventHandler(this.frmTinhChatPhong_Load);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridC_TinhChatPhong)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource_TinhChatPhong)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridV_TinhChatPhong)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repoDienGiai)).EndInit();
            this.tableLayout_TinhChatPhong.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar1;
        private DevExpress.XtraBars.BarButtonItem btnThem;
        private DevExpress.XtraBars.BarButtonItem btnSua;
        private DevExpress.XtraBars.BarButtonItem btnXoa;
        private DevExpress.XtraBars.BarButtonItem btnLuu;
        private DevExpress.XtraBars.BarButtonItem btnThoat;
        private DevExpress.XtraBars.Bar bar3;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraGrid.GridControl gridC_TinhChatPhong;
        private DevExpress.XtraGrid.Views.Grid.GridView gridV_TinhChatPhong;
        private System.Windows.Forms.BindingSource bindingSource_TinhChatPhong;
        private DevExpress.XtraGrid.Columns.GridColumn colMaTinhChatPhongQL;
        private DevExpress.XtraGrid.Columns.GridColumn colTenTinhChatPhong;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoExEdit repoDienGiai;
        private DevExpress.XtraBars.BarButtonItem btnXuatExcel;
        private System.Windows.Forms.TableLayoutPanel tableLayout_TinhChatPhong;
        private DevExpress.XtraBars.BarButtonItem btnHuy;
        private DevExpress.XtraGrid.Columns.GridColumn colDienGiaiText;
    }
}