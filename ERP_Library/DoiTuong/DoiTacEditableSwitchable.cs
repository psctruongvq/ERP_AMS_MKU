
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;
using System.ComponentModel;

namespace ERP_Library
{
    [Serializable()]
    [TypeConverter(typeof(DoiTacTypeConverter))]
    public class DoiTac : Csla.BusinessBase<DoiTac>
    {
        #region Business Properties and Methods

        //declare members
        private long _maDoiTac = 0;
        private string _maQLDoiTac = string.Empty;
        private string _tenDoiTac = string.Empty;
        private string _tenVietTat = string.Empty;
        private string _maSoThue = string.Empty;
        private bool _tinhTrang = true;
        private int _loaiDoiTac = 0;
        private string _dienGiai = string.Empty;
        private string _nguoiLap = string.Empty;
        private string _diachi = string.Empty;
        private string _dienthoai = string.Empty;
        private string _maBoPHan = string.Empty;
        private string _tenBoPhan = string.Empty;
        private string _cmnd = string.Empty;
        private Nullable<DateTime> _ngayLap = DateTime.Today.Date;
        private string _noiCap = string.Empty;
        private int _maCongTy = ERP_Library.Security.CurrentUser.Info.MaCongTy;
        private bool _ngungSuDung = false;
        private string _maCongTyQuanLy = string.Empty;
        private string _gioiTinh;
        private string _tenLop;
        private string _tenKhoi;
        private string _namHoc;
        private string _tenTruong;
        private DateTime _ngaySinh;
        private string _ten;
        //declare child member(s)
        private NguoiLienLacList _nguoiLienLacList = NguoiLienLacList.NewNguoiLienLacList();
        private DoiTac_DienThoai_FaxList _doiTac_DienThoai_FaxList = DoiTac_DienThoai_FaxList.NewDoiTac_DienThoai_FaxList();
        private TK_NganHangList _tK_NganHangList = TK_NganHangList.NewTK_NganHangList();
        private TKPhu_NganHangList _tkPhu_NganHangList = TKPhu_NganHangList.NewTKPhu_NganHangList();
        private DoiTac_PhuongThucThanhToanList _doiTac_PhuongThucThanhToanList = DoiTac_PhuongThucThanhToanList.NewDoiTac_PhuongThucThanhToanList();
        private DoiTac_Website_EmailList _doiTac_Website_EmailList = DoiTac_Website_EmailList.NewDoiTac_Website_EmailList();
        private DiaChi_DoiTacList _diaChi_DoiTacList = DiaChi_DoiTacList.NewDiaChi_DoiTacList();

        private DoiTuongTheoDoiList _TheoDoiTaiKhoanDoiTuongList = DoiTuongTheoDoiList.NewDoiTuongTheoDoiList();

        private NhaCungCap _nhaCungCap = NhaCungCap.NewNhaCungCap();
        private KhachHang _khachHang = KhachHang.NewKhachHang();

        [System.ComponentModel.DataObjectField(true, false)]

        public bool Check { get; set; }


        public long MaDoiTac
        {
            get
            {
                CanReadProperty("MaDoiTac", true);
                return _maDoiTac;
            }
        }

        public string MaQLDoiTac
        {
            get
            {
                CanReadProperty("MaQLDoiTac", true);
                return _maQLDoiTac;
            }
            set
            {
                CanWriteProperty("MaQLDoiTac", true);
                if (value == null) value = string.Empty;
                if (!_maQLDoiTac.Equals(value))
                {
                    _maQLDoiTac = value;
                    PropertyHasChanged("MaQLDoiTac");
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

        public DateTime? NgayLap
        {
            get
            {
                CanReadProperty("NgayLap", true);
                if (_ngayLap == null)
                    return null;
                return _ngayLap.Value;
            }
            set
            {
                CanWriteProperty(true);
                if (!_ngayLap.Equals(value))
                {
                    _ngayLap = value;
                    PropertyHasChanged("NgayLap");
                }
            }
        }

        public DateTime NgaySinh
        {
            get
            {
                CanReadProperty("NgaySinh", true);
                return _ngaySinh;
            }
            set
            {
                CanWriteProperty(true);
                if (!_ngaySinh.Equals(value))
                {
                    _ngaySinh = value;
                    PropertyHasChanged("NgaySinh");
                }
            }
        }
        public string MaCongTyQuanLy
        {
            get
            {
                CanReadProperty("MaCongTyQuanLy", true);
                return _maCongTyQuanLy;
            }
            set
            {
                CanWriteProperty("GioiTinh", true);
                if (value == null) value = string.Empty;
                if (!_maCongTyQuanLy.Equals(value))
                {
                    _maCongTyQuanLy = value;
                    PropertyHasChanged("MaCongTyQuanLy");
                }
            }
        }
        public string GioiTinh
        {
            get
            {
                CanReadProperty("GioiTinh", true);
                return _gioiTinh;
            }
            set
            {
                CanWriteProperty("GioiTinh", true);
                if (value == null) value = string.Empty;
                if (!_gioiTinh.Equals(value))
                {
                    _gioiTinh = value;
                    PropertyHasChanged("GioiTinh");
                }
            }
        }

        public string TenLop
        {
            get
            {
                CanReadProperty("TenLop", true);
                return _tenLop;
            }
            set
            {
                CanWriteProperty("TenLop", true);
                if (value == null) value = string.Empty;
                if (!_tenLop.Equals(value))
                {
                    _tenLop = value;
                    PropertyHasChanged("TenLop");
                }
            }
        }

        public string Ten
        {
            get
            {
                CanReadProperty("Ten", true);
                return _ten;
            }
            set
            {
                CanWriteProperty("Ten", true);
                if (value == null) value = string.Empty;
                if (!_ten.Equals(value))
                {
                    _ten = value;
                    PropertyHasChanged("Ten");
                }
            }
        }

        public string NamHoc
        {
            get
            {
                CanReadProperty("NamHoc", true);
                return _namHoc;
            }
            set
            {
                CanWriteProperty("NamHoc", true);
                if (value == null) value = string.Empty;
                if (!_namHoc.Equals(value))
                {
                    _namHoc = value;
                    PropertyHasChanged("NamHoc");
                }
            }
        }

        public string TenKhoi
        {
            get
            {
                CanReadProperty("TenKhoi", true);
                return _tenKhoi;
            }
            set
            {
                CanWriteProperty("TenKhoi", true);
                if (value == null) value = string.Empty;
                if (!_tenKhoi.Equals(value))
                {
                    _tenKhoi = value;
                    PropertyHasChanged("TenKhoi");
                }
            }
        }

        public string TenTruong
        {
            get
            {
                CanReadProperty("TenTruong", true);
                return _tenTruong;
            }
            set
            {
                CanWriteProperty("TenTruong", true);
                if (value == null) value = string.Empty;
                if (!_tenTruong.Equals(value))
                {
                    _tenTruong = value;
                    PropertyHasChanged("TenTruong");
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

        public string TenVietTat
        {
            get
            {
                CanReadProperty("TenVietTat", true);
                return _tenVietTat;
            }
            set
            {
                CanWriteProperty("TenVietTat", true);
                if (value == null) value = string.Empty;
                if (!_tenVietTat.Equals(value))
                {
                    _tenVietTat = value;
                    PropertyHasChanged("TenVietTat");
                }
            }
        }

        public string MaSoThue
        {
            get
            {
                CanReadProperty("MaSoThue", true);
                return _maSoThue;
            }
            set
            {
                CanWriteProperty("MaSoThue", true);
                if (value == null) value = string.Empty;
                if (!_maSoThue.Equals(value))
                {
                    _maSoThue = value;
                    PropertyHasChanged("MaSoThue");
                }
            }
        }

        public bool TinhTrang
        {
            get
            {
                CanReadProperty("TinhTrang", true);
                return _tinhTrang;
            }
            set
            {
                CanWriteProperty("TinhTrang", true);
                if (!_tinhTrang.Equals(value))
                {
                    _tinhTrang = value;
                    PropertyHasChanged("TinhTrang");
                }
            }
        }

        public int LoaiDoiTac
        {
            get
            {
                CanReadProperty("LoaiDoiTac", true);
                return _loaiDoiTac;
            }
            set
            {
                CanWriteProperty("LoaiDoiTac", true);
                if (!_loaiDoiTac.Equals(value))
                {
                    _loaiDoiTac = value;
                    PropertyHasChanged("LoaiDoiTac");
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

        public bool NgungSuDung
        {
            get
            {
                CanReadProperty("NgungSuDung", true);
                return _ngungSuDung;
            }
            set
            {
                CanWriteProperty("NgungSuDung", true);
                if (!_ngungSuDung.Equals(value))
                {
                    _ngungSuDung = value;
                    PropertyHasChanged("NgungSuDung");
                }
            }
        }

        public string TenDayDu
        {
            get
            {
                CanReadProperty(true);
                return _maQLDoiTac + " - " + _tenDoiTac;
            }
        }

        public string MaBoPhan
        {
            get
            {
                CanReadProperty(true);
                return _maBoPHan;
            }
        }
        public string TenBoPhan
        {
            get
            {
                CanReadProperty(true);
                return _tenBoPhan;
            }
        }
        public string DiaChi
        {
            get
            {
                CanReadProperty(true);
                return _diachi;
            }
        }

        public string DienThoai
        {
            get
            {
                CanReadProperty(true);
                return _dienthoai;
            }
        }

        public NhaCungCap NhaCungCap
        {
            get
            {
                CanReadProperty("NhaCungCap", true);
                return _nhaCungCap;
            }
        }

        public KhachHang KhachHang
        {
            get
            {
                CanReadProperty("KhachHang", true);
                return _khachHang;
            }
        }

        public NguoiLienLacList NguoiLienLacList
        {
            get
            {
                CanReadProperty("NguoiLienLacList", true);
                return _nguoiLienLacList;
            }
        }

        public DiaChi_DoiTacList DiaChi_DoiTacList
        {
            get
            {
                CanReadProperty("DiaChi_DoiTacList", true);
                return _diaChi_DoiTacList;
            }
        }

        public DoiTac_DienThoai_FaxList DoiTac_DienThoai_FaxList
        {
            get
            {
                CanReadProperty("DoiTac_DienThoai_FaxList", true);
                return _doiTac_DienThoai_FaxList;
            }
        }

        public TK_NganHangList TK_NganHangList
        {
            get
            {
                CanReadProperty("TK_NganHangList", true);
                return _tK_NganHangList;
            }
        }

        public TKPhu_NganHangList tKPhu_NganHangList
        {
            get
            {
                CanReadProperty("tKPhu_NganHangList", true);
                return _tkPhu_NganHangList;
            }
        }

        public DoiTac_PhuongThucThanhToanList DoiTac_PhuongThucThanhToanList
        {
            get
            {
                CanReadProperty("DoiTac_PhuongThucThanhToanList", true);
                return _doiTac_PhuongThucThanhToanList;
            }
        }

        public DoiTac_Website_EmailList DoiTac_Website_EmailList
        {
            get
            {
                CanReadProperty("DoiTac_Website_EmailList", true);
                return _doiTac_Website_EmailList;
            }
        }

        public DoiTuongTheoDoiList TheoDoiTaiKhoanDoiTuongList
        {
            get
            {
                CanReadProperty("TheoDoiTaiKhoanDoiTuongList", true);
                return _TheoDoiTaiKhoanDoiTuongList;
            }
        }

        public override bool IsValid
        {
            get { return base.IsValid || _nguoiLienLacList.IsValid || _doiTac_DienThoai_FaxList.IsValid || _tK_NganHangList.IsValid || _tkPhu_NganHangList.IsValid || _doiTac_PhuongThucThanhToanList.IsValid || _doiTac_Website_EmailList.IsValid || _diaChi_DoiTacList.IsValid || _khachHang.IsValid || _nhaCungCap.IsValid || _TheoDoiTaiKhoanDoiTuongList.IsValid; }
        }

        public override bool IsDirty
        {
            get { return base.IsDirty || _nguoiLienLacList.IsDirty || _doiTac_DienThoai_FaxList.IsDirty || _tK_NganHangList.IsDirty || _tkPhu_NganHangList.IsDirty || _doiTac_PhuongThucThanhToanList.IsDirty || _doiTac_Website_EmailList.IsDirty || _diaChi_DoiTacList.IsDirty || _khachHang.IsDirty || _nhaCungCap.IsDirty || _TheoDoiTaiKhoanDoiTuongList.IsDirty; }
        }

        public string MaQLUser
        {
            get
            {
               // CanReadProperty("MaQLUser", true);
                return _nguoiLap;
            }
            set
            {
                //    CanWriteProperty("MaQLUser", true);
                //    if (!_nguoiLap.Equals(value))
                //    {
                _nguoiLap = value;
            //        PropertyHasChanged("MaQLUser");
            //    }
            }
        }

        protected override object GetIdValue()
        {
            return _maDoiTac;
        }
        public override string ToString()
        {
            return _maQLDoiTac;
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
            // MaQLDoiTac
            //
            ValidationRules.AddRule(CommonRules.StringRequired, "MaQLDoiTac");
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("MaQLDoiTac", 20));
            //
            // TenDoiTac
            //
            ValidationRules.AddRule(CommonRules.StringRequired, "TenDoiTac");
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("TenDoiTac", 500));
            //
            // TenVietTat
            //
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("TenVietTat", 50));
            //
            // MaSoThue
            //
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("MaSoThue", 50));
            //
            // DienGiai
            //
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("DienGiai", 500));
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
            //TODO: Define authorization rules in DoiTac
            //AuthorizationRules.AllowRead("NguoiLienLacList", "DoiTacReadGroup");
            //AuthorizationRules.AllowRead("DoiTac_DienThoai_FaxList", "DoiTacReadGroup");
            //AuthorizationRules.AllowRead("TK_NganHangList", "DoiTacReadGroup");
            //AuthorizationRules.AllowRead("PhuongThucThanhToanList", "DoiTacReadGroup");
            //AuthorizationRules.AllowRead("DoiTac_Website_EmailList", "DoiTacReadGroup");
            //AuthorizationRules.AllowRead("MaDoiTac", "DoiTacReadGroup");
            //AuthorizationRules.AllowRead("MaQLDoiTac", "DoiTacReadGroup");
            //AuthorizationRules.AllowRead("TenDoiTac", "DoiTacReadGroup");
            //AuthorizationRules.AllowRead("TenVietTat", "DoiTacReadGroup");
            //AuthorizationRules.AllowRead("MaSoThue", "DoiTacReadGroup");
            //AuthorizationRules.AllowRead("TinhTrang", "DoiTacReadGroup");
            //AuthorizationRules.AllowRead("LoaiDoiTac", "DoiTacReadGroup");
            //AuthorizationRules.AllowRead("DienGiai", "DoiTacReadGroup");

            //AuthorizationRules.AllowWrite("MaQLDoiTac", "DoiTacWriteGroup");
            //AuthorizationRules.AllowWrite("TenDoiTac", "DoiTacWriteGroup");
            //AuthorizationRules.AllowWrite("TenVietTat", "DoiTacWriteGroup");
            //AuthorizationRules.AllowWrite("MaSoThue", "DoiTacWriteGroup");
            //AuthorizationRules.AllowWrite("TinhTrang", "DoiTacWriteGroup");
            //AuthorizationRules.AllowWrite("LoaiDoiTac", "DoiTacWriteGroup");
            //AuthorizationRules.AllowWrite("DienGiai", "DoiTacWriteGroup");
        }


        public static bool CanGetObject()
        {
            //TODO: Define CanGetObject permission in DoiTac
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("DoiTacViewGroup"))
            //	return true;
            //return false;
        }

        public static bool CanAddObject()
        {
            //TODO: Define CanAddObject permission in DoiTac
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("DoiTacAddGroup"))
            //	return true;
            //return false;
        }

        public static bool CanEditObject()
        {
            //TODO: Define CanEditObject permission in DoiTac
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("DoiTacEditGroup"))
            //	return true;
            //return false;
        }

        public static bool CanDeleteObject()
        {
            //TODO: Define CanDeleteObject permission in DoiTac
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("DoiTacDeleteGroup"))
            //	return true;
            //return false;
        }
        #region KiemTraMST
        public static int KiemTraMST(string maSoThue)
        {
            int gt = 0;
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                try
                {
                    using (SqlCommand cm = cn.CreateCommand())
                    {
                        cm.CommandType = CommandType.StoredProcedure;
                        cm.CommandText = "spd_KiemTraMaSoThue";
                        cm.Parameters.AddWithValue("@MaSoThue", maSoThue);
                        cm.Parameters.AddWithValue("@MaCongTy", ERP_Library.Security.CurrentUser.Info.MaCongTy);
                        cm.Parameters.AddWithValue("@GiaTri", gt);
                        cm.Parameters["@GiaTri"].Direction = ParameterDirection.Output;

                        cm.ExecuteNonQuery();
                        gt = Convert.ToInt32(cm.Parameters["@GiaTri"].Value);
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return gt;
            }//using
        }
        #endregion
        #region KiemTraMaKH
        public static int KiemTraMaKH(string maKhachHang)
        {
            int gt = 0;
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                try
                {
                    using (SqlCommand cm = cn.CreateCommand())
                    {
                        cm.CommandType = CommandType.StoredProcedure;
                        cm.CommandText = "spd_KiemTraMaKhachHang";
                        cm.Parameters.AddWithValue("@MaQLKhachHang", maKhachHang);
                        cm.Parameters.AddWithValue("@MaCongTy", ERP_Library.Security.CurrentUser.Info.MaCongTy);
                        cm.Parameters.AddWithValue("@GiaTri", gt);
                        cm.Parameters["@GiaTri"].Direction = ParameterDirection.Output;

                        cm.ExecuteNonQuery();
                        gt = Convert.ToInt32(cm.Parameters["@GiaTri"].Value);
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return gt;
            }//using
        }
        #endregion

        #region KiemTraMaNCC
        public static int KiemTraMaNCC(string maNhaCungCap)
        {
            int gt = 0;
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                try
                {
                    using (SqlCommand cm = cn.CreateCommand())
                    {
                        cm.CommandType = CommandType.StoredProcedure;
                        cm.CommandText = "spd_KiemTraMaNhaCungCap";
                        cm.Parameters.AddWithValue("@MaQLNhaCungCap", maNhaCungCap);
                        cm.Parameters.AddWithValue("@MaCongTy", ERP_Library.Security.CurrentUser.Info.MaCongTy);
                        cm.Parameters.AddWithValue("@GiaTri", gt);
                        cm.Parameters["@GiaTri"].Direction = ParameterDirection.Output;

                        cm.ExecuteNonQuery();
                        gt = (int)cm.Parameters["@GiaTri"].Value;
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return gt;
            }//using
        }
        #endregion

        #endregion //Authorization Rules

        #region Factory Methods
        public DoiTac()
        { /* require use of factory method */

        }

        public DoiTac(long ma, string ten)
        {
            _maDoiTac = ma;
            _tenDoiTac = ten;
        }

        public DoiTac(string ten)
        {
            _maQLDoiTac = ten;
        }
        public static DoiTac NewDoiTac(long ma, string ten)
        {
            return new DoiTac(ma, ten);
        }

        public static DoiTac NewDoiTac(string ten)
        {
            DoiTac dt = new DoiTac();
            dt._maQLDoiTac = ten;
            return dt;
        }
        //public static DoiTac NewDoiTac(string maquanly)
        //{
        //    DoiTac dt = new DoiTac();
        //    dt._maQLDoiTac = maquanly;
        //    return dt;
        //}

        public static DoiTac NewDoiTac()
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a DoiTac");
            return DataPortal.Create<DoiTac>(new CriteriaAll());
        }
        public static DoiTac GetDoiTac(long maDoiTac)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a DoiTac");
            return DataPortal.Fetch<DoiTac>(new Criteria(maDoiTac));
        }
        public static DoiTac GetDoiTacXuatDongPhuc(string maTruong, long maDoiTac)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a DoiTac");
            return DataPortal.Fetch<DoiTac>(new CriteriaXuatDongPhuc(maTruong, maDoiTac));
        }
        public static DoiTac GetDoiTacbyTenDoiTacForPreviewReport(string tendoitac)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a DoiTac");
            return DataPortal.Fetch<DoiTac>(new CriteriabyTenDoiTacForPreviewReport(tendoitac));
        }

        public static DoiTac GetDoiTacForDeNghiChuyenKhoanHDDV(long maDoiTac)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a DoiTac");
            return DataPortal.Fetch<DoiTac>(new CriteriaForDeNghiChuyenKhoanHDDV(maDoiTac));
        }

        public static DoiTac GetDoiTacWithoutChild(long maDoiTac)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a DoiTac");
            return DataPortal.Fetch<DoiTac>(new CriteriaWithoutChild(maDoiTac));
        }

        public static DoiTac GetDoiTacForDoiTuongTheoDoi(long maDoiTac)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a DoiTac");
            return DataPortal.Fetch<DoiTac>(new CriteriaForDoiTuongTheoDoi(maDoiTac));
        }

        public static DoiTac GetDoiTacWithoutChildbyTenKhachHang(string tenDoiTac)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a DoiTac");
            return DataPortal.Fetch<DoiTac>(new CriteriaWithoutChildbyTenKhachHang(tenDoiTac));
        }

        public static DoiTac GetDoiTacForTaoHoaDonDichVu(long maDoiTac)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a DoiTac");
            return DataPortal.Fetch<DoiTac>(new CriteriaForTaoHoaDonDichVu(maDoiTac));
        }

        public static DoiTac GetDoiTacByMaQLDoiTac(string maQLDoiTac)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a DoiTac");
            return DataPortal.Fetch<DoiTac>(new CriteriaByMaQLDoiTac(maQLDoiTac));
        }

        public static void DeleteDoiTac(long maDoiTac)
        {
            if (!CanDeleteObject())
                throw new System.Security.SecurityException("User not authorized to remove a DoiTac");
            DataPortal.Delete(new Criteria(maDoiTac));
        }

        public override DoiTac Save()
        {
            if (IsDeleted && !CanDeleteObject())
                throw new System.Security.SecurityException("User not authorized to remove a DoiTac");
            else if (IsNew && !CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a DoiTac");
            else if (!CanEditObject())
                throw new System.Security.SecurityException("User not authorized to update a DoiTac");

            return base.Save();
        }

        #endregion //Factory Methods

        #region Child Factory Methods
        private DoiTac(long maDoiTac)
        {
            this._maDoiTac = maDoiTac;
        }

        internal static DoiTac NewDoiTacChild(long maDoiTac)
        {
            DoiTac child = new DoiTac(maDoiTac);
            child.ValidationRules.CheckRules();
            child.MarkAsChild();
            return child;
        }

        internal static DoiTac GetDoiTac(SafeDataReader dr)
        {
            DoiTac child = new DoiTac();
            child.MarkAsChild();
            child.Fetch(dr);
            return child;
        }
        internal static DoiTac GetDoiTacByViewDoiTuong(SafeDataReader dr)
        {
            DoiTac child = new DoiTac();
            child.MarkAsChild();
            child.FetchObjectViewDoiTuong(dr);
            return child;
        }
        internal static DoiTac GetDoiTac_RutGon(SafeDataReader dr)
        {
            DoiTac child = new DoiTac();
            child.MarkAsChild();
            child.FetchByTen(dr);
            return child;
        }

        internal static DoiTac GetDoiTacByTen(SafeDataReader dr)
        {
            DoiTac child = new DoiTac();
            child.MarkAsChild();
            child.FetchByTen(dr);
            return child;
        }

        internal static DoiTac GetHocSinh(SafeDataReader dr)
        {
            DoiTac child = new DoiTac();
            child.MarkAsChild();
            child.FetchHocSinh(dr);
            return child;
        }

        internal static DoiTac GetHocSinhFromBienLai(SafeDataReader dr)
        {
            DoiTac child = new DoiTac();
            child.MarkAsChild();
            child.FetchFromBienLai(dr);
            return child;
        }
        #endregion //Child Factory Methods

        #region Data Access

        #region Criteria

        [Serializable()]
        private class Criteria
        {
            public long MaDoiTac;

            public Criteria(long maDoiTac)
            {
                this.MaDoiTac = maDoiTac;
            }
        }
        private class CriteriaXuatDongPhuc
        {
            public long MaDoiTac;
            public string MaTruong;
            public CriteriaXuatDongPhuc(string maTruong, long maDoiTac)
            {
                this.MaDoiTac = maDoiTac;
                this.MaTruong = maTruong;
            }
        }
        [Serializable()]
        private class CriteriabyTenDoiTacForPreviewReport
        {
            public string TenDoiTac;

            public CriteriabyTenDoiTacForPreviewReport(string tendoitac)
            {
                this.TenDoiTac = tendoitac;
            }
        }

        [Serializable()]
        private class CriteriaForDeNghiChuyenKhoanHDDV
        {
            public long MaDoiTac;

            public CriteriaForDeNghiChuyenKhoanHDDV(long maDoiTac)
            {
                this.MaDoiTac = maDoiTac;
            }
        }
        [Serializable()]
        private class CriteriaWithoutChild
        {
            public long MaDoiTac;

            public CriteriaWithoutChild(long maDoiTac)
            {
                this.MaDoiTac = maDoiTac;
            }
        }

        [Serializable()]
        private class CriteriaForDoiTuongTheoDoi
        {
            public long MaDoiTac;

            public CriteriaForDoiTuongTheoDoi(long maDoiTac)
            {
                this.MaDoiTac = maDoiTac;
            }
        }

        [Serializable()]
        private class CriteriaWithoutChildbyTenKhachHang
        {
            public string TenDoiTac;

            public CriteriaWithoutChildbyTenKhachHang(string tendoitac)
            {
                this.TenDoiTac = tendoitac;
            }
        }

        [Serializable()]
        private class CriteriaForTaoHoaDonDichVu
        {
            public long MaDoiTac;

            public CriteriaForTaoHoaDonDichVu(long maDoiTac)
            {
                this.MaDoiTac = maDoiTac;
            }
        }

        [Serializable()]
        private class CriteriaByMaQLDoiTac
        {
            public string MaQLDoiTac;

            public CriteriaByMaQLDoiTac(string maQLDoiTac)
            {
                this.MaQLDoiTac = maQLDoiTac;
            }
        }

        [Serializable()]
        private class CriteriaAll
        {

            public CriteriaAll()
            {

            }
        }
        #endregion //Criteria

        #region Data Access - Create
        [RunLocal]
        private void DataPortal_Create(CriteriaAll criteria1)
        {
            //_maDoiTac = criteria.MaDoiTac;
            //_nguoiLienLacList = NguoiLienLacList.NewNguoiLienLacList();
            //_tK_NganHangList = TK_NganHangList.NewTK_NganHangList();
            //_phuongThucThanhToanList = PhuongThucThanhToanList.NewPhuongThucThanhToanList();
            //_doiTac_DienThoai_FaxList = DoiTac_DienThoai_FaxList.NewDoiTac_DienThoai_FaxList();
            //_doiTac_Website_EmailList = DoiTac_Website_EmailList.NewDoiTac_Website_EmailList();
            //_diaChi_DoiTacList = DiaChi_DoiTacList.NewDiaChi_DoiTacList();
            // _nhaCungCap = NhaCungCap.NewNhaCungCap(0);

            ValidationRules.CheckRules();
        }

        #endregion //Data Access - Create

        #region Data Access - Fetch
        private void DataPortal_Fetch(object criteria)
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

        private void ExecuteFetch(SqlTransaction tr, object criteria)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                #region BS
                if (criteria is CriteriaWithoutChildbyTenKhachHang)
                {
                    cm.CommandText = "spd_SelecttblDoiTacbyTenDoiTacForHoaDonThue";
                    cm.Parameters.AddWithValue("@TenDoiTac", ((CriteriaWithoutChildbyTenKhachHang)criteria).TenDoiTac);

                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                        {
                            FetchObject(dr);
                            ValidationRules.CheckRules();
                        }
                    }
                    return;
                }

                if (criteria is CriteriaForDoiTuongTheoDoi)
                {
                    cm.CommandText = "spd_SelecttblDoiTacForDoiTuongTheoDoi";
                    cm.Parameters.AddWithValue("@MaDoiTac", ((CriteriaForDoiTuongTheoDoi)criteria).MaDoiTac);

                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                        {
                            FetchObject(dr);
                            ValidationRules.CheckRules();
                        }
                    }
                    return;
                }
                #endregion//BS



                if (criteria is Criteria)
                {
                    //cm.CommandText = "spd_SelecttblDoiTac";
                    cm.CommandText = "spd_SelecttblDoiTac_1";
                    //cm.Parameters.AddWithValue("@MaDoiTac", criteria.MaDoiTac);
                    cm.Parameters.AddWithValue("@MaDoiTac", ((Criteria)criteria).MaDoiTac);

                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                        {
                            FetchObjectCMND(dr);
                            ValidationRules.CheckRules();

                            //load child object(s)
                            FetchChildren(_maDoiTac);
                        }
                    }
                }
                if (criteria is CriteriabyTenDoiTacForPreviewReport)
                {
                    cm.CommandText = "spd_SelecttblDoiTacbyTenDoiTacForPreviewReport";
                    cm.Parameters.AddWithValue("@TenDoiTac", ((CriteriabyTenDoiTacForPreviewReport)criteria).TenDoiTac);

                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                        {
                            FetchObject(dr);
                            ValidationRules.CheckRules();

                            //load child object(s)
                            FetchChildren(_maDoiTac);
                        }
                    }
                }
                else if (criteria is CriteriaWithoutChild)
                {
                    cm.CommandText = "spd_SelecttblDoiTac";
                    cm.Parameters.AddWithValue("@MaDoiTac", ((CriteriaWithoutChild)criteria).MaDoiTac);

                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                        {
                            FetchObject(dr);
                            ValidationRules.CheckRules();
                        }
                    }
                }
                else if (criteria is CriteriaForDeNghiChuyenKhoanHDDV)
                {
                    cm.CommandText = "spd_SelecttblDoiTac";
                    cm.Parameters.AddWithValue("@MaDoiTac", ((CriteriaForDeNghiChuyenKhoanHDDV)criteria).MaDoiTac);

                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                        {
                            FetchObject(dr);
                            ValidationRules.CheckRules();

                            //load child object(s)
                            FetchChildrenForDeNghiChuyenKhoanHDDV(_maDoiTac);
                        }
                    }
                }
                else if (criteria is CriteriaForTaoHoaDonDichVu)
                {
                    cm.CommandText = "spd_SelecttblDoiTac";
                    cm.Parameters.AddWithValue("@MaDoiTac", ((CriteriaForTaoHoaDonDichVu)criteria).MaDoiTac);

                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                        {
                            FetchObject(dr);
                            ValidationRules.CheckRules();

                            //load child object(s)
                            FetchChildrenForTaoHoaDonDichVu(_maDoiTac);
                        }
                    }
                }
                else if (criteria is CriteriaByMaQLDoiTac)
                {
                    cm.CommandText = "spd_SelecttblDoiTac";
                    cm.Parameters.AddWithValue("@MaQLDoiTac", ((CriteriaByMaQLDoiTac)criteria).MaQLDoiTac);

                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                        {
                            FetchObject(dr);
                            ValidationRules.CheckRules();

                            //load child object(s)
                            FetchChildrenForTaoHoaDonDichVu(_maDoiTac);
                        }
                    }
                }
                else if (criteria is CriteriaXuatDongPhuc)
                {
                    //cm.CommandText = "spd_SelecttblDoiTac";
                    cm.CommandText = "spd_GetHocSinhFromBienLai_byMaDoiTac";
                    //cm.Parameters.AddWithValue("@MaDoiTac", criteria.MaDoiTac);
                    cm.Parameters.AddWithValue("@MaDoiTac", ((CriteriaXuatDongPhuc)criteria).MaDoiTac);
                    cm.Parameters.AddWithValue("@MaTruong", ((CriteriaXuatDongPhuc)criteria).MaTruong);
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                        {
                            FetchFromBienLai(dr);
                            ValidationRules.CheckRules();
                        }
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
                    ExecuteInsert(tr);

                    //update child object(s)
                    UpdateChildren(tr);

                    tr.Commit();
                }
                catch (Exception ex)
                {
                    tr.Rollback();
                    throw ex;
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
                        ExecuteUpdate(tr);
                    }

                    //update child object(s)
                    UpdateChildren(tr);

                    tr.Commit();
                }
                catch (Exception ex)
                {
                    tr.Rollback();
                    throw ex;
                }
            }//using

        }

        #endregion //Data Access - Update

        #region Data Access - Delete
        protected override void DataPortal_DeleteSelf()
        {
            DataPortal_Delete(new Criteria(_maDoiTac));
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
                cm.CommandText = "spd_DeletetblDoiTac";

                cm.Parameters.AddWithValue("@MaDoiTac", criteria.MaDoiTac);

                cm.ExecuteNonQuery();
            }//using
        }
        #endregion //Data Access - Delete

        #region Data Access - Fetch

        private void Fetch(SafeDataReader dr)
        {
            FetchObject(dr);
            MarkOld();
            //ValidationRules.CheckRules();

            //load child object(s)
            FetchChildren(_maDoiTac);
        }
        private void FetchByTen(SafeDataReader dr)
        {
            FetchObject(dr);
            MarkOld();
        }
        private void FetchHocSinh(SafeDataReader dr)
        {
            FetchObjectHocSinh(dr);
            MarkOld();
        }
        private void FetchFromBienLai(SafeDataReader dr)
        {
            FetchObjectBienLai(dr);
            MarkOld();
        }

        private void FetchObjectBienLai(SafeDataReader dr)
        {
            _maQLDoiTac = dr.GetString("MaHocSinh");
            _tenDoiTac = dr.GetString("HoTen");
            _ngaySinh = dr.GetDateTime("BirthDay");
            _gioiTinh = dr.GetString("GenderName");
            _tenLop = dr.GetString("TenLop");
            _tenKhoi = dr.GetString("TenKhoi");
            _maDoiTac = dr.GetInt64("MaDoiTac");
            _namHoc = dr.GetString("NamHoc");
            _tenTruong = dr.GetString("TenTruong");
            _ten = dr.GetString("Ten");
        }

        private void FetchObject(SafeDataReader dr)
        {
            _maDoiTac = dr.GetInt64("MaDoiTac");
            _maQLDoiTac = dr.GetString("MaQLDoiTac");
            _tenDoiTac = dr.GetString("TenDoiTac");
            _tenVietTat = dr.GetString("TenVietTat");
            _maSoThue = dr.GetString("MaSoThue");
            _tinhTrang = dr.GetBoolean("TinhTrang");
            _loaiDoiTac = dr.GetInt32("LoaiDoiTac");
            _maCongTy = dr.GetInt32("MaCongTy");
            _dienGiai = dr.GetString("DienGiai");

            _diachi = dr.GetString("diachi");
            _dienthoai = dr.GetString("DienThoai");
            _nguoiLap = dr.GetString("NguoiLap");
            _maBoPHan = dr.GetString("MaBoPhanQL");
            _tenBoPhan = dr.GetString("TenBoPhan");
            _ngungSuDung = dr.GetBoolean("NgungSuDung");
            _maCongTyQuanLy = dr.GetString("MaCongTyQuanLy");
            if (dr.GetValue("NgayLap") == null)
                _ngayLap = null;
            else
            _ngayLap = dr.GetDateTime("NgayLap");
        }
        private void FetchObjectViewDoiTuong(SafeDataReader dr)
        {
            _maDoiTac = dr.GetInt64("MaDoiTac");
            _maQLDoiTac = dr.GetString("MaQLDoiTac");
            _tenDoiTac = dr.GetString("TenDoiTac");
            _tenVietTat = dr.GetString("TenVietTat");
            _maSoThue = dr.GetString("MaSoThue");
            _tinhTrang = dr.GetBoolean("TinhTrang");
            _loaiDoiTac = dr.GetInt32("LoaiDoiTac");
            _maCongTy = dr.GetInt32("MaCongTy");
            _dienGiai = dr.GetString("DienGiai");

            _diachi = dr.GetString("diachi");
            _dienthoai = dr.GetString("DienThoai");

            _maBoPHan = dr.GetString("MaBoPhanQL");
            _tenBoPhan = dr.GetString("TenBoPhan");
            _ngungSuDung = dr.GetBoolean("NgungSuDung");

            MarkOld();
        }

        private void FetchObjectHocSinh(SafeDataReader dr)
        {
            _maQLDoiTac = dr.GetString("MaQLDoiTac");
            _tenDoiTac = dr.GetString("TenDoiTac");
            _tenTruong = dr.GetString("MaTruongHocSinh");
        }

        private void FetchObjectCMND(SafeDataReader dr)
        {
            _maDoiTac = dr.GetInt64("MaDoiTac");
            _maQLDoiTac = dr.GetString("MaQLDoiTac");
            _tenDoiTac = dr.GetString("TenDoiTac");
            _tenVietTat = dr.GetString("TenVietTat");
            _maSoThue = dr.GetString("MaSoThue");
            _tinhTrang = dr.GetBoolean("TinhTrang");
            _loaiDoiTac = dr.GetInt32("LoaiDoiTac");
            _maCongTy = dr.GetInt32("MaCongTy");
            _dienGiai = dr.GetString("DienGiai");

            _diachi = dr.GetString("diachi");
            _dienthoai = dr.GetString("DienThoai");

            _maBoPHan = dr.GetString("MaBoPhanQL");
            _tenBoPhan = dr.GetString("TenBoPhan");
            _ngungSuDung = dr.GetBoolean("NgungSuDung");

            _cmnd = dr.GetString("CMNDDoiTac");
            if (dr.GetValue("NgayLap") == null)
                _ngayLap = null;
            else
                _ngayLap = dr.GetDateTime("NgayLap");
            _noiCap = dr.GetString("NoiCap");

        }

        private void FetchChildren(long madoitac)
        {
            #region Old
            //if (_loaiDoiTac == 1)//Nha Cung Cap
            //{
            //    _nhaCungCap = NhaCungCap.GetNhaCungCap(madoitac);
            //    _nguoiLienLacList = NguoiLienLacList.GetNguoiLienLacList(madoitac);
            //    _doiTac_DienThoai_FaxList = DoiTac_DienThoai_FaxList.GetDoiTac_DienThoai_FaxList(madoitac);
            //    _tK_NganHangList = TK_NganHangList.GetTK_NganHangList(madoitac);
            //    _tkPhu_NganHangList = TKPhu_NganHangList.GetTKPhu_NganHangList(madoitac);
            //    _doiTac_PhuongThucThanhToanList = DoiTac_PhuongThucThanhToanList.GetDoiTac_PhuongThucThanhToanList(madoitac);
            //    _doiTac_Website_EmailList = DoiTac_Website_EmailList.GetDoiTac_Website_EmailList(madoitac);
            //    _diaChi_DoiTacList = DiaChi_DoiTacList.GetDiaChi_DoiTacList(madoitac);

            //    _TheoDoiTaiKhoanDoiTuongList = DoiTuongTheoDoiList.GetDoiTuongTheoDoiListByMaDoiTuong(madoitac);

            //}
            //else if (_loaiDoiTac == 2 || _loaiDoiTac == 3)//Khach Hang
            //{
            //    _khachHang = KhachHang.GetKhachHang(madoitac);
            //    _nguoiLienLacList = NguoiLienLacList.GetNguoiLienLacList(madoitac);
            //    _doiTac_DienThoai_FaxList = DoiTac_DienThoai_FaxList.GetDoiTac_DienThoai_FaxList(madoitac);
            //    _tK_NganHangList = TK_NganHangList.GetTK_NganHangList(madoitac);
            //    _tkPhu_NganHangList = TKPhu_NganHangList.GetTKPhu_NganHangList(madoitac);
            //    _doiTac_PhuongThucThanhToanList = DoiTac_PhuongThucThanhToanList.GetDoiTac_PhuongThucThanhToanList(madoitac);
            //    _doiTac_Website_EmailList = DoiTac_Website_EmailList.GetDoiTac_Website_EmailList(madoitac);
            //    _diaChi_DoiTacList = DiaChi_DoiTacList.GetDiaChi_DoiTacList(madoitac);

            //    _TheoDoiTaiKhoanDoiTuongList = DoiTuongTheoDoiList.GetDoiTuongTheoDoiListByMaDoiTuong(madoitac);

            //}
            #endregion//Old

            #region Modify
            _nhaCungCap = NhaCungCap.GetNhaCungCap(madoitac);
            _nguoiLienLacList = NguoiLienLacList.GetNguoiLienLacList(madoitac);
            _doiTac_DienThoai_FaxList = DoiTac_DienThoai_FaxList.GetDoiTac_DienThoai_FaxList(madoitac);
            _tK_NganHangList = TK_NganHangList.GetTK_NganHangList(madoitac);
            _tkPhu_NganHangList = TKPhu_NganHangList.GetTKPhu_NganHangList(madoitac);
            _doiTac_PhuongThucThanhToanList = DoiTac_PhuongThucThanhToanList.GetDoiTac_PhuongThucThanhToanList(madoitac);
            _doiTac_Website_EmailList = DoiTac_Website_EmailList.GetDoiTac_Website_EmailList(madoitac);
            _diaChi_DoiTacList = DiaChi_DoiTacList.GetDiaChi_DoiTacList(madoitac);

            _TheoDoiTaiKhoanDoiTuongList = DoiTuongTheoDoiList.GetDoiTuongTheoDoiListByMaDoiTuong(madoitac);

            _khachHang = KhachHang.GetKhachHang(madoitac);
            _nguoiLienLacList = NguoiLienLacList.GetNguoiLienLacList(madoitac);
            _doiTac_DienThoai_FaxList = DoiTac_DienThoai_FaxList.GetDoiTac_DienThoai_FaxList(madoitac);
            _tK_NganHangList = TK_NganHangList.GetTK_NganHangList(madoitac);
            _tkPhu_NganHangList = TKPhu_NganHangList.GetTKPhu_NganHangList(madoitac);
            _doiTac_PhuongThucThanhToanList = DoiTac_PhuongThucThanhToanList.GetDoiTac_PhuongThucThanhToanList(madoitac);
            _doiTac_Website_EmailList = DoiTac_Website_EmailList.GetDoiTac_Website_EmailList(madoitac);
            _diaChi_DoiTacList = DiaChi_DoiTacList.GetDiaChi_DoiTacList(madoitac);

            _TheoDoiTaiKhoanDoiTuongList = DoiTuongTheoDoiList.GetDoiTuongTheoDoiListByMaDoiTuong(madoitac);


            #endregion//Modify
        }

        private void FetchChildrenForDeNghiChuyenKhoanHDDV(long madoitac)
        {
            _tK_NganHangList = TK_NganHangList.GetTK_NganHangList(madoitac);
            _tkPhu_NganHangList = TKPhu_NganHangList.GetTKPhu_NganHangList(madoitac);
        }

        private void FetchChildrenForTaoHoaDonDichVu(long madoitac)
        {
            _doiTac_DienThoai_FaxList = DoiTac_DienThoai_FaxList.GetDoiTac_DienThoai_FaxList(madoitac);
            _diaChi_DoiTacList = DiaChi_DoiTacList.GetDiaChi_DoiTacList(madoitac);
        }
        #endregion //Data Access - Fetch

        #region Data Access - Insert
        internal void Insert(SqlTransaction tr)
        {
            if (!IsDirty) return;

            ExecuteInsert(tr);
            MarkOld();

            //update child object(s)
            UpdateChildren(tr);
        }

        private void ExecuteInsert(SqlTransaction tr)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                //cm.CommandText = "spd_InserttblDoiTac";
                cm.CommandText = "spd_InserttblDoiTac_1";

                AddInsertParameters(cm);

                cm.ExecuteNonQuery();
                _maDoiTac = (long)cm.Parameters["@MaDoiTuong"].Value;

            }//using
        }

        private void AddInsertParameters(SqlCommand cm)
        {
            cm.Parameters.AddWithValue("@MaDoiTuong", _maDoiTac);
            cm.Parameters["@MaDoiTuong"].Direction = ParameterDirection.Output;
            if (_maQLDoiTac.Length > 0)
                cm.Parameters.AddWithValue("@MaQLDoiTac", _maQLDoiTac);
            else
                cm.Parameters.AddWithValue("@MaQLDoiTac", DBNull.Value);
            cm.Parameters.AddWithValue("@Loai", 1);
            cm.Parameters.AddWithValue("@TenDoiTac", _tenDoiTac);
            cm.Parameters.AddWithValue("@TenVietTat", _tenVietTat);
            if (_maSoThue.Length > 0)
                cm.Parameters.AddWithValue("@MaSoThue", _maSoThue);
            else
                cm.Parameters.AddWithValue("@MaSoThue", DBNull.Value);
            cm.Parameters.AddWithValue("@TinhTrang", _tinhTrang);
            cm.Parameters.AddWithValue("@NgungSuDung", _ngungSuDung);
            if (_loaiDoiTac != 0)
                cm.Parameters.AddWithValue("@LoaiDoiTac", _loaiDoiTac);
            else
                cm.Parameters.AddWithValue("@LoaiDoiTac", false);
            if (_dienGiai.Length > 0)
                cm.Parameters.AddWithValue("@DienGiai", _dienGiai);
            else
                cm.Parameters.AddWithValue("@DienGiai", DBNull.Value);

            cm.Parameters.AddWithValue("@MaCongTy", _maCongTy);

            if (_cmnd.Length > 0)
                cm.Parameters.AddWithValue("@CMND", _cmnd);
            else
                cm.Parameters.AddWithValue("@CMND", DBNull.Value);
            if (_ngayLap != null)
                cm.Parameters.AddWithValue("@NgayLap", _ngayLap.Value);
            else cm.Parameters.AddWithValue("@NgayLap", DBNull.Value);

            if (_noiCap.Length > 0)
                cm.Parameters.AddWithValue("@NoiCap", _noiCap);
            else
                cm.Parameters.AddWithValue("@NoiCap", DBNull.Value);

            cm.Parameters.AddWithValue("@MaNguoiLap", Security.CurrentUser.Info.UserID);
            cm.Parameters.AddWithValue("@MaBoPhan", Security.CurrentUser.Info.MaBoPhan);
            cm.Parameters.AddWithValue("@TenBoPhan", Security.CurrentUser.Info.TenBoPhan);

        }
        #endregion //Data Access - Insert

        #region Data Access - Update
        internal void Update(SqlTransaction tr)
        {
            if (!IsDirty) return;

            if (base.IsDirty)
            {
                ExecuteUpdate(tr);
                MarkOld();

                UpdateChildren(tr);
            }

            //update child object(s)
            //UpdateChildren(tr);
        }

        private void ExecuteUpdate(SqlTransaction tr)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                //cm.CommandText = "spd_UpdatetblDoiTac";
                cm.CommandText = "spd_UpdatetblDoiTac_1";

                AddUpdateParameters(cm);

                cm.ExecuteNonQuery();

            }//using
        }

        private void AddUpdateParameters(SqlCommand cm)
        {
            cm.Parameters.AddWithValue("@MaDoiTac", _maDoiTac);
            if (_maQLDoiTac.Length > 0)
                cm.Parameters.AddWithValue("@MaQLDoiTac", _maQLDoiTac);
            else
                cm.Parameters.AddWithValue("@MaQLDoiTac", DBNull.Value);
            cm.Parameters.AddWithValue("@TenDoiTac", _tenDoiTac);
            cm.Parameters.AddWithValue("@TenVietTat", _tenVietTat);
            if (_maSoThue.Length > 0)
                cm.Parameters.AddWithValue("@MaSoThue", _maSoThue);
            else
                cm.Parameters.AddWithValue("@MaSoThue", DBNull.Value);
            cm.Parameters.AddWithValue("@TinhTrang", _tinhTrang);
            cm.Parameters.AddWithValue("@NgungSuDung", _ngungSuDung);
            if (_loaiDoiTac != 0)
                cm.Parameters.AddWithValue("@LoaiDoiTac", _loaiDoiTac);
            else
                cm.Parameters.AddWithValue("@LoaiDoiTac", false);
            if (_dienGiai.Length > 0)
                cm.Parameters.AddWithValue("@DienGiai", _dienGiai);
            else
                cm.Parameters.AddWithValue("@DienGiai", DBNull.Value);

            if (_cmnd.Length > 0)
                cm.Parameters.AddWithValue("@CMND", _cmnd);
            else
                cm.Parameters.AddWithValue("@CMND", DBNull.Value);
            if (_ngayLap != null)
                cm.Parameters.AddWithValue("@NgayLap", _ngayLap.Value);
            else cm.Parameters.AddWithValue("@NgayLap", DBNull.Value);

            if (_noiCap.Length > 0)
                cm.Parameters.AddWithValue("@NoiCap", _noiCap);
            else
                cm.Parameters.AddWithValue("@NoiCap", DBNull.Value);


            cm.Parameters.AddWithValue("@MaNguoiLap", Security.CurrentUser.Info.UserID);
            cm.Parameters.AddWithValue("@MaBoPhan", Security.CurrentUser.Info.MaBoPhan);
            cm.Parameters.AddWithValue("@TenBoPhan", Security.CurrentUser.Info.TenBoPhan);

            cm.Parameters.AddWithValue("@MaCongTy", _maCongTy);
        }

        private void UpdateChildren(SqlTransaction tr)
        {
            _nguoiLienLacList.Update(tr, this);
            _doiTac_DienThoai_FaxList.Update(tr, this);
            _tK_NganHangList.Update(tr, this);
            _tkPhu_NganHangList.Update(tr, this);
            _doiTac_PhuongThucThanhToanList.Update(tr, this);
            _doiTac_Website_EmailList.Update(tr, this);
            _diaChi_DoiTacList.Update(tr, this);

            _TheoDoiTaiKhoanDoiTuongList.Update(tr, this);

            if (_loaiDoiTac == 2 || _loaiDoiTac == 3)///Khach Hang
            {
                if (this.IsDeleted == false && _khachHang.IsNew)
                {
                    _khachHang.Insert(tr, this);
                }
                else if (_khachHang.IsDeleted)
                {
                    _khachHang.DeleteSelf(tr);
                }
                else
                {
                    _khachHang.Update(tr, this);
                }
            }
            else if (_loaiDoiTac == 1)
            {
                if (this.IsDeleted == false && _nhaCungCap.IsNew && _nhaCungCap.MaNhaCungCap == 0)
                {
                    _nhaCungCap.Insert(tr, this);
                    _khachHang.Insert(tr, this);
                }
                else if (_nhaCungCap.IsDeleted)
                {
                    _nhaCungCap.DeleteSelf(tr);
                    _khachHang.DeleteSelf(tr);
                }
                else
                {
                    _nhaCungCap.Update(tr, this);
                    _khachHang.Update(tr, this);
                }
            }

        }
        #endregion //Data Access - Update

        #region Data Access - Delete
        internal void DeleteSelf(SqlTransaction tr)
        {
            //if (!IsDirty) return;
            if (IsNew) return;

            _khachHang.Delete();
            _nhaCungCap.Delete();
            //_nhaCungCap.Delete();           
            _nguoiLienLacList.Clear();
            _doiTac_DienThoai_FaxList.Clear();
            _tK_NganHangList.Clear();
            _tkPhu_NganHangList.Clear();
            _doiTac_PhuongThucThanhToanList.Clear();
            _doiTac_Website_EmailList.Clear();
            _diaChi_DoiTacList.Clear();

            _TheoDoiTaiKhoanDoiTuongList.Clear();

            UpdateChildren(tr);
            ExecuteDelete(tr, new Criteria(_maDoiTac));
            MarkNew();
        }
        #endregion //Data Access - Delete

        #endregion //Data Access

        #region MaKhachHangTuDongTang
        internal static string MaKhachHangTuDongTang( int loaiDoiTac)
        {
            string giaTriTraVe = string.Empty;
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_LayKhachHangLonNhat";
                    cm.Parameters.AddWithValue("@LoaiDoiTac", loaiDoiTac);
                    SqlParameter prmGiaTriTraVe = new SqlParameter("@GiaTri", SqlDbType.VarChar, 30);
                    prmGiaTriTraVe.Direction = ParameterDirection.Output;
                    cm.Parameters.Add(prmGiaTriTraVe);
                    cm.ExecuteNonQuery();
                    if (prmGiaTriTraVe.Value != null)
                    {
                        giaTriTraVe = (string)prmGiaTriTraVe.Value;
                    }
                }
            }//us
            return giaTriTraVe;
        }
        #endregion

        #region MaKhachHangTuDong
        public static string MaKhachHangTuDong( int loaiDoiTac)
        {
            #region Modify
            string MaKhachHangLonNhat;
            int temp;
            string GiaTriTraVe;

            MaKhachHangLonNhat = MaKhachHangTuDongTang( loaiDoiTac);
            if (MaKhachHangLonNhat != "")
            {
                GiaTriTraVe = MaKhachHangLonNhat;
                return GiaTriTraVe;
            }
            else
                return "";
            #endregion//Modify

            #region Old
            //string MaKhachHangLonNhat;
            //int temp;
            //string GiaTriTraVe;

            //MaKhachHangLonNhat = MaKhachHangTuDongTang(maCongTy, loaiDoiTac);
            //if (MaKhachHangLonNhat != "")
            //{
            //    temp = Convert.ToInt32(MaKhachHangLonNhat.Substring(4));
            //    temp = temp + 1;
            //    if (temp < 10)
            //    {
            //        GiaTriTraVe = MaKhachHangLonNhat.Substring(0, 4) + "000" + temp.ToString();
            //    }
            //    else if (temp < 100)
            //    {
            //        GiaTriTraVe = MaKhachHangLonNhat.Substring(0, 4) + "00" + temp.ToString();
            //    }
            //    else if (temp < 1000)
            //    {
            //        GiaTriTraVe = MaKhachHangLonNhat.Substring(0, 4) + "0" + temp.ToString();
            //    }
            //    else
            //    {
            //        GiaTriTraVe = MaKhachHangLonNhat.Substring(0, 4) + temp.ToString();
            //    }
            //    return GiaTriTraVe;
            //}
            //else
            //    return "";
            #endregion//Old
        }
        #endregion

        public static bool GopKhachHang(long makhchinh, long makhloaibo)
        {
            SqlTransaction tr;

            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                tr = cn.BeginTransaction();
                try
                {
                    using (SqlCommand cm = tr.Connection.CreateCommand())
                    {
                        cm.Transaction = tr;
                        cm.CommandType = CommandType.StoredProcedure;
                        cm.CommandText = "spd_UpdatetblDoiTac_DungChinh";
                        cm.Parameters.AddWithValue("@MaKhChinh", makhchinh);
                        cm.Parameters.AddWithValue("@MaKhLoaiBo", makhloaibo);
                        cm.ExecuteNonQuery();

                    }//using
                    tr.Commit();
                    return true;
                }
                catch (Exception ex)
                {
                    tr.Rollback();
                    return false;
                    throw ex;
                }
            }

        }
        public static bool kiemtramasothue(long maKhachHang, string masothue)
        {

            int sorecord = 0;
            if (masothue != "")
            {
                using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
                {
                    cn.Open();
                    using (SqlCommand cm = cn.CreateCommand())
                    {
                        cm.CommandType = CommandType.StoredProcedure;
                        cm.CommandText = "spd_kiemtramasothuedoitac";
                        cm.Parameters.AddWithValue("@masothue", masothue);
                        cm.Parameters.AddWithValue("@maKhachHang", maKhachHang);
                        cm.Parameters.AddWithValue("@mabophan", ERP_Library.Security.CurrentUser.Info.MaBoPhan);
                        sorecord = (int)cm.ExecuteScalar();
                    }
                    if (sorecord != 0) return true;
                }
            }
            return false;
        }
    }
    #region Type Converter

    public class DoiTacTypeConverter : TypeConverter
    {

        public override object ConvertTo(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value, Type destinationType)
        {
            if (destinationType == typeof(Int32))
            {
                return ((DoiTac)value).MaDoiTac;
            }
            if (destinationType == typeof(String))
            {
                return ((DoiTac)value).TenDoiTac;
            }
            if (destinationType == typeof(Object))
            {
                return ((DoiTac)value).MaQLDoiTac;
            }
            return value;

        }
        public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
        {
            if (destinationType == typeof(Int32))
            {
                return true;
            }
            else if (destinationType == typeof(String))
            {
                return true;
            }
            else if (destinationType == typeof(Object))
            {
                return true;
            }
            return false;
        }

        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            if (sourceType == typeof(Int32))
            {
                return true;
            }
            else return false;
        }
    }
    #endregion



}
