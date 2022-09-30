namespace PSC_ERP
{
    partial class frmDanhSachNgayNghiTrongNam
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
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand1 = new Infragistics.Win.UltraWinGrid.UltraGridBand("NgayHoliday", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn1 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("MaNgayHoliday");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn2 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Ngay");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn3 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("TenNgayHoliday");
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDanhSachNgayNghiTrongNam));
            this.grdu_BacLuongCoBan = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.NgayHoliday_BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gbx_ThongNghiViec = new System.Windows.Forms.GroupBox();
            this.txtu_TenNgayNghi = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.lbl_TenNgayNghi = new System.Windows.Forms.Label();
            this.dtmp_NgayNghi = new Infragistics.Win.UltraWinEditors.UltraDateTimeEditor();
            this.lbl_NgayNghi = new System.Windows.Forms.Label();
            this.tlsMain = new System.Windows.Forms.ToolStrip();
            this.tlslblThem = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
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
            ((System.ComponentModel.ISupportInitialize)(this.grdu_BacLuongCoBan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NgayHoliday_BindingSource)).BeginInit();
            this.gbx_ThongNghiViec.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtu_TenNgayNghi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtmp_NgayNghi)).BeginInit();
            this.tlsMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // grdu_BacLuongCoBan
            // 
            this.grdu_BacLuongCoBan.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grdu_BacLuongCoBan.DataSource = this.NgayHoliday_BindingSource;
            appearance3.BackColor = System.Drawing.Color.White;
            appearance3.FontData.BoldAsString = "False";
            this.grdu_BacLuongCoBan.DisplayLayout.Appearance = appearance3;
            ultraGridColumn1.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            ultraGridColumn1.Header.VisiblePosition = 1;
            ultraGridColumn2.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            ultraGridColumn2.Header.VisiblePosition = 2;
            ultraGridColumn3.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            ultraGridColumn3.Header.VisiblePosition = 0;
            ultraGridBand1.Columns.AddRange(new object[] {
            ultraGridColumn1,
            ultraGridColumn2,
            ultraGridColumn3});
            this.grdu_BacLuongCoBan.DisplayLayout.BandsSerializer.Add(ultraGridBand1);
            this.grdu_BacLuongCoBan.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            this.grdu_BacLuongCoBan.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.Yes;
            appearance1.BackColor = System.Drawing.Color.SteelBlue;
            this.grdu_BacLuongCoBan.DisplayLayout.Override.HeaderAppearance = appearance1;
            this.grdu_BacLuongCoBan.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand;
            this.grdu_BacLuongCoBan.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdu_BacLuongCoBan.Location = new System.Drawing.Point(0, 86);
            this.grdu_BacLuongCoBan.Name = "grdu_BacLuongCoBan";
            this.grdu_BacLuongCoBan.Size = new System.Drawing.Size(578, 239);
            this.grdu_BacLuongCoBan.TabIndex = 29;
            this.grdu_BacLuongCoBan.InitializeLayout += new Infragistics.Win.UltraWinGrid.InitializeLayoutEventHandler(this.grdu_BacLuongCoBan_InitializeLayout);
            // 
            // NgayHoliday_BindingSource
            // 
            this.NgayHoliday_BindingSource.AllowNew = true;
            this.NgayHoliday_BindingSource.DataSource = typeof(ERP_Library.NgayHolidayList);
            // 
            // gbx_ThongNghiViec
            // 
            this.gbx_ThongNghiViec.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gbx_ThongNghiViec.Controls.Add(this.txtu_TenNgayNghi);
            this.gbx_ThongNghiViec.Controls.Add(this.lbl_TenNgayNghi);
            this.gbx_ThongNghiViec.Controls.Add(this.dtmp_NgayNghi);
            this.gbx_ThongNghiViec.Controls.Add(this.lbl_NgayNghi);
            this.gbx_ThongNghiViec.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbx_ThongNghiViec.Location = new System.Drawing.Point(2, 28);
            this.gbx_ThongNghiViec.Name = "gbx_ThongNghiViec";
            this.gbx_ThongNghiViec.Size = new System.Drawing.Size(576, 55);
            this.gbx_ThongNghiViec.TabIndex = 30;
            this.gbx_ThongNghiViec.TabStop = false;
            this.gbx_ThongNghiViec.Text = "Thông Tin Nghỉ Việc";
            // 
            // txtu_TenNgayNghi
            // 
            this.txtu_TenNgayNghi.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            appearance4.FontData.BoldAsString = "False";
            this.txtu_TenNgayNghi.Appearance = appearance4;
            this.txtu_TenNgayNghi.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.NgayHoliday_BindingSource, "TenNgayHoliday", true));
            this.txtu_TenNgayNghi.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007;
            this.txtu_TenNgayNghi.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtu_TenNgayNghi.Location = new System.Drawing.Point(306, 22);
            this.txtu_TenNgayNghi.Name = "txtu_TenNgayNghi";
            this.txtu_TenNgayNghi.Size = new System.Drawing.Size(262, 21);
            this.txtu_TenNgayNghi.TabIndex = 7;
            // 
            // lbl_TenNgayNghi
            // 
            this.lbl_TenNgayNghi.AutoSize = true;
            this.lbl_TenNgayNghi.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_TenNgayNghi.Location = new System.Drawing.Point(215, 26);
            this.lbl_TenNgayNghi.Name = "lbl_TenNgayNghi";
            this.lbl_TenNgayNghi.Size = new System.Drawing.Size(82, 13);
            this.lbl_TenNgayNghi.TabIndex = 0;
            this.lbl_TenNgayNghi.Text = "Tên Ngày Nghĩ";
            // 
            // dtmp_NgayNghi
            // 
            appearance5.FontData.BoldAsString = "False";
            this.dtmp_NgayNghi.Appearance = appearance5;
            this.dtmp_NgayNghi.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.NgayHoliday_BindingSource, "Ngay", true));
            this.dtmp_NgayNghi.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007;
            this.dtmp_NgayNghi.FormatString = "dd/MM/yyyy";
            this.dtmp_NgayNghi.Location = new System.Drawing.Point(73, 22);
            this.dtmp_NgayNghi.Name = "dtmp_NgayNghi";
            this.dtmp_NgayNghi.Size = new System.Drawing.Size(127, 21);
            this.dtmp_NgayNghi.TabIndex = 0;
            // 
            // lbl_NgayNghi
            // 
            this.lbl_NgayNghi.AutoSize = true;
            this.lbl_NgayNghi.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_NgayNghi.Location = new System.Drawing.Point(8, 26);
            this.lbl_NgayNghi.Name = "lbl_NgayNghi";
            this.lbl_NgayNghi.Size = new System.Drawing.Size(60, 13);
            this.lbl_NgayNghi.TabIndex = 0;
            this.lbl_NgayNghi.Text = "Ngày Nghĩ";
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
            this.tlslblIn,
            this.toolStripButton1,
            this.tlslblTroGiup,
            this.toolStripSeparator5,
            this.tlslblThoat});
            this.tlsMain.Location = new System.Drawing.Point(0, 0);
            this.tlsMain.Name = "tlsMain";
            this.tlsMain.Size = new System.Drawing.Size(582, 25);
            this.tlsMain.TabIndex = 40;
            this.tlsMain.Text = "toolStrip1";
            // 
            // tlslblThem
            // 
            this.tlslblThem.Image = ((System.Drawing.Image)(resources.GetObject("tlslblThem.Image")));
            this.tlslblThem.Name = "tlslblThem";
            this.tlslblThem.Size = new System.Drawing.Size(58, 22);
            this.tlslblThem.Text = "Thêm";
            this.tlslblThem.Click += new System.EventHandler(this.tlslblThem_Click);
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
            this.tlslblUndo.Size = new System.Drawing.Size(56, 22);
            this.tlslblUndo.Text = "Undo";
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
            this.tlslblIn.Text = "In";
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
            this.tlslblThoat.Size = new System.Drawing.Size(58, 22);
            this.tlslblThoat.Text = "Thoát";
            this.tlslblThoat.Click += new System.EventHandler(this.tlslblThoat_Click);
            // 
            // frmDanhSachNgayNghiTrongNam
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(582, 324);
            this.Controls.Add(this.tlsMain);
            this.Controls.Add(this.gbx_ThongNghiViec);
            this.Controls.Add(this.grdu_BacLuongCoBan);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "frmDanhSachNgayNghiTrongNam";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Danh Sách Ngày Nghĩ Trong Năm";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmDanhSachNgayNghiTrongNam_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.grdu_BacLuongCoBan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NgayHoliday_BindingSource)).EndInit();
            this.gbx_ThongNghiViec.ResumeLayout(false);
            this.gbx_ThongNghiViec.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtu_TenNgayNghi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtmp_NgayNghi)).EndInit();
            this.tlsMain.ResumeLayout(false);
            this.tlsMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Infragistics.Win.UltraWinGrid.UltraGrid grdu_BacLuongCoBan;
        private System.Windows.Forms.GroupBox gbx_ThongNghiViec;
        private Infragistics.Win.UltraWinEditors.UltraTextEditor txtu_TenNgayNghi;
        private System.Windows.Forms.Label lbl_TenNgayNghi;
        private Infragistics.Win.UltraWinEditors.UltraDateTimeEditor dtmp_NgayNghi;
        private System.Windows.Forms.Label lbl_NgayNghi;
        private System.Windows.Forms.BindingSource NgayHoliday_BindingSource;
        private System.Windows.Forms.ToolStrip tlsMain;
        private System.Windows.Forms.ToolStripButton tlslblThem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
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
    }
}