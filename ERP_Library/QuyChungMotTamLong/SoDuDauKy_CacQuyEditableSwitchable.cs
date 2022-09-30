
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{
    [Serializable()]
    public class SoDuDauKy_CacQuy : Csla.BusinessBase<SoDuDauKy_CacQuy>
    {
        #region Business Properties and Methods

        //declare members
        private long _maChiTiet = 0;
        private int _maKy = 0;
        private int _maLoaiQuy = 0;
        private decimal _soDuDauKyCo = 0;
        private decimal _soDuDauKyNo = 0;
        private string _tenCacQuy = string.Empty;

        [System.ComponentModel.DataObjectField(true, true)]
        public long MaChiTiet
        {
            get
            {
                CanReadProperty("MaChiTiet", true);
                return _maChiTiet;
            }
        }

        public int MaKy
        {
            get
            {
                CanReadProperty("MaKy", true);
                return _maKy;
            }
            set
            {
                CanWriteProperty("MaKy", true);
                if (!_maKy.Equals(value))
                {
                    _maKy = value;
                    PropertyHasChanged("MaKy");
                }
            }
        }

        public int MaLoaiQuy
        {
            get
            {
                CanReadProperty("MaLoaiQuy", true);
                return _maLoaiQuy;
            }
            set
            {
                CanWriteProperty("MaLoaiQuy", true);
                if (!_maLoaiQuy.Equals(value))
                {
                    _maLoaiQuy = value;
                    PropertyHasChanged("MaLoaiQuy");
                }
            }
        }

        public string TenCacQuy
        {
            get
            {
                CanReadProperty("TenTaiKhoan", true);
                return _tenCacQuy;
            }
        }

        public decimal SoDuDauKyCo
        {
            get
            {
                CanReadProperty("SoDuDauKyCo", true);
                return _soDuDauKyCo;
            }
            set
            {
                CanWriteProperty("SoDuDauKyCo", true);
                if (!_soDuDauKyCo.Equals(value))
                {
                    _soDuDauKyCo = value;
                    PropertyHasChanged("SoDuDauKyCo");
                }
            }
        }

        public decimal SoDuDauKyNo
        {
            get
            {
                CanReadProperty("SoDuDauKyNo", true);
                return _soDuDauKyNo;
            }
            set
            {
                CanWriteProperty("SoDuDauKyNo", true);
                if (!_soDuDauKyNo.Equals(value))
                {
                    _soDuDauKyNo = value;
                    PropertyHasChanged("SoDuDauKyNo");
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
            //TODO: Define authorization rules in SoDuDauKy_CacQuy
            //AuthorizationRules.AllowRead("MaChiTiet", "SoDuDauKy_CacQuyReadGroup");
            //AuthorizationRules.AllowRead("MaKy", "SoDuDauKy_CacQuyReadGroup");
            //AuthorizationRules.AllowRead("MaTaiKhoan", "SoDuDauKy_CacQuyReadGroup");
            //AuthorizationRules.AllowRead("SoDuDauKyCo", "SoDuDauKy_CacQuyReadGroup");
            //AuthorizationRules.AllowRead("SoDuDauKyNo", "SoDuDauKy_CacQuyReadGroup");

            //AuthorizationRules.AllowWrite("MaKy", "SoDuDauKy_CacQuyWriteGroup");
            //AuthorizationRules.AllowWrite("MaTaiKhoan", "SoDuDauKy_CacQuyWriteGroup");
            //AuthorizationRules.AllowWrite("SoDuDauKyCo", "SoDuDauKy_CacQuyWriteGroup");
            //AuthorizationRules.AllowWrite("SoDuDauKyNo", "SoDuDauKy_CacQuyWriteGroup");
        }


        public static bool CanGetObject()
        {
            //TODO: Define CanGetObject permission in SoDuDauKy_CacQuy
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("SoDuDauKy_CacQuyViewGroup"))
            //	return true;
            //return false;
        }

        public static bool CanAddObject()
        {
            //TODO: Define CanAddObject permission in SoDuDauKy_CacQuy
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("SoDuDauKy_CacQuyAddGroup"))
            //	return true;
            //return false;
        }

        public static bool CanEditObject()
        {
            //TODO: Define CanEditObject permission in SoDuDauKy_CacQuy
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("SoDuDauKy_CacQuyEditGroup"))
            //	return true;
            //return false;
        }

        public static bool CanDeleteObject()
        {
            //TODO: Define CanDeleteObject permission in SoDuDauKy_CacQuy
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("SoDuDauKy_CacQuyDeleteGroup"))
            //	return true;
            //return false;
        }
        #endregion //Authorization Rules

        #region Factory Methods
        private SoDuDauKy_CacQuy()
        { /* require use of factory method */ }

        public static SoDuDauKy_CacQuy NewSoDuDauKy_CacQuy()
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a SoDuDauKy_CacQuy");
            return DataPortal.Create<SoDuDauKy_CacQuy>();
        }

        public static SoDuDauKy_CacQuy GetSoDuDauKy_CacQuy(long maChiTiet)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a SoDuDauKy_CacQuy");
            return DataPortal.Fetch<SoDuDauKy_CacQuy>(new Criteria(maChiTiet));
        }

        public static void DeleteSoDuDauKy_CacQuy(long maChiTiet)
        {
            if (!CanDeleteObject())
                throw new System.Security.SecurityException("User not authorized to remove a SoDuDauKy_CacQuy");
            DataPortal.Delete(new Criteria(maChiTiet));
        }

        public override SoDuDauKy_CacQuy Save()
        {
            if (IsDeleted && !CanDeleteObject())
                throw new System.Security.SecurityException("User not authorized to remove a SoDuDauKy_CacQuy");
            else if (IsNew && !CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a SoDuDauKy_CacQuy");
            else if (!CanEditObject())
                throw new System.Security.SecurityException("User not authorized to update a SoDuDauKy_CacQuy");

            return base.Save();
        }

        #endregion //Factory Methods

        #region Child Factory Methods
        internal static SoDuDauKy_CacQuy NewSoDuDauKy_CacQuyChild()
        {
            SoDuDauKy_CacQuy child = new SoDuDauKy_CacQuy();
            child.ValidationRules.CheckRules();
            child.MarkAsChild();
            return child;
        }

        internal static SoDuDauKy_CacQuy GetSoDuDauKy_CacQuy(SafeDataReader dr)
        {
            SoDuDauKy_CacQuy child = new SoDuDauKy_CacQuy();
            child.MarkAsChild();
            child.Fetch(dr);
            return child;
        }

        internal static SoDuDauKy_CacQuy GetSoDuDauKy_CacQuy(SafeDataReader dr, bool KiemTra)
        {
            SoDuDauKy_CacQuy child = new SoDuDauKy_CacQuy();
            child.MarkAsChild();
            child.Fetch(dr, KiemTra);
            return child;
        }
        #endregion //Child Factory Methods

        #region Data Access

        #region Criteria

        [Serializable()]
        private class Criteria
        {
            public long MaChiTiet;

            public Criteria(long maChiTiet)
            {
                this.MaChiTiet = maChiTiet;
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

            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
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
                cm.CommandText = "spd_SelecttblSoDuDauKy_CacQuy";

                cm.Parameters.AddWithValue("@MaChiTiet", criteria.MaChiTiet);

                using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                {
                    if (dr.Read())
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

            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
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

            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
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
            DataPortal_Delete(new Criteria(_maChiTiet));
        }

        private void DataPortal_Delete(Criteria criteria)
        {
            SqlTransaction tr;

            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
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
                cm.CommandText = "spd_DeletetblSoDuDauKy_CacQuy";

                cm.Parameters.AddWithValue("@MaChiTiet", criteria.MaChiTiet);

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

        private void Fetch(SafeDataReader dr, bool IsOld)
        {
            FetchObject(dr);
            //Kiểm tra nếu cũ thì đánh dấu markold không thì đánh dấu là mới
            if (IsOld)
            {
                MarkOld();
            }
            else
            {
                MarkNew();
            }

            ValidationRules.CheckRules();

            //load child object(s)
            FetchChildren(dr);

        }

        private void FetchObject(SafeDataReader dr)
        {
            _maChiTiet = dr.GetInt64("MaChiTiet");
            _maKy = dr.GetInt32("MaKy");
            _maLoaiQuy = dr.GetInt32("MaLoaiQuy");
            _soDuDauKyCo = dr.GetDecimal("SoDuDauKyCo");
            _soDuDauKyNo = dr.GetDecimal("SoDuDauKyNo");
            _tenCacQuy = dr.GetString("TenCacQuy");
        }

        private void FetchChildren(SafeDataReader dr)
        {
        }
        #endregion //Data Access - Fetch

        #region Data Access - Insert
        internal void Insert(SqlTransaction tr, SoDuDauKy_CacQuyList parent)
        {
            if (!IsDirty) return;

            ExecuteInsert(tr, parent);
            MarkOld();

            //update child object(s)
            UpdateChildren(tr);
        }

        private void ExecuteInsert(SqlTransaction tr, SoDuDauKy_CacQuyList parent)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_InserttblSoDuDauKy_CacQuy";

                AddInsertParameters(cm, parent);

                cm.ExecuteNonQuery();

                _maChiTiet = (long)cm.Parameters["@MaChiTiet"].Value;
            }//using
        }

        private void AddInsertParameters(SqlCommand cm, SoDuDauKy_CacQuyList parent)
        {
            //TODO: if parent use identity key, fix fk member with value from parent
            if (_maKy != 0)
                cm.Parameters.AddWithValue("@MaKy", _maKy);
            else
                cm.Parameters.AddWithValue("@MaKy", DBNull.Value);
            if (_maLoaiQuy != 0)
                cm.Parameters.AddWithValue("@MaLoaiQuy", _maLoaiQuy);
            else
                cm.Parameters.AddWithValue("@MaLoaiQuy", DBNull.Value);
            if (_soDuDauKyCo != 0)
                cm.Parameters.AddWithValue("@SoDuDauKyCo", _soDuDauKyCo);
            else
                cm.Parameters.AddWithValue("@SoDuDauKyCo", DBNull.Value);
            if (_soDuDauKyNo != 0)
                cm.Parameters.AddWithValue("@SoDuDauKyNo", _soDuDauKyNo);
            else
                cm.Parameters.AddWithValue("@SoDuDauKyNo", DBNull.Value);
            cm.Parameters.AddWithValue("@MaChiTiet", _maChiTiet);
            cm.Parameters["@MaChiTiet"].Direction = ParameterDirection.Output;
        }
        #endregion //Data Access - Insert

        #region Data Access - Update
        internal void Update(SqlTransaction tr, SoDuDauKy_CacQuyList parent)
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

        private void ExecuteUpdate(SqlTransaction tr, SoDuDauKy_CacQuyList parent)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_UpdatetblSoDuDauKy_CacQuy";

                AddUpdateParameters(cm, parent);

                cm.ExecuteNonQuery();

            }//using
        }

        private void AddUpdateParameters(SqlCommand cm, SoDuDauKy_CacQuyList parent)
        {
            cm.Parameters.AddWithValue("@MaChiTiet", _maChiTiet);
            if (_maKy != 0)
                cm.Parameters.AddWithValue("@MaKy", _maKy);
            if (_maLoaiQuy != 0)
                cm.Parameters.AddWithValue("@MaLoaiQuy", _maLoaiQuy);
            else
                cm.Parameters.AddWithValue("@MaLoaiQuy", DBNull.Value);
            if (_soDuDauKyCo != 0)
                cm.Parameters.AddWithValue("@SoDuDauKyCo", _soDuDauKyCo);
            else
                cm.Parameters.AddWithValue("@SoDuDauKyCo", DBNull.Value);
            if (_soDuDauKyNo != 0)
                cm.Parameters.AddWithValue("@SoDuDauKyNo", _soDuDauKyNo);
            else
                cm.Parameters.AddWithValue("@SoDuDauKyNo", DBNull.Value);
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

            ExecuteDelete(tr, new Criteria(_maChiTiet));
            MarkNew();
        }
        #endregion //Data Access - Delete
        #endregion //Data Access
    }
}
