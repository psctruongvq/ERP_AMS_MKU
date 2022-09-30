
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{ 
	[Serializable()] 
	public class QuaTrinhLuanChuyenBoNhiem : Csla.BusinessBase<QuaTrinhLuanChuyenBoNhiem>
	{
		#region Business Properties and Methods

        private int _mactQuatrinhluanchuyen = 0;
        private long _maNhanVien = 0;
        private string _tenNhanVien = string.Empty;
        private int _quyetDinh = 0;
        private int _maLoaiQuyetDinh = 0;
        private string _soQuyetDinh = string.Empty;
        private string _nguoiCapQuyetDinh = string.Empty;
        private string _capQuyetDinh = string.Empty;
        private SmartDate _ngayKy = new SmartDate(DateTime.Today.Date);
        private SmartDate _ngayHieuLuc = new SmartDate(DateTime.Today.Date);
        private int _maBoPhanCu = 0;
        private string _tenBoPhanCu = string.Empty;
        private int _maBoPhanMoi = 0;
        private string _tenBoPhanMoi = string.Empty;
        private int _maChucVuCu = 0;
        private string _tenChucVuCu = string.Empty;
        private int _maChucVuMoi = 0;
        private string _tenChucVuMoi = string.Empty;
        private string _ghiChu = string.Empty;
        private int _maNguoiLap = 0;
        private SmartDate _ngayLap = new SmartDate(DateTime.Today.Date);
        private DateTime _ngayHuongMucMoi = DateTime.Today.Date;
        private decimal _heSoNoiBoCu = 0;
        private decimal _heSoPhuCapCu = 0;
        private decimal _heSoBuCu = 0;
        private decimal _heSoBoSungCu = 0;
        private decimal _heSoDocHaiCu = 0;
        private decimal _heSoNoiBoMoi = 0;
        private decimal _heSoPhuCapMoi = 0;
        private decimal _heSoBuMoi = 0;
        private decimal _heSoBoSungMoi = 0;
        private decimal _heSoDocHaiMoi = 0;
        private int _maNgachLuongCu = 0;
        private int _maBacLuongCu = 0;
        private decimal _heSoLuongCu = 0;
        private decimal _hSVKCu = 0;
        private int _maNgachLuongMoi = 0;
        private int _maBacLuongMoi = 0;
        private decimal _heSoLuongMoi = 0;
        private decimal _hSVKMoi = 0;
        private int _maNgachBHCu = 0;
        private int _maBacBHCu = 0;
        private decimal _heSoBHCu = 0;
        private decimal _hSVKBHCu = 0;
        private int _maNgachBHMoi = 0;
        private int _maBacBHMoi = 0;
        private decimal _heSoBHMoi = 0;
        private decimal _hSVKBHMoi = 0;
        private int _maNhomNgachMoi = 0;
        private bool _laQDMoi= true;

      
        private int _maNhomNgachBHMoi = 0;

       
        [System.ComponentModel.DataObjectField(true, true)]

        public bool LaQDMoi
        {
            get
            {
                CanReadProperty("LaQDMoi", true);
                return _laQDMoi;
            }
            set
            {
                if (!_laQDMoi.Equals(value))
                {
                    _laQDMoi = value;
                    PropertyHasChanged("LaQDMoi");
                }
            }
        }
        public int MactQuatrinhluanchuyen
        {
            get
            {
                CanReadProperty("MactQuatrinhluanchuyen", true);
                return _mactQuatrinhluanchuyen;
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
                if (!_maNhanVien.Equals(value))
                {
                    _maNhanVien = value;
                    PropertyHasChanged("MaNhanVien");
                }
            }
        }
        public int MaNhomNgachMoi
        {
            get { return _maNhomNgachMoi; }
            set { _maNhomNgachMoi = value;
            PropertyHasChanged("MaNhomNgachMoi");
            }
        }
        public int MaNhomNgachBHMoi
        {
            get { return _maNhomNgachBHMoi; }
            set { _maNhomNgachBHMoi = value;
            PropertyHasChanged("MaNhomNgachBHMoi");
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
                if (value == null) value = string.Empty;
                if (!_tenNhanVien.Equals(value))
                {
                    _tenNhanVien = value;
                    PropertyHasChanged("TenNhanVien");
                }
            }
        }

        public int QuyetDinh
        {
            get
            {
                CanReadProperty("QuyetDinh", true);
                return _quyetDinh;
            }
            set
            {
                if (!_quyetDinh.Equals(value))
                {
                    _quyetDinh = value;
                    PropertyHasChanged("QuyetDinh");
                }
            }
        }

        public int MaLoaiQuyetDinh
        {
            get
            {
                CanReadProperty("MaLoaiQuyetDinh", true);
                return _maLoaiQuyetDinh;
            }
            set
            {
                if (!_maLoaiQuyetDinh.Equals(value))
                {
                    _maLoaiQuyetDinh = value;
                    PropertyHasChanged("MaLoaiQuyetDinh");
                }
            }
        }

        public string SoQuyetDinh
        {
            get
            {
                CanReadProperty("SoQuyetDinh", true);
                return _soQuyetDinh;
            }
            set
            {
                if (value == null) value = string.Empty;
                if (!_soQuyetDinh.Equals(value))
                {
                    _soQuyetDinh = value;
                    PropertyHasChanged("SoQuyetDinh");
                }
            }
        }

        public string NguoiCapQuyetDinh
        {
            get
            {
                CanReadProperty("NguoiCapQuyetDinh", true);
                return _nguoiCapQuyetDinh;
            }
            set
            {
                if (value == null) value = string.Empty;
                if (!_nguoiCapQuyetDinh.Equals(value))
                {
                    _nguoiCapQuyetDinh = value;
                    PropertyHasChanged("NguoiCapQuyetDinh");
                }
            }
        }

        public string CapQuyetDinh
        {
            get
            {
                CanReadProperty("CapQuyetDinh", true);
                return _capQuyetDinh;
            }
            set
            {
                if (value == null) value = string.Empty;
                if (!_capQuyetDinh.Equals(value))
                {
                    _capQuyetDinh = value;
                    PropertyHasChanged("CapQuyetDinh");
                }
            }
        }

        public DateTime NgayKy
        {
            get
            {
                CanReadProperty("NgayKy", true);
                return _ngayKy.Date;
            }
            set
            {
                CanWriteProperty(true);
                if (!_ngayKy.Equals(value))
                {
                    _ngayKy = new SmartDate(value);
                    PropertyHasChanged("NgayKy");
                }
            }
        }

        public DateTime NgayHieuLuc
        {
            get
            {
                CanReadProperty("NgayHieuLuc", true);
                return _ngayHieuLuc.Date;
            }
            set
            {
                CanWriteProperty(true);
                if (!_ngayHieuLuc.Equals(value))
                {
                    _ngayHieuLuc = new SmartDate(value);
                    PropertyHasChanged("NgayHieuLuc");
                }
            }
        }

         public int MaBoPhanCu
        {
            get
            {
                CanReadProperty("MaBoPhanCu", true);
                return _maBoPhanCu;
            }
            set
            {
                if (!_maBoPhanCu.Equals(value))
                {
                    _maBoPhanCu = value;
                    _tenBoPhanCu = BoPhan.GetBoPhan(_maBoPhanCu).TenBoPhan;
                    PropertyHasChanged("MaBoPhanCu");
                }
            }
        }

        public string TenBoPhanCu
        {
            get
            {
                CanReadProperty("TenBoPhanCu", true);
                _tenBoPhanCu = BoPhan.GetBoPhan(_maBoPhanCu).TenBoPhan;
                return _tenBoPhanCu;
            }
            set
            {
                if (value == null) value = string.Empty;
                if (!_tenBoPhanCu.Equals(value))
                {
                    _tenBoPhanCu = value;
                    PropertyHasChanged("TenBoPhanCu");
                }
            }
        }

        public int MaBoPhanMoi
        {
            get
            {
                CanReadProperty("MaBoPhanMoi", true);
                return _maBoPhanMoi;
            }
            set
            {
                if (!_maBoPhanMoi.Equals(value))
                {
                    _tenBoPhanMoi = BoPhan.GetBoPhan(_maBoPhanMoi).TenBoPhan;
                    _maBoPhanMoi = value;
                    PropertyHasChanged("MaBoPhanMoi");
                }
            }
        }

        public string TenBoPhanMoi
        {
            get
            {
                CanReadProperty("TenBoPhanMoi", true);
                _tenBoPhanMoi = BoPhan.GetBoPhan(_maBoPhanMoi).TenBoPhan;
                return _tenBoPhanMoi;
            }
            set
            {
                if (value == null) value = string.Empty;
                if (!_tenBoPhanMoi.Equals(value))
                {
                    _tenBoPhanMoi = value;
                    PropertyHasChanged("TenBoPhanMoi");
                }
            }
        }

        public int MaChucVuCu
        {
            get
            {
                CanReadProperty("MaChucVuCu", true);
                return _maChucVuCu;
            }
            set
            {
                if (!_maChucVuCu.Equals(value))
                {
                    _maChucVuCu = value;
                    _tenChucVuCu = ChucVu.GetChucVu(_maChucVuCu).TenChucVu;
                    PropertyHasChanged("MaChucVuCu");
                }
            }
        }

        public string TenChucVuCu
        {
            get
            {
                CanReadProperty("TenChucVuCu", true);
                _tenChucVuCu = ChucVu.GetChucVu(_maChucVuCu).TenChucVu;
                return _tenChucVuCu;
            }
            set
            {
                if (value == null) value = string.Empty;
                if (!_tenChucVuCu.Equals(value))
                {
                    _tenChucVuCu = value;
                    PropertyHasChanged("TenChucVuCu");
                }
            }
        }

        public int MaChucVuMoi
        {
            get
            {
                CanReadProperty("MaChucVuMoi", true);
                return _maChucVuMoi;
            }
            set
            {
                if (!_maChucVuMoi.Equals(value))
                {
                    _maChucVuMoi = value;
                    _tenChucVuMoi = ChucVu.GetChucVu(_maChucVuMoi).TenChucVu;
                    PropertyHasChanged("MaChucVuMoi");
                }
            }
        }

        public string TenChucVuMoi
        {
            get
            {
                CanReadProperty("TenChucVuMoi", true);
                _tenChucVuMoi = ChucVu.GetChucVu(_maChucVuMoi).TenChucVu;
                return _tenChucVuMoi;
            }
            set
            {
                if (value == null) value = string.Empty;
                if (!_tenChucVuMoi.Equals(value))
                {
                    _tenChucVuMoi = value;
                    
                    PropertyHasChanged("TenChucVuMoi");
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
                if (value == null) value = string.Empty;
                if (!_ghiChu.Equals(value))
                {
                    _ghiChu = value;
                    PropertyHasChanged("GhiChu");
                }
            }
        }

        public int MaNguoiLap
        {
            get
            {
                CanReadProperty("MaNguoiLap", true);
                return _maNguoiLap;
            }
            set
            {
                if (!_maNguoiLap.Equals(value))
                {
                    _maNguoiLap = value;
                    PropertyHasChanged("MaNguoiLap");
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
                CanWriteProperty(true);
                if (!_ngayLap.Equals(value))
                {
                    _ngayLap = new SmartDate(value);
                    PropertyHasChanged("NgayLap");
                }
            }
        }
        public DateTime NgayHuongMucMoi
        {
            get
            {
                return _ngayHuongMucMoi;
            }
            set
            {
                if (!_ngayHuongMucMoi.Equals(value))
                {
                    _ngayHuongMucMoi = value;
                    PropertyHasChanged("NgayHuongMucMoi");
                }
            }
        }

        public decimal HeSoNoiBoCu
        {
            get
            {
                return _heSoNoiBoCu;
            }
            set
            {
                if (!_heSoNoiBoCu.Equals(value))
                {
                    _heSoNoiBoCu = value;
                    PropertyHasChanged("HeSoNoiBoCu");
                }
            }
        }

        public decimal HeSoPhuCapCu
        {
            get
            {
                return _heSoPhuCapCu;
            }
            set
            {
                if (!_heSoPhuCapCu.Equals(value))
                {
                    _heSoPhuCapCu = value;
                    PropertyHasChanged("HeSoPhuCapCu");
                }
            }
        }

        public decimal HeSoBuCu
        {
            get
            {
                return _heSoBuCu;
            }
            set
            {
                if (!_heSoBuCu.Equals(value))
                {
                    _heSoBuCu = value;
                    PropertyHasChanged("HeSoBuCu");
                }
            }
        }

        public decimal HeSoBoSungCu
        {
            get
            {
                return _heSoBoSungCu;
            }
            set
            {
                if (!_heSoBoSungCu.Equals(value))
                {
                    _heSoBoSungCu = value;
                    PropertyHasChanged("HeSoBoSungCu");
                }
            }
        }

        public decimal HeSoDocHaiCu
        {
            get
            {
                return _heSoDocHaiCu;
            }
            set
            {
                if (!_heSoDocHaiCu.Equals(value))
                {
                    _heSoDocHaiCu = value;
                    PropertyHasChanged("HeSoDocHaiCu");
                }
            }
        }

        public decimal HeSoNoiBoMoi
        {
            get
            {
                return _heSoNoiBoMoi;
            }
            set
            {
                if (!_heSoNoiBoMoi.Equals(value))
                {
                    _heSoNoiBoMoi = value;
                    PropertyHasChanged("HeSoNoiBoMoi");
                }
            }
        }

        public decimal HeSoPhuCapMoi
        {
            get
            {
                return _heSoPhuCapMoi;
            }
            set
            {
                if (!_heSoPhuCapMoi.Equals(value))
                {
                    _heSoPhuCapMoi = value;
                    PropertyHasChanged("HeSoPhuCapMoi");
                }
            }
        }

        public decimal HeSoBuMoi
        {
            get
            {
                return _heSoBuMoi;
            }
            set
            {
                if (!_heSoBuMoi.Equals(value))
                {
                    _heSoBuMoi = value;
                    PropertyHasChanged("HeSoBuMoi");
                }
            }
        }

        public decimal HeSoBoSungMoi
        {
            get
            {
                return _heSoBoSungMoi;
            }
            set
            {
                if (!_heSoBoSungMoi.Equals(value))
                {
                    _heSoBoSungMoi = value;
                    PropertyHasChanged("HeSoBoSungMoi");
                }
            }
        }

        public decimal HeSoDocHaiMoi
        {
            get
            {
                return _heSoDocHaiMoi;
            }
            set
            {
                if (!_heSoDocHaiMoi.Equals(value))
                {
                    _heSoDocHaiMoi = value;
                    PropertyHasChanged("HeSoDocHaiMoi");
                }
            }
        }

        public int MaNgachLuongCu
        {
            get
            {
                return _maNgachLuongCu;
            }
            set
            {
                if (!_maNgachLuongCu.Equals(value))
                {
                    _maNgachLuongCu = value;
                    PropertyHasChanged("MaNgachLuongCu");
                }
            }
        }

        public int MaBacLuongCu
        {
            get
            {
                return _maBacLuongCu;
            }
            set
            {
                if (!_maBacLuongCu.Equals(value))
                {
                    _maBacLuongCu = value;
                    PropertyHasChanged("MaBacLuongCu");
                }
            }
        }

        public decimal HeSoLuongCu
        {
            get
            {
                return _heSoLuongCu;
            }
            set
            {
                if (!_heSoLuongCu.Equals(value))
                {
                    _heSoLuongCu = value;
                    PropertyHasChanged("HeSoLuongCu");
                }
            }
        }

        public decimal HSVKCu
        {
            get
            {
                return _hSVKCu;
            }
            set
            {
                if (!_hSVKCu.Equals(value))
                {
                    _hSVKCu = value;
                    PropertyHasChanged("HSVKCu");
                }
            }
        }

        public int MaNgachLuongMoi
        {
            get
            {
                return _maNgachLuongMoi;
            }
            set
            {
                if (!_maNgachLuongMoi.Equals(value))
                {
                    _maNgachLuongMoi = value;
                    PropertyHasChanged("MaNgachLuongMoi");
                }
            }
        }

        public int MaBacLuongMoi
        {
            get
            {
                return _maBacLuongMoi;
            }
            set
            {
                if (!_maBacLuongMoi.Equals(value))
                {
                    _maBacLuongMoi = value;
                    _heSoLuongMoi = BacLuongCoBan.GetBacLuongCoBan(_maBacLuongMoi).HeSoLuong;
                    PropertyHasChanged("MaBacLuongMoi");
                }
            }
        }

        public decimal HeSoLuongMoi
        {
            get
            {
                return _heSoLuongMoi;
            }
            set
            {
                if (!_heSoLuongMoi.Equals(value))
                {
                    _heSoLuongMoi = value;
                    PropertyHasChanged("HeSoLuongMoi");
                }
            }
        }

        public decimal HSVKMoi
        {
            get
            {
                return _hSVKMoi;
            }
            set
            {
                if (!_hSVKMoi.Equals(value))
                {
                    _hSVKMoi = value;
                    PropertyHasChanged("HSVKMoi");
                }
            }
        }

        public int MaNgachBHCu
        {
            get
            {
                return _maNgachBHCu;
            }
            set
            {
                if (!_maNgachBHCu.Equals(value))
                {
                    _maNgachBHCu = value;
                    PropertyHasChanged("MaNgachBHCu");
                }
            }
        }

        public int MaBacBHCu
        {
            get
            {
                return _maBacBHCu;
            }
            set
            {
                if (!_maBacBHCu.Equals(value))
                {
                    _maBacBHCu = value;
                    PropertyHasChanged("MaBacBHCu");
                }
            }
        }

        public decimal HeSoBHCu
        {
            get
            {
                return _heSoBHCu;
            }
            set
            {
                if (!_heSoBHCu.Equals(value))
                {
                    _heSoBHCu = value;
                    PropertyHasChanged("HeSoBHCu");
                }
            }
        }

        public decimal HSVKBHCu
        {
            get
            {
                return _hSVKBHCu;
            }
            set
            {
                if (!_hSVKBHCu.Equals(value))
                {
                    _hSVKBHCu = value;
                    PropertyHasChanged("HSVKBHCu");
                }
            }
        }

        public int MaNgachBHMoi
        {
            get
            {
                return _maNgachBHMoi;
            }
            set
            {
                if (!_maNgachBHMoi.Equals(value))
                {
                    _maNgachBHMoi = value;
                    PropertyHasChanged("MaNgachBHMoi");
                }
            }
        }

        public int MaBacBHMoi
        {
            get
            {
                return _maBacBHMoi;
            }
            set
            {
                if (!_maBacBHMoi.Equals(value))
                {
                    _maBacBHMoi = value;
                    _heSoBHMoi = BacLuongCoBan.GetBacLuongCoBan(_maBacBHMoi).HeSoLuong;
                    PropertyHasChanged("MaBacBHMoi");
                }
            }
        }

        public decimal HeSoBHMoi
        {
            get
            {
                return _heSoBHMoi;
            }
            set
            {
                if (!_heSoBHMoi.Equals(value))
                {
                    _heSoBHMoi = value;
                    PropertyHasChanged("HeSoBHMoi");
                }
            }
        }

        public decimal HSVKBHMoi
        {
            get
            {
                return _hSVKBHMoi;
            }
            set
            {
                if (!_hSVKBHMoi.Equals(value))
                {
                    _hSVKBHMoi = value;
                    PropertyHasChanged("HSVKBHMoi");
                }
            }
        }
 
    
		protected override object GetIdValue()
		{
			return _mactQuatrinhluanchuyen;
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
			//TODO: Define authorization rules in QuaTrinhLuanChuyenBoNhiem
			//AuthorizationRules.AllowRead("MactQuatrinhluanchuyen", "QuaTrinhLuanChuyenBoNhiemReadGroup");
			//AuthorizationRules.AllowRead("MaNhanVien", "QuaTrinhLuanChuyenBoNhiemReadGroup");
			//AuthorizationRules.AllowRead("QuyetDinh", "QuaTrinhLuanChuyenBoNhiemReadGroup");
			//AuthorizationRules.AllowRead("MaLoaiQuyetDinh", "QuaTrinhLuanChuyenBoNhiemReadGroup");
			//AuthorizationRules.AllowRead("SoQuyetDinh", "QuaTrinhLuanChuyenBoNhiemReadGroup");
			//AuthorizationRules.AllowRead("MaNguoiCapQuyetDinh", "QuaTrinhLuanChuyenBoNhiemReadGroup");
			//AuthorizationRules.AllowRead("NgayKy", "QuaTrinhLuanChuyenBoNhiemReadGroup");
			//AuthorizationRules.AllowRead("NgayKyString", "QuaTrinhLuanChuyenBoNhiemReadGroup");
			//AuthorizationRules.AllowRead("NgayHieuLuc", "QuaTrinhLuanChuyenBoNhiemReadGroup");
			//AuthorizationRules.AllowRead("NgayHieuLucString", "QuaTrinhLuanChuyenBoNhiemReadGroup");
			//AuthorizationRules.AllowRead("MaDonViCu", "QuaTrinhLuanChuyenBoNhiemReadGroup");
			//AuthorizationRules.AllowRead("MaPhongBanCu", "QuaTrinhLuanChuyenBoNhiemReadGroup");
			//AuthorizationRules.AllowRead("MaChucDanhCu", "QuaTrinhLuanChuyenBoNhiemReadGroup");
			//AuthorizationRules.AllowRead("MaChucVuCu", "QuaTrinhLuanChuyenBoNhiemReadGroup");
			//AuthorizationRules.AllowRead("MaChuyenMonNghiepVuCu", "QuaTrinhLuanChuyenBoNhiemReadGroup");
			//AuthorizationRules.AllowRead("MaDonViMoi", "QuaTrinhLuanChuyenBoNhiemReadGroup");
			//AuthorizationRules.AllowRead("MaPhongBanMoi", "QuaTrinhLuanChuyenBoNhiemReadGroup");
			//AuthorizationRules.AllowRead("MaChucDanhMoi", "QuaTrinhLuanChuyenBoNhiemReadGroup");
			//AuthorizationRules.AllowRead("MaChucVuMoi", "QuaTrinhLuanChuyenBoNhiemReadGroup");
			//AuthorizationRules.AllowRead("MaChuyenMonNghiepVuMoi", "QuaTrinhLuanChuyenBoNhiemReadGroup");
			//AuthorizationRules.AllowRead("GhiChu", "QuaTrinhLuanChuyenBoNhiemReadGroup");
			//AuthorizationRules.AllowRead("MaNguoiLap", "QuaTrinhLuanChuyenBoNhiemReadGroup");
			//AuthorizationRules.AllowRead("NgayLap", "QuaTrinhLuanChuyenBoNhiemReadGroup");
			//AuthorizationRules.AllowRead("NgayLapString", "QuaTrinhLuanChuyenBoNhiemReadGroup");

			//AuthorizationRules.AllowWrite("MaNhanVien", "QuaTrinhLuanChuyenBoNhiemWriteGroup");
			//AuthorizationRules.AllowWrite("QuyetDinh", "QuaTrinhLuanChuyenBoNhiemWriteGroup");
			//AuthorizationRules.AllowWrite("MaLoaiQuyetDinh", "QuaTrinhLuanChuyenBoNhiemWriteGroup");
			//AuthorizationRules.AllowWrite("SoQuyetDinh", "QuaTrinhLuanChuyenBoNhiemWriteGroup");
			//AuthorizationRules.AllowWrite("MaNguoiCapQuyetDinh", "QuaTrinhLuanChuyenBoNhiemWriteGroup");
			//AuthorizationRules.AllowWrite("NgayKyString", "QuaTrinhLuanChuyenBoNhiemWriteGroup");
			//AuthorizationRules.AllowWrite("NgayHieuLucString", "QuaTrinhLuanChuyenBoNhiemWriteGroup");
			//AuthorizationRules.AllowWrite("MaDonViCu", "QuaTrinhLuanChuyenBoNhiemWriteGroup");
			//AuthorizationRules.AllowWrite("MaPhongBanCu", "QuaTrinhLuanChuyenBoNhiemWriteGroup");
			//AuthorizationRules.AllowWrite("MaChucDanhCu", "QuaTrinhLuanChuyenBoNhiemWriteGroup");
			//AuthorizationRules.AllowWrite("MaChucVuCu", "QuaTrinhLuanChuyenBoNhiemWriteGroup");
			//AuthorizationRules.AllowWrite("MaChuyenMonNghiepVuCu", "QuaTrinhLuanChuyenBoNhiemWriteGroup");
			//AuthorizationRules.AllowWrite("MaDonViMoi", "QuaTrinhLuanChuyenBoNhiemWriteGroup");
			//AuthorizationRules.AllowWrite("MaPhongBanMoi", "QuaTrinhLuanChuyenBoNhiemWriteGroup");
			//AuthorizationRules.AllowWrite("MaChucDanhMoi", "QuaTrinhLuanChuyenBoNhiemWriteGroup");
			//AuthorizationRules.AllowWrite("MaChucVuMoi", "QuaTrinhLuanChuyenBoNhiemWriteGroup");
			//AuthorizationRules.AllowWrite("MaChuyenMonNghiepVuMoi", "QuaTrinhLuanChuyenBoNhiemWriteGroup");
			//AuthorizationRules.AllowWrite("GhiChu", "QuaTrinhLuanChuyenBoNhiemWriteGroup");
			//AuthorizationRules.AllowWrite("MaNguoiLap", "QuaTrinhLuanChuyenBoNhiemWriteGroup");
			//AuthorizationRules.AllowWrite("NgayLapString", "QuaTrinhLuanChuyenBoNhiemWriteGroup");
		}


		public static bool CanGetObject()
		{
			//TODO: Define CanGetObject permission in QuaTrinhLuanChuyenBoNhiem
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("QuaTrinhLuanChuyenBoNhiemViewGroup"))
			//	return true;
			//return false;
		}

		public static bool CanAddObject()
		{
			//TODO: Define CanAddObject permission in QuaTrinhLuanChuyenBoNhiem
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("QuaTrinhLuanChuyenBoNhiemAddGroup"))
			//	return true;
			//return false;
		}

		public static bool CanEditObject()
		{
			//TODO: Define CanEditObject permission in QuaTrinhLuanChuyenBoNhiem
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("QuaTrinhLuanChuyenBoNhiemEditGroup"))
			//	return true;
			//return false;
		}

		public static bool CanDeleteObject()
		{
			//TODO: Define CanDeleteObject permission in QuaTrinhLuanChuyenBoNhiem
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("QuaTrinhLuanChuyenBoNhiemDeleteGroup"))
			//	return true;
			//return false;
		}
		#endregion //Authorization Rules

		#region Factory Methods
		private QuaTrinhLuanChuyenBoNhiem()
		{ /* require use of factory method */ }

		public static QuaTrinhLuanChuyenBoNhiem NewQuaTrinhLuanChuyenBoNhiem()
		{
			if (!CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a QuaTrinhLuanChuyenBoNhiem");
			return DataPortal.Create<QuaTrinhLuanChuyenBoNhiem>();
		}

        public static QuaTrinhLuanChuyenBoNhiem NewQuaTrinhLuanChuyenBoNhiem(long maNhanVien, int MaDonVi, int MaPhongBan, int MaChucDanh, int MaChucVu, int MaDonViChuyenMon)
        {
            QuaTrinhLuanChuyenBoNhiem _QuaTrinhLuanChuyenBoNhiem = new QuaTrinhLuanChuyenBoNhiem();
            _QuaTrinhLuanChuyenBoNhiem.MaNhanVien = maNhanVien;
            //_QuaTrinhLuanChuyenBoNhiem.MaDonViCu = MaDonVi;
            //_QuaTrinhLuanChuyenBoNhiem.MaPhongBanCu = MaPhongBan;
            //_QuaTrinhLuanChuyenBoNhiem.MaChucDanhCu = MaChucDanh;
            _QuaTrinhLuanChuyenBoNhiem.MaChucVuCu = MaChucVu;
            //_QuaTrinhLuanChuyenBoNhiem.MaChuyenMonNghiepVuCu = MaDonViChuyenMon;
            return _QuaTrinhLuanChuyenBoNhiem;
        }

		public static QuaTrinhLuanChuyenBoNhiem GetQuaTrinhLuanChuyenBoNhiem(int mactQuatrinhluanchuyen)
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException("User not authorized to view a QuaTrinhLuanChuyenBoNhiem");
			return DataPortal.Fetch<QuaTrinhLuanChuyenBoNhiem>(new Criteria(mactQuatrinhluanchuyen));
		}

		public static void DeleteQuaTrinhLuanChuyenBoNhiem(int mactQuatrinhluanchuyen)
		{
			if (!CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a QuaTrinhLuanChuyenBoNhiem");
			DataPortal.Delete(new Criteria(mactQuatrinhluanchuyen));
		}

		public override QuaTrinhLuanChuyenBoNhiem Save()
		{
			if (IsDeleted && !CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a QuaTrinhLuanChuyenBoNhiem");
			else if (IsNew && !CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a QuaTrinhLuanChuyenBoNhiem");
			else if (!CanEditObject())
				throw new System.Security.SecurityException("User not authorized to update a QuaTrinhLuanChuyenBoNhiem");

			return base.Save();
		}
        public static int KiemTraNgayHieuLucMax(long MaNhanVien)
        {
            int maQuyetDinh = 0;
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {

                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_KiemTraNgayHieuLucMaxLuanChuyenDieuChuyen";
                    cm.Parameters.AddWithValue("@MaNhanVien", MaNhanVien);
                    cm.Parameters.AddWithValue("@MaQuyetDinh", maQuyetDinh);
                    cm.Parameters["@MaQuyetDinh"].Direction = ParameterDirection.Output;

                    cm.ExecuteNonQuery();


                    object obj = (object)cm.Parameters["@MaQuyetDinh"].Value;
                    if (!Convert.IsDBNull(obj))
                    {
                        maQuyetDinh = (int)obj;
                    }

                }

                return maQuyetDinh;
            }//using
        }
		#endregion //Factory Methods

		#region Child Factory Methods
		internal static QuaTrinhLuanChuyenBoNhiem NewQuaTrinhLuanChuyenBoNhiemChild()
		{
			QuaTrinhLuanChuyenBoNhiem child = new QuaTrinhLuanChuyenBoNhiem();
			child.ValidationRules.CheckRules();
			child.MarkAsChild();
			return child;
		}

		internal static QuaTrinhLuanChuyenBoNhiem GetQuaTrinhLuanChuyenBoNhiem(SafeDataReader dr)
		{
			QuaTrinhLuanChuyenBoNhiem child =  new QuaTrinhLuanChuyenBoNhiem();
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
			public int MactQuatrinhluanchuyen;

			public Criteria(int mactQuatrinhluanchuyen)
			{
				this.MactQuatrinhluanchuyen = mactQuatrinhluanchuyen;
			}
		}

		#endregion //Criteria

		#region Data Access - Create
		[RunLocal]
		protected override void DataPortal_Create()
		{
			//ValidationRules.CheckRules();
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
                cm.CommandText = "spd_SelecttblnsQuaTrinhLuanChuyenBoNhiem";

				cm.Parameters.AddWithValue("@MaCT_QuaTrinhLuanChuyen", criteria.MactQuatrinhluanchuyen);

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
			DataPortal_Delete(new Criteria(_mactQuatrinhluanchuyen));
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
                cm.CommandText = "spd_DeletetblnsQuaTrinhLuanChuyenBoNhiem";

				cm.Parameters.AddWithValue("@MaCT_QuaTrinhLuanChuyen", criteria.MactQuatrinhluanchuyen);

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
			FetchChildren(dr);
		}

		private void FetchObject(SafeDataReader dr)
		{
            _mactQuatrinhluanchuyen = dr.GetInt32("MaCT_QuaTrinhLuanChuyen");
            _maNhanVien = dr.GetInt64("MaNhanVien");
            _tenNhanVien = dr.GetString("TenNhanVien");
            _quyetDinh = dr.GetInt32("QuyetDinh");
            _maLoaiQuyetDinh = dr.GetInt32("MaLoaiQuyetDinh");
            _soQuyetDinh = dr.GetString("SoQuyetDinh");
            _nguoiCapQuyetDinh = dr.GetString("NguoiCapQuyetDinh");
            _capQuyetDinh = dr.GetString("CapQuyetDinh");
            _ngayKy = dr.GetSmartDate("NgayKy", _ngayKy.EmptyIsMin);
            _ngayHieuLuc = dr.GetSmartDate("NgayHieuLuc", _ngayHieuLuc.EmptyIsMin);
            _maBoPhanCu = dr.GetInt32("MaBoPhanCu");
            _tenBoPhanCu = dr.GetString("TenBoPhanCu");
            _maBoPhanMoi = dr.GetInt32("MaBoPhanMoi");
            _tenBoPhanMoi = dr.GetString("TenBoPhanMoi");
            _maChucVuCu = dr.GetInt32("MaChucVuCu");
            _tenChucVuCu = dr.GetString("TenChucVuCu");
            _maChucVuMoi = dr.GetInt32("MaChucVuMoi");
            _tenChucVuMoi = dr.GetString("TenChucVuMoi");
            _ghiChu = dr.GetString("GhiChu");
            _maNguoiLap = dr.GetInt32("MaNguoiLap");
            _ngayLap = dr.GetSmartDate("NgayLap", _ngayLap.EmptyIsMin);
            _ngayHuongMucMoi = dr.GetDateTime("NgayHuongMucMoi");
            _heSoNoiBoCu = dr.GetDecimal("HeSoNoiBoCu");
            _heSoPhuCapCu = dr.GetDecimal("HeSoPhuCapCu");
            _heSoBuCu = dr.GetDecimal("HeSoBuCu");
            _heSoBoSungCu = dr.GetDecimal("HeSoBoSungCu");
            _heSoDocHaiCu = dr.GetDecimal("HeSoDocHaiCu");
            _heSoNoiBoMoi = dr.GetDecimal("HeSoNoiBoMoi");
            _heSoPhuCapMoi = dr.GetDecimal("HeSoPhuCapMoi");
            _heSoBuMoi = dr.GetDecimal("HeSoBuMoi");
            _heSoBoSungMoi = dr.GetDecimal("HeSoBoSungMoi");
            _heSoDocHaiMoi = dr.GetDecimal("HeSoDocHaiMoi");
            _maNgachLuongCu = dr.GetInt32("MaNgachLuongCu");
            _maBacLuongCu = dr.GetInt32("MaBacLuongCu");
            _heSoLuongCu = dr.GetDecimal("HeSoLuongCu");
            _hSVKCu = dr.GetDecimal("HSVKCu");
            _maNgachLuongMoi = dr.GetInt32("MaNgachLuongMoi");
            _maBacLuongMoi = dr.GetInt32("MaBacLuongMoi");
            _heSoLuongMoi = dr.GetDecimal("HeSoLuongMoi");
            _hSVKMoi = dr.GetDecimal("HSVKMoi");
            _maNgachBHCu = dr.GetInt32("MaNgachBHCu");
            _maBacBHCu = dr.GetInt32("MaBacBHCu");
            _heSoBHCu = dr.GetDecimal("HeSoBHCu");
            _hSVKBHCu = dr.GetDecimal("HSVKBHCu");
            _maNgachBHMoi = dr.GetInt32("MaNgachBHMoi");
            _maBacBHMoi = dr.GetInt32("MaBacBHMoi");
            _heSoBHMoi = dr.GetDecimal("HeSoBHMoi");
            _hSVKBHMoi = dr.GetDecimal("HSVKBHMoi");
            _maNhomNgachMoi = dr.GetInt32("MaNhomNgachMoi");
            _maNhomNgachBHMoi = dr.GetInt32("MaNhomNgachBHMoi");
            _laQDMoi = dr.GetBoolean("LaQDMoi");
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
                cm.CommandText = "spd_InserttblnsQuaTrinhLuanChuyenBoNhiem";

				AddInsertParameters(cm);

				cm.ExecuteNonQuery();

				_mactQuatrinhluanchuyen = (int)cm.Parameters["@MaCT_QuaTrinhLuanChuyen"].Value;
			}//using
		}

		private void AddInsertParameters(SqlCommand cm)
		{
            //TODO: if parent use identity key, fix fk member with value from parent
            if (_maNhanVien != 0)
                cm.Parameters.AddWithValue("@MaNhanVien", _maNhanVien);
            else
                cm.Parameters.AddWithValue("@MaNhanVien", DBNull.Value);
            if (_tenNhanVien.Length > 0)
                cm.Parameters.AddWithValue("@TenNhanVien", _tenNhanVien);
            else
                cm.Parameters.AddWithValue("@TenNhanVien", DBNull.Value);
            if (_quyetDinh != 0)
                cm.Parameters.AddWithValue("@QuyetDinh", _quyetDinh);
            else
                cm.Parameters.AddWithValue("@QuyetDinh", DBNull.Value);
            if (_maLoaiQuyetDinh != 0)
                cm.Parameters.AddWithValue("@MaLoaiQuyetDinh", _maLoaiQuyetDinh);
            else
                cm.Parameters.AddWithValue("@MaLoaiQuyetDinh", DBNull.Value);
            if (_soQuyetDinh.Length > 0)
                cm.Parameters.AddWithValue("@SoQuyetDinh", _soQuyetDinh);
            else
                cm.Parameters.AddWithValue("@SoQuyetDinh", DBNull.Value);
            if (_nguoiCapQuyetDinh.Length > 0)
                cm.Parameters.AddWithValue("@NguoiCapQuyetDinh", _nguoiCapQuyetDinh);
            else
                cm.Parameters.AddWithValue("@NguoiCapQuyetDinh", DBNull.Value);
            if (_capQuyetDinh.Length > 0)
                cm.Parameters.AddWithValue("@CapQuyetDinh", _capQuyetDinh);
            else
                cm.Parameters.AddWithValue("@CapQuyetDinh", DBNull.Value);
            cm.Parameters.AddWithValue("@NgayKy", _ngayKy.DBValue);
            cm.Parameters.AddWithValue("@NgayHieuLuc", _ngayHieuLuc.DBValue);
            if (_maBoPhanCu != 0)
                cm.Parameters.AddWithValue("@MaBoPhanCu", _maBoPhanCu);
            else
                cm.Parameters.AddWithValue("@MaBoPhanCu", DBNull.Value);
            if (_tenBoPhanCu.Length > 0)
                cm.Parameters.AddWithValue("@TenBoPhanCu", _tenBoPhanCu);
            else
                cm.Parameters.AddWithValue("@TenBoPhanCu", DBNull.Value);
            if (_maBoPhanMoi != 0)
                cm.Parameters.AddWithValue("@MaBoPhanMoi", _maBoPhanMoi);
            else
                cm.Parameters.AddWithValue("@MaBoPhanMoi", DBNull.Value);
            if (_tenBoPhanMoi.Length > 0)
                cm.Parameters.AddWithValue("@TenBoPhanMoi", _tenBoPhanMoi);
            else
                cm.Parameters.AddWithValue("@TenBoPhanMoi", DBNull.Value);
            if (_maChucVuCu != 0)
                cm.Parameters.AddWithValue("@MaChucVuCu", _maChucVuCu);
            else
                cm.Parameters.AddWithValue("@MaChucVuCu", DBNull.Value);
            if (_tenChucVuCu.Length > 0)
                cm.Parameters.AddWithValue("@TenChucVuCu", _tenChucVuCu);
            else
                cm.Parameters.AddWithValue("@TenChucVuCu", DBNull.Value);
            if (_maChucVuMoi != 0)
                cm.Parameters.AddWithValue("@MaChucVuMoi", _maChucVuMoi);
            else
                cm.Parameters.AddWithValue("@MaChucVuMoi", DBNull.Value);
            if (_tenChucVuMoi.Length > 0)
                cm.Parameters.AddWithValue("@TenChucVuMoi", _tenChucVuMoi);
            else
                cm.Parameters.AddWithValue("@TenChucVuMoi", DBNull.Value);
            if (_ghiChu.Length > 0)
                cm.Parameters.AddWithValue("@GhiChu", _ghiChu);
            else
                cm.Parameters.AddWithValue("@GhiChu", DBNull.Value);
            if (_maNguoiLap != 0)
                cm.Parameters.AddWithValue("@MaNguoiLap", _maNguoiLap);
            else
                cm.Parameters.AddWithValue("@MaNguoiLap", DBNull.Value);
            cm.Parameters.AddWithValue("@NgayLap", _ngayLap.DBValue);
            cm.Parameters.AddWithValue("@NgayHuongMucMoi", _ngayHuongMucMoi);
            if (_heSoNoiBoCu != 0)
                cm.Parameters.AddWithValue("@HeSoNoiBoCu", _heSoNoiBoCu);
            else
                cm.Parameters.AddWithValue("@HeSoNoiBoCu", DBNull.Value);
            if (_heSoPhuCapCu != 0)
                cm.Parameters.AddWithValue("@HeSoPhuCapCu", _heSoPhuCapCu);
            else
                cm.Parameters.AddWithValue("@HeSoPhuCapCu", DBNull.Value);
            if (_heSoBuCu != 0)
                cm.Parameters.AddWithValue("@HeSoBuCu", _heSoBuCu);
            else
                cm.Parameters.AddWithValue("@HeSoBuCu", DBNull.Value);
            if (_heSoBoSungCu != 0)
                cm.Parameters.AddWithValue("@HeSoBoSungCu", _heSoBoSungCu);
            else
                cm.Parameters.AddWithValue("@HeSoBoSungCu", DBNull.Value);
            if (_heSoDocHaiCu != 0)
                cm.Parameters.AddWithValue("@HeSoDocHaiCu", _heSoDocHaiCu);
            else
                cm.Parameters.AddWithValue("@HeSoDocHaiCu", DBNull.Value);
            if (_heSoNoiBoMoi != 0)
                cm.Parameters.AddWithValue("@HeSoNoiBoMoi", _heSoNoiBoMoi);
            else
                cm.Parameters.AddWithValue("@HeSoNoiBoMoi", DBNull.Value);
            if (_heSoPhuCapMoi != 0)
                cm.Parameters.AddWithValue("@HeSoPhuCapMoi", _heSoPhuCapMoi);
            else
                cm.Parameters.AddWithValue("@HeSoPhuCapMoi", DBNull.Value);
            if (_heSoBuMoi != 0)
                cm.Parameters.AddWithValue("@HeSoBuMoi", _heSoBuMoi);
            else
                cm.Parameters.AddWithValue("@HeSoBuMoi", DBNull.Value);
            if (_heSoBoSungMoi != 0)
                cm.Parameters.AddWithValue("@HeSoBoSungMoi", _heSoBoSungMoi);
            else
                cm.Parameters.AddWithValue("@HeSoBoSungMoi", DBNull.Value);
            if (_heSoDocHaiMoi != 0)
                cm.Parameters.AddWithValue("@HeSoDocHaiMoi", _heSoDocHaiMoi);
            else
                cm.Parameters.AddWithValue("@HeSoDocHaiMoi", DBNull.Value);
            if (_maNgachLuongCu != 0)
                cm.Parameters.AddWithValue("@MaNgachLuongCu", _maNgachLuongCu);
            else
                cm.Parameters.AddWithValue("@MaNgachLuongCu", DBNull.Value);
            if (_maBacLuongCu != 0)
                cm.Parameters.AddWithValue("@MaBacLuongCu", _maBacLuongCu);
            else
                cm.Parameters.AddWithValue("@MaBacLuongCu", DBNull.Value);
            if (_heSoLuongCu != 0)
                cm.Parameters.AddWithValue("@HeSoLuongCu", _heSoLuongCu);
            else
                cm.Parameters.AddWithValue("@HeSoLuongCu", DBNull.Value);
            if (_hSVKCu != 0)
                cm.Parameters.AddWithValue("@HSVKCu", _hSVKCu);
            else
                cm.Parameters.AddWithValue("@HSVKCu", DBNull.Value);
            if (_maNgachLuongMoi != 0)
                cm.Parameters.AddWithValue("@MaNgachLuongMoi", _maNgachLuongMoi);
            else
                cm.Parameters.AddWithValue("@MaNgachLuongMoi", DBNull.Value);
            if (_maBacLuongMoi != 0)
                cm.Parameters.AddWithValue("@MaBacLuongMoi", _maBacLuongMoi);
            else
                cm.Parameters.AddWithValue("@MaBacLuongMoi", DBNull.Value);
            if (_heSoLuongMoi != 0)
                cm.Parameters.AddWithValue("@HeSoLuongMoi", _heSoLuongMoi);
            else
                cm.Parameters.AddWithValue("@HeSoLuongMoi", DBNull.Value);
            if (_hSVKMoi != 0)
                cm.Parameters.AddWithValue("@HSVKMoi", _hSVKMoi);
            else
                cm.Parameters.AddWithValue("@HSVKMoi", DBNull.Value);
            if (_maNgachBHCu != 0)
                cm.Parameters.AddWithValue("@MaNgachBHCu", _maNgachBHCu);
            else
                cm.Parameters.AddWithValue("@MaNgachBHCu", DBNull.Value);
            if (_maBacBHCu != 0)
                cm.Parameters.AddWithValue("@MaBacBHCu", _maBacBHCu);
            else
                cm.Parameters.AddWithValue("@MaBacBHCu", DBNull.Value);
            if (_heSoBHCu != 0)
                cm.Parameters.AddWithValue("@HeSoBHCu", _heSoBHCu);
            else
                cm.Parameters.AddWithValue("@HeSoBHCu", DBNull.Value);
            if (_hSVKBHCu != 0)
                cm.Parameters.AddWithValue("@HSVKBHCu", _hSVKBHCu);
            else
                cm.Parameters.AddWithValue("@HSVKBHCu", DBNull.Value);
            if (_maNgachBHMoi != 0)
                cm.Parameters.AddWithValue("@MaNgachBHMoi", _maNgachBHMoi);
            else
                cm.Parameters.AddWithValue("@MaNgachBHMoi", DBNull.Value);
            if (_maBacBHMoi != 0)
                cm.Parameters.AddWithValue("@MaBacBHMoi", _maBacBHMoi);
            else
                cm.Parameters.AddWithValue("@MaBacBHMoi", DBNull.Value);
            if (_heSoBHMoi != 0)
                cm.Parameters.AddWithValue("@HeSoBHMoi", _heSoBHMoi);
            else
                cm.Parameters.AddWithValue("@HeSoBHMoi", DBNull.Value);
            if (_hSVKBHMoi != 0)
                cm.Parameters.AddWithValue("@HSVKBHMoi", _hSVKBHMoi);
            else
                cm.Parameters.AddWithValue("@HSVKBHMoi", DBNull.Value);

            cm.Parameters.AddWithValue("@LaQDMoi", _laQDMoi);

            if (_maNhomNgachMoi != 0)
                cm.Parameters.AddWithValue("@MaNhomNgachMoi", _maNhomNgachMoi);
            else
                cm.Parameters.AddWithValue("@MaNhomNgachMoi", DBNull.Value);
            if (_maNhomNgachBHMoi != 0)
                cm.Parameters.AddWithValue("@MaNhomNgachBHMoi", _maNhomNgachBHMoi);
            else
                cm.Parameters.AddWithValue("@MaNhomNgachBHMoi", DBNull.Value);
            cm.Parameters.AddWithValue("@MaCT_QuaTrinhLuanChuyen", _mactQuatrinhluanchuyen);
            cm.Parameters["@MaCT_QuaTrinhLuanChuyen"].Direction = ParameterDirection.Output;
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
                cm.CommandText = "spd_UpdatetblnsQuaTrinhLuanChuyenBoNhiem";

				AddUpdateParameters(cm);

				cm.ExecuteNonQuery();

			}//using
		}

		private void AddUpdateParameters(SqlCommand cm)
		{
            cm.Parameters.AddWithValue("@MaCT_QuaTrinhLuanChuyen", _mactQuatrinhluanchuyen);
            if (_maNhanVien != 0)
                cm.Parameters.AddWithValue("@MaNhanVien", _maNhanVien);
            else
                cm.Parameters.AddWithValue("@MaNhanVien", DBNull.Value);
            if (_tenNhanVien.Length > 0)
                cm.Parameters.AddWithValue("@TenNhanVien", _tenNhanVien);
            else
                cm.Parameters.AddWithValue("@TenNhanVien", DBNull.Value);
            if (_quyetDinh != 0)
                cm.Parameters.AddWithValue("@QuyetDinh", _quyetDinh);
            else
                cm.Parameters.AddWithValue("@QuyetDinh", DBNull.Value);
            if (_maLoaiQuyetDinh != 0)
                cm.Parameters.AddWithValue("@MaLoaiQuyetDinh", _maLoaiQuyetDinh);
            else
                cm.Parameters.AddWithValue("@MaLoaiQuyetDinh", DBNull.Value);
            if (_soQuyetDinh.Length > 0)
                cm.Parameters.AddWithValue("@SoQuyetDinh", _soQuyetDinh);
            else
                cm.Parameters.AddWithValue("@SoQuyetDinh", DBNull.Value);
            if (_nguoiCapQuyetDinh.Length > 0)
                cm.Parameters.AddWithValue("@NguoiCapQuyetDinh", _nguoiCapQuyetDinh);
            else
                cm.Parameters.AddWithValue("@NguoiCapQuyetDinh", DBNull.Value);
            if (_capQuyetDinh.Length > 0)
                cm.Parameters.AddWithValue("@CapQuyetDinh", _capQuyetDinh);
            else
                cm.Parameters.AddWithValue("@CapQuyetDinh", DBNull.Value);
            cm.Parameters.AddWithValue("@NgayKy", _ngayKy.DBValue);
            cm.Parameters.AddWithValue("@NgayHieuLuc", _ngayHieuLuc.DBValue);
            if (_maBoPhanCu != 0)
                cm.Parameters.AddWithValue("@MaBoPhanCu", _maBoPhanCu);
            else
                cm.Parameters.AddWithValue("@MaBoPhanCu", DBNull.Value);
            if (_tenBoPhanCu.Length > 0)
                cm.Parameters.AddWithValue("@TenBoPhanCu", _tenBoPhanCu);
            else
                cm.Parameters.AddWithValue("@TenBoPhanCu", DBNull.Value);
            if (_maBoPhanMoi != 0)
                cm.Parameters.AddWithValue("@MaBoPhanMoi", _maBoPhanMoi);
            else
                cm.Parameters.AddWithValue("@MaBoPhanMoi", DBNull.Value);
            if (_tenBoPhanMoi.Length > 0)
                cm.Parameters.AddWithValue("@TenBoPhanMoi", _tenBoPhanMoi);
            else
                cm.Parameters.AddWithValue("@TenBoPhanMoi", DBNull.Value);
            if (_maChucVuCu != 0)
                cm.Parameters.AddWithValue("@MaChucVuCu", _maChucVuCu);
            else
                cm.Parameters.AddWithValue("@MaChucVuCu", DBNull.Value);
            if (_tenChucVuCu.Length > 0)
                cm.Parameters.AddWithValue("@TenChucVuCu", _tenChucVuCu);
            else
                cm.Parameters.AddWithValue("@TenChucVuCu", DBNull.Value);
            if (_maChucVuMoi != 0)
                cm.Parameters.AddWithValue("@MaChucVuMoi", _maChucVuMoi);
            else
                cm.Parameters.AddWithValue("@MaChucVuMoi", DBNull.Value);
            if (_tenChucVuMoi.Length > 0)
                cm.Parameters.AddWithValue("@TenChucVuMoi", _tenChucVuMoi);
            else
                cm.Parameters.AddWithValue("@TenChucVuMoi", DBNull.Value);
            if (_ghiChu.Length > 0)
                cm.Parameters.AddWithValue("@GhiChu", _ghiChu);
            else
                cm.Parameters.AddWithValue("@GhiChu", DBNull.Value);
            if (_maNguoiLap != 0)
                cm.Parameters.AddWithValue("@MaNguoiLap", _maNguoiLap);
            else
                cm.Parameters.AddWithValue("@MaNguoiLap", DBNull.Value);
            cm.Parameters.AddWithValue("@NgayLap", _ngayLap.DBValue);
            cm.Parameters.AddWithValue("@NgayHuongMucMoi", _ngayHuongMucMoi);
            if (_heSoNoiBoCu != 0)
                cm.Parameters.AddWithValue("@HeSoNoiBoCu", _heSoNoiBoCu);
            else
                cm.Parameters.AddWithValue("@HeSoNoiBoCu", DBNull.Value);
            if (_heSoPhuCapCu != 0)
                cm.Parameters.AddWithValue("@HeSoPhuCapCu", _heSoPhuCapCu);
            else
                cm.Parameters.AddWithValue("@HeSoPhuCapCu", DBNull.Value);
            if (_heSoBuCu != 0)
                cm.Parameters.AddWithValue("@HeSoBuCu", _heSoBuCu);
            else
                cm.Parameters.AddWithValue("@HeSoBuCu", DBNull.Value);
            if (_heSoBoSungCu != 0)
                cm.Parameters.AddWithValue("@HeSoBoSungCu", _heSoBoSungCu);
            else
                cm.Parameters.AddWithValue("@HeSoBoSungCu", DBNull.Value);
            if (_heSoDocHaiCu != 0)
                cm.Parameters.AddWithValue("@HeSoDocHaiCu", _heSoDocHaiCu);
            else
                cm.Parameters.AddWithValue("@HeSoDocHaiCu", DBNull.Value);
            if (_heSoNoiBoMoi != 0)
                cm.Parameters.AddWithValue("@HeSoNoiBoMoi", _heSoNoiBoMoi);
            else
                cm.Parameters.AddWithValue("@HeSoNoiBoMoi", DBNull.Value);
            if (_heSoPhuCapMoi != 0)
                cm.Parameters.AddWithValue("@HeSoPhuCapMoi", _heSoPhuCapMoi);
            else
                cm.Parameters.AddWithValue("@HeSoPhuCapMoi", DBNull.Value);
            if (_heSoBuMoi != 0)
                cm.Parameters.AddWithValue("@HeSoBuMoi", _heSoBuMoi);
            else
                cm.Parameters.AddWithValue("@HeSoBuMoi", DBNull.Value);
            if (_heSoBoSungMoi != 0)
                cm.Parameters.AddWithValue("@HeSoBoSungMoi", _heSoBoSungMoi);
            else
                cm.Parameters.AddWithValue("@HeSoBoSungMoi", DBNull.Value);
            if (_heSoDocHaiMoi != 0)
                cm.Parameters.AddWithValue("@HeSoDocHaiMoi", _heSoDocHaiMoi);
            else
                cm.Parameters.AddWithValue("@HeSoDocHaiMoi", DBNull.Value);
            if (_maNgachLuongCu != 0)
                cm.Parameters.AddWithValue("@MaNgachLuongCu", _maNgachLuongCu);
            else
                cm.Parameters.AddWithValue("@MaNgachLuongCu", DBNull.Value);
            if (_maBacLuongCu != 0)
                cm.Parameters.AddWithValue("@MaBacLuongCu", _maBacLuongCu);
            else
                cm.Parameters.AddWithValue("@MaBacLuongCu", DBNull.Value);
            if (_heSoLuongCu != 0)
                cm.Parameters.AddWithValue("@HeSoLuongCu", _heSoLuongCu);
            else
                cm.Parameters.AddWithValue("@HeSoLuongCu", DBNull.Value);
            if (_hSVKCu != 0)
                cm.Parameters.AddWithValue("@HSVKCu", _hSVKCu);
            else
                cm.Parameters.AddWithValue("@HSVKCu", DBNull.Value);
            if (_maNgachLuongMoi != 0)
                cm.Parameters.AddWithValue("@MaNgachLuongMoi", _maNgachLuongMoi);
            else
                cm.Parameters.AddWithValue("@MaNgachLuongMoi", DBNull.Value);
            if (_maBacLuongMoi != 0)
                cm.Parameters.AddWithValue("@MaBacLuongMoi", _maBacLuongMoi);
            else
                cm.Parameters.AddWithValue("@MaBacLuongMoi", DBNull.Value);
            if (_heSoLuongMoi != 0)
                cm.Parameters.AddWithValue("@HeSoLuongMoi", _heSoLuongMoi);
            else
                cm.Parameters.AddWithValue("@HeSoLuongMoi", DBNull.Value);
            if (_hSVKMoi != 0)
                cm.Parameters.AddWithValue("@HSVKMoi", _hSVKMoi);
            else
                cm.Parameters.AddWithValue("@HSVKMoi", DBNull.Value);
            if (_maNgachBHCu != 0)
                cm.Parameters.AddWithValue("@MaNgachBHCu", _maNgachBHCu);
            else
                cm.Parameters.AddWithValue("@MaNgachBHCu", DBNull.Value);
            if (_maBacBHCu != 0)
                cm.Parameters.AddWithValue("@MaBacBHCu", _maBacBHCu);
            else
                cm.Parameters.AddWithValue("@MaBacBHCu", DBNull.Value);
            if (_heSoBHCu != 0)
                cm.Parameters.AddWithValue("@HeSoBHCu", _heSoBHCu);
            else
                cm.Parameters.AddWithValue("@HeSoBHCu", DBNull.Value);
            if (_hSVKBHCu != 0)
                cm.Parameters.AddWithValue("@HSVKBHCu", _hSVKBHCu);
            else
                cm.Parameters.AddWithValue("@HSVKBHCu", DBNull.Value);
            if (_maNgachBHMoi != 0)
                cm.Parameters.AddWithValue("@MaNgachBHMoi", _maNgachBHMoi);
            else
                cm.Parameters.AddWithValue("@MaNgachBHMoi", DBNull.Value);
            if (_maBacBHMoi != 0)
                cm.Parameters.AddWithValue("@MaBacBHMoi", _maBacBHMoi);
            else
                cm.Parameters.AddWithValue("@MaBacBHMoi", DBNull.Value);
            if (_heSoBHMoi != 0)
                cm.Parameters.AddWithValue("@HeSoBHMoi", _heSoBHMoi);
            else
                cm.Parameters.AddWithValue("@HeSoBHMoi", DBNull.Value);
            if (_hSVKBHMoi != 0)
                cm.Parameters.AddWithValue("@HSVKBHMoi", _hSVKBHMoi);
            else
                cm.Parameters.AddWithValue("@HSVKBHMoi", DBNull.Value);
            if (_maNhomNgachMoi != 0)
                cm.Parameters.AddWithValue("@MaNhomNgachMoi", _maNhomNgachMoi);
            else
                cm.Parameters.AddWithValue("@MaNhomNgachMoi", DBNull.Value);
            if (_maNhomNgachBHMoi != 0)
                cm.Parameters.AddWithValue("@MaNhomNgachBHMoi", _maNhomNgachBHMoi);
            else
                cm.Parameters.AddWithValue("@MaNhomNgachBHMoi", DBNull.Value);
            cm.Parameters.AddWithValue("@LaQDMoi", _laQDMoi);
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

			ExecuteDelete(tr, new Criteria(_mactQuatrinhluanchuyen));
			MarkNew();
		}
		#endregion //Data Access - Delete
		#endregion //Data Access
	}
}
