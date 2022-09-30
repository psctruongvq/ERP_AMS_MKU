
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;
using System.Windows.Forms;

namespace ERP_Library
{ 
	[Serializable()] 
	public class NhanVien : Csla.BusinessBase<NhanVien>
	{
		#region Business Properties and Methods
        #region members
        //declare members
        public string _tenGioiTinh = string.Empty;
        public string _tenBacLuongCoBan = string.Empty;
        public string _tenNgachLuongBaoHiem = string.Empty;
        public string _tenBacLuongBaoHiem = string.Empty;
        private string _maQLNhanVien = string.Empty;
        private string _cardID = string.Empty;
        private string _tenNhanVien = string.Empty;
        private string _ho = string.Empty;
        private string _ten = string.Empty;
        private int _maChucVu = 0;
        private string _tenChucVu = string.Empty;
        private int _maBoPhan = 0;
        private string _tenBoPhan = string.Empty;
        private bool _gioiTinh = false;
        private string _cmnd = string.Empty;
        DateTime _ngayDenHanNangLuong = DateTime.Today.Date;
        private SmartDate _ngayCap = new SmartDate(false);
        private int _maNoiCap = 0;
        private int _maKiemNhiem = 0;
        private string _tenKiemNhiem = string.Empty;
        private int _maChucDanh = 0;
        private SmartDate _ngaySinh = new SmartDate(DateTime.Today.Date);
        private Nullable<DateTime> _ngayTinhThamNien = null;
        private Nullable<DateTime> _mocLenLuong = null;
        private Nullable<DateTime> _mocLenLuongBaoHiem = null;
        private string _thangSinh = string.Empty;
        private string _namSinh = string.Empty;
        private bool _danhDauNamSinh = false;
        private int _maNoiSinh = 0;
        private int _maTinhThanhQueQuan = 0;
        private int _quocTich = 0;
        private int _maDanToc = 0;
        private int _maTonGiao = 0;
        private SmartDate _ngayVaoNganh = new SmartDate(DateTime.Today.Date);        
        private string _loaiSucKhoe = string.Empty;
        private string _chieuCao = string.Empty;
        private string _nhomMau = string.Empty;
        private string _canNang = string.Empty;
        private int _maUuTienGD = 0;
        private int _maUuTienBanThan = 0;
        private long _maNguoiLap = (long)ERP_Library.Security.CurrentUser.Info.UserID;
        private SmartDate _ngayLap = new SmartDate(DateTime.Today.Date);
        private string _soTaiKhoan = string.Empty;
        private int _maNganHang = 0;
        private byte _tinhTrang = 0;
        private byte[] _fileAnh;
        private int _loaiNV = 0;
        private int _maThanhPhanGD = 0;
        private int _maQuanHuyenNoiSinh = 0;
        private int _maQuanHuyenQueQuan = 0;
        private int _maCongViec = 0;
        private decimal _thangLuong = 0;
        private int _maThangLuong = 0;
        private int _tinhTrangHonNhan = 0;
        private int _maNgachLuongCoBan = 0;
        private int _maBacLuongCoBan = 0;
        private string _diaChiNhanVienTam = string.Empty;
        private string _ghiChuNhanVien = string.Empty;
        private string _diachiThT = string.Empty;
        private int _diachithtQuan = 0;
        private int _diachithtTinh = 0;
        private string _diachiTT = string.Empty;
        private int _diachittQuan = 0;
        private int _diachittTinh = 0;
        private string _dienthoaiThT = string.Empty;
        private string _dienthoaiTT = string.Empty;
        private string _theNhaBao = string.Empty;
        private string _maSoThue = string.Empty;
        private string _dungCuLaoDong = string.Empty;
        private short _cachTinhThueTNCN = 0;
        private decimal _heSoPhuCapChucVu = 0;
        private decimal _heSoLuongBoSung = 0;
        private string _email = string.Empty;
        private decimal _heSoVuotKhung = 0;
        private decimal _heSoVuotKhungBH = 0;
        private decimal _heSoBu = 0;
        private decimal _heSoDocHai = 0;
        private bool _phuCapHC = false;
        private decimal _heSoLuong = 0;
        private bool _traLuongQuaTK = false;
        private decimal _luongKhoan = 0;
        private int _maNhomNgachLuongCB = 0;
        private int _maDocHai = 0;
        private int _maNhomNgachLuongBaoHiem = 0;
        private int _maNgachLuongBaoHiem = 0;
        private int _maBacLuongBaoHiem = 0;
        private decimal _heSoLuongBaoHiem = 0;
        private decimal _heSoLuongNoiBo = 0;
        private bool _khongTinhLuong = false;
        private bool _khongTinhPhuCap = false;
        private bool _khongTinhThuLao = false;
        private bool _khongTinhBaoHiem = false;

        private long _maNhanVien = 0;
		//declare child member(s)
        private DiaChi_NhanVienList _diaChi_NhanVienList = DiaChi_NhanVienList.NewDiaChi_NhanVienList();
        private NhanVien_NgoaiNguList _ngoaiNgu_NhanVienList = NhanVien_NgoaiNguList.NewNhanVien_NgoaiNguList();
        private NhanVien_ChuyenNganhList _chuyenMon_NhanVienList = NhanVien_ChuyenNganhList.NewNhanVien_ChuyenNganhList();
        private NhanVien_ChungChiList _nhanVienChungChiList = NhanVien_ChungChiList.NewNhanVien_ChungChiList();
        private NhanVien_TrinhDoQuanLyList _trinhDoQL_NhanVienList = NhanVien_TrinhDoQuanLyList.NewNhanVien_TrinhDoQuanLyList();
		private NhanVien_DienThoai_FaxList _nhanVien_DienThoai_FaxList = NhanVien_DienThoai_FaxList.NewNhanVien_DienThoai_FaxList();		
		private QuaTrinhTGQDList _quaTrinhTGQDList = QuaTrinhTGQDList.NewQuaTrinhTGQDList();
		//private QuaTrinhSinhHoatDangList _quaTrinhSinhHoatDangList = QuaTrinhSinhHoatDangList.NewQuaTrinhSinhHoatDangList();
        private TrinhDoList _trinhDoList = TrinhDoList.NewTrinhDoList();
		//private QuanHeGiaDinhList _quanHeGiaDinhList = QuanHeGiaDinhList.NewQuanHeGiaDinhList();
        //private QuaTrinhLuanChuyenBoNhiemList _quaTrinhLuanChuyenBoNhiemList = QuaTrinhLuanChuyenBoNhiemList.NewQuaTrinhLuanChuyenBoNhiemList();
        private HoatDongXaHoiList _HoatDongXHList = HoatDongXaHoiList.NewHoatDongXaHoiList();
        private NhanVienGiaCanhList _NhanVienGiaCanhList = NhanVienGiaCanhList.NewNhanVienGiaCanhList();
        private NhanVien_EmailList _NhanVien_EmailList = NhanVien_EmailList.NewNhanVien_EmailList();
        private ThongTinKhacList _ThongTinKhacList = ThongTinKhacList.NewThongTinKhacList();
        private NhanVien_TaiKhoanNganHangList _nhanVien_TaiKhoanNganHangList = NhanVien_TaiKhoanNganHangList.NewNhanVien_TaiKhoanNganHangList();
        //private HoSoLuongList _HoSoLuongList = HoSoLuongList.NewHoSoLuongList();
        private bool _congDoan = false;
        #endregion members
        [System.ComponentModel.DataObjectField(true, true)]

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
        public string TenBacLuongBaoHiem
        {
            get
            {
                
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
        public string TenNgachLuongBaoHiem
        {
            get
            {
               
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
                    PropertyHasChanged("MaBacLuongBaoHiem");
                }
            }
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
                    PropertyHasChanged("MaNhomNgachLuongCB");
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
                    HeSoLuong = BacLuongCoBan.GetBacLuongCoBan(_maBacLuongCoBan).HeSoLuong;
                
                    PropertyHasChanged("MaBacLuongCoBan");
                }
            }
        }
        public string TenBacLuongCoBan
        {
            get
            {
                CanReadProperty("TenBacLuongCoBan", true);
                
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
            get 
            {
                CanReadProperty("HeSoLuongNoiBo", true);
                return _heSoLuongNoiBo; 
            }
            set 
            { 
                CanWriteProperty("HeSoLuongNoiBo", true);
                if (!_heSoLuongNoiBo.Equals(value))
                {

                    _heSoLuongNoiBo = value;
                    PropertyHasChanged("HeSoLuongNoiBo");
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
                    PropertyHasChanged("MaNhomNgachLuongBaoHiem");
                }
            }
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
                    PropertyHasChanged("MaNgachLuongBaoHiem");
                }
            }
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
        public short CachTinhThueTNCN
        {
            get
            {
                CanReadProperty("CachTinhThueTNCN", true);
                return _cachTinhThueTNCN;
            }
            set
            {
                CanWriteProperty("CachTinhThueTNCN", true);
                if (!_cachTinhThueTNCN.Equals(value))
                {
                    _cachTinhThueTNCN = value;
                    PropertyHasChanged("CachTinhThueTNCN");
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
        public string Email
        {
            get
            {
                CanReadProperty("Email", true);
                return _email;
            }
            set
            {
                CanWriteProperty("Email", true);
                if (value == null) value = string.Empty;
                if (!_email.Equals(value))
                {
                    _email = value;
                    PropertyHasChanged("Email");
                }
            }
        }
        public string DungCuLaoDong
        {
            get
            {
                CanReadProperty("DungCuLaoDong", true);
                return _dungCuLaoDong;
            }
            set
            {
                CanWriteProperty("DungCuLaoDong", true);
                if (value == null) value = string.Empty;
                if (!_dungCuLaoDong.Equals(value))
                {
                    _dungCuLaoDong = value;
                    PropertyHasChanged("DungCuLaoDong");
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
     

    

        public string DiachiThT
        {
            get
            {
                CanReadProperty("DiachiThT", true);
                return _diachiThT;
            }
            set
            {
                CanWriteProperty("DiachiThT", true);
                if (value == null) value = string.Empty;
                if (!_diachiThT.Equals(value))
                {
                    _diachiThT = value;
                    PropertyHasChanged("DiachiThT");
                }
            }
        }

        public int DiachiThT_Quan
        {
            get
            {
                CanReadProperty("DiachiThT_Quan", true);
                return _diachithtQuan;
            }
            set
            {
                CanWriteProperty("DiachiThT_Quan", true);
                if (!_diachithtQuan.Equals(value))
                {
                    _diachithtQuan = value;
                    PropertyHasChanged("DiachiThT_Quan");
                }
            }
        }

        public int DiachiThT_Tinh
        {
            get
            {
                CanReadProperty("DiachiThT_Tinh", true);
                return _diachithtTinh;
            }
            set
            {
                CanWriteProperty("DiachiThT_Tinh", true);
                if (!_diachithtTinh.Equals(value))
                {
                    _diachithtTinh = value;
                    PropertyHasChanged("DiachiThT_Tinh");
                }
            }
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

        public int DiachiTT_Quan
        {
            get
            {
                CanReadProperty("DiachiTT_Quan", true);
                return _diachittQuan;
            }
            set
            {
                CanWriteProperty("DiachiTT_Quan", true);
                if (!_diachittQuan.Equals(value))
                {
                    _diachittQuan = value;
                    PropertyHasChanged("DiachiTT_Quan");
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
                    PropertyHasChanged("DiachiTT_Tinh");
                }
            }
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

        public string HoNV
        {
            get
            {
                
                return _ho;
            }
            set
            {
                
                if (value == null) value = string.Empty;
                if (!_ho.Equals(value))
                {
                    _ho = value;
                   
                }
            }
        }

        public string TenNV
        {
            get
            {
                
                return _ten;
            }
            set
            {
                
                if (value == null) value = string.Empty;
                if (!_ten.Equals(value))
                {
                    _ten = value;
                    
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
        public bool TraLuongQuaTK
        {
            get
            {
                CanReadProperty("TraLuongQuaTK", true);
                return _traLuongQuaTK;
            }
            set
            {
                CanWriteProperty("TraLuongQuaTK", true);
                if (!_traLuongQuaTK.Equals(value))
                {
                    _traLuongQuaTK = value;
                    PropertyHasChanged("TraLuongQuaTK");
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
       
        public Nullable<DateTime> NgayTinhThamNien
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

        public long  MaNguoiLap
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
                if (_ngayLap.Date.ToString() == "1/1/0001 12:00:00 AM")
                {
                    _ngayLap.Date = DateTime.Today;
                }
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

        public byte[] FileAnh
        {
            get
            {
                CanReadProperty("FileAnh", true);
                return _fileAnh;
            }
            set
            {
                CanWriteProperty("FileAnh", true);
                //if (!_fileAnh.Equals(value))
                //{
                    _fileAnh = value;
                    PropertyHasChanged("FileAnh");
                //}
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
                    //_cachTinhLuong = CongViec.GetCongViec(_maCongViec).
                    PropertyHasChanged("MaCongViec");
                }
            }
        }

        public decimal ThangLuong
        {
            get
            {
                CanReadProperty("ThangLuong", true);
                _thangLuong = ERP_Library.ThangLuong.GetThangLuong(_maChucVu, _maCongViec).Luong;
                _maThangLuong = ERP_Library.ThangLuong.GetThangLuong(_maChucVu, _maCongViec).MaThangLuong;
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

    
        public int TinhTrangHonNhan
        {
            get
            {
                CanReadProperty("TinhTrangHonNhan", true);
                return _tinhTrangHonNhan;
            }
            set
            {
                CanWriteProperty("TinhTrangHonNhan", true);
                if (!_tinhTrangHonNhan.Equals(value))
                {
                    _tinhTrangHonNhan = value;
                    PropertyHasChanged("TinhTrangHonNhan");
                }
            }
        }


        public string DiaChiNhanVienTam
        {
            get
            {
                CanReadProperty("DiaCHiTam", true);
                return _diaChiNhanVienTam;
            }
            set
            {
                CanWriteProperty("DiaCHiTam", true);
                if (value == null) value = string.Empty;
                if (!_diaChiNhanVienTam.Equals(value))
                {
                    _diaChiNhanVienTam = value;
                    PropertyHasChanged("DiaCHiTam");
                }
            }
        }
        public bool KhongTinhLuong
        {
            get
            {
                CanReadProperty("KhongTinhLuong", true);
                return _khongTinhLuong;
            }
            set
            {
                CanWriteProperty("KhongTinhLuong", true);
                if (!_khongTinhLuong.Equals(value))
                {
                    _khongTinhLuong = value;
                    PropertyHasChanged("KhongTinhLuong");
                }
            }
        }
        public bool KhongTinhPhuCap
        {
            get
            {
                CanReadProperty("KhongTinhPhuCap", true);
                return _khongTinhPhuCap;
            }
            set
            {
                CanWriteProperty("KhongTinhPhuCap", true);
                if (!_khongTinhPhuCap.Equals(value))
                {
                    _khongTinhPhuCap = value;
                    PropertyHasChanged("KhongTinhPhuCap");
                }
            }
        }
        public bool KhongTinhThuLao
        {
            get
            {
                CanReadProperty("KhongTinhThuLao", true);
                return _khongTinhThuLao;
            }
            set
            {
                CanWriteProperty("KhongTinhThuLao", true);
                if (!_khongTinhThuLao.Equals(value))
                {
                    _khongTinhThuLao = value;
                    PropertyHasChanged("KhongTinhThuLao");
                }
            }
        }

        public bool KhongTinhBaoHiem
        {
            get
            {
                CanReadProperty("KhongTinhBaoHiem", true);
                return _khongTinhBaoHiem;
            }
            set
            {
                CanWriteProperty("KhongTinhBaoHiem", true);
                if (!_khongTinhBaoHiem.Equals(value))
                {
                    _khongTinhBaoHiem = value;
                    PropertyHasChanged("KhongTinhBaoHiem");
                }
            }
        }
        public string GhiChu
        {
            get
            {
                CanReadProperty("GhiChu", true);
                return _ghiChuNhanVien;
            }
            set
            {
                CanWriteProperty("GhiChu", true);
                if (value == null) value = string.Empty;
                if (!_ghiChuNhanVien.Equals(value))
                {
                    _ghiChuNhanVien = value;
                    PropertyHasChanged("GhiChu");
                }
            }
        }
        public DateTime NgayDenHanNangLuong
        {
            get { return _ngayDenHanNangLuong; }
            set { _ngayDenHanNangLuong = value; }
        }
		public DiaChi_NhanVienList DiaChi_NhanVienList
		{
			get
			{
				CanReadProperty("DiaChi_NhanVienList", true);
				return _diaChi_NhanVienList;
			}
            set
            {
                CanWriteProperty("DiaChi_NhanVienList", true);
                if (!_diaChi_NhanVienList.Equals(value))
                {
                    _diaChi_NhanVienList = value;
                    PropertyHasChanged("DiaChi_NhanVienList");
                }
            }
		}

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
        public NhanVien_ChuyenNganhList NhanVienChuyenNganhList
        {
            get
            {
                CanReadProperty("NhanVienChuyenNganhList", true);
                return _chuyenMon_NhanVienList;
            }
            set
            {
                CanWriteProperty("NhanVienChuyenNganhList", true);
                if (!_chuyenMon_NhanVienList.Equals(value))
                {
                    _chuyenMon_NhanVienList = value;
                    PropertyHasChanged("NhanVienChuyenNganhList");
                }
            }
        }
        public NhanVien_ChungChiList NhanVienChungChiList
        {
            get
            {
                CanReadProperty("NhanVienChungChiList", true);
                return _nhanVienChungChiList;
            }
            set
            {
                CanWriteProperty("NhanVienChungChiList", true);
                if (!_nhanVienChungChiList.Equals(value))
                {
                    _nhanVienChungChiList = value;
                    PropertyHasChanged("NhanVienChungChiList");
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
		public NhanVien_DienThoai_FaxList NhanVien_DienThoai_FaxList
		{
			get
			{
				CanReadProperty("NhanVien_DienThoai_FaxList", true);
				return _nhanVien_DienThoai_FaxList;
			}
            set
            {
                CanWriteProperty("NhanVien_DienThoai_FaxList", true);
                if (!_nhanVien_DienThoai_FaxList.Equals(value))
                {
                    _nhanVien_DienThoai_FaxList = value;
                    PropertyHasChanged("NhanVien_DienThoai_FaxList");
                }
            }
		}

        public QuaTrinhTGQDList QuaTrinhTGQDList
        {
            get
            {
                CanReadProperty("QuaTrinhTGQDList", true);
                return _quaTrinhTGQDList;
            }
            set
            {
                CanWriteProperty("QuaTrinhTGQDList", true);
                if (!_quaTrinhTGQDList.Equals(value))
                {
                    _quaTrinhTGQDList = value;
                    PropertyHasChanged("QuaTrinhTGQDList");
                }
            }
        }

        //public QuaTrinhSinhHoatDangList QuaTrinhSinhHoatDangList
        //{
        //    get
        //    {
        //        CanReadProperty("QuaTrinhSinhHoatDangList", true);
        //        return _quaTrinhSinhHoatDangList;
        //    }
        //}

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

        //public QuanHeGiaDinhList QuanHeGiaDinhList
        //{
        //    get
        //    {
        //        CanReadProperty("QuanHeGiaDinhList", true);
        //        return _quanHeGiaDinhList;
        //    }
        //}

        //public QuaTrinhLuanChuyenBoNhiemList QuaTrinhLuanChuyenBoNhiemList
        //{
        //    get
        //    {
        //        CanReadProperty("QuaTrinhLuanChuyenBoNhiemList", true);
        //        return _quaTrinhLuanChuyenBoNhiemList;
        //    }
        //}

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

        public NhanVien_TaiKhoanNganHangList NhanVienTaiKhoanNganHangList
        {
            get
            {
                CanReadProperty("NhanVienTaiKhoanNganHangList", true);
                
                return _nhanVien_TaiKhoanNganHangList;
            }
            set
            {
                CanWriteProperty("NhanVienTaiKhoanNganHangList", true);
                if (!_nhanVien_TaiKhoanNganHangList.Equals(value))
                {
                    _nhanVien_TaiKhoanNganHangList = value;
                   
                    PropertyHasChanged("NhanVienTaiKhoanNganHangList");
                }
            }

        }

        public NhanVien_EmailList NhanVien_EmailList
        {
            get
            {
                CanReadProperty("NhanVien_EmailList", true);
                return _NhanVien_EmailList;
            }
            set
            {
                CanWriteProperty("NhanVien_EmailList", true);
                if (!_NhanVien_EmailList.Equals(value))
                {
                    _NhanVien_EmailList = value;
                    PropertyHasChanged("NhanVien_EmailList");
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

        public override bool IsValid
        {
            get { return base.IsValid || _diaChi_NhanVienList.IsValid || _nhanVien_DienThoai_FaxList.IsValid || _quaTrinhTGQDList.IsValid || _trinhDoList.IsValid || _HoatDongXHList.IsValid || _NhanVien_EmailList.IsValid || _ThongTinKhacList.IsValid || _ngoaiNgu_NhanVienList.IsValid || _trinhDoQL_NhanVienList.IsValid || _chuyenMon_NhanVienList.IsValid; }
        }

        public override bool IsDirty
        {
            get { return base.IsDirty || _diaChi_NhanVienList.IsDirty || _nhanVien_DienThoai_FaxList.IsDirty || _quaTrinhTGQDList.IsDirty || _trinhDoList.IsDirty || _HoatDongXHList.IsDirty || _NhanVien_EmailList.IsDirty || _ThongTinKhacList.IsDirty || _ngoaiNgu_NhanVienList.IsDirty || _trinhDoQL_NhanVienList.IsDirty||_chuyenMon_NhanVienList.IsDirty; }
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
     
        }


        public static bool CanGetObject()
        {           
            return true;            
        }

        public static bool CanAddObject()
        {        
            return true;          
        }

        public static bool CanEditObject()
        {            
            return true;
        }

        public static bool CanDeleteObject()
        {          
            return true;           
        }

        public static int KiemTraMaNV(string maNV)
        {
            int gt = 0;
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                try
                {
                    using (SqlCommand cm = cn.CreateCommand())
                    {
                        cm.CommandType = CommandType.StoredProcedure;
                        cm.CommandText = "spd_KiemTraMaNhanVien";
                        cm.Parameters.AddWithValue("@maNV", maNV);                      
                        cm.Parameters.AddWithValue("@GiaTri", gt);
                        cm.Parameters["@GiaTri"].Direction = ParameterDirection.Output;

                        cm.ExecuteNonQuery();
                        gt = (int)cm.Parameters["@GiaTri"].Value;
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return gt;
            }//using
        }

        public static int KiemTraCardID(string cardID)
        {
            int gt = 0;
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                try
                {
                    using (SqlCommand cm = cn.CreateCommand())
                    {
                        cm.CommandType = CommandType.StoredProcedure;
                        cm.CommandText = "spd_KiemTraCardID";
                        cm.Parameters.AddWithValue("@cardID", cardID);
                        cm.Parameters.AddWithValue("@GiaTri", gt);
                        cm.Parameters["@GiaTri"].Direction = ParameterDirection.Output;

                        cm.ExecuteNonQuery();
                        gt = (int)cm.Parameters["@GiaTri"].Value;
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return gt;
            }//using
        }
        #endregion //Authorization Rulesss

		#region Factory Methods
		public NhanVien()
		{ /* require use of factory method */ }
        public NhanVien(string tenNhanVien)
        {
            
            this.TenNhanVien=tenNhanVien;
        }

        public static bool KiemTraNguoiPhuThuoc(NhanVien nhanVien)
        {

            for (int i = 0; i < nhanVien.NhanVienGiaCanhList.Count; i++)
            {
                string cmnd = QuanHeGiaDinh.GetQuanHeGiaDinh(nhanVien.NhanVienGiaCanhList[i].MaQuanHeGiaDinh).Cmnd;
                int kiemTra = NhanVienGiaCanh.KiemTraCMND_GiaCanhDuyNhat(cmnd, nhanVien.MaNhanVien);
                if (kiemTra > 0)
                {
                    MessageBox.Show(QuanHeGiaDinh.GetQuanHeGiaDinh(nhanVien.NhanVienGiaCanhList[i].MaQuanHeGiaDinh).HoTenNguoiThan.ToString() + " đã được khai báo người phụ thuộc, Xin vui lòng kiểm tra lại CMND.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                if (NhanVienGiaCanh.KiemTraHoChieu_GiaCanhDuyNhat(QuanHeGiaDinh.GetQuanHeGiaDinh(nhanVien.NhanVienGiaCanhList[i].MaQuanHeGiaDinh).HoChieu, nhanVien.MaNhanVien) > 0)
                {
                    MessageBox.Show(QuanHeGiaDinh.GetQuanHeGiaDinh(nhanVien.NhanVienGiaCanhList[i].MaQuanHeGiaDinh).HoTenNguoiThan.ToString() + " đã được khai báo người phụ thuộc, Xin vui lòng kiểm tra lại Hộ Chiếu.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }

            return true;
        }
        public static NhanVien NewNhanVien()
        {
            NhanVien nv = new NhanVien();
            DiaChi_NhanVien diaChi = DiaChi_NhanVien.NewDiaChi_NhanVien();
            nv.DiaChi_NhanVienList.Add(diaChi);
            HoatDongXaHoi hdxh = HoatDongXaHoi.NewHoatDongXaHoi();
            nv.HoatDongXHList.Add(hdxh);
            NhanVien_DienThoai_Fax fax = NhanVien_DienThoai_Fax.NewNhanVien_DienThoai_Fax();
            nv.NhanVien_DienThoai_FaxList.Add(fax);
            NhanVien_ChungChi chungChi = NhanVien_ChungChi.NewNhanVien_ChungChi();
            nv.NhanVienChungChiList.Add(chungChi);
            NhanVien_ChuyenNganh chuyenNganh = NhanVien_ChuyenNganh.NewNhanVien_ChuyenNganh();
            nv.NhanVienChuyenNganhList.Add(chuyenNganh);
          //  NhanVienGiaCanh giaCanh = NhanVienGiaCanh.NewNhanVienGiaCanh();
           // nv.NhanVienGiaCanhList.Add(giaCanh);
            NhanVien_NgoaiNgu ngoaiNgu = NhanVien_NgoaiNgu.NewNhanVien_NgoaiNgu();
            nv.NhanVienNgoaiNguList.Add(ngoaiNgu);
            //NhanVien_TaiKhoanNganHang taiKhoan = NhanVien_TaiKhoanNganHang.NewNhanVien_TaiKhoanNganHang();
            //nv.NhanVienTaiKhoanNganHangList.Add(taiKhoan);
            NhanVien_TrinhDoQuanLy quanLy = NhanVien_TrinhDoQuanLy.NewNhanVien_TrinhDoQuanLy();
            nv.NhanVienTrinhDoQuanLyList.Add(quanLy);
            ThongTinKhac ttKhac = ThongTinKhac.NewThongTinKhac();
            nv.ThongTinKhacList.Add(ttKhac);
            TrinhDo td = TrinhDo.NewTrinhDo();
            nv.TrinhDoList.Add(td);
            QuaTrinhTGQD tgqd = QuaTrinhTGQD.NewQuaTrinhTGQD();
            nv.QuaTrinhTGQDList.Add(tgqd);
            NhanVien_Email email = NhanVien_Email.NewNhanVien_Email();
            nv.NhanVien_EmailList.Add(email);


            return nv;
            //if (!CanAddObject())
            //    throw new System.Security.SecurityException("User not authorized to add a NhanVien");
            //return DataPortal.Create<NhanVien>(new CriteriaAll());
        }
        public static NhanVien NewNhanVien(long maNhanVien,string TenNhanVien)
        {
            return new NhanVien(TenNhanVien);
        }
		public static NhanVien GetNhanVien(long maNhanVien)
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException("User not authorized to view a NhanVien");
			return DataPortal.Fetch<NhanVien>(new Criteria(maNhanVien));
		}

        public static NhanVien GetNhanVien_IsDirty(long maNhanVien)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a NhanVien");
            return DataPortal.Fetch<NhanVien>(new Criteria_Isdirty(maNhanVien));
        }
      
        public static NhanVien GetNhanVienByMaQL(string maQLNhanVien)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a NhanVien");
            return DataPortal.Fetch<NhanVien>(new CriteriaByMaQL(maQLNhanVien));
        }

        public static NhanVien GetNhanVien_ByCMND(string CMND)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a NhanVien");
            return DataPortal.Fetch<NhanVien>(new CriteriaByCMND(CMND));
        }

		public static void DeleteNhanVien(long maNhanVien)
		{
			if (!CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a NhanVien");
			DataPortal.Delete(new Criteria(maNhanVien));
		}

		public override NhanVien Save()
		{
			if (IsDeleted && !CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a NhanVien");
			else if (IsNew && !CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a NhanVien");
			else if (!CanEditObject())
				throw new System.Security.SecurityException("User not authorized to update a NhanVien");

			return base.Save();
		}
        public static int KiemTraTheNhaBaoDuyNhat(string TheNhaBao,long MaNhanVien)
        {
            int gt = 0;
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                try
                {
                    using (SqlCommand cm = cn.CreateCommand())
                    {
                        cm.CommandType = CommandType.StoredProcedure;
                        cm.CommandText = "spd_KiemTraTheNhaBaoDuyNhat";
                        if (TheNhaBao.Length > 0)
                            cm.Parameters.AddWithValue("@TheNhaBao", TheNhaBao);
                        else
                            cm.Parameters.AddWithValue("@TheNhaBao", DBNull.Value);
                        
                            cm.Parameters.AddWithValue("@MaNhanVien", MaNhanVien);
                     
                        cm.Parameters.AddWithValue("@GiaTri", gt);
                        cm.Parameters["@GiaTri"].Direction = ParameterDirection.Output;

                        cm.ExecuteNonQuery();
                        gt = (int)cm.Parameters["@GiaTri"].Value;

                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return gt;
            }//using
        }
        public static int KiemTraCardIDDuyNhat(string CardID,long MaNhanVien)
        {
            int gt = 0;
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                try
                {
                    using (SqlCommand cm = cn.CreateCommand())
                    {
                        cm.CommandType = CommandType.StoredProcedure;
                        cm.CommandText = "spd_KiemTraCardIDDuyNhat";
                        if (CardID.Length > 0)
                            cm.Parameters.AddWithValue("@CardID", CardID);
                        else
                            cm.Parameters.AddWithValue("@CardID", DBNull.Value);
                       
                            cm.Parameters.AddWithValue("@MaNhanVien", MaNhanVien);
                     
                        cm.Parameters.AddWithValue("@GiaTri", gt);
                        cm.Parameters["@GiaTri"].Direction = ParameterDirection.Output;

                        cm.ExecuteNonQuery();
                        gt = (int)cm.Parameters["@GiaTri"].Value;

                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return gt;
            }//using
        }
        public static int KiemTraMaSoThueDuyNhat(string MaSoThue,long MaNhanVien)
        {
            int gt = 0;
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                try
                {
                    using (SqlCommand cm = cn.CreateCommand())
                    {
                        cm.CommandType = CommandType.StoredProcedure;
                        cm.CommandText = "spd_KiemTraMaSoThueDuyNhat";
                        if (MaSoThue.Length > 0)
                            cm.Parameters.AddWithValue("@MaSoThue", MaSoThue);
                        else
                            cm.Parameters.AddWithValue("@MaSoThue", DBNull.Value);
                        
                            cm.Parameters.AddWithValue("@MaNhanVien", MaNhanVien);
                       
                        cm.Parameters.AddWithValue("@GiaTri", gt);
                        cm.Parameters["@GiaTri"].Direction = ParameterDirection.Output;

                        cm.ExecuteNonQuery();
                        gt = (int)cm.Parameters["@GiaTri"].Value;

                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return gt;
            }//using
        }
        public static int KiemTraCMNDDuyNhat(string CMND,long MaNhanVien)
        {
            int gt = 0;
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                try
                {
                    using (SqlCommand cm = cn.CreateCommand())
                    {
                        cm.CommandType = CommandType.StoredProcedure;
                        cm.CommandText = "spd_KiemTraCMNDDuyNhat";
                        if (CMND.Length > 0)
                            cm.Parameters.AddWithValue("@CMND", CMND);
                        else
                            cm.Parameters.AddWithValue("@CMND", DBNull.Value);
                      
                            cm.Parameters.AddWithValue("@MaNhanVien", MaNhanVien);
                        
                        cm.Parameters.AddWithValue("@GiaTri", gt);
                        cm.Parameters["@GiaTri"].Direction = ParameterDirection.Output;

                        cm.ExecuteNonQuery();
                        gt = (int)cm.Parameters["@GiaTri"].Value;

                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return gt;
            }//using
        }
       	
		#endregion //Factory Methods

		#region Child Factory Methods
		internal static NhanVien NewNhanVienChild()
		{
			NhanVien child = new NhanVien();
			child.ValidationRules.CheckRules();
			child.MarkAsChild();
			return child;
		}

		internal static NhanVien GetNhanVien(SafeDataReader dr)
		{
			NhanVien child =  new NhanVien();
			child.MarkAsChild();
			child.Fetch(dr);
			return child;
		}
        internal static NhanVien GetNhanVienNotChild(SafeDataReader dr)
        {
            NhanVien child = new NhanVien();
            child.MarkAsChild();
            child.FetchNotChild(dr);
            return child;
        }
        internal static NhanVien GetNhanVienByDenHanNangLuong(SafeDataReader dr)
        {
            NhanVien child = new NhanVien();
            child.MarkAsChild();

            child.MaNhanVien = dr.GetInt64("MaNhanVien");
            child.TenBacLuongCoBan = dr.GetString("TenBacLuongCoBan");
            child.MaQLNhanVien = dr.GetString("MaQLNhanVien");
            child.TenNhanVien = dr.GetString("TenNhanVien");
            child.TenChucVu = dr.GetString("TenChucVu");
            child.TenBoPhan = dr.GetString("TenBoPhan");
            child.TenKiemNhiem = dr.GetString("TenKiemNhiem");
            child.LoaiNV = dr.GetInt32("LoaiNV");
            child.HeSoLuongBaoHiem = dr.GetDecimal("HeSoLuongBaoHiem");
            child.HeSoLuongBaoHiem = dr.GetDecimal("HeSoLuongBaoHiem");
            child.HeSoLuongBoSung = dr.GetDecimal("HeSoLuongBoSung");
            child.HeSoPhuCapChucVu = dr.GetDecimal("HeSoPhuCapChucVu");
            child.HeSoVuotKhung = dr.GetDecimal("HeSoVuotKhung");
            child.HeSoBu = dr.GetDecimal("HeSoBu");
            child.HeSoDocHai = dr.GetDecimal("HeSoDocHai");
            child.PhuCapHC = dr.GetBoolean("PhuCapHC");
            child.TenBacLuongBaoHiem = dr.GetString("MaQuanLy");
            child.MaNgachLuongBaoHiem = dr.GetInt32("MaNgachLuongBaoHiem");
            //child.TenNgachLuongBaoHiem = NgachLuongNoiBo.GetNgachLuongNoiBo(child.MaNgachLuongBaoHiem).TenNgachLuongBaoHiem;
            child.TenNgachLuongBaoHiem = dr.GetString("TenNgachLuongBaoHiem");
            child.HeSoLuong = dr.GetDecimal("HeSoLuong");
            child.LuongKhoan = dr.GetDecimal("LuongKhoan");
            child.NgayVaoNganh = dr.GetDateTime("NgayVaoNganh");
            child.NgayDenHanNangLuong = dr.GetDateTime("DenHanNangLuong");
            child.MaBacLuongCoBan = dr.GetInt32("MaBacLuongCoBan");
            child.MaNgachLuongCoBan = dr.GetInt32("MaNgachLuongCoBan");
            child.MaBacLuongBaoHiem = dr.GetInt32("MaBacLuongBaoHiem");           
            child.MaBoPhan = dr.GetInt32("MaBoPhan");
            child.MaChucVu = dr.GetInt32("MaChucVu");
            return child;
        }
        internal static NhanVien GetNhanVienByChuaCoSoBHXH(SafeDataReader dr)
        {
            NhanVien child = new NhanVien();
            child.MarkAsChild();
            child.MaNhanVien = dr.GetInt64("MaNhanVien");
            child.MaQLNhanVien = dr.GetString("MaQLNhanVien");
            child.TenNhanVien = dr.GetString("TenNhanVien");
            child.TenChucVu = dr.GetString("TenChucVu");
            child.TenBoPhan = dr.GetString("TenBoPhan");            
            child.LoaiNV = dr.GetInt32("LoaiNV");
            child.HeSoLuongBaoHiem = dr.GetDecimal("HeSoLuongBaoHiem");            
            child.HeSoPhuCapChucVu = dr.GetDecimal("HeSoPhuCapChucVu");
            child.HeSoVuotKhung = dr.GetDecimal("HeSoVuotKhung");            
            child.HeSoDocHai = dr.GetDecimal("HeSoDocHai");
            child.NgayVaoNganh = dr.GetDateTime("NgayVaoNganh");                       
            
            return child;
        }
        internal static NhanVien GetNhanVienByChuaCoTheBHYT(SafeDataReader dr)
        {
            NhanVien child = new NhanVien();
            child.MarkAsChild();
            child.MaNhanVien = dr.GetInt64("MaNhanVien");
            child.MaQLNhanVien = dr.GetString("MaQLNhanVien");
            child.TenNhanVien = dr.GetString("TenNhanVien");
            child.TenChucVu = dr.GetString("TenChucVu");
            child.TenBoPhan = dr.GetString("TenBoPhan");
            child.LoaiNV = dr.GetInt32("LoaiNV");
            child.HeSoLuongBaoHiem = dr.GetDecimal("HeSoLuongBaoHiem");
            child.HeSoPhuCapChucVu = dr.GetDecimal("HeSoPhuCapChucVu");
            child.HeSoVuotKhung = dr.GetDecimal("HeSoVuotKhung");
            child.HeSoDocHai = dr.GetDecimal("HeSoDocHai");
            child.NgayVaoNganh = dr.GetDateTime("NgayVaoNganh");

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

        [Serializable()]
        private class Criteria_Isdirty
        {
            public long MaNhanVien;

            public Criteria_Isdirty(long maNhanVien)
            {
                this.MaNhanVien = maNhanVien;
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

        private class CriteriaByCMND
        {
            //public long MaNhanVien;
            public string CMND;
            public CriteriaByCMND(string cmnd)
            {
                this.CMND = cmnd;
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
                else if (criteria is Criteria_Isdirty)
                {
                    cm.CommandText = "spd_SelecttblnsNhanVien";
                    cm.Parameters.AddWithValue("@MaNhanVien", ((Criteria_Isdirty)criteria).MaNhanVien);
                }
               
                else if (criteria is CriteriaByMaQL)
                {
                    cm.CommandText = "spd_SelecttblnsNhanVienByMaQL";
                    cm.Parameters.AddWithValue("@MaQLNhanVien", ((CriteriaByMaQL)criteria).maQLNV);
                }

                else if (criteria is CriteriaByCMND)
                {
                    cm.CommandText = "spd_SelecttblnsNhanVien_ByCMND";
                    cm.Parameters.AddWithValue("@CMND", ((CriteriaByCMND)criteria).CMND);
                }


				using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
				{
                    while (dr.Read())
                    {
                        FetchObject(dr);
                        if (criteria is Criteria_Isdirty)
                        {
                            MarkOld();
                        }
                        //ValidationRules.CheckRules();
                        //load child object(s)
                        FetchChildren(_maNhanVien);
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
				catch(Exception ex)
				{
					tr.Rollback();
					throw ex;
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
				catch(Exception ex)
				{
					tr.Rollback();
					throw ex;
				}
			}//using

		}
        public void Data_Update()
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
                catch (Exception ex)
                {
                    tr.Rollback();
                    throw ex;
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
			FetchChildren(_maNhanVien);
		}
        private void FetchNotChild(SafeDataReader dr)
        {
            FetchObject(dr);
            MarkOld();
            //ValidationRules.CheckRules();

            //load child object(s)
            //FetchChildren(_maNhanVien);
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
                _diachiThT = dr.GetString("DiachiThT");
                _diachithtQuan = dr.GetInt32("DiachiThT_Quan");
                _diachiThT = dr.GetString("DiachiThT");
                _diachiTT = dr.GetString("DiachiTT");
                _diachittQuan = dr.GetInt32("DiachiTT_Quan");
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
                //_ngayTinhThamNien = dr.GetSmartDate("NgayTinhThamNien", _ngayTinhThamNien.EmptyIsMin);
                object ngayTinhTT = dr.GetValue("NgayTinhThamNien");                
                if (ngayTinhTT != null)
                    _ngayTinhThamNien = (DateTime)ngayTinhTT;   
                else
                    _ngayTinhThamNien = null;

                object mocLenLuong = dr.GetValue("MocLenLuong");
                if (mocLenLuong != null)
                    _mocLenLuong = (DateTime)mocLenLuong;
                else
                    _mocLenLuong = null;
                object mocLenLuongBaoHiem = dr.GetValue("MocLenLuongBaoHiem");
                if (mocLenLuongBaoHiem != null)
                    _mocLenLuongBaoHiem = (DateTime)mocLenLuongBaoHiem;
                else
                    _mocLenLuongBaoHiem = null;
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
                _fileAnh = (byte[])dr["FileAnh"];
                _loaiNV = dr.GetInt32("LoaiNV");  
                _maThanhPhanGD = dr.GetInt32("MaThanhPhanGD");
                _maQuanHuyenNoiSinh = dr.GetInt32("MaQuanHuyenNoiSinh");
                _maQuanHuyenQueQuan = dr.GetInt32("MaQuanHuyenQueQuan");
                _maCongViec = dr.GetInt32("MaCongViec");
                _maThangLuong = dr.GetInt32("MaThangLuong");
                _thangLuong = dr.GetDecimal("ThangLuong");
                _tinhTrangHonNhan = dr.GetInt32("TinhTrangHonNhan");              
              
                _diaChiNhanVienTam = dr.GetString("DiachiNhanvienTam");
                _ghiChuNhanVien = dr.GetString("GhiChuNhanVien");
                _theNhaBao = dr.GetString("TheNhaBao");
                _maSoThue = dr.GetString("MaSoThue");
                _cachTinhThueTNCN = dr.GetInt16("CachTinhThueTNCN");
                _email = dr.GetString("Email");

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
              // _TenNgachLuongBaoHiem = dr.GetString("TenNgachLuongBaoHiem");
             //  _TenBacLuongBaoHiem = dr.GetString("TenBacLuongBaoHiem");
               _heSoVuotKhung = dr.GetDecimal("HeSoVuotKhung");
               _heSoVuotKhungBH = dr.GetDecimal("HeSoVuotKhungBH"); 
               _traLuongQuaTK = dr.GetBoolean("TraLuongQuaTK");
               _luongKhoan = dr.GetDecimal("LuongKhoan");
               _heSoLuongNoiBo = dr.GetDecimal("HeSoLuongNoiBo");
               _khongTinhLuong = dr.GetBoolean("KhongTinhLuong");
               _khongTinhPhuCap = dr.GetBoolean("KhongTinhPhuCap");
               _congDoan = dr.GetBoolean("CongDoan");
               _khongTinhThuLao = dr.GetBoolean("KhongTinhThuLao");
               _khongTinhBaoHiem = dr.GetBoolean("KhongTinhBaoHiem");
              
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

		private void FetchChildren(long maNhaVien)
		{
            if (DiaChi_NhanVienList.GetDiaChi_NhanVienList(maNhaVien).Count != 0)
            {
                _diaChi_NhanVienList = DiaChi_NhanVienList.GetDiaChi_NhanVienList(maNhaVien);
            }
            if (NhanVien_NgoaiNguList.GetNhanVien_NgoaiNguList(maNhaVien).Count!=0)
            {
                _ngoaiNgu_NhanVienList = NhanVien_NgoaiNguList.GetNhanVien_NgoaiNguList(_maNhanVien);
            }
            if (NhanVien_ChuyenNganhList.GetNhanVien_ChuyenNganhList(maNhaVien).Count != 0)
            {
                _chuyenMon_NhanVienList = NhanVien_ChuyenNganhList.GetNhanVien_ChuyenNganhList(maNhaVien);
            }
            if (NhanVien_ChungChiList.GetNhanVien_ChungChiList(maNhaVien).Count != 0)
            {
                _nhanVienChungChiList = NhanVien_ChungChiList.GetNhanVien_ChungChiList(maNhaVien);
            }
            if (NhanVien_TrinhDoQuanLyList.GetNhanVien_TrinhDoQuanLyList(maNhaVien).Count != 0)
            {
                _trinhDoQL_NhanVienList = NhanVien_TrinhDoQuanLyList.GetNhanVien_TrinhDoQuanLyList(maNhaVien);
            }
            if (NhanVien_DienThoai_FaxList.GetNhanVien_DienThoai_FaxList(maNhaVien).Count != 0)
            {
                _nhanVien_DienThoai_FaxList = NhanVien_DienThoai_FaxList.GetNhanVien_DienThoai_FaxList(maNhaVien);
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
            if (NhanVien_TaiKhoanNganHangList.GetNhanVien_TaiKhoanNganHangList(maNhaVien).Count != 0)
            {
                _nhanVien_TaiKhoanNganHangList = NhanVien_TaiKhoanNganHangList.GetNhanVien_TaiKhoanNganHangList(MaNhanVien);

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
            try
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
            catch (Exception ex)
            {
                throw ex;
            }
		}

        private void AddInsertParameters(SqlCommand cm)
        {
            cm.Parameters.AddWithValue("@LoaiDoiTuong", false);
            cm.Parameters.AddWithValue("@MaDoiTuong", _maNhanVien);
            cm.Parameters["@MaDoiTuong"].Direction = ParameterDirection.Output;

            if (_maQLNhanVien.Length > 0)
                cm.Parameters.AddWithValue("@MaQLNhanVien", _maQLNhanVien);
            else
                cm.Parameters.AddWithValue("@MaQLNhanVien", DBNull.Value);
            cm.Parameters.AddWithValue("@MaQLNhanVienCu", _maQLNhanVien);
            if (_cardID.Length > 0)
                cm.Parameters.AddWithValue("@CardID", _cardID);
            else
                cm.Parameters.AddWithValue("@CardID", DBNull.Value);
            if (_tenNhanVien.Length > 0)
                cm.Parameters.AddWithValue("@TenNhanVien", _tenNhanVien);
            else
                cm.Parameters.AddWithValue("@TenNhanVien", DBNull.Value);
            if (_ho.Length > 0)
                cm.Parameters.AddWithValue("@Ho", _ho);
            else
                cm.Parameters.AddWithValue("@Ho", DBNull.Value);
            if (_ten.Length > 0)
                cm.Parameters.AddWithValue("@Ten", _ten);
            else
                cm.Parameters.AddWithValue("@Ten", DBNull.Value);
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
           
                cm.Parameters.AddWithValue("@GioiTinh", _gioiTinh);
           
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
            cm.Parameters.AddWithValue("@Ngay_sinh", DBNull.Value);
            cm.Parameters.AddWithValue("@Thang_sinh", DBNull.Value);
            cm.Parameters.AddWithValue("@Nam_sinh", DBNull.Value);
            cm.Parameters.AddWithValue("@DanhDauNamSinh", DBNull.Value);
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
            if (_ngayTinhThamNien == null)
                cm.Parameters.AddWithValue("@NgayTinhThamNien", DBNull.Value);
            else
                cm.Parameters.AddWithValue("@NgayTinhThamNien", _ngayTinhThamNien);
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
            cm.Parameters.AddWithValue("@MaNguoiLap", ERP_Library.Security.CurrentUser.Info.UserID);

            cm.Parameters.AddWithValue("@NgayLap", DateTime.Today.Date);
            if (_soTaiKhoan.Length > 0)
                cm.Parameters.AddWithValue("@SoTaiKhoan", _soTaiKhoan);
            else
                cm.Parameters.AddWithValue("@SoTaiKhoan", DBNull.Value);
            if (_maNganHang != 0)
                cm.Parameters.AddWithValue("@MaNganHang", _maNganHang);
            else
                cm.Parameters.AddWithValue("@MaNganHang", DBNull.Value);
            if (_tinhTrang != 0)
                cm.Parameters.AddWithValue("@TinhTrang", _tinhTrang);
            else
                cm.Parameters.AddWithValue("@TinhTrang", 0);
            if (_fileAnh != null)
                cm.Parameters.AddWithValue("@FileAnh", _fileAnh);
            else
                cm.Parameters.AddWithValue("@FileAnh", new byte[0]);
            if (_loaiNV != 0)
                cm.Parameters.AddWithValue("@LoaiNV", _loaiNV);
            else
                cm.Parameters.AddWithValue("@LoaiNV", DBNull.Value);
            if (_maThanhPhanGD != 0)
                cm.Parameters.AddWithValue("@MaThanhPhanGD", _maThanhPhanGD);
            else
                cm.Parameters.AddWithValue("@MaThanhPhanGD", DBNull.Value);
            if (_maQuanHuyenNoiSinh != 0)
                cm.Parameters.AddWithValue("@MaQuanHuyenNoiSinh", _maQuanHuyenNoiSinh);
            else
                cm.Parameters.AddWithValue("@MaQuanHuyenNoiSinh", DBNull.Value);
            if (_maQuanHuyenQueQuan != 0)
                cm.Parameters.AddWithValue("@MaQuanHuyenQueQuan", _maQuanHuyenQueQuan);
            else
                cm.Parameters.AddWithValue("@MaQuanHuyenQueQuan", DBNull.Value);
            if (_maCongViec != 0)
                cm.Parameters.AddWithValue("@MaCongViec", _maCongViec);
            else
                cm.Parameters.AddWithValue("@MaCongViec", DBNull.Value);
            if (_thangLuong != 0)
                cm.Parameters.AddWithValue("@ThangLuong", _thangLuong);
            else
                cm.Parameters.AddWithValue("@ThangLuong", DBNull.Value);
            if (_maThangLuong != 0)
                cm.Parameters.AddWithValue("@MaThangLuong", _maThangLuong);
            else
                cm.Parameters.AddWithValue("@MaThangLuong", DBNull.Value);
            if (_tinhTrangHonNhan != 0)
                cm.Parameters.AddWithValue("@TinhTrangHonNhan", _tinhTrangHonNhan);
            else
                cm.Parameters.AddWithValue("@TinhTrangHonNhan", DBNull.Value);
            if (_maNgachLuongCoBan != 0)
                cm.Parameters.AddWithValue("@MaNgachLuongCoBan", _maNgachLuongCoBan);
            else
                cm.Parameters.AddWithValue("@MaNgachLuongCoBan", DBNull.Value);
            if (_maBacLuongCoBan != 0)
                cm.Parameters.AddWithValue("@MaBacLuongCoBan", _maBacLuongCoBan);
            else
                cm.Parameters.AddWithValue("@MaBacLuongCoBan", DBNull.Value);
            if (_diaChiNhanVienTam.Length > 0)
                cm.Parameters.AddWithValue("@DiaChiNhanVienTam", _diaChiNhanVienTam);
            else
                cm.Parameters.AddWithValue("@DiaChiNhanVienTam", DBNull.Value);
            if (_ghiChuNhanVien.Length > 0)
                cm.Parameters.AddWithValue("@GhiChuNhanVien", _ghiChuNhanVien);
            else
                cm.Parameters.AddWithValue("@GhiChuNhanVien", DBNull.Value);
            if (_diachiThT.Length > 0)
                cm.Parameters.AddWithValue("@DiachiThT", _diachiThT);
            else
                cm.Parameters.AddWithValue("@DiachiThT", DBNull.Value);
            if (_diachithtQuan != 0)
                cm.Parameters.AddWithValue("@DiachiThT_Quan", _diachithtQuan);
            else
                cm.Parameters.AddWithValue("@DiachiThT_Quan", DBNull.Value);
            if (_diachithtTinh != 0)
                cm.Parameters.AddWithValue("@DiachiThT_Tinh", _diachithtTinh);
            else
                cm.Parameters.AddWithValue("@DiachiThT_Tinh", DBNull.Value);
            if (_diachiTT.Length > 0)
                cm.Parameters.AddWithValue("@DiachiTT", _diachiTT);
            else
                cm.Parameters.AddWithValue("@DiachiTT", DBNull.Value);
            if (_diachittQuan != 0)
                cm.Parameters.AddWithValue("@DiachiTT_Quan", _diachittQuan);
            else
                cm.Parameters.AddWithValue("@DiachiTT_Quan", DBNull.Value);
            if (_diachittTinh != 0)
                cm.Parameters.AddWithValue("@DiachiTT_Tinh", _diachittTinh);
            else
                cm.Parameters.AddWithValue("@DiachiTT_Tinh", DBNull.Value);
            if (_dienthoaiThT.Length > 0)
                cm.Parameters.AddWithValue("@DienthoaiThT", _dienthoaiThT);
            else
                cm.Parameters.AddWithValue("@DienthoaiThT", DBNull.Value);
            if (_dienthoaiTT.Length > 0)
                cm.Parameters.AddWithValue("@DienthoaiTT", _dienthoaiTT);
            else
                cm.Parameters.AddWithValue("@DienthoaiTT", DBNull.Value);
            if (_theNhaBao.Length > 0)
                cm.Parameters.AddWithValue("@TheNhaBao", _theNhaBao);
            else
                cm.Parameters.AddWithValue("@TheNhaBao", DBNull.Value);
            if (_maSoThue.Length > 0)
                cm.Parameters.AddWithValue("@MaSoThue", _maSoThue);
            else
                cm.Parameters.AddWithValue("@MaSoThue", DBNull.Value);
            if (_dungCuLaoDong.Length > 0)
                cm.Parameters.AddWithValue("@DungCuLaoDong", _dungCuLaoDong);
            else
                cm.Parameters.AddWithValue("@DungCuLaoDong", DBNull.Value);

            cm.Parameters.AddWithValue("@CachTinhThueTNCN", _cachTinhThueTNCN);

            if (_heSoPhuCapChucVu != 0)
                cm.Parameters.AddWithValue("@HeSoPhuCapChucVu", _heSoPhuCapChucVu);
            else
                cm.Parameters.AddWithValue("@HeSoPhuCapChucVu", DBNull.Value);
            if (_heSoLuongBoSung != 0)
                cm.Parameters.AddWithValue("@HeSoLuongBoSung", _heSoLuongBoSung);
            else
                cm.Parameters.AddWithValue("@HeSoLuongBoSung", DBNull.Value);
            if (_email.Length > 0)
                cm.Parameters.AddWithValue("@Email", _email);
            else
                cm.Parameters.AddWithValue("@Email", DBNull.Value);
            if (_heSoVuotKhung != 0)
                cm.Parameters.AddWithValue("@HeSoVuotKhung", _heSoVuotKhung);
            else
                cm.Parameters.AddWithValue("@HeSoVuotKhung", DBNull.Value);
            if (_heSoVuotKhungBH != 0)
                cm.Parameters.AddWithValue("@HeSoVuotKhungBH", _heSoVuotKhungBH);
            else
                cm.Parameters.AddWithValue("@HeSoVuotKhungBH", DBNull.Value);
            if (_heSoBu != 0)
                cm.Parameters.AddWithValue("@HeSoBu", _heSoBu);
            else
                cm.Parameters.AddWithValue("@HeSoBu", DBNull.Value);
            if (_heSoDocHai != 0)
                cm.Parameters.AddWithValue("@HeSoDocHai", _heSoDocHai);
            else
                cm.Parameters.AddWithValue("@HeSoDocHai", DBNull.Value);
            if (_phuCapHC != false)
                cm.Parameters.AddWithValue("@PhuCapHC", _phuCapHC);
            else
                cm.Parameters.AddWithValue("@PhuCapHC", DBNull.Value);
            if (_heSoLuong != 0)
                cm.Parameters.AddWithValue("@HeSoLuong", _heSoLuong);
            else
                cm.Parameters.AddWithValue("@HeSoLuong", DBNull.Value);
        
                cm.Parameters.AddWithValue("@TraLuongQuaTK", _traLuongQuaTK);
      
            if (_luongKhoan != 0)
                cm.Parameters.AddWithValue("@LuongKhoan", _luongKhoan);
            else
                cm.Parameters.AddWithValue("@LuongKhoan", DBNull.Value);
            if (_maNhomNgachLuongCB != 0)
                cm.Parameters.AddWithValue("@MaNhomNgachLuongCB", _maNhomNgachLuongCB);
            else
                cm.Parameters.AddWithValue("@MaNhomNgachLuongCB", DBNull.Value);
            if (_maDocHai != 0)
                cm.Parameters.AddWithValue("@MaDocHai", _maDocHai);
            else
                cm.Parameters.AddWithValue("@MaDocHai", DBNull.Value);
            if (_maNhomNgachLuongBaoHiem != 0)
                cm.Parameters.AddWithValue("@MaNhomNgachLuongBaoHiem", _maNhomNgachLuongBaoHiem);
            else
                cm.Parameters.AddWithValue("@MaNhomNgachLuongBaoHiem", DBNull.Value);
            if (_maNgachLuongBaoHiem != 0)
                cm.Parameters.AddWithValue("@MaNgachLuongBaoHiem", _maNgachLuongBaoHiem);
            else
                cm.Parameters.AddWithValue("@MaNgachLuongBaoHiem", DBNull.Value);
            if (_maBacLuongBaoHiem != 0)
                cm.Parameters.AddWithValue("@MaBacLuongBaoHiem", _maBacLuongBaoHiem);
            else
                cm.Parameters.AddWithValue("@MaBacLuongBaoHiem", DBNull.Value);
            if (_heSoLuongBaoHiem != 0)
                cm.Parameters.AddWithValue("@HeSoLuongBaoHiem", _heSoLuongBaoHiem);
            else
                cm.Parameters.AddWithValue("@HeSoLuongBaoHiem", DBNull.Value);
            if (_heSoLuongNoiBo != 0)
                cm.Parameters.AddWithValue("@HeSoLuongNoiBo", _heSoLuongNoiBo);
            else
                cm.Parameters.AddWithValue("@HeSoLuongNoiBo", DBNull.Value);
            if (_mocLenLuong == null)
                cm.Parameters.AddWithValue("@MocLenLuong", DBNull.Value);
            else
                cm.Parameters.AddWithValue("@MocLenLuong", _mocLenLuong);
            if (_mocLenLuongBaoHiem == null)
                cm.Parameters.AddWithValue("@MocLenLuongBaoHiem", DBNull.Value);
            else
                cm.Parameters.AddWithValue("@MocLenLuongBaoHiem", _mocLenLuongBaoHiem);
            if (_khongTinhLuong != false)
                cm.Parameters.AddWithValue("@KhongTinhLuong", _khongTinhLuong);
            else
                cm.Parameters.AddWithValue("@KhongTinhLuong", DBNull.Value);
            if (_khongTinhPhuCap != false)
                cm.Parameters.AddWithValue("@KhongTinhPhuCap", _khongTinhPhuCap);
            else
                cm.Parameters.AddWithValue("@KhongTinhPhuCap", DBNull.Value);
            cm.Parameters.AddWithValue("@NguoiSua", Security.CurrentUser.Info.UserID);
            cm.Parameters.AddWithValue("@CongDoan", _congDoan);
            if (_khongTinhThuLao != false)
                cm.Parameters.AddWithValue("@KhongTinhThuLao", _khongTinhThuLao);
            else
                cm.Parameters.AddWithValue("@KhongTinhThuLao", DBNull.Value);
            if (_khongTinhBaoHiem != false)
                cm.Parameters.AddWithValue("@KhongTinhBaoHiem", _khongTinhBaoHiem);
            else
                cm.Parameters.AddWithValue("@KhongTinhBaoHiem", DBNull.Value);
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
            try
            {
                using (SqlCommand cm = tr.Connection.CreateCommand())
                {
                    int maBoPhan = NhanVien.GetNhanVien(_maNhanVien).MaBoPhan;

                    NhanVien nv = NhanVien.GetNhanVien(_maNhanVien);
                   
                    cm.Transaction = tr;
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_UpdatetblnsNhanVien";
                    AddUpdateParameters(cm);
                    cm.ExecuteNonQuery();

                  

                }//using
            }
            catch (Exception ex)
            {
                throw ex;
            }
		}

        private void AddUpdateParameters(SqlCommand cm)
        {
            cm.Parameters.AddWithValue("@MaNhanVien", _maNhanVien);
            cm.Parameters.AddWithValue("@MaQLNhanVienCu", _maQLNhanVien);
            if (_maQLNhanVien.Length > 0)
                cm.Parameters.AddWithValue("@MaQLNhanVien", _maQLNhanVien);
            else
                cm.Parameters.AddWithValue("@MaQLNhanVien", DBNull.Value);
            if (_cardID.Length > 0)
                cm.Parameters.AddWithValue("@CardID", _cardID);
            else
                cm.Parameters.AddWithValue("@CardID", DBNull.Value);
            if (_tenNhanVien.Length > 0)
                cm.Parameters.AddWithValue("@TenNhanVien", _tenNhanVien);
            else
                cm.Parameters.AddWithValue("@TenNhanVien", DBNull.Value);
            if (_ho.Length > 0)
                cm.Parameters.AddWithValue("@Ho", _ho);
            else
                cm.Parameters.AddWithValue("@Ho", DBNull.Value);
            if (_ten.Length > 0)
                cm.Parameters.AddWithValue("@Ten", _ten);
            else
                cm.Parameters.AddWithValue("@Ten", DBNull.Value);
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
            
                cm.Parameters.AddWithValue("@GioiTinh", _gioiTinh);
           
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
            cm.Parameters.AddWithValue("@Ngay_sinh", DBNull.Value);
            cm.Parameters.AddWithValue("@Thang_sinh", DBNull.Value);
            cm.Parameters.AddWithValue("@Nam_sinh", DBNull.Value);
            cm.Parameters.AddWithValue("@DanhDauNamSinh", DBNull.Value);
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
            if(_ngayTinhThamNien==null)
                cm.Parameters.AddWithValue("@NgayTinhThamNien",DBNull.Value);
            else
            cm.Parameters.AddWithValue("@NgayTinhThamNien", _ngayTinhThamNien);
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
            
                cm.Parameters.AddWithValue("@MaNguoiLap", ERP_Library.Security.CurrentUser.Info.UserID);
            
            cm.Parameters.AddWithValue("@NgayLap", DateTime.Today.Date);
            if (_soTaiKhoan.Length > 0)
                cm.Parameters.AddWithValue("@SoTaiKhoan", _soTaiKhoan);
            else
                cm.Parameters.AddWithValue("@SoTaiKhoan", DBNull.Value);
            if (_maNganHang != 0)
                cm.Parameters.AddWithValue("@MaNganHang", _maNganHang);
            else
                cm.Parameters.AddWithValue("@MaNganHang", DBNull.Value);
            
            if (_fileAnh != null)
                cm.Parameters.AddWithValue("@FileAnh", _fileAnh);
            else
                cm.Parameters.AddWithValue("@FileAnh", new byte[0]);
            if (_loaiNV != 0)
                cm.Parameters.AddWithValue("@LoaiNV", _loaiNV);
            else
                cm.Parameters.AddWithValue("@LoaiNV", DBNull.Value);
            if (_maThanhPhanGD != 0)
                cm.Parameters.AddWithValue("@MaThanhPhanGD", _maThanhPhanGD);
            else
                cm.Parameters.AddWithValue("@MaThanhPhanGD", DBNull.Value);
            if (_maQuanHuyenNoiSinh != 0)
                cm.Parameters.AddWithValue("@MaQuanHuyenNoiSinh", _maQuanHuyenNoiSinh);
            else
                cm.Parameters.AddWithValue("@MaQuanHuyenNoiSinh", DBNull.Value);
            if (_maQuanHuyenQueQuan != 0)
                cm.Parameters.AddWithValue("@MaQuanHuyenQueQuan", _maQuanHuyenQueQuan);
            else
                cm.Parameters.AddWithValue("@MaQuanHuyenQueQuan", DBNull.Value);
            if (_maCongViec != 0)
                cm.Parameters.AddWithValue("@MaCongViec", _maCongViec);
            else
                cm.Parameters.AddWithValue("@MaCongViec", DBNull.Value);
            if (_thangLuong != 0)
                cm.Parameters.AddWithValue("@ThangLuong", _thangLuong);
            else
                cm.Parameters.AddWithValue("@ThangLuong", DBNull.Value);
            if (_maThangLuong != 0)
                cm.Parameters.AddWithValue("@MaThangLuong", _maThangLuong);
            else
                cm.Parameters.AddWithValue("@MaThangLuong", DBNull.Value);
            if (_tinhTrangHonNhan != 0)
                cm.Parameters.AddWithValue("@TinhTrangHonNhan", _tinhTrangHonNhan);
            else
                cm.Parameters.AddWithValue("@TinhTrangHonNhan", DBNull.Value);
            if (_maNgachLuongCoBan != 0)
                cm.Parameters.AddWithValue("@MaNgachLuongCoBan", _maNgachLuongCoBan);
            else
                cm.Parameters.AddWithValue("@MaNgachLuongCoBan", DBNull.Value);
            if (_maBacLuongCoBan != 0)
                cm.Parameters.AddWithValue("@MaBacLuongCoBan", _maBacLuongCoBan);
            else
                cm.Parameters.AddWithValue("@MaBacLuongCoBan", DBNull.Value);
            if (_diaChiNhanVienTam.Length > 0)
                cm.Parameters.AddWithValue("@DiaChiNhanVienTam", _diaChiNhanVienTam);
            else
                cm.Parameters.AddWithValue("@DiaChiNhanVienTam", DBNull.Value);
            if (_ghiChuNhanVien.Length > 0)
                cm.Parameters.AddWithValue("@GhiChuNhanVien", _ghiChuNhanVien);
            else
                cm.Parameters.AddWithValue("@GhiChuNhanVien", DBNull.Value);
            if (_diachiThT.Length > 0)
                cm.Parameters.AddWithValue("@DiachiThT", _diachiThT);
            else
                cm.Parameters.AddWithValue("@DiachiThT", DBNull.Value);
            if (_diachithtQuan != 0)
                cm.Parameters.AddWithValue("@DiachiThT_Quan", _diachithtQuan);
            else
                cm.Parameters.AddWithValue("@DiachiThT_Quan", DBNull.Value);
            if (_diachithtTinh != 0)
                cm.Parameters.AddWithValue("@DiachiThT_Tinh", _diachithtTinh);
            else
                cm.Parameters.AddWithValue("@DiachiThT_Tinh", DBNull.Value);
            if (_diachiTT.Length > 0)
                cm.Parameters.AddWithValue("@DiachiTT", _diachiTT);
            else
                cm.Parameters.AddWithValue("@DiachiTT", DBNull.Value);
            if (_diachittQuan != 0)
                cm.Parameters.AddWithValue("@DiachiTT_Quan", _diachittQuan);
            else
                cm.Parameters.AddWithValue("@DiachiTT_Quan", DBNull.Value);
            if (_diachittTinh != 0)
                cm.Parameters.AddWithValue("@DiachiTT_Tinh", _diachittTinh);
            else
                cm.Parameters.AddWithValue("@DiachiTT_Tinh", DBNull.Value);
            if (_dienthoaiThT.Length > 0)
                cm.Parameters.AddWithValue("@DienthoaiThT", _dienthoaiThT);
            else
                cm.Parameters.AddWithValue("@DienthoaiThT", DBNull.Value);
            if (_dienthoaiTT.Length > 0)
                cm.Parameters.AddWithValue("@DienthoaiTT", _dienthoaiTT);
            else
                cm.Parameters.AddWithValue("@DienthoaiTT", DBNull.Value);
            if (_theNhaBao.Length > 0)
                cm.Parameters.AddWithValue("@TheNhaBao", _theNhaBao);
            else
                cm.Parameters.AddWithValue("@TheNhaBao", DBNull.Value);
            if (_maSoThue.Length > 0)
                cm.Parameters.AddWithValue("@MaSoThue", _maSoThue);
            else
                cm.Parameters.AddWithValue("@MaSoThue", DBNull.Value);
            if (_dungCuLaoDong.Length > 0)
                cm.Parameters.AddWithValue("@DungCuLaoDong", _dungCuLaoDong);
            else
                cm.Parameters.AddWithValue("@DungCuLaoDong", DBNull.Value);

            cm.Parameters.AddWithValue("@CachTinhThueTNCN", _cachTinhThueTNCN);

            if (_heSoPhuCapChucVu != 0)
                cm.Parameters.AddWithValue("@HeSoPhuCapChucVu", _heSoPhuCapChucVu);
            else
                cm.Parameters.AddWithValue("@HeSoPhuCapChucVu", DBNull.Value);
            if (_heSoLuongBoSung != 0)
                cm.Parameters.AddWithValue("@HeSoLuongBoSung", _heSoLuongBoSung);
            else
                cm.Parameters.AddWithValue("@HeSoLuongBoSung", DBNull.Value);
            if (_email.Length > 0)
                cm.Parameters.AddWithValue("@Email", _email);
            else
                cm.Parameters.AddWithValue("@Email", DBNull.Value);
            if (_heSoVuotKhung != 0)
                cm.Parameters.AddWithValue("@HeSoVuotKhung", _heSoVuotKhung);
            else
                cm.Parameters.AddWithValue("@HeSoVuotKhung", DBNull.Value);
            if (_heSoVuotKhungBH != 0)
                cm.Parameters.AddWithValue("@HeSoVuotKhungBH", _heSoVuotKhungBH);
            else
                cm.Parameters.AddWithValue("@HeSoVuotKhungBH", DBNull.Value);
            if (_heSoBu != 0)
                cm.Parameters.AddWithValue("@HeSoBu", _heSoBu);
            else
                cm.Parameters.AddWithValue("@HeSoBu", DBNull.Value);
            if (_heSoDocHai != 0)
                cm.Parameters.AddWithValue("@HeSoDocHai", _heSoDocHai);
            else
                cm.Parameters.AddWithValue("@HeSoDocHai", DBNull.Value);
            if (_phuCapHC != false)
                cm.Parameters.AddWithValue("@PhuCapHC", _phuCapHC);
            else
                cm.Parameters.AddWithValue("@PhuCapHC", DBNull.Value);
            if (_heSoLuong != 0)
                cm.Parameters.AddWithValue("@HeSoLuong", _heSoLuong);
            else
                cm.Parameters.AddWithValue("@HeSoLuong", DBNull.Value);
            
                cm.Parameters.AddWithValue("@TraLuongQuaTK", _traLuongQuaTK);
         
            if (_luongKhoan != 0)
                cm.Parameters.AddWithValue("@LuongKhoan", _luongKhoan);
            else
                cm.Parameters.AddWithValue("@LuongKhoan", DBNull.Value);
            if (_maNhomNgachLuongCB != 0)
                cm.Parameters.AddWithValue("@MaNhomNgachLuongCB", _maNhomNgachLuongCB);
            else
                cm.Parameters.AddWithValue("@MaNhomNgachLuongCB", DBNull.Value);
            if (_maDocHai != 0)
                cm.Parameters.AddWithValue("@MaDocHai", _maDocHai);
            else
                cm.Parameters.AddWithValue("@MaDocHai", DBNull.Value);
            if (_maNhomNgachLuongBaoHiem != 0)
                cm.Parameters.AddWithValue("@MaNhomNgachLuongBaoHiem", _maNhomNgachLuongBaoHiem);
            else
                cm.Parameters.AddWithValue("@MaNhomNgachLuongBaoHiem", DBNull.Value);
            if (_maNgachLuongBaoHiem != 0)
                cm.Parameters.AddWithValue("@MaNgachLuongBaoHiem", _maNgachLuongBaoHiem);
            else
                cm.Parameters.AddWithValue("@MaNgachLuongBaoHiem", DBNull.Value);
            if (_maBacLuongBaoHiem != 0)
                cm.Parameters.AddWithValue("@MaBacLuongBaoHiem", _maBacLuongBaoHiem);
            else
                cm.Parameters.AddWithValue("@MaBacLuongBaoHiem", DBNull.Value);
            if (_heSoLuongBaoHiem != 0)
                cm.Parameters.AddWithValue("@HeSoLuongBaoHiem", _heSoLuongBaoHiem);
            else
                cm.Parameters.AddWithValue("@HeSoLuongBaoHiem", DBNull.Value);
            if (_heSoLuongNoiBo != 0)
                cm.Parameters.AddWithValue("@HeSoLuongNoiBo", _heSoLuongNoiBo);
            else
                cm.Parameters.AddWithValue("@HeSoLuongNoiBo", DBNull.Value);
            if (_mocLenLuong == DateTime.MinValue || _mocLenLuong== null)
                cm.Parameters.AddWithValue("@MocLenLuong", DBNull.Value);
            else
                cm.Parameters.AddWithValue("@MocLenLuong", _mocLenLuong);
            if (_mocLenLuongBaoHiem == DateTime.MinValue || _mocLenLuongBaoHiem==null)
                cm.Parameters.AddWithValue("@MocLenLuongBaoHiem", DBNull.Value);
            else
                cm.Parameters.AddWithValue("@MocLenLuongBaoHiem", _mocLenLuongBaoHiem);
            if (_khongTinhLuong != false)
                cm.Parameters.AddWithValue("@KhongTinhLuong", _khongTinhLuong);
            else
                cm.Parameters.AddWithValue("@KhongTinhLuong", DBNull.Value);
            if (_khongTinhPhuCap != false)
                cm.Parameters.AddWithValue("@KhongTinhPhuCap", _khongTinhPhuCap);
            else
                cm.Parameters.AddWithValue("@KhongTinhPhuCap", DBNull.Value);
            cm.Parameters.AddWithValue("@NguoiSua", Security.CurrentUser.Info.UserID);
            cm.Parameters.AddWithValue("@CongDoan", _congDoan);
            if (_khongTinhThuLao != false)
                cm.Parameters.AddWithValue("@KhongTinhThuLao", _khongTinhThuLao);
            else
                cm.Parameters.AddWithValue("@KhongTinhThuLao", DBNull.Value);
            if (_khongTinhBaoHiem != false)
                cm.Parameters.AddWithValue("@KhongTinhBaoHiem", _khongTinhBaoHiem);
            else
                cm.Parameters.AddWithValue("@KhongTinhBaoHiem", DBNull.Value);
        }

     
		private void UpdateChildren(SqlTransaction tr)		
        {
			//_diaChi_NhanVienList.Update(tr, this);
			//_nhanVien_DienThoai_FaxList.Update(tr, this);			
			//_quaTrinhTGQDList.Update(tr, this);
		//	_quaTrinhSinhHoatDangList.Update(tr, this);
            _nhanVienChungChiList.Update(tr, this);
            _trinhDoList.Update(tr, this);
			//_quanHeGiaDinhList.Update(tr, this);
            _HoatDongXHList.Update(tr, this);
            _NhanVienGiaCanhList.Update(tr, this);
           // _NhanVien_EmailList.Update(tr, this);
            _ThongTinKhacList.Update(tr, this);
            //_HoSoLuongList.Update(tr, this);
            _ngoaiNgu_NhanVienList.Update(tr, this);
            _chuyenMon_NhanVienList.Update(tr, this);
            _trinhDoQL_NhanVienList.Update(tr, this);
            _nhanVien_TaiKhoanNganHangList.Update(tr, this);

		    }
		#endregion //Data Access - Update

		#region Data Access - Delete
		internal void DeleteSelf(SqlTransaction tr)
		{
			if (!IsDirty) return;
			if (IsNew) return;
            _nhanVienChungChiList.Clear();
            _ngoaiNgu_NhanVienList.Clear();
            _chuyenMon_NhanVienList.Clear();
            _diaChi_NhanVienList.Clear();
            _nhanVien_DienThoai_FaxList.Clear();            
            _quaTrinhTGQDList.Clear();
            //_quaTrinhSinhHoatDangList.Clear();
            _trinhDoList.Clear();
            //_quanHeGiaDinhList.Clear();
            //_quaTrinhLuanChuyenBoNhiemList.Clear();
            _HoatDongXHList.Clear();
            _ngoaiNgu_NhanVienList.Clear();
            _trinhDoQL_NhanVienList.Clear();
            _NhanVienGiaCanhList.Clear();
            _NhanVien_EmailList.Clear();
            _ThongTinKhacList.Clear();
            _nhanVien_TaiKhoanNganHangList.Clear();
            UpdateChildren(tr);

			ExecuteDelete(tr, new Criteria(_maNhanVien));
			//MarkNew();
		}
		#endregion //Data Access - Delete
		#endregion //Data Access

        public static string Laymasomoinhat()
        {
            string masomoi = "";
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {

                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_Selecttblnsnhanvien_Laymaqlmoinhat";
                    //masomoi = cm.ExecuteScalar().ToString();
                }
            }
            return masomoi;
        }
        public static void XoaNV(NhanVien nhanvien)
        {
            
           
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                
                cn.Open();
                
                using (SqlCommand cm = cn.CreateCommand())
                {
                    SqlTransaction trans;
                    trans = cn.BeginTransaction();
                    cm.Connection = cn;
                    cm.Transaction = trans;
                    try
                    {
                        cm.CommandType = CommandType.StoredProcedure;
                        cm.CommandText = "spd_DeletetblnsNhanVien";
                        cm.Parameters.AddWithValue("@MaNhanVien", nhanvien.MaNhanVien);
                        cm.ExecuteNonQuery();

                        trans.Commit();
                    }
                    catch (Exception ex)
                    {
                        trans.Rollback();
                        throw ex;
                    }

                }//using
            }
            
        }
	}
}
