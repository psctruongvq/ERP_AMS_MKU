
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{
    [Serializable()]
    public class SoDuDauKyHopDong : Csla.BusinessBase<SoDuDauKyHopDong>
    {
        #region Business Properties and Methods

        //declare members
        private long _maChiTiet = 0;
        private long _maHopDong = 0;
        private decimal _soDuDauKyNo = 0;
        private decimal _soDuDauKyCo = 0;
        private int _maKy = 0;
        private int _maBoPhan = 0;
        private string _soHopDong = string.Empty;
        private string _tenDoiTac = string.Empty;
        private int _maTaiKhoan = 0;
        private string _soHieuTK = string.Empty;
        private string _tenTaiKhoan = string.Empty;

        [System.ComponentModel.DataObjectField(true, true)]
        public long MaChiTiet
        {
            get
            {
                CanReadProperty("MaChiTiet", true);
                return _maChiTiet;
            }
        }

        public long MaHopDong
        {
            get
            {
                CanReadProperty("MaHopDong", true);
                return _maHopDong;
            }
            set
            {
                CanWriteProperty("MaHopDong", true);
                if (!_maHopDong.Equals(value))
                {
                    _maHopDong = value;
                    PropertyHasChanged("MaHopDong");
                }
            }
        }

        public string SoHopDong
        {
            get
            {
                CanReadProperty("SoHopDong", true);
                return _soHopDong;
            }
            set
            {
                CanWriteProperty("SoHopDong", true);
                if (!_soHopDong.Equals(value))
                {
                    _soHopDong = value;
                    PropertyHasChanged("SoHopDong");
                }
            }
        }

        public string TenDoiTac
        {
            get
            {
                CanReadProperty("TenDoiTac", true);
                return _tenDoiTac;
            }
            set
            {
                CanWriteProperty("TenDoiTac", true);
                if (!_tenDoiTac.Equals(value))
                {
                    _tenDoiTac = value;
                    PropertyHasChanged("TenDoiTac");
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
                    if (_maTaiKhoan != 0)
                    {
                        _tenTaiKhoan = HeThongTaiKhoan1.GetHeThongTaiKhoan1(_maTaiKhoan).TenTaiKhoan;
                    }
                }
            }
        }

        protected override object GetIdValue()
        {
            return _maChiTiet;
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
            //TODO: Define authorization rules in SoDuDauKyHopDong
            //AuthorizationRules.AllowRead("MaChiTiet", "SoDuDauKyHopDongReadGroup");
            //AuthorizationRules.AllowRead("MaTaiKhoan", "SoDuDauKyHopDongReadGroup");
            //AuthorizationRules.AllowRead("MaHopDong", "SoDuDauKyHopDongReadGroup");
            //AuthorizationRules.AllowRead("SoDuDauKyNo", "SoDuDauKyHopDongReadGroup");
            //AuthorizationRules.AllowRead("SoDuDauKyCo", "SoDuDauKyHopDongReadGroup");
            //AuthorizationRules.AllowRead("PhatSinhNoTrongKy", "SoDuDauKyHopDongReadGroup");
            //AuthorizationRules.AllowRead("PhatSinhCoTrongKy", "SoDuDauKyHopDongReadGroup");
            //AuthorizationRules.AllowRead("LuyKeNo", "SoDuDauKyHopDongReadGroup");
            //AuthorizationRules.AllowRead("LuyKeCo", "SoDuDauKyHopDongReadGroup");
            //AuthorizationRules.AllowRead("MaKy", "SoDuDauKyHopDongReadGroup");
            //AuthorizationRules.AllowRead("MaBoPhan", "SoDuDauKyHopDongReadGroup");

            //AuthorizationRules.AllowWrite("MaTaiKhoan", "SoDuDauKyHopDongWriteGroup");
            //AuthorizationRules.AllowWrite("MaHopDong", "SoDuDauKyHopDongWriteGroup");
            //AuthorizationRules.AllowWrite("SoDuDauKyNo", "SoDuDauKyHopDongWriteGroup");
            //AuthorizationRules.AllowWrite("SoDuDauKyCo", "SoDuDauKyHopDongWriteGroup");
            //AuthorizationRules.AllowWrite("PhatSinhNoTrongKy", "SoDuDauKyHopDongWriteGroup");
            //AuthorizationRules.AllowWrite("PhatSinhCoTrongKy", "SoDuDauKyHopDongWriteGroup");
            //AuthorizationRules.AllowWrite("LuyKeNo", "SoDuDauKyHopDongWriteGroup");
            //AuthorizationRules.AllowWrite("LuyKeCo", "SoDuDauKyHopDongWriteGroup");
            //AuthorizationRules.AllowWrite("MaKy", "SoDuDauKyHopDongWriteGroup");
            //AuthorizationRules.AllowWrite("MaBoPhan", "SoDuDauKyHopDongWriteGroup");
        }


        public static bool CanGetObject()
        {
            //TODO: Define CanGetObject permission in SoDuDauKyHopDong
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("SoDuDauKyHopDongViewGroup"))
            //	return true;
            //return false;
        }

        public static bool CanAddObject()
        {
            //TODO: Define CanAddObject permission in SoDuDauKyHopDong
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("SoDuDauKyHopDongAddGroup"))
            //	return true;
            //return false;
        }

        public static bool CanEditObject()
        {
            //TODO: Define CanEditObject permission in SoDuDauKyHopDong
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("SoDuDauKyHopDongEditGroup"))
            //	return true;
            //return false;
        }

        public static bool CanDeleteObject()
        {
            //TODO: Define CanDeleteObject permission in SoDuDauKyHopDong
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("SoDuDauKyHopDongDeleteGroup"))
            //	return true;
            //return false;
        }
        #endregion //Authorization Rules

        #region Factory Methods
        private SoDuDauKyHopDong()
        { /* require use of factory method */ }

        public static SoDuDauKyHopDong NewSoDuDauKyHopDong()
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a SoDuDauKyHopDong");
            return DataPortal.Create<SoDuDauKyHopDong>();
        }

        public static SoDuDauKyHopDong GetSoDuDauKyHopDong(long maChiTiet)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a SoDuDauKyHopDong");
            return DataPortal.Fetch<SoDuDauKyHopDong>(new Criteria(maChiTiet));
        }

        public static void DeleteSoDuDauKyHopDong(long maChiTiet)
        {
            if (!CanDeleteObject())
                throw new System.Security.SecurityException("User not authorized to remove a SoDuDauKyHopDong");
            DataPortal.Delete(new Criteria(maChiTiet));
        }

        public override SoDuDauKyHopDong Save()
        {
            if (IsDeleted && !CanDeleteObject())
                throw new System.Security.SecurityException("User not authorized to remove a SoDuDauKyHopDong");
            else if (IsNew && !CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a SoDuDauKyHopDong");
            else if (!CanEditObject())
                throw new System.Security.SecurityException("User not authorized to update a SoDuDauKyHopDong");

            return base.Save();
        }

        #endregion //Factory Methods

        #region Child Factory Methods
        internal static SoDuDauKyHopDong NewSoDuDauKyHopDongChild()
        {
            SoDuDauKyHopDong child = new SoDuDauKyHopDong();
            child.ValidationRules.CheckRules();
            child.MarkAsChild();
            return child;
        }

        internal static SoDuDauKyHopDong GetSoDuDauKyHopDong(SafeDataReader dr)
        {
            SoDuDauKyHopDong child = new SoDuDauKyHopDong();
            child.MarkAsChild();
            child.Fetch(dr);
            return child;
        }

        internal static SoDuDauKyHopDong GetSoDuDauKyHopDong(SafeDataReader dr, bool bKiemTra)
        {
            SoDuDauKyHopDong child = new SoDuDauKyHopDong();
            child.MarkAsChild();
            child.Fetch(dr, bKiemTra);
            return child;
        }
        #endregion //Child Factory Methods

        #region Data Access

        #region Criteria

        [Serializable()]
        private class Criteria
        {
            public long MaChiTiet;

            public Criteria(long maChiTiet)
            {
                this.MaChiTiet = maChiTiet;
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
                cm.CommandText = "spd_SelecttblSoDuDauKyTheoHopDong";

                cm.Parameters.AddWithValue("@MaChiTiet", criteria.MaChiTiet);

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
                    ExecuteInsert(tr, null);

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
                        ExecuteUpdate(tr, null);
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
            DataPortal_Delete(new Criteria(_maChiTiet));
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
                cm.CommandText = "spd_DeletetblSoDuDauKyTheoHopDong";

                cm.Parameters.AddWithValue("@MaChiTiet", criteria.MaChiTiet);

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

        private void Fetch(SafeDataReader dr, bool bKiemTra) 
        {
            FetchObject(dr);
            if (bKiemTra)
                MarkOld();
            else
                MarkNew();
            ValidationRules.CheckRules();

            //load child object(s)
            FetchChildren(dr);
        }

        private void FetchObject(SafeDataReader dr)
        {
            _maChiTiet = dr.GetInt64("MaChiTiet");
            _maHopDong = dr.GetInt64("MaHopDong");
            _soDuDauKyNo = dr.GetDecimal("SoDuDauKyNo");
            _soDuDauKyCo = dr.GetDecimal("SoDuDauKyCo");
            _maKy = dr.GetInt32("MaKy");
            _maBoPhan = dr.GetInt32("MaBoPhan");
            _soHopDong = dr.GetString("SoHopDong");
            _tenDoiTac = dr.GetString("TenDoiTac");
            _maTaiKhoan = dr.GetInt32("MaTaiKhoan");
            _soHieuTK = dr.GetString("SoHieuTK");
            _tenTaiKhoan = dr.GetString("TenTaiKhoan");
        }

        private void FetchChildren(SafeDataReader dr)
        {
        }
        #endregion //Data Access - Fetch

        #region Data Access - Insert
        internal void Insert(SqlTransaction tr, SoDuDauKyHopDongList parent)
        {
            if (!IsDirty) return;

            ExecuteInsert(tr, parent);
            MarkOld();

            //update child object(s)
            UpdateChildren(tr);
        }

        private void ExecuteInsert(SqlTransaction tr, SoDuDauKyHopDongList parent)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_InserttblSoDuDauKyTheoHopDong";

                AddInsertParameters(cm, parent);

                cm.ExecuteNonQuery();

                _maChiTiet = (long)cm.Parameters["@MaChiTiet"].Value;
            }//using
        }

        private void AddInsertParameters(SqlCommand cm, SoDuDauKyHopDongList parent)
        {
            //TODO: if parent use identity key, fix fk member with value from parent
            if (_maHopDong != 0)
                cm.Parameters.AddWithValue("@MaHopDong", _maHopDong);
            else
                cm.Parameters.AddWithValue("@MaHopDong", DBNull.Value);
            if (_soDuDauKyNo != 0)
                cm.Parameters.AddWithValue("@SoDuDauKyNo", _soDuDauKyNo);
            else
                cm.Parameters.AddWithValue("@SoDuDauKyNo", DBNull.Value);
            if (_soDuDauKyCo != 0)
                cm.Parameters.AddWithValue("@SoDuDauKyCo", _soDuDauKyCo);
            else
                cm.Parameters.AddWithValue("@SoDuDauKyCo", DBNull.Value);
            if (_maKy != 0)
                cm.Parameters.AddWithValue("@MaKy", _maKy);
            else
                cm.Parameters.AddWithValue("@MaKy", DBNull.Value);
            if (_maBoPhan != 0)
                cm.Parameters.AddWithValue("@MaBoPhan", _maBoPhan);
            else
                cm.Parameters.AddWithValue("@MaBoPhan", DBNull.Value);
            if (_maTaiKhoan != 0)
                cm.Parameters.AddWithValue("@MaTaiKhoan", _maTaiKhoan);
            else
                cm.Parameters.AddWithValue("@MaTaiKhoan", DBNull.Value);
            cm.Parameters.AddWithValue("@MaChiTiet", _maChiTiet);
            cm.Parameters["@MaChiTiet"].Direction = ParameterDirection.Output;
        }
        #endregion //Data Access - Insert

        #region Data Access - Update
        internal void Update(SqlTransaction tr, SoDuDauKyHopDongList parent)
        {
            if (!IsDirty) return;

            if (base.IsDirty)
            {
                ExecuteUpdate(tr, parent);
                MarkOld();
            }

            //update child object(s)
            UpdateChildren(tr);
        }

        private void ExecuteUpdate(SqlTransaction tr, SoDuDauKyHopDongList parent)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_UpdatetblSoDuDauKyTheoHopDong";

                AddUpdateParameters(cm, parent);

                cm.ExecuteNonQuery();

            }//using
        }

        private void AddUpdateParameters(SqlCommand cm, SoDuDauKyHopDongList parent)
        {
            cm.Parameters.AddWithValue("@MaChiTiet", _maChiTiet);
            if (_maHopDong != 0)
                cm.Parameters.AddWithValue("@MaHopDong", _maHopDong);
            else
                cm.Parameters.AddWithValue("@MaHopDong", DBNull.Value);
            if (_soDuDauKyNo != 0)
                cm.Parameters.AddWithValue("@SoDuDauKyNo", _soDuDauKyNo);
            else
                cm.Parameters.AddWithValue("@SoDuDauKyNo", DBNull.Value);
            if (_soDuDauKyCo != 0)
                cm.Parameters.AddWithValue("@SoDuDauKyCo", _soDuDauKyCo);
            else
                cm.Parameters.AddWithValue("@SoDuDauKyCo", DBNull.Value);
            if (_maKy != 0)
                cm.Parameters.AddWithValue("@MaKy", _maKy);
            else
                cm.Parameters.AddWithValue("@MaKy", DBNull.Value);
            if (_maBoPhan != 0)
                cm.Parameters.AddWithValue("@MaBoPhan", _maBoPhan);
            else
                cm.Parameters.AddWithValue("@MaBoPhan", DBNull.Value);
            if (_maTaiKhoan != 0)
                cm.Parameters.AddWithValue("@MaTaiKhoan", _maTaiKhoan);
            else
                cm.Parameters.AddWithValue("@MaTaiKhoan", DBNull.Value);
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

            ExecuteDelete(tr, new Criteria(_maChiTiet));
            MarkNew();
        }
        #endregion //Data Access - Delete
        #endregion //Data Access
    }
}
