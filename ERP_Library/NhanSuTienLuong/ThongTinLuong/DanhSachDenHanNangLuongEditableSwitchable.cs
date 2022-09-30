
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{ 
	[Serializable()] 
	public class DanhSachDenHanNangLuong : Csla.BusinessBase<DanhSachDenHanNangLuong>
	{
		#region Business Properties and Methods

		//declare members
        static decimal _heSoLuongNext = 0;
        static int maBacLuongCoBanNext = 0;
       static decimal HSVK = 0;
       static decimal heSoPhuCapChucVu = 0;
       static string tenBacLuongMoi = string.Empty;

        static   decimal HSLuongBHNext = 0;
          static int maBacLuongBHNext = 0;
          static string tenBacLuongBaoHiemMoi = string.Empty;
       
      // static DanhSachDenHanNangLuong _nangLuong;
          private bool _daChuyenThanhNangLuong = false;

        
		private int _iDDenHanNangLuong = 0;
		private string _tenDanhSach = string.Empty;
        private SmartDate _ngayDenHan = new SmartDate(DateTime.Today.Date);
		private long _maNhanVien = 0;
        private string _maQLNhanVien = string.Empty;
		private string _tenNhanVien = string.Empty;
        private SmartDate _ngaySinh = new SmartDate(DateTime.Today.Date);
		private int _maChucVu = 0;
		private string _tenChucVu = string.Empty;
		private int _maBoPhan = 0;
		private string _tenBoPhan = string.Empty;
		private int _maNhomNgach = 0;
		private string _tenNhomNgach = string.Empty;
		private int _maNgachLuong = 0;
		private string _tenNgachLuong = string.Empty;
		private int _maBacLuong = 0;
		private string _tenBacLuong = string.Empty;
		private decimal _heSoLuong = 0;
		private decimal _heSoPhuCapChucVu = 0;
		private decimal _heSoVuotKhung = 0;
        private SmartDate _mocNangLuongLanSau = new SmartDate(DateTime.Today.Date);
		private int _maBacLuongMoi = 0;
		private string _tenBacLuongMoi = string.Empty;
		private decimal _heSoLuongMoi = 0;
		private decimal _heSoPhuCapChucVuMoi = 0;
		private decimal _heSoVuotKhungMoi = 0;
        private SmartDate _mocNangLuongLanSauNew = new SmartDate(DateTime.Today.Date);
        private int _kieuNangLuong = 0;
        private int _loaiNV = 0;
        private long _maNhanVienBiKyLuat=0;
		[System.ComponentModel.DataObjectField(true, true)]
		public int IDDenHanNangLuong
		{
			get
			{
				return _iDDenHanNangLuong;
			}
		}

		public string TenDanhSach
		{
			get
			{
              
				return _tenDanhSach;
			}
			set
			{
				if (value == null) value = string.Empty;
				if (!_tenDanhSach.Equals(value))
				{
					_tenDanhSach = value;
					PropertyHasChanged("TenDanhSach");
				}
			}
		}

		public DateTime NgayDenHan
		{
			get
			{
				return _ngayDenHan.Date;
			}
            set
            {
                CanWriteProperty("NgayDenHan", true);
                if (!_ngayDenHan.Equals(value))
                {
                    _ngayDenHan = new SmartDate(value);
                  
                    PropertyHasChanged("NgayDenHan");
                }
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

		public DateTime NgaySinh
		{
			get
			{
				return _ngaySinh.Date;
			}
            set
            {
                CanWriteProperty("NgaySinh", true);
                if (!_ngaySinh.Equals(value))
                {
                    _ngaySinh = new SmartDate(value);
                    PropertyHasChanged("NgaySinh");
                }
            }
		}

	
		public int MaChucVu
		{
			get
			{
				return _maChucVu;
			}
			set
			{
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

		public int MaNhomNgach
		{
			get
			{
				return _maNhomNgach;
			}
			set
			{
				if (!_maNhomNgach.Equals(value))
				{
					_maNhomNgach = value;
					PropertyHasChanged("MaNhomNgach");
				}
			}
		}

		public string TenNhomNgach
		{
			get
			{
				return _tenNhomNgach;
			}
			set
			{
				if (value == null) value = string.Empty;
				if (!_tenNhomNgach.Equals(value))
				{
					_tenNhomNgach = value;
					PropertyHasChanged("TenNhomNgach");
				}
			}
		}

		public int MaNgachLuong
		{
			get
			{
				return _maNgachLuong;
			}
			set
			{
				if (!_maNgachLuong.Equals(value))
				{
					_maNgachLuong = value;
					PropertyHasChanged("MaNgachLuong");
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

		public int MaBacLuong
		{
			get
			{
				return _maBacLuong;
			}
			set
			{
				if (!_maBacLuong.Equals(value))
				{
					_maBacLuong = value;
					PropertyHasChanged("MaBacLuong");
				}
			}
		}

		public string TenBacLuong
		{
			get
			{
				return _tenBacLuong;
			}
			set
			{
				if (value == null) value = string.Empty;
				if (!_tenBacLuong.Equals(value))
				{
					_tenBacLuong = value;
					PropertyHasChanged("TenBacLuong");
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

		public DateTime MocNangLuongLanSau
		{
			get
			{
				return _mocNangLuongLanSau.Date;
			}
            set
            {
                CanWriteProperty("MocNangLuongLanSau", true);
                if (!_mocNangLuongLanSau.Equals(value))
                {
                    _mocNangLuongLanSau = new SmartDate(value);
                    PropertyHasChanged("MocNangLuongLanSau");
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
					PropertyHasChanged("MaBacLuongMoi");
				}
			}
		}

		public string TenBacLuongMoi
		{
			get
			{
				return _tenBacLuongMoi;
			}
			set
			{
				if (value == null) value = string.Empty;
				if (!_tenBacLuongMoi.Equals(value))
				{
					_tenBacLuongMoi = value;
					PropertyHasChanged("TenBacLuongMoi");
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

		public decimal HeSoPhuCapChucVuMoi
		{
			get
			{
				return _heSoPhuCapChucVuMoi;
			}
			set
			{
				if (!_heSoPhuCapChucVuMoi.Equals(value))
				{
					_heSoPhuCapChucVuMoi = value;
					PropertyHasChanged("HeSoPhuCapChucVuMoi");
				}
			}
		}

		public decimal HeSoVuotKhungMoi
		{
			get
			{
				return _heSoVuotKhungMoi;
			}
			set
			{
				if (!_heSoVuotKhungMoi.Equals(value))
				{
					_heSoVuotKhungMoi = value;
					PropertyHasChanged("HeSoVuotKhungMoi");
				}
			}
		}

		public DateTime MocNangLuongLanSauNew
		{
			get
			{
				return _mocNangLuongLanSauNew.Date;
			}
            set
            {
                CanWriteProperty("MocNangLuongLanSauNew", true);
                if (!_mocNangLuongLanSauNew.Equals(value))
                {
                    _mocNangLuongLanSauNew = new SmartDate(value);
                    PropertyHasChanged("MocNangLuongLanSauNew");
                }
            }
		}

        public int KieuNangLuong
        {
            get
            {
                return _kieuNangLuong;
            }
            set
            {
                if (!_kieuNangLuong.Equals(value))
                {
                    _kieuNangLuong = value;
                    PropertyHasChanged("KieuNangLuong");
                }
            }
        }
        public int LoaiNV
        {
            get
            {
                return _loaiNV;
            }
            set
            {
                if (!_loaiNV.Equals(value))
                {
                    _loaiNV = value;
                    PropertyHasChanged("LoaiNV");
                }
            }
        }
        public long MaNhanVienBiKyLuat
        {
            get
            {
                return _maNhanVienBiKyLuat;
            }
            set
            {
                if (!_maNhanVienBiKyLuat.Equals(value))
                {
                    _maNhanVienBiKyLuat = value;
                    PropertyHasChanged("MaNhanVienBiKyLuat");
                }
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
        public bool DaChuyenThanhNangLuong
        {
            get { return _daChuyenThanhNangLuong; }
            set { _daChuyenThanhNangLuong = value; }
        }
		protected override object GetIdValue()
		{
			return _iDDenHanNangLuong;
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
			// TenDanhSach
			//
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("TenDanhSach", 50));
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
			// TenNhomNgach
			//
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("TenNhomNgach", 50));
			//
			// TenNgachLuong
			//
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("TenNgachLuong", 50));
			//
			// TenBacLuong
			//
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("TenBacLuong", 50));
			//
			// TenBacLuongMoi
			//
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("TenBacLuongMoi", 50));
		}

		protected override void AddBusinessRules()
		{
			AddCommonRules();
			AddCustomRules();
		}
		#endregion //Validation Rules

		#region Factory Methods
		private DanhSachDenHanNangLuong()
		{ /* require use of factory method */ }

		public static DanhSachDenHanNangLuong NewDanhSachDenHanNangLuong()
		{
			return DataPortal.Create<DanhSachDenHanNangLuong>();
		}

		public static DanhSachDenHanNangLuong GetDanhSachDenHanNangLuong(int iDDenHanNangLuong)
		{
			return DataPortal.Fetch<DanhSachDenHanNangLuong>(new Criteria(iDDenHanNangLuong));
		}
        public static DanhSachDenHanNangLuong NewDanhSachDenHanNangLuongByNhanVien(long maNhanVien,DateTime ngayDenHan)
        {
            return DataPortal.Fetch<DanhSachDenHanNangLuong>(new CriteriaByNhanVien(maNhanVien,ngayDenHan));
        }

		public static void DeleteDanhSachDenHanNangLuong(int iDDenHanNangLuong)
		{
			DataPortal.Delete(new Criteria(iDDenHanNangLuong));
		}

		#endregion //Factory Methods

		#region Child Factory Methods
		internal static DanhSachDenHanNangLuong NewDanhSachDenHanNangLuongChild()
		{
			DanhSachDenHanNangLuong child = new DanhSachDenHanNangLuong();
			child.ValidationRules.CheckRules();
			child.MarkAsChild();
			return child;
		}
        internal static DanhSachDenHanNangLuong GetDanhSachDenHanNangLuongByThang(SafeDataReader dr)
        {
            DanhSachDenHanNangLuong child = new DanhSachDenHanNangLuong();
            child._tenDanhSach = dr.GetString("TenDanhSach");
            child.MarkAsChild();
            child.MarkOld();
            return child;
        }
        internal static DanhSachDenHanNangLuong GetDanhSachDenHanNangLuongByDenNgay(SafeDataReader dr)
        {
            try
            {
                DanhSachDenHanNangLuong child = new DanhSachDenHanNangLuong();
                child._maNhanVien = dr.GetInt64("MaNhanVien");
                child._maQLNhanVien = dr.GetString("MaQLNhanVien");
                child._tenNhanVien = dr.GetString("TenNhanVien");
                child._ngaySinh = dr.GetSmartDate("NgaySinh");
                child._maChucVu = dr.GetInt32("MaChucVu");
                child._tenChucVu = dr.GetString("TenChucVu");
                child._maBoPhan = dr.GetInt32("MaBoPhan");
                child._tenBoPhan = dr.GetString("TenBoPhan");
                child._maNhomNgach = dr.GetInt32("MaNhomNgach");
                child._tenNhomNgach = dr.GetString("TenNhomNgach");
                child._maNgachLuong = dr.GetInt32("MaNgachLuong");
                child._tenNgachLuong = dr.GetString("TenNgachLuong");
                child._maBacLuong = dr.GetInt32("MaBacLuong");
                child._tenBacLuong = dr.GetString("TenBacLuong");
                child._heSoLuong = dr.GetDecimal("HeSoLuong");
                child._heSoPhuCapChucVu = dr.GetDecimal("HeSoPhuCapChucVu");
                child._heSoVuotKhung = dr.GetDecimal("HeSoVuotKhung");
                child._mocNangLuongLanSau = dr.GetSmartDate("MocNangLuongLanSau");
                child._mocNangLuongLanSauNew = dr.GetSmartDate("DenHanNangLuong");
                GetThongTinDenHanNangLuong(child._maNhanVien);
                child._heSoLuongMoi = _heSoLuongNext;
                child._heSoPhuCapChucVuMoi = heSoPhuCapChucVu;
                child._heSoVuotKhungMoi = HSVK;
                child._maBacLuongMoi = maBacLuongCoBanNext;
                child._tenBacLuongMoi = tenBacLuongMoi;
                child._loaiNV = 1;
                child._kieuNangLuong = 1;
                child.MarkAsChild();
                child.MarkNew();
                return child;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        internal static DanhSachDenHanNangLuong GetDanhSachDenHanNangLuongBaoHiemByDenNgay(SafeDataReader dr)
        {
            DanhSachDenHanNangLuong child = new DanhSachDenHanNangLuong();
            child._maNhanVien = dr.GetInt64("MaNhanVien");
            child._maQLNhanVien = dr.GetString("MaQLNhanVien");
            child._tenNhanVien = dr.GetString("TenNhanVien");
            child._ngaySinh = dr.GetSmartDate("NgaySinh");
            child._maChucVu = dr.GetInt32("MaChucVu");
            child._tenChucVu = dr.GetString("TenChucVu");
            child._maBoPhan = dr.GetInt32("MaBoPhan");
            child._tenBoPhan = dr.GetString("TenBoPhan");
            child._maNhomNgach = dr.GetInt32("MaNhomNgach");
            child._tenNhomNgach = dr.GetString("TenNhomNgach");
            child._maNgachLuong = dr.GetInt32("MaNgachLuong");
            child._tenNgachLuong = dr.GetString("TenNgachLuong");
            child._maBacLuong = dr.GetInt32("MaBacLuong");
            child._tenBacLuong = dr.GetString("TenBacLuong");
            child._heSoLuong = dr.GetDecimal("HeSoLuongBaoHiem");
            child._heSoPhuCapChucVu = dr.GetDecimal("HeSoPhuCapChucVu");
            child._heSoVuotKhung = dr.GetDecimal("HeSoVuotKhung");
            child._mocNangLuongLanSau = dr.GetSmartDate("MocNangLuongLanSau");
            child._mocNangLuongLanSauNew = dr.GetSmartDate("DenHanNangLuong");
            GetThongTinDenHanNangLuong(child._maNhanVien);
            child._heSoLuongMoi = HSLuongBHNext;
            child._heSoPhuCapChucVuMoi = heSoPhuCapChucVu;
            child._heSoVuotKhungMoi = HSVK;
            child._maBacLuongMoi = maBacLuongBHNext;
            child._tenBacLuongMoi = tenBacLuongBaoHiemMoi;
            child._loaiNV = 2;
            //child._kieuNangLuong =2;
            child.MarkAsChild();
            child.MarkNew();
            return child;
        }
        private static void  GetThongTinDenHanNangLuong(long _maNhanVien)
        {
           
            NhanVien _nhanVien = NhanVien.GetNhanVien(_maNhanVien);
            heSoPhuCapChucVu = _nhanVien.HeSoPhuCapChucVu;
            BacLuongCoBanList _listBacLuongBH = BacLuongCoBanList.GetBacLuongCoBanList(_nhanVien.MaNgachLuongBaoHiem);
            BacLuongCoBanList _listBacLuongCB = BacLuongCoBanList.GetBacLuongCoBanList(_nhanVien.MaNgachLuongCoBan);
            decimal _heSoLuong = _nhanVien.HeSoLuong;
            decimal _heSoLuongBH = _nhanVien.HeSoLuongBaoHiem;
            DanhSachDenHanNangLuong _nangLuong = DanhSachDenHanNangLuong.NewDanhSachDenHanNangLuong();
            HSVK = _nhanVien.HeSoVuotKhung;
            _heSoLuongNext = _heSoLuong;
            for (int j = 0; j < _listBacLuongCB.Count; j++)
            {
                if (_heSoLuong < _listBacLuongCB[j].HeSoLuong)
                {
                    _heSoLuongNext = _listBacLuongCB[j].HeSoLuong;//Hệ Số Kế Tiếp
                    break;
                }
            }
            BacLuongCoBan bacLuongCoBan= BacLuongCoBan.GetBacLuongCoBanByHeSoLuong(_heSoLuongNext, _nhanVien.MaNgachLuongCoBan);
            maBacLuongCoBanNext = bacLuongCoBan.MaBacLuongCoBan;
            tenBacLuongMoi = bacLuongCoBan.MaQuanLy;

            HSLuongBHNext = _heSoLuongBH;
            for (int j = 0; j < _listBacLuongBH.Count; j++)
            {
                if (_heSoLuongBH < _listBacLuongBH[j].HeSoLuong)
                {
                    HSLuongBHNext = _listBacLuongBH[j].HeSoLuong;//Hệ Số Kế Tiếp
                    break;

                }
            }
            BacLuongCoBan bacLuongBaoHiem = BacLuongCoBan.GetBacLuongCoBanByHeSoLuong(HSLuongBHNext, _nhanVien.MaNgachLuongBaoHiem);
            maBacLuongBHNext = bacLuongBaoHiem.MaBacLuongCoBan;
            tenBacLuongBaoHiemMoi = bacLuongBaoHiem.MaQuanLy;


            if ((_heSoLuongNext == _heSoLuong) && HSVK == 0)//Hết Bậc Lương tăng Vượt Khung lần đầu.
            {
                HSVK = 5;
            }
            else if ((_heSoLuongNext == _heSoLuong) && HSVK != 0)//Hết Bậc Lương tăng Vượt Khung lần Sau.
            {
                HSVK = HSVK + 1;
            }
        

        }

		internal static DanhSachDenHanNangLuong GetDanhSachDenHanNangLuong(SafeDataReader dr)
		{
			DanhSachDenHanNangLuong child =  new DanhSachDenHanNangLuong();
			child.MarkAsChild();
			child.Fetch(dr);
			return child;
		}
        internal static DanhSachDenHanNangLuong GetDanhSachDenHanNangLuongByNgay(SafeDataReader dr)
        {
            DanhSachDenHanNangLuong child = new DanhSachDenHanNangLuong();
            child._iDDenHanNangLuong = dr.GetInt32("IDDenHanNangLuong");
            child._tenDanhSach = dr.GetString("TenDanhSach");
            child._ngayDenHan = dr.GetSmartDate("NgayDenHan");
            child._maNhanVien = dr.GetInt64("MaNhanVien");
            child._tenNhanVien = dr.GetString("TenNhanVien");
            child._ngaySinh = dr.GetSmartDate("NgaySinh");
            child._maChucVu = dr.GetInt32("MaChucVu");
            child._tenChucVu = dr.GetString("TenChucVu");
            child._maBoPhan = dr.GetInt32("MaBoPhan");
            child._tenBoPhan = dr.GetString("TenBoPhan");
            child._maNhomNgach = dr.GetInt32("MaNhomNgach");
            child._tenNhomNgach = dr.GetString("TenNhomNgach");
            child._maNgachLuong = dr.GetInt32("MaNgachLuong");
            child._tenNgachLuong = dr.GetString("TenNgachLuong");
            child._maBacLuong = dr.GetInt32("MaBacLuong");
            child._tenBacLuong = dr.GetString("TenBacLuong");
            child._heSoLuong = dr.GetDecimal("HeSoLuong");
            child._heSoPhuCapChucVu = dr.GetDecimal("HeSoPhuCapChucVu");
            child._heSoVuotKhung = dr.GetDecimal("HeSoVuotKhung");
            child._mocNangLuongLanSau = dr.GetSmartDate("MocNangLuongLanSau");
            child._maBacLuongMoi = dr.GetInt32("MaBacLuongMoi");
            child._tenBacLuongMoi = dr.GetString("TenBacLuongMoi");
            child._heSoLuongMoi = dr.GetDecimal("HeSoLuongMoi");
            child._heSoPhuCapChucVuMoi = dr.GetDecimal("HeSoPhuCapChucVuMoi");
            child._heSoVuotKhungMoi = dr.GetDecimal("HeSoVuotKhungMoi");
            child._mocNangLuongLanSauNew = dr.GetSmartDate("MocNangLuongLanSauNew");
            child._loaiNV = dr.GetInt32("LoaiNV");
            child._kieuNangLuong = dr.GetInt32("KieuNangLuong");
            child._maNhanVienBiKyLuat = dr.GetInt64("MaNhanVienBiKyLuat");
            child.MarkAsChild();
          
            return child;
        }
		#endregion //Child Factory Methods

		#region Data Access

		#region Criteria

		[Serializable()]
		private class Criteria
		{
			public int IDDenHanNangLuong;

			public Criteria(int iDDenHanNangLuong)
			{
				this.IDDenHanNangLuong = iDDenHanNangLuong;
			}
		}
        private class CriteriaByNhanVien
        {
            public long MaNhanVien;
            public DateTime NgayDenHan;
            public CriteriaByNhanVien(long maNhanVien,DateTime ngayDenHan)
            {
                this.MaNhanVien = maNhanVien;
                this.NgayDenHan = ngayDenHan;
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
			using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
			{
				cn.Open();

				ExecuteFetch(cn, criteria);
			}//using
		}

        private void ExecuteFetch(SqlConnection cn, object criteria)
		{
			using (SqlCommand cm = cn.CreateCommand())
			{
				cm.CommandType = CommandType.StoredProcedure;
                if (criteria is Criteria)
                {
                    cm.CommandText = "spd_SelecttblnsDanhSachDenHanNangLuong";

                    cm.Parameters.AddWithValue("@IDDenHanNangLuong",((Criteria) criteria).IDDenHanNangLuong);

                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                        {
                            FetchObject(dr);
                            // ValidationRules.CheckRules();

                            //load child object(s)
                            FetchChildren(dr);
                        }
                    }
                }
                else if (criteria is CriteriaByNhanVien)
                {
                    cm.CommandText = "spd_DanhSachDenHanNangLuongByNhanVien";

                    cm.Parameters.AddWithValue("@MaNhanVien", ((CriteriaByNhanVien)criteria).MaNhanVien);
                    cm.Parameters.AddWithValue("@NgayDenHan", ((CriteriaByNhanVien)criteria).NgayDenHan.Date);

                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                        {
                            DanhSachDenHanNangLuong child = new DanhSachDenHanNangLuong();
                            child._maNhanVien = dr.GetInt64("MaNhanVien");
                            child._tenNhanVien = dr.GetString("TenNhanVien");
                            child._ngaySinh = dr.GetSmartDate("NgaySinh");
                            child._maChucVu = dr.GetInt32("MaChucVu");
                            child._tenChucVu = dr.GetString("TenChucVu");
                            child._maBoPhan = dr.GetInt32("MaBoPhan");
                            child._tenBoPhan = dr.GetString("TenBoPhan");
                            child._maNhomNgach = dr.GetInt32("MaNhomNgach");
                            child._tenNhomNgach = dr.GetString("TenNhomNgach");
                            child._maNgachLuong = dr.GetInt32("MaNgachLuong");
                            child._tenNgachLuong = dr.GetString("TenNgachLuong");
                            child._maBacLuong = dr.GetInt32("MaBacLuong");
                            child._tenBacLuong = dr.GetString("TenBacLuong");
                            child._heSoLuong = dr.GetDecimal("HeSoLuong");
                            child._heSoPhuCapChucVu = dr.GetDecimal("HeSoPhuCapChucVu");
                            child._heSoVuotKhung = dr.GetDecimal("HeSoVuotKhung");
                            child._mocNangLuongLanSau = dr.GetSmartDate("MocNangLuongLanSau");
                            child._mocNangLuongLanSauNew = dr.GetSmartDate("DenHanNangLuong");
                            GetThongTinDenHanNangLuong(child._maNhanVien);
                            child._heSoLuongMoi = _heSoLuongNext;
                            child._heSoPhuCapChucVuMoi = heSoPhuCapChucVu;
                            child._heSoVuotKhungMoi = HSVK;
                            child._maBacLuongMoi = maBacLuongCoBanNext;
                            child._tenBacLuongMoi = tenBacLuongMoi;
                            child._loaiNV = 1;
                            child._kieuNangLuong = 1;
                            child.MarkAsChild();
                            child.MarkNew();
                          
                           
                           
                        }
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

		#region Data Access - Update
		protected override void DataPortal_Update()
		{
			using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
			{
				cn.Open();

				if (base.IsDirty)
				{
					ExecuteUpdate(cn, null);
				}

				//update child object(s)
				UpdateChildren(cn);
			}//using

		}

		#endregion //Data Access - Update

		#region Data Access - Delete
		protected override void DataPortal_DeleteSelf()
		{
			DataPortal_Delete(new Criteria(_iDDenHanNangLuong));
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
                cm.CommandText = "spd_DeletetblnsDanhSachDenHanNangLuong";

				cm.Parameters.AddWithValue("@IDDenHanNangLuong", criteria.IDDenHanNangLuong);

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
			_iDDenHanNangLuong = dr.GetInt32("IDDenHanNangLuong");
			_tenDanhSach = dr.GetString("TenDanhSach");
			_ngayDenHan = dr.GetSmartDate("NgayDenHan", _ngayDenHan.EmptyIsMin);
			_maNhanVien = dr.GetInt64("MaNhanVien");
			_tenNhanVien = dr.GetString("TenNhanVien");
			_ngaySinh = dr.GetSmartDate("NgaySinh", _ngaySinh.EmptyIsMin);
			_maChucVu = dr.GetInt32("MaChucVu");
			_tenChucVu = dr.GetString("TenChucVu");
			_maBoPhan = dr.GetInt32("MaBoPhan");
			_tenBoPhan = dr.GetString("TenBoPhan");
			_maNhomNgach = dr.GetInt32("MaNhomNgach");
			_tenNhomNgach = dr.GetString("TenNhomNgach");
			_maNgachLuong = dr.GetInt32("MaNgachLuong");
			_tenNgachLuong = dr.GetString("TenNgachLuong");
			_maBacLuong = dr.GetInt32("MaBacLuong");
			_tenBacLuong = dr.GetString("TenBacLuong");
			_heSoLuong = dr.GetDecimal("HeSoLuong");
			_heSoPhuCapChucVu = dr.GetDecimal("HeSoPhuCapChucVu");
			_heSoVuotKhung = dr.GetDecimal("HeSoVuotKhung");
			_mocNangLuongLanSau = dr.GetSmartDate("MocNangLuongLanSau", _mocNangLuongLanSau.EmptyIsMin);
			_maBacLuongMoi = dr.GetInt32("MaBacLuongMoi");
			_tenBacLuongMoi = dr.GetString("TenBacLuongMoi");
			_heSoLuongMoi = dr.GetDecimal("HeSoLuongMoi");
			_heSoPhuCapChucVuMoi = dr.GetDecimal("HeSoPhuCapChucVuMoi");
			_heSoVuotKhungMoi = dr.GetDecimal("HeSoVuotKhungMoi");
			_mocNangLuongLanSauNew = dr.GetSmartDate("MocNangLuongLanSauNew", _mocNangLuongLanSauNew.EmptyIsMin);
           _loaiNV = dr.GetInt32("LoaiNV");
           _kieuNangLuong = dr.GetInt32("KieuNangLuong");
            _daChuyenThanhNangLuong=dr.GetBoolean("DaChuyenThanhNangLuong");
		}

		private void FetchChildren(SafeDataReader dr)
		{
		}
		#endregion //Data Access - Fetch

		#region Data Access - Insert
		internal void Insert(SqlConnection cn, DanhSachDenHanNangLuongList parent)
		{
			if (!IsDirty) return;

			ExecuteInsert(cn, parent);
			MarkOld();

			//update child object(s)
			UpdateChildren(cn);
		}

		private void ExecuteInsert(SqlConnection cn, DanhSachDenHanNangLuongList parent)
		{
			using (SqlCommand cm = cn.CreateCommand())
			{
				cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_InserttblnsDanhSachDenHanNangLuong";

				AddInsertParameters(cm, parent);

				cm.ExecuteNonQuery();

				_iDDenHanNangLuong = (int)cm.Parameters["@IDDenHanNangLuong"].Value;
			}//using
		}

		private void AddInsertParameters(SqlCommand cm, DanhSachDenHanNangLuongList parent)
		{
			//TODO: if parent use identity key, fix fk member with value from parent
			if (_tenDanhSach.Length > 0)
				cm.Parameters.AddWithValue("@TenDanhSach", _tenDanhSach);
			else
				cm.Parameters.AddWithValue("@TenDanhSach", DBNull.Value);
			cm.Parameters.AddWithValue("@NgayDenHan", _ngayDenHan.DBValue);
			if (_maNhanVien != 0)
				cm.Parameters.AddWithValue("@MaNhanVien", _maNhanVien);
			else
				cm.Parameters.AddWithValue("@MaNhanVien", DBNull.Value);
			if (_tenNhanVien.Length > 0)
				cm.Parameters.AddWithValue("@TenNhanVien", _tenNhanVien);
			else
				cm.Parameters.AddWithValue("@TenNhanVien", DBNull.Value);
			cm.Parameters.AddWithValue("@NgaySinh", _ngaySinh.DBValue);
			if (_maChucVu != 0)
				cm.Parameters.AddWithValue("@MaChucVu", _maChucVu);
			else
				cm.Parameters.AddWithValue("@MaChucVu", DBNull.Value);
			if (_tenChucVu.Length > 0)
				cm.Parameters.AddWithValue("@TenChucVu", _tenChucVu);
			else
				cm.Parameters.AddWithValue("@TenChucVu", DBNull.Value);
			if (_maBoPhan != 0)
				cm.Parameters.AddWithValue("@MaBoPhan", _maBoPhan);
			else
				cm.Parameters.AddWithValue("@MaBoPhan", DBNull.Value);
			if (_tenBoPhan.Length > 0)
				cm.Parameters.AddWithValue("@TenBoPhan", _tenBoPhan);
			else
				cm.Parameters.AddWithValue("@TenBoPhan", DBNull.Value);
			if (_maNhomNgach != 0)
				cm.Parameters.AddWithValue("@MaNhomNgach", _maNhomNgach);
			else
				cm.Parameters.AddWithValue("@MaNhomNgach", DBNull.Value);
			if (_tenNhomNgach.Length > 0)
				cm.Parameters.AddWithValue("@TenNhomNgach", _tenNhomNgach);
			else
				cm.Parameters.AddWithValue("@TenNhomNgach", DBNull.Value);
			if (_maNgachLuong != 0)
				cm.Parameters.AddWithValue("@MaNgachLuong", _maNgachLuong);
			else
				cm.Parameters.AddWithValue("@MaNgachLuong", DBNull.Value);
			if (_tenNgachLuong.Length > 0)
				cm.Parameters.AddWithValue("@TenNgachLuong", _tenNgachLuong);
			else
				cm.Parameters.AddWithValue("@TenNgachLuong", DBNull.Value);
			if (_maBacLuong != 0)
				cm.Parameters.AddWithValue("@MaBacLuong", _maBacLuong);
			else
				cm.Parameters.AddWithValue("@MaBacLuong", DBNull.Value);
			if (_tenBacLuong.Length > 0)
				cm.Parameters.AddWithValue("@TenBacLuong", _tenBacLuong);
			else
				cm.Parameters.AddWithValue("@TenBacLuong", DBNull.Value);
			if (_heSoLuong != 0)
				cm.Parameters.AddWithValue("@HeSoLuong", _heSoLuong);
			else
				cm.Parameters.AddWithValue("@HeSoLuong", DBNull.Value);
			if (_heSoPhuCapChucVu != 0)
				cm.Parameters.AddWithValue("@HeSoPhuCapChucVu", _heSoPhuCapChucVu);
			else
				cm.Parameters.AddWithValue("@HeSoPhuCapChucVu", DBNull.Value);
			if (_heSoVuotKhung != 0)
				cm.Parameters.AddWithValue("@HeSoVuotKhung", _heSoVuotKhung);
			else
				cm.Parameters.AddWithValue("@HeSoVuotKhung", DBNull.Value);
			cm.Parameters.AddWithValue("@MocNangLuongLanSau", _mocNangLuongLanSau.DBValue);
			if (_maBacLuongMoi != 0)
				cm.Parameters.AddWithValue("@MaBacLuongMoi", _maBacLuongMoi);
			else
				cm.Parameters.AddWithValue("@MaBacLuongMoi", DBNull.Value);
			if (_tenBacLuongMoi.Length > 0)
				cm.Parameters.AddWithValue("@TenBacLuongMoi", _tenBacLuongMoi);
			else
				cm.Parameters.AddWithValue("@TenBacLuongMoi", DBNull.Value);
			if (_heSoLuongMoi != 0)
				cm.Parameters.AddWithValue("@HeSoLuongMoi", _heSoLuongMoi);
			else
				cm.Parameters.AddWithValue("@HeSoLuongMoi", DBNull.Value);
			if (_heSoPhuCapChucVuMoi != 0)
				cm.Parameters.AddWithValue("@HeSoPhuCapChucVuMoi", _heSoPhuCapChucVuMoi);
			else
				cm.Parameters.AddWithValue("@HeSoPhuCapChucVuMoi", DBNull.Value);
			if (_heSoVuotKhungMoi != 0)
				cm.Parameters.AddWithValue("@HeSoVuotKhungMoi", _heSoVuotKhungMoi);
			else
				cm.Parameters.AddWithValue("@HeSoVuotKhungMoi", DBNull.Value);
			cm.Parameters.AddWithValue("@MocNangLuongLanSauNew", _mocNangLuongLanSauNew.DBValue);
			cm.Parameters.AddWithValue("@IDDenHanNangLuong", _iDDenHanNangLuong);
            cm.Parameters.AddWithValue("@LoaiNV", _loaiNV);
            cm.Parameters.AddWithValue("@KieuNangLuong",_kieuNangLuong);
			cm.Parameters["@IDDenHanNangLuong"].Direction = ParameterDirection.Output;
		}
		#endregion //Data Access - Insert

		#region Data Access - Update
		internal void Update(SqlConnection cn, DanhSachDenHanNangLuongList parent)
		{
			if (!IsDirty) return;

			if (base.IsDirty)
			{
				ExecuteUpdate(cn, parent);
				MarkOld();
			}

			//update child object(s)
			UpdateChildren(cn);
		}

		private void ExecuteUpdate(SqlConnection cn, DanhSachDenHanNangLuongList parent)
		{
			using (SqlCommand cm = cn.CreateCommand())
			{
				cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_UpdatetblnsDanhSachDenHanNangLuong";

				AddUpdateParameters(cm, parent);

				cm.ExecuteNonQuery();

			}//using
		}

		private void AddUpdateParameters(SqlCommand cm, DanhSachDenHanNangLuongList parent)
		{
			cm.Parameters.AddWithValue("@IDDenHanNangLuong", _iDDenHanNangLuong);
			if (_tenDanhSach.Length > 0)
				cm.Parameters.AddWithValue("@TenDanhSach", _tenDanhSach);
			else
				cm.Parameters.AddWithValue("@TenDanhSach", DBNull.Value);
			cm.Parameters.AddWithValue("@NgayDenHan", _ngayDenHan.DBValue);
			if (_maNhanVien != 0)
				cm.Parameters.AddWithValue("@MaNhanVien", _maNhanVien);
			else
				cm.Parameters.AddWithValue("@MaNhanVien", DBNull.Value);
			if (_tenNhanVien.Length > 0)
				cm.Parameters.AddWithValue("@TenNhanVien", _tenNhanVien);
			else
				cm.Parameters.AddWithValue("@TenNhanVien", DBNull.Value);
			cm.Parameters.AddWithValue("@NgaySinh", _ngaySinh.DBValue);
			if (_maChucVu != 0)
				cm.Parameters.AddWithValue("@MaChucVu", _maChucVu);
			else
				cm.Parameters.AddWithValue("@MaChucVu", DBNull.Value);
			if (_tenChucVu.Length > 0)
				cm.Parameters.AddWithValue("@TenChucVu", _tenChucVu);
			else
				cm.Parameters.AddWithValue("@TenChucVu", DBNull.Value);
			if (_maBoPhan != 0)
				cm.Parameters.AddWithValue("@MaBoPhan", _maBoPhan);
			else
				cm.Parameters.AddWithValue("@MaBoPhan", DBNull.Value);
			if (_tenBoPhan.Length > 0)
				cm.Parameters.AddWithValue("@TenBoPhan", _tenBoPhan);
			else
				cm.Parameters.AddWithValue("@TenBoPhan", DBNull.Value);
			if (_maNhomNgach != 0)
				cm.Parameters.AddWithValue("@MaNhomNgach", _maNhomNgach);
			else
				cm.Parameters.AddWithValue("@MaNhomNgach", DBNull.Value);
			if (_tenNhomNgach.Length > 0)
				cm.Parameters.AddWithValue("@TenNhomNgach", _tenNhomNgach);
			else
				cm.Parameters.AddWithValue("@TenNhomNgach", DBNull.Value);
			if (_maNgachLuong != 0)
				cm.Parameters.AddWithValue("@MaNgachLuong", _maNgachLuong);
			else
				cm.Parameters.AddWithValue("@MaNgachLuong", DBNull.Value);
			if (_tenNgachLuong.Length > 0)
				cm.Parameters.AddWithValue("@TenNgachLuong", _tenNgachLuong);
			else
				cm.Parameters.AddWithValue("@TenNgachLuong", DBNull.Value);
			if (_maBacLuong != 0)
				cm.Parameters.AddWithValue("@MaBacLuong", _maBacLuong);
			else
				cm.Parameters.AddWithValue("@MaBacLuong", DBNull.Value);
			if (_tenBacLuong.Length > 0)
				cm.Parameters.AddWithValue("@TenBacLuong", _tenBacLuong);
			else
				cm.Parameters.AddWithValue("@TenBacLuong", DBNull.Value);
			if (_heSoLuong != 0)
				cm.Parameters.AddWithValue("@HeSoLuong", _heSoLuong);
			else
				cm.Parameters.AddWithValue("@HeSoLuong", DBNull.Value);
			if (_heSoPhuCapChucVu != 0)
				cm.Parameters.AddWithValue("@HeSoPhuCapChucVu", _heSoPhuCapChucVu);
			else
				cm.Parameters.AddWithValue("@HeSoPhuCapChucVu", DBNull.Value);
			if (_heSoVuotKhung != 0)
				cm.Parameters.AddWithValue("@HeSoVuotKhung", _heSoVuotKhung);
			else
				cm.Parameters.AddWithValue("@HeSoVuotKhung", DBNull.Value);
			cm.Parameters.AddWithValue("@MocNangLuongLanSau", _mocNangLuongLanSau.DBValue);
			if (_maBacLuongMoi != 0)
				cm.Parameters.AddWithValue("@MaBacLuongMoi", _maBacLuongMoi);
			else
				cm.Parameters.AddWithValue("@MaBacLuongMoi", DBNull.Value);
			if (_tenBacLuongMoi.Length > 0)
				cm.Parameters.AddWithValue("@TenBacLuongMoi", _tenBacLuongMoi);
			else
				cm.Parameters.AddWithValue("@TenBacLuongMoi", DBNull.Value);
			if (_heSoLuongMoi != 0)
				cm.Parameters.AddWithValue("@HeSoLuongMoi", _heSoLuongMoi);
			else
				cm.Parameters.AddWithValue("@HeSoLuongMoi", DBNull.Value);
			if (_heSoPhuCapChucVuMoi != 0)
				cm.Parameters.AddWithValue("@HeSoPhuCapChucVuMoi", _heSoPhuCapChucVuMoi);
			else
				cm.Parameters.AddWithValue("@HeSoPhuCapChucVuMoi", DBNull.Value);
			if (_heSoVuotKhungMoi != 0)
				cm.Parameters.AddWithValue("@HeSoVuotKhungMoi", _heSoVuotKhungMoi);
			else
				cm.Parameters.AddWithValue("@HeSoVuotKhungMoi", DBNull.Value);
			cm.Parameters.AddWithValue("@MocNangLuongLanSauNew", _mocNangLuongLanSauNew.DBValue);
            cm.Parameters.AddWithValue("@DaChuyenThanhNangLuong", _daChuyenThanhNangLuong);
            cm.Parameters.AddWithValue("@LoaiNV", _loaiNV);
            cm.Parameters.AddWithValue("@KieuNangLuong", _kieuNangLuong);
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

			ExecuteDelete(cn, new Criteria(_iDDenHanNangLuong));
			MarkNew();
		}
		#endregion //Data Access - Delete
		#endregion //Data Access
	}
}
