
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{
    [Serializable()]
    public class GiayRutTien : Csla.BusinessBase<GiayRutTien>
    {
        #region Business Properties and Methods

        //declare members
        private long _maGiayRutTien = 0;
        private string _so = string.Empty;
        private int _maCongTy = 0;
        private string _tenCongTy = string.Empty;
        private int _taiKhoanRut = 0;
        private long _nguoiLinhTien = 0;
        private string _tenNguoiLinh = string.Empty;
        private string _cmnd = string.Empty;
        private DateTime _ngayCap = DateTime.Now.Date;
        private string _noiCap = string.Empty;
        private decimal _soTienRut = 0;
        private string _noiDung = string.Empty;
        private string _ghiChu = string.Empty;
        private string _soTienBangChu = string.Empty;
        private string _dienGiai = string.Empty;
        private int _userId = 0;
        private DateTime _ngayLap = DateTime.Now.Date;
        private DateTime? _ngayXacNhan = null;

        //declare child member(s)
        private ChiTietGiayRutTienList _cTGiayRutTienList = ChiTietGiayRutTienList.NewChiTietGiayRutTienList();

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

        public string TenCongTy
        {
            get
            {
                CanReadProperty("TenCongTy", true);
                return _tenCongTy;
            }
            set
            {
                CanWriteProperty("TenCongTy", true);
                if (value == null) value = string.Empty;
                if (!_tenCongTy.Equals(value))
                {
                    _tenCongTy = value;
                    PropertyHasChanged("TenCongTy");
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
                    NhanVien nv = NhanVien.GetNhanVien(_nguoiLinhTien);
                    TenNguoiLinh = nv.TenNhanVien;
                    Cmnd = nv.Cmnd;
                    NgayCap = nv.NgayCap;
                    NoiCap = TinhThanh.GetTinhThanh(nv.MaNoiCap).TenTinhThanh;
                    PropertyHasChanged("NguoiLinhTien");
                }
            }
        }

        public string TenNguoiLinh
        {
            get
            {
                CanReadProperty("TenNguoiLinh", true);
                return _tenNguoiLinh;
            }
            set
            {
                CanWriteProperty("TenNguoiLinh", true);
                if (value == null) value = string.Empty;
                if (!_tenNguoiLinh.Equals(value))
                {
                    _tenNguoiLinh = value;
                    PropertyHasChanged("TenNguoiLinh");
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
                return _ngayCap;
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
                return _soTienRut;
            }
            set
            {
                CanWriteProperty("SoTien", true);
                if (!_soTienRut.Equals(value))
                {
                    _soTienRut = value;
                    _soTienBangChu = HamDungChung.DocTien(_soTienRut);
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

        public string SoTienBangChu
        {
            get
            {
                CanReadProperty("SoTienBangChu", true);
                return _soTienBangChu;
            }
            set
            {
                CanWriteProperty("SoTienBangChu", true);
                if (value == null) value = string.Empty;
                if (!_soTienBangChu.Equals(value))
                {
                    _soTienBangChu = value;
                    PropertyHasChanged("SoTienBangChu");
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

        public DateTime NgayLap
        {
            get
            {
                CanReadProperty("NgayLap", true);
                return _ngayLap;
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
                if (_ngayXacNhan == DateTime.MinValue)
                {
                    _ngayXacNhan = null;
                }
                return _ngayXacNhan;
            }
            set
            {
                CanWriteProperty("NgayXacNhan", true);
                if (!_ngayXacNhan.Equals(value))
                {
                    if (value == null)
                        _ngayXacNhan = null;
                    else if (value != DateTime.MinValue & value != DateTime.MaxValue & ((DateTime)value).Year != 1753)
                    {
                        _ngayXacNhan = value;
                        PropertyHasChanged("NgayXacNhan");
                    }
                    PropertyHasChanged("NgayXacNhan");
                }
            }
        }

        public ChiTietGiayRutTienList CTGiayRutTienList
        {
            get
            {
                CanReadProperty("CTGiayRutTienList", true);
                return _cTGiayRutTienList;
            }
        }

        public override bool IsValid
        {
            get { return base.IsValid && _cTGiayRutTienList.IsValid; }
        }

        public override bool IsDirty
        {
            get { return base.IsDirty || _cTGiayRutTienList.IsDirty; }
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
            // TenCongTy
            //
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("TenCongTy", 500));
            //
            // TenNguoiLinh
            //
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("TenNguoiLinh", 500));
            //
            // Cmnd
            //
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("Cmnd", 50));
            //
            // NoiCap
            //
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("NoiCap", 500));
            //
            // NoiDung
            //
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("NoiDung", 2000));
            //
            // GhiChu
            //
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("GhiChu", 500));
            //
            // SoTienBangChu
            //
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("SoTienBangChu", 500));
            //
            // DienGiai
            //
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("DienGiai", 2000));
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
            //TODO: Define authorization rules in GiayRutTien
            //AuthorizationRules.AllowRead("CTGiayRutTienList", "GiayRutTienReadGroup");
            //AuthorizationRules.AllowRead("MaGiayRutTien", "GiayRutTienReadGroup");
            //AuthorizationRules.AllowRead("So", "GiayRutTienReadGroup");
            //AuthorizationRules.AllowRead("MaCongTy", "GiayRutTienReadGroup");
            //AuthorizationRules.AllowRead("TenCongTy", "GiayRutTienReadGroup");
            //AuthorizationRules.AllowRead("TaiKhoanRut", "GiayRutTienReadGroup");
            //AuthorizationRules.AllowRead("NguoiLinhTien", "GiayRutTienReadGroup");
            //AuthorizationRules.AllowRead("TenNguoiLinh", "GiayRutTienReadGroup");
            //AuthorizationRules.AllowRead("Cmnd", "GiayRutTienReadGroup");
            //AuthorizationRules.AllowRead("NgayCap", "GiayRutTienReadGroup");
            //AuthorizationRules.AllowRead("NgayCapString", "GiayRutTienReadGroup");
            //AuthorizationRules.AllowRead("NoiCap", "GiayRutTienReadGroup");
            //AuthorizationRules.AllowRead("SoTienRut", "GiayRutTienReadGroup");
            //AuthorizationRules.AllowRead("NoiDung", "GiayRutTienReadGroup");
            //AuthorizationRules.AllowRead("GhiChu", "GiayRutTienReadGroup");
            //AuthorizationRules.AllowRead("SoTienBangChu", "GiayRutTienReadGroup");
            //AuthorizationRules.AllowRead("DienGiai", "GiayRutTienReadGroup");
            //AuthorizationRules.AllowRead("UserId", "GiayRutTienReadGroup");
            //AuthorizationRules.AllowRead("NgayLap", "GiayRutTienReadGroup");
            //AuthorizationRules.AllowRead("NgayLapString", "GiayRutTienReadGroup");
            //AuthorizationRules.AllowRead("NgayXacNhan", "GiayRutTienReadGroup");
            //AuthorizationRules.AllowRead("NgayXacNhanString", "GiayRutTienReadGroup");

            //AuthorizationRules.AllowWrite("So", "GiayRutTienWriteGroup");
            //AuthorizationRules.AllowWrite("MaCongTy", "GiayRutTienWriteGroup");
            //AuthorizationRules.AllowWrite("TenCongTy", "GiayRutTienWriteGroup");
            //AuthorizationRules.AllowWrite("TaiKhoanRut", "GiayRutTienWriteGroup");
            //AuthorizationRules.AllowWrite("NguoiLinhTien", "GiayRutTienWriteGroup");
            //AuthorizationRules.AllowWrite("TenNguoiLinh", "GiayRutTienWriteGroup");
            //AuthorizationRules.AllowWrite("Cmnd", "GiayRutTienWriteGroup");
            //AuthorizationRules.AllowWrite("NgayCapString", "GiayRutTienWriteGroup");
            //AuthorizationRules.AllowWrite("NoiCap", "GiayRutTienWriteGroup");
            //AuthorizationRules.AllowWrite("SoTienRut", "GiayRutTienWriteGroup");
            //AuthorizationRules.AllowWrite("NoiDung", "GiayRutTienWriteGroup");
            //AuthorizationRules.AllowWrite("GhiChu", "GiayRutTienWriteGroup");
            //AuthorizationRules.AllowWrite("SoTienBangChu", "GiayRutTienWriteGroup");
            //AuthorizationRules.AllowWrite("DienGiai", "GiayRutTienWriteGroup");
            //AuthorizationRules.AllowWrite("UserId", "GiayRutTienWriteGroup");
            //AuthorizationRules.AllowWrite("NgayLapString", "GiayRutTienWriteGroup");
            //AuthorizationRules.AllowWrite("NgayXacNhanString", "GiayRutTienWriteGroup");
        }


        public static bool CanGetObject()
        {
            //TODO: Define CanGetObject permission in GiayRutTien
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("GiayRutTienViewGroup"))
            //	return true;
            //return false;
        }

        public static bool CanAddObject()
        {
            //TODO: Define CanAddObject permission in GiayRutTien
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("GiayRutTienAddGroup"))
            //	return true;
            //return false;
        }

        public static bool CanEditObject()
        {
            //TODO: Define CanEditObject permission in GiayRutTien
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("GiayRutTienEditGroup"))
            //	return true;
            //return false;
        }

        public static bool CanDeleteObject()
        {
            //TODO: Define CanDeleteObject permission in GiayRutTien
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("GiayRutTienDeleteGroup"))
            //	return true;
            //return false;
        }
        #endregion //Authorization Rules

        #region Factory Methods
        private GiayRutTien()
        { 
            /* require use of factory method */
            MarkAsChild();
        }

        public static GiayRutTien NewGiayRutTien()
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a GiayRutTien");
            return DataPortal.Create<GiayRutTien>();
        }

        public static GiayRutTien GetGiayRutTien(long maGiayRutTien)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a GiayRutTien");
            return DataPortal.Fetch<GiayRutTien>(new Criteria(maGiayRutTien));
        }

        public static void DeleteGiayRutTien(long maGiayRutTien)
        {
            if (!CanDeleteObject())
                throw new System.Security.SecurityException("User not authorized to remove a GiayRutTien");
            DataPortal.Delete(new Criteria(maGiayRutTien));
        }

        public override GiayRutTien Save()
        {
            if (IsDeleted && !CanDeleteObject())
                throw new System.Security.SecurityException("User not authorized to remove a GiayRutTien");
            else if (IsNew && !CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a GiayRutTien");
            else if (!CanEditObject())
                throw new System.Security.SecurityException("User not authorized to update a GiayRutTien");

            return base.Save();
        }

        #endregion //Factory Methods

        #region Child Factory Methods
        internal static GiayRutTien NewGiayRutTienChild()
        {
            GiayRutTien child = new GiayRutTien();
            child.ValidationRules.CheckRules();
            child.MarkAsChild();
            return child;
        }

        internal static GiayRutTien GetGiayRutTien(SafeDataReader dr)
        {
            GiayRutTien child = new GiayRutTien();
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
                cm.CommandText = "spd_SelecttblGiayRutTien";

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
                cm.CommandText = "spd_DeletetblGiayRutTien";

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
            _tenCongTy = dr.GetString("TenCongTy");
            _taiKhoanRut = dr.GetInt32("TaiKhoanRut");
            _nguoiLinhTien = dr.GetInt64("NguoiLinhTien");
            _tenNguoiLinh = dr.GetString("TenNguoiLinh");
            _cmnd = dr.GetString("CMND");
            _ngayCap = dr.GetDateTime("NgayCap");
            _noiCap = dr.GetString("NoiCap");
            _soTienRut = dr.GetDecimal("SoTienRut");
            _noiDung = dr.GetString("NoiDung");
            _ghiChu = dr.GetString("GhiChu");
            _soTienBangChu = dr.GetString("SoTienBangChu");
            _dienGiai = dr.GetString("DienGiai");
            _userId = dr.GetInt32("UserId");
            _ngayLap = dr.GetDateTime("NgayLap");
            NgayXacNhan = dr.GetDateTime("NgayXacNhan");
        }

        private void FetchChildren(SafeDataReader dr)
        {
            //dr.NextResult();
            _cTGiayRutTienList = ChiTietGiayRutTienList.GetChiTietGiayRutTienList(MaGiayRutTien);
        }
        #endregion //Data Access - Fetch

        #region Data Access - Insert
        internal void Insert(SqlTransaction tr, GiayRutTienList parent)
        {
            if (!IsDirty) return;

            ExecuteInsert(tr, parent);
            MarkOld();

            //update child object(s)
            UpdateChildren(tr);
        }

        private void ExecuteInsert(SqlTransaction tr, GiayRutTienList parent)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_InserttblGiayRutTien";

                AddInsertParameters(cm, parent);

                cm.ExecuteNonQuery();

                _maGiayRutTien = (long)cm.Parameters["@MaGiayRutTien"].Value;
            }//using
        }

        private void AddInsertParameters(SqlCommand cm, GiayRutTienList parent)
        {
            //TODO: if parent use identity key, fix fk member with value from parent
            if (_so.Length > 0)
                cm.Parameters.AddWithValue("@So", _so);
            else
                cm.Parameters.AddWithValue("@So", DBNull.Value);
            //Nếu như sau này cho phép nhân viên của công ty này lập giấy rút tiền cho Công Ty Khác thì sửa lại chỗ này (Thành 20/06/2012)
            cm.Parameters.AddWithValue("@MaCongTy", Security.CurrentUser.Info.MaCongTy);
            cm.Parameters.AddWithValue("@TenCongTy", CongTy.GetCongTy(Security.CurrentUser.Info.MaCongTy).TenCongTy);
            if (_taiKhoanRut != 0)
                cm.Parameters.AddWithValue("@TaiKhoanRut", _taiKhoanRut);
            else
                cm.Parameters.AddWithValue("@TaiKhoanRut", DBNull.Value);
            if (_nguoiLinhTien != 0)
                cm.Parameters.AddWithValue("@NguoiLinhTien", _nguoiLinhTien);
            else
                cm.Parameters.AddWithValue("@NguoiLinhTien", DBNull.Value);
            if (_tenNguoiLinh.Length > 0)
                cm.Parameters.AddWithValue("@TenNguoiLinh", _tenNguoiLinh);
            else
                cm.Parameters.AddWithValue("@TenNguoiLinh", DBNull.Value);
            if (_cmnd.Length > 0)
                cm.Parameters.AddWithValue("@CMND", _cmnd);
            else
                cm.Parameters.AddWithValue("@CMND", DBNull.Value);
            cm.Parameters.AddWithValue("@NgayCap", _ngayCap);
            if (_noiCap.Length > 0)
                cm.Parameters.AddWithValue("@NoiCap", _noiCap);
            else
                cm.Parameters.AddWithValue("@NoiCap", DBNull.Value);
            if (_soTienRut != 0)
                cm.Parameters.AddWithValue("@SoTienRut", _soTienRut);
            else
                cm.Parameters.AddWithValue("@SoTienRut", DBNull.Value);
            if (_noiDung.Length > 0)
                cm.Parameters.AddWithValue("@NoiDung", _noiDung);
            else
                cm.Parameters.AddWithValue("@NoiDung", DBNull.Value);
            if (_ghiChu.Length > 0)
                cm.Parameters.AddWithValue("@GhiChu", _ghiChu);
            else
                cm.Parameters.AddWithValue("@GhiChu", DBNull.Value);
            if (_soTienBangChu.Length > 0)
                cm.Parameters.AddWithValue("@SoTienBangChu", _soTienBangChu);
            else
                cm.Parameters.AddWithValue("@SoTienBangChu", DBNull.Value);
            if (_dienGiai.Length > 0)
                cm.Parameters.AddWithValue("@DienGiai", _dienGiai);
            else
                cm.Parameters.AddWithValue("@DienGiai", DBNull.Value);
            cm.Parameters.AddWithValue("@UserId", Security.CurrentUser.Info.UserID);
            cm.Parameters.AddWithValue("@NgayLap", _ngayLap);
            if (_ngayXacNhan != null)
                cm.Parameters.AddWithValue("@NgayXacNhan", _ngayXacNhan);
            else
                cm.Parameters.AddWithValue("@NgayXacNhan", DBNull.Value);
            cm.Parameters.AddWithValue("@MaGiayRutTien", _maGiayRutTien);
            cm.Parameters["@MaGiayRutTien"].Direction = ParameterDirection.Output;
        }
        #endregion //Data Access - Insert

        #region Data Access - Update
        internal void Update(SqlTransaction tr, GiayRutTienList parent)
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

        private void ExecuteUpdate(SqlTransaction tr, GiayRutTienList parent)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_UpdatetblGiayRutTien";

                AddUpdateParameters(cm, parent);

                cm.ExecuteNonQuery();

            }//using
        }

        private void AddUpdateParameters(SqlCommand cm, GiayRutTienList parent)
        {
            cm.Parameters.AddWithValue("@MaGiayRutTien", _maGiayRutTien);
            if (_so.Length > 0)
                cm.Parameters.AddWithValue("@So", _so);
            else
                cm.Parameters.AddWithValue("@So", DBNull.Value);
            //Nếu như sau này cho phép nhân viên của công ty này lập giấy rút tiền cho Công Ty Khác thì sửa lại chỗ này
            cm.Parameters.AddWithValue("@MaCongTy", Security.CurrentUser.Info.MaCongTy);
            cm.Parameters.AddWithValue("@TenCongTy", CongTy.GetCongTy(Security.CurrentUser.Info.MaCongTy).TenCongTy);

            if (_taiKhoanRut != 0)
                cm.Parameters.AddWithValue("@TaiKhoanRut", _taiKhoanRut);
            else
                cm.Parameters.AddWithValue("@TaiKhoanRut", DBNull.Value);
            if (_nguoiLinhTien != 0)
                cm.Parameters.AddWithValue("@NguoiLinhTien", _nguoiLinhTien);
            else
                cm.Parameters.AddWithValue("@NguoiLinhTien", DBNull.Value);
            if (_tenNguoiLinh.Length > 0)
                cm.Parameters.AddWithValue("@TenNguoiLinh", _tenNguoiLinh);
            else
                cm.Parameters.AddWithValue("@TenNguoiLinh", DBNull.Value);
            if (_cmnd.Length > 0)
                cm.Parameters.AddWithValue("@CMND", _cmnd);
            else
                cm.Parameters.AddWithValue("@CMND", DBNull.Value);
            cm.Parameters.AddWithValue("@NgayCap", _ngayCap);
            if (_noiCap.Length > 0)
                cm.Parameters.AddWithValue("@NoiCap", _noiCap);
            else
                cm.Parameters.AddWithValue("@NoiCap", DBNull.Value);
            if (_soTienRut != 0)
                cm.Parameters.AddWithValue("@SoTienRut", _soTienRut);
            else
                cm.Parameters.AddWithValue("@SoTienRut", DBNull.Value);
            if (_noiDung.Length > 0)
                cm.Parameters.AddWithValue("@NoiDung", _noiDung);
            else
                cm.Parameters.AddWithValue("@NoiDung", DBNull.Value);
            if (_ghiChu.Length > 0)
                cm.Parameters.AddWithValue("@GhiChu", _ghiChu);
            else
                cm.Parameters.AddWithValue("@GhiChu", DBNull.Value);
            if (_soTienBangChu.Length > 0)
                cm.Parameters.AddWithValue("@SoTienBangChu", _soTienBangChu);
            else
                cm.Parameters.AddWithValue("@SoTienBangChu", DBNull.Value);
            if (_dienGiai.Length > 0)
                cm.Parameters.AddWithValue("@DienGiai", _dienGiai);
            else
                cm.Parameters.AddWithValue("@DienGiai", DBNull.Value);
            cm.Parameters.AddWithValue("@UserId", Security.CurrentUser.Info.UserID);         
            cm.Parameters.AddWithValue("@NgayLap", _ngayLap.Date);
            if (_ngayXacNhan != null)
                cm.Parameters.AddWithValue("@NgayXacNhan", _ngayXacNhan);
            else
                cm.Parameters.AddWithValue("@NgayXacNhan", DBNull.Value);
        }

        private void UpdateChildren(SqlTransaction tr)
        {
            _cTGiayRutTienList.Update(tr, this);
        }
        #endregion //Data Access - Update

        #region Data Access - Delete
        internal void DeleteSelf(SqlTransaction tr)
        {
            if (!IsDirty) return;
            if (IsNew) return;

            _cTGiayRutTienList.Clear();
            _cTGiayRutTienList.Update(tr, this);
            ExecuteDelete(tr, new Criteria(_maGiayRutTien));
            MarkNew();
        }
        #endregion //Data Access - Delete
        #endregion //Data Access
    }
}
