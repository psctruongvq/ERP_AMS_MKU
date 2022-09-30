
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{ 
    //Thành
	[Serializable()] 
	public class HopDongMuaBan : Csla.BusinessBase<HopDongMuaBan>
	{
       
        public override string ToString()
        {
            return _tenHopDong;
        }

		#region Business Properties and Methods

		//declare members
		private long _maHopDong = 0;
		private string _soHopDong = string.Empty;
 		private int _maBangBaoGia = 0;
		private decimal _tongTien = 0;
        private int  _maLoaiHopDong= 0;
        private int _maLoaiTien = 1;
        private string _maHopDongQL = string.Empty;
        private string _tenHopDong = string.Empty;
        private long _maDoiTac = 0;
        private SmartDate _ngayLap = new SmartDate(DateTime.Today);
        private SmartDate _tuNgay = new SmartDate(DateTime.Today);
        private SmartDate _ngayHetHan = new SmartDate(DateTime.Today);
        private Int32 _maNguoiLap = ERP_Library.Security.CurrentUser.Info.UserID;
        private byte _tinhTrang = 0;        
        private byte[] _flieDinhKem = new byte[0];
        private long _nguoiLienLac = 0;
        private long _maNguoiKy = 0;
        private SmartDate _ngayKy = new SmartDate(DateTime.Today);
        private string _ghiChu = string.Empty;
        private decimal _soTienDatCoc = 0;
        private decimal _phiGiaoDich = 0;
        private double _laiSuat = 0;
        private byte _daThanhToan = 0;
        private double  _phanTramKyQuy = 0;
        private string _vietBangChu = string.Empty;
        private string _tenDoiTac = string.Empty;
        private string _maQLDoiTac = string.Empty;
        private string _cmnd = string.Empty;
        private string _tinhTrangString = string.Empty;
        private bool _muaBan = false;
        private bool _hdTrongNgoaiDai = false;
        private double _thueSuat = 0;
        private decimal _thueVAT = 0;
        private bool _check = false;//M
        private string _tenNguoiLienLac = string.Empty;
        private string _tenNguoiKy = string.Empty;
        private DateTime _ngayApDungLai = DateTime.Today.Date;
        private int _soNgay = 1;
        private bool _loaiNgay = false;//tính số ngày tù ngày, đến ngày bình thường 
        private string _soThamDinh = string.Empty;
        private SmartDate _ngayThamDinh = new SmartDate(DateTime.Today);
        private int _maBoPhanChuQuan = 0;
        private string _donViChuQuan = string.Empty;
        
		//declare child member(s)
        
		private DotGiaoHangHDMBList _dotGiaoHangHDMBList = DotGiaoHangHDMBList.NewDotGiaoHangHDMBList();
		private DotThanhToanHDMBList _dotThanhToanHDMBList = DotThanhToanHDMBList.NewDotThanhToanHDMBList();
		private CT_HopDongMuaBanList _cT_HopDongMuaBanList = CT_HopDongMuaBanList.NewCT_HopDongMuaBanList();
        private CT_HopDongMuaBanNgoaiTeList _cT_HopDongMuaBanNgoaiTeList = CT_HopDongMuaBanNgoaiTeList.NewCT_HopDongMuaBanNgoaiTeList();
        private CT_MuaBanTSCDList _cT_MuaBanTSCDList = CT_MuaBanTSCDList.NewCT_MuaBanTSCDList();
        private CT_HopDongDichVuList _CT_HopDongDichVuList = CT_HopDongDichVuList.NewCT_HopDongDichVuList();
        private ChiTietThanhToanList _chiTietThanhToanList = ChiTietThanhToanList.NewChiTietThanhToanList();

		[System.ComponentModel.DataObjectField(true, true)]
		public long MaHopDong
		{
			get
			{
				CanReadProperty("MaHopDong", true);
				return _maHopDong;
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

        public string TenDoiTac 
        {
            get
            {
                CanReadProperty("TenDoiTac", true);
                return _tenDoiTac;
            }
           
        }
        
        public string MaQLDoiTac
        {
            get
            {
                CanReadProperty("MaQLDoiTac", true);
                return _maQLDoiTac;
            }
           
        }
        
        public string CMND
        {
            get
            {
                CanReadProperty("CMND", true);
                return _cmnd;
            }
           
        }

		public int MaBangBaoGia
		{
			get
			{
				CanReadProperty("MaBangBaoGia", true);
				return _maBangBaoGia;
			}
			set
			{
				CanWriteProperty("MaBangBaoGia", true);
				if (!_maBangBaoGia.Equals(value))
				{
					_maBangBaoGia = value;
					PropertyHasChanged("MaBangBaoGia");
				}
			}
		}

		public decimal TongTien
		{
			get
			{
				CanReadProperty("TongTien", true);
				return _tongTien;
			}
			set
			{
				CanWriteProperty("TongTien", true);
				if (!_tongTien.Equals(value))
				{
					_tongTien = value;
                    _thueVAT = _tongTien * (decimal)_thueSuat / 100;
                    _soTienDatCoc = _tongTien * (decimal)_phanTramKyQuy / 100;
                    _vietBangChu = HamDungChung.DocTien(_tongTien);
					PropertyHasChanged("TongTien");
				}
			}
		}

        public int MaLoaiHopDong
        {
            get
            {
                CanReadProperty("MaLoaiHopDong", true);
                return _maLoaiHopDong;
            }
            set
            {
                CanWriteProperty("MaLoaiHopDong", true);
                if (!_maLoaiHopDong.Equals(value))
                {
                    _maLoaiHopDong = value;
                    PropertyHasChanged("MaLoaiHopDong");
                }
            }
        }

        public int MaLoaiTien
        {
            get
            {
                CanReadProperty("MaLoaiTien", true);
                return _maLoaiTien;
            }
            set
            {
                CanWriteProperty("MaLoaiTien", true);
                if (!_maLoaiTien.Equals(value))
                {
                    _maLoaiTien = value;
                    PropertyHasChanged("MaLoaiTien");
                }
            }
        }

        public string MaHopDongQL
        {
            get
            {
                CanReadProperty("MaHopDongQL", true);
                return _maHopDongQL;
            }
            set
            {
                CanWriteProperty("MaHopDongQL", true);
                if (value == null) value = string.Empty;
                if (!_maHopDongQL.Equals(value))
                {
                    _maHopDongQL = value;
                    PropertyHasChanged("MaHopDongQL");
                }
            }
        }

        public string TenHopDong
        {
            get
            {
                CanReadProperty("TenHopDong", true);
                return _tenHopDong;
            }
            set
            {
                CanWriteProperty("TenHopDong", true);
                if (value == null) value = string.Empty;
                if (!_tenHopDong.Equals(value))
                {
                    _tenHopDong = value;
                    PropertyHasChanged("TenHopDong");
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

        public DateTime NgayLap
        {
            get
            {
                CanReadProperty(true);
                return _ngayLap.Date;
            }
            set
            {
                CanWriteProperty(true);
                if (!_ngayLap.Equals(value))
                {
                    _ngayLap = new SmartDate(value);
                    PropertyHasChanged();
                }
            }
        }

        public DateTime TuNgay
        {
            get
            {
                CanReadProperty(true);
                return _tuNgay.Date;
            }
            set
            {
                CanWriteProperty(true);
                if (!_tuNgay.Equals(value))
                {
                    _tuNgay = new SmartDate(value);
                    PropertyHasChanged();
                }
            }
        }

        public DateTime NgayHetHan
        {
            get
            {
                CanReadProperty(true);
                return _ngayHetHan.Date;
            }
            set
            {
                CanWriteProperty(true);
                if (!_ngayHetHan.Equals(value))
                {
                    _ngayHetHan = new SmartDate(value);
                    PropertyHasChanged();
                }
            }
        }

        public Int32 MaNguoiLap
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
       
        public byte[] FileDinhKem
        {
            get
            {
                CanReadProperty("FileDinhKem", true);
                return _flieDinhKem;
            }
            set
            {
                CanWriteProperty("FileDinhKem", true);
                if (!_flieDinhKem.Equals(value))
                {
                    _flieDinhKem = value;
                    PropertyHasChanged("FileDinhKem");
                }
            }
        }

        public long NguoiLienLac
        {
            get
            {
                CanReadProperty("TenHopDong", true);
                return _nguoiLienLac;
            }
            set
            {
                CanWriteProperty("TenHopDong", true);
                if (value == null) value = 0;
                if (!_nguoiLienLac.Equals(value))
                {
                    _nguoiLienLac = value;
                    PropertyHasChanged("TenHopDong");
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
                    _tenNguoiKy = TenNV.GetTenNhanVien(_maNguoiKy).TenNhanVien;
                    PropertyHasChanged("MaNguoiKy");
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
                    PropertyHasChanged();
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

        public double PhanTramKyQuy
        {
            get
            {
                CanReadProperty("PhanTramKyQuy", true);
                return _phanTramKyQuy;
            }
            set
            {
                CanWriteProperty("PhanTramKyQuy", true);
                if (!_phanTramKyQuy.Equals(value))
                {
                    _phanTramKyQuy = value;
                    _soTienDatCoc = _tongTien * (decimal)_phanTramKyQuy / 100;
                    PropertyHasChanged("PhanTramKyQuy");
                }
            }
        }

        public decimal SoTienDatCoc
        {
            get
            {
                CanReadProperty("SoTienDatCoc", true);
                return _soTienDatCoc;
            }
            set
            {
                CanWriteProperty("SoTienDatCoc", true);
                if (!_soTienDatCoc.Equals(value))
                {
                    _soTienDatCoc = value;
                    PropertyHasChanged("SoTienDatCoc");
                }
            }
        }

        public decimal PhiGiaoDich
        {
            get
            {
                CanReadProperty("PhiGiaoDich", true);
                return _phiGiaoDich;
            }
            set
            {
                CanWriteProperty("PhiGiaoDich", true);
                if (!_phiGiaoDich.Equals(value))
                {
                    _phiGiaoDich = value;
                    PropertyHasChanged("PhiGiaoDich");
                }
            }
        }

        public double LaiSuat
        {
            get
            {
                CanReadProperty("LaiSuat", true);
                return _laiSuat;
            }
            set
            {
                CanWriteProperty("LaiSuat", true);
                if (!_laiSuat.Equals(value))
                {
                    _laiSuat = value;
                    PropertyHasChanged("LaiSuat");
                }
            }
        }

        public string VietBangChu
        {
            get
            {
                CanReadProperty("VietBangChu", true);
                return _vietBangChu;
            }
            set
            {
                CanWriteProperty("VietBangChu", true);
                if (value == null) value = string.Empty;
                if (!_vietBangChu.Equals(value))
                {
                    _vietBangChu = value;
                    PropertyHasChanged("VietBangChu");
                }
            }
        }

        public byte DaThanhToan
        {
            get
            {
                CanReadProperty("DaThanhToan", true);
                return _daThanhToan;
            }
            set
            {
                CanWriteProperty("DaThanhToan", true);
                if (!_daThanhToan.Equals(value))
                {
                    _daThanhToan = value;
                    PropertyHasChanged("DaThanhToan");
                }
            }
        }
        
        public bool MuaBan
        {
            get
            {
                CanReadProperty("MuaBan", true);
                return _muaBan;
            }
            set
            {
                CanWriteProperty("MuaBan", true);
                if (!_muaBan.Equals(value))
                {
                    _muaBan = value;
                    PropertyHasChanged("MuaBan");
                }
            }
        }

        public bool HDTrongNgoaiDai
        {
            get
            {
                CanReadProperty("HDTrongNgoaiDai", true);
                return _hdTrongNgoaiDai;
            }
            set
            {
                CanWriteProperty("HDTrongNgoaiDai", true);
                if (!_hdTrongNgoaiDai.Equals(value))
                {
                    _hdTrongNgoaiDai = value;
                    PropertyHasChanged("HDTrongNgoaiDai");
                }
            }
        }

        public string TinhTrangString
        {
            get
            {
                CanReadProperty("TinhTrangString", true);
                if (_tinhTrang == 0)
                    _tinhTrangString = "Chưa thực hiện";
                else if (_tinhTrang == 1)
                    _tinhTrangString = "Đang thực hiện";
                else if (_tinhTrang == 2)
                    _tinhTrangString = "Đã giao xong hàng";
                else if (_tinhTrang == 3)
                    _tinhTrangString = "Đã hoàn tất";
                else _tinhTrangString = "Đã bị hủy";
                return _tinhTrangString;
            }
            
        }

        public double ThueSuat 
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
                    _thueVAT = _tongTien * (decimal)_thueSuat / 100;
                    PropertyHasChanged("ThueSuat");
                }
            }
        }

        public decimal ThueVAT
        {
            get
            {
                CanReadProperty("ThueVAT", true);                
                return _thueVAT;
            }
            set 
            {
                CanWriteProperty("ThueVAT", true);
                if (!_thueVAT.Equals(value))
                {
                    _thueVAT = value;
                    PropertyHasChanged("ThueVAT");
                }
            }

        }
        public bool Check//M
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
        }//END M

		public DotGiaoHangHDMBList DotGiaoHangHDMBList
		{
			get
			{
				CanReadProperty("DotGiaoHangHDMB", true);
				return _dotGiaoHangHDMBList;
			}
            set
            {

                CanWriteProperty("DotGiaoHangHDMB", true);
                if (value == null) _dotGiaoHangHDMBList = DotGiaoHangHDMBList.NewDotGiaoHangHDMBList();
                if (!_dotGiaoHangHDMBList.Equals(value))
                {
                    _dotGiaoHangHDMBList = value;
                    PropertyHasChanged("DotGiaoHangHDMB");
                }
            
            }
		}

        public CT_HopDongDichVuList CT_HopDongDichVu
        {
            get
            {
                CanReadProperty("CT_HopDongDichVu", true);
                return _CT_HopDongDichVuList;
            }
            set
            {

                CanWriteProperty("CT_HopDongDichVu", true);
                if (!CT_HopDongDichVu.Equals(value))
                {
                    CT_HopDongDichVu = value;
                    PropertyHasChanged("CT_HopDongDichVu");
                }

            }
        }

        public string TenNguoiKy
        {
            get
            {
                CanReadProperty("TenNguoiKy", true);
                return _tenNguoiKy;
            }
            set
            {
                CanWriteProperty("TenNguoiKy", true);
                if (value == null) value = string.Empty;
                if (!_tenNguoiKy.Equals(value))
                {
                    _tenNguoiKy = value;
                    PropertyHasChanged("TenNguoiKy");
                }
            }
        }

        public string TenNguoiLienLac
        {
            get
            {
                CanReadProperty("TenNguoiLienLac", true);
                return _tenNguoiLienLac;
            }
            set
            {
                CanWriteProperty("TenNguoiLienLac", true);
                if (value == null) value = string.Empty;
                if (!_tenNguoiLienLac.Equals(value))
                {
                    _tenNguoiLienLac = value;
                    PropertyHasChanged("TenNguoiLienLac");
                }
            }
        }

        public DateTime NgayApDungLai
        {
            get
            {
                CanReadProperty("NgayApDungLai", true);
                return _ngayApDungLai;
            }
            set
            {
                CanWriteProperty("NgayApDungLai", true);
                if (!_ngayApDungLai.Equals(value))
                {
                    _ngayApDungLai = value;
                    PropertyHasChanged("NgayApDungLai");
                }
            }
        }

        public int SoNgay
        {
            get
            {
                CanReadProperty("SoNgay", true);
                return _soNgay;
            }
            set
            {
                CanWriteProperty("SoNgay", true);
                if (!_soNgay.Equals(value))
                {
                    _soNgay = value;
                    PropertyHasChanged("SoNgay");
                }
            }
        }

        public bool LoaiNgay
        {
            get
            {
                CanReadProperty("LoaiNgay", true);
                return _loaiNgay;
                
            }
            set
            {
                CanWriteProperty("LoaiNgay", true);
                if (!_loaiNgay.Equals(value))
                {
                    _loaiNgay = value;
                    PropertyHasChanged("LoaiNgay");
                }
            }
        }

        public string SoThamDinh
        {
            get
            {
                CanReadProperty("SoThamDinh", true);
                return _soThamDinh;
            }
            set
            {
                CanWriteProperty("SoThamDinh", true);
                if (value == null) value = string.Empty;
                if (!_soThamDinh.Equals(value))
                {
                    _soThamDinh = value;
                    PropertyHasChanged("SoThamDinh");
                }
            }
        }

        public DateTime NgayThamDinh
        {
            get
            {
                CanReadProperty("NgayThamDinh", true);
                return _ngayThamDinh.Date;
            }
            set
            {
                CanWriteProperty(true);
                if (!_ngayThamDinh.Equals(value))
                {
                    _ngayThamDinh = new SmartDate(value);
                    PropertyHasChanged();
                }
            }
        }

        public int MaBoPhanChuQuan
        {
            get
            {
                CanReadProperty("MaBoPhanChuQuan", true);
                return _maBoPhanChuQuan;
            }
            set
            {
                CanWriteProperty("MaBoPhanChuQuan", true);
                if (!_maBoPhanChuQuan.Equals(value))
                {
                    _maBoPhanChuQuan = value;
                    _donViChuQuan = BoPhan.GetBoPhan(_maBoPhanChuQuan).TenBoPhan;
                    PropertyHasChanged("MaBoPhanChuQuan");
                }
            }
        }

        public string DonViChuQuan
        {
            get
            {
                CanReadProperty("DonViChuQuan", true);
                return _donViChuQuan;
            }
            set
            {
                CanWriteProperty("DonViChuQuan", true);
                if (value == null) value = string.Empty;
                if (!_donViChuQuan.Equals(value))
                {
                    _donViChuQuan = value;
                    PropertyHasChanged("DonViChuQuan");
                }
            }
        }

		public DotThanhToanHDMBList DotThanhToanHDMBList
		{
			get
			{
				CanReadProperty("DotThanhToanHDMB", true);
				return _dotThanhToanHDMBList;
			}
		}

		public CT_HopDongMuaBanList CT_HopDongMuaBanList
		{
			get
			{
				CanReadProperty("CT_HopDongMuaBan", true);
				return _cT_HopDongMuaBanList;
			}
		}

        public CT_HopDongMuaBanNgoaiTeList CT_HopDongMuaBanNgoaiTeList
        {
            get
            {
                CanReadProperty("CT_HopDongMuaBanNgoaiTeList", true);
                return _cT_HopDongMuaBanNgoaiTeList;
            }
        }

        public CT_MuaBanTSCDList CT_MuaBanTSCDList
        {
            get
            {
                CanReadProperty("CT_MuaBanTSCDList", true);
                return _cT_MuaBanTSCDList;
            }
        }

        public ChiTietThanhToanList chiTietThanhToan
        {
            get
            {
                CanReadProperty("chiTietThanhToan", true);
                return _chiTietThanhToanList;
            }
        }
        
		public override bool IsValid
		{
            get { return base.IsValid && _dotGiaoHangHDMBList.IsValid && _dotThanhToanHDMBList.IsValid && _cT_HopDongMuaBanList.IsValid && _cT_HopDongMuaBanNgoaiTeList.IsValid && _cT_MuaBanTSCDList.IsValid && _CT_HopDongDichVuList.IsValid; }
		}

		public override bool IsDirty
		{
            get { return base.IsDirty || _dotGiaoHangHDMBList.IsDirty || _dotThanhToanHDMBList.IsDirty || _cT_HopDongMuaBanList.IsDirty || _cT_HopDongMuaBanNgoaiTeList.IsDirty || _cT_MuaBanTSCDList.IsDirty || _CT_HopDongDichVuList.IsValid; }
		}

		protected override object GetIdValue()
		{
			return _maHopDong;
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
			//ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("SoHopDong", 20));
           // ValidationRules.AddRule(CommonRules.StringRequired, "MaHopDongQL");
           // ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("MaHopDongQL", 20));
            //
            // TenHopDong
            //
           // ValidationRules.AddRule(CommonRules.StringRequired, "TenHopDong");
           // ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("TenHopDong", 500));
            //
            // NgayLap
            //
            
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
			//TODO: Define authorization rules in HopDongMuaBan
			//AuthorizationRules.AllowRead("DotGiaoHangHDMB", "HopDongMuaBanReadGroup");
			//AuthorizationRules.AllowRead("DotThanhToanHDMB", "HopDongMuaBanReadGroup");
			//AuthorizationRules.AllowRead("CT_HopDongMuaBan", "HopDongMuaBanReadGroup");
			//AuthorizationRules.AllowRead("MaHopDong", "HopDongMuaBanReadGroup");
			//AuthorizationRules.AllowRead("SoHopDong", "HopDongMuaBanReadGroup");
			//AuthorizationRules.AllowRead("MaBangBaoGia", "HopDongMuaBanReadGroup");
			//AuthorizationRules.AllowRead("TongTien", "HopDongMuaBanReadGroup");
			//AuthorizationRules.AllowRead("Loai", "HopDongMuaBanReadGroup");

			//AuthorizationRules.AllowWrite("SoHopDong", "HopDongMuaBanWriteGroup");
			//AuthorizationRules.AllowWrite("MaBangBaoGia", "HopDongMuaBanWriteGroup");
			//AuthorizationRules.AllowWrite("TongTien", "HopDongMuaBanWriteGroup");
			//AuthorizationRules.AllowWrite("Loai", "HopDongMuaBanWriteGroup");
		}


		public static bool CanGetObject()
		{
			//TODO: Define CanGetObject permission in HopDongMuaBan
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("HopDongMuaBanViewGroup"))
			//	return true;
			//return false;
		}

		public static bool CanAddObject()
		{
			//TODO: Define CanAddObject permission in HopDongMuaBan
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("HopDongMuaBanAddGroup"))
			//	return true;
			//return false;
		}

		public static bool CanEditObject()
		{
			//TODO: Define CanEditObject permission in HopDongMuaBan
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("HopDongMuaBanEditGroup"))
			//	return true;
			//return false;
		}

		public static bool CanDeleteObject()
		{
			//TODO: Define CanDeleteObject permission in HopDongMuaBan
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("HopDongMuaBanDeleteGroup"))
			//	return true;
			//return false;
		}
		#endregion //Authorization Rules

		#region Factory Methods
		private HopDongMuaBan()
		{ 
            /* require use of factory method */
            MarkAsChild();
        }

        private HopDongMuaBan(long MaHopDong, string tenHopDong)
        {
            _maHopDong = MaHopDong;
            _soHopDong = tenHopDong;
            _tenHopDong = tenHopDong;
        }

        public static HopDongMuaBan NewHopDongMuaBan(long MaHopDong, string tenHopDong)
        {
            return new HopDongMuaBan(MaHopDong, tenHopDong);
        }

		public static HopDongMuaBan NewHopDongMuaBan()
		{
			if (!CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a HopDongMuaBan");
			return DataPortal.Create<HopDongMuaBan>();
		}

		public static HopDongMuaBan GetHopDongMuaBan(long maHopDong)
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException("User not authorized to view a HopDongMuaBan");
			return DataPortal.Fetch<HopDongMuaBan>(new Criteria(maHopDong));
		}

		public static void DeleteHopDongMuaBan(long maHopDong)
		{
			if (!CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a HopDongMuaBan");
			DataPortal.Delete(new Criteria(maHopDong));
		}


		public override HopDongMuaBan Save()
		{
			if (IsDeleted && !CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a HopDongMuaBan");
			else if (IsNew && !CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a HopDongMuaBan");
			else if (!CanEditObject())
				throw new System.Security.SecurityException("User not authorized to update a HopDongMuaBan");

			return base.Save();
		}


        public static bool KiemTraSoHopDongTonTai(string soHopDong,  int loai, bool muaBan )
        {
            if (KiemTraSoHopDong(soHopDong, loai, muaBan ) == 0)
                return true;
            return false;
        }

        public static bool KiemTraHopDongDaPhatSinhPhuLucHayNghiemThu(long maHopDong)
        {
            bool _kq = false;
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "Spd_KiemTraHopDongDaPhatSinhPhuLucHayNghiemThu";
                    cm.Parameters.AddWithValue("@MaHopDong", maHopDong);
                    SqlParameter prmGiaTriTraVe = new SqlParameter("@GiaTriTraVe", SqlDbType.Bit, 16);
                    prmGiaTriTraVe.Direction = ParameterDirection.Output;
                    cm.Parameters.Add(prmGiaTriTraVe);
                    cm.ExecuteNonQuery();
                    _kq = (bool)prmGiaTriTraVe.Value;
                }
            }//us
            return _kq;
        }
              
		#endregion //Factory Methods

		#region Child Factory Methods
		internal static HopDongMuaBan NewHopDongMuaBanChild()
		{
			HopDongMuaBan child = new HopDongMuaBan();
			child.ValidationRules.CheckRules();
			child.MarkAsChild();
			return child;
		}

		internal static HopDongMuaBan GetHopDongMuaBan(SafeDataReader dr)
		{
			HopDongMuaBan child =  new HopDongMuaBan();
			child.MarkAsChild();
			child.Fetch(dr);
			return child;
		}

        internal static HopDongMuaBan GetHopDongMuaBanWitoutChild(SafeDataReader dr)
        {
            HopDongMuaBan child = new HopDongMuaBan();
            child.MarkAsChild();
            child.FetchWithoutChild(dr);
            return child;
        }
		#endregion //Child Factory Methods

		#region Data Access

		#region Criteria

		[Serializable()]
		private class Criteria
		{
			public long MaHopDong;

			public Criteria(long maHopDong)
			{
				this.MaHopDong = maHopDong;
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
                cm.CommandText = "spd_SelecttblHopDongMuaBan";

				cm.Parameters.AddWithValue("@MaHopDong", criteria.MaHopDong);

				using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
				{
                    while (dr.Read())
                    {
                        FetchObject(dr);
                        //ValidationRules.CheckRules();

                        //load child object(s)
                        FetchChildren(_maHopDong);
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
                catch (SqlException ex)
                {
                    tr.Rollback();
                    HamDungChung.ThongBaoLoi(ex);
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
                catch (SqlException ex)
                {
                    tr.Rollback();
                    HamDungChung.ThongBaoLoi(ex);
                }
			}//using

		}

		#endregion //Data Access - Update

		#region Data Access - Delete
		protected override void DataPortal_DeleteSelf()
		{
			DataPortal_Delete(new Criteria(_maHopDong));
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
                    _dotGiaoHangHDMBList.Clear();
                    _dotThanhToanHDMBList.Clear();
                    _cT_HopDongMuaBanList.Clear();
                    _cT_HopDongMuaBanNgoaiTeList.Clear();
                    UpdateChildren(tr);
					ExecuteDelete(tr, criteria);                    
					tr.Commit();
				}
                catch (SqlException ex)
                {
                    tr.Rollback();
                    HamDungChung.ThongBaoLoi(ex);
                }
			}//using

		}

		private void ExecuteDelete(SqlTransaction tr, Criteria criteria)
		{
			using (SqlCommand cm = tr.Connection.CreateCommand())
			{
				cm.Transaction = tr;
				cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_DeletetblHopDongMuaBan";

				cm.Parameters.AddWithValue("@MaHopDong", criteria.MaHopDong);

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
			FetchChildren(MaHopDong);
		}

        private void FetchWithoutChild(SafeDataReader dr)
        {
            FetchObject(dr);
            MarkOld();
            ValidationRules.CheckRules();
        }

		private void FetchObject(SafeDataReader dr)
		{			
            _maHopDong = dr.GetInt64("MaHopDong");
			_soHopDong = dr.GetString("SoHopDong");
			_maBangBaoGia = dr.GetInt32("MaBangBaoGia");
			_tongTien = dr.GetDecimal("TongTien");
            _maLoaiHopDong = dr.GetInt32("MaLoaiHopDong");
            _maLoaiTien = dr.GetInt32("MaLoaiTien");       
            _maHopDongQL = dr.GetString("MaHopDongQL");
            _tenHopDong = dr.GetString("TenHopDong");
            _maDoiTac = dr.GetInt64("MaDoiTac");
            _ngayLap = dr.GetSmartDate("NgayLap", _ngayLap.EmptyIsMin);
            _tuNgay = dr.GetSmartDate("TuNgay", _tuNgay.EmptyIsMin);
            _ngayHetHan = dr.GetSmartDate("NgayHetHan", _ngayHetHan.EmptyIsMin);
            _maNguoiLap = dr.GetInt32("MaNguoiLap");
            _tinhTrang = dr.GetByte("TinhTrang");            
            //_flieDinhKem = (byte[])dr["FileDinhKem"];
            _nguoiLienLac = dr.GetInt64("NguoiLienLac");
            _maNguoiKy = dr.GetInt64("MaNguoiKy");
            _ngayKy = dr.GetSmartDate("NgayKy", _ngayKy.EmptyIsMin);
            _ghiChu = dr.GetString("GhiChu");
            _phanTramKyQuy = dr.GetDouble("PhanTramKyQuy");
            _soTienDatCoc = dr.GetDecimal("SoTienDatCoc");
            _phiGiaoDich = dr.GetDecimal("PhiGiaoDich");
            _laiSuat = dr.GetDouble("LaiSuat");
            _vietBangChu = dr.GetString("VietBangChu");
            _tenDoiTac = dr.GetString("TenDoiTac");
            _maQLDoiTac = dr.GetString("MaQLDoiTac");
            _cmnd = dr.GetString("CMND");
            _muaBan= dr.GetBoolean("MuaBan");
            _hdTrongNgoaiDai= dr.GetBoolean("HDTrongNgoaiDai");
            _thueSuat = dr.GetDouble("ThueSuat");
            _thueVAT = dr.GetDecimal("ThueVat");
            _tenNguoiKy = dr.GetString("TenNguoiKy");
            _tenNguoiLienLac = dr.GetString("TenNguoiLienLac");
            _ngayApDungLai = dr.GetDateTime("NgayApDungLai");
            _soNgay = dr.GetInt32("SoNgay");
            _loaiNgay = dr.GetBoolean("LoaiNgay");
            _soThamDinh = dr.GetString("SoThamDinh");
            _ngayThamDinh = dr.GetSmartDate("NgayThamDinh", _ngayThamDinh.EmptyIsMin);
            _maBoPhanChuQuan = dr.GetInt32("MaBoPhanChuQuan");
            _donViChuQuan = dr.GetString("DonViChuQuan");

		}

		private void FetchChildren(long maHopDong)
		{
            _CT_HopDongDichVuList = CT_HopDongDichVuList.GetCT_HopDongDichVuList(maHopDong);
            _chiTietThanhToanList = ChiTietThanhToanList.GetChiTietThanhToanList(maHopDong);
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
                cm.CommandText = "spd_InserttblHopDongMuaBan";

				AddInsertParameters(cm);

				cm.ExecuteNonQuery();

				_maHopDong = (long)cm.Parameters["@MaHopDong"].Value;
			}//using
		}

		private void AddInsertParameters(SqlCommand cm)
		{
			if (_soHopDong.Length > 0)
				cm.Parameters.AddWithValue("@SoHopDong", _soHopDong);
			else
				cm.Parameters.AddWithValue("@SoHopDong", DBNull.Value);
			if (_maBangBaoGia != 0)
				cm.Parameters.AddWithValue("@MaBangBaoGia", _maBangBaoGia);
			else
				cm.Parameters.AddWithValue("@MaBangBaoGia", DBNull.Value);
			if (_tongTien != 0)
				cm.Parameters.AddWithValue("@TongTien", _tongTien);
			else
				cm.Parameters.AddWithValue("@TongTien", DBNull.Value);
            if (_maLoaiHopDong != 0)
                cm.Parameters.AddWithValue("@MaLoaiHopDong", _maLoaiHopDong);
            else
                cm.Parameters.AddWithValue("@MaLoaiHopDong", DBNull.Value);            			
            if (_maLoaiTien != 0)
                cm.Parameters.AddWithValue("@MaLoaiTien", _maLoaiTien);
            else
                cm.Parameters.AddWithValue("@MaLoaiTien", DBNull.Value);
            cm.Parameters.AddWithValue("@MaHopDongQL", _maHopDongQL);
            cm.Parameters.AddWithValue("@TenHopDong", _tenHopDong);
            cm.Parameters.AddWithValue("@MaDoiTac", _maDoiTac);
            cm.Parameters.AddWithValue("@NgayLap", _ngayLap.DBValue);
            cm.Parameters.AddWithValue("@TuNgay", _tuNgay.DBValue);
            cm.Parameters.AddWithValue("@NgayHetHan", _ngayHetHan.DBValue);
            cm.Parameters.AddWithValue("@MaNguoiLap", _maNguoiLap);
            cm.Parameters.AddWithValue("@TinhTrang", _tinhTrang);
            if (_maNguoiKy != 0)
                cm.Parameters.AddWithValue("@MaNguoiKy", _maNguoiKy);
            else
                cm.Parameters.AddWithValue("@MaNguoiKy", DBNull.Value);
            cm.Parameters.AddWithValue("@NgayKy", _ngayKy.DBValue);
            cm.Parameters.AddWithValue("@FileDinhKem", _flieDinhKem);
            if(_nguoiLienLac !=0)
                cm.Parameters.AddWithValue("@NguoiLienLac", _nguoiLienLac);
            else
                cm.Parameters.AddWithValue("@NguoiLienLac", DBNull.Value);
            cm.Parameters.AddWithValue("@GhiChu", _ghiChu);
            cm.Parameters.AddWithValue("@PhanTramKyQuy", _phanTramKyQuy);        
            cm.Parameters.AddWithValue("@SoTienDatCoc", _soTienDatCoc);          
            if (_phiGiaoDich != 0)
                cm.Parameters.AddWithValue("@PhiGiaoDich", _phiGiaoDich);
            else
                cm.Parameters.AddWithValue("@PhiGiaoDich", DBNull.Value);            
            cm.Parameters.AddWithValue("@LaiSuat", _laiSuat);                     
            cm.Parameters.AddWithValue("@VietBangChu", _vietBangChu);
            cm.Parameters.AddWithValue("@DaThanhToan", _daThanhToan);
            cm.Parameters.AddWithValue("@MaHopDong", _maHopDong);			
			cm.Parameters["@MaHopDong"].Direction = ParameterDirection.Output;
            cm.Parameters.AddWithValue("@MuaBan", _muaBan);
            cm.Parameters.AddWithValue("@HDTrongNgoaiDai", _hdTrongNgoaiDai);
            if (_thueSuat != 0)
                cm.Parameters.AddWithValue("@ThueSuat", _thueSuat);
            else cm.Parameters.AddWithValue("@ThueSuat", DBNull.Value);
            if (_thueVAT != 0)
                cm.Parameters.AddWithValue("@ThueVAT", _thueVAT);
            else cm.Parameters.AddWithValue("@ThueVAT", DBNull.Value);
            if (_tenNguoiKy.Length > 0)
                cm.Parameters.AddWithValue("@TenNguoiKy", _tenNguoiKy);
            else
                cm.Parameters.AddWithValue("@TenNguoiKy", DBNull.Value);
            cm.Parameters.AddWithValue("@TenNguoiLienLac", _tenNguoiLienLac);
            cm.Parameters.AddWithValue("@NgayApDungLai", _ngayApDungLai);
            cm.Parameters.AddWithValue("@SoNgay", _soNgay);
            cm.Parameters.AddWithValue("@LoaiNgay", _loaiNgay);
            cm.Parameters.AddWithValue("@SoThamDinh", _soThamDinh);
            cm.Parameters.AddWithValue("@NgayThamDinh", _ngayThamDinh.DBValue);
            if (_maBoPhanChuQuan != 0)
                cm.Parameters.AddWithValue("@MaBoPhanChuQuan", _maBoPhanChuQuan);
            else cm.Parameters.AddWithValue("@MaBoPhanChuQuan", DBNull.Value);
            if (_donViChuQuan.Length > 0)
                cm.Parameters.AddWithValue("@DonViChuQuan", _donViChuQuan);
            else
                cm.Parameters.AddWithValue("@DonViChuQuan", DBNull.Value);

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
                cm.CommandText = "spd_UpdatetblHopDongMuaBan";

				AddUpdateParameters(cm);

				cm.ExecuteNonQuery();

			}//using
		}

		private void AddUpdateParameters(SqlCommand cm)
		{
			cm.Parameters.AddWithValue("@MaHopDong", _maHopDong);
			if (_soHopDong.Length > 0)
				cm.Parameters.AddWithValue("@SoHopDong", _soHopDong);
			else
				cm.Parameters.AddWithValue("@SoHopDong", DBNull.Value);
			if (_maBangBaoGia != 0)
				cm.Parameters.AddWithValue("@MaBangBaoGia", _maBangBaoGia);
			else
				cm.Parameters.AddWithValue("@MaBangBaoGia", DBNull.Value);
			if (_tongTien != 0)
				cm.Parameters.AddWithValue("@TongTien", _tongTien);
			else
				cm.Parameters.AddWithValue("@TongTien", DBNull.Value); 
            if (_maLoaiHopDong !=0 ) 
                cm.Parameters.AddWithValue("@MaLoaiHopDong", _maLoaiHopDong);            
            else
                cm.Parameters.AddWithValue("@MaLoaiHopDong", DBNull.Value);            
            if (_maLoaiTien != 0)
                cm.Parameters.AddWithValue("@MaLoaiTien", _maLoaiTien);
            else
                cm.Parameters.AddWithValue("@MaLoaiTien", DBNull.Value);
            cm.Parameters.AddWithValue("@MaHopDongQL", _maHopDongQL);
            cm.Parameters.AddWithValue("@TenHopDong", _tenHopDong);
            cm.Parameters.AddWithValue("@MaDoiTac", _maDoiTac);
            cm.Parameters.AddWithValue("@NgayLap", _ngayLap.DBValue);
            cm.Parameters.AddWithValue("@TuNgay", _tuNgay.DBValue);
            cm.Parameters.AddWithValue("@NgayHetHan", _ngayHetHan.DBValue);
            cm.Parameters.AddWithValue("@MaNguoiLap", _maNguoiLap);
            cm.Parameters.AddWithValue("@TinhTrang", _tinhTrang);
            if (_maNguoiKy != 0)
                cm.Parameters.AddWithValue("@MaNguoiKy", _maNguoiKy);
            else
                cm.Parameters.AddWithValue("@MaNguoiKy", DBNull.Value);
            cm.Parameters.AddWithValue("@NgayKy", _ngayKy.DBValue);
            cm.Parameters.AddWithValue("@FileDinhKem", _flieDinhKem);
            cm.Parameters.AddWithValue("@NguoiLienLac", _nguoiLienLac);
            cm.Parameters.AddWithValue("@GhiChu", _ghiChu);
            cm.Parameters.AddWithValue("@PhanTramKyQuy", _phanTramKyQuy);
            cm.Parameters.AddWithValue("@SoTienDatCoc", _soTienDatCoc);              
            if (_phiGiaoDich != 0)
                cm.Parameters.AddWithValue("@PhiGiaoDich", _phiGiaoDich);
            else
                cm.Parameters.AddWithValue("@PhiGiaoDich", DBNull.Value);
            if (_laiSuat != 0)
                cm.Parameters.AddWithValue("@LaiSuat", _laiSuat);
            else
                cm.Parameters.AddWithValue("@LaiSuat", DBNull.Value);
            cm.Parameters.AddWithValue("@VietBangChu", _vietBangChu);
            cm.Parameters.AddWithValue("@DaThanhToan", _daThanhToan);
            cm.Parameters.AddWithValue("@MuaBan", _muaBan);
            cm.Parameters.AddWithValue("@HDTrongNgoaiDai", _hdTrongNgoaiDai);
            if (_thueSuat != 0)
                cm.Parameters.AddWithValue("@ThueSuat", _thueSuat);
            else cm.Parameters.AddWithValue("@ThueSuat", DBNull.Value);
            if (_thueVAT != 0)
                cm.Parameters.AddWithValue("@ThueVAT", _thueVAT);
            else cm.Parameters.AddWithValue("@ThueVAT", DBNull.Value);
            if (_tenNguoiKy.Length > 0)
                cm.Parameters.AddWithValue("@TenNguoiKy", _tenNguoiKy);
            else
                cm.Parameters.AddWithValue("@TenNguoiKy", DBNull.Value);
            cm.Parameters.AddWithValue("@TenNguoiLienLac", _tenNguoiLienLac);
            cm.Parameters.AddWithValue("@NgayApDungLai", _ngayApDungLai);
            cm.Parameters.AddWithValue("@SoNgay", _soNgay);
            cm.Parameters.AddWithValue("@LoaiNgay", _loaiNgay);
            cm.Parameters.AddWithValue("@SoThamDinh", _soThamDinh);
            cm.Parameters.AddWithValue("@NgayThamDinh", _ngayThamDinh.DBValue);
            if (_maBoPhanChuQuan != 0)
                cm.Parameters.AddWithValue("@MaBoPhanChuQuan", _maBoPhanChuQuan);
            else cm.Parameters.AddWithValue("@MaBoPhanChuQuan", DBNull.Value);
            if (_donViChuQuan.Length > 0)
                cm.Parameters.AddWithValue("@DonViChuQuan", _donViChuQuan);
            else
                cm.Parameters.AddWithValue("@DonViChuQuan", DBNull.Value);
		}

		private void UpdateChildren(SqlTransaction tr)
		{
			_dotGiaoHangHDMBList.Update(tr, this);
			_dotThanhToanHDMBList.Update(tr, this);
			_cT_HopDongMuaBanList.Update(tr, this);
            _cT_HopDongMuaBanNgoaiTeList.Update(tr, this);
            _cT_MuaBanTSCDList.Update(tr, this);
            _CT_HopDongDichVuList.Update(tr, this);
            _chiTietThanhToanList.Update(tr, this);
		}
		#endregion //Data Access - Update

		#region Data Access - Delete
		internal void DeleteSelf(SqlTransaction tr)
		{
			if (!IsDirty) return;
			if (IsNew) return;

            _CT_HopDongDichVuList.Clear();
            _chiTietThanhToanList.Clear();
            UpdateChildren(tr);
			ExecuteDelete(tr, new Criteria(_maHopDong));
			MarkNew();
		}
		#endregion //Data Access - Delete
		#endregion //Data Access

        #region Kiểm Tra

        internal static int KiemTraSoHopDong(string soHopDong, int loaiHopDong, bool muaBan)
        {
            int giaTriTraVe = 0;
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {

                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_KiemTraSoHopDongMuaBan";
                    cm.Parameters.AddWithValue("@SoHopDong", soHopDong);
                    cm.Parameters.AddWithValue("@LoaiHopDong", loaiHopDong);
                    cm.Parameters.AddWithValue("@GiaTriTraVe", giaTriTraVe);
                    cm.Parameters.AddWithValue("@MuaBan", muaBan);
                    cm.Parameters["@GiaTriTraVe"].Direction = ParameterDirection.Output;
                    cm.ExecuteNonQuery();
                    giaTriTraVe = (int)cm.Parameters["@GiaTriTraVe"].Value;
                }
            }//us

            return giaTriTraVe;
        }

        public static string SoHopDongTuDongTang(int loaiHopDong, bool muaBan)
        {
            string giaTriTraVe =string.Empty;
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {

                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_GetSoHopDongMuaBanLonNhat";                    
                    cm.Parameters.AddWithValue("@LoaiHopDong", loaiHopDong);
                    cm.Parameters.AddWithValue("@MuaBan", muaBan);
                  
                    SqlParameter prmGiaTriTraVe = new SqlParameter("@GiaTriTraVe", SqlDbType.VarChar, 30);
                    prmGiaTriTraVe.Direction = ParameterDirection.Output;
                    cm.Parameters.Add(prmGiaTriTraVe);
                    cm.ExecuteNonQuery();
                    giaTriTraVe = (string)prmGiaTriTraVe.Value;
                }
            }//us
            return giaTriTraVe;
        }

        public static string SetSoHopDongTrongDai(DateTime ngayLap)
        {
            string giaTriTraVe = string.Empty;
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {

                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_SetSoHopDongTrongDai";
                    cm.Parameters.AddWithValue("@NgayLap", ngayLap);
                    SqlParameter prmGiaTriTraVe = new SqlParameter("@GiaTriTraVe", SqlDbType.VarChar, 40);
                    prmGiaTriTraVe.Direction = ParameterDirection.Output;
                    cm.Parameters.Add(prmGiaTriTraVe);
                    cm.ExecuteNonQuery();
                    giaTriTraVe = (string)prmGiaTriTraVe.Value;
                }
            }//us
            return giaTriTraVe;
        }

        public static string SetSoThamDinhHopDong(DateTime ngayLap)
        {
            string giaTriTraVe = string.Empty;
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {

                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_SetSoThamDinhHopDong";
                    cm.Parameters.AddWithValue("@NgayLap", ngayLap);
                    SqlParameter prmGiaTriTraVe = new SqlParameter("@GiaTriTraVe", SqlDbType.VarChar, 40);
                    prmGiaTriTraVe.Direction = ParameterDirection.Output;
                    cm.Parameters.Add(prmGiaTriTraVe);
                    cm.ExecuteNonQuery();
                    giaTriTraVe = (string)prmGiaTriTraVe.Value;
                }
            }//us
            return giaTriTraVe;
        }

        public static bool KiemTraTrungSoHopDong(long maHopDong,string soHopDong)
        {
            bool trungSoHopDong = false;
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {

                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "Spd_KiemTraTrungSoHopDong";
                    cm.Parameters.AddWithValue("@MaHopDong", maHopDong);
                    cm.Parameters.AddWithValue("@SoHopDong", soHopDong);
                    SqlParameter prmGiaTriTraVe = new SqlParameter("@TrungSoHopDong", SqlDbType.Bit);
                    prmGiaTriTraVe.Direction = ParameterDirection.Output;
                    cm.Parameters.Add(prmGiaTriTraVe);
                    cm.ExecuteNonQuery();
                    trungSoHopDong = (bool)prmGiaTriTraVe.Value;
                }
            }//us
            return trungSoHopDong;
        }

        public static bool KiemTraTrungSoThamDinhHopDong(long maHopDong, string soThamDinh)
        {
            bool trungSoThamDinh = false;
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {

                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "Spd_KiemTraTrungSoThamDinhHopDong";
                    cm.Parameters.AddWithValue("@MaHopDong", maHopDong);
                    cm.Parameters.AddWithValue("@SoThamDinh", soThamDinh);
                    SqlParameter prmGiaTriTraVe = new SqlParameter("@TrungSoThamDinh", SqlDbType.Bit);
                    prmGiaTriTraVe.Direction = ParameterDirection.Output;
                    cm.Parameters.Add(prmGiaTriTraVe);
                    cm.ExecuteNonQuery();
                    trungSoThamDinh = (bool)prmGiaTriTraVe.Value;
                }
            }//us
            return trungSoThamDinh;
        }
        #endregion

    }
}
