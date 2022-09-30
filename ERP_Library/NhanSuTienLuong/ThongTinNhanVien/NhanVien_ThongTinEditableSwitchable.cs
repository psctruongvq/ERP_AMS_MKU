
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{ 
	[Serializable()] 
	public class NhanVien_ThongTin : Csla.BusinessBase<NhanVien_ThongTin>
	{
		#region Business Properties and Methods

		//declare members
		private long _maNhanVien = 0;
		private string _maQLNhanVien = string.Empty;
        private string _maQLBoPhan = string.Empty;
		private string _tenNhanVien = string.Empty;
		private string _tenChucVu = string.Empty;
        private string _maChucVu = string.Empty;
        private string _tenChucDanh = string.Empty;
        private string _maChucDanh = string.Empty;
		private string _tenBoPhan = string.Empty;
		private string _gioiTinh = string.Empty;
		private string _cmnd = string.Empty;
		private DateTime _ngaySinh = DateTime.Today.Date;
		private string _tinhThanhNoiSinh = string.Empty;
		private string _danToc = string.Empty;
		private string _tenTonGiao = string.Empty;
		private string _tinhTrang = string.Empty;
		private DateTime _ngayVaoNganh = DateTime.Today.Date;
		private DateTime _ngayTinhThamNien = DateTime.Today.Date;
		private string _diaChi = string.Empty;
		private string _theNhaBao = string.Empty;
		private string _maSoThue = string.Empty;
		private string _loaiNhanVien = string.Empty;
		private string _tinhTrangHonNhan = string.Empty;
		private string _soTaiKhoan = string.Empty;
		private string _tenNganHang = string.Empty;
		private string _ngachLuong = string.Empty;
		private string _tenNgachLuong = string.Empty;
		private string _bacLuong = string.Empty;
		private decimal _heSoLuong = 0;
		private decimal _heSoVuotKhung = 0;
		private DateTime _mocLenLuong = DateTime.Today.Date;
		private string _ngachLuongBH = string.Empty;
		private string _tenNgachLuongBH = string.Empty;
		private string _bacLuongBH = string.Empty;
		private decimal _heSoLuongBaoHiem = 0;
		private DateTime _mocLenLuongBaoHiem = DateTime.Today.Date;
		private decimal _heSoVuotKhungBH = 0;
		private decimal _heSoPhuCapChucVu = 0;
		private decimal _heSoLuongNoiBo = 0;
		private decimal _heSoLuongBoSung = 0;
		private decimal _heSoBu = 0;
		private decimal _heSoDocHai = 0;
		private bool _phuCapHC = false;
		private string _chuyenNganhDaoTao = string.Empty;
		private string _trinhDoHocVan = string.Empty;
		private string _trinhDoTinHoc = string.Empty;
		private string _tenNgoaiNgu = string.Empty;
		private string _trinhDoNgoaiNgu = string.Empty;
		private string _tenQuanLyKinhTe = string.Empty;
		private string _tenQuanLyNhaNuoc = string.Empty;
		private string _lyLuanCT = string.Empty;
		private string _tenChungChi = string.Empty;
        private DateTime _ngayCap = DateTime.Today.Date;
        private string _noiCap = string.Empty;
        private string _soTheDang = string.Empty;

      
        private DateTime _ngayVaoDangDB = DateTime.Today.Date;
        private DateTime _ngayVaoDangCT = DateTime.Today.Date;

		[System.ComponentModel.DataObjectField(true, false)]
        public string SoTheDang
        {
            get { return _soTheDang; }
            set { _soTheDang = value; }
        }
		public long MaNhanVien
		{
			get
			{
				return _maNhanVien;
			}
		}

		public string MaQLNhanVien
		{
			get
			{
				return _maQLNhanVien;
			}
			set
			{
				if (value == null) value = string.Empty;
				if (!_maQLNhanVien.Equals(value))
				{
					_maQLNhanVien = value;
					PropertyHasChanged("MaQLNhanVien");
				}
			}
		}
        public string MaQLBoPhan
        {
            get
            {
                return _maQLBoPhan;
            }
            set
            {
                if (value == null) value = string.Empty;
                if (!_maQLBoPhan.Equals(value))
                {
                    _maQLBoPhan = value;
                    PropertyHasChanged("MaQLBoPhan");
                }
            }
        }
		public string TenNhanVien
		{
			get
			{
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
        public string NoiCap
        {
            get
            {
                return _noiCap;
            }
            set
            {              
                if (!_noiCap.Equals(value))
                {
                    _noiCap = value;
                    PropertyHasChanged("NoiCap");
                }
            }
        }

		public string TenChucVu
		{
			get
			{
				return _tenChucVu;
			}
			set
			{
				if (value == null) value = string.Empty;
				if (!_tenChucVu.Equals(value))
				{
					_tenChucVu = value;
					PropertyHasChanged("TenChucVu");
				}
			}
		}

        public string MaChucVu
        {
            get
            {
                return _maChucVu;
            }
            set
            {
                if (value == null) value = string.Empty;
                if (!_maChucVu.Equals(value))
                {
                    _maChucVu = value;
                    PropertyHasChanged("MaChucVu");
                }
            }
        }

        public string TenChucDanh
        {
            get
            {
                return _tenChucDanh;
            }
            set
            {
                if (value == null) value = string.Empty;
                if (!_tenChucDanh.Equals(value))
                {
                    _tenChucVu = value;
                    PropertyHasChanged("TenChucDanh");
                }
            }
        }

        public string MaChucDanh
        {
            get
            {
                return _maChucDanh;
            }
            set
            {
                if (value == null) value = string.Empty;
                if (!_maChucDanh.Equals(value))
                {
                    _maChucDanh = value;
                    PropertyHasChanged("MaChucDanh");
                }
            }
        }

      

		public string TenBoPhan
		{
			get
			{
				return _tenBoPhan;
			}
			set
			{
				if (value == null) value = string.Empty;
				if (!_tenBoPhan.Equals(value))
				{
					_tenBoPhan = value;
					PropertyHasChanged("TenBoPhan");
				}
			}
		}

		public string GioiTinh
		{
			get
			{
				return _gioiTinh;
			}
			set
			{
				if (value == null) value = string.Empty;
				if (!_gioiTinh.Equals(value))
				{
					_gioiTinh = value;
					PropertyHasChanged("GioiTinh");
				}
			}
		}

		public string Cmnd
		{
			get
			{
				return _cmnd;
			}
			set
			{
				if (value == null) value = string.Empty;
				if (!_cmnd.Equals(value))
				{
					_cmnd = value;
					PropertyHasChanged("Cmnd");
				}
			}
		}

		public DateTime NgaySinh
		{
			get
			{
				return _ngaySinh;
			}
			set
			{
				if (!_ngaySinh.Equals(value))
				{
					_ngaySinh = value;
					PropertyHasChanged("NgaySinh");
				}
			}
		}

		public string TinhThanhNoiSinh
		{
			get
			{
				return _tinhThanhNoiSinh;
			}
			set
			{
				if (value == null) value = string.Empty;
				if (!_tinhThanhNoiSinh.Equals(value))
				{
					_tinhThanhNoiSinh = value;
					PropertyHasChanged("TinhThanhNoiSinh");
				}
			}
		}

		public string DanToc
		{
			get
			{
				return _danToc;
			}
			set
			{
				if (value == null) value = string.Empty;
				if (!_danToc.Equals(value))
				{
					_danToc = value;
					PropertyHasChanged("DanToc");
				}
			}
		}

		public string TenTonGiao
		{
			get
			{
				return _tenTonGiao;
			}
			set
			{
				if (value == null) value = string.Empty;
				if (!_tenTonGiao.Equals(value))
				{
					_tenTonGiao = value;
					PropertyHasChanged("TenTonGiao");
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
				if (value == null) value = string.Empty;
				if (!_tinhTrang.Equals(value))
				{
					_tinhTrang = value;
					PropertyHasChanged("TinhTrang");
				}
			}
		}

		public DateTime NgayVaoNganh
		{
			get
			{
				return _ngayVaoNganh;
			}
			set
			{
				if (!_ngayVaoNganh.Equals(value))
				{
					_ngayVaoNganh = value;
					PropertyHasChanged("NgayVaoNganh");
				}
			}
		}

		public DateTime NgayTinhThamNien
		{
			get
			{
				return _ngayTinhThamNien;
			}
			set
			{
				if (!_ngayTinhThamNien.Equals(value))
				{
					_ngayTinhThamNien = value;
					PropertyHasChanged("NgayTinhThamNien");
				}
			}
		}

		public string DiaChi
		{
			get
			{
				return _diaChi;
			}
			set
			{
				if (value == null) value = string.Empty;
				if (!_diaChi.Equals(value))
				{
					_diaChi = value;
					PropertyHasChanged("DiaChi");
				}
			}
		}

		public string TheNhaBao
		{
			get
			{
				return _theNhaBao;
			}
			set
			{
				if (value == null) value = string.Empty;
				if (!_theNhaBao.Equals(value))
				{
					_theNhaBao = value;
					PropertyHasChanged("TheNhaBao");
				}
			}
		}

		public string MaSoThue
		{
			get
			{
				return _maSoThue;
			}
			set
			{
				if (value == null) value = string.Empty;
				if (!_maSoThue.Equals(value))
				{
					_maSoThue = value;
					PropertyHasChanged("MaSoThue");
				}
			}
		}

		public string LoaiNhanVien
		{
			get
			{
				return _loaiNhanVien;
			}
			set
			{
				if (value == null) value = string.Empty;
				if (!_loaiNhanVien.Equals(value))
				{
					_loaiNhanVien = value;
					PropertyHasChanged("LoaiNhanVien");
				}
			}
		}

		public string TinhTrangHonNhan
		{
			get
			{
				return _tinhTrangHonNhan;
			}
			set
			{
				if (value == null) value = string.Empty;
				if (!_tinhTrangHonNhan.Equals(value))
				{
					_tinhTrangHonNhan = value;
					PropertyHasChanged("TinhTrangHonNhan");
				}
			}
		}

		public string SoTaiKhoan
		{
			get
			{
				return _soTaiKhoan;
			}
			set
			{
				if (value == null) value = string.Empty;
				if (!_soTaiKhoan.Equals(value))
				{
					_soTaiKhoan = value;
					PropertyHasChanged("SoTaiKhoan");
				}
			}
		}

		public string TenNganHang
		{
			get
			{
				return _tenNganHang;
			}
			set
			{
				if (value == null) value = string.Empty;
				if (!_tenNganHang.Equals(value))
				{
					_tenNganHang = value;
					PropertyHasChanged("TenNganHang");
				}
			}
		}

		public string NgachLuong
		{
			get
			{
				return _ngachLuong;
			}
			set
			{
				if (value == null) value = string.Empty;
				if (!_ngachLuong.Equals(value))
				{
					_ngachLuong = value;
					PropertyHasChanged("NgachLuong");
				}
			}
		}

		public string TenNgachLuong
		{
			get
			{
				return _tenNgachLuong;
			}
			set
			{
				if (value == null) value = string.Empty;
				if (!_tenNgachLuong.Equals(value))
				{
					_tenNgachLuong = value;
					PropertyHasChanged("TenNgachLuong");
				}
			}
		}

		public string BacLuong
		{
			get
			{
				return _bacLuong;
			}
			set
			{
				if (value == null) value = string.Empty;
				if (!_bacLuong.Equals(value))
				{
					_bacLuong = value;
					PropertyHasChanged("BacLuong");
				}
			}
		}

		public decimal HeSoLuong
		{
			get
			{
				return _heSoLuong;
			}
			set
			{
				if (!_heSoLuong.Equals(value))
				{
					_heSoLuong = value;
					PropertyHasChanged("HeSoLuong");
				}
			}
		}

		public decimal HeSoVuotKhung
		{
			get
			{
				return _heSoVuotKhung;
			}
			set
			{
				if (!_heSoVuotKhung.Equals(value))
				{
					_heSoVuotKhung = value;
					PropertyHasChanged("HeSoVuotKhung");
				}
			}
		}

		public DateTime MocLenLuong
		{
			get
			{
				return _mocLenLuong;
			}
			set
			{
				if (!_mocLenLuong.Equals(value))
				{
					_mocLenLuong = value;
					PropertyHasChanged("MocLenLuong");
				}
			}
		}

        public DateTime NgayCap
        {
            get
            {
                return _ngayCap;
            }
            set
            {
                if (!_ngayCap.Equals(value))
                {
                    _ngayCap = value;
                    PropertyHasChanged("NgayCap");
                }
            }
        }

        public DateTime NgayVaoDangDB
        {
            get
            {
                return _ngayVaoDangDB;
            }
            set
            {
                if (!_ngayVaoDangDB.Equals(value))
                {
                    _ngayVaoDangDB = value;
                    PropertyHasChanged("NgayVaoDangDB");
                }
            }
        }

        public DateTime NgayVaoDangCT
        {
            get
            {
                return _ngayVaoDangCT;
            }
            set
            {
                if (!_ngayVaoDangCT.Equals(value))
                {
                    _ngayVaoDangCT = value;
                    PropertyHasChanged("NgayVaoDangCT");
                }
            }
        }


		public string NgachLuongBH
		{
			get
			{
				return _ngachLuongBH;
			}
			set
			{
				if (value == null) value = string.Empty;
				if (!_ngachLuongBH.Equals(value))
				{
					_ngachLuongBH = value;
					PropertyHasChanged("NgachLuongBH");
				}
			}
		}

		public string TenNgachLuongBH
		{
			get
			{
				return _tenNgachLuongBH;
			}
			set
			{
				if (value == null) value = string.Empty;
				if (!_tenNgachLuongBH.Equals(value))
				{
					_tenNgachLuongBH = value;
					PropertyHasChanged("TenNgachLuongBH");
				}
			}
		}

		public string BacLuongBH
		{
			get
			{
				return _bacLuongBH;
			}
			set
			{
				if (value == null) value = string.Empty;
				if (!_bacLuongBH.Equals(value))
				{
					_bacLuongBH = value;
					PropertyHasChanged("BacLuongBH");
				}
			}
		}

		public decimal HeSoLuongBaoHiem
		{
			get
			{
				return _heSoLuongBaoHiem;
			}
			set
			{
				if (!_heSoLuongBaoHiem.Equals(value))
				{
					_heSoLuongBaoHiem = value;
					PropertyHasChanged("HeSoLuongBaoHiem");
				}
			}
		}

		public DateTime MocLenLuongBaoHiem
		{
			get
			{
				return _mocLenLuongBaoHiem;
			}
			set
			{
				if (!_mocLenLuongBaoHiem.Equals(value))
				{
					_mocLenLuongBaoHiem = value;
					PropertyHasChanged("MocLenLuongBaoHiem");
				}
			}
		}

		public decimal HeSoVuotKhungBH
		{
			get
			{
				return _heSoVuotKhungBH;
			}
			set
			{
				if (!_heSoVuotKhungBH.Equals(value))
				{
					_heSoVuotKhungBH = value;
					PropertyHasChanged("HeSoVuotKhungBH");
				}
			}
		}

		public decimal HeSoPhuCapChucVu
		{
			get
			{
				return _heSoPhuCapChucVu;
			}
			set
			{
				if (!_heSoPhuCapChucVu.Equals(value))
				{
					_heSoPhuCapChucVu = value;
					PropertyHasChanged("HeSoPhuCapChucVu");
				}
			}
		}

		public decimal HeSoLuongNoiBo
		{
			get
			{
				return _heSoLuongNoiBo;
			}
			set
			{
				if (!_heSoLuongNoiBo.Equals(value))
				{
					_heSoLuongNoiBo = value;
					PropertyHasChanged("HeSoLuongNoiBo");
				}
			}
		}

		public decimal HeSoLuongBoSung
		{
			get
			{
				return _heSoLuongBoSung;
			}
			set
			{
				if (!_heSoLuongBoSung.Equals(value))
				{
					_heSoLuongBoSung = value;
					PropertyHasChanged("HeSoLuongBoSung");
				}
			}
		}

		public decimal HeSoBu
		{
			get
			{
				return _heSoBu;
			}
			set
			{
				if (!_heSoBu.Equals(value))
				{
					_heSoBu = value;
					PropertyHasChanged("HeSoBu");
				}
			}
		}

		public decimal HeSoDocHai
		{
			get
			{
				return _heSoDocHai;
			}
			set
			{
				if (!_heSoDocHai.Equals(value))
				{
					_heSoDocHai = value;
					PropertyHasChanged("HeSoDocHai");
				}
			}
		}

		public bool PhuCapHC
		{
			get
			{
				return _phuCapHC;
			}
			set
			{
				if (!_phuCapHC.Equals(value))
				{
					_phuCapHC = value;
					PropertyHasChanged("PhuCapHC");
				}
			}
		}

		public string ChuyenNganhDaoTao
		{
			get
			{
				return _chuyenNganhDaoTao;
			}
			set
			{
				if (value == null) value = string.Empty;
				if (!_chuyenNganhDaoTao.Equals(value))
				{
					_chuyenNganhDaoTao = value;
					PropertyHasChanged("ChuyenNganhDaoTao");
				}
			}
		}

		public string TrinhDoHocVan
		{
			get
			{
				return _trinhDoHocVan;
			}
			set
			{
				if (value == null) value = string.Empty;
				if (!_trinhDoHocVan.Equals(value))
				{
					_trinhDoHocVan = value;
					PropertyHasChanged("TrinhDoHocVan");
				}
			}
		}

		public string TrinhDoTinHoc
		{
			get
			{
				return _trinhDoTinHoc;
			}
			set
			{
				if (value == null) value = string.Empty;
				if (!_trinhDoTinHoc.Equals(value))
				{
					_trinhDoTinHoc = value;
					PropertyHasChanged("TrinhDoTinHoc");
				}
			}
		}

		public string TenNgoaiNgu
		{
			get
			{
				return _tenNgoaiNgu;
			}
			set
			{
				if (value == null) value = string.Empty;
				if (!_tenNgoaiNgu.Equals(value))
				{
					_tenNgoaiNgu = value;
					PropertyHasChanged("TenNgoaiNgu");
				}
			}
		}

		public string TrinhDoNgoaiNgu
		{
			get
			{
				return _trinhDoNgoaiNgu;
			}
			set
			{
				if (value == null) value = string.Empty;
				if (!_trinhDoNgoaiNgu.Equals(value))
				{
					_trinhDoNgoaiNgu = value;
					PropertyHasChanged("TrinhDoNgoaiNgu");
				}
			}
		}

		public string TenQuanLyKinhTe
		{
			get
			{
				return _tenQuanLyKinhTe;
			}
			set
			{
				if (value == null) value = string.Empty;
				if (!_tenQuanLyKinhTe.Equals(value))
				{
					_tenQuanLyKinhTe = value;
					PropertyHasChanged("TenQuanLyKinhTe");
				}
			}
		}

		public string TenQuanLyNhaNuoc
		{
			get
			{
				return _tenQuanLyNhaNuoc;
			}
			set
			{
				if (value == null) value = string.Empty;
				if (!_tenQuanLyNhaNuoc.Equals(value))
				{
					_tenQuanLyNhaNuoc = value;
					PropertyHasChanged("TenQuanLyNhaNuoc");
				}
			}
		}

		public string LyLuanCT
		{
			get
			{
				return _lyLuanCT;
			}
			set
			{
				if (value == null) value = string.Empty;
				if (!_lyLuanCT.Equals(value))
				{
					_lyLuanCT = value;
					PropertyHasChanged("LyLuanCT");
				}
			}
		}

		public string TenChungChi
		{
			get
			{
				return _tenChungChi;
			}
			set
			{
				if (value == null) value = string.Empty;
				if (!_tenChungChi.Equals(value))
				{
					_tenChungChi = value;
					PropertyHasChanged("TenChungChi");
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
			// TenNhanVien
			//
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("TenNhanVien", 50));
			//
			// TenChucVu
			//
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("TenChucVu", 50));
			//
			// TenBoPhan
			//
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("TenBoPhan", 50));
			//
			// GioiTinh
			//
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("GioiTinh", 50));
			//
			// Cmnd
			//
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("Cmnd", 50));
			//
			// TinhThanhNoiSinh
			//
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("TinhThanhNoiSinh", 50));
			//
			// DanToc
			//
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("DanToc", 50));
			//
			// TenTonGiao
			//
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("TenTonGiao", 50));
			//
			// TinhTrang
			//
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("TinhTrang", 50));
			//
			// DiaChi
			//
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("DiaChi", 500));
			//
			// TheNhaBao
			//
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("TheNhaBao", 50));
			//
			// MaSoThue
			//
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("MaSoThue", 50));
			//
			// LoaiNhanVien
			//
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("LoaiNhanVien", 50));
			//
			// TinhTrangHonNhan
			//
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("TinhTrangHonNhan", 50));
			//
			// SoTaiKhoan
			//
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("SoTaiKhoan", 50));
			//
			// TenNganHang
			//
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("TenNganHang", 50));
			//
			// NgachLuong
			//
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("NgachLuong", 50));
			//
			// TenNgachLuong
			//
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("TenNgachLuong", 50));
			//
			// BacLuong
			//
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("BacLuong", 50));
			//
			// NgachLuongBH
			//
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("NgachLuongBH", 50));
			//
			// TenNgachLuongBH
			//
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("TenNgachLuongBH", 50));
			//
			// BacLuongBH
			//
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("BacLuongBH", 50));
			//
			// ChuyenNganhDaoTao
			//
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("ChuyenNganhDaoTao", 50));
			//
			// TrinhDoHocVan
			//
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("TrinhDoHocVan", 50));
			//
			// TrinhDoTinHoc
			//
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("TrinhDoTinHoc", 50));
			//
			// TenNgoaiNgu
			//
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("TenNgoaiNgu", 50));
			//
			// TrinhDoNgoaiNgu
			//
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("TrinhDoNgoaiNgu", 50));
			//
			// TenQuanLyKinhTe
			//
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("TenQuanLyKinhTe", 50));
			//
			// TenQuanLyNhaNuoc
			//
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("TenQuanLyNhaNuoc", 50));
			//
			// LyLuanCT
			//
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("LyLuanCT", 50));
			//
			// TenChungChi
			//
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("TenChungChi", 50));
		}

		protected override void AddBusinessRules()
		{
			AddCommonRules();
			AddCustomRules();
		}
		#endregion //Validation Rules

		#region Factory Methods
		private NhanVien_ThongTin()
		{ /* require use of factory method */ }

		public static NhanVien_ThongTin NewNhanVien_ThongTin(long maNhanVien)
		{
			return DataPortal.Create<NhanVien_ThongTin>(new Criteria(maNhanVien));
		}

		public static NhanVien_ThongTin GetNhanVien_ThongTin(long maNhanVien)
		{
			return DataPortal.Fetch<NhanVien_ThongTin>(new Criteria(maNhanVien));
		}

		public static void DeleteNhanVien_ThongTin(long maNhanVien)
		{
			DataPortal.Delete(new Criteria(maNhanVien));
		}

		#endregion //Factory Methods

		#region Child Factory Methods
		private NhanVien_ThongTin( long maNhanVien)
		{
			this._maNhanVien = maNhanVien;
		}

		internal static NhanVien_ThongTin NewNhanVien_ThongTinChild(long maNhanVien)
		{
			NhanVien_ThongTin child = new NhanVien_ThongTin(maNhanVien);
			child.ValidationRules.CheckRules();
			child.MarkAsChild();
			return child;
		}

		internal static NhanVien_ThongTin GetNhanVien_ThongTin(SafeDataReader dr)
		{
			NhanVien_ThongTin child =  new NhanVien_ThongTin();
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

		#endregion //Criteria

		#region Data Access - Create
		[RunLocal]
		private void DataPortal_Create(Criteria criteria)
		{
			_maNhanVien = criteria.MaNhanVien;
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
				cm.CommandText = "SelectTable_1";

				cm.Parameters.AddWithValue("@MaNhanVien", criteria.MaNhanVien);

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
            _maQLBoPhan = dr.GetString("MaQLBoPhan");
			_maNhanVien = dr.GetInt64("MaNhanVien");
			_maQLNhanVien = dr.GetString("MaQLNhanVien");
			_tenNhanVien = dr.GetString("TenNhanVien");
			_tenChucVu = dr.GetString("TenChucVu");
            _maChucVu = dr.GetString("MaChucVu");
            _tenChucDanh = dr.GetString("TenChucDanh");
            _maChucDanh = dr.GetString("MaChucDanh");
			_tenBoPhan = dr.GetString("TenBoPhan");
			_gioiTinh = dr.GetString("GioiTinh");
			_cmnd = dr.GetString("CMND");
			_ngaySinh = dr.GetDateTime("NgaySinh");
			_tinhThanhNoiSinh = dr.GetString("TinhThanhNoiSinh");
			_danToc = dr.GetString("DanToc");
			_tenTonGiao = dr.GetString("TenTonGiao");
			_tinhTrang = dr.GetString("TinhTrang");
			_ngayVaoNganh = dr.GetDateTime("NgayVaoNganh");
			_ngayTinhThamNien = dr.GetDateTime("NgayTinhThamNien");
			_diaChi = dr.GetString("DiaChi");
			_theNhaBao = dr.GetString("TheNhaBao");
			_maSoThue = dr.GetString("MaSoThue");
			_loaiNhanVien = dr.GetString("LoaiNhanVien");
			_tinhTrangHonNhan = dr.GetString("TinhTrangHonNhan");
			_soTaiKhoan = dr.GetString("SoTaiKhoan");
			_tenNganHang = dr.GetString("TenNganHang");
			_ngachLuong = dr.GetString("NgachLuong");
			_tenNgachLuong = dr.GetString("TenNgachLuong");
			_bacLuong = dr.GetString("BacLuong");
			_heSoLuong = dr.GetDecimal("HeSoLuong");
			_heSoVuotKhung = dr.GetDecimal("HeSoVuotKhung");
			_mocLenLuong = dr.GetDateTime("MocLenLuong");
			_ngachLuongBH = dr.GetString("NgachLuongBH");
			_tenNgachLuongBH = dr.GetString("TenNgachLuongBH");
			_bacLuongBH = dr.GetString("BacLuongBH");
			_heSoLuongBaoHiem = dr.GetDecimal("HeSoLuongBaoHiem");
			_mocLenLuongBaoHiem = dr.GetDateTime("MocLenLuongBaoHiem");
			_heSoVuotKhungBH = dr.GetDecimal("HeSoVuotKhungBH");
			_heSoPhuCapChucVu = dr.GetDecimal("HeSoPhuCapChucVu");
			_heSoLuongNoiBo = dr.GetDecimal("HeSoLuongNoiBo");
			_heSoLuongBoSung = dr.GetDecimal("HeSoLuongBoSung");
			_heSoBu = dr.GetDecimal("HeSoBu");
			_heSoDocHai = dr.GetDecimal("HeSoDocHai");
			_phuCapHC = dr.GetBoolean("PhuCapHC");
			_chuyenNganhDaoTao = dr.GetString("ChuyenNganhDaoTao");
			_trinhDoHocVan = dr.GetString("TrinhDoHocVan");
			_trinhDoTinHoc = dr.GetString("TrinhDoTinHoc");
			_tenNgoaiNgu = dr.GetString("TenNgoaiNgu");
			_trinhDoNgoaiNgu = dr.GetString("TrinhDoNgoaiNgu");
			_tenQuanLyKinhTe = dr.GetString("TenQuanLyKinhTe");
			_tenQuanLyNhaNuoc = dr.GetString("TenQuanLyNhaNuoc");
			_lyLuanCT = dr.GetString("LyLuanCT");
			_tenChungChi = dr.GetString("TenChungChi");
            _ngayCap = dr.GetDateTime("NgayCap");
            _noiCap = dr.GetString("NoiCap");
            _soTheDang = dr.GetString("SoTheDang");
            _ngayVaoDangCT = dr.GetDateTime("NgayVaoDangCT");
            _ngayVaoDangDB = dr.GetDateTime("NgayVaoDangDB"); 
		}

		private void FetchChildren(SafeDataReader dr)
		{
		}
		#endregion //Data Access - Fetch

	
		#endregion //Data Access
	}
}
