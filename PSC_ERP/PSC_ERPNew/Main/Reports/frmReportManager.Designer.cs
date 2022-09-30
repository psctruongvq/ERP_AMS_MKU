namespace PSC_ERPNew.Main.Reports
{
    partial class frmReportManager
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReportManager));
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.gridControl_UserList = new DevExpress.XtraGrid.GridControl();
            this.appusersBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView_UserList = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colTenDangNhap = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.cbMaPhanHe = new DevExpress.XtraEditors.GridLookUpEdit();
            this.barManager = new DevExpress.XtraBars.BarManager(this.components);
            this.bar1 = new DevExpress.XtraBars.Bar();
            this.btnImport = new DevExpress.XtraBars.BarButtonItem();
            this.btnExport = new DevExpress.XtraBars.BarButtonItem();
            this.btnThoat = new DevExpress.XtraBars.BarButtonItem();
            this.standaloneBarDockControl1 = new DevExpress.XtraBars.StandaloneBarDockControl();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.MaPhanHe_BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colMaPHanHe = new DevExpress.XtraGrid.Columns.GridColumn();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txtBlackHole = new DevExpress.XtraEditors.TextEdit();
            this.gridControl_Report = new DevExpress.XtraGrid.GridControl();
            this.reportBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView_Report = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colReportKey = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colModifiedDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colReportName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colInList = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOnForm = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colChon = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_UserList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.appusersBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_UserList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbMaPhanHe.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MaPhanHe_BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBlackHole.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_Report)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.reportBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_Report)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.gridControl_UserList);
            this.splitContainerControl1.Panel1.Controls.Add(this.panelControl1);
            this.splitContainerControl1.Panel1.Controls.Add(this.txtBlackHole);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.gridControl_Report);
            this.splitContainerControl1.Panel2.Controls.Add(this.standaloneBarDockControl1);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(852, 506);
            this.splitContainerControl1.SplitterPosition = 248;
            this.splitContainerControl1.TabIndex = 0;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // gridControl_UserList
            // 
            this.gridControl_UserList.DataSource = this.appusersBindingSource;
            this.gridControl_UserList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl_UserList.Location = new System.Drawing.Point(0, 32);
            this.gridControl_UserList.MainView = this.gridView_UserList;
            this.gridControl_UserList.Name = "gridControl_UserList";
            this.gridControl_UserList.Size = new System.Drawing.Size(248, 474);
            this.gridControl_UserList.TabIndex = 1;
            this.gridControl_UserList.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView_UserList});
            // 
            // appusersBindingSource
            // 
            this.appusersBindingSource.DataSource = typeof(PSC_ERP_Business.Main.Model.app_users);
            this.appusersBindingSource.CurrentChanged += new System.EventHandler(this.appusersBindingSource_CurrentChanged);
            // 
            // gridView_UserList
            // 
            this.gridView_UserList.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colTenDangNhap});
            this.gridView_UserList.GridControl = this.gridControl_UserList;
            this.gridView_UserList.GroupPanelText = "Danh sách người dùng";
            this.gridView_UserList.Name = "gridView_UserList";
            this.gridView_UserList.OptionsView.ShowAutoFilterRow = true;
            this.gridView_UserList.OptionsView.ShowFooter = true;
            this.gridView_UserList.DoubleClick += new System.EventHandler(this.gridView_UserList_DoubleClick);
            // 
            // colTenDangNhap
            // 
            this.colTenDangNhap.Caption = "Tên đăng nhập";
            this.colTenDangNhap.FieldName = "TenDangNhap";
            this.colTenDangNhap.Name = "colTenDangNhap";
            this.colTenDangNhap.OptionsColumn.AllowEdit = false;
            this.colTenDangNhap.OptionsColumn.ReadOnly = true;
            this.colTenDangNhap.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colTenDangNhap.Visible = true;
            this.colTenDangNhap.VisibleIndex = 0;
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.cbMaPhanHe);
            this.panelControl1.Controls.Add(this.labelControl1);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(248, 32);
            this.panelControl1.TabIndex = 0;
            // 
            // cbMaPhanHe
            // 
            this.cbMaPhanHe.Location = new System.Drawing.Point(105, 5);
            this.cbMaPhanHe.MenuManager = this.barManager;
            this.cbMaPhanHe.Name = "cbMaPhanHe";
            this.cbMaPhanHe.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbMaPhanHe.Properties.DataSource = this.MaPhanHe_BindingSource;
            this.cbMaPhanHe.Properties.DisplayMember = "MaPhanHe";
            this.cbMaPhanHe.Properties.NullText = "<<Không chọn>>";
            this.cbMaPhanHe.Properties.ValueMember = "MaPhanHe";
            this.cbMaPhanHe.Properties.View = this.gridLookUpEdit1View;
            this.cbMaPhanHe.Size = new System.Drawing.Size(132, 20);
            this.cbMaPhanHe.TabIndex = 1;
            // 
            // barManager
            // 
            this.barManager.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar1});
            this.barManager.DockControls.Add(this.barDockControlTop);
            this.barManager.DockControls.Add(this.barDockControlBottom);
            this.barManager.DockControls.Add(this.barDockControlLeft);
            this.barManager.DockControls.Add(this.barDockControlRight);
            this.barManager.DockControls.Add(this.standaloneBarDockControl1);
            this.barManager.Form = this;
            this.barManager.Images = this.imageList;
            this.barManager.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.btnImport,
            this.btnExport,
            this.btnThoat});
            this.barManager.MaxItemId = 3;
            // 
            // bar1
            // 
            this.bar1.BarName = "Tools";
            this.bar1.DockCol = 0;
            this.bar1.DockRow = 0;
            this.bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Standalone;
            this.bar1.FloatLocation = new System.Drawing.Point(708, 136);
            this.bar1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnImport, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnExport, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnThoat, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)});
            this.bar1.StandaloneBarDockControl = this.standaloneBarDockControl1;
            this.bar1.Text = "Tools";
            // 
            // btnImport
            // 
            this.btnImport.Caption = "Import";
            this.btnImport.Id = 0;
            this.btnImport.ImageIndex = 11;
            this.btnImport.Name = "btnImport";
            this.btnImport.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnImport_ItemClick);
            // 
            // btnExport
            // 
            this.btnExport.Caption = "Export";
            this.btnExport.Id = 1;
            this.btnExport.ImageIndex = 10;
            this.btnExport.Name = "btnExport";
            this.btnExport.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnExport_ItemClick);
            // 
            // btnThoat
            // 
            this.btnThoat.Caption = "Thoát";
            this.btnThoat.Id = 2;
            this.btnThoat.ImageIndex = 9;
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnThoat_ItemClick);
            // 
            // standaloneBarDockControl1
            // 
            this.standaloneBarDockControl1.CausesValidation = false;
            this.standaloneBarDockControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.standaloneBarDockControl1.Location = new System.Drawing.Point(0, 0);
            this.standaloneBarDockControl1.Name = "standaloneBarDockControl1";
            this.standaloneBarDockControl1.Size = new System.Drawing.Size(599, 43);
            this.standaloneBarDockControl1.Text = "standaloneBarDockControl1";
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(852, 0);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 506);
            this.barDockControlBottom.Size = new System.Drawing.Size(852, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 0);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 506);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(852, 0);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 506);
            // 
            // imageList
            // 
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList.Images.SetKeyName(0, "add64.png");
            this.imageList.Images.SetKeyName(1, "undo64.png");
            this.imageList.Images.SetKeyName(2, "1337595172_file_edit.png");
            this.imageList.Images.SetKeyName(3, "1343360966_file_delete.png");
            this.imageList.Images.SetKeyName(4, "save64.png");
            this.imageList.Images.SetKeyName(5, "1337595258_Gnome-View-Refresh-64.png");
            this.imageList.Images.SetKeyName(6, "find64.png");
            this.imageList.Images.SetKeyName(7, "printer64.png");
            this.imageList.Images.SetKeyName(8, "help64.png");
            this.imageList.Images.SetKeyName(9, "exit64.png");
            this.imageList.Images.SetKeyName(10, "export.png");
            this.imageList.Images.SetKeyName(11, "import.png");
            // 
            // MaPhanHe_BindingSource
            // 
            this.MaPhanHe_BindingSource.DataSource = typeof(PSC_ERP_Business.Main.Model.Report);
            // 
            // gridLookUpEdit1View
            // 
            this.gridLookUpEdit1View.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colMaPHanHe});
            this.gridLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridLookUpEdit1View.Name = "gridLookUpEdit1View";
            this.gridLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridLookUpEdit1View.OptionsView.ShowAutoFilterRow = true;
            this.gridLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // colMaPHanHe
            // 
            this.colMaPHanHe.AppearanceCell.Options.UseTextOptions = true;
            this.colMaPHanHe.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colMaPHanHe.AppearanceHeader.Options.UseTextOptions = true;
            this.colMaPHanHe.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colMaPHanHe.Caption = "Mã Phân Hệ";
            this.colMaPHanHe.FieldName = "MaPhanHe";
            this.colMaPHanHe.Name = "colMaPHanHe";
            this.colMaPHanHe.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colMaPHanHe.Visible = true;
            this.colMaPHanHe.VisibleIndex = 0;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(11, 8);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(88, 13);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Chọn mã phân hệ:";
            // 
            // txtBlackHole
            // 
            this.txtBlackHole.Location = new System.Drawing.Point(221, 43);
            this.txtBlackHole.MenuManager = this.barManager;
            this.txtBlackHole.Name = "txtBlackHole";
            this.txtBlackHole.Size = new System.Drawing.Size(100, 20);
            this.txtBlackHole.TabIndex = 2;
            this.txtBlackHole.TabStop = false;
            // 
            // gridControl_Report
            // 
            this.gridControl_Report.DataSource = this.reportBindingSource;
            this.gridControl_Report.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl_Report.Location = new System.Drawing.Point(0, 43);
            this.gridControl_Report.MainView = this.gridView_Report;
            this.gridControl_Report.Name = "gridControl_Report";
            this.gridControl_Report.Size = new System.Drawing.Size(599, 463);
            this.gridControl_Report.TabIndex = 3;
            this.gridControl_Report.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView_Report});
            // 
            // reportBindingSource
            // 
            this.reportBindingSource.DataSource = typeof(PSC_ERP_Business.Main.Model.Report);
            // 
            // gridView_Report
            // 
            this.gridView_Report.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colReportKey,
            this.colModifiedDate,
            this.colReportName,
            this.colInList,
            this.colOnForm,
            this.colChon});
            this.gridView_Report.GridControl = this.gridControl_Report;
            this.gridView_Report.Name = "gridView_Report";
            this.gridView_Report.OptionsView.ShowAutoFilterRow = true;
            this.gridView_Report.OptionsView.ShowFooter = true;
            this.gridView_Report.OptionsView.ShowGroupPanel = false;
            // 
            // colReportKey
            // 
            this.colReportKey.AppearanceHeader.Options.UseTextOptions = true;
            this.colReportKey.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colReportKey.Caption = "Khóa";
            this.colReportKey.FieldName = "ReportKey";
            this.colReportKey.Name = "colReportKey";
            this.colReportKey.OptionsColumn.ReadOnly = true;
            this.colReportKey.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colReportKey.Visible = true;
            this.colReportKey.VisibleIndex = 0;
            this.colReportKey.Width = 87;
            // 
            // colModifiedDate
            // 
            this.colModifiedDate.AppearanceCell.Options.UseTextOptions = true;
            this.colModifiedDate.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colModifiedDate.AppearanceHeader.Options.UseTextOptions = true;
            this.colModifiedDate.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colModifiedDate.Caption = "Ngày cập nhật";
            this.colModifiedDate.FieldName = "ModifiedDate";
            this.colModifiedDate.Name = "colModifiedDate";
            this.colModifiedDate.OptionsColumn.ReadOnly = true;
            this.colModifiedDate.Visible = true;
            this.colModifiedDate.VisibleIndex = 2;
            this.colModifiedDate.Width = 82;
            // 
            // colReportName
            // 
            this.colReportName.AppearanceHeader.Options.UseTextOptions = true;
            this.colReportName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colReportName.Caption = "Tên báo cáo";
            this.colReportName.FieldName = "ReportName";
            this.colReportName.Name = "colReportName";
            this.colReportName.OptionsColumn.ReadOnly = true;
            this.colReportName.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colReportName.Visible = true;
            this.colReportName.VisibleIndex = 1;
            this.colReportName.Width = 164;
            // 
            // colInList
            // 
            this.colInList.AppearanceCell.Options.UseTextOptions = true;
            this.colInList.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colInList.AppearanceHeader.Options.UseTextOptions = true;
            this.colInList.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colInList.Caption = "In List";
            this.colInList.FieldName = "InList";
            this.colInList.Name = "colInList";
            this.colInList.OptionsColumn.ReadOnly = true;
            this.colInList.Visible = true;
            this.colInList.VisibleIndex = 3;
            this.colInList.Width = 47;
            // 
            // colOnForm
            // 
            this.colOnForm.AppearanceCell.Options.UseTextOptions = true;
            this.colOnForm.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colOnForm.AppearanceHeader.Options.UseTextOptions = true;
            this.colOnForm.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colOnForm.Caption = "On Form";
            this.colOnForm.FieldName = "OnForm";
            this.colOnForm.Name = "colOnForm";
            this.colOnForm.OptionsColumn.ReadOnly = true;
            this.colOnForm.Visible = true;
            this.colOnForm.VisibleIndex = 4;
            this.colOnForm.Width = 48;
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
            this.colChon.Visible = true;
            this.colChon.VisibleIndex = 5;
            this.colChon.Width = 55;
            // 
            // frmReportManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(852, 506);
            this.Controls.Add(this.splitContainerControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "frmReportManager";
            this.Text = "Quản lý báo cáo";
            this.Load += new System.EventHandler(this.frmReportManager_Load);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_UserList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.appusersBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_UserList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbMaPhanHe.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MaPhanHe_BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBlackHole.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_Report)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.reportBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_Report)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraGrid.GridControl gridControl_UserList;
        private System.Windows.Forms.BindingSource appusersBindingSource;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView_UserList;
        private DevExpress.XtraGrid.Columns.GridColumn colTenDangNhap;
        private DevExpress.XtraBars.StandaloneBarDockControl standaloneBarDockControl1;
        private DevExpress.XtraBars.BarManager barManager;
        private DevExpress.XtraBars.Bar bar1;
        private DevExpress.XtraBars.BarButtonItem btnImport;
        private DevExpress.XtraBars.BarButtonItem btnExport;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private System.Windows.Forms.ImageList imageList;
        private System.Windows.Forms.BindingSource reportBindingSource;
        private DevExpress.XtraEditors.TextEdit txtBlackHole;
        private System.Windows.Forms.BindingSource MaPhanHe_BindingSource;
        private DevExpress.XtraBars.BarButtonItem btnThoat;
        private DevExpress.XtraEditors.GridLookUpEdit cbMaPhanHe;
        private DevExpress.XtraGrid.Views.Grid.GridView gridLookUpEdit1View;
        private DevExpress.XtraGrid.Columns.GridColumn colMaPHanHe;
        private DevExpress.XtraGrid.GridControl gridControl_Report;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView_Report;
        private DevExpress.XtraGrid.Columns.GridColumn colReportKey;
        private DevExpress.XtraGrid.Columns.GridColumn colModifiedDate;
        private DevExpress.XtraGrid.Columns.GridColumn colReportName;
        private DevExpress.XtraGrid.Columns.GridColumn colInList;
        private DevExpress.XtraGrid.Columns.GridColumn colOnForm;
        private DevExpress.XtraGrid.Columns.GridColumn colChon;
    }
}