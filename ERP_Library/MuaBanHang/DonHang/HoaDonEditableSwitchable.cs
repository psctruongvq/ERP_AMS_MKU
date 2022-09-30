using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;
using System.Collections.Generic;

//ngay 05/12/2013 

namespace ERP_Library
{
    [Serializable()]
    public class HoaDon : Csla.BusinessBase<HoaDon>
    {
        #region Business Properties and Methods

        //declare members
        private long _maHoaDon = 0;
        private int _loaiHoaDon = 0;
        private double _thueSuatVAT = 0;
        private long _maDoiTac = 0;
        private long _maPhieuNhapXuat = 0;
        private string _soSerial = string.Empty;
        private string _soHoaDon = string.Empty;
        private decimal _thanhTien = 0;
        private decimal _thueVAT = 0;
        private decimal _tongTien = 0;
        private double _chietKhau = 0;
        private long _maNguoiLap = ERP_Library.Security.CurrentUser.Info.UserID;
        private bool _muaBan = false;
        private DateTime _ngayLap = DateTime.Now.Date;
        private int _maHinhThucTT = 0;
        private DateTime _ngayHetHanTT = DateTime.Now.Date;
        private int _maNguoiLienLac = 0;
        private int _maDCGuiHD = 0;
        private int _maDienThoai = 0;
        private byte _tinhTrang = 0;
        private string _vietBangChu = string.Empty;
        private decimal _soTienDaThanhToan = 0;
        private decimal _soTienConLai = 0;
        private long _maDonHang = 0;
        private byte _quyTrinh = 0;
        private byte _doiTuongMuaBan = 0;
        private bool _nhapXuat = false;
        private long _maHopDong = 0;
        private long _maSoTK = 0;
        private string _tenDoiTac = string.Empty;
        private string _maQLDoiTac = string.Empty;
        private string _maSoThue = string.Empty;
        private string _DiaChi = string.Empty;
        private string _cmnd = string.Empty;
        private bool _check = false;
        private bool _tatToan = false;
        private decimal _soTienChietKhau = 0;
        private byte _loaiUuDai = 0;
        private bool _chiHoaHong = false;
        private decimal _soTienTucThoi = 0;
        private bool _chuyenCongNo = false;
        private bool _khauTruThue = false;
        private string _ghichu = "";
        private string _soct_hd = "";
        private int _maLoaiTien = 1;
        private decimal _nguyenTe = 0;
        private decimal _tyGia = 1;
        private decimal _thueSuatGTGTNhaThau = 50;
        private decimal _tyLeGTGT = 10;
        private decimal _thueGTGTNhaThau = 0;
        private decimal _thueSuatTNDNNhaThau = 5;
        private decimal _thueTNDNNhaThau = 0;
        private decimal _thueMienGiam = 0;
        private string _soChungTu = "";
        private decimal _tienThue = 0;
        private DateTime _ngayLapCT = new DateTime();// = new DateTime();
        private string _mauHoaDon = string.Empty;
        private string _kyHieuMauHoaDon = string.Empty;

        private Guid _OidBienLai = Guid.Empty;
        private int _IDBienLai = 0;

        private byte _NhomHHDVMuaVao = 0;
        private long _maChungTu_CongNo = 0;
        private int _maLoaiChungTu_CongNo = 0;
        private decimal _soTienThanhToan = 0;
        private string _soChungTu_ThanhToan = string.Empty;
        private long _maChungTu_ThanhToan = 0;
        private int _maLoaiChungTu_ThanhToan = 0;
        #region BS import from Excel
        string _TenKhachHangNgoai = string.Empty;
        string _NguoiLienLacNgoai = string.Empty;
        string _MSThueNgoai = string.Empty;
        string _DiaChiNgoai = string.Empty;
        string _DTNgoai = string.Empty;
        public string TenKhachHangNgoai
        {
            get
            {
                CanReadProperty("TenKhachHangNgoai", true);
                return _TenKhachHangNgoai;
            }
            set
            {
                CanWriteProperty("TenKhachHangNgoai", true);
                if (!_TenKhachHangNgoai.Equals(value))
                {
                    _TenKhachHangNgoai = value;
                    PropertyHasChanged("TenKhachHangNgoai");
                }
            }
        }
        public string NguoiLienLacNgoai
        {
            get
            {
                CanReadProperty("NguoiLienLacNgoai", true);
                return _NguoiLienLacNgoai;
            }
            set
            {
                CanWriteProperty("NguoiLienLacNgoai", true);
                if (!_NguoiLienLacNgoai.Equals(value))
                {
                    _NguoiLienLacNgoai = value;
                    PropertyHasChanged("NguoiLienLacNgoai");
                }
            }
        }
        public string MSThueNgoai
        {
            get
            {
                CanReadProperty("MSThueNgoai", true);
                return _MSThueNgoai;
            }
            set
            {
                CanWriteProperty("MSThueNgoai", true);
                if (!_MSThueNgoai.Equals(value))
                {
                    _MSThueNgoai = value;
                    PropertyHasChanged("MSThueNgoai");
                }
            }
        }
        public string DiaChiNgoai
        {
            get
            {
                CanReadProperty("DiaChiNgoai", true);
                return _DiaChiNgoai;
            }
            set
            {
                CanWriteProperty("DiaChiNgoai", true);
                if (!_DiaChiNgoai.Equals(value))
                {
                    _DiaChiNgoai = value;
                    PropertyHasChanged("DiaChiNgoai");
                }
            }
        }
        public string DTNgoai
        {
            get
            {
                CanReadProperty("DTNgoai", true);
                return _DTNgoai;
            }
            set
            {
                CanWriteProperty("DTNgoai", true);
                if (!_DTNgoai.Equals(value))
                {
                    _DTNgoai = value;
                    PropertyHasChanged("DTNgoai");
                }
            }
        }
        #endregion//BS import from Excel

        //private ChungTu_HoaDon _ChungTu_HoaDon = ChungTu_HoaDon.NewChungTu_HoaDon();

        //declare child member(s)
        private CT_HoaDonList _cT_HoaDonList = CT_HoaDonList.NewCT_HoaDonList();
        private CT_HoaDonDichVuList _cT_HoaDonDichVuList = CT_HoaDonDichVuList.NewCT_HoaDonDichVuList();
        private CT_HoaDonBienLaiChildList _CT_HoaDonBienLaiList = CT_HoaDonBienLaiChildList.NewCT_HoaDonBienLaiChildList();
        private ChungTu_HoaDonList _ChungTu_HoaDonList = ChungTu_HoaDonList.NewChungTu_HoaDonList();
        private ChungTu_HoaDonThanhToanChildList _ChungTu_HoaDonThanhToanList = ChungTu_HoaDonThanhToanChildList.NewChungTu_HoaDonThanhToanChildList();
        [System.ComponentModel.DataObjectField(true, true)]

        public long MaHoaDon
        {
            get
            {
                CanReadProperty("MaHoaDon", true);
                return _maHoaDon;
            }
        }

        //public ChungTu_HoaDon ChungTu_HoaDon
        //{
        //    get
        //    {
        //        CanReadProperty(true);
        //        return _ChungTu_HoaDon;
        //    }
        //    set
        //    {
        //        CanWriteProperty("ChungTu_HoaDon", true);
        //        if (!_ChungTu_HoaDon.Equals(value))
        //        {
        //            _ChungTu_HoaDon = value;
        //            PropertyHasChanged("ChungTu_HoaDon");
        //        }
        //    }
        //}


        public int LoaiHoaDon
        {
            get
            {
                CanReadProperty("LoaiHoaDon", true);
                return _loaiHoaDon;
            }
            set
            {
                CanWriteProperty("LoaiHoaDon", true);
                if (!_loaiHoaDon.Equals(value))
                {
                    _loaiHoaDon = value;
                    PropertyHasChanged("LoaiHoaDon");
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
                    if (_loaiHoaDon == 4)
                    {
                        if (_thueSuatVAT == -1)
                        {
                            _thueVAT = 0;
                            _tongTien = (_thanhTien - _soTienChietKhau);
                        }
                        else
                        {
                            _thueVAT = Math.Round(((_thanhTien - _soTienChietKhau) * (decimal)_thueSuatVAT / 100));
                            //_tongTien = _thanhTien + _thanhTien * (decimal)_thueSuatVAT / 100;
                            _tongTien = (_thanhTien - _soTienChietKhau) + _thueVAT;
                        }
                    }
                    else
                    {
                        if (_thueSuatVAT == -1)
                        {
                            _thueVAT = 0;
                            _tongTien = (_thanhTien - _soTienChietKhau);
                        }
                        else
                        {
                            _thueVAT = Math.Round((_thanhTien - _soTienChietKhau) * (decimal)_thueSuatVAT / 100, 0);
                            _tongTien = (_thanhTien - _soTienChietKhau) + _thueVAT;
                        }

                    }
                    //_vietBangChu = HamDungChung.DocTien(_tongTien);
                    PropertyHasChanged("ThueSuatVAT");
                }
            }
        }

        public long MaDoiTac
        {
            get
            {
                CanReadProperty("MaDoiTac", true);
                LoadDoiTuong();
                return _maDoiTac;
            }
            set
            {
                CanWriteProperty("MaDoiTac", true);
                if (!_maDoiTac.Equals(value))
                {
                    _maDoiTac = value;
                    LoadDoiTuong();
                    PropertyHasChanged("MaDoiTac");
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

        public long MaSoTK
        {
            get
            {
                CanReadProperty("MaSoTK", true);
                return _maSoTK;
            }
            set
            {
                CanWriteProperty("MaSoTK", true);
                if (!_maSoTK.Equals(value))
                {
                    _maSoTK = value;
                    PropertyHasChanged("MaSoTK");
                }
            }
        }

        public long MaPhieuNhapXuat
        {
            get
            {
                CanReadProperty("MaPhieuNhapXuat", true);
                return _maPhieuNhapXuat;
            }
            set
            {
                CanWriteProperty("MaPhieuNhapXuat", true);
                if (!_maPhieuNhapXuat.Equals(value))
                {
                    _maPhieuNhapXuat = value;
                    PropertyHasChanged("MaPhieuNhapXuat");
                }
            }
        }

        public string SoSerial
        {
            get
            {
                CanReadProperty("SoSerial", true);
                return _soSerial;
            }
            set
            {
                CanWriteProperty("SoSerial", true);
                if (value == null) value = string.Empty;
                if (!_soSerial.Equals(value))
                {
                    _soSerial = value;
                    PropertyHasChanged("SoSerial");
                }
            }
        }

        public string SoHoaDon
        {
            get
            {
                CanReadProperty("SoHoaDon", true);
                return _soHoaDon;
            }
            set
            {
                CanWriteProperty("SoHoaDon", true);
                if (value == null) value = string.Empty;
                if (!_soHoaDon.Equals(value))
                {
                    _soHoaDon = value;
                    PropertyHasChanged("SoHoaDon");
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
                    if (_loaiHoaDon == 4)
                    {
                        if (_thueSuatVAT == -1)
                        {
                            _thueVAT = 0;
                            _tongTien = _thanhTien;
                        }
                        else
                        {
                            _thueVAT = Math.Round((_thanhTien - _soTienChietKhau) * (decimal)_thueSuatVAT / 100, 0);
                            _tongTien = (_thanhTien - _soTienChietKhau) + _thueVAT;
                        }
                    }
                    else
                    {
                        if (_thueSuatVAT == -1)
                        {
                            _thueVAT = 0;
                            _tongTien = (_thanhTien - _soTienChietKhau) + _thueVAT;
                        }
                        else
                        {
                            _thueVAT = Math.Round((_thanhTien - _soTienChietKhau) * (decimal)_thueSuatVAT / 100, 0);
                            _tongTien = (_thanhTien - _soTienChietKhau) + _thueVAT;
                        }
                    }
                    PropertyHasChanged("ThanhTien");
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
                _thueVAT = value;
                _tongTien = _thueVAT + (_thanhTien - _soTienChietKhau);
                PropertyHasChanged("ThueVAT");
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
                    //if (_loaiHoaDon == 4)
                    //{
                    //    if (_thueSuatVAT == -1)
                    //        _thueVAT = 0;
                    //    else
                    //        _thueVAT = _thanhTien * (decimal)_thueSuatVAT / 100;                        
                    //}
                    //else
                    //{
                    //    if (_thueSuatVAT == -1)
                    //    {
                    //        _thueVAT = 0;
                    //        _tongTien = _thanhTien;
                    //    }
                    //    else
                    //    {
                    //        _thueVAT = _tongTien * (decimal)_thueSuatVAT / 100;
                    //        _thanhTien = _tongTien - (_tongTien * (decimal)_thueSuatVAT / 100);
                    //    }

                    //}
                    _vietBangChu = HamDungChung.DocTien(_tongTien);
                    PropertyHasChanged("TongTien");
                }
            }
        }

        public double ChietKhau
        {
            get
            {
                CanReadProperty("ChietKhau", true);
                return _chietKhau;
            }
            set
            {
                CanWriteProperty("ChietKhau", true);
                if (!_chietKhau.Equals(value))
                {
                    _chietKhau = value;
                    PropertyHasChanged("ChietKhau");
                }
            }
        }

        public long MaNguoiLap
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

        public bool TatToan
        {
            get
            {
                CanReadProperty("TatToan", true);
                return _tatToan;
            }
            set
            {
                CanWriteProperty("TatToan", true);
                if (!_tatToan.Equals(value))
                {
                    _tatToan = value;
                    PropertyHasChanged("TatToan");
                }
            }
        }

        public DateTime NgayLap
        {
            get
            {
                CanReadProperty("NgayLap", true);
                return _ngayLap.Date;
            }
            set
            {
                CanWriteProperty("NgayLap", true);
                if (!_ngayLap.Equals(value))
                {
                    _ngayLap = value;
                    _ngayHetHanTT = _ngayLap.AddMonths(6);
                    PropertyHasChanged("NgayLap");
                }
            }
        }

        public int MaHinhThucTT
        {
            get
            {
                CanReadProperty("MaHinhThucTT", true);
                return _maHinhThucTT;
            }
            set
            {
                CanWriteProperty("MaHinhThucTT", true);
                if (!_maHinhThucTT.Equals(value))
                {
                    _maHinhThucTT = value;
                    PropertyHasChanged("MaHinhThucTT");
                }
            }
        }

        public DateTime NgayHetHanTT
        {
            get
            {
                CanReadProperty("NgayHetHanTT", true);
                return _ngayHetHanTT.Date;
            }
            set
            {
                CanWriteProperty("NgayHetHanTT", true);
                if (!_ngayHetHanTT.Equals(value))
                {
                    _ngayHetHanTT = value;
                    PropertyHasChanged("NgayHetHanTT");
                }
            }
        }

        public int MaNguoiLienLac
        {
            get
            {
                CanReadProperty("MaNguoiLienLac", true);
                return _maNguoiLienLac;
            }
            set
            {
                CanWriteProperty("MaNguoiLienLac", true);
                if (!_maNguoiLienLac.Equals(value))
                {
                    _maNguoiLienLac = value;
                    PropertyHasChanged("MaNguoiLienLac");
                }
            }
        }

        public int MaDCGuiHD
        {
            get
            {
                CanReadProperty("MaDCGuiHD", true);
                return _maDCGuiHD;
            }
            set
            {
                CanWriteProperty("MaDCGuiHD", true);
                if (!_maDCGuiHD.Equals(value))
                {
                    _maDCGuiHD = value;
                    PropertyHasChanged("MaDCGuiHD");
                }
            }
        }

        public int MaDienThoai
        {
            get
            {
                CanReadProperty("MaDienThoai", true);
                return _maDienThoai;
            }
            set
            {
                CanWriteProperty("MaDienThoai", true);
                if (!_maDienThoai.Equals(value))
                {
                    _maDienThoai = value;
                    PropertyHasChanged("MaDienThoai");
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

        public decimal SoTienDaThanhToan
        {
            get
            {
                CanReadProperty("SoTienDaThanhToan", true);
                return _soTienDaThanhToan;
            }
            set
            {
                CanWriteProperty("SoTienDaThanhToan", true);
                if (!_soTienDaThanhToan.Equals(value))
                {
                    _soTienDaThanhToan = value;
                    _soTienConLai = _tongTien - _soTienDaThanhToan;
                    PropertyHasChanged("SoTienDaThanhToan");
                }
            }
        }

        public decimal SoTienConLai
        {
            get
            {
                CanReadProperty("SoTienConLai", true);
                return _soTienConLai;
            }
            set
            {
                CanWriteProperty("SoTienConLai", true);
                if (!_soTienConLai.Equals(value))
                {
                    _soTienConLai = value;
                    PropertyHasChanged("SoTienConLai");
                }
            }
        }

        public long MaDonHang
        {
            get
            {
                CanReadProperty("MaDonHang", true);
                return _maDonHang;
            }
            set
            {
                CanWriteProperty("MaDonHang", true);
                if (!_maDonHang.Equals(value))
                {
                    _maDonHang = value;
                    PropertyHasChanged("MaDonHang");
                }
            }
        }

        public byte QuyTrinh
        {
            get
            {
                CanReadProperty("QuyTrinh", true);
                return _quyTrinh;
            }
            set
            {
                CanWriteProperty("QuyTrinh", true);
                if (!_quyTrinh.Equals(value))
                {
                    _quyTrinh = value;
                    PropertyHasChanged("QuyTrinh");
                }
            }
        }

        public byte DoiTuongMuaBan
        {
            get
            {
                CanReadProperty("DoiTuongMuaBan", true);
                return _doiTuongMuaBan;
            }
            set
            {
                CanWriteProperty("DoiTuongMuaBan", true);
                if (!_doiTuongMuaBan.Equals(value))
                {
                    _doiTuongMuaBan = value;
                    PropertyHasChanged("DoiTuongMuaBan");
                }
            }
        }

        public Boolean NhapXuat
        {
            get
            {
                CanReadProperty("NhapXuat", true);
                return _nhapXuat;
            }
            set
            {
                CanWriteProperty("NhapXuat", true);
                if (!_nhapXuat.Equals(value))
                {
                    _nhapXuat = value;
                    PropertyHasChanged("NhapXuat");
                }
            }
        }

        public Decimal SoTienChietKhau
        {
            get
            {
                CanReadProperty("SoTienChietKhau", true);
                return _soTienChietKhau;
            }
            set
            {
                CanWriteProperty("SoTienChietKhau", true);
                if (!_soTienChietKhau.Equals(value))
                {
                    _soTienChietKhau = value;
                    PropertyHasChanged("SoTienChietKhau");
                }
            }
        }

        public byte LoaiUuDai
        {
            get
            {
                CanReadProperty("LoaiUuDai", true);
                return _loaiUuDai;
            }
            set
            {
                CanWriteProperty("LoaiUuDai", true);
                if (!_loaiUuDai.Equals(value))
                {
                    _loaiUuDai = value;
                    PropertyHasChanged("LoaiUuDai");
                }
            }
        }

        public bool ChiHoaHong
        {
            get
            {
                CanReadProperty("ChiHoaHong", true);
                return _chiHoaHong;
            }
            set
            {
                CanWriteProperty("ChiHoaHong", true);
                if (!_chiHoaHong.Equals(value))
                {
                    _chiHoaHong = value;
                    PropertyHasChanged("ChiHoaHong");
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
                    LoaiTien _loaiTien = LoaiTien.GetLoaiTien(_maLoaiTien);
                    TyGia = (decimal)_loaiTien.TiGiaQuyDoi;
                    PropertyHasChanged("MaLoaiTien");
                }
            }
        }
        public decimal NguyenTe
        {
            get
            {
                CanReadProperty("NguyenTe", true);
                return _nguyenTe;
            }
            set
            {
                CanWriteProperty("NguyenTe", true);
                if (!_nguyenTe.Equals(value))
                {
                    _nguyenTe = value;
                    _thanhTien = _tyGia * _nguyenTe;
                    _thueGTGTNhaThau = Math.Round((_nguyenTe * _tyGia * _tyLeGTGT / 100 * _thueSuatGTGTNhaThau / 100) / (1 - _tyLeGTGT / 100 * _thueSuatGTGTNhaThau / 100));
                    _thueTNDNNhaThau = Math.Round((_nguyenTe * _tyGia * _thueSuatTNDNNhaThau / 100) / (1 - _thueSuatTNDNNhaThau / 100));
                    _tongTien = (_thanhTien - _soTienChietKhau) + _thueGTGTNhaThau + _thueTNDNNhaThau - _thueMienGiam;
                    PropertyHasChanged("NguyenTe");
                }
            }
        }
        public decimal TienThue
        {
            get
            {
                CanReadProperty("TienThue", true);
                return _thueVAT + _thueGTGTNhaThau + _thueTNDNNhaThau - _thueMienGiam;
            }
            //set
            //{
            //    CanReadProperty("TienThue", true);
            //    _tienThue = value;
            //}
        }

        public decimal TyGia
        {
            get
            {
                CanReadProperty("TyGia", true);
                return _tyGia;
            }
            set
            {
                CanWriteProperty("TyGia", true);
                if (!_tyGia.Equals(value))
                {
                    _tyGia = value;
                    _thanhTien = _tyGia * _nguyenTe;
                    _thueGTGTNhaThau = Math.Round((_nguyenTe * _tyGia * _tyLeGTGT / 100 * _thueSuatGTGTNhaThau / 100) / (1 - _tyLeGTGT / 100 * _thueSuatGTGTNhaThau / 100));
                    _thueTNDNNhaThau = Math.Round((_nguyenTe * _tyGia * _thueSuatTNDNNhaThau / 100) / (1 - _thueSuatTNDNNhaThau / 100));
                    _tongTien = (_thanhTien - _soTienChietKhau) + _thueGTGTNhaThau + _thueTNDNNhaThau - _thueMienGiam;
                    PropertyHasChanged("TyGia");
                }
            }
        }
        public decimal ThueSuatGTGTNhaThau
        {
            get
            {
                CanReadProperty("ThueSuatGTGTNhaThau", true);
                return _thueSuatGTGTNhaThau;
            }
            set
            {
                CanWriteProperty("ThueSuatGTGTNhaThau", true);
                if (!_thueSuatGTGTNhaThau.Equals(value))
                {
                    _thueSuatGTGTNhaThau = value;
                    _thueGTGTNhaThau = Math.Round((_nguyenTe * _tyGia * _tyLeGTGT / 100 * _thueSuatGTGTNhaThau / 100) / (1 - _tyLeGTGT / 100 * _thueSuatGTGTNhaThau / 100));
                    _tongTien = (_thanhTien - _soTienChietKhau) + _thueGTGTNhaThau + _thueTNDNNhaThau - _thueMienGiam;
                    PropertyHasChanged("ThueSuatGTGTNhaThau");
                }
            }
        }
        public decimal TyLeGTGT
        {
            get
            {
                CanReadProperty("TyLeGTGT", true);
                return _tyLeGTGT;
            }
            set
            {
                CanWriteProperty("TyLeGTGT", true);
                if (!_tyLeGTGT.Equals(value))
                {
                    _tyLeGTGT = value;
                    _thueGTGTNhaThau = Math.Round((_nguyenTe * _tyGia * _tyLeGTGT / 100 * _thueSuatGTGTNhaThau / 100) / (1 - _tyLeGTGT / 100 * _thueSuatGTGTNhaThau / 100));
                    _tongTien = (_thanhTien - _soTienChietKhau) + _thueGTGTNhaThau + _thueTNDNNhaThau - _thueMienGiam;
                    PropertyHasChanged("TyLeGTGT");
                }
            }
        }

        public decimal ThueGTGTNhaThau
        {
            get
            {
                CanReadProperty("ThueGTGTNhaThau", true);
                return _thueGTGTNhaThau;
            }
            set
            {
                CanWriteProperty("ThueGTGTNhaThau", true);
                if (!_thueGTGTNhaThau.Equals(value))
                {
                    _thueGTGTNhaThau = value;
                    _tongTien = (_thanhTien - _soTienChietKhau) + _thueGTGTNhaThau + _thueTNDNNhaThau - _thueMienGiam;
                    PropertyHasChanged("ThueGTGTNhaThau");
                }
            }
        }
        public decimal ThueSuatTNDNNhaThau
        {
            get
            {
                CanReadProperty("ThueSuatTNDNNhaThau", true);
                return _thueSuatTNDNNhaThau;
            }
            set
            {
                CanWriteProperty("ThueSuatTNDNNhaThau", true);
                if (!_thueSuatTNDNNhaThau.Equals(value))
                {
                    _thueSuatTNDNNhaThau = value;
                    _thueTNDNNhaThau = Math.Round((_nguyenTe * _tyGia * _thueSuatTNDNNhaThau / 100) / (1 - _thueSuatTNDNNhaThau / 100));
                    _tongTien = (_thanhTien - _soTienChietKhau) + _thueGTGTNhaThau + _thueTNDNNhaThau - _thueMienGiam;
                    PropertyHasChanged("ThueSuatTNDNNhaThau");
                }
            }
        }
        public decimal ThueTNDNNhaThau
        {
            get
            {
                CanReadProperty("ThueTNDNNhaThau", true);
                return _thueTNDNNhaThau;
            }
            set
            {
                CanWriteProperty("ThueTNDNNhaThau", true);
                if (!_thueTNDNNhaThau.Equals(value))
                {
                    _thueTNDNNhaThau = value;
                    _tongTien = (_thanhTien - _soTienChietKhau) + _thueGTGTNhaThau + _thueTNDNNhaThau - _thueMienGiam;
                    PropertyHasChanged("ThueTNDNNhaThau");
                }
            }
        }
        public decimal ThueMienGiam
        {
            get
            {
                CanReadProperty("ThueMienGiam", true);
                return _thueMienGiam;
            }
            set
            {
                CanWriteProperty("ThueMienGiam", true);
                if (!_thueMienGiam.Equals(value))
                {
                    _thueMienGiam = value;
                    _tongTien = (_thanhTien - _soTienChietKhau) + _thueGTGTNhaThau + _thueTNDNNhaThau - _thueMienGiam;
                    PropertyHasChanged("ThueMienGiam");
                }
            }
        }

        public CT_HoaDonList CT_HoaDonList
        {
            get
            {
                CanReadProperty("CT_HoaDonList", true);
                return _cT_HoaDonList;
            }
            set
            {
                CanWriteProperty("CT_HoaDonList", true);
                if (!_cT_HoaDonList.Equals(value))
                {
                    _cT_HoaDonList = value;
                    PropertyHasChanged("CT_HoaDonList");
                }
            }
        }

        public CT_HoaDonDichVuList CT_HoaDonDichVuList
        {
            get
            {
                CanReadProperty("CT_HoaDonDichVuList", true);
                return _cT_HoaDonDichVuList;
            }
            set
            {
                CanWriteProperty("CT_HoaDonDichVuList", true);
                if (!_cT_HoaDonDichVuList.Equals(value))
                {
                    _cT_HoaDonDichVuList = value;
                    PropertyHasChanged("CT_HoaDonDichVuList");
                }
            }
        }

        public CT_HoaDonBienLaiChildList CT_HoaDonBienLaiList
        {
            get
            {
                CanReadProperty("CT_HoaDonBienLaiList", true);
                return _CT_HoaDonBienLaiList;
            }
            set
            {
                CanWriteProperty("CT_HoaDonBienLaiList", true);
                if (!_CT_HoaDonBienLaiList.Equals(value))
                {
                    _CT_HoaDonBienLaiList = value;
                    PropertyHasChanged("CT_HoaDonBienLaiList");
                }
            }
        }

        public ChungTu_HoaDonList Chungtu_HoaDonList
        {
            get
            {
                CanReadProperty("Chungtu_HoaDonList", true);
                return _ChungTu_HoaDonList;
            }
            set
            {
                CanWriteProperty("Chungtu_HoaDonList", true);
                if (!_ChungTu_HoaDonList.Equals(value))
                {
                    _ChungTu_HoaDonList = value;
                    PropertyHasChanged("Chungtu_HoaDonList");
                }
            }
        }

        public ChungTu_HoaDonThanhToanChildList ChungTu_HoaDonThanhToanList
        {
            get
            {
                CanReadProperty("ChungTu_HoaDonThanhToanList", true);
                return _ChungTu_HoaDonThanhToanList;
            }
            set
            {
                CanWriteProperty("ChungTu_HoaDonThanhToanList", true);
                if (!_ChungTu_HoaDonThanhToanList.Equals(value))
                {
                    _ChungTu_HoaDonThanhToanList = value;
                    PropertyHasChanged("ChungTu_HoaDonThanhToanList");
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
        }
        public string MaSoThue
        {
            get
            {
                return _maSoThue;
            }
        }
        public string DiaChi
        {
            get
            {
                return _DiaChi;
            }
        }

        public string MaQLDoiTac
        {
            get
            {
                CanReadProperty("MaQLDoiTac", true);
                return _maQLDoiTac;
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

        public decimal SoTienTucThoi
        {
            get
            {
                CanReadProperty("SoTienTucThoi", true);
                return _soTienTucThoi;
            }
            set
            {
                CanWriteProperty("SoTienTucThoi", true);
                if (!_soTienTucThoi.Equals(value))
                {
                    _soTienTucThoi = value;
                    PropertyHasChanged("SoTienTucThoi");
                }
            }
        }

        public bool Check
        {
            get
            {
                CanReadProperty("Check", true);
                //if (_ChungTu_HoaDon.IsValid)
                //    _check = true;
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
        }

        public bool ChuyenCongNo
        {
            get
            {
                CanReadProperty("ChuyenCongNo", true);
                return _chuyenCongNo;
            }
            set
            {
                CanWriteProperty("ChuyenCongNo", true);
                if (!_chuyenCongNo.Equals(value))
                {
                    _chuyenCongNo = value;
                    PropertyHasChanged("ChuyenCongNo");
                }
            }
        }

        public bool KhauTruThue
        {
            get
            {
                CanReadProperty("KhauTruThue", true);
                return _khauTruThue;
            }
            set
            {
                CanWriteProperty("KhauTruThue", true);
                if (!_khauTruThue.Equals(value))
                {
                    _khauTruThue = value;
                    PropertyHasChanged("KhauTruThue");
                }
            }
        }
        public string GhiChu
        {
            get
            {
                CanReadProperty(true);
                return _ghichu;
            }
            set
            {
                CanWriteProperty(true);
                if (!_ghichu.Equals(value))
                {
                    _ghichu = value;
                    PropertyHasChanged();
                }
            }
        }

        public DateTime NgayLapCT
        {
            get
            {
                CanReadProperty("NgayLapCT", true);
                return _ngayLapCT;
            }
            set
            {
                CanWriteProperty("NgayLapCT", true);
                if (!_ngayLapCT.Equals(value))
                {
                    _ngayLapCT = value;
                    PropertyHasChanged("NgayLapCT");
                }
            }
        }

        public string SoChungTu
        {
            get
            {
                CanReadProperty("SoChungTu", true);
                return _soChungTu;
            }
            set
            {
                CanWriteProperty("SoChungTu", true);
                if (value == null) value = string.Empty;
                if (!_soChungTu.Equals(value))
                {
                    _soChungTu = value;
                    PropertyHasChanged("SoChungTu");
                }
            }
        }

        public string SoCT_HD
        {
            get
            {
                CanReadProperty(true);
                return _soct_hd;
            }
        }

        public string MauHoaDon
        {
            get
            {
                CanReadProperty("MauHoaDon", true);
                return _mauHoaDon;
            }
            set
            {
                CanWriteProperty("MauHoaDon", true);
                if (value == null) value = string.Empty;
                if (!_mauHoaDon.Equals(value))
                {
                    _mauHoaDon = value;
                    PropertyHasChanged("MauHoaDon");
                }
            }
        }

        public string KyHieuMauHoaDon
        {
            get
            {
                CanReadProperty("KyHieuMauHoaDon", true);
                return _kyHieuMauHoaDon;
            }
            set
            {
                CanWriteProperty("KyHieuMauHoaDon", true);
                if (value == null) value = string.Empty;
                if (!_kyHieuMauHoaDon.Equals(value))
                {
                    _kyHieuMauHoaDon = value;
                    PropertyHasChanged("KyHieuMauHoaDon");
                }
            }
        }

        public Guid OidBienLai
        {
            get
            {
                CanReadProperty("OidBienLai", true);
                return _OidBienLai;
            }
            set
            {
                CanWriteProperty("OidBienLai", true);
                if (value == null) value = Guid.Empty;
                if (!_OidBienLai.Equals(value))
                {
                    _OidBienLai = value;
                    PropertyHasChanged("OidBienLai");
                }
            }
        }

        public int IDBienLai
        {
            get
            {
                CanReadProperty("IDBienLai", true);
                return _IDBienLai;
            }
            set
            {
                CanWriteProperty("IDBienLai", true);
                if (!_IDBienLai.Equals(value))
                {
                    _IDBienLai = value;
                    PropertyHasChanged("IDBienLai");
                }
            }
        }

        public byte NhomHHDVMuaVao
        {
            get
            {
                CanReadProperty("NhomHHDVMuaVao", true);
                return _NhomHHDVMuaVao;
            }
            set
            {
                CanWriteProperty("NhomHHDVMuaVao", true);
                if (!_NhomHHDVMuaVao.Equals(value))
                {
                    _NhomHHDVMuaVao = value;
                    PropertyHasChanged("NhomHHDVMuaVao");
                }
            }
        }

        public long MaChungTu_CongNo
        {
            get
            {
                CanReadProperty("MaChungTu_CongNo", true);
                return _maChungTu_CongNo;
            }
            set
            {
                CanWriteProperty("MaChungTu_CongNo", true);
                if (!_maChungTu_CongNo.Equals(value))
                {
                    _maChungTu_CongNo = value;
                    PropertyHasChanged("MaChungTu_CongNo");
                }
            }
        }

        public int MaLoaiChungTu_CongNo
        {
            get
            {
                CanReadProperty("MaLoaiChungTu_CongNo", true);
                return _maLoaiChungTu_CongNo;
            }
            set
            {
                CanWriteProperty("MaLoaiChungTu_CongNo", true);
                if (!_maLoaiChungTu_CongNo.Equals(value))
                {
                    _maLoaiChungTu_CongNo = value;
                    PropertyHasChanged("MaLoaiChungTu_CongNo");
                }
            }
        }

        public decimal SoTienThanhToan
        {
            get
            {
                CanReadProperty("SoTienThanhToan", true);
                return _soTienThanhToan;
            }
            set
            {
                CanWriteProperty("SoTienThanhToan", true);
                if (!_soTienThanhToan.Equals(value))
                {
                    _soTienThanhToan = value;
                    //_soTienConLai = _tongTien - _soTienDaThanhToan;
                    PropertyHasChanged("SoTienThanhToan");
                }
            }
        }

        public string SoChungTu_ThanhToan
        {
            get
            {
                CanReadProperty("SoChungTu_ThanhToan", true);
                return _soChungTu_ThanhToan;
            }
            set
            {
                CanWriteProperty("SoChungTu_ThanhToan", true);
                if (!_soChungTu_ThanhToan.Equals(value))
                {
                    _soChungTu_ThanhToan = value;
                    PropertyHasChanged("SoChungTu_ThanhToan");
                }
            }
        }

        public long MaChungTu_ThanhToan
        {
            get
            {
                CanReadProperty("MaChungTu_ThanhToan", true);
                return _maChungTu_ThanhToan;
            }
            set
            {
                CanWriteProperty("MaChungTu_ThanhToan", true);
                if (!_maChungTu_ThanhToan.Equals(value))
                {
                    _maChungTu_ThanhToan = value;
                    PropertyHasChanged("MaChungTu_ThanhToan");
                }
            }
        }

        public int MaLoaiChungTu_ThanhToan
        {
            get
            {
                CanReadProperty("MaLoaiChungTu_ThanhToan", true);
                return _maLoaiChungTu_ThanhToan;
            }
            set
            {
                CanWriteProperty("MaLoaiChungTu_ThanhToan", true);
                if (!_maLoaiChungTu_ThanhToan.Equals(value))
                {
                    _maLoaiChungTu_ThanhToan = value;
                    PropertyHasChanged("MaLoaiChungTu_ThanhToan");
                }
            }
        }

        public override bool IsValid
        {
            get
            {
                //return base.IsValid && _cT_HoaDonList.IsValid && _cT_HoaDonDichVuList.IsValid
                //    //&& _ChungTu_HoaDon.IsValid
                //    && _CT_HoaDonBienLaiList.IsValid
                //    && _ChungTu_HoaDonList.IsValid
                //    //&& _ChungTu_HoaDonThanhToanList.IsValid
                //    ;
                return true;
            }
        }

        public override bool IsDirty
        {
            get
            {
                return base.IsDirty || _cT_HoaDonList.IsDirty || _cT_HoaDonDichVuList.IsDirty
                    //|| _ChungTu_HoaDon.IsDirty
                    || _CT_HoaDonBienLaiList.IsDirty
                    || _ChungTu_HoaDonList.IsDirty
                    || _ChungTu_HoaDonThanhToanList.IsDirty
                    ;
            }
        }

        protected override object GetIdValue()
        {
            return _maHoaDon;
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
            // SoSerial
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
            //TODO: Define authorization rules in HoaDon
            //AuthorizationRules.AllowRead("CT_HoaDonList", "HoaDonReadGroup");
            //AuthorizationRules.AllowRead("CT_HoaDonDichVuList", "HoaDonReadGroup");
            //AuthorizationRules.AllowRead("MaHoaDon", "HoaDonReadGroup");
            //AuthorizationRules.AllowRead("LoaiHoaDon", "HoaDonReadGroup");
            //AuthorizationRules.AllowRead("ThueSuatVAT", "HoaDonReadGroup");
            //AuthorizationRules.AllowRead("MaDoiTac", "HoaDonReadGroup");
            //AuthorizationRules.AllowRead("MaPhieuNhapXuat", "HoaDonReadGroup");
            //AuthorizationRules.AllowRead("SoSerial", "HoaDonReadGroup");
            //AuthorizationRules.AllowRead("SoHoaDon", "HoaDonReadGroup");
            //AuthorizationRules.AllowRead("ThanhTien", "HoaDonReadGroup");
            //AuthorizationRules.AllowRead("ThueVAT", "HoaDonReadGroup");
            //AuthorizationRules.AllowRead("TongTien", "HoaDonReadGroup");
            //AuthorizationRules.AllowRead("ChietKhau", "HoaDonReadGroup");
            //AuthorizationRules.AllowRead("MaNguoiLap", "HoaDonReadGroup");
            //AuthorizationRules.AllowRead("MuaBan", "HoaDonReadGroup");
            //AuthorizationRules.AllowRead("NgayLap", "HoaDonReadGroup");
            //AuthorizationRules.AllowRead("NgayLapString", "HoaDonReadGroup");
            //AuthorizationRules.AllowRead("MaHinhThucTT", "HoaDonReadGroup");
            //AuthorizationRules.AllowRead("NgayHetHanTT", "HoaDonReadGroup");
            //AuthorizationRules.AllowRead("NgayHetHanTTString", "HoaDonReadGroup");
            //AuthorizationRules.AllowRead("MaNguoiLienLac", "HoaDonReadGroup");
            //AuthorizationRules.AllowRead("MaDCGuiHD", "HoaDonReadGroup");
            //AuthorizationRules.AllowRead("MaDienThoai", "HoaDonReadGroup");
            //AuthorizationRules.AllowRead("TinhTrang", "HoaDonReadGroup");
            //AuthorizationRules.AllowRead("VietBangChu", "HoaDonReadGroup");
            //AuthorizationRules.AllowRead("SoTienDaThanhToan", "HoaDonReadGroup");
            //AuthorizationRules.AllowRead("SoTienConLai", "HoaDonReadGroup");
            //AuthorizationRules.AllowRead("MaDonHang", "HoaDonReadGroup");
            //AuthorizationRules.AllowRead("QuyTrinh", "HoaDonReadGroup");
            //AuthorizationRules.AllowRead("MaHopDong", "HoaDonReadGroup");
            //AuthorizationRules.AllowRead("MaSoTK", "HoaDonReadGroup");

            //AuthorizationRules.AllowWrite("LoaiHoaDon", "HoaDonWriteGroup");
            //AuthorizationRules.AllowWrite("ThueSuatVAT", "HoaDonWriteGroup");
            //AuthorizationRules.AllowWrite("MaDoiTac", "HoaDonWriteGroup");
            //AuthorizationRules.AllowWrite("MaPhieuNhapXuat", "HoaDonWriteGroup");
            //AuthorizationRules.AllowWrite("SoSerial", "HoaDonWriteGroup");
            //AuthorizationRules.AllowWrite("SoHoaDon", "HoaDonWriteGroup");
            //AuthorizationRules.AllowWrite("ThanhTien", "HoaDonWriteGroup");
            //AuthorizationRules.AllowWrite("ThueVAT", "HoaDonWriteGroup");
            //AuthorizationRules.AllowWrite("TongTien", "HoaDonWriteGroup");
            //AuthorizationRules.AllowWrite("ChietKhau", "HoaDonWriteGroup");
            //AuthorizationRules.AllowWrite("MaNguoiLap", "HoaDonWriteGroup");
            //AuthorizationRules.AllowWrite("MuaBan", "HoaDonWriteGroup");
            //AuthorizationRules.AllowWrite("NgayLapString", "HoaDonWriteGroup");
            //AuthorizationRules.AllowWrite("MaHinhThucTT", "HoaDonWriteGroup");
            //AuthorizationRules.AllowWrite("NgayHetHanTTString", "HoaDonWriteGroup");
            //AuthorizationRules.AllowWrite("MaNguoiLienLac", "HoaDonWriteGroup");
            //AuthorizationRules.AllowWrite("MaDCGuiHD", "HoaDonWriteGroup");
            //AuthorizationRules.AllowWrite("MaDienThoai", "HoaDonWriteGroup");
            //AuthorizationRules.AllowWrite("TinhTrang", "HoaDonWriteGroup");
            //AuthorizationRules.AllowWrite("VietBangChu", "HoaDonWriteGroup");
            //AuthorizationRules.AllowWrite("SoTienDaThanhToan", "HoaDonWriteGroup");
            //AuthorizationRules.AllowWrite("SoTienConLai", "HoaDonWriteGroup");
            //AuthorizationRules.AllowWrite("MaDonHang", "HoaDonWriteGroup");
            //AuthorizationRules.AllowWrite("QuyTrinh", "HoaDonWriteGroup");
            //AuthorizationRules.AllowWrite("MaHopDong", "HoaDonWriteGroup");
            //AuthorizationRules.AllowWrite("MaSoTK", "HoaDonWriteGroup");
        }


        public static bool CanGetObject()
        {
            //TODO: Define CanGetObject permission in HoaDon
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("HoaDonViewGroup"))
            //	return true;
            //return false;
        }

        public static bool CanAddObject()
        {
            //TODO: Define CanAddObject permission in HoaDon
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("HoaDonAddGroup"))
            //	return true;
            //return false;
        }

        public static bool CanEditObject()
        {
            //TODO: Define CanEditObject permission in HoaDon
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("HoaDonEditGroup"))
            //	return true;
            //return false;
        }

        public static bool CanDeleteObject()
        {
            //TODO: Define CanDeleteObject permission in HoaDon
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("HoaDonDeleteGroup"))
            //	return true;
            //return false;
        }
        #endregion //Authorization Rules

        #region Factory Methods
        private HoaDon()
        { /* require use of factory method */  }

        public static HoaDon NewHoaDon()
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a HoaDon");
            return DataPortal.Create<HoaDon>();

            //HoaDon hd = new HoaDon();
            //hd.MarkAsChild();
            //return hd;


        }

        public static HoaDon GetHoaDon(long maHoaDon)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a HoaDon");
            return DataPortal.Fetch<HoaDon>(new Criteria(maHoaDon));
        }

        public static HoaDon GetHoaDonBanRaByChungTu(long machungTu)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a HoaDon");
            return DataPortal.Fetch<HoaDon>(new CriteriaByMaChungTu(machungTu));
        }

        public static HoaDon GetHoaDon_MaHopDong_ChuaTatToan(long maHopDong)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a HoaDon");
            return DataPortal.Fetch<HoaDon>(new CriteriaByMaHopDong_ChuaTatToan(maHopDong));
        }

        public static HoaDon GetHoaDon_MaHopDong(long maHopDong)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a HoaDon");
            return DataPortal.Fetch<HoaDon>(new CriteriaByMaHopDong(maHopDong));
        }

        public static HoaDon GetHoaDonBySoHoaDon(string soHoaDon)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a HoaDon");
            return DataPortal.Fetch<HoaDon>(new CriteriaBySoHoaDon(soHoaDon));
        }

        public static void DeleteHoaDon(long maHoaDon)
        {
            if (!CanDeleteObject())
                throw new System.Security.SecurityException("User not authorized to remove a HoaDon");
            DataPortal.Delete(new Criteria(maHoaDon));
        }

        public static void DeleteHoaDon(HoaDon hoadon)
        {
            SqlTransaction tr;
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                tr = cn.BeginTransaction();
                try
                {
                    hoadon.CT_HoaDonList.Clear();
                    hoadon.CT_HoaDonList.Update(tr, hoadon);

                    hoadon.CT_HoaDonDichVuList.Clear();
                    hoadon.CT_HoaDonDichVuList.Update(tr, hoadon);
                    hoadon.CT_HoaDonBienLaiList.Clear();
                    hoadon.CT_HoaDonBienLaiList.Update(tr, hoadon);
                    hoadon.Chungtu_HoaDonList.Clear();
                    hoadon.Chungtu_HoaDonList.Update(tr, hoadon);
                    hoadon.ChungTu_HoaDonThanhToanList.Clear();
                    hoadon.ChungTu_HoaDonThanhToanList.Update(tr, hoadon);


                    using (SqlCommand cm = tr.Connection.CreateCommand())
                    {
                        cm.Transaction = tr;
                        cm.CommandType = CommandType.StoredProcedure;
                        cm.CommandText = "spd_DeletetblHoaDon";
                        cm.Parameters.AddWithValue("@MaHoaDon", hoadon.MaHoaDon);
                        cm.ExecuteNonQuery();

                    }
                    tr.Commit();
                }
                catch (SqlException ex)
                {
                    tr.Rollback();
                    throw ex;
                }
            }
        }


        public override HoaDon Save()
        {
            if (IsDeleted && !CanDeleteObject())
                throw new System.Security.SecurityException("User not authorized to remove a HoaDon");
            else if (IsNew && !CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a HoaDon");
            else if (!CanEditObject())
                throw new System.Security.SecurityException("User not authorized to update a HoaDon");

            return base.Save();
        }
        public void Save(SqlTransaction tr)
        {
            //this.RaiseListChangedEvents = false;
            //// update (thus deleting) any deleted child objects
            //foreach (DinhKhoan obj in DeletedList)
            //    obj.DeleteSelf();
            // now that they are deleted, remove them from memory too
            //DeletedList.Clear();
            // add/update any current child objects
            if (this.IsDirty)
            {
                if (this.IsNew)
                    this.Insert(tr);
                else
                    this.Update(tr);
            }

        }

        public static HoaDon NewHoaDon(byte QuyTrinh)
        {
            return new HoaDon(QuyTrinh);
        }


        public static HoaDon NewHoaDon(HopDongMuaBan hopDongMuaBan)
        {
            return new HoaDon(hopDongMuaBan);
        }

        public static HoaDon NewHoaDon(List<ChiTietBienLaiFromOtherDB> chitietbienlai)
        {
            return new HoaDon(chitietbienlai);
        }

        public static HoaDon NewHoaDon(ThanhLyTaiSan thanhlyTS)
        {
            return new HoaDon(thanhlyTS);
        }

        public static HoaDon NewHoaDon(NghiepVuDieuChuyenNgoai nghiepVuDieuChuyenNgoai)
        {
            return new HoaDon(nghiepVuDieuChuyenNgoai);
        }



        #region SoHoaDonTuDong
        public static string SoHoaDonTuDong()
        {
            string SoHoaDonLonNhat;
            int temp;
            string GiaTriTraVe;

            SoHoaDonLonNhat = SoHoaDonTuDongTang();
            if (SoHoaDonLonNhat != "")
            {
                temp = Convert.ToInt32(SoHoaDonLonNhat.Substring(4));
                temp = temp + 1;
                if (temp < 10)
                {
                    GiaTriTraVe = SoHoaDonLonNhat.Substring(0, 2) + "000" + temp.ToString();
                }
                else if (temp < 100)
                {
                    GiaTriTraVe = SoHoaDonLonNhat.Substring(0, 2) + "00" + temp.ToString();
                }
                else if (temp < 1000)
                {
                    GiaTriTraVe = SoHoaDonLonNhat.Substring(0, 2) + "0" + temp.ToString();
                }
                else
                {
                    GiaTriTraVe = SoHoaDonLonNhat.Substring(0, 2) + temp.ToString();
                }
                return GiaTriTraVe;
            }
            else
                return "";
        }
        #endregion

        #region SoSerialTuDong
        public static string SoSerialTuDong()
        {
            string SoSerialLonNhat;
            int temp;
            string GiaTriTraVe;

            SoSerialLonNhat = SoSerialTuDongTang();
            if (SoSerialLonNhat != "")
            {
                temp = Convert.ToInt32(SoSerialLonNhat.Substring(4));
                temp = temp + 1;
                if (temp < 10)
                {
                    GiaTriTraVe = SoSerialLonNhat.Substring(0, 4) + "000" + temp.ToString();
                }
                else if (temp < 100)
                {
                    GiaTriTraVe = SoSerialLonNhat.Substring(0, 4) + "00" + temp.ToString();
                }
                else if (temp < 1000)
                {
                    GiaTriTraVe = SoSerialLonNhat.Substring(0, 4) + "0" + temp.ToString();
                }
                else
                {
                    GiaTriTraVe = SoSerialLonNhat.Substring(0, 4) + temp.ToString();
                }
                return GiaTriTraVe;
            }
            else
                return "";
        }
        #endregion

        private void LoadDoiTuong()
        {
            if (_maDoiTac != 0)
            {
                DoiTuongAll doituong = DoiTuongAll.GetDoiTuongAll(_maDoiTac);
                _tenDoiTac = doituong.TenDoiTuong;
                _maSoThue = doituong.MaSoThue;
                _DiaChi = doituong.DiaChi;
            }
        }

        public static decimal GetSoTienConLaiHoaDon(long maHoaDon, long maChungTu)//M
        {
            decimal kqGiaTri = 0;

            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "Spd_GetSoTienConLaiHoaDon";
                    cm.Parameters.AddWithValue("@MaHoaDon", maHoaDon);
                    cm.Parameters.AddWithValue("@MaChungTu", maChungTu);
                    SqlParameter prmGiaTriTraVe = new SqlParameter("@GiaTriTraVe", SqlDbType.Decimal, 16);
                    prmGiaTriTraVe.Direction = ParameterDirection.Output;
                    cm.Parameters.Add(prmGiaTriTraVe);
                    cm.ExecuteNonQuery();
                    kqGiaTri = (decimal)prmGiaTriTraVe.Value;
                }
            }//us

            return kqGiaTri;

        }

        public static decimal GetSoTienConLai_HoaDonBanRa(long maHoaDon, long maChungTu, long maDoiTac)//M
        {
            decimal kqGiaTri = 0;

            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "Spd_GetSoTienConLai_HoaDonBanRa";
                    cm.Parameters.AddWithValue("@MaHoaDon", maHoaDon);
                    cm.Parameters.AddWithValue("@MaChungTu", maChungTu);
                    cm.Parameters.AddWithValue("@MaDoiTac", maDoiTac);
                    SqlParameter prmGiaTriTraVe = new SqlParameter("@GiaTriTraVe", SqlDbType.Decimal, 16);
                    prmGiaTriTraVe.Direction = ParameterDirection.Output;
                    cm.Parameters.Add(prmGiaTriTraVe);
                    cm.ExecuteNonQuery();
                    kqGiaTri = (decimal)prmGiaTriTraVe.Value;
                }
            }//us

            return kqGiaTri;

        }

        public static decimal GetSoTienDaThanhToanHoaDon(long maHoaDon, long maChungTu)//M
        {
            decimal kqGiaTri = 0;

            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "Spd_GetSoTienDaThanhToanHoaDon";
                    cm.Parameters.AddWithValue("@MaHoaDon", maHoaDon);
                    cm.Parameters.AddWithValue("@MaChungTu", maChungTu);
                    SqlParameter prmGiaTriTraVe = new SqlParameter("@GiaTriTraVe", SqlDbType.Decimal, 16);
                    prmGiaTriTraVe.Direction = ParameterDirection.Output;
                    cm.Parameters.Add(prmGiaTriTraVe);
                    cm.ExecuteNonQuery();
                    kqGiaTri = (decimal)prmGiaTriTraVe.Value;
                }
            }//us

            return kqGiaTri;

        }

        #endregion //Factory Methods

        #region Child Factory Methods
        internal static HoaDon NewHoaDonChild()
        {
            HoaDon child = new HoaDon();
            child.ValidationRules.CheckRules();
            child.MarkAsChild();
            return child;
        }

        private HoaDon(byte QuyTrinh)
        {
            this._quyTrinh = QuyTrinh;
            this.ValidationRules.CheckRules();

        }


        #region Hóa đơn hợp đồng mua bán
        private HoaDon(HopDongMuaBan HopDongMuaBan)
        {
            this._loaiHoaDon = 6;
            this._thanhTien = HopDongMuaBan.TongTien;
            this._tongTien = HopDongMuaBan.TongTien;
            this._maDoiTac = HopDongMuaBan.MaDoiTac;
            this._maHopDong = HopDongMuaBan.MaHopDong;
            //this._muaBan = true;

            this._vietBangChu = HopDongMuaBan.VietBangChu;
            this.ValidationRules.CheckRules();

        }
        #endregion

        #region New HoaDon Form BienLai
        private HoaDon(List<ChiTietBienLaiFromOtherDB> chitietbienlai)
        {
            //this._loaiHoaDon = 5;
            //foreach (ChiTietBienLaiFromOtherDB ctbienlai in bienlai.ChiTietBienLaiList)
            //{ 
            //    CT_HoaDonDichVu ct_dichvu = CT_HoaDonDichVu.NewCT_HoaDonDichVu();
            //    ct_dichvu.SoLuong = ctbienlai.SoLuong;
            //    ct_dichvu.DonGia = ctbienlai.DonGia;
            //    ct_dichvu.ThanhTien = ctbienlai.SoTien;
            //    ct_dichvu.TenHangHoaDichVu = ctbienlai.DienGiai;
            //    ct_dichvu.GhiChu = ctbienlai.GhiChu;
            //    _cT_HoaDonDichVuList.Add(ct_dichvu);
            //    _thanhTien += ctbienlai.SoTien;
            //}
            this.ValidationRules.CheckRules();

        }
        #endregion New HoaDOn Form BienLai

        #region Hóa đơn thanh lý tài sản
        private HoaDon(ThanhLyTaiSan thanhlyTS)
        {
            this._loaiHoaDon = 7;
            //0: Hóa Đơn Bán Hàng; 1: Hóa Đơn Mua Hàng; 2: Hóa Đơn Trả Hàng; 3: Hóa Đơn Nhận Hàng Trả; 4: Hóa Đơn Mua Hàng Dịch Vụ; 5: Hóa Đơn Bán Hàng Dịch Vụ, 6 Hóa Đơn Mua Tài Sản, 7 Hóa Đơn Bán Tài Sản

            this._maDoiTac = thanhlyTS.ChungTu.DoiTuong;
            this._thanhTien = thanhlyTS.ChungTu.Tien.ThanhTien;
            this._tongTien = thanhlyTS.ChungTu.Tien.ThanhTien;
            this.ValidationRules.CheckRules();

        }


        private HoaDon(NghiepVuDieuChuyenNgoai nghiepVuDieuChuyenNgoai)
        {
            this._loaiHoaDon = 8;
            //0: Hóa Đơn Bán Hàng; 1: Hóa Đơn Mua Hàng; 2: Hóa Đơn Trả Hàng; 3: Hóa Đơn Nhận Hàng Trả; 4: Hóa Đơn Mua Hàng Dịch Vụ; 5: Hóa Đơn Bán Hàng Dịch Vụ,
            // 6 Hóa Đơn Mua Tài Sản, 7 Hóa Đơn Bán Tài Sản, 8: Hóa đơn tài sản điều chuyển ngoài

            this._maDoiTac = nghiepVuDieuChuyenNgoai.ChungTu.DoiTuong;


            this._thanhTien = nghiepVuDieuChuyenNgoai.ChungTu.Tien.ThanhTien;
            this._tongTien = nghiepVuDieuChuyenNgoai.ChungTu.Tien.ThanhTien;
            this.ValidationRules.CheckRules();

        }
        #endregion

        internal static HoaDon GetHoaDon(SafeDataReader dr)
        {
            HoaDon child = new HoaDon();
            child.MarkAsChild();
            child.Fetch(dr);
            return child;
        }


        public static HoaDon GetHoaDon_New(SafeDataReader dr)
        {
            HoaDon child = new HoaDon();
            child.MarkAsChild();
            child.Fetch_New(dr);
            return child;
        }
        #endregion //Child Factory Methods

        #region Data Access
        internal static HoaDon GetHoaDonWithoutChild(SafeDataReader dr)
        {
            HoaDon child = new HoaDon();
            child.MarkAsChild();
            child.FetchWithoutChild(dr);
            return child;
        }

        #region Criteria

        [Serializable()]
        private class Criteria
        {
            public long MaHoaDon;

            public Criteria(long maHoaDon)
            {
                this.MaHoaDon = maHoaDon;
            }
        }

        [Serializable()]
        private class CriteriaByMaChungTu
        {
            public long MaChungTu;

            public CriteriaByMaChungTu(long maChungTu)
            {
                this.MaChungTu = maChungTu;
            }
        }

        private class CriteriaByMaDonHang
        {
            public long MaDonHang;

            public CriteriaByMaDonHang(long _maDonHang)
            {
                MaDonHang = _maDonHang;
            }
        }

        private class CriteriaByMaHopDong_ChuaTatToan
        {
            public long maHopDong;

            public CriteriaByMaHopDong_ChuaTatToan(long _maHopDong)
            {
                maHopDong = _maHopDong;
            }
        }

        private class CriteriaByMaHopDong
        {
            public long maHopDong;

            public CriteriaByMaHopDong(long _maHopDong)
            {
                maHopDong = _maHopDong;
            }
        }

        private class CriteriaByMaSoTK
        {
            public long maSoTK;

            public CriteriaByMaSoTK(long _maSoTK)
            {
                maSoTK = _maSoTK;
            }
        }

        private class CriteriaBySoHoaDon
        {
            public string soHoaDon;

            public CriteriaBySoHoaDon(string _soHoaDon)
            {
                soHoaDon = _soHoaDon;
            }
        }
        #endregion //Criteria

        #region Data Access - Create
        [RunLocal]
        protected override void DataPortal_Create()
        {
            ValidationRules.CheckRules();
        }

        #endregion //Data Access - Create

        #region Data Access - Fetch
        private void DataPortal_Fetch(Object criteria)
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
                catch (Exception ex)
                {
                    tr.Rollback();
                    throw ex;
                }
            }//using
        }

        private void ExecuteFetch(SqlTransaction tr, Object criteria)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                if (criteria is Criteria)
                {
                    cm.CommandText = "spd_SelecttblHoaDon";
                    cm.Parameters.AddWithValue("@MaHoaDon", ((Criteria)criteria).MaHoaDon);
                }

                else if (criteria is CriteriaByMaChungTu)
                {
                    cm.CommandText = "spd_SelecttblHoaDonBanRaByMaChungTu";
                    cm.Parameters.AddWithValue("@MaChungTu", ((CriteriaByMaChungTu)criteria).MaChungTu);
                }
                else if (criteria is CriteriaByMaHopDong)
                {
                    cm.CommandText = "spd_SelecttblHoaDonsByMaHopDong";
                    cm.Parameters.AddWithValue("@MaHopDong", ((CriteriaByMaHopDong)criteria).maHopDong);
                }
                else if (criteria is CriteriaBySoHoaDon)
                {
                    cm.CommandText = "spd_SelecttblHoaDonsBySoHoaDon";
                    cm.Parameters.AddWithValue("@SoHoaDon", ((CriteriaBySoHoaDon)criteria).soHoaDon);
                }
                using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                {
                    if (dr.Read())
                    {
                        FetchObject(dr);
                        ValidationRules.CheckRules();

                        //load child object(s)
                        FetchChildren(this.MaHoaDon);
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
                    ExecuteInsert(tr, null);

                    //update child object(s)
                    UpdateChildren(tr);

                    tr.Commit();
                }
                catch (SqlException ex)
                {
                    throw ex;
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
                        //ExecuteUpdate(tr, ChungTu._ChungTuGoc);
                        ExecuteUpdate(tr, null);
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
            DataPortal_Delete(new Criteria(_maHoaDon));
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
                cm.CommandText = "spd_DeletetblHoaDon";

                cm.Parameters.AddWithValue("@MaHoaDon", criteria.MaHoaDon);

                cm.ExecuteNonQuery();
            }//using
        }
        #endregion //Data Access - Delete

        #region Data Access - Fetch
        private void Fetch(SafeDataReader dr)
        {
            FetchObject(dr);
            MarkOld();
            //ValidationRules.CheckRules();

            //load child object(s)
            FetchChildren(this.MaHoaDon);
        }

        private void FetchWithoutChild(SafeDataReader dr)
        {
            FetchObject(dr);
            MarkOld();
        }


        private void Fetch_New(SafeDataReader dr)
        {
            FetchObject_New(dr);
            MarkOld();
            //ValidationRules.CheckRules();

            //load child object(s)
            FetchChildren(this.MaHoaDon);
        }

        private void FetchObject(SafeDataReader dr)
        {
            _maHoaDon = dr.GetInt64("MaHoaDon");
            _loaiHoaDon = dr.GetInt32("LoaiHoaDon");
            _thueSuatVAT = dr.GetDouble("ThueSuatVAT");
            _maDoiTac = dr.GetInt64("MaDoiTac");
            _maPhieuNhapXuat = dr.GetInt64("MaPhieuNhapXuat");
            _soSerial = dr.GetString("SoSerial");
            _soHoaDon = dr.GetString("SoHoaDon");
            _thanhTien = dr.GetDecimal("ThanhTien");
            _thueVAT = dr.GetDecimal("ThueVAT");
            _tongTien = dr.GetDecimal("TongTien");
            _chietKhau = dr.GetDouble("ChietKhau");

            _muaBan = dr.GetBoolean("MuaBan");
            _ngayLap = dr.GetDateTime("NgayLap");
            _maHinhThucTT = dr.GetInt32("MaHinhThucTT");
            _ngayHetHanTT = dr.GetDateTime("NgayHetHanTT");
            _maNguoiLienLac = dr.GetInt32("MaNguoiLienLac");
            _maDCGuiHD = dr.GetInt32("MaDCGuiHD");
            _maDienThoai = dr.GetInt32("MaDienThoai");
            _tinhTrang = dr.GetByte("TinhTrang");
            _vietBangChu = dr.GetString("VietBangChu");
            _soTienDaThanhToan = dr.GetDecimal("SoTienDaThanhToan");
            _soTienConLai = dr.GetDecimal("SoTienConLai");
            _maDonHang = dr.GetInt64("MaDonHang");
            _quyTrinh = dr.GetByte("QuyTrinh");
            _doiTuongMuaBan = dr.GetByte("DoiTuongMuaBan");
            _nhapXuat = dr.GetBoolean("NhapXuat");
            _maHopDong = dr.GetInt64("MaHopDong");
            _maSoTK = dr.GetInt64("MaSoTK");
            _tenDoiTac = dr.GetString("TenDoiTac");
            _maQLDoiTac = dr.GetString("MaQLDoiTac");
            _cmnd = dr.GetString("CMND");
            _tatToan = dr.GetBoolean("TatToan");
            _soTienChietKhau = dr.GetDecimal("SoTienChietKhau");
            _soTienChietKhau = dr.GetByte("LoaiUuDai");
            _chuyenCongNo = dr.GetBoolean("ChuyenCongNo");
            _khauTruThue = dr.GetBoolean("KhauTruThue");
            _ghichu = dr.GetString("GhiCHu");
            _soct_hd = dr.GetString("SoCT_HD");
            _nguyenTe = dr.GetDecimal("NguyenTe");
            _tyGia = dr.GetDecimal("TyGia");
            _maLoaiTien = dr.GetInt32("MaLoaiTien");
            _thueSuatGTGTNhaThau = dr.GetDecimal("ThueSuatGTGTNhaThau");
            _tyLeGTGT = dr.GetDecimal("TyLeGTGT");
            _thueGTGTNhaThau = dr.GetDecimal("ThueGTGTNhaThau");
            _thueSuatTNDNNhaThau = dr.GetDecimal("ThueSuatTNDNNhaThau");
            _thueTNDNNhaThau = dr.GetDecimal("ThueTNDNNhaThau");
            _thueMienGiam = dr.GetDecimal("ThueMienGiam");
            _tienThue = _thueVAT + _thueTNDNNhaThau + _thueGTGTNhaThau - _thueMienGiam;
            _mauHoaDon = dr.GetString("MauHoaDon");
            _kyHieuMauHoaDon = dr.GetString("KyHieuMauHoaDon");
            _OidBienLai = dr.GetGuid("OidBienLai");
            _IDBienLai = dr.GetInt32("IDBienLai");
            _NhomHHDVMuaVao = dr.GetByte("NhomHHDVMuaVao");
            //  if(ChungTu_HoaDon.GetChungTu_HoaDon_MaHoaDon(dr.GetInt64("MaHoaDon"))!=null)
            // _ChungTu_HoaDon = ChungTu_HoaDon.GetChungTu_HoaDon_MaHoaDon(dr.GetInt64("MaHoaDon"));
            //if (_ChungTu_HoaDon.IsValid)
            //    _check = true;
        }

        private void FetchObject_New(SafeDataReader dr)
        {
            _maHoaDon = dr.GetInt64("MaHoaDon");
            _loaiHoaDon = dr.GetInt32("LoaiHoaDon");
            _thueSuatVAT = dr.GetDouble("ThueSuatVAT");
            _maDoiTac = dr.GetInt64("MaDoiTac");
            _maPhieuNhapXuat = dr.GetInt64("MaPhieuNhapXuat");
            _soSerial = dr.GetString("SoSerial");
            _soHoaDon = dr.GetString("SoHoaDon");
            _thanhTien = dr.GetDecimal("ThanhTien");
            _thueVAT = dr.GetDecimal("ThueVAT");
            _tongTien = dr.GetDecimal("TongTien");
            _chietKhau = dr.GetDouble("ChietKhau");

            _muaBan = dr.GetBoolean("MuaBan");
            _ngayLap = dr.GetDateTime("NgayLap");
            _maHinhThucTT = dr.GetInt32("MaHinhThucTT");
            _ngayHetHanTT = dr.GetDateTime("NgayHetHanTT");
            _maNguoiLienLac = dr.GetInt32("MaNguoiLienLac");
            _maDCGuiHD = dr.GetInt32("MaDCGuiHD");
            _maDienThoai = dr.GetInt32("MaDienThoai");
            _tinhTrang = dr.GetByte("TinhTrang");
            _vietBangChu = dr.GetString("VietBangChu");
            _soTienDaThanhToan = dr.GetDecimal("SoTienDaThanhToan");
            _soTienConLai = dr.GetDecimal("SoTienConLai");
            _maDonHang = dr.GetInt64("MaDonHang");
            _quyTrinh = dr.GetByte("QuyTrinh");
            _doiTuongMuaBan = dr.GetByte("DoiTuongMuaBan");
            _nhapXuat = dr.GetBoolean("NhapXuat");
            _maHopDong = dr.GetInt64("MaHopDong");
            _maSoTK = dr.GetInt64("MaSoTK");
            _tenDoiTac = dr.GetString("TenDoiTac");
            _maQLDoiTac = dr.GetString("MaQLDoiTac");
            _cmnd = dr.GetString("CMND");
            _tatToan = dr.GetBoolean("TatToan");
            _soTienChietKhau = dr.GetDecimal("SoTienChietKhau");
            _soTienChietKhau = dr.GetByte("LoaiUuDai");
            _chuyenCongNo = dr.GetBoolean("ChuyenCongNo");
            _khauTruThue = dr.GetBoolean("KhauTruThue");
            _ghichu = dr.GetString("GhiCHu");
            _soct_hd = dr.GetString("SoCT_HD");
            _soChungTu = dr.GetString("SoChungTu");
            _ngayLapCT = dr.GetDateTime("NgayLapChungTu");
            _nguyenTe = dr.GetDecimal("NguyenTe");
            _tyGia = dr.GetDecimal("TyGia");
            _maLoaiTien = dr.GetInt32("MaLoaiTien");
            _thueSuatGTGTNhaThau = dr.GetDecimal("ThueSuatGTGTNhaThau");
            _tyLeGTGT = dr.GetDecimal("TyLeGTGT");
            _thueGTGTNhaThau = dr.GetDecimal("ThueGTGTNhaThau");
            _thueSuatTNDNNhaThau = dr.GetDecimal("ThueSuatTNDNNhaThau");
            _thueTNDNNhaThau = dr.GetDecimal("ThueTNDNNhaThau");
            _thueMienGiam = dr.GetDecimal("ThueMienGiam");
            _tienThue = _thueVAT + _thueTNDNNhaThau + _thueGTGTNhaThau - _thueMienGiam;
            _maChungTu_CongNo = dr.GetInt64("MaChungTu_CongNo");
            _maChungTu_ThanhToan = dr.GetInt64("MaChungTu_ThanhToan");
            _maLoaiChungTu_CongNo = dr.GetInt32("MaLoaiChungTu_CongNo");
            _maLoaiChungTu_ThanhToan = dr.GetInt32("MaLoaiChungTu_ThanhToan");
            _soTienThanhToan = dr.GetDecimal("SoTienThanhToan");
            _soChungTu_ThanhToan = dr.GetString("SoChungTu_ThanhToan");
        }

        private void FetchChildren(long MaHoaDon)
        {
            _cT_HoaDonList = CT_HoaDonList.GetCT_HoaDonList(MaHoaDon);

            _cT_HoaDonDichVuList = CT_HoaDonDichVuList.GetCT_HoaDonDichVuList(MaHoaDon);
            _CT_HoaDonBienLaiList = CT_HoaDonBienLaiChildList.GetCT_HoaDonBienLaiChildList(MaHoaDon);
            if (_loaiHoaDon == 5)//La Hoa Don Ban Hang
            {
                _ChungTu_HoaDonList = ChungTu_HoaDonList.GetChungTu_HoaDonByMaHoaDonList(MaHoaDon);
                _ChungTu_HoaDonThanhToanList = ChungTu_HoaDonThanhToanChildList.GetChungTu_HoaDonThanhToanChildListByChungTu(MaHoaDon);
            }
        }
        #endregion //Data Access - Fetch

        #region Data Access - Insert
        internal void Insert(SqlTransaction tr, HoaDonList parent)
        {
            if (!IsDirty) return;

            ExecuteInsert(tr, parent);
            MarkOld();

            //update child object(s)
            UpdateChildren(tr);
        }

        internal void Insert(SqlTransaction tr)
        {
            if (!IsDirty) return;

            ExecuteInsert(tr);
            MarkOld();

            //update child object(s)
            UpdateChildren(tr);
        }

        private void ExecuteInsert(SqlTransaction tr, HoaDonList parent)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_InserttblHoaDon";

                AddInsertParameters(cm);

                cm.ExecuteNonQuery();

                _maHoaDon = Convert.ToInt64(cm.Parameters["@MaHoaDon"].Value);
                if (_check == true)
                {
                    //_ChungTu_HoaDon = ChungTu_HoaDon.NewChungTu_HoaDon(parent._MaChungTu, _maHoaDon, _soTienDaThanhToan);
                    //_ChungTu_HoaDon.Insert(tr, null);
                }
            }//using
        }

        private void ExecuteInsert(SqlTransaction tr)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_InserttblHoaDon";

                AddInsertParameters(cm);

                cm.ExecuteNonQuery();

                _maHoaDon = Convert.ToInt64(cm.Parameters["@MaHoaDon"].Value);
            }//using
        }

        private void AddInsertParameters(SqlCommand cm)
        {
            cm.Parameters.AddWithValue("@LoaiHoaDon", _loaiHoaDon);
            cm.Parameters.AddWithValue("@ThueSuatVAT", _thueSuatVAT);
            if (_maDoiTac != 0)
                cm.Parameters.AddWithValue("@MaDoiTac", _maDoiTac);
            else
                cm.Parameters.AddWithValue("@MaDoiTac", DBNull.Value);
            if (_maPhieuNhapXuat != 0)
                cm.Parameters.AddWithValue("@MaPhieuNhapXuat", _maPhieuNhapXuat);
            else
                cm.Parameters.AddWithValue("@MaPhieuNhapXuat", DBNull.Value);
            cm.Parameters.AddWithValue("@SoSerial", _soSerial);
            cm.Parameters.AddWithValue("@SoHoaDon", _soHoaDon);
            cm.Parameters.AddWithValue("@ThanhTien", _thanhTien);
            cm.Parameters.AddWithValue("@ThueVAT", _thueVAT);
            cm.Parameters.AddWithValue("@TongTien", _tongTien);
            if (_chietKhau != 0)
                cm.Parameters.AddWithValue("@ChietKhau", _chietKhau);
            else
                cm.Parameters.AddWithValue("@ChietKhau", DBNull.Value);
            if (_maNguoiLap != 0)
                cm.Parameters.AddWithValue("@MaNguoiLap", _maNguoiLap);
            else
                cm.Parameters.AddWithValue("@MaNguoiLap", DBNull.Value);
            if (_muaBan != false)
                cm.Parameters.AddWithValue("@MuaBan", _muaBan);
            else
                cm.Parameters.AddWithValue("@MuaBan", DBNull.Value);
            cm.Parameters.AddWithValue("@NgayLap", _ngayLap.Date);
            if (_maHinhThucTT != 0)
                cm.Parameters.AddWithValue("@MaHinhThucTT", _maHinhThucTT);
            else
                cm.Parameters.AddWithValue("@MaHinhThucTT", DBNull.Value);
            cm.Parameters.AddWithValue("@NgayHetHanTT", _ngayHetHanTT.Date);
            if (_maNguoiLienLac != 0)
                cm.Parameters.AddWithValue("@MaNguoiLienLac", _maNguoiLienLac);
            else
                cm.Parameters.AddWithValue("@MaNguoiLienLac", DBNull.Value);
            if (_maDCGuiHD != 0)
                cm.Parameters.AddWithValue("@MaDCGuiHD", _maDCGuiHD);
            else
                cm.Parameters.AddWithValue("@MaDCGuiHD", DBNull.Value);
            if (_maDienThoai != 0)
                cm.Parameters.AddWithValue("@MaDienThoai", _maDienThoai);
            else
                cm.Parameters.AddWithValue("@MaDienThoai", DBNull.Value);
            cm.Parameters.AddWithValue("@TinhTrang", _tinhTrang);
            if (_vietBangChu.Length > 0)
                cm.Parameters.AddWithValue("@VietBangChu", _vietBangChu);
            else
                cm.Parameters.AddWithValue("@VietBangChu", DBNull.Value);
            cm.Parameters.AddWithValue("@SoTienDaThanhToan", _soTienDaThanhToan);
            //cm.Parameters.AddWithValue("@SoTienConLai", _soTienConLai);
            cm.Parameters.AddWithValue("@SoTienConLai", _tongTien);
            if (_maDonHang != 0)
                cm.Parameters.AddWithValue("@MaDonHang", _maDonHang);
            else
                cm.Parameters.AddWithValue("@MaDonHang", DBNull.Value);
            cm.Parameters.AddWithValue("@QuyTrinh", _quyTrinh);
            cm.Parameters.AddWithValue("@DoiTuongMuaBan", _doiTuongMuaBan);
            cm.Parameters.AddWithValue("@NhapXuat", _nhapXuat);
            if (_maHopDong != 0)
                cm.Parameters.AddWithValue("@MaHopDong", _maHopDong);
            else
                cm.Parameters.AddWithValue("@MaHopDong", DBNull.Value);
            if (_maSoTK != 0)
                cm.Parameters.AddWithValue("@MaSoTK", _maSoTK);
            else
                cm.Parameters.AddWithValue("@MaSoTK", DBNull.Value);
            cm.Parameters.AddWithValue("@TatToan", _tatToan);
            cm.Parameters.AddWithValue("@SoTienChietKhau", _soTienChietKhau);
            if (_loaiUuDai != 0)
                cm.Parameters.AddWithValue("@LoaiUuDai", _loaiUuDai);
            else
                cm.Parameters.AddWithValue("@LoaiUuDai", DBNull.Value);
            cm.Parameters.AddWithValue("@ChiHoaHong", _chiHoaHong);
            cm.Parameters.AddWithValue("@KhauTruThue", _khauTruThue);
            cm.Parameters.AddWithValue("@Ghichu", _ghichu);

            cm.Parameters.AddWithValue("@Mabophan", Security.CurrentUser.Info.MaBoPhan);
            cm.Parameters.AddWithValue("@Tenbophan", Security.CurrentUser.Info.TenBoPhan);
            cm.Parameters.AddWithValue("@NgayTao", DateTime.Now.Date);
            cm.Parameters.AddWithValue("@NguyenTe", _nguyenTe);
            cm.Parameters.AddWithValue("@TyGia", _tyGia);
            cm.Parameters.AddWithValue("@MaLoaiTien", _maLoaiTien);
            cm.Parameters.AddWithValue("@ThueSuatGTGTNhaThau", _thueSuatGTGTNhaThau);
            cm.Parameters.AddWithValue("@TyLeGTGT", _tyLeGTGT);
            cm.Parameters.AddWithValue("@ThueGTGTNhaThau", _thueGTGTNhaThau);
            cm.Parameters.AddWithValue("@ThueSuatTNDNNhaThau", _thueSuatTNDNNhaThau);
            cm.Parameters.AddWithValue("@ThueTNDNNhaThau", _thueTNDNNhaThau);
            cm.Parameters.AddWithValue("@ThueMienGiam", _thueMienGiam);
            cm.Parameters.AddWithValue("@MauHoaDon", _mauHoaDon);
            cm.Parameters.AddWithValue("@KyHieuMauHoaDon", _kyHieuMauHoaDon);
            if (_OidBienLai != Guid.Empty)
                cm.Parameters.AddWithValue("@OidBienLai", _OidBienLai);
            else
                cm.Parameters.AddWithValue("@OidBienLai", DBNull.Value);

            if (_IDBienLai != 0)
                cm.Parameters.AddWithValue("@IDBienLai", _IDBienLai);
            else
                cm.Parameters.AddWithValue("@IDBienLai", DBNull.Value);

            if (_NhomHHDVMuaVao != 0)
                cm.Parameters.AddWithValue("@NhomHHDVMuaVao", _NhomHHDVMuaVao);
            else
                cm.Parameters.AddWithValue("@NhomHHDVMuaVao", DBNull.Value);

            cm.Parameters.AddWithValue("@MaHoaDon", _maHoaDon);
            cm.Parameters["@MaHoaDon"].Direction = ParameterDirection.Output;
        }
        #endregion //Data Access - Insert

        #region Data Access - Update
        internal void Update(SqlTransaction tr, HoaDonList parent)
        {
            ///if (!IsDirty) return;

            //	if (base.IsDirty)
            //	{
            ExecuteUpdate(tr, parent);
            MarkOld();
            //}

            //update child object(s)
            UpdateChildren(tr);
        }

        internal void Update(SqlTransaction tr)
        {
            ///if (!IsDirty) return;

            //	if (base.IsDirty)
            //	{
            ExecuteUpdate(tr);
            MarkOld();
            //}

            //update child object(s)
            UpdateChildren(tr);
        }

        private void ExecuteUpdate(SqlTransaction tr, HoaDonList parent)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_UpdatetblHoaDon";

                AddUpdateParameters(cm);

                cm.ExecuteNonQuery();
                //if (_check == true)
                //{
                //if (parent != null)
                //{
                //    for (int i = 0; i < parent.Count; i++)
                //    {
                //        if (parent[i].ChungTu_HoaDon.MaHoaDon != 0)
                //        {
                //            if (parent[i].ChungTu_HoaDon.IsNew == true)
                //            {
                //                //parent[i].ChungTu_HoaDon = ChungTu_HoaDon.NewChungTu_HoaDon(parent._MaChungTu, _maHoaDon, _soTienTucThoi);
                //                //  parent[i].ChungTu_HoaDon.Insert(tr, null);
                //            }
                //            else if (parent[i].ChungTu_HoaDon.IsDirty == true)
                //            {
                //                // parent[i].ChungTu_HoaDon.Update(tr, null);
                //            }
                //        }
                //    }

                //}
                //}
                //_ChungTu_HoaDonList.DataPortal_Update(tr);

            }//using
        }

        private void ExecuteUpdate(SqlTransaction tr)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_UpdatetblHoaDon";

                AddUpdateParameters(cm);

                cm.ExecuteNonQuery();

            }//using
        }


        private void AddUpdateParameters(SqlCommand cm)
        {
            if (_maHopDong != 0)
                cm.Parameters.AddWithValue("@MaHopDong", _maHopDong);
            else
                cm.Parameters.AddWithValue("@MaHopDong", DBNull.Value);
            if (_maSoTK != 0)
                cm.Parameters.AddWithValue("@MaSoTK", _maSoTK);
            else
                cm.Parameters.AddWithValue("@MaSoTK", DBNull.Value);
            cm.Parameters.AddWithValue("@MaHoaDon", _maHoaDon);
            cm.Parameters.AddWithValue("@LoaiHoaDon", _loaiHoaDon);
            cm.Parameters.AddWithValue("@ThueSuatVAT", _thueSuatVAT);
            if (_maDoiTac != 0)
                cm.Parameters.AddWithValue("@MaDoiTac", _maDoiTac);
            else
                cm.Parameters.AddWithValue("@MaDoiTac", DBNull.Value);
            if (_maPhieuNhapXuat != 0)
                cm.Parameters.AddWithValue("@MaPhieuNhapXuat", _maPhieuNhapXuat);
            else
                cm.Parameters.AddWithValue("@MaPhieuNhapXuat", DBNull.Value);
            cm.Parameters.AddWithValue("@SoSerial", _soSerial);
            cm.Parameters.AddWithValue("@SoHoaDon", _soHoaDon);
            cm.Parameters.AddWithValue("@ThanhTien", _thanhTien);
            cm.Parameters.AddWithValue("@ThueVAT", _thueVAT);
            cm.Parameters.AddWithValue("@TongTien", _tongTien);
            if (_chietKhau != 0)
                cm.Parameters.AddWithValue("@ChietKhau", _chietKhau);
            else
                cm.Parameters.AddWithValue("@ChietKhau", DBNull.Value);
            if (_maNguoiLap != 0)
                cm.Parameters.AddWithValue("@MaNguoiLap", _maNguoiLap);
            else
                cm.Parameters.AddWithValue("@MaNguoiLap", DBNull.Value);
            if (_muaBan != false)
                cm.Parameters.AddWithValue("@MuaBan", _muaBan);
            else
                cm.Parameters.AddWithValue("@MuaBan", DBNull.Value);
            cm.Parameters.AddWithValue("@NgayLap", _ngayLap.Date);
            if (_maHinhThucTT != 0)
                cm.Parameters.AddWithValue("@MaHinhThucTT", _maHinhThucTT);
            else
                cm.Parameters.AddWithValue("@MaHinhThucTT", DBNull.Value);

            if (_ngayHetHanTT.Year >= 1900)
                cm.Parameters.AddWithValue("@NgayHetHanTT", _ngayHetHanTT.Date);
            else
                cm.Parameters.AddWithValue("@NgayHetHanTT", DBNull.Value);

            if (_maNguoiLienLac != 0)
                cm.Parameters.AddWithValue("@MaNguoiLienLac", _maNguoiLienLac);
            else
                cm.Parameters.AddWithValue("@MaNguoiLienLac", DBNull.Value);
            if (_maDCGuiHD != 0)
                cm.Parameters.AddWithValue("@MaDCGuiHD", _maDCGuiHD);
            else
                cm.Parameters.AddWithValue("@MaDCGuiHD", DBNull.Value);
            if (_maDienThoai != 0)
                cm.Parameters.AddWithValue("@MaDienThoai", _maDienThoai);
            else
                cm.Parameters.AddWithValue("@MaDienThoai", DBNull.Value);
            cm.Parameters.AddWithValue("@TinhTrang", _tinhTrang);
            if (_vietBangChu.Length > 0)
                cm.Parameters.AddWithValue("@VietBangChu", _vietBangChu);
            else
                cm.Parameters.AddWithValue("@VietBangChu", DBNull.Value);
            cm.Parameters.AddWithValue("@SoTienDaThanhToan", _soTienDaThanhToan);
            cm.Parameters.AddWithValue("@SoTienConLai", _soTienConLai);
            if (_maDonHang != 0)
                cm.Parameters.AddWithValue("@MaDonHang", _maDonHang);
            else
                cm.Parameters.AddWithValue("@MaDonHang", DBNull.Value);
            cm.Parameters.AddWithValue("@QuyTrinh", _quyTrinh);
            cm.Parameters.AddWithValue("@DoiTuongMuaBan", _doiTuongMuaBan);
            cm.Parameters.AddWithValue("@NhapXuat", _nhapXuat);
            cm.Parameters.AddWithValue("@TatToan", _tatToan);
            cm.Parameters.AddWithValue("@SoTienChietKhau", _soTienChietKhau);
            if (_loaiUuDai != 0)
                cm.Parameters.AddWithValue("@LoaiUuDai", _loaiUuDai);
            else
                cm.Parameters.AddWithValue("@LoaiUuDai", DBNull.Value);
            cm.Parameters.AddWithValue("@ChiHoaHong", _chiHoaHong);
            cm.Parameters.AddWithValue("@ChuyenCongNo", _chuyenCongNo);
            cm.Parameters.AddWithValue("@KhauTruThue", _khauTruThue);
            cm.Parameters.AddWithValue("@Ghichu", _ghichu);
            cm.Parameters.AddWithValue("@NguyenTe", _nguyenTe);
            cm.Parameters.AddWithValue("@TyGia", _tyGia);
            cm.Parameters.AddWithValue("@Mabophan", Security.CurrentUser.Info.MaBoPhan);
            cm.Parameters.AddWithValue("@Tenbophan", Security.CurrentUser.Info.TenBoPhan);
            cm.Parameters.AddWithValue("@MaLoaiTien", _maLoaiTien);
            cm.Parameters.AddWithValue("@ThueSuatGTGTNhaThau", _thueSuatGTGTNhaThau);
            cm.Parameters.AddWithValue("@TyLeGTGT", _tyLeGTGT);
            cm.Parameters.AddWithValue("@ThueGTGTNhaThau", _thueGTGTNhaThau);
            cm.Parameters.AddWithValue("@ThueSuatTNDNNhaThau", _thueSuatTNDNNhaThau);
            cm.Parameters.AddWithValue("@ThueTNDNNhaThau", _thueTNDNNhaThau);
            cm.Parameters.AddWithValue("@ThueMienGiam", _thueMienGiam);
            cm.Parameters.AddWithValue("@MauHoaDon", _mauHoaDon);
            cm.Parameters.AddWithValue("@KyHieuMauHoaDon", _kyHieuMauHoaDon);
            if (_OidBienLai != Guid.Empty)
                cm.Parameters.AddWithValue("@OidBienLai", _OidBienLai);
            else
                cm.Parameters.AddWithValue("@OidBienLai", DBNull.Value);

            if (_IDBienLai != 0)
                cm.Parameters.AddWithValue("@IDBienLai", _IDBienLai);
            else
                cm.Parameters.AddWithValue("@IDBienLai", DBNull.Value);

            if (_NhomHHDVMuaVao != 0)
                cm.Parameters.AddWithValue("@NhomHHDVMuaVao", _NhomHHDVMuaVao);
            else
                cm.Parameters.AddWithValue("@NhomHHDVMuaVao", DBNull.Value);
        }

        private void UpdateChildren(SqlTransaction tr)
        {
            _cT_HoaDonList.Update(tr, this);
            _cT_HoaDonDichVuList.Update(tr, this);
            _CT_HoaDonBienLaiList.Update(tr, this);
            if (_loaiHoaDon == 5)   //ban ra
            {
                _ChungTu_HoaDonList.Update(tr, this);
                _ChungTu_HoaDonThanhToanList.Update(tr, this);
            }
            //HoaDon_DoiTac.s.Update(tr, this);
        }
        #endregion //Data Access - Update

        #region Data Access - Delete
        internal void DeleteSelf(SqlTransaction tr)
        {
            //if (!IsDirty) return;
            if (IsNew) return;

            //neu xoa hoa don ba ra xoa luon chung tu doanh thu cua hoa don do
            ChungTu ct = ChungTu.NewChungTu();
            if (_loaiHoaDon == 5) //ban ra
            {
                ChungTu_HoaDonThanhToanChildList list = ChungTu_HoaDonThanhToanChildList.GetChungTu_HoaDonThanhToanChildListByHoaDon(_maHoaDon);
                foreach (ChungTu_HoaDonThanhToan obj in list)
                {
                    ChungTuList listCT = ChungTuList.GetChungTuListByMaChungTu_New(obj.MaChungTu);

                    if (listCT.Count > 0)
                    {
                        ct = listCT[0];

                        if (ct.LoaiChungTu.MaLoaiCT == 16) //chung tu doanh thu 
                            break;
                    }

                }
            }

            _cT_HoaDonList.Clear();
            _cT_HoaDonDichVuList.Clear();
            _CT_HoaDonBienLaiList.Clear();
            _ChungTu_HoaDonList.Clear();
            _ChungTu_HoaDonThanhToanList.Clear();
            UpdateChildren(tr);
            ExecuteDelete(tr, new Criteria(_maHoaDon));

            //xoa chung tu doanh thu
            if (_loaiHoaDon == 5)
            {
                if (ct.LoaiChungTu != null && ct.LoaiChungTu.MaLoaiCT == 16)
                {
                    ChungTu.DeleteChungTu_ByDeleteHoaDon(ct, tr);
                }
            }

            MarkNew();
        }
        #endregion //Data Access - Delete
        #endregion //Data Access

        #region Kiểm Tra
        internal static string SoHoaDonTuDongTang()
        {
            string giaTriTraVe = string.Empty;
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_GetSoHoaDonLonNhat";
                    SqlParameter prmGiaTriTraVe = new SqlParameter("@GiaTriTraVe", SqlDbType.VarChar, 30);
                    prmGiaTriTraVe.Direction = ParameterDirection.Output;
                    cm.Parameters.Add(prmGiaTriTraVe);
                    cm.ExecuteNonQuery();
                    giaTriTraVe = (string)prmGiaTriTraVe.Value;
                }
            }//us
            return giaTriTraVe;
        }

        internal static string SoSerialTuDongTang()
        {
            string giaTriTraVe = string.Empty;
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_GetSoSerialLonNhat";
                    SqlParameter prmGiaTriTraVe = new SqlParameter("@GiaTriTraVe", SqlDbType.VarChar, 30);
                    prmGiaTriTraVe.Direction = ParameterDirection.Output;
                    cm.Parameters.Add(prmGiaTriTraVe);
                    cm.ExecuteNonQuery();
                    giaTriTraVe = (string)prmGiaTriTraVe.Value;
                }
            }//us
            return giaTriTraVe;
        }

        public static int KiemTraHoaDon(string SoHoaDon, string SoSerial, Int64 MaDoiTac, decimal SoTien, int Nam)
        {
            int giaTriTraVe = 0;
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_KiemTraHoaDon";
                    cm.Parameters.AddWithValue("@SoHoaDon", SoHoaDon);
                    cm.Parameters.AddWithValue("@SoSerial", SoSerial);
                    cm.Parameters.AddWithValue("@MaDoiTac", MaDoiTac);
                    cm.Parameters.AddWithValue("@SoTien", SoTien);
                    cm.Parameters.AddWithValue("@Nam", Nam);
                    giaTriTraVe = (int)cm.ExecuteScalar();

                }
            }//us
            return giaTriTraVe;
        }

        public static int KiemTraTrungSoHoaDon(string soHoaDon, string mauHoaDon, string kyHieuMauHoaDon, Int64 maHoaDon, DateTime ngayHoaDon,string soSerial, Int64 maChungTu)
        {
            int giaTriTraVe = 0;
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_KiemTraTrungHoaDon";
                    cm.Parameters.AddWithValue("@SoHoaDon", soHoaDon);
                    cm.Parameters.AddWithValue("@MauHoaDon", mauHoaDon);
                    cm.Parameters.AddWithValue("@KyHieuMauHoaDon", kyHieuMauHoaDon);
                    cm.Parameters.AddWithValue("@MaHoaDon", maHoaDon);
                    cm.Parameters.AddWithValue("@NgayHoaDon", ngayHoaDon);
                    cm.Parameters.AddWithValue("@soSerial", soSerial);
                    cm.Parameters.AddWithValue("@maChungTu", maChungTu);
                    giaTriTraVe = (int)cm.ExecuteScalar();

                }
            }//us
            return giaTriTraVe;
        }

        public static int KiemTraTrungSoHoaDonTheoDoiTac(string soHoaDon, Int64 maHoaDon, Int64 maDoiTac)
        {
            int giaTriTraVe = 0;
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_KiemTraTrungHoaDonTheoDoiTac";
                    cm.Parameters.AddWithValue("@SoHoaDon", soHoaDon);
                    cm.Parameters.AddWithValue("@maDoiTac", maDoiTac);
                    cm.Parameters.AddWithValue("@MaHoaDon", maHoaDon);
                    giaTriTraVe = (int)cm.ExecuteScalar();

                }
            }//us
            return giaTriTraVe;
        }

        #endregion
        public static HoaDon NewHoaDon(string p)
        {
            HoaDon hd = new HoaDon();
            hd.SoHoaDon = p;
            return hd;
        }

        #region kiem tra hoa don da duoc chon len bang ke hay chua
        public static bool IsHoaDonDaChonLenBangKe(long MaHoaDon)
        {
            int giaTriTraVe = 0;
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_IsHoaDonDaChonLenBangKe";
                    cm.Parameters.AddWithValue("@MaHoaDon", MaHoaDon);                   
                    giaTriTraVe = (int)cm.ExecuteScalar();

                }
            }//us
            if (giaTriTraVe == 0)
                return false;
            else
                return true;
        }
        #endregion

    }

}
