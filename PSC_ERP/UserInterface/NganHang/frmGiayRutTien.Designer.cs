namespace PSC_ERP
{
    partial class frmGiayRutTien
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGiayRutTien));
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand1 = new Infragistics.Win.UltraWinGrid.UltraGridBand("GiayRutTien", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn1 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("MaGiayRutTien");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn2 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("So");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn8 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("MaCongTy");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn9 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("TenCongTy");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn10 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("TaiKhoanRut", -1, 6301985);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn12 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("NguoiLinhTien");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn15 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("TenNguoiLinh");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn16 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Cmnd");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn19 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("NgayCap");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn21 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("NoiCap");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn7 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("SoTien");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn23 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("NoiDung");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn5 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("GhiChu");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn14 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("SoTienBangChu");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn4 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("DienGiai");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn11 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("UserId");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn3 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("NgayLap", -1, null, 0, Infragistics.Win.UltraWinGrid.SortIndicator.Ascending, false);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn6 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("NgayXacNhan");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn26 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("CTGiayRutTienList");
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand2 = new Infragistics.Win.UltraWinGrid.UltraGridBand("CTGiayRutTienList", 0);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn27 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("MaChiTiet");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn28 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("MaGiayRutTien");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn29 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("NoiDung");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn30 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("SoTien");
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.ValueList valueList1 = new Infragistics.Win.ValueList(6301985);
            this.toolMain = new System.Windows.Forms.ToolStrip();
            this.tlThem = new System.Windows.Forms.ToolStripButton();
            this.tlslblLuu = new System.Windows.Forms.ToolStripButton();
            this.tlSua = new System.Windows.Forms.ToolStripButton();
            this.tlXoa = new System.Windows.Forms.ToolStripButton();
            this.tlUndo = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.tlslblInLenh = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tlClose = new System.Windows.Forms.ToolStripButton();
            this.grdData = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.bdChungTu = new System.Windows.Forms.BindingSource(this.components);
            this.txtDenNgay = new Infragistics.Win.UltraWinEditors.UltraDateTimeEditor();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTuNgay = new Infragistics.Win.UltraWinEditors.UltraDateTimeEditor();
            this.label1 = new System.Windows.Forms.Label();
            this.ultraGroupBox1 = new Infragistics.Win.Misc.UltraGroupBox();
            this.tlslblInLenh_Exim = new System.Windows.Forms.ToolStripButton();
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
            this.tlslblInLenh_Exim,
            this.tlslblInLenh,
            this.toolStripSeparator2,
            this.tlClose});
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
            // tlslblInLenh
            // 
            this.tlslblInLenh.Image = ((System.Drawing.Image)(resources.GetObject("tlslblInLenh.Image")));
            this.tlslblInLenh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tlslblInLenh.Name = "tlslblInLenh";
            this.tlslblInLenh.Size = new System.Drawing.Size(110, 22);
            this.tlslblInLenh.Text = "In Giấy Rút Tiền";
            this.tlslblInLenh.Click += new System.EventHandler(this.tlslblDNBanNgoaiTe_Click);
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
            ultraGridColumn1.Header.VisiblePosition = 0;
            ultraGridColumn1.Hidden = true;
            ultraGridColumn1.Width = 66;
            ultraGridColumn2.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            ultraGridColumn2.Header.Caption = "Số chứng từ";
            ultraGridColumn2.Header.VisiblePosition = 1;
            ultraGridColumn2.Width = 124;
            ultraGridColumn8.Header.VisiblePosition = 2;
            ultraGridColumn8.Hidden = true;
            ultraGridColumn8.Width = 59;
            ultraGridColumn9.Header.Caption = "Công ty";
            ultraGridColumn9.Header.VisiblePosition = 5;
            ultraGridColumn9.Hidden = true;
            ultraGridColumn9.Width = 128;
            ultraGridColumn10.Header.Caption = "Số tài khoản";
            ultraGridColumn10.Header.VisiblePosition = 7;
            ultraGridColumn10.Width = 163;
            ultraGridColumn12.Header.VisiblePosition = 8;
            ultraGridColumn12.Hidden = true;
            ultraGridColumn12.Width = 72;
            ultraGridColumn15.Header.Caption = "Tên người nhận tiền";
            ultraGridColumn15.Header.VisiblePosition = 9;
            ultraGridColumn15.Width = 194;
            ultraGridColumn16.Header.VisiblePosition = 10;
            ultraGridColumn16.Hidden = true;
            ultraGridColumn16.Width = 68;
            ultraGridColumn19.Header.VisiblePosition = 11;
            ultraGridColumn19.Hidden = true;
            ultraGridColumn19.Width = 65;
            ultraGridColumn21.Header.VisiblePosition = 12;
            ultraGridColumn21.Hidden = true;
            ultraGridColumn21.Width = 85;
            ultraGridColumn7.Format = "#,###";
            ultraGridColumn7.Header.Caption = "Số tiền";
            ultraGridColumn7.Header.VisiblePosition = 6;
            ultraGridColumn7.Width = 97;
            ultraGridColumn23.Header.Caption = "Nội dung";
            ultraGridColumn23.Header.VisiblePosition = 14;
            ultraGridColumn23.Width = 179;
            ultraGridColumn5.Header.VisiblePosition = 15;
            ultraGridColumn5.Hidden = true;
            ultraGridColumn5.Width = 61;
            ultraGridColumn14.Header.VisiblePosition = 16;
            ultraGridColumn14.Hidden = true;
            ultraGridColumn14.Width = 52;
            ultraGridColumn4.Header.VisiblePosition = 13;
            ultraGridColumn4.Hidden = true;
            ultraGridColumn4.Width = 51;
            ultraGridColumn11.Header.VisiblePosition = 17;
            ultraGridColumn11.Hidden = true;
            ultraGridColumn11.Width = 20;
            ultraGridColumn3.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            ultraGridColumn3.Header.Caption = "Ngày lập";
            ultraGridColumn3.Header.VisiblePosition = 4;
            ultraGridColumn3.Width = 105;
            ultraGridColumn6.Header.Caption = "Ngày xác nhận";
            ultraGridColumn6.Header.VisiblePosition = 3;
            ultraGridColumn6.Width = 116;
            ultraGridColumn26.Header.VisiblePosition = 18;
            ultraGridBand1.Columns.AddRange(new object[] {
            ultraGridColumn1,
            ultraGridColumn2,
            ultraGridColumn8,
            ultraGridColumn9,
            ultraGridColumn10,
            ultraGridColumn12,
            ultraGridColumn15,
            ultraGridColumn16,
            ultraGridColumn19,
            ultraGridColumn21,
            ultraGridColumn7,
            ultraGridColumn23,
            ultraGridColumn5,
            ultraGridColumn14,
            ultraGridColumn4,
            ultraGridColumn11,
            ultraGridColumn3,
            ultraGridColumn6,
            ultraGridColumn26});
            ultraGridBand1.SummaryFooterCaption = "Tổng cộng:";
            ultraGridColumn27.Header.VisiblePosition = 0;
            ultraGridColumn28.Header.VisiblePosition = 1;
            ultraGridColumn29.Header.VisiblePosition = 2;
            ultraGridColumn30.Header.VisiblePosition = 3;
            ultraGridBand2.Columns.AddRange(new object[] {
            ultraGridColumn27,
            ultraGridColumn28,
            ultraGridColumn29,
            ultraGridColumn30});
            this.grdData.DisplayLayout.BandsSerializer.Add(ultraGridBand1);
            this.grdData.DisplayLayout.BandsSerializer.Add(ultraGridBand2);
            this.grdData.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No;
            this.grdData.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.False;
            this.grdData.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.True;
            appearance2.BackColor = System.Drawing.Color.Transparent;
            this.grdData.DisplayLayout.Override.CardAreaAppearance = appearance2;
            this.grdData.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;
            this.grdData.DisplayLayout.Override.ColumnAutoSizeMode = Infragistics.Win.UltraWinGrid.ColumnAutoSizeMode.AllRowsInBand;
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
            this.grdData.DisplayLayout.Override.SummaryDisplayArea = Infragistics.Win.UltraWinGrid.SummaryDisplayAreas.BottomFixed;
            appearance6.TextHAlignAsString = "Right";
            this.grdData.DisplayLayout.Override.SummaryFooterAppearance = appearance6;
            this.grdData.DisplayLayout.Override.SummaryFooterCaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            this.grdData.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.grdData.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.grdData.DisplayLayout.TabNavigation = Infragistics.Win.UltraWinGrid.TabNavigation.NextControl;
            valueList1.Key = "NganHang";
            this.grdData.DisplayLayout.ValueLists.AddRange(new Infragistics.Win.ValueList[] {
            valueList1});
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
            this.bdChungTu.DataSource = typeof(ERP_Library.GiayRutTienList);
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
            // tlslblInLenh_Exim
            // 
            this.tlslblInLenh_Exim.Image = ((System.Drawing.Image)(resources.GetObject("tlslblInLenh_Exim.Image")));
            this.tlslblInLenh_Exim.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tlslblInLenh_Exim.Name = "tlslblInLenh_Exim";
            this.tlslblInLenh_Exim.Size = new System.Drawing.Size(172, 22);
            this.tlslblInLenh_Exim.Text = "In Giấy Rút Tiền (Eximbank)";
            this.tlslblInLenh_Exim.Click += new System.EventHandler(this.tlslblInLenh_Exim_Click);
            // 
            // frmGiayRutTien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1018, 562);
            this.Controls.Add(this.grdData);
            this.Controls.Add(this.ultraGroupBox1);
            this.Controls.Add(this.toolMain);
            this.Name = "frmGiayRutTien";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Danh sách giấy rút tiền";
            this.Load += new System.EventHandler(this.frmGiayRutTien_Load);
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
        private System.Windows.Forms.ToolStripButton tlslblInLenh;
        private Infragistics.Win.Misc.UltraGroupBox ultraGroupBox1;
        private System.Windows.Forms.ToolStripButton tlslblLuu;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton tlslblInLenh_Exim;
    }
}