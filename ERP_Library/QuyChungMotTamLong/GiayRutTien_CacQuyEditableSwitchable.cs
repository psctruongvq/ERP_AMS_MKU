
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{
    [Serializable()]
    public class GiayRutTien_CacQuy : Csla.BusinessBase<GiayRutTien_CacQuy>
    {
        #region Business Properties and Methods

        //declare members
        private long _maGiayRutTien = 0;
        private string _so = string.Empty;
        private int _maCongTy = 0;
        private int _taiKhoanRut = 0;
        private long _nguoiLinhTien = 0;
        private string _cmnd = string.Empty;
        private DateTime _ngayCap = DateTime.Today;
        private string _noiCap = string.Empty;
        private decimal _soTien = 0;
        private string _noiDung = string.Empty;
        private string _ghiChu = string.Empty;
        private int _userId = 0;
        private int _loaiDeNghi = 0;
        private DateTime _ngayLap = DateTime.Today;
        private DateTime? _ngayXacNhan = null;
        private DateTime _ngayHeThong = DateTime.Today;

        //declare child member(s)
        private ChiTiet_GiayRutTien_CacQuyList _cTGiayRutTien_CacQuyList = ChiTiet_GiayRutTien_CacQuyList.NewChiTiet_GiayRutTien_CacQuyList();

        [System.ComponentModel.DataObjectField(true, true)]
        public long MaGiayRutTien
        {
            get
            {
                CanReadProperty("MaGiayRutTien", true);
                return _maGiayRutTien;
            }
        }

        public string So
        {
            get
            {
                CanReadProperty("So", true);
                return _so;
            }
            set
            {
                CanWriteProperty("So", true);
                if (value == null) value = string.Empty;
                if (!_so.Equals(value))
                {
                    _so = value;
                    PropertyHasChanged("So");
                }
            }
        }

        public int MaCongTy
        {
            get
            {
                CanReadProperty("MaCongTy", true);
                return _maCongTy;
            }
            set
            {
                CanWriteProperty("MaCongTy", true);
                if (!_maCongTy.Equals(value))
                {
                    _maCongTy = value;
                    PropertyHasChanged("MaCongTy");
                }
            }
        }

        public int TaiKhoanRut
        {
            get
            {
                CanReadProperty("TaiKhoanRut", true);
                return _taiKhoanRut;
            }
            set
            {
                CanWriteProperty("TaiKhoanRut", true);
                if (!_taiKhoanRut.Equals(value))
                {
                    _taiKhoanRut = value;
                    PropertyHasChanged("TaiKhoanRut");
                }
            }
        }

        public long NguoiLinhTien
        {
            get
            {
                CanReadProperty("NguoiLinhTien", true);
                return _nguoiLinhTien;
            }
            set
            {
                CanWriteProperty("NguoiLinhTien", true);
                if (!_nguoiLinhTien.Equals(value))
                {
                    _nguoiLinhTien = value;
                    PropertyHasChanged("NguoiLinhTien");
                }
            }
        }

        public string Cmnd
        {
            get
            {
                CanReadProperty("Cmnd", true);
                return _cmnd;
            }
            set
            {
                CanWriteProperty("Cmnd", true);
                if (value == null) value = string.Empty;
                if (!_cmnd.Equals(value))
                {
                    _cmnd = value;
                    PropertyHasChanged("Cmnd");
                }
            }
        }

        public DateTime NgayCap
        {
            get
            {
                CanReadProperty("NgayCap", true);
                return _ngayCap.Date;
            }
            set
            {
                CanWriteProperty("NgayCap", true);
                if (!_ngayCap.Equals(value))
                {
                    _ngayCap = value;
                    PropertyHasChanged("NgayCap");
                }
            }
        }

        public string NoiCap
        {
            get
            {
                CanReadProperty("NoiCap", true);
                return _noiCap;
            }
            set
            {
                CanWriteProperty("NoiCap", true);
                if (value == null) value = string.Empty;
                if (!_noiCap.Equals(value))
                {
                    _noiCap = value;
                    PropertyHasChanged("NoiCap");
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

        public string NoiDung
        {
            get
            {
                CanReadProperty("NoiDung", true);
                return _noiDung;
            }
            set
            {
                CanWriteProperty("NoiDung", true);
                if (value == null) value = string.Empty;
                if (!_noiDung.Equals(value))
                {
                    _noiDung = value;
                    PropertyHasChanged("NoiDung");
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

        public DateTime NgayLap
        {
            get
            {
                CanReadProperty("NgayLap", true);
                return _ngayLap.Date;
            }
            set
            {
                CanWriteProperty("NgayLap", true);
                if (!_ngayLap.Equals(value))
                {
                    _ngayLap = value;
                    PropertyHasChanged("NgayLap");
                }
            }
        }

        public DateTime? NgayXacNhan
        {
            get
            {
                CanReadProperty("NgayXacNhan", true);
                return _ngayXacNhan;
            }
            set
            {
                CanWriteProperty("NgayXacNhan", true);
                if (!_ngayXacNhan.Equals(value))
                {
                    _ngayXacNhan = value;
                    PropertyHasChanged("NgayXacNhan");
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

        public ChiTiet_GiayRutTien_CacQuyList CTGiayRutTien_CacQuyList
        {
            get
            {
                CanReadProperty("CTGiayRutTien_CacQuyList", true);
                return _cTGiayRutTien_CacQuyList;
            }
        }

        public override bool IsValid
        {
            get { return base.IsValid && _cTGiayRutTien_CacQuyList.IsValid; }
        }

        public override bool IsDirty
        {
            get { return base.IsDirty || _cTGiayRutTien_CacQuyList.IsDirty; }
        }

        protected override object GetIdValue()
        {
            return _maGiayRutTien;
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
            // So
            //
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("So", 50));
            //
            // Cmnd
            //
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("Cmnd", 50));
            //
            // NoiCap
            //
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("NoiCap", 200));
            //
            // NoiDung
            //
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("NoiDung", 4000));
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
            //TODO: Define authorization rules in GiayRutTien_CacQuy
            //AuthorizationRules.AllowRead("CTGiayRutTien_CacQuy", "GiayRutTien_CacQuyReadGroup");
            //AuthorizationRules.AllowRead("MaGiayRutTien", "GiayRutTien_CacQuyReadGroup");
            //AuthorizationRules.AllowRead("So", "GiayRutTien_CacQuyReadGroup");
            //AuthorizationRules.AllowRead("MaCongTy", "GiayRutTien_CacQuyReadGroup");
            //AuthorizationRules.AllowRead("TaiKhoanRut", "GiayRutTien_CacQuyReadGroup");
            //AuthorizationRules.AllowRead("NguoiLinhTien", "GiayRutTien_CacQuyReadGroup");
            //AuthorizationRules.AllowRead("Cmnd", "GiayRutTien_CacQuyReadGroup");
            //AuthorizationRules.AllowRead("NgayCap", "GiayRutTien_CacQuyReadGroup");
            //AuthorizationRules.AllowRead("NgayCapString", "GiayRutTien_CacQuyReadGroup");
            //AuthorizationRules.AllowRead("NoiCap", "GiayRutTien_CacQuyReadGroup");
            //AuthorizationRules.AllowRead("SoTien", "GiayRutTien_CacQuyReadGroup");
            //AuthorizationRules.AllowRead("NoiDung", "GiayRutTien_CacQuyReadGroup");
            //AuthorizationRules.AllowRead("GhiChu", "GiayRutTien_CacQuyReadGroup");
            //AuthorizationRules.AllowRead("UserId", "GiayRutTien_CacQuyReadGroup");
            //AuthorizationRules.AllowRead("NgayLap", "GiayRutTien_CacQuyReadGroup");
            //AuthorizationRules.AllowRead("NgayLapString", "GiayRutTien_CacQuyReadGroup");
            //AuthorizationRules.AllowRead("NgayXacNhan", "GiayRutTien_CacQuyReadGroup");
            //AuthorizationRules.AllowRead("NgayXacNhanString", "GiayRutTien_CacQuyReadGroup");
            //AuthorizationRules.AllowRead("NgayHeThong", "GiayRutTien_CacQuyReadGroup");
            //AuthorizationRules.AllowRead("NgayHeThongString", "GiayRutTien_CacQuyReadGroup");

            //AuthorizationRules.AllowWrite("So", "GiayRutTien_CacQuyWriteGroup");
            //AuthorizationRules.AllowWrite("MaCongTy", "GiayRutTien_CacQuyWriteGroup");
            //AuthorizationRules.AllowWrite("TaiKhoanRut", "GiayRutTien_CacQuyWriteGroup");
            //AuthorizationRules.AllowWrite("NguoiLinhTien", "GiayRutTien_CacQuyWriteGroup");
            //AuthorizationRules.AllowWrite("Cmnd", "GiayRutTien_CacQuyWriteGroup");
            //AuthorizationRules.AllowWrite("NgayCapString", "GiayRutTien_CacQuyWriteGroup");
            //AuthorizationRules.AllowWrite("NoiCap", "GiayRutTien_CacQuyWriteGroup");
            //AuthorizationRules.AllowWrite("SoTien", "GiayRutTien_CacQuyWriteGroup");
            //AuthorizationRules.AllowWrite("NoiDung", "GiayRutTien_CacQuyWriteGroup");
            //AuthorizationRules.AllowWrite("GhiChu", "GiayRutTien_CacQuyWriteGroup");
            //AuthorizationRules.AllowWrite("UserId", "GiayRutTien_CacQuyWriteGroup");
            //AuthorizationRules.AllowWrite("NgayLapString", "GiayRutTien_CacQuyWriteGroup");
            //AuthorizationRules.AllowWrite("NgayXacNhanString", "GiayRutTien_CacQuyWriteGroup");
            //AuthorizationRules.AllowWrite("NgayHeThongString", "GiayRutTien_CacQuyWriteGroup");
        }


        public static bool CanGetObject()
        {
            //TODO: Define CanGetObject permission in GiayRutTien_CacQuy
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("GiayRutTien_CacQuyViewGroup"))
            //	return true;
            //return false;
        }

        public static bool CanAddObject()
        {
            //TODO: Define CanAddObject permission in GiayRutTien_CacQuy
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("GiayRutTien_CacQuyAddGroup"))
            //	return true;
            //return false;
        }

        public static bool CanEditObject()
        {
            //TODO: Define CanEditObject permission in GiayRutTien_CacQuy
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("GiayRutTien_CacQuyEditGroup"))
            //	return true;
            //return false;
        }

        public static bool CanDeleteObject()
        {
            //TODO: Define CanDeleteObject permission in GiayRutTien_CacQuy
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("GiayRutTien_CacQuyDeleteGroup"))
            //	return true;
            //return false;
        }
        #endregion //Authorization Rules

        #region Factory Methods
        private GiayRutTien_CacQuy()
        { 
            /* require use of factory method */
            MarkAsChild();
        }

        public static GiayRutTien_CacQuy NewGiayRutTien_CacQuy()
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a GiayRutTien_CacQuy");
            return DataPortal.Create<GiayRutTien_CacQuy>();
        }

        public static GiayRutTien_CacQuy GetGiayRutTien_CacQuy(long maGiayRutTien)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a GiayRutTien_CacQuy");
            return DataPortal.Fetch<GiayRutTien_CacQuy>(new Criteria(maGiayRutTien));
        }

        public static void DeleteGiayRutTien_CacQuy(long maGiayRutTien)
        {
            if (!CanDeleteObject())
                throw new System.Security.SecurityException("User not authorized to remove a GiayRutTien_CacQuy");
            DataPortal.Delete(new Criteria(maGiayRutTien));
        }

        public override GiayRutTien_CacQuy Save()
        {
            if (IsDeleted && !CanDeleteObject())
                throw new System.Security.SecurityException("User not authorized to remove a GiayRutTien_CacQuy");
            else if (IsNew && !CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a GiayRutTien_CacQuy");
            else if (!CanEditObject())
                throw new System.Security.SecurityException("User not authorized to update a GiayRutTien_CacQuy");

            return base.Save();
        }

        #endregion //Factory Methods

        #region Child Factory Methods
        internal static GiayRutTien_CacQuy NewGiayRutTien_CacQuyChild()
        {
            GiayRutTien_CacQuy child = new GiayRutTien_CacQuy();
            child.ValidationRules.CheckRules();
            child.MarkAsChild();
            return child;
        }

        internal static GiayRutTien_CacQuy GetGiayRutTien_CacQuy(SafeDataReader dr)
        {
            GiayRutTien_CacQuy child = new GiayRutTien_CacQuy();
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
            public long MaGiayRutTien;

            public Criteria(long maGiayRutTien)
            {
                this.MaGiayRutTien = maGiayRutTien;
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
                cm.CommandText = "spd_SelecttblGiayRutTien_CacQuy";

                cm.Parameters.AddWithValue("@MaGiayRutTien", criteria.MaGiayRutTien);

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
            DataPortal_Delete(new Criteria(_maGiayRutTien));
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
                cm.CommandText = "spd_DeletetblGiayRutTien_CacQuy";

                cm.Parameters.AddWithValue("@MaGiayRutTien", criteria.MaGiayRutTien);

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
            _maGiayRutTien = dr.GetInt64("MaGiayRutTien");
            _so = dr.GetString("So");
            _maCongTy = dr.GetInt32("MaCongTy");
            _taiKhoanRut = dr.GetInt32("TaiKhoanRut");
            _nguoiLinhTien = dr.GetInt64("NguoiLinhTien");
            _cmnd = dr.GetString("CMND");
            _ngayCap = dr.GetDateTime("NgayCap");
            _noiCap = dr.GetString("NoiCap");
            _soTien = dr.GetDecimal("SoTien");
            _noiDung = dr.GetString("NoiDung");
            _ghiChu = dr.GetString("GhiChu");
            _userId = dr.GetInt32("UserId");
            _ngayLap = dr.GetDateTime("NgayLap");
            _ngayXacNhan = dr.GetDateTime("NgayXacNhan");
            _ngayHeThong = dr.GetDateTime("NgayHeThong");
            if (_ngayXacNhan == DateTime.MinValue)
                _ngayXacNhan = null;
        }

        private void FetchChildren(SafeDataReader dr)
        {
            _cTGiayRutTien_CacQuyList = ChiTiet_GiayRutTien_CacQuyList.GetChiTiet_GiayRutTien_CacQuyList(_maGiayRutTien);
        }
        #endregion //Data Access - Fetch

        #region Data Access - Insert
        internal void Insert(SqlTransaction tr, GiayRutTien_CacQuyList parent)
        {
            if (!IsDirty) return;

            ExecuteInsert(tr, parent);
            MarkOld();

            //update child object(s)
            UpdateChildren(tr);
        }

        private void ExecuteInsert(SqlTransaction tr, GiayRutTien_CacQuyList parent)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_InserttblGiayRutTien_CacQuy";

                AddInsertParameters(cm, parent);

                cm.ExecuteNonQuery();

                _maGiayRutTien = (long)cm.Parameters["@MaGiayRutTien"].Value;
            }//using
        }

        private void AddInsertParameters(SqlCommand cm, GiayRutTien_CacQuyList parent)
        {
            //TODO: if parent use identity key, fix fk member with value from parent
            if (_so.Length > 0)
                cm.Parameters.AddWithValue("@So", _so);
            else
                cm.Parameters.AddWithValue("@So", DBNull.Value);
            if (_maCongTy != 0)
                cm.Parameters.AddWithValue("@MaCongTy", _maCongTy);
            else
                cm.Parameters.AddWithValue("@MaCongTy", DBNull.Value);
            cm.Parameters.AddWithValue("@TaiKhoanRut", _taiKhoanRut);
            if (_nguoiLinhTien != 0)
                cm.Parameters.AddWithValue("@NguoiLinhTien", _nguoiLinhTien);
            else
                cm.Parameters.AddWithValue("@NguoiLinhTien", DBNull.Value);
            if (_cmnd.Length > 0)
                cm.Parameters.AddWithValue("@CMND", _cmnd);
            else
                cm.Parameters.AddWithValue("@CMND", DBNull.Value);
            cm.Parameters.AddWithValue("@NgayCap", _ngayCap);
            if (_noiCap.Length > 0)
                cm.Parameters.AddWithValue("@NoiCap", _noiCap);
            else
                cm.Parameters.AddWithValue("@NoiCap", DBNull.Value);
            if (_soTien != 0)
                cm.Parameters.AddWithValue("@SoTien", _soTien);
            else
                cm.Parameters.AddWithValue("@SoTien", DBNull.Value);
            if (_noiDung.Length > 0)
                cm.Parameters.AddWithValue("@NoiDung", _noiDung);
            else
                cm.Parameters.AddWithValue("@NoiDung", DBNull.Value);
            if (_ghiChu.Length > 0)
                cm.Parameters.AddWithValue("@GhiChu", _ghiChu);
            else
                cm.Parameters.AddWithValue("@GhiChu", DBNull.Value);
            cm.Parameters.AddWithValue("@UserId", Security.CurrentUser.Info.UserID);
            cm.Parameters.AddWithValue("@NgayLap", _ngayLap);
            if (_ngayXacNhan != null && _ngayXacNhan != DateTime.MinValue)
                cm.Parameters.AddWithValue("@NgayXacNhan", _ngayXacNhan);
            else
                cm.Parameters.AddWithValue("@NgayXacNhan", DBNull.Value);
            cm.Parameters.AddWithValue("@NgayHeThong", DateTime.Today);
            cm.Parameters.AddWithValue("@LoaiDeNghi", _loaiDeNghi);
            cm.Parameters.AddWithValue("@MaGiayRutTien", _maGiayRutTien);
            cm.Parameters["@MaGiayRutTien"].Direction = ParameterDirection.Output;
        }
        #endregion //Data Access - Insert

        #region Data Access - Update
        internal void Update(SqlTransaction tr, GiayRutTien_CacQuyList parent)
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

        private void ExecuteUpdate(SqlTransaction tr, GiayRutTien_CacQuyList parent)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_UpdatetblGiayRutTien_CacQuy";

                AddUpdateParameters(cm, parent);

                cm.ExecuteNonQuery();

            }//using
        }

        private void AddUpdateParameters(SqlCommand cm, GiayRutTien_CacQuyList parent)
        {
            cm.Parameters.AddWithValue("@MaGiayRutTien", _maGiayRutTien);
            if (_so.Length > 0)
                cm.Parameters.AddWithValue("@So", _so);
            else
                cm.Parameters.AddWithValue("@So", DBNull.Value);
            if (_maCongTy != 0)
                cm.Parameters.AddWithValue("@MaCongTy", _maCongTy);
            else
                cm.Parameters.AddWithValue("@MaCongTy", DBNull.Value);
            cm.Parameters.AddWithValue("@TaiKhoanRut", _taiKhoanRut);
            if (_nguoiLinhTien != 0)
                cm.Parameters.AddWithValue("@NguoiLinhTien", _nguoiLinhTien);
            else
                cm.Parameters.AddWithValue("@NguoiLinhTien", DBNull.Value);
            if (_cmnd.Length > 0)
                cm.Parameters.AddWithValue("@CMND", _cmnd);
            else
                cm.Parameters.AddWithValue("@CMND", DBNull.Value);
            cm.Parameters.AddWithValue("@NgayCap", _ngayCap);
            if (_noiCap.Length > 0)
                cm.Parameters.AddWithValue("@NoiCap", _noiCap);
            else
                cm.Parameters.AddWithValue("@NoiCap", DBNull.Value);
            if (_soTien != 0)
                cm.Parameters.AddWithValue("@SoTien", _soTien);
            else
                cm.Parameters.AddWithValue("@SoTien", DBNull.Value);
            if (_noiDung.Length > 0)
                cm.Parameters.AddWithValue("@NoiDung", _noiDung);
            else
                cm.Parameters.AddWithValue("@NoiDung", DBNull.Value);
            if (_ghiChu.Length > 0)
                cm.Parameters.AddWithValue("@GhiChu", _ghiChu);
            else
                cm.Parameters.AddWithValue("@GhiChu", DBNull.Value);
            cm.Parameters.AddWithValue("@UserId", Security.CurrentUser.Info.UserID);
            cm.Parameters.AddWithValue("@NgayLap", _ngayLap);
            if (_ngayXacNhan != null && _ngayXacNhan != DateTime.MinValue)
                cm.Parameters.AddWithValue("@NgayXacNhan", _ngayXacNhan);
            else
                cm.Parameters.AddWithValue("@NgayXacNhan", DBNull.Value);

            cm.Parameters.AddWithValue("@NgayHeThong", DateTime.Today);
            cm.Parameters.AddWithValue("@LoaiDeNghi", _loaiDeNghi);
        }

        private void UpdateChildren(SqlTransaction tr)
        {
            _cTGiayRutTien_CacQuyList.Update(tr, this);
        }
        #endregion //Data Access - Update

        #region Data Access - Delete
        internal void DeleteSelf(SqlTransaction tr)
        {
            if (!IsDirty) return;
            if (IsNew) return;

            _cTGiayRutTien_CacQuyList.Clear();
            _cTGiayRutTien_CacQuyList.Update(tr, this);

            ExecuteDelete(tr, new Criteria(_maGiayRutTien));
            MarkNew();
        }
        #endregion //Data Access - Delete
        #endregion //Data Access
    }
}
