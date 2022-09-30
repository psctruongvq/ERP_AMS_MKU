
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{
    [Serializable()]
    public class ChuyenKhoanChuaDuyet : Csla.BusinessBase<ChuyenKhoanChuaDuyet>
    {
        #region Business Properties and Methods

        //declare members
        private long _maPhieu = 0;
        private string _so = string.Empty;
        private SmartDate _ngay = new SmartDate(false);
        private int _userID = 0;
        private string _tenDangNhap = string.Empty;
        private long _maNganHang = 0;
        private string _soTaiKhoan = string.Empty;
        private string _tenNganHang = string.Empty;
        private string _tenDoiTac = string.Empty;
        private decimal _soTien = 0;
        private int _loaiTien = 0;
        private string _maQuanLy = string.Empty;
        private int _loai = 0;
        private string _dienGiai = string.Empty;

        [System.ComponentModel.DataObjectField(true, true)]
        public long MaPhieu
        {
            get
            {
                CanReadProperty("MaPhieu", true);
                return _maPhieu;
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
        }

        public string NgayString
        {
            get
            {
                CanReadProperty("NgayString", true);
                return _ngay.Text;
            }
            set
            {
                CanWriteProperty("NgayString", true);
                if (value == null) value = string.Empty;
                if (!_ngay.Equals(value))
                {
                    _ngay.Text = value;
                    PropertyHasChanged("NgayString");
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

        public string TenDangNhap
        {
            get
            {
                CanReadProperty("TenDangNhap", true);
                return _tenDangNhap;
            }
            set
            {
                CanWriteProperty("TenDangNhap", true);
                if (value == null) value = string.Empty;
                if (!_tenDangNhap.Equals(value))
                {
                    _tenDangNhap = value;
                    PropertyHasChanged("TenDangNhap");
                }
            }
        }

        public long MaNganHang
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

        public string MaQuanLy
        {
            get
            {
                CanReadProperty("MaQuanLy", true);
                return _maQuanLy;
            }
            set
            {
                CanWriteProperty("MaQuanLy", true);
                if (value == null) value = string.Empty;
                if (!_maQuanLy.Equals(value))
                {
                    _maQuanLy = value;
                    PropertyHasChanged("MaQuanLy");
                }
            }
        }

        public int Loai
        {
            get
            {
                CanReadProperty("Loai", true);
                return _loai;
            }
            set
            {
                CanWriteProperty("Loai", true);
                if (!_loai.Equals(value))
                {
                    _loai = value;
                    PropertyHasChanged("Loai");
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

        protected override object GetIdValue()
        {
            return _maPhieu;
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
            // TenDangNhap
            //
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("TenDangNhap", 50));
            //
            // SoTaiKhoan
            //
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("SoTaiKhoan", 50));
            //
            // TenNganHang
            //
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("TenNganHang", 200));
            //
            // TenDoiTac
            //
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("TenDoiTac", 200));
            //
            // MaQuanLy
            //
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("MaQuanLy", 5));
            //
            // DienGiai
            //
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("DienGiai", 4000));
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
            //TODO: Define authorization rules in ChuyenKhoanChuaDuyet
            //AuthorizationRules.AllowRead("MaPhieu", "ChuyenKhoanChuaDuyetReadGroup");
            //AuthorizationRules.AllowRead("So", "ChuyenKhoanChuaDuyetReadGroup");
            //AuthorizationRules.AllowRead("Ngay", "ChuyenKhoanChuaDuyetReadGroup");
            //AuthorizationRules.AllowRead("NgayString", "ChuyenKhoanChuaDuyetReadGroup");
            //AuthorizationRules.AllowRead("UserID", "ChuyenKhoanChuaDuyetReadGroup");
            //AuthorizationRules.AllowRead("TenDangNhap", "ChuyenKhoanChuaDuyetReadGroup");
            //AuthorizationRules.AllowRead("MaNganHang", "ChuyenKhoanChuaDuyetReadGroup");
            //AuthorizationRules.AllowRead("SoTaiKhoan", "ChuyenKhoanChuaDuyetReadGroup");
            //AuthorizationRules.AllowRead("TenNganHang", "ChuyenKhoanChuaDuyetReadGroup");
            //AuthorizationRules.AllowRead("TenDoiTac", "ChuyenKhoanChuaDuyetReadGroup");
            //AuthorizationRules.AllowRead("SoTien", "ChuyenKhoanChuaDuyetReadGroup");
            //AuthorizationRules.AllowRead("LoaiTien", "ChuyenKhoanChuaDuyetReadGroup");
            //AuthorizationRules.AllowRead("MaQuanLy", "ChuyenKhoanChuaDuyetReadGroup");
            //AuthorizationRules.AllowRead("Loai", "ChuyenKhoanChuaDuyetReadGroup");
            //AuthorizationRules.AllowRead("DienGiai", "ChuyenKhoanChuaDuyetReadGroup");

            //AuthorizationRules.AllowWrite("So", "ChuyenKhoanChuaDuyetWriteGroup");
            //AuthorizationRules.AllowWrite("NgayString", "ChuyenKhoanChuaDuyetWriteGroup");
            //AuthorizationRules.AllowWrite("UserID", "ChuyenKhoanChuaDuyetWriteGroup");
            //AuthorizationRules.AllowWrite("TenDangNhap", "ChuyenKhoanChuaDuyetWriteGroup");
            //AuthorizationRules.AllowWrite("MaNganHang", "ChuyenKhoanChuaDuyetWriteGroup");
            //AuthorizationRules.AllowWrite("SoTaiKhoan", "ChuyenKhoanChuaDuyetWriteGroup");
            //AuthorizationRules.AllowWrite("TenNganHang", "ChuyenKhoanChuaDuyetWriteGroup");
            //AuthorizationRules.AllowWrite("TenDoiTac", "ChuyenKhoanChuaDuyetWriteGroup");
            //AuthorizationRules.AllowWrite("SoTien", "ChuyenKhoanChuaDuyetWriteGroup");
            //AuthorizationRules.AllowWrite("LoaiTien", "ChuyenKhoanChuaDuyetWriteGroup");
            //AuthorizationRules.AllowWrite("MaQuanLy", "ChuyenKhoanChuaDuyetWriteGroup");
            //AuthorizationRules.AllowWrite("Loai", "ChuyenKhoanChuaDuyetWriteGroup");
            //AuthorizationRules.AllowWrite("DienGiai", "ChuyenKhoanChuaDuyetWriteGroup");
        }


        public static bool CanGetObject()
        {
            //TODO: Define CanGetObject permission in ChuyenKhoanChuaDuyet
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("ChuyenKhoanChuaDuyetViewGroup"))
            //	return true;
            //return false;
        }

        public static bool CanAddObject()
        {
            //TODO: Define CanAddObject permission in ChuyenKhoanChuaDuyet
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("ChuyenKhoanChuaDuyetAddGroup"))
            //	return true;
            //return false;
        }

        public static bool CanEditObject()
        {
            //TODO: Define CanEditObject permission in ChuyenKhoanChuaDuyet
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("ChuyenKhoanChuaDuyetEditGroup"))
            //	return true;
            //return false;
        }

        public static bool CanDeleteObject()
        {
            //TODO: Define CanDeleteObject permission in ChuyenKhoanChuaDuyet
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("ChuyenKhoanChuaDuyetDeleteGroup"))
            //	return true;
            //return false;
        }
        #endregion //Authorization Rules

        #region Factory Methods
        private ChuyenKhoanChuaDuyet()
        { /* require use of factory method */ }

        public static ChuyenKhoanChuaDuyet NewChuyenKhoanChuaDuyet()
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a ChuyenKhoanChuaDuyet");
            return DataPortal.Create<ChuyenKhoanChuaDuyet>();
        }

        public static ChuyenKhoanChuaDuyet GetChuyenKhoanChuaDuyet(long maPhieu)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a ChuyenKhoanChuaDuyet");
            return DataPortal.Fetch<ChuyenKhoanChuaDuyet>(new Criteria(maPhieu));
        }

        public static void DeleteChuyenKhoanChuaDuyet(long maPhieu)
        {
            if (!CanDeleteObject())
                throw new System.Security.SecurityException("User not authorized to remove a ChuyenKhoanChuaDuyet");
            DataPortal.Delete(new Criteria(maPhieu));
        }

        public override ChuyenKhoanChuaDuyet Save()
        {
            if (IsDeleted && !CanDeleteObject())
                throw new System.Security.SecurityException("User not authorized to remove a ChuyenKhoanChuaDuyet");
            else if (IsNew && !CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a ChuyenKhoanChuaDuyet");
            else if (!CanEditObject())
                throw new System.Security.SecurityException("User not authorized to update a ChuyenKhoanChuaDuyet");

            return base.Save();
        }

        #endregion //Factory Methods

        #region Child Factory Methods
        internal static ChuyenKhoanChuaDuyet NewChuyenKhoanChuaDuyetChild()
        {
            ChuyenKhoanChuaDuyet child = new ChuyenKhoanChuaDuyet();
            child.ValidationRules.CheckRules();
            child.MarkAsChild();
            return child;
        }

        internal static ChuyenKhoanChuaDuyet GetChuyenKhoanChuaDuyet(SafeDataReader dr)
        {
            ChuyenKhoanChuaDuyet child = new ChuyenKhoanChuaDuyet();
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
            public long MaPhieu;

            public Criteria(long maPhieu)
            {
                this.MaPhieu = maPhieu;
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
                cm.CommandText = "GetChuyenKhoanChuaDuyet";

                cm.Parameters.AddWithValue("@MaPhieu", criteria.MaPhieu);

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

                ExecuteInsert(cn, null);

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
                    ExecuteUpdate(cn, null);
                }

                //update child object(s)
                UpdateChildren(cn);
            }//using

        }

        #endregion //Data Access - Update

        #region Data Access - Delete
        protected override void DataPortal_DeleteSelf()
        {
            DataPortal_Delete(new Criteria(_maPhieu));
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
                cm.CommandText = "DeleteChuyenKhoanChuaDuyet";

                cm.Parameters.AddWithValue("@MaPhieu", criteria.MaPhieu);

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
            _maPhieu = dr.GetInt64("MaPhieu");
            _so = dr.GetString("So");
            _ngay = dr.GetSmartDate("Ngay", _ngay.EmptyIsMin);
            _userID = dr.GetInt32("UserID");
            _tenDangNhap = dr.GetString("TenDangNhap");
            _maNganHang = dr.GetInt64("MaNganHang");
            _soTaiKhoan = dr.GetString("SoTaiKhoan");
            _tenNganHang = dr.GetString("TenNganHang");
            _tenDoiTac = dr.GetString("TenDoiTac");
            _soTien = dr.GetDecimal("SoTien");
            _loaiTien = dr.GetInt32("LoaiTien");
            _maQuanLy = dr.GetString("MaQuanLy");
            _loai = dr.GetInt32("Loai");
            _dienGiai = dr.GetString("DienGiai");
        }

        private void FetchChildren(SafeDataReader dr)
        {
        }
        #endregion //Data Access - Fetch

        #region Data Access - Insert
        internal void Insert(SqlConnection cn, ChuyenKhoanChuaDuyetList parent)
        {
            if (!IsDirty) return;

            ExecuteInsert(cn, parent);
            MarkOld();

            //update child object(s)
            UpdateChildren(cn);
        }

        private void ExecuteInsert(SqlConnection cn, ChuyenKhoanChuaDuyetList parent)
        {
            using (SqlCommand cm = cn.CreateCommand())
            {
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "AddChuyenKhoanChuaDuyet";

                AddInsertParameters(cm, parent);

                cm.ExecuteNonQuery();

                _maPhieu = (long)cm.Parameters["@NewMaPhieu"].Value;
            }//using
        }

        private void AddInsertParameters(SqlCommand cm, ChuyenKhoanChuaDuyetList parent)
        {
            //TODO: if parent use identity key, fix fk member with value from parent
            if (_so.Length > 0)
                cm.Parameters.AddWithValue("@So", _so);
            else
                cm.Parameters.AddWithValue("@So", DBNull.Value);
            cm.Parameters.AddWithValue("@Ngay", _ngay.DBValue);
            if (_userID != 0)
                cm.Parameters.AddWithValue("@UserID", _userID);
            else
                cm.Parameters.AddWithValue("@UserID", DBNull.Value);
            if (_tenDangNhap.Length > 0)
                cm.Parameters.AddWithValue("@TenDangNhap", _tenDangNhap);
            else
                cm.Parameters.AddWithValue("@TenDangNhap", DBNull.Value);
            if (_maNganHang != 0)
                cm.Parameters.AddWithValue("@MaNganHang", _maNganHang);
            else
                cm.Parameters.AddWithValue("@MaNganHang", DBNull.Value);
            if (_soTaiKhoan.Length > 0)
                cm.Parameters.AddWithValue("@SoTaiKhoan", _soTaiKhoan);
            else
                cm.Parameters.AddWithValue("@SoTaiKhoan", DBNull.Value);
            if (_tenNganHang.Length > 0)
                cm.Parameters.AddWithValue("@TenNganHang", _tenNganHang);
            else
                cm.Parameters.AddWithValue("@TenNganHang", DBNull.Value);
            if (_tenDoiTac.Length > 0)
                cm.Parameters.AddWithValue("@TenDoiTac", _tenDoiTac);
            else
                cm.Parameters.AddWithValue("@TenDoiTac", DBNull.Value);
            if (_soTien != 0)
                cm.Parameters.AddWithValue("@SoTien", _soTien);
            else
                cm.Parameters.AddWithValue("@SoTien", DBNull.Value);
            if (_loaiTien != 0)
                cm.Parameters.AddWithValue("@LoaiTien", _loaiTien);
            else
                cm.Parameters.AddWithValue("@LoaiTien", DBNull.Value);
            if (_maQuanLy.Length > 0)
                cm.Parameters.AddWithValue("@MaQuanLy", _maQuanLy);
            else
                cm.Parameters.AddWithValue("@MaQuanLy", DBNull.Value);
            if (_loai != 0)
                cm.Parameters.AddWithValue("@Loai", _loai);
            else
                cm.Parameters.AddWithValue("@Loai", DBNull.Value);
            if (_dienGiai.Length > 0)
                cm.Parameters.AddWithValue("@DienGiai", _dienGiai);
            else
                cm.Parameters.AddWithValue("@DienGiai", DBNull.Value);
            cm.Parameters.AddWithValue("@NewMaPhieu", _maPhieu);
            cm.Parameters["@NewMaPhieu"].Direction = ParameterDirection.Output;
        }
        #endregion //Data Access - Insert

        #region Data Access - Update
        internal void Update(SqlConnection cn, ChuyenKhoanChuaDuyetList parent)
        {
            if (!IsDirty) return;

            if (base.IsDirty)
            {
                ExecuteUpdate(cn, parent);
                MarkOld();
            }

            //update child object(s)
            UpdateChildren(cn);
        }

        private void ExecuteUpdate(SqlConnection cn, ChuyenKhoanChuaDuyetList parent)
        {
            using (SqlCommand cm = cn.CreateCommand())
            {
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "UpdateChuyenKhoanChuaDuyet";

                AddUpdateParameters(cm, parent);

                cm.ExecuteNonQuery();

            }//using
        }

        private void AddUpdateParameters(SqlCommand cm, ChuyenKhoanChuaDuyetList parent)
        {
            cm.Parameters.AddWithValue("@MaPhieu", _maPhieu);
            if (_so.Length > 0)
                cm.Parameters.AddWithValue("@So", _so);
            else
                cm.Parameters.AddWithValue("@So", DBNull.Value);
            cm.Parameters.AddWithValue("@Ngay", _ngay.DBValue);
            if (_userID != 0)
                cm.Parameters.AddWithValue("@UserID", _userID);
            else
                cm.Parameters.AddWithValue("@UserID", DBNull.Value);
            if (_tenDangNhap.Length > 0)
                cm.Parameters.AddWithValue("@TenDangNhap", _tenDangNhap);
            else
                cm.Parameters.AddWithValue("@TenDangNhap", DBNull.Value);
            if (_maNganHang != 0)
                cm.Parameters.AddWithValue("@MaNganHang", _maNganHang);
            else
                cm.Parameters.AddWithValue("@MaNganHang", DBNull.Value);
            if (_soTaiKhoan.Length > 0)
                cm.Parameters.AddWithValue("@SoTaiKhoan", _soTaiKhoan);
            else
                cm.Parameters.AddWithValue("@SoTaiKhoan", DBNull.Value);
            if (_tenNganHang.Length > 0)
                cm.Parameters.AddWithValue("@TenNganHang", _tenNganHang);
            else
                cm.Parameters.AddWithValue("@TenNganHang", DBNull.Value);
            if (_tenDoiTac.Length > 0)
                cm.Parameters.AddWithValue("@TenDoiTac", _tenDoiTac);
            else
                cm.Parameters.AddWithValue("@TenDoiTac", DBNull.Value);
            if (_soTien != 0)
                cm.Parameters.AddWithValue("@SoTien", _soTien);
            else
                cm.Parameters.AddWithValue("@SoTien", DBNull.Value);
            if (_loaiTien != 0)
                cm.Parameters.AddWithValue("@LoaiTien", _loaiTien);
            else
                cm.Parameters.AddWithValue("@LoaiTien", DBNull.Value);
            if (_maQuanLy.Length > 0)
                cm.Parameters.AddWithValue("@MaQuanLy", _maQuanLy);
            else
                cm.Parameters.AddWithValue("@MaQuanLy", DBNull.Value);
            if (_loai != 0)
                cm.Parameters.AddWithValue("@Loai", _loai);
            else
                cm.Parameters.AddWithValue("@Loai", DBNull.Value);
            if (_dienGiai.Length > 0)
                cm.Parameters.AddWithValue("@DienGiai", _dienGiai);
            else
                cm.Parameters.AddWithValue("@DienGiai", DBNull.Value);
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

            ExecuteDelete(cn, new Criteria(_maPhieu));
            MarkNew();
        }
        #endregion //Data Access - Delete
        #endregion //Data Access
    }
}
