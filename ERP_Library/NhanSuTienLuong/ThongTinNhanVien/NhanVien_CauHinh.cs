
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{
    [Serializable()]
    public class NhanVien_CauHinh : Csla.BusinessBase<NhanVien_CauHinh>
    {
        #region Business Properties and Methods

        //declare members
        internal int _maCauHinh = 0;
        private string _maQuanLy = string.Empty;
        private int _stt = 0;
        private string _ten = string.Empty;
        private string _LoaiDuLieu = "";

        [System.ComponentModel.DataObjectField(true, true)]
        public int MaCauHinh
        {
            get
            {
                return _maCauHinh;
            }
        }

        public string MaQuanLy
        {
            get
            {
                return _maQuanLy;
            }
            set
            {
                if (value == null) value = string.Empty;
                if (!_maQuanLy.Equals(value))
                {
                    _maQuanLy = value;
                    PropertyHasChanged("MaQuanLy");
                }
            }
        }

        public int Stt
        {
            get
            {
                return _stt;
            }
            set
            {
                if (!_stt.Equals(value))
                {
                    _stt = value;
                    PropertyHasChanged("Stt");
                }
            }
        }

        public string Ten
        {
            get
            {
                return _ten;
            }
            set
            {
                if (value == null) value = string.Empty;
                if (!_ten.Equals(value))
                {
                    _ten = value;
                    PropertyHasChanged("Ten");
                }
            }
        }

        public string LoaiDuLieu
        {
            get
            {
                return _LoaiDuLieu;
            }
            set
            {
                if (!_LoaiDuLieu.Equals(value))
                {
                    _LoaiDuLieu = value;
                    PropertyHasChanged();
                }
            }
        }

        protected override object GetIdValue()
        {
            return _maCauHinh;
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
            // MaQuanLy
            //
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("MaQuanLy", 50));
            //
            // Ten
            //
            ValidationRules.AddRule(CommonRules.StringRequired, "Ten");
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("Ten", 100));
            ValidationRules.AddRule(CommonRules.StringRequired, "LoaiDuLieu");
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("LoaiDuLieu", 50));
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
            //TODO: Define CanGetObject permission in NhanVien_CauHinh
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("NhanVien_CauHinhViewGroup"))
            //	return true;
            //return false;
        }

        public static bool CanAddObject()
        {
            //TODO: Define CanAddObject permission in NhanVien_CauHinh
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("NhanVien_CauHinhAddGroup"))
            //	return true;
            //return false;
        }

        public static bool CanEditObject()
        {
            //TODO: Define CanEditObject permission in NhanVien_CauHinh
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("NhanVien_CauHinhEditGroup"))
            //	return true;
            //return false;
        }

        public static bool CanDeleteObject()
        {
            //TODO: Define CanDeleteObject permission in NhanVien_CauHinh
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("NhanVien_CauHinhDeleteGroup"))
            //	return true;
            //return false;
        }
        #endregion //Authorization Rules

        #region Factory Methods
        public NhanVien_CauHinh()
        { /* require use of factory method */ }

        public static NhanVien_CauHinh NewNhanVien_CauHinh()
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a NhanVien_CauHinh");
            return DataPortal.Create<NhanVien_CauHinh>();
        }

        public static NhanVien_CauHinh GetNhanVien_CauHinh(int maCauHinh)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a NhanVien_CauHinh");
            return DataPortal.Fetch<NhanVien_CauHinh>(new Criteria(maCauHinh));
        }

        public static void DeleteNhanVien_CauHinh(int maCauHinh)
        {
            if (!CanDeleteObject())
                throw new System.Security.SecurityException("User not authorized to remove a NhanVien_CauHinh");
            DataPortal.Delete(new Criteria(maCauHinh));
        }

        public override NhanVien_CauHinh Save()
        {
            if (IsDeleted && !CanDeleteObject())
                throw new System.Security.SecurityException("User not authorized to remove a NhanVien_CauHinh");
            else if (IsNew && !CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a NhanVien_CauHinh");
            else if (!CanEditObject())
                throw new System.Security.SecurityException("User not authorized to update a NhanVien_CauHinh");

            return base.Save();
        }

        #endregion //Factory Methods

        #region Child Factory Methods
        internal static NhanVien_CauHinh NewNhanVien_CauHinhChild()
        {
            NhanVien_CauHinh child = new NhanVien_CauHinh();
            child.ValidationRules.CheckRules();
            child.MarkAsChild();
            return child;
        }

        internal static NhanVien_CauHinh GetNhanVien_CauHinh(SafeDataReader dr)
        {
            NhanVien_CauHinh child = new NhanVien_CauHinh();
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
            public int MaCauHinh;

            public Criteria(int maCauHinh)
            {
                this.MaCauHinh = maCauHinh;
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
                cm.CommandText = "spd_Select_NhanVien_CauHinh";

                cm.Parameters.AddWithValue("@MaCauHinh", criteria.MaCauHinh);

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
            DataPortal_Delete(new Criteria(_maCauHinh));
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
                cm.CommandText = "spd_Delete_NhanVien_CauHinh";

                cm.Parameters.AddWithValue("@MaCauHinh", criteria.MaCauHinh);

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
            _maCauHinh = dr.GetInt32("MaCauHinh");
            _maQuanLy = dr.GetString("MaQuanLy");
            _stt = dr.GetInt32("STT");
            _ten = dr.GetString("Ten");
            _LoaiDuLieu = dr.GetString("LoaiDuLieu");
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
                cm.CommandText = "spd_Insert_NhanVien_CauHinh";

                AddInsertParameters(cm);

                cm.ExecuteNonQuery();

                _maCauHinh = (int)cm.Parameters["@MaCauHinh"].Value;
            }//using
        }

        private void AddInsertParameters(SqlCommand cm)
        {
            if (_maQuanLy.Length > 0)
                cm.Parameters.AddWithValue("@MaQuanLy", _maQuanLy);
            else
                cm.Parameters.AddWithValue("@MaQuanLy", DBNull.Value);
            cm.Parameters.AddWithValue("@STT", _stt);
            cm.Parameters.AddWithValue("@Ten", _ten);
            cm.Parameters.AddWithValue("@LoaiDuLieu", _LoaiDuLieu);
            cm.Parameters.AddWithValue("@MaCauHinh", _maCauHinh);
            cm.Parameters["@MaCauHinh"].Direction = ParameterDirection.Output;
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
                cm.CommandText = "spd_Update_NhanVien_CauHinh";

                AddUpdateParameters(cm);

                cm.ExecuteNonQuery();

            }//using
        }

        private void AddUpdateParameters(SqlCommand cm)
        {
            cm.Parameters.AddWithValue("@MaCauHinh", _maCauHinh);
            if (_maQuanLy.Length > 0)
                cm.Parameters.AddWithValue("@MaQuanLy", _maQuanLy);
            else
                cm.Parameters.AddWithValue("@MaQuanLy", DBNull.Value);
            cm.Parameters.AddWithValue("@STT", _stt);
            cm.Parameters.AddWithValue("@LoaiDuLieu", _LoaiDuLieu);
            cm.Parameters.AddWithValue("@Ten", _ten);
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

            ExecuteDelete(tr, new Criteria(_maCauHinh));
            MarkNew();
        }
        #endregion //Data Access - Delete
        #endregion //Data Access
    }
}
