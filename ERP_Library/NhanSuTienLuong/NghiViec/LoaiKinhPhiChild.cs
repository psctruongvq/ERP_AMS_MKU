
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{
    [Serializable()]
    public class LoaiKinhPhiChild : Csla.BusinessBase<LoaiKinhPhiChild>
    {
        #region Business Properties and Methods

        //declare members
        private int _maKinhPhi = 0;
        private string _tenKinhPhi = string.Empty;
        private string _ghiChu = string.Empty;

        [System.ComponentModel.DataObjectField(true, true)]
        public int MaKinhPhi
        {
            get
            {
                CanReadProperty("MaKinhPhi", true);
                return _maKinhPhi;
            }
        }

        public string TenKinhPhi
        {
            get
            {
                CanReadProperty("TenKinhPhi", true);
                return _tenKinhPhi;
            }
            set
            {
                CanWriteProperty("TenKinhPhi", true);
                if (value == null) value = string.Empty;
                if (!_tenKinhPhi.Equals(value))
                {
                    _tenKinhPhi = value;
                    PropertyHasChanged("TenKinhPhi");
                }
            }
        }

        public string GhiChu
        {
            get
            {
                CanReadProperty("GhiChu", true);
                return _ghiChu;
            }
            set
            {
                CanWriteProperty("GhiChu", true);
                if (value == null) value = string.Empty;
                if (!_ghiChu.Equals(value))
                {
                    _ghiChu = value;
                    PropertyHasChanged("GhiChu");
                }
            }
        }

        protected override object GetIdValue()
        {
            return _maKinhPhi;
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
            // TenKinhPhi
            //
            ValidationRules.AddRule(CommonRules.StringRequired, "TenKinhPhi");
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("TenKinhPhi", 200));
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
            //TODO: Define authorization rules in LoaiKinhPhiChild
            //AuthorizationRules.AllowRead("MaKinhPhi", "LoaiKinhPhiChildReadGroup");
            //AuthorizationRules.AllowRead("TenKinhPhi", "LoaiKinhPhiChildReadGroup");
            //AuthorizationRules.AllowRead("GhiChu", "LoaiKinhPhiChildReadGroup");

            //AuthorizationRules.AllowWrite("TenKinhPhi", "LoaiKinhPhiChildWriteGroup");
            //AuthorizationRules.AllowWrite("GhiChu", "LoaiKinhPhiChildWriteGroup");
        }

        #endregion //Authorization Rules

        #region Factory Methods
        internal static LoaiKinhPhiChild NewLoaiKinhPhiChild()
        {
            return new LoaiKinhPhiChild();
        }

        internal static LoaiKinhPhiChild GetLoaiKinhPhiChild(SafeDataReader dr)
        {
            return new LoaiKinhPhiChild(dr);
        }

        private LoaiKinhPhiChild()
        {

            ValidationRules.CheckRules();
            MarkAsChild();
        }

        private LoaiKinhPhiChild(SafeDataReader dr)
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
            _maKinhPhi = dr.GetInt32("MaKinhPhi");
            _tenKinhPhi = dr.GetString("TenKinhPhi");
            _ghiChu = dr.GetString("GhiChu");
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
                cm.CommandText = "sp_AddLoaiKinhPhiChild";

                AddInsertParameters(cm);

                cm.ExecuteNonQuery();

                _maKinhPhi = (int)cm.Parameters["@NewMaKinhPhi"].Value;
            }//using
        }

        private void AddInsertParameters(SqlCommand cm)
        {
            cm.Parameters.AddWithValue("@TenKinhPhi", _tenKinhPhi);
            if (_ghiChu.Length > 0)
                cm.Parameters.AddWithValue("@GhiChu", _ghiChu);
            else
                cm.Parameters.AddWithValue("@GhiChu", DBNull.Value);
            cm.Parameters.AddWithValue("@NewMaKinhPhi", _maKinhPhi);
            cm.Parameters["@NewMaKinhPhi"].Direction = ParameterDirection.Output;
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
                cm.CommandText = "sp_UpdateLoaiKinhPhiChild";

                AddUpdateParameters(cm);

                cm.ExecuteNonQuery();

            }//using
        }

        private void AddUpdateParameters(SqlCommand cm)
        {
            cm.Parameters.AddWithValue("@MaKinhPhi", _maKinhPhi);
            cm.Parameters.AddWithValue("@TenKinhPhi", _tenKinhPhi);
            if (_ghiChu.Length > 0)
                cm.Parameters.AddWithValue("@GhiChu", _ghiChu);
            else
                cm.Parameters.AddWithValue("@GhiChu", DBNull.Value);
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
                cm.CommandText = "sp_DeleteLoaiKinhPhiChild";

                cm.Parameters.AddWithValue("@MaKinhPhi", this._maKinhPhi);

                cm.ExecuteNonQuery();
            }//using
        }
        #endregion //Data Access - Delete
        #endregion //Data Access
    }
}
