
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library.Report
{
    [Serializable()]
    public class ChiTietDangPhiNhanVien : Csla.ReadOnlyBase<ChiTietDangPhiNhanVien>
    {
        #region Business Properties and Methods

        //declare members
        private string _tenNhom = string.Empty;
        private string _dienGiai = string.Empty;
        private decimal _soTien = 0;

        public string TenNhom
        {
            get
            {
                return _tenNhom;
            }
        }

        [System.ComponentModel.DataObjectField(true, false)]
        public string DienGiai
        {
            get
            {
                return _dienGiai;
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
            return _tenNhom + " - " + _dienGiai;
        }

        #endregion //Business Properties and Methods

        #region Factory Methods
        internal static ChiTietDangPhiNhanVien GetChiTietDangPhiNhanVien(SafeDataReader dr)
        {
            return new ChiTietDangPhiNhanVien(dr);
        }

        private ChiTietDangPhiNhanVien(SafeDataReader dr)
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
            _tenNhom = dr.GetString("TenNhom");
            _dienGiai = dr.GetString("DienGiai");
            _soTien = dr.GetDecimal("SoTien");
        }

        private void FetchChildren(SafeDataReader dr)
        {
        }
        #endregion //Data Access - Fetch
        #endregion //Data Access
    }
}
