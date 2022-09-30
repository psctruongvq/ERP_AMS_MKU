
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{
    [Serializable()]
    public class LoaiHopDong : Csla.BusinessBase<LoaiHopDong>
    {
        #region Business Properties and Methods

        //declare members
        private int _maLoaiHopDong = 0;
        private string _maQuanLy = string.Empty;
        private string _tenLoaiHopDong = string.Empty;

        [System.ComponentModel.DataObjectField(true, true)]
        public int MaLoaiHopDong
        {
            get
            {
                return _maLoaiHopDong;
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

        public string TenLoaiHopDong
        {
            get
            {
                return _tenLoaiHopDong;
            }
            set
            {
                if (value == null) value = string.Empty;
                if (!_tenLoaiHopDong.Equals(value))
                {
                    _tenLoaiHopDong = value;
                    PropertyHasChanged("TenLoaiHopDong");
                }
            }
        }

        protected override object GetIdValue()
        {
            return _maLoaiHopDong;
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
            ValidationRules.AddRule(CommonRules.StringRequired, "MaQuanLy");
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("MaQuanLy", 50));
            //
            // TenLoaiHopDong
            //
            ValidationRules.AddRule(CommonRules.StringRequired, "TenLoaiHopDong");
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("TenLoaiHopDong", 500));
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
            //TODO: Define CanGetObject permission in LoaiHopDong
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("LoaiHopDongViewGroup"))
            //	return true;
            //return false;
        }

        public static bool CanAddObject()
        {
            //TODO: Define CanAddObject permission in LoaiHopDong
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("LoaiHopDongAddGroup"))
            //	return true;
            //return false;
        }

        public static bool CanEditObject()
        {
            //TODO: Define CanEditObject permission in LoaiHopDong
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("LoaiHopDongEditGroup"))
            //	return true;
            //return false;
        }

        public static bool CanDeleteObject()
        {
            //TODO: Define CanDeleteObject permission in LoaiHopDong
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("LoaiHopDongDeleteGroup"))
            //	return true;
            //return false;
        }
        #endregion //Authorization Rules

        #region Factory Methods
        private LoaiHopDong()
        { /* require use of factory method */ }
        private LoaiHopDong(int ma, string ten)
        {
            _maLoaiHopDong = ma;
            _tenLoaiHopDong = ten;
        }

        public static LoaiHopDong NewLoaiHopDong()
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a LoaiHopDong");
            return DataPortal.Create<LoaiHopDong>();
        }
        public static LoaiHopDong NewLoaiHopDong(int ma ,string ten)
        {
            return new LoaiHopDong(ma, ten);
        }

        public static LoaiHopDong GetLoaiHopDong(int maLoaiHopDong)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a LoaiHopDong");
            return DataPortal.Fetch<LoaiHopDong>(new Criteria(maLoaiHopDong));
        }
        public static LoaiHopDong GetLoaiHopDong(string maLoaiHopDongQL)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a LoaiHopDong");
            return DataPortal.Fetch<LoaiHopDong>(new Criteria(maLoaiHopDongQL));
        }

        public static void DeleteLoaiHopDong(int maLoaiHopDong)
        {
            if (!CanDeleteObject())
                throw new System.Security.SecurityException("User not authorized to remove a LoaiHopDong");
            DataPortal.Delete(new Criteria(maLoaiHopDong));
        }

        public override LoaiHopDong Save()
        {
            if (IsDeleted && !CanDeleteObject())
                throw new System.Security.SecurityException("User not authorized to remove a LoaiHopDong");
            else if (IsNew && !CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a LoaiHopDong");
            else if (!CanEditObject())
                throw new System.Security.SecurityException("User not authorized to update a LoaiHopDong");

            return base.Save();
        }

        #endregion //Factory Methods

        #region Child Factory Methods
        internal static LoaiHopDong NewLoaiHopDongChild()
        {
            LoaiHopDong child = new LoaiHopDong();
            child.ValidationRules.CheckRules();
            child.MarkAsChild();
            return child;
        }

        internal static LoaiHopDong GetLoaiHopDong(SafeDataReader dr)
        {
            LoaiHopDong child = new LoaiHopDong();
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
            public int MaLoaiHopDong;
            public string MaLoaiHopDongQL;

            public Criteria(int maLoaiHopDong)
            {
                this.MaLoaiHopDong = maLoaiHopDong;
            }

            public Criteria(string maLoaiHopDongQL)
            {
                this.MaLoaiHopDongQL = maLoaiHopDongQL;
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
                if (criteria.MaLoaiHopDong == 0)
                {
                    cm.CommandText = "spd_Select_LoaiHopDongByMaQuanLy";
                    cm.Parameters.AddWithValue("@MaQuanLy", criteria.MaLoaiHopDongQL);
                }
                else
                {
                    cm.CommandText = "spd_Select_LoaiHopDong";
                    cm.Parameters.AddWithValue("@MaLoaiHopDong", criteria.MaLoaiHopDong);
                }

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
            DataPortal_Delete(new Criteria(_maLoaiHopDong));
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
                cm.CommandText = "spd_Delete_LoaiHopDong";

                cm.Parameters.AddWithValue("@MaLoaiHopDong", criteria.MaLoaiHopDong);

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
            _maLoaiHopDong = dr.GetInt32("MaLoaiHopDong");
            _maQuanLy = dr.GetString("MaQuanLy");
            _tenLoaiHopDong = dr.GetString("TenLoaiHopDong");
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
                cm.CommandText = "spd_Insert_LoaiHopDong";

                AddInsertParameters(cm);

                cm.ExecuteNonQuery();

                _maLoaiHopDong = (int)cm.Parameters["@MaLoaiHopDong"].Value;
            }//using
        }

        private void AddInsertParameters(SqlCommand cm)
        {
            cm.Parameters.AddWithValue("@MaQuanLy", _maQuanLy);
            cm.Parameters.AddWithValue("@TenLoaiHopDong", _tenLoaiHopDong);
            cm.Parameters.AddWithValue("@MaLoaiHopDong", _maLoaiHopDong);
            cm.Parameters["@MaLoaiHopDong"].Direction = ParameterDirection.Output;
        }
        #endregion //Data Access - Insertmmo

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
                cm.CommandText = "spd_Update_LoaiHopDong";

                AddUpdateParameters(cm);

                cm.ExecuteNonQuery();

            }//using
        }

        private void AddUpdateParameters(SqlCommand cm)
        {
            cm.Parameters.AddWithValue("@MaLoaiHopDong", _maLoaiHopDong);
            cm.Parameters.AddWithValue("@MaQuanLy", _maQuanLy);
            cm.Parameters.AddWithValue("@TenLoaiHopDong", _tenLoaiHopDong);
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

            ExecuteDelete(tr, new Criteria(_maLoaiHopDong));
            MarkNew();
        }
        #endregion //Data Access - Delete
        #endregion //Data Access

        #region Kiem Tra
        public static bool KiemTraTrungMaloaiHopDong(int maLoaiHD, string maQuanLy)
        {
            bool trungSoHopDong = false;
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {

                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "Spd_KiemTraTrungMaLoaiHD";
                    cm.Parameters.AddWithValue("@MaLoaiHD", maLoaiHD);
                    cm.Parameters.AddWithValue("@MaQuanLy", maQuanLy);
                    SqlParameter prmGiaTriTraVe = new SqlParameter("@TrungMaQuanLy", SqlDbType.Bit);
                    prmGiaTriTraVe.Direction = ParameterDirection.Output;
                    cm.Parameters.Add(prmGiaTriTraVe);
                    cm.ExecuteNonQuery();
                    trungSoHopDong = (bool)prmGiaTriTraVe.Value;
                }
            }//us
            return trungSoHopDong;
        }
        #endregion

    }
}
