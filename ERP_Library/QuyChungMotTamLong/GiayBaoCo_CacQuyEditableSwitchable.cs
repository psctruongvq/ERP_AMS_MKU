
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{
    [Serializable()]
    public class GiayBaoCo_CacQuy : Csla.BusinessBase<GiayBaoCo_CacQuy>
    {
        #region Business Properties and Methods

        //declare members
        private long _maGiayBaoCo = 0;
        private string _soChungTu = string.Empty;
        private DateTime _ngayNhan = DateTime.Today;
        private long _maDoiTac = 0;
        private int _taiKhoanNhan = 0;
        private int _lapBangKe = 0;
        private decimal _soTien = 0;
        private decimal _tyGia = 0;
        private int _userId = 0;
        private int _loaiTien = 1;
        private string _dienGiai = string.Empty;
        private string _ghiChu = string.Empty;
        private int _loaiGBC = 0;
        private int _loaiDeNghi = 0;
        private DateTime _ngayHeThong = DateTime.Today;
        private bool _hoanTat = false;
        private string _tenDoiTac = string.Empty;
        private string _soTaiKhoan = string.Empty;

        [System.ComponentModel.DataObjectField(true, true)]
        public long MaGiayBaoCo
        {
            get
            {
                CanReadProperty("MaGiayBaoCo", true);
                return _maGiayBaoCo;
            }
        }

        public string SoChungTu
        {
            get
            {
                CanReadProperty("SoChungTu", true);
                return _soChungTu;
            }
            set
            {
                CanWriteProperty("SoChungTu", true);
                if (value == null) value = string.Empty;
                if (!_soChungTu.Equals(value))
                {
                    _soChungTu = value;
                    PropertyHasChanged("SoChungTu");
                }
            }
        }

        public DateTime NgayNhan
        {
            get
            {
                CanReadProperty("NgayNhan", true);
                return _ngayNhan.Date;
            }
            set
            {
                CanWriteProperty("NgayNhan", true);
                if (!_ngayNhan.Equals(value))
                {
                    _ngayNhan = value;
                    PropertyHasChanged("NgayNhan");
                }
            }
        }

        public long MaDoiTac
        {
            get
            {
                CanReadProperty("MaDoiTac", true);
                return _maDoiTac;
            }
            set
            {
                CanWriteProperty("MaDoiTac", true);
                if (!_maDoiTac.Equals(value))
                {
                    _maDoiTac = value;
                    PropertyHasChanged("MaDoiTac");
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
                if (value == null) value = string.Empty;
                if (!_tenDoiTac.Equals(value))
                {
                    _tenDoiTac = value;
                    PropertyHasChanged("TenDoiTac");
                }
            }
        }

        public int TaiKhoanNhan
        {
            get
            {
                CanReadProperty("TaiKhoanNhan", true);
                return _taiKhoanNhan;
            }
            set
            {
                CanWriteProperty("TaiKhoanNhan", true);
                if (!_taiKhoanNhan.Equals(value))
                {
                    _taiKhoanNhan = value;
                    PropertyHasChanged("TaiKhoanNhan");
                }
            }
        }

        public int LapBangKe
        {
            get
            {
                CanReadProperty("LapBangKe", true);
                return _lapBangKe;
            }
            set
            {
                CanWriteProperty("LapBangKe", true);
                if (!_lapBangKe.Equals(value))
                {
                    _lapBangKe = value;
                    PropertyHasChanged("LapBangKe");
                }
            }
        }

        public string SoTaiKhoan
        {
            get
            {
                CanReadProperty("SoTaiKhoan", true);
                return _soTaiKhoan;
            }
            set
            {
                CanWriteProperty("SoTaiKhoan", true);
                if (value == null) value = string.Empty;
                if (!_soTaiKhoan.Equals(value))
                {
                    _soTaiKhoan = value;
                    PropertyHasChanged("SoTaiKhoan");
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

        public decimal TyGia
        {
            get
            {
                CanReadProperty("TyGia", true);
                return _tyGia;
            }
            set
            {
                CanWriteProperty("TyGia", true);
                if (!_tyGia.Equals(value))
                {
                    _tyGia = value;
                    PropertyHasChanged("TyGia");
                }
            }
        }

        public int UserId
        {
            get
            {
                CanReadProperty("UserId", true);
                return _userId;
            }
            set
            {
                CanWriteProperty("UserId", true);
                if (!_userId.Equals(value))
                {
                    _userId = value;
                    PropertyHasChanged("UserId");
                }
            }
        }

        public int LoaiTien
        {
            get
            {
                CanReadProperty("LoaiTien", true);
                return _loaiTien;
            }
            set
            {
                CanWriteProperty("LoaiTien", true);
                if (!_loaiTien.Equals(value))
                {
                    _loaiTien = value;
                    PropertyHasChanged("LoaiTien");
                }
            }
        }

        public string DienGiai
        {
            get
            {
                CanReadProperty("DienGiai", true);
                return _dienGiai;
            }
            set
            {
                CanWriteProperty("DienGiai", true);
                if (value == null) value = string.Empty;
                if (!_dienGiai.Equals(value))
                {
                    _dienGiai = value;
                    PropertyHasChanged("DienGiai");
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

        public int LoaiGBC
        {
            get
            {
                CanReadProperty("LoaiGBC", true);
                return _loaiGBC;
            }
            set
            {
                CanWriteProperty("LoaiGBC", true);
                if (!_loaiGBC.Equals(value))
                {
                    _loaiGBC = value;
                    PropertyHasChanged("LoaiGBC");
                }
            }
        }

        public int LoaiDeNghi
        {
            get
            {
                CanReadProperty("LoaiDeNghi", true);
                return _loaiDeNghi;
            }
            set
            {
                CanWriteProperty("LoaiDeNghi", true);
                if (!_loaiDeNghi.Equals(value))
                {
                    _loaiDeNghi = value;
                    PropertyHasChanged("LoaiDeNghi");
                }
            }
        }

        public DateTime NgayHeThong
        {
            get
            {
                CanReadProperty("NgayHeThong", true);
                return _ngayHeThong.Date;
            }
            set
            {
                CanWriteProperty("NgayHeThong", true);
                if (!_ngayHeThong.Equals(value))
                {
                    _ngayHeThong = value;
                    PropertyHasChanged("NgayHeThong");
                }
            }
        }

        public bool HoanTat
        {
            get
            {
                CanReadProperty("HoanTat", true);
                return _hoanTat;
            }
            set
            {
                CanWriteProperty("HoanTat", true);
                if (!_hoanTat.Equals(value))
                {
                    _hoanTat = value;
                    PropertyHasChanged("HoanTat");
                }
            }
        }

        protected override object GetIdValue()
        {
            return _maGiayBaoCo;
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
            // SoChungTu
            //
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("SoChungTu", 50));
            //
            // DienGiai
            //
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("DienGiai", 4000));
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
            //TODO: Define authorization rules in GiayBaoCo_CacQuy
            //AuthorizationRules.AllowRead("MaGiayBaoCo", "GiayBaoCo_CacQuyReadGroup");
            //AuthorizationRules.AllowRead("SoChungTu", "GiayBaoCo_CacQuyReadGroup");
            //AuthorizationRules.AllowRead("NgayNhan", "GiayBaoCo_CacQuyReadGroup");
            //AuthorizationRules.AllowRead("NgayNhanString", "GiayBaoCo_CacQuyReadGroup");
            //AuthorizationRules.AllowRead("MaDoiTac", "GiayBaoCo_CacQuyReadGroup");
            //AuthorizationRules.AllowRead("TaiKhoanNhan", "GiayBaoCo_CacQuyReadGroup");
            //AuthorizationRules.AllowRead("LapBangKe", "GiayBaoCo_CacQuyReadGroup");
            //AuthorizationRules.AllowRead("SoTien", "GiayBaoCo_CacQuyReadGroup");
            //AuthorizationRules.AllowRead("TyGia", "GiayBaoCo_CacQuyReadGroup");
            //AuthorizationRules.AllowRead("UserId", "GiayBaoCo_CacQuyReadGroup");
            //AuthorizationRules.AllowRead("LoaiTien", "GiayBaoCo_CacQuyReadGroup");
            //AuthorizationRules.AllowRead("DienGiai", "GiayBaoCo_CacQuyReadGroup");
            //AuthorizationRules.AllowRead("GhiChu", "GiayBaoCo_CacQuyReadGroup");
            //AuthorizationRules.AllowRead("LoaiGBC", "GiayBaoCo_CacQuyReadGroup");
            //AuthorizationRules.AllowRead("LoaiDeNghi", "GiayBaoCo_CacQuyReadGroup");
            //AuthorizationRules.AllowRead("NgayHeThong", "GiayBaoCo_CacQuyReadGroup");
            //AuthorizationRules.AllowRead("NgayHeThongString", "GiayBaoCo_CacQuyReadGroup");
            //AuthorizationRules.AllowRead("HoanTat", "GiayBaoCo_CacQuyReadGroup");

            //AuthorizationRules.AllowWrite("SoChungTu", "GiayBaoCo_CacQuyWriteGroup");
            //AuthorizationRules.AllowWrite("NgayNhanString", "GiayBaoCo_CacQuyWriteGroup");
            //AuthorizationRules.AllowWrite("MaDoiTac", "GiayBaoCo_CacQuyWriteGroup");
            //AuthorizationRules.AllowWrite("TaiKhoanNhan", "GiayBaoCo_CacQuyWriteGroup");
            //AuthorizationRules.AllowWrite("LapBangKe", "GiayBaoCo_CacQuyWriteGroup");
            //AuthorizationRules.AllowWrite("SoTien", "GiayBaoCo_CacQuyWriteGroup");
            //AuthorizationRules.AllowWrite("TyGia", "GiayBaoCo_CacQuyWriteGroup");
            //AuthorizationRules.AllowWrite("UserId", "GiayBaoCo_CacQuyWriteGroup");
            //AuthorizationRules.AllowWrite("LoaiTien", "GiayBaoCo_CacQuyWriteGroup");
            //AuthorizationRules.AllowWrite("DienGiai", "GiayBaoCo_CacQuyWriteGroup");
            //AuthorizationRules.AllowWrite("GhiChu", "GiayBaoCo_CacQuyWriteGroup");
            //AuthorizationRules.AllowWrite("LoaiGBC", "GiayBaoCo_CacQuyWriteGroup");
            //AuthorizationRules.AllowWrite("LoaiDeNghi", "GiayBaoCo_CacQuyWriteGroup");
            //AuthorizationRules.AllowWrite("NgayHeThongString", "GiayBaoCo_CacQuyWriteGroup");
            //AuthorizationRules.AllowWrite("HoanTat", "GiayBaoCo_CacQuyWriteGroup");
        }


        public static bool CanGetObject()
        {
            //TODO: Define CanGetObject permission in GiayBaoCo_CacQuy
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("GiayBaoCo_CacQuyViewGroup"))
            //	return true;
            //return false;
        }

        public static bool CanAddObject()
        {
            //TODO: Define CanAddObject permission in GiayBaoCo_CacQuy
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("GiayBaoCo_CacQuyAddGroup"))
            //	return true;
            //return false;
        }

        public static bool CanEditObject()
        {
            //TODO: Define CanEditObject permission in GiayBaoCo_CacQuy
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("GiayBaoCo_CacQuyEditGroup"))
            //	return true;
            //return false;
        }

        public static bool CanDeleteObject()
        {
            //TODO: Define CanDeleteObject permission in GiayBaoCo_CacQuy
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("GiayBaoCo_CacQuyDeleteGroup"))
            //	return true;
            //return false;
        }
        #endregion //Authorization Rules

        #region Factory Methods
        private GiayBaoCo_CacQuy()
        { 
            /* require use of factory method */
            MarkAsChild();
        }

        public static GiayBaoCo_CacQuy NewGiayBaoCo_CacQuy()
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a GiayBaoCo_CacQuy");
            return DataPortal.Create<GiayBaoCo_CacQuy>();
        }

        public static GiayBaoCo_CacQuy GetGiayBaoCo_CacQuy(long maGiayBaoCo)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a GiayBaoCo_CacQuy");
            return DataPortal.Fetch<GiayBaoCo_CacQuy>(new Criteria(maGiayBaoCo));
        }

        public static void DeleteGiayBaoCo_CacQuy(long maGiayBaoCo)
        {
            if (!CanDeleteObject())
                throw new System.Security.SecurityException("User not authorized to remove a GiayBaoCo_CacQuy");
            DataPortal.Delete(new Criteria(maGiayBaoCo));
        }

        public override GiayBaoCo_CacQuy Save()
        {
            if (IsDeleted && !CanDeleteObject())
                throw new System.Security.SecurityException("User not authorized to remove a GiayBaoCo_CacQuy");
            else if (IsNew && !CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a GiayBaoCo_CacQuy");
            else if (!CanEditObject())
                throw new System.Security.SecurityException("User not authorized to update a GiayBaoCo_CacQuy");

            return base.Save();
        }

        #endregion //Factory Methods

        #region Child Factory Methods
        internal static GiayBaoCo_CacQuy NewGiayBaoCo_CacQuyChild()
        {
            GiayBaoCo_CacQuy child = new GiayBaoCo_CacQuy();
            child.ValidationRules.CheckRules();
            child.MarkAsChild();
            return child;
        }

        internal static GiayBaoCo_CacQuy GetGiayBaoCo_CacQuy(SafeDataReader dr)
        {
            GiayBaoCo_CacQuy child = new GiayBaoCo_CacQuy();
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
            public long MaGiayBaoCo;

            public Criteria(long maGiayBaoCo)
            {
                this.MaGiayBaoCo = maGiayBaoCo;
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
                cm.CommandText = "spd_SelecttblGiayBaoCo_CacQuy";

                cm.Parameters.AddWithValue("@MaGiayBaoCo", criteria.MaGiayBaoCo);

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
            DataPortal_Delete(new Criteria(_maGiayBaoCo));
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
                cm.CommandText = "spd_DeletetblGiayBaoCo_CacQuy";

                cm.Parameters.AddWithValue("@MaGiayBaoCo", criteria.MaGiayBaoCo);

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
            _maGiayBaoCo = dr.GetInt64("MaGiayBaoCo");
            _soChungTu = dr.GetString("SoChungTu");
            _ngayNhan = dr.GetDateTime("NgayNhan");
            _maDoiTac = dr.GetInt64("MaDoiTac");
            _tenDoiTac = dr.GetString("TenDoiTac");
            _taiKhoanNhan = dr.GetInt32("TaiKhoanNhan");
            _soTaiKhoan = dr.GetString("SoTaiKhoan");
            _lapBangKe = dr.GetInt32("LapBangKe");
            _soTien = dr.GetDecimal("SoTien");
            _tyGia = dr.GetDecimal("TyGia");
            _userId = dr.GetInt32("UserId");
            _loaiTien = dr.GetInt32("LoaiTien");
            _dienGiai = dr.GetString("DienGiai");
            _ghiChu = dr.GetString("GhiChu");
            _loaiGBC = dr.GetInt32("LoaiGBC");
            _loaiDeNghi = dr.GetInt32("LoaiDeNghi");
            _ngayHeThong = dr.GetDateTime("NgayHeThong");
            _hoanTat = dr.GetBoolean("HoanTat");
        }

        private void FetchChildren(SafeDataReader dr)
        {
        }
        #endregion //Data Access - Fetch

        #region Data Access - Insert
        internal void Insert(SqlTransaction tr, GiayBaoCo_CacQuyList parent)
        {
            if (!IsDirty) return;

            ExecuteInsert(tr, parent);
            MarkOld();

            //update child object(s)
            UpdateChildren(tr);
        }

        private void ExecuteInsert(SqlTransaction tr, GiayBaoCo_CacQuyList parent)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_InserttblGiayBaoCo_CacQuy";

                AddInsertParameters(cm, parent);

                cm.ExecuteNonQuery();

                _maGiayBaoCo = (long)cm.Parameters["@MaGiayBaoCo"].Value;
            }//using
        }

        private void AddInsertParameters(SqlCommand cm, GiayBaoCo_CacQuyList parent)
        {
            //TODO: if parent use identity key, fix fk member with value from parent
            if (_soChungTu.Length > 0)
                cm.Parameters.AddWithValue("@SoChungTu", _soChungTu);
            else
                cm.Parameters.AddWithValue("@SoChungTu", DBNull.Value);
            cm.Parameters.AddWithValue("@NgayNhan", _ngayNhan);
            if (_maDoiTac != 0)
                cm.Parameters.AddWithValue("@MaDoiTac", _maDoiTac);
            else
                cm.Parameters.AddWithValue("@MaDoiTac", DBNull.Value);
            if (_tenDoiTac.Length > 0)
				cm.Parameters.AddWithValue("@TenDoiTac", _tenDoiTac);
			else
				cm.Parameters.AddWithValue("@TenDoiTac", DBNull.Value);
			if (_taiKhoanNhan != 0)
				cm.Parameters.AddWithValue("@TaiKhoanNhan", _taiKhoanNhan);
			else
				cm.Parameters.AddWithValue("@TaiKhoanNhan", DBNull.Value);
			if (_soTaiKhoan.Length > 0)
				cm.Parameters.AddWithValue("@SoTaiKhoan", _soTaiKhoan);
			else
				cm.Parameters.AddWithValue("@SoTaiKhoan", DBNull.Value);
            if (_lapBangKe != 0)
                cm.Parameters.AddWithValue("@LapBangKe", _lapBangKe);
            else
                cm.Parameters.AddWithValue("@LapBangKe", DBNull.Value);
            if (_soTien != 0)
                cm.Parameters.AddWithValue("@SoTien", _soTien);
            else
                cm.Parameters.AddWithValue("@SoTien", DBNull.Value);
            if (_tyGia != 0)
                cm.Parameters.AddWithValue("@TyGia", _tyGia);
            else
                cm.Parameters.AddWithValue("@TyGia", DBNull.Value);
            cm.Parameters.AddWithValue("@UserId", Security.CurrentUser.Info.UserID);
            if (_loaiTien != 0)
                cm.Parameters.AddWithValue("@LoaiTien", _loaiTien);
            else
                cm.Parameters.AddWithValue("@LoaiTien", DBNull.Value);
            if (_dienGiai.Length > 0)
                cm.Parameters.AddWithValue("@DienGiai", _dienGiai);
            else
                cm.Parameters.AddWithValue("@DienGiai", DBNull.Value);
            if (_ghiChu.Length > 0)
                cm.Parameters.AddWithValue("@GhiChu", _ghiChu);
            else
                cm.Parameters.AddWithValue("@GhiChu", DBNull.Value);
            if (_loaiGBC != 0)
                cm.Parameters.AddWithValue("@LoaiGBC", _loaiGBC);
            else
                cm.Parameters.AddWithValue("@LoaiGBC", DBNull.Value);
            if (_loaiDeNghi != 0)
                cm.Parameters.AddWithValue("@LoaiDeNghi", _loaiDeNghi);
            else
                cm.Parameters.AddWithValue("@LoaiDeNghi", DBNull.Value);
            cm.Parameters.AddWithValue("@NgayHeThong", DateTime.Today);
            if (_hoanTat != false)
                cm.Parameters.AddWithValue("@HoanTat", _hoanTat);
            else
                cm.Parameters.AddWithValue("@HoanTat", DBNull.Value);
            cm.Parameters.AddWithValue("@MaGiayBaoCo", _maGiayBaoCo);
            cm.Parameters["@MaGiayBaoCo"].Direction = ParameterDirection.Output;
        }
        #endregion //Data Access - Insert

        #region Data Access - Update
        internal void Update(SqlTransaction tr, GiayBaoCo_CacQuyList parent)
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

        private void ExecuteUpdate(SqlTransaction tr, GiayBaoCo_CacQuyList parent)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_UpdatetblGiayBaoCo_CacQuy";

                AddUpdateParameters(cm, parent);

                cm.ExecuteNonQuery();

            }//using
        }

        private void AddUpdateParameters(SqlCommand cm, GiayBaoCo_CacQuyList parent)
        {
            cm.Parameters.AddWithValue("@MaGiayBaoCo", _maGiayBaoCo);
            if (_soChungTu.Length > 0)
                cm.Parameters.AddWithValue("@SoChungTu", _soChungTu);
            else
                cm.Parameters.AddWithValue("@SoChungTu", DBNull.Value);
            cm.Parameters.AddWithValue("@NgayNhan", _ngayNhan);
            if (_maDoiTac != 0)
                cm.Parameters.AddWithValue("@MaDoiTac", _maDoiTac);
            else
                cm.Parameters.AddWithValue("@MaDoiTac", DBNull.Value);
            if (_tenDoiTac.Length > 0)
                cm.Parameters.AddWithValue("@TenDoiTac", _tenDoiTac);
            else
                cm.Parameters.AddWithValue("@TenDoiTac", DBNull.Value);
            if (_taiKhoanNhan != 0)
                cm.Parameters.AddWithValue("@TaiKhoanNhan", _taiKhoanNhan);
            else
                cm.Parameters.AddWithValue("@TaiKhoanNhan", DBNull.Value);
            if (_soTaiKhoan.Length > 0)
                cm.Parameters.AddWithValue("@SoTaiKhoan", _soTaiKhoan);
            else
                cm.Parameters.AddWithValue("@SoTaiKhoan", DBNull.Value);
            if (_lapBangKe != 0)
                cm.Parameters.AddWithValue("@LapBangKe", _lapBangKe);
            else
                cm.Parameters.AddWithValue("@LapBangKe", DBNull.Value);
            if (_soTien != 0)
                cm.Parameters.AddWithValue("@SoTien", _soTien);
            else
                cm.Parameters.AddWithValue("@SoTien", DBNull.Value);
            if (_tyGia != 0)
                cm.Parameters.AddWithValue("@TyGia", _tyGia);
            else
                cm.Parameters.AddWithValue("@TyGia", DBNull.Value);
            cm.Parameters.AddWithValue("@UserId", Security.CurrentUser.Info.UserID);
            if (_loaiTien != 0)
                cm.Parameters.AddWithValue("@LoaiTien", _loaiTien);
            else
                cm.Parameters.AddWithValue("@LoaiTien", DBNull.Value);
            if (_dienGiai.Length > 0)
                cm.Parameters.AddWithValue("@DienGiai", _dienGiai);
            else
                cm.Parameters.AddWithValue("@DienGiai", DBNull.Value);
            if (_ghiChu.Length > 0)
                cm.Parameters.AddWithValue("@GhiChu", _ghiChu);
            else
                cm.Parameters.AddWithValue("@GhiChu", DBNull.Value);
            if (_loaiGBC != 0)
                cm.Parameters.AddWithValue("@LoaiGBC", _loaiGBC);
            else
                cm.Parameters.AddWithValue("@LoaiGBC", DBNull.Value);
            if (_loaiDeNghi != 0)
                cm.Parameters.AddWithValue("@LoaiDeNghi", _loaiDeNghi);
            else
                cm.Parameters.AddWithValue("@LoaiDeNghi", DBNull.Value);
            cm.Parameters.AddWithValue("@NgayHeThong", DateTime.Today);
            if (_hoanTat != false)
                cm.Parameters.AddWithValue("@HoanTat", _hoanTat);
            else
                cm.Parameters.AddWithValue("@HoanTat", DBNull.Value);
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

            ExecuteDelete(tr, new Criteria(_maGiayBaoCo));
            MarkNew();
        }
        #endregion //Data Access - Delete
        #endregion //Data Access
    }
}
