
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{
    [Serializable()]
    public class BaoCaoCongDoanPhiChild : Csla.ReadOnlyBase<BaoCaoCongDoanPhiChild>
    {
        #region Business Properties and Methods

        //declare members
        private long _maNhanVien = 0;
        private string _tenNhanVien = string.Empty;
        private int _maBoPhan = 0;
        private string _tenBoPhan = string.Empty;
        private decimal _ky1 = 0;
        private decimal _ky2 = 0;
        private decimal _ky3 = 0;
        private decimal _tongCong = 0;
        private string _maBoPhanQL = "";

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

        public int MaBoPhan
        {
            get
            {
                return _maBoPhan;
            }
        }

        public string TenBoPhan
        {
            get
            {
                return _tenBoPhan;
            }
        }

        public decimal Ky1
        {
            get
            {
                return _ky1;
            }
        }

        public decimal Ky2
        {
            get
            {
                return _ky2;
            }
        }

        public decimal Ky3
        {
            get
            {
                return _ky3;
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
        internal static BaoCaoCongDoanPhiChild GetBaoCaoCongDoanPhiChild(SafeDataReader dr)
        {
            return new BaoCaoCongDoanPhiChild(dr);
        }
        internal static BaoCaoCongDoanPhiChild GetBaoCaoTongHop(SafeDataReader dr)
        {
            BaoCaoCongDoanPhiChild item = new BaoCaoCongDoanPhiChild();
            item.FetchTongHop(dr);
            return item;
        }

        private BaoCaoCongDoanPhiChild(SafeDataReader dr)
        {
            Fetch(dr);
        }
        private BaoCaoCongDoanPhiChild() { }
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
            _maNhanVien = dr.GetInt64("MaNhanVien");
            _tenNhanVien = dr.GetString("TenNhanVien");
            _maBoPhan = dr.GetInt32("MaBoPhan");
            _tenBoPhan = dr.GetString("TenBoPhan");
            _ky1 = dr.GetDecimal("Ky1");
            _ky2 = dr.GetDecimal("Ky2");
            _ky3 = dr.GetDecimal("Ky3");
            _tongCong = dr.GetDecimal("TongCong");
            _maBoPhanQL = dr.GetString("MaBoPhanQL");
        }

        private void FetchTongHop(SafeDataReader dr)
        {
            _maBoPhan = dr.GetInt32("MaBoPhan");
            _tenBoPhan = dr.GetString("TenBoPhan");
            _ky1 = dr.GetDecimal("Ky1");
            _ky2 = dr.GetDecimal("Ky2");
            _ky3 = dr.GetDecimal("Ky3");
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
