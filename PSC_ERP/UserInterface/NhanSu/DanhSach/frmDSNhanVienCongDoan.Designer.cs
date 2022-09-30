namespace PSC_ERP
{
    partial class frmDSNhanVienCongDoan
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
            Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand1 = new Infragistics.Win.UltraWinGrid.UltraGridBand("NhanVienCongDoan", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn1 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("MaBoPhanQL");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn2 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("TenBoPhan");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn3 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("MaQLNhanVien");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn4 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("TenNhanVien");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn5 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("TenChucVu");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn6 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("NgayVaoDai");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn7 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("NgayVaoCongDoan");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn8 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("HeSoPhuCapChucVu");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn9 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("HeSoLuongNoiBo");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn10 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("HeSoLuongBoSung");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn11 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("HeSoVuotKhung");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn12 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("HeSoBu");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn13 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("HeSoDocHai");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn14 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("HeSoLuong");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn15 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("HeSoVuotKhungBH");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn16 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("HeSoLuongBaoHiem");
            Infragistics.Win.Appearance appearance13 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance14 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance15 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance16 = new Infragistics.Win.Appearance();
            this.dateTuNgay = new System.Windows.Forms.DateTimePicker();
            this.dateDenNgay = new System.Windows.Forms.DateTimePicker();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rdTatCa = new System.Windows.Forms.RadioButton();
            this.rdDaChuyen = new System.Windows.Forms.RadioButton();
            this.rdChua = new System.Windows.Forms.RadioButton();
            this.button1 = new System.Windows.Forms.Button();
            this.gridData = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.bindingSource1_DSnhanVienCongDoan = new System.Windows.Forms.BindingSource(this.components);
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1_DSnhanVienCongDoan)).BeginInit();
            this.SuspendLayout();
            // 
            // dateTuNgay
            // 
            this.dateTuNgay.CustomFormat = "dd/MM/yyyy";
            this.dateTuNgay.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTuNgay.Location = new System.Drawing.Point(122, 19);
            this.dateTuNgay.Name = "dateTuNgay";
            this.dateTuNgay.Size = new System.Drawing.Size(111, 20);
            this.dateTuNgay.TabIndex = 0;
            this.dateTuNgay.ValueChanged += new System.EventHandler(this.dateTuNgay_ValueChanged);
            // 
            // dateDenNgay
            // 
            this.dateDenNgay.CustomFormat = "dd/MM/yyyy";
            this.dateDenNgay.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateDenNgay.Location = new System.Drawing.Point(282, 19);
            this.dateDenNgay.Name = "dateDenNgay";
            this.dateDenNgay.Size = new System.Drawing.Size(111, 20);
            this.dateDenNgay.TabIndex = 1;
            this.dateDenNgay.ValueChanged += new System.EventHandler(this.dateDenNgay_ValueChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.rdTatCa);
            this.groupBox1.Controls.Add(this.rdDaChuyen);
            this.groupBox1.Controls.Add(this.rdChua);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.dateTuNgay);
            this.groupBox1.Controls.Add(this.dateDenNgay);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(877, 50);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            // 
            // rdTatCa
            // 
            this.rdTatCa.AutoSize = true;
            this.rdTatCa.Location = new System.Drawing.Point(578, 22);
            this.rdTatCa.Name = "rdTatCa";
            this.rdTatCa.Size = new System.Drawing.Size(57, 17);
            this.rdTatCa.TabIndex = 84;
            this.rdTatCa.Text = "Tất Cả";
            this.rdTatCa.UseVisualStyleBackColor = true;
            this.rdTatCa.CheckedChanged += new System.EventHandler(this.rdTatCa_CheckedChanged);
            // 
            // rdDaChuyen
            // 
            this.rdDaChuyen.AutoSize = true;
            this.rdDaChuyen.Location = new System.Drawing.Point(494, 22);
            this.rdDaChuyen.Name = "rdDaChuyen";
            this.rdDaChuyen.Size = new System.Drawing.Size(78, 17);
            this.rdDaChuyen.TabIndex = 83;
            this.rdDaChuyen.Text = "Đã vào CĐ";
            this.rdDaChuyen.UseVisualStyleBackColor = true;
            this.rdDaChuyen.CheckedChanged += new System.EventHandler(this.rdDaChuyen_CheckedChanged);
            // 
            // rdChua
            // 
            this.rdChua.AutoSize = true;
            this.rdChua.Checked = true;
            this.rdChua.Location = new System.Drawing.Point(399, 22);
            this.rdChua.Name = "rdChua";
            this.rdChua.Size = new System.Drawing.Size(89, 17);
            this.rdChua.TabIndex = 82;
            this.rdChua.TabStop = true;
            this.rdChua.Text = "Chưa vào CĐ";
            this.rdChua.UseVisualStyleBackColor = true;
            this.rdChua.CheckedChanged += new System.EventHandler(this.rdChua_CheckedChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(641, 20);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Export";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // gridData
            // 
            this.gridData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gridData.DataSource = this.bindingSource1_DSnhanVienCongDoan;
            appearance12.BackColor = System.Drawing.Color.White;
            this.gridData.DisplayLayout.Appearance = appearance12;
            ultraGridColumn1.Header.VisiblePosition = 1;
            ultraGridColumn1.Hidden = true;
            ultraGridColumn2.Header.Caption = "Tên Bộ Phận";
            ultraGridColumn2.Header.VisiblePosition = 0;
            ultraGridColumn3.Header.VisiblePosition = 2;
            ultraGridColumn3.Hidden = true;
            ultraGridColumn4.Header.Caption = "Tên Nhân Viên";
            ultraGridColumn4.Header.VisiblePosition = 3;
            ultraGridColumn5.Header.Caption = "Chức Vụ";
            ultraGridColumn5.Header.VisiblePosition = 4;
            ultraGridColumn6.Format = "dd/MM/yyyy";
            ultraGridColumn6.Header.Caption = "Ngày Vào Đài";
            ultraGridColumn6.Header.VisiblePosition = 5;
            ultraGridColumn6.MaskInput = "{LOC}dd/mm/yyyy";
            ultraGridColumn6.Width = 80;
            ultraGridColumn7.Format = "dd/MM/yyyy";
            ultraGridColumn7.Header.Caption = "Ngày Vào CĐ";
            ultraGridColumn7.Header.VisiblePosition = 6;
            ultraGridColumn7.MaskInput = "{LOC}dd/mm/yyyy";
            ultraGridColumn8.Header.Caption = "PCCV";
            ultraGridColumn8.Header.VisiblePosition = 9;
            ultraGridColumn9.Header.Caption = "HSNB";
            ultraGridColumn9.Header.VisiblePosition = 10;
            ultraGridColumn10.Header.Caption = "HSBS";
            ultraGridColumn10.Header.VisiblePosition = 11;
            ultraGridColumn11.Header.Caption = "HSVK";
            ultraGridColumn11.Header.VisiblePosition = 12;
            ultraGridColumn12.Header.Caption = "HS Bù";
            ultraGridColumn12.Header.VisiblePosition = 13;
            ultraGridColumn13.Header.Caption = "HSĐH";
            ultraGridColumn13.Header.VisiblePosition = 14;
            ultraGridColumn14.Header.Caption = "HS Lương";
            ultraGridColumn14.Header.VisiblePosition = 7;
            ultraGridColumn15.Header.Caption = "HSVKBH";
            ultraGridColumn15.Header.VisiblePosition = 15;
            ultraGridColumn16.Header.Caption = "HS BH";
            ultraGridColumn16.Header.VisiblePosition = 8;
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
            ultraGridColumn16});
            this.gridData.DisplayLayout.BandsSerializer.Add(ultraGridBand1);
            this.gridData.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            this.gridData.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.Yes;
            appearance13.BackColor = System.Drawing.Color.Transparent;
            this.gridData.DisplayLayout.Override.CardAreaAppearance = appearance13;
            appearance14.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(192)))), ((int)(((byte)(130)))));
            appearance14.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(122)))), ((int)(((byte)(68)))));
            appearance14.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance14.FontData.BoldAsString = "True";
            appearance14.FontData.Name = "Arial";
            appearance14.FontData.SizeInPoints = 10F;
            appearance14.ForeColor = System.Drawing.Color.White;
            appearance14.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent;
            this.gridData.DisplayLayout.Override.HeaderAppearance = appearance14;
            this.gridData.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand;
            appearance15.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(192)))), ((int)(((byte)(130)))));
            appearance15.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(122)))), ((int)(((byte)(68)))));
            appearance15.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            this.gridData.DisplayLayout.Override.RowSelectorAppearance = appearance15;
            appearance16.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(230)))), ((int)(((byte)(148)))));
            appearance16.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(149)))), ((int)(((byte)(21)))));
            appearance16.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            this.gridData.DisplayLayout.Override.SelectedRowAppearance = appearance16;
            this.gridData.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridData.Location = new System.Drawing.Point(1, 68);
            this.gridData.Name = "gridData";
            this.gridData.Size = new System.Drawing.Size(888, 347);
            this.gridData.TabIndex = 28;
            this.gridData.InitializeLayout += new Infragistics.Win.UltraWinGrid.InitializeLayoutEventHandler(this.gridData_InitializeLayout);
            // 
            // bindingSource1_DSnhanVienCongDoan
            // 
            this.bindingSource1_DSnhanVienCongDoan.DataSource = typeof(ERP_Library.NhanVienCongDoanList);
            // 
            // frmDSNhanVienCongDoan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(901, 413);
            this.Controls.Add(this.gridData);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmDSNhanVienCongDoan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Danh Sách Nhân Viên Công Đoàn";
            this.Load += new System.EventHandler(this.frmDanhSachNhanVienNghiViec_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1_DSnhanVienCongDoan)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dateTuNgay;
        private System.Windows.Forms.DateTimePicker dateDenNgay;
        private System.Windows.Forms.GroupBox groupBox1;
        private Infragistics.Win.UltraWinGrid.UltraGrid gridData;
        private System.Windows.Forms.BindingSource bindingSource1_DSnhanVienCongDoan;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.RadioButton rdTatCa;
        private System.Windows.Forms.RadioButton rdDaChuyen;
        private System.Windows.Forms.RadioButton rdChua;
    }
}