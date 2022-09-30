
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library.Security
{
    [Serializable()]
    public class UserPhongBan : Csla.BusinessBase<UserPhongBan>
    {
        #region Business Properties and Methods

        //declare members
        private int _userID = 0;
        private int _maPhongBan = 0;
        private string _maPhongBanQL = string.Empty;
        private string _tenPhongBan = "";
        private bool _suDung = false;

        public int UserID
        {
            get
            {
                return _userID;
            }
        }

        [System.ComponentModel.DataObjectField(true, false)]
        public int MaPhongBan
        {
            get
            {
                return _maPhongBan;
            }
        }

        public string MaPhongBanQL
        {
            get
            {
                return _maPhongBanQL;
            }
        }

        public string TenPhongBan
        {
            get
            {
                return _tenPhongBan;
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
                    PropertyHasChanged("Chon");
                }
            }
        }

        protected override object GetIdValue()
        {
            return _maPhongBan;
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
        internal static UserPhongBan NewUserPhongBan(int maPhongBan)
        {
            return new UserPhongBan(maPhongBan);
        }

        internal static UserPhongBan GetUserPhongBan(SafeDataReader dr)
        {
            return new UserPhongBan(dr);
        }

        private UserPhongBan(int maPhongBan)
        {
            this._maPhongBan = maPhongBan;
            ValidationRules.CheckRules();
            MarkAsChild();
        }

        private UserPhongBan(SafeDataReader dr)
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
            _maPhongBan = dr.GetInt32("MaPhongBan");
            _maPhongBanQL = dr.GetString("MaPhongBanQL");
            _tenPhongBan = dr.GetString("TenPhongBan");
            _suDung = dr.GetBoolean("SuDung");
        }

        private void FetchChildren(SafeDataReader dr)
        {
        }
        #endregion //Data Access - Fetch

        #region Data Access - Insert
        internal void Insert(SqlTransaction tr)
        {
            if (!IsDirty) return;

            ExecuteInsert(tr);
            MarkOld();

            //update child object(s)
            UpdateChildren(tr);
        }

        private void ExecuteInsert(SqlTransaction tr)
        {
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
                cm.CommandText = "app_Update_UserPhongBan";

                AddUpdateParameters(cm);

                cm.ExecuteNonQuery();

            }//using
        }

        private void AddUpdateParameters(SqlCommand cm)
        {
            cm.Parameters.AddWithValue("@UserID", _userID);
            cm.Parameters.AddWithValue("@MaPhongBan", _maPhongBan);
            cm.Parameters.AddWithValue("@SuDung", _suDung);
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
        }
        #endregion //Data Access - Delete
        #endregion //Data Access
    }
}
