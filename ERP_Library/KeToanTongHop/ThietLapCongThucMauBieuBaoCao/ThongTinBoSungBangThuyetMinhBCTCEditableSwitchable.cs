using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{
    [Serializable()]
    public class ThongTinBoSungBangThuyetMinhBCTCEditableSwitchable : Csla.BusinessBase<ThongTinBoSungBangThuyetMinhBCTCEditableSwitchable>
    {
        #region Business Properties and Methods

        //declare members
        private long _id = 0;
        private string _tenDoiTuong = string.Empty;
        private decimal _soTienDK = 0;
        private string _ghiChu = string.Empty;
        private int _maMuc = 0;
        private SmartDate _tuNgay = new SmartDate(false);
        private SmartDate _denNgay = new SmartDate(false);
        private decimal _soTienCK = 0;

        [System.ComponentModel.DataObjectField(true, true)]
        public long Id
        {
            get
            {
                CanReadProperty("Id", true);
                return _id;
            }
        }

        public string TenDoiTuong
        {
            get
            {
                CanReadProperty("TenDoiTuong", true);
                return _tenDoiTuong;
            }
            set
            {
                CanWriteProperty("TenDoiTuong", true);
                if (value == null) value = string.Empty;
                if (!_tenDoiTuong.Equals(value))
                {
                    _tenDoiTuong = value;
                    PropertyHasChanged("TenDoiTuong");
                }
            }
        }

        public decimal SoTienDK
        {
            get
            {
                CanReadProperty("SoTienDK", true);
                return _soTienDK;
            }
            set
            {
                CanWriteProperty("SoTienDK", true);
                if (!_soTienDK.Equals(value))
                {
                    _soTienDK = value;
                    PropertyHasChanged("SoTienDK");
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

        public int MaMuc
        {
            get
            {
                CanReadProperty("MaMuc", true);
                return _maMuc;
            }
            set
            {
                CanWriteProperty("MaMuc", true);
                if (!_maMuc.Equals(value))
                {
                    _maMuc = value;
                    PropertyHasChanged("MaMuc");
                }
            }
        }

        public DateTime TuNgay
        {
            get
            {
                CanReadProperty("TuNgay", true);
                return _tuNgay.Date;
            }
            set
            {

                CanWriteProperty("TuNgay", true);
                _tuNgay = new SmartDate(value);
                PropertyHasChanged("TuNgay");
            }
        }

        public DateTime DenNgay
        {
            get
            {
                CanReadProperty("DenNgay", true);
                return _denNgay.Date;
            }
            set
            {

                CanWriteProperty("DenNgay", true);
                _denNgay = new SmartDate(value);
                PropertyHasChanged("DenNgay");
            }
        }

        public decimal SoTienCK
        {
            get
            {
                CanReadProperty("SoTienCK", true);
                return _soTienCK;
            }
            set
            {
                CanWriteProperty("SoTienCK", true);
                if (!_soTienCK.Equals(value))
                {
                    _soTienCK = value;
                    PropertyHasChanged("SoTienCK");
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
            //TODO: Define authorization rules in ThongTinBoSungBangThuyetMinhBCTCEditableSwitchable
            //AuthorizationRules.AllowRead("Id", "ThongTinBoSungBangThuyetMinhBCTCEditableSwitchableReadGroup");
            //AuthorizationRules.AllowRead("TenDoiTuong", "ThongTinBoSungBangThuyetMinhBCTCEditableSwitchableReadGroup");
            //AuthorizationRules.AllowRead("SoTienDK", "ThongTinBoSungBangThuyetMinhBCTCEditableSwitchableReadGroup");
            //AuthorizationRules.AllowRead("GhiChu", "ThongTinBoSungBangThuyetMinhBCTCEditableSwitchableReadGroup");
            //AuthorizationRules.AllowRead("MaMuc", "ThongTinBoSungBangThuyetMinhBCTCEditableSwitchableReadGroup");
            //AuthorizationRules.AllowRead("TuNgay", "ThongTinBoSungBangThuyetMinhBCTCEditableSwitchableReadGroup");
            //AuthorizationRules.AllowRead("TuNgayString", "ThongTinBoSungBangThuyetMinhBCTCEditableSwitchableReadGroup");
            //AuthorizationRules.AllowRead("DenNgay", "ThongTinBoSungBangThuyetMinhBCTCEditableSwitchableReadGroup");
            //AuthorizationRules.AllowRead("DenNgayString", "ThongTinBoSungBangThuyetMinhBCTCEditableSwitchableReadGroup");
            //AuthorizationRules.AllowRead("SoTienCK", "ThongTinBoSungBangThuyetMinhBCTCEditableSwitchableReadGroup");

            //AuthorizationRules.AllowWrite("TenDoiTuong", "ThongTinBoSungBangThuyetMinhBCTCEditableSwitchableWriteGroup");
            //AuthorizationRules.AllowWrite("SoTienDK", "ThongTinBoSungBangThuyetMinhBCTCEditableSwitchableWriteGroup");
            //AuthorizationRules.AllowWrite("GhiChu", "ThongTinBoSungBangThuyetMinhBCTCEditableSwitchableWriteGroup");
            //AuthorizationRules.AllowWrite("MaMuc", "ThongTinBoSungBangThuyetMinhBCTCEditableSwitchableWriteGroup");
            //AuthorizationRules.AllowWrite("TuNgayString", "ThongTinBoSungBangThuyetMinhBCTCEditableSwitchableWriteGroup");
            //AuthorizationRules.AllowWrite("DenNgayString", "ThongTinBoSungBangThuyetMinhBCTCEditableSwitchableWriteGroup");
            //AuthorizationRules.AllowWrite("SoTienCK", "ThongTinBoSungBangThuyetMinhBCTCEditableSwitchableWriteGroup");
        }


        public static bool CanGetObject()
        {
            //TODO: Define CanGetObject permission in ThongTinBoSungBangThuyetMinhBCTCEditableSwitchable
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("ThongTinBoSungBangThuyetMinhBCTCEditableSwitchableViewGroup"))
            //	return true;
            //return false;
        }

        public static bool CanAddObject()
        {
            //TODO: Define CanAddObject permission in ThongTinBoSungBangThuyetMinhBCTCEditableSwitchable
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("ThongTinBoSungBangThuyetMinhBCTCEditableSwitchableAddGroup"))
            //	return true;
            //return false;
        }

        public static bool CanEditObject()
        {
            //TODO: Define CanEditObject permission in ThongTinBoSungBangThuyetMinhBCTCEditableSwitchable
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("ThongTinBoSungBangThuyetMinhBCTCEditableSwitchableEditGroup"))
            //	return true;
            //return false;
        }

        public static bool CanDeleteObject()
        {
            //TODO: Define CanDeleteObject permission in ThongTinBoSungBangThuyetMinhBCTCEditableSwitchable
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("ThongTinBoSungBangThuyetMinhBCTCEditableSwitchableDeleteGroup"))
            //	return true;
            //return false;
        }
        #endregion //Authorization Rules

        #region Factory Methods
        private ThongTinBoSungBangThuyetMinhBCTCEditableSwitchable()
        { /* require use of factory method */ }

        public static ThongTinBoSungBangThuyetMinhBCTCEditableSwitchable NewThongTinBoSungBangThuyetMinhBCTCEditableSwitchable()
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a ThongTinBoSungBangThuyetMinhBCTCEditableSwitchable");
            return DataPortal.Create<ThongTinBoSungBangThuyetMinhBCTCEditableSwitchable>();
        }

        public static ThongTinBoSungBangThuyetMinhBCTCEditableSwitchable GetThongTinBoSungBangThuyetMinhBCTCEditableSwitchable(long id)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a ThongTinBoSungBangThuyetMinhBCTCEditableSwitchable");
            return DataPortal.Fetch<ThongTinBoSungBangThuyetMinhBCTCEditableSwitchable>(new Criteria(id));
        }

        public static void DeleteThongTinBoSungBangThuyetMinhBCTCEditableSwitchable(long id)
        {
            if (!CanDeleteObject())
                throw new System.Security.SecurityException("User not authorized to remove a ThongTinBoSungBangThuyetMinhBCTCEditableSwitchable");
            DataPortal.Delete(new Criteria(id));
        }

        public override ThongTinBoSungBangThuyetMinhBCTCEditableSwitchable Save()
        {
            if (IsDeleted && !CanDeleteObject())
                throw new System.Security.SecurityException("User not authorized to remove a ThongTinBoSungBangThuyetMinhBCTCEditableSwitchable");
            else if (IsNew && !CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a ThongTinBoSungBangThuyetMinhBCTCEditableSwitchable");
            else if (!CanEditObject())
                throw new System.Security.SecurityException("User not authorized to update a ThongTinBoSungBangThuyetMinhBCTCEditableSwitchable");

            return base.Save();
        }

        #endregion //Factory Methods

        #region Child Factory Methods
        internal static ThongTinBoSungBangThuyetMinhBCTCEditableSwitchable NewThongTinBoSungBangThuyetMinhBCTCEditableSwitchableChild()
        {
            ThongTinBoSungBangThuyetMinhBCTCEditableSwitchable child = new ThongTinBoSungBangThuyetMinhBCTCEditableSwitchable();
            child.ValidationRules.CheckRules();
            child.MarkAsChild();
            return child;
        }

        internal static ThongTinBoSungBangThuyetMinhBCTCEditableSwitchable GetThongTinBoSungBangThuyetMinhBCTCEditableSwitchable(SafeDataReader dr)
        {
            ThongTinBoSungBangThuyetMinhBCTCEditableSwitchable child = new ThongTinBoSungBangThuyetMinhBCTCEditableSwitchable();
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
            public long Id;

            public Criteria(long id)
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
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();

                ExecuteFetch(cn, criteria);
            }//using
        }

        private void ExecuteFetch(SqlConnection cn, Criteria criteria)
        {
            using (SqlCommand cm = cn.CreateCommand())
            {
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "GetThongTinBoSungBangThuyetMinhBCTCEditableSwitchable";

                cm.Parameters.AddWithValue("@Id", criteria.Id);

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
                cm.CommandText = "spd_DeletetblThongTinBoSungBangThuyetMinhBCTC";

                cm.Parameters.AddWithValue("@Id", criteria.Id);

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
            _id = dr.GetInt64("Id");
            _tenDoiTuong = dr.GetString("TenDoiTuong");
            _soTienDK = dr.GetDecimal("SoTienDK");
            _ghiChu = dr.GetString("GhiChu");
            _maMuc = dr.GetInt32("MaMuc");
            _tuNgay = dr.GetSmartDate("TuNgay", _tuNgay.EmptyIsMin);
            _denNgay = dr.GetSmartDate("DenNgay", _denNgay.EmptyIsMin);
            _soTienCK = dr.GetDecimal("SoTienCK");
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
                cm.CommandText = "spd_InserttblThongTinBoSungBangThuyetMinhBCTC";

                AddInsertParameters(cm);

                cm.ExecuteNonQuery();

                _id = (long)cm.Parameters["@Id"].Value;
            }//using
        }

        private void AddInsertParameters(SqlCommand cm)
        {
            if (_tenDoiTuong.Length > 0)
                cm.Parameters.AddWithValue("@TenDoiTuong", _tenDoiTuong);
            else
                cm.Parameters.AddWithValue("@TenDoiTuong", DBNull.Value);
            if (_soTienDK != 0)
                cm.Parameters.AddWithValue("@SoTienDK", _soTienDK);
            else
                cm.Parameters.AddWithValue("@SoTienDK", DBNull.Value);
            if (_ghiChu.Length > 0)
                cm.Parameters.AddWithValue("@GhiChu", _ghiChu);
            else
                cm.Parameters.AddWithValue("@GhiChu", DBNull.Value);
            if (_maMuc != 0)
                cm.Parameters.AddWithValue("@MaMuc", _maMuc);
            else
                cm.Parameters.AddWithValue("@MaMuc", DBNull.Value);
            cm.Parameters.AddWithValue("@TuNgay", _tuNgay.DBValue);
            cm.Parameters.AddWithValue("@DenNgay", _denNgay.DBValue);
            if (_soTienCK != 0)
                cm.Parameters.AddWithValue("@SoTienCK", _soTienCK);
            else
                cm.Parameters.AddWithValue("@SoTienCK", DBNull.Value);
            cm.Parameters.AddWithValue("@Id", _id);
            cm.Parameters["@Id"].Direction = ParameterDirection.Output;
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
                cm.CommandText = "spd_UpdatetblThongTinBoSungBangThuyetMinhBCTC";

                AddUpdateParameters(cm);

                cm.ExecuteNonQuery();

            }//using
        }

        private void AddUpdateParameters(SqlCommand cm)
        {
            cm.Parameters.AddWithValue("@Id", _id);
            if (_tenDoiTuong.Length > 0)
                cm.Parameters.AddWithValue("@TenDoiTuong", _tenDoiTuong);
            else
                cm.Parameters.AddWithValue("@TenDoiTuong", DBNull.Value);
            if (_soTienDK != 0)
                cm.Parameters.AddWithValue("@SoTienDK", _soTienDK);
            else
                cm.Parameters.AddWithValue("@SoTienDK", DBNull.Value);
            if (_ghiChu.Length > 0)
                cm.Parameters.AddWithValue("@GhiChu", _ghiChu);
            else
                cm.Parameters.AddWithValue("@GhiChu", DBNull.Value);
            if (_maMuc != 0)
                cm.Parameters.AddWithValue("@MaMuc", _maMuc);
            else
                cm.Parameters.AddWithValue("@MaMuc", DBNull.Value);
            cm.Parameters.AddWithValue("@TuNgay", _tuNgay.DBValue);
            cm.Parameters.AddWithValue("@DenNgay", _denNgay.DBValue);
            if (_soTienCK != 0)
                cm.Parameters.AddWithValue("@SoTienCK", _soTienCK);
            else
                cm.Parameters.AddWithValue("@SoTienCK", DBNull.Value);
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
