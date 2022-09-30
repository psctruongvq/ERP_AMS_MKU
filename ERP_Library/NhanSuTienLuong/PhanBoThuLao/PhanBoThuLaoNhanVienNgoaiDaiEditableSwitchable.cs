using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;
namespace ERP_Library
{ 
	[Serializable()] 
	public class PhanBoThuLaoNhanVienNgoaiDai : Csla.BusinessBase<PhanBoThuLaoNhanVienNgoaiDai>
	{
		#region Business Properties and Methods

		//declare members
		private long _maPhanBoThuLaoNgoaiDai = 0;
		private int _maChuongTrinh = 0;
		private string _tenChuongTrinh = string.Empty;
		private long _maPhanBoThuLao = 0;
		private long _maChiTietPhanBoThuLao = 0;
		private int _maKyTinhLuong = 0;
		private string _dienGiai = string.Empty;
		private decimal _soTien = 0;
		private int _nguoiLap = 0;
		private SmartDate _ngayLap = new SmartDate(DateTime.Today);
		private string _maPhieuChi = string.Empty;
		private long _maChiThuLao = 0;
		private int _maBoPhan = 0;
		private string _maQLBoPhan = string.Empty;
		private string _tenBoPhan = string.Empty;
		private string _tenNhanVien = string.Empty;
		private byte _phanTramThue = 0;
		private decimal _tienThue = 0;
		private decimal _soTienConLai = 0;
		private long _maNhanVien = 0;
		private bool _duocNhapHo = false;
		private bool _thanhToan = false;
		private string _cmnd = string.Empty;
		private string _maSoThue = string.Empty;
		private string _dienThoai = string.Empty;
		private string _diaChi = string.Empty;
		private int _loai = 0;
		private long _maNhanVienChuyenTien = 0;
		private int _maGiayXacNhan = 0;
		private int _maChiTietGiayXacNhan = 0;
		private int _maCongViec = 0;

		[System.ComponentModel.DataObjectField(true, true)]
		public long MaPhanBoThuLaoNgoaiDai
		{
			get
			{
				CanReadProperty("MaPhanBoThuLaoNgoaiDai", true);
				return _maPhanBoThuLaoNgoaiDai;
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
                    if (_soTien != 0)
                    {
                        _soTienConLai = _soTien;
                    }
					PropertyHasChanged("SoTien");
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

		public long MaChiThuLao
		{
			get
			{
				CanReadProperty("MaChiThuLao", true);
				return _maChiThuLao;
			}
			set
			{
				CanWriteProperty("MaChiThuLao", true);
				if (!_maChiThuLao.Equals(value))
				{
					_maChiThuLao = value;
					PropertyHasChanged("MaChiThuLao");
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
                    if (_phanTramThue == 0)
                    {
                        _soTienConLai = _soTien;
                        _tienThue = _soTien * _phanTramThue / 100;
                    }
                    else
                    {
                        _tienThue = _soTien * _phanTramThue / 100;
                        _soTienConLai = _soTien - _tienThue;
                        
                    }            
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
                if(_phanTramThue==0)
                {
                    _soTienConLai = _soTien;
                    _tienThue = _soTien * _phanTramThue / 100;
                }
                else
                {
                   _tienThue= _soTien * _phanTramThue/100;
                }
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

		public string DienThoai
		{
			get
			{
				CanReadProperty("DienThoai", true);
				return _dienThoai;
			}
			set
			{
				CanWriteProperty("DienThoai", true);
				if (value == null) value = string.Empty;
				if (!_dienThoai.Equals(value))
				{
					_dienThoai = value;
					PropertyHasChanged("DienThoai");
				}
			}
		}

		public string DiaChi
		{
			get
			{
				CanReadProperty("DiaChi", true);
				return _diaChi;
			}
			set
			{
				CanWriteProperty("DiaChi", true);
				if (value == null) value = string.Empty;
				if (!_diaChi.Equals(value))
				{
					_diaChi = value;
					PropertyHasChanged("DiaChi");
				}
			}
		}

		public int Loai
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

		public long MaNhanVienChuyenTien
		{
			get
			{
				CanReadProperty("MaNhanVienChuyenTien", true);
				return _maNhanVienChuyenTien;
			}
			set
			{
				CanWriteProperty("MaNhanVienChuyenTien", true);
				if (!_maNhanVienChuyenTien.Equals(value))
				{
					_maNhanVienChuyenTien = value;
					PropertyHasChanged("MaNhanVienChuyenTien");
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
			return _maPhanBoThuLaoNgoaiDai;
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
			// TenChuongTrinh
			//
			ValidationRules.AddRule(CommonRules.StringRequired, "TenChuongTrinh");
			//
			// MaPhieuChi
			//
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("MaPhieuChi", 30));
			//
			// MaQLBoPhan
			//
			ValidationRules.AddRule(CommonRules.StringRequired, "MaQLBoPhan");
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("MaQLBoPhan", 50));
			//
			// TenBoPhan
			//
			ValidationRules.AddRule(CommonRules.StringRequired, "TenBoPhan");
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("TenBoPhan", 50));
			//
			// TenNhanVien
			//
			ValidationRules.AddRule(CommonRules.StringRequired, "TenNhanVien");
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("TenNhanVien", 500));
			//
			// Cmnd
			//
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("Cmnd", 50));
			//
			// MaSoThue
			//
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("MaSoThue", 50));
			//
			// DienThoai
			//
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("DienThoai", 50));
			//
			// DiaChi
			//
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("DiaChi", 500));
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
			//TODO: Define authorization rules in PhanBoThuLaoNhanVienNgoaiDai
			//AuthorizationRules.AllowRead("MaPhanBoThuLaoNgoaiDai", "PhanBoThuLaoNhanVienNgoaiDaiReadGroup");
			//AuthorizationRules.AllowRead("MaChuongTrinh", "PhanBoThuLaoNhanVienNgoaiDaiReadGroup");
			//AuthorizationRules.AllowRead("TenChuongTrinh", "PhanBoThuLaoNhanVienNgoaiDaiReadGroup");
			//AuthorizationRules.AllowRead("MaPhanBoThuLao", "PhanBoThuLaoNhanVienNgoaiDaiReadGroup");
			//AuthorizationRules.AllowRead("MaChiTietPhanBoThuLao", "PhanBoThuLaoNhanVienNgoaiDaiReadGroup");
			//AuthorizationRules.AllowRead("MaKyTinhLuong", "PhanBoThuLaoNhanVienNgoaiDaiReadGroup");
			//AuthorizationRules.AllowRead("DienGiai", "PhanBoThuLaoNhanVienNgoaiDaiReadGroup");
			//AuthorizationRules.AllowRead("SoTien", "PhanBoThuLaoNhanVienNgoaiDaiReadGroup");
			//AuthorizationRules.AllowRead("NguoiLap", "PhanBoThuLaoNhanVienNgoaiDaiReadGroup");
			//AuthorizationRules.AllowRead("NgayLap", "PhanBoThuLaoNhanVienNgoaiDaiReadGroup");
			//AuthorizationRules.AllowRead("NgayLapString", "PhanBoThuLaoNhanVienNgoaiDaiReadGroup");
			//AuthorizationRules.AllowRead("MaPhieuChi", "PhanBoThuLaoNhanVienNgoaiDaiReadGroup");
			//AuthorizationRules.AllowRead("MaChiThuLao", "PhanBoThuLaoNhanVienNgoaiDaiReadGroup");
			//AuthorizationRules.AllowRead("MaBoPhan", "PhanBoThuLaoNhanVienNgoaiDaiReadGroup");
			//AuthorizationRules.AllowRead("MaQLBoPhan", "PhanBoThuLaoNhanVienNgoaiDaiReadGroup");
			//AuthorizationRules.AllowRead("TenBoPhan", "PhanBoThuLaoNhanVienNgoaiDaiReadGroup");
			//AuthorizationRules.AllowRead("TenNhanVien", "PhanBoThuLaoNhanVienNgoaiDaiReadGroup");
			//AuthorizationRules.AllowRead("PhanTramThue", "PhanBoThuLaoNhanVienNgoaiDaiReadGroup");
			//AuthorizationRules.AllowRead("TienThue", "PhanBoThuLaoNhanVienNgoaiDaiReadGroup");
			//AuthorizationRules.AllowRead("SoTienConLai", "PhanBoThuLaoNhanVienNgoaiDaiReadGroup");
			//AuthorizationRules.AllowRead("MaNhanVien", "PhanBoThuLaoNhanVienNgoaiDaiReadGroup");
			//AuthorizationRules.AllowRead("DuocNhapHo", "PhanBoThuLaoNhanVienNgoaiDaiReadGroup");
			//AuthorizationRules.AllowRead("ThanhToan", "PhanBoThuLaoNhanVienNgoaiDaiReadGroup");
			//AuthorizationRules.AllowRead("Cmnd", "PhanBoThuLaoNhanVienNgoaiDaiReadGroup");
			//AuthorizationRules.AllowRead("MaSoThue", "PhanBoThuLaoNhanVienNgoaiDaiReadGroup");
			//AuthorizationRules.AllowRead("DienThoai", "PhanBoThuLaoNhanVienNgoaiDaiReadGroup");
			//AuthorizationRules.AllowRead("DiaChi", "PhanBoThuLaoNhanVienNgoaiDaiReadGroup");
			//AuthorizationRules.AllowRead("Loai", "PhanBoThuLaoNhanVienNgoaiDaiReadGroup");
			//AuthorizationRules.AllowRead("MaNhanVienChuyenTien", "PhanBoThuLaoNhanVienNgoaiDaiReadGroup");
			//AuthorizationRules.AllowRead("MaGiayXacNhan", "PhanBoThuLaoNhanVienNgoaiDaiReadGroup");
			//AuthorizationRules.AllowRead("MaChiTietGiayXacNhan", "PhanBoThuLaoNhanVienNgoaiDaiReadGroup");
			//AuthorizationRules.AllowRead("MaCongViec", "PhanBoThuLaoNhanVienNgoaiDaiReadGroup");

			//AuthorizationRules.AllowWrite("MaChuongTrinh", "PhanBoThuLaoNhanVienNgoaiDaiWriteGroup");
			//AuthorizationRules.AllowWrite("TenChuongTrinh", "PhanBoThuLaoNhanVienNgoaiDaiWriteGroup");
			//AuthorizationRules.AllowWrite("MaPhanBoThuLao", "PhanBoThuLaoNhanVienNgoaiDaiWriteGroup");
			//AuthorizationRules.AllowWrite("MaChiTietPhanBoThuLao", "PhanBoThuLaoNhanVienNgoaiDaiWriteGroup");
			//AuthorizationRules.AllowWrite("MaKyTinhLuong", "PhanBoThuLaoNhanVienNgoaiDaiWriteGroup");
			//AuthorizationRules.AllowWrite("DienGiai", "PhanBoThuLaoNhanVienNgoaiDaiWriteGroup");
			//AuthorizationRules.AllowWrite("SoTien", "PhanBoThuLaoNhanVienNgoaiDaiWriteGroup");
			//AuthorizationRules.AllowWrite("NguoiLap", "PhanBoThuLaoNhanVienNgoaiDaiWriteGroup");
			//AuthorizationRules.AllowWrite("NgayLapString", "PhanBoThuLaoNhanVienNgoaiDaiWriteGroup");
			//AuthorizationRules.AllowWrite("MaPhieuChi", "PhanBoThuLaoNhanVienNgoaiDaiWriteGroup");
			//AuthorizationRules.AllowWrite("MaChiThuLao", "PhanBoThuLaoNhanVienNgoaiDaiWriteGroup");
			//AuthorizationRules.AllowWrite("MaBoPhan", "PhanBoThuLaoNhanVienNgoaiDaiWriteGroup");
			//AuthorizationRules.AllowWrite("MaQLBoPhan", "PhanBoThuLaoNhanVienNgoaiDaiWriteGroup");
			//AuthorizationRules.AllowWrite("TenBoPhan", "PhanBoThuLaoNhanVienNgoaiDaiWriteGroup");
			//AuthorizationRules.AllowWrite("TenNhanVien", "PhanBoThuLaoNhanVienNgoaiDaiWriteGroup");
			//AuthorizationRules.AllowWrite("PhanTramThue", "PhanBoThuLaoNhanVienNgoaiDaiWriteGroup");
			//AuthorizationRules.AllowWrite("TienThue", "PhanBoThuLaoNhanVienNgoaiDaiWriteGroup");
			//AuthorizationRules.AllowWrite("SoTienConLai", "PhanBoThuLaoNhanVienNgoaiDaiWriteGroup");
			//AuthorizationRules.AllowWrite("MaNhanVien", "PhanBoThuLaoNhanVienNgoaiDaiWriteGroup");
			//AuthorizationRules.AllowWrite("DuocNhapHo", "PhanBoThuLaoNhanVienNgoaiDaiWriteGroup");
			//AuthorizationRules.AllowWrite("ThanhToan", "PhanBoThuLaoNhanVienNgoaiDaiWriteGroup");
			//AuthorizationRules.AllowWrite("Cmnd", "PhanBoThuLaoNhanVienNgoaiDaiWriteGroup");
			//AuthorizationRules.AllowWrite("MaSoThue", "PhanBoThuLaoNhanVienNgoaiDaiWriteGroup");
			//AuthorizationRules.AllowWrite("DienThoai", "PhanBoThuLaoNhanVienNgoaiDaiWriteGroup");
			//AuthorizationRules.AllowWrite("DiaChi", "PhanBoThuLaoNhanVienNgoaiDaiWriteGroup");
			//AuthorizationRules.AllowWrite("Loai", "PhanBoThuLaoNhanVienNgoaiDaiWriteGroup");
			//AuthorizationRules.AllowWrite("MaNhanVienChuyenTien", "PhanBoThuLaoNhanVienNgoaiDaiWriteGroup");
			//AuthorizationRules.AllowWrite("MaGiayXacNhan", "PhanBoThuLaoNhanVienNgoaiDaiWriteGroup");
			//AuthorizationRules.AllowWrite("MaChiTietGiayXacNhan", "PhanBoThuLaoNhanVienNgoaiDaiWriteGroup");
			//AuthorizationRules.AllowWrite("MaCongViec", "PhanBoThuLaoNhanVienNgoaiDaiWriteGroup");
		}


		public static bool CanGetObject()
		{
			//TODO: Define CanGetObject permission in PhanBoThuLaoNhanVienNgoaiDai
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("PhanBoThuLaoNhanVienNgoaiDaiViewGroup"))
			//	return true;
			//return false;
		}

		public static bool CanAddObject()
		{
			//TODO: Define CanAddObject permission in PhanBoThuLaoNhanVienNgoaiDai
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("PhanBoThuLaoNhanVienNgoaiDaiAddGroup"))
			//	return true;
			//return false;
		}

		public static bool CanEditObject()
		{
			//TODO: Define CanEditObject permission in PhanBoThuLaoNhanVienNgoaiDai
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("PhanBoThuLaoNhanVienNgoaiDaiEditGroup"))
			//	return true;
			//return false;
		}

		public static bool CanDeleteObject()
		{
			//TODO: Define CanDeleteObject permission in PhanBoThuLaoNhanVienNgoaiDai
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("PhanBoThuLaoNhanVienNgoaiDaiDeleteGroup"))
			//	return true;
			//return false;
		}
		#endregion //Authorization Rules

		#region Factory Methods
		private PhanBoThuLaoNhanVienNgoaiDai()
		{ /* require use of factory method */
            MarkAsChild();
        }

		public static PhanBoThuLaoNhanVienNgoaiDai NewPhanBoThuLaoNhanVienNgoaiDai()
		{
			if (!CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a PhanBoThuLaoNhanVienNgoaiDai");
			return DataPortal.Create<PhanBoThuLaoNhanVienNgoaiDai>();
		}

		public static PhanBoThuLaoNhanVienNgoaiDai GetPhanBoThuLaoNhanVienNgoaiDai(long maPhanBoThuLaoNgoaiDai)
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException("User not authorized to view a PhanBoThuLaoNhanVienNgoaiDai");
			return DataPortal.Fetch<PhanBoThuLaoNhanVienNgoaiDai>(new Criteria(maPhanBoThuLaoNgoaiDai));
		}

		public static void DeletePhanBoThuLaoNhanVienNgoaiDai(long maPhanBoThuLaoNgoaiDai)
		{
			if (!CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a PhanBoThuLaoNhanVienNgoaiDai");
			DataPortal.Delete(new Criteria(maPhanBoThuLaoNgoaiDai));
		}

        public static PhanBoThuLaoNhanVienNgoaiDai GetPhanBoThuLaoNhanVienNgoaiDaiByMaPhanBoThuLao(int maPhanBoThuLao ,DateTime ngayLap)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a PhanBoThuLaoNhanVienNgoaiDai");
            return DataPortal.Fetch<PhanBoThuLaoNhanVienNgoaiDai>(new CriteriaByMaPhanBoThuLao(maPhanBoThuLao, ngayLap));
        }

		public override PhanBoThuLaoNhanVienNgoaiDai Save()
		{
			if (IsDeleted && !CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a PhanBoThuLaoNhanVienNgoaiDai");
			else if (IsNew && !CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a PhanBoThuLaoNhanVienNgoaiDai");
			else if (!CanEditObject())
				throw new System.Security.SecurityException("User not authorized to update a PhanBoThuLaoNhanVienNgoaiDai");

			return base.Save();
		}

		#endregion //Factory Methods

		#region Child Factory Methods
		internal static PhanBoThuLaoNhanVienNgoaiDai NewPhanBoThuLaoNhanVienNgoaiDaiChild()
		{
			PhanBoThuLaoNhanVienNgoaiDai child = new PhanBoThuLaoNhanVienNgoaiDai();
			child.ValidationRules.CheckRules();
			child.MarkAsChild();
			return child;
		}

		internal static PhanBoThuLaoNhanVienNgoaiDai GetPhanBoThuLaoNhanVienNgoaiDai(SafeDataReader dr)
		{
			PhanBoThuLaoNhanVienNgoaiDai child =  new PhanBoThuLaoNhanVienNgoaiDai();
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
			public long MaPhanBoThuLaoNgoaiDai;

			public Criteria(long maPhanBoThuLaoNgoaiDai)
			{
				this.MaPhanBoThuLaoNgoaiDai = maPhanBoThuLaoNgoaiDai;
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
        
        #endregion#endregion //Criteria

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
                if(criteria is Criteria)
                {
				cm.Transaction = tr;
				cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "Spd_SelecttblnsPhanBoThuLaoNhanVienNgoaiDai";

				cm.Parameters.AddWithValue("@MaPhanBoThuLaoNgoaiDai", ((Criteria)criteria).MaPhanBoThuLaoNgoaiDai);
                }

               if(criteria is CriteriaByMaPhanBoThuLao)
                {
				cm.Transaction = tr;
				cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "Spd_SelecttblnsPhanBoThuLaoNhanVienNgoaiDaiByMaPhanBoThuLao";

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
			DataPortal_Delete(new Criteria(_maPhanBoThuLaoNgoaiDai));
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
                cm.CommandText = "Spd_DeletetblnsPhanBoThuLaoNhanVienNgoaiDai";

				cm.Parameters.AddWithValue("@MaPhanBoThuLaoNgoaiDai", criteria.MaPhanBoThuLaoNgoaiDai);

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
			_maPhanBoThuLaoNgoaiDai = dr.GetInt64("MaPhanBoThuLaoNgoaiDai");
			_maChuongTrinh = dr.GetInt32("MaChuongTrinh");
			_tenChuongTrinh = dr.GetString("TenChuongTrinh");
			_maPhanBoThuLao = dr.GetInt64("MaPhanBoThuLao");
			_maChiTietPhanBoThuLao = dr.GetInt64("MaChiTietPhanBoThuLao");
			_maKyTinhLuong = dr.GetInt32("MaKyTinhLuong");
			_dienGiai = dr.GetString("DienGiai");
			_soTien = dr.GetDecimal("SoTien");
			_nguoiLap = dr.GetInt32("NguoiLap");
			_ngayLap = dr.GetSmartDate("NgayLap", _ngayLap.EmptyIsMin);
			_maPhieuChi = dr.GetString("MaPhieuChi");
			_maChiThuLao = dr.GetInt64("MaChiThuLao");
			_maBoPhan = dr.GetInt32("MaBoPhan");
			_maQLBoPhan = dr.GetString("MaQLBoPhan");
			_tenBoPhan = dr.GetString("TenBoPhan");
			_tenNhanVien = dr.GetString("TenNhanVien");
			_phanTramThue = dr.GetByte("PhanTramThue");
			_tienThue = dr.GetDecimal("TienThue");
			_soTienConLai = dr.GetDecimal("SoTienConLai");
			_maNhanVien = dr.GetInt64("MaNhanVien");
			_duocNhapHo = dr.GetBoolean("DuocNhapHo");
			_thanhToan = dr.GetBoolean("ThanhToan");
			_cmnd = dr.GetString("CMND");
			_maSoThue = dr.GetString("MaSoThue");
			_dienThoai = dr.GetString("DienThoai");
			_diaChi = dr.GetString("DiaChi");
			_loai = dr.GetInt32("Loai");
			_maNhanVienChuyenTien = dr.GetInt64("MaNhanVienChuyenTien");
			_maGiayXacNhan = dr.GetInt32("MaGiayXacNhan");
			_maChiTietGiayXacNhan = dr.GetInt32("MaChiTietGiayXacNhan");
			_maCongViec = dr.GetInt32("MaCongViec");
		}

		private void FetchChildren(SafeDataReader dr)
		{
		}
		#endregion //Data Access - Fetch

		#region Data Access - Insert
		internal void Insert(SqlTransaction tr, PhanBoThuLaoNhanVienNgoaiDaiList parent)
		{
			if (!IsDirty) return;

			ExecuteInsert(tr, parent);
			MarkOld();

			//update child object(s)
			UpdateChildren(tr);
		}

		private void ExecuteInsert(SqlTransaction tr, PhanBoThuLaoNhanVienNgoaiDaiList parent)
		{
			using (SqlCommand cm = tr.Connection.CreateCommand())
			{
				cm.Transaction = tr;
				cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "Spd_InserttblnsPhanBoThuLaoNhanVienNgoaiDai";

				AddInsertParameters(cm, parent);

				cm.ExecuteNonQuery();

				_maPhanBoThuLaoNgoaiDai = (long)cm.Parameters["@MaPhanBoThuLaoNgoaiDai"].Value;
			}//using
		}

		private void AddInsertParameters(SqlCommand cm, PhanBoThuLaoNhanVienNgoaiDaiList parent)
		{
			//TODO: if parent use identity key, fix fk member with value from parent
			cm.Parameters.AddWithValue("@MaChuongTrinh", _maChuongTrinh);
			cm.Parameters.AddWithValue("@TenChuongTrinh", _tenChuongTrinh);
			cm.Parameters.AddWithValue("@MaPhanBoThuLao", _maPhanBoThuLao);
			cm.Parameters.AddWithValue("@MaChiTietPhanBoThuLao", _maChiTietPhanBoThuLao);
			cm.Parameters.AddWithValue("@MaKyTinhLuong", _maKyTinhLuong);
			if (_dienGiai.Length > 0)
				cm.Parameters.AddWithValue("@DienGiai", _dienGiai);
			else
				cm.Parameters.AddWithValue("@DienGiai", DBNull.Value);
			cm.Parameters.AddWithValue("@SoTien", _soTien);
			cm.Parameters.AddWithValue("@NguoiLap", _nguoiLap);
			cm.Parameters.AddWithValue("@NgayLap", _ngayLap.DBValue);
			if (_maPhieuChi.Length > 0)
				cm.Parameters.AddWithValue("@MaPhieuChi", _maPhieuChi);
			else
				cm.Parameters.AddWithValue("@MaPhieuChi", DBNull.Value);
			if (_maChiThuLao != 0)
				cm.Parameters.AddWithValue("@MaChiThuLao", _maChiThuLao);
			else
				cm.Parameters.AddWithValue("@MaChiThuLao", DBNull.Value);
			cm.Parameters.AddWithValue("@MaBoPhan", _maBoPhan);
			cm.Parameters.AddWithValue("@MaQLBoPhan", _maQLBoPhan);
			cm.Parameters.AddWithValue("@TenBoPhan", _tenBoPhan);
			cm.Parameters.AddWithValue("@TenNhanVien", _tenNhanVien);
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
			cm.Parameters.AddWithValue("@MaNhanVien", _maNhanVien);
			if (_duocNhapHo != false)
				cm.Parameters.AddWithValue("@DuocNhapHo", _duocNhapHo);
			else
				cm.Parameters.AddWithValue("@DuocNhapHo", DBNull.Value);
			if (_thanhToan != false)
				cm.Parameters.AddWithValue("@ThanhToan", _thanhToan);
			else
				cm.Parameters.AddWithValue("@ThanhToan", DBNull.Value);
			if (_cmnd.Length > 0)
				cm.Parameters.AddWithValue("@CMND", _cmnd);
			else
				cm.Parameters.AddWithValue("@CMND", DBNull.Value);
			if (_maSoThue.Length > 0)
				cm.Parameters.AddWithValue("@MaSoThue", _maSoThue);
			else
				cm.Parameters.AddWithValue("@MaSoThue", DBNull.Value);
			if (_dienThoai.Length > 0)
				cm.Parameters.AddWithValue("@DienThoai", _dienThoai);
			else
				cm.Parameters.AddWithValue("@DienThoai", DBNull.Value);
			if (_diaChi.Length > 0)
				cm.Parameters.AddWithValue("@DiaChi", _diaChi);
			else
				cm.Parameters.AddWithValue("@DiaChi", DBNull.Value);
			cm.Parameters.AddWithValue("@Loai", _loai);
			if (_maNhanVienChuyenTien != 0)
				cm.Parameters.AddWithValue("@MaNhanVienChuyenTien", _maNhanVienChuyenTien);
			else
				cm.Parameters.AddWithValue("@MaNhanVienChuyenTien", DBNull.Value);
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
			cm.Parameters.AddWithValue("@MaPhanBoThuLaoNgoaiDai", _maPhanBoThuLaoNgoaiDai);
			cm.Parameters["@MaPhanBoThuLaoNgoaiDai"].Direction = ParameterDirection.Output;
		}
		#endregion //Data Access - Insert

		#region Data Access - Update
		internal void Update(SqlTransaction tr, PhanBoThuLaoNhanVienNgoaiDaiList parent)
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

		private void ExecuteUpdate(SqlTransaction tr, PhanBoThuLaoNhanVienNgoaiDaiList parent)
		{
			using (SqlCommand cm = tr.Connection.CreateCommand())
			{
				cm.Transaction = tr;
				cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "Spd_UpdatetblnsPhanBoThuLaoNhanVienNgoaiDai";

				AddUpdateParameters(cm, parent);

				cm.ExecuteNonQuery();

			}//using
		}

		private void AddUpdateParameters(SqlCommand cm, PhanBoThuLaoNhanVienNgoaiDaiList parent)
		{
			cm.Parameters.AddWithValue("@MaPhanBoThuLaoNgoaiDai", _maPhanBoThuLaoNgoaiDai);
			cm.Parameters.AddWithValue("@MaChuongTrinh", _maChuongTrinh);
			cm.Parameters.AddWithValue("@TenChuongTrinh", _tenChuongTrinh);
			cm.Parameters.AddWithValue("@MaPhanBoThuLao", _maPhanBoThuLao);
			cm.Parameters.AddWithValue("@MaChiTietPhanBoThuLao", _maChiTietPhanBoThuLao);
			cm.Parameters.AddWithValue("@MaKyTinhLuong", _maKyTinhLuong);
			if (_dienGiai.Length > 0)
				cm.Parameters.AddWithValue("@DienGiai", _dienGiai);
			else
				cm.Parameters.AddWithValue("@DienGiai", DBNull.Value);
			cm.Parameters.AddWithValue("@SoTien", _soTien);
			cm.Parameters.AddWithValue("@NguoiLap", _nguoiLap);
			cm.Parameters.AddWithValue("@NgayLap", _ngayLap.DBValue);
			if (_maPhieuChi.Length > 0)
				cm.Parameters.AddWithValue("@MaPhieuChi", _maPhieuChi);
			else
				cm.Parameters.AddWithValue("@MaPhieuChi", DBNull.Value);
			if (_maChiThuLao != 0)
				cm.Parameters.AddWithValue("@MaChiThuLao", _maChiThuLao);
			else
				cm.Parameters.AddWithValue("@MaChiThuLao", DBNull.Value);
			cm.Parameters.AddWithValue("@MaBoPhan", _maBoPhan);
			cm.Parameters.AddWithValue("@MaQLBoPhan", _maQLBoPhan);
			cm.Parameters.AddWithValue("@TenBoPhan", _tenBoPhan);
			cm.Parameters.AddWithValue("@TenNhanVien", _tenNhanVien);
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
			cm.Parameters.AddWithValue("@MaNhanVien", _maNhanVien);
			if (_duocNhapHo != false)
				cm.Parameters.AddWithValue("@DuocNhapHo", _duocNhapHo);
			else
				cm.Parameters.AddWithValue("@DuocNhapHo", DBNull.Value);
			if (_thanhToan != false)
				cm.Parameters.AddWithValue("@ThanhToan", _thanhToan);
			else
				cm.Parameters.AddWithValue("@ThanhToan", DBNull.Value);
			if (_cmnd.Length > 0)
				cm.Parameters.AddWithValue("@CMND", _cmnd);
			else
				cm.Parameters.AddWithValue("@CMND", DBNull.Value);
			if (_maSoThue.Length > 0)
				cm.Parameters.AddWithValue("@MaSoThue", _maSoThue);
			else
				cm.Parameters.AddWithValue("@MaSoThue", DBNull.Value);
			if (_dienThoai.Length > 0)
				cm.Parameters.AddWithValue("@DienThoai", _dienThoai);
			else
				cm.Parameters.AddWithValue("@DienThoai", DBNull.Value);
			if (_diaChi.Length > 0)
				cm.Parameters.AddWithValue("@DiaChi", _diaChi);
			else
				cm.Parameters.AddWithValue("@DiaChi", DBNull.Value);
			cm.Parameters.AddWithValue("@Loai", _loai);
			if (_maNhanVienChuyenTien != 0)
				cm.Parameters.AddWithValue("@MaNhanVienChuyenTien", _maNhanVienChuyenTien);
			else
				cm.Parameters.AddWithValue("@MaNhanVienChuyenTien", DBNull.Value);
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

			ExecuteDelete(tr, new Criteria(_maPhanBoThuLaoNgoaiDai));
			MarkNew();
		}
		#endregion //Data Access - Delete
		#endregion //Data Access
	}
}

