
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{
    [Serializable()]
    public class HangCungCapBQ_VT : Csla.BusinessBase<HangCungCapBQ_VT>
    {
        #region Business Properties and Methods

        //declare members
        private int _maHangCungCap = 0;
        private long _maNhaCungCap = 0;
        private int _maHangHoa = 0;

        [System.ComponentModel.DataObjectField(true, true)]
        public int MaHangCungCap
        {
            get
            {
                CanReadProperty("MaHangCungCap", true);
                return _maHangCungCap;
            }
        }

        public long MaNhaCungCap
        {
            get
            {
                CanReadProperty("MaNhaCungCap", true);
                return _maNhaCungCap;
            }
            set
            {
                CanWriteProperty("MaNhaCungCap", true);
                if (!_maNhaCungCap.Equals(value))
                {
                    _maNhaCungCap = value;
                    PropertyHasChanged("MaNhaCungCap");
                }
            }
        }

        public int MaHangHoa
        {
            get
            {
                CanReadProperty("MaHangHoa", true);
                return _maHangHoa;
            }
            set
            {
                CanWriteProperty("MaHangHoa", true);
                if (!_maHangHoa.Equals(value))
                {
                    _maHangHoa = value;
                    PropertyHasChanged("MaHangHoa");
                }
            }
        }

        protected override object GetIdValue()
        {
            return _maHangCungCap;
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
            //TODO: Define authorization rules in HangCungCapBQ_VT
            //AuthorizationRules.AllowRead("MaHangCungCap", "HangCungCapBQ_VTReadGroup");
            //AuthorizationRules.AllowRead("MaNhaCungCap", "HangCungCapBQ_VTReadGroup");
            //AuthorizationRules.AllowRead("MaHangHoa", "HangCungCapBQ_VTReadGroup");

            //AuthorizationRules.AllowWrite("MaNhaCungCap", "HangCungCapBQ_VTWriteGroup");
            //AuthorizationRules.AllowWrite("MaHangHoa", "HangCungCapBQ_VTWriteGroup");
        }


        public static bool CanGetObject()
        {
            //TODO: Define CanGetObject permission in HangCungCapBQ_VT
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("HangCungCapBQ_VTViewGroup"))
            //	return true;
            //return false;
        }

        public static bool CanAddObject()
        {
            //TODO: Define CanAddObject permission in HangCungCapBQ_VT
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("HangCungCapBQ_VTAddGroup"))
            //	return true;
            //return false;
        }

        public static bool CanEditObject()
        {
            //TODO: Define CanEditObject permission in HangCungCapBQ_VT
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("HangCungCapBQ_VTEditGroup"))
            //	return true;
            //return false;
        }

        public static bool CanDeleteObject()
        {
            //TODO: Define CanDeleteObject permission in HangCungCapBQ_VT
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("HangCungCapBQ_VTDeleteGroup"))
            //	return true;
            //return false;
        }
        #endregion //Authorization Rules

        #region Factory Methods
        private HangCungCapBQ_VT()
        { /* require use of factory method */ }

        public static HangCungCapBQ_VT NewHangCungCapBQ_VT()
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a HangCungCapBQ_VT");
            return DataPortal.Create<HangCungCapBQ_VT>();
        }

        public static HangCungCapBQ_VT GetHangCungCapBQ_VT(int maHangCungCap)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a HangCungCapBQ_VT");
            return DataPortal.Fetch<HangCungCapBQ_VT>(new Criteria(maHangCungCap));
        }

        public static void DeleteHangCungCapBQ_VT(int maHangCungCap)
        {
            if (!CanDeleteObject())
                throw new System.Security.SecurityException("User not authorized to remove a HangCungCapBQ_VT");
            DataPortal.Delete(new Criteria(maHangCungCap));
        }

        public override HangCungCapBQ_VT Save()
        {
            if (IsDeleted && !CanDeleteObject())
                throw new System.Security.SecurityException("User not authorized to remove a HangCungCapBQ_VT");
            else if (IsNew && !CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a HangCungCapBQ_VT");
            else if (!CanEditObject())
                throw new System.Security.SecurityException("User not authorized to update a HangCungCapBQ_VT");

            return base.Save();
        }

        #endregion //Factory Methods

        #region Child Factory Methods
        internal static HangCungCapBQ_VT NewHangCungCapBQ_VTChild()
        {
            HangCungCapBQ_VT child = new HangCungCapBQ_VT();
            child.ValidationRules.CheckRules();
            child.MarkAsChild();
            return child;
        }

        internal static HangCungCapBQ_VT GetHangCungCapBQ_VT(SafeDataReader dr)
        {
            HangCungCapBQ_VT child = new HangCungCapBQ_VT();
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
            public int MaHangCungCap;

            public Criteria(int maHangCungCap)
            {
                this.MaHangCungCap = maHangCungCap;
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
                cm.CommandText = "spd_SelecttblHangCungCap";

                cm.Parameters.AddWithValue("@MaHangCungCap", criteria.MaHangCungCap);

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
            DataPortal_Delete(new Criteria(_maHangCungCap));
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
                cm.CommandText = "spd_DeletetblHangCungCap";

                cm.Parameters.AddWithValue("@MaHangCungCap", criteria.MaHangCungCap);

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
            _maHangCungCap = dr.GetInt32("MaHangCungCap");
            _maNhaCungCap = dr.GetInt64("MaNhaCungCap");
            _maHangHoa = dr.GetInt32("MaHangHoa");
        }

        private void FetchChildren(SafeDataReader dr)
        {
        }
        #endregion //Data Access - Fetch

        #region Data Access - Insert
        internal void Insert(SqlTransaction tr, HangCungCapBQ_VTList parent)
        {
            if (!IsDirty) return;

            ExecuteInsert(tr, parent);
            MarkOld();

            //update child object(s)
            UpdateChildren(tr);
        }

        private void ExecuteInsert(SqlTransaction tr, HangCungCapBQ_VTList parent)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_InserttblHangCungCap";

                AddInsertParameters(cm, parent);

                cm.ExecuteNonQuery();

                _maHangCungCap = (int)cm.Parameters["@MaHangCungCap"].Value;
            }//using
        }

        private void AddInsertParameters(SqlCommand cm, HangCungCapBQ_VTList parent)
        {
            //TODO: if parent use identity key, fix fk member with value from parent
            if (_maNhaCungCap != 0)
                cm.Parameters.AddWithValue("@MaNhaCungCap", _maNhaCungCap);
            else
                cm.Parameters.AddWithValue("@MaNhaCungCap", DBNull.Value);
            if (_maHangHoa != 0)
                cm.Parameters.AddWithValue("@MaHangHoa", _maHangHoa);
            else
                cm.Parameters.AddWithValue("@MaHangHoa", DBNull.Value);
            cm.Parameters.AddWithValue("@MaHangCungCap", _maHangCungCap);
            cm.Parameters["@MaHangCungCap"].Direction = ParameterDirection.Output;
        }
        #endregion //Data Access - Insert

        #region Data Access - Update
        internal void Update(SqlTransaction tr, HangCungCapBQ_VTList parent)
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

        private void ExecuteUpdate(SqlTransaction tr, HangCungCapBQ_VTList parent)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_UpdatetblHangCungCap";

                AddUpdateParameters(cm, parent);

                cm.ExecuteNonQuery();

            }//using
        }

        private void AddUpdateParameters(SqlCommand cm, HangCungCapBQ_VTList parent)
        {
            cm.Parameters.AddWithValue("@MaHangCungCap", _maHangCungCap);
            if (_maNhaCungCap != 0)
                cm.Parameters.AddWithValue("@MaNhaCungCap", _maNhaCungCap);
            else
                cm.Parameters.AddWithValue("@MaNhaCungCap", DBNull.Value);
            if (_maHangHoa != 0)
                cm.Parameters.AddWithValue("@MaHangHoa", _maHangHoa);
            else
                cm.Parameters.AddWithValue("@MaHangHoa", DBNull.Value);
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

            ExecuteDelete(tr, new Criteria(_maHangCungCap));
            MarkNew();
        }
        #endregion //Data Access - Delete
        #endregion //Data Access
    }
}
