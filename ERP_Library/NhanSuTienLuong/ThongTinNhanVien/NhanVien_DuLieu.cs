
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{
    [Serializable()]
    public class NhanVien_DuLieu : Csla.BusinessBase<NhanVien_DuLieu>
    {
        #region Business Properties and Methods

        //declare members
        internal long _maDuLieu = 0;
        private long _maNhanVien = 0;
        private int _maCauHinh = 0;
        private string _duLieu = string.Empty;

        [System.ComponentModel.DataObjectField(true, true)]
        public long MaDuLieu
        {
            get
            {
                return _maDuLieu;
            }
        }

        public long MaNhanVien
        {
            get
            {
                return _maNhanVien;
            }
            set
            {
                if (!_maNhanVien.Equals(value))
                {
                    _maNhanVien = value;
                    PropertyHasChanged("MaNhanVien");
                }
            }
        }

        public int MaCauHinh
        {
            get
            {
                return _maCauHinh;
            }
            set
            {
                if (!_maCauHinh.Equals(value))
                {
                    _maCauHinh = value;
                    PropertyHasChanged("MaCauHinh");
                }
            }
        }

        public string DuLieu
        {
            get
            {
                return _duLieu;
            }
            set
            {
                if (value == null) value = string.Empty;
                if (!_duLieu.Equals(value))
                {
                    _duLieu = value;
                    PropertyHasChanged("DuLieu");
                }
            }
        }
       
        protected override object GetIdValue()
        {
            return _maDuLieu;
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
            // DuLieu
            //
            ValidationRules.AddRule(CommonRules.StringRequired, "DuLieu");
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("DuLieu", 100));
        }

        protected override void AddBusinessRules()
        {
            AddCommonRules();
            AddCustomRules();
        }
        #endregion //Validation Rules

        #region Authorization Rules

        public static bool CanGetObject()
        {
            //TODO: Define CanGetObject permission in NhanVien_DuLieu
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("NhanVien_DuLieuViewGroup"))
            //	return true;
            //return false;
        }

        public static bool CanAddObject()
        {
            //TODO: Define CanAddObject permission in NhanVien_DuLieu
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("NhanVien_DuLieuAddGroup"))
            //	return true;
            //return false;
        }

        public static bool CanEditObject()
        {
            //TODO: Define CanEditObject permission in NhanVien_DuLieu
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("NhanVien_DuLieuEditGroup"))
            //	return true;
            //return false;
        }

        public static bool CanDeleteObject()
        {
            //TODO: Define CanDeleteObject permission in NhanVien_DuLieu
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("NhanVien_DuLieuDeleteGroup"))
            //	return true;
            //return false;
        }
        #endregion //Authorization Rules

        #region Factory Methods
        private NhanVien_DuLieu()
        { /* require use of factory method */ }

        public static NhanVien_DuLieu NewNhanVien_DuLieu()
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a NhanVien_DuLieu");
            return DataPortal.Create<NhanVien_DuLieu>();
        }

        public static NhanVien_DuLieu GetNhanVien_DuLieu(long maDuLieu)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a NhanVien_DuLieu");
            return DataPortal.Fetch<NhanVien_DuLieu>(new Criteria(maDuLieu));
        }

        public static void DeleteNhanVien_DuLieu(long maDuLieu)
        {
            if (!CanDeleteObject())
                throw new System.Security.SecurityException("User not authorized to remove a NhanVien_DuLieu");
            DataPortal.Delete(new Criteria(maDuLieu));
        }

        public override NhanVien_DuLieu Save()
        {
            if (IsDeleted && !CanDeleteObject())
                throw new System.Security.SecurityException("User not authorized to remove a NhanVien_DuLieu");
            else if (IsNew && !CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a NhanVien_DuLieu");
            else if (!CanEditObject())
                throw new System.Security.SecurityException("User not authorized to update a NhanVien_DuLieu");

            return base.Save();
        }

        #endregion //Factory Methods

        #region Child Factory Methods
        public static NhanVien_DuLieu NewNhanVien_DuLieuChild()
        {
            NhanVien_DuLieu child = new NhanVien_DuLieu();
            child.ValidationRules.CheckRules();
            child.MarkAsChild();
            return child;
        }

        internal static NhanVien_DuLieu GetNhanVien_DuLieu(SafeDataReader dr)
        {
            NhanVien_DuLieu child = new NhanVien_DuLieu();
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
            public long MaDuLieu;

            public Criteria(long maDuLieu)
            {
                this.MaDuLieu = maDuLieu;
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
                cm.CommandText = "spd_Select_NhanVien_DuLieu";

                cm.Parameters.AddWithValue("@MaDuLieu", criteria.MaDuLieu);

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
            DataPortal_Delete(new Criteria(_maDuLieu));
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
                cm.CommandText = "spd_Delete_NhanVien_DuLieu";

                cm.Parameters.AddWithValue("@MaDuLieu", criteria.MaDuLieu);

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
            _maDuLieu = dr.GetInt64("MaDuLieu");
            _maNhanVien = dr.GetInt64("MaNhanVien");
            _maCauHinh = dr.GetInt32("MaCauHinh");
            _duLieu = dr.GetString("DuLieu");
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
                cm.CommandText = "spd_Insert_NhanVien_DuLieu";

                AddInsertParameters(cm);

                cm.ExecuteNonQuery();

                _maDuLieu = (long)cm.Parameters["@MaDuLieu"].Value;
            }//using
        }

        private void AddInsertParameters(SqlCommand cm)
        {
            cm.Parameters.AddWithValue("@MaNhanVien", _maNhanVien);
            cm.Parameters.AddWithValue("@MaCauHinh", _maCauHinh);
            cm.Parameters.AddWithValue("@DuLieu", _duLieu);
            cm.Parameters.AddWithValue("@MaDuLieu", _maDuLieu);
            cm.Parameters["@MaDuLieu"].Direction = ParameterDirection.Output;
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
                cm.CommandText = "spd_Update_NhanVien_DuLieu";

                AddUpdateParameters(cm);

                cm.ExecuteNonQuery();

            }//using
        }

        private void AddUpdateParameters(SqlCommand cm)
        {
            cm.Parameters.AddWithValue("@MaDuLieu", _maDuLieu);
            cm.Parameters.AddWithValue("@MaNhanVien", _maNhanVien);
            cm.Parameters.AddWithValue("@MaCauHinh", _maCauHinh);
            cm.Parameters.AddWithValue("@DuLieu", _duLieu);
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

            ExecuteDelete(tr, new Criteria(_maDuLieu));
            MarkNew();
        }
        #endregion //Data Access - Delete
        #endregion //Data Access
    }
}
