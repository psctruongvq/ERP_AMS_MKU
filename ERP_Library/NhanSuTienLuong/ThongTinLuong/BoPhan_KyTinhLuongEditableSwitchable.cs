
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{
    [Serializable()]
    public class BoPhan_KyTinhLuong : Csla.BusinessBase<BoPhan_KyTinhLuong>
    {
        #region Business Properties and Methods

        //declare members
        private int _maBoPhan = 0;
        private int _maKyTinhLuong = 0;
        private double _soNgayLVTT = 0;
        private int _maBoPhanKyTinhLuong = 0;
        private double _soCongTinhChuyenCan = 0;
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

        public int MaKyTinhLuong
        {
            get
            {
                CanReadProperty("MaKyTinhLuong", true);
                return _maKyTinhLuong;
            }
            set
            {
                CanWriteProperty("MaKyTinhLuong", true);
                if (!_maKyTinhLuong.Equals(value))
                {
                    _maKyTinhLuong = value;
                    PropertyHasChanged("MaKyTinhLuong");
                }
            }
        }

        public double SoNgayLVTT
        {
            get
            {
                CanReadProperty("SoNgayLVTT", true);
                return _soNgayLVTT;
            }
            set
            {
                CanWriteProperty("SoNgayLVTT", true);
                if (!_soNgayLVTT.Equals(value))
                {
                    _soNgayLVTT = value;
                    PropertyHasChanged("SoNgayLVTT");
                }
            }
        }
        public double SoCongTinhChuyenCan
        {
            get
            {
                CanReadProperty("SoCongTinhChuyenCan", true);
                return _soCongTinhChuyenCan;
            }
            set
            {
                CanWriteProperty("SoCongTinhChuyenCan", true);
                if (!_soCongTinhChuyenCan.Equals(value))
                {
                    _soCongTinhChuyenCan = value;
                    PropertyHasChanged("SoCongTinhChuyenCan");
                }
            }
        }
        [System.ComponentModel.DataObjectField(true, true)]
        public int MaBoPhanKyTinhLuong
        {
            get
            {
                CanReadProperty("MaBoPhanKyTinhLuong", true);
                return _maBoPhanKyTinhLuong;
            }
        }

        protected override object GetIdValue()
        {
            return _maBoPhanKyTinhLuong;
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
            //TODO: Define authorization rules in BoPhan_KyTinhLuong
            //AuthorizationRules.AllowRead("MaBoPhan", "BoPhan_KyTinhLuongReadGroup");
            //AuthorizationRules.AllowRead("MaKyTinhLuong", "BoPhan_KyTinhLuongReadGroup");
            //AuthorizationRules.AllowRead("SoNgayLVTT", "BoPhan_KyTinhLuongReadGroup");
            //AuthorizationRules.AllowRead("MaBoPhanKyTinhLuong", "BoPhan_KyTinhLuongReadGroup");

            //AuthorizationRules.AllowWrite("MaBoPhan", "BoPhan_KyTinhLuongWriteGroup");
            //AuthorizationRules.AllowWrite("MaKyTinhLuong", "BoPhan_KyTinhLuongWriteGroup");
            //AuthorizationRules.AllowWrite("SoNgayLVTT", "BoPhan_KyTinhLuongWriteGroup");
        }


        public static bool CanGetObject()
        {
            //TODO: Define CanGetObject permission in BoPhan_KyTinhLuong
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("BoPhan_KyTinhLuongViewGroup"))
            //	return true;
            //return false;
        }

        public static bool CanAddObject()
        {
            //TODO: Define CanAddObject permission in BoPhan_KyTinhLuong
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("BoPhan_KyTinhLuongAddGroup"))
            //	return true;
            //return false;
        }

        public static bool CanEditObject()
        {
            //TODO: Define CanEditObject permission in BoPhan_KyTinhLuong
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("BoPhan_KyTinhLuongEditGroup"))
            //	return true;
            //return false;
        }

        public static bool CanDeleteObject()
        {
            //TODO: Define CanDeleteObject permission in BoPhan_KyTinhLuong
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("BoPhan_KyTinhLuongDeleteGroup"))
            //	return true;
            //return false;
        }
        #endregion //Authorization Rules

        #region Factory Methods
        private BoPhan_KyTinhLuong()
        { /* require use of factory method */ }

        public static BoPhan_KyTinhLuong NewBoPhan_KyTinhLuong()
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a BoPhan_KyTinhLuong");
            return DataPortal.Create<BoPhan_KyTinhLuong>();
        }

        public static BoPhan_KyTinhLuong GetBoPhan_KyTinhLuong(int maBoPhanKyTinhLuong)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a BoPhan_KyTinhLuong");
            return DataPortal.Fetch<BoPhan_KyTinhLuong>(new Criteria(maBoPhanKyTinhLuong));
        }

        public static void DeleteBoPhan_KyTinhLuong(int maBoPhanKyTinhLuong)
        {
            if (!CanDeleteObject())
                throw new System.Security.SecurityException("User not authorized to remove a BoPhan_KyTinhLuong");
            DataPortal.Delete(new Criteria(maBoPhanKyTinhLuong));
        }

        public override BoPhan_KyTinhLuong Save()
        {
            if (IsDeleted && !CanDeleteObject())
                throw new System.Security.SecurityException("User not authorized to remove a BoPhan_KyTinhLuong");
            else if (IsNew && !CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a BoPhan_KyTinhLuong");
            else if (!CanEditObject())
                throw new System.Security.SecurityException("User not authorized to update a BoPhan_KyTinhLuong");

            return base.Save();
        }

        #endregion //Factory Methods

        #region Child Factory Methods
        internal static BoPhan_KyTinhLuong NewBoPhan_KyTinhLuongChild()
        {
            BoPhan_KyTinhLuong child = new BoPhan_KyTinhLuong();
            child.ValidationRules.CheckRules();
            child.MarkAsChild();
            return child;
        }

        internal static BoPhan_KyTinhLuong GetBoPhan_KyTinhLuong(SafeDataReader dr)
        {
            BoPhan_KyTinhLuong child = new BoPhan_KyTinhLuong();
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
            public int MaBoPhanKyTinhLuong;

            public Criteria(int maBoPhanKyTinhLuong)
            {
                this.MaBoPhanKyTinhLuong = maBoPhanKyTinhLuong;
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
                cm.CommandText = "sp_SelecttblnsBoPhan_KyTinhLuong";

                cm.Parameters.AddWithValue("@MaBoPhanKyTinhLuong", criteria.MaBoPhanKyTinhLuong);

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
            DataPortal_Delete(new Criteria(_maBoPhanKyTinhLuong));
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
                cm.CommandText = "sp_DeletetblnsBoPhan_KyTinhLuong";

                cm.Parameters.AddWithValue("@MaBoPhanKyTinhLuong", criteria.MaBoPhanKyTinhLuong);

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
            _maBoPhan = dr.GetInt32("MaBoPhan");
            _maKyTinhLuong = dr.GetInt32("MaKyTinhLuong");
            _soNgayLVTT = dr.GetDouble("SoNgayLVTT");
            _maBoPhanKyTinhLuong = dr.GetInt32("MaBoPhanKyTinhLuong");
            _soCongTinhChuyenCan = dr.GetDouble("SoCongTinhChuyenCan");
        }

        private void FetchChildren(SafeDataReader dr)
        {
        }
        #endregion //Data Access - Fetch

        #region Data Access - Insert
        internal void Insert(SqlTransaction tr, BoPhan_KyTinhLuongList parent)
        {
            if (!IsDirty) return;

            ExecuteInsert(tr, parent);
            MarkOld();

            //update child object(s)
            UpdateChildren(tr);
        }

        private void ExecuteInsert(SqlTransaction tr, BoPhan_KyTinhLuongList parent)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "sp_InserttblnsBoPhan_KyTinhLuong";

                AddInsertParameters(cm, parent);

                cm.ExecuteNonQuery();

                _maBoPhanKyTinhLuong = (int)cm.Parameters["@MaBoPhanKyTinhLuong"].Value;
            }//using
        }

        private void AddInsertParameters(SqlCommand cm, BoPhan_KyTinhLuongList parent)
        {
            //TODO: if parent use identity key, fix fk member with value from parent
            cm.Parameters.AddWithValue("@MaBoPhan", _maBoPhan);
            cm.Parameters.AddWithValue("@MaKyTinhLuong", _maKyTinhLuong);
            cm.Parameters.AddWithValue("@SoNgayLVTT", _soNgayLVTT);
            cm.Parameters.AddWithValue("@SoCongTinhChuyenCan", _soCongTinhChuyenCan);
            cm.Parameters.AddWithValue("@MaBoPhanKyTinhLuong", _maBoPhanKyTinhLuong);
            cm.Parameters["@MaBoPhanKyTinhLuong"].Direction = ParameterDirection.Output;
        }
        #endregion //Data Access - Insert

        #region Data Access - Update
        internal void Update(SqlTransaction tr, BoPhan_KyTinhLuongList parent)
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

        private void ExecuteUpdate(SqlTransaction tr, BoPhan_KyTinhLuongList parent)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "sp_UpdatetblnsBoPhan_KyTinhLuong";

                AddUpdateParameters(cm, parent);

                cm.ExecuteNonQuery();

            }//using
        }

        private void AddUpdateParameters(SqlCommand cm, BoPhan_KyTinhLuongList parent)
        {
            cm.Parameters.AddWithValue("@MaBoPhan", _maBoPhan);
            cm.Parameters.AddWithValue("@MaKyTinhLuong", _maKyTinhLuong);
            cm.Parameters.AddWithValue("@SoNgayLVTT", _soNgayLVTT);
            cm.Parameters.AddWithValue("@SoCongTinhChuyenCan", _soCongTinhChuyenCan);
            cm.Parameters.AddWithValue("@MaBoPhanKyTinhLuong", _maBoPhanKyTinhLuong);
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

            ExecuteDelete(tr, new Criteria(_maBoPhanKyTinhLuong));
            MarkNew();
        }
        #endregion //Data Access - Delete
        #endregion //Data Access
    }
}
