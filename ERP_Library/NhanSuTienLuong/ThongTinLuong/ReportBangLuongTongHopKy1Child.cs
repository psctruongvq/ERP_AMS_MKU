
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library.Report
{
    [Serializable()]
    public class BangLuongTongHopKy1Child : Csla.ReadOnlyBase<BangLuongTongHopKy1Child>
    {
        #region Business Properties and Methods

        //declare members
        private int _maBoPhan = 0;
        private string _maBoPhanQL = string.Empty;
        private string _tenBoPhan = string.Empty;
        private int _soNV = 0;
        private decimal _heSoBaoHiem = 0;
        private decimal _heSoCoBan = 0;
        private decimal _heSoPhuCap = 0;
        private decimal _heSoVuotKhung = 0;
        private decimal _heSoLuong = 0;
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
        private decimal _ThueTNCN = 0;
        private int _SoNguoiPhuThuoc = 0;
        private decimal _SoTienGiamTru = 0;
        private decimal _ThucLanhSauThue = 0;

        private decimal _TruNgayLuong = 0;
        private decimal _TruyThuBHXH = 0;
        private decimal _ChenhLechLuong = 0;


        public int MaBoPhan
        {
            get
            {
                return _maBoPhan;
            }
        }

        public string MaBoPhanQL
        {
            get
            {
                return _maBoPhanQL;
            }
        }

        public string TenBoPhan
        {
            get
            {
                return _tenBoPhan;
            }
        }

        public int SoNV
        {
            get
            {
                return _soNV;
            }
        }

        public decimal HeSoBaoHiem
        {
            get
            {
                return _heSoBaoHiem;
            }
        }

        public decimal HeSoCoBan
        {
            get
            {
                return _heSoCoBan;
            }
        }

        public decimal HeSoPhuCap
        {
            get
            {
                return _heSoPhuCap;
            }
        }

        public decimal HeSoVuotKhung
        {
            get
            {
                return _heSoVuotKhung;
            }
        }

        public decimal HeSoLuong
        {
            get
            {
                return _heSoLuong;
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

        public decimal TruyThuBHXH
        {
            get
            {
                return _TruyThuBHXH;
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
            return _maBoPhan;
		}

        #endregion //Business Properties and Methods

        #region Factory Methods
        internal static BangLuongTongHopKy1Child GetBangLuongTongHopKy1Child(SafeDataReader dr)
        {
            return new BangLuongTongHopKy1Child(dr);
        }

        private BangLuongTongHopKy1Child(SafeDataReader dr)
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
            _maBoPhan = dr.GetInt32("MaBoPhan");
            _maBoPhanQL = dr.GetString("MaBoPhanQL");
            _tenBoPhan = dr.GetString("TenBoPhan");
            _soNV = dr.GetInt32("SoNV");
            _heSoBaoHiem = dr.GetDecimal("HeSoBaoHiem");
            _heSoCoBan = dr.GetDecimal("HeSoCoBan");
            _heSoPhuCap = dr.GetDecimal("HeSoPhuCap");
            _heSoVuotKhung = dr.GetDecimal("HeSoVuotKhung");
            _heSoLuong = dr.GetDecimal("HeSoLuong");
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
            _ThueTNCN = dr.GetDecimal("ThueTNCN");
            _SoNguoiPhuThuoc = dr.GetInt32("SoNguoiPhuThuoc");
            _SoTienGiamTru = dr.GetDecimal("SoTienGiamTru");
            _ThucLanhSauThue = dr.GetDecimal("ThucLanhSauThue");

            _TruNgayLuong = dr.GetDecimal("TruNgayLuong");
            _TruyThuBHXH = dr.GetDecimal("TruyThuBHXH");
            _ChenhLechLuong = dr.GetDecimal("TruyLinh");
        }

        private void FetchChildren(SafeDataReader dr)
        {
        }
        #endregion //Data Access - Fetch
        #endregion //Data Access
    }
}
