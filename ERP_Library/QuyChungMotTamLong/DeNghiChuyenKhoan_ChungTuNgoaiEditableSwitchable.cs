
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{
    [Serializable()]
    public class DeNghiChuyenKhoan_ChungTuNgoai : Csla.BusinessBase<DeNghiChuyenKhoan_ChungTuNgoai>
    {
        #region Business Properties and Methods

        //declare members
        public long _maPhieu = 0;
        private string _so = string.Empty;
        private DateTime _ngay = DateTime.Today;
        private long _maDoiTac = 0;
        private int _maTaiKhoanNhan = 0;
        private int _maTaiKhoanChuyen = 0;
        private string _lyDo = string.Empty;
        private decimal _soTien = 0;
        private int _loaiTien = 1;
        private bool _daDuyet = false;
        private int _userID = 0;
        private DateTime _ngayHeThong = DateTime.Today;
        private int _loaiDeNghi = 0;
        private string _ghiChu = string.Empty;

        private int _maBoPhan = ERP_Library.Security.CurrentUser.Info.MaBoPhan;
        private long _maNhanVien = ERP_Library.Security.CurrentUser.Info.MaNhanVien;
        private int _maCongTy = ERP_Library.Security.CurrentUser.Info.MaCongTy;
        private string _soTaiKhoan = string.Empty;
        private string _tenDoiTac = string.Empty;

        //Thành bổ sung ngày (04/09/2012)
        private DateTime? _ngayXacNhan = null;
        private string _soTaiKhoanChuyen = string.Empty;
        private decimal _tyGia = 0;
        private int _loaiChungTu = 0;
        private bool _chon = false;
        private string _tenLoaiChungTu = string.Empty;
        private decimal _thanhTien = 0;

        [System.ComponentModel.DataObjectField(true, true)]
        public long MaPhieu
        {
            get
            {
                CanReadProperty("MaPhieu", true);
                return _maPhieu;
            }
        }

        public bool Chon
        {
            get
            {
                CanReadProperty("Chon", true);
                return _chon;
            }
            set
            {
                CanWriteProperty("Chon", true);
                if (!_chon.Equals(value))
                {
                    _chon = value;
                    PropertyHasChanged("Chon");
                }
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

        public int MaTaiKhoanNhan
        {
            get
            {
                CanReadProperty("MaTaiKhoanNhan", true);
                return _maTaiKhoanNhan;
            }
            set
            {
                CanWriteProperty("MaTaiKhoanNhan", true);
                if (!_maTaiKhoanNhan.Equals(value))
                {
                    _maTaiKhoanNhan = value;
                    PropertyHasChanged("MaTaiKhoanNhan");
                }
            }
        }

        public int MaTaiKhoanChuyen
        {
            get
            {
                CanReadProperty("MaTaiKhoanChuyen", true);
                return _maTaiKhoanChuyen;
            }
            set
            {
                CanWriteProperty("MaTaiKhoanChuyen", true);
                if (!_maTaiKhoanChuyen.Equals(value))
                {
                    _maTaiKhoanChuyen = value;
                    PropertyHasChanged("MaTaiKhoanChuyen");
                }
            }
        }

        public string LyDo
        {
            get
            {
                CanReadProperty("LyDo", true);
                return _lyDo;
            }
            set
            {
                CanWriteProperty("LyDo", true);
                if (value == null) value = string.Empty;
                if (!_lyDo.Equals(value))
                {
                    _lyDo = value;
                    PropertyHasChanged("LyDo");
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

        public bool DaDuyet
        {
            get
            {
                CanReadProperty("DaDuyet", true);
                return _daDuyet;
            }
            set
            {
                CanWriteProperty("DaDuyet", true);
                if (!_daDuyet.Equals(value))
                {
                    _daDuyet = value;
                    PropertyHasChanged("DaDuyet");
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

        public long MaNhanVien
        {
            get
            {
                CanReadProperty("MaNhanVien", true);
                return _maNhanVien;
            }
            set
            {
                CanWriteProperty("MaNhanVien", true);
                if (!_maNhanVien.Equals(value))
                {
                    _maNhanVien = value;
                    PropertyHasChanged("MaNhanVien");
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

        public DateTime? NgayXacNhan
        {
            get
            {
                CanReadProperty("NgayXacNhan", true);
                return _ngayXacNhan;
            }
        }

        public string SoTaiKhoanChuyen
        {
            get
            {
                CanReadProperty("SoTaiKhoanChuyen", true);
                return _soTaiKhoanChuyen;
            }
        }

        public decimal TyGia
        {
            get
            {
                CanReadProperty("TyGia", true);
                return _tyGia;
            }
        }

        public decimal ThanhTien
        {
            get
            {
                CanReadProperty("ThanhTien", true);
                return _thanhTien;
            }
        }

        public int LoaiChungTu
        {
            get
            {
                CanReadProperty("LoaiChungTu", true);
                return _loaiChungTu;
            }
        }

        public string TenLoaiChungTu
        {
            get
            {
                CanReadProperty("TenLoaiChungTu", true);
                if (_loaiChungTu == 2)
                    return "Giấy báo có";
                else if (_loaiChungTu == 3)
                    return "Phí ngân hàng";
                else if (_loaiChungTu == 4)
                    return "Giấy rút tiền";
                else
                    return "Đề nghị chuyển khoản";
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
            // LyDo
            //
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("LyDo", 4000));
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
            //TODO: Define authorization rules in DeNghiChuyenKhoan_ChungTuNgoai
            //AuthorizationRules.AllowRead("MaPhieu", "DeNghiChuyenKhoan_ChungTuNgoaiReadGroup");
            //AuthorizationRules.AllowRead("So", "DeNghiChuyenKhoan_ChungTuNgoaiReadGroup");
            //AuthorizationRules.AllowRead("Ngay", "DeNghiChuyenKhoan_ChungTuNgoaiReadGroup");
            //AuthorizationRules.AllowRead("NgayString", "DeNghiChuyenKhoan_ChungTuNgoaiReadGroup");
            //AuthorizationRules.AllowRead("MaDoiTac", "DeNghiChuyenKhoan_ChungTuNgoaiReadGroup");
            //AuthorizationRules.AllowRead("MaTaiKhoanNhan", "DeNghiChuyenKhoan_ChungTuNgoaiReadGroup");
            //AuthorizationRules.AllowRead("MaTaiKhoanChuyen", "DeNghiChuyenKhoan_ChungTuNgoaiReadGroup");
            //AuthorizationRules.AllowRead("LyDo", "DeNghiChuyenKhoan_ChungTuNgoaiReadGroup");
            //AuthorizationRules.AllowRead("SoTien", "DeNghiChuyenKhoan_ChungTuNgoaiReadGroup");
            //AuthorizationRules.AllowRead("LoaiTien", "DeNghiChuyenKhoan_ChungTuNgoaiReadGroup");
            //AuthorizationRules.AllowRead("DaDuyet", "DeNghiChuyenKhoan_ChungTuNgoaiReadGroup");
            //AuthorizationRules.AllowRead("UserID", "DeNghiChuyenKhoan_ChungTuNgoaiReadGroup");
            //AuthorizationRules.AllowRead("NgayHeThong", "DeNghiChuyenKhoan_ChungTuNgoaiReadGroup");
            //AuthorizationRules.AllowRead("NgayHeThongString", "DeNghiChuyenKhoan_ChungTuNgoaiReadGroup");
            //AuthorizationRules.AllowRead("LoaiDeNghi", "DeNghiChuyenKhoan_ChungTuNgoaiReadGroup");
            //AuthorizationRules.AllowRead("GhiChu", "DeNghiChuyenKhoan_ChungTuNgoaiReadGroup");

            //AuthorizationRules.AllowWrite("So", "DeNghiChuyenKhoan_ChungTuNgoaiWriteGroup");
            //AuthorizationRules.AllowWrite("NgayString", "DeNghiChuyenKhoan_ChungTuNgoaiWriteGroup");
            //AuthorizationRules.AllowWrite("MaDoiTac", "DeNghiChuyenKhoan_ChungTuNgoaiWriteGroup");
            //AuthorizationRules.AllowWrite("MaTaiKhoanNhan", "DeNghiChuyenKhoan_ChungTuNgoaiWriteGroup");
            //AuthorizationRules.AllowWrite("MaTaiKhoanChuyen", "DeNghiChuyenKhoan_ChungTuNgoaiWriteGroup");
            //AuthorizationRules.AllowWrite("LyDo", "DeNghiChuyenKhoan_ChungTuNgoaiWriteGroup");
            //AuthorizationRules.AllowWrite("SoTien", "DeNghiChuyenKhoan_ChungTuNgoaiWriteGroup");
            //AuthorizationRules.AllowWrite("LoaiTien", "DeNghiChuyenKhoan_ChungTuNgoaiWriteGroup");
            //AuthorizationRules.AllowWrite("DaDuyet", "DeNghiChuyenKhoan_ChungTuNgoaiWriteGroup");
            //AuthorizationRules.AllowWrite("UserID", "DeNghiChuyenKhoan_ChungTuNgoaiWriteGroup");
            //AuthorizationRules.AllowWrite("NgayHeThongString", "DeNghiChuyenKhoan_ChungTuNgoaiWriteGroup");
            //AuthorizationRules.AllowWrite("LoaiDeNghi", "DeNghiChuyenKhoan_ChungTuNgoaiWriteGroup");
            //AuthorizationRules.AllowWrite("GhiChu", "DeNghiChuyenKhoan_ChungTuNgoaiWriteGroup");
        }


        public static bool CanGetObject()
        {
            //TODO: Define CanGetObject permission in DeNghiChuyenKhoan_ChungTuNgoai
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("DeNghiChuyenKhoan_ChungTuNgoaiViewGroup"))
            //	return true;
            //return false;
        }

        public static bool CanAddObject()
        {
            //TODO: Define CanAddObject permission in DeNghiChuyenKhoan_ChungTuNgoai
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("DeNghiChuyenKhoan_ChungTuNgoaiAddGroup"))
            //	return true;
            //return false;
        }

        public static bool CanEditObject()
        {
            //TODO: Define CanEditObject permission in DeNghiChuyenKhoan_ChungTuNgoai
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("DeNghiChuyenKhoan_ChungTuNgoaiEditGroup"))
            //	return true;
            //return false;
        }

        public static bool CanDeleteObject()
        {
            //TODO: Define CanDeleteObject permission in DeNghiChuyenKhoan_ChungTuNgoai
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("DeNghiChuyenKhoan_ChungTuNgoaiDeleteGroup"))
            //	return true;
            //return false;
        }
        #endregion //Authorization Rules

        #region Factory Methods
        private DeNghiChuyenKhoan_ChungTuNgoai()
        { 
            /* require use of factory method */
            MarkAsChild();
        }

        public static DeNghiChuyenKhoan_ChungTuNgoai NewDeNghiChuyenKhoan_ChungTuNgoai()
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a DeNghiChuyenKhoan_ChungTuNgoai");
            return DataPortal.Create<DeNghiChuyenKhoan_ChungTuNgoai>();
        }

        public static DeNghiChuyenKhoan_ChungTuNgoai GetDeNghiChuyenKhoan_ChungTuNgoai(long maPhieu)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a DeNghiChuyenKhoan_ChungTuNgoai");
            return DataPortal.Fetch<DeNghiChuyenKhoan_ChungTuNgoai>(new Criteria(maPhieu));
        }

        public static void DeleteDeNghiChuyenKhoan_ChungTuNgoai(long maPhieu)
        {
            if (!CanDeleteObject())
                throw new System.Security.SecurityException("User not authorized to remove a DeNghiChuyenKhoan_ChungTuNgoai");
            DataPortal.Delete(new Criteria(maPhieu));
        }

        public override DeNghiChuyenKhoan_ChungTuNgoai Save()
        {
            if (IsDeleted && !CanDeleteObject())
                throw new System.Security.SecurityException("User not authorized to remove a DeNghiChuyenKhoan_ChungTuNgoai");
            else if (IsNew && !CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a DeNghiChuyenKhoan_ChungTuNgoai");
            else if (!CanEditObject())
                throw new System.Security.SecurityException("User not authorized to update a DeNghiChuyenKhoan_ChungTuNgoai");

            return base.Save();
        }

        #endregion //Factory Methods

        #region Child Factory Methods
        internal static DeNghiChuyenKhoan_ChungTuNgoai NewDeNghiChuyenKhoan_ChungTuNgoaiChild()
        {
            DeNghiChuyenKhoan_ChungTuNgoai child = new DeNghiChuyenKhoan_ChungTuNgoai();
            child.ValidationRules.CheckRules();
            child.MarkAsChild();
            return child;
        }

        internal static DeNghiChuyenKhoan_ChungTuNgoai GetDeNghiChuyenKhoan_ChungTuNgoai(SafeDataReader dr)
        {
            DeNghiChuyenKhoan_ChungTuNgoai child = new DeNghiChuyenKhoan_ChungTuNgoai();
            child.MarkAsChild();
            child.Fetch(dr);
            return child;
        }

        internal static DeNghiChuyenKhoan_ChungTuNgoai GetDeNghiChuyenKhoan_ChungTuNgoai_New(SafeDataReader dr)
        {
            DeNghiChuyenKhoan_ChungTuNgoai child = new DeNghiChuyenKhoan_ChungTuNgoai();
            child.MarkAsChild();
            child.Fetch_New(dr);
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
                cm.CommandText = "spd_SelecttblDeNghiChuyenKhoan_ChungTuNgoai";

                cm.Parameters.AddWithValue("@MaPhieu", criteria.MaPhieu);

                using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                {
                    if (dr.Read())
                    {
                        FetchObject(dr);
                        ValidationRules.CheckRules();

                        //load child object(s)
                        FetchChildren(dr);
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
            DataPortal_Delete(new Criteria(_maPhieu));
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
                cm.CommandText = "spd_DeletetblDeNghiChuyenKhoan_ChungTuNgoai";

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
            _ngay = dr.GetDateTime("Ngay");
            _maDoiTac = dr.GetInt64("MaDoiTac");
            _maTaiKhoanNhan = dr.GetInt32("MaTaiKhoanNhan");
            _maTaiKhoanChuyen = dr.GetInt32("MaTaiKhoanChuyen");
            _lyDo = dr.GetString("LyDo");
            _soTien = dr.GetDecimal("SoTien");
            _loaiTien = dr.GetInt32("LoaiTien");
            _daDuyet = dr.GetBoolean("DaDuyet");
            _userID = dr.GetInt32("UserID");
            _ngayHeThong = dr.GetDateTime("NgayHeThong");
            _loaiDeNghi = dr.GetInt32("LoaiDeNghi");
            _ghiChu = dr.GetString("GhiChu");
            _maBoPhan = dr.GetInt32("MaBoPhan");
            _maNhanVien = dr.GetInt64("MaNhanVien");
            _soTaiKhoan = dr.GetString("SoTaiKhoan");
            _tenDoiTac = dr.GetString("TenDoiTac");
        }

        private void Fetch_New(SafeDataReader dr)
        {
            FetchObject_New(dr);
            MarkOld();
            ValidationRules.CheckRules();

            //load child object(s)
            FetchChildren(dr);
        }

        private void FetchObject_New(SafeDataReader dr)
        {
            _maPhieu = dr.GetInt64("MaPhieu");
            _so = dr.GetString("So");
            _ngay = dr.GetDateTime("Ngay");
            _maDoiTac = dr.GetInt64("MaDoiTac");
            _maTaiKhoanNhan = dr.GetInt32("MaTaiKhoanNhan");
            _maTaiKhoanChuyen = dr.GetInt32("MaTaiKhoanChuyen");
            _lyDo = dr.GetString("LyDo");
            _soTien = dr.GetDecimal("SoTien");
            _loaiTien = dr.GetInt32("LoaiTien");
            _daDuyet = dr.GetBoolean("DaDuyet");
            _userID = dr.GetInt32("UserID");
            _ngayHeThong = dr.GetDateTime("NgayHeThong");
            _loaiDeNghi = dr.GetInt32("LoaiDeNghi");
            _ghiChu = dr.GetString("GhiChu");
            _maBoPhan = dr.GetInt32("MaBoPhan");
            _maNhanVien = dr.GetInt64("MaNhanVien");
            _soTaiKhoan = dr.GetString("SoTaiKhoan");
            _tenDoiTac = dr.GetString("TenDoiTac");
            _ngayXacNhan = dr.GetDateTime("NgayXacNhan");
            if (_ngayXacNhan == DateTime.MinValue)
                _ngayXacNhan = null;
            _soTaiKhoanChuyen = dr.GetString("SoTaiKhoanChuyen");
            _tyGia = dr.GetDecimal("TyGia");
            _loaiChungTu = dr.GetInt32("LoaiChungTu");
            _thanhTien = _tyGia * _soTien;
        }

        private void FetchChildren(SafeDataReader dr)
        {
        }
        #endregion //Data Access - Fetch

        #region Data Access - Insert
        internal void Insert(SqlTransaction tr, DeNghiChuyenKhoan_ChungTuNgoaiList parent)
        {
            if (!IsDirty) return;

            ExecuteInsert(tr, parent);
            MarkOld();

            //update child object(s)
            UpdateChildren(tr);
        }

        private void ExecuteInsert(SqlTransaction tr, DeNghiChuyenKhoan_ChungTuNgoaiList parent)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_InserttblDeNghiChuyenKhoan_ChungTuNgoai";

                AddInsertParameters(cm, parent);

                cm.ExecuteNonQuery();

                _maPhieu = (long)cm.Parameters["@MaPhieu"].Value;
            }//using
        }

        private void AddInsertParameters(SqlCommand cm, DeNghiChuyenKhoan_ChungTuNgoaiList parent)
        {
            //TODO: if parent use identity key, fix fk member with value from parent
            if (_so.Length > 0)
                cm.Parameters.AddWithValue("@So", _so);
            else
                cm.Parameters.AddWithValue("@So", DBNull.Value);
            cm.Parameters.AddWithValue("@Ngay", _ngay);
            if (_maDoiTac != 0)
                cm.Parameters.AddWithValue("@MaDoiTac", _maDoiTac);
            else
                cm.Parameters.AddWithValue("@MaDoiTac", DBNull.Value);
            if (_maTaiKhoanNhan != 0)
                cm.Parameters.AddWithValue("@MaTaiKhoanNhan", _maTaiKhoanNhan);
            else
                cm.Parameters.AddWithValue("@MaTaiKhoanNhan", DBNull.Value);
            if (_maTaiKhoanChuyen != 0)
                cm.Parameters.AddWithValue("@MaTaiKhoanChuyen", _maTaiKhoanChuyen);
            else
                cm.Parameters.AddWithValue("@MaTaiKhoanChuyen", DBNull.Value);
            if (_lyDo.Length > 0)
                cm.Parameters.AddWithValue("@LyDo", _lyDo);
            else
                cm.Parameters.AddWithValue("@LyDo", DBNull.Value);
            if (_soTien != 0)
                cm.Parameters.AddWithValue("@SoTien", _soTien);
            else
                cm.Parameters.AddWithValue("@SoTien", DBNull.Value);
            if (_loaiTien != 0)
                cm.Parameters.AddWithValue("@LoaiTien", _loaiTien);
            else
                cm.Parameters.AddWithValue("@LoaiTien", DBNull.Value);
            cm.Parameters.AddWithValue("@DaDuyet", _daDuyet);
            cm.Parameters.AddWithValue("@UserID", Security.CurrentUser.Info.UserID);
            cm.Parameters.AddWithValue("@NgayHeThong", _ngayHeThong);
            cm.Parameters.AddWithValue("@LoaiDeNghi", _loaiDeNghi);
            if (_ghiChu.Length > 0)
                cm.Parameters.AddWithValue("@GhiChu", _ghiChu);
            else
                cm.Parameters.AddWithValue("@GhiChu", DBNull.Value);
            cm.Parameters.AddWithValue("@MaBoPhan", _maBoPhan);
            cm.Parameters.AddWithValue("@MaNhanVien", _maNhanVien);
            cm.Parameters.AddWithValue("@MaCongTy", _maCongTy);
            if (_soTaiKhoan.Length > 0)
                cm.Parameters.AddWithValue("@SoTaiKhoan", _soTaiKhoan);
            else
                cm.Parameters.AddWithValue("@SoTaiKhoan", DBNull.Value);
            if (_tenDoiTac.Length > 0)
                cm.Parameters.AddWithValue("@TenDoiTac", _tenDoiTac);
            else
                cm.Parameters.AddWithValue("@TenDoiTac", DBNull.Value);
            cm.Parameters.AddWithValue("@MaPhieu", _maPhieu);
            cm.Parameters["@MaPhieu"].Direction = ParameterDirection.Output;
        }
        #endregion //Data Access - Insert

        #region Data Access - Update
        internal void Update(SqlTransaction tr, DeNghiChuyenKhoan_ChungTuNgoaiList parent)
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

        private void ExecuteUpdate(SqlTransaction tr, DeNghiChuyenKhoan_ChungTuNgoaiList parent)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_UpdatetblDeNghiChuyenKhoan_ChungTuNgoai";

                AddUpdateParameters(cm, parent);

                cm.ExecuteNonQuery();

            }//using
        }

        private void AddUpdateParameters(SqlCommand cm, DeNghiChuyenKhoan_ChungTuNgoaiList parent)
        {
            cm.Parameters.AddWithValue("@MaPhieu", _maPhieu);
            if (_so.Length > 0)
                cm.Parameters.AddWithValue("@So", _so);
            else
                cm.Parameters.AddWithValue("@So", DBNull.Value);
            cm.Parameters.AddWithValue("@Ngay", _ngay);
            if (_maDoiTac != 0)
                cm.Parameters.AddWithValue("@MaDoiTac", _maDoiTac);
            else
                cm.Parameters.AddWithValue("@MaDoiTac", DBNull.Value);
            if (_maTaiKhoanNhan != 0)
                cm.Parameters.AddWithValue("@MaTaiKhoanNhan", _maTaiKhoanNhan);
            else
                cm.Parameters.AddWithValue("@MaTaiKhoanNhan", DBNull.Value);
            if (_maTaiKhoanChuyen != 0)
                cm.Parameters.AddWithValue("@MaTaiKhoanChuyen", _maTaiKhoanChuyen);
            else
                cm.Parameters.AddWithValue("@MaTaiKhoanChuyen", DBNull.Value);
            if (_lyDo.Length > 0)
                cm.Parameters.AddWithValue("@LyDo", _lyDo);
            else
                cm.Parameters.AddWithValue("@LyDo", DBNull.Value);
            if (_soTien != 0)
                cm.Parameters.AddWithValue("@SoTien", _soTien);
            else
                cm.Parameters.AddWithValue("@SoTien", DBNull.Value);
            if (_loaiTien != 0)
                cm.Parameters.AddWithValue("@LoaiTien", _loaiTien);
            else
                cm.Parameters.AddWithValue("@LoaiTien", DBNull.Value);
            cm.Parameters.AddWithValue("@DaDuyet", _daDuyet);
            cm.Parameters.AddWithValue("@UserID", Security.CurrentUser.Info.UserID);
            cm.Parameters.AddWithValue("@NgayHeThong", _ngayHeThong);
            cm.Parameters.AddWithValue("@LoaiDeNghi", _loaiDeNghi);
            if (_ghiChu.Length > 0)
                cm.Parameters.AddWithValue("@GhiChu", _ghiChu);
            else
                cm.Parameters.AddWithValue("@GhiChu", DBNull.Value);
            cm.Parameters.AddWithValue("@MaBoPhan", _maBoPhan);
            cm.Parameters.AddWithValue("@MaNhanVien", _maNhanVien);
            cm.Parameters.AddWithValue("@MaCongTy", _maCongTy);
            if (_soTaiKhoan.Length > 0)
                cm.Parameters.AddWithValue("@SoTaiKhoan", _soTaiKhoan);
            else
                cm.Parameters.AddWithValue("@SoTaiKhoan", DBNull.Value);
            if (_tenDoiTac.Length > 0)
                cm.Parameters.AddWithValue("@TenDoiTac", _tenDoiTac);
            else
                cm.Parameters.AddWithValue("@TenDoiTac", DBNull.Value);
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

            ExecuteDelete(tr, new Criteria(_maPhieu));
            MarkNew();
        }
        #endregion //Data Access - Delete

        /// <summary>
        /// Tìm số phiếu mới = tổng số phiếu hiện có + 1
        /// </summary>
        /// <returns></returns>
        public string SoPhieuMoi(int Nam, int LoaiDeNghi)
        {
            string SoCTMax = string.Empty;
            string strChuoi = string.Empty;
            int iSoDeNghi = 0;
            string strMaQLUser = Security.CurrentUser.Info.MaQLUser;
            string strMaBoPhan = BoPhan.GetBoPhan(ERP_Library.Security.CurrentUser.Info.MaBoPhan).MaBoPhanQL;

            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                SqlCommand cm = cn.CreateCommand();
                cm.CommandType = CommandType.Text;
                cm.CommandText = "Select Max(So) From tblDeNghiChuyenKhoan_ChungTuNgoai Where UserID = @UserID And YEAR(Ngay) = @Nam and Ngay >= '06/04/2012'"; //Chỉ lấy các chứng từ sau ngày 01/06/2012
                cm.Parameters.AddWithValue("@UserID", Security.CurrentUser.Info.UserID);
                cm.Parameters.AddWithValue("@Nam", Nam);
                SoCTMax = Convert.ToString(cm.ExecuteScalar());
                cn.Close();
            }

            if (SoCTMax != string.Empty && SoCTMax != null)
            {
                //Lấy 4 số cuối kiểm tra xem có phải là năm hiện tại hay không(Cái này bắt luôn cho cả việc nếu nó không theo cấu trúc số ĐN mới)
                strChuoi = SoCTMax.Substring(SoCTMax.Length - 4, 4);
                if (strChuoi.Equals(Nam.ToString()))
                {
                    strChuoi = SoCTMax.Substring(0, 4);
                    iSoDeNghi = Convert.ToInt32(strChuoi) + 1;
                }
            }
            else
            {
                iSoDeNghi++;
            }

            string Chuoi = string.Empty;
            if(LoaiDeNghi == 1)
                Chuoi = "CMTL";
            else
                Chuoi = "CĐ";

            if (iSoDeNghi.ToString().Length == 1)
                return "000" + iSoDeNghi.ToString() + Chuoi + "/" + strMaQLUser + "/" + strMaBoPhan + "/" + Nam.ToString();
            else if (iSoDeNghi.ToString().Length == 2)
                return "00" + iSoDeNghi.ToString() + Chuoi + "/" + strMaQLUser + "/" + strMaBoPhan + "/" + Nam.ToString();
            else if (iSoDeNghi.ToString().Length == 3)
                return "0" + iSoDeNghi.ToString() + Chuoi + "/" + strMaQLUser + "/" + strMaBoPhan + "/" + Nam.ToString();
            else
                return iSoDeNghi.ToString() + Chuoi + "/" + strMaQLUser + "/" + strMaBoPhan + "/" + Nam.ToString();
        }

        #endregion //Data Access
    }
}
