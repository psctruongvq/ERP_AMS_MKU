
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library.Report
{
    [Serializable()]
    public class BangKeThueTNCN_NVChild : Csla.ReadOnlyBase<BangKeThueTNCN_NVChild>
    {
        #region Business Properties and Methods

        //declare members
        private long _maNhanVien = 0;
        private string _tenNhanVien = string.Empty;
        private decimal _tongThuNhapTinhThue = 0;
        private decimal _thueTNCN = 0;
        private string _cMND = string.Empty;
        private string _maSoThue = string.Empty;

        [System.ComponentModel.DataObjectField(true, false)]
        public long MaNhanVien
        {
            get
            {
                return _maNhanVien;
            }
        }

        public string TenNhanVien
        {
            get
            {
                return _tenNhanVien;
            }
        }

        public decimal TongThuNhapTinhThue
        {
            get
            {
                return _tongThuNhapTinhThue;
            }
        }

        public decimal ThueTNCN
        {
            get
            {
                return _thueTNCN;
            }
        }

        public string CMND
        {
            get
            {
                return _cMND;
            }
        }

        public string MaSoThue
        {
            get
            {
                return _maSoThue;
            }
        }
        protected override object GetIdValue()
        {
            return _maNhanVien;
        }

        #endregion //Business Properties and Methods

        #region Factory Methods
        internal static BangKeThueTNCN_NVChild GetBangKeThueTNCN_NVChild(SafeDataReader dr)
        {
            return new BangKeThueTNCN_NVChild(dr);
        }

        private BangKeThueTNCN_NVChild(SafeDataReader dr)
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
            _tenNhanVien = dr.GetString("TenNhanVien");
            _tongThuNhapTinhThue = dr.GetDecimal("TongThuNhapTinhThue");
            _thueTNCN = dr.GetDecimal("ThueTNCN");
            _cMND = dr.GetString("CMND");
            _maSoThue = dr.GetString("MaSoThue");
        }

        private void FetchChildren(SafeDataReader dr)
        {
        }
        #endregion //Data Access - Fetch
        #endregion //Data Access
    }
}
