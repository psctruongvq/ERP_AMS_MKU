
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library.Report
{
    [Serializable()]
    public class BangLuongChiTietKy1Child : Csla.ReadOnlyBase<BangLuongChiTietKy1Child>
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
        private decimal _heSoLuong = 0;
        private decimal _luongCoBanNN = 0;
        private decimal _tienLuong = 0;
        private decimal _nghiSongay = 0;
        private decimal _nghiLuong = 0;
        private decimal _bhxhSongay = 0;
        private decimal _bhxhLuong = 0;
        private decimal _truBhxh = 0;
        private decimal _truBhyt = 0;
        private decimal _truBhtn = 0;
        private decimal _truCongdoan = 0;
        private decimal _truCong = 0;
        private decimal _thucLanh = 0;
        private string _kyHieu = string.Empty;
        private string _tenNhanVien = string.Empty;
        private string _tenBoPhan = string.Empty;
        private string _maBoPhanQL = string.Empty;
        private decimal _ThueTNCN = 0;
        private int _SoNguoiPhuThuoc = 0;
        private decimal _SoTienGiamTru = 0;
        private decimal _ThucLanhSauThue = 0;

        private decimal _TruNgayLuong = 0;
        private decimal _TruBHXH = 0;
        private decimal _ChenhLechLuong = 0;

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

        public decimal HeSoLuong
        {
            get
            {
                return _heSoLuong;
            }
        }

        public decimal LuongCoBanNN
        {
            get
            {
                return _luongCoBanNN;
            }
        }

        public decimal TienLuong
        {
            get
            {
                return _tienLuong;
            }
        }

        public decimal NghiSongay
        {
            get
            {
                return _nghiSongay;
            }
        }

        public decimal NghiLuong
        {
            get
            {
                return _nghiLuong;
            }
        }

        public decimal BhxhSongay
        {
            get
            {
                return _bhxhSongay;
            }
        }

        public decimal BhxhLuong
        {
            get
            {
                return _bhxhLuong;
            }
        }

        public decimal TruBhxh
        {
            get
            {
                return _truBhxh;
            }
        }

        public decimal TruBhyt
        {
            get
            {
                return _truBhyt;
            }
        }

        public decimal TruBhtn
        {
            get
            {
                return _truBhtn;
            }
        }

        public decimal TruCongdoan
        {
            get
            {
                return _truCongdoan;
            }
        }

        public decimal TruCong
        {
            get
            {
                return _truCong;
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

        public decimal ThueTNCN
        {
            get
            {
                return _ThueTNCN;
            }
        }

        public decimal SoNguoiPhuThuoc
        {
            get
            {
                return _SoNguoiPhuThuoc;
            }
        }

        public decimal SoTienGiamTru
        {
            get
            {
                return _SoTienGiamTru;
            }
        }

        public decimal ThucLanhSauThue
        {
            get
            {
                return _ThucLanhSauThue;
            }
        }

        public decimal TruNgayLuong
        {
            get
            {
                return _TruNgayLuong;
            }
        }

        public decimal TruBHXH
        {
            get
            {
                return _TruBHXH;
            }
        }

        public decimal ChenhLechLuong
        {
            get
            {
                return _ChenhLechLuong;
            }
        }

        protected override object GetIdValue()
        {
            return _maChiTiet;
        }

        #endregion //Business Properties and Methods

        #region Factory Methods
        internal static BangLuongChiTietKy1Child GetBangLuongChiTietKy1Child(SafeDataReader dr)
        {
            return new BangLuongChiTietKy1Child(dr);
        }

        private BangLuongChiTietKy1Child(SafeDataReader dr)
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
            _heSoLuong = dr.GetDecimal("HeSoLuong");
            _luongCoBanNN = dr.GetDecimal("LuongCoBanNN");
            _tienLuong = dr.GetDecimal("TienLuong");
            _nghiSongay = dr.GetDecimal("Nghi_SoNgay");
            _nghiLuong = dr.GetDecimal("Nghi_Luong");
            _bhxhSongay = dr.GetDecimal("BHXH_SoNgay");
            _bhxhLuong = dr.GetDecimal("BHXH_Luong");
            _truBhxh = dr.GetDecimal("Tru_BHXH");
            _truBhyt = dr.GetDecimal("Tru_BHYT");
            _truBhtn = dr.GetDecimal("Tru_BHTN");
            _truCongdoan = dr.GetDecimal("Tru_CongDoan");
            _truCong = dr.GetDecimal("Tru_Cong");
            _thucLanh = dr.GetDecimal("ThucLanh");
            _kyHieu = dr.GetString("KyHieu");
            _tenNhanVien = dr.GetString("TenNhanVien");
            _tenBoPhan = dr.GetString("TenBoPhan");
            _maBoPhanQL = dr.GetString("MaBoPhanQL");
            _ThueTNCN = dr.GetDecimal("ThueTNCN");
            _SoNguoiPhuThuoc = dr.GetInt32("SoNguoiPhuThuoc");
            _SoTienGiamTru = dr.GetDecimal("SoTienGiamTru");
            _ThucLanhSauThue = dr.GetDecimal("ThucLanhSauThue");

            _TruNgayLuong = dr.GetDecimal("TruNgayLuong");
            _TruBHXH = dr.GetDecimal("TruBHXH");
            _ChenhLechLuong = dr.GetDecimal("ChenhLechLuong");
        }

        private void FetchChildren(SafeDataReader dr)
        {
        }
        #endregion //Data Access - Fetch
        #endregion //Data Access
    }
}
