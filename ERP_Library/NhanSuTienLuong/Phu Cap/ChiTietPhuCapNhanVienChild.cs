
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library.Report
{
    [Serializable()]
    public class ChiTietPhuCapNhanVienChild : Csla.ReadOnlyBase<ChiTietPhuCapNhanVienChild>
    {
        #region Business Properties and Methods

        //declare members
        private long _maNhanVien = 0;
        private string _maBoPhanQL = string.Empty;
        private string _tenBoPhan = string.Empty;
        private string _tenNhanVien = string.Empty;
        private decimal _soTien = 0;
        private string _tenChucVu = "";
        private string _soTaiKhoan = "";
        private string _cmnd = "";
        private decimal _ngoaigio = 0;
        private decimal _hangthang = 0;
        private decimal _phucap = 0;
        private decimal _thuesuat = 0;
        private decimal _tienthue = 0;

        [System.ComponentModel.DataObjectField(true, false)]
        public long MaNhanVien
        {
            get
            {
                return _maNhanVien;
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

        public decimal PhuCap
        {
            get
            {
                return _phucap;
            }
        }

        public decimal ThueSuat
        {
            get
            {
                return _thuesuat;
            }
        }

        public decimal TienThue
        {
            get
            {
                return _tienthue;
            }
        }

        public decimal SoTien
        {
            get
            {
                return _soTien;
            }
        }
       
        public string TenChucVu
        {
            get
            {
                return _tenChucVu;
            }
        }

        public string SoTaiKhoan
        {
            get
            {
                return _soTaiKhoan;
            }
        }

        public string CMND
        {
            get
            {
                return _cmnd;
            }
        }

        public decimal NgoaiGio
        {
            get
            {
                return _ngoaigio;
            }
        }

        public decimal HangThang
        {
            get
            {
                return _hangthang;
            }
        }

        protected override object GetIdValue()
        {
            return _maNhanVien;
        }

        #endregion //Business Properties and Methods

        #region Factory Methods
        private ChiTietPhuCapNhanVienChild() { }

        internal static ChiTietPhuCapNhanVienChild GetChiTietPhuCapNhanVienChild(SafeDataReader dr)
        {
            return new ChiTietPhuCapNhanVienChild(dr);
        }

        internal static ChiTietPhuCapNhanVienChild GetChiTietPhuCapNhanVienChild2Nhom(SafeDataReader dr)
        {
            ChiTietPhuCapNhanVienChild item = new ChiTietPhuCapNhanVienChild();
            item.FetchObject2Nhom(dr);
            return item;
        }

        private ChiTietPhuCapNhanVienChild(SafeDataReader dr)
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
            _maBoPhanQL = dr.GetString("MaBoPhanQL");
            _tenBoPhan = dr.GetString("TenBoPhan");
            _tenNhanVien = dr.GetString("TenNhanVien");
            _soTien = dr.GetDecimal("SoTien");
            _tenChucVu = dr.GetString("TenChucVu");
            _soTaiKhoan= dr.GetString("SoTaiKhoan");
            _cmnd = dr.GetString("CMND");
            _phucap = dr.GetDecimal("PhuCap");
            _thuesuat = dr.GetDecimal("ThueSuat");
            _tienthue = dr.GetDecimal("TienThue");
        }

        private void FetchObject2Nhom(SafeDataReader dr)
        {
            _maNhanVien = dr.GetInt64("MaNhanVien");
            _maBoPhanQL = dr.GetString("MaBoPhanQL");
            _tenBoPhan = dr.GetString("TenBoPhan");
            _tenNhanVien = dr.GetString("TenNhanVien");
            _soTien = dr.GetDecimal("SoTien");
            _tenChucVu = dr.GetString("TenChucVu");
            _soTaiKhoan = dr.GetString("SoTaiKhoan");
            _cmnd = dr.GetString("CMND");
            _ngoaigio = dr.GetDecimal("NgoaiGio");
            _hangthang = dr.GetDecimal("HangThang");
        }

        private void FetchChildren(SafeDataReader dr)
        {
        }
        #endregion //Data Access - Fetch
        #endregion //Data Access
    }
}
