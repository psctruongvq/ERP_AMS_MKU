using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{
    [Serializable()]
    public class ChungTuImportFromExcel : Csla.BusinessBase<ChungTuImportFromExcel>
    {
        #region Business Properties and Methods

        //declare members
        private long _id = 0;
        private double _stt = 0;
        private string _loaiChungTu = string.Empty;
        private string _soChungTu = string.Empty;
        private DateTime _ngayChungTu = new DateTime();
        private DateTime _ngayHachToan = new DateTime();
        private string _soHoaDon = string.Empty;
        private DateTime _ngayHoaDon = new DateTime();
        private string _tKNo = string.Empty;
        private string _tKCo = string.Empty;
        private string _loaiTien = string.Empty;
        private decimal _soTien = 0;
        private decimal _quyDoiSoTien = 0;
        private string _maVTHH = string.Empty;
        private string _tenVTHH = string.Empty;
        private decimal _soLuong = 0;
        private decimal _donGia = 0;
        private decimal _tyLeCK = 0;
        private decimal _tienCK = 0;
        private string _maDoiTuongNo = string.Empty;
        private string _maDoiTuongCo = string.Empty;
        private string _taiKhoanNganHang = string.Empty;
        private string _khoanMucChiPhi = string.Empty;
        private string _dTTapHopCP = string.Empty;
        private string _maThongKe = string.Empty;
        private string _dienGiaiChung = string.Empty;
        private string _dienGiaiChiTiet = string.Empty;
        private string _tinhTrangGhiSo = string.Empty;
        private string _tenDTCo = string.Empty;
        private string _tenDTNo = string.Empty;
        private int _maCongTy = ERP_Library.Security.CurrentUser.Info.MaCongTy;
        private int _userImport = ERP_Library.Security.CurrentUser.Info.UserID;
        private string _fileImportName = string.Empty;
        private DateTime _ngayImport = DateTime.Today.Date;
        private string _taiKhoanNganHangDen = string.Empty;
        private string _MaDoiTuongChung = string.Empty;
        private string _TenDTChung = string.Empty;
        private string _MaKho = string.Empty;
        private string _MaDonVi = string.Empty;
        private string _SoHopDong = string.Empty;
        private string _soSeri = string.Empty;
        private decimal _thueSuat = 0;
        private decimal _tienThue = 0;
        private string _soPhieuNhapXuatThamChieu = string.Empty;
        private string _tenNhanVienNhapXuat = string.Empty;
        //MaLoaiCT, MaTKNo, MaTKCo, DoiTuongNoBigInt, DoiTuongCoBigInt, MaTaiKhoanNganHangDi, MaTaiKhoanNganHangDen

        [System.ComponentModel.DataObjectField(true, true)]
        public long Id
        {
            get
            {
                CanReadProperty("Id", true);
                return _id;
            }
        }

        public double STT
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


        public DateTime NgayChungTu
        {
            get
            {
                CanReadProperty("NgayChungTu", true);
                return _ngayChungTu.Date;
            }
            set
            {
                CanWriteProperty("NgayChungTu", true);
                if (!_ngayChungTu.Equals(value))
                {
                    _ngayChungTu = value;
                    PropertyHasChanged("NgayChungTu");
                }
            }
        }


        public DateTime? NgayHachToan
        {
            get
            {
                CanReadProperty("NgayHachToan", true);
                if (_ngayHachToan == DateTime.MinValue)
                    return null;
                return _ngayHachToan;
            }
            set
            {
                CanWriteProperty("NgayHachToan", true);
                if (!_ngayHachToan.Equals(value))
                {
                    if (value == null)
                        _ngayHachToan = DateTime.MinValue;
                    else
                        _ngayHachToan = value.Value;

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
                if (_ngayHoaDon == DateTime.MinValue)
                    return null;
                return _ngayHoaDon;
            }
            set
            {
                CanWriteProperty("NgayHoaDon", true);
                if (!_ngayHoaDon.Equals(value))
                {
                    if (value == null)
                        _ngayHoaDon = DateTime.MinValue;
                    else
                        _ngayHoaDon = value.Value;

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

        public string MaVTHH
        {
            get
            {
                CanReadProperty("MaVTHH", true);
                return _maVTHH;
            }
            set
            {
                CanWriteProperty("MaVTHH", true);
                if (value == null) value = string.Empty;
                if (!_maVTHH.Equals(value))
                {
                    _maVTHH = value;
                    PropertyHasChanged("MaVTHH");
                }
            }
        }

        public string TenVTHH
        {
            get
            {
                CanReadProperty("TenVTHH", true);
                return _tenVTHH;
            }
            set
            {
                CanWriteProperty("TenVTHH", true);
                if (value == null) value = string.Empty;
                if (!_tenVTHH.Equals(value))
                {
                    _tenVTHH = value;
                    PropertyHasChanged("TenVTHH");
                }
            }
        }

        public decimal SoLuong
        {
            get
            {
                CanReadProperty("SoLuong", true);
                return _soLuong;
            }
            set
            {
                CanWriteProperty("SoLuong", true);
                if (!_soLuong.Equals(value))
                {
                    _soLuong = value;
                    PropertyHasChanged("SoLuong");
                }
            }
        }

        public decimal DonGia
        {
            get
            {
                CanReadProperty("DonGia", true);
                return _donGia;
            }
            set
            {
                CanWriteProperty("DonGia", true);
                if (!_donGia.Equals(value))
                {
                    _donGia = value;
                    PropertyHasChanged("DonGia");
                }
            }
        }

        public decimal TyLeCK
        {
            get
            {
                CanReadProperty("TyLeCK", true);
                return _tyLeCK;
            }
            set
            {
                CanWriteProperty("TyLeCK", true);
                if (!_tyLeCK.Equals(value))
                {
                    _tyLeCK = value;
                    PropertyHasChanged("TyLeCK");
                }
            }
        }

        public decimal TienCK
        {
            get
            {
                CanReadProperty("TienCK", true);
                return _tienCK;
            }
            set
            {
                CanWriteProperty("TienCK", true);
                if (!_tienCK.Equals(value))
                {
                    _tienCK = value;
                    PropertyHasChanged("TienCK");
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

        public string TaiKhoanNganHang
        {
            get
            {
                CanReadProperty("TaiKhoanNganHang", true);
                return _taiKhoanNganHang;
            }
            set
            {
                CanWriteProperty("TaiKhoanNganHang", true);
                if (value == null) value = string.Empty;
                if (!_taiKhoanNganHang.Equals(value))
                {
                    _taiKhoanNganHang = value;
                    PropertyHasChanged("TaiKhoanNganHang");
                }
            }
        }

        public string TaiKhoanNganHangDen
        {
            get
            {
                CanReadProperty("TaiKhoanNganHangDen", true);
                return _taiKhoanNganHangDen;
            }
            set
            {
                CanWriteProperty("TaiKhoanNganHangDen", true);
                if (value == null) value = string.Empty;
                if (!_taiKhoanNganHangDen.Equals(value))
                {
                    _taiKhoanNganHangDen = value;
                    PropertyHasChanged("TaiKhoanNganHangDen");
                }
            }
        }

        public string KhoanMucChiPhi
        {
            get
            {
                CanReadProperty("KhoanMucChiPhi", true);
                return _khoanMucChiPhi;
            }
            set
            {
                CanWriteProperty("KhoanMucChiPhi", true);
                if (value == null) value = string.Empty;
                if (!_khoanMucChiPhi.Equals(value))
                {
                    _khoanMucChiPhi = value;
                    PropertyHasChanged("KhoanMucChiPhi");
                }
            }
        }

        public string DTTapHopCP
        {
            get
            {
                CanReadProperty("DTTapHopCP", true);
                return _dTTapHopCP;
            }
            set
            {
                CanWriteProperty("DTTapHopCP", true);
                if (value == null) value = string.Empty;
                if (!_dTTapHopCP.Equals(value))
                {
                    _dTTapHopCP = value;
                    PropertyHasChanged("DTTapHopCP");
                }
            }
        }

        public string MaThongKe
        {
            get
            {
                CanReadProperty("MaThongKe", true);
                return _maThongKe;
            }
            set
            {
                CanWriteProperty("MaThongKe", true);
                if (value == null) value = string.Empty;
                if (!_maThongKe.Equals(value))
                {
                    _maThongKe = value;
                    PropertyHasChanged("MaThongKe");
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

        public string FileImportName
        {
            get
            {
                CanReadProperty("FileImportName", true);
                return _fileImportName;
            }
            set
            {
                CanWriteProperty("FileImportName", true);
                if (value == null) value = string.Empty;
                if (!_fileImportName.Equals(value))
                {
                    _fileImportName = value;
                    PropertyHasChanged("FileImportName");
                }
            }
        }


        public DateTime NgayImport
        {
            get
            {
                CanReadProperty("NgayImport", true);
                return _ngayImport.Date;
            }
            set
            {
                CanWriteProperty("NgayImport", true);
                if (!_ngayImport.Equals(value))
                {
                    _ngayImport = value;
                    PropertyHasChanged("NgayImport");
                }
            }
        }

        public string MaDoiTuongChung
        {
            get
            {
                CanReadProperty("MaDoiTuongChung", true);
                return _MaDoiTuongChung;
            }
            set
            {
                CanWriteProperty("MaDoiTuongChung", true);
                if (value == null) value = string.Empty;
                if (!_MaDoiTuongChung.Equals(value))
                {
                    _MaDoiTuongChung = value;
                    PropertyHasChanged("MaDoiTuongChung");
                }
            }
        }

        public string TenDTChung
        {
            get
            {
                CanReadProperty("TenDTChung", true);
                return _TenDTChung;
            }
            set
            {
                CanWriteProperty("TenDTChung", true);
                if (value == null) value = string.Empty;
                if (!_TenDTChung.Equals(value))
                {
                    _TenDTChung = value;
                    PropertyHasChanged("TenDTChung");
                }
            }
        }

        public string MaKho
        {
            get
            {
                CanReadProperty("MaKho", true);
                return _MaKho;
            }
            set
            {
                CanWriteProperty("MaKho", true);
                if (value == null) value = string.Empty;
                if (!_MaKho.Equals(value))
                {
                    _MaKho = value;
                    PropertyHasChanged("MaKho");
                }
            }
        }

        public string MaDonVi
        {
            get
            {
                CanReadProperty("MaDonVi", true);
                return _MaDonVi;
            }
            set
            {
                CanWriteProperty("MaDonVi", true);
                if (value == null) value = string.Empty;
                if (!_MaDonVi.Equals(value))
                {
                    _MaDonVi = value;
                    PropertyHasChanged("MaDonVi");
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

        public string SoSeri
        {
            get
            {
                CanReadProperty("SoSeri", true);
                return _soSeri;
            }
            set
            {
                CanWriteProperty("SoSeri", true);
                if (value == null) value = string.Empty;
                if (!_soSeri.Equals(value))
                {
                    _soSeri = value;
                    PropertyHasChanged("SoSeri");
                }
            }
        }

        public decimal ThueSuat
        {
            get
            {
                CanReadProperty("ThueSuat", true);
                return _thueSuat;
            }
            set
            {
                CanWriteProperty("ThueSuat", true);
                if (!_thueSuat.Equals(value))
                {
                    _thueSuat = value;
                    PropertyHasChanged("ThueSuat");
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

        public string SoPhieuNhapXuatThamChieu
        {
            get
            {
                CanReadProperty("SoPhieuNhapXuatThamChieu", true);
                return _soPhieuNhapXuatThamChieu;
            }
            set
            {
                CanWriteProperty("SoPhieuNhapXuatThamChieu", true);
                if (value == null) value = string.Empty;
                if (!_soPhieuNhapXuatThamChieu.Equals(value))
                {
                    _soPhieuNhapXuatThamChieu = value;
                    PropertyHasChanged("SoPhieuNhapXuatThamChieu");
                }
            }
        }

        public string TenNhanVienNhapXuat
        {
            get
            {
                CanReadProperty("TenNhanVienNhapXuat", true);
                return _tenNhanVienNhapXuat;
            }
            set
            {
                CanWriteProperty("TenNhanVienNhapXuat", true);
                if (value == null) value = string.Empty;
                if (!_tenNhanVienNhapXuat.Equals(value))
                {
                    _tenNhanVienNhapXuat = value;
                    PropertyHasChanged("TenNhanVienNhapXuat");
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
            //TODO: Define authorization rules in ChungTuImportFromExcel
            //AuthorizationRules.AllowRead("Id", "ChungTuImportFromExcelReadGroup");
            //AuthorizationRules.AllowRead("Stt", "ChungTuImportFromExcelReadGroup");
            //AuthorizationRules.AllowRead("LoaiChungTu", "ChungTuImportFromExcelReadGroup");
            //AuthorizationRules.AllowRead("SoChungTu", "ChungTuImportFromExcelReadGroup");
            //AuthorizationRules.AllowRead("NgayChungTu", "ChungTuImportFromExcelReadGroup");
            //AuthorizationRules.AllowRead("NgayChungTuString", "ChungTuImportFromExcelReadGroup");
            //AuthorizationRules.AllowRead("NgayHachToan", "ChungTuImportFromExcelReadGroup");
            //AuthorizationRules.AllowRead("NgayHachToanString", "ChungTuImportFromExcelReadGroup");
            //AuthorizationRules.AllowRead("SoHoaDon", "ChungTuImportFromExcelReadGroup");
            //AuthorizationRules.AllowRead("NgayHoaDon", "ChungTuImportFromExcelReadGroup");
            //AuthorizationRules.AllowRead("NgayHoaDonString", "ChungTuImportFromExcelReadGroup");
            //AuthorizationRules.AllowRead("TKNo", "ChungTuImportFromExcelReadGroup");
            //AuthorizationRules.AllowRead("TKCo", "ChungTuImportFromExcelReadGroup");
            //AuthorizationRules.AllowRead("LoaiTien", "ChungTuImportFromExcelReadGroup");
            //AuthorizationRules.AllowRead("SoTien", "ChungTuImportFromExcelReadGroup");
            //AuthorizationRules.AllowRead("QuyDoiSoTien", "ChungTuImportFromExcelReadGroup");
            //AuthorizationRules.AllowRead("MaVTHH", "ChungTuImportFromExcelReadGroup");
            //AuthorizationRules.AllowRead("TenVTHH", "ChungTuImportFromExcelReadGroup");
            //AuthorizationRules.AllowRead("SoLuong", "ChungTuImportFromExcelReadGroup");
            //AuthorizationRules.AllowRead("DonGia", "ChungTuImportFromExcelReadGroup");
            //AuthorizationRules.AllowRead("TyLeCK", "ChungTuImportFromExcelReadGroup");
            //AuthorizationRules.AllowRead("TienCK", "ChungTuImportFromExcelReadGroup");
            //AuthorizationRules.AllowRead("MaDoiTuongNo", "ChungTuImportFromExcelReadGroup");
            //AuthorizationRules.AllowRead("MaDoiTuongCo", "ChungTuImportFromExcelReadGroup");
            //AuthorizationRules.AllowRead("TaiKhoanNganHang", "ChungTuImportFromExcelReadGroup");
            //AuthorizationRules.AllowRead("KhoanMucChiPhi", "ChungTuImportFromExcelReadGroup");
            //AuthorizationRules.AllowRead("DTTapHopCP", "ChungTuImportFromExcelReadGroup");
            //AuthorizationRules.AllowRead("MaThongKe", "ChungTuImportFromExcelReadGroup");
            //AuthorizationRules.AllowRead("DienGiaiChung", "ChungTuImportFromExcelReadGroup");
            //AuthorizationRules.AllowRead("DienGiaiChiTiet", "ChungTuImportFromExcelReadGroup");
            //AuthorizationRules.AllowRead("TinhTrangGhiSo", "ChungTuImportFromExcelReadGroup");
            //AuthorizationRules.AllowRead("TenDTCo", "ChungTuImportFromExcelReadGroup");
            //AuthorizationRules.AllowRead("TenDTNo", "ChungTuImportFromExcelReadGroup");
            //AuthorizationRules.AllowRead("MaCongTy", "ChungTuImportFromExcelReadGroup");
            //AuthorizationRules.AllowRead("UserImport", "ChungTuImportFromExcelReadGroup");
            //AuthorizationRules.AllowRead("FileImportName", "ChungTuImportFromExcelReadGroup");
            //AuthorizationRules.AllowRead("NgayImport", "ChungTuImportFromExcelReadGroup");
            //AuthorizationRules.AllowRead("NgayImportString", "ChungTuImportFromExcelReadGroup");

            //AuthorizationRules.AllowWrite("Stt", "ChungTuImportFromExcelWriteGroup");
            //AuthorizationRules.AllowWrite("LoaiChungTu", "ChungTuImportFromExcelWriteGroup");
            //AuthorizationRules.AllowWrite("SoChungTu", "ChungTuImportFromExcelWriteGroup");
            //AuthorizationRules.AllowWrite("NgayChungTuString", "ChungTuImportFromExcelWriteGroup");
            //AuthorizationRules.AllowWrite("NgayHachToanString", "ChungTuImportFromExcelWriteGroup");
            //AuthorizationRules.AllowWrite("SoHoaDon", "ChungTuImportFromExcelWriteGroup");
            //AuthorizationRules.AllowWrite("NgayHoaDonString", "ChungTuImportFromExcelWriteGroup");
            //AuthorizationRules.AllowWrite("TKNo", "ChungTuImportFromExcelWriteGroup");
            //AuthorizationRules.AllowWrite("TKCo", "ChungTuImportFromExcelWriteGroup");
            //AuthorizationRules.AllowWrite("LoaiTien", "ChungTuImportFromExcelWriteGroup");
            //AuthorizationRules.AllowWrite("SoTien", "ChungTuImportFromExcelWriteGroup");
            //AuthorizationRules.AllowWrite("QuyDoiSoTien", "ChungTuImportFromExcelWriteGroup");
            //AuthorizationRules.AllowWrite("MaVTHH", "ChungTuImportFromExcelWriteGroup");
            //AuthorizationRules.AllowWrite("TenVTHH", "ChungTuImportFromExcelWriteGroup");
            //AuthorizationRules.AllowWrite("SoLuong", "ChungTuImportFromExcelWriteGroup");
            //AuthorizationRules.AllowWrite("DonGia", "ChungTuImportFromExcelWriteGroup");
            //AuthorizationRules.AllowWrite("TyLeCK", "ChungTuImportFromExcelWriteGroup");
            //AuthorizationRules.AllowWrite("TienCK", "ChungTuImportFromExcelWriteGroup");
            //AuthorizationRules.AllowWrite("MaDoiTuongNo", "ChungTuImportFromExcelWriteGroup");
            //AuthorizationRules.AllowWrite("MaDoiTuongCo", "ChungTuImportFromExcelWriteGroup");
            //AuthorizationRules.AllowWrite("TaiKhoanNganHang", "ChungTuImportFromExcelWriteGroup");
            //AuthorizationRules.AllowWrite("KhoanMucChiPhi", "ChungTuImportFromExcelWriteGroup");
            //AuthorizationRules.AllowWrite("DTTapHopCP", "ChungTuImportFromExcelWriteGroup");
            //AuthorizationRules.AllowWrite("MaThongKe", "ChungTuImportFromExcelWriteGroup");
            //AuthorizationRules.AllowWrite("DienGiaiChung", "ChungTuImportFromExcelWriteGroup");
            //AuthorizationRules.AllowWrite("DienGiaiChiTiet", "ChungTuImportFromExcelWriteGroup");
            //AuthorizationRules.AllowWrite("TinhTrangGhiSo", "ChungTuImportFromExcelWriteGroup");
            //AuthorizationRules.AllowWrite("TenDTCo", "ChungTuImportFromExcelWriteGroup");
            //AuthorizationRules.AllowWrite("TenDTNo", "ChungTuImportFromExcelWriteGroup");
            //AuthorizationRules.AllowWrite("MaCongTy", "ChungTuImportFromExcelWriteGroup");
            //AuthorizationRules.AllowWrite("UserImport", "ChungTuImportFromExcelWriteGroup");
            //AuthorizationRules.AllowWrite("FileImportName", "ChungTuImportFromExcelWriteGroup");
            //AuthorizationRules.AllowWrite("NgayImportString", "ChungTuImportFromExcelWriteGroup");
        }


        public static bool CanGetObject()
        {
            //TODO: Define CanGetObject permission in ChungTuImportFromExcel
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("ChungTuImportFromExcelViewGroup"))
            //	return true;
            //return false;
        }

        public static bool CanAddObject()
        {
            //TODO: Define CanAddObject permission in ChungTuImportFromExcel
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("ChungTuImportFromExcelAddGroup"))
            //	return true;
            //return false;
        }

        public static bool CanEditObject()
        {
            //TODO: Define CanEditObject permission in ChungTuImportFromExcel
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("ChungTuImportFromExcelEditGroup"))
            //	return true;
            //return false;
        }

        public static bool CanDeleteObject()
        {
            //TODO: Define CanDeleteObject permission in ChungTuImportFromExcel
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("ChungTuImportFromExcelDeleteGroup"))
            //	return true;
            //return false;
        }
        #endregion //Authorization Rules

        #region Factory Methods
        private ChungTuImportFromExcel()
        { /* require use of factory method */ }

        public static ChungTuImportFromExcel NewChungTuImportFromExcel()
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a ChungTuImportFromExcel");
            return DataPortal.Create<ChungTuImportFromExcel>();
        }

        public static ChungTuImportFromExcel GetChungTuImportFromExcel(long id)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a ChungTuImportFromExcel");
            return DataPortal.Fetch<ChungTuImportFromExcel>(new Criteria(id));
        }

        public static void DeleteChungTuImportFromExcel(long id)
        {
            if (!CanDeleteObject())
                throw new System.Security.SecurityException("User not authorized to remove a ChungTuImportFromExcel");
            DataPortal.Delete(new Criteria(id));
        }

        public override ChungTuImportFromExcel Save()
        {
            if (IsDeleted && !CanDeleteObject())
                throw new System.Security.SecurityException("User not authorized to remove a ChungTuImportFromExcel");
            else if (IsNew && !CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a ChungTuImportFromExcel");
            else if (!CanEditObject())
                throw new System.Security.SecurityException("User not authorized to update a ChungTuImportFromExcel");

            return base.Save();
        }

        #endregion //Factory Methods

        #region Child Factory Methods
        internal static ChungTuImportFromExcel NewChungTuImportFromExcelChild()
        {
            ChungTuImportFromExcel child = new ChungTuImportFromExcel();
            child.ValidationRules.CheckRules();
            child.MarkAsChild();
            return child;
        }

        internal static ChungTuImportFromExcel GetChungTuImportFromExcel(SafeDataReader dr)
        {
            ChungTuImportFromExcel child = new ChungTuImportFromExcel();
            child.MarkAsChild();
            child.Fetch(dr);
            return child;
        }

        public static bool KiemTraChungTuDaDuocImportVaoData(string soChungTu)
        {
            bool rs = false;
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "Spd_KiemTraSoChungTuDaDuocImportVaoData";
                    cm.Parameters.AddWithValue("@SoChungTu", soChungTu);
                    cm.Parameters.AddWithValue("@MaCongTy", ERP_Library.Security.CurrentUser.Info.MaCongTy);
                    SqlParameter prmGiaTriTraVe = new SqlParameter("@GiaTriTraVe", SqlDbType.Bit, 50);
                    prmGiaTriTraVe.Direction = ParameterDirection.Output;
                    cm.Parameters.Add(prmGiaTriTraVe);
                    cm.ExecuteNonQuery();
                    rs = (bool)prmGiaTriTraVe.Value;
                }
            }//us
            return rs;

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
                cm.CommandText = "spd_SelecttblChungTuImportFromExcel";

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
            SqlTransaction tr;
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                tr = cn.BeginTransaction();
                ExecuteInsert(tr);

                //update child object(s)
                UpdateChildren(tr);
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
                if (base.IsDirty)
                {
                    ExecuteUpdate(tr);
                }

                //update child object(s)
                UpdateChildren(tr);
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
                cm.CommandText = "spd_DeletetblChungTuImportFromExcel";

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
            _stt = dr.GetDouble("STT");
            _loaiChungTu = dr.GetString("LoaiChungTu");
            _soChungTu = dr.GetString("SoChungTu");
            _ngayChungTu = dr.GetDateTime("NgayChungTu");
            _ngayHachToan = dr.GetDateTime("NgayHachToan");
            _soHoaDon = dr.GetString("SoHoaDon");
            _ngayHoaDon = dr.GetDateTime("NgayHoaDon");
            _tKNo = dr.GetString("TKNo");
            _tKCo = dr.GetString("TKCo");
            _loaiTien = dr.GetString("LoaiTien");
            _soTien = dr.GetDecimal("SoTien");
            _quyDoiSoTien = dr.GetDecimal("QuyDoiSoTien");
            _maVTHH = dr.GetString("MaVTHH");
            _tenVTHH = dr.GetString("TenVTHH");
            _soLuong = dr.GetDecimal("SoLuong");
            _donGia = dr.GetDecimal("DonGia");
            _tyLeCK = dr.GetDecimal("TyLeCK");
            _tienCK = dr.GetDecimal("TienCK");
            _maDoiTuongNo = dr.GetString("MaDoiTuongNo");
            _maDoiTuongCo = dr.GetString("MaDoiTuongCo");
            _taiKhoanNganHang = dr.GetString("TaiKhoanNganHang");
            _taiKhoanNganHangDen = dr.GetString("TaiKhoanNganHangDen");
            _khoanMucChiPhi = dr.GetString("KhoanMucChiPhi");
            _dTTapHopCP = dr.GetString("DTTapHopCP");
            _maThongKe = dr.GetString("MaThongKe");
            _dienGiaiChung = dr.GetString("DienGiaiChung");
            _dienGiaiChiTiet = dr.GetString("DienGiaiChiTiet");
            _tinhTrangGhiSo = dr.GetString("TinhTrangGhiSo");
            _tenDTCo = dr.GetString("TenDTCo");
            _tenDTNo = dr.GetString("TenDTNo");
            _maCongTy = dr.GetInt32("MaCongTy");
            _userImport = dr.GetInt32("UserImport");
            _fileImportName = dr.GetString("FileImportName");
            _ngayImport = dr.GetDateTime("NgayImport");

            _MaDoiTuongChung = dr.GetString("MaDoiTuongChung");
            _TenDTChung = dr.GetString("TenDTChung");
            _MaKho = dr.GetString("MaKho");
            
            _MaDonVi = dr.GetString("MaDonVi");
            _SoHopDong = dr.GetString("SoHopDong");
            _soSeri = dr.GetString("SoSeri");
            _thueSuat = dr.GetDecimal("ThueSuat");
            _tienThue = dr.GetDecimal("TienThue");
            _soPhieuNhapXuatThamChieu = dr.GetString("SoPhieuNhapXuatThamChieu");
            _tenNhanVienNhapXuat = dr.GetString("TenNhanVienNhapXuat");
        }

        private void FetchChildren(SafeDataReader dr)
        {
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
                cm.CommandText = "spd_InserttblChungTuImportFromExcel";

                AddInsertParameters(cm);

                cm.ExecuteNonQuery();

                _id = (long)cm.Parameters["@ID"].Value;
            }//using
        }

        private void AddInsertParameters(SqlCommand cm)
        {
            if (_stt != 0)
                cm.Parameters.AddWithValue("@STT", _stt);
            else
                cm.Parameters.AddWithValue("@STT", DBNull.Value);
            if (_loaiChungTu.Length > 0)
                cm.Parameters.AddWithValue("@LoaiChungTu", _loaiChungTu);
            else
                cm.Parameters.AddWithValue("@LoaiChungTu", DBNull.Value);
            if (_soChungTu.Length > 0)
                cm.Parameters.AddWithValue("@SoChungTu", _soChungTu);
            else
                cm.Parameters.AddWithValue("@SoChungTu", DBNull.Value);
            if (_ngayChungTu != DateTime.MinValue)
                cm.Parameters.AddWithValue("@NgayChungTu", _ngayChungTu);
            else
                cm.Parameters.AddWithValue("@NgayChungTu", DBNull.Value);
            if (_ngayHachToan != DateTime.MinValue)
                cm.Parameters.AddWithValue("@NgayHachToan", _ngayHachToan);
            else
                cm.Parameters.AddWithValue("@NgayHachToan", DBNull.Value);
            if (_soHoaDon.Length > 0)
                cm.Parameters.AddWithValue("@SoHoaDon", _soHoaDon);
            else
                cm.Parameters.AddWithValue("@SoHoaDon", DBNull.Value);
            if (_ngayHoaDon != DateTime.MinValue)
                cm.Parameters.AddWithValue("@NgayHoaDon", _ngayHoaDon);
            else
                cm.Parameters.AddWithValue("@NgayHoaDon", DBNull.Value);
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
            if (_maVTHH.Length > 0)
                cm.Parameters.AddWithValue("@MaVTHH", _maVTHH);
            else
                cm.Parameters.AddWithValue("@MaVTHH", DBNull.Value);
            if (_tenVTHH.Length > 0)
                cm.Parameters.AddWithValue("@TenVTHH", _tenVTHH);
            else
                cm.Parameters.AddWithValue("@TenVTHH", DBNull.Value);
            if (_soLuong != 0)
                cm.Parameters.AddWithValue("@SoLuong", _soLuong);
            else
                cm.Parameters.AddWithValue("@SoLuong", DBNull.Value);
            if (_donGia != 0)
                cm.Parameters.AddWithValue("@DonGia", _donGia);
            else
                cm.Parameters.AddWithValue("@DonGia", DBNull.Value);
            if (_tyLeCK != 0)
                cm.Parameters.AddWithValue("@TyLeCK", _tyLeCK);
            else
                cm.Parameters.AddWithValue("@TyLeCK", DBNull.Value);
            if (_tienCK != 0)
                cm.Parameters.AddWithValue("@TienCK", _tienCK);
            else
                cm.Parameters.AddWithValue("@TienCK", DBNull.Value);
            if (_maDoiTuongNo.Length > 0)
                cm.Parameters.AddWithValue("@MaDoiTuongNo", _maDoiTuongNo);
            else
                cm.Parameters.AddWithValue("@MaDoiTuongNo", DBNull.Value);
            if (_maDoiTuongCo.Length > 0)
                cm.Parameters.AddWithValue("@MaDoiTuongCo", _maDoiTuongCo);
            else
                cm.Parameters.AddWithValue("@MaDoiTuongCo", DBNull.Value);
            if (_taiKhoanNganHang.Length > 0)
                cm.Parameters.AddWithValue("@TaiKhoanNganHang", _taiKhoanNganHang);
            else
                cm.Parameters.AddWithValue("@TaiKhoanNganHang", DBNull.Value);
            if (_taiKhoanNganHangDen.Length > 0)
                cm.Parameters.AddWithValue("@TaiKhoanNganHangDen", _taiKhoanNganHangDen);
            else
                cm.Parameters.AddWithValue("@TaiKhoanNganHangDen", DBNull.Value);
            if (_khoanMucChiPhi.Length > 0)
                cm.Parameters.AddWithValue("@KhoanMucChiPhi", _khoanMucChiPhi);
            else
                cm.Parameters.AddWithValue("@KhoanMucChiPhi", DBNull.Value);
            if (_dTTapHopCP.Length > 0)
                cm.Parameters.AddWithValue("@DTTapHopCP", _dTTapHopCP);
            else
                cm.Parameters.AddWithValue("@DTTapHopCP", DBNull.Value);
            if (_maThongKe.Length > 0)
                cm.Parameters.AddWithValue("@MaThongKe", _maThongKe);
            else
                cm.Parameters.AddWithValue("@MaThongKe", DBNull.Value);
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
            if (_fileImportName.Length > 0)
                cm.Parameters.AddWithValue("@FileImportName", _fileImportName);
            else
                cm.Parameters.AddWithValue("@FileImportName", DBNull.Value);
            cm.Parameters.AddWithValue("@NgayImport", _ngayImport);

            if (_MaDoiTuongChung.Length > 0)
                cm.Parameters.AddWithValue("@MaDoiTuongChung", _MaDoiTuongChung);
            else
                cm.Parameters.AddWithValue("@MaDoiTuongChung", DBNull.Value);
            if (_TenDTChung.Length > 0)
                cm.Parameters.AddWithValue("@TenDTChung", _TenDTChung);
            else
                cm.Parameters.AddWithValue("@TenDTChung", DBNull.Value);
            if (_MaKho.Length > 0)
                cm.Parameters.AddWithValue("@MaKho", _MaKho);
            else
                cm.Parameters.AddWithValue("@MaKho", DBNull.Value);

            if (_MaDonVi.Length > 0)
                cm.Parameters.AddWithValue("@MaDonVi", _MaDonVi);
            else
                cm.Parameters.AddWithValue("@MaDonVi", DBNull.Value);

            if (_SoHopDong.Length > 0)
                cm.Parameters.AddWithValue("@SoHopDong", _SoHopDong);
            else
                cm.Parameters.AddWithValue("@SoHopDong", DBNull.Value);

            if (_soSeri.Length > 0)
                cm.Parameters.AddWithValue("@SoSeri", _soSeri);
            else
                cm.Parameters.AddWithValue("@SoSeri", DBNull.Value);

            if (_thueSuat != 0)
                cm.Parameters.AddWithValue("@ThueSuat", _thueSuat);
            else
                cm.Parameters.AddWithValue("@ThueSuat", DBNull.Value);

            if (_tienThue != 0)
                cm.Parameters.AddWithValue("@TienThue", _tienThue);
            else
                cm.Parameters.AddWithValue("@TienThue", DBNull.Value);

            if (_soPhieuNhapXuatThamChieu.Length > 0)
                cm.Parameters.AddWithValue("@SoPhieuNhapXuatThamChieu", _soPhieuNhapXuatThamChieu);
            else
                cm.Parameters.AddWithValue("@SoPhieuNhapXuatThamChieu", DBNull.Value);

            if (_tenNhanVienNhapXuat.Length > 0)
                cm.Parameters.AddWithValue("@TenNhanVienNhapXuat", _tenNhanVienNhapXuat);
            else
                cm.Parameters.AddWithValue("@TenNhanVienNhapXuat", DBNull.Value);

            cm.Parameters.AddWithValue("@ID", _id);
            cm.Parameters["@ID"].Direction = ParameterDirection.Output;
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
                cm.CommandText = "spd_UpdatetblChungTuImportFromExcel";

                AddUpdateParameters(cm);

                cm.ExecuteNonQuery();

            }//using
        }

        private void AddUpdateParameters(SqlCommand cm)
        {
            cm.Parameters.AddWithValue("@ID", _id);
            if (_stt != 0)
                cm.Parameters.AddWithValue("@STT", _stt);
            else
                cm.Parameters.AddWithValue("@STT", DBNull.Value);
            if (_loaiChungTu.Length > 0)
                cm.Parameters.AddWithValue("@LoaiChungTu", _loaiChungTu);
            else
                cm.Parameters.AddWithValue("@LoaiChungTu", DBNull.Value);
            if (_soChungTu.Length > 0)
                cm.Parameters.AddWithValue("@SoChungTu", _soChungTu);
            else
                cm.Parameters.AddWithValue("@SoChungTu", DBNull.Value);
            cm.Parameters.AddWithValue("@NgayChungTu", _ngayChungTu);
            cm.Parameters.AddWithValue("@NgayHachToan", _ngayHachToan);
            if (_soHoaDon.Length > 0)
                cm.Parameters.AddWithValue("@SoHoaDon", _soHoaDon);
            else
                cm.Parameters.AddWithValue("@SoHoaDon", DBNull.Value);
            cm.Parameters.AddWithValue("@NgayHoaDon", _ngayHoaDon);
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
            if (_maVTHH.Length > 0)
                cm.Parameters.AddWithValue("@MaVTHH", _maVTHH);
            else
                cm.Parameters.AddWithValue("@MaVTHH", DBNull.Value);
            if (_tenVTHH.Length > 0)
                cm.Parameters.AddWithValue("@TenVTHH", _tenVTHH);
            else
                cm.Parameters.AddWithValue("@TenVTHH", DBNull.Value);
            if (_soLuong != 0)
                cm.Parameters.AddWithValue("@SoLuong", _soLuong);
            else
                cm.Parameters.AddWithValue("@SoLuong", DBNull.Value);
            if (_donGia != 0)
                cm.Parameters.AddWithValue("@DonGia", _donGia);
            else
                cm.Parameters.AddWithValue("@DonGia", DBNull.Value);
            if (_tyLeCK != 0)
                cm.Parameters.AddWithValue("@TyLeCK", _tyLeCK);
            else
                cm.Parameters.AddWithValue("@TyLeCK", DBNull.Value);
            if (_tienCK != 0)
                cm.Parameters.AddWithValue("@TienCK", _tienCK);
            else
                cm.Parameters.AddWithValue("@TienCK", DBNull.Value);
            if (_maDoiTuongNo.Length > 0)
                cm.Parameters.AddWithValue("@MaDoiTuongNo", _maDoiTuongNo);
            else
                cm.Parameters.AddWithValue("@MaDoiTuongNo", DBNull.Value);
            if (_maDoiTuongCo.Length > 0)
                cm.Parameters.AddWithValue("@MaDoiTuongCo", _maDoiTuongCo);
            else
                cm.Parameters.AddWithValue("@MaDoiTuongCo", DBNull.Value);
            if (_taiKhoanNganHang.Length > 0)
                cm.Parameters.AddWithValue("@TaiKhoanNganHang", _taiKhoanNganHang);
            else
                cm.Parameters.AddWithValue("@TaiKhoanNganHang", DBNull.Value);
            if (_taiKhoanNganHangDen.Length > 0)
                cm.Parameters.AddWithValue("@TaiKhoanNganHangDen", _taiKhoanNganHangDen);
            else
                cm.Parameters.AddWithValue("@TaiKhoanNganHangDen", DBNull.Value);
            if (_khoanMucChiPhi.Length > 0)
                cm.Parameters.AddWithValue("@KhoanMucChiPhi", _khoanMucChiPhi);
            else
                cm.Parameters.AddWithValue("@KhoanMucChiPhi", DBNull.Value);
            if (_dTTapHopCP.Length > 0)
                cm.Parameters.AddWithValue("@DTTapHopCP", _dTTapHopCP);
            else
                cm.Parameters.AddWithValue("@DTTapHopCP", DBNull.Value);
            if (_maThongKe.Length > 0)
                cm.Parameters.AddWithValue("@MaThongKe", _maThongKe);
            else
                cm.Parameters.AddWithValue("@MaThongKe", DBNull.Value);
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
            if (_fileImportName.Length > 0)
                cm.Parameters.AddWithValue("@FileImportName", _fileImportName);
            else
                cm.Parameters.AddWithValue("@FileImportName", DBNull.Value);
            cm.Parameters.AddWithValue("@NgayImport", _ngayImport);

            if (_MaDoiTuongChung.Length > 0)
                cm.Parameters.AddWithValue("@MaDoiTuongChung", _MaDoiTuongChung);
            else
                cm.Parameters.AddWithValue("@MaDoiTuongChung", DBNull.Value);
            if (_TenDTChung.Length > 0)
                cm.Parameters.AddWithValue("@TenDTChung", _TenDTChung);
            else
                cm.Parameters.AddWithValue("@TenDTChung", DBNull.Value);

            if (_MaKho.Length > 0)
                cm.Parameters.AddWithValue("@MaKho", _MaKho);
            else
                cm.Parameters.AddWithValue("@MaKho", DBNull.Value);

            if (_MaDonVi.Length > 0)
                cm.Parameters.AddWithValue("@MaDonVi", _MaDonVi);
            else
                cm.Parameters.AddWithValue("@MaDonVi", DBNull.Value);

            if (_SoHopDong.Length > 0)
                cm.Parameters.AddWithValue("@SoHopDong", _SoHopDong);
            else
                cm.Parameters.AddWithValue("@SoHopDong", DBNull.Value);
        }

        private void UpdateChildren(SqlTransaction tr)
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
