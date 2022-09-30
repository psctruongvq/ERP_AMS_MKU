namespace PSC_ERP
{
    partial class frmInChiTietLuongNghiViec_Old
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
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn1 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Chon");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn2 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("MaBoPhan");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn3 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("MaBoPhanQL");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn4 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("TenBoPhan");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn5 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("NgayTao");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn6 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("MaBoPhanCha");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn7 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("MaLoaiBoPhan");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn8 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("MaCongTy");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn9 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("KhongTinhLuong");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn10 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("KhauHaoHaoMon");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn11 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("MaPhanCap");
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            this.cmbKyLuong = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.lblKyLuong = new System.Windows.Forms.Label();
            this.btnClose = new Infragistics.Win.Misc.UltraButton();
            this.btnIn = new Infragistics.Win.Misc.UltraButton();
            this.btnIn2Mat = new Infragistics.Win.Misc.UltraButton();
            this.chkChuKy = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTuNgay = new System.Windows.Forms.DateTimePicker();
            this.txtDenNgay = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dtNgayBDTinhLuong = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.dtNgayKTTinhLuong = new System.Windows.Forms.DateTimePicker();
            this.BindS_BoPhan = new System.Windows.Forms.BindingSource(this.components);
            this.bindingSource2_nhanVien = new System.Windows.Forms.BindingSource(this.components);
            this.label9 = new System.Windows.Forms.Label();
            this.lbl_ChiNhanh = new System.Windows.Forms.Label();
            this.cmbu_Bophan = new Infragistics.Win.UltraWinGrid.UltraCombo();
            this.ultraCombo_NhanVien = new Infragistics.Win.UltraWinGrid.UltraCombo();
            ((System.ComponentModel.ISupportInitialize)(this.cmbKyLuong)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkChuKy)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BindS_BoPhan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource2_nhanVien)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbu_Bophan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraCombo_NhanVien)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbKyLuong
            // 
            this.cmbKyLuong.DisplayMember = "TenKy";
            this.cmbKyLuong.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007;
            this.cmbKyLuong.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.cmbKyLuong.Location = new System.Drawing.Point(86, 12);
            this.cmbKyLuong.Name = "cmbKyLuong";
            this.cmbKyLuong.Size = new System.Drawing.Size(228, 21);
            this.cmbKyLuong.TabIndex = 0;
            this.cmbKyLuong.ValueMember = "MaKy";
            this.cmbKyLuong.ValueChanged += new System.EventHandler(this.cmbKyLuong_ValueChanged);
            // 
            // lblKyLuong
            // 
            this.lblKyLuong.AutoSize = true;
            this.lblKyLuong.Location = new System.Drawing.Point(11, 20);
            this.lblKyLuong.Name = "lblKyLuong";
            this.lblKyLuong.Size = new System.Drawing.Size(67, 13);
            this.lblKyLuong.TabIndex = 0;
            this.lblKyLuong.Text = "Tháng lương";
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(85, 208);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(64, 32);
            this.btnClose.TabIndex = 5;
            this.btnClose.Text = "Đóng";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnIn
            // 
            this.btnIn.Location = new System.Drawing.Point(15, 208);
            this.btnIn.Name = "btnIn";
            this.btnIn.Size = new System.Drawing.Size(64, 32);
            this.btnIn.TabIndex = 4;
            this.btnIn.Text = "In";
            this.btnIn.Click += new System.EventHandler(this.btnIn_Click);
            // 
            // btnIn2Mat
            // 
            this.btnIn2Mat.Location = new System.Drawing.Point(155, 208);
            this.btnIn2Mat.Name = "btnIn2Mat";
            this.btnIn2Mat.Size = new System.Drawing.Size(64, 32);
            this.btnIn2Mat.TabIndex = 6;
            this.btnIn2Mat.Text = "In 2 mặt";
            this.btnIn2Mat.Visible = false;
            this.btnIn2Mat.Click += new System.EventHandler(this.btnIn2Mat_Click);
            // 
            // chkChuKy
            // 
            this.chkChuKy.Checked = true;
            this.chkChuKy.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkChuKy.Location = new System.Drawing.Point(15, 149);
            this.chkChuKy.Name = "chkChuKy";
            this.chkChuKy.Size = new System.Drawing.Size(215, 21);
            this.chkChuKy.TabIndex = 10;
            this.chkChuKy.Text = "In chữ ký phụ trách ban, thủ trưởng";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Từ ngày";
            // 
            // txtTuNgay
            // 
            this.txtTuNgay.CustomFormat = "dd/MM/yy";
            this.txtTuNgay.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.txtTuNgay.Location = new System.Drawing.Point(86, 39);
            this.txtTuNgay.Name = "txtTuNgay";
            this.txtTuNgay.Size = new System.Drawing.Size(84, 20);
            this.txtTuNgay.TabIndex = 3;
            // 
            // txtDenNgay
            // 
            this.txtDenNgay.CustomFormat = "dd/MM/yy";
            this.txtDenNgay.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.txtDenNgay.Location = new System.Drawing.Point(230, 39);
            this.txtDenNgay.Name = "txtDenNgay";
            this.txtDenNgay.Size = new System.Drawing.Size(84, 20);
            this.txtDenNgay.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(178, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "đến ngày";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 76);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Ngày BĐ tính";
            // 
            // dtNgayBDTinhLuong
            // 
            this.dtNgayBDTinhLuong.CustomFormat = "dd/MM/yy";
            this.dtNgayBDTinhLuong.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtNgayBDTinhLuong.Location = new System.Drawing.Point(86, 69);
            this.dtNgayBDTinhLuong.Name = "dtNgayBDTinhLuong";
            this.dtNgayBDTinhLuong.Size = new System.Drawing.Size(84, 20);
            this.dtNgayBDTinhLuong.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(178, 76);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "đến ngày";
            // 
            // dtNgayKTTinhLuong
            // 
            this.dtNgayKTTinhLuong.CustomFormat = "dd/MM/yy";
            this.dtNgayKTTinhLuong.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtNgayKTTinhLuong.Location = new System.Drawing.Point(230, 69);
            this.dtNgayKTTinhLuong.Name = "dtNgayKTTinhLuong";
            this.dtNgayKTTinhLuong.Size = new System.Drawing.Size(84, 20);
            this.dtNgayKTTinhLuong.TabIndex = 5;
            // 
            // BindS_BoPhan
            // 
            this.BindS_BoPhan.DataSource = typeof(ERP_Library.BoPhanList);
            // 
            // bindingSource2_nhanVien
            // 
            this.bindingSource2_nhanVien.DataSource = typeof(ERP_Library.TTNhanVienRutGonList);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(13, 125);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(57, 13);
            this.label9.TabIndex = 78;
            this.label9.Text = "Nhân Viên";
            // 
            // lbl_ChiNhanh
            // 
            this.lbl_ChiNhanh.AutoSize = true;
            this.lbl_ChiNhanh.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_ChiNhanh.Location = new System.Drawing.Point(22, 99);
            this.lbl_ChiNhanh.Name = "lbl_ChiNhanh";
            this.lbl_ChiNhanh.Size = new System.Drawing.Size(47, 13);
            this.lbl_ChiNhanh.TabIndex = 77;
            this.lbl_ChiNhanh.Text = "Bộ phận";
            // 
            // cmbu_Bophan
            // 
            appearance1.FontData.BoldAsString = "False";
            this.cmbu_Bophan.Appearance = appearance1;
            this.cmbu_Bophan.CheckedListSettings.CheckStateMember = "";
            this.cmbu_Bophan.DataSource = this.BindS_BoPhan;
            ultraGridColumn1.Header.VisiblePosition = 0;
            ultraGridColumn2.Header.VisiblePosition = 1;
            ultraGridColumn2.Hidden = true;
            ultraGridColumn3.Header.Caption = "Mã QL";
            ultraGridColumn3.Header.VisiblePosition = 2;
            ultraGridColumn4.Header.Caption = "Tên Bộ Phận";
            ultraGridColumn4.Header.VisiblePosition = 3;
            ultraGridColumn4.Width = 250;
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
            this.cmbu_Bophan.DisplayLayout.BandsSerializer.Add(ultraGridBand1);
            this.cmbu_Bophan.DisplayMember = "TenBoPhan";
            this.cmbu_Bophan.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007;
            this.cmbu_Bophan.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbu_Bophan.Location = new System.Drawing.Point(85, 96);
            this.cmbu_Bophan.Name = "cmbu_Bophan";
            this.cmbu_Bophan.Size = new System.Drawing.Size(229, 22);
            this.cmbu_Bophan.TabIndex = 2;
            this.cmbu_Bophan.ValueMember = "MaBoPhan";
            this.cmbu_Bophan.ValueChanged += new System.EventHandler(this.cmbu_Bophan_ValueChanged);
            this.cmbu_Bophan.InitializeLayout += new Infragistics.Win.UltraWinGrid.InitializeLayoutEventHandler(this.cmbu_Bophan_InitializeLayout);
            // 
            // ultraCombo_NhanVien
            // 
            appearance6.FontData.BoldAsString = "False";
            this.ultraCombo_NhanVien.Appearance = appearance6;
            this.ultraCombo_NhanVien.CheckedListSettings.CheckStateMember = "";
            this.ultraCombo_NhanVien.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007;
            this.ultraCombo_NhanVien.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ultraCombo_NhanVien.Location = new System.Drawing.Point(86, 125);
            this.ultraCombo_NhanVien.Name = "ultraCombo_NhanVien";
            this.ultraCombo_NhanVien.Size = new System.Drawing.Size(229, 22);
            this.ultraCombo_NhanVien.TabIndex = 79;
            this.ultraCombo_NhanVien.InitializeLayout += new Infragistics.Win.UltraWinGrid.InitializeLayoutEventHandler(this.ultraCombo_NhanVien_InitializeLayout);
            // 
            // frmInChiTietLuongNghiViec
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(345, 278);
            this.ControlBox = false;
            this.Controls.Add(this.ultraCombo_NhanVien);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.lbl_ChiNhanh);
            this.Controls.Add(this.cmbu_Bophan);
            this.Controls.Add(this.dtNgayKTTinhLuong);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtDenNgay);
            this.Controls.Add(this.dtNgayBDTinhLuong);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtTuNgay);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.chkChuKy);
            this.Controls.Add(this.btnIn2Mat);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnIn);
            this.Controls.Add(this.cmbKyLuong);
            this.Controls.Add(this.lblKyLuong);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmInChiTietLuongNghiViec";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "In chi tiết lương nhân viên";
            ((System.ComponentModel.ISupportInitialize)(this.cmbKyLuong)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkChuKy)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BindS_BoPhan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource2_nhanVien)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbu_Bophan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraCombo_NhanVien)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Infragistics.Win.UltraWinEditors.UltraComboEditor cmbKyLuong;
        private System.Windows.Forms.Label lblKyLuong;
        private Infragistics.Win.Misc.UltraButton btnClose;
        private Infragistics.Win.Misc.UltraButton btnIn;
        private Infragistics.Win.Misc.UltraButton btnIn2Mat;
        private Infragistics.Win.UltraWinEditors.UltraCheckEditor chkChuKy;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker txtTuNgay;
        private System.Windows.Forms.DateTimePicker txtDenNgay;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtNgayBDTinhLuong;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dtNgayKTTinhLuong;
        private System.Windows.Forms.BindingSource BindS_BoPhan;
        private System.Windows.Forms.BindingSource bindingSource2_nhanVien;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lbl_ChiNhanh;
        private Infragistics.Win.UltraWinGrid.UltraCombo cmbu_Bophan;
        private Infragistics.Win.UltraWinGrid.UltraCombo ultraCombo_NhanVien;
    }
}