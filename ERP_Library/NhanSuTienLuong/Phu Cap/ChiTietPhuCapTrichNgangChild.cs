
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library.Report
{
    [Serializable()]
    public class ChiTietPhuCapTrichNgangChild : Csla.ReadOnlyBase<ChiTietPhuCapTrichNgangChild>
    {
        #region Business Properties and Methods

        //declare members
        private int _maBoPhan = 0;
        private string _maBoPhanQL = string.Empty;
        private string _tenBoPhan = string.Empty;
        private long _maNhanVien = 0;
        private string _tenNhanVien = string.Empty;
        private string _tenPhuCap = string.Empty;
        private decimal _soTien = 0;

        public int MaBoPhan
        {
            get
            {
                return _maBoPhan;
            }
        }

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

        public string TenPhuCap
        {
            get
            {
                return _tenPhuCap;
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
        internal static ChiTietPhuCapTrichNgangChild GetChiTietPhuCapTrichNgangChild(SafeDataReader dr)
        {
            return new ChiTietPhuCapTrichNgangChild(dr);
        }

        private ChiTietPhuCapTrichNgangChild(SafeDataReader dr)
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
            _maBoPhan = dr.GetInt32("MaBoPhan");
            _maBoPhanQL = dr.GetString("MaBoPhanQL");
            _tenBoPhan = dr.GetString("TenBoPhan");
            _maNhanVien = dr.GetInt64("MaNhanVien");
            _tenNhanVien = dr.GetString("TenNhanVien");
            _tenPhuCap = dr.GetString("TenPhuCap");
            _soTien = dr.GetDecimal("SoTien");
        }

        private void FetchChildren(SafeDataReader dr)
        {
        }
        #endregion //Data Access - Fetch
        #endregion //Data Access
    }
}
