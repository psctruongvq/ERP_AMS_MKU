
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library.Report
{
    [Serializable()]
    public class ChiTietChuyenKhoanBoPhanChild : Csla.ReadOnlyBase<ChiTietChuyenKhoanBoPhanChild>
    {
        #region Business Properties and Methods

        //declare members
        private string _maBoPhanQL = string.Empty;
        private string _tenBoPhan = string.Empty;
        private string _tenNhanVien = string.Empty;
        private string _soTaiKhoan = string.Empty;
        private decimal _soTien = 0;

        private string _cmnd = string.Empty;
        private string _tenNganHang = string.Empty;

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

        public decimal SoTien
        {
            get
            {
                return _soTien;
            }
        }

        public string CMND
        {
            get
            {
                return _cmnd;
            }
        }

        public string TenNgangHang
        {
            get
            {
                return _tenNganHang;
            }
        }

        protected override object GetIdValue()
		{
            return _tenBoPhan + "-" + _tenNhanVien;
		}

        #endregion //Business Properties and Methods

        #region Factory Methods
        internal static ChiTietChuyenKhoanBoPhanChild GetChiTietChuyenKhoanBoPhanChild(SafeDataReader dr)
        {
            return new ChiTietChuyenKhoanBoPhanChild(dr);
        }

        private ChiTietChuyenKhoanBoPhanChild(SafeDataReader dr)
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
            _maBoPhanQL = dr.GetString("MaBoPhanQL");
            _tenBoPhan = dr.GetString("TenBoPhan");
            _tenNhanVien = dr.GetString("TenNhanVien");
            _soTaiKhoan = dr.GetString("SoTaiKhoan");
            _soTien = dr.GetDecimal("SoTien");
            _cmnd = dr.GetString("CMND");
            _tenNganHang = dr.GetString("TenNganHang");
        }

        private void FetchChildren(SafeDataReader dr)
        {
        }
        #endregion //Data Access - Fetch
        #endregion //Data Access
    }
}
