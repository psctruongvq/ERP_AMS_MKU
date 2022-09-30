
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library.Report
{
    [Serializable()]
    public class TongHopChamNgoaiGioBoPhanChild : Csla.ReadOnlyBase<TongHopChamNgoaiGioBoPhanChild>
    {
        #region Business Properties and Methods

        //declare members
        private int _maBoPhan = 0;
        private int _maLoaiTangCa = 0;
        private decimal _thoiGian = 0;
        private string _maBoPhanQL = string.Empty;
        private string _tenBoPhan = string.Empty;
        private string _tenLoaiTangCa = string.Empty;

        private decimal _tBCN = 0;
        private decimal _nGNT = 0;
        private decimal _nGNL = 0;
        private decimal _tongCong = 0;
        private decimal _soGioDu = 0;

        [System.ComponentModel.DataObjectField(true, false)]
        public int MaBoPhan
        {
            get
            {
                return _maBoPhan;
            }
        }

        public int MaLoaiTangCa
        {
            get
            {
                return _maLoaiTangCa;
            }
        }

        public decimal ThoiGian
        {
            get
            {
                return _thoiGian;
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

        public string TenLoaiTangCa
        {
            get
            {
                return _tenLoaiTangCa;
            }
        }


        public decimal TBCN
        {
            get
            {
                return _tBCN;
            }
        }
        public decimal NGNT
        {
            get
            {
                return _nGNT;
            }
        }
        public decimal NGNL
        {
            get
            {
                return _nGNL;
            }
        }
        public decimal TongCong
        {
            get
            {
                return _tongCong;
            }
        }

        public decimal SoGioDu
        {
            get
            {
                return _soGioDu;
            }
        }

        protected override object GetIdValue()
        {
            return _maBoPhan;
        }

        #endregion //Business Properties and Methods

        #region Factory Methods
        internal static TongHopChamNgoaiGioBoPhanChild GetTongHopChamNgoaiGioBoPhanChild(SafeDataReader dr)
        {
            return new TongHopChamNgoaiGioBoPhanChild(dr);
        }

        private TongHopChamNgoaiGioBoPhanChild(SafeDataReader dr)
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
            _maLoaiTangCa = dr.GetInt32("MaLoaiTangCa");
            _thoiGian = dr.GetDecimal("ThoiGian");
            _maBoPhanQL = dr.GetString("MaBoPhanQL");
            _tenBoPhan = dr.GetString("TenBoPhan");
            _tenLoaiTangCa = dr.GetString("TenLoaiTangCa");

            _nGNL = dr.GetDecimal("NGNL");
            _nGNT = dr.GetDecimal("NGNT");
            _tBCN = dr.GetDecimal("TBCN");
            _tongCong = dr.GetDecimal("TongCong");
            _soGioDu = dr.GetDecimal("SoGioDu");
        }

        private void FetchChildren(SafeDataReader dr)
        {
        }
        #endregion //Data Access - Fetch
        #endregion //Data Access
    }
}
                  