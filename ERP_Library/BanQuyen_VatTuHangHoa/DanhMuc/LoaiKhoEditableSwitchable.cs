
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{
    [Serializable()]
    public class LoaiKhoBQ_VT : Csla.BusinessBase<LoaiKhoBQ_VT>
    {
        #region Business Properties and Methods

        //declare members
        private int _maLoaiKho = 0;
        private string _maQuanLy = string.Empty;
        private string _tenLoaiKho = string.Empty;
        private string _dienGiai = string.Empty;
        private bool _tinhTrang = true;

        [System.ComponentModel.DataObjectField(true, true)]
        public int MaLoaiKho
        {
            get
            {
                CanReadProperty("MaLoaiKho", true);
                return _maLoaiKho;
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

        public string TenLoaiKho
        {
            get
            {
                CanReadProperty("TenLoaiKho", true);
                return _tenLoaiKho;
            }
            set
            {
                CanWriteProperty("TenLoaiKho", true);
                if (value == null) value = string.Empty;
                if (!_tenLoaiKho.Equals(value))
                {
                    _tenLoaiKho = value;
                    PropertyHasChanged("TenLoaiKho");
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

        public bool TinhTrang
        {
            get
            {
                CanReadProperty("TinhTrang", true);
                return _tinhTrang;
            }
            set
            {
                CanWriteProperty("TinhTrang", true);
                if (!_tinhTrang.Equals(value))
                {
                    _tinhTrang = value;
                    PropertyHasChanged("TinhTrang");
                }
            }
        }

        protected override object GetIdValue()
        {
            return _maLoaiKho;
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
            ValidationRules.AddRule(CommonRules.StringRequired, "MaQuanLy");
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("MaQuanLy", 20));
            //
            // TenLoaiKho
            //
            ValidationRules.AddRule(CommonRules.StringRequired, "TenLoaiKho");
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("TenLoaiKho", 100));
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
            //TODO: Define authorization rules in LoaiKhoBQ_VT
            //AuthorizationRules.AllowRead("MaLoaiKho", "LoaiKhoBQ_VTReadGroup");
            //AuthorizationRules.AllowRead("MaQuanLy", "LoaiKhoBQ_VTReadGroup");
            //AuthorizationRules.AllowRead("TenLoaiKho", "LoaiKhoBQ_VTReadGroup");
            //AuthorizationRules.AllowRead("DienGiai", "LoaiKhoBQ_VTReadGroup");
            //AuthorizationRules.AllowRead("TinhTrang", "LoaiKhoBQ_VTReadGroup");

            //AuthorizationRules.AllowWrite("MaQuanLy", "LoaiKhoBQ_VTWriteGroup");
            //AuthorizationRules.AllowWrite("TenLoaiKho", "LoaiKhoBQ_VTWriteGroup");
            //AuthorizationRules.AllowWrite("DienGiai", "LoaiKhoBQ_VTWriteGroup");
            //AuthorizationRules.AllowWrite("TinhTrang", "LoaiKhoBQ_VTWriteGroup");
        }


        public static bool CanGetObject()
        {
            //TODO: Define CanGetObject permission in LoaiKhoBQ_VT
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("LoaiKhoBQ_VTViewGroup"))
            //	return true;
            //return false;
        }

        public static bool CanAddObject()
        {
            //TODO: Define CanAddObject permission in LoaiKhoBQ_VT
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("LoaiKhoBQ_VTAddGroup"))
            //	return true;
            //return false;
        }

        public static bool CanEditObject()
        {
            //TODO: Define CanEditObject permission in LoaiKhoBQ_VT
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("LoaiKhoBQ_VTEditGroup"))
            //	return true;
            //return false;
        }

        public static bool CanDeleteObject()
        {
            //TODO: Define CanDeleteObject permission in LoaiKhoBQ_VT
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("LoaiKhoBQ_VTDeleteGroup"))
            //	return true;
            //return false;
        }
        #endregion //Authorization Rules

        #region Factory Methods
        private LoaiKhoBQ_VT()
        { /* require use of factory method */ }

        public static LoaiKhoBQ_VT NewLoaiKhoBQ_VT()
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a LoaiKhoBQ_VT");
            return DataPortal.Create<LoaiKhoBQ_VT>();
        }

        public static LoaiKhoBQ_VT GetLoaiKhoBQ_VT(int maLoaiKho)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a LoaiKhoBQ_VT");
            return DataPortal.Fetch<LoaiKhoBQ_VT>(new Criteria(maLoaiKho));
        }

        public static void DeleteLoaiKhoBQ_VT(int maLoaiKho)
        {
            if (!CanDeleteObject())
                throw new System.Security.SecurityException("User not authorized to remove a LoaiKhoBQ_VT");
            DataPortal.Delete(new Criteria(maLoaiKho));
        }

        public override LoaiKhoBQ_VT Save()
        {
            if (IsDeleted && !CanDeleteObject())
                throw new System.Security.SecurityException("User not authorized to remove a LoaiKhoBQ_VT");
            else if (IsNew && !CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a LoaiKhoBQ_VT");
            else if (!CanEditObject())
                throw new System.Security.SecurityException("User not authorized to update a LoaiKhoBQ_VT");

            return base.Save();
        }

        #endregion //Factory Methods

        #region Child Factory Methods
        internal static LoaiKhoBQ_VT NewLoaiKhoBQ_VTChild()
        {
            LoaiKhoBQ_VT child = new LoaiKhoBQ_VT();
            child.ValidationRules.CheckRules();
            child.MarkAsChild();
            return child;
        }

        internal static LoaiKhoBQ_VT GetLoaiKhoBQ_VT(SafeDataReader dr)
        {
            LoaiKhoBQ_VT child = new LoaiKhoBQ_VT();
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
            public int MaLoaiKho;

            public Criteria(int maLoaiKho)
            {
                this.MaLoaiKho = maLoaiKho;
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
                cm.CommandText = "spd_SelecttblLoaiKho";

                cm.Parameters.AddWithValue("@MaLoaiKho", criteria.MaLoaiKho);

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
            DataPortal_Delete(new Criteria(_maLoaiKho));
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
                cm.CommandText = "spd_DeletetblLoaiKho";

                cm.Parameters.AddWithValue("@MaLoaiKho", criteria.MaLoaiKho);

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
            _maLoaiKho = dr.GetInt32("MaLoaiKho");
            _maQuanLy = dr.GetString("MaQuanLy");
            _tenLoaiKho = dr.GetString("TenLoaiKho");
            _dienGiai = dr.GetString("DienGiai");
            _tinhTrang = dr.GetBoolean("TinhTrang");
        }

        private void FetchChildren(SafeDataReader dr)
        {
        }
        #endregion //Data Access - Fetch

        #region Data Access - Insert
        internal void Insert(SqlTransaction tr, LoaiKhoBQ_VTList parent)
        {
            if (!IsDirty) return;

            ExecuteInsert(tr, parent);
            MarkOld();

            //update child object(s)
            UpdateChildren(tr);
        }

        private void ExecuteInsert(SqlTransaction tr, LoaiKhoBQ_VTList parent)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_InserttblLoaiKho";

                AddInsertParameters(cm, parent);

                cm.ExecuteNonQuery();

                _maLoaiKho = (int)cm.Parameters["@MaLoaiKho"].Value;
            }//using
        }

        private void AddInsertParameters(SqlCommand cm, LoaiKhoBQ_VTList parent)
        {
            //TODO: if parent use identity key, fix fk member with value from parent
            cm.Parameters.AddWithValue("@MaQuanLy", _maQuanLy);
            cm.Parameters.AddWithValue("@TenLoaiKho", _tenLoaiKho);
            if (_dienGiai.Length > 0)
                cm.Parameters.AddWithValue("@DienGiai", _dienGiai);
            else
                cm.Parameters.AddWithValue("@DienGiai", DBNull.Value);
            cm.Parameters.AddWithValue("@TinhTrang", _tinhTrang);
            cm.Parameters.AddWithValue("@MaLoaiKho", _maLoaiKho);
            cm.Parameters["@MaLoaiKho"].Direction = ParameterDirection.Output;
        }
        #endregion //Data Access - Insert

        #region Data Access - Update
        internal void Update(SqlTransaction tr, LoaiKhoBQ_VTList parent)
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

        private void ExecuteUpdate(SqlTransaction tr, LoaiKhoBQ_VTList parent)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_UpdatetblLoaiKho";

                AddUpdateParameters(cm, parent);

                cm.ExecuteNonQuery();

            }//using
        }

        private void AddUpdateParameters(SqlCommand cm, LoaiKhoBQ_VTList parent)
        {
            cm.Parameters.AddWithValue("@MaLoaiKho", _maLoaiKho);
            cm.Parameters.AddWithValue("@MaQuanLy", _maQuanLy);
            cm.Parameters.AddWithValue("@TenLoaiKho", _tenLoaiKho);
            if (_dienGiai.Length > 0)
                cm.Parameters.AddWithValue("@DienGiai", _dienGiai);
            else
                cm.Parameters.AddWithValue("@DienGiai", DBNull.Value);
            cm.Parameters.AddWithValue("@TinhTrang", _tinhTrang);
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

            ExecuteDelete(tr, new Criteria(_maLoaiKho));
            MarkNew();
        }
        #endregion //Data Access - Delete
        #endregion //Data Access
    }
}
