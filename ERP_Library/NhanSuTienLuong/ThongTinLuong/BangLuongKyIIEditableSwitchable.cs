
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{
    [Serializable()]
    public class BangLuongKyII : Csla.BusinessBase<BangLuongKyII>
    {
        #region Business Properties and Methods

        //declare members
        private int _maChiTiet = 0;
        private int _maKyTinhLuong = 0;
        private long _maNhanVien = 0;
        private int _maBoPhan = 0;
        private int _thanhToan = 0;
        private string _soTaiKhoan = string.Empty;
        private string _cmnd = string.Empty;
        private int _maNganHang = 0;
        private int _loaiNV = 0;
        private string _maNgachLuong = string.Empty;
        private decimal _heSoCoBan = 0;
        private decimal _heSoBaoHiem = 0;
        private decimal _heSoNoiBo = 0;
        private decimal _phanTramVuotKhung = 0;
        private decimal _heSoVuotKhung = 0;
        private decimal _heSoPhuCap = 0;
        private decimal _heSoDocHai = 0;
        private decimal _heSoBu = 0;
        private decimal _heSoBoSung = 0;
        private bool _phuCapHanhChinh = false;
        private decimal _luongKhoan = 0;
        private decimal _phanTramNhan = 0;
        private decimal _luongNoiBo = 0;
        private decimal _luongCoBanNN = 0;
        private decimal _donGiaThamNien = 0;
        private int _soNamThamNien = 0;
        private decimal _luongThamNien = 0;
        private decimal _heSoLuong = 0;
        private decimal _luongHeSo = 0;
        private decimal _luongKy1 = 0;
        private decimal _thuLao = 0;
        private decimal _phuCap = 0;
        private decimal _khenThuong = 0;
        private decimal _khac = 0;
        private decimal _tongThuNhap = 0;
        private decimal _giamTruTinhThue = 0;
        private int _soNguoiPhuThuoc = 0;
        private decimal _thueTNCN = 0;
        private decimal _thueDaTamThu = 0;
        private bool _truThueTNCN = false;
        private decimal _cacKhoanDaLinh = 0;
        private decimal _congKhac = 0;
        private decimal _thucLanh = 0;
        private string _kyHieu = string.Empty;
        private int _khoanNghiSongay = 0;
        private decimal _khoanNghiLuong = 0;
        private int _khoanBhxhSongay = 0;
        private decimal _khoanBhxhLuong = 0;
        private decimal _khoanTruBhxh = 0;
        private decimal _khoanTruBhyt = 0;
        private decimal _khoanTruBhtn = 0;
        private decimal _khoanTruCong = 0;
        private decimal _khoanThuclanh = 0;
        private decimal _tongThuNhapTinhThue = 0;
        private decimal _phuCapTinhThue = 0;
        private decimal _khenThuongTinhThue = 0;
        private decimal _khacTinhThue = 0;
        private decimal _phanTramVuotKhungBH = 0;
        private decimal _heSoVuotKhungBH = 0;
        private decimal _thuLaoTinhThue = 0;
        private decimal _truCongdoan = 0;
        private SmartDate _ngayBDTinhLuong = new SmartDate(false);
        private SmartDate _ngayKTTinhLuong = new SmartDate(false);
        private long _maPhieuChi = 0;
        private decimal _phanTramThue = 0;
        private long _maDeNghi = 0;

        [System.ComponentModel.DataObjectField(true, true)]
        public int MaChiTiet
        {
            get
            {
                CanReadProperty("MaChiTiet", true);
                return _maChiTiet;
            }
        }

        public int MaKyTinhLuong
        {
            get
            {
                CanReadProperty("MaKyTinhLuong", true);
                return _maKyTinhLuong;
            }
            set
            {
                CanWriteProperty("MaKyTinhLuong", true);
                if (!_maKyTinhLuong.Equals(value))
                {
                    _maKyTinhLuong = value;
                    PropertyHasChanged("MaKyTinhLuong");
                }
            }
        }

        public long MaNhanVien
        {
            get
            {
                CanReadProperty("MaNhanVien", true);
                return _maNhanVien;
            }
            set
            {
                CanWriteProperty("MaNhanVien", true);
                if (!_maNhanVien.Equals(value))
                {
                    _maNhanVien = value;
                    PropertyHasChanged("MaNhanVien");
                }
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

        public int ThanhToan
        {
            get
            {
                CanReadProperty("ThanhToan", true);
                return _thanhToan;
            }
            set
            {
                CanWriteProperty("ThanhToan", true);
                if (!_thanhToan.Equals(value))
                {
                    _thanhToan = value;
                    PropertyHasChanged("ThanhToan");
                }
            }
        }

        public string SoTaiKhoan
        {
            get
            {
                CanReadProperty("SoTaiKhoan", true);
                return _soTaiKhoan;
            }
            set
            {
                CanWriteProperty("SoTaiKhoan", true);
                if (value == null) value = string.Empty;
                if (!_soTaiKhoan.Equals(value))
                {
                    _soTaiKhoan = value;
                    PropertyHasChanged("SoTaiKhoan");
                }
            }
        }

        public string Cmnd
        {
            get
            {
                CanReadProperty("Cmnd", true);
                return _cmnd;
            }
            set
            {
                CanWriteProperty("Cmnd", true);
                if (value == null) value = string.Empty;
                if (!_cmnd.Equals(value))
                {
                    _cmnd = value;
                    PropertyHasChanged("Cmnd");
                }
            }
        }

        public int MaNganHang
        {
            get
            {
                CanReadProperty("MaNganHang", true);
                return _maNganHang;
            }
            set
            {
                CanWriteProperty("MaNganHang", true);
                if (!_maNganHang.Equals(value))
                {
                    _maNganHang = value;
                    PropertyHasChanged("MaNganHang");
                }
            }
        }

        public int LoaiNV
        {
            get
            {
                CanReadProperty("LoaiNV", true);
                return _loaiNV;
            }
            set
            {
                CanWriteProperty("LoaiNV", true);
                if (!_loaiNV.Equals(value))
                {
                    _loaiNV = value;
                    PropertyHasChanged("LoaiNV");
                }
            }
        }

        public string MaNgachLuong
        {
            get
            {
                CanReadProperty("MaNgachLuong", true);
                return _maNgachLuong;
            }
            set
            {
                CanWriteProperty("MaNgachLuong", true);
                if (value == null) value = string.Empty;
                if (!_maNgachLuong.Equals(value))
                {
                    _maNgachLuong = value;
                    PropertyHasChanged("MaNgachLuong");
                }
            }
        }

        public decimal HeSoCoBan
        {
            get
            {
                CanReadProperty("HeSoCoBan", true);
                return _heSoCoBan;
            }
            set
            {
                CanWriteProperty("HeSoCoBan", true);
                if (!_heSoCoBan.Equals(value))
                {
                    _heSoCoBan = value;
                    PropertyHasChanged("HeSoCoBan");
                }
            }
        }

        public decimal HeSoBaoHiem
        {
            get
            {
                CanReadProperty("HeSoBaoHiem", true);
                return _heSoBaoHiem;
            }
            set
            {
                CanWriteProperty("HeSoBaoHiem", true);
                if (!_heSoBaoHiem.Equals(value))
                {
                    _heSoBaoHiem = value;
                    PropertyHasChanged("HeSoBaoHiem");
                }
            }
        }

        public decimal HeSoNoiBo
        {
            get
            {
                CanReadProperty("HeSoNoiBo", true);
                return _heSoNoiBo;
            }
            set
            {
                CanWriteProperty("HeSoNoiBo", true);
                if (!_heSoNoiBo.Equals(value))
                {
                    _heSoNoiBo = value;
                    PropertyHasChanged("HeSoNoiBo");
                }
            }
        }

        public decimal PhanTramVuotKhung
        {
            get
            {
                CanReadProperty("PhanTramVuotKhung", true);
                return _phanTramVuotKhung;
            }
            set
            {
                CanWriteProperty("PhanTramVuotKhung", true);
                if (!_phanTramVuotKhung.Equals(value))
                {
                    _phanTramVuotKhung = value;
                    PropertyHasChanged("PhanTramVuotKhung");
                }
            }
        }

        public decimal HeSoVuotKhung
        {
            get
            {
                CanReadProperty("HeSoVuotKhung", true);
                return _heSoVuotKhung;
            }
            set
            {
                CanWriteProperty("HeSoVuotKhung", true);
                if (!_heSoVuotKhung.Equals(value))
                {
                    _heSoVuotKhung = value;
                    PropertyHasChanged("HeSoVuotKhung");
                }
            }
        }

        public decimal HeSoPhuCap
        {
            get
            {
                CanReadProperty("HeSoPhuCap", true);
                return _heSoPhuCap;
            }
            set
            {
                CanWriteProperty("HeSoPhuCap", true);
                if (!_heSoPhuCap.Equals(value))
                {
                    _heSoPhuCap = value;
                    PropertyHasChanged("HeSoPhuCap");
                }
            }
        }

        public decimal HeSoDocHai
        {
            get
            {
                CanReadProperty("HeSoDocHai", true);
                return _heSoDocHai;
            }
            set
            {
                CanWriteProperty("HeSoDocHai", true);
                if (!_heSoDocHai.Equals(value))
                {
                    _heSoDocHai = value;
                    PropertyHasChanged("HeSoDocHai");
                }
            }
        }

        public decimal HeSoBu
        {
            get
            {
                CanReadProperty("HeSoBu", true);
                return _heSoBu;
            }
            set
            {
                CanWriteProperty("HeSoBu", true);
                if (!_heSoBu.Equals(value))
                {
                    _heSoBu = value;
                    PropertyHasChanged("HeSoBu");
                }
            }
        }

        public decimal HeSoBoSung
        {
            get
            {
                CanReadProperty("HeSoBoSung", true);
                return _heSoBoSung;
            }
            set
            {
                CanWriteProperty("HeSoBoSung", true);
                if (!_heSoBoSung.Equals(value))
                {
                    _heSoBoSung = value;
                    PropertyHasChanged("HeSoBoSung");
                }
            }
        }

        public bool PhuCapHanhChinh
        {
            get
            {
                CanReadProperty("PhuCapHanhChinh", true);
                return _phuCapHanhChinh;
            }
            set
            {
                CanWriteProperty("PhuCapHanhChinh", true);
                if (!_phuCapHanhChinh.Equals(value))
                {
                    _phuCapHanhChinh = value;
                    PropertyHasChanged("PhuCapHanhChinh");
                }
            }
        }

        public decimal LuongKhoan
        {
            get
            {
                CanReadProperty("LuongKhoan", true);
                return _luongKhoan;
            }
            set
            {
                CanWriteProperty("LuongKhoan", true);
                if (!_luongKhoan.Equals(value))
                {
                    _luongKhoan = value;
                    PropertyHasChanged("LuongKhoan");
                }
            }
        }

        public decimal PhanTramNhan
        {
            get
            {
                CanReadProperty("PhanTramNhan", true);
                return _phanTramNhan;
            }
            set
            {
                CanWriteProperty("PhanTramNhan", true);
                if (!_phanTramNhan.Equals(value))
                {
                    _phanTramNhan = value;
                    PropertyHasChanged("PhanTramNhan");
                }
            }
        }

        public decimal LuongNoiBo
        {
            get
            {
                CanReadProperty("LuongNoiBo", true);
                return _luongNoiBo;
            }
            set
            {
                CanWriteProperty("LuongNoiBo", true);
                if (!_luongNoiBo.Equals(value))
                {
                    _luongNoiBo = value;
                    PropertyHasChanged("LuongNoiBo");
                }
            }
        }

        public decimal LuongCoBanNN
        {
            get
            {
                CanReadProperty("LuongCoBanNN", true);
                return _luongCoBanNN;
            }
            set
            {
                CanWriteProperty("LuongCoBanNN", true);
                if (!_luongCoBanNN.Equals(value))
                {
                    _luongCoBanNN = value;
                    PropertyHasChanged("LuongCoBanNN");
                }
            }
        }

        public decimal DonGiaThamNien
        {
            get
            {
                CanReadProperty("DonGiaThamNien", true);
                return _donGiaThamNien;
            }
            set
            {
                CanWriteProperty("DonGiaThamNien", true);
                if (!_donGiaThamNien.Equals(value))
                {
                    _donGiaThamNien = value;
                    PropertyHasChanged("DonGiaThamNien");
                }
            }
        }

        public int SoNamThamNien
        {
            get
            {
                CanReadProperty("SoNamThamNien", true);
                return _soNamThamNien;
            }
            set
            {
                CanWriteProperty("SoNamThamNien", true);
                if (!_soNamThamNien.Equals(value))
                {
                    _soNamThamNien = value;
                    PropertyHasChanged("SoNamThamNien");
                }
            }
        }

        public decimal LuongThamNien
        {
            get
            {
                CanReadProperty("LuongThamNien", true);
                return _luongThamNien;
            }
            set
            {
                CanWriteProperty("LuongThamNien", true);
                if (!_luongThamNien.Equals(value))
                {
                    _luongThamNien = value;
                    PropertyHasChanged("LuongThamNien");
                }
            }
        }

        public decimal HeSoLuong
        {
            get
            {
                CanReadProperty("HeSoLuong", true);
                return _heSoLuong;
            }
            set
            {
                CanWriteProperty("HeSoLuong", true);
                if (!_heSoLuong.Equals(value))
                {
                    _heSoLuong = value;
                    PropertyHasChanged("HeSoLuong");
                }
            }
        }

        public decimal LuongHeSo
        {
            get
            {
                CanReadProperty("LuongHeSo", true);
                return _luongHeSo;
            }
            set
            {
                CanWriteProperty("LuongHeSo", true);
                if (!_luongHeSo.Equals(value))
                {
                    _luongHeSo = value;
                    PropertyHasChanged("LuongHeSo");
                }
            }
        }

        public decimal LuongKy1
        {
            get
            {
                CanReadProperty("LuongKy1", true);
                return _luongKy1;
            }
            set
            {
                CanWriteProperty("LuongKy1", true);
                if (!_luongKy1.Equals(value))
                {
                    _luongKy1 = value;
                    PropertyHasChanged("LuongKy1");
                }
            }
        }

        public decimal ThuLao
        {
            get
            {
                CanReadProperty("ThuLao", true);
                return _thuLao;
            }
            set
            {
                CanWriteProperty("ThuLao", true);
                if (!_thuLao.Equals(value))
                {
                    _thuLao = value;
                    PropertyHasChanged("ThuLao");
                }
            }
        }

        public decimal PhuCap
        {
            get
            {
                CanReadProperty("PhuCap", true);
                return _phuCap;
            }
            set
            {
                CanWriteProperty("PhuCap", true);
                if (!_phuCap.Equals(value))
                {
                    _phuCap = value;
                    PropertyHasChanged("PhuCap");
                }
            }
        }

        public decimal KhenThuong
        {
            get
            {
                CanReadProperty("KhenThuong", true);
                return _khenThuong;
            }
            set
            {
                CanWriteProperty("KhenThuong", true);
                if (!_khenThuong.Equals(value))
                {
                    _khenThuong = value;
                    PropertyHasChanged("KhenThuong");
                }
            }
        }

        public decimal Khac
        {
            get
            {
                CanReadProperty("Khac", true);
                return _khac;
            }
            set
            {
                CanWriteProperty("Khac", true);
                if (!_khac.Equals(value))
                {
                    _khac = value;
                    PropertyHasChanged("Khac");
                }
            }
        }

        public decimal TongThuNhap
        {
            get
            {
                CanReadProperty("TongThuNhap", true);
                return _tongThuNhap;
            }
            set
            {
                CanWriteProperty("TongThuNhap", true);
                if (!_tongThuNhap.Equals(value))
                {
                    _tongThuNhap = value;
                    PropertyHasChanged("TongThuNhap");
                }
            }
        }

        public decimal GiamTruTinhThue
        {
            get
            {
                CanReadProperty("GiamTruTinhThue", true);
                return _giamTruTinhThue;
            }
            set
            {
                CanWriteProperty("GiamTruTinhThue", true);
                if (!_giamTruTinhThue.Equals(value))
                {
                    _giamTruTinhThue = value;
                    PropertyHasChanged("GiamTruTinhThue");
                }
            }
        }

        public int SoNguoiPhuThuoc
        {
            get
            {
                CanReadProperty("SoNguoiPhuThuoc", true);
                return _soNguoiPhuThuoc;
            }
            set
            {
                CanWriteProperty("SoNguoiPhuThuoc", true);
                if (!_soNguoiPhuThuoc.Equals(value))
                {
                    _soNguoiPhuThuoc = value;
                    PropertyHasChanged("SoNguoiPhuThuoc");
                }
            }
        }

        public decimal ThueTNCN
        {
            get
            {
                CanReadProperty("ThueTNCN", true);
                return _thueTNCN;
            }
            set
            {
                CanWriteProperty("ThueTNCN", true);
                if (!_thueTNCN.Equals(value))
                {
                    _thueTNCN = value;
                    PropertyHasChanged("ThueTNCN");
                }
            }
        }

        public decimal ThueDaTamThu
        {
            get
            {
                CanReadProperty("ThueDaTamThu", true);
                return _thueDaTamThu;
            }
            set
            {
                CanWriteProperty("ThueDaTamThu", true);
                if (!_thueDaTamThu.Equals(value))
                {
                    _thueDaTamThu = value;
                    PropertyHasChanged("ThueDaTamThu");
                }
            }
        }

        public bool TruThueTNCN
        {
            get
            {
                CanReadProperty("TruThueTNCN", true);
                return _truThueTNCN;
            }
            set
            {
                CanWriteProperty("TruThueTNCN", true);
                if (!_truThueTNCN.Equals(value))
                {
                    _truThueTNCN = value;
                    PropertyHasChanged("TruThueTNCN");
                }
            }
        }

        public decimal CacKhoanDaLinh
        {
            get
            {
                CanReadProperty("CacKhoanDaLinh", true);
                return _cacKhoanDaLinh;
            }
            set
            {
                CanWriteProperty("CacKhoanDaLinh", true);
                if (!_cacKhoanDaLinh.Equals(value))
                {
                    _cacKhoanDaLinh = value;
                    PropertyHasChanged("CacKhoanDaLinh");
                }
            }
        }

        public decimal CongKhac
        {
            get
            {
                CanReadProperty("CongKhac", true);
                return _congKhac;
            }
            set
            {
                CanWriteProperty("CongKhac", true);
                if (!_congKhac.Equals(value))
                {
                    _congKhac = value;
                    PropertyHasChanged("CongKhac");
                }
            }
        }

        public decimal ThucLanh
        {
            get
            {
                CanReadProperty("ThucLanh", true);
                return _thucLanh;
            }
            set
            {
                CanWriteProperty("ThucLanh", true);
                if (!_thucLanh.Equals(value))
                {
                    _thucLanh = value;
                    PropertyHasChanged("ThucLanh");
                }
            }
        }

        public string KyHieu
        {
            get
            {
                CanReadProperty("KyHieu", true);
                return _kyHieu;
            }
            set
            {
                CanWriteProperty("KyHieu", true);
                if (value == null) value = string.Empty;
                if (!_kyHieu.Equals(value))
                {
                    _kyHieu = value;
                    PropertyHasChanged("KyHieu");
                }
            }
        }

        public int KhoanNghiSongay
        {
            get
            {
                CanReadProperty("KhoanNghiSongay", true);
                return _khoanNghiSongay;
            }
            set
            {
                CanWriteProperty("KhoanNghiSongay", true);
                if (!_khoanNghiSongay.Equals(value))
                {
                    _khoanNghiSongay = value;
                    PropertyHasChanged("KhoanNghiSongay");
                }
            }
        }

        public decimal KhoanNghiLuong
        {
            get
            {
                CanReadProperty("KhoanNghiLuong", true);
                return _khoanNghiLuong;
            }
            set
            {
                CanWriteProperty("KhoanNghiLuong", true);
                if (!_khoanNghiLuong.Equals(value))
                {
                    _khoanNghiLuong = value;
                    PropertyHasChanged("KhoanNghiLuong");
                }
            }
        }

        public int KhoanBhxhSongay
        {
            get
            {
                CanReadProperty("KhoanBhxhSongay", true);
                return _khoanBhxhSongay;
            }
            set
            {
                CanWriteProperty("KhoanBhxhSongay", true);
                if (!_khoanBhxhSongay.Equals(value))
                {
                    _khoanBhxhSongay = value;
                    PropertyHasChanged("KhoanBhxhSongay");
                }
            }
        }

        public decimal KhoanBhxhLuong
        {
            get
            {
                CanReadProperty("KhoanBhxhLuong", true);
                return _khoanBhxhLuong;
            }
            set
            {
                CanWriteProperty("KhoanBhxhLuong", true);
                if (!_khoanBhxhLuong.Equals(value))
                {
                    _khoanBhxhLuong = value;
                    PropertyHasChanged("KhoanBhxhLuong");
                }
            }
        }

        public decimal KhoanTruBhxh
        {
            get
            {
                CanReadProperty("KhoanTruBhxh", true);
                return _khoanTruBhxh;
            }
            set
            {
                CanWriteProperty("KhoanTruBhxh", true);
                if (!_khoanTruBhxh.Equals(value))
                {
                    _khoanTruBhxh = value;
                    PropertyHasChanged("KhoanTruBhxh");
                }
            }
        }

        public decimal KhoanTruBhyt
        {
            get
            {
                CanReadProperty("KhoanTruBhyt", true);
                return _khoanTruBhyt;
            }
            set
            {
                CanWriteProperty("KhoanTruBhyt", true);
                if (!_khoanTruBhyt.Equals(value))
                {
                    _khoanTruBhyt = value;
                    PropertyHasChanged("KhoanTruBhyt");
                }
            }
        }

        public decimal KhoanTruBhtn
        {
            get
            {
                CanReadProperty("KhoanTruBhtn", true);
                return _khoanTruBhtn;
            }
            set
            {
                CanWriteProperty("KhoanTruBhtn", true);
                if (!_khoanTruBhtn.Equals(value))
                {
                    _khoanTruBhtn = value;
                    PropertyHasChanged("KhoanTruBhtn");
                }
            }
        }

        public decimal KhoanTruCong
        {
            get
            {
                CanReadProperty("KhoanTruCong", true);
                return _khoanTruCong;
            }
            set
            {
                CanWriteProperty("KhoanTruCong", true);
                if (!_khoanTruCong.Equals(value))
                {
                    _khoanTruCong = value;
                    PropertyHasChanged("KhoanTruCong");
                }
            }
        }

        public decimal KhoanThuclanh
        {
            get
            {
                CanReadProperty("KhoanThuclanh", true);
                return _khoanThuclanh;
            }
            set
            {
                CanWriteProperty("KhoanThuclanh", true);
                if (!_khoanThuclanh.Equals(value))
                {
                    _khoanThuclanh = value;
                    PropertyHasChanged("KhoanThuclanh");
                }
            }
        }

        public decimal TongThuNhapTinhThue
        {
            get
            {
                CanReadProperty("TongThuNhapTinhThue", true);
                return _tongThuNhapTinhThue;
            }
            set
            {
                CanWriteProperty("TongThuNhapTinhThue", true);
                if (!_tongThuNhapTinhThue.Equals(value))
                {
                    _tongThuNhapTinhThue = value;
                    PropertyHasChanged("TongThuNhapTinhThue");
                }
            }
        }

        public decimal PhuCapTinhThue
        {
            get
            {
                CanReadProperty("PhuCapTinhThue", true);
                return _phuCapTinhThue;
            }
            set
            {
                CanWriteProperty("PhuCapTinhThue", true);
                if (!_phuCapTinhThue.Equals(value))
                {
                    _phuCapTinhThue = value;
                    PropertyHasChanged("PhuCapTinhThue");
                }
            }
        }

        public decimal KhenThuongTinhThue
        {
            get
            {
                CanReadProperty("KhenThuongTinhThue", true);
                return _khenThuongTinhThue;
            }
            set
            {
                CanWriteProperty("KhenThuongTinhThue", true);
                if (!_khenThuongTinhThue.Equals(value))
                {
                    _khenThuongTinhThue = value;
                    PropertyHasChanged("KhenThuongTinhThue");
                }
            }
        }

        public decimal KhacTinhThue
        {
            get
            {
                CanReadProperty("KhacTinhThue", true);
                return _khacTinhThue;
            }
            set
            {
                CanWriteProperty("KhacTinhThue", true);
                if (!_khacTinhThue.Equals(value))
                {
                    _khacTinhThue = value;
                    PropertyHasChanged("KhacTinhThue");
                }
            }
        }

        public decimal PhanTramVuotKhungBH
        {
            get
            {
                CanReadProperty("PhanTramVuotKhungBH", true);
                return _phanTramVuotKhungBH;
            }
            set
            {
                CanWriteProperty("PhanTramVuotKhungBH", true);
                if (!_phanTramVuotKhungBH.Equals(value))
                {
                    _phanTramVuotKhungBH = value;
                    PropertyHasChanged("PhanTramVuotKhungBH");
                }
            }
        }

        public decimal HeSoVuotKhungBH
        {
            get
            {
                CanReadProperty("HeSoVuotKhungBH", true);
                return _heSoVuotKhungBH;
            }
            set
            {
                CanWriteProperty("HeSoVuotKhungBH", true);
                if (!_heSoVuotKhungBH.Equals(value))
                {
                    _heSoVuotKhungBH = value;
                    PropertyHasChanged("HeSoVuotKhungBH");
                }
            }
        }

        public decimal ThuLaoTinhThue
        {
            get
            {
                CanReadProperty("ThuLaoTinhThue", true);
                return _thuLaoTinhThue;
            }
            set
            {
                CanWriteProperty("ThuLaoTinhThue", true);
                if (!_thuLaoTinhThue.Equals(value))
                {
                    _thuLaoTinhThue = value;
                    PropertyHasChanged("ThuLaoTinhThue");
                }
            }
        }

        public decimal TruCongdoan
        {
            get
            {
                CanReadProperty("TruCongdoan", true);
                return _truCongdoan;
            }
            set
            {
                CanWriteProperty("TruCongdoan", true);
                if (!_truCongdoan.Equals(value))
                {
                    _truCongdoan = value;
                    PropertyHasChanged("TruCongdoan");
                }
            }
        }

        public DateTime NgayBDTinhLuong
        {
            get
            {
                CanReadProperty("NgayBDTinhLuong", true);
                return _ngayBDTinhLuong.Date;
            }
        }

        public string NgayBDTinhLuongString
        {
            get
            {
                CanReadProperty("NgayBDTinhLuongString", true);
                return _ngayBDTinhLuong.Text;
            }
            set
            {
                CanWriteProperty("NgayBDTinhLuongString", true);
                if (value == null) value = string.Empty;
                if (!_ngayBDTinhLuong.Equals(value))
                {
                    _ngayBDTinhLuong.Text = value;
                    PropertyHasChanged("NgayBDTinhLuongString");
                }
            }
        }

        public DateTime NgayKTTinhLuong
        {
            get
            {
                CanReadProperty("NgayKTTinhLuong", true);
                return _ngayKTTinhLuong.Date;
            }
        }

        public string NgayKTTinhLuongString
        {
            get
            {
                CanReadProperty("NgayKTTinhLuongString", true);
                return _ngayKTTinhLuong.Text;
            }
            set
            {
                CanWriteProperty("NgayKTTinhLuongString", true);
                if (value == null) value = string.Empty;
                if (!_ngayKTTinhLuong.Equals(value))
                {
                    _ngayKTTinhLuong.Text = value;
                    PropertyHasChanged("NgayKTTinhLuongString");
                }
            }
        }

        public long MaPhieuChi
        {
            get
            {
                CanReadProperty("MaPhieuChi", true);
                return _maPhieuChi;
            }
            set
            {
                CanWriteProperty("MaPhieuChi", true);
                if (!_maPhieuChi.Equals(value))
                {
                    _maPhieuChi = value;
                    PropertyHasChanged("MaPhieuChi");
                }
            }
        }

        public decimal PhanTramThue
        {
            get
            {
                CanReadProperty("PhanTramThue", true);
                return _phanTramThue;
            }
            set
            {
                CanWriteProperty("PhanTramThue", true);
                if (!_phanTramThue.Equals(value))
                {
                    _phanTramThue = value;
                    PropertyHasChanged("PhanTramThue");
                }
            }
        }

        public long MaDeNghi
        {
            get
            {
                CanReadProperty("MaDeNghi", true);
                return _maDeNghi;
            }
            set
            {
                CanWriteProperty("MaDeNghi", true);
                if (!_maDeNghi.Equals(value))
                {
                    _maDeNghi = value;
                    PropertyHasChanged("MaDeNghi");
                }
            }
        }

        protected override object GetIdValue()
        {
            return _maChiTiet;
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
            // SoTaiKhoan
            //
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("SoTaiKhoan", 50));
            //
            // Cmnd
            //
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("Cmnd", 50));
            //
            // MaNgachLuong
            //
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("MaNgachLuong", 50));
            //
            // KyHieu
            //
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("KyHieu", 50));
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
            //TODO: Define authorization rules in BangLuongKyII
            //AuthorizationRules.AllowRead("MaChiTiet", "BangLuongKyIIReadGroup");
            //AuthorizationRules.AllowRead("MaKyTinhLuong", "BangLuongKyIIReadGroup");
            //AuthorizationRules.AllowRead("MaNhanVien", "BangLuongKyIIReadGroup");
            //AuthorizationRules.AllowRead("MaBoPhan", "BangLuongKyIIReadGroup");
            //AuthorizationRules.AllowRead("ThanhToan", "BangLuongKyIIReadGroup");
            //AuthorizationRules.AllowRead("SoTaiKhoan", "BangLuongKyIIReadGroup");
            //AuthorizationRules.AllowRead("Cmnd", "BangLuongKyIIReadGroup");
            //AuthorizationRules.AllowRead("MaNganHang", "BangLuongKyIIReadGroup");
            //AuthorizationRules.AllowRead("LoaiNV", "BangLuongKyIIReadGroup");
            //AuthorizationRules.AllowRead("MaNgachLuong", "BangLuongKyIIReadGroup");
            //AuthorizationRules.AllowRead("HeSoCoBan", "BangLuongKyIIReadGroup");
            //AuthorizationRules.AllowRead("HeSoBaoHiem", "BangLuongKyIIReadGroup");
            //AuthorizationRules.AllowRead("HeSoNoiBo", "BangLuongKyIIReadGroup");
            //AuthorizationRules.AllowRead("PhanTramVuotKhung", "BangLuongKyIIReadGroup");
            //AuthorizationRules.AllowRead("HeSoVuotKhung", "BangLuongKyIIReadGroup");
            //AuthorizationRules.AllowRead("HeSoPhuCap", "BangLuongKyIIReadGroup");
            //AuthorizationRules.AllowRead("HeSoDocHai", "BangLuongKyIIReadGroup");
            //AuthorizationRules.AllowRead("HeSoBu", "BangLuongKyIIReadGroup");
            //AuthorizationRules.AllowRead("HeSoBoSung", "BangLuongKyIIReadGroup");
            //AuthorizationRules.AllowRead("PhuCapHanhChinh", "BangLuongKyIIReadGroup");
            //AuthorizationRules.AllowRead("LuongKhoan", "BangLuongKyIIReadGroup");
            //AuthorizationRules.AllowRead("PhanTramNhan", "BangLuongKyIIReadGroup");
            //AuthorizationRules.AllowRead("LuongNoiBo", "BangLuongKyIIReadGroup");
            //AuthorizationRules.AllowRead("LuongCoBanNN", "BangLuongKyIIReadGroup");
            //AuthorizationRules.AllowRead("DonGiaThamNien", "BangLuongKyIIReadGroup");
            //AuthorizationRules.AllowRead("SoNamThamNien", "BangLuongKyIIReadGroup");
            //AuthorizationRules.AllowRead("LuongThamNien", "BangLuongKyIIReadGroup");
            //AuthorizationRules.AllowRead("HeSoLuong", "BangLuongKyIIReadGroup");
            //AuthorizationRules.AllowRead("LuongHeSo", "BangLuongKyIIReadGroup");
            //AuthorizationRules.AllowRead("LuongKy1", "BangLuongKyIIReadGroup");
            //AuthorizationRules.AllowRead("ThuLao", "BangLuongKyIIReadGroup");
            //AuthorizationRules.AllowRead("PhuCap", "BangLuongKyIIReadGroup");
            //AuthorizationRules.AllowRead("KhenThuong", "BangLuongKyIIReadGroup");
            //AuthorizationRules.AllowRead("Khac", "BangLuongKyIIReadGroup");
            //AuthorizationRules.AllowRead("TongThuNhap", "BangLuongKyIIReadGroup");
            //AuthorizationRules.AllowRead("GiamTruTinhThue", "BangLuongKyIIReadGroup");
            //AuthorizationRules.AllowRead("SoNguoiPhuThuoc", "BangLuongKyIIReadGroup");
            //AuthorizationRules.AllowRead("ThueTNCN", "BangLuongKyIIReadGroup");
            //AuthorizationRules.AllowRead("ThueDaTamThu", "BangLuongKyIIReadGroup");
            //AuthorizationRules.AllowRead("TruThueTNCN", "BangLuongKyIIReadGroup");
            //AuthorizationRules.AllowRead("CacKhoanDaLinh", "BangLuongKyIIReadGroup");
            //AuthorizationRules.AllowRead("CongKhac", "BangLuongKyIIReadGroup");
            //AuthorizationRules.AllowRead("ThucLanh", "BangLuongKyIIReadGroup");
            //AuthorizationRules.AllowRead("KyHieu", "BangLuongKyIIReadGroup");
            //AuthorizationRules.AllowRead("KhoanNghiSongay", "BangLuongKyIIReadGroup");
            //AuthorizationRules.AllowRead("KhoanNghiLuong", "BangLuongKyIIReadGroup");
            //AuthorizationRules.AllowRead("KhoanBhxhSongay", "BangLuongKyIIReadGroup");
            //AuthorizationRules.AllowRead("KhoanBhxhLuong", "BangLuongKyIIReadGroup");
            //AuthorizationRules.AllowRead("KhoanTruBhxh", "BangLuongKyIIReadGroup");
            //AuthorizationRules.AllowRead("KhoanTruBhyt", "BangLuongKyIIReadGroup");
            //AuthorizationRules.AllowRead("KhoanTruBhtn", "BangLuongKyIIReadGroup");
            //AuthorizationRules.AllowRead("KhoanTruCong", "BangLuongKyIIReadGroup");
            //AuthorizationRules.AllowRead("KhoanThuclanh", "BangLuongKyIIReadGroup");
            //AuthorizationRules.AllowRead("TongThuNhapTinhThue", "BangLuongKyIIReadGroup");
            //AuthorizationRules.AllowRead("PhuCapTinhThue", "BangLuongKyIIReadGroup");
            //AuthorizationRules.AllowRead("KhenThuongTinhThue", "BangLuongKyIIReadGroup");
            //AuthorizationRules.AllowRead("KhacTinhThue", "BangLuongKyIIReadGroup");
            //AuthorizationRules.AllowRead("PhanTramVuotKhungBH", "BangLuongKyIIReadGroup");
            //AuthorizationRules.AllowRead("HeSoVuotKhungBH", "BangLuongKyIIReadGroup");
            //AuthorizationRules.AllowRead("ThuLaoTinhThue", "BangLuongKyIIReadGroup");
            //AuthorizationRules.AllowRead("TruCongdoan", "BangLuongKyIIReadGroup");
            //AuthorizationRules.AllowRead("NgayBDTinhLuong", "BangLuongKyIIReadGroup");
            //AuthorizationRules.AllowRead("NgayBDTinhLuongString", "BangLuongKyIIReadGroup");
            //AuthorizationRules.AllowRead("NgayKTTinhLuong", "BangLuongKyIIReadGroup");
            //AuthorizationRules.AllowRead("NgayKTTinhLuongString", "BangLuongKyIIReadGroup");
            //AuthorizationRules.AllowRead("MaPhieuChi", "BangLuongKyIIReadGroup");
            //AuthorizationRules.AllowRead("PhanTramThue", "BangLuongKyIIReadGroup");
            //AuthorizationRules.AllowRead("MaDeNghi", "BangLuongKyIIReadGroup");

            //AuthorizationRules.AllowWrite("MaKyTinhLuong", "BangLuongKyIIWriteGroup");
            //AuthorizationRules.AllowWrite("MaNhanVien", "BangLuongKyIIWriteGroup");
            //AuthorizationRules.AllowWrite("MaBoPhan", "BangLuongKyIIWriteGroup");
            //AuthorizationRules.AllowWrite("ThanhToan", "BangLuongKyIIWriteGroup");
            //AuthorizationRules.AllowWrite("SoTaiKhoan", "BangLuongKyIIWriteGroup");
            //AuthorizationRules.AllowWrite("Cmnd", "BangLuongKyIIWriteGroup");
            //AuthorizationRules.AllowWrite("MaNganHang", "BangLuongKyIIWriteGroup");
            //AuthorizationRules.AllowWrite("LoaiNV", "BangLuongKyIIWriteGroup");
            //AuthorizationRules.AllowWrite("MaNgachLuong", "BangLuongKyIIWriteGroup");
            //AuthorizationRules.AllowWrite("HeSoCoBan", "BangLuongKyIIWriteGroup");
            //AuthorizationRules.AllowWrite("HeSoBaoHiem", "BangLuongKyIIWriteGroup");
            //AuthorizationRules.AllowWrite("HeSoNoiBo", "BangLuongKyIIWriteGroup");
            //AuthorizationRules.AllowWrite("PhanTramVuotKhung", "BangLuongKyIIWriteGroup");
            //AuthorizationRules.AllowWrite("HeSoVuotKhung", "BangLuongKyIIWriteGroup");
            //AuthorizationRules.AllowWrite("HeSoPhuCap", "BangLuongKyIIWriteGroup");
            //AuthorizationRules.AllowWrite("HeSoDocHai", "BangLuongKyIIWriteGroup");
            //AuthorizationRules.AllowWrite("HeSoBu", "BangLuongKyIIWriteGroup");
            //AuthorizationRules.AllowWrite("HeSoBoSung", "BangLuongKyIIWriteGroup");
            //AuthorizationRules.AllowWrite("PhuCapHanhChinh", "BangLuongKyIIWriteGroup");
            //AuthorizationRules.AllowWrite("LuongKhoan", "BangLuongKyIIWriteGroup");
            //AuthorizationRules.AllowWrite("PhanTramNhan", "BangLuongKyIIWriteGroup");
            //AuthorizationRules.AllowWrite("LuongNoiBo", "BangLuongKyIIWriteGroup");
            //AuthorizationRules.AllowWrite("LuongCoBanNN", "BangLuongKyIIWriteGroup");
            //AuthorizationRules.AllowWrite("DonGiaThamNien", "BangLuongKyIIWriteGroup");
            //AuthorizationRules.AllowWrite("SoNamThamNien", "BangLuongKyIIWriteGroup");
            //AuthorizationRules.AllowWrite("LuongThamNien", "BangLuongKyIIWriteGroup");
            //AuthorizationRules.AllowWrite("HeSoLuong", "BangLuongKyIIWriteGroup");
            //AuthorizationRules.AllowWrite("LuongHeSo", "BangLuongKyIIWriteGroup");
            //AuthorizationRules.AllowWrite("LuongKy1", "BangLuongKyIIWriteGroup");
            //AuthorizationRules.AllowWrite("ThuLao", "BangLuongKyIIWriteGroup");
            //AuthorizationRules.AllowWrite("PhuCap", "BangLuongKyIIWriteGroup");
            //AuthorizationRules.AllowWrite("KhenThuong", "BangLuongKyIIWriteGroup");
            //AuthorizationRules.AllowWrite("Khac", "BangLuongKyIIWriteGroup");
            //AuthorizationRules.AllowWrite("TongThuNhap", "BangLuongKyIIWriteGroup");
            //AuthorizationRules.AllowWrite("GiamTruTinhThue", "BangLuongKyIIWriteGroup");
            //AuthorizationRules.AllowWrite("SoNguoiPhuThuoc", "BangLuongKyIIWriteGroup");
            //AuthorizationRules.AllowWrite("ThueTNCN", "BangLuongKyIIWriteGroup");
            //AuthorizationRules.AllowWrite("ThueDaTamThu", "BangLuongKyIIWriteGroup");
            //AuthorizationRules.AllowWrite("TruThueTNCN", "BangLuongKyIIWriteGroup");
            //AuthorizationRules.AllowWrite("CacKhoanDaLinh", "BangLuongKyIIWriteGroup");
            //AuthorizationRules.AllowWrite("CongKhac", "BangLuongKyIIWriteGroup");
            //AuthorizationRules.AllowWrite("ThucLanh", "BangLuongKyIIWriteGroup");
            //AuthorizationRules.AllowWrite("KyHieu", "BangLuongKyIIWriteGroup");
            //AuthorizationRules.AllowWrite("KhoanNghiSongay", "BangLuongKyIIWriteGroup");
            //AuthorizationRules.AllowWrite("KhoanNghiLuong", "BangLuongKyIIWriteGroup");
            //AuthorizationRules.AllowWrite("KhoanBhxhSongay", "BangLuongKyIIWriteGroup");
            //AuthorizationRules.AllowWrite("KhoanBhxhLuong", "BangLuongKyIIWriteGroup");
            //AuthorizationRules.AllowWrite("KhoanTruBhxh", "BangLuongKyIIWriteGroup");
            //AuthorizationRules.AllowWrite("KhoanTruBhyt", "BangLuongKyIIWriteGroup");
            //AuthorizationRules.AllowWrite("KhoanTruBhtn", "BangLuongKyIIWriteGroup");
            //AuthorizationRules.AllowWrite("KhoanTruCong", "BangLuongKyIIWriteGroup");
            //AuthorizationRules.AllowWrite("KhoanThuclanh", "BangLuongKyIIWriteGroup");
            //AuthorizationRules.AllowWrite("TongThuNhapTinhThue", "BangLuongKyIIWriteGroup");
            //AuthorizationRules.AllowWrite("PhuCapTinhThue", "BangLuongKyIIWriteGroup");
            //AuthorizationRules.AllowWrite("KhenThuongTinhThue", "BangLuongKyIIWriteGroup");
            //AuthorizationRules.AllowWrite("KhacTinhThue", "BangLuongKyIIWriteGroup");
            //AuthorizationRules.AllowWrite("PhanTramVuotKhungBH", "BangLuongKyIIWriteGroup");
            //AuthorizationRules.AllowWrite("HeSoVuotKhungBH", "BangLuongKyIIWriteGroup");
            //AuthorizationRules.AllowWrite("ThuLaoTinhThue", "BangLuongKyIIWriteGroup");
            //AuthorizationRules.AllowWrite("TruCongdoan", "BangLuongKyIIWriteGroup");
            //AuthorizationRules.AllowWrite("NgayBDTinhLuongString", "BangLuongKyIIWriteGroup");
            //AuthorizationRules.AllowWrite("NgayKTTinhLuongString", "BangLuongKyIIWriteGroup");
            //AuthorizationRules.AllowWrite("MaPhieuChi", "BangLuongKyIIWriteGroup");
            //AuthorizationRules.AllowWrite("PhanTramThue", "BangLuongKyIIWriteGroup");
            //AuthorizationRules.AllowWrite("MaDeNghi", "BangLuongKyIIWriteGroup");
        }


        public static bool CanGetObject()
        {
            //TODO: Define CanGetObject permission in BangLuongKyII
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("BangLuongKyIIViewGroup"))
            //	return true;
            //return false;
        }

        public static bool CanAddObject()
        {
            //TODO: Define CanAddObject permission in BangLuongKyII
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("BangLuongKyIIAddGroup"))
            //	return true;
            //return false;
        }

        public static bool CanEditObject()
        {
            //TODO: Define CanEditObject permission in BangLuongKyII
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("BangLuongKyIIEditGroup"))
            //	return true;
            //return false;
        }

        public static bool CanDeleteObject()
        {
            //TODO: Define CanDeleteObject permission in BangLuongKyII
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("BangLuongKyIIDeleteGroup"))
            //	return true;
            //return false;
        }
        #endregion //Authorization Rules

        #region Factory Methods
        private BangLuongKyII()
        { /* require use of factory method */ }

        public static BangLuongKyII NewBangLuongKyII()
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a BangLuongKyII");
            return DataPortal.Create<BangLuongKyII>();
        }

        public static BangLuongKyII GetBangLuongKyII(int maChiTiet)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a BangLuongKyII");
            return DataPortal.Fetch<BangLuongKyII>(new Criteria(maChiTiet));
        }

        public static void DeleteBangLuongKyII(int maChiTiet)
        {
            if (!CanDeleteObject())
                throw new System.Security.SecurityException("User not authorized to remove a BangLuongKyII");
            DataPortal.Delete(new Criteria(maChiTiet));
        }

        public override BangLuongKyII Save()
        {
            if (IsDeleted && !CanDeleteObject())
                throw new System.Security.SecurityException("User not authorized to remove a BangLuongKyII");
            else if (IsNew && !CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a BangLuongKyII");
            else if (!CanEditObject())
                throw new System.Security.SecurityException("User not authorized to update a BangLuongKyII");

            return base.Save();
        }

        #endregion //Factory Methods

        #region Child Factory Methods
        internal static BangLuongKyII NewBangLuongKyIIChild()
        {
            BangLuongKyII child = new BangLuongKyII();
            child.ValidationRules.CheckRules();
            child.MarkAsChild();
            return child;
        }

        internal static BangLuongKyII GetBangLuongKyII(SafeDataReader dr)
        {
            BangLuongKyII child = new BangLuongKyII();
            child.MarkAsChild();
            child.Fetch(dr);
            return child;
        }
        #endregion //Child Factory Methods

        #region Data Access

        #region Criteria

        [Serializable()]
        private class Criteria
        {
            public int MaChiTiet;

            public Criteria(int maChiTiet)
            {
                this.MaChiTiet = maChiTiet;
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
        private void DataPortal_Fetch(Criteria criteria)
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

        private void ExecuteFetch(SqlTransaction tr, Criteria criteria)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_SelecttblBangLuongKyII";

                cm.Parameters.AddWithValue("@MaChiTiet", criteria.MaChiTiet);

                using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                {
                    dr.Read();
                    FetchObject(dr);
                    ValidationRules.CheckRules();

                    //load child object(s)
                    FetchChildren(dr);
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
                catch
                {
                    tr.Rollback();
                    throw;
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
                        ExecuteUpdate(tr, null);
                    }

                    //update child object(s)
                    UpdateChildren(tr);

                    tr.Commit();
                }
                catch
                {
                    tr.Rollback();
                    throw;
                }
            }//using

        }

        #endregion //Data Access - Update

        #region Data Access - Delete
        protected override void DataPortal_DeleteSelf()
        {
            DataPortal_Delete(new Criteria(_maChiTiet));
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
                catch
                {
                    tr.Rollback();
                    throw;
                }
            }//using

        }

        private void ExecuteDelete(SqlTransaction tr, Criteria criteria)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_DeletetblBangLuongKyII";

                cm.Parameters.AddWithValue("@MaChiTiet", criteria.MaChiTiet);

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
            FetchChildren(dr);
        }

        private void FetchObject(SafeDataReader dr)
        {
            _maChiTiet = dr.GetInt32("MaChiTiet");
            _maKyTinhLuong = dr.GetInt32("MaKyTinhLuong");
            _maNhanVien = dr.GetInt64("MaNhanVien");
            _maBoPhan = dr.GetInt32("MaBoPhan");
            _thanhToan = dr.GetInt32("ThanhToan");
            _soTaiKhoan = dr.GetString("SoTaiKhoan");
            _cmnd = dr.GetString("CMND");
            _maNganHang = dr.GetInt32("MaNganHang");
            _loaiNV = dr.GetInt32("LoaiNV");
            _maNgachLuong = dr.GetString("MaNgachLuong");
            _heSoCoBan = dr.GetDecimal("HeSoCoBan");
            _heSoBaoHiem = dr.GetDecimal("HeSoBaoHiem");
            _heSoNoiBo = dr.GetDecimal("HeSoNoiBo");
            _phanTramVuotKhung = dr.GetDecimal("PhanTramVuotKhung");
            _heSoVuotKhung = dr.GetDecimal("HeSoVuotKhung");
            _heSoPhuCap = dr.GetDecimal("HeSoPhuCap");
            _heSoDocHai = dr.GetDecimal("HeSoDocHai");
            _heSoBu = dr.GetDecimal("HeSoBu");
            _heSoBoSung = dr.GetDecimal("HeSoBoSung");
            _phuCapHanhChinh = dr.GetBoolean("PhuCapHanhChinh");
            _luongKhoan = dr.GetDecimal("LuongKhoan");
            _phanTramNhan = dr.GetDecimal("PhanTramNhan");
            _luongNoiBo = dr.GetDecimal("LuongNoiBo");
            _luongCoBanNN = dr.GetDecimal("LuongCoBanNN");
            _donGiaThamNien = dr.GetDecimal("DonGiaThamNien");
            _soNamThamNien = dr.GetInt32("SoNamThamNien");
            _luongThamNien = dr.GetDecimal("LuongThamNien");
            _heSoLuong = dr.GetDecimal("HeSoLuong");
            _luongHeSo = dr.GetDecimal("LuongHeSo");
            _luongKy1 = dr.GetDecimal("LuongKy1");
            _thuLao = dr.GetDecimal("ThuLao");
            _phuCap = dr.GetDecimal("PhuCap");
            _khenThuong = dr.GetDecimal("KhenThuong");
            _khac = dr.GetDecimal("Khac");
            _tongThuNhap = dr.GetDecimal("TongThuNhap");
            _giamTruTinhThue = dr.GetDecimal("GiamTruTinhThue");
            _soNguoiPhuThuoc = dr.GetInt32("SoNguoiPhuThuoc");
            _thueTNCN = dr.GetDecimal("ThueTNCN");
            _thueDaTamThu = dr.GetDecimal("ThueDaTamThu");
            _truThueTNCN = dr.GetBoolean("TruThueTNCN");
            _cacKhoanDaLinh = dr.GetDecimal("CacKhoanDaLinh");
            _congKhac = dr.GetDecimal("CongKhac");
            _thucLanh = dr.GetDecimal("ThucLanh");
            _kyHieu = dr.GetString("KyHieu");
            _khoanNghiSongay = dr.GetInt32("Khoan_Nghi_SoNgay");
            _khoanNghiLuong = dr.GetDecimal("Khoan_Nghi_Luong");
            _khoanBhxhSongay = dr.GetInt32("Khoan_BHXH_SoNgay");
            _khoanBhxhLuong = dr.GetDecimal("Khoan_BHXH_Luong");
            _khoanTruBhxh = dr.GetDecimal("Khoan_Tru_BHXH");
            _khoanTruBhyt = dr.GetDecimal("Khoan_Tru_BHYT");
            _khoanTruBhtn = dr.GetDecimal("Khoan_Tru_BHTN");
            _khoanTruCong = dr.GetDecimal("Khoan_Tru_Cong");
            _khoanThuclanh = dr.GetDecimal("Khoan_ThucLanh");
            _tongThuNhapTinhThue = dr.GetDecimal("TongThuNhapTinhThue");
            _phuCapTinhThue = dr.GetDecimal("PhuCapTinhThue");
            _khenThuongTinhThue = dr.GetDecimal("KhenThuongTinhThue");
            _khacTinhThue = dr.GetDecimal("KhacTinhThue");
            _phanTramVuotKhungBH = dr.GetDecimal("PhanTramVuotKhungBH");
            _heSoVuotKhungBH = dr.GetDecimal("HeSoVuotKhungBH");
            _thuLaoTinhThue = dr.GetDecimal("ThuLaoTinhThue");
            _truCongdoan = dr.GetDecimal("Tru_CongDoan");
            _ngayBDTinhLuong = dr.GetSmartDate("NgayBDTinhLuong", _ngayBDTinhLuong.EmptyIsMin);
            _ngayKTTinhLuong = dr.GetSmartDate("NgayKTTinhLuong", _ngayKTTinhLuong.EmptyIsMin);
            _maPhieuChi = dr.GetInt64("MaPhieuChi");
            _phanTramThue = dr.GetDecimal("PhanTramThue");
            _maDeNghi = dr.GetInt64("MaDeNghi");
        }

        private void FetchChildren(SafeDataReader dr)
        {
        }
        #endregion //Data Access - Fetch

        #region Data Access - Insert
        internal void Insert(SqlTransaction tr, BangLuongKyIIList parent)
        {
            if (!IsDirty) return;

            ExecuteInsert(tr, parent);
            MarkOld();

            //update child object(s)
            UpdateChildren(tr);
        }

        private void ExecuteInsert(SqlTransaction tr, BangLuongKyIIList parent)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_InserttblBangLuongKyII";

                AddInsertParameters(cm, parent);

                cm.ExecuteNonQuery();

                _maChiTiet = (int)cm.Parameters["@NewMaChiTiet"].Value;
            }//using
        }

        private void AddInsertParameters(SqlCommand cm, BangLuongKyIIList parent)
        {
            //TODO: if parent use identity key, fix fk member with value from parent
            cm.Parameters.AddWithValue("@MaKyTinhLuong", _maKyTinhLuong);
            cm.Parameters.AddWithValue("@MaNhanVien", _maNhanVien);
            cm.Parameters.AddWithValue("@MaBoPhan", _maBoPhan);
            cm.Parameters.AddWithValue("@ThanhToan", _thanhToan);
            if (_soTaiKhoan.Length > 0)
                cm.Parameters.AddWithValue("@SoTaiKhoan", _soTaiKhoan);
            else
                cm.Parameters.AddWithValue("@SoTaiKhoan", DBNull.Value);
            if (_cmnd.Length > 0)
                cm.Parameters.AddWithValue("@CMND", _cmnd);
            else
                cm.Parameters.AddWithValue("@CMND", DBNull.Value);
            if (_maNganHang != 0)
                cm.Parameters.AddWithValue("@MaNganHang", _maNganHang);
            else
                cm.Parameters.AddWithValue("@MaNganHang", DBNull.Value);
            cm.Parameters.AddWithValue("@LoaiNV", _loaiNV);
            if (_maNgachLuong.Length > 0)
                cm.Parameters.AddWithValue("@MaNgachLuong", _maNgachLuong);
            else
                cm.Parameters.AddWithValue("@MaNgachLuong", DBNull.Value);
            if (_heSoCoBan != 0)
                cm.Parameters.AddWithValue("@HeSoCoBan", _heSoCoBan);
            else
                cm.Parameters.AddWithValue("@HeSoCoBan", DBNull.Value);
            if (_heSoBaoHiem != 0)
                cm.Parameters.AddWithValue("@HeSoBaoHiem", _heSoBaoHiem);
            else
                cm.Parameters.AddWithValue("@HeSoBaoHiem", DBNull.Value);
            if (_heSoNoiBo != 0)
                cm.Parameters.AddWithValue("@HeSoNoiBo", _heSoNoiBo);
            else
                cm.Parameters.AddWithValue("@HeSoNoiBo", DBNull.Value);
            if (_phanTramVuotKhung != 0)
                cm.Parameters.AddWithValue("@PhanTramVuotKhung", _phanTramVuotKhung);
            else
                cm.Parameters.AddWithValue("@PhanTramVuotKhung", DBNull.Value);
            if (_heSoVuotKhung != 0)
                cm.Parameters.AddWithValue("@HeSoVuotKhung", _heSoVuotKhung);
            else
                cm.Parameters.AddWithValue("@HeSoVuotKhung", DBNull.Value);
            if (_heSoPhuCap != 0)
                cm.Parameters.AddWithValue("@HeSoPhuCap", _heSoPhuCap);
            else
                cm.Parameters.AddWithValue("@HeSoPhuCap", DBNull.Value);
            if (_heSoDocHai != 0)
                cm.Parameters.AddWithValue("@HeSoDocHai", _heSoDocHai);
            else
                cm.Parameters.AddWithValue("@HeSoDocHai", DBNull.Value);
            if (_heSoBu != 0)
                cm.Parameters.AddWithValue("@HeSoBu", _heSoBu);
            else
                cm.Parameters.AddWithValue("@HeSoBu", DBNull.Value);
            if (_heSoBoSung != 0)
                cm.Parameters.AddWithValue("@HeSoBoSung", _heSoBoSung);
            else
                cm.Parameters.AddWithValue("@HeSoBoSung", DBNull.Value);
            if (_phuCapHanhChinh != false)
                cm.Parameters.AddWithValue("@PhuCapHanhChinh", _phuCapHanhChinh);
            else
                cm.Parameters.AddWithValue("@PhuCapHanhChinh", DBNull.Value);
            if (_luongKhoan != 0)
                cm.Parameters.AddWithValue("@LuongKhoan", _luongKhoan);
            else
                cm.Parameters.AddWithValue("@LuongKhoan", DBNull.Value);
            if (_phanTramNhan != 0)
                cm.Parameters.AddWithValue("@PhanTramNhan", _phanTramNhan);
            else
                cm.Parameters.AddWithValue("@PhanTramNhan", DBNull.Value);
            if (_luongNoiBo != 0)
                cm.Parameters.AddWithValue("@LuongNoiBo", _luongNoiBo);
            else
                cm.Parameters.AddWithValue("@LuongNoiBo", DBNull.Value);
            if (_luongCoBanNN != 0)
                cm.Parameters.AddWithValue("@LuongCoBanNN", _luongCoBanNN);
            else
                cm.Parameters.AddWithValue("@LuongCoBanNN", DBNull.Value);
            if (_donGiaThamNien != 0)
                cm.Parameters.AddWithValue("@DonGiaThamNien", _donGiaThamNien);
            else
                cm.Parameters.AddWithValue("@DonGiaThamNien", DBNull.Value);
            if (_soNamThamNien != 0)
                cm.Parameters.AddWithValue("@SoNamThamNien", _soNamThamNien);
            else
                cm.Parameters.AddWithValue("@SoNamThamNien", DBNull.Value);
            if (_luongThamNien != 0)
                cm.Parameters.AddWithValue("@LuongThamNien", _luongThamNien);
            else
                cm.Parameters.AddWithValue("@LuongThamNien", DBNull.Value);
            if (_heSoLuong != 0)
                cm.Parameters.AddWithValue("@HeSoLuong", _heSoLuong);
            else
                cm.Parameters.AddWithValue("@HeSoLuong", DBNull.Value);
            if (_luongHeSo != 0)
                cm.Parameters.AddWithValue("@LuongHeSo", _luongHeSo);
            else
                cm.Parameters.AddWithValue("@LuongHeSo", DBNull.Value);
            if (_luongKy1 != 0)
                cm.Parameters.AddWithValue("@LuongKy1", _luongKy1);
            else
                cm.Parameters.AddWithValue("@LuongKy1", DBNull.Value);
            if (_thuLao != 0)
                cm.Parameters.AddWithValue("@ThuLao", _thuLao);
            else
                cm.Parameters.AddWithValue("@ThuLao", DBNull.Value);
            if (_phuCap != 0)
                cm.Parameters.AddWithValue("@PhuCap", _phuCap);
            else
                cm.Parameters.AddWithValue("@PhuCap", DBNull.Value);
            if (_khenThuong != 0)
                cm.Parameters.AddWithValue("@KhenThuong", _khenThuong);
            else
                cm.Parameters.AddWithValue("@KhenThuong", DBNull.Value);
            if (_khac != 0)
                cm.Parameters.AddWithValue("@Khac", _khac);
            else
                cm.Parameters.AddWithValue("@Khac", DBNull.Value);
            if (_tongThuNhap != 0)
                cm.Parameters.AddWithValue("@TongThuNhap", _tongThuNhap);
            else
                cm.Parameters.AddWithValue("@TongThuNhap", DBNull.Value);
            if (_giamTruTinhThue != 0)
                cm.Parameters.AddWithValue("@GiamTruTinhThue", _giamTruTinhThue);
            else
                cm.Parameters.AddWithValue("@GiamTruTinhThue", DBNull.Value);
            if (_soNguoiPhuThuoc != 0)
                cm.Parameters.AddWithValue("@SoNguoiPhuThuoc", _soNguoiPhuThuoc);
            else
                cm.Parameters.AddWithValue("@SoNguoiPhuThuoc", DBNull.Value);
            if (_thueTNCN != 0)
                cm.Parameters.AddWithValue("@ThueTNCN", _thueTNCN);
            else
                cm.Parameters.AddWithValue("@ThueTNCN", DBNull.Value);
            if (_thueDaTamThu != 0)
                cm.Parameters.AddWithValue("@ThueDaTamThu", _thueDaTamThu);
            else
                cm.Parameters.AddWithValue("@ThueDaTamThu", DBNull.Value);
            if (_truThueTNCN != false)
                cm.Parameters.AddWithValue("@TruThueTNCN", _truThueTNCN);
            else
                cm.Parameters.AddWithValue("@TruThueTNCN", DBNull.Value);
            if (_cacKhoanDaLinh != 0)
                cm.Parameters.AddWithValue("@CacKhoanDaLinh", _cacKhoanDaLinh);
            else
                cm.Parameters.AddWithValue("@CacKhoanDaLinh", DBNull.Value);
            if (_congKhac != 0)
                cm.Parameters.AddWithValue("@CongKhac", _congKhac);
            else
                cm.Parameters.AddWithValue("@CongKhac", DBNull.Value);
            if (_thucLanh != 0)
                cm.Parameters.AddWithValue("@ThucLanh", _thucLanh);
            else
                cm.Parameters.AddWithValue("@ThucLanh", DBNull.Value);
            if (_kyHieu.Length > 0)
                cm.Parameters.AddWithValue("@KyHieu", _kyHieu);
            else
                cm.Parameters.AddWithValue("@KyHieu", DBNull.Value);
            if (_khoanNghiSongay != 0)
                cm.Parameters.AddWithValue("@Khoan_Nghi_SoNgay", _khoanNghiSongay);
            else
                cm.Parameters.AddWithValue("@Khoan_Nghi_SoNgay", DBNull.Value);
            if (_khoanNghiLuong != 0)
                cm.Parameters.AddWithValue("@Khoan_Nghi_Luong", _khoanNghiLuong);
            else
                cm.Parameters.AddWithValue("@Khoan_Nghi_Luong", DBNull.Value);
            if (_khoanBhxhSongay != 0)
                cm.Parameters.AddWithValue("@Khoan_BHXH_SoNgay", _khoanBhxhSongay);
            else
                cm.Parameters.AddWithValue("@Khoan_BHXH_SoNgay", DBNull.Value);
            if (_khoanBhxhLuong != 0)
                cm.Parameters.AddWithValue("@Khoan_BHXH_Luong", _khoanBhxhLuong);
            else
                cm.Parameters.AddWithValue("@Khoan_BHXH_Luong", DBNull.Value);
            if (_khoanTruBhxh != 0)
                cm.Parameters.AddWithValue("@Khoan_Tru_BHXH", _khoanTruBhxh);
            else
                cm.Parameters.AddWithValue("@Khoan_Tru_BHXH", DBNull.Value);
            if (_khoanTruBhyt != 0)
                cm.Parameters.AddWithValue("@Khoan_Tru_BHYT", _khoanTruBhyt);
            else
                cm.Parameters.AddWithValue("@Khoan_Tru_BHYT", DBNull.Value);
            if (_khoanTruBhtn != 0)
                cm.Parameters.AddWithValue("@Khoan_Tru_BHTN", _khoanTruBhtn);
            else
                cm.Parameters.AddWithValue("@Khoan_Tru_BHTN", DBNull.Value);
            if (_khoanTruCong != 0)
                cm.Parameters.AddWithValue("@Khoan_Tru_Cong", _khoanTruCong);
            else
                cm.Parameters.AddWithValue("@Khoan_Tru_Cong", DBNull.Value);
            if (_khoanThuclanh != 0)
                cm.Parameters.AddWithValue("@Khoan_ThucLanh", _khoanThuclanh);
            else
                cm.Parameters.AddWithValue("@Khoan_ThucLanh", DBNull.Value);
            if (_tongThuNhapTinhThue != 0)
                cm.Parameters.AddWithValue("@TongThuNhapTinhThue", _tongThuNhapTinhThue);
            else
                cm.Parameters.AddWithValue("@TongThuNhapTinhThue", DBNull.Value);
            if (_phuCapTinhThue != 0)
                cm.Parameters.AddWithValue("@PhuCapTinhThue", _phuCapTinhThue);
            else
                cm.Parameters.AddWithValue("@PhuCapTinhThue", DBNull.Value);
            if (_khenThuongTinhThue != 0)
                cm.Parameters.AddWithValue("@KhenThuongTinhThue", _khenThuongTinhThue);
            else
                cm.Parameters.AddWithValue("@KhenThuongTinhThue", DBNull.Value);
            if (_khacTinhThue != 0)
                cm.Parameters.AddWithValue("@KhacTinhThue", _khacTinhThue);
            else
                cm.Parameters.AddWithValue("@KhacTinhThue", DBNull.Value);
            if (_phanTramVuotKhungBH != 0)
                cm.Parameters.AddWithValue("@PhanTramVuotKhungBH", _phanTramVuotKhungBH);
            else
                cm.Parameters.AddWithValue("@PhanTramVuotKhungBH", DBNull.Value);
            if (_heSoVuotKhungBH != 0)
                cm.Parameters.AddWithValue("@HeSoVuotKhungBH", _heSoVuotKhungBH);
            else
                cm.Parameters.AddWithValue("@HeSoVuotKhungBH", DBNull.Value);
            if (_thuLaoTinhThue != 0)
                cm.Parameters.AddWithValue("@ThuLaoTinhThue", _thuLaoTinhThue);
            else
                cm.Parameters.AddWithValue("@ThuLaoTinhThue", DBNull.Value);
            if (_truCongdoan != 0)
                cm.Parameters.AddWithValue("@Tru_CongDoan", _truCongdoan);
            else
                cm.Parameters.AddWithValue("@Tru_CongDoan", DBNull.Value);
            cm.Parameters.AddWithValue("@NgayBDTinhLuong", _ngayBDTinhLuong.DBValue);
            cm.Parameters.AddWithValue("@NgayKTTinhLuong", _ngayKTTinhLuong.DBValue);
            if (_maPhieuChi != 0)
                cm.Parameters.AddWithValue("@MaPhieuChi", _maPhieuChi);
            else
                cm.Parameters.AddWithValue("@MaPhieuChi", DBNull.Value);
            if (_phanTramThue != 0)
                cm.Parameters.AddWithValue("@PhanTramThue", _phanTramThue);
            else
                cm.Parameters.AddWithValue("@PhanTramThue", DBNull.Value);
            if (_maDeNghi != 0)
                cm.Parameters.AddWithValue("@MaDeNghi", _maDeNghi);
            else
                cm.Parameters.AddWithValue("@MaDeNghi", DBNull.Value);
            cm.Parameters.AddWithValue("@MaChiTiet", _maChiTiet);
            cm.Parameters["@MaChiTiet"].Direction = ParameterDirection.Output;
        }
        #endregion //Data Access - Insert

        #region Data Access - Update
        internal void Update(SqlTransaction tr, BangLuongKyIIList parent)
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

        private void ExecuteUpdate(SqlTransaction tr, BangLuongKyIIList parent)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_UpdatetblnsBangLuong_Ky2";

                AddUpdateParameters(cm, parent);

                cm.ExecuteNonQuery();

            }//using
        }

        private void AddUpdateParameters(SqlCommand cm, BangLuongKyIIList parent)
        {
            cm.Parameters.AddWithValue("@MaChiTiet", _maChiTiet);
            cm.Parameters.AddWithValue("@MaKyTinhLuong", _maKyTinhLuong);
            cm.Parameters.AddWithValue("@MaNhanVien", _maNhanVien);
            cm.Parameters.AddWithValue("@MaBoPhan", _maBoPhan);
            cm.Parameters.AddWithValue("@ThanhToan", _thanhToan);
            if (_soTaiKhoan.Length > 0)
                cm.Parameters.AddWithValue("@SoTaiKhoan", _soTaiKhoan);
            else
                cm.Parameters.AddWithValue("@SoTaiKhoan", DBNull.Value);
            if (_cmnd.Length > 0)
                cm.Parameters.AddWithValue("@CMND", _cmnd);
            else
                cm.Parameters.AddWithValue("@CMND", DBNull.Value);
            if (_maNganHang != 0)
                cm.Parameters.AddWithValue("@MaNganHang", _maNganHang);
            else
                cm.Parameters.AddWithValue("@MaNganHang", DBNull.Value);
            cm.Parameters.AddWithValue("@LoaiNV", _loaiNV);
            if (_maNgachLuong.Length > 0)
                cm.Parameters.AddWithValue("@MaNgachLuong", _maNgachLuong);
            else
                cm.Parameters.AddWithValue("@MaNgachLuong", DBNull.Value);
            if (_heSoCoBan != 0)
                cm.Parameters.AddWithValue("@HeSoCoBan", _heSoCoBan);
            else
                cm.Parameters.AddWithValue("@HeSoCoBan", DBNull.Value);
            if (_heSoBaoHiem != 0)
                cm.Parameters.AddWithValue("@HeSoBaoHiem", _heSoBaoHiem);
            else
                cm.Parameters.AddWithValue("@HeSoBaoHiem", DBNull.Value);
            if (_heSoNoiBo != 0)
                cm.Parameters.AddWithValue("@HeSoNoiBo", _heSoNoiBo);
            else
                cm.Parameters.AddWithValue("@HeSoNoiBo", DBNull.Value);
            if (_phanTramVuotKhung != 0)
                cm.Parameters.AddWithValue("@PhanTramVuotKhung", _phanTramVuotKhung);
            else
                cm.Parameters.AddWithValue("@PhanTramVuotKhung", DBNull.Value);
            if (_heSoVuotKhung != 0)
                cm.Parameters.AddWithValue("@HeSoVuotKhung", _heSoVuotKhung);
            else
                cm.Parameters.AddWithValue("@HeSoVuotKhung", DBNull.Value);
            if (_heSoPhuCap != 0)
                cm.Parameters.AddWithValue("@HeSoPhuCap", _heSoPhuCap);
            else
                cm.Parameters.AddWithValue("@HeSoPhuCap", DBNull.Value);
            if (_heSoDocHai != 0)
                cm.Parameters.AddWithValue("@HeSoDocHai", _heSoDocHai);
            else
                cm.Parameters.AddWithValue("@HeSoDocHai", DBNull.Value);
            if (_heSoBu != 0)
                cm.Parameters.AddWithValue("@HeSoBu", _heSoBu);
            else
                cm.Parameters.AddWithValue("@HeSoBu", DBNull.Value);
            if (_heSoBoSung != 0)
                cm.Parameters.AddWithValue("@HeSoBoSung", _heSoBoSung);
            else
                cm.Parameters.AddWithValue("@HeSoBoSung", DBNull.Value);
            if (_phuCapHanhChinh != false)
                cm.Parameters.AddWithValue("@PhuCapHanhChinh", _phuCapHanhChinh);
            else
                cm.Parameters.AddWithValue("@PhuCapHanhChinh", DBNull.Value);
            if (_luongKhoan != 0)
                cm.Parameters.AddWithValue("@LuongKhoan", _luongKhoan);
            else
                cm.Parameters.AddWithValue("@LuongKhoan", DBNull.Value);
            if (_phanTramNhan != 0)
                cm.Parameters.AddWithValue("@PhanTramNhan", _phanTramNhan);
            else
                cm.Parameters.AddWithValue("@PhanTramNhan", DBNull.Value);
            if (_luongNoiBo != 0)
                cm.Parameters.AddWithValue("@LuongNoiBo", _luongNoiBo);
            else
                cm.Parameters.AddWithValue("@LuongNoiBo", DBNull.Value);
            if (_luongCoBanNN != 0)
                cm.Parameters.AddWithValue("@LuongCoBanNN", _luongCoBanNN);
            else
                cm.Parameters.AddWithValue("@LuongCoBanNN", DBNull.Value);
            if (_donGiaThamNien != 0)
                cm.Parameters.AddWithValue("@DonGiaThamNien", _donGiaThamNien);
            else
                cm.Parameters.AddWithValue("@DonGiaThamNien", DBNull.Value);
            if (_soNamThamNien != 0)
                cm.Parameters.AddWithValue("@SoNamThamNien", _soNamThamNien);
            else
                cm.Parameters.AddWithValue("@SoNamThamNien", DBNull.Value);
            if (_luongThamNien != 0)
                cm.Parameters.AddWithValue("@LuongThamNien", _luongThamNien);
            else
                cm.Parameters.AddWithValue("@LuongThamNien", DBNull.Value);
            if (_heSoLuong != 0)
                cm.Parameters.AddWithValue("@HeSoLuong", _heSoLuong);
            else
                cm.Parameters.AddWithValue("@HeSoLuong", DBNull.Value);
            if (_luongHeSo != 0)
                cm.Parameters.AddWithValue("@LuongHeSo", _luongHeSo);
            else
                cm.Parameters.AddWithValue("@LuongHeSo", DBNull.Value);
            if (_luongKy1 != 0)
                cm.Parameters.AddWithValue("@LuongKy1", _luongKy1);
            else
                cm.Parameters.AddWithValue("@LuongKy1", DBNull.Value);
            if (_thuLao != 0)
                cm.Parameters.AddWithValue("@ThuLao", _thuLao);
            else
                cm.Parameters.AddWithValue("@ThuLao", DBNull.Value);
            if (_phuCap != 0)
                cm.Parameters.AddWithValue("@PhuCap", _phuCap);
            else
                cm.Parameters.AddWithValue("@PhuCap", DBNull.Value);
            if (_khenThuong != 0)
                cm.Parameters.AddWithValue("@KhenThuong", _khenThuong);
            else
                cm.Parameters.AddWithValue("@KhenThuong", DBNull.Value);
            if (_khac != 0)
                cm.Parameters.AddWithValue("@Khac", _khac);
            else
                cm.Parameters.AddWithValue("@Khac", DBNull.Value);
            if (_tongThuNhap != 0)
                cm.Parameters.AddWithValue("@TongThuNhap", _tongThuNhap);
            else
                cm.Parameters.AddWithValue("@TongThuNhap", DBNull.Value);
            if (_giamTruTinhThue != 0)
                cm.Parameters.AddWithValue("@GiamTruTinhThue", _giamTruTinhThue);
            else
                cm.Parameters.AddWithValue("@GiamTruTinhThue", DBNull.Value);
            if (_soNguoiPhuThuoc != 0)
                cm.Parameters.AddWithValue("@SoNguoiPhuThuoc", _soNguoiPhuThuoc);
            else
                cm.Parameters.AddWithValue("@SoNguoiPhuThuoc", DBNull.Value);
            if (_thueTNCN != 0)
                cm.Parameters.AddWithValue("@ThueTNCN", _thueTNCN);
            else
                cm.Parameters.AddWithValue("@ThueTNCN", DBNull.Value);
            if (_thueDaTamThu != 0)
                cm.Parameters.AddWithValue("@ThueDaTamThu", _thueDaTamThu);
            else
                cm.Parameters.AddWithValue("@ThueDaTamThu", DBNull.Value);
            if (_truThueTNCN != false)
                cm.Parameters.AddWithValue("@TruThueTNCN", _truThueTNCN);
            else
                cm.Parameters.AddWithValue("@TruThueTNCN", DBNull.Value);
            if (_cacKhoanDaLinh != 0)
                cm.Parameters.AddWithValue("@CacKhoanDaLinh", _cacKhoanDaLinh);
            else
                cm.Parameters.AddWithValue("@CacKhoanDaLinh", DBNull.Value);
            if (_congKhac != 0)
                cm.Parameters.AddWithValue("@CongKhac", _congKhac);
            else
                cm.Parameters.AddWithValue("@CongKhac", DBNull.Value);
            if (_thucLanh != 0)
                cm.Parameters.AddWithValue("@ThucLanh", _thucLanh);
            else
                cm.Parameters.AddWithValue("@ThucLanh", DBNull.Value);
            if (_kyHieu.Length > 0)
                cm.Parameters.AddWithValue("@KyHieu", _kyHieu);
            else
                cm.Parameters.AddWithValue("@KyHieu", DBNull.Value);
            if (_khoanNghiSongay != 0)
                cm.Parameters.AddWithValue("@Khoan_Nghi_SoNgay", _khoanNghiSongay);
            else
                cm.Parameters.AddWithValue("@Khoan_Nghi_SoNgay", DBNull.Value);
            if (_khoanNghiLuong != 0)
                cm.Parameters.AddWithValue("@Khoan_Nghi_Luong", _khoanNghiLuong);
            else
                cm.Parameters.AddWithValue("@Khoan_Nghi_Luong", DBNull.Value);
            if (_khoanBhxhSongay != 0)
                cm.Parameters.AddWithValue("@Khoan_BHXH_SoNgay", _khoanBhxhSongay);
            else
                cm.Parameters.AddWithValue("@Khoan_BHXH_SoNgay", DBNull.Value);
            if (_khoanBhxhLuong != 0)
                cm.Parameters.AddWithValue("@Khoan_BHXH_Luong", _khoanBhxhLuong);
            else
                cm.Parameters.AddWithValue("@Khoan_BHXH_Luong", DBNull.Value);
            if (_khoanTruBhxh != 0)
                cm.Parameters.AddWithValue("@Khoan_Tru_BHXH", _khoanTruBhxh);
            else
                cm.Parameters.AddWithValue("@Khoan_Tru_BHXH", DBNull.Value);
            if (_khoanTruBhyt != 0)
                cm.Parameters.AddWithValue("@Khoan_Tru_BHYT", _khoanTruBhyt);
            else
                cm.Parameters.AddWithValue("@Khoan_Tru_BHYT", DBNull.Value);
            if (_khoanTruBhtn != 0)
                cm.Parameters.AddWithValue("@Khoan_Tru_BHTN", _khoanTruBhtn);
            else
                cm.Parameters.AddWithValue("@Khoan_Tru_BHTN", DBNull.Value);
            if (_khoanTruCong != 0)
                cm.Parameters.AddWithValue("@Khoan_Tru_Cong", _khoanTruCong);
            else
                cm.Parameters.AddWithValue("@Khoan_Tru_Cong", DBNull.Value);
            if (_khoanThuclanh != 0)
                cm.Parameters.AddWithValue("@Khoan_ThucLanh", _khoanThuclanh);
            else
                cm.Parameters.AddWithValue("@Khoan_ThucLanh", DBNull.Value);
            if (_tongThuNhapTinhThue != 0)
                cm.Parameters.AddWithValue("@TongThuNhapTinhThue", _tongThuNhapTinhThue);
            else
                cm.Parameters.AddWithValue("@TongThuNhapTinhThue", DBNull.Value);
            if (_phuCapTinhThue != 0)
                cm.Parameters.AddWithValue("@PhuCapTinhThue", _phuCapTinhThue);
            else
                cm.Parameters.AddWithValue("@PhuCapTinhThue", DBNull.Value);
            if (_khenThuongTinhThue != 0)
                cm.Parameters.AddWithValue("@KhenThuongTinhThue", _khenThuongTinhThue);
            else
                cm.Parameters.AddWithValue("@KhenThuongTinhThue", DBNull.Value);
            if (_khacTinhThue != 0)
                cm.Parameters.AddWithValue("@KhacTinhThue", _khacTinhThue);
            else
                cm.Parameters.AddWithValue("@KhacTinhThue", DBNull.Value);
            if (_phanTramVuotKhungBH != 0)
                cm.Parameters.AddWithValue("@PhanTramVuotKhungBH", _phanTramVuotKhungBH);
            else
                cm.Parameters.AddWithValue("@PhanTramVuotKhungBH", DBNull.Value);
            if (_heSoVuotKhungBH != 0)
                cm.Parameters.AddWithValue("@HeSoVuotKhungBH", _heSoVuotKhungBH);
            else
                cm.Parameters.AddWithValue("@HeSoVuotKhungBH", DBNull.Value);
            if (_thuLaoTinhThue != 0)
                cm.Parameters.AddWithValue("@ThuLaoTinhThue", _thuLaoTinhThue);
            else
                cm.Parameters.AddWithValue("@ThuLaoTinhThue", DBNull.Value);
            if (_truCongdoan != 0)
                cm.Parameters.AddWithValue("@Tru_CongDoan", _truCongdoan);
            else
                cm.Parameters.AddWithValue("@Tru_CongDoan", DBNull.Value);
            cm.Parameters.AddWithValue("@NgayBDTinhLuong", _ngayBDTinhLuong.DBValue);
            cm.Parameters.AddWithValue("@NgayKTTinhLuong", _ngayKTTinhLuong.DBValue);
            if (_maPhieuChi != 0)
                cm.Parameters.AddWithValue("@MaPhieuChi", _maPhieuChi);
            else
                cm.Parameters.AddWithValue("@MaPhieuChi", DBNull.Value);
            if (_phanTramThue != 0)
                cm.Parameters.AddWithValue("@PhanTramThue", _phanTramThue);
            else
                cm.Parameters.AddWithValue("@PhanTramThue", DBNull.Value);
            if (_maDeNghi != 0)
                cm.Parameters.AddWithValue("@MaDeNghi", _maDeNghi);
            else
                cm.Parameters.AddWithValue("@MaDeNghi", DBNull.Value);
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

            ExecuteDelete(tr, new Criteria(_maChiTiet));
            MarkNew();
        }
        #endregion //Data Access - Delete
        #endregion //Data Access
    }
}
