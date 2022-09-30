namespace PSC_ERP
{
    partial class frmLoaiVanBan
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLoaiVanBan));
            this.LoaiVanBan_BingSource = new System.Windows.Forms.BindingSource(this.components);
            this.btnLuu = new System.Windows.Forms.ToolStripButton();
            this.btnThoat = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.btnXoa = new System.Windows.Forms.ToolStripButton();
            this.tlsMain = new System.Windows.Forms.ToolStrip();
            this.btnThem = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.txtDienGiai = new DevExpress.XtraEditors.TextEdit();
            this.txtTenLoaiVanBan = new DevExpress.XtraEditors.TextEdit();
            this.txtMaQuanLy = new DevExpress.XtraEditors.TextEdit();
            this.dteNgayLap = new DevExpress.XtraEditors.DateEdit();
            this.cbLoaiVanBanCha = new DevExpress.XtraEditors.GridLookUpEdit();
            this.LoaiVanBanCha_BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colMaQuanLy1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTenLoaivanBan1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.layoutControlGroup2 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.itemPhongBan = new DevExpress.XtraLayout.LayoutControlItem();
            this.itemNgayKiemKe = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.LoaiVanBan_TreeList = new DevExpress.XtraTreeList.TreeList();
            this.colMaQuanLy = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colTenLoaivanBan = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.btnTimKiem = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txtThongTin = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.LoaiVanBan_BingSource)).BeginInit();
            this.tlsMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDienGiai.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTenLoaiVanBan.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaQuanLy.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dteNgayLap.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dteNgayLap.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbLoaiVanBanCha.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LoaiVanBanCha_BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemPhongBan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemNgayKiemKe)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LoaiVanBan_TreeList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtThongTin.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // LoaiVanBan_BingSource
            // 
            this.LoaiVanBan_BingSource.AllowNew = true;
            this.LoaiVanBan_BingSource.DataSource = typeof(ERP_Library.LoaiVanBanList);
            // 
            // btnLuu
            // 
            this.btnLuu.Image = ((System.Drawing.Image)(resources.GetObject("btnLuu.Image")));
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(52, 23);
            this.btnLuu.Text = "&Lưu";
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // btnThoat
            // 
            this.btnThoat.Image = ((System.Drawing.Image)(resources.GetObject("btnThoat.Image")));
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(64, 23);
            this.btnThoat.Text = "Thoát";
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // toolStripSeparator
            // 
            this.toolStripSeparator.Name = "toolStripSeparator";
            this.toolStripSeparator.Size = new System.Drawing.Size(6, 26);
            // 
            // btnXoa
            // 
            this.btnXoa.Image = ((System.Drawing.Image)(resources.GetObject("btnXoa.Image")));
            this.btnXoa.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(52, 23);
            this.btnXoa.Text = "&Xóa";
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // tlsMain
            // 
            this.tlsMain.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.tlsMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnThem,
            this.btnLuu,
            this.toolStripSeparator,
            this.btnXoa,
            this.toolStripSeparator1,
            this.btnThoat});
            this.tlsMain.Location = new System.Drawing.Point(0, 0);
            this.tlsMain.Name = "tlsMain";
            this.tlsMain.Size = new System.Drawing.Size(792, 26);
            this.tlsMain.TabIndex = 0;
            this.tlsMain.Text = "toolStrip1";
            // 
            // btnThem
            // 
            this.btnThem.Image = ((System.Drawing.Image)(resources.GetObject("btnThem.Image")));
            this.btnThem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(63, 23);
            this.btnThem.Text = "&Thêm";
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 26);
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.Size = new System.Drawing.Size(320, 392);
            this.layoutControlGroup1.Text = "Root";
            this.layoutControlGroup1.TextVisible = false;
            // 
            // groupControl1
            // 
            this.groupControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 9F);
            this.groupControl1.Appearance.Options.UseFont = true;
            this.groupControl1.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 10F);
            this.groupControl1.AppearanceCaption.Options.UseFont = true;
            this.groupControl1.Controls.Add(this.layoutControl1);
            this.groupControl1.Location = new System.Drawing.Point(472, 37);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(320, 397);
            this.groupControl1.TabIndex = 33;
            this.groupControl1.Text = "Thông Tin Chi Tiết";
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.txtDienGiai);
            this.layoutControl1.Controls.Add(this.txtTenLoaiVanBan);
            this.layoutControl1.Controls.Add(this.txtMaQuanLy);
            this.layoutControl1.Controls.Add(this.dteNgayLap);
            this.layoutControl1.Controls.Add(this.cbLoaiVanBanCha);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(2, 24);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(960, 157, 250, 350);
            this.layoutControl1.Root = this.layoutControlGroup2;
            this.layoutControl1.Size = new System.Drawing.Size(316, 371);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // txtDienGiai
            // 
            this.txtDienGiai.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.LoaiVanBan_BingSource, "DienGiai", true));
            this.txtDienGiai.Location = new System.Drawing.Point(110, 108);
            this.txtDienGiai.Name = "txtDienGiai";
            this.txtDienGiai.Size = new System.Drawing.Size(194, 20);
            this.txtDienGiai.StyleController = this.layoutControl1;
            this.txtDienGiai.TabIndex = 4;
            // 
            // txtTenLoaiVanBan
            // 
            this.txtTenLoaiVanBan.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.LoaiVanBan_BingSource, "TenLoaivanBan", true));
            this.txtTenLoaiVanBan.Location = new System.Drawing.Point(110, 36);
            this.txtTenLoaiVanBan.Name = "txtTenLoaiVanBan";
            this.txtTenLoaiVanBan.Size = new System.Drawing.Size(194, 20);
            this.txtTenLoaiVanBan.StyleController = this.layoutControl1;
            this.txtTenLoaiVanBan.TabIndex = 1;
            // 
            // txtMaQuanLy
            // 
            this.txtMaQuanLy.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.LoaiVanBan_BingSource, "MaQuanLy", true));
            this.txtMaQuanLy.Location = new System.Drawing.Point(110, 12);
            this.txtMaQuanLy.Name = "txtMaQuanLy";
            this.txtMaQuanLy.Size = new System.Drawing.Size(194, 20);
            this.txtMaQuanLy.StyleController = this.layoutControl1;
            this.txtMaQuanLy.TabIndex = 0;
            // 
            // dteNgayLap
            // 
            this.dteNgayLap.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.LoaiVanBan_BingSource, "NgayLap", true));
            this.dteNgayLap.EditValue = null;
            this.dteNgayLap.Location = new System.Drawing.Point(110, 60);
            this.dteNgayLap.Name = "dteNgayLap";
            this.dteNgayLap.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dteNgayLap.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dteNgayLap.Properties.CalendarTimeProperties.CloseUpKey = new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.F4);
            this.dteNgayLap.Properties.CalendarTimeProperties.PopupBorderStyle = DevExpress.XtraEditors.Controls.PopupBorderStyles.Default;
            this.dteNgayLap.Properties.Mask.EditMask = "dd/MM/yyyy";
            this.dteNgayLap.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.dteNgayLap.Size = new System.Drawing.Size(194, 20);
            this.dteNgayLap.StyleController = this.layoutControl1;
            this.dteNgayLap.TabIndex = 2;
            // 
            // cbLoaiVanBanCha
            // 
            this.cbLoaiVanBanCha.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.LoaiVanBan_BingSource, "MaLoaiCha", true));
            this.cbLoaiVanBanCha.EditValue = 0;
            this.cbLoaiVanBanCha.Location = new System.Drawing.Point(110, 84);
            this.cbLoaiVanBanCha.Name = "cbLoaiVanBanCha";
            this.cbLoaiVanBanCha.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbLoaiVanBanCha.Properties.DataSource = this.LoaiVanBanCha_BindingSource;
            this.cbLoaiVanBanCha.Properties.DisplayMember = "TenLoaivanBan";
            this.cbLoaiVanBanCha.Properties.NullText = "<<Không chọn>>";
            this.cbLoaiVanBanCha.Properties.ValueMember = "MaLoaiVanBan";
            this.cbLoaiVanBanCha.Properties.View = this.gridView1;
            this.cbLoaiVanBanCha.Size = new System.Drawing.Size(194, 20);
            this.cbLoaiVanBanCha.StyleController = this.layoutControl1;
            this.cbLoaiVanBanCha.TabIndex = 3;
            // 
            // LoaiVanBanCha_BindingSource
            // 
            this.LoaiVanBanCha_BindingSource.AllowNew = true;
            this.LoaiVanBanCha_BindingSource.DataSource = typeof(ERP_Library.LoaiVanBanList);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colMaQuanLy1,
            this.colTenLoaivanBan1});
            this.gridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // colMaQuanLy1
            // 
            this.colMaQuanLy1.AppearanceHeader.Options.UseTextOptions = true;
            this.colMaQuanLy1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colMaQuanLy1.Caption = "Mã Quản Lý";
            this.colMaQuanLy1.FieldName = "MaQuanLy";
            this.colMaQuanLy1.Name = "colMaQuanLy1";
            this.colMaQuanLy1.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colMaQuanLy1.Visible = true;
            this.colMaQuanLy1.VisibleIndex = 0;
            // 
            // colTenLoaivanBan1
            // 
            this.colTenLoaivanBan1.AppearanceHeader.Options.UseTextOptions = true;
            this.colTenLoaivanBan1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colTenLoaivanBan1.Caption = "Tên Loại Văn Bản";
            this.colTenLoaivanBan1.FieldName = "TenLoaivanBan";
            this.colTenLoaivanBan1.Name = "colTenLoaivanBan1";
            this.colTenLoaivanBan1.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colTenLoaivanBan1.Visible = true;
            this.colTenLoaivanBan1.VisibleIndex = 1;
            // 
            // layoutControlGroup2
            // 
            this.layoutControlGroup2.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 9F);
            this.layoutControlGroup2.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlGroup2.CustomizationFormText = "layoutControlGroup1";
            this.layoutControlGroup2.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup2.GroupBordersVisible = false;
            this.layoutControlGroup2.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.itemPhongBan,
            this.itemNgayKiemKe,
            this.layoutControlItem1,
            this.layoutControlItem3,
            this.layoutControlItem4});
            this.layoutControlGroup2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup2.Name = "Root";
            this.layoutControlGroup2.Size = new System.Drawing.Size(316, 371);
            this.layoutControlGroup2.Text = "Root";
            this.layoutControlGroup2.TextVisible = false;
            // 
            // itemPhongBan
            // 
            this.itemPhongBan.Control = this.cbLoaiVanBanCha;
            this.itemPhongBan.CustomizationFormText = "Phòng ban";
            this.itemPhongBan.Location = new System.Drawing.Point(0, 72);
            this.itemPhongBan.Name = "itemPhongBan";
            this.itemPhongBan.Size = new System.Drawing.Size(296, 24);
            this.itemPhongBan.Text = "Văn Bản Cha";
            this.itemPhongBan.TextSize = new System.Drawing.Size(95, 14);
            // 
            // itemNgayKiemKe
            // 
            this.itemNgayKiemKe.Control = this.dteNgayLap;
            this.itemNgayKiemKe.CustomizationFormText = "Ngày kiểm kê";
            this.itemNgayKiemKe.Location = new System.Drawing.Point(0, 48);
            this.itemNgayKiemKe.Name = "itemNgayKiemKe";
            this.itemNgayKiemKe.Size = new System.Drawing.Size(296, 24);
            this.itemNgayKiemKe.Text = "Ngày Lập";
            this.itemNgayKiemKe.TextSize = new System.Drawing.Size(95, 14);
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.txtMaQuanLy;
            this.layoutControlItem1.CustomizationFormText = "Mã Quản Lý";
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(296, 24);
            this.layoutControlItem1.Text = "Mã Quản Lý";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(95, 14);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.txtTenLoaiVanBan;
            this.layoutControlItem3.CustomizationFormText = "Tên Loại Văn Bản";
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 24);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(296, 24);
            this.layoutControlItem3.Text = "Tên Loại Văn Bản";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(95, 14);
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 9F);
            this.layoutControlItem4.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem4.Control = this.txtDienGiai;
            this.layoutControlItem4.CustomizationFormText = "Diễn Giải";
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 96);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(296, 255);
            this.layoutControlItem4.Text = "Diễn Giải";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(95, 14);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.txtMaQuanLy;
            this.layoutControlItem2.CustomizationFormText = "Mã Quản Lý";
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem2.Name = "layoutControlItem1";
            this.layoutControlItem2.Size = new System.Drawing.Size(296, 24);
            this.layoutControlItem2.Text = "Mã Quản Lý";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(61, 13);
            this.layoutControlItem2.TextToControlDistance = 5;
            // 
            // groupControl2
            // 
            this.groupControl2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 9F);
            this.groupControl2.Appearance.Options.UseFont = true;
            this.groupControl2.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 10F);
            this.groupControl2.AppearanceCaption.Options.UseFont = true;
            this.groupControl2.Controls.Add(this.LoaiVanBan_TreeList);
            this.groupControl2.Controls.Add(this.btnTimKiem);
            this.groupControl2.Controls.Add(this.labelControl1);
            this.groupControl2.Controls.Add(this.txtThongTin);
            this.groupControl2.Location = new System.Drawing.Point(0, 37);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(466, 384);
            this.groupControl2.TabIndex = 34;
            this.groupControl2.Text = "Danh Sách Loại Văn Bản";
            // 
            // LoaiVanBan_TreeList
            // 
            this.LoaiVanBan_TreeList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.LoaiVanBan_TreeList.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.colMaQuanLy,
            this.colTenLoaivanBan});
            this.LoaiVanBan_TreeList.DataSource = this.LoaiVanBan_BingSource;
            this.LoaiVanBan_TreeList.KeyFieldName = "MaLoaiVanBan";
            this.LoaiVanBan_TreeList.Location = new System.Drawing.Point(5, 54);
            this.LoaiVanBan_TreeList.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003;
            this.LoaiVanBan_TreeList.Name = "LoaiVanBan_TreeList";
            this.LoaiVanBan_TreeList.OptionsBehavior.AutoFocusNewNode = true;
            this.LoaiVanBan_TreeList.OptionsView.ShowSummaryFooter = true;
            this.LoaiVanBan_TreeList.ParentFieldName = "MaLoaiCha";
            this.LoaiVanBan_TreeList.Size = new System.Drawing.Size(456, 328);
            this.LoaiVanBan_TreeList.TabIndex = 4;
            // 
            // colMaQuanLy
            // 
            this.colMaQuanLy.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colMaQuanLy.AppearanceHeader.Options.UseFont = true;
            this.colMaQuanLy.AppearanceHeader.Options.UseTextOptions = true;
            this.colMaQuanLy.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colMaQuanLy.Caption = "Mã Quản Lý";
            this.colMaQuanLy.FieldName = "MaQuanLy";
            this.colMaQuanLy.Name = "colMaQuanLy";
            this.colMaQuanLy.OptionsFilter.AutoFilterCondition = DevExpress.XtraTreeList.Columns.AutoFilterCondition.Contains;
            this.colMaQuanLy.Visible = true;
            this.colMaQuanLy.VisibleIndex = 0;
            this.colMaQuanLy.Width = 187;
            // 
            // colTenLoaivanBan
            // 
            this.colTenLoaivanBan.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colTenLoaivanBan.AppearanceHeader.Options.UseFont = true;
            this.colTenLoaivanBan.AppearanceHeader.Options.UseTextOptions = true;
            this.colTenLoaivanBan.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colTenLoaivanBan.Caption = "Tên Loại Văn Bản";
            this.colTenLoaivanBan.FieldName = "TenLoaivanBan";
            this.colTenLoaivanBan.Name = "colTenLoaivanBan";
            this.colTenLoaivanBan.OptionsFilter.AutoFilterCondition = DevExpress.XtraTreeList.Columns.AutoFilterCondition.Contains;
            this.colTenLoaivanBan.Visible = true;
            this.colTenLoaivanBan.VisibleIndex = 1;
            this.colTenLoaivanBan.Width = 251;
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.Appearance.Font = new System.Drawing.Font("Tahoma", 9F);
            this.btnTimKiem.Appearance.Options.UseFont = true;
            this.btnTimKiem.Location = new System.Drawing.Point(340, 27);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(68, 23);
            this.btnTimKiem.TabIndex = 3;
            this.btnTimKiem.Text = "Tìm";
            this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 9F);
            this.labelControl1.Location = new System.Drawing.Point(32, 31);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(74, 14);
            this.labelControl1.TabIndex = 2;
            this.labelControl1.Text = "Thông tin tìm";
            // 
            // txtThongTin
            // 
            this.txtThongTin.Location = new System.Drawing.Point(112, 28);
            this.txtThongTin.Name = "txtThongTin";
            this.txtThongTin.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9F);
            this.txtThongTin.Properties.Appearance.Options.UseFont = true;
            this.txtThongTin.Size = new System.Drawing.Size(222, 20);
            this.txtThongTin.TabIndex = 1;
            this.txtThongTin.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtThongTin_KeyDown);
            // 
            // frmLoaiVanBan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 426);
            this.Controls.Add(this.groupControl2);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.tlsMain);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmLoaiVanBan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Loại Văn Bản";
            this.Load += new System.EventHandler(this.frmLoaiVanBan_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmLoaiVanBan_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.LoaiVanBan_BingSource)).EndInit();
            this.tlsMain.ResumeLayout(false);
            this.tlsMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtDienGiai.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTenLoaiVanBan.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaQuanLy.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dteNgayLap.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dteNgayLap.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbLoaiVanBanCha.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LoaiVanBanCha_BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemPhongBan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemNgayKiemKe)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            this.groupControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LoaiVanBan_TreeList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtThongTin.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource LoaiVanBan_BingSource;
        private System.Windows.Forms.ToolStripButton btnLuu;
        private System.Windows.Forms.ToolStripButton btnThoat;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator;
        private System.Windows.Forms.ToolStripButton btnXoa;
        private System.Windows.Forms.ToolStrip tlsMain;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraEditors.DateEdit dteNgayLap;
        private DevExpress.XtraEditors.GridLookUpEdit cbLoaiVanBanCha;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup2;
        private DevExpress.XtraLayout.LayoutControlItem itemPhongBan;
        private DevExpress.XtraLayout.LayoutControlItem itemNgayKiemKe;
        private DevExpress.XtraEditors.TextEdit txtMaQuanLy;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraEditors.TextEdit txtTenLoaiVanBan;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraEditors.TextEdit txtDienGiai;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private System.Windows.Forms.BindingSource LoaiVanBanCha_BindingSource;
        private System.Windows.Forms.ToolStripButton btnThem;
        private DevExpress.XtraGrid.Columns.GridColumn colMaQuanLy1;
        private DevExpress.XtraGrid.Columns.GridColumn colTenLoaivanBan1;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraEditors.SimpleButton btnTimKiem;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit txtThongTin;
        private DevExpress.XtraTreeList.TreeList LoaiVanBan_TreeList;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colMaQuanLy;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colTenLoaivanBan;
    }
}