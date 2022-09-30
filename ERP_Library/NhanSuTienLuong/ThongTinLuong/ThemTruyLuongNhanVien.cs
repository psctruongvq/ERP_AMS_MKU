
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{
    [Serializable()]
    public class ThemTruyLuongNhanVienChild : Csla.ReadOnlyBase<ThemTruyLuongNhanVienChild>
    {
        #region Business Properties and Methods

        //declare members
        private int _maQuyetDinh = 0;
        private string _soQuyetDinh = string.Empty;
        private string _tenBoPhan = string.Empty;
        private string _tenNhanVien = string.Empty;
        private decimal _heSoCu = 0;
        private decimal _heSoMoi = 0;
        private DateTime _ngayHieuLuc = DateTime.Today;
        private int _kyTinhLuongApDung = 0;

        [System.ComponentModel.DataObjectField(true, false)]
        public int MaQuyetDinh
        {
            get
            {
                return _maQuyetDinh;
            }
        }

        public string SoQuyetDinh
        {
            get
            {
                return _soQuyetDinh;
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

        public decimal HeSoCu
        {
            get
            {
                return _heSoCu;
            }
        }

        public decimal HeSoMoi
        {
            get
            {
                return _heSoMoi;
            }
        }

        public DateTime NgayHieuLuc
        {
            get
            {
                return _ngayHieuLuc;
            }
        }

        public int KyTinhLuongApDung
        {
            get
            {
                return _kyTinhLuongApDung;
            }
        }

        protected override object GetIdValue()
        {
            return _maQuyetDinh;
        }

        #endregion //Business Properties and Methods

        #region Factory Methods
        internal static ThemTruyLuongNhanVienChild GetThemTruyLuongNhanVienChild(SafeDataReader dr)
        {
            return new ThemTruyLuongNhanVienChild(dr);
        }

        private ThemTruyLuongNhanVienChild(SafeDataReader dr)
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
            _maQuyetDinh = dr.GetInt32("MaQuyetDinh");
            _soQuyetDinh = dr.GetString("SoQuyetDinh");
            _tenBoPhan = dr.GetString("TenBoPhan");
            _tenNhanVien = dr.GetString("TenNhanVien");
            _heSoCu = dr.GetDecimal("HeSoCu");
            _heSoMoi = dr.GetDecimal("HeSoMoi");
            _ngayHieuLuc = dr.GetDateTime("NgayHieuLuc");
            _kyTinhLuongApDung = dr.GetInt32("KyTinhLuongApDung");
        }

        private void FetchChildren(SafeDataReader dr)
        {
        }
        #endregion //Data Access - Fetch
        #endregion //Data Access
    }
}
