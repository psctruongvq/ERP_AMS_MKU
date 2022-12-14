
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library.Report
{
    [Serializable()]
    public class ChiTietPhuCapNgoaiGioChild : Csla.ReadOnlyBase<ChiTietPhuCapNgoaiGioChild>
    {
        #region Business Properties and Methods

        //declare members
        private int _maBoPhan = 0;
        private int _maNhanVien = 0;
        private int _maLoaiPhuCap = 0;
        private string _maBoPhanQL = string.Empty;
        private string _tenBoPhan = string.Empty;
        private string _tenNhanVien = string.Empty;
        private string _tenLoaiPhuCap = string.Empty;
        private decimal _soTien = 0;
        private string _tenThoiGian = string.Empty;
        private decimal _thoiGian = 0;
        private int _sTTCot = 0;

        [System.ComponentModel.DataObjectField(true, false)]
        public int MaBoPhan
        {
            get
            {
                return _maBoPhan;
            }
        }

        [System.ComponentModel.DataObjectField(true, false)]
        public int MaNhanVien
        {
            get
            {
                return _maNhanVien;
            }
        }

        public int MaLoaiPhuCap
        {
            get
            {
                return _maLoaiPhuCap;
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

        public int STTCot
        {
            get
            {
                return _sTTCot;
            }
        }

        protected override object GetIdValue()
        {
            return string.Format("{0}:{1}", _maBoPhan, _maNhanVien);
        }

        #endregion //Business Properties and Methods

        #region Factory Methods
        internal static ChiTietPhuCapNgoaiGioChild GetChiTietPhuCapNgoaiGioChild(SafeDataReader dr)
        {
            return new ChiTietPhuCapNgoaiGioChild(dr);
        }

        private ChiTietPhuCapNgoaiGioChild(SafeDataReader dr)
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
            _maNhanVien = dr.GetInt32("MaNhanVien");
            _maLoaiPhuCap = dr.GetInt32("MaLoaiPhuCap");
            _maBoPhanQL = dr.GetString("MaBoPhanQL");
            _tenBoPhan = dr.GetString("TenBoPhan");
            _tenNhanVien = dr.GetString("TenNhanVien");
            _tenLoaiPhuCap = dr.GetString("TenLoaiPhuCap");
            _soTien = dr.GetDecimal("SoTien");
            _tenThoiGian = dr.GetString("TenThoiGian");
            _thoiGian = dr.GetDecimal("ThoiGian");
            _sTTCot = dr.GetInt32("STTCot");
        }

        private void FetchChildren(SafeDataReader dr)
        {
        }
        #endregion //Data Access - Fetch
        #endregion //Data Access
    }
}
