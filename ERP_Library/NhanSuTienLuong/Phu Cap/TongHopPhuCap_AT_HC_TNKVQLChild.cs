
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{
    [Serializable()]
    public class TongHopPhuCapAT_HC_TNKVQLChild : Csla.ReadOnlyBase<TongHopPhuCapAT_HC_TNKVQLChild>
    {
        #region Business Properties and Methods

        //declare members
        private int _maBoPhan = 0;
        private string _maBoPhanQL = string.Empty;
        private string _tenBoPhan = string.Empty;
        private decimal _antruaBidv = 0;
        private decimal _antruaDonga = 0;
        private decimal _antruaKhac = 0;
        private decimal _hanhchinhBidv = 0;
        private decimal _hanhchinhDonga = 0;
        private decimal _hanhchinhKhac = 0;
        private decimal _tnkvqlBidv = 0;
        private decimal _tnkvqlDonga = 0;
        private decimal _tnkvqlKhac = 0;
        private decimal _TcBidv = 0;
        private decimal _TcDonga = 0;
        private decimal _TcKhac = 0;
        private decimal _tongCong = 0;

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

        public decimal AntruaBidv
        {
            get
            {
                return _antruaBidv;
            }
        }

        public decimal AntruaDonga
        {
            get
            {
                return _antruaDonga;
            }
        }

        public decimal AntruaKhac
        {
            get
            {
                return _antruaKhac;
            }
        }

        public decimal HanhchinhBidv
        {
            get
            {
                return _hanhchinhBidv;
            }
        }

        public decimal HanhchinhDonga
        {
            get
            {
                return _hanhchinhDonga;
            }
        }

        public decimal HanhchinhKhac
        {
            get
            {
                return _hanhchinhKhac;
            }
        }

        public decimal TnkvqlBidv
        {
            get
            {
                return _tnkvqlBidv;
            }
        }

        public decimal TnkvqlDonga
        {
            get
            {
                return _tnkvqlDonga;
            }
        }

        public decimal TnkvqlKhac
        {
            get
            {
                return _tnkvqlKhac;
            }
        }

        public decimal TcBidv
        {
            get
            {
                return _TcBidv;
            }
        }

        public decimal TcDonga
        {
            get
            {
                return _TcDonga;
            }
        }

        public decimal TcKhac
        {
            get
            {
                return _TcKhac;
            }
        }
        public decimal TongCong
        {
            get
            {
                return _tongCong;
            }
        }

        protected override object GetIdValue()
        {
            return _maBoPhan;
        }

        #endregion //Business Properties and Methods

        #region Factory Methods
        internal static TongHopPhuCapAT_HC_TNKVQLChild GetTongHopPhuCapAT_HC_TNKVQLChild(SafeDataReader dr)
        {
            return new TongHopPhuCapAT_HC_TNKVQLChild(dr);
        }

        private TongHopPhuCapAT_HC_TNKVQLChild(SafeDataReader dr)
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
            _antruaBidv = dr.GetDecimal("AnTrua_BIDV");
            _antruaDonga = dr.GetDecimal("AnTrua_DongA");
            _antruaKhac = dr.GetDecimal("AnTrua_Khac");
            _hanhchinhBidv = dr.GetDecimal("HanhChinh_BIDV");
            _hanhchinhDonga = dr.GetDecimal("HanhChinh_DongA");
            _hanhchinhKhac = dr.GetDecimal("HanhChinh_Khac");
            _tnkvqlBidv = dr.GetDecimal("TNKVQL_BIDV");
            _tnkvqlDonga = dr.GetDecimal("TNKVQL_DongA");
            _tnkvqlKhac = dr.GetDecimal("TNKVQL_Khac");
            _TcBidv = dr.GetDecimal("TC_BIDV");
            _TcDonga = dr.GetDecimal("TC_DongA");
            _TcKhac = dr.GetDecimal("TC_Khac");
            _tongCong = dr.GetDecimal("TongCong");
        }

        private void FetchChildren(SafeDataReader dr)
        {
        }
        #endregion //Data Access - Fetch
        #endregion //Data Access
    }
}
