namespace PSC_ERP
{
    partial class frmDanhSachNhanVienNghiViec
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
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn11 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("KhongTinhLuong");
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand2 = new Infragistics.Win.UltraWinGrid.UltraGridBand("DanhSachNhanVienNghiViecChild", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn12 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("TenBoPhan");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn17 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("MaQLNhanVien");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn19 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("TenNhanVien", -1, null, 0, Infragistics.Win.UltraWinGrid.SortIndicator.Ascending, false);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn14 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("TenChucVu");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn20 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("TuNgay");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn13 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("DenNgay");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn15 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("SoNgay");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn16 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("TenHinhThucNghi");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn18 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("LyDo");
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            this.grpFind = new Infragistics.Win.Misc.UltraGroupBox();
            this.cmbBoPhan = new Infragistics.Win.UltraWinGrid.UltraCombo();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbNhanVien = new PSC_ERP.ComboboxNhanVien();
            this.btnFind = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDenNgay = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTuNgay = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.grdBaoCao = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.bdBaoCao = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.grpFind)).BeginInit();
            this.grpFind.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbBoPhan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdBaoCao)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdBaoCao)).BeginInit();
            this.SuspendLayout();
            // 
            // grpFind
            // 
            this.grpFind.Controls.Add(this.cmbBoPhan);
            this.grpFind.Controls.Add(this.label4);
            this.grpFind.Controls.Add(this.cmbNhanVien);
            this.grpFind.Controls.Add(this.btnFind);
            this.grpFind.Controls.Add(this.label3);
            this.grpFind.Controls.Add(this.txtDenNgay);
            this.grpFind.Controls.Add(this.label2);
            this.grpFind.Controls.Add(this.txtTuNgay);
            this.grpFind.Controls.Add(this.label1);
            this.grpFind.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpFind.Location = new System.Drawing.Point(0, 0);
            this.grpFind.Name = "grpFind";
            this.grpFind.Size = new System.Drawing.Size(862, 91);
            this.grpFind.TabIndex = 0;
            this.grpFind.Text = "Tìm kiếm";
            // 
            // cmbBoPhan
            // 
            appearance1.BackColor = System.Drawing.SystemColors.ControlLight;
            appearance1.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance1.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            this.cmbBoPhan.DisplayLayout.Appearance = appearance1;
            ultraGridColumn1.Header.VisiblePosition = 0;
            ultraGridColumn1.Hidden = true;
            ultraGridColumn2.Header.Caption = "Mã BP";
            ultraGridColumn2.Header.VisiblePosition = 1;
            ultraGridColumn2.Width = 59;
            ultraGridColumn3.Header.Caption = "Tên bộ phận";
            ultraGridColumn3.Header.VisiblePosition = 2;
            ultraGridColumn3.Width = 182;
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
            ultraGridColumn11.Header.VisiblePosition = 10;
            ultraGridColumn11.Hidden = true;
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
            ultraGridColumn11});
            this.cmbBoPhan.DisplayLayout.BandsSerializer.Add(ultraGridBand1);
            this.cmbBoPhan.DisplayLayout.InterBandSpacing = 10;
            this.cmbBoPhan.DisplayLayout.MaxColScrollRegions = 1;
            this.cmbBoPhan.DisplayLayout.MaxRowScrollRegions = 1;
            appearance2.BackColor = System.Drawing.Color.Transparent;
            this.cmbBoPhan.DisplayLayout.Override.CardAreaAppearance = appearance2;
            appearance3.BackColor = System.Drawing.SystemColors.Control;
            appearance3.BackColor2 = System.Drawing.SystemColors.ControlLightLight;
            appearance3.BackGradientStyle = Infragistics.Win.GradientStyle.VerticalBump;
            this.cmbBoPhan.DisplayLayout.Override.CellAppearance = appearance3;
            this.cmbBoPhan.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText;
            appearance4.BackColor = System.Drawing.SystemColors.Control;
            appearance4.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance4.BackGradientStyle = Infragistics.Win.GradientStyle.VerticalBump;
            appearance4.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent;
            this.cmbBoPhan.DisplayLayout.Override.HeaderAppearance = appearance4;
            this.cmbBoPhan.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            appearance5.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.cmbBoPhan.DisplayLayout.Override.RowSelectorAppearance = appearance5;
            appearance6.BackColor = System.Drawing.SystemColors.InactiveCaption;
            appearance6.BackColor2 = System.Drawing.SystemColors.ActiveCaption;
            appearance6.BackGradientStyle = Infragistics.Win.GradientStyle.VerticalBump;
            this.cmbBoPhan.DisplayLayout.Override.SelectedRowAppearance = appearance6;
            this.cmbBoPhan.DisplayLayout.RowConnectorColor = System.Drawing.SystemColors.ControlDarkDark;
            this.cmbBoPhan.DisplayLayout.RowConnectorStyle = Infragistics.Win.UltraWinGrid.RowConnectorStyle.Dashed;
            this.cmbBoPhan.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.cmbBoPhan.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.cmbBoPhan.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy;
            this.cmbBoPhan.DisplayMember = "TenBoPhan";
            this.cmbBoPhan.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007;
            this.cmbBoPhan.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.cmbBoPhan.Location = new System.Drawing.Point(400, 18);
            this.cmbBoPhan.Name = "cmbBoPhan";
            this.cmbBoPhan.Size = new System.Drawing.Size(176, 22);
            this.cmbBoPhan.TabIndex = 12;
            this.cmbBoPhan.ValueMember = "MaBoPhan";
            this.cmbBoPhan.ValueChanged += new System.EventHandler(this.cmbBoPhan_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(339, 25);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Bộ phận";
            // 
            // cmbNhanVien
            // 
            this.cmbNhanVien.AutoSize = true;
            this.cmbNhanVien.Location = new System.Drawing.Point(642, 18);
            this.cmbNhanVien.Name = "cmbNhanVien";
            this.cmbNhanVien.Size = new System.Drawing.Size(203, 22);
            this.cmbNhanVien.TabIndex = 7;
            this.cmbNhanVien.Value = null;
            // 
            // btnFind
            // 
            this.btnFind.Location = new System.Drawing.Point(376, 58);
            this.btnFind.Margin = new System.Windows.Forms.Padding(2);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(85, 22);
            this.btnFind.TabIndex = 10;
            this.btnFind.Text = "Tìm kiếm";
            this.btnFind.UseVisualStyleBackColor = true;
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(581, 25);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Nhân viên";
            // 
            // txtDenNgay
            // 
            this.txtDenNgay.CustomFormat = "dd/MM/yyyy";
            this.txtDenNgay.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.txtDenNgay.Location = new System.Drawing.Point(235, 22);
            this.txtDenNgay.Margin = new System.Windows.Forms.Padding(2);
            this.txtDenNgay.Name = "txtDenNgay";
            this.txtDenNgay.Size = new System.Drawing.Size(93, 20);
            this.txtDenNgay.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(180, 27);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Đến ngày";
            // 
            // txtTuNgay
            // 
            this.txtTuNgay.CustomFormat = "dd/MM/yyyy";
            this.txtTuNgay.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.txtTuNgay.Location = new System.Drawing.Point(75, 24);
            this.txtTuNgay.Margin = new System.Windows.Forms.Padding(2);
            this.txtTuNgay.Name = "txtTuNgay";
            this.txtTuNgay.Size = new System.Drawing.Size(85, 20);
            this.txtTuNgay.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 28);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Từ ngày";
            // 
            // grdBaoCao
            // 
            this.grdBaoCao.DataSource = this.bdBaoCao;
            appearance7.BackColor = System.Drawing.Color.White;
            this.grdBaoCao.DisplayLayout.Appearance = appearance7;
            ultraGridColumn12.Header.Caption = "Bộ phận";
            ultraGridColumn12.Header.VisiblePosition = 0;
            ultraGridColumn12.Width = 150;
            ultraGridColumn17.Header.Caption = "Mã NV";
            ultraGridColumn17.Header.VisiblePosition = 1;
            ultraGridColumn19.Header.Caption = "Tên nhân viên";
            ultraGridColumn19.Header.VisiblePosition = 2;
            ultraGridColumn19.Width = 186;
            ultraGridColumn14.Header.Caption = "Chứcvụ";
            ultraGridColumn14.Header.VisiblePosition = 3;
            ultraGridColumn20.Header.Caption = "Từ ngày";
            ultraGridColumn20.Header.VisiblePosition = 4;
            ultraGridColumn13.Header.Caption = "Đến ngày";
            ultraGridColumn13.Header.VisiblePosition = 5;
            ultraGridColumn15.Header.Caption = "Ngày nghỉ";
            ultraGridColumn15.Header.VisiblePosition = 6;
            ultraGridColumn16.Header.Caption = "Hình thức nghỉ";
            ultraGridColumn16.Header.VisiblePosition = 7;
            ultraGridColumn18.Header.Caption = "Lý do";
            ultraGridColumn18.Header.VisiblePosition = 8;
            ultraGridColumn18.Width = 246;
            ultraGridBand2.Columns.AddRange(new object[] {
            ultraGridColumn12,
            ultraGridColumn17,
            ultraGridColumn19,
            ultraGridColumn14,
            ultraGridColumn20,
            ultraGridColumn13,
            ultraGridColumn15,
            ultraGridColumn16,
            ultraGridColumn18});
            this.grdBaoCao.DisplayLayout.BandsSerializer.Add(ultraGridBand2);
            this.grdBaoCao.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No;
            this.grdBaoCao.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.False;
            this.grdBaoCao.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.False;
            appearance8.BackColor = System.Drawing.Color.Transparent;
            this.grdBaoCao.DisplayLayout.Override.CardAreaAppearance = appearance8;
            this.grdBaoCao.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;
            this.grdBaoCao.DisplayLayout.Override.ColumnAutoSizeMode = Infragistics.Win.UltraWinGrid.ColumnAutoSizeMode.AllRowsInBand;
            appearance9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(135)))), ((int)(((byte)(214)))));
            appearance9.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(59)))), ((int)(((byte)(150)))));
            appearance9.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance9.FontData.BoldAsString = "True";
            appearance9.FontData.Name = "Arial";
            appearance9.FontData.SizeInPoints = 10F;
            appearance9.ForeColor = System.Drawing.Color.White;
            appearance9.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent;
            this.grdBaoCao.DisplayLayout.Override.HeaderAppearance = appearance9;
            this.grdBaoCao.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            appearance10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(135)))), ((int)(((byte)(214)))));
            appearance10.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(59)))), ((int)(((byte)(150)))));
            appearance10.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            this.grdBaoCao.DisplayLayout.Override.RowSelectorAppearance = appearance10;
            appearance11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(230)))), ((int)(((byte)(148)))));
            appearance11.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(149)))), ((int)(((byte)(21)))));
            appearance11.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            this.grdBaoCao.DisplayLayout.Override.SelectedRowAppearance = appearance11;
            this.grdBaoCao.DisplayLayout.Override.SelectTypeCell = Infragistics.Win.UltraWinGrid.SelectType.None;
            this.grdBaoCao.DisplayLayout.Override.SelectTypeCol = Infragistics.Win.UltraWinGrid.SelectType.None;
            this.grdBaoCao.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.Single;
            this.grdBaoCao.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.grdBaoCao.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.grdBaoCao.DisplayLayout.TabNavigation = Infragistics.Win.UltraWinGrid.TabNavigation.NextControl;
            this.grdBaoCao.DisplayLayout.ViewStyle = Infragistics.Win.UltraWinGrid.ViewStyle.SingleBand;
            this.grdBaoCao.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdBaoCao.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdBaoCao.Location = new System.Drawing.Point(0, 91);
            this.grdBaoCao.Name = "grdBaoCao";
            this.grdBaoCao.Size = new System.Drawing.Size(862, 386);
            this.grdBaoCao.TabIndex = 1;
            // 
            // bdBaoCao
            // 
            this.bdBaoCao.DataSource = typeof(ERP_Library.DanhSachNhanVienNghiViecList);
            // 
            // frmDanhSachNhanVienNghiViec
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(862, 477);
            this.Controls.Add(this.grdBaoCao);
            this.Controls.Add(this.grpFind);
            this.Name = "frmDanhSachNhanVienNghiViec";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Danh sách nhân viên nghỉ việc";
            this.Load += new System.EventHandler(this.frmDanhSachNhanVienNghiViec_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grpFind)).EndInit();
            this.grpFind.ResumeLayout(false);
            this.grpFind.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbBoPhan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdBaoCao)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdBaoCao)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Infragistics.Win.Misc.UltraGroupBox grpFind;
        private System.Windows.Forms.Label label4;
        private ComboboxNhanVien cmbNhanVien;
        private System.Windows.Forms.Button btnFind;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker txtDenNgay;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker txtTuNgay;
        private System.Windows.Forms.Label label1;
        private Infragistics.Win.UltraWinGrid.UltraGrid grdBaoCao;
        private System.Windows.Forms.BindingSource bdBaoCao;
        private Infragistics.Win.UltraWinGrid.UltraCombo cmbBoPhan;
    }
}