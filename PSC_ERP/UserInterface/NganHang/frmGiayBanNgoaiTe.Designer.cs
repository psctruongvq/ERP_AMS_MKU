namespace PSC_ERP
{
    partial class frmGiayBanNgoaiTe
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGiayBanNgoaiTe));
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand1 = new Infragistics.Win.UltraWinGrid.UltraGridBand("GiayBanNgoaiTe", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn19 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("MaPhieu");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn20 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("SoDeNghi");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn21 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("NganHangMua", -1, 6301985);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn22 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("NganHangBan", -1, 6301985);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn23 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("NgayXacNhan");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn24 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("TieuDe");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn25 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("SoTien");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn26 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("LoaiTien", -1, 21134345);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn27 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("MucDichThanhToan");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn28 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("SoKheUoc");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn29 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("NgaySoSach");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn30 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("SoTienBangChu");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn31 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("TyGia");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn32 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("NgayLap");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn33 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("UserID");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn34 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("NgaySua");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn35 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("NgaySuaString");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn36 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("LoaiMatHang");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn1 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("DeNghi_GiayBanNTList");
            Infragistics.Win.UltraWinGrid.SummarySettings summarySettings1 = new Infragistics.Win.UltraWinGrid.SummarySettings("SoTien", Infragistics.Win.UltraWinGrid.SummaryType.Sum, null, "SoTien", 6, true, "GiayBanNgoaiTe", 0, Infragistics.Win.UltraWinGrid.SummaryPosition.UseSummaryPositionColumn, "SoTien", 6, true);
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand2 = new Infragistics.Win.UltraWinGrid.UltraGridBand("DeNghi_GiayBanNTList", 0);
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.ValueList valueList1 = new Infragistics.Win.ValueList(6301985);
            Infragistics.Win.ValueList valueList2 = new Infragistics.Win.ValueList(21134345);
            this.toolMain = new System.Windows.Forms.ToolStrip();
            this.tlThem = new System.Windows.Forms.ToolStripButton();
            this.tlslblLuu = new System.Windows.Forms.ToolStripButton();
            this.tlSua = new System.Windows.Forms.ToolStripButton();
            this.tlXoa = new System.Windows.Forms.ToolStripButton();
            this.tlUndo = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.tlslblDNBanNgoaiTe = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tlClose = new System.Windows.Forms.ToolStripButton();
            this.grdData = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.bdChungTu = new System.Windows.Forms.BindingSource(this.components);
            this.txtDenNgay = new Infragistics.Win.UltraWinEditors.UltraDateTimeEditor();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTuNgay = new Infragistics.Win.UltraWinEditors.UltraDateTimeEditor();
            this.label1 = new System.Windows.Forms.Label();
            this.ultraGroupBox1 = new Infragistics.Win.Misc.UltraGroupBox();
            this.toolStripButton_Coppy = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdChungTu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDenNgay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTuNgay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox1)).BeginInit();
            this.ultraGroupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolMain
            // 
            this.toolMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tlThem,
            this.tlslblLuu,
            this.tlSua,
            this.tlXoa,
            this.tlUndo,
            this.toolStripButton1,
            this.tlslblDNBanNgoaiTe,
            this.toolStripSeparator2,
            this.tlClose,
            this.toolStripButton_Coppy,
            this.toolStripButton2});
            this.toolMain.Location = new System.Drawing.Point(0, 0);
            this.toolMain.Name = "toolMain";
            this.toolMain.Size = new System.Drawing.Size(1018, 25);
            this.toolMain.TabIndex = 3;
            this.toolMain.Text = "Chức năng";
            // 
            // tlThem
            // 
            this.tlThem.Image = ((System.Drawing.Image)(resources.GetObject("tlThem.Image")));
            this.tlThem.ImageTransparentColor = System.Drawing.Color.White;
            this.tlThem.Name = "tlThem";
            this.tlThem.Size = new System.Drawing.Size(58, 22);
            this.tlThem.Text = "&Thêm";
            this.tlThem.Click += new System.EventHandler(this.tlThem_Click);
            // 
            // tlslblLuu
            // 
            this.tlslblLuu.Image = ((System.Drawing.Image)(resources.GetObject("tlslblLuu.Image")));
            this.tlslblLuu.Name = "tlslblLuu";
            this.tlslblLuu.Size = new System.Drawing.Size(47, 22);
            this.tlslblLuu.Text = "&Lưu";
            this.tlslblLuu.Click += new System.EventHandler(this.tlslblLuu_Click);
            // 
            // tlSua
            // 
            this.tlSua.Image = ((System.Drawing.Image)(resources.GetObject("tlSua.Image")));
            this.tlSua.ImageTransparentColor = System.Drawing.Color.White;
            this.tlSua.Name = "tlSua";
            this.tlSua.Size = new System.Drawing.Size(46, 22);
            this.tlSua.Text = "&Sửa";
            this.tlSua.Click += new System.EventHandler(this.tlSua_Click);
            // 
            // tlXoa
            // 
            this.tlXoa.Image = ((System.Drawing.Image)(resources.GetObject("tlXoa.Image")));
            this.tlXoa.ImageTransparentColor = System.Drawing.Color.White;
            this.tlXoa.Name = "tlXoa";
            this.tlXoa.Size = new System.Drawing.Size(47, 22);
            this.tlXoa.Text = "&Xóa";
            this.tlXoa.Click += new System.EventHandler(this.tlXoa_Click);
            // 
            // tlUndo
            // 
            this.tlUndo.Image = ((System.Drawing.Image)(resources.GetObject("tlUndo.Image")));
            this.tlUndo.ImageTransparentColor = System.Drawing.Color.White;
            this.tlUndo.Name = "tlUndo";
            this.tlUndo.Size = new System.Drawing.Size(56, 22);
            this.tlUndo.Text = "&Undo";
            this.tlUndo.Click += new System.EventHandler(this.tlUndo_Click);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(89, 22);
            this.toolStripButton1.Text = "Export Excel";
            // 
            // tlslblDNBanNgoaiTe
            // 
            this.tlslblDNBanNgoaiTe.Image = ((System.Drawing.Image)(resources.GetObject("tlslblDNBanNgoaiTe.Image")));
            this.tlslblDNBanNgoaiTe.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tlslblDNBanNgoaiTe.Name = "tlslblDNBanNgoaiTe";
            this.tlslblDNBanNgoaiTe.Size = new System.Drawing.Size(83, 22);
            this.tlslblDNBanNgoaiTe.Text = "In Đề Nghị";
            this.tlslblDNBanNgoaiTe.Click += new System.EventHandler(this.tlslblDNBanNgoaiTe_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // tlClose
            // 
            this.tlClose.Image = ((System.Drawing.Image)(resources.GetObject("tlClose.Image")));
            this.tlClose.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tlClose.Name = "tlClose";
            this.tlClose.Size = new System.Drawing.Size(56, 22);
            this.tlClose.Text = "Đóng";
            this.tlClose.Click += new System.EventHandler(this.tlClose_Click);
            // 
            // grdData
            // 
            this.grdData.DataSource = this.bdChungTu;
            appearance1.BackColor = System.Drawing.Color.White;
            this.grdData.DisplayLayout.Appearance = appearance1;
            this.grdData.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns;
            ultraGridColumn19.Header.VisiblePosition = 0;
            ultraGridColumn19.Width = 17;
            ultraGridColumn20.Header.VisiblePosition = 1;
            ultraGridColumn20.Width = 85;
            ultraGridColumn21.Header.VisiblePosition = 2;
            ultraGridColumn21.Width = 96;
            ultraGridColumn22.Header.VisiblePosition = 3;
            ultraGridColumn22.Width = 54;
            ultraGridColumn23.Header.VisiblePosition = 4;
            ultraGridColumn23.Width = 98;
            ultraGridColumn24.Header.VisiblePosition = 5;
            ultraGridColumn24.Width = 45;
            ultraGridColumn25.Header.VisiblePosition = 6;
            ultraGridColumn25.Width = 37;
            ultraGridColumn26.Header.VisiblePosition = 7;
            ultraGridColumn26.Width = 34;
            ultraGridColumn27.Header.VisiblePosition = 8;
            ultraGridColumn27.Width = 70;
            ultraGridColumn28.Header.VisiblePosition = 9;
            ultraGridColumn28.Width = 45;
            ultraGridColumn29.Header.VisiblePosition = 10;
            ultraGridColumn29.Width = 46;
            ultraGridColumn30.Header.VisiblePosition = 11;
            ultraGridColumn30.Width = 60;
            ultraGridColumn31.Header.VisiblePosition = 12;
            ultraGridColumn31.Width = 37;
            ultraGridColumn32.Header.VisiblePosition = 13;
            ultraGridColumn32.Width = 41;
            ultraGridColumn33.Header.VisiblePosition = 14;
            ultraGridColumn33.Width = 28;
            ultraGridColumn34.Header.VisiblePosition = 15;
            ultraGridColumn34.Width = 41;
            ultraGridColumn35.Header.VisiblePosition = 16;
            ultraGridColumn35.Width = 54;
            ultraGridColumn36.Header.VisiblePosition = 17;
            ultraGridColumn36.Width = 90;
            ultraGridColumn1.Header.VisiblePosition = 18;
            ultraGridBand1.Columns.AddRange(new object[] {
            ultraGridColumn19,
            ultraGridColumn20,
            ultraGridColumn21,
            ultraGridColumn22,
            ultraGridColumn23,
            ultraGridColumn24,
            ultraGridColumn25,
            ultraGridColumn26,
            ultraGridColumn27,
            ultraGridColumn28,
            ultraGridColumn29,
            ultraGridColumn30,
            ultraGridColumn31,
            ultraGridColumn32,
            ultraGridColumn33,
            ultraGridColumn34,
            ultraGridColumn35,
            ultraGridColumn36,
            ultraGridColumn1});
            appearance2.TextHAlignAsString = "Right";
            summarySettings1.Appearance = appearance2;
            summarySettings1.DisplayFormat = "{0:#,###.##}";
            summarySettings1.GroupBySummaryValueAppearance = appearance3;
            ultraGridBand1.Summaries.AddRange(new Infragistics.Win.UltraWinGrid.SummarySettings[] {
            summarySettings1});
            ultraGridBand1.SummaryFooterCaption = "Tổng cộng";
            this.grdData.DisplayLayout.BandsSerializer.Add(ultraGridBand1);
            this.grdData.DisplayLayout.BandsSerializer.Add(ultraGridBand2);
            this.grdData.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No;
            this.grdData.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.False;
            this.grdData.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.True;
            appearance4.BackColor = System.Drawing.Color.Transparent;
            this.grdData.DisplayLayout.Override.CardAreaAppearance = appearance4;
            this.grdData.DisplayLayout.Override.ColumnAutoSizeMode = Infragistics.Win.UltraWinGrid.ColumnAutoSizeMode.AllRowsInBand;
            this.grdData.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow;
            appearance5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(135)))), ((int)(((byte)(214)))));
            appearance5.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(59)))), ((int)(((byte)(150)))));
            appearance5.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance5.FontData.BoldAsString = "True";
            appearance5.FontData.Name = "Arial";
            appearance5.FontData.SizeInPoints = 10F;
            appearance5.ForeColor = System.Drawing.Color.White;
            appearance5.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent;
            this.grdData.DisplayLayout.Override.HeaderAppearance = appearance5;
            this.grdData.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            appearance6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(135)))), ((int)(((byte)(214)))));
            appearance6.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(59)))), ((int)(((byte)(150)))));
            appearance6.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            this.grdData.DisplayLayout.Override.RowSelectorAppearance = appearance6;
            this.grdData.DisplayLayout.Override.RowSelectorNumberStyle = Infragistics.Win.UltraWinGrid.RowSelectorNumberStyle.RowIndex;
            appearance7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(230)))), ((int)(((byte)(148)))));
            appearance7.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(149)))), ((int)(((byte)(21)))));
            appearance7.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            this.grdData.DisplayLayout.Override.SelectedRowAppearance = appearance7;
            this.grdData.DisplayLayout.Override.SelectTypeCell = Infragistics.Win.UltraWinGrid.SelectType.None;
            this.grdData.DisplayLayout.Override.SelectTypeCol = Infragistics.Win.UltraWinGrid.SelectType.None;
            this.grdData.DisplayLayout.Override.SummaryDisplayArea = Infragistics.Win.UltraWinGrid.SummaryDisplayAreas.BottomFixed;
            this.grdData.DisplayLayout.Override.SummaryFooterCaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            this.grdData.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.grdData.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.grdData.DisplayLayout.TabNavigation = Infragistics.Win.UltraWinGrid.TabNavigation.NextControl;
            valueList1.Key = "NganHang";
            valueList2.Key = "LoaiTien";
            this.grdData.DisplayLayout.ValueLists.AddRange(new Infragistics.Win.ValueList[] {
            valueList1,
            valueList2});
            this.grdData.DisplayLayout.ViewStyle = Infragistics.Win.UltraWinGrid.ViewStyle.SingleBand;
            this.grdData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdData.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdData.Location = new System.Drawing.Point(0, 66);
            this.grdData.Name = "grdData";
            this.grdData.Size = new System.Drawing.Size(1018, 496);
            this.grdData.TabIndex = 10;
            this.grdData.InitializeLayout += new Infragistics.Win.UltraWinGrid.InitializeLayoutEventHandler(this.grdData_InitializeLayout);
            this.grdData.AfterRowsDeleted += new System.EventHandler(this.grdData_AfterRowsDeleted);
            this.grdData.BeforeRowsDeleted += new Infragistics.Win.UltraWinGrid.BeforeRowsDeletedEventHandler(this.grdData_BeforeRowsDeleted);
            this.grdData.DoubleClickRow += new Infragistics.Win.UltraWinGrid.DoubleClickRowEventHandler(this.grdData_DoubleClickRow);
            // 
            // bdChungTu
            // 
            this.bdChungTu.DataSource = typeof(ERP_Library.GiayBanNgoaiTeList);
            // 
            // txtDenNgay
            // 
            this.txtDenNgay.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007;
            this.txtDenNgay.Location = new System.Drawing.Point(555, 11);
            this.txtDenNgay.Name = "txtDenNgay";
            this.txtDenNgay.Size = new System.Drawing.Size(113, 21);
            this.txtDenNgay.TabIndex = 9;
            this.txtDenNgay.ValueChanged += new System.EventHandler(this.Ngay_Changed);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(497, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "đến ngày";
            // 
            // txtTuNgay
            // 
            this.txtTuNgay.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007;
            this.txtTuNgay.Location = new System.Drawing.Point(355, 11);
            this.txtTuNgay.Name = "txtTuNgay";
            this.txtTuNgay.Size = new System.Drawing.Size(113, 21);
            this.txtTuNgay.TabIndex = 7;
            this.txtTuNgay.ValueChanged += new System.EventHandler(this.Ngay_Changed);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(303, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Từ ngày";
            // 
            // ultraGroupBox1
            // 
            this.ultraGroupBox1.Controls.Add(this.txtDenNgay);
            this.ultraGroupBox1.Controls.Add(this.label1);
            this.ultraGroupBox1.Controls.Add(this.txtTuNgay);
            this.ultraGroupBox1.Controls.Add(this.label2);
            this.ultraGroupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.ultraGroupBox1.Location = new System.Drawing.Point(0, 25);
            this.ultraGroupBox1.Name = "ultraGroupBox1";
            this.ultraGroupBox1.Size = new System.Drawing.Size(1018, 41);
            this.ultraGroupBox1.TabIndex = 11;
            // 
            // toolStripButton_Coppy
            // 
            this.toolStripButton_Coppy.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_Coppy.Image")));
            this.toolStripButton_Coppy.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_Coppy.Name = "toolStripButton_Coppy";
            this.toolStripButton_Coppy.Size = new System.Drawing.Size(65, 22);
            this.toolStripButton_Coppy.Text = "Coppy ";
            this.toolStripButton_Coppy.Click += new System.EventHandler(this.toolStripButton_Coppy_Click);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(55, 22);
            this.toolStripButton2.Text = "Paste";
            this.toolStripButton2.Click += new System.EventHandler(this.toolStripButton2_Click_1);
            // 
            // frmGiayBanNgoaiTe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1018, 562);
            this.Controls.Add(this.grdData);
            this.Controls.Add(this.ultraGroupBox1);
            this.Controls.Add(this.toolMain);
            this.Name = "frmGiayBanNgoaiTe";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Danh sách Giấy Đề Nghị Bán Ngoại Tệ";
            this.Load += new System.EventHandler(this.frmChungTuNganHang_Load);
            this.toolMain.ResumeLayout(false);
            this.toolMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdChungTu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDenNgay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTuNgay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox1)).EndInit();
            this.ultraGroupBox1.ResumeLayout(false);
            this.ultraGroupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolMain;
        private System.Windows.Forms.ToolStripButton tlThem;
        private System.Windows.Forms.ToolStripButton tlSua;
        private System.Windows.Forms.ToolStripButton tlXoa;
        private System.Windows.Forms.ToolStripButton tlUndo;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton tlClose;
        private Infragistics.Win.UltraWinGrid.UltraGrid grdData;
        private Infragistics.Win.UltraWinEditors.UltraDateTimeEditor txtDenNgay;
        private System.Windows.Forms.Label label2;
        private Infragistics.Win.UltraWinEditors.UltraDateTimeEditor txtTuNgay;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.BindingSource bdChungTu;
        private System.Windows.Forms.ToolStripButton tlslblDNBanNgoaiTe;
        private Infragistics.Win.Misc.UltraGroupBox ultraGroupBox1;
        private System.Windows.Forms.ToolStripButton tlslblLuu;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton toolStripButton_Coppy;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
    }
}