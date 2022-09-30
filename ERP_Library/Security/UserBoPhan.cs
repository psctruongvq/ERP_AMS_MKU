
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library.Security
{
    [Serializable()]
    public class UserBoPhan : Csla.BusinessBase<UserBoPhan>
    {
        #region Business Properties and Methods

        //declare members
        private int _userID = 0;
        private int _maBoPhan = 0;
        private string _maBoPhanQL = string.Empty;
        private string _tenBoPhan = "";
        private bool _suDung = false;
        private bool _nhapThuLao = false;
        private int _maBoPhanCha = 0;

        public int UserID
        {
            get
            {
                return _userID;
            }
        }

        [System.ComponentModel.DataObjectField(true, false)]
        public int MaBoPhan
        {
            get
            {
                return _maBoPhan;
            }
        }

        public string MaBoPhanQL
        {
            get
            {
                return _maBoPhanQL;
            }
        }

        public string TenBoPhan
        {
            get
            {
                return _tenBoPhan;
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

        public bool NhapThuLao
        {
            get
            {
                return _nhapThuLao;
            }
            set
            {
                if (!_nhapThuLao.Equals(value))
                {
                    _nhapThuLao = value;
                    PropertyHasChanged();
                }
            }
        }

        public int MaBoPhanCha
        {
            get
            {
                return _maBoPhanCha;
            }
        }

        protected override object GetIdValue()
        {
            return _maBoPhan;
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
        internal static UserBoPhan NewUserBoPhan(int maBoPhan)
        {
            return new UserBoPhan(maBoPhan);
        }

        internal static UserBoPhan GetUserBoPhan(SafeDataReader dr)
        {
            return new UserBoPhan(dr);
        }

        private UserBoPhan(int maBoPhan)
        {
            this._maBoPhan = maBoPhan;
            ValidationRules.CheckRules();
            MarkAsChild();
        }

        private UserBoPhan(SafeDataReader dr)
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
            _maBoPhan = dr.GetInt32("MaBoPhan");
            _maBoPhanQL = dr.GetString("MaBoPhanQL");
            _tenBoPhan = dr.GetString("TenBoPhan");
            _suDung = dr.GetBoolean("SuDung");
            _nhapThuLao = dr.GetBoolean("NhapThuLao");
            _maBoPhanCha = dr.GetInt32("MaBoPhanCha");
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
                cm.CommandText = "app_Update_UserBoPhan";

                AddUpdateParameters(cm);

                cm.ExecuteNonQuery();

            }//using
        }

        private void AddUpdateParameters(SqlCommand cm)
        {
            cm.Parameters.AddWithValue("@UserID", _userID);
            cm.Parameters.AddWithValue("@MaBoPhan", _maBoPhan);
            cm.Parameters.AddWithValue("@SuDung", _suDung);
            cm.Parameters.AddWithValue("@NhapThuLao", _nhapThuLao);
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
