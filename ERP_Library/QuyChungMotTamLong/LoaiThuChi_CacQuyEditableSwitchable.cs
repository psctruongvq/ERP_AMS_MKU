
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{
    [Serializable()]
    public class LoaiThuChi_CacQuy : Csla.BusinessBase<LoaiThuChi_CacQuy>
    {
        #region Business Properties and Methods

        //declare members
        private int _maLoaiThuChi = 0;
        private string _tenLoaiThuChi = string.Empty;
        private bool _isThu = false;

        [System.ComponentModel.DataObjectField(true, true)]
        public int MaLoaiThuChi
        {
            get
            {
                CanReadProperty("MaLoaiThuChi", true);
                return _maLoaiThuChi;
            }
        }

        public string TenLoaiThuChi
        {
            get
            {
                CanReadProperty("TenLoaiThuChi", true);
                return _tenLoaiThuChi;
            }
            set
            {
                CanWriteProperty("TenLoaiThuChi", true);
                if (!_tenLoaiThuChi.Equals(value))
                {
                    _tenLoaiThuChi = value;
                    PropertyHasChanged("TenLoaiThuChi");
                }
            }
        }

        public bool IsThu
        {
            get
            {
                CanReadProperty("IsThu", true);
                return _isThu;
            }
            set
            {
                CanWriteProperty("IsThu", true);
                if (!_isThu.Equals(value))
                {
                    _isThu = value;
                    PropertyHasChanged("IsThu");
                }
            }
        }

        protected override object GetIdValue()
        {
            return _maLoaiThuChi;
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
            //TODO: Define authorization rules in LoaiThuChi_CacQuy
            //AuthorizationRules.AllowRead("MaLoaiThuChi", "LoaiThuChi_CacQuyReadGroup");
            //AuthorizationRules.AllowRead("TenLoaiThuChi", "LoaiThuChi_CacQuyReadGroup");
            //AuthorizationRules.AllowRead("IsThu", "LoaiThuChi_CacQuyReadGroup");

            //AuthorizationRules.AllowWrite("TenLoaiThuChi", "LoaiThuChi_CacQuyWriteGroup");
            //AuthorizationRules.AllowWrite("IsThu", "LoaiThuChi_CacQuyWriteGroup");
        }


        public static bool CanGetObject()
        {
            //TODO: Define CanGetObject permission in LoaiThuChi_CacQuy
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("LoaiThuChi_CacQuyViewGroup"))
            //	return true;
            //return false;
        }

        public static bool CanAddObject()
        {
            //TODO: Define CanAddObject permission in LoaiThuChi_CacQuy
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("LoaiThuChi_CacQuyAddGroup"))
            //	return true;
            //return false;
        }

        public static bool CanEditObject()
        {
            //TODO: Define CanEditObject permission in LoaiThuChi_CacQuy
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("LoaiThuChi_CacQuyEditGroup"))
            //	return true;
            //return false;
        }

        public static bool CanDeleteObject()
        {
            //TODO: Define CanDeleteObject permission in LoaiThuChi_CacQuy
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("LoaiThuChi_CacQuyDeleteGroup"))
            //	return true;
            //return false;
        }
        #endregion //Authorization Rules

        #region Factory Methods
        private LoaiThuChi_CacQuy()
        { 
            /* require use of factory method */
            MarkAsChild();
        }

        public static LoaiThuChi_CacQuy NewLoaiThuChi_CacQuy()
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a LoaiThuChi_CacQuy");
            return DataPortal.Create<LoaiThuChi_CacQuy>();
        }

        public static LoaiThuChi_CacQuy NewLoaiThuChi_CacQuy(string TenLoaiThuChi)
        {
            LoaiThuChi_CacQuy child = new LoaiThuChi_CacQuy();
            child.TenLoaiThuChi = TenLoaiThuChi;
            return child;
        }

        public static LoaiThuChi_CacQuy GetLoaiThuChi_CacQuy(int maLoaiThuChi)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a LoaiThuChi_CacQuy");
            return DataPortal.Fetch<LoaiThuChi_CacQuy>(new Criteria(maLoaiThuChi));
        }

        public static void DeleteLoaiThuChi_CacQuy(int maLoaiThuChi)
        {
            if (!CanDeleteObject())
                throw new System.Security.SecurityException("User not authorized to remove a LoaiThuChi_CacQuy");
            DataPortal.Delete(new Criteria(maLoaiThuChi));
        }

        public override LoaiThuChi_CacQuy Save()
        {
            if (IsDeleted && !CanDeleteObject())
                throw new System.Security.SecurityException("User not authorized to remove a LoaiThuChi_CacQuy");
            else if (IsNew && !CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a LoaiThuChi_CacQuy");
            else if (!CanEditObject())
                throw new System.Security.SecurityException("User not authorized to update a LoaiThuChi_CacQuy");

            return base.Save();
        }

        #endregion //Factory Methods

        #region Child Factory Methods
        internal static LoaiThuChi_CacQuy NewLoaiThuChi_CacQuyChild()
        {
            LoaiThuChi_CacQuy child = new LoaiThuChi_CacQuy();
            child.ValidationRules.CheckRules();
            child.MarkAsChild();
            return child;
        }

        internal static LoaiThuChi_CacQuy GetLoaiThuChi_CacQuy(SafeDataReader dr)
        {
            LoaiThuChi_CacQuy child = new LoaiThuChi_CacQuy();
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
            public int MaLoaiThuChi;

            public Criteria(int maLoaiThuChi)
            {
                this.MaLoaiThuChi = maLoaiThuChi;
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
                cm.CommandText = "spd_SelecttblLoaiThuChi_CacQuy";

                cm.Parameters.AddWithValue("@MaLoaiThuChi", criteria.MaLoaiThuChi);

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
            DataPortal_Delete(new Criteria(_maLoaiThuChi));
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
                cm.CommandText = "spd_DeletetblLoaiThuChi_CacQuy";

                cm.Parameters.AddWithValue("@MaLoaiThuChi", criteria.MaLoaiThuChi);

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
            _maLoaiThuChi = dr.GetInt32("MaLoaiThuChi");
            _tenLoaiThuChi = dr.GetString("TenLoaiThuChi");
            _isThu = dr.GetBoolean("IsThu");
        }

        private void FetchChildren(SafeDataReader dr)
        {
        }
        #endregion //Data Access - Fetch

        #region Data Access - Insert
        internal void Insert(SqlTransaction tr, LoaiThuChi_CacQuyList parent)
        {
            if (!IsDirty) return;

            ExecuteInsert(tr, parent);
            MarkOld();

            //update child object(s)
            UpdateChildren(tr);
        }

        private void ExecuteInsert(SqlTransaction tr, LoaiThuChi_CacQuyList parent)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_InserttblLoaiThuChi_CacQuy";

                AddInsertParameters(cm, parent);

                cm.ExecuteNonQuery();

                _maLoaiThuChi = (int)cm.Parameters["@MaLoaiThuChi"].Value;
            }//using
        }

        private void AddInsertParameters(SqlCommand cm, LoaiThuChi_CacQuyList parent)
        {
            //TODO: if parent use identity key, fix fk member with value from parent
            if (_tenLoaiThuChi != string.Empty)
                cm.Parameters.AddWithValue("@TenLoaiThuChi", _tenLoaiThuChi);
            else
                cm.Parameters.AddWithValue("@TenLoaiThuChi", DBNull.Value);
            if (_isThu != false)
                cm.Parameters.AddWithValue("@IsThu", _isThu);
            else
                cm.Parameters.AddWithValue("@IsThu", DBNull.Value);
            cm.Parameters.AddWithValue("@MaLoaiThuChi", _maLoaiThuChi);
            cm.Parameters["@MaLoaiThuChi"].Direction = ParameterDirection.Output;
        }
        #endregion //Data Access - Insert

        #region Data Access - Update
        internal void Update(SqlTransaction tr, LoaiThuChi_CacQuyList parent)
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

        private void ExecuteUpdate(SqlTransaction tr, LoaiThuChi_CacQuyList parent)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_UpdatetblLoaiThuChi_CacQuy";

                AddUpdateParameters(cm, parent);

                cm.ExecuteNonQuery();

            }//using
        }

        private void AddUpdateParameters(SqlCommand cm, LoaiThuChi_CacQuyList parent)
        {
            cm.Parameters.AddWithValue("@MaLoaiThuChi", _maLoaiThuChi);
            if (_tenLoaiThuChi != string.Empty)
                cm.Parameters.AddWithValue("@TenLoaiThuChi", _tenLoaiThuChi);
            else
                cm.Parameters.AddWithValue("@TenLoaiThuChi", DBNull.Value);
            if (_isThu != false)
                cm.Parameters.AddWithValue("@IsThu", _isThu);
            else
                cm.Parameters.AddWithValue("@IsThu", DBNull.Value);
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

            ExecuteDelete(tr, new Criteria(_maLoaiThuChi));
            MarkNew();
        }
        #endregion //Data Access - Delete
        #endregion //Data Access
    }
}
