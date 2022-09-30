
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{
    [Serializable()]
    public class BoPhan_NgayPhep : Csla.BusinessBase<BoPhan_NgayPhep>
    {
        #region Business Properties and Methods

        //declare members
        private int _bophanNgayphepid = 0;
        private Nullable<int> _maBoPhan = null;
        private int _ngayPhep = 0;
        private string _ghiChu = string.Empty;

        [System.ComponentModel.DataObjectField(true, true)]
        public int BophanNgayphepid
        {
            get
            {
                CanReadProperty("BophanNgayphepid", true);
                return _bophanNgayphepid;
            }
        }

        public Nullable<int> MaBoPhan
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

        public int NgayPhep
        {
            get
            {
                CanReadProperty("NgayPhep", true);
                return _ngayPhep;
            }
            set
            {
                CanWriteProperty("NgayPhep", true);
                if (!_ngayPhep.Equals(value))
                {
                    _ngayPhep = value;
                    PropertyHasChanged("NgayPhep");
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

        protected override object GetIdValue()
        {
            return _bophanNgayphepid;
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
            //TODO: Define authorization rules in BoPhan_NgayPhep
            //AuthorizationRules.AllowRead("BophanNgayphepid", "BoPhan_NgayPhepReadGroup");
            //AuthorizationRules.AllowRead("MaBoPhan", "BoPhan_NgayPhepReadGroup");
            //AuthorizationRules.AllowRead("NgayPhep", "BoPhan_NgayPhepReadGroup");
            //AuthorizationRules.AllowRead("GhiChu", "BoPhan_NgayPhepReadGroup");

            //AuthorizationRules.AllowWrite("MaBoPhan", "BoPhan_NgayPhepWriteGroup");
            //AuthorizationRules.AllowWrite("NgayPhep", "BoPhan_NgayPhepWriteGroup");
            //AuthorizationRules.AllowWrite("GhiChu", "BoPhan_NgayPhepWriteGroup");
        }


        public static bool CanGetObject()
        {
            //TODO: Define CanGetObject permission in BoPhan_NgayPhep
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("BoPhan_NgayPhepViewGroup"))
            //	return true;
            //return false;
        }

        public static bool CanAddObject()
        {
            //TODO: Define CanAddObject permission in BoPhan_NgayPhep
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("BoPhan_NgayPhepAddGroup"))
            //	return true;
            //return false;
        }

        public static bool CanEditObject()
        {
            //TODO: Define CanEditObject permission in BoPhan_NgayPhep
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("BoPhan_NgayPhepEditGroup"))
            //	return true;
            //return false;
        }

        public static bool CanDeleteObject()
        {
            //TODO: Define CanDeleteObject permission in BoPhan_NgayPhep
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("BoPhan_NgayPhepDeleteGroup"))
            //	return true;
            //return false;
        }
        #endregion //Authorization Rules

        #region Factory Methods
        public BoPhan_NgayPhep()
        { /* require use of factory method */ MarkAsChild(); }

        public static BoPhan_NgayPhep NewBoPhan_NgayPhep()
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a BoPhan_NgayPhep");
            return DataPortal.Create<BoPhan_NgayPhep>();
        }

        public static BoPhan_NgayPhep GetBoPhan_NgayPhep(int bophanNgayphepid)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a BoPhan_NgayPhep");
            return DataPortal.Fetch<BoPhan_NgayPhep>(new Criteria(bophanNgayphepid));
        }

        public static void DeleteBoPhan_NgayPhep(int bophanNgayphepid)
        {
            if (!CanDeleteObject())
                throw new System.Security.SecurityException("User not authorized to remove a BoPhan_NgayPhep");
            DataPortal.Delete(new Criteria(bophanNgayphepid));
        }

        public override BoPhan_NgayPhep Save()
        {
            if (IsDeleted && !CanDeleteObject())
                throw new System.Security.SecurityException("User not authorized to remove a BoPhan_NgayPhep");
            else if (IsNew && !CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a BoPhan_NgayPhep");
            else if (!CanEditObject())
                throw new System.Security.SecurityException("User not authorized to update a BoPhan_NgayPhep");

            return base.Save();
        }

        #endregion //Factory Methods

        #region Child Factory Methods
        internal static BoPhan_NgayPhep NewBoPhan_NgayPhepChild()
        {
            BoPhan_NgayPhep child = new BoPhan_NgayPhep();
            child.ValidationRules.CheckRules();
            child.MarkAsChild();
            return child;
        }

        internal static BoPhan_NgayPhep GetBoPhan_NgayPhep(SafeDataReader dr)
        {
            BoPhan_NgayPhep child = new BoPhan_NgayPhep();
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
            public int BophanNgayphepid;

            public Criteria(int bophanNgayphepid)
            {
                this.BophanNgayphepid = bophanNgayphepid;
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
                cm.CommandText = "GetBoPhan_NgayPhep";

                cm.Parameters.AddWithValue("@BoPhan_NgayPhepID", criteria.BophanNgayphepid);

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
            DataPortal_Delete(new Criteria(_bophanNgayphepid));
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
                cm.CommandText = "DeleteBoPhan_NgayPhep";

                cm.Parameters.AddWithValue("@BoPhan_NgayPhepID", criteria.BophanNgayphepid);

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
            _bophanNgayphepid = dr.GetInt32("BoPhan_NgayPhepID");
            _maBoPhan = (Nullable<int>)dr.GetValue("MaBoPhan");
            _ngayPhep = dr.GetInt32("NgayPhep");
            _ghiChu = dr.GetString("GhiChu");
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
                cm.CommandText = "AddBoPhan_NgayPhep";

                AddInsertParameters(cm);

                cm.ExecuteNonQuery();

                _bophanNgayphepid = (int)cm.Parameters["@NewBoPhan_NgayPhepID"].Value;
            }//using
        }

        private void AddInsertParameters(SqlCommand cm)
        {
            cm.Parameters.AddWithValue("@MaBoPhan", _maBoPhan);
            cm.Parameters.AddWithValue("@NgayPhep", _ngayPhep);
            if (_ghiChu.Length > 0)
                cm.Parameters.AddWithValue("@GhiChu", _ghiChu);
            else
                cm.Parameters.AddWithValue("@GhiChu", DBNull.Value);
            cm.Parameters.AddWithValue("@NewBoPhan_NgayPhepID", _bophanNgayphepid);
            cm.Parameters["@NewBoPhan_NgayPhepID"].Direction = ParameterDirection.Output;
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
                cm.CommandText = "UpdateBoPhan_NgayPhep";

                AddUpdateParameters(cm);

                cm.ExecuteNonQuery();

            }//using
        }

        private void AddUpdateParameters(SqlCommand cm)
        {
            cm.Parameters.AddWithValue("@BoPhan_NgayPhepID", _bophanNgayphepid);
            cm.Parameters.AddWithValue("@MaBoPhan", _maBoPhan);
            cm.Parameters.AddWithValue("@NgayPhep", _ngayPhep);
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

            ExecuteDelete(tr, new Criteria(_bophanNgayphepid));
            MarkNew();
        }
        #endregion //Data Access - Delete
        #endregion //Data Access
    }
}
