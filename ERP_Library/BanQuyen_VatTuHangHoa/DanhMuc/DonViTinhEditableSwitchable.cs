
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{
    [Serializable()]
    public class DonViTinhBQ_VT : Csla.BusinessBase<DonViTinhBQ_VT>
    {
        #region Business Properties and Methods

        //declare members
        private int _maDonViTinh = 0;
        private string _maQuanLy = string.Empty;
        private string _tenDonViTinh = string.Empty;
        private string _dienGiai = string.Empty;
        private bool _maTinhTrang = true;

        [System.ComponentModel.DataObjectField(true, true)]
        public int MaDonViTinh
        {
            get
            {
                CanReadProperty("MaDonViTinh", true);
                return _maDonViTinh;
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

        public string TenDonViTinh
        {
            get
            {
                CanReadProperty("TenDonViTinh", true);
                return _tenDonViTinh;
            }
            set
            {
                CanWriteProperty("TenDonViTinh", true);
                if (value == null) value = string.Empty;
                if (!_tenDonViTinh.Equals(value))
                {
                    _tenDonViTinh = value;
                    PropertyHasChanged("TenDonViTinh");
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

        public bool MaTinhTrang
        {
            get
            {
                CanReadProperty("MaTinhTrang", true);
                return _maTinhTrang;
            }
            set
            {
                CanWriteProperty("MaTinhTrang", true);
                if (!_maTinhTrang.Equals(value))
                {
                    _maTinhTrang = value;
                    PropertyHasChanged("MaTinhTrang");
                }
            }
        }

        protected override object GetIdValue()
        {
            return _maDonViTinh;
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
            // TenDonViTinh
            //
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("TenDonViTinh", 100));
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
            //TODO: Define authorization rules in DonViTinhBQ_VT
            //AuthorizationRules.AllowRead("MaDonViTinh", "DonViTinhBQ_VTReadGroup");
            //AuthorizationRules.AllowRead("MaQuanLy", "DonViTinhBQ_VTReadGroup");
            //AuthorizationRules.AllowRead("TenDonViTinh", "DonViTinhBQ_VTReadGroup");
            //AuthorizationRules.AllowRead("DienGiai", "DonViTinhBQ_VTReadGroup");
            //AuthorizationRules.AllowRead("MaTinhTrang", "DonViTinhBQ_VTReadGroup");

            //AuthorizationRules.AllowWrite("MaQuanLy", "DonViTinhBQ_VTWriteGroup");
            //AuthorizationRules.AllowWrite("TenDonViTinh", "DonViTinhBQ_VTWriteGroup");
            //AuthorizationRules.AllowWrite("DienGiai", "DonViTinhBQ_VTWriteGroup");
            //AuthorizationRules.AllowWrite("MaTinhTrang", "DonViTinhBQ_VTWriteGroup");
        }


        public static bool CanGetObject()
        {
            //TODO: Define CanGetObject permission in DonViTinhBQ_VT
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("DonViTinhBQ_VTViewGroup"))
            //	return true;
            //return false;
        }

        public static bool CanAddObject()
        {
            //TODO: Define CanAddObject permission in DonViTinhBQ_VT
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("DonViTinhBQ_VTAddGroup"))
            //	return true;
            //return false;
        }

        public static bool CanEditObject()
        {
            //TODO: Define CanEditObject permission in DonViTinhBQ_VT
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("DonViTinhBQ_VTEditGroup"))
            //	return true;
            //return false;
        }

        public static bool CanDeleteObject()
        {
            //TODO: Define CanDeleteObject permission in DonViTinhBQ_VT
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("DonViTinhBQ_VTDeleteGroup"))
            //	return true;
            //return false;
        }
        #endregion //Authorization Rules

        #region Factory Methods
        private DonViTinhBQ_VT()
        { /* require use of factory method */ }

        public static DonViTinhBQ_VT NewDonViTinhBQ_VT()
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a DonViTinhBQ_VT");
            return DataPortal.Create<DonViTinhBQ_VT>();
        }

        public static DonViTinhBQ_VT GetDonViTinhBQ_VT(int maDonViTinh)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a DonViTinhBQ_VT");
            return DataPortal.Fetch<DonViTinhBQ_VT>(new Criteria(maDonViTinh));
        }

        public static DonViTinhBQ_VT GetDonViTinhBQ_VT(string tenDonViTinh)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a DonViTinhBQ_VT");
            return DataPortal.Fetch<DonViTinhBQ_VT>(new Criteria_TenDonViTinh(tenDonViTinh));
        }

        public static void DeleteDonViTinhBQ_VT(int maDonViTinh)
        {
            if (!CanDeleteObject())
                throw new System.Security.SecurityException("User not authorized to remove a DonViTinhBQ_VT");
            DataPortal.Delete(new Criteria(maDonViTinh));
        }

        public override DonViTinhBQ_VT Save()
        {
            if (IsDeleted && !CanDeleteObject())
                throw new System.Security.SecurityException("User not authorized to remove a DonViTinhBQ_VT");
            else if (IsNew && !CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a DonViTinhBQ_VT");
            else if (!CanEditObject())
                throw new System.Security.SecurityException("User not authorized to update a DonViTinhBQ_VT");

            return base.Save();
        }

        #endregion //Factory Methods

        #region Child Factory Methods
        internal static DonViTinhBQ_VT NewDonViTinhBQ_VTChild()
        {
            DonViTinhBQ_VT child = new DonViTinhBQ_VT();
            child.ValidationRules.CheckRules();
            child.MarkAsChild();
            return child;
        }

        internal static DonViTinhBQ_VT GetDonViTinhBQ_VT(SafeDataReader dr)
        {
            DonViTinhBQ_VT child = new DonViTinhBQ_VT();
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
            public int MaDonViTinh;

            public Criteria(int maDonViTinh)
            {
                this.MaDonViTinh = maDonViTinh;
            }
        }

        [Serializable()]
        private class Criteria_TenDonViTinh
        {
            public string TenDonViTinh;

            public Criteria_TenDonViTinh(string tenDonViTinh)
            {
                this.TenDonViTinh = tenDonViTinh;
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
        private void DataPortal_Fetch(object criteria)
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

        private void ExecuteFetch(SqlTransaction tr, object criteria) //Thang
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                if (criteria is Criteria)
                {
                    cm.CommandText = "spd_SelecttblDonViTinh";
                    cm.Parameters.AddWithValue("@MaDonViTinh", ((Criteria)criteria).MaDonViTinh);
                }                
                if(criteria is Criteria_TenDonViTinh)
                {
                    cm.CommandText = "spd_SelecttblDonViTinh_TenDonViTinh";
                    cm.Parameters.AddWithValue("@TenDonViTinh", ((Criteria_TenDonViTinh)criteria).TenDonViTinh);
                }

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
            DataPortal_Delete(new Criteria(_maDonViTinh));
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
                cm.CommandText = "spd_DeletetblDonViTinh";

                cm.Parameters.AddWithValue("@MaDonViTinh", criteria.MaDonViTinh);

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
            _maDonViTinh = dr.GetInt32("MaDonViTinh");
            _maQuanLy = dr.GetString("MaQuanLy");
            _tenDonViTinh = dr.GetString("TenDonViTinh");
            _dienGiai = dr.GetString("DienGiai");
            _maTinhTrang = dr.GetBoolean("MaTinhTrang");
        }

        private void FetchChildren(SafeDataReader dr)
        {
        }
        #endregion //Data Access - Fetch

        #region Data Access - Insert
        internal void Insert(SqlTransaction tr, DonViTinhBQ_VTList parent)
        {
            if (!IsDirty) return;

            ExecuteInsert(tr, parent);
            MarkOld();

            //update child object(s)
            UpdateChildren(tr);
        }

        private void ExecuteInsert(SqlTransaction tr, DonViTinhBQ_VTList parent)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_InserttblDonViTinh";

                AddInsertParameters(cm, parent);

                cm.ExecuteNonQuery();

                _maDonViTinh = (int)cm.Parameters["@MaDonViTinh"].Value;
            }//using
        }

        private void AddInsertParameters(SqlCommand cm, DonViTinhBQ_VTList parent)
        {
            //TODO: if parent use identity key, fix fk member with value from parent
            cm.Parameters.AddWithValue("@MaQuanLy", _maQuanLy);
            if (_tenDonViTinh.Length > 0)
                cm.Parameters.AddWithValue("@TenDonViTinh", _tenDonViTinh);
            else
                cm.Parameters.AddWithValue("@TenDonViTinh", DBNull.Value);
            if (_dienGiai.Length > 0)
                cm.Parameters.AddWithValue("@DienGiai", _dienGiai);
            else
                cm.Parameters.AddWithValue("@DienGiai", DBNull.Value);
            cm.Parameters.AddWithValue("@MaTinhTrang", _maTinhTrang);
            cm.Parameters.AddWithValue("@MaDonViTinh", _maDonViTinh);
            cm.Parameters["@MaDonViTinh"].Direction = ParameterDirection.Output;
        }
        #endregion //Data Access - Insert

        #region Data Access - Update
        internal void Update(SqlTransaction tr, DonViTinhBQ_VTList parent)
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

        private void ExecuteUpdate(SqlTransaction tr, DonViTinhBQ_VTList parent)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_UpdatetblDonViTinh";

                AddUpdateParameters(cm, parent);

                cm.ExecuteNonQuery();

            }//using
        }

        private void AddUpdateParameters(SqlCommand cm, DonViTinhBQ_VTList parent)
        {
            cm.Parameters.AddWithValue("@MaDonViTinh", _maDonViTinh);
            cm.Parameters.AddWithValue("@MaQuanLy", _maQuanLy);
            if (_tenDonViTinh.Length > 0)
                cm.Parameters.AddWithValue("@TenDonViTinh", _tenDonViTinh);
            else
                cm.Parameters.AddWithValue("@TenDonViTinh", DBNull.Value);
            if (_dienGiai.Length > 0)
                cm.Parameters.AddWithValue("@DienGiai", _dienGiai);
            else
                cm.Parameters.AddWithValue("@DienGiai", DBNull.Value);
            cm.Parameters.AddWithValue("@MaTinhTrang", _maTinhTrang);
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

            ExecuteDelete(tr, new Criteria(_maDonViTinh));
            MarkNew();
        }
        #endregion //Data Access - Delete
        #endregion //Data Access
    }
}
