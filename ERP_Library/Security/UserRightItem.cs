
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library.Security
{
    [Serializable()]
    public class UserRightItem : Csla.BusinessBase<UserRightItem>
    {
        #region Business Properties and Methods

        //declare members
        private int _menuID = 0;
        private string _tenChucNang = string.Empty;
        private bool _suDung = false;
        private int _parentID = 0;

        [System.ComponentModel.DataObjectField(true, false)]
        public int MenuID
        {
            get
            {
                return _menuID;
            }
        }

        public string TenChucNang
        {
            get
            {
                return _tenChucNang;
            }
        }

        public int ParentID
        {
            get
            {
                return _parentID;
            }
        }

        public bool SuDung
        {
            get
            {
                return _suDung;
            }
            set
            {
                if (!_suDung.Equals(value))
                {
                    _suDung = value;
                    PropertyHasChanged("SuDung");
                }
            }
        }

        protected override object GetIdValue()
        {
            return _menuID;
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
            // TenChucNang
            //
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("TenChucNang", 100));
        }

        protected override void AddBusinessRules()
        {
            AddCommonRules();
            AddCustomRules();
        }
        #endregion //Validation Rules

        #region Factory Methods
        internal static UserRightItem NewUserRightItem(int menuID)
        {
            return new UserRightItem(menuID);
        }

        internal static UserRightItem GetUserRightItem(SafeDataReader dr)
        {
            return new UserRightItem(dr);
        }

        private UserRightItem(int menuID)
        {
            this._menuID = menuID;
            ValidationRules.CheckRules();
            MarkAsChild();
        }

        private UserRightItem(SafeDataReader dr)
        {
            MarkAsChild();
            Fetch(dr);
        }
        #endregion //Factory Methods


        #region Data Access

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
            _menuID = dr.GetInt32("MenuID");
            _tenChucNang = dr.GetString("TenChucNang");
            _parentID = dr.GetInt32("ParentID");
            _suDung = dr.GetBoolean("SuDung");
        }

        private void FetchChildren(SafeDataReader dr)
        {
        }
        #endregion //Data Access - Fetch

        #region Data Access - Insert
        internal void Insert(SqlTransaction tr)
        {
            //if (!IsDirty) return;

            //ExecuteInsert(tr);
            //MarkOld();

            ////update child object(s)
            //UpdateChildren(tr);
        }

        private void ExecuteInsert(SqlTransaction tr)
        {
            //using (SqlCommand cm = tr.Connection.CreateCommand())
            //{
            //    cm.Transaction = tr;
            //    cm.CommandType = CommandType.StoredProcedure;
            //    cm.CommandText = "sp_Insert_UserRightItem";

            //    AddInsertParameters(cm);

            //    cm.ExecuteNonQuery();

            //}//using
        }

        private void AddInsertParameters(SqlCommand cm)
        {
            //if (_menuID != 0)
            //    cm.Parameters.AddWithValue("@MenuID", _menuID);
            //else
            //    cm.Parameters.AddWithValue("@MenuID", DBNull.Value);
            //if (_tenChucNang.Length > 0)
            //    cm.Parameters.AddWithValue("@TenChucNang", _tenChucNang);
            //else
            //    cm.Parameters.AddWithValue("@TenChucNang", DBNull.Value);
            //if (_suDung != false)
            //    cm.Parameters.AddWithValue("@SuDung", _suDung);
            //else
            //    cm.Parameters.AddWithValue("@SuDung", DBNull.Value);
        }
        #endregion //Data Access - Insert

        #region Data Access - Update
        internal void Update(SqlTransaction tr)
        {
            if (!IsDirty) return;

            if (base.IsDirty)
            {
                ExecuteUpdate(tr);
                MarkOld();
            }

            //update child object(s)
            UpdateChildren(tr);
        }

        private void ExecuteUpdate(SqlTransaction tr)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "app_Update_UserRights";

                AddUpdateParameters(cm);

                cm.ExecuteNonQuery();

            }//using
        }

        private void AddUpdateParameters(SqlCommand cm)
        {
            cm.Parameters.AddWithValue("@GroupID", ((UserRightList)Parent).GroupID);
            cm.Parameters.AddWithValue("@MenuID", _menuID);
            cm.Parameters.AddWithValue("@SuDung", _suDung);           
        }

        private void UpdateChildren(SqlTransaction tr)
        {
        }
        #endregion //Data Access - Update

        #region Data Access - Delete
        internal void DeleteSelf(SqlTransaction tr)
        {
            //if (!IsDirty) return;
            //if (IsNew) return;

            //ExecuteDelete(tr);
            //MarkNew();
        }

        private void ExecuteDelete(SqlTransaction tr)
        {
            //using (SqlCommand cm = tr.Connection.CreateCommand())
            //{
            //    cm.Transaction = tr;
            //    cm.CommandType = CommandType.StoredProcedure;
            //    cm.CommandText = "sp_Delete_UserRightItem";

            //    cm.Parameters.AddWithValue("@MenuID", this._menuID);

            //    cm.ExecuteNonQuery();
            //}//using
        }
        #endregion //Data Access - Delete
        #endregion //Data Access
    }
}
