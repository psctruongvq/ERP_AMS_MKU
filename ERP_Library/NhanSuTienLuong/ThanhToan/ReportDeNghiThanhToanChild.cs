
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library.Report
{
    [Serializable()]
    public class DeNghiThanhToanChild : Csla.ReadOnlyBase<DeNghiThanhToanChild>
    {
        #region Business Properties and Methods

        //declare members
        private long _maPhieu = 0;
        private string _so = string.Empty;
        private DateTime _ngay = DateTime.Today;
        private string _tenNhanVien = string.Empty;
        private string _tenBoPhan = string.Empty;
        private string _lyDo = string.Empty;
        private decimal _soTien = 0;

        [System.ComponentModel.DataObjectField(true, false)]
        public long MaPhieu
        {
            get
            {
                return _maPhieu;
            }
        }

        public string So
        {
            get
            {
                return _so;
            }
        }

        public DateTime Ngay
        {
            get
            {
                return _ngay;
            }
        }

        public string TenNhanVien
        {
            get
            {
                return _tenNhanVien;
            }
        }

        public string TenBoPhan
        {
            get
            {
                return _tenBoPhan;
            }
        }

        public string LyDo
        {
            get
            {
                return _lyDo;
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
            return _maPhieu;
        }

        #endregion //Business Properties and Methods

        #region Factory Methods
        internal static DeNghiThanhToanChild GetDeNghiThanhToanChild(SafeDataReader dr)
        {
            return new DeNghiThanhToanChild(dr);
        }

        private DeNghiThanhToanChild(SafeDataReader dr)
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
            _maPhieu = dr.GetInt64("MaPhieu");
            _so = dr.GetString("So");
            _ngay = dr.GetDateTime("Ngay");
            _tenNhanVien = dr.GetString("TenNhanVien");
            _tenBoPhan = dr.GetString("TenBoPhan");
            _lyDo = dr.GetString("LyDo");
            _soTien = dr.GetDecimal("SoTien");
        }

        private void FetchChildren(SafeDataReader dr)
        {
        }
        #endregion //Data Access - Fetch
        #endregion //Data Access
    }
}
