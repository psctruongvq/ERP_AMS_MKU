
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library.Report
{
    [Serializable()]
    public class ChiTietChuyenKhoanNhanVienBoPhanChild : Csla.ReadOnlyBase<ChiTietChuyenKhoanNhanVienBoPhanChild>
    {
        #region Business Properties and Methods

        //declare members
        private long _maChiTiet = 0;
        private string _maBoPhanQL = string.Empty;
        private string _tenBoPhan = string.Empty;
        private string _tenNhanVien = string.Empty;
        private string _soTaiKhoan = string.Empty;
        private DateTime _ngay = DateTime.Today;
        private string _loai = string.Empty;
        private decimal _soTien = 0;
        private string _boPhanDeNghi = "";

        public long MaChiTiet
        {
            get
            {
                return _maChiTiet;
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

        public string TenNhanVien
        {
            get
            {
                return _tenNhanVien;
            }
        }

        public string SoTaiKhoan
        {
            get
            {
                return _soTaiKhoan;
            }
        }

        public string BoPhanDeNghi
        {
            get
            {
                return _boPhanDeNghi;
            }
        }

        public DateTime Ngay
        {
            get
            {
                return _ngay;
            }
        }

        public string Loai
        {
            get
            {
                return _loai;
            }
        }

        public decimal SoTien
        {
            get
            {
                return _soTien;
            }
        }

        protected override object GetIdValue()
		{
            return _maChiTiet;
		}

        #endregion //Business Properties and Methods

        #region Factory Methods
        internal static ChiTietChuyenKhoanNhanVienBoPhanChild GetChiTietChuyenKhoanNhanVienBoPhanChild(SafeDataReader dr)
        {
            return new ChiTietChuyenKhoanNhanVienBoPhanChild(dr);
        }

        private ChiTietChuyenKhoanNhanVienBoPhanChild(SafeDataReader dr)
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
            _maChiTiet = dr.GetInt64("MaChiTiet");
            _maBoPhanQL = dr.GetString("MaBoPhanQL");
            _tenBoPhan = dr.GetString("TenBoPhan");
            _tenNhanVien = dr.GetString("TenNhanVien");
            _soTaiKhoan = dr.GetString("SoTaiKhoan");
            _boPhanDeNghi = dr.GetString("BoPhanDeNghi");
            _ngay = dr.GetDateTime("Ngay");
            _loai = dr.GetString("Loai");
            _soTien = dr.GetDecimal("SoTien");
        }

        private void FetchChildren(SafeDataReader dr)
        {
        }
        #endregion //Data Access - Fetch
        #endregion //Data Access
    }
}
