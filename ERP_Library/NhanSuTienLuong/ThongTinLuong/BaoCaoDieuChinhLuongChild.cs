
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{
    [Serializable()]
    public class BaoCaoDieuChinhLuongChild : Csla.ReadOnlyBase<BaoCaoDieuChinhLuongChild>
    {
        #region Business Properties and Methods

        //declare members
        private int _maChiTiet = 0;
        private string _tenBoPhan = string.Empty;
        private string _tenNhanVien = string.Empty;
        private DateTime _tuThang = DateTime.Today;
        private DateTime _denThang = DateTime.Today;
        private int _soThang = 0;
        private decimal _heSoLuongTruoc = 0;
        private decimal _heSoPCTruoc = 0;
        private decimal _heSoVKTruoc = 0;
        private decimal _tiLeTruoc = 0;
        private decimal _luongDot1Truoc = 0;
        private decimal _bHXHTruoc = 0;
        private decimal _luongDot2Truoc = 0;
        private decimal _soTienTruoc = 0;
        private decimal _heSoLuongSau = 0;
        private decimal _heSoPCSau = 0;
        private decimal _heSoVKSau = 0;
        private decimal _tiLeSau = 0;
        private decimal _luongDot1Sau = 0;
        private decimal _bHXHSau = 0;
        private decimal _luongDot2Sau = 0;
        private decimal _soTienSau = 0;
        private decimal _soTienDieuChinh = 0;
        private string _ghiChu = string.Empty;

        [System.ComponentModel.DataObjectField(true, false)]
        public int MaChiTiet
        {
            get
            {
                return _maChiTiet;
            }
        }

        public string TenBoPhan
        {
            get
            {
                return _tenBoPhan;
            }
        }

        public string TenNhanVien
        {
            get
            {
                return _tenNhanVien;
            }
        }

        public DateTime TuThang
        {
            get
            {
                return _tuThang;
            }
        }

        public DateTime DenThang
        {
            get
            {
                return _denThang;
            }
        }

        public int SoThang
        {
            get
            {
                return _soThang;
            }
        }

        public decimal HeSoLuongTruoc
        {
            get
            {
                return _heSoLuongTruoc;
            }
        }

        public decimal HeSoPCTruoc
        {
            get
            {
                return _heSoPCTruoc;
            }
        }

        public decimal HeSoVKTruoc
        {
            get
            {
                return _heSoVKTruoc;
            }
        }

        public decimal TiLeTruoc
        {
            get
            {
                return _tiLeTruoc;
            }
        }

        public decimal LuongDot1Truoc
        {
            get
            {
                return _luongDot1Truoc;
            }
        }

        public decimal BHXHTruoc
        {
            get
            {
                return _bHXHTruoc;
            }
        }

        public decimal LuongDot2Truoc
        {
            get
            {
                return _luongDot2Truoc;
            }
        }

        public decimal SoTienTruoc
        {
            get
            {
                return _soTienTruoc;
            }
        }

        public decimal HeSoLuongSau
        {
            get
            {
                return _heSoLuongSau;
            }
        }

        public decimal HeSoPCSau
        {
            get
            {
                return _heSoPCSau;
            }
        }

        public decimal HeSoVKSau
        {
            get
            {
                return _heSoVKSau;
            }
        }

        public decimal TiLeSau
        {
            get
            {
                return _tiLeSau;
            }
        }

        public decimal LuongDot1Sau
        {
            get
            {
                return _luongDot1Sau;
            }
        }

        public decimal BHXHSau
        {
            get
            {
                return _bHXHSau;
            }
        }

        public decimal LuongDot2Sau
        {
            get
            {
                return _luongDot2Sau;
            }
        }

        public decimal SoTienSau
        {
            get
            {
                return _soTienSau;
            }
        }

        public decimal SoTienDieuChinh
        {
            get
            {
                return _soTienDieuChinh;
            }
        }

        public string GhiChu
        {
            get
            {
                return _ghiChu;
            }
        }

        protected override object GetIdValue()
        {
            return _maChiTiet;
        }

        #endregion //Business Properties and Methods

        #region Factory Methods
        internal static BaoCaoDieuChinhLuongChild GetBaoCaoDieuChinhLuongChild(SafeDataReader dr)
        {
            return new BaoCaoDieuChinhLuongChild(dr);
        }

        private BaoCaoDieuChinhLuongChild(SafeDataReader dr)
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
            _tenBoPhan = dr.GetString("TenBoPhan");
            _tenNhanVien = dr.GetString("TenNhanVien");
            _tuThang = dr.GetDateTime("TuThang");
            _denThang = dr.GetDateTime("DenThang");
            _soThang = dr.GetInt32("SoThang");
            _heSoLuongTruoc = dr.GetDecimal("HeSoLuongTruoc");
            _heSoPCTruoc = dr.GetDecimal("HeSoPCTruoc");
            _heSoVKTruoc = dr.GetDecimal("HeSoVKTruoc");
            _tiLeTruoc = dr.GetDecimal("TiLeTruoc");
            _luongDot1Truoc = dr.GetDecimal("LuongDot1Truoc");
            _bHXHTruoc = dr.GetDecimal("BHXHTruoc");
            _luongDot2Truoc = dr.GetDecimal("LuongDot2Truoc");
            _soTienTruoc = dr.GetDecimal("SoTienTruoc");
            _heSoLuongSau = dr.GetDecimal("HeSoLuongSau");
            _heSoPCSau = dr.GetDecimal("HeSoPCSau");
            _heSoVKSau = dr.GetDecimal("HeSoVKSau");
            _tiLeSau = dr.GetDecimal("TiLeSau");
            _luongDot1Sau = dr.GetDecimal("LuongDot1Sau");
            _bHXHSau = dr.GetDecimal("BHXHSau");
            _luongDot2Sau = dr.GetDecimal("LuongDot2Sau");
            _soTienSau = dr.GetDecimal("SoTienSau");
            _soTienDieuChinh = dr.GetDecimal("SoTienDieuChinh");
            _ghiChu = dr.GetString("GhiChu");
        }

        private void FetchChildren(SafeDataReader dr)
        {
        }
        #endregion //Data Access - Fetch
        #endregion //Data Access
    }
}
