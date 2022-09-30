
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library.Report
{
    [Serializable()]
    public class BangLuongChiTietKy2Child : Csla.ReadOnlyBase<BangLuongChiTietKy2Child>
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
        private string _tenNhanVien = string.Empty;
        private string _tenBoPhan = string.Empty;
        private string _maBoPhanQL = string.Empty;
        private decimal _truCongDoan = 0;
        private DateTime _ngayBDTinhLuong;
        private DateTime _ngayKTTinhLuong;

        public int MaChiTiet
        {
            get
            {
                return _maChiTiet;
            }
        }

        [System.ComponentModel.DataObjectField(true, false)]
        public int MaKyTinhLuong
        {
            get
            {
                return _maKyTinhLuong;
            }
        }

        public long MaNhanVien
        {
            get
            {
                return _maNhanVien;
            }
        }

        [System.ComponentModel.DataObjectField(true, false)]
        public int MaBoPhan
        {
            get
            {
                return _maBoPhan;
            }
        }

        public int ThanhToan
        {
            get
            {
                return _thanhToan;
            }
        }

        public string SoTaiKhoan
        {
            get
            {
                return _soTaiKhoan;
            }
        }

        public string Cmnd
        {
            get
            {
                return _cmnd;
            }
        }

        [System.ComponentModel.DataObjectField(true, false)]
        public int MaNganHang
        {
            get
            {
                return _maNganHang;
            }
        }

        [System.ComponentModel.DataObjectField(true, false)]
        public int LoaiNV
        {
            get
            {
                return _loaiNV;
            }
        }

        public string MaNgachLuong
        {
            get
            {
                return _maNgachLuong;
            }
        }

        public decimal HeSoCoBan
        {
            get
            {
                return _heSoCoBan;
            }
        }

        public decimal HeSoBaoHiem
        {
            get
            {
                return _heSoBaoHiem;
            }
        }

        public decimal HeSoNoiBo
        {
            get
            {
                return _heSoNoiBo;
            }
        }

        public decimal PhanTramVuotKhung
        {
            get
            {
                return _phanTramVuotKhung;
            }
        }

        public decimal HeSoVuotKhung
        {
            get
            {
                return _heSoVuotKhung;
            }
        }

        public decimal HeSoPhuCap
        {
            get
            {
                return _heSoPhuCap;
            }
        }

        public decimal HeSoDocHai
        {
            get
            {
                return _heSoDocHai;
            }
        }

        public decimal HeSoBu
        {
            get
            {
                return _heSoBu;
            }
        }

        public decimal HeSoBoSung
        {
            get
            {
                return _heSoBoSung;
            }
        }

        public bool PhuCapHanhChinh
        {
            get
            {
                return _phuCapHanhChinh;
            }
        }

        public decimal LuongKhoan
        {
            get
            {
                return _luongKhoan;
            }
        }

        public decimal PhanTramNhan
        {
            get
            {
                return _phanTramNhan;
            }
        }

        public decimal LuongNoiBo
        {
            get
            {
                return _luongNoiBo;
            }
        }

        public decimal LuongCoBanNN
        {
            get
            {
                return _luongCoBanNN;
            }
        }

        public decimal DonGiaThamNien
        {
            get
            {
                return _donGiaThamNien;
            }
        }

        public int SoNamThamNien
        {
            get
            {
                return _soNamThamNien;
            }
        }

        public decimal LuongThamNien
        {
            get
            {
                return _luongThamNien;
            }
        }

        public decimal HeSoLuong
        {
            get
            {
                return _heSoLuong;
            }
        }

        public decimal LuongHeSo
        {
            get
            {
                return _luongHeSo;
            }
        }

        public decimal LuongKy1
        {
            get
            {
                return _luongKy1;
            }
        }

        public decimal ThuLao
        {
            get
            {
                return _thuLao;
            }
        }

        public decimal PhuCap
        {
            get
            {
                return _phuCap;
            }
        }

        public decimal KhenThuong
        {
            get
            {
                return _khenThuong;
            }
        }

        public decimal Khac
        {
            get
            {
                return _khac;
            }
        }

        public decimal TongThuNhap
        {
            get
            {
                return _tongThuNhap;
            }
        }

        public decimal GiamTruTinhThue
        {
            get
            {
                return _giamTruTinhThue;
            }
        }

        public int SoNguoiPhuThuoc
        {
            get
            {
                return _soNguoiPhuThuoc;
            }
        }

        public decimal ThueTNCN
        {
            get
            {
                return _thueTNCN;
            }
        }

        public decimal ThueDaTamThu
        {
            get
            {
                return _thueDaTamThu;
            }
        }

        public bool TruThueTNCN
        {
            get
            {
                return _truThueTNCN;
            }
        }

        public decimal CacKhoanDaLinh
        {
            get
            {
                return _cacKhoanDaLinh;
            }
        }

        public decimal CongKhac
        {
            get
            {
                return _congKhac;
            }
        }

        public decimal ThucLanh
        {
            get
            {
                return _thucLanh;
            }
        }

        public string KyHieu
        {
            get
            {
                return _kyHieu;
            }
        }

        public int KhoanNghiSongay
        {
            get
            {
                return _khoanNghiSongay;
            }
        }

        public decimal KhoanNghiLuong
        {
            get
            {
                return _khoanNghiLuong;
            }
        }

        public int KhoanBhxhSongay
        {
            get
            {
                return _khoanBhxhSongay;
            }
        }

        public decimal KhoanBhxhLuong
        {
            get
            {
                return _khoanBhxhLuong;
            }
        }

        public decimal KhoanTruBhxh
        {
            get
            {
                return _khoanTruBhxh;
            }
        }

        public decimal KhoanTruBhyt
        {
            get
            {
                return _khoanTruBhyt;
            }
        }

        public decimal KhoanTruBhtn
        {
            get
            {
                return _khoanTruBhtn;
            }
        }

        public decimal KhoanTruCong
        {
            get
            {
                return _khoanTruCong;
            }
        }
        public decimal TruCongDoan
        {
            get
            {
                return _truCongDoan;
            }
        }


        public decimal KhoanThuclanh
        {
            get
            {
                return _khoanThuclanh;
            }
        }

        public string TenNhanVien
        {
            get
            {
                return _tenNhanVien;
            }
        }

        public string TenBoPhan
        {
            get
            {
                return _tenBoPhan;
            }
        }

        public string MaBoPhanQL
        {
            get
            {
                return _maBoPhanQL;
            }
        }

        public decimal ThueConPhaiThuTra
        {
            get
            {
                return _thueTNCN - _thueDaTamThu;
            }
        }

        public decimal ThucLanhTinhTamThu
        {
            get
            {
                return _luongHeSo + _luongThamNien - _thueTNCN + _thueDaTamThu;
            }
        }

        public DateTime NgayBDTinhLuong
        {
            get
            {
                return _ngayBDTinhLuong;
            }
        }
        public DateTime NgayKTTinhLuong
        {
            get
            {
                return _ngayKTTinhLuong;
            }
        }
        protected override object GetIdValue()
        {
            return string.Format("{0}:{1}", _maKyTinhLuong, _maNhanVien);
        }

        #endregion //Business Properties and Methods

        #region Factory Methods
        internal static BangLuongChiTietKy2Child GetBangLuongChiTietKy2Child(SafeDataReader dr)
        {
            return new BangLuongChiTietKy2Child(dr);
        }

        private BangLuongChiTietKy2Child(SafeDataReader dr)
        {
            Fetch(dr);
        }
        #endregion //Factory Methods


        #region Data Access

        #region Data Access - Fetch
        private void Fetch(SafeDataReader dr)
        {
            FetchObject(dr);

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
            _tenNhanVien = dr.GetString("TenNhanVien");
            _tenBoPhan = dr.GetString("TenBoPhan");
            _maBoPhanQL = dr.GetString("MaBoPhanQL");
            _truCongDoan = dr.GetDecimal("Tru_CongDoan");
            if(dr.GetDateTime("NgayBDTinhLuong")!= DateTime.MinValue)
            {
                _ngayBDTinhLuong = dr.GetDateTime("NgayBDTinhLuong");
            }
            if (dr.GetDateTime("NgayKTTinhLuong") != DateTime.MinValue)
            {
                _ngayKTTinhLuong = dr.GetDateTime("NgayKTTinhLuong");
            }
        }

        private void FetchChildren(SafeDataReader dr)
        {
        }
        #endregion //Data Access - Fetch
        #endregion //Data Access
    }
}
