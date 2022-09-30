using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{
    [Serializable()]
    public class InBienLaiNhanVienTuQuyetToan : Csla.BusinessBase<InBienLaiNhanVienTuQuyetToan>
    {
        #region Business Properties and Methods

        //declare members
        private long _id = 0;
        private long _maNhanVien = 0;
        private int _maKyQuyetToan = 0;
        private int _nam = 0;
        private int _thang = 0;
        private int _maBoPhan = 0;
        private string _tenNhanVien = string.Empty;
        private string _mst = string.Empty;
        private string _cmnd = string.Empty;
        private decimal _soTien = 0;
        private decimal _phanTramThue = 0;
        private decimal _tienThue = 0;
        private decimal _soTienConLai = 0;
        private int _maUNC = 0;
        private SmartDate _ngayLap = new SmartDate(false);
        private int _nguoiLap = 0;
        private string _soTaiKhoan = string.Empty;
        private string _tenNganHang = string.Empty;
        private int _loai = 0;
        private long _maNhanVienChuyenTien = 0;
        private string _quyen = string.Empty;
        private string _kyHieu = string.Empty;
        private string _so = string.Empty;
        private int _stt = 0;
        private bool _tinhTrangIn = false;

        private string _TenBoPhan = string.Empty;

        private int _TuThang=0;
        private int _DenThang = 0;

        public bool Chon { get; set; }

        [System.ComponentModel.DataObjectField(true, true)]
        public long Id
        {
            get
            {
                CanReadProperty("Id", true);
                return _id;
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

        public int MaKyQuyetToan
        {
            get
            {
                CanReadProperty("MaKyQuyetToan", true);
                return _maKyQuyetToan;
            }
            set
            {
                CanWriteProperty("MaKyQuyetToan", true);
                if (!_maKyQuyetToan.Equals(value))
                {
                    _maKyQuyetToan = value;
                    PropertyHasChanged("MaKyQuyetToan");
                }
            }
        }

        public int Nam
        {
            get
            {
                CanReadProperty("Nam", true);
                return _nam;
            }
            set
            {
                CanWriteProperty("Nam", true);
                if (!_nam.Equals(value))
                {
                    _nam = value;
                    PropertyHasChanged("Nam");
                }
            }
        }

        public int Thang
        {
            get
            {
                CanReadProperty("Thang", true);
                return _thang;
            }
            set
            {
                CanWriteProperty("Thang", true);
                if (!_thang.Equals(value))
                {
                    _thang = value;
                    PropertyHasChanged("Thang");
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

        public string TenNhanVien
        {
            get
            {
                CanReadProperty("TenNhanVien", true);
                return _tenNhanVien;
            }
            set
            {
                CanWriteProperty("TenNhanVien", true);
                if (value == null) value = string.Empty;
                if (!_tenNhanVien.Equals(value))
                {
                    _tenNhanVien = value;
                    PropertyHasChanged("TenNhanVien");
                }
            }
        }

        public string Mst
        {
            get
            {
                CanReadProperty("Mst", true);
                return _mst;
            }
            set
            {
                CanWriteProperty("Mst", true);
                if (value == null) value = string.Empty;
                if (!_mst.Equals(value))
                {
                    _mst = value;
                    PropertyHasChanged("Mst");
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

        public decimal PhanTramThue
        {
            get
            {
                CanReadProperty("PhanTramThue", true);
                return _phanTramThue;
            }
            set
            {
                CanWriteProperty("PhanTramThue", true);
                if (!_phanTramThue.Equals(value))
                {
                    _phanTramThue = value;
                    PropertyHasChanged("PhanTramThue");
                }
            }
        }

        public decimal TienThue
        {
            get
            {
                CanReadProperty("TienThue", true);
                return _tienThue;
            }
            set
            {
                CanWriteProperty("TienThue", true);
                if (!_tienThue.Equals(value))
                {
                    _tienThue = value;
                    PropertyHasChanged("TienThue");
                }
            }
        }

        public decimal SoTienConLai
        {
            get
            {
                CanReadProperty("SoTienConLai", true);
                return _soTienConLai;
            }
            set
            {
                CanWriteProperty("SoTienConLai", true);
                if (!_soTienConLai.Equals(value))
                {
                    _soTienConLai = value;
                    PropertyHasChanged("SoTienConLai");
                }
            }
        }

        public int MaUNC
        {
            get
            {
                CanReadProperty("MaUNC", true);
                return _maUNC;
            }
            set
            {
                CanWriteProperty("MaUNC", true);
                if (!_maUNC.Equals(value))
                {
                    _maUNC = value;
                    PropertyHasChanged("MaUNC");
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
                _ngayLap = new SmartDate(value);
                PropertyHasChanged("NgayLap");
            }
        }

        public string NgayLapString
        {
            get
            {
                CanReadProperty("NgayLapString", true);
                return _ngayLap.Text;
            }
            set
            {
                CanWriteProperty("NgayLapString", true);
                if (value == null) value = string.Empty;
                if (!_ngayLap.Equals(value))
                {
                    _ngayLap.Text = value;
                    PropertyHasChanged("NgayLapString");
                }
            }
        }

        public int NguoiLap
        {
            get
            {
                CanReadProperty("NguoiLap", true);
                return _nguoiLap;
            }
            set
            {
                CanWriteProperty("NguoiLap", true);
                if (!_nguoiLap.Equals(value))
                {
                    _nguoiLap = value;
                    PropertyHasChanged("NguoiLap");
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

        public long MaNhanVienChuyenTien
        {
            get
            {
                CanReadProperty("MaNhanVienChuyenTien", true);
                return _maNhanVienChuyenTien;
            }
            set
            {
                CanWriteProperty("MaNhanVienChuyenTien", true);
                if (!_maNhanVienChuyenTien.Equals(value))
                {
                    _maNhanVienChuyenTien = value;
                    PropertyHasChanged("MaNhanVienChuyenTien");
                }
            }
        }

        public string Quyen
        {
            get
            {
                CanReadProperty("Quyen", true);
                return _quyen;
            }
            set
            {
                CanWriteProperty("Quyen", true);
                if (value == null) value = string.Empty;
                if (!_quyen.Equals(value))
                {
                    _quyen = value;
                    PropertyHasChanged("Quyen");
                }
            }
        }

        public string KyHieu
        {
            get
            {
                CanReadProperty("KyHieu", true);
                return _kyHieu;
            }
            set
            {
                CanWriteProperty("KyHieu", true);
                if (value == null) value = string.Empty;
                if (!_kyHieu.Equals(value))
                {
                    _kyHieu = value;
                    PropertyHasChanged("KyHieu");
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

        public int Stt
        {
            get
            {
                CanReadProperty("Stt", true);
                return _stt;
            }
            set
            {
                CanWriteProperty("Stt", true);
                if (!_stt.Equals(value))
                {
                    _stt = value;
                    PropertyHasChanged("Stt");
                }
            }
        }

        public bool TinhTrangIn
        {
            get
            {
                CanReadProperty("TinhTrangIn", true);
                return _tinhTrangIn;
            }
            set
            {
                CanWriteProperty("TinhTrangIn", true);
                if (!_tinhTrangIn.Equals(value))
                {
                    _tinhTrangIn = value;
                    PropertyHasChanged("TinhTrangIn");
                }
            }
        }

        public string TenBoPhan
        {
            get
            {
                CanReadProperty("TenBoPhan", true);
                return _TenBoPhan;
            }
            set
            {
                CanWriteProperty("TenBoPhan", true);
                if (value == null) value = string.Empty;
                if (!_TenBoPhan.Equals(value))
                {
                    _TenBoPhan = value;
                    PropertyHasChanged("TenBoPhan");
                }
            }
        }

        public int TuThang
        {
            get
            {
                CanReadProperty("TuThang", true);
                return _TuThang;
            }
            set
            {
                CanWriteProperty("TuThang", true);
                if (!_TuThang.Equals(value))
                {
                    _TuThang = value;
                    PropertyHasChanged("TuThang");
                }
            }
        }

        public int DenThang
        {
            get
            {
                CanReadProperty("DenThang", true);
                return _DenThang;
            }
            set
            {
                CanWriteProperty("DenThang", true);
                if (!_DenThang.Equals(value))
                {
                    _DenThang = value;
                    PropertyHasChanged("DenThang");
                }
            }
        }

        protected override object GetIdValue()
        {
            return _id;
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
            // TenNhanVien
            //
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("TenNhanVien", 800));
            //
            // Mst
            //
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("Mst", 50));
            //
            // Cmnd
            //
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("Cmnd", 50));
            //
            // SoTaiKhoan
            //
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("SoTaiKhoan", 50));
            //
            // TenNganHang
            //
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("TenNganHang", 2000));
            //
            // Quyen
            //
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("Quyen", 100));
            //
            // KyHieu
            //
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("KyHieu", 100));
            //
            // So
            //
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("So", 100));
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
            //TODO: Define authorization rules in InBienLaiNhanVienTuQuyetToan
            //AuthorizationRules.AllowRead("Id", "InBienLaiNhanVienTuQuyetToanReadGroup");
            //AuthorizationRules.AllowRead("MaNhanVien", "InBienLaiNhanVienTuQuyetToanReadGroup");
            //AuthorizationRules.AllowRead("MaKyQuyetToan", "InBienLaiNhanVienTuQuyetToanReadGroup");
            //AuthorizationRules.AllowRead("Nam", "InBienLaiNhanVienTuQuyetToanReadGroup");
            //AuthorizationRules.AllowRead("Thang", "InBienLaiNhanVienTuQuyetToanReadGroup");
            //AuthorizationRules.AllowRead("MaBoPhan", "InBienLaiNhanVienTuQuyetToanReadGroup");
            //AuthorizationRules.AllowRead("TenNhanVien", "InBienLaiNhanVienTuQuyetToanReadGroup");
            //AuthorizationRules.AllowRead("Mst", "InBienLaiNhanVienTuQuyetToanReadGroup");
            //AuthorizationRules.AllowRead("Cmnd", "InBienLaiNhanVienTuQuyetToanReadGroup");
            //AuthorizationRules.AllowRead("SoTien", "InBienLaiNhanVienTuQuyetToanReadGroup");
            //AuthorizationRules.AllowRead("PhanTramThue", "InBienLaiNhanVienTuQuyetToanReadGroup");
            //AuthorizationRules.AllowRead("TienThue", "InBienLaiNhanVienTuQuyetToanReadGroup");
            //AuthorizationRules.AllowRead("SoTienConLai", "InBienLaiNhanVienTuQuyetToanReadGroup");
            //AuthorizationRules.AllowRead("MaUNC", "InBienLaiNhanVienTuQuyetToanReadGroup");
            //AuthorizationRules.AllowRead("NgayLap", "InBienLaiNhanVienTuQuyetToanReadGroup");
            //AuthorizationRules.AllowRead("NgayLapString", "InBienLaiNhanVienTuQuyetToanReadGroup");
            //AuthorizationRules.AllowRead("NguoiLap", "InBienLaiNhanVienTuQuyetToanReadGroup");
            //AuthorizationRules.AllowRead("SoTaiKhoan", "InBienLaiNhanVienTuQuyetToanReadGroup");
            //AuthorizationRules.AllowRead("TenNganHang", "InBienLaiNhanVienTuQuyetToanReadGroup");
            //AuthorizationRules.AllowRead("Loai", "InBienLaiNhanVienTuQuyetToanReadGroup");
            //AuthorizationRules.AllowRead("MaNhanVienChuyenTien", "InBienLaiNhanVienTuQuyetToanReadGroup");
            //AuthorizationRules.AllowRead("Quyen", "InBienLaiNhanVienTuQuyetToanReadGroup");
            //AuthorizationRules.AllowRead("KyHieu", "InBienLaiNhanVienTuQuyetToanReadGroup");
            //AuthorizationRules.AllowRead("So", "InBienLaiNhanVienTuQuyetToanReadGroup");
            //AuthorizationRules.AllowRead("Stt", "InBienLaiNhanVienTuQuyetToanReadGroup");
            //AuthorizationRules.AllowRead("TinhTrangIn", "InBienLaiNhanVienTuQuyetToanReadGroup");

            //AuthorizationRules.AllowWrite("MaNhanVien", "InBienLaiNhanVienTuQuyetToanWriteGroup");
            //AuthorizationRules.AllowWrite("MaKyQuyetToan", "InBienLaiNhanVienTuQuyetToanWriteGroup");
            //AuthorizationRules.AllowWrite("Nam", "InBienLaiNhanVienTuQuyetToanWriteGroup");
            //AuthorizationRules.AllowWrite("Thang", "InBienLaiNhanVienTuQuyetToanWriteGroup");
            //AuthorizationRules.AllowWrite("MaBoPhan", "InBienLaiNhanVienTuQuyetToanWriteGroup");
            //AuthorizationRules.AllowWrite("TenNhanVien", "InBienLaiNhanVienTuQuyetToanWriteGroup");
            //AuthorizationRules.AllowWrite("Mst", "InBienLaiNhanVienTuQuyetToanWriteGroup");
            //AuthorizationRules.AllowWrite("Cmnd", "InBienLaiNhanVienTuQuyetToanWriteGroup");
            //AuthorizationRules.AllowWrite("SoTien", "InBienLaiNhanVienTuQuyetToanWriteGroup");
            //AuthorizationRules.AllowWrite("PhanTramThue", "InBienLaiNhanVienTuQuyetToanWriteGroup");
            //AuthorizationRules.AllowWrite("TienThue", "InBienLaiNhanVienTuQuyetToanWriteGroup");
            //AuthorizationRules.AllowWrite("SoTienConLai", "InBienLaiNhanVienTuQuyetToanWriteGroup");
            //AuthorizationRules.AllowWrite("MaUNC", "InBienLaiNhanVienTuQuyetToanWriteGroup");
            //AuthorizationRules.AllowWrite("NgayLapString", "InBienLaiNhanVienTuQuyetToanWriteGroup");
            //AuthorizationRules.AllowWrite("NguoiLap", "InBienLaiNhanVienTuQuyetToanWriteGroup");
            //AuthorizationRules.AllowWrite("SoTaiKhoan", "InBienLaiNhanVienTuQuyetToanWriteGroup");
            //AuthorizationRules.AllowWrite("TenNganHang", "InBienLaiNhanVienTuQuyetToanWriteGroup");
            //AuthorizationRules.AllowWrite("Loai", "InBienLaiNhanVienTuQuyetToanWriteGroup");
            //AuthorizationRules.AllowWrite("MaNhanVienChuyenTien", "InBienLaiNhanVienTuQuyetToanWriteGroup");
            //AuthorizationRules.AllowWrite("Quyen", "InBienLaiNhanVienTuQuyetToanWriteGroup");
            //AuthorizationRules.AllowWrite("KyHieu", "InBienLaiNhanVienTuQuyetToanWriteGroup");
            //AuthorizationRules.AllowWrite("So", "InBienLaiNhanVienTuQuyetToanWriteGroup");
            //AuthorizationRules.AllowWrite("Stt", "InBienLaiNhanVienTuQuyetToanWriteGroup");
            //AuthorizationRules.AllowWrite("TinhTrangIn", "InBienLaiNhanVienTuQuyetToanWriteGroup");
        }


        public static bool CanGetObject()
        {
            //TODO: Define CanGetObject permission in InBienLaiNhanVienTuQuyetToan
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("InBienLaiNhanVienTuQuyetToanViewGroup"))
            //	return true;
            //return false;
        }

        public static bool CanAddObject()
        {
            //TODO: Define CanAddObject permission in InBienLaiNhanVienTuQuyetToan
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("InBienLaiNhanVienTuQuyetToanAddGroup"))
            //	return true;
            //return false;
        }

        public static bool CanEditObject()
        {
            //TODO: Define CanEditObject permission in InBienLaiNhanVienTuQuyetToan
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("InBienLaiNhanVienTuQuyetToanEditGroup"))
            //	return true;
            //return false;
        }

        public static bool CanDeleteObject()
        {
            //TODO: Define CanDeleteObject permission in InBienLaiNhanVienTuQuyetToan
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("InBienLaiNhanVienTuQuyetToanDeleteGroup"))
            //	return true;
            //return false;
        }
        #endregion //Authorization Rules

        #region Factory Methods
        private InBienLaiNhanVienTuQuyetToan()
        { /* require use of factory method */ }

        public static InBienLaiNhanVienTuQuyetToan NewInBienLaiNhanVienTuQuyetToan()
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a InBienLaiNhanVienTuQuyetToan");
            return DataPortal.Create<InBienLaiNhanVienTuQuyetToan>();
        }

        public static InBienLaiNhanVienTuQuyetToan GetInBienLaiNhanVienTuQuyetToan(long id)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a InBienLaiNhanVienTuQuyetToan");
            return DataPortal.Fetch<InBienLaiNhanVienTuQuyetToan>(new Criteria(id));
        }

        public static void DeleteInBienLaiNhanVienTuQuyetToan(long id)
        {
            if (!CanDeleteObject())
                throw new System.Security.SecurityException("User not authorized to remove a InBienLaiNhanVienTuQuyetToan");
            DataPortal.Delete(new Criteria(id));
        }

        public override InBienLaiNhanVienTuQuyetToan Save()
        {
            if (IsDeleted && !CanDeleteObject())
                throw new System.Security.SecurityException("User not authorized to remove a InBienLaiNhanVienTuQuyetToan");
            else if (IsNew && !CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a InBienLaiNhanVienTuQuyetToan");
            else if (!CanEditObject())
                throw new System.Security.SecurityException("User not authorized to update a InBienLaiNhanVienTuQuyetToan");

            return base.Save();
        }

        public static byte KiemTraMaKyQuyetToanDaInBienLai(int makyquyettoan)
        {
            byte rs = 0;//--0: Hop Le; 1: Chi Chot, chua In  Bien Lai; 2: Da In Bien Lai 
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "Spd_KiemTraMaKyQuyetToanDaInBienLai";
                    cm.Parameters.AddWithValue("@MaKyQuyetToan", makyquyettoan);
                    cm.Parameters.AddWithValue("@Userid", ERP_Library.Security.CurrentUser.Info.UserID);
                    SqlParameter prmGiaTriTraVe = new SqlParameter("@GiaTriTraVe", SqlDbType.TinyInt, 50);
                    prmGiaTriTraVe.Direction = ParameterDirection.Output;
                    cm.Parameters.Add(prmGiaTriTraVe);
                    cm.ExecuteNonQuery();
                    rs = (byte)prmGiaTriTraVe.Value;
                }
            }//us
            return rs;

        }

        #endregion //Factory Methods

        #region Child Factory Methods
        public static InBienLaiNhanVienTuQuyetToan NewInBienLaiNhanVienTuQuyetToanChild()
        {
            InBienLaiNhanVienTuQuyetToan child = new InBienLaiNhanVienTuQuyetToan();
            child.ValidationRules.CheckRules();
            child.MarkAsChild();
            return child;
        }

        internal static InBienLaiNhanVienTuQuyetToan GetInBienLaiNhanVienTuQuyetToan(SafeDataReader dr)
        {
            InBienLaiNhanVienTuQuyetToan child = new InBienLaiNhanVienTuQuyetToan();
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
            public long Id;

            public Criteria(long id)
            {
                this.Id = id;
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
                cm.CommandText = "spd_SelecttblInBienLaiNhanVienTuQuyetToan";

                cm.Parameters.AddWithValue("@ID", criteria.Id);

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
            DataPortal_Delete(new Criteria(_id));
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
                cm.CommandText = "spd_DeletetblInBienLaiNhanVienTuQuyetToan";

                cm.Parameters.AddWithValue("@ID", criteria.Id);

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
            _id = dr.GetInt64("ID");
            _maNhanVien = dr.GetInt64("MaNhanVien");
            _maKyQuyetToan = dr.GetInt32("MaKyQuyetToan");
            _nam = dr.GetInt32("Nam");
            _thang = dr.GetInt32("Thang");
            _maBoPhan = dr.GetInt32("MaBoPhan");
            _tenNhanVien = dr.GetString("TenNhanVien");
            _mst = dr.GetString("MST");
            _cmnd = dr.GetString("CMND");
            _soTien = dr.GetDecimal("SoTien");
            _phanTramThue = dr.GetDecimal("PhanTramThue");
            _tienThue = dr.GetDecimal("TienThue");
            _soTienConLai = dr.GetDecimal("SoTienConLai");
            _maUNC = dr.GetInt32("MaUNC");
            _ngayLap = dr.GetSmartDate("NgayLap", _ngayLap.EmptyIsMin);
            _nguoiLap = dr.GetInt32("NguoiLap");
            _soTaiKhoan = dr.GetString("SoTaiKhoan");
            _tenNganHang = dr.GetString("TenNganHang");
            _loai = dr.GetInt32("Loai");
            _maNhanVienChuyenTien = dr.GetInt64("MaNhanVienChuyenTien");
            _quyen = dr.GetString("Quyen");
            _kyHieu = dr.GetString("KyHieu");
            _so = dr.GetString("So");
            _stt = dr.GetInt32("STT");
            _tinhTrangIn = dr.GetBoolean("TinhTrangIn");
            _TenBoPhan = dr.GetString("TenBoPhan");

            _TuThang = dr.GetInt32("TuThang");
            _DenThang = dr.GetInt32("DenThang");
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
                cm.CommandText = "spd_InserttblInBienLaiNhanVienTuQuyetToan";

                AddInsertParameters(cm);

                cm.ExecuteNonQuery();

                _id = (long)cm.Parameters["@ID"].Value;
            }//using
        }

        private void AddInsertParameters(SqlCommand cm)
        {
            if (_maNhanVien != 0)
                cm.Parameters.AddWithValue("@MaNhanVien", _maNhanVien);
            else
                cm.Parameters.AddWithValue("@MaNhanVien", DBNull.Value);
            if (_maKyQuyetToan != 0)
                cm.Parameters.AddWithValue("@MaKyQuyetToan", _maKyQuyetToan);
            else
                cm.Parameters.AddWithValue("@MaKyQuyetToan", DBNull.Value);
            if (_nam != 0)
                cm.Parameters.AddWithValue("@Nam", _nam);
            else
                cm.Parameters.AddWithValue("@Nam", DBNull.Value);
            if (_thang != 0)
                cm.Parameters.AddWithValue("@Thang", _thang);
            else
                cm.Parameters.AddWithValue("@Thang", DBNull.Value);
            if (_maBoPhan != 0)
                cm.Parameters.AddWithValue("@MaBoPhan", _maBoPhan);
            else
                cm.Parameters.AddWithValue("@MaBoPhan", DBNull.Value);
            if (_tenNhanVien.Length > 0)
                cm.Parameters.AddWithValue("@TenNhanVien", _tenNhanVien);
            else
                cm.Parameters.AddWithValue("@TenNhanVien", DBNull.Value);
            if (_mst.Length > 0)
                cm.Parameters.AddWithValue("@MST", _mst);
            else
                cm.Parameters.AddWithValue("@MST", DBNull.Value);
            if (_cmnd.Length > 0)
                cm.Parameters.AddWithValue("@CMND", _cmnd);
            else
                cm.Parameters.AddWithValue("@CMND", DBNull.Value);
            if (_soTien != 0)
                cm.Parameters.AddWithValue("@SoTien", _soTien);
            else
                cm.Parameters.AddWithValue("@SoTien", DBNull.Value);
            if (_phanTramThue != 0)
                cm.Parameters.AddWithValue("@PhanTramThue", _phanTramThue);
            else
                cm.Parameters.AddWithValue("@PhanTramThue", DBNull.Value);
            if (_tienThue != 0)
                cm.Parameters.AddWithValue("@TienThue", _tienThue);
            else
                cm.Parameters.AddWithValue("@TienThue", DBNull.Value);
            if (_soTienConLai != 0)
                cm.Parameters.AddWithValue("@SoTienConLai", _soTienConLai);
            else
                cm.Parameters.AddWithValue("@SoTienConLai", DBNull.Value);
            if (_maUNC != 0)
                cm.Parameters.AddWithValue("@MaUNC", _maUNC);
            else
                cm.Parameters.AddWithValue("@MaUNC", DBNull.Value);
            cm.Parameters.AddWithValue("@NgayLap", _ngayLap.DBValue);
            if (_nguoiLap != 0)
                cm.Parameters.AddWithValue("@NguoiLap", _nguoiLap);
            else
                cm.Parameters.AddWithValue("@NguoiLap", DBNull.Value);
            if (_soTaiKhoan.Length > 0)
                cm.Parameters.AddWithValue("@SoTaiKhoan", _soTaiKhoan);
            else
                cm.Parameters.AddWithValue("@SoTaiKhoan", DBNull.Value);
            if (_tenNganHang.Length > 0)
                cm.Parameters.AddWithValue("@TenNganHang", _tenNganHang);
            else
                cm.Parameters.AddWithValue("@TenNganHang", DBNull.Value);
            cm.Parameters.AddWithValue("@Loai", _loai);
            if (_maNhanVienChuyenTien != 0)
                cm.Parameters.AddWithValue("@MaNhanVienChuyenTien", _maNhanVienChuyenTien);
            else
                cm.Parameters.AddWithValue("@MaNhanVienChuyenTien", DBNull.Value);
            if (_quyen.Length > 0)
                cm.Parameters.AddWithValue("@Quyen", _quyen);
            else
                cm.Parameters.AddWithValue("@Quyen", DBNull.Value);
            if (_kyHieu.Length > 0)
                cm.Parameters.AddWithValue("@KyHieu", _kyHieu);
            else
                cm.Parameters.AddWithValue("@KyHieu", DBNull.Value);
            if (_so.Length > 0)
                cm.Parameters.AddWithValue("@So", _so);
            else
                cm.Parameters.AddWithValue("@So", DBNull.Value);
            if (_stt != 0)
                cm.Parameters.AddWithValue("@STT", _stt);
            else
                cm.Parameters.AddWithValue("@STT", DBNull.Value);
            if (_tinhTrangIn != false)
                cm.Parameters.AddWithValue("@TinhTrangIn", _tinhTrangIn);
            else
                cm.Parameters.AddWithValue("@TinhTrangIn", DBNull.Value);
            if (_TenBoPhan.Length > 0)
                cm.Parameters.AddWithValue("@TenBoPhan", _TenBoPhan);
            else
                cm.Parameters.AddWithValue("@TenBoPhan", DBNull.Value);

            if (_TuThang != 0)
                cm.Parameters.AddWithValue("@TuThang", _TuThang);
            else
                cm.Parameters.AddWithValue("@TuThang", DBNull.Value);

            if (_DenThang != 0)
                cm.Parameters.AddWithValue("@DenThang", _DenThang);
            else
                cm.Parameters.AddWithValue("@DenThang", DBNull.Value);

            cm.Parameters.AddWithValue("@ID", _id);
            cm.Parameters["@ID"].Direction = ParameterDirection.Output;
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
                cm.CommandText = "spd_UpdatetblInBienLaiNhanVienTuQuyetToan";

                AddUpdateParameters(cm);

                cm.ExecuteNonQuery();

            }//using
        }

        private void AddUpdateParameters(SqlCommand cm)
        {
            cm.Parameters.AddWithValue("@ID", _id);
            if (_maNhanVien != 0)
                cm.Parameters.AddWithValue("@MaNhanVien", _maNhanVien);
            else
                cm.Parameters.AddWithValue("@MaNhanVien", DBNull.Value);
            if (_maKyQuyetToan != 0)
                cm.Parameters.AddWithValue("@MaKyQuyetToan", _maKyQuyetToan);
            else
                cm.Parameters.AddWithValue("@MaKyQuyetToan", DBNull.Value);
            if (_nam != 0)
                cm.Parameters.AddWithValue("@Nam", _nam);
            else
                cm.Parameters.AddWithValue("@Nam", DBNull.Value);
            if (_thang != 0)
                cm.Parameters.AddWithValue("@Thang", _thang);
            else
                cm.Parameters.AddWithValue("@Thang", DBNull.Value);
            if (_maBoPhan != 0)
                cm.Parameters.AddWithValue("@MaBoPhan", _maBoPhan);
            else
                cm.Parameters.AddWithValue("@MaBoPhan", DBNull.Value);
            if (_tenNhanVien.Length > 0)
                cm.Parameters.AddWithValue("@TenNhanVien", _tenNhanVien);
            else
                cm.Parameters.AddWithValue("@TenNhanVien", DBNull.Value);
            if (_mst.Length > 0)
                cm.Parameters.AddWithValue("@MST", _mst);
            else
                cm.Parameters.AddWithValue("@MST", DBNull.Value);
            if (_cmnd.Length > 0)
                cm.Parameters.AddWithValue("@CMND", _cmnd);
            else
                cm.Parameters.AddWithValue("@CMND", DBNull.Value);
            if (_soTien != 0)
                cm.Parameters.AddWithValue("@SoTien", _soTien);
            else
                cm.Parameters.AddWithValue("@SoTien", DBNull.Value);
            if (_phanTramThue != 0)
                cm.Parameters.AddWithValue("@PhanTramThue", _phanTramThue);
            else
                cm.Parameters.AddWithValue("@PhanTramThue", DBNull.Value);
            if (_tienThue != 0)
                cm.Parameters.AddWithValue("@TienThue", _tienThue);
            else
                cm.Parameters.AddWithValue("@TienThue", DBNull.Value);
            if (_soTienConLai != 0)
                cm.Parameters.AddWithValue("@SoTienConLai", _soTienConLai);
            else
                cm.Parameters.AddWithValue("@SoTienConLai", DBNull.Value);
            if (_maUNC != 0)
                cm.Parameters.AddWithValue("@MaUNC", _maUNC);
            else
                cm.Parameters.AddWithValue("@MaUNC", DBNull.Value);
            cm.Parameters.AddWithValue("@NgayLap", _ngayLap.DBValue);
            if (_nguoiLap != 0)
                cm.Parameters.AddWithValue("@NguoiLap", _nguoiLap);
            else
                cm.Parameters.AddWithValue("@NguoiLap", DBNull.Value);
            if (_soTaiKhoan.Length > 0)
                cm.Parameters.AddWithValue("@SoTaiKhoan", _soTaiKhoan);
            else
                cm.Parameters.AddWithValue("@SoTaiKhoan", DBNull.Value);
            if (_tenNganHang.Length > 0)
                cm.Parameters.AddWithValue("@TenNganHang", _tenNganHang);
            else
                cm.Parameters.AddWithValue("@TenNganHang", DBNull.Value);
            cm.Parameters.AddWithValue("@Loai", _loai);
            if (_maNhanVienChuyenTien != 0)
                cm.Parameters.AddWithValue("@MaNhanVienChuyenTien", _maNhanVienChuyenTien);
            else
                cm.Parameters.AddWithValue("@MaNhanVienChuyenTien", DBNull.Value);
            if (_quyen.Length > 0)
                cm.Parameters.AddWithValue("@Quyen", _quyen);
            else
                cm.Parameters.AddWithValue("@Quyen", DBNull.Value);
            if (_kyHieu.Length > 0)
                cm.Parameters.AddWithValue("@KyHieu", _kyHieu);
            else
                cm.Parameters.AddWithValue("@KyHieu", DBNull.Value);
            if (_so.Length > 0)
                cm.Parameters.AddWithValue("@So", _so);
            else
                cm.Parameters.AddWithValue("@So", DBNull.Value);
            if (_stt != 0)
                cm.Parameters.AddWithValue("@STT", _stt);
            else
                cm.Parameters.AddWithValue("@STT", DBNull.Value);
            if (_tinhTrangIn != false)
                cm.Parameters.AddWithValue("@TinhTrangIn", _tinhTrangIn);
            else
                cm.Parameters.AddWithValue("@TinhTrangIn", DBNull.Value);

            if (_TenBoPhan.Length > 0)
                cm.Parameters.AddWithValue("@TenBoPhan", _TenBoPhan);
            else
                cm.Parameters.AddWithValue("@TenBoPhan", DBNull.Value);

            if (_TuThang != 0)
                cm.Parameters.AddWithValue("@TuThang", _TuThang);
            else
                cm.Parameters.AddWithValue("@TuThang", DBNull.Value);

            if (_DenThang != 0)
                cm.Parameters.AddWithValue("@DenThang", _DenThang);
            else
                cm.Parameters.AddWithValue("@DenThang", DBNull.Value);
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

            ExecuteDelete(cn, new Criteria(_id));
            MarkNew();
        }
        #endregion //Data Access - Delete
        #endregion //Data Access
    }
}
