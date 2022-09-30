
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library.Report
{
    [Serializable()]
    public class TongHopPhuCapNhanVienChild : Csla.ReadOnlyBase<TongHopPhuCapNhanVienChild>
    {
        #region Business Properties and Methods

        //declare members
        private int _maBoPhan = 0;
        private string _maBoPhanQL = string.Empty;
        private string _tenBoPhan = string.Empty;
        private decimal _soTien = 0;
        private decimal _bidv = 0;
        private decimal _dongA = 0;
        private decimal _khac = 0;

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

        public decimal SoTien
        {
            get
            {
                return _soTien;
            }
        }
        public decimal BIDV
        {
            get
            {
                return _bidv;
            }
        }

        public decimal DongA
        {
            get
            {
                return _dongA;
            }
        }

        public decimal Khac
        {
            get
            {
                return _khac;
            }
        }

        protected override object GetIdValue()
        {
            return _maBoPhan;
        }

        #endregion //Business Properties and Methods

        #region Factory Methods
        internal static TongHopPhuCapNhanVienChild GetTongHopPhuCapNhanVienChild(SafeDataReader dr)
        {
            return new TongHopPhuCapNhanVienChild(dr);
        }
        internal static TongHopPhuCapNhanVienChild GetTongHopNganHangChild(SafeDataReader dr)
        {
            TongHopPhuCapNhanVienChild item = new TongHopPhuCapNhanVienChild(dr);
            item._bidv = dr.GetDecimal("BIDV");
            item._dongA = dr.GetDecimal("DongA");
            item._khac = dr.GetDecimal("Khac");
            return item;
        }

        private TongHopPhuCapNhanVienChild(SafeDataReader dr)
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
            _soTien = dr.GetDecimal("SoTien");
        }

        private void FetchChildren(SafeDataReader dr)
        {
        }
        #endregion //Data Access - Fetch
        #endregion //Data Access
    }
}
