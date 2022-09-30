namespace PSC_ERPNew.Main.Sys
{
    partial class frmGrant
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGrant));
            DevExpress.Utils.SuperToolTip superToolTip1 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem1 = new DevExpress.Utils.ToolTipTitleItem();
            DevExpress.Utils.SuperToolTip superToolTip2 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem2 = new DevExpress.Utils.ToolTipTitleItem();
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.gridControl_DanhSachUser = new DevExpress.XtraGrid.GridControl();
            this.appusersBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView_DanhSachUser = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colTenDangNhap = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMatKhau = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMaNhanVien = new DevExpress.XtraGrid.Columns.GridColumn();
            this.GridLookUpEditNhanVien = new DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit();
            this.tblnsNhanVienBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.GridLookUpEditViewNhanVien = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colMaQLNhanVien = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTenNhanVien = new DevExpress.XtraGrid.Columns.GridColumn();
            this.txtBlackHole = new DevExpress.XtraEditors.TextEdit();
            this.mainMenuBarManager = new DevExpress.XtraBars.BarManager(this.components);
            this.bar4 = new DevExpress.XtraBars.Bar();
            this.btnLuu = new DevExpress.XtraBars.BarButtonItem();
            this.btnThoat = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControl1 = new DevExpress.XtraBars.BarDockControl();
            this.btnThemMoi = new DevExpress.XtraBars.BarButtonItem();
            this.TreeList_DanhSachMenu = new DevExpress.XtraTreeList.TreeList();
            this.colTitle = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colMaPhanHeQL = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colChon = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colThem = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colSua = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colXoa = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.appMenuBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.mainMenuBar = new DevExpress.XtraBars.Bar();
            this.bar1 = new DevExpress.XtraBars.Bar();
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.bar3 = new DevExpress.XtraBars.Bar();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_DanhSachUser)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.appusersBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_DanhSachUser)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridLookUpEditNhanVien)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblnsNhanVienBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridLookUpEditViewNhanVien)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBlackHole.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mainMenuBarManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TreeList_DanhSachMenu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.appMenuBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 40);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.gridControl_DanhSachUser);
            this.splitContainerControl1.Panel1.Controls.Add(this.txtBlackHole);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.TreeList_DanhSachMenu);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(913, 375);
            this.splitContainerControl1.SplitterPosition = 365;
            this.splitContainerControl1.TabIndex = 0;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // gridControl_DanhSachUser
            // 
            this.gridControl_DanhSachUser.DataSource = this.appusersBindingSource;
            this.gridControl_DanhSachUser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl_DanhSachUser.Location = new System.Drawing.Point(0, 0);
            this.gridControl_DanhSachUser.MainView = this.gridView_DanhSachUser;
            this.gridControl_DanhSachUser.Name = "gridControl_DanhSachUser";
            this.gridControl_DanhSachUser.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.GridLookUpEditNhanVien});
            this.gridControl_DanhSachUser.Size = new System.Drawing.Size(365, 375);
            this.gridControl_DanhSachUser.TabIndex = 0;
            this.gridControl_DanhSachUser.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView_DanhSachUser});
            // 
            // appusersBindingSource
            // 
            this.appusersBindingSource.DataSource = typeof(PSC_ERP_Business.Main.Model.app_users);
            this.appusersBindingSource.CurrentChanged += new System.EventHandler(this.appusersBindingSource_CurrentChanged);
            // 
            // gridView_DanhSachUser
            // 
            this.gridView_DanhSachUser.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colTenDangNhap,
            this.colMatKhau,
            this.colMaNhanVien});
            this.gridView_DanhSachUser.GridControl = this.gridControl_DanhSachUser;
            this.gridView_DanhSachUser.GroupPanelText = "Danh sách người dùng";
            this.gridView_DanhSachUser.Name = "gridView_DanhSachUser";
            this.gridView_DanhSachUser.OptionsView.ShowAutoFilterRow = true;
            this.gridView_DanhSachUser.OptionsView.ShowGroupPanel = false;
            // 
            // colTenDangNhap
            // 
            this.colTenDangNhap.AppearanceCell.Options.UseTextOptions = true;
            this.colTenDangNhap.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colTenDangNhap.Caption = "Tên đăng nhập";
            this.colTenDangNhap.FieldName = "TenDangNhap";
            this.colTenDangNhap.MaxWidth = 130;
            this.colTenDangNhap.Name = "colTenDangNhap";
            this.colTenDangNhap.OptionsColumn.ReadOnly = true;
            this.colTenDangNhap.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colTenDangNhap.Visible = true;
            this.colTenDangNhap.VisibleIndex = 0;
            // 
            // colMatKhau
            // 
            this.colMatKhau.AppearanceCell.Options.UseTextOptions = true;
            this.colMatKhau.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colMatKhau.AppearanceHeader.Options.UseTextOptions = true;
            this.colMatKhau.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colMatKhau.Caption = "Mật khẩu";
            this.colMatKhau.FieldName = "MatKhau";
            this.colMatKhau.Name = "colMatKhau";
            this.colMatKhau.OptionsColumn.ReadOnly = true;
            // 
            // colMaNhanVien
            // 
            this.colMaNhanVien.AppearanceHeader.Options.UseTextOptions = true;
            this.colMaNhanVien.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colMaNhanVien.Caption = "Tên nhân viên";
            this.colMaNhanVien.FieldName = "NguoiLap_Ten";
            this.colMaNhanVien.Name = "colMaNhanVien";
            this.colMaNhanVien.OptionsColumn.ReadOnly = true;
            this.colMaNhanVien.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colMaNhanVien.Visible = true;
            this.colMaNhanVien.VisibleIndex = 1;
            // 
            // GridLookUpEditNhanVien
            // 
            this.GridLookUpEditNhanVien.AutoHeight = false;
            this.GridLookUpEditNhanVien.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.GridLookUpEditNhanVien.DataSource = this.tblnsNhanVienBindingSource;
            this.GridLookUpEditNhanVien.DisplayMember = "TenNhanVien";
            this.GridLookUpEditNhanVien.Name = "GridLookUpEditNhanVien";
            this.GridLookUpEditNhanVien.ValueMember = "MaNhanVien";
            this.GridLookUpEditNhanVien.View = this.GridLookUpEditViewNhanVien;
            // 
            // GridLookUpEditViewNhanVien
            // 
            this.GridLookUpEditViewNhanVien.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colMaQLNhanVien,
            this.colTenNhanVien});
            this.GridLookUpEditViewNhanVien.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.GridLookUpEditViewNhanVien.Name = "GridLookUpEditViewNhanVien";
            this.GridLookUpEditViewNhanVien.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.GridLookUpEditViewNhanVien.OptionsView.ShowGroupPanel = false;
            // 
            // colMaQLNhanVien
            // 
            this.colMaQLNhanVien.Caption = "Mã nhân viên";
            this.colMaQLNhanVien.FieldName = "MaQLNhanVien";
            this.colMaQLNhanVien.Name = "colMaQLNhanVien";
            this.colMaQLNhanVien.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colMaQLNhanVien.Visible = true;
            this.colMaQLNhanVien.VisibleIndex = 0;
            // 
            // colTenNhanVien
            // 
            this.colTenNhanVien.Caption = "Tên nhân viên";
            this.colTenNhanVien.FieldName = "TenNhanVien";
            this.colTenNhanVien.Name = "colTenNhanVien";
            this.colTenNhanVien.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colTenNhanVien.Visible = true;
            this.colTenNhanVien.VisibleIndex = 1;
            // 
            // txtBlackHole
            // 
            this.txtBlackHole.Location = new System.Drawing.Point(229, 11);
            this.txtBlackHole.MenuManager = this.mainMenuBarManager;
            this.txtBlackHole.Name = "txtBlackHole";
            this.txtBlackHole.Size = new System.Drawing.Size(100, 20);
            this.txtBlackHole.TabIndex = 1;
            // 
            // mainMenuBarManager
            // 
            this.mainMenuBarManager.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar4});
            this.mainMenuBarManager.DockControls.Add(this.barDockControlTop);
            this.mainMenuBarManager.DockControls.Add(this.barDockControlBottom);
            this.mainMenuBarManager.DockControls.Add(this.barDockControlLeft);
            this.mainMenuBarManager.DockControls.Add(this.barDockControl1);
            this.mainMenuBarManager.Form = this;
            this.mainMenuBarManager.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.btnThemMoi,
            this.btnLuu,
            this.btnThoat});
            this.mainMenuBarManager.MainMenu = this.bar4;
            this.mainMenuBarManager.MaxItemId = 9;
            // 
            // bar4
            // 
            this.bar4.BarName = "Main menu";
            this.bar4.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Top;
            this.bar4.DockCol = 0;
            this.bar4.DockRow = 0;
            this.bar4.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar4.FloatLocation = new System.Drawing.Point(646, 346);
            this.bar4.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnLuu, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnThoat, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)});
            this.bar4.OptionsBar.MultiLine = true;
            this.bar4.OptionsBar.UseWholeRow = true;
            this.bar4.Text = "Main menu";
            // 
            // btnLuu
            // 
            this.btnLuu.Caption = "Lưu";
            this.btnLuu.Glyph = ((System.Drawing.Image)(resources.GetObject("btnLuu.Glyph")));
            this.btnLuu.Id = 3;
            this.btnLuu.ItemShortcut = new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S));
            this.btnLuu.Name = "btnLuu";
            toolTipTitleItem1.Text = "Ctrl+S";
            superToolTip1.Items.Add(toolTipTitleItem1);
            this.btnLuu.SuperTip = superToolTip1;
            this.btnLuu.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnLuu_ItemClick);
            // 
            // btnThoat
            // 
            this.btnThoat.Caption = "Thoát";
            this.btnThoat.Glyph = ((System.Drawing.Image)(resources.GetObject("btnThoat.Glyph")));
            this.btnThoat.Id = 6;
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
            this.barDockControlTop.Size = new System.Drawing.Size(913, 40);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 415);
            this.barDockControlBottom.Size = new System.Drawing.Size(913, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 40);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 375);
            // 
            // barDockControl1
            // 
            this.barDockControl1.CausesValidation = false;
            this.barDockControl1.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControl1.Location = new System.Drawing.Point(913, 40);
            this.barDockControl1.Size = new System.Drawing.Size(0, 375);
            // 
            // btnThemMoi
            // 
            this.btnThemMoi.Caption = "Thêm mới";
            this.btnThemMoi.Id = 0;
            this.btnThemMoi.ImageIndex = 0;
            this.btnThemMoi.ItemShortcut = new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N));
            this.btnThemMoi.Name = "btnThemMoi";
            // 
            // TreeList_DanhSachMenu
            // 
            this.TreeList_DanhSachMenu.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.colTitle,
            this.colMaPhanHeQL,
            this.colChon,
            this.colThem,
            this.colSua,
            this.colXoa});
            this.TreeList_DanhSachMenu.CustomizationFormBounds = new System.Drawing.Rectangle(954, 424, 216, 209);
            this.TreeList_DanhSachMenu.DataSource = this.appMenuBindingSource;
            this.TreeList_DanhSachMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TreeList_DanhSachMenu.Location = new System.Drawing.Point(0, 0);
            this.TreeList_DanhSachMenu.Name = "TreeList_DanhSachMenu";
            this.TreeList_DanhSachMenu.OptionsBehavior.PopulateServiceColumns = true;
            this.TreeList_DanhSachMenu.Size = new System.Drawing.Size(543, 375);
            this.TreeList_DanhSachMenu.TabIndex = 1;
            this.TreeList_DanhSachMenu.CellValueChanging += new DevExpress.XtraTreeList.CellValueChangedEventHandler(this.TreeList_DanhSachMenu_CellValueChanging);
            this.TreeList_DanhSachMenu.CellValueChanged += new DevExpress.XtraTreeList.CellValueChangedEventHandler(this.TreeList_DanhSachMenu_CellValueChanged);
            // 
            // colTitle
            // 
            this.colTitle.AppearanceHeader.Options.UseTextOptions = true;
            this.colTitle.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colTitle.Caption = "Tiêu đề";
            this.colTitle.FieldName = "Title";
            this.colTitle.Name = "colTitle";
            this.colTitle.OptionsColumn.AllowFocus = false;
            this.colTitle.Visible = true;
            this.colTitle.VisibleIndex = 0;
            this.colTitle.Width = 334;
            // 
            // colMaPhanHeQL
            // 
            this.colMaPhanHeQL.AppearanceCell.Options.UseTextOptions = true;
            this.colMaPhanHeQL.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colMaPhanHeQL.AppearanceHeader.Options.UseTextOptions = true;
            this.colMaPhanHeQL.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colMaPhanHeQL.Caption = "Mã phân hệ";
            this.colMaPhanHeQL.FieldName = "MaPhanHeQL";
            this.colMaPhanHeQL.Name = "colMaPhanHeQL";
            this.colMaPhanHeQL.OptionsColumn.AllowFocus = false;
            this.colMaPhanHeQL.Width = 30;
            // 
            // colChon
            // 
            this.colChon.AppearanceCell.Options.UseTextOptions = true;
            this.colChon.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colChon.AppearanceHeader.Options.UseTextOptions = true;
            this.colChon.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colChon.Caption = "Chọn";
            this.colChon.FieldName = "Chon";
            this.colChon.Name = "colChon";
            this.colChon.OptionsFilter.AutoFilterCondition = DevExpress.XtraTreeList.Columns.AutoFilterCondition.Contains;
            this.colChon.OptionsFilter.ShowEmptyDateFilter = true;
            this.colChon.Visible = true;
            this.colChon.VisibleIndex = 1;
            this.colChon.Width = 57;
            // 
            // colThem
            // 
            this.colThem.Caption = "Thêm";
            this.colThem.FieldName = "Them";
            this.colThem.Name = "colThem";
            this.colThem.Visible = true;
            this.colThem.VisibleIndex = 2;
            this.colThem.Width = 54;
            // 
            // colSua
            // 
            this.colSua.Caption = "Sửa";
            this.colSua.FieldName = "Sua";
            this.colSua.Name = "colSua";
            this.colSua.Visible = true;
            this.colSua.VisibleIndex = 3;
            this.colSua.Width = 45;
            // 
            // colXoa
            // 
            this.colXoa.Caption = "Xóa";
            this.colXoa.FieldName = "Xoa";
            this.colXoa.Name = "colXoa";
            this.colXoa.Visible = true;
            this.colXoa.VisibleIndex = 4;
            this.colXoa.Width = 35;
            // 
            // appMenuBindingSource
            // 
            this.appMenuBindingSource.DataSource = typeof(PSC_ERP_Business.Main.Model.AppMenu);
            // 
            // mainMenuBar
            // 
            this.mainMenuBar.BarName = "Main menu";
            this.mainMenuBar.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Top;
            this.mainMenuBar.DockCol = 0;
            this.mainMenuBar.DockRow = 0;
            this.mainMenuBar.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.mainMenuBar.FloatLocation = new System.Drawing.Point(668, 233);
            this.mainMenuBar.OptionsBar.MultiLine = true;
            this.mainMenuBar.OptionsBar.UseWholeRow = true;
            this.mainMenuBar.Text = "Main menu";
            // 
            // bar1
            // 
            this.bar1.BarName = "Main menu";
            this.bar1.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Top;
            this.bar1.DockCol = 0;
            this.bar1.DockRow = 0;
            this.bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar1.FloatLocation = new System.Drawing.Point(668, 233);
            this.bar1.OptionsBar.MultiLine = true;
            this.bar1.OptionsBar.UseWholeRow = true;
            this.bar1.Text = "Main menu";
            // 
            // bar2
            // 
            this.bar2.BarName = "Main menu";
            this.bar2.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Top;
            this.bar2.DockCol = 0;
            this.bar2.DockRow = 0;
            this.bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar2.FloatLocation = new System.Drawing.Point(668, 233);
            this.bar2.OptionsBar.MultiLine = true;
            this.bar2.OptionsBar.UseWholeRow = true;
            this.bar2.Text = "Main menu";
            // 
            // bar3
            // 
            this.bar3.BarName = "Main menu";
            this.bar3.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Top;
            this.bar3.DockCol = 0;
            this.bar3.DockRow = 0;
            this.bar3.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar3.FloatLocation = new System.Drawing.Point(668, 233);
            this.bar3.OptionsBar.MultiLine = true;
            this.bar3.OptionsBar.UseWholeRow = true;
            this.bar3.Text = "Main menu";
            // 
            // frmGrant
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(913, 415);
            this.Controls.Add(this.splitContainerControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControl1);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "frmGrant";
            this.Text = "Cấp quyền ";
            this.Load += new System.EventHandler(this.frmGrant_Load);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_DanhSachUser)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.appusersBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_DanhSachUser)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridLookUpEditNhanVien)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblnsNhanVienBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridLookUpEditViewNhanVien)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBlackHole.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mainMenuBarManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TreeList_DanhSachMenu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.appMenuBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraGrid.GridControl gridControl_DanhSachUser;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView_DanhSachUser;
        private DevExpress.XtraBars.Bar mainMenuBar;
        private DevExpress.XtraBars.Bar bar1;
        private DevExpress.XtraBars.Bar bar2;
        private DevExpress.XtraBars.Bar bar3;
        private DevExpress.XtraBars.BarManager mainMenuBarManager;
        private DevExpress.XtraBars.Bar bar4;
        private DevExpress.XtraBars.BarButtonItem btnThemMoi;
        private DevExpress.XtraBars.BarButtonItem btnLuu;
        private DevExpress.XtraBars.BarButtonItem btnThoat;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControl1;
        private System.Windows.Forms.BindingSource appusersBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colTenDangNhap;
        private DevExpress.XtraGrid.Columns.GridColumn colMaNhanVien;
        private DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit GridLookUpEditNhanVien;
        private System.Windows.Forms.BindingSource tblnsNhanVienBindingSource;
        private DevExpress.XtraGrid.Views.Grid.GridView GridLookUpEditViewNhanVien;
        private DevExpress.XtraGrid.Columns.GridColumn colMaQLNhanVien;
        private DevExpress.XtraGrid.Columns.GridColumn colTenNhanVien;
        private DevExpress.XtraTreeList.TreeList TreeList_DanhSachMenu;
        private System.Windows.Forms.BindingSource appMenuBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colMatKhau;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colTitle;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colMaPhanHeQL;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colChon;
        private DevExpress.XtraEditors.TextEdit txtBlackHole;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colThem;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colSua;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colXoa;
    }
}