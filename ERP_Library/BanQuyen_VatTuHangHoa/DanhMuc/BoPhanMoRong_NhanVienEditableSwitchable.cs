using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{
    [Serializable()]
    public class BoPhanMoRong_NhanVien : Csla.BusinessBase<BoPhanMoRong_NhanVien>
    {
        #region Business Properties and Methods

        //declare members
        private long _maNhanVien = 0;
        private int _maBoPhanMoRong = 0;
        private SmartDate _ngayLap = new SmartDate(false);
        private string _ghiChu = string.Empty;

        [System.ComponentModel.DataObjectField(true, false)]
        public long MaNhanVien
        {
            get
            {
                CanReadProperty("MaNhanVien", true);
                return _maNhanVien;
            }
            set
            {
                CanWriteProperty("MaNhanVien", true);
                if (!_maNhanVien.Equals(value))
                {
                    _maNhanVien = value;
                    PropertyHasChanged("MaNhanVien");
                }
            }
        }

        [System.ComponentModel.DataObjectField(true, false)]
        public int MaBoPhanMoRong
        {
            get
            {
                CanReadProperty("MaBoPhanMoRong", true);
                return _maBoPhanMoRong;
            }
            set
            {
                CanWriteProperty("MaBoPhanMoRong", true);
                if (!_maBoPhanMoRong.Equals(value))
                {
                    _maBoPhanMoRong = value;
                    PropertyHasChanged("MaBoPhanMoRong");
                }
            }
        }

        public DateTime NgayLap
        {
            get
            {
                CanReadProperty("NgayLap", true);
                return _ngayLap.Date;
            }
            set
            {
                if (_ngayLap.Date != (DateTime)value)
                {
                    CanWriteProperty("NgayLap", true);
                    _ngayLap = new SmartDate(value);
                    PropertyHasChanged("NgayLap");
                }

            }
        }

        //public string NgayLapString
        //{
        //    get
        //    {
        //        CanReadProperty("NgayLapString", true);
        //        return _ngayLap.Text;
        //    }
        //    set
        //    {
        //        CanWriteProperty("NgayLapString", true);
        //        if (value == null) value = string.Empty;
        //        if (!_ngayLap.Equals(value))
        //        {
        //            _ngayLap.Text = value;
        //            PropertyHasChanged("NgayLapString");
        //        }
        //    }
        //}

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

        protected override object GetIdValue()
        {
            return string.Format("{0}:{1}", _maNhanVien, _maBoPhanMoRong);
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
            // GhiChu
            //
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("GhiChu", 1000));
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
            //TODO: Define authorization rules in BoPhanMoRong_NhanVien
            //AuthorizationRules.AllowRead("MaNhanVien", "BoPhanMoRong_NhanVienReadGroup");
            //AuthorizationRules.AllowRead("MaBoPhanMoRong", "BoPhanMoRong_NhanVienReadGroup");
            //AuthorizationRules.AllowRead("NgayLap", "BoPhanMoRong_NhanVienReadGroup");
            //AuthorizationRules.AllowRead("NgayLapString", "BoPhanMoRong_NhanVienReadGroup");
            //AuthorizationRules.AllowRead("GhiChu", "BoPhanMoRong_NhanVienReadGroup");

            //AuthorizationRules.AllowWrite("NgayLapString", "BoPhanMoRong_NhanVienWriteGroup");
            //AuthorizationRules.AllowWrite("GhiChu", "BoPhanMoRong_NhanVienWriteGroup");
        }


        public static bool CanGetObject()
        {
            //TODO: Define CanGetObject permission in BoPhanMoRong_NhanVien
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("BoPhanMoRong_NhanVienViewGroup"))
            //	return true;
            //return false;
        }

        public static bool CanAddObject()
        {
            //TODO: Define CanAddObject permission in BoPhanMoRong_NhanVien
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("BoPhanMoRong_NhanVienAddGroup"))
            //	return true;
            //return false;
        }

        public static bool CanEditObject()
        {
            //TODO: Define CanEditObject permission in BoPhanMoRong_NhanVien
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("BoPhanMoRong_NhanVienEditGroup"))
            //	return true;
            //return false;
        }

        public static bool CanDeleteObject()
        {
            //TODO: Define CanDeleteObject permission in BoPhanMoRong_NhanVien
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("BoPhanMoRong_NhanVienDeleteGroup"))
            //	return true;
            //return false;
        }
        #endregion //Authorization Rules

        #region Factory Methods
        public BoPhanMoRong_NhanVien()
        { /* require use of factory method */ }

        public static BoPhanMoRong_NhanVien NewBoPhanMoRong_NhanVien(long maNhanVien, int maBoPhanMoRong)
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a BoPhanMoRong_NhanVien");
            return DataPortal.Create<BoPhanMoRong_NhanVien>(new Criteria(maNhanVien, maBoPhanMoRong));
        }

        public static BoPhanMoRong_NhanVien GetBoPhanMoRong_NhanVien(long maNhanVien, int maBoPhanMoRong)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a BoPhanMoRong_NhanVien");
            return DataPortal.Fetch<BoPhanMoRong_NhanVien>(new Criteria(maNhanVien, maBoPhanMoRong));
        }

        public static void DeleteBoPhanMoRong_NhanVien(long maNhanVien, int maBoPhanMoRong)
        {
            if (!CanDeleteObject())
                throw new System.Security.SecurityException("User not authorized to remove a BoPhanMoRong_NhanVien");
            DataPortal.Delete(new Criteria(maNhanVien, maBoPhanMoRong));
        }

        public override BoPhanMoRong_NhanVien Save()
        {
            if (IsDeleted && !CanDeleteObject())
                throw new System.Security.SecurityException("User not authorized to remove a BoPhanMoRong_NhanVien");
            else if (IsNew && !CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a BoPhanMoRong_NhanVien");
            else if (!CanEditObject())
                throw new System.Security.SecurityException("User not authorized to update a BoPhanMoRong_NhanVien");

            return base.Save();
        }

        #endregion //Factory Methods

        #region Child Factory Methods
        private BoPhanMoRong_NhanVien(long maNhanVien, int maBoPhanMoRong)
        {
            this._maNhanVien = maNhanVien;
            this._maBoPhanMoRong = maBoPhanMoRong;
        }

        internal static BoPhanMoRong_NhanVien NewBoPhanMoRong_NhanVienChild(long maNhanVien, int maBoPhanMoRong)
        {
            BoPhanMoRong_NhanVien child = new BoPhanMoRong_NhanVien(maNhanVien, maBoPhanMoRong);
            child.ValidationRules.CheckRules();
            child.MarkAsChild();
            return child;
        }

        internal static BoPhanMoRong_NhanVien GetBoPhanMoRong_NhanVien(SafeDataReader dr)
        {
            BoPhanMoRong_NhanVien child = new BoPhanMoRong_NhanVien();
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
            public long MaNhanVien;
            public int MaBoPhanMoRong;

            public Criteria(long maNhanVien, int maBoPhanMoRong)
            {
                this.MaNhanVien = maNhanVien;
                this.MaBoPhanMoRong = maBoPhanMoRong;
            }
        }

        #endregion //Criteria

        #region Data Access - Create
        [RunLocal]
        private void DataPortal_Create(Criteria criteria)
        {
            _maNhanVien = criteria.MaNhanVien;
            _maBoPhanMoRong = criteria.MaBoPhanMoRong;
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
                cm.CommandText = "spd_SelectnsBoPhanMoRong_NhanVien";

                cm.Parameters.AddWithValue("@MaNhanVien", criteria.MaNhanVien);
                cm.Parameters.AddWithValue("@MaBoPhanMoRong", criteria.MaBoPhanMoRong);

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
            DataPortal_Delete(new Criteria(_maNhanVien, _maBoPhanMoRong));
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
                cm.CommandText = "spd_DeletensBoPhanMoRong_NhanVien";

                cm.Parameters.AddWithValue("@MaNhanVien", criteria.MaNhanVien);
                cm.Parameters.AddWithValue("@MaBoPhanMoRong", criteria.MaBoPhanMoRong);

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
            _maNhanVien = dr.GetInt64("MaNhanVien");
            _maBoPhanMoRong = dr.GetInt32("MaBoPhanMoRong");
            _ngayLap = dr.GetSmartDate("NgayLap", _ngayLap.EmptyIsMin);
            _ghiChu = dr.GetString("GhiChu");
        }

        private void FetchChildren(SafeDataReader dr)
        {
        }
        #endregion //Data Access - Fetch

        #region Data Access - Insert
        internal void Insert(SqlTransaction tr, BoPhanMoRong_NhanVienList parent)
        {
            if (!IsDirty) return;

            ExecuteInsert(tr, parent);
            MarkOld();

            //update child object(s)
            UpdateChildren(tr);
        }

        private void ExecuteInsert(SqlTransaction tr, BoPhanMoRong_NhanVienList parent)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_InsertnsBoPhanMoRong_NhanVien";

                AddInsertParameters(cm, parent);

                cm.ExecuteNonQuery();

            }//using
        }

        private void AddInsertParameters(SqlCommand cm, BoPhanMoRong_NhanVienList parent)
        {
            //TODO: if parent use identity key, fix fk member with value from parent
            cm.Parameters.AddWithValue("@MaNhanVien", _maNhanVien);
            cm.Parameters.AddWithValue("@MaBoPhanMoRong", _maBoPhanMoRong);
            cm.Parameters.AddWithValue("@NgayLap", _ngayLap.DBValue);
            if (_ghiChu.Length > 0)
                cm.Parameters.AddWithValue("@GhiChu", _ghiChu);
            else
                cm.Parameters.AddWithValue("@GhiChu", DBNull.Value);
        }
        #endregion //Data Access - Insert

        #region Data Access - Update
        internal void Update(SqlTransaction tr, BoPhanMoRong_NhanVienList parent)
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

        private void ExecuteUpdate(SqlTransaction tr, BoPhanMoRong_NhanVienList parent)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_UpdatensBoPhanMoRong_NhanVien";

                AddUpdateParameters(cm, parent);

                cm.ExecuteNonQuery();

            }//using
        }

        private void AddUpdateParameters(SqlCommand cm, BoPhanMoRong_NhanVienList parent)
        {
            cm.Parameters.AddWithValue("@MaNhanVien", _maNhanVien);
            cm.Parameters.AddWithValue("@MaBoPhanMoRong", _maBoPhanMoRong);
            cm.Parameters.AddWithValue("@NgayLap", _ngayLap.DBValue);
            if (_ghiChu.Length > 0)
                cm.Parameters.AddWithValue("@GhiChu", _ghiChu);
            else
                cm.Parameters.AddWithValue("@GhiChu", DBNull.Value);
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

            ExecuteDelete(tr, new Criteria(_maNhanVien, _maBoPhanMoRong));
            MarkNew();
        }
        #endregion //Data Access - Delete
        #endregion //Data Access
    }
}
