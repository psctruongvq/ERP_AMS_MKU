
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{
    [Serializable()]
    public class DanhSachNhanVienNghiViecChild : Csla.ReadOnlyBase<DanhSachNhanVienNghiViecChild>
    {
        #region Business Properties and Methods

        //declare members
        private string _tenBoPhan = string.Empty;
        private string _maQLNhanVien = string.Empty;
        private string _tenNhanVien = string.Empty;
        private string _tenChucVu = string.Empty;
        private DateTime _tuNgay = DateTime.Today;
        private DateTime _denNgay = DateTime.Today;
        private int _soNgay = 0;
        private string _tenHinhThucNghi = string.Empty;
        private string _lyDo = string.Empty;

        public string TenBoPhan
        {
            get
            {
                CanReadProperty("TenBoPhan", true);
                return _tenBoPhan;
            }
        }

        public string MaQLNhanVien
        {
            get
            {
                CanReadProperty("MaQLNhanVien", true);
                return _maQLNhanVien;
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

        public string TenChucVu
        {
            get
            {
                CanReadProperty("TenChucVu", true);
                return _tenChucVu;
            }
        }

        [System.ComponentModel.DataObjectField(true, false)]
        public DateTime TuNgay
        {
            get
            {
                CanReadProperty("TuNgay", true);
                return _tuNgay;
            }
        }

        [System.ComponentModel.DataObjectField(true, false)]
        public DateTime DenNgay
        {
            get
            {
                CanReadProperty("DenNgay", true);
                return _denNgay;
            }
        }

        public int SoNgay
        {
            get
            {
                CanReadProperty("SoNgay", true);
                return _soNgay;
            }
        }

        public string TenHinhThucNghi
        {
            get
            {
                CanReadProperty("TenHinhThucNghi", true);
                return _tenHinhThucNghi;
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

        protected override object GetIdValue()
        {
            return string.Format("{0}:{1}", _tuNgay, _denNgay);
        }

        #endregion //Business Properties and Methods

        #region Authorization Rules
        protected override void AddAuthorizationRules()
        {
            //TODO: Define authorization rules in DanhSachNhanVienNghiViecChild
            //AuthorizationRules.AllowRead("TenBoPhan", "DanhSachNhanVienNghiViecChildReadGroup");
            //AuthorizationRules.AllowRead("MaQLNhanVien", "DanhSachNhanVienNghiViecChildReadGroup");
            //AuthorizationRules.AllowRead("TenNhanVien", "DanhSachNhanVienNghiViecChildReadGroup");
            //AuthorizationRules.AllowRead("TenChucVu", "DanhSachNhanVienNghiViecChildReadGroup");
            //AuthorizationRules.AllowRead("TuNgay", "DanhSachNhanVienNghiViecChildReadGroup");
            //AuthorizationRules.AllowRead("DenNgay", "DanhSachNhanVienNghiViecChildReadGroup");
            //AuthorizationRules.AllowRead("SoNgay", "DanhSachNhanVienNghiViecChildReadGroup");
            //AuthorizationRules.AllowRead("TenHinhThucNghi", "DanhSachNhanVienNghiViecChildReadGroup");
            //AuthorizationRules.AllowRead("LyDo", "DanhSachNhanVienNghiViecChildReadGroup");

        }

        #endregion //Authorization Rules

        #region Factory Methods
        internal static DanhSachNhanVienNghiViecChild GetDanhSachNhanVienNghiViecChild(SafeDataReader dr)
        {
            return new DanhSachNhanVienNghiViecChild(dr);
        }

        private DanhSachNhanVienNghiViecChild(SafeDataReader dr)
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
            _tenBoPhan = dr.GetString("TenBoPhan");
            _maQLNhanVien = dr.GetString("MaQLNhanVien");
            _tenNhanVien = dr.GetString("TenNhanVien");
            _tenChucVu = dr.GetString("TenChucVu");
            _tuNgay = dr.GetDateTime("TuNgay");
            _denNgay = dr.GetDateTime("DenNgay");
            _soNgay = dr.GetInt32("SoNgay");
            _tenHinhThucNghi = dr.GetString("TenHinhThucNghi");
            _lyDo = dr.GetString("LyDo");
        }

        private void FetchChildren(SafeDataReader dr)
        {
        }
        #endregion //Data Access - Fetch
        #endregion //Data Access
    }
}
