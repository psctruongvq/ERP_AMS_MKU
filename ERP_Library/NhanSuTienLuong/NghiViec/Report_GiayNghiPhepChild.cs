
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library.Report
{
    [Serializable()]
    public class GiayNghiPhepChild : Csla.ReadOnlyBase<GiayNghiPhepChild>
    {
        #region Business Properties and Methods

        //declare members
        private string _so = string.Empty;
        private DateTime _ngay = DateTime.Today;
        private string _tenBoPhan = string.Empty;
        private string _tenNhanVien = string.Empty;
        private string _lyDo = string.Empty;
        private DateTime _tuNgay = DateTime.Today;
        private DateTime _denNgay = DateTime.Today;
        private int _ngayPhep = 0;
        private string _ghiChu = string.Empty;

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
                return _ngay;
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

        public string LyDo
        {
            get
            {
                CanReadProperty("LyDo", true);
                return _lyDo;
            }
        }

        public DateTime TuNgay
        {
            get
            {
                CanReadProperty("TuNgay", true);
                return _tuNgay;
            }
        }

        public DateTime DenNgay
        {
            get
            {
                CanReadProperty("DenNgay", true);
                return _denNgay;
            }
        }

        public int NgayPhep
        {
            get
            {
                CanReadProperty("NgayPhep", true);
                return _ngayPhep;
            }
        }

        public string GhiChu
        {
            get
            {
                CanReadProperty("GhiChu", true);
                return _ghiChu;
            }
        }

        protected override object GetIdValue()
		{
            return string.Format("{0}{1}", _so, _ngay);
		}

        #endregion //Business Properties and Methods

        #region Authorization Rules
        protected override void AddAuthorizationRules()
        {
            //TODO: Define authorization rules in GiayNghiPhepChild
            //AuthorizationRules.AllowRead("So", "GiayNghiPhepChildReadGroup");
            //AuthorizationRules.AllowRead("Ngay", "GiayNghiPhepChildReadGroup");
            //AuthorizationRules.AllowRead("TenBoPhan", "GiayNghiPhepChildReadGroup");
            //AuthorizationRules.AllowRead("TenNhanVien", "GiayNghiPhepChildReadGroup");
            //AuthorizationRules.AllowRead("LyDo", "GiayNghiPhepChildReadGroup");
            //AuthorizationRules.AllowRead("TuNgay", "GiayNghiPhepChildReadGroup");
            //AuthorizationRules.AllowRead("DenNgay", "GiayNghiPhepChildReadGroup");
            //AuthorizationRules.AllowRead("NgayPhep", "GiayNghiPhepChildReadGroup");
            //AuthorizationRules.AllowRead("GhiChu", "GiayNghiPhepChildReadGroup");

        }

        #endregion //Authorization Rules

        #region Factory Methods
        internal static GiayNghiPhepChild GetGiayNghiPhepChild(SafeDataReader dr)
        {
            return new GiayNghiPhepChild(dr);
        }

        private GiayNghiPhepChild(SafeDataReader dr)
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
            _so = dr.GetString("So");
            _ngay = dr.GetDateTime("Ngay");
            _tenBoPhan = dr.GetString("TenBoPhan");
            _tenNhanVien = dr.GetString("TenNhanVien");
            _lyDo = dr.GetString("LyDo");
            _tuNgay = dr.GetDateTime("TuNgay");
            _denNgay = dr.GetDateTime("DenNgay");
            _ngayPhep = dr.GetInt32("NgayPhep");
            _ghiChu = dr.GetString("GhiChu");
        }

        private void FetchChildren(SafeDataReader dr)
        {
        }
        #endregion //Data Access - Fetch
        #endregion //Data Access
    }
}
