
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{
    [Serializable()]
    public class DaoTaoNgoai : Csla.BusinessBase<DaoTaoNgoai>
    {
        #region Business Properties and Methods

        //declare members
        private int _maDTNgoai = 0;
        private string _maQL = string.Empty;
        private string _tenChuongTrinh = string.Empty;
        private DateTime _tuNgay = DateTime.Today;
        private DateTime _denNgay = DateTime.Today;
        private decimal _hocPhi = 0;
        private string _ghiChu = string.Empty;

        //declare child member(s)
        private DaoTaoNgoai_ChiTietList _chiTiet = DaoTaoNgoai_ChiTietList.NewDaoTaoNgoai_ChiTietList();

        [System.ComponentModel.DataObjectField(true, true)]
        public int MaDTNgoai
        {
            get
            {
                CanReadProperty("MaDTNgoai", true);
                return _maDTNgoai;
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

        public string TenChuongTrinh
        {
            get
            {
                CanReadProperty("TenChuongTrinh", true);
                return _tenChuongTrinh;
            }
            set
            {
                CanWriteProperty("TenChuongTrinh", true);
                if (value == null) value = string.Empty;
                if (!_tenChuongTrinh.Equals(value))
                {
                    _tenChuongTrinh = value;
                    PropertyHasChanged("TenChuongTrinh");
                }
            }
        }

        public DateTime TuNgay
        {
            get
            {
                CanReadProperty("TuNgay", true);
                return _tuNgay;
            }
            set
            {
                CanWriteProperty("TuNgay", true);
                if (!_tuNgay.Equals(value))
                {
                    _tuNgay = value;
                    PropertyHasChanged("TuNgay");
                }
            }
        }

        public DateTime DenNgay
        {
            get
            {
                CanReadProperty("DenNgay", true);
                return _denNgay;
            }
            set
            {
                CanWriteProperty("DenNgay", true);
                if (!_denNgay.Equals(value))
                {
                    _denNgay = value;
                    PropertyHasChanged("DenNgay");
                }
            }
        }

        public decimal HocPhi
        {
            get
            {
                CanReadProperty("HocPhi", true);
                return _hocPhi;
            }
            set
            {
                CanWriteProperty("HocPhi", true);
                if (!_hocPhi.Equals(value))
                {
                    _hocPhi = value;
                    PropertyHasChanged("HocPhi");
                }
            }
        }

        public string GhiChu
        {
            get
            {
                CanReadProperty("GhiChu", true);
                return _ghiChu;
            }
            set
            {
                CanWriteProperty("GhiChu", true);
                if (value == null) value = string.Empty;
                if (!_ghiChu.Equals(value))
                {
                    _ghiChu = value;
                    PropertyHasChanged("GhiChu");
                }
            }
        }

        public DaoTaoNgoai_ChiTietList ChiTiet
        {
            get
            {
                CanReadProperty("ChiTiet", true);
                return _chiTiet;
            }
        }

        public override bool IsValid
        {
            get { return base.IsValid && _chiTiet.IsValid; }
        }

        public override bool IsDirty
        {
            get { return base.IsDirty || _chiTiet.IsDirty; }
        }

        protected override object GetIdValue()
        {
            return _maDTNgoai;
        }

        #endregion //Business Properties and Methods

        #region Validation Rules
        private void AddCustomRules()
        {
            //add custom/non-generated rules here...
            ValidationRules.AddRule(CommonRulesEx.ValueRequire, new CommonRulesEx.RequireArgs("TenChuongTrinh", "Chưa có nhập tên chương trình"));
        }

        private void AddCommonRules()
        {
            //
            // MaQL
            //
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("MaQL", 50));
            //
            // TenChuongTrinh
            //
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("TenChuongTrinh", 200));
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
            //TODO: Define authorization rules in DaoTaoNgoai
            //AuthorizationRules.AllowRead("ChiTiet", "DaoTaoNgoaiReadGroup");
            //AuthorizationRules.AllowRead("MaDTNgoai", "DaoTaoNgoaiReadGroup");
            //AuthorizationRules.AllowRead("MaQL", "DaoTaoNgoaiReadGroup");
            //AuthorizationRules.AllowRead("TenChuongTrinh", "DaoTaoNgoaiReadGroup");
            //AuthorizationRules.AllowRead("TuNgay", "DaoTaoNgoaiReadGroup");
            //AuthorizationRules.AllowRead("DenNgay", "DaoTaoNgoaiReadGroup");
            //AuthorizationRules.AllowRead("HocPhi", "DaoTaoNgoaiReadGroup");
            //AuthorizationRules.AllowRead("GhiChu", "DaoTaoNgoaiReadGroup");

            //AuthorizationRules.AllowWrite("MaQL", "DaoTaoNgoaiWriteGroup");
            //AuthorizationRules.AllowWrite("TenChuongTrinh", "DaoTaoNgoaiWriteGroup");
            //AuthorizationRules.AllowWrite("TuNgay", "DaoTaoNgoaiWriteGroup");
            //AuthorizationRules.AllowWrite("DenNgay", "DaoTaoNgoaiWriteGroup");
            //AuthorizationRules.AllowWrite("HocPhi", "DaoTaoNgoaiWriteGroup");
            //AuthorizationRules.AllowWrite("GhiChu", "DaoTaoNgoaiWriteGroup");
        }


        public static bool CanGetObject()
        {
            //TODO: Define CanGetObject permission in DaoTaoNgoai
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("DaoTaoNgoaiViewGroup"))
            //	return true;
            //return false;
        }

        public static bool CanAddObject()
        {
            //TODO: Define CanAddObject permission in DaoTaoNgoai
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("DaoTaoNgoaiAddGroup"))
            //	return true;
            //return false;
        }

        public static bool CanEditObject()
        {
            //TODO: Define CanEditObject permission in DaoTaoNgoai
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("DaoTaoNgoaiEditGroup"))
            //	return true;
            //return false;
        }

        public static bool CanDeleteObject()
        {
            //TODO: Define CanDeleteObject permission in DaoTaoNgoai
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("DaoTaoNgoaiDeleteGroup"))
            //	return true;
            //return false;
        }
        #endregion //Authorization Rules

        #region Factory Methods
        private DaoTaoNgoai()
        { /* require use of factory method */ }

        public static DaoTaoNgoai NewDaoTaoNgoai()
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a DaoTaoNgoai");
            return DataPortal.Create<DaoTaoNgoai>();
        }

        public static DaoTaoNgoai GetDaoTaoNgoai(int maDTNgoai)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a DaoTaoNgoai");
            return DataPortal.Fetch<DaoTaoNgoai>(new Criteria(maDTNgoai));
        }

        public static void DeleteDaoTaoNgoai(int maDTNgoai)
        {
            if (!CanDeleteObject())
                throw new System.Security.SecurityException("User not authorized to remove a DaoTaoNgoai");
            DataPortal.Delete(new Criteria(maDTNgoai));
        }

        public override DaoTaoNgoai Save()
        {
            if (IsDeleted && !CanDeleteObject())
                throw new System.Security.SecurityException("User not authorized to remove a DaoTaoNgoai");
            else if (IsNew && !CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a DaoTaoNgoai");
            else if (!CanEditObject())
                throw new System.Security.SecurityException("User not authorized to update a DaoTaoNgoai");

            return base.Save();
        }

        #endregion //Factory Methods

        #region Data Access

        #region Criteria

        [Serializable()]
        private class Criteria
        {
            public int MaDTNgoai;

            public Criteria(int maDTNgoai)
            {
                this.MaDTNgoai = maDTNgoai;
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
                cm.CommandText = "spd_Select_DaoTaoNgoai";

                cm.Parameters.AddWithValue("@MaDTNgoai", criteria.MaDTNgoai);

                using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                {
                    FetchObject(dr);
                    ValidationRules.CheckRules();

                    //load child object(s)
                    FetchChildren(dr);
                }
            }//using
        }

        private void FetchObject(SafeDataReader dr)
        {
            dr.Read();
            _maDTNgoai = dr.GetInt32("MaDTNgoai");
            _maQL = dr.GetString("MaQL");
            _tenChuongTrinh = dr.GetString("TenChuongTrinh");
            _tuNgay = dr.GetDateTime("TuNgay");
            _denNgay = dr.GetDateTime("DenNgay");
            _hocPhi = dr.GetDecimal("HocPhi");
            _ghiChu = dr.GetString("GhiChu");
        }

        private void FetchChildren(SafeDataReader dr)
        {
            dr.NextResult();
            _chiTiet = DaoTaoNgoai_ChiTietList.GetDaoTaoNgoai_ChiTietList(dr);
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

        private void ExecuteInsert(SqlTransaction tr)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_Insert_DaoTaoNgoai";

                AddInsertParameters(cm);

                cm.ExecuteNonQuery();

                _maDTNgoai = (int)cm.Parameters["@MaDTNgoai"].Value;
            }//using
        }

        private void AddInsertParameters(SqlCommand cm)
        {
            if (_maQL.Length > 0)
                cm.Parameters.AddWithValue("@MaQL", _maQL);
            else
                cm.Parameters.AddWithValue("@MaQL", DBNull.Value);
            cm.Parameters.AddWithValue("@TenChuongTrinh", _tenChuongTrinh);
            cm.Parameters.AddWithValue("@TuNgay", _tuNgay);
            cm.Parameters.AddWithValue("@DenNgay", _denNgay);
            cm.Parameters.AddWithValue("@HocPhi", _hocPhi);
            if (_ghiChu.Length > 0)
                cm.Parameters.AddWithValue("@GhiChu", _ghiChu);
            else
                cm.Parameters.AddWithValue("@GhiChu", DBNull.Value);
            cm.Parameters.AddWithValue("@MaDTNgoai", _maDTNgoai);
            cm.Parameters["@MaDTNgoai"].Direction = ParameterDirection.Output;
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

        private void ExecuteUpdate(SqlTransaction tr)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_Update_DaoTaoNgoai";

                AddUpdateParameters(cm);

                cm.ExecuteNonQuery();

            }//using
        }

        private void AddUpdateParameters(SqlCommand cm)
        {
            cm.Parameters.AddWithValue("@MaDTNgoai", _maDTNgoai);
            if (_maQL.Length > 0)
                cm.Parameters.AddWithValue("@MaQL", _maQL);
            else
                cm.Parameters.AddWithValue("@MaQL", DBNull.Value);
            cm.Parameters.AddWithValue("@TenChuongTrinh", _tenChuongTrinh);
            cm.Parameters.AddWithValue("@TuNgay", _tuNgay);
            cm.Parameters.AddWithValue("@DenNgay", _denNgay);
            cm.Parameters.AddWithValue("@HocPhi", _hocPhi);
            if (_ghiChu.Length > 0)
                cm.Parameters.AddWithValue("@GhiChu", _ghiChu);
            else
                cm.Parameters.AddWithValue("@GhiChu", DBNull.Value);
        }

        private void UpdateChildren(SqlTransaction tr)
        {
            _chiTiet.Update(tr, this);
        }
        #endregion //Data Access - Update

        #region Data Access - Delete
        protected override void DataPortal_DeleteSelf()
        {
            DataPortal_Delete(new Criteria(_maDTNgoai));
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
                cm.CommandText = "spd_Delete_DaoTaoNgoai";

                cm.Parameters.AddWithValue("@MaDTNgoai", criteria.MaDTNgoai);

                cm.ExecuteNonQuery();
            }//using
        }
        #endregion //Data Access - Delete
        #endregion //Data Access
    }
}
