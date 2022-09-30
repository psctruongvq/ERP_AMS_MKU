
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{
    [Serializable()]
    public class NhomNganHang : Csla.BusinessBase<NhomNganHang>
    {
        #region Business Properties and Methods

        //declare members
        private long _maNhomNganHang = 0;
        private string _tenNhomNganHang = string.Empty;
        private string _maUNCNganHang = string.Empty;
        private string _chuVietTat = string.Empty;
        private long _soUNCBatDau = 0;

        [System.ComponentModel.DataObjectField(true, true)]
        public long MaNhomNganHang
        {
            get
            {
                CanReadProperty("MaNhomNganHang", true);
                return _maNhomNganHang;
            }
        }

        public string TenNhomNganHang
        {
            get
            {
                CanReadProperty("TenNhomNganHang", true);
                return _tenNhomNganHang;
            }
            set
            {
                CanWriteProperty("TenNhomNganHang", true);
                if (value == null) value = string.Empty;
                if (!_tenNhomNganHang.Equals(value))
                {
                    _tenNhomNganHang = value;
                    PropertyHasChanged("TenNhomNganHang");
                }
            }
        }

        public string MaUNCNganHang
        {
            get
            {
                CanReadProperty("MaUNCNganHang", true);
                return _maUNCNganHang;
            }
            set
            {
                CanWriteProperty("MaUNCNganHang", true);
                if (value == null) value = string.Empty;
                if (!_maUNCNganHang.Equals(value))
                {
                    _maUNCNganHang = value;
                    PropertyHasChanged("MaUNCNganHang");
                }
            }
        }

        public string ChuVietTat
        {
            get
            {
                CanReadProperty("ChuVietTat", true);
                return _chuVietTat;
            }
            set
            {
                CanWriteProperty("ChuVietTat", true);
                if (value == null) value = string.Empty;
                if (!_chuVietTat.Equals(value))
                {
                    _chuVietTat = value;
                    PropertyHasChanged("ChuVietTat");
                }
            }
        }

        public long SoUNCBatDau
        {
            get
            {
                CanReadProperty("SoUNCBatDau", true);
                return _soUNCBatDau;
            }
            set
            {
                CanWriteProperty("SoUNCBatDau", true);
                if (!_soUNCBatDau.Equals(value))
                {
                    _soUNCBatDau = value;
                    PropertyHasChanged("SoUNCBatDau");
                }
            }
        }

        protected override object GetIdValue()
        {
            return _maNhomNganHang;
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
            // TenNhomNganHang
            //
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("TenNhomNganHang", 500));
            //
            // MaUNCNganHang
            //
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("MaUNCNganHang", 50));
            //
            // ChuVietTat
            //
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("ChuVietTat", 50));
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
            //TODO: Define authorization rules in NhomNganHang
            //AuthorizationRules.AllowRead("MaNhomNganHang", "NhomNganHangReadGroup");
            //AuthorizationRules.AllowRead("TenNhomNganHang", "NhomNganHangReadGroup");
            //AuthorizationRules.AllowRead("MaUNCNganHang", "NhomNganHangReadGroup");
            //AuthorizationRules.AllowRead("ChuVietTat", "NhomNganHangReadGroup");
            //AuthorizationRules.AllowRead("SoUNCBatDau", "NhomNganHangReadGroup");

            //AuthorizationRules.AllowWrite("TenNhomNganHang", "NhomNganHangWriteGroup");
            //AuthorizationRules.AllowWrite("MaUNCNganHang", "NhomNganHangWriteGroup");
            //AuthorizationRules.AllowWrite("ChuVietTat", "NhomNganHangWriteGroup");
            //AuthorizationRules.AllowWrite("SoUNCBatDau", "NhomNganHangWriteGroup");
        }


        public static bool CanGetObject()
        {
            //TODO: Define CanGetObject permission in NhomNganHang
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("NhomNganHangViewGroup"))
            //	return true;
            //return false;
        }

        public static bool CanAddObject()
        {
            //TODO: Define CanAddObject permission in NhomNganHang
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("NhomNganHangAddGroup"))
            //	return true;
            //return false;
        }

        public static bool CanEditObject()
        {
            //TODO: Define CanEditObject permission in NhomNganHang
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("NhomNganHangEditGroup"))
            //	return true;
            //return false;
        }

        public static bool CanDeleteObject()
        {
            //TODO: Define CanDeleteObject permission in NhomNganHang
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("NhomNganHangDeleteGroup"))
            //	return true;
            //return false;
        }
        #endregion //Authorization Rules

        #region Factory Methods
        private NhomNganHang()
        { 
            /* require use of factory method */ 
            MarkAsChild();
        }

        public static NhomNganHang NewNhomNganHang()
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a NhomNganHang");
            return DataPortal.Create<NhomNganHang>();
        }

        public static NhomNganHang NewNhomNganHang(string tenNhom)
        {
            return new NhomNganHang(tenNhom);
        }

        public static NhomNganHang GetNhomNganHang(long maNhomNganHang)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a NhomNganHang");
            return DataPortal.Fetch<NhomNganHang>(new Criteria(maNhomNganHang));
        }

        public static void DeleteNhomNganHang(long maNhomNganHang)
        {
            if (!CanDeleteObject())
                throw new System.Security.SecurityException("User not authorized to remove a NhomNganHang");
            DataPortal.Delete(new Criteria(maNhomNganHang));
        }

        public override NhomNganHang Save()
        {
            if (IsDeleted && !CanDeleteObject())
                throw new System.Security.SecurityException("User not authorized to remove a NhomNganHang");
            else if (IsNew && !CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a NhomNganHang");
            else if (!CanEditObject())
                throw new System.Security.SecurityException("User not authorized to update a NhomNganHang");

            return base.Save();
        }

        #endregion //Factory Methods

        #region Child Factory Methods
        internal static NhomNganHang NewNhomNganHangChild()
        {
            NhomNganHang child = new NhomNganHang();
            child.ValidationRules.CheckRules();
            child.MarkAsChild();
            return child;
        }

        internal static NhomNganHang GetNhomNganHang(SafeDataReader dr)
        {
            NhomNganHang child = new NhomNganHang();
            child.MarkAsChild();
            child.Fetch(dr);
            return child;
        }

        private NhomNganHang(string TenNhomNganHang)
        {
            this.TenNhomNganHang = TenNhomNganHang;
            MarkAsChild();
        }
        #endregion //Child Factory Methods

        #region Data Access

        #region Criteria

        [Serializable()]
        private class Criteria
        {
            public long MaNhomNganHang;

            public Criteria(long maNhomNganHang)
            {
                this.MaNhomNganHang = maNhomNganHang;
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
                cm.CommandText = "spd_SelecttblnsNhomNganHang";

                cm.Parameters.AddWithValue("@MaNhomNganHang", criteria.MaNhomNganHang);

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
            DataPortal_Delete(new Criteria(_maNhomNganHang));
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
                cm.CommandText = "spd_DeletetblnsNhomNganHang";

                cm.Parameters.AddWithValue("@MaNhomNganHang", criteria.MaNhomNganHang);

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
            _maNhomNganHang = dr.GetInt64("MaNhomNganHang");
            _tenNhomNganHang = dr.GetString("TenNhomNganHang");
            _maUNCNganHang = dr.GetString("MaUNCNganHang");
            _chuVietTat = dr.GetString("ChuVietTat");
            _soUNCBatDau = dr.GetInt64("SoUNCBatDau");
        }

        private void FetchChildren(SafeDataReader dr)
        {
        }
        #endregion //Data Access - Fetch

        #region Data Access - Insert
        internal void Insert(SqlTransaction tr, NhomNganHangList parent)
        {
            if (!IsDirty) return;

            ExecuteInsert(tr, parent);
            MarkOld();

            //update child object(s)
            UpdateChildren(tr);
        }

        private void ExecuteInsert(SqlTransaction tr, NhomNganHangList parent)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_InserttblnsNhomNganHang";

                AddInsertParameters(cm, parent);

                cm.ExecuteNonQuery();

                _maNhomNganHang = (long)cm.Parameters["@MaNhomNganHang"].Value;
            }//using
        }

        private void AddInsertParameters(SqlCommand cm, NhomNganHangList parent)
        {
            //TODO: if parent use identity key, fix fk member with value from parent
            if (_tenNhomNganHang.Length > 0)
                cm.Parameters.AddWithValue("@TenNhomNganHang", _tenNhomNganHang);
            else
                cm.Parameters.AddWithValue("@TenNhomNganHang", DBNull.Value);
            if (_maUNCNganHang.Length > 0)
                cm.Parameters.AddWithValue("@MaUNCNganHang", _maUNCNganHang);
            else
                cm.Parameters.AddWithValue("@MaUNCNganHang", DBNull.Value);
            if (_chuVietTat.Length > 0)
                cm.Parameters.AddWithValue("@ChuVietTat", _chuVietTat);
            else
                cm.Parameters.AddWithValue("@ChuVietTat", DBNull.Value);
            if (_soUNCBatDau != 0)
                cm.Parameters.AddWithValue("@SoUNCBatDau", _soUNCBatDau);
            else
                cm.Parameters.AddWithValue("@SoUNCBatDau", DBNull.Value);
            cm.Parameters.AddWithValue("@MaNhomNganHang", _maNhomNganHang);
            cm.Parameters["@MaNhomNganHang"].Direction = ParameterDirection.Output;
        }
        #endregion //Data Access - Insert

        #region Data Access - Update
        internal void Update(SqlTransaction tr, NhomNganHangList parent)
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

        private void ExecuteUpdate(SqlTransaction tr, NhomNganHangList parent)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_UpdatetblnsNhomNganHang";

                AddUpdateParameters(cm, parent);

                cm.ExecuteNonQuery();

            }//using
        }

        private void AddUpdateParameters(SqlCommand cm, NhomNganHangList parent)
        {
            cm.Parameters.AddWithValue("@MaNhomNganHang", _maNhomNganHang);
            if (_tenNhomNganHang.Length > 0)
                cm.Parameters.AddWithValue("@TenNhomNganHang", _tenNhomNganHang);
            else
                cm.Parameters.AddWithValue("@TenNhomNganHang", DBNull.Value);
            if (_maUNCNganHang.Length > 0)
                cm.Parameters.AddWithValue("@MaUNCNganHang", _maUNCNganHang);
            else
                cm.Parameters.AddWithValue("@MaUNCNganHang", DBNull.Value);
            if (_chuVietTat.Length > 0)
                cm.Parameters.AddWithValue("@ChuVietTat", _chuVietTat);
            else
                cm.Parameters.AddWithValue("@ChuVietTat", DBNull.Value);
            if (_soUNCBatDau != 0)
                cm.Parameters.AddWithValue("@SoUNCBatDau", _soUNCBatDau);
            else
                cm.Parameters.AddWithValue("@SoUNCBatDau", DBNull.Value);
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

            ExecuteDelete(tr, new Criteria(_maNhomNganHang));
            MarkNew();
        }
        #endregion //Data Access - Delete
        #endregion //Data Access
    }
}








