
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{
    [Serializable()]
    public class NhanVienComboListChild : Csla.ReadOnlyBase<NhanVienComboListChild>
    {
        #region Business Properties and Methods

        //declare members
        private long _maNhanVien = 0;
        private string _maQLNhanVien = string.Empty;
        private string _tenNhanVien = string.Empty;
        private string _cardID = string.Empty;
        private string _tenChucVu = string.Empty;
        private int _maBoPhan = 0;
        private string _tenBoPhan = string.Empty;

        public long MaNhanVien
        {
            get
            {
                CanReadProperty("MaNhanVien", true);
                return _maNhanVien;
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

        public string CardID
        {
            get
            {
                CanReadProperty("CardID", true);
                return _cardID;
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

        public int MaBoPhan
        {
            get
            {
                CanReadProperty("MaBoPhan", true);
                return _maBoPhan;
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

        protected override object GetIdValue()
		{
            return _maNhanVien;
		}

        #endregion //Business Properties and Methods

        #region Authorization Rules
        protected override void AddAuthorizationRules()
        {
            //TODO: Define authorization rules in NhanVienComboListChild
            //AuthorizationRules.AllowRead("MaNhanVien", "NhanVienComboListChildReadGroup");
            //AuthorizationRules.AllowRead("MaQLNhanVien", "NhanVienComboListChildReadGroup");
            //AuthorizationRules.AllowRead("TenNhanVien", "NhanVienComboListChildReadGroup");
            //AuthorizationRules.AllowRead("CardID", "NhanVienComboListChildReadGroup");
            //AuthorizationRules.AllowRead("TenChucVu", "NhanVienComboListChildReadGroup");
            //AuthorizationRules.AllowRead("TenBoPhan", "NhanVienComboListChildReadGroup");

        }

        #endregion //Authorization Rules

        #region Factory Methods
        internal static NhanVienComboListChild GetNhanVienComboListChild(SafeDataReader dr)
        {
            return new NhanVienComboListChild(dr);
        }
      
        private NhanVienComboListChild(SafeDataReader dr)
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
            _maQLNhanVien = dr.GetString("MaQLNhanVien");
            _tenNhanVien = dr.GetString("TenNhanVien");
            _cardID = dr.GetString("CardID");
            _tenChucVu = dr.GetString("TenChucVu");
            _maBoPhan = dr.GetInt32("MaBoPhan");
            _tenBoPhan = dr.GetString("TenBoPhan");
        }

        private void FetchChildren(SafeDataReader dr)
        {
        }
        #endregion //Data Access - Fetch
        #endregion //Data Access
    }
}
