
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library.Report
{
    [Serializable()]
    public class InChiTietLuong_ThuLaoChild : Csla.ReadOnlyBase<InChiTietLuong_ThuLaoChild>
    {
        #region Business Properties and Methods

        //declare members
        private long _maChiTiet = 0;
        private DateTime _ngay = DateTime.Today;
        private string _boPhan = string.Empty;
        private string _chuongTrinh = string.Empty;
        private decimal _soTien = 0;
        private bool _ck = false;
        private long _maDeNghi = 0;

        public long MaChiTiet
        {
            get
            {
                return _maChiTiet;
            }
        }

        public DateTime Ngay
        {
            get
            {
                return _ngay;
            }
        }

        public string BoPhan
        {
            get
            {
                return _boPhan;
            }
        }

        public string ChuongTrinh
        {
            get
            {
                return _chuongTrinh;
            }
        }

        public decimal SoTien
        {
            get
            {
                return _soTien;
            }
        }

        public bool Ck
        {
            get
            {
                return _ck;
            }
        }

        public long MaDeNghi
        {
            get
            {
                return _maDeNghi;
            }
        }

        protected override object GetIdValue()
		{
            return _maChiTiet;
		}

        #endregion //Business Properties and Methods

        #region Factory Methods
        internal static InChiTietLuong_ThuLaoChild GetInChiTietLuong_ThuLaoChild(SafeDataReader dr)
        {
            return new InChiTietLuong_ThuLaoChild(dr);
        }

        private InChiTietLuong_ThuLaoChild(SafeDataReader dr)
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
            _ngay = dr.GetDateTime("Ngay");
            _boPhan = dr.GetString("BoPhan");
            _chuongTrinh = dr.GetString("ChuongTrinh");
            _soTien = dr.GetDecimal("SoTien");
            _ck = dr.GetBoolean("CK");
            _maDeNghi = dr.GetInt64("MaDeNghi");
        }

        private void FetchChildren(SafeDataReader dr)
        {
        }
        #endregion //Data Access - Fetch
        #endregion //Data Access
    }
}
