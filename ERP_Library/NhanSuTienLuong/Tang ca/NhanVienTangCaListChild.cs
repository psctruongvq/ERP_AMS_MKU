
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{
    [Serializable()]
    public class NhanVienTangCaListChild : Csla.ReadOnlyBase<NhanVienTangCaListChild>
    {
        #region Business Properties and Methods

        //declare members
        private int _maBangTangCa = 0;
        private string _tenBoPhan = string.Empty;
        private string _tenNhanVien = string.Empty;
        private string _tenLoaiTangCa = string.Empty;
        private DateTime _ngayTangCa = DateTime.Today;
        private DateTime _thoiGianBD = DateTime.Today;
        private DateTime _thoiGianKT = DateTime.Today;
        private decimal _soGio = 0;

        public int MaBangTangCa
        {
            get
            {
                CanReadProperty("MaBangTangCa", true);
                return _maBangTangCa;
            }
        }

        public string TenBoPhan
        {
            get
            {
                CanReadProperty("TenBoPhan", true);
                return _tenBoPhan;
            }
        }

        public string TenNhanVien
        {
            get
            {
                CanReadProperty("TenNhanVien", true);
                return _tenNhanVien;
            }
        }

        public string TenLoaiTangCa
        {
            get
            {
                CanReadProperty("TenLoaiTangCa", true);
                return _tenLoaiTangCa;
            }
        }

        public DateTime NgayTangCa
        {
            get
            {
                CanReadProperty("NgayTangCa", true);
                return _ngayTangCa;
            }
        }

        public DateTime ThoiGianBD
        {
            get
            {
                CanReadProperty("ThoiGianBD", true);
                return _thoiGianBD;
            }
        }

        public DateTime ThoiGianKT
        {
            get
            {
                CanReadProperty("ThoiGianKT", true);
                return _thoiGianKT;
            }
        }

        public decimal SoGio
        {
            get
            {
                CanReadProperty("SoGio", true);
                return _soGio;
            }
        }

        protected override object GetIdValue()
        {
            return _maBangTangCa;
        }

        #endregion //Business Properties and Methods

        #region Authorization Rules
        protected override void AddAuthorizationRules()
        {
            //TODO: Define authorization rules in NhanVienTangCaListChild
            //AuthorizationRules.AllowRead("MaBangTangCa", "NhanVienTangCaListChildReadGroup");
            //AuthorizationRules.AllowRead("TenBoPhan", "NhanVienTangCaListChildReadGroup");
            //AuthorizationRules.AllowRead("TenNhanVien", "NhanVienTangCaListChildReadGroup");
            //AuthorizationRules.AllowRead("TenLoaiTangCa", "NhanVienTangCaListChildReadGroup");
            //AuthorizationRules.AllowRead("NgayTangCa", "NhanVienTangCaListChildReadGroup");
            //AuthorizationRules.AllowRead("ThoiGianBD", "NhanVienTangCaListChildReadGroup");
            //AuthorizationRules.AllowRead("ThoiGianKT", "NhanVienTangCaListChildReadGroup");
            //AuthorizationRules.AllowRead("SoGio", "NhanVienTangCaListChildReadGroup");
            //AuthorizationRules.AllowRead("MaBoPhan", "NhanVienTangCaListChildReadGroup");
            //AuthorizationRules.AllowRead("MaNhanVien", "NhanVienTangCaListChildReadGroup");

        }

        #endregion //Authorization Rules

        #region Factory Methods
        internal static NhanVienTangCaListChild GetNhanVienTangCaListChild(SafeDataReader dr)
        {
            return new NhanVienTangCaListChild(dr);
        }

        private NhanVienTangCaListChild(SafeDataReader dr)
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
            _maBangTangCa = dr.GetInt32("MaBangTangCa");
            _tenBoPhan = dr.GetString("TenBoPhan");
            _tenNhanVien = dr.GetString("TenNhanVien");
            _tenLoaiTangCa = dr.GetString("TenLoaiTangCa");
            _ngayTangCa = dr.GetDateTime("NgayTangCa");
            _thoiGianBD = dr.GetDateTime("ThoiGianBD");
            _thoiGianKT = dr.GetDateTime("ThoiGianKT");
            _soGio = dr.GetDecimal("SoGio");
        }

        private void FetchChildren(SafeDataReader dr)
        {
        }
        #endregion //Data Access - Fetch
        #endregion //Data Access
    }
}
