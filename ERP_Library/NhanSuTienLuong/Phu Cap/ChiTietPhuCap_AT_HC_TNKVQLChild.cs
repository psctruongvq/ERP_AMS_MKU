
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;
 
namespace ERP_Library
{
    [Serializable()]
    public class ChiTietPhuCapAT_HC_TNKVQLChild : Csla.ReadOnlyBase<ChiTietPhuCapAT_HC_TNKVQLChild>
    {
        #region Business Properties and Methods

        //declare members
        private int _maNhanVien = 0;
        private string _tenBoPhan = string.Empty;
        private string _tenNhanVien = string.Empty;
        private string _soTaiKhoan = string.Empty;
        private string _soCMND = string.Empty;
        private decimal _anTrua = 0;
        private decimal _hanhChinh = 0;
        private decimal _tnkvql = 0;
        private decimal _tongCong = 0;
        private string _maBoPhanQL = "";

        [System.ComponentModel.DataObjectField(true, false)]
        public int MaNhanVien
        {
            get
            {
                return _maNhanVien;
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

        public string SoTaiKhoan
        {
            get
            {
                return _soTaiKhoan;
            }
        }

        public string SoCMND
        {
            get
            {
                return _soCMND;
            }
        }

        public decimal AnTrua
        {
            get
            {
                return _anTrua;
            }
        }

        public decimal HanhChinh
        {
            get
            {
                return _hanhChinh;
            }
        }

        public decimal Tnkvql
        {
            get
            {
                return _tnkvql;
            }
        }

        public decimal TongCong
        {
            get
            {
                return _tongCong;
            }
        }

        public string MaBoPhanQL
        {
            get
            {
                return _maBoPhanQL;
            }
        }

        protected override object GetIdValue()
        {
            return _maNhanVien;
        }

        #endregion //Business Properties and Methods

        #region Factory Methods
        internal static ChiTietPhuCapAT_HC_TNKVQLChild GetChiTietPhuCapAT_HC_TNKVQLChild(SafeDataReader dr)
        {
            return new ChiTietPhuCapAT_HC_TNKVQLChild(dr);
        }

        private ChiTietPhuCapAT_HC_TNKVQLChild(SafeDataReader dr)
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
            _maNhanVien = dr.GetInt32("MaNhanVien");
            _tenBoPhan = dr.GetString("TenBoPhan");
            _tenNhanVien = dr.GetString("TenNhanVien");
            _soTaiKhoan = dr.GetString("SoTaiKhoan");
            _soCMND = dr.GetString("SoCMND");
            _anTrua = dr.GetDecimal("AnTrua");
            _hanhChinh = dr.GetDecimal("HanhChinh");
            _tnkvql = dr.GetDecimal("TNKVQL");
            _tongCong = dr.GetDecimal("TongCong");
            _maBoPhanQL = dr.GetString("MaBoPhanQL");
        }

        private void FetchChildren(SafeDataReader dr)
        {
        }
        #endregion //Data Access - Fetch
        #endregion //Data Access
    }
}
