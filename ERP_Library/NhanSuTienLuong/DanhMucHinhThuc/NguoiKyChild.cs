
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{
    [Serializable()]
    public class NguoiKyChild : Csla.BusinessBase<NguoiKyChild>
    {
        #region Business Properties and Methods

        //declare members
        private int _maNguoiKy = 0;
        private string _tenNguoiKy = string.Empty;

        [System.ComponentModel.DataObjectField(true, true)]
        public int MaNguoiKy
        {
            get
            {
                CanReadProperty("MaNguoiKy", true);
                return _maNguoiKy;
            }
        }

        public string TenNguoiKy
        {
            get
            {
                CanReadProperty("TenNguoiKy", true);
                return _tenNguoiKy;
            }
            set
            {
                CanWriteProperty("TenNguoiKy", true);
                if (value == null) value = string.Empty;
                if (!_tenNguoiKy.Equals(value))
                {
                    _tenNguoiKy = value;
                    PropertyHasChanged("TenNguoiKy");
                }
            }
        }

        protected override object GetIdValue()
        {
            return _maNguoiKy;
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
            // TenNguoiKy
            //
            ValidationRules.AddRule(CommonRules.StringRequired, "TenNguoiKy");
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("TenNguoiKy", 50));
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
            //TODO: Define authorization rules in NguoiKyChild
            //AuthorizationRules.AllowRead("MaNguoiKy", "NguoiKyChildReadGroup");
            //AuthorizationRules.AllowRead("TenNguoiKy", "NguoiKyChildReadGroup");

            //AuthorizationRules.AllowWrite("TenNguoiKy", "NguoiKyChildWriteGroup");
        }

        #endregion //Authorization Rules

        #region Factory Methods
        internal static NguoiKyChild NewNguoiKyChild()
        {
            return new NguoiKyChild();
        }

        internal static NguoiKyChild GetNguoiKyChild(SafeDataReader dr)
        {
            return new NguoiKyChild(dr);
        }

        private NguoiKyChild()
        {

            ValidationRules.CheckRules();
            MarkAsChild();
        }

        private NguoiKyChild(SafeDataReader dr)
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
            _maNguoiKy = dr.GetInt32("MaNguoiKy");
            _tenNguoiKy = dr.GetString("TenNguoiKy");
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
                cm.CommandText = "spd_Insert_NguoiKyChild";

                AddInsertParameters(cm);

                cm.ExecuteNonQuery();

                _maNguoiKy = (int)cm.Parameters["@MaNguoiKy"].Value;
            }//using
        }

        private void AddInsertParameters(SqlCommand cm)
        {
            cm.Parameters.AddWithValue("@TenNguoiKy", _tenNguoiKy);
            cm.Parameters.AddWithValue("@MaNguoiKy", _maNguoiKy);
            cm.Parameters["@MaNguoiKy"].Direction = ParameterDirection.Output;
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
                cm.CommandText = "spd_Update_NguoiKyChild";

                AddUpdateParameters(cm);

                cm.ExecuteNonQuery();

            }//using
        }

        private void AddUpdateParameters(SqlCommand cm)
        {
            cm.Parameters.AddWithValue("@MaNguoiKy", _maNguoiKy);
            cm.Parameters.AddWithValue("@TenNguoiKy", _tenNguoiKy);
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
                cm.CommandText = "spd_Delete_NguoiKyChild";

                cm.Parameters.AddWithValue("@MaNguoiKy", this._maNguoiKy);

                cm.ExecuteNonQuery();
            }//using
        }
        #endregion //Data Access - Delete
        #endregion //Data Access
    }
}
