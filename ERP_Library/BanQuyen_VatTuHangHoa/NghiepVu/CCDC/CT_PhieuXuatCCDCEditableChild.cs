
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;
using System.Windows.Forms;
//13_04_2013
namespace ERP_Library
{
    [Serializable()]
    public class CT_PhieuXuatCCDC : Csla.BusinessBase<CT_PhieuXuatCCDC>
    {
        #region Business Properties and Methods

        //declare members
        private int _maChiTietPhieuXuat = 0;
        private long _maPhieuxuat = 0;
        private decimal _soLuong = 0;
        private int _maDonViTinh = 0;
        private decimal _donGia = 0;
        private decimal _thanhTien = 0;
        private decimal _thoiLuong = 0;
        private int _maHangHoa = 0;
        private int _maChuongTrinhCon = 0;//M Ban Quyen
        private string _dienGiai = string.Empty;
        private long _maPhieuNhap = 0;
        private string _soPhieuNhap = string.Empty;
        private SmartDate _ngayPhatSong = new SmartDate(DateTime.MinValue); //new SmartDate(DateTime.Today);
        //private SmartDate _ngayNghiemThu = new SmartDate(DateTime.Today);
        private String _ngayNghiemThu = string.Empty;
        private int _maNguon = 0;
        private long _maHopDong = 0;//M
        private decimal _sLgCt_PNhap = 0;//M
        private bool _chonTuDSCTPhieu = false;
        private decimal _donGiaCT_PNhap = 0;//M
        private decimal _soLuongLuu = 0;//M
        private decimal _thanhTienLuu = 0;//M
        private decimal _donGiaLuu = 0;//M
        private decimal _thanhTienCT_PNhap = 0;

        private string _MoTaTenCCDC = string.Empty;

        private double _tyLeCK = 0;
        private decimal _tienChietKhau = 0;
        private decimal _chiPhiMuaHang = 0;
        private double _thueSuatVAT = 0;
        private decimal _tienThue = 0;

        private decimal _donGiaGoc = 0;
        private decimal _thanhTienGoc = 0;
        private int _maChiTietPhieuNhap = 0;
        private long _maCT_KetChuyen = 0;
        private long _maCT_KetChuyenCCDC = 0;
        private int _maTruong = 0;

        [System.ComponentModel.DataObjectField(true, true)]
        public int MaChiTietPhieuXuat
        {
            get
            {
                CanReadProperty("MaChiTietPhieuXuat", true);
                return _maChiTietPhieuXuat;
            }
        }

        public long MaPhieuxuat
        {
            get
            {
                CanReadProperty("MaPhieuxuat", true);
                return _maPhieuxuat;
            }
            set
            {
                CanWriteProperty("MaPhieuxuat", true);
                if (!_maPhieuxuat.Equals(value))
                {
                    _maPhieuxuat = value;
                    PropertyHasChanged("MaPhieuxuat");
                }
            }
        }

        public decimal SoLuong
        {
            get
            {
                CanReadProperty("SoLuong", true);
                return _soLuong;
            }
            set
            {
                CanWriteProperty("SoLuong", true);
                if (!_soLuong.Equals(value))
                {
                    _soLuong = value;
                    if (_donGia != 0)
                        _thanhTien = TinhThanhTien(_soLuong, _donGia);
                    PropertyHasChanged("SoLuong");
                }
            }
        }
        public static decimal TinhThanhTien(decimal soLuong, decimal donGia)
        {
            return Math.Round(soLuong * donGia, 0, MidpointRounding.AwayFromZero);
        }

        public int MaDonViTinh
        {
            get
            {
                CanReadProperty("MaDonViTinh", true);
                return _maDonViTinh;
            }
            set
            {
                CanWriteProperty("MaDonViTinh", true);
                if (!_maDonViTinh.Equals(value))
                {
                    _maDonViTinh = value;
                    PropertyHasChanged("MaDonViTinh");
                }
            }
        }

        public decimal DonGia
        {
            get
            {
                CanReadProperty("DonGia", true);
                return _donGia;
            }
            set
            {
                CanWriteProperty("DonGia", true);
                if (!_donGia.Equals(value))
                {
                    _donGia = value;
                    PropertyHasChanged("DonGia");
                }
            }
        }

        public decimal ThanhTien
        {
            get
            {
                CanReadProperty("ThanhTien", true);
                return _thanhTien;
            }
            set
            {
                CanWriteProperty("ThanhTien", true);
                if (!_thanhTien.Equals(value))
                {
                    _thanhTien = value;
                    PropertyHasChanged("ThanhTien");
                }
            }
        }

        public decimal ThoiLuong
        {
            get
            {
                CanReadProperty("ThoiLuong", true);
                return _thoiLuong;
            }
            set
            {
                CanWriteProperty("ThoiLuong", true);
                if (!_thoiLuong.Equals(value))
                {
                    _thoiLuong = value;
                    PropertyHasChanged("ThoiLuong");
                }
            }
        }

        public int MaHangHoa
        {
            get
            {
                CanReadProperty("MaHangHoa", true);
                return _maHangHoa;
            }
            set
            {
                CanWriteProperty("MaHangHoa", true);
                if (!_maHangHoa.Equals(value))
                {
                    _maHangHoa = value;
                    PropertyHasChanged("MaHangHoa");
                }
            }
        }
        public int MaChuongTrinhCon//M Ban Quyen
        {
            get
            {
                CanReadProperty("MaChuongTrinhCon", true);
                return _maChuongTrinhCon;
            }
            set
            {
                CanWriteProperty("MaChuongTrinhCon", true);
                if (!_maChuongTrinhCon.Equals(value))
                {
                    _maChuongTrinhCon = value;
                    PropertyHasChanged("MaChuongTrinhCon");
                }
            }
        }

        public string DienGiai
        {
            get
            {
                CanReadProperty("DienGiai", true);
                return _dienGiai;
            }
            set
            {
                CanWriteProperty("DienGiai", true);
                if (value == null) value = string.Empty;
                if (!_dienGiai.Equals(value))
                {
                    _dienGiai = value;
                    PropertyHasChanged("DienGiai");
                }
            }
        }

        public long MaPhieuNhap
        {
            get
            {
                CanReadProperty("MaPhieuNhap", true);
                return _maPhieuNhap;

            }
            set
            {
                CanWriteProperty("MaPhieuNhap", true);
                if (!_maPhieuNhap.Equals(value))
                {
                    _maPhieuNhap = value;
                    PropertyHasChanged("MaPhieuNhap");
                    //
                    _soPhieuNhap = PhieuNhapXuatCCDC.GetPhieuNhapXuat(_maPhieuNhap).SoPhieu;
                }
            }
        }
        public string SoPhieuNhap
        {
            get
            {
                CanReadProperty("MaPhieuNhap", true);
                return _soPhieuNhap;
            }

        }

        public DateTime? NgayPhatSong
        {
            get
            {
                CanReadProperty("NgayPhatSong", true);
                if (_ngayPhatSong.Date == DateTime.MinValue)
                    return null;
                return _ngayPhatSong.Date;
            }
            set
            {
                CanWriteProperty("NgayPhatSong", true);
                if (!_ngayPhatSong.Date.Equals(value))
                {
                    if (value == null)
                    {
                        _ngayPhatSong = new SmartDate(DateTime.MinValue);
                    }
                    else
                    {
                        _ngayPhatSong = new SmartDate(value.Value.Date);
                    }
                    PropertyHasChanged("NgayPhatSong");
                }
            }
        }

        //public string NgayPhatSongString
        //{
        //    get
        //    {
        //        CanReadProperty("NgayPhatSongString", true);
        //        return _ngayPhatSong.Text;
        //    }
        //    set
        //    {
        //        CanWriteProperty("NgayPhatSongString", true);
        //        if (value == null) value = string.Empty;
        //        if (!_ngayPhatSong.Equals(value))
        //        {
        //            _ngayPhatSong.Text = value;
        //            PropertyHasChanged("NgayPhatSongString");
        //        }
        //    }
        //}

        public string NgayNghiemThu
        {
            get
            {
                CanReadProperty("NgayNghiemThu", true);
                return _ngayNghiemThu;
            }
            set
            {
                CanWriteProperty("NgayNghiemThu", true);
                if (!_ngayNghiemThu.Equals(value))
                {
                    _ngayNghiemThu = value;
                    PropertyHasChanged("NgayNghiemThu");
                }
            }
        }

        public int MaNguon
        {
            get
            {
                CanReadProperty("MaNguon", true);
                return _maNguon;
            }
            set
            {
                CanWriteProperty("MaNguon", true);
                if (!_maNguon.Equals(value))
                {
                    _maNguon = value;
                    PropertyHasChanged("MaNguon");
                }
            }
        }
        public long MaHopDong
        {
            get
            {
                CanReadProperty("MaHopDong", true);
                return _maHopDong;
            }
            set
            {
                CanWriteProperty("MaHopDong", true);
                if (!_maHopDong.Equals(value))
                {
                    _maHopDong = value;
                    PropertyHasChanged("MaHopDong");
                }
            }
        }

     
        public decimal SLgCt_PNhap//M
        {
            get
            {
                return _sLgCt_PNhap;
            }
        }
        public bool ChonTuDSCTPhieu//M
        {
            get
            {
                return _chonTuDSCTPhieu;
            }
        }
        public decimal DonGiaCT_PNhap
        {
            get
            {
                return _donGiaCT_PNhap;
            }
        }
        public decimal SoLuongLuu//M
        {
            get
            {
                return _soLuongLuu;
            }
        }
        public decimal ThanhTienLuu//M
        {
            get
            {
                return _thanhTienLuu;
            }
        }
        public decimal DonGiaLuu
        {
            get
            {
                return _donGiaLuu;
            }

        }
        public decimal ThanhTienCT_PNhap
        {
            get
            {
                return _thanhTienCT_PNhap;
            }
        }

        //public string NgayNghiemThuString
        //{
        //    get
        //    {
        //        CanReadProperty("NgayNghiemThuString", true);
        //        return _ngayNghiemThu.Text;
        //    }
        //    set
        //    {
        //        CanWriteProperty("NgayNghiemThuString", true);
        //        if (value == null) value = string.Empty;
        //        if (!_ngayNghiemThu.Equals(value))
        //        {
        //            _ngayNghiemThu.Text = value;
        //            PropertyHasChanged("NgayNghiemThuString");
        //        }
        //    }
        //}

        public string MoTaTenCCDC
        {
            get
            {
                CanReadProperty("MoTaTenCCDC", true);
                return _MoTaTenCCDC;
            }
            set
            {
                CanWriteProperty("MoTaTenCCDC", true);
                if (!_MoTaTenCCDC.Equals(value))
                {
                    _MoTaTenCCDC = value;
                    PropertyHasChanged("MoTaTenCCDC");
                }
            }
        }
        public double TyLeCK
        {
            get
            {
                CanReadProperty("TyLeCK", true);
                return _tyLeCK;
            }
            set
            {
                CanWriteProperty("TyLeCK", true);
                if (!_tyLeCK.Equals(value))
                {
                    _tyLeCK = value;
                    PropertyHasChanged("TyLeCK");
                }
            }
        }

        public decimal TienChietKhau
        {
            get
            {
                CanReadProperty("TienChietKhau", true);
                return _tienChietKhau;
            }
            set
            {
                CanWriteProperty("TienChietKhau", true);
                if (!_tienChietKhau.Equals(value))
                {
                    _tienChietKhau = value;
                    PropertyHasChanged("TienChietKhau");
                }
            }
        }

        public decimal ChiPhiMuaHang
        {
            get
            {
                CanReadProperty("ChiPhiMuaHang", true);
                return _chiPhiMuaHang;
            }
            set
            {
                CanWriteProperty("ChiPhiMuaHang", true);
                if (!_chiPhiMuaHang.Equals(value))
                {
                    _chiPhiMuaHang = value;
                    PropertyHasChanged("ChiPhiMuaHang");
                }
            }
        }

        public double ThueSuatVAT
        {
            get
            {
                CanReadProperty("ThueSuatVAT", true);
                return _thueSuatVAT;
            }
            set
            {
                CanWriteProperty("ThueSuatVAT", true);
                if (!_thueSuatVAT.Equals(value))
                {
                    _thueSuatVAT = value;
                    PropertyHasChanged("ThueSuatVAT");
                }
            }
        }

        public decimal TienThue
        {
            get
            {
                CanReadProperty("TienThue", true);
                return _tienThue;
            }
            set
            {
                CanWriteProperty("TienThue", true);
                if (!_tienThue.Equals(value))
                {
                    _tienThue = value;
                    PropertyHasChanged("TienThue");
                }
            }
        }

        public decimal DonGiaGoc
        {
            get
            {
                CanReadProperty("DonGiaGoc", true);
                return _donGiaGoc;
            }
            set
            {
                CanWriteProperty("DonGiaGoc", true);
                if (!_donGiaGoc.Equals(value))
                {
                    _donGiaGoc = value;
                    PropertyHasChanged("DonGiaGoc");
                }
            }
        }
        public decimal ThanhTienGoc
        {
            get
            {
                CanReadProperty("ThanhTienGoc", true);
                return _thanhTienGoc;
            }
            set
            {
                CanWriteProperty("ThanhTienGoc", true);
                if (!_thanhTienGoc.Equals(value))
                {
                    _thanhTienGoc = value;
                    PropertyHasChanged("ThanhTienGoc");
                }
            }
        }

        public int MaChiTietPhieuNhap
        {
            get
            {
                CanReadProperty("MaChiTietPhieuNhap", true);
                return _maChiTietPhieuNhap;
            }
            set
            {
                CanWriteProperty("MaChiTietPhieuNhap", true);
                if (!_maChiTietPhieuNhap.Equals(value))
                {
                    _maChiTietPhieuNhap = value;
                    PropertyHasChanged("MaChiTietPhieuNhap");
                }
            }
        }

        public long MaCT_KetChuyen
        {
            get
            {
                CanReadProperty("MaCT_KetChuyen", true);
                return _maCT_KetChuyen;
            }
            set
            {
                CanWriteProperty("MaCT_KetChuyen", true);
                if (!_maCT_KetChuyen.Equals(value))
                {
                    _maCT_KetChuyen = value;
                    PropertyHasChanged("MaCT_KetChuyen");
                }

            }
        }
        public long MaCT_KetChuyenCCDC
        {
            get
            {
                CanReadProperty("MaCT_KetChuyenCCDC", true);
                return _maCT_KetChuyenCCDC;
            }
            set
            {
                CanWriteProperty("MaCT_KetChuyenCCDC", true);
                if (!_maCT_KetChuyenCCDC.Equals(value))
                {
                    _maCT_KetChuyenCCDC = value;
                    PropertyHasChanged("MaCT_KetChuyenCCDC");
                }

            }
        }

        public int MaTruong
        {
            get
            {
                CanReadProperty("maTruong", true);
                return _maTruong;
            }
            set
            {
                CanWriteProperty("maTruong", true);
                if (!_maTruong.Equals(value))
                {
                    _maTruong = value;
                    PropertyHasChanged("maTruong");
                }
            }
        }
        
        protected override object GetIdValue()
        {
            return _maChiTietPhieuXuat;
        }

        #endregion //Business Properties and Methods

        #region Validation Rules
        private void AddCustomRules()
        {
            //add custom/non-generated rules here...
        }

        private void AddCommonRules()
        {
            //
            // DienGiai
            //
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("DienGiai", 1000));
        }

        protected override void AddBusinessRules()
        {
            AddCommonRules();
            AddCustomRules();
        }
        #endregion //Validation Rules

        #region Authorization Rules
        protected override void AddAuthorizationRules()
        {
            //TODO: Define authorization rules in CT_PhieuXuat
            //AuthorizationRules.AllowRead("MaChiTietPhieuXuat", "CT_PhieuXuatReadGroup");
            //AuthorizationRules.AllowRead("MaPhieuxuat", "CT_PhieuXuatReadGroup");
            //AuthorizationRules.AllowRead("SoLuong", "CT_PhieuXuatReadGroup");
            //AuthorizationRules.AllowRead("MaDonViTinh", "CT_PhieuXuatReadGroup");
            //AuthorizationRules.AllowRead("DonGia", "CT_PhieuXuatReadGroup");
            //AuthorizationRules.AllowRead("ThanhTien", "CT_PhieuXuatReadGroup");
            //AuthorizationRules.AllowRead("ThoiLuong", "CT_PhieuXuatReadGroup");
            //AuthorizationRules.AllowRead("MaHangHoa", "CT_PhieuXuatReadGroup");
            //AuthorizationRules.AllowRead("DienGiai", "CT_PhieuXuatReadGroup");
            //AuthorizationRules.AllowRead("MaPhieuNhap", "CT_PhieuXuatReadGroup");
            //AuthorizationRules.AllowRead("NgayPhatSong", "CT_PhieuXuatReadGroup");
            //AuthorizationRules.AllowRead("NgayPhatSongString", "CT_PhieuXuatReadGroup");
            //AuthorizationRules.AllowRead("NgayNghiemThu", "CT_PhieuXuatReadGroup");
            //AuthorizationRules.AllowRead("NgayNghiemThuString", "CT_PhieuXuatReadGroup");

            //AuthorizationRules.AllowWrite("MaPhieuxuat", "CT_PhieuXuatWriteGroup");
            //AuthorizationRules.AllowWrite("SoLuong", "CT_PhieuXuatWriteGroup");
            //AuthorizationRules.AllowWrite("MaDonViTinh", "CT_PhieuXuatWriteGroup");
            //AuthorizationRules.AllowWrite("DonGia", "CT_PhieuXuatWriteGroup");
            //AuthorizationRules.AllowWrite("ThanhTien", "CT_PhieuXuatWriteGroup");
            //AuthorizationRules.AllowWrite("ThoiLuong", "CT_PhieuXuatWriteGroup");
            //AuthorizationRules.AllowWrite("MaHangHoa", "CT_PhieuXuatWriteGroup");
            //AuthorizationRules.AllowWrite("DienGiai", "CT_PhieuXuatWriteGroup");
            //AuthorizationRules.AllowWrite("MaPhieuNhap", "CT_PhieuXuatWriteGroup");
            //AuthorizationRules.AllowWrite("NgayPhatSongString", "CT_PhieuXuatWriteGroup");
            //AuthorizationRules.AllowWrite("NgayNghiemThuString", "CT_PhieuXuatWriteGroup");
        }

        #endregion //Authorization Rules

        #region Factory Methods
        internal static CT_PhieuXuatCCDC NewCT_PhieuXuat()
        {
            return new CT_PhieuXuatCCDC();
        }

        internal static CT_PhieuXuatCCDC NewCT_PhieuXuat(CT_PhieuNhapCCDC _ctPhieuNhap, int _loai)
        {
            return new CT_PhieuXuatCCDC(_ctPhieuNhap, _loai);
        }
        public static CT_PhieuXuatCCDC NewCT_PhieuXuat(ChuongTrinhBanQuyenCon _chuongTrinhBanQuyenCon, long _maPhieuNhapxuat, int _maBoPhan, int _maKho, DateTime _ngayNX, string _dienGiaiPhieu)
        {
            return new CT_PhieuXuatCCDC(_chuongTrinhBanQuyenCon, _maPhieuNhapxuat, _maBoPhan, _maKho, _ngayNX, _dienGiaiPhieu);
        }
        internal static CT_PhieuXuatCCDC NewCT_PhieuXuat(CT_PhieuNhapCCDC _ctPhieuNhap, int _maKho, DateTime _ngayNX)
        {
            return new CT_PhieuXuatCCDC(_ctPhieuNhap, _maKho, _ngayNX);
        }
        internal static CT_PhieuXuatCCDC NewCT_PhieuXuat(CT_PhieuNhap _ctPhieuNhap, DateTime _ngayNX)//Cho Xuat Thang
        {
            return new CT_PhieuXuatCCDC(_ctPhieuNhap, _ngayNX);
        }
        internal static CT_PhieuXuatCCDC GetCT_PhieuXuat(SafeDataReader dr)
        {
            return new CT_PhieuXuatCCDC(dr);
        }

        private CT_PhieuXuatCCDC()
        {

            ValidationRules.CheckRules();
            MarkAsChild();
        }
        private CT_PhieuXuatCCDC(ChuongTrinhBanQuyenCon ctbq, long _maPhieuNhapxuat, int _maBoPhan, int _maKho, DateTime _ngayNX, string _dienGiaiphieu)
        {
            HangHoaBQ_VT hh = HangHoaBQ_VT.GetHangHoaBQ_VT(ctbq.MaHangHoa);
            _maHangHoa = ctbq.MaHangHoa;
            _maChuongTrinhCon = ctbq.MaChuongTrinhCon;
            _maHopDong = ctbq.MaHopDong;
            _maNguon = ctbq.MaNguon;
            _thoiLuong = ctbq.ThoiLuong;
            _maDonViTinh = hh.MaDonViTinh;
            _soLuong = ctbq.SoLuongTon;
            _donGia = ChuongTrinhBanQuyenCon.GetGiaBinhQuanChuongTrinhBanQuyen(_maPhieuNhapxuat, _maBoPhan, _maKho, ctbq.MaChuongTrinhCon, ctbq.MaHopDong, ctbq.MaNguon, _ngayNX);
            _thanhTien = ChuongTrinhBanQuyenCon.GetGiaTriChuongTrinhBanQuyen(_maPhieuNhapxuat, _maBoPhan, _maKho, ctbq.MaChuongTrinhCon, ctbq.MaHopDong, ctbq.MaNguon, _ngayNX);
            _dienGiai = _dienGiaiphieu;
            ValidationRules.CheckRules();
            MarkAsChild();
        }

        public CT_PhieuXuatCCDC(CT_KiemKeTonKho cT_KiemKeTonKho)
        {
            _maHangHoa = cT_KiemKeTonKho.MaHangHoa;
            HangHoaBQ_VT _hangHoaBQ_VT = HangHoaBQ_VT.GetHangHoaBQ_VT(_maHangHoa);
            //_thanhTien = (cT_KiemKeTonKho.GiaTriDieuChinh < 0) ? Math.Abs(cT_KiemKeTonKho.GiaTriDieuChinh) : 0;
            //_soLuong = (cT_KiemKeTonKho.SLDieuChinh < 0) ? Math.Abs((short)cT_KiemKeTonKho.SLDieuChinh) : (short)0;
            _thanhTien = (cT_KiemKeTonKho.GiaTriDieuChinh > 0) ? cT_KiemKeTonKho.GiaTriDieuChinh : 0;
            _soLuong = (cT_KiemKeTonKho.SLDieuChinh > 0) ? (short)cT_KiemKeTonKho.SLDieuChinh : (short)0;
            _maDonViTinh = _hangHoaBQ_VT.MaDonViTinh;
            _thoiLuong = _hangHoaBQ_VT.ThoiLuong;
            _donGia = (_soLuong != 0) ? Math.Round(Math.Abs(_thanhTien / _soLuong), 0) : 0;
        }

        public CT_PhieuXuatCCDC(CT_PhieuLinhNhienLieu cT_PhieuLinhNhienLieu, int maKho, DateTime ngayNX)
        {
            //
            _maHangHoa = cT_PhieuLinhNhienLieu.MaHangHoa;
            HangHoaBQ_VT _hangHoaBQ_VT = HangHoaBQ_VT.GetHangHoaBQ_VT(_maHangHoa);
            _maDonViTinh = _hangHoaBQ_VT.MaDonViTinh;
            _donGia = HangHoaBQ_VT.GetGiaTriBinhQuanHangHoa(0, maKho, _maHangHoa, ngayNX);
            _soLuong = Convert.ToInt64(cT_PhieuLinhNhienLieu.SoLuongXuat);
            if (_soLuong == HangHoaBQ_VT.GetSoLuongHangHoaBinhQuan(0, maKho, _maHangHoa, ngayNX))
                _thanhTien = HangHoaBQ_VT.GetGiaTriHangHoaBinhQuan(0, maKho, _maHangHoa, ngayNX);
            else
                _thanhTien = Math.Round((_soLuong) * (_donGia), 0, MidpointRounding.AwayFromZero);
            //
        }

        public CT_PhieuXuatCCDC(CT_PhieuNhapCCDC _ctPhieuNhap, int _loai)
        {
            if (_loai == 4)
            {
                long maHopDong = 0;
                NhapXuat_HopDongList nx_HopDongList = NhapXuat_HopDongList.GetNhapXuat_HopDongList(_ctPhieuNhap.MaPhieuNhap);
                if (nx_HopDongList.Count != 0)
                    maHopDong = nx_HopDongList[0].MaHopDong;
                _maPhieuNhap = _ctPhieuNhap.MaPhieuNhap;
                _maChuongTrinhCon = _ctPhieuNhap.MaChuongTrinhCon;
                _maHangHoa = _ctPhieuNhap.MaHangHoa;
                _maDonViTinh = _ctPhieuNhap.MaDonViTinh;
                _thoiLuong = _ctPhieuNhap.ThoiLuong;
                _dienGiai = _ctPhieuNhap.DienGiai;
                _maNguon = _ctPhieuNhap.MaNguon;
                _maHopDong = maHopDong;
                _thanhTien = _ctPhieuNhap.ThanhTien;
                _ngayNghiemThu = _ctPhieuNhap.NgayNghiemThu;
            }
            else
            {
                _maPhieuNhap = _ctPhieuNhap.MaPhieuNhap;
                _maHangHoa = _ctPhieuNhap.MaHangHoa;
                _donGia = _ctPhieuNhap.DonGia;
                _soLuong = (decimal)(_ctPhieuNhap.SoLuong - _ctPhieuNhap.SoLuongXuat);
                _maDonViTinh = _ctPhieuNhap.MaDonViTinh;
                _thoiLuong = _ctPhieuNhap.ThoiLuong;
                _dienGiai = _ctPhieuNhap.DienGiai;
                _maNguon = _ctPhieuNhap.MaNguon;
                _sLgCt_PNhap = _ctPhieuNhap.SoLuong - _ctPhieuNhap.SoLuongXuat;//M
                _donGiaCT_PNhap = _ctPhieuNhap.DonGia;
                _thanhTienCT_PNhap = _ctPhieuNhap.ThanhTien;//M
                _thanhTien = _ctPhieuNhap.ThanhTien;
            }
            ValidationRules.CheckRules();
            MarkAsChild();
        }

        public CT_PhieuXuatCCDC(CT_PhieuNhapCCDC _ctPhieuNhap, int _maKho, DateTime _ngayLap)//
        {
            _maPhieuNhap = _ctPhieuNhap.MaPhieuNhap;
            _maHangHoa = _ctPhieuNhap.MaHangHoa;
            _donGia = _ctPhieuNhap.DonGia;
            _soLuong = (decimal)(_ctPhieuNhap.SoLuong - _ctPhieuNhap.SoLuongXuat);
            _maDonViTinh = _ctPhieuNhap.MaDonViTinh;
            _thoiLuong = _ctPhieuNhap.ThoiLuong;
            _dienGiai = _ctPhieuNhap.DienGiai;
            _maNguon = _ctPhieuNhap.MaNguon;
            _ngayNghiemThu = _ctPhieuNhap.NgayNghiemThu;
            _sLgCt_PNhap = _ctPhieuNhap.SoLuong - _ctPhieuNhap.SoLuongXuat;//M
            _donGiaCT_PNhap = _ctPhieuNhap.DonGia;
            _thanhTienCT_PNhap = _ctPhieuNhap.ThanhTien;//M
            //_thanhTien = _ctPhieuNhap.ThanhTien;
            if (_soLuong == HangHoaBQ_VT.GetSoLuongHangHoaBinhQuan(0, _maKho, _maHangHoa, _ngayLap))
                _thanhTien = HangHoaBQ_VT.GetGiaTriHangHoaBinhQuan(0, _maKho, _maHangHoa, _ngayLap);
            else
                _thanhTien = _thanhTien = _soLuong * _ctPhieuNhap.DonGia; //_ctPhieuNhap.ThanhTien;
            ValidationRules.CheckRules();
            MarkAsChild();
        }
        public CT_PhieuXuatCCDC(CT_PhieuNhapCCDC _ctPhieuNhap, int maBoPhan, int _maKho, long maHopDong, DateTime _ngayLap)//Binh Quan Ban Quyen
        {
            _maPhieuNhap = _ctPhieuNhap.MaPhieuNhap;
            _maHangHoa = _ctPhieuNhap.MaHangHoa;
            _donGia = _ctPhieuNhap.DonGia;
            //_donGia = HangHoaBQ_VT.GetGiaBinhQuanChuongTrinhBQ(0,maBoPhan, _maKho, _maHangHoa, maHopDong, _ngayLap);
            _soLuong = (decimal)(_ctPhieuNhap.SoLuong - _ctPhieuNhap.SoLuongXuat);
            _maDonViTinh = _ctPhieuNhap.MaDonViTinh;
            _thoiLuong = _ctPhieuNhap.ThoiLuong;
            _dienGiai = _ctPhieuNhap.DienGiai;
            _maNguon = _ctPhieuNhap.MaNguon;
            _maHopDong = maHopDong;
            _ngayNghiemThu = _ctPhieuNhap.NgayNghiemThu;
            _sLgCt_PNhap = _ctPhieuNhap.SoLuong - _ctPhieuNhap.SoLuongXuat;//M
            _donGiaCT_PNhap = _ctPhieuNhap.DonGia;
            _thanhTienCT_PNhap = _ctPhieuNhap.ThanhTien;//M
            //_thanhTien = _ctPhieuNhap.ThanhTien;
            if (_soLuong == HangHoaBQ_VT.GetSoLuongChuongTrinhBQ(0, maBoPhan, _maKho, _maHangHoa, maHopDong, _ngayLap))
                _thanhTien = HangHoaBQ_VT.GetGiaTriChuongTrinhBQ(0, maBoPhan, _maKho, _maHangHoa, maHopDong, _ngayLap);
            else
                _thanhTien = Math.Round(_donGia * _soLuong, 0, MidpointRounding.AwayFromZero);
            ValidationRules.CheckRules();
            MarkAsChild();
        }//END Binh Quan Ban Quyen
        public CT_PhieuXuatCCDC(CT_PhieuNhap _ctPhieuNhap, DateTime _ngayLap)//Cho Xuat Thang CCDC
        {
            _maPhieuNhap = _ctPhieuNhap.MaPhieuNhap;
            _soPhieuNhap = PhieuNhapXuatCCDC.GetPhieuNhapXuat(_maPhieuNhap).SoPhieu;
            _maHangHoa = _ctPhieuNhap.MaHangHoa;
            _donGia = _ctPhieuNhap.DonGia;
            _soLuong = (decimal)(_ctPhieuNhap.SoLuong - _ctPhieuNhap.SoLuongXuat);
            _maDonViTinh = _ctPhieuNhap.MaDonViTinh;
            _dienGiai = _ctPhieuNhap.DienGiai;
            _maNguon = _ctPhieuNhap.MaNguon;
            _sLgCt_PNhap = _ctPhieuNhap.SoLuong - _ctPhieuNhap.SoLuongXuat;//M
            _donGiaCT_PNhap = _ctPhieuNhap.DonGia;
            _thanhTienCT_PNhap = _ctPhieuNhap.ThanhTien;//M
            if (_soLuong == HangHoaBQ_VT.GetSoLuongHangHoaNXT(0, _maPhieuNhap, _maHangHoa, _ngayLap, _donGia, _ctPhieuNhap.MaChiTietPhieuNhap,_ctPhieuNhap.MaCT_KetChuyen,0))//New 19112013
                _thanhTien = HangHoaBQ_VT.GetGiaTriHangHoaNXT(0, _maPhieuNhap, _maHangHoa, _ngayLap, _donGia, _ctPhieuNhap.MaChiTietPhieuNhap,_ctPhieuNhap.MaCT_KetChuyen);//New 19112013
            else
                _thanhTien = Math.Round(_donGia * _soLuong, 0, MidpointRounding.AwayFromZero);
            _MoTaTenCCDC = _ctPhieuNhap.MoTaTenCCDC;
            _dienGiai = _ctPhieuNhap.DienGiai;
            //
            _tyLeCK = _ctPhieuNhap.TyLeCK;
            _tienChietKhau = _ctPhieuNhap.TienChietKhau;
            _chiPhiMuaHang = _ctPhieuNhap.ChiPhiMuaHang;
            _thueSuatVAT = _ctPhieuNhap.ThueSuatVAT;
            _tienThue = _ctPhieuNhap.TienThue;
            _donGiaGoc = _ctPhieuNhap.DonGiaGoc;
            _thanhTienGoc = _ctPhieuNhap.ThanhTienGoc;
            _thoiLuong = _ctPhieuNhap.ThoiLuong;
            _maChiTietPhieuNhap = _ctPhieuNhap.MaChiTietPhieuNhap;            
            _maCT_KetChuyenCCDC = _ctPhieuNhap.MaCT_KetChuyen;
            ValidationRules.CheckRules();
            ValidationRules.CheckRules();
            MarkAsChild();
        }//END Cho Xuat Thang Vat tu Hang hoa
        public CT_PhieuXuatCCDC(CT_PhieuNhapCCDC _ctPhieuNhap, int maBoPhan, int _maKho, int _phuongPhapNX, long maHopDong, DateTime _ngayLap)//Cho Xuat Thang and Binh Quan Ban Quyen
        {
            _maPhieuNhap = _ctPhieuNhap.MaPhieuNhap;
            _soPhieuNhap = PhieuNhapXuatCCDC.GetPhieuNhapXuat(_maPhieuNhap).SoPhieu;
            _maHangHoa = _ctPhieuNhap.MaHangHoa;
            _maChuongTrinhCon = _ctPhieuNhap.MaChuongTrinhCon;//
            _donGia = _ctPhieuNhap.DonGia;
            _soLuong = (decimal)(_ctPhieuNhap.SoLuong - _ctPhieuNhap.SoLuongXuat);
            _maDonViTinh = _ctPhieuNhap.MaDonViTinh;
            _thoiLuong = _ctPhieuNhap.ThoiLuong;
            _dienGiai = _ctPhieuNhap.DienGiai;
            _maNguon = _ctPhieuNhap.MaNguon;
            _maHopDong = maHopDong;
            _ngayNghiemThu = _ctPhieuNhap.NgayNghiemThu;
            _sLgCt_PNhap = _ctPhieuNhap.SoLuong - _ctPhieuNhap.SoLuongXuat;//M
            _chonTuDSCTPhieu = true;
            _donGiaCT_PNhap = _ctPhieuNhap.DonGia;
            _thanhTienCT_PNhap = _ctPhieuNhap.ThanhTien;//M

            if (_soLuong == ChuongTrinhBanQuyenCon.GetSoLuongChuongTrinhBanQuyen_NXT(0, maBoPhan, _maKho, _phuongPhapNX, _maPhieuNhap, _maChuongTrinhCon, maHopDong, _ctPhieuNhap.MaNguon, _ngayLap))
            {
                _thanhTien = ChuongTrinhBanQuyenCon.GetGiaTriChuongTrinhBanQuyen_NXT(0, maBoPhan, _maKho, _phuongPhapNX, _maPhieuNhap, _maChuongTrinhCon, maHopDong, _ctPhieuNhap.MaNguon, _ngayLap);
                if (_soLuong == 1)
                    _donGia = _thanhTien;
            }
            else
                _thanhTien = Math.Round(_donGia * _soLuong, 0, MidpointRounding.AwayFromZero);
            _maChiTietPhieuNhap = _ctPhieuNhap.MaChiTietPhieuNhap;
            ValidationRules.CheckRules();
            MarkAsChild();
        }//END Cho Xuat Thang Ban Quyen , _phieuXuat.MaPhongBan, _phieuXuat.PhuongPhapNX, _phieuXuat.MaKho, _phieuXuat.NgayNX

        public CT_PhieuXuatCCDC(CT_PhieuXuatCCDC _ctPhieuXuat)
        {
            _maPhieuNhap = 0;
            _maHangHoa = _ctPhieuXuat.MaHangHoa;
            _donGia = _ctPhieuXuat.DonGia;
            _thanhTien = _ctPhieuXuat.ThanhTien;
            _soLuong = _ctPhieuXuat.SoLuong;
            _maDonViTinh = _ctPhieuXuat.MaDonViTinh;
            _thoiLuong = _ctPhieuXuat.ThoiLuong;
            _dienGiai = _ctPhieuXuat.DienGiai;
            _maNguon = _ctPhieuXuat.MaNguon;
            _ngayNghiemThu = _ctPhieuXuat.NgayNghiemThu;
            ValidationRules.CheckRules();
            MarkAsChild();
        }
        public CT_PhieuXuatCCDC(CT_PhieuXuatCCDC _ctPhieuXuat, int _maKho, DateTime _ngayLap)
        {
            _maPhieuNhap = 0;
            _maHangHoa = _ctPhieuXuat.MaHangHoa;
            _donGia = _ctPhieuXuat.DonGia;
            _soLuong = _ctPhieuXuat.SoLuong;
            _maDonViTinh = _ctPhieuXuat.MaDonViTinh;
            _thoiLuong = _ctPhieuXuat.ThoiLuong;
            _dienGiai = _ctPhieuXuat.DienGiai;
            _maNguon = _ctPhieuXuat.MaNguon;
            _ngayNghiemThu = _ctPhieuXuat.NgayNghiemThu;
            //_thanhTien = _ctPhieuXuat.ThanhTien;
            if (_soLuong == HangHoaBQ_VT.GetSoLuongHangHoaBinhQuan(0, _maKho, _maHangHoa, _ngayLap))
                _thanhTien = HangHoaBQ_VT.GetGiaTriHangHoaBinhQuan(0, _maKho, _maHangHoa, _ngayLap);
            else
                _thanhTien = _ctPhieuXuat.ThanhTien;
            ValidationRules.CheckRules();
            MarkAsChild();
        }

        private CT_PhieuXuatCCDC(SafeDataReader dr)
        {
            MarkAsChild();
            Fetch(dr);
        }
        #endregion //Factory Methods


        #region Data Access

        #region Data Access - Fetch
        private void Fetch(SafeDataReader dr)
        {
            FetchObject(dr);
            MarkOld();
            ValidationRules.CheckRules();

            //load child object(s)
            FetchChildren(dr);
        }

        private void FetchObject(SafeDataReader dr)
        {
            _maChiTietPhieuXuat = dr.GetInt32("MaChiTietPhieuXuat");
            _maPhieuxuat = dr.GetInt64("MaPhieuxuat");
            _soLuong = dr.GetDecimal("SoLuong");
            _maDonViTinh = dr.GetInt32("MaDonViTinh");
            _donGia = dr.GetDecimal("DonGia");
            _thanhTien = dr.GetDecimal("ThanhTien");
            _thoiLuong = dr.GetDecimal("ThoiLuong");
            _maHangHoa = dr.GetInt32("MaHangHoa");
            _maChuongTrinhCon = dr.GetInt32("MaChuongTrinhCon");//M Ban Quyen
            _dienGiai = dr.GetString("DienGiai");
            _maPhieuNhap = dr.GetInt64("MaPhieuNhap");
            _soPhieuNhap = PhieuNhapXuatCCDC.GetPhieuNhapXuat(_maPhieuNhap).SoPhieu;
            _ngayPhatSong = dr.GetSmartDate("NgayPhatSong", _ngayPhatSong.EmptyIsMin);
            //_ngayNghiemThu = dr.GetSmartDate("NgayNghiemThu", _ngayNghiemThu.EmptyIsMin);
            _ngayNghiemThu = dr.GetString("NgayNghiemThu");
            _maNguon = dr.GetInt32("MaNguon");
            _maHopDong = dr.GetInt64("MaHopDong");
            _soLuongLuu = _soLuong;//M
            _thanhTienLuu = _thanhTien;//M
            _donGiaLuu = _donGia;//M

            _MoTaTenCCDC = dr.GetString("MoTaTenCCDC");

            _tyLeCK = dr.GetDouble("TyLeCK");
            _tienChietKhau = dr.GetDecimal("TienChietKhau");
            _chiPhiMuaHang = dr.GetDecimal("ChiPhiMuaHang");
            _thueSuatVAT = dr.GetDouble("ThueSuatVAT");
            _tienThue = dr.GetDecimal("TienThue");
            _donGiaGoc = dr.GetDecimal("DonGiaGoc");
            _thanhTienGoc = dr.GetDecimal("ThanhTienGoc");
            _maChiTietPhieuNhap = dr.GetInt32("MaChiTietPhieuNhap");
            _maCT_KetChuyen = dr.GetInt64("MaCT_KetChuyen");
            _maCT_KetChuyenCCDC = dr.GetInt64("MaCT_KetChuyenCCDC");
            _maTruong = dr.GetInt32("maTruong");
        }

        private void FetchChildren(SafeDataReader dr)
        {
        }
        #endregion //Data Access - Fetch

        #region Data Access - Insert
        internal void Insert(SqlTransaction tr, PhieuNhapXuatCCDC parent)
        {
            if (!IsDirty) return;

            ExecuteInsert(tr, parent);
            MarkOld();

            //update child object(s)
            UpdateChildren(tr);
        }

        private void ExecuteInsert(SqlTransaction tr, PhieuNhapXuatCCDC parent)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_InserttblCT_PhieuXuat";

                AddInsertParameters(cm, parent);

                cm.ExecuteNonQuery();

                _maChiTietPhieuXuat = (int)cm.Parameters["@MaChiTietPhieuXuat"].Value;
            }//using
        }

        private void AddInsertParameters(SqlCommand cm, PhieuNhapXuatCCDC parent)
        {
            _maPhieuxuat = parent.MaPhieuNhapXuat;
            //TODO: if parent use identity key, fix fk member with value from parent
            cm.Parameters.AddWithValue("@MaPhieuxuat", _maPhieuxuat);
            cm.Parameters.AddWithValue("@SoLuong", _soLuong);
            if (_maDonViTinh != 0)
                cm.Parameters.AddWithValue("@MaDonViTinh", _maDonViTinh);
            else
                cm.Parameters.AddWithValue("@MaDonViTinh", DBNull.Value);
            if (_donGia != 0)
                cm.Parameters.AddWithValue("@DonGia", _donGia);
            else
                cm.Parameters.AddWithValue("@DonGia", DBNull.Value);
            if (_thanhTien != 0)
                cm.Parameters.AddWithValue("@ThanhTien", _thanhTien);
            else
                cm.Parameters.AddWithValue("@ThanhTien", DBNull.Value);
            if (_thoiLuong != 0)
                cm.Parameters.AddWithValue("@ThoiLuong", _thoiLuong);
            else
                cm.Parameters.AddWithValue("@ThoiLuong", DBNull.Value);
            if (_maHangHoa != 0)
                cm.Parameters.AddWithValue("@MaHangHoa", _maHangHoa);
            else
                cm.Parameters.AddWithValue("@MaHangHoa", DBNull.Value);
            if (_maChuongTrinhCon != 0)//Ban Quyen
                cm.Parameters.AddWithValue("@MaChuongTrinhCon", _maChuongTrinhCon);
            else
                cm.Parameters.AddWithValue("@MaChuongTrinhCon", DBNull.Value);
            if (_dienGiai.Length > 0)
                cm.Parameters.AddWithValue("@DienGiai", _dienGiai);
            else
                cm.Parameters.AddWithValue("@DienGiai", DBNull.Value);
            if (_maPhieuNhap != 0)
                cm.Parameters.AddWithValue("@MaPhieuNhap", _maPhieuNhap);
            else
                cm.Parameters.AddWithValue("@MaPhieuNhap", DBNull.Value);
            cm.Parameters.AddWithValue("@NgayPhatSong", _ngayPhatSong.DBValue);
            if (_ngayNghiemThu.Length > 0)
                cm.Parameters.AddWithValue("@NgayNghiemThu", _ngayNghiemThu);
            else
                cm.Parameters.AddWithValue("@NgayNghiemThu", DBNull.Value);
            if (_maNguon != 0)
                cm.Parameters.AddWithValue("MaNguon", _maNguon);
            else
                cm.Parameters.AddWithValue("MaNguon", DBNull.Value);
            if (_maHopDong != 0)
                cm.Parameters.AddWithValue("MaHopDong", _maHopDong);
            else
                cm.Parameters.AddWithValue("MaHopDong", DBNull.Value);

            if (_MoTaTenCCDC.Length > 0)
                cm.Parameters.AddWithValue("@MoTaTenCCDC", _MoTaTenCCDC);
            else
                cm.Parameters.AddWithValue("@MoTaTenCCDC", DBNull.Value);

            //
            if (_tyLeCK != 0)
                cm.Parameters.AddWithValue("@TyLeCK", _tyLeCK);
            else
                cm.Parameters.AddWithValue("@TyLeCK", DBNull.Value);
            if (_tienChietKhau != 0)
                cm.Parameters.AddWithValue("@TienChietKhau", _tienChietKhau);
            else
                cm.Parameters.AddWithValue("@TienChietKhau", DBNull.Value);
            if (_chiPhiMuaHang != 0)
                cm.Parameters.AddWithValue("@ChiPhiMuaHang", _chiPhiMuaHang);
            else
                cm.Parameters.AddWithValue("@ChiPhiMuaHang", DBNull.Value);
            if (_thueSuatVAT != 0)
                cm.Parameters.AddWithValue("@ThueSuatVAT", _thueSuatVAT);
            else
                cm.Parameters.AddWithValue("@ThueSuatVAT", DBNull.Value);
            if (_tienThue != 0)
                cm.Parameters.AddWithValue("@TienThue", _tienThue);
            else
                cm.Parameters.AddWithValue("@TienThue", DBNull.Value);
            if (_donGiaGoc != 0)
                cm.Parameters.AddWithValue("@DonGiaGoc", _donGiaGoc);
            else
                cm.Parameters.AddWithValue("@DonGiaGoc", DBNull.Value);
            if (_thanhTienGoc != 0)
                cm.Parameters.AddWithValue("@ThanhTienGoc", _thanhTienGoc);
            else
                cm.Parameters.AddWithValue("@ThanhTienGoc", DBNull.Value);
            if (_maChiTietPhieuNhap != 0)
                cm.Parameters.AddWithValue("MaChiTietPhieuNhap", _maChiTietPhieuNhap);
            else
                cm.Parameters.AddWithValue("MaChiTietPhieuNhap", DBNull.Value);
            if (_maCT_KetChuyen != 0)
                cm.Parameters.AddWithValue("@MaCT_KetChuyen", _maCT_KetChuyen);
            else
                cm.Parameters.AddWithValue("@MaCT_KetChuyen", DBNull.Value);
            if (_maCT_KetChuyenCCDC != 0)
                cm.Parameters.AddWithValue("@MaCT_KetChuyenCCDC", _maCT_KetChuyenCCDC);
            else
                cm.Parameters.AddWithValue("@MaCT_KetChuyenCCDC", DBNull.Value);
            if (_maTruong > 0)
                cm.Parameters.AddWithValue("@maTruong", _maTruong);
            else
                cm.Parameters.AddWithValue("@maTruong", DBNull.Value);
            cm.Parameters.AddWithValue("@MaChiTietPhieuXuat", _maChiTietPhieuXuat);
            cm.Parameters["@MaChiTietPhieuXuat"].Direction = ParameterDirection.Output;
        }
        #endregion //Data Access - Insert

        #region Data Access - Update
        internal void Update(SqlTransaction tr, PhieuNhapXuatCCDC parent)
        {
            if (!IsDirty) return;

            if (base.IsDirty)
            {
                ExecuteUpdate(tr, parent);
                MarkOld();
            }

            //update child object(s)
            UpdateChildren(tr);
        }

        private void ExecuteUpdate(SqlTransaction tr, PhieuNhapXuatCCDC parent)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_UpdatetblCT_PhieuXuat";

                AddUpdateParameters(cm, parent);

                cm.ExecuteNonQuery();

            }//using
        }

        private void AddUpdateParameters(SqlCommand cm, PhieuNhapXuatCCDC parent)
        {
            cm.Parameters.AddWithValue("@MaChiTietPhieuXuat", _maChiTietPhieuXuat);
            cm.Parameters.AddWithValue("@MaPhieuxuat", _maPhieuxuat);
            cm.Parameters.AddWithValue("@SoLuong", _soLuong);
            if (_maDonViTinh != 0)
                cm.Parameters.AddWithValue("@MaDonViTinh", _maDonViTinh);
            else
                cm.Parameters.AddWithValue("@MaDonViTinh", DBNull.Value);
            if (_donGia != 0)
                cm.Parameters.AddWithValue("@DonGia", _donGia);
            else
                cm.Parameters.AddWithValue("@DonGia", DBNull.Value);
            if (_thanhTien != 0)
                cm.Parameters.AddWithValue("@ThanhTien", _thanhTien);
            else
                cm.Parameters.AddWithValue("@ThanhTien", DBNull.Value);
            if (_thoiLuong != 0)
                cm.Parameters.AddWithValue("@ThoiLuong", _thoiLuong);
            else
                cm.Parameters.AddWithValue("@ThoiLuong", DBNull.Value);
            if (_maHangHoa != 0)
                cm.Parameters.AddWithValue("@MaHangHoa", _maHangHoa);
            else
                cm.Parameters.AddWithValue("@MaHangHoa", DBNull.Value);
            if (_maChuongTrinhCon != 0)//M Ban Quyen
                cm.Parameters.AddWithValue("@MaChuongTrinhCon", _maChuongTrinhCon);
            else
                cm.Parameters.AddWithValue("@MaChuongTrinhCon", DBNull.Value);
            if (_dienGiai.Length > 0)
                cm.Parameters.AddWithValue("@DienGiai", _dienGiai);
            else
                cm.Parameters.AddWithValue("@DienGiai", DBNull.Value);
            if (_maPhieuNhap != 0)
                cm.Parameters.AddWithValue("@MaPhieuNhap", _maPhieuNhap);
            else
                cm.Parameters.AddWithValue("@MaPhieuNhap", DBNull.Value);
            cm.Parameters.AddWithValue("@NgayPhatSong", _ngayPhatSong.DBValue);
            if (_ngayNghiemThu.Length > 0)
                cm.Parameters.AddWithValue("@NgayNghiemThu", _ngayNghiemThu);
            else
                cm.Parameters.AddWithValue("@NgayNghiemThu", DBNull.Value);
            if (_maNguon != 0)
                cm.Parameters.AddWithValue("MaNguon", _maNguon);
            else
                cm.Parameters.AddWithValue("MaNguon", DBNull.Value);
            if (_maHopDong != 0)
                cm.Parameters.AddWithValue("MaHopDong", _maHopDong);
            else
                cm.Parameters.AddWithValue("MaHopDong", DBNull.Value);

            if (_MoTaTenCCDC.Length > 0)
                cm.Parameters.AddWithValue("@MoTaTenCCDC", _MoTaTenCCDC);
            else
                cm.Parameters.AddWithValue("@MoTaTenCCDC", DBNull.Value);

            //
            if (_tyLeCK != 0)
                cm.Parameters.AddWithValue("@TyLeCK", _tyLeCK);
            else
                cm.Parameters.AddWithValue("@TyLeCK", DBNull.Value);
            if (_tienChietKhau != 0)
                cm.Parameters.AddWithValue("@TienChietKhau", _tienChietKhau);
            else
                cm.Parameters.AddWithValue("@TienChietKhau", DBNull.Value);
            if (_chiPhiMuaHang != 0)
                cm.Parameters.AddWithValue("@ChiPhiMuaHang", _chiPhiMuaHang);
            else
                cm.Parameters.AddWithValue("@ChiPhiMuaHang", DBNull.Value);
            if (_thueSuatVAT != 0)
                cm.Parameters.AddWithValue("@ThueSuatVAT", _thueSuatVAT);
            else
                cm.Parameters.AddWithValue("@ThueSuatVAT", DBNull.Value);
            if (_tienThue != 0)
                cm.Parameters.AddWithValue("@TienThue", _tienThue);
            else
                cm.Parameters.AddWithValue("@TienThue", DBNull.Value);
            if (_donGiaGoc != 0)
                cm.Parameters.AddWithValue("@DonGiaGoc", _donGiaGoc);
            else
                cm.Parameters.AddWithValue("@DonGiaGoc", DBNull.Value);
            if (_thanhTienGoc != 0)
                cm.Parameters.AddWithValue("@ThanhTienGoc", _thanhTienGoc);
            else
                cm.Parameters.AddWithValue("@ThanhTienGoc", DBNull.Value);
            if (_maChiTietPhieuNhap != 0)
                cm.Parameters.AddWithValue("MaChiTietPhieuNhap", _maChiTietPhieuNhap);
            else
                cm.Parameters.AddWithValue("MaChiTietPhieuNhap", DBNull.Value);
            if (_maCT_KetChuyen != 0)
                cm.Parameters.AddWithValue("@MaCT_KetChuyen", _maCT_KetChuyen);
            else
                cm.Parameters.AddWithValue("@MaCT_KetChuyen", DBNull.Value);
            if (_maCT_KetChuyenCCDC != 0)
                cm.Parameters.AddWithValue("@MaCT_KetChuyenCCDC", _maCT_KetChuyenCCDC);
            else
                cm.Parameters.AddWithValue("@MaCT_KetChuyenCCDC", DBNull.Value);
            if (_maTruong > 0)
                cm.Parameters.AddWithValue("@maTruong", _maTruong);
            else
                cm.Parameters.AddWithValue("@maTruong", DBNull.Value);
        }

        private void UpdateChildren(SqlTransaction tr)
        {
        }
        #endregion //Data Access - Update

        #region Data Access - Delete
        internal void DeleteSelf(SqlTransaction tr)
        {
            if (!IsDirty) return;
            if (IsNew) return;

            ExecuteDelete(tr);
            MarkNew();
        }

        private void ExecuteDelete(SqlTransaction tr)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_DeletetblCT_PhieuXuat";

                cm.Parameters.AddWithValue("@MaChiTietPhieuXuat", this._maChiTietPhieuXuat);

                cm.ExecuteNonQuery();
            }//using
        }
        #endregion //Data Access - Delete
        #endregion //Data Access
    }
}
