
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{
    [Serializable()]
    public class SoDuDauKyTheoDoiTuong : Csla.BusinessBase<SoDuDauKyTheoDoiTuong>
    {
        #region Business Properties and Methods

        //declare members
        private long _maSo = 0;
        private int _maTaiKhoan = 0;
        private long _maDoiTuong = 0;
        private decimal _soDuDauKyNo = 0;
        private decimal _soDuDauKyCo = 0;
        private decimal _phatSinhNoTrongKy = 0;
        private decimal _phatSinhCoTrongKy = 0;
        private decimal _luyKeNo = 0;
        private decimal _luyKeCo = 0;
        private int _maKy = 0;
        private int _maBoPhan = 0;

        [System.ComponentModel.DataObjectField(true, true)]
        public long MaSo
        {
            get
            {
                CanReadProperty("MaSo", true);
                return _maSo;
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

        public long MaDoiTuong
        {
            get
            {
                CanReadProperty("MaDoiTuong", true);
                return _maDoiTuong;
            }
            set
            {
                CanWriteProperty("MaDoiTuong", true);
                if (!_maDoiTuong.Equals(value))
                {
                    _maDoiTuong = value;
                    PropertyHasChanged("MaDoiTuong");
                }
            }
        }

        public decimal SoDuDauKyNo
        {
            get
            {
                CanReadProperty("SoDuDauKyNo", true);
                return _soDuDauKyNo;
            }
            set
            {
                CanWriteProperty("SoDuDauKyNo", true);
                if (!_soDuDauKyNo.Equals(value))
                {
                    _soDuDauKyNo = value;
                    PropertyHasChanged("SoDuDauKyNo");
                }
            }
        }

        public decimal SoDuDauKyCo
        {
            get
            {
                CanReadProperty("SoDuDauKyCo", true);
                return _soDuDauKyCo;
            }
            set
            {
                CanWriteProperty("SoDuDauKyCo", true);
                if (!_soDuDauKyCo.Equals(value))
                {
                    _soDuDauKyCo = value;
                    PropertyHasChanged("SoDuDauKyCo");
                }
            }
        }

        public decimal PhatSinhNoTrongKy
        {
            get
            {
                CanReadProperty("PhatSinhNoTrongKy", true);
                return _phatSinhNoTrongKy;
            }
            set
            {
                CanWriteProperty("PhatSinhNoTrongKy", true);
                if (!_phatSinhNoTrongKy.Equals(value))
                {
                    _phatSinhNoTrongKy = value;
                    PropertyHasChanged("PhatSinhNoTrongKy");
                }
            }
        }

        public decimal PhatSinhCoTrongKy
        {
            get
            {
                CanReadProperty("PhatSinhCoTrongKy", true);
                return _phatSinhCoTrongKy;
            }
            set
            {
                CanWriteProperty("PhatSinhCoTrongKy", true);
                if (!_phatSinhCoTrongKy.Equals(value))
                {
                    _phatSinhCoTrongKy = value;
                    PropertyHasChanged("PhatSinhCoTrongKy");
                }
            }
        }

        public decimal LuyKeNo
        {
            get
            {
                CanReadProperty("LuyKeNo", true);
                return _luyKeNo;
            }
            set
            {
                CanWriteProperty("LuyKeNo", true);
                if (!_luyKeNo.Equals(value))
                {
                    _luyKeNo = value;
                    PropertyHasChanged("LuyKeNo");
                }
            }
        }

        public decimal LuyKeCo
        {
            get
            {
                CanReadProperty("LuyKeCo", true);
                return _luyKeCo;
            }
            set
            {
                CanWriteProperty("LuyKeCo", true);
                if (!_luyKeCo.Equals(value))
                {
                    _luyKeCo = value;
                    PropertyHasChanged("LuyKeCo");
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

        private string _soHieuTK;
        public string SoHieuTK
        {
            get
            {
                CanReadProperty("SoHieuTK", true);
                return _soHieuTK;
            }
        }

        private string _tenTaiKhoan;
        public string TenTaiKhoan
        {
            get
            {
                CanReadProperty("TenTaiKhoan", true);
                return _tenTaiKhoan;
            }
        }

        private string _tenDoiTuong;
        public string TenDoiTuong
        {
            get
            {
                CanReadProperty("TenDoiTuong", true);
                return _tenDoiTuong;
            }
        }

        private string _maDoiTuongQL;
        public string MaDoiTuongQL
        {
            get
            {
                CanReadProperty("MaDoiTuongQL", true);
                return _maDoiTuongQL;
            }
        }
        protected override object GetIdValue()
        {
            return _maSo;
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
            //TODO: Define authorization rules in SoDuDauKyTheoDoiTuong
            //AuthorizationRules.AllowRead("MaSo", "SoDuDauKyTheoDoiTuongReadGroup");
            //AuthorizationRules.AllowRead("MaTaiKhoan", "SoDuDauKyTheoDoiTuongReadGroup");
            //AuthorizationRules.AllowRead("MaDoiTuong", "SoDuDauKyTheoDoiTuongReadGroup");
            //AuthorizationRules.AllowRead("SoDuDauKyNo", "SoDuDauKyTheoDoiTuongReadGroup");
            //AuthorizationRules.AllowRead("SoDuDauKyCo", "SoDuDauKyTheoDoiTuongReadGroup");
            //AuthorizationRules.AllowRead("PhatSinhNoTrongKy", "SoDuDauKyTheoDoiTuongReadGroup");
            //AuthorizationRules.AllowRead("PhatSinhCoTrongKy", "SoDuDauKyTheoDoiTuongReadGroup");
            //AuthorizationRules.AllowRead("LuyKeNo", "SoDuDauKyTheoDoiTuongReadGroup");
            //AuthorizationRules.AllowRead("LuyKeCo", "SoDuDauKyTheoDoiTuongReadGroup");
            //AuthorizationRules.AllowRead("MaKy", "SoDuDauKyTheoDoiTuongReadGroup");
            //AuthorizationRules.AllowRead("MaBoPhan", "SoDuDauKyTheoDoiTuongReadGroup");

            //AuthorizationRules.AllowWrite("MaTaiKhoan", "SoDuDauKyTheoDoiTuongWriteGroup");
            //AuthorizationRules.AllowWrite("MaDoiTuong", "SoDuDauKyTheoDoiTuongWriteGroup");
            //AuthorizationRules.AllowWrite("SoDuDauKyNo", "SoDuDauKyTheoDoiTuongWriteGroup");
            //AuthorizationRules.AllowWrite("SoDuDauKyCo", "SoDuDauKyTheoDoiTuongWriteGroup");
            //AuthorizationRules.AllowWrite("PhatSinhNoTrongKy", "SoDuDauKyTheoDoiTuongWriteGroup");
            //AuthorizationRules.AllowWrite("PhatSinhCoTrongKy", "SoDuDauKyTheoDoiTuongWriteGroup");
            //AuthorizationRules.AllowWrite("LuyKeNo", "SoDuDauKyTheoDoiTuongWriteGroup");
            //AuthorizationRules.AllowWrite("LuyKeCo", "SoDuDauKyTheoDoiTuongWriteGroup");
            //AuthorizationRules.AllowWrite("MaKy", "SoDuDauKyTheoDoiTuongWriteGroup");
            //AuthorizationRules.AllowWrite("MaBoPhan", "SoDuDauKyTheoDoiTuongWriteGroup");
        }


        public static bool CanGetObject()
        {
            //TODO: Define CanGetObject permission in SoDuDauKyTheoDoiTuong
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("SoDuDauKyTheoDoiTuongViewGroup"))
            //	return true;
            //return false;
        }

        public static bool CanAddObject()
        {
            //TODO: Define CanAddObject permission in SoDuDauKyTheoDoiTuong
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("SoDuDauKyTheoDoiTuongAddGroup"))
            //	return true;
            //return false;
        }

        public static bool CanEditObject()
        {
            //TODO: Define CanEditObject permission in SoDuDauKyTheoDoiTuong
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("SoDuDauKyTheoDoiTuongEditGroup"))
            //	return true;
            //return false;
        }

        public static bool CanDeleteObject()
        {
            //TODO: Define CanDeleteObject permission in SoDuDauKyTheoDoiTuong
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("SoDuDauKyTheoDoiTuongDeleteGroup"))
            //	return true;
            //return false;
        }
        #endregion //Authorization Rules

        #region Factory Methods
        private SoDuDauKyTheoDoiTuong()
        { /* require use of factory method */ }

        public static SoDuDauKyTheoDoiTuong NewSoDuDauKyTheoDoiTuong()
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a SoDuDauKyTheoDoiTuong");
            return DataPortal.Create<SoDuDauKyTheoDoiTuong>();
        }

        public static SoDuDauKyTheoDoiTuong GetSoDuDauKyTheoDoiTuong(long maSo)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a SoDuDauKyTheoDoiTuong");
            return DataPortal.Fetch<SoDuDauKyTheoDoiTuong>(new Criteria(maSo));
        }

        public static void DeleteSoDuDauKyTheoDoiTuong(long maSo)
        {
            if (!CanDeleteObject())
                throw new System.Security.SecurityException("User not authorized to remove a SoDuDauKyTheoDoiTuong");
            DataPortal.Delete(new Criteria(maSo));
        }

        public override SoDuDauKyTheoDoiTuong Save()
        {
            if (IsDeleted && !CanDeleteObject())
                throw new System.Security.SecurityException("User not authorized to remove a SoDuDauKyTheoDoiTuong");
            else if (IsNew && !CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a SoDuDauKyTheoDoiTuong");
            else if (!CanEditObject())
                throw new System.Security.SecurityException("User not authorized to update a SoDuDauKyTheoDoiTuong");

            return base.Save();
        }

        #endregion //Factory Methods

        #region Child Factory Methods
        internal static SoDuDauKyTheoDoiTuong NewSoDuDauKyTheoDoiTuongChild()
        {
            SoDuDauKyTheoDoiTuong child = new SoDuDauKyTheoDoiTuong();
            child.ValidationRules.CheckRules();
            child.MarkAsChild();
            return child;
        }

        internal static SoDuDauKyTheoDoiTuong GetSoDuDauKyTheoDoiTuong(SafeDataReader dr, bool kiemTra)
        {
            SoDuDauKyTheoDoiTuong child = new SoDuDauKyTheoDoiTuong();
            child.MarkAsChild();
            child.Fetch(dr, kiemTra);
            return child;
        }

        internal static SoDuDauKyTheoDoiTuong GetSoDuDauKyTheoDoiTuong(SafeDataReader dr)
        {
            SoDuDauKyTheoDoiTuong child = new SoDuDauKyTheoDoiTuong();
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
            public long MaSo;

            public Criteria(long maSo)
            {
                this.MaSo = maSo;
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
                cm.CommandText = "spd_SelecttblSoDuDauKyTheoDoiTuong";

                cm.Parameters.AddWithValue("@MaSo", criteria.MaSo);

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
            DataPortal_Delete(new Criteria(_maSo));
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
                cm.CommandText = "spd_DeletetblSoDuDauKyTheoDoiTuong";

                cm.Parameters.AddWithValue("@MaSo", criteria.MaSo);

                cm.ExecuteNonQuery();
            }//using
        }
        #endregion //Data Access - Delete

        #region Data Access - Fetch
        private void Fetch(SafeDataReader dr, bool kiemTra)
        {
            FetchObject(dr);
            if (kiemTra == false)
                MarkNew();
            else
                MarkOld();
            ValidationRules.CheckRules();

            //load child object(s)
            FetchChildren(dr);
        }

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
            _maSo = dr.GetInt64("MaSo");
            _maTaiKhoan = dr.GetInt32("MaTaiKhoan");
            _maDoiTuong = dr.GetInt64("MaDoiTuong");
            _soDuDauKyNo = dr.GetDecimal("SoDuDauKyNo");
            _soDuDauKyCo = dr.GetDecimal("SoDuDauKyCo");
            _phatSinhNoTrongKy = dr.GetDecimal("PhatSinhNoTrongKy");
            _phatSinhCoTrongKy = dr.GetDecimal("PhatSinhCoTrongKy");
            _luyKeNo = dr.GetDecimal("LuyKeNo");
            _luyKeCo = dr.GetDecimal("LuyKeCo");
            _maKy = dr.GetInt32("MaKy");
            _maBoPhan = dr.GetInt32("MaBoPhan");
            _soHieuTK = dr.GetString("SoHieuTK");
            _tenTaiKhoan = dr.GetString("TenTaiKhoan");
            _tenDoiTuong = dr.GetString("TenDoiTuong");
            _maDoiTuongQL = dr.GetString("MaDoiTuongQL");
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
                cm.CommandText = "spd_InserttblSoDuDauKyTheoDoiTuong";

                AddInsertParameters(cm);

                cm.ExecuteNonQuery();

                _maSo = (long)cm.Parameters["@MaSo"].Value;
            }//using
        }

        private void AddInsertParameters(SqlCommand cm)
        {
            if (_maTaiKhoan != 0)
                cm.Parameters.AddWithValue("@MaTaiKhoan", _maTaiKhoan);
            else
                cm.Parameters.AddWithValue("@MaTaiKhoan", DBNull.Value);
            if (_maDoiTuong != 0)
                cm.Parameters.AddWithValue("@MaDoiTuong", _maDoiTuong);
            else
                cm.Parameters.AddWithValue("@MaDoiTuong", DBNull.Value);
            if (_soDuDauKyNo != 0)
                cm.Parameters.AddWithValue("@SoDuDauKyNo", _soDuDauKyNo);
            else
                cm.Parameters.AddWithValue("@SoDuDauKyNo", DBNull.Value);
            if (_soDuDauKyCo != 0)
                cm.Parameters.AddWithValue("@SoDuDauKyCo", _soDuDauKyCo);
            else
                cm.Parameters.AddWithValue("@SoDuDauKyCo", DBNull.Value);
            if (_phatSinhNoTrongKy != 0)
                cm.Parameters.AddWithValue("@PhatSinhNoTrongKy", _phatSinhNoTrongKy);
            else
                cm.Parameters.AddWithValue("@PhatSinhNoTrongKy", DBNull.Value);
            if (_phatSinhCoTrongKy != 0)
                cm.Parameters.AddWithValue("@PhatSinhCoTrongKy", _phatSinhCoTrongKy);
            else
                cm.Parameters.AddWithValue("@PhatSinhCoTrongKy", DBNull.Value);
            if (_luyKeNo != 0)
                cm.Parameters.AddWithValue("@LuyKeNo", _luyKeNo);
            else
                cm.Parameters.AddWithValue("@LuyKeNo", DBNull.Value);
            if (_luyKeCo != 0)
                cm.Parameters.AddWithValue("@LuyKeCo", _luyKeCo);
            else
                cm.Parameters.AddWithValue("@LuyKeCo", DBNull.Value);
            if (_maKy != 0)
                cm.Parameters.AddWithValue("@MaKy", _maKy);
            else
                cm.Parameters.AddWithValue("@MaKy", DBNull.Value);
            if (_maBoPhan != 0)
                cm.Parameters.AddWithValue("@MaBoPhan", _maBoPhan);
            else
                cm.Parameters.AddWithValue("@MaBoPhan", DBNull.Value);
            cm.Parameters.AddWithValue("@MaSo", _maSo);
            cm.Parameters["@MaSo"].Direction = ParameterDirection.Output;
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
                cm.CommandText = "spd_UpdatetblSoDuDauKyTheoDoiTuong";

                AddUpdateParameters(cm);

                cm.ExecuteNonQuery();

            }//using
        }

        private void AddUpdateParameters(SqlCommand cm)
        {
            cm.Parameters.AddWithValue("@MaSo", _maSo);
            if (_maTaiKhoan != 0)
                cm.Parameters.AddWithValue("@MaTaiKhoan", _maTaiKhoan);
            else
                cm.Parameters.AddWithValue("@MaTaiKhoan", DBNull.Value);
            if (_maDoiTuong != 0)
                cm.Parameters.AddWithValue("@MaDoiTuong", _maDoiTuong);
            else
                cm.Parameters.AddWithValue("@MaDoiTuong", DBNull.Value);
            if (_soDuDauKyNo != 0)
                cm.Parameters.AddWithValue("@SoDuDauKyNo", _soDuDauKyNo);
            else
                cm.Parameters.AddWithValue("@SoDuDauKyNo", DBNull.Value);
            if (_soDuDauKyCo != 0)
                cm.Parameters.AddWithValue("@SoDuDauKyCo", _soDuDauKyCo);
            else
                cm.Parameters.AddWithValue("@SoDuDauKyCo", DBNull.Value);
            if (_phatSinhNoTrongKy != 0)
                cm.Parameters.AddWithValue("@PhatSinhNoTrongKy", _phatSinhNoTrongKy);
            else
                cm.Parameters.AddWithValue("@PhatSinhNoTrongKy", DBNull.Value);
            if (_phatSinhCoTrongKy != 0)
                cm.Parameters.AddWithValue("@PhatSinhCoTrongKy", _phatSinhCoTrongKy);
            else
                cm.Parameters.AddWithValue("@PhatSinhCoTrongKy", DBNull.Value);
            if (_luyKeNo != 0)
                cm.Parameters.AddWithValue("@LuyKeNo", _luyKeNo);
            else
                cm.Parameters.AddWithValue("@LuyKeNo", DBNull.Value);
            if (_luyKeCo != 0)
                cm.Parameters.AddWithValue("@LuyKeCo", _luyKeCo);
            else
                cm.Parameters.AddWithValue("@LuyKeCo", DBNull.Value);
            if (_maKy != 0)
                cm.Parameters.AddWithValue("@MaKy", _maKy);
            else
                cm.Parameters.AddWithValue("@MaKy", DBNull.Value);
            if (_maBoPhan != 0)
                cm.Parameters.AddWithValue("@MaBoPhan", _maBoPhan);
            else
                cm.Parameters.AddWithValue("@MaBoPhan", DBNull.Value);
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

            ExecuteDelete(tr, new Criteria(_maSo));
            MarkNew();
        }
        #endregion //Data Access - Delete

        #region KiemTraKyKetChuyen
        public static int KiemTraKyKetChuyen(int MaKy, int MaBoPhan)
        {
            int GiaTriTrave;
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_KiemTraSoDuTaiKhoanTheoDoiTuong";
                    cm.Parameters.AddWithValue("@MaKy", MaKy);
                    cm.Parameters.AddWithValue("@MaBoPhan", MaBoPhan);
                    cm.Parameters.AddWithValue("@UserID", ERP_Library.Security.CurrentUser.Info.UserID);
                    SqlParameter prmGiaTriTraVe = new SqlParameter("@GiaTriTraVe", SqlDbType.Int);
                    prmGiaTriTraVe.Direction = ParameterDirection.Output;
                    cm.Parameters.Add(prmGiaTriTraVe);
                    cm.ExecuteNonQuery();
                    GiaTriTrave = (int)prmGiaTriTraVe.Value;

                }
            }
            return GiaTriTrave;
        }
        #endregion

        #region ket chuyen so du doi tuong qua so du tai khoan
        public static void UpdateSoDuTaiKhoan_BySoDuTheoDoiTuong(int MaKy, int MaBoPhan)
        {
            int GiaTriTrave;
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_UpdateSoDuTaiKhoan_BySoDuTheoDoiTuong";
                    cm.Parameters.AddWithValue("@MaKy", MaKy);
                    cm.Parameters.AddWithValue("@MaBoPhan", MaBoPhan);
                    cm.Parameters.AddWithValue("@UserID", ERP_Library.Security.CurrentUser.Info.UserID);                  
                    cm.ExecuteNonQuery();                
                }
            }            
        }
        #endregion
        #endregion //Data Access
    }
}
