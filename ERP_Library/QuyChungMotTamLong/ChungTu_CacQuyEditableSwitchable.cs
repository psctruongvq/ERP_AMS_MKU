
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;
using ERP_Library.ThanhToan;

namespace ERP_Library
{
    [Serializable()]
    public class ChungTu_CacLoaiQuy : Csla.BusinessBase<ChungTu_CacLoaiQuy>
    {
        #region Business Properties and Methods

        //declare members
        private long _machungtuCacquy = 0;
        private string _soChungTu = string.Empty;
        private DateTime _ngayLap = DateTime.Today;
        private DateTime _ngayHeThong = DateTime.Today;
        private int _userID = 0;
        private decimal _soTien = 0;
        private decimal _tyGia = 1;
        private int _loaiTien = 1;
        private decimal _thanhTien = 0;
        private string _dienGiai = string.Empty;
        private int _maLoaiQuy = 1;
        private long _maDoiTuong = 0;
        private int _maLoaiChungTu = 3;
        private string _tenDoiTac = string.Empty;
        private string _diaChi = string.Empty;
        private int _loaiThuChi = 0;      

        //Bổ sung cho form check chọn thu chi (Thành : 13/08/2012)
        private bool _isThuChi = false;
        private DateTime? _ngayThuChi = null;
        private string _nguoiThuChi = string.Empty;
        private int _maNguoiThuChi = 0;
        private int _loaiChungTuDiKem = 0;

        private bool _ToChuc = false;


        #region BoSung
 //        ,lquy.TenCacQuy AS LoaiQuy
 //,ltc.TenLoaiThuChi AS ChuongTrinh
 //,bt.SoTien AS SoTienButToan
 //,tkN.SoHieuTK AS TKNo
 //,tkC.SoHieuTK AS TkCo
        private string _LoaiQuy=string.Empty;
        private string _ChuongTrinh = string.Empty;
        private decimal _SoTienButToan = 0;
        private string _TKNo = string.Empty;
        private string _TKCo = string.Empty;
        #endregion BoSung


        //declare child member(s)
        private ButToan_CacQuyList _butToanQuyList = ButToan_CacQuyList.NewButToan_CacQuyList();
        private ChungTu_DeNghiChuyenKhoanNgoaiList _chungTu_DeNghiNgoaiList = ChungTu_DeNghiChuyenKhoanNgoaiList.NewChungTu_DeNghiChuyenKhoanNgoaiList();
        private ChungTu_GiayBaoCo_CacQuyList _chungTu_GiayBCList = ChungTu_GiayBaoCo_CacQuyList.NewChungTu_GiayBaoCo_CacQuyList();
        private ChungTu_GiayRutTien_CacQuyList _chungTu_GiayRTList = ChungTu_GiayRutTien_CacQuyList.NewChungTu_GiayRutTien_CacQuyList();

        [System.ComponentModel.DataObjectField(true, true)]
        public long MachungtuCacquy
        {
            get
            {
                CanReadProperty("MachungtuCacquy", true);
                return _machungtuCacquy;
            }
        }

        public bool IsThuChi
        {
            get
            {
                CanReadProperty("IsThuChi", true);
                return _isThuChi;
            }
            set
            {
                CanWriteProperty("IsThuChi", true);
                if (!_isThuChi.Equals(value))
                {
                    _isThuChi = value;
                    if (_isThuChi)
                    {
                        _ngayThuChi = DateTime.Today;
                        _maNguoiThuChi = ERP_Library.Security.CurrentUser.Info.UserID;
                        _nguoiThuChi = ERP_Library.Security.CurrentUser.Info.TenDangNhap;
                    }
                    else
                    {
                        _ngayThuChi = null;
                        _maNguoiThuChi = 0;
                        _nguoiThuChi = "";
                    }
                    PropertyHasChanged("IsThuChi");
                }
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

        public string DiaChi
        {
            get
            {
                CanReadProperty("DiaChi", true);
                return _diaChi;
            }
            set
            {
                CanWriteProperty("DiaChi", true);
                if (value == null) value = string.Empty;
                if (!_diaChi.Equals(value))
                {
                    _diaChi = value;
                    PropertyHasChanged("DiaChi");
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

        public int MaLoaiThuChi
        {
            get
            {
                CanReadProperty("MaLoaiThuChi", true);
                return _loaiThuChi;
            }
            set
            {
                CanWriteProperty("MaLoaiThuChi", true);
                if (!_loaiThuChi.Equals(value))
                {
                    _loaiThuChi = value;
                    PropertyHasChanged("MaLoaiThuChi");
                }
            }
        }

        #region BS
        public bool ToChuc
        {
            get
            {
                CanReadProperty("ToChuc", true);
                return _ToChuc;
            }
            set
            {
                CanWriteProperty("ToChuc", true);
                if (!_ToChuc.Equals(value))
                {
                    _ToChuc = value;
                    PropertyHasChanged("ToChuc");
                }
            }
        }
        #endregion//BS

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
                    ThanhTien = _tyGia * _soTien;
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
                    ThanhTien = _tyGia * _soTien;
                    PropertyHasChanged("TyGia");
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

        public decimal ThanhTien
        {
            get
            {
                CanReadProperty("ThanhTien", true);
                return _thanhTien;
            }
            set
            {
                CanWriteProperty("ThanhTien", true);
                if (!_thanhTien.Equals(value))
                {
                    _thanhTien = value;
                    PropertyHasChanged("ThanhTien");
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

        public int MaLoaiQuy
        {
            get
            {
                CanReadProperty("MaLoaiQuy", true);
                return _maLoaiQuy;
            }
            set
            {
                CanWriteProperty("MaLoaiQuy", true);
                if (!_maLoaiQuy.Equals(value))
                {
                    _maLoaiQuy = value;
                    PropertyHasChanged("MaLoaiQuy");
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

        public int MaLoaiChungTu
        {
            get
            {
                CanReadProperty("MaLoaiChungTu", true);
                return _maLoaiChungTu;
            }
            set
            {
                CanWriteProperty("MaLoaiChungTu", true);
                if (!_maLoaiChungTu.Equals(value))
                {
                    _maLoaiChungTu = value;
                    PropertyHasChanged("MaLoaiChungTu");
                }
            }
        }

        public DateTime? NgayThuChi
        {
            get
            {
                CanReadProperty("NgayThuChi", true);
                return _ngayThuChi;
            }
            set
            {
                CanWriteProperty("NgayThuChi", true);
                if (!_ngayThuChi.Equals(value))
                {
                    _ngayThuChi = value;
                    PropertyHasChanged("NgayThuChi");
                }
            }
        }

        public string NguoiThuChi
        {
            get
            {
                CanReadProperty("NguoiThuChi", true);
                return _nguoiThuChi;
            }
            set
            {
                CanWriteProperty("NguoiThuChi", true);
                if (value == null) value = string.Empty;
                if (!_nguoiThuChi.Equals(value))
                {
                    _nguoiThuChi = value;
                    PropertyHasChanged("NguoiThuChi");
                }
            }
        }

        public int MaNguoiThuChi
        {
            get
            {
                CanReadProperty("MaNguoiThuChi", true);
                return _maNguoiThuChi;
            }
        }

        public int LoaiChungTuDiKem
        {
            get
            {
                CanReadProperty("LoaiChungTuDiKem", true);
                return _loaiChungTuDiKem;
            }
            set
            {
                CanWriteProperty("LoaiChungTuDiKem", true);
                if (!_loaiChungTuDiKem.Equals(value))
                {
                    _loaiChungTuDiKem = value;
                    PropertyHasChanged("LoaiChungTuDiKem");
                }
            }
        }

        #region BoSung
        public string LoaiQuy
        {
            get
            {
                CanReadProperty("LoaiQuy", true);
                return _LoaiQuy;
            }
        }
        public string ChuongTrinh
        {
            get
            {
                CanReadProperty("ChuongTrinh", true);
                return _ChuongTrinh;
            }
        }
        public decimal SoTienButToan
        {
            get
            {
                CanReadProperty("SoTienButToan", true);
                return _SoTienButToan;
            }
        }
        public string TKNo
        {
            get
            {
                CanReadProperty("TKNo", true);
                return _TKNo;
            }
        }
        public string TKCo
        {
            get
            {
                CanReadProperty("TKCo", true);
                return _TKCo;
            }
        }

        #endregion//BoSung


        public ButToan_CacQuyList ButToanQuyList
        {
            get
            {
                CanReadProperty("ButToanQuyList", true);
                return _butToanQuyList;
            }
        }

        public ChungTu_DeNghiChuyenKhoanNgoaiList ChungTu_DeNghiNgoaiList
        {
            get
            {
                CanReadProperty("ChungTu_DeNghiNgoaiList", true);
                return _chungTu_DeNghiNgoaiList;
            }
        }

        public ChungTu_GiayBaoCo_CacQuyList ChungTu_GiayBCList
        {
            get
            {
                CanReadProperty("ChungTu_GiayBCList", true);
                return _chungTu_GiayBCList;
            }
        }

        public ChungTu_GiayRutTien_CacQuyList ChungTu_GiayRTList
        {
            get
            {
                CanReadProperty("ChungTu_GiayRTList", true);
                return _chungTu_GiayRTList;
            }
        }

        public TamUng_QC1TLList _TamUng_QC1TLList = TamUng_QC1TLList.NewTamUng_QC1TLList();

        public TamUng_QC1TLList TamUng_QC1TLList
        {
            get
            {
                CanReadProperty(true);
                return _TamUng_QC1TLList;
            }
            set
            {
                CanWriteProperty(true);
                if (!_TamUng_QC1TLList.Equals(value))
                {
                    _TamUng_QC1TLList = value;
                    PropertyHasChanged();
                }
            }
        }

        public override bool IsValid
        {
            get { return base.IsValid && _butToanQuyList.IsValid && _chungTu_DeNghiNgoaiList.IsValid && _chungTu_GiayBCList.IsValid && _chungTu_GiayRTList.IsValid && _TamUng_QC1TLList.IsValid; }
        }

        public override bool IsDirty
        {
            get { return base.IsDirty || _butToanQuyList.IsDirty || _chungTu_DeNghiNgoaiList.IsDirty || _chungTu_GiayBCList.IsDirty || _chungTu_GiayRTList.IsDirty || _TamUng_QC1TLList.IsDirty; }
        }

        protected override object GetIdValue()
        {
            return _machungtuCacquy;
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
            ValidationRules.AddRule(CommonRules.StringRequired, "SoChungTu");
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("SoChungTu", 50));
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
            //TODO: Define authorization rules in ChungTu_CacLoaiQuy
            //AuthorizationRules.AllowRead("DNChuyenKhoanList", "ChungTu_CacLoaiQuyReadGroup");
            //AuthorizationRules.AllowRead("MachungtuCacquy", "ChungTu_CacLoaiQuyReadGroup");
            //AuthorizationRules.AllowRead("SoChungTu", "ChungTu_CacLoaiQuyReadGroup");
            //AuthorizationRules.AllowRead("NgayLap", "ChungTu_CacLoaiQuyReadGroup");
            //AuthorizationRules.AllowRead("NgayLapString", "ChungTu_CacLoaiQuyReadGroup");
            //AuthorizationRules.AllowRead("NgayHeThong", "ChungTu_CacLoaiQuyReadGroup");
            //AuthorizationRules.AllowRead("NgayHeThongString", "ChungTu_CacLoaiQuyReadGroup");
            //AuthorizationRules.AllowRead("UserID", "ChungTu_CacLoaiQuyReadGroup");
            //AuthorizationRules.AllowRead("SoTien", "ChungTu_CacLoaiQuyReadGroup");
            //AuthorizationRules.AllowRead("TyGia", "ChungTu_CacLoaiQuyReadGroup");
            //AuthorizationRules.AllowRead("LoaiTien", "ChungTu_CacLoaiQuyReadGroup");
            //AuthorizationRules.AllowRead("ThanhTien", "ChungTu_CacLoaiQuyReadGroup");
            //AuthorizationRules.AllowRead("DienGiai", "ChungTu_CacLoaiQuyReadGroup");
            //AuthorizationRules.AllowRead("MaLoaiQuy", "ChungTu_CacLoaiQuyReadGroup");
            //AuthorizationRules.AllowRead("MaDoiTuong", "ChungTu_CacLoaiQuyReadGroup");
            //AuthorizationRules.AllowRead("MaLoaiChungTu", "ChungTu_CacLoaiQuyReadGroup");

            //AuthorizationRules.AllowWrite("SoChungTu", "ChungTu_CacLoaiQuyWriteGroup");
            //AuthorizationRules.AllowWrite("NgayLapString", "ChungTu_CacLoaiQuyWriteGroup");
            //AuthorizationRules.AllowWrite("NgayHeThongString", "ChungTu_CacLoaiQuyWriteGroup");
            //AuthorizationRules.AllowWrite("UserID", "ChungTu_CacLoaiQuyWriteGroup");
            //AuthorizationRules.AllowWrite("SoTien", "ChungTu_CacLoaiQuyWriteGroup");
            //AuthorizationRules.AllowWrite("TyGia", "ChungTu_CacLoaiQuyWriteGroup");
            //AuthorizationRules.AllowWrite("LoaiTien", "ChungTu_CacLoaiQuyWriteGroup");
            //AuthorizationRules.AllowWrite("ThanhTien", "ChungTu_CacLoaiQuyWriteGroup");
            //AuthorizationRules.AllowWrite("DienGiai", "ChungTu_CacLoaiQuyWriteGroup");
            //AuthorizationRules.AllowWrite("MaLoaiQuy", "ChungTu_CacLoaiQuyWriteGroup");
            //AuthorizationRules.AllowWrite("MaDoiTuong", "ChungTu_CacLoaiQuyWriteGroup");
            //AuthorizationRules.AllowWrite("MaLoaiChungTu", "ChungTu_CacLoaiQuyWriteGroup");
        }


        public static bool CanGetObject()
        {
            //TODO: Define CanGetObject permission in ChungTu_CacLoaiQuy
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("ChungTu_CacLoaiQuyViewGroup"))
            //	return true;
            //return false;
        }

        public static bool CanAddObject()
        {
            //TODO: Define CanAddObject permission in ChungTu_CacLoaiQuy
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("ChungTu_CacLoaiQuyAddGroup"))
            //	return true;
            //return false;
        }

        public static bool CanEditObject()
        {
            //TODO: Define CanEditObject permission in ChungTu_CacLoaiQuy
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("ChungTu_CacLoaiQuyEditGroup"))
            //	return true;
            //return false;
        }

        public static bool CanDeleteObject()
        {
            //TODO: Define CanDeleteObject permission in ChungTu_CacLoaiQuy
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("ChungTu_CacLoaiQuyDeleteGroup"))
            //	return true;
            //return false;
        }
        #endregion //Authorization Rules

        #region Factory Methods
        private ChungTu_CacLoaiQuy()
        { 
            /* require use of factory method */
            _butToanQuyList = ButToan_CacQuyList.GetButToan_CacQuyList(_machungtuCacquy);
        }

        public static ChungTu_CacLoaiQuy NewChungTu_CacLoaiQuy()
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a ChungTu_CacLoaiQuy");
            return DataPortal.Create<ChungTu_CacLoaiQuy>();
        }

        public static ChungTu_CacLoaiQuy GetChungTu_CacLoaiQuy(long machungtuCacquy)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a ChungTu_CacLoaiQuy");
            return DataPortal.Fetch<ChungTu_CacLoaiQuy>(new Criteria(machungtuCacquy));
        }

        public static void DeleteChungTu_CacLoaiQuy(long machungtuCacquy)
        {
            if (!CanDeleteObject())
                throw new System.Security.SecurityException("User not authorized to remove a ChungTu_CacLoaiQuy");
            DataPortal.Delete(new Criteria(machungtuCacquy));
        }

        public static void DeleteChungTu_CacLoaiQuy(ChungTu_CacLoaiQuy _ct)
        {
            SqlTransaction tr;
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                tr = cn.BeginTransaction();
                try
                {
                   

                    //
                    _ct.ButToanQuyList.Clear();
                    _ct.ButToanQuyList.Update(tr,_ct);
                    _ct.ChungTu_DeNghiNgoaiList.Clear();
                    _ct.ChungTu_DeNghiNgoaiList.Update(tr, _ct);
                    _ct.ChungTu_GiayBCList.Clear();
                    _ct.ChungTu_GiayBCList.Update(tr, _ct);
                    _ct.ChungTu_GiayRTList.Clear();
                    _ct.ChungTu_GiayRTList.Update(tr, _ct);

                    _ct.TamUng_QC1TLList.DataPortal_Delete(tr);
                    //

                    using (SqlCommand cm = tr.Connection.CreateCommand())
                    {
                        cm.Transaction = tr;
                        cm.CommandType = CommandType.StoredProcedure;
                        cm.CommandText = "spd_DeletetblChungTu_CacQuy";

                        cm.Parameters.AddWithValue("@MaChungTu_CacQuy", _ct.MachungtuCacquy);

                        cm.ExecuteNonQuery();
                    }//using
                    tr.Commit();
                }
                catch (SqlException ex)
                {
                    tr.Rollback();
                    throw ex;
                }
            }
        }

        public override ChungTu_CacLoaiQuy Save()
        {
            if (IsDeleted && !CanDeleteObject())
                throw new System.Security.SecurityException("User not authorized to remove a ChungTu_CacLoaiQuy");
            else if (IsNew && !CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a ChungTu_CacLoaiQuy");
            else if (!CanEditObject())
                throw new System.Security.SecurityException("User not authorized to update a ChungTu_CacLoaiQuy");

            return base.Save();
        }

        #endregion //Factory Methods

        #region Child Factory Methods
        internal static ChungTu_CacLoaiQuy NewChungTu_CacLoaiQuyChild()
        {
            ChungTu_CacLoaiQuy child = new ChungTu_CacLoaiQuy();
            child.ValidationRules.CheckRules();
            child.MarkAsChild();
            return child;
        }

        internal static ChungTu_CacLoaiQuy GetChungTu_CacLoaiQuy(SafeDataReader dr)
        {
            ChungTu_CacLoaiQuy child = new ChungTu_CacLoaiQuy();
            child.MarkAsChild();
            child.Fetch(dr);
            return child;
        }

        internal static ChungTu_CacLoaiQuy GetChungTu_CacLoaiQuy_ThuChi(SafeDataReader dr)
        {
            ChungTu_CacLoaiQuy child = new ChungTu_CacLoaiQuy();
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
            public long MachungtuCacquy;

            public Criteria(long machungtuCacquy)
            {
                this.MachungtuCacquy = machungtuCacquy;
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
                cm.CommandText = "spd_SelecttblChungTu_CacQuy";

                cm.Parameters.AddWithValue("@MaChungTu_CacQuy", criteria.MachungtuCacquy);

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
            DataPortal_Delete(new Criteria(_machungtuCacquy));
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
                cm.CommandText = "spd_DeletetblChungTu_CacQuy";

                cm.Parameters.AddWithValue("@MaChungTu_CacQuy", criteria.MachungtuCacquy);

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

        private void Fetch_New(SafeDataReader dr)
        {
            FetchObject_New(dr);
            MarkOld();
            ValidationRules.CheckRules();

            //load child object(s)
            FetchChildren(dr);
        }

        private void FetchObject(SafeDataReader dr)
        {
            _machungtuCacquy = dr.GetInt64("MaChungTu_CacQuy");
            _soChungTu = dr.GetString("SoChungTu");
            _ngayLap = dr.GetDateTime("NgayLap");
            _ngayHeThong = dr.GetDateTime("NgayHeThong");
            _userID = dr.GetInt32("UserID");
            _soTien = dr.GetDecimal("SoTien");
            _tyGia = dr.GetDecimal("TyGia");
            _loaiTien = dr.GetInt32("LoaiTien");
            _thanhTien = dr.GetDecimal("ThanhTien");
            _dienGiai = dr.GetString("DienGiai");
            _maLoaiQuy = dr.GetInt32("MaLoaiQuy");
            _maDoiTuong = dr.GetInt64("MaDoiTuong");
            _maLoaiChungTu = dr.GetInt32("MaLoaiChungTu");
            _tenDoiTac = dr.GetString("TenDoiTac");
            _diaChi = dr.GetString("DiaChi");
            _loaiThuChi = dr.GetInt32("MaLoaiThuChi");
            _loaiChungTuDiKem = dr.GetInt32("LoaiChungTu");

            _ToChuc = dr.GetBoolean("ToChuc");//BS

            #region MyRegion
            _LoaiQuy = dr.GetString("LoaiQuy");
            _ChuongTrinh = dr.GetString("ChuongTrinh");
            _SoTienButToan = dr.GetDecimal("SoTienButToan");
            _TKNo = dr.GetString("TKNo");
            _TKCo = dr.GetString("TKCo"); 
            #endregion
        }

        private void FetchObject_New(SafeDataReader dr)
        {
            _machungtuCacquy = dr.GetInt64("MaChungTu_CacQuy");
            _soChungTu = dr.GetString("SoChungTu");
            _ngayLap = dr.GetDateTime("NgayLap");
            _ngayHeThong = dr.GetDateTime("NgayHeThong");
            _userID = dr.GetInt32("UserID");
            _soTien = dr.GetDecimal("SoTien");
            _tyGia = dr.GetDecimal("TyGia");
            _loaiTien = dr.GetInt32("LoaiTien");
            _thanhTien = dr.GetDecimal("ThanhTien");
            _dienGiai = dr.GetString("DienGiai");
            _maLoaiQuy = dr.GetInt32("MaLoaiQuy");
            _maDoiTuong = dr.GetInt64("MaDoiTuong");
            _maLoaiChungTu = dr.GetInt32("MaLoaiChungTu");
            _tenDoiTac = dr.GetString("TenDoiTac");
            _diaChi = dr.GetString("DiaChi");
            _loaiThuChi = dr.GetInt32("MaLoaiThuChi");
            _ToChuc = dr.GetBoolean("ToChuc");//BS
            _isThuChi = dr.GetBoolean("IsThuChi");
            _ngayThuChi = dr.GetDateTime("NgayThuChi");
            if (_ngayThuChi.Value == DateTime.MinValue)
            {
                _ngayThuChi = null;
            }
            _nguoiThuChi = dr.GetString("NguoiThuChi");
            _maNguoiThuChi = dr.GetInt32("MaNguoiThuChi");
            _loaiChungTuDiKem = dr.GetInt32("LoaiChungTu");
        }

        private void FetchChildren(SafeDataReader dr)
        {
            _butToanQuyList = ButToan_CacQuyList.GetButToan_CacQuyList(_machungtuCacquy);
            _chungTu_DeNghiNgoaiList = ChungTu_DeNghiChuyenKhoanNgoaiList.GetChungTu_DeNghiChuyenKhoanNgoaiList(_machungtuCacquy);
            _chungTu_GiayBCList = ChungTu_GiayBaoCo_CacQuyList.GetChungTu_GiayBaoCo_CacQuyList(_machungtuCacquy);
            _chungTu_GiayRTList = ChungTu_GiayRutTien_CacQuyList.GetChungTu_GiayBaoCo_CacQuyList_ByMaChungTu(_machungtuCacquy);

            _TamUng_QC1TLList = ERP_Library.TamUng_QC1TLList.GetTamUng_QC1TLList(_machungtuCacquy);
        }
        #endregion //Data Access - Fetch

        #region Data Access - Insert
        internal void Insert(SqlTransaction tr, ChungTu_CacLoaiQuyList parent)
        {
            if (!IsDirty) return;

            ExecuteInsert(tr, parent);
            MarkOld();

            //update child object(s)
            UpdateChildren(tr);
        }

        private void ExecuteInsert(SqlTransaction tr, ChungTu_CacLoaiQuyList parent)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_InserttblChungTu_CacQuy";

                AddInsertParameters(cm, parent);

                cm.ExecuteNonQuery();

                _machungtuCacquy = (long)cm.Parameters["@MaChungTu_CacQuy"].Value;
            }//using
        }

        private void AddInsertParameters(SqlCommand cm, ChungTu_CacLoaiQuyList parent)
        {
            //TODO: if parent use identity key, fix fk member with value from parent
            cm.Parameters.AddWithValue("@SoChungTu", _soChungTu);
            cm.Parameters.AddWithValue("@NgayLap", _ngayLap);
            cm.Parameters.AddWithValue("@NgayHeThong", DateTime.Now);
            cm.Parameters.AddWithValue("@UserID", Security.CurrentUser.Info.UserID);
            cm.Parameters.AddWithValue("@SoTien", _soTien);
            cm.Parameters.AddWithValue("@TyGia", _tyGia);
            cm.Parameters.AddWithValue("@LoaiTien", _loaiTien);
            cm.Parameters.AddWithValue("@ThanhTien", _thanhTien);
            if (_dienGiai.Length > 0)
                cm.Parameters.AddWithValue("@DienGiai", _dienGiai);
            else
                cm.Parameters.AddWithValue("@DienGiai", DBNull.Value);
            cm.Parameters.AddWithValue("@MaLoaiQuy", _maLoaiQuy);
            if (_maDoiTuong != 0)
                cm.Parameters.AddWithValue("@MaDoiTuong", _maDoiTuong);
            else
                cm.Parameters.AddWithValue("@MaDoiTuong", DBNull.Value);
            if (_maLoaiChungTu != 0)
                cm.Parameters.AddWithValue("@MaLoaiChungTu", _maLoaiChungTu);
            else
                cm.Parameters.AddWithValue("@MaLoaiChungTu", DBNull.Value);
            cm.Parameters.AddWithValue("@TenDoiTac", _tenDoiTac);
            cm.Parameters.AddWithValue("@DiaChi", _diaChi);
            cm.Parameters.AddWithValue("@MaLoaiThuChi", _loaiThuChi);
            if (_ToChuc)
                cm.Parameters.AddWithValue("@ToChuc", _ToChuc);
            else
                cm.Parameters.AddWithValue("@ToChuc", DBNull.Value);


            cm.Parameters.AddWithValue("@MaChungTu_CacQuy", _machungtuCacquy);
            cm.Parameters["@MaChungTu_CacQuy"].Direction = ParameterDirection.Output;
        }
        #endregion //Data Access - Insert

        #region Data Access - Update
        internal void Update(SqlTransaction tr, ChungTu_CacLoaiQuyList parent)
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

        private void ExecuteUpdate(SqlTransaction tr, ChungTu_CacLoaiQuyList parent)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_UpdatetblChungTu_CacQuy";

                AddUpdateParameters(cm, parent);

                cm.ExecuteNonQuery();

            }//using
        }

        private void AddUpdateParameters(SqlCommand cm, ChungTu_CacLoaiQuyList parent)
        {
            cm.Parameters.AddWithValue("@MaChungTu_CacQuy", _machungtuCacquy);
            cm.Parameters.AddWithValue("@SoChungTu", _soChungTu);
            cm.Parameters.AddWithValue("@NgayLap", _ngayLap);
            cm.Parameters.AddWithValue("@NgayHeThong", DateTime.Now);
            cm.Parameters.AddWithValue("@UserID", Security.CurrentUser.Info.UserID);
            cm.Parameters.AddWithValue("@SoTien", _soTien);
            cm.Parameters.AddWithValue("@TyGia", _tyGia);
            cm.Parameters.AddWithValue("@LoaiTien", _loaiTien);
            cm.Parameters.AddWithValue("@ThanhTien", _thanhTien);
            if (_dienGiai.Length > 0)
                cm.Parameters.AddWithValue("@DienGiai", _dienGiai);
            else
                cm.Parameters.AddWithValue("@DienGiai", DBNull.Value);
            cm.Parameters.AddWithValue("@MaLoaiQuy", _maLoaiQuy);
            if (_maDoiTuong != 0)
                cm.Parameters.AddWithValue("@MaDoiTuong", _maDoiTuong);
            else
                cm.Parameters.AddWithValue("@MaDoiTuong", DBNull.Value);
            if (_maLoaiChungTu != 0)
                cm.Parameters.AddWithValue("@MaLoaiChungTu", _maLoaiChungTu);
            else
                cm.Parameters.AddWithValue("@MaLoaiChungTu", DBNull.Value);

            if (_loaiThuChi != 0)
                cm.Parameters.AddWithValue("@MaLoaiThuChi", _loaiThuChi);
            else
                cm.Parameters.AddWithValue("@MaLoaiThuChi", DBNull.Value);

            cm.Parameters.AddWithValue("@TenDoiTac", _tenDoiTac);
            cm.Parameters.AddWithValue("@DiaChi", _diaChi);

            if (_ToChuc)
                cm.Parameters.AddWithValue("@ToChuc", _ToChuc);
            else
                cm.Parameters.AddWithValue("@ToChuc", DBNull.Value);
        }

        private void UpdateChildren(SqlTransaction tr)
        {
            _butToanQuyList.Update(tr, this);
            _chungTu_DeNghiNgoaiList.Update(tr, this);
            _chungTu_GiayBCList.Update(tr, this);
            _chungTu_GiayRTList.Update(tr, this);

            int loaiThuChi = 0;
            for (int i = 0; i < _butToanQuyList.Count; i++)
            {
                if (HeThongTaiKhoan1.GetHeThongTaiKhoan1(_butToanQuyList[i].NoTaiKhoan).SoHieuTK.StartsWith("312"))
                    loaiThuChi = 2;
                if (HeThongTaiKhoan1.GetHeThongTaiKhoan1(_butToanQuyList[i].CoTaiKhoan).SoHieuTK.StartsWith("312"))
                    loaiThuChi = 3;
            }
            foreach (TamUng_QC1TL tu in _TamUng_QC1TLList)
            {
                tu.NgayLap = this.NgayLap;
                tu.LoaiThuChi = loaiThuChi;
            }
            _TamUng_QC1TLList.DataPortal_Update(tr, _machungtuCacquy, _soChungTu);


        }
        #endregion //Data Access - Update

        #region Data Access - Delete
        internal void DeleteSelf(SqlTransaction tr)
        {
            if (!IsDirty) return;
            if (IsNew) return;

            _butToanQuyList.Clear();
            _butToanQuyList.Update(tr, this);
            _chungTu_DeNghiNgoaiList.Clear();
            _chungTu_DeNghiNgoaiList.Update(tr, this);
            _chungTu_GiayBCList.Clear();
            _chungTu_GiayBCList.Update(tr, this);
            _chungTu_GiayRTList.Clear();
            _chungTu_GiayRTList.Update(tr, this);

            
            _TamUng_QC1TLList.DataPortal_Delete(tr,this._machungtuCacquy);

            ExecuteDelete(tr, new Criteria(_machungtuCacquy));
            MarkNew();
        }
        #endregion //Data Access - Delete

        public static bool KiemTraSoChungTu(string SoChungTu, long MaChungTu_CacQuy)
        {
            bool bFound = false;
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                SqlCommand cm = cn.CreateCommand();
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_KiemTraSoChungTu_CacQuy";
                cm.Parameters.AddWithValue("@MaChungTu_CacQuy", MaChungTu_CacQuy);
                cm.Parameters.AddWithValue("@SoChungTu", SoChungTu);
                int iRows = Convert.ToInt32(cm.ExecuteScalar());
                if (iRows > 0)
                    bFound = true;
                cn.Close();

            }//using

            return bFound;
        }
        #endregion //Data Access

        public static string LaySoChungTuMax(int maLoaiChungTu, int Nam)
        {
            string strSoMoi = string.Empty;
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                SqlCommand cm = cn.CreateCommand();

                #region Old
                //cm.CommandType = System.Data.CommandType.Text;
                //cm.CommandText = "select (isnull(Max(Left(SoChungTu,4)),0)+1) as SoCTMax from tblChungTu_CacQuy where MaLoaiChungTu=@MaLoaiChungTu and UserID=@UserId and year(NgayLap)=@Nam";
                //cm.Parameters.AddWithValue("@MaLoaiChungTu", maLoaiChungTu);
                //cm.Parameters.AddWithValue("@UserID", ERP_Library.Security.CurrentUser.Info.UserID);
                //cm.Parameters.AddWithValue("@Nam", Nam);
                //strSoMoi = Convert.ToString(cm.ExecuteScalar());
                #endregion//Old
                #region New
                cm.CommandType = System.Data.CommandType.StoredProcedure;
                cm.CommandText = "spd_SetNumericalOrderSoChungTu_QC1TL";
                cm.Parameters.AddWithValue("@MaLoaiChungTu", maLoaiChungTu);
                cm.Parameters.AddWithValue("@UserID", ERP_Library.Security.CurrentUser.Info.UserID);
                cm.Parameters.AddWithValue("@Nam", Nam);
                SqlParameter prmGiaTriTraVe = new SqlParameter("@GiaTriTraVe", SqlDbType.VarChar, 100);
                prmGiaTriTraVe.Direction = ParameterDirection.Output;
                cm.Parameters.Add(prmGiaTriTraVe);
                cm.ExecuteNonQuery();
                if (prmGiaTriTraVe.Value != null)
                    strSoMoi = (string)prmGiaTriTraVe.Value;
                #endregion//New
                cn.Close();
            }
            int len = strSoMoi.Length;

            string nam = DateTime.Today.Year.ToString();
            while (len < 4)
            {
                strSoMoi = "0" + strSoMoi;
                len = strSoMoi.Length;
            }
            if (maLoaiChungTu == 2)
                strSoMoi = strSoMoi + "T/CMTL/" + (BoPhan.GetBoPhan(ERP_Library.Security.CurrentUser.Info.MaBoPhan)).MaBoPhanQL.Substring(0, 4);
            else if (maLoaiChungTu == 3)
                strSoMoi = strSoMoi + "C/CMTL/" + (BoPhan.GetBoPhan(ERP_Library.Security.CurrentUser.Info.MaBoPhan)).MaBoPhanQL.Substring(0, 4);
            else if (maLoaiChungTu == 16)
                strSoMoi = strSoMoi + "K/CMTL/" + (BoPhan.GetBoPhan(ERP_Library.Security.CurrentUser.Info.MaBoPhan)).MaBoPhanQL.Substring(0, 4);
            //return strSoMoi + "/" + DateTime.Today.Year.ToString();
            return strSoMoi + "/" + Nam.ToString();
        }

        public void Update_ThuQuy(long MaChungTu_CacQuy, DateTime? NgayThuChi, int NguoiThuChi, bool IsThuChi)
        {
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                SqlCommand cm = cn.CreateCommand();
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_UpdatetblChungTu_CacQuy_ThuQuy";
                cm.Parameters.AddWithValue("@MaChungTu_CacQuy", MaChungTu_CacQuy);
                if(NgayThuChi != null && NgayThuChi != DateTime.MinValue)
                    cm.Parameters.AddWithValue("@NgayThuChi", NgayThuChi);
                else
                    cm.Parameters.AddWithValue("@NgayThuChi", DBNull.Value);
                if (NguoiThuChi != 0)
                    cm.Parameters.AddWithValue("@NguoiThuChi", NguoiThuChi);
                else
                    cm.Parameters.AddWithValue("@NguoiThuChi", DBNull.Value);
                cm.Parameters.AddWithValue("@isThuChi", IsThuChi);
                cm.ExecuteNonQuery();

                cn.Close();
            }
        }

        public static void CapNhapLaiSoChungTuTangLienTiepTuNgay(int maLoaiChungTu, DateTime tungay)
        {
            if (BoPhan.GetBoPhan(ERP_Library.Security.CurrentUser.Info.MaBoPhan).MaBoPhanQL != "DV02")//Không là Trung Tâm Tin Tức
            {
                using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
                {
                    cn.Open();
                    using (SqlCommand cm = cn.CreateCommand())
                    {
                        cm.CommandType = CommandType.StoredProcedure;
                        cm.CommandText = "spd_CapNhatSoChungTuTangLienTiepTuNgay_QC1TL";
                        cm.Parameters.AddWithValue("@MaLoaiChungTu", maLoaiChungTu);
                        cm.Parameters.AddWithValue("@TuNgay", tungay);
                        cm.Parameters.AddWithValue("@MaNguoiLap", ERP_Library.Security.CurrentUser.Info.UserID);
                        cm.ExecuteNonQuery();
                    }
                }
            }
        }

    }
}
