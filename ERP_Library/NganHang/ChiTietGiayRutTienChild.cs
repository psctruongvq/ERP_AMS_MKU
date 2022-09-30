
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{
    [Serializable()]
    public class ChiTietGiayRutTien : Csla.BusinessBase<ChiTietGiayRutTien>
    {
        #region Business Properties and Methods

        //declare members
        private long _maChiTiet = 0;
        private long _maGiayRutTien = 0;
        private string _noiDung = string.Empty;
        private decimal _soTien = 0;

        [System.ComponentModel.DataObjectField(true, true)]
        public long MaChiTiet
        {
            get
            {
                CanReadProperty("MaChiTiet", true);
                return _maChiTiet;
            }
        }

        public long MaGiayRutTien
        {
            get
            {
                CanReadProperty("MaGiayRutTien", true);
                return _maGiayRutTien;
            }
            set
            {
                CanWriteProperty("MaGiayRutTien", true);
                if (!_maGiayRutTien.Equals(value))
                {
                    _maGiayRutTien = value;
                    PropertyHasChanged("MaGiayRutTien");
                }
            }
        }

        public string NoiDung
        {
            get
            {
                CanReadProperty("NoiDung", true);
                return _noiDung;
            }
            set
            {
                CanWriteProperty("NoiDung", true);
                if (value == null) value = string.Empty;
                if (!_noiDung.Equals(value))
                {
                    _noiDung = value;
                    PropertyHasChanged("NoiDung");
                }
            }
        }

        public decimal SoTien
        {
            get
            {
                CanReadProperty("SoTien", true);
                return _soTien;
            }
            set
            {
                CanWriteProperty("SoTien", true);
                if (!_soTien.Equals(value))
                {
                    _soTien = value;
                    PropertyHasChanged("SoTien");
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
            //
            // NoiDung
            //
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("NoiDung", 500));
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
            //TODO: Define authorization rules in ChiTietGiayRutTien
            //AuthorizationRules.AllowRead("MaChiTiet", "ChiTietGiayRutTienReadGroup");
            //AuthorizationRules.AllowRead("MaGiayRutTien", "ChiTietGiayRutTienReadGroup");
            //AuthorizationRules.AllowRead("NoiDung", "ChiTietGiayRutTienReadGroup");
            //AuthorizationRules.AllowRead("SoTien", "ChiTietGiayRutTienReadGroup");

            //AuthorizationRules.AllowWrite("MaGiayRutTien", "ChiTietGiayRutTienWriteGroup");
            //AuthorizationRules.AllowWrite("NoiDung", "ChiTietGiayRutTienWriteGroup");
            //AuthorizationRules.AllowWrite("SoTien", "ChiTietGiayRutTienWriteGroup");
        }

        #endregion //Authorization Rules

        #region Factory Methods
        internal static ChiTietGiayRutTien NewChiTietGiayRutTien()
        {
            return new ChiTietGiayRutTien();
        }

        internal static ChiTietGiayRutTien GetChiTietGiayRutTien(SafeDataReader dr)
        {
            return new ChiTietGiayRutTien(dr);
        }

        private ChiTietGiayRutTien()
        {

            ValidationRules.CheckRules();
            MarkAsChild();
        }

        private ChiTietGiayRutTien(SafeDataReader dr)
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
            _maGiayRutTien = dr.GetInt64("MaGiayRutTien");
            _noiDung = dr.GetString("NoiDung");
            _soTien = dr.GetDecimal("SoTien");
        }

        private void FetchChildren(SafeDataReader dr)
        {
        }
        #endregion //Data Access - Fetch

        #region Data Access - Insert
        internal void Insert(SqlTransaction tr, GiayRutTien parent)
        {
            if (!IsDirty) return;

            ExecuteInsert(tr, parent);
            MarkOld();

            //update child object(s)
            UpdateChildren(tr);
        }

        private void ExecuteInsert(SqlTransaction tr, GiayRutTien parent)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_InserttblCT_GiayRutTien";

                AddInsertParameters(cm, parent);

                cm.ExecuteNonQuery();

                _maChiTiet = (long)cm.Parameters["@MaChiTiet"].Value;
            }//using
        }

        private void AddInsertParameters(SqlCommand cm, GiayRutTien parent)
        {
            //TODO: if parent use identity key, fix fk member with value from parent
            if (parent.MaGiayRutTien != 0)
                cm.Parameters.AddWithValue("@MaGiayRutTien", parent.MaGiayRutTien);
            else
                cm.Parameters.AddWithValue("@MaGiayRutTien", DBNull.Value);
            if (_noiDung.Length > 0)
                cm.Parameters.AddWithValue("@NoiDung", _noiDung);
            else
                cm.Parameters.AddWithValue("@NoiDung", DBNull.Value);
            if (_soTien != 0)
                cm.Parameters.AddWithValue("@SoTien", _soTien);
            else
                cm.Parameters.AddWithValue("@SoTien", DBNull.Value);
            cm.Parameters.AddWithValue("@MaChiTiet", _maChiTiet);
            cm.Parameters["@MaChiTiet"].Direction = ParameterDirection.Output;
        }
        #endregion //Data Access - Insert

        #region Data Access - Update
        internal void Update(SqlTransaction tr, GiayRutTien parent)
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

        private void ExecuteUpdate(SqlTransaction tr, GiayRutTien parent)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_UpdatetblCT_GiayRutTien";

                AddUpdateParameters(cm, parent);

                cm.ExecuteNonQuery();

            }//using
        }

        private void AddUpdateParameters(SqlCommand cm, GiayRutTien parent)
        {
            cm.Parameters.AddWithValue("@MaChiTiet", _maChiTiet);
            if (parent.MaGiayRutTien != 0)
                cm.Parameters.AddWithValue("@MaGiayRutTien", parent.MaGiayRutTien);
            else
                cm.Parameters.AddWithValue("@MaGiayRutTien", DBNull.Value);
            if (_noiDung.Length > 0)
                cm.Parameters.AddWithValue("@NoiDung", _noiDung);
            else
                cm.Parameters.AddWithValue("@NoiDung", DBNull.Value);
            if (_soTien != 0)
                cm.Parameters.AddWithValue("@SoTien", _soTien);
            else
                cm.Parameters.AddWithValue("@SoTien", DBNull.Value);
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
                cm.CommandText = "spd_DeletetblCT_GiayRutTien";

                cm.Parameters.AddWithValue("@MaChiTiet", this._maChiTiet);

                cm.ExecuteNonQuery();
            }//using
        }
        #endregion //Data Access - Delete
        #endregion //Data Access
    }
}
