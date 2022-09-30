namespace PSC_ERP
{
    partial class frmDiaChi_NhanVien
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
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand1 = new Infragistics.Win.UltraWinGrid.UltraGridBand("QuanHuyen", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn1 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("MaTinhThanh");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn2 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("MaQuanHuyen");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn3 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("MaQuanLy");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn4 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("TenQuanHuyen");
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand2 = new Infragistics.Win.UltraWinGrid.UltraGridBand("TinhThanh", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn5 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("MaKhuVuc");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn6 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("MaQuocGia");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn7 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("DienGiai");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn8 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("MaTinhThanh");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn9 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("TenTinhThanh");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn10 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("MaTinhThanhQuanLy");
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand3 = new Infragistics.Win.UltraWinGrid.UltraGridBand("QuocGia", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn11 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("MaQuocGia");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn12 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("DienGiai");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn13 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("MaQuocGiaQuanLy");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn14 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("TenQuocGia");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn15 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("TenVietTat");
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDiaChi_NhanVien));
            this.cmbu_QuanHuyen = new Infragistics.Win.UltraWinGrid.UltraCombo();
            this.QuanHuyen_BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.cmbu_TinhThanh = new Infragistics.Win.UltraWinGrid.UltraCombo();
            this.TinhThanh_BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.cmbu_QuocGia = new Infragistics.Win.UltraWinGrid.UltraCombo();
            this.QuocGia_bindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.lbl_QuanHuyenXa = new System.Windows.Forms.Label();
            this.lbl_QueQuan = new System.Windows.Forms.Label();
            this.lbl_QuocTich = new System.Windows.Forms.Label();
            this.gbx_ThamGiaDoan = new System.Windows.Forms.GroupBox();
            this.btn_OK = new System.Windows.Forms.Button();
            this.txtu_SoNha = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.lbl_TenPhongBan = new System.Windows.Forms.Label();
            this.NhanVien_DiaChi_bindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.cmbu_QuanHuyen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.QuanHuyen_BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbu_TinhThanh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TinhThanh_BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbu_QuocGia)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.QuocGia_bindingSource)).BeginInit();
            this.gbx_ThamGiaDoan.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtu_SoNha)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NhanVien_DiaChi_bindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbu_QuanHuyen
            // 
            this.cmbu_QuanHuyen.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.cmbu_QuanHuyen.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.NhanVien_DiaChi_bindingSource, "QuanHuyen", true));
            this.cmbu_QuanHuyen.DataSource = this.QuanHuyen_BindingSource;
            ultraGridColumn1.Header.VisiblePosition = 1;
            ultraGridColumn2.Header.VisiblePosition = 0;
            ultraGridColumn3.Header.VisiblePosition = 2;
            ultraGridColumn4.Header.VisiblePosition = 3;
            ultraGridBand1.Columns.AddRange(new object[] {
            ultraGridColumn1,
            ultraGridColumn2,
            ultraGridColumn3,
            ultraGridColumn4});
            this.cmbu_QuanHuyen.DisplayLayout.BandsSerializer.Add(ultraGridBand1);
            this.cmbu_QuanHuyen.DisplayMember = "TenQuanHuyen";
            this.cmbu_QuanHuyen.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007;
            this.cmbu_QuanHuyen.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbu_QuanHuyen.Location = new System.Drawing.Point(170, 86);
            this.cmbu_QuanHuyen.Name = "cmbu_QuanHuyen";
            this.cmbu_QuanHuyen.Size = new System.Drawing.Size(233, 22);
            this.cmbu_QuanHuyen.TabIndex = 23;
            this.cmbu_QuanHuyen.ValueMember = "MaQuanHuyen";
            // 
            // QuanHuyen_BindingSource
            // 
            this.QuanHuyen_BindingSource.DataSource = typeof(ERP_Library.QuanHuyenList);
            // 
            // cmbu_TinhThanh
            // 
            this.cmbu_TinhThanh.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.cmbu_TinhThanh.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.NhanVien_DiaChi_bindingSource, "TinhTP", true));
            this.cmbu_TinhThanh.DataSource = this.TinhThanh_BindingSource;
            ultraGridColumn5.Header.VisiblePosition = 1;
            ultraGridColumn6.Header.VisiblePosition = 0;
            ultraGridColumn7.Header.VisiblePosition = 2;
            ultraGridColumn8.Header.VisiblePosition = 3;
            ultraGridColumn9.Header.VisiblePosition = 4;
            ultraGridColumn10.Header.VisiblePosition = 5;
            ultraGridBand2.Columns.AddRange(new object[] {
            ultraGridColumn5,
            ultraGridColumn6,
            ultraGridColumn7,
            ultraGridColumn8,
            ultraGridColumn9,
            ultraGridColumn10});
            this.cmbu_TinhThanh.DisplayLayout.BandsSerializer.Add(ultraGridBand2);
            this.cmbu_TinhThanh.DisplayMember = "TenTinhThanh";
            this.cmbu_TinhThanh.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007;
            this.cmbu_TinhThanh.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbu_TinhThanh.Location = new System.Drawing.Point(170, 57);
            this.cmbu_TinhThanh.Name = "cmbu_TinhThanh";
            this.cmbu_TinhThanh.Size = new System.Drawing.Size(233, 22);
            this.cmbu_TinhThanh.TabIndex = 22;
            this.cmbu_TinhThanh.ValueMember = "MaTinhThanh";
            this.cmbu_TinhThanh.ValueChanged += new System.EventHandler(this.cmbu_TinhThanh_ValueChanged);
            // 
            // TinhThanh_BindingSource
            // 
            this.TinhThanh_BindingSource.DataSource = typeof(ERP_Library.TinhThanhList);
            // 
            // cmbu_QuocGia
            // 
            this.cmbu_QuocGia.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.cmbu_QuocGia.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.NhanVien_DiaChi_bindingSource, "QuocGia", true));
            this.cmbu_QuocGia.DataSource = this.QuocGia_bindingSource;
            ultraGridColumn11.Header.VisiblePosition = 0;
            ultraGridColumn12.Header.VisiblePosition = 1;
            ultraGridColumn13.Header.VisiblePosition = 2;
            ultraGridColumn14.Header.VisiblePosition = 3;
            ultraGridColumn15.Header.VisiblePosition = 4;
            ultraGridBand3.Columns.AddRange(new object[] {
            ultraGridColumn11,
            ultraGridColumn12,
            ultraGridColumn13,
            ultraGridColumn14,
            ultraGridColumn15});
            this.cmbu_QuocGia.DisplayLayout.BandsSerializer.Add(ultraGridBand3);
            this.cmbu_QuocGia.DisplayMember = "TenQuocGia";
            this.cmbu_QuocGia.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007;
            this.cmbu_QuocGia.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbu_QuocGia.Location = new System.Drawing.Point(170, 28);
            this.cmbu_QuocGia.Name = "cmbu_QuocGia";
            this.cmbu_QuocGia.Size = new System.Drawing.Size(233, 22);
            this.cmbu_QuocGia.TabIndex = 21;
            this.cmbu_QuocGia.ValueMember = "MaQuocGia";
            this.cmbu_QuocGia.ValueChanged += new System.EventHandler(this.cmbu_QuocGia_ValueChanged);
            // 
            // QuocGia_bindingSource
            // 
            this.QuocGia_bindingSource.DataSource = typeof(ERP_Library.QuocGiaList);
            // 
            // lbl_QuanHuyenXa
            // 
            this.lbl_QuanHuyenXa.AutoSize = true;
            this.lbl_QuanHuyenXa.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_QuanHuyenXa.Location = new System.Drawing.Point(18, 91);
            this.lbl_QuanHuyenXa.Name = "lbl_QuanHuyenXa";
            this.lbl_QuanHuyenXa.Size = new System.Drawing.Size(69, 13);
            this.lbl_QuanHuyenXa.TabIndex = 18;
            this.lbl_QuanHuyenXa.Text = "Quận/Huyện";
            // 
            // lbl_QueQuan
            // 
            this.lbl_QueQuan.AutoSize = true;
            this.lbl_QueQuan.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_QueQuan.Location = new System.Drawing.Point(18, 62);
            this.lbl_QueQuan.Name = "lbl_QueQuan";
            this.lbl_QueQuan.Size = new System.Drawing.Size(62, 13);
            this.lbl_QueQuan.TabIndex = 19;
            this.lbl_QueQuan.Text = "Tỉnh Thành";
            // 
            // lbl_QuocTich
            // 
            this.lbl_QuocTich.AutoSize = true;
            this.lbl_QuocTich.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_QuocTich.Location = new System.Drawing.Point(18, 33);
            this.lbl_QuocTich.Name = "lbl_QuocTich";
            this.lbl_QuocTich.Size = new System.Drawing.Size(52, 13);
            this.lbl_QuocTich.TabIndex = 20;
            this.lbl_QuocTich.Text = "Quốc Gia";
            // 
            // gbx_ThamGiaDoan
            // 
            this.gbx_ThamGiaDoan.Controls.Add(this.btn_OK);
            this.gbx_ThamGiaDoan.Controls.Add(this.txtu_SoNha);
            this.gbx_ThamGiaDoan.Controls.Add(this.lbl_TenPhongBan);
            this.gbx_ThamGiaDoan.Controls.Add(this.cmbu_QuanHuyen);
            this.gbx_ThamGiaDoan.Controls.Add(this.lbl_QuocTich);
            this.gbx_ThamGiaDoan.Controls.Add(this.cmbu_TinhThanh);
            this.gbx_ThamGiaDoan.Controls.Add(this.lbl_QueQuan);
            this.gbx_ThamGiaDoan.Controls.Add(this.cmbu_QuocGia);
            this.gbx_ThamGiaDoan.Controls.Add(this.lbl_QuanHuyenXa);
            this.gbx_ThamGiaDoan.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbx_ThamGiaDoan.Location = new System.Drawing.Point(2, 3);
            this.gbx_ThamGiaDoan.Name = "gbx_ThamGiaDoan";
            this.gbx_ThamGiaDoan.Size = new System.Drawing.Size(427, 187);
            this.gbx_ThamGiaDoan.TabIndex = 24;
            this.gbx_ThamGiaDoan.TabStop = false;
            this.gbx_ThamGiaDoan.Text = "Tạo Địa Chỉ";
            // 
            // btn_OK
            // 
            this.btn_OK.Location = new System.Drawing.Point(170, 150);
            this.btn_OK.Name = "btn_OK";
            this.btn_OK.Size = new System.Drawing.Size(75, 27);
            this.btn_OK.TabIndex = 203;
            this.btn_OK.Text = "Hoàn Tất";
            this.btn_OK.UseVisualStyleBackColor = true;
            this.btn_OK.Click += new System.EventHandler(this.btn_OK_Click);
            // 
            // txtu_SoNha
            // 
            this.txtu_SoNha.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.NhanVien_DiaChi_bindingSource, "TenDiaChi", true));
            this.txtu_SoNha.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007;
            this.txtu_SoNha.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtu_SoNha.Location = new System.Drawing.Point(170, 115);
            this.txtu_SoNha.Name = "txtu_SoNha";
            this.txtu_SoNha.Size = new System.Drawing.Size(233, 21);
            this.txtu_SoNha.TabIndex = 202;
            // 
            // lbl_TenPhongBan
            // 
            this.lbl_TenPhongBan.AutoSize = true;
            this.lbl_TenPhongBan.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_TenPhongBan.Location = new System.Drawing.Point(18, 119);
            this.lbl_TenPhongBan.Name = "lbl_TenPhongBan";
            this.lbl_TenPhongBan.Size = new System.Drawing.Size(141, 13);
            this.lbl_TenPhongBan.TabIndex = 201;
            this.lbl_TenPhongBan.Text = "Số Nhà/Đường/Phường(Xã)";
            // 
            // NhanVien_DiaChi_bindingSource
            // 
            this.NhanVien_DiaChi_bindingSource.AllowNew = true;
            this.NhanVien_DiaChi_bindingSource.DataSource = typeof(ERP_Library.DiaChi_NhanVienList);
            // 
            // frmDiaChi_NhanVien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(432, 192);
            this.Controls.Add(this.gbx_ThamGiaDoan);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmDiaChi_NhanVien";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Địa Chỉ_Nhân Viên";
            ((System.ComponentModel.ISupportInitialize)(this.cmbu_QuanHuyen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.QuanHuyen_BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbu_TinhThanh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TinhThanh_BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbu_QuocGia)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.QuocGia_bindingSource)).EndInit();
            this.gbx_ThamGiaDoan.ResumeLayout(false);
            this.gbx_ThamGiaDoan.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtu_SoNha)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NhanVien_DiaChi_bindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Infragistics.Win.UltraWinGrid.UltraCombo cmbu_QuanHuyen;
        private Infragistics.Win.UltraWinGrid.UltraCombo cmbu_TinhThanh;
        private Infragistics.Win.UltraWinGrid.UltraCombo cmbu_QuocGia;
        private System.Windows.Forms.Label lbl_QuanHuyenXa;
        private System.Windows.Forms.Label lbl_QueQuan;
        private System.Windows.Forms.Label lbl_QuocTich;
        private System.Windows.Forms.GroupBox gbx_ThamGiaDoan;
        private Infragistics.Win.UltraWinEditors.UltraTextEditor txtu_SoNha;
        private System.Windows.Forms.Label lbl_TenPhongBan;
        private System.Windows.Forms.BindingSource QuocGia_bindingSource;
        private System.Windows.Forms.BindingSource TinhThanh_BindingSource;
        private System.Windows.Forms.BindingSource QuanHuyen_BindingSource;
        private System.Windows.Forms.Button btn_OK;
        private System.Windows.Forms.BindingSource NhanVien_DiaChi_bindingSource;

    }
}