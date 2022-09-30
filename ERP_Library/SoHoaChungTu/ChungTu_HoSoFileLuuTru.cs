using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{
    [Serializable()]
    public class ChungTu_HoSoFileLuuTru : Csla.BusinessBase<ChungTu_HoSoFileLuuTru>
    {
        #region Business Properties and Methods

        //declare members
        private long _id = 0;
        private string _username = string.Empty;
        private string _password = string.Empty;
        private string _urlHosochungtu = string.Empty;
        private string _urlCongty = string.Empty;
        private long _maChungTu = 0;
        private string _tenFile = string.Empty;
        private string _tenFileUp = string.Empty;
        private int _loaiNghiepVu = 0;
        public int MaLoaiNghiepVu
        {
            get
            {
                CanReadProperty("LoaiNghiepVu", true);
                return _loaiNghiepVu;
            }
            set
            {
                CanWriteProperty("LoaiNghiepVu", true);
                if (!_loaiNghiepVu.Equals(value))
                {
                    _loaiNghiepVu = value;
                    PropertyHasChanged("LoaiNghiepVu");
                }
            }
        }
        [System.ComponentModel.DataObjectField(true, true)]
        public long Id
        {
            get
            {
                CanReadProperty("Id", true);
                return _id;
            }
        }

        public string Username
        {
            get
            {
                CanReadProperty("Username", true);
                return _username;
            }
            set
            {
                CanWriteProperty("Username", true);
                if (value == null) value = string.Empty;
                if (!_username.Equals(value))
                {
                    _username = value;
                    PropertyHasChanged("Username");
                }
            }
        }

        public string Password
        {
            get
            {
                CanReadProperty("Password", true);
                return _password;
            }
            set
            {
                CanWriteProperty("Password", true);
                if (value == null) value = string.Empty;
                if (!_password.Equals(value))
                {
                    _password = value;
                    PropertyHasChanged("Password");
                }
            }
        }

        public string UrlHosochungtu
        {
            get
            {
                CanReadProperty("UrlHosochungtu", true);
                return _urlHosochungtu;
            }
            set
            {
                CanWriteProperty("UrlHosochungtu", true);
                if (value == null) value = string.Empty;
                if (!_urlHosochungtu.Equals(value))
                {
                    _urlHosochungtu = value;
                    PropertyHasChanged("UrlHosochungtu");
                }
            }
        }

        public string UrlCongty
        {
            get
            {
                CanReadProperty("UrlCongty", true);
                return _urlCongty;
            }
            set
            {
                CanWriteProperty("UrlCongty", true);
                if (value == null) value = string.Empty;
                if (!_urlCongty.Equals(value))
                {
                    _urlCongty = value;
                    PropertyHasChanged("UrlCongty");
                }
            }
        }

        public long MaChungTu
        {
            get
            {
                CanReadProperty("MaChungTu", true);
                return _maChungTu;
            }
            set
            {
                CanWriteProperty("MaChungTu", true);
                if (!_maChungTu.Equals(value))
                {
                    _maChungTu = value;
                    PropertyHasChanged("MaChungTu");
                }
            }
        }

        public string TenFile
        {
            get
            {
                CanReadProperty("TenFile", true);
                return _tenFile;
            }
            set
            {
                CanWriteProperty("TenFile", true);
                if (value == null) value = string.Empty;
                if (!_tenFile.Equals(value))
                {
                    _tenFile = value;
                    PropertyHasChanged("TenFile");
                }
            }
        }
        public string TenFileUp
        {
            get
            {
                CanReadProperty("TenFileUp", true);
                return _tenFileUp;
            }
            set
            {
                CanWriteProperty("TenFileUp", true);
                if (value == null) value = string.Empty;
                if (!_tenFileUp.Equals(value))
                {
                    _tenFileUp = value;
                    PropertyHasChanged("TenFileUp");
                }
            }
        }
        protected override object GetIdValue()
        {
            return _id;
        }

        #endregion //Business Properties and Methods

        #region Validation Rules
        private void AddCustomRules()
        {
            //add custom/non-generated rules here...
        }

        private void AddCommonRules()
        {
            //
            // Username
            //
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("Username", 100));
            //
            // Password
            //
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("Password", 100));
            //
            // UrlHosochungtu
            //
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("UrlHosochungtu", 500));
            //
            // UrlCongty
            //
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("UrlCongty", 100));
            //
            // TenFile
            //
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("TenFile", 500));
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
            //TODO: Define authorization rules in ChungTu_HoSoFileLuuTru
            //AuthorizationRules.AllowRead("Id", "ChungTu_HoSoFileLuuTruReadGroup");
            //AuthorizationRules.AllowRead("Username", "ChungTu_HoSoFileLuuTruReadGroup");
            //AuthorizationRules.AllowRead("Password", "ChungTu_HoSoFileLuuTruReadGroup");
            //AuthorizationRules.AllowRead("UrlHosochungtu", "ChungTu_HoSoFileLuuTruReadGroup");
            //AuthorizationRules.AllowRead("UrlCongty", "ChungTu_HoSoFileLuuTruReadGroup");
            //AuthorizationRules.AllowRead("MaChungTu", "ChungTu_HoSoFileLuuTruReadGroup");
            //AuthorizationRules.AllowRead("TenFile", "ChungTu_HoSoFileLuuTruReadGroup");

            //AuthorizationRules.AllowWrite("Username", "ChungTu_HoSoFileLuuTruWriteGroup");
            //AuthorizationRules.AllowWrite("Password", "ChungTu_HoSoFileLuuTruWriteGroup");
            //AuthorizationRules.AllowWrite("UrlHosochungtu", "ChungTu_HoSoFileLuuTruWriteGroup");
            //AuthorizationRules.AllowWrite("UrlCongty", "ChungTu_HoSoFileLuuTruWriteGroup");
            //AuthorizationRules.AllowWrite("MaChungTu", "ChungTu_HoSoFileLuuTruWriteGroup");
            //AuthorizationRules.AllowWrite("TenFile", "ChungTu_HoSoFileLuuTruWriteGroup");
        }


        public static bool CanGetObject()
        {
            //TODO: Define CanGetObject permission in ChungTu_HoSoFileLuuTru
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("ChungTu_HoSoFileLuuTruViewGroup"))
            //	return true;
            //return false;
        }

        public static bool CanAddObject()
        {
            //TODO: Define CanAddObject permission in ChungTu_HoSoFileLuuTru
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("ChungTu_HoSoFileLuuTruAddGroup"))
            //	return true;
            //return false;
        }

        public static bool CanEditObject()
        {
            //TODO: Define CanEditObject permission in ChungTu_HoSoFileLuuTru
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("ChungTu_HoSoFileLuuTruEditGroup"))
            //	return true;
            //return false;
        }

        public static bool CanDeleteObject()
        {
            //TODO: Define CanDeleteObject permission in ChungTu_HoSoFileLuuTru
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("ChungTu_HoSoFileLuuTruDeleteGroup"))
            //	return true;
            //return false;
        }
        #endregion //Authorization Rules

        #region Factory Methods
        private ChungTu_HoSoFileLuuTru()
        { /* require use of factory method */  MarkAsChild(); }

        public static ChungTu_HoSoFileLuuTru NewChungTu_HoSoFileLuuTru()
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a ChungTu_HoSoFileLuuTru");
            return DataPortal.Create<ChungTu_HoSoFileLuuTru>();
        }

        public static ChungTu_HoSoFileLuuTru GetChungTu_HoSoFileLuuTru(long id)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a ChungTu_HoSoFileLuuTru");
            return DataPortal.Fetch<ChungTu_HoSoFileLuuTru>(new Criteria(id));
        }

        public static void DeleteChungTu_HoSoFileLuuTru(long id)
        {
            if (!CanDeleteObject())
                throw new System.Security.SecurityException("User not authorized to remove a ChungTu_HoSoFileLuuTru");
            DataPortal.Delete(new Criteria(id));
        }

        public override ChungTu_HoSoFileLuuTru Save()
        {
            if (IsDeleted && !CanDeleteObject())
                throw new System.Security.SecurityException("User not authorized to remove a ChungTu_HoSoFileLuuTru");
            else if (IsNew && !CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a ChungTu_HoSoFileLuuTru");
            else if (!CanEditObject())
                throw new System.Security.SecurityException("User not authorized to update a ChungTu_HoSoFileLuuTru");

            return base.Save();
        }

        #endregion //Factory Methods

        #region Child Factory Methods
        internal static ChungTu_HoSoFileLuuTru NewChungTu_HoSoFileLuuTruChild()
        {
            ChungTu_HoSoFileLuuTru child = new ChungTu_HoSoFileLuuTru();
            child.ValidationRules.CheckRules();
            child.MarkAsChild();
            return child;
        }

        internal static ChungTu_HoSoFileLuuTru GetChungTu_HoSoFileLuuTru(SafeDataReader dr)
        {
            ChungTu_HoSoFileLuuTru child = new ChungTu_HoSoFileLuuTru();
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
            public long Id;

            public Criteria(long id)
            {
                this.Id = id;
            }
        }

        #endregion //Criteria

        #region Data Access - Create
        [RunLocal]
        protected override void DataPortal_Create()
        {
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
                cm.CommandText = "GetChungTu_HoSoFileLuuTru";

                cm.Parameters.AddWithValue("@ID", criteria.Id);

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

        #region Data Access - Insert
        protected override void DataPortal_Insert()
        {
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();

                ExecuteInsert(cn);

                //update child object(s)
                UpdateChildren(cn);
            }//using

        }

        #endregion //Data Access - Insert

        #region Data Access - Update
        protected override void DataPortal_Update()
        {
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();

                if (base.IsDirty)
                {
                    ExecuteUpdate(cn);
                }

                //update child object(s)
                UpdateChildren(cn);
            }//using

        }

        #endregion //Data Access - Update

        #region Data Access - Delete
        protected override void DataPortal_DeleteSelf()
        {
            DataPortal_Delete(new Criteria(_id));
        }

        private void DataPortal_Delete(Criteria criteria)
        {
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();

                ExecuteDelete(cn, criteria);

            }//using

        }

        private void ExecuteDelete(SqlConnection cn, Criteria criteria)
        {
            using (SqlCommand cm = cn.CreateCommand())
            {
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "DeleteChungTu_HoSoFileLuuTru";

                cm.Parameters.AddWithValue("@ID", criteria.Id);

                cm.ExecuteNonQuery();
            }//using
        }
        #endregion //Data Access - Delete

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
            _id = dr.GetInt64("ID");
            _username = dr.GetString("Username");
            _password = dr.GetString("Password");
            _urlHosochungtu = dr.GetString("URL_HoSoChungTu");
            _urlCongty = dr.GetString("URL_CongTy");
            _maChungTu = dr.GetInt64("MaChungTu");
            _tenFile = dr.GetString("TenFile");
            _tenFileUp = dr.GetString("TenFileUp");
            _loaiNghiepVu = dr.GetInt32("LoaiNghiepVu");
        }

        private void FetchChildren(SafeDataReader dr)
        {
        }
        #endregion //Data Access - Fetch

        #region Data Access - Insert
        internal void Insert(SqlConnection cn)
        {
            if (!IsDirty) return;

            ExecuteInsert(cn);
            MarkOld();

            //update child object(s)
            UpdateChildren(cn);
        }

        private void ExecuteInsert(SqlConnection cn)
        {
            using (SqlCommand cm = cn.CreateCommand())
            {
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "AddChungTu_HoSoFileLuuTru";

                AddInsertParameters(cm);

                cm.ExecuteNonQuery();

                _id = (long)cm.Parameters["@NewID"].Value;
            }//using
        }

        private void AddInsertParameters(SqlCommand cm)
        {
            //TODO: if parent use identity key, fix fk member with value from parent
            if (_username.Length > 0)
                cm.Parameters.AddWithValue("@Username", _username);
            else
                cm.Parameters.AddWithValue("@Username", DBNull.Value);
            if (_password.Length > 0)
                cm.Parameters.AddWithValue("@Password", _password);
            else
                cm.Parameters.AddWithValue("@Password", DBNull.Value);
            if (_urlHosochungtu.Length > 0)
                cm.Parameters.AddWithValue("@URL_HoSoChungTu", _urlHosochungtu);
            else
                cm.Parameters.AddWithValue("@URL_HoSoChungTu", DBNull.Value);
            if (_urlCongty.Length > 0)
                cm.Parameters.AddWithValue("@URL_CongTy", _urlCongty);
            else
                cm.Parameters.AddWithValue("@URL_CongTy", DBNull.Value);
            if (_maChungTu != 0)
                cm.Parameters.AddWithValue("@MaChungTu", _maChungTu);
            else
                cm.Parameters.AddWithValue("@MaChungTu", DBNull.Value);
            if (_tenFile.Length > 0)
                cm.Parameters.AddWithValue("@TenFile", _tenFile);
            else
                cm.Parameters.AddWithValue("@TenFile", DBNull.Value);
            if (_tenFileUp.Length > 0)
                cm.Parameters.AddWithValue("@TenFileUp", _tenFileUp);
            else
                cm.Parameters.AddWithValue("@TenFileUp", DBNull.Value);
            if (_loaiNghiepVu != 0)
                cm.Parameters.AddWithValue("@MaLoaiNghiepVu", _loaiNghiepVu);
            else
                cm.Parameters.AddWithValue("@MaLoaiNghiepVu", DBNull.Value);
            cm.Parameters.AddWithValue("@NewID", _id);
            cm.Parameters["@NewID"].Direction = ParameterDirection.Output;
        }
        #endregion //Data Access - Insert

        #region Data Access - Update
        internal void Update(SqlConnection cn)
        {
            if (!IsDirty) return;

            if (base.IsDirty)
            {
                ExecuteUpdate(cn);
                MarkOld();
            }

            //update child object(s)
            UpdateChildren(cn);
        }

        private void ExecuteUpdate(SqlConnection cn)
        {
            using (SqlCommand cm = cn.CreateCommand())
            {
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "UpdateChungTu_HoSoFileLuuTru";

                AddUpdateParameters(cm);

                cm.ExecuteNonQuery();

            }//using
        }

        private void AddUpdateParameters(SqlCommand cm)
        {
            cm.Parameters.AddWithValue("@ID", _id);
            if (_username.Length > 0)
                cm.Parameters.AddWithValue("@Username", _username);
            else
                cm.Parameters.AddWithValue("@Username", DBNull.Value);
            if (_password.Length > 0)
                cm.Parameters.AddWithValue("@Password", _password);
            else
                cm.Parameters.AddWithValue("@Password", DBNull.Value);
            if (_urlHosochungtu.Length > 0)
                cm.Parameters.AddWithValue("@URL_HoSoChungTu", _urlHosochungtu);
            else
                cm.Parameters.AddWithValue("@URL_HoSoChungTu", DBNull.Value);
            if (_urlCongty.Length > 0)
                cm.Parameters.AddWithValue("@URL_CongTy", _urlCongty);
            else
                cm.Parameters.AddWithValue("@URL_CongTy", DBNull.Value);
            if (_maChungTu != 0)
                cm.Parameters.AddWithValue("@MaChungTu", _maChungTu);
            else
                cm.Parameters.AddWithValue("@MaChungTu", DBNull.Value);
            if (_tenFile.Length > 0)
                cm.Parameters.AddWithValue("@TenFile", _tenFile);
            else
                cm.Parameters.AddWithValue("@TenFile", DBNull.Value);
            if (_tenFileUp.Length > 0)
                cm.Parameters.AddWithValue("@TenFileUp", _tenFileUp);
            else
                cm.Parameters.AddWithValue("@TenFileUp", DBNull.Value);
            if (_loaiNghiepVu != 0)
                cm.Parameters.AddWithValue("@MaLoaiNghiepVu", _loaiNghiepVu);
            else
                cm.Parameters.AddWithValue("@MaLoaiNghiepVu", DBNull.Value);
        }

        private void UpdateChildren(SqlConnection cn)
        {
        }
        #endregion //Data Access - Update

        #region Data Access - Delete
        internal void DeleteSelf(SqlConnection cn)
        {
            if (!IsDirty) return;
            if (IsNew) return;

            ExecuteDelete(cn, new Criteria(_id));
            MarkNew();
        }
        #endregion //Data Access - Delete
        #endregion //Data Access
    }
}
