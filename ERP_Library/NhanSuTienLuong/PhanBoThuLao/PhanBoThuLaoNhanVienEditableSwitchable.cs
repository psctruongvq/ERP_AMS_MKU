using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;
namespace ERP_Library
{ 
	[Serializable()] 
	public class PhanBoThuLaoNhanVien : Csla.BusinessBase<PhanBoThuLaoNhanVien>
	{
		#region Business Properties and Methods

		//declare members
		private int _maPhanBoThuLaoChuongTrinh = 0;
		private int _maChuongTrinh = 0;
		private string _tenChuongTrinh = string.Empty;
		private long _maNhanVien = 0;
		private int _maKyTinhLuong = 0;
		private decimal _soTien = 0;
        private SmartDate _ngayLap = new SmartDate(DateTime.Today);
		private int _nguoiLap = 0;
		private string _maPhieuChi = string.Empty;
		private string _dienGiai = string.Empty;
		private byte _phanTramThue = 0;
		private decimal _tienThue = 0;
		private decimal _soTienConLai = 0;
		private bool _tinhDangPhi = false;
		private long _maPhanBoThuLao = 0;
		private long _maChiTietPhanBoThuLao = 0;
		private bool _thanhToan = false;
		private bool _thucNhan = false;
		private string _maQLNhanVien = string.Empty;
		private string _tenNhanVien = string.Empty;
		private int _maBoPhan = 0;
		private string _maQLBoPhan = string.Empty;
		private string _tenBoPhan = string.Empty;
		private int _maChucVu = 0;
		private string _tenChucVu = string.Empty;
		private bool _khongTinhThuNhap = false;
		private bool _duocNhapHo = false;
		private int _maGiayXacNhan = 0;
		private int _maChiTietGiayXacNhan = 0;
		private int _maCongViec = 0;

		[System.ComponentModel.DataObjectField(true, true)]
		public int MaPhanBoThuLaoChuongTrinh
		{
			get
			{
				CanReadProperty("MaPhanBoThuLaoChuongTrinh", true);
				return _maPhanBoThuLaoChuongTrinh;
			}
		}

		public int MaChuongTrinh
		{
			get
			{
				CanReadProperty("MaChuongTrinh", true);
				return _maChuongTrinh;
			}
			set
			{
				CanWriteProperty("MaChuongTrinh", true);
				if (!_maChuongTrinh.Equals(value))
				{
					_maChuongTrinh = value;
					PropertyHasChanged("MaChuongTrinh");
				}
			}
		}

		public string TenChuongTrinh
		{
			get
			{
				CanReadProperty("TenChuongTrinh", true);
				return _tenChuongTrinh;
			}
			set
			{
				CanWriteProperty("TenChuongTrinh", true);
				if (value == null) value = string.Empty;
				if (!_tenChuongTrinh.Equals(value))
				{
					_tenChuongTrinh = value;
					PropertyHasChanged("TenChuongTrinh");
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
                    _soTienConLai = _soTien;
					PropertyHasChanged("SoTien");
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
                CanWriteProperty("NgayLap", true);
                if (!_ngayLap.Equals(value))
                {
                    _ngayLap = new SmartDate(value);
                    PropertyHasChanged("NgayLap");
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

		public string MaPhieuChi
		{
			get
			{
				CanReadProperty("MaPhieuChi", true);
				return _maPhieuChi;
			}
			set
			{
				CanWriteProperty("MaPhieuChi", true);
				if (value == null) value = string.Empty;
				if (!_maPhieuChi.Equals(value))
				{
					_maPhieuChi = value;
					PropertyHasChanged("MaPhieuChi");
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

		public byte PhanTramThue
		{
			get
			{
				CanReadProperty("PhanTramThue", true);
				return _phanTramThue;
			}
			set
			{
				CanWriteProperty("PhanTramThue", true);
				if (!_phanTramThue.Equals(value))
				{
					_phanTramThue = value;
					PropertyHasChanged("PhanTramThue");
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

		public bool TinhDangPhi
		{
			get
			{
				CanReadProperty("TinhDangPhi", true);
				return _tinhDangPhi;
			}
			set
			{
				CanWriteProperty("TinhDangPhi", true);
				if (!_tinhDangPhi.Equals(value))
				{
					_tinhDangPhi = value;
					PropertyHasChanged("TinhDangPhi");
				}
			}
		}

		public long MaPhanBoThuLao
		{
			get
			{
				CanReadProperty("MaPhanBoThuLao", true);
				return _maPhanBoThuLao;
			}
			set
			{
				CanWriteProperty("MaPhanBoThuLao", true);
				if (!_maPhanBoThuLao.Equals(value))
				{
					_maPhanBoThuLao = value;
					PropertyHasChanged("MaPhanBoThuLao");
				}
			}
		}

		public long MaChiTietPhanBoThuLao
		{
			get
			{
				CanReadProperty("MaChiTietPhanBoThuLao", true);
				return _maChiTietPhanBoThuLao;
			}
			set
			{
				CanWriteProperty("MaChiTietPhanBoThuLao", true);
				if (!_maChiTietPhanBoThuLao.Equals(value))
				{
					_maChiTietPhanBoThuLao = value;
					PropertyHasChanged("MaChiTietPhanBoThuLao");
				}
			}
		}

		public bool ThanhToan
		{
			get
			{
				CanReadProperty("ThanhToan", true);
				return _thanhToan;
			}
			set
			{
				CanWriteProperty("ThanhToan", true);
				if (!_thanhToan.Equals(value))
				{
					_thanhToan = value;
					PropertyHasChanged("ThanhToan");
				}
			}
		}

		public bool ThucNhan
		{
			get
			{
				CanReadProperty("ThucNhan", true);
				return _thucNhan;
			}
			set
			{
				CanWriteProperty("ThucNhan", true);
				if (!_thucNhan.Equals(value))
				{
					_thucNhan = value;
					PropertyHasChanged("ThucNhan");
				}
			}
		}

		public string MaQLNhanVien
		{
			get
			{
				CanReadProperty("MaQLNhanVien", true);
				return _maQLNhanVien;
			}
			set
			{
				CanWriteProperty("MaQLNhanVien", true);
				if (value == null) value = string.Empty;
				if (!_maQLNhanVien.Equals(value))
				{
					_maQLNhanVien = value;
					PropertyHasChanged("MaQLNhanVien");
				}
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
				CanWriteProperty("TenNhanVien", true);
				if (value == null) value = string.Empty;
				if (!_tenNhanVien.Equals(value))
				{
					_tenNhanVien = value;
					PropertyHasChanged("TenNhanVien");
				}
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

		public string MaQLBoPhan
		{
			get
			{
				CanReadProperty("MaQLBoPhan", true);
				return _maQLBoPhan;
			}
			set
			{
				CanWriteProperty("MaQLBoPhan", true);
				if (value == null) value = string.Empty;
				if (!_maQLBoPhan.Equals(value))
				{
					_maQLBoPhan = value;
					PropertyHasChanged("MaQLBoPhan");
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
			set
			{
				CanWriteProperty("TenBoPhan", true);
				if (value == null) value = string.Empty;
				if (!_tenBoPhan.Equals(value))
				{
					_tenBoPhan = value;
					PropertyHasChanged("TenBoPhan");
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

		public string TenChucVu
		{
			get
			{
				CanReadProperty("TenChucVu", true);
				return _tenChucVu;
			}
			set
			{
				CanWriteProperty("TenChucVu", true);
				if (value == null) value = string.Empty;
				if (!_tenChucVu.Equals(value))
				{
					_tenChucVu = value;
					PropertyHasChanged("TenChucVu");
				}
			}
		}

		public bool KhongTinhThuNhap
		{
			get
			{
				CanReadProperty("KhongTinhThuNhap", true);
				return _khongTinhThuNhap;
			}
			set
			{
				CanWriteProperty("KhongTinhThuNhap", true);
				if (!_khongTinhThuNhap.Equals(value))
				{
					_khongTinhThuNhap = value;
					PropertyHasChanged("KhongTinhThuNhap");
				}
			}
		}

		public bool DuocNhapHo
		{
			get
			{
				CanReadProperty("DuocNhapHo", true);
				return _duocNhapHo;
			}
			set
			{
				CanWriteProperty("DuocNhapHo", true);
				if (!_duocNhapHo.Equals(value))
				{
					_duocNhapHo = value;
					PropertyHasChanged("DuocNhapHo");
				}
			}
		}

		public int MaGiayXacNhan
		{
			get
			{
				CanReadProperty("MaGiayXacNhan", true);
				return _maGiayXacNhan;
			}
			set
			{
				CanWriteProperty("MaGiayXacNhan", true);
				if (!_maGiayXacNhan.Equals(value))
				{
					_maGiayXacNhan = value;
					PropertyHasChanged("MaGiayXacNhan");
				}
			}
		}

		public int MaChiTietGiayXacNhan
		{
			get
			{
				CanReadProperty("MaChiTietGiayXacNhan", true);
				return _maChiTietGiayXacNhan;
			}
			set
			{
				CanWriteProperty("MaChiTietGiayXacNhan", true);
				if (!_maChiTietGiayXacNhan.Equals(value))
				{
					_maChiTietGiayXacNhan = value;
					PropertyHasChanged("MaChiTietGiayXacNhan");
				}
			}
		}

		public int MaCongViec
		{
			get
			{
				CanReadProperty("MaCongViec", true);
				return _maCongViec;
			}
			set
			{
				CanWriteProperty("MaCongViec", true);
				if (!_maCongViec.Equals(value))
				{
					_maCongViec = value;
					PropertyHasChanged("MaCongViec");
				}
			}
		}
 
		protected override object GetIdValue()
		{
			return _maPhanBoThuLaoChuongTrinh;
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
			// MaPhieuChi
			//
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("MaPhieuChi", 50));
			//
			// MaQLNhanVien
			//
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("MaQLNhanVien", 50));
			//
			// TenNhanVien
			//
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("TenNhanVien", 500));
			//
			// MaQLBoPhan
			//
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("MaQLBoPhan", 50));
			//
			// TenBoPhan
			//
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("TenBoPhan", 500));
			//
			// TenChucVu
			//
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("TenChucVu", 50));
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
			//TODO: Define authorization rules in PhanBoThuLaoNhanVien
			//AuthorizationRules.AllowRead("MaPhanBoThuLaoChuongTrinh", "PhanBoThuLaoNhanVienReadGroup");
			//AuthorizationRules.AllowRead("MaChuongTrinh", "PhanBoThuLaoNhanVienReadGroup");
			//AuthorizationRules.AllowRead("TenChuongTrinh", "PhanBoThuLaoNhanVienReadGroup");
			//AuthorizationRules.AllowRead("MaNhanVien", "PhanBoThuLaoNhanVienReadGroup");
			//AuthorizationRules.AllowRead("MaKyTinhLuong", "PhanBoThuLaoNhanVienReadGroup");
			//AuthorizationRules.AllowRead("SoTien", "PhanBoThuLaoNhanVienReadGroup");
			//AuthorizationRules.AllowRead("NgayLap", "PhanBoThuLaoNhanVienReadGroup");
			//AuthorizationRules.AllowRead("NgayLapString", "PhanBoThuLaoNhanVienReadGroup");
			//AuthorizationRules.AllowRead("NguoiLap", "PhanBoThuLaoNhanVienReadGroup");
			//AuthorizationRules.AllowRead("MaPhieuChi", "PhanBoThuLaoNhanVienReadGroup");
			//AuthorizationRules.AllowRead("DienGiai", "PhanBoThuLaoNhanVienReadGroup");
			//AuthorizationRules.AllowRead("PhanTramThue", "PhanBoThuLaoNhanVienReadGroup");
			//AuthorizationRules.AllowRead("TienThue", "PhanBoThuLaoNhanVienReadGroup");
			//AuthorizationRules.AllowRead("SoTienConLai", "PhanBoThuLaoNhanVienReadGroup");
			//AuthorizationRules.AllowRead("TinhDangPhi", "PhanBoThuLaoNhanVienReadGroup");
			//AuthorizationRules.AllowRead("MaPhanBoThuLao", "PhanBoThuLaoNhanVienReadGroup");
			//AuthorizationRules.AllowRead("MaChiTietPhanBoThuLao", "PhanBoThuLaoNhanVienReadGroup");
			//AuthorizationRules.AllowRead("ThanhToan", "PhanBoThuLaoNhanVienReadGroup");
			//AuthorizationRules.AllowRead("ThucNhan", "PhanBoThuLaoNhanVienReadGroup");
			//AuthorizationRules.AllowRead("MaQLNhanVien", "PhanBoThuLaoNhanVienReadGroup");
			//AuthorizationRules.AllowRead("TenNhanVien", "PhanBoThuLaoNhanVienReadGroup");
			//AuthorizationRules.AllowRead("MaBoPhan", "PhanBoThuLaoNhanVienReadGroup");
			//AuthorizationRules.AllowRead("MaQLBoPhan", "PhanBoThuLaoNhanVienReadGroup");
			//AuthorizationRules.AllowRead("TenBoPhan", "PhanBoThuLaoNhanVienReadGroup");
			//AuthorizationRules.AllowRead("MaChucVu", "PhanBoThuLaoNhanVienReadGroup");
			//AuthorizationRules.AllowRead("TenChucVu", "PhanBoThuLaoNhanVienReadGroup");
			//AuthorizationRules.AllowRead("KhongTinhThuNhap", "PhanBoThuLaoNhanVienReadGroup");
			//AuthorizationRules.AllowRead("DuocNhapHo", "PhanBoThuLaoNhanVienReadGroup");
			//AuthorizationRules.AllowRead("MaGiayXacNhan", "PhanBoThuLaoNhanVienReadGroup");
			//AuthorizationRules.AllowRead("MaChiTietGiayXacNhan", "PhanBoThuLaoNhanVienReadGroup");
			//AuthorizationRules.AllowRead("MaCongViec", "PhanBoThuLaoNhanVienReadGroup");

			//AuthorizationRules.AllowWrite("MaChuongTrinh", "PhanBoThuLaoNhanVienWriteGroup");
			//AuthorizationRules.AllowWrite("TenChuongTrinh", "PhanBoThuLaoNhanVienWriteGroup");
			//AuthorizationRules.AllowWrite("MaNhanVien", "PhanBoThuLaoNhanVienWriteGroup");
			//AuthorizationRules.AllowWrite("MaKyTinhLuong", "PhanBoThuLaoNhanVienWriteGroup");
			//AuthorizationRules.AllowWrite("SoTien", "PhanBoThuLaoNhanVienWriteGroup");
			//AuthorizationRules.AllowWrite("NgayLapString", "PhanBoThuLaoNhanVienWriteGroup");
			//AuthorizationRules.AllowWrite("NguoiLap", "PhanBoThuLaoNhanVienWriteGroup");
			//AuthorizationRules.AllowWrite("MaPhieuChi", "PhanBoThuLaoNhanVienWriteGroup");
			//AuthorizationRules.AllowWrite("DienGiai", "PhanBoThuLaoNhanVienWriteGroup");
			//AuthorizationRules.AllowWrite("PhanTramThue", "PhanBoThuLaoNhanVienWriteGroup");
			//AuthorizationRules.AllowWrite("TienThue", "PhanBoThuLaoNhanVienWriteGroup");
			//AuthorizationRules.AllowWrite("SoTienConLai", "PhanBoThuLaoNhanVienWriteGroup");
			//AuthorizationRules.AllowWrite("TinhDangPhi", "PhanBoThuLaoNhanVienWriteGroup");
			//AuthorizationRules.AllowWrite("MaPhanBoThuLao", "PhanBoThuLaoNhanVienWriteGroup");
			//AuthorizationRules.AllowWrite("MaChiTietPhanBoThuLao", "PhanBoThuLaoNhanVienWriteGroup");
			//AuthorizationRules.AllowWrite("ThanhToan", "PhanBoThuLaoNhanVienWriteGroup");
			//AuthorizationRules.AllowWrite("ThucNhan", "PhanBoThuLaoNhanVienWriteGroup");
			//AuthorizationRules.AllowWrite("MaQLNhanVien", "PhanBoThuLaoNhanVienWriteGroup");
			//AuthorizationRules.AllowWrite("TenNhanVien", "PhanBoThuLaoNhanVienWriteGroup");
			//AuthorizationRules.AllowWrite("MaBoPhan", "PhanBoThuLaoNhanVienWriteGroup");
			//AuthorizationRules.AllowWrite("MaQLBoPhan", "PhanBoThuLaoNhanVienWriteGroup");
			//AuthorizationRules.AllowWrite("TenBoPhan", "PhanBoThuLaoNhanVienWriteGroup");
			//AuthorizationRules.AllowWrite("MaChucVu", "PhanBoThuLaoNhanVienWriteGroup");
			//AuthorizationRules.AllowWrite("TenChucVu", "PhanBoThuLaoNhanVienWriteGroup");
			//AuthorizationRules.AllowWrite("KhongTinhThuNhap", "PhanBoThuLaoNhanVienWriteGroup");
			//AuthorizationRules.AllowWrite("DuocNhapHo", "PhanBoThuLaoNhanVienWriteGroup");
			//AuthorizationRules.AllowWrite("MaGiayXacNhan", "PhanBoThuLaoNhanVienWriteGroup");
			//AuthorizationRules.AllowWrite("MaChiTietGiayXacNhan", "PhanBoThuLaoNhanVienWriteGroup");
			//AuthorizationRules.AllowWrite("MaCongViec", "PhanBoThuLaoNhanVienWriteGroup");
		}


		public static bool CanGetObject()
		{
			//TODO: Define CanGetObject permission in PhanBoThuLaoNhanVien
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("PhanBoThuLaoNhanVienViewGroup"))
			//	return true;
			//return false;
		}

		public static bool CanAddObject()
		{
			//TODO: Define CanAddObject permission in PhanBoThuLaoNhanVien
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("PhanBoThuLaoNhanVienAddGroup"))
			//	return true;
			//return false;
		}

		public static bool CanEditObject()
		{
			//TODO: Define CanEditObject permission in PhanBoThuLaoNhanVien
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("PhanBoThuLaoNhanVienEditGroup"))
			//	return true;
			//return false;
		}

		public static bool CanDeleteObject()
		{
			//TODO: Define CanDeleteObject permission in PhanBoThuLaoNhanVien
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("PhanBoThuLaoNhanVienDeleteGroup"))
			//	return true;
			//return false;
		}
		#endregion //Authorization Rules

		#region Factory Methods
		private PhanBoThuLaoNhanVien()
		{ /* require use of factory method */
            MarkAsChild();
        }

		public static PhanBoThuLaoNhanVien NewPhanBoThuLaoNhanVien()
		{
			if (!CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a PhanBoThuLaoNhanVien");
			return DataPortal.Create<PhanBoThuLaoNhanVien>();
		}

		public static PhanBoThuLaoNhanVien GetPhanBoThuLaoNhanVien(int maPhanBoThuLaoChuongTrinh)
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException("User not authorized to view a PhanBoThuLaoNhanVien");
			return DataPortal.Fetch<PhanBoThuLaoNhanVien>(new Criteria(maPhanBoThuLaoChuongTrinh));
		}

        public static PhanBoThuLaoNhanVien GetPhanBoThuLaoNhanVienByMaPhanBoThuLao(int maPhanBoThuLao, DateTime ngayLap)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a PhanBoThuLaoNhanVien");
            return DataPortal.Fetch<PhanBoThuLaoNhanVien>(new CriteriaByMaPhanBoThuLao(maPhanBoThuLao,ngayLap));
        }

		public static void DeletePhanBoThuLaoNhanVien(int maPhanBoThuLaoChuongTrinh)
		{
			if (!CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a PhanBoThuLaoNhanVien");
			DataPortal.Delete(new Criteria(maPhanBoThuLaoChuongTrinh));
		}

		public override PhanBoThuLaoNhanVien Save()
		{
			if (IsDeleted && !CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a PhanBoThuLaoNhanVien");
			else if (IsNew && !CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a PhanBoThuLaoNhanVien");
			else if (!CanEditObject())
				throw new System.Security.SecurityException("User not authorized to update a PhanBoThuLaoNhanVien");

			return base.Save();
		}

		#endregion //Factory Methods

		#region Child Factory Methods
		internal static PhanBoThuLaoNhanVien NewPhanBoThuLaoNhanVienChild()
		{
			PhanBoThuLaoNhanVien child = new PhanBoThuLaoNhanVien();
			child.ValidationRules.CheckRules();
			child.MarkAsChild();
			return child;
		}

		internal static PhanBoThuLaoNhanVien GetPhanBoThuLaoNhanVien(SafeDataReader dr)
		{
			PhanBoThuLaoNhanVien child =  new PhanBoThuLaoNhanVien();
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
			public int MaPhanBoThuLaoChuongTrinh;

			public Criteria(int maPhanBoThuLaoChuongTrinh)
			{
				this.MaPhanBoThuLaoChuongTrinh = maPhanBoThuLaoChuongTrinh;
			}
		}

        private class CriteriaByMaPhanBoThuLao
        {
            public int MaPhanBoThuLao;
            public DateTime NgayLap;

            public CriteriaByMaPhanBoThuLao(int maPhanBoThuLao,DateTime ngayLap)
            {
                this.MaPhanBoThuLao = maPhanBoThuLao;
                this.NgayLap = ngayLap;
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
                if (criteria is Criteria)
                {
                    cm.Transaction = tr;
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "Spd_SelecttblnsPhanBoThuLaoChuongTrinh";

                    cm.Parameters.AddWithValue("@MaPhanBoThuLaoChuongTrinh", ((Criteria)criteria).MaPhanBoThuLaoChuongTrinh);
                }

                if (criteria is CriteriaByMaPhanBoThuLao)
                {
                    cm.Transaction = tr;
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "Spd_SelecttblnsPhanBoThuLaoChuongTrinhByMaBoPhan";

                    cm.Parameters.AddWithValue("@MaPhanBoThuLao", ((CriteriaByMaPhanBoThuLao)criteria).MaPhanBoThuLao);
                    cm.Parameters.AddWithValue("@NgayLap", ((CriteriaByMaPhanBoThuLao)criteria).NgayLap);
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
			DataPortal_Delete(new Criteria(_maPhanBoThuLaoChuongTrinh));
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
                cm.CommandText = "Spd_DeletetblnsPhanBoThuLaoChuongTrinh";

				cm.Parameters.AddWithValue("@MaPhanBoThuLaoChuongTrinh", criteria.MaPhanBoThuLaoChuongTrinh);

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
			_maPhanBoThuLaoChuongTrinh = dr.GetInt32("MaPhanBoThuLaoChuongTrinh");
			_maChuongTrinh = dr.GetInt32("MaChuongTrinh");
			_tenChuongTrinh = dr.GetString("TenChuongTrinh");
			_maNhanVien = dr.GetInt64("MaNhanVien");
			_maKyTinhLuong = dr.GetInt32("MaKyTinhLuong");
			_soTien = dr.GetDecimal("SoTien");
			_ngayLap = dr.GetSmartDate("NgayLap", _ngayLap.EmptyIsMin);
			_nguoiLap = dr.GetInt32("NguoiLap");
			_maPhieuChi = dr.GetString("MaPhieuChi");
			_dienGiai = dr.GetString("DienGiai");
			_phanTramThue = dr.GetByte("PhanTramThue");
			_tienThue = dr.GetDecimal("TienThue");
			_soTienConLai = dr.GetDecimal("SoTienConLai");
			_tinhDangPhi = dr.GetBoolean("TinhDangPhi");
			_maPhanBoThuLao = dr.GetInt64("MaPhanBoThuLao");
			_maChiTietPhanBoThuLao = dr.GetInt64("MaChiTietPhanBoThuLao");
			_thanhToan = dr.GetBoolean("ThanhToan");
			_thucNhan = dr.GetBoolean("ThucNhan");
			_maQLNhanVien = dr.GetString("MaQLNhanVien");
			_tenNhanVien = dr.GetString("TenNhanVien");
			_maBoPhan = dr.GetInt32("MaBoPhan");
			_maQLBoPhan = dr.GetString("MaQLBoPhan");
			_tenBoPhan = dr.GetString("TenBoPhan");
			_maChucVu = dr.GetInt32("MaChucVu");
			_tenChucVu = dr.GetString("TenChucVu");
			_khongTinhThuNhap = dr.GetBoolean("KhongTinhThuNhap");
			_duocNhapHo = dr.GetBoolean("DuocNhapHo");
			_maGiayXacNhan = dr.GetInt32("MaGiayXacNhan");
			_maChiTietGiayXacNhan = dr.GetInt32("MaChiTietGiayXacNhan");
			_maCongViec = dr.GetInt32("MaCongViec");
		}

		private void FetchChildren(SafeDataReader dr)
		{
		}
		#endregion //Data Access - Fetch

		#region Data Access - Insert
		internal void Insert(SqlTransaction tr, PhanBoThuLaoNhanVienList parent)
		{
			if (!IsDirty) return;

			ExecuteInsert(tr, parent);
			MarkOld();

			//update child object(s)
			UpdateChildren(tr);
		}

		private void ExecuteInsert(SqlTransaction tr, PhanBoThuLaoNhanVienList parent)
		{
			using (SqlCommand cm = tr.Connection.CreateCommand())
			{
				cm.Transaction = tr;
				cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "Spd_InserttblnsPhanBoThuLaoChuongTrinh";

				AddInsertParameters(cm, parent);

				cm.ExecuteNonQuery();

				_maPhanBoThuLaoChuongTrinh = (int)cm.Parameters["@MaPhanBoThuLaoChuongTrinh"].Value;
			}//using
		}

		private void AddInsertParameters(SqlCommand cm, PhanBoThuLaoNhanVienList parent)
		{
			//TODO: if parent use identity key, fix fk member with value from parent
			if (_maChuongTrinh != 0)
				cm.Parameters.AddWithValue("@MaChuongTrinh", _maChuongTrinh);
			else
				cm.Parameters.AddWithValue("@MaChuongTrinh", DBNull.Value);
			if (_tenChuongTrinh.Length > 0)
				cm.Parameters.AddWithValue("@TenChuongTrinh", _tenChuongTrinh);
			else
				cm.Parameters.AddWithValue("@TenChuongTrinh", DBNull.Value);
			if (_maNhanVien != 0)
				cm.Parameters.AddWithValue("@MaNhanVien", _maNhanVien);
			else
				cm.Parameters.AddWithValue("@MaNhanVien", DBNull.Value);
			if (_maKyTinhLuong != 0)
				cm.Parameters.AddWithValue("@MaKyTinhLuong", _maKyTinhLuong);
			else
				cm.Parameters.AddWithValue("@MaKyTinhLuong", DBNull.Value);
			if (_soTien != 0)
				cm.Parameters.AddWithValue("@SoTien", _soTien);
			else
				cm.Parameters.AddWithValue("@SoTien", DBNull.Value);
			cm.Parameters.AddWithValue("@NgayLap", _ngayLap.DBValue);
			if (_nguoiLap != 0)
				cm.Parameters.AddWithValue("@NguoiLap", _nguoiLap);
			else
				cm.Parameters.AddWithValue("@NguoiLap", DBNull.Value);
			if (_maPhieuChi.Length > 0)
				cm.Parameters.AddWithValue("@MaPhieuChi", _maPhieuChi);
			else
				cm.Parameters.AddWithValue("@MaPhieuChi", DBNull.Value);
			if (_dienGiai.Length > 0)
				cm.Parameters.AddWithValue("@DienGiai", _dienGiai);
			else
				cm.Parameters.AddWithValue("@DienGiai", DBNull.Value);
			if (_phanTramThue != 0)
				cm.Parameters.AddWithValue("@PhanTramThue", _phanTramThue);
			else
				cm.Parameters.AddWithValue("@PhanTramThue", DBNull.Value);
			if (_tienThue != 0)
				cm.Parameters.AddWithValue("@TienThue", _tienThue);
			else
				cm.Parameters.AddWithValue("@TienThue", DBNull.Value);
			if (_soTienConLai != 0)
				cm.Parameters.AddWithValue("@SoTienConLai", _soTienConLai);
			else
				cm.Parameters.AddWithValue("@SoTienConLai", DBNull.Value);
			if (_tinhDangPhi != false)
				cm.Parameters.AddWithValue("@TinhDangPhi", _tinhDangPhi);
			else
				cm.Parameters.AddWithValue("@TinhDangPhi", DBNull.Value);
			if (_maPhanBoThuLao != 0)
				cm.Parameters.AddWithValue("@MaPhanBoThuLao", _maPhanBoThuLao);
			else
				cm.Parameters.AddWithValue("@MaPhanBoThuLao", DBNull.Value);
			if (_maChiTietPhanBoThuLao != 0)
				cm.Parameters.AddWithValue("@MaChiTietPhanBoThuLao", _maChiTietPhanBoThuLao);
			else
				cm.Parameters.AddWithValue("@MaChiTietPhanBoThuLao", DBNull.Value);
			if (_thanhToan != false)
				cm.Parameters.AddWithValue("@ThanhToan", _thanhToan);
			else
				cm.Parameters.AddWithValue("@ThanhToan", DBNull.Value);
			if (_thucNhan != false)
				cm.Parameters.AddWithValue("@ThucNhan", _thucNhan);
			else
				cm.Parameters.AddWithValue("@ThucNhan", DBNull.Value);
			if (_maQLNhanVien.Length > 0)
				cm.Parameters.AddWithValue("@MaQLNhanVien", _maQLNhanVien);
			else
				cm.Parameters.AddWithValue("@MaQLNhanVien", DBNull.Value);
			if (_tenNhanVien.Length > 0)
				cm.Parameters.AddWithValue("@TenNhanVien", _tenNhanVien);
			else
				cm.Parameters.AddWithValue("@TenNhanVien", DBNull.Value);
			cm.Parameters.AddWithValue("@MaBoPhan", _maBoPhan);
			if (_maQLBoPhan.Length > 0)
				cm.Parameters.AddWithValue("@MaQLBoPhan", _maQLBoPhan);
			else
				cm.Parameters.AddWithValue("@MaQLBoPhan", DBNull.Value);
			if (_tenBoPhan.Length > 0)
				cm.Parameters.AddWithValue("@TenBoPhan", _tenBoPhan);
			else
				cm.Parameters.AddWithValue("@TenBoPhan", DBNull.Value);
			if (_maChucVu != 0)
				cm.Parameters.AddWithValue("@MaChucVu", _maChucVu);
			else
				cm.Parameters.AddWithValue("@MaChucVu", DBNull.Value);
			if (_tenChucVu.Length > 0)
				cm.Parameters.AddWithValue("@TenChucVu", _tenChucVu);
			else
				cm.Parameters.AddWithValue("@TenChucVu", DBNull.Value);
			if (_khongTinhThuNhap != false)
				cm.Parameters.AddWithValue("@KhongTinhThuNhap", _khongTinhThuNhap);
			else
				cm.Parameters.AddWithValue("@KhongTinhThuNhap", DBNull.Value);
			if (_duocNhapHo != false)
				cm.Parameters.AddWithValue("@DuocNhapHo", _duocNhapHo);
			else
				cm.Parameters.AddWithValue("@DuocNhapHo", DBNull.Value);
			if (_maGiayXacNhan != 0)
				cm.Parameters.AddWithValue("@MaGiayXacNhan", _maGiayXacNhan);
			else
				cm.Parameters.AddWithValue("@MaGiayXacNhan", DBNull.Value);
			if (_maChiTietGiayXacNhan != 0)
				cm.Parameters.AddWithValue("@MaChiTietGiayXacNhan", _maChiTietGiayXacNhan);
			else
				cm.Parameters.AddWithValue("@MaChiTietGiayXacNhan", DBNull.Value);
			if (_maCongViec != 0)
				cm.Parameters.AddWithValue("@MaCongViec", _maCongViec);
			else
				cm.Parameters.AddWithValue("@MaCongViec", DBNull.Value);
			cm.Parameters.AddWithValue("@MaPhanBoThuLaoChuongTrinh", _maPhanBoThuLaoChuongTrinh);
			cm.Parameters["@MaPhanBoThuLaoChuongTrinh"].Direction = ParameterDirection.Output;
		}
		#endregion //Data Access - Insert

		#region Data Access - Update
		internal void Update(SqlTransaction tr, PhanBoThuLaoNhanVienList parent)
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

		private void ExecuteUpdate(SqlTransaction tr, PhanBoThuLaoNhanVienList parent)
		{
			using (SqlCommand cm = tr.Connection.CreateCommand())
			{
				cm.Transaction = tr;
				cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "Spd_UpdatetblnsPhanBoThuLaoChuongTrinh";

				AddUpdateParameters(cm, parent);

				cm.ExecuteNonQuery();

			}//using
		}

		private void AddUpdateParameters(SqlCommand cm, PhanBoThuLaoNhanVienList parent)
		{
			cm.Parameters.AddWithValue("@MaPhanBoThuLaoChuongTrinh", _maPhanBoThuLaoChuongTrinh);
			if (_maChuongTrinh != 0)
				cm.Parameters.AddWithValue("@MaChuongTrinh", _maChuongTrinh);
			else
				cm.Parameters.AddWithValue("@MaChuongTrinh", DBNull.Value);
			if (_tenChuongTrinh.Length > 0)
				cm.Parameters.AddWithValue("@TenChuongTrinh", _tenChuongTrinh);
			else
				cm.Parameters.AddWithValue("@TenChuongTrinh", DBNull.Value);
			if (_maNhanVien != 0)
				cm.Parameters.AddWithValue("@MaNhanVien", _maNhanVien);
			else
				cm.Parameters.AddWithValue("@MaNhanVien", DBNull.Value);
			if (_maKyTinhLuong != 0)
				cm.Parameters.AddWithValue("@MaKyTinhLuong", _maKyTinhLuong);
			else
				cm.Parameters.AddWithValue("@MaKyTinhLuong", DBNull.Value);
			if (_soTien != 0)
				cm.Parameters.AddWithValue("@SoTien", _soTien);
			else
				cm.Parameters.AddWithValue("@SoTien", DBNull.Value);
			cm.Parameters.AddWithValue("@NgayLap", _ngayLap.DBValue);
			if (_nguoiLap != 0)
				cm.Parameters.AddWithValue("@NguoiLap", _nguoiLap);
			else
				cm.Parameters.AddWithValue("@NguoiLap", DBNull.Value);
			if (_maPhieuChi.Length > 0)
				cm.Parameters.AddWithValue("@MaPhieuChi", _maPhieuChi);
			else
				cm.Parameters.AddWithValue("@MaPhieuChi", DBNull.Value);
			if (_dienGiai.Length > 0)
				cm.Parameters.AddWithValue("@DienGiai", _dienGiai);
			else
				cm.Parameters.AddWithValue("@DienGiai", DBNull.Value);
			if (_phanTramThue != 0)
				cm.Parameters.AddWithValue("@PhanTramThue", _phanTramThue);
			else
				cm.Parameters.AddWithValue("@PhanTramThue", DBNull.Value);
			if (_tienThue != 0)
				cm.Parameters.AddWithValue("@TienThue", _tienThue);
			else
				cm.Parameters.AddWithValue("@TienThue", DBNull.Value);
			if (_soTienConLai != 0)
				cm.Parameters.AddWithValue("@SoTienConLai", _soTienConLai);
			else
				cm.Parameters.AddWithValue("@SoTienConLai", DBNull.Value);
			if (_tinhDangPhi != false)
				cm.Parameters.AddWithValue("@TinhDangPhi", _tinhDangPhi);
			else
				cm.Parameters.AddWithValue("@TinhDangPhi", DBNull.Value);
			if (_maPhanBoThuLao != 0)
				cm.Parameters.AddWithValue("@MaPhanBoThuLao", _maPhanBoThuLao);
			else
				cm.Parameters.AddWithValue("@MaPhanBoThuLao", DBNull.Value);
			if (_maChiTietPhanBoThuLao != 0)
				cm.Parameters.AddWithValue("@MaChiTietPhanBoThuLao", _maChiTietPhanBoThuLao);
			else
				cm.Parameters.AddWithValue("@MaChiTietPhanBoThuLao", DBNull.Value);
			if (_thanhToan != false)
				cm.Parameters.AddWithValue("@ThanhToan", _thanhToan);
			else
				cm.Parameters.AddWithValue("@ThanhToan", DBNull.Value);
			if (_thucNhan != false)
				cm.Parameters.AddWithValue("@ThucNhan", _thucNhan);
			else
				cm.Parameters.AddWithValue("@ThucNhan", DBNull.Value);
			if (_maQLNhanVien.Length > 0)
				cm.Parameters.AddWithValue("@MaQLNhanVien", _maQLNhanVien);
			else
				cm.Parameters.AddWithValue("@MaQLNhanVien", DBNull.Value);
			if (_tenNhanVien.Length > 0)
				cm.Parameters.AddWithValue("@TenNhanVien", _tenNhanVien);
			else
				cm.Parameters.AddWithValue("@TenNhanVien", DBNull.Value);
			cm.Parameters.AddWithValue("@MaBoPhan", _maBoPhan);
			if (_maQLBoPhan.Length > 0)
				cm.Parameters.AddWithValue("@MaQLBoPhan", _maQLBoPhan);
			else
				cm.Parameters.AddWithValue("@MaQLBoPhan", DBNull.Value);
			if (_tenBoPhan.Length > 0)
				cm.Parameters.AddWithValue("@TenBoPhan", _tenBoPhan);
			else
				cm.Parameters.AddWithValue("@TenBoPhan", DBNull.Value);
			if (_maChucVu != 0)
				cm.Parameters.AddWithValue("@MaChucVu", _maChucVu);
			else
				cm.Parameters.AddWithValue("@MaChucVu", DBNull.Value);
			if (_tenChucVu.Length > 0)
				cm.Parameters.AddWithValue("@TenChucVu", _tenChucVu);
			else
				cm.Parameters.AddWithValue("@TenChucVu", DBNull.Value);
			if (_khongTinhThuNhap != false)
				cm.Parameters.AddWithValue("@KhongTinhThuNhap", _khongTinhThuNhap);
			else
				cm.Parameters.AddWithValue("@KhongTinhThuNhap", DBNull.Value);
			if (_duocNhapHo != false)
				cm.Parameters.AddWithValue("@DuocNhapHo", _duocNhapHo);
			else
				cm.Parameters.AddWithValue("@DuocNhapHo", DBNull.Value);
			if (_maGiayXacNhan != 0)
				cm.Parameters.AddWithValue("@MaGiayXacNhan", _maGiayXacNhan);
			else
				cm.Parameters.AddWithValue("@MaGiayXacNhan", DBNull.Value);
			if (_maChiTietGiayXacNhan != 0)
				cm.Parameters.AddWithValue("@MaChiTietGiayXacNhan", _maChiTietGiayXacNhan);
			else
				cm.Parameters.AddWithValue("@MaChiTietGiayXacNhan", DBNull.Value);
			if (_maCongViec != 0)
				cm.Parameters.AddWithValue("@MaCongViec", _maCongViec);
			else
				cm.Parameters.AddWithValue("@MaCongViec", DBNull.Value);
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

			ExecuteDelete(tr, new Criteria(_maPhanBoThuLaoChuongTrinh));
			MarkNew();
		}
		#endregion //Data Access - Delete
		#endregion //Data Access
	}
}

