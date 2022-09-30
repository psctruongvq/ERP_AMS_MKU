
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{
    [Serializable()]
    public class UyNhiemChi_CacQuy : Csla.BusinessBase<UyNhiemChi_CacQuy>
    {
        #region Business Properties and Methods

        //declare members
        private long _maUyNhiemChi = 0;
        private string _so = string.Empty;
        private DateTime _ngay = DateTime.Today;
        private string _dienGiai = string.Empty;
        private decimal _soTien = 0;
        private DateTime _ngayHeThong = DateTime.Today;
        private DateTime? _ngayXacNhan = null;
        private int _loaiDeNghi = 0;
        private int _maNganHang = 0;
        private int _userID = 0;
        private bool _hoanTat = false;
        private string _ghiChu = string.Empty;
        private int _soChungTu = 0;
        private string _tenDoiTac = string.Empty;
        private string _soTaiKhoan = string.Empty;
        private string _soTaiKhoanChuyen = string.Empty;
        private string _tenNganHang = string.Empty;

        //declare child member(s)
        private DeNghi_UyNhiemChi_CacQuyList _deNghi_UNC_CacQuyList = DeNghi_UyNhiemChi_CacQuyList.NewDeNghi_UyNhiemChi_CacQuyList();

        [System.ComponentModel.DataObjectField(true, true)]
        public long MaUyNhiemChi
        {
            get
            {
                CanReadProperty("MaUyNhiemChi", true);
                return _maUyNhiemChi;
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

        public DateTime Ngay
        {
            get
            {
                CanReadProperty("Ngay", true);
                return _ngay.Date;
            }
            set
            {
                CanWriteProperty("Ngay", true);
                if (!_ngay.Equals(value))
                {
                    _ngay = value;
                    PropertyHasChanged("Ngay");
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

        public int MaNganHang
        {
            get
            {
                CanReadProperty("MaNganHang", true);
                return _maNganHang;
            }
            set
            {
                CanWriteProperty("MaNganHang", true);
                if (!_maNganHang.Equals(value))
                {
                    _maNganHang = value;
                    PropertyHasChanged("MaNganHang");
                }
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

        public int SoChungTu
        {
            get
            {
                CanReadProperty("SoChungTu", true);
                return _soChungTu;
            }
            set
            {
                CanWriteProperty("SoChungTu", true);
                if (!_soChungTu.Equals(value))
                {
                    _soChungTu = value;
                    PropertyHasChanged("SoChungTu");
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

        public string SoTaiKhoanChuyen
        {
            get
            {
                CanReadProperty("SoTaiKhoanChuyen", true);
                return _soTaiKhoanChuyen;
            }
            set
            {
                CanWriteProperty("SoTaiKhoanChuyen", true);
                if (value == null) value = string.Empty;
                if (!_soTaiKhoanChuyen.Equals(value))
                {
                    _soTaiKhoanChuyen = value;
                    PropertyHasChanged("SoTaiKhoanChuyen");
                }
            }
        }

        public string TenNganHang
        {
            get
            {
                CanReadProperty("TenNganHang", true);
                return _tenNganHang;
            }
            set
            {
                CanWriteProperty("TenNganHang", true);
                if (value == null) value = string.Empty;
                if (!_tenNganHang.Equals(value))
                {
                    _tenNganHang = value;
                    PropertyHasChanged("TenNganHang");
                }
            }
        }

        public DeNghi_UyNhiemChi_CacQuyList DeNghi_UNC_CacQuyList
        {
            get
            {
                CanReadProperty("DeNghi_UNC_CacQuyList", true);
                return _deNghi_UNC_CacQuyList;
            }
        }

        public override bool IsValid
        {
            get { return base.IsValid && _deNghi_UNC_CacQuyList.IsValid; }
        }

        public override bool IsDirty
        {
            get { return base.IsDirty || _deNghi_UNC_CacQuyList.IsDirty; }
        }

        protected override object GetIdValue()
        {
            return _maUyNhiemChi;
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
            // DienGiai
            //
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("DienGiai", 4000));
            //
            // GhiChu
            //
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("GhiChu", 2000));
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
            //TODO: Define authorization rules in UyNhiemChi_CacQuy
            //AuthorizationRules.AllowRead("DeNghi_UNC_CacQuyList", "UyNhiemChi_CacQuyReadGroup");
            //AuthorizationRules.AllowRead("MaUyNhiemChi", "UyNhiemChi_CacQuyReadGroup");
            //AuthorizationRules.AllowRead("So", "UyNhiemChi_CacQuyReadGroup");
            //AuthorizationRules.AllowRead("Ngay", "UyNhiemChi_CacQuyReadGroup");
            //AuthorizationRules.AllowRead("NgayString", "UyNhiemChi_CacQuyReadGroup");
            //AuthorizationRules.AllowRead("DienGiai", "UyNhiemChi_CacQuyReadGroup");
            //AuthorizationRules.AllowRead("SoTien", "UyNhiemChi_CacQuyReadGroup");
            //AuthorizationRules.AllowRead("NgayHeThong", "UyNhiemChi_CacQuyReadGroup");
            //AuthorizationRules.AllowRead("NgayHeThongString", "UyNhiemChi_CacQuyReadGroup");
            //AuthorizationRules.AllowRead("NgayXacNhan", "UyNhiemChi_CacQuyReadGroup");
            //AuthorizationRules.AllowRead("NgayXacNhanString", "UyNhiemChi_CacQuyReadGroup");
            //AuthorizationRules.AllowRead("LoaiDeNghi", "UyNhiemChi_CacQuyReadGroup");
            //AuthorizationRules.AllowRead("MaNganHang", "UyNhiemChi_CacQuyReadGroup");
            //AuthorizationRules.AllowRead("UserID", "UyNhiemChi_CacQuyReadGroup");
            //AuthorizationRules.AllowRead("HoanTat", "UyNhiemChi_CacQuyReadGroup");
            //AuthorizationRules.AllowRead("GhiChu", "UyNhiemChi_CacQuyReadGroup");
            //AuthorizationRules.AllowRead("SoChungTu", "UyNhiemChi_CacQuyReadGroup");

            //AuthorizationRules.AllowWrite("So", "UyNhiemChi_CacQuyWriteGroup");
            //AuthorizationRules.AllowWrite("NgayString", "UyNhiemChi_CacQuyWriteGroup");
            //AuthorizationRules.AllowWrite("DienGiai", "UyNhiemChi_CacQuyWriteGroup");
            //AuthorizationRules.AllowWrite("SoTien", "UyNhiemChi_CacQuyWriteGroup");
            //AuthorizationRules.AllowWrite("NgayHeThongString", "UyNhiemChi_CacQuyWriteGroup");
            //AuthorizationRules.AllowWrite("NgayXacNhanString", "UyNhiemChi_CacQuyWriteGroup");
            //AuthorizationRules.AllowWrite("LoaiDeNghi", "UyNhiemChi_CacQuyWriteGroup");
            //AuthorizationRules.AllowWrite("MaNganHang", "UyNhiemChi_CacQuyWriteGroup");
            //AuthorizationRules.AllowWrite("UserID", "UyNhiemChi_CacQuyWriteGroup");
            //AuthorizationRules.AllowWrite("HoanTat", "UyNhiemChi_CacQuyWriteGroup");
            //AuthorizationRules.AllowWrite("GhiChu", "UyNhiemChi_CacQuyWriteGroup");
            //AuthorizationRules.AllowWrite("SoChungTu", "UyNhiemChi_CacQuyWriteGroup");
        }


        public static bool CanGetObject()
        {
            //TODO: Define CanGetObject permission in UyNhiemChi_CacQuy
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("UyNhiemChi_CacQuyViewGroup"))
            //	return true;
            //return false;
        }

        public static bool CanAddObject()
        {
            //TODO: Define CanAddObject permission in UyNhiemChi_CacQuy
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("UyNhiemChi_CacQuyAddGroup"))
            //	return true;
            //return false;
        }

        public static bool CanEditObject()
        {
            //TODO: Define CanEditObject permission in UyNhiemChi_CacQuy
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("UyNhiemChi_CacQuyEditGroup"))
            //	return true;
            //return false;
        }

        public static bool CanDeleteObject()
        {
            //TODO: Define CanDeleteObject permission in UyNhiemChi_CacQuy
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("UyNhiemChi_CacQuyDeleteGroup"))
            //	return true;
            //return false;
        }
        #endregion //Authorization Rules

        #region Factory Methods
        private UyNhiemChi_CacQuy()
        { 
            /* require use of factory method */
            MarkAsChild();
        }

        public static UyNhiemChi_CacQuy NewUyNhiemChi_CacQuy()
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a UyNhiemChi_CacQuy");
            return DataPortal.Create<UyNhiemChi_CacQuy>();
        }

        public static UyNhiemChi_CacQuy GetUyNhiemChi_CacQuy(long maUyNhiemChi)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a UyNhiemChi_CacQuy");
            return DataPortal.Fetch<UyNhiemChi_CacQuy>(new Criteria(maUyNhiemChi));
        }

        public static void DeleteUyNhiemChi_CacQuy(long maUyNhiemChi)
        {
            if (!CanDeleteObject())
                throw new System.Security.SecurityException("User not authorized to remove a UyNhiemChi_CacQuy");
            DataPortal.Delete(new Criteria(maUyNhiemChi));
        }

        public override UyNhiemChi_CacQuy Save()
        {
            if (IsDeleted && !CanDeleteObject())
                throw new System.Security.SecurityException("User not authorized to remove a UyNhiemChi_CacQuy");
            else if (IsNew && !CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a UyNhiemChi_CacQuy");
            else if (!CanEditObject())
                throw new System.Security.SecurityException("User not authorized to update a UyNhiemChi_CacQuy");

            return base.Save();
        }

        #endregion //Factory Methods

        #region Child Factory Methods
        internal static UyNhiemChi_CacQuy NewUyNhiemChi_CacQuyChild()
        {
            UyNhiemChi_CacQuy child = new UyNhiemChi_CacQuy();
            child.ValidationRules.CheckRules();
            child.MarkAsChild();
            return child;
        }

        internal static UyNhiemChi_CacQuy GetUyNhiemChi_CacQuy(SafeDataReader dr)
        {
            UyNhiemChi_CacQuy child = new UyNhiemChi_CacQuy();
            child.MarkAsChild();
            child.Fetch(dr);
            return child;
        }

        internal static UyNhiemChi_CacQuy GetUyNhiemChi_CacQuy_New(SafeDataReader dr)
        {
            UyNhiemChi_CacQuy child = new UyNhiemChi_CacQuy();
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
            public long MaUyNhiemChi;

            public Criteria(long maUyNhiemChi)
            {
                this.MaUyNhiemChi = maUyNhiemChi;
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
                cm.CommandText = "spd_SelecttblUyNhiemChi_CacQuy";

                cm.Parameters.AddWithValue("@MaUyNhiemChi", criteria.MaUyNhiemChi);

                using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                {
                    if (dr.Read())
                    {
                        FetchObject(dr);
                        ValidationRules.CheckRules();

                        //load child object(s)
                        FetchChildren();
                    }
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
            DataPortal_Delete(new Criteria(_maUyNhiemChi));
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
                cm.CommandText = "spd_DeletetblUyNhiemChi_CacQuy";

                cm.Parameters.AddWithValue("@MaUyNhiemChi", criteria.MaUyNhiemChi);

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
            FetchChildren();
        }

        private void Fetch_New(SafeDataReader dr)
        {
            FetchObject(dr);
            MarkOld();
            ValidationRules.CheckRules();

            //load child object(s)
            //FetchChildren();
        }

        private void FetchObject(SafeDataReader dr)
        {
            _maUyNhiemChi = dr.GetInt64("MaUyNhiemChi");
            _so = dr.GetString("So");
            _ngay = dr.GetDateTime("Ngay");
            _dienGiai = dr.GetString("DienGiai");
            _soTien = dr.GetDecimal("SoTien");
            _ngayHeThong = dr.GetDateTime("NgayHeThong");
            _ngayXacNhan = dr.GetDateTime("NgayXacNhan");
            _loaiDeNghi = dr.GetInt32("LoaiDeNghi");
            _maNganHang = dr.GetInt32("MaNganHang");
            _userID = dr.GetInt32("UserID");
            _hoanTat = dr.GetBoolean("HoanTat");
            _ghiChu = dr.GetString("GhiChu");
            _soChungTu = dr.GetInt32("SoChungTu");
            _soTaiKhoan = dr.GetString("SoTK");
            _tenDoiTac = dr.GetString("TenDoiTac");
            _soTaiKhoanChuyen = dr.GetString("SoTaiKhoan");
            if (_ngayXacNhan == DateTime.MinValue)
                _ngayXacNhan = null;
        }

        private void FetchChildren()
        {
            _deNghi_UNC_CacQuyList = DeNghi_UyNhiemChi_CacQuyList.GetDeNghi_UyNhiemChi_CacQuyList(_maUyNhiemChi);
        }
        #endregion //Data Access - Fetch

        #region Data Access - Insert
        internal void Insert(SqlTransaction tr, UyNhiemChi_CacQuyList parent)
        {
            if (!IsDirty) return;

            ExecuteInsert(tr, parent);
            MarkOld();

            //update child object(s)
            UpdateChildren(tr);
        }

        private void ExecuteInsert(SqlTransaction tr, UyNhiemChi_CacQuyList parent)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_InserttblUyNhiemChi_CacQuy";

                AddInsertParameters(cm, parent);

                cm.ExecuteNonQuery();

                _maUyNhiemChi = (long)cm.Parameters["@MaUyNhiemChi"].Value;
            }//using
        }

        private void AddInsertParameters(SqlCommand cm, UyNhiemChi_CacQuyList parent)
        {
            //TODO: if parent use identity key, fix fk member with value from parent
            if (_so.Length > 0)
                cm.Parameters.AddWithValue("@So", _so);
            else
                cm.Parameters.AddWithValue("@So", DBNull.Value);
            cm.Parameters.AddWithValue("@Ngay", _ngay);
            if (_dienGiai.Length > 0)
                cm.Parameters.AddWithValue("@DienGiai", _dienGiai);
            else
                cm.Parameters.AddWithValue("@DienGiai", DBNull.Value);
            if (_soTien != 0)
                cm.Parameters.AddWithValue("@SoTien", _soTien);
            else
                cm.Parameters.AddWithValue("@SoTien", DBNull.Value);
            cm.Parameters.AddWithValue("@NgayHeThong", DateTime.Today);
            if (_ngayXacNhan != null && _ngayXacNhan != DateTime.MinValue)
                cm.Parameters.AddWithValue("@NgayXacNhan", _ngayXacNhan);
            else
                cm.Parameters.AddWithValue("@NgayXacNhan", DBNull.Value);
            cm.Parameters.AddWithValue("@LoaiDeNghi", _loaiDeNghi);
            if (_maNganHang != 0)
                cm.Parameters.AddWithValue("@MaNganHang", _maNganHang);
            else
                cm.Parameters.AddWithValue("@MaNganHang", DBNull.Value);
            cm.Parameters.AddWithValue("@UserID", Security.CurrentUser.Info.UserID);
            if (_hoanTat != false)
                cm.Parameters.AddWithValue("@HoanTat", _hoanTat);
            else
                cm.Parameters.AddWithValue("@HoanTat", DBNull.Value);
            if (_ghiChu.Length > 0)
                cm.Parameters.AddWithValue("@GhiChu", _ghiChu);
            else
                cm.Parameters.AddWithValue("@GhiChu", DBNull.Value);
            if (_soTaiKhoanChuyen.Length > 0)
                cm.Parameters.AddWithValue("@SoTaiKhoan", _soTaiKhoanChuyen);
            else
                cm.Parameters.AddWithValue("@SoTaiKhoan", DBNull.Value);
            if (_tenNganHang.Length > 0)
                cm.Parameters.AddWithValue("@TenNganHang", _tenNganHang);
            else
                cm.Parameters.AddWithValue("@TenNganHang", DBNull.Value);
            if (_soChungTu != 0)
                cm.Parameters.AddWithValue("@SoChungTu", _soChungTu);
            else
                cm.Parameters.AddWithValue("@SoChungTu", DBNull.Value);
            cm.Parameters.AddWithValue("@MaUyNhiemChi", _maUyNhiemChi);
            cm.Parameters["@MaUyNhiemChi"].Direction = ParameterDirection.Output;
        }
        #endregion //Data Access - Insert

        #region Data Access - Update
        internal void Update(SqlTransaction tr, UyNhiemChi_CacQuyList parent)
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

        private void ExecuteUpdate(SqlTransaction tr, UyNhiemChi_CacQuyList parent)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_UpdatetblUyNhiemChi_CacQuy";

                AddUpdateParameters(cm, parent);

                cm.ExecuteNonQuery();

            }//using
        }

        private void AddUpdateParameters(SqlCommand cm, UyNhiemChi_CacQuyList parent)
        {
            cm.Parameters.AddWithValue("@MaUyNhiemChi", _maUyNhiemChi);
            if (_so.Length > 0)
                cm.Parameters.AddWithValue("@So", _so);
            else
                cm.Parameters.AddWithValue("@So", DBNull.Value);
            cm.Parameters.AddWithValue("@Ngay", _ngay);
            if (_dienGiai.Length > 0)
                cm.Parameters.AddWithValue("@DienGiai", _dienGiai);
            else
                cm.Parameters.AddWithValue("@DienGiai", DBNull.Value);
            if (_soTien != 0)
                cm.Parameters.AddWithValue("@SoTien", _soTien);
            else
                cm.Parameters.AddWithValue("@SoTien", DBNull.Value);
            cm.Parameters.AddWithValue("@NgayHeThong", DateTime.Today);
            if (_ngayXacNhan != null && _ngayXacNhan != DateTime.MinValue)
                cm.Parameters.AddWithValue("@NgayXacNhan", _ngayXacNhan);
            else
                cm.Parameters.AddWithValue("@NgayXacNhan", DBNull.Value);
            cm.Parameters.AddWithValue("@LoaiDeNghi", _loaiDeNghi);
            if (_maNganHang != 0)
                cm.Parameters.AddWithValue("@MaNganHang", _maNganHang);
            else
                cm.Parameters.AddWithValue("@MaNganHang", DBNull.Value);
            cm.Parameters.AddWithValue("@UserID", Security.CurrentUser.Info.UserID);
            if (_hoanTat != false)
                cm.Parameters.AddWithValue("@HoanTat", _hoanTat);
            else
                cm.Parameters.AddWithValue("@HoanTat", DBNull.Value);
            if (_ghiChu.Length > 0)
                cm.Parameters.AddWithValue("@GhiChu", _ghiChu);
            else
                cm.Parameters.AddWithValue("@GhiChu", DBNull.Value);
            if (_soChungTu != 0)
                cm.Parameters.AddWithValue("@SoChungTu", _soChungTu);
            else
                cm.Parameters.AddWithValue("@SoChungTu", DBNull.Value);
            if (_soTaiKhoanChuyen.Length > 0)
                cm.Parameters.AddWithValue("@SoTaiKhoan", _soTaiKhoanChuyen);
            else
                cm.Parameters.AddWithValue("@SoTaiKhoan", DBNull.Value);
            if (_tenNganHang.Length > 0)
                cm.Parameters.AddWithValue("@TenNganHang", _tenNganHang);
            else
                cm.Parameters.AddWithValue("@TenNganHang", DBNull.Value);
        }

        private void UpdateChildren(SqlTransaction tr)
        {
            _deNghi_UNC_CacQuyList.Update(tr, this);
        }
        #endregion //Data Access - Update

        #region Data Access - Delete
        internal void DeleteSelf(SqlTransaction tr)
        {
            if (!IsDirty) return;
            if (IsNew) return;

            _deNghi_UNC_CacQuyList.Clear();
            _deNghi_UNC_CacQuyList.Update(tr, this);
            ExecuteDelete(tr, new Criteria(_maUyNhiemChi));
            MarkNew();
        }
        #endregion //Data Access - Delete
        #endregion //Data Access

        public string GetMaUNC()
        {
            string strMaUNC = string.Empty;
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_LayMaUNCNganHang";
                    cm.Parameters.AddWithValue("@MaNganHang", _maNganHang);

                    strMaUNC = Convert.ToString(cm.ExecuteScalar());
                }

                cn.Close();
            }
            return strMaUNC;
        }

        public string GetSoChungTu(ref int iSoChungTu)
        {
            string strSoChungTu = string.Empty;
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {

                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_LaySoChungTuMax_CacQuy";
                    cm.Parameters.AddWithValue("@MaNganHang", _maNganHang);
                    cm.Parameters.AddWithValue("@Nam", _ngay.Year);

                    //Do công ty khác nhau cung sử dụng 1 TK ngân hàng nên phải lấy thêm từng công ty
                    cm.Parameters.AddWithValue("@MaCongTy", Security.CurrentUser.Info.MaCongTy);
                    cm.Parameters.AddWithValue("@LoaiDeNghi", _loaiDeNghi);

                    iSoChungTu = Convert.ToInt32(cm.ExecuteScalar());
                }
                cn.Close();
            }
            iSoChungTu++;
            if (iSoChungTu.ToString().Length == 1)
                strSoChungTu = "000" + iSoChungTu.ToString();
            else if (iSoChungTu.ToString().Length == 2)
                strSoChungTu = "00" + iSoChungTu.ToString();
            else if (iSoChungTu.ToString().Length == 3)
                strSoChungTu = "0" + iSoChungTu.ToString();
            else
                strSoChungTu = iSoChungTu.ToString();

            return strSoChungTu;
        }
    }
}
