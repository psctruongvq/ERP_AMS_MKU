namespace PSC_ERP.Main
{
    partial class frmDialogProjectEmployeeResource
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDialogProjectEmployeeResource));
            DevExpress.Utils.SuperToolTip superToolTip1 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem1 = new DevExpress.Utils.ToolTipTitleItem();
            DevExpress.Utils.SuperToolTip superToolTip2 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem2 = new DevExpress.Utils.ToolTipTitleItem();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar1 = new DevExpress.XtraBars.Bar();
            this.btnDuaDuLieuVeTask = new DevExpress.XtraBars.BarButtonItem();
            this.btnThoat = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.txtBlackHole = new System.Windows.Forms.TextBox();
            this.grdProjectEmployeeResource = new DevExpress.XtraGrid.GridControl();
            this.projectEmployeeResourceBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.grdViewProjectEmployeeResource = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colChon = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDescription = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTenNhanVien1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cbProjectEmployeeResource = new DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit();
            this.repositoryItemGridLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colDescription1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTenNhanVien = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdProjectEmployeeResource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.projectEmployeeResourceBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdViewProjectEmployeeResource)).BeginInit();
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
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.btnDuaDuLieuVeTask,
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
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnDuaDuLieuVeTask, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnThoat, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)});
            this.bar1.Text = "Tools";
            // 
            // btnDuaDuLieuVeTask
            // 
            this.btnDuaDuLieuVeTask.Caption = "Đưa dữ liệu về";
            this.btnDuaDuLieuVeTask.Id = 6;
            this.btnDuaDuLieuVeTask.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnDuaDuLieuVeTask.ImageOptions.Image")));
            this.btnDuaDuLieuVeTask.ItemShortcut = new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.B));
            this.btnDuaDuLieuVeTask.Name = "btnDuaDuLieuVeTask";
            toolTipTitleItem1.Text = "Ctrl+B";
            superToolTip1.Items.Add(toolTipTitleItem1);
            this.btnDuaDuLieuVeTask.SuperTip = superToolTip1;
            this.btnDuaDuLieuVeTask.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnDuaDuLieuVeTask_ItemClick);
            // 
            // btnThoat
            // 
            this.btnThoat.Caption = "Thoát";
            this.btnThoat.Id = 7;
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
            this.barDockControlTop.Size = new System.Drawing.Size(613, 47);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 281);
            this.barDockControlBottom.Manager = this.barManager1;
            this.barDockControlBottom.Size = new System.Drawing.Size(613, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 47);
            this.barDockControlLeft.Manager = this.barManager1;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 234);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(613, 47);
            this.barDockControlRight.Manager = this.barManager1;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 234);
            // 
            // txtBlackHole
            // 
            this.txtBlackHole.Location = new System.Drawing.Point(4, 41);
            this.txtBlackHole.Name = "txtBlackHole";
            this.txtBlackHole.Size = new System.Drawing.Size(100, 21);
            this.txtBlackHole.TabIndex = 20;
            this.txtBlackHole.TabStop = false;
            // 
            // grdProjectEmployeeResource
            // 
            this.grdProjectEmployeeResource.DataSource = this.projectEmployeeResourceBindingSource;
            this.grdProjectEmployeeResource.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdProjectEmployeeResource.Location = new System.Drawing.Point(0, 47);
            this.grdProjectEmployeeResource.MainView = this.grdViewProjectEmployeeResource;
            this.grdProjectEmployeeResource.Name = "grdProjectEmployeeResource";
            this.grdProjectEmployeeResource.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.cbProjectEmployeeResource});
            this.grdProjectEmployeeResource.Size = new System.Drawing.Size(613, 234);
            this.grdProjectEmployeeResource.TabIndex = 25;
            this.grdProjectEmployeeResource.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grdViewProjectEmployeeResource});
            // 
            // projectEmployeeResourceBindingSource
            // 
            this.projectEmployeeResourceBindingSource.DataSource = typeof(PSC_ERP_Business.Main.Model.ProjectEmployeeResource);
            // 
            // grdViewProjectEmployeeResource
            // 
            this.grdViewProjectEmployeeResource.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colChon,
            this.colDescription,
            this.colTenNhanVien1});
            this.grdViewProjectEmployeeResource.GridControl = this.grdProjectEmployeeResource;
            this.grdViewProjectEmployeeResource.GroupPanelText = "Danh sách nhân viên";
            this.grdViewProjectEmployeeResource.Name = "grdViewProjectEmployeeResource";
            this.grdViewProjectEmployeeResource.OptionsSelection.MultiSelect = true;
            this.grdViewProjectEmployeeResource.OptionsView.ShowAutoFilterRow = true;
            this.grdViewProjectEmployeeResource.OptionsView.ShowFooter = true;
            // 
            // colChon
            // 
            this.colChon.FieldName = "Chon";
            this.colChon.Name = "colChon";
            this.colChon.Visible = true;
            this.colChon.VisibleIndex = 0;
            this.colChon.Width = 68;
            // 
            // colDescription
            // 
            this.colDescription.FieldName = "Description";
            this.colDescription.Name = "colDescription";
            this.colDescription.OptionsColumn.AllowEdit = false;
            this.colDescription.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colDescription.Visible = true;
            this.colDescription.VisibleIndex = 2;
            this.colDescription.Width = 265;
            // 
            // colTenNhanVien1
            // 
            this.colTenNhanVien1.Caption = "Tên nhân viên";
            this.colTenNhanVien1.FieldName = "NhanVien.TenNhanVien";
            this.colTenNhanVien1.Name = "colTenNhanVien1";
            this.colTenNhanVien1.OptionsColumn.AllowEdit = false;
            this.colTenNhanVien1.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colTenNhanVien1.Visible = true;
            this.colTenNhanVien1.VisibleIndex = 1;
            this.colTenNhanVien1.Width = 262;
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
            // frmDialogProjectEmployeeResource
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(613, 281);
            this.ControlBox = false;
            this.Controls.Add(this.grdProjectEmployeeResource);
            this.Controls.Add(this.txtBlackHole);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "frmDialogProjectEmployeeResource";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Danh sách nhân viên theo porject";
            this.Load += new System.EventHandler(this.frmDialogProjectEmployeeResource_Load);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdProjectEmployeeResource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.projectEmployeeResourceBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdViewProjectEmployeeResource)).EndInit();
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
        private DevExpress.XtraBars.BarButtonItem btnDuaDuLieuVeTask;
        private System.Windows.Forms.TextBox txtBlackHole;
        private DevExpress.XtraGrid.GridControl grdProjectEmployeeResource;
        private DevExpress.XtraGrid.Views.Grid.GridView grdViewProjectEmployeeResource;
        private DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit cbProjectEmployeeResource;
        private DevExpress.XtraGrid.Views.Grid.GridView repositoryItemGridLookUpEdit1View;
        private DevExpress.XtraGrid.Columns.GridColumn colDescription1;
        private DevExpress.XtraGrid.Columns.GridColumn colTenNhanVien;
        private System.Windows.Forms.BindingSource projectEmployeeResourceBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colChon;
        private DevExpress.XtraGrid.Columns.GridColumn colDescription;
        private DevExpress.XtraGrid.Columns.GridColumn colTenNhanVien1;
        private DevExpress.XtraBars.BarButtonItem btnThoat;
    }
}