
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{
    [Serializable()]
    public class LoaiQuy : Csla.BusinessBase<LoaiQuy>
    {
        #region Business Properties and Methods

        //declare members
        private int _maCacQuy = 0;
        private string _tenCacQuy = string.Empty;
        private string _maCacQuyQL = string.Empty;
        private DateTime _ngayLap = DateTime.Today;
        private int _userID = 0;

        [System.ComponentModel.DataObjectField(true, true)]
        public int MaCacQuy
        {
            get
            {
                CanReadProperty("MaCacQuy", true);
                return _maCacQuy;
            }
        }

        public string TenCacQuy
        {
            get
            {
                CanReadProperty("TenCacQuy", true);
                return _tenCacQuy;
            }
            set
            {
                CanWriteProperty("TenCacQuy", true);
                if (value == null) value = string.Empty;
                if (!_tenCacQuy.Equals(value))
                {
                    _tenCacQuy = value;
                    PropertyHasChanged("TenCacQuy");
                }
            }
        }

        public string MaCacQuyQL
        {
            get
            {
                CanReadProperty("MaCacQuyQL", true);
                return _maCacQuyQL;
            }
            set
            {
                CanWriteProperty("MaCacQuyQL", true);
                if (value == null) value = string.Empty;
                if (!_maCacQuyQL.Equals(value))
                {
                    _maCacQuyQL = value;
                    PropertyHasChanged("MaCacQuyQL");
                }
            }
        }

        public DateTime NgayLap
        {
            get
            {
                CanReadProperty("NgayLap", true);
                return _ngayLap.Date;
            }
            set
            {
                CanWriteProperty("NgayLap", true);
                if (!_ngayLap.Equals(value))
                {
                    _ngayLap = value;
                    PropertyHasChanged("NgayLap");
                }
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

        protected override object GetIdValue()
        {
            return _maCacQuy;
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
            // TenCacQuy
            //
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("TenCacQuy", 4000));
            //
            // MaCacQuyQL
            //
            ValidationRules.AddRule(CommonRules.StringRequired, "MaCacQuyQL");
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("MaCacQuyQL", 50));
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
            //TODO: Define authorization rules in LoaiQuy
            //AuthorizationRules.AllowRead("MaCacQuy", "LoaiQuyReadGroup");
            //AuthorizationRules.AllowRead("TenCacQuy", "LoaiQuyReadGroup");
            //AuthorizationRules.AllowRead("MaCacQuyQL", "LoaiQuyReadGroup");
            //AuthorizationRules.AllowRead("NgayLap", "LoaiQuyReadGroup");
            //AuthorizationRules.AllowRead("NgayLapString", "LoaiQuyReadGroup");
            //AuthorizationRules.AllowRead("UserID", "LoaiQuyReadGroup");
            //AuthorizationRules.AllowRead("NgayHeThong", "LoaiQuyReadGroup");
            //AuthorizationRules.AllowRead("NgayHeThongString", "LoaiQuyReadGroup");

            //AuthorizationRules.AllowWrite("TenCacQuy", "LoaiQuyWriteGroup");
            //AuthorizationRules.AllowWrite("MaCacQuyQL", "LoaiQuyWriteGroup");
            //AuthorizationRules.AllowWrite("NgayLapString", "LoaiQuyWriteGroup");
            //AuthorizationRules.AllowWrite("UserID", "LoaiQuyWriteGroup");
            //AuthorizationRules.AllowWrite("NgayHeThongString", "LoaiQuyWriteGroup");
        }


        public static bool CanGetObject()
        {
            //TODO: Define CanGetObject permission in LoaiQuy
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("LoaiQuyViewGroup"))
            //	return true;
            //return false;
        }

        public static bool CanAddObject()
        {
            //TODO: Define CanAddObject permission in LoaiQuy
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("LoaiQuyAddGroup"))
            //	return true;
            //return false;
        }

        public static bool CanEditObject()
        {
            //TODO: Define CanEditObject permission in LoaiQuy
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("LoaiQuyEditGroup"))
            //	return true;
            //return false;
        }

        public static bool CanDeleteObject()
        {
            //TODO: Define CanDeleteObject permission in LoaiQuy
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("LoaiQuyDeleteGroup"))
            //	return true;
            //return false;
        }
        #endregion //Authorization Rules

        #region Factory Methods
        private LoaiQuy()
        { 
            /* require use of factory method */
            MarkAsChild();        
        }


        public static LoaiQuy NewLoaiQuy()
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a LoaiQuy");
            return DataPortal.Create<LoaiQuy>();
        }

        public static LoaiQuy NewLoaiQuy(string TenQuy)
        {
            LoaiQuy obj = new LoaiQuy();
            obj.TenCacQuy = TenQuy;
            return obj;
        }

        public static LoaiQuy GetLoaiQuy(int maCacQuy)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a LoaiQuy");
            return DataPortal.Fetch<LoaiQuy>(new Criteria(maCacQuy));
        }

        public static void DeleteLoaiQuy(int maCacQuy)
        {
            if (!CanDeleteObject())
                throw new System.Security.SecurityException("User not authorized to remove a LoaiQuy");
            DataPortal.Delete(new Criteria(maCacQuy));
        }

        public override LoaiQuy Save()
        {
            if (IsDeleted && !CanDeleteObject())
                throw new System.Security.SecurityException("User not authorized to remove a LoaiQuy");
            else if (IsNew && !CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a LoaiQuy");
            else if (!CanEditObject())
                throw new System.Security.SecurityException("User not authorized to update a LoaiQuy");

            return base.Save();
        }

        #endregion //Factory Methods

        #region Child Factory Methods
        internal static LoaiQuy NewLoaiQuyChild()
        {
            LoaiQuy child = new LoaiQuy();
            child.ValidationRules.CheckRules();
            child.MarkAsChild();
            return child;
        }

        internal static LoaiQuy GetLoaiQuy(SafeDataReader dr)
        {
            LoaiQuy child = new LoaiQuy();
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
            public int MaCacQuy;

            public Criteria(int maCacQuy)
            {
                this.MaCacQuy = maCacQuy;
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
            SqlTransaction tr;

            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();

                tr = cn.BeginTransaction();
                try
                {
                    ExecuteFetch(tr, criteria);

                    tr.Commit();
                }
                catch
                {
                    tr.Rollback();
                    throw;
                }
            }//using
        }

        private void ExecuteFetch(SqlTransaction tr, Criteria criteria)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_SelecttblLoaiQuy";

                cm.Parameters.AddWithValue("@MaCacQuy", criteria.MaCacQuy);

                using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                {
                    while (dr.Read())
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
            SqlTransaction tr;

            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();

                tr = cn.BeginTransaction();
                try
                {
                    ExecuteInsert(tr, null);

                    //update child object(s)
                    UpdateChildren(tr);

                    tr.Commit();
                }
                catch
                {
                    tr.Rollback();
                    throw;
                }
            }//using

        }

        #endregion //Data Access - Insert

        #region Data Access - Update
        protected override void DataPortal_Update()
        {
            SqlTransaction tr;

            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();

                tr = cn.BeginTransaction();
                try
                {
                    if (base.IsDirty)
                    {
                        ExecuteUpdate(tr, null);
                    }

                    //update child object(s)
                    UpdateChildren(tr);

                    tr.Commit();
                }
                catch
                {
                    tr.Rollback();
                    throw;
                }
            }//using

        }

        #endregion //Data Access - Update

        #region Data Access - Delete
        protected override void DataPortal_DeleteSelf()
        {
            DataPortal_Delete(new Criteria(_maCacQuy));
        }

        private void DataPortal_Delete(Criteria criteria)
        {
            SqlTransaction tr;

            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();

                tr = cn.BeginTransaction();
                try
                {
                    ExecuteDelete(tr, criteria);

                    tr.Commit();
                }
                catch
                {
                    tr.Rollback();
                    throw;
                }
            }//using

        }

        private void ExecuteDelete(SqlTransaction tr, Criteria criteria)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_DeletetblLoaiQuy";

                cm.Parameters.AddWithValue("@MaCacQuy", criteria.MaCacQuy);

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
            _maCacQuy = dr.GetInt32("MaCacQuy");
            _tenCacQuy = dr.GetString("TenCacQuy");
            _maCacQuyQL = dr.GetString("MaCacQuyQL");
            _ngayLap = dr.GetDateTime("NgayLap");
            _userID = dr.GetInt32("UserID");
        }

        private void FetchChildren(SafeDataReader dr)
        {
        }
        #endregion //Data Access - Fetch

        #region Data Access - Insert
        internal void Insert(SqlTransaction tr, LoaiQuyList parent)
        {
            if (!IsDirty) return;

            ExecuteInsert(tr, parent);
            MarkOld();

            //update child object(s)
            UpdateChildren(tr);
        }

        private void ExecuteInsert(SqlTransaction tr, LoaiQuyList parent)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_InserttblLoaiQuy";

                AddInsertParameters(cm, parent);

                cm.ExecuteNonQuery();

                _maCacQuy = (int)cm.Parameters["@MaCacQuy"].Value;
            }//using
        }

        private void AddInsertParameters(SqlCommand cm, LoaiQuyList parent)
        {
            //TODO: if parent use identity key, fix fk member with value from parent
            if (_tenCacQuy.Length > 0)
                cm.Parameters.AddWithValue("@TenCacQuy", _tenCacQuy);
            else
                cm.Parameters.AddWithValue("@TenCacQuy", DBNull.Value);
            cm.Parameters.AddWithValue("@MaCacQuyQL", _maCacQuyQL);
            cm.Parameters.AddWithValue("@NgayLap", _ngayLap);
            cm.Parameters.AddWithValue("@UserID", Security.CurrentUser.Info.UserID);
            cm.Parameters.AddWithValue("@NgayHeThong", DateTime.Now);
            cm.Parameters.AddWithValue("@MaCacQuy", _maCacQuy);
            cm.Parameters["@MaCacQuy"].Direction = ParameterDirection.Output;
        }
        #endregion //Data Access - Insert

        #region Data Access - Update
        internal void Update(SqlTransaction tr, LoaiQuyList parent)
        {
            if (!IsDirty) return;

            if (base.IsDirty)
            {
                ExecuteUpdate(tr, parent);
                MarkOld();
            }

            //update child object(s)
            UpdateChildren(tr);
        }

        private void ExecuteUpdate(SqlTransaction tr, LoaiQuyList parent)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_UpdatetblLoaiQuy";

                AddUpdateParameters(cm, parent);

                cm.ExecuteNonQuery();

            }//using
        }

        private void AddUpdateParameters(SqlCommand cm, LoaiQuyList parent)
        {
            cm.Parameters.AddWithValue("@MaCacQuy", _maCacQuy);
            if (_tenCacQuy.Length > 0)
                cm.Parameters.AddWithValue("@TenCacQuy", _tenCacQuy);
            else
                cm.Parameters.AddWithValue("@TenCacQuy", DBNull.Value);
            cm.Parameters.AddWithValue("@MaCacQuyQL", _maCacQuyQL);
            cm.Parameters.AddWithValue("@NgayLap", _ngayLap);
            cm.Parameters.AddWithValue("@UserID", Security.CurrentUser.Info.UserID);
            cm.Parameters.AddWithValue("@NgayHeThong", DateTime.Now);
        }

        private void UpdateChildren(SqlTransaction tr)
        {
        }
        #endregion //Data Access - Update

        #region Data Access - Delete
        internal void DeleteSelf(SqlTransaction tr)
        {
            if (!IsDirty) return;
            if (IsNew) return;

            ExecuteDelete(tr, new Criteria(_maCacQuy));
            MarkNew();
        }
        #endregion //Data Access - Delete
        #endregion //Data Access
    }
}
