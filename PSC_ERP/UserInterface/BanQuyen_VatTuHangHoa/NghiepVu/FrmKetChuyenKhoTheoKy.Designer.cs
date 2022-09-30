namespace PSC_ERP
{
    partial class FrmKetChuyenKhoTheoKy
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmKetChuyenKhoTheoKy));
            this.mainMenuBarManager = new DevExpress.XtraBars.BarManager(this.components);
            this.mainMenuBar = new DevExpress.XtraBars.Bar();
            this.btnThemMoi = new DevExpress.XtraBars.BarButtonItem();
            this.btn_KetChuyen = new DevExpress.XtraBars.BarButtonItem();
            this.btnHelp = new DevExpress.XtraBars.BarButtonItem();
            this.btn_HuyKetChuyen = new DevExpress.XtraBars.BarButtonItem();
            this.btnThoat = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.GrCtrl_ThongTinKetChuyen = new DevExpress.XtraEditors.GroupControl();
            this.gridLookUpEdit_KyKetchuyen = new DevExpress.XtraEditors.GridLookUpEdit();
            this.KyListbindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.txt_DienGiai = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.gridLookUpEdit_KhoKetChuyen = new DevExpress.XtraEditors.GridLookUpEdit();
            this.khoBQVTListBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView3 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.defaultLookAndFeel1 = new DevExpress.LookAndFeel.DefaultLookAndFeel(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.mainMenuBarManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrCtrl_ThongTinKetChuyen)).BeginInit();
            this.GrCtrl_ThongTinKetChuyen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpEdit_KyKetchuyen.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.KyListbindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_DienGiai.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpEdit_KhoKetChuyen.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.khoBQVTListBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).BeginInit();
            this.SuspendLayout();
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
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btn_HuyKetChuyen, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnThoat, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)});
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
            // btn_HuyKetChuyen
            // 
            this.btn_HuyKetChuyen.Caption = "Hủy Kết Chuyển";
            this.btn_HuyKetChuyen.Id = 10;
            this.btn_HuyKetChuyen.ImageIndex = 2;
            this.btn_HuyKetChuyen.Name = "btn_HuyKetChuyen";
            this.btn_HuyKetChuyen.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btn_HuyKetChuyen_ItemClick);
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
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(816, 34);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 306);
            this.barDockControlBottom.Size = new System.Drawing.Size(816, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 34);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 272);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(816, 34);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 272);
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
            // GrCtrl_ThongTinKetChuyen
            // 
            this.GrCtrl_ThongTinKetChuyen.Controls.Add(this.gridLookUpEdit_KyKetchuyen);
            this.GrCtrl_ThongTinKetChuyen.Controls.Add(this.txt_DienGiai);
            this.GrCtrl_ThongTinKetChuyen.Controls.Add(this.labelControl2);
            this.GrCtrl_ThongTinKetChuyen.Controls.Add(this.labelControl1);
            this.GrCtrl_ThongTinKetChuyen.Controls.Add(this.labelControl5);
            this.GrCtrl_ThongTinKetChuyen.Controls.Add(this.gridLookUpEdit_KhoKetChuyen);
            this.GrCtrl_ThongTinKetChuyen.Dock = System.Windows.Forms.DockStyle.Top;
            this.GrCtrl_ThongTinKetChuyen.Location = new System.Drawing.Point(0, 34);
            this.GrCtrl_ThongTinKetChuyen.Name = "GrCtrl_ThongTinKetChuyen";
            this.GrCtrl_ThongTinKetChuyen.Size = new System.Drawing.Size(816, 108);
            this.GrCtrl_ThongTinKetChuyen.TabIndex = 4;
            this.GrCtrl_ThongTinKetChuyen.Text = "Thông Tin Để Kết Chuyển";
            // 
            // gridLookUpEdit_KyKetchuyen
            // 
            this.gridLookUpEdit_KyKetchuyen.Location = new System.Drawing.Point(171, 24);
            this.gridLookUpEdit_KyKetchuyen.MenuManager = this.mainMenuBarManager;
            this.gridLookUpEdit_KyKetchuyen.Name = "gridLookUpEdit_KyKetchuyen";
            this.gridLookUpEdit_KyKetchuyen.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.gridLookUpEdit_KyKetchuyen.Properties.DataSource = this.KyListbindingSource;
            this.gridLookUpEdit_KyKetchuyen.Properties.DisplayMember = "TenKy";
            this.gridLookUpEdit_KyKetchuyen.Properties.NullText = "Chọn Kỳ";
            this.gridLookUpEdit_KyKetchuyen.Properties.ValueMember = "MaKy";
            this.gridLookUpEdit_KyKetchuyen.Properties.View = this.gridLookUpEdit1View;
            this.gridLookUpEdit_KyKetchuyen.Size = new System.Drawing.Size(165, 20);
            this.gridLookUpEdit_KyKetchuyen.TabIndex = 11;
            this.gridLookUpEdit_KyKetchuyen.EditValueChanged += new System.EventHandler(this.gridLookUpEdit_KyKetchuyen_EditValueChanged);
            // 
            // KyListbindingSource
            // 
            this.KyListbindingSource.DataSource = typeof(ERP_Library.KyList);
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
            // txt_DienGiai
            // 
            this.txt_DienGiai.Location = new System.Drawing.Point(171, 74);
            this.txt_DienGiai.MenuManager = this.mainMenuBarManager;
            this.txt_DienGiai.Name = "txt_DienGiai";
            this.txt_DienGiai.Size = new System.Drawing.Size(481, 20);
            this.txt_DienGiai.TabIndex = 2;
            this.txt_DienGiai.EditValueChanged += new System.EventHandler(this.txt_DienGiai_EditValueChanged);
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(126, 77);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(45, 13);
            this.labelControl2.TabIndex = 10;
            this.labelControl2.Text = "Diễn Giải:";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(89, 31);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(75, 13);
            this.labelControl1.TabIndex = 9;
            this.labelControl1.Text = "Kỳ Kết Chuyển:";
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(90, 53);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(81, 13);
            this.labelControl5.TabIndex = 6;
            this.labelControl5.Text = "Kho Kết Chuyển:";
            // 
            // gridLookUpEdit_KhoKetChuyen
            // 
            this.gridLookUpEdit_KhoKetChuyen.Location = new System.Drawing.Point(171, 50);
            this.gridLookUpEdit_KhoKetChuyen.MenuManager = this.mainMenuBarManager;
            this.gridLookUpEdit_KhoKetChuyen.Name = "gridLookUpEdit_KhoKetChuyen";
            this.gridLookUpEdit_KhoKetChuyen.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.gridLookUpEdit_KhoKetChuyen.Properties.DataSource = this.khoBQVTListBindingSource;
            this.gridLookUpEdit_KhoKetChuyen.Properties.DisplayMember = "TenKho";
            this.gridLookUpEdit_KhoKetChuyen.Properties.NullText = "Chọn Kho";
            this.gridLookUpEdit_KhoKetChuyen.Properties.ValueMember = "MaKho";
            this.gridLookUpEdit_KhoKetChuyen.Properties.View = this.gridView3;
            this.gridLookUpEdit_KhoKetChuyen.Size = new System.Drawing.Size(165, 20);
            this.gridLookUpEdit_KhoKetChuyen.TabIndex = 1;
            this.gridLookUpEdit_KhoKetChuyen.EditValueChanged += new System.EventHandler(this.gridLookUpEdit_KhoKetChuyen_EditValueChanged);
            // 
            // khoBQVTListBindingSource
            // 
            this.khoBQVTListBindingSource.DataSource = typeof(ERP_Library.KhoBQ_VTList);
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
            // defaultLookAndFeel1
            // 
            this.defaultLookAndFeel1.LookAndFeel.SkinName = "Office 2010 Blue";
            // 
            // FrmKetChuyenKhoTheoKy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(816, 306);
            this.Controls.Add(this.GrCtrl_ThongTinKetChuyen);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "FrmKetChuyenKhoTheoKy";
            this.Text = "Kết Chuyển Tồn Kho Theo Ky";
            this.Load += new System.EventHandler(this.FrmKetChuyenKhoTheoKy_Load);
            ((System.ComponentModel.ISupportInitialize)(this.mainMenuBarManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrCtrl_ThongTinKetChuyen)).EndInit();
            this.GrCtrl_ThongTinKetChuyen.ResumeLayout(false);
            this.GrCtrl_ThongTinKetChuyen.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpEdit_KyKetchuyen.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.KyListbindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_DienGiai.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpEdit_KhoKetChuyen.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.khoBQVTListBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

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
        private DevExpress.XtraEditors.GroupControl GrCtrl_ThongTinKetChuyen;
        private System.Windows.Forms.BindingSource khoBQVTListBindingSource;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.GridLookUpEdit gridLookUpEdit_KhoKetChuyen;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private System.Windows.Forms.BindingSource KyListbindingSource;
        private DevExpress.LookAndFeel.DefaultLookAndFeel defaultLookAndFeel1;
        private DevExpress.XtraEditors.TextEdit txt_DienGiai;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.GridLookUpEdit gridLookUpEdit_KyKetchuyen;
        private DevExpress.XtraGrid.Views.Grid.GridView gridLookUpEdit1View;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
    }
}