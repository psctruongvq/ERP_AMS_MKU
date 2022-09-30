


using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;
using System.Globalization;
namespace ERP_Library
{ 
	[Serializable()] 
	public class ExportNhanVien : Csla.BusinessBase<ExportNhanVien>
	{
		#region Business Properties and Methods
        #region members
        //declare members
        private int _maChucDanh = 0;
        private bool _gioiTinh = false;
        private int _maNoiCap = 0;       
        private int _maBoPhan = 0;
        private int _maChucVu = 0;  
        private int _maDanToc = 0;
        private int _maTonGiao = 0;  
        private int _maNganHang = 0;       
        private int _loaiNV = 0;      
        private int _maNgachLuongCoBan = 0;
        private int _maBacLuongCoBan = 0; 
        private int _diachithtTinh = 0; 
        private int _diachittTinh = 0;    
        private decimal _heSoPhuCapChucVu = 0;
        private decimal _heSoLuongBoSung = 0;      
        private decimal _heSoVuotKhung = 0;
        private decimal _heSoVuotKhungBH = 0;
        private decimal _heSoBu = 0;
        private decimal _heSoDocHai = 0;
        private bool _phuCapHC = false;
        private decimal _heSoLuong = 0;
        private decimal _luongKhoan = 0;
        private int _maNhomNgachLuongCB = 0;       
        private int _maNhomNgachLuongBaoHiem = 0;
        private int _maNgachLuongBaoHiem = 0;
        private int _maBacLuongBaoHiem = 0;
        private decimal _heSoLuongBaoHiem = 0;
        private decimal _heSoLuongNoiBo = 0;
        private long _maNhanVien = 0;
        private string _tenNhomNgachLuongCB = string.Empty;
        private string _tenNgachLuongCoBan = string.Empty;
        private string _tenNhomNgachLuongBaoHiem = string.Empty;
        public string _tenGioiTinh = string.Empty;
        public string _tenBacLuongCoBan = string.Empty;
        public string _tenNgachLuongBaoHiem = string.Empty;
        public string _tenBacLuongBaoHiem = string.Empty;
        private string _maQLNhanVien = string.Empty;      
        private string _tenNhanVien = string.Empty;
        private string _ho = string.Empty;
        private string _ten = string.Empty;
        private string _tenChucVu = string.Empty;
        private string _tenBoPhan = string.Empty;
        private string _cmnd = string.Empty;
      
        private SmartDate _ngayCap = new SmartDate(false);
        private SmartDate _ngaySinh = new SmartDate(DateTime.Today.Date);
        private Nullable<DateTime> _ngayTinhThamNien = null;
        private Nullable<DateTime> _mocLenLuong = null;
        private Nullable<DateTime> _mocLenLuongBaoHiem = null;
        private string _thangSinh = string.Empty;
        private string _namSinh = string.Empty;
        private SmartDate _ngayVaoNganh = new SmartDate(DateTime.Today.Date);   
        private string _soTaiKhoan = string.Empty;      
        private string _diachiThT = string.Empty;
        private string _diachiTT = string.Empty;
        private string _dienthoaiThT = string.Empty;
        private string _dienthoaiTT = string.Empty;
        private string _theNhaBao = string.Empty;
        private string _maSoThue = string.Empty;
        private string _tenDiaChiThT_Tinh = string.Empty;
        private string _tenDiaChiTT_Tinh = string.Empty;
        private string _tenChucDanh = string.Empty;
        private string _tenDanToc = string.Empty;
        private string _tenTonGiao = string.Empty;
        private string _tenNganHang = string.Empty;
        private string _tenLoaiNV = string.Empty;
		//declare child member(s)
       
        //private NhanVien_NgoaiNguList _ngoaiNgu_NhanVienList = NhanVien_NgoaiNguList.NewNhanVien_NgoaiNguList();
        //private NhanVien_TrinhDoQuanLyList _trinhDoQL_NhanVienList = NhanVien_TrinhDoQuanLyList.NewNhanVien_TrinhDoQuanLyList();
			
        //private QuaTrinhTGQDList _quaTrinhTGQDList = QuaTrinhTGQDList.NewQuaTrinhTGQDList();
        //private QuyetDinhNangLuongList _quyetDinhNangLuongList = QuyetDinhNangLuongList.NewQuyetDinhNangLuongList();
        //private TrinhDoList _trinhDoList = TrinhDoList.NewTrinhDoList();
        //private QuanHeGiaDinhList _quanHeGiaDinhList = QuanHeGiaDinhList.NewQuanHeGiaDinhList();
        //private QuaTrinhLuanChuyenBoNhiemList _quaTrinhLuanChuyenBoNhiemList = QuaTrinhLuanChuyenBoNhiemList.NewQuaTrinhLuanChuyenBoNhiemList();
        //private HoatDongXaHoiList _HoatDongXHList = HoatDongXaHoiList.NewHoatDongXaHoiList();
        //private NhanVienGiaCanhList _NhanVienGiaCanhList = NhanVienGiaCanhList.NewNhanVienGiaCanhList();
        //private NhanVien_EmailList _NhanVien_EmailList = NhanVien_EmailList.NewNhanVien_EmailList();
        //private ThongTinKhacList _ThongTinKhacList = ThongTinKhacList.NewThongTinKhacList();
        
        #endregion members
        [System.ComponentModel.DataObjectField(true, true)]
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
        public string Ten
        {
            get { return _ten; }
            set { _ten = value; }
        }
        public string Ho
        {
            get { return _ho; }
            set { _ho = value; }
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
                    _tenBoPhan = BoPhan.GetBoPhan(_maBoPhan).TenBoPhan;
                    PropertyHasChanged("MaBoPhan");
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
                    _tenGioiTinh = "Nữ";
                else if (_gioiTinh == true)
                    _tenGioiTinh = "Nam";
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
        public string TheNhaBao
        {
            get
            {
                CanReadProperty("TheNhaBao", true);
                return _theNhaBao;
            }
            set
            {
                CanWriteProperty("TheNhaBao", true);
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
        public string TenLoaiNV
        {
            get
            {
                if (_loaiNV == 1)
                    _tenLoaiNV = "BC";
                if (_loaiNV == 2)
                    _tenLoaiNV = "V1";
                if (_loaiNV == 3)
                    _tenLoaiNV = "V2";
                if (_loaiNV == 4)
                    _tenLoaiNV = "HD";
                return _tenLoaiNV;
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
                    _tenChucVu = ChucVu.GetChucVu(_maChucVu).TenChucVu;
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
                    _tenChucDanh = ChucDanh.GetChucDanh(_maChucDanh).TenChucDanh;
                    PropertyHasChanged("MaChucDanh");
                }
            }
        }
        public string TenChucDanh
        {
            get
            {
                _tenChucDanh = ChucDanh.GetChucDanh(_maChucDanh).TenChucDanh;
                return _tenChucDanh; }
            set { _tenChucDanh = value; }
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
                    _tenDanToc = DanToc_NV.GetDanToc_NV(_maDanToc).DanToc;
                    PropertyHasChanged("MaDanToc");
                }
            }
        }
        public string TenDanToc
        {
            get {
                _tenDanToc = DanToc_NV.GetDanToc_NV(_maDanToc).DanToc; 
                return _tenDanToc;
            }
            set { _tenDanToc = value; }
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
                    _tenTonGiao = TonGiao.GetTonGiao(_maTonGiao).TenTonGiao;
                    PropertyHasChanged("MaTonGiao");
                }
            }
        }
        public string TenTonGiao
        {
            get {
                _tenTonGiao = TonGiao.GetTonGiao(_maTonGiao).TenTonGiao;
                return _tenTonGiao; }
            set { _tenTonGiao = value; }
        }
        public DateTime NgayVaoDai
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
        public Nullable<DateTime> NgayBoNhiem
        {
            get
            {
                CanReadProperty("NgayTinhThamNien", true);
                return _ngayTinhThamNien;
            }
            set
            {
                CanWriteProperty(true);
                if (!_ngayTinhThamNien.Equals(value))
                {
                    _ngayTinhThamNien = value;
                    PropertyHasChanged("NgayTinhThamNien");
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
                    _tenNganHang = NganHang.GetNganHang(_maNganHang).TenNganHang;
                    PropertyHasChanged("MaNganHang");
                }
            }
        }
        public string TenNganHang
        {
            get {
                _tenNganHang = NganHang.GetNganHang(_maNganHang).TenNganHang;
                return _tenNganHang; }
            set { _tenNganHang = value; }
        }
        public int MaNhomNgachLuongCB
        {
            get
            {
                CanReadProperty("MaNhomNgachLuongCB", true);
                return _maNhomNgachLuongCB;
            }
            set
            {
                CanWriteProperty("MaNhomNgachLuongCB", true);
                if (!_maNhomNgachLuongCB.Equals(value))
                {

                    _maNhomNgachLuongCB = value;
                    _tenNhomNgachLuongCB = NhomNgachLuongCoBan.GetNhomNgachLuongCoBan(_maNhomNgachLuongCB).TenNhomNgachLuongCoBan;
                    PropertyHasChanged("MaNhomNgachLuongCB");
                }
            }
        }
        public string TenNhomNgachLuongCB
        {
            get {
                _tenNhomNgachLuongCB = NhomNgachLuongCoBan.GetNhomNgachLuongCoBan(_maNhomNgachLuongCB).TenNhomNgachLuongCoBan;
                
                return _tenNhomNgachLuongCB; }
            set { _tenNhomNgachLuongCB = value; }
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
                    _tenNgachLuongCoBan = NgachLuongCoBan.GetNgachLuongCoBan(_maNgachLuongCoBan).MaQuanLy;
                    PropertyHasChanged("MaNgachLuongCoBan");
                }
            }
        }
        public string TenNgachLuongCoBan
        {
            get {
                _tenNgachLuongCoBan = NgachLuongCoBan.GetNgachLuongCoBan(_maNgachLuongCoBan).MaQuanLy;

                return _tenNgachLuongCoBan; }
            set { _tenNgachLuongCoBan = value; }
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
                    HeSoLuong = BacLuongCoBan.GetBacLuongCoBan(_maBacLuongCoBan).HeSoLuong;
                    _tenBacLuongCoBan = BacLuongCoBan.GetBacLuongCoBan(_maBacLuongCoBan).MaQuanLy;
                    PropertyHasChanged("MaBacLuongCoBan");
                }
            }
        }
        public string TenBacLuongCoBan
        {
            get
            {
                CanReadProperty("TenBacLuongCoBan", true);
                _tenBacLuongCoBan = BacLuongCoBan.GetBacLuongCoBan(_maBacLuongCoBan).MaQuanLy;
                return _tenBacLuongCoBan;
            }
            set
            {
                CanWriteProperty("TenBacLuongCoBan", true);
                if (!_tenBacLuongCoBan.Equals(value))
                {
                    _tenBacLuongCoBan = value;
                  
                    PropertyHasChanged("TenBacLuongCoBan");
                }
            }
        }
        public decimal HeSoLuong
        {
            get
            {
                CanReadProperty("HeSoLuong", true);
                return _heSoLuong;
            }
            set
            {
                CanWriteProperty("HeSoLuong", true);
                if (!_heSoLuong.Equals(value))
                {
                    _heSoLuong = value;
                    PropertyHasChanged("HeSoLuong");
                }
            }
        }
        public int MaNhomNgachLuongBaoHiem
        {
            get
            {
                CanReadProperty("MaNhomNgachLuongBaoHiem", true);
                return _maNhomNgachLuongBaoHiem;
            }
            set
            {
                CanWriteProperty("MaNhomNgachLuongBaoHiem", true);
                if (!_maNhomNgachLuongBaoHiem.Equals(value))
                {

                    _maNhomNgachLuongBaoHiem = value;
                    _tenNhomNgachLuongBaoHiem = NhomNgachLuongCoBan.GetNhomNgachLuongCoBan(_maNhomNgachLuongBaoHiem).MaQL;
                    PropertyHasChanged("MaNhomNgachLuongBaoHiem");
                }
            }
        }
        public string TenNhomNgachLuongBaoHiem
        {
            get {
                _tenNhomNgachLuongBaoHiem = NhomNgachLuongCoBan.GetNhomNgachLuongCoBan(_maNhomNgachLuongBaoHiem).MaQL;
                
                return _tenNhomNgachLuongBaoHiem; }
            set { _tenNhomNgachLuongBaoHiem = value; }
        }
        public int MaNgachLuongBaoHiem
        {
            get
            {
                CanReadProperty("MaNgachLuongBaoHiem", true);
                return _maNgachLuongBaoHiem;
            }
            set
            {
                CanWriteProperty("MaNgachLuongBaoHiem", true);
                if (!_maNgachLuongBaoHiem.Equals(value))
                {
                    _maNgachLuongBaoHiem = value;
                    _tenNgachLuongBaoHiem = NgachLuongCoBan.GetNgachLuongCoBan(_maNgachLuongBaoHiem).MaQuanLy;
                    PropertyHasChanged("MaNgachLuongBaoHiem");
                }
            }
        }   
        public string TenNgachLuongBaoHiem
        {
            get
            {
                _tenNgachLuongBaoHiem = NgachLuongCoBan.GetNgachLuongCoBan(_maNgachLuongBaoHiem).MaQuanLy;
              
                return _tenNgachLuongBaoHiem;
            }
            set
            {
                CanWriteProperty("TenNgachLuongBaoHiem", true);
                if (value == null) value = string.Empty;
                if (!_tenNgachLuongBaoHiem.Equals(value))
                {
                    _tenNgachLuongBaoHiem = value;
                    PropertyHasChanged("TenNgachLuongBaoHiem");
                }
            }
        }
        public int MaBacLuongBaoHiem
        {
            get
            {
                CanReadProperty("MaBacLuongBaoHiem", true);
                return _maBacLuongBaoHiem;
            }
            set
            {
                CanWriteProperty("MaBacLuongBaoHiem", true);
                if (!_maBacLuongBaoHiem.Equals(value))
                {

                    _maBacLuongBaoHiem = value;
                    _heSoLuongBaoHiem = BacLuongCoBan.GetBacLuongCoBan(_maBacLuongBaoHiem).HeSoLuong;
                    _tenBacLuongBaoHiem = BacLuongCoBan.GetBacLuongCoBan(_maBacLuongBaoHiem).MaQuanLy;
                    PropertyHasChanged("MaBacLuongBaoHiem");
                }
            }
        }
        public string TenBacLuongBaoHiem
        {
            get
            {
                _tenBacLuongBaoHiem = BacLuongCoBan.GetBacLuongCoBan(_maBacLuongBaoHiem).MaQuanLy;

                return _tenBacLuongBaoHiem;
            }
            set
            {
                CanWriteProperty("TenBacLuongBaoHiem", true);
                if (value == null) value = string.Empty;
                if (!_tenBacLuongBaoHiem.Equals(value))
                {
                    _tenBacLuongBaoHiem = value;
                    PropertyHasChanged("TenBacLuongBaoHiem");
                }
            }
        }          
        public decimal HeSoLuongBaoHiem
        {
            //HeSoLuongCoBan ->HSBH
            //HeSoPhu->HeSoCoBan
            get
            {
                CanReadProperty("HeSoLuongBaoHiem", true);
                //_heSoLuongCoBan =(decimal)BacLuongCoBan.GetBacLuongCoBan(_maBacLuongCoBan).HeSoLuong;
                return _heSoLuongBaoHiem;
            }
            set
            {
                CanWriteProperty("HeSoLuongBaoHiem", true);
                if (!_heSoLuongBaoHiem.Equals(value))
                {
                    _heSoLuongBaoHiem = value;
                    //   _heSoLuongCoBan = (decimal)BacLuongCoBan.GetBacLuongCoBan(_maBacLuongCoBan).HeSoLuong;

                    PropertyHasChanged("HeSoLuongBaoHiem");
                }
            }
        }
        public decimal HeSoVuotKhung
        {
            get
            {
                CanReadProperty("HeSoVuotKhung", true);
                return _heSoVuotKhung;
            }
            set
            {
                CanWriteProperty("HeSoVuotKhung", true);
                if (!_heSoVuotKhung.Equals(value))
                {
                    _heSoVuotKhung = value;
                    PropertyHasChanged("HeSoVuotKhung");
                }
            }
        }
        public decimal HeSoVuotKhungBH
        {
            get
            {
                CanReadProperty("HeSoVuotKhungBH", true);
                return _heSoVuotKhungBH;
            }
            set
            {
                CanWriteProperty("HeSoVuotKhungBH", true);
                if (!_heSoVuotKhungBH.Equals(value))
                {
                    _heSoVuotKhungBH = value;
                    PropertyHasChanged("HeSoVuotKhungBH");
                }
            }
        }
        public decimal HeSoLuongNoiBo
        {
            get { return _heSoLuongNoiBo; }
            set { _heSoLuongNoiBo = value; }
        }
        public decimal HeSoLuongBoSung
        {
            get
            {
                CanReadProperty("HeSoLuongBoSung", true);
                return _heSoLuongBoSung;
            }
            set
            {
                CanWriteProperty("HeSoLuongBoSung", true);
                if (!_heSoLuongBoSung.Equals(value))
                {
                    _heSoLuongBoSung = value;
                    PropertyHasChanged("HeSoLuongBoSung");
                }
            }
        }      
        public decimal HeSoPhuCapChucVu
        {
            get
            {
                CanReadProperty("HeSoPhuCapChucVu", true);
                return _heSoPhuCapChucVu;
            }
            set
            {
                CanWriteProperty("HeSoPhuCapChucVu", true);
                if (!_heSoPhuCapChucVu.Equals(value))
                {
                    _heSoPhuCapChucVu = value;
                    PropertyHasChanged("HeSoPhuCapChucVu");
                }
            }
        }
        public decimal HeSoDocHai
        {
            get
            {
                CanReadProperty("HeSoDocHai", true);
                return _heSoDocHai;
            }
            set
            {
                CanWriteProperty("HeSoDocHai", true);
                if (!_heSoDocHai.Equals(value))
                {
                    _heSoDocHai = value;
                    PropertyHasChanged("HeSoDocHai");
                }
            }
        }
        public decimal LuongKhoan
        {
            get
            {
                CanReadProperty("LuongKhoan", true);
                return _luongKhoan;
            }
            set
            {
                CanWriteProperty("LuongKhoan", true);
                if (!_luongKhoan.Equals(value))
                {
                    _luongKhoan = value;
                    PropertyHasChanged("LuongKhoan");
                }
            }
        }
        public decimal HeSoBu
        {
            get
            {
                CanReadProperty("HeSoBu", true);
                return _heSoBu;
            }
            set
            {
                CanWriteProperty("HeSoBu", true);
                if (!_heSoBu.Equals(value))
                {
                    _heSoBu = value;
                    PropertyHasChanged("HeSoBu");
                }
            }
        }
        public bool PhuCapHC
        {
            get
            {
                CanReadProperty("PhuCapHC", true);
                return _phuCapHC;
            }
            set
            {
                CanWriteProperty("PhuCapHC", true);
                if (!_phuCapHC.Equals(value))
                {
                    _phuCapHC = value;
                    PropertyHasChanged("PhuCapHC");
                }
            }
        }
        public Nullable<DateTime> MocLenLuong
        {
            get
            {
                CanReadProperty("MocLenLuong", true);
                return _mocLenLuong;
            }
            set
            {
                CanWriteProperty(true);
                if (!_mocLenLuong.Equals(value))
                {
                    _mocLenLuong = value;
                    PropertyHasChanged("MocLenLuong");
                }
            }
        }
        public Nullable<DateTime> MocLenLuongBaoHiem
        {
            get
            {
                CanReadProperty("MocLenLuongBaoHiem", true);
                return _mocLenLuongBaoHiem;
            }
            set
            {
                CanWriteProperty(true);
                if (!_mocLenLuongBaoHiem.Equals(value))
                {
                    _mocLenLuongBaoHiem = value;
                    PropertyHasChanged("MocLenLuongBaoHiem");
                }
            }
        }      
        public string DiachiThuongTru
        {
            get
            {
                CanReadProperty("DiachiThuongTru", true);
                return _diachiThT;
            }
            set
            {
                CanWriteProperty("DiachiThuongTru", true);
                if (value == null) value = string.Empty;
                if (!_diachiThT.Equals(value))
                {
                    _diachiThT = value;
                    PropertyHasChanged("DiachiThuongTru");
                }
            }
        }
        public int MaDiachiThuongTru_Tinh
        {
            get
            {
                CanReadProperty("MaDiachiThuongTru_Tinh", true);
                return _diachithtTinh;
            }
            set
            {
                CanWriteProperty("MaDiachiThuongTru_Tinh", true);
                if (!_diachithtTinh.Equals(value))
                {
                    _diachithtTinh = value;
                    _tenDiaChiThT_Tinh = TinhThanh.GetTinhThanh(_diachithtTinh).TenTinhThanh;
                    PropertyHasChanged("MaDiachiThuongTru_Tinh");
                }
            }
        }
        public string TenDiaChiThT_Tinh
        {
            get {
                _tenDiaChiThT_Tinh = TinhThanh.GetTinhThanh(_diachithtTinh).TenTinhThanh;
                
                return _tenDiaChiThT_Tinh; }
            set { _tenDiaChiThT_Tinh = value; }
        }
        public string DiachiTT
        {
            get
            {
                CanReadProperty("DiachiTT", true);
                return _diachiTT;
            }
            set
            {
                CanWriteProperty("DiachiTT", true);
                if (value == null) value = string.Empty;
                if (!_diachiTT.Equals(value))
                {
                    _diachiTT = value;
                    PropertyHasChanged("DiachiTT");
                }
            }
        }
        public int DiachiTT_Tinh
        {
            get
            {
                CanReadProperty("DiachiTT_Tinh", true);
                return _diachittTinh;
            }
            set
            {
                CanWriteProperty("DiachiTT_Tinh", true);
                if (!_diachittTinh.Equals(value))
                {
                    _diachittTinh = value;
                    _tenDiaChiTT_Tinh = TinhThanh.GetTinhThanh(_diachittTinh).TenTinhThanh;
                    PropertyHasChanged("DiachiTT_Tinh");
                }
            }
        }
        public string TenDiaChiTT_Tinh
        {
            get {
                _tenDiaChiTT_Tinh = TinhThanh.GetTinhThanh(_diachittTinh).TenTinhThanh;                
                return _tenDiaChiTT_Tinh; }
            set { _tenDiaChiTT_Tinh = value; }
        }
        public string DienthoaiThT
        {
            get
            {
                CanReadProperty("DienthoaiThT", true);
                return _dienthoaiThT;
            }
            set
            {
                CanWriteProperty("DienthoaiThT", true);
                if (value == null) value = string.Empty;
                if (!_dienthoaiThT.Equals(value))
                {
                    _dienthoaiThT = value;
                    PropertyHasChanged("DienthoaiThT");
                }
            }
        }
        public string DienthoaiTT
        {
            get
            {
                CanReadProperty("DienthoaiTT", true);
                return _dienthoaiTT;
            }
            set
            {
                CanWriteProperty("DienthoaiTT", true);
                if (value == null) value = string.Empty;
                if (!_dienthoaiTT.Equals(value))
                {
                    _dienthoaiTT = value;
                    PropertyHasChanged("DienthoaiTT");
                }
            }
        }      
        /*
       public NhanVien_NgoaiNguList NhanVienNgoaiNguList
        {
            get
            {
                CanReadProperty("NhanVienNgoaiNguList", true);
                return _ngoaiNgu_NhanVienList;
            }
            set
            {
                CanWriteProperty("NhanVienNgoaiNguList", true);
                if (!_ngoaiNgu_NhanVienList.Equals(value))
                {
                    _ngoaiNgu_NhanVienList = value;
                    PropertyHasChanged("NhanVienNgoaiNguList");
                }
            }
        }
        public NhanVien_TrinhDoQuanLyList NhanVienTrinhDoQuanLyList
        {
            get
            {
                CanReadProperty("NhanVienTrinhDoQuanLyList", true);
                return _trinhDoQL_NhanVienList;
            }
            set
            {
                CanWriteProperty("NhanVienTrinhDoQuanLyList", true);
                if (!_trinhDoQL_NhanVienList.Equals(value))
                {
                    _trinhDoQL_NhanVienList = value;
                    PropertyHasChanged("NhanVienTrinhDoQuanLyList");
                }
            }
        }
		public TrinhDoList TrinhDoList
		{
			get
			{
				CanReadProperty("TrinhDoList", true);
				return _trinhDoList;
			}
            set
            {
                CanWriteProperty("TrinhDoList", true);
                if (!_trinhDoList.Equals(value))
                {
                    _trinhDoList = value;
                    PropertyHasChanged("TrinhDoList");
                }
            }
		}
        public QuanHeGiaDinhList QuanHeGiaDinhList
        {
            get
            {
                CanReadProperty("QuanHeGiaDinhList", true);
                return _quanHeGiaDinhList;
            }
        }

        public QuaTrinhLuanChuyenBoNhiemList QuaTrinhLuanChuyenBoNhiemList
        {
            get
            {
                CanReadProperty("QuaTrinhLuanChuyenBoNhiemList", true);
                return _quaTrinhLuanChuyenBoNhiemList;
            }
        }

        public HoatDongXaHoiList HoatDongXHList
        {
            get
            {
                CanReadProperty("HoatDongXHList", true);
                return _HoatDongXHList;
            }
            set
            {
                CanWriteProperty("HoatDongXHList", true);
                if (!_HoatDongXHList.Equals(value))
                {
                    _HoatDongXHList = value;
                    PropertyHasChanged("HoatDongXHList");
                }
            }
        }
        public NhanVienGiaCanhList NhanVienGiaCanhList
        {
            get
            {
                CanReadProperty("NhanVienGiaCanhList", true);
               // _NhanVienGiaCanhList = NhanVienGiaCanhList.GetNhanVienGiaCanhList(MaNhanVien);
                return _NhanVienGiaCanhList;
            }
            set
            {
                CanWriteProperty("NhanVienGiaCanhList", true);
                if (!_NhanVienGiaCanhList.Equals(value))
                {
                    _NhanVienGiaCanhList = value;
                   // _NhanVienGiaCanhList = NhanVienGiaCanhList.GetNhanVienGiaCanhList(MaNhanVien);
                    PropertyHasChanged("NhanVienGiaCanhList");
                }
            }
 
        }

        public ThongTinKhacList ThongTinKhacList
        {
            get
            {
                CanReadProperty("ThongTinKhacList", true);
                return _ThongTinKhacList;
            }
            set
            {
                CanWriteProperty("ThongTinKhacList", true);
                if (!_ThongTinKhacList.Equals(value))
                {
                    _ThongTinKhacList = value;
                    PropertyHasChanged("ThongTinKhacList");
                }
            }
        }

        public QuyetDinhNangLuongList QuyetDinhNangLuong_List
        {
            get
            {
                CanReadProperty("QuyetDinhNangLuong_List", true);
                return _quyetDinhNangLuongList;
            }
            set
            {
                CanWriteProperty("QuyetDinhNangLuong_List", true);
                if (!_quyetDinhNangLuongList.Equals(value))
                {
                    _quyetDinhNangLuongList = value;
                    PropertyHasChanged("QuyetDinhNangLuong_List");
                }
            }
        }

      */

     

        public override bool IsValid
        {
            get { return base.IsValid;}// ||  _quaTrinhTGQDList.IsValid || _trinhDoList.IsValid || _HoatDongXHList.IsValid || _NhanVien_EmailList.IsValid || _ThongTinKhacList.IsValid || _ngoaiNgu_NhanVienList.IsValid || _trinhDoQL_NhanVienList.IsValid; }
        }

        public override bool IsDirty
        {
            get { return base.IsDirty ;}//||  _quaTrinhTGQDList.IsDirty || _trinhDoList.IsDirty || _HoatDongXHList.IsDirty || _NhanVien_EmailList.IsDirty || _ThongTinKhacList.IsDirty || _ngoaiNgu_NhanVienList.IsDirty || _trinhDoQL_NhanVienList.IsDirty; }
        }

		protected override object GetIdValue()
		{
			return _maNhanVien;
		}

		#endregion //Business Properties and Methods


		#region Factory Methods
		public ExportNhanVien()
		{ /* require use of factory method */ }
        public ExportNhanVien(string tenNhanVien)
        {
            
            this.TenNhanVien=tenNhanVien;
        }
        

		public static ExportNhanVien NewNhanVien()
		{
		
            return DataPortal.Create<ExportNhanVien>(new CriteriaAll());
		}
        public static ExportNhanVien NewNhanVien(long maNhanVien,string TenNhanVien)
        {
            return new ExportNhanVien(TenNhanVien);
        }
		public static ExportNhanVien GetNhanVien(long maNhanVien)
		{
			
			return DataPortal.Fetch<ExportNhanVien>(new Criteria(maNhanVien));
		}
        public static ExportNhanVien GetNhanVienByDatabase(long maNhanVien,int dataBaseNumber)
        {
          
            return DataPortal.Fetch<ExportNhanVien>(new CriteriabyDatabase(maNhanVien,dataBaseNumber));
        }
        public static ExportNhanVien GetNhanVienByMaQL(string maQLNhanVien)
        {
           
            return DataPortal.Fetch<ExportNhanVien>(new CriteriaByMaQL(maQLNhanVien));
        }

		public static void DeleteNhanVien(long maNhanVien)
		{
			
			DataPortal.Delete(new Criteria(maNhanVien));
		}

		public override ExportNhanVien Save()
		{
			
		

			return base.Save();
		}
     
		#endregion //Factory Methods

		#region Child Factory Methods
		internal static ExportNhanVien NewNhanVienChild()
		{
			ExportNhanVien child = new ExportNhanVien();
			child.ValidationRules.CheckRules();
			child.MarkAsChild();
			return child;
		}

		internal static ExportNhanVien GetNhanVien(SafeDataReader dr)
		{
			ExportNhanVien child =  new ExportNhanVien();
			child.MarkAsChild();
			child.Fetch(dr);
			return child;
		}
        internal static ExportNhanVien GetNhanVienNotChild(SafeDataReader dr)
        {
            ExportNhanVien child = new ExportNhanVien();
            child.MarkAsChild();
            child.FetchNotChild(dr);
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
        private class CriteriabyDatabase
		{
			public long MaNhanVien;
            public int DatabaseNumber;

            public CriteriabyDatabase(long maNhanVien,int databaseNumber)
			{
				this.MaNhanVien = maNhanVien;
                this.DatabaseNumber = databaseNumber;
			}
		}
        
        [Serializable()]
        private class CriteriaByMaQL
        {
            //public long MaNhanVien;
            public string maQLNV;
            public CriteriaByMaQL(string maQLNV)
            {
                this.maQLNV = maQLNV;
            }
        }
        [Serializable()]
        private class CriteriaAll
        {

            public CriteriaAll()
            {

            }
        }

		#endregion //Criteria

		#region Data Access - Create
		[RunLocal]
        private  void DataPortal_Create(CriteriaAll criteria)
		{
			//ValidationRules.CheckRules();
		}

		#endregion //Data Access - Create

		#region Data Access - Fetch
		private void DataPortal_Fetch(Object criteria)
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
				catch(Exception ex)
				{
					tr.Rollback();
					throw ex;
				}
			}//using
		}

		private void ExecuteFetch(SqlTransaction tr, Object criteria)
		{
			using (SqlCommand cm = tr.Connection.CreateCommand())
			{
				cm.Transaction = tr;
				cm.CommandType = CommandType.StoredProcedure;
                if (criteria is Criteria)
                {
                    cm.CommandText = "spd_SelecttblnsNhanVien";
                    cm.Parameters.AddWithValue("@MaNhanVien", ((Criteria)criteria).MaNhanVien);
                }
                if (criteria is CriteriabyDatabase)
                {
                    cm.CommandText = "spd_SelecttblnsNhanVienByDatabase";
                    cm.Parameters.AddWithValue("@MaNhanVien", ((CriteriabyDatabase)criteria).MaNhanVien);
                    cm.Parameters.AddWithValue("@DatabaseNumber", ((CriteriabyDatabase)criteria).DatabaseNumber);
                }
                else if (criteria is CriteriaByMaQL)
                {
                    cm.CommandText = "spd_SelecttblnsNhanVienByMaQL";
                    cm.Parameters.AddWithValue("@MaQLNhanVien", ((CriteriaByMaQL)criteria).maQLNV);
                }

				using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
				{
                    while (dr.Read())
                    {
                        FetchObject(dr);
                        //ValidationRules.CheckRules();
                        //load child object(s)
                        //FetchChildren(_maNhanVien);
                    }
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
			//FetchChildren(_maNhanVien);
		}
        private void FetchNotChild(SafeDataReader dr)
        {
            FetchObject(dr);
           
        }

        private void FetchObject(SafeDataReader dr)
        {
            try
            {
              
                _maNhanVien = dr.GetInt64("MaNhanVien");
                _maQLNhanVien = dr.GetString("MaQLNhanVien");
             
                _tenNhanVien = dr.GetString("TenNhanVien");
                _maChucVu = dr.GetInt32("MaChucVu");
                
                _tenChucVu = dr.GetString("TenChucVu");                
                _diachiThT = dr.GetString("DiachiThT");            
                _diachiThT = dr.GetString("DiachiThT");
                _diachiTT = dr.GetString("DiachiTT");               
                _diachittTinh = dr.GetInt32("DiachiTT_Tinh");
                _diachithtTinh = dr.GetInt32("DiachiThT_Tinh");
                _dienthoaiThT = dr.GetString("DienthoaiThT");
                _dienthoaiTT = dr.GetString("DienthoaiTT");
                _ho = dr.GetString("Ho");
                _ten = dr.GetString("Ten");
                _maBoPhan = dr.GetInt32("MaBoPhan");
                _tenBoPhan = dr.GetString("TenBoPhan");
                _gioiTinh = dr.GetBoolean("GioiTinh");
                _cmnd = dr.GetString("CMND");
                _ngayCap = dr.GetSmartDate("NgayCap");
                _maNoiCap = dr.GetInt32("MaNoiCap");               
                _maChucDanh = dr.GetInt32("MaChucDanh");
                _ngaySinh = dr.GetSmartDate("NgaySinh");
                      
            
                _maDanToc = dr.GetInt32("MaDanToc");
                _maTonGiao = dr.GetInt32("MaTonGiao");
                _ngayVaoNganh = dr.GetSmartDate("NgayVaoNganh");              
                object ngayTinhTT = dr.GetValue("NgayTinhThamNien");
                if (ngayTinhTT != null)
                {
                    string dateStr=Convert.ToDateTime(ngayTinhTT).ToShortDateString();
                    _ngayTinhThamNien = Convert.ToDateTime(dateStr); 
                }
                else
                    _ngayTinhThamNien = null;

                object mocLenLuong = dr.GetValue("MocLenLuong");
                if (mocLenLuong != null)
                    _mocLenLuong = Convert.ToDateTime(mocLenLuong).Date;
                else
                    _mocLenLuong = null;
                object mocLenLuongBaoHiem = dr.GetValue("MocLenLuongBaoHiem");
                if (mocLenLuongBaoHiem != null)
                    _mocLenLuongBaoHiem = Convert.ToDateTime(mocLenLuongBaoHiem).Date;
                else
                    _mocLenLuongBaoHiem = null;
              
                _soTaiKhoan = dr.GetString("SoTaiKhoan");
                _maNganHang = dr.GetInt32("MaNganHang");
            
              
                _loaiNV = dr.GetInt32("LoaiNV");  
              
             
                         
              
             
                _theNhaBao = dr.GetString("TheNhaBao");
                _maSoThue = dr.GetString("MaSoThue");
            
               

                _maNhomNgachLuongCB = dr.GetInt32("MaNhomNgachLuongCB");
                _maNgachLuongCoBan = dr.GetInt32("MaNgachLuongCoBan");
                _maBacLuongCoBan = dr.GetInt32("MaBacLuongCoBan");
                _heSoLuongBaoHiem = dr.GetDecimal("HeSoLuongBaoHiem");

                _maNhomNgachLuongBaoHiem = dr.GetInt32("MaNhomNgachLuongBaoHiem");
                _maNgachLuongBaoHiem = dr.GetInt32("MaNgachLuongBaoHiem");
                _maBacLuongBaoHiem = dr.GetInt32("MaBacLuongBaoHiem");
                _heSoLuongBaoHiem = dr.GetDecimal("HeSoLuongBaoHiem");

                _heSoLuong = dr.GetDecimal("HeSoLuong");

               _heSoLuongBoSung = dr.GetDecimal("HeSoLuongBoSung");
                _heSoPhuCapChucVu = dr.GetDecimal("HeSoPhuCapChucVu");                           
               _heSoBu = dr.GetDecimal("HeSoBu");
               _heSoDocHai = dr.GetDecimal("HeSoDocHai");
               _phuCapHC = dr.GetBoolean("PhuCapHC");
           
               _heSoVuotKhung = dr.GetDecimal("HeSoVuotKhung");
               _heSoVuotKhungBH = dr.GetDecimal("HeSoVuotKhungBH"); 
              
               _luongKhoan = dr.GetDecimal("LuongKhoan");
               _heSoLuongNoiBo = dr.GetDecimal("HeSoLuongNoiBo");
              
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /*
		private void FetchChildren(long maNhaVien)
		{
           
            if (NhanVien_NgoaiNguList.GetNhanVien_NgoaiNguList(maNhaVien).Count!=0)
            {
                _ngoaiNgu_NhanVienList = NhanVien_NgoaiNguList.GetNhanVien_NgoaiNguList(_maNhanVien);
            }
            if (NhanVien_TrinhDoQuanLyList.GetNhanVien_TrinhDoQuanLyList(maNhaVien).Count != 0)
            {
                _trinhDoQL_NhanVienList = NhanVien_TrinhDoQuanLyList.GetNhanVien_TrinhDoQuanLyList(maNhaVien);
            }
            
            if (QuaTrinhTGQDList.GetQuaTrinhTGQDList(maNhaVien).Count != 0)
            {
                _quaTrinhTGQDList = QuaTrinhTGQDList.GetQuaTrinhTGQDList(maNhaVien);
            }
            if (TrinhDoList.GetTrinhDoList(maNhaVien).Count != 0)
            {
                _trinhDoList = TrinhDoList.GetTrinhDoList(maNhaVien);
            }
            if (HoatDongXaHoiList.GetHoatDongXaHoiList(maNhaVien).Count != 0)
            {
                _HoatDongXHList = HoatDongXaHoiList.GetHoatDongXaHoiList(maNhaVien);
            }
            if (NhanVienGiaCanhList.GetNhanVienGiaCanhList(maNhaVien).Count == 0)
            {
                _NhanVienGiaCanhList = NhanVienGiaCanhList.GetNhanVienGiaCanhList(maNhaVien);
                
            }
            if (NhanVien_EmailList.GetNhanVien_EmailList(maNhaVien).Count != 0)
            {
                _NhanVien_EmailList = NhanVien_EmailList.GetNhanVien_EmailList(maNhaVien);
            }
            if (ThongTinKhacList.GetThongTinKhacList(maNhaVien).Count != 0)
            {
                _ThongTinKhacList = ThongTinKhacList.GetThongTinKhacList(maNhaVien);
            }
            //_HoSoLuongList = HoSoLuong.GetHoSoLuong(maNhaVien);
		}
        */
		#endregion //Data Access - Fetch
     
        #endregion //Data Access

   
	}
}
