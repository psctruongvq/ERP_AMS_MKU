
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library.Security
{
    [Serializable()]
    public class UserThuLaoChild : Csla.BusinessBase<UserThuLaoChild>
    {
        #region Business Properties and Methods

        //declare members
        private int _userID = 0;
        private int _nguoiLap = 0;//lưu id của user là người lập thù lao
        private string _TenNguoiLap = "";//tên của user là người lập thù lao
        private bool _chon = false;

        [System.ComponentModel.DataObjectField(true, false)]
        public int UserID
        {
            get
            {
                return _userID;
            }
        }

        [System.ComponentModel.DataObjectField(true, false)]
        public int NguoiLap
        {
            get
            {
                return _nguoiLap;
            }
        }

        public string TenNguoiLap
        {
            get
            {
                return _TenNguoiLap;
            }
        }

        public bool Chon
        {
            get
            {
                return _chon;
            }
            set
            {
                if (!_chon.Equals(value))
                {
                    _chon = value;
                    PropertyHasChanged();
                }
            }
        }

        protected override object GetIdValue()
        {
            return string.Format("{0}:{1}", _userID, _nguoiLap);
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

        #region Factory Methods
        internal static UserThuLaoChild NewUserThuLaoChild(int userID, int nguoiLap)
        {
            return new UserThuLaoChild(userID, nguoiLap);
        }

        internal static UserThuLaoChild GetUserThuLaoChild(SafeDataReader dr)
        {
            return new UserThuLaoChild(dr);
        }

        private UserThuLaoChild(int userID, int nguoiLap)
        {
            this._userID = userID;
            this._nguoiLap = nguoiLap;
            ValidationRules.CheckRules();
            MarkAsChild();
        }

        private UserThuLaoChild(SafeDataReader dr)
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
            _userID = dr.GetInt32("UserID");
            _nguoiLap = dr.GetInt32("NguoiLap");
            _TenNguoiLap = dr.GetString("TenNguoiLap");
            _chon = dr.GetBoolean("Chon");
        }

        private void FetchChildren(SafeDataReader dr)
        {
        }
        #endregion //Data Access - Fetch

        #region Data Access - Insert
        internal void Insert(SqlTransaction tr, UserItem parent)
        {
            if (!IsDirty) return;

            ExecuteInsert(tr, parent);
            MarkOld();

            //update child object(s)
            UpdateChildren(tr);
        }

        private void ExecuteInsert(SqlTransaction tr, UserItem parent)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_Update_UserThuLaoChild";

                AddInsertParameters(cm, parent);

                cm.ExecuteNonQuery();

            }//using
        }

        private void AddInsertParameters(SqlCommand cm, UserItem parent)
        {
            _userID = parent._userID;
            cm.Parameters.AddWithValue("@UserID", _userID);
            cm.Parameters.AddWithValue("@NguoiLap", _nguoiLap);
        }
        #endregion //Data Access - Insert

        #region Data Access - Update
        internal void Update(SqlTransaction tr, UserItem parent)
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

        private void ExecuteUpdate(SqlTransaction tr, UserItem parent)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_Update_UserThuLaoChild";

                AddUpdateParameters(cm, parent);

                cm.ExecuteNonQuery();

            }//using
        }

        private void AddUpdateParameters(SqlCommand cm, UserItem parent)
        {
            cm.Parameters.AddWithValue("@UserID", _userID);
            cm.Parameters.AddWithValue("@NguoiLap", _nguoiLap);
            cm.Parameters.AddWithValue("@Chon", _chon);
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

            ExecuteDelete(tr);
            MarkNew();
        }

        private void ExecuteDelete(SqlTransaction tr)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_Delete_UserThuLaoChild";

                cm.Parameters.AddWithValue("@UserID", this._userID);
                cm.Parameters.AddWithValue("@NguoiLap", this._nguoiLap);

                cm.ExecuteNonQuery();
            }//using
        }
        #endregion //Data Access - Delete
        #endregion //Data Access
    }
}
