namespace PSC_ERP
{
    partial class frmChamTangCaTongHop
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
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand1 = new Infragistics.Win.UltraWinGrid.UltraGridBand("NhanVienComboListChild", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn1 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("MaNhanVien");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn2 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("MaQLNhanVien");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn3 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("TenNhanVien");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn4 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("CardID");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn5 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("TenChucVu");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn6 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("MaBoPhan");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn7 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("TenBoPhan");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn8 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Chon", 0);
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            this.radTatCa = new System.Windows.Forms.RadioButton();
            this.radNhanVien = new System.Windows.Forms.RadioButton();
            this.grdData = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.bdData = new System.Windows.Forms.BindingSource(this.components);
            this.btnDongY = new Infragistics.Win.Misc.UltraButton();
            this.btnKhong = new Infragistics.Win.Misc.UltraButton();
            this.radBoPhan = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.txtSoNV = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.txtNgayThuong = new Infragistics.Win.UltraWinEditors.UltraNumericEditor();
            this.txtT7CN = new Infragistics.Win.UltraWinEditors.UltraNumericEditor();
            this.txtNgayLe = new Infragistics.Win.UltraWinEditors.UltraNumericEditor();
            this.chkNgayThuong = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
            this.chkT7CN = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
            this.chkNgayLe = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
            ((System.ComponentModel.ISupportInitialize)(this.grdData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSoNV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNgayThuong)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtT7CN)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNgayLe)).BeginInit();
            this.SuspendLayout();
            // 
            // radTatCa
            // 
            this.radTatCa.AutoSize = true;
            this.radTatCa.Checked = true;
            this.radTatCa.Location = new System.Drawing.Point(12, 27);
            this.radTatCa.Name = "radTatCa";
            this.radTatCa.Size = new System.Drawing.Size(192, 17);
            this.radTatCa.TabIndex = 0;
            this.radTatCa.TabStop = true;
            this.radTatCa.Text = "Chấm tăng ca cho tất cả nhân viên";
            this.radTatCa.UseVisualStyleBackColor = true;
            // 
            // radNhanVien
            // 
            this.radNhanVien.AutoSize = true;
            this.radNhanVien.Location = new System.Drawing.Point(12, 73);
            this.radNhanVien.Name = "radNhanVien";
            this.radNhanVien.Size = new System.Drawing.Size(211, 17);
            this.radNhanVien.TabIndex = 2;
            this.radNhanVien.Text = "Chấm một vài nhân viên thuộc bộ phận";
            this.radNhanVien.UseVisualStyleBackColor = true;
            this.radNhanVien.CheckedChanged += new System.EventHandler(this.radNhanVien_CheckedChanged);
            // 
            // grdData
            // 
            this.grdData.DataSource = this.bdData;
            appearance1.BackColor = System.Drawing.Color.White;
            this.grdData.DisplayLayout.Appearance = appearance1;
            this.grdData.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ExtendLastColumn;
            ultraGridColumn1.Header.VisiblePosition = 1;
            ultraGridColumn1.Hidden = true;
            ultraGridColumn2.AllowRowSummaries = Infragistics.Win.UltraWinGrid.AllowRowSummaries.False;
            ultraGridColumn2.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;
            ultraGridColumn2.Header.Caption = "Mã nhân viên";
            ultraGridColumn2.Header.VisiblePosition = 2;
            ultraGridColumn3.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;
            ultraGridColumn3.Header.Caption = "Tên nhân viên";
            ultraGridColumn3.Header.VisiblePosition = 3;
            ultraGridColumn4.Header.VisiblePosition = 4;
            ultraGridColumn4.Hidden = true;
            ultraGridColumn5.Header.VisiblePosition = 5;
            ultraGridColumn5.Hidden = true;
            ultraGridColumn6.Header.VisiblePosition = 6;
            ultraGridColumn6.Hidden = true;
            ultraGridColumn7.Header.VisiblePosition = 7;
            ultraGridColumn7.Hidden = true;
            ultraGridColumn8.AllowGroupBy = Infragistics.Win.DefaultableBoolean.False;
            ultraGridColumn8.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;
            ultraGridColumn8.AllowRowSummaries = Infragistics.Win.UltraWinGrid.AllowRowSummaries.False;
            ultraGridColumn8.AutoSizeMode = Infragistics.Win.UltraWinGrid.ColumnAutoSizeMode.None;
            ultraGridColumn8.DataType = typeof(bool);
            ultraGridColumn8.DefaultCellValue = false;
            ultraGridColumn8.Header.Caption = "";
            ultraGridColumn8.Header.VisiblePosition = 0;
            ultraGridColumn8.SortIndicator = Infragistics.Win.UltraWinGrid.SortIndicator.Disabled;
            ultraGridColumn8.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox;
            ultraGridBand1.Columns.AddRange(new object[] {
            ultraGridColumn1,
            ultraGridColumn2,
            ultraGridColumn3,
            ultraGridColumn4,
            ultraGridColumn5,
            ultraGridColumn6,
            ultraGridColumn7,
            ultraGridColumn8});
            this.grdData.DisplayLayout.BandsSerializer.Add(ultraGridBand1);
            this.grdData.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No;
            this.grdData.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.False;
            this.grdData.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.True;
            appearance2.BackColor = System.Drawing.Color.Transparent;
            this.grdData.DisplayLayout.Override.CardAreaAppearance = appearance2;
            this.grdData.DisplayLayout.Override.ColumnAutoSizeMode = Infragistics.Win.UltraWinGrid.ColumnAutoSizeMode.AllRowsInBand;
            this.grdData.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains;
            this.grdData.DisplayLayout.Override.FilterOperatorDropDownItems = Infragistics.Win.UltraWinGrid.FilterOperatorDropDownItems.Contains;
            this.grdData.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow;
            appearance3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(135)))), ((int)(((byte)(214)))));
            appearance3.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(59)))), ((int)(((byte)(150)))));
            appearance3.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance3.FontData.BoldAsString = "True";
            appearance3.FontData.Name = "Arial";
            appearance3.FontData.SizeInPoints = 10F;
            appearance3.ForeColor = System.Drawing.Color.White;
            appearance3.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent;
            this.grdData.DisplayLayout.Override.HeaderAppearance = appearance3;
            this.grdData.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            appearance4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(135)))), ((int)(((byte)(214)))));
            appearance4.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(59)))), ((int)(((byte)(150)))));
            appearance4.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            this.grdData.DisplayLayout.Override.RowSelectorAppearance = appearance4;
            this.grdData.DisplayLayout.Override.RowSelectorNumberStyle = Infragistics.Win.UltraWinGrid.RowSelectorNumberStyle.RowIndex;
            appearance5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(230)))), ((int)(((byte)(148)))));
            appearance5.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(149)))), ((int)(((byte)(21)))));
            appearance5.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            this.grdData.DisplayLayout.Override.SelectedRowAppearance = appearance5;
            this.grdData.DisplayLayout.Override.SelectTypeCell = Infragistics.Win.UltraWinGrid.SelectType.None;
            this.grdData.DisplayLayout.Override.SelectTypeCol = Infragistics.Win.UltraWinGrid.SelectType.None;
            this.grdData.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.Single;
            this.grdData.DisplayLayout.Override.SummaryDisplayArea = Infragistics.Win.UltraWinGrid.SummaryDisplayAreas.RootRowsFootersOnly;
            this.grdData.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.grdData.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.grdData.DisplayLayout.TabNavigation = Infragistics.Win.UltraWinGrid.TabNavigation.NextControl;
            this.grdData.DisplayLayout.ViewStyle = Infragistics.Win.UltraWinGrid.ViewStyle.SingleBand;
            this.grdData.Location = new System.Drawing.Point(12, 96);
            this.grdData.Name = "grdData";
            this.grdData.Size = new System.Drawing.Size(432, 321);
            this.grdData.TabIndex = 3;
            this.grdData.AfterCellUpdate += new Infragistics.Win.UltraWinGrid.CellEventHandler(this.grdData_AfterCellUpdate);
            this.grdData.CellChange += new Infragistics.Win.UltraWinGrid.CellEventHandler(this.grdData_CellChange);
            // 
            // bdData
            // 
            this.bdData.DataSource = typeof(ERP_Library.NhanVienComboList);
            // 
            // btnDongY
            // 
            this.btnDongY.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDongY.Location = new System.Drawing.Point(138, 512);
            this.btnDongY.Name = "btnDongY";
            this.btnDongY.Size = new System.Drawing.Size(87, 30);
            this.btnDongY.TabIndex = 10;
            this.btnDongY.Text = "Đồng ý";
            this.btnDongY.Click += new System.EventHandler(this.btnDongY_Click);
            // 
            // btnKhong
            // 
            this.btnKhong.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnKhong.Location = new System.Drawing.Point(231, 512);
            this.btnKhong.Name = "btnKhong";
            this.btnKhong.Size = new System.Drawing.Size(87, 30);
            this.btnKhong.TabIndex = 11;
            this.btnKhong.Text = "Không";
            this.btnKhong.Click += new System.EventHandler(this.btnKhong_Click);
            // 
            // radBoPhan
            // 
            this.radBoPhan.AutoSize = true;
            this.radBoPhan.Location = new System.Drawing.Point(12, 50);
            this.radBoPhan.Name = "radBoPhan";
            this.radBoPhan.Size = new System.Drawing.Size(201, 17);
            this.radBoPhan.TabIndex = 1;
            this.radBoPhan.Text = "Chấm tất cả nhân viên trong bộ phận";
            this.radBoPhan.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(367, 75);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Số NV";
            // 
            // txtSoNV
            // 
            this.txtSoNV.Enabled = false;
            this.txtSoNV.Location = new System.Drawing.Point(411, 67);
            this.txtSoNV.Name = "txtSoNV";
            this.txtSoNV.Size = new System.Drawing.Size(33, 21);
            this.txtSoNV.TabIndex = 13;
            // 
            // txtNgayThuong
            // 
            this.txtNgayThuong.Enabled = false;
            this.txtNgayThuong.FormatString = "#.##";
            this.txtNgayThuong.Location = new System.Drawing.Point(242, 427);
            this.txtNgayThuong.Name = "txtNgayThuong";
            this.txtNgayThuong.NumericType = Infragistics.Win.UltraWinEditors.NumericType.Double;
            this.txtNgayThuong.Size = new System.Drawing.Size(51, 21);
            this.txtNgayThuong.TabIndex = 5;
            // 
            // txtT7CN
            // 
            this.txtT7CN.Enabled = false;
            this.txtT7CN.FormatString = "#.##";
            this.txtT7CN.Location = new System.Drawing.Point(242, 453);
            this.txtT7CN.Name = "txtT7CN";
            this.txtT7CN.NumericType = Infragistics.Win.UltraWinEditors.NumericType.Double;
            this.txtT7CN.Size = new System.Drawing.Size(51, 21);
            this.txtT7CN.TabIndex = 7;
            // 
            // txtNgayLe
            // 
            this.txtNgayLe.Enabled = false;
            this.txtNgayLe.FormatString = "#.##";
            this.txtNgayLe.Location = new System.Drawing.Point(242, 479);
            this.txtNgayLe.Name = "txtNgayLe";
            this.txtNgayLe.NumericType = Infragistics.Win.UltraWinEditors.NumericType.Double;
            this.txtNgayLe.Size = new System.Drawing.Size(51, 21);
            this.txtNgayLe.TabIndex = 9;
            // 
            // chkNgayThuong
            // 
            this.chkNgayThuong.GlyphStyle = Infragistics.Win.GlyphStyle.Office2007;
            this.chkNgayThuong.Location = new System.Drawing.Point(11, 428);
            this.chkNgayThuong.Name = "chkNgayThuong";
            this.chkNgayThuong.Size = new System.Drawing.Size(212, 20);
            this.chkNgayThuong.TabIndex = 4;
            this.chkNgayThuong.Text = "Cập nhật số giờ tăng ca ngày thường";
            this.chkNgayThuong.CheckedChanged += new System.EventHandler(this.chkNgayThuong_CheckedChanged);
            // 
            // chkT7CN
            // 
            this.chkT7CN.GlyphStyle = Infragistics.Win.GlyphStyle.Office2007;
            this.chkT7CN.Location = new System.Drawing.Point(11, 454);
            this.chkT7CN.Name = "chkT7CN";
            this.chkT7CN.Size = new System.Drawing.Size(225, 20);
            this.chkT7CN.TabIndex = 6;
            this.chkT7CN.Text = "Cập nhật số giờ tăng ca thứ 7, Chủ nhật";
            this.chkT7CN.CheckedChanged += new System.EventHandler(this.chkT7CN_CheckedChanged);
            // 
            // chkNgayLe
            // 
            this.chkNgayLe.GlyphStyle = Infragistics.Win.GlyphStyle.Office2007;
            this.chkNgayLe.Location = new System.Drawing.Point(11, 480);
            this.chkNgayLe.Name = "chkNgayLe";
            this.chkNgayLe.Size = new System.Drawing.Size(202, 20);
            this.chkNgayLe.TabIndex = 8;
            this.chkNgayLe.Text = "Cập nhật số giờ tăng ca ngày lễ";
            this.chkNgayLe.CheckedChanged += new System.EventHandler(this.chkNgayLe_CheckedChanged);
            // 
            // frmChamTangCaTongHop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(456, 554);
            this.ControlBox = false;
            this.Controls.Add(this.chkNgayLe);
            this.Controls.Add(this.chkT7CN);
            this.Controls.Add(this.chkNgayThuong);
            this.Controls.Add(this.txtNgayLe);
            this.Controls.Add(this.txtT7CN);
            this.Controls.Add(this.txtNgayThuong);
            this.Controls.Add(this.txtSoNV);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.radBoPhan);
            this.Controls.Add(this.btnKhong);
            this.Controls.Add(this.btnDongY);
            this.Controls.Add(this.grdData);
            this.Controls.Add(this.radNhanVien);
            this.Controls.Add(this.radTatCa);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmChamTangCaTongHop";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chấm tăng ca hàng loạt";
            this.Load += new System.EventHandler(this.frmChamTangCaHangLoat_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSoNV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNgayThuong)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtT7CN)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNgayLe)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton radTatCa;
        private System.Windows.Forms.RadioButton radNhanVien;
        private Infragistics.Win.UltraWinGrid.UltraGrid grdData;
        private Infragistics.Win.Misc.UltraButton btnDongY;
        private Infragistics.Win.Misc.UltraButton btnKhong;
        private System.Windows.Forms.RadioButton radBoPhan;
        private System.Windows.Forms.BindingSource bdData;
        private System.Windows.Forms.Label label3;
        private Infragistics.Win.UltraWinEditors.UltraTextEditor txtSoNV;
        private Infragistics.Win.UltraWinEditors.UltraNumericEditor txtNgayThuong;
        private Infragistics.Win.UltraWinEditors.UltraNumericEditor txtT7CN;
        private Infragistics.Win.UltraWinEditors.UltraNumericEditor txtNgayLe;
        private Infragistics.Win.UltraWinEditors.UltraCheckEditor chkNgayThuong;
        private Infragistics.Win.UltraWinEditors.UltraCheckEditor chkT7CN;
        private Infragistics.Win.UltraWinEditors.UltraCheckEditor chkNgayLe;
    }
}