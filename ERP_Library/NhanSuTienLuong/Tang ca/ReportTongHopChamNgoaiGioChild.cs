
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library.Report
{
    [Serializable()]
    public class TongHopChamNgoaiGioChild : Csla.ReadOnlyBase<TongHopChamNgoaiGioChild>
    {
        #region Business Properties and Methods

        //declare members
        private long _maNhanVien = 0;
        private int _maLoaiTangCa = 0;
        private string _maBoPhanQL = string.Empty;                   
        private string _tenBoPhan = string.Empty;
        private string _tenNhanVien = string.Empty;
        private string _tenLoaiTangCa = string.Empty;
        private decimal _thoiGian = 0;
        private decimal _tBCN = 0;
        private decimal _nGNT = 0;
        private decimal _nGNL = 0;
        private decimal _tongCong = 0;
        private decimal _soGioDu = 0;

        public long MaNhanVien
        {
            get
            {
                return _maNhanVien;
            }
        }

        public int MaLoaiTangCa
        {
            get
            {
                return _maLoaiTangCa;
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

        public string TenNhanVien
        {
            get
            {
                return _tenNhanVien;
            }
        }

        public string TenLoaiTangCa
        {
            get
            {
                return _tenLoaiTangCa;
            }
        }

        public decimal ThoiGian
        {
            get
            {
                return _thoiGian;
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
            return _maNhanVien + "-" + _maLoaiTangCa;
		}

        private TongHopChamNgoaiGioChild()
		{

			//ValidationRules.CheckRules();
			//MarkAsChild();
		}

        #endregion //Business Properties and Methods

        #region Factory Methods
        internal static TongHopChamNgoaiGioChild GetTongHopChamNgoaiGioChild(SafeDataReader dr)
        {
            return new TongHopChamNgoaiGioChild(dr);
        }

      

        private TongHopChamNgoaiGioChild(SafeDataReader dr)
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
            try
            {
                _maNhanVien = dr.GetInt64("MaNhanVien");
                _maLoaiTangCa = dr.GetInt32("MaLoaiTangCa");
                _maBoPhanQL = dr.GetString("MaBoPhanQL");
                _tenBoPhan = dr.GetString("TenBoPhan");
                _tenNhanVien = dr.GetString("TenNhanVien");
                _tenLoaiTangCa = dr.GetString("TenLoaiTangCa");
                _thoiGian = dr.GetDecimal("ThoiGian");
                _nGNL = dr.GetDecimal("NGNL");
                _nGNT = dr.GetDecimal("NGNT");
                _tBCN = dr.GetDecimal("TBCN");
                _tongCong = dr.GetDecimal("TongCong");
                _soGioDu = dr.GetDecimal("SoGioDu");
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        private void FetchChildren(SafeDataReader dr)
        {
        }
        #endregion //Data Access - Fetch
        #endregion //Data Access
    }
}
