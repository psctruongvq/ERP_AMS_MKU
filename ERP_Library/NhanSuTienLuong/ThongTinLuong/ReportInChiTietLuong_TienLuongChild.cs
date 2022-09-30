
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library.Report
{
    [Serializable()]
    public class InChiTietLuong_TienLuongChild : Csla.ReadOnlyBase<InChiTietLuong_TienLuongChild>
    {
        #region Business Properties and Methods

        //declare members
        private DateTime _ngay = DateTime.Today;
        private string _boPhan = string.Empty;
        private string _dienGiai = string.Empty;
        private decimal _soTien = 0;


        public DateTime? Ngay
        {
            get
            {
                if (_ngay.Date == DateTime.MinValue)
                    return null;
                return _ngay.Date;
            }
        }

        public string BoPhan
        {
            get
            {
                return _boPhan;
            }
        }

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
            return 1;
        }

        #endregion //Business Properties and Methods

        #region Factory Methods
        internal static InChiTietLuong_TienLuongChild GetInChiTietLuong_TienLuongChild(SafeDataReader dr)
        {
            return new InChiTietLuong_TienLuongChild(dr);
        }

        private InChiTietLuong_TienLuongChild(SafeDataReader dr)
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
            _ngay = dr.GetDateTime("Ngay");
            _boPhan = dr.GetString("BoPhan");
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
