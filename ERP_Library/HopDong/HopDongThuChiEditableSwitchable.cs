
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{
    //Thành
    [Serializable()]
    public class HopDongThuChi : Csla.BusinessBase<HopDongThuChi>
    {

        public override string ToString()
        {
            return _tenHopDong;
        }

        #region Business Properties and Methods

        //declare members
        private long _maHopDong = 0;
        private string _soHopDong = string.Empty;
        private int _maBangBaoGia = 0;
        private decimal _tongTien = 0;
        private int _maLoaiHopDong = 0;
        private int _maLoaiTien = 1;
        private string _maHopDongQL = string.Empty;
        private string _tenHopDong = string.Empty;
        private long _maDoiTac = 0;
        private SmartDate _ngayLap = new SmartDate(DateTime.Today);
        private SmartDate _tuNgay = new SmartDate(DateTime.MinValue);
        private SmartDate _ngayHetHan = new SmartDate(DateTime.MinValue);
        private int _maNguoiLap = ERP_Library.Security.CurrentUser.Info.UserID;
        private byte _tinhTrang = 1;//Bat dau khoi chay Hop Dong
        private byte[] _flieDinhKem = new byte[0];
        private long _nguoiLienLac = 0;
        private long _maNguoiKy = 0;
        private SmartDate _ngayKy = new SmartDate(DateTime.Today);
        private string _ghiChu = string.Empty;
        private decimal _soTienDatCoc = 0;
        private decimal _phiGiaoDich = 0;
        private double _laiSuat = 0;
        private byte _daThanhToan = 0;
        private double _phanTramKyQuy = 0;
        private string _vietBangChu = string.Empty;
        private string _tenDoiTac = string.Empty;
        private string _maQLDoiTac = string.Empty;
        private string _cmnd = string.Empty;
        private string _tinhTrangString = string.Empty;
        private bool _muaBan = false;
        private bool _hdTrongNgoaiDai = false;
        private double _thueSuat = 0;
        private decimal _thueVAT = 0;
        private bool _check = false;//M
        private string _tenNguoiLienLac = string.Empty;
        private string _tenNguoiKy = string.Empty;
        private SmartDate _ngayApDungLai = new SmartDate(DateTime.MinValue);// = DateTime.Today.Date;
        private int _soNgay = 1;
        private bool _loaiNgay = false;//tính số ngày tù ngày, đến ngày bình thường 
        private string _soThamDinh = string.Empty;
        private SmartDate _ngayThamDinh = new SmartDate(DateTime.MinValue);
        private int _maBoPhanChuQuan = 0;
        private string _donViChuQuan = string.Empty;
        //
        private decimal _thueTNGiuLai = 0;
        private int _maDuAn = 0;
        private decimal _quyCMTL = 0;
        private SmartDate _ngayNhapQuyCMTL = new SmartDate(DateTime.MinValue);
        private int _maPhanLoaiHD = 0;
        private long _maHopDongChinh = 0;
        private bool _laPhuLuc = false;
        private byte _thuChi = 1;
        private byte _loaiChuongTrinhHD = 1;//khong la chuongtrinh xa hoi hoa
        private double _tiGiaQuyDoi = 1;
        private int _maChuongTrinh = 0;
        private int _maKeHoach = 0;
        private string _daLapHopDongString = string.Empty;
        private decimal _giaTriQuyetToan = 0;
        private string _soKeToanTheoDoi = string.Empty;
        //declare child member(s)


        private CT_HopDongThuChiList _CT_HopDongDichVuList = CT_HopDongThuChiList.NewCT_HopDongDichVuList();
        private ChiTietThanhToanHopDongThuChiList _chiTietThanhToanList = ChiTietThanhToanHopDongThuChiList.NewChiTietThanhToanList();
        //
        private ChiTietThanhToanThucTeList _chiTietThanhToanThucTeList = ChiTietThanhToanThucTeList.NewChiTietThanhToanThucTeList();
        private ChiTietThuLaoHopDongList _chiTietThuLaoHopDongList = ChiTietThuLaoHopDongList.NewChiTietThuLaoHopDongList();

        [System.ComponentModel.DataObjectField(true, true)]
        public long MaHopDong
        {
            get
            {
                CanReadProperty("MaHopDong", true);
                return _maHopDong;
            }

        }

        public string SoHopDong
        {
            get
            {
                CanReadProperty("SoHopDong", true);
                return _soHopDong;
            }
            set
            {
                CanWriteProperty("SoHopDong", true);
                if (value == null) value = string.Empty;
                if (!_soHopDong.Equals(value))
                {
                    _soHopDong = value;
                    PropertyHasChanged("SoHopDong");
                }
            }
        }

        public string TenDoiTac
        {
            get
            {
                CanReadProperty("TenDoiTac", true);
                return _tenDoiTac;
            }
            set
            {
                CanWriteProperty("TenDoiTac", true);
                if (value == null) value = string.Empty;
                if (!_tenDoiTac.Equals(value))
                {
                    _tenDoiTac = value;
                    PropertyHasChanged("TenDoiTac");
                }
            }
        }

        public string MaQLDoiTac
        {
            get
            {
                CanReadProperty("MaQLDoiTac", true);
                return _maQLDoiTac;
            }
            set
            {
                CanWriteProperty("MaQLDoiTac", true);
                if (value == null) value = string.Empty;
                if (!_maQLDoiTac.Equals(value))
                {
                    _maQLDoiTac = value;
                    PropertyHasChanged("MaQLDoiTac");
                }
            }
        }

        public string CMND
        {
            get
            {
                CanReadProperty("CMND", true);
                return _cmnd;
            }

        }

        public int MaBangBaoGia
        {
            get
            {
                CanReadProperty("MaBangBaoGia", true);
                return _maBangBaoGia;
            }
            set
            {
                CanWriteProperty("MaBangBaoGia", true);
                if (!_maBangBaoGia.Equals(value))
                {
                    _maBangBaoGia = value;
                    PropertyHasChanged("MaBangBaoGia");
                }
            }
        }

        public decimal TongTien
        {
            get
            {
                CanReadProperty("TongTien", true);
                return _tongTien;
            }
            set
            {
                CanWriteProperty("TongTien", true);
                if (!_tongTien.Equals(value))
                {
                    _tongTien = value;
                    _thueVAT = _tongTien * (decimal)_thueSuat / 100;
                    _soTienDatCoc = _tongTien * (decimal)_phanTramKyQuy / 100;
                    _vietBangChu = HamDungChung.DocTien(_tongTien);
                    PropertyHasChanged("TongTien");
                }
            }
        }

        public int MaLoaiHopDong
        {
            get
            {
                CanReadProperty("MaLoaiHopDong", true);
                return _maLoaiHopDong;
            }
            set
            {
                CanWriteProperty("MaLoaiHopDong", true);
                if (!_maLoaiHopDong.Equals(value))
                {
                    _maLoaiHopDong = value;
                    PropertyHasChanged("MaLoaiHopDong");
                }
            }
        }

        public int MaLoaiTien
        {
            get
            {
                CanReadProperty("MaLoaiTien", true);
                return _maLoaiTien;
            }
            set
            {
                CanWriteProperty("MaLoaiTien", true);
                if (!_maLoaiTien.Equals(value))
                {
                    _maLoaiTien = value;
                    PropertyHasChanged("MaLoaiTien");
                }
            }
        }

        public string MaHopDongQL
        {
            get
            {
                CanReadProperty("MaHopDongQL", true);
                return _maHopDongQL;
            }
            set
            {
                CanWriteProperty("MaHopDongQL", true);
                if (value == null) value = string.Empty;
                if (!_maHopDongQL.Equals(value))
                {
                    _maHopDongQL = value;
                    PropertyHasChanged("MaHopDongQL");
                }
            }
        }

        public string TenHopDong
        {
            get
            {
                CanReadProperty("TenHopDong", true);
                return _tenHopDong;
            }
            set
            {
                CanWriteProperty("TenHopDong", true);
                if (value == null) value = string.Empty;
                if (!_tenHopDong.Equals(value))
                {
                    _tenHopDong = value;
                    PropertyHasChanged("TenHopDong");
                }
            }
        }

        public long MaDoiTac
        {
            get
            {
                CanReadProperty("MaDoiTac", true);
                return _maDoiTac;
            }
            set
            {
                CanWriteProperty("MaDoiTac", true);
                if (!_maDoiTac.Equals(value))
                {
                    _maDoiTac = value;
                    PropertyHasChanged("MaDoiTac");
                }
            }
        }

        public DateTime NgayLap
        {
            get
            {
                CanReadProperty(true);
                return _ngayLap.Date;
            }
            set
            {
                CanWriteProperty(true);
                if (!_ngayLap.Equals(value))
                {
                    _ngayLap = new SmartDate(value);
                    PropertyHasChanged();
                }
            }
        }

        public DateTime? TuNgay
        {
            get
            {
                CanReadProperty(true);
                if (_tuNgay.Date == DateTime.MinValue)
                    return null;
                return _tuNgay.Date;
            }
            set
            {
                CanWriteProperty(true);
                if (!_tuNgay.Equals(value))
                {
                    if (value == null)
                        _tuNgay = new SmartDate(DateTime.MinValue);
                    else
                        _tuNgay = new SmartDate(value.Value.Date);
                    if (_soNgay > 0 && _tuNgay != new SmartDate(DateTime.MinValue))
                    {
                        _ngayHetHan = new SmartDate(TinhDenNgay(_tuNgay.Date, (_soNgay - 1), _loaiNgay));
                    }
                    PropertyHasChanged();
                }
            }
        }

        public string TuNgayString
        {
            get
            {
                CanReadProperty("TuNgayString", true);
                return string.Format("{0:dd/MM/yyyy}", _tuNgay.Text);
            }
            set
            {
                CanWriteProperty("TuNgayString", true);
                if (value == null) value = string.Empty;
                if (!_tuNgay.Equals(value))
                {
                    _tuNgay.Text = string.Format("{0:dd/MM/yyyy}", value);
                    PropertyHasChanged("TuNgayString");
                }
            }
        }

        public DateTime? NgayHetHan
        {
            get
            {
                CanReadProperty(true);
                if (_ngayHetHan.Date == DateTime.MinValue)
                    return null;
                return _ngayHetHan.Date;
            }
            set
            {
                CanWriteProperty(true);
                if (!_ngayHetHan.Equals(value))
                {
                    if (value == null)
                        _ngayHetHan = new SmartDate(DateTime.MinValue);
                    else
                        _ngayHetHan = new SmartDate(value.Value.Date);
                    PropertyHasChanged();
                }
            }
        }

        public string NgayHetHanString
        {
            get
            {
                CanReadProperty("NgayHetHanString", true);
                return string.Format("{0:dd/MM/yyyy}", _ngayHetHan.Text);
            }
            set
            {
                CanWriteProperty("NgayHetHanString", true);
                if (value == null) value = string.Empty;
                if (!_ngayHetHan.Equals(value))
                {
                    _ngayHetHan.Text = string.Format("{0:dd/MM/yyyy}", value);
                    PropertyHasChanged("NgayHetHanString");
                }
            }
        }

        public int MaNguoiLap
        {
            get
            {
                CanReadProperty("MaNguoiLap", true);
                return _maNguoiLap;
            }
            set
            {
                CanWriteProperty("MaNguoiLap", true);
                if (!_maNguoiLap.Equals(value))
                {
                    _maNguoiLap = value;
                    PropertyHasChanged("MaNguoiLap");
                }
            }
        }

        public byte TinhTrang
        {
            get
            {
                CanReadProperty("TinhTrang", true);
                return _tinhTrang;
            }
            set
            {
                CanWriteProperty("TinhTrang", true);
                if (!_tinhTrang.Equals(value))
                {
                    _tinhTrang = value;
                    PropertyHasChanged("TinhTrang");
                }
            }
        }

        public byte[] FileDinhKem
        {
            get
            {
                CanReadProperty("FileDinhKem", true);
                return _flieDinhKem;
            }
            set
            {
                CanWriteProperty("FileDinhKem", true);
                if (!_flieDinhKem.Equals(value))
                {
                    _flieDinhKem = value;
                    PropertyHasChanged("FileDinhKem");
                }
            }
        }

        public long NguoiLienLac
        {
            get
            {
                CanReadProperty("TenHopDong", true);
                return _nguoiLienLac;
            }
            set
            {
                CanWriteProperty("TenHopDong", true);
                if (value == null) value = 0;
                if (!_nguoiLienLac.Equals(value))
                {
                    _nguoiLienLac = value;
                    PropertyHasChanged("TenHopDong");
                }
            }
        }

        public long MaNguoiKy
        {
            get
            {
                CanReadProperty("MaNguoiKy", true);
                return _maNguoiKy;
            }
            set
            {
                CanWriteProperty("MaNguoiKy", true);
                if (!_maNguoiKy.Equals(value))
                {
                    _maNguoiKy = value;
                    _tenNguoiKy = TenNV.GetTenNhanVien(_maNguoiKy).TenNhanVien;
                    PropertyHasChanged("MaNguoiKy");
                }
            }
        }

        public DateTime? NgayKy
        {
            get
            {
                CanReadProperty("NgayKy", true);
                if (_ngayKy.Date == DateTime.MinValue)
                    return null;
                return _ngayKy.Date;
            }
            set
            {
                CanWriteProperty(true);
                if (!_ngayKy.Equals(value))
                {
                    if (value == null)
                        _ngayKy = new SmartDate(DateTime.MinValue);
                    else
                        _ngayKy = new SmartDate(value.Value.Date);
                    PropertyHasChanged();
                }
            }
        }

        public string GhiChu
        {
            get
            {
                CanReadProperty("GhiChu", true);
                return _ghiChu;
            }
            set
            {
                CanWriteProperty("GhiChu", true);
                if (value == null) value = string.Empty;
                if (!_ghiChu.Equals(value))
                {
                    _ghiChu = value;
                    PropertyHasChanged("GhiChu");
                }
            }
        }

        public double PhanTramKyQuy
        {
            get
            {
                CanReadProperty("PhanTramKyQuy", true);
                return _phanTramKyQuy;
            }
            set
            {
                CanWriteProperty("PhanTramKyQuy", true);
                if (!_phanTramKyQuy.Equals(value))
                {
                    _phanTramKyQuy = value;
                    _soTienDatCoc = _tongTien * (decimal)_phanTramKyQuy / 100;
                    PropertyHasChanged("PhanTramKyQuy");
                }
            }
        }

        public decimal SoTienDatCoc
        {
            get
            {
                CanReadProperty("SoTienDatCoc", true);
                return _soTienDatCoc;
            }
            set
            {
                CanWriteProperty("SoTienDatCoc", true);
                if (!_soTienDatCoc.Equals(value))
                {
                    _soTienDatCoc = value;
                    PropertyHasChanged("SoTienDatCoc");
                }
            }
        }

        public decimal PhiGiaoDich
        {
            get
            {
                CanReadProperty("PhiGiaoDich", true);
                return _phiGiaoDich;
            }
            set
            {
                CanWriteProperty("PhiGiaoDich", true);
                if (!_phiGiaoDich.Equals(value))
                {
                    _phiGiaoDich = value;
                    PropertyHasChanged("PhiGiaoDich");
                }
            }
        }

        public double LaiSuat
        {
            get
            {
                CanReadProperty("LaiSuat", true);
                return _laiSuat;
            }
            set
            {
                CanWriteProperty("LaiSuat", true);
                if (!_laiSuat.Equals(value))
                {
                    _laiSuat = value;
                    PropertyHasChanged("LaiSuat");
                }
            }
        }

        public string VietBangChu
        {
            get
            {
                CanReadProperty("VietBangChu", true);
                return _vietBangChu;
            }
            set
            {
                CanWriteProperty("VietBangChu", true);
                if (value == null) value = string.Empty;
                if (!_vietBangChu.Equals(value))
                {
                    _vietBangChu = value;
                    PropertyHasChanged("VietBangChu");
                }
            }
        }

        public byte DaThanhToan
        {
            get
            {
                CanReadProperty("DaThanhToan", true);
                return _daThanhToan;
            }
            set
            {
                CanWriteProperty("DaThanhToan", true);
                if (!_daThanhToan.Equals(value))
                {
                    _daThanhToan = value;
                    PropertyHasChanged("DaThanhToan");
                }
            }
        }

        public bool MuaBan
        {
            get
            {
                CanReadProperty("MuaBan", true);
                return _muaBan;
            }
            set
            {
                CanWriteProperty("MuaBan", true);
                if (!_muaBan.Equals(value))
                {
                    _muaBan = value;
                    PropertyHasChanged("MuaBan");
                }
            }
        }

        public bool HDTrongNgoaiDai
        {
            get
            {
                CanReadProperty("HDTrongNgoaiDai", true);
                return _hdTrongNgoaiDai;
            }
            set
            {
                CanWriteProperty("HDTrongNgoaiDai", true);
                if (!_hdTrongNgoaiDai.Equals(value))
                {
                    _hdTrongNgoaiDai = value;
                    if (_hdTrongNgoaiDai == true)
                    {
                        _thuChi = 2;
                    }
                    else
                    {
                        _thuChi = 1;
                    }
                    PropertyHasChanged("HDTrongNgoaiDai");

                }
            }
        }

        public string TinhTrangString
        {
            get
            {
                CanReadProperty("TinhTrangString", true);
                if (_tinhTrang == 0)
                    _tinhTrangString = "Chưa thực hiện";
                else if (_tinhTrang == 1)
                    _tinhTrangString = "Đang thực hiện";
                else if (_tinhTrang == 2)
                    _tinhTrangString = "Đã giao xong hàng";
                else if (_tinhTrang == 3)
                    _tinhTrangString = "Đã hoàn tất";
                else _tinhTrangString = "Đã bị hủy";
                return _tinhTrangString;
            }

        }

        public double ThueSuat
        {
            get
            {
                CanReadProperty("ThueSuat", true);
                return _thueSuat;
            }
            set
            {
                CanWriteProperty("ThueSuat", true);
                if (!_thueSuat.Equals(value))
                {
                    _thueSuat = value;
                    _thueVAT = _tongTien * (decimal)_thueSuat / 100;
                    PropertyHasChanged("ThueSuat");
                }
            }
        }

        public decimal ThueVAT
        {
            get
            {
                CanReadProperty("ThueVAT", true);
                return _thueVAT;
            }
            set
            {
                CanWriteProperty("ThueVAT", true);
                if (!_thueVAT.Equals(value))
                {
                    _thueVAT = value;
                    PropertyHasChanged("ThueVAT");
                }
            }

        }
        public bool Check//M
        {
            get
            {
                CanReadProperty("Check", true);
                return _check;
            }
            set
            {
                CanWriteProperty("Check", true);
                if (!_check.Equals(value))
                {
                    _check = value;
                    PropertyHasChanged("Check");
                }
            }
        }//END M


        public string TenNguoiKy
        {
            get
            {
                CanReadProperty("TenNguoiKy", true);
                return _tenNguoiKy;
            }
            set
            {
                CanWriteProperty("TenNguoiKy", true);
                if (value == null) value = string.Empty;
                if (!_tenNguoiKy.Equals(value))
                {
                    _tenNguoiKy = value;
                    PropertyHasChanged("TenNguoiKy");
                }
            }
        }

        public string TenNguoiLienLac
        {
            get
            {
                CanReadProperty("TenNguoiLienLac", true);
                return _tenNguoiLienLac;
            }
            set
            {
                CanWriteProperty("TenNguoiLienLac", true);
                if (value == null) value = string.Empty;
                if (!_tenNguoiLienLac.Equals(value))
                {
                    _tenNguoiLienLac = value;
                    PropertyHasChanged("TenNguoiLienLac");
                }
            }
        }

        public DateTime? NgayApDungLai
        {
            get
            {
                CanReadProperty("NgayApDungLai", true);
                if (_ngayApDungLai.Date == DateTime.MinValue)
                    return null;
                return _ngayApDungLai.Date;
            }
            set
            {
                CanWriteProperty(true);
                if (!_ngayApDungLai.Equals(value))
                {
                    if (value == null)
                        _ngayApDungLai = new SmartDate(DateTime.MinValue);
                    else
                        _ngayApDungLai = new SmartDate(value.Value.Date);
                    PropertyHasChanged();
                }
            }

        }

        public string NgayApDungLaiString
        {
            get
            {
                CanReadProperty("NgayApDungLaiString", true);
                return string.Format("{0:dd/MM/yyyy}", _ngayApDungLai.Text);
            }
            set
            {
                CanWriteProperty("NgayApDungLaiString", true);
                if (value == null) value = string.Empty;
                if (!_ngayApDungLai.Equals(value))
                {
                    _ngayApDungLai.Text = string.Format("{0:dd/MM/yyyy}", value);
                    PropertyHasChanged("NgayApDungLaiString");
                }
            }
        }



        public int SoNgay
        {
            get
            {
                CanReadProperty("SoNgay", true);
                return _soNgay;
            }
            set
            {
                CanWriteProperty("SoNgay", true);
                if (!_soNgay.Equals(value))
                {
                    _soNgay = value;
                    if (_soNgay > 0 && _tuNgay != new SmartDate(DateTime.MinValue))
                    {
                        _ngayHetHan = new SmartDate(TinhDenNgay(_tuNgay.Date, (_soNgay - 1), _loaiNgay));
                    }
                    PropertyHasChanged("SoNgay");
                }
            }
        }

        public bool LoaiNgay
        {
            get
            {
                CanReadProperty("LoaiNgay", true);
                return _loaiNgay;

            }
            set
            {
                CanWriteProperty("LoaiNgay", true);
                if (!_loaiNgay.Equals(value))
                {
                    _loaiNgay = value;
                    if (_soNgay > 0 && _tuNgay != new SmartDate(DateTime.MinValue))
                    {
                        _ngayHetHan = new SmartDate(TinhDenNgay(_tuNgay.Date, (_soNgay - 1), _loaiNgay));
                    }
                    PropertyHasChanged("LoaiNgay");
                }
            }
        }

        public string SoThamDinh
        {
            get
            {
                CanReadProperty("SoThamDinh", true);
                return _soThamDinh;
            }
            set
            {
                CanWriteProperty("SoThamDinh", true);
                if (value == null) value = string.Empty;
                if (!_soThamDinh.Equals(value))
                {
                    _soThamDinh = value;
                    PropertyHasChanged("SoThamDinh");
                }
            }
        }

        public DateTime? NgayThamDinh
        {
            get
            {
                CanReadProperty("NgayThamDinh", true);
                if (_ngayThamDinh.Date == DateTime.MinValue)
                    return null;
                return _ngayThamDinh.Date;
            }
            set
            {
                CanWriteProperty("NgayThamDinh", true);
                if (!_ngayThamDinh.Equals(value))
                {
                    if (value == null)
                        _ngayThamDinh = new SmartDate(DateTime.MinValue);
                    else
                        _ngayThamDinh = new SmartDate(value.Value.Date);

                    PropertyHasChanged();
                }
            }

        }

        public string NgayThamDinhString
        {
            get
            {
                CanReadProperty("NgayThamDinhString", true);
                return string.Format("{0:dd/MM/yyyy}", _ngayThamDinh.Text);
            }
            set
            {
                CanWriteProperty("NgayThamDinhString", true);
                if (value == null) value = string.Empty;
                if (!_ngayThamDinh.Equals(value))
                {
                    _ngayThamDinh.Text = string.Format("{0:dd/MM/yyyy}", value);
                    PropertyHasChanged("NgayThamDinhString");
                }
            }
        }

        public int MaBoPhanChuQuan
        {
            get
            {
                CanReadProperty("MaBoPhanChuQuan", true);
                return _maBoPhanChuQuan;
            }
            set
            {
                CanWriteProperty("MaBoPhanChuQuan", true);
                if (!_maBoPhanChuQuan.Equals(value))
                {
                    _maBoPhanChuQuan = value;
                    _donViChuQuan = BoPhan.GetBoPhan(_maBoPhanChuQuan).TenBoPhan;
                    PropertyHasChanged("MaBoPhanChuQuan");
                }
            }
        }

        public string DonViChuQuan
        {
            get
            {
                CanReadProperty("DonViChuQuan", true);
                return _donViChuQuan;
            }
            set
            {
                CanWriteProperty("DonViChuQuan", true);
                if (value == null) value = string.Empty;
                if (!_donViChuQuan.Equals(value))
                {
                    _donViChuQuan = value;
                    PropertyHasChanged("DonViChuQuan");
                }
            }
        }

        public decimal ThueTNGiuLai
        {
            get
            {
                CanReadProperty("ThueTNGiuLai", true);
                return _thueTNGiuLai;
            }
            set
            {
                CanWriteProperty("ThueTNGiuLai", true);
                if (!_thueTNGiuLai.Equals(value))
                {
                    _thueTNGiuLai = value;
                    PropertyHasChanged("ThueTNGiuLai");
                }
            }
        }


        public int MaDuAn
        {
            get
            {
                CanReadProperty("MaDuAn", true);
                return _maDuAn;
            }
            set
            {
                CanWriteProperty("MaDuAn", true);
                if (!_maDuAn.Equals(value))
                {
                    _maDuAn = value;
                    PropertyHasChanged("MaDuAn");
                }
            }
        }

        public decimal QuyCMTL
        {
            get
            {
                CanReadProperty("QuyCMTL", true);
                return _quyCMTL;
            }
            set
            {
                CanWriteProperty("QuyCMTL", true);
                if (!_quyCMTL.Equals(value))
                {
                    _quyCMTL = value;
                    PropertyHasChanged("QuyCMTL");
                }
            }
        }

        public DateTime? NgayNhapQuyCMTL
        {
            get
            {
                CanReadProperty("NgayNhapQuyCMTL", true);
                if (_ngayNhapQuyCMTL.Date == DateTime.MinValue)
                    return null;
                return _ngayNhapQuyCMTL.Date;
            }
            set
            {
                CanWriteProperty("NgayNhapQuyCMTL", true);
                if (!_ngayNhapQuyCMTL.Equals(value))
                {
                    if (value == null)
                        _ngayNhapQuyCMTL = new SmartDate(DateTime.MinValue);
                    else
                        _ngayNhapQuyCMTL = new SmartDate(value.Value.Date);

                    PropertyHasChanged();
                }
            }

        }

        public int MaPhanLoaiHD
        {
            get
            {
                CanReadProperty("MaPhanLoaiHD", true);
                return _maPhanLoaiHD;
            }
            set
            {
                CanWriteProperty("MaPhanLoaiHD", true);
                if (!_maPhanLoaiHD.Equals(value))
                {
                    _maPhanLoaiHD = value;
                    PropertyHasChanged("MaPhanLoaiHD");
                }
            }
        }

        public long MaHopDongChinh
        {
            get
            {
                CanReadProperty("MaHopDongChinh", true);
                return _maHopDongChinh;
            }
            set
            {
                CanWriteProperty("MaHopDongChinh", true);
                if (!_maHopDongChinh.Equals(value))
                {
                    _maHopDongChinh = value;
                    PropertyHasChanged("MaHopDongChinh");
                }
            }
        }

        public bool LaPhuLuc
        {
            get
            {
                CanReadProperty("LaPhuLuc", true);
                return _laPhuLuc;
            }
            set
            {
                CanWriteProperty("LaPhuLuc", true);
                if (!_laPhuLuc.Equals(value))
                {
                    _laPhuLuc = value;
                    PropertyHasChanged("LaPhuLuc");
                }
            }
        }

        public byte ThuChi
        {
            get
            {
                CanReadProperty("ThuChi", true);
                return _thuChi;
            }
            set
            {
                CanWriteProperty("ThuChi", true);
                if (!_thuChi.Equals(value))
                {
                    _thuChi = value;
                    PropertyHasChanged("ThuChi");
                }
            }
        }
        public byte LoaiChuongTrinhHD
        {
            get
            {
                CanReadProperty("LoaiChuongTrinhHD", true);
                return _loaiChuongTrinhHD;
            }
            set
            {
                CanWriteProperty("LoaiChuongTrinhHD", true);
                if (!_loaiChuongTrinhHD.Equals(value))
                {
                    _loaiChuongTrinhHD = value;
                    PropertyHasChanged("LoaiChuongTrinhHD");
                }
            }
        }

        public double TiGiaQuyDoi
        {
            get
            {
                CanReadProperty("TiGiaQuyDoi", true);
                return _tiGiaQuyDoi;
            }
            set
            {
                CanWriteProperty("TiGiaQuyDoi", true);
                if (!_tiGiaQuyDoi.Equals(value))
                {
                    _tiGiaQuyDoi = value;
                    PropertyHasChanged("TiGiaQuyDoi");
                }
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

        public int MaKeHoach
        {
            get
            {
                CanReadProperty("MaKeHoach", true);
                return _maKeHoach;
            }
            set
            {
                CanWriteProperty("MaKeHoach", true);
                if (!_maKeHoach.Equals(value))
                {
                    _maKeHoach = value;
                    PropertyHasChanged("MaKeHoach");
                }
            }
        }

        public string DaLapHopDongString
        {
            get
            {
                CanReadProperty("DaLapHopDongString", true);
                if (_maLoaiHopDong == 0)
                    _daLapHopDongString = "Chưa lập Hợp Đồng";
                else
                    _daLapHopDongString = "Đã lập Hợp Đồng";
                return _daLapHopDongString;
            }
        }

        public decimal GiaTriQuyetToan
        {
            get
            {
                CanReadProperty("GiaTriQuyetToan", true);
                return _giaTriQuyetToan;
            }
            set
            {
                CanWriteProperty("GiaTriQuyetToan", true);
                if (!_giaTriQuyetToan.Equals(value))
                {
                    _giaTriQuyetToan = value;
                    PropertyHasChanged("GiaTriQuyetToan");
                }
            }
        }

        public string SoKeToanTheoDoi
        {
            get
            {
                CanReadProperty("SoKeToanTheoDoi", true);
                return _soKeToanTheoDoi;
            }
            set
            {
                CanWriteProperty("SoKeToanTheoDoi", true);
                if (!_soKeToanTheoDoi.Equals(value))
                {
                    _soKeToanTheoDoi = value;
                    PropertyHasChanged("SoKeToanTheoDoi");
                }
            }
        }

        public CT_HopDongThuChiList CT_HopDongDichVu
        {
            get
            {
                CanReadProperty("CT_HopDongDichVu", true);
                return _CT_HopDongDichVuList;
            }
            set
            {

                CanWriteProperty("CT_HopDongDichVu", true);
                if (!CT_HopDongDichVu.Equals(value))
                {
                    CT_HopDongDichVu = value;
                    PropertyHasChanged("CT_HopDongDichVu");
                }

            }
        }

        public ChiTietThanhToanHopDongThuChiList chiTietThanhToan
        {
            get
            {
                CanReadProperty("ChiTietThanhToan", true);
                return _chiTietThanhToanList;
            }
        }

        public ChiTietThanhToanThucTeList chiTietThanhToanThucTeList
        {
            get
            {
                CanReadProperty("ChiTietThanhToanThucTeList", true);
                return _chiTietThanhToanThucTeList;
            }
        }

        public ChiTietThuLaoHopDongList chiTietThuLaoHopDongList
        {
            get
            {
                CanReadProperty("ChiTietThuLaoHopDongList", true);
                return _chiTietThuLaoHopDongList;
            }
        }

        public override bool IsValid
        {
            get { return base.IsValid && _CT_HopDongDichVuList.IsValid && _chiTietThanhToanList.IsValid && _chiTietThanhToanThucTeList.IsValid && _chiTietThuLaoHopDongList.IsValid; }
        }

        public override bool IsDirty
        {
            get { return base.IsDirty || _CT_HopDongDichVuList.IsDirty || _chiTietThanhToanList.IsDirty || _chiTietThanhToanThucTeList.IsDirty || _chiTietThuLaoHopDongList.IsDirty; }
        }

        protected override object GetIdValue()
        {
            return _maHopDong;
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
            // SoHopDong
            //
            //ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("SoHopDong", 20));
            // ValidationRules.AddRule(CommonRules.StringRequired, "MaHopDongQL");
            // ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("MaHopDongQL", 20));
            //
            // TenHopDong
            //
            // ValidationRules.AddRule(CommonRules.StringRequired, "TenHopDong");
            // ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("TenHopDong", 500));
            //
            // NgayLap
            //

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
            //TODO: Define authorization rules in HopDongMuaBan
            //AuthorizationRules.AllowRead("DotGiaoHangHDMB", "HopDongMuaBanReadGroup");
            //AuthorizationRules.AllowRead("DotThanhToanHDMB", "HopDongMuaBanReadGroup");
            //AuthorizationRules.AllowRead("CT_HopDongMuaBan", "HopDongMuaBanReadGroup");
            //AuthorizationRules.AllowRead("MaHopDong", "HopDongMuaBanReadGroup");
            //AuthorizationRules.AllowRead("SoHopDong", "HopDongMuaBanReadGroup");
            //AuthorizationRules.AllowRead("MaBangBaoGia", "HopDongMuaBanReadGroup");
            //AuthorizationRules.AllowRead("TongTien", "HopDongMuaBanReadGroup");
            //AuthorizationRules.AllowRead("Loai", "HopDongMuaBanReadGroup");

            //AuthorizationRules.AllowWrite("SoHopDong", "HopDongMuaBanWriteGroup");
            //AuthorizationRules.AllowWrite("MaBangBaoGia", "HopDongMuaBanWriteGroup");
            //AuthorizationRules.AllowWrite("TongTien", "HopDongMuaBanWriteGroup");
            //AuthorizationRules.AllowWrite("Loai", "HopDongMuaBanWriteGroup");
        }


        public static bool CanGetObject()
        {
            //TODO: Define CanGetObject permission in HopDongMuaBan
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("HopDongMuaBanViewGroup"))
            //	return true;
            //return false;
        }

        public static bool CanAddObject()
        {
            //TODO: Define CanAddObject permission in HopDongMuaBan
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("HopDongMuaBanAddGroup"))
            //	return true;
            //return false;
        }

        public static bool CanEditObject()
        {
            //TODO: Define CanEditObject permission in HopDongMuaBan
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("HopDongMuaBanEditGroup"))
            //	return true;
            //return false;
        }

        public static bool CanDeleteObject()
        {
            //TODO: Define CanDeleteObject permission in HopDongMuaBan
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("HopDongMuaBanDeleteGroup"))
            //	return true;
            //return false;
        }
        #endregion //Authorization Rules

        #region Factory Methods
        private HopDongThuChi()
        {
            /* require use of factory method */
            //MarkAsChild();
        }

        private HopDongThuChi(long MaHopDong, string tenHopDong)
        {
            _maHopDong = MaHopDong;
            _soHopDong = tenHopDong;
            _tenHopDong = tenHopDong;
        }

        public static HopDongThuChi NewHopDongMuaBan(long MaHopDong, string tenHopDong)
        {
            return new HopDongThuChi(MaHopDong, tenHopDong);
        }

        public static HopDongThuChi NewPhuLucHopDongMuaBan(HopDongThuChi hopDong)//taoPhuLuctuHopDong
        {
            HopDongThuChi hopDongThuChi = new HopDongThuChi();

            hopDongThuChi.TongTien = hopDong.TongTien;
            hopDongThuChi.MaLoaiHopDong = hopDong.MaLoaiHopDong;
            hopDongThuChi.MaLoaiTien = hopDong.MaLoaiTien;
            hopDongThuChi.TiGiaQuyDoi = hopDong.TiGiaQuyDoi;
            hopDongThuChi.TenHopDong = hopDong.TenHopDong;
            hopDongThuChi.MaDoiTac = hopDong.MaDoiTac;
            hopDongThuChi.TuNgay = hopDong.TuNgay;
            hopDongThuChi.NgayHetHan = hopDong.NgayHetHan;
            hopDongThuChi.TinhTrang = hopDong.TinhTrang;
            hopDongThuChi.NguoiLienLac = hopDong.NguoiLienLac;
            hopDongThuChi.MaNguoiKy = hopDong.MaNguoiKy;
            hopDongThuChi.NgayKy = hopDong.NgayKy;
            hopDongThuChi.GhiChu = hopDong.GhiChu;
            hopDongThuChi.SoTienDatCoc = hopDong.SoTienDatCoc;
            hopDongThuChi.PhiGiaoDich = hopDong.PhiGiaoDich;
            hopDongThuChi.LaiSuat = hopDong.LaiSuat;
            hopDongThuChi.DaThanhToan = hopDong.DaThanhToan;
            hopDongThuChi.PhanTramKyQuy = hopDong.PhanTramKyQuy;
            hopDongThuChi.MuaBan = hopDong.MuaBan;
            hopDongThuChi.HDTrongNgoaiDai = hopDong.HDTrongNgoaiDai;
            hopDongThuChi.ThueSuat = hopDong.ThueSuat;
            hopDongThuChi.ThueVAT = hopDong.ThueVAT;
            hopDongThuChi.TenNguoiLienLac = hopDong.TenNguoiLienLac;
            hopDongThuChi.NgayApDungLai = hopDong.NgayApDungLai;// = DateTime.Today.Date;
            hopDongThuChi.SoNgay = hopDong.SoNgay;
            hopDongThuChi.LoaiNgay = hopDong.LoaiNgay;//tính số ngày tù ngày, đến ngày bình thường 
            hopDongThuChi.SoThamDinh = hopDong.SoThamDinh;
            hopDongThuChi.NgayThamDinh = hopDong.NgayThamDinh;
            hopDongThuChi.MaBoPhanChuQuan = hopDong.MaBoPhanChuQuan;
            hopDongThuChi.MaChuongTrinh = hopDong.MaChuongTrinh;//
            //
            hopDongThuChi.ThueTNGiuLai = hopDong.ThueTNGiuLai;
            hopDongThuChi.MaDuAn = hopDong.MaDuAn;
            hopDongThuChi.QuyCMTL = hopDong.QuyCMTL;
            hopDongThuChi.NgayNhapQuyCMTL = hopDong.NgayNhapQuyCMTL;
            hopDongThuChi.MaPhanLoaiHD = hopDong.MaPhanLoaiHD;
            hopDongThuChi.MaKeHoach = hopDong.MaKeHoach;
            //
            if (hopDong.LaPhuLuc)
                hopDongThuChi.MaHopDongChinh = hopDong.MaHopDongChinh;
            else
                hopDongThuChi.MaHopDongChinh = hopDong.MaHopDong;
            hopDongThuChi.LaPhuLuc = true;
            //
            hopDongThuChi.ThuChi = hopDong.ThuChi;
            hopDongThuChi.LoaiChuongTrinhHD = hopDong.LoaiChuongTrinhHD;//khong la chuongtrinh xa hoi hoa
            hopDongThuChi.GiaTriQuyetToan = hopDong.GiaTriQuyetToan;
            hopDongThuChi.SoKeToanTheoDoi = hopDong.SoKeToanTheoDoi;

            foreach (CT_HopDongThuChi ct in hopDong.CT_HopDongDichVu)
            {
                hopDongThuChi.CT_HopDongDichVu.Add(new CT_HopDongThuChi(ct));
            }
            foreach (ChiTietThanhToanHopDongThuChi ct in hopDong.chiTietThanhToan)
            {
                hopDongThuChi.chiTietThanhToan.Add(new ChiTietThanhToanHopDongThuChi(ct));
            }
            foreach (ChiTietThanhToanThucTe ct in hopDong.chiTietThanhToanThucTeList)
            {
                hopDongThuChi.chiTietThanhToanThucTeList.Add(new ChiTietThanhToanThucTe(ct));
            }
            foreach (ChiTietThuLaoHopDong ct in hopDong.chiTietThuLaoHopDongList)
            {
                hopDongThuChi.chiTietThuLaoHopDongList.Add(new ChiTietThuLaoHopDong(ct));
            }

            return hopDongThuChi;
        }

        public static HopDongThuChi NewHopDongMuaBan()
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a HopDongThuChi");
            return DataPortal.Create<HopDongThuChi>();
        }

        public static HopDongThuChi GetHopDongMuaBan(long maHopDong)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a HopDongThuChi");
            return DataPortal.Fetch<HopDongThuChi>(new Criteria(maHopDong));
        }

        public static HopDongThuChi GetHopDongMuaBanLast(long maHopDong)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a HopDongThuChi");
            return DataPortal.Fetch<HopDongThuChi>(new CriteriaGetHDLast(maHopDong));
        }

        public static HopDongThuChi GetHopDongMuaBanLastfromHopDong2014(long maHopDong)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a HopDongThuChi");
            return DataPortal.Fetch<HopDongThuChi>(new CriteriaGetHDLastfromHopDong2014(maHopDong));
        }

        public static HopDongThuChi GetHopDongMuaBanWithoutChild(long maHopDong)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a HopDongThuChi");
            return DataPortal.Fetch<HopDongThuChi>(new CriteriaGetWithoutChild(maHopDong));
        }

        public static HopDongThuChi UpdateHopDongFromHopDong(HopDongThuChi hopDongSour, HopDongThuChi hopDongDes)//taoPhuLuctuHopDong
        {
            HopDongThuChi hopDongThuChi = new HopDongThuChi();
            hopDongThuChi = hopDongDes;

            hopDongThuChi.TongTien = hopDongSour.TongTien;
            hopDongThuChi.MaLoaiHopDong = hopDongSour.MaLoaiHopDong;
            hopDongThuChi.MaLoaiTien = hopDongSour.MaLoaiTien;
            hopDongThuChi.TiGiaQuyDoi = hopDongSour.TiGiaQuyDoi;
            hopDongThuChi.TenHopDong = hopDongSour.TenHopDong;
            hopDongThuChi.MaDoiTac = hopDongSour.MaDoiTac;
            hopDongThuChi.TuNgay = hopDongSour.TuNgay;
            hopDongThuChi.NgayHetHan = hopDongSour.NgayHetHan;
            hopDongThuChi.TinhTrang = hopDongSour.TinhTrang;
            hopDongThuChi.NguoiLienLac = hopDongSour.NguoiLienLac;
            hopDongThuChi.MaNguoiKy = hopDongSour.MaNguoiKy;
            hopDongThuChi.NgayKy = hopDongSour.NgayKy;
            hopDongThuChi.GhiChu = hopDongSour.GhiChu;
            hopDongThuChi.SoTienDatCoc = hopDongSour.SoTienDatCoc;
            hopDongThuChi.PhiGiaoDich = hopDongSour.PhiGiaoDich;
            hopDongThuChi.LaiSuat = hopDongSour.LaiSuat;
            hopDongThuChi.DaThanhToan = hopDongSour.DaThanhToan;
            hopDongThuChi.PhanTramKyQuy = hopDongSour.PhanTramKyQuy;
            hopDongThuChi.MuaBan = hopDongSour.MuaBan;
            hopDongThuChi.HDTrongNgoaiDai = hopDongSour.HDTrongNgoaiDai;
            hopDongThuChi.ThueSuat = hopDongSour.ThueSuat;
            hopDongThuChi.ThueVAT = hopDongSour.ThueVAT;
            hopDongThuChi.TenNguoiLienLac = hopDongSour.TenNguoiLienLac;
            hopDongThuChi.NgayApDungLai = hopDongSour.NgayApDungLai;// = DateTime.Today.Date;
            hopDongThuChi.SoNgay = hopDongSour.SoNgay;
            hopDongThuChi.LoaiNgay = hopDongSour.LoaiNgay;//tính số ngày tù ngày, đến ngày bình thường 
            hopDongThuChi.SoThamDinh = hopDongSour.SoThamDinh;
            hopDongThuChi.NgayThamDinh = hopDongSour.NgayThamDinh;
            hopDongThuChi.MaBoPhanChuQuan = hopDongSour.MaBoPhanChuQuan;
            hopDongThuChi.MaChuongTrinh = hopDongSour.MaChuongTrinh;//
            //
            hopDongThuChi.ThueTNGiuLai = hopDongSour.ThueTNGiuLai;
            hopDongThuChi.MaDuAn = hopDongSour.MaDuAn;
            hopDongThuChi.QuyCMTL = hopDongSour.QuyCMTL;
            hopDongThuChi.NgayNhapQuyCMTL = hopDongSour.NgayNhapQuyCMTL;
            hopDongThuChi.MaPhanLoaiHD = hopDongSour.MaPhanLoaiHD;
            //
            hopDongThuChi.ThuChi = hopDongSour.ThuChi;
            hopDongThuChi.LoaiChuongTrinhHD = hopDongSour.LoaiChuongTrinhHD;//khong la chuongtrinh xa hoi hoa
            hopDongThuChi.GiaTriQuyetToan = hopDongSour.GiaTriQuyetToan;
            hopDongThuChi.SoKeToanTheoDoi = hopDongSour.SoKeToanTheoDoi;

            foreach (CT_HopDongThuChi ct in hopDongSour.CT_HopDongDichVu)
            {
                hopDongThuChi.CT_HopDongDichVu.Add(new CT_HopDongThuChi(ct));
            }
            foreach (ChiTietThanhToanHopDongThuChi ct in hopDongSour.chiTietThanhToan)
            {
                hopDongThuChi.chiTietThanhToan.Add(new ChiTietThanhToanHopDongThuChi(ct));
            }
            foreach (ChiTietThanhToanThucTe ct in hopDongSour.chiTietThanhToanThucTeList)
            {
                hopDongThuChi.chiTietThanhToanThucTeList.Add(new ChiTietThanhToanThucTe(ct));
            }
            foreach (ChiTietThuLaoHopDong ct in hopDongSour.chiTietThuLaoHopDongList)
            {
                hopDongThuChi.chiTietThuLaoHopDongList.Add(new ChiTietThuLaoHopDong(ct));
            }
            if (hopDongSour.MaLoaiHopDong != 0)
            {
                //tra hop dong ve tinh trang moi PS
                DeleteHopDongThuChiTuHopDongPS(hopDongSour.MaHopDong);
            }
            return hopDongThuChi;
        }

        public static void DeleteHopDongMuaBan(long maHopDong)
        {
            if (!CanDeleteObject())
                throw new System.Security.SecurityException("User not authorized to remove a HopDongThuChi");
            DataPortal.Delete(new Criteria(maHopDong));
        }

        public static void DeleteHopDongThuChi(long maHopDong)
        {//B
            HopDongThuChi hopDongThuChi = HopDongThuChi.GetHopDongMuaBan(maHopDong);
            SqlTransaction tr;
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                tr = cn.BeginTransaction();
                try
                {
                    hopDongThuChi.CT_HopDongDichVu.Clear();
                    hopDongThuChi.CT_HopDongDichVu.Update(tr, hopDongThuChi);
                    hopDongThuChi.chiTietThanhToan.Clear();
                    hopDongThuChi.chiTietThanhToan.Update(tr, hopDongThuChi);
                    hopDongThuChi.chiTietThanhToanThucTeList.Clear();
                    hopDongThuChi.chiTietThanhToanThucTeList.Update(tr, hopDongThuChi);
                    hopDongThuChi.chiTietThuLaoHopDongList.Clear();
                    hopDongThuChi.chiTietThuLaoHopDongList.Update(tr, hopDongThuChi);
                    using (SqlCommand cm = tr.Connection.CreateCommand())
                    {
                        cm.Transaction = tr;
                        cm.CommandType = CommandType.StoredProcedure;
                        cm.CommandText = "spd_DeletetblHopDongMuaBan";
                        cm.Parameters.AddWithValue("@MaHopDong", hopDongThuChi.MaHopDong);
                        cm.ExecuteNonQuery();
                    }//using
                    tr.Commit();
                }
                catch (SqlException ex)
                {
                    tr.Rollback();
                    throw ex;
                }
            }
        }

        public static void DeleteHopDongThuChiTuHopDongPS(long maHopDong)
        {//B
            HopDongThuChi hopDongThuChi = HopDongThuChi.GetHopDongMuaBan(maHopDong);
            SqlTransaction tr;
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                tr = cn.BeginTransaction();
                try
                {
                    hopDongThuChi.CT_HopDongDichVu.Clear();
                    hopDongThuChi.CT_HopDongDichVu.Update(tr, hopDongThuChi);
                    hopDongThuChi.chiTietThanhToan.Clear();
                    hopDongThuChi.chiTietThanhToan.Update(tr, hopDongThuChi);
                    hopDongThuChi.chiTietThanhToanThucTeList.Clear();
                    hopDongThuChi.chiTietThanhToanThucTeList.Update(tr, hopDongThuChi);
                    hopDongThuChi.chiTietThuLaoHopDongList.Clear();
                    hopDongThuChi.chiTietThuLaoHopDongList.Update(tr, hopDongThuChi);
                    using (SqlCommand cm = tr.Connection.CreateCommand())
                    {
                        cm.Transaction = tr;
                        cm.CommandType = CommandType.StoredProcedure;
                        cm.CommandText = "spd_DeletetblHopDongMuaBanTuHopDongPS";
                        cm.Parameters.AddWithValue("@MaHopDong", hopDongThuChi.MaHopDong);
                        cm.ExecuteNonQuery();
                    }//using
                    tr.Commit();
                }
                catch (SqlException ex)
                {
                    tr.Rollback();
                    throw ex;
                }
            }
        }

        public override HopDongThuChi Save()
        {
            if (IsDeleted && !CanDeleteObject())
                throw new System.Security.SecurityException("User not authorized to remove a HopDongMuaBan");
            else if (IsNew && !CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a HopDongMuaBan");
            else if (!CanEditObject())
                throw new System.Security.SecurityException("User not authorized to update a HopDongMuaBan");

            return base.Save();
        }


        public static bool KiemTraSoHopDongTonTai(string soHopDong, int loai, bool muaBan)
        {
            if (KiemTraSoHopDong(soHopDong, loai, muaBan) == 0)
                return true;
            return false;
        }

        public static bool KiemTraHopDongDaPhatSinhNghiemThuThanhly(long maHopDong)
        {
            bool _kq = false;
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "Spd_KiemTraHopDongDaPhatSinhNghiemThuThanhLy";
                    cm.Parameters.AddWithValue("@MaHopDong", maHopDong);
                    SqlParameter prmGiaTriTraVe = new SqlParameter("@GiaTriTraVe", SqlDbType.Bit, 16);
                    prmGiaTriTraVe.Direction = ParameterDirection.Output;
                    cm.Parameters.Add(prmGiaTriTraVe);
                    cm.ExecuteNonQuery();
                    _kq = (bool)prmGiaTriTraVe.Value;
                }
            }//us
            return _kq;
        }

        public static bool KiemTraHopDongDaThanhly(long maHopDong)
        {
            bool _kq = false;
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "Spd_KiemTraHopDongDaThanhLy";
                    cm.Parameters.AddWithValue("@MaHopDong", maHopDong);
                    SqlParameter prmGiaTriTraVe = new SqlParameter("@GiaTriTraVe", SqlDbType.Bit, 16);
                    prmGiaTriTraVe.Direction = ParameterDirection.Output;
                    cm.Parameters.Add(prmGiaTriTraVe);
                    cm.ExecuteNonQuery();
                    _kq = (bool)prmGiaTriTraVe.Value;
                }
            }//us
            return _kq;
        }

        public static bool KiemTraHopDongDaPhatSinhPhuLuc(long maHopDong)
        {
            bool _kq = false;
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "Spd_KiemTraHopDongDaPhatSinhPhuLuc";
                    cm.Parameters.AddWithValue("@MaHopDong", maHopDong);
                    SqlParameter prmGiaTriTraVe = new SqlParameter("@GiaTriTraVe", SqlDbType.Bit, 16);
                    prmGiaTriTraVe.Direction = ParameterDirection.Output;
                    cm.Parameters.Add(prmGiaTriTraVe);
                    cm.ExecuteNonQuery();
                    _kq = (bool)prmGiaTriTraVe.Value;
                }
            }//us
            return _kq;
        }

        public static bool KiemTraPhuLucDaPhatSinhPhuLucMoi(long maHopDong, long maHopDongChinh)
        {
            bool _kq = false;
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "Spd_KiemTraPhuLucDaPhatSinhPhuLucmoi";
                    cm.Parameters.AddWithValue("@MaHopDong", maHopDong);
                    cm.Parameters.AddWithValue("@MaHopDongChinh", maHopDongChinh);
                    SqlParameter prmGiaTriTraVe = new SqlParameter("@GiaTriTraVe", SqlDbType.Bit, 16);
                    prmGiaTriTraVe.Direction = ParameterDirection.Output;
                    cm.Parameters.Add(prmGiaTriTraVe);
                    cm.ExecuteNonQuery();
                    _kq = (bool)prmGiaTriTraVe.Value;
                }
            }//us
            return _kq;
        }

        public static bool KiemTraHopDongDaPhatSinhNhapXuat(long maHopDong)
        {
            bool _kq = false;
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "Spd_KiemTraHopDongDaPhatSinhNhapXuat";
                    cm.Parameters.AddWithValue("@MaHopDong", maHopDong);
                    SqlParameter prmGiaTriTraVe = new SqlParameter("@GiaTriTraVe", SqlDbType.Bit, 16);
                    prmGiaTriTraVe.Direction = ParameterDirection.Output;
                    cm.Parameters.Add(prmGiaTriTraVe);
                    cm.ExecuteNonQuery();
                    _kq = (bool)prmGiaTriTraVe.Value;
                }
            }//us
            return _kq;
        }


        #region Tinh Den Ngay

        private int TinhSoNgayNghi_TuNgayDenNgay(DateTime tuNgay, DateTime denNgay)
        {
            int soNgay = 0;

            TimeSpan diff = denNgay - tuNgay;
            int days = diff.Days;
            for (int i = 0; i <= days; i++)
            {
                DateTime testDate = tuNgay.AddDays(i);
                if (testDate.DayOfWeek == DayOfWeek.Saturday || testDate.DayOfWeek == DayOfWeek.Sunday || NgayHoliday.LaNgayLe(testDate.Date))
                {
                    soNgay += 1;
                }

            }
            return soNgay;
        }

        private int TinhSoNgayNghi_TuNgaySoNgay(DateTime tuNgay, int soNgay)
        {
            int soNgayNghi = 0;
            DateTime denNgayTemp = tuNgay.AddDays(soNgay);

            int soNgayTemp = TinhSoNgayNghi_TuNgayDenNgay(tuNgay, denNgayTemp);
            DateTime denNgay = tuNgay.AddDays(soNgayTemp + soNgay);
            soNgayNghi = TinhSoNgayNghi_TuNgayDenNgay(tuNgay, denNgay);
            return soNgayNghi;
        }

        private DateTime TinhDenNgay(DateTime tuNgay, int soNgay, bool coTruNgayLe)
        {
            if (coTruNgayLe)
            {
                return tuNgay.AddDays(TinhSoNgayNghi_TuNgaySoNgay(tuNgay, soNgay) + soNgay);
            }
            else
            {
                return tuNgay.AddDays(soNgay);
            }

        }
        #endregion


        #endregion //Factory Methods

        #region Child Factory Methods
        internal static HopDongThuChi NewHopDongMuaBanChild()
        {
            HopDongThuChi child = new HopDongThuChi();
            child.ValidationRules.CheckRules();
            child.MarkAsChild();
            return child;
        }

        internal static HopDongThuChi GetHopDongMuaBan(SafeDataReader dr)
        {
            HopDongThuChi child = new HopDongThuChi();
            child.MarkAsChild();
            child.Fetch(dr);
            return child;
        }
        internal static HopDongThuChi GetHopDongMuaBanWithoutChild(SafeDataReader dr)
        {
            HopDongThuChi child = new HopDongThuChi();
            child.MarkAsChild();
            child.FetchWithoutChild(dr);
            return child;
        }
        #endregion //Child Factory Methods

        #region Data Access

        #region Criteria

        [Serializable()]
        private class Criteria
        {
            public long MaHopDong;

            public Criteria(long maHopDong)
            {
                this.MaHopDong = maHopDong;
            }
        }
        private class CriteriaGetHDLast
        {
            public long MaHopDong;

            public CriteriaGetHDLast(long maHopDong)
            {
                this.MaHopDong = maHopDong;
            }
        }

        private class CriteriaGetWithoutChild
        {
            public long MaHopDong;

            public CriteriaGetWithoutChild(long maHopDong)
            {
                this.MaHopDong = maHopDong;
            }
        }

        private class CriteriaGetHDLastfromHopDong2014
        {
            public long MaHopDong;

            public CriteriaGetHDLastfromHopDong2014(long maHopDong)
            {
                this.MaHopDong = maHopDong;
            }
        }

        #endregion //Criteria

        #region Data Access - Create
        [RunLocal]
        protected override void DataPortal_Create()
        {
            //ValidationRules.CheckRules();
        }

        #endregion //Data Access - Create

        #region Data Access - Fetch
        private void DataPortal_Fetch(object criteria)
        {
            SqlTransaction tr;

            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();

                tr = cn.BeginTransaction();
                try
                {
                    ExecuteFetch(tr, criteria);

                    tr.Commit();
                }
                catch
                {
                    tr.Rollback();
                    throw;
                }
            }//using
        }

        private void ExecuteFetch(SqlTransaction tr, object criteria)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                if (criteria is Criteria || criteria is CriteriaGetHDLast || criteria is CriteriaGetHDLastfromHopDong2014)
                {
                    if (criteria is Criteria)
                    {
                        cm.CommandText = "spd_SelecttblHopDongMuaBan";
                        cm.Parameters.AddWithValue("@MaHopDong", ((Criteria)criteria).MaHopDong);
                    }
                    else if (criteria is CriteriaGetHDLast)
                    {
                        cm.CommandText = "spd_SelecttblHopDongMuaBanLast";
                        cm.Parameters.AddWithValue("@MaHopDong", ((CriteriaGetHDLast)criteria).MaHopDong);
                    }
                    else if (criteria is CriteriaGetHDLastfromHopDong2014)
                    {
                        cm.CommandText = "spd_SelecttblHopDongMuaBanLastfromHopDong2014";
                        cm.Parameters.AddWithValue("@MaHopDong", ((CriteriaGetHDLastfromHopDong2014)criteria).MaHopDong);
                    }

                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                        {
                            FetchObject(dr);
                            //ValidationRules.CheckRules();

                            //load child object(s)
                            FetchChildren(_maHopDong);
                        }
                    }
                }
                else if (criteria is CriteriaGetWithoutChild)
                {
                    cm.CommandText = "spd_SelecttblHopDongMuaBan";
                    cm.Parameters.AddWithValue("@MaHopDong", ((CriteriaGetWithoutChild)criteria).MaHopDong);
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                        {
                            FetchObject(dr);
                        }
                    }
                }
            }//using
        }

        #endregion //Data Access - Fetch

        #region Data Access - Insert
        protected override void DataPortal_Insert()
        {
            SqlTransaction tr;

            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();

                tr = cn.BeginTransaction();
                try
                {
                    ExecuteInsert(tr);

                    //update child object(s)
                    UpdateChildren(tr);

                    tr.Commit();
                }
                catch (SqlException ex)
                {
                    tr.Rollback();
                    HamDungChung.ThongBaoLoi(ex);
                }
            }//using

        }

        #endregion //Data Access - Insert

        #region Data Access - Update
        protected override void DataPortal_Update()
        {
            SqlTransaction tr;

            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();

                tr = cn.BeginTransaction();
                try
                {
                    if (base.IsDirty)
                    {
                        ExecuteUpdate(tr);
                    }

                    //update child object(s)
                    UpdateChildren(tr);

                    tr.Commit();
                }
                catch (SqlException ex)
                {
                    tr.Rollback();
                    HamDungChung.ThongBaoLoi(ex);
                }
            }//using

        }

        #endregion //Data Access - Update

        #region Data Access - Delete
        protected override void DataPortal_DeleteSelf()
        {
            DataPortal_Delete(new Criteria(_maHopDong));
        }

        private void DataPortal_Delete(Criteria criteria)
        {
            SqlTransaction tr;

            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();

                tr = cn.BeginTransaction();
                try
                {

                    UpdateChildren(tr);
                    ExecuteDelete(tr, criteria);
                    tr.Commit();
                }
                catch (SqlException ex)
                {
                    tr.Rollback();
                    HamDungChung.ThongBaoLoi(ex);
                }
            }//using

        }

        private void ExecuteDelete(SqlTransaction tr, Criteria criteria)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_DeletetblHopDongMuaBan";

                cm.Parameters.AddWithValue("@MaHopDong", criteria.MaHopDong);

                cm.ExecuteNonQuery();
            }//using
        }
        #endregion //Data Access - Delete

        #region Data Access - Fetch
        private void Fetch(SafeDataReader dr)
        {
            FetchObject(dr);
            MarkOld();
            ValidationRules.CheckRules();

            //load child object(s)
            FetchChildren(MaHopDong);
        }
        private void FetchWithoutChild(SafeDataReader dr)
        {
            FetchObject(dr);
            MarkOld();
            ValidationRules.CheckRules();

        }

        private void FetchObject(SafeDataReader dr)
        {
            _maHopDong = dr.GetInt64("MaHopDong");
            _soHopDong = dr.GetString("SoHopDong");
            _maBangBaoGia = dr.GetInt32("MaBangBaoGia");
            _tongTien = dr.GetDecimal("TongTien");
            _maLoaiHopDong = dr.GetInt32("MaLoaiHopDong");
            _maLoaiTien = dr.GetInt32("MaLoaiTien");
            _maHopDongQL = dr.GetString("MaHopDongQL");
            _tenHopDong = dr.GetString("TenHopDong");
            _maDoiTac = dr.GetInt64("MaDoiTac");
            _ngayLap = dr.GetSmartDate("NgayLap", _ngayLap.EmptyIsMin);
            _tuNgay = dr.GetSmartDate("TuNgay", _tuNgay.EmptyIsMin);
            _ngayHetHan = dr.GetSmartDate("NgayHetHan", _ngayHetHan.EmptyIsMin);
            _maNguoiLap = dr.GetInt32("MaNguoiLap");
            _tinhTrang = dr.GetByte("TinhTrang");
            //_flieDinhKem = (byte[])dr["FileDinhKem"];
            _nguoiLienLac = dr.GetInt64("NguoiLienLac");
            _maNguoiKy = dr.GetInt64("MaNguoiKy");
            _ngayKy = dr.GetSmartDate("NgayKy", _ngayKy.EmptyIsMin);
            _ghiChu = dr.GetString("GhiChu");
            _phanTramKyQuy = dr.GetDouble("PhanTramKyQuy");
            _soTienDatCoc = dr.GetDecimal("SoTienDatCoc");
            _phiGiaoDich = dr.GetDecimal("PhiGiaoDich");
            _laiSuat = dr.GetDouble("LaiSuat");
            _vietBangChu = dr.GetString("VietBangChu");
            _tenDoiTac = dr.GetString("TenDoiTac");
            _maQLDoiTac = dr.GetString("MaQLDoiTac");
            _cmnd = dr.GetString("CMND");
            _muaBan = dr.GetBoolean("MuaBan");
            _hdTrongNgoaiDai = dr.GetBoolean("HDTrongNgoaiDai");
            _thueSuat = dr.GetDouble("ThueSuat");
            _thueVAT = dr.GetDecimal("ThueVat");
            _tenNguoiKy = dr.GetString("TenNguoiKy");
            _tenNguoiLienLac = dr.GetString("TenNguoiLienLac");
            _ngayApDungLai = dr.GetSmartDate("NgayApDungLai", _ngayApDungLai.EmptyIsMin);
            _soNgay = dr.GetInt32("SoNgay");
            _loaiNgay = dr.GetBoolean("LoaiNgay");
            _soThamDinh = dr.GetString("SoThamDinh");
            _ngayThamDinh = dr.GetSmartDate("NgayThamDinh", _ngayThamDinh.EmptyIsMin);
            _maBoPhanChuQuan = dr.GetInt32("MaBoPhanChuQuan");
            _donViChuQuan = dr.GetString("DonViChuQuan");
            //
            _thueTNGiuLai = dr.GetDecimal("ThueTNGiuLai");
            _maDuAn = dr.GetInt32("MaDuAn");
            _quyCMTL = dr.GetDecimal("QuyCMTL");
            _ngayNhapQuyCMTL = dr.GetSmartDate("NgayNhapQuyCMTL", _ngayNhapQuyCMTL.EmptyIsMin);
            _maPhanLoaiHD = dr.GetInt32("MaPhanLoaiHD");
            _maHopDongChinh = dr.GetInt64("MaHopDongChinh");
            _laPhuLuc = dr.GetBoolean("LaPhuLuc");
            _thuChi = dr.GetByte("ThuChi");
            _loaiChuongTrinhHD = dr.GetByte("LoaiChuongTrinhHD");
            _tiGiaQuyDoi = dr.GetDouble("TiGiaQuyDoi");
            _maChuongTrinh = dr.GetInt32("MaChuongTrinh");
            _maKeHoach = dr.GetInt32("MaKeHoach");
            _giaTriQuyetToan = dr.GetDecimal("GiaTriQuyetToan");
            _soKeToanTheoDoi = dr.GetString("SoKeToanTheoDoi");
        }

        private void FetchChildren(long maHopDong)
        {
            _CT_HopDongDichVuList = CT_HopDongThuChiList.GetCT_HopDongDichVuList(maHopDong);
            _chiTietThanhToanList = ChiTietThanhToanHopDongThuChiList.GetChiTietThanhToanList(maHopDong);
            _chiTietThanhToanThucTeList = ChiTietThanhToanThucTeList.GetChiTietThanhToanThucTeList(maHopDong);
            _chiTietThuLaoHopDongList = ChiTietThuLaoHopDongList.GetChiTietThuLaoHopDongList(maHopDong);
        }
        #endregion //Data Access - Fetch

        #region Data Access - Insert
        internal void Insert(SqlTransaction tr)
        {
            if (!IsDirty) return;

            ExecuteInsert(tr);
            MarkOld();

            //update child object(s)
            UpdateChildren(tr);
        }

        private void ExecuteInsert(SqlTransaction tr)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_InserttblHopDongMuaBan_N";

                AddInsertParameters(cm);

                cm.ExecuteNonQuery();

                _maHopDong = (long)cm.Parameters["@MaHopDong"].Value;
            }//using
        }

        private void AddInsertParameters(SqlCommand cm)
        {
            if (_soHopDong.Length > 0)
                cm.Parameters.AddWithValue("@SoHopDong", _soHopDong);
            else
                cm.Parameters.AddWithValue("@SoHopDong", DBNull.Value);
            if (_maBangBaoGia != 0)
                cm.Parameters.AddWithValue("@MaBangBaoGia", _maBangBaoGia);
            else
                cm.Parameters.AddWithValue("@MaBangBaoGia", DBNull.Value);
            if (_tongTien != 0)
                cm.Parameters.AddWithValue("@TongTien", _tongTien);
            else
                cm.Parameters.AddWithValue("@TongTien", DBNull.Value);
            if (_maLoaiHopDong != 0)
                cm.Parameters.AddWithValue("@MaLoaiHopDong", _maLoaiHopDong);
            else
                cm.Parameters.AddWithValue("@MaLoaiHopDong", DBNull.Value);
            if (_maLoaiTien != 0)
                cm.Parameters.AddWithValue("@MaLoaiTien", _maLoaiTien);
            else
                cm.Parameters.AddWithValue("@MaLoaiTien", DBNull.Value);
            cm.Parameters.AddWithValue("@MaHopDongQL", _maHopDongQL);
            cm.Parameters.AddWithValue("@TenHopDong", _tenHopDong);
            if (_maDoiTac != 0)
                cm.Parameters.AddWithValue("@MaDoiTac", _maDoiTac);
            else
                cm.Parameters.AddWithValue("@MaDoiTac", DBNull.Value);
            cm.Parameters.AddWithValue("@NgayLap", _ngayLap.DBValue);
            //if (_tuNgay == DateTime.MinValue)
            //    cm.Parameters.AddWithValue("@TuNgay", _tuNgay.DBValue);
            //else
            cm.Parameters.AddWithValue("@TuNgay", _tuNgay.DBValue);
            //if (_ngayHetHan == DateTime.MinValue)
            //    cm.Parameters.AddWithValue("@NgayHetHan", _ngayHetHan.DBValue);
            //else
            cm.Parameters.AddWithValue("@NgayHetHan", _ngayHetHan.DBValue);
            cm.Parameters.AddWithValue("@MaNguoiLap", _maNguoiLap);
            cm.Parameters.AddWithValue("@TinhTrang", _tinhTrang);
            if (_maNguoiKy != 0)
                cm.Parameters.AddWithValue("@MaNguoiKy", _maNguoiKy);
            else
                cm.Parameters.AddWithValue("@MaNguoiKy", DBNull.Value);
            cm.Parameters.AddWithValue("@NgayKy", _ngayKy.DBValue);
            cm.Parameters.AddWithValue("@FileDinhKem", _flieDinhKem);
            if (_nguoiLienLac != 0)
                cm.Parameters.AddWithValue("@NguoiLienLac", _nguoiLienLac);
            else
                cm.Parameters.AddWithValue("@NguoiLienLac", DBNull.Value);
            cm.Parameters.AddWithValue("@GhiChu", _ghiChu);
            cm.Parameters.AddWithValue("@PhanTramKyQuy", _phanTramKyQuy);
            cm.Parameters.AddWithValue("@SoTienDatCoc", _soTienDatCoc);
            if (_phiGiaoDich != 0)
                cm.Parameters.AddWithValue("@PhiGiaoDich", _phiGiaoDich);
            else
                cm.Parameters.AddWithValue("@PhiGiaoDich", DBNull.Value);
            cm.Parameters.AddWithValue("@LaiSuat", _laiSuat);
            cm.Parameters.AddWithValue("@VietBangChu", _vietBangChu);
            cm.Parameters.AddWithValue("@DaThanhToan", _daThanhToan);
            cm.Parameters.AddWithValue("@MaHopDong", _maHopDong);
            cm.Parameters["@MaHopDong"].Direction = ParameterDirection.Output;
            cm.Parameters.AddWithValue("@MuaBan", _muaBan);
            cm.Parameters.AddWithValue("@HDTrongNgoaiDai", _hdTrongNgoaiDai);
            if (_thueSuat != 0)
                cm.Parameters.AddWithValue("@ThueSuat", _thueSuat);
            else cm.Parameters.AddWithValue("@ThueSuat", DBNull.Value);
            if (_thueVAT != 0)
                cm.Parameters.AddWithValue("@ThueVAT", _thueVAT);
            else cm.Parameters.AddWithValue("@ThueVAT", DBNull.Value);
            if (_tenNguoiKy.Length > 0)
                cm.Parameters.AddWithValue("@TenNguoiKy", _tenNguoiKy);
            else
                cm.Parameters.AddWithValue("@TenNguoiKy", DBNull.Value);
            cm.Parameters.AddWithValue("@TenNguoiLienLac", _tenNguoiLienLac);
            //if (_ngayApDungLai == DateTime.MinValue)
            //    cm.Parameters.AddWithValue("@NgayApDungLai", DBNull.Value);
            //else
            cm.Parameters.AddWithValue("@NgayApDungLai", _ngayApDungLai.DBValue);
            cm.Parameters.AddWithValue("@SoNgay", _soNgay);
            cm.Parameters.AddWithValue("@LoaiNgay", _loaiNgay);
            if (_soThamDinh.Length > 0)
                cm.Parameters.AddWithValue("@SoThamDinh", _soThamDinh);
            else
                cm.Parameters.AddWithValue("@SoThamDinh", DBNull.Value);

            cm.Parameters.AddWithValue("@NgayThamDinh", _ngayThamDinh.DBValue);
            if (_maBoPhanChuQuan != 0)
                cm.Parameters.AddWithValue("@MaBoPhanChuQuan", _maBoPhanChuQuan);
            else cm.Parameters.AddWithValue("@MaBoPhanChuQuan", DBNull.Value);
            if (_donViChuQuan.Length > 0)
                cm.Parameters.AddWithValue("@DonViChuQuan", _donViChuQuan);
            else
                cm.Parameters.AddWithValue("@DonViChuQuan", DBNull.Value);


            if (_thueTNGiuLai != 0)
                cm.Parameters.AddWithValue("@ThueTNGiuLai", _thueTNGiuLai);
            else
                cm.Parameters.AddWithValue("@ThueTNGiuLai", DBNull.Value);

            if (_maDuAn != 0)
                cm.Parameters.AddWithValue("@MaDuAn", _maDuAn);
            else
                cm.Parameters.AddWithValue("@MaDuAn", DBNull.Value);

            if (_quyCMTL != 0)
                cm.Parameters.AddWithValue("@QuyCMTL", _quyCMTL);
            else
                cm.Parameters.AddWithValue("@QuyCMTL", DBNull.Value);
            cm.Parameters.AddWithValue("@NgayNhapQuyCMTL", _ngayNhapQuyCMTL.DBValue);

            if (_maPhanLoaiHD != 0)
                cm.Parameters.AddWithValue("@MaPhanLoaiHD", _maPhanLoaiHD);
            else
                cm.Parameters.AddWithValue("@MaPhanLoaiHD", DBNull.Value);

            if (_maHopDongChinh != 0)
                cm.Parameters.AddWithValue("@MaHopDongChinh", _maHopDongChinh);
            else
                cm.Parameters.AddWithValue("@MaHopDongChinh", DBNull.Value);

            cm.Parameters.AddWithValue("@LaPhuLuc", _laPhuLuc);
            cm.Parameters.AddWithValue("@ThuChi", _thuChi);
            cm.Parameters.AddWithValue("@LoaiChuongTrinhHD", _loaiChuongTrinhHD);
            if (_tiGiaQuyDoi != 0)
                cm.Parameters.AddWithValue("@TiGiaQuyDoi", _tiGiaQuyDoi);
            else
                cm.Parameters.AddWithValue("@TiGiaQuyDoi", DBNull.Value);

            if (_maChuongTrinh != 0)
                cm.Parameters.AddWithValue("@MaChuongTrinh", _maChuongTrinh);
            else
                cm.Parameters.AddWithValue("@MaChuongTrinh", DBNull.Value);

            if (_maKeHoach != 0)
                cm.Parameters.AddWithValue("@MaKeHoach", _maKeHoach);
            else
                cm.Parameters.AddWithValue("@MaKeHoach", DBNull.Value);
            if (_giaTriQuyetToan != 0)
                cm.Parameters.AddWithValue("@giaTriQuyetToan", _giaTriQuyetToan);
            else
                cm.Parameters.AddWithValue("@giaTriQuyetToan", DBNull.Value);
            if (_soKeToanTheoDoi.Length > 0)
                cm.Parameters.AddWithValue("@soKeToanTheoDoi", _soKeToanTheoDoi);
            else
                cm.Parameters.AddWithValue("@soKeToanTheoDoi", DBNull.Value);

        }
        #endregion //Data Access - Insert

        #region Data Access - Update
        internal void Update(SqlTransaction tr)
        {
            if (!IsDirty) return;

            if (base.IsDirty)
            {
                ExecuteUpdate(tr);
                MarkOld();
            }

            //update child object(s)
            UpdateChildren(tr);
        }

        private void ExecuteUpdate(SqlTransaction tr)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_UpdatetblHopDongMuaBan_N";

                AddUpdateParameters(cm);

                cm.ExecuteNonQuery();

            }//using
        }

        private void AddUpdateParameters(SqlCommand cm)
        {
            
            if(_maNguoiLap==0)
                _maNguoiLap=ERP_Library.Security.CurrentUser.Info.UserID;

            cm.Parameters.AddWithValue("@MaHopDong", _maHopDong);
            if (_soHopDong.Length > 0)
                cm.Parameters.AddWithValue("@SoHopDong", _soHopDong);
            else
                cm.Parameters.AddWithValue("@SoHopDong", DBNull.Value);
            if (_maBangBaoGia != 0)
                cm.Parameters.AddWithValue("@MaBangBaoGia", _maBangBaoGia);
            else
                cm.Parameters.AddWithValue("@MaBangBaoGia", DBNull.Value);
            if (_tongTien != 0)
                cm.Parameters.AddWithValue("@TongTien", _tongTien);
            else
                cm.Parameters.AddWithValue("@TongTien", DBNull.Value);
            if (_maLoaiHopDong != 0)
                cm.Parameters.AddWithValue("@MaLoaiHopDong", _maLoaiHopDong);
            else
                cm.Parameters.AddWithValue("@MaLoaiHopDong", DBNull.Value);
            if (_maLoaiTien != 0)
                cm.Parameters.AddWithValue("@MaLoaiTien", _maLoaiTien);
            else
                cm.Parameters.AddWithValue("@MaLoaiTien", DBNull.Value);
            cm.Parameters.AddWithValue("@MaHopDongQL", _maHopDongQL);
            cm.Parameters.AddWithValue("@TenHopDong", _tenHopDong);
            if (_maDoiTac != 0)
                cm.Parameters.AddWithValue("@MaDoiTac", _maDoiTac);
            else
                cm.Parameters.AddWithValue("@MaDoiTac", DBNull.Value);
            cm.Parameters.AddWithValue("@NgayLap", _ngayLap.DBValue);
            //if (_tuNgay == DateTime.MinValue)
            //    cm.Parameters.AddWithValue("@TuNgay", _tuNgay.DBValue);
            //else
            cm.Parameters.AddWithValue("@TuNgay", _tuNgay.DBValue);
            //if (_ngayHetHan == DateTime.MinValue)
            //    cm.Parameters.AddWithValue("@NgayHetHan", _ngayHetHan.DBValue);
            //else
            cm.Parameters.AddWithValue("@NgayHetHan", _ngayHetHan.DBValue);
            cm.Parameters.AddWithValue("@MaNguoiLap", _maNguoiLap);
            cm.Parameters.AddWithValue("@TinhTrang", _tinhTrang);
            if (_maNguoiKy != 0)
                cm.Parameters.AddWithValue("@MaNguoiKy", _maNguoiKy);
            else
                cm.Parameters.AddWithValue("@MaNguoiKy", DBNull.Value);
            cm.Parameters.AddWithValue("@NgayKy", _ngayKy.DBValue);
            cm.Parameters.AddWithValue("@FileDinhKem", _flieDinhKem);
            cm.Parameters.AddWithValue("@NguoiLienLac", _nguoiLienLac);
            cm.Parameters.AddWithValue("@GhiChu", _ghiChu);
            cm.Parameters.AddWithValue("@PhanTramKyQuy", _phanTramKyQuy);
            cm.Parameters.AddWithValue("@SoTienDatCoc", _soTienDatCoc);
            if (_phiGiaoDich != 0)
                cm.Parameters.AddWithValue("@PhiGiaoDich", _phiGiaoDich);
            else
                cm.Parameters.AddWithValue("@PhiGiaoDich", DBNull.Value);
            if (_laiSuat != 0)
                cm.Parameters.AddWithValue("@LaiSuat", _laiSuat);
            else
                cm.Parameters.AddWithValue("@LaiSuat", DBNull.Value);
            cm.Parameters.AddWithValue("@VietBangChu", _vietBangChu);
            cm.Parameters.AddWithValue("@DaThanhToan", _daThanhToan);
            cm.Parameters.AddWithValue("@MuaBan", _muaBan);
            cm.Parameters.AddWithValue("@HDTrongNgoaiDai", _hdTrongNgoaiDai);
            if (_thueSuat != 0)
                cm.Parameters.AddWithValue("@ThueSuat", _thueSuat);
            else cm.Parameters.AddWithValue("@ThueSuat", DBNull.Value);
            if (_thueVAT != 0)
                cm.Parameters.AddWithValue("@ThueVAT", _thueVAT);
            else cm.Parameters.AddWithValue("@ThueVAT", DBNull.Value);
            if (_tenNguoiKy.Length > 0)
                cm.Parameters.AddWithValue("@TenNguoiKy", _tenNguoiKy);
            else
                cm.Parameters.AddWithValue("@TenNguoiKy", DBNull.Value);
            cm.Parameters.AddWithValue("@TenNguoiLienLac", _tenNguoiLienLac);
            //if (_ngayApDungLai == DateTime.MinValue)
            //    cm.Parameters.AddWithValue("@NgayApDungLai", DBNull.Value);
            //else
            cm.Parameters.AddWithValue("@NgayApDungLai", _ngayApDungLai.DBValue);
            cm.Parameters.AddWithValue("@SoNgay", _soNgay);
            cm.Parameters.AddWithValue("@LoaiNgay", _loaiNgay);
            if (_soThamDinh.Length > 0)
                cm.Parameters.AddWithValue("@SoThamDinh", _soThamDinh);
            else
                cm.Parameters.AddWithValue("@SoThamDinh", DBNull.Value);
            cm.Parameters.AddWithValue("@NgayThamDinh", _ngayThamDinh.DBValue);
            if (_maBoPhanChuQuan != 0)
                cm.Parameters.AddWithValue("@MaBoPhanChuQuan", _maBoPhanChuQuan);
            else cm.Parameters.AddWithValue("@MaBoPhanChuQuan", DBNull.Value);
            if (_donViChuQuan.Length > 0)
                cm.Parameters.AddWithValue("@DonViChuQuan", _donViChuQuan);
            else
                cm.Parameters.AddWithValue("@DonViChuQuan", DBNull.Value);

            //
            if (_thueTNGiuLai != 0)
                cm.Parameters.AddWithValue("@ThueTNGiuLai", _thueTNGiuLai);
            else
                cm.Parameters.AddWithValue("@ThueTNGiuLai", DBNull.Value);

            if (_maDuAn != 0)
                cm.Parameters.AddWithValue("@MaDuAn", _maDuAn);
            else
                cm.Parameters.AddWithValue("@MaDuAn", DBNull.Value);

            if (_quyCMTL != 0)
                cm.Parameters.AddWithValue("@QuyCMTL", _quyCMTL);
            else
                cm.Parameters.AddWithValue("@QuyCMTL", DBNull.Value);
            cm.Parameters.AddWithValue("@NgayNhapQuyCMTL", _ngayNhapQuyCMTL.DBValue);

            if (_maPhanLoaiHD != 0)
                cm.Parameters.AddWithValue("@MaPhanLoaiHD", _maPhanLoaiHD);
            else
                cm.Parameters.AddWithValue("@MaPhanLoaiHD", DBNull.Value);

            if (_maHopDongChinh != 0)
                cm.Parameters.AddWithValue("@MaHopDongChinh", _maHopDongChinh);
            else
                cm.Parameters.AddWithValue("@MaHopDongChinh", DBNull.Value);

            cm.Parameters.AddWithValue("@LaPhuLuc", _laPhuLuc);
            cm.Parameters.AddWithValue("@ThuChi", _thuChi);
            cm.Parameters.AddWithValue("@LoaiChuongTrinhHD", _loaiChuongTrinhHD);
            if (_tiGiaQuyDoi != 0)
                cm.Parameters.AddWithValue("@TiGiaQuyDoi", _tiGiaQuyDoi);
            else
                cm.Parameters.AddWithValue("@TiGiaQuyDoi", DBNull.Value);

            if (_maChuongTrinh != 0)
                cm.Parameters.AddWithValue("@MaChuongTrinh", _maChuongTrinh);
            else
                cm.Parameters.AddWithValue("@MaChuongTrinh", DBNull.Value);

            if (_maKeHoach != 0)
                cm.Parameters.AddWithValue("@MaKeHoach", _maKeHoach);
            else
                cm.Parameters.AddWithValue("@MaKeHoach", DBNull.Value);
            if (_giaTriQuyetToan != 0)
                cm.Parameters.AddWithValue("@giaTriQuyetToan", _giaTriQuyetToan);
            else
                cm.Parameters.AddWithValue("@giaTriQuyetToan", DBNull.Value);
            if (_soKeToanTheoDoi.Length > 0)
                cm.Parameters.AddWithValue("@soKeToanTheoDoi", _soKeToanTheoDoi);
            else
                cm.Parameters.AddWithValue("@soKeToanTheoDoi", DBNull.Value);
        }

        private void UpdateChildren(SqlTransaction tr)
        {
            _CT_HopDongDichVuList.Update(tr, this);
            _chiTietThanhToanList.Update(tr, this);

            _chiTietThanhToanThucTeList.Update(tr, this);
            _chiTietThuLaoHopDongList.Update(tr, this);
        }
        #endregion //Data Access - Update

        #region Data Access - Delete
        internal void DeleteSelf(SqlTransaction tr)
        {
            if (!IsDirty) return;
            if (IsNew) return;

            _CT_HopDongDichVuList.Clear();
            _chiTietThanhToanList.Clear();
            _chiTietThanhToanThucTeList.Clear();
            _chiTietThuLaoHopDongList.Clear();
            UpdateChildren(tr);
            ExecuteDelete(tr, new Criteria(_maHopDong));
            MarkNew();
        }
        #endregion //Data Access - Delete
        #endregion //Data Access

        #region Kiểm Tra

        internal static int KiemTraSoHopDong(string soHopDong, int loaiHopDong, bool muaBan)
        {
            int giaTriTraVe = 0;
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {

                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_KiemTraSoHopDongMuaBan";
                    cm.Parameters.AddWithValue("@SoHopDong", soHopDong);
                    cm.Parameters.AddWithValue("@LoaiHopDong", loaiHopDong);
                    cm.Parameters.AddWithValue("@GiaTriTraVe", giaTriTraVe);
                    cm.Parameters.AddWithValue("@MuaBan", muaBan);
                    cm.Parameters["@GiaTriTraVe"].Direction = ParameterDirection.Output;
                    cm.ExecuteNonQuery();
                    giaTriTraVe = (int)cm.Parameters["@GiaTriTraVe"].Value;
                }
            }//us

            return giaTriTraVe;
        }

        public static string SoHopDongTuDongTang(int loaiHopDong, bool muaBan)
        {
            string giaTriTraVe = string.Empty;
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {

                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_GetSoHopDongMuaBanLonNhat";
                    cm.Parameters.AddWithValue("@LoaiHopDong", loaiHopDong);
                    cm.Parameters.AddWithValue("@MuaBan", muaBan);

                    SqlParameter prmGiaTriTraVe = new SqlParameter("@GiaTriTraVe", SqlDbType.VarChar, 30);
                    prmGiaTriTraVe.Direction = ParameterDirection.Output;
                    cm.Parameters.Add(prmGiaTriTraVe);
                    cm.ExecuteNonQuery();
                    giaTriTraVe = (string)prmGiaTriTraVe.Value;
                }
            }//us
            return giaTriTraVe;
        }

        public static string SetSoHopDongTrongDai(DateTime ngayLap)
        {
            string giaTriTraVe = string.Empty;
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {

                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_SetSoHopDongTrongDai";
                    cm.Parameters.AddWithValue("@NgayLap", ngayLap);
                    cm.Parameters.AddWithValue("@MaCongTy", ERP_Library.Security.CurrentUser.Info.MaCongTy);
                    SqlParameter prmGiaTriTraVe = new SqlParameter("@GiaTriTraVe", SqlDbType.VarChar, 40);
                    prmGiaTriTraVe.Direction = ParameterDirection.Output;
                    cm.Parameters.Add(prmGiaTriTraVe);
                    cm.ExecuteNonQuery();
                    giaTriTraVe = (string)prmGiaTriTraVe.Value;
                }
            }//us
            return giaTriTraVe;
        }

        public static string SetSoPhuLucHopDong(long maHopDong)
        {
            string giaTriTraVe = string.Empty;
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {

                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_SetMaPhuLucHopDongQuanLy";
                    cm.Parameters.AddWithValue("@MaHopDong", maHopDong);
                    cm.Parameters.AddWithValue("@MaCongTy", ERP_Library.Security.CurrentUser.Info.MaCongTy);
                    SqlParameter prmGiaTriTraVe = new SqlParameter("@GiaTriTraVe", SqlDbType.VarChar, 40);
                    prmGiaTriTraVe.Direction = ParameterDirection.Output;
                    cm.Parameters.Add(prmGiaTriTraVe);
                    cm.ExecuteNonQuery();
                    giaTriTraVe = (string)prmGiaTriTraVe.Value;
                }
            }//us
            return giaTriTraVe;
        }

        public static string SetSoThamDinhHopDong(DateTime ngayLap)
        {
            string giaTriTraVe = string.Empty;
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {

                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_SetSoThamDinhHopDong";
                    cm.Parameters.AddWithValue("@NgayLap", ngayLap);
                    cm.Parameters.AddWithValue("@MaCongTy", ERP_Library.Security.CurrentUser.Info.MaCongTy);
                    SqlParameter prmGiaTriTraVe = new SqlParameter("@GiaTriTraVe", SqlDbType.VarChar, 40);
                    prmGiaTriTraVe.Direction = ParameterDirection.Output;
                    cm.Parameters.Add(prmGiaTriTraVe);
                    cm.ExecuteNonQuery();
                    giaTriTraVe = (string)prmGiaTriTraVe.Value;
                }
            }//us
            return giaTriTraVe;
        }

        public static bool KiemTraTrungSoHopDong(long maHopDong, string soHopDong)
        {
            bool trungSoHopDong = false;
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {

                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "Spd_KiemTraTrungSoHopDong";
                    cm.Parameters.AddWithValue("@MaHopDong", maHopDong);
                    cm.Parameters.AddWithValue("@SoHopDong", soHopDong);
                    cm.Parameters.AddWithValue("@MaCongTy", ERP_Library.Security.CurrentUser.Info.MaCongTy);
                    SqlParameter prmGiaTriTraVe = new SqlParameter("@TrungSoHopDong", SqlDbType.Bit);
                    prmGiaTriTraVe.Direction = ParameterDirection.Output;
                    cm.Parameters.Add(prmGiaTriTraVe);
                    cm.ExecuteNonQuery();
                    trungSoHopDong = (bool)prmGiaTriTraVe.Value;
                }
            }//us
            return trungSoHopDong;
        }



        public static bool KiemTraTrungSoThamDinhHopDong(long maHopDong, string soThamDinh)
        {
            bool trungSoThamDinh = false;
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {

                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "Spd_KiemTraTrungSoThamDinhHopDong";
                    cm.Parameters.AddWithValue("@MaHopDong", maHopDong);
                    cm.Parameters.AddWithValue("@SoThamDinh", soThamDinh);
                    SqlParameter prmGiaTriTraVe = new SqlParameter("@TrungSoThamDinh", SqlDbType.Bit);
                    prmGiaTriTraVe.Direction = ParameterDirection.Output;
                    cm.Parameters.Add(prmGiaTriTraVe);
                    cm.ExecuteNonQuery();
                    trungSoThamDinh = (bool)prmGiaTriTraVe.Value;
                }
            }//us
            return trungSoThamDinh;
        }

        public static string GetSoHopDongForSoPhuLuc(long maHopDong)
        {
            string soHopDong = string.Empty;
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_GetSoHopDongForSoPhuLuc";
                    cm.Parameters.AddWithValue("@MaHopDong", maHopDong);
                    SqlParameter prmGiaTriTraVe = new SqlParameter("@GiaTriTraVe", SqlDbType.NVarChar, 40);
                    prmGiaTriTraVe.Direction = ParameterDirection.Output;
                    cm.Parameters.Add(prmGiaTriTraVe);
                    cm.ExecuteNonQuery();
                    soHopDong = (string)prmGiaTriTraVe.Value;
                }
            }//us
            return soHopDong;
        }
        #endregion

    }
}
