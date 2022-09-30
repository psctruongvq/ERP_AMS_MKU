using System;
namespace PSC_ERPNew.Main.Sys
{
    partial class frmMenuAndFunctionManager
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMenuAndFunctionManager));
            DevExpress.Utils.SuperToolTip superToolTip1 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem1 = new DevExpress.Utils.ToolTipTitleItem();
            DevExpress.Utils.SuperToolTip superToolTip2 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem2 = new DevExpress.Utils.ToolTipTitleItem();
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.txtFilterTree = new DevExpress.XtraEditors.TextEdit();
            this.treeMenu = new DevExpress.XtraTreeList.TreeList();
            this.colTitle = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.repositoryItemMemoEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
            this.colMenuImage = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.repositoryItemPictureEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit();
            this.colFunctionImage = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colShortKey = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colMaPhanHeQL = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colId = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colVisible = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colParentId = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colDescription = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colType = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colEnable = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colFunctionID = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colLocalIdx = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colGlobalIdx = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colFunction = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colMenu1 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colMenu2 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.cmsMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.btnThemMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.btnThemPhanHe = new System.Windows.Forms.ToolStripMenuItem();
            this.btnThemRibbon = new System.Windows.Forms.ToolStripMenuItem();
            this.btnThemRibbonPageCategory = new System.Windows.Forms.ToolStripMenuItem();
            this.btnThemRibbonPage = new System.Windows.Forms.ToolStripMenuItem();
            this.btnThemRibbonPageGroup = new System.Windows.Forms.ToolStripMenuItem();
            this.btnThemBarButtonGroup = new System.Windows.Forms.ToolStripMenuItem();
            this.btnThemBarSubItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnThemNavBarControl = new System.Windows.Forms.ToolStripMenuItem();
            this.btnThemNavBarGroup = new System.Windows.Forms.ToolStripMenuItem();
            this.btnThemNavBarItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnXoaMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.AppMenuBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.groupDetailMenu = new DevExpress.XtraEditors.GroupControl();
            this.btnMoveDownMenu = new DevExpress.XtraEditors.SimpleButton();
            this.btnMoveUpMenu = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txtThuocPhanHe = new DevExpress.XtraEditors.TextEdit();
            this.txtBlackHole = new System.Windows.Forms.TextBox();
            this.gridCtrlFunction = new DevExpress.XtraGrid.GridControl();
            this.AppFunctionBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridViewFunction = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colFunctionName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemMemoEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
            this.colNamespaceAndClassName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemSearchLookUpEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit();
            this.formTypeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.colImage1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemPictureEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit();
            this.colPublicInitInstanceMethod = new DevExpress.XtraGrid.Columns.GridColumn();
            this.groupDetailFunction = new DevExpress.XtraEditors.GroupControl();
            this.btnMoveDownFunction = new DevExpress.XtraEditors.SimpleButton();
            this.btnMoveUpFunction = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.txtSingletonPropertyName = new DevExpress.XtraEditors.TextEdit();
            this.functionPicture = new DevExpress.XtraEditors.PictureEdit();
            this.chkIsMdiChild = new DevExpress.XtraEditors.CheckEdit();
            this.chkIsMdiContainer = new DevExpress.XtraEditors.CheckEdit();
            this.chkIsShowDialog = new DevExpress.XtraEditors.CheckEdit();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar1 = new DevExpress.XtraBars.Bar();
            this.btnSave = new DevExpress.XtraBars.BarButtonItem();
            this.btnThoat = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.imageListForToolbar = new System.Windows.Forms.ImageList(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtFilterTree.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.treeMenu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemPictureEdit1)).BeginInit();
            this.cmsMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AppMenuBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupDetailMenu)).BeginInit();
            this.groupDetailMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtThuocPhanHe.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridCtrlFunction)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AppFunctionBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewFunction)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSearchLookUpEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.formTypeBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemPictureEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupDetailFunction)).BeginInit();
            this.groupDetailFunction.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSingletonPropertyName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.functionPicture.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkIsMdiChild.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkIsMdiContainer.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkIsShowDialog.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 47);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.txtFilterTree);
            this.splitContainerControl1.Panel1.Controls.Add(this.treeMenu);
            this.splitContainerControl1.Panel1.Controls.Add(this.groupDetailMenu);
            this.splitContainerControl1.Panel1.Controls.Add(this.txtBlackHole);
            this.splitContainerControl1.Panel1.Text = "Panel Menu";
            this.splitContainerControl1.Panel2.Controls.Add(this.gridCtrlFunction);
            this.splitContainerControl1.Panel2.Controls.Add(this.groupDetailFunction);
            this.splitContainerControl1.Panel2.Text = "Panel Function";
            this.splitContainerControl1.Size = new System.Drawing.Size(1105, 449);
            this.splitContainerControl1.SplitterPosition = 542;
            this.splitContainerControl1.TabIndex = 3;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // txtFilterTree
            // 
            this.txtFilterTree.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFilterTree.Location = new System.Drawing.Point(16, 144);
            this.txtFilterTree.Name = "txtFilterTree";
            this.txtFilterTree.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 13F);
            this.txtFilterTree.Properties.Appearance.Options.UseFont = true;
            this.txtFilterTree.Size = new System.Drawing.Size(508, 28);
            this.txtFilterTree.TabIndex = 5;
            this.txtFilterTree.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtFilterTree_KeyDown);
            // 
            // treeMenu
            // 
            this.treeMenu.AllowDrop = true;
            this.treeMenu.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.colTitle,
            this.colMenuImage,
            this.colFunctionImage,
            this.colShortKey,
            this.colMaPhanHeQL,
            this.colId,
            this.colVisible,
            this.colParentId,
            this.colDescription,
            this.colType,
            this.colEnable,
            this.colFunctionID,
            this.colLocalIdx,
            this.colGlobalIdx,
            this.colFunction,
            this.colMenu1,
            this.colMenu2});
            this.treeMenu.ContextMenuStrip = this.cmsMenu;
            this.treeMenu.CustomizationFormBounds = new System.Drawing.Rectangle(795, 306, 216, 183);
            this.treeMenu.DataSource = this.AppMenuBindingSource;
            this.treeMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeMenu.Location = new System.Drawing.Point(0, 123);
            this.treeMenu.Name = "treeMenu";
            this.treeMenu.OptionsBehavior.PopulateServiceColumns = true;
            this.treeMenu.OptionsDragAndDrop.DragNodesMode = DevExpress.XtraTreeList.DragNodesMode.Single;
            this.treeMenu.OptionsView.ShowAutoFilterRow = true;
            this.treeMenu.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemPictureEdit1,
            this.repositoryItemMemoEdit2});
            this.treeMenu.Size = new System.Drawing.Size(542, 326);
            this.treeMenu.TabIndex = 2;
            this.treeMenu.GetStateImage += new DevExpress.XtraTreeList.GetStateImageEventHandler(this.treeMenu_GetStateImage);
            this.treeMenu.AfterFocusNode += new DevExpress.XtraTreeList.NodeEventHandler(this.treeMenu_AfterFocusNode);
            this.treeMenu.DragDrop += new System.Windows.Forms.DragEventHandler(this.treeMenu_DragDrop);
            this.treeMenu.DragOver += new System.Windows.Forms.DragEventHandler(this.treeMenu_DragOver);
            this.treeMenu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.treeMenu_KeyDown);
            this.treeMenu.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.treeMenu_KeyPress);
            this.treeMenu.MouseDown += new System.Windows.Forms.MouseEventHandler(this.treeMenu_MouseDown);
            this.treeMenu.MouseUp += new System.Windows.Forms.MouseEventHandler(this.treeMenu_MouseUp);
            // 
            // colTitle
            // 
            this.colTitle.ColumnEdit = this.repositoryItemMemoEdit2;
            this.colTitle.FieldName = "Title";
            this.colTitle.MinWidth = 49;
            this.colTitle.Name = "colTitle";
            this.colTitle.Visible = true;
            this.colTitle.VisibleIndex = 1;
            this.colTitle.Width = 248;
            // 
            // repositoryItemMemoEdit2
            // 
            this.repositoryItemMemoEdit2.Appearance.Options.UseTextOptions = true;
            this.repositoryItemMemoEdit2.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.repositoryItemMemoEdit2.Name = "repositoryItemMemoEdit2";
            // 
            // colMenuImage
            // 
            this.colMenuImage.Caption = "Menu Image";
            this.colMenuImage.ColumnEdit = this.repositoryItemPictureEdit1;
            this.colMenuImage.FieldName = "Image";
            this.colMenuImage.Name = "colMenuImage";
            this.colMenuImage.Visible = true;
            this.colMenuImage.VisibleIndex = 2;
            this.colMenuImage.Width = 192;
            // 
            // repositoryItemPictureEdit1
            // 
            this.repositoryItemPictureEdit1.CustomHeight = 16;
            this.repositoryItemPictureEdit1.Name = "repositoryItemPictureEdit1";
            this.repositoryItemPictureEdit1.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Squeeze;
            this.repositoryItemPictureEdit1.ZoomAccelerationFactor = 1D;
            // 
            // colFunctionImage
            // 
            this.colFunctionImage.Caption = "Funtion Image";
            this.colFunctionImage.ColumnEdit = this.repositoryItemPictureEdit1;
            this.colFunctionImage.FieldName = "AppFunction.Image";
            this.colFunctionImage.Name = "colFunctionImage";
            this.colFunctionImage.OptionsColumn.ReadOnly = true;
            this.colFunctionImage.Visible = true;
            this.colFunctionImage.VisibleIndex = 3;
            this.colFunctionImage.Width = 129;
            // 
            // colShortKey
            // 
            this.colShortKey.FieldName = "ShortKey";
            this.colShortKey.Name = "colShortKey";
            this.colShortKey.Width = 26;
            // 
            // colMaPhanHeQL
            // 
            this.colMaPhanHeQL.FieldName = "MaPhanHeQL";
            this.colMaPhanHeQL.Name = "colMaPhanHeQL";
            this.colMaPhanHeQL.Width = 67;
            // 
            // colId
            // 
            this.colId.FieldName = "Id";
            this.colId.Name = "colId";
            this.colId.Width = 59;
            // 
            // colVisible
            // 
            this.colVisible.FieldName = "Visible";
            this.colVisible.Name = "colVisible";
            this.colVisible.Width = 26;
            // 
            // colParentId
            // 
            this.colParentId.FieldName = "ParentID";
            this.colParentId.Name = "colParentId";
            this.colParentId.Width = 26;
            // 
            // colDescription
            // 
            this.colDescription.FieldName = "Description";
            this.colDescription.Name = "colDescription";
            this.colDescription.Width = 26;
            // 
            // colType
            // 
            this.colType.FieldName = "Type";
            this.colType.Name = "colType";
            this.colType.Width = 26;
            // 
            // colEnable
            // 
            this.colEnable.FieldName = "Enable";
            this.colEnable.Name = "colEnable";
            this.colEnable.Width = 26;
            // 
            // colFunctionID
            // 
            this.colFunctionID.FieldName = "FunctionID";
            this.colFunctionID.Name = "colFunctionID";
            this.colFunctionID.Width = 26;
            // 
            // colLocalIdx
            // 
            this.colLocalIdx.Caption = "STT";
            this.colLocalIdx.FieldName = "LocalIdx";
            this.colLocalIdx.MinWidth = 41;
            this.colLocalIdx.Name = "colLocalIdx";
            this.colLocalIdx.Visible = true;
            this.colLocalIdx.VisibleIndex = 0;
            this.colLocalIdx.Width = 49;
            // 
            // colGlobalIdx
            // 
            this.colGlobalIdx.FieldName = "GlobalIdx";
            this.colGlobalIdx.Name = "colGlobalIdx";
            this.colGlobalIdx.Width = 26;
            // 
            // colFunction
            // 
            this.colFunction.FieldName = "Function";
            this.colFunction.Name = "colFunction";
            this.colFunction.Width = 27;
            // 
            // colMenu1
            // 
            this.colMenu1.FieldName = "Menu1";
            this.colMenu1.Name = "colMenu1";
            this.colMenu1.Width = 27;
            // 
            // colMenu2
            // 
            this.colMenu2.FieldName = "Menu2";
            this.colMenu2.Name = "colMenu2";
            this.colMenu2.Width = 27;
            // 
            // cmsMenu
            // 
            this.cmsMenu.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.cmsMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnThemMenu,
            this.btnXoaMenu});
            this.cmsMenu.Name = "cmsMenu";
            this.cmsMenu.Size = new System.Drawing.Size(135, 52);
            this.cmsMenu.Opening += new System.ComponentModel.CancelEventHandler(this.cmsMenu_Opening);
            // 
            // btnThemMenu
            // 
            this.btnThemMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnThemPhanHe,
            this.btnThemRibbon,
            this.btnThemRibbonPageCategory,
            this.btnThemRibbonPage,
            this.btnThemRibbonPageGroup,
            this.btnThemBarButtonGroup,
            this.btnThemBarSubItem,
            this.btnThemNavBarControl,
            this.btnThemNavBarGroup,
            this.btnThemNavBarItem});
            this.btnThemMenu.Name = "btnThemMenu";
            this.btnThemMenu.Size = new System.Drawing.Size(134, 24);
            this.btnThemMenu.Text = "Thêm ...";
            this.btnThemMenu.Click += new System.EventHandler(this.btnThemMenu_Click);
            // 
            // btnThemPhanHe
            // 
            this.btnThemPhanHe.Image = ((System.Drawing.Image)(resources.GetObject("btnThemPhanHe.Image")));
            this.btnThemPhanHe.Name = "btnThemPhanHe";
            this.btnThemPhanHe.Size = new System.Drawing.Size(208, 24);
            this.btnThemPhanHe.Text = "Phân hệ";
            this.btnThemPhanHe.Click += new System.EventHandler(this.btnThemPhanHe_Click);
            // 
            // btnThemRibbon
            // 
            this.btnThemRibbon.Image = ((System.Drawing.Image)(resources.GetObject("btnThemRibbon.Image")));
            this.btnThemRibbon.Name = "btnThemRibbon";
            this.btnThemRibbon.Size = new System.Drawing.Size(208, 24);
            this.btnThemRibbon.Text = "Ribbon";
            this.btnThemRibbon.Click += new System.EventHandler(this.btnThemRibbon_Click);
            // 
            // btnThemRibbonPageCategory
            // 
            this.btnThemRibbonPageCategory.Image = ((System.Drawing.Image)(resources.GetObject("btnThemRibbonPageCategory.Image")));
            this.btnThemRibbonPageCategory.Name = "btnThemRibbonPageCategory";
            this.btnThemRibbonPageCategory.Size = new System.Drawing.Size(208, 24);
            this.btnThemRibbonPageCategory.Text = "RibbonPageCategory";
            this.btnThemRibbonPageCategory.Click += new System.EventHandler(this.btnThemRibbonPageCategory_Click);
            // 
            // btnThemRibbonPage
            // 
            this.btnThemRibbonPage.Image = ((System.Drawing.Image)(resources.GetObject("btnThemRibbonPage.Image")));
            this.btnThemRibbonPage.Name = "btnThemRibbonPage";
            this.btnThemRibbonPage.Size = new System.Drawing.Size(208, 24);
            this.btnThemRibbonPage.Text = "RibbonPage";
            this.btnThemRibbonPage.Click += new System.EventHandler(this.btnThemRibbonPage_Click);
            // 
            // btnThemRibbonPageGroup
            // 
            this.btnThemRibbonPageGroup.Image = ((System.Drawing.Image)(resources.GetObject("btnThemRibbonPageGroup.Image")));
            this.btnThemRibbonPageGroup.Name = "btnThemRibbonPageGroup";
            this.btnThemRibbonPageGroup.Size = new System.Drawing.Size(208, 24);
            this.btnThemRibbonPageGroup.Text = "RibbonPageGroup";
            this.btnThemRibbonPageGroup.Click += new System.EventHandler(this.btnThemRibbonPageGroup_Click);
            // 
            // btnThemBarButtonGroup
            // 
            this.btnThemBarButtonGroup.Image = ((System.Drawing.Image)(resources.GetObject("btnThemBarButtonGroup.Image")));
            this.btnThemBarButtonGroup.Name = "btnThemBarButtonGroup";
            this.btnThemBarButtonGroup.Size = new System.Drawing.Size(208, 24);
            this.btnThemBarButtonGroup.Text = "BarButtonGroup";
            this.btnThemBarButtonGroup.Click += new System.EventHandler(this.btnThemBarButtonGroup_Click);
            // 
            // btnThemBarSubItem
            // 
            this.btnThemBarSubItem.Image = ((System.Drawing.Image)(resources.GetObject("btnThemBarSubItem.Image")));
            this.btnThemBarSubItem.Name = "btnThemBarSubItem";
            this.btnThemBarSubItem.Size = new System.Drawing.Size(208, 24);
            this.btnThemBarSubItem.Text = "BarSubItem";
            this.btnThemBarSubItem.Click += new System.EventHandler(this.btnThemBarSubItem_Click);
            // 
            // btnThemNavBarControl
            // 
            this.btnThemNavBarControl.Name = "btnThemNavBarControl";
            this.btnThemNavBarControl.Size = new System.Drawing.Size(208, 24);
            this.btnThemNavBarControl.Text = "NavBarControl";
            // 
            // btnThemNavBarGroup
            // 
            this.btnThemNavBarGroup.Name = "btnThemNavBarGroup";
            this.btnThemNavBarGroup.Size = new System.Drawing.Size(208, 24);
            this.btnThemNavBarGroup.Text = "NavBarGroup";
            // 
            // btnThemNavBarItem
            // 
            this.btnThemNavBarItem.Name = "btnThemNavBarItem";
            this.btnThemNavBarItem.Size = new System.Drawing.Size(208, 24);
            this.btnThemNavBarItem.Text = "NavBarItem";
            // 
            // btnXoaMenu
            // 
            this.btnXoaMenu.Name = "btnXoaMenu";
            this.btnXoaMenu.ShortcutKeys = System.Windows.Forms.Keys.Delete;
            this.btnXoaMenu.Size = new System.Drawing.Size(134, 24);
            this.btnXoaMenu.Text = "Xóa";
            this.btnXoaMenu.Click += new System.EventHandler(this.btnXoaMenu_Click);
            // 
            // AppMenuBindingSource
            // 
            this.AppMenuBindingSource.DataSource = typeof(PSC_ERP_Business.Main.Model.AppMenu);
            // 
            // groupDetailMenu
            // 
            this.groupDetailMenu.Controls.Add(this.btnMoveDownMenu);
            this.groupDetailMenu.Controls.Add(this.btnMoveUpMenu);
            this.groupDetailMenu.Controls.Add(this.labelControl1);
            this.groupDetailMenu.Controls.Add(this.txtThuocPhanHe);
            this.groupDetailMenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupDetailMenu.Location = new System.Drawing.Point(0, 0);
            this.groupDetailMenu.Name = "groupDetailMenu";
            this.groupDetailMenu.Size = new System.Drawing.Size(542, 123);
            this.groupDetailMenu.TabIndex = 1;
            this.groupDetailMenu.Text = "Chi tiết menu";
            // 
            // btnMoveDownMenu
            // 
            this.btnMoveDownMenu.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnMoveDownMenu.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMoveDownMenu.Appearance.Options.UseFont = true;
            this.btnMoveDownMenu.Location = new System.Drawing.Point(488, 75);
            this.btnMoveDownMenu.Name = "btnMoveDownMenu";
            this.btnMoveDownMenu.Size = new System.Drawing.Size(47, 42);
            this.btnMoveDownMenu.TabIndex = 2;
            this.btnMoveDownMenu.Text = "Down";
            this.btnMoveDownMenu.Click += new System.EventHandler(this.btnMoveDownMenu_Click);
            // 
            // btnMoveUpMenu
            // 
            this.btnMoveUpMenu.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnMoveUpMenu.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMoveUpMenu.Appearance.Options.UseFont = true;
            this.btnMoveUpMenu.Location = new System.Drawing.Point(488, 25);
            this.btnMoveUpMenu.Name = "btnMoveUpMenu";
            this.btnMoveUpMenu.Size = new System.Drawing.Size(47, 42);
            this.btnMoveUpMenu.TabIndex = 2;
            this.btnMoveUpMenu.Text = "Up";
            this.btnMoveUpMenu.Click += new System.EventHandler(this.btnMoveUpMenu_Click);
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(12, 24);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(71, 13);
            this.labelControl1.TabIndex = 1;
            this.labelControl1.Text = "Thuộc phân hệ";
            // 
            // txtThuocPhanHe
            // 
            this.txtThuocPhanHe.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.AppMenuBindingSource, "MaPhanHeQL", true));
            this.txtThuocPhanHe.Location = new System.Drawing.Point(99, 21);
            this.txtThuocPhanHe.Name = "txtThuocPhanHe";
            this.txtThuocPhanHe.Size = new System.Drawing.Size(100, 20);
            this.txtThuocPhanHe.TabIndex = 0;
            // 
            // txtBlackHole
            // 
            this.txtBlackHole.Location = new System.Drawing.Point(212, 46);
            this.txtBlackHole.Name = "txtBlackHole";
            this.txtBlackHole.Size = new System.Drawing.Size(100, 21);
            this.txtBlackHole.TabIndex = 3;
            this.txtBlackHole.TabStop = false;
            // 
            // gridCtrlFunction
            // 
            this.gridCtrlFunction.AllowDrop = true;
            this.gridCtrlFunction.DataSource = this.AppFunctionBindingSource;
            this.gridCtrlFunction.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridCtrlFunction.Location = new System.Drawing.Point(0, 123);
            this.gridCtrlFunction.MainView = this.gridViewFunction;
            this.gridCtrlFunction.Name = "gridCtrlFunction";
            this.gridCtrlFunction.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemPictureEdit2,
            this.repositoryItemSearchLookUpEdit1,
            this.repositoryItemMemoEdit1});
            this.gridCtrlFunction.Size = new System.Drawing.Size(558, 326);
            this.gridCtrlFunction.TabIndex = 2;
            this.gridCtrlFunction.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewFunction});
            // 
            // AppFunctionBindingSource
            // 
            this.AppFunctionBindingSource.DataSource = typeof(PSC_ERP_Business.Main.Model.AppFunction);
            // 
            // gridViewFunction
            // 
            this.gridViewFunction.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colFunctionName,
            this.colNamespaceAndClassName,
            this.colImage1,
            this.colPublicInitInstanceMethod});
            this.gridViewFunction.GridControl = this.gridCtrlFunction;
            this.gridViewFunction.Name = "gridViewFunction";
            this.gridViewFunction.NewItemRowText = "<<Thêm dòng mới>>";
            this.gridViewFunction.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;
            this.gridViewFunction.OptionsView.RowAutoHeight = true;
            this.gridViewFunction.OptionsView.ShowAutoFilterRow = true;
            this.gridViewFunction.OptionsView.ShowGroupPanel = false;
            this.gridViewFunction.MouseDown += new System.Windows.Forms.MouseEventHandler(this.gridViewFunction_MouseDown);
            this.gridViewFunction.MouseMove += new System.Windows.Forms.MouseEventHandler(this.gridViewFunction_MouseMove);
            // 
            // colFunctionName
            // 
            this.colFunctionName.Caption = "Tên";
            this.colFunctionName.ColumnEdit = this.repositoryItemMemoEdit1;
            this.colFunctionName.FieldName = "FunctionName";
            this.colFunctionName.Name = "colFunctionName";
            this.colFunctionName.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colFunctionName.Visible = true;
            this.colFunctionName.VisibleIndex = 0;
            this.colFunctionName.Width = 190;
            // 
            // repositoryItemMemoEdit1
            // 
            this.repositoryItemMemoEdit1.Appearance.Options.UseTextOptions = true;
            this.repositoryItemMemoEdit1.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.repositoryItemMemoEdit1.Name = "repositoryItemMemoEdit1";
            // 
            // colNamespaceAndClassName
            // 
            this.colNamespaceAndClassName.ColumnEdit = this.repositoryItemSearchLookUpEdit1;
            this.colNamespaceAndClassName.FieldName = "NamespaceAndClassName";
            this.colNamespaceAndClassName.Name = "colNamespaceAndClassName";
            this.colNamespaceAndClassName.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colNamespaceAndClassName.Visible = true;
            this.colNamespaceAndClassName.VisibleIndex = 1;
            this.colNamespaceAndClassName.Width = 251;
            // 
            // repositoryItemSearchLookUpEdit1
            // 
            this.repositoryItemSearchLookUpEdit1.AutoHeight = false;
            this.repositoryItemSearchLookUpEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemSearchLookUpEdit1.DataSource = this.formTypeBindingSource;
            this.repositoryItemSearchLookUpEdit1.DisplayMember = "Name";
            this.repositoryItemSearchLookUpEdit1.Name = "repositoryItemSearchLookUpEdit1";
            this.repositoryItemSearchLookUpEdit1.ValueMember = "FullName";
            // 
            // colImage1
            // 
            this.colImage1.ColumnEdit = this.repositoryItemPictureEdit2;
            this.colImage1.FieldName = "Image";
            this.colImage1.Name = "colImage1";
            this.colImage1.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Equals;
            this.colImage1.Visible = true;
            this.colImage1.VisibleIndex = 3;
            this.colImage1.Width = 88;
            // 
            // repositoryItemPictureEdit2
            // 
            this.repositoryItemPictureEdit2.CustomHeight = 16;
            this.repositoryItemPictureEdit2.Name = "repositoryItemPictureEdit2";
            this.repositoryItemPictureEdit2.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Squeeze;
            this.repositoryItemPictureEdit2.ZoomAccelerationFactor = 1D;
            // 
            // colPublicInitInstanceMethod
            // 
            this.colPublicInitInstanceMethod.Caption = "Phương thức show Form";
            this.colPublicInitInstanceMethod.FieldName = "PublicInitInstanceMethod";
            this.colPublicInitInstanceMethod.Name = "colPublicInitInstanceMethod";
            this.colPublicInitInstanceMethod.Visible = true;
            this.colPublicInitInstanceMethod.VisibleIndex = 2;
            this.colPublicInitInstanceMethod.Width = 167;
            // 
            // groupDetailFunction
            // 
            this.groupDetailFunction.Controls.Add(this.btnMoveDownFunction);
            this.groupDetailFunction.Controls.Add(this.btnMoveUpFunction);
            this.groupDetailFunction.Controls.Add(this.labelControl2);
            this.groupDetailFunction.Controls.Add(this.txtSingletonPropertyName);
            this.groupDetailFunction.Controls.Add(this.functionPicture);
            this.groupDetailFunction.Controls.Add(this.chkIsMdiChild);
            this.groupDetailFunction.Controls.Add(this.chkIsMdiContainer);
            this.groupDetailFunction.Controls.Add(this.chkIsShowDialog);
            this.groupDetailFunction.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupDetailFunction.Location = new System.Drawing.Point(0, 0);
            this.groupDetailFunction.Name = "groupDetailFunction";
            this.groupDetailFunction.Size = new System.Drawing.Size(558, 123);
            this.groupDetailFunction.TabIndex = 1;
            this.groupDetailFunction.Text = "Chi tiết chức năng";
            // 
            // btnMoveDownFunction
            // 
            this.btnMoveDownFunction.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnMoveDownFunction.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.btnMoveDownFunction.Appearance.Options.UseFont = true;
            this.btnMoveDownFunction.Location = new System.Drawing.Point(428, 75);
            this.btnMoveDownFunction.Name = "btnMoveDownFunction";
            this.btnMoveDownFunction.Size = new System.Drawing.Size(47, 42);
            this.btnMoveDownFunction.TabIndex = 4;
            this.btnMoveDownFunction.Text = "Down";
            this.btnMoveDownFunction.Visible = false;
            this.btnMoveDownFunction.Click += new System.EventHandler(this.btnMoveDownFunction_Click);
            // 
            // btnMoveUpFunction
            // 
            this.btnMoveUpFunction.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnMoveUpFunction.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.btnMoveUpFunction.Appearance.Options.UseFont = true;
            this.btnMoveUpFunction.Location = new System.Drawing.Point(428, 25);
            this.btnMoveUpFunction.Name = "btnMoveUpFunction";
            this.btnMoveUpFunction.Size = new System.Drawing.Size(47, 42);
            this.btnMoveUpFunction.TabIndex = 5;
            this.btnMoveUpFunction.Text = "Up";
            this.btnMoveUpFunction.Visible = false;
            this.btnMoveUpFunction.Click += new System.EventHandler(this.btnMoveUpFunction_Click);
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(204, 26);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(48, 13);
            this.labelControl2.TabIndex = 3;
            this.labelControl2.Text = "Singleton:";
            this.labelControl2.Visible = false;
            // 
            // txtSingletonPropertyName
            // 
            this.txtSingletonPropertyName.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.AppFunctionBindingSource, "PublicStaticSingletonProperty", true));
            this.txtSingletonPropertyName.Location = new System.Drawing.Point(258, 22);
            this.txtSingletonPropertyName.Name = "txtSingletonPropertyName";
            this.txtSingletonPropertyName.Size = new System.Drawing.Size(100, 20);
            this.txtSingletonPropertyName.TabIndex = 2;
            this.txtSingletonPropertyName.Visible = false;
            // 
            // functionPicture
            // 
            this.functionPicture.DataBindings.Add(new System.Windows.Forms.Binding("Image", this.AppFunctionBindingSource, "Image", true));
            this.functionPicture.Location = new System.Drawing.Point(481, 18);
            this.functionPicture.Name = "functionPicture";
            this.functionPicture.Properties.NullText = "Không có icon.\r\nDouble click vào\r\nđây để chọn icon.";
            this.functionPicture.Properties.ZoomAccelerationFactor = 1D;
            this.functionPicture.Size = new System.Drawing.Size(100, 96);
            this.functionPicture.TabIndex = 0;
            this.functionPicture.DoubleClick += new System.EventHandler(this.functionPicture_DoubleClick);
            // 
            // chkIsMdiChild
            // 
            this.chkIsMdiChild.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.AppFunctionBindingSource, "IsMdiChild", true));
            this.chkIsMdiChild.Location = new System.Drawing.Point(5, 73);
            this.chkIsMdiChild.Name = "chkIsMdiChild";
            this.chkIsMdiChild.Properties.Caption = "MdiChild";
            this.chkIsMdiChild.Size = new System.Drawing.Size(111, 19);
            this.chkIsMdiChild.TabIndex = 1;
            // 
            // chkIsMdiContainer
            // 
            this.chkIsMdiContainer.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.AppFunctionBindingSource, "IsMdiContainer", true));
            this.chkIsMdiContainer.Location = new System.Drawing.Point(5, 48);
            this.chkIsMdiContainer.Name = "chkIsMdiContainer";
            this.chkIsMdiContainer.Properties.Caption = "MdiContainer";
            this.chkIsMdiContainer.Size = new System.Drawing.Size(111, 19);
            this.chkIsMdiContainer.TabIndex = 1;
            this.chkIsMdiContainer.Visible = false;
            // 
            // chkIsShowDialog
            // 
            this.chkIsShowDialog.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.AppFunctionBindingSource, "ShowDialog", true));
            this.chkIsShowDialog.Location = new System.Drawing.Point(5, 23);
            this.chkIsShowDialog.Name = "chkIsShowDialog";
            this.chkIsShowDialog.Properties.Caption = "ShowDiaglog";
            this.chkIsShowDialog.Size = new System.Drawing.Size(111, 19);
            this.chkIsShowDialog.TabIndex = 1;
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
            this.barManager1.Images = this.imageListForToolbar;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.btnThoat,
            this.btnSave});
            this.barManager1.MaxItemId = 3;
            // 
            // bar1
            // 
            this.bar1.BarName = "Tools";
            this.bar1.DockCol = 0;
            this.bar1.DockRow = 0;
            this.bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnSave, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnThoat, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)});
            this.bar1.Text = "Tools";
            // 
            // btnSave
            // 
            this.btnSave.Caption = "Lưu";
            this.btnSave.Id = 1;
            this.btnSave.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.ImageOptions.Image")));
            this.btnSave.ItemShortcut = new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S));
            this.btnSave.Name = "btnSave";
            toolTipTitleItem1.Text = "Alt+S";
            superToolTip1.Items.Add(toolTipTitleItem1);
            this.btnSave.SuperTip = superToolTip1;
            this.btnSave.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnSave_ItemClick);
            // 
            // btnThoat
            // 
            this.btnThoat.Caption = "Thoát";
            this.btnThoat.Id = 0;
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
            this.barDockControlTop.Manager = this.barManager1;
            this.barDockControlTop.Size = new System.Drawing.Size(1105, 47);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 496);
            this.barDockControlBottom.Manager = this.barManager1;
            this.barDockControlBottom.Size = new System.Drawing.Size(1105, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 47);
            this.barDockControlLeft.Manager = this.barManager1;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 449);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(1105, 47);
            this.barDockControlRight.Manager = this.barManager1;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 449);
            // 
            // imageListForToolbar
            // 
            this.imageListForToolbar.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListForToolbar.ImageStream")));
            this.imageListForToolbar.TransparentColor = System.Drawing.Color.Transparent;
            this.imageListForToolbar.Images.SetKeyName(0, "add64.png");
            this.imageListForToolbar.Images.SetKeyName(1, "undo64.png");
            this.imageListForToolbar.Images.SetKeyName(2, "1337595172_file_edit.png");
            this.imageListForToolbar.Images.SetKeyName(3, "1343360966_file_delete.png");
            this.imageListForToolbar.Images.SetKeyName(4, "save64.png");
            this.imageListForToolbar.Images.SetKeyName(5, "1337595258_Gnome-View-Refresh-64.png");
            this.imageListForToolbar.Images.SetKeyName(6, "find64.png");
            this.imageListForToolbar.Images.SetKeyName(7, "printer64.png");
            this.imageListForToolbar.Images.SetKeyName(8, "help64.png");
            this.imageListForToolbar.Images.SetKeyName(9, "exit64.png");
            this.imageListForToolbar.Images.SetKeyName(10, "list.png");
            // 
            // frmMenuAndFunctionManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1105, 496);
            this.Controls.Add(this.splitContainerControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "frmMenuAndFunctionManager";
            this.Text = "Quản lý chức năng và menu";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmMenuAndFunctionManager_Load);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtFilterTree.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.treeMenu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemPictureEdit1)).EndInit();
            this.cmsMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.AppMenuBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupDetailMenu)).EndInit();
            this.groupDetailMenu.ResumeLayout(false);
            this.groupDetailMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtThuocPhanHe.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridCtrlFunction)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AppFunctionBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewFunction)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSearchLookUpEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.formTypeBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemPictureEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupDetailFunction)).EndInit();
            this.groupDetailFunction.ResumeLayout(false);
            this.groupDetailFunction.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSingletonPropertyName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.functionPicture.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkIsMdiChild.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkIsMdiContainer.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkIsShowDialog.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private System.Windows.Forms.BindingSource AppMenuBindingSource;
        private System.Windows.Forms.ContextMenuStrip cmsMenu;
        private System.Windows.Forms.ToolStripMenuItem btnThemMenu;
        private System.Windows.Forms.ToolStripMenuItem btnXoaMenu;
        private System.Windows.Forms.ToolStripMenuItem btnThemRibbonPage;
        private System.Windows.Forms.ToolStripMenuItem btnThemRibbonPageGroup;
        private System.Windows.Forms.ToolStripMenuItem btnThemBarSubItem;
        private System.Windows.Forms.ToolStripMenuItem btnThemBarButtonGroup;
        private DevExpress.XtraTreeList.TreeList treeMenu;
        private DevExpress.XtraEditors.GroupControl groupDetailMenu;
        private System.Windows.Forms.TextBox txtBlackHole;
        private DevExpress.XtraEditors.CheckEdit chkIsShowDialog;
        private DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit repositoryItemPictureEdit1;
        private DevExpress.XtraGrid.GridControl gridCtrlFunction;
        private System.Windows.Forms.BindingSource AppFunctionBindingSource;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewFunction;
        private DevExpress.XtraEditors.GroupControl groupDetailFunction;
        private DevExpress.XtraEditors.CheckEdit chkIsMdiContainer;
        private DevExpress.XtraEditors.CheckEdit chkIsMdiChild;
        //private DevExpress.Utils.ImageCollection imageCollection1;
        private DevExpress.XtraEditors.PictureEdit functionPicture;
        private DevExpress.XtraGrid.Columns.GridColumn colFunctionName;
        private DevExpress.XtraGrid.Columns.GridColumn colNamespaceAndClassName;
        private DevExpress.XtraGrid.Columns.GridColumn colImage1;
        private DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit repositoryItemPictureEdit2;
        private System.Windows.Forms.ToolStripMenuItem btnThemPhanHe;
        private System.Windows.Forms.ToolStripMenuItem btnThemRibbon;
        private System.Windows.Forms.ToolStripMenuItem btnThemRibbonPageCategory;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit txtThuocPhanHe;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colTitle;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colShortKey;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colMaPhanHeQL;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colId;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colVisible;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colParentId;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colDescription;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colType;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colEnable;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colFunctionID;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colLocalIdx;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colGlobalIdx;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colFunction;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colMenu1;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colMenu2;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colFunctionImage;
        private DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit repositoryItemSearchLookUpEdit1;
        private System.Windows.Forms.BindingSource formTypeBindingSource;
        private DevExpress.XtraEditors.TextEdit txtFilterTree;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colMenuImage;
        private DevExpress.XtraEditors.SimpleButton btnMoveDownMenu;
        private DevExpress.XtraEditors.SimpleButton btnMoveUpMenu;
        private System.Windows.Forms.ToolStripMenuItem btnThemNavBarControl;
        private System.Windows.Forms.ToolStripMenuItem btnThemNavBarGroup;
        private System.Windows.Forms.ToolStripMenuItem btnThemNavBarItem;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.TextEdit txtSingletonPropertyName;
        private DevExpress.XtraEditors.SimpleButton btnMoveDownFunction;
        private DevExpress.XtraEditors.SimpleButton btnMoveUpFunction;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar1;
        private DevExpress.XtraBars.BarButtonItem btnThoat;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarButtonItem btnSave;
        private System.Windows.Forms.ImageList imageListForToolbar;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit repositoryItemMemoEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn colPublicInitInstanceMethod;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit repositoryItemMemoEdit2;
        //private DevExpress.XtraGrid.Views.Grid.GridView repositoryItemSearchLookUpEdit1View;
        //private System.Windows.Forms.BindingSource formTypeBindingSource;
    }
}