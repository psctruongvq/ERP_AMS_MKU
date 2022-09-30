namespace PSC_ERP
{
    partial class frmKetChuyenKhoBanQuyenTheoKyBQ
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmKetChuyenKhoBanQuyenTheoKyBQ));
            this.khoBQVTListBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.mainMenuBarManager = new DevExpress.XtraBars.BarManager(this.components);
            this.mainMenuBar = new DevExpress.XtraBars.Bar();
            this.btnThemMoi = new DevExpress.XtraBars.BarButtonItem();
            this.btn_KetChuyen = new DevExpress.XtraBars.BarButtonItem();
            this.btnHelp = new DevExpress.XtraBars.BarButtonItem();
            this.btnThoat = new DevExpress.XtraBars.BarButtonItem();
            this.btn_HuyKetChuyen = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.KyListbindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.defaultLookAndFeel1 = new DevExpress.LookAndFeel.DefaultLookAndFeel(this.components);
            this.GrCtrl_ThongTinKetChuyen = new DevExpress.XtraEditors.GroupControl();
            this.gridLookUpEdit_Ky = new DevExpress.XtraEditors.GridLookUpEdit();
            this.gridLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.gridLookUpEdit_KhoKetChuyen = new DevExpress.XtraEditors.GridLookUpEdit();
            this.gridView3 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.boPhanListBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridBoPhan = new DevExpress.XtraGrid.GridControl();
            this.gridView_BoPhan = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colChon = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CheckEdit_Chon = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.khoBQVTListBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mainMenuBarManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.KyListbindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrCtrl_ThongTinKetChuyen)).BeginInit();
            this.GrCtrl_ThongTinKetChuyen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpEdit_Ky.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpEdit_KhoKetChuyen.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.boPhanListBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridBoPhan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_BoPhan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CheckEdit_Chon)).BeginInit();
            this.SuspendLayout();
            // 
            // khoBQVTListBindingSource
            // 
            this.khoBQVTListBindingSource.DataSource = typeof(ERP_Library.KhoBQ_VTList);
            // 
            // mainMenuBarManager
            // 
            this.mainMenuBarManager.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.mainMenuBar});
            this.mainMenuBarManager.DockControls.Add(this.barDockControlTop);
            this.mainMenuBarManager.DockControls.Add(this.barDockControlBottom);
            this.mainMenuBarManager.DockControls.Add(this.barDockControlLeft);
            this.mainMenuBarManager.DockControls.Add(this.barDockControlRight);
            this.mainMenuBarManager.Form = this;
            this.mainMenuBarManager.Images = this.imageList1;
            this.mainMenuBarManager.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.btnThemMoi,
            this.btnThoat,
            this.btnHelp,
            this.btn_KetChuyen,
            this.btn_HuyKetChuyen});
            this.mainMenuBarManager.LargeImages = this.imageList1;
            this.mainMenuBarManager.MainMenu = this.mainMenuBar;
            this.mainMenuBarManager.MaxItemId = 11;
            // 
            // mainMenuBar
            // 
            this.mainMenuBar.BarName = "Main menu";
            this.mainMenuBar.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Top;
            this.mainMenuBar.DockCol = 0;
            this.mainMenuBar.DockRow = 0;
            this.mainMenuBar.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.mainMenuBar.FloatLocation = new System.Drawing.Point(337, 299);
            this.mainMenuBar.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnThemMoi, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btn_KetChuyen, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnHelp, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnThoat, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btn_HuyKetChuyen, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)});
            this.mainMenuBar.OptionsBar.MultiLine = true;
            this.mainMenuBar.OptionsBar.UseWholeRow = true;
            this.mainMenuBar.Text = "Main menu";
            // 
            // btnThemMoi
            // 
            this.btnThemMoi.Caption = "Thêm mới";
            this.btnThemMoi.Id = 0;
            this.btnThemMoi.ImageIndex = 0;
            this.btnThemMoi.Name = "btnThemMoi";
            this.btnThemMoi.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            // 
            // btn_KetChuyen
            // 
            this.btn_KetChuyen.Caption = "Kết Chuyển";
            this.btn_KetChuyen.Id = 8;
            this.btn_KetChuyen.ImageIndex = 14;
            this.btn_KetChuyen.Name = "btn_KetChuyen";
            this.btn_KetChuyen.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btn_KetChuyen_ItemClick);
            // 
            // btnHelp
            // 
            this.btnHelp.Caption = "Trợ giúp";
            this.btnHelp.Id = 7;
            this.btnHelp.ImageIndex = 6;
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            // 
            // btnThoat
            // 
            this.btnThoat.Caption = "Thoát";
            this.btnThoat.Id = 6;
            this.btnThoat.ImageIndex = 8;
            this.btnThoat.ItemShortcut = new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Q));
            this.btnThoat.Name = "btnThoat";
            toolTipTitleItem1.Text = "Ctrl+Q";
            superToolTip1.Items.Add(toolTipTitleItem1);
            this.btnThoat.SuperTip = superToolTip1;
            this.btnThoat.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnThoat_ItemClick);
            // 
            // btn_HuyKetChuyen
            // 
            this.btn_HuyKetChuyen.Caption = "Hủy Kết Chuyển";
            this.btn_HuyKetChuyen.Id = 10;
            this.btn_HuyKetChuyen.ImageIndex = 2;
            this.btn_HuyKetChuyen.Name = "btn_HuyKetChuyen";
            this.btn_HuyKetChuyen.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btn_HuyKetChuyen_ItemClick);
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(831, 32);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 428);
            this.barDockControlBottom.Size = new System.Drawing.Size(831, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 32);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 396);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(831, 32);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 396);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "1343360963_file_add.png");
            this.imageList1.Images.SetKeyName(1, "1337595172_file_edit.png");
            this.imageList1.Images.SetKeyName(2, "1343360966_file_delete.png");
            this.imageList1.Images.SetKeyName(3, "1343360964_file_search.png");
            this.imageList1.Images.SetKeyName(4, "undo64.png");
            this.imageList1.Images.SetKeyName(5, "save64.png");
            this.imageList1.Images.SetKeyName(6, "help64.png");
            this.imageList1.Images.SetKeyName(7, "printer64.png");
            this.imageList1.Images.SetKeyName(8, "exit64.png");
            this.imageList1.Images.SetKeyName(9, "1337595258_Gnome-View-Refresh-64.png");
            this.imageList1.Images.SetKeyName(10, "utilities64.png");
            this.imageList1.Images.SetKeyName(11, "report64.png");
            this.imageList1.Images.SetKeyName(12, "1345603535_invoice.png");
            this.imageList1.Images.SetKeyName(13, "1345604043_import.png");
            this.imageList1.Images.SetKeyName(14, "1345604085_export.png");
            // 
            // KyListbindingSource
            // 
            this.KyListbindingSource.DataSource = typeof(ERP_Library.KyList);
            // 
            // defaultLookAndFeel1
            // 
            this.defaultLookAndFeel1.LookAndFeel.SkinName = "Office 2010 Blue";
            // 
            // GrCtrl_ThongTinKetChuyen
            // 
            this.GrCtrl_ThongTinKetChuyen.Controls.Add(this.gridLookUpEdit_Ky);
            this.GrCtrl_ThongTinKetChuyen.Controls.Add(this.labelControl1);
            this.GrCtrl_ThongTinKetChuyen.Controls.Add(this.labelControl5);
            this.GrCtrl_ThongTinKetChuyen.Controls.Add(this.gridLookUpEdit_KhoKetChuyen);
            this.GrCtrl_ThongTinKetChuyen.Dock = System.Windows.Forms.DockStyle.Top;
            this.GrCtrl_ThongTinKetChuyen.Location = new System.Drawing.Point(0, 32);
            this.GrCtrl_ThongTinKetChuyen.Name = "GrCtrl_ThongTinKetChuyen";
            this.GrCtrl_ThongTinKetChuyen.Size = new System.Drawing.Size(831, 81);
            this.GrCtrl_ThongTinKetChuyen.TabIndex = 5;
            this.GrCtrl_ThongTinKetChuyen.Text = "Thông Tin Để Kết Chuyển";
            // 
            // gridLookUpEdit_Ky
            // 
            this.gridLookUpEdit_Ky.EditValue = "";
            this.gridLookUpEdit_Ky.Location = new System.Drawing.Point(197, 24);
            this.gridLookUpEdit_Ky.MenuManager = this.mainMenuBarManager;
            this.gridLookUpEdit_Ky.Name = "gridLookUpEdit_Ky";
            this.gridLookUpEdit_Ky.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.gridLookUpEdit_Ky.Properties.DataSource = this.KyListbindingSource;
            this.gridLookUpEdit_Ky.Properties.DisplayMember = "TenKy";
            this.gridLookUpEdit_Ky.Properties.NullText = "Chọn Kỳ";
            this.gridLookUpEdit_Ky.Properties.ValueMember = "MaKy";
            this.gridLookUpEdit_Ky.Properties.View = this.gridLookUpEdit1View;
            this.gridLookUpEdit_Ky.Size = new System.Drawing.Size(208, 20);
            this.gridLookUpEdit_Ky.TabIndex = 0;
            this.gridLookUpEdit_Ky.EditValueChanged += new System.EventHandler(this.gridLookUpEdit_Ky_EditValueChanged);
            // 
            // gridLookUpEdit1View
            // 
            this.gridLookUpEdit1View.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn5});
            this.gridLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridLookUpEdit1View.Name = "gridLookUpEdit1View";
            this.gridLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridLookUpEdit1View.OptionsView.ShowAutoFilterRow = true;
            this.gridLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            this.gridLookUpEdit1View.OptionsView.ShowViewCaption = true;
            this.gridLookUpEdit1View.ViewCaption = "Chọn Kỳ";
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Kỳ";
            this.gridColumn3.FieldName = "TenKy";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 0;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Ngày bắt đầu";
            this.gridColumn4.FieldName = "NgayBatDau";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 1;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "Ngày kết thúc";
            this.gridColumn5.FieldName = "NgayKetThuc";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 2;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(112, 27);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(75, 13);
            this.labelControl1.TabIndex = 9;
            this.labelControl1.Text = "Kỳ Kết Chuyển:";
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(112, 53);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(81, 13);
            this.labelControl5.TabIndex = 6;
            this.labelControl5.Text = "Kho Kết Chuyển:";
            // 
            // gridLookUpEdit_KhoKetChuyen
            // 
            this.gridLookUpEdit_KhoKetChuyen.Location = new System.Drawing.Point(197, 50);
            this.gridLookUpEdit_KhoKetChuyen.MenuManager = this.mainMenuBarManager;
            this.gridLookUpEdit_KhoKetChuyen.Name = "gridLookUpEdit_KhoKetChuyen";
            this.gridLookUpEdit_KhoKetChuyen.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.gridLookUpEdit_KhoKetChuyen.Properties.DataSource = this.khoBQVTListBindingSource;
            this.gridLookUpEdit_KhoKetChuyen.Properties.DisplayMember = "TenKho";
            this.gridLookUpEdit_KhoKetChuyen.Properties.NullText = "Chọn Kho";
            this.gridLookUpEdit_KhoKetChuyen.Properties.ValueMember = "MaKho";
            this.gridLookUpEdit_KhoKetChuyen.Properties.View = this.gridView3;
            this.gridLookUpEdit_KhoKetChuyen.Size = new System.Drawing.Size(208, 20);
            this.gridLookUpEdit_KhoKetChuyen.TabIndex = 1;
            this.gridLookUpEdit_KhoKetChuyen.EditValueChanged += new System.EventHandler(this.gridLookUpEdit_KhoKetChuyen_EditValueChanged);
            // 
            // gridView3
            // 
            this.gridView3.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn7,
            this.gridColumn8});
            this.gridView3.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView3.Name = "gridView3";
            this.gridView3.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView3.OptionsView.ShowAutoFilterRow = true;
            this.gridView3.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn7
            // 
            this.gridColumn7.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn7.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn7.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridColumn7.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn7.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn7.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridColumn7.Caption = "Mã";
            this.gridColumn7.FieldName = "MaQuanLy";
            this.gridColumn7.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText;
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 0;
            this.gridColumn7.Width = 40;
            // 
            // gridColumn8
            // 
            this.gridColumn8.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn8.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn8.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridColumn8.Caption = "Tên";
            this.gridColumn8.FieldName = "TenKho";
            this.gridColumn8.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText;
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 1;
            this.gridColumn8.Width = 110;
            // 
            // boPhanListBindingSource
            // 
            this.boPhanListBindingSource.DataSource = typeof(ERP_Library.BoPhanList);
            // 
            // gridBoPhan
            // 
            this.gridBoPhan.DataSource = this.boPhanListBindingSource;
            this.gridBoPhan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridBoPhan.Location = new System.Drawing.Point(0, 113);
            this.gridBoPhan.MainView = this.gridView_BoPhan;
            this.gridBoPhan.MenuManager = this.mainMenuBarManager;
            this.gridBoPhan.Name = "gridBoPhan";
            this.gridBoPhan.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.CheckEdit_Chon});
            this.gridBoPhan.Size = new System.Drawing.Size(831, 315);
            this.gridBoPhan.TabIndex = 10;
            this.gridBoPhan.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView_BoPhan});
            // 
            // gridView_BoPhan
            // 
            this.gridView_BoPhan.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colChon,
            this.gridColumn1,
            this.gridColumn2});
            this.gridView_BoPhan.GridControl = this.gridBoPhan;
            this.gridView_BoPhan.Name = "gridView_BoPhan";
            this.gridView_BoPhan.OptionsView.ShowGroupPanel = false;
            // 
            // colChon
            // 
            this.colChon.AppearanceHeader.Options.UseTextOptions = true;
            this.colChon.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colChon.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colChon.Caption = "Chọn";
            this.colChon.ColumnEdit = this.CheckEdit_Chon;
            this.colChon.FieldName = "Chon";
            this.colChon.Name = "colChon";
            this.colChon.Visible = true;
            this.colChon.VisibleIndex = 0;
            this.colChon.Width = 50;
            // 
            // CheckEdit_Chon
            // 
            this.CheckEdit_Chon.AutoHeight = false;
            this.CheckEdit_Chon.Caption = "Check";
            this.CheckEdit_Chon.Name = "CheckEdit_Chon";
            this.CheckEdit_Chon.EditValueChanged += new System.EventHandler(this.CheckEdit_Chon_EditValueChanged);
            // 
            // gridColumn1
            // 
            this.gridColumn1.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn1.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridColumn1.Caption = "Mã";
            this.gridColumn1.FieldName = "MaBoPhanQL";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 2;
            this.gridColumn1.Width = 100;
            // 
            // gridColumn2
            // 
            this.gridColumn2.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn2.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn2.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridColumn2.Caption = "Tên phòng ban";
            this.gridColumn2.FieldName = "TenBoPhan";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            this.gridColumn2.Width = 270;
            // 
            // frmKetChuyenKhoBanQuyenTheoKyBQ
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(831, 428);
            this.Controls.Add(this.gridBoPhan);
            this.Controls.Add(this.GrCtrl_ThongTinKetChuyen);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "frmKetChuyenKhoBanQuyenTheoKyBQ";
            this.Text = "frmKetChuyenKhoBanQuyenTheoKy";
            this.Load += new System.EventHandler(this.frmKetChuyenKhoBanQuyenTheoKy_Load);
            ((System.ComponentModel.ISupportInitialize)(this.khoBQVTListBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mainMenuBarManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.KyListbindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrCtrl_ThongTinKetChuyen)).EndInit();
            this.GrCtrl_ThongTinKetChuyen.ResumeLayout(false);
            this.GrCtrl_ThongTinKetChuyen.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpEdit_Ky.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpEdit_KhoKetChuyen.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.boPhanListBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridBoPhan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_BoPhan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CheckEdit_Chon)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.BindingSource khoBQVTListBindingSource;
        private DevExpress.XtraBars.BarManager mainMenuBarManager;
        private DevExpress.XtraBars.Bar mainMenuBar;
        private DevExpress.XtraBars.BarButtonItem btnThemMoi;
        private DevExpress.XtraBars.BarButtonItem btn_KetChuyen;
        private DevExpress.XtraBars.BarButtonItem btn_HuyKetChuyen;
        private DevExpress.XtraBars.BarButtonItem btnHelp;
        private DevExpress.XtraBars.BarButtonItem btnThoat;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.BindingSource KyListbindingSource;
        private DevExpress.LookAndFeel.DefaultLookAndFeel defaultLookAndFeel1;
        private DevExpress.XtraEditors.GroupControl GrCtrl_ThongTinKetChuyen;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.GridLookUpEdit gridLookUpEdit_KhoKetChuyen;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private System.Windows.Forms.BindingSource boPhanListBindingSource;
        private DevExpress.XtraEditors.GridLookUpEdit gridLookUpEdit_Ky;
        private DevExpress.XtraGrid.Views.Grid.GridView gridLookUpEdit1View;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.GridControl gridBoPhan;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView_BoPhan;
        private DevExpress.XtraGrid.Columns.GridColumn colChon;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit CheckEdit_Chon;
    }
}