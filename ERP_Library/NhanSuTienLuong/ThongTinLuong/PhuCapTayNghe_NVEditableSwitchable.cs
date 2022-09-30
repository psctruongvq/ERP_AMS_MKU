
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{
    [Serializable()]
    public class PhuCapTayNghe_NV : Csla.BusinessBase<PhuCapTayNghe_NV>
    {
        #region Business Properties and Methods

        //declare members
        private long _maphuccaptayngheNv = 0;
        private long _maNhanVien = 0;
        private string _tenNhanvien = string.Empty;
        private string _MaqlNhanvien = string.Empty;
        private int _maTayNghe = 0;
        private string _tentaynghe = string.Empty;
        private int _maKyTinhLuong = 0;
        private string _Kyluong = string.Empty;

        [System.ComponentModel.DataObjectField(true, true)]
        public long MaphuccaptayngheNv
        {
            get
            {
                CanReadProperty("MaphuccaptayngheNv", true);
                return _maphuccaptayngheNv;
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

        public int MaTayNghe
        {
            get
            {
                CanReadProperty("MaTayNghe", true);
                return _maTayNghe;
            }
            set
            {
                CanWriteProperty("MaTayNghe", true);
                if (!_maTayNghe.Equals(value))
                {
                    _maTayNghe = value;
                    PropertyHasChanged("MaTayNghe");
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
        public string Tentaynghe
        {
            get
            {
                CanReadProperty(true);
                return _tentaynghe;
            }
            set
            {
                CanWriteProperty(true);
                if (value == null) value = string.Empty;
                if (!_tentaynghe.Equals(value))
                {
                    _tentaynghe = value;
                    PropertyHasChanged();
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
            return _maphuccaptayngheNv;
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
            //TODO: Define authorization rules in PhuCapTayNghe_NV
            //AuthorizationRules.AllowRead("MaphuccaptayngheNv", "PhuCapTayNghe_NVReadGroup");
            //AuthorizationRules.AllowRead("MaNhanVien", "PhuCapTayNghe_NVReadGroup");
            //AuthorizationRules.AllowRead("MaTayNghe", "PhuCapTayNghe_NVReadGroup");
            //AuthorizationRules.AllowRead("MaKyTinhLuong", "PhuCapTayNghe_NVReadGroup");

            //AuthorizationRules.AllowWrite("MaNhanVien", "PhuCapTayNghe_NVWriteGroup");
            //AuthorizationRules.AllowWrite("MaTayNghe", "PhuCapTayNghe_NVWriteGroup");
            //AuthorizationRules.AllowWrite("MaKyTinhLuong", "PhuCapTayNghe_NVWriteGroup");
        }


        public static bool CanGetObject()
        {
            //TODO: Define CanGetObject permission in PhuCapTayNghe_NV
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("PhuCapTayNghe_NVViewGroup"))
            //	return true;
            //return false;
        }

        public static bool CanAddObject()
        {
            //TODO: Define CanAddObject permission in PhuCapTayNghe_NV
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("PhuCapTayNghe_NVAddGroup"))
            //	return true;
            //return false;
        }

        public static bool CanEditObject()
        {
            //TODO: Define CanEditObject permission in PhuCapTayNghe_NV
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("PhuCapTayNghe_NVEditGroup"))
            //	return true;
            //return false;
        }

        public static bool CanDeleteObject()
        {
            //TODO: Define CanDeleteObject permission in PhuCapTayNghe_NV
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("PhuCapTayNghe_NVDeleteGroup"))
            //	return true;
            //return false;
        }
        #endregion //Authorization Rules

        #region Factory Methods
        private PhuCapTayNghe_NV()
        { /* require use of factory method */ }

        public static PhuCapTayNghe_NV NewPhuCapTayNghe_NV()
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a PhuCapTayNghe_NV");
            return DataPortal.Create<PhuCapTayNghe_NV>();
        }

        public static PhuCapTayNghe_NV GetPhuCapTayNghe_NV(long maphuccaptayngheNv)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a PhuCapTayNghe_NV");
            return DataPortal.Fetch<PhuCapTayNghe_NV>(new Criteria(maphuccaptayngheNv));
        }

        public static void DeletePhuCapTayNghe_NV(long maphuccaptayngheNv)
        {
            if (!CanDeleteObject())
                throw new System.Security.SecurityException("User not authorized to remove a PhuCapTayNghe_NV");
            DataPortal.Delete(new Criteria(maphuccaptayngheNv));
        }

        public override PhuCapTayNghe_NV Save()
        {
            if (IsDeleted && !CanDeleteObject())
                throw new System.Security.SecurityException("User not authorized to remove a PhuCapTayNghe_NV");
            else if (IsNew && !CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a PhuCapTayNghe_NV");
            else if (!CanEditObject())
                throw new System.Security.SecurityException("User not authorized to update a PhuCapTayNghe_NV");

            return base.Save();
        }

        #endregion //Factory Methods

        #region Child Factory Methods
        internal static PhuCapTayNghe_NV NewPhuCapTayNghe_NVChild()
        {
            PhuCapTayNghe_NV child = new PhuCapTayNghe_NV();
            child.ValidationRules.CheckRules();
            child.MarkAsChild();
            return child;
        }

        internal static PhuCapTayNghe_NV GetPhuCapTayNghe_NV(SafeDataReader dr)
        {
            PhuCapTayNghe_NV child = new PhuCapTayNghe_NV();
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
            public long MaphuccaptayngheNv;

            public Criteria(long maphuccaptayngheNv)
            {
                this.MaphuccaptayngheNv = maphuccaptayngheNv;
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
                cm.CommandText = "spd_selecttblnsPhuCapTayNghe_NV";

                cm.Parameters.AddWithValue("@MaPhucCapTayNghe_NV", criteria.MaphuccaptayngheNv);

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
            DataPortal_Delete(new Criteria(_maphuccaptayngheNv));
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
                cm.CommandText = "spd_DeletetblnsPhuCapTayNghe_NV";

                cm.Parameters.AddWithValue("@MaPhucCapTayNghe_NV", criteria.MaphuccaptayngheNv);

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
            
            _maphuccaptayngheNv = dr.GetInt64("MaPhucCapTayNghe_NV");
            _maNhanVien = dr.GetInt64("MaNhanVien");
            _tenNhanvien = dr.GetString("Tennhanvien");
            _MaqlNhanvien = dr.GetString("MaQlNhanVien");                                 
            _maTayNghe = dr.GetInt32("MaTayNghe");
            _tentaynghe = dr.GetString("Taynghe");
            _maKyTinhLuong = dr.GetInt32("MaKyTinhLuong");
            _Kyluong = dr.GetString("Kyluong");
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
                cm.CommandText = "spd_InserttblnsPhuCapTayNghe_NV";

                AddInsertParameters(cm);

                cm.ExecuteNonQuery();

                _maphuccaptayngheNv = (long)cm.Parameters["@MaPhucCapTayNghe_NV"].Value;
            }//using
        }

        private void AddInsertParameters(SqlCommand cm)
        {
            if (_maNhanVien != 0)
                cm.Parameters.AddWithValue("@MaNhanVien", _maNhanVien);
            else
                cm.Parameters.AddWithValue("@MaNhanVien", DBNull.Value);
            if (_maTayNghe != 0)
                cm.Parameters.AddWithValue("@MaTayNghe", _maTayNghe);
            else
                cm.Parameters.AddWithValue("@MaTayNghe", DBNull.Value);
            if (_maKyTinhLuong != 0)
                cm.Parameters.AddWithValue("@MaKyTinhLuong", _maKyTinhLuong);
            else
                cm.Parameters.AddWithValue("@MaKyTinhLuong", DBNull.Value);
            cm.Parameters.AddWithValue("@MaPhucCapTayNghe_NV", _maphuccaptayngheNv);
            cm.Parameters["@MaPhucCapTayNghe_NV"].Direction = ParameterDirection.Output;
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
                cm.CommandText = "spd_UpdatetblnsPhuCapTayNghe_NV";

                AddUpdateParameters(cm);

                cm.ExecuteNonQuery();

            }//using
        }

        private void AddUpdateParameters(SqlCommand cm)
        {
            cm.Parameters.AddWithValue("@MaPhucCapTayNghe_NV", _maphuccaptayngheNv);
            if (_maNhanVien != 0)
                cm.Parameters.AddWithValue("@MaNhanVien", _maNhanVien);
            else
                cm.Parameters.AddWithValue("@MaNhanVien", DBNull.Value);
            if (_maTayNghe != 0)
                cm.Parameters.AddWithValue("@MaTayNghe", _maTayNghe);
            else
                cm.Parameters.AddWithValue("@MaTayNghe", DBNull.Value);
            if (_maKyTinhLuong != 0)
                cm.Parameters.AddWithValue("@MaKyTinhLuong", _maKyTinhLuong);
            else
                cm.Parameters.AddWithValue("@MaKyTinhLuong", DBNull.Value);
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

            ExecuteDelete(tr, new Criteria(_maphuccaptayngheNv));
            MarkNew();
        }
        #endregion //Data Access - Delete
        #endregion //Data Access
    }
}
