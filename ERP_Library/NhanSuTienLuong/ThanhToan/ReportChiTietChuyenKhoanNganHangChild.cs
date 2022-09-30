
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;
//long

namespace ERP_Library.Report
{
    [Serializable()]
    public class ChiTietChuyenKhoanChild : Csla.ReadOnlyBase<ChiTietChuyenKhoanChild>
    {
        #region Business Properties and Methods

        //declare members
        private long _maNhanVien = 0;
        private string _tenNhanVien = string.Empty;
        private string _soTaiKhoan = string.Empty;
        private string _soCMND = string.Empty;
        private decimal _soTien = 0;
        private int _loaiNhanVien = 0;
        private string _tenNganHang = string.Empty;

        private int _maBoPhan = 0;
        private string _maBoPhanQL = string.Empty;
        private string _tenBoPhan = string.Empty;
        private decimal _tienThue = 0;
        private decimal _tienTruocThue = 0;
        private DateTime _ngayLap;
        [System.ComponentModel.DataObjectField(true, false)]
        public long MaNhanVien
        {
            get
            {
                return _maNhanVien;
            }
        }

        public DateTime NgayLap
        {
            get
            {
                return _ngayLap;
            }
        }
        public int MaBoPhan
        {
            get
            {
                return _maBoPhan;
            }
        }
        public string TenNhanVien
        {
            get
            {
                return _tenNhanVien;
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

        public decimal SoTien
        {
            get
            {
                return _soTien;
            }
        }

        public decimal TienThue
        {
            get
            {
                return _tienThue;
            }
        }
        public decimal TienTruocThue
        {
            get
            {
                return _tienTruocThue;
            }
        }

        public int LoaiNhanVien
        {
            get
            {
                return _loaiNhanVien;
            }
        }
        public string TenNganHang
        {
            get
            {
                return _tenNganHang;
            }
        }


        protected override object GetIdValue()
        {
            return _maNhanVien;
        }

        #endregion //Business Properties and Methods

        #region Factory Methods
        internal static ChiTietChuyenKhoanChild GetChiTietChuyenKhoanChild(SafeDataReader dr)
        {
            
            return new ChiTietChuyenKhoanChild(dr);
        }

        //internal static ChiTietChuyenKhoanChild GetChiTietChuyenKhoanChildTruThue(SafeDataReader dr)
        //{
        //   ChiTietChuyenKhoanChild ct=ChiTietChuyenKhoanChild
        //    return new ChiTietChuy(dr);
        //}
        private ChiTietChuyenKhoanChild(SafeDataReader dr)
        {
            Fetch(dr);
        }

        //private ChiTietChuyenKhoanChildTruThue(SafeDataReader dr)
        //{
        //    FetchObjectThue(dr);
        //}
        #endregion //Factory Methods


        #region Data Access

        #region Data Access - Fetch
        private void Fetch(SafeDataReader dr)
        {
            FetchObject(dr);

            //load child object(s)
            FetchChildren(dr);
        }

        //private void FetchThue(SafeDataReader dr)
        //{
        //    FetchObjectThue(dr);

        //    //load child object(s)
        //   // FetchChildren(dr);
        //}
        private void FetchObject(SafeDataReader dr)
        {
            _maNhanVien = dr.GetInt64("MaNhanVien");
            _tenNhanVien = dr.GetString("TenNhanVien");
            _soTaiKhoan = dr.GetString("SoTaiKhoan");
            _soCMND = dr.GetString("SoCMND");
            _soTien = dr.GetDecimal("SoTien");// so tien sau thue
            _loaiNhanVien = dr.GetInt32("LoaiNhanVien");
            _tenNganHang = dr.GetString("TenNganHang");

            _tenBoPhan = dr.GetString("TenBoPhan");
            _maBoPhan = dr.GetInt32("MaBoPhan");
            _maBoPhanQL = dr.GetString("MaBoPhanQL");
            _tienThue = dr.GetDecimal("TienThue");
            _tienTruocThue = dr.GetDecimal("SoTienChuyenTrongDot");
            _ngayLap = dr.GetDateTime("NgayLap");
            
        }

        //private void FetchObjectThue(SafeDataReader dr)
        //{
        //    _maNhanVien = dr.GetInt64("MaNhanVien");
        //    _tenNhanVien = dr.GetString("TenNhanVien");
        //    _soTaiKhoan = dr.GetString("SoTaiKhoan");
        //    _soCMND = dr.GetString("SoCMND");
        //    _soTien = dr.GetDecimal("SoTien");
        //    _loaiNhanVien = dr.GetInt32("LoaiNhanVien");
        //    _tenNganHang = dr.GetString("TenNganHang");

        //    _tenBoPhan = dr.GetString("TenBoPhan");
        //    _maBoPhan = dr.GetInt32("MaBoPhan");
        //    _tienThue = dr.GetDecimal("TienThue");
        //    _tienSauThue = dr.GetDecimal("TienSauThue");
        //}

        private void FetchChildren(SafeDataReader dr)
        {
        }
        #endregion //Data Access - Fetch
        #endregion //Data Access
    }
}
