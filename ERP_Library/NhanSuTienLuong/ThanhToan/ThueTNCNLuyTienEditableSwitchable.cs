
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{
    [Serializable()]
    public class ThueTNCNLuyTien : Csla.BusinessBase<ThueTNCNLuyTien>
    {
        #region Business Properties and Methods

        //declare members
        private long _thueTNCNLuyTien = 0;
        private int _maBoPhan = 0;
        private int _maKyTinhLuong = 0;
        private long _maNhanVien = 0;
        private int _nguoiLap = 0;
        private string _dienGiai = string.Empty;
        private decimal _tongThuNhap = 0;
        private decimal _tongThuNhapChiuThue = 0;
        private decimal _thueTNCNPhaiNop = 0;
        private decimal _thueTNCNDaNop = 0;
        private decimal _phanTramTinh = 0;
        private decimal _thueTNCNTamNop = 0;
        private decimal _tongTienGiamTru = 0;
        private decimal _soThangGiamTru = 0;
        private int _soNPT = 0;
        private decimal _bhxh = 0;
        private decimal _bhyt = 0;
        private decimal _bhtn = 0;
        private SmartDate _ngayLap = new SmartDate(DateTime.Today);
        private SmartDate _ngayTinh = new SmartDate(DateTime.Today);
        private int _soThang = 0;
        private bool _daThu = false;
        private decimal _thueTNCNDuocMien = 0;
        private int _lanTinhThue = 0;
        private string _soChungTu = string.Empty;
        private long _maChungTu = 0;
        private decimal _soTienChuyenTrongDot = 0;
        private string _tenBoPhan = string.Empty;
        private string _tenNhanVien = string.Empty;
        private bool _ngoai = false;
        private decimal _tongThuNhapTT = 0;
        private decimal _tongThuNhapChiuThueTT = 0;

        [System.ComponentModel.DataObjectField(true, true)]
        public long MaThueTNCNLuyTien
        {
            get
            {
                CanReadProperty("MaThueTNCNLuyTien", true);
                return _thueTNCNLuyTien;
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

        public int MaKyTinhLuong
        {
            get
            {
                CanReadProperty("MaKyTinhLuong", true);
                return _maKyTinhLuong;
            }
            set
            {
                CanWriteProperty("MaKyTinhLuong", true);
                if (!_maKyTinhLuong.Equals(value))
                {
                    _maKyTinhLuong = value;
                    PropertyHasChanged("MaKyTinhLuong");
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

        public decimal TongThuNhap
        {
            get
            {
                CanReadProperty("TongThuNhap", true);
                return _tongThuNhap;
            }
            set
            {
                CanWriteProperty("TongThuNhap", true);
                if (!_tongThuNhap.Equals(value))
                {
                    _tongThuNhap = value;
                    PropertyHasChanged("TongThuNhap");
                }
            }
        }

        public decimal TongThuNhapChiuThue
        {
            get
            {
                CanReadProperty("TongThuNhapChiuThue", true);
                return _tongThuNhapChiuThue;
            }
            set
            {
                CanWriteProperty("TongThuNhapChiuThue", true);
                if (!_tongThuNhapChiuThue.Equals(value))
                {
                    _tongThuNhapChiuThue = value;
                    PropertyHasChanged("TongThuNhapChiuThue");
                }
            }
        }

        public decimal ThueTNCNPhaiNop
        {
            get
            {
                CanReadProperty("ThueTNCNPhaiNop", true);
                return _thueTNCNPhaiNop;
            }
            set
            {
                CanWriteProperty("ThueTNCNPhaiNop", true);
                if (!_thueTNCNPhaiNop.Equals(value))
                {
                    _thueTNCNPhaiNop = value;
                    PropertyHasChanged("ThueTNCNPhaiNop");
                }
            }
        }

        public decimal ThueTNCNDaNop
        {
            get
            {
                CanReadProperty("ThueTNCNDaNop", true);
                return _thueTNCNDaNop;
            }
            set
            {
                CanWriteProperty("ThueTNCNDaNop", true);
                if (!_thueTNCNDaNop.Equals(value))
                {
                    _thueTNCNDaNop = value;
                    PropertyHasChanged("ThueTNCNDaNop");
                }
            }
        }

        public decimal PhanTramTinh
        {
            get
            {
                CanReadProperty("PhanTramTinh", true);
                return _phanTramTinh;
            }
            set
            {
                CanWriteProperty("PhanTramTinh", true);
                if (!_phanTramTinh.Equals(value))
                {
                    _phanTramTinh = value;
                    PropertyHasChanged("PhanTramTinh");
                }
            }
        }

        public decimal ThueTNCNTamNop
        {
            get
            {
                CanReadProperty("ThueTNCNTamNop", true);
                return _thueTNCNTamNop;
            }
            set
            {
                CanWriteProperty("ThueTNCNTamNop", true);
                if (!_thueTNCNTamNop.Equals(value))
                {
                    _thueTNCNTamNop = value;
                    PropertyHasChanged("ThueTNCNTamNop");
                }
            }
        }

        public decimal TongTienGiamTru
        {
            get
            {
                CanReadProperty("TongTienGiamTru", true);
                return _tongTienGiamTru;
            }
            set
            {
                CanWriteProperty("TongTienGiamTru", true);
                if (!_tongTienGiamTru.Equals(value))
                {
                    _tongTienGiamTru = value;
                    PropertyHasChanged("TongTienGiamTru");
                }
            }
        }

        public decimal SoThangGiamTru
        {
            get
            {
                CanReadProperty("SoThangGiamTru", true);
                return _soThangGiamTru;
            }
            set
            {
                CanWriteProperty("SoThangGiamTru", true);
                if (!_soThangGiamTru.Equals(value))
                {
                    _soThangGiamTru = value;
                    PropertyHasChanged("SoThangGiamTru");
                }
            }
        }

        public int SoNPT
        {
            get
            {
                CanReadProperty("SoNPT", true);
                return _soNPT;
            }
            set
            {
                CanWriteProperty("SoNPT", true);
                if (!_soNPT.Equals(value))
                {
                    _soNPT = value;
                    PropertyHasChanged("SoNPT");
                }
            }
        }

        public decimal Bhxh
        {
            get
            {
                CanReadProperty("Bhxh", true);
                return _bhxh;
            }
            set
            {
                CanWriteProperty("Bhxh", true);
                if (!_bhxh.Equals(value))
                {
                    _bhxh = value;
                    PropertyHasChanged("Bhxh");
                }
            }
        }

        public decimal Bhyt
        {
            get
            {
                CanReadProperty("Bhyt", true);
                return _bhyt;
            }
            set
            {
                CanWriteProperty("Bhyt", true);
                if (!_bhyt.Equals(value))
                {
                    _bhyt = value;
                    PropertyHasChanged("Bhyt");
                }
            }
        }

        public decimal Bhtn
        {
            get
            {
                CanReadProperty("Bhtn", true);
                return _bhtn;
            }
            set
            {
                CanWriteProperty("Bhtn", true);
                if (!_bhtn.Equals(value))
                {
                    _bhtn = value;
                    PropertyHasChanged("Bhtn");
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

        public DateTime NgayTinh
        {
            get
            {
                CanReadProperty("NgayTinh", true);
                return _ngayTinh.Date;
            }
        }

        public string NgayTinhString
        {
            get
            {
                CanReadProperty("NgayTinhString", true);
                return _ngayTinh.Text;
            }
            set
            {
                CanWriteProperty("NgayTinhString", true);
                if (value == null) value = string.Empty;
                if (!_ngayTinh.Equals(value))
                {
                    _ngayTinh.Text = value;
                    PropertyHasChanged("NgayTinhString");
                }
            }
        }

        public int SoThang
        {
            get
            {
                CanReadProperty("SoThang", true);
                return _soThang;
            }
            set
            {
                CanWriteProperty("SoThang", true);
                if (!_soThang.Equals(value))
                {
                    _soThang = value;
                    PropertyHasChanged("SoThang");
                }
            }
        }

        public bool DaThu
        {
            get
            {
                CanReadProperty("DaThu", true);
                return _daThu;
            }
            set
            {
                CanWriteProperty("DaThu", true);
                if (!_daThu.Equals(value))
                {
                    _daThu = value;
                    PropertyHasChanged("DaThu");
                }
            }
        }

        public decimal ThueTNCNDuocMien
        {
            get
            {
                CanReadProperty("ThueTNCNDuocMien", true);
                return _thueTNCNDuocMien;
            }
            set
            {
                CanWriteProperty("ThueTNCNDuocMien", true);
                if (!_thueTNCNDuocMien.Equals(value))
                {
                    _thueTNCNDuocMien = value;
                    PropertyHasChanged("ThueTNCNDuocMien");
                }
            }
        }

        public int LanTinhThue
        {
            get
            {
                CanReadProperty("LanTinhThue", true);
                return _lanTinhThue;
            }
            set
            {
                CanWriteProperty("LanTinhThue", true);
                if (!_lanTinhThue.Equals(value))
                {
                    _lanTinhThue = value;
                    PropertyHasChanged("LanTinhThue");
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

        public string TenBoPhan
        {
            get
            {
                CanReadProperty("TenBoPhan", true);
                return _tenBoPhan;
            }
        }

        public string TenNhanVien
        {
            get
            {
                CanReadProperty("TenNhanVien", true);
                return _tenNhanVien;
            }
        }

        public long MaChungTu
        {
            get
            {
                CanReadProperty("MaChungTu", true);
                return _maChungTu;
            }
            set
            {
                CanWriteProperty("MaChungTu", true);
                if (!_maChungTu.Equals(value))
                {
                    _maChungTu = value;
                    PropertyHasChanged("MaChungTu");
                }
            }
        }

        public decimal SoTienChuyenTrongDot
        {
            get
            {
                CanReadProperty("SoTienChuyenTrongDot", true);
                return _soTienChuyenTrongDot;
            }
            set
            {
                CanWriteProperty("SoTienChuyenTrongDot", true);
                if (!_soTienChuyenTrongDot.Equals(value))
                {
                    _soTienChuyenTrongDot = value;
                    PropertyHasChanged("SoTienChuyenTrongDot");
                }
            }
        }

        public decimal TongThuNhapTT
        {
            get
            {
                CanReadProperty("TongThuNhapTT", true);
                return _tongThuNhapTT;
            }
            set
            {
                CanWriteProperty("TongThuNhapTT", true);
                if (!_tongThuNhapTT.Equals(value))
                {
                    _tongThuNhapTT = value;
                    PropertyHasChanged("TongThuNhapTT");
                }
            }
        }

        public decimal TongThuNhapChiuThueTT
        {
            get
            {
                CanReadProperty("TongThuNhapChiuThueTT", true);
                return _tongThuNhapChiuThueTT;
            }
            set
            {
                CanWriteProperty("TongThuNhapChiuThueTT", true);
                if (!_tongThuNhapChiuThueTT.Equals(value))
                {
                    _tongThuNhapChiuThueTT = value;
                    PropertyHasChanged("TongThuNhapChiuThueTT");
                }
            }
        }

        protected override object GetIdValue()
        {
            return _thueTNCNLuyTien;
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
            // DienGiai
            //
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("DienGiai", 4000));
            //
            // NgayLap
            //
            ValidationRules.AddRule(CommonRules.StringRequired, "NgayLapString");
            //
            // NgayTinh
            //
            ValidationRules.AddRule(CommonRules.StringRequired, "NgayTinhString");
            //
            // SoChungTu
            //
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("SoChungTu", 50));
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
            //TODO: Define authorization rules in ThueTNCNLuyTien
            //AuthorizationRules.AllowRead("ThueTNCNLuyTien", "ThueTNCNLuyTienReadGroup");
            //AuthorizationRules.AllowRead("MaBoPhan", "ThueTNCNLuyTienReadGroup");
            //AuthorizationRules.AllowRead("MaKyTinhLuong", "ThueTNCNLuyTienReadGroup");
            //AuthorizationRules.AllowRead("MaNhanVien", "ThueTNCNLuyTienReadGroup");
            //AuthorizationRules.AllowRead("NguoiLap", "ThueTNCNLuyTienReadGroup");
            //AuthorizationRules.AllowRead("DienGiai", "ThueTNCNLuyTienReadGroup");
            //AuthorizationRules.AllowRead("TongThuNhap", "ThueTNCNLuyTienReadGroup");
            //AuthorizationRules.AllowRead("TongThuNhapChiuThue", "ThueTNCNLuyTienReadGroup");
            //AuthorizationRules.AllowRead("ThueTNCNPhaiNop", "ThueTNCNLuyTienReadGroup");
            //AuthorizationRules.AllowRead("ThueTNCNDaNop", "ThueTNCNLuyTienReadGroup");
            //AuthorizationRules.AllowRead("PhanTramTinh", "ThueTNCNLuyTienReadGroup");
            //AuthorizationRules.AllowRead("ThueTNCNTamNop", "ThueTNCNLuyTienReadGroup");
            //AuthorizationRules.AllowRead("TongTienGiamTru", "ThueTNCNLuyTienReadGroup");
            //AuthorizationRules.AllowRead("SoThangGiamTru", "ThueTNCNLuyTienReadGroup");
            //AuthorizationRules.AllowRead("SoNPT", "ThueTNCNLuyTienReadGroup");
            //AuthorizationRules.AllowRead("Bhxh", "ThueTNCNLuyTienReadGroup");
            //AuthorizationRules.AllowRead("Bhyt", "ThueTNCNLuyTienReadGroup");
            //AuthorizationRules.AllowRead("Bhtn", "ThueTNCNLuyTienReadGroup");
            //AuthorizationRules.AllowRead("NgayLap", "ThueTNCNLuyTienReadGroup");
            //AuthorizationRules.AllowRead("NgayLapString", "ThueTNCNLuyTienReadGroup");
            //AuthorizationRules.AllowRead("NgayTinh", "ThueTNCNLuyTienReadGroup");
            //AuthorizationRules.AllowRead("NgayTinhString", "ThueTNCNLuyTienReadGroup");
            //AuthorizationRules.AllowRead("SoThang", "ThueTNCNLuyTienReadGroup");
            //AuthorizationRules.AllowRead("DaThu", "ThueTNCNLuyTienReadGroup");
            //AuthorizationRules.AllowRead("ThueTNCNDuocMien", "ThueTNCNLuyTienReadGroup");
            //AuthorizationRules.AllowRead("LanTinhThue", "ThueTNCNLuyTienReadGroup");
            //AuthorizationRules.AllowRead("SoChungTu", "ThueTNCNLuyTienReadGroup");
            //AuthorizationRules.AllowRead("MaChungTu", "ThueTNCNLuyTienReadGroup");
            //AuthorizationRules.AllowRead("SoTienChuyenTrongDot", "ThueTNCNLuyTienReadGroup");

            //AuthorizationRules.AllowWrite("MaBoPhan", "ThueTNCNLuyTienWriteGroup");
            //AuthorizationRules.AllowWrite("MaKyTinhLuong", "ThueTNCNLuyTienWriteGroup");
            //AuthorizationRules.AllowWrite("MaNhanVien", "ThueTNCNLuyTienWriteGroup");
            //AuthorizationRules.AllowWrite("NguoiLap", "ThueTNCNLuyTienWriteGroup");
            //AuthorizationRules.AllowWrite("DienGiai", "ThueTNCNLuyTienWriteGroup");
            //AuthorizationRules.AllowWrite("TongThuNhap", "ThueTNCNLuyTienWriteGroup");
            //AuthorizationRules.AllowWrite("TongThuNhapChiuThue", "ThueTNCNLuyTienWriteGroup");
            //AuthorizationRules.AllowWrite("ThueTNCNPhaiNop", "ThueTNCNLuyTienWriteGroup");
            //AuthorizationRules.AllowWrite("ThueTNCNDaNop", "ThueTNCNLuyTienWriteGroup");
            //AuthorizationRules.AllowWrite("PhanTramTinh", "ThueTNCNLuyTienWriteGroup");
            //AuthorizationRules.AllowWrite("ThueTNCNTamNop", "ThueTNCNLuyTienWriteGroup");
            //AuthorizationRules.AllowWrite("TongTienGiamTru", "ThueTNCNLuyTienWriteGroup");
            //AuthorizationRules.AllowWrite("SoThangGiamTru", "ThueTNCNLuyTienWriteGroup");
            //AuthorizationRules.AllowWrite("SoNPT", "ThueTNCNLuyTienWriteGroup");
            //AuthorizationRules.AllowWrite("Bhxh", "ThueTNCNLuyTienWriteGroup");
            //AuthorizationRules.AllowWrite("Bhyt", "ThueTNCNLuyTienWriteGroup");
            //AuthorizationRules.AllowWrite("Bhtn", "ThueTNCNLuyTienWriteGroup");
            //AuthorizationRules.AllowWrite("NgayLapString", "ThueTNCNLuyTienWriteGroup");
            //AuthorizationRules.AllowWrite("NgayTinhString", "ThueTNCNLuyTienWriteGroup");
            //AuthorizationRules.AllowWrite("SoThang", "ThueTNCNLuyTienWriteGroup");
            //AuthorizationRules.AllowWrite("DaThu", "ThueTNCNLuyTienWriteGroup");
            //AuthorizationRules.AllowWrite("ThueTNCNDuocMien", "ThueTNCNLuyTienWriteGroup");
            //AuthorizationRules.AllowWrite("LanTinhThue", "ThueTNCNLuyTienWriteGroup");
            //AuthorizationRules.AllowWrite("SoChungTu", "ThueTNCNLuyTienWriteGroup");
            //AuthorizationRules.AllowWrite("MaChungTu", "ThueTNCNLuyTienWriteGroup");
            //AuthorizationRules.AllowWrite("SoTienChuyenTrongDot", "ThueTNCNLuyTienWriteGroup");
        }


        public static bool CanGetObject()
        {
            //TODO: Define CanGetObject permission in ThueTNCNLuyTien
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("ThueTNCNLuyTienViewGroup"))
            //	return true;
            //return false;
        }

        public static bool CanAddObject()
        {
            //TODO: Define CanAddObject permission in ThueTNCNLuyTien
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("ThueTNCNLuyTienAddGroup"))
            //	return true;
            //return false;
        }

        public static bool CanEditObject()
        {
            //TODO: Define CanEditObject permission in ThueTNCNLuyTien
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("ThueTNCNLuyTienEditGroup"))
            //	return true;
            //return false;
        }

        public static bool CanDeleteObject()
        {
            //TODO: Define CanDeleteObject permission in ThueTNCNLuyTien
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("ThueTNCNLuyTienDeleteGroup"))
            //	return true;
            //return false;
        }
        #endregion //Authorization Rules

        #region Factory Methods
        private ThueTNCNLuyTien()
        { /* require use of factory method */ }

        public static ThueTNCNLuyTien NewThueTNCNLuyTien()
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a ThueTNCNLuyTien");
            return DataPortal.Create<ThueTNCNLuyTien>();
        }

        public static ThueTNCNLuyTien GetThueTNCNLuyTien(long thueTNCNLuyTien)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a ThueTNCNLuyTien");
            return DataPortal.Fetch<ThueTNCNLuyTien>(new Criteria(thueTNCNLuyTien));
        }

        public static void DeleteThueTNCNLuyTien(long thueTNCNLuyTien)
        {
            if (!CanDeleteObject())
                throw new System.Security.SecurityException("User not authorized to remove a ThueTNCNLuyTien");
            DataPortal.Delete(new Criteria(thueTNCNLuyTien));
        }

        public override ThueTNCNLuyTien Save()
        {
            if (IsDeleted && !CanDeleteObject())
                throw new System.Security.SecurityException("User not authorized to remove a ThueTNCNLuyTien");
            else if (IsNew && !CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a ThueTNCNLuyTien");
            else if (!CanEditObject())
                throw new System.Security.SecurityException("User not authorized to update a ThueTNCNLuyTien");

            return base.Save();
        }

        #endregion //Factory Methods

        #region Child Factory Methods
        internal static ThueTNCNLuyTien NewThueTNCNLuyTienChild()
        {
            ThueTNCNLuyTien child = new ThueTNCNLuyTien();
            child.ValidationRules.CheckRules();
            child.MarkAsChild();
            return child;
        }

        internal static ThueTNCNLuyTien GetThueTNCNLuyTien(SafeDataReader dr)
        {
            ThueTNCNLuyTien child = new ThueTNCNLuyTien();
            child.MarkAsChild();
            child.Fetch(dr);
            return child;
        }

        internal static ThueTNCNLuyTien GetThueTNCNLuyTien_NgoaiDoan(SafeDataReader dr)
        {
            ThueTNCNLuyTien child = new ThueTNCNLuyTien();
            child.MarkAsChild();
            child.Fetch_NgoaiDoan(dr);
            return child;
        }
        #endregion //Child Factory Methods

        #region Data Access

        #region Criteria

        [Serializable()]
        private class Criteria
        {
            public long ThueTNCNLuyTien;

            public Criteria(long thueTNCNLuyTien)
            {
                this.ThueTNCNLuyTien = thueTNCNLuyTien;
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
                cm.CommandText = "spd_SelecttblThueTNCNLuyTien";

                cm.Parameters.AddWithValue("@ThueTNCNLuyTien", criteria.ThueTNCNLuyTien);

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
            DataPortal_Delete(new Criteria(_thueTNCNLuyTien));
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
                cm.CommandText = "spd_DeletetblThueTNCNLuyTien";

                cm.Parameters.AddWithValue("@ThueTNCNLuyTien", criteria.ThueTNCNLuyTien);

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

        private void Fetch_NgoaiDoan(SafeDataReader dr)
        {
            FetchObject_NgoaiDoan(dr);
            MarkOld();
            ValidationRules.CheckRules();

            //load child object(s)
            FetchChildren(dr);
        }

        private void FetchObject(SafeDataReader dr)
        {
            _thueTNCNLuyTien = dr.GetInt64("ThueTNCNLuyTien");
            _maBoPhan = dr.GetInt32("MaBoPhan");
            _maKyTinhLuong = dr.GetInt32("MaKyTinhLuong");
            _maNhanVien = dr.GetInt64("MaNhanVien");
            _nguoiLap = dr.GetInt32("NguoiLap");
            _dienGiai = dr.GetString("DienGiai");
            _tongThuNhap = dr.GetDecimal("TongThuNhap");
            _tongThuNhapChiuThue = dr.GetDecimal("TongThuNhapChiuThue");
            _thueTNCNPhaiNop = dr.GetDecimal("ThueTNCNPhaiNop");
            _thueTNCNDaNop = dr.GetDecimal("ThueTNCNDaNop");
            _phanTramTinh = dr.GetDecimal("PhanTramTinh");
            _thueTNCNTamNop = dr.GetDecimal("ThueTNCNTamNop");
            _tongTienGiamTru = dr.GetDecimal("TongTienGiamTru");
            _soThangGiamTru = dr.GetDecimal("SoThangGiamTru");
            _soNPT = dr.GetInt32("SoNPT");
            _bhxh = dr.GetDecimal("BHXH");
            _bhyt = dr.GetDecimal("BHYT");
            _bhtn = dr.GetDecimal("BHTN");
            _ngayLap = dr.GetSmartDate("NgayLap", _ngayLap.EmptyIsMin);
            _ngayTinh = dr.GetSmartDate("NgayTinh", _ngayTinh.EmptyIsMin);
            _soThang = dr.GetInt32("SoThang");
            _daThu = dr.GetBoolean("DaThu");
            _thueTNCNDuocMien = dr.GetDecimal("ThueTNCNDuocMien");
            _lanTinhThue = dr.GetInt32("LanTinhThue");
            _soChungTu = dr.GetString("SoChungTu");
            _maChungTu = dr.GetInt64("MaChungTu");
            _soTienChuyenTrongDot = dr.GetDecimal("SoTienChuyenTrongDot");
            _tenBoPhan = dr.GetString("TenBoPhan");
            _tenNhanVien = dr.GetString("TenNhanVien");
            _tongThuNhapTT = dr.GetDecimal("TongThuNhapTT"); 
            _tongThuNhapChiuThueTT = dr.GetDecimal("TongThuNhapChiuThueTT");
        }

        private void FetchObject_NgoaiDoan(SafeDataReader dr)
        {
            _thueTNCNLuyTien = dr.GetInt64("ThueTNCNLuyTien");
            _maBoPhan = dr.GetInt32("MaBoPhan");
            _maKyTinhLuong = dr.GetInt32("MaKyTinhLuong");
            _maNhanVien = dr.GetInt64("MaNhanVien");
            _nguoiLap = dr.GetInt32("NguoiLap");
            _dienGiai = dr.GetString("DienGiai");
            _tongThuNhap = dr.GetDecimal("TongThuNhap");
            _tongThuNhapChiuThue = dr.GetDecimal("TongThuNhapChiuThue");
            _thueTNCNPhaiNop = dr.GetDecimal("ThueTNCNPhaiNop");
            _thueTNCNDaNop = dr.GetDecimal("ThueTNCNDaNop");
            _phanTramTinh = dr.GetDecimal("PhanTramTinh");
            _thueTNCNTamNop = dr.GetDecimal("ThueTNCNTamNop");
            _tongTienGiamTru = dr.GetDecimal("TongTienGiamTru");
            _soThangGiamTru = dr.GetDecimal("SoThangGiamTru");
            _soNPT = dr.GetInt32("SoNPT");
            _bhxh = dr.GetDecimal("BHXH");
            _bhyt = dr.GetDecimal("BHYT");
            _bhtn = dr.GetDecimal("BHTN");
            _ngayLap = dr.GetSmartDate("NgayLap", _ngayLap.EmptyIsMin);
            _ngayTinh = dr.GetSmartDate("NgayTinh", _ngayTinh.EmptyIsMin);
            _soThang = dr.GetInt32("SoThang");
            _daThu = dr.GetBoolean("DaThu");
            _thueTNCNDuocMien = dr.GetDecimal("ThueTNCNDuocMien");
            _lanTinhThue = dr.GetInt32("LanTinhThue");
            _soChungTu = dr.GetString("SoChungTu");
            _maChungTu = dr.GetInt64("MaChungTu");
            _soTienChuyenTrongDot = dr.GetDecimal("SoTienChuyenTrongDot");
            _tenBoPhan = dr.GetString("TenBoPhan");
            _tenNhanVien = dr.GetString("TenNhanVien");
            _ngoai = dr.GetBoolean("NgoaiDoan");
        }

        private void FetchChildren(SafeDataReader dr)
        {
        }
        #endregion //Data Access - Fetch

        #region Data Access - Insert
        internal void Insert(SqlTransaction tr, ThueTNCNLuyTienList parent)
        {
            if (!IsDirty) return;

            ExecuteInsert(tr, parent);
            MarkOld();

            //update child object(s)
            UpdateChildren(tr);
        }

        private void ExecuteInsert(SqlTransaction tr, ThueTNCNLuyTienList parent)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_InserttblThueTNCNLuyTien";

                AddInsertParameters(cm, parent);

                cm.ExecuteNonQuery();

                _thueTNCNLuyTien = (long)cm.Parameters["@NewThueTNCNLuyTien"].Value;
            }//using
        }

        private void AddInsertParameters(SqlCommand cm, ThueTNCNLuyTienList parent)
        {
            //TODO: if parent use identity key, fix fk member with value from parent
            cm.Parameters.AddWithValue("@MaBoPhan", _maBoPhan);
            cm.Parameters.AddWithValue("@MaKyTinhLuong", _maKyTinhLuong);
            cm.Parameters.AddWithValue("@MaNhanVien", _maNhanVien);
            cm.Parameters.AddWithValue("@NguoiLap", _nguoiLap);
            if (_dienGiai.Length > 0)
                cm.Parameters.AddWithValue("@DienGiai", _dienGiai);
            else
                cm.Parameters.AddWithValue("@DienGiai", DBNull.Value);
            if (_tongThuNhap != 0)
                cm.Parameters.AddWithValue("@TongThuNhap", _tongThuNhap);
            else
                cm.Parameters.AddWithValue("@TongThuNhap", DBNull.Value);
            if (_tongThuNhapChiuThue != 0)
                cm.Parameters.AddWithValue("@TongThuNhapChiuThue", _tongThuNhapChiuThue);
            else
                cm.Parameters.AddWithValue("@TongThuNhapChiuThue", DBNull.Value);
            if (_thueTNCNPhaiNop != 0)
                cm.Parameters.AddWithValue("@ThueTNCNPhaiNop", _thueTNCNPhaiNop);
            else
                cm.Parameters.AddWithValue("@ThueTNCNPhaiNop", DBNull.Value);
            if (_thueTNCNDaNop != 0)
                cm.Parameters.AddWithValue("@ThueTNCNDaNop", _thueTNCNDaNop);
            else
                cm.Parameters.AddWithValue("@ThueTNCNDaNop", DBNull.Value);
            if (_phanTramTinh != 0)
                cm.Parameters.AddWithValue("@PhanTramTinh", _phanTramTinh);
            else
                cm.Parameters.AddWithValue("@PhanTramTinh", DBNull.Value);
            if (_thueTNCNTamNop != 0)
                cm.Parameters.AddWithValue("@ThueTNCNTamNop", _thueTNCNTamNop);
            else
                cm.Parameters.AddWithValue("@ThueTNCNTamNop", DBNull.Value);
            if (_tongTienGiamTru != 0)
                cm.Parameters.AddWithValue("@TongTienGiamTru", _tongTienGiamTru);
            else
                cm.Parameters.AddWithValue("@TongTienGiamTru", DBNull.Value);
            if (_soThangGiamTru != 0)
                cm.Parameters.AddWithValue("@SoThangGiamTru", _soThangGiamTru);
            else
                cm.Parameters.AddWithValue("@SoThangGiamTru", DBNull.Value);
            if (_soNPT != 0)
                cm.Parameters.AddWithValue("@SoNPT", _soNPT);
            else
                cm.Parameters.AddWithValue("@SoNPT", DBNull.Value);
            if (_bhxh != 0)
                cm.Parameters.AddWithValue("@BHXH", _bhxh);
            else
                cm.Parameters.AddWithValue("@BHXH", DBNull.Value);
            if (_bhyt != 0)
                cm.Parameters.AddWithValue("@BHYT", _bhyt);
            else
                cm.Parameters.AddWithValue("@BHYT", DBNull.Value);
            if (_bhtn != 0)
                cm.Parameters.AddWithValue("@BHTN", _bhtn);
            else
                cm.Parameters.AddWithValue("@BHTN", DBNull.Value);
            cm.Parameters.AddWithValue("@NgayLap", _ngayLap.DBValue);
            cm.Parameters.AddWithValue("@NgayTinh", _ngayTinh.DBValue);
            if (_soThang != 0)
                cm.Parameters.AddWithValue("@SoThang", _soThang);
            else
                cm.Parameters.AddWithValue("@SoThang", DBNull.Value);
            if (_daThu != false)
                cm.Parameters.AddWithValue("@DaThu", _daThu);
            else
                cm.Parameters.AddWithValue("@DaThu", DBNull.Value);
            if (_thueTNCNDuocMien != 0)
                cm.Parameters.AddWithValue("@ThueTNCNDuocMien", _thueTNCNDuocMien);
            else
                cm.Parameters.AddWithValue("@ThueTNCNDuocMien", DBNull.Value);
            if (_lanTinhThue != 0)
                cm.Parameters.AddWithValue("@LanTinhThue", _lanTinhThue);
            else
                cm.Parameters.AddWithValue("@LanTinhThue", DBNull.Value);
            if (_soChungTu.Length > 0)
                cm.Parameters.AddWithValue("@SoChungTu", _soChungTu);
            else
                cm.Parameters.AddWithValue("@SoChungTu", DBNull.Value);
            if (_maChungTu != 0)
                cm.Parameters.AddWithValue("@MaChungTu", _maChungTu);
            else
                cm.Parameters.AddWithValue("@MaChungTu", DBNull.Value);
            if (_soTienChuyenTrongDot != 0)
                cm.Parameters.AddWithValue("@SoTienChuyenTrongDot", _soTienChuyenTrongDot);
            else
                cm.Parameters.AddWithValue("@SoTienChuyenTrongDot", DBNull.Value);
            cm.Parameters.AddWithValue("@ThueTNCNLuyTien", _thueTNCNLuyTien);
            cm.Parameters["@ThueTNCNLuyTien"].Direction = ParameterDirection.Output;
        }
        #endregion //Data Access - Insert

        #region Data Access - Update
        internal void Update(SqlTransaction tr, ThueTNCNLuyTienList parent)
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

        private void ExecuteUpdate(SqlTransaction tr, ThueTNCNLuyTienList parent)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_UpdatetblThueTNCNLuyTien";

                AddUpdateParameters(cm, parent);

                cm.ExecuteNonQuery();

            }//using
        }

        private void AddUpdateParameters(SqlCommand cm, ThueTNCNLuyTienList parent)
        {
            cm.Parameters.AddWithValue("@ThueTNCNLuyTien", _thueTNCNLuyTien);
            cm.Parameters.AddWithValue("@MaBoPhan", _maBoPhan);
            cm.Parameters.AddWithValue("@MaKyTinhLuong", _maKyTinhLuong);
            cm.Parameters.AddWithValue("@MaNhanVien", _maNhanVien);
            cm.Parameters.AddWithValue("@NguoiLap", _nguoiLap);
            if (_dienGiai.Length > 0)
                cm.Parameters.AddWithValue("@DienGiai", _dienGiai);
            else
                cm.Parameters.AddWithValue("@DienGiai", DBNull.Value);
            if (_tongThuNhap != 0)
                cm.Parameters.AddWithValue("@TongThuNhap", _tongThuNhap);
            else
                cm.Parameters.AddWithValue("@TongThuNhap", DBNull.Value);
            if (_tongThuNhapChiuThue != 0)
                cm.Parameters.AddWithValue("@TongThuNhapChiuThue", _tongThuNhapChiuThue);
            else
                cm.Parameters.AddWithValue("@TongThuNhapChiuThue", DBNull.Value);
            if (_thueTNCNPhaiNop != 0)
                cm.Parameters.AddWithValue("@ThueTNCNPhaiNop", _thueTNCNPhaiNop);
            else
                cm.Parameters.AddWithValue("@ThueTNCNPhaiNop", DBNull.Value);
            if (_thueTNCNDaNop != 0)
                cm.Parameters.AddWithValue("@ThueTNCNDaNop", _thueTNCNDaNop);
            else
                cm.Parameters.AddWithValue("@ThueTNCNDaNop", DBNull.Value);
            if (_phanTramTinh != 0)
                cm.Parameters.AddWithValue("@PhanTramTinh", _phanTramTinh);
            else
                cm.Parameters.AddWithValue("@PhanTramTinh", DBNull.Value);
            if (_thueTNCNTamNop != 0)
                cm.Parameters.AddWithValue("@ThueTNCNTamNop", _thueTNCNTamNop);
            else
                cm.Parameters.AddWithValue("@ThueTNCNTamNop", DBNull.Value);
            if (_tongTienGiamTru != 0)
                cm.Parameters.AddWithValue("@TongTienGiamTru", _tongTienGiamTru);
            else
                cm.Parameters.AddWithValue("@TongTienGiamTru", DBNull.Value);
            if (_soThangGiamTru != 0)
                cm.Parameters.AddWithValue("@SoThangGiamTru", _soThangGiamTru);
            else
                cm.Parameters.AddWithValue("@SoThangGiamTru", DBNull.Value);
            if (_soNPT != 0)
                cm.Parameters.AddWithValue("@SoNPT", _soNPT);
            else
                cm.Parameters.AddWithValue("@SoNPT", DBNull.Value);
            if (_bhxh != 0)
                cm.Parameters.AddWithValue("@BHXH", _bhxh);
            else
                cm.Parameters.AddWithValue("@BHXH", DBNull.Value);
            if (_bhyt != 0)
                cm.Parameters.AddWithValue("@BHYT", _bhyt);
            else
                cm.Parameters.AddWithValue("@BHYT", DBNull.Value);
            if (_bhtn != 0)
                cm.Parameters.AddWithValue("@BHTN", _bhtn);
            else
                cm.Parameters.AddWithValue("@BHTN", DBNull.Value);
            cm.Parameters.AddWithValue("@NgayLap", _ngayLap.DBValue);
            cm.Parameters.AddWithValue("@NgayTinh", _ngayTinh.DBValue);
            if (_soThang != 0)
                cm.Parameters.AddWithValue("@SoThang", _soThang);
            else
                cm.Parameters.AddWithValue("@SoThang", DBNull.Value);
            if (_daThu != false)
                cm.Parameters.AddWithValue("@DaThu", _daThu);
            else
                cm.Parameters.AddWithValue("@DaThu", DBNull.Value);
            if (_thueTNCNDuocMien != 0)
                cm.Parameters.AddWithValue("@ThueTNCNDuocMien", _thueTNCNDuocMien);
            else
                cm.Parameters.AddWithValue("@ThueTNCNDuocMien", DBNull.Value);
            if (_lanTinhThue != 0)
                cm.Parameters.AddWithValue("@LanTinhThue", _lanTinhThue);
            else
                cm.Parameters.AddWithValue("@LanTinhThue", DBNull.Value);
            if (_soChungTu.Length > 0)
                cm.Parameters.AddWithValue("@SoChungTu", _soChungTu);
            else
                cm.Parameters.AddWithValue("@SoChungTu", DBNull.Value);
            if (_maChungTu != 0)
                cm.Parameters.AddWithValue("@MaChungTu", _maChungTu);
            else
                cm.Parameters.AddWithValue("@MaChungTu", DBNull.Value);
            if (_soTienChuyenTrongDot != 0)
                cm.Parameters.AddWithValue("@SoTienChuyenTrongDot", _soTienChuyenTrongDot);
            else
                cm.Parameters.AddWithValue("@SoTienChuyenTrongDot", DBNull.Value);
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

            ExecuteDelete(tr, new Criteria(_thueTNCNLuyTien));
            MarkNew();
        }
        #endregion //Data Access - Delete
        #endregion //Data Access
    }
}
