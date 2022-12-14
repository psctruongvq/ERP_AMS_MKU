using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library.ThanhToan
{
    [Serializable()]
    public class DeNghiChuyenKhoan : Csla.BusinessBase<DeNghiChuyenKhoan>
    {
        #region Business Properties and Methods

        //declare members
        internal long _maPhieu = 0;
        private string _so = string.Empty;
        private DateTime _ngay = DateTime.Today;
        private int _maBoPhan = ERP_Library.Security.CurrentUser.Info.MaBoPhan;
        private long _maNhanVien = ERP_Library.Security.CurrentUser.Info.MaNhanVien;
        private string _lyDo = string.Empty;
        private decimal _soTien = 0;
        private string _maPhanHe = string.Empty;
        private string _tinhTrang = "";
        private DeNghiChuyenKhoan_ChungTuList _chungtu;
        private bool _hoanTat = false;
        private int _userID = ERP_Library.Security.CurrentUser.Info.UserID;
        private string _soTaiKhoanNhan = "";
        private string _nganHangNhan = "";
        private string _tenNguoiNhan = "";
        private Nullable<int> _maTaiKhoanChuyen = null;
        private bool _daDuyet = false;
        private bool _daMua = false;
        private int _maDatabaseGui = 0;
        private int _maDatabaseNhan = 0;
        private string _nganHangChuyen = "";

        /// <summary>
        /// Tran Them vao xu ly thu chi
        /// 
        private string _tenBoPhan = string.Empty;
        private string _tenNhanVien = string.Empty;
        private decimal _soTienThanhToan = 0;
        private decimal _tongTien = 0;
        private decimal _soTienConLai = 0;
        private ChungTu_DeNghiChuyenKhoanChildList _chungTu_DeNghiChuyenKhoan;
        private string _soTaiKhoan = "";
        private long _maCTDNCK = 0;
        private bool _loai = false;
        private bool _chon = false;
        private int _loaiCT = 0; //Loai 0: De Nghi Chuyen Khoan - Loai 1: Chung Tu Ngan Hang
        private DateTime? _ngayXacNhan = DateTime.Now.Date;
        private decimal _tyGia = 1;
        private decimal _thanhTien = 0;
        private long _maHopDong = 0;

        private DeNghiChuyenKhoan_DichVuList _deNghiChuyenKhoan_DichVuList = DeNghiChuyenKhoan_DichVuList.NewDeNghiChuyenKhoan_DichVuList();
        private DeNghiChuyenKhoan_TKPhu _deNghiChuyenKhoan_TKPhu = DeNghiChuyenKhoan_TKPhu.NewDeNghiChuyenKhoan_TKPhu();

        //Thành thêm cột "Chọn" (05/04/2012)
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

        public long MaCTDNCK
        {
            get { return _maCTDNCK; }
            set { _maCTDNCK = value; }
        }
        public string SoTaiKhoan
        {
            get
            {
                CanReadProperty("SoTaiKhoan", true);
                if (_maTaiKhoanChuyen != null)
                    _soTaiKhoan = (CongTy_NganHang.GetCongTy_NganHang(_maTaiKhoanChuyen.Value)).SoTaiKhoan;
                return _soTaiKhoan;
            }

        }
        private string _tenNganHang = "";

        public string TenNganHang
        {

            get
            {
                CanReadProperty("TenNganHang", true);
                if (_maTaiKhoanChuyen != null)
                    _tenNganHang = NganHang.GetNganHang((CongTy_NganHang.GetCongTy_NganHang(_maTaiKhoanChuyen.Value)).MaNganHang).TenNganHang;
                return _tenNganHang;
            }

        }
        public ChungTu_DeNghiChuyenKhoanChildList ChungTu_DeNghiChuyenKhoan
        {
            get
            {
                CanReadProperty(true);
                return _chungTu_DeNghiChuyenKhoan;
            }
            set
            {
                CanWriteProperty(true);
                _chungTu_DeNghiChuyenKhoan = value;
            }
        }
        public decimal SoTienConLai
        {
            get { return _soTienConLai; }
            set
            {
                if (!_soTienConLai.Equals(value))
                {
                    _soTienConLai = value;
                    PropertyHasChanged("SoTienConLai");
                }
            }
        }



        private Boolean _check = false;
        public Boolean Check
        {
            get { return _check; }
            set
            {
                _check = value;
            }
        }
        public decimal SoTienThanhToan
        {
            get { return _soTienThanhToan; }
            set { _soTienThanhToan = value; }
        }
        public decimal TongTien
        {
            get { return _tongTien; }
            set { _tongTien = value; }
        }
        [System.ComponentModel.DataObjectField(true, true)]
        public long MaPhieu
        {
            get
            {
                return _maPhieu;
            }
        }

        public string So
        {
            get
            {
                return _so;
            }
            set
            {
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
                return _ngay;
            }
            set
            {
                if (!_ngay.Equals(value))
                {
                    _ngay = value;
                    PropertyHasChanged("Ngay");
                }
            }
        }

        public int MaBoPhan
        {
            get
            {
                return _maBoPhan;
            }
            set
            {
                if (!_maBoPhan.Equals(value))
                {
                    _maBoPhan = value;
                    PropertyHasChanged("MaBoPhan");
                }
            }
        }
        public string TenBoPhan
        {
            get
            {
                CanReadProperty("TenBoPhan", true);

                return BoPhan.GetBoPhan(_maBoPhan).TenBoPhan;
            }

        }
        public long MaNhanVien
        {
            get
            {
                return _maNhanVien;
            }
            set
            {
                if (!_maNhanVien.Equals(value))
                {
                    _maNhanVien = value;
                    PropertyHasChanged("MaNhanVien");
                }
            }
        }
        public string TenNhanVien
        {
            get
            {
                CanReadProperty("TenNhanVien", true);

                return NhanVien.GetNhanVien(_maNhanVien).TenNhanVien;
            }

        }

        public string LyDo
        {
            get
            {
                return _lyDo;
            }
            set
            {
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
                return _soTien;
            }
            set
            {
                if (!_soTien.Equals(value))
                {
                    _soTien = value;
                    _thanhTien = _soTien * _tyGia;
                    PropertyHasChanged("SoTien");
                }
            }
        }

        public string MaPhanHe
        {
            get
            {
                return _maPhanHe;
            }
            set
            {
                if (value == null) value = string.Empty;
                if (!_maPhanHe.Equals(value))
                {
                    _maPhanHe = value;
                    PropertyHasChanged("MaPhanHe");
                }
            }
        }

        public string TinhTrang
        {
            get
            {
                return _tinhTrang;
            }
            set
            {
                if (!_tinhTrang.Equals(value))
                {
                    _tinhTrang = value;
                    PropertyHasChanged();
                }
            }
        }

        public bool HoanTat
        {
            get
            {
                return _hoanTat;
            }
            set
            {
                if (!_hoanTat.Equals(value))
                {
                    _hoanTat = value;
                    PropertyHasChanged();
                }
            }
        }

        public bool DaDuyet
        {
            get
            {
                return _daDuyet;
            }
            set
            {
                if (!_daDuyet.Equals(value))
                {
                    _daDuyet = value;
                    PropertyHasChanged();
                }
            }
        }

        public bool DaMua
        {
            get
            {
                return _daMua;
            }
            set
            {
                if (!_daMua.Equals(value))
                {
                    _daMua = value;
                    PropertyHasChanged();
                }
            }
        }

        public string SoTaiKhoanNhan
        {
            get
            {
                return _soTaiKhoanNhan;
            }
            set
            {
                if (!_soTaiKhoanNhan.Equals(value))
                {
                    _soTaiKhoanNhan = value;
                    PropertyHasChanged();
                }
            }
        }
        public string NganHangNhan
        {
            get
            {
                return _nganHangNhan;
            }
            set
            {
                if (!_nganHangNhan.Equals(value))
                {
                    _nganHangNhan = value;
                    PropertyHasChanged();
                }
            }
        }

        public string TenNguoiNhan
        {
            get
            {
                return _tenNguoiNhan;
            }
            set
            {
                if (!_tenNguoiNhan.Equals(value))
                {
                    _tenNguoiNhan = value;
                    PropertyHasChanged();
                }
            }
        }

        public Nullable<int> MaTaiKhoanChuyen
        {
            get
            {
                return _maTaiKhoanChuyen;
            }

            set
            {
                if (!_maTaiKhoanChuyen.Equals(value))
                {
                    _maTaiKhoanChuyen = value;
                    PropertyHasChanged();
                    if (_maTaiKhoanChuyen.HasValue)
                        NganHangChuyen = CongTy_NganHang.GetCongTy_NganHang(_maTaiKhoanChuyen.Value).TenNganHang;
                    else
                        NganHangChuyen = "";
                }
            }
        }

        public string NganHangChuyen
        {
            get
            {
                return _nganHangChuyen;
            }
            set
            {
                if (!_nganHangChuyen.Equals(value))
                {
                    _nganHangChuyen = value;
                    PropertyHasChanged();
                }
            }
        }


        public DeNghiChuyenKhoan_ChungTuList ChungTu
        {
            get
            {
                return _chungtu;
            }
        }

        public int MaDatabaseGui
        {
            get
            {
                return _maDatabaseGui;
            }
            set
            {
                if (!_maDatabaseGui.Equals(value))
                {
                    _maDatabaseGui = value;
                    PropertyHasChanged();
                }
            }
        }

        public int MaDatabaseNhan
        {
            get
            {
                return _maDatabaseNhan;
            }
            set
            {
                if (!_maDatabaseNhan.Equals(value))
                {
                    _maDatabaseNhan = value;
                    PropertyHasChanged();
                }
            }
        }


        public Boolean Loai
        {
            get { return _loai; }
            set
            {
                _loai = value;
            }
        }

        public int LoaiCT
        {
            get
            {
                return _loaiCT;
            }
            set
            {
                if (!_loaiCT.Equals(value))
                {
                    _loaiCT = value;
                    PropertyHasChanged("LoaiCT");
                }
            }
        }

        public DateTime? NgayXacNhan
        {
            get
            {
                if (_ngayXacNhan == DateTime.MinValue)
                    return null;
                return _ngayXacNhan;
            }
        }

        public string LoaiChungTu
        {
            get
            {
                if (LoaiCT == 4)
                    return "Lệnh chuyển tiền";
                else if (LoaiCT == 2)
                    return "Giấy báo có";
                else if (LoaiCT == 3)
                    return "Đề nghị bán ngoại tệ";
                else if (LoaiCT == 5)
                    return "Ủy Nhiệm Chi";
                else if (LoaiCT == 6)
                    return "Phí Ngân Hàng";
                else if (LoaiCT == 7)
                    return "Giấy rút tiền";
                else if (LoaiCT == 8)
                    return "Điều chuyển nội bộ";
                return "Đề nghị chuyển khoản";
            }
        }

        public DeNghiChuyenKhoan_DichVuList DeNghiDichVuList
        {
            get
            {
                CanReadProperty("DeNghiDichVuList", true);
                return _deNghiChuyenKhoan_DichVuList;
            }
            set
            {
                CanWriteProperty("DeNghiDichVuList", true);
                if (!_deNghiChuyenKhoan_DichVuList.Equals(value))
                {
                    _deNghiChuyenKhoan_DichVuList = value;
                    PropertyHasChanged("DeNghiDichVuList");
                }
            }
        }

        public DeNghiChuyenKhoan_TKPhu TaiKhoanPhu
        {
            get
            {
                CanReadProperty("TaiKhoanPhu", true);
                return _deNghiChuyenKhoan_TKPhu;
            }
            set
            {
                CanWriteProperty("TaiKhoanPhu", true);
                if (!_deNghiChuyenKhoan_TKPhu.Equals(value))
                {
                    _deNghiChuyenKhoan_TKPhu = value;
                    PropertyHasChanged("TaiKhoanPhu");
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
                    _thanhTien = _soTien * _tyGia;
                    PropertyHasChanged("TyGia");
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
        }

        public long MaHopDong
        {
            get
            {
                CanReadProperty("MaHopDong", true);
                return _maHopDong;
            }
            set
            {
                CanWriteProperty("MaHopDong", true);
                if (!_maHopDong.Equals(value))
                {
                    _maHopDong = value;
                    PropertyHasChanged("MaHopDong");
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
            //ValidationRules.AddRule(CommonRules.StringRequired, "So");
            //ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("So", 50));
            ////
            //// LyDo
            ////
            //ValidationRules.AddRule(CommonRules.StringRequired, "LyDo");
            //ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("LyDo", 250));
            ////
            //// MaPhanHe
            ////
            //ValidationRules.AddRule(CommonRules.StringRequired, "MaPhanHe");
            //ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("MaPhanHe", 50));
        }

        protected override void AddBusinessRules()
        {
            // AddCommonRules();
            // AddCustomRules();
        }
        #endregion //Validation Rules

        #region Authorization Rules

        public static bool CanGetObject()
        {
            //TODO: Define CanGetObject permission in DeNghiChuyenKhoan
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("DeNghiChuyenKhoanViewGroup"))
            //	return true;
            //return false;
        }

        public static bool CanAddObject()
        {
            //TODO: Define CanAddObject permission in DeNghiChuyenKhoan
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("DeNghiChuyenKhoanAddGroup"))
            //	return true;
            //return false;
        }

        public static bool CanEditObject()
        {
            //TODO: Define CanEditObject permission in DeNghiChuyenKhoan
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("DeNghiChuyenKhoanEditGroup"))
            //	return true;
            //return false;
        }

        public static bool CanDeleteObject()
        {
            //TODO: Define CanDeleteObject permission in DeNghiChuyenKhoan
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("DeNghiChuyenKhoanDeleteGroup"))
            //	return true;
            //return false;
        }
        #endregion //Authorization Rules

        #region Factory Methods
        private DeNghiChuyenKhoan()
        { /* require use of factory method */
            _chungtu = DeNghiChuyenKhoan_ChungTuList.NewDeNghiChuyenKhoan_ChungTuList();
            _maDatabaseGui = ERP_Library.Security.CurrentUser.Info.MaCongTy;
            _maDatabaseNhan = _maDatabaseGui;
        }

        public static DeNghiChuyenKhoan NewDeNghiChuyenKhoan()
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a DeNghiChuyenKhoan");
            return DataPortal.Create<DeNghiChuyenKhoan>();
        }
        public static DeNghiChuyenKhoan NewDeNghiChuyenKhoan(string tenPhieu)
        {
            DeNghiChuyenKhoan item = new DeNghiChuyenKhoan();
            item._so = tenPhieu;
            return item;
        }
        public static DeNghiChuyenKhoan GetDeNghiChuyenKhoan(long maPhieu)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a DeNghiChuyenKhoan");
            return DataPortal.Fetch<DeNghiChuyenKhoan>(new Criteria(maPhieu));
        }

        #region BoSung
        public static DeNghiChuyenKhoan NewDeNghiChuyenKhoan(DeNghiChuyenKhoan deNghiChuyenKhoan)
        {
            DeNghiChuyenKhoan NewDeNghi = new DeNghiChuyenKhoan();
            //Lấy dữ liệu cho DeNghi mới
            NewDeNghi.Ngay = DateTime.Now.Date;
            NewDeNghi.MaBoPhan = deNghiChuyenKhoan.MaBoPhan;
            NewDeNghi.MaNhanVien = deNghiChuyenKhoan.MaNhanVien;
            NewDeNghi.LyDo = deNghiChuyenKhoan.LyDo;
            NewDeNghi.SoTien = deNghiChuyenKhoan.SoTien;
            NewDeNghi.MaPhanHe = deNghiChuyenKhoan.MaPhanHe;
            NewDeNghi.TinhTrang = deNghiChuyenKhoan.TinhTrang;
            //HoanTat
            NewDeNghi.SoTaiKhoanNhan = deNghiChuyenKhoan.SoTaiKhoanNhan;
            NewDeNghi.NganHangNhan = deNghiChuyenKhoan.NganHangNhan;
            NewDeNghi.TenNguoiNhan = deNghiChuyenKhoan.TenNguoiNhan;
            NewDeNghi.MaTaiKhoanChuyen = deNghiChuyenKhoan.MaTaiKhoanChuyen;
            //SoTienConLai
            //DaDuyet
            NewDeNghi.MaDatabaseNhan = deNghiChuyenKhoan.MaDatabaseNhan;
            NewDeNghi.NganHangChuyen = deNghiChuyenKhoan.NganHangChuyen;
            NewDeNghi.MaHopDong = deNghiChuyenKhoan.MaHopDong;
            //ChungTu_DeNghiChuyenKhoanChildList ChungTu_DeNghiChuyenKhoan
            if (deNghiChuyenKhoan.ChungTu_DeNghiChuyenKhoan != null)
                foreach (ChungTu_DeNghiChuyenKhoanChild chungtu_denghichuyenkhoan in deNghiChuyenKhoan.ChungTu_DeNghiChuyenKhoan)
                {
                    ChungTu_DeNghiChuyenKhoanChild newItem = ChungTu_DeNghiChuyenKhoanChild.NewChungTu_DeNghiChuyenKhoanChild();
                    newItem.MaCT = chungtu_denghichuyenkhoan.MaCT;
                    newItem.SoTien = chungtu_denghichuyenkhoan.SoTien;
                    newItem.SoChungTu = chungtu_denghichuyenkhoan.SoChungTu;
                    newItem.LyDo = chungtu_denghichuyenkhoan.LyDo;
                    NewDeNghi.ChungTu_DeNghiChuyenKhoan.Add(newItem);
                }
            //DeNghiChuyenKhoan_ChungTuList ChungTu
            if (deNghiChuyenKhoan.ChungTu != null)
                foreach (DeNghiChuyenKhoan_ChungTu deNghiChuyenKhoan_ChungTu in deNghiChuyenKhoan.ChungTu)
                {
                    DeNghiChuyenKhoan_ChungTu newItem = DeNghiChuyenKhoan_ChungTu.NewDeNghiChuyenKhoan_ChungTu();
                    newItem.MaLoaiChungTu = deNghiChuyenKhoan_ChungTu.MaLoaiChungTu;
                    newItem.DienGiai = deNghiChuyenKhoan_ChungTu.DienGiai;
                    newItem.SoTien = deNghiChuyenKhoan_ChungTu.SoTien;
                    newItem.DuLieuChungTu = deNghiChuyenKhoan_ChungTu.DuLieuChungTu;
                    NewDeNghi.ChungTu.Add(newItem);
                }
            //_deNghiCanDeCopy.DeNghiDichVuList
            if (deNghiChuyenKhoan.DeNghiDichVuList != null)
                foreach (DeNghiChuyenKhoan_DichVu deNghiChuyenKhoan_DichVu in deNghiChuyenKhoan.DeNghiDichVuList)
                {
                    DeNghiChuyenKhoan_DichVu newItem = DeNghiChuyenKhoan_DichVu.NewDeNghiChuyenKhoan_DichVu();
                    newItem.MaDoiTac = deNghiChuyenKhoan_DichVu.MaDoiTac;
                    newItem.TenDoiTac = deNghiChuyenKhoan_DichVu.TenDoiTac;
                    newItem.SoTaiKhoan = deNghiChuyenKhoan_DichVu.SoTaiKhoan;
                    newItem.SoTien = deNghiChuyenKhoan_DichVu.SoTien;
                    newItem.MaNganHang = deNghiChuyenKhoan_DichVu.MaNganHang;
                    newItem.TenNganHang = deNghiChuyenKhoan_DichVu.TenNganHang;
                    newItem.MaLoaiChungTu = deNghiChuyenKhoan_DichVu.MaLoaiChungTu;
                    newItem.GhiChu = deNghiChuyenKhoan_DichVu.GhiChu;
                    newItem.Cmnd = deNghiChuyenKhoan_DichVu.Cmnd;
                    newItem.ThongTinKhac = deNghiChuyenKhoan_DichVu.ThongTinKhac;
                    newItem.SoTienTruocThue = deNghiChuyenKhoan_DichVu.SoTienTruocThue;
                    newItem.GhiChu = deNghiChuyenKhoan_DichVu.GhiChu;

                    NewDeNghi.DeNghiDichVuList.Add(newItem);
                }
            if (deNghiChuyenKhoan.TaiKhoanPhu != null)
            {
                NewDeNghi.TaiKhoanPhu = DeNghiChuyenKhoan_TKPhu.NewDeNghiChuyenKhoan_TKPhu();
                NewDeNghi.TaiKhoanPhu.MaDoiTac = deNghiChuyenKhoan.TaiKhoanPhu.MaDoiTac;
                NewDeNghi.TaiKhoanPhu.TenDoiTac = deNghiChuyenKhoan.TaiKhoanPhu.TenDoiTac;
                NewDeNghi.TaiKhoanPhu.SoTaiKhoan = deNghiChuyenKhoan.TaiKhoanPhu.SoTaiKhoan;
                NewDeNghi.TaiKhoanPhu.MaTKPhu = deNghiChuyenKhoan.TaiKhoanPhu.MaTKPhu;
                NewDeNghi.TaiKhoanPhu.IsTaiKhoanPhu = deNghiChuyenKhoan.TaiKhoanPhu.IsTaiKhoanPhu;
                  
            }


            return NewDeNghi;
        }
        #endregion

        public static void DeleteDeNghiChuyenKhoan(long maPhieu)
        {
            if (!CanDeleteObject())
                throw new System.Security.SecurityException("User not authorized to remove a DeNghiChuyenKhoan");
            DataPortal.Delete(new Criteria(maPhieu));
        }

        public override DeNghiChuyenKhoan Save()
        {
            if (IsDeleted && !CanDeleteObject())
                throw new System.Security.SecurityException("User not authorized to remove a DeNghiChuyenKhoan");
            else if (IsNew && !CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a DeNghiChuyenKhoan");
            else if (!CanEditObject())
                throw new System.Security.SecurityException("User not authorized to update a DeNghiChuyenKhoan");

            return base.Save();
        }

        #endregion //Factory Methods

        #region Child Factory Methods
        internal static DeNghiChuyenKhoan NewDeNghiChuyenKhoanChild()
        {
            DeNghiChuyenKhoan child = new DeNghiChuyenKhoan();
            child.ValidationRules.CheckRules();
            child.MarkAsChild();
            return child;
        }

        internal static DeNghiChuyenKhoan GetDeNghiChuyenKhoan(SafeDataReader dr)
        {
            DeNghiChuyenKhoan child = new DeNghiChuyenKhoan();
            child.MarkAsChild();
            child.Fetch(dr);
            child._chungtu = DeNghiChuyenKhoan_ChungTuList.GetDeNghiChuyenKhoan_ChungTuList(child._maPhieu);
            //child._chungTu_DeNghiChuyenKhoan = ChungTu_DeNghiChuyenKhoanChildList.GetChungTu_DeNghiChuyenKhoanChildList(child.MaPhieu);
            return child;
        }

        internal static DeNghiChuyenKhoan GetDeNghiChuyenKhoan_New(SafeDataReader dr)
        {
            DeNghiChuyenKhoan child = new DeNghiChuyenKhoan();
            child.MarkAsChild();
            child.Fetch_New(dr);
            child._chungtu = DeNghiChuyenKhoan_ChungTuList.GetDeNghiChuyenKhoan_ChungTuList(child._maPhieu);
            //child._chungTu_DeNghiChuyenKhoan = ChungTu_DeNghiChuyenKhoanChildList.GetChungTu_DeNghiChuyenKhoanChildList(child.MaPhieu);
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
                cm.CommandText = "spd_Select_DeNghiChuyenKhoan";

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
            _chungtu = DeNghiChuyenKhoan_ChungTuList.GetDeNghiChuyenKhoan_ChungTuList(_maPhieu);
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
                        ExecuteUpdate(tr);
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
                cm.CommandTimeout = 0;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_Delete_DeNghiChuyenKhoan";

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
            _maPhieu = dr.GetInt64("MaPhieu");
            _so = dr.GetString("So");
            _ngay = dr.GetDateTime("Ngay");
            _maBoPhan = dr.GetInt32("MaBoPhan");
            _maNhanVien = dr.GetInt64("MaNhanVien");
            _lyDo = dr.GetString("LyDo");
            _soTien = dr.GetDecimal("SoTien");
            _maPhanHe = dr.GetString("MaPhanHe");
            _tinhTrang = dr.GetString("TinhTrang");
            _hoanTat = dr.GetBoolean("HoanTat");
            _userID = dr.GetInt32("UserID");
            _soTaiKhoanNhan = dr.GetString("SoTaiKhoanNhan");
            _nganHangNhan = dr.GetString("NganHangNhan");
            _tenNguoiNhan = dr.GetString("TenNguoiNhan");
            _maTaiKhoanChuyen = (Nullable<int>)dr.GetValue("MaTaiKhoanChuyen");
            _soTienConLai = dr.GetDecimal("SoTienConLai");
            _daDuyet = dr.GetBoolean("DaDuyet");
            _maDatabaseGui = dr.GetInt32("MaDatabaseGui");
            _maDatabaseNhan = dr.GetInt32("MaDatabaseNhan");
            _nganHangChuyen = dr.GetString("NganHangChuyen");
            _maHopDong = dr.GetInt64("MaHopDong");
        }

        private void FetchObject_New(SafeDataReader dr)
        {
            _maPhieu = dr.GetInt64("MaPhieu");
            _so = dr.GetString("So");
            _ngay = dr.GetDateTime("Ngay");
            _maBoPhan = dr.GetInt32("MaBoPhan");
            _maNhanVien = dr.GetInt64("MaNhanVien");
            _lyDo = dr.GetString("LyDo");
            _soTien = dr.GetDecimal("SoTien");
            _maPhanHe = dr.GetString("MaPhanHe");
            _tinhTrang = dr.GetString("TinhTrang");
            _hoanTat = dr.GetBoolean("HoanTat");
            _userID = dr.GetInt32("UserID");
            _soTaiKhoanNhan = dr.GetString("SoTaiKhoanNhan");
            _nganHangNhan = dr.GetString("NganHangNhan");
            _tenNguoiNhan = dr.GetString("TenNguoiNhan");
            _maTaiKhoanChuyen = (Nullable<int>)dr.GetValue("MaTaiKhoanChuyen");
            _soTienConLai = dr.GetDecimal("SoTienConLai");
            _daDuyet = dr.GetBoolean("DaDuyet");
            _maDatabaseGui = dr.GetInt32("MaDatabaseGui");
            _maDatabaseNhan = dr.GetInt32("MaDatabaseNhan");
            _nganHangChuyen = dr.GetString("NganHangChuyen");
            _loaiCT = dr.GetInt32("LoaiCT");
            _ngayXacNhan = dr.GetDateTime("NgayXacNhan");
            _tyGia = dr.GetDecimal("TyGia");
            _thanhTien = _soTien * _tyGia;
        }

        private void FetchChildren(SafeDataReader dr)
        {
            _deNghiChuyenKhoan_DichVuList = DeNghiChuyenKhoan_DichVuList.GetDeNghiChuyenKhoan_DichVuList(_maPhieu);
            _deNghiChuyenKhoan_TKPhu = DeNghiChuyenKhoan_TKPhu.GetDeNghiChuyenKhoan_TKPhu(_maPhieu);
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
                cm.CommandText = "spd_Insert_DeNghiChuyenKhoan";

                AddInsertParameters(cm);

                cm.ExecuteNonQuery();

                _maPhieu = (long)cm.Parameters["@MaPhieu"].Value;
            }//using
        }

        private void AddInsertParameters(SqlCommand cm)
        {
            cm.Parameters.AddWithValue("@So", _so);
            cm.Parameters.AddWithValue("@Ngay", _ngay);
            cm.Parameters.AddWithValue("@MaBoPhan", _maBoPhan);
            cm.Parameters.AddWithValue("@MaNhanVien", _maNhanVien);
            cm.Parameters.AddWithValue("@LyDo", _lyDo);
            cm.Parameters.AddWithValue("@SoTien", _soTien);
            cm.Parameters.AddWithValue("@MaPhanHe", _maPhanHe);
            cm.Parameters.AddWithValue("@TinhTrang", _tinhTrang);
            cm.Parameters.AddWithValue("@HoanTat", _hoanTat);
            cm.Parameters.AddWithValue("@UserID", _userID);
            if (_soTaiKhoanNhan != null)
                cm.Parameters.AddWithValue("@SoTaiKhoanNhan", _soTaiKhoanNhan);
            else
                cm.Parameters.AddWithValue("@SoTaiKhoanNhan", DBNull.Value);
            if (_nganHangNhan != null)
                cm.Parameters.AddWithValue("@NganHangNhan", _nganHangNhan);
            else
                cm.Parameters.AddWithValue("@NganHangNhan", DBNull.Value);
            if (_tenNguoiNhan != null)
                cm.Parameters.AddWithValue("@TenNguoiNhan", _tenNguoiNhan);
            else
                cm.Parameters.AddWithValue("@TenNguoiNhan", DBNull.Value);
            if (_maTaiKhoanChuyen.HasValue)
                cm.Parameters.AddWithValue("@MaTaiKhoanChuyen", _maTaiKhoanChuyen.Value);
            else
                cm.Parameters.AddWithValue("@MaTaiKhoanChuyen", DBNull.Value);
            cm.Parameters.AddWithValue("@MaPhieu", _maPhieu);
            cm.Parameters["@MaPhieu"].Direction = ParameterDirection.Output;
            cm.Parameters.AddWithValue("@MaDatabaseGui", _maDatabaseGui);
            cm.Parameters.AddWithValue("@MaDatabaseNhan", _maDatabaseNhan);
            cm.Parameters.AddWithValue("@Loai", _loai);
            cm.Parameters.AddWithValue("@MaHopDong", _maHopDong);

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
                cm.CommandText = "spd_Update_DeNghiChuyenKhoan";

                AddUpdateParameters(cm);

                cm.ExecuteNonQuery();

            }//using
        }

        private void AddUpdateParameters(SqlCommand cm)
        {
            cm.Parameters.AddWithValue("@MaPhieu", _maPhieu);
            cm.Parameters.AddWithValue("@So", _so);
            cm.Parameters.AddWithValue("@Ngay", _ngay);
            cm.Parameters.AddWithValue("@MaBoPhan", _maBoPhan);
            cm.Parameters.AddWithValue("@MaNhanVien", _maNhanVien);
            cm.Parameters.AddWithValue("@LyDo", _lyDo);
            cm.Parameters.AddWithValue("@SoTien", _soTien);
            cm.Parameters.AddWithValue("@MaPhanHe", _maPhanHe);
            cm.Parameters.AddWithValue("@TinhTrang", _tinhTrang);
            cm.Parameters.AddWithValue("@HoanTat", _hoanTat);
            cm.Parameters.AddWithValue("@UserID", _userID);
            if (_soTaiKhoanNhan != null)
                cm.Parameters.AddWithValue("@SoTaiKhoanNhan", _soTaiKhoanNhan);
            else
                cm.Parameters.AddWithValue("@SoTaiKhoanNhan", DBNull.Value);
            if (_nganHangNhan != null)
                cm.Parameters.AddWithValue("@NganHangNhan", _nganHangNhan);
            else
                cm.Parameters.AddWithValue("@NganHangNhan", DBNull.Value);
            if (_tenNguoiNhan != null)
                cm.Parameters.AddWithValue("@TenNguoiNhan", _tenNguoiNhan);
            else
                cm.Parameters.AddWithValue("@TenNguoiNhan", DBNull.Value);
            if (_maTaiKhoanChuyen.HasValue)
                cm.Parameters.AddWithValue("@MaTaiKhoanChuyen", _maTaiKhoanChuyen.Value);
            else
                cm.Parameters.AddWithValue("@MaTaiKhoanChuyen", DBNull.Value);
            cm.Parameters.AddWithValue("@SoTienConLai", _soTienConLai);
            cm.Parameters.AddWithValue("@MaDatabaseGui", _maDatabaseGui);
            cm.Parameters.AddWithValue("@MaDatabaseNhan", _maDatabaseNhan);
            cm.Parameters.AddWithValue("@Loai", _loai);
            cm.Parameters.AddWithValue("@MaHopDong", _maHopDong);
        }

        private void UpdateChildren(SqlTransaction tr)
        {
            _deNghiChuyenKhoan_DichVuList.Update(tr, this);
            if (_deNghiChuyenKhoan_TKPhu.IsNew)
                _deNghiChuyenKhoan_TKPhu.Insert(tr, this);
            else if (_deNghiChuyenKhoan_TKPhu.IsDeleted)
                _deNghiChuyenKhoan_TKPhu.DeleteSelf(tr, this);
            else
                _deNghiChuyenKhoan_TKPhu.Update(tr, this);
        }
        #endregion //Data Access - Update

        #region Data Access - Delete
        internal void DeleteSelf(SqlTransaction tr)
        {
            if (!IsDirty) return;
            if (IsNew) return;

            _deNghiChuyenKhoan_DichVuList.DataPortal_Delete(tr);
            _deNghiChuyenKhoan_TKPhu.DeleteSelf(tr, this);
            ExecuteDelete(tr, new Criteria(_maPhieu));
            MarkNew();
        }
        #endregion //Data Access - Delete
        #endregion //Data Access

        public override bool IsDirty
        {
            get
            {
                return base.IsDirty || _chungtu.IsDirty || _deNghiChuyenKhoan_DichVuList.IsDirty || _deNghiChuyenKhoan_TKPhu.IsDirty;
            }
        }

        /// <summary>
        /// Tìm số phiếu mới = tổng số phiếu hiện có + 1
        /// </summary>
        /// <returns></returns>
        public string SoPhieuMoi(int Nam)
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
                cm.CommandText = "Select Max(Left(So, 4)) From tblDeNghiChuyenKhoan Where UserID = @UserID And YEAR(Ngay) = @Nam and Ngay >= '09/30/2012'"; //Chỉ lấy các chứng từ sau ngày 01/06/2012
                cm.Parameters.AddWithValue("@UserID", _userID);
                cm.Parameters.AddWithValue("@Nam", Nam);
                SoCTMax = Convert.ToString(cm.ExecuteScalar());
                cn.Close();
            }

            if (SoCTMax != string.Empty && SoCTMax != null)
            {
                iSoDeNghi = Convert.ToInt32(SoCTMax) + 1;
            }
            else
            {
                iSoDeNghi = 1;
            }

            if (iSoDeNghi.ToString().Length == 1)
                return "000" + iSoDeNghi.ToString() + "DNCK/" + strMaQLUser + "/" + strMaBoPhan + "/" + Nam.ToString();
            else if (iSoDeNghi.ToString().Length == 2)
                return "00" + iSoDeNghi.ToString() + "DNCK/" + strMaQLUser + "/" + strMaBoPhan + "/" + Nam.ToString();
            else if (iSoDeNghi.ToString().Length == 3)
                return "0" + iSoDeNghi.ToString() + "DNCK/" + strMaQLUser + "/" + strMaBoPhan + "/" + Nam.ToString();
            else
                return iSoDeNghi.ToString() + "DNCK/" + strMaQLUser + "/" + strMaBoPhan + "/" + Nam.ToString();
        }

    }
}
