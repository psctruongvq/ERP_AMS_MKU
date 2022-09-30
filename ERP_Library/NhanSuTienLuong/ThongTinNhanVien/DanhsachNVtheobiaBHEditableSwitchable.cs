
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{
    [Serializable()]
    public class DanhsachNVTheoBiaBHXH : Csla.BusinessBase<DanhsachNVTheoBiaBHXH>
    {
        #region Business Properties and Methods

        //declare members
        private long _maNhanVien = 0;
        private int _Masobaohiem = 0;
        private string _maQLNhanVien = string.Empty;
        private string _tenNhanVien = string.Empty;
        private string _tenChucVu = string.Empty;
        private int _maChucVu = 0;
        private int _maBoPhan = 0;
        private string _tenBoPhan = string.Empty;
        private DateTime _ngayVaoLam = DateTime.Today;
        private string _sosoBaohiem = string.Empty;
        [System.ComponentModel.DataObjectField(true, false)]
        public long MaNhanVien
        {
            get
            {
                CanReadProperty("MaNhanVien", true);
                return _maNhanVien;
            }
        }

        public int Masobaohiem
        {
            get
            {
                CanReadProperty("Masobaohiem", true);
                return _Masobaohiem;
            }
        }

        public string MaQLNhanVien
        {
            get
            {
                CanReadProperty("MaQLNhanVien", true);
                return _maQLNhanVien;
            }
            set
            {
                CanWriteProperty("MaQLNhanVien", true);
                if (value == null) value = string.Empty;
                if (!_maQLNhanVien.Equals(value))
                {
                    _maQLNhanVien = value;
                    PropertyHasChanged("MaQLNhanVien");
                }
            }
        }

        public string TenNhanVien
        {
            get
            {
                CanReadProperty("TenNhanVien", true);
                return _tenNhanVien;
            }
            set
            {
                CanWriteProperty("TenNhanVien", true);
                if (value == null) value = string.Empty;
                if (!_tenNhanVien.Equals(value))
                {
                    _tenNhanVien = value;
                    PropertyHasChanged("TenNhanVien");
                }
            }
        }

        public string Sosobaohiem
        {
            get
            {
                CanReadProperty("Sosobaohiem", true);
                return _sosoBaohiem;
            }
            set
            {
                CanWriteProperty("Sosobaohiem", true);
                if (value == null) value = string.Empty;
                if (!_sosoBaohiem.Equals(value))
                {
                    _sosoBaohiem = value;
                    PropertyHasChanged("Sosobaohiem");
                }
            }
        }

        public string TenChucVu
        {
            get
            {
                CanReadProperty("TenChucVu", true);
                return _tenChucVu;
            }
            set
            {
                CanWriteProperty("TenChucVu", true);
                if (value == null) value = string.Empty;
                if (!_tenChucVu.Equals(value))
                {
                    _tenChucVu = value;
                    PropertyHasChanged("TenChucVu");
                }
            }
        }

        public int MaChucVu
        {
            get
            {
                CanReadProperty("MaChucVu", true);
                return _maChucVu;
            }
            set
            {
                CanWriteProperty("MaChucVu", true);
                if (!_maChucVu.Equals(value))
                {
                    _maChucVu = value;
                    PropertyHasChanged("MaChucVu");
                }
            }
        }

        public int MaBoPhan
        {
            get
            {
                CanReadProperty("MaBoPhan", true);
                return _maBoPhan;
            }
            set
            {
                CanWriteProperty("MaBoPhan", true);
                if (!_maBoPhan.Equals(value))
                {
                    _maBoPhan = value;
                    PropertyHasChanged("MaBoPhan");
                }
            }
        }

        public string TenBoPhan
        {
            get
            {
                CanReadProperty("TenBoPhan", true);
                return _tenBoPhan;
            }
            set
            {
                CanWriteProperty("TenBoPhan", true);
                if (value == null) value = string.Empty;
                if (!_tenBoPhan.Equals(value))
                {
                    _tenBoPhan = value;
                    PropertyHasChanged("TenBoPhan");
                }
            }
        }

        public DateTime NgayVaoLam
        {
            get
            {
                CanReadProperty("NgayVaoLam", true);
                return _ngayVaoLam.Date;
            }
            set
            {
                CanWriteProperty("NgayVaoLam", true);
                if (!_ngayVaoLam.Equals(value))
                {
                    _ngayVaoLam = value;
                    PropertyHasChanged("NgayVaoLam");
                }
            }
        }

        protected override object GetIdValue()
        {
            return _maNhanVien;
        }

        #endregion //Business Properties and Methods

        #region Validation Rules
        private void AddCustomRules()
        {
            //add custom/non-generated rules here...
        }

        private void AddCommonRules()
        {
            // TenNhanVien
            //
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("TenNhanVien", 500));
            //
            // TenChucVu
            //
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("TenChucVu", 500));
        }

        protected override void AddBusinessRules()
        {
            AddCommonRules();
            AddCustomRules();
        }
        #endregion //Validation Rules

        #region Authorization Rules
        protected override void AddAuthorizationRules()
        {

        }


        public static bool CanGetObject()
        {
            //TODO: Define CanGetObject permission in ThongTinNhanVienTongHop
            return true;
            //	return true;
            //return false;
        }

        public static bool CanAddObject()
        {
            //TODO: Define CanAddObject permission in ThongTinNhanVienTongHop
            return true;
            //	return true;
            //return false;
        }

        public static bool CanEditObject()
        {
            //TODO: Define CanEditObject permission in ThongTinNhanVienTongHop
            return true;
            //	return true;
            //return false;
        }

        public static bool CanDeleteObject()
        {
            //TODO: Define CanDeleteObject permission in ThongTinNhanVienTongHop
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("ThongTinNhanVienTongHopDeleteGroup"))
            //	return true;
            //return false;
        }
        #endregion //Authorization Rules

        #region Factory Methods
        private DanhsachNVTheoBiaBHXH()
        { /* require use of factory method */ }

        public static DanhsachNVTheoBiaBHXH NewDanhsachNVTheoBiaBHXH(long maNhanVien)
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a ThongTinNhanVienTongHop");
            return DataPortal.Create<DanhsachNVTheoBiaBHXH>(new Criteria(maNhanVien));
        }

        public static DanhsachNVTheoBiaBHXH GetDanhsachNVTheoBiaBHXH(long maNhanVien)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a ThongTinNhanVienTongHop");
            return DataPortal.Fetch<DanhsachNVTheoBiaBHXH>(new Criteria(maNhanVien));
        }
        public override DanhsachNVTheoBiaBHXH Save()
        {
            if (IsDeleted && !CanDeleteObject())
                throw new System.Security.SecurityException("User not authorized to remove a ThongTinNhanVienTongHop");
            else if (IsNew && !CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a ThongTinNhanVienTongHop");
            else if (!CanEditObject())
                throw new System.Security.SecurityException("User not authorized to update a ThongTinNhanVienTongHop");

            return base.Save();
        }

        #endregion //Factory Methods

        #region Child Factory Methods
        private DanhsachNVTheoBiaBHXH(long maNhanVien)
        {
            this._maNhanVien = maNhanVien;
        }

        internal static DanhsachNVTheoBiaBHXH NewDanhsachNVTheoBiaBHXHChild(long maNhanVien)
        {
            DanhsachNVTheoBiaBHXH child = new DanhsachNVTheoBiaBHXH(maNhanVien);
            child.ValidationRules.CheckRules();
            child.MarkAsChild();
            return child;
        }

        internal static DanhsachNVTheoBiaBHXH GetDanhsachNVTheoBiaBHXH(SafeDataReader dr)
        {
            DanhsachNVTheoBiaBHXH child = new DanhsachNVTheoBiaBHXH();
            child.MarkAsChild();
            child.Fetch(dr);
            return child;
        }
        #endregion //Child Factory Methods

        #region Data Access

        #region Criteria

        [Serializable()]
        private class Criteria
        {
            public long MaNhanVien;

            public Criteria(long maNhanVien)
            {
                this.MaNhanVien = maNhanVien;
            }
        }

        #endregion //Criteria

        #region Data Access - Create
        [RunLocal]
        private void DataPortal_Create(Criteria criteria)
        {
            _maNhanVien = criteria.MaNhanVien;
            ValidationRules.CheckRules();
        }

        #endregion //Data Access - Create

        #region Data Access - Fetch
        private void DataPortal_Fetch(Criteria criteria)
        {
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();

                ExecuteFetch(cn, criteria);
            }//using
        }

        private void ExecuteFetch(SqlConnection cn, Criteria criteria)
        {
            using (SqlCommand cm = cn.CreateCommand())
            {
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_ThongTinNhanVien";

                cm.Parameters.AddWithValue("@MaNhanVien", criteria.MaNhanVien);

                using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                {
                    dr.Read();
                    FetchObject(dr);
                    ValidationRules.CheckRules();

                    //load child object(s)
                    FetchChildren(dr);
                }
            }//using
        }

        #endregion //Data Access - Fetch

        #region Data Access - Fetch
        private void Fetch(SafeDataReader dr)
        {
            FetchObject(dr);
            MarkOld();
            ValidationRules.CheckRules();

            //load child object(s)
            FetchChildren(dr);
        }

        private void FetchObject(SafeDataReader dr)
        {
            try
            {
                _sosoBaohiem = dr.GetString("Sosobaohiem");
                _Masobaohiem = dr.GetInt32("masobaohiem");
                _maNhanVien = dr.GetInt64("MaNhanVien");
                _maQLNhanVien = dr.GetString("Maquanly");
                _tenNhanVien = dr.GetString("TenNhanVien");
                _tenChucVu = dr.GetString("TenChucVu");
                _maChucVu = dr.GetInt32("MaChucVu");
                _ngayVaoLam = dr.GetDateTime("NgayVaolam");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void FetchChildren(SafeDataReader dr)
        {

        }
        #endregion //Data Access - Fetch

        #endregion //Data Access
    }
}
