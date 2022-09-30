
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{
    [Serializable()]
    public class ChungTu_ChuongTrinh : Csla.BusinessBase<ChungTu_ChuongTrinh>
    {
        #region Business Properties and Methods

        //declare members
        private long _machungtuChuongtrinh = 0;
        private long _maChungTu = 0;
        private int _maChuongTrinh = 0;
        private string _tenChuongTrinh = string.Empty;
        private decimal _soTien = 0;

        [System.ComponentModel.DataObjectField(true, true)]
        public long MachungtuChuongtrinh
        {
            get
            {
                CanReadProperty("MachungtuChuongtrinh", true);
                return _machungtuChuongtrinh;
            }
        }

        public long MaChungTu
        {
            get
            {
                CanReadProperty("MaChungTu", true);
                return _maChungTu;
            }
            set
            {
                CanWriteProperty("MaChungTu", true);
                if (!_maChungTu.Equals(value))
                {
                    _maChungTu = value;
                    PropertyHasChanged("MaChungTu");
                }
            }
        }

        public int MaChuongTrinh
        {
            get
            {
                CanReadProperty("MaChuongTrinh", true);
                return _maChuongTrinh;
            }
            set
            {
                CanWriteProperty("MaChuongTrinh", true);
                if (!_maChuongTrinh.Equals(value))
                {
                    _maChuongTrinh = value;
                    PropertyHasChanged("MaChuongTrinh");
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

        public decimal SoTien
        {
            get
            {
                CanReadProperty("SoTien", true);
                return _soTien;
            }
            set
            {
                CanWriteProperty("SoTien", true);
                if (!_soTien.Equals(value))
                {
                    _soTien = value;
                    PropertyHasChanged("SoTien");
                }
            }
        }

        protected override object GetIdValue()
        {
            return _machungtuChuongtrinh;
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
            //TODO: Define authorization rules in ChungTu_ChuongTrinh
            //AuthorizationRules.AllowRead("MachungtuChuongtrinh", "ChungTu_ChuongTrinhReadGroup");
            //AuthorizationRules.AllowRead("MaChungTu", "ChungTu_ChuongTrinhReadGroup");
            //AuthorizationRules.AllowRead("MaChuongTrinh", "ChungTu_ChuongTrinhReadGroup");
            //AuthorizationRules.AllowRead("TenChuongTrinh", "ChungTu_ChuongTrinhReadGroup");
            //AuthorizationRules.AllowRead("SoTien", "ChungTu_ChuongTrinhReadGroup");

            //AuthorizationRules.AllowWrite("MaChungTu", "ChungTu_ChuongTrinhWriteGroup");
            //AuthorizationRules.AllowWrite("MaChuongTrinh", "ChungTu_ChuongTrinhWriteGroup");
            //AuthorizationRules.AllowWrite("TenChuongTrinh", "ChungTu_ChuongTrinhWriteGroup");
            //AuthorizationRules.AllowWrite("SoTien", "ChungTu_ChuongTrinhWriteGroup");
        }


        public static bool CanGetObject()
        {
            //TODO: Define CanGetObject permission in ChungTu_ChuongTrinh
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("ChungTu_ChuongTrinhViewGroup"))
            //	return true;
            //return false;
        }

        public static bool CanAddObject()
        {
            //TODO: Define CanAddObject permission in ChungTu_ChuongTrinh
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("ChungTu_ChuongTrinhAddGroup"))
            //	return true;
            //return false;
        }

        public static bool CanEditObject()
        {
            //TODO: Define CanEditObject permission in ChungTu_ChuongTrinh
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("ChungTu_ChuongTrinhEditGroup"))
            //	return true;
            //return false;
        }

        public static bool CanDeleteObject()
        {
            //TODO: Define CanDeleteObject permission in ChungTu_ChuongTrinh
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("ChungTu_ChuongTrinhDeleteGroup"))
            //	return true;
            //return false;
        }
        #endregion //Authorization Rules

        #region Factory Methods
        private ChungTu_ChuongTrinh()
        { /* require use of factory method */ }

        public static ChungTu_ChuongTrinh NewChungTu_ChuongTrinh()
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a ChungTu_ChuongTrinh");
            return DataPortal.Create<ChungTu_ChuongTrinh>();
        }

        public static ChungTu_ChuongTrinh GetChungTu_ChuongTrinh(long machungtuChuongtrinh)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a ChungTu_ChuongTrinh");
            return DataPortal.Fetch<ChungTu_ChuongTrinh>(new Criteria(machungtuChuongtrinh));
        }

        public static void DeleteChungTu_ChuongTrinh(long machungtuChuongtrinh)
        {
            if (!CanDeleteObject())
                throw new System.Security.SecurityException("User not authorized to remove a ChungTu_ChuongTrinh");
            DataPortal.Delete(new Criteria(machungtuChuongtrinh));
        }

        public override ChungTu_ChuongTrinh Save()
        {
            if (IsDeleted && !CanDeleteObject())
                throw new System.Security.SecurityException("User not authorized to remove a ChungTu_ChuongTrinh");
            else if (IsNew && !CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a ChungTu_ChuongTrinh");
            else if (!CanEditObject())
                throw new System.Security.SecurityException("User not authorized to update a ChungTu_ChuongTrinh");

            return base.Save();
        }

        #endregion //Factory Methods

        #region Child Factory Methods
        internal static ChungTu_ChuongTrinh NewChungTu_ChuongTrinhChild()
        {
            ChungTu_ChuongTrinh child = new ChungTu_ChuongTrinh();
            child.ValidationRules.CheckRules();
            child.MarkAsChild();
            return child;
        }

        internal static ChungTu_ChuongTrinh GetChungTu_ChuongTrinh(SafeDataReader dr)
        {
            ChungTu_ChuongTrinh child = new ChungTu_ChuongTrinh();
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
            public long MachungtuChuongtrinh;

            public Criteria(long machungtuChuongtrinh)
            {
                this.MachungtuChuongtrinh = machungtuChuongtrinh;
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
                cm.CommandText = "spd_SelecttblChungTu_ChuongTrinh";

                cm.Parameters.AddWithValue("@MaChungTu_ChuongTrinh", criteria.MachungtuChuongtrinh);

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
            DataPortal_Delete(new Criteria(_machungtuChuongtrinh));
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
                cm.CommandText = "spd_DeletetblChungTu_ChuongTrinh";

                cm.Parameters.AddWithValue("@MaChungTu_ChuongTrinh", criteria.MachungtuChuongtrinh);

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
            _machungtuChuongtrinh = dr.GetInt64("MaChungTu_ChuongTrinh");
            _maChungTu = dr.GetInt64("MaChungTu");
            _maChuongTrinh = dr.GetInt32("MaChuongTrinh");
            _tenChuongTrinh = dr.GetString("TenChuongTrinh");
            _soTien = dr.GetDecimal("SoTien");
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
                cm.CommandText = "spd_InserttblChungTu_ChuongTrinh";

                AddInsertParameters(cm);

                cm.ExecuteNonQuery();

                _machungtuChuongtrinh = (long)cm.Parameters["@MaChungTu_ChuongTrinh"].Value;
            }//using
        }

        private void AddInsertParameters(SqlCommand cm)
        {
            if (_maChungTu != 0)
                cm.Parameters.AddWithValue("@MaChungTu", _maChungTu);
            else
                cm.Parameters.AddWithValue("@MaChungTu", DBNull.Value);
            if (_maChuongTrinh != 0)
                cm.Parameters.AddWithValue("@MaChuongTrinh", _maChuongTrinh);
            else
                cm.Parameters.AddWithValue("@MaChuongTrinh", DBNull.Value);
            if (_tenChuongTrinh.Length > 0)
                cm.Parameters.AddWithValue("@TenChuongTrinh", _tenChuongTrinh);
            else
                cm.Parameters.AddWithValue("@TenChuongTrinh", DBNull.Value);
            if (_soTien != 0)
                cm.Parameters.AddWithValue("@SoTien", _soTien);
            else
                cm.Parameters.AddWithValue("@SoTien", DBNull.Value);
            cm.Parameters.AddWithValue("@MaChungTu_ChuongTrinh", _machungtuChuongtrinh);
            cm.Parameters["@MaChungTu_ChuongTrinh"].Direction = ParameterDirection.Output;
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
                cm.CommandText = "spd_UpdatetblChungTu_ChuongTrinh";

                AddUpdateParameters(cm);

                cm.ExecuteNonQuery();

            }//using
        }

        private void AddUpdateParameters(SqlCommand cm)
        {
            cm.Parameters.AddWithValue("@MaChungTu_ChuongTrinh", _machungtuChuongtrinh);
            if (_maChungTu != 0)
                cm.Parameters.AddWithValue("@MaChungTu", _maChungTu);
            else
                cm.Parameters.AddWithValue("@MaChungTu", DBNull.Value);
            if (_maChuongTrinh != 0)
                cm.Parameters.AddWithValue("@MaChuongTrinh", _maChuongTrinh);
            else
                cm.Parameters.AddWithValue("@MaChuongTrinh", DBNull.Value);
            if (_tenChuongTrinh.Length > 0)
                cm.Parameters.AddWithValue("@TenChuongTrinh", _tenChuongTrinh);
            else
                cm.Parameters.AddWithValue("@TenChuongTrinh", DBNull.Value);
            if (_soTien != 0)
                cm.Parameters.AddWithValue("@SoTien", _soTien);
            else
                cm.Parameters.AddWithValue("@SoTien", DBNull.Value);
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

            ExecuteDelete(tr, new Criteria(_machungtuChuongtrinh));
            MarkNew();
        }
        #endregion //Data Access - Delete
        #endregion //Data Access
    }
}
