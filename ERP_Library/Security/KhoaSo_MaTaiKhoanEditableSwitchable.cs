using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{
    [Serializable()]
    public class KhoaSo_MaTaiKhoan : Csla.BusinessBase<KhoaSo_MaTaiKhoan>
    {
        #region Business Properties and Methods

        //declare members
        private int _maKhoaSo = 0;
        private int _maKy = 0;
        private int _userID = 0;
        private int _maTaiKhoan = 0;
        private bool _khoaSo = false;
        private string _soHieuTK = string.Empty;
        private int _maTaiKhoanCha = 0;
        private string _tenTaiKhoan = string.Empty;

        [System.ComponentModel.DataObjectField(true, true)]
        public int MaKhoaSo
        {
            get
            {
                CanReadProperty("MaKhoaSo", true);
                return _maKhoaSo;
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

        //[DisplayName("Tên đăng nhập")]
        private string _tenDangNhap = string.Empty;
        public string TenDangNhap
        {
            get { return _tenDangNhap; }

        }

        private DateTime _ngayBatDau = DateTime.Today.Date;
        //[DisplayName("Ngày bắt đầu")]
        public DateTime NgayBatDau
        {
            get { return _ngayBatDau; }

        }

        private DateTime _ngayKetThuc = DateTime.Today.Date;
        //[DisplayName("Ngày kết thúc")]
        public DateTime NgayKetThuc
        {
            get { return _ngayKetThuc; }

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

        public int MaTaiKhoan
        {
            get
            {
                CanReadProperty("MaTaiKhoan", true);
                return _maTaiKhoan;
            }
            set
            {
                CanWriteProperty("MaTaiKhoan", true);
                if (!_maTaiKhoan.Equals(value))
                {
                    _maTaiKhoan = value;
                    PropertyHasChanged("MaTaiKhoan");
                }
            }
        }

        public int MaTaiKhoanCha
        {
            get
            {
                CanReadProperty("MaTaiKhoanCha", true);
                return _maTaiKhoanCha;
            }
            set
            {
                CanWriteProperty("MaTaiKhoanCha", true);
                if (!_maTaiKhoanCha.Equals(value))
                {
                    _maTaiKhoanCha = value;
                    PropertyHasChanged("MaTaiKhoanCha");
                }
            }
        }

        public string SoHieuTK
        {
            get
            {
                CanReadProperty("SoHieuTK", true);
                return _soHieuTK;
            }
            set
            {
                CanWriteProperty("SoHieuTK", true);
                if (!_soHieuTK.Equals(value))
                {
                    _soHieuTK = value;
                    PropertyHasChanged("SoHieuTK");
                }
            }
        }

        public string TenTaiKhoan
        {
            get
            {
                CanReadProperty("TenTaiKhoan", true);
                return _tenTaiKhoan;
            }
            set
            {
                CanWriteProperty("TenTaiKhoan", true);
                if (!_tenTaiKhoan.Equals(value))
                {
                    _tenTaiKhoan = value;
                    PropertyHasChanged("TenTaiKhoan");
                }
            }
        }

        public bool KhoaSo
        {
            get
            {
                CanReadProperty("KhoaSo", true);
                return _khoaSo;
            }
            set
            {
                CanWriteProperty("KhoaSo", true);
                if (!_khoaSo.Equals(value))
                {
                    _khoaSo = value;
                    PropertyHasChanged("KhoaSo");
                }
            }
        }

        protected override object GetIdValue()
        {
            return _maKhoaSo;
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
            //TODO: Define authorization rules in KhoaSo_MaTaiKhoan
            //AuthorizationRules.AllowRead("MaKhoaSo", "KhoaSo_MaTaiKhoanReadGroup");
            //AuthorizationRules.AllowRead("MaKy", "KhoaSo_MaTaiKhoanReadGroup");
            //AuthorizationRules.AllowRead("UserID", "KhoaSo_MaTaiKhoanReadGroup");
            //AuthorizationRules.AllowRead("MaTaiKhoan", "KhoaSo_MaTaiKhoanReadGroup");
            //AuthorizationRules.AllowRead("KhoaSo", "KhoaSo_MaTaiKhoanReadGroup");

            //AuthorizationRules.AllowWrite("MaKy", "KhoaSo_MaTaiKhoanWriteGroup");
            //AuthorizationRules.AllowWrite("UserID", "KhoaSo_MaTaiKhoanWriteGroup");
            //AuthorizationRules.AllowWrite("MaTaiKhoan", "KhoaSo_MaTaiKhoanWriteGroup");
            //AuthorizationRules.AllowWrite("KhoaSo", "KhoaSo_MaTaiKhoanWriteGroup");
        }


        public static bool CanGetObject()
        {
            //TODO: Define CanGetObject permission in KhoaSo_MaTaiKhoan
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("KhoaSo_MaTaiKhoanViewGroup"))
            //	return true;
            //return false;
        }

        public static bool CanAddObject()
        {
            //TODO: Define CanAddObject permission in KhoaSo_MaTaiKhoan
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("KhoaSo_MaTaiKhoanAddGroup"))
            //	return true;
            //return false;
        }

        public static bool CanEditObject()
        {
            //TODO: Define CanEditObject permission in KhoaSo_MaTaiKhoan
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("KhoaSo_MaTaiKhoanEditGroup"))
            //	return true;
            //return false;
        }

        public static bool CanDeleteObject()
        {
            //TODO: Define CanDeleteObject permission in KhoaSo_MaTaiKhoan
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("KhoaSo_MaTaiKhoanDeleteGroup"))
            //	return true;
            //return false;
        }
        #endregion //Authorization Rules

        #region Factory Methods
        private KhoaSo_MaTaiKhoan()
        { /* require use of factory method */ }

        public static KhoaSo_MaTaiKhoan NewKhoaSo_MaTaiKhoan()
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a KhoaSo_MaTaiKhoan");
            return DataPortal.Create<KhoaSo_MaTaiKhoan>();
        }

        public static KhoaSo_MaTaiKhoan GetKhoaSo_MaTaiKhoan(int maKhoaSo)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a KhoaSo_MaTaiKhoan");
            return DataPortal.Fetch<KhoaSo_MaTaiKhoan>(new Criteria(maKhoaSo));
        }

        public static void DeleteKhoaSo_MaTaiKhoan(int maKhoaSo)
        {
            if (!CanDeleteObject())
                throw new System.Security.SecurityException("User not authorized to remove a KhoaSo_MaTaiKhoan");
            DataPortal.Delete(new Criteria(maKhoaSo));
        }

        public override KhoaSo_MaTaiKhoan Save()
        {
            if (IsDeleted && !CanDeleteObject())
                throw new System.Security.SecurityException("User not authorized to remove a KhoaSo_MaTaiKhoan");
            else if (IsNew && !CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a KhoaSo_MaTaiKhoan");
            else if (!CanEditObject())
                throw new System.Security.SecurityException("User not authorized to update a KhoaSo_MaTaiKhoan");

            return base.Save();
        }

        #endregion //Factory Methods

        #region Child Factory Methods
        internal static KhoaSo_MaTaiKhoan NewKhoaSo_MaTaiKhoanChild()
        {
            KhoaSo_MaTaiKhoan child = new KhoaSo_MaTaiKhoan();
            child.ValidationRules.CheckRules();
            child.MarkAsChild();
            return child;
        }

        internal static KhoaSo_MaTaiKhoan GetKhoaSo_MaTaiKhoan(SafeDataReader dr)
        {
            KhoaSo_MaTaiKhoan child = new KhoaSo_MaTaiKhoan();
            child.MarkAsChild();
            child.Fetch(dr);
            return child;
        }

        internal static KhoaSo_MaTaiKhoan GetKhoaSo_MaTaiKhoanForNew(SafeDataReader dr)
        {
            KhoaSo_MaTaiKhoan child = new KhoaSo_MaTaiKhoan();
            child.MarkAsChild();
            child.FetchNew(dr);
            return child;
        }

        internal static KhoaSo_MaTaiKhoan GetKhoaSo_MaTaiKhoanByMaKy(SafeDataReader dr)
        {
            KhoaSo_MaTaiKhoan child = new KhoaSo_MaTaiKhoan();
            child.MarkAsChild();
            child.FetchByMaKy(dr);
            return child;
        }
        #endregion //Child Factory Methods

        #region Data Access

        #region Criteria

        [Serializable()]
        private class Criteria
        {
            public int MaKhoaSo;

            public Criteria(int maKhoaSo)
            {
                this.MaKhoaSo = maKhoaSo;
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
                cm.CommandText = "spd_SelecttblKhoaSo_MaTaiKhoan";

                cm.Parameters.AddWithValue("@MaKhoaSo", criteria.MaKhoaSo);

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
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();

                ExecuteInsert(cn);

                //update child object(s)
                UpdateChildren(cn);
            }//using

        }

        #endregion //Data Access - Insert

        #region Data Access - Update
        protected override void DataPortal_Update()
        {
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();

                if (base.IsDirty)
                {
                    ExecuteUpdate(cn);
                }

                //update child object(s)
                UpdateChildren(cn);
            }//using

        }

        #endregion //Data Access - Update

        #region Data Access - Delete
        protected override void DataPortal_DeleteSelf()
        {
            DataPortal_Delete(new Criteria(_maKhoaSo));
        }

        private void DataPortal_Delete(Criteria criteria)
        {
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();

                ExecuteDelete(cn, criteria);

            }//using

        }

        private void ExecuteDelete(SqlConnection cn, Criteria criteria)
        {
            using (SqlCommand cm = cn.CreateCommand())
            {
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_DeletetblKhoaSo_MaTaiKhoan";

                cm.Parameters.AddWithValue("@MaKhoaSo", criteria.MaKhoaSo);

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
        private void FetchNew(SafeDataReader dr)
        {
            FetchObject(dr);
            MarkNew();
            ValidationRules.CheckRules();

            //load child object(s)
            FetchChildren(dr);
        }

        private void FetchObject(SafeDataReader dr)
        {
            _maKhoaSo = dr.GetInt32("MaKhoaSo");
            _maKy = dr.GetInt32("MaKy");
            _userID = dr.GetInt32("UserID");
            _maTaiKhoan = dr.GetInt32("MaTaiKhoan");
            _khoaSo = dr.GetBoolean("KhoaSo");
            _ngayBatDau = dr.GetDateTime("NgayBatDau");// Ky.GetKy(_maKy).NgayBatDau;
            _ngayKetThuc = dr.GetDateTime("NgayKetThuc");//Ky.GetKy(_maKy).NgayKetThuc;
            _tenDangNhap = dr.GetString("TenDangNhap");//ERP_Library.Security.UserItem.GetUserItem(_userID).TenDangNhap;
        }

        private void FetchByMaKy(SafeDataReader dr)
        {
            FetchObjectByMaKy(dr);
            if (_maKhoaSo == 0)
                MarkNew();
            else
                MarkOld();

            ValidationRules.CheckRules();

            //load child object(s)
            FetchChildren(dr);
        }

        private void FetchObjectByMaKy(SafeDataReader dr)
        {
            _maKhoaSo = dr.GetInt32("MaKhoaSo");
            _maKy = dr.GetInt32("MaKy");
            _userID = dr.GetInt32("UserID");
            _maTaiKhoan = dr.GetInt32("MaTaiKhoan");
            _khoaSo = dr.GetBoolean("KhoaSo");
            //_ngayBatDau = dr.GetDateTime("NgayBatDau");// Ky.GetKy(_maKy).NgayBatDau;
            //_ngayKetThuc = dr.GetDateTime("NgayKetThuc");//Ky.GetKy(_maKy).NgayKetThuc;
            //_tenDangNhap = dr.GetString("TenDangNhap");//ERP_Library.Security.UserItem.GetUserItem(_userID).TenDangNhap;
            _tenTaiKhoan = dr.GetString("TenTaiKhoan");
            _soHieuTK = dr.GetString("SoHieuTK");
            _maTaiKhoanCha = dr.GetInt32("MaTaiKhoanCha");
        }

        private void FetchChildren(SafeDataReader dr)
        {
        }
        #endregion //Data Access - Fetch

        #region Data Access - Insert
        internal void Insert(SqlConnection cn)
        {
            if (!IsDirty) return;

            ExecuteInsert(cn);
            MarkOld();

            //update child object(s)
            UpdateChildren(cn);
        }

        private void ExecuteInsert(SqlConnection cn)
        {
            using (SqlCommand cm = cn.CreateCommand())
            {
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_InserttblKhoaSo_MaTaiKhoan";

                AddInsertParameters(cm);

                cm.ExecuteNonQuery();

                _maKhoaSo = (int)cm.Parameters["@MaKhoaSo"].Value;
            }//using
        }

        private void AddInsertParameters(SqlCommand cm)
        {
            cm.Parameters.AddWithValue("@MaKy", _maKy);
            if (_userID != 0)
                cm.Parameters.AddWithValue("@UserID", _userID);
            else
                cm.Parameters.AddWithValue("@UserID", DBNull.Value);
            if (_maTaiKhoan != 0)
                cm.Parameters.AddWithValue("@MaTaiKhoan", _maTaiKhoan);
            else
                cm.Parameters.AddWithValue("@MaTaiKhoan", DBNull.Value);
            if (_khoaSo != false)
                cm.Parameters.AddWithValue("@KhoaSo", _khoaSo);
            else
                cm.Parameters.AddWithValue("@KhoaSo", DBNull.Value);
            cm.Parameters.AddWithValue("@MaKhoaSo", _maKhoaSo);
            cm.Parameters["@MaKhoaSo"].Direction = ParameterDirection.Output;
        }
        #endregion //Data Access - Insert

        #region Data Access - Update
        internal void Update(SqlConnection cn)
        {
            if (!IsDirty) return;

            if (base.IsDirty)
            {
                ExecuteUpdate(cn);
                MarkOld();
            }

            //update child object(s)
            UpdateChildren(cn);
        }

        private void ExecuteUpdate(SqlConnection cn)
        {
            using (SqlCommand cm = cn.CreateCommand())
            {
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_UpdatetblKhoaSo_MaTaiKhoan";

                AddUpdateParameters(cm);

                cm.ExecuteNonQuery();

            }//using
        }

        private void AddUpdateParameters(SqlCommand cm)
        {
            cm.Parameters.AddWithValue("@MaKhoaSo", _maKhoaSo);
            cm.Parameters.AddWithValue("@MaKy", _maKy);
            if (_userID != 0)
                cm.Parameters.AddWithValue("@UserID", _userID);
            else
                cm.Parameters.AddWithValue("@UserID", DBNull.Value);
            if (_maTaiKhoan != 0)
                cm.Parameters.AddWithValue("@MaTaiKhoan", _maTaiKhoan);
            else
                cm.Parameters.AddWithValue("@MaTaiKhoan", DBNull.Value);
            if (_khoaSo != false)
                cm.Parameters.AddWithValue("@KhoaSo", _khoaSo);
            else
                cm.Parameters.AddWithValue("@KhoaSo", DBNull.Value);
        }

        private void UpdateChildren(SqlConnection cn)
        {
        }
        #endregion //Data Access - Update

        #region Data Access - Delete
        internal void DeleteSelf(SqlConnection cn)
        {
            if (!IsDirty) return;
            if (IsNew) return;

            ExecuteDelete(cn, new Criteria(_maKhoaSo));
            MarkNew();
        }
        #endregion //Data Access - Delete
        #endregion //Data Access
    }
}
