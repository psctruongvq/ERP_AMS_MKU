
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;
//23_03_2013
namespace ERP_Library
{
    [Serializable()]
    public class CT_PhieuNhap : Csla.BusinessBase<CT_PhieuNhap>
    {
        #region Business Properties and Methods

        //declare members
        private int _maChiTietPhieuNhap = 0;
        private long _maPhieuNhap = 0;
        private int _maHangHoa = 0;
        private int _maChuongTrinhCon = 0;//M Ban Quyen
        private decimal _donGia = 0;
        private decimal _thanhTien = 0;
        private decimal _soLuong = 0;
        private int _maDonViTinh = 0;
        private decimal _thoiLuong = 0;
        private string _dienGiai = string.Empty;
        private decimal _soLuongXuat = 0;
        private decimal _soLuongConLai = 0;
        //private SmartDate _ngayNghiemThu = new SmartDate(DateTime.Today);
        private string _ngayNghiemThu = string.Empty;
        private int _maNguon = 0;
        private string _MoTaTenCCDC = string.Empty;
        //Me
        private bool _checkChon;

        private double _tyLeCK = 0;
        private decimal _tienChietKhau = 0;
        private decimal _chiPhiMuaHang = 0;
        private double _thueSuatVAT = 0;
        private decimal _tienThue = 0;

        private decimal _donGiaGoc = 0;
        private decimal _thanhTienGoc = 0;
        private string _soPhieu = string.Empty;
        private int _maBoPhan = 0;
        private long _maCT_KetChuyen = 0;
        private string _maQLHangHoa = string.Empty;  //trinh bay len luoi de filter
        private string _tenHangHoa = string.Empty;

        [System.ComponentModel.DataObjectField(true, true)]
        public int MaChiTietPhieuNhap
        {
            get
            {
                CanReadProperty("MaChiTietPhieuNhap", true);
                return _maChiTietPhieuNhap;
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
                }
            }
        }

        public string SoPhieu
        {
            get
            {
                return _soPhieu;
            }
        }

        public string MaQLHangHoa
        {
            get
            {
                return _maQLHangHoa;
            }
        }

        public string TenHangHoa
        {
            get
            {
                return _tenHangHoa;
            }
        }


        public int MaBoPhan
        {
            get
            {
                CanReadProperty("MaBoPhan", true);
                return _maBoPhan;
            }
            set
            {
                CanWriteProperty("MaBoPhan", true);
                if (!_maBoPhan.Equals(value))
                {
                    _maBoPhan = value;
                    PropertyHasChanged("MaBoPhan");
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
                    //_thanhTienGoc = _soLuong * _donGiaGoc;
                    ThanhTienGoc = _soLuong * _donGiaGoc;
                    TienChietKhau = (_thanhTienGoc * (decimal)_tyLeCK) / 100;
                    TienThue = ((_thanhTienGoc - _tienChietKhau) * (decimal)_thueSuatVAT) / 100;
                    PropertyHasChanged("SoLuong");
                    _soLuongXuat = 0;//New 19112013
                    _soLuongConLai = 0;//New 19112013
                }
            }
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

        public decimal SoLuongXuat
        {
            get
            {
                CanReadProperty("SoLuongXuat", true);
                return _soLuongXuat;
            }
            set
            {
                CanWriteProperty("SoLuongXuat", true);
                if (!_soLuongXuat.Equals(value))
                {
                    _soLuongXuat = value;
                    PropertyHasChanged("SoLuongXuat");
                }
            }
        }

        public decimal SoLuongConLai
        {
            get
            {
                CanReadProperty("SoLuongConLai", true);
                //return _soLuongConLai;
                return (_soLuong - _soLuongXuat);
            }
            set
            {
                CanWriteProperty("SoLuongConLai", true);
                if (!_soLuongConLai.Equals(value))
                {
                    _soLuongConLai = value;
                    PropertyHasChanged("SoLuongConLai");
                }
            }
        }
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
        //Me
        public bool CheckChon
        {
            get { return _checkChon; }
            set { _checkChon = value; }
        }

        //Me
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
                    TienChietKhau = (_thanhTienGoc * (decimal)_tyLeCK) / 100;
                    TienThue = ((_thanhTienGoc - _tienChietKhau) * (decimal)_thueSuatVAT) / 100;
                    Method_TinhDonGiaThanhTien();
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
                    Method_TinhDonGiaThanhTien();
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
                    TienThue = ((_thanhTienGoc - _tienChietKhau) * (decimal)_thueSuatVAT) / 100;
                    Method_TinhDonGiaThanhTien();
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
                    Method_TinhDonGiaThanhTien();
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
                    ThanhTienGoc = SoLuong * DonGiaGoc;
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
                    TienChietKhau = Math.Round((_thanhTienGoc * (decimal)_tyLeCK) / 100);
                    TienThue = ((_thanhTienGoc - _tienChietKhau) * (decimal)_thueSuatVAT) / 100;
                    Method_TinhDonGiaThanhTien();

                    if (_soLuong != 0)
                    {
                        _donGiaGoc = Math.Round(_thanhTienGoc / _soLuong, 0);
                    }

                    PropertyHasChanged("ThanhTienGoc");
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


        protected override object GetIdValue()
        {
            return _maChiTietPhieuNhap;
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
            //TODO: Define authorization rules in CT_PhieuNhap
            //AuthorizationRules.AllowRead("MaChiTietPhieuNhap", "CT_PhieuNhapReadGroup");
            //AuthorizationRules.AllowRead("MaPhieuNhap", "CT_PhieuNhapReadGroup");
            //AuthorizationRules.AllowRead("MaHangHoa", "CT_PhieuNhapReadGroup");
            //AuthorizationRules.AllowRead("DonGia", "CT_PhieuNhapReadGroup");
            //AuthorizationRules.AllowRead("ThanhTien", "CT_PhieuNhapReadGroup");
            //AuthorizationRules.AllowRead("SoLuong", "CT_PhieuNhapReadGroup");
            //AuthorizationRules.AllowRead("MaDonViTinh", "CT_PhieuNhapReadGroup");
            //AuthorizationRules.AllowRead("ThoiLuong", "CT_PhieuNhapReadGroup");
            //AuthorizationRules.AllowRead("DienGiai", "CT_PhieuNhapReadGroup");
            //AuthorizationRules.AllowRead("SoLuongXuat", "CT_PhieuNhapReadGroup");
            //AuthorizationRules.AllowRead("SoLuongConLai", "CT_PhieuNhapReadGroup");

            //AuthorizationRules.AllowWrite("MaPhieuNhap", "CT_PhieuNhapWriteGroup");
            //AuthorizationRules.AllowWrite("MaHangHoa", "CT_PhieuNhapWriteGroup");
            //AuthorizationRules.AllowWrite("DonGia", "CT_PhieuNhapWriteGroup");
            //AuthorizationRules.AllowWrite("ThanhTien", "CT_PhieuNhapWriteGroup");
            //AuthorizationRules.AllowWrite("SoLuong", "CT_PhieuNhapWriteGroup");
            //AuthorizationRules.AllowWrite("MaDonViTinh", "CT_PhieuNhapWriteGroup");
            //AuthorizationRules.AllowWrite("ThoiLuong", "CT_PhieuNhapWriteGroup");
            //AuthorizationRules.AllowWrite("DienGiai", "CT_PhieuNhapWriteGroup");
            //AuthorizationRules.AllowWrite("SoLuongXuat", "CT_PhieuNhapWriteGroup");
            //AuthorizationRules.AllowWrite("SoLuongConLai", "CT_PhieuNhapWriteGroup");
        }

        #endregion //Authorization Rules

        #region Factory Methods
        internal static CT_PhieuNhap NewCT_PhieuNhap()
        {
            return new CT_PhieuNhap();
        }

        internal static CT_PhieuNhap GetCT_PhieuNhap(SafeDataReader dr)
        {
            return new CT_PhieuNhap(dr);
        }

        internal static CT_PhieuNhap GetCT_PhieuNhap_ForXuatDichDanh(SafeDataReader dr)
        {
            return new CT_PhieuNhap(dr, "XuatDichDanh");
        }

        private CT_PhieuNhap()
        {

            ValidationRules.CheckRules();
            MarkAsChild();
        }
        public CT_PhieuNhap(CT_PhieuNhap _ct_PhieuNhap)
        {
            _maChuongTrinhCon = _ct_PhieuNhap.MaChuongTrinhCon;
            _maHangHoa = _ct_PhieuNhap.MaHangHoa;
            _donGia = _ct_PhieuNhap.DonGia;
            _thanhTien = _ct_PhieuNhap.ThanhTien;
            _soLuong = _ct_PhieuNhap.SoLuong;
            _maDonViTinh = _ct_PhieuNhap.MaDonViTinh;
            _thoiLuong = _ct_PhieuNhap.ThoiLuong;
            _ngayNghiemThu = _ct_PhieuNhap.NgayNghiemThu;
            _dienGiai = _ct_PhieuNhap.DienGiai;
            _maNguon = _ct_PhieuNhap.MaNguon;
            _MoTaTenCCDC = _ct_PhieuNhap.MoTaTenCCDC;
            //
            _tyLeCK = _ct_PhieuNhap.TyLeCK;
            _tienChietKhau = _ct_PhieuNhap.TienChietKhau;
            _chiPhiMuaHang = _ct_PhieuNhap.ChiPhiMuaHang;
            _thueSuatVAT = _ct_PhieuNhap.ThueSuatVAT;
            _tienThue = _ct_PhieuNhap.TienThue;
            _donGiaGoc = _ct_PhieuNhap.DonGiaGoc;
            _thanhTienGoc = _ct_PhieuNhap.ThanhTienGoc;
            ValidationRules.CheckRules();
            MarkAsChild();
        }

        private CT_PhieuNhap(SafeDataReader dr)
        {
            MarkAsChild();
            Fetch(dr);
        }

        private CT_PhieuNhap(SafeDataReader dr, string flag)
        {
            MarkAsChild();
            Fetch_ForXuatDichDanh(dr);
        }

        public CT_PhieuNhap(CT_KiemKeTonKho cT_KiemKeTonKho)
        {

            _maHangHoa = cT_KiemKeTonKho.MaHangHoa;
            HangHoaBQ_VT _hangHoaBQ_VT = HangHoaBQ_VT.GetHangHoaBQ_VT(_maHangHoa);
            //_thanhTien = (cT_KiemKeTonKho.GiaTriDieuChinh > 0) ? cT_KiemKeTonKho.GiaTriDieuChinh : 0;
            //_soLuong = (cT_KiemKeTonKho.SLDieuChinh > 0) ? (short)cT_KiemKeTonKho.SLDieuChinh : (short)0;
            _thanhTien = (cT_KiemKeTonKho.GiaTriDieuChinh < 0) ? Math.Abs(cT_KiemKeTonKho.GiaTriDieuChinh) : 0;
            _soLuong = (cT_KiemKeTonKho.SLDieuChinh < 0) ? Math.Abs((short)cT_KiemKeTonKho.SLDieuChinh) : (short)0;
            _maDonViTinh = _hangHoaBQ_VT.MaDonViTinh;
            _thoiLuong = _hangHoaBQ_VT.ThoiLuong;
            _donGia = (_soLuong != 0) ? Math.Round(_thanhTien / _soLuong, 0) : 0;
        }

        private void Method_TinhDonGiaThanhTien()
        {
            _thanhTien = Math.Round(_thanhTienGoc - _tienChietKhau + _tienThue);
            _donGia = Math.Round(_thanhTien / (_soLuong == 0 ? 1 : _soLuong));
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

        private void Fetch_ForXuatDichDanh(SafeDataReader dr)
        {
            FetchObject_ForXuatDichDanh(dr);
            MarkOld();
            ValidationRules.CheckRules();

        }

        private void FetchObject(SafeDataReader dr)
        {
            _maChiTietPhieuNhap = dr.GetInt32("MaChiTietPhieuNhap");
            _maPhieuNhap = dr.GetInt64("MaPhieuNhap");
            _maHangHoa = dr.GetInt32("MaHangHoa");
            _maChuongTrinhCon = dr.GetInt32("MaChuongTrinhCon");//M Ban Quyen
            _donGia = dr.GetDecimal("DonGia");
            _thanhTien = dr.GetDecimal("ThanhTien");
            _soLuong = dr.GetDecimal("SoLuong");
            _maDonViTinh = dr.GetInt32("MaDonViTinh");
            _thoiLuong = dr.GetDecimal("ThoiLuong");
            _dienGiai = dr.GetString("DienGiai");
            _soLuongXuat = dr.GetDecimal("SoLuongXuat");
            //_soLuongConLai = dr.GetDecimal("SoLuongConLai");
            _soLuongConLai = _soLuong - _soLuongXuat;
            //_ngayNghiemThu = dr.GetSmartDate("NgayNghiemThu", _ngayNghiemThu.EmptyIsMin);
            _ngayNghiemThu = dr.GetString("NgayNghiemThu");
            _maNguon = dr.GetInt32("MaNguon");
            _MoTaTenCCDC = dr.GetString("MoTaTenCCDC");

            _tyLeCK = dr.GetDouble("TyLeCK");
            _tienChietKhau = dr.GetDecimal("TienChietKhau");
            _chiPhiMuaHang = dr.GetDecimal("ChiPhiMuaHang");
            _thueSuatVAT = dr.GetDouble("ThueSuatVAT");
            _tienThue = dr.GetDecimal("TienThue");
            _donGiaGoc = dr.GetDecimal("DonGiaGoc");
            _thanhTienGoc = dr.GetDecimal("ThanhTienGoc");
            _soPhieu = dr.GetString("SoPhieu");
            _maBoPhan = dr.GetInt32("MaBoPhan");
            _maQLHangHoa = dr.GetString("MaQLHangHoa");
            _tenHangHoa = dr.GetString("TenHangHoa");
        }

        private void FetchChildren(SafeDataReader dr)
        {
        }

        private void FetchObject_ForXuatDichDanh(SafeDataReader dr)
        {
            _maChiTietPhieuNhap = dr.GetInt32("MaChiTietPhieuNhap");
            _maPhieuNhap = dr.GetInt64("MaPhieuNhap");
            _maHangHoa = dr.GetInt32("MaHangHoa");
            _maChuongTrinhCon = dr.GetInt32("MaChuongTrinhCon");//M Ban Quyen
            _donGia = dr.GetDecimal("DonGia");
            _thanhTien = dr.GetDecimal("ThanhTien");
            _soLuong = dr.GetDecimal("SoLuong");
            _maDonViTinh = dr.GetInt32("MaDonViTinh");
            _thoiLuong = dr.GetDecimal("ThoiLuong");
            _dienGiai = dr.GetString("DienGiai");
            _soLuongXuat = dr.GetDecimal("SoLuongXuat");
            //_soLuongConLai = dr.GetDecimal("SoLuongConLai");
            _soLuongConLai = _soLuong - _soLuongXuat;
            //_ngayNghiemThu = dr.GetSmartDate("NgayNghiemThu", _ngayNghiemThu.EmptyIsMin);
            _ngayNghiemThu = dr.GetString("NgayNghiemThu");
            _maNguon = dr.GetInt32("MaNguon");
            _MoTaTenCCDC = dr.GetString("MoTaTenCCDC");

            _tyLeCK = dr.GetDouble("TyLeCK");
            _tienChietKhau = dr.GetDecimal("TienChietKhau");
            _chiPhiMuaHang = dr.GetDecimal("ChiPhiMuaHang");
            _thueSuatVAT = dr.GetDouble("ThueSuatVAT");
            _tienThue = dr.GetDecimal("TienThue");
            _donGiaGoc = dr.GetDecimal("DonGiaGoc");
            _thanhTienGoc = dr.GetDecimal("ThanhTienGoc");
            _soPhieu = dr.GetString("SoPhieu");
            _maBoPhan = dr.GetInt32("MaBoPhan");
            _maCT_KetChuyen = dr.GetInt64("MaCT_KetChuyen");
            _maQLHangHoa = dr.GetString("MaQLHangHoa");
            _tenHangHoa = dr.GetString("TenHangHoa");
        }

        #endregion //Data Access - Fetch

        #region Data Access - Insert
        internal void Insert(SqlTransaction tr, PhieuNhapXuat parent)
        {
            if (!IsDirty) return;

            ExecuteInsert(tr, parent);
            MarkOld();

            //update child object(s)
            UpdateChildren(tr);
        }

        private void ExecuteInsert(SqlTransaction tr, PhieuNhapXuat parent)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_InserttblCT_PhieuNhap";

                AddInsertParameters(cm, parent);

                cm.ExecuteNonQuery();

                _maChiTietPhieuNhap = (int)cm.Parameters["@MaChiTietPhieuNhap"].Value;
            }//using
        }

        private void AddInsertParameters(SqlCommand cm, PhieuNhapXuat parent)
        {
            //TODO: if parent use identity key, fix fk member with value from parent
            _maPhieuNhap = parent.MaPhieuNhapXuat;
            cm.Parameters.AddWithValue("@MaPhieuNhap", _maPhieuNhap);
            cm.Parameters.AddWithValue("@MaHangHoa", _maHangHoa);
            if (_maChuongTrinhCon != 0)//Ban Quyen
                cm.Parameters.AddWithValue("@MaChuongTrinhCon", _maChuongTrinhCon);
            else
                cm.Parameters.AddWithValue("@MaChuongTrinhCon", DBNull.Value);
            cm.Parameters.AddWithValue("@DonGia", _donGia);
            cm.Parameters.AddWithValue("@ThanhTien", _thanhTien);
            cm.Parameters.AddWithValue("@SoLuong", _soLuong);
            if (_maDonViTinh != 0)
                cm.Parameters.AddWithValue("@MaDonViTinh", _maDonViTinh);
            else
                cm.Parameters.AddWithValue("@MaDonViTinh", DBNull.Value);
            if (_thoiLuong != 0)
                cm.Parameters.AddWithValue("@ThoiLuong", _thoiLuong);
            else
                cm.Parameters.AddWithValue("@ThoiLuong", DBNull.Value);
            if (_dienGiai.Length > 0)
                cm.Parameters.AddWithValue("@DienGiai", _dienGiai);
            else
                cm.Parameters.AddWithValue("@DienGiai", DBNull.Value);
            cm.Parameters.AddWithValue("@SoLuongXuat", _soLuongXuat);
            cm.Parameters.AddWithValue("@SoLuongConLai", _soLuong - _soLuongXuat);
            if (_ngayNghiemThu.Length > 0)
                cm.Parameters.AddWithValue("@NgayNghiemThu", _ngayNghiemThu);
            else
                cm.Parameters.AddWithValue("@NgayNghiemThu", DBNull.Value);
            if (_maNguon != 0)
                cm.Parameters.AddWithValue("MaNguon", _maNguon);
            else
                cm.Parameters.AddWithValue("MaNguon", DBNull.Value);

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

            if (_maBoPhan > 0)
                cm.Parameters.AddWithValue("@MaBoPhan", _maBoPhan);
            else
                cm.Parameters.AddWithValue("@MaBoPhan", DBNull.Value);

            cm.Parameters.AddWithValue("@MaChiTietPhieuNhap", _maChiTietPhieuNhap);
            cm.Parameters["@MaChiTietPhieuNhap"].Direction = ParameterDirection.Output;
        }
        #endregion //Data Access - Insert

        #region Data Access - Update
        internal void Update(SqlTransaction tr, PhieuNhapXuat parent)
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

        private void ExecuteUpdate(SqlTransaction tr, PhieuNhapXuat parent)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_UpdatetblCT_PhieuNhap";

                AddUpdateParameters(cm, parent);

                cm.ExecuteNonQuery();

            }//using
        }

        private void AddUpdateParameters(SqlCommand cm, PhieuNhapXuat parent)
        {
            cm.Parameters.AddWithValue("@MaChiTietPhieuNhap", _maChiTietPhieuNhap);
            cm.Parameters.AddWithValue("@MaPhieuNhap", _maPhieuNhap);
            cm.Parameters.AddWithValue("@MaHangHoa", _maHangHoa);
            if (_maChuongTrinhCon != 0)
                cm.Parameters.AddWithValue("@MaChuongTrinhCon", _maChuongTrinhCon);//M Ban Quyen
            else
                cm.Parameters.AddWithValue("@MaChuongTrinhCon", DBNull.Value);//M Ban Quyen
            cm.Parameters.AddWithValue("@DonGia", _donGia);
            cm.Parameters.AddWithValue("@ThanhTien", _thanhTien);
            cm.Parameters.AddWithValue("@SoLuong", _soLuong);
            if (_maDonViTinh != 0)
                cm.Parameters.AddWithValue("@MaDonViTinh", _maDonViTinh);
            else
                cm.Parameters.AddWithValue("@MaDonViTinh", DBNull.Value);
            if (_thoiLuong != 0)
                cm.Parameters.AddWithValue("@ThoiLuong", _thoiLuong);
            else
                cm.Parameters.AddWithValue("@ThoiLuong", DBNull.Value);
            if (_dienGiai.Length > 0)
                cm.Parameters.AddWithValue("@DienGiai", _dienGiai);
            else
                cm.Parameters.AddWithValue("@DienGiai", DBNull.Value);
            cm.Parameters.AddWithValue("@SoLuongXuat", _soLuongXuat);
            cm.Parameters.AddWithValue("@SoLuongConLai", _soLuong - _soLuongXuat);
            if (_ngayNghiemThu.Length > 0)
                cm.Parameters.AddWithValue("@NgayNghiemThu", _ngayNghiemThu);
            else
                cm.Parameters.AddWithValue("@NgayNghiemThu", DBNull.Value);
            if (_maNguon != 0)
                cm.Parameters.AddWithValue("MaNguon", _maNguon);
            else
                cm.Parameters.AddWithValue("MaNguon", DBNull.Value);

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
            if (_maBoPhan > 0)
                cm.Parameters.AddWithValue("@MaBoPhan", _maBoPhan);
            else
                cm.Parameters.AddWithValue("@MaBoPhan", DBNull.Value);
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
                cm.CommandText = "spd_DeletetblCT_PhieuNhap";

                cm.Parameters.AddWithValue("@MaChiTietPhieuNhap", this._maChiTietPhieuNhap);

                cm.ExecuteNonQuery();
            }//using
        }
        #endregion //Data Access - Delete
        #endregion //Data Access

    }
}
