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
    public partial class frmHoaDonDichVuBanRa : Form
    {


        HoaDon _hoaDon;
        NguoiLienLacList _NguoiLienLacList;
        DoiTacList _DoiTacList;
        DoiTac_DienThoai_FaxList _DoiTac_DienThoai_FaxList;
        DiaChi_DoiTacList _DiaChi_DoiTacList;
        private HamDungChung hamDungChung = new HamDungChung();
        private Util util = new Util();
        Decimal _tongTien = 0;
        int _loaihd = 5;//Hoa Don Ban Ra
        long maDoiTac = 0;
        DateTime _ngaylap = DateTime.Now.Date;
        HoaDonList _hoaDonList = HoaDonList.NewHoaDonList();
        public HoaDonList _HoaDonListDichVu = HoaDonList.NewHoaDonList();
        HoaDon_DoiTac _hdDOitac;
        Boolean capNhatHoaDon = false;

        // phan khai bao hoa don tu tang 
        int _Loaicaphd = 0;
        string _sokh = "", _sohd = "";
        string _KyHieuMauHoaDon = "";
        PhuongThucThanhToanList _phuongthucthanhtoanList = PhuongThucThanhToanList.NewPhuongThucThanhToanList();
        ChungTu _chungTu;


        private BindingSource NhomHHDVMVListBindingSource = new BindingSource();
        private BindingSource DoiTacListBindingSource = new BindingSource();

        #region Devexpress
        int UserId = ERP_Library.Security.CurrentUser.Info.UserID;
        DataSet dataSetDev;
        #endregion //Devexpress

        public void Show_frmHoaDonDichVuBanRa()
        {
            frmHoaDonDichVuBanRa frm = new frmHoaDonDichVuBanRa(5);
            frm.Show();
        }
        public frmHoaDonDichVuBanRa()
        {
            InitializeComponent();
            KhoiTao();
            cmbu_LoaiHoaDon.ReadOnly = true;
            ThemMoi();
            _hoaDon.LoaiHoaDon = 5;
            // Lay so hoa don theo bo phan
            _Loaicaphd = CapPhatHoaDon.LaySoHoaDon(ref _sokh, ref _sohd, ERP_Library.Security.CurrentUser.Info.MaBoPhan);
            _hoaDon.SoHoaDon = _sohd;
            _hoaDon.SoSerial = _sokh;
            _hoaDon.MaHinhThucTT = 0;
            //if (_Loaicaphd == 1)
            //    _hoaDon.SoHoaDon = "";
        }

        public frmHoaDonDichVuBanRa(ButToan buttoan, string tenDoiTuong, decimal sotienChungtu, int phuongthucthanhtoan)
        {
            InitializeComponent();
            KhoiTao();
            cmbu_LoaiHoaDon.ReadOnly = true;
            ThemMoi(buttoan, tenDoiTuong, sotienChungtu, phuongthucthanhtoan);
            _hoaDon.LoaiHoaDon = 5;
            // Lay so hoa don theo bo phan
            _Loaicaphd = CapPhatHoaDon.LaySoHoaDon(ref _sokh, ref _sohd, ERP_Library.Security.CurrentUser.Info.MaBoPhan);
            _hoaDon.SoHoaDon = _sohd;
            _hoaDon.SoSerial = _sokh;
            //if (_Loaicaphd == 1)
            //    _hoaDon.SoHoaDon = "";

        }

        public frmHoaDonDichVuBanRa(ChungTu chungtu)
        {
            InitializeComponent();
            KhoiTao();
            cmbu_LoaiHoaDon.ReadOnly = true;
            ThemMoi(chungtu);
            _hoaDon.LoaiHoaDon = 5;
            // Lay so hoa don theo bo phan
            _Loaicaphd = CapPhatHoaDon.LaySoHoaDon(ref _sokh, ref _sohd, ERP_Library.Security.CurrentUser.Info.MaBoPhan);
            _hoaDon.SoHoaDon = _sohd;
            _hoaDon.SoSerial = _sokh;
            //if (_Loaicaphd == 1)
            //    _hoaDon.SoHoaDon = "";

        }

        public frmHoaDonDichVuBanRa(long _maDoiTac, int Loai, DateTime Ngaylap, ChungTu chungtu = null)
        {
            InitializeComponent();
            maDoiTac = _maDoiTac;
            _loaihd = Loai;
            KhoiTao(_maDoiTac);
            ThemMoi(_maDoiTac);
            cmbu_LoaiHoaDon.ReadOnly = true;
            //cmbu_KhachHang.ReadOnly = true;

            _hoaDon.NgayHetHanTT = _ngaylap;
            _hoaDon.NgayLap = _ngaylap;
            // Lay so hoa don theo bo phan
            _Loaicaphd = CapPhatHoaDon.LaySoHoaDon(ref _sokh, ref _sohd, ERP_Library.Security.CurrentUser.Info.MaBoPhan);
            _hoaDon.SoHoaDon = _sohd;
            _hoaDon.SoSerial = _sokh;
            //if (_Loaicaphd == 1)
            //    _hoaDon.SoHoaDon = "";
            khoitaocontrol();
            _chungTu = chungtu;
            foreach (ButToan bt in _chungTu.DinhKhoan.ButToan)
            {
                CT_HoaDonDichVu ct_dichvu = CT_HoaDonDichVu.NewCT_HoaDonDichVu();
                ct_dichvu.SoLuong = 1;
                ct_dichvu.DonGia = bt.SoTien;
                ct_dichvu.MaDoiTac = bt.DoiTuongCo;
                _hoaDon.CT_HoaDonDichVuList.Add(ct_dichvu);
            }
            cTHoaDonDichVuListBindingSource.DataSource = _hoaDon.CT_HoaDonDichVuList;

        }
        public frmHoaDonDichVuBanRa(int loai)
        {
            InitializeComponent();
            _loaihd = loai;
            //tlslblThem.Enabled = false;
            cmbu_LoaiHoaDon.ReadOnly = true;
            KhoiTao();
            ThemMoi(loai);

            // Lay so hoa don theo bo phan
            _Loaicaphd = CapPhatHoaDon.LaySoHoaDon(ref _sokh, ref _sohd, ERP_Library.Security.CurrentUser.Info.MaBoPhan);
            _hoaDon.SoHoaDon = _sohd;
            _hoaDon.SoSerial = _sokh;
            // if (_Loaicaphd == 1)
            //    _hoaDon.SoHoaDon = "";
        }
        public frmHoaDonDichVuBanRa(HoaDon hd)
        {
            InitializeComponent();
            KhoiTao(hd);
            if (_hoaDon.MaDoiTac == 0)
            {
                radngoaidm.Checked = true;
                _hdDOitac = HoaDon_DoiTac.GetHoaDon_DoiTacByHoaDon(_hoaDon.MaHoaDon);
                Binds_hoadon_Doitac.DataSource = _hdDOitac;
                txtu_MaSoThue.Text = _hdDOitac.MSThue;
            }
            else
            {
                radtrongdm.Checked = true;
                DoiTac doitacSelected = DoiTac.GetDoiTacForTaoHoaDonDichVu(_hoaDon.MaDoiTac);//DoiTac.GetDoiTac(_hoaDon.MaDoiTac);
                txtu_MaSoThue.Text = doitacSelected.MaSoThue;
                diaChiDoiTacListBindingSource.DataSource = doitacSelected.DiaChi_DoiTacList;
                doiTacDienThoaiFaxListBindingSource.DataSource = doitacSelected.DoiTac_DienThoai_FaxList;
            }
        }

        #region Hóa Đơn Chi Tiền Hoa Hồng
        public frmHoaDonDichVuBanRa(int loai, byte doiTuongLap)
        {
            InitializeComponent();
            KhoiTao(loai, doiTuongLap);
        }
        #endregion


        #region InitializeLayout
        public void KhoiTaoHoaDonMuaHangDichVu()
        {
            //grdu_ChiTietHoaDon.DisplayLayout.Bands[0].Columns["MaChiTiet"].Hidden = true;
            //grdu_ChiTietHoaDon.DisplayLayout.Bands[0].Columns["MaHoaDon"].Hidden = true;
            //grdu_ChiTietHoaDon.DisplayLayout.Bands[0].Columns["TienPhat"].Hidden = true;
            //grdu_ChiTietHoaDon.DisplayLayout.Bands[0].Columns["TienPhuThu"].Hidden = true;
            //grdu_ChiTietHoaDon.DisplayLayout.Bands[0].Columns["NhomHHDVMuaVao"].Hidden = true;

            //grdu_ChiTietHoaDon.DisplayLayout.Bands[0].Columns["TenHangHoaDichVu"].Header.Caption = "Hàng Hóa";
            //grdu_ChiTietHoaDon.DisplayLayout.Bands[0].Columns["TenHangHoaDichVu"].Header.VisiblePosition = 1;
            //grdu_ChiTietHoaDon.DisplayLayout.Bands[0].Columns["TenHangHoaDichVu"].Width = 200;

            //grdu_ChiTietHoaDon.DisplayLayout.Bands[0].Columns["MaDoiTac"].Header.Caption = "Đối Tác";
            //grdu_ChiTietHoaDon.DisplayLayout.Bands[0].Columns["MaDoiTac"].Header.VisiblePosition = 2;
            //grdu_ChiTietHoaDon.DisplayLayout.Bands[0].Columns["MaDoiTac"].Width = 200;
            //grdu_ChiTietHoaDon.DisplayLayout.Bands[0].Columns["MaDoiTac"].EditorComponent = DoiTac_ultraCombo; 

            //grdu_ChiTietHoaDon.DisplayLayout.Bands[0].Columns["SoLuong"].Header.Caption = "Số Lượng";
            //grdu_ChiTietHoaDon.DisplayLayout.Bands[0].Columns["SoLuong"].Header.VisiblePosition = 3;

            //grdu_ChiTietHoaDon.DisplayLayout.Bands[0].Columns["MaDonViTinh"].Hidden = true;
            //grdu_ChiTietHoaDon.DisplayLayout.Bands[0].Columns["MaDonViTinh"].Header.VisiblePosition = 4;
            //grdu_ChiTietHoaDon.DisplayLayout.Bands[0].Columns["MaDonViTinh"].EditorComponent = cmbu_DonViTinh;

            //grdu_ChiTietHoaDon.DisplayLayout.Bands[0].Columns["DonGia"].Header.Caption = "Đơn Giá";
            //grdu_ChiTietHoaDon.DisplayLayout.Bands[0].Columns["DonGia"].Width = 150;
            //grdu_ChiTietHoaDon.DisplayLayout.Bands[0].Columns["DonGia"].Header.VisiblePosition = 5;
            //grdu_ChiTietHoaDon.DisplayLayout.Bands[0].Columns["DonGia"].Format = "#,###";

            //grdu_ChiTietHoaDon.DisplayLayout.Bands[0].Columns["ThanhTien"].Header.Caption = "Tổng Tiền";
            //grdu_ChiTietHoaDon.DisplayLayout.Bands[0].Columns["ThanhTien"].Width = 200;
            //grdu_ChiTietHoaDon.DisplayLayout.Bands[0].Columns["ThanhTien"].Header.VisiblePosition = 6;
            //grdu_ChiTietHoaDon.DisplayLayout.Bands[0].Columns["ThanhTien"].CellActivation = Activation.AllowEdit;
            //grdu_ChiTietHoaDon.DisplayLayout.Bands[0].Columns["ThanhTien"].Format = "#,###";

            //grdu_ChiTietHoaDon.DisplayLayout.Bands[0].Columns["GhiChu"].Header.Caption = "Ghi Chú";
            //grdu_ChiTietHoaDon.DisplayLayout.Bands[0].Columns["GhiChu"].Width = 150;
            //grdu_ChiTietHoaDon.DisplayLayout.Bands[0].Columns["GhiChu"].Header.VisiblePosition = 7;

            ////grdu_ChiTietHoaDon.DisplayLayout.Bands[0].Columns["NhomHHDVMuaVao"].Header.Caption = "Nhóm HHDV mua vào";
            ////grdu_ChiTietHoaDon.DisplayLayout.Bands[0].Columns["NhomHHDVMuaVao"].Width = 150;
            ////grdu_ChiTietHoaDon.DisplayLayout.Bands[0].Columns["NhomHHDVMuaVao"].Header.VisiblePosition = 8;
            ////grdu_ChiTietHoaDon.DisplayLayout.Bands[0].Columns["NhomHHDVMuaVao"].EditorComponent = NhomHHDVMuaVao_ultraCombo;



            //this.grdu_ChiTietHoaDon.DisplayLayout.Override.HeaderStyle = HeaderStyle.WindowsXPCommand;
            //this.grdu_ChiTietHoaDon.DisplayLayout.Override.HeaderAppearance.BackColor = System.Drawing.Color.SteelBlue;
            //foreach (UltraGridColumn col in this.grdu_ChiTietHoaDon.DisplayLayout.Bands[0].Columns)
            //{
            //    col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
            //    col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
            //    col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;//x =  //= System.Drawing.w;//RoyalBlue
            //}
        }

        private void cbo_khnhap_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            cbo_khnhap.DisplayLayout.Bands[0].Columns["Id"].Hidden = true;
            cbo_khnhap.DisplayLayout.Bands[0].Columns["MaHoaDon"].Hidden = true;
            cbo_khnhap.DisplayLayout.Bands[0].Columns["DiaChi"].Hidden = true;
            cbo_khnhap.DisplayLayout.Bands[0].Columns["MSThue"].Hidden = true;
            cbo_khnhap.DisplayLayout.Bands[0].Columns["NguoiLienHe"].Hidden = true;
            cbo_khnhap.DisplayLayout.Bands[0].Columns["DienThoai"].Hidden = true;
            cbo_khnhap.DisplayLayout.Bands[0].Columns["TenDoiTac"].Header.Caption = "Tên Đối Tác";
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
            cmbu_KhachHang.DisplayLayout.Bands[0].Columns["MaQLDoiTac"].Header.Caption = "Mã KH";
            cmbu_KhachHang.DisplayLayout.Bands[0].Columns["MaQLDoiTac"].Width = 80;

            cmbu_KhachHang.DisplayLayout.Bands[0].Columns["TenDoitac"].Header.Caption = "Tên Khách Hàng";
            cmbu_KhachHang.DisplayLayout.Bands[0].Columns["TenDoitac"].Width = 150;

            cmbu_KhachHang.DisplayLayout.Bands[0].Columns["TenVietTat"].Header.Caption = "Tên Viết Tắt";
            cmbu_KhachHang.DisplayLayout.Bands[0].Columns["TenVietTat"].Width = 80;

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

        private void grdu_ChiTietHoaDon_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            hamDungChung.ultragrdEmail_InitializeLayout(sender, e);
        }

        private void cmbu_DonViTinh_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            cmbu_DonViTinh.DisplayLayout.Override.HeaderAppearance.BackColor = Color.SteelBlue;
            this.cmbu_DonViTinh.DisplayLayout.Override.HeaderStyle = HeaderStyle.WindowsXPCommand;

            foreach (UltraGridColumn col in this.cmbu_DonViTinh.DisplayLayout.Bands[0].Columns)
            {
                col.Hidden = true;
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = Color.Navy;
            }

            cmbu_DonViTinh.DisplayLayout.Bands[0].Columns["MaQuanLy"].Hidden = false;
            cmbu_DonViTinh.DisplayLayout.Bands[0].Columns["MaQuanLy"].Header.Caption = "Mã DVT";
            cmbu_DonViTinh.DisplayLayout.Bands[0].Columns["MaQuanLy"].Header.VisiblePosition = 0;

            cmbu_DonViTinh.DisplayLayout.Bands[0].Columns["TenDonViTinh"].Hidden = false;
            cmbu_DonViTinh.DisplayLayout.Bands[0].Columns["TenDonViTinh"].Header.Caption = "Tên Đơn Vị Tính";
            cmbu_DonViTinh.DisplayLayout.Bands[0].Columns["TenDonViTinh"].Header.VisiblePosition = 1;
        }


        #endregion

        #region KhoiTao

        private void LoadDataPhuongThucThanhToanList()
        {
            _phuongthucthanhtoanList = PhuongThucThanhToanList.GetPhuongThucThanhToanList();
            PhuongThucThanhToan pttt = PhuongThucThanhToan.NewPhuongThucThanhToan();
            pttt.MaQuanLyPTTT = "TM/CK";
            pttt.TenPhuongThucThanhToan = "TM/CK";
            _phuongthucthanhtoanList.Insert(0, pttt);
            phuongThucThanhToanListBindingSource.DataSource = _phuongthucthanhtoanList;
        }
        private void InitForm()
        {

            hoaDonbindingSource.DataSource = typeof(HoaDon);
            doiTacListBindingSource.DataSource = typeof(DoiTacList);
            phuongThucThanhToanListBindingSource.DataSource = typeof(PhuongThucThanhToanList);
            donViTinhListBindingSource.DataSource = typeof(DonViTinhList);
            kyListBindingSource.DataSource = typeof(KyList);
            Binds_hoadon_Doitac.DataSource = typeof(HoaDon_DoiTacList);
            mauHDBindingSource.DataSource = typeof(DanhMucMauHoaDonList);
        }

        private void LoadDoiTacList()
        {
            _DoiTacList = DoiTacList.GetDoiTacListByTen(0);
            DoiTac _DoiTac = DoiTac.NewDoiTac(0, "Không Chọn...");
            _DoiTacList.Insert(0, _DoiTac);
            doiTacListBindingSource.DataSource = _DoiTacList;
        }

        private void KhoiTao()
        {
            InitForm();
            DanhMucMauHoaDonList danhMucMauHoaDonList = DanhMucMauHoaDonList.GetDanhMucMauHoaDonList();
            mauHDBindingSource.DataSource = danhMucMauHoaDonList;

            LoadDataPhuongThucThanhToanList();
            LoadDoiTacList();

            donViTinhListBindingSource.DataSource = DonViTinhList.GetDonViTinhList();
            
        }
        private void KhoiTao(long maDoiTac)
        {
            InitForm();
            DanhMucMauHoaDonList danhMucMauHoaDonList = DanhMucMauHoaDonList.GetDanhMucMauHoaDonList();
            mauHDBindingSource.DataSource = danhMucMauHoaDonList;
            LoadDataPhuongThucThanhToanList();
            _DoiTacList = DoiTacList.GetDoiTacListByTen(0);

            DoiTac _DoiTac = DoiTac.NewDoiTac(0, "Thêm Mới...");
            _DoiTacList.Insert(0, _DoiTac);

            doiTacListBindingSource.DataSource = _DoiTacList;

            donViTinhListBindingSource.DataSource = DonViTinhList.GetDonViTinhList();
            cmbu_KhachHang.Value = maDoiTac;
           
        }
        private void KhoiTao(int loai, byte doiTuongLap)
        {
            InitForm();
            DanhMucMauHoaDonList danhMucMauHoaDonList = DanhMucMauHoaDonList.GetDanhMucMauHoaDonList();
            mauHDBindingSource.DataSource = danhMucMauHoaDonList;
            ThemMoi();
            LoadDataPhuongThucThanhToanList();
            doiTacListBindingSource.DataSource = DoiTacList.GetDoiTacListTheoKhachHangDaiLy(doiTuongLap);
            kyListBindingSource.DataSource = KyList.GetKyList();
            _hoaDon.LoaiHoaDon = loai;
            cmbu_LoaiHoaDon.Enabled = false;
            pn_HoaDonHoaHong.Visible = true;
        }
        public void KhoiTao(HoaDon hd)
        {
            InitForm();
            DanhMucMauHoaDonList danhMucMauHoaDonList = DanhMucMauHoaDonList.GetDanhMucMauHoaDonList();
            mauHDBindingSource.DataSource = danhMucMauHoaDonList;
            _hoaDon = hd;
            LoadDataPhuongThucThanhToanList();
            LoadDoiTacList();
            //doiTacListBindingSource.DataSource = DoiTacList.GetDoiTacList(_hoaDon.MaDoiTac);
            donViTinhListBindingSource.DataSource = DonViTinhList.GetDonViTinhList();
            hoaDonbindingSource.DataSource = _hoaDon;
            KhoiTaoHoaDonMuaHangDichVu();

        }

        #endregion//KhoiTao

        #region ThemMoi
        private void SetDefaultMauHoaDon_KyHieuHoaDon()
        {
            if (_hoaDon.IsNew)
            {
                foreach (TaiKhoanThue tkThue in TaiKhoanThue.TaiKhoanThueList)
                {
                    if (tkThue.MauHoaDon != "")
                    {
                        _hoaDon.MauHoaDon = tkThue.MauHoaDon;
                        _hoaDon.KyHieuMauHoaDon = tkThue.MauHoaDon + "/" + tkThue.KyHieuHoaDon;
                        _KyHieuMauHoaDon = tkThue.KyHieuHoaDon;
                        break;
                    }
                }
                _hoaDon.LoaiHoaDon = _loaihd;
                _Loaicaphd = CapPhatHoaDon.LaySoHoaDon(ref _sokh, ref _sohd, ERP_Library.Security.CurrentUser.Info.MaBoPhan);
                _hoaDon.SoHoaDon = _sohd;
                _hoaDon.SoSerial = _sokh;
            }
        }

        private void ThemMoi()
        {
            _hoaDon = HoaDon.NewHoaDon();
            SetDefaultMauHoaDon_KyHieuHoaDon();
            KhoiTaoHoaDonMuaHangDichVu();

            _hoaDon.LoaiHoaDon = _loaihd;
            _hoaDon.MaHinhThucTT = 1;
            hoaDonbindingSource.DataSource = _hoaDon;
            cTHoaDonDichVuListBindingSource.DataSource = _hoaDon.CT_HoaDonDichVuList;
            txt_SoHoaDon.Focus();

            this.strIDChungTu = "";
        }

        private void ThemMoi(ButToan buttoan, string tenDoiTuong, decimal sotienChungtu, int phuongthucthanhtoan)
        {
            _hoaDon = HoaDon.NewHoaDon();
            SetDefaultMauHoaDon_KyHieuHoaDon();
            KhoiTaoHoaDonMuaHangDichVu();

            _hoaDon.LoaiHoaDon = _loaihd;
            _hoaDon.MaHinhThucTT = phuongthucthanhtoan;
            radngoaidm.Checked = true;
            #region Hoadon_DoiTac
            if (_hdDOitac == null)
            {
                _hdDOitac = HoaDon_DoiTac.NewHoaDon_DoiTac();
            }
            _hdDOitac.TenDoiTac = tenDoiTuong;
            Binds_hoadon_Doitac.DataSource = _hdDOitac;
            #endregion//HoaDon_DoiTac
            //Tao CT_HoaDonDichVu
            CT_HoaDonDichVu ct_dichvu = CT_HoaDonDichVu.NewCT_HoaDonDichVu();
            ct_dichvu.TenHangHoaDichVu = buttoan.DienGiai;
            ct_dichvu.SoLuong = 1;
            ct_dichvu.DonGia = buttoan.SoTien;
            ct_dichvu.ThanhTien = buttoan.SoTien;
            ct_dichvu.MaButToan = buttoan.MaButToan;
            _hoaDon.CT_HoaDonDichVuList.Add(ct_dichvu);
            //ChungTu_HoaDon
            ChungTu_HoaDon ct_hd = ChungTu_HoaDon.NewChungTu_HoaDon();
            ct_hd.MaButToan = buttoan.MaButToan;
            ct_hd.SoTien = buttoan.SoTien;
            _hoaDon.Chungtu_HoaDonList.Add(ct_hd);
            //Tinh Thue Suat
            _hoaDon.ThanhTien = sotienChungtu - buttoan.SoTien;
            if (buttoan.SoTien > 0)
            {
                double thuesuat = 0;
                thuesuat = (double)((sotienChungtu - buttoan.SoTien) / buttoan.SoTien);
                if (thuesuat < 3)
                {
                    _hoaDon.ThueSuatVAT = 0;
                }
                else if (thuesuat < 8)
                {
                    _hoaDon.ThueSuatVAT = 5;
                }
                else
                {
                    _hoaDon.ThueSuatVAT = 10;
                }
            }
            _hoaDon.TongTien = sotienChungtu;


            hoaDonbindingSource.DataSource = _hoaDon;
            cTHoaDonDichVuListBindingSource.DataSource = _hoaDon.CT_HoaDonDichVuList;
            txt_SoHoaDon.Focus();
        }

        private void ThemMoi(ChungTu chungtu)
        {
            _hoaDon = HoaDon.NewHoaDon();
            SetDefaultMauHoaDon_KyHieuHoaDon();
            KhoiTaoHoaDonMuaHangDichVu();

            _hoaDon.LoaiHoaDon = _loaihd;
            _hoaDon.MaHinhThucTT = chungtu.MaPhuongThucThanhToan;
            if (chungtu.DoiTuong != 0)
            {
                radtrongdm.Checked = true;
                radngoaidm.Checked = false;
                _hoaDon.MaDoiTac = chungtu.DoiTuong;
            }
            else
            {
                radtrongdm.Checked = false;
                radngoaidm.Checked = true;
                #region Hoadon_DoiTac
                if (_hdDOitac == null)
                {
                    _hdDOitac = HoaDon_DoiTac.NewHoaDon_DoiTac();
                }
                _hdDOitac.TenDoiTac = chungtu.ChungTu_DiaChi.Ten;
                Binds_hoadon_Doitac.DataSource = _hdDOitac;
                #endregion//HoaDon_DoiTac
            }
            decimal tongtien = _hoaDon.ThanhTien;

            string strIDButToan = "";
            decimal soTien = 0;
            string dienGiai = "";
            long maDoiTac = 0;
            int intIDKhoanMuc = 0;
            foreach (ButToan itembuttoan in chungtu.DinhKhoan.ButToan)
            {
                //gom lai theo noi dung & doi tuong
                dienGiai = itembuttoan.DienGiai + "";
                maDoiTac = itembuttoan.DoiTuongCo;
                soTien = 0;
                intIDKhoanMuc = itembuttoan.IDKhoanMuc;
                foreach (ButToan iButToan in chungtu.DinhKhoan.ButToan)
                {
                    if (strIDButToan.Contains(iButToan.MaButToan + ""))
                    {
                        continue;
                    }

                    //group theo IDkhoanmuc
                    if (intIDKhoanMuc == iButToan.IDKhoanMuc && maDoiTac == iButToan.DoiTuongCo)
                    {
                        soTien = soTien + iButToan.SoTien;
                        strIDButToan = strIDButToan + iButToan.MaButToan + ",";
                    }

                    ////group theo diengiai
                    //if (dienGiai.Equals(iButToan.DienGiai) && maDoiTac == iButToan.DoiTuongCo)
                    //{
                    //    soTien = soTien + iButToan.SoTien;
                    //    strIDButToan = strIDButToan + iButToan.MaButToan + ",";
                    //}
                }

                if (soTien > 0)
                {
                    CT_HoaDonDichVu ct_dichvu = CT_HoaDonDichVu.NewCT_HoaDonDichVu();
                    ct_dichvu.TenHangHoaDichVu = dienGiai;
                    ct_dichvu.SoLuong = 1;
                    ct_dichvu.DonGia = soTien;
                    ct_dichvu.ThanhTien = soTien;
                    ct_dichvu.MaButToan = itembuttoan.MaButToan;
                    ct_dichvu.MaChungTu = chungtu.MaChungTu;
                    ct_dichvu.MaDoiTac = maDoiTac;
                    _hoaDon.CT_HoaDonDichVuList.Add(ct_dichvu);
                    //ChungTu_HoaDonThanhToan
                    ChungTu_HoaDonThanhToan ct_hd = ChungTu_HoaDonThanhToan.NewChungTu_HoaDonThanhToan();
                    ct_hd.MaChungTu = chungtu.MaChungTu;
                    ct_hd.MaButToan = itembuttoan.MaButToan;
                    ct_hd.SoTienThanhToan = soTien; //chungtu.Tien.ThanhTien;
                    _hoaDon.ChungTu_HoaDonThanhToanList.Add(ct_hd);
                }
                tongtien += itembuttoan.SoTien;

                ////Tao CT_HoaDonDichVu
                //CT_HoaDonDichVu ct_dichvu = CT_HoaDonDichVu.NewCT_HoaDonDichVu();
                //ct_dichvu.TenHangHoaDichVu = itembuttoan.DienGiai;
                //ct_dichvu.SoLuong = 1;
                //ct_dichvu.DonGia = itembuttoan.SoTien;
                //ct_dichvu.ThanhTien = itembuttoan.SoTien;
                //ct_dichvu.MaButToan = itembuttoan.MaButToan;
                //ct_dichvu.MaChungTu = chungtu.MaChungTu;
                //ct_dichvu.MaDoiTac = itembuttoan.DoiTuongCo;
                //_hoaDon.CT_HoaDonDichVuList.Add(ct_dichvu);
                ////ChungTu_HoaDonThanhToan
                //ChungTu_HoaDonThanhToan ct_hd = ChungTu_HoaDonThanhToan.NewChungTu_HoaDonThanhToan();
                //ct_hd.MaChungTu = chungtu.MaChungTu;
                //ct_hd.MaButToan = itembuttoan.MaButToan;
                //ct_hd.SoTienThanhToan = itembuttoan.SoTien; //chungtu.Tien.ThanhTien;
                //_hoaDon.ChungTu_HoaDonThanhToanList.Add(ct_hd);
                //tongtien += itembuttoan.SoTien;
            }
            //
            #region Item ChungTu
            //CT_HoaDonDichVu ct_dichvu = CT_HoaDonDichVu.NewCT_HoaDonDichVu();
            //ct_dichvu.TenHangHoaDichVu = chungtu.DienGiai;
            //ct_dichvu.SoLuong = 1;
            //ct_dichvu.DonGia = chungtu.SoTien;
            //ct_dichvu.ThanhTien = chungtu.SoTien;
            //ct_dichvu.MaChungTu = chungtu.MaChungTu;
            //_hoaDon.CT_HoaDonDichVuList.Add(ct_dichvu);
            #endregion Item ChungTu

            _hoaDon.ThanhTien += tongtien;
            //_hoaDon.TongTien = chungtu.Tien.ThanhTien;
            _hoaDon.KhauTruThue = true;
            _hoaDon.ThueSuatVAT = -1;

            hoaDonbindingSource.DataSource = _hoaDon;
            cTHoaDonDichVuListBindingSource.DataSource = _hoaDon.CT_HoaDonDichVuList;
            txt_SoHoaDon.Focus();
        }


        private void ThemMoi(long madt)
        {
            _hoaDon = HoaDon.NewHoaDon();
            SetDefaultMauHoaDon_KyHieuHoaDon();
            hoaDonbindingSource.DataSource = _hoaDon;
            cTHoaDonDichVuListBindingSource.DataSource = _hoaDon.CT_HoaDonDichVuList;
            KhoiTaoHoaDonMuaHangDichVu();

            _hoaDon.LoaiHoaDon = _loaihd;
            _hoaDon.MaDoiTac = madt;
            _hoaDon.MaHinhThucTT = 1;
            txt_SoHoaDon.Focus();



        }
        private void ThemMoi(int loai)
        {
            _hoaDon = HoaDon.NewHoaDon();
            SetDefaultMauHoaDon_KyHieuHoaDon();
            _hoaDon.LoaiHoaDon = loai;
            hoaDonbindingSource.DataSource = _hoaDon;
            cTHoaDonDichVuListBindingSource.DataSource = _hoaDon.CT_HoaDonDichVuList;
            _hdDOitac = HoaDon_DoiTac.NewHoaDon_DoiTac();
            Binds_hoadon_Doitac.DataSource = _hdDOitac;
            _hoaDon.MaHinhThucTT = 1;
            _hoaDon.LoaiHoaDon = loai;
            KhoiTaoHoaDonMuaHangDichVu();
        }
        #endregion//ThemMoi

        #region Event
        private void radtrongdm_CheckedChanged(object sender, EventArgs e)
        {
            LoadKhachHang();
        }

        private void radngoaidm_CheckedChanged(object sender, EventArgs e)
        {
            LoadKhachHang();
        }

        private void luuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            gridControl1.Update();
            if (KiemTraDuLieu() == true)
            {
                if (LuuDuLieu() == true)
                    MessageBox.Show(this, util.thanhcong, util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void thêmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (
               _hoaDon.IsNew == false
               &&
               !PublicClass.KiemTraIsHoaDonBiHuy(_hoaDon.MaHoaDon)
               &&
               PublicClass.KiemTraHoaDonDaLapChungTuKeToan(_hoaDon.MaHoaDon) == 0
               )
            {
                //MessageBox.Show("Vui Lòng lập Chứng Từ Kế Toán Cho Hóa Đơn!", "Yêu Cầu");
                //return;
            }

            cbo_khnhap.Text = "";
            if (maDoiTac == 0) // truong hop nhap tu do
                ThemMoi();
            else
                ThemMoi(maDoiTac);
            _hoaDon.LoaiHoaDon = 5;
            // Lay so hoa don theo bo phan
            _Loaicaphd = CapPhatHoaDon.LaySoHoaDon(ref _sokh, ref _sohd, ERP_Library.Security.CurrentUser.Info.MaBoPhan);
            _hoaDon.SoHoaDon = _sohd;
            _hoaDon.SoSerial = _sokh;
            _hoaDon.MaHinhThucTT = 0;
        }

        private void grdu_ChiTietHoaDon_AfterCellUpdate(object sender, CellEventArgs e)
        {
            #region Old
            //Decimal _tongTien = 0;
            //if (grdu_ChiTietHoaDon.ActiveRow.Cells["SoLuong"].IsActiveCell == true || grdu_ChiTietHoaDon.ActiveRow.Cells["DonGia"].IsActiveCell == true)
            //{
            //    if (_hoaDon.LoaiHoaDon == 5)
            //    {
            //        grdu_ChiTietHoaDon.ActiveRow.Cells["ThanhTien"].Value = Convert.ToInt32(grdu_ChiTietHoaDon.ActiveRow.Cells["SoLuong"].Value) * Convert.ToDecimal(grdu_ChiTietHoaDon.ActiveRow.Cells["DonGia"].Value);

            //        foreach (CT_HoaDonDichVu ct_HoaDonDichVu in _hoaDon.CT_HoaDonDichVuList)
            //        {
            //            _tongTien = _tongTien + ct_HoaDonDichVu.ThanhTien;
            //        }
            //        _hoaDon.ThanhTien = _tongTien;
            //    }
            //} 
            #endregion old

            #region Modify
            //Decimal _tongTien = 0;
            //if (grdu_ChiTietHoaDon.ActiveRow.Cells["ThanhTien"].IsActiveCell == true || grdu_ChiTietHoaDon.ActiveRow.Cells["SoLuong"].IsActiveCell == true || grdu_ChiTietHoaDon.ActiveRow.Cells["DonGia"].IsActiveCell == true)
            //{
            //    if (_hoaDon.LoaiHoaDon == 5)
            //    {
            //        foreach (CT_HoaDonDichVu ct_HoaDonDichVu in _hoaDon.CT_HoaDonDichVuList)
            //        {
            //            _tongTien = _tongTien + ct_HoaDonDichVu.ThanhTien;
            //        }
            //        _hoaDon.ThanhTien = _tongTien;

            //        hoaDonbindingSource.DataSource = _hoaDon;
            //    }
            //} 
            #endregion Modify

        }

        private void tlslblThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tlSBtnBienLai_Click(object sender, EventArgs e)
        {
            bool duoclap = true;
            if (_hoaDon.IsNew == false)
            {
                if (MessageBox.Show("Việc này sẽ tạo Hóa đơn mới. Bạn có muốn tiếp tục?", "Xác Nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    duoclap = false;
                }
            }
            if (duoclap)
            {
                LapHoaDonFromBienLai();
            }
        }

        private void tlSbtnLapTuPhieuThu_Click(object sender, EventArgs e)
        {
            bool duoclap = true;
            if (_hoaDon.IsNew == false)
            {
                if (MessageBox.Show("Việc này sẽ tạo Hóa đơn mới. Bạn có muốn tiếp tục?", "Xác Nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    duoclap = false;
                }
            }
            if (duoclap)
            {
                //LapHoaDonFromButToanThuePhaiNop();
                //LapHoaDonBanRaFromChungTu();
                //LapHoaDonBanRaFromChungTu_GroupByDienGiai();

                LapHoaDonBanRaFromChungTu_GroupByIDKhoanMuc();
            }
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

        private void tlsIn_Click(object sender, EventArgs e)
        {
            InHoaDonGTGTBanRa_Dev();
            //InHDBanRa(1);
        }

        private void cmbe_ThueVAT_ValueChanged(object sender, EventArgs e)
        {
            //MessageBox.Show("fhfghfghgfhgfhfgh");
        }

        private void cmbu_KhachHang_AfterCloseUp(object sender, EventArgs e)
        {
            long ma = 0;
            if (cmbu_KhachHang.ActiveRow != null)
            {
                if (cmbu_KhachHang.Text == "Thêm Mới...")
                {
                    frmKhachHangCustomize _frmKhachHang = new frmKhachHangCustomize();
                    if (_frmKhachHang.ShowDialog() != DialogResult.OK)
                    {
                        _DoiTacList = DoiTacList.GetDoiTacListByTen(0);
                        DoiTac _DoiTac = DoiTac.NewDoiTac(0, "Thêm Mới...");
                        _DoiTacList.Insert(0, _DoiTac);
                        ma = _DoiTacList[_DoiTacList.Count - 1].MaDoiTac;
                        cmbu_KhachHang.Value = ma;
                        //
                        DoiTac doitacSelected = DoiTac.GetDoiTacForTaoHoaDonDichVu(ma);// DoiTac.GetDoiTac(ma);//BS
                        txtu_MaSoThue.Text = doitacSelected.MaSoThue;//BS
                        diaChiDoiTacListBindingSource.DataSource = doitacSelected.DiaChi_DoiTacList; //DoiTac.GetDoiTac(ma).DiaChi_DoiTacList;
                        doiTacDienThoaiFaxListBindingSource.DataSource = doitacSelected.DoiTac_DienThoai_FaxList;//DoiTac.GetDoiTac(ma).DoiTac_DienThoai_FaxList;
                        doiTacListBindingSource.DataSource = _DoiTacList;
                    }
                }
            }
        }





        private void cmbu_KhachHang_ValueChanged(object sender, EventArgs e)
        {
            if (cmbu_KhachHang.ActiveRow != null)
            {
                if (cmbu_KhachHang.Text != "Thêm Mới...")
                {
                    long maDoiTac = 0;
                    long.TryParse(cmbu_KhachHang.Value.ToString(), out maDoiTac);

                    if (maDoiTac != 0)
                    {
                        DoiTac doitacSelected = DoiTac.GetDoiTacForTaoHoaDonDichVu(maDoiTac); //DoiTac.GetDoiTac((long)cmbu_KhachHang.Value);
                        txtu_MaSoThue.Text = doitacSelected.MaSoThue; //(Convert.ToString(KhachHang.GetKhachHang((long)cmbu_KhachHang.Value)));
                        diaChiDoiTacListBindingSource.DataSource = doitacSelected.DiaChi_DoiTacList; //DoiTac.GetDoiTac((long)cmbu_KhachHang.Value).DiaChi_DoiTacList;
                        doiTacDienThoaiFaxListBindingSource.DataSource = doitacSelected.DoiTac_DienThoai_FaxList;//DoiTac.GetDoiTac((long)cmbu_KhachHang.Value).DoiTac_DienThoai_FaxList;
                        
                        if (doitacSelected.DiaChi_DoiTacList.Count > 0)
                        {
                            _hoaDon.MaDCGuiHD = doitacSelected.DiaChi_DoiTacList[0].MaChiTiet;
                            //cmb_DiaChi.SelectedValue = doitacSelected.DiaChi_DoiTacList[0].MaChiTiet;                            
                        }
                        _hoaDon.MaDoiTac = maDoiTac;
                    }
                }
            }
        }

        private void cmbeu_TinhTrang_Leave(object sender, EventArgs e)
        {
            if (cmbeu_TinhTrang.Value != null)
            {
                Int16 tinhtranghd = 0;
                if (Int16.TryParse(cmbeu_TinhTrang.Value.ToString(), out tinhtranghd))
                {
                    if (tinhtranghd == 0)//Chưa Thanh Toan
                    {
                        _hoaDon.SoTienDaThanhToan = 0;
                        _hoaDon.SoTienConLai = _hoaDon.TongTien;
                    }
                    else if (tinhtranghd == 1)//Đã Thanh Toan đủ
                    {
                        _hoaDon.SoTienDaThanhToan = _hoaDon.TongTien;
                        _hoaDon.SoTienConLai = 0;
                    }
                    else if (tinhtranghd == 2)//Đã Thanh Toan đủ
                    {
                        _hoaDon.SoTienDaThanhToan = 0;
                        _hoaDon.SoTienConLai = 0;
                    }
                    hoaDonbindingSource.DataSource = _hoaDon;
                }
            }
        }

        private void cmbu_MauHD_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            HamDungChung.Combobox_InitializeLayout(sender, e);
            FilterCombo f = new FilterCombo(cmbu_MauHD, "MaQuanLy");
            foreach (UltraGridColumn col in this.cmbu_MauHD.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;
                col.Hidden = true;
                if (col.DataType == typeof(decimal))
                {
                    col.CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                }
            }
            cmbu_MauHD.DisplayLayout.Bands[0].Columns["MaQuanLy"].Hidden = false;
            cmbu_MauHD.DisplayLayout.Bands[0].Columns["MaQuanLy"].Header.Caption = "Mã Hóa Đơn";
            cmbu_MauHD.DisplayLayout.Bands[0].Columns["MaQuanLy"].Header.VisiblePosition = 0;
            cmbu_MauHD.DisplayLayout.Bands[0].Columns["MaQuanLy"].Width = 100;

            cmbu_MauHD.DisplayLayout.Bands[0].Columns["TenLoaiHoaDon"].Hidden = false;
            cmbu_MauHD.DisplayLayout.Bands[0].Columns["TenLoaiHoaDon"].Header.Caption = "Tên Loại Hóa Đơn";
            cmbu_MauHD.DisplayLayout.Bands[0].Columns["TenLoaiHoaDon"].Header.VisiblePosition = 2;
            cmbu_MauHD.DisplayLayout.Bands[0].Columns["TenLoaiHoaDon"].Width = 300;
        }

        private void cmbu_MauHD_ValueChanged(object sender, EventArgs e)
        {
            if (_hoaDon != null && cmbu_MauHD.Value != null)
            {
                if (capNhatHoaDon || _hoaDon.IsNew)
                {
                    _hoaDon.MauHoaDon = Convert.ToString(cmbu_MauHD.Value).Trim();
                    _hoaDon.KyHieuMauHoaDon = Convert.ToString(cmbu_MauHD.Value).Trim() + "/" + _KyHieuMauHoaDon;
                }

            }
            capNhatHoaDon = false;
        }

        private void cmbu_MauHD_MouseClick(object sender, MouseEventArgs e)
        {
            capNhatHoaDon = true;
        }

        private void cb_LoaiHD_CheckedChanged(object sender, EventArgs e)
        {
            if (cb_LoaiHD.Checked == true)
            {
                _hoaDon.ThueSuatVAT = -1;
            }
        }

        private void tlSbtnlapChungTuKeToan_Click(object sender, EventArgs e)
        {
            if (_hoaDon.IsNew == true)
            {
                MessageBox.Show("Vui lòng cập nhật Hóa đơn trước khi lập Chứng từ kế toán?", "Yêu Cầu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            LapChungTuKeToanTuHoaDon();
        }

        #endregion

        #region Process
        private void InHDBanRa(int macongty)
        {
            ReportDocument Report = new Report.Thue.Report_HoaDonDichVu();
            DataSet dataset = new DataSet();
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.StoredProcedure;

            command.CommandText = "spd_REPORT_ReportHeader";
            command.Parameters.AddWithValue("@macongty", macongty);
            command.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            table.TableName = "spd_REPORT_ReportHeader;1";

            SqlCommand command1 = new SqlCommand();
            command1.CommandType = CommandType.StoredProcedure;
            command1.CommandText = "Report_HoaDonDichVu";
            command1.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);
            command1.Parameters.AddWithValue("@mahoadon", _hoaDon.MaHoaDon);

            SqlDataAdapter adapter1 = new SqlDataAdapter(command1);
            DataTable table1 = new DataTable();
            adapter1.Fill(table1);
            table1.TableName = "Report_HoaDonDichVu;1";

            dataset.Tables.Add(table);
            dataset.Tables.Add(table1);


            Report.SetDataSource(dataset);
            frmHienThiReport dlg = new frmHienThiReport();
            dlg.crytalView_HienThiReport.ReportSource = Report;
            dlg.Show();
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
                _hdDOitac = null;
            }
            else
            {
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
                _hdDOitac = HoaDon_DoiTac.NewHoaDon_DoiTac();
                Binds_hoadon_Doitac.DataSource = _hdDOitac;
            }
        }
        private bool LuuDuLieu()
        {
            bool kq = true;
            try
            {
                if (_hoaDon.CT_HoaDonDichVuList.Count > 0)
                {
                    _hoaDon.NhomHHDVMuaVao = 0;
                }
                else
                {
                    if (_hoaDon.KhauTruThue == true)
                        _hoaDon.NhomHHDVMuaVao = 4;
                    else
                        _hoaDon.NhomHHDVMuaVao = 3;
                }

                if (chkKhongTongHopTrenToKhai.Checked == true)
                    _hoaDon.NhomHHDVMuaVao = 5;
                else
                    _hoaDon.NhomHHDVMuaVao = 0;

                _hoaDon.VietBangChu = HamDungChung.DocTien(_hoaDon.TongTien);
                hoaDonbindingSource.EndEdit();
                _hoaDon.ApplyEdit();
                _hoaDon.Save();
                // Luu Khach Hang moi

                Binds_hoadon_Doitac.EndEdit();
                if (_hdDOitac != null)
                {
                    _hdDOitac.MaHoaDon = _hoaDon.MaHoaDon;
                    _hdDOitac.TenDoiTac = cbo_khnhap.Text;
                    _hdDOitac.NguoiLienHe = cbo_nguoillnhap.Text;
                    _hdDOitac.MSThue = txtu_MaSoThue.Text;
                    _hdDOitac.DiaChi = cbo_diachinhap.Text;
                    _hdDOitac.DienThoai = cbo_dtnhap.Text;
                    _hdDOitac.Save();
                    _HoaDonListDichVu.Add(_hoaDon);
                }
                if (_hoaDonList.Count != 0)
                {
                    _hoaDonList.ApplyEdit();
                    _hoaDonList.Save();
                }
            }
            catch (Exception ex)
            {
                //kq = false;
            }
            return kq;
        }
        private bool KiemtratrungsoHD(string sohd, string kyhieu, bool edit) // mo hoa don len sua
        {
            bool ketqua = true;
            if (edit)
            {
                if (CapPhatHoaDon.KiemTraSoHoaDon(sohd, kyhieu) != 0)
                    ketqua = true;
                else
                    ketqua = false;
            }
            else
            {
                if (CapPhatHoaDon.KiemTraSoHoDonSua(sohd, kyhieu, _hoaDon.MaHoaDon) == 1)
                    ketqua = true;
                else
                    ketqua = false;
            }
            return ketqua;
        }
        private bool KiemTraDuLieu()
        {
            bool kq = true;
            if (_hoaDon.SoHoaDon == string.Empty)
            {
                MessageBox.Show(this, util.sohoadon, util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_SoHoaDon.Focus();
                kq = false;
            }

            //else if (_hoaDon.SoSerial == string.Empty)
            //{
            //    MessageBox.Show(this, util.soserial, util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    txt_SoSerial.Focus();
            //    kq = false;
            //}
            else if (_hoaDon.MaDoiTac == 0 && radtrongdm.Checked)
            {
                MessageBox.Show(this, util.nhaptenkhachhang, util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbu_KhachHang.Focus();
                kq = false;
            }
            else if (cmb_HinhThucTT.Text == "")
            {
                MessageBox.Show(this, "Chưa Chọn Phương Thức Thanh Toán", util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmb_HinhThucTT.Focus();
                kq = false;
            }
            else if (KiemtratrungsoHD(_hoaDon.SoHoaDon, _hoaDon.SoSerial, _hoaDon.IsNew))
            {
                MessageBox.Show(this, "Hóa Đơn Bị Trùng Số", util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_SoHoaDon.Focus();
                kq = false;
            }
            else if (_hoaDon.CT_HoaDonDichVuList.Count > 10)
            {
                MessageBox.Show(this, "Chi tiết vượt quá 10, không hợp lệ! ", util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                kq = false;
            }
            // Kiem tra so hoa don nam trong day cho phep
            return kq;
        }


        #region Devexpress
        private void InHoaDonGTGTBanRa_Dev()
        {
            //BEGIN
            ReportTemplate _report = ReportTemplate.GetReportTemplate("ID_Report_HoaDonGTGTBanRa"); ;

            if (_report != null)
            {
                DateTime dtDenNgay = DateTime.Today;
                frmReport frm = new frmReport();

                ReportTemplate _reportTemplate = ReportTemplate.GetReportTemplate(_report.Id, UserId, dtDenNgay);
                if (_reportTemplate.Id == string.Empty)
                {
                    _reportTemplate.Id = _report.Id;
                    _reportTemplate.UserID = UserId;
                    _reportTemplate.DenNgay = dtDenNgay;
                }
                if (_report.TenPhuongThuc != "")
                {
                    this.GetType().GetMethod(_report.TenPhuongThuc).Invoke(this, null);
                }

                frm.HienThiReport(_reportTemplate, dataSetDev);
                frm.Show();
            }
            //END
        }

        public void Method_HoaDonGTGTBanRa()
        {
            dataSetDev = new DataSet();
            using (SqlConnection cn = new SqlConnection(ERP_Library.Database.ERP_Connection))
            {

                cn.Open();
                //tao bang_PhieuNhapVatTu
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "Report_HoaDonDichVu";
                    cm.Parameters.AddWithValue("@MaHoaDon", _hoaDon.MaHoaDon);

                    SqlDataAdapter da = new SqlDataAdapter(cm);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    const int maxrow = 10;
                    int rowcount = dt.Rows.Count;
                    //if (rowcount != 0 && rowcount < maxrow)
                    //{
                    //    for (int i = 0; i < maxrow - rowcount; i++)
                    //    {
                    //        //[TenHangHoaDichVu], [SoLuong], [DonGia], [ThanhTien]
                    //        //[TenDoiTac], [MaSoThueKH], [TenPhuongThucThanhToan]
                    //        //[TThoadon], [ThueVAT], [TongTien]
                    //        //[MauHoaDon],[KyHieuMauHoaDon]      
                    //        DataRow dr = dt.NewRow();
                    //        dr["TenHangHoaDichVu"] = string.Empty;
                    //        dr["SoLuong"] = 0;
                    //        dr["DonGia"] = 0;
                    //        dr["ThanhTien"] = 0;

                    //        dr["TenDoiTac"] = dt.Rows[0]["TenDoiTac"];
                    //        dr["MaSoThueKH"] = dt.Rows[0]["MaSoThueKH"];
                    //        dr["TenPhuongThucThanhToan"] = dt.Rows[0]["TenPhuongThucThanhToan"];
                    //        dr["TThoadon"] = dt.Rows[0]["TThoadon"];
                    //        dr["ThueVAT"] = dt.Rows[0]["ThueVAT"];
                    //        dr["ThueSuatVAT"] = dt.Rows[0]["ThueSuatVAT"];
                    //        dr["TongTien"] = dt.Rows[0]["TongTien"];
                    //        dr["MauHoaDon"] = dt.Rows[0]["MauHoaDon"];
                    //        dr["KyHieuMauHoaDon"] = dt.Rows[0]["KyHieuMauHoaDon"];
                    //        dr["VietBangChu"] = dt.Rows[0]["VietBangChu"];
                    //        dr["NguoiMuaHang"] = dt.Rows[0]["NguoiMuaHang"];
                    //        dt.Rows.Add(dr);
                    //    }
                    //}
                    dt.TableName = "MainData";
                    dataSetDev.Tables.Add(dt);
                }
                //tao bang_ReportHeaderAndFooter
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_ReportHeaderAndFooter";
                    cm.Parameters.AddWithValue("@MaNguoiLap", UserId);
                    SqlDataAdapter da = new SqlDataAdapter(cm);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dt.TableName = "spd_ReportHeaderAndFooter";
                    dataSetDev.Tables.Add(dt);
                }

            }//us 
        }

        private void InHoaDonGTGTBanRa_MayInKim_Dev()
        {
            //BEGIN
            ReportTemplate _report = ReportTemplate.GetReportTemplate("ID_Report_HoaDonGTGTBanRa_MayInKim"); ;

            if (_report != null)
            {
                DateTime dtDenNgay = DateTime.Today;
                frmReport frm = new frmReport();

                ReportTemplate _reportTemplate = ReportTemplate.GetReportTemplate(_report.Id, UserId, dtDenNgay);
                if (_reportTemplate.Id == string.Empty)
                {
                    _reportTemplate.Id = _report.Id;
                    _reportTemplate.UserID = UserId;
                    _reportTemplate.DenNgay = dtDenNgay;
                }
                if (_report.TenPhuongThuc != "")
                {
                    this.GetType().GetMethod(_report.TenPhuongThuc).Invoke(this, null);
                }

                frm.HienThiReport(_reportTemplate, dataSetDev);
                frm.Show();
            }
            //END
        }
        #endregion //Devexpress

        private bool KiemTraCungDoiTuongKhiLapHoaDonTuBienLaiHopLe(List<ChiTietBienLaiFromOtherDB> chitietbienlailistSelected)
        {
            string maQLDoiTuong = chitietbienlailistSelected[0].MaQLDoiTuong;
            foreach (ChiTietBienLaiFromOtherDB ctbienlai in chitietbienlailistSelected)
            {
                if (ctbienlai.MaQLDoiTuong != maQLDoiTuong)//Không Cùng Đối Tượng
                {
                    //MessageBox.Show("Không cùng đối tượng khi thu!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            return true;
        }
        private bool KiemTraLapHoaDonTuBienLaiHopLe(List<ChiTietBienLaiFromOtherDB> chitietbienlailistSelected)
        {
            int kieuthuphi = chitietbienlailistSelected[0].KieuThuPhi;
            int hinhthucthanhtoan = chitietbienlailistSelected[0].HinhThucThanhToan;
            foreach (ChiTietBienLaiFromOtherDB ctbienlai in chitietbienlailistSelected)
            {
                if (ctbienlai.KieuThuPhi == 3 && ctbienlai.KieuThuPhi != kieuthuphi)//Kiem Tra cung loai Thu Đồng Phục
                {
                    MessageBox.Show("Thu Đồng phục không hợp lệ!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                if (ctbienlai.HinhThucThanhToan != hinhthucthanhtoan)//Kiem Tra cung Hinh Thuc Thanh Toan
                {
                    MessageBox.Show("Thu theo hình thức thanh toán không hợp lệ!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            return true;
        }

        private void LapHoaDonFromBienLai()
        {
            if (_hoaDon.IsNew == false)
            {
                _hoaDon = HoaDon.NewHoaDon();
                SetDefaultMauHoaDon_KyHieuHoaDon();
            }
            radngoaidm.Checked = true;
            string tendoituong = cbo_khnhap.Text;
            #region Process
            FrmGetBienLaiFronOtherDB frm = new FrmGetBienLaiFronOtherDB(tendoituong, (int)cmb_HinhThucTT.SelectedValue, 2);
            if (frm.ShowDialog() != DialogResult.OK)
            {
                decimal tongtien = 0;
                List<ChiTietBienLaiFromOtherDB> chitietbienlailistSelected = frm.ChiTietBienLaiListSelected;//M
                if (chitietbienlailistSelected.Count != 0)//M
                {
                    if (KiemTraLapHoaDonTuBienLaiHopLe(chitietbienlailistSelected) == false) return;

                    #region Hoadon_DoiTac
                    if (_hdDOitac == null)
                    {
                        _hdDOitac = HoaDon_DoiTac.NewHoaDon_DoiTac();
                    }
                    if (KiemTraCungDoiTuongKhiLapHoaDonTuBienLaiHopLe(chitietbienlailistSelected))
                    {
                        _hdDOitac.TenDoiTac = chitietbienlailistSelected[0].TenDoiTuong;
                        cbo_khnhap.Value = chitietbienlailistSelected[0].TenDoiTuong;
                    }
                    else
                    {
                        _hdDOitac.TenDoiTac = cbo_khnhap.Text;
                        //cbo_khnhap.Value = cbo_khnhap.Text;
                    }
                    Binds_hoadon_Doitac.DataSource = _hdDOitac;
                    #endregion//HoaDon_DoiTac

                    if (chitietbienlailistSelected[0].HinhThucThanhToan == 1)
                    {
                        _hoaDon.MaHinhThucTT = 1;//Tien Mat
                    }
                    else
                    //if (chitietbienlailistSelected[0].HinhThucThanhToan==3
                    //|| chitietbienlailistSelected[0].HinhThucThanhToan==5
                    //)
                    {
                        _hoaDon.MaHinhThucTT = 2;//Chuyen Khoan
                    }
                    foreach (ChiTietBienLaiFromOtherDB ctbienlai in chitietbienlailistSelected)
                    {
                        bool insert = true;
                        if (_hoaDon.CT_HoaDonBienLaiList.Count > 0)
                        {
                            foreach (CT_HoaDonBienLaiChild item in _hoaDon.CT_HoaDonBienLaiList)
                            {
                                if (
                                    (ctbienlai.MaChiTiet != Guid.Empty && item.OidChiTietBienLai == ctbienlai.MaChiTiet)
                                     ||
                                     (ctbienlai.MaChiTietInt != 0 && item.IDChiTietBienLai == ctbienlai.MaChiTietInt)
                                    )
                                {
                                    insert = false;
                                    break;
                                }
                            }

                        }//grdViewCt_PhieuXuat.RowCount > 0

                        if (insert)
                        {
                            //Tao CT_HoaDonDichVu
                            CT_HoaDonDichVu ct_dichvu = CT_HoaDonDichVu.NewCT_HoaDonDichVu();
                            ct_dichvu.TenHangHoaDichVu = ctbienlai.DienGiai;
                            ct_dichvu.SoLuong = ctbienlai.SoLuong;
                            ct_dichvu.DonGia = ctbienlai.DonGia;
                            ct_dichvu.ThanhTien = ctbienlai.SoTien;
                            ct_dichvu.GhiChu = ctbienlai.GhiChu;
                            _hoaDon.CT_HoaDonDichVuList.Add(ct_dichvu);
                            tongtien += ctbienlai.SoTien;
                            //Tao CT_HoaDonBienLai
                            CT_HoaDonBienLaiChild ct_hoadonbienlai = CT_HoaDonBienLaiChild.NewCT_HoaDonBienLaiChild();
                            ct_hoadonbienlai.OidMaBienLai = ctbienlai.MaBienLai;
                            ct_hoadonbienlai.OidChiTietBienLai = ctbienlai.MaChiTiet;
                            ct_hoadonbienlai.IDBienLai = ctbienlai.MaBienLaiInt;
                            ct_hoadonbienlai.IDChiTietBienLai = ctbienlai.MaChiTietInt;
                            _hoaDon.CT_HoaDonBienLaiList.Add(ct_hoadonbienlai);
                        }
                    }
                    //Tinh Thue Suat
                    if (chitietbienlailistSelected[0].KieuThuPhi == 3)//Xac định là thu đồng phục, thuế suất 10%
                    {
                        _hoaDon.ThanhTien = (100 * tongtien) / (100 + 10);
                        _hoaDon.ThueSuatVAT = 10;
                        _hoaDon.TongTien = tongtien;
                    }
                    else
                    {
                        _hoaDon.ThanhTien = tongtien;
                        _hoaDon.ThueSuatVAT = 0;
                        _hoaDon.TongTien = tongtien;
                    }
                }
            }
            #endregion//Process
            hoaDonbindingSource.DataSource = _hoaDon;
            cTHoaDonDichVuListBindingSource.DataSource = _hoaDon.CT_HoaDonDichVuList;

        }

        //
        private bool KiemTraCungDoiTuongKhiLapHoaDonTuButToanThuePhaiNopHopLe(List<ButToanThuePhaiNopForHoaDonBanRa> buttoanthuephainoplistSelected)
        {
            string tendoituong = buttoanthuephainoplistSelected[0].TenDoiTuong;
            foreach (ButToanThuePhaiNopForHoaDonBanRa buttoan in buttoanthuephainoplistSelected)
            {
                if (buttoan.TenDoiTuong != tendoituong)//Không Cùng Đối Tượng
                {
                    //MessageBox.Show("Không cùng đối tượng khi thu!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            return true;
        }
        private bool KiemTraLapHoaDonTuButToanThuePhaiNopHopLe(List<ButToanThuePhaiNopForHoaDonBanRa> buttoanthuephainoplistSelected)
        {
            int hinhthucthanhtoan = buttoanthuephainoplistSelected[0].MaPhuongThucThanhToan;
            foreach (ButToanThuePhaiNopForHoaDonBanRa bt in buttoanthuephainoplistSelected)
            {
                if (bt.MaPhuongThucThanhToan != hinhthucthanhtoan)//Kiem Tra cung Hinh Thuc Thanh Toan
                {
                    MessageBox.Show("Thu theo hình thức thanh toán không hợp lệ!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            return true;
        }

        private bool KiemTraCungDoiTuongKhiLapHoaDonTuChungTuHopLe(List<ChungTuForHoaDonBanRa> chungtulistSelected)
        {
            string tendoituong = chungtulistSelected[0].TenDoiTuong;
            foreach (ChungTuForHoaDonBanRa chungtu in chungtulistSelected)
            {
                if (chungtu.TenDoiTuong != tendoituong)//Không Cùng Đối Tượng
                {
                    //MessageBox.Show("Không cùng đối tượng khi thu!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            return true;
        }
        private bool KiemTraLapHoaDonTuChungTUHopLe(List<ChungTuForHoaDonBanRa> chungtulistSelected)
        {
            int hinhthucthanhtoan = chungtulistSelected[0].MaPhuongThucThanhToan;
            foreach (ChungTuForHoaDonBanRa bt in chungtulistSelected)
            {
                if (bt.MaPhuongThucThanhToan != hinhthucthanhtoan)//Kiem Tra cung Hinh Thuc Thanh Toan
                {
                    //MessageBox.Show("Thu theo hình thức thanh toán không hợp lệ!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    MessageBox.Show("Lưu ý! Hình thức thanh toán không giống nhau!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
            }
            return true;
        }
        private void LapHoaDonFromButToanThuePhaiNop()
        {
            //ButToan buttoan,string tenDoiTuong,decimal sotienChungtu, int phuongthucthanhtoan
            if (_hoaDon.IsNew == false)
            {
                _hoaDon = HoaDon.NewHoaDon();
                SetDefaultMauHoaDon_KyHieuHoaDon();
            }
            radngoaidm.Checked = true;
            string tendoituong = cbo_khnhap.Text;
            #region Process
            FrmGetButToanThuePhaiNopToHoaDonBanRa frm = new FrmGetButToanThuePhaiNopToHoaDonBanRa();
            if (frm.ShowDialog() != DialogResult.OK)
            {
                decimal tongtien = _hoaDon.TongTien;
                decimal tienThue = _hoaDon.TienThue;
                List<ButToanThuePhaiNopForHoaDonBanRa> buttoanthuephainoplistSelected = frm.ButToanThuePhaiNopListSelected;//M
                if (buttoanthuephainoplistSelected.Count != 0)//M
                {
                    if (KiemTraLapHoaDonTuButToanThuePhaiNopHopLe(buttoanthuephainoplistSelected) == false) return;

                    #region Hoadon_DoiTac
                    if (_hdDOitac == null)
                    {
                        _hdDOitac = HoaDon_DoiTac.NewHoaDon_DoiTac();
                    }
                    if (KiemTraCungDoiTuongKhiLapHoaDonTuButToanThuePhaiNopHopLe(buttoanthuephainoplistSelected))
                    {
                        _hdDOitac.TenDoiTac = buttoanthuephainoplistSelected[0].TenDoiTuong;
                        cbo_khnhap.Value = buttoanthuephainoplistSelected[0].TenDoiTuong;
                    }
                    else
                    {
                        _hdDOitac.TenDoiTac = cbo_khnhap.Text;
                        //cbo_khnhap.Value = cbo_khnhap.Text;
                    }
                    Binds_hoadon_Doitac.DataSource = _hdDOitac;
                    #endregion//HoaDon_DoiTac
                    _hoaDon.MaHinhThucTT = buttoanthuephainoplistSelected[0].MaPhuongThucThanhToan;

                    foreach (ButToanThuePhaiNopForHoaDonBanRa buttoan in buttoanthuephainoplistSelected)
                    {
                        bool insert = true;
                        if (_hoaDon.CT_HoaDonDichVuList.Count > 0)
                        {
                            foreach (CT_HoaDonDichVu item in _hoaDon.CT_HoaDonDichVuList)
                            {
                                if (item.MaButToan == buttoan.MaButToan)
                                {
                                    insert = false;
                                    break;
                                }
                            }

                        }//grdViewCt_PhieuXuat.RowCount > 0

                        if (insert)
                        {
                            //Tao CT_HoaDonDichVu
                            CT_HoaDonDichVu ct_dichvu = CT_HoaDonDichVu.NewCT_HoaDonDichVu();
                            ct_dichvu.TenHangHoaDichVu = buttoan.DienGiai;
                            ct_dichvu.SoLuong = 1;
                            ct_dichvu.DonGia = buttoan.TienThue;
                            ct_dichvu.ThanhTien = buttoan.TienThue;
                            ct_dichvu.MaButToan = buttoan.MaButToan;
                            _hoaDon.CT_HoaDonDichVuList.Add(ct_dichvu);
                            //ChungTu_HoaDon
                            ChungTu_HoaDon ct_hd = ChungTu_HoaDon.NewChungTu_HoaDon();
                            ct_hd.MaButToan = buttoan.MaButToan;
                            ct_hd.SoTien = buttoan.TienThue;
                            _hoaDon.Chungtu_HoaDonList.Add(ct_hd);
                            //
                            tongtien += buttoan.TienSauThue;
                            tienThue += buttoan.TienThue;
                        }
                    }
                    if (tienThue > 0)
                    {
                        double thuesuat = 0;
                        thuesuat = (double)((tongtien - tienThue) / tienThue);
                        if (thuesuat < 3)
                        {
                            _hoaDon.ThueSuatVAT = 0;
                        }
                        else if (thuesuat < 8)
                        {
                            _hoaDon.ThueSuatVAT = 5;
                        }
                        else
                        {
                            _hoaDon.ThueSuatVAT = 10;
                        }
                    }
                    _hoaDon.TongTien = tongtien;
                }
            }
            #endregion//Process
            hoaDonbindingSource.DataSource = _hoaDon;
            cTHoaDonDichVuListBindingSource.DataSource = _hoaDon.CT_HoaDonDichVuList;

        }

        private void LapHoaDonBanRaFromChungTu()
        {
            //ButToan buttoan,string tenDoiTuong,decimal sotienChungtu, int phuongthucthanhtoan
            if (_hoaDon.IsNew == false)
            {
                _hoaDon = HoaDon.NewHoaDon();
                SetDefaultMauHoaDon_KyHieuHoaDon();
            }
            radngoaidm.Checked = true;
            string tendoituong = cbo_khnhap.Text;
            #region Process
            //FrmGetButToanThuePhaiNopToHoaDonBanRa frm = new FrmGetButToanThuePhaiNopToHoaDonBanRa();
            FrmGeChungTuToHoaDonBanRa frm = new FrmGeChungTuToHoaDonBanRa();
            if (frm.ShowDialog() != DialogResult.OK)
            {
                decimal tongtien = _hoaDon.TongTien;
                decimal tienThue = _hoaDon.TienThue;
                List<ChungTuForHoaDonBanRa> chungtulistSelected = frm.ChungTuListSelected;//M
                if (chungtulistSelected.Count != 0)//M
                {
                    if (KiemTraLapHoaDonTuChungTUHopLe(chungtulistSelected) == false) return;

                    #region Hoadon_DoiTac
                    if (_hdDOitac == null)
                    {
                        _hdDOitac = HoaDon_DoiTac.NewHoaDon_DoiTac();
                    }
                    if (KiemTraCungDoiTuongKhiLapHoaDonTuChungTuHopLe(chungtulistSelected))
                    {
                        _hdDOitac.TenDoiTac = chungtulistSelected[0].TenDoiTuong;
                        cbo_khnhap.Value = chungtulistSelected[0].TenDoiTuong;
                    }
                    else
                    {
                        _hdDOitac.TenDoiTac = cbo_khnhap.Text;
                        //cbo_khnhap.Value = cbo_khnhap.Text;
                    }
                    Binds_hoadon_Doitac.DataSource = _hdDOitac;
                    #endregion//HoaDon_DoiTac
                    _hoaDon.MaHinhThucTT = chungtulistSelected[0].MaPhuongThucThanhToan;

                    //==============KO GOM THEO DIEN GIAI===============
                    foreach (ChungTuForHoaDonBanRa chungtu in chungtulistSelected)
                    {
                        bool insert = true;
                        if (_hoaDon.CT_HoaDonDichVuList.Count > 0)
                        {
                            foreach (CT_HoaDonDichVu item in _hoaDon.CT_HoaDonDichVuList)
                            {
                                if (item.MaChungTu == chungtu.MaChungTu && item.MaButToan == chungtu.MaButToan)
                                {
                                    insert = false;
                                    break;
                                }
                            }

                        }//grdViewCt_PhieuXuat.RowCount > 0

                        if (insert)
                        {
                            //Tao CT_HoaDonDichVu
                            #region ItemChungTu
                            CT_HoaDonDichVu ct_dichvu = CT_HoaDonDichVu.NewCT_HoaDonDichVu();
                            ct_dichvu.TenHangHoaDichVu = chungtu.DienGiaiButToan;
                            ct_dichvu.SoLuong = 1;
                            ct_dichvu.DonGia = chungtu.SoTienButToan;
                            ct_dichvu.ThanhTien = chungtu.SoTienButToan;
                            ct_dichvu.MaChungTu = chungtu.MaChungTu;
                            ct_dichvu.MaButToan = chungtu.MaButToan;
                            ct_dichvu.MaDoiTac = chungtu.MaDoiTuong;
                            _hoaDon.CT_HoaDonDichVuList.Add(ct_dichvu);
                            #endregion ItemChungTu
                            //ChungTu_HoaDon
                            ChungTu_HoaDonThanhToan ct_hd = ChungTu_HoaDonThanhToan.NewChungTu_HoaDonThanhToan();
                            ct_hd.MaChungTu = chungtu.MaChungTu;
                            ct_hd.MaButToan = chungtu.MaButToan;
                            ct_hd.SoTienThanhToan = chungtu.SoTienButToan;
                            ct_hd.MaDoiTac = chungtu.MaDoiTuong;

                            _hoaDon.ChungTu_HoaDonThanhToanList.Add(ct_hd);
                            //
                            tongtien += chungtu.SoTienButToan;
                        }
                    }
                    _hoaDon.ThanhTien = tongtien;
                    _hoaDon.TongTien = tongtien;
                    _hoaDon.KhauTruThue = true;
                    _hoaDon.ThueSuatVAT = -1;
                    //=========================================================


                }
            }
            #endregion//Process
            hoaDonbindingSource.DataSource = _hoaDon;
            cTHoaDonDichVuListBindingSource.DataSource = _hoaDon.CT_HoaDonDichVuList;

        }

        private void LapChungTuKeToanTuHoaDon()
        {
            long maChungTu = PublicClass.KiemTraHoaDonDaLapChungTuKeToan(_hoaDon.MaHoaDon);
            if (maChungTu != 0)
            {
                if (MessageBox.Show("Hóa đơn đã lập chứng từ kế toán, bạn có muốn xem lại chứng từ?", "Xác Nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    ChungTuCustomize chungtu = ChungTuCustomize.GetChungTuCustomize(maChungTu);
                    FrmChungTuKeToanCustomize frm = new FrmChungTuKeToanCustomize(chungtu);
                    frm.ShowDialog();
                }
                else
                {
                    return;
                }
            }
            else
            {
                FrmChungTuKeToanCustomize frm = new FrmChungTuKeToanCustomize(_hoaDon);
                frm.ShowDialog();
            }
        }

        #endregion

        private void frmHoaDonDichVuBanRa_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (
                _hoaDon.IsNew == false
                &&
                !PublicClass.KiemTraIsHoaDonBiHuy(_hoaDon.MaHoaDon)
                &&
                PublicClass.KiemTraHoaDonDaLapChungTuKeToan(_hoaDon.MaHoaDon) == 0
                )
            {
                //MessageBox.Show("Vui Lòng lập Chứng Từ Kế Toán Cho Hóa Đơn!", "Yêu Cầu");
                //e.Cancel = true;
            }
        }

        private void tlSBtnDelete_Click(object sender, EventArgs e)
        {
            HoaDon.DeleteHoaDon(_hoaDon);
        }

        private void NhomHHDVMuaVao_ultraCombo_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            ////NhomHHDVMuaVao
            //NhomHHDVMVListBindingSource.DataSource = typeof(NhomHHDVMuaVao);
            //NhomHHDVMVListBindingSource.DataSource = NhomHHDVMuaVaoList.GetNhomHHDVMuaVaoList();
            ////
            //NhomHHDVMuaVao_ultraCombo.DataSource = NhomHHDVMVListBindingSource;
            ////NhomHHDVMuaVao_ultraCombo.DisplayLayout.Appearance = appearance19;
            //NhomHHDVMuaVao_ultraCombo.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            //NhomHHDVMuaVao_ultraCombo.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            //NhomHHDVMuaVao_ultraCombo.DisplayMember = "MaQL";
            //NhomHHDVMuaVao_ultraCombo.ValueMember = "MaQL";
            //foreach (UltraGridColumn col in NhomHHDVMuaVao_ultraCombo.DisplayLayout.Bands[0].Columns)
            //{
            //    col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
            //    col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
            //    col.Header.Appearance.ForeColor = System.Drawing.Color.RoyalBlue;
            //    col.Hidden = true;
            //}
            //NhomHHDVMuaVao_ultraCombo.DisplayLayout.Bands[0].Columns["MaQL"].Hidden = false;
            //NhomHHDVMuaVao_ultraCombo.DisplayLayout.Bands[0].Columns["MaQL"].Header.Caption = "Mã nhóm";
            //NhomHHDVMuaVao_ultraCombo.DisplayLayout.Bands[0].Columns["MaQL"].Header.VisiblePosition = 1;
            //NhomHHDVMuaVao_ultraCombo.DisplayLayout.Bands[0].Columns["MaQL"].Width = 70;
            //NhomHHDVMuaVao_ultraCombo.DisplayLayout.Bands[0].Columns["TenNhomHHDVMuaVao"].Hidden = false;
            //NhomHHDVMuaVao_ultraCombo.DisplayLayout.Bands[0].Columns["TenNhomHHDVMuaVao"].Header.Caption = "Tên nhóm";
            //NhomHHDVMuaVao_ultraCombo.DisplayLayout.Bands[0].Columns["TenNhomHHDVMuaVao"].Width = 500;
            //NhomHHDVMuaVao_ultraCombo.DisplayLayout.Bands[0].Columns["TenNhomHHDVMuaVao"].Header.VisiblePosition = 2;
            //FilterCombo f = new FilterCombo(grdu_ChiTietHoaDon, "NhomHHDVMuaVao", "TenNhomHHDVMuaVao");
        }


        private void khoitaocontrol()
        {

            ////NhomHHDVMuaVao
            //NhomHHDVMVListBindingSource.DataSource = typeof(NhomHHDVMuaVao);
            //NhomHHDVMVListBindingSource.DataSource = NhomHHDVMuaVaoList.GetNhomHHDVMuaVaoList();
            ////
            //NhomHHDVMuaVao_ultraCombo.DataSource = NhomHHDVMVListBindingSource;
            ////NhomHHDVMuaVao_ultraCombo.DisplayLayout.Appearance = appearance19;
            //NhomHHDVMuaVao_ultraCombo.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            //NhomHHDVMuaVao_ultraCombo.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            //NhomHHDVMuaVao_ultraCombo.DisplayMember = "MaQL";
            //NhomHHDVMuaVao_ultraCombo.ValueMember = "MaQL";
            //foreach (UltraGridColumn col in NhomHHDVMuaVao_ultraCombo.DisplayLayout.Bands[0].Columns)
            //{
            //    col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
            //    col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
            //    col.Header.Appearance.ForeColor = System.Drawing.Color.RoyalBlue;
            //    col.Hidden = true;
            //}
            //NhomHHDVMuaVao_ultraCombo.DisplayLayout.Bands[0].Columns["MaQL"].Hidden = false;
            //NhomHHDVMuaVao_ultraCombo.DisplayLayout.Bands[0].Columns["MaQL"].Header.Caption = "Mã nhóm";
            //NhomHHDVMuaVao_ultraCombo.DisplayLayout.Bands[0].Columns["MaQL"].Header.VisiblePosition = 1;
            //NhomHHDVMuaVao_ultraCombo.DisplayLayout.Bands[0].Columns["MaQL"].Width = 70;
            //NhomHHDVMuaVao_ultraCombo.DisplayLayout.Bands[0].Columns["TenNhomHHDVMuaVao"].Hidden = false;
            //NhomHHDVMuaVao_ultraCombo.DisplayLayout.Bands[0].Columns["TenNhomHHDVMuaVao"].Header.Caption = "Tên nhóm";
            //NhomHHDVMuaVao_ultraCombo.DisplayLayout.Bands[0].Columns["TenNhomHHDVMuaVao"].Width = 500;
            //NhomHHDVMuaVao_ultraCombo.DisplayLayout.Bands[0].Columns["TenNhomHHDVMuaVao"].Header.VisiblePosition = 2;
            //FilterCombo f = new FilterCombo(grdu_ChiTietHoaDon, "NhomHHDVMuaVao", "TenNhomHHDVMuaVao");



        }

        private void DoiTac_ultraCombo_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {

            FilterCombo f = new FilterCombo(DoiTac_ultraCombo, "TenDoiTac");
            _DoiTacList = DoiTacList.GetDoiTacListByTen(0);
            //DoiTac _DoiTac = DoiTac.NewDoiTac(0, "Thêm Mới...");
            //_DoiTacList.Insert(0, _DoiTac);
            doiTacListBindingSource.DataSource = _DoiTacList;
            //DoiTac
            //
            //DoiTac_ultraCombo.DataSource = doiTacListBindingSource;
            //DoiTac_ultraCombo.DisplayLayout.Appearance = appearance19;
            DoiTac_ultraCombo.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            DoiTac_ultraCombo.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            //DoiTac_ultraCombo.DisplayMember = "TenDoiTac";
            //DoiTac_ultraCombo.ValueMember = "MaDoiTac";
            foreach (UltraGridColumn col in DoiTac_ultraCombo.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.RoyalBlue;
                col.Hidden = true;
            }
            DoiTac_ultraCombo.DisplayLayout.Bands[0].Columns["MaQLDoiTac"].Hidden = false;
            DoiTac_ultraCombo.DisplayLayout.Bands[0].Columns["MaQLDoiTac"].Header.Caption = "Mã QL";
            DoiTac_ultraCombo.DisplayLayout.Bands[0].Columns["MaQLDoiTac"].Header.VisiblePosition = 1;
            DoiTac_ultraCombo.DisplayLayout.Bands[0].Columns["MaQLDoiTac"].Width = 70;
            DoiTac_ultraCombo.DisplayLayout.Bands[0].Columns["TenDoiTac"].Hidden = false;
            DoiTac_ultraCombo.DisplayLayout.Bands[0].Columns["TenDoiTac"].Header.Caption = "Tên Đối Tác";
            DoiTac_ultraCombo.DisplayLayout.Bands[0].Columns["TenDoiTac"].Width = 500;
            DoiTac_ultraCombo.DisplayLayout.Bands[0].Columns["TenDoiTac"].Header.VisiblePosition = 2;
        }

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            #region Modify
            Decimal _tongTien = 0;
            if (e.Column.FieldName == "ThanhTien" || e.Column.FieldName == "SoLuong" || e.Column.FieldName == "DonGia")
            {
                if (_hoaDon.LoaiHoaDon == 5)
                {
                    foreach (CT_HoaDonDichVu ct_HoaDonDichVu in _hoaDon.CT_HoaDonDichVuList)
                    {
                        _tongTien = _tongTien + ct_HoaDonDichVu.ThanhTien;
                    }
                    _hoaDon.ThanhTien = _tongTien;

                    hoaDonbindingSource.DataSource = _hoaDon;
                }
            }
            if (e.Column.FieldName == "TenHangHoaDichVu")
            {
                CT_HoaDonDichVu obj = (CT_HoaDonDichVu)cTHoaDonDichVuListBindingSource.Current;
                if (_hoaDon.MaDoiTac != 0 && obj.MaDoiTac == 0)
                {
                    obj.MaDoiTac = _hoaDon.MaDoiTac;
                }
            }
            #endregion Modify
        }

        private void gridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                if (gridView1.RowCount > 0)
                {
                    if (gridView1.GetSelectedRows().Length > 0)
                    {
                        if (MessageBox.Show(String.Format("Bạn có muốn xóa {0} dòng được chọn không?", gridView1.GetSelectedRows().Length), "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            gridView1.DeleteSelectedRows();
                        }
                    }
                }
            }
        }

        private void tlsInHoaDon_MayInKim_Click(object sender, EventArgs e)
        {
            InHoaDonGTGTBanRa_MayInKim_Dev();
        }

        string strIDChungTu = "";
        private void LapHoaDonBanRaFromChungTu_GroupByDienGiai()
        {
            //ButToan buttoan,string tenDoiTuong,decimal sotienChungtu, int phuongthucthanhtoan
            if (_hoaDon.IsNew == false)
            {
                _hoaDon = HoaDon.NewHoaDon();
                SetDefaultMauHoaDon_KyHieuHoaDon();
            }
            radngoaidm.Checked = true;
            string tendoituong = cbo_khnhap.Text;
            #region Process
            //FrmGetButToanThuePhaiNopToHoaDonBanRa frm = new FrmGetButToanThuePhaiNopToHoaDonBanRa();
            FrmGeChungTuToHoaDonBanRa frm = new FrmGeChungTuToHoaDonBanRa();
            if (frm.ShowDialog() != DialogResult.OK)
            {
                decimal tongtien = _hoaDon.TongTien;
                decimal tienThue = _hoaDon.TienThue;
                List<ChungTuForHoaDonBanRa> chungtulistSelected = frm.ChungTuListSelected;//M
                if (chungtulistSelected.Count != 0)//M
                {
                    //if (KiemTraLapHoaDonTuChungTUHopLe(chungtulistSelected) == false) return;
                    if (KiemTraLapHoaDonTuChungTUHopLe(chungtulistSelected) == false)
                    {
                        _hoaDon.MaHinhThucTT = 0;
                    }
                    else
                    {
                        _hoaDon.MaHinhThucTT = chungtulistSelected[0].MaPhuongThucThanhToan;
                    }

                    #region Hoadon_DoiTac
                    if (_hdDOitac == null)
                    {
                        _hdDOitac = HoaDon_DoiTac.NewHoaDon_DoiTac();
                    }

                    if (chungtulistSelected[0].MaDoiTuong > 0)
                    {
                        radtrongdm.Checked = true;
                        cmbu_KhachHang.Value = chungtulistSelected[0].MaDoiTuong;
                        _hoaDon.MaDoiTac = chungtulistSelected[0].MaDoiTuong;
                    }
                    else
                    {
                        if (KiemTraCungDoiTuongKhiLapHoaDonTuChungTuHopLe(chungtulistSelected))
                        {
                            _hdDOitac.TenDoiTac = chungtulistSelected[0].TenDoiTuong;
                            cbo_khnhap.Value = chungtulistSelected[0].TenDoiTuong;                            
                        }
                        else
                        {
                            _hdDOitac.TenDoiTac = cbo_khnhap.Text;
                            //cbo_khnhap.Value = cbo_khnhap.Text;
                        }
                        Binds_hoadon_Doitac.DataSource = _hdDOitac;
                    }

                    #endregion//HoaDon_DoiTac


                    //GOM LAI THEO DIEN GIAI                   
                    decimal soTien = 0;
                    string dienGiai = "";
                    long maDoiTac = 0;
                    foreach (ChungTuForHoaDonBanRa chungtu in chungtulistSelected)
                    {
                        //gom lai theo noi dung & doi tuong
                        dienGiai = chungtu.DienGiaiButToan + "";
                        maDoiTac = chungtu.MaDoiTuong;
                        soTien = 0;
                        foreach (ChungTuForHoaDonBanRa iChungTu in chungtulistSelected)
                        {
                            if (strIDChungTu.Contains(iChungTu.MaButToan + ""))
                            {
                                continue;
                            }
                            if (dienGiai.Equals(iChungTu.DienGiaiButToan) && maDoiTac == iChungTu.MaDoiTuong)
                            {
                                soTien = soTien + iChungTu.SoTienButToan;
                                strIDChungTu = strIDChungTu + iChungTu.MaButToan + ",";

                                //truong hop chon nhieu phieu, hinh thuc thanh toan khac nhung cung noi dung
                                //vi du, thu hoc phi, vua tien mat, chuyen khoan, xuat chung 1 HD,
                                //=> so tien thanh toan tach rieng tung chung tu PT, PT ngan hang
                                if (iChungTu.SoTienButToan > 0)
                                {
                                    ChungTu_HoaDonThanhToan ct_hd = ChungTu_HoaDonThanhToan.NewChungTu_HoaDonThanhToan();
                                    ct_hd.MaChungTu = iChungTu.MaChungTu;
                                    ct_hd.MaButToan = iChungTu.MaButToan;
                                    ct_hd.SoTienThanhToan = iChungTu.SoTienButToan; //chungtu.Tien.ThanhTien;
                                    _hoaDon.ChungTu_HoaDonThanhToanList.Add(ct_hd);
                                }
                            }
                        }

                        if (soTien > 0)
                        {
                            CT_HoaDonDichVu ct_dichvu = CT_HoaDonDichVu.NewCT_HoaDonDichVu();
                            ct_dichvu.TenHangHoaDichVu = dienGiai;
                            ct_dichvu.SoLuong = 1;
                            ct_dichvu.DonGia = soTien;
                            ct_dichvu.ThanhTien = soTien;
                            ct_dichvu.MaButToan = chungtu.MaButToan;
                            ct_dichvu.MaChungTu = chungtu.MaChungTu;
                            ct_dichvu.MaDoiTac = maDoiTac;
                            _hoaDon.CT_HoaDonDichVuList.Add(ct_dichvu);
                            //ChungTu_HoaDonThanhToan
                            //ChungTu_HoaDonThanhToan ct_hd = ChungTu_HoaDonThanhToan.NewChungTu_HoaDonThanhToan();
                            //ct_hd.MaChungTu = chungtu.MaChungTu;
                            //ct_hd.MaButToan = chungtu.MaButToan;
                            //ct_hd.SoTienThanhToan = soTien; //chungtu.Tien.ThanhTien;
                            //_hoaDon.ChungTu_HoaDonThanhToanList.Add(ct_hd);

                            tongtien += soTien;
                        }

                    }

                    _hoaDon.ThanhTien = tongtien;
                    //_hoaDon.TongTien = chungtu.Tien.ThanhTien;
                    _hoaDon.KhauTruThue = true;
                    _hoaDon.ThueSuatVAT = -1;

                    hoaDonbindingSource.DataSource = _hoaDon;
                    cTHoaDonDichVuListBindingSource.DataSource = _hoaDon.CT_HoaDonDichVuList;
                    txt_SoHoaDon.Focus();
                }
            }
            #endregion//Process
            hoaDonbindingSource.DataSource = _hoaDon;
            cTHoaDonDichVuListBindingSource.DataSource = _hoaDon.CT_HoaDonDichVuList;

        }

        private void LapHoaDonBanRaFromChungTu_GroupByIDKhoanMuc()
        {
            //ButToan buttoan,string tenDoiTuong,decimal sotienChungtu, int phuongthucthanhtoan
            if (_hoaDon.IsNew == false)
            {
                _hoaDon = HoaDon.NewHoaDon();
                SetDefaultMauHoaDon_KyHieuHoaDon();
            }
            radngoaidm.Checked = true;
            string tendoituong = cbo_khnhap.Text;
            #region Process
            //FrmGetButToanThuePhaiNopToHoaDonBanRa frm = new FrmGetButToanThuePhaiNopToHoaDonBanRa();
            FrmGeChungTuToHoaDonBanRa frm = new FrmGeChungTuToHoaDonBanRa();
            if (frm.ShowDialog() != DialogResult.OK)
            {
                decimal tongtien = _hoaDon.TongTien;
                decimal tienThue = _hoaDon.TienThue;
                List<ChungTuForHoaDonBanRa> chungtulistSelected = frm.ChungTuListSelected;//M
                if (chungtulistSelected.Count != 0)//M
                {
                    //if (KiemTraLapHoaDonTuChungTUHopLe(chungtulistSelected) == false) return;
                    if (KiemTraLapHoaDonTuChungTUHopLe(chungtulistSelected) == false)
                    {
                        _hoaDon.MaHinhThucTT = 0;
                    }
                    else
                    {
                        _hoaDon.MaHinhThucTT = chungtulistSelected[0].MaPhuongThucThanhToan;
                    }

                    #region Hoadon_DoiTac
                    if (_hdDOitac == null)
                    {
                        _hdDOitac = HoaDon_DoiTac.NewHoaDon_DoiTac();
                    }

                    if (chungtulistSelected[0].MaDoiTuong > 0)
                    {
                        radtrongdm.Checked = true;
                        cmbu_KhachHang.Value = chungtulistSelected[0].MaDoiTuong;
                        _hoaDon.MaDoiTac = chungtulistSelected[0].MaDoiTuong;
                    }
                    else
                    {
                        if (KiemTraCungDoiTuongKhiLapHoaDonTuChungTuHopLe(chungtulistSelected))
                        {
                            _hdDOitac.TenDoiTac = chungtulistSelected[0].TenDoiTuong;
                            cbo_khnhap.Value = chungtulistSelected[0].TenDoiTuong;
                        }
                        else
                        {
                            _hdDOitac.TenDoiTac = cbo_khnhap.Text;
                            //cbo_khnhap.Value = cbo_khnhap.Text;
                        }
                        Binds_hoadon_Doitac.DataSource = _hdDOitac;
                    }

                    #endregion//HoaDon_DoiTac


                    //GOM LAI THEO DIEN GIAI                   
                    decimal soTien = 0;
                    string dienGiai = "";
                    long maDoiTac = 0;
                    int intIDKhoanMuc = 0;
                    foreach (ChungTuForHoaDonBanRa chungtu in chungtulistSelected)
                    {
                        //gom lai theo noi dung & doi tuong
                        dienGiai = chungtu.DienGiaiButToan + "";
                        maDoiTac = chungtu.MaDoiTuong;
                        intIDKhoanMuc = chungtu.IDKhoanMuc;
                        soTien = 0;
                        foreach (ChungTuForHoaDonBanRa iChungTu in chungtulistSelected)
                        {
                            if (strIDChungTu.Contains(iChungTu.MaButToan + ""))
                            {
                                continue;
                            }
                            if (intIDKhoanMuc == iChungTu.IDKhoanMuc && maDoiTac == iChungTu.MaDoiTuong)
                            {
                                soTien = soTien + iChungTu.SoTienButToan;
                                strIDChungTu = strIDChungTu + iChungTu.MaButToan + ",";

                                //truong hop chon nhieu phieu, hinh thuc thanh toan khac nhung cung noi dung
                                //vi du, thu hoc phi, vua tien mat, chuyen khoan, xuat chung 1 HD,
                                //=> so tien thanh toan tach rieng tung chung tu PT, PT ngan hang
                                if (iChungTu.SoTienButToan > 0)
                                {
                                    ChungTu_HoaDonThanhToan ct_hd = ChungTu_HoaDonThanhToan.NewChungTu_HoaDonThanhToan();
                                    ct_hd.MaChungTu = iChungTu.MaChungTu;
                                    ct_hd.MaButToan = iChungTu.MaButToan;
                                    ct_hd.SoTienThanhToan = iChungTu.SoTienButToan; //chungtu.Tien.ThanhTien;
                                    _hoaDon.ChungTu_HoaDonThanhToanList.Add(ct_hd);
                                }
                            }
                        }

                        if (soTien > 0)
                        {
                            CT_HoaDonDichVu ct_dichvu = CT_HoaDonDichVu.NewCT_HoaDonDichVu();
                            ct_dichvu.TenHangHoaDichVu = dienGiai;
                            ct_dichvu.SoLuong = 1;
                            ct_dichvu.DonGia = soTien;
                            ct_dichvu.ThanhTien = soTien;
                            ct_dichvu.MaButToan = chungtu.MaButToan;
                            ct_dichvu.MaChungTu = chungtu.MaChungTu;
                            ct_dichvu.MaDoiTac = maDoiTac;
                            _hoaDon.CT_HoaDonDichVuList.Add(ct_dichvu);
                            //ChungTu_HoaDonThanhToan
                            //ChungTu_HoaDonThanhToan ct_hd = ChungTu_HoaDonThanhToan.NewChungTu_HoaDonThanhToan();
                            //ct_hd.MaChungTu = chungtu.MaChungTu;
                            //ct_hd.MaButToan = chungtu.MaButToan;
                            //ct_hd.SoTienThanhToan = soTien; //chungtu.Tien.ThanhTien;
                            //_hoaDon.ChungTu_HoaDonThanhToanList.Add(ct_hd);

                            tongtien += soTien;
                        }

                    }

                    _hoaDon.ThanhTien = tongtien;
                    //_hoaDon.TongTien = chungtu.Tien.ThanhTien;
                    _hoaDon.KhauTruThue = true;
                    _hoaDon.ThueSuatVAT = -1;

                    hoaDonbindingSource.DataSource = _hoaDon;
                    cTHoaDonDichVuListBindingSource.DataSource = _hoaDon.CT_HoaDonDichVuList;
                    txt_SoHoaDon.Focus();
                }
            }
            #endregion//Process
            hoaDonbindingSource.DataSource = _hoaDon;
            cTHoaDonDichVuListBindingSource.DataSource = _hoaDon.CT_HoaDonDichVuList;

        }

        private void frmHoaDonDichVuBanRa_Load(object sender, EventArgs e)
        {
            if (this._hoaDon.NhomHHDVMuaVao == 5)
                chkKhongTongHopTrenToKhai.Checked = true;
            else
                chkKhongTongHopTrenToKhai.Checked = false;
        }
    }
}

