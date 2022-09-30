namespace PSC_ERP
{
    partial class FrmPhanLoaiHopDong
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPhanLoaiHopDong));
            DevExpress.Utils.SuperToolTip superToolTip3 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem3 = new DevExpress.Utils.ToolTipTitleItem();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.defaultLookAndFeel1 = new DevExpress.LookAndFeel.DefaultLookAndFeel(this.components);
            this.mainMenuBarManager = new DevExpress.XtraBars.BarManager(this.components);
            this.mainMenuBar = new DevExpress.XtraBars.Bar();
            this.btnThemMoi = new DevExpress.XtraBars.BarButtonItem();
            this.btnXoa = new DevExpress.XtraBars.BarButtonItem();
            this.btn_Refresh = new DevExpress.XtraBars.BarButtonItem();
            this.btnLuu = new DevExpress.XtraBars.BarButtonItem();
            this.btnThoat = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControl1 = new DevExpress.XtraBars.BarDockControl();
            this.barButtonItem5 = new DevExpress.XtraBars.BarButtonItem();
            this.btnPrint = new DevExpress.XtraBars.BarButtonItem();
            this.btnHelp = new DevExpress.XtraBars.BarButtonItem();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.txt_TenPhanLoaiHD = new DevExpress.XtraEditors.TextEdit();
            this.PhanLoaiHopDongList_bindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.txt_MaPhanLoaiHDQL = new DevExpress.XtraEditors.TextEdit();
            this.loaiHopDongListBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.grd_DSPhanLoaiHopDong = new DevExpress.XtraGrid.GridControl();
            this.gridView_DMPhanLoaiHD = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colMaQuanLyXe = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTenXe = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.mainMenuBarManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txt_TenPhanLoaiHD.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PhanLoaiHopDongList_bindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_MaPhanLoaiHDQL.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.loaiHopDongListBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grd_DSPhanLoaiHopDong)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_DMPhanLoaiHD)).BeginInit();
            this.SuspendLayout();
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
            // 
            // defaultLookAndFeel1
            // 
            this.defaultLookAndFeel1.LookAndFeel.SkinName = "Office 2010 Blue";
            // 
            // mainMenuBarManager
            // 
            this.mainMenuBarManager.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.mainMenuBar});
            this.mainMenuBarManager.DockControls.Add(this.barDockControlTop);
            this.mainMenuBarManager.DockControls.Add(this.barDockControlBottom);
            this.mainMenuBarManager.DockControls.Add(this.barDockControlLeft);
            this.mainMenuBarManager.DockControls.Add(this.barDockControl1);
            this.mainMenuBarManager.Form = this;
            this.mainMenuBarManager.Images = this.imageList1;
            this.mainMenuBarManager.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.btnThemMoi,
            this.btnXoa,
            this.btnLuu,
            this.barButtonItem5,
            this.btnPrint,
            this.btnThoat,
            this.btnHelp,
            this.btn_Refresh});
            this.mainMenuBarManager.LargeImages = this.imageList1;
            this.mainMenuBarManager.MainMenu = this.mainMenuBar;
            this.mainMenuBarManager.MaxItemId = 9;
            // 
            // mainMenuBar
            // 
            this.mainMenuBar.BarName = "Main menu";
            this.mainMenuBar.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Top;
            this.mainMenuBar.DockCol = 0;
            this.mainMenuBar.DockRow = 0;
            this.mainMenuBar.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.mainMenuBar.FloatLocation = new System.Drawing.Point(668, 233);
            this.mainMenuBar.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnThemMoi, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnXoa, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btn_Refresh, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnLuu, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
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
            this.btnThemMoi.ItemShortcut = new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N));
            this.btnThemMoi.Name = "btnThemMoi";
            this.btnThemMoi.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnThemMoi_ItemClick);
            // 
            // btnXoa
            // 
            this.btnXoa.Caption = "Xóa";
            this.btnXoa.Id = 2;
            this.btnXoa.ImageIndex = 2;
            this.btnXoa.ItemShortcut = new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D));
            this.btnXoa.Name = "btnXoa";
            toolTipTitleItem3.Text = "Ctrl+D";
            superToolTip3.Items.Add(toolTipTitleItem3);
            this.btnXoa.SuperTip = superToolTip3;
            this.btnXoa.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnXoa_ItemClick);
            // 
            // btn_Refresh
            // 
            this.btn_Refresh.Caption = "Refresh";
            this.btn_Refresh.Id = 8;
            this.btn_Refresh.ImageIndex = 4;
            this.btn_Refresh.ItemShortcut = new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Z));
            this.btn_Refresh.Name = "btn_Refresh";
            this.btn_Refresh.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btn_Refresh_ItemClick);
            // 
            // btnLuu
            // 
            this.btnLuu.Caption = "Lưu";
            this.btnLuu.Id = 3;
            this.btnLuu.ImageIndex = 5;
            this.btnLuu.ItemShortcut = new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S));
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnLuu_ItemClick);
            // 
            // btnThoat
            // 
            this.btnThoat.Caption = "Thoát";
            this.btnThoat.Id = 6;
            this.btnThoat.ImageIndex = 8;
            this.btnThoat.ItemShortcut = new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.X));
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnThoat_ItemClick);
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(694, 32);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 339);
            this.barDockControlBottom.Size = new System.Drawing.Size(694, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 32);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 307);
            // 
            // barDockControl1
            // 
            this.barDockControl1.CausesValidation = false;
            this.barDockControl1.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControl1.Location = new System.Drawing.Point(694, 32);
            this.barDockControl1.Size = new System.Drawing.Size(0, 307);
            // 
            // barButtonItem5
            // 
            this.barButtonItem5.Caption = "Refresh";
            this.barButtonItem5.Id = 4;
            this.barButtonItem5.ImageIndex = 9;
            this.barButtonItem5.Name = "barButtonItem5";
            this.barButtonItem5.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            // 
            // btnPrint
            // 
            this.btnPrint.Caption = "In";
            this.btnPrint.Id = 5;
            this.btnPrint.ImageIndex = 7;
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            // 
            // btnHelp
            // 
            this.btnHelp.Caption = "Trợ giúp";
            this.btnHelp.Id = 7;
            this.btnHelp.ImageIndex = 6;
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            // 
            // panelControl1
            // 
            this.panelControl1.Appearance.BackColor = System.Drawing.Color.LightCyan;
            this.panelControl1.Appearance.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.panelControl1.Appearance.Options.UseBackColor = true;
            this.panelControl1.Controls.Add(this.txt_TenPhanLoaiHD);
            this.panelControl1.Controls.Add(this.labelControl6);
            this.panelControl1.Controls.Add(this.labelControl2);
            this.panelControl1.Controls.Add(this.txt_MaPhanLoaiHDQL);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 32);
            this.panelControl1.LookAndFeel.SkinName = "Office 2010 Silver";
            this.panelControl1.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.UltraFlat;
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(694, 55);
            this.panelControl1.TabIndex = 4;
            // 
            // txt_TenPhanLoaiHD
            // 
            this.txt_TenPhanLoaiHD.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.PhanLoaiHopDongList_bindingSource, "TenPhanLoaiHD", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.txt_TenPhanLoaiHD.Location = new System.Drawing.Point(409, 20);
            this.txt_TenPhanLoaiHD.Name = "txt_TenPhanLoaiHD";
            this.txt_TenPhanLoaiHD.Properties.Appearance.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_TenPhanLoaiHD.Properties.Appearance.Options.UseFont = true;
            this.txt_TenPhanLoaiHD.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            this.txt_TenPhanLoaiHD.Size = new System.Drawing.Size(237, 22);
            this.txt_TenPhanLoaiHD.TabIndex = 1;
            // 
            // PhanLoaiHopDongList_bindingSource
            // 
            this.PhanLoaiHopDongList_bindingSource.DataSource = typeof(ERP_Library.PhanLoaiHopDongList);
            // 
            // labelControl6
            // 
            this.labelControl6.Appearance.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl6.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.labelControl6.LineColor = System.Drawing.Color.Lime;
            this.labelControl6.Location = new System.Drawing.Point(278, 25);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(129, 15);
            this.labelControl6.TabIndex = 13;
            this.labelControl6.Text = "Tên phân loại hợp đồng:";
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl2.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.labelControl2.LineColor = System.Drawing.Color.Lime;
            this.labelControl2.LineVisible = true;
            this.labelControl2.Location = new System.Drawing.Point(72, 24);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(73, 15);
            this.labelControl2.TabIndex = 2;
            this.labelControl2.Text = "Mã phân loại:";
            // 
            // txt_MaPhanLoaiHDQL
            // 
            this.txt_MaPhanLoaiHDQL.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.PhanLoaiHopDongList_bindingSource, "MaPhanLoaiHDQL", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.txt_MaPhanLoaiHDQL.Location = new System.Drawing.Point(148, 20);
            this.txt_MaPhanLoaiHDQL.Name = "txt_MaPhanLoaiHDQL";
            this.txt_MaPhanLoaiHDQL.Properties.Appearance.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_MaPhanLoaiHDQL.Properties.Appearance.Options.UseFont = true;
            this.txt_MaPhanLoaiHDQL.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            this.txt_MaPhanLoaiHDQL.Size = new System.Drawing.Size(113, 22);
            this.txt_MaPhanLoaiHDQL.TabIndex = 0;
            // 
            // loaiHopDongListBindingSource
            // 
            this.loaiHopDongListBindingSource.DataSource = typeof(ERP_Library.LoaiHopDongList);
            // 
            // grd_DSPhanLoaiHopDong
            // 
            this.grd_DSPhanLoaiHopDong.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.grd_DSPhanLoaiHopDong.DataSource = this.PhanLoaiHopDongList_bindingSource;
            this.grd_DSPhanLoaiHopDong.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grd_DSPhanLoaiHopDong.EmbeddedNavigator.Text = "show ra tiêu đề";
            this.grd_DSPhanLoaiHopDong.EmbeddedNavigator.ToolTipTitle = "ToolTipTitle";
            this.grd_DSPhanLoaiHopDong.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grd_DSPhanLoaiHopDong.Location = new System.Drawing.Point(0, 87);
            this.grd_DSPhanLoaiHopDong.LookAndFeel.SkinName = "Office 2010 Silver";
            this.grd_DSPhanLoaiHopDong.LookAndFeel.UseDefaultLookAndFeel = false;
            this.grd_DSPhanLoaiHopDong.MainView = this.gridView_DMPhanLoaiHD;
            this.grd_DSPhanLoaiHopDong.Name = "grd_DSPhanLoaiHopDong";
            this.grd_DSPhanLoaiHopDong.Size = new System.Drawing.Size(694, 252);
            this.grd_DSPhanLoaiHopDong.TabIndex = 5;
            this.grd_DSPhanLoaiHopDong.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView_DMPhanLoaiHD});
            // 
            // gridView_DMPhanLoaiHD
            // 
            this.gridView_DMPhanLoaiHD.Appearance.ViewCaption.Font = new System.Drawing.Font("Times New Roman", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridView_DMPhanLoaiHD.Appearance.ViewCaption.ForeColor = System.Drawing.Color.Red;
            this.gridView_DMPhanLoaiHD.Appearance.ViewCaption.Options.UseFont = true;
            this.gridView_DMPhanLoaiHD.Appearance.ViewCaption.Options.UseForeColor = true;
            this.gridView_DMPhanLoaiHD.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colMaQuanLyXe,
            this.colTenXe});
            this.gridView_DMPhanLoaiHD.GridControl = this.grd_DSPhanLoaiHopDong;
            this.gridView_DMPhanLoaiHD.GroupPanelText = "Danh Mục Loại Hợp Đồng";
            this.gridView_DMPhanLoaiHD.Name = "gridView_DMPhanLoaiHD";
            this.gridView_DMPhanLoaiHD.OptionsBehavior.ReadOnly = true;
            this.gridView_DMPhanLoaiHD.OptionsNavigation.AutoFocusNewRow = true;
            this.gridView_DMPhanLoaiHD.OptionsView.ShowAutoFilterRow = true;
            // 
            // colMaQuanLyXe
            // 
            this.colMaQuanLyXe.AppearanceHeader.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colMaQuanLyXe.AppearanceHeader.ForeColor = System.Drawing.Color.RoyalBlue;
            this.colMaQuanLyXe.AppearanceHeader.Options.UseFont = true;
            this.colMaQuanLyXe.AppearanceHeader.Options.UseForeColor = true;
            this.colMaQuanLyXe.AppearanceHeader.Options.UseTextOptions = true;
            this.colMaQuanLyXe.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colMaQuanLyXe.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colMaQuanLyXe.Caption = "Mã Phân Loại";
            this.colMaQuanLyXe.FieldName = "MaPhanLoaiHDQL";
            this.colMaQuanLyXe.Name = "colMaQuanLyXe";
            this.colMaQuanLyXe.Visible = true;
            this.colMaQuanLyXe.VisibleIndex = 0;
            this.colMaQuanLyXe.Width = 45;
            // 
            // colTenXe
            // 
            this.colTenXe.AppearanceHeader.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colTenXe.AppearanceHeader.ForeColor = System.Drawing.Color.RoyalBlue;
            this.colTenXe.AppearanceHeader.Options.UseFont = true;
            this.colTenXe.AppearanceHeader.Options.UseForeColor = true;
            this.colTenXe.AppearanceHeader.Options.UseTextOptions = true;
            this.colTenXe.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colTenXe.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colTenXe.Caption = "Tên Phân Loại";
            this.colTenXe.FieldName = "TenPhanLoaiHD";
            this.colTenXe.Name = "colTenXe";
            this.colTenXe.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colTenXe.Visible = true;
            this.colTenXe.VisibleIndex = 1;
            this.colTenXe.Width = 90;
            // 
            // FrmPhanLoaiHopDong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(694, 339);
            this.Controls.Add(this.grd_DSPhanLoaiHopDong);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControl1);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "FrmPhanLoaiHopDong";
            this.Text = "Danh Mục Loại Hợp Đồng";
            this.Load += new System.EventHandler(this.FrmPhanLoaiHopDong_Load);
            ((System.ComponentModel.ISupportInitialize)(this.mainMenuBarManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txt_TenPhanLoaiHD.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PhanLoaiHopDongList_bindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_MaPhanLoaiHDQL.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.loaiHopDongListBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grd_DSPhanLoaiHopDong)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_DMPhanLoaiHD)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ImageList imageList1;
        private DevExpress.LookAndFeel.DefaultLookAndFeel defaultLookAndFeel1;
        private DevExpress.XtraBars.BarManager mainMenuBarManager;
        private DevExpress.XtraBars.Bar mainMenuBar;
        private DevExpress.XtraBars.BarButtonItem btnThemMoi;
        private DevExpress.XtraBars.BarButtonItem btnXoa;
        private DevExpress.XtraBars.BarButtonItem btn_Refresh;
        private DevExpress.XtraBars.BarButtonItem btnLuu;
        private DevExpress.XtraBars.BarButtonItem barButtonItem5;
        private DevExpress.XtraBars.BarButtonItem btnPrint;
        private DevExpress.XtraBars.BarButtonItem btnHelp;
        private DevExpress.XtraBars.BarButtonItem btnThoat;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControl1;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.TextEdit txt_TenPhanLoaiHD;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.TextEdit txt_MaPhanLoaiHDQL;
        private DevExpress.XtraGrid.GridControl grd_DSPhanLoaiHopDong;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView_DMPhanLoaiHD;
        private DevExpress.XtraGrid.Columns.GridColumn colMaQuanLyXe;
        private DevExpress.XtraGrid.Columns.GridColumn colTenXe;
        private System.Windows.Forms.BindingSource PhanLoaiHopDongList_bindingSource;
        private System.Windows.Forms.BindingSource loaiHopDongListBindingSource;

    }
}