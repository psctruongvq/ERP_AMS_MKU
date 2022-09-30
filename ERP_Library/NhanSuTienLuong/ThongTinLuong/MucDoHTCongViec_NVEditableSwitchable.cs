
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{
    [Serializable()]
    public class MucDoHTCongViec_NV : Csla.BusinessBase<MucDoHTCongViec_NV>
    {
        #region Business Properties and Methods

        //declare members
        private long _maMucDoHTCongViec = 0;
        private long _maNhanVien = 0;
        private string _tenNhanvien = string.Empty;
        private string _MaqlNhanvien = string.Empty;
        private int _maMucDo = 0;
        private string _Tenmucdo=string.Empty;
        private int _maKy = 0;
        private string _Kyluong = string.Empty;

        [System.ComponentModel.DataObjectField(true, true)]
        public long MaMucDoHTCongViec
        {
            get
            {
                CanReadProperty("MaMucDoHTCongViec", true);
                return _maMucDoHTCongViec;
            }
        }

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
        public string Tennhanvien
        {
            get
            {
                CanReadProperty(true);
                return _tenNhanvien;
            }
            set
            {
                CanWriteProperty(true);
                if (value == null) value = string.Empty;
                if (!_tenNhanvien.Equals(value))
                {
                    _tenNhanvien = value;
                    PropertyHasChanged();
                }
            }
        }
        public string MaqlNhanvien
        {
            get
            {
                CanReadProperty(true);
                return _MaqlNhanvien;
            }
            set
            {
                CanWriteProperty(true);
                if (value == null) value = string.Empty;
                if (!_MaqlNhanvien.Equals(value))
                {
                    _MaqlNhanvien = value;
                    PropertyHasChanged();
                }
            }
        }
        public int MaMucDo
        {
            get
            {
                CanReadProperty("MaMucDo", true);
                return _maMucDo;
            }
            set
            {
                CanWriteProperty("MaMucDo", true);
                if (!_maMucDo.Equals(value))
                {
                    _maMucDo = value;
                    PropertyHasChanged("MaMucDo");
                }
            }
        }
        public string Tenmucdo
        {
            get
            {
                CanReadProperty(true);
                return _Tenmucdo;
            }
            set
            {
                CanWriteProperty(true);
                if (value == null) value = string.Empty;
                if (!_Tenmucdo.Equals(value))
                {
                    _Tenmucdo = value;
                    PropertyHasChanged();
                }
            }
        }
        public int MaKy
        {
            get
            {
                CanReadProperty("MaKy", true);
                return _maKy;
            }
            set
            {
                CanWriteProperty("MaKy", true);
                if (!_maKy.Equals(value))
                {
                    _maKy = value;
                    PropertyHasChanged("MaKy");
                }
            }
        }
        public string Kyluong
        {
            get
            {
                CanReadProperty(true);
                return _Kyluong;
            }
            set
            {
                CanWriteProperty(true);
                if (value == null) value = string.Empty;
                if (!_Kyluong.Equals(value))
                {
                    _Kyluong = value;
                    PropertyHasChanged();
                }
            }
        }
        protected override object GetIdValue()
        {
            return _maMucDoHTCongViec;
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
            //TODO: Define authorization rules in MucDoHTCongViec_NV
            //AuthorizationRules.AllowRead("MaMucDoHTCongViec", "MucDoHTCongViec_NVReadGroup");
            //AuthorizationRules.AllowRead("MaNhanVien", "MucDoHTCongViec_NVReadGroup");
            //AuthorizationRules.AllowRead("MaMucDo", "MucDoHTCongViec_NVReadGroup");
            //AuthorizationRules.AllowRead("MaKy", "MucDoHTCongViec_NVReadGroup");

            //AuthorizationRules.AllowWrite("MaNhanVien", "MucDoHTCongViec_NVWriteGroup");
            //AuthorizationRules.AllowWrite("MaMucDo", "MucDoHTCongViec_NVWriteGroup");
            //AuthorizationRules.AllowWrite("MaKy", "MucDoHTCongViec_NVWriteGroup");
        }


        public static bool CanGetObject()
        {
            //TODO: Define CanGetObject permission in MucDoHTCongViec_NV
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("MucDoHTCongViec_NVViewGroup"))
            //	return true;
            //return false;
        }

        public static bool CanAddObject()
        {
            //TODO: Define CanAddObject permission in MucDoHTCongViec_NV
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("MucDoHTCongViec_NVAddGroup"))
            //	return true;
            //return false;
        }

        public static bool CanEditObject()
        {
            //TODO: Define CanEditObject permission in MucDoHTCongViec_NV
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("MucDoHTCongViec_NVEditGroup"))
            //	return true;
            //return false;
        }

        public static bool CanDeleteObject()
        {
            //TODO: Define CanDeleteObject permission in MucDoHTCongViec_NV
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("MucDoHTCongViec_NVDeleteGroup"))
            //	return true;
            //return false;
        }
        #endregion //Authorization Rules

        #region Factory Methods
        private MucDoHTCongViec_NV()
        { /* require use of factory method */ }

        public static MucDoHTCongViec_NV NewMucDoHTCongViec_NV()
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a MucDoHTCongViec_NV");
            return DataPortal.Create<MucDoHTCongViec_NV>();
        }

        public static MucDoHTCongViec_NV GetMucDoHTCongViec_NV(long maMucDoHTCongViec)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a MucDoHTCongViec_NV");
            return DataPortal.Fetch<MucDoHTCongViec_NV>(new Criteria(maMucDoHTCongViec));
        }

        public static void DeleteMucDoHTCongViec_NV(long maMucDoHTCongViec)
        {
            if (!CanDeleteObject())
                throw new System.Security.SecurityException("User not authorized to remove a MucDoHTCongViec_NV");
            DataPortal.Delete(new Criteria(maMucDoHTCongViec));
        }

        public override MucDoHTCongViec_NV Save()
        {
            if (IsDeleted && !CanDeleteObject())
                throw new System.Security.SecurityException("User not authorized to remove a MucDoHTCongViec_NV");
            else if (IsNew && !CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a MucDoHTCongViec_NV");
            else if (!CanEditObject())
                throw new System.Security.SecurityException("User not authorized to update a MucDoHTCongViec_NV");

            return base.Save();
        }

        #endregion //Factory Methods

        #region Child Factory Methods
        internal static MucDoHTCongViec_NV NewMucDoHTCongViec_NVChild()
        {
            MucDoHTCongViec_NV child = new MucDoHTCongViec_NV();
            child.ValidationRules.CheckRules();
            child.MarkAsChild();
            return child;
        }

        internal static MucDoHTCongViec_NV GetMucDoHTCongViec_NV(SafeDataReader dr)
        {
            MucDoHTCongViec_NV child = new MucDoHTCongViec_NV();
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
            public long MaMucDoHTCongViec;

            public Criteria(long maMucDoHTCongViec)
            {
                this.MaMucDoHTCongViec = maMucDoHTCongViec;
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
                cm.CommandText = "spd_SelecttblnsMucDoHTCongViec_NV";

                cm.Parameters.AddWithValue("@MaMucDoHTCongViec", criteria.MaMucDoHTCongViec);

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
            DataPortal_Delete(new Criteria(_maMucDoHTCongViec));
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
                cm.CommandText = "spd_DeletetblnsMucDoHTCongViec_NV";

                cm.Parameters.AddWithValue("@MaMucDoHTCongViec", criteria.MaMucDoHTCongViec);

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
            _maMucDoHTCongViec = dr.GetInt64("MaMucDoHTCongViec");
            _maNhanVien = dr.GetInt64("MaNhanVien");
            _tenNhanvien = dr.GetString("TennhanVien");
            _MaqlNhanvien = dr.GetString("MaQlNhanVien");
            _maMucDo = dr.GetInt32("MaMucDo");
            _Tenmucdo = dr.GetString("Tenmucdo");            
            _maKy = dr.GetInt32("MaKy");
            _Kyluong = dr.GetString("Tenky");
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
                cm.CommandText = "spd_inserttblnsMucDoHTCongViec_NV";

                AddInsertParameters(cm);

                cm.ExecuteNonQuery();

                _maMucDoHTCongViec = (long)cm.Parameters["@MaMucDoHTCongViec"].Value;
            }//using
        }

        private void AddInsertParameters(SqlCommand cm)
        {
            if (_maNhanVien != 0)
                cm.Parameters.AddWithValue("@MaNhanVien", _maNhanVien);
            else
                cm.Parameters.AddWithValue("@MaNhanVien", DBNull.Value);
            if (_maMucDo != 0)
                cm.Parameters.AddWithValue("@MaMucDo", _maMucDo);
            else
                cm.Parameters.AddWithValue("@MaMucDo", DBNull.Value);
            if (_maKy != 0)
                cm.Parameters.AddWithValue("@MaKy", _maKy);
            else
                cm.Parameters.AddWithValue("@MaKy", DBNull.Value);
            cm.Parameters.AddWithValue("@MaMucDoHTCongViec", _maMucDoHTCongViec);
            cm.Parameters["@MaMucDoHTCongViec"].Direction = ParameterDirection.Output;
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
                cm.CommandText = "spd_UpdatetblnsMucDoHTCongViec_NV";

                AddUpdateParameters(cm);

                cm.ExecuteNonQuery();

            }//using
        }

        private void AddUpdateParameters(SqlCommand cm)
        {
            cm.Parameters.AddWithValue("@MaMucDoHTCongViec", _maMucDoHTCongViec);
            if (_maNhanVien != 0)
                cm.Parameters.AddWithValue("@MaNhanVien", _maNhanVien);
            else
                cm.Parameters.AddWithValue("@MaNhanVien", DBNull.Value);
            if (_maMucDo != 0)
                cm.Parameters.AddWithValue("@MaMucDo", _maMucDo);
            else
                cm.Parameters.AddWithValue("@MaMucDo", DBNull.Value);
            if (_maKy != 0)
                cm.Parameters.AddWithValue("@MaKy", _maKy);
            else
                cm.Parameters.AddWithValue("@MaKy", DBNull.Value);
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

            ExecuteDelete(tr, new Criteria(_maMucDoHTCongViec));
            MarkNew();
        }
        #endregion //Data Access - Delete
        #endregion //Data Access
    }
}
