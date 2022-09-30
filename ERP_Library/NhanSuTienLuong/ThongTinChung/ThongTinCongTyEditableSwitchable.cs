
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{ 
	[Serializable()] 
	public class ThongTinCongTy : Csla.BusinessBase<ThongTinCongTy>
	{
		#region Business Properties and Methods
       
		//declare members
		private long _maNhanVien = 0;
		private string _tenNhanVien = string.Empty;
		private string _maQuanLy = string.Empty;
		private int _maTo = 0;
		private string _tenTo = string.Empty;
		private int _maChiNhanh = 0;
		private string _tenChiNhanh = string.Empty;
		private int _maPhongBan = 0;
		private string _tenPhongBan = string.Empty;
		private int _maChucVu = 0;
		private string _tenChucVu = string.Empty;
		private int _maKiemNhiem = 0;
		private string _tenKiemNhiem = string.Empty;
		private SmartDate _ngayVaoLam = new SmartDate(DateTime.Today);
		private decimal _phanTramLCB = 0;
		private decimal _phanTramLKD = 0;
		private decimal _luongCB = 0;
		private decimal _heSoLuongCB = 0;
        private decimal _soTienHSCB = 0;
		private decimal _luongKD = 0;
		private decimal _heSoLuongKD = 0;
		private decimal _soTienHSKD = 0;
		private short _phanTramBHXH = 0;
		private decimal _tienBHXH = 0;
		private short _phanTramBHYT = 0;
		private decimal _tienBHYT = 0;
		private short _phanTramCongDoan = 0;
		private decimal _soTienCongDoan = 0;
		private decimal _phidoanDang = 0;
		private decimal _phanTramDanhGiaCB = 0;
		private decimal _phanTramDanhGiaKD = 0;
		private decimal _tienNopThue = 0;
		private decimal _soNgayCong = 0;
		private decimal _soNgayLamViec = 0;
		private decimal _soGioTangCa30 = 0;
		private decimal _soTienTangCa30 = 0;
		private decimal _soGioTangCa45 = 0;
		private decimal _soTienTangCa45 = 0;
		private decimal _soGioTangCa60 = 0;
		private decimal _soTienTangCa60 = 0;
		private decimal _tienThucLanh = 0;
		private decimal _tienThucLanhTron = 0;
		private bool _congDoan = false;
		private bool _doan = false;
		private bool _dang = false;
        private decimal _HeSoPhuCapChucVu = 0;
        private decimal _HeSoLuongNoiBo = 0;
        private decimal _HeSoLuongBoSung = 0;
		//declare child member(s)
		//private NghiViecList _nghiViecList = NghiViecList.NewNghiViecList();
		private PhuCapThuongXuyenList _phuCapThuongXuyenList = PhuCapThuongXuyenList.NewPhuCapThuongXuyenList();
		//private ToNhanVienList _toNhanVienList = ToNhanVienList.NewToNhanVienList();
		private BangCongList _bangCongList = BangCongList.NewBangCongList();
		//private LamViecNVList _lichLamViecTheoNVList = LamViecNVList.NewLamViecNVList();
		//private QuaTrinhDGCBHangThangList _quaTrinhDGCBHangThangList = QuaTrinhDGCBHangThangList.NewQuaTrinhDGCBHangThangList();

		[System.ComponentModel.DataObjectField(true, false)]
		public long MaNhanVien
		{
			get
			{
				CanReadProperty("MaNhanVien", true);
				return _maNhanVien;
			}
		}
        public decimal HeSoLuongBoSung
        {
            get
            {
                CanReadProperty("HeSoLuongBoSung", true);
                return _HeSoLuongBoSung;
            }
            set
            {
                CanWriteProperty("HeSoLuongBoSung", true);
                if (!_HeSoLuongBoSung.Equals(value))
                {
                    _HeSoLuongBoSung = value;
                    PropertyHasChanged("HeSoLuongBoSung");
                }
            }
        }
        //_HeSoLuongNoiBo
        public decimal HeSoLuongBaoHiem
        {
            get
            {
                CanReadProperty("HeSoLuongBaoHiem", true);
                return _HeSoLuongNoiBo;
            }
            set
            {
                CanWriteProperty("HeSoLuongBaoHiem", true);
                if (!_HeSoLuongNoiBo.Equals(value))
                {
                    _HeSoLuongNoiBo = value;
                    PropertyHasChanged("HeSoLuongBaoHiem");
                }
            }
        }
        public decimal HeSoPhuCapChucVu
        {
            get
            {
                CanReadProperty("HeSoPhuCapChucVu", true);
                return _HeSoPhuCapChucVu;
            }
            set
            {
                CanWriteProperty("HeSoPhuCapChucVu", true);
                if (!_HeSoPhuCapChucVu.Equals(value))
                {
                    _HeSoPhuCapChucVu = value;
                    PropertyHasChanged("HeSoPhuCapChucVu");
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

		public string MaQuanLy
		{
			get
			{
				CanReadProperty("MaQuanLy", true);
				return _maQuanLy;
			}
			set
			{
				CanWriteProperty("MaQuanLy", true);
				if (value == null) value = string.Empty;
				if (!_maQuanLy.Equals(value))
				{
					_maQuanLy = value;
					PropertyHasChanged("MaQuanLy");
				}
			}
		}

		public int MaTo
		{
			get
			{
				CanReadProperty("MaTo", true);
				return _maTo;
			}
			set
			{
				CanWriteProperty("MaTo", true);
				if (!_maTo.Equals(value))
				{
					_maTo = value;
					PropertyHasChanged("MaTo");
				}
			}
		}

		public string TenTo
		{
			get
			{
				CanReadProperty("TenTo", true);
				return _tenTo;
			}
			set
			{
				CanWriteProperty("TenTo", true);
				if (value == null) value = string.Empty;
				if (!_tenTo.Equals(value))
				{
					_tenTo = value;
					PropertyHasChanged("TenTo");
				}
			}
		}

		public int MaChiNhanh
		{
			get
			{
				CanReadProperty("MaChiNhanh", true);
				return _maChiNhanh;
			}
			set
			{
				CanWriteProperty("MaChiNhanh", true);
				if (!_maChiNhanh.Equals(value))
				{
					_maChiNhanh = value;
					PropertyHasChanged("MaChiNhanh");
				}
			}
		}

		public string TenChiNhanh
		{
			get
			{
				CanReadProperty("TenChiNhanh", true);
				return _tenChiNhanh;
			}
			set
			{
				CanWriteProperty("TenChiNhanh", true);
				if (value == null) value = string.Empty;
				if (!_tenChiNhanh.Equals(value))
				{
					_tenChiNhanh = value;
					PropertyHasChanged("TenChiNhanh");
				}
			}
		}

		public int MaPhongBan
		{
			get
			{
				CanReadProperty("MaPhongBan", true);
				return _maPhongBan;
			}
			set
			{
				CanWriteProperty("MaPhongBan", true);
				if (!_maPhongBan.Equals(value))
				{
					_maPhongBan = value;
					PropertyHasChanged("MaPhongBan");
				}
			}
		}

		public string TenPhongBan
		{
			get
			{
				CanReadProperty("TenPhongBan", true);
				return _tenPhongBan;
			}
			set
			{
				CanWriteProperty("TenPhongBan", true);
				if (value == null) value = string.Empty;
				if (!_tenPhongBan.Equals(value))
				{
					_tenPhongBan = value;
					PropertyHasChanged("TenPhongBan");
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

		public DateTime NgayVaoLam
		{
			get
			{
				CanReadProperty("NgayVaoLam", true);
				return _ngayVaoLam.Date;
			}
             set
            {
                CanWriteProperty(true);
                if (!_ngayVaoLam.Equals(value))
                {
                    _ngayVaoLam = new SmartDate(value);
                    PropertyHasChanged("NgayVaoLam");
                }
            }
		}		

		public decimal PhanTramLCB
		{
			get
			{
				CanReadProperty("PhanTramLCB", true);
				return _phanTramLCB;
			}
			set
			{
				CanWriteProperty("PhanTramLCB", true);
				if (!_phanTramLCB.Equals(value))
				{
					_phanTramLCB = value;
					PropertyHasChanged("PhanTramLCB");
				}
			}
		}

		public decimal PhanTramLKD
		{
			get
			{
				CanReadProperty("PhanTramLKD", true);
				return _phanTramLKD;
			}
			set
			{
				CanWriteProperty("PhanTramLKD", true);
				if (!_phanTramLKD.Equals(value))
				{
					_phanTramLKD = value;
					PropertyHasChanged("PhanTramLKD");
				}
			}
		}

		public decimal LuongCB
		{
			get
			{
				CanReadProperty("LuongCB", true);
				return _luongCB;
			}
			set
			{
				CanWriteProperty("LuongCB", true);
				if (!_luongCB.Equals(value))
				{
					_luongCB = value;
					PropertyHasChanged("LuongCB");
				}
			}
		}

		public decimal HeSoLuongCB
		{
			get
			{
				CanReadProperty("HeSoLuongCB", true);
				return _heSoLuongCB;
			}
			set
			{
				CanWriteProperty("HeSoLuongCB", true);
				if (!_heSoLuongCB.Equals(value))
				{
					_heSoLuongCB = value;
					PropertyHasChanged("HeSoLuongCB");
				}
			}
		}

		public decimal SoTienHSCB
		{
			get
			{
				CanReadProperty("SoTienHSCB", true);
				return _soTienHSCB;
			}
			set
			{
				CanWriteProperty("SoTienHSCB", true);
				if (!_soTienHSCB.Equals(value))
				{
					_soTienHSCB = value;
					PropertyHasChanged("SoTienHSCB");
				}
			}
		}

		public decimal LuongKD
		{
			get
			{
				CanReadProperty("LuongKD", true);
				return _luongKD;
			}
			set
			{
				CanWriteProperty("LuongKD", true);
				if (!_luongKD.Equals(value))
				{
					_luongKD = value;
					PropertyHasChanged("LuongKD");
				}
			}
		}

		public decimal HeSoLuongKD
		{
			get
			{
				CanReadProperty("HeSoLuongKD", true);
				return _heSoLuongKD;
			}
			set
			{
				CanWriteProperty("HeSoLuongKD", true);
				if (!_heSoLuongKD.Equals(value))
				{
					_heSoLuongKD = value;
					PropertyHasChanged("HeSoLuongKD");
				}
			}
		}

		public decimal SoTienHSKD
		{
			get
			{
				CanReadProperty("SoTienHSKD", true);
				return _soTienHSKD;
			}
			set
			{
				CanWriteProperty("SoTienHSKD", true);
				if (!_soTienHSKD.Equals(value))
				{
					_soTienHSKD = value;
					PropertyHasChanged("SoTienHSKD");
				}
			}
		}

		public short PhanTramBHXH
		{
			get
			{
				CanReadProperty("PhanTramBHXH", true);
				return _phanTramBHXH;
			}
			set
			{
				CanWriteProperty("PhanTramBHXH", true);
				if (!_phanTramBHXH.Equals(value))
				{
					_phanTramBHXH = value;
					PropertyHasChanged("PhanTramBHXH");
				}
			}
		}

		public decimal TienBHXH
		{
			get
			{
				CanReadProperty("TienBHXH", true);
				return _tienBHXH;
			}
			set
			{
				CanWriteProperty("TienBHXH", true);
				if (!_tienBHXH.Equals(value))
				{
					_tienBHXH = value;
					PropertyHasChanged("TienBHXH");
				}
			}
		}

		public short PhanTramBHYT
		{
			get
			{
				CanReadProperty("PhanTramBHYT", true);
				return _phanTramBHYT;
			}
			set
			{
				CanWriteProperty("PhanTramBHYT", true);
				if (!_phanTramBHYT.Equals(value))
				{
					_phanTramBHYT = value;
					PropertyHasChanged("PhanTramBHYT");
				}
			}
		}

		public decimal TienBHYT
		{
			get
			{
				CanReadProperty("TienBHYT", true);
				return _tienBHYT;
			}
			set
			{
				CanWriteProperty("TienBHYT", true);
				if (!_tienBHYT.Equals(value))
				{
					_tienBHYT = value;
					PropertyHasChanged("TienBHYT");
				}
			}
		}

		public short PhanTramCongDoan
		{
			get
			{
                CanReadProperty("PhanTramCongDoan", true);
				return _phanTramCongDoan;
			}
			set
			{
				CanWriteProperty("PhanTramCongDoan", true);
				if (!_phanTramCongDoan.Equals(value))
				{
					_phanTramCongDoan = value;
                    PropertyHasChanged("PhanTramCongDoan");
				}
			}
		}

		public decimal SoTienCongDoan
		{
			get
			{
				CanReadProperty("SoTienCongDoan", true);
				return _soTienCongDoan;
			}
			set
			{
				CanWriteProperty("SoTienCongDoan", true);
				if (!_soTienCongDoan.Equals(value))
				{
					_soTienCongDoan = value;
					PropertyHasChanged("SoTienCongDoan");
				}
			}
		}

		public decimal PhidoanDang
		{
			get
			{
				CanReadProperty("PhidoanDang", true);
				return _phidoanDang;
			}
			set
			{
				CanWriteProperty("PhidoanDang", true);
				if (!_phidoanDang.Equals(value))
				{
					_phidoanDang = value;
					PropertyHasChanged("PhidoanDang");
				}
			}
		}

		public decimal PhanTramDanhGiaCB
		{
			get
			{
				CanReadProperty("PhanTramDanhGiaCB", true);
				return _phanTramDanhGiaCB;
			}
			set
			{
				CanWriteProperty("PhanTramDanhGiaCB", true);
				if (!_phanTramDanhGiaCB.Equals(value))
				{
					_phanTramDanhGiaCB = value;
					PropertyHasChanged("PhanTramDanhGiaCB");
				}
			}
		}

		public decimal PhanTramDanhGiaKD
		{
			get
			{
				CanReadProperty("PhanTramDanhGiaKD", true);
				return _phanTramDanhGiaKD;
			}
			set
			{
				CanWriteProperty("PhanTramDanhGiaKD", true);
				if (!_phanTramDanhGiaKD.Equals(value))
				{
					_phanTramDanhGiaKD = value;
					PropertyHasChanged("PhanTramDanhGiaKD");
				}
			}
		}

		public decimal TienNopThue
		{
			get
			{
				CanReadProperty("TienNopThue", true);
				return _tienNopThue;
			}
			set
			{
				CanWriteProperty("TienNopThue", true);
				if (!_tienNopThue.Equals(value))
				{
					_tienNopThue = value;
					PropertyHasChanged("TienNopThue");
				}
			}
		}

		public decimal SoNgayCong
		{
			get
			{
				CanReadProperty("SoNgayCong", true);
				return _soNgayCong;
			}
			set
			{
				CanWriteProperty("SoNgayCong", true);
				if (!_soNgayCong.Equals(value))
				{
					_soNgayCong = value;
					PropertyHasChanged("SoNgayCong");
				}
			}
		}

		public decimal SoNgayLamViec
		{
			get
			{
				CanReadProperty("SoNgayLamViec", true);
				return _soNgayLamViec;
			}
			set
			{
				CanWriteProperty("SoNgayLamViec", true);
				if (!_soNgayLamViec.Equals(value))
				{
					_soNgayLamViec = value;
					PropertyHasChanged("SoNgayLamViec");
				}
			}
		}

		public decimal SoGioTangCa30
		{
			get
			{
				CanReadProperty("SoGioTangCa30", true);
				return _soGioTangCa30;
			}
			set
			{
				CanWriteProperty("SoGioTangCa30", true);
				if (!_soGioTangCa30.Equals(value))
				{
					_soGioTangCa30 = value;
					PropertyHasChanged("SoGioTangCa30");
				}
			}
		}

		public decimal SoTienTangCa30
		{
			get
			{
				CanReadProperty("SoTienTangCa30", true);
				return _soTienTangCa30;
			}
			set
			{
				CanWriteProperty("SoTienTangCa30", true);
				if (!_soTienTangCa30.Equals(value))
				{
					_soTienTangCa30 = value;
					PropertyHasChanged("SoTienTangCa30");
				}
			}
		}

		public decimal SoGioTangCa45
		{
			get
			{
				CanReadProperty("SoGioTangCa45", true);
				return _soGioTangCa45;
			}
			set
			{
				CanWriteProperty("SoGioTangCa45", true);
				if (!_soGioTangCa45.Equals(value))
				{
					_soGioTangCa45 = value;
					PropertyHasChanged("SoGioTangCa45");
				}
			}
		}

		public decimal SoTienTangCa45
		{
			get
			{
				CanReadProperty("SoTienTangCa45", true);
				return _soTienTangCa45;
			}
			set
			{
				CanWriteProperty("SoTienTangCa45", true);
				if (!_soTienTangCa45.Equals(value))
				{
					_soTienTangCa45 = value;
					PropertyHasChanged("SoTienTangCa45");
				}
			}
		}

		public decimal SoGioTangCa60
		{
			get
			{
				CanReadProperty("SoGioTangCa60", true);
				return _soGioTangCa60;
			}
			set
			{
				CanWriteProperty("SoGioTangCa60", true);
				if (!_soGioTangCa60.Equals(value))
				{
					_soGioTangCa60 = value;
					PropertyHasChanged("SoGioTangCa60");
				}
			}
		}

		public decimal SoTienTangCa60
		{
			get
			{
				CanReadProperty("SoTienTangCa60", true);
				return _soTienTangCa60;
			}
			set
			{
				CanWriteProperty("SoTienTangCa60", true);
				if (!_soTienTangCa60.Equals(value))
				{
					_soTienTangCa60 = value;
					PropertyHasChanged("SoTienTangCa60");
				}
			}
		}

		public decimal TienThucLanh
		{
			get
			{
				CanReadProperty("TienThucLanh", true);
				return _tienThucLanh;
			}
			set
			{
				CanWriteProperty("TienThucLanh", true);
				if (!_tienThucLanh.Equals(value))
				{
					_tienThucLanh = value;
					PropertyHasChanged("TienThucLanh");
				}
			}
		}

		public decimal TienThucLanhTron
		{
			get
			{
				CanReadProperty("TienThucLanhTron", true);
				return _tienThucLanhTron;
			}
			set
			{
				CanWriteProperty("TienThucLanhTron", true);
				if (!_tienThucLanhTron.Equals(value))
				{
					_tienThucLanhTron = value;
					PropertyHasChanged("TienThucLanhTron");
				}
			}
		}

		public bool CongDoan
		{
			get
			{
				CanReadProperty("CongDoan", true);
				return _congDoan;
			}
			set
			{
				CanWriteProperty("CongDoan", true);
				if (!_congDoan.Equals(value))
				{
					_congDoan = value;
					PropertyHasChanged("CongDoan");
				}
			}
		}

		public bool Doan
		{
			get
			{
				CanReadProperty("Doan", true);
				return _doan;
			}
			set
			{
				CanWriteProperty("Doan", true);
				if (!_doan.Equals(value))
				{
					_doan = value;
					PropertyHasChanged("Doan");
				}
			}
		}

		public bool Dang
		{
			get
			{
				CanReadProperty("Dang", true);
				return _dang;
			}
			set
			{
				CanWriteProperty("Dang", true);
				if (!_dang.Equals(value))
				{
					_dang = value;
					PropertyHasChanged("Dang");
				}
			}
		}

        //public NghiViecList NghiViecList
        //{
        //    get
        //    {
        //        CanReadProperty("NghiViecList", true);
        //        return _nghiViecList;
        //    }
        //}

		public PhuCapThuongXuyenList PhuCapThuongXuyenList
		{
			get
			{
				CanReadProperty("PhuCapThuongXuyenList", true);
				return _phuCapThuongXuyenList;
			}
		}

        //public ToNhanVienList ToNhanVienList
        //{
        //    get
        //    {
        //        CanReadProperty("ToNhanVienList", true);
        //        return _toNhanVienList;
        //    }
        //}

		public BangCongList BangCongList
		{
			get
			{
				CanReadProperty("BangCongList", true);
				return _bangCongList;
			}
		}

        //public LamViecNVList LichLamViecTheoNVList
        //{
        //    get
        //    {
        //        CanReadProperty("LichLamViecTheoNVList", true);
        //        return _lichLamViecTheoNVList;
        //    }
        //}

        //public QuaTrinhDGCBHangThangList QuaTrinhDGCBHangThangList
        //{
        //    get
        //    {
        //        CanReadProperty("QuaTrinhDGCBHangThangList", true);
        //        return _quaTrinhDGCBHangThangList;
        //    }
        //}
 
		public override bool IsValid
		{
			get { return base.IsValid &&  _phuCapThuongXuyenList.IsValid && _bangCongList.IsValid ; }
		}

		public override bool IsDirty
		{
            get { return base.IsDirty || _phuCapThuongXuyenList.IsDirty || _bangCongList.IsDirty ; }
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
			// TenNhanVien
			//
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("TenNhanVien", 200));
			//
			// MaQuanLy
			//
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("MaQuanLy", 20));
			//
			// TenTo
			//
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("TenTo", 200));
			//
			// TenChiNhanh
			//
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("TenChiNhanh", 500));
			//
			// TenPhongBan
			//
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("TenPhongBan", 500));
			//
			// TenChucVu
			//
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("TenChucVu", 500));
			//
			// TenKiemNhiem
			//
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("TenKiemNhiem", 500));
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
			//TODO: Define authorization rules in ThongTinCongTy
			//AuthorizationRules.AllowRead("NghiViecList", "ThongTinCongTyReadGroup");
			//AuthorizationRules.AllowRead("PhuCapThuongXuyenList", "ThongTinCongTyReadGroup");
			//AuthorizationRules.AllowRead("ToNhanVienList", "ThongTinCongTyReadGroup");
			//AuthorizationRules.AllowRead("BangCongList", "ThongTinCongTyReadGroup");
			//AuthorizationRules.AllowRead("LichLamViecTheoNVList", "ThongTinCongTyReadGroup");
			//AuthorizationRules.AllowRead("QuaTrinhDGCBHangThangList", "ThongTinCongTyReadGroup");
			//AuthorizationRules.AllowRead("MaNhanVien", "ThongTinCongTyReadGroup");
			//AuthorizationRules.AllowRead("TenNhanVien", "ThongTinCongTyReadGroup");
			//AuthorizationRules.AllowRead("MaQuanLy", "ThongTinCongTyReadGroup");
			//AuthorizationRules.AllowRead("MaTo", "ThongTinCongTyReadGroup");
			//AuthorizationRules.AllowRead("TenTo", "ThongTinCongTyReadGroup");
			//AuthorizationRules.AllowRead("MaChiNhanh", "ThongTinCongTyReadGroup");
			//AuthorizationRules.AllowRead("TenChiNhanh", "ThongTinCongTyReadGroup");
			//AuthorizationRules.AllowRead("MaPhongBan", "ThongTinCongTyReadGroup");
			//AuthorizationRules.AllowRead("TenPhongBan", "ThongTinCongTyReadGroup");
			//AuthorizationRules.AllowRead("MaChucVu", "ThongTinCongTyReadGroup");
			//AuthorizationRules.AllowRead("TenChucVu", "ThongTinCongTyReadGroup");
			//AuthorizationRules.AllowRead("MaKiemNhiem", "ThongTinCongTyReadGroup");
			//AuthorizationRules.AllowRead("TenKiemNhiem", "ThongTinCongTyReadGroup");
			//AuthorizationRules.AllowRead("NgayVaoLam", "ThongTinCongTyReadGroup");
			//AuthorizationRules.AllowRead("NgayVaoLamString", "ThongTinCongTyReadGroup");
			//AuthorizationRules.AllowRead("PhanTramLCB", "ThongTinCongTyReadGroup");
			//AuthorizationRules.AllowRead("PhanTramLKD", "ThongTinCongTyReadGroup");
			//AuthorizationRules.AllowRead("LuongCB", "ThongTinCongTyReadGroup");
			//AuthorizationRules.AllowRead("HeSoLuongCB", "ThongTinCongTyReadGroup");
			//AuthorizationRules.AllowRead("SoTienHSCB", "ThongTinCongTyReadGroup");
			//AuthorizationRules.AllowRead("LuongKD", "ThongTinCongTyReadGroup");
			//AuthorizationRules.AllowRead("HeSoLuongKD", "ThongTinCongTyReadGroup");
			//AuthorizationRules.AllowRead("SoTienHSKD", "ThongTinCongTyReadGroup");
			//AuthorizationRules.AllowRead("PhanTramBHXH", "ThongTinCongTyReadGroup");
			//AuthorizationRules.AllowRead("TienBHXH", "ThongTinCongTyReadGroup");
			//AuthorizationRules.AllowRead("PhanTramBHYT", "ThongTinCongTyReadGroup");
			//AuthorizationRules.AllowRead("TienBHYT", "ThongTinCongTyReadGroup");
			//AuthorizationRules.AllowRead("PhanTramCongDoan", "ThongTinCongTyReadGroup");
			//AuthorizationRules.AllowRead("SoTienCongDoan", "ThongTinCongTyReadGroup");
			//AuthorizationRules.AllowRead("PhidoanDang", "ThongTinCongTyReadGroup");
			//AuthorizationRules.AllowRead("PhanTramDanhGiaCB", "ThongTinCongTyReadGroup");
			//AuthorizationRules.AllowRead("PhanTramDanhGiaKD", "ThongTinCongTyReadGroup");
			//AuthorizationRules.AllowRead("TienNopThue", "ThongTinCongTyReadGroup");
			//AuthorizationRules.AllowRead("SoNgayCong", "ThongTinCongTyReadGroup");
			//AuthorizationRules.AllowRead("SoNgayLamViec", "ThongTinCongTyReadGroup");
			//AuthorizationRules.AllowRead("SoGioTangCa30", "ThongTinCongTyReadGroup");
			//AuthorizationRules.AllowRead("SoTienTangCa30", "ThongTinCongTyReadGroup");
			//AuthorizationRules.AllowRead("SoGioTangCa45", "ThongTinCongTyReadGroup");
			//AuthorizationRules.AllowRead("SoTienTangCa45", "ThongTinCongTyReadGroup");
			//AuthorizationRules.AllowRead("SoGioTangCa60", "ThongTinCongTyReadGroup");
			//AuthorizationRules.AllowRead("SoTienTangCa60", "ThongTinCongTyReadGroup");
			//AuthorizationRules.AllowRead("TienThucLanh", "ThongTinCongTyReadGroup");
			//AuthorizationRules.AllowRead("TienThucLanhTron", "ThongTinCongTyReadGroup");
			//AuthorizationRules.AllowRead("CongDoan", "ThongTinCongTyReadGroup");
			//AuthorizationRules.AllowRead("Doan", "ThongTinCongTyReadGroup");
			//AuthorizationRules.AllowRead("Dang", "ThongTinCongTyReadGroup");

			//AuthorizationRules.AllowWrite("TenNhanVien", "ThongTinCongTyWriteGroup");
			//AuthorizationRules.AllowWrite("MaQuanLy", "ThongTinCongTyWriteGroup");
			//AuthorizationRules.AllowWrite("MaTo", "ThongTinCongTyWriteGroup");
			//AuthorizationRules.AllowWrite("TenTo", "ThongTinCongTyWriteGroup");
			//AuthorizationRules.AllowWrite("MaChiNhanh", "ThongTinCongTyWriteGroup");
			//AuthorizationRules.AllowWrite("TenChiNhanh", "ThongTinCongTyWriteGroup");
			//AuthorizationRules.AllowWrite("MaPhongBan", "ThongTinCongTyWriteGroup");
			//AuthorizationRules.AllowWrite("TenPhongBan", "ThongTinCongTyWriteGroup");
			//AuthorizationRules.AllowWrite("MaChucVu", "ThongTinCongTyWriteGroup");
			//AuthorizationRules.AllowWrite("TenChucVu", "ThongTinCongTyWriteGroup");
			//AuthorizationRules.AllowWrite("MaKiemNhiem", "ThongTinCongTyWriteGroup");
			//AuthorizationRules.AllowWrite("TenKiemNhiem", "ThongTinCongTyWriteGroup");
			//AuthorizationRules.AllowWrite("NgayVaoLamString", "ThongTinCongTyWriteGroup");
			//AuthorizationRules.AllowWrite("PhanTramLCB", "ThongTinCongTyWriteGroup");
			//AuthorizationRules.AllowWrite("PhanTramLKD", "ThongTinCongTyWriteGroup");
			//AuthorizationRules.AllowWrite("LuongCB", "ThongTinCongTyWriteGroup");
			//AuthorizationRules.AllowWrite("HeSoLuongCB", "ThongTinCongTyWriteGroup");
			//AuthorizationRules.AllowWrite("SoTienHSCB", "ThongTinCongTyWriteGroup");
			//AuthorizationRules.AllowWrite("LuongKD", "ThongTinCongTyWriteGroup");
			//AuthorizationRules.AllowWrite("HeSoLuongKD", "ThongTinCongTyWriteGroup");
			//AuthorizationRules.AllowWrite("SoTienHSKD", "ThongTinCongTyWriteGroup");
			//AuthorizationRules.AllowWrite("PhanTramBHXH", "ThongTinCongTyWriteGroup");
			//AuthorizationRules.AllowWrite("TienBHXH", "ThongTinCongTyWriteGroup");
			//AuthorizationRules.AllowWrite("PhanTramBHYT", "ThongTinCongTyWriteGroup");
			//AuthorizationRules.AllowWrite("TienBHYT", "ThongTinCongTyWriteGroup");
			//AuthorizationRules.AllowWrite("PhanTramCongDoan", "ThongTinCongTyWriteGroup");
			//AuthorizationRules.AllowWrite("SoTienCongDoan", "ThongTinCongTyWriteGroup");
			//AuthorizationRules.AllowWrite("PhidoanDang", "ThongTinCongTyWriteGroup");
			//AuthorizationRules.AllowWrite("PhanTramDanhGiaCB", "ThongTinCongTyWriteGroup");
			//AuthorizationRules.AllowWrite("PhanTramDanhGiaKD", "ThongTinCongTyWriteGroup");
			//AuthorizationRules.AllowWrite("TienNopThue", "ThongTinCongTyWriteGroup");
			//AuthorizationRules.AllowWrite("SoNgayCong", "ThongTinCongTyWriteGroup");
			//AuthorizationRules.AllowWrite("SoNgayLamViec", "ThongTinCongTyWriteGroup");
			//AuthorizationRules.AllowWrite("SoGioTangCa30", "ThongTinCongTyWriteGroup");
			//AuthorizationRules.AllowWrite("SoTienTangCa30", "ThongTinCongTyWriteGroup");
			//AuthorizationRules.AllowWrite("SoGioTangCa45", "ThongTinCongTyWriteGroup");
			//AuthorizationRules.AllowWrite("SoTienTangCa45", "ThongTinCongTyWriteGroup");
			//AuthorizationRules.AllowWrite("SoGioTangCa60", "ThongTinCongTyWriteGroup");
			//AuthorizationRules.AllowWrite("SoTienTangCa60", "ThongTinCongTyWriteGroup");
			//AuthorizationRules.AllowWrite("TienThucLanh", "ThongTinCongTyWriteGroup");
			//AuthorizationRules.AllowWrite("TienThucLanhTron", "ThongTinCongTyWriteGroup");
			//AuthorizationRules.AllowWrite("CongDoan", "ThongTinCongTyWriteGroup");
			//AuthorizationRules.AllowWrite("Doan", "ThongTinCongTyWriteGroup");
			//AuthorizationRules.AllowWrite("Dang", "ThongTinCongTyWriteGroup");
		}


		public static bool CanGetObject()
		{
			//TODO: Define CanGetObject permission in ThongTinCongTy
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("ThongTinCongTyViewGroup"))
			//	return true;
			//return false;
		}

		public static bool CanAddObject()
		{
			//TODO: Define CanAddObject permission in ThongTinCongTy
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("ThongTinCongTyAddGroup"))
			//	return true;
			//return false;
		}

		public static bool CanEditObject()
		{
			//TODO: Define CanEditObject permission in ThongTinCongTy
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("ThongTinCongTyEditGroup"))
			//	return true;
			//return false;
		}

		public static bool CanDeleteObject()
		{
			//TODO: Define CanDeleteObject permission in ThongTinCongTy
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("ThongTinCongTyDeleteGroup"))
			//	return true;
			//return false;
		}
		#endregion //Authorization Rules

		#region Factory Methods
		private ThongTinCongTy()
		{ /* require use of factory method */ }

		public static ThongTinCongTy NewThongTinCongTy()
		{
			if (!CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a ThongTinCongTy");
			return DataPortal.Create<ThongTinCongTy>(new CriteriaAll());
		}

		public static ThongTinCongTy GetThongTinCongTy(long maNhanVien)
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException("User not authorized to view a ThongTinCongTy");
			return DataPortal.Fetch<ThongTinCongTy>(new Criteria(maNhanVien));
		}

		public static void DeleteThongTinCongTy(long maNhanVien)
		{
			if (!CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a ThongTinCongTy");
			DataPortal.Delete(new Criteria(maNhanVien));
		}

		public override ThongTinCongTy Save()
		{
			if (IsDeleted && !CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a ThongTinCongTy");
			else if (IsNew && !CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a ThongTinCongTy");
			else if (!CanEditObject())
				throw new System.Security.SecurityException("User not authorized to update a ThongTinCongTy");

			return base.Save();
		}

		#endregion //Factory Methods

		#region Child Factory Methods
		private ThongTinCongTy(long maNhanVien)
		{
			this._maNhanVien = maNhanVien;
		}

		internal static ThongTinCongTy NewThongTinCongTyChild(long maNhanVien)
		{
			ThongTinCongTy child = new ThongTinCongTy(maNhanVien);
			child.ValidationRules.CheckRules();
			child.MarkAsChild();
			return child;
		}
        internal static ThongTinCongTy GetNhanVien(SafeDataReader dr)
        {
            ThongTinCongTy child = new ThongTinCongTy();
            child.MarkAsChild();
            child._maNhanVien = dr.GetInt64("MaNhanVien");                        
            child._tenNhanVien = dr.GetString("TenNhanVien");
            child._maQuanLy = dr.GetString("MaQuanLy");
            return child;
        }
		internal static ThongTinCongTy GetThongTinCongTy(SafeDataReader dr)
		{
			ThongTinCongTy child =  new ThongTinCongTy();
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
				cm.CommandText = "spd_SelecttblnsThongTinCongTy";

				cm.Parameters.AddWithValue("@MaNhanVien", criteria.MaNhanVien);

				using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
				{
					dr.Read();
					FetchObject(dr);
					ValidationRules.CheckRules();

					//load child object(s)
					FetchChildren(_maNhanVien);
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
				cm.CommandText = "spd_DeletetblnsThongTinCongTy";

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
			ValidationRules.CheckRules();

			//load child object(s)
			FetchChildren(_maNhanVien);
		}

		private void FetchObject(SafeDataReader dr)
		{
			_maNhanVien = dr.GetInt64("MaNhanVien");
			_tenNhanVien = dr.GetString("TenNhanVien");
			_maQuanLy = dr.GetString("MaQuanLy");
			_maTo = dr.GetInt32("MaTo");
			_tenTo = dr.GetString("TenTo");
			_maChiNhanh = dr.GetInt32("MaChiNhanh");
			_tenChiNhanh = dr.GetString("TenChiNhanh");
			_maPhongBan = dr.GetInt32("MaPhongBan");
			_tenPhongBan = dr.GetString("TenPhongBan");
			_maChucVu = dr.GetInt32("MaChucVu");
			_tenChucVu = dr.GetString("TenChucVu");
			_maKiemNhiem = dr.GetInt32("MaKiemNhiem");
			_tenKiemNhiem = dr.GetString("TenKiemNhiem");
			_ngayVaoLam = dr.GetSmartDate("NgayVaoLam", _ngayVaoLam.EmptyIsMin);
			_phanTramLCB = dr.GetDecimal("PhanTramLCB");
			_phanTramLKD = dr.GetDecimal("PhanTramLKD");
			_luongCB = dr.GetDecimal("LuongCB");
			_heSoLuongCB = dr.GetDecimal("HeSoLuongCB");
			_soTienHSCB = dr.GetDecimal("SoTienHSCB");
			_luongKD = dr.GetDecimal("LuongKD");
			_heSoLuongKD = dr.GetDecimal("HeSoLuongKD");
			_soTienHSKD = dr.GetDecimal("SoTienHSKD");
			_phanTramBHXH = dr.GetInt16("PhanTramBHXH");
			_tienBHXH = dr.GetDecimal("TienBHXH");
			_phanTramBHYT = dr.GetInt16("PhanTramBHYT");
			_tienBHYT = dr.GetDecimal("TienBHYT");
            _phanTramCongDoan = dr.GetInt16("PhanTramCongDoan");
			_soTienCongDoan = dr.GetDecimal("SoTienCongDoan");
			_phidoanDang = dr.GetDecimal("PhiDoan_Dang");
			_phanTramDanhGiaCB = dr.GetDecimal("PhanTramDanhGiaCB");
			_phanTramDanhGiaKD = dr.GetDecimal("PhanTramDanhGiaKD");
			_tienNopThue = dr.GetDecimal("TienNopThue");
			_soNgayCong = dr.GetDecimal("SoNgayCong");
			_soNgayLamViec = dr.GetDecimal("SoNgayLamViec");
			_soGioTangCa30 = dr.GetDecimal("SoGioTangCa30");
			_soTienTangCa30 = dr.GetDecimal("SoTienTangCa30");
			_soGioTangCa45 = dr.GetDecimal("SoGioTangCa45");
			_soTienTangCa45 = dr.GetDecimal("SoTienTangCa45");
			_soGioTangCa60 = dr.GetDecimal("SoGioTangCa60");
			_soTienTangCa60 = dr.GetDecimal("SoTienTangCa60");
			_tienThucLanh = dr.GetDecimal("TienThucLanh");
			_tienThucLanhTron = dr.GetDecimal("TienThucLanhTron");
			_congDoan = dr.GetBoolean("CongDoan");
			_doan = dr.GetBoolean("Doan");
			_dang = dr.GetBoolean("Dang");
		}

		private void FetchChildren(long maNhanVien)
		{			
			//_nghiViecList = NghiViecList.GetNghiViecList(maNhanVien);			
            //_phuCapThuongXuyenList = PhuCapThuongXuyenList.GetPhuCapThuongXuyenList(dr);            
            //_toNhanVienList = ToNhanVienList.GetToNhanVienList(maNhanVien);
			//_bangCongList = BangCongList.GetBangCongList(maNhanVien);			
            //_lichLamViecTheoNVList = LamViecNVList.GetLamViecNVList_MaNV(maNhanVien);			
            //_quaTrinhDGCBHangThangList = QuaTrinhDGCBHangThangList.GetQuaTrinhDGCBHangThangList(maNhanVien);
		}
		#endregion //Data Access - Fetch

		#region Data Access - Insert
		internal void Insert(SqlTransaction tr, NhanVien parent)
		{
			if (!IsDirty) return;

			ExecuteInsert(tr, parent);
			MarkOld();

			//update child object(s)
			UpdateChildren(tr);
		}

		private void ExecuteInsert(SqlTransaction tr, NhanVien parent)
		{
			using (SqlCommand cm = tr.Connection.CreateCommand())
			{
				cm.Transaction = tr;
				cm.CommandType = CommandType.StoredProcedure;
				cm.CommandText = "spd_InserttblnsThongTinCongTy";

				AddInsertParameters(cm, parent);

				cm.ExecuteNonQuery();

			}//using
		}

		private void AddInsertParameters(SqlCommand cm, NhanVien parent)
		{
			//TODO: if parent use identity key, fix fk member with value from parent
			cm.Parameters.AddWithValue("@MaNhanVien", parent.MaNhanVien);
			if (_tenNhanVien.Length > 0)
				cm.Parameters.AddWithValue("@TenNhanVien", _tenNhanVien);
			else
				cm.Parameters.AddWithValue("@TenNhanVien", DBNull.Value);
			if (_maQuanLy.Length > 0)
				cm.Parameters.AddWithValue("@MaQuanLy", _maQuanLy);
			else
				cm.Parameters.AddWithValue("@MaQuanLy", DBNull.Value);
			if (_maTo != 0)
				cm.Parameters.AddWithValue("@MaTo", _maTo);
			else
				cm.Parameters.AddWithValue("@MaTo", DBNull.Value);
			if (_tenTo.Length > 0)
				cm.Parameters.AddWithValue("@TenTo", _tenTo);
			else
				cm.Parameters.AddWithValue("@TenTo", DBNull.Value);
			if (_maChiNhanh != 0)
				cm.Parameters.AddWithValue("@MaChiNhanh", _maChiNhanh);
			else
				cm.Parameters.AddWithValue("@MaChiNhanh", DBNull.Value);
			if (_tenChiNhanh.Length > 0)
				cm.Parameters.AddWithValue("@TenChiNhanh", _tenChiNhanh);
			else
				cm.Parameters.AddWithValue("@TenChiNhanh", DBNull.Value);
			if (_maPhongBan != 0)
				cm.Parameters.AddWithValue("@MaPhongBan", _maPhongBan);
			else
				cm.Parameters.AddWithValue("@MaPhongBan", DBNull.Value);
			if (_tenPhongBan.Length > 0)
				cm.Parameters.AddWithValue("@TenPhongBan", _tenPhongBan);
			else
				cm.Parameters.AddWithValue("@TenPhongBan", DBNull.Value);
			if (_maChucVu != 0)
				cm.Parameters.AddWithValue("@MaChucVu", _maChucVu);
			else
				cm.Parameters.AddWithValue("@MaChucVu", DBNull.Value);
			if (_tenChucVu.Length > 0)
				cm.Parameters.AddWithValue("@TenChucVu", _tenChucVu);
			else
				cm.Parameters.AddWithValue("@TenChucVu", DBNull.Value);
			if (_maKiemNhiem != 0)
				cm.Parameters.AddWithValue("@MaKiemNhiem", _maKiemNhiem);
			else
				cm.Parameters.AddWithValue("@MaKiemNhiem", DBNull.Value);
			if (_tenKiemNhiem.Length > 0)
				cm.Parameters.AddWithValue("@TenKiemNhiem", _tenKiemNhiem);
			else
				cm.Parameters.AddWithValue("@TenKiemNhiem", DBNull.Value);
			cm.Parameters.AddWithValue("@NgayVaoLam", _ngayVaoLam.DBValue);
			if (_phanTramLCB != 0)
				cm.Parameters.AddWithValue("@PhanTramLCB", _phanTramLCB);
			else
				cm.Parameters.AddWithValue("@PhanTramLCB", DBNull.Value);
			if (_phanTramLKD != 0)
				cm.Parameters.AddWithValue("@PhanTramLKD", _phanTramLKD);
			else
				cm.Parameters.AddWithValue("@PhanTramLKD", DBNull.Value);
			if (_luongCB != 0)
				cm.Parameters.AddWithValue("@LuongCB", _luongCB);
			else
				cm.Parameters.AddWithValue("@LuongCB", DBNull.Value);
			if (_heSoLuongCB != 0)
				cm.Parameters.AddWithValue("@HeSoLuongCB", _heSoLuongCB);
			else
				cm.Parameters.AddWithValue("@HeSoLuongCB", DBNull.Value);
            _soTienHSCB = _luongCB * _heSoLuongCB;
			cm.Parameters.AddWithValue("@SoTienHSCB", _soTienHSCB);
			
			if (_luongKD != 0)
				cm.Parameters.AddWithValue("@LuongKD", _luongKD);
			else
				cm.Parameters.AddWithValue("@LuongKD", DBNull.Value);
			if (_heSoLuongKD != 0)
				cm.Parameters.AddWithValue("@HeSoLuongKD", _heSoLuongKD);
			else
				cm.Parameters.AddWithValue("@HeSoLuongKD", DBNull.Value);
            _soTienHSKD = _luongKD * _heSoLuongKD;
			cm.Parameters.AddWithValue("@SoTienHSKD", _soTienHSKD);
			
			if (_phanTramBHXH != 0)
				cm.Parameters.AddWithValue("@PhanTramBHXH", _phanTramBHXH);
			else
				cm.Parameters.AddWithValue("@PhanTramBHXH", DBNull.Value);
			if (_tienBHXH != 0)
				cm.Parameters.AddWithValue("@TienBHXH", _tienBHXH);
			else
				cm.Parameters.AddWithValue("@TienBHXH", DBNull.Value);
			if (_phanTramBHYT != 0)
				cm.Parameters.AddWithValue("@PhanTramBHYT", _phanTramBHYT);
			else
				cm.Parameters.AddWithValue("@PhanTramBHYT", DBNull.Value);
			if (_tienBHYT != 0)
				cm.Parameters.AddWithValue("@TienBHYT", _tienBHYT);
			else
				cm.Parameters.AddWithValue("@TienBHYT", DBNull.Value);
			if (_phanTramCongDoan != 0)
				cm.Parameters.AddWithValue("@PhanTramCongDoan", _phanTramCongDoan);
			else
				cm.Parameters.AddWithValue("@PhanTramCongDoan", DBNull.Value);
			if (_soTienCongDoan != 0)
				cm.Parameters.AddWithValue("@SoTienCongDoan", _soTienCongDoan);
			else
				cm.Parameters.AddWithValue("@SoTienCongDoan", DBNull.Value);
			if (_phidoanDang != 0)
				cm.Parameters.AddWithValue("@PhiDoan_Dang", _phidoanDang);
			else
				cm.Parameters.AddWithValue("@PhiDoan_Dang", DBNull.Value);
			if (_phanTramDanhGiaCB != 0)
				cm.Parameters.AddWithValue("@PhanTramDanhGiaCB", _phanTramDanhGiaCB);
			else
				cm.Parameters.AddWithValue("@PhanTramDanhGiaCB", DBNull.Value);
			if (_phanTramDanhGiaKD != 0)
				cm.Parameters.AddWithValue("@PhanTramDanhGiaKD", _phanTramDanhGiaKD);
			else
				cm.Parameters.AddWithValue("@PhanTramDanhGiaKD", DBNull.Value);
			if (_tienNopThue != 0)
				cm.Parameters.AddWithValue("@TienNopThue", _tienNopThue);
			else
				cm.Parameters.AddWithValue("@TienNopThue", DBNull.Value);
			if (_soNgayCong != 0)
				cm.Parameters.AddWithValue("@SoNgayCong", _soNgayCong);
			else
				cm.Parameters.AddWithValue("@SoNgayCong", DBNull.Value);
			if (_soNgayLamViec != 0)
				cm.Parameters.AddWithValue("@SoNgayLamViec", _soNgayLamViec);
			else
				cm.Parameters.AddWithValue("@SoNgayLamViec", DBNull.Value);
			if (_soGioTangCa30 != 0)
				cm.Parameters.AddWithValue("@SoGioTangCa30", _soGioTangCa30);
			else
				cm.Parameters.AddWithValue("@SoGioTangCa30", DBNull.Value);
			if (_soTienTangCa30 != 0)
				cm.Parameters.AddWithValue("@SoTienTangCa30", _soTienTangCa30);
			else
				cm.Parameters.AddWithValue("@SoTienTangCa30", DBNull.Value);
			if (_soGioTangCa45 != 0)
				cm.Parameters.AddWithValue("@SoGioTangCa45", _soGioTangCa45);
			else
				cm.Parameters.AddWithValue("@SoGioTangCa45", DBNull.Value);
			if (_soTienTangCa45 != 0)
				cm.Parameters.AddWithValue("@SoTienTangCa45", _soTienTangCa45);
			else
				cm.Parameters.AddWithValue("@SoTienTangCa45", DBNull.Value);
			if (_soGioTangCa60 != 0)
				cm.Parameters.AddWithValue("@SoGioTangCa60", _soGioTangCa60);
			else
				cm.Parameters.AddWithValue("@SoGioTangCa60", DBNull.Value);
			if (_soTienTangCa60 != 0)
				cm.Parameters.AddWithValue("@SoTienTangCa60", _soTienTangCa60);
			else
				cm.Parameters.AddWithValue("@SoTienTangCa60", DBNull.Value);
			if (_tienThucLanh != 0)
				cm.Parameters.AddWithValue("@TienThucLanh", _tienThucLanh);
			else
				cm.Parameters.AddWithValue("@TienThucLanh", DBNull.Value);
			if (_tienThucLanhTron != 0)
				cm.Parameters.AddWithValue("@TienThucLanhTron", _tienThucLanhTron);
			else
				cm.Parameters.AddWithValue("@TienThucLanhTron", DBNull.Value);
			if (_congDoan != false)
				cm.Parameters.AddWithValue("@CongDoan", _congDoan);
			else
				cm.Parameters.AddWithValue("@CongDoan", DBNull.Value);
			if (_doan != false)
				cm.Parameters.AddWithValue("@Doan", _doan);
			else
				cm.Parameters.AddWithValue("@Doan", DBNull.Value);
			if (_dang != false)
				cm.Parameters.AddWithValue("@Dang", _dang);
			else
				cm.Parameters.AddWithValue("@Dang", DBNull.Value);
		}
		#endregion //Data Access - Insert

		#region Data Access - Update
		internal void Update(SqlTransaction tr, NhanVien parent)
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

		private void ExecuteUpdate(SqlTransaction tr, NhanVien parent)
		{
			using (SqlCommand cm = tr.Connection.CreateCommand())
			{
				cm.Transaction = tr;
				cm.CommandType = CommandType.StoredProcedure;
				cm.CommandText = "spd_UpdatetblnsThongTinCongTy";

				AddUpdateParameters(cm, parent);

				cm.ExecuteNonQuery();

			}//using
		}

		private void AddUpdateParameters(SqlCommand cm, NhanVien parent)
		{
			cm.Parameters.AddWithValue("@MaNhanVien", parent.MaNhanVien);
			if (_tenNhanVien.Length > 0)
				cm.Parameters.AddWithValue("@TenNhanVien", _tenNhanVien);
			else
				cm.Parameters.AddWithValue("@TenNhanVien", DBNull.Value);
			if (_maQuanLy.Length > 0)
				cm.Parameters.AddWithValue("@MaQuanLy", _maQuanLy);
			else
				cm.Parameters.AddWithValue("@MaQuanLy", DBNull.Value);
			if (_maTo != 0)
				cm.Parameters.AddWithValue("@MaTo", _maTo);
			else
				cm.Parameters.AddWithValue("@MaTo", DBNull.Value);
			if (_tenTo.Length > 0)
				cm.Parameters.AddWithValue("@TenTo", _tenTo);
			else
				cm.Parameters.AddWithValue("@TenTo", DBNull.Value);
			if (_maChiNhanh != 0)
				cm.Parameters.AddWithValue("@MaChiNhanh", _maChiNhanh);
			else
				cm.Parameters.AddWithValue("@MaChiNhanh", DBNull.Value);
			if (_tenChiNhanh.Length > 0)
				cm.Parameters.AddWithValue("@TenChiNhanh", _tenChiNhanh);
			else
				cm.Parameters.AddWithValue("@TenChiNhanh", DBNull.Value);
			if (_maPhongBan != 0)
				cm.Parameters.AddWithValue("@MaPhongBan", _maPhongBan);
			else
				cm.Parameters.AddWithValue("@MaPhongBan", DBNull.Value);
			if (_tenPhongBan.Length > 0)
				cm.Parameters.AddWithValue("@TenPhongBan", _tenPhongBan);
			else
				cm.Parameters.AddWithValue("@TenPhongBan", DBNull.Value);
			if (_maChucVu != 0)
				cm.Parameters.AddWithValue("@MaChucVu", _maChucVu);
			else
				cm.Parameters.AddWithValue("@MaChucVu", DBNull.Value);
			if (_tenChucVu.Length > 0)
				cm.Parameters.AddWithValue("@TenChucVu", _tenChucVu);
			else
				cm.Parameters.AddWithValue("@TenChucVu", DBNull.Value);
			if (_maKiemNhiem != 0)
				cm.Parameters.AddWithValue("@MaKiemNhiem", _maKiemNhiem);
			else
				cm.Parameters.AddWithValue("@MaKiemNhiem", DBNull.Value);
			if (_tenKiemNhiem.Length > 0)
				cm.Parameters.AddWithValue("@TenKiemNhiem", _tenKiemNhiem);
			else
				cm.Parameters.AddWithValue("@TenKiemNhiem", DBNull.Value);
			cm.Parameters.AddWithValue("@NgayVaoLam", _ngayVaoLam.DBValue);
			if (_phanTramLCB != 0)
				cm.Parameters.AddWithValue("@PhanTramLCB", _phanTramLCB);
			else
				cm.Parameters.AddWithValue("@PhanTramLCB", DBNull.Value);
			if (_phanTramLKD != 0)
				cm.Parameters.AddWithValue("@PhanTramLKD", _phanTramLKD);
			else
				cm.Parameters.AddWithValue("@PhanTramLKD", DBNull.Value);
			if (_luongCB != 0)
				cm.Parameters.AddWithValue("@LuongCB", _luongCB);
			else
				cm.Parameters.AddWithValue("@LuongCB", DBNull.Value);
			if (_heSoLuongCB != 0)
				cm.Parameters.AddWithValue("@HeSoLuongCB", _heSoLuongCB);
			else
				cm.Parameters.AddWithValue("@HeSoLuongCB", DBNull.Value);
            _soTienHSCB = _luongCB * _heSoLuongCB;
			cm.Parameters.AddWithValue("@SoTienHSCB", _soTienHSCB);
			
			if (_luongKD != 0)
				cm.Parameters.AddWithValue("@LuongKD", _luongKD);
			else
				cm.Parameters.AddWithValue("@LuongKD", DBNull.Value);
			if (_heSoLuongKD != 0)
				cm.Parameters.AddWithValue("@HeSoLuongKD", _heSoLuongKD);
			else
				cm.Parameters.AddWithValue("@HeSoLuongKD", DBNull.Value);
            _soTienHSKD = _luongKD * _heSoLuongKD;
			cm.Parameters.AddWithValue("@SoTienHSKD", _soTienHSKD);
			
			if (_phanTramBHXH != 0)
				cm.Parameters.AddWithValue("@PhanTramBHXH", _phanTramBHXH);
			else
				cm.Parameters.AddWithValue("@PhanTramBHXH", DBNull.Value);
			if (_tienBHXH != 0)
				cm.Parameters.AddWithValue("@TienBHXH", _tienBHXH);
			else
				cm.Parameters.AddWithValue("@TienBHXH", DBNull.Value);
			if (_phanTramBHYT != 0)
				cm.Parameters.AddWithValue("@PhanTramBHYT", _phanTramBHYT);
			else
				cm.Parameters.AddWithValue("@PhanTramBHYT", DBNull.Value);
			if (_tienBHYT != 0)
				cm.Parameters.AddWithValue("@TienBHYT", _tienBHYT);
			else
				cm.Parameters.AddWithValue("@TienBHYT", DBNull.Value);
			if (_phanTramCongDoan != 0)
				cm.Parameters.AddWithValue("@PhanTramCongDoan", _phanTramCongDoan);
			else
				cm.Parameters.AddWithValue("@PhanTramCongDoan", DBNull.Value);
			if (_soTienCongDoan != 0)
				cm.Parameters.AddWithValue("@SoTienCongDoan", _soTienCongDoan);
			else
				cm.Parameters.AddWithValue("@SoTienCongDoan", DBNull.Value);
			if (_phidoanDang != 0)
				cm.Parameters.AddWithValue("@PhiDoan_Dang", _phidoanDang);
			else
				cm.Parameters.AddWithValue("@PhiDoan_Dang", DBNull.Value);
			if (_phanTramDanhGiaCB != 0)
				cm.Parameters.AddWithValue("@PhanTramDanhGiaCB", _phanTramDanhGiaCB);
			else
				cm.Parameters.AddWithValue("@PhanTramDanhGiaCB", DBNull.Value);
			if (_phanTramDanhGiaKD != 0)
				cm.Parameters.AddWithValue("@PhanTramDanhGiaKD", _phanTramDanhGiaKD);
			else
				cm.Parameters.AddWithValue("@PhanTramDanhGiaKD", DBNull.Value);
			if (_tienNopThue != 0)
				cm.Parameters.AddWithValue("@TienNopThue", _tienNopThue);
			else
				cm.Parameters.AddWithValue("@TienNopThue", DBNull.Value);
			if (_soNgayCong != 0)
				cm.Parameters.AddWithValue("@SoNgayCong", _soNgayCong);
			else
				cm.Parameters.AddWithValue("@SoNgayCong", DBNull.Value);
			if (_soNgayLamViec != 0)
				cm.Parameters.AddWithValue("@SoNgayLamViec", _soNgayLamViec);
			else
				cm.Parameters.AddWithValue("@SoNgayLamViec", DBNull.Value);
			if (_soGioTangCa30 != 0)
				cm.Parameters.AddWithValue("@SoGioTangCa30", _soGioTangCa30);
			else
				cm.Parameters.AddWithValue("@SoGioTangCa30", DBNull.Value);
			if (_soTienTangCa30 != 0)
				cm.Parameters.AddWithValue("@SoTienTangCa30", _soTienTangCa30);
			else
				cm.Parameters.AddWithValue("@SoTienTangCa30", DBNull.Value);
			if (_soGioTangCa45 != 0)
				cm.Parameters.AddWithValue("@SoGioTangCa45", _soGioTangCa45);
			else
				cm.Parameters.AddWithValue("@SoGioTangCa45", DBNull.Value);
			if (_soTienTangCa45 != 0)
				cm.Parameters.AddWithValue("@SoTienTangCa45", _soTienTangCa45);
			else
				cm.Parameters.AddWithValue("@SoTienTangCa45", DBNull.Value);
			if (_soGioTangCa60 != 0)
				cm.Parameters.AddWithValue("@SoGioTangCa60", _soGioTangCa60);
			else
				cm.Parameters.AddWithValue("@SoGioTangCa60", DBNull.Value);
			if (_soTienTangCa60 != 0)
				cm.Parameters.AddWithValue("@SoTienTangCa60", _soTienTangCa60);
			else
				cm.Parameters.AddWithValue("@SoTienTangCa60", DBNull.Value);
			if (_tienThucLanh != 0)
				cm.Parameters.AddWithValue("@TienThucLanh", _tienThucLanh);
			else
				cm.Parameters.AddWithValue("@TienThucLanh", DBNull.Value);
			if (_tienThucLanhTron != 0)
				cm.Parameters.AddWithValue("@TienThucLanhTron", _tienThucLanhTron);
			else
				cm.Parameters.AddWithValue("@TienThucLanhTron", DBNull.Value);
			if (_congDoan != false)
				cm.Parameters.AddWithValue("@CongDoan", _congDoan);
			else
				cm.Parameters.AddWithValue("@CongDoan", DBNull.Value);
			if (_doan != false)
				cm.Parameters.AddWithValue("@Doan", _doan);
			else
				cm.Parameters.AddWithValue("@Doan", DBNull.Value);
			if (_dang != false)
				cm.Parameters.AddWithValue("@Dang", _dang);
			else
				cm.Parameters.AddWithValue("@Dang", DBNull.Value);
		}

		private void UpdateChildren(SqlTransaction tr)
		{
			//_nghiViecList.Update(tr, this);
			//_phuCapThuongXuyenList.Update(tr, this);
			//_toNhanVienList.Update(tr, this);
			//_bangCongList.Update(tr, this);
			//_lichLamViecTheoNVList.Update(tr, this);
			//_quaTrinhDGCBHangThangList.Update(tr, this);
		}
		#endregion //Data Access - Update

		#region Data Access - Delete
		internal void DeleteSelf(SqlTransaction tr)
		{
			if (!IsDirty) return;
			if (IsNew) return;
            //_nghiViecList.Clear();
            //_toNhanVienList.Clear();
            _bangCongList.Clear();
            //_lichLamViecTheoNVList.Clear();
            //_quaTrinhDGCBHangThangList.Clear();
            UpdateChildren(tr);

			ExecuteDelete(tr, new Criteria(_maNhanVien));
			MarkNew();
		}
		#endregion //Data Access - Delete
		#endregion //Data Access
	}
}
