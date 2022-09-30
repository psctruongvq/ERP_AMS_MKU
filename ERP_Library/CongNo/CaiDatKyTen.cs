
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{
    [Serializable()]
    public class CaiDatKyTen : Csla.BusinessBase<CaiDatKyTen>
    {
        #region Business Properties and Methods

        //declare members
        private int _maKyTenCN = 0;
        private string _tenThuTruong = string.Empty;
        private string _tenKTTTruong = string.Empty;
        private string _tenThuQuy = string.Empty;
        private string _nhanThuTruong = string.Empty;
        private string _nhanKTTruong = string.Empty;
        private string _nhanNguoiLap = string.Empty;
        private string _nhanThuQuy = string.Empty;
        private string _tenNguoiLap = string.Empty;
        private int _MaUserID = 0;
        [System.ComponentModel.DataObjectField(true, true)]
        public int MaKyTenCN
        {
            get
            {
                CanReadProperty("MaKyTenCN", true);
                return _maKyTenCN;
            }
        }

        public string TenThuTruong
        {
            get
            {
                CanReadProperty("TenThuTruong", true);
                return _tenThuTruong;
            }
            set
            {
                CanWriteProperty("TenThuTruong", true);
                if (value == null) value = string.Empty;
                if (!_tenThuTruong.Equals(value))
                {
                    _tenThuTruong = value;
                    PropertyHasChanged("TenThuTruong");
                }
            }
        }

        public string TenKTTTruong
        {
            get
            {
                CanReadProperty("TenKTTTruong", true);
                return _tenKTTTruong;
            }
            set
            {
                CanWriteProperty("TenKTTTruong", true);
                if (value == null) value = string.Empty;
                if (!_tenKTTTruong.Equals(value))
                {
                    _tenKTTTruong = value;
                    PropertyHasChanged("TenKTTTruong");
                }
            }
        }

        public string TenThuQuy
        {
            get
            {
                CanReadProperty("TenThuQuy", true);
                return _tenThuQuy;
            }
            set
            {
                CanWriteProperty("TenThuQuy", true);
                if (value == null) value = string.Empty;
                if (!_tenThuQuy.Equals(value))
                {
                    _tenThuQuy = value;
                    PropertyHasChanged("TenThuQuy");
                }
            }
        }

        public string NhanThuTruong
        {
            get
            {
                CanReadProperty("NhanThuTruong", true);
                return _nhanThuTruong;
            }
            set
            {
                CanWriteProperty("NhanThuTruong", true);
                if (value == null) value = string.Empty;
                if (!_nhanThuTruong.Equals(value))
                {
                    _nhanThuTruong = value;
                    PropertyHasChanged("NhanThuTruong");
                }
            }
        }

        public string NhanKTTruong
        {
            get
            {
                CanReadProperty("NhanKTTruong", true);
                return _nhanKTTruong;
            }
            set
            {
                CanWriteProperty("NhanKTTruong", true);
                if (value == null) value = string.Empty;
                if (!_nhanKTTruong.Equals(value))
                {
                    _nhanKTTruong = value;
                    PropertyHasChanged("NhanKTTruong");
                }
            }
        }

        public string NhanNguoiLap
        {
            get
            {
                CanReadProperty("NhanNguoiLap", true);
                return _nhanNguoiLap;
            }
            set
            {
                CanWriteProperty("NhanNguoiLap", true);
                if (value == null) value = string.Empty;
                if (!_nhanNguoiLap.Equals(value))
                {
                    _nhanNguoiLap = value;
                    PropertyHasChanged("NhanNguoiLap");
                }
            }
        }

        public string NhanThuQuy
        {
            get
            {
                CanReadProperty("NhanThuQuy", true);
                return _nhanThuQuy;
            }
            set
            {
                CanWriteProperty("NhanThuQuy", true);
                if (value == null) value = string.Empty;
                if (!_nhanThuQuy.Equals(value))
                {
                    _nhanThuQuy = value;
                    PropertyHasChanged("NhanThuQuy");
                }
            }
        }
        public string TenNguoiLap
        {
            get
            {
                CanReadProperty("TenNguoiLap", true);
                return _tenNguoiLap;
            }
            //set
            //{
            //    CanWriteProperty("TenNguoiLap", true);
            //    if (value == null) value = string.Empty;
            //    if (!_nhanThuQuy.Equals(value))
            //    {
            //        _nhanThuQuy = value;
            //        PropertyHasChanged("TenNguoiLap");
            //    }
            //}
        }
        public int MaUserID
        {
            get
            {
                CanReadProperty("MaUserID", true);
                return _MaUserID;
            }
            set
            {
                CanWriteProperty("MaUserID", true);
                if (!_MaUserID.Equals(value))
                {
                    _MaUserID = value;
                    PropertyHasChanged("MaUserID");
                }
            }
        }
        protected override object GetIdValue()
        {
            return _maKyTenCN;
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
            // TenThuTruong
            //
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("TenThuTruong", 50));
            //
            // TenKTTTruong
            //
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("TenKTTTruong", 50));
            //
            // TenThuQuy
            //
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("TenThuQuy", 50));
            //
            // NhanThuTruong
            //
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("NhanThuTruong", 50));
            //
            // NhanKTTruong
            //
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("NhanKTTruong", 50));
            //
            // NhanNguoiLap
            //
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("NhanNguoiLap", 50));
            //
            // NhanThuQuy
            //
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("NhanThuQuy", 50));
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
            //TODO: Define authorization rules in CaiDatKyTen
            //AuthorizationRules.AllowRead("MaKyTenCN", "CaiDatKyTenReadGroup");
            //AuthorizationRules.AllowRead("TenThuTruong", "CaiDatKyTenReadGroup");
            //AuthorizationRules.AllowRead("TenKTTTruong", "CaiDatKyTenReadGroup");
            //AuthorizationRules.AllowRead("TenThuQuy", "CaiDatKyTenReadGroup");
            //AuthorizationRules.AllowRead("NhanThuTruong", "CaiDatKyTenReadGroup");
            //AuthorizationRules.AllowRead("NhanKTTruong", "CaiDatKyTenReadGroup");
            //AuthorizationRules.AllowRead("NhanNguoiLap", "CaiDatKyTenReadGroup");
            //AuthorizationRules.AllowRead("NhanThuQuy", "CaiDatKyTenReadGroup");

            //AuthorizationRules.AllowWrite("TenThuTruong", "CaiDatKyTenWriteGroup");
            //AuthorizationRules.AllowWrite("TenKTTTruong", "CaiDatKyTenWriteGroup");
            //AuthorizationRules.AllowWrite("TenThuQuy", "CaiDatKyTenWriteGroup");
            //AuthorizationRules.AllowWrite("NhanThuTruong", "CaiDatKyTenWriteGroup");
            //AuthorizationRules.AllowWrite("NhanKTTruong", "CaiDatKyTenWriteGroup");
            //AuthorizationRules.AllowWrite("NhanNguoiLap", "CaiDatKyTenWriteGroup");
            //AuthorizationRules.AllowWrite("NhanThuQuy", "CaiDatKyTenWriteGroup");
        }


        public static bool CanGetObject()
        {
            //TODO: Define CanGetObject permission in CaiDatKyTen
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("CaiDatKyTenViewGroup"))
            //	return true;
            //return false;
        }

        public static bool CanAddObject()
        {
            //TODO: Define CanAddObject permission in CaiDatKyTen
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("CaiDatKyTenAddGroup"))
            //	return true;
            //return false;
        }

        public static bool CanEditObject()
        {
            //TODO: Define CanEditObject permission in CaiDatKyTen
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("CaiDatKyTenEditGroup"))
            //	return true;
            //return false;
        }

        public static bool CanDeleteObject()
        {
            //TODO: Define CanDeleteObject permission in CaiDatKyTen
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("CaiDatKyTenDeleteGroup"))
            //	return true;
            //return false;
        }
        #endregion //Authorization Rules

        #region Factory Methods
        private CaiDatKyTen()
        { /* require use of factory method */ }

        public static CaiDatKyTen NewCaiDatKyTen()
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a CaiDatKyTen");
            return DataPortal.Create<CaiDatKyTen>();
        }

        public static CaiDatKyTen GetCaiDatKyTen(int c)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a CaiDatKyTen");
            return DataPortal.Fetch<CaiDatKyTen>(new Criteria( c));
        }

        public static void DeleteCaiDatKyTen(int maKyTenCN)
        {
            if (!CanDeleteObject())
                throw new System.Security.SecurityException("User not authorized to remove a CaiDatKyTen");
            DataPortal.Delete(new Criteria(maKyTenCN));
        }

        public override CaiDatKyTen Save()
        {
            if (IsDeleted && !CanDeleteObject())
                throw new System.Security.SecurityException("User not authorized to remove a CaiDatKyTen");
            else if (IsNew && !CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a CaiDatKyTen");
            else if (!CanEditObject())
                throw new System.Security.SecurityException("User not authorized to update a CaiDatKyTen");

            return base.Save();
        }

        #endregion //Factory Methods

        #region Child Factory Methods
        internal static CaiDatKyTen NewCaiDatKyTenChild()
        {
            CaiDatKyTen child = new CaiDatKyTen();
            child.ValidationRules.CheckRules();
            child.MarkAsChild();
            return child;
        }

        internal static CaiDatKyTen GetCaiDatKyTen(SafeDataReader dr)
        {
            CaiDatKyTen child = new CaiDatKyTen();
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
            public int c;
            public Criteria(int _c)
            {
                this.c = _c;
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
                cm.CommandText = "sp_SelecttblcnKyTen";

              //  cm.Parameters.AddWithValue("@MaKyTenCN", criteria.MaKyTenCN);
                cm.Parameters.AddWithValue("@MaNguoiLap", ERP_Library.Security.CurrentUser.Info.UserID);
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

        public void Insert() // ham viet moi
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
            DataPortal_Delete(new Criteria(_maKyTenCN));
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
                cm.CommandText = "DeleteCaiDatKyTen";

                cm.Parameters.AddWithValue("@MaKyTenCN", criteria.c);

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
            
            _maKyTenCN = dr.GetInt32("MaKyTenCN");
            _tenThuTruong = dr.GetString("TenThuTruong");
            _tenKTTTruong = dr.GetString("TenKTTTruong");
            _tenThuQuy = dr.GetString("TenThuQuy");
            _nhanThuTruong = dr.GetString("NhanThuTruong");
            _nhanKTTruong = dr.GetString("NhanKTTruong");
            _nhanNguoiLap = dr.GetString("NhanNguoiLap");
            _nhanThuQuy = dr.GetString("NhanThuQuy");
            _tenNguoiLap = dr.GetString("TenNguoiLap");
            _MaUserID = dr.GetInt32("MaUserID");
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
                cm.CommandText = "sp_InserttblcnKyTen";

                AddInsertParameters(cm);

                cm.ExecuteNonQuery();

                _maKyTenCN = (int)cm.Parameters["@MaKyTenCN"].Value;
            }//using
        }

        private void AddInsertParameters(SqlCommand cm)
        {
            if (_tenThuTruong.Length > 0)
                cm.Parameters.AddWithValue("@TenThuTruong", _tenThuTruong);
            else
                cm.Parameters.AddWithValue("@TenThuTruong", DBNull.Value);
            if (_tenKTTTruong.Length > 0)
                cm.Parameters.AddWithValue("@TenKTTTruong", _tenKTTTruong);
            else
                cm.Parameters.AddWithValue("@TenKTTTruong", DBNull.Value);
            if (_tenThuQuy.Length > 0)
                cm.Parameters.AddWithValue("@TenThuQuy", _tenThuQuy);
            else
                cm.Parameters.AddWithValue("@TenThuQuy", DBNull.Value);
            if (_nhanThuTruong.Length > 0)
                cm.Parameters.AddWithValue("@NhanThuTruong", _nhanThuTruong);
            else
                cm.Parameters.AddWithValue("@NhanThuTruong", DBNull.Value);
            if (_nhanKTTruong.Length > 0)
                cm.Parameters.AddWithValue("@NhanKTTruong", _nhanKTTruong);
            else
                cm.Parameters.AddWithValue("@NhanKTTruong", DBNull.Value);
            if (_nhanNguoiLap.Length > 0)
                cm.Parameters.AddWithValue("@NhanNguoiLap", _nhanNguoiLap);
            else
                cm.Parameters.AddWithValue("@NhanNguoiLap", DBNull.Value);
            if (_nhanThuQuy.Length > 0)
                cm.Parameters.AddWithValue("@NhanThuQuy", _nhanThuQuy);
            else
                cm.Parameters.AddWithValue("@NhanThuQuy", DBNull.Value);
            _MaUserID = ERP_Library.Security.CurrentUser.Info.UserID;
            cm.Parameters.AddWithValue("MaUserID", _MaUserID);
            cm.Parameters.AddWithValue("@MaKyTenCN", _maKyTenCN);
            cm.Parameters["@MaKyTenCN"].Direction = ParameterDirection.Output;
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
                cm.CommandText = "sp_UpdatetblcnKyTen";

                AddUpdateParameters(cm);

                cm.ExecuteNonQuery();

            }//using
        }
        public void DataPortal_UpDate()
        {
           

            SqlTransaction tr;

            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();

                tr = cn.BeginTransaction();
                try
                {
                    ExecuteUpdate(tr);
                    tr.Commit();
                }
                catch
                {
                    tr.Rollback();
                    throw;
                }
            }//using SqlConnection

          
        }
        private void AddUpdateParameters(SqlCommand cm)
        {
            cm.Parameters.AddWithValue("@MaKyTenCN", _maKyTenCN);
            cm.Parameters.AddWithValue("@MaUserID", _MaUserID);
            if (_tenThuTruong.Length > 0)
                cm.Parameters.AddWithValue("@TenThuTruong", _tenThuTruong);
            else
                cm.Parameters.AddWithValue("@TenThuTruong", DBNull.Value);
            if (_tenKTTTruong.Length > 0)
                cm.Parameters.AddWithValue("@TenKTTTruong", _tenKTTTruong);
            else
                cm.Parameters.AddWithValue("@TenKTTTruong", DBNull.Value);
            if (_tenThuQuy.Length > 0)
                cm.Parameters.AddWithValue("@TenThuQuy", _tenThuQuy);
            else
                cm.Parameters.AddWithValue("@TenThuQuy", DBNull.Value);
            if (_nhanThuTruong.Length > 0)
                cm.Parameters.AddWithValue("@NhanThuTruong", _nhanThuTruong);
            else
                cm.Parameters.AddWithValue("@NhanThuTruong", DBNull.Value);
            if (_nhanKTTruong.Length > 0)
                cm.Parameters.AddWithValue("@NhanKTTruong", _nhanKTTruong);
            else
                cm.Parameters.AddWithValue("@NhanKTTruong", DBNull.Value);
            if (_nhanNguoiLap.Length > 0)
                cm.Parameters.AddWithValue("@NhanNguoiLap", _nhanNguoiLap);
            else
                cm.Parameters.AddWithValue("@NhanNguoiLap", DBNull.Value);
            if (_nhanThuQuy.Length > 0)
                cm.Parameters.AddWithValue("@NhanThuQuy", _nhanThuQuy);
            else
                cm.Parameters.AddWithValue("@NhanThuQuy", DBNull.Value);
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

            ExecuteDelete(tr, new Criteria(_maKyTenCN));
            MarkNew();
        }
        #endregion //Data Access - Delete
        #endregion //Data Access
    }
}
