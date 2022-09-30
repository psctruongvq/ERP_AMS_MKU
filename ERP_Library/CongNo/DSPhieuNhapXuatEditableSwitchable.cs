using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{ 
	[Serializable()] 
	public class DSPhieuNhapXuat : Csla.BusinessBase<DSPhieuNhapXuat>
	{
		#region Business Properties and Methods

		//declare members
		private long _maPhieuNhapXuat = 0;
		private string _soPhieu = string.Empty;
		private short _loai = 0;
		private bool _laNhap = false;
		private SmartDate _ngayHT = new SmartDate(DateTime.Today);
		private SmartDate _ngayNX = new SmartDate(false);
		private long _maNguoiLap = 0;
		private int _maKho = 0;
		private long _maDoiTac = 0;
		private int _maKhoDoiTac = 0;
		private long _maNhanCong = 0;
		private decimal _tuoiVang = 0;
		private decimal _giaTriHoaDon = 0;
		private decimal _giaTriKho = 0;
		private string _dienGiai = string.Empty;
		private int _maNghiepVuNX = 0;
		private int _maDinhKhoan = 0;
		private byte _maTinhTrang = 0;
		private byte _quyTrinh = 0;
		private string _tongSoTienString = string.Empty;
		private bool _ghiSoCai = false;
		private long _maPhieuXuatNau = 0;
		private decimal _chiPhiVanChuyen = 0;
		private double _phanTramChietKhauHD = 0;
		private decimal _soTienChietKhauHD = 0;
		private byte _loaiUuDai = 0;
		private decimal _soTienDaThanhToan = 0;
		private decimal _soTienConLai = 0;
		private byte _trangThai = 0;
        private bool _check = false;
        private decimal _soTienTucThoi = 0;

        private ChungTu_HoaDon _ChungTu_HoaDon = ChungTu_HoaDon.NewChungTu_HoaDon();

		[System.ComponentModel.DataObjectField(true, true)]
		public long MaPhieuNhapXuat
		{
			get
			{
				CanReadProperty("MaPhieuNhapXuat", true);
				return _maPhieuNhapXuat;
			}
		}

		public string SoPhieu
		{
			get
			{
				CanReadProperty("SoPhieu", true);
				return _soPhieu;
			}
			set
			{
				CanWriteProperty("SoPhieu", true);
				if (value == null) value = string.Empty;
				if (!_soPhieu.Equals(value))
				{
					_soPhieu = value;
					PropertyHasChanged("SoPhieu");
				}
			}
		}

        public ChungTu_HoaDon ChungTu_HoaDon
        {
            get
            {
                CanReadProperty(true);
                return _ChungTu_HoaDon;
            }
            set
            {
                CanWriteProperty("ChungTu_HoaDon", true);
                if (!_ChungTu_HoaDon.Equals(value))
                {
                    _ChungTu_HoaDon = value;
                    PropertyHasChanged("ChungTu_HoaDon");
                }
            }
        }

		public short Loai
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

		public bool LaNhap
		{
			get
			{
				CanReadProperty("LaNhap", true);
				return _laNhap;
			}
			set
			{
				CanWriteProperty("LaNhap", true);
				if (!_laNhap.Equals(value))
				{
					_laNhap = value;
					PropertyHasChanged("LaNhap");
				}
			}
		}

		public DateTime NgayHT
		{
			get
			{
				CanReadProperty("NgayHT", true);
				return _ngayHT.Date;
			}
            set
            {
                CanWriteProperty("NgayHT", true);
                if (!_ngayHT.Equals(value))
                {
                    _ngayHT = new SmartDate(value);
                    PropertyHasChanged("NgayHT");
                }
            }
		}

		public DateTime NgayNX
		{
			get
			{
				CanReadProperty("NgayNX", true);
				return _ngayNX.Date;
			}
            set
            {
                CanWriteProperty("NgayNX", true);
                if (!_ngayNX.Equals(value))
                {
                    _ngayNX = new SmartDate(value);
                    PropertyHasChanged("NgayNX");
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

		public int MaKho
		{
			get
			{
				CanReadProperty("MaKho", true);
				return _maKho;
			}
			set
			{
				CanWriteProperty("MaKho", true);
				if (!_maKho.Equals(value))
				{
					_maKho = value;
					PropertyHasChanged("MaKho");
				}
			}
		}

		public long MaDoiTac
		{
			get
			{
				CanReadProperty("MaDoiTac", true);
				return _maDoiTac;
			}
			set
			{
				CanWriteProperty("MaDoiTac", true);
				if (!_maDoiTac.Equals(value))
				{
					_maDoiTac = value;
					PropertyHasChanged("MaDoiTac");
				}
			}
		}

		public int MaKhoDoiTac
		{
			get
			{
				CanReadProperty("MaKhoDoiTac", true);
				return _maKhoDoiTac;
			}
			set
			{
				CanWriteProperty("MaKhoDoiTac", true);
				if (!_maKhoDoiTac.Equals(value))
				{
					_maKhoDoiTac = value;
					PropertyHasChanged("MaKhoDoiTac");
				}
			}
		}

		public long MaNhanCong
		{
			get
			{
				CanReadProperty("MaNhanCong", true);
				return _maNhanCong;
			}
			set
			{
				CanWriteProperty("MaNhanCong", true);
				if (!_maNhanCong.Equals(value))
				{
					_maNhanCong = value;
					PropertyHasChanged("MaNhanCong");
				}
			}
		}

		public decimal TuoiVang
		{
			get
			{
				CanReadProperty("TuoiVang", true);
				return _tuoiVang;
			}
			set
			{
				CanWriteProperty("TuoiVang", true);
				if (!_tuoiVang.Equals(value))
				{
					_tuoiVang = value;
					PropertyHasChanged("TuoiVang");
				}
			}
		}

		public decimal GiaTriHoaDon
		{
			get
			{
				CanReadProperty("GiaTriHoaDon", true);
				return _giaTriHoaDon;
			}
			set
			{
				CanWriteProperty("GiaTriHoaDon", true);
				if (!_giaTriHoaDon.Equals(value))
				{
					_giaTriHoaDon = value;
                    _soTienConLai = _giaTriHoaDon - _soTienDaThanhToan;
					PropertyHasChanged("GiaTriHoaDon");
				}
			}
		}

		public decimal GiaTriKho
		{
			get
			{
				CanReadProperty("GiaTriKho", true);
				return _giaTriKho;
			}
			set
			{
				CanWriteProperty("GiaTriKho", true);
				if (!_giaTriKho.Equals(value))
				{
					_giaTriKho = value;
					PropertyHasChanged("GiaTriKho");
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

		public int MaNghiepVuNX
		{
			get
			{
				CanReadProperty("MaNghiepVuNX", true);
				return _maNghiepVuNX;
			}
			set
			{
				CanWriteProperty("MaNghiepVuNX", true);
				if (!_maNghiepVuNX.Equals(value))
				{
					_maNghiepVuNX = value;
					PropertyHasChanged("MaNghiepVuNX");
				}
			}
		}

		public int MaDinhKhoan
		{
			get
			{
				CanReadProperty("MaDinhKhoan", true);
				return _maDinhKhoan;
			}
			set
			{
				CanWriteProperty("MaDinhKhoan", true);
				if (!_maDinhKhoan.Equals(value))
				{
					_maDinhKhoan = value;
					PropertyHasChanged("MaDinhKhoan");
				}
			}
		}

		public byte MaTinhTrang
		{
			get
			{
				CanReadProperty("MaTinhTrang", true);
				return _maTinhTrang;
			}
			set
			{
				CanWriteProperty("MaTinhTrang", true);
				if (!_maTinhTrang.Equals(value))
				{
					_maTinhTrang = value;
					PropertyHasChanged("MaTinhTrang");
				}
			}
		}

		public byte QuyTrinh
		{
			get
			{
				CanReadProperty("QuyTrinh", true);
				return _quyTrinh;
			}
			set
			{
				CanWriteProperty("QuyTrinh", true);
				if (!_quyTrinh.Equals(value))
				{
					_quyTrinh = value;
					PropertyHasChanged("QuyTrinh");
				}
			}
		}

		public string TongSoTienString
		{
			get
			{
				CanReadProperty("TongSoTienString", true);
				return _tongSoTienString;
			}
			set
			{
				CanWriteProperty("TongSoTienString", true);
				if (value == null) value = string.Empty;
				if (!_tongSoTienString.Equals(value))
				{
					_tongSoTienString = value;
					PropertyHasChanged("TongSoTienString");
				}
			}
		}

		public bool GhiSoCai
		{
			get
			{
				CanReadProperty("GhiSoCai", true);
				return _ghiSoCai;
			}
			set
			{
				CanWriteProperty("GhiSoCai", true);
				if (!_ghiSoCai.Equals(value))
				{
					_ghiSoCai = value;
					PropertyHasChanged("GhiSoCai");
				}
			}
		}

		public long MaPhieuXuatNau
		{
			get
			{
				CanReadProperty("MaPhieuXuatNau", true);
				return _maPhieuXuatNau;
			}
			set
			{
				CanWriteProperty("MaPhieuXuatNau", true);
				if (!_maPhieuXuatNau.Equals(value))
				{
					_maPhieuXuatNau = value;
					PropertyHasChanged("MaPhieuXuatNau");
				}
			}
		}

		public decimal ChiPhiVanChuyen
		{
			get
			{
				CanReadProperty("ChiPhiVanChuyen", true);
				return _chiPhiVanChuyen;
			}
			set
			{
				CanWriteProperty("ChiPhiVanChuyen", true);
				if (!_chiPhiVanChuyen.Equals(value))
				{
					_chiPhiVanChuyen = value;
					PropertyHasChanged("ChiPhiVanChuyen");
				}
			}
		}

		public double PhanTramChietKhauHD
		{
			get
			{
				CanReadProperty("PhanTramChietKhauHD", true);
				return _phanTramChietKhauHD;
			}
			set
			{
				CanWriteProperty("PhanTramChietKhauHD", true);
				if (!_phanTramChietKhauHD.Equals(value))
				{
					_phanTramChietKhauHD = value;
					PropertyHasChanged("PhanTramChietKhauHD");
				}
			}
		}

		public decimal SoTienChietKhauHD
		{
			get
			{
				CanReadProperty("SoTienChietKhauHD", true);
				return _soTienChietKhauHD;
			}
			set
			{
				CanWriteProperty("SoTienChietKhauHD", true);
				if (!_soTienChietKhauHD.Equals(value))
				{
					_soTienChietKhauHD = value;
					PropertyHasChanged("SoTienChietKhauHD");
				}
			}
		}

		public byte LoaiUuDai
		{
			get
			{
				CanReadProperty("LoaiUuDai", true);
				return _loaiUuDai;
			}
			set
			{
				CanWriteProperty("LoaiUuDai", true);
				if (!_loaiUuDai.Equals(value))
				{
					_loaiUuDai = value;
					PropertyHasChanged("LoaiUuDai");
				}
			}
		}

		public decimal SoTienDaThanhToan
		{
			get
			{
				CanReadProperty("SoTienDaThanhToan", true);
				return _soTienDaThanhToan;
			}
			set
			{
				CanWriteProperty("SoTienDaThanhToan", true);
				if (!_soTienDaThanhToan.Equals(value))
				{
					_soTienDaThanhToan = value;
                    _soTienConLai = _giaTriHoaDon - _soTienDaThanhToan;
					PropertyHasChanged("SoTienDaThanhToan");
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

		public byte TrangThai
		{
			get
			{
				CanReadProperty("TrangThai", true);
				return _trangThai;
			}
			set
			{
				CanWriteProperty("TrangThai", true);
				if (!_trangThai.Equals(value))
				{
					_trangThai = value;
					PropertyHasChanged("TrangThai");
				}
			}
		}

        public bool Check
        {
            get
            {
                CanReadProperty("Check", true);
                return _check;
            }
            set
            {
                CanWriteProperty("Check", true);
                if (!_check.Equals(value))
                {
                    _check = value;
                    PropertyHasChanged("Check");
                }
            }
        }

        public decimal SoTienTucThoi
        {
            get
            {
                CanReadProperty("SoTienTucThoi", true);
                return _soTienTucThoi;
            }
            set
            {
                CanWriteProperty("SoTienTucThoi", true);
                if (!_soTienTucThoi.Equals(value))
                {
                    _soTienTucThoi = value;
                    PropertyHasChanged("SoTienTucThoi");
                }
            }
        }

		protected override object GetIdValue()
		{
			return _maPhieuNhapXuat;
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
			// SoPhieu
			//
            //ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("SoPhieu", 20));
            ////
            //// NgayHT
            ////
            //ValidationRules.AddRule(CommonRules.StringRequired, "NgayHTString");
            ////
            //// DienGiai
            ////
            //ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("DienGiai", 500));
            ////
            //// TongSoTienString
            ////
            //ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("TongSoTienString", 1024));
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
			//TODO: Define authorization rules in DSPhieuNhapXuat
			//AuthorizationRules.AllowRead("MaPhieuNhapXuat", "DSPhieuNhapXuatReadGroup");
			//AuthorizationRules.AllowRead("SoPhieu", "DSPhieuNhapXuatReadGroup");
			//AuthorizationRules.AllowRead("Loai", "DSPhieuNhapXuatReadGroup");
			//AuthorizationRules.AllowRead("LaNhap", "DSPhieuNhapXuatReadGroup");
			//AuthorizationRules.AllowRead("NgayHT", "DSPhieuNhapXuatReadGroup");
			//AuthorizationRules.AllowRead("NgayHTString", "DSPhieuNhapXuatReadGroup");
			//AuthorizationRules.AllowRead("NgayNX", "DSPhieuNhapXuatReadGroup");
			//AuthorizationRules.AllowRead("NgayNXString", "DSPhieuNhapXuatReadGroup");
			//AuthorizationRules.AllowRead("MaNguoiLap", "DSPhieuNhapXuatReadGroup");
			//AuthorizationRules.AllowRead("MaKho", "DSPhieuNhapXuatReadGroup");
			//AuthorizationRules.AllowRead("MaDoiTac", "DSPhieuNhapXuatReadGroup");
			//AuthorizationRules.AllowRead("MaKhoDoiTac", "DSPhieuNhapXuatReadGroup");
			//AuthorizationRules.AllowRead("MaNhanCong", "DSPhieuNhapXuatReadGroup");
			//AuthorizationRules.AllowRead("TuoiVang", "DSPhieuNhapXuatReadGroup");
			//AuthorizationRules.AllowRead("GiaTriHoaDon", "DSPhieuNhapXuatReadGroup");
			//AuthorizationRules.AllowRead("GiaTriKho", "DSPhieuNhapXuatReadGroup");
			//AuthorizationRules.AllowRead("DienGiai", "DSPhieuNhapXuatReadGroup");
			//AuthorizationRules.AllowRead("MaNghiepVuNX", "DSPhieuNhapXuatReadGroup");
			//AuthorizationRules.AllowRead("MaDinhKhoan", "DSPhieuNhapXuatReadGroup");
			//AuthorizationRules.AllowRead("MaTinhTrang", "DSPhieuNhapXuatReadGroup");
			//AuthorizationRules.AllowRead("QuyTrinh", "DSPhieuNhapXuatReadGroup");
			//AuthorizationRules.AllowRead("TongSoTienString", "DSPhieuNhapXuatReadGroup");
			//AuthorizationRules.AllowRead("GhiSoCai", "DSPhieuNhapXuatReadGroup");
			//AuthorizationRules.AllowRead("MaPhieuXuatNau", "DSPhieuNhapXuatReadGroup");
			//AuthorizationRules.AllowRead("ChiPhiVanChuyen", "DSPhieuNhapXuatReadGroup");
			//AuthorizationRules.AllowRead("PhanTramChietKhauHD", "DSPhieuNhapXuatReadGroup");
			//AuthorizationRules.AllowRead("SoTienChietKhauHD", "DSPhieuNhapXuatReadGroup");
			//AuthorizationRules.AllowRead("LoaiUuDai", "DSPhieuNhapXuatReadGroup");
			//AuthorizationRules.AllowRead("SoTienDaThanhToan", "DSPhieuNhapXuatReadGroup");
			//AuthorizationRules.AllowRead("SoTienConLai", "DSPhieuNhapXuatReadGroup");
			//AuthorizationRules.AllowRead("TrangThai", "DSPhieuNhapXuatReadGroup");

			//AuthorizationRules.AllowWrite("SoPhieu", "DSPhieuNhapXuatWriteGroup");
			//AuthorizationRules.AllowWrite("Loai", "DSPhieuNhapXuatWriteGroup");
			//AuthorizationRules.AllowWrite("LaNhap", "DSPhieuNhapXuatWriteGroup");
			//AuthorizationRules.AllowWrite("NgayHTString", "DSPhieuNhapXuatWriteGroup");
			//AuthorizationRules.AllowWrite("NgayNXString", "DSPhieuNhapXuatWriteGroup");
			//AuthorizationRules.AllowWrite("MaNguoiLap", "DSPhieuNhapXuatWriteGroup");
			//AuthorizationRules.AllowWrite("MaKho", "DSPhieuNhapXuatWriteGroup");
			//AuthorizationRules.AllowWrite("MaDoiTac", "DSPhieuNhapXuatWriteGroup");
			//AuthorizationRules.AllowWrite("MaKhoDoiTac", "DSPhieuNhapXuatWriteGroup");
			//AuthorizationRules.AllowWrite("MaNhanCong", "DSPhieuNhapXuatWriteGroup");
			//AuthorizationRules.AllowWrite("TuoiVang", "DSPhieuNhapXuatWriteGroup");
			//AuthorizationRules.AllowWrite("GiaTriHoaDon", "DSPhieuNhapXuatWriteGroup");
			//AuthorizationRules.AllowWrite("GiaTriKho", "DSPhieuNhapXuatWriteGroup");
			//AuthorizationRules.AllowWrite("DienGiai", "DSPhieuNhapXuatWriteGroup");
			//AuthorizationRules.AllowWrite("MaNghiepVuNX", "DSPhieuNhapXuatWriteGroup");
			//AuthorizationRules.AllowWrite("MaDinhKhoan", "DSPhieuNhapXuatWriteGroup");
			//AuthorizationRules.AllowWrite("MaTinhTrang", "DSPhieuNhapXuatWriteGroup");
			//AuthorizationRules.AllowWrite("QuyTrinh", "DSPhieuNhapXuatWriteGroup");
			//AuthorizationRules.AllowWrite("TongSoTienString", "DSPhieuNhapXuatWriteGroup");
			//AuthorizationRules.AllowWrite("GhiSoCai", "DSPhieuNhapXuatWriteGroup");
			//AuthorizationRules.AllowWrite("MaPhieuXuatNau", "DSPhieuNhapXuatWriteGroup");
			//AuthorizationRules.AllowWrite("ChiPhiVanChuyen", "DSPhieuNhapXuatWriteGroup");
			//AuthorizationRules.AllowWrite("PhanTramChietKhauHD", "DSPhieuNhapXuatWriteGroup");
			//AuthorizationRules.AllowWrite("SoTienChietKhauHD", "DSPhieuNhapXuatWriteGroup");
			//AuthorizationRules.AllowWrite("LoaiUuDai", "DSPhieuNhapXuatWriteGroup");
			//AuthorizationRules.AllowWrite("SoTienDaThanhToan", "DSPhieuNhapXuatWriteGroup");
			//AuthorizationRules.AllowWrite("SoTienConLai", "DSPhieuNhapXuatWriteGroup");
			//AuthorizationRules.AllowWrite("TrangThai", "DSPhieuNhapXuatWriteGroup");
		}


		public static bool CanGetObject()
		{
			//TODO: Define CanGetObject permission in DSPhieuNhapXuat
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("DSPhieuNhapXuatViewGroup"))
			//	return true;
			//return false;
		}

		public static bool CanAddObject()
		{
			//TODO: Define CanAddObject permission in DSPhieuNhapXuat
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("DSPhieuNhapXuatAddGroup"))
			//	return true;
			//return false;
		}

		public static bool CanEditObject()
		{
			//TODO: Define CanEditObject permission in DSPhieuNhapXuat
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("DSPhieuNhapXuatEditGroup"))
			//	return true;
			//return false;
		}

		public static bool CanDeleteObject()
		{
			//TODO: Define CanDeleteObject permission in DSPhieuNhapXuat
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("DSPhieuNhapXuatDeleteGroup"))
			//	return true;
			//return false;
		}
		#endregion //Authorization Rules

		#region Factory Methods
		private DSPhieuNhapXuat()
		{ /* require use of factory method */ }

		public static DSPhieuNhapXuat NewDSPhieuNhapXuat()
		{
			if (!CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a DSPhieuNhapXuat");
			return DataPortal.Create<DSPhieuNhapXuat>();
		}

		public static DSPhieuNhapXuat GetDSPhieuNhapXuat(long maPhieuNhapXuat)
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException("User not authorized to view a DSPhieuNhapXuat");
			return DataPortal.Fetch<DSPhieuNhapXuat>(new Criteria(maPhieuNhapXuat));
		}

		public static void DeleteDSPhieuNhapXuat(long maPhieuNhapXuat)
		{
			if (!CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a DSPhieuNhapXuat");
			DataPortal.Delete(new Criteria(maPhieuNhapXuat));
		}

		public override DSPhieuNhapXuat Save()
		{
			if (IsDeleted && !CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a DSPhieuNhapXuat");
			else if (IsNew && !CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a DSPhieuNhapXuat");
			else if (!CanEditObject())
				throw new System.Security.SecurityException("User not authorized to update a DSPhieuNhapXuat");

			return base.Save();
		}

		#endregion //Factory Methods

		#region Child Factory Methods
		internal static DSPhieuNhapXuat NewDSPhieuNhapXuatChild()
		{
			DSPhieuNhapXuat child = new DSPhieuNhapXuat();
			child.ValidationRules.CheckRules();
			child.MarkAsChild();
			return child;
		}

		internal static DSPhieuNhapXuat GetDSPhieuNhapXuat(SafeDataReader dr)
		{
			DSPhieuNhapXuat child =  new DSPhieuNhapXuat();
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
			public long MaPhieuNhapXuat;

			public Criteria(long maPhieuNhapXuat)
			{
				this.MaPhieuNhapXuat = maPhieuNhapXuat;
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
                cm.CommandText = "spd_LayPhieuNhap";

				cm.Parameters.AddWithValue("@MaPhieuNhap", criteria.MaPhieuNhapXuat);

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
		}

		#endregion //Data Access - Fetch

		#region Data Access - Insert
		protected override void DataPortal_Insert()
		{
			using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
			{
				cn.Open();

				ExecuteInsert(cn, null);

				//update child object(s)
				UpdateChildren(cn);
			}//using

		}

		#endregion //Data Access - Insert

		#region Data Access - Delete
		protected override void DataPortal_DeleteSelf()
		{
			DataPortal_Delete(new Criteria(_maPhieuNhapXuat));
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
				cm.CommandText = "DeleteDSPhieuNhapXuat";

				cm.Parameters.AddWithValue("@MaPhieuNhapXuat", criteria.MaPhieuNhapXuat);

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
			_maPhieuNhapXuat = dr.GetInt64("MaPhieuNhapXuat");
			_soPhieu = dr.GetString("SoPhieu");
			_loai = dr.GetInt16("Loai");
			_laNhap = dr.GetBoolean("LaNhap");
			_ngayHT = dr.GetSmartDate("NgayHT", _ngayHT.EmptyIsMin);
			_ngayNX = dr.GetSmartDate("NgayNX", _ngayNX.EmptyIsMin);
			_maNguoiLap = dr.GetInt64("MaNguoiLap");
			_maKho = dr.GetInt32("MaKho");
			_maDoiTac = dr.GetInt64("MaDoiTac");
			_maKhoDoiTac = dr.GetInt32("MaKhoDoiTac");
			_maNhanCong = dr.GetInt64("MaNhanCong");
			_tuoiVang = dr.GetDecimal("TuoiVang");
			_giaTriHoaDon = dr.GetDecimal("GiaTriHoaDon");
			_giaTriKho = dr.GetDecimal("GiaTriKho");
			_dienGiai = dr.GetString("DienGiai");
			_maNghiepVuNX = dr.GetInt32("MaNghiepVuNX");
			_maDinhKhoan = dr.GetInt32("MaDinhKhoan");
			_maTinhTrang = dr.GetByte("MaTinhTrang");
			_quyTrinh = dr.GetByte("QuyTrinh");
			_tongSoTienString = dr.GetString("TongSoTienString");
			_ghiSoCai = dr.GetBoolean("GhiSoCai");
			_maPhieuXuatNau = dr.GetInt64("MaPhieuXuatNau");
			_chiPhiVanChuyen = dr.GetDecimal("ChiPhiVanChuyen");
			_phanTramChietKhauHD = dr.GetDouble("PhanTramChietKhauHD");
			_soTienChietKhauHD = dr.GetDecimal("SoTienChietKhauHD");
			_loaiUuDai = dr.GetByte("LoaiUuDai");
			_soTienDaThanhToan = dr.GetDecimal("SoTienDaThanhToan");
			_soTienConLai = dr.GetDecimal("SoTienConLai");
			_trangThai = dr.GetByte("TrangThai");
            //if (ChungTu_HoaDon.GetChungTu_HoaDon_MaPhieuNhapXuat(dr.GetInt64("MaPhieuNhapXuat")) != null)
            //    _ChungTu_HoaDon = ChungTu_HoaDon.GetChungTu_HoaDon_MaPhieuNhapXuat(dr.GetInt64("MaPhieuNhapXuat"));
		}

		private void FetchChildren(SafeDataReader dr)
		{
		}
		#endregion //Data Access - Fetch

		#region Data Access - Insert
        
		internal void Insert(SqlConnection cn, DSPhieuNhapXuatList parent)
		{
			if (!IsDirty) return;

			ExecuteInsert(cn, parent);
			MarkOld();

			//update child object(s)
			UpdateChildren(cn);
		}

		private void ExecuteInsert(SqlConnection cn, DSPhieuNhapXuatList parent)
		{
			using (SqlCommand cm = cn.CreateCommand())
			{
				cm.CommandType = CommandType.StoredProcedure;
				cm.CommandText = "AddDSPhieuNhapXuat";

				AddInsertParameters(cm, parent);

				cm.ExecuteNonQuery();

				_maPhieuNhapXuat = (long)cm.Parameters["@NewMaPhieuNhapXuat"].Value;
			}//using
		}

		private void AddInsertParameters(SqlCommand cm, DSPhieuNhapXuatList parent)
		{
			//TODO: if parent use identity key, fix fk member with value from parent
			if (_soPhieu.Length > 0)
				cm.Parameters.AddWithValue("@SoPhieu", _soPhieu);
			else
				cm.Parameters.AddWithValue("@SoPhieu", DBNull.Value);
			if (_loai != 0)
				cm.Parameters.AddWithValue("@Loai", _loai);
			else
				cm.Parameters.AddWithValue("@Loai", DBNull.Value);
			if (_laNhap != false)
				cm.Parameters.AddWithValue("@LaNhap", _laNhap);
			else
				cm.Parameters.AddWithValue("@LaNhap", DBNull.Value);
			cm.Parameters.AddWithValue("@NgayHT", _ngayHT.DBValue);
			cm.Parameters.AddWithValue("@NgayNX", _ngayNX.DBValue);
			if (_maNguoiLap != 0)
				cm.Parameters.AddWithValue("@MaNguoiLap", _maNguoiLap);
			else
				cm.Parameters.AddWithValue("@MaNguoiLap", DBNull.Value);
			cm.Parameters.AddWithValue("@MaKho", _maKho);
			if (_maDoiTac != 0)
				cm.Parameters.AddWithValue("@MaDoiTac", _maDoiTac);
			else
				cm.Parameters.AddWithValue("@MaDoiTac", DBNull.Value);
			if (_maKhoDoiTac != 0)
				cm.Parameters.AddWithValue("@MaKhoDoiTac", _maKhoDoiTac);
			else
				cm.Parameters.AddWithValue("@MaKhoDoiTac", DBNull.Value);
			if (_maNhanCong != 0)
				cm.Parameters.AddWithValue("@MaNhanCong", _maNhanCong);
			else
				cm.Parameters.AddWithValue("@MaNhanCong", DBNull.Value);
			if (_tuoiVang != 0)
				cm.Parameters.AddWithValue("@TuoiVang", _tuoiVang);
			else
				cm.Parameters.AddWithValue("@TuoiVang", DBNull.Value);
			if (_giaTriHoaDon != 0)
				cm.Parameters.AddWithValue("@GiaTriHoaDon", _giaTriHoaDon);
			else
				cm.Parameters.AddWithValue("@GiaTriHoaDon", DBNull.Value);
			if (_giaTriKho != 0)
				cm.Parameters.AddWithValue("@GiaTriKho", _giaTriKho);
			else
				cm.Parameters.AddWithValue("@GiaTriKho", DBNull.Value);
			if (_dienGiai.Length > 0)
				cm.Parameters.AddWithValue("@DienGiai", _dienGiai);
			else
				cm.Parameters.AddWithValue("@DienGiai", DBNull.Value);
			if (_maNghiepVuNX != 0)
				cm.Parameters.AddWithValue("@MaNghiepVuNX", _maNghiepVuNX);
			else
				cm.Parameters.AddWithValue("@MaNghiepVuNX", DBNull.Value);
			if (_maDinhKhoan != 0)
				cm.Parameters.AddWithValue("@MaDinhKhoan", _maDinhKhoan);
			else
				cm.Parameters.AddWithValue("@MaDinhKhoan", DBNull.Value);
			cm.Parameters.AddWithValue("@MaTinhTrang", _maTinhTrang);
			cm.Parameters.AddWithValue("@QuyTrinh", _quyTrinh);
			if (_tongSoTienString.Length > 0)
				cm.Parameters.AddWithValue("@TongSoTienString", _tongSoTienString);
			else
				cm.Parameters.AddWithValue("@TongSoTienString", DBNull.Value);
			if (_ghiSoCai != false)
				cm.Parameters.AddWithValue("@GhiSoCai", _ghiSoCai);
			else
				cm.Parameters.AddWithValue("@GhiSoCai", DBNull.Value);
			if (_maPhieuXuatNau != 0)
				cm.Parameters.AddWithValue("@MaPhieuXuatNau", _maPhieuXuatNau);
			else
				cm.Parameters.AddWithValue("@MaPhieuXuatNau", DBNull.Value);
			if (_chiPhiVanChuyen != 0)
				cm.Parameters.AddWithValue("@ChiPhiVanChuyen", _chiPhiVanChuyen);
			else
				cm.Parameters.AddWithValue("@ChiPhiVanChuyen", DBNull.Value);
			if (_phanTramChietKhauHD != 0)
				cm.Parameters.AddWithValue("@PhanTramChietKhauHD", _phanTramChietKhauHD);
			else
				cm.Parameters.AddWithValue("@PhanTramChietKhauHD", DBNull.Value);
			if (_soTienChietKhauHD != 0)
				cm.Parameters.AddWithValue("@SoTienChietKhauHD", _soTienChietKhauHD);
			else
				cm.Parameters.AddWithValue("@SoTienChietKhauHD", DBNull.Value);
			if (_loaiUuDai != 0)
				cm.Parameters.AddWithValue("@LoaiUuDai", _loaiUuDai);
			else
				cm.Parameters.AddWithValue("@LoaiUuDai", DBNull.Value);
			if (_soTienDaThanhToan != 0)
				cm.Parameters.AddWithValue("@SoTienDaThanhToan", _soTienDaThanhToan);
			else
				cm.Parameters.AddWithValue("@SoTienDaThanhToan", DBNull.Value);
			if (_soTienConLai != 0)
				cm.Parameters.AddWithValue("@SoTienConLai", _soTienConLai);
			else
				cm.Parameters.AddWithValue("@SoTienConLai", DBNull.Value);
			if (_trangThai != 0)
				cm.Parameters.AddWithValue("@TrangThai", _trangThai);
			else
				cm.Parameters.AddWithValue("@TrangThai", DBNull.Value);
			cm.Parameters.AddWithValue("@NewMaPhieuNhapXuat", _maPhieuNhapXuat);
			cm.Parameters["@NewMaPhieuNhapXuat"].Direction = ParameterDirection.Output;
		}
       
        #endregion //Data Access - Insert

        #region Data Access - Update
        #region Them Vao
        internal void Update(SqlTransaction tr, DSPhieuNhapXuatList parent)
        {
            ExecuteUpdate(tr, parent);
            MarkOld();

            //update child object(s)
            //UpdateChildren(tr);
        }

        private void ExecuteUpdate(SqlTransaction tr, DSPhieuNhapXuatList parent)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_UpdatetblPhieuNhapXuat_Trang";

                AddUpdateParameters(cm);
                cm.ExecuteNonQuery();
            }//using
        }

        private void AddUpdateParameters(SqlCommand cm)
        {
            cm.Parameters.AddWithValue("@MaPhieuNhapXuat", _maPhieuNhapXuat);
            cm.Parameters.AddWithValue("@GiaTriHoaDon", _giaTriHoaDon);
            cm.Parameters.AddWithValue("@SoTienDaThanhToan", _soTienDaThanhToan);
            cm.Parameters.AddWithValue("@SoTienConLai", _soTienConLai);
            cm.Parameters.AddWithValue("@TrangThai", _trangThai);
        }

        #endregion

		private void UpdateChildren(SqlConnection cn)
		{
		}
		#endregion //Data Access - Update

		#region Data Access - Delete
		internal void DeleteSelf(SqlConnection cn)
		{
			if (!IsDirty) return;
			if (IsNew) return;

			ExecuteDelete(cn, new Criteria(_maPhieuNhapXuat));
			MarkNew();
		}
		#endregion //Data Access - Delete
		#endregion //Data Access
	}
}
