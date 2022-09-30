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
using DevExpress.XtraEditors.Repository;
using PSC_ERP_Common;

namespace PSC_ERP
{

    public partial class frmHoaDonDichVuMuaVao : Form
    {
        HoaDon _hoaDon;
        DoiTacList _DoiTacList;
        private HamDungChung hamDungChung = new HamDungChung();
        private Util util = new Util();
        HoaDon_DoiTac _hdDOitac;
        Decimal _tongTien = 0;
        long maDoiTac = 0;
        DateTime _ngaylap = DateTime.Now.Date;
        HoaDonList _hoaDonList = HoaDonList.NewHoaDonList();
        bool _loaikhautru = false;
        public HoaDonList _HoaDonListDichVu = HoaDonList.NewHoaDonList();
        //Thành Thêm
        ChungTu _chungTu;
        ButToan _butToan;

        PhieuNhapXuat _PhieuNX;

        PhuongThucThanhToanList _phuongthucthanhtoanList = PhuongThucThanhToanList.NewPhuongThucThanhToanList();

        Infragistics.Win.UltraWinGrid.UltraCombo DoiTac_ultraCombo = new UltraCombo();

        private BindingSource NhomHHDVMVListBindingSource = new BindingSource();


        public frmHoaDonDichVuMuaVao()
        {
            InitializeComponent();
            KhaiBaoSuKien();
            KhoiTao();
            ThemMoi();
            cmbu_MauHD.Value = "01GTKT";
        }
        public frmHoaDonDichVuMuaVao(DateTime Ngaylap, bool Loai)
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
            cmbu_MauHD.Value = "01GTKT";
        }

        public frmHoaDonDichVuMuaVao(long _maDoiTac, DateTime NgayLap, bool Loai, ChungTu chungtu = null)
        {
            _ngaylap = NgayLap;

            maDoiTac = _maDoiTac;
            //maDoiTac = chungtu.DoiTuong;
            InitializeComponent();
            KhaiBaoSuKien();
            //KhoiTao(_maDoiTac);
            KhoiTaoNew(maDoiTac);
            ThemMoi();
            cmbu_LoaiHoaDon.ReadOnly = true;

            _hoaDon.NgayHetHanTT = _ngaylap;
            _hoaDon.NgayLap = _ngaylap;
            _hoaDon.KhauTruThue = Loai;

            if (Loai)
            {
                cmbe_ThueVAT.Enabled = false;
                _hoaDon.NhomHHDVMuaVao = 4;
            }
            else
                _hoaDon.NhomHHDVMuaVao = 3;
            // cmbu_KhachHang.ReadOnly = true;
            cmbu_MauHD.Value = "01GTKT";
            _chungTu = chungtu;

            CT_HoaDonDichVu ct_dichvu = CT_HoaDonDichVu.NewCT_HoaDonDichVu();
            if (_chungTu != null)
            {
                foreach (ButToan bt in _chungTu.ButToanList)
                {
                    ct_dichvu.SoLuong = 1;
                    ct_dichvu.DonGia = bt.SoTien;
                    ct_dichvu.MaDoiTac = bt.DoiTuongCo;
                    _hoaDon.CT_HoaDonDichVuList.Add(ct_dichvu);
                }
            }
        }

        public frmHoaDonDichVuMuaVao(PhieuNhapXuat phieuNX, bool Loai)
        {
            _PhieuNX = phieuNX;
            _ngaylap = phieuNX.NgayNX;

            maDoiTac = phieuNX.MaDoiTac;
            InitializeComponent();
            KhaiBaoSuKien();
            KhoiTao(maDoiTac);
            ThemMoi(phieuNX);
            cmbu_LoaiHoaDon.ReadOnly = true;

            _hoaDon.NgayHetHanTT = _ngaylap;
            _hoaDon.NgayLap = _ngaylap;
            _hoaDon.KhauTruThue = Loai;
            if (Loai)
                cmbe_ThueVAT.Enabled = false;
        }

        public void Show_frmHoaDonDichVuMuaVao()
        {
            frmHoaDonDichVuMuaVao frm = new frmHoaDonDichVuMuaVao(4);
            frm.Show();
        }

        public frmHoaDonDichVuMuaVao(int loai)
        {

            InitializeComponent();
            KhaiBaoSuKien();
            KhoiTao();
            ThemMoi(loai);
            cmbu_MauHD.Value = "01GTKT";
        }
        public frmHoaDonDichVuMuaVao(HoaDon hd)
        {
            using (DialogUtil.Wait())
            {

                InitializeComponent();
                KhaiBaoSuKien();
                KhoiTao();
                KhoiTao(hd);
                khoitaocontrol();
                if (_hoaDon.MaDoiTac == 0)
                {
                    radngoaidm.Checked = true;
                    _hdDOitac = HoaDon_DoiTac.GetHoaDon_DoiTacByHoaDon(_hoaDon.MaHoaDon);
                    Binds_hoadon_Doitac.DataSource = _hdDOitac;
                    txtu_MaSoThue.Text = _hdDOitac.MSThue;
                    if (_hoaDon.MaDoiTac != 0)
                    {
                        txtu_MaSoThue.Text = DoiTac.GetDoiTac(_hoaDon.MaDoiTac).MaSoThue;
                    }
                }
                cmbu_MauHD.Value = hd.MauHoaDon;
                _hoaDon.KyHieuMauHoaDon = hd.KyHieuMauHoaDon;


                if (_hoaDon.MaDCGuiHD == 0)
                {
                    cbo_DiaChiText.Location = cmb_DiaChi.Location;
                    cmb_DiaChi.Visible = false;
                    cbo_DiaChiText.Visible = true;
                }
                else
                {
                    cmb_DiaChi.Visible = true;
                    cbo_DiaChiText.Visible = false;
                }
            }


        }


        private void khoitaocontrol()
        {
            //NhomHHDVMuaVao
            NhomHHDVMVListBindingSource.DataSource = typeof(NhomHHDVMuaVao);
            NhomHHDVMVListBindingSource.DataSource = NhomHHDVMuaVaoList.GetNhomHHDVMuaVaoList();
            //
            NhomHHDVMuaVao_ultraCombo.DataSource = NhomHHDVMVListBindingSource;
            //NhomHHDVMuaVao_ultraCombo.DisplayLayout.Appearance = appearance19;
            NhomHHDVMuaVao_ultraCombo.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            NhomHHDVMuaVao_ultraCombo.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            NhomHHDVMuaVao_ultraCombo.DisplayMember = "TenNhomHHDVMuaVao";
            NhomHHDVMuaVao_ultraCombo.ValueMember = "Id";
            foreach (UltraGridColumn col in NhomHHDVMuaVao_ultraCombo.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.RoyalBlue;
                col.Hidden = true;
            }
            NhomHHDVMuaVao_ultraCombo.DisplayLayout.Bands[0].Columns["MaQL"].Hidden = false;
            NhomHHDVMuaVao_ultraCombo.DisplayLayout.Bands[0].Columns["MaQL"].Header.Caption = "Mã nhóm";
            NhomHHDVMuaVao_ultraCombo.DisplayLayout.Bands[0].Columns["MaQL"].Header.VisiblePosition = 1;
            NhomHHDVMuaVao_ultraCombo.DisplayLayout.Bands[0].Columns["MaQL"].Width = 70;
            NhomHHDVMuaVao_ultraCombo.DisplayLayout.Bands[0].Columns["TenNhomHHDVMuaVao"].Hidden = false;
            NhomHHDVMuaVao_ultraCombo.DisplayLayout.Bands[0].Columns["TenNhomHHDVMuaVao"].Header.Caption = "Tên nhóm";
            NhomHHDVMuaVao_ultraCombo.DisplayLayout.Bands[0].Columns["TenNhomHHDVMuaVao"].Width = 500;
            NhomHHDVMuaVao_ultraCombo.DisplayLayout.Bands[0].Columns["TenNhomHHDVMuaVao"].Header.VisiblePosition = 2;
            FilterCombo f = new FilterCombo(grdu_ChiTietHoaDon, "NhomHHDVMuaVao", "TenNhomHHDVMuaVao");
        }


        public frmHoaDonDichVuMuaVao(ChungTu ct, HoaDon hd)
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
                if (_hoaDon.MaDoiTac != 0)
                {
                    txtu_MaSoThue.Text = DoiTac.GetDoiTac(_hoaDon.MaDoiTac).MaSoThue;
                }
            }
            cmbu_MauHD.Value = hd.MauHoaDon;
            _hoaDon.KyHieuMauHoaDon = hd.KyHieuMauHoaDon;
        }

        //Tạo Hóa Đơn Dịch Vụ Mua Vào Mới - Thành Viết (14/03/2012)
        public frmHoaDonDichVuMuaVao(ChungTu chungTu, ButToan butToan, bool _loai)
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

        private void LoadDataPhuongThucThanhToanList()
        {
            _phuongthucthanhtoanList = PhuongThucThanhToanList.GetPhuongThucThanhToanList();
            PhuongThucThanhToan pttt = PhuongThucThanhToan.NewPhuongThucThanhToan();
            pttt.MaQuanLyPTTT = "TM/CK";
            pttt.TenPhuongThucThanhToan = "TM/CK";
            _phuongthucthanhtoanList.Insert(0, pttt);
            phuongThucThanhToanListBindingSource.DataSource = _phuongthucthanhtoanList;
        }
        public void KhoiTao(HoaDon hd)
        {

            _hoaDon = hd;
            LoadDataPhuongThucThanhToanList();
            //            doiTacListBindingSource.DataSource = DoiTacList.GetDoiTacList(_hoaDon.MaDoiTac);
            hoaDonbindingSource.DataSource = _hoaDon;
            cTHoaDonDichVuListBindingSource.DataSource = _hoaDon.CT_HoaDonDichVuList;

        }
        private bool KiemTraMaSoThueHopLe()
        {
            //if (txtu_MaSoThue.Text.Length == 9 || (txtu_MaSoThue.Text.Length == 14 && txtu_MaSoThue.Text.Substring(10, 1) == "-") || txtu_MaSoThue.Text.Length == 13 || txtu_MaSoThue.Text.Length == 10)
            //{
            //    return false;
            //}
            return true;
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
            LoadDataPhuongThucThanhToanList();
            _DoiTacList = DoiTacList.GetDoiTacListByTen(0);
            //DoiTac _DoiTac = DoiTac.NewDoiTac(0, "Thêm Mới...");
            //_DoiTacList.Insert(0, _DoiTac);
            doiTacListBindingSource.DataSource = _DoiTacList;

        }
        private void KhoiTaoNew(long maDoiTac)
        {
            LoadDataPhuongThucThanhToanList();
            _DoiTacList = DoiTacList.GetDoiTacListByTen(0);

            //DoiTac _DoiTac = DoiTac.NewDoiTac(0, "Thêm Mới...");
            //_DoiTacList.Insert(0, _DoiTac);
            doiTacListBindingSource.DataSource = _DoiTacList;
            cmbu_KhachHang.Value = maDoiTac;

            NhomHHDVMVListBindingSource.DataSource = typeof(NhomHHDVMuaVao);
            NhomHHDVMVListBindingSource.DataSource = NhomHHDVMuaVaoList.GetNhomHHDVMuaVaoList();
            //
            NhomHHDVMuaVao_ultraCombo.DataSource = NhomHHDVMVListBindingSource;
            //NhomHHDVMuaVao_ultraCombo.DisplayLayout.Appearance = appearance19;
            NhomHHDVMuaVao_ultraCombo.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            NhomHHDVMuaVao_ultraCombo.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            NhomHHDVMuaVao_ultraCombo.DisplayMember = "TenNhomHHDVMuaVao";
            NhomHHDVMuaVao_ultraCombo.ValueMember = "Id";
            foreach (UltraGridColumn col in NhomHHDVMuaVao_ultraCombo.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.RoyalBlue;
                col.Hidden = true;
            }
            NhomHHDVMuaVao_ultraCombo.DisplayLayout.Bands[0].Columns["MaQL"].Hidden = false;
            NhomHHDVMuaVao_ultraCombo.DisplayLayout.Bands[0].Columns["MaQL"].Header.Caption = "Mã nhóm";
            NhomHHDVMuaVao_ultraCombo.DisplayLayout.Bands[0].Columns["MaQL"].Header.VisiblePosition = 1;
            NhomHHDVMuaVao_ultraCombo.DisplayLayout.Bands[0].Columns["MaQL"].Width = 70;
            NhomHHDVMuaVao_ultraCombo.DisplayLayout.Bands[0].Columns["TenNhomHHDVMuaVao"].Hidden = false;
            NhomHHDVMuaVao_ultraCombo.DisplayLayout.Bands[0].Columns["TenNhomHHDVMuaVao"].Header.Caption = "Tên nhóm";
            NhomHHDVMuaVao_ultraCombo.DisplayLayout.Bands[0].Columns["TenNhomHHDVMuaVao"].Width = 500;
            NhomHHDVMuaVao_ultraCombo.DisplayLayout.Bands[0].Columns["TenNhomHHDVMuaVao"].Header.VisiblePosition = 2;
            FilterCombo f = new FilterCombo(grdu_ChiTietHoaDon, "NhomHHDVMuaVao", "TenNhomHHDVMuaVao");


            ////DoiTac
            ////
            //DoiTac_ultraCombo.DataSource = doiTacListBindingSource;
            ////DoiTac_ultraCombo.DisplayLayout.Appearance = appearance19;
            //DoiTac_ultraCombo.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            //DoiTac_ultraCombo.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            //DoiTac_ultraCombo.DisplayMember = "TenDoiTac";
            //DoiTac_ultraCombo.ValueMember = "MaDoiTac";
            //foreach (UltraGridColumn col in DoiTac_ultraCombo.DisplayLayout.Bands[0].Columns)
            //{
            //    col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
            //    col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
            //    col.Header.Appearance.ForeColor = System.Drawing.Color.RoyalBlue;
            //    col.Hidden = true;
            //}
            //DoiTac_ultraCombo.DisplayLayout.Bands[0].Columns["MaQLDoiTac"].Hidden = false;
            //DoiTac_ultraCombo.DisplayLayout.Bands[0].Columns["MaQLDoiTac"].Header.Caption = "Mã QL";
            //DoiTac_ultraCombo.DisplayLayout.Bands[0].Columns["MaQLDoiTac"].Header.VisiblePosition = 1;
            //DoiTac_ultraCombo.DisplayLayout.Bands[0].Columns["MaQLDoiTac"].Width = 70;
            //DoiTac_ultraCombo.DisplayLayout.Bands[0].Columns["TenDoiTac"].Hidden = false;
            //DoiTac_ultraCombo.DisplayLayout.Bands[0].Columns["TenDoiTac"].Header.Caption = "Tên Đối Tác";
            //DoiTac_ultraCombo.DisplayLayout.Bands[0].Columns["TenDoiTac"].Width = 500;
            //DoiTac_ultraCombo.DisplayLayout.Bands[0].Columns["TenDoiTac"].Header.VisiblePosition = 2;
            //FilterCombo f1 = new FilterCombo(grdu_ChiTietHoaDon, "MaQLDoiTac", "TenDoiTac");
        }
        private void KhoiTao(long maDoiTac)
        {
            LoadDataPhuongThucThanhToanList();
            _DoiTacList = DoiTacList.GetDoiTacListByTen(0);

            //DoiTac _DoiTac = DoiTac.NewDoiTac(0, "Thêm Mới...");
            //_DoiTacList.Insert(0, _DoiTac);
            doiTacListBindingSource.DataSource = _DoiTacList;
            cmbu_KhachHang.Value = maDoiTac;
        }
        private void ThemMoi()
        {
            _hoaDon = HoaDon.NewHoaDon();
            hoaDonbindingSource.DataSource = _hoaDon;
            cTHoaDonDichVuListBindingSource.DataSource = _hoaDon.CT_HoaDonDichVuList;
            _hoaDon.MaDoiTac = maDoiTac;
            _hoaDon.LoaiHoaDon = 4;
            _hoaDon.MaHinhThucTT = 0;
            _hoaDon.NgayLap = _ngaylap;
            _hoaDon.NgayHetHanTT = _ngaylap;
            _hoaDon.MauHoaDon = "01GTKT";
            _hoaDon.KhauTruThue = true;

            txt_SoHoaDon.Focus();

            //_hdDOitac = HoaDon_DoiTac.NewHoaDon_DoiTac();
            //Binds_hoadon_Doitac.DataSource = _hdDOitac;

        }

        private void ThemMoi(PhieuNhapXuat phieuNX)
        {
            _hoaDon = HoaDon.NewHoaDon();
            decimal thanhtien = 0;
            decimal tongtien = 0;
            decimal tienChietkhau = 0;
            decimal tienthue = 0;

            foreach (CT_PhieuNhap ctpn in phieuNX.CT_PhieuNhapList)
            {
                CT_HoaDonDichVu ct_dichvu = CT_HoaDonDichVu.NewCT_HoaDonDichVu();
                HangHoaBQ_VT hanghoa = HangHoaBQ_VT.GetHangHoaBQ_VT(ctpn.MaHangHoa);
                ct_dichvu.TenHangHoaDichVu = hanghoa.TenHangHoa;
                ct_dichvu.SoLuong = (double)ctpn.SoLuong;
                ct_dichvu.DonGia = ctpn.DonGiaGoc;
                ct_dichvu.ThanhTien = ctpn.ThanhTienGoc;
                ct_dichvu.TyLeCK = ctpn.TyLeCK;
                ct_dichvu.TienChietKhau = ctpn.TienChietKhau;
                ct_dichvu.ThueSuatVAT = ctpn.ThueSuatVAT;
                ct_dichvu.TienThue = ctpn.TienThue;
                thanhtien += ctpn.ThanhTienGoc;
                tienChietkhau += ctpn.TienChietKhau;
                tienthue += ctpn.TienThue;
                _hoaDon.CT_HoaDonDichVuList.Add(ct_dichvu);
            }
            _hoaDon.MaDoiTac = maDoiTac;
            _hoaDon.LoaiHoaDon = 4;
            _hoaDon.MaHinhThucTT = 0;
            _hoaDon.NgayLap = _ngaylap;
            _hoaDon.NgayHetHanTT = _ngaylap;
            _hoaDon.MauHoaDon = "01GTKT";
            _hoaDon.KhauTruThue = true;
            _hoaDon.ThueSuatVAT = phieuNX.CT_PhieuNhapList.Count > 0 ? phieuNX.CT_PhieuNhapList[0].ThueSuatVAT : 0;
            _hoaDon.ThanhTien = thanhtien;
            _hoaDon.SoTienChietKhau = tienChietkhau;
            _hoaDon.ThueVAT = tienthue;
            _hoaDon.TongTien = thanhtien - tienChietkhau + tienthue;
            hoaDonbindingSource.DataSource = _hoaDon;
            cTHoaDonDichVuListBindingSource.DataSource = _hoaDon.CT_HoaDonDichVuList;

            txt_SoHoaDon.Focus();

            //_hdDOitac = HoaDon_DoiTac.NewHoaDon_DoiTac();
            //Binds_hoadon_Doitac.DataSource = _hdDOitac;

        }
        private void ThemMoi(int loai)
        {
            _hoaDon = HoaDon.NewHoaDon();
            cTHoaDonDichVuListBindingSource.DataSource = _hoaDon.CT_HoaDonDichVuList;
            _hoaDon.LoaiHoaDon = loai;
            hoaDonbindingSource.DataSource = _hoaDon;
            _hoaDon.MaHinhThucTT = 1;
            _hoaDon.NgayHetHanTT = _ngaylap;
            _hoaDon.NgayLap = _ngaylap;
            _hoaDon.MauHoaDon = "01GTKT";
            //_hdDOitac = HoaDon_DoiTac.NewHoaDon_DoiTac();
            //Binds_hoadon_Doitac.DataSource = _hdDOitac;
        }

        decimal soTienTruocThue;
        decimal tienThue;
        private void ThemMoi(ChungTu chungTu, ButToan butToan, bool loai)
        {
            soTienTruocThue = 0;
            tienThue = 0;
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
            _hoaDon.NgayLap = chungTu.NgayLap;
            // _hoaDon.NgayHetHanTT = _hoaDon.NgayLap.AddMonths(6);
            // dtp_NgayHetHanTT.Value = _hoaDon.NgayLap.AddMonths(6);
            _hoaDon.MaDoiTac = chungTu.DoiTuong;

            _hoaDon.LoaiHoaDon = 4;
            _hoaDon.MaHinhThucTT = 2;
            _hoaDon.NgayLap = chungTu.NgayLap;
            _hoaDon.NgayHetHanTT = _hoaDon.NgayLap.AddMonths(6);
            _hoaDon.ThanhTien = soTienTruocThue;
            _hoaDon.ThueSuatVAT = 10;
            if (butToan != null)
                _hoaDon.GhiChu = butToan.DienGiai;
            _hoaDon.KhauTruThue = loai;
            _hoaDon.MauHoaDon = "01GTKT";
            _hoaDon.KhauTruThue = true;

            hoaDonbindingSource.DataSource = _hoaDon;
            cTHoaDonDichVuListBindingSource.DataSource = _hoaDon.CT_HoaDonDichVuList;
            txt_SoHoaDon.Focus();
            //_hdDOitac = HoaDon_DoiTac.NewHoaDon_DoiTac();
            //Binds_hoadon_Doitac.DataSource = _hdDOitac;
            if (_chungTu.DoiTuong != 0)
                txtu_MaSoThue.Text = DoiTac.GetDoiTacWithoutChild(_chungTu.DoiTuong).MaSoThue; //DoiTac.GetDoiTac(_chungTu.DoiTuong).MaSoThue;
        }

        #endregion

        private void luuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            label1.Focus();

            if (KiemTraDuLieu() == true)
            {
                try
                {
                    if (KiemTraMaSoThueHopLe())//
                    {
                        hoaDonbindingSource.EndEdit();
                        _hoaDon.ApplyEdit();
                        int hoadon;
                        hoadon = HoaDon.KiemTraHoaDon(_hoaDon.SoHoaDon, _hoaDon.SoSerial, _hoaDon.MaDoiTac, _hoaDon.TongTien, _hoaDon.NgayLap.Year);
                        if (_hoaDon.IsNew)
                        {
                            if (hoadon > 0)
                            {
                                MessageBox.Show(this, "Hóa đơn này đã tồn tại rồi vui lòng kiểm tra lại", util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                        }
                        //if (_chungTu.NgayLap.AddMonths(6).Month != _hoaDon.NgayHetHanTT.Month)
                        //{
                        //    MessageBox.Show(this, "Hóa đơn này hết hạn thanh toán vui lòng kiểm tra lại", util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        //    return;
                        //}

                        else if (HamDungChung.KiemTraLaSo(txt_SoHoaDon.Text) == false)
                        {
                            MessageBox.Show(this, "Vui Lòng Nhập Số", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            txt_SoHoaDon.Focus();
                            return;
                        }
                        else if (_chungTu != null)
                        {
                            if (dtp_NgayLap.DateTime.Date > _chungTu.NgayLap.Date)
                            {
                                MessageBox.Show(this, "Ngày lập hóa đơn phải nhỏ hơn hoạt bằng ngày lập chứng từ", util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                dtp_NgayLap.Focus();
                                return;
                            }
                        }
                        if (_hoaDon.CT_HoaDonDichVuList.Count > 0)
                            _hoaDon.NhomHHDVMuaVao = 0;
                        else
                        {
                            //if (cb_LoaiHD.Checked == true)
                            //    _hoaDon.NhomHHDVMuaVao = 4;
                            //else
                            //    _hoaDon.NhomHHDVMuaVao = 3;
                        }
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
                        else
                        {
                            _hdDOitac = HoaDon_DoiTac.GetHoaDon_DoiTacByHoaDon(_hoaDon.MaHoaDon);
                            if (_hdDOitac != null && _hdDOitac.MaHoaDon != 0)
                            {
                                _hdDOitac.Delete();
                                _hdDOitac.Save();
                            }
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
            label1.Focus();

            hoaDonbindingSource.EndEdit();
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
                txt_SoSerial.Focus();
                kq = false;
            }
            else if (cmb_HinhThucTT.Text == "")
            {
                MessageBox.Show(this, "Chưa Chọn Phương Thức Thanh Toán", util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmb_HinhThucTT.Focus();
                kq = false;
            }

            //else if (txt_DienGiai.Text == "" || txt_DienGiai.Text == null)
            //{
            //    MessageBox.Show(this, "Diễn giải không được để trống", util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    txt_DienGiai.Focus();
            //    kq = false;
            //}
            //else if (string.IsNullOrEmpty(_hoaDon.MauHoaDon))
            //{
            //    MessageBox.Show(this, "Vui lòng chọn mẫu hóa đơn", util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    cmbu_MauHD.Focus();
            //    kq = false;
            //}
            //else if (string.IsNullOrEmpty(_hoaDon.KyHieuMauHoaDon))
            //{
            //    MessageBox.Show(this, "Vui lòng nhập ký hiệu mẫu hóa đơn", util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    txt_KyHieuMauHD.Focus();
            //    kq = false;
            //}
            else if (HoaDon.KiemTraTrungSoHoaDon(_hoaDon.SoHoaDon, _hoaDon.MauHoaDon, _hoaDon.KyHieuMauHoaDon, _hoaDon.MaHoaDon, _hoaDon.NgayLap, _hoaDon.SoSerial, 0) > 0)
            {
                MessageBox.Show("Trùng Ký hiệu mẫu hóa đơn và Số hóa đơn, không hợp lệ!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                gridLookUpEdit1.Visible = true;
                //DoiTuongGridLookUpEdit.Visible = true;
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
                txtu_MaSoThue.ReadOnly = false;
                cmbu_KhachHang.Visible = false;
                gridLookUpEdit1.Visible = false;
                //DoiTuongGridLookUpEdit.Visible = false;
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

        private void LoadDoiTuongList()
        {
            _DoiTacList = DoiTacList.GetDoiTacListByTen(0);
            //DoiTac _DoiTac = DoiTac.NewDoiTac(0, "Thêm Mới...");
            //_DoiTacList.Insert(0, _DoiTac);
            doiTacListBindingSource.DataSource = _DoiTacList;
        }

        private void DesignDoiTuongGridLookUpEdit()
        {
            HamDungChung.InitGridLookUpDev2(DoiTuongGridLookUpEdit, doiTacListBindingSource, "TenDoiTac", "MaDoiTac", "", true, true, DevExpress.XtraEditors.Controls.TextEditStyles.Standard);
            HamDungChung.ShowFieldGridLookUpDev2(DoiTuongGridLookUpEdit, new string[] { "TenDoiTac", "MaQLDoiTac", "MaSoThue", }, new string[] { "Tên đối tác", "Mã đối tác", "Mã số thuế", }, new int[] { 120, 90, 90 }, false);
            this.DoiTuongGridLookUpEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Plus, "Thêm đối tác", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None))});
            this.DoiTuongGridLookUpEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Undo, "Làm mới danh sách đối tác", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None))});
            this.DoiTuongGridLookUpEdit.Properties.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.DoiTuongGridLookUpEdit_Properties_ButtonClick);
            //this.DoiTuongGridLookUpEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            //new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Plus, "Thêm đối tượng", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2, "Khác/Thêm", null, superToolTip5, true)});
            DoiTuongGridLookUpEdit.EditValueChanged += new System.EventHandler(this.DoiTuongGridLookUpEdit_EditValueChanged);
        }

        private void DesignControls()
        {
            DesignDoiTuongGridLookUpEdit();
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

        //private void cmbu_KhachHang_AfterCloseUp(object sender, EventArgs e)
        //{
        //    long ma = 0;
        //    if (cmbu_KhachHang.ActiveRow != null)
        //    {                            
        //        if (cmbu_KhachHang.Text == "Thêm Mới...")
        //        {                                                                         
        //            frmKhachHang _frmKhachHang = new frmKhachHang();
        //            if (_frmKhachHang.ShowDialog() != DialogResult.OK)
        //            {
        //                _DoiTacList = DoiTacList.GetDoiTacListByTen(0);
        //                //DoiTac _DoiTac = DoiTac.NewDoiTac(0, "Thêm Mới...");
        //                //_DoiTacList.Insert(0, _DoiTac);
        //                ma = _DoiTacList[_DoiTacList.Count - 1].MaDoiTac;
        //                cmbu_KhachHang.Value = ma;

        //                diaChiDoiTacListBindingSource.DataSource = DoiTac.GetDoiTac(ma).DiaChi_DoiTacList;
        //                doiTacDienThoaiFaxListBindingSource.DataSource = DoiTac.GetDoiTac(ma).DoiTac_DienThoai_FaxList;
        //                doiTacListBindingSource.DataSource = _DoiTacList;
        //            }
        //        }
        //    }
        //}

        private void cmbu_KhachHang_ValueChanged(object sender, EventArgs e)
        {
            if (cmbu_KhachHang.ActiveRow != null)
            {
                txtu_MaSoThue.ReadOnly = true;
                if (cmbu_KhachHang.Text != "Thêm Mới...")
                {
                    //diaChiDoiTacListBindingSource.DataSource = DoiTac.GetDoiTac((long)cmbu_KhachHang.Value).DiaChi_DoiTacList;
                    //doiTacDienThoaiFaxListBindingSource.DataSource = DoiTac.GetDoiTac((long)cmbu_KhachHang.Value).DoiTac_DienThoai_FaxList;

                    diaChiDoiTacListBindingSource.DataSource = DoiTac.GetDoiTacForTaoHoaDonDichVu((long)cmbu_KhachHang.Value).DiaChi_DoiTacList;
                    doiTacDienThoaiFaxListBindingSource.DataSource = DoiTac.GetDoiTacForTaoHoaDonDichVu((long)cmbu_KhachHang.Value).DoiTac_DienThoai_FaxList;
                }
            }
        }


        private void gridLookUpEdit1_EditValueChanged(object sender, EventArgs e)
        {
            if (gridLookUpEdit1.Text != "[EditValue is null]" && gridLookUpEdit1.Text != "")
            {
                txtu_MaSoThue.ReadOnly = true;
                //if (gridLookUpEdit1.!= "Thêm Mới...")
                //
                DoiTac doitac = DoiTac.GetDoiTacForTaoHoaDonDichVu(Convert.ToInt64(gridLookUpEdit1.EditValue));
                _hoaDon.MaDoiTac = Convert.ToInt32(gridLookUpEdit1.EditValue.ToString()); //bị lỗi không binding được lên cbo nên gán
                txtu_MaSoThue.Text = doitac.MaSoThue;
                diaChiDoiTacListBindingSource.DataSource = doitac.DiaChi_DoiTacList;
                doiTacDienThoaiFaxListBindingSource.DataSource = doitac.DoiTac_DienThoai_FaxList;
                if (cmb_DiaChi.SelectedValue != null)
                    _hoaDon.MaDCGuiHD = Convert.ToInt32(cmb_DiaChi.SelectedValue.ToString()); //bị lỗi không binding được lên cbo nên gán

                //txtu_MaSoThue.Text = ((ERP_Library.DoiTac)(gridLookUpEdit1.GetSelectedDataRow())).MaSoThue;
                //diaChiDoiTacListBindingSource.DataSource = DoiTac.GetDoiTac(Convert.ToInt64(gridLookUpEdit1.EditValue)).DiaChi_DoiTacList;
                //doiTacDienThoaiFaxListBindingSource.DataSource = DoiTac.GetDoiTac(Convert.ToInt64(gridLookUpEdit1.EditValue)).DoiTac_DienThoai_FaxList;
                //}
            }

        }

        private void frmHoaDonDichVuMuaVao_Load(object sender, EventArgs e)
        {
            DanhMucMauHoaDonList danhMucMauHoaDonList = DanhMucMauHoaDonList.GetDanhMucMauHoaDonList();
            mauHDBindingSource.DataSource = danhMucMauHoaDonList;
            DesignControls();
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
                    _hoaDon.KyHieuMauHoaDon = Convert.ToString(cmbu_MauHD.Value).Trim() + "/";
                }

            }
        }
        Boolean capNhatHoaDon = false;
        private void cmbu_MauHD_MouseClick(object sender, MouseEventArgs e)
        {
            capNhatHoaDon = true;
        }

        private void grdu_ChiTietHoaDon_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            this.grdu_ChiTietHoaDon.DisplayLayout.Override.HeaderStyle = HeaderStyle.WindowsXPCommand;
            this.grdu_ChiTietHoaDon.DisplayLayout.Override.HeaderAppearance.BackColor = System.Drawing.Color.SteelBlue;
            foreach (UltraGridColumn col in this.grdu_ChiTietHoaDon.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;
                col.Hidden = true;
            }
            //


            //NhomHHDVMuaVao_ultraCombo.ValueChanged += new System.EventHandler(this.ultraCombo_CoTaiKhoan_ValueChanged);
            //NhomHHDVMuaVao_ultraCombo.Leave += new System.EventHandler(this.ultraCombo_CoTaiKhoan_Leave);

            ////
            //"TenHangHoaDichVu","MaDonViTinh", "SoLuong", "DonGia", "ThanhTien","ThueSuatVAT","TienThue"

            grdu_ChiTietHoaDon.DisplayLayout.Bands[0].Columns["TenHangHoaDichVu"].Hidden = false;
            grdu_ChiTietHoaDon.DisplayLayout.Bands[0].Columns["TenHangHoaDichVu"].Header.Caption = "Hàng Hóa/Dịch Vụ";
            grdu_ChiTietHoaDon.DisplayLayout.Bands[0].Columns["TenHangHoaDichVu"].Header.VisiblePosition = 1;

            //grdu_ChiTietHoaDon.DisplayLayout.Bands[0].Columns["MaDoiTac"].Hidden = false;
            //grdu_ChiTietHoaDon.DisplayLayout.Bands[0].Columns["MaDoiTac"].Header.Caption = "Đối Tác";
            //grdu_ChiTietHoaDon.DisplayLayout.Bands[0].Columns["MaDoiTac"].Header.VisiblePosition = 2;
            //grdu_ChiTietHoaDon.DisplayLayout.Bands[0].Columns["MaDoiTac"].EditorComponent = DoiTac_ultraCombo;

            grdu_ChiTietHoaDon.DisplayLayout.Bands[0].Columns["SoLuong"].Hidden = false;
            grdu_ChiTietHoaDon.DisplayLayout.Bands[0].Columns["SoLuong"].Header.Caption = "Số Lượng";
            grdu_ChiTietHoaDon.DisplayLayout.Bands[0].Columns["SoLuong"].Header.VisiblePosition = 2;
            grdu_ChiTietHoaDon.DisplayLayout.Bands[0].Columns["SoLuong"].MaskInput = "nnnnnnnnn";


            grdu_ChiTietHoaDon.DisplayLayout.Bands[0].Columns["DonGia"].Hidden = false;
            grdu_ChiTietHoaDon.DisplayLayout.Bands[0].Columns["DonGia"].Header.Caption = "Đơn Giá";
            grdu_ChiTietHoaDon.DisplayLayout.Bands[0].Columns["DonGia"].Header.VisiblePosition = 3;
            grdu_ChiTietHoaDon.DisplayLayout.Bands[0].Columns["DonGia"].MaskInput = "{LOC}nnn,nnn,nnn,nnn,nnn.nn";
            grdu_ChiTietHoaDon.DisplayLayout.Bands[0].Columns["DonGia"].Format = "###,###,###,###,###";
            grdu_ChiTietHoaDon.DisplayLayout.Bands[0].Columns["DonGia"].CellAppearance.TextHAlign = HAlign.Right;

            grdu_ChiTietHoaDon.DisplayLayout.Bands[0].Columns["ThanhTien"].Hidden = false;
            grdu_ChiTietHoaDon.DisplayLayout.Bands[0].Columns["ThanhTien"].Header.Caption = "Thành Tiền";
            grdu_ChiTietHoaDon.DisplayLayout.Bands[0].Columns["ThanhTien"].Header.VisiblePosition = 4;
            grdu_ChiTietHoaDon.DisplayLayout.Bands[0].Columns["ThanhTien"].MaskInput = "{LOC}nnn,nnn,nnn,nnn,nnn.nn";
            grdu_ChiTietHoaDon.DisplayLayout.Bands[0].Columns["ThanhTien"].Format = "###,###,###,###,###";
            grdu_ChiTietHoaDon.DisplayLayout.Bands[0].Columns["ThanhTien"].CellAppearance.TextHAlign = HAlign.Right;

            grdu_ChiTietHoaDon.DisplayLayout.Bands[0].Columns["TyLeCK"].Hidden = false;
            grdu_ChiTietHoaDon.DisplayLayout.Bands[0].Columns["TyLeCK"].Header.Caption = "Tỷ lệ CK(%)";
            grdu_ChiTietHoaDon.DisplayLayout.Bands[0].Columns["TyLeCK"].Header.VisiblePosition = 5;
            grdu_ChiTietHoaDon.DisplayLayout.Bands[0].Columns["TyLeCK"].MaskInput = "nnnnnnnnn";


            grdu_ChiTietHoaDon.DisplayLayout.Bands[0].Columns["TienChietKhau"].Hidden = false;
            grdu_ChiTietHoaDon.DisplayLayout.Bands[0].Columns["TienChietKhau"].Header.Caption = "Tiền chiết khấu";
            grdu_ChiTietHoaDon.DisplayLayout.Bands[0].Columns["TienChietKhau"].Header.VisiblePosition = 6;
            grdu_ChiTietHoaDon.DisplayLayout.Bands[0].Columns["TienChietKhau"].MaskInput = "{LOC}nnn,nnn,nnn,nnn,nnn.nn";
            grdu_ChiTietHoaDon.DisplayLayout.Bands[0].Columns["TienChietKhau"].Format = "###,###,###,###,###";
            grdu_ChiTietHoaDon.DisplayLayout.Bands[0].Columns["TienChietKhau"].CellAppearance.TextHAlign = HAlign.Right;

            grdu_ChiTietHoaDon.DisplayLayout.Bands[0].Columns["ThueSuatVAT"].Hidden = false;
            grdu_ChiTietHoaDon.DisplayLayout.Bands[0].Columns["ThueSuatVAT"].Header.Caption = "Thuế suất VAT";
            grdu_ChiTietHoaDon.DisplayLayout.Bands[0].Columns["ThueSuatVAT"].Header.VisiblePosition = 7;
            grdu_ChiTietHoaDon.DisplayLayout.Bands[0].Columns["ThueSuatVAT"].MaskInput = "nnnnnnnnn";


            grdu_ChiTietHoaDon.DisplayLayout.Bands[0].Columns["TienThue"].Hidden = false;
            grdu_ChiTietHoaDon.DisplayLayout.Bands[0].Columns["TienThue"].Header.Caption = "Tiền thuế VAT";
            grdu_ChiTietHoaDon.DisplayLayout.Bands[0].Columns["TienThue"].Header.VisiblePosition = 8;
            grdu_ChiTietHoaDon.DisplayLayout.Bands[0].Columns["TienThue"].MaskInput = "{LOC}nnn,nnn,nnn,nnn,nnn.nn";
            grdu_ChiTietHoaDon.DisplayLayout.Bands[0].Columns["TienThue"].Format = "###,###,###,###,###";
            grdu_ChiTietHoaDon.DisplayLayout.Bands[0].Columns["TienThue"].CellAppearance.TextHAlign = HAlign.Right;


            grdu_ChiTietHoaDon.DisplayLayout.Bands[0].Columns["NhomHHDVMuaVao"].Hidden = false;
            grdu_ChiTietHoaDon.DisplayLayout.Bands[0].Columns["NhomHHDVMuaVao"].Header.Caption = "Nhóm HHDV mua vào";
            grdu_ChiTietHoaDon.DisplayLayout.Bands[0].Columns["NhomHHDVMuaVao"].Header.VisiblePosition = 9;
            grdu_ChiTietHoaDon.DisplayLayout.Bands[0].Columns["NhomHHDVMuaVao"].EditorComponent = NhomHHDVMuaVao_ultraCombo; //--ultraCbDonViTinh;



            this.grdu_ChiTietHoaDon.DisplayLayout.Override.HeaderStyle = HeaderStyle.WindowsXPCommand;
            this.grdu_ChiTietHoaDon.DisplayLayout.Override.HeaderAppearance.BackColor = System.Drawing.Color.SteelBlue;
            foreach (UltraGridColumn col in this.grdu_ChiTietHoaDon.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;//x =  //= System.Drawing.w;//RoyalBlue
            }
            hamDungChung.ultragrdEmail_InitializeLayout(sender, e);



        }


        #region EventHandles

        private void DoiTuongGridLookUpEdit_Properties_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Plus)
            {
                frmKhachHangDoiTacCustomize frmKhachHang = new frmKhachHangDoiTacCustomize(true);
                if (frmKhachHang.ShowDialog(this) != DialogResult.OK)
                {
                    if (frmKhachHang.MaDoiTac != 0)
                    {
                        LoadDoiTuongList();
                        DoiTuongGridLookUpEdit.EditValue = frmKhachHang.MaDoiTac;
                    }
                }
            }
            else if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Undo)
            {
                LoadDoiTuongList();
            }
        }

        private void DoiTuongGridLookUpEdit_EditValueChanged(object sender, EventArgs e)
        {
            if (DoiTuongGridLookUpEdit.Text != "[EditValue is null]" && DoiTuongGridLookUpEdit.Text != "")
            {
                txtu_MaSoThue.ReadOnly = true;
                //if (DoiTuongGridLookUpEdit.!= "Thêm Mới...")
                //
                DoiTac doitac = DoiTac.GetDoiTacForTaoHoaDonDichVu(Convert.ToInt64(DoiTuongGridLookUpEdit.EditValue));
                txtu_MaSoThue.Text = doitac.MaSoThue;

                DoiTacList dtList = DoiTacList.NewDoiTacList();
                dtList.Add(doitac);
                diaChiDoiTacListBindingSource.DataSource = doitac.DiaChi_DoiTacList;
                //diaChiDoiTacListBindingSource.DataSource = dtList;
                //diaChiDoiTacListBindingSource.DataMember = "DiaChi_DoiTacList";

                doiTacDienThoaiFaxListBindingSource.DataSource = doitac.DoiTac_DienThoai_FaxList;

                //txtu_MaSoThue.Text = ((ERP_Library.DoiTac)(DoiTuongGridLookUpEdit.GetSelectedDataRow())).MaSoThue;
                //diaChiDoiTacListBindingSource.DataSource = DoiTac.GetDoiTac(Convert.ToInt64(DoiTuongGridLookUpEdit.EditValue)).DiaChi_DoiTacList;
                //doiTacDienThoaiFaxListBindingSource.DataSource = DoiTac.GetDoiTac(Convert.ToInt64(DoiTuongGridLookUpEdit.EditValue)).DoiTac_DienThoai_FaxList;
                //}
            }

        }

        #endregion EventHandles

        private void gridLookUpEdit1_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Plus)
            {
                frmKhachHangDoiTacCustomize frmKhachHang = new frmKhachHangDoiTacCustomize(true);
                if (frmKhachHang.ShowDialog(this) != DialogResult.OK)
                {
                    if (frmKhachHang.MaDoiTac != 0)
                    {
                        LoadDoiTuongList();
                        gridLookUpEdit1.EditValue = frmKhachHang.MaDoiTac;
                    }
                }
            }
            else if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Undo)
            {
                LoadDoiTuongList();
            }
        }

        private void NhomHHDVMuaVao_ultraCombo_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            //NhomHHDVMuaVao
            NhomHHDVMVListBindingSource.DataSource = typeof(NhomHHDVMuaVao);
            NhomHHDVMVListBindingSource.DataSource = NhomHHDVMuaVaoList.GetNhomHHDVMuaVaoList();
            //
            NhomHHDVMuaVao_ultraCombo.DataSource = NhomHHDVMVListBindingSource;
            //NhomHHDVMuaVao_ultraCombo.DisplayLayout.Appearance = appearance19;
            NhomHHDVMuaVao_ultraCombo.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            NhomHHDVMuaVao_ultraCombo.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            NhomHHDVMuaVao_ultraCombo.DisplayMember = "TenNhomHHDVMuaVao";
            NhomHHDVMuaVao_ultraCombo.ValueMember = "Id";
            foreach (UltraGridColumn col in NhomHHDVMuaVao_ultraCombo.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.RoyalBlue;
                col.Hidden = true;
            }
            NhomHHDVMuaVao_ultraCombo.DisplayLayout.Bands[0].Columns["MaQL"].Hidden = false;
            NhomHHDVMuaVao_ultraCombo.DisplayLayout.Bands[0].Columns["MaQL"].Header.Caption = "Mã nhóm";
            NhomHHDVMuaVao_ultraCombo.DisplayLayout.Bands[0].Columns["MaQL"].Header.VisiblePosition = 1;
            NhomHHDVMuaVao_ultraCombo.DisplayLayout.Bands[0].Columns["MaQL"].Width = 70;
            NhomHHDVMuaVao_ultraCombo.DisplayLayout.Bands[0].Columns["TenNhomHHDVMuaVao"].Hidden = false;
            NhomHHDVMuaVao_ultraCombo.DisplayLayout.Bands[0].Columns["TenNhomHHDVMuaVao"].Header.Caption = "Tên nhóm";
            NhomHHDVMuaVao_ultraCombo.DisplayLayout.Bands[0].Columns["TenNhomHHDVMuaVao"].Width = 500;
            NhomHHDVMuaVao_ultraCombo.DisplayLayout.Bands[0].Columns["TenNhomHHDVMuaVao"].Header.VisiblePosition = 2;
            FilterCombo f = new FilterCombo(grdu_ChiTietHoaDon, "NhomHHDVMuaVao", "TenNhomHHDVMuaVao");
        }


        private void grdu_ChiTietHoaDon_AfterCellUpdate(object sender, CellEventArgs e)
        {
            Decimal _tongTien = 0;
            decimal _chietKhau = 0;
            double _tyleCK = 0;
            decimal _chiTietCK = 0;
            decimal _thanhTien = 0;

            UltraGridRow row = grdu_ChiTietHoaDon.ActiveRow;
            _tyleCK = (double)row.Cells["TyLeCK"].Value;
            _thanhTien = (decimal)row.Cells["ThanhTien"].Value;
            _chiTietCK = Math.Round((_thanhTien * (decimal)_tyleCK) / 100, 0, MidpointRounding.AwayFromZero);
            

            if (grdu_ChiTietHoaDon.ActiveCell == grdu_ChiTietHoaDon.ActiveRow.Cells["ThanhTien"]
                || grdu_ChiTietHoaDon.ActiveCell == grdu_ChiTietHoaDon.ActiveRow.Cells["SoLuong"]
                || grdu_ChiTietHoaDon.ActiveCell == grdu_ChiTietHoaDon.ActiveRow.Cells["DonGia"]
               )
            {
                row.Cells["TienChietKhau"].Value = _chiTietCK;

                if (_hoaDon.LoaiHoaDon == 4)
                {
                    foreach (CT_HoaDonDichVu ct_HoaDonDichVu in _hoaDon.CT_HoaDonDichVuList)
                    {
                        _tongTien = _tongTien + ct_HoaDonDichVu.ThanhTien;
                        _chietKhau = _chietKhau + ct_HoaDonDichVu.TienChietKhau;
                    }
                    _hoaDon.ThanhTien = _tongTien;
                    _hoaDon.SoTienChietKhau = _chietKhau;

                    hoaDonbindingSource.DataSource = _hoaDon;
                }
            }
        }


    }
}

