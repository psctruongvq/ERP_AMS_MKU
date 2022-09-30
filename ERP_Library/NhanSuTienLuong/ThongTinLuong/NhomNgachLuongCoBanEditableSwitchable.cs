
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;
namespace ERP_Library
{

    [Serializable()]
    public class NhomNgachLuongCoBan : Csla.BusinessBase<NhomNgachLuongCoBan>
    {
        #region Business Properties and Methods

        //declare members
        private int _maNhomNgachLuongCoBan = 0;
        private string _maQL = string.Empty;
        private string _tenNhomNgachLuongCoBan = string.Empty;
        private string _dienGiai = string.Empty;

        [System.ComponentModel.DataObjectField(true, false)]
        public int MaNhomNgachLuongCoBan
        {
            get
            {
                CanReadProperty("MaNhomNgachLuongCoBan", true);
                return _maNhomNgachLuongCoBan;
            }
        }

        public string MaQL
        {
            get
            {
                CanReadProperty("MaQL", true);
                return _maQL;
            }
            set
            {
                CanWriteProperty("MaQL", true);
                if (value == null) value = string.Empty;
                if (!_maQL.Equals(value))
                {
                    _maQL = value;
                    PropertyHasChanged("MaQL");
                }
            }
        }

        public string TenNhomNgachLuongCoBan
        {
            get
            {
                CanReadProperty("TenNhomNgachLuongCoBan", true);
                return _tenNhomNgachLuongCoBan;
            }
            set
            {
                CanWriteProperty("TenNhomNgachLuongCoBan", true);
                if (value == null) value = string.Empty;
                if (!_tenNhomNgachLuongCoBan.Equals(value))
                {
                    _tenNhomNgachLuongCoBan = value;
                    PropertyHasChanged("TenNhomNgachLuongCoBan");
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

        protected override object GetIdValue()
        {
            return _maNhomNgachLuongCoBan;
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
            // MaQL
            //
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("MaQL", 50));
            //
            // TenNhomNgachLuongCoBan
            //
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("TenNhomNgachLuongCoBan", 50));
            //
            // DienGiai
            //
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("DienGiai", 500));
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
            //TODO: Define authorization rules in NhomNgachLuongCoBan
            //AuthorizationRules.AllowRead("MaNhomNgachLuongCoBan", "NhomNgachLuongCoBanReadGroup");
            //AuthorizationRules.AllowRead("MaQL", "NhomNgachLuongCoBanReadGroup");
            //AuthorizationRules.AllowRead("TenNhomNgachLuongCoBan", "NhomNgachLuongCoBanReadGroup");
            //AuthorizationRules.AllowRead("DienGiai", "NhomNgachLuongCoBanReadGroup");

            //AuthorizationRules.AllowWrite("MaQL", "NhomNgachLuongCoBanWriteGroup");
            //AuthorizationRules.AllowWrite("TenNhomNgachLuongCoBan", "NhomNgachLuongCoBanWriteGroup");
            //AuthorizationRules.AllowWrite("DienGiai", "NhomNgachLuongCoBanWriteGroup");
        }


        public static bool CanGetObject()
        {
            //TODO: Define CanGetObject permission in NhomNgachLuongCoBan
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("NhomNgachLuongCoBanViewGroup"))
            //	return true;
            //return false;
        }

        public static bool CanAddObject()
        {
            //TODO: Define CanAddObject permission in NhomNgachLuongCoBan
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("NhomNgachLuongCoBanAddGroup"))
            //	return true;
            //return false;
        }

        public static bool CanEditObject()
        {
            //TODO: Define CanEditObject permission in NhomNgachLuongCoBan
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("NhomNgachLuongCoBanEditGroup"))
            //	return true;
            //return false;
        }

        public static bool CanDeleteObject()
        {
            //TODO: Define CanDeleteObject permission in NhomNgachLuongCoBan
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("NhomNgachLuongCoBanDeleteGroup"))
            //	return true;
            //return false;
        }
        #endregion //Authorization Rules

        #region Factory Methods
        private NhomNgachLuongCoBan()
        { /* require use of factory method */ }
        public static NhomNgachLuongCoBan NewNhomNgachLuongCoBan()
        {
            NhomNgachLuongCoBan item = new NhomNgachLuongCoBan();
            item.MarkAsChild();
            return item;
        }

        public static NhomNgachLuongCoBan NewNhomNgachLuongCoBan(int _MaNhom, string _TenNhom)
        {
            NhomNgachLuongCoBan item = new NhomNgachLuongCoBan();
            item._maNhomNgachLuongCoBan = _MaNhom;
            item.TenNhomNgachLuongCoBan = _TenNhom;
            item.MarkAsChild();
            return item;
        }

        public static NhomNgachLuongCoBan NewNhomNgachLuongCoBan(int maNhomNgachLuongCoBan)
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a NhomNgachLuongCoBan");
            return DataPortal.Create<NhomNgachLuongCoBan>(new Criteria(maNhomNgachLuongCoBan));
        }

        public static NhomNgachLuongCoBan GetNhomNgachLuongCoBan(int maNhomNgachLuongCoBan)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a NhomNgachLuongCoBan");
            return DataPortal.Fetch<NhomNgachLuongCoBan>(new Criteria(maNhomNgachLuongCoBan));
        }

        public static void DeleteNhomNgachLuongCoBan(int maNhomNgachLuongCoBan)
        {
            if (!CanDeleteObject())
                throw new System.Security.SecurityException("User not authorized to remove a NhomNgachLuongCoBan");
            DataPortal.Delete(new Criteria(maNhomNgachLuongCoBan));
        }

        public override NhomNgachLuongCoBan Save()
        {
            if (IsDeleted && !CanDeleteObject())
                throw new System.Security.SecurityException("User not authorized to remove a NhomNgachLuongCoBan");
            else if (IsNew && !CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a NhomNgachLuongCoBan");
            else if (!CanEditObject())
                throw new System.Security.SecurityException("User not authorized to update a NhomNgachLuongCoBan");

            return base.Save();
        }

        #endregion //Factory Methods

        #region Child Factory Methods
        private NhomNgachLuongCoBan(int maNhomNgachLuongCoBan)
        {
            this._maNhomNgachLuongCoBan = maNhomNgachLuongCoBan;
        }

        internal static NhomNgachLuongCoBan NewNhomNgachLuongCoBanChild(int maNhomNgachLuongCoBan)
        {
            NhomNgachLuongCoBan child = new NhomNgachLuongCoBan(maNhomNgachLuongCoBan);
            child.ValidationRules.CheckRules();
            child.MarkAsChild();
            return child;
        }

        internal static NhomNgachLuongCoBan GetNhomNgachLuongCoBan(SafeDataReader dr)
        {
            NhomNgachLuongCoBan child = new NhomNgachLuongCoBan();
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
            public int MaNhomNgachLuongCoBan;

            public Criteria(int maNhomNgachLuongCoBan)
            {
                this.MaNhomNgachLuongCoBan = maNhomNgachLuongCoBan;
            }
        }

        #endregion //Criteria

        #region Data Access - Create
        [RunLocal]
        private void DataPortal_Create(Criteria criteria)
        {
            _maNhomNgachLuongCoBan = criteria.MaNhomNgachLuongCoBan;
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
                cm.CommandText = "spd_SelecttblnsNhomNgachLuongCoBan";

                cm.Parameters.AddWithValue("@MaNhomNgachLuongCoBan", criteria.MaNhomNgachLuongCoBan);

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
            DataPortal_Delete(new Criteria(_maNhomNgachLuongCoBan));
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
                cm.CommandText = "spd_DeletetblnsNhomNgachLuongCoBan";

                cm.Parameters.AddWithValue("@MaNhomNgachLuongCoBan", criteria.MaNhomNgachLuongCoBan);

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
            _maNhomNgachLuongCoBan = dr.GetInt32("MaNhomNgachLuongCoBan");
            _maQL = dr.GetString("MaQL");
            _tenNhomNgachLuongCoBan = dr.GetString("TenNhomNgachLuongCoBan");
            _dienGiai = dr.GetString("DienGiai");
        }

        private void FetchChildren(SafeDataReader dr)
        {
        }
        #endregion //Data Access - Fetch

        #region Data Access - Insert
        internal void Insert(SqlTransaction tr, NhomNgachLuongCoBanList parent)
        {
            if (!IsDirty) return;

            ExecuteInsert(tr, parent);
            MarkOld();

            //update child object(s)
            UpdateChildren(tr);
        }

        private void ExecuteInsert(SqlTransaction tr, NhomNgachLuongCoBanList parent)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_InserttblnsNhomNgachLuongCoBan";

                AddInsertParameters(cm, parent);

                cm.ExecuteNonQuery();

            }//using
        }

        private void AddInsertParameters(SqlCommand cm, NhomNgachLuongCoBanList parent)
        {
            //TODO: if parent use identity key, fix fk member with value from parent
            cm.Parameters.AddWithValue("@MaNhomNgachLuongCoBan", _maNhomNgachLuongCoBan);
            if (_maQL.Length > 0)
                cm.Parameters.AddWithValue("@MaQL", _maQL);
            else
                cm.Parameters.AddWithValue("@MaQL", DBNull.Value);
            if (_tenNhomNgachLuongCoBan.Length > 0)
                cm.Parameters.AddWithValue("@TenNhomNgachLuongCoBan", _tenNhomNgachLuongCoBan);
            else
                cm.Parameters.AddWithValue("@TenNhomNgachLuongCoBan", DBNull.Value);
            if (_dienGiai.Length > 0)
                cm.Parameters.AddWithValue("@DienGiai", _dienGiai);
            else
                cm.Parameters.AddWithValue("@DienGiai", DBNull.Value);
            cm.Parameters["@MaNhomNgachLuongCoBan"].Direction = ParameterDirection.Output;
        }
        #endregion //Data Access - Insert

        #region Data Access - Update
        internal void Update(SqlTransaction tr, NhomNgachLuongCoBanList parent)
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

        private void ExecuteUpdate(SqlTransaction tr, NhomNgachLuongCoBanList parent)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_UpdatetblnsNhomNgachLuongCoBan";

                AddUpdateParameters(cm, parent);

                cm.ExecuteNonQuery();

            }//using
        }

        private void AddUpdateParameters(SqlCommand cm, NhomNgachLuongCoBanList parent)
        {
            cm.Parameters.AddWithValue("@MaNhomNgachLuongCoBan", _maNhomNgachLuongCoBan);
            if (_maQL.Length > 0)
                cm.Parameters.AddWithValue("@MaQL", _maQL);
            else
                cm.Parameters.AddWithValue("@MaQL", DBNull.Value);
            if (_tenNhomNgachLuongCoBan.Length > 0)
                cm.Parameters.AddWithValue("@TenNhomNgachLuongCoBan", _tenNhomNgachLuongCoBan);
            else
                cm.Parameters.AddWithValue("@TenNhomNgachLuongCoBan", DBNull.Value);
            if (_dienGiai.Length > 0)
                cm.Parameters.AddWithValue("@DienGiai", _dienGiai);
            else
                cm.Parameters.AddWithValue("@DienGiai", DBNull.Value);
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

            ExecuteDelete(tr, new Criteria(_maNhomNgachLuongCoBan));
            MarkNew();
        }
        #endregion //Data Access - Delete
        #endregion //Data Access
    }

}