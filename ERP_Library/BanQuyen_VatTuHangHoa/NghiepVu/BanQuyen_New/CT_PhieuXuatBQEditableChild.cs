
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;
using System.Windows.Forms;
//07/07/2014
namespace ERP_Library
{
    [Serializable()]
    public class CT_PhieuXuatBQ : Csla.BusinessBase<CT_PhieuXuatBQ>
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

        private int _maChuongTrinh = 0;
        private int _maChuongTrinhCha = 0;
        private int _maChiTietPhieuNhap = 0;


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
                    //_thanhTien = _soLuong * _donGia;
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
                    _soPhieuNhap = PhieuNhapXuat.GetPhieuNhapXuat(_maPhieuNhap).SoPhieu;
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
                        _ngayPhatSong =new SmartDate( value.Value.Date);
                    }
                    PropertyHasChanged("NgayPhatSong");
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

        public int MaChuongTrinh
        {
            get
            {
                CanReadProperty("MaChuongTrinh", true);
                return _maChuongTrinh;
            }
            set
            {
                CanWriteProperty("MaChuongTrinh", true);
                if (!_maChuongTrinh.Equals(value))
                {
                    _maChuongTrinh = value;
                    PropertyHasChanged("MaChuongTrinh");
                }
            }
        }

        public int MaChuongTrinhCha
        {
            get
            {
                CanReadProperty("MaChuongTrinhCha", true);
                return _maChuongTrinhCha;
            }
            set
            {
                CanWriteProperty("MaChuongTrinhCha", true);
                if (!_maChuongTrinhCha.Equals(value))
                {
                    _maChuongTrinhCha = value;
                    PropertyHasChanged("MaChuongTrinhCha");
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
        internal static CT_PhieuXuatBQ NewCT_PhieuXuat()
        {
            return new CT_PhieuXuatBQ();
        }

        internal static CT_PhieuXuatBQ NewCT_PhieuXuat(CT_PhieuNhapBQ _ctPhieuNhap, int _loai)
        {
            return new CT_PhieuXuatBQ(_ctPhieuNhap, _loai);
        }
        public static CT_PhieuXuatBQ NewCT_PhieuXuat(ChuongTrinh_NewBQ _chuongTrinhBanQuyenCon, long _maPhieuNhapxuat, int _maBoPhan, int _maKho, DateTime _ngayNX, string _dienGiaiPhieu)
        {
            return new CT_PhieuXuatBQ(_chuongTrinhBanQuyenCon, _maPhieuNhapxuat, _maBoPhan, _maKho, _ngayNX, _dienGiaiPhieu);
        }
        internal static CT_PhieuXuatBQ NewCT_PhieuXuat(CT_PhieuNhapBQ _ctPhieuNhap, int _maKho, DateTime _ngayNX)
        {
            return new CT_PhieuXuatBQ(_ctPhieuNhap, _maKho, _ngayNX);
        }
        
        internal static CT_PhieuXuatBQ GetCT_PhieuXuat(SafeDataReader dr)
        {
            return new CT_PhieuXuatBQ(dr);
        }

        private CT_PhieuXuatBQ()
        {

            ValidationRules.CheckRules();
            MarkAsChild();
        }
        private CT_PhieuXuatBQ(ChuongTrinh_NewBQ ctbq, long _maPhieuNhapxuat, int _maBoPhan, int _maKho, DateTime _ngayNX, string _dienGiaiphieu)
        {
            _maChuongTrinh = ctbq.MaChuongTrinh;
            if (_maChuongTrinh != 0)
            {
                //Lay Chuong Trinh Cha
                {
                    int maCtCha = ChuongTrinh_New.GetChuongTrinh_New(_maChuongTrinh).MaChuongTrinhCha;
                    if (maCtCha != 0)
                    {
                        _maChuongTrinhCha = maCtCha;
                    }
                    else
                    {
                        _maChuongTrinhCha = _maChuongTrinh;
                    }
                }
            }
            _maHopDong = ctbq.MaHopDong;
            _maNguon = ctbq.MaNguonCT;
            _thoiLuong = ctbq.ThoiLuong;
            _maDonViTinh = ctbq.MaDonViTinh;
            _soLuong = ctbq.SoLuongTon;
            _donGia = ChuongTrinh_NewBQ.GetGiaBinhQuanChuongTrinhBanQuyen(_maPhieuNhapxuat, _maBoPhan, _maKho, ctbq.MaChuongTrinh, ctbq.MaHopDong, _ngayNX);//= ChuongTrinh_NewBQ.GetGiaBinhQuanChuongTrinhBanQuyen(_maPhieuNhapxuat, _maBoPhan, _maKho, ctbq.MaChuongTrinh, ctbq.MaHopDong, ctbq.MaNguonCT, _ngayNX);
            _thanhTien = ChuongTrinh_NewBQ.GetGiaTriChuongTrinhBanQuyen(_maPhieuNhapxuat, _maBoPhan, _maKho, ctbq.MaChuongTrinh, ctbq.MaHopDong, _ngayNX);//= ChuongTrinh_NewBQ.GetGiaTriChuongTrinhBanQuyen(_maPhieuNhapxuat, _maBoPhan, _maKho, ctbq.MaChuongTrinh, ctbq.MaHopDong, ctbq.MaNguonCT, _ngayNX);
            _dienGiai = _dienGiaiphieu;
            ValidationRules.CheckRules();
            MarkAsChild();
        }




        public CT_PhieuXuatBQ(CT_PhieuNhapBQ _ctPhieuNhap, int _loai)
        {
            if (_loai == 4)
            {
                long maHopDong = 0;
                NhapXuat_HopDongList nx_HopDongList = NhapXuat_HopDongList.GetNhapXuat_HopDongList(_ctPhieuNhap.MaPhieuNhap);
                if (nx_HopDongList.Count != 0)
                    maHopDong = nx_HopDongList[0].MaHopDong;
                _maPhieuNhap = _ctPhieuNhap.MaPhieuNhap;
                _soPhieuNhap = PhieuNhapXuatBQ.GetPhieuNhapXuat(_maPhieuNhap).SoPhieu;
                _maChuongTrinhCon = _ctPhieuNhap.MaChuongTrinhCon;
                _maHangHoa = _ctPhieuNhap.MaHangHoa;
                _maDonViTinh = _ctPhieuNhap.MaDonViTinh;
                _thoiLuong = _ctPhieuNhap.ThoiLuong;
                _dienGiai = _ctPhieuNhap.DienGiai;
                _maNguon = _ctPhieuNhap.MaNguon;
                _maHopDong = maHopDong;
                _soLuong = _ctPhieuNhap.SoLuong;
                _donGia = _ctPhieuNhap.DonGia;
                _thanhTien = _ctPhieuNhap.ThanhTien;
                _ngayNghiemThu = _ctPhieuNhap.NgayNghiemThu;
                _maChuongTrinh = _ctPhieuNhap.MaChuongTrinh;
                _maChiTietPhieuNhap = _ctPhieuNhap.MaChiTietPhieuNhap;//M
            }
            else
            {

                _maPhieuNhap = _ctPhieuNhap.MaPhieuNhap;
                _maHangHoa = _ctPhieuNhap.MaHangHoa;
                _donGia = _ctPhieuNhap.DonGia;
                _soLuong = (Int64)(_ctPhieuNhap.SoLuong - _ctPhieuNhap.SoLuongXuat);
                _maDonViTinh = _ctPhieuNhap.MaDonViTinh;
                _thoiLuong = _ctPhieuNhap.ThoiLuong;
                _dienGiai = _ctPhieuNhap.DienGiai;
                _maNguon = _ctPhieuNhap.MaNguon;
                _sLgCt_PNhap = _ctPhieuNhap.SoLuong - _ctPhieuNhap.SoLuongXuat;//M
                _donGiaCT_PNhap = _ctPhieuNhap.DonGia;
                _thanhTienCT_PNhap = _ctPhieuNhap.ThanhTien;//M
                _thanhTien = _ctPhieuNhap.ThanhTien;
                _maChuongTrinh = _ctPhieuNhap.MaChuongTrinh;
                _maChiTietPhieuNhap = _ctPhieuNhap.MaChiTietPhieuNhap;//M
            }
            ValidationRules.CheckRules();
            MarkAsChild();
        }

        public CT_PhieuXuatBQ(CT_PhieuNhapBQ _ctPhieuNhap, int _maKho, DateTime _ngayLap)//
        {

            _maPhieuNhap = _ctPhieuNhap.MaPhieuNhap;
            _maHangHoa = _ctPhieuNhap.MaHangHoa;
            _donGia = _ctPhieuNhap.DonGia;
            _soLuong = (Int64)(_ctPhieuNhap.SoLuong - _ctPhieuNhap.SoLuongXuat);
            _maDonViTinh = _ctPhieuNhap.MaDonViTinh;
            _thoiLuong = _ctPhieuNhap.ThoiLuong;
            _dienGiai = _ctPhieuNhap.DienGiai;
            _maNguon = _ctPhieuNhap.MaNguon;
            _ngayNghiemThu = _ctPhieuNhap.NgayNghiemThu;
            _sLgCt_PNhap = _ctPhieuNhap.SoLuong - _ctPhieuNhap.SoLuongXuat;//M
            _donGiaCT_PNhap = _ctPhieuNhap.DonGia;
            _thanhTienCT_PNhap = _ctPhieuNhap.ThanhTien;//M
            _maChuongTrinh = _ctPhieuNhap.MaChuongTrinh;
            _maChiTietPhieuNhap = _ctPhieuNhap.MaChiTietPhieuNhap;//M
            //_thanhTien = _ctPhieuNhap.ThanhTien;
            if (_soLuong == HangHoaBQ_VT.GetSoLuongHangHoaBinhQuan(0, _maKho, _maHangHoa, _ngayLap))
                _thanhTien = HangHoaBQ_VT.GetGiaTriHangHoaBinhQuan(0, _maKho, _maHangHoa, _ngayLap);
            else
                _thanhTien = _thanhTien = _soLuong * _ctPhieuNhap.DonGia; //_ctPhieuNhap.ThanhTien;
            ValidationRules.CheckRules();
            MarkAsChild();
        }
        public CT_PhieuXuatBQ(CT_PhieuNhapBQ _ctPhieuNhap, int maBoPhan, int _maKho, long maHopDong, DateTime _ngayLap)//Binh Quan Ban Quyen
        {

            _maPhieuNhap = _ctPhieuNhap.MaPhieuNhap;
            _maHangHoa = _ctPhieuNhap.MaHangHoa;
            _donGia = _ctPhieuNhap.DonGia;
            //_donGia = HangHoaBQ_VT.GetGiaBinhQuanChuongTrinhBQ(0,maBoPhan, _maKho, _maHangHoa, maHopDong, _ngayLap);
            _soLuong = (Int64)(_ctPhieuNhap.SoLuong - _ctPhieuNhap.SoLuongXuat);
            _maDonViTinh = _ctPhieuNhap.MaDonViTinh;
            _thoiLuong = _ctPhieuNhap.ThoiLuong;
            _dienGiai = _ctPhieuNhap.DienGiai;
            _maNguon = _ctPhieuNhap.MaNguon;
            _maHopDong = maHopDong;
            _ngayNghiemThu = _ctPhieuNhap.NgayNghiemThu;
            _sLgCt_PNhap = _ctPhieuNhap.SoLuong - _ctPhieuNhap.SoLuongXuat;//M
            _donGiaCT_PNhap = _ctPhieuNhap.DonGia;
            _thanhTienCT_PNhap = _ctPhieuNhap.ThanhTien;//M
            _maChuongTrinh = _ctPhieuNhap.MaChuongTrinh;
            _maChiTietPhieuNhap = _ctPhieuNhap.MaChiTietPhieuNhap;//M
            //_thanhTien = _ctPhieuNhap.ThanhTien;
            if (_soLuong == HangHoaBQ_VT.GetSoLuongChuongTrinhBQ(0, maBoPhan, _maKho, _maHangHoa, maHopDong, _ngayLap))
                _thanhTien = HangHoaBQ_VT.GetGiaTriChuongTrinhBQ(0, maBoPhan, _maKho, _maHangHoa, maHopDong, _ngayLap);
            else
                _thanhTien = Math.Round(_donGia * _soLuong, 0, MidpointRounding.AwayFromZero);
            ValidationRules.CheckRules();
            MarkAsChild();
        }//END Binh Quan Ban Quyen
        public CT_PhieuXuatBQ(CT_PhieuNhapBQ _ctPhieuNhap, int maBoPhan, int _maKho, int _phuongPhapNX, long maHopDong, DateTime _ngayLap)//Cho Xuat Thang and Binh Quan Ban Quyen
        {

            _maPhieuNhap = _ctPhieuNhap.MaPhieuNhap;
            _soPhieuNhap = PhieuNhapXuatBQ.GetPhieuNhapXuat(_maPhieuNhap).SoPhieu;
            _maHangHoa = _ctPhieuNhap.MaHangHoa;
            _maChuongTrinhCon = _ctPhieuNhap.MaChuongTrinhCon;//
            _donGia = _ctPhieuNhap.DonGia;
            _soLuong = (Int64)(_ctPhieuNhap.SoLuong - _ctPhieuNhap.SoLuongXuat);
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
            _maChuongTrinh = _ctPhieuNhap.MaChuongTrinh;
            _maChiTietPhieuNhap = _ctPhieuNhap.MaChiTietPhieuNhap;//M
            if (_maChuongTrinh != 0)
            {
                //Lay Chuong Trinh Cha
                {
                    int maCtCha = ChuongTrinh_New.GetChuongTrinh_New(_maChuongTrinh).MaChuongTrinhCha;
                    if (maCtCha != 0)
                    {
                        _maChuongTrinhCha = maCtCha;
                    }
                    else
                    {
                        _maChuongTrinhCha = _maChuongTrinh;
                    }
                }
            }
            if (_soLuong == ChuongTrinh_NewBQ.GetSoLuongChuongTrinhBanQuyen_NXT(0, maBoPhan, _maKho, _phuongPhapNX, _maPhieuNhap, _maChuongTrinh, maHopDong, _ngayLap, _maChiTietPhieuNhap))
            //if (_soLuong == ChuongTrinh_NewBQ.GetSoLuongChuongTrinhBanQuyenTheoMaChiTietPhieuNhap_NXT(0, _maChiTietPhieuNhap, _ngayLap))
            {
                _thanhTien = ChuongTrinh_NewBQ.GetGiaTriChuongTrinhBanQuyen_NXT(0, maBoPhan, _maKho, _phuongPhapNX, _maPhieuNhap, _maChuongTrinh, maHopDong, _ngayLap, _maChiTietPhieuNhap);
                //_thanhTien = ChuongTrinh_NewBQ.GetGiaTriChuongTrinhBanQuyenTheoMaChiTietPhieuNhap_NXT(0, _maChiTietPhieuNhap, _ngayLap);
                //if (_soLuong == 1)
                //    _donGia = _thanhTien;
            }
            else
                _thanhTien = Math.Round(_donGia * _soLuong, 0, MidpointRounding.AwayFromZero);
            ValidationRules.CheckRules();
            MarkAsChild();
        }//END Cho Xuat Thang Ban Quyen , _phieuXuat.MaPhongBan, _phieuXuat.PhuongPhapNX, _phieuXuat.MaKho, _phieuXuat.NgayNX

        public CT_PhieuXuatBQ(CT_PhieuXuatBQ _ctPhieuXuat)
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
            _maChuongTrinh = _ctPhieuXuat.MaChuongTrinh;
            _maChiTietPhieuNhap = _ctPhieuXuat.MaChiTietPhieuNhap;//M
            ValidationRules.CheckRules();
            MarkAsChild();
        }
        public CT_PhieuXuatBQ(CT_PhieuXuatBQ _ctPhieuXuat, int _maKho, DateTime _ngayLap)
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
            _maChuongTrinh = _ctPhieuXuat.MaChuongTrinh;
            _maChiTietPhieuNhap = _ctPhieuXuat.MaChiTietPhieuNhap;//M
            //_thanhTien = _ctPhieuXuat.ThanhTien;
            if (_soLuong == HangHoaBQ_VT.GetSoLuongHangHoaBinhQuan(0, _maKho, _maHangHoa, _ngayLap))
                _thanhTien = HangHoaBQ_VT.GetGiaTriHangHoaBinhQuan(0, _maKho, _maHangHoa, _ngayLap);
            else
                _thanhTien = _ctPhieuXuat.ThanhTien;
            ValidationRules.CheckRules();
            MarkAsChild();
        }

        private CT_PhieuXuatBQ(SafeDataReader dr)
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
            _soPhieuNhap = PhieuNhapXuat.GetPhieuNhapXuat(_maPhieuNhap).SoPhieu;
            _ngayPhatSong = dr.GetSmartDate("NgayPhatSong", _ngayPhatSong.EmptyIsMin);
            //_ngayNghiemThu = dr.GetSmartDate("NgayNghiemThu", _ngayNghiemThu.EmptyIsMin);
            _ngayNghiemThu = dr.GetString("NgayNghiemThu");
            _maNguon = dr.GetInt32("MaNguon");
            _maHopDong = dr.GetInt64("MaHopDong");
            _soLuongLuu = _soLuong;//M
            _thanhTienLuu = _thanhTien;//M
            _donGiaLuu = _donGia;//M

            _maChuongTrinh = dr.GetInt32("MaChuongTrinh");
            if (_maChuongTrinh != 0)
            {
                //Lay Chuong Trinh Cha
                {
                    int maCtCha = ChuongTrinh_New.GetChuongTrinh_New(_maChuongTrinh).MaChuongTrinhCha;
                    if (maCtCha != 0)
                    {
                        _maChuongTrinhCha = maCtCha;
                    }
                    else
                    {
                        _maChuongTrinhCha = _maChuongTrinh;
                    }
                }
            }

            _maChiTietPhieuNhap = dr.GetInt32("MaChiTietPhieuNhap");

        }

        private void FetchChildren(SafeDataReader dr)
        {
        }
        #endregion //Data Access - Fetch

        #region Data Access - Insert
        internal void Insert(SqlTransaction tr, PhieuNhapXuatBQ parent)
        {
            if (!IsDirty) return;

            ExecuteInsert(tr, parent);
            MarkOld();

            //update child object(s)
            UpdateChildren(tr);
        }

        private void ExecuteInsert(SqlTransaction tr, PhieuNhapXuatBQ parent)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_InserttblCT_PhieuXuat_BQ";

                AddInsertParameters(cm, parent);

                cm.ExecuteNonQuery();

                _maChiTietPhieuXuat = (int)cm.Parameters["@MaChiTietPhieuXuat"].Value;
            }//using
        }

        private void AddInsertParameters(SqlCommand cm, PhieuNhapXuatBQ parent)
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

            if (_maChuongTrinh != 0)
                cm.Parameters.AddWithValue("MaChuongTrinh", _maChuongTrinh);
            else
                cm.Parameters.AddWithValue("MaChuongTrinh", DBNull.Value);

            if (_maChiTietPhieuNhap != 0)
                cm.Parameters.AddWithValue("MaChiTietPhieuNhap", _maChiTietPhieuNhap);
            else
                cm.Parameters.AddWithValue("MaChiTietPhieuNhap", DBNull.Value);

            cm.Parameters.AddWithValue("@MaChiTietPhieuXuat", _maChiTietPhieuXuat);
            cm.Parameters["@MaChiTietPhieuXuat"].Direction = ParameterDirection.Output;
        }
        #endregion //Data Access - Insert

        #region Data Access - Update
        internal void Update(SqlTransaction tr, PhieuNhapXuatBQ parent)
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

        private void ExecuteUpdate(SqlTransaction tr, PhieuNhapXuatBQ parent)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_UpdatetblCT_PhieuXuat_BQ";

                AddUpdateParameters(cm, parent);

                cm.ExecuteNonQuery();

            }//using
        }

        private void AddUpdateParameters(SqlCommand cm, PhieuNhapXuatBQ parent)
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

            if (_maChuongTrinh != 0)
                cm.Parameters.AddWithValue("MaChuongTrinh", _maChuongTrinh);
            else
                cm.Parameters.AddWithValue("MaChuongTrinh", DBNull.Value);

            if (_maChiTietPhieuNhap != 0)
                cm.Parameters.AddWithValue("MaChiTietPhieuNhap", _maChiTietPhieuNhap);
            else
                cm.Parameters.AddWithValue("MaChiTietPhieuNhap", DBNull.Value);
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
                cm.CommandText = "spd_DeletetblCT_PhieuXuat_BQ";

                cm.Parameters.AddWithValue("@MaChiTietPhieuXuat", this._maChiTietPhieuXuat);

                cm.ExecuteNonQuery();
            }//using
        }
        #endregion //Data Access - Delete
        #endregion //Data Access
    }
}
