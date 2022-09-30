
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{
    [Serializable()]
    public class GiayNghiPhepNuocNgoaiListChild : Csla.ReadOnlyBase<GiayNghiPhepNuocNgoaiListChild>
    {
        #region Business Properties and Methods

        //declare members
        private int _maNghiPhep = 0;
        private string _so = string.Empty;
        private SmartDate _ngay = new SmartDate(DateTime.Today);
        private string _tenNhanVien = string.Empty;
        private string _lyDo = string.Empty;
        private SmartDate _tuNgay = new SmartDate(DateTime.Today);
        private SmartDate _denNgay = new SmartDate(DateTime.Today);
        private int _maKyTinhLuong = 0;

        public int MaKyTinhLuong
        {
            get
            {
                CanReadProperty("MaKyTinhLuong", true);
                return _maKyTinhLuong;
            }

        }
        public int MaNghiPhep
        {
            get
            {
                CanReadProperty("MaNghiPhep", true);
                return _maNghiPhep;
            }
        }

        public string So
        {
            get
            {
                CanReadProperty("So", true);
                return _so;
            }
        }

        public DateTime Ngay
        {
            get
            {
                CanReadProperty("Ngay", true);
                return _ngay.Date;
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

        public string LyDo
        {
            get
            {
                CanReadProperty("LyDo", true);
                return _lyDo;
            }
        }

        [System.ComponentModel.DataObjectField(true, false)]
        public DateTime TuNgay
        {
            get
            {
                CanReadProperty("TuNgay", true);
                return _tuNgay.Date;
            }
        }

        [System.ComponentModel.DataObjectField(true, false)]
        public DateTime DenNgay
        {
            get
            {
                CanReadProperty("DenNgay", true);
                return _denNgay.Date;
            }
        }

        protected override object GetIdValue()
        {
            return _maNghiPhep;
        }

        #endregion //Business Properties and Methods

        #region Authorization Rules
        protected override void AddAuthorizationRules()
        {
            //TODO: Define authorization rules in GiayNghiPhepNuocNgoaiListChild
            //AuthorizationRules.AllowRead("MaNghiPhep", "GiayNghiPhepNuocNgoaiListChildReadGroup");
            //AuthorizationRules.AllowRead("So", "GiayNghiPhepNuocNgoaiListChildReadGroup");
            //AuthorizationRules.AllowRead("Ngay", "GiayNghiPhepNuocNgoaiListChildReadGroup");
            //AuthorizationRules.AllowRead("NgayString", "GiayNghiPhepNuocNgoaiListChildReadGroup");
            //AuthorizationRules.AllowRead("TenNhanVien", "GiayNghiPhepNuocNgoaiListChildReadGroup");
            //AuthorizationRules.AllowRead("LyDo", "GiayNghiPhepNuocNgoaiListChildReadGroup");
            //AuthorizationRules.AllowRead("TuNgay", "GiayNghiPhepNuocNgoaiListChildReadGroup");
            //AuthorizationRules.AllowRead("TuNgayString", "GiayNghiPhepNuocNgoaiListChildReadGroup");
            //AuthorizationRules.AllowRead("DenNgay", "GiayNghiPhepNuocNgoaiListChildReadGroup");
            //AuthorizationRules.AllowRead("DenNgayString", "GiayNghiPhepNuocNgoaiListChildReadGroup");

        }

        #endregion //Authorization Rules

        #region Factory Methods
        internal static GiayNghiPhepNuocNgoaiListChild GetGiayNghiPhepNuocNgoaiListChild(SafeDataReader dr)
        {
            return new GiayNghiPhepNuocNgoaiListChild(dr);
        }

        private GiayNghiPhepNuocNgoaiListChild(SafeDataReader dr)
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
            _maNghiPhep = dr.GetInt32("MaNghiPhep");
            _so = dr.GetString("So");
            _ngay = dr.GetSmartDate("Ngay", _ngay.EmptyIsMin);
            _tenNhanVien = dr.GetString("TenNhanVien");
            _lyDo = dr.GetString("LyDo");
            _tuNgay = dr.GetSmartDate("TuNgay", _tuNgay.EmptyIsMin);
            _denNgay = dr.GetSmartDate("DenNgay", _denNgay.EmptyIsMin);
            _maKyTinhLuong = dr.GetInt32("MaKyTinhLuong");
        }

        private void FetchChildren(SafeDataReader dr)
        {
        }
        #endregion //Data Access - Fetch
        #endregion //Data Access
    }
}
