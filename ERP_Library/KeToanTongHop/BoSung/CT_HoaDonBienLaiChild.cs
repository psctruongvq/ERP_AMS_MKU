using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{
    [Serializable()]
    public class CT_HoaDonBienLaiChild : Csla.BusinessBase<CT_HoaDonBienLaiChild>
    {
        #region Business Properties and Methods

        //declare members
        private long _maChiTiet = 0;
        private long _maHoaDon = 0;
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

        public long MaHoaDon
        {
            get
            {
                CanReadProperty("MaHoaDon", true);
                return _maHoaDon;
            }
            set
            {
                CanWriteProperty("MaHoaDon", true);
                if (!_maHoaDon.Equals(value))
                {
                    _maHoaDon = value;
                    PropertyHasChanged("MaHoaDon");
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
            //TODO: Define authorization rules in CT_HoaDonBienLaiChild
            //AuthorizationRules.AllowRead("MaChiTiet", "CT_HoaDonBienLaiChildReadGroup");
            //AuthorizationRules.AllowRead("MaHoaDon", "CT_HoaDonBienLaiChildReadGroup");
            //AuthorizationRules.AllowRead("OidMaBienLai", "CT_HoaDonBienLaiChildReadGroup");
            //AuthorizationRules.AllowRead("OidChiTietBienLai", "CT_HoaDonBienLaiChildReadGroup");
            //AuthorizationRules.AllowRead("IDBienLai", "CT_HoaDonBienLaiChildReadGroup");
            //AuthorizationRules.AllowRead("IDChiTietBienLai", "CT_HoaDonBienLaiChildReadGroup");

            //AuthorizationRules.AllowWrite("MaHoaDon", "CT_HoaDonBienLaiChildWriteGroup");
            //AuthorizationRules.AllowWrite("OidMaBienLai", "CT_HoaDonBienLaiChildWriteGroup");
            //AuthorizationRules.AllowWrite("OidChiTietBienLai", "CT_HoaDonBienLaiChildWriteGroup");
            //AuthorizationRules.AllowWrite("IDBienLai", "CT_HoaDonBienLaiChildWriteGroup");
            //AuthorizationRules.AllowWrite("IDChiTietBienLai", "CT_HoaDonBienLaiChildWriteGroup");
        }

        #endregion //Authorization Rules

        #region Factory Methods
        public static CT_HoaDonBienLaiChild NewCT_HoaDonBienLaiChild()
        {
            return new CT_HoaDonBienLaiChild();
        }

        internal static CT_HoaDonBienLaiChild GetCT_HoaDonBienLaiChild(SafeDataReader dr)
        {
            return new CT_HoaDonBienLaiChild(dr);
        }

        private CT_HoaDonBienLaiChild()
        {

            ValidationRules.CheckRules();
            MarkAsChild();
        }

        private CT_HoaDonBienLaiChild(SafeDataReader dr)
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
            _maHoaDon = dr.GetInt64("MaHoaDon");
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
        internal void Insert(SqlTransaction tr, HoaDon parent)
        {
            if (!IsDirty) return;

            ExecuteInsert(tr, parent);
            MarkOld();

            //update child object(s)
            UpdateChildren(tr);
        }

        private void ExecuteInsert(SqlTransaction tr, HoaDon parent)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_InserttblCT_HoaDonBienLai";

                AddInsertParameters(cm, parent);

                cm.ExecuteNonQuery();

                _maChiTiet = (long)cm.Parameters["@MaChiTiet"].Value;
            }//using
        }

        private void AddInsertParameters(SqlCommand cm, HoaDon parent)
        {
            _maHoaDon = parent.MaHoaDon;
            //TODO: if parent use identity key, fix fk member with value from parent
            if (_maHoaDon != 0)
                cm.Parameters.AddWithValue("@MaHoaDon", _maHoaDon);
            else
                cm.Parameters.AddWithValue("@MaHoaDon", DBNull.Value);
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
        internal void Update(SqlTransaction tr, HoaDon parent)
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

        private void ExecuteUpdate(SqlTransaction tr, HoaDon parent)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_UpdatetblCT_HoaDonBienLai";

                AddUpdateParameters(cm, parent);

                cm.ExecuteNonQuery();

            }//using
        }

        private void AddUpdateParameters(SqlCommand cm, HoaDon parent)
        {
            _maHoaDon = parent.MaHoaDon;
            cm.Parameters.AddWithValue("@MaChiTiet", _maChiTiet);
            if (_maHoaDon != 0)
                cm.Parameters.AddWithValue("@MaHoaDon", _maHoaDon);
            else
                cm.Parameters.AddWithValue("@MaHoaDon", DBNull.Value);
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
                cm.CommandText = "spd_DeletetblCT_HoaDonBienLai";

                cm.Parameters.AddWithValue("@MaChiTiet", this._maChiTiet);

                cm.ExecuteNonQuery();
            }//using
        }
        #endregion //Data Access - Delete
        #endregion //Data Access
    }
}
