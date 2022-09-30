
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library.Report
{
    [Serializable()]
    public class TongHopPhuCapNgoaiGioChild : Csla.ReadOnlyBase<TongHopPhuCapNgoaiGioChild>
    {
        #region Business Properties and Methods

        //declare members
        private int _maBoPhan = 0;
        private string _maBoPhanQL = string.Empty;
        private string _tenBoPhan = string.Empty;
        private string _tenLoaiPhuCap = string.Empty;
        private decimal _soTien = 0;
        private string _tenThoiGian = string.Empty;
        private decimal _thoiGian = 0;

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

        public string TenThoiGian
        {
            get
            {
                return _tenThoiGian;
            }
        }

        public decimal ThoiGian
        {
            get
            {
                return _thoiGian;
            }
        }

        protected override object GetIdValue()
        {
            return _maBoPhan;
        }

        #endregion //Business Properties and Methods

        #region Factory Methods
        internal static TongHopPhuCapNgoaiGioChild GetTongHopPhuCapNgoaiGioChild(SafeDataReader dr)
        {
            return new TongHopPhuCapNgoaiGioChild(dr);
        }

        private TongHopPhuCapNgoaiGioChild(SafeDataReader dr)
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
            _tenLoaiPhuCap = dr.GetString("TenLoaiPhuCap");
            _soTien = dr.GetDecimal("SoTien");
            _tenThoiGian = dr.GetString("TenThoiGian");
            _thoiGian = dr.GetDecimal("ThoiGian");
        }

        private void FetchChildren(SafeDataReader dr)
        {
        }
        #endregion //Data Access - Fetch
        #endregion //Data Access
    }
}
             