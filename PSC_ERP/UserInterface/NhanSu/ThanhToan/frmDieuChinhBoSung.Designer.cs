namespace PSC_ERP.UserInterface.NhanSu.ThanhToan
{
    partial class frmDieuChinhBoSung
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDieuChinhBoSung));
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand1 = new Infragistics.Win.UltraWinGrid.UltraGridBand("DieuChinhBoSung", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn2 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("MaChiTiet", -1, null, 0, Infragistics.Win.UltraWinGrid.SortIndicator.Ascending, false);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn3 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("MaNhanVien");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn4 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("MaKyTinhLuong");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn5 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Thang");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn6 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Nam");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn14 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("SoTien");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn15 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("DienGiai");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn16 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("LoaiDieuChinh");
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.ValueList valueList1 = new Infragistics.Win.ValueList(6301985);
            Infragistics.Win.ValueList valueList2 = new Infragistics.Win.ValueList(62527479);
            Infragistics.Win.ValueListItem valueListItem1 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem2 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem3 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem4 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem5 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem6 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem7 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem8 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand2 = new Infragistics.Win.UltraWinGrid.UltraGridBand("NhanVienComboListChild", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn13 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("MaNhanVien");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn17 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("MaQLNhanVien");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn18 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("TenNhanVien");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn19 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("CardID");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn20 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("TenChucVu");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn21 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("MaBoPhan");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn22 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("TenBoPhan");
            this.toolMain = new System.Windows.Forms.ToolStrip();
            this.tlslblLuu = new System.Windows.Forms.ToolStripButton();
            this.tlXoa = new System.Windows.Forms.ToolStripButton();
            this.tlUndo = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tlClose = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.grdData = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.bdDanhSach = new System.Windows.Forms.BindingSource(this.components);
            this.cmbKyLuong = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.cmb_LoaiDieuChinh = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.cmb_NhanVien = new Infragistics.Win.UltraWinGrid.UltraCombo();
            this.bdNhanVien = new System.Windows.Forms.BindingSource(this.components);
            this.cb_Nam = new System.Windows.Forms.ComboBox();
            this.lb_SoHieuTK = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.bdKyTinhLuong = new System.Windows.Forms.BindingSource(this.components);
            this.toolMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdDanhSach)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbKyLuong)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmb_LoaiDieuChinh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmb_NhanVien)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdNhanVien)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bdKyTinhLuong)).BeginInit();
            this.SuspendLayout();
            // 
            // toolMain
            // 
            this.toolMain.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.toolMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tlslblLuu,
            this.tlXoa,
            this.tlUndo,
            this.toolStripSeparator2,
            this.tlClose,
            this.toolStripButton1});
            this.toolMain.Location = new System.Drawing.Point(0, 0);
            this.toolMain.Name = "toolMain";
            this.toolMain.Size = new System.Drawing.Size(798, 26);
            this.toolMain.TabIndex = 4;
            this.toolMain.Text = "Chức năng";
            // 
            // tlslblLuu
            // 
            this.tlslblLuu.Name = "tlslblLuu";
            this.tlslblLuu.Size = new System.Drawing.Size(36, 23);
            this.tlslblLuu.Text = "&Lưu";
            this.tlslblLuu.Click += new System.EventHandler(this.tlslblLuu_Click);
            // 
            // tlXoa
            // 
            this.tlXoa.Name = "tlXoa";
            this.tlXoa.Size = new System.Drawing.Size(36, 23);
            this.tlXoa.Text = "&Xóa";
            this.tlXoa.Click += new System.EventHandler(this.tlXoa_Click);
            // 
            // tlUndo
            // 
            this.tlUndo.Name = "tlUndo";
            this.tlUndo.Size = new System.Drawing.Size(47, 23);
            this.tlUndo.Text = "&Undo";
            this.tlUndo.Click += new System.EventHandler(this.tlUndo_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 26);
            // 
            // tlClose
            // 
            this.tlClose.Name = "tlClose";
            this.tlClose.Size = new System.Drawing.Size(47, 23);
            this.tlClose.Text = "Đóng";
            this.tlClose.Click += new System.EventHandler(this.tlClose_Click);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(23, 23);
            this.toolStripButton1.Text = "toolStripButton1";
            // 
            // grdData
            // 
            this.grdData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdData.DataSource = this.bdDanhSach;
            appearance1.BackColor = System.Drawing.Color.White;
            this.grdData.DisplayLayout.Appearance = appearance1;
            this.grdData.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns;
            ultraGridColumn2.Header.VisiblePosition = 0;
            ultraGridColumn2.Width = 54;
            ultraGridColumn3.Header.VisiblePosition = 1;
            ultraGridColumn3.Width = 137;
            ultraGridColumn4.Header.VisiblePosition = 2;
            ultraGridColumn4.Width = 134;
            ultraGridColumn5.Header.VisiblePosition = 3;
            ultraGridColumn5.Width = 65;
            ultraGridColumn6.Header.VisiblePosition = 4;
            ultraGridColumn6.Width = 64;
            ultraGridColumn14.Header.VisiblePosition = 5;
            ultraGridColumn14.Width = 68;
            ultraGridColumn15.Header.VisiblePosition = 6;
            ultraGridColumn15.Width = 108;
            ultraGridColumn16.Header.VisiblePosition = 7;
            ultraGridColumn16.Width = 123;
            ultraGridBand1.Columns.AddRange(new object[] {
            ultraGridColumn2,
            ultraGridColumn3,
            ultraGridColumn4,
            ultraGridColumn5,
            ultraGridColumn6,
            ultraGridColumn14,
            ultraGridColumn15,
            ultraGridColumn16});
            ultraGridBand1.SummaryFooterCaption = "Tổng cộng";
            this.grdData.DisplayLayout.BandsSerializer.Add(ultraGridBand1);
            this.grdData.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No;
            this.grdData.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.False;
            this.grdData.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.True;
            this.grdData.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.True;
            appearance2.BackColor = System.Drawing.Color.Transparent;
            this.grdData.DisplayLayout.Override.CardAreaAppearance = appearance2;
            this.grdData.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.Edit;
            this.grdData.DisplayLayout.Override.ColumnAutoSizeMode = Infragistics.Win.UltraWinGrid.ColumnAutoSizeMode.AllRowsInBand;
            this.grdData.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains;
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
            this.grdData.DisplayLayout.Override.SelectTypeCell = Infragistics.Win.UltraWinGrid.SelectType.Single;
            this.grdData.DisplayLayout.Override.SelectTypeCol = Infragistics.Win.UltraWinGrid.SelectType.None;
            this.grdData.DisplayLayout.Override.SummaryDisplayArea = Infragistics.Win.UltraWinGrid.SummaryDisplayAreas.BottomFixed;
            this.grdData.DisplayLayout.Override.SummaryFooterCaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            valueList1.Key = "NganHang";
            valueList2.Key = "NguoiLap";
            this.grdData.DisplayLayout.ValueLists.AddRange(new Infragistics.Win.ValueList[] {
            valueList1,
            valueList2});
            this.grdData.DisplayLayout.ViewStyle = Infragistics.Win.UltraWinGrid.ViewStyle.SingleBand;
            this.grdData.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdData.Location = new System.Drawing.Point(0, 86);
            this.grdData.Name = "grdData";
            this.grdData.Size = new System.Drawing.Size(798, 323);
            this.grdData.TabIndex = 14;
            this.grdData.InitializeLayout += new Infragistics.Win.UltraWinGrid.InitializeLayoutEventHandler(this.grdData_InitializeLayout);
            // 
            // bdDanhSach
            // 
            this.bdDanhSach.AllowNew = true;
            this.bdDanhSach.DataSource = typeof(ERP_Library.DieuChinhBoSungList);
            // 
            // cmbKyLuong
            // 
            this.cmbKyLuong.DisplayMember = "TenKy";
            this.cmbKyLuong.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007;
            this.cmbKyLuong.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.cmbKyLuong.Location = new System.Drawing.Point(191, 165);
            this.cmbKyLuong.Name = "cmbKyLuong";
            this.cmbKyLuong.Size = new System.Drawing.Size(239, 21);
            this.cmbKyLuong.TabIndex = 15;
            this.cmbKyLuong.ValueMember = "MaKy";
            this.cmbKyLuong.Visible = false;
            // 
            // cmb_LoaiDieuChinh
            // 
            this.cmb_LoaiDieuChinh.DisplayMember = "";
            this.cmb_LoaiDieuChinh.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007;
            this.cmb_LoaiDieuChinh.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            valueListItem1.DataValue = 1;
            valueListItem1.DisplayText = "BH Xã hội";
            valueListItem2.DataValue = 2;
            valueListItem2.DisplayText = "BH Y Tế";
            valueListItem3.DataValue = 3;
            valueListItem3.DisplayText = "BH Thất Nghiệp";
            valueListItem4.DataValue = 4;
            valueListItem4.DisplayText = "Tổng Thu Nhập Chịu Thuế";
            valueListItem5.DataValue = 5;
            valueListItem5.DisplayText = "Thuế đã nộp";
            valueListItem6.DataValue = 6;
            valueListItem6.DisplayText = "Số tiền giảm trừ gia cảnh";
            valueListItem7.DataValue = 8;
            valueListItem7.DisplayText = "Tổng Thu Nhập";
            valueListItem8.DataValue = 100;
            valueListItem8.DisplayText = "Thuế Còn Phải Nộp";
            this.cmb_LoaiDieuChinh.Items.AddRange(new Infragistics.Win.ValueListItem[] {
            valueListItem1,
            valueListItem2,
            valueListItem3,
            valueListItem4,
            valueListItem5,
            valueListItem6,
            valueListItem7,
            valueListItem8});
            this.cmb_LoaiDieuChinh.Location = new System.Drawing.Point(191, 126);
            this.cmb_LoaiDieuChinh.Name = "cmb_LoaiDieuChinh";
            this.cmb_LoaiDieuChinh.Size = new System.Drawing.Size(239, 21);
            this.cmb_LoaiDieuChinh.TabIndex = 17;
            this.cmb_LoaiDieuChinh.ValueMember = "";
            this.cmb_LoaiDieuChinh.Visible = false;
            // 
            // cmb_NhanVien
            // 
            this.cmb_NhanVien.DataSource = this.bdNhanVien;
            ultraGridColumn13.Header.VisiblePosition = 0;
            ultraGridColumn13.Hidden = true;
            ultraGridColumn17.Header.Caption = "Mã QL ";
            ultraGridColumn17.Header.VisiblePosition = 1;
            ultraGridColumn18.Header.Caption = "Tên nhân viên";
            ultraGridColumn18.Header.VisiblePosition = 2;
            ultraGridColumn18.Width = 180;
            ultraGridColumn19.Header.VisiblePosition = 3;
            ultraGridColumn19.Hidden = true;
            ultraGridColumn20.Header.VisiblePosition = 4;
            ultraGridColumn20.Hidden = true;
            ultraGridColumn21.Header.VisiblePosition = 5;
            ultraGridColumn21.Hidden = true;
            ultraGridColumn22.Header.Caption = "Tên bộ phận";
            ultraGridColumn22.Header.VisiblePosition = 6;
            ultraGridColumn22.Width = 130;
            ultraGridBand2.Columns.AddRange(new object[] {
            ultraGridColumn13,
            ultraGridColumn17,
            ultraGridColumn18,
            ultraGridColumn19,
            ultraGridColumn20,
            ultraGridColumn21,
            ultraGridColumn22});
            this.cmb_NhanVien.DisplayLayout.BandsSerializer.Add(ultraGridBand2);
            this.cmb_NhanVien.DisplayMember = "TenNhanVien";
            this.cmb_NhanVien.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007;
            this.cmb_NhanVien.Location = new System.Drawing.Point(191, 209);
            this.cmb_NhanVien.Name = "cmb_NhanVien";
            this.cmb_NhanVien.Size = new System.Drawing.Size(239, 22);
            this.cmb_NhanVien.TabIndex = 18;
            this.cmb_NhanVien.ValueMember = "MaNhanVien";
            this.cmb_NhanVien.Visible = false;
            this.cmb_NhanVien.InitializeLayout += new Infragistics.Win.UltraWinGrid.InitializeLayoutEventHandler(this.cmb_NhanVien_InitializeLayout);
            // 
            // bdNhanVien
            // 
            this.bdNhanVien.AllowNew = true;
            this.bdNhanVien.DataSource = typeof(ERP_Library.NhanVienComboList);
            // 
            // cb_Nam
            // 
            this.cb_Nam.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cb_Nam.FormattingEnabled = true;
            this.cb_Nam.Location = new System.Drawing.Point(297, 16);
            this.cb_Nam.Name = "cb_Nam";
            this.cb_Nam.Size = new System.Drawing.Size(103, 24);
            this.cb_Nam.TabIndex = 19;
            // 
            // lb_SoHieuTK
            // 
            this.lb_SoHieuTK.AutoSize = true;
            this.lb_SoHieuTK.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_SoHieuTK.Location = new System.Drawing.Point(223, 19);
            this.lb_SoHieuTK.Name = "lb_SoHieuTK";
            this.lb_SoHieuTK.Size = new System.Drawing.Size(37, 16);
            this.lb_SoHieuTK.TabIndex = 20;
            this.lb_SoHieuTK.Text = "Năm";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.cb_Nam);
            this.groupBox1.Controls.Add(this.lb_SoHieuTK);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(0, 27);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(798, 53);
            this.groupBox1.TabIndex = 21;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Điều kiện";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(418, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 31);
            this.button1.TabIndex = 21;
            this.button1.Text = "Xem";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // bdKyTinhLuong
            // 
            this.bdKyTinhLuong.AllowNew = true;
            this.bdKyTinhLuong.DataSource = typeof(ERP_Library.DieuChinhBoSungList);
            // 
            // frmDieuChinhBoSung
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(798, 411);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.cmb_NhanVien);
            this.Controls.Add(this.cmb_LoaiDieuChinh);
            this.Controls.Add(this.cmbKyLuong);
            this.Controls.Add(this.grdData);
            this.Controls.Add(this.toolMain);
            this.Name = "frmDieuChinhBoSung";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Điều chỉnh bổ sung";
            this.toolMain.ResumeLayout(false);
            this.toolMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdDanhSach)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbKyLuong)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmb_LoaiDieuChinh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmb_NhanVien)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdNhanVien)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bdKyTinhLuong)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolMain;
        private System.Windows.Forms.ToolStripButton tlslblLuu;
        private System.Windows.Forms.ToolStripButton tlXoa;
        private System.Windows.Forms.ToolStripButton tlUndo;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton tlClose;
        private Infragistics.Win.UltraWinGrid.UltraGrid grdData;
        private System.Windows.Forms.BindingSource bdDanhSach;
        private System.Windows.Forms.BindingSource bdKyTinhLuong;
        private System.Windows.Forms.BindingSource bdNhanVien;
        private Infragistics.Win.UltraWinEditors.UltraComboEditor cmbKyLuong;
        private Infragistics.Win.UltraWinEditors.UltraComboEditor cmb_LoaiDieuChinh;
        private Infragistics.Win.UltraWinGrid.UltraCombo cmb_NhanVien;
        private System.Windows.Forms.ComboBox cb_Nam;
        private System.Windows.Forms.Label lb_SoHieuTK;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.Button button1;
    }
}