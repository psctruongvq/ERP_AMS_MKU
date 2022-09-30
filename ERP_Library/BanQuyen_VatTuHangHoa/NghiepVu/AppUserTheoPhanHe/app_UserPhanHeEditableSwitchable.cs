using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{
    [Serializable()]
    public class app_UserPhanHeEditableSwitchable : Csla.BusinessBase<app_UserPhanHeEditableSwitchable>
    {
        #region Business Properties and Methods

        //declare members
        private int _id = 0;
        private int _userID = 0;
        private int _nguoiLap = 0;
        private int _maPhanHe = 0;
        private string _description = string.Empty;

        [System.ComponentModel.DataObjectField(true, true)]
        public int Id
        {
            get
            {
                CanReadProperty("Id", true);
                return _id;
            }
        }

        public int UserID
        {
            get
            {
                CanReadProperty("UserID", true);
                return _userID;
            }
            set
            {
                CanWriteProperty("UserID", true);
                if (!_userID.Equals(value))
                {
                    _userID = value;
                    PropertyHasChanged("UserID");
                }
            }
        }

        public int NguoiLap
        {
            get
            {
                CanReadProperty("NguoiLap", true);
                return _nguoiLap;
            }
            set
            {
                CanWriteProperty("NguoiLap", true);
                if (!_nguoiLap.Equals(value))
                {
                    _nguoiLap = value;
                    PropertyHasChanged("NguoiLap");
                }
            }
        }

        public int MaPhanHe
        {
            get
            {
                CanReadProperty("MaPhanHe", true);
                return _maPhanHe;
            }
            set
            {
                CanWriteProperty("MaPhanHe", true);
                if (!_maPhanHe.Equals(value))
                {
                    _maPhanHe = value;
                    PropertyHasChanged("MaPhanHe");
                }
            }
        }

        public string Description
        {
            get
            {
                CanReadProperty("Description", true);
                return _description;
            }
            set
            {
                CanWriteProperty("Description", true);
                if (value == null) value = string.Empty;
                if (!_description.Equals(value))
                {
                    _description = value;
                    PropertyHasChanged("Description");
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
            //TODO: Define authorization rules in app_UserPhanHeEditableSwitchable
            //AuthorizationRules.AllowRead("Id", "app_UserPhanHeEditableSwitchableReadGroup");
            //AuthorizationRules.AllowRead("UserID", "app_UserPhanHeEditableSwitchableReadGroup");
            //AuthorizationRules.AllowRead("NguoiLap", "app_UserPhanHeEditableSwitchableReadGroup");
            //AuthorizationRules.AllowRead("MaPhanHe", "app_UserPhanHeEditableSwitchableReadGroup");
            //AuthorizationRules.AllowRead("Description", "app_UserPhanHeEditableSwitchableReadGroup");

            //AuthorizationRules.AllowWrite("UserID", "app_UserPhanHeEditableSwitchableWriteGroup");
            //AuthorizationRules.AllowWrite("NguoiLap", "app_UserPhanHeEditableSwitchableWriteGroup");
            //AuthorizationRules.AllowWrite("MaPhanHe", "app_UserPhanHeEditableSwitchableWriteGroup");
            //AuthorizationRules.AllowWrite("Description", "app_UserPhanHeEditableSwitchableWriteGroup");
        }


        public static bool CanGetObject()
        {
            //TODO: Define CanGetObject permission in app_UserPhanHeEditableSwitchable
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("app_UserPhanHeEditableSwitchableViewGroup"))
            //	return true;
            //return false;
        }

        public static bool CanAddObject()
        {
            //TODO: Define CanAddObject permission in app_UserPhanHeEditableSwitchable
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("app_UserPhanHeEditableSwitchableAddGroup"))
            //	return true;
            //return false;
        }

        public static bool CanEditObject()
        {
            //TODO: Define CanEditObject permission in app_UserPhanHeEditableSwitchable
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("app_UserPhanHeEditableSwitchableEditGroup"))
            //	return true;
            //return false;
        }

        public static bool CanDeleteObject()
        {
            //TODO: Define CanDeleteObject permission in app_UserPhanHeEditableSwitchable
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("app_UserPhanHeEditableSwitchableDeleteGroup"))
            //	return true;
            //return false;
        }
        #endregion //Authorization Rules

        #region Factory Methods
        private app_UserPhanHeEditableSwitchable()
        { /* require use of factory method */ }

        public static app_UserPhanHeEditableSwitchable Newapp_UserPhanHeEditableSwitchable()
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a app_UserPhanHeEditableSwitchable");
            return DataPortal.Create<app_UserPhanHeEditableSwitchable>();
        }

        public static app_UserPhanHeEditableSwitchable Getapp_UserPhanHeEditableSwitchable(int id)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a app_UserPhanHeEditableSwitchable");
            return DataPortal.Fetch<app_UserPhanHeEditableSwitchable>(new Criteria(id));
        }

        public static void Deleteapp_UserPhanHeEditableSwitchable(int id)
        {
            if (!CanDeleteObject())
                throw new System.Security.SecurityException("User not authorized to remove a app_UserPhanHeEditableSwitchable");
            DataPortal.Delete(new Criteria(id));
        }

        public override app_UserPhanHeEditableSwitchable Save()
        {
            if (IsDeleted && !CanDeleteObject())
                throw new System.Security.SecurityException("User not authorized to remove a app_UserPhanHeEditableSwitchable");
            else if (IsNew && !CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a app_UserPhanHeEditableSwitchable");
            else if (!CanEditObject())
                throw new System.Security.SecurityException("User not authorized to update a app_UserPhanHeEditableSwitchable");

            return base.Save();
        }

        #endregion //Factory Methods

        #region Child Factory Methods
        internal static app_UserPhanHeEditableSwitchable Newapp_UserPhanHeEditableSwitchableChild()
        {
            app_UserPhanHeEditableSwitchable child = new app_UserPhanHeEditableSwitchable();
            child.ValidationRules.CheckRules();
            child.MarkAsChild();
            return child;
        }

        internal static app_UserPhanHeEditableSwitchable Getapp_UserPhanHeEditableSwitchable(SafeDataReader dr)
        {
            app_UserPhanHeEditableSwitchable child = new app_UserPhanHeEditableSwitchable();
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
            public int Id;

            public Criteria(int id)
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
                cm.CommandText = "spd_Selectapp_UserPhanHe";

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
                cm.CommandText = "spd_Deleteapp_UserPhanHe";

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
            _id = dr.GetInt32("ID");
            _userID = dr.GetInt32("UserID");
            _nguoiLap = dr.GetInt32("NguoiLap");
            _maPhanHe = dr.GetInt32("MaPhanHe");
            _description = dr.GetString("Description");
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
                cm.CommandText = "spd_Insertapp_UserPhanHe";

                AddInsertParameters(cm);

                cm.ExecuteNonQuery();

                _id = (int)cm.Parameters["@ID"].Value;
            }//using
        }

        private void AddInsertParameters(SqlCommand cm)
        {
            cm.Parameters.AddWithValue("@UserID", _userID);
            cm.Parameters.AddWithValue("@NguoiLap", _nguoiLap);
            cm.Parameters.AddWithValue("@MaPhanHe", _maPhanHe);
            if (_description.Length > 0)
                cm.Parameters.AddWithValue("@Description", _description);
            else
                cm.Parameters.AddWithValue("@Description", DBNull.Value);
            cm.Parameters.AddWithValue("@ID", _id);
            cm.Parameters["@ID"].Direction = ParameterDirection.Output;
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
                cm.CommandText = "spd_Updateapp_UserPhanHe";

                AddUpdateParameters(cm);

                cm.ExecuteNonQuery();

            }//using
        }

        private void AddUpdateParameters(SqlCommand cm)
        {
            cm.Parameters.AddWithValue("@ID", _id);
            cm.Parameters.AddWithValue("@UserID", _userID);
            cm.Parameters.AddWithValue("@NguoiLap", _nguoiLap);
            cm.Parameters.AddWithValue("@MaPhanHe", _maPhanHe);
            if (_description.Length > 0)
                cm.Parameters.AddWithValue("@Description", _description);
            else
                cm.Parameters.AddWithValue("@Description", DBNull.Value);
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
