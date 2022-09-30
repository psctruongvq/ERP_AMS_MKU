namespace PSC_ERP   
{
    partial class frmHoaDonTuDonHang
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
            Infragistics.Win.Appearance appearance59 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance61 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance62 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance64 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance63 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand1 = new Infragistics.Win.UltraWinGrid.UltraGridBand("NguoiLienLacList", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn1 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("MaNguoiLienLac");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn2 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Email");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn3 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("DienThoai");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn4 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("MaDoiTac");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn5 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("TenNguoiLienLac");
            Infragistics.Win.Appearance appearance51 = new Infragistics.Win.Appearance();
            Infragistics.Win.ValueListItem valueListItem1 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem2 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem3 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem4 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem5 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem6 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem7 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem8 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem9 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem10 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem11 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem12 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.Appearance appearance65 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance66 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance67 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance116 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand2 = new Infragistics.Win.UltraWinGrid.UltraGridBand("CT_HoaDonList", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn6 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("MaDonViTinh");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn7 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("SoLuong");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn8 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("MaHoaDon");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn9 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("MactHoadon");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn10 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("TenDonViTinh");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn11 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("DonGia");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn12 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ThanhTien");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn13 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("DienGiai");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn14 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("MaHangHoa");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn15 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("KhoiLuongVang");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn16 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("TenHangHoa");
            Infragistics.Win.Appearance appearance117 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmHoaDonTuDonHang));
            this.ultraGroupBox3 = new Infragistics.Win.Misc.UltraGroupBox();
            this.cmb_HinhThucTT = new System.Windows.Forms.ComboBox();
            this.txt_SoSerial = new System.Windows.Forms.TextBox();
            this.ultradteNgayLap = new Infragistics.Win.UltraWinEditors.UltraDateTimeEditor();
            this.txt_SoDonHang = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txt_SoHoaDon = new System.Windows.Forms.TextBox();
            this.dtu_NgayHetHanTT = new Infragistics.Win.UltraWinEditors.UltraDateTimeEditor();
            this.label28 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.ultraGroupBox2 = new Infragistics.Win.Misc.UltraGroupBox();
            this.label21 = new System.Windows.Forms.Label();
            this.cmb_DienThoai = new System.Windows.Forms.ComboBox();
            this.txt_DoiTac = new System.Windows.Forms.TextBox();
            this.txtu_MaSoThue = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.label4 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.cmbu_NguoiLienLac = new Infragistics.Win.UltraWinGrid.UltraCombo();
            this.label15 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.cmb_DiaChi = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cb_LoaiHD = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.numu_SoTienUuDai = new Infragistics.Win.UltraWinEditors.UltraNumericEditor();
            this.cbeu_HinhThucUuDai = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbe_PhanTramUuDai = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.label20 = new System.Windows.Forms.Label();
            this.cmbe_ThueVAT = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.cmbeu_TinhTrang = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.label5 = new System.Windows.Forms.Label();
            this.numeu_SoTienDaThanhToan = new Infragistics.Win.UltraWinEditors.UltraNumericEditor();
            this.label22 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.numeu_TongTien = new Infragistics.Win.UltraWinEditors.UltraNumericEditor();
            this.txt_VietBangChua = new System.Windows.Forms.TextBox();
            this.label26 = new System.Windows.Forms.Label();
            this.numeu_ThanhTien = new Infragistics.Win.UltraWinEditors.UltraNumericEditor();
            this.label6 = new System.Windows.Forms.Label();
            this.grdu_ChiTietHoaDon = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.tlsThem = new System.Windows.Forms.ToolStripMenuItem();
            this.luuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tlslblUndo = new System.Windows.Forms.ToolStripMenuItem();
            this.btlIn = new System.Windows.Forms.ToolStripMenuItem();
            this.tlslblTroGiup = new System.Windows.Forms.ToolStripMenuItem();
            this.inToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.HoaDonbindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.cTHoaDonListBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.doiTacDienThoaiFaxListBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.DoiTacbindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.nguoiLienLacListBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.diaChiDoiTacListBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.phuongThucThanhToanListBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.donHangBanBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.donHangMuaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.donNhanHangTraBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.donTraHangMuaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox3)).BeginInit();
            this.ultraGroupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ultradteNgayLap)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtu_NgayHetHanTT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox2)).BeginInit();
            this.ultraGroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtu_MaSoThue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbu_NguoiLienLac)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numu_SoTienUuDai)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbeu_HinhThucUuDai)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbe_PhanTramUuDai)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbe_ThueVAT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbeu_TinhTrang)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numeu_SoTienDaThanhToan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numeu_TongTien)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numeu_ThanhTien)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdu_ChiTietHoaDon)).BeginInit();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.HoaDonbindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cTHoaDonListBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.doiTacDienThoaiFaxListBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DoiTacbindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nguoiLienLacListBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.diaChiDoiTacListBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.phuongThucThanhToanListBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.donHangBanBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.donHangMuaBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.donNhanHangTraBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.donTraHangMuaBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // ultraGroupBox3
            // 
            appearance59.BackColor = System.Drawing.Color.Transparent;
            this.ultraGroupBox3.Appearance = appearance59;
            this.ultraGroupBox3.Controls.Add(this.cmb_HinhThucTT);
            this.ultraGroupBox3.Controls.Add(this.txt_SoSerial);
            this.ultraGroupBox3.Controls.Add(this.ultradteNgayLap);
            this.ultraGroupBox3.Controls.Add(this.txt_SoDonHang);
            this.ultraGroupBox3.Controls.Add(this.label8);
            this.ultraGroupBox3.Controls.Add(this.txt_SoHoaDon);
            this.ultraGroupBox3.Controls.Add(this.dtu_NgayHetHanTT);
            this.ultraGroupBox3.Controls.Add(this.label28);
            this.ultraGroupBox3.Controls.Add(this.label10);
            this.ultraGroupBox3.Controls.Add(this.label12);
            this.ultraGroupBox3.Controls.Add(this.label11);
            this.ultraGroupBox3.Controls.Add(this.label7);
            this.ultraGroupBox3.Controls.Add(this.label13);
            this.ultraGroupBox3.Controls.Add(this.label14);
            this.ultraGroupBox3.Controls.Add(this.label1);
            appearance61.FontData.BoldAsString = "True";
            this.ultraGroupBox3.HeaderAppearance = appearance61;
            this.ultraGroupBox3.Location = new System.Drawing.Point(6, 27);
            this.ultraGroupBox3.Name = "ultraGroupBox3";
            this.ultraGroupBox3.Size = new System.Drawing.Size(339, 189);
            this.ultraGroupBox3.TabIndex = 0;
            this.ultraGroupBox3.Text = "Thông Tin  Hóa Đơn";
            // 
            // cmb_HinhThucTT
            // 
            this.cmb_HinhThucTT.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.HoaDonbindingSource, "MaHinhThucTT", true));
            this.cmb_HinhThucTT.DataSource = this.phuongThucThanhToanListBindingSource;
            this.cmb_HinhThucTT.DisplayMember = "TenPhuongThucThanhToan";
            this.cmb_HinhThucTT.FormattingEnabled = true;
            this.cmb_HinhThucTT.Location = new System.Drawing.Point(144, 103);
            this.cmb_HinhThucTT.Name = "cmb_HinhThucTT";
            this.cmb_HinhThucTT.Size = new System.Drawing.Size(179, 21);
            this.cmb_HinhThucTT.TabIndex = 3;
            this.cmb_HinhThucTT.ValueMember = "MaPhuongThucThanhToan";
            // 
            // txt_SoSerial
            // 
            this.txt_SoSerial.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.HoaDonbindingSource, "SoSerial", true));
            this.txt_SoSerial.Location = new System.Drawing.Point(144, 75);
            this.txt_SoSerial.Name = "txt_SoSerial";
            this.txt_SoSerial.Size = new System.Drawing.Size(179, 20);
            this.txt_SoSerial.TabIndex = 2;
            // 
            // ultradteNgayLap
            // 
            this.ultradteNgayLap.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ultradteNgayLap.DateTime = new System.DateTime(2007, 11, 12, 0, 0, 0, 0);
            this.ultradteNgayLap.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007;
            this.ultradteNgayLap.FormatString = "dd/MM/yyyy";
            this.ultradteNgayLap.Location = new System.Drawing.Point(144, 158);
            this.ultradteNgayLap.MaskInput = "{LOC}dd/mm/yyyy";
            this.ultradteNgayLap.Name = "ultradteNgayLap";
            this.ultradteNgayLap.Size = new System.Drawing.Size(179, 21);
            this.ultradteNgayLap.TabIndex = 5;
            this.ultradteNgayLap.Value = new System.DateTime(2007, 11, 12, 0, 0, 0, 0);
            // 
            // txt_SoDonHang
            // 
            this.txt_SoDonHang.Location = new System.Drawing.Point(144, 22);
            this.txt_SoDonHang.Name = "txt_SoDonHang";
            this.txt_SoDonHang.Size = new System.Drawing.Size(179, 20);
            this.txt_SoDonHang.TabIndex = 0;
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(22, 162);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 13);
            this.label8.TabIndex = 38;
            this.label8.Text = "Ngày Lập";
            // 
            // txt_SoHoaDon
            // 
            this.txt_SoHoaDon.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.HoaDonbindingSource, "SoHoaDon", true));
            this.txt_SoHoaDon.Location = new System.Drawing.Point(144, 49);
            this.txt_SoHoaDon.Name = "txt_SoHoaDon";
            this.txt_SoHoaDon.Size = new System.Drawing.Size(179, 20);
            this.txt_SoHoaDon.TabIndex = 1;
            // 
            // dtu_NgayHetHanTT
            // 
            this.dtu_NgayHetHanTT.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dtu_NgayHetHanTT.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.HoaDonbindingSource, "NgayHetHanTT", true));
            this.dtu_NgayHetHanTT.DateTime = new System.DateTime(2007, 11, 12, 0, 0, 0, 0);
            this.dtu_NgayHetHanTT.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007;
            this.dtu_NgayHetHanTT.FormatString = "dd/MM/yyyy";
            this.dtu_NgayHetHanTT.Location = new System.Drawing.Point(144, 131);
            this.dtu_NgayHetHanTT.MaskInput = "{LOC}dd/mm/yyyy";
            this.dtu_NgayHetHanTT.Name = "dtu_NgayHetHanTT";
            this.dtu_NgayHetHanTT.Size = new System.Drawing.Size(179, 21);
            this.dtu_NgayHetHanTT.TabIndex = 4;
            this.dtu_NgayHetHanTT.Value = new System.DateTime(2007, 11, 12, 0, 0, 0, 0);
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(22, 135);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(92, 13);
            this.label28.TabIndex = 0;
            this.label28.Text = "Ngày Hết Hạn TT";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(22, 108);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(74, 13);
            this.label10.TabIndex = 13;
            this.label10.Text = "Hình Thức TT";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.Red;
            this.label12.Location = new System.Drawing.Point(10, 78);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(13, 17);
            this.label12.TabIndex = 28;
            this.label12.Text = "*";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.Red;
            this.label11.Location = new System.Drawing.Point(10, 51);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(13, 17);
            this.label11.TabIndex = 28;
            this.label11.Text = "*";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Red;
            this.label7.Location = new System.Drawing.Point(10, 24);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(13, 17);
            this.label7.TabIndex = 28;
            this.label7.Text = "*";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(22, 80);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(49, 13);
            this.label13.TabIndex = 14;
            this.label13.Text = "Số Serial";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(22, 53);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(66, 13);
            this.label14.TabIndex = 15;
            this.label14.Text = "Số Hóa Đơn";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Chọn Đơn Hàng";
            // 
            // ultraGroupBox2
            // 
            this.ultraGroupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            appearance62.BackColor = System.Drawing.Color.Transparent;
            this.ultraGroupBox2.Appearance = appearance62;
            this.ultraGroupBox2.Controls.Add(this.label21);
            this.ultraGroupBox2.Controls.Add(this.cmb_DienThoai);
            this.ultraGroupBox2.Controls.Add(this.txt_DoiTac);
            this.ultraGroupBox2.Controls.Add(this.txtu_MaSoThue);
            this.ultraGroupBox2.Controls.Add(this.label4);
            this.ultraGroupBox2.Controls.Add(this.label16);
            this.ultraGroupBox2.Controls.Add(this.cmbu_NguoiLienLac);
            this.ultraGroupBox2.Controls.Add(this.label15);
            this.ultraGroupBox2.Controls.Add(this.label17);
            this.ultraGroupBox2.Controls.Add(this.label18);
            this.ultraGroupBox2.Controls.Add(this.label19);
            this.ultraGroupBox2.Controls.Add(this.cmb_DiaChi);
            appearance64.FontData.BoldAsString = "True";
            this.ultraGroupBox2.HeaderAppearance = appearance64;
            this.ultraGroupBox2.Location = new System.Drawing.Point(351, 26);
            this.ultraGroupBox2.Name = "ultraGroupBox2";
            this.ultraGroupBox2.Size = new System.Drawing.Size(338, 190);
            this.ultraGroupBox2.TabIndex = 1;
            this.ultraGroupBox2.Text = "Khách Hàng";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.ForeColor = System.Drawing.Color.Red;
            this.label21.Location = new System.Drawing.Point(17, 51);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(13, 17);
            this.label21.TabIndex = 28;
            this.label21.Text = "*";
            // 
            // cmb_DienThoai
            // 
            this.cmb_DienThoai.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cmb_DienThoai.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.HoaDonbindingSource, "MaDienThoai", true));
            this.cmb_DienThoai.DataSource = this.doiTacDienThoaiFaxListBindingSource;
            this.cmb_DienThoai.DisplayMember = "SoDTFax";
            this.cmb_DienThoai.FormattingEnabled = true;
            this.cmb_DienThoai.Location = new System.Drawing.Point(121, 130);
            this.cmb_DienThoai.Name = "cmb_DienThoai";
            this.cmb_DienThoai.Size = new System.Drawing.Size(206, 21);
            this.cmb_DienThoai.TabIndex = 4;
            this.cmb_DienThoai.ValueMember = "MaDienThoaiFax";
            // 
            // txt_DoiTac
            // 
            this.txt_DoiTac.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_DoiTac.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.DoiTacbindingSource, "TenDoiTac", true));
            this.txt_DoiTac.Location = new System.Drawing.Point(121, 23);
            this.txt_DoiTac.Name = "txt_DoiTac";
            this.txt_DoiTac.ReadOnly = true;
            this.txt_DoiTac.Size = new System.Drawing.Size(206, 20);
            this.txt_DoiTac.TabIndex = 0;
            // 
            // txtu_MaSoThue
            // 
            this.txtu_MaSoThue.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            appearance63.BackColor = System.Drawing.SystemColors.Info;
            this.txtu_MaSoThue.Appearance = appearance63;
            this.txtu_MaSoThue.BackColor = System.Drawing.SystemColors.Info;
            this.txtu_MaSoThue.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.DoiTacbindingSource, "MaSoThue", true));
            this.txtu_MaSoThue.Location = new System.Drawing.Point(121, 49);
            this.txtu_MaSoThue.Name = "txtu_MaSoThue";
            this.txtu_MaSoThue.ReadOnly = true;
            this.txtu_MaSoThue.Size = new System.Drawing.Size(207, 21);
            this.txtu_MaSoThue.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(29, 53);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Mã Số Thuế";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.Color.Red;
            this.label16.Location = new System.Drawing.Point(17, 24);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(13, 17);
            this.label16.TabIndex = 28;
            this.label16.Text = "*";
            // 
            // cmbu_NguoiLienLac
            // 
            this.cmbu_NguoiLienLac.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbu_NguoiLienLac.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.cmbu_NguoiLienLac.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.HoaDonbindingSource, "MaNguoiLienLac", true));
            this.cmbu_NguoiLienLac.DataSource = this.nguoiLienLacListBindingSource;
            ultraGridColumn1.Header.VisiblePosition = 0;
            ultraGridColumn2.Header.VisiblePosition = 1;
            ultraGridColumn3.Header.VisiblePosition = 2;
            ultraGridColumn4.Header.VisiblePosition = 3;
            ultraGridColumn5.Header.VisiblePosition = 4;
            ultraGridBand1.Columns.AddRange(new object[] {
            ultraGridColumn1,
            ultraGridColumn2,
            ultraGridColumn3,
            ultraGridColumn4,
            ultraGridColumn5});
            this.cmbu_NguoiLienLac.DisplayLayout.BandsSerializer.Add(ultraGridBand1);
            this.cmbu_NguoiLienLac.DisplayMember = "TenNguoiLienLac";
            this.cmbu_NguoiLienLac.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007;
            this.cmbu_NguoiLienLac.Location = new System.Drawing.Point(121, 75);
            this.cmbu_NguoiLienLac.Name = "cmbu_NguoiLienLac";
            this.cmbu_NguoiLienLac.Size = new System.Drawing.Size(207, 22);
            this.cmbu_NguoiLienLac.SyncWithCurrencyManager = true;
            this.cmbu_NguoiLienLac.TabIndex = 2;
            this.cmbu_NguoiLienLac.ValueMember = "MaNguoiLienLac";
            this.cmbu_NguoiLienLac.InitializeLayout += new Infragistics.Win.UltraWinGrid.InitializeLayoutEventHandler(this.cmbu_NguoiLienLac_InitializeLayout);
            // 
            // label15
            // 
            this.label15.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(29, 108);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(79, 13);
            this.label15.TabIndex = 0;
            this.label15.Text = "Địa Chỉ Gởi HĐ";
            // 
            // label17
            // 
            this.label17.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(29, 80);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(79, 13);
            this.label17.TabIndex = 0;
            this.label17.Text = "Người Liên Lạc";
            // 
            // label18
            // 
            this.label18.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(29, 26);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(45, 13);
            this.label18.TabIndex = 0;
            this.label18.Text = "Đối Tác";
            // 
            // label19
            // 
            this.label19.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(29, 135);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(59, 13);
            this.label19.TabIndex = 0;
            this.label19.Text = "Điện Thoại";
            // 
            // cmb_DiaChi
            // 
            this.cmb_DiaChi.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cmb_DiaChi.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.HoaDonbindingSource, "MaDCGuiHD", true));
            this.cmb_DiaChi.DataSource = this.diaChiDoiTacListBindingSource;
            this.cmb_DiaChi.DisplayMember = "TenDiaChiChung";
            this.cmb_DiaChi.FormattingEnabled = true;
            this.cmb_DiaChi.Location = new System.Drawing.Point(121, 103);
            this.cmb_DiaChi.Name = "cmb_DiaChi";
            this.cmb_DiaChi.Size = new System.Drawing.Size(206, 21);
            this.cmb_DiaChi.TabIndex = 3;
            this.cmb_DiaChi.ValueMember = "MaDiaChi";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.cb_LoaiHD);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.cmbe_ThueVAT);
            this.groupBox1.Controls.Add(this.cmbeu_TinhTrang);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.numeu_SoTienDaThanhToan);
            this.groupBox1.Controls.Add(this.label22);
            this.groupBox1.Controls.Add(this.label25);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.numeu_TongTien);
            this.groupBox1.Controls.Add(this.txt_VietBangChua);
            this.groupBox1.Controls.Add(this.label26);
            this.groupBox1.Controls.Add(this.numeu_ThanhTien);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.grdu_ChiTietHoaDon);
            this.groupBox1.Location = new System.Drawing.Point(7, 217);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(683, 306);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Chi Tiết Hóa Đơn";
            // 
            // cb_LoaiHD
            // 
            this.cb_LoaiHD.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cb_LoaiHD.AutoSize = true;
            this.cb_LoaiHD.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.HoaDonbindingSource, "KhauTruThue", true));
            this.cb_LoaiHD.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cb_LoaiHD.Location = new System.Drawing.Point(399, 194);
            this.cb_LoaiHD.Name = "cb_LoaiHD";
            this.cb_LoaiHD.Size = new System.Drawing.Size(252, 17);
            this.cb_LoaiHD.TabIndex = 54;
            this.cb_LoaiHD.Text = "Hóa Đơn Khấu Trừ/ Hóa Đơn Bán Hàng";
            this.cb_LoaiHD.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox2.Controls.Add(this.numu_SoTienUuDai);
            this.groupBox2.Controls.Add(this.cbeu_HinhThucUuDai);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.cmbe_PhanTramUuDai);
            this.groupBox2.Controls.Add(this.label20);
            this.groupBox2.Location = new System.Drawing.Point(0, 169);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(339, 72);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Ưu Đãi";
            // 
            // numu_SoTienUuDai
            // 
            this.numu_SoTienUuDai.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            appearance51.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.numu_SoTienUuDai.Appearance = appearance51;
            this.numu_SoTienUuDai.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.numu_SoTienUuDai.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.HoaDonbindingSource, "SoTienChietKhau", true));
            this.numu_SoTienUuDai.Location = new System.Drawing.Point(201, 44);
            this.numu_SoTienUuDai.MaskInput = "{LOC}nnn,nnn,nnn,nnn,nnn";
            this.numu_SoTienUuDai.MaxValue = 1E+18;
            this.numu_SoTienUuDai.Name = "numu_SoTienUuDai";
            this.numu_SoTienUuDai.NumericType = Infragistics.Win.UltraWinEditors.NumericType.Double;
            this.numu_SoTienUuDai.PromptChar = ' ';
            this.numu_SoTienUuDai.ReadOnly = true;
            this.numu_SoTienUuDai.Size = new System.Drawing.Size(126, 21);
            this.numu_SoTienUuDai.TabIndex = 2;
            // 
            // cbeu_HinhThucUuDai
            // 
            this.cbeu_HinhThucUuDai.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.HoaDonbindingSource, "LoaiUuDai", true));
            valueListItem1.DataValue = ((short)(1));
            valueListItem1.DisplayText = "Chiết Khấu";
            valueListItem2.DataValue = ((short)(2));
            valueListItem2.DisplayText = "Giảm Giá";
            valueListItem3.DataValue = ((short)(3));
            valueListItem3.DisplayText = "Khuyến Mãi";
            this.cbeu_HinhThucUuDai.Items.AddRange(new Infragistics.Win.ValueListItem[] {
            valueListItem1,
            valueListItem2,
            valueListItem3});
            this.cbeu_HinhThucUuDai.Location = new System.Drawing.Point(122, 15);
            this.cbeu_HinhThucUuDai.Name = "cbeu_HinhThucUuDai";
            this.cbeu_HinhThucUuDai.Size = new System.Drawing.Size(205, 21);
            this.cbeu_HinhThucUuDai.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(130, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Số Tiền";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(102, 13);
            this.label3.TabIndex = 26;
            this.label3.Text = "Hình thức ưu đãi";
            // 
            // cmbe_PhanTramUuDai
            // 
            this.cmbe_PhanTramUuDai.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.cmbe_PhanTramUuDai.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.HoaDonbindingSource, "ChietKhau", true));
            valueListItem4.DataValue = "ValueListItem0";
            valueListItem4.DisplayText = "0";
            valueListItem5.DataValue = "ValueListItem1";
            valueListItem5.DisplayText = "5";
            valueListItem6.DataValue = "ValueListItem2";
            valueListItem6.DisplayText = "10";
            this.cmbe_PhanTramUuDai.Items.AddRange(new Infragistics.Win.ValueListItem[] {
            valueListItem4,
            valueListItem5,
            valueListItem6});
            this.cmbe_PhanTramUuDai.Location = new System.Drawing.Point(41, 44);
            this.cmbe_PhanTramUuDai.Name = "cmbe_PhanTramUuDai";
            this.cmbe_PhanTramUuDai.Size = new System.Drawing.Size(60, 21);
            this.cmbe_PhanTramUuDai.TabIndex = 1;
            // 
            // label20
            // 
            this.label20.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(12, 48);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(24, 13);
            this.label20.TabIndex = 30;
            this.label20.Text = "(%)";
            // 
            // cmbe_ThueVAT
            // 
            this.cmbe_ThueVAT.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmbe_ThueVAT.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.HoaDonbindingSource, "ThueSuatVAT", true));
            valueListItem7.DataValue = "ValueListItem0";
            valueListItem7.DisplayText = "0";
            valueListItem8.DataValue = "ValueListItem1";
            valueListItem8.DisplayText = "5";
            valueListItem9.DataValue = "ValueListItem2";
            valueListItem9.DisplayText = "10";
            this.cmbe_ThueVAT.Items.AddRange(new Infragistics.Win.ValueListItem[] {
            valueListItem7,
            valueListItem8,
            valueListItem9});
            this.cmbe_ThueVAT.Location = new System.Drawing.Point(399, 217);
            this.cmbe_ThueVAT.Name = "cmbe_ThueVAT";
            this.cmbe_ThueVAT.Size = new System.Drawing.Size(63, 21);
            this.cmbe_ThueVAT.TabIndex = 3;
            // 
            // cmbeu_TinhTrang
            // 
            this.cmbeu_TinhTrang.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmbeu_TinhTrang.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.HoaDonbindingSource, "TinhTrang", true));
            valueListItem10.DataValue = ((byte)(1));
            valueListItem10.DisplayText = "Đã Thanh Toán Đủ";
            valueListItem11.DataValue = ((byte)(2));
            valueListItem11.DisplayText = "Thanh Toán Một Phần";
            valueListItem12.DataValue = ((byte)(0));
            valueListItem12.DisplayText = "Chưa Thanh Toán";
            this.cmbeu_TinhTrang.Items.AddRange(new Infragistics.Win.ValueListItem[] {
            valueListItem10,
            valueListItem11,
            valueListItem12});
            this.cmbeu_TinhTrang.Location = new System.Drawing.Point(155, 277);
            this.cmbeu_TinhTrang.Name = "cmbeu_TinhTrang";
            this.cmbeu_TinhTrang.ReadOnly = true;
            this.cmbeu_TinhTrang.Size = new System.Drawing.Size(172, 21);
            this.cmbeu_TinhTrang.TabIndex = 6;
            this.cmbeu_TinhTrang.ValueChanged += new System.EventHandler(this.cmbeu_TinhTrang_ValueChanged);
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(390, 281);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(144, 13);
            this.label5.TabIndex = 52;
            this.label5.Text = "Số Tiền Đã Thanh Toán";
            // 
            // numeu_SoTienDaThanhToan
            // 
            this.numeu_SoTienDaThanhToan.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            appearance65.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.numeu_SoTienDaThanhToan.Appearance = appearance65;
            this.numeu_SoTienDaThanhToan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.numeu_SoTienDaThanhToan.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.HoaDonbindingSource, "SoTienDaThanhToan", true));
            this.numeu_SoTienDaThanhToan.Location = new System.Drawing.Point(545, 277);
            this.numeu_SoTienDaThanhToan.MaskInput = "{LOC}nnn,nnn,nnn,nnn,nnn";
            this.numeu_SoTienDaThanhToan.MaxValue = 1E+18;
            this.numeu_SoTienDaThanhToan.Name = "numeu_SoTienDaThanhToan";
            this.numeu_SoTienDaThanhToan.NumericType = Infragistics.Win.UltraWinEditors.NumericType.Double;
            this.numeu_SoTienDaThanhToan.PromptChar = ' ';
            this.numeu_SoTienDaThanhToan.ReadOnly = true;
            this.numeu_SoTienDaThanhToan.Size = new System.Drawing.Size(121, 21);
            this.numeu_SoTienDaThanhToan.TabIndex = 7;
            // 
            // label22
            // 
            this.label22.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.Location = new System.Drawing.Point(10, 281);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(69, 13);
            this.label22.TabIndex = 51;
            this.label22.Text = "Tình Trạng";
            // 
            // label25
            // 
            this.label25.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label25.AutoSize = true;
            this.label25.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label25.Location = new System.Drawing.Point(468, 221);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(65, 13);
            this.label25.TabIndex = 45;
            this.label25.Text = "Tổng Tiền";
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(10, 253);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(88, 13);
            this.label9.TabIndex = 49;
            this.label9.Text = "Viết Bằng Chữ";
            // 
            // numeu_TongTien
            // 
            this.numeu_TongTien.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            appearance66.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.numeu_TongTien.Appearance = appearance66;
            this.numeu_TongTien.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.numeu_TongTien.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.HoaDonbindingSource, "TongTien", true));
            this.numeu_TongTien.Location = new System.Drawing.Point(545, 217);
            this.numeu_TongTien.MaskInput = "nnn,nnn,nnn,nnn,nnn";
            this.numeu_TongTien.MaxValue = 1E+18;
            this.numeu_TongTien.Name = "numeu_TongTien";
            this.numeu_TongTien.NumericType = Infragistics.Win.UltraWinEditors.NumericType.Double;
            this.numeu_TongTien.PromptChar = ' ';
            this.numeu_TongTien.ReadOnly = true;
            this.numeu_TongTien.Size = new System.Drawing.Size(121, 21);
            this.numeu_TongTien.TabIndex = 4;
            // 
            // txt_VietBangChua
            // 
            this.txt_VietBangChua.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_VietBangChua.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.HoaDonbindingSource, "VietBangChu", true));
            this.txt_VietBangChua.Location = new System.Drawing.Point(154, 250);
            this.txt_VietBangChua.Name = "txt_VietBangChua";
            this.txt_VietBangChua.Size = new System.Drawing.Size(512, 20);
            this.txt_VietBangChua.TabIndex = 5;
            // 
            // label26
            // 
            this.label26.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label26.AutoSize = true;
            this.label26.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label26.Location = new System.Drawing.Point(345, 221);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(48, 13);
            this.label26.TabIndex = 43;
            this.label26.Text = "(%VAT)";
            // 
            // numeu_ThanhTien
            // 
            this.numeu_ThanhTien.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            appearance67.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.numeu_ThanhTien.Appearance = appearance67;
            this.numeu_ThanhTien.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.numeu_ThanhTien.Location = new System.Drawing.Point(545, 167);
            this.numeu_ThanhTien.MaskInput = "{LOC}nnn,nnn,nnn,nnn,nnn";
            this.numeu_ThanhTien.MaxValue = 1E+18;
            this.numeu_ThanhTien.Name = "numeu_ThanhTien";
            this.numeu_ThanhTien.NumericType = Infragistics.Win.UltraWinEditors.NumericType.Double;
            this.numeu_ThanhTien.PromptChar = ' ';
            this.numeu_ThanhTien.ReadOnly = true;
            this.numeu_ThanhTien.Size = new System.Drawing.Size(121, 21);
            this.numeu_ThanhTien.TabIndex = 2;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(396, 171);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(138, 13);
            this.label6.TabIndex = 44;
            this.label6.Text = "Thành Tiền Chưa Thuế";
            // 
            // grdu_ChiTietHoaDon
            // 
            this.grdu_ChiTietHoaDon.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grdu_ChiTietHoaDon.DataSource = this.cTHoaDonListBindingSource;
            appearance116.BackColor = System.Drawing.Color.White;
            appearance116.FontData.BoldAsString = "False";
            this.grdu_ChiTietHoaDon.DisplayLayout.Appearance = appearance116;
            ultraGridColumn6.Header.VisiblePosition = 8;
            ultraGridColumn7.Header.VisiblePosition = 1;
            ultraGridColumn8.Header.VisiblePosition = 3;
            ultraGridColumn9.Header.VisiblePosition = 0;
            ultraGridColumn10.Header.VisiblePosition = 4;
            ultraGridColumn11.Header.VisiblePosition = 2;
            ultraGridColumn12.Header.VisiblePosition = 5;
            ultraGridColumn13.Header.VisiblePosition = 6;
            ultraGridColumn14.Header.VisiblePosition = 7;
            ultraGridColumn15.Header.VisiblePosition = 9;
            ultraGridColumn16.Header.VisiblePosition = 10;
            ultraGridBand2.Columns.AddRange(new object[] {
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
            this.grdu_ChiTietHoaDon.DisplayLayout.BandsSerializer.Add(ultraGridBand2);
            this.grdu_ChiTietHoaDon.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            this.grdu_ChiTietHoaDon.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.Yes;
            appearance117.BackColor = System.Drawing.Color.SteelBlue;
            this.grdu_ChiTietHoaDon.DisplayLayout.Override.HeaderAppearance = appearance117;
            this.grdu_ChiTietHoaDon.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand;
            this.grdu_ChiTietHoaDon.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdu_ChiTietHoaDon.Location = new System.Drawing.Point(9, 17);
            this.grdu_ChiTietHoaDon.Name = "grdu_ChiTietHoaDon";
            this.grdu_ChiTietHoaDon.Size = new System.Drawing.Size(664, 146);
            this.grdu_ChiTietHoaDon.TabIndex = 0;
            this.grdu_ChiTietHoaDon.Text = "ultraGrid1";
            this.grdu_ChiTietHoaDon.Error += new Infragistics.Win.UltraWinGrid.ErrorEventHandler(this.grdu_ChiTietHoaDon_Error);
            this.grdu_ChiTietHoaDon.InitializeLayout += new Infragistics.Win.UltraWinGrid.InitializeLayoutEventHandler(this.grdu_ChiTietHoaDon_InitializeLayout);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tlsThem,
            this.luuToolStripMenuItem,
            this.tlslblUndo,
            this.btlIn,
            this.tlslblTroGiup,
            this.inToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(701, 24);
            this.menuStrip1.TabIndex = 41;
            this.menuStrip1.Text = "Thêm";
            // 
            // tlsThem
            // 
            this.tlsThem.Image = ((System.Drawing.Image)(resources.GetObject("tlsThem.Image")));
            this.tlsThem.Name = "tlsThem";
            this.tlsThem.Size = new System.Drawing.Size(61, 20);
            this.tlsThem.Text = "Thê&m";
            this.tlsThem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tlsThem.ToolTipText = "Ctr+M";
            this.tlsThem.Click += new System.EventHandler(this.thêmToolStripMenuItem_Click);
            // 
            // luuToolStripMenuItem
            // 
            this.luuToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("luuToolStripMenuItem.Image")));
            this.luuToolStripMenuItem.Name = "luuToolStripMenuItem";
            this.luuToolStripMenuItem.Size = new System.Drawing.Size(53, 20);
            this.luuToolStripMenuItem.Text = "&Lưu";
            this.luuToolStripMenuItem.ToolTipText = "Ctr+L";
            this.luuToolStripMenuItem.Click += new System.EventHandler(this.luuToolStripMenuItem_Click);
            // 
            // tlslblUndo
            // 
            this.tlslblUndo.Image = ((System.Drawing.Image)(resources.GetObject("tlslblUndo.Image")));
            this.tlslblUndo.Name = "tlslblUndo";
            this.tlslblUndo.Size = new System.Drawing.Size(60, 20);
            this.tlslblUndo.Text = "&Undo";
            this.tlslblUndo.ToolTipText = "Ctr+U";
            // 
            // btlIn
            // 
            this.btlIn.Image = ((System.Drawing.Image)(resources.GetObject("btlIn.Image")));
            this.btlIn.Name = "btlIn";
            this.btlIn.Size = new System.Drawing.Size(45, 20);
            this.btlIn.Text = "&In";
            this.btlIn.ToolTipText = "Ctr+I";
            this.btlIn.Click += new System.EventHandler(this.btlIn_Click);
            // 
            // tlslblTroGiup
            // 
            this.tlslblTroGiup.Image = ((System.Drawing.Image)(resources.GetObject("tlslblTroGiup.Image")));
            this.tlslblTroGiup.Name = "tlslblTroGiup";
            this.tlslblTroGiup.Size = new System.Drawing.Size(75, 20);
            this.tlslblTroGiup.Text = "Trợ &Giúp";
            this.tlslblTroGiup.ToolTipText = "Ctr+G";
            // 
            // inToolStripMenuItem
            // 
            this.inToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("inToolStripMenuItem.Image")));
            this.inToolStripMenuItem.Name = "inToolStripMenuItem";
            this.inToolStripMenuItem.Size = new System.Drawing.Size(63, 20);
            this.inToolStripMenuItem.Text = "Th&oát";
            this.inToolStripMenuItem.ToolTipText = "Ctr+O";
            this.inToolStripMenuItem.Click += new System.EventHandler(this.inToolStripMenuItem_Click);
            // 
            // HoaDonbindingSource
            // 
            this.HoaDonbindingSource.DataSource = typeof(ERP_Library.HoaDon);
            // 
            // cTHoaDonListBindingSource
            // 
            this.cTHoaDonListBindingSource.DataMember = "CT_HoaDonList";
            this.cTHoaDonListBindingSource.DataSource = this.HoaDonbindingSource;
            this.cTHoaDonListBindingSource.CurrentChanged += new System.EventHandler(this.cTHoaDonListBindingSource_CurrentChanged);
            // 
            // doiTacDienThoaiFaxListBindingSource
            // 
            this.doiTacDienThoaiFaxListBindingSource.DataMember = "DoiTac_DienThoai_FaxList";
            this.doiTacDienThoaiFaxListBindingSource.DataSource = this.DoiTacbindingSource;
            // 
            // DoiTacbindingSource
            // 
            this.DoiTacbindingSource.DataSource = typeof(ERP_Library.DoiTac);
            // 
            // nguoiLienLacListBindingSource
            // 
            this.nguoiLienLacListBindingSource.DataMember = "NguoiLienLacList";
            this.nguoiLienLacListBindingSource.DataSource = this.DoiTacbindingSource;
            // 
            // diaChiDoiTacListBindingSource
            // 
            this.diaChiDoiTacListBindingSource.DataMember = "DiaChi_DoiTacList";
            this.diaChiDoiTacListBindingSource.DataSource = this.DoiTacbindingSource;
            // 
            // phuongThucThanhToanListBindingSource
            // 
            this.phuongThucThanhToanListBindingSource.DataSource = typeof(ERP_Library.PhuongThucThanhToanList);
            // 
            // donHangBanBindingSource
            // 
            this.donHangBanBindingSource.DataSource = typeof(ERP_Library.DonHangBanList);
            // 
            // donHangMuaBindingSource
            // 
            this.donHangMuaBindingSource.DataSource = typeof(ERP_Library.DonHangMuaList);
            // 
            // donNhanHangTraBindingSource
            // 
            this.donNhanHangTraBindingSource.DataSource = typeof(ERP_Library.DonNhanHangTraList);
            // 
            // donTraHangMuaBindingSource
            // 
            this.donTraHangMuaBindingSource.DataSource = typeof(ERP_Library.DonTraHangMuaList);
            // 
            // frmHoaDonTuDonHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(701, 526);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.ultraGroupBox2);
            this.Controls.Add(this.ultraGroupBox3);
            this.Name = "frmHoaDonTuDonHang";
            this.Text = "Hóa Đơn";
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox3)).EndInit();
            this.ultraGroupBox3.ResumeLayout(false);
            this.ultraGroupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ultradteNgayLap)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtu_NgayHetHanTT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox2)).EndInit();
            this.ultraGroupBox2.ResumeLayout(false);
            this.ultraGroupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtu_MaSoThue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbu_NguoiLienLac)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numu_SoTienUuDai)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbeu_HinhThucUuDai)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbe_PhanTramUuDai)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbe_ThueVAT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbeu_TinhTrang)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numeu_SoTienDaThanhToan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numeu_TongTien)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numeu_ThanhTien)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdu_ChiTietHoaDon)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.HoaDonbindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cTHoaDonListBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.doiTacDienThoaiFaxListBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DoiTacbindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nguoiLienLacListBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.diaChiDoiTacListBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.phuongThucThanhToanListBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.donHangBanBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.donHangMuaBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.donNhanHangTraBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.donTraHangMuaBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Infragistics.Win.Misc.UltraGroupBox ultraGroupBox3;
        private System.Windows.Forms.ComboBox cmb_HinhThucTT;
        private System.Windows.Forms.TextBox txt_SoSerial;
        private System.Windows.Forms.TextBox txt_SoHoaDon;
        private Infragistics.Win.UltraWinEditors.UltraDateTimeEditor dtu_NgayHetHanTT;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label1;
        private Infragistics.Win.Misc.UltraGroupBox ultraGroupBox2;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.ComboBox cmb_DienThoai;
        private System.Windows.Forms.TextBox txt_DoiTac;
        private Infragistics.Win.UltraWinEditors.UltraTextEditor txtu_MaSoThue;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label16;
        private Infragistics.Win.UltraWinGrid.UltraCombo cmbu_NguoiLienLac;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.ComboBox cmb_DiaChi;
        private Infragistics.Win.UltraWinEditors.UltraDateTimeEditor ultradteNgayLap;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox groupBox1;
        private Infragistics.Win.UltraWinGrid.UltraGrid grdu_ChiTietHoaDon;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label9;
        private Infragistics.Win.UltraWinEditors.UltraNumericEditor numeu_TongTien;
        private System.Windows.Forms.TextBox txt_VietBangChua;
        private System.Windows.Forms.Label label26;
        private Infragistics.Win.UltraWinEditors.UltraNumericEditor numeu_ThanhTien;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tlsThem;
        private System.Windows.Forms.ToolStripMenuItem luuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tlslblUndo;
        private System.Windows.Forms.ToolStripMenuItem btlIn;
        private System.Windows.Forms.ToolStripMenuItem tlslblTroGiup;
        private System.Windows.Forms.ToolStripMenuItem inToolStripMenuItem;
        private Infragistics.Win.UltraWinEditors.UltraComboEditor cmbeu_TinhTrang;
        private System.Windows.Forms.Label label5;
        private Infragistics.Win.UltraWinEditors.UltraNumericEditor numeu_SoTienDaThanhToan;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.BindingSource donHangBanBindingSource;
        private System.Windows.Forms.BindingSource donHangMuaBindingSource;
        private System.Windows.Forms.BindingSource donNhanHangTraBindingSource;
        private System.Windows.Forms.BindingSource donTraHangMuaBindingSource;
        private System.Windows.Forms.BindingSource HoaDonbindingSource;
        private System.Windows.Forms.BindingSource cTHoaDonListBindingSource;
        private System.Windows.Forms.BindingSource phuongThucThanhToanListBindingSource;
        private System.Windows.Forms.TextBox txt_SoDonHang;
        private System.Windows.Forms.BindingSource DoiTacbindingSource;
        private System.Windows.Forms.BindingSource doiTacDienThoaiFaxListBindingSource;
        private System.Windows.Forms.BindingSource nguoiLienLacListBindingSource;
        private System.Windows.Forms.BindingSource diaChiDoiTacListBindingSource;
        private Infragistics.Win.UltraWinEditors.UltraComboEditor cmbe_ThueVAT;
        private System.Windows.Forms.GroupBox groupBox2;
        private Infragistics.Win.UltraWinEditors.UltraNumericEditor numu_SoTienUuDai;
        private Infragistics.Win.UltraWinEditors.UltraComboEditor cbeu_HinhThucUuDai;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private Infragistics.Win.UltraWinEditors.UltraComboEditor cmbe_PhanTramUuDai;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.CheckBox cb_LoaiHD;
    }
}