
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library.Report
{
    [Serializable()]
    public class ThuLaoNhanVienNganHangChild : Csla.ReadOnlyBase<ThuLaoNhanVienNganHangChild>
    {
        #region Business Properties and Methods

        //declare members
        private long _maNhanVien = 0;
        private string _tenBoPhan = string.Empty;
        private string _tenNhanVien = string.Empty;
        private string _cmnd = string.Empty;
        private string _soTaiKhoan = string.Empty;
        private decimal _soTien = 0;

        [System.ComponentModel.DataObjectField(true, false)]
        public long MaNhanVien
        {
            get
            {
                return _maNhanVien;
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

        public string Cmnd
        {
            get
            {
                return _cmnd;
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

        protected override object GetIdValue()
        {
            return _maNhanVien;
        }

        #endregion //Business Properties and Methods

        #region Factory Methods
        internal static ThuLaoNhanVienNganHangChild GetThuLaoNhanVienNganHangChild(SafeDataReader dr)
        {
            return new ThuLaoNhanVienNganHangChild(dr);
        }

        private ThuLaoNhanVienNganHangChild(SafeDataReader dr)
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
            _maNhanVien = dr.GetInt64("MaNhanVien");
            _tenBoPhan = dr.GetString("TenBoPhan");
            _tenNhanVien = dr.GetString("TenNhanVien");
            _cmnd = dr.GetString("CMND");
            _soTaiKhoan = dr.GetString("SoTaiKhoan");
            _soTien = dr.GetDecimal("SoTien");
        }

        private void FetchChildren(SafeDataReader dr)
        {
        }
        #endregion //Data Access - Fetch
        #endregion //Data Access
    }
}
