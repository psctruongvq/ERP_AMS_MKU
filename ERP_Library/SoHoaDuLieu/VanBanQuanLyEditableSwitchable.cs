using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;
using ERP_Library.Security;

namespace ERP_Library
{
    [Serializable()]
    public class VanBanQuanLy : Csla.BusinessBase<VanBanQuanLy>
    {
        #region Business Properties and Methods

        //declare members
        private long _oid = 0;
        private string _maQuanLy = string.Empty;
        private long? _nhomVanban = null;
        private string _tenVanBan = string.Empty;
        private string _dienGiai = string.Empty;
        private long _boPhan = 0;
        private long _nguoiChinhSua = 0;

        [System.ComponentModel.DataObjectField(true, true)]
        public long Oid
        {
            get
            {
                CanReadProperty("Oid", true);
                return _oid;
            }
        }

        public string MaQuanLy
        {
            get
            {
                CanReadProperty("MaQuanLy", true);
                return _maQuanLy;
            }
            set
            {
                CanWriteProperty("MaQuanLy", true);
                if (value == null) value = string.Empty;
                if (!_maQuanLy.Equals(value))
                {
                    _maQuanLy = value;
                    PropertyHasChanged("MaQuanLy");
                }
            }
        }

        public long? NhomVanban
        {
            get
            {
                CanReadProperty("NhomVanban", true);
                return _nhomVanban;
            }
            set
            {
                CanWriteProperty("NhomVanban", true);
                if (!_nhomVanban.Equals(value))
                {
                    _nhomVanban = value;
                    PropertyHasChanged("NhomVanban");
                }
            }
        }

        public string TenVanBan
        {
            get
            {
                CanReadProperty("TenVanBan", true);
                return _tenVanBan;
            }
            set
            {
                CanWriteProperty("TenVanBan", true);
                if (value == null) value = string.Empty;
                if (!_tenVanBan.Equals(value))
                {
                    _tenVanBan = value;
                    PropertyHasChanged("TenVanBan");
                }
            }
        }

        public string DienGiai
        {
            get
            {
                CanReadProperty("DienGiai", true);
                return _dienGiai;
            }
            set
            {
                CanWriteProperty("DienGiai", true);
                if (value == null) value = string.Empty;
                if (!_dienGiai.Equals(value))
                {
                    _dienGiai = value;
                    PropertyHasChanged("DienGiai");
                }
            }
        }

        public long BoPhan
        {
            get
            {
                CanReadProperty("BoPhan", true);
                return _boPhan;
            }
            set
            {
                CanWriteProperty("BoPhan", true);
                if (!_boPhan.Equals(value))
                {
                    _boPhan = value;
                    PropertyHasChanged("BoPhan");
                }
            }
        }

        public long NguoiChinhSua
        {
            get
            {
                CanReadProperty("NguoiChinhSua", true);
                return _nguoiChinhSua;
            }
            set
            {
                CanWriteProperty("NguoiChinhSua", true);
                if (!_nguoiChinhSua.Equals(value))
                {
                    _nguoiChinhSua = value;
                    PropertyHasChanged("NguoiChinhSua");
                }
            }
        }

        protected override object GetIdValue()
        {
            return _oid;
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
            // MaQuanLy
            //
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("MaQuanLy", 50));
            //
            // TenVanBan
            //
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("TenVanBan", 100));
            //
            // DienGiai
            //
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("DienGiai", 200));
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
            //TODO: Define authorization rules in VanBanQuanLy
            //AuthorizationRules.AllowRead("Oid", "VanBanQuanLyReadGroup");
            //AuthorizationRules.AllowRead("MaQuanLy", "VanBanQuanLyReadGroup");
            //AuthorizationRules.AllowRead("NhomVanban", "VanBanQuanLyReadGroup");
            //AuthorizationRules.AllowRead("TenVanBan", "VanBanQuanLyReadGroup");
            //AuthorizationRules.AllowRead("DienGiai", "VanBanQuanLyReadGroup");
            //AuthorizationRules.AllowRead("BoPhan", "VanBanQuanLyReadGroup");
            //AuthorizationRules.AllowRead("NgayLap", "VanBanQuanLyReadGroup");
            //AuthorizationRules.AllowRead("NgayLapString", "VanBanQuanLyReadGroup");
            //AuthorizationRules.AllowRead("NgayChinhSua", "VanBanQuanLyReadGroup");
            //AuthorizationRules.AllowRead("NgayChinhSuaString", "VanBanQuanLyReadGroup");
            //AuthorizationRules.AllowRead("NguoiChinhSua", "VanBanQuanLyReadGroup");

            //AuthorizationRules.AllowWrite("MaQuanLy", "VanBanQuanLyWriteGroup");
            //AuthorizationRules.AllowWrite("NhomVanban", "VanBanQuanLyWriteGroup");
            //AuthorizationRules.AllowWrite("TenVanBan", "VanBanQuanLyWriteGroup");
            //AuthorizationRules.AllowWrite("DienGiai", "VanBanQuanLyWriteGroup");
            //AuthorizationRules.AllowWrite("BoPhan", "VanBanQuanLyWriteGroup");
            //AuthorizationRules.AllowWrite("NgayLapString", "VanBanQuanLyWriteGroup");
            //AuthorizationRules.AllowWrite("NgayChinhSuaString", "VanBanQuanLyWriteGroup");
            //AuthorizationRules.AllowWrite("NguoiChinhSua", "VanBanQuanLyWriteGroup");
        }


        public static bool CanGetObject()
        {
            //TODO: Define CanGetObject permission in VanBanQuanLy
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("VanBanQuanLyViewGroup"))
            //	return true;
            //return false;
        }

        public static bool CanAddObject()
        {
            //TODO: Define CanAddObject permission in VanBanQuanLy
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("VanBanQuanLyAddGroup"))
            //	return true;
            //return false;
        }

        public static bool CanEditObject()
        {
            //TODO: Define CanEditObject permission in VanBanQuanLy
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("VanBanQuanLyEditGroup"))
            //	return true;
            //return false;
        }

        public static bool CanDeleteObject()
        {
            //TODO: Define CanDeleteObject permission in VanBanQuanLy
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("VanBanQuanLyDeleteGroup"))
            //	return true;
            //return false;
        }
        #endregion //Authorization Rules

        #region Factory Methods
        private VanBanQuanLy()
        { /* require use of factory method */ }

        public static VanBanQuanLy NewVanBanQuanLy()
        {
            VanBanQuanLy item = new VanBanQuanLy();
            item.MarkAsChild();
            return item;
        }

        public static VanBanQuanLy GetVanBanQuanLy(long oid)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a VanBanQuanLy");
            return DataPortal.Fetch<VanBanQuanLy>(new Criteria(oid));
        }

        public static void DeleteVanBanQuanLy(long oid)
        {
            if (!CanDeleteObject())
                throw new System.Security.SecurityException("User not authorized to remove a VanBanQuanLy");
            DataPortal.Delete(new Criteria(oid));
        }

        public override VanBanQuanLy Save()
        {
            if (IsDeleted && !CanDeleteObject())
                throw new System.Security.SecurityException("User not authorized to remove a VanBanQuanLy");
            else if (IsNew && !CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a VanBanQuanLy");
            else if (!CanEditObject())
                throw new System.Security.SecurityException("User not authorized to update a VanBanQuanLy");

            return base.Save();
        }

        #endregion //Factory Methods

        #region Child Factory Methods
        internal static VanBanQuanLy NewVanBanQuanLyChild()
        {
            VanBanQuanLy child = new VanBanQuanLy();
            child.ValidationRules.CheckRules();
            child.MarkAsChild();
            return child;
        }

        internal static VanBanQuanLy GetVanBanQuanLy(SafeDataReader dr)
        {
            VanBanQuanLy child = new VanBanQuanLy();
            child.MarkAsChild();
            child.Fetch(dr);
            return child;
        }
        #endregion //Child Factory Methods

        #region Data Access

        #region Criteria

        [Serializable()]
        private class Criteria
        {
            public long Oid;

            public Criteria(long oid)
            {
                this.Oid = oid;
            }
        }

        #endregion //Criteria

        #region Data Access - Create
        [RunLocal]
        protected override void DataPortal_Create()
        {
            ValidationRules.CheckRules();
        }

        #endregion //Data Access - Create

        #region Data Access - Fetch
        private void DataPortal_Fetch(Criteria criteria)
        {
            SqlTransaction tr;

            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection_Digital))
            {
                cn.Open();

                tr = cn.BeginTransaction();
                try
                {
                    ExecuteFetch(tr, criteria);

                    tr.Commit();
                }
                catch
                {
                    tr.Rollback();
                    throw;
                }
            }//using
        }

        private void ExecuteFetch(SqlTransaction tr, Criteria criteria)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_SelectVanBanQuanLy";

                cm.Parameters.AddWithValue("@Oid", criteria.Oid);

                using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                {
                    dr.Read();
                    FetchObject(dr);
                    ValidationRules.CheckRules();

                    //load child object(s)
                    FetchChildren(dr);
                }
            }//using
        }

        #endregion //Data Access - Fetch

        #region Data Access - Insert
        protected override void DataPortal_Insert()
        {
            SqlTransaction tr;

            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection_Digital))
            {
                cn.Open();

                tr = cn.BeginTransaction();
                try
                {
                    ExecuteInsert(tr, null);

                    //update child object(s)
                    UpdateChildren(tr);

                    tr.Commit();
                }
                catch
                {
                    tr.Rollback();
                    throw;
                }
            }//using

        }

        #endregion //Data Access - Insert

        #region Data Access - Update
        protected override void DataPortal_Update()
        {
            SqlTransaction tr;

            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection_Digital))
            {
                cn.Open();

                tr = cn.BeginTransaction();
                try
                {
                    if (base.IsDirty)
                    {
                        ExecuteUpdate(tr, null);
                    }

                    //update child object(s)
                    UpdateChildren(tr);

                    tr.Commit();
                }
                catch
                {
                    tr.Rollback();
                    throw;
                }
            }//using

        }

        #endregion //Data Access - Update

        #region Data Access - Delete
        protected override void DataPortal_DeleteSelf()
        {
            DataPortal_Delete(new Criteria(_oid));
        }

        private void DataPortal_Delete(Criteria criteria)
        {
            SqlTransaction tr;

            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection_Digital))
            {
                cn.Open();

                tr = cn.BeginTransaction();
                try
                {
                    ExecuteDelete(tr, criteria);

                    tr.Commit();
                }
                catch
                {
                    tr.Rollback();
                    throw;
                }
            }//using

        }

        private void ExecuteDelete(SqlTransaction tr, Criteria criteria)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_DeleteVanBanQuanLy";

                cm.Parameters.AddWithValue("@Oid", criteria.Oid);

                cm.ExecuteNonQuery();
            }//using
        }
        #endregion //Data Access - Delete

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
            _oid = dr.GetInt64("Oid");
            _maQuanLy = dr.GetString("MaQuanLy");
            _nhomVanban = dr.GetInt64("NhomVanban");
            _tenVanBan = dr.GetString("TenVanBan");
            _dienGiai = dr.GetString("DienGiai");
            _boPhan = dr.GetInt64("BoPhan");
            _nguoiChinhSua = dr.GetInt64("NguoiChinhSua");
        }

        private void FetchChildren(SafeDataReader dr)
        {
        }
        #endregion //Data Access - Fetch

        #region Data Access - Insert
        internal void Insert(SqlTransaction tr, VanBanQuanLyList parent)
        {
            if (!IsDirty) return;

            ExecuteInsert(tr, parent);
            MarkOld();

            //update child object(s)
            UpdateChildren(tr);
        }

        private void ExecuteInsert(SqlTransaction tr, VanBanQuanLyList parent)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_InsertVanBanQuanLy";

                AddInsertParameters(cm, parent);

                cm.ExecuteNonQuery();
            }//using
        }

        private void AddInsertParameters(SqlCommand cm, VanBanQuanLyList parent)
        {
            //TODO: if parent use identity key, fix fk member with value from parent
            if (_maQuanLy.Length > 0)
                cm.Parameters.AddWithValue("@MaQuanLy", _maQuanLy);
            else
                cm.Parameters.AddWithValue("@MaQuanLy", DBNull.Value);
            if (_nhomVanban != 0)
                cm.Parameters.AddWithValue("@NhomVanban", _nhomVanban);
            else
                cm.Parameters.AddWithValue("@NhomVanban", DBNull.Value);
            if (_tenVanBan.Length > 0)
                cm.Parameters.AddWithValue("@TenVanBan", _tenVanBan);
            else
                cm.Parameters.AddWithValue("@TenVanBan", DBNull.Value);
            if (_dienGiai.Length > 0)
                cm.Parameters.AddWithValue("@DienGiai", _dienGiai);
            else
                cm.Parameters.AddWithValue("@DienGiai", DBNull.Value);
            cm.Parameters.AddWithValue("@BoPhan", CurrentUser.Info.MaCongTy);
            cm.Parameters.AddWithValue("@NguoiChinhSua", CurrentUser.Info.UserID);
        }
        #endregion //Data Access - Insert

        #region Data Access - Update
        internal void Update(SqlTransaction tr, VanBanQuanLyList parent)
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

        private void ExecuteUpdate(SqlTransaction tr, VanBanQuanLyList parent)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_UpdateVanBanQuanLy";

                AddUpdateParameters(cm, parent);

                cm.ExecuteNonQuery();

            }//using
        }

        private void AddUpdateParameters(SqlCommand cm, VanBanQuanLyList parent)
        {
            cm.Parameters.AddWithValue("@Oid", _oid);
            if (_maQuanLy.Length > 0)
                cm.Parameters.AddWithValue("@MaQuanLy", _maQuanLy);
            else
                cm.Parameters.AddWithValue("@MaQuanLy", DBNull.Value);
            if (_nhomVanban != 0)
                cm.Parameters.AddWithValue("@NhomVanban", _nhomVanban);
            else
                cm.Parameters.AddWithValue("@NhomVanban", DBNull.Value);
            if (_tenVanBan.Length > 0)
                cm.Parameters.AddWithValue("@TenVanBan", _tenVanBan);
            else
                cm.Parameters.AddWithValue("@TenVanBan", DBNull.Value);
            if (_dienGiai.Length > 0)
                cm.Parameters.AddWithValue("@DienGiai", _dienGiai);
            else
                cm.Parameters.AddWithValue("@DienGiai", DBNull.Value);
            cm.Parameters.AddWithValue("@BoPhan", CurrentUser.Info.MaCongTy);
            cm.Parameters.AddWithValue("@NguoiChinhSua", CurrentUser.Info.UserID);
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

            ExecuteDelete(tr, new Criteria(_oid));
            MarkNew();
        }
        #endregion //Data Access - Delete
        #endregion //Data Access
    }
}
