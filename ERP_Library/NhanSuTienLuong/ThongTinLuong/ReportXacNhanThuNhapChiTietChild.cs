
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library.Report
{
    [Serializable()]
    public class XacNhanThuNhapChiTietChild : Csla.ReadOnlyBase<XacNhanThuNhapChiTietChild>
    {
        #region Business Properties and Methods

        //declare members
        private int _maChiTiet = 0;
        private DateTime _kyLuong = DateTime.Today;
        private decimal _soTien = 0;

        [System.ComponentModel.DataObjectField(true, false)]
        public int MaChiTiet
        {
            get
            {
                return _maChiTiet;
            }
        }

        public DateTime KyLuong
        {
            get
            {
                return _kyLuong;
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
        internal static XacNhanThuNhapChiTietChild GetXacNhanThuNhapChiTietChild(SafeDataReader dr)
        {
            return new XacNhanThuNhapChiTietChild(dr);
        }

        private XacNhanThuNhapChiTietChild(SafeDataReader dr)
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
            _kyLuong = dr.GetDateTime("KyLuong");
            _soTien = dr.GetDecimal("SoTien");
        }

        private void FetchChildren(SafeDataReader dr)
        {
        }
        #endregion //Data Access - Fetch
        #endregion //Data Access
    }
}
