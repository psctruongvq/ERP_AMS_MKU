using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{
    [Serializable()]
    public class TinhChatPhong : Csla.BusinessBase<TinhChatPhong>
    {
        #region Business Properties and Methods

        //declare members
        private int _maTinhChatPhong = 0;
        private string _maTinhChatPhongQL = string.Empty;
        private string _tenTinhChatPhong = string.Empty;
        private int _userID = Security.CurrentUser.Info.UserID;
        private SmartDate _dateEdit = new SmartDate(DateTime.Today);
        private string _dienGiaiText = string.Empty;

        [System.ComponentModel.DataObjectField(true, true)]
        public int MaTinhChatPhong
        {
            get
            {
                CanReadProperty("MaTinhChatPhong", true);
                return _maTinhChatPhong;
            }
        }

        public string MaTinhChatPhongQL
        {
            get
            {
                CanReadProperty("MaTinhChatPhongQL", true);
                return _maTinhChatPhongQL;
            }
            set
            {
                CanWriteProperty("MaTinhChatPhongQL", true);
                if (value == null) value = string.Empty;
                if (!_maTinhChatPhongQL.Equals(value))
                {
                    _maTinhChatPhongQL = value;
                    PropertyHasChanged("MaTinhChatPhongQL");
                }
            }
        }

        public string TenTinhChatPhong
        {
            get
            {
                CanReadProperty("TenTinhChatPhong", true);
                return _tenTinhChatPhong;
            }
            set
            {
                CanWriteProperty("TenTinhChatPhong", true);
                if (value == null) value = string.Empty;
                if (!_tenTinhChatPhong.Equals(value))
                {
                    _tenTinhChatPhong = value;
                    PropertyHasChanged("TenTinhChatPhong");
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

        public DateTime DateEdit
        {
            get
            {
                CanReadProperty("DateEdit", true);
                return _dateEdit.Date;
            }
        }

        public string DateEditString
        {
            get
            {
                CanReadProperty("DateEditString", true);
                return _dateEdit.Text;
            }
            set
            {
                CanWriteProperty("DateEditString", true);
                if (value == null) value = string.Empty;
                if (!_dateEdit.Equals(value))
                {
                    _dateEdit.Text = value;
                    PropertyHasChanged("DateEditString");
                }
            }
        }

        public string DienGiaiText
        {
            get
            {
                CanReadProperty("DienGiaiText", true);
                return _dienGiaiText;
            }
            set
            {
                CanWriteProperty("DienGiaiText", true);
                if (value == null) value = string.Empty;
                if (!_dienGiaiText.Equals(value))
                {
                    _dienGiaiText = value;
                    PropertyHasChanged("DienGiaiText");
                }
            }
        }

        protected override object GetIdValue()
        {
            return _maTinhChatPhong;
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
            // MaTinhChatPhongQL
            //
            ValidationRules.AddRule(CommonRules.StringRequired, "MaTinhChatPhongQL");
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("MaTinhChatPhongQL", 50));
            //
            // TenTinhChatPhong
            //
            ValidationRules.AddRule(CommonRules.StringRequired, "TenTinhChatPhong");
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
            //TODO: Define authorization rules in TinhChatPhong
            //AuthorizationRules.AllowRead("MaTinhChatPhong", "TinhChatPhongReadGroup");
            //AuthorizationRules.AllowRead("MaTinhChatPhongQL", "TinhChatPhongReadGroup");
            //AuthorizationRules.AllowRead("TenTinhChatPhong", "TinhChatPhongReadGroup");
            //AuthorizationRules.AllowRead("UserID", "TinhChatPhongReadGroup");
            //AuthorizationRules.AllowRead("DateEdit", "TinhChatPhongReadGroup");
            //AuthorizationRules.AllowRead("DateEditString", "TinhChatPhongReadGroup");
            //AuthorizationRules.AllowRead("DienGiaiText", "TinhChatPhongReadGroup");

            //AuthorizationRules.AllowWrite("MaTinhChatPhongQL", "TinhChatPhongWriteGroup");
            //AuthorizationRules.AllowWrite("TenTinhChatPhong", "TinhChatPhongWriteGroup");
            //AuthorizationRules.AllowWrite("UserID", "TinhChatPhongWriteGroup");
            //AuthorizationRules.AllowWrite("DateEditString", "TinhChatPhongWriteGroup");
            //AuthorizationRules.AllowWrite("DienGiaiText", "TinhChatPhongWriteGroup");
        }


        public static bool CanGetObject()
        {
            //TODO: Define CanGetObject permission in TinhChatPhong
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("TinhChatPhongViewGroup"))
            //	return true;
            //return false;
        }

        public static bool CanAddObject()
        {
            //TODO: Define CanAddObject permission in TinhChatPhong
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("TinhChatPhongAddGroup"))
            //	return true;
            //return false;
        }

        public static bool CanEditObject()
        {
            //TODO: Define CanEditObject permission in TinhChatPhong
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("TinhChatPhongEditGroup"))
            //	return true;
            //return false;
        }

        public static bool CanDeleteObject()
        {
            //TODO: Define CanDeleteObject permission in TinhChatPhong
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("TinhChatPhongDeleteGroup"))
            //	return true;
            //return false;
        }
        #endregion //Authorization Rules

        #region Factory Methods
        private TinhChatPhong()
        { /* require use of factory method */
            MarkAsChild();
        }

        public static TinhChatPhong NewTinhChatPhong()
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a TinhChatPhong");
            return DataPortal.Create<TinhChatPhong>();
        }

        public static TinhChatPhong GetTinhChatPhong(int maTinhChatPhong)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a TinhChatPhong");
            return DataPortal.Fetch<TinhChatPhong>(new Criteria(maTinhChatPhong));
        }

        public static void DeleteTinhChatPhong(int maTinhChatPhong)
        {
            if (!CanDeleteObject())
                throw new System.Security.SecurityException("User not authorized to remove a TinhChatPhong");
            DataPortal.Delete(new Criteria(maTinhChatPhong));
        }

        public override TinhChatPhong Save()
        {
            if (IsDeleted && !CanDeleteObject())
                throw new System.Security.SecurityException("User not authorized to remove a TinhChatPhong");
            else if (IsNew && !CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a TinhChatPhong");
            else if (!CanEditObject())
                throw new System.Security.SecurityException("User not authorized to update a TinhChatPhong");

            return base.Save();
        }

        #endregion //Factory Methods

        #region Child Factory Methods
        internal static TinhChatPhong NewTinhChatPhongChild()
        {
            TinhChatPhong child = new TinhChatPhong();
            child.ValidationRules.CheckRules();
            child.MarkAsChild();
            return child;
        }

        internal static TinhChatPhong GetTinhChatPhong(SafeDataReader dr)
        {
            TinhChatPhong child = new TinhChatPhong();
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
            public int MaTinhChatPhong;

            public Criteria(int maTinhChatPhong)
            {
                this.MaTinhChatPhong = maTinhChatPhong;
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
                cm.CommandText = "spd_TinhChatPhongList_GetByID";

                cm.Parameters.AddWithValue("@MaTinhChatPhong", criteria.MaTinhChatPhong);

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
            DataPortal_Delete(new Criteria(_maTinhChatPhong));
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
                cm.CommandText = "spd_TinhChatPhong_Delete";

                cm.Parameters.AddWithValue("@MaTinhChatPhong", criteria.MaTinhChatPhong);

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
            //FetchChildren(dr);
        }

        private void FetchObject(SafeDataReader dr)
        {
            _maTinhChatPhong = dr.GetInt32("MaTinhChatPhong");
            _maTinhChatPhongQL = dr.GetString("MaTinhChatPhongQL");
            _tenTinhChatPhong = dr.GetString("TenTinhChatPhong");
            _userID = dr.GetInt32("UserID");
            _dateEdit = dr.GetSmartDate("DateEdit", _dateEdit.EmptyIsMin);
            _dienGiaiText = dr.GetString("DienGiaiText");
        }

        internal void FetchChildren(SafeDataReader dr)
        {
        }
        #endregion //Data Access - Fetch

        #region Data Access - Insert
        internal void Insert(SqlTransaction tr, TinhChatPhongList parent)
        {
            if (!IsDirty) return;

            ExecuteInsert(tr, parent);
            MarkOld();

            //update child object(s)
            UpdateChildren(tr);
        }

        private void ExecuteInsert(SqlTransaction tr, TinhChatPhongList parent)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_TinhChatPhong_Add";

                AddInsertParameters(cm, parent);

                cm.ExecuteNonQuery();

                _maTinhChatPhong = (int)cm.Parameters["@MaTinhChatPhong"].Value;
            }//using
        }

        private void AddInsertParameters(SqlCommand cm, TinhChatPhongList parent)
        {
            //TODO: if parent use identity key, fix fk member with value from parent
            cm.Parameters.AddWithValue("@MaTinhChatPhongQL", _maTinhChatPhongQL);
            cm.Parameters.AddWithValue("@TenTinhChatPhong", _tenTinhChatPhong);
            cm.Parameters.AddWithValue("@UserID", _userID);
            cm.Parameters.AddWithValue("@DateEdit", _dateEdit.DBValue);
            if (_dienGiaiText.Length > 0)
                cm.Parameters.AddWithValue("@DienGiaiText", _dienGiaiText);
            else
                cm.Parameters.AddWithValue("@DienGiaiText", DBNull.Value);
            cm.Parameters.AddWithValue("@MaTinhChatPhong", _maTinhChatPhong);
            cm.Parameters["@MaTinhChatPhong"].Direction = ParameterDirection.Output;
        }
        #endregion //Data Access - Insert

        #region Data Access - Update
        internal void Update(SqlTransaction tr, TinhChatPhongList parent)
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

        private void ExecuteUpdate(SqlTransaction tr, TinhChatPhongList parent)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_TinhChatPhong_Update";

                AddUpdateParameters(cm, parent);

                cm.ExecuteNonQuery();

            }//using
        }

        private void AddUpdateParameters(SqlCommand cm, TinhChatPhongList parent)
        {
            cm.Parameters.AddWithValue("@MaTinhChatPhong", _maTinhChatPhong);
            cm.Parameters.AddWithValue("@MaTinhChatPhongQL", _maTinhChatPhongQL);
            cm.Parameters.AddWithValue("@TenTinhChatPhong", _tenTinhChatPhong);
            cm.Parameters.AddWithValue("@UserID", _userID);
            cm.Parameters.AddWithValue("@DateEdit", _dateEdit.DBValue);
            if (_dienGiaiText.Length > 0)
                cm.Parameters.AddWithValue("@DienGiaiText", _dienGiaiText);
            else
                cm.Parameters.AddWithValue("@DienGiaiText", DBNull.Value);
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

            ExecuteDelete(tr, new Criteria(_maTinhChatPhong));
            MarkNew();
        }
        #endregion //Data Access - Delete
        #endregion //Data Access
    }
}
