namespace PSC_ERP
{
    partial class frmNhanVienTangCaEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmNhanVienTangCaEdit));
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand1 = new Infragistics.Win.UltraWinGrid.UltraGridBand("BoPhan", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn1 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("MaBoPhan");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn2 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("MaBoPhanQL");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn3 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("TenBoPhan");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn4 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("NgayTao");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn5 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("MaBoPhanCha");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn6 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("MaLoaiBoPhan");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn7 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("MaCongTy");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn8 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("TangCaGianCa");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn9 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("SoGioTangCa");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn10 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("SoGioGianCa");
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
            this.tlsMain = new System.Windows.Forms.ToolStrip();
            this.tlslblLuu = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tlslblXoa = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tlslblUndo = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.tlslblIn = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripSeparator();
            this.tlslblTroGiup = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.tlslblThoat = new System.Windows.Forms.ToolStripButton();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbBoPhan = new Infragistics.Win.UltraWinGrid.UltraCombo();
            this.bdData = new System.Windows.Forms.BindingSource(this.components);
            this.txtNgay = new Infragistics.Win.UltraWinEditors.UltraDateTimeEditor();
            this.label7 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtGioBD = new Infragistics.Win.UltraWinMaskedEdit.UltraMaskedEdit();
            this.txtGioKT = new Infragistics.Win.UltraWinMaskedEdit.UltraMaskedEdit();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbHinhThuc = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.label6 = new System.Windows.Forms.Label();
            this.txtGhiChu = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.label8 = new System.Windows.Forms.Label();
            this.txtSoGio = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.cmbNhanVien = new PSC_ERP.ComboboxNhanVien();
            this.tlsMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbBoPhan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNgay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbHinhThuc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGhiChu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSoGio)).BeginInit();
            this.SuspendLayout();
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
            this.tlslblIn,
            this.toolStripButton1,
            this.tlslblTroGiup,
            this.toolStripSeparator5,
            this.tlslblThoat});
            this.tlsMain.Location = new System.Drawing.Point(0, 0);
            this.tlsMain.Name = "tlsMain";
            this.tlsMain.Size = new System.Drawing.Size(486, 25);
            this.tlsMain.TabIndex = 1;
            this.tlsMain.Text = "toolStrip1";
            // 
            // tlslblLuu
            // 
            this.tlslblLuu.Image = ((System.Drawing.Image)(resources.GetObject("tlslblLuu.Image")));
            this.tlslblLuu.Name = "tlslblLuu";
            this.tlslblLuu.Size = new System.Drawing.Size(45, 22);
            this.tlslblLuu.Text = "&Lưu";
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
            this.tlslblXoa.Click += new System.EventHandler(this.tlslblXoa_Click);
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
            this.tlslblUndo.Click += new System.EventHandler(this.tlslblUndo_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // tlslblIn
            // 
            this.tlslblIn.Image = ((System.Drawing.Image)(resources.GetObject("tlslblIn.Image")));
            this.tlslblIn.Name = "tlslblIn";
            this.tlslblIn.Size = new System.Drawing.Size(37, 22);
            this.tlslblIn.Text = "&In";
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
            this.tlslblTroGiup.Size = new System.Drawing.Size(67, 22);
            this.tlslblTroGiup.Text = "Trợ &Giúp";
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
            this.tlslblThoat.Click += new System.EventHandler(this.tlslblThoat_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 87);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Bộ phận";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 117);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Nhân viên";
            // 
            // cmbBoPhan
            // 
            this.cmbBoPhan.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.cmbBoPhan.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bdData, "MaBoPhan", true));
            appearance7.BackColor = System.Drawing.SystemColors.ControlLight;
            appearance7.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance7.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            this.cmbBoPhan.DisplayLayout.Appearance = appearance7;
            ultraGridColumn1.Header.VisiblePosition = 0;
            ultraGridColumn1.Hidden = true;
            ultraGridColumn2.Header.Caption = "Mã bộ phận";
            ultraGridColumn2.Header.VisiblePosition = 1;
            ultraGridColumn3.Header.Caption = "Tên bộ phận";
            ultraGridColumn3.Header.VisiblePosition = 2;
            ultraGridColumn4.Header.VisiblePosition = 3;
            ultraGridColumn4.Hidden = true;
            ultraGridColumn5.Header.VisiblePosition = 4;
            ultraGridColumn5.Hidden = true;
            ultraGridColumn6.Header.VisiblePosition = 5;
            ultraGridColumn6.Hidden = true;
            ultraGridColumn7.Header.VisiblePosition = 6;
            ultraGridColumn7.Hidden = true;
            ultraGridColumn8.Header.VisiblePosition = 7;
            ultraGridColumn8.Hidden = true;
            ultraGridColumn9.Header.VisiblePosition = 8;
            ultraGridColumn9.Hidden = true;
            ultraGridColumn10.Header.VisiblePosition = 9;
            ultraGridColumn10.Hidden = true;
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
            ultraGridColumn10});
            this.cmbBoPhan.DisplayLayout.BandsSerializer.Add(ultraGridBand1);
            this.cmbBoPhan.DisplayLayout.InterBandSpacing = 10;
            this.cmbBoPhan.DisplayLayout.MaxColScrollRegions = 1;
            this.cmbBoPhan.DisplayLayout.MaxRowScrollRegions = 1;
            appearance8.BackColor = System.Drawing.Color.Transparent;
            this.cmbBoPhan.DisplayLayout.Override.CardAreaAppearance = appearance8;
            appearance9.BackColor = System.Drawing.SystemColors.Control;
            appearance9.BackColor2 = System.Drawing.SystemColors.ControlLightLight;
            appearance9.BackGradientStyle = Infragistics.Win.GradientStyle.VerticalBump;
            this.cmbBoPhan.DisplayLayout.Override.CellAppearance = appearance9;
            this.cmbBoPhan.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText;
            appearance10.BackColor = System.Drawing.SystemColors.Control;
            appearance10.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance10.BackGradientStyle = Infragistics.Win.GradientStyle.VerticalBump;
            appearance10.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent;
            this.cmbBoPhan.DisplayLayout.Override.HeaderAppearance = appearance10;
            this.cmbBoPhan.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            appearance11.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.cmbBoPhan.DisplayLayout.Override.RowSelectorAppearance = appearance11;
            appearance12.BackColor = System.Drawing.SystemColors.InactiveCaption;
            appearance12.BackColor2 = System.Drawing.SystemColors.ActiveCaption;
            appearance12.BackGradientStyle = Infragistics.Win.GradientStyle.VerticalBump;
            this.cmbBoPhan.DisplayLayout.Override.SelectedRowAppearance = appearance12;
            this.cmbBoPhan.DisplayLayout.RowConnectorColor = System.Drawing.SystemColors.ControlDarkDark;
            this.cmbBoPhan.DisplayLayout.RowConnectorStyle = Infragistics.Win.UltraWinGrid.RowConnectorStyle.Dashed;
            this.cmbBoPhan.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.cmbBoPhan.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.cmbBoPhan.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy;
            this.cmbBoPhan.DisplayMember = "TenBoPhan";
            this.cmbBoPhan.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007;
            this.cmbBoPhan.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbBoPhan.Location = new System.Drawing.Point(89, 78);
            this.cmbBoPhan.Name = "cmbBoPhan";
            this.cmbBoPhan.Size = new System.Drawing.Size(208, 22);
            this.cmbBoPhan.TabIndex = 3;
            this.cmbBoPhan.ValueMember = "MaBoPhan";
            this.cmbBoPhan.ValueChanged += new System.EventHandler(this.cmbBoPhan_ValueChanged);
            // 
            // bdData
            // 
            this.bdData.DataSource = typeof(ERP_Library.NhanVienTangCa);
            // 
            // txtNgay
            // 
            this.txtNgay.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bdData, "NgayTangCa", true));
            this.txtNgay.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007;
            this.txtNgay.Location = new System.Drawing.Point(89, 51);
            this.txtNgay.Name = "txtNgay";
            this.txtNgay.Size = new System.Drawing.Size(94, 21);
            this.txtNgay.TabIndex = 1;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 59);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(71, 13);
            this.label7.TabIndex = 0;
            this.label7.Text = "Ngày tăng ca";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 145);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Giờ bắt đầu";
            // 
            // txtGioBD
            // 
            this.txtGioBD.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bdData, "GioBatDau", true));
            this.txtGioBD.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007;
            this.txtGioBD.EditAs = Infragistics.Win.UltraWinMaskedEdit.EditAsType.UseSpecifiedMask;
            this.txtGioBD.InputMask = "{LOC}hh:mm";
            this.txtGioBD.Location = new System.Drawing.Point(89, 138);
            this.txtGioBD.Name = "txtGioBD";
            this.txtGioBD.Size = new System.Drawing.Size(58, 20);
            this.txtGioBD.TabIndex = 7;
            this.txtGioBD.Text = ":";
            // 
            // txtGioKT
            // 
            this.txtGioKT.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bdData, "GioKetThuc", true));
            this.txtGioKT.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007;
            this.txtGioKT.EditAs = Infragistics.Win.UltraWinMaskedEdit.EditAsType.UseSpecifiedMask;
            this.txtGioKT.InputMask = "{LOC}hh:mm";
            this.txtGioKT.Location = new System.Drawing.Point(239, 138);
            this.txtGioKT.Name = "txtGioKT";
            this.txtGioKT.Size = new System.Drawing.Size(58, 20);
            this.txtGioKT.TabIndex = 9;
            this.txtGioKT.Text = ":";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(167, 145);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "giờ kết thúc";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 172);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Hình thức";
            // 
            // cmbHinhThuc
            // 
            this.cmbHinhThuc.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bdData, "MaLoaiTangCa", true));
            this.cmbHinhThuc.DisplayMember = "TenLoaiTangCa";
            this.cmbHinhThuc.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007;
            this.cmbHinhThuc.Location = new System.Drawing.Point(89, 164);
            this.cmbHinhThuc.Name = "cmbHinhThuc";
            this.cmbHinhThuc.Size = new System.Drawing.Size(208, 21);
            this.cmbHinhThuc.TabIndex = 13;
            this.cmbHinhThuc.ValueMember = "MaLoaiTangCa";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 200);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(44, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "Ghi chú";
            // 
            // txtGhiChu
            // 
            this.txtGhiChu.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bdData, "GhiChu", true));
            this.txtGhiChu.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007;
            this.txtGhiChu.Location = new System.Drawing.Point(89, 191);
            this.txtGhiChu.Multiline = true;
            this.txtGhiChu.Name = "txtGhiChu";
            this.txtGhiChu.Size = new System.Drawing.Size(372, 93);
            this.txtGhiChu.TabIndex = 15;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(357, 145);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(35, 13);
            this.label8.TabIndex = 10;
            this.label8.Text = "số giờ";
            // 
            // txtSoGio
            // 
            this.txtSoGio.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bdData, "SoGio", true));
            this.txtSoGio.Enabled = false;
            this.txtSoGio.Location = new System.Drawing.Point(398, 138);
            this.txtSoGio.Name = "txtSoGio";
            this.txtSoGio.Size = new System.Drawing.Size(63, 21);
            this.txtSoGio.TabIndex = 11;
            // 
            // cmbNhanVien
            // 
            this.cmbNhanVien.AutoSize = true;
            this.cmbNhanVien.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bdData, "MaNhanVien", true));
            this.cmbNhanVien.Location = new System.Drawing.Point(89, 108);
            this.cmbNhanVien.Margin = new System.Windows.Forms.Padding(5);
            this.cmbNhanVien.Name = "cmbNhanVien";
            this.cmbNhanVien.Size = new System.Drawing.Size(372, 22);
            this.cmbNhanVien.TabIndex = 5;
            this.cmbNhanVien.Value = null;
            // 
            // frmNhanVienTangCaEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(486, 299);
            this.Controls.Add(this.txtSoGio);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtGhiChu);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cmbHinhThuc);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtGioKT);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtGioBD);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtNgay);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cmbNhanVien);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmbBoPhan);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tlsMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmNhanVienTangCaEdit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Nhân viên tăng ca";
            this.Load += new System.EventHandler(this.frmNhanVienTangCaEdit_Load);
            this.tlsMain.ResumeLayout(false);
            this.tlsMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbBoPhan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNgay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbHinhThuc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGhiChu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSoGio)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tlsMain;
        private System.Windows.Forms.ToolStripButton tlslblLuu;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton tlslblXoa;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton tlslblUndo;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton tlslblIn;
        private System.Windows.Forms.ToolStripSeparator toolStripButton1;
        private System.Windows.Forms.ToolStripButton tlslblTroGiup;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripButton tlslblThoat;
        private System.Windows.Forms.BindingSource bdData;
        private System.Windows.Forms.Label label1;
        private ComboboxNhanVien cmbNhanVien;
        private System.Windows.Forms.Label label4;
        private Infragistics.Win.UltraWinGrid.UltraCombo cmbBoPhan;
        private Infragistics.Win.UltraWinEditors.UltraDateTimeEditor txtNgay;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label2;
        private Infragistics.Win.UltraWinMaskedEdit.UltraMaskedEdit txtGioBD;
        private Infragistics.Win.UltraWinMaskedEdit.UltraMaskedEdit txtGioKT;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private Infragistics.Win.UltraWinEditors.UltraComboEditor cmbHinhThuc;
        private System.Windows.Forms.Label label6;
        private Infragistics.Win.UltraWinEditors.UltraTextEditor txtGhiChu;
        private System.Windows.Forms.Label label8;
        private Infragistics.Win.UltraWinEditors.UltraTextEditor txtSoGio;
    }
}