
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{
    [Serializable()]
    public class Xe : Csla.BusinessBase<Xe>
    {
        #region Business Properties and Methods

        //declare members
        private int _id = 0;
        private string _maQuanLyXe = string.Empty;
        private string _tenXe = string.Empty;
        private int _maBoPhan = 0;

        [System.ComponentModel.DataObjectField(true, true)]
        public int Id
        {
            get
            {
                CanReadProperty("Id", true);
                return _id;
            }
        }

        public string MaQuanLyXe
        {
            get
            {
                CanReadProperty("MaQuanLyXe", true);
                return _maQuanLyXe;
            }
            set
            {
                CanWriteProperty("MaQuanLyXe", true);
                if (value == null) value = string.Empty;
                if (!_maQuanLyXe.Equals(value))
                {
                    _maQuanLyXe = value;
                    PropertyHasChanged("MaQuanLyXe");
                }
            }
        }

        public string TenXe
        {
            get
            {
                CanReadProperty("TenXe", true);
                return _tenXe;
            }
            set
            {
                CanWriteProperty("TenXe", true);
                if (value == null) value = string.Empty;
                if (!_tenXe.Equals(value))
                {
                    _tenXe = value;
                    PropertyHasChanged("TenXe");
                }
            }
        }

        public int MaBoPhan
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

        protected override object GetIdValue()
        {
            return _id;
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
            // MaQuanLyXe
            //
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("MaQuanLyXe", 50));
            //
            // TenXe
            //
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("TenXe", 100));
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
            //TODO: Define authorization rules in Xe
            //AuthorizationRules.AllowRead("Id", "XeReadGroup");
            //AuthorizationRules.AllowRead("MaQuanLyXe", "XeReadGroup");
            //AuthorizationRules.AllowRead("TenXe", "XeReadGroup");
            //AuthorizationRules.AllowRead("MaBoPhan", "XeReadGroup");

            //AuthorizationRules.AllowWrite("MaQuanLyXe", "XeWriteGroup");
            //AuthorizationRules.AllowWrite("TenXe", "XeWriteGroup");
            //AuthorizationRules.AllowWrite("MaBoPhan", "XeWriteGroup");
        }


        public static bool CanGetObject()
        {
            //TODO: Define CanGetObject permission in Xe
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("XeViewGroup"))
            //	return true;
            //return false;
        }

        public static bool CanAddObject()
        {
            //TODO: Define CanAddObject permission in Xe
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("XeAddGroup"))
            //	return true;
            //return false;
        }

        public static bool CanEditObject()
        {
            //TODO: Define CanEditObject permission in Xe
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("XeEditGroup"))
            //	return true;
            //return false;
        }

        public static bool CanDeleteObject()
        {
            //TODO: Define CanDeleteObject permission in Xe
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("XeDeleteGroup"))
            //	return true;
            //return false;
        }
        #endregion //Authorization Rules

        #region Factory Methods
        private Xe()
        { /* require use of factory method */ }

        public static Xe NewXe()
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a Xe");
            return DataPortal.Create<Xe>();
        }

        public static Xe GetXe(int id)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a Xe");
            return DataPortal.Fetch<Xe>(new Criteria(id));
        }

        public static void DeleteXe(int id)
        {
            if (!CanDeleteObject())
                throw new System.Security.SecurityException("User not authorized to remove a Xe");
            DataPortal.Delete(new Criteria(id));
        }

        public override Xe Save()
        {
            if (IsDeleted && !CanDeleteObject())
                throw new System.Security.SecurityException("User not authorized to remove a Xe");
            else if (IsNew && !CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a Xe");
            else if (!CanEditObject())
                throw new System.Security.SecurityException("User not authorized to update a Xe");

            return base.Save();
        }

        #endregion //Factory Methods

        #region Child Factory Methods
        internal static Xe NewXeChild()
        {
            Xe child = new Xe();
            child.ValidationRules.CheckRules();
            child.MarkAsChild();
            return child;
        }

        internal static Xe GetXe(SafeDataReader dr)
        {
            Xe child = new Xe();
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
            public int Id;

            public Criteria(int id)
            {
                this.Id = id;
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
                cm.CommandText = "spd_SelecttblXe";

                cm.Parameters.AddWithValue("@ID", criteria.Id);

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
            DataPortal_Delete(new Criteria(_id));
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
                cm.CommandText = "spd_DeletetblXe";

                cm.Parameters.AddWithValue("@ID", criteria.Id);

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
            _id = dr.GetInt32("ID");
            _maQuanLyXe = dr.GetString("MaQuanLyXe");
            _tenXe = dr.GetString("TenXe");
            _maBoPhan = dr.GetInt32("MaBoPhan");
        }

        private void FetchChildren(SafeDataReader dr)
        {
        }
        #endregion //Data Access - Fetch

        #region Data Access - Insert
        internal void Insert(SqlTransaction tr, XeList parent)
        {
            if (!IsDirty) return;

            ExecuteInsert(tr, parent);
            MarkOld();

            //update child object(s)
            UpdateChildren(tr);
        }

        private void ExecuteInsert(SqlTransaction tr, XeList parent)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_InserttblXe";

                AddInsertParameters(cm, parent);

                cm.ExecuteNonQuery();

                _id = (int)cm.Parameters["@ID"].Value;
            }//using
        }

        private void AddInsertParameters(SqlCommand cm, XeList parent)
        {
            //TODO: if parent use identity key, fix fk member with value from parent
            if (_maQuanLyXe.Length > 0)
                cm.Parameters.AddWithValue("@MaQuanLyXe", _maQuanLyXe);
            else
                cm.Parameters.AddWithValue("@MaQuanLyXe", DBNull.Value);
            if (_tenXe.Length > 0)
                cm.Parameters.AddWithValue("@TenXe", _tenXe);
            else
                cm.Parameters.AddWithValue("@TenXe", DBNull.Value);
            if (_maBoPhan != 0)
                cm.Parameters.AddWithValue("@MaBoPhan", _maBoPhan);
            else
                cm.Parameters.AddWithValue("@MaBoPhan", DBNull.Value);
            cm.Parameters.AddWithValue("@ID", _id);
            cm.Parameters["@ID"].Direction = ParameterDirection.Output;
        }
        #endregion //Data Access - Insert

        #region Data Access - Update
        internal void Update(SqlTransaction tr, XeList parent)
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

        private void ExecuteUpdate(SqlTransaction tr, XeList parent)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_UpdatetblXe";

                AddUpdateParameters(cm, parent);

                cm.ExecuteNonQuery();

            }//using
        }

        private void AddUpdateParameters(SqlCommand cm, XeList parent)
        {
            cm.Parameters.AddWithValue("@ID", _id);
            if (_maQuanLyXe.Length > 0)
                cm.Parameters.AddWithValue("@MaQuanLyXe", _maQuanLyXe);
            else
                cm.Parameters.AddWithValue("@MaQuanLyXe", DBNull.Value);
            if (_tenXe.Length > 0)
                cm.Parameters.AddWithValue("@TenXe", _tenXe);
            else
                cm.Parameters.AddWithValue("@TenXe", DBNull.Value);
            if (_maBoPhan != 0)
                cm.Parameters.AddWithValue("@MaBoPhan", _maBoPhan);
            else
                cm.Parameters.AddWithValue("@MaBoPhan", DBNull.Value);
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

            ExecuteDelete(tr, new Criteria(_id));
            MarkNew();
        }
        #endregion //Data Access - Delete
        #endregion //Data Access
    }
}
