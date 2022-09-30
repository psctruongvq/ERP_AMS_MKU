
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{ 
	[Serializable()] 
	public class HDLaoDong : Csla.BusinessBase<HDLaoDong>
	{
	    #region Business Properties and Methods

		//declare members
		private long _maHopDongLaoDong = 0;
		private long _maNhanVien = 0;
        private string _tenNhanVien = string.Empty;
		private int _maHinhThucHopDong = 0;
        private string _TenHinhthucHD = string.Empty;
		private string _soHopDong = string.Empty;
		private SmartDate _ngayKy = new SmartDate(DateTime.Today);
		private long _maNguoiKy = 0;
		private int _maChucVu = 0;
		private int _maChucDanh = 0;
		private SmartDate _tuNgay = new SmartDate(DateTime.Today);
		private SmartDate _denNgay = new SmartDate(DateTime.Today);
		private string _dieuKhoanKhac = string.Empty;
        private long _maNguoiLap = Security.CurrentUser.Info.UserID;
        private string _tenNguoiLap = string.Empty;
		private SmartDate _ngayLap = new SmartDate(DateTime.Today);
		private decimal _phanTramBHXH = 0;
		private decimal _phanTramBHYT = 0;
		private decimal _soTienCongDoan = 0;
		private string _ghiChu = string.Empty;
		private byte _tinhTrang = 1;
        private string _thoiGianLamViec = string.Empty;
        private string _dungCuLamViec = string.Empty;
        private string _phuongTienDiLamViec = string.Empty;
        private string _cheDoDaoTao = string.Empty;
        private string _congViecPhaiLam = string.Empty;
        private string _ngheNghiep = string.Empty;
        private string _Mucluong = string.Empty;
        private string _Hinhthuctraluong = string.Empty;

		[System.ComponentModel.DataObjectField(true, true)]
		public long MaHopDongLaoDong
		{
			get
			{
				CanReadProperty("MaHopDongLaoDong", true);
				return _maHopDongLaoDong;
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

        public string TenNhanVien
        {
            get
            {
                CanReadProperty("TenNhanVien", true);
                return NhanVien.GetNhanVien(_maNhanVien).TenNhanVien;
            }
        }

		public int MaHinhThucHopDong
		{
			get
			{
				CanReadProperty("MaHinhThucHopDong", true);
				return _maHinhThucHopDong;
			}
			set
			{
				CanWriteProperty("MaHinhThucHopDong", true);
				if (!_maHinhThucHopDong.Equals(value))
				{
					_maHinhThucHopDong = value;
                    _TenHinhthucHD = HinhThucHopDong.GetHinhThucHopDong(_maHinhThucHopDong).TenHinhThucHopDong;
					PropertyHasChanged("MaHinhThucHopDong");
				}
			}
		}

		public string SoHopDong
		{
			get
			{
				CanReadProperty("SoHopDong", true);
				return _soHopDong;
			}
			set
			{
				CanWriteProperty("SoHopDong", true);
				if (value == null) value = string.Empty;
				if (!_soHopDong.Equals(value))
				{
					_soHopDong = value;
					PropertyHasChanged("SoHopDong");
				}
			}
		}

        public string TenHinhThucHD
        {
            get
            {
                CanReadProperty( true);
                _TenHinhthucHD = HinhThucHopDong.GetHinhThucHopDong(_maHinhThucHopDong).TenHinhThucHopDong;
                return _TenHinhthucHD;
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
		
        public long MaNguoiKy
		{
			get
			{
				CanReadProperty("MaNguoiKy", true);
				return _maNguoiKy;
			}
			set
			{
				CanWriteProperty("MaNguoiKy", true);
				if (!_maNguoiKy.Equals(value))
				{
					_maNguoiKy = value;
					PropertyHasChanged("MaNguoiKy");
				}
			}
		}

		public int MaChucVu
		{
			get
			{
				CanReadProperty("MaChucVu", true);
				return _maChucVu;
			}
			set
			{
				CanWriteProperty("MaChucVu", true);
				if (!_maChucVu.Equals(value))
				{
					_maChucVu = value;
					PropertyHasChanged("MaChucVu");
				}
			}
		}

		public int MaChucDanh
		{
			get
			{
				CanReadProperty("MaChucDanh", true);
				return _maChucDanh;
			}
			set
			{
				CanWriteProperty("MaChucDanh", true);
				if (!_maChucDanh.Equals(value))
				{
					_maChucDanh = value;
					PropertyHasChanged("MaChucDanh");
				}
			}
		}

		public DateTime TuNgay
		{
			get
			{
				CanReadProperty("TuNgay", true);
				return _tuNgay.Date;
			}
            set
            {
                CanWriteProperty(true);
                if (!_tuNgay.Equals(value))
                {
                    _tuNgay = new SmartDate(value);
                    PropertyHasChanged("TuNgay");
                }
            }
		}
		
		public DateTime DenNgay
		{
			get
			{
				CanReadProperty("DenNgay", true);
				return _denNgay.Date;
			}
            set
            {
                CanWriteProperty(true);
                if (!_denNgay.Equals(value))
                {
                    _denNgay = new SmartDate(value);
                    PropertyHasChanged("DenNgay");
                }
            }
		}		

		public string DieuKhoanKhac
		{
			get
			{
				CanReadProperty("DieuKhoanKhac", true);
				return _dieuKhoanKhac;
			}
			set
			{
				CanWriteProperty("DieuKhoanKhac", true);
				if (value == null) value = string.Empty;
				if (!_dieuKhoanKhac.Equals(value))
				{
					_dieuKhoanKhac = value;
					PropertyHasChanged("DieuKhoanKhac");
				}
			}
		}

		public long MaNguoiLap
		{
			get
			{
				CanReadProperty("MaNguoiLap", true);
				return _maNguoiLap;
			}
			set
			{
				CanWriteProperty("MaNguoiLap", true);
				if (!_maNguoiLap.Equals(value))
				{
					_maNguoiLap = value;
					PropertyHasChanged("MaNguoiLap");
				}
			}
		}

        public string TenNguoiLap
        {
            get
            {
                CanReadProperty("TenNguoiLap", true);
                _tenNguoiLap = TenNV.GetTenNhanVien(_maNguoiLap).TenNhanVien;
                return _tenNguoiLap;
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

		public decimal HeSoBHXH
		{
			get
			{
				CanReadProperty("HeSoBHXH", true);
                _phanTramBHXH = Default_Ngay.GetDefault_Ngay().PhanTramBHXH;
				return _phanTramBHXH;
			}
			set
			{
				CanWriteProperty("HeSoBHXH", true);
				if (!_phanTramBHXH.Equals(value))
				{
                    _phanTramBHXH = Default_Ngay.GetDefault_Ngay().PhanTramBHXH;
					_phanTramBHXH = value;
					PropertyHasChanged("HeSoBHXH");
				}
			}
		}

		public decimal HeSoBHYT
		{
			get
			{
				CanReadProperty("HeSoBHYT", true);
                _phanTramBHXH = Default_Ngay.GetDefault_Ngay().PhanTramBHXH;
				return _phanTramBHYT;
			}
			set
			{
				CanWriteProperty("HeSoBHYT", true);
				if (!_phanTramBHYT.Equals(value))
				{
                    _phanTramBHXH = Default_Ngay.GetDefault_Ngay().PhanTramBHXH;
					_phanTramBHYT = value;
					PropertyHasChanged("HeSoBHYT");
				}
			}
		}

		public decimal SoTienCongDoan
		{
			get
			{
				CanReadProperty("SoTienCongDoan", true);
                _soTienCongDoan = Default_Ngay.GetDefault_Ngay().TienCongDoan;
                return _soTienCongDoan;
			}
			set
			{
                CanWriteProperty("SoTienCongDoan", true);
                if (!_soTienCongDoan.Equals(value))
				{
                    _soTienCongDoan = Default_Ngay.GetDefault_Ngay().TienCongDoan;
                    _soTienCongDoan = value;
                    PropertyHasChanged("SoTienCongDoan");
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
				CanWriteProperty("GhiChu", true);
				if (value == null) value = string.Empty;
				if (!_ghiChu.Equals(value))
				{
					_ghiChu = value;
					PropertyHasChanged("GhiChu");
				}
			}
		}

		public byte TinhTrang
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

        public string ThoiGianLamViec
        {
            get
            {
                CanReadProperty("ThoiGianLamViec", true);
                return _thoiGianLamViec;
            }
            set
            {
                CanWriteProperty("ThoiGianLamViec", true);
                if (value == null) value = string.Empty;
                if (!_thoiGianLamViec.Equals(value))
                {
                    _thoiGianLamViec = value;
                    PropertyHasChanged("ThoiGianLamViec");
                }
            }
        }

        public string DungCuLamViec
        {
            get
            {
                CanReadProperty("DungCuLamViec", true);
                return _dungCuLamViec;
            }
            set
            {
                CanWriteProperty("DungCuLamViec", true);
                if (value == null) value = string.Empty;
                if (!_dungCuLamViec.Equals(value))
                {
                    _dungCuLamViec = value;
                    PropertyHasChanged("DungCuLamViec");
                }
            }
        }

        public string PhuongTienDiLamViec
        {
            get
            {
                CanReadProperty("PhuongTienDiLamViec", true);
                return _phuongTienDiLamViec;
            }
            set
            {
                CanWriteProperty("PhuongTienDiLamViec", true);
                if (value == null) value = string.Empty;
                if (!_phuongTienDiLamViec.Equals(value))
                {
                    _phuongTienDiLamViec = value;
                    PropertyHasChanged("PhuongTienDiLamViec");
                }
            }
        }

        public string CheDoDaoTao
        {
            get
            {
                CanReadProperty("CheDoDaoTao", true);
                return _cheDoDaoTao;
            }
            set
            {
                CanWriteProperty("CheDoDaoTao", true);
                if (value == null) value = string.Empty;
                if (!_cheDoDaoTao.Equals(value))
                {
                    _cheDoDaoTao = value;
                    PropertyHasChanged("CheDoDaoTao");
                }
            }
        }

        public string CongViecPhaiLam
        {
            get
            {
                CanReadProperty("CongViecPhaiLam", true);
                return _congViecPhaiLam;
            }
            set
            {
                CanWriteProperty("CongViecPhaiLam", true);
                if (value == null) value = string.Empty;
                if (!_congViecPhaiLam.Equals(value))
                {
                    _congViecPhaiLam = value;
                    PropertyHasChanged("CongViecPhaiLam");
                }
            }
        }

        public string NgheNghiep
        {
            get
            {
                CanReadProperty("NgheNghiep", true);
                return _ngheNghiep;
            }
            set
            {
                CanWriteProperty("NgheNghiep", true);
                if (value == null) value = string.Empty;
                if (!_ngheNghiep.Equals(value))
                {
                    _ngheNghiep = value;
                    PropertyHasChanged("NgheNghiep");
                }
            }
        }

        public string Mucluong
        {
            get
            {
                CanReadProperty("MucLuong", true);
                return _Mucluong;
            }
            set
            {
                CanWriteProperty("MucLuong", true);
                if (value == null) value = string.Empty;
                if (!_Mucluong.Equals(value))
                {
                    _Mucluong = value;
                    PropertyHasChanged("MucLuong");
                }
            }
        }

        public string HinhThucTraLuong
        {
            get
            {
                CanReadProperty("HinhThucTraLuong", true);
                return _Hinhthuctraluong;
            }
            set
            {
                CanWriteProperty("HinhThucTraLuong", true);
                if (value == null) value = string.Empty;
                if (!_Hinhthuctraluong.Equals(value))
                {
                    _Hinhthuctraluong = value;
                    PropertyHasChanged("HinhThucTraLuong");
                }
            }
        }

		protected override object GetIdValue()
		{
			return _maHopDongLaoDong;
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
			// SoHopDong
			//
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("SoHopDong", 20));
			//
			// DieuKhoanKhac
			//
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("DieuKhoanKhac", 500));
			//
			// GhiChu
			//
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("GhiChu", 4000));
            //
            // ThoiGianLamViec
            //
            //ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("ThoiGianLamViec", 50));
            //
            // DungCuLamViec
            //
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("DungCuLamViec", 4000));
            //
            // PhuongTienDiLamViec
            //
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("PhuongTienDiLamViec", 4000));
            //
            // CheDoDaoTao
            //
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("CheDoDaoTao", 4000));
            //
            // CongViecPhaiLam
            //
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("CongViecPhaiLam", 4000));
            //
            // NgheNghiep
            //
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("NgheNghiep", 500));

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
			//TODO: Define authorization rules in HDLaoDong
			//AuthorizationRules.AllowRead("MaHopDongLaoDong", "HDLaoDongReadGroup");
			//AuthorizationRules.AllowRead("MaNhanVien", "HDLaoDongReadGroup");
			//AuthorizationRules.AllowRead("MaHinhThucHopDong", "HDLaoDongReadGroup");
			//AuthorizationRules.AllowRead("SoHopDong", "HDLaoDongReadGroup");
			//AuthorizationRules.AllowRead("NgayKy", "HDLaoDongReadGroup");
			//AuthorizationRules.AllowRead("NgayKyString", "HDLaoDongReadGroup");
			//AuthorizationRules.AllowRead("MaNguoiKy", "HDLaoDongReadGroup");
			//AuthorizationRules.AllowRead("MaNgachLuongCB", "HDLaoDongReadGroup");
			//AuthorizationRules.AllowRead("MaNgachLuongKD", "HDLaoDongReadGroup");
			//AuthorizationRules.AllowRead("MaBacLuongCB", "HDLaoDongReadGroup");
			//AuthorizationRules.AllowRead("MaBacLuongKD", "HDLaoDongReadGroup");
			//AuthorizationRules.AllowRead("MaChucVu", "HDLaoDongReadGroup");
			//AuthorizationRules.AllowRead("MaChucDanh", "HDLaoDongReadGroup");
			//AuthorizationRules.AllowRead("HeSoLuongCB", "HDLaoDongReadGroup");
			//AuthorizationRules.AllowRead("HeSoLuongKD", "HDLaoDongReadGroup");
			//AuthorizationRules.AllowRead("PhanTramLuongV1", "HDLaoDongReadGroup");
			//AuthorizationRules.AllowRead("PhanTramLuongV2", "HDLaoDongReadGroup");
			//AuthorizationRules.AllowRead("TuNgay", "HDLaoDongReadGroup");
			//AuthorizationRules.AllowRead("TuNgayString", "HDLaoDongReadGroup");
			//AuthorizationRules.AllowRead("DenNgay", "HDLaoDongReadGroup");
			//AuthorizationRules.AllowRead("DenNgayString", "HDLaoDongReadGroup");
			//AuthorizationRules.AllowRead("DieuKhoanKhac", "HDLaoDongReadGroup");
			//AuthorizationRules.AllowRead("MaNguoiLap", "HDLaoDongReadGroup");
			//AuthorizationRules.AllowRead("NgayLap", "HDLaoDongReadGroup");
			//AuthorizationRules.AllowRead("NgayLapString", "HDLaoDongReadGroup");
			//AuthorizationRules.AllowRead("HeSoBHXH", "HDLaoDongReadGroup");
			//AuthorizationRules.AllowRead("HeSoBHYT", "HDLaoDongReadGroup");
			//AuthorizationRules.AllowRead("HeSoCD", "HDLaoDongReadGroup");
			//AuthorizationRules.AllowRead("GhiChu", "HDLaoDongReadGroup");
			//AuthorizationRules.AllowRead("TinhTrang", "HDLaoDongReadGroup");
            //AuthorizationRules.AllowRead("ThoiGianLamViec", "HDLaoDongReadGroup");
            //AuthorizationRules.AllowRead("DungCuLamViec", "HDLaoDongReadGroup");
            //AuthorizationRules.AllowRead("PhuongTienDiLamViec", "HDLaoDongReadGroup");
            //AuthorizationRules.AllowRead("CheDoDaoTao", "HDLaoDongReadGroup");
            //AuthorizationRules.AllowRead("CongViecPhaiLam", "HDLaoDongReadGroup");
            //AuthorizationRules.AllowRead("NgheNghiep", "HDLaoDongReadGroup");

			//AuthorizationRules.AllowWrite("MaNhanVien", "HDLaoDongWriteGroup");
			//AuthorizationRules.AllowWrite("MaHinhThucHopDong", "HDLaoDongWriteGroup");
			//AuthorizationRules.AllowWrite("SoHopDong", "HDLaoDongWriteGroup");
			//AuthorizationRules.AllowWrite("NgayKyString", "HDLaoDongWriteGroup");
			//AuthorizationRules.AllowWrite("MaNguoiKy", "HDLaoDongWriteGroup");
			//AuthorizationRules.AllowWrite("MaNgachLuongCB", "HDLaoDongWriteGroup");
			//AuthorizationRules.AllowWrite("MaNgachLuongKD", "HDLaoDongWriteGroup");
			//AuthorizationRules.AllowWrite("MaBacLuongCB", "HDLaoDongWriteGroup");
			//AuthorizationRules.AllowWrite("MaBacLuongKD", "HDLaoDongWriteGroup");
			//AuthorizationRules.AllowWrite("MaChucVu", "HDLaoDongWriteGroup");
			//AuthorizationRules.AllowWrite("MaChucDanh", "HDLaoDongWriteGroup");
			//AuthorizationRules.AllowWrite("HeSoLuongCB", "HDLaoDongWriteGroup");
			//AuthorizationRules.AllowWrite("HeSoLuongKD", "HDLaoDongWriteGroup");
			//AuthorizationRules.AllowWrite("PhanTramLuongV1", "HDLaoDongWriteGroup");
			//AuthorizationRules.AllowWrite("PhanTramLuongV2", "HDLaoDongWriteGroup");
			//AuthorizationRules.AllowWrite("TuNgayString", "HDLaoDongWriteGroup");
			//AuthorizationRules.AllowWrite("DenNgayString", "HDLaoDongWriteGroup");
			//AuthorizationRules.AllowWrite("DieuKhoanKhac", "HDLaoDongWriteGroup");
			//AuthorizationRules.AllowWrite("MaNguoiLap", "HDLaoDongWriteGroup");
			//AuthorizationRules.AllowWrite("NgayLapString", "HDLaoDongWriteGroup");
			//AuthorizationRules.AllowWrite("HeSoBHXH", "HDLaoDongWriteGroup");
			//AuthorizationRules.AllowWrite("HeSoBHYT", "HDLaoDongWriteGroup");
			//AuthorizationRules.AllowWrite("HeSoCD", "HDLaoDongWriteGroup");
			//AuthorizationRules.AllowWrite("GhiChu", "HDLaoDongWriteGroup");
			//AuthorizationRules.AllowWrite("TinhTrang", "HDLaoDongWriteGroup");
            //AuthorizationRules.AllowWrite("ThoiGianLamViec", "HDLaoDongWriteGroup");
            //AuthorizationRules.AllowWrite("DungCuLamViec", "HDLaoDongWriteGroup");
            //AuthorizationRules.AllowWrite("PhuongTienDiLamViec", "HDLaoDongWriteGroup");
            //AuthorizationRules.AllowWrite("CheDoDaoTao", "HDLaoDongWriteGroup");
            //AuthorizationRules.AllowWrite("CongViecPhaiLam", "HDLaoDongWriteGroup");
            //AuthorizationRules.AllowWrite("NgheNghiep", "HDLaoDongWriteGroup");
		}


		public static bool CanGetObject()
		{
			//TODO: Define CanGetObject permission in HDLaoDong
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("HDLaoDongViewGroup"))
			//	return true;
			//return false;
		}

		public static bool CanAddObject()
		{
			//TODO: Define CanAddObject permission in HDLaoDong
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("HDLaoDongAddGroup"))
			//	return true;
			//return false;
		}

		public static bool CanEditObject()
		{
			//TODO: Define CanEditObject permission in HDLaoDong
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("HDLaoDongEditGroup"))
			//	return true;
			//return false;
		}

		public static bool CanDeleteObject()
		{
			//TODO: Define CanDeleteObject permission in HDLaoDong
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("HDLaoDongDeleteGroup"))
			//	return true;
			//return false;
		}
		#endregion //Authorization Rules

		#region Factory Methods
		private HDLaoDong()
		{ /* require use of factory method */ }

		public static HDLaoDong NewHDLaoDong()
		{
			if (!CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a HDLaoDong");
			return DataPortal.Create<HDLaoDong>();
		}

        public static HDLaoDong NewHDLaoDong(long MaNhanVien, int MaChucVu, int MaChucDanh, decimal HeSoBHXH, decimal HeSoBHYT, decimal SoTienCongDoan)
        {
            HDLaoDong _HDLaoDong = new HDLaoDong();
            _HDLaoDong.MaNhanVien = MaNhanVien;
            _HDLaoDong.MaChucVu = MaChucVu;
            _HDLaoDong.MaChucDanh = MaChucDanh;
            _HDLaoDong.HeSoBHXH = HeSoBHXH;
            _HDLaoDong.HeSoBHYT = HeSoBHYT;
            _HDLaoDong.SoTienCongDoan = SoTienCongDoan;
            return _HDLaoDong;
        }

		public static HDLaoDong GetHDLaoDong(long maHopDongLaoDong)
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException("User not authorized to view a HDLaoDong");
			return DataPortal.Fetch<HDLaoDong>(new Criteria(maHopDongLaoDong));
		}

		public static void DeleteHDLaoDong(long maHopDongLaoDong)
		{
			if (!CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a HDLaoDong");
			DataPortal.Delete(new Criteria(maHopDongLaoDong));
		}

		public override HDLaoDong Save()
		{
			if (IsDeleted && !CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a HDLaoDong");
			else if (IsNew && !CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a HDLaoDong");
			else if (!CanEditObject())
				throw new System.Security.SecurityException("User not authorized to update a HDLaoDong");

			return base.Save();
		}

		#endregion //Factory Methods

		#region Child Factory Methods
		internal static HDLaoDong NewHDLaoDongChild()
		{
			HDLaoDong child = new HDLaoDong();
			child.ValidationRules.CheckRules();
			child.MarkAsChild();
			return child;
		}

		internal static HDLaoDong GetHDLaoDong(SafeDataReader dr)
		{
			HDLaoDong child =  new HDLaoDong();
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
			public long MaHopDongLaoDong;

			public Criteria(long maHopDongLaoDong)
			{
				this.MaHopDongLaoDong = maHopDongLaoDong;
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
                cm.CommandText = "spd_SelecttblnsHopDongLaoDong";

				cm.Parameters.AddWithValue("@MaHopDongLaoDong", criteria.MaHopDongLaoDong);

				using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
				{
                    while (dr.Read())
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
			DataPortal_Delete(new Criteria(_maHopDongLaoDong));
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
                cm.CommandText = "spd_DeletetblnsHopDongLaoDong";

				cm.Parameters.AddWithValue("@MaHopDongLaoDong", criteria.MaHopDongLaoDong);

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
            try
            {
                _maHopDongLaoDong = dr.GetInt64("MaHopDongLaoDong");
                _maNhanVien = dr.GetInt64("MaNhanVien");
                _tenNhanVien = TenNV.GetTenNhanVien(_maNhanVien).TenNhanVien;
                _maHinhThucHopDong = dr.GetInt32("MaHinhThucHopDong");
                _TenHinhthucHD = HinhThucHopDong.GetHinhThucHopDong(_maHinhThucHopDong).TenHinhThucHopDong;
                _soHopDong = dr.GetString("SoHopDong");
                _ngayKy = dr.GetSmartDate("NgayKy", _ngayKy.EmptyIsMin);
                _maNguoiKy = dr.GetInt64("MaNguoiKy");
                _maChucVu = dr.GetInt32("MaChucVu");
                _maChucDanh = dr.GetInt32("MaChucDanh");
                _tuNgay = dr.GetSmartDate("TuNgay", _tuNgay.EmptyIsMin);
                _denNgay = dr.GetSmartDate("DenNgay", _denNgay.EmptyIsMin);
                _dieuKhoanKhac = dr.GetString("DieuKhoanKhac");
                _maNguoiLap = dr.GetInt64("MaNguoiLap");
                _ngayLap = dr.GetSmartDate("NgayLap", _ngayLap.EmptyIsMin);
                _phanTramBHXH = dr.GetDecimal("PhanTramBHXH");
                _phanTramBHYT = dr.GetDecimal("PhanTramBHYT");
                _soTienCongDoan=Default_Ngay.GetDefault_Ngay().TienCongDoan;
                //_soTienCongDoan = dr.GetDecimal("SoTienCongDoan");
                _ghiChu = dr.GetString("GhiChu");
                _tinhTrang = dr.GetByte("TinhTrang");
                _thoiGianLamViec = dr.GetString("ThoiGianLamViec");
                _dungCuLamViec = dr.GetString("DungCuLamViec");
                _phuongTienDiLamViec = dr.GetString("PhuongTienDiLamViec");
                _cheDoDaoTao = dr.GetString("CheDoDaoTao");
                _congViecPhaiLam = dr.GetString("CongViecPhaiLam");
                _ngheNghiep = dr.GetString("NgheNghiep");
                _Hinhthuctraluong = dr.GetString("Hinhthuctraluong");
                _Mucluong = dr.GetString("MucluongChinhTienCong");
            }
            catch (Exception ex)
            {
                throw ex;
            }
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
                cm.CommandText = "spd_InserttblnsHopDongLaoDong";

				AddInsertParameters(cm);

				cm.ExecuteNonQuery();

				_maHopDongLaoDong = (long)cm.Parameters["@MaHopDongLaoDong"].Value;
			}//using
		}

		private void AddInsertParameters(SqlCommand cm)
		{
			cm.Parameters.AddWithValue("@MaNhanVien", _maNhanVien);
			cm.Parameters.AddWithValue("@MaHinhThucHopDong", _maHinhThucHopDong);
			cm.Parameters.AddWithValue("@SoHopDong", _soHopDong);
			cm.Parameters.AddWithValue("@NgayKy", _ngayKy.DBValue);
			cm.Parameters.AddWithValue("@MaNguoiKy", _maNguoiKy);
			cm.Parameters.AddWithValue("@MaChucVu", _maChucVu);
			cm.Parameters.AddWithValue("@MaChucDanh", _maChucDanh);
			cm.Parameters.AddWithValue("@TuNgay", _tuNgay.DBValue);
			cm.Parameters.AddWithValue("@DenNgay", _denNgay.DBValue);
			if (_dieuKhoanKhac.Length > 0)
				cm.Parameters.AddWithValue("@DieuKhoanKhac", _dieuKhoanKhac);
			else
				cm.Parameters.AddWithValue("@DieuKhoanKhac", DBNull.Value);
			if (_maNguoiLap != 0)
				cm.Parameters.AddWithValue("@MaNguoiLap", _maNguoiLap);
			else
				cm.Parameters.AddWithValue("@MaNguoiLap", DBNull.Value);
			cm.Parameters.AddWithValue("@NgayLap", _ngayLap.DBValue);
            cm.Parameters.AddWithValue("@PhanTramBHXH", _phanTramBHXH);
            cm.Parameters.AddWithValue("@PhanTramBHYT ", _phanTramBHYT);
            cm.Parameters.AddWithValue("@SoTienCongDoan", _soTienCongDoan);
			cm.Parameters.AddWithValue("@GhiChu", _ghiChu);
			cm.Parameters.AddWithValue("@TinhTrang", _tinhTrang);
            if (_thoiGianLamViec.Length > 0)
                cm.Parameters.AddWithValue("@ThoiGianLamViec", _thoiGianLamViec);
            else
                cm.Parameters.AddWithValue("@ThoiGianLamViec", DBNull.Value);
            if (_dungCuLamViec.Length > 0)
                cm.Parameters.AddWithValue("@DungCuLamViec", _dungCuLamViec);
            else
                cm.Parameters.AddWithValue("@DungCuLamViec", DBNull.Value);
            if (_phuongTienDiLamViec.Length > 0)
                cm.Parameters.AddWithValue("@PhuongTienDiLamViec", _phuongTienDiLamViec);
            else
                cm.Parameters.AddWithValue("@PhuongTienDiLamViec", DBNull.Value);
            if (_cheDoDaoTao.Length > 0)
                cm.Parameters.AddWithValue("@CheDoDaoTao", _cheDoDaoTao);
            else
                cm.Parameters.AddWithValue("@CheDoDaoTao", DBNull.Value);
            if (_congViecPhaiLam.Length > 0)
                cm.Parameters.AddWithValue("@CongViecPhaiLam", _congViecPhaiLam);
            else
                cm.Parameters.AddWithValue("@CongViecPhaiLam", DBNull.Value);
            if (_ngheNghiep.Length > 0)
                cm.Parameters.AddWithValue("@NgheNghiep", _ngheNghiep);
            else
                cm.Parameters.AddWithValue("@NgheNghiep", DBNull.Value);

            if (_Mucluong.Length > 0)
                cm.Parameters.AddWithValue("@MucluongChinhTienCong", _Mucluong);
            else
                cm.Parameters.AddWithValue("@MucluongChinhTienCong", DBNull.Value);

            if (_Hinhthuctraluong.Length > 0)
                cm.Parameters.AddWithValue("@Hinhthuctraluong", _Hinhthuctraluong);
            else
                cm.Parameters.AddWithValue("@Hinhthuctraluong", DBNull.Value);

			cm.Parameters.AddWithValue("@MaHopDongLaoDong", _maHopDongLaoDong);
			cm.Parameters["@MaHopDongLaoDong"].Direction = ParameterDirection.Output;
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
                cm.CommandText = "spd_UpdatetblnsHopDongLaoDong";

				AddUpdateParameters(cm);

				cm.ExecuteNonQuery();

			}//using
		}

		private void AddUpdateParameters(SqlCommand cm)
		{
            cm.Parameters.AddWithValue("@MaHopDongLaoDong", _maHopDongLaoDong);
            cm.Parameters.AddWithValue("@MaHinhThucHopDong", _maHinhThucHopDong);
            cm.Parameters.AddWithValue("@NgayKy", _ngayKy.DBValue);
            cm.Parameters.AddWithValue("@TuNgay", _tuNgay.DBValue);
            cm.Parameters.AddWithValue("@DenNgay", _denNgay.DBValue);
            cm.Parameters.AddWithValue("@NgayLap", _ngayLap.DBValue);
            cm.Parameters.AddWithValue("@HeSoBHXH", _phanTramBHXH);
            cm.Parameters.AddWithValue("@HeSoBHYT", _phanTramBHYT);
            cm.Parameters.AddWithValue("@SoTienCongDoan", _soTienCongDoan);
            cm.Parameters.AddWithValue("@SoHopDong", _soHopDong);
            cm.Parameters.AddWithValue("@GhiChu", _ghiChu);
            if (_congViecPhaiLam.Length > 0)
                cm.Parameters.AddWithValue("@CongViecPhaiLam", _congViecPhaiLam);
            else
                cm.Parameters.AddWithValue("@CongViecPhaiLam", DBNull.Value);
            if (_ngheNghiep.Length > 0)
                cm.Parameters.AddWithValue("@NgheNghiep", _ngheNghiep);
            else
                cm.Parameters.AddWithValue("@NgheNghiep", DBNull.Value);

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

			ExecuteDelete(tr, new Criteria(_maHopDongLaoDong));
			MarkNew();
		}
		#endregion //Data Access - Delete

        #region KiemTraSoHopDong

        public static int KiemTraSoHopDong(string soHopDong)
        {
            int giaTri = 0;
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {

                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_KiemTraSoHopDong";
                    cm.Parameters.AddWithValue("@SoHopDong", soHopDong);
                    cm.Parameters.AddWithValue("@GiaTri", giaTri);
                    cm.Parameters["@GiaTri"].Direction = ParameterDirection.Output;
                    cm.ExecuteNonQuery();
                    giaTri = (int)cm.Parameters["@GiaTri"].Value;
                }
            }//us

            return giaTri;
        }

        #endregion

		#endregion //Data Access

        public static void ThemvaoHopDong(long manhanvien,string SoHopdong,int MaHTHD,DateTime Ngayky, DateTime TuNgay,DateTime DenNgay, long MaNguoiLap,DateTime NgayLap, string Ghichu,string Nghenghiep, string Congviec)
        {

            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {

                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_InserttblnsHopdonglaodongList";
                    cm.Parameters.AddWithValue("@manhanvien", manhanvien);
                    cm.Parameters.AddWithValue("@SoHopdong", SoHopdong);
                    cm.Parameters.AddWithValue("@mahinhthucHD", MaHTHD);
                    cm.Parameters.AddWithValue("@Ngayky", Ngayky);
                    cm.Parameters.AddWithValue("@Tungay",TuNgay);
                    if (DateTime.Parse(DenNgay.ToLongDateString()).ToString("dd/MM/yyyy") == "01/01/0001")
                        cm.Parameters.AddWithValue("@Denngay", DBNull.Value);  
                    else  
                        cm.Parameters.AddWithValue("@Denngay", DenNgay);
                    cm.Parameters.AddWithValue("@Manguoilap", MaNguoiLap);
                    cm.Parameters.AddWithValue("@NgayLap", NgayLap);
                    cm.Parameters.AddWithValue("@Nghenghiep",Nghenghiep );
                    cm.Parameters.AddWithValue("@CongViec", Congviec);
                    cm.Parameters.AddWithValue("@GhiChu", Ghichu);
                    cm.ExecuteNonQuery();
                }
            }
        }
	}
}
