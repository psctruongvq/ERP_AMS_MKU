
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{
    [Serializable()]
    public class KhoiSanXuat : Csla.BusinessBase<KhoiSanXuat>
    {
        #region Business Properties and Methods

        //declare members
        private int _maKhoiSanXuat = 0;
        private string _maKhoiQuanLy = string.Empty;
        private string _tenKhoiSanXuat = string.Empty;

        [System.ComponentModel.DataObjectField(true, true)]
        public int MaKhoiSanXuat
        {
            get
            {
                CanReadProperty("MaKhoiSanXuat", true);
                return _maKhoiSanXuat;
            }
        }

        public string MaKhoiQuanLy
        {
            get
            {
                CanReadProperty("MaKhoiQuanLy", true);
                return _maKhoiQuanLy;
            }
            set
            {
                CanWriteProperty("MaKhoiQuanLy", true);
                if (value == null) value = string.Empty;
                if (!_maKhoiQuanLy.Equals(value))
                {
                    _maKhoiQuanLy = value;
                    PropertyHasChanged("MaKhoiQuanLy");
                }
            }
        }

        public string TenKhoiSanXuat
        {
            get
            {
                CanReadProperty("TenKhoiSanXuat", true);
                return _tenKhoiSanXuat;
            }
            set
            {
                CanWriteProperty("TenKhoiSanXuat", true);
                if (value == null) value = string.Empty;
                if (!_tenKhoiSanXuat.Equals(value))
                {
                    _tenKhoiSanXuat = value;
                    PropertyHasChanged("TenKhoiSanXuat");
                }
            }
        }

        protected override object GetIdValue()
        {
            return _maKhoiSanXuat;
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
            // MaKhoiQuanLy
            //
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("MaKhoiQuanLy", 50));
            //
            // TenKhoiSanXuat
            //
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("TenKhoiSanXuat", 200));
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
            //TODO: Define authorization rules in KhoiSanXuat
            //AuthorizationRules.AllowRead("MaKhoiSanXuat", "KhoiSanXuatReadGroup");
            //AuthorizationRules.AllowRead("MaKhoiQuanLy", "KhoiSanXuatReadGroup");
            //AuthorizationRules.AllowRead("TenKhoiSanXuat", "KhoiSanXuatReadGroup");

            //AuthorizationRules.AllowWrite("MaKhoiQuanLy", "KhoiSanXuatWriteGroup");
            //AuthorizationRules.AllowWrite("TenKhoiSanXuat", "KhoiSanXuatWriteGroup");
        }


        public static bool CanGetObject()
        {
            //TODO: Define CanGetObject permission in KhoiSanXuat
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("KhoiSanXuatViewGroup"))
            //	return true;
            //return false;
        }

        public static bool CanAddObject()
        {
            //TODO: Define CanAddObject permission in KhoiSanXuat
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("KhoiSanXuatAddGroup"))
            //	return true;
            //return false;
        }

        public static bool CanEditObject()
        {
            //TODO: Define CanEditObject permission in KhoiSanXuat
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("KhoiSanXuatEditGroup"))
            //	return true;
            //return false;
        }

        public static bool CanDeleteObject()
        {
            //TODO: Define CanDeleteObject permission in KhoiSanXuat
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("KhoiSanXuatDeleteGroup"))
            //	return true;
            //return false;
        }
        #endregion //Authorization Rules

        #region Factory Methods
        private KhoiSanXuat()
        { /* require use of factory method */ }

        public static KhoiSanXuat NewKhoiSanXuat()
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a KhoiSanXuat");
            return DataPortal.Create<KhoiSanXuat>();
        }

        public static KhoiSanXuat GetKhoiSanXuat(int maKhoiSanXuat)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a KhoiSanXuat");
            return DataPortal.Fetch<KhoiSanXuat>(new Criteria(maKhoiSanXuat));
        }

        public static void DeleteKhoiSanXuat(int maKhoiSanXuat)
        {
            if (!CanDeleteObject())
                throw new System.Security.SecurityException("User not authorized to remove a KhoiSanXuat");
            DataPortal.Delete(new Criteria(maKhoiSanXuat));
        }

        public override KhoiSanXuat Save()
        {
            if (IsDeleted && !CanDeleteObject())
                throw new System.Security.SecurityException("User not authorized to remove a KhoiSanXuat");
            else if (IsNew && !CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a KhoiSanXuat");
            else if (!CanEditObject())
                throw new System.Security.SecurityException("User not authorized to update a KhoiSanXuat");

            return base.Save();
        }

        #endregion //Factory Methods

        #region Child Factory Methods
        internal static KhoiSanXuat NewKhoiSanXuatChild()
        {
            KhoiSanXuat child = new KhoiSanXuat();
            child.ValidationRules.CheckRules();
            child.MarkAsChild();
            return child;
        }

        internal static KhoiSanXuat GetKhoiSanXuat(SafeDataReader dr)
        {
            KhoiSanXuat child = new KhoiSanXuat();
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
            public int MaKhoiSanXuat;

            public Criteria(int maKhoiSanXuat)
            {
                this.MaKhoiSanXuat = maKhoiSanXuat;
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
                cm.CommandText = "spd_SelecttblnsKhoiSanXuat";

                cm.Parameters.AddWithValue("@MaKhoiSanXuat", criteria.MaKhoiSanXuat);

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
                    ExecuteInsert(tr);

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
                        ExecuteUpdate(tr);
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
            DataPortal_Delete(new Criteria(_maKhoiSanXuat));
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
                cm.CommandText = "spd_DeletetblnsKhoiSanXuat";

                cm.Parameters.AddWithValue("@MaKhoiSanXuat", criteria.MaKhoiSanXuat);

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
            _maKhoiSanXuat = dr.GetInt32("MaKhoiSanXuat");
            _maKhoiQuanLy = dr.GetString("MaKhoiQuanLy");
            _tenKhoiSanXuat = dr.GetString("TenKhoiSanXuat");
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
                cm.CommandText = "spd_InserttblsnsKhoiSanXuat";

                AddInsertParameters(cm);

                cm.ExecuteNonQuery();

                _maKhoiSanXuat = (int)cm.Parameters["@MaKhoiSanXuat"].Value;
            }//using
        }

        private void AddInsertParameters(SqlCommand cm)
        {
            if (_maKhoiQuanLy.Length > 0)
                cm.Parameters.AddWithValue("@MaKhoiQuanLy", _maKhoiQuanLy);
            else
                cm.Parameters.AddWithValue("@MaKhoiQuanLy", DBNull.Value);
            if (_tenKhoiSanXuat.Length > 0)
                cm.Parameters.AddWithValue("@TenKhoiSanXuat", _tenKhoiSanXuat);
            else
                cm.Parameters.AddWithValue("@TenKhoiSanXuat", DBNull.Value);
            cm.Parameters.AddWithValue("@MaKhoiSanXuat", _maKhoiSanXuat);
            cm.Parameters["@MaKhoiSanXuat"].Direction = ParameterDirection.Output;
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
                cm.CommandText = "spd_UpdatetblnsKhoiSanXuat";

                AddUpdateParameters(cm);

                cm.ExecuteNonQuery();

            }//using
        }

        private void AddUpdateParameters(SqlCommand cm)
        {
            cm.Parameters.AddWithValue("@MaKhoiSanXuat", _maKhoiSanXuat);
            if (_maKhoiQuanLy.Length > 0)
                cm.Parameters.AddWithValue("@MaKhoiQuanLy", _maKhoiQuanLy);
            else
                cm.Parameters.AddWithValue("@MaKhoiQuanLy", DBNull.Value);
            if (_tenKhoiSanXuat.Length > 0)
                cm.Parameters.AddWithValue("@TenKhoiSanXuat", _tenKhoiSanXuat);
            else
                cm.Parameters.AddWithValue("@TenKhoiSanXuat", DBNull.Value);
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

            ExecuteDelete(tr, new Criteria(_maKhoiSanXuat));
            MarkNew();
        }
        #endregion //Data Access - Delete
        #endregion //Data Access
    }
}
