
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{
    [Serializable()]
    public class LuuTruCapPhatHoaDon : Csla.BusinessBase<LuuTruCapPhatHoaDon>
    {
        #region Business Properties and Methods

        //declare members
        private int _id = 0;
        private string _tenTT = string.Empty;
        private DateTime _ngayCap = DateTime.Now;
        private int _tuSo = 0;
        private int _denSo = 0;
        private string _kyHieu = string.Empty;
        private string _ghiChu = string.Empty;

        [System.ComponentModel.DataObjectField(true, true)]
        public int Id
        {
            get
            {
                CanReadProperty("Id", true);
                return _id;
            }
        }

        public string TenTT
        {
            get
            {
                CanReadProperty("TenTT", true);
                return _tenTT;
            }
            set
            {
                CanWriteProperty("TenTT", true);
                if (value == null) value = string.Empty;
                if (!_tenTT.Equals(value))
                {
                    _tenTT = value;
                    PropertyHasChanged("TenTT");
                }
            }
        }

        public DateTime NgayCap
        {
            get
            {
                CanReadProperty("NgayCap", true);
                return _ngayCap.Date;
            }
            set
            {
                CanWriteProperty( true);               
                if (!_ngayCap.Equals(value))
                {
                    _ngayCap = value;
                    PropertyHasChanged();
                }
            }
        }
      
        public int TuSo
        {
            get
            {
                CanReadProperty("TuSo", true);
                return _tuSo;
            }
            set
            {
                CanWriteProperty("TuSo", true);
                if (!_tuSo.Equals(value))
                {
                    _tuSo = value;
                    PropertyHasChanged("TuSo");
                }
            }
        }

        public int DenSo
        {
            get
            {
                CanReadProperty("DenSo", true);
                return _denSo;
            }
            set
            {
                CanWriteProperty("DenSo", true);
                if (!_denSo.Equals(value))
                {
                    _denSo = value;
                    PropertyHasChanged("DenSo");
                }
            }
        }

        public string KyHieu
        {
            get
            {
                CanReadProperty("KyHieu", true);
                return _kyHieu;
            }
            set
            {
                CanWriteProperty("KyHieu", true);
                if (value == null) value = string.Empty;
                if (!_kyHieu.Equals(value))
                {
                    _kyHieu = value;
                    PropertyHasChanged("KyHieu");
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
            //
            // TenTT
            //

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
            //TODO: Define authorization rules in LuuTruCapPhatHoaDon
            //AuthorizationRules.AllowRead("Id", "LuuTruCapPhatHoaDonReadGroup");
            //AuthorizationRules.AllowRead("TenTT", "LuuTruCapPhatHoaDonReadGroup");
            //AuthorizationRules.AllowRead("NgayCap", "LuuTruCapPhatHoaDonReadGroup");
            //AuthorizationRules.AllowRead("NgayCapString", "LuuTruCapPhatHoaDonReadGroup");
            //AuthorizationRules.AllowRead("TuSo", "LuuTruCapPhatHoaDonReadGroup");
            //AuthorizationRules.AllowRead("DenSo", "LuuTruCapPhatHoaDonReadGroup");
            //AuthorizationRules.AllowRead("KyHieu", "LuuTruCapPhatHoaDonReadGroup");
            //AuthorizationRules.AllowRead("GhiChu", "LuuTruCapPhatHoaDonReadGroup");

            //AuthorizationRules.AllowWrite("TenTT", "LuuTruCapPhatHoaDonWriteGroup");
            //AuthorizationRules.AllowWrite("NgayCapString", "LuuTruCapPhatHoaDonWriteGroup");
            //AuthorizationRules.AllowWrite("TuSo", "LuuTruCapPhatHoaDonWriteGroup");
            //AuthorizationRules.AllowWrite("DenSo", "LuuTruCapPhatHoaDonWriteGroup");
            //AuthorizationRules.AllowWrite("KyHieu", "LuuTruCapPhatHoaDonWriteGroup");
            //AuthorizationRules.AllowWrite("GhiChu", "LuuTruCapPhatHoaDonWriteGroup");
        }


        public static bool CanGetObject()
        {
            //TODO: Define CanGetObject permission in LuuTruCapPhatHoaDon
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("LuuTruCapPhatHoaDonViewGroup"))
            //	return true;
            //return false;
        }

        public static bool CanAddObject()
        {
            //TODO: Define CanAddObject permission in LuuTruCapPhatHoaDon
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("LuuTruCapPhatHoaDonAddGroup"))
            //	return true;
            //return false;
        }

        public static bool CanEditObject()
        {
            //TODO: Define CanEditObject permission in LuuTruCapPhatHoaDon
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("LuuTruCapPhatHoaDonEditGroup"))
            //	return true;
            //return false;
        }

        public static bool CanDeleteObject()
        {
            //TODO: Define CanDeleteObject permission in LuuTruCapPhatHoaDon
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("LuuTruCapPhatHoaDonDeleteGroup"))
            //	return true;
            //return false;
        }
        #endregion //Authorization Rules

        #region Factory Methods
        private LuuTruCapPhatHoaDon()
        { /* require use of factory method */ }

        public static LuuTruCapPhatHoaDon NewLuuTruCapPhatHoaDon()
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a LuuTruCapPhatHoaDon");
            return DataPortal.Create<LuuTruCapPhatHoaDon>();
        }

        public static LuuTruCapPhatHoaDon GetLuuTruCapPhatHoaDon(int id)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a LuuTruCapPhatHoaDon");
            return DataPortal.Fetch<LuuTruCapPhatHoaDon>(new Criteria(id));
        }

        public static void DeleteLuuTruCapPhatHoaDon(int id)
        {
            if (!CanDeleteObject())
                throw new System.Security.SecurityException("User not authorized to remove a LuuTruCapPhatHoaDon");
            DataPortal.Delete(new Criteria(id));
        }

        public override LuuTruCapPhatHoaDon Save()
        {
            if (IsDeleted && !CanDeleteObject())
                throw new System.Security.SecurityException("User not authorized to remove a LuuTruCapPhatHoaDon");
            else if (IsNew && !CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a LuuTruCapPhatHoaDon");
            else if (!CanEditObject())
                throw new System.Security.SecurityException("User not authorized to update a LuuTruCapPhatHoaDon");

            return base.Save();
        }

        #endregion //Factory Methods

        #region Child Factory Methods
        internal static LuuTruCapPhatHoaDon NewLuuTruCapPhatHoaDonChild()
        {
            LuuTruCapPhatHoaDon child = new LuuTruCapPhatHoaDon();
            child.ValidationRules.CheckRules();
            child.MarkAsChild();
            return child;
        }

        internal static LuuTruCapPhatHoaDon GetLuuTruCapPhatHoaDon(SafeDataReader dr)
        {
            LuuTruCapPhatHoaDon child = new LuuTruCapPhatHoaDon();
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
            public int Id;

            public Criteria(int id)
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
                cm.CommandText = "[spd_SelecttblLuuTruHoaDon]";

                cm.Parameters.AddWithValue("@ID", criteria.Id);

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
                cm.CommandText = "[spd_DeletetblLuuTruHoaDon]";

                cm.Parameters.AddWithValue("@ID", criteria.Id);

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
            _id = dr.GetInt32("ID");
            _tenTT = dr.GetString("TenTT");
            _ngayCap = dr.GetDateTime("NgayCap");
            _tuSo = dr.GetInt32("TuSo");
            _denSo = dr.GetInt32("DenSo");
            _kyHieu = dr.GetString("KyHieu");
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
                cm.CommandText = "[spd_InserttblLuuTruHoaDon]";

                AddInsertParameters(cm);

                cm.ExecuteNonQuery();

                _id = (int)cm.Parameters["@ID"].Value;
            }//using
        }

        private void AddInsertParameters(SqlCommand cm)
        {
            if (_tenTT.Length > 0)
                cm.Parameters.AddWithValue("@TenTT", _tenTT);
            else
                cm.Parameters.AddWithValue("@TenTT", DBNull.Value);
            cm.Parameters.AddWithValue("@NgayCap", _ngayCap.Date);
            if (_tuSo != 0)
                cm.Parameters.AddWithValue("@TuSo", _tuSo);
            else
                cm.Parameters.AddWithValue("@TuSo", DBNull.Value);
            if (_denSo != 0)
                cm.Parameters.AddWithValue("@DenSo", _denSo);
            else
                cm.Parameters.AddWithValue("@DenSo", DBNull.Value);
            if (_kyHieu.Length > 0)
                cm.Parameters.AddWithValue("@KyHieu", _kyHieu);
            else
                cm.Parameters.AddWithValue("@KyHieu", DBNull.Value);
            if (_ghiChu.Length > 0)
                cm.Parameters.AddWithValue("@GhiChu", _ghiChu);
            else
                cm.Parameters.AddWithValue("@GhiChu", DBNull.Value);
            cm.Parameters.AddWithValue("@ID", _id);
            cm.Parameters["@ID"].Direction = ParameterDirection.Output;
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
                cm.CommandText = "[spd_UpdatetblLuuTruHoaDon]";

                AddUpdateParameters(cm);

                cm.ExecuteNonQuery();

            }//using
        }

        private void AddUpdateParameters(SqlCommand cm)
        {
            cm.Parameters.AddWithValue("@ID", _id);
            if (_tenTT.Length > 0)
                cm.Parameters.AddWithValue("@TenTT", _tenTT);
            else
                cm.Parameters.AddWithValue("@TenTT", DBNull.Value);
            cm.Parameters.AddWithValue("@NgayCap", _ngayCap.Date);
            if (_tuSo != 0)
                cm.Parameters.AddWithValue("@TuSo", _tuSo);
            else
                cm.Parameters.AddWithValue("@TuSo", DBNull.Value);
            if (_denSo != 0)
                cm.Parameters.AddWithValue("@DenSo", _denSo);
            else
                cm.Parameters.AddWithValue("@DenSo", DBNull.Value);
            if (_kyHieu.Length > 0)
                cm.Parameters.AddWithValue("@KyHieu", _kyHieu);
            else
                cm.Parameters.AddWithValue("@KyHieu", DBNull.Value);
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

            ExecuteDelete(tr, new Criteria(_id));
            MarkNew();
        }
        #endregion //Data Access - Delete
        #endregion //Data Access
    }
}
