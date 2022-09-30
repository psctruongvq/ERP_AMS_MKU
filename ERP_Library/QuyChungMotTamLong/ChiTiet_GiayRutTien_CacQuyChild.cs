
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{
    [Serializable()]
    public class ChiTiet_GiayRutTien_CacQuy : Csla.BusinessBase<ChiTiet_GiayRutTien_CacQuy>
    {
        #region Business Properties and Methods

        //declare members
        private long _maChiTiet = 0;
        private long _maGiayRutTien = 0;
        private string _noiDung = string.Empty;
        private decimal _soTien = 0;
        private int _loaiTien = 0;
        private decimal _tyGia = 0;

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

        public int LoaiTien
        {
            get
            {
                CanReadProperty("LoaiTien", true);
                return _loaiTien;
            }
            set
            {
                CanWriteProperty("LoaiTien", true);
                if (!_loaiTien.Equals(value))
                {
                    _loaiTien = value;
                    PropertyHasChanged("LoaiTien");
                }
            }
        }

        public decimal TyGia
        {
            get
            {
                CanReadProperty("TyGia", true);
                return _tyGia;
            }
            set
            {
                CanWriteProperty("TyGia", true);
                if (!_tyGia.Equals(value))
                {
                    _tyGia = value;
                    PropertyHasChanged("TyGia");
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
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("NoiDung", 4000));
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
            //TODO: Define authorization rules in ChiTiet_GiayRutTien_CacQuy
            //AuthorizationRules.AllowRead("MaChiTiet", "ChiTiet_GiayRutTien_CacQuyReadGroup");
            //AuthorizationRules.AllowRead("MaGiayRutTien", "ChiTiet_GiayRutTien_CacQuyReadGroup");
            //AuthorizationRules.AllowRead("NoiDung", "ChiTiet_GiayRutTien_CacQuyReadGroup");
            //AuthorizationRules.AllowRead("SoTien", "ChiTiet_GiayRutTien_CacQuyReadGroup");
            //AuthorizationRules.AllowRead("LoaiTien", "ChiTiet_GiayRutTien_CacQuyReadGroup");
            //AuthorizationRules.AllowRead("TyGia", "ChiTiet_GiayRutTien_CacQuyReadGroup");

            //AuthorizationRules.AllowWrite("MaGiayRutTien", "ChiTiet_GiayRutTien_CacQuyWriteGroup");
            //AuthorizationRules.AllowWrite("NoiDung", "ChiTiet_GiayRutTien_CacQuyWriteGroup");
            //AuthorizationRules.AllowWrite("SoTien", "ChiTiet_GiayRutTien_CacQuyWriteGroup");
            //AuthorizationRules.AllowWrite("LoaiTien", "ChiTiet_GiayRutTien_CacQuyWriteGroup");
            //AuthorizationRules.AllowWrite("TyGia", "ChiTiet_GiayRutTien_CacQuyWriteGroup");
        }

        #endregion //Authorization Rules

        #region Factory Methods
        internal static ChiTiet_GiayRutTien_CacQuy NewChiTiet_GiayRutTien_CacQuy()
        {
            return new ChiTiet_GiayRutTien_CacQuy();
        }

        internal static ChiTiet_GiayRutTien_CacQuy GetChiTiet_GiayRutTien_CacQuy(SafeDataReader dr)
        {
            return new ChiTiet_GiayRutTien_CacQuy(dr);
        }

        private ChiTiet_GiayRutTien_CacQuy()
        {

            ValidationRules.CheckRules();
            MarkAsChild();
        }

        private ChiTiet_GiayRutTien_CacQuy(SafeDataReader dr)
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
            _loaiTien = dr.GetInt32("LoaiTien");
            _tyGia = dr.GetDecimal("TyGia");
        }

        private void FetchChildren(SafeDataReader dr)
        {
        }
        #endregion //Data Access - Fetch

        #region Data Access - Insert
        internal void Insert(SqlTransaction tr, GiayRutTien_CacQuy parent)
        {
            if (!IsDirty) return;

            ExecuteInsert(tr, parent);
            MarkOld();

            //update child object(s)
            UpdateChildren(tr);
        }

        private void ExecuteInsert(SqlTransaction tr, GiayRutTien_CacQuy parent)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_InserttblCT_GiayRutTien_CacQuy";

                AddInsertParameters(cm, parent);

                cm.ExecuteNonQuery();

                _maChiTiet = (long)cm.Parameters["@MaChiTiet"].Value;
            }//using
        }

        private void AddInsertParameters(SqlCommand cm, GiayRutTien_CacQuy parent)
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
            if (_loaiTien != 0)
                cm.Parameters.AddWithValue("@LoaiTien", _loaiTien);
            else
                cm.Parameters.AddWithValue("@LoaiTien", DBNull.Value);
            if (_tyGia != 0)
                cm.Parameters.AddWithValue("@TyGia", _tyGia);
            else
                cm.Parameters.AddWithValue("@TyGia", DBNull.Value);
            cm.Parameters.AddWithValue("@MaChiTiet", _maChiTiet);
            cm.Parameters["@MaChiTiet"].Direction = ParameterDirection.Output;
        }
        #endregion //Data Access - Insert

        #region Data Access - Update
        internal void Update(SqlTransaction tr, GiayRutTien_CacQuy parent)
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

        private void ExecuteUpdate(SqlTransaction tr, GiayRutTien_CacQuy parent)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_UpdatetblCT_GiayRutTien_CacQuy";

                AddUpdateParameters(cm, parent);

                cm.ExecuteNonQuery();

            }//using
        }

        private void AddUpdateParameters(SqlCommand cm, GiayRutTien_CacQuy parent)
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
            if (_loaiTien != 0)
                cm.Parameters.AddWithValue("@LoaiTien", _loaiTien);
            else
                cm.Parameters.AddWithValue("@LoaiTien", DBNull.Value);
            if (_tyGia != 0)
                cm.Parameters.AddWithValue("@TyGia", _tyGia);
            else
                cm.Parameters.AddWithValue("@TyGia", DBNull.Value);
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
                cm.CommandText = "spd_DeletetblCT_GiayRutTien_CacQuy";

                cm.Parameters.AddWithValue("@MaChiTiet", this._maChiTiet);

                cm.ExecuteNonQuery();
            }//using
        }
        #endregion //Data Access - Delete
        #endregion //Data Access
    }
}
