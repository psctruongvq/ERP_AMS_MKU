namespace PSC_ERP
{
    partial class frmLoaiThueThuNhap
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
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand1 = new Infragistics.Win.UltraWinGrid.UltraGridBand("LoaiThueThuNhap", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn5 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("MaThueThuNhap");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn3 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("TienToiThieu");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn1 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("TienToiDa");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn4 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("PhanTramThue");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn2 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("GhiChu", -1, null, 0, Infragistics.Win.UltraWinGrid.SortIndicator.Ascending, false);
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLoaiThueThuNhap));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.nmu_Thue = new Infragistics.Win.UltraWinEditors.UltraNumericEditor();
            this.loaiThueThuNhapListBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.nmu_MucToiDa = new Infragistics.Win.UltraWinEditors.UltraNumericEditor();
            this.nmu_MucToiThieu = new Infragistics.Win.UltraWinEditors.UltraNumericEditor();
            this.txt_GhiChu = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.grd_LoaiThueThuNhap = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.tlsMain = new System.Windows.Forms.ToolStrip();
            this.tlslblThem = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tlslblLuu = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tlslblXoa = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tlslblUndo = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.tlslblTim = new System.Windows.Forms.ToolStripButton();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripSeparator();
            this.tlslblIn = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripSeparator();
            this.tlslblTroGiup = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.tlslblThoat = new System.Windows.Forms.ToolStripButton();
            this.tlslblExportExcel = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmu_Thue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.loaiThueThuNhapListBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmu_MucToiDa)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmu_MucToiThieu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grd_LoaiThueThuNhap)).BeginInit();
            this.tlsMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.nmu_Thue);
            this.groupBox1.Controls.Add(this.nmu_MucToiDa);
            this.groupBox1.Controls.Add(this.nmu_MucToiThieu);
            this.groupBox1.Controls.Add(this.txt_GhiChu);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 35);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(531, 92);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông Tin";
            // 
            // nmu_Thue
            // 
            this.nmu_Thue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.nmu_Thue.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.loaiThueThuNhapListBindingSource, "PhanTramThue", true));
            this.nmu_Thue.Location = new System.Drawing.Point(454, 20);
            this.nmu_Thue.MaskInput = "nnnnnnnnn";
            this.nmu_Thue.Name = "nmu_Thue";
            this.nmu_Thue.PromptChar = ' ';
            this.nmu_Thue.Size = new System.Drawing.Size(50, 21);
            this.nmu_Thue.TabIndex = 2;
            // 
            // loaiThueThuNhapListBindingSource
            // 
            this.loaiThueThuNhapListBindingSource.DataSource = typeof(ERP_Library.LoaiThueThuNhapList);
            // 
            // nmu_MucToiDa
            // 
            this.nmu_MucToiDa.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.loaiThueThuNhapListBindingSource, "TienToiDa", true));
            this.nmu_MucToiDa.Location = new System.Drawing.Point(253, 20);
            this.nmu_MucToiDa.MaskInput = "{LOC}nnn,nnn,nnn,nnn,nnn";
            this.nmu_MucToiDa.Name = "nmu_MucToiDa";
            this.nmu_MucToiDa.PromptChar = ' ';
            this.nmu_MucToiDa.Size = new System.Drawing.Size(100, 21);
            this.nmu_MucToiDa.TabIndex = 2;
            // 
            // nmu_MucToiThieu
            // 
            this.nmu_MucToiThieu.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.loaiThueThuNhapListBindingSource, "TienToiThieu", true));
            this.nmu_MucToiThieu.Location = new System.Drawing.Point(79, 20);
            this.nmu_MucToiThieu.MaskInput = "{LOC}nnn,nnn,nnn,nnn,nnn";
            this.nmu_MucToiThieu.Name = "nmu_MucToiThieu";
            this.nmu_MucToiThieu.PromptChar = ' ';
            this.nmu_MucToiThieu.Size = new System.Drawing.Size(100, 21);
            this.nmu_MucToiThieu.TabIndex = 2;
            // 
            // txt_GhiChu
            // 
            this.txt_GhiChu.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_GhiChu.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.loaiThueThuNhapListBindingSource, "GhiChu", true));
            this.txt_GhiChu.Location = new System.Drawing.Point(79, 49);
            this.txt_GhiChu.Multiline = true;
            this.txt_GhiChu.Name = "txt_GhiChu";
            this.txt_GhiChu.Size = new System.Drawing.Size(443, 37);
            this.txt_GhiChu.TabIndex = 1;
            this.txt_GhiChu.TextChanged += new System.EventHandler(this.txt_GhiChu_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(189, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Mức tối đa";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(510, 24);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(15, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "%";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(364, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Phần Trăm Thuế";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 62);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Ghi Chú";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mức tối thiểu";
            // 
            // grd_LoaiThueThuNhap
            // 
            this.grd_LoaiThueThuNhap.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grd_LoaiThueThuNhap.DataSource = this.loaiThueThuNhapListBindingSource;
            appearance1.BackColor = System.Drawing.SystemColors.Window;
            appearance1.BorderColor = System.Drawing.SystemColors.InactiveCaption;
            this.grd_LoaiThueThuNhap.DisplayLayout.Appearance = appearance1;
            ultraGridColumn5.Header.VisiblePosition = 4;
            ultraGridColumn3.Header.VisiblePosition = 2;
            ultraGridColumn1.Header.VisiblePosition = 0;
            ultraGridColumn4.Header.VisiblePosition = 3;
            ultraGridColumn2.Header.VisiblePosition = 1;
            ultraGridBand1.Columns.AddRange(new object[] {
            ultraGridColumn5,
            ultraGridColumn3,
            ultraGridColumn1,
            ultraGridColumn4,
            ultraGridColumn2});
            this.grd_LoaiThueThuNhap.DisplayLayout.BandsSerializer.Add(ultraGridBand1);
            this.grd_LoaiThueThuNhap.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.grd_LoaiThueThuNhap.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            appearance2.BackColor = System.Drawing.SystemColors.ActiveBorder;
            appearance2.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance2.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance2.BorderColor = System.Drawing.SystemColors.Window;
            this.grd_LoaiThueThuNhap.DisplayLayout.GroupByBox.Appearance = appearance2;
            appearance3.ForeColor = System.Drawing.SystemColors.GrayText;
            this.grd_LoaiThueThuNhap.DisplayLayout.GroupByBox.BandLabelAppearance = appearance3;
            this.grd_LoaiThueThuNhap.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.grd_LoaiThueThuNhap.DisplayLayout.GroupByBox.Hidden = true;
            appearance4.BackColor = System.Drawing.SystemColors.ControlLightLight;
            appearance4.BackColor2 = System.Drawing.SystemColors.Control;
            appearance4.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance4.ForeColor = System.Drawing.SystemColors.GrayText;
            this.grd_LoaiThueThuNhap.DisplayLayout.GroupByBox.PromptAppearance = appearance4;
            this.grd_LoaiThueThuNhap.DisplayLayout.MaxColScrollRegions = 1;
            this.grd_LoaiThueThuNhap.DisplayLayout.MaxRowScrollRegions = 1;
            appearance5.BackColor = System.Drawing.SystemColors.Window;
            appearance5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.grd_LoaiThueThuNhap.DisplayLayout.Override.ActiveCellAppearance = appearance5;
            appearance6.BackColor = System.Drawing.SystemColors.Highlight;
            appearance6.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.grd_LoaiThueThuNhap.DisplayLayout.Override.ActiveRowAppearance = appearance6;
            this.grd_LoaiThueThuNhap.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted;
            this.grd_LoaiThueThuNhap.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted;
            appearance7.BackColor = System.Drawing.SystemColors.Window;
            this.grd_LoaiThueThuNhap.DisplayLayout.Override.CardAreaAppearance = appearance7;
            appearance8.BorderColor = System.Drawing.Color.Silver;
            appearance8.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter;
            this.grd_LoaiThueThuNhap.DisplayLayout.Override.CellAppearance = appearance8;
            this.grd_LoaiThueThuNhap.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText;
            this.grd_LoaiThueThuNhap.DisplayLayout.Override.CellPadding = 0;
            appearance9.BackColor = System.Drawing.SystemColors.Control;
            appearance9.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance9.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element;
            appearance9.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance9.BorderColor = System.Drawing.SystemColors.Window;
            this.grd_LoaiThueThuNhap.DisplayLayout.Override.GroupByRowAppearance = appearance9;
            appearance10.TextHAlignAsString = "Left";
            this.grd_LoaiThueThuNhap.DisplayLayout.Override.HeaderAppearance = appearance10;
            this.grd_LoaiThueThuNhap.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            this.grd_LoaiThueThuNhap.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand;
            appearance11.BackColor = System.Drawing.SystemColors.Window;
            appearance11.BorderColor = System.Drawing.Color.Silver;
            this.grd_LoaiThueThuNhap.DisplayLayout.Override.RowAppearance = appearance11;
            this.grd_LoaiThueThuNhap.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
            appearance12.BackColor = System.Drawing.SystemColors.ControlLight;
            this.grd_LoaiThueThuNhap.DisplayLayout.Override.TemplateAddRowAppearance = appearance12;
            this.grd_LoaiThueThuNhap.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.grd_LoaiThueThuNhap.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.grd_LoaiThueThuNhap.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy;
            this.grd_LoaiThueThuNhap.Location = new System.Drawing.Point(12, 137);
            this.grd_LoaiThueThuNhap.Name = "grd_LoaiThueThuNhap";
            this.grd_LoaiThueThuNhap.Size = new System.Drawing.Size(531, 210);
            this.grd_LoaiThueThuNhap.TabIndex = 1;
            this.grd_LoaiThueThuNhap.Text = "ultraGrid1";
            this.grd_LoaiThueThuNhap.InitializeLayout += new Infragistics.Win.UltraWinGrid.InitializeLayoutEventHandler(this.grd_LoaiThueThuNhap_InitializeLayout);
            // 
            // tlsMain
            // 
            this.tlsMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tlslblThem,
            this.toolStripSeparator1,
            this.tlslblLuu,
            this.toolStripSeparator2,
            this.tlslblXoa,
            this.toolStripSeparator3,
            this.tlslblUndo,
            this.toolStripSeparator4,
            this.tlslblTim,
            this.toolStripLabel1,
            this.tlslblExportExcel,
            this.toolStripSeparator6,
            this.tlslblIn,
            this.toolStripButton1,
            this.tlslblTroGiup,
            this.toolStripSeparator5,
            this.tlslblThoat});
            this.tlsMain.Location = new System.Drawing.Point(0, 0);
            this.tlsMain.Name = "tlsMain";
            this.tlsMain.Size = new System.Drawing.Size(551, 25);
            this.tlsMain.TabIndex = 33;
            this.tlsMain.Text = "toolStrip1";
            // 
            // tlslblThem
            // 
            this.tlslblThem.Image = ((System.Drawing.Image)(resources.GetObject("tlslblThem.Image")));
            this.tlslblThem.Name = "tlslblThem";
            this.tlslblThem.Size = new System.Drawing.Size(58, 22);
            this.tlslblThem.Text = "Thêm";
            this.tlslblThem.Click += new System.EventHandler(this.thêmToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // tlslblLuu
            // 
            this.tlslblLuu.Image = ((System.Drawing.Image)(resources.GetObject("tlslblLuu.Image")));
            this.tlslblLuu.Name = "tlslblLuu";
            this.tlslblLuu.Size = new System.Drawing.Size(47, 22);
            this.tlslblLuu.Text = "Lưu";
            this.tlslblLuu.Click += new System.EventHandler(this.tlslblLuu_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // tlslblXoa
            // 
            this.tlslblXoa.Image = ((System.Drawing.Image)(resources.GetObject("tlslblXoa.Image")));
            this.tlslblXoa.Name = "tlslblXoa";
            this.tlslblXoa.Size = new System.Drawing.Size(47, 22);
            this.tlslblXoa.Text = "Xóa";
            this.tlslblXoa.Click += new System.EventHandler(this.xóaToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // tlslblUndo
            // 
            this.tlslblUndo.Image = ((System.Drawing.Image)(resources.GetObject("tlslblUndo.Image")));
            this.tlslblUndo.Name = "tlslblUndo";
            this.tlslblUndo.Size = new System.Drawing.Size(56, 22);
            this.tlslblUndo.Text = "Undo";
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // tlslblTim
            // 
            this.tlslblTim.Image = ((System.Drawing.Image)(resources.GetObject("tlslblTim.Image")));
            this.tlslblTim.Name = "tlslblTim";
            this.tlslblTim.Size = new System.Drawing.Size(48, 22);
            this.tlslblTim.Text = "Tìm";
            this.tlslblTim.Visible = false;
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(6, 25);
            this.toolStripLabel1.Visible = false;
            // 
            // tlslblIn
            // 
            this.tlslblIn.Image = ((System.Drawing.Image)(resources.GetObject("tlslblIn.Image")));
            this.tlslblIn.Name = "tlslblIn";
            this.tlslblIn.Size = new System.Drawing.Size(37, 22);
            this.tlslblIn.Text = "In";
            this.tlslblIn.Click += new System.EventHandler(this.tlslblIn_Click);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(6, 25);
            // 
            // tlslblTroGiup
            // 
            this.tlslblTroGiup.Image = ((System.Drawing.Image)(resources.GetObject("tlslblTroGiup.Image")));
            this.tlslblTroGiup.Name = "tlslblTroGiup";
            this.tlslblTroGiup.Size = new System.Drawing.Size(73, 22);
            this.tlslblTroGiup.Text = "Trợ Giúp";
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 25);
            // 
            // tlslblThoat
            // 
            this.tlslblThoat.Image = ((System.Drawing.Image)(resources.GetObject("tlslblThoat.Image")));
            this.tlslblThoat.Name = "tlslblThoat";
            this.tlslblThoat.Size = new System.Drawing.Size(58, 20);
            this.tlslblThoat.Text = "Thoát";
            this.tlslblThoat.Click += new System.EventHandler(this.thoatToolStripMenuItem_Click);
            // 
            // tlslblExportExcel
            // 
            this.tlslblExportExcel.Image = ((System.Drawing.Image)(resources.GetObject("tlslblExportExcel.Image")));
            this.tlslblExportExcel.Name = "tlslblExportExcel";
            this.tlslblExportExcel.Size = new System.Drawing.Size(80, 22);
            this.tlslblExportExcel.Text = "&Xuất Excel";
            this.tlslblExportExcel.Click += new System.EventHandler(this.tlslblExportExcel_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 25);
            this.toolStripSeparator6.Visible = false;
            // 
            // frmLoaiThueThuNhap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(551, 357);
            this.Controls.Add(this.tlsMain);
            this.Controls.Add(this.grd_LoaiThueThuNhap);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmLoaiThueThuNhap";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Loại Thuế Thu Nhập";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmu_Thue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.loaiThueThuNhapListBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmu_MucToiDa)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmu_MucToiThieu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grd_LoaiThueThuNhap)).EndInit();
            this.tlsMain.ResumeLayout(false);
            this.tlsMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private Infragistics.Win.UltraWinGrid.UltraGrid grd_LoaiThueThuNhap;
        private System.Windows.Forms.ToolStrip tlsMain;
        private System.Windows.Forms.ToolStripButton tlslblThem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tlslblLuu;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton tlslblXoa;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton tlslblUndo;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton tlslblTim;
        private System.Windows.Forms.ToolStripSeparator toolStripLabel1;
        private System.Windows.Forms.ToolStripButton tlslblIn;
        private System.Windows.Forms.ToolStripSeparator toolStripButton1;
        private System.Windows.Forms.ToolStripButton tlslblTroGiup;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripButton tlslblThoat;
        private System.Windows.Forms.TextBox txt_GhiChu;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private Infragistics.Win.UltraWinEditors.UltraNumericEditor nmu_Thue;
        private Infragistics.Win.UltraWinEditors.UltraNumericEditor nmu_MucToiDa;
        private Infragistics.Win.UltraWinEditors.UltraNumericEditor nmu_MucToiThieu;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.BindingSource loaiThueThuNhapListBindingSource;
        private System.Windows.Forms.ToolStripButton tlslblExportExcel;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
    }
}