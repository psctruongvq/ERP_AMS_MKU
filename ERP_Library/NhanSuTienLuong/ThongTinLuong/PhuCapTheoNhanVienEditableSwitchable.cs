
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{
    [Serializable()]
    public class PhuCapTheoNhanVien : Csla.BusinessBase<PhuCapTheoNhanVien>
    {
        #region Business Properties and Methods

        //declare members
        private int _maPhuCapTheoNhanVien = 0;
        private long _maNhanVien = 0;
        private int _maLoaiPhuCap = 0;
        private string _tenloaiphucap = string.Empty;
        private string _maQlnhanvien = string.Empty;
        private string _tennhanvien = string.Empty;
        private decimal _soTien = 0;
        private string _ghiChu = string.Empty;

        [System.ComponentModel.DataObjectField(true, true)]
        public int MaPhuCapTheoNhanVien
        {
            get
            {
                CanReadProperty("MaPhuCapTheoNhanVien", true);
                return _maPhuCapTheoNhanVien;
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

        public int MaLoaiPhuCap
        {
            get
            {
                CanReadProperty("MaLoaiPhuCap", true);
                return _maLoaiPhuCap;
            }
            set
            {
                CanWriteProperty("MaLoaiPhuCap", true);
                if (!_maLoaiPhuCap.Equals(value))
                {
                    _maLoaiPhuCap = value;
                    PropertyHasChanged("MaLoaiPhuCap");
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
        public string TenLoaiPhuCap
        {
            get
            {
                CanReadProperty( true);
                return _tenloaiphucap;
            }
            set
            {
                CanWriteProperty( true);
                if (value == null) value = string.Empty;
                if (!_tenloaiphucap.Equals(value))
                {
                    _tenloaiphucap = value;
                    PropertyHasChanged();
                }
            }
        }
        public string Tennhanvien
        {
            get
            {
                CanReadProperty();
                return _tennhanvien;
            }
            set
            {
                CanWriteProperty();
                if (value == null) value = string.Empty;
                if (!_tennhanvien.Equals(value))
                {
                    _tennhanvien = value;
                    PropertyHasChanged();
                }
            }
        }
        public string MaQLNhanvien
        {
            get
            {
                CanReadProperty();
                return _maQlnhanvien;
            }
            set
            {
                CanWriteProperty();
                if (value == null) value = string.Empty;
                if (!_maQlnhanvien.Equals(value))
                {
                    _maQlnhanvien = value;
                    PropertyHasChanged();
                }
            }
        }

        protected override object GetIdValue()
        {
            return _maPhuCapTheoNhanVien;
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
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("GhiChu", 4000));
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
            //TODO: Define authorization rules in PhuCapTheoNhanVien
            //AuthorizationRules.AllowRead("MaPhuCapTheoNhanVien", "PhuCapTheoNhanVienReadGroup");
            //AuthorizationRules.AllowRead("MaNhanVien", "PhuCapTheoNhanVienReadGroup");
            //AuthorizationRules.AllowRead("MaLoaiPhuCap", "PhuCapTheoNhanVienReadGroup");
            //AuthorizationRules.AllowRead("SoTien", "PhuCapTheoNhanVienReadGroup");
            //AuthorizationRules.AllowRead("GhiChu", "PhuCapTheoNhanVienReadGroup");

            //AuthorizationRules.AllowWrite("MaNhanVien", "PhuCapTheoNhanVienWriteGroup");
            //AuthorizationRules.AllowWrite("MaLoaiPhuCap", "PhuCapTheoNhanVienWriteGroup");
            //AuthorizationRules.AllowWrite("SoTien", "PhuCapTheoNhanVienWriteGroup");
            //AuthorizationRules.AllowWrite("GhiChu", "PhuCapTheoNhanVienWriteGroup");
        }


        public static bool CanGetObject()
        {
            //TODO: Define CanGetObject permission in PhuCapTheoNhanVien
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("PhuCapTheoNhanVienViewGroup"))
            //	return true;
            //return false;
        }

        public static bool CanAddObject()
        {
            //TODO: Define CanAddObject permission in PhuCapTheoNhanVien
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("PhuCapTheoNhanVienAddGroup"))
            //	return true;
            //return false;
        }

        public static bool CanEditObject()
        {
            //TODO: Define CanEditObject permission in PhuCapTheoNhanVien
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("PhuCapTheoNhanVienEditGroup"))
            //	return true;
            //return false;
        }

        public static bool CanDeleteObject()
        {
            //TODO: Define CanDeleteObject permission in PhuCapTheoNhanVien
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("PhuCapTheoNhanVienDeleteGroup"))
            //	return true;
            //return false;
        }
        #endregion //Authorization Rules

        #region Factory Methods
        private PhuCapTheoNhanVien()
        { /* require use of factory method */ }

        public static PhuCapTheoNhanVien NewPhuCapTheoNhanVien()
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a PhuCapTheoNhanVien");
            return DataPortal.Create<PhuCapTheoNhanVien>();
        }

        public static PhuCapTheoNhanVien GetPhuCapTheoNhanVien(int maPhuCapTheoNhanVien)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a PhuCapTheoNhanVien");
            return DataPortal.Fetch<PhuCapTheoNhanVien>(new Criteria(maPhuCapTheoNhanVien));
        }
        public static PhuCapTheoNhanVien GetPhuCapTheoNhanVienAll()
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a PhuCapTheoNhanVien");
            return DataPortal.Fetch<PhuCapTheoNhanVien>(new FilterCriteria());
        }
        public static void DeletePhuCapTheoNhanVien(int maPhuCapTheoNhanVien)
        {
            if (!CanDeleteObject())
                throw new System.Security.SecurityException("User not authorized to remove a PhuCapTheoNhanVien");
            DataPortal.Delete(new Criteria(maPhuCapTheoNhanVien));
        }

        public override PhuCapTheoNhanVien Save()
        {
            if (IsDeleted && !CanDeleteObject())
                throw new System.Security.SecurityException("User not authorized to remove a PhuCapTheoNhanVien");
            else if (IsNew && !CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a PhuCapTheoNhanVien");
            else if (!CanEditObject())
                throw new System.Security.SecurityException("User not authorized to update a PhuCapTheoNhanVien");

            return base.Save();
        }

        #endregion //Factory Methods

        #region Child Factory Methods
        internal static PhuCapTheoNhanVien NewPhuCapTheoNhanVienChild()
        {
            PhuCapTheoNhanVien child = new PhuCapTheoNhanVien();
            child.ValidationRules.CheckRules();
            child.MarkAsChild();
            return child;
        }

        internal static PhuCapTheoNhanVien GetPhuCapTheoNhanVien(SafeDataReader dr)
        {
            PhuCapTheoNhanVien child = new PhuCapTheoNhanVien();
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
            public int MaPhuCapTheoNhanVien;

            public Criteria(int maPhuCapTheoNhanVien)
            {
                this.MaPhuCapTheoNhanVien = maPhuCapTheoNhanVien;
            }
        }
        private class FilterCriteria
        {
            public FilterCriteria()
            {
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
        private void DataPortal_Fetch(object criteria)
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

        private void ExecuteFetch(SqlTransaction tr, object criteria)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                if (criteria is Criteria)
                {
                   // cm.Parameters.AddWithValue("@MaPhuCapTheoNhanVien", criteria.MaPhuCapTheoNhanVien);
                }
                else if (criteria is FilterCriteria)
                {
                    cm.CommandText = "spd_selecttblnsPhuCapTheoNhanVien";                 
                }
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
            DataPortal_Delete(new Criteria(_maPhuCapTheoNhanVien));
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
                cm.CommandText = "spd_DeletetblnsPhuCapTheoNhanVien";

                cm.Parameters.AddWithValue("@MaPhuCapTheoNhanVien", criteria.MaPhuCapTheoNhanVien);

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
            _maPhuCapTheoNhanVien = dr.GetInt32("MaPhuCapTheoNhanVien");
            _maNhanVien = dr.GetInt64("MaNhanVien");
            _tennhanvien= dr.GetString("Tennhanvien");
            _maQlnhanvien = dr.GetString("MaQlNhanvien");            
            _maLoaiPhuCap = dr.GetInt32("MaLoaiPhuCap");
            _tenloaiphucap = dr.GetString("TenLoaiPhuCap");
            _soTien = dr.GetDecimal("SoTien");
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
                cm.CommandText = "spd_inserttblnsPhuCapTheoNhanVien";

                AddInsertParameters(cm);

                cm.ExecuteNonQuery();

                _maPhuCapTheoNhanVien = (int)cm.Parameters["@MaPhuCapTheoNhanVien"].Value;
            }//using
        }

        private void AddInsertParameters(SqlCommand cm)
        {
            if (_maNhanVien != 0)
                cm.Parameters.AddWithValue("@MaNhanVien", _maNhanVien);
            else
                cm.Parameters.AddWithValue("@MaNhanVien", DBNull.Value);
            cm.Parameters.AddWithValue("@MaLoaiPhuCap", _maLoaiPhuCap);
            if (_soTien != 0)
                cm.Parameters.AddWithValue("@SoTien", _soTien);
            else
                cm.Parameters.AddWithValue("@SoTien", DBNull.Value);
            if (_ghiChu.Length > 0)
                cm.Parameters.AddWithValue("@GhiChu", _ghiChu);
            else
                cm.Parameters.AddWithValue("@GhiChu", DBNull.Value);
            cm.Parameters.AddWithValue("@MaPhuCapTheoNhanVien", _maPhuCapTheoNhanVien);
            cm.Parameters["@maPhuCapTheoNhanVien"].Direction = ParameterDirection.Output;
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
                cm.CommandText = "spd_updatetblnsPhuCapTheoNhanVien";

                AddUpdateParameters(cm);

                cm.ExecuteNonQuery();

            }//using
        }

        private void AddUpdateParameters(SqlCommand cm)
        {
            cm.Parameters.AddWithValue("@MaPhuCapTheoNhanVien", _maPhuCapTheoNhanVien);
            if (_maNhanVien != 0)
                cm.Parameters.AddWithValue("@MaNhanVien", _maNhanVien);
            else
                cm.Parameters.AddWithValue("@MaNhanVien", DBNull.Value);
            cm.Parameters.AddWithValue("@MaLoaiPhuCap", _maLoaiPhuCap);
            if (_soTien != 0)
                cm.Parameters.AddWithValue("@SoTien", _soTien);
            else
                cm.Parameters.AddWithValue("@SoTien", DBNull.Value);
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

            ExecuteDelete(tr, new Criteria(_maPhuCapTheoNhanVien));
            MarkNew();
        }
        #endregion //Data Access - Delete
        #endregion //Data Access
    }
}
