using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{
    [Serializable()]
    public class ChungTuCustomize : Csla.BusinessBase<ChungTuCustomize>
    {
        #region Business Properties and Methods

        //declare members
        private long _id = 0;
        private string _MaLoaiChungTuQL = string.Empty;
        private string _loaiChungTu = string.Empty;
        private string _soChungTu = string.Empty;
        private SmartDate _ngayChungTu = new SmartDate(DateTime.MinValue);
        private SmartDate _ngayHachToan = new SmartDate(DateTime.MinValue);
        private string _soHoaDon = string.Empty;
        private SmartDate _ngayHoaDon = new SmartDate(DateTime.MinValue);
        private string _tKNo = string.Empty;
        private string _tKCo = string.Empty;
        private string _loaiTien = string.Empty;
        private decimal _soTien = 0;
        private decimal _quyDoiSoTien = 0;
        private decimal _SoTienButToan = 0;
        private string _maDoiTuongChung = string.Empty;
        private string _tenDTChung = string.Empty;
        private string _maDoiTuongNo = string.Empty;
        private string _maDoiTuongCo = string.Empty;
        private string _dienGiaiChung = string.Empty;
        private string _dienGiaiChiTiet = string.Empty;
        private string _tinhTrangGhiSo = string.Empty;
        private string _tenDTCo = string.Empty;
        private string _tenDTNo = string.Empty;
        private int _maCongTy = 0;
        private int _userImport = 0;
        private string _tenDoiTuongNgoai = string.Empty;
    //    NULL AS SoTaiKhoanDi,NULL AS NganHangDi
    //,NULL AS SoTaiKhoanDen, NULL AS NganHangDen
        private string _SoTaiKhoanDi=string.Empty;
        private string _NganHangDi = string.Empty;
        private string _SoTaiKhoanDen = string.Empty;
        private string _NganHangDen = string.Empty;

        private string _DonVi = string.Empty;
        private string _KhoanMuc = string.Empty;
        private string _SoHopDong = string.Empty;


        [System.ComponentModel.DataObjectField(true, true)]
        public long Id
        {
            get
            {
                CanReadProperty("Id", true);
                return _id;
            }
        }

        public string LoaiChungTu
        {
            get
            {
                CanReadProperty("LoaiChungTu", true);
                return _loaiChungTu;
            }
            set
            {
                CanWriteProperty("LoaiChungTu", true);
                if (value == null) value = string.Empty;
                if (!_loaiChungTu.Equals(value))
                {
                    _loaiChungTu = value;
                    PropertyHasChanged("LoaiChungTu");
                }
            }
        }

        public string MaLoaiChungTuQL
        {
            get
            {
                CanReadProperty("MaLoaiChungTuQL", true);
                return _MaLoaiChungTuQL;
            }
            set
            {
                CanWriteProperty("LoaiChungTu", true);
                if (value == null) value = string.Empty;
                if (!_MaLoaiChungTuQL.Equals(value))
                {
                    _MaLoaiChungTuQL = value;
                    PropertyHasChanged("LoaiChungTu");
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

        public DateTime? NgayChungTu
        {
            get
            {
                CanReadProperty("NgayChungTu", true);
                if (_ngayChungTu.Date == DateTime.MinValue)
                    return null;
                return _ngayChungTu.Date;
            }
            set
            {
                CanWriteProperty("NgayChungTu", true);
                if (!_ngayChungTu.Equals(value))
                {
                    if (value == null)
                        _ngayChungTu = new SmartDate(DateTime.MinValue);
                    else
                        _ngayChungTu = new SmartDate(value.Value.Date);

                    PropertyHasChanged();
                }
            }

        }


        public DateTime? NgayHachToan
        {
            get
            {
                CanReadProperty("NgayHachToan", true);
                if (_ngayHachToan.Date == DateTime.MinValue)
                    return null;
                return _ngayChungTu.Date;
            }
            set
            {
                CanWriteProperty("NgayHachToan", true);
                if (!_ngayHachToan.Equals(value))
                {
                    if (value == null)
                        _ngayHachToan = new SmartDate(DateTime.MinValue);
                    else
                        _ngayHachToan = new SmartDate(value.Value.Date);

                    PropertyHasChanged();
                }
            }

        }

        public string SoHoaDon
        {
            get
            {
                CanReadProperty("SoHoaDon", true);
                return _soHoaDon;
            }
            set
            {
                CanWriteProperty("SoHoaDon", true);
                if (value == null) value = string.Empty;
                if (!_soHoaDon.Equals(value))
                {
                    _soHoaDon = value;
                    PropertyHasChanged("SoHoaDon");
                }
            }
        }

        public DateTime? NgayHoaDon
        {
            get
            {
                CanReadProperty("NgayHoaDon", true);
                if (_ngayHoaDon.Date == DateTime.MinValue)
                    return null;
                return _ngayChungTu.Date;
            }
            set
            {
                CanWriteProperty("NgayHoaDon", true);
                if (!_ngayHoaDon.Equals(value))
                {
                    if (value == null)
                        _ngayHoaDon = new SmartDate(DateTime.MinValue);
                    else
                        _ngayHoaDon = new SmartDate(value.Value.Date);

                    PropertyHasChanged();
                }
            }

        }

        public string TKNo
        {
            get
            {
                CanReadProperty("TKNo", true);
                return _tKNo;
            }
            set
            {
                CanWriteProperty("TKNo", true);
                if (value == null) value = string.Empty;
                if (!_tKNo.Equals(value))
                {
                    _tKNo = value;
                    PropertyHasChanged("TKNo");
                }
            }
        }

        public string TKCo
        {
            get
            {
                CanReadProperty("TKCo", true);
                return _tKCo;
            }
            set
            {
                CanWriteProperty("TKCo", true);
                if (value == null) value = string.Empty;
                if (!_tKCo.Equals(value))
                {
                    _tKCo = value;
                    PropertyHasChanged("TKCo");
                }
            }
        }

        public string LoaiTien
        {
            get
            {
                CanReadProperty("LoaiTien", true);
                return _loaiTien;
            }
            set
            {
                CanWriteProperty("LoaiTien", true);
                if (value == null) value = string.Empty;
                if (!_loaiTien.Equals(value))
                {
                    _loaiTien = value;
                    PropertyHasChanged("LoaiTien");
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

        public decimal QuyDoiSoTien
        {
            get
            {
                CanReadProperty("QuyDoiSoTien", true);
                return _quyDoiSoTien;
            }
            set
            {
                CanWriteProperty("QuyDoiSoTien", true);
                if (!_quyDoiSoTien.Equals(value))
                {
                    _quyDoiSoTien = value;
                    PropertyHasChanged("QuyDoiSoTien");
                }
            }
        }

        public decimal SoTienButToan
        {
            get
            {
                CanReadProperty("SoTienButToan", true);
                return _SoTienButToan;
            }
            set
            {
                CanWriteProperty("SoTienButToan", true);
                if (!_SoTienButToan.Equals(value))
                {
                    _SoTienButToan = value;
                    PropertyHasChanged("SoTienButToan");
                }
            }
        }

        public string MaDoiTuongNo
        {
            get
            {
                CanReadProperty("MaDoiTuongNo", true);
                return _maDoiTuongNo;
            }
            set
            {
                CanWriteProperty("MaDoiTuongNo", true);
                if (value == null) value = string.Empty;
                if (!_maDoiTuongNo.Equals(value))
                {
                    _maDoiTuongNo = value;
                    PropertyHasChanged("MaDoiTuongNo");
                }
            }
        }

        public string MaDoiTuongCo
        {
            get
            {
                CanReadProperty("MaDoiTuongCo", true);
                return _maDoiTuongCo;
            }
            set
            {
                CanWriteProperty("MaDoiTuongCo", true);
                if (value == null) value = string.Empty;
                if (!_maDoiTuongCo.Equals(value))
                {
                    _maDoiTuongCo = value;
                    PropertyHasChanged("MaDoiTuongCo");
                }
            }
        }

        public string DienGiaiChung
        {
            get
            {
                CanReadProperty("DienGiaiChung", true);
                return _dienGiaiChung;
            }
            set
            {
                CanWriteProperty("DienGiaiChung", true);
                if (value == null) value = string.Empty;
                if (!_dienGiaiChung.Equals(value))
                {
                    _dienGiaiChung = value;
                    PropertyHasChanged("DienGiaiChung");
                }
            }
        }

        public string DienGiaiChiTiet
        {
            get
            {
                CanReadProperty("DienGiaiChiTiet", true);
                return _dienGiaiChiTiet;
            }
            set
            {
                CanWriteProperty("DienGiaiChiTiet", true);
                if (value == null) value = string.Empty;
                if (!_dienGiaiChiTiet.Equals(value))
                {
                    _dienGiaiChiTiet = value;
                    PropertyHasChanged("DienGiaiChiTiet");
                }
            }
        }

        public string TinhTrangGhiSo
        {
            get
            {
                CanReadProperty("TinhTrangGhiSo", true);
                return _tinhTrangGhiSo;
            }
            set
            {
                CanWriteProperty("TinhTrangGhiSo", true);
                if (value == null) value = string.Empty;
                if (!_tinhTrangGhiSo.Equals(value))
                {
                    _tinhTrangGhiSo = value;
                    PropertyHasChanged("TinhTrangGhiSo");
                }
            }
        }

        public string TenDTCo
        {
            get
            {
                CanReadProperty("TenDTCo", true);
                return _tenDTCo;
            }
            set
            {
                CanWriteProperty("TenDTCo", true);
                if (value == null) value = string.Empty;
                if (!_tenDTCo.Equals(value))
                {
                    _tenDTCo = value;
                    PropertyHasChanged("TenDTCo");
                }
            }
        }

        public string TenDTNo
        {
            get
            {
                CanReadProperty("TenDTNo", true);
                return _tenDTNo;
            }
            set
            {
                CanWriteProperty("TenDTNo", true);
                if (value == null) value = string.Empty;
                if (!_tenDTNo.Equals(value))
                {
                    _tenDTNo = value;
                    PropertyHasChanged("TenDTNo");
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

        public int UserImport
        {
            get
            {
                CanReadProperty("UserImport", true);
                return _userImport;
            }
            set
            {
                CanWriteProperty("UserImport", true);
                if (!_userImport.Equals(value))
                {
                    _userImport = value;
                    PropertyHasChanged("UserImport");
                }
            }
        }

        public string MaDoiTuongChung
        {
            get
            {
                CanReadProperty("MaDoiTuongChung", true);
                return _maDoiTuongChung;
            }
            set
            {
                CanWriteProperty("MaDoiTuongChung", true);
                if (value == null) value = string.Empty;
                if (!_maDoiTuongChung.Equals(value))
                {
                    _maDoiTuongChung = value;
                    PropertyHasChanged("MaDoiTuongChung");
                }
            }
        }

        public string TenDTChung
        {
            get
            {
                CanReadProperty("TenDTChung", true);
                return _tenDTChung;
            }
            set
            {
                CanWriteProperty("TenDTChung", true);
                if (value == null) value = string.Empty;
                if (!_tenDTChung.Equals(value))
                {
                    _tenDTChung = value;
                    PropertyHasChanged("TenDTChung");
                }
            }
        }

        public string TenDoiTuongNgoai
        {
            get
            {
                CanReadProperty("TenDoiTuongNgoai", true);
                return _tenDoiTuongNgoai;
            }
            set
            {
                CanWriteProperty("TenDoiTuongNgoai", true);
                if (value == null) value = string.Empty;
                if (!_tenDoiTuongNgoai.Equals(value))
                {
                    _tenDoiTuongNgoai = value;
                    PropertyHasChanged("TenDoiTuongNgoai");
                }
            }
        }

        public string SoTaiKhoanDi
        {
            get
            {
                CanReadProperty("SoTaiKhoanDi", true);
                return _SoTaiKhoanDi;
            }
            set
            {
                CanWriteProperty("SoTaiKhoanDi", true);
                if (value == null) value = string.Empty;
                if (!_SoTaiKhoanDi.Equals(value))
                {
                    _SoTaiKhoanDi = value;
                    PropertyHasChanged("SoTaiKhoanDi");
                }
            }
        }

        public string NganHangDi
        {
            get
            {
                CanReadProperty("NganHangDi", true);
                return _NganHangDi;
            }
            set
            {
                CanWriteProperty("NganHangDi", true);
                if (value == null) value = string.Empty;
                if (!_NganHangDi.Equals(value))
                {
                    _NganHangDi = value;
                    PropertyHasChanged("NganHangDi");
                }
            }
        }

        public string SoTaiKhoanDen
        {
            get
            {
                CanReadProperty("SoTaiKhoanDen", true);
                return _SoTaiKhoanDen;
            }
            set
            {
                CanWriteProperty("SoTaiKhoanDen", true);
                if (value == null) value = string.Empty;
                if (!_SoTaiKhoanDen.Equals(value))
                {
                    _SoTaiKhoanDen = value;
                    PropertyHasChanged("SoTaiKhoanDen");
                }
            }
        }

        public string NganHangDen
        {
            get
            {
                CanReadProperty("NganHangDen", true);
                return _NganHangDen;
            }
            set
            {
                CanWriteProperty("NganHangDen", true);
                if (value == null) value = string.Empty;
                if (!_NganHangDen.Equals(value))
                {
                    _NganHangDen = value;
                    PropertyHasChanged("NganHangDen");
                }
            }
        }

        public string DonVi
        {
            get
            {
                CanReadProperty("DonVi", true);
                return _DonVi;
            }
            set
            {
                CanWriteProperty("DonVi", true);
                if (value == null) value = string.Empty;
                if (!_DonVi.Equals(value))
                {
                    _DonVi = value;
                    PropertyHasChanged("DonVi");
                }
            }
        }

        public string KhoanMuc
        {
            get
            {
                CanReadProperty("KhoanMuc", true);
                return _KhoanMuc;
            }
            set
            {
                CanWriteProperty("KhoanMuc", true);
                if (value == null) value = string.Empty;
                if (!_KhoanMuc.Equals(value))
                {
                    _KhoanMuc = value;
                    PropertyHasChanged("KhoanMuc");
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
                if (value == null) value = string.Empty;
                if (!_SoHopDong.Equals(value))
                {
                    _SoHopDong = value;
                    PropertyHasChanged("SoHopDong");
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
            //TODO: Define authorization rules in ChungTuCustomize
            //AuthorizationRules.AllowRead("Id", "ChungTuCustomizeReadGroup");
            //AuthorizationRules.AllowRead("Stt", "ChungTuCustomizeReadGroup");
            //AuthorizationRules.AllowRead("LoaiChungTu", "ChungTuCustomizeReadGroup");
            //AuthorizationRules.AllowRead("SoChungTu", "ChungTuCustomizeReadGroup");
            //AuthorizationRules.AllowRead("NgayChungTu", "ChungTuCustomizeReadGroup");
            //AuthorizationRules.AllowRead("NgayChungTuString", "ChungTuCustomizeReadGroup");
            //AuthorizationRules.AllowRead("NgayHachToan", "ChungTuCustomizeReadGroup");
            //AuthorizationRules.AllowRead("NgayHachToanString", "ChungTuCustomizeReadGroup");
            //AuthorizationRules.AllowRead("SoHoaDon", "ChungTuCustomizeReadGroup");
            //AuthorizationRules.AllowRead("NgayHoaDon", "ChungTuCustomizeReadGroup");
            //AuthorizationRules.AllowRead("NgayHoaDonString", "ChungTuCustomizeReadGroup");
            //AuthorizationRules.AllowRead("TKNo", "ChungTuCustomizeReadGroup");
            //AuthorizationRules.AllowRead("TKCo", "ChungTuCustomizeReadGroup");
            //AuthorizationRules.AllowRead("LoaiTien", "ChungTuCustomizeReadGroup");
            //AuthorizationRules.AllowRead("SoTien", "ChungTuCustomizeReadGroup");
            //AuthorizationRules.AllowRead("QuyDoiSoTien", "ChungTuCustomizeReadGroup");
            //AuthorizationRules.AllowRead("MaVTHH", "ChungTuCustomizeReadGroup");
            //AuthorizationRules.AllowRead("TenVTHH", "ChungTuCustomizeReadGroup");
            //AuthorizationRules.AllowRead("SoLuong", "ChungTuCustomizeReadGroup");
            //AuthorizationRules.AllowRead("DonGia", "ChungTuCustomizeReadGroup");
            //AuthorizationRules.AllowRead("TyLeCK", "ChungTuCustomizeReadGroup");
            //AuthorizationRules.AllowRead("TienCK", "ChungTuCustomizeReadGroup");
            //AuthorizationRules.AllowRead("MaDoiTuongNo", "ChungTuCustomizeReadGroup");
            //AuthorizationRules.AllowRead("MaDoiTuongCo", "ChungTuCustomizeReadGroup");
            //AuthorizationRules.AllowRead("TaiKhoanNganHang", "ChungTuCustomizeReadGroup");
            //AuthorizationRules.AllowRead("KhoanMucChiPhi", "ChungTuCustomizeReadGroup");
            //AuthorizationRules.AllowRead("DTTapHopCP", "ChungTuCustomizeReadGroup");
            //AuthorizationRules.AllowRead("MaThongKe", "ChungTuCustomizeReadGroup");
            //AuthorizationRules.AllowRead("DienGiaiChung", "ChungTuCustomizeReadGroup");
            //AuthorizationRules.AllowRead("DienGiaiChiTiet", "ChungTuCustomizeReadGroup");
            //AuthorizationRules.AllowRead("TinhTrangGhiSo", "ChungTuCustomizeReadGroup");
            //AuthorizationRules.AllowRead("TenDTCo", "ChungTuCustomizeReadGroup");
            //AuthorizationRules.AllowRead("TenDTNo", "ChungTuCustomizeReadGroup");
            //AuthorizationRules.AllowRead("MaCongTy", "ChungTuCustomizeReadGroup");
            //AuthorizationRules.AllowRead("UserImport", "ChungTuCustomizeReadGroup");
            //AuthorizationRules.AllowRead("FileImportName", "ChungTuCustomizeReadGroup");
            //AuthorizationRules.AllowRead("NgayImport", "ChungTuCustomizeReadGroup");
            //AuthorizationRules.AllowRead("NgayImportString", "ChungTuCustomizeReadGroup");
            //AuthorizationRules.AllowRead("TaiKhoanNganHangDen", "ChungTuCustomizeReadGroup");
            //AuthorizationRules.AllowRead("MaDoiTuongChung", "ChungTuCustomizeReadGroup");
            //AuthorizationRules.AllowRead("TenDTChung", "ChungTuCustomizeReadGroup");
            //AuthorizationRules.AllowRead("MaKho", "ChungTuCustomizeReadGroup");

            //AuthorizationRules.AllowWrite("Stt", "ChungTuCustomizeWriteGroup");
            //AuthorizationRules.AllowWrite("LoaiChungTu", "ChungTuCustomizeWriteGroup");
            //AuthorizationRules.AllowWrite("SoChungTu", "ChungTuCustomizeWriteGroup");
            //AuthorizationRules.AllowWrite("NgayChungTuString", "ChungTuCustomizeWriteGroup");
            //AuthorizationRules.AllowWrite("NgayHachToanString", "ChungTuCustomizeWriteGroup");
            //AuthorizationRules.AllowWrite("SoHoaDon", "ChungTuCustomizeWriteGroup");
            //AuthorizationRules.AllowWrite("NgayHoaDonString", "ChungTuCustomizeWriteGroup");
            //AuthorizationRules.AllowWrite("TKNo", "ChungTuCustomizeWriteGroup");
            //AuthorizationRules.AllowWrite("TKCo", "ChungTuCustomizeWriteGroup");
            //AuthorizationRules.AllowWrite("LoaiTien", "ChungTuCustomizeWriteGroup");
            //AuthorizationRules.AllowWrite("SoTien", "ChungTuCustomizeWriteGroup");
            //AuthorizationRules.AllowWrite("QuyDoiSoTien", "ChungTuCustomizeWriteGroup");
            //AuthorizationRules.AllowWrite("MaVTHH", "ChungTuCustomizeWriteGroup");
            //AuthorizationRules.AllowWrite("TenVTHH", "ChungTuCustomizeWriteGroup");
            //AuthorizationRules.AllowWrite("SoLuong", "ChungTuCustomizeWriteGroup");
            //AuthorizationRules.AllowWrite("DonGia", "ChungTuCustomizeWriteGroup");
            //AuthorizationRules.AllowWrite("TyLeCK", "ChungTuCustomizeWriteGroup");
            //AuthorizationRules.AllowWrite("TienCK", "ChungTuCustomizeWriteGroup");
            //AuthorizationRules.AllowWrite("MaDoiTuongNo", "ChungTuCustomizeWriteGroup");
            //AuthorizationRules.AllowWrite("MaDoiTuongCo", "ChungTuCustomizeWriteGroup");
            //AuthorizationRules.AllowWrite("TaiKhoanNganHang", "ChungTuCustomizeWriteGroup");
            //AuthorizationRules.AllowWrite("KhoanMucChiPhi", "ChungTuCustomizeWriteGroup");
            //AuthorizationRules.AllowWrite("DTTapHopCP", "ChungTuCustomizeWriteGroup");
            //AuthorizationRules.AllowWrite("MaThongKe", "ChungTuCustomizeWriteGroup");
            //AuthorizationRules.AllowWrite("DienGiaiChung", "ChungTuCustomizeWriteGroup");
            //AuthorizationRules.AllowWrite("DienGiaiChiTiet", "ChungTuCustomizeWriteGroup");
            //AuthorizationRules.AllowWrite("TinhTrangGhiSo", "ChungTuCustomizeWriteGroup");
            //AuthorizationRules.AllowWrite("TenDTCo", "ChungTuCustomizeWriteGroup");
            //AuthorizationRules.AllowWrite("TenDTNo", "ChungTuCustomizeWriteGroup");
            //AuthorizationRules.AllowWrite("MaCongTy", "ChungTuCustomizeWriteGroup");
            //AuthorizationRules.AllowWrite("UserImport", "ChungTuCustomizeWriteGroup");
            //AuthorizationRules.AllowWrite("FileImportName", "ChungTuCustomizeWriteGroup");
            //AuthorizationRules.AllowWrite("NgayImportString", "ChungTuCustomizeWriteGroup");
            //AuthorizationRules.AllowWrite("TaiKhoanNganHangDen", "ChungTuCustomizeWriteGroup");
            //AuthorizationRules.AllowWrite("MaDoiTuongChung", "ChungTuCustomizeWriteGroup");
            //AuthorizationRules.AllowWrite("TenDTChung", "ChungTuCustomizeWriteGroup");
            //AuthorizationRules.AllowWrite("MaKho", "ChungTuCustomizeWriteGroup");
        }


        public static bool CanGetObject()
        {
            //TODO: Define CanGetObject permission in ChungTuCustomize
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("ChungTuCustomizeViewGroup"))
            //	return true;
            //return false;
        }

        public static bool CanAddObject()
        {
            //TODO: Define CanAddObject permission in ChungTuCustomize
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("ChungTuCustomizeAddGroup"))
            //	return true;
            //return false;
        }

        public static bool CanEditObject()
        {
            //TODO: Define CanEditObject permission in ChungTuCustomize
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("ChungTuCustomizeEditGroup"))
            //	return true;
            //return false;
        }

        public static bool CanDeleteObject()
        {
            //TODO: Define CanDeleteObject permission in ChungTuCustomize
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("ChungTuCustomizeDeleteGroup"))
            //	return true;
            //return false;
        }
        #endregion //Authorization Rules

        #region Factory Methods
        private ChungTuCustomize()
        { /* require use of factory method */ }

        public static ChungTuCustomize NewChungTuCustomize()
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a ChungTuCustomize");
            return DataPortal.Create<ChungTuCustomize>();
        }

        public static ChungTuCustomize GetChungTuCustomize(long id)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a ChungTuCustomize");
            return DataPortal.Fetch<ChungTuCustomize>(new Criteria(id));
        }

        public static void DeleteChungTuCustomize(long id)
        {
            if (!CanDeleteObject())
                throw new System.Security.SecurityException("User not authorized to remove a ChungTuCustomize");
            DataPortal.Delete(new Criteria(id));
        }

        public override ChungTuCustomize Save()
        {
            if (IsDeleted && !CanDeleteObject())
                throw new System.Security.SecurityException("User not authorized to remove a ChungTuCustomize");
            else if (IsNew && !CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a ChungTuCustomize");
            else if (!CanEditObject())
                throw new System.Security.SecurityException("User not authorized to update a ChungTuCustomize");

            return base.Save();
        }

        #endregion //Factory Methods

        #region Child Factory Methods
        internal static ChungTuCustomize NewChungTuCustomizeChild()
        {
            ChungTuCustomize child = new ChungTuCustomize();
            child.ValidationRules.CheckRules();
            child.MarkAsChild();
            return child;
        }

        internal static ChungTuCustomize GetChungTuCustomize(SafeDataReader dr)
        {
            ChungTuCustomize child = new ChungTuCustomize();
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
                cm.CommandText = "spd_SelecttblChungTuCustomizeByMaChungTu";

                cm.Parameters.AddWithValue("@IDChungTu", criteria.Id);

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
                cm.CommandText = "DeleteChungTuCustomize";

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
            _MaLoaiChungTuQL = dr.GetString("MaLoaiChungTuQL");
            _loaiChungTu = dr.GetString("LoaiChungTu");
            _soChungTu = dr.GetString("SoChungTu");
            _ngayChungTu = dr.GetSmartDate("NgayChungTu", _ngayChungTu.EmptyIsMin);
            _ngayHachToan = dr.GetSmartDate("NgayHachToan", _ngayHachToan.EmptyIsMin);
            _soHoaDon = dr.GetString("SoHoaDon");
            _ngayHoaDon = dr.GetSmartDate("NgayHoaDon", _ngayHoaDon.EmptyIsMin);
            _tKNo = dr.GetString("TKNo");
            _tKCo = dr.GetString("TKCo");
            _loaiTien = dr.GetString("LoaiTien");
            _soTien = dr.GetDecimal("SoTien");
            _quyDoiSoTien = dr.GetDecimal("QuyDoiSoTien");
            _SoTienButToan = dr.GetDecimal("SoTienButToan");
            _maDoiTuongNo = dr.GetString("MaDoiTuongNo");
            _maDoiTuongCo = dr.GetString("MaDoiTuongCo");
            _dienGiaiChung = dr.GetString("DienGiaiChung");
            _dienGiaiChiTiet = dr.GetString("DienGiaiChiTiet");
            _tinhTrangGhiSo = dr.GetString("TinhTrangGhiSo");
            _tenDTCo = dr.GetString("TenDTCo");
            _tenDTNo = dr.GetString("TenDTNo");
            _maCongTy = dr.GetInt32("MaCongTy");
            _userImport = dr.GetInt32("UserImport");
            _maDoiTuongChung = dr.GetString("MaDoiTuongChung");
            _tenDTChung = dr.GetString("TenDTChung");
            _tenDoiTuongNgoai = dr.GetString("TenDoiTuongNgoai");

            _SoTaiKhoanDi = dr.GetString("SoTaiKhoanDi");
            _NganHangDi = dr.GetString("NganHangDi");
            _SoTaiKhoanDen = dr.GetString("SoTaiKhoanDen");
            _NganHangDen = dr.GetString("NganHangDen");

            _DonVi = dr.GetString("DonVi");
            _KhoanMuc = dr.GetString("KhoanMuc");
            _SoHopDong = dr.GetString("SoHopDong");
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
                cm.CommandText = "AddChungTuCustomize";

                AddInsertParameters(cm);

                cm.ExecuteNonQuery();

                _id = (long)cm.Parameters["@NewID"].Value;
            }//using
        }

        private void AddInsertParameters(SqlCommand cm)
        {
            if (_MaLoaiChungTuQL.Length > 0)
                cm.Parameters.AddWithValue("@MaLoaiChungTuQL", _MaLoaiChungTuQL);
            else
                cm.Parameters.AddWithValue("@MaLoaiChungTuQL", DBNull.Value);
            if (_loaiChungTu.Length > 0)
                cm.Parameters.AddWithValue("@LoaiChungTu", _loaiChungTu);
            else
                cm.Parameters.AddWithValue("@LoaiChungTu", DBNull.Value);
            if (_soChungTu.Length > 0)
                cm.Parameters.AddWithValue("@SoChungTu", _soChungTu);
            else
                cm.Parameters.AddWithValue("@SoChungTu", DBNull.Value);
            cm.Parameters.AddWithValue("@NgayChungTu", _ngayChungTu.DBValue);
            cm.Parameters.AddWithValue("@NgayHachToan", _ngayHachToan.DBValue);
            if (_soHoaDon.Length > 0)
                cm.Parameters.AddWithValue("@SoHoaDon", _soHoaDon);
            else
                cm.Parameters.AddWithValue("@SoHoaDon", DBNull.Value);
            cm.Parameters.AddWithValue("@NgayHoaDon", _ngayHoaDon.DBValue);
            if (_tKNo.Length > 0)
                cm.Parameters.AddWithValue("@TKNo", _tKNo);
            else
                cm.Parameters.AddWithValue("@TKNo", DBNull.Value);
            if (_tKCo.Length > 0)
                cm.Parameters.AddWithValue("@TKCo", _tKCo);
            else
                cm.Parameters.AddWithValue("@TKCo", DBNull.Value);
            if (_loaiTien.Length > 0)
                cm.Parameters.AddWithValue("@LoaiTien", _loaiTien);
            else
                cm.Parameters.AddWithValue("@LoaiTien", DBNull.Value);
            if (_soTien != 0)
                cm.Parameters.AddWithValue("@SoTien", _soTien);
            else
                cm.Parameters.AddWithValue("@SoTien", DBNull.Value);
            if (_quyDoiSoTien != 0)
                cm.Parameters.AddWithValue("@QuyDoiSoTien", _quyDoiSoTien);
            else
                cm.Parameters.AddWithValue("@QuyDoiSoTien", DBNull.Value);
            if (_SoTienButToan != 0)
                cm.Parameters.AddWithValue("@SoTienButToan", _SoTienButToan);
            else
                cm.Parameters.AddWithValue("@SoTienButToan", DBNull.Value);
           
            if (_maDoiTuongNo.Length > 0)
                cm.Parameters.AddWithValue("@MaDoiTuongNo", _maDoiTuongNo);
            else
                cm.Parameters.AddWithValue("@MaDoiTuongNo", DBNull.Value);
            if (_maDoiTuongCo.Length > 0)
                cm.Parameters.AddWithValue("@MaDoiTuongCo", _maDoiTuongCo);
            else
                cm.Parameters.AddWithValue("@MaDoiTuongCo", DBNull.Value);
            
            if (_dienGiaiChung.Length > 0)
                cm.Parameters.AddWithValue("@DienGiaiChung", _dienGiaiChung);
            else
                cm.Parameters.AddWithValue("@DienGiaiChung", DBNull.Value);
            if (_dienGiaiChiTiet.Length > 0)
                cm.Parameters.AddWithValue("@DienGiaiChiTiet", _dienGiaiChiTiet);
            else
                cm.Parameters.AddWithValue("@DienGiaiChiTiet", DBNull.Value);
            if (_tinhTrangGhiSo.Length > 0)
                cm.Parameters.AddWithValue("@TinhTrangGhiSo", _tinhTrangGhiSo);
            else
                cm.Parameters.AddWithValue("@TinhTrangGhiSo", DBNull.Value);
            if (_tenDTCo.Length > 0)
                cm.Parameters.AddWithValue("@TenDTCo", _tenDTCo);
            else
                cm.Parameters.AddWithValue("@TenDTCo", DBNull.Value);
            if (_tenDTNo.Length > 0)
                cm.Parameters.AddWithValue("@TenDTNo", _tenDTNo);
            else
                cm.Parameters.AddWithValue("@TenDTNo", DBNull.Value);
            if (_maCongTy != 0)
                cm.Parameters.AddWithValue("@MaCongTy", _maCongTy);
            else
                cm.Parameters.AddWithValue("@MaCongTy", DBNull.Value);
            if (_userImport != 0)
                cm.Parameters.AddWithValue("@UserImport", _userImport);
            else
                cm.Parameters.AddWithValue("@UserImport", DBNull.Value);
           
            if (_maDoiTuongChung.Length > 0)
                cm.Parameters.AddWithValue("@MaDoiTuongChung", _maDoiTuongChung);
            else
                cm.Parameters.AddWithValue("@MaDoiTuongChung", DBNull.Value);
            if (_tenDTChung.Length > 0)
                cm.Parameters.AddWithValue("@TenDTChung", _tenDTChung);
            else
                cm.Parameters.AddWithValue("@TenDTChung", DBNull.Value);

            if (_tenDoiTuongNgoai.Length > 0)
                cm.Parameters.AddWithValue("@TenDoiTuongNgoai", _tenDoiTuongNgoai);
            else
                cm.Parameters.AddWithValue("@TenDoiTuongNgoai", DBNull.Value);
            cm.Parameters.AddWithValue("@NID", _id);
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
                cm.CommandText = "UpdateChungTuCustomize";

                AddUpdateParameters(cm);

                cm.ExecuteNonQuery();

            }//using
        }

        private void AddUpdateParameters(SqlCommand cm)
        {
            cm.Parameters.AddWithValue("@ID", _id);
            if (_MaLoaiChungTuQL.Length > 0)
                cm.Parameters.AddWithValue("@MaLoaiChungTuQL", _MaLoaiChungTuQL);
            else
                cm.Parameters.AddWithValue("@MaLoaiChungTuQL", DBNull.Value);
            if (_loaiChungTu.Length > 0)
                cm.Parameters.AddWithValue("@LoaiChungTu", _loaiChungTu);
            else
                cm.Parameters.AddWithValue("@LoaiChungTu", DBNull.Value);
            if (_soChungTu.Length > 0)
                cm.Parameters.AddWithValue("@SoChungTu", _soChungTu);
            else
                cm.Parameters.AddWithValue("@SoChungTu", DBNull.Value);
            cm.Parameters.AddWithValue("@NgayChungTu", _ngayChungTu.DBValue);
            cm.Parameters.AddWithValue("@NgayHachToan", _ngayHachToan.DBValue);
            if (_soHoaDon.Length > 0)
                cm.Parameters.AddWithValue("@SoHoaDon", _soHoaDon);
            else
                cm.Parameters.AddWithValue("@SoHoaDon", DBNull.Value);
            cm.Parameters.AddWithValue("@NgayHoaDon", _ngayHoaDon.DBValue);
            if (_tKNo.Length > 0)
                cm.Parameters.AddWithValue("@TKNo", _tKNo);
            else
                cm.Parameters.AddWithValue("@TKNo", DBNull.Value);
            if (_tKCo.Length > 0)
                cm.Parameters.AddWithValue("@TKCo", _tKCo);
            else
                cm.Parameters.AddWithValue("@TKCo", DBNull.Value);
            if (_loaiTien.Length > 0)
                cm.Parameters.AddWithValue("@LoaiTien", _loaiTien);
            else
                cm.Parameters.AddWithValue("@LoaiTien", DBNull.Value);
            if (_soTien != 0)
                cm.Parameters.AddWithValue("@SoTien", _soTien);
            else
                cm.Parameters.AddWithValue("@SoTien", DBNull.Value);
            if (_quyDoiSoTien != 0)
                cm.Parameters.AddWithValue("@QuyDoiSoTien", _quyDoiSoTien);
            else
                cm.Parameters.AddWithValue("@QuyDoiSoTien", DBNull.Value);
            if (_SoTienButToan != 0)
                cm.Parameters.AddWithValue("@SoTienButToan", _SoTienButToan);
            else
                cm.Parameters.AddWithValue("@SoTienButToan", DBNull.Value);
            if (_maDoiTuongNo.Length > 0)
                cm.Parameters.AddWithValue("@MaDoiTuongNo", _maDoiTuongNo);
            else
                cm.Parameters.AddWithValue("@MaDoiTuongNo", DBNull.Value);
            if (_maDoiTuongCo.Length > 0)
                cm.Parameters.AddWithValue("@MaDoiTuongCo", _maDoiTuongCo);
            else
                cm.Parameters.AddWithValue("@MaDoiTuongCo", DBNull.Value);
            
            if (_dienGiaiChung.Length > 0)
                cm.Parameters.AddWithValue("@DienGiaiChung", _dienGiaiChung);
            else
                cm.Parameters.AddWithValue("@DienGiaiChung", DBNull.Value);
            if (_dienGiaiChiTiet.Length > 0)
                cm.Parameters.AddWithValue("@DienGiaiChiTiet", _dienGiaiChiTiet);
            else
                cm.Parameters.AddWithValue("@DienGiaiChiTiet", DBNull.Value);
            if (_tinhTrangGhiSo.Length > 0)
                cm.Parameters.AddWithValue("@TinhTrangGhiSo", _tinhTrangGhiSo);
            else
                cm.Parameters.AddWithValue("@TinhTrangGhiSo", DBNull.Value);
            if (_tenDTCo.Length > 0)
                cm.Parameters.AddWithValue("@TenDTCo", _tenDTCo);
            else
                cm.Parameters.AddWithValue("@TenDTCo", DBNull.Value);
            if (_tenDTNo.Length > 0)
                cm.Parameters.AddWithValue("@TenDTNo", _tenDTNo);
            else
                cm.Parameters.AddWithValue("@TenDTNo", DBNull.Value);
            if (_maCongTy != 0)
                cm.Parameters.AddWithValue("@MaCongTy", _maCongTy);
            else
                cm.Parameters.AddWithValue("@MaCongTy", DBNull.Value);
            if (_userImport != 0)
                cm.Parameters.AddWithValue("@UserImport", _userImport);
            else
                cm.Parameters.AddWithValue("@UserImport", DBNull.Value);
            
            if (_maDoiTuongChung.Length > 0)
                cm.Parameters.AddWithValue("@MaDoiTuongChung", _maDoiTuongChung);
            else
                cm.Parameters.AddWithValue("@MaDoiTuongChung", DBNull.Value);
            if (_tenDTChung.Length > 0)
                cm.Parameters.AddWithValue("@TenDTChung", _tenDTChung);
            else
                cm.Parameters.AddWithValue("@TenDTChung", DBNull.Value);
            if (_tenDoiTuongNgoai.Length > 0)
                cm.Parameters.AddWithValue("@TenDoiTuongNgoai", _tenDoiTuongNgoai);
            else
                cm.Parameters.AddWithValue("@TenDoiTuongNgoai", DBNull.Value);
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
