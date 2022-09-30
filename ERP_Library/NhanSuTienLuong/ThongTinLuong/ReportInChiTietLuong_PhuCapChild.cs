
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library.Report
{
    [Serializable()]
    public class InChiTietLuong_PhuCapChild : Csla.ReadOnlyBase<InChiTietLuong_PhuCapChild>
    {
        #region Business Properties and Methods

        //declare members
        private long _maChiTiet = 0;
        private DateTime _ngay = DateTime.Today;
        private string _boPhan = string.Empty;
        private string _phuCap = string.Empty;
        private decimal _soTien = 0;
        private bool _ck = false;
        private string _tenGroup = "";
        private decimal _soTienTinhThue = 0;
        private decimal _soTienKhongTinhThue = 0;

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

        public string PhuCap
        {
            get
            {
                return _phuCap;
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

        public string TenGroup
        {
            get
            {
                return _tenGroup;
            }
        }

        public decimal SoTienTinhThue
        {
            get
            {
                return _soTienTinhThue;
            }
        }

        public decimal SoTienKhongTinhThue
        {
            get
            {
                return _soTienKhongTinhThue;
            }
        }

        protected override object GetIdValue()
		{
            return _maChiTiet;
		}

        #endregion //Business Properties and Methods

        #region Factory Methods
        internal static InChiTietLuong_PhuCapChild GetInChiTietLuong_PhuCapChild(SafeDataReader dr)
        {
            return new InChiTietLuong_PhuCapChild(dr);
        }

        private InChiTietLuong_PhuCapChild(SafeDataReader dr)
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
            _phuCap = dr.GetString("PhuCap");
            _soTien = dr.GetDecimal("SoTien");
            _ck = dr.GetBoolean("CK");
            _tenGroup = dr.GetString("TenGroup");
            _soTienTinhThue = dr.GetDecimal("SoTienTinhThue");
            _soTienKhongTinhThue = dr.GetDecimal("SoTienKhongTinhThue");
        }

        private void FetchChildren(SafeDataReader dr)
        {
        }
        #endregion //Data Access - Fetch
        #endregion //Data Access
    }
}
