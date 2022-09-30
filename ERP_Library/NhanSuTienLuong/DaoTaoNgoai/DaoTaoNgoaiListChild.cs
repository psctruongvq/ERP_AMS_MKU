
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{
    [Serializable()]
    public class DaoTaoNgoaiListChild : Csla.ReadOnlyBase<DaoTaoNgoaiListChild>
    {
        #region Business Properties and Methods

        //declare members
        private int _maDTNgoai = 0;
        private string _maQL = string.Empty;
        private string _tenChuongTrinh = string.Empty;
        private DateTime _tuNgay = DateTime.Today;
        private DateTime _denNgay = DateTime.Today;
        private decimal _hocPhi = 0;
        private string _ghiChu = string.Empty;

        [System.ComponentModel.DataObjectField(true, true)]
        public int MaDTNgoai
        {
            get
            {
                CanReadProperty("MaDTNgoai", true);
                return _maDTNgoai;
            }
        }

        public string MaQL
        {
            get
            {
                CanReadProperty("MaQL", true);
                return _maQL;
            }
        }

        public string TenChuongTrinh
        {
            get
            {
                CanReadProperty("TenChuongTrinh", true);
                return _tenChuongTrinh;
            }
        }

        public DateTime TuNgay
        {
            get
            {
                CanReadProperty("TuNgay", true);
                return _tuNgay;
            }
        }

        public DateTime DenNgay
        {
            get
            {
                CanReadProperty("DenNgay", true);
                return _denNgay;
            }
        }

        public decimal HocPhi
        {
            get
            {
                CanReadProperty("HocPhi", true);
                return _hocPhi;
            }
        }

        public string GhiChu
        {
            get
            {
                CanReadProperty("GhiChu", true);
                return _ghiChu;
            }
        }

        protected override object GetIdValue()
        {
            return _maDTNgoai;
        }

        #endregion //Business Properties and Methods

        #region Authorization Rules
        protected override void AddAuthorizationRules()
        {
            //TODO: Define authorization rules in DaoTaoNgoaiListChild
            //AuthorizationRules.AllowRead("MaDTNgoai", "DaoTaoNgoaiListChildReadGroup");
            //AuthorizationRules.AllowRead("MaQL", "DaoTaoNgoaiListChildReadGroup");
            //AuthorizationRules.AllowRead("TenChuongTrinh", "DaoTaoNgoaiListChildReadGroup");
            //AuthorizationRules.AllowRead("TuNgay", "DaoTaoNgoaiListChildReadGroup");
            //AuthorizationRules.AllowRead("DenNgay", "DaoTaoNgoaiListChildReadGroup");
            //AuthorizationRules.AllowRead("HocPhi", "DaoTaoNgoaiListChildReadGroup");
            //AuthorizationRules.AllowRead("GhiChu", "DaoTaoNgoaiListChildReadGroup");

        }

        #endregion //Authorization Rules

        #region Factory Methods
        internal static DaoTaoNgoaiListChild GetDaoTaoNgoaiListChild(SafeDataReader dr)
        {
            return new DaoTaoNgoaiListChild(dr);
        }

        private DaoTaoNgoaiListChild(SafeDataReader dr)
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
            _maDTNgoai = dr.GetInt32("MaDTNgoai");
            _maQL = dr.GetString("MaQL");
            _tenChuongTrinh = dr.GetString("TenChuongTrinh");
            _tuNgay = dr.GetDateTime("TuNgay");
            _denNgay = dr.GetDateTime("DenNgay");
            _hocPhi = dr.GetDecimal("HocPhi");
            _ghiChu = dr.GetString("GhiChu");
        }

        private void FetchChildren(SafeDataReader dr)
        {
        }
        #endregion //Data Access - Fetch
        #endregion //Data Access
    }
}
