namespace PSC_ERP
{
    partial class frmToKhaiThue
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
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand1 = new Infragistics.Win.UltraWinGrid.UltraGridBand("CT_ToKhaiThue", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn1 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("TenHangHoa");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn2 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("MaDonViTinh");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn3 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("PhanTramThueNK");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn4 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ThueSuatTTDB");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn5 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("MaChiTiet");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn6 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("PhanTramThuKhac", -1, null, 0, Infragistics.Win.UltraWinGrid.SortIndicator.Ascending, false);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn7 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ThanhTien");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn8 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("PhanTramThueVAT");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn9 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ThueSuatVAT");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn10 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("KhoiLuong");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn11 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("MaHangHoa");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn12 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ThueSuatNK");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn13 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("SoTienThuKhac");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn14 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("TenDonViTinh");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn15 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("PhanTramThueTTDB");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn16 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("DonGia");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn17 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("MaToKhaiThue");
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmToKhaiThue));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.numu_TyGia = new Infragistics.Win.UltraWinEditors.UltraNumericEditor();
            this.cb_LoaiTien = new System.Windows.Forms.ComboBox();
            this.ceru_SoTienQuyDoi = new Infragistics.Win.UltraWinEditors.UltraCurrencyEditor();
            this.crcu_SoTien = new Infragistics.Win.UltraWinEditors.UltraCurrencyEditor();
            this.dtp_NgayKhai = new System.Windows.Forms.DateTimePicker();
            this.txt_SoToKhaiThue = new System.Windows.Forms.TextBox();
            this.txt_VietBangChu = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.grdu_CTToKhaiThue = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.tlsMain = new System.Windows.Forms.ToolStrip();
            this.tlslblLuu = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tlslblXoa = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tlslblUndo = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.tlslblTroGiup = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.tlslblThoat = new System.Windows.Forms.ToolStripButton();
            this.cTToKhaiThueListBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ToKhaiThuebindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.loaiTienListBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numu_TyGia)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ceru_SoTienQuyDoi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.crcu_SoTien)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdu_CTToKhaiThue)).BeginInit();
            this.tlsMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cTToKhaiThueListBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ToKhaiThuebindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.loaiTienListBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.numu_TyGia);
            this.groupBox1.Controls.Add(this.cb_LoaiTien);
            this.groupBox1.Controls.Add(this.ceru_SoTienQuyDoi);
            this.groupBox1.Controls.Add(this.crcu_SoTien);
            this.groupBox1.Controls.Add(this.dtp_NgayKhai);
            this.groupBox1.Controls.Add(this.txt_SoToKhaiThue);
            this.groupBox1.Controls.Add(this.txt_VietBangChu);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 34);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(502, 122);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông Tin Tờ Khai Thuế";
            // 
            // numu_TyGia
            // 
            this.numu_TyGia.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.ToKhaiThuebindingSource, "TyGia", true));
            this.numu_TyGia.Location = new System.Drawing.Point(100, 72);
            this.numu_TyGia.Name = "numu_TyGia";
            this.numu_TyGia.PromptChar = ' ';
            this.numu_TyGia.ReadOnly = true;
            this.numu_TyGia.Size = new System.Drawing.Size(150, 21);
            this.numu_TyGia.TabIndex = 4;
            // 
            // cb_LoaiTien
            // 
            this.cb_LoaiTien.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cb_LoaiTien.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.ToKhaiThuebindingSource, "MaLoaiTien", true));
            this.cb_LoaiTien.DataSource = this.loaiTienListBindingSource;
            this.cb_LoaiTien.DisplayMember = "TenLoaiTien";
            this.cb_LoaiTien.FormattingEnabled = true;
            this.cb_LoaiTien.Location = new System.Drawing.Point(361, 46);
            this.cb_LoaiTien.Name = "cb_LoaiTien";
            this.cb_LoaiTien.Size = new System.Drawing.Size(118, 21);
            this.cb_LoaiTien.TabIndex = 3;
            this.cb_LoaiTien.ValueMember = "MaLoaiTien";
            this.cb_LoaiTien.SelectedValueChanged += new System.EventHandler(this.cb_LoaiTien_SelectedValueChanged);
            // 
            // ceru_SoTienQuyDoi
            // 
            this.ceru_SoTienQuyDoi.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ceru_SoTienQuyDoi.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.ToKhaiThuebindingSource, "TongSoTienThue", true));
            this.ceru_SoTienQuyDoi.Location = new System.Drawing.Point(361, 72);
            this.ceru_SoTienQuyDoi.MaskInput = "{LOC} nnn,nnn,nnn,nnn.nn";
            this.ceru_SoTienQuyDoi.Name = "ceru_SoTienQuyDoi";
            this.ceru_SoTienQuyDoi.PromptChar = ' ';
            this.ceru_SoTienQuyDoi.ReadOnly = true;
            this.ceru_SoTienQuyDoi.Size = new System.Drawing.Size(118, 21);
            this.ceru_SoTienQuyDoi.TabIndex = 5;
            // 
            // crcu_SoTien
            // 
            this.crcu_SoTien.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.ToKhaiThuebindingSource, "SoTien", true));
            this.crcu_SoTien.Location = new System.Drawing.Point(100, 46);
            this.crcu_SoTien.MaskInput = "{LOC}nnn,nnn,nnn,nnn.nn";
            this.crcu_SoTien.Name = "crcu_SoTien";
            this.crcu_SoTien.PromptChar = ' ';
            this.crcu_SoTien.ReadOnly = true;
            this.crcu_SoTien.Size = new System.Drawing.Size(150, 21);
            this.crcu_SoTien.TabIndex = 2;
            // 
            // dtp_NgayKhai
            // 
            this.dtp_NgayKhai.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dtp_NgayKhai.CustomFormat = "dd/MM/yyyy";
            this.dtp_NgayKhai.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.ToKhaiThuebindingSource, "NgayKhai", true));
            this.dtp_NgayKhai.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp_NgayKhai.Location = new System.Drawing.Point(361, 20);
            this.dtp_NgayKhai.Name = "dtp_NgayKhai";
            this.dtp_NgayKhai.Size = new System.Drawing.Size(118, 20);
            this.dtp_NgayKhai.TabIndex = 1;
            // 
            // txt_SoToKhaiThue
            // 
            this.txt_SoToKhaiThue.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.ToKhaiThuebindingSource, "SoToKhai", true));
            this.txt_SoToKhaiThue.Location = new System.Drawing.Point(100, 20);
            this.txt_SoToKhaiThue.Name = "txt_SoToKhaiThue";
            this.txt_SoToKhaiThue.Size = new System.Drawing.Size(150, 20);
            this.txt_SoToKhaiThue.TabIndex = 0;
            // 
            // txt_VietBangChu
            // 
            this.txt_VietBangChu.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_VietBangChu.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.ToKhaiThuebindingSource, "VietBangChu", true));
            this.txt_VietBangChu.Location = new System.Drawing.Point(100, 98);
            this.txt_VietBangChu.Name = "txt_VietBangChu";
            this.txt_VietBangChu.ReadOnly = true;
            this.txt_VietBangChu.Size = new System.Drawing.Size(379, 20);
            this.txt_VietBangChu.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(269, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Ngày Khai";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 102);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Viết Bằng Chữ";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(269, 76);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(85, 13);
            this.label7.TabIndex = 0;
            this.label7.Text = "Số Tiền Quy Đổi";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(19, 76);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(38, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Tỷ Giá";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(269, 50);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Mã Loại Tiền";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(19, 50);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Số Tiền";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Số Tờ Khai";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.grdu_CTToKhaiThue);
            this.groupBox2.Location = new System.Drawing.Point(12, 162);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(502, 320);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Chi Tiết Tờ Khai Thuế";
            // 
            // grdu_CTToKhaiThue
            // 
            this.grdu_CTToKhaiThue.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grdu_CTToKhaiThue.DataSource = this.cTToKhaiThueListBindingSource;
            appearance4.BackColor = System.Drawing.SystemColors.Window;
            appearance4.BorderColor = System.Drawing.SystemColors.InactiveCaption;
            this.grdu_CTToKhaiThue.DisplayLayout.Appearance = appearance4;
            ultraGridColumn1.Header.VisiblePosition = 0;
            ultraGridColumn2.Header.VisiblePosition = 1;
            ultraGridColumn3.Header.VisiblePosition = 2;
            ultraGridColumn4.Header.VisiblePosition = 3;
            ultraGridColumn5.Header.VisiblePosition = 4;
            ultraGridColumn6.Header.VisiblePosition = 5;
            ultraGridColumn7.Header.VisiblePosition = 6;
            ultraGridColumn8.Header.VisiblePosition = 7;
            ultraGridColumn9.Header.VisiblePosition = 8;
            ultraGridColumn10.Header.VisiblePosition = 9;
            ultraGridColumn11.Header.VisiblePosition = 10;
            ultraGridColumn12.Header.VisiblePosition = 11;
            ultraGridColumn13.Header.VisiblePosition = 12;
            ultraGridColumn14.Header.VisiblePosition = 14;
            ultraGridColumn15.Header.VisiblePosition = 13;
            ultraGridColumn16.Header.VisiblePosition = 15;
            ultraGridColumn17.Header.VisiblePosition = 16;
            ultraGridBand1.Columns.AddRange(new object[] {
            ultraGridColumn1,
            ultraGridColumn2,
            ultraGridColumn3,
            ultraGridColumn4,
            ultraGridColumn5,
            ultraGridColumn6,
            ultraGridColumn7,
            ultraGridColumn8,
            ultraGridColumn9,
            ultraGridColumn10,
            ultraGridColumn11,
            ultraGridColumn12,
            ultraGridColumn13,
            ultraGridColumn14,
            ultraGridColumn15,
            ultraGridColumn16,
            ultraGridColumn17});
            this.grdu_CTToKhaiThue.DisplayLayout.BandsSerializer.Add(ultraGridBand1);
            this.grdu_CTToKhaiThue.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.grdu_CTToKhaiThue.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            appearance1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            appearance1.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance1.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance1.BorderColor = System.Drawing.SystemColors.Window;
            this.grdu_CTToKhaiThue.DisplayLayout.GroupByBox.Appearance = appearance1;
            appearance2.ForeColor = System.Drawing.SystemColors.GrayText;
            this.grdu_CTToKhaiThue.DisplayLayout.GroupByBox.BandLabelAppearance = appearance2;
            this.grdu_CTToKhaiThue.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.grdu_CTToKhaiThue.DisplayLayout.GroupByBox.Hidden = true;
            appearance3.BackColor = System.Drawing.SystemColors.ControlLightLight;
            appearance3.BackColor2 = System.Drawing.SystemColors.Control;
            appearance3.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance3.ForeColor = System.Drawing.SystemColors.GrayText;
            this.grdu_CTToKhaiThue.DisplayLayout.GroupByBox.PromptAppearance = appearance3;
            this.grdu_CTToKhaiThue.DisplayLayout.MaxColScrollRegions = 1;
            this.grdu_CTToKhaiThue.DisplayLayout.MaxRowScrollRegions = 1;
            appearance12.BackColor = System.Drawing.SystemColors.Window;
            appearance12.ForeColor = System.Drawing.SystemColors.ControlText;
            this.grdu_CTToKhaiThue.DisplayLayout.Override.ActiveCellAppearance = appearance12;
            appearance7.BackColor = System.Drawing.SystemColors.Highlight;
            appearance7.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.grdu_CTToKhaiThue.DisplayLayout.Override.ActiveRowAppearance = appearance7;
            this.grdu_CTToKhaiThue.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted;
            this.grdu_CTToKhaiThue.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted;
            appearance6.BackColor = System.Drawing.SystemColors.Window;
            this.grdu_CTToKhaiThue.DisplayLayout.Override.CardAreaAppearance = appearance6;
            appearance5.BorderColor = System.Drawing.Color.Silver;
            appearance5.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter;
            this.grdu_CTToKhaiThue.DisplayLayout.Override.CellAppearance = appearance5;
            this.grdu_CTToKhaiThue.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText;
            this.grdu_CTToKhaiThue.DisplayLayout.Override.CellPadding = 0;
            appearance9.BackColor = System.Drawing.SystemColors.Control;
            appearance9.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance9.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element;
            appearance9.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance9.BorderColor = System.Drawing.SystemColors.Window;
            this.grdu_CTToKhaiThue.DisplayLayout.Override.GroupByRowAppearance = appearance9;
            appearance11.TextHAlignAsString = "Left";
            this.grdu_CTToKhaiThue.DisplayLayout.Override.HeaderAppearance = appearance11;
            this.grdu_CTToKhaiThue.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            this.grdu_CTToKhaiThue.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand;
            appearance10.BackColor = System.Drawing.SystemColors.Window;
            appearance10.BorderColor = System.Drawing.Color.Silver;
            this.grdu_CTToKhaiThue.DisplayLayout.Override.RowAppearance = appearance10;
            this.grdu_CTToKhaiThue.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
            appearance8.BackColor = System.Drawing.SystemColors.ControlLight;
            this.grdu_CTToKhaiThue.DisplayLayout.Override.TemplateAddRowAppearance = appearance8;
            this.grdu_CTToKhaiThue.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.grdu_CTToKhaiThue.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.grdu_CTToKhaiThue.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy;
            this.grdu_CTToKhaiThue.Location = new System.Drawing.Point(6, 19);
            this.grdu_CTToKhaiThue.Name = "grdu_CTToKhaiThue";
            this.grdu_CTToKhaiThue.Size = new System.Drawing.Size(490, 295);
            this.grdu_CTToKhaiThue.TabIndex = 0;
            this.grdu_CTToKhaiThue.Text = "ultraGrid1";
            this.grdu_CTToKhaiThue.InitializeLayout += new Infragistics.Win.UltraWinGrid.InitializeLayoutEventHandler(this.grdu_CTToKhaiThue_InitializeLayout);
            this.grdu_CTToKhaiThue.KeyDown += new System.Windows.Forms.KeyEventHandler(this.grdu_CTToKhaiThue_KeyDown);
            this.grdu_CTToKhaiThue.Leave += new System.EventHandler(this.grdu_CTToKhaiThue_Leave);
            // 
            // tlsMain
            // 
            this.tlsMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tlslblLuu,
            this.toolStripSeparator2,
            this.tlslblXoa,
            this.toolStripSeparator3,
            this.tlslblUndo,
            this.toolStripSeparator4,
            this.tlslblTroGiup,
            this.toolStripSeparator5,
            this.tlslblThoat});
            this.tlsMain.Location = new System.Drawing.Point(0, 0);
            this.tlsMain.Name = "tlsMain";
            this.tlsMain.Size = new System.Drawing.Size(524, 25);
            this.tlsMain.TabIndex = 12;
            this.tlsMain.Text = "toolStrip1";
            // 
            // tlslblLuu
            // 
            this.tlslblLuu.Image = ((System.Drawing.Image)(resources.GetObject("tlslblLuu.Image")));
            this.tlslblLuu.Name = "tlslblLuu";
            this.tlslblLuu.Size = new System.Drawing.Size(45, 22);
            this.tlslblLuu.Text = "&Lưu";
            this.tlslblLuu.ToolTipText = "Ctr+L";
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
            this.tlslblXoa.Size = new System.Drawing.Size(45, 22);
            this.tlslblXoa.Text = "&Xóa";
            this.tlslblXoa.ToolTipText = "Ctr+X";
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
            this.tlslblUndo.Size = new System.Drawing.Size(52, 22);
            this.tlslblUndo.Text = "&Undo";
            this.tlslblUndo.ToolTipText = "Ctr+U";
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // tlslblTroGiup
            // 
            this.tlslblTroGiup.Image = ((System.Drawing.Image)(resources.GetObject("tlslblTroGiup.Image")));
            this.tlslblTroGiup.Name = "tlslblTroGiup";
            this.tlslblTroGiup.Size = new System.Drawing.Size(67, 22);
            this.tlslblTroGiup.Text = "Trợ &Giúp";
            this.tlslblTroGiup.ToolTipText = "Ctr+G";
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
            this.tlslblThoat.Size = new System.Drawing.Size(55, 22);
            this.tlslblThoat.Text = "Th&oát";
            this.tlslblThoat.ToolTipText = "Ctr+O";
            this.tlslblThoat.Click += new System.EventHandler(this.tlslblThoat_Click);
            // 
            // cTToKhaiThueListBindingSource
            // 
            this.cTToKhaiThueListBindingSource.AllowNew = true;
            this.cTToKhaiThueListBindingSource.DataSource = typeof(ERP_Library.CT_ToKhaiThueList);
            // 
            // ToKhaiThuebindingSource
            // 
            this.ToKhaiThuebindingSource.DataSource = typeof(ERP_Library.ToKhaiThue);
            // 
            // loaiTienListBindingSource
            // 
            this.loaiTienListBindingSource.DataSource = typeof(ERP_Library.LoaiTienList);
            // 
            // frmToKhaiThue
            // 
            this.ClientSize = new System.Drawing.Size(524, 491);
            this.Controls.Add(this.tlsMain);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmToKhaiThue";
            this.Text = "Tờ Khai Thuế";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numu_TyGia)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ceru_SoTienQuyDoi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.crcu_SoTien)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdu_CTToKhaiThue)).EndInit();
            this.tlsMain.ResumeLayout(false);
            this.tlsMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cTToKhaiThueListBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ToKhaiThuebindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.loaiTienListBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txt_VietBangChu;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private Infragistics.Win.UltraWinGrid.UltraGrid grdu_CTToKhaiThue;
        private System.Windows.Forms.ToolStrip tlsMain;
        private System.Windows.Forms.ToolStripButton tlslblLuu;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton tlslblXoa;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton tlslblUndo;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton tlslblTroGiup;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripButton tlslblThoat;
        private System.Windows.Forms.DateTimePicker dtp_NgayKhai;
        private System.Windows.Forms.TextBox txt_SoToKhaiThue;
        private System.Windows.Forms.ComboBox cb_LoaiTien;
        private Infragistics.Win.UltraWinEditors.UltraCurrencyEditor ceru_SoTienQuyDoi;
        private Infragistics.Win.UltraWinEditors.UltraCurrencyEditor crcu_SoTien;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private Infragistics.Win.UltraWinEditors.UltraNumericEditor numu_TyGia;
        private System.Windows.Forms.BindingSource cTToKhaiThueListBindingSource;
        private System.Windows.Forms.BindingSource ToKhaiThuebindingSource;
        private System.Windows.Forms.BindingSource loaiTienListBindingSource;
    }
}