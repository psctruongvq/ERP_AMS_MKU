
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{
    [Serializable()]
    public class HangHoaBQ_VT : Csla.BusinessBase<HangHoaBQ_VT>
    {
        #region Business Properties and Methods

        //declare members
        private int _maHangHoa = 0;
        private string _maQuanLy = string.Empty;
        private string _tenHangHoa = string.Empty;
        private int _maDonViTinh = 0;
        private int _maNhomHangHoa = 0;
        private int _maQuocGia = 0;
        private string _tenHangSanXuat = string.Empty;
        private bool _tinhTrang = true;
        private string _dienGiai = string.Empty;
        private decimal _thoiLuong = 0;
        private SmartDate _ngayLap = new SmartDate(false);
        private decimal _donGiaGoc = 0;
        private decimal _soLuongTon = 0;
        private int _taiKhoanKho = 0;
        private int _taiKhoanPhanBo = 0;
        private int _taiKhoanChoPhanBo = 0;
        [System.ComponentModel.DataObjectField(true, true)]
        public int MaHangHoa
        {
            get
            {
                CanReadProperty("MaHangHoa", true);
                return _maHangHoa;
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

        public string TenHangHoa
        {
            get
            {
                CanReadProperty("TenHangHoa", true);
                return _tenHangHoa;
            }
            set
            {
                CanWriteProperty("TenHangHoa", true);
                if (value == null) value = string.Empty;
                if (!_tenHangHoa.Equals(value))
                {
                    _tenHangHoa = value;
                    PropertyHasChanged("TenHangHoa");
                }
            }
        }

        public decimal SoLuongTon
        {
            get
            {
                CanReadProperty("SoLuongTon", true);
                return _soLuongTon;
            }
            set
            {
                CanWriteProperty("SoLuongTon", true);
                if (!_soLuongTon.Equals(value))
                {
                    _soLuongTon = value;
                    PropertyHasChanged("SoLuongTon");
                }
            }
        }

        public decimal DonGiaGoc
        {
            get
            {
                CanReadProperty("DonGiaGoc", true);
                return _donGiaGoc;
            }
            set
            {
                CanWriteProperty("DonGiaGoc", true);
                if (!_donGiaGoc.Equals(value))
                {
                    _donGiaGoc = value;
                    PropertyHasChanged("DonGiaGoc");
                }
            }
        }

        public int MaDonViTinh
        {
            get
            {
                CanReadProperty("MaDonViTinh", true);
                return _maDonViTinh;
            }
            set
            {
                CanWriteProperty("MaDonViTinh", true);
                if (!_maDonViTinh.Equals(value))
                {
                    _maDonViTinh = value;
                    PropertyHasChanged("MaDonViTinh");
                }
            }
        }

        public int MaNhomHangHoa
        {
            get
            {
                CanReadProperty("MaNhomHangHoa", true);
                return _maNhomHangHoa;
            }
            set
            {
                CanWriteProperty("MaNhomHangHoa", true);
                if (!_maNhomHangHoa.Equals(value))
                {
                    _maNhomHangHoa = value;
                    PropertyHasChanged("MaNhomHangHoa");
                }
            }
        }

        public int MaQuocGia
        {
            get
            {
                CanReadProperty("MaQuocGia", true);
                return _maQuocGia;
            }
            set
            {
                CanWriteProperty("MaQuocGia", true);
                if (!_maQuocGia.Equals(value))
                {
                    _maQuocGia = value;
                    PropertyHasChanged("MaQuocGia");
                }
            }
        }

        public string TenHangSanXuat
        {
            get
            {
                CanReadProperty("TenHangSanXuat", true);
                return _tenHangSanXuat;
            }
            set
            {
                CanWriteProperty("TenHangSanXuat", true);
                if (value == null) value = string.Empty;
                if (!_tenHangSanXuat.Equals(value))
                {
                    _tenHangSanXuat = value;
                    PropertyHasChanged("TenHangSanXuat");
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

        public decimal ThoiLuong
        {
            get
            {
                CanReadProperty("ThoiLuong", true);
                return _thoiLuong;
            }
            set
            {
                CanWriteProperty("ThoiLuong", true);
                if (!_thoiLuong.Equals(value))
                {
                    _thoiLuong = value;
                    PropertyHasChanged("ThoiLuong");
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
        public int TaiKhoanKho
        {
            get
            {
                CanReadProperty("TaiKhoanKho", true);
                return _taiKhoanKho;
            }
            set
            {
                CanWriteProperty("TaiKhoanKho", true);
                if (!_taiKhoanKho.Equals(value))
                {
                    _taiKhoanKho = value;
                    PropertyHasChanged("TaiKhoanKho");
                }
            }
        }
        public int TaiKhoanPhanBo
        {
            get
            {
                CanReadProperty("TaiKhoanPhanBo", true);
                return _taiKhoanPhanBo;
            }
            set
            {
                CanWriteProperty("TaiKhoanPhanBo", true);
                if (!_taiKhoanPhanBo.Equals(value))
                {
                    _taiKhoanPhanBo = value;
                    PropertyHasChanged("TaiKhoanPhanBo");
                }
            }
        }
        public int TaiKhoanChoPhanBo
        {
            get
            {
                CanReadProperty("TaiKhoanChoPhanBo", true);
                return _taiKhoanChoPhanBo;
            }
            set
            {
                CanWriteProperty("TaiKhoanChoPhanBo", true);
                if (!_taiKhoanChoPhanBo.Equals(value))
                {
                    _taiKhoanChoPhanBo = value;
                    PropertyHasChanged("TaiKhoanChoPhanBo");
                }
            }
        }
        protected override object GetIdValue()
        {
            return _maHangHoa;
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
            // MaQuanLy
            //
            //ValidationRules.AddRule(CommonRules.StringRequired, "MaQuanLy");
            //ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("MaQuanLy", 100));
            //
            // TenHangHoa
            //
            //ValidationRules.AddRule(CommonRules.StringRequired, "TenHangHoa");
            //ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("TenHangHoa", 1000));
            //
            // TenHangSanXuat
            //
            //ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("TenHangSanXuat", 100));
            //
            // DienGiai
            //
            //ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("DienGiai", 500));
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
            //TODO: Define authorization rules in HangHoaBQ_VT
            //AuthorizationRules.AllowRead("MaHangHoa", "HangHoaBQ_VTReadGroup");
            //AuthorizationRules.AllowRead("MaQuanLy", "HangHoaBQ_VTReadGroup");
            //AuthorizationRules.AllowRead("TenHangHoa", "HangHoaBQ_VTReadGroup");
            //AuthorizationRules.AllowRead("MaDonViTinh", "HangHoaBQ_VTReadGroup");
            //AuthorizationRules.AllowRead("MaNhomHangHoa", "HangHoaBQ_VTReadGroup");
            //AuthorizationRules.AllowRead("MaQuocGia", "HangHoaBQ_VTReadGroup");
            //AuthorizationRules.AllowRead("TenHangSanXuat", "HangHoaBQ_VTReadGroup");
            //AuthorizationRules.AllowRead("TinhTrang", "HangHoaBQ_VTReadGroup");
            //AuthorizationRules.AllowRead("DienGiai", "HangHoaBQ_VTReadGroup");
            //AuthorizationRules.AllowRead("ThoiLuong", "HangHoaBQ_VTReadGroup");
            //AuthorizationRules.AllowRead("NgayLap", "HangHoaBQ_VTReadGroup");
            //AuthorizationRules.AllowRead("NgayLapString", "HangHoaBQ_VTReadGroup");

            //AuthorizationRules.AllowWrite("MaQuanLy", "HangHoaBQ_VTWriteGroup");
            //AuthorizationRules.AllowWrite("TenHangHoa", "HangHoaBQ_VTWriteGroup");
            //AuthorizationRules.AllowWrite("MaDonViTinh", "HangHoaBQ_VTWriteGroup");
            //AuthorizationRules.AllowWrite("MaNhomHangHoa", "HangHoaBQ_VTWriteGroup");
            //AuthorizationRules.AllowWrite("MaQuocGia", "HangHoaBQ_VTWriteGroup");
            //AuthorizationRules.AllowWrite("TenHangSanXuat", "HangHoaBQ_VTWriteGroup");
            //AuthorizationRules.AllowWrite("TinhTrang", "HangHoaBQ_VTWriteGroup");
            //AuthorizationRules.AllowWrite("DienGiai", "HangHoaBQ_VTWriteGroup");
            //AuthorizationRules.AllowWrite("ThoiLuong", "HangHoaBQ_VTWriteGroup");
            //AuthorizationRules.AllowWrite("NgayLapString", "HangHoaBQ_VTWriteGroup");
        }


        public static bool CanGetObject()
        {
            //TODO: Define CanGetObject permission in HangHoaBQ_VT
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("HangHoaBQ_VTViewGroup"))
            //	return true;
            //return false;
        }

        public static bool CanAddObject()
        {
            //TODO: Define CanAddObject permission in HangHoaBQ_VT
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("HangHoaBQ_VTAddGroup"))
            //	return true;
            //return false;
        }

        public static bool CanEditObject()
        {
            //TODO: Define CanEditObject permission in HangHoaBQ_VT
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("HangHoaBQ_VTEditGroup"))
            //	return true;
            //return false;
        }

        public static bool CanDeleteObject()
        {
            //TODO: Define CanDeleteObject permission in HangHoaBQ_VT
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("HangHoaBQ_VTDeleteGroup"))
            //	return true;
            //return false;
        }
        #endregion //Authorization Rules

        #region Factory Methods
        private HangHoaBQ_VT()
        { /* require use of factory method */
            base.MarkAsChild();
        }

        public static HangHoaBQ_VT NewHangHoaBQ_VT()
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a HangHoaBQ_VT");
            return DataPortal.Create<HangHoaBQ_VT>();
        }

        public static HangHoaBQ_VT GetHangHoaBQ_VT(int maHangHoa)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a HangHoaBQ_VT");
            return DataPortal.Fetch<HangHoaBQ_VT>(new Criteria(maHangHoa));
        }

        public static HangHoaBQ_VT GetHangHoaBQ_VT(string tenHangHoa)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a HangHoaBQ_VT");
            return DataPortal.Fetch<HangHoaBQ_VT>(new Criteria_TenHangHoa(tenHangHoa));
        }

        public static void DeleteHangHoaBQ_VT(int maHangHoa)
        {
            if (!CanDeleteObject())
                throw new System.Security.SecurityException("User not authorized to remove a HangHoaBQ_VT");
            DataPortal.Delete(new Criteria(maHangHoa));
        }

        public override HangHoaBQ_VT Save()
        {
            if (IsDeleted && !CanDeleteObject())
                throw new System.Security.SecurityException("User not authorized to remove a HangHoaBQ_VT");
            else if (IsNew && !CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a HangHoaBQ_VT");
            else if (!CanEditObject())
                throw new System.Security.SecurityException("User not authorized to update a HangHoaBQ_VT");

            return base.Save();
        }
        #region Lay gia Binh Quan cua HangHoa
        public static decimal GetGiaBinhQuan(int maKho, int maHangHoa, DateTime ngay)
        {
            decimal kqGiaBinhQuan = 0;

            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "Spd_GetGiaTriBinhQuanHangHoa";
                    cm.Parameters.AddWithValue("@maKho", maKho);
                    cm.Parameters.AddWithValue("@maHangHoa", maHangHoa);
                    cm.Parameters.AddWithValue("@ngay", ngay);
                    SqlParameter prmGiaTriBQTraVe = new SqlParameter("@GiaTriTraVe", SqlDbType.Decimal, 16);
                    prmGiaTriBQTraVe.Direction = ParameterDirection.Output;
                    cm.Parameters.Add(prmGiaTriBQTraVe);
                    cm.ExecuteNonQuery();
                    kqGiaBinhQuan = (decimal)prmGiaTriBQTraVe.Value;
                }
            }//us

            return kqGiaBinhQuan;

        }
        public static decimal GetGiaTriBinhQuanHangHoa(long maPhieuXuat, int maKho, int maHangHoa, DateTime ngay)//M
        {
            decimal kqGiaBinhQuan = 0;

            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "Spd_GetGiaTriBinhQuanHangHoa_M";
                    cm.Parameters.AddWithValue("@maPhieuXuat", maPhieuXuat);
                    cm.Parameters.AddWithValue("@maKho", maKho);
                    cm.Parameters.AddWithValue("@maHangHoa", maHangHoa);
                    cm.Parameters.AddWithValue("@ngay", ngay);
                    SqlParameter prmGiaTriBQTraVe = new SqlParameter("@GiaTriTraVe", SqlDbType.Decimal, 16);
                    prmGiaTriBQTraVe.Direction = ParameterDirection.Output;
                    cm.Parameters.Add(prmGiaTriBQTraVe);
                    cm.ExecuteNonQuery();
                    kqGiaBinhQuan = (decimal)prmGiaTriBQTraVe.Value;
                }
            }//us

            return kqGiaBinhQuan;

        }
        #endregion//Lay gia Binh Quan cua HangHoa
        #region Lay gia tri Vat Tu HangHoa
        public static decimal GetGiaTriVTHH(int maKho, int maHangHoa, DateTime ngay)
        {
            decimal kqGiaBinhQuan = 0;

            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "Spd_GetGiaTriVatTuHangHoa";
                    cm.Parameters.AddWithValue("@maKho", maKho);
                    cm.Parameters.AddWithValue("@maHangHoa", maHangHoa);
                    cm.Parameters.AddWithValue("@ngay", ngay);
                    SqlParameter prmGiaTriBQTraVe = new SqlParameter("@GiaTriTraVe", SqlDbType.Decimal, 16);
                    prmGiaTriBQTraVe.Direction = ParameterDirection.Output;
                    cm.Parameters.Add(prmGiaTriBQTraVe);
                    cm.ExecuteNonQuery();
                    kqGiaBinhQuan = (decimal)prmGiaTriBQTraVe.Value;
                }
            }//us

            return kqGiaBinhQuan;

        }
        #endregion//Lay gia tri Vat Tu HangHoa
        #region BAN QUYEN
        #region Binh Quan
        #region Lay gia Binh Quan cua Chuong Trinh BQ
        public static decimal GetGiaBinhQuanChuongTrinhBQ(long maPhieuXuat, int maBoPhan, int maKho, int maHangHoa, long maHopDong, DateTime ngay)
        {
            decimal kqGiaBinhQuan = 0;

            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "Spd_GetGiaTriBinhQuanChuongTrinhBQ";
                    cm.Parameters.AddWithValue("@maPhieuXuat", maPhieuXuat);
                    cm.Parameters.AddWithValue("@maBoPhan", maBoPhan);
                    cm.Parameters.AddWithValue("@maKho", maKho);
                    cm.Parameters.AddWithValue("@maHangHoa", maHangHoa);
                    cm.Parameters.AddWithValue("@maHopDong", maHopDong);
                    cm.Parameters.AddWithValue("@ngay", ngay);
                    SqlParameter prmGiaTriBQTraVe = new SqlParameter("@GiaTriTraVe", SqlDbType.Decimal, 16);
                    prmGiaTriBQTraVe.Direction = ParameterDirection.Output;
                    cm.Parameters.Add(prmGiaTriBQTraVe);
                    cm.ExecuteNonQuery();
                    kqGiaBinhQuan = (decimal)prmGiaTriBQTraVe.Value;
                }
            }//us

            return kqGiaBinhQuan;

        }
        #endregion//Lay gia Binh Quan cua Chuong Trinh BQ
        #region Lay gia tri cua Chuong Trinh BanQuyen
        public static decimal GetGiaTriChuongTrinhBQ(long maPhieuXuat, int maBoPhan, int maKho, int maHangHoa, long maHopDong, DateTime ngay)
        {
            decimal kqGiaBinhQuan = 0;

            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "Spd_GetGiaTriChuongTrinhBQ";
                    cm.Parameters.AddWithValue("@maPhieuXuat", maPhieuXuat);
                    cm.Parameters.AddWithValue("@maBoPhan", maBoPhan);
                    cm.Parameters.AddWithValue("@maKho", maKho);
                    cm.Parameters.AddWithValue("@maHangHoa", maHangHoa);
                    cm.Parameters.AddWithValue("@maHopDong", maHopDong);
                    cm.Parameters.AddWithValue("@ngay", ngay);
                    SqlParameter prmGiaTriBQTraVe = new SqlParameter("@GiaTriTraVe", SqlDbType.Decimal, 16);
                    prmGiaTriBQTraVe.Direction = ParameterDirection.Output;
                    cm.Parameters.Add(prmGiaTriBQTraVe);
                    cm.ExecuteNonQuery();
                    kqGiaBinhQuan = (decimal)prmGiaTriBQTraVe.Value;
                }
            }//us

            return kqGiaBinhQuan;

        }
        #endregion//Lay gia tri cua Chuong Trinh Ban Quyen
        #region Lay So Luong cua Chuong Trinh BQ
        public static decimal GetSoLuongChuongTrinhBQ(long maPhieuXuat, int maBoPhan, int maKho, int maHangHoa, long maHopDong, DateTime ngay)//M
        {
            decimal kqSoLuong = 0;

            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "Spd_GetSoLuongChuongTrinhBQ";
                    cm.Parameters.AddWithValue("@maPhieuXuat", maPhieuXuat);
                    cm.Parameters.AddWithValue("@maBoPhan", maBoPhan);
                    cm.Parameters.AddWithValue("@maKho", maKho);
                    cm.Parameters.AddWithValue("@maHangHoa", maHangHoa);
                    cm.Parameters.AddWithValue("@maHopDong", maHopDong);
                    cm.Parameters.AddWithValue("@ngay", ngay);
                    SqlParameter prmSoLuongTraVe = new SqlParameter("@GiaTriTraVe", SqlDbType.Decimal, 16);
                    prmSoLuongTraVe.Direction = ParameterDirection.Output;
                    cm.Parameters.Add(prmSoLuongTraVe);
                    cm.ExecuteNonQuery();
                    kqSoLuong = (decimal)prmSoLuongTraVe.Value;
                }
            }//us

            return kqSoLuong;

        }
        #endregion//Lay gia So Luong cua Chuong Trinh BQ
        #endregion//Binh Quan
        #region Nhap Xuat Thang BQ
        public static decimal GetSoLuongChuongTrinhBQ_NXT(long maPhieuXuat, int maBoPhan, long maPhieuNhap, int maHangHoa, long maHopDong, DateTime ngay)//M
        {
            decimal kqSoLuong = 0;

            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "Spd_GetSoLuongChuongTrinhBQ_NXT";
                    cm.Parameters.AddWithValue("@maPhieuXuat", maPhieuXuat);
                    cm.Parameters.AddWithValue("@maBoPhan", maBoPhan);
                    cm.Parameters.AddWithValue("@maPhieuNhap", maPhieuNhap);
                    cm.Parameters.AddWithValue("@maHangHoa", maHangHoa);
                    cm.Parameters.AddWithValue("@maHopDong", maHopDong);
                    cm.Parameters.AddWithValue("@ngay", ngay);
                    SqlParameter prmSoLuongTraVe = new SqlParameter("@GiaTriTraVe", SqlDbType.Decimal, 16);
                    prmSoLuongTraVe.Direction = ParameterDirection.Output;
                    cm.Parameters.Add(prmSoLuongTraVe);
                    cm.ExecuteNonQuery();
                    kqSoLuong = (decimal)prmSoLuongTraVe.Value;
                }
            }//us

            return kqSoLuong;

        }

        public static decimal GetGiaTriChuongTrinhBQ_NXT(long maPhieuXuat, int maBoPhan, long maPhieuNhap, int maHangHoa, long maHopDong, DateTime ngay)//M
        {
            decimal kqSoLuong = 0;

            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "Spd_GetGiaTriChuongTrinhBQ_NXT";
                    cm.Parameters.AddWithValue("@maPhieuXuat", maPhieuXuat);
                    cm.Parameters.AddWithValue("@maBoPhan", maBoPhan);
                    cm.Parameters.AddWithValue("@maPhieuNhap", maPhieuNhap);
                    cm.Parameters.AddWithValue("@maHangHoa", maHangHoa);
                    cm.Parameters.AddWithValue("@maHopDong", maHopDong);
                    cm.Parameters.AddWithValue("@ngay", ngay);
                    SqlParameter prmSoLuongTraVe = new SqlParameter("@GiaTriTraVe", SqlDbType.Decimal, 16);
                    prmSoLuongTraVe.Direction = ParameterDirection.Output;
                    cm.Parameters.Add(prmSoLuongTraVe);
                    cm.ExecuteNonQuery();
                    kqSoLuong = (decimal)prmSoLuongTraVe.Value;
                }
            }//us

            return kqSoLuong;

        }
        #endregion//Nhap Xuat Thang BQ

        #endregion//BAN QUYEN
        #region Lay gia So Luong cua HangHoa
        public static decimal GetSoLuongHangHoa(int maKho, int maHangHoa, DateTime ngay)
        {
            decimal kqSoLuong = 0;

            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "Spd_GetSoLuongHangHoa";
                    cm.Parameters.AddWithValue("@maKho", maKho);
                    cm.Parameters.AddWithValue("@maHangHoa", maHangHoa);
                    cm.Parameters.AddWithValue("@ngay", ngay);
                    SqlParameter prmSoLuongTraVe = new SqlParameter("@GiaTriTraVe", SqlDbType.Decimal, 16);
                    prmSoLuongTraVe.Direction = ParameterDirection.Output;
                    cm.Parameters.Add(prmSoLuongTraVe);
                    cm.ExecuteNonQuery();
                    kqSoLuong = (decimal)prmSoLuongTraVe.Value;
                }
            }//us

            return kqSoLuong;

        }
        public static decimal GetSoLuongHangHoaBinhQuan(long maPhieuXuat, int maKho, int maHangHoa, DateTime ngay)//M
        {
            decimal kqSoLuong = 0;

            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "Spd_GetSoLuongHangHoa_M";
                    cm.Parameters.AddWithValue("@maPhieuXuat", maPhieuXuat);
                    cm.Parameters.AddWithValue("@maKho", maKho);
                    cm.Parameters.AddWithValue("@maHangHoa", maHangHoa);
                    cm.Parameters.AddWithValue("@ngay", ngay);
                    SqlParameter prmSoLuongTraVe = new SqlParameter("@GiaTriTraVe", SqlDbType.Decimal);
                    prmSoLuongTraVe.Precision = 15;
                    prmSoLuongTraVe.Scale = 2;
                    prmSoLuongTraVe.Direction = ParameterDirection.Output;
                    cm.Parameters.Add(prmSoLuongTraVe);
                    cm.ExecuteNonQuery();
                    kqSoLuong = (decimal)prmSoLuongTraVe.Value;
                }
            }//us

            return kqSoLuong;

        }
        public static decimal GetSoLuongHangHoaNhapThang(int maKho, int maHangHoa, DateTime ngay)
        {
            decimal kqSoLuong = 0;

            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "Spd_GetSoLuongHangHoaNhapThang";
                    cm.Parameters.AddWithValue("@maKho", maKho);
                    cm.Parameters.AddWithValue("@maHangHoa", maHangHoa);
                    cm.Parameters.AddWithValue("@ngay", ngay);
                    SqlParameter prmSoLuongTraVe = new SqlParameter("@GiaTriTraVe", SqlDbType.Decimal, 16);
                    prmSoLuongTraVe.Direction = ParameterDirection.Output;
                    cm.Parameters.Add(prmSoLuongTraVe);
                    cm.ExecuteNonQuery();
                    kqSoLuong = (decimal)prmSoLuongTraVe.Value;
                }
            }//us

            return kqSoLuong;

        }
        #endregion//Lay gia So Luong cua HangHoa

        
        #region Lay Gia Tri (Tong Tien) cua HangHoa
        public static decimal GetGiaTriHangHoa(int maKho, int maHangHoa, DateTime ngay)
        {
            decimal kqGiaTri = 0;

            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "Spd_GetGiaTriHangHoa";
                    cm.Parameters.AddWithValue("@maKho", maKho);
                    cm.Parameters.AddWithValue("@maHangHoa", maHangHoa);
                    cm.Parameters.AddWithValue("@ngay", ngay);
                    SqlParameter prmGiaTriTraVe = new SqlParameter("@GiaTriTraVe", SqlDbType.Decimal, 16);
                    prmGiaTriTraVe.Direction = ParameterDirection.Output;
                    cm.Parameters.Add(prmGiaTriTraVe);
                    cm.ExecuteNonQuery();
                    kqGiaTri = (decimal)prmGiaTriTraVe.Value;
                }
            }//us

            return kqGiaTri;

        }
        public static decimal GetGiaTriHangHoaBinhQuan(long maPhieuXuat, int maKho, int maHangHoa, DateTime ngay)//M
        {
            decimal kqGiaTri = 0;

            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "Spd_GetGiaTriHangHoa_M";
                    cm.Parameters.AddWithValue("@maPhieuXuat", maPhieuXuat);
                    cm.Parameters.AddWithValue("@maKho", maKho);
                    cm.Parameters.AddWithValue("@maHangHoa", maHangHoa);
                    cm.Parameters.AddWithValue("@ngay", ngay);
                    SqlParameter prmGiaTriTraVe = new SqlParameter("@GiaTriTraVe", SqlDbType.Decimal, 16);
                    prmGiaTriTraVe.Direction = ParameterDirection.Output;
                    cm.Parameters.Add(prmGiaTriTraVe);
                    cm.ExecuteNonQuery();
                    kqGiaTri = (decimal)prmGiaTriTraVe.Value;
                }
            }//us

            return kqGiaTri;

        }
        #endregion//Lay gia Binh Quan cua HangHoa

        #region lay So luong va Gia tri cua Hang hoa NhapXuatThang//M
        public static decimal GetSoLuongHangHoaNXT(long maPhieuXuat, long maPhieuNhap, int maHangHoa, DateTime ngay, decimal donGia, long maChiTietPhieuNhap, long maCT_KetChuyen, long maCT_KetChuyenCCDC)//M 19112013
        {
            decimal kqSoLuong = 0;

            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "Spd_GetSoLuongHangHoaNXT";
                    cm.Parameters.AddWithValue("@maPhieuXuat", maPhieuXuat);
                    cm.Parameters.AddWithValue("@maPhieuNhap", maPhieuNhap);
                    cm.Parameters.AddWithValue("@maHangHoa", maHangHoa);
                    cm.Parameters.AddWithValue("@ngay", ngay);
                    cm.Parameters.AddWithValue("@DonGia", donGia);//New 19112013
                    cm.Parameters.AddWithValue("@maChiTietPhieuNhap", maChiTietPhieuNhap);
                    cm.Parameters.AddWithValue("@maCT_KetChuyen", maCT_KetChuyen);
                    cm.Parameters.AddWithValue("@maCT_KetChuyenCCDC", maCT_KetChuyenCCDC);
                    SqlParameter prmSoLuongTraVe = new SqlParameter("@GiaTriTraVe", SqlDbType.Decimal);
                    prmSoLuongTraVe.Precision = 15;
                    prmSoLuongTraVe.Scale = 2;
                    prmSoLuongTraVe.Direction = ParameterDirection.Output;
                    cm.Parameters.Add(prmSoLuongTraVe);
                    cm.ExecuteNonQuery();
                    kqSoLuong = (decimal)prmSoLuongTraVe.Value;
                }
            }//us

            return kqSoLuong;

        }

        public static decimal GetGiaTriHangHoaNXT(long maPhieuXuat, long maPhieuNhap, int maHangHoa, DateTime ngay, decimal donGia, int maChiTietPhieuNhap, long maCT_KetChuyen)//M 19112013
        {
            decimal kqGiaTri = 0;

            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "Spd_GetGiaTriHangHoaNXT";
                    cm.Parameters.AddWithValue("@maPhieuXuat", maPhieuXuat);
                    cm.Parameters.AddWithValue("@maPhieuNhap", maPhieuNhap);
                    cm.Parameters.AddWithValue("@maHangHoa", maHangHoa);
                    cm.Parameters.AddWithValue("@ngay", ngay);
                    cm.Parameters.AddWithValue("@DonGia", donGia);//New 19112013
                    cm.Parameters.AddWithValue("@maChiTietPhieuNhap", maChiTietPhieuNhap);
                    cm.Parameters.AddWithValue("@maCT_KetChuyen", maCT_KetChuyen);
                    SqlParameter prmGiaTriTraVe = new SqlParameter("@GiaTriTraVe", SqlDbType.Decimal, 16);
                    prmGiaTriTraVe.Direction = ParameterDirection.Output;
                    cm.Parameters.Add(prmGiaTriTraVe);
                    cm.ExecuteNonQuery();
                    kqGiaTri = (decimal)prmGiaTriTraVe.Value;
                }
            }//us

            return kqGiaTri;

        }
        #endregion//lay So luong va Gia tri cua Hang hoa NhapXuatThang
        #region Lay So Luong Xuat cua HangHoa Theo Phong Ban
        public static decimal GetSLXuatHangHoaTheoPhongBan(int maPhongBan, int maHangHoa, DateTime ngay)
        {
            int SoLuong = 0;

            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_SoLuongXuatTheoPhongBan";
                    cm.Parameters.AddWithValue("@MaPhongBan", maPhongBan);
                    cm.Parameters.AddWithValue("@maHangHoa", maHangHoa);
                    cm.Parameters.AddWithValue("@DenNgay", ngay);
                    SqlParameter prmGiaTriTraVe = new SqlParameter("@SoLuong", SqlDbType.Int, 32);
                    prmGiaTriTraVe.Direction = ParameterDirection.Output;
                    cm.Parameters.Add(prmGiaTriTraVe);
                    cm.ExecuteNonQuery();
                    SoLuong = (int)prmGiaTriTraVe.Value;
                }
            }//us

            return SoLuong;

        }
        #endregion//Lay gia Binh Quan cua HangHoa

        public static String Get_MaxMaQuanLy(int maNhomHangHoa, int size = 4)
        {
            
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {

                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_MaxMaQuanLy_HangHoa";
                    cm.Parameters.AddWithValue("@MaNhomHangHoa", maNhomHangHoa);
                    cm.Parameters.AddWithValue("@Size", size);
                    SqlParameter paraMaQuanLy = new SqlParameter("@MaQuanLy", SqlDbType.VarChar, 100);
                    paraMaQuanLy.Direction = ParameterDirection.Output;
                    cm.Parameters.Add(paraMaQuanLy);
                    cm.ExecuteNonQuery();
                    return paraMaQuanLy.SqlValue.ToString();
                }
            }
            
        }

        public static String spd_MaxMaHangHoaByMaNhom(int maNhomHangHoa)
        {
            
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {

                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_MaxMaHangHoaByMaNhom";
                    cm.Parameters.AddWithValue("@MaNhomHangHoa", maNhomHangHoa);
                    SqlParameter paraMaQuanLy = new SqlParameter("@MaQuanLy", SqlDbType.VarChar, 100);
                    paraMaQuanLy.Direction = ParameterDirection.Output;
                    cm.Parameters.Add(paraMaQuanLy);
                    cm.ExecuteNonQuery();
                    return paraMaQuanLy.SqlValue.ToString();
                }
            }
            
        }
        public static bool KiemTraTrungMaQuanLy(long maHangHoa, string maQuanLy)
        {
            bool result = false;
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "Spd_CheckMaQuanLyHangHoa";
                    cm.Parameters.AddWithValue("@MaHangHoa", maHangHoa);
                    cm.Parameters.AddWithValue("@MaQuanLy", maQuanLy);
                    SqlParameter outPara = new SqlParameter("@TrungMaQuanLy", SqlDbType.Bit);
                    outPara.Direction = ParameterDirection.Output;
                    cm.Parameters.Add(outPara);
                    cm.ExecuteNonQuery();
                    result = (bool)outPara.Value;
                }
            }//end using
            return result;
        }//end function

        public static bool CheckMaQuanLyHangHoaKhongTrung(int _maHangHoa, string _maQuanLy, bool _laMoi)
        {
            bool Kt = false;
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "Spd_KiemTraMaQuanLyHangHoaKhongTrung";
                    cm.Parameters.AddWithValue("@MaHangHoa", _maHangHoa);
                    cm.Parameters.AddWithValue("@MaQuanLy", _maQuanLy);
                    cm.Parameters.AddWithValue("@LaMoi", _laMoi);
                    SqlParameter prmGiaTriTraVe = new SqlParameter("@GiaTriTraVe", SqlDbType.Bit);
                    prmGiaTriTraVe.Direction = ParameterDirection.Output;
                    cm.Parameters.Add(prmGiaTriTraVe);
                    cm.ExecuteNonQuery();
                    Kt = (bool)prmGiaTriTraVe.Value;
                }
            }//us
            return Kt;

        }
        #endregion //Factory Methods

        #region Child Factory Methods
        internal static HangHoaBQ_VT NewHangHoaBQ_VTChild()
        {
            HangHoaBQ_VT child = new HangHoaBQ_VT();
            child.ValidationRules.CheckRules();
            child.MarkAsChild();
            return child;
        }

        internal static HangHoaBQ_VT GetHangHoaBQ_VT(SafeDataReader dr)
        {
            HangHoaBQ_VT child = new HangHoaBQ_VT();
            child.MarkAsChild();
            child.Fetch(dr);
            return child;
        }

        internal static HangHoaBQ_VT GetHangHoaBQ_VT_getHH2018(SafeDataReader dr)
        {
            HangHoaBQ_VT child = new HangHoaBQ_VT();
            child.MarkAsChild();
            child.Fetch_2018(dr);
            return child;
        }

        #endregion //Child Factory Methods

        #region Data Access

        #region Criteria

        [Serializable()]
        private class Criteria
        {
            public int MaHangHoa;

            public Criteria(int maHangHoa)
            {
                this.MaHangHoa = maHangHoa;
            }
        }

        private class Criteria_TenHangHoa
        {
            public string TenHangHoa;

            public Criteria_TenHangHoa(string tenHangHoa)
            {
                this.TenHangHoa = tenHangHoa;
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
                if (criteria is Criteria)
                {
                    cm.CommandText = "spd_SelecttblHangHoa";
                    cm.Parameters.AddWithValue("@MaHangHoa", ((Criteria)criteria).MaHangHoa);
                }
                if (criteria is Criteria_TenHangHoa)                    
                {
                    cm.CommandText = "spd_SelecttblHangHoa_TenHangHoa";
                    cm.Parameters.AddWithValue("@TenHangHoa", ((Criteria_TenHangHoa)criteria).TenHangHoa);
                }
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
            DataPortal_Delete(new Criteria(_maHangHoa));
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
                cm.CommandText = "spd_DeletetblHangHoa";

                cm.Parameters.AddWithValue("@MaHangHoa", criteria.MaHangHoa);

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

        private void Fetch_2018(SafeDataReader dr)
        {
            FetchObject_2018(dr);
            MarkOld();
            ValidationRules.CheckRules();

            //load child object(s)
            FetchChildren(dr);
        }

        private void FetchObject_2018(SafeDataReader dr)
        {
            _maHangHoa = dr.GetInt32("MaHangHoa");
            _maQuanLy = dr.GetString("MaQuanLy");
            _tenHangHoa = dr.GetString("TenHangHoa");
            _maDonViTinh = dr.GetInt32("MaDonViTinh");
            _maNhomHangHoa = dr.GetInt32("MaNhomHangHoa");
            _maQuocGia = dr.GetInt32("MaQuocGia");
            _tenHangSanXuat = dr.GetString("TenHangSanXuat");
            _tinhTrang = dr.GetBoolean("TinhTrang");
            _dienGiai = dr.GetString("DienGiai");
            _thoiLuong = dr.GetDecimal("ThoiLuong");
            _ngayLap = dr.GetSmartDate("NgayLap", _ngayLap.EmptyIsMin);
            _donGiaGoc = dr.GetDecimal("DonGiaGoc");
            _soLuongTon = dr.GetDecimal("slTonDK");
            _taiKhoanKho = dr.GetInt32("TaiKhoanKho");
            _taiKhoanPhanBo = dr.GetInt32("TaiKhoanPhanBo");
            _taiKhoanChoPhanBo = dr.GetInt32("TaiKhoanChoPhanBo");
        }

        private void FetchObject(SafeDataReader dr)
        {
            _maHangHoa = dr.GetInt32("MaHangHoa");
            _maQuanLy = dr.GetString("MaQuanLy");
            _tenHangHoa = dr.GetString("TenHangHoa");
            _maDonViTinh = dr.GetInt32("MaDonViTinh");
            _maNhomHangHoa = dr.GetInt32("MaNhomHangHoa");
            _maQuocGia = dr.GetInt32("MaQuocGia");
            _tenHangSanXuat = dr.GetString("TenHangSanXuat");
            _tinhTrang = dr.GetBoolean("TinhTrang");
            _dienGiai = dr.GetString("DienGiai");
            _thoiLuong = dr.GetDecimal("ThoiLuong");
            _ngayLap = dr.GetSmartDate("NgayLap", _ngayLap.EmptyIsMin);
            _taiKhoanKho = dr.GetInt32("TaiKhoanKho");
            _taiKhoanPhanBo = dr.GetInt32("TaiKhoanPhanBo");
            _taiKhoanChoPhanBo = dr.GetInt32("TaiKhoanChoPhanBo");
        }

        private void FetchChildren(SafeDataReader dr)
        {
        }
        #endregion //Data Access - Fetch

        #region Data Access - Insert
        internal void Insert(SqlTransaction tr, HangHoaBQ_VTList parent)
        {
            if (!IsDirty) return;

            ExecuteInsert(tr, parent);
            MarkOld();

            //update child object(s)
            UpdateChildren(tr);
        }

        private void ExecuteInsert(SqlTransaction tr, HangHoaBQ_VTList parent)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_InserttblHangHoa";
                cm.CommandTimeout = 900;
                AddInsertParameters(cm, parent);
                cm.ExecuteNonQuery();

                _maHangHoa = (int)cm.Parameters["@MaHangHoa"].Value;
            }//using
        }

        private void AddInsertParameters(SqlCommand cm, HangHoaBQ_VTList parent)
        {
            //TODO: if parent use identity key, fix fk member with value from parent
            cm.Parameters.AddWithValue("@MaQuanLy", _maQuanLy);
            cm.Parameters.AddWithValue("@TenHangHoa", _tenHangHoa);
            if (_maDonViTinh != 0)
                cm.Parameters.AddWithValue("@MaDonViTinh", _maDonViTinh);
            else
                cm.Parameters.AddWithValue("@MaDonViTinh", DBNull.Value);
            if (_maNhomHangHoa != 0)
                cm.Parameters.AddWithValue("@MaNhomHangHoa", _maNhomHangHoa);
            else
                cm.Parameters.AddWithValue("@MaNhomHangHoa", DBNull.Value);
            if (_maQuocGia != 0)
                cm.Parameters.AddWithValue("@MaQuocGia", _maQuocGia);
            else
                cm.Parameters.AddWithValue("@MaQuocGia", DBNull.Value);
            if (_tenHangSanXuat.Length > 0)
                cm.Parameters.AddWithValue("@TenHangSanXuat", _tenHangSanXuat);
            else
                cm.Parameters.AddWithValue("@TenHangSanXuat", DBNull.Value);
            cm.Parameters.AddWithValue("@TinhTrang", _tinhTrang);
            if (_dienGiai.Length > 0)
                cm.Parameters.AddWithValue("@DienGiai", _dienGiai);
            else
                cm.Parameters.AddWithValue("@DienGiai", DBNull.Value);
            if (_thoiLuong != 0)
                cm.Parameters.AddWithValue("@ThoiLuong", _thoiLuong);
            else
                cm.Parameters.AddWithValue("@ThoiLuong", DBNull.Value);
            cm.Parameters.AddWithValue("@NgayLap", _ngayLap.DBValue);
            cm.Parameters.AddWithValue("@MaHangHoa", _maHangHoa);
            cm.Parameters["@MaHangHoa"].Direction = ParameterDirection.Output;
            if (_taiKhoanKho != 0)
                cm.Parameters.AddWithValue("@TaiKhoanKho", _taiKhoanKho);
            else
                cm.Parameters.AddWithValue("@TaiKhoanKho", DBNull.Value);
            if (_taiKhoanPhanBo != 0)
                cm.Parameters.AddWithValue("@TaiKhoanPhanBo", _taiKhoanPhanBo);
            else
                cm.Parameters.AddWithValue("@TaiKhoanPhanBo", DBNull.Value);
            if (_taiKhoanChoPhanBo != 0)
                cm.Parameters.AddWithValue("@TaiKhoanChoPhanBo", _taiKhoanChoPhanBo);
            else
                cm.Parameters.AddWithValue("@TaiKhoanChoPhanBo", DBNull.Value);
        }
        #endregion //Data Access - Insert

        #region Data Access - Update
        internal void Update(SqlTransaction tr, HangHoaBQ_VTList parent)
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

        private void ExecuteUpdate(SqlTransaction tr, HangHoaBQ_VTList parent)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_UpdatetblHangHoa";
                cm.CommandTimeout = 900;
                AddUpdateParameters(cm, parent);

                cm.ExecuteNonQuery();

            }//using
        }

        private void AddUpdateParameters(SqlCommand cm, HangHoaBQ_VTList parent)
        {
            cm.Parameters.AddWithValue("@MaHangHoa", _maHangHoa);
            cm.Parameters.AddWithValue("@MaQuanLy", _maQuanLy);
            cm.Parameters.AddWithValue("@TenHangHoa", _tenHangHoa);
            if (_maDonViTinh != 0)
                cm.Parameters.AddWithValue("@MaDonViTinh", _maDonViTinh);
            else
                cm.Parameters.AddWithValue("@MaDonViTinh", DBNull.Value);
            if (_maNhomHangHoa != 0)
                cm.Parameters.AddWithValue("@MaNhomHangHoa", _maNhomHangHoa);
            else
                cm.Parameters.AddWithValue("@MaNhomHangHoa", DBNull.Value);
            if (_maQuocGia != 0)
                cm.Parameters.AddWithValue("@MaQuocGia", _maQuocGia);
            else
                cm.Parameters.AddWithValue("@MaQuocGia", DBNull.Value);
            if (_tenHangSanXuat.Length > 0)
                cm.Parameters.AddWithValue("@TenHangSanXuat", _tenHangSanXuat);
            else
                cm.Parameters.AddWithValue("@TenHangSanXuat", DBNull.Value);
            cm.Parameters.AddWithValue("@TinhTrang", _tinhTrang);
            if (_dienGiai.Length > 0)
                cm.Parameters.AddWithValue("@DienGiai", _dienGiai);
            else
                cm.Parameters.AddWithValue("@DienGiai", DBNull.Value);
            if (_thoiLuong != 0)
                cm.Parameters.AddWithValue("@ThoiLuong", _thoiLuong);
            else
                cm.Parameters.AddWithValue("@ThoiLuong", DBNull.Value);
            if (_taiKhoanKho != 0)
                cm.Parameters.AddWithValue("@TaiKhoanKho", _taiKhoanKho);
            else
                cm.Parameters.AddWithValue("@TaiKhoanKho", DBNull.Value);
            if (_taiKhoanPhanBo != 0)
                cm.Parameters.AddWithValue("@TaiKhoanPhanBo", _taiKhoanPhanBo);
            else
                cm.Parameters.AddWithValue("@TaiKhoanPhanBo", DBNull.Value);
            if (_taiKhoanChoPhanBo != 0)
                cm.Parameters.AddWithValue("@TaiKhoanChoPhanBo", _taiKhoanChoPhanBo);
            else
                cm.Parameters.AddWithValue("@TaiKhoanChoPhanBo", DBNull.Value);
            cm.Parameters.AddWithValue("@NgayLap", _ngayLap.DBValue);
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

            ExecuteDelete(tr, new Criteria(_maHangHoa));
            MarkNew();
        }
        #endregion //Data Access - Delete
        #endregion //Data Access
    }
}
