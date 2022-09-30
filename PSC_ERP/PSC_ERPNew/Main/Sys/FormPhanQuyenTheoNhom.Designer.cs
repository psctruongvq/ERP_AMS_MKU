namespace PSC_ERPNew.Main.Sys
{
    partial class FormPhanQuyenTheoNhom
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormPhanQuyenTheoNhom));
            DevExpress.Utils.SuperToolTip superToolTip1 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem1 = new DevExpress.Utils.ToolTipTitleItem();
            DevExpress.Utils.SuperToolTip superToolTip2 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem2 = new DevExpress.Utils.ToolTipTitleItem();
            this.mainMenuBarManager = new DevExpress.XtraBars.BarManager(this.components);
            this.bar4 = new DevExpress.XtraBars.Bar();
            this.btnLuu = new DevExpress.XtraBars.BarButtonItem();
            this.btnThoat = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControl1 = new DevExpress.XtraBars.BarDockControl();
            this.btnThemMoi = new DevExpress.XtraBars.BarButtonItem();
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.gridControl_DanhSachUser = new DevExpress.XtraGrid.GridControl();
            this.bding_Group = new System.Windows.Forms.BindingSource(this.components);
            this.gridView_DanhSachUser = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colMatKhau = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMaNhanVien = new DevExpress.XtraGrid.Columns.GridColumn();
            this.GridLookUpEditNhanVien = new DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit();
            this.GridLookUpEditViewNhanVien = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colMaQLNhanVien = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTenNhanVien = new DevExpress.XtraGrid.Columns.GridColumn();
            this.txtBlackHole = new DevExpress.XtraEditors.TextEdit();
            this.TreeList_DanhSachMenu = new DevExpress.XtraTreeList.TreeList();
            this.colTitle = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colMaPhanHeQL = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colChon = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colThem = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colSua = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colXoa = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeListColumn1 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeListColumn2 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.bding_appMenuList = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.mainMenuBarManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_DanhSachUser)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bding_Group)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_DanhSachUser)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridLookUpEditNhanVien)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridLookUpEditViewNhanVien)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBlackHole.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TreeList_DanhSachMenu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bding_appMenuList)).BeginInit();
            this.SuspendLayout();
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
            this.btnLuu.Id = 3;
            this.btnLuu.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnLuu.ImageOptions.Image")));
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
            this.btnThoat.Id = 6;
            this.btnThoat.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnThoat.ImageOptions.Image")));
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
            this.barDockControlTop.Manager = this.mainMenuBarManager;
            this.barDockControlTop.Size = new System.Drawing.Size(1442, 40);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 435);
            this.barDockControlBottom.Manager = this.mainMenuBarManager;
            this.barDockControlBottom.Size = new System.Drawing.Size(1442, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 40);
            this.barDockControlLeft.Manager = this.mainMenuBarManager;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 395);
            // 
            // barDockControl1
            // 
            this.barDockControl1.CausesValidation = false;
            this.barDockControl1.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControl1.Location = new System.Drawing.Point(1442, 40);
            this.barDockControl1.Manager = this.mainMenuBarManager;
            this.barDockControl1.Size = new System.Drawing.Size(0, 395);
            // 
            // btnThemMoi
            // 
            this.btnThemMoi.Caption = "Thêm mới";
            this.btnThemMoi.Id = 0;
            this.btnThemMoi.ImageOptions.ImageIndex = 0;
            this.btnThemMoi.ItemShortcut = new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N));
            this.btnThemMoi.Name = "btnThemMoi";
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
            this.splitContainerControl1.Size = new System.Drawing.Size(1442, 395);
            this.splitContainerControl1.SplitterPosition = 380;
            this.splitContainerControl1.TabIndex = 4;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // gridControl_DanhSachUser
            // 
            this.gridControl_DanhSachUser.DataSource = this.bding_Group;
            this.gridControl_DanhSachUser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl_DanhSachUser.Location = new System.Drawing.Point(0, 0);
            this.gridControl_DanhSachUser.MainView = this.gridView_DanhSachUser;
            this.gridControl_DanhSachUser.Name = "gridControl_DanhSachUser";
            this.gridControl_DanhSachUser.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.GridLookUpEditNhanVien});
            this.gridControl_DanhSachUser.Size = new System.Drawing.Size(380, 395);
            this.gridControl_DanhSachUser.TabIndex = 0;
            this.gridControl_DanhSachUser.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView_DanhSachUser});
            // 
            // bding_Group
            // 
            this.bding_Group.PositionChanged += new System.EventHandler(this.bding_Group_PositionChanged);
            // 
            // gridView_DanhSachUser
            // 
            this.gridView_DanhSachUser.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colMatKhau,
            this.colMaNhanVien});
            this.gridView_DanhSachUser.GridControl = this.gridControl_DanhSachUser;
            this.gridView_DanhSachUser.GroupPanelText = "Danh sách người dùng";
            this.gridView_DanhSachUser.Name = "gridView_DanhSachUser";
            this.gridView_DanhSachUser.OptionsDetail.EnableMasterViewMode = false;
            this.gridView_DanhSachUser.OptionsView.ShowAutoFilterRow = true;
            this.gridView_DanhSachUser.OptionsView.ShowGroupPanel = false;
            // 
            // colMatKhau
            // 
            this.colMatKhau.AppearanceCell.Options.UseTextOptions = true;
            this.colMatKhau.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colMatKhau.AppearanceHeader.Options.UseTextOptions = true;
            this.colMatKhau.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colMatKhau.Caption = "GroupID";
            this.colMatKhau.FieldName = "GroupID";
            this.colMatKhau.Name = "colMatKhau";
            // 
            // colMaNhanVien
            // 
            this.colMaNhanVien.AppearanceHeader.Options.UseTextOptions = true;
            this.colMaNhanVien.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colMaNhanVien.Caption = "Tên nhóm";
            this.colMaNhanVien.FieldName = "TenChucNang";
            this.colMaNhanVien.Name = "colMaNhanVien";
            this.colMaNhanVien.OptionsColumn.ReadOnly = true;
            this.colMaNhanVien.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colMaNhanVien.Visible = true;
            this.colMaNhanVien.VisibleIndex = 0;
            // 
            // GridLookUpEditNhanVien
            // 
            this.GridLookUpEditNhanVien.AutoHeight = false;
            this.GridLookUpEditNhanVien.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
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
            // TreeList_DanhSachMenu
            // 
            this.TreeList_DanhSachMenu.Appearance.OddRow.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.TreeList_DanhSachMenu.Appearance.OddRow.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.TreeList_DanhSachMenu.Appearance.OddRow.Options.UseBackColor = true;
            this.TreeList_DanhSachMenu.Appearance.TreeLine.BackColor = System.Drawing.Color.DarkBlue;
            this.TreeList_DanhSachMenu.Appearance.TreeLine.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.TreeList_DanhSachMenu.Appearance.TreeLine.Options.UseBackColor = true;
            this.TreeList_DanhSachMenu.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.colTitle,
            this.colMaPhanHeQL,
            this.colChon,
            this.colThem,
            this.colSua,
            this.colXoa,
            this.treeListColumn1,
            this.treeListColumn2});
            this.TreeList_DanhSachMenu.Cursor = System.Windows.Forms.Cursors.Default;
            this.TreeList_DanhSachMenu.CustomizationFormBounds = new System.Drawing.Rectangle(954, 424, 216, 209);
            this.TreeList_DanhSachMenu.DataSource = this.bding_appMenuList;
            this.TreeList_DanhSachMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TreeList_DanhSachMenu.Location = new System.Drawing.Point(0, 0);
            this.TreeList_DanhSachMenu.Name = "TreeList_DanhSachMenu";
            this.TreeList_DanhSachMenu.OptionsBehavior.PopulateServiceColumns = true;
            this.TreeList_DanhSachMenu.OptionsView.EnableAppearanceOddRow = true;
            this.TreeList_DanhSachMenu.Size = new System.Drawing.Size(1057, 395);
            this.TreeList_DanhSachMenu.TabIndex = 1;
            this.TreeList_DanhSachMenu.CellValueChanging += new DevExpress.XtraTreeList.CellValueChangedEventHandler(this.TreeList_DanhSachMenu_CellValueChanging);
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
            this.colChon.Caption = "Xem";
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
            this.colThem.AppearanceCell.Options.UseTextOptions = true;
            this.colThem.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colThem.AppearanceHeader.Options.UseTextOptions = true;
            this.colThem.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colThem.Caption = "Thêm";
            this.colThem.FieldName = "Them";
            this.colThem.Name = "colThem";
            this.colThem.Visible = true;
            this.colThem.VisibleIndex = 2;
            this.colThem.Width = 54;
            // 
            // colSua
            // 
            this.colSua.AppearanceCell.Options.UseTextOptions = true;
            this.colSua.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colSua.AppearanceHeader.Options.UseTextOptions = true;
            this.colSua.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colSua.Caption = "Sửa";
            this.colSua.FieldName = "Sua";
            this.colSua.Name = "colSua";
            this.colSua.Visible = true;
            this.colSua.VisibleIndex = 3;
            this.colSua.Width = 45;
            // 
            // colXoa
            // 
            this.colXoa.AppearanceCell.Options.UseTextOptions = true;
            this.colXoa.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colXoa.AppearanceHeader.Options.UseTextOptions = true;
            this.colXoa.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colXoa.Caption = "Xóa";
            this.colXoa.FieldName = "Xoa";
            this.colXoa.Name = "colXoa";
            this.colXoa.Visible = true;
            this.colXoa.VisibleIndex = 4;
            this.colXoa.Width = 35;
            // 
            // treeListColumn1
            // 
            this.treeListColumn1.Caption = "IDMenu";
            this.treeListColumn1.FieldName = "MenuID";
            this.treeListColumn1.Name = "treeListColumn1";
            // 
            // treeListColumn2
            // 
            this.treeListColumn2.Caption = "IDGroup";
            this.treeListColumn2.FieldName = "GroupID";
            this.treeListColumn2.Name = "treeListColumn2";
            // 
            // bding_appMenuList
            // 
            this.bding_appMenuList.DataSource = typeof(ERP_Library.AppMenuGroupList);
            // 
            // FormPhanQuyenTheoNhom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1442, 435);
            this.Controls.Add(this.splitContainerControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControl1);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "FormPhanQuyenTheoNhom";
            this.Text = "PHÂN QUYỀN NHÓM";
            this.Load += new System.EventHandler(this.frmGrantGroup_Load);
            ((System.ComponentModel.ISupportInitialize)(this.mainMenuBarManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_DanhSachUser)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bding_Group)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_DanhSachUser)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridLookUpEditNhanVien)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridLookUpEditViewNhanVien)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBlackHole.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TreeList_DanhSachMenu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bding_appMenuList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.BarManager mainMenuBarManager;
        private DevExpress.XtraBars.Bar bar4;
        private DevExpress.XtraBars.BarButtonItem btnLuu;
        private DevExpress.XtraBars.BarButtonItem btnThoat;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControl1;
        private DevExpress.XtraBars.BarButtonItem btnThemMoi;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraGrid.GridControl gridControl_DanhSachUser;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView_DanhSachUser;
        private DevExpress.XtraGrid.Columns.GridColumn colMatKhau;
        private DevExpress.XtraGrid.Columns.GridColumn colMaNhanVien;
        private DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit GridLookUpEditNhanVien;
        private DevExpress.XtraGrid.Views.Grid.GridView GridLookUpEditViewNhanVien;
        private DevExpress.XtraGrid.Columns.GridColumn colMaQLNhanVien;
        private DevExpress.XtraGrid.Columns.GridColumn colTenNhanVien;
        private DevExpress.XtraEditors.TextEdit txtBlackHole;
        private DevExpress.XtraTreeList.TreeList TreeList_DanhSachMenu;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colTitle;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colMaPhanHeQL;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colChon;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colThem;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colSua;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colXoa;
        private System.Windows.Forms.BindingSource bding_appMenuList;
        private System.Windows.Forms.BindingSource bding_Group;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn1;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn2;
    }
}