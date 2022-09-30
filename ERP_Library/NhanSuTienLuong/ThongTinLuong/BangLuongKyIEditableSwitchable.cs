
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{
    [Serializable()]
    public class BangLuongKyI : Csla.BusinessBase<BangLuongKyI>
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
        private decimal _phanTramVuotKhungBH = 0;
        private decimal _heSoVuotKhungBH = 0;
        private decimal _thueTNCN = 0;
        private int _soNguoiPhuThuoc = 0;
        private decimal _soTienGiamTru = 0;
        private decimal _thucLanhSauThue = 0;
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

        public decimal TienLuong
        {
            get
            {
                CanReadProperty("TienLuong", true);
                return _tienLuong;
            }
            set
            {
                CanWriteProperty("TienLuong", true);
                if (!_tienLuong.Equals(value))
                {
                    _tienLuong = value;
                    PropertyHasChanged("TienLuong");
                }
            }
        }

        public decimal NghiSongay
        {
            get
            {
                CanReadProperty("NghiSongay", true);
                return _nghiSongay;
            }
            set
            {
                CanWriteProperty("NghiSongay", true);
                if (!_nghiSongay.Equals(value))
                {
                    _nghiSongay = value;
                    PropertyHasChanged("NghiSongay");
                }
            }
        }

        public decimal NghiLuong
        {
            get
            {
                CanReadProperty("NghiLuong", true);
                return _nghiLuong;
            }
            set
            {
                CanWriteProperty("NghiLuong", true);
                if (!_nghiLuong.Equals(value))
                {
                    _nghiLuong = value;
                    PropertyHasChanged("NghiLuong");
                }
            }
        }

        public decimal BhxhSongay
        {
            get
            {
                CanReadProperty("BhxhSongay", true);
                return _bhxhSongay;
            }
            set
            {
                CanWriteProperty("BhxhSongay", true);
                if (!_bhxhSongay.Equals(value))
                {
                    _bhxhSongay = value;
                    PropertyHasChanged("BhxhSongay");
                }
            }
        }

        public decimal BhxhLuong
        {
            get
            {
                CanReadProperty("BhxhLuong", true);
                return _bhxhLuong;
            }
            set
            {
                CanWriteProperty("BhxhLuong", true);
                if (!_bhxhLuong.Equals(value))
                {
                    _bhxhLuong = value;
                    PropertyHasChanged("BhxhLuong");
                }
            }
        }

        public decimal TruBhxh
        {
            get
            {
                CanReadProperty("TruBhxh", true);
                return _truBhxh;
            }
            set
            {
                CanWriteProperty("TruBhxh", true);
                if (!_truBhxh.Equals(value))
                {
                    _truBhxh = value;
                    PropertyHasChanged("TruBhxh");
                }
            }
        }

        public decimal TruBhyt
        {
            get
            {
                CanReadProperty("TruBhyt", true);
                return _truBhyt;
            }
            set
            {
                CanWriteProperty("TruBhyt", true);
                if (!_truBhyt.Equals(value))
                {
                    _truBhyt = value;
                    PropertyHasChanged("TruBhyt");
                }
            }
        }

        public decimal TruBhtn
        {
            get
            {
                CanReadProperty("TruBhtn", true);
                return _truBhtn;
            }
            set
            {
                CanWriteProperty("TruBhtn", true);
                if (!_truBhtn.Equals(value))
                {
                    _truBhtn = value;
                    PropertyHasChanged("TruBhtn");
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

        public decimal TruCong
        {
            get
            {
                CanReadProperty("TruCong", true);
                return _truCong;
            }
            set
            {
                CanWriteProperty("TruCong", true);
                if (!_truCong.Equals(value))
                {
                    _truCong = value;
                    PropertyHasChanged("TruCong");
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

        public decimal SoTienGiamTru
        {
            get
            {
                CanReadProperty("SoTienGiamTru", true);
                return _soTienGiamTru;
            }
            set
            {
                CanWriteProperty("SoTienGiamTru", true);
                if (!_soTienGiamTru.Equals(value))
                {
                    _soTienGiamTru = value;
                    PropertyHasChanged("SoTienGiamTru");
                }
            }
        }

        public decimal ThucLanhSauThue
        {
            get
            {
                CanReadProperty("ThucLanhSauThue", true);
                return _thucLanhSauThue;
            }
            set
            {
                CanWriteProperty("ThucLanhSauThue", true);
                if (!_thucLanhSauThue.Equals(value))
                {
                    _thucLanhSauThue = value;
                    PropertyHasChanged("ThucLanhSauThue");
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
            //TODO: Define authorization rules in BangLuongKyI
            //AuthorizationRules.AllowRead("MaChiTiet", "BangLuongKyIReadGroup");
            //AuthorizationRules.AllowRead("MaKyTinhLuong", "BangLuongKyIReadGroup");
            //AuthorizationRules.AllowRead("MaNhanVien", "BangLuongKyIReadGroup");
            //AuthorizationRules.AllowRead("MaBoPhan", "BangLuongKyIReadGroup");
            //AuthorizationRules.AllowRead("ThanhToan", "BangLuongKyIReadGroup");
            //AuthorizationRules.AllowRead("SoTaiKhoan", "BangLuongKyIReadGroup");
            //AuthorizationRules.AllowRead("Cmnd", "BangLuongKyIReadGroup");
            //AuthorizationRules.AllowRead("MaNganHang", "BangLuongKyIReadGroup");
            //AuthorizationRules.AllowRead("LoaiNV", "BangLuongKyIReadGroup");
            //AuthorizationRules.AllowRead("MaNgachLuong", "BangLuongKyIReadGroup");
            //AuthorizationRules.AllowRead("HeSoCoBan", "BangLuongKyIReadGroup");
            //AuthorizationRules.AllowRead("HeSoBaoHiem", "BangLuongKyIReadGroup");
            //AuthorizationRules.AllowRead("HeSoNoiBo", "BangLuongKyIReadGroup");
            //AuthorizationRules.AllowRead("PhanTramVuotKhung", "BangLuongKyIReadGroup");
            //AuthorizationRules.AllowRead("HeSoVuotKhung", "BangLuongKyIReadGroup");
            //AuthorizationRules.AllowRead("HeSoPhuCap", "BangLuongKyIReadGroup");
            //AuthorizationRules.AllowRead("HeSoDocHai", "BangLuongKyIReadGroup");
            //AuthorizationRules.AllowRead("HeSoBu", "BangLuongKyIReadGroup");
            //AuthorizationRules.AllowRead("HeSoBoSung", "BangLuongKyIReadGroup");
            //AuthorizationRules.AllowRead("PhuCapHanhChinh", "BangLuongKyIReadGroup");
            //AuthorizationRules.AllowRead("LuongKhoan", "BangLuongKyIReadGroup");
            //AuthorizationRules.AllowRead("PhanTramNhan", "BangLuongKyIReadGroup");
            //AuthorizationRules.AllowRead("HeSoLuong", "BangLuongKyIReadGroup");
            //AuthorizationRules.AllowRead("LuongCoBanNN", "BangLuongKyIReadGroup");
            //AuthorizationRules.AllowRead("TienLuong", "BangLuongKyIReadGroup");
            //AuthorizationRules.AllowRead("NghiSongay", "BangLuongKyIReadGroup");
            //AuthorizationRules.AllowRead("NghiLuong", "BangLuongKyIReadGroup");
            //AuthorizationRules.AllowRead("BhxhSongay", "BangLuongKyIReadGroup");
            //AuthorizationRules.AllowRead("BhxhLuong", "BangLuongKyIReadGroup");
            //AuthorizationRules.AllowRead("TruBhxh", "BangLuongKyIReadGroup");
            //AuthorizationRules.AllowRead("TruBhyt", "BangLuongKyIReadGroup");
            //AuthorizationRules.AllowRead("TruBhtn", "BangLuongKyIReadGroup");
            //AuthorizationRules.AllowRead("TruCongdoan", "BangLuongKyIReadGroup");
            //AuthorizationRules.AllowRead("TruCong", "BangLuongKyIReadGroup");
            //AuthorizationRules.AllowRead("ThucLanh", "BangLuongKyIReadGroup");
            //AuthorizationRules.AllowRead("KyHieu", "BangLuongKyIReadGroup");
            //AuthorizationRules.AllowRead("PhanTramVuotKhungBH", "BangLuongKyIReadGroup");
            //AuthorizationRules.AllowRead("HeSoVuotKhungBH", "BangLuongKyIReadGroup");
            //AuthorizationRules.AllowRead("ThueTNCN", "BangLuongKyIReadGroup");
            //AuthorizationRules.AllowRead("SoNguoiPhuThuoc", "BangLuongKyIReadGroup");
            //AuthorizationRules.AllowRead("SoTienGiamTru", "BangLuongKyIReadGroup");
            //AuthorizationRules.AllowRead("ThucLanhSauThue", "BangLuongKyIReadGroup");
            //AuthorizationRules.AllowRead("MaPhieuChi", "BangLuongKyIReadGroup");
            //AuthorizationRules.AllowRead("PhanTramThue", "BangLuongKyIReadGroup");
            //AuthorizationRules.AllowRead("MaDeNghi", "BangLuongKyIReadGroup");

            //AuthorizationRules.AllowWrite("MaKyTinhLuong", "BangLuongKyIWriteGroup");
            //AuthorizationRules.AllowWrite("MaNhanVien", "BangLuongKyIWriteGroup");
            //AuthorizationRules.AllowWrite("MaBoPhan", "BangLuongKyIWriteGroup");
            //AuthorizationRules.AllowWrite("ThanhToan", "BangLuongKyIWriteGroup");
            //AuthorizationRules.AllowWrite("SoTaiKhoan", "BangLuongKyIWriteGroup");
            //AuthorizationRules.AllowWrite("Cmnd", "BangLuongKyIWriteGroup");
            //AuthorizationRules.AllowWrite("MaNganHang", "BangLuongKyIWriteGroup");
            //AuthorizationRules.AllowWrite("LoaiNV", "BangLuongKyIWriteGroup");
            //AuthorizationRules.AllowWrite("MaNgachLuong", "BangLuongKyIWriteGroup");
            //AuthorizationRules.AllowWrite("HeSoCoBan", "BangLuongKyIWriteGroup");
            //AuthorizationRules.AllowWrite("HeSoBaoHiem", "BangLuongKyIWriteGroup");
            //AuthorizationRules.AllowWrite("HeSoNoiBo", "BangLuongKyIWriteGroup");
            //AuthorizationRules.AllowWrite("PhanTramVuotKhung", "BangLuongKyIWriteGroup");
            //AuthorizationRules.AllowWrite("HeSoVuotKhung", "BangLuongKyIWriteGroup");
            //AuthorizationRules.AllowWrite("HeSoPhuCap", "BangLuongKyIWriteGroup");
            //AuthorizationRules.AllowWrite("HeSoDocHai", "BangLuongKyIWriteGroup");
            //AuthorizationRules.AllowWrite("HeSoBu", "BangLuongKyIWriteGroup");
            //AuthorizationRules.AllowWrite("HeSoBoSung", "BangLuongKyIWriteGroup");
            //AuthorizationRules.AllowWrite("PhuCapHanhChinh", "BangLuongKyIWriteGroup");
            //AuthorizationRules.AllowWrite("LuongKhoan", "BangLuongKyIWriteGroup");
            //AuthorizationRules.AllowWrite("PhanTramNhan", "BangLuongKyIWriteGroup");
            //AuthorizationRules.AllowWrite("HeSoLuong", "BangLuongKyIWriteGroup");
            //AuthorizationRules.AllowWrite("LuongCoBanNN", "BangLuongKyIWriteGroup");
            //AuthorizationRules.AllowWrite("TienLuong", "BangLuongKyIWriteGroup");
            //AuthorizationRules.AllowWrite("NghiSongay", "BangLuongKyIWriteGroup");
            //AuthorizationRules.AllowWrite("NghiLuong", "BangLuongKyIWriteGroup");
            //AuthorizationRules.AllowWrite("BhxhSongay", "BangLuongKyIWriteGroup");
            //AuthorizationRules.AllowWrite("BhxhLuong", "BangLuongKyIWriteGroup");
            //AuthorizationRules.AllowWrite("TruBhxh", "BangLuongKyIWriteGroup");
            //AuthorizationRules.AllowWrite("TruBhyt", "BangLuongKyIWriteGroup");
            //AuthorizationRules.AllowWrite("TruBhtn", "BangLuongKyIWriteGroup");
            //AuthorizationRules.AllowWrite("TruCongdoan", "BangLuongKyIWriteGroup");
            //AuthorizationRules.AllowWrite("TruCong", "BangLuongKyIWriteGroup");
            //AuthorizationRules.AllowWrite("ThucLanh", "BangLuongKyIWriteGroup");
            //AuthorizationRules.AllowWrite("KyHieu", "BangLuongKyIWriteGroup");
            //AuthorizationRules.AllowWrite("PhanTramVuotKhungBH", "BangLuongKyIWriteGroup");
            //AuthorizationRules.AllowWrite("HeSoVuotKhungBH", "BangLuongKyIWriteGroup");
            //AuthorizationRules.AllowWrite("ThueTNCN", "BangLuongKyIWriteGroup");
            //AuthorizationRules.AllowWrite("SoNguoiPhuThuoc", "BangLuongKyIWriteGroup");
            //AuthorizationRules.AllowWrite("SoTienGiamTru", "BangLuongKyIWriteGroup");
            //AuthorizationRules.AllowWrite("ThucLanhSauThue", "BangLuongKyIWriteGroup");
            //AuthorizationRules.AllowWrite("MaPhieuChi", "BangLuongKyIWriteGroup");
            //AuthorizationRules.AllowWrite("PhanTramThue", "BangLuongKyIWriteGroup");
            //AuthorizationRules.AllowWrite("MaDeNghi", "BangLuongKyIWriteGroup");
        }


        public static bool CanGetObject()
        {
            //TODO: Define CanGetObject permission in BangLuongKyI
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("BangLuongKyIViewGroup"))
            //	return true;
            //return false;
        }

        public static bool CanAddObject()
        {
            //TODO: Define CanAddObject permission in BangLuongKyI
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("BangLuongKyIAddGroup"))
            //	return true;
            //return false;
        }

        public static bool CanEditObject()
        {
            //TODO: Define CanEditObject permission in BangLuongKyI
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("BangLuongKyIEditGroup"))
            //	return true;
            //return false;
        }

        public static bool CanDeleteObject()
        {
            //TODO: Define CanDeleteObject permission in BangLuongKyI
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("BangLuongKyIDeleteGroup"))
            //	return true;
            //return false;
        }
        #endregion //Authorization Rules

        #region Factory Methods
        private BangLuongKyI()
        { /* require use of factory method */ }

        public static BangLuongKyI NewBangLuongKyI()
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a BangLuongKyI");
            return DataPortal.Create<BangLuongKyI>();
        }

        public static BangLuongKyI GetBangLuongKyI(int maChiTiet)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a BangLuongKyI");
            return DataPortal.Fetch<BangLuongKyI>(new Criteria(maChiTiet));
        }

        public static void DeleteBangLuongKyI(int maChiTiet)
        {
            if (!CanDeleteObject())
                throw new System.Security.SecurityException("User not authorized to remove a BangLuongKyI");
            DataPortal.Delete(new Criteria(maChiTiet));
        }

        public override BangLuongKyI Save()
        {
            if (IsDeleted && !CanDeleteObject())
                throw new System.Security.SecurityException("User not authorized to remove a BangLuongKyI");
            else if (IsNew && !CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a BangLuongKyI");
            else if (!CanEditObject())
                throw new System.Security.SecurityException("User not authorized to update a BangLuongKyI");

            return base.Save();
        }

        #endregion //Factory Methods

        #region Child Factory Methods
        internal static BangLuongKyI NewBangLuongKyIChild()
        {
            BangLuongKyI child = new BangLuongKyI();
            child.ValidationRules.CheckRules();
            child.MarkAsChild();
            return child;
        }

        internal static BangLuongKyI GetBangLuongKyI(SafeDataReader dr)
        {
            BangLuongKyI child = new BangLuongKyI();
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
                cm.CommandText = "spd_SelecttblBangLuongKyI";

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
                cm.CommandText = "spd_DeletetblBangLuongKyI";

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
            _phanTramVuotKhungBH = dr.GetDecimal("PhanTramVuotKhungBH");
            _heSoVuotKhungBH = dr.GetDecimal("HeSoVuotKhungBH");
            _thueTNCN = dr.GetDecimal("ThueTNCN");
            _soNguoiPhuThuoc = dr.GetInt32("SoNguoiPhuThuoc");
            _soTienGiamTru = dr.GetDecimal("SoTienGiamTru");
            _thucLanhSauThue = dr.GetDecimal("ThucLanhSauThue");
            _maPhieuChi = dr.GetInt64("MaPhieuChi");
            _phanTramThue = dr.GetDecimal("PhanTramThue");
            _maDeNghi = dr.GetInt64("MaDeNghi");
        }

        private void FetchChildren(SafeDataReader dr)
        {
        }
        #endregion //Data Access - Fetch

        #region Data Access - Insert
        internal void Insert(SqlTransaction tr, BangLuongKyIList parent)
        {
            if (!IsDirty) return;

            ExecuteInsert(tr, parent);
            MarkOld();

            //update child object(s)
            UpdateChildren(tr);
        }

        private void ExecuteInsert(SqlTransaction tr, BangLuongKyIList parent)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_InserttblBangLuongKyI";

                AddInsertParameters(cm, parent);

                cm.ExecuteNonQuery();

                _maChiTiet = (int)cm.Parameters["@NewMaChiTiet"].Value;
            }//using
        }

        private void AddInsertParameters(SqlCommand cm, BangLuongKyIList parent)
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
            if (_heSoLuong != 0)
                cm.Parameters.AddWithValue("@HeSoLuong", _heSoLuong);
            else
                cm.Parameters.AddWithValue("@HeSoLuong", DBNull.Value);
            if (_luongCoBanNN != 0)
                cm.Parameters.AddWithValue("@LuongCoBanNN", _luongCoBanNN);
            else
                cm.Parameters.AddWithValue("@LuongCoBanNN", DBNull.Value);
            if (_tienLuong != 0)
                cm.Parameters.AddWithValue("@TienLuong", _tienLuong);
            else
                cm.Parameters.AddWithValue("@TienLuong", DBNull.Value);
            if (_nghiSongay != 0)
                cm.Parameters.AddWithValue("@Nghi_SoNgay", _nghiSongay);
            else
                cm.Parameters.AddWithValue("@Nghi_SoNgay", DBNull.Value);
            if (_nghiLuong != 0)
                cm.Parameters.AddWithValue("@Nghi_Luong", _nghiLuong);
            else
                cm.Parameters.AddWithValue("@Nghi_Luong", DBNull.Value);
            if (_bhxhSongay != 0)
                cm.Parameters.AddWithValue("@BHXH_SoNgay", _bhxhSongay);
            else
                cm.Parameters.AddWithValue("@BHXH_SoNgay", DBNull.Value);
            if (_bhxhLuong != 0)
                cm.Parameters.AddWithValue("@BHXH_Luong", _bhxhLuong);
            else
                cm.Parameters.AddWithValue("@BHXH_Luong", DBNull.Value);
            if (_truBhxh != 0)
                cm.Parameters.AddWithValue("@Tru_BHXH", _truBhxh);
            else
                cm.Parameters.AddWithValue("@Tru_BHXH", DBNull.Value);
            if (_truBhyt != 0)
                cm.Parameters.AddWithValue("@Tru_BHYT", _truBhyt);
            else
                cm.Parameters.AddWithValue("@Tru_BHYT", DBNull.Value);
            if (_truBhtn != 0)
                cm.Parameters.AddWithValue("@Tru_BHTN", _truBhtn);
            else
                cm.Parameters.AddWithValue("@Tru_BHTN", DBNull.Value);
            if (_truCongdoan != 0)
                cm.Parameters.AddWithValue("@Tru_CongDoan", _truCongdoan);
            else
                cm.Parameters.AddWithValue("@Tru_CongDoan", DBNull.Value);
            if (_truCong != 0)
                cm.Parameters.AddWithValue("@Tru_Cong", _truCong);
            else
                cm.Parameters.AddWithValue("@Tru_Cong", DBNull.Value);
            if (_thucLanh != 0)
                cm.Parameters.AddWithValue("@ThucLanh", _thucLanh);
            else
                cm.Parameters.AddWithValue("@ThucLanh", DBNull.Value);
            if (_kyHieu.Length > 0)
                cm.Parameters.AddWithValue("@KyHieu", _kyHieu);
            else
                cm.Parameters.AddWithValue("@KyHieu", DBNull.Value);
            if (_phanTramVuotKhungBH != 0)
                cm.Parameters.AddWithValue("@PhanTramVuotKhungBH", _phanTramVuotKhungBH);
            else
                cm.Parameters.AddWithValue("@PhanTramVuotKhungBH", DBNull.Value);
            if (_heSoVuotKhungBH != 0)
                cm.Parameters.AddWithValue("@HeSoVuotKhungBH", _heSoVuotKhungBH);
            else
                cm.Parameters.AddWithValue("@HeSoVuotKhungBH", DBNull.Value);
            if (_thueTNCN != 0)
                cm.Parameters.AddWithValue("@ThueTNCN", _thueTNCN);
            else
                cm.Parameters.AddWithValue("@ThueTNCN", DBNull.Value);
            if (_soNguoiPhuThuoc != 0)
                cm.Parameters.AddWithValue("@SoNguoiPhuThuoc", _soNguoiPhuThuoc);
            else
                cm.Parameters.AddWithValue("@SoNguoiPhuThuoc", DBNull.Value);
            if (_soTienGiamTru != 0)
                cm.Parameters.AddWithValue("@SoTienGiamTru", _soTienGiamTru);
            else
                cm.Parameters.AddWithValue("@SoTienGiamTru", DBNull.Value);
            if (_thucLanhSauThue != 0)
                cm.Parameters.AddWithValue("@ThucLanhSauThue", _thucLanhSauThue);
            else
                cm.Parameters.AddWithValue("@ThucLanhSauThue", DBNull.Value);
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
        internal void Update(SqlTransaction tr, BangLuongKyIList parent)
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

        private void ExecuteUpdate(SqlTransaction tr, BangLuongKyIList parent)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_UpdatetblnsBangLuong_Ky1";

                AddUpdateParameters(cm, parent);

                cm.ExecuteNonQuery();

            }//using
        }

        private void AddUpdateParameters(SqlCommand cm, BangLuongKyIList parent)
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
            if (_heSoLuong != 0)
                cm.Parameters.AddWithValue("@HeSoLuong", _heSoLuong);
            else
                cm.Parameters.AddWithValue("@HeSoLuong", DBNull.Value);
            if (_luongCoBanNN != 0)
                cm.Parameters.AddWithValue("@LuongCoBanNN", _luongCoBanNN);
            else
                cm.Parameters.AddWithValue("@LuongCoBanNN", DBNull.Value);
            if (_tienLuong != 0)
                cm.Parameters.AddWithValue("@TienLuong", _tienLuong);
            else
                cm.Parameters.AddWithValue("@TienLuong", DBNull.Value);
            if (_nghiSongay != 0)
                cm.Parameters.AddWithValue("@Nghi_SoNgay", _nghiSongay);
            else
                cm.Parameters.AddWithValue("@Nghi_SoNgay", DBNull.Value);
            if (_nghiLuong != 0)
                cm.Parameters.AddWithValue("@Nghi_Luong", _nghiLuong);
            else
                cm.Parameters.AddWithValue("@Nghi_Luong", DBNull.Value);
            if (_bhxhSongay != 0)
                cm.Parameters.AddWithValue("@BHXH_SoNgay", _bhxhSongay);
            else
                cm.Parameters.AddWithValue("@BHXH_SoNgay", DBNull.Value);
            if (_bhxhLuong != 0)
                cm.Parameters.AddWithValue("@BHXH_Luong", _bhxhLuong);
            else
                cm.Parameters.AddWithValue("@BHXH_Luong", DBNull.Value);
            if (_truBhxh != 0)
                cm.Parameters.AddWithValue("@Tru_BHXH", _truBhxh);
            else
                cm.Parameters.AddWithValue("@Tru_BHXH", DBNull.Value);
            if (_truBhyt != 0)
                cm.Parameters.AddWithValue("@Tru_BHYT", _truBhyt);
            else
                cm.Parameters.AddWithValue("@Tru_BHYT", DBNull.Value);
            if (_truBhtn != 0)
                cm.Parameters.AddWithValue("@Tru_BHTN", _truBhtn);
            else
                cm.Parameters.AddWithValue("@Tru_BHTN", DBNull.Value);
            if (_truCongdoan != 0)
                cm.Parameters.AddWithValue("@Tru_CongDoan", _truCongdoan);
            else
                cm.Parameters.AddWithValue("@Tru_CongDoan", DBNull.Value);
            if (_truCong != 0)
                cm.Parameters.AddWithValue("@Tru_Cong", _truCong);
            else
                cm.Parameters.AddWithValue("@Tru_Cong", DBNull.Value);
            if (_thucLanh != 0)
                cm.Parameters.AddWithValue("@ThucLanh", _thucLanh);
            else
                cm.Parameters.AddWithValue("@ThucLanh", DBNull.Value);
            if (_kyHieu.Length > 0)
                cm.Parameters.AddWithValue("@KyHieu", _kyHieu);
            else
                cm.Parameters.AddWithValue("@KyHieu", DBNull.Value);
            if (_phanTramVuotKhungBH != 0)
                cm.Parameters.AddWithValue("@PhanTramVuotKhungBH", _phanTramVuotKhungBH);
            else
                cm.Parameters.AddWithValue("@PhanTramVuotKhungBH", DBNull.Value);
            if (_heSoVuotKhungBH != 0)
                cm.Parameters.AddWithValue("@HeSoVuotKhungBH", _heSoVuotKhungBH);
            else
                cm.Parameters.AddWithValue("@HeSoVuotKhungBH", DBNull.Value);
            if (_thueTNCN != 0)
                cm.Parameters.AddWithValue("@ThueTNCN", _thueTNCN);
            else
                cm.Parameters.AddWithValue("@ThueTNCN", DBNull.Value);
            if (_soNguoiPhuThuoc != 0)
                cm.Parameters.AddWithValue("@SoNguoiPhuThuoc", _soNguoiPhuThuoc);
            else
                cm.Parameters.AddWithValue("@SoNguoiPhuThuoc", DBNull.Value);
            if (_soTienGiamTru != 0)
                cm.Parameters.AddWithValue("@SoTienGiamTru", _soTienGiamTru);
            else
                cm.Parameters.AddWithValue("@SoTienGiamTru", DBNull.Value);
            if (_thucLanhSauThue != 0)
                cm.Parameters.AddWithValue("@ThucLanhSauThue", _thucLanhSauThue);
            else
                cm.Parameters.AddWithValue("@ThucLanhSauThue", DBNull.Value);
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
