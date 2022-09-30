using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{
    [Serializable()]
    public class HoatDongDev : Csla.BusinessBase<HoatDongDev>
    {
        #region Business Properties and Methods

        //declare members
        private int _maHoatDong = 0;
        private string _tenHoatDong = string.Empty;
        private string _maQLHoatDong = string.Empty;
        private int _maCongTy = 0;
        private string _englishName = string.Empty;
        private bool _ngungSuDung = false;

        [System.ComponentModel.DataObjectField(true, true)]
        public int MaHoatDong
        {
            get
            {
                CanReadProperty("MaHoatDong", true);
                return _maHoatDong;
            }
        }

        public string TenHoatDong
        {
            get
            {
                CanReadProperty("TenHoatDong", true);
                return _tenHoatDong;
            }
            set
            {
                CanWriteProperty("TenHoatDong", true);
                if (value == null) value = string.Empty;
                if (!_tenHoatDong.Equals(value))
                {
                    _tenHoatDong = value;
                    PropertyHasChanged("TenHoatDong");
                }
            }
        }

        public string MaQLHoatDong
        {
            get
            {
                CanReadProperty("MaQLHoatDong", true);
                return _maQLHoatDong;
            }
            set
            {
                CanWriteProperty("MaQLHoatDong", true);
                if (value == null) value = string.Empty;
                if (!_maQLHoatDong.Equals(value))
                {
                    _maQLHoatDong = value;
                    PropertyHasChanged("MaQLHoatDong");
                }
            }
        }

        public int MaCongTy
        {
            get
            {
                CanReadProperty("MaCongTy", true);
                return _maCongTy;
            }
            set
            {
                CanWriteProperty("MaCongTy", true);
                if (!_maCongTy.Equals(value))
                {
                    _maCongTy = value;
                    PropertyHasChanged("MaCongTy");
                }
            }
        }

        public string EnglishName
        {
            get
            {
                CanReadProperty("EnglishName", true);
                return _englishName;
            }
            set
            {
                CanWriteProperty("EnglishName", true);
                if (value == null) value = string.Empty;
                if (!_englishName.Equals(value))
                {
                    _englishName = value;
                    PropertyHasChanged("EnglishName");
                }
            }
        }

        public bool NgungSuDung
        {
            get
            {
                CanReadProperty("NgungSuDung", true);
                return _ngungSuDung;
            }
            set
            {
                CanWriteProperty("NgungSuDung", true);
                if (!_ngungSuDung.Equals(value))
                {
                    _ngungSuDung = value;
                    PropertyHasChanged("NgungSuDung");
                }
            }
        }

        protected override object GetIdValue()
        {
            return _maHoatDong;
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
            // TenHoatDong
            //
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("TenHoatDong", 2000));
            //
            // MaQLHoatDong
            //
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("MaQLHoatDong", 50));
            //
            // EnglishName
            //
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("EnglishName", 2000));
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
            //TODO: Define authorization rules in HoatDongDev
            //AuthorizationRules.AllowRead("MaHoatDong", "HoatDongDevReadGroup");
            //AuthorizationRules.AllowRead("TenHoatDong", "HoatDongDevReadGroup");
            //AuthorizationRules.AllowRead("MaQLHoatDong", "HoatDongDevReadGroup");
            //AuthorizationRules.AllowRead("MaCongTy", "HoatDongDevReadGroup");
            //AuthorizationRules.AllowRead("EnglishName", "HoatDongDevReadGroup");
            //AuthorizationRules.AllowRead("NgungSuDung", "HoatDongDevReadGroup");

            //AuthorizationRules.AllowWrite("TenHoatDong", "HoatDongDevWriteGroup");
            //AuthorizationRules.AllowWrite("MaQLHoatDong", "HoatDongDevWriteGroup");
            //AuthorizationRules.AllowWrite("MaCongTy", "HoatDongDevWriteGroup");
            //AuthorizationRules.AllowWrite("EnglishName", "HoatDongDevWriteGroup");
            //AuthorizationRules.AllowWrite("NgungSuDung", "HoatDongDevWriteGroup");
        }


        public static bool CanGetObject()
        {
            //TODO: Define CanGetObject permission in HoatDongDev
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("HoatDongDevViewGroup"))
            //	return true;
            //return false;
        }

        public static bool CanAddObject()
        {
            //TODO: Define CanAddObject permission in HoatDongDev
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("HoatDongDevAddGroup"))
            //	return true;
            //return false;
        }

        public static bool CanEditObject()
        {
            //TODO: Define CanEditObject permission in HoatDongDev
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("HoatDongDevEditGroup"))
            //	return true;
            //return false;
        }

        public static bool CanDeleteObject()
        {
            //TODO: Define CanDeleteObject permission in HoatDongDev
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("HoatDongDevDeleteGroup"))
            //	return true;
            //return false;
        }
        #endregion //Authorization Rules

        #region Factory Methods
        private HoatDongDev()
        { /* require use of factory method */ }

        public static HoatDongDev NewHoatDongDev()
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a HoatDongDev");
            return DataPortal.Create<HoatDongDev>();
        }

        public static HoatDongDev GetHoatDongDev(int maHoatDong)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a HoatDongDev");
            return DataPortal.Fetch<HoatDongDev>(new Criteria(maHoatDong));
        }

        public static void DeleteHoatDongDev(int maHoatDong)
        {
            if (!CanDeleteObject())
                throw new System.Security.SecurityException("User not authorized to remove a HoatDongDev");
            DataPortal.Delete(new Criteria(maHoatDong));
        }

        public override HoatDongDev Save()
        {
            if (IsDeleted && !CanDeleteObject())
                throw new System.Security.SecurityException("User not authorized to remove a HoatDongDev");
            else if (IsNew && !CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a HoatDongDev");
            else if (!CanEditObject())
                throw new System.Security.SecurityException("User not authorized to update a HoatDongDev");

            return base.Save();
        }

        #endregion //Factory Methods

        #region Child Factory Methods
        internal static HoatDongDev NewHoatDongDevChild()
        {
            HoatDongDev child = new HoatDongDev();
            child.ValidationRules.CheckRules();
            child.MarkAsChild();
            return child;
        }

        internal static HoatDongDev GetHoatDongDev(SafeDataReader dr)
        {
            HoatDongDev child = new HoatDongDev();
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
            public int MaHoatDong;

            public Criteria(int maHoatDong)
            {
                this.MaHoatDong = maHoatDong;
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
                cm.CommandText = "spd_SelecttblHoatDongDev";

                cm.Parameters.AddWithValue("@MaHoatDong", criteria.MaHoatDong);

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
            DataPortal_Delete(new Criteria(_maHoatDong));
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
                cm.CommandText = "spd_DeletetblHoatDongDev";

                cm.Parameters.AddWithValue("@MaHoatDong", criteria.MaHoatDong);

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
            _maHoatDong = dr.GetInt32("MaHoatDong");
            _tenHoatDong = dr.GetString("TenHoatDong");
            _maQLHoatDong = dr.GetString("MaQLHoatDong");
            _maCongTy = dr.GetInt32("MaCongTy");
            _englishName = dr.GetString("EnglishName");
            _ngungSuDung = dr.GetBoolean("NgungSuDung");
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
                cm.CommandText = "spd_InserttblHoatDongDev";

                AddInsertParameters(cm);

                cm.ExecuteNonQuery();

                _maHoatDong = (int)cm.Parameters["@MaHoatDong"].Value;
            }//using
        }

        private void AddInsertParameters(SqlCommand cm)
        {
            if (_tenHoatDong.Length > 0)
                cm.Parameters.AddWithValue("@TenHoatDong", _tenHoatDong);
            else
                cm.Parameters.AddWithValue("@TenHoatDong", DBNull.Value);
            if (_maQLHoatDong.Length > 0)
                cm.Parameters.AddWithValue("@MaQLHoatDong", _maQLHoatDong);
            else
                cm.Parameters.AddWithValue("@MaQLHoatDong", DBNull.Value);
            if (_maCongTy != 0)
                cm.Parameters.AddWithValue("@MaCongTy", _maCongTy);
            else
                cm.Parameters.AddWithValue("@MaCongTy", DBNull.Value);
            if (_englishName.Length > 0)
                cm.Parameters.AddWithValue("@EnglishName", _englishName);
            else
                cm.Parameters.AddWithValue("@EnglishName", DBNull.Value);
            if (_ngungSuDung != false)
                cm.Parameters.AddWithValue("@NgungSuDung", _ngungSuDung);
            else
                cm.Parameters.AddWithValue("@NgungSuDung", DBNull.Value);
            cm.Parameters.AddWithValue("@MaHoatDong", _maHoatDong);
            cm.Parameters["@MaHoatDong"].Direction = ParameterDirection.Output;
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
                cm.CommandText = "spd_UpdatetblHoatDongDev";

                AddUpdateParameters(cm);

                cm.ExecuteNonQuery();

            }//using
        }

        private void AddUpdateParameters(SqlCommand cm)
        {
            cm.Parameters.AddWithValue("@MaHoatDong", _maHoatDong);
            if (_tenHoatDong.Length > 0)
                cm.Parameters.AddWithValue("@TenHoatDong", _tenHoatDong);
            else
                cm.Parameters.AddWithValue("@TenHoatDong", DBNull.Value);
            if (_maQLHoatDong.Length > 0)
                cm.Parameters.AddWithValue("@MaQLHoatDong", _maQLHoatDong);
            else
                cm.Parameters.AddWithValue("@MaQLHoatDong", DBNull.Value);
            if (_maCongTy != 0)
                cm.Parameters.AddWithValue("@MaCongTy", _maCongTy);
            else
                cm.Parameters.AddWithValue("@MaCongTy", DBNull.Value);
            if (_englishName.Length > 0)
                cm.Parameters.AddWithValue("@EnglishName", _englishName);
            else
                cm.Parameters.AddWithValue("@EnglishName", DBNull.Value);
            if (_ngungSuDung != false)
                cm.Parameters.AddWithValue("@NgungSuDung", _ngungSuDung);
            else
                cm.Parameters.AddWithValue("@NgungSuDung", DBNull.Value);
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

            ExecuteDelete(cn, new Criteria(_maHoatDong));
            MarkNew();
        }
        #endregion //Data Access - Delete
        #endregion //Data Access
    }
}
