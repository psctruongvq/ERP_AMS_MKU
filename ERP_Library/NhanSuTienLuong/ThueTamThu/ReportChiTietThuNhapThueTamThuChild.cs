
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library.Report
{
    [Serializable()]
    public class ChiTietThuNhapThueTamThuChild : Csla.ReadOnlyBase<ChiTietThuNhapThueTamThuChild>
    {
        #region Business Properties and Methods

        //declare members
        private long _maNhanVien = 0;
        private int _maBoPhan = 0;
        private string _maBoPhanQL = string.Empty;
        private string _tenBoPhan = string.Empty;
        private string _tenNhanVien = string.Empty;
        private decimal _thuNhap = 0;
        private decimal _thueTamThu = 0;
        private decimal _thucLanh = 0;

        [System.ComponentModel.DataObjectField(true, false)]
        public long MaNhanVien
        {
            get
            {
                return _maNhanVien;
            }
        }

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

        public string TenNhanVien
        {
            get
            {
                return _tenNhanVien;
            }
        }

        public decimal ThuNhap
        {
            get
            {
                return _thuNhap;
            }
        }

        public decimal ThueTamThu
        {
            get
            {
                return _thueTamThu;
            }
        }

        public decimal ThucLanh
        {
            get
            {
                return _thucLanh;
            }
        }

        protected override object GetIdValue()
        {
            return _maNhanVien;
        }

        #endregion //Business Properties and Methods

        #region Factory Methods
        internal static ChiTietThuNhapThueTamThuChild GetChiTietThuNhapThueTamThuChild(SafeDataReader dr)
        {
            return new ChiTietThuNhapThueTamThuChild(dr);
        }

        private ChiTietThuNhapThueTamThuChild(SafeDataReader dr)
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
            _maNhanVien = dr.GetInt64("MaNhanVien");
            _maBoPhan = dr.GetInt32("MaBoPhan");
            _maBoPhanQL = dr.GetString("MaBoPhanQL");
            _tenBoPhan = dr.GetString("TenBoPhan");
            _tenNhanVien = dr.GetString("TenNhanVien");
            _thuNhap = dr.GetDecimal("ThuNhap");
            _thueTamThu = dr.GetDecimal("ThueTamThu");
            _thucLanh = dr.GetDecimal("ThucLanh");
        }

        private void FetchChildren(SafeDataReader dr)
        {
        }
        #endregion //Data Access - Fetch
        #endregion //Data Access
    }
}
