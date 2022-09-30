
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{
    [Serializable()]
    public class NhomVanBan : Csla.BusinessBase<NhomVanBan>
    {
        #region Business Properties and Methods

        //declare members
        private long _maNhomVanBan = 0;
        private string _maQuanLy = string.Empty;
        private string _tenNhomvanBan = string.Empty;
        private string _dienGiai = string.Empty;
        private long _maBoPhan = 0;
        private int _userId = 0;
        private long _maNhomCha = 0;

        [System.ComponentModel.DataObjectField(true, true)]
        public long MaNhomVanBan
        {
            get
            {
                CanReadProperty("MaNhomVanBan", true);
                return _maNhomVanBan;
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

        public string TenNhomvanBan
        {
            get
            {
                CanReadProperty("TenNhomvanBan", true);
                return _tenNhomvanBan;
            }
            set
            {
                CanWriteProperty("TenNhomvanBan", true);
                if (value == null) value = string.Empty;
                if (!_tenNhomvanBan.Equals(value))
                {
                    _tenNhomvanBan = value;
                    PropertyHasChanged("TenNhomvanBan");
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

        public long MaBoPhan
        {
            get
            {
                CanReadProperty("MaBoPhan", true);
                return _maBoPhan;
            }
            set
            {
                CanWriteProperty("MaBoPhan", true);
                if (!_maBoPhan.Equals(value))
                {
                    _maBoPhan = value;
                    PropertyHasChanged("MaBoPhan");
                }
            }
        }

        public int UserId
        {
            get
            {
                CanReadProperty("UserId", true);
                return _userId;
            }
            set
            {
                CanWriteProperty("UserId", true);
                if (!_userId.Equals(value))
                {
                    _userId = value;
                    PropertyHasChanged("UserId");
                }
            }
        }

        public long MaNhomCha
        {
            get
            {
                CanReadProperty("MaNhomCha", true);
                return _maNhomCha;
            }
            set
            {
                CanWriteProperty("MaNhomCha", true);
                if (!_maNhomCha.Equals(value))
                {
                    _maNhomCha = value;
                    PropertyHasChanged("MaNhomCha");
                }
            }
        }

        protected override object GetIdValue()
        {
            return _maNhomVanBan;
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
            // TenNhomvanBan
            //
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("TenNhomvanBan", 100));
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
            //TODO: Define authorization rules in NhomVanBan
            //AuthorizationRules.AllowRead("MaNhomVanBan", "NhomVanBanReadGroup");
            //AuthorizationRules.AllowRead("MaQuanLy", "NhomVanBanReadGroup");
            //AuthorizationRules.AllowRead("TenNhomvanBan", "NhomVanBanReadGroup");
            //AuthorizationRules.AllowRead("DienGiai", "NhomVanBanReadGroup");
            //AuthorizationRules.AllowRead("MaBoPhan", "NhomVanBanReadGroup");
            //AuthorizationRules.AllowRead("UserId", "NhomVanBanReadGroup");
            //AuthorizationRules.AllowRead("MaNhomCha", "NhomVanBanReadGroup");

            //AuthorizationRules.AllowWrite("MaQuanLy", "NhomVanBanWriteGroup");
            //AuthorizationRules.AllowWrite("TenNhomvanBan", "NhomVanBanWriteGroup");
            //AuthorizationRules.AllowWrite("DienGiai", "NhomVanBanWriteGroup");
            //AuthorizationRules.AllowWrite("MaBoPhan", "NhomVanBanWriteGroup");
            //AuthorizationRules.AllowWrite("UserId", "NhomVanBanWriteGroup");
            //AuthorizationRules.AllowWrite("MaNhomCha", "NhomVanBanWriteGroup");
        }


        public static bool CanGetObject()
        {
            //TODO: Define CanGetObject permission in NhomVanBan
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("NhomVanBanViewGroup"))
            //	return true;
            //return false;
        }

        public static bool CanAddObject()
        {
            //TODO: Define CanAddObject permission in NhomVanBan
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("NhomVanBanAddGroup"))
            //	return true;
            //return false;
        }

        public static bool CanEditObject()
        {
            //TODO: Define CanEditObject permission in NhomVanBan
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("NhomVanBanEditGroup"))
            //	return true;
            //return false;
        }

        public static bool CanDeleteObject()
        {
            //TODO: Define CanDeleteObject permission in NhomVanBan
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("NhomVanBanDeleteGroup"))
            //	return true;
            //return false;
        }
        #endregion //Authorization Rules

        #region Factory Methods
        private NhomVanBan()
        { /* require use of factory method */ }

        private NhomVanBan(int maNhom, string tenNhom)
        { 
            /* require use of factory method */
            this._maNhomCha = 0;
            this.TenNhomvanBan = tenNhom;
            this._maNhomVanBan = maNhom;
        }

        public static NhomVanBan NewNhomVanBan()
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a NhomVanBan");
            return DataPortal.Create<NhomVanBan>();
        }

        public static NhomVanBan NewNhomVanBan(int maNhom, string tenNhom)
        {
            NhomVanBan _NhomVanBan = new NhomVanBan(maNhom, tenNhom);
            return _NhomVanBan;
        }

        public static NhomVanBan GetNhomVanBan(long maNhomVanBan)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a NhomVanBan");
            return DataPortal.Fetch<NhomVanBan>(new Criteria(maNhomVanBan));
        }

        public static void DeleteNhomVanBan(long maNhomVanBan)
        {
            if (!CanDeleteObject())
                throw new System.Security.SecurityException("User not authorized to remove a NhomVanBan");
            DataPortal.Delete(new Criteria(maNhomVanBan));
        }

        public override NhomVanBan Save()
        {
            if (IsDeleted && !CanDeleteObject())
                throw new System.Security.SecurityException("User not authorized to remove a NhomVanBan");
            else if (IsNew && !CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a NhomVanBan");
            else if (!CanEditObject())
                throw new System.Security.SecurityException("User not authorized to update a NhomVanBan");

            return base.Save();
        }

        #endregion //Factory Methods

        #region Child Factory Methods
        internal static NhomVanBan NewNhomVanBanChild()
        {
            NhomVanBan child = new NhomVanBan();
            child.ValidationRules.CheckRules();
            child.MarkAsChild();
            return child;
        }

        internal static NhomVanBan GetNhomVanBan(SafeDataReader dr)
        {
            NhomVanBan child = new NhomVanBan();
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
            public long MaNhomVanBan;

            public Criteria(long maNhomVanBan)
            {
                this.MaNhomVanBan = maNhomVanBan;
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
                cm.CommandText = "spd_SelecttblNhomVanBan";

                cm.Parameters.AddWithValue("@MaNhomVanBan", criteria.MaNhomVanBan);

                using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                {
                    while (dr.Read())
                    {
                        FetchObject(dr);
                        ValidationRules.CheckRules();

                        //load child object(s)
                        FetchChildren(dr);
                    }
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
            DataPortal_Delete(new Criteria(_maNhomVanBan));
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
                cm.CommandText = "spd_DeletetblNhomVanBan";

                cm.Parameters.AddWithValue("@MaNhomVanBan", criteria.MaNhomVanBan);

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
            _maNhomVanBan = dr.GetInt64("MaNhomVanBan");
            _maQuanLy = dr.GetString("MaQuanLy");
            _tenNhomvanBan = dr.GetString("TenNhomvanBan");
            _dienGiai = dr.GetString("DienGiai");
            _maBoPhan = dr.GetInt64("MaBoPhan");
            _userId = dr.GetInt32("UserId");
            _maNhomCha = dr.GetInt64("MaNhomCha");
        }

        private void FetchChildren(SafeDataReader dr)
        {
        }
        #endregion //Data Access - Fetch

        #region Data Access - Insert
        internal void Insert(SqlTransaction tr, NhomVanBanList parent)
        {
            if (!IsDirty) return;

            ExecuteInsert(tr, parent);
            MarkOld();

            //update child object(s)
            UpdateChildren(tr);
        }

        private void ExecuteInsert(SqlTransaction tr, NhomVanBanList parent)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_InserttblNhomVanBan";

                AddInsertParameters(cm, parent);

                cm.ExecuteNonQuery();

                _maNhomVanBan = (long)cm.Parameters["@MaNhomVanBan"].Value;
            }//using
        }

        private void AddInsertParameters(SqlCommand cm, NhomVanBanList parent)
        {
            //TODO: if parent use identity key, fix fk member with value from parent
            if (_maQuanLy.Length > 0)
                cm.Parameters.AddWithValue("@MaQuanLy", _maQuanLy);
            else
                cm.Parameters.AddWithValue("@MaQuanLy", DBNull.Value);
            if (_tenNhomvanBan.Length > 0)
                cm.Parameters.AddWithValue("@TenNhomvanBan", _tenNhomvanBan);
            else
                cm.Parameters.AddWithValue("@TenNhomvanBan", DBNull.Value);
            if (_dienGiai.Length > 0)
                cm.Parameters.AddWithValue("@DienGiai", _dienGiai);
            else
                cm.Parameters.AddWithValue("@DienGiai", DBNull.Value);
            cm.Parameters.AddWithValue("@MaBoPhan", Security.CurrentUser.Info.MaBoPhan);
            cm.Parameters.AddWithValue("@UserId", Security.CurrentUser.Info.UserID);
            if (_maNhomCha != 0)
                cm.Parameters.AddWithValue("@MaNhomCha", _maNhomCha);
            else
                cm.Parameters.AddWithValue("@MaNhomCha", DBNull.Value);

            cm.Parameters.AddWithValue("@MaNhomVanBan", _maNhomVanBan);
            cm.Parameters["@MaNhomVanBan"].Direction = ParameterDirection.Output;
        }
        #endregion //Data Access - Insert

        #region Data Access - Update
        internal void Update(SqlTransaction tr, NhomVanBanList parent)
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

        private void ExecuteUpdate(SqlTransaction tr, NhomVanBanList parent)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_UpdatetblNhomVanBan";

                AddUpdateParameters(cm, parent);

                cm.ExecuteNonQuery();

            }//using
        }

        private void AddUpdateParameters(SqlCommand cm, NhomVanBanList parent)
        {
            cm.Parameters.AddWithValue("@MaNhomVanBan", _maNhomVanBan);
            if (_maQuanLy.Length > 0)
                cm.Parameters.AddWithValue("@MaQuanLy", _maQuanLy);
            else
                cm.Parameters.AddWithValue("@MaQuanLy", DBNull.Value);
            if (_tenNhomvanBan.Length > 0)
                cm.Parameters.AddWithValue("@TenNhomvanBan", _tenNhomvanBan);
            else
                cm.Parameters.AddWithValue("@TenNhomvanBan", DBNull.Value);
            if (_dienGiai.Length > 0)
                cm.Parameters.AddWithValue("@DienGiai", _dienGiai);
            else
                cm.Parameters.AddWithValue("@DienGiai", DBNull.Value);
            cm.Parameters.AddWithValue("@MaBoPhan", Security.CurrentUser.Info.MaBoPhan);
            cm.Parameters.AddWithValue("@UserId", Security.CurrentUser.Info.UserID);
            if (_maNhomCha != 0)
                cm.Parameters.AddWithValue("@MaNhomCha", _maNhomCha);
            else
                cm.Parameters.AddWithValue("@MaNhomCha", DBNull.Value);
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

            ExecuteDelete(tr, new Criteria(_maNhomVanBan));
            MarkNew();
        }
        #endregion //Data Access - Delete
        #endregion //Data Access
    }
}
