using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{
    [Serializable()]
    public class CT_ChungTuBienLaiChild : Csla.BusinessBase<CT_ChungTuBienLaiChild>
    {
        #region Business Properties and Methods

        //declare members
        private long _maChiTiet = 0;
        private long _maChungTu = 0;
        private Guid _oidMaBienLai = Guid.Empty;
        private Guid _oidChiTietBienLai = Guid.Empty;
        private int _iDBienLai = 0;
        private long _iDChiTietBienLai = 0;

        [System.ComponentModel.DataObjectField(true, true)]
        public long MaChiTiet
        {
            get
            {
                CanReadProperty("MaChiTiet", true);
                return _maChiTiet;
            }
        }

        public long MaChungTu
        {
            get
            {
                CanReadProperty("MaChungTu", true);
                return _maChungTu;
            }
            set
            {
                CanWriteProperty("MaChungTu", true);
                if (!_maChungTu.Equals(value))
                {
                    _maChungTu = value;
                    PropertyHasChanged("MaChungTu");
                }
            }
        }

        public Guid OidMaBienLai
        {
            get
            {
                CanReadProperty("OidMaBienLai", true);
                return _oidMaBienLai;
            }
            set
            {
                CanWriteProperty("OidMaBienLai", true);
                if (!_oidMaBienLai.Equals(value))
                {
                    _oidMaBienLai = value;
                    PropertyHasChanged("OidMaBienLai");
                }
            }
        }

        public Guid OidChiTietBienLai
        {
            get
            {
                CanReadProperty("OidChiTietBienLai", true);
                return _oidChiTietBienLai;
            }
            set
            {
                CanWriteProperty("OidChiTietBienLai", true);
                if (!_oidChiTietBienLai.Equals(value))
                {
                    _oidChiTietBienLai = value;
                    PropertyHasChanged("OidChiTietBienLai");
                }
            }
        }

        public int IDBienLai
        {
            get
            {
                CanReadProperty("IDBienLai", true);
                return _iDBienLai;
            }
            set
            {
                CanWriteProperty("IDBienLai", true);
                if (!_iDBienLai.Equals(value))
                {
                    _iDBienLai = value;
                    PropertyHasChanged("IDBienLai");
                }
            }
        }

        public long IDChiTietBienLai
        {
            get
            {
                CanReadProperty("IDChiTietBienLai", true);
                return _iDChiTietBienLai;
            }
            set
            {
                CanWriteProperty("IDChiTietBienLai", true);
                if (!_iDChiTietBienLai.Equals(value))
                {
                    _iDChiTietBienLai = value;
                    PropertyHasChanged("IDChiTietBienLai");
                }
            }
        }

        protected override object GetIdValue()
        {
            return _maChiTiet;
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
            //TODO: Define authorization rules in CT_ChungTuBienLaiChild
            //AuthorizationRules.AllowRead("MaChiTiet", "CT_ChungTuBienLaiChildReadGroup");
            //AuthorizationRules.AllowRead("MaChungTu", "CT_ChungTuBienLaiChildReadGroup");
            //AuthorizationRules.AllowRead("OidMaBienLai", "CT_ChungTuBienLaiChildReadGroup");
            //AuthorizationRules.AllowRead("OidChiTietBienLai", "CT_ChungTuBienLaiChildReadGroup");
            //AuthorizationRules.AllowRead("IDBienLai", "CT_ChungTuBienLaiChildReadGroup");
            //AuthorizationRules.AllowRead("IDChiTietBienLai", "CT_ChungTuBienLaiChildReadGroup");

            //AuthorizationRules.AllowWrite("MaChungTu", "CT_ChungTuBienLaiChildWriteGroup");
            //AuthorizationRules.AllowWrite("OidMaBienLai", "CT_ChungTuBienLaiChildWriteGroup");
            //AuthorizationRules.AllowWrite("OidChiTietBienLai", "CT_ChungTuBienLaiChildWriteGroup");
            //AuthorizationRules.AllowWrite("IDBienLai", "CT_ChungTuBienLaiChildWriteGroup");
            //AuthorizationRules.AllowWrite("IDChiTietBienLai", "CT_ChungTuBienLaiChildWriteGroup");
        }

        #endregion //Authorization Rules

        #region Factory Methods
        public static CT_ChungTuBienLaiChild NewCT_ChungTuBienLaiChild()
        {
            return new CT_ChungTuBienLaiChild();
        }

        internal static CT_ChungTuBienLaiChild GetCT_ChungTuBienLaiChild(SafeDataReader dr)
        {
            return new CT_ChungTuBienLaiChild(dr);
        }

        private CT_ChungTuBienLaiChild()
        {

            ValidationRules.CheckRules();
            MarkAsChild();
        }

        private CT_ChungTuBienLaiChild(SafeDataReader dr)
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
            _maChiTiet = dr.GetInt64("MaChiTiet");
            _maChungTu = dr.GetInt64("MaChungTu");
            _oidMaBienLai = dr.GetGuid("OidMaBienLai");
            _oidChiTietBienLai = dr.GetGuid("OidChiTietBienLai");
            _iDBienLai = dr.GetInt32("IDBienLai");
            _iDChiTietBienLai = dr.GetInt64("IDChiTietBienLai");
        }

        private void FetchChildren(SafeDataReader dr)
        {
        }
        #endregion //Data Access - Fetch

        #region Data Access - Insert
        internal void Insert(SqlTransaction tr, ChungTu parent)
        {
            if (!IsDirty) return;

            ExecuteInsert(tr, parent);
            MarkOld();

            //update child object(s)
            UpdateChildren(tr);
        }

        private void ExecuteInsert(SqlTransaction tr, ChungTu parent)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_InserttblCT_ChungTuBienLai";

                AddInsertParameters(cm, parent);

                cm.ExecuteNonQuery();

                _maChiTiet = (long)cm.Parameters["@MaChiTiet"].Value;
            }//using
        }

        private void AddInsertParameters(SqlCommand cm, ChungTu parent)
        {
            _maChungTu = parent.MaChungTu;
            //TODO: if parent use identity key, fix fk member with value from parent
            if (_maChungTu != 0)
                cm.Parameters.AddWithValue("@MaChungTu", _maChungTu);
            else
                cm.Parameters.AddWithValue("@MaChungTu", DBNull.Value);
            if (_oidMaBienLai != Guid.Empty)
                cm.Parameters.AddWithValue("@OidMaBienLai", _oidMaBienLai);
            else
                cm.Parameters.AddWithValue("@OidMaBienLai", DBNull.Value);
            if (_oidChiTietBienLai != Guid.Empty)
                cm.Parameters.AddWithValue("@OidChiTietBienLai", _oidChiTietBienLai);
            else
                cm.Parameters.AddWithValue("@OidChiTietBienLai", DBNull.Value);
            if (_iDBienLai != 0)
                cm.Parameters.AddWithValue("@IDBienLai", _iDBienLai);
            else
                cm.Parameters.AddWithValue("@IDBienLai", DBNull.Value);
            if (_iDChiTietBienLai != 0)
                cm.Parameters.AddWithValue("@IDChiTietBienLai", _iDChiTietBienLai);
            else
                cm.Parameters.AddWithValue("@IDChiTietBienLai", DBNull.Value);
            cm.Parameters.AddWithValue("@MaChiTiet", _maChiTiet);
            cm.Parameters["@MaChiTiet"].Direction = ParameterDirection.Output;
        }
        #endregion //Data Access - Insert

        #region Data Access - Update
        internal void Update(SqlTransaction tr, ChungTu parent)
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

        private void ExecuteUpdate(SqlTransaction tr, ChungTu parent)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_UpdatetblCT_ChungTuBienLai";

                AddUpdateParameters(cm, parent);

                cm.ExecuteNonQuery();

            }//using
        }

        private void AddUpdateParameters(SqlCommand cm, ChungTu parent)
        {
            _maChungTu = parent.MaChungTu;
            cm.Parameters.AddWithValue("@MaChiTiet", _maChiTiet);
            if (_maChungTu != 0)
                cm.Parameters.AddWithValue("@MaChungTu", _maChungTu);
            else
                cm.Parameters.AddWithValue("@MaChungTu", DBNull.Value);
            if (_oidMaBienLai != Guid.Empty)
                cm.Parameters.AddWithValue("@OidMaBienLai", _oidMaBienLai);
            else
                cm.Parameters.AddWithValue("@OidMaBienLai", DBNull.Value);
            if (_oidChiTietBienLai != Guid.Empty)
                cm.Parameters.AddWithValue("@OidChiTietBienLai", _oidChiTietBienLai);
            else
                cm.Parameters.AddWithValue("@OidChiTietBienLai", DBNull.Value);
            if (_iDBienLai != 0)
                cm.Parameters.AddWithValue("@IDBienLai", _iDBienLai);
            else
                cm.Parameters.AddWithValue("@IDBienLai", DBNull.Value);
            if (_iDChiTietBienLai != 0)
                cm.Parameters.AddWithValue("@IDChiTietBienLai", _iDChiTietBienLai);
            else
                cm.Parameters.AddWithValue("@IDChiTietBienLai", DBNull.Value);
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
                cm.CommandText = "spd_DeletetblCT_ChungTuBienLai";

                cm.Parameters.AddWithValue("@MaChiTiet", this._maChiTiet);

                cm.ExecuteNonQuery();
            }//using
        }
        #endregion //Data Access - Delete
        #endregion //Data Access
    }
}
