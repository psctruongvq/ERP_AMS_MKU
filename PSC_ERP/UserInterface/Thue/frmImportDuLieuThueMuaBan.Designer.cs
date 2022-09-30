namespace PSC_ERP
{
    partial class frmImportDuLieuThueMuaBan
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmImportDuLieuThueMuaBan));
            Infragistics.Win.Appearance appearance14 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance15 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance16 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance17 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance18 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance19 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance20 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance21 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance22 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance23 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance24 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance26 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
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
            this.tlslblThoat = new System.Windows.Forms.ToolStripButton();
            this.tlsMain = new System.Windows.Forms.ToolStrip();
            this.tlsImport = new System.Windows.Forms.ToolStripSplitButton();
            this.tlsImportmua = new System.Windows.Forms.ToolStripMenuItem();
            this.tlsimportban = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tlsxem = new System.Windows.Forms.ToolStripButton();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.grd_Muavao = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.grd_Banra = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dtmp_Ngay = new Infragistics.Win.UltraWinEditors.UltraDateTimeEditor();
            this.label3 = new System.Windows.Forms.Label();
            this.cbo_Ky = new Infragistics.Win.UltraWinGrid.UltraCombo();
            this.label4 = new System.Windows.Forms.Label();
            this.BindS_ky = new System.Windows.Forms.BindingSource(this.components);
            this.Binds_bophan = new System.Windows.Forms.BindingSource(this.components);
            this.Binds_doitac = new System.Windows.Forms.BindingSource(this.components);
            this.bindscaphd = new System.Windows.Forms.BindingSource(this.components);
            this.tlsMain.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grd_Muavao)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grd_Banra)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtmp_Ngay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbo_Ky)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BindS_ky)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Binds_bophan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Binds_doitac)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindscaphd)).BeginInit();
            this.SuspendLayout();
            // 
            // tlslblThoat
            // 
            this.tlslblThoat.Image = ((System.Drawing.Image)(resources.GetObject("tlslblThoat.Image")));
            this.tlslblThoat.Name = "tlslblThoat";
            this.tlslblThoat.Size = new System.Drawing.Size(58, 22);
            this.tlslblThoat.Text = "Thoát";
            this.tlslblThoat.Click += new System.EventHandler(this.tlslblThoat_Click);
            // 
            // tlsMain
            // 
            this.tlsMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tlsImport,
            this.toolStripSeparator1,
            this.tlsxem,
            this.tlslblThoat});
            this.tlsMain.Location = new System.Drawing.Point(0, 0);
            this.tlsMain.Name = "tlsMain";
            this.tlsMain.Size = new System.Drawing.Size(916, 25);
            this.tlsMain.TabIndex = 30;
            this.tlsMain.Text = "toolStrip1";
            // 
            // tlsImport
            // 
            this.tlsImport.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tlsImportmua,
            this.tlsimportban});
            this.tlsImport.Image = ((System.Drawing.Image)(resources.GetObject("tlsImport.Image")));
            this.tlsImport.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tlsImport.Name = "tlsImport";
            this.tlsImport.Size = new System.Drawing.Size(114, 22);
            this.tlsImport.Text = "Import dữ liệu";
            // 
            // tlsImportmua
            // 
            this.tlsImportmua.Name = "tlsImportmua";
            this.tlsImportmua.Size = new System.Drawing.Size(198, 22);
            this.tlsImportmua.Text = "Import dữ liệu mua vào";
            this.tlsImportmua.Click += new System.EventHandler(this.tlsImportmua_Click);
            // 
            // tlsimportban
            // 
            this.tlsimportban.Name = "tlsimportban";
            this.tlsimportban.Size = new System.Drawing.Size(198, 22);
            this.tlsimportban.Text = "Import dữ liệu bán ra";
            this.tlsimportban.Click += new System.EventHandler(this.tlsimportban_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // tlsxem
            // 
            this.tlsxem.Image = ((System.Drawing.Image)(resources.GetObject("tlsxem.Image")));
            this.tlsxem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tlsxem.Name = "tlsxem";
            this.tlsxem.Size = new System.Drawing.Size(90, 22);
            this.tlsxem.Text = "Xem dữ liệu";
            this.tlsxem.Visible = false;
            this.tlsxem.Click += new System.EventHandler(this.tlsxem_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(6, 79);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(905, 425);
            this.tabControl1.TabIndex = 31;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.grd_Muavao);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(897, 399);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Mua Vào";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // grd_Muavao
            // 
            this.grd_Muavao.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            appearance14.BackColor = System.Drawing.SystemColors.Window;
            appearance14.BorderColor = System.Drawing.SystemColors.InactiveCaption;
            this.grd_Muavao.DisplayLayout.Appearance = appearance14;
            this.grd_Muavao.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.grd_Muavao.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            appearance15.BackColor = System.Drawing.SystemColors.ActiveBorder;
            appearance15.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance15.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance15.BorderColor = System.Drawing.SystemColors.Window;
            this.grd_Muavao.DisplayLayout.GroupByBox.Appearance = appearance15;
            appearance16.ForeColor = System.Drawing.SystemColors.GrayText;
            this.grd_Muavao.DisplayLayout.GroupByBox.BandLabelAppearance = appearance16;
            this.grd_Muavao.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.grd_Muavao.DisplayLayout.GroupByBox.Hidden = true;
            appearance17.BackColor = System.Drawing.SystemColors.ControlLightLight;
            appearance17.BackColor2 = System.Drawing.SystemColors.Control;
            appearance17.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance17.ForeColor = System.Drawing.SystemColors.GrayText;
            this.grd_Muavao.DisplayLayout.GroupByBox.PromptAppearance = appearance17;
            this.grd_Muavao.DisplayLayout.MaxColScrollRegions = 1;
            this.grd_Muavao.DisplayLayout.MaxRowScrollRegions = 1;
            appearance18.BackColor = System.Drawing.SystemColors.Window;
            appearance18.ForeColor = System.Drawing.SystemColors.ControlText;
            this.grd_Muavao.DisplayLayout.Override.ActiveCellAppearance = appearance18;
            appearance19.BackColor = System.Drawing.SystemColors.Highlight;
            appearance19.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.grd_Muavao.DisplayLayout.Override.ActiveRowAppearance = appearance19;
            this.grd_Muavao.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.Yes;
            this.grd_Muavao.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted;
            this.grd_Muavao.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted;
            appearance20.BackColor = System.Drawing.SystemColors.Window;
            this.grd_Muavao.DisplayLayout.Override.CardAreaAppearance = appearance20;
            appearance21.BorderColor = System.Drawing.Color.Silver;
            appearance21.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter;
            this.grd_Muavao.DisplayLayout.Override.CellAppearance = appearance21;
            this.grd_Muavao.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText;
            this.grd_Muavao.DisplayLayout.Override.CellPadding = 0;
            appearance22.BackColor = System.Drawing.SystemColors.Control;
            appearance22.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance22.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element;
            appearance22.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance22.BorderColor = System.Drawing.SystemColors.Window;
            this.grd_Muavao.DisplayLayout.Override.GroupByRowAppearance = appearance22;
            appearance23.TextHAlignAsString = "Left";
            this.grd_Muavao.DisplayLayout.Override.HeaderAppearance = appearance23;
            this.grd_Muavao.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            this.grd_Muavao.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand;
            appearance24.BackColor = System.Drawing.SystemColors.Window;
            appearance24.BorderColor = System.Drawing.Color.Silver;
            this.grd_Muavao.DisplayLayout.Override.RowAppearance = appearance24;
            this.grd_Muavao.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.True;
            appearance26.BackColor = System.Drawing.SystemColors.ControlLight;
            this.grd_Muavao.DisplayLayout.Override.TemplateAddRowAppearance = appearance26;
            this.grd_Muavao.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.grd_Muavao.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.grd_Muavao.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy;
            this.grd_Muavao.Location = new System.Drawing.Point(6, 6);
            this.grd_Muavao.Name = "grd_Muavao";
            this.grd_Muavao.Size = new System.Drawing.Size(885, 387);
            this.grd_Muavao.TabIndex = 35;
            this.grd_Muavao.Text = "ultraGrid1";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.grd_Banra);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(897, 399);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Bán Ra";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // grd_Banra
            // 
            this.grd_Banra.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            appearance4.BackColor = System.Drawing.SystemColors.Window;
            appearance4.BorderColor = System.Drawing.SystemColors.InactiveCaption;
            this.grd_Banra.DisplayLayout.Appearance = appearance4;
            this.grd_Banra.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.grd_Banra.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            appearance1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            appearance1.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance1.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance1.BorderColor = System.Drawing.SystemColors.Window;
            this.grd_Banra.DisplayLayout.GroupByBox.Appearance = appearance1;
            appearance2.ForeColor = System.Drawing.SystemColors.GrayText;
            this.grd_Banra.DisplayLayout.GroupByBox.BandLabelAppearance = appearance2;
            this.grd_Banra.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.grd_Banra.DisplayLayout.GroupByBox.Hidden = true;
            appearance3.BackColor = System.Drawing.SystemColors.ControlLightLight;
            appearance3.BackColor2 = System.Drawing.SystemColors.Control;
            appearance3.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance3.ForeColor = System.Drawing.SystemColors.GrayText;
            this.grd_Banra.DisplayLayout.GroupByBox.PromptAppearance = appearance3;
            this.grd_Banra.DisplayLayout.MaxColScrollRegions = 1;
            this.grd_Banra.DisplayLayout.MaxRowScrollRegions = 1;
            appearance12.BackColor = System.Drawing.SystemColors.Window;
            appearance12.ForeColor = System.Drawing.SystemColors.ControlText;
            this.grd_Banra.DisplayLayout.Override.ActiveCellAppearance = appearance12;
            appearance7.BackColor = System.Drawing.SystemColors.Highlight;
            appearance7.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.grd_Banra.DisplayLayout.Override.ActiveRowAppearance = appearance7;
            this.grd_Banra.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.Yes;
            this.grd_Banra.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted;
            this.grd_Banra.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted;
            appearance6.BackColor = System.Drawing.SystemColors.Window;
            this.grd_Banra.DisplayLayout.Override.CardAreaAppearance = appearance6;
            appearance5.BorderColor = System.Drawing.Color.Silver;
            appearance5.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter;
            this.grd_Banra.DisplayLayout.Override.CellAppearance = appearance5;
            this.grd_Banra.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText;
            this.grd_Banra.DisplayLayout.Override.CellPadding = 0;
            appearance9.BackColor = System.Drawing.SystemColors.Control;
            appearance9.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance9.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element;
            appearance9.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance9.BorderColor = System.Drawing.SystemColors.Window;
            this.grd_Banra.DisplayLayout.Override.GroupByRowAppearance = appearance9;
            appearance11.TextHAlignAsString = "Left";
            this.grd_Banra.DisplayLayout.Override.HeaderAppearance = appearance11;
            this.grd_Banra.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            this.grd_Banra.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand;
            appearance10.BackColor = System.Drawing.SystemColors.Window;
            appearance10.BorderColor = System.Drawing.Color.Silver;
            this.grd_Banra.DisplayLayout.Override.RowAppearance = appearance10;
            this.grd_Banra.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.True;
            appearance8.BackColor = System.Drawing.SystemColors.ControlLight;
            this.grd_Banra.DisplayLayout.Override.TemplateAddRowAppearance = appearance8;
            this.grd_Banra.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.grd_Banra.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.grd_Banra.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy;
            this.grd_Banra.Location = new System.Drawing.Point(6, 6);
            this.grd_Banra.Name = "grd_Banra";
            this.grd_Banra.Size = new System.Drawing.Size(885, 387);
            this.grd_Banra.TabIndex = 36;
            this.grd_Banra.Text = "ultraGrid1";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.dtmp_Ngay);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.cbo_Ky);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Location = new System.Drawing.Point(6, 28);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(905, 45);
            this.groupBox1.TabIndex = 32;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông Tin";
            // 
            // dtmp_Ngay
            // 
            this.dtmp_Ngay.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007;
            this.dtmp_Ngay.FormatString = "";
            this.dtmp_Ngay.Location = new System.Drawing.Point(378, 17);
            this.dtmp_Ngay.MaskInput = "{LOC}dd/mm/yyyy";
            this.dtmp_Ngay.Name = "dtmp_Ngay";
            this.dtmp_Ngay.Size = new System.Drawing.Size(117, 21);
            this.dtmp_Ngay.TabIndex = 18;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(311, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 17;
            this.label3.Text = "Ngày Lập";
            // 
            // cbo_Ky
            // 
            this.cbo_Ky.CheckedListSettings.CheckStateMember = "";
            this.cbo_Ky.DataSource = this.BindS_ky;
            this.cbo_Ky.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            this.cbo_Ky.DisplayMember = "TenKy";
            this.cbo_Ky.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbo_Ky.Location = new System.Drawing.Point(43, 17);
            this.cbo_Ky.Name = "cbo_Ky";
            this.cbo_Ky.Size = new System.Drawing.Size(262, 22);
            this.cbo_Ky.TabIndex = 16;
            this.cbo_Ky.ValueMember = "MaKy";
            this.cbo_Ky.InitializeLayout += new Infragistics.Win.UltraWinGrid.InitializeLayoutEventHandler(this.cbo_Ky_InitializeLayout);
            this.cbo_Ky.AfterCloseUp += new System.EventHandler(this.cbo_Ky_AfterCloseUp);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Location = new System.Drawing.Point(18, 21);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(19, 13);
            this.label4.TabIndex = 15;
            this.label4.Text = "Kỳ";
            // 
            // bindscaphd
            // 
            this.bindscaphd.AllowNew = true;
            // 
            // frmImportDuLieuThueMuaBan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(916, 506);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.tlsMain);
            this.KeyPreview = true;
            this.Name = "frmImportDuLieuThueMuaBan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dữ liệu hóa đơn";
            this.tlsMain.ResumeLayout(false);
            this.tlsMain.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grd_Muavao)).EndInit();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grd_Banra)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtmp_Ngay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbo_Ky)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BindS_ky)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Binds_bophan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Binds_doitac)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindscaphd)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource bindscaphd;
        private System.Windows.Forms.ToolStripButton tlslblThoat;
        private System.Windows.Forms.ToolStrip tlsMain;
        private System.Windows.Forms.BindingSource Binds_bophan;
        private System.Windows.Forms.BindingSource Binds_doitac;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private Infragistics.Win.UltraWinGrid.UltraGrid grd_Muavao;
        private System.Windows.Forms.GroupBox groupBox1;
        private Infragistics.Win.UltraWinGrid.UltraGrid grd_Banra;
        private System.Windows.Forms.ToolStripSplitButton tlsImport;
        private System.Windows.Forms.ToolStripMenuItem tlsImportmua;
        private System.Windows.Forms.ToolStripMenuItem tlsimportban;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tlsxem;
        private Infragistics.Win.UltraWinEditors.UltraDateTimeEditor dtmp_Ngay;
        private System.Windows.Forms.Label label3;
        private Infragistics.Win.UltraWinGrid.UltraCombo cbo_Ky;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.BindingSource BindS_ky;
    }
}