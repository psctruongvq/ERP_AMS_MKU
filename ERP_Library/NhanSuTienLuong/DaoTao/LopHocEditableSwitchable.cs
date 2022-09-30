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
    public class LopHoc : Csla.BusinessBase<LopHoc>
    {
        #region Business Properties and Methods

        //declare members
        private int _maLopHoc = 0;
        private SmartDate _ngayBatDau = new SmartDate(DateTime.MinValue);
        private SmartDate _ngayKetThuc = new SmartDate(DateTime.MinValue);
        private SmartDate _ngayBatDauChinhThuc = new SmartDate(DateTime.MinValue);
        private SmartDate _ngayKetThucChinhThuc = new SmartDate(DateTime.MinValue);
        private byte _vanbangChungchi = 0;
        private string _tenvanbangChungchi = string.Empty;
        private int _loaiVanBang = 0;
        private int _maQuocGiaCap = 0;
        private int _maTruongDaoTao = 0;
        private string _ghiChu = string.Empty;
        private int _maChuyenNganhDaoTao = 0;
        private byte _trongnuocNgoainuoc = 0;
        private int _maLoaiLop = 0;
        private int _maDonViDaoTao = 0;

        private int _SoNguoiHoc = 0;
        private string _NguoiPTThanhToan = string.Empty;
        private string _SoHopDong = string.Empty;
        private SmartDate _NgayHopDong = new SmartDate(DateTime.MinValue);
        private decimal _DonGia = 0;
        private decimal _TongTien = 0;
        private decimal _DaThanhToan = 0;
        private decimal _ConLai = 0;
        private string _GhiChuThanhToan = string.Empty;
        //declare child member(s)
        //private KhoaBieuHocChildList _khoaBieuHoc = KhoaBieuHocChildList.NewKhoaBieuHocChildList();

        [System.ComponentModel.DataObjectField(true, true)]
        public int MaLopHoc
        {
            get
            {
                CanReadProperty("MaLopHoc", true);
                return _maLopHoc;
            }
        }

        [DisplayName("Ngày bắt đầu")]
        public DateTime? NgayBatDau
        {
            get
            {
                CanReadProperty("NgayBatDau", true);
                if (_ngayBatDau.Date == DateTime.MinValue)
                    return null;
                return _ngayBatDau.Date;
            }
            set
            {
                CanWriteProperty("NgayBatDau", true);
                if (!_ngayBatDau.Equals(value))
                {
                    if (value == null)
                        _ngayBatDau = new SmartDate(DateTime.MinValue);
                    else
                        _ngayBatDau = new SmartDate(value.Value.Date);
                    _ngayBatDauChinhThuc = _ngayBatDau;
                    PropertyHasChanged();
                }
            }
        }

        [DisplayName("Ngày kết thúc")]
        public DateTime? NgayKetThuc
        {
            get
            {
                CanReadProperty("NgayKetThuc", true);
                if (_ngayKetThuc.Date == DateTime.MinValue)
                    return null;
                return _ngayKetThuc.Date;
            }
            set
            {
                CanWriteProperty("NgayKetThuc", true);
                if (!_ngayKetThuc.Equals(value))
                {
                    if (value == null)
                        _ngayKetThuc = new SmartDate(DateTime.MinValue);
                    else
                        _ngayKetThuc = new SmartDate(value.Value.Date);
                    _ngayKetThucChinhThuc = _ngayKetThuc;
                    PropertyHasChanged();
                }
            }
        }

        [DisplayName("Ngày bắt đầu chính thưc")]
        public DateTime? NgayBatDauChinhThuc
        {
            get
            {
                CanReadProperty("NgayBatDauChinhThuc", true);
                if (_ngayBatDauChinhThuc.Date == DateTime.MinValue)
                    return null;
                return _ngayBatDauChinhThuc.Date;
            }
            set
            {
                CanWriteProperty("NgayBatDauChinhThuc", true);
                if (!_ngayBatDauChinhThuc.Equals(value))
                {
                    if (value == null)
                        _ngayBatDauChinhThuc = new SmartDate(DateTime.MinValue);
                    else
                        _ngayBatDauChinhThuc = new SmartDate(value.Value.Date);
                    PropertyHasChanged();
                }
            }
        }

        [DisplayName("Ngày kết thúc chính thức")]
        public DateTime? NgayKetThucChinhThuc
        {
            get
            {
                CanReadProperty("NgayKetThucChinhThuc", true);
                if (_ngayKetThucChinhThuc.Date == DateTime.MinValue)
                    return null;
                return _ngayKetThucChinhThuc.Date;
            }
            set
            {
                CanWriteProperty("NgayKetThucChinhThuc", true);
                if (!_ngayKetThucChinhThuc.Equals(value))
                {
                    if (value == null)
                        _ngayKetThucChinhThuc = new SmartDate(DateTime.MinValue);
                    else
                        _ngayKetThucChinhThuc = new SmartDate(value.Value.Date);
                    PropertyHasChanged();
                }
            }
        }

        //public string NgayKetThucString
        //{
        //    get
        //    {
        //        CanReadProperty("NgayKetThucString", true);
        //        return _ngayKetThuc.Text;
        //    }
        //    set
        //    {
        //        CanWriteProperty("NgayKetThucString", true);
        //        if (value == null) value = string.Empty;
        //        if (!_ngayKetThuc.Equals(value))
        //        {
        //            _ngayKetThuc.Text = value;
        //            PropertyHasChanged("NgayKetThucString");
        //        }
        //    }
        //}

        [DisplayName("Văn bằng/Chứng chỉ")]
        public byte VanbangChungChi
        {
            get
            {
                CanReadProperty("VanbangChungChi", true);
                return _vanbangChungchi;
            }
            set
            {
                CanWriteProperty("VanbangChungChi", true);
                if (!_vanbangChungchi.Equals(value))
                {
                    _vanbangChungchi = value;
                    PropertyHasChanged("VanbangChungChi");
                }
            }
        }
        [DisplayName("Văn bằng/Chứng chỉ")]
        public string VanbangChungChiString
        {
            get
            {
                if (_vanbangChungchi == 1)
                    return "Văn bằng";
                else if (_vanbangChungchi == 2)
                    return "Chứng chỉ";
                return "";
            }
        }

        [DisplayName("Tên Văn bằng/Chứng chỉ")]
        public string TenvanbangChungchi
        {
            get
            {
                CanReadProperty("TenvanbangChungchi", true);
                return _tenvanbangChungchi;
            }
            set
            {
                CanWriteProperty("TenvanbangChungchi", true);
                if (value == null) value = string.Empty;
                if (!_tenvanbangChungchi.Equals(value))
                {
                    _tenvanbangChungchi = value;
                    PropertyHasChanged("TenvanbangChungchi");
                }
            }
        }

        [DisplayName("Loại Văn bằng/Chứng chỉ")]
        public int LoaiVanBang
        {
            get
            {
                CanReadProperty("LoaiVanBang", true);
                return _loaiVanBang;
            }
            set
            {
                CanWriteProperty("LoaiVanBang", true);
                if (!_loaiVanBang.Equals(value))
                {
                    _loaiVanBang = value;
                    PropertyHasChanged("LoaiVanBang");
                }
            }
        }
        [DisplayName("Loại Văn bằng/Chứng chỉ")]
        public string LoaiVanBangString
        {
            get
            {
                if (_loaiVanBang != 0)
                    return TrinhDoHocVanClass.GetTrinhDoHocVanClass(_loaiVanBang).TrinhDoHocVan;
                return "";
            }
        }

        [DisplayName("Quốc gia cấp")]
        public int MaQuocGiaCap
        {
            get
            {
                CanReadProperty("MaQuocGiaCap", true);
                return _maQuocGiaCap;
            }
            set
            {
                CanWriteProperty("MaQuocGiaCap", true);
                if (!_maQuocGiaCap.Equals(value))
                {
                    _maQuocGiaCap = value;
                    PropertyHasChanged("MaQuocGiaCap");
                }
            }
        }
        [DisplayName("Quốc gia cấp")]
        public string QuocGiaCap
        {
            get
            {
                if (_maQuocGiaCap != 0)
                    return QuocGia.GetQuocGia(_maQuocGiaCap).TenQuocGia;
                return "";
            }
        }

        [DisplayName("Trường đào tạo")]
        public int MaTruongDaoTao
        {
            get
            {
                CanReadProperty("MaTruongDaoTao", true);
                return _maTruongDaoTao;
            }
            set
            {
                CanWriteProperty("MaTruongDaoTao", true);
                if (!_maTruongDaoTao.Equals(value))
                {
                    _maTruongDaoTao = value;
                    PropertyHasChanged("MaTruongDaoTao");
                }
            }
        }
        [DisplayName("Trường đào tạo")]
        public string TenTruongDaoTao
        {
            get
            {
                if (_maTruongDaoTao != 0)
                    return TruongDaoTao.GetTruongDaoTao(_maTruongDaoTao).TenTruongDaoTao;
                return "";
            }
        }

        [DisplayName("Ghi chú")]
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

        [DisplayName("Chuyên ngành đào tạo")]
        public int MaChuyenNganhDaoTao
        {
            get
            {
                CanReadProperty("MaChuyenNganhDaoTao", true);
                return _maChuyenNganhDaoTao;
            }
            set
            {
                CanWriteProperty("MaChuyenNganhDaoTao", true);
                if (!_maChuyenNganhDaoTao.Equals(value))
                {
                    _maChuyenNganhDaoTao = value;
                    PropertyHasChanged("MaChuyenNganhDaoTao");
                }
            }
        }
        [DisplayName("Chuyên ngành đào tạo")]
        public string TenChuyenNganhDaoTao
        {
            get
            {
                if (_maChuyenNganhDaoTao != 0)
                    return ChuyenNganhDaoTaoClass.GetChuyenNganhDaoTaoClass(_maChuyenNganhDaoTao).ChuyenNganhDaoTao;
                return "";
            }
        }

        [DisplayName("Đào tạo trong nước/ ngoài nước")]
        public byte TrongnuocNgoainuoc
        {
            get
            {
                CanReadProperty("TrongnuocNgoainuoc", true);
                return _trongnuocNgoainuoc;
            }
            set
            {
                CanWriteProperty("TrongnuocNgoainuoc", true);
                if (!_trongnuocNgoainuoc.Equals(value))
                {
                    _trongnuocNgoainuoc = value;
                    PropertyHasChanged("TrongnuocNgoainuoc");
                }
            }
        }
        [DisplayName("Đào tạo")]
        public string TrongnuocNgoainuocString
        {
            get
            {
                if (_trongnuocNgoainuoc == 1)
                    return "Trong nước";
                else if (_trongnuocNgoainuoc == 2)
                    return "Ngoài nước";
                return "";
            }
        }

        public int MaLoaiLop
        {
            get
            {
                CanReadProperty("MaLoaiLop", true);
                return _maLoaiLop;
            }
            set
            {
                CanWriteProperty("MaLoaiLop", true);
                if (!_maLoaiLop.Equals(value))
                {
                    _maLoaiLop = value;
                    PropertyHasChanged("MaLoaiLop");
                }
            }
        }

        public string TenLoaiLop
        {
            get
            {
                if (_maLoaiLop != 0)
                    return LoaiLopDaoTao.GetLoaiLopDaoTao(_maLoaiLop).TenLoaiLop;
                return "";
            }
        }

        public int MaDonViDaoTao
        {
            get
            {
                CanReadProperty("MaDonViDaoTao", true);
                return _maDonViDaoTao;
            }
            set
            {
                CanWriteProperty("MaDonViDaoTao", true);
                if (!_maDonViDaoTao.Equals(value))
                {
                    _maDonViDaoTao = value;
                    PropertyHasChanged("MaDonViDaoTao");
                }
            }
        }

        public string TenDonViDaoTao
        {
            get
            {
                if (_maDonViDaoTao != 0)
                    return DonViDaoTao.GetDonViDaoTao(_maDonViDaoTao).TenDonViDaoTao;
                return "";
            }
        }
        //======
        public int SoNguoiHoc
        {
            get
            {
                CanReadProperty("SoNguoiHoc", true);
                return _SoNguoiHoc;
            }
            set
            {
                CanWriteProperty("SoNguoiHoc", true);
                if (!_SoNguoiHoc.Equals(value))
                {
                    _SoNguoiHoc = value;
                    _TongTien = _DonGia * _SoNguoiHoc;//==
                    _ConLai = _TongTien - DaThanhToan;//==
                    PropertyHasChanged("SoNguoiHoc");
                }
            }
        }

        public string NguoiPTThanhToan
        {
            get
            {
                CanReadProperty("NguoiPTThanhToan", true);
                return _NguoiPTThanhToan;
            }
            set
            {
                CanWriteProperty("NguoiPTThanhToan", true);
                if (!_NguoiPTThanhToan.Equals(value))
                {
                    _NguoiPTThanhToan = value;
                    PropertyHasChanged("NguoiPTThanhToan");
                }
            }
        }

        public string SoHopDong
        {
            get
            {
                CanReadProperty("SoHopDong", true);
                return _SoHopDong;
            }
            set
            {
                CanWriteProperty("SoHopDong", true);
                if (!_SoHopDong.Equals(value))
                {
                    _SoHopDong = value;
                    PropertyHasChanged("SoHopDong");
                }
            }
        }

        public DateTime? NgayHopDong
        {
            get
            {
                CanReadProperty("NgayHopDong", true);
                if (_NgayHopDong.Date == DateTime.MinValue)
                    return null;
                return _NgayHopDong.Date;
            }
            set
            {
                CanWriteProperty("NgayHopDong", true);
                if (!_NgayHopDong.Equals(value))
                {
                    if (value == null)
                        _NgayHopDong = new SmartDate(DateTime.MinValue);
                    else
                        _NgayHopDong = new SmartDate(value.Value.Date);
                    PropertyHasChanged();
                }
            }
        }

        public decimal DonGia
        {
            get
            {
                CanReadProperty("DonGia", true);
                return _DonGia;
            }
            set
            {
                CanWriteProperty("DonGia", true);
                if (!_DonGia.Equals(value))
                {
                    _DonGia = value;
                    _TongTien = _DonGia * _SoNguoiHoc;//==
                    _ConLai = _TongTien - DaThanhToan;//==
                    PropertyHasChanged("DonGia");
                }
            }
        }

        public decimal TongTien
        {
            get
            {
                CanReadProperty("TongTien", true);
                return _TongTien;
            }
            set
            {
                CanWriteProperty("TongTien", true);
                if (!_TongTien.Equals(value))
                {
                    _TongTien = value;
                    _ConLai = _TongTien - _DaThanhToan;//==
                    PropertyHasChanged("TongTien");
                }
            }
        }

        public decimal DaThanhToan
        {
            get
            {
                CanReadProperty("DaThanhToan", true);
                return _DaThanhToan;
            }
            set
            {
                CanWriteProperty("DaThanhToan", true);
                if (!_DaThanhToan.Equals(value))
                {
                    _DaThanhToan = value;
                    _ConLai = _TongTien - _DaThanhToan;//==
                    PropertyHasChanged("DaThanhToan");
                }
            }
        }

        public decimal ConLai
        {
            get
            {
                CanReadProperty("ConLai", true);
                return _ConLai;
            }
            set
            {
                CanWriteProperty("ConLai", true);
                if (!_ConLai.Equals(value))
                {
                    _ConLai = value;
                    PropertyHasChanged("ConLai");
                }
            }
        }


        public string GhiChuThanhToan
        {
            get
            {
                CanReadProperty("GhiChuThanhToan", true);
                return _GhiChuThanhToan;
            }
            set
            {
                CanWriteProperty("GhiChuThanhToan", true);
                if (!_GhiChuThanhToan.Equals(value))
                {
                    _GhiChuThanhToan = value;
                    PropertyHasChanged("GhiChuThanhToan");
                }
            }
        }



        /// <summary>
        /// //
        /// </summary>
        //public KhoaBieuHocChildList KhoaBieuHoc
        //{
        //    get
        //    {
        //        CanReadProperty("KhoaBieuHoc", true);
        //        return _khoaBieuHoc;
        //    }
        //}

        public override bool IsValid
        {
            //get { return base.IsValid && _khoaBieuHoc.IsValid; }
            get { return base.IsValid; }
        }

        public override bool IsDirty
        {
            //get { return base.IsDirty || _khoaBieuHoc.IsDirty; }
            get { return base.IsDirty; }
        }

        protected override object GetIdValue()
        {
            return _maLopHoc;
        }

        #endregion //Business Properties and Methods

        #region Validation Rules
        private void AddCustomRules()
        {
            //add custom/non-generated rules here...
        }

        private void AddCommonRules()
        {

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
            //TODO: Define authorization rules in LopHoc
            //AuthorizationRules.AllowRead("MaLopHoc", "LopHocReadGroup");
            //AuthorizationRules.AllowRead("NgayBatDau", "LopHocReadGroup");
            //AuthorizationRules.AllowRead("NgayBatDauString", "LopHocReadGroup");
            //AuthorizationRules.AllowRead("NgayKetThuc", "LopHocReadGroup");
            //AuthorizationRules.AllowRead("NgayKetThucString", "LopHocReadGroup");
            //AuthorizationRules.AllowRead("VanbangChungchi", "LopHocReadGroup");
            //AuthorizationRules.AllowRead("TenvanbangChungchi", "LopHocReadGroup");
            //AuthorizationRules.AllowRead("LoaiVanBang", "LopHocReadGroup");
            //AuthorizationRules.AllowRead("MaQuocGiaCap", "LopHocReadGroup");
            //AuthorizationRules.AllowRead("MaTruongDaoTao", "LopHocReadGroup");
            //AuthorizationRules.AllowRead("GhiChu", "LopHocReadGroup");
            //AuthorizationRules.AllowRead("MaChuyenNganhDaoTao", "LopHocReadGroup");
            //AuthorizationRules.AllowRead("TrongnuocNgoainuoc", "LopHocReadGroup");

            //AuthorizationRules.AllowWrite("NgayBatDauString", "LopHocWriteGroup");
            //AuthorizationRules.AllowWrite("NgayKetThucString", "LopHocWriteGroup");
            //AuthorizationRules.AllowWrite("VanbangChungchi", "LopHocWriteGroup");
            //AuthorizationRules.AllowWrite("TenvanbangChungchi", "LopHocWriteGroup");
            //AuthorizationRules.AllowWrite("LoaiVanBang", "LopHocWriteGroup");
            //AuthorizationRules.AllowWrite("MaQuocGiaCap", "LopHocWriteGroup");
            //AuthorizationRules.AllowWrite("MaTruongDaoTao", "LopHocWriteGroup");
            //AuthorizationRules.AllowWrite("GhiChu", "LopHocWriteGroup");
            //AuthorizationRules.AllowWrite("MaChuyenNganhDaoTao", "LopHocWriteGroup");
            //AuthorizationRules.AllowWrite("TrongnuocNgoainuoc", "LopHocWriteGroup");
        }


        public static bool CanGetObject()
        {
            //TODO: Define CanGetObject permission in LopHoc
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("LopHocViewGroup"))
            //	return true;
            //return false;
        }

        public static bool CanAddObject()
        {
            //TODO: Define CanAddObject permission in LopHoc
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("LopHocAddGroup"))
            //	return true;
            //return false;
        }

        public static bool CanEditObject()
        {
            //TODO: Define CanEditObject permission in LopHoc
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("LopHocEditGroup"))
            //	return true;
            //return false;
        }

        public static bool CanDeleteObject()
        {
            //TODO: Define CanDeleteObject permission in LopHoc
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("LopHocDeleteGroup"))
            //	return true;
            //return false;
        }
        #endregion //Authorization Rules

        #region Factory Methods
        private LopHoc()
        { /* require use of factory method */ }

        public static LopHoc NewLopHoc()
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a LopHoc");
            return DataPortal.Create<LopHoc>();
        }

        public static LopHoc NewLopHoc(string tenvanbangChungchi)
        {
            LopHoc lophoc = new LopHoc() { _tenvanbangChungchi = tenvanbangChungchi };
            return lophoc;
        }

        public static LopHoc GetLopHoc(int maLopHoc)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a LopHoc");
            return DataPortal.Fetch<LopHoc>(new Criteria(maLopHoc));
        }

        public static void DeleteLopHoc(int maLopHoc)
        {
            if (!CanDeleteObject())
                throw new System.Security.SecurityException("User not authorized to remove a LopHoc");
            DataPortal.Delete(new Criteria(maLopHoc));
        }

        public static void DeleteLopHoc(LopHoc lopHoc)
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
                        cm.CommandText = "spd_DeletetblnsLopHoc";

                        cm.Parameters.AddWithValue("@MaLopHoc", lopHoc.MaLopHoc);

                        cm.ExecuteNonQuery();
                    }//using
                    tr.Commit();
                }
                catch (Exception ex)
                {
                    tr.Rollback();
                }

            }//using
        }

        public override LopHoc Save()
        {
            if (IsDeleted && !CanDeleteObject())
                throw new System.Security.SecurityException("User not authorized to remove a LopHoc");
            else if (IsNew && !CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a LopHoc");
            else if (!CanEditObject())
                throw new System.Security.SecurityException("User not authorized to update a LopHoc");

            return base.Save();
        }

        #region Bo Sung
        public static bool KiemTraLopHocdaDeCu(int maLopHoc)
        {
            bool result = false;
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "Spd_CheckLopHocdaDeCu";
                    cm.Parameters.AddWithValue("@MaLopHoc", maLopHoc);
                    SqlParameter outPara = new SqlParameter("@DaDeCu", SqlDbType.Bit);
                    outPara.Direction = ParameterDirection.Output;
                    cm.Parameters.Add(outPara);
                    cm.ExecuteNonQuery();
                    result = (bool)outPara.Value;
                }
            }//end using
            return result;
        }//end function

        public static int GetMonth_RemainTime(int maLopHoc)
        {
            int result;
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "Spd_GetMonth_RemainTime";
                    cm.Parameters.AddWithValue("@MaLopHoc", maLopHoc);
                    SqlParameter outPara = new SqlParameter("@Month_remainTime", SqlDbType.Int);
                    outPara.Direction = ParameterDirection.Output;
                    cm.Parameters.Add(outPara);
                    cm.ExecuteNonQuery();
                    result = (int)outPara.Value;
                }
            }//end using
            return result;
        }//end function

        public static bool KiemTraLopHocMoTrungThoiGian_MaLoaiLop(int maLoaiLop, int maLopHoc, DateTime ngayBatDau, DateTime ngayKetThuc)
        {
            bool result = false;
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "Spd_CheckLopHocMoTrungThoiGian_MaLoaiLop";
                    cm.Parameters.AddWithValue("@MaLoaiLop", maLoaiLop);
                    cm.Parameters.AddWithValue("@MaLopHoc", maLopHoc);
                    cm.Parameters.AddWithValue("@NgayBatDau", ngayBatDau);
                    cm.Parameters.AddWithValue("@NgayKetThuc", ngayKetThuc);
                    SqlParameter outPara = new SqlParameter("@TrungThoiGianMoLop", SqlDbType.Bit);
                    outPara.Direction = ParameterDirection.Output;
                    cm.Parameters.Add(outPara);
                    cm.ExecuteNonQuery();
                    result = (bool)outPara.Value;
                }
            }//end using
            return result;
        }//end function

        public static bool KiemTraLopHocDaNopBangKhongChoCapNhat(int maLopHoc)
        {
            bool result = false;
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "Spd_CheckLopHocDaNopBangKhongChoCapNhat";
                    cm.Parameters.AddWithValue("@MaLopHoc", maLopHoc);
                    SqlParameter outPara = new SqlParameter("@DaNopBang", SqlDbType.Bit);
                    outPara.Direction = ParameterDirection.Output;
                    cm.Parameters.Add(outPara);
                    cm.ExecuteNonQuery();
                    result = (bool)outPara.Value;
                }
            }//end using
            return result;
        }//end function

        public static bool KiemTraLopHocDaCoNguoiDiHocKhongChoCapNhat(int maLopHoc)
        {
            bool result = false;
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "Spd_CheckLopHocDaCoNguoiDiHocKhongChoCapNhat";
                    cm.Parameters.AddWithValue("@MaLopHoc", maLopHoc);
                    SqlParameter outPara = new SqlParameter("@CoDiHoc", SqlDbType.Bit);
                    outPara.Direction = ParameterDirection.Output;
                    cm.Parameters.Add(outPara);
                    cm.ExecuteNonQuery();
                    result = (bool)outPara.Value;
                }
            }//end using
            return result;
        }//end function

        public static int GetSoNguoiDiHocOfLopHoc(int maLopHoc)
        {
            int result;
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "Spd_CountSoNguoiDiHocOfLopHoc";
                    cm.Parameters.AddWithValue("@MaLopHoc", maLopHoc);
                    SqlParameter outPara = new SqlParameter("@SoNguoiHoc", SqlDbType.Int);
                    outPara.Direction = ParameterDirection.Output;
                    cm.Parameters.Add(outPara);
                    cm.ExecuteNonQuery();
                    result = (int)outPara.Value;
                }
            }//end using
            return result;
        }//end function
        #endregion

        #endregion //Factory Methods

        #region Child Factory Methods
        internal static LopHoc NewLopHocChild()
        {
            LopHoc child = new LopHoc();
            child.ValidationRules.CheckRules();
            child.MarkAsChild();
            return child;
        }

        internal static LopHoc GetLopHoc(SafeDataReader dr)
        {
            LopHoc child = new LopHoc();
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
            public int MaLopHoc;

            public Criteria(int maLopHoc)
            {
                this.MaLopHoc = maLopHoc;
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
                catch (Exception ex)
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
                cm.CommandText = "spd_SelecttblnsLopHoc";

                cm.Parameters.AddWithValue("@MaLopHoc", criteria.MaLopHoc);

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
                    ExecuteInsert(tr);

                    //update child object(s)
                    UpdateChildren(tr);
                    tr.Commit();
                }
                catch (Exception ex)
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
                        ExecuteUpdate(tr);
                    }

                    //update child object(s)
                    UpdateChildren(tr);
                    tr.Commit();
                }
                catch (Exception ex)
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
            DataPortal_Delete(new Criteria(_maLopHoc));
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
                    //_khoaBieuHoc.Clear();
                    UpdateChildren(tr);
                    ExecuteDelete(tr, criteria);
                    tr.Commit();
                }
                catch (Exception ex)
                {

                }

            }//using

        }

        private void ExecuteDelete(SqlTransaction tr, Criteria criteria)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_DeletetblnsLopHoc";

                cm.Parameters.AddWithValue("@MaLopHoc", criteria.MaLopHoc);

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
            _maLopHoc = dr.GetInt32("MaLopHoc");
            _ngayBatDau = dr.GetSmartDate("NgayBatDau", _ngayBatDau.EmptyIsMin);
            _ngayKetThuc = dr.GetSmartDate("NgayKetThuc", _ngayKetThuc.EmptyIsMin);
            _ngayBatDauChinhThuc = dr.GetSmartDate("NgayBatDauChinhThuc", _ngayBatDauChinhThuc.EmptyIsMin);
            _ngayKetThucChinhThuc = dr.GetSmartDate("NgayKetThucChinhThuc", _ngayKetThucChinhThuc.EmptyIsMin);
            _vanbangChungchi = dr.GetByte("VanBang_ChungChi");
            _tenvanbangChungchi = dr.GetString("TenVanBang_ChungChi");
            _loaiVanBang = dr.GetInt32("LoaiVanBang");
            _maQuocGiaCap = dr.GetInt32("MaQuocGiaCap");
            _maTruongDaoTao = dr.GetInt32("MaTruongDaoTao");
            _ghiChu = dr.GetString("GhiChu");
            _maChuyenNganhDaoTao = dr.GetInt32("MaChuyenNganhDaoTao");
            _trongnuocNgoainuoc = dr.GetByte("TrongNuoc_NgoaiNuoc");
            _maLoaiLop = dr.GetInt32("MaLoaiLop");
            _maDonViDaoTao = dr.GetInt32("MaDonViDaoTao");

            _SoNguoiHoc = dr.GetInt32("SoNguoiHoc");
            _NguoiPTThanhToan = dr.GetString("NguoiPTThanhToan");
            _SoHopDong = dr.GetString("SoHopDong");
            _NgayHopDong = dr.GetSmartDate("NgayHopDong");
            _DonGia = dr.GetDecimal("DonGia");
            _TongTien = dr.GetDecimal("TongTien");
            _DaThanhToan = dr.GetDecimal("DaThanhToan");
            _ConLai = dr.GetDecimal("ConLai");
            _GhiChuThanhToan = dr.GetString("GhiChuThanhToan");
        }

        private void FetchChildren(SafeDataReader dr)
        {
            //_khoaBieuHoc = KhoaBieuHocChildList.GetKhoaBieuHocChildList(this.MaLopHoc);
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
                cm.CommandText = "spd_InserttblnsLopHoc";

                AddInsertParameters(cm);

                cm.ExecuteNonQuery();

                _maLopHoc = (int)cm.Parameters["@MaLopHoc"].Value;
            }//using
        }

        private void AddInsertParameters(SqlCommand cm)
        {
            cm.Parameters.AddWithValue("@NgayBatDau", _ngayBatDau.DBValue);
            cm.Parameters.AddWithValue("@NgayKetThuc", _ngayKetThuc.DBValue);
            cm.Parameters.AddWithValue("@NgayBatDauChinhThuc", _ngayBatDauChinhThuc.DBValue);
            cm.Parameters.AddWithValue("@NgayKetThucChinhThuc", _ngayKetThucChinhThuc.DBValue);
            if (_vanbangChungchi != 0)
                cm.Parameters.AddWithValue("@VanBang_ChungChi", _vanbangChungchi);
            else
                cm.Parameters.AddWithValue("@VanBang_ChungChi", DBNull.Value);
            if (_tenvanbangChungchi.Length > 0)
                cm.Parameters.AddWithValue("@TenVanBang_ChungChi", _tenvanbangChungchi);
            else
                cm.Parameters.AddWithValue("@TenVanBang_ChungChi", DBNull.Value);
            if (_loaiVanBang != 0)
                cm.Parameters.AddWithValue("@LoaiVanBang", _loaiVanBang);
            else
                cm.Parameters.AddWithValue("@LoaiVanBang", DBNull.Value);
            if (_maQuocGiaCap != 0)
                cm.Parameters.AddWithValue("@MaQuocGiaCap", _maQuocGiaCap);
            else
                cm.Parameters.AddWithValue("@MaQuocGiaCap", DBNull.Value);
            if (_maTruongDaoTao != 0)
                cm.Parameters.AddWithValue("@MaTruongDaoTao", _maTruongDaoTao);
            else
                cm.Parameters.AddWithValue("@MaTruongDaoTao", DBNull.Value);
            if (_ghiChu.Length > 0)
                cm.Parameters.AddWithValue("@GhiChu", _ghiChu);
            else
                cm.Parameters.AddWithValue("@GhiChu", DBNull.Value);
            if (_maChuyenNganhDaoTao != 0)
                cm.Parameters.AddWithValue("@MaChuyenNganhDaoTao", _maChuyenNganhDaoTao);
            else
                cm.Parameters.AddWithValue("@MaChuyenNganhDaoTao", DBNull.Value);
            if (_trongnuocNgoainuoc != 0)
                cm.Parameters.AddWithValue("@TrongNuoc_NgoaiNuoc", _trongnuocNgoainuoc);
            else
                cm.Parameters.AddWithValue("@TrongNuoc_NgoaiNuoc", DBNull.Value);
            if (_maLoaiLop != 0)
                cm.Parameters.AddWithValue("@MaLoaiLop", _maLoaiLop);
            else
                cm.Parameters.AddWithValue("@MaLoaiLop", DBNull.Value);
            if (_maDonViDaoTao != 0)
                cm.Parameters.AddWithValue("@MaDonViDaoTao", _maDonViDaoTao);
            else
                cm.Parameters.AddWithValue("@MaDonViDaoTao", DBNull.Value);

//==
            if (_SoNguoiHoc != 0)
                cm.Parameters.AddWithValue("@SoNguoiHoc", _SoNguoiHoc);
            else
                cm.Parameters.AddWithValue("@SoNguoiHoc", DBNull.Value);

            if (_NguoiPTThanhToan.Length > 0)
                cm.Parameters.AddWithValue("@NguoiPTThanhToan", _NguoiPTThanhToan);
            else
                cm.Parameters.AddWithValue("@NguoiPTThanhToan", DBNull.Value);

            if (_SoHopDong.Length > 0)
                cm.Parameters.AddWithValue("@SoHopDong", _SoHopDong);
            else
                cm.Parameters.AddWithValue("@SoHopDong", DBNull.Value);

            cm.Parameters.AddWithValue("NgayHopDong", _NgayHopDong.DBValue);
            if (_DonGia != 0)
                cm.Parameters.AddWithValue("@DonGia", _DonGia);
            else
                cm.Parameters.AddWithValue("@DonGia", DBNull.Value);

            if (_TongTien != 0)
                cm.Parameters.AddWithValue("@TongTien", _TongTien);
            else
                cm.Parameters.AddWithValue("@TongTien", DBNull.Value);

            if (_DaThanhToan != 0)
                cm.Parameters.AddWithValue("@DaThanhToan", _DaThanhToan);
            else
                cm.Parameters.AddWithValue("@DaThanhToan", DBNull.Value);

            if (_ConLai != 0)
                cm.Parameters.AddWithValue("@ConLai", _ConLai);
            else
                cm.Parameters.AddWithValue("@ConLai", DBNull.Value);

            if (_GhiChuThanhToan.Length > 0)
                cm.Parameters.AddWithValue("@GhiChuThanhToan", _GhiChuThanhToan);
            else
                cm.Parameters.AddWithValue("@GhiChuThanhToan", DBNull.Value);

            cm.Parameters.AddWithValue("@MaLopHoc", _maLopHoc);
            cm.Parameters["@MaLopHoc"].Direction = ParameterDirection.Output;
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
            }

            //update child object(s)
            UpdateChildren(tr);
        }

        private void ExecuteUpdate(SqlTransaction tr)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_UpdatetblnsLopHoc";

                AddUpdateParameters(cm);

                cm.ExecuteNonQuery();

            }//using
        }

        private void AddUpdateParameters(SqlCommand cm)
        {
            cm.Parameters.AddWithValue("@MaLopHoc", _maLopHoc);
            cm.Parameters.AddWithValue("@NgayBatDau", _ngayBatDau.DBValue);
            cm.Parameters.AddWithValue("@NgayKetThuc", _ngayKetThuc.DBValue);
            cm.Parameters.AddWithValue("@NgayBatDauChinhThuc", _ngayBatDauChinhThuc.DBValue);
            cm.Parameters.AddWithValue("@NgayKetThucChinhThuc", _ngayKetThucChinhThuc.DBValue);
            if (_vanbangChungchi != 0)
                cm.Parameters.AddWithValue("@VanBang_ChungChi", _vanbangChungchi);
            else
                cm.Parameters.AddWithValue("@VanBang_ChungChi", DBNull.Value);
            if (_tenvanbangChungchi.Length > 0)
                cm.Parameters.AddWithValue("@TenVanBang_ChungChi", _tenvanbangChungchi);
            else
                cm.Parameters.AddWithValue("@TenVanBang_ChungChi", DBNull.Value);
            if (_loaiVanBang != 0)
                cm.Parameters.AddWithValue("@LoaiVanBang", _loaiVanBang);
            else
                cm.Parameters.AddWithValue("@LoaiVanBang", DBNull.Value);
            if (_maQuocGiaCap != 0)
                cm.Parameters.AddWithValue("@MaQuocGiaCap", _maQuocGiaCap);
            else
                cm.Parameters.AddWithValue("@MaQuocGiaCap", DBNull.Value);
            if (_maTruongDaoTao != 0)
                cm.Parameters.AddWithValue("@MaTruongDaoTao", _maTruongDaoTao);
            else
                cm.Parameters.AddWithValue("@MaTruongDaoTao", DBNull.Value);
            if (_ghiChu.Length > 0)
                cm.Parameters.AddWithValue("@GhiChu", _ghiChu);
            else
                cm.Parameters.AddWithValue("@GhiChu", DBNull.Value);
            if (_maChuyenNganhDaoTao != 0)
                cm.Parameters.AddWithValue("@MaChuyenNganhDaoTao", _maChuyenNganhDaoTao);
            else
                cm.Parameters.AddWithValue("@MaChuyenNganhDaoTao", DBNull.Value);
            if (_maLoaiLop != 0)
                cm.Parameters.AddWithValue("@MaLoaiLop", _maLoaiLop);
            else
                cm.Parameters.AddWithValue("@MaLoaiLop", DBNull.Value);
            if (_maDonViDaoTao != 0)
                cm.Parameters.AddWithValue("@MaDonViDaoTao", _maDonViDaoTao);
            else
                cm.Parameters.AddWithValue("@MaDonViDaoTao", DBNull.Value);
            if (_trongnuocNgoainuoc != 0)
                cm.Parameters.AddWithValue("@TrongNuoc_NgoaiNuoc", _trongnuocNgoainuoc);
            else
                cm.Parameters.AddWithValue("@TrongNuoc_NgoaiNuoc", DBNull.Value);
            //===
            if (_SoNguoiHoc != 0)
                cm.Parameters.AddWithValue("@SoNguoiHoc", _SoNguoiHoc);
            else
                cm.Parameters.AddWithValue("@SoNguoiHoc", DBNull.Value);

            if (_NguoiPTThanhToan.Length > 0)
                cm.Parameters.AddWithValue("@NguoiPTThanhToan", _NguoiPTThanhToan);
            else
                cm.Parameters.AddWithValue("@NguoiPTThanhToan", DBNull.Value);

            if (_SoHopDong.Length > 0)
                cm.Parameters.AddWithValue("@SoHopDong", _SoHopDong);
            else
                cm.Parameters.AddWithValue("@SoHopDong", DBNull.Value);

            cm.Parameters.AddWithValue("NgayHopDong", _NgayHopDong.DBValue);
            if (_DonGia != 0)
                cm.Parameters.AddWithValue("@DonGia", _DonGia);
            else
                cm.Parameters.AddWithValue("@DonGia", DBNull.Value);

            if (_TongTien != 0)
                cm.Parameters.AddWithValue("@TongTien", _TongTien);
            else
                cm.Parameters.AddWithValue("@TongTien", DBNull.Value);

            if (_DaThanhToan != 0)
                cm.Parameters.AddWithValue("@DaThanhToan", _DaThanhToan);
            else
                cm.Parameters.AddWithValue("@DaThanhToan", DBNull.Value);

            if (_ConLai != 0)
                cm.Parameters.AddWithValue("@ConLai", _ConLai);
            else
                cm.Parameters.AddWithValue("@ConLai", DBNull.Value);

            if (_GhiChuThanhToan.Length > 0)
                cm.Parameters.AddWithValue("@GhiChuThanhToan", _GhiChuThanhToan);
            else
                cm.Parameters.AddWithValue("@GhiChuThanhToan", DBNull.Value);
        }

        private void UpdateChildren(SqlTransaction tr)
        {
            //_khoaBieuHoc.Update(tr, this);
        }
        #endregion //Data Access - Update

        #region Data Access - Delete
        internal void DeleteSelf(SqlTransaction tr)
        {
            if (!IsDirty) return;
            if (IsNew) return;

            //_khoaBieuHoc.Clear();
            UpdateChildren(tr);
            ExecuteDelete(tr, new Criteria(_maLopHoc));
            MarkNew();
        }
        #endregion //Data Access - Delete
        #endregion //Data Access
    }
}
