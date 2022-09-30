
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library.Report
{
    [Serializable()]
    public class InChiTietLuong_TongHopChild : Csla.ReadOnlyBase<InChiTietLuong_TongHopChild>
    {
        #region Business Properties and Methods

        //declare members
        private int _stt = 0;
        private string _dienGiai = string.Empty;
        private decimal _soTien = 0;
        private bool _th = false;

        public int Stt
        {
            get
            {
                return _stt;
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

        public bool Th
        {
            get
            {
                return _th;
            }
        }

        protected override object GetIdValue()
		{
            return _dienGiai;
		}

        #endregion //Business Properties and Methods

        #region Factory Methods
        internal static InChiTietLuong_TongHopChild GetInChiTietLuong_TongHopChild(SafeDataReader dr)
        {
            return new InChiTietLuong_TongHopChild(dr);
        }

        private InChiTietLuong_TongHopChild(SafeDataReader dr)
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
            _stt = dr.GetInt32("STT");
            _dienGiai = dr.GetString("DienGiai");
            _soTien = dr.GetDecimal("SoTien");
            _th = dr.GetBoolean("TH");
        }

        private void FetchChildren(SafeDataReader dr)
        {
        }
        #endregion //Data Access - Fetch
        #endregion //Data Access
    }
}
