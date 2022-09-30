
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library.Report
{
    [Serializable()]
    public class TongHopPhuCapTrichNgangChild : Csla.ReadOnlyBase<TongHopPhuCapTrichNgangChild>
    {
        #region Business Properties and Methods

        //declare members
        private int _maBoPhan = 0;
        private string _maBoPhanQL = string.Empty;
        private string _tenBoPhan = string.Empty;
        private int _maLoaiPhuCap = 0;
        private string _tenLoaiPhuCap = string.Empty;
        private decimal _soTien = 0;
        private int _tc = 0;

        [System.ComponentModel.DataObjectField(true, false)]
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

        public int MaLoaiPhuCap
        {
            get
            {
                return _maLoaiPhuCap;
            }
        }

        public string TenLoaiPhuCap
        {
            get
            {
                return _tenLoaiPhuCap;
            }
        }

        public decimal SoTien
        {
            get
            {
                return _soTien;
            }
        }

        public int Tc
        {
            get
            {
                return _tc;
            }
        }

        protected override object GetIdValue()
        {
            return _maBoPhan;
        }

        #endregion //Business Properties and Methods

        #region Factory Methods
        internal static TongHopPhuCapTrichNgangChild GetTongHopPhuCapTrichNgangChild(SafeDataReader dr)
        {
            return new TongHopPhuCapTrichNgangChild(dr);
        }

        private TongHopPhuCapTrichNgangChild(SafeDataReader dr)
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
            _maLoaiPhuCap = dr.GetInt32("MaLoaiPhuCap");
            _tenLoaiPhuCap = dr.GetString("TenLoaiPhuCap");
            _soTien = dr.GetDecimal("SoTien");
            _tc = dr.GetInt32("TC");
        }

        private void FetchChildren(SafeDataReader dr)
        {
        }
        #endregion //Data Access - Fetch
        #endregion //Data Access
    }
}
