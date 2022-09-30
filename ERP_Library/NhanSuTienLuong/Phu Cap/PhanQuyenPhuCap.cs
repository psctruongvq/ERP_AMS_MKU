
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{
    [Serializable()]
    public class PhanQuyenPhuCap : Csla.BusinessBase<PhanQuyenPhuCap>
    {
        #region Business Properties and Methods

        //declare members
        private int _userID = 0;
        private int _maNhomPhuCap = 0;
        private bool _chon = false;
        private string _tenNhomPhuCap = "";

        [System.ComponentModel.DataObjectField(true, false)]
        public int UserID
        {
            get
            {
                return _userID;
            }
        }

        [System.ComponentModel.DataObjectField(true, false)]
        public int MaNhomPhuCap
        {
            get
            {
                return _maNhomPhuCap;
            }
        }

        public string TenNhomPhuCap
        {
            get
            {
                return _tenNhomPhuCap;
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
                    PropertyHasChanged("Chon");
                }
            }
        }

        protected override object GetIdValue()
        {
            return _userID;
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
        internal static PhanQuyenPhuCap NewPhanQuyenPhuCap(int userID, int maLoaiPhuCap)
        {
            return new PhanQuyenPhuCap(userID, maLoaiPhuCap);
        }

        internal static PhanQuyenPhuCap GetPhanQuyenPhuCap(SafeDataReader dr)
        {
            return new PhanQuyenPhuCap(dr);
        }

        private PhanQuyenPhuCap(int userID, int maLoaiPhuCap)
        {
            this._userID = userID;
            this._maNhomPhuCap = maLoaiPhuCap;
            ValidationRules.CheckRules();
            MarkAsChild();
        }

        private PhanQuyenPhuCap(SafeDataReader dr)
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
            _maNhomPhuCap = dr.GetInt32("MaNhom");
            _chon = dr.GetBoolean("Chon");
            _tenNhomPhuCap = dr.GetString("Ten");
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
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_Update_PhanQuyenPhuCap";

                AddInsertParameters(cm);

                cm.ExecuteNonQuery();

            }//using
        }

        private void AddInsertParameters(SqlCommand cm)
        {
            cm.Parameters.AddWithValue("@UserID", _userID);
            cm.Parameters.AddWithValue("@MaNhomPhuCap", _maNhomPhuCap);
            cm.Parameters.AddWithValue("@Chon", _chon);
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
                cm.CommandText = "spd_Update_PhanQuyenPhuCap";

                AddUpdateParameters(cm);

                cm.ExecuteNonQuery();

            }//using
        }

        private void AddUpdateParameters(SqlCommand cm)
        {
            cm.Parameters.AddWithValue("@UserID", _userID);
            cm.Parameters.AddWithValue("@MaNhomPhuCap", _maNhomPhuCap);
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
                cm.CommandText = "spd_Delete_PhanQuyenPhuCap";

                cm.Parameters.AddWithValue("@UserID", this._userID);
                cm.Parameters.AddWithValue("@MaNhomPhuCap", this._maNhomPhuCap);

                cm.ExecuteNonQuery();
            }//using
        }
        #endregion //Data Access - Delete
        #endregion //Data Access
    }
}
