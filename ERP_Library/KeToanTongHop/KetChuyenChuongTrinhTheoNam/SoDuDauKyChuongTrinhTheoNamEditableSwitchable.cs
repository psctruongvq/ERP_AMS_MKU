using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{
    [Serializable()]
    public class SoDuDauKyChuongTrinhTheoNam : Csla.BusinessBase<SoDuDauKyChuongTrinhTheoNam>
    {
        #region Business Properties and Methods

        //declare members
        private int _maKyKetChuyen = 0;
        private int _nam = 0;
        private SmartDate _ngayHT = new SmartDate(DateTime.Today);
        private int _userID = ERP_Library.Security.CurrentUser.Info.UserID;
        private int _maBoPhan = ERP_Library.Security.CurrentUser.Info.MaBoPhan;

        private CT_SoDuDauKyChuongTrinhTheoNamList _chitiet_SoDuDauKyChuongTrinhTheoNamList = CT_SoDuDauKyChuongTrinhTheoNamList.NewCT_SoDuDauKyChuongTrinhTheoNamList();

        [System.ComponentModel.DataObjectField(true, true)]
        public int MaKyKetChuyen
        {
            get
            {
                CanReadProperty("MaKyKetChuyen", true);
                return _maKyKetChuyen;
            }
        }

        public int Nam
        {
            get
            {
                CanReadProperty("Nam", true);
                return _nam;
            }
            set
            {
                CanWriteProperty("Nam", true);
                if (!_nam.Equals(value))
                {
                    _nam = value;
                    PropertyHasChanged("Nam");
                }
            }
        }

        public DateTime NgayHT
        {
            get
            {
                CanReadProperty("NgayHT", true);
                return _ngayHT.Date;
            }
        }

        public int UserID
        {
            get
            {
                CanReadProperty("UserID", true);
                return _userID;
            }
            set
            {
                CanWriteProperty("UserID", true);
                if (!_userID.Equals(value))
                {
                    _userID = value;
                    PropertyHasChanged("UserID");
                }
            }
        }

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

        public CT_SoDuDauKyChuongTrinhTheoNamList ChiTiet_SoDuDauKyChuongTrinhTheoNamList
        {
            get
            {
                CanReadProperty("ChiTiet_SoDuDauKyChuongTrinhTheoNamList", true);
                return _chitiet_SoDuDauKyChuongTrinhTheoNamList;
            }
        }

        protected override object GetIdValue()
        {
            return _maKyKetChuyen;
        }

        public override bool IsValid
        {
            get
            {
                return base.IsValid && _chitiet_SoDuDauKyChuongTrinhTheoNamList.IsValid;
            }
        }

        public override bool IsDirty
        {
            get
            {
                return base.IsDirty || _chitiet_SoDuDauKyChuongTrinhTheoNamList.IsDirty;
            }
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
            //TODO: Define authorization rules in SoDuDauKyChuongTrinhTheoNam
            //AuthorizationRules.AllowRead("MaKyKetChuyen", "SoDuDauKyChuongTrinhTheoNamReadGroup");
            //AuthorizationRules.AllowRead("Nam", "SoDuDauKyChuongTrinhTheoNamReadGroup");
            //AuthorizationRules.AllowRead("MaTaiKhoan", "SoDuDauKyChuongTrinhTheoNamReadGroup");
            //AuthorizationRules.AllowRead("UserID", "SoDuDauKyChuongTrinhTheoNamReadGroup");

            //AuthorizationRules.AllowWrite("Nam", "SoDuDauKyChuongTrinhTheoNamWriteGroup");
            //AuthorizationRules.AllowWrite("MaTaiKhoan", "SoDuDauKyChuongTrinhTheoNamWriteGroup");
            //AuthorizationRules.AllowWrite("UserID", "SoDuDauKyChuongTrinhTheoNamWriteGroup");
        }


        public static bool CanGetObject()
        {
            //TODO: Define CanGetObject permission in SoDuDauKyChuongTrinhTheoNam
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("SoDuDauKyChuongTrinhTheoNamViewGroup"))
            //	return true;
            //return false;
        }

        public static bool CanAddObject()
        {
            //TODO: Define CanAddObject permission in SoDuDauKyChuongTrinhTheoNam
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("SoDuDauKyChuongTrinhTheoNamAddGroup"))
            //	return true;
            //return false;
        }

        public static bool CanEditObject()
        {
            //TODO: Define CanEditObject permission in SoDuDauKyChuongTrinhTheoNam
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("SoDuDauKyChuongTrinhTheoNamEditGroup"))
            //	return true;
            //return false;
        }

        public static bool CanDeleteObject()
        {
            //TODO: Define CanDeleteObject permission in SoDuDauKyChuongTrinhTheoNam
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("SoDuDauKyChuongTrinhTheoNamDeleteGroup"))
            //	return true;
            //return false;
        }
        #endregion //Authorization Rules

        #region Factory Methods
        private SoDuDauKyChuongTrinhTheoNam()
        { /* require use of factory method */ }

        public static SoDuDauKyChuongTrinhTheoNam NewSoDuDauKyChuongTrinhTheoNam()
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a SoDuDauKyChuongTrinhTheoNam");
            return DataPortal.Create<SoDuDauKyChuongTrinhTheoNam>();
        }

        public static SoDuDauKyChuongTrinhTheoNam GetSoDuDauKyChuongTrinhTheoNam(int maKyKetChuyen)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a SoDuDauKyChuongTrinhTheoNam");
            return DataPortal.Fetch<SoDuDauKyChuongTrinhTheoNam>(new Criteria(maKyKetChuyen));
        }

        public static void DeleteSoDuDauKyChuongTrinhTheoNam(int maKyKetChuyen)
        {
            if (!CanDeleteObject())
                throw new System.Security.SecurityException("User not authorized to remove a SoDuDauKyChuongTrinhTheoNam");
            DataPortal.Delete(new Criteria(maKyKetChuyen));
        }

        public override SoDuDauKyChuongTrinhTheoNam Save()
        {
            if (IsDeleted && !CanDeleteObject())
                throw new System.Security.SecurityException("User not authorized to remove a SoDuDauKyChuongTrinhTheoNam");
            else if (IsNew && !CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a SoDuDauKyChuongTrinhTheoNam");
            else if (!CanEditObject())
                throw new System.Security.SecurityException("User not authorized to update a SoDuDauKyChuongTrinhTheoNam");

            return base.Save();
        }

        public static bool KiemTraDaKetChuyenChuongTrinhTheoNam(int nam)
        {
            bool result = false;

            using (SqlConnection cn=new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm=cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "Spd_KiemTraDaKetChuyenChuongTrinhTheoNam";
                    cm.Parameters.AddWithValue("@Nam", nam);
                    cm.Parameters.AddWithValue("@UserID", ERP_Library.Security.CurrentUser.Info.UserID);
                    cm.Parameters.AddWithValue("@MaBoPhan", ERP_Library.Security.CurrentUser.Info.MaBoPhan);
                    SqlParameter prmGiaTriTraVe = new SqlParameter("@GiaTriTraVe", SqlDbType.Bit, 2);
                    prmGiaTriTraVe.Direction = ParameterDirection.Output;
                    cm.Parameters.Add(prmGiaTriTraVe);
                    cm.ExecuteNonQuery();
                    result = (bool)prmGiaTriTraVe.Value;
                }
            }

            return result;
        }

        public static bool KiemTraCoTonTaiSoDuDauKyTheoNam(int nam)
        {
            bool result = false;

            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "Spd_KiemTraCoTonTaiSoDuDauKyTheoNam";
                    cm.Parameters.AddWithValue("@Nam", nam);
                    cm.Parameters.AddWithValue("@UserID", ERP_Library.Security.CurrentUser.Info.UserID);
                    cm.Parameters.AddWithValue("@MaBoPhan", ERP_Library.Security.CurrentUser.Info.MaBoPhan);
                    SqlParameter prmGiaTriTraVe = new SqlParameter("@GiaTriTraVe", SqlDbType.Bit, 2);
                    prmGiaTriTraVe.Direction = ParameterDirection.Output;
                    cm.Parameters.Add(prmGiaTriTraVe);
                    cm.ExecuteNonQuery();
                    result = (bool)prmGiaTriTraVe.Value;
                }
            }

            return result;
        }

        public static void KetChuyenSoDuDauKyChuongTrinhTheoNam(int nam)
        {
            using (SqlConnection cn=new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm =cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "Spd_KetChuyenSoDuDauKyChuongTrinhTheoNam";
                    cm.Parameters.AddWithValue("@Nam", nam);
                    cm.Parameters.AddWithValue("@UserID", ERP_Library.Security.CurrentUser.Info.UserID);
                    cm.Parameters.AddWithValue("@MaBoPhan", ERP_Library.Security.CurrentUser.Info.MaBoPhan);
                    cm.ExecuteNonQuery();
                }
            }
        }

        public static void HuyKetChuyenSoDuDauKyChuongTrinhTheoNam(int nam)
        {
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "Spd_HuyKetChuyenSoDuDauKyChuongTrinhTheoNam";
                    cm.Parameters.AddWithValue("@Nam", nam);
                    cm.Parameters.AddWithValue("@UserID", ERP_Library.Security.CurrentUser.Info.UserID);
                    cm.Parameters.AddWithValue("@MaBoPhan", ERP_Library.Security.CurrentUser.Info.MaBoPhan);
                    cm.ExecuteNonQuery();
                }
            }
        }

        public static bool KiemTraSoDuDauKyChuongTrinhCPSXDaKetChuyen(int nam)
        {
            bool giaTriTraVe = false;
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_KiemTraSoDuDauKyChuongTrinhCPSXDaKetChuyen";
                    cm.Parameters.AddWithValue("@Nam", nam);
                    cm.Parameters.AddWithValue("@UserID", ERP_Library.Security.CurrentUser.Info.UserID);
                    cm.Parameters.AddWithValue("@MaBoPhan", ERP_Library.Security.CurrentUser.Info.MaBoPhan);
                    SqlParameter prmGiaTriTraVe = new SqlParameter("@DaKetChuyen", SqlDbType.Bit);
                    prmGiaTriTraVe.Direction = ParameterDirection.Output;
                    cm.Parameters.Add(prmGiaTriTraVe);
                    cm.ExecuteNonQuery();
                    giaTriTraVe = (bool)prmGiaTriTraVe.Value;
                }
            }//us
            return giaTriTraVe;
        }

        #endregion //Factory Methods

        #region Child Factory Methods
        internal static SoDuDauKyChuongTrinhTheoNam NewSoDuDauKyChuongTrinhTheoNamChild()
        {
            SoDuDauKyChuongTrinhTheoNam child = new SoDuDauKyChuongTrinhTheoNam();
            child.ValidationRules.CheckRules();
            child.MarkAsChild();
            return child;
        }

        internal static SoDuDauKyChuongTrinhTheoNam GetSoDuDauKyChuongTrinhTheoNam(SafeDataReader dr)
        {
            SoDuDauKyChuongTrinhTheoNam child = new SoDuDauKyChuongTrinhTheoNam();
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
            public int MaKyKetChuyen;

            public Criteria(int maKyKetChuyen)
            {
                this.MaKyKetChuyen = maKyKetChuyen;
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
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();

                ExecuteFetch(cn, criteria);
            }//using
        }

        private void ExecuteFetch(SqlConnection cn, Criteria criteria)
        {
            using (SqlCommand cm = cn.CreateCommand())
            {
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_SelectSoDuDauKyChuongTrinhTheoNambyMaKyKetChuyen";
                cm.Parameters.AddWithValue("@Nam", criteria.MaKyKetChuyen);
                cm.Parameters.AddWithValue("@UserID", ERP_Library.Security.CurrentUser.Info.UserID);
                cm.Parameters.AddWithValue("@MaBoPhan", ERP_Library.Security.CurrentUser.Info.MaBoPhan);

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
                catch (Exception ex)
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
                tr=cn.BeginTransaction();

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
                catch (Exception ex)
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
            DataPortal_Delete(new Criteria(_maKyKetChuyen));
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
                catch (Exception ex)
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
                cm.CommandText = "spd_DeletetblSoDuDauKyChuongTrinhTheoNam";

                cm.Parameters.AddWithValue("@MaKyKetChuyen", criteria.MaKyKetChuyen);

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
            _maKyKetChuyen = dr.GetInt32("MaKyKetChuyen");
            _nam = dr.GetInt32("Nam");
            _ngayHT = dr.GetSmartDate("NgayHT", _ngayHT.EmptyIsMin);
            _userID = dr.GetInt32("UserID");
            _maBoPhan = dr.GetInt32("MaBoPhan");
        }

        private void FetchChildren(SafeDataReader dr)
        {
            _chitiet_SoDuDauKyChuongTrinhTheoNamList = CT_SoDuDauKyChuongTrinhTheoNamList.GetCT_SoDuDauKyChuongTrinhTheoNamList(this.MaKyKetChuyen);
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
                cm.CommandText = "spd_InserttblSoDuDauKyChuongTrinhTheoNam";

                AddInsertParameters(cm);

                cm.ExecuteNonQuery();

                _maKyKetChuyen = (int)cm.Parameters["@MaKyKetChuyen"].Value;
            }//using
        }

        private void AddInsertParameters(SqlCommand cm)
        {
            if (_nam != 0)
                cm.Parameters.AddWithValue("@Nam", _nam);
            else
                cm.Parameters.AddWithValue("@Nam", DBNull.Value);
            cm.Parameters.AddWithValue("@NgayHT", _ngayHT.DBValue);
            if (_userID != 0)
                cm.Parameters.AddWithValue("@UserID", _userID);
            else
                cm.Parameters.AddWithValue("@UserID", DBNull.Value);
            if (_maBoPhan != 0)
                cm.Parameters.AddWithValue("@MaBoPhan", _maBoPhan);
            else
                cm.Parameters.AddWithValue("@MaBoPhan", DBNull.Value);
            cm.Parameters.AddWithValue("@MaKyKetChuyen", _maKyKetChuyen);
            cm.Parameters["@MaKyKetChuyen"].Direction = ParameterDirection.Output;
        }
        #endregion //Data Access - Insert

        #region Data Access - Update
        internal void Update(SqlTransaction tr)
        {
            if (!IsDirty) return;

            //if (base.IsDirty)
            //{
            //    ExecuteUpdate(tr);
            //    MarkOld();
            //}

            //update child object(s)
            UpdateChildren(tr);
        }

        private void ExecuteUpdate(SqlTransaction tr)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_UpdatetblSoDuDauKyChuongTrinhTheoNam";

                AddUpdateParameters(cm);

                cm.ExecuteNonQuery();

            }//using
        }

        private void AddUpdateParameters(SqlCommand cm)
        {
            cm.Parameters.AddWithValue("@MaKyKetChuyen", _maKyKetChuyen);
            if (_nam != 0)
                cm.Parameters.AddWithValue("@Nam", _nam);
            else
                cm.Parameters.AddWithValue("@Nam", DBNull.Value);
            cm.Parameters.AddWithValue("@NgayHT", _ngayHT.DBValue);
            if (_userID != 0)
                cm.Parameters.AddWithValue("@UserID", _userID);
            else
                cm.Parameters.AddWithValue("@UserID", DBNull.Value);
            if (_maBoPhan != 0)
                cm.Parameters.AddWithValue("@MaBoPhan", _maBoPhan);
            else
                cm.Parameters.AddWithValue("@MaBoPhan", DBNull.Value);
        }

        private void UpdateChildren(SqlTransaction tr)
        {
            _chitiet_SoDuDauKyChuongTrinhTheoNamList.Update(tr, this);
        }
        #endregion //Data Access - Update

        #region Data Access - Delete
        internal void DeleteSelf(SqlTransaction tr)
        {
            if (!IsDirty) return;
            if (IsNew) return;

            ExecuteDelete(tr, new Criteria(_maKyKetChuyen));
            MarkNew();
        }
        #endregion //Data Access - Delete
        #endregion //Data Access
    }
}
