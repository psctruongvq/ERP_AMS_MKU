namespace PSC_ERP
{
    partial class frmDaoTaoNgoaiEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDaoTaoNgoaiEdit));
            Infragistics.Win.Appearance appearance31 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand1 = new Infragistics.Win.UltraWinGrid.UltraGridBand("ChiTiet", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn1 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("MaDTNgoaiChiTiet");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn2 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("MaDTNgoai");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn3 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("HocVien");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn4 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("NgaySinh");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn5 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("GioiTinh", -1, 31928922);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn6 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("DiaChi");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn7 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("DienThoai");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn8 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("QueQuan", -1, 31975329);
            Infragistics.Win.Appearance appearance32 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance33 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance34 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance35 = new Infragistics.Win.Appearance();
            Infragistics.Win.ValueList valueList1 = new Infragistics.Win.ValueList(31928922);
            Infragistics.Win.ValueListItem valueListItem1 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem2 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueList valueList2 = new Infragistics.Win.ValueList(31975329);
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
            this.txtGhiChu = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.label13 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtMa = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTen = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.label3 = new System.Windows.Forms.Label();
            this.ultraDateTimeEditor1 = new Infragistics.Win.UltraWinEditors.UltraDateTimeEditor();
            this.ultraDateTimeEditor2 = new Infragistics.Win.UltraWinEditors.UltraDateTimeEditor();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.ultraNumericEditor1 = new Infragistics.Win.UltraWinEditors.UltraNumericEditor();
            this.grdChiTiet = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.bdData = new System.Windows.Forms.BindingSource(this.components);
            this.tlsMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtGhiChu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMa)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraDateTimeEditor1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraDateTimeEditor2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraNumericEditor1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdChiTiet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdData)).BeginInit();
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
            this.tlsMain.Size = new System.Drawing.Size(689, 25);
            this.tlsMain.TabIndex = 0;
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
            // txtGhiChu
            // 
            this.txtGhiChu.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bdData, "GhiChu", true));
            this.txtGhiChu.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007;
            this.txtGhiChu.Location = new System.Drawing.Point(64, 105);
            this.txtGhiChu.Multiline = true;
            this.txtGhiChu.Name = "txtGhiChu";
            this.txtGhiChu.Size = new System.Drawing.Size(511, 52);
            this.txtGhiChu.TabIndex = 11;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(14, 109);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(44, 13);
            this.label13.TabIndex = 10;
            this.label13.Text = "Ghi chú";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(22, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mã";
            // 
            // txtMa
            // 
            this.txtMa.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bdData, "MaQL", true));
            this.txtMa.Location = new System.Drawing.Point(64, 51);
            this.txtMa.Name = "txtMa";
            this.txtMa.Size = new System.Drawing.Size(90, 21);
            this.txtMa.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(174, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Tên chương trình";
            // 
            // txtTen
            // 
            this.txtTen.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bdData, "TenChuongTrinh", true));
            this.txtTen.Location = new System.Drawing.Point(268, 51);
            this.txtTen.Name = "txtTen";
            this.txtTen.Size = new System.Drawing.Size(307, 21);
            this.txtTen.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 82);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Từ ngày";
            // 
            // ultraDateTimeEditor1
            // 
            this.ultraDateTimeEditor1.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bdData, "TuNgay", true));
            this.ultraDateTimeEditor1.Location = new System.Drawing.Point(64, 78);
            this.ultraDateTimeEditor1.Name = "ultraDateTimeEditor1";
            this.ultraDateTimeEditor1.Size = new System.Drawing.Size(90, 21);
            this.ultraDateTimeEditor1.TabIndex = 5;
            // 
            // ultraDateTimeEditor2
            // 
            this.ultraDateTimeEditor2.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bdData, "DenNgay", true));
            this.ultraDateTimeEditor2.Location = new System.Drawing.Point(268, 78);
            this.ultraDateTimeEditor2.Name = "ultraDateTimeEditor2";
            this.ultraDateTimeEditor2.Size = new System.Drawing.Size(100, 21);
            this.ultraDateTimeEditor2.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(174, 82);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Đến ngày";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(421, 82);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(46, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Học phí";
            // 
            // ultraNumericEditor1
            // 
            this.ultraNumericEditor1.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bdData, "HocPhi", true));
            this.ultraNumericEditor1.FormatString = "#,###";
            this.ultraNumericEditor1.Location = new System.Drawing.Point(473, 78);
            this.ultraNumericEditor1.Name = "ultraNumericEditor1";
            this.ultraNumericEditor1.Size = new System.Drawing.Size(102, 21);
            this.ultraNumericEditor1.TabIndex = 9;
            // 
            // grdChiTiet
            // 
            this.grdChiTiet.DataMember = "ChiTiet";
            this.grdChiTiet.DataSource = this.bdData;
            appearance31.BackColor = System.Drawing.Color.White;
            this.grdChiTiet.DisplayLayout.Appearance = appearance31;
            this.grdChiTiet.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns;
            ultraGridColumn1.Header.VisiblePosition = 0;
            ultraGridColumn1.Hidden = true;
            ultraGridColumn2.Header.VisiblePosition = 1;
            ultraGridColumn2.Hidden = true;
            ultraGridColumn3.Header.Caption = "Tên học viên";
            ultraGridColumn3.Header.VisiblePosition = 2;
            ultraGridColumn3.Width = 142;
            ultraGridColumn4.Header.Caption = "Ngày sinh";
            ultraGridColumn4.Header.VisiblePosition = 3;
            ultraGridColumn4.Width = 76;
            ultraGridColumn5.Header.Caption = "Giới tính";
            ultraGridColumn5.Header.VisiblePosition = 4;
            ultraGridColumn5.Width = 67;
            ultraGridColumn6.Header.Caption = "Địa chỉ";
            ultraGridColumn6.Header.VisiblePosition = 5;
            ultraGridColumn6.Width = 163;
            ultraGridColumn7.Header.Caption = "Điện thoại";
            ultraGridColumn7.Header.VisiblePosition = 6;
            ultraGridColumn7.Width = 97;
            ultraGridColumn8.Header.Caption = "Quê quán";
            ultraGridColumn8.Header.VisiblePosition = 7;
            ultraGridColumn8.Nullable = Infragistics.Win.UltraWinGrid.Nullable.Nothing;
            ultraGridColumn8.Width = 94;
            ultraGridBand1.Columns.AddRange(new object[] {
            ultraGridColumn1,
            ultraGridColumn2,
            ultraGridColumn3,
            ultraGridColumn4,
            ultraGridColumn5,
            ultraGridColumn6,
            ultraGridColumn7,
            ultraGridColumn8});
            this.grdChiTiet.DisplayLayout.BandsSerializer.Add(ultraGridBand1);
            this.grdChiTiet.DisplayLayout.GroupByBox.Hidden = true;
            this.grdChiTiet.DisplayLayout.MaxColScrollRegions = 1;
            this.grdChiTiet.DisplayLayout.MaxRowScrollRegions = 1;
            this.grdChiTiet.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.TemplateOnTop;
            this.grdChiTiet.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.True;
            this.grdChiTiet.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.True;
            appearance32.BackColor = System.Drawing.Color.Transparent;
            this.grdChiTiet.DisplayLayout.Override.CardAreaAppearance = appearance32;
            this.grdChiTiet.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText;
            appearance33.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(135)))), ((int)(((byte)(214)))));
            appearance33.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(59)))), ((int)(((byte)(150)))));
            appearance33.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance33.FontData.BoldAsString = "True";
            appearance33.FontData.Name = "Arial";
            appearance33.FontData.SizeInPoints = 10F;
            appearance33.ForeColor = System.Drawing.Color.White;
            appearance33.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent;
            this.grdChiTiet.DisplayLayout.Override.HeaderAppearance = appearance33;
            this.grdChiTiet.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            appearance34.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(135)))), ((int)(((byte)(214)))));
            appearance34.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(59)))), ((int)(((byte)(150)))));
            appearance34.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            this.grdChiTiet.DisplayLayout.Override.RowSelectorAppearance = appearance34;
            appearance35.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(230)))), ((int)(((byte)(148)))));
            appearance35.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(149)))), ((int)(((byte)(21)))));
            appearance35.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            this.grdChiTiet.DisplayLayout.Override.SelectedRowAppearance = appearance35;
            this.grdChiTiet.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.grdChiTiet.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            valueList1.Key = "GioiTinh";
            valueListItem1.DataValue = false;
            valueListItem1.DisplayText = "Nam";
            valueListItem2.DataValue = true;
            valueListItem2.DisplayText = "Nữ";
            valueList1.ValueListItems.AddRange(new Infragistics.Win.ValueListItem[] {
            valueListItem1,
            valueListItem2});
            valueList2.Key = "QueQuan";
            this.grdChiTiet.DisplayLayout.ValueLists.AddRange(new Infragistics.Win.ValueList[] {
            valueList1,
            valueList2});
            this.grdChiTiet.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy;
            this.grdChiTiet.Location = new System.Drawing.Point(17, 163);
            this.grdChiTiet.Name = "grdChiTiet";
            this.grdChiTiet.Size = new System.Drawing.Size(660, 279);
            this.grdChiTiet.TabIndex = 12;
            this.grdChiTiet.BeforeRowsDeleted += new Infragistics.Win.UltraWinGrid.BeforeRowsDeletedEventHandler(this.grdChiTiet_BeforeRowsDeleted);
            // 
            // bdData
            // 
            this.bdData.DataSource = typeof(ERP_Library.DaoTaoNgoai);
            // 
            // frmDaoTaoNgoaiEdit
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(689, 454);
            this.Controls.Add(this.grdChiTiet);
            this.Controls.Add(this.ultraNumericEditor1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.ultraDateTimeEditor2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.ultraDateTimeEditor1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtTen);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtMa);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtGhiChu);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.tlsMain);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmDaoTaoNgoaiEdit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chương trình đào tạo ngoài";
            this.Load += new System.EventHandler(this.frmDaoTaoNgoaiEdit_Load);
            this.tlsMain.ResumeLayout(false);
            this.tlsMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtGhiChu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMa)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraDateTimeEditor1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraDateTimeEditor2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraNumericEditor1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdChiTiet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdData)).EndInit();
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
        private Infragistics.Win.UltraWinEditors.UltraTextEditor txtGhiChu;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label1;
        private Infragistics.Win.UltraWinEditors.UltraTextEditor txtMa;
        private System.Windows.Forms.Label label2;
        private Infragistics.Win.UltraWinEditors.UltraTextEditor txtTen;
        private System.Windows.Forms.Label label3;
        private Infragistics.Win.UltraWinEditors.UltraDateTimeEditor ultraDateTimeEditor1;
        private Infragistics.Win.UltraWinEditors.UltraDateTimeEditor ultraDateTimeEditor2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private Infragistics.Win.UltraWinEditors.UltraNumericEditor ultraNumericEditor1;
        private Infragistics.Win.UltraWinGrid.UltraGrid grdChiTiet;
        private System.Windows.Forms.BindingSource bdData;
    }
}