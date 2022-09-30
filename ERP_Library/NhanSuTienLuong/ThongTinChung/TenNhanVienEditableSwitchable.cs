
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{ 
	[Serializable()] 
	public class TenNV : Csla.BusinessBase<TenNV>
	{
		#region Business Properties and Methods

		//declare members
		private long _maNhanVien = 0;
		private string _maQLNhanVien = string.Empty;
		private string _cardID = string.Empty;
		private string _tenNhanVien = string.Empty;
		private int _maChucVu = 0;
		private string _tenChucVu = string.Empty;
		private int _maBoPhan = 0;
		private string _tenBoPhan = string.Empty;
		private bool _gioiTinh = false;
        private string _tenGioiTinh = string.Empty;
		private string _cmnd = string.Empty;
		private SmartDate _ngayCap = new SmartDate(DateTime.Today);
		private int _maNoiCap = 0;
		private int _maKiemNhiem = 0;
		private string _tenKiemNhiem = string.Empty;
		private int _maChucDanh = 0;
		private SmartDate _ngaySinh = new SmartDate(DateTime.Today);
		private int _maNoiSinh = 0;
		private int _maTinhThanhQueQuan = 0;
		private int _quocTich = 0;
		private int _maDanToc = 0;
		private int _maTonGiao = 0;
		private SmartDate _ngayVaoNganh = new SmartDate(DateTime.Today);
		private SmartDate _ngayTinhThamNien = new SmartDate(DateTime.Today);
		private string _loaiSucKhoe = string.Empty;
		private string _chieuCao = string.Empty;
		private string _nhomMau = string.Empty;
		private string _canNang = string.Empty;
		private int _maUuTienGD = 0;
		private int _maUuTienBanThan = 0;
		private long _maNguoiLap = 0;
		private SmartDate _ngayLap = new SmartDate(DateTime.Today);
		private string _soTaiKhoan = string.Empty;
		private int _maNganHang = 0;
        private byte _tinhTrang = 0;
		private int _loaiNV = 0;
		private int _maThanhPhanGD = 0;
		private int _maQuanHuyenNoiSinh = 0;
		private int _maQuanHuyenQueQuan = 0;
        private bool _Check = false;
        private string _TenTinhTrang = string.Empty;
        private int _maCongViec = 0;
        private decimal _thangLuong = 0;
        private int _maTayNghe = 0;
        private decimal _soTienPhuCapTayNghe = 0;
        private int _maMucDoHTCongViec = 0;
        private decimal _soTienThuong = 0;
        private int _maPhuCap = 0;
        private int _maKhenThuong = 0;
        private int _maThangLuong = 0;
        private int _maNgachLuongCoBan = 0;
        private int _maBacLuongCoBan = 0;
        private decimal _heSoLuongCoBan = 0;
        
		[System.ComponentModel.DataObjectField(true, false)]
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

		public string CardID
		{
			get
			{
				CanReadProperty("CardID", true);
				return _cardID;
			}
			set
			{
				CanWriteProperty("CardID", true);
				if (value == null) value = string.Empty;
				if (!_cardID.Equals(value))
				{
					_cardID = value;
					PropertyHasChanged("CardID");
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

		public bool GioiTinh
		{
			get
			{
				CanReadProperty("GioiTinh", true);
				return _gioiTinh;
			}
			set
			{
				CanWriteProperty("GioiTinh", true);
				if (!_gioiTinh.Equals(value))
				{
					_gioiTinh = value;
					PropertyHasChanged("GioiTinh");
				}
			}
		}

        public string TenGioiTinh
        {
            get
            {
                CanReadProperty("TenGioiTinh", true);
                if (_gioiTinh == false)
                    _tenGioiTinh = "Nam";
                else if (_gioiTinh == true)
                    _tenGioiTinh = "Nữ";
                return _tenGioiTinh;
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

		public DateTime NgayCap
		{
			get
			{
				CanReadProperty("NgayCap", true);
				return _ngayCap.Date;
			}
             set
            {
                CanWriteProperty(true);
                if (!_ngayCap.Equals(value))
                {
                    _ngayCap = new SmartDate(value);
                    PropertyHasChanged("NgayCap");
                }
            }
		}
		
		public int MaNoiCap
		{
			get
			{
				CanReadProperty("MaNoiCap", true);
				return _maNoiCap;
			}
			set
			{
				CanWriteProperty("MaNoiCap", true);
				if (!_maNoiCap.Equals(value))
				{
					_maNoiCap = value;
					PropertyHasChanged("MaNoiCap");
				}
			}
		}

		public int MaKiemNhiem
		{
			get
			{
				CanReadProperty("MaKiemNhiem", true);
				return _maKiemNhiem;
			}
			set
			{
				CanWriteProperty("MaKiemNhiem", true);
				if (!_maKiemNhiem.Equals(value))
				{
					_maKiemNhiem = value;
					PropertyHasChanged("MaKiemNhiem");
				}
			}
		}

		public string TenKiemNhiem
		{
			get
			{
				CanReadProperty("TenKiemNhiem", true);
				return _tenKiemNhiem;
			}
			set
			{
				CanWriteProperty("TenKiemNhiem", true);
				if (value == null) value = string.Empty;
				if (!_tenKiemNhiem.Equals(value))
				{
					_tenKiemNhiem = value;
					PropertyHasChanged("TenKiemNhiem");
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

		public DateTime NgaySinh
		{
			get
			{
				CanReadProperty("NgaySinh", true);
				return _ngaySinh.Date;
			}
            set
            {
                CanWriteProperty(true);
                if (!_ngaySinh.Equals(value))
                {
                    _ngaySinh = new SmartDate(value);
                    PropertyHasChanged("NgaySinh");
                }
            }
		}
		
		public int MaNoiSinh
		{
			get
			{
				CanReadProperty("MaNoiSinh", true);
				return _maNoiSinh;
			}
			set
			{
				CanWriteProperty("MaNoiSinh", true);
				if (!_maNoiSinh.Equals(value))
				{
					_maNoiSinh = value;
					PropertyHasChanged("MaNoiSinh");
				}
			}
		}

		public int MaTinhThanhQueQuan
		{
			get
			{
				CanReadProperty("MaTinhThanhQueQuan", true);
				return _maTinhThanhQueQuan;
			}
			set
			{
				CanWriteProperty("MaTinhThanhQueQuan", true);
				if (!_maTinhThanhQueQuan.Equals(value))
				{
					_maTinhThanhQueQuan = value;
					PropertyHasChanged("MaTinhThanhQueQuan");
				}
			}
		}

		public int QuocTich
		{
			get
			{
				CanReadProperty("QuocTich", true);
				return _quocTich;
			}
			set
			{
				CanWriteProperty("QuocTich", true);
				if (!_quocTich.Equals(value))
				{
					_quocTich = value;
					PropertyHasChanged("QuocTich");
				}
			}
		}

		public int MaDanToc
		{
			get
			{
				CanReadProperty("MaDanToc", true);
				return _maDanToc;
			}
			set
			{
				CanWriteProperty("MaDanToc", true);
				if (!_maDanToc.Equals(value))
				{
					_maDanToc = value;
					PropertyHasChanged("MaDanToc");
				}
			}
		}

		public int MaTonGiao
		{
			get
			{
				CanReadProperty("MaTonGiao", true);
				return _maTonGiao;
			}
			set
			{
				CanWriteProperty("MaTonGiao", true);
				if (!_maTonGiao.Equals(value))
				{
					_maTonGiao = value;
					PropertyHasChanged("MaTonGiao");
				}
			}
		}

		public DateTime NgayVaoNganh
		{
			get
			{
				CanReadProperty("NgayVaoNganh", true);
				return _ngayVaoNganh.Date;
			}
            set
            {
                CanWriteProperty(true);
                if (!_ngayVaoNganh.Equals(value))
                {
                    _ngayVaoNganh = new SmartDate(value);
                    PropertyHasChanged("NgayVaoNganh");
                }
            }
		}
	
		public DateTime NgayTinhThamNien
		{
			get
			{
				CanReadProperty("NgayTinhThamNien", true);
				return _ngayTinhThamNien.Date;
			}
            set
            {
                CanWriteProperty(true);
                if (!_ngayTinhThamNien.Equals(value))
                {
                    _ngayTinhThamNien = new SmartDate(value);
                    PropertyHasChanged("NgayTinhThamNien");
                }
            }
		}
		
		public string LoaiSucKhoe
		{
			get
			{
				CanReadProperty("LoaiSucKhoe", true);
				return _loaiSucKhoe;
			}
			set
			{
				CanWriteProperty("LoaiSucKhoe", true);
				if (value == null) value = string.Empty;
				if (!_loaiSucKhoe.Equals(value))
				{
					_loaiSucKhoe = value;
					PropertyHasChanged("LoaiSucKhoe");
				}
			}
		}

		public string ChieuCao
		{
			get
			{
				CanReadProperty("ChieuCao", true);
				return _chieuCao;
			}
			set
			{
				CanWriteProperty("ChieuCao", true);
				if (value == null) value = string.Empty;
				if (!_chieuCao.Equals(value))
				{
					_chieuCao = value;
					PropertyHasChanged("ChieuCao");
				}
			}
		}

		public string NhomMau
		{
			get
			{
				CanReadProperty("NhomMau", true);
				return _nhomMau;
			}
			set
			{
				CanWriteProperty("NhomMau", true);
				if (value == null) value = string.Empty;
				if (!_nhomMau.Equals(value))
				{
					_nhomMau = value;
					PropertyHasChanged("NhomMau");
				}
			}
		}

		public string CanNang
		{
			get
			{
				CanReadProperty("CanNang", true);
				return _canNang;
			}
			set
			{
				CanWriteProperty("CanNang", true);
				if (value == null) value = string.Empty;
				if (!_canNang.Equals(value))
				{
					_canNang = value;
					PropertyHasChanged("CanNang");
				}
			}
		}

		public int MaUuTienGD
		{
			get
			{
				CanReadProperty("MaUuTienGD", true);
				return _maUuTienGD;
			}
			set
			{
				CanWriteProperty("MaUuTienGD", true);
				if (!_maUuTienGD.Equals(value))
				{
					_maUuTienGD = value;
					PropertyHasChanged("MaUuTienGD");
				}
			}
		}

		public int MaUuTienBanThan
		{
			get
			{
				CanReadProperty("MaUuTienBanThan", true);
				return _maUuTienBanThan;
			}
			set
			{
				CanWriteProperty("MaUuTienBanThan", true);
				if (!_maUuTienBanThan.Equals(value))
				{
					_maUuTienBanThan = value;
					PropertyHasChanged("MaUuTienBanThan");
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
		
		public string SoTaiKhoan
		{
			get
			{
				CanReadProperty("SoTaiKhoan", true);
				return _soTaiKhoan;
			}
			set
			{
				CanWriteProperty("SoTaiKhoan", true);
				if (value == null) value = string.Empty;
				if (!_soTaiKhoan.Equals(value))
				{
					_soTaiKhoan = value;
					PropertyHasChanged("SoTaiKhoan");
				}
			}
		}

		public int MaNganHang
		{
			get
			{
				CanReadProperty("MaNganHang", true);
				return _maNganHang;
			}
			set
			{
				CanWriteProperty("MaNganHang", true);
				if (!_maNganHang.Equals(value))
				{
					_maNganHang = value;
					PropertyHasChanged("MaNganHang");
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

		public int LoaiNV
		{
			get
			{
				CanReadProperty("LoaiNV", true);
				return _loaiNV;
			}
			set
			{
				CanWriteProperty("LoaiNV", true);
				if (!_loaiNV.Equals(value))
				{
					_loaiNV = value;
					PropertyHasChanged("LoaiNV");
				}
			}
		}

		public int MaThanhPhanGD
		{
			get
			{
				CanReadProperty("MaThanhPhanGD", true);
				return _maThanhPhanGD;
			}
			set
			{
				CanWriteProperty("MaThanhPhanGD", true);
				if (!_maThanhPhanGD.Equals(value))
				{
					_maThanhPhanGD = value;
					PropertyHasChanged("MaThanhPhanGD");
				}
			}
		}

		public int MaQuanHuyenNoiSinh
		{
			get
			{
				CanReadProperty("MaQuanHuyenNoiSinh", true);
				return _maQuanHuyenNoiSinh;
			}
			set
			{
				CanWriteProperty("MaQuanHuyenNoiSinh", true);
				if (!_maQuanHuyenNoiSinh.Equals(value))
				{
					_maQuanHuyenNoiSinh = value;
					PropertyHasChanged("MaQuanHuyenNoiSinh");
				}
			}
		}

		public int MaQuanHuyenQueQuan
		{
			get
			{
				CanReadProperty("MaQuanHuyenQueQuan", true);
				return _maQuanHuyenQueQuan;
			}
			set
			{
				CanWriteProperty("MaQuanHuyenQueQuan", true);
				if (!_maQuanHuyenQueQuan.Equals(value))
				{
					_maQuanHuyenQueQuan = value;
					PropertyHasChanged("MaQuanHuyenQueQuan");
				}
			}
		}

        public bool Check
        {
            get
            {
                CanReadProperty("Check", true);
                return _Check;
            }
            set
            {
                CanWriteProperty("Check", true);
                if (!_Check.Equals(value))
                {
                    _Check = value;
                    PropertyHasChanged("Check");
                }
            }
        }

        public string TenTinhTrang
        {
            get
            {
                CanReadProperty("TenTinhTrang", true);
                if (_tinhTrang == 0)
                    _TenTinhTrang = "Đang Làm";
                else if (_tinhTrang == 1)
                    _TenTinhTrang = "Thôi Việc";
                else if (_tinhTrang == 2)
                    _TenTinhTrang = "Tạm Nghỉ";
                    return _TenTinhTrang;
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

        public decimal ThangLuong
        {
            get
            {
                CanReadProperty("ThangLuong", true);
                return _thangLuong;
            }
            set
            {
                CanWriteProperty("ThangLuong", true);
                if (!_thangLuong.Equals(value))
                {
                    _thangLuong = value;
                    PropertyHasChanged("ThangLuong");
                }
            }
        }

        public int MaTayNghe
        {
            get
            {
                CanReadProperty("MaTayNghe", true);
                return _maTayNghe;
            }
            set
            {
                CanWriteProperty("MaTayNghe", true);
                if (!_maTayNghe.Equals(value))
                {
                    _maTayNghe = value;
                    PropertyHasChanged("MaTayNghe");
                }
            }
        }

        public decimal SoTienPhuCapTayNghe
        {
            get
            {
                CanReadProperty("SoTienPhuCapTayNghe", true);
                return _soTienPhuCapTayNghe;
            }
            set
            {
                CanWriteProperty("SoTienPhuCapTayNghe", true);
                if (!_soTienPhuCapTayNghe.Equals(value))
                {
                    _soTienPhuCapTayNghe = value;
                    PropertyHasChanged("SoTienPhuCapTayNghe");
                }
            }
        }

        public int MaMucDoHTCongViec
        {
            get
            {
                CanReadProperty("MaMucDoHTCongViec", true);
                return _maMucDoHTCongViec;
            }
            set
            {
                CanWriteProperty("MaMucDoHTCongViec", true);
                if (!_maMucDoHTCongViec.Equals(value))
                {
                    _maMucDoHTCongViec = value;
                    PropertyHasChanged("MaMucDoHTCongViec");
                }
            }
        }

        public decimal SoTienThuong
        {
            get
            {
                CanReadProperty("SoTienThuong", true);
                return _soTienThuong;
            }
            set
            {
                CanWriteProperty("SoTienThuong", true);
                if (!_soTienThuong.Equals(value))
                {
                    _soTienThuong = value;
                    PropertyHasChanged("SoTienThuong");
                }
            }
        }

        public int MaPhuCap
        {
            get
            {
                CanReadProperty("MaPhuCap", true);
                return _maPhuCap;
            }
            set
            {
                CanWriteProperty("MaPhuCap", true);
                if (!_maPhuCap.Equals(value))
                {
                    _maPhuCap = value;
                    PropertyHasChanged("MaPhuCap");
                }
            }
        }

        public int MaKhenThuong
        {
            get
            {
                CanReadProperty("MaKhenThuong", true);
                return _maKhenThuong;
            }
            set
            {
                CanWriteProperty("MaKhenThuong", true);
                if (!_maKhenThuong.Equals(value))
                {
                    _maKhenThuong = value;
                    PropertyHasChanged("MaKhenThuong");
                }
            }
        }

        public int MaThangLuong
        {
            get
            {
                CanReadProperty("MaThangLuong", true);
                return _maThangLuong;
            }
            set
            {
                CanWriteProperty("MaThangLuong", true);
                if (!_maThangLuong.Equals(value))
                {
                    _maThangLuong = value;
                    PropertyHasChanged("MaThangLuong");
                }
            }
        }

        public int MaNgachLuongCoBan
        {
            get
            {
                CanReadProperty("MaNgachLuongCoBan", true);
                return _maNgachLuongCoBan;
            }
            set
            {
                CanWriteProperty("MaNgachLuongCoBan", true);
                if (!_maNgachLuongCoBan.Equals(value))
                {
                    _maNgachLuongCoBan = value;
                    PropertyHasChanged("MaNgachLuongCoBan");
                }
            }
        }

        public int MaBacLuongCoBan
        {
            get
            {
                CanReadProperty("MaBacLuongCoBan", true);
                return _maBacLuongCoBan;
            }
            set
            {
                CanWriteProperty("MaBacLuongCoBan", true);
                if (!_maBacLuongCoBan.Equals(value))
                {
                    _maBacLuongCoBan = value;
                    PropertyHasChanged("MaBacLuongCoBan");
                }
            }
        }

        public decimal HeSoLuongCoBan
        {
            get
            {
                CanReadProperty("HeSoLuongCoBan", true);
                return _heSoLuongCoBan;
            }
            set
            {
                CanWriteProperty("HeSoLuongCoBan", true);
                if (!_heSoLuongCoBan.Equals(value))
                {
                    _heSoLuongCoBan = value;
                    PropertyHasChanged("HeSoLuongCoBan");
                }
            }
        }

		protected override object GetIdValue()
		{
			return _maNhanVien;
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
			// MaQLNhanVien
			//
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("MaQLNhanVien", 50));
			//
			// CardID
			//
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("CardID", 50));
			//
			// TenNhanVien
			//
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("TenNhanVien", 500));
			//
			// TenChucVu
			//
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("TenChucVu", 500));
			//
			// TenPhongBan
			//
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("TenPhongBan", 500));
			//
			// Cmnd
			//
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("Cmnd", 20));
			//
			// TenKiemNhiem
			//
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("TenKiemNhiem", 500));
			//
			// LoaiSucKhoe
			//
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("LoaiSucKhoe", 50));
			//
			// ChieuCao
			//
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("ChieuCao", 50));
			//
			// NhomMau
			//
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("NhomMau", 50));
			//
			// CanNang
			//
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("CanNang", 50));
			//
			// SoTaiKhoan
			//
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("SoTaiKhoan", 20));
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
			//TODO: Define authorization rules in TenNhanVien
			//AuthorizationRules.AllowRead("MaNhanVien", "TenNhanVienReadGroup");
			//AuthorizationRules.AllowRead("MaQLNhanVien", "TenNhanVienReadGroup");
			//AuthorizationRules.AllowRead("CardID", "TenNhanVienReadGroup");
			//AuthorizationRules.AllowRead("TenNhanVien", "TenNhanVienReadGroup");
			//AuthorizationRules.AllowRead("MaChucVu", "TenNhanVienReadGroup");
			//AuthorizationRules.AllowRead("TenChucVu", "TenNhanVienReadGroup");
			//AuthorizationRules.AllowRead("MaPhongBan", "TenNhanVienReadGroup");
			//AuthorizationRules.AllowRead("TenPhongBan", "TenNhanVienReadGroup");
			//AuthorizationRules.AllowRead("MaChiNhanh", "TenNhanVienReadGroup");
			//AuthorizationRules.AllowRead("TenChiNhanh", "TenNhanVienReadGroup");
			//AuthorizationRules.AllowRead("TenTo", "TenNhanVienReadGroup");
			//AuthorizationRules.AllowRead("MaTo", "TenNhanVienReadGroup");
			//AuthorizationRules.AllowRead("GioiTinh", "TenNhanVienReadGroup");
			//AuthorizationRules.AllowRead("Cmnd", "TenNhanVienReadGroup");
			//AuthorizationRules.AllowRead("NgayCap", "TenNhanVienReadGroup");
			//AuthorizationRules.AllowRead("NgayCapString", "TenNhanVienReadGroup");
			//AuthorizationRules.AllowRead("MaNoiCap", "TenNhanVienReadGroup");
			//AuthorizationRules.AllowRead("MaKiemNhiem", "TenNhanVienReadGroup");
			//AuthorizationRules.AllowRead("TenKiemNhiem", "TenNhanVienReadGroup");
			//AuthorizationRules.AllowRead("MaChucDanh", "TenNhanVienReadGroup");
			//AuthorizationRules.AllowRead("NgaySinh", "TenNhanVienReadGroup");
			//AuthorizationRules.AllowRead("NgaySinhString", "TenNhanVienReadGroup");
			//AuthorizationRules.AllowRead("MaNoiSinh", "TenNhanVienReadGroup");
			//AuthorizationRules.AllowRead("MaTinhThanhQueQuan", "TenNhanVienReadGroup");
			//AuthorizationRules.AllowRead("QuocTich", "TenNhanVienReadGroup");
			//AuthorizationRules.AllowRead("MaDanToc", "TenNhanVienReadGroup");
			//AuthorizationRules.AllowRead("MaTonGiao", "TenNhanVienReadGroup");
			//AuthorizationRules.AllowRead("NgayVaoNganh", "TenNhanVienReadGroup");
			//AuthorizationRules.AllowRead("NgayVaoNganhString", "TenNhanVienReadGroup");
			//AuthorizationRules.AllowRead("NgayTinhThamNien", "TenNhanVienReadGroup");
			//AuthorizationRules.AllowRead("NgayTinhThamNienString", "TenNhanVienReadGroup");
			//AuthorizationRules.AllowRead("LoaiSucKhoe", "TenNhanVienReadGroup");
			//AuthorizationRules.AllowRead("ChieuCao", "TenNhanVienReadGroup");
			//AuthorizationRules.AllowRead("NhomMau", "TenNhanVienReadGroup");
			//AuthorizationRules.AllowRead("CanNang", "TenNhanVienReadGroup");
			//AuthorizationRules.AllowRead("MaUuTienGD", "TenNhanVienReadGroup");
			//AuthorizationRules.AllowRead("MaUuTienBanThan", "TenNhanVienReadGroup");
			//AuthorizationRules.AllowRead("MaNguoiLap", "TenNhanVienReadGroup");
			//AuthorizationRules.AllowRead("NgayLap", "TenNhanVienReadGroup");
			//AuthorizationRules.AllowRead("NgayLapString", "TenNhanVienReadGroup");
			//AuthorizationRules.AllowRead("SoTaiKhoan", "TenNhanVienReadGroup");
			//AuthorizationRules.AllowRead("MaNganHang", "TenNhanVienReadGroup");
			//AuthorizationRules.AllowRead("TinhTrang", "TenNhanVienReadGroup");
			//AuthorizationRules.AllowRead("FileAnh", "TenNhanVienReadGroup");
			//AuthorizationRules.AllowRead("LoaiNV", "TenNhanVienReadGroup");
			//AuthorizationRules.AllowRead("MaThanhPhanGD", "TenNhanVienReadGroup");
			//AuthorizationRules.AllowRead("MaQuanHuyenNoiSinh", "TenNhanVienReadGroup");
			//AuthorizationRules.AllowRead("MaQuanHuyenQueQuan", "TenNhanVienReadGroup");

			//AuthorizationRules.AllowWrite("MaQLNhanVien", "TenNhanVienWriteGroup");
			//AuthorizationRules.AllowWrite("CardID", "TenNhanVienWriteGroup");
			//AuthorizationRules.AllowWrite("TenNhanVien", "TenNhanVienWriteGroup");
			//AuthorizationRules.AllowWrite("MaChucVu", "TenNhanVienWriteGroup");
			//AuthorizationRules.AllowWrite("TenChucVu", "TenNhanVienWriteGroup");
			//AuthorizationRules.AllowWrite("MaPhongBan", "TenNhanVienWriteGroup");
			//AuthorizationRules.AllowWrite("TenPhongBan", "TenNhanVienWriteGroup");
			//AuthorizationRules.AllowWrite("MaChiNhanh", "TenNhanVienWriteGroup");
			//AuthorizationRules.AllowWrite("TenChiNhanh", "TenNhanVienWriteGroup");
			//AuthorizationRules.AllowWrite("TenTo", "TenNhanVienWriteGroup");
			//AuthorizationRules.AllowWrite("MaTo", "TenNhanVienWriteGroup");
			//AuthorizationRules.AllowWrite("GioiTinh", "TenNhanVienWriteGroup");
			//AuthorizationRules.AllowWrite("Cmnd", "TenNhanVienWriteGroup");
			//AuthorizationRules.AllowWrite("NgayCapString", "TenNhanVienWriteGroup");
			//AuthorizationRules.AllowWrite("MaNoiCap", "TenNhanVienWriteGroup");
			//AuthorizationRules.AllowWrite("MaKiemNhiem", "TenNhanVienWriteGroup");
			//AuthorizationRules.AllowWrite("TenKiemNhiem", "TenNhanVienWriteGroup");
			//AuthorizationRules.AllowWrite("MaChucDanh", "TenNhanVienWriteGroup");
			//AuthorizationRules.AllowWrite("NgaySinhString", "TenNhanVienWriteGroup");
			//AuthorizationRules.AllowWrite("MaNoiSinh", "TenNhanVienWriteGroup");
			//AuthorizationRules.AllowWrite("MaTinhThanhQueQuan", "TenNhanVienWriteGroup");
			//AuthorizationRules.AllowWrite("QuocTich", "TenNhanVienWriteGroup");
			//AuthorizationRules.AllowWrite("MaDanToc", "TenNhanVienWriteGroup");
			//AuthorizationRules.AllowWrite("MaTonGiao", "TenNhanVienWriteGroup");
			//AuthorizationRules.AllowWrite("NgayVaoNganhString", "TenNhanVienWriteGroup");
			//AuthorizationRules.AllowWrite("NgayTinhThamNienString", "TenNhanVienWriteGroup");
			//AuthorizationRules.AllowWrite("LoaiSucKhoe", "TenNhanVienWriteGroup");
			//AuthorizationRules.AllowWrite("ChieuCao", "TenNhanVienWriteGroup");
			//AuthorizationRules.AllowWrite("NhomMau", "TenNhanVienWriteGroup");
			//AuthorizationRules.AllowWrite("CanNang", "TenNhanVienWriteGroup");
			//AuthorizationRules.AllowWrite("MaUuTienGD", "TenNhanVienWriteGroup");
			//AuthorizationRules.AllowWrite("MaUuTienBanThan", "TenNhanVienWriteGroup");
			//AuthorizationRules.AllowWrite("MaNguoiLap", "TenNhanVienWriteGroup");
			//AuthorizationRules.AllowWrite("NgayLapString", "TenNhanVienWriteGroup");
			//AuthorizationRules.AllowWrite("SoTaiKhoan", "TenNhanVienWriteGroup");
			//AuthorizationRules.AllowWrite("MaNganHang", "TenNhanVienWriteGroup");
			//AuthorizationRules.AllowWrite("TinhTrang", "TenNhanVienWriteGroup");
			//AuthorizationRules.AllowWrite("FileAnh", "TenNhanVienWriteGroup");
			//AuthorizationRules.AllowWrite("LoaiNV", "TenNhanVienWriteGroup");
			//AuthorizationRules.AllowWrite("MaThanhPhanGD", "TenNhanVienWriteGroup");
			//AuthorizationRules.AllowWrite("MaQuanHuyenNoiSinh", "TenNhanVienWriteGroup");
			//AuthorizationRules.AllowWrite("MaQuanHuyenQueQuan", "TenNhanVienWriteGroup");
		}


		public static bool CanGetObject()
		{
			//TODO: Define CanGetObject permission in TenNhanVien
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("TenNhanVienViewGroup"))
			//	return true;
			//return false;
		}

		public static bool CanAddObject()
		{
			//TODO: Define CanAddObject permission in TenNhanVien
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("TenNhanVienAddGroup"))
			//	return true;
			//return false;
		}

		public static bool CanEditObject()
		{
			//TODO: Define CanEditObject permission in TenNhanVien
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("TenNhanVienEditGroup"))
			//	return true;
			//return false;
		}

		public static bool CanDeleteObject()
		{
			//TODO: Define CanDeleteObject permission in TenNhanVien
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("TenNhanVienDeleteGroup"))
			//	return true;
			//return false;
		}
		#endregion //Authorization Rules

		#region Factory Methods
		private TenNV()
		{ /* require use of factory method */ }

        private TenNV(String ten)
        {
            this.TenNhanVien = ten;
            this.MarkAsChild();
        }

        public static TenNV NewTenNhanVien(string ten)
        {
            return new TenNV(ten);
        }

        public static TenNV NewTenNhanVien()
		{
			if (!CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a TenNhanVien");
			return DataPortal.Create<TenNV>(new CriteriaAll());
		}

		public static TenNV GetTenNhanVien(long maNhanVien)
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException("User not authorized to view a TenNhanVien");
			return DataPortal.Fetch<TenNV>(new Criteria(maNhanVien));
		}

		public static void DeleteTenNhanVien(long maNhanVien)
		{
			if (!CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a TenNhanVien");
			DataPortal.Delete(new Criteria(maNhanVien));
		}

		public override TenNV Save()
		{
			if (IsDeleted && !CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a TenNhanVien");
			else if (IsNew && !CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a TenNhanVien");
			else if (!CanEditObject())
				throw new System.Security.SecurityException("User not authorized to update a TenNhanVien");

			return base.Save();
		}

		#endregion //Factory Methods

		#region Child Factory Methods
        internal static TenNV NewNhanVienChild()
        {
            TenNV child = new TenNV();
            child.ValidationRules.CheckRules();
            child.MarkAsChild();
            return child;
        }		

		internal static TenNV GetTenNhanVien(SafeDataReader dr)
		{
			TenNV child =  new TenNV();
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
			public long MaNhanVien;

			public Criteria(long maNhanVien)
			{
				this.MaNhanVien = maNhanVien;
			}
		}

        private class CriteriaAll
        {           
            public CriteriaAll()
            {                
            }
        }

		#endregion //Criteria

		#region Data Access - Create
		[RunLocal]
		private void DataPortal_Create(CriteriaAll criteria)
		{
			//_maNhanVien = criteria.MaNhanVien;
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
					throw ex;
				}
			}//using
		}

		private void ExecuteFetch(SqlTransaction tr, Criteria criteria)
		{
			using (SqlCommand cm = tr.Connection.CreateCommand())
			{
				cm.Transaction = tr;
				cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_SelecttblnsNhanVien";

				cm.Parameters.AddWithValue("@MaNhanVien", criteria.MaNhanVien);

				using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
				{
                    if (dr.Read())
                    {
                        FetchObject(dr);
                       // ValidationRules.CheckRules();

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
			DataPortal_Delete(new Criteria(_maNhanVien));
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
                cm.CommandText = "spd_DeletetblnsNhanVien";

				cm.Parameters.AddWithValue("@MaNhanVien", criteria.MaNhanVien);

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
			//FetchChildren(dr);
		}

		private void FetchObject(SafeDataReader dr)
		{
            try
            {
                _maNhanVien = dr.GetInt64("MaNhanVien");
                _maQLNhanVien = dr.GetString("MaQLNhanVien");
                _cardID = dr.GetString("CardID");
                _tenNhanVien = dr.GetString("TenNhanVien");
                _maChucVu = dr.GetInt32("MaChucVu");
                _tenChucVu = dr.GetString("TenChucVu");
                _maBoPhan = dr.GetInt32("MaBoPhan");
                _tenBoPhan = dr.GetString("TenBoPhan");
                _gioiTinh = dr.GetBoolean("GioiTinh");
                _cmnd = dr.GetString("CMND");
                _ngayCap = dr.GetSmartDate("NgayCap", _ngayCap.EmptyIsMin);
                _maNoiCap = dr.GetInt32("MaNoiCap");
                _maKiemNhiem = dr.GetInt32("MaKiemNhiem");
                _tenKiemNhiem = dr.GetString("TenKiemNhiem");
                _maChucDanh = dr.GetInt32("MaChucDanh");
                _ngaySinh = dr.GetSmartDate("NgaySinh", _ngaySinh.EmptyIsMin);
                _maNoiSinh = dr.GetInt32("MaNoiSinh");
                _maTinhThanhQueQuan = dr.GetInt32("MaTinhThanhQueQuan");
                _quocTich = dr.GetInt32("QuocTich");
                _maDanToc = dr.GetInt32("MaDanToc");
                _maTonGiao = dr.GetInt32("MaTonGiao");
                _ngayVaoNganh = dr.GetSmartDate("NgayVaoNganh", _ngayVaoNganh.EmptyIsMin);
                _ngayTinhThamNien = dr.GetSmartDate("NgayTinhThamNien", _ngayTinhThamNien.EmptyIsMin);
                _loaiSucKhoe = dr.GetString("LoaiSucKhoe");
                _chieuCao = dr.GetString("ChieuCao");
                _nhomMau = dr.GetString("NhomMau");
                _canNang = dr.GetString("CanNang");
                _maUuTienGD = dr.GetInt32("MaUuTienGD");
                _maUuTienBanThan = dr.GetInt32("MaUuTienBanThan");
                _maNguoiLap = dr.GetInt64("MaNguoiLap");
                _ngayLap = dr.GetSmartDate("NgayLap", _ngayLap.EmptyIsMin);
                _soTaiKhoan = dr.GetString("SoTaiKhoan");
                _maNganHang = dr.GetInt32("MaNganHang");
                _tinhTrang = dr.GetByte("TinhTrang");
                _loaiNV = dr.GetInt32("LoaiNV");
                _maThanhPhanGD = dr.GetInt32("MaThanhPhanGD");
                _maQuanHuyenNoiSinh = dr.GetInt32("MaQuanHuyenNoiSinh");
                _maQuanHuyenQueQuan = dr.GetInt32("MaQuanHuyenQueQuan");
                _maCongViec = dr.GetInt32("MaCongViec");
                _maThangLuong = dr.GetInt32("MaThangLuong");
                _thangLuong = dr.GetDecimal("ThangLuong");
                _maNgachLuongCoBan = dr.GetInt32("MaNgachLuongCoBan");
                _maBacLuongCoBan = dr.GetInt32("MaBacLuongCoBan");
                _heSoLuongCoBan = dr.GetDecimal("HeSoLuong");
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
                cm.CommandText = "spd_InserttblnsNhanVien";

				AddInsertParameters(cm);

				cm.ExecuteNonQuery();
                _maNhanVien = (long)cm.Parameters["@MaDoiTuong"].Value;
			}//using
		}

		private void AddInsertParameters(SqlCommand cm)
		{
            cm.Parameters.AddWithValue("@LoaiDoiTuong", false);
            cm.Parameters.AddWithValue("@MaDoiTuong", _maNhanVien);
            cm.Parameters["@MaDoiTuong"].Direction = ParameterDirection.Output;

            cm.Parameters.AddWithValue("@MaQLNhanVien", _maQLNhanVien);
            cm.Parameters.AddWithValue("@CardID", _cardID);
            cm.Parameters.AddWithValue("@TenNhanVien", _tenNhanVien);
            cm.Parameters.AddWithValue("@MaChucVu", _maChucVu);
            cm.Parameters.AddWithValue("@TenChucVu", _tenChucVu);

            cm.Parameters.AddWithValue("@MaBoPhan", _maBoPhan);
            cm.Parameters.AddWithValue("@TenBoPhan", _tenBoPhan);

            if (_gioiTinh != false)
                cm.Parameters.AddWithValue("@GioiTinh", _gioiTinh);
            else
                cm.Parameters.AddWithValue("@GioiTinh", DBNull.Value);
            if (_cmnd.Length > 0)
                cm.Parameters.AddWithValue("@CMND", _cmnd);
            else
                cm.Parameters.AddWithValue("@CMND", DBNull.Value);
            cm.Parameters.AddWithValue("@NgayCap", _ngayCap.DBValue);
            if (_maNoiCap != 0)
                cm.Parameters.AddWithValue("@MaNoiCap", _maNoiCap);
            else
                cm.Parameters.AddWithValue("@MaNoiCap", DBNull.Value);
            if (_maKiemNhiem != 0)
                cm.Parameters.AddWithValue("@MaKiemNhiem", _maKiemNhiem);
            else
                cm.Parameters.AddWithValue("@MaKiemNhiem", DBNull.Value);
            if (_tenKiemNhiem.Length > 0)
                cm.Parameters.AddWithValue("@TenKiemNhiem", _tenKiemNhiem);
            else
                cm.Parameters.AddWithValue("@TenKiemNhiem", DBNull.Value);
            if (_maChucDanh != 0)
                cm.Parameters.AddWithValue("@MaChucDanh", _maChucDanh);
            else
                cm.Parameters.AddWithValue("@MaChucDanh", DBNull.Value);
            cm.Parameters.AddWithValue("@NgaySinh", _ngaySinh.DBValue);
            if (_maNoiSinh != 0)
                cm.Parameters.AddWithValue("@MaNoiSinh", _maNoiSinh);
            else
                cm.Parameters.AddWithValue("@MaNoiSinh", DBNull.Value);

            if (_maTinhThanhQueQuan != 0)
                cm.Parameters.AddWithValue("@MaTinhThanhQueQuan", _maTinhThanhQueQuan);
            else
                cm.Parameters.AddWithValue("@MaTinhThanhQueQuan", DBNull.Value);

            if (_quocTich != 0)
                cm.Parameters.AddWithValue("@QuocTich", _quocTich);
            else
                cm.Parameters.AddWithValue("@QuocTich", DBNull.Value);

            if (_maDanToc != 0)
                cm.Parameters.AddWithValue("@MaDanToc", _maDanToc);
            else
                cm.Parameters.AddWithValue("@MaDanToc", DBNull.Value);

            if (_maTonGiao != 0)
                cm.Parameters.AddWithValue("@MaTonGiao", _maTonGiao);
            else
                cm.Parameters.AddWithValue("@MaTonGiao", DBNull.Value);

            cm.Parameters.AddWithValue("@NgayVaoNganh", _ngayVaoNganh.DBValue);
            cm.Parameters.AddWithValue("@NgayTinhThamNien", _ngayTinhThamNien.DBValue);

            if (_loaiSucKhoe.Length > 0)
                cm.Parameters.AddWithValue("@LoaiSucKhoe", _loaiSucKhoe);
            else
                cm.Parameters.AddWithValue("@LoaiSucKhoe", DBNull.Value);

            if (_chieuCao.Length > 0)
                cm.Parameters.AddWithValue("@ChieuCao", _chieuCao);
            else
                cm.Parameters.AddWithValue("@ChieuCao", DBNull.Value);

            if (_nhomMau.Length > 0)
                cm.Parameters.AddWithValue("@NhomMau", _nhomMau);
            else
                cm.Parameters.AddWithValue("@NhomMau", DBNull.Value);

            if (_canNang.Length > 0)
                cm.Parameters.AddWithValue("@CanNang", _canNang);
            else
                cm.Parameters.AddWithValue("@CanNang", DBNull.Value);

            if (_maUuTienGD != 0)
                cm.Parameters.AddWithValue("@MaUuTienGD", _maUuTienGD);
            else
                cm.Parameters.AddWithValue("@MaUuTienGD", DBNull.Value);

            if (_maUuTienBanThan != 0)
                cm.Parameters.AddWithValue("@MaUuTienBanThan", _maUuTienBanThan);
            else
                cm.Parameters.AddWithValue("@MaUuTienBanThan", DBNull.Value);

            cm.Parameters.AddWithValue("@MaNguoiLap", _maNguoiLap);
            cm.Parameters.AddWithValue("@NgayLap", _ngayLap.DBValue);

            if (_soTaiKhoan.Length > 0)
                cm.Parameters.AddWithValue("@SoTaiKhoan", _soTaiKhoan);
            else
                cm.Parameters.AddWithValue("@SoTaiKhoan", DBNull.Value);

            if (_maNganHang != 0)
                cm.Parameters.AddWithValue("@MaNganHang", _maNganHang);
            else
                cm.Parameters.AddWithValue("@MaNganHang", DBNull.Value);
            cm.Parameters.AddWithValue("@TinhTrang", _tinhTrang);

            //if (_fileAnh.Length > 0)
            //{
            //    cm.Parameters.AddWithValue("@FileAnh", DBNull.Value);
            //}
            //else
            //    cm.Parameters.AddWithValue("@FileAnh", _fileAnh);  

            cm.Parameters.AddWithValue("@LoaiNV", _loaiNV);
            cm.Parameters.AddWithValue("@MaThanhPhanGD", _maThanhPhanGD);
            cm.Parameters.AddWithValue("@MaQuanHuyenNoiSinh", _maQuanHuyenNoiSinh);
            cm.Parameters.AddWithValue("@MaQuanHuyenQueQuan", _maQuanHuyenQueQuan);
            cm.Parameters.AddWithValue("@MaCongViec", _maCongViec);
            cm.Parameters.AddWithValue("@ThangLuong", _thangLuong);
            cm.Parameters.AddWithValue("@MaThangLuong", _maThangLuong);
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
                cm.CommandText = "spd_UpdatetblnsNhanVien_PhucHoi";

				AddUpdateParameters(cm);

				cm.ExecuteNonQuery();

			}//using
		}

		private void AddUpdateParameters(SqlCommand cm)
		{
            cm.Parameters.AddWithValue("@MaNhanVien", _maNhanVien);
            cm.Parameters.AddWithValue("@MaQLNhanVien", _maQLNhanVien);
            cm.Parameters.AddWithValue("@CardID", _cardID);
            cm.Parameters.AddWithValue("@TenNhanVien", _tenNhanVien);
            cm.Parameters.AddWithValue("@MaChucVu", _maChucVu);
            if (_tenChucVu.Length > 0)
                cm.Parameters.AddWithValue("@TenChucVu", _tenChucVu);
            else
                cm.Parameters.AddWithValue("@TenChucVu", DBNull.Value);
            cm.Parameters.AddWithValue("@MaBoPhan", _maBoPhan);
            cm.Parameters.AddWithValue("@TenBoPhan", _tenBoPhan);

            if (_gioiTinh != false)
                cm.Parameters.AddWithValue("@GioiTinh", _gioiTinh);
            else
                cm.Parameters.AddWithValue("@GioiTinh", DBNull.Value);
            if (_cmnd.Length > 0)
                cm.Parameters.AddWithValue("@CMND", _cmnd);
            else
                cm.Parameters.AddWithValue("@CMND", DBNull.Value);
            cm.Parameters.AddWithValue("@NgayCap", _ngayCap.DBValue);
            if (_maNoiCap != 0)
                cm.Parameters.AddWithValue("@MaNoiCap", _maNoiCap);
            else
                cm.Parameters.AddWithValue("@MaNoiCap", DBNull.Value);
            if (_maKiemNhiem != 0)
                cm.Parameters.AddWithValue("@MaKiemNhiem", _maKiemNhiem);
            else
                cm.Parameters.AddWithValue("@MaKiemNhiem", DBNull.Value);
            if (_tenKiemNhiem.Length > 0)
                cm.Parameters.AddWithValue("@TenKiemNhiem", _tenKiemNhiem);
            else
                cm.Parameters.AddWithValue("@TenKiemNhiem", DBNull.Value);
            if (_maChucDanh != 0)
                cm.Parameters.AddWithValue("@MaChucDanh", _maChucDanh);
            else
                cm.Parameters.AddWithValue("@MaChucDanh", DBNull.Value);
            cm.Parameters.AddWithValue("@NgaySinh", _ngaySinh.DBValue);
            if (_maNoiSinh != 0)
                cm.Parameters.AddWithValue("@MaNoiSinh", _maNoiSinh);
            else
                cm.Parameters.AddWithValue("@MaNoiSinh", DBNull.Value);
            if (_maTinhThanhQueQuan != 0)
                cm.Parameters.AddWithValue("@MaTinhThanhQueQuan", _maTinhThanhQueQuan);
            else
                cm.Parameters.AddWithValue("@MaTinhThanhQueQuan", DBNull.Value);
            if (_quocTich != 0)
                cm.Parameters.AddWithValue("@QuocTich", _quocTich);
            else
                cm.Parameters.AddWithValue("@QuocTich", DBNull.Value);
            if (_maDanToc != 0)
                cm.Parameters.AddWithValue("@MaDanToc", _maDanToc);
            else
                cm.Parameters.AddWithValue("@MaDanToc", DBNull.Value);
            if (_maTonGiao != 0)
                cm.Parameters.AddWithValue("@MaTonGiao", _maTonGiao);
            else
                cm.Parameters.AddWithValue("@MaTonGiao", DBNull.Value);
            cm.Parameters.AddWithValue("@NgayVaoNganh", _ngayVaoNganh.DBValue);
            cm.Parameters.AddWithValue("@NgayTinhThamNien", _ngayTinhThamNien.DBValue);
            if (_loaiSucKhoe.Length > 0)
                cm.Parameters.AddWithValue("@LoaiSucKhoe", _loaiSucKhoe);
            else
                cm.Parameters.AddWithValue("@LoaiSucKhoe", DBNull.Value);
            if (_chieuCao.Length > 0)
                cm.Parameters.AddWithValue("@ChieuCao", _chieuCao);
            else
                cm.Parameters.AddWithValue("@ChieuCao", DBNull.Value);
            if (_nhomMau.Length > 0)
                cm.Parameters.AddWithValue("@NhomMau", _nhomMau);
            else
                cm.Parameters.AddWithValue("@NhomMau", DBNull.Value);
            if (_canNang.Length > 0)
                cm.Parameters.AddWithValue("@CanNang", _canNang);
            else
                cm.Parameters.AddWithValue("@CanNang", DBNull.Value);
            if (_maUuTienGD != 0)
                cm.Parameters.AddWithValue("@MaUuTienGD", _maUuTienGD);
            else
                cm.Parameters.AddWithValue("@MaUuTienGD", DBNull.Value);
            if (_maUuTienBanThan != 0)
                cm.Parameters.AddWithValue("@MaUuTienBanThan", _maUuTienBanThan);
            else
                cm.Parameters.AddWithValue("@MaUuTienBanThan", DBNull.Value);
            cm.Parameters.AddWithValue("@MaNguoiLap", _maNguoiLap);
            cm.Parameters.AddWithValue("@NgayLap", _ngayLap.DBValue);
            if (_soTaiKhoan.Length > 0)
                cm.Parameters.AddWithValue("@SoTaiKhoan", _soTaiKhoan);
            else
                cm.Parameters.AddWithValue("@SoTaiKhoan", DBNull.Value);
            if (_maNganHang != 0)
                cm.Parameters.AddWithValue("@MaNganHang", _maNganHang);
            else
                cm.Parameters.AddWithValue("@MaNganHang", DBNull.Value);
            cm.Parameters.AddWithValue("@TinhTrang", _tinhTrang);
             
            cm.Parameters.AddWithValue("@LoaiNV", _loaiNV);
            if (_maThanhPhanGD != 0)
                cm.Parameters.AddWithValue("@MaThanhPhanGD", _maThanhPhanGD);
            else
                cm.Parameters.AddWithValue("@MaThanhPhanGD", DBNull.Value);
            
            cm.Parameters.AddWithValue("@MaQuanHuyenNoiSinh", _maQuanHuyenNoiSinh);
            cm.Parameters.AddWithValue("@MaQuanHuyenQueQuan", _maQuanHuyenQueQuan);
            cm.Parameters.AddWithValue("@MaCongViec", _maCongViec);
            cm.Parameters.AddWithValue("@ThangLuong", _thangLuong);
            cm.Parameters.AddWithValue("@MaThangLuong", _maThangLuong);
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

			ExecuteDelete(tr, new Criteria(_maNhanVien));
			MarkNew();
		}
		#endregion //Data Access - Delete
		#endregion //Data Access
	}
}
