using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Infragistics.Shared;
using Infragistics.Win;
using Infragistics.Win.UltraWinGrid;
using ERP_Library;
using CrystalDecisions.CrystalReports.Engine;
using System.Data.SqlClient;
namespace PSC_ERP
{

    public partial class frmHoaDonMuaBanQuyen : Form
    {               
        HoaDon _hoaDon;
        DoiTacList _DoiTacList;      
        private HamDungChung hamDungChung = new HamDungChung();
        private Util util = new Util();
        HoaDon_DoiTac _hdDOitac;
        Decimal _tongTien = 0;        
        long maDoiTac = 0;
        DateTime _ngaylap=DateTime.Now.Date;
        HoaDonList _hoaDonList = HoaDonList.NewHoaDonList();
        bool _loaikhautru = false;
        public HoaDonList _HoaDonListDichVu = HoaDonList.NewHoaDonList();
      
        //Thành Thêm
        ChungTu _chungTu;
        ButToan _butToan;
      
        public frmHoaDonMuaBanQuyen()
        {
            InitializeComponent();
            KhaiBaoSuKien();
            KhoiTao();
            ThemMoi();        
        }
        public frmHoaDonMuaBanQuyen(DateTime Ngaylap, bool Loai)
        {
            _ngaylap = Ngaylap;
            InitializeComponent();
            KhaiBaoSuKien();
            KhoiTao();
            ThemMoi();
            _hoaDon.NgayLap = _ngaylap;
            _hoaDon.NgayHetHanTT = _ngaylap;
            _hoaDon.KhauTruThue = Loai;
            cmbu_LoaiHoaDon.ReadOnly = true;
        }

        public frmHoaDonMuaBanQuyen(long _maDoiTac , DateTime NgayLap, bool Loai)
        {
            _ngaylap = NgayLap;

            maDoiTac = _maDoiTac;
            InitializeComponent();
            KhaiBaoSuKien();
            KhoiTao(_maDoiTac);
            ThemMoi();         
            cmbu_LoaiHoaDon.ReadOnly = true;
         
            _hoaDon.NgayHetHanTT = _ngaylap;
            _hoaDon.NgayLap = _ngaylap;
            _hoaDon.KhauTruThue = Loai;
            if (Loai)
                cmbe_ThueVAT.Enabled = false;
           // cmbu_KhachHang.ReadOnly = true;

          
        }

        //public void Show_frmHoaDonDichVuMuaVao()
        //{
        //    frmHoaDonDichVuMuaVao frm=new frmHoaDonDichVuMuaVao(30);
        //    frm.Show();
        //}
        
        public frmHoaDonMuaBanQuyen(int loai)
        {

            InitializeComponent();
            KhaiBaoSuKien();
            KhoiTao();
            ThemMoi(loai);
          
        }
        public frmHoaDonMuaBanQuyen(HoaDon hd)
        {
            InitializeComponent();
            KhaiBaoSuKien();
            KhoiTao();
            KhoiTao(hd);
            if (_hoaDon.MaDoiTac == 0)
            {
                radngoaidm.Checked = true;
                _hdDOitac = HoaDon_DoiTac.GetHoaDon_DoiTacByHoaDon(_hoaDon.MaHoaDon);
                Binds_hoadon_Doitac.DataSource = _hdDOitac;
                txtu_MaSoThue.Text = _hdDOitac.MSThue;
            }

        } 

        public frmHoaDonMuaBanQuyen(ChungTu ct, HoaDon hd)
        {
            InitializeComponent();
            KhaiBaoSuKien();
            KhoiTao();
            KhoiTao(hd);
            _chungTu = ct;
            if (_hoaDon.MaDoiTac == 0)
            {
                radngoaidm.Checked = true;
                _hdDOitac = HoaDon_DoiTac.GetHoaDon_DoiTacByHoaDon(_hoaDon.MaHoaDon);
                Binds_hoadon_Doitac.DataSource = _hdDOitac;
                txtu_MaSoThue.Text = _hdDOitac.MSThue;
            }
        }   
  
        //Tạo Hóa Đơn Dịch Vụ Mua Vào Mới - Thành Viết (14/03/2012)
        public frmHoaDonMuaBanQuyen(ChungTu chungTu, ButToan butToan, bool _loai)
        {
            InitializeComponent();
            KhaiBaoSuKien();
            KhoiTao();
            _chungTu = chungTu;
            _butToan = butToan;
            _loaikhautru = _loai;
            ThemMoi(chungTu, butToan, _loai);

            cmbu_LoaiHoaDon.ReadOnly = true;
        }

        private void KhaiBaoSuKien()
        {
            hamDungChung.EventForm(this);           
        }                                 
        public void KhoiTao(HoaDon hd)
        {
           
            _hoaDon = hd;
            phuongThucThanhToanListBindingSource.DataSource = PhuongThucThanhToanList.GetPhuongThucThanhToanList();
//            doiTacListBindingSource.DataSource = DoiTacList.GetDoiTacList(_hoaDon.MaDoiTac);
            hoaDonbindingSource.DataSource = _hoaDon;
            
        }
     

        private void cmbu_KhachHang_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            FilterCombo f = new FilterCombo(cmbu_KhachHang, "TenDoiTac");            

            cmbu_KhachHang.DisplayLayout.Bands[0].Columns["MaDoiTac"].Hidden = true;
            cmbu_KhachHang.DisplayLayout.Bands[0].Columns["KhachHang"].Hidden = true;
            cmbu_KhachHang.DisplayLayout.Bands[0].Columns["NhaCungCap"].Hidden = true;
            cmbu_KhachHang.DisplayLayout.Bands[0].Columns["LoaiDoitac"].Hidden = true;
            cmbu_KhachHang.DisplayLayout.Bands[0].Columns["DienGiai"].Hidden = true;
            cmbu_KhachHang.DisplayLayout.Bands[0].Columns["TinhTrang"].Hidden = true;
            cmbu_KhachHang.DisplayLayout.Bands[0].Columns["MaQLDoiTac"].Hidden = true;
            cmbu_KhachHang.DisplayLayout.Bands[0].Columns["Tenviettat"].Hidden = true;
            cmbu_KhachHang.DisplayLayout.Bands[0].Columns["DiaChi"].Hidden = true;
            cmbu_KhachHang.DisplayLayout.Bands[0].Columns["DienThoai"].Hidden = true;

            cmbu_KhachHang.DisplayLayout.Bands[0].Columns["TenDoitac"].Header.Caption = "Tên Khách Hàng";
            cmbu_KhachHang.DisplayLayout.Bands[0].Columns["TenDoitac"].Width = 150;

            cmbu_KhachHang.DisplayLayout.Bands[0].Columns["MaSoThue"].Hidden = false;
            cmbu_KhachHang.DisplayLayout.Bands[0].Columns["MaSoThue"].Header.Caption = "Mã Số Thuế";

            this.cmbu_KhachHang.DisplayLayout.Override.HeaderAppearance.BackColor = System.Drawing.Color.SteelBlue;//appearance17;
            this.cmbu_KhachHang.DisplayLayout.Override.HeaderStyle = HeaderStyle.WindowsXPCommand;

            foreach (UltraGridColumn col in this.cmbu_KhachHang.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = Color.Navy;
            }
        }            
        private void cmbu_NguoiLienLac_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {

            cmbu_NguoiLienLac.DisplayLayout.Bands[0].Columns["MaNguoiLienLac"].Hidden = true;
            cmbu_NguoiLienLac.DisplayLayout.Bands[0].Columns["TenNguoiLienLac"].Header.Caption = "Tên Người Liên Lạc";
            cmbu_NguoiLienLac.DisplayLayout.Bands[0].Columns["TenNguoiLienLac"].Header.VisiblePosition = 1;
            cmbu_NguoiLienLac.DisplayLayout.Bands[0].Columns["DienThoai"].Header.Caption = "Điện Thoại";
            cmbu_NguoiLienLac.DisplayLayout.Bands[0].Columns["DienThoai"].Header.VisiblePosition = 2;
            cmbu_NguoiLienLac.DisplayLayout.Bands[0].Columns["Email"].Header.Caption = "Email";
            cmbu_NguoiLienLac.DisplayLayout.Bands[0].Columns["Email"].Header.VisiblePosition = 3;
            cmbu_NguoiLienLac.DisplayLayout.Bands[0].Columns["MaDoiTac"].Hidden = true;
            this.cmbu_NguoiLienLac.DisplayLayout.Override.HeaderStyle = HeaderStyle.WindowsXPCommand;
            this.cmbu_NguoiLienLac.DisplayLayout.Override.HeaderAppearance.BackColor = System.Drawing.Color.SteelBlue;
            foreach (UltraGridColumn col in this.cmbu_NguoiLienLac.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;//x =  //= System.Drawing.w;//RoyalBlue
            }
        }
                

        #region KhoiTao không tham số
        private void KhoiTao()
        {
            loaiTienListBindingSource.DataSource = LoaiTienList.GetLoaiTienList();
            phuongThucThanhToanListBindingSource.DataSource = PhuongThucThanhToanList.GetPhuongThucThanhToanList();
            _DoiTacList = DoiTacList.GetDoiTacListByTen(0);
            DoiTac _DoiTac = DoiTac.NewDoiTac(0, "Thêm Mới...");
            _DoiTacList.Insert(0, _DoiTac);
            doiTacListBindingSource.DataSource = _DoiTacList;         
        }
        private void KhoiTao(long maDoiTac)
        {
            loaiTienListBindingSource.DataSource = LoaiTienList.GetLoaiTienList();
            phuongThucThanhToanListBindingSource.DataSource = PhuongThucThanhToanList.GetPhuongThucThanhToanList();
            _DoiTacList = DoiTacList.GetDoiTacListByTen(0);

            DoiTac _DoiTac = DoiTac.NewDoiTac(0, "Thêm Mới...");
            _DoiTacList.Insert(0, _DoiTac);
            doiTacListBindingSource.DataSource = _DoiTacList;
            cmbu_KhachHang.Value = maDoiTac;           
        }    
        private void ThemMoi()
        {
            _hoaDon = HoaDon.NewHoaDon();
            hoaDonbindingSource.DataSource = _hoaDon;
            _hoaDon.MaDoiTac = maDoiTac;
            _hoaDon.LoaiHoaDon = 30;
            _hoaDon.MaHinhThucTT = 1;
            _hoaDon.NgayLap = _ngaylap;
            _hoaDon.NgayHetHanTT = _ngaylap;

            txt_SoHoaDon.Focus();

            _hdDOitac = HoaDon_DoiTac.NewHoaDon_DoiTac();
            Binds_hoadon_Doitac.DataSource = _hdDOitac;
        }
        private void ThemMoi(int loai)
        {
            _hoaDon = HoaDon.NewHoaDon();
            _hoaDon.LoaiHoaDon = loai;
            hoaDonbindingSource.DataSource = _hoaDon;
            _hoaDon.MaHinhThucTT = 1;
            _hoaDon.NgayHetHanTT = _ngaylap;
            _hoaDon.NgayLap = _ngaylap;

            _hdDOitac = HoaDon_DoiTac.NewHoaDon_DoiTac();
            Binds_hoadon_Doitac.DataSource = _hdDOitac;
        }

        decimal soTienTruocThue;
        decimal tienThue;
        private void ThemMoi(ChungTu chungTu, ButToan butToan, bool loai)
        {
             soTienTruocThue=0;
             tienThue=0;
            foreach (ButToan bt in chungTu.DinhKhoan.ButToan)
            {
                if (bt.SoHieuTKNo.Contains("3113"))
                {
                    tienThue += bt.SoTien;
                }
                else
                {
                    soTienTruocThue += bt.SoTien;
                }
            }

            _hoaDon = HoaDon.NewHoaDon();

            hoaDonbindingSource.DataSource = _hoaDon;
            _hoaDon.NgayLap = chungTu.NgayLap;
           // _hoaDon.NgayHetHanTT = _hoaDon.NgayLap.AddMonths(6);
           // dtp_NgayHetHanTT.Value = _hoaDon.NgayLap.AddMonths(6);
            _hoaDon.MaDoiTac = chungTu.DoiTuong;
            _hoaDon.LoaiHoaDon = 30;
            _hoaDon.MaHinhThucTT = 1;
            _hoaDon.NgayLap = chungTu.NgayLap;
            _hoaDon.NgayHetHanTT = _hoaDon.NgayLap.AddMonths(6);          
            _hoaDon.ThanhTien = soTienTruocThue;
            _hoaDon.ThueSuatVAT = 10;
            _hoaDon.GhiChu = butToan.DienGiai;
            _hoaDon.KhauTruThue = loai;

            txt_SoHoaDon.Focus();
            hoaDonbindingSource.DataSource = _hoaDon;
            _hdDOitac = HoaDon_DoiTac.NewHoaDon_DoiTac();
            Binds_hoadon_Doitac.DataSource = _hdDOitac;
           
        }
      
        #endregion               
      
        private void luuToolStripMenuItem_Click(object sender, EventArgs e)                                                             
        {
            if (KiemTraDuLieu() == true)
            {
                try
                {
                    if (txtu_MaSoThue.Text.Length == 9 || (txtu_MaSoThue.Text.Length == 14 && txtu_MaSoThue.Text.Substring(10, 1) == "-") || txtu_MaSoThue.Text.Length == 13 || txtu_MaSoThue.Text.Length == 10 || txtu_MaSoThue.Text.Length ==0)
                    {

                        hoaDonbindingSource.EndEdit();
                        _hoaDon.ApplyEdit();
                        _hoaDon.Save();

                        // Luu Khach Hang moi
                        if (_hdDOitac != null)
                        {
                            Binds_hoadon_Doitac.EndEdit();
                            _hdDOitac.MaHoaDon = _hoaDon.MaHoaDon;
                            _hdDOitac.TenDoiTac = cbo_khnhap.Text;
                            _hdDOitac.NguoiLienHe = cbo_nguoillnhap.Text;
                            _hdDOitac.MSThue = txtu_MaSoThue.Text;
                            _hdDOitac.DiaChi = cbo_diachinhap.Text;
                            _hdDOitac.DienThoai = cbo_dtnhap.Text;
                            _hdDOitac.Save();
                        }
                        _HoaDonListDichVu.Add(_hoaDon);

                        if (_hoaDonList.Count != 0)
                        {
                            _hoaDonList.ApplyEdit();
                            _hoaDonList.Save();
                        }
                        MessageBox.Show(this, util.thanhcong, util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {

                        MessageBox.Show(this, "Mã Số Thuế Không Hợp Lệ", util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtu_MaSoThue.Focus();
                        return;
                    }

                  
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }

            }
        }          
        private void thêmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_chungTu != null)
            {
                ThemMoi(_chungTu, _butToan, _loaikhautru);
            }
            else
            {
                ThemMoi();
            }
        }                        
        private void cmbeu_TinhTrang_ValueChanged(object sender, EventArgs e)
        {
            if (cmbeu_TinhTrang.Value != null)
            {
                //chưa thanh tóan
                if (Convert.ToInt32(cmbeu_TinhTrang.Value) == 0)
                {                 
                    num_SoTienDaThanhToan.Value = 0;
                    _hoaDon.TinhTrang = 0;
                }
                //thanh toán đủ
                else if (Convert.ToInt32(cmbeu_TinhTrang.Value) == 1)
                {
                    if (_tongTien != 0)
                    {
                        num_SoTienDaThanhToan.Value = _tongTien;                        
                    }
                    else
                    {
                        num_SoTienDaThanhToan.Value = _hoaDon.TongTien;
                        _hoaDon.SoTienDaThanhToan = _hoaDon.TongTien;
                    }
                    _hoaDon.TinhTrang = 1;
                }
                //thanh toán 1 phần
                else //if (Convert.ToInt32(cmbeu_TinhTrang.Value) == 2)
                {
                  
                    num_SoTienDaThanhToan.Value = 0;                    
                    _hoaDon.TinhTrang = 2;
                }
            }
        }
        private void inToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, util.thaoTac, util.thongbao, MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                this.Close();
            }
        }          
        private void cmbe_ThueVAT_ValueChanged(object sender, EventArgs e)
        {
           
        }                                                            
        private void tlslblThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        #region process




        private bool KiemTraDuLieu()
        {
            bool kq = true;
            hoaDonbindingSource.EndEdit();
            if (_hoaDon.SoHoaDon == string.Empty)
            {
                MessageBox.Show(this, util.sohoadon, util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_SoHoaDon.Focus();
                kq = false;
            }
           
            else if (_hoaDon.MaDoiTac == 0 && radtrongdm.Checked)
            {
                MessageBox.Show(this, util.nhaptenkhachhang, util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_SoSerial.Focus();
                kq = false;
            }
            else if (cmb_HinhThucTT.Text == "")
            {
                MessageBox.Show(this, "Chưa Chọn Phương Thức Thanh Toán", util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmb_HinhThucTT.Focus();
                kq = false;
            }  
            else if(_chungTu !=null)
            {
                if (dtp_NgayLap.DateTime.Date > _chungTu.NgayLap.Date)
                {
                    MessageBox.Show(this, "Ngày lập hóa đơn phải nhỏ hơn hoạt bằng ngày lập chứng từ", util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    dtp_NgayLap.Focus();
                    kq = false;
                }
            }
            else if (txt_DienGiai.Text == "" || txt_DienGiai.Text== null)
            {
                MessageBox.Show(this, "Diễn giải không được để trống", util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_DienGiai.Focus();
                kq = false;
            }

            return kq;
        }
        private void LoadKhachHang()
        {
            _hoaDon.MaDoiTac = 0;
            if (radtrongdm.Checked)
            {
                cmbu_KhachHang.Visible = true;
                cbo_khnhap.Visible = false;
                cmb_DiaChi.Visible = true;
                cbo_diachinhap.Visible = false;
                cmb_DienThoai.Visible = true;                
                cbo_dtnhap.Visible = false;
                cmbu_NguoiLienLac.Visible = true;
                cbo_nguoillnhap.Visible = false;

                cbo_khnhap.Text = "";
                cbo_diachinhap.Text = "";
                cbo_dtnhap.Text = "";
                cbo_nguoillnhap.Text = "";
                cmbu_KhachHang.Focus();
            }
            else
            {
                txtu_MaSoThue.ReadOnly = false;
                cmbu_KhachHang.Visible = false;
                cbo_khnhap.Visible = true;
                cmb_DiaChi.Visible = false;
                cbo_diachinhap.Visible = true;
                cmb_DienThoai.Visible = false;
                cbo_dtnhap.Visible = true;
                cmbu_NguoiLienLac.Visible = false;
                cbo_nguoillnhap.Visible = true;
                cmbu_KhachHang.Value = 0;
                cbo_khnhap.Focus();
            }
        }
        #endregion

        private void radtrongdm_CheckedChanged(object sender, EventArgs e)
        {
            LoadKhachHang();
        }

        private void radngoaidm_CheckedChanged(object sender, EventArgs e)
        {
            LoadKhachHang();
        }

        private void cbo_khnhap_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            cbo_khnhap.DisplayLayout.Bands[0].Columns["id"].Hidden = true;
            cbo_khnhap.DisplayLayout.Bands[0].Columns["mahoadon"].Hidden = true;
            cbo_khnhap.DisplayLayout.Bands[0].Columns["diachi"].Hidden = true;
            cbo_khnhap.DisplayLayout.Bands[0].Columns["msthue"].Hidden = true;
            cbo_khnhap.DisplayLayout.Bands[0].Columns["nguoilienhe"].Hidden = true;
            cbo_khnhap.DisplayLayout.Bands[0].Columns["dienthoai"].Hidden = true;
            cbo_khnhap.DisplayLayout.Bands[0].Columns["Tendoitac"].Header.Caption = "Tên Đối Tác";

        }

        private void cbo_nguoillnhap_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            cbo_nguoillnhap.DisplayLayout.Bands[0].Columns["id"].Hidden = true;
            cbo_nguoillnhap.DisplayLayout.Bands[0].Columns["mahoadon"].Hidden = true;
            cbo_nguoillnhap.DisplayLayout.Bands[0].Columns["diachi"].Hidden = true;
            cbo_nguoillnhap.DisplayLayout.Bands[0].Columns["msthue"].Hidden = true;
            cbo_nguoillnhap.DisplayLayout.Bands[0].Columns["nguoilienhe"].Header.Caption = "Liên Hệ";
            cbo_nguoillnhap.DisplayLayout.Bands[0].Columns["dienthoai"].Hidden = true;
            cbo_nguoillnhap.DisplayLayout.Bands[0].Columns["nguoilienhe"].Hidden = true;
        }

        private void cmbu_KhachHang_AfterCloseUp(object sender, EventArgs e)
        {
            long ma = 0;
            if (cmbu_KhachHang.ActiveRow != null)
            {                            
                if (cmbu_KhachHang.Text == "Thêm Mới...")
                {                                                                         
                    frmKhachHang _frmKhachHang = new frmKhachHang();
                    if (_frmKhachHang.ShowDialog() != DialogResult.OK)
                    {
                        _DoiTacList = DoiTacList.GetDoiTacListByTen(0);
                        DoiTac _DoiTac = DoiTac.NewDoiTac(0, "Thêm Mới...");
                        _DoiTacList.Insert(0, _DoiTac);
                        ma = _DoiTacList[_DoiTacList.Count - 1].MaDoiTac;
                        cmbu_KhachHang.Value = ma;

                        diaChiDoiTacListBindingSource.DataSource = DoiTac.GetDoiTac(ma).DiaChi_DoiTacList;
                        doiTacDienThoaiFaxListBindingSource.DataSource = DoiTac.GetDoiTac(ma).DoiTac_DienThoai_FaxList;
                        doiTacListBindingSource.DataSource = _DoiTacList;
                    }
                }
            }
        }

        private void cmbu_KhachHang_ValueChanged(object sender, EventArgs e)
        {
            if (cmbu_KhachHang.ActiveRow != null)
            {
                txtu_MaSoThue.ReadOnly = true;           
                if (cmbu_KhachHang.Text != "Thêm Mới...")
                {                  
                    diaChiDoiTacListBindingSource.DataSource = DoiTac.GetDoiTac((long)cmbu_KhachHang.Value).DiaChi_DoiTacList;
                    doiTacDienThoaiFaxListBindingSource.DataSource = DoiTac.GetDoiTac((long)cmbu_KhachHang.Value).DoiTac_DienThoai_FaxList;
                }
            }
        }

        private void ultraGroupBox2_Click(object sender, EventArgs e)
        {

        }

        private void cbu_LoaiTien_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            foreach (UltraGridColumn col in this.cbu_LoaiTien.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;
                col.Hidden = true;
            }
            cbu_LoaiTien.DisplayLayout.Bands[0].Columns["MaLoaiQuanLy"].Hidden = false;
            cbu_LoaiTien.DisplayLayout.Bands[0].Columns["MaLoaiQuanLy"].Header.Caption = "Loại Tiền";
            cbu_LoaiTien.DisplayLayout.Bands[0].Columns["MaLoaiQuanLy"].Header.VisiblePosition = 0;
            cbu_LoaiTien.DisplayLayout.Bands[0].Columns["MaLoaiQuanLy"].Width = 40;

            cbu_LoaiTien.DisplayLayout.Bands[0].Columns["TenLoaiTien"].Hidden = false;
            cbu_LoaiTien.DisplayLayout.Bands[0].Columns["TenLoaiTien"].Header.Caption = "Tên Loại Tiền";
            cbu_LoaiTien.DisplayLayout.Bands[0].Columns["TenLoaiTien"].Header.VisiblePosition = 2;
            cbu_LoaiTien.DisplayLayout.Bands[0].Columns["TenLoaiTien"].Width = 80;

            cbu_LoaiTien.DisplayLayout.Bands[0].Columns["TiGiaQuyDoi"].Hidden = false;
            cbu_LoaiTien.DisplayLayout.Bands[0].Columns["TiGiaQuyDoi"].Header.Caption = "Tỷ Giá";
            cbu_LoaiTien.DisplayLayout.Bands[0].Columns["TiGiaQuyDoi"].Header.VisiblePosition = 1;
            cbu_LoaiTien.DisplayLayout.Bands[0].Columns["TiGiaQuyDoi"].Width = 50;
        }

        private void frmHoaDonMuaBanQuyen_Load(object sender, EventArgs e)
        {

        }

      

             
    }
}
  
