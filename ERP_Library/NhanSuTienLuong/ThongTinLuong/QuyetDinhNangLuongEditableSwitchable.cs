
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;
//TT111
namespace ERP_Library
{ 
	[Serializable()] 
	public class QuyetDinhNangLuong : Csla.BusinessBase<QuyetDinhNangLuong>
	{
		#region Business Properties and Methods

		//declare members
        private int _maQuyetDinh = 0;
        private string _soQuyetDinh = string.Empty;
        private long _maNhanVien = 0;
        private int _maChucVu = 0;
        private string _tenChucVu = string.Empty;
        private int _maBoPhan = 0;
        private string _tenBoPhan = string.Empty;
        private string _maQLNhanVien = string.Empty;
        private int _maNhomBaoHiemNgach = 0;
        private int _maNgachBaoHiemCu = 0;
        private string _tenNgachBaoHiemCu = string.Empty;
        private int _maBacBaoHiemCu = 0;
        private decimal _heSoBaoHiemCu = 0;
        private string _tenBacBaoHiemCu = string.Empty;
        private int _maNgachBaoHiemMoi = 0;
        private string _tenNgachBaoHiemMoi = string.Empty;
        private int _maBacBaoHiemMoi = 0;
        private decimal _heSoBaoHiemMoi = 0;
        private string _tenBacBaoHiemMoi = string.Empty;
        private SmartDate _ngayHieuLuc = new SmartDate(DateTime.Today.Date);
        private SmartDate _mocThoiGianNangBac = new SmartDate(DateTime.Today.Date);
        private SmartDate _mocThoiGianNangBacMoi = new SmartDate(DateTime.Today.Date);
        private long _maNguoiLap = 0;
        private SmartDate _ngayLap = new SmartDate(DateTime.Today.Date);
        private decimal _hSPCCu = 0;
        private decimal _hSPCMoi = 0;
        private decimal _hSVKCu = 0;
        private decimal _hSVKMoi = 0;
        private decimal _hSVKBHCu = 0;
        private decimal _hSVKBHMoi = 0;
        private SmartDate _ngayDenHan = new SmartDate(DateTime.Today.Date);
        private SmartDate _ngayDenHanMoi = new SmartDate(DateTime.Today.Date);
        private int _thoiGiaNangBacCu = 0;
        private int _thoiGianNangBacMoi = 0;
        private int _maNgachCoBanCu = 0;
        private int _maBacLuongCoBanCu = 0;

        private int _maNhomNgachCoBan = 0;
        private int _maNgachLuongCoBanMoi = 0;
        private int _maBacLuongCoBanMoi = 0;
        private decimal _heSoLuongMoi = 0;
        private decimal _heSoLuongCu = 0;

        private string _tenNhanVien = string.Empty;
        private string _tenNgachCoBanCu = string.Empty;
        private string _tenBacCoBanCu = string.Empty;
        private string _tenBacCoBanMoi = string.Empty;
        private int _kieuNangLuong = 0;
       
        private string _tenNgachCoBanMoi = string.Empty;
        private decimal _HeSoNBCu = 0;
        private decimal _HeSoNBMoi = 0;
        private int _loaiNhanVienCu = 0;
        private int _loaiNhanVienMoi = 0;
        private bool _capNhatSau = false;
        private DateTime? _mocNangLuong = null;
        private DateTime? _mocNangLuongBH = null;
       

		[System.ComponentModel.DataObjectField(true, true)]
        public long MaNhanVien
        {
            get
            {
                CanReadProperty("MaNhanVien", true);
                _tenNhanVien = TTNhanVienRutGon.GetTTNhanVienRutGon(_maNhanVien).TenNhanVien;
                return _maNhanVien;
            }
            set
            {
                CanWriteProperty("MaNhanVien", true);
                if (!_maNhanVien.Equals(value))
                {
                    _maNhanVien = value;
                    NhanVien _nv = NhanVien.GetNhanVien(_maNhanVien);
                    _maChucVu = _nv.MaChucVu;
                    _tenChucVu = _nv.TenChucVu;
                    _maQLNhanVien = _nv.MaQLNhanVien;
                    _maBoPhan = _nv.MaBoPhan;
                    _tenBoPhan = _nv.TenBoPhan;                    
                    _hSVKCu = _nv.HeSoVuotKhung;
                    _maNhomBaoHiemNgach = _nv.MaNhomNgachLuongBaoHiem;
                    _maNgachBaoHiemCu = _nv.MaNgachLuongBaoHiem;                    
                    _maBacBaoHiemCu = _nv.MaBacLuongBaoHiem;
                    _tenNgachBaoHiemCu = NgachLuongCoBan.GetNgachLuongCoBan(_maNgachBaoHiemCu).TenNgachLuongCoBan;
                    _tenBacBaoHiemCu = BacLuongCoBan.GetBacLuongCoBan(_maBacBaoHiemCu).MaQuanLy;
                    _maNhomNgachCoBan = _nv.MaNhomNgachLuongCB;
                    _maNgachCoBanCu = _nv.MaNgachLuongCoBan;
                    _maBacLuongCoBanCu = _nv.MaBacLuongCoBan;
                    _tenNgachCoBanCu = NgachLuongCoBan.GetNgachLuongCoBan(_nv.MaNgachLuongCoBan).TenNgachLuongCoBan;
                    _tenBacCoBanCu = BacLuongCoBan.GetBacLuongCoBan(_nv.MaBacLuongCoBan).MaQuanLy;
                    _HeSoNBCu = _nv.HeSoLuongNoiBo;
                    _loaiNhanVienCu = _nv.LoaiNV;

                    _tenNhanVien = TTNhanVienRutGon.GetTTNhanVienRutGon(_maNhanVien).TenNhanVien;
                    PropertyHasChanged("MaNhanVien");

                }
            }
        }
        public string TenNhanVien
        {
            get
            {
                _tenNhanVien = TTNhanVienRutGon.GetTTNhanVienRutGon(_maNhanVien).TenNhanVien;
                return _tenNhanVien;
            }
            set { _tenNhanVien = value; }
        }
        public string TenBacCoBanCu
        {
            get
            {
                _tenBacCoBanCu = BacLuongCoBan.GetBacLuongCoBan(_maBacLuongCoBanCu).MaQuanLy;
                return _tenBacCoBanCu;
            }
            set { _tenBacCoBanCu = value; }
        }
        public string TenNgachCoBanCu
        {
            get { return _tenNgachCoBanCu; }
            set { _tenNgachCoBanCu = value; }
        }
      
        public DateTime NgayHieuLuc
        {
            get
            {
                CanReadProperty("NgayHieuLuc", true);
                return _ngayHieuLuc.Date;
            }
            set
            {
                CanWriteProperty("NgayHieuLuc", true);
                if (!_ngayHieuLuc.Equals(value))
                {
                    _ngayHieuLuc = new SmartDate(value);
                    PropertyHasChanged("NgayHieuLuc");
                }
            }
        }
        public string TenNgachCoBanMoi
        {
            get {
                _tenNgachCoBanMoi = NgachLuongCoBan.GetNgachLuongCoBan(_maNgachLuongCoBanMoi).TenNgachLuongCoBan;
                return _tenNgachCoBanMoi; 
            }
            set { _tenNgachCoBanMoi = value; }
        }
        public string TenBacCoBanMoi
        {
            get
            {
              //  _tenBacCoBanMoi = BacLuongCoBan.GetBacLuongCoBan(_maBacLuongCoBanMoi).MaQuanLy;
                return _tenBacCoBanMoi;
            }
            set { _tenBacCoBanMoi = value; }
        }
        public DateTime MocThoiGianNangBac
        {
            get
            {
                CanReadProperty("MocThoiGianNangBac", true);
                return _mocThoiGianNangBac.Date;
            }
            set
            {
                CanWriteProperty("NgayHieuLuc", true);
                if (!_mocThoiGianNangBac.Equals(value))
                {
                    _mocThoiGianNangBac = new SmartDate(value);
                    PropertyHasChanged("NgayHieuLuc");
                }
            }
        }

        public DateTime MocThoiGianNangBacMoi
        {
            get
            {
                CanReadProperty("MocThoiGianNangBacMoi", true);
                return _mocThoiGianNangBacMoi.Date;
            }
            set
            {
                CanWriteProperty("MocThoiGianNangBacMoi", true);
                if (!_mocThoiGianNangBacMoi.Equals(value))
                {
                    _mocThoiGianNangBacMoi = new SmartDate(value);
                    PropertyHasChanged("MocThoiGianNangBacMoi");
                }
            }
        }
        public DateTime NgayQuyetDinh
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
        public DateTime NgayDenHan
        {
            get
            {
                CanReadProperty("NgayDenHan", true);
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
        public DateTime NgayDenHanMoi
        {
            get
            {
                CanReadProperty("NgayDenHanMoi", true);
                return _ngayDenHanMoi.Date;
            }
            set
            {
                CanWriteProperty("NgayDenHanMoi", true);
                if (!_ngayDenHanMoi.Equals(value))
                {
                    _ngayDenHanMoi = new SmartDate(value);
                    PropertyHasChanged("NgayDenHanLanMoi");
                }
            }
        }
        public int MaNhomNgachCoBan
        {
            get { return _maNhomNgachCoBan; }
            set
            {
                _maNhomNgachCoBan = value;
                PropertyHasChanged();
            }
        }
        public int MaNgachLuongCoBanMoi
        {
            get
            {

                return _maNgachLuongCoBanMoi;
            }
            set
            {
                if (!_maNgachLuongCoBanMoi.Equals(value))
                {
                    _maNgachLuongCoBanMoi = value;
                    _tenNgachCoBanMoi = NgachLuongCoBan.GetNgachLuongCoBan(_maNgachLuongCoBanMoi).TenNgachLuongCoBan;
                    PropertyHasChanged("MaNgachLuongCoBanMoi");
                }
            }
        }
        public int MaBacLuongCoBanMoi
        {
            get
            {
                CanReadProperty("MaBacLuongCoBanMoi", true);
                return _maBacLuongCoBanMoi;
            }
            set
            {
                CanWriteProperty("MaBacLuongCoBanMoi", true);
                if (!_maBacLuongCoBanMoi.Equals(value))
                {
                    _maBacLuongCoBanMoi = value;
                    _tenBacCoBanMoi = BacLuongCoBan.GetBacLuongCoBan(_maBacLuongCoBanMoi).MaQuanLy;
                    //tt
                    _heSoLuongMoi = BacLuongCoBan.GetBacLuongCoBan(_maBacLuongCoBanMoi).HeSoLuong;

                    PropertyHasChanged("MaBacLuongCoBanMoi");
                }
            }
        }




        public int MaQuyetDinh
        {
            get
            {
                return _maQuyetDinh;
            }
        }

        public string SoQuyetDinh
        {
            get
            {
                return _soQuyetDinh;
            }
            set
            {
                if (value == null) value = string.Empty;
                if (!_soQuyetDinh.Equals(value))
                {
                    _soQuyetDinh = value;
                    PropertyHasChanged("SoQuyetDinh");
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

        public int MaNhomBaoHiemNgach
        {
            get
            {
                return _maNhomBaoHiemNgach;
            }
            set
            {
                if (!_maNhomBaoHiemNgach.Equals(value))
                {
                    _maNhomBaoHiemNgach = value;
                    PropertyHasChanged("MaNhomBaoHiemNgach");
                }
            }
        }

        public int MaNgachBaoHiemCu
        {
            get
            {
                return _maNgachBaoHiemCu;
            }
            set
            {
                if (!_maNgachBaoHiemCu.Equals(value))
                {
                    _maNgachBaoHiemCu = value;
                    PropertyHasChanged("MaNgachBaoHiemCu");
                }
            }
        }

        public string TenNgachBaoHiemCu
        {
            get
            {
                return _tenNgachBaoHiemCu;
            }
            set
            {
                if (value == null) value = string.Empty;
                if (!_tenNgachBaoHiemCu.Equals(value))
                {
                    _tenNgachBaoHiemCu = value;
                    PropertyHasChanged("TenNgachBaoHiemCu");
                }
            }
        }

        public int MaBacBaoHiemCu
        {
            get
            {
                return _maBacBaoHiemCu;
            }
            set
            {
                if (!_maBacBaoHiemCu.Equals(value))
                {
                    _maBacBaoHiemCu = value;
                    PropertyHasChanged("MaBacBaoHiemCu");
                }
            }
        }

        public decimal HeSoBaoHiemCu
        {
            get
            {
                return _heSoBaoHiemCu;
            }
            set
            {
                if (!_heSoBaoHiemCu.Equals(value))
                {
                    _heSoBaoHiemCu = value;
                    PropertyHasChanged("HeSoBaoHiemCu");
                }
            }
        }

        public string TenBacBaoHiemCu
        {
            get
            {
                _tenBacBaoHiemCu = BacLuongCoBan.GetBacLuongCoBan(_maBacBaoHiemCu).MaQuanLy;
                return _tenBacBaoHiemCu;
            }
            set
            {
                if (value == null) value = string.Empty;
                if (!_tenBacBaoHiemCu.Equals(value))
                {
                    _tenBacBaoHiemCu = value;
                    PropertyHasChanged("TenBacBaoHiemCu");
                }
            }
        }

        public int MaNgachBaoHiemMoi
        {
            get
            {
                
                return _maNgachBaoHiemMoi;
            }
            set
            {
                if (!_maNgachBaoHiemMoi.Equals(value))
                {
                    _maNgachBaoHiemMoi = value;
                    _tenNgachBaoHiemMoi = NgachLuongCoBan.GetNgachLuongCoBan(MaNgachBaoHiemMoi).TenNgachLuongCoBan;
                    PropertyHasChanged("MaNgachBaoHiemMoi");
                }
            }
        }

        public string TenNgachBaoHiemMoi
        {
            get
            {
                _tenNgachBaoHiemMoi = NgachLuongCoBan.GetNgachLuongCoBan(_maNgachBaoHiemMoi).TenNgachLuongCoBan;
                return _tenNgachBaoHiemMoi;
            }
            set
            {
                if (value == null) value = string.Empty;
                if (!_tenNgachBaoHiemMoi.Equals(value))
                {
                    _tenNgachBaoHiemMoi = value;
                    PropertyHasChanged("TenNgachBaoHiemMoi");
                }
            }
        }

        public int MaBacBaoHiemMoi
        {
            get
            {
                CanReadProperty("MaBacBaoHiemMoi", true);
                return _maBacBaoHiemMoi;
            }
            set
            {
                CanWriteProperty("MaBacBaoHiemMoi", true);
                if (!_maBacBaoHiemMoi.Equals(value))
                {
                    _maBacBaoHiemMoi = value;
                    _tenBacBaoHiemMoi = BacLuongCoBan.GetBacLuongCoBan(_maBacBaoHiemMoi).MaQuanLy;
                    _heSoBaoHiemMoi = BacLuongCoBan.GetBacLuongCoBan(_maBacBaoHiemMoi).HeSoLuong;
                    PropertyHasChanged("MaBacBaoHiemMoi");
                }
            }
        }

        public decimal HeSoBaoHiemMoi
        {
            get
            {
                CanReadProperty("HeSoBaoHiemMoi", true);
                return _heSoBaoHiemMoi;
            }
            set
            {
                CanWriteProperty("HeSoBaoHiemMoi", true);
                if (!_heSoBaoHiemMoi.Equals(value))
                {
                    _heSoBaoHiemMoi = value;
                    PropertyHasChanged("HeSoBaoHiemMoi");
                }
            }
        }

        public string TenBacBaoHiemMoi
        {
            get
            {
             //   _tenBacBaoHiemMoi = BacLuongCoBan.GetBacLuongCoBan(_maBacBaoHiemMoi).MaQuanLy;
                return _tenBacBaoHiemMoi;
            }
            set
            {
                if (value == null) value = string.Empty;
                if (!_tenBacBaoHiemMoi.Equals(value))
                {
                    _tenBacBaoHiemMoi = value;
                    PropertyHasChanged("TenBacBaoHiemMoi");
                }
            }
        }

   
   
        public long MaNguoiLap
        {
            get
            {
                return _maNguoiLap;
            }
            set
            {
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

  
        public decimal HSPCCu
        {
            get
            {
                return _hSPCCu;
            }
            set
            {
                if (!_hSPCCu.Equals(value))
                {
                    _hSPCCu = value;
                    PropertyHasChanged("HSPCCu");
                }
            }
        }

        public decimal HSPCMoi
        {
            get
            {
                return _hSPCMoi;
            }
            set
            {
                if (!_hSPCMoi.Equals(value))
                {
                    _hSPCMoi = value;
                    PropertyHasChanged("HSPCMoi");
                }
            }
        }

        public decimal HSVKCu
        {
            get
            {
                return _hSVKCu;
            }
            set
            {
                if (!_hSVKCu.Equals(value))
                {
                    _hSVKCu = value;
                    PropertyHasChanged("HSVKCu");
                }
            }
        }

        public decimal HSVKMoi
        {
            get
            {
                return _hSVKMoi;
            }
            set
            {
                if (!_hSVKMoi.Equals(value))
                {
                    _hSVKMoi = value;
                    PropertyHasChanged("HSVKMoi");
                }
            }
        }

        public decimal HSVKBHCu
        {
            get
            {
                return _hSVKBHCu;
            }
            set
            {
                if (!_hSVKBHCu.Equals(value))
                {
                    _hSVKBHCu = value;
                    PropertyHasChanged("HSVKBHCu");
                }
            }
        }

        public decimal HSVKBHMoi
        {
            get
            {
                return _hSVKBHMoi;
            }
            set
            {
                if (!_hSVKBHMoi.Equals(value))
                {
                    _hSVKBHMoi = value;
                    PropertyHasChanged("HSVKBHMoi");
                }
            }
        }


  
        public int ThoiGiaNangBacCu
        {
            get
            {
                return _thoiGiaNangBacCu;
            }
            set
            {
                if (!_thoiGiaNangBacCu.Equals(value))
                {
                    _thoiGiaNangBacCu = value;
                    PropertyHasChanged("ThoiGiaNangBacCu");
                }
            }
        }

        public int ThoiGianNangBacMoi
        {
            get
            {
                return _thoiGianNangBacMoi;
            }
            set
            {
                if (!_thoiGianNangBacMoi.Equals(value))
                {
                    _thoiGianNangBacMoi = value;
                    PropertyHasChanged("ThoiGianNangBacMoi");
                }
            }
        }

        public int MaNgachCoBanCu
        {
            get
            {
                return _maNgachCoBanCu;
            }
            set
            {
                if (!_maNgachCoBanCu.Equals(value))
                {
                    _maNgachCoBanCu = value;
                    PropertyHasChanged("MaNgachCoBanCu");
                }
            }
        }

        public int MaBacLuongCoBanCu
        {
            get
            {
                return _maBacLuongCoBanCu;
            }
            set
            {
                if (!_maBacLuongCoBanCu.Equals(value))
                {
                    _maBacLuongCoBanCu = value;
                    PropertyHasChanged("MaBacLuongCoBanCu");
                }
            }
        }





        public decimal HeSoLuongMoi
        {
            get
            {
                CanReadProperty("HeSoLuongMoi", true);
               // _heSoLuongMoi = BacLuongCoBan.GetBacLuongCoBan(MaBacLuongCoBanMoi).HeSoLuong;
                return _heSoLuongMoi;
            }
            set
            {
                CanWriteProperty("HeSoLuongMoi", true);
                if (!_heSoLuongMoi.Equals(value))
                {
                    _heSoLuongMoi = value;
                    PropertyHasChanged("HeSoLuongMoi");
                }
            }
        }

        public decimal HeSoLuongCu
        {
            get
            {
                return _heSoLuongCu;
            }
            set
            {
                if (!_heSoLuongCu.Equals(value))
                {
                    _heSoLuongCu = value;
                    PropertyHasChanged("HeSoLuongCu");
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

        public decimal HeSoNBCu
        {
            get
            {
                return _HeSoNBCu;
            }
            set
            {
                if (!_HeSoNBCu.Equals(value))
                {
                    _HeSoNBCu = value;
                    PropertyHasChanged("HeSoNoiBoCu");
                }
            }
        }

        public decimal HeSoNBMoi
        {
            get
            {
                return _HeSoNBMoi;
            }
            set
            {
                if (!_HeSoNBMoi.Equals(value))
                {
                    _HeSoNBMoi = value;
                    PropertyHasChanged("HeSoNBMoi");
                }
            }
        }

        public int LoaiNhanVienCu
        {
            get
            {
                return _loaiNhanVienCu;
            }
            set
            {
                if (!_loaiNhanVienCu.Equals(value))
                {
                    _loaiNhanVienCu = value;
                    PropertyHasChanged("LoaiNhanVienCu");
                }
            }
        }

        public int LoaiNhanVienMoi
        {
            get
            {
                return _loaiNhanVienMoi;
            }
            set
            {
                if (!_loaiNhanVienMoi.Equals(value))
                {
                    _loaiNhanVienMoi = value;
                    PropertyHasChanged("LoaiNhanVienMoi");
                }
            }
        }

        public bool CapNhatSau
        {
            get
            {
                return _capNhatSau;
            }
            set
            {
                if (!_capNhatSau.Equals(value))
                {
                    _capNhatSau = value;
                    PropertyHasChanged("CapNhatSau");
                }
            }
        }


        public DateTime? MocNangLuong
        {
            get
            {
                CanReadProperty("MocNangLuong", true);
                return _mocNangLuong;
            }
            set
            {
                CanWriteProperty("MocNangLuong", true);
                if (!_mocNangLuong.Equals(value))
                {
                    _mocNangLuong = value;
                    PropertyHasChanged("MocNangLuong");
                }
            }
        }

        public DateTime? MocNangLuongBH
        {
            get
            {
                CanReadProperty("MocNangLuongBH", true);
                return _mocNangLuongBH;
            }
            set
            {
                CanWriteProperty("MocNangLuongBH", true);
                if (!_mocNangLuongBH.Equals(value))
                {
                    _mocNangLuongBH = value;
                    PropertyHasChanged("MocNangLuongBH");
                }
            }
        }
   
		protected override object GetIdValue()
		{
			return _maQuyetDinh;
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
			//TODO: Define CanGetObject permission in QuyetDinhNangLuong
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("QuyetDinhNangLuongViewGroup"))
			//	return true;
			//return false;
		}

		public static bool CanAddObject()
		{
			//TODO: Define CanAddObject permission in QuyetDinhNangLuong
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("QuyetDinhNangLuongAddGroup"))
			//	return true;
			//return false;
		}

		public static bool CanEditObject()
		{
			//TODO: Define CanEditObject permission in QuyetDinhNangLuong
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("QuyetDinhNangLuongEditGroup"))
			//	return true;
			//return false;
		}

		public static bool CanDeleteObject()
		{
			//TODO: Define CanDeleteObject permission in QuyetDinhNangLuong
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("QuyetDinhNangLuongDeleteGroup"))
			//	return true;
			//return false;
		}
		#endregion //Authorization Rules

		#region Factory Methods
		private QuyetDinhNangLuong()
		{ /* require use of factory method */ }

		public static QuyetDinhNangLuong NewQuyetDinhNangLuong()
		{
            QuyetDinhNangLuong item = new QuyetDinhNangLuong();
            item.MarkAsChild();
            return item;
		}
        public static QuyetDinhNangLuong NewQuyetDinhNangLuong(long maNhanVien,decimal heSoCu)
        {
            QuyetDinhNangLuong item = new QuyetDinhNangLuong();
            item.MarkAsChild();
            item.MaNhanVien=maNhanVien;
            item.HeSoBaoHiemCu = heSoCu;
            return item;
        }
		public static QuyetDinhNangLuong GetQuyetDinhNangLuong(int maQuyetDinh)
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException("User not authorized to view a QuyetDinhNangLuong");
			return DataPortal.Fetch<QuyetDinhNangLuong>(new Criteria(maQuyetDinh));
		}
        public static int KiemTraNgayHieuLucMax(long MaNhanVien)
        {
            int maQuyetDinh = 0;
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {

                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_KiemTraNgayHieuLucMaxQuyetDinhNangLuong";
                    cm.Parameters.AddWithValue("@MaNhanVien", MaNhanVien);
                    cm.Parameters.AddWithValue("@MaQuyetDinh", maQuyetDinh);
                    cm.Parameters["@MaQuyetDinh"].Direction = ParameterDirection.Output;

                    cm.ExecuteNonQuery();

                  
                   object obj     = (object) cm.Parameters["@MaQuyetDinh"].Value;
                   if (!Convert.IsDBNull(obj))
                   {
                       maQuyetDinh = (int)obj;
                   }
                     
                }

                return maQuyetDinh;
            }//using
        }
        
		public static void DeleteQuyetDinhNangLuong(int maQuyetDinh)
		{
			if (!CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a QuyetDinhNangLuong");
			DataPortal.Delete(new Criteria(maQuyetDinh));
		}

		public override QuyetDinhNangLuong Save()
		{
			if (IsDeleted && !CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a QuyetDinhNangLuong");
			else if (IsNew && !CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a QuyetDinhNangLuong");
			else if (!CanEditObject())
				throw new System.Security.SecurityException("User not authorized to update a QuyetDinhNangLuong");

			return base.Save();
		}

		#endregion //Factory Methods

		#region Child Factory Methods
		internal static QuyetDinhNangLuong NewQuyetDinhNangLuongChild()
		{
			QuyetDinhNangLuong child = new QuyetDinhNangLuong();
			//child.ValidationRules.CheckRules();
			child.MarkAsChild();
			return child;
		}

		internal static QuyetDinhNangLuong GetQuyetDinhNangLuong(SafeDataReader dr)
		{
			QuyetDinhNangLuong child =  new QuyetDinhNangLuong();
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
			public int MaQuyetDinh;

			public Criteria(int maQuyetDinh)
			{
				this.MaQuyetDinh = maQuyetDinh;
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
                cm.CommandText = "spd_SelecttblnsQuyetDinhNangLuong";

				cm.Parameters.AddWithValue("@MaQuyetDinh", criteria.MaQuyetDinh);

				using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
				{
                    while (dr.Read())
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
			DataPortal_Delete(new Criteria(_maQuyetDinh));
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
                cm.CommandText = "spd_DeletetblnsQuyetDinhNangLuong";

				cm.Parameters.AddWithValue("@MaQuyetDinh", criteria.MaQuyetDinh);

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
            _maQuyetDinh = dr.GetInt32("MaQuyetDinh");
            _soQuyetDinh = dr.GetString("SoQuyetDinh");
            _maNhanVien = dr.GetInt64("MaNhanVien");
            _maChucVu = dr.GetInt32("MaChucVu");
            _tenChucVu = dr.GetString("TenChucVu");
            _maBoPhan = dr.GetInt32("MaBoPhan");
            _tenBoPhan = dr.GetString("TenBoPhan");
            _maQLNhanVien = dr.GetString("MaQLNhanVien");
            _maNhomBaoHiemNgach = dr.GetInt32("MaNhomBaoHiemNgach");
            _maNgachBaoHiemCu = dr.GetInt32("MaNgachBaoHiemCu");
            _tenNgachBaoHiemCu = dr.GetString("TenNgachBaoHiemCu");
            _maBacBaoHiemCu = dr.GetInt32("MaBacBaoHiemCu");
            _heSoBaoHiemCu = dr.GetDecimal("HeSoBaoHiemCu");
            _tenBacBaoHiemCu = dr.GetString("TenBacBaoHiemCu");
            _maNgachBaoHiemMoi = dr.GetInt32("MaNgachBaoHiemMoi");
            _tenNgachBaoHiemMoi = dr.GetString("TenNgachBaoHiemMoi");
            _maBacBaoHiemMoi = dr.GetInt32("MaBacBaoHiemMoi");
            _heSoBaoHiemMoi = dr.GetDecimal("HeSoBaoHiemMoi");
           // _tenBacBaoHiemMoi = dr.GetString("TenBacBaoHiemMoi");
            _ngayHieuLuc = dr.GetSmartDate("NgayHieuLuc", _ngayHieuLuc.EmptyIsMin);
            _mocThoiGianNangBac = dr.GetSmartDate("MocThoiGianNangBac", _mocThoiGianNangBac.EmptyIsMin);
            _mocThoiGianNangBacMoi = dr.GetSmartDate("MocThoiGianNangBacMoi", _mocThoiGianNangBacMoi.EmptyIsMin);
            _maNguoiLap = dr.GetInt64("MaNguoiLap");
            _ngayLap = dr.GetSmartDate("NgayLap", _ngayLap.EmptyIsMin);
            _hSPCCu = dr.GetDecimal("HSPCCu");
            _hSPCMoi = dr.GetDecimal("HSPCMoi");
            _hSVKCu = dr.GetDecimal("HSVKCu");
            _hSVKMoi = dr.GetDecimal("HSVKMoi");
            _hSVKBHCu = dr.GetDecimal("HSVKBHCu");
            _hSVKBHMoi = dr.GetDecimal("HSVKBHMoi");
            _ngayDenHan = dr.GetSmartDate("NgayDenHan", _ngayDenHan.EmptyIsMin);
            _ngayDenHanMoi = dr.GetSmartDate("NgayDenHanMoi", _ngayDenHanMoi.EmptyIsMin);
            _thoiGiaNangBacCu = dr.GetInt32("ThoiGiaNangBacCu");
            _thoiGianNangBacMoi = dr.GetInt32("ThoiGianNangBacMoi");
            _maNgachCoBanCu = dr.GetInt32("MaNgachCoBanCu");
            _maBacLuongCoBanCu = dr.GetInt32("MaBacLuongCoBanCu");
            _maNgachLuongCoBanMoi = dr.GetInt32("MaNgachLuongCoBanMoi");
            _maBacLuongCoBanMoi = dr.GetInt32("MaBacLuongCoBanMoi");
            _heSoLuongMoi = dr.GetDecimal("HeSoLuongMoi");
            _heSoLuongCu = dr.GetDecimal("HeSoLuongCu");
            _maNhomNgachCoBan = dr.GetInt32("MaNhomNgachCoBan");
            _kieuNangLuong = dr.GetInt32("KieuNangLuong");
            _tenBacBaoHiemMoi = BacLuongCoBan.GetBacLuongCoBan(_maBacBaoHiemMoi).MaQuanLy;
            _tenBacCoBanMoi = BacLuongCoBan.GetBacLuongCoBan(_maBacLuongCoBanMoi).MaQuanLy;
            _HeSoNBCu = dr.GetDecimal("HeSoNBCu");
            _HeSoNBMoi = dr.GetDecimal("HeSoNBMoi");
            _loaiNhanVienCu = dr.GetInt32("LoaiNhanVienCu");
            _loaiNhanVienMoi = dr.GetInt32("LoaiNhanVienMoi");
            _capNhatSau = dr.GetBoolean("CapNhatSau");

            _mocNangLuong = dr.GetDateTime("MocNangLuong");
            _mocNangLuongBH = dr.GetDateTime("MocNangLuongBH");
		}

		private void FetchChildren(SafeDataReader dr)
		{
		}
		#endregion //Data Access - Fetch

		#region Data Access - Insert
		internal void Insert(SqlTransaction tr, QuyetDinhNangLuongList parent)
		{
			if (!IsDirty) return;

			ExecuteInsert(tr, parent);
			MarkOld();

			//update child object(s)
			UpdateChildren(tr);
		}

		private void ExecuteInsert(SqlTransaction tr, QuyetDinhNangLuongList parent)
		{
			using (SqlCommand cm = tr.Connection.CreateCommand())
			{
				cm.Transaction = tr;
				cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_InserttblnsQuyetDinhNangLuong";

				AddInsertParameters(cm, parent);

				cm.ExecuteNonQuery();

				_maQuyetDinh = (int)cm.Parameters["@MaQuyetDinh"].Value;
			}//using
		}

		private void AddInsertParameters(SqlCommand cm, QuyetDinhNangLuongList parent)
		{
			//TODO: if parent use identity key, fix fk member with value from parent
            cm.Parameters.AddWithValue("@SoQuyetDinh", _soQuyetDinh);
            cm.Parameters.AddWithValue("@MaNhanVien", _maNhanVien);
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
            if (_maQLNhanVien.Length > 0)
                cm.Parameters.AddWithValue("@MaQLNhanVien", _maQLNhanVien);
            else
                cm.Parameters.AddWithValue("@MaQLNhanVien", DBNull.Value);
            if (_maNhomBaoHiemNgach != 0)
                cm.Parameters.AddWithValue("@MaNhomBaoHiemNgach", _maNhomBaoHiemNgach);
            else
                cm.Parameters.AddWithValue("@MaNhomBaoHiemNgach", DBNull.Value);
            if (_maNgachBaoHiemCu != 0)
                cm.Parameters.AddWithValue("@MaNgachBaoHiemCu", _maNgachBaoHiemCu);
            else
                cm.Parameters.AddWithValue("@MaNgachBaoHiemCu", DBNull.Value);
            if (_tenNgachBaoHiemCu.Length > 0)
                cm.Parameters.AddWithValue("@TenNgachBaoHiemCu", _tenNgachBaoHiemCu);
            else
                cm.Parameters.AddWithValue("@TenNgachBaoHiemCu", DBNull.Value);
            if (_maBacBaoHiemCu != 0)
                cm.Parameters.AddWithValue("@MaBacBaoHiemCu", _maBacBaoHiemCu);
            else
                cm.Parameters.AddWithValue("@MaBacBaoHiemCu", DBNull.Value);
            if (_heSoBaoHiemCu != 0)
                cm.Parameters.AddWithValue("@HeSoBaoHiemCu", _heSoBaoHiemCu);
            else
                cm.Parameters.AddWithValue("@HeSoBaoHiemCu", DBNull.Value);
            if (_tenBacBaoHiemCu.Length > 0)
                cm.Parameters.AddWithValue("@TenBacBaoHiemCu", _tenBacBaoHiemCu);
            else
                cm.Parameters.AddWithValue("@TenBacBaoHiemCu", DBNull.Value);
            if (_maNgachBaoHiemMoi != 0)
                cm.Parameters.AddWithValue("@MaNgachBaoHiemMoi", _maNgachBaoHiemMoi);
            else
                cm.Parameters.AddWithValue("@MaNgachBaoHiemMoi", DBNull.Value);
            if (_tenNgachBaoHiemMoi.Length > 0)
                cm.Parameters.AddWithValue("@TenNgachBaoHiemMoi", _tenNgachBaoHiemMoi);
            else
                cm.Parameters.AddWithValue("@TenNgachBaoHiemMoi", DBNull.Value);
            if (_maBacBaoHiemMoi != 0)
                cm.Parameters.AddWithValue("@MaBacBaoHiemMoi", _maBacBaoHiemMoi);
            else
                cm.Parameters.AddWithValue("@MaBacBaoHiemMoi", DBNull.Value);
            if (_heSoBaoHiemMoi != 0)
                cm.Parameters.AddWithValue("@HeSoBaoHiemMoi", _heSoBaoHiemMoi);
            else
                cm.Parameters.AddWithValue("@HeSoBaoHiemMoi", DBNull.Value);
            if (_tenBacBaoHiemMoi.Length > 0)
                cm.Parameters.AddWithValue("@TenBacBaoHiemMoi", _tenBacBaoHiemMoi);
            else
                cm.Parameters.AddWithValue("@TenBacBaoHiemMoi", DBNull.Value);
            cm.Parameters.AddWithValue("@NgayHieuLuc", _ngayHieuLuc.DBValue);
            cm.Parameters.AddWithValue("@MocThoiGianNangBac", _mocThoiGianNangBac.DBValue);
            cm.Parameters.AddWithValue("@MocThoiGianNangBacMoi", _mocThoiGianNangBacMoi.DBValue);
            if (_maNguoiLap != 0)
                cm.Parameters.AddWithValue("@MaNguoiLap", _maNguoiLap);
            else
                cm.Parameters.AddWithValue("@MaNguoiLap", DBNull.Value);
            cm.Parameters.AddWithValue("@NgayLap", _ngayLap.DBValue);
            if (_hSPCCu != 0)
                cm.Parameters.AddWithValue("@HSPCCu", _hSPCCu);
            else
                cm.Parameters.AddWithValue("@HSPCCu", DBNull.Value);
            if (_hSPCMoi != 0)
                cm.Parameters.AddWithValue("@HSPCMoi", _hSPCMoi);
            else
                cm.Parameters.AddWithValue("@HSPCMoi", DBNull.Value);
            if (_hSVKCu != 0)
                cm.Parameters.AddWithValue("@HSVKCu", _hSVKCu);
            else
                cm.Parameters.AddWithValue("@HSVKCu", DBNull.Value);
            if (_hSVKMoi != 0)
                cm.Parameters.AddWithValue("@HSVKMoi", _hSVKMoi);
            else
                cm.Parameters.AddWithValue("@HSVKMoi", DBNull.Value);


            if (_hSVKBHCu != 0)
                cm.Parameters.AddWithValue("@HSVKBHCu", _hSVKBHCu);
            else
                cm.Parameters.AddWithValue("@HSVKBHCu", DBNull.Value);
            if (_hSVKBHMoi != 0)
                cm.Parameters.AddWithValue("@HSVKBHMoi", _hSVKBHMoi);
            else
                cm.Parameters.AddWithValue("@HSVKBHMoi", DBNull.Value);

            cm.Parameters.AddWithValue("@NgayDenHan", _ngayDenHan.DBValue);
            cm.Parameters.AddWithValue("@NgayDenHanMoi", _ngayDenHanMoi.DBValue);
            if (_thoiGiaNangBacCu != 0)
                cm.Parameters.AddWithValue("@ThoiGiaNangBacCu", _thoiGiaNangBacCu);
            else
                cm.Parameters.AddWithValue("@ThoiGiaNangBacCu", DBNull.Value);
            if (_thoiGianNangBacMoi != 0)
                cm.Parameters.AddWithValue("@ThoiGianNangBacMoi", _thoiGianNangBacMoi);
            else
                cm.Parameters.AddWithValue("@ThoiGianNangBacMoi", DBNull.Value);
            if (_maNgachCoBanCu != 0)
                cm.Parameters.AddWithValue("@MaNgachCoBanCu", _maNgachCoBanCu);
            else
                cm.Parameters.AddWithValue("@MaNgachCoBanCu", DBNull.Value);
            if (_maBacLuongCoBanCu != 0)
                cm.Parameters.AddWithValue("@MaBacLuongCoBanCu", _maBacLuongCoBanCu);
            else
                cm.Parameters.AddWithValue("@MaBacLuongCoBanCu", DBNull.Value);
            if (_maNgachLuongCoBanMoi != 0)
                cm.Parameters.AddWithValue("@MaNgachLuongCoBanMoi", _maNgachLuongCoBanMoi);
            else
                cm.Parameters.AddWithValue("@MaNgachLuongCoBanMoi", DBNull.Value);
            if (_maBacLuongCoBanMoi != 0)
                cm.Parameters.AddWithValue("@MaBacLuongCoBanMoi", _maBacLuongCoBanMoi);
            else
                cm.Parameters.AddWithValue("@MaBacLuongCoBanMoi", DBNull.Value);
            if (_heSoLuongMoi != 0)
                cm.Parameters.AddWithValue("@HeSoLuongMoi", _heSoLuongMoi);
            else
                cm.Parameters.AddWithValue("@HeSoLuongMoi", DBNull.Value);
            if (_heSoLuongCu != 0)
                cm.Parameters.AddWithValue("@HeSoLuongCu", _heSoLuongCu);
            else
                cm.Parameters.AddWithValue("@HeSoLuongCu", DBNull.Value);
            if (_maNhomNgachCoBan != 0)
                cm.Parameters.AddWithValue("@MaNhomNgachCoBan", _maNhomNgachCoBan);
            else
                cm.Parameters.AddWithValue("@MaNhomNgachCoBan", DBNull.Value);
            cm.Parameters.AddWithValue("@MaQuyetDinh", _maQuyetDinh);
            if (_kieuNangLuong != 0)
                cm.Parameters.AddWithValue("@KieuNangLuong", _kieuNangLuong);
            else
                cm.Parameters.AddWithValue("@KieuNangLuong", DBNull.Value);
            if (_HeSoNBCu != 0)
                cm.Parameters.AddWithValue("@HeSoNBCu", _HeSoNBCu);
            else
                cm.Parameters.AddWithValue("@HeSoNBCu", DBNull.Value);
            if (_HeSoNBMoi != 0)
                cm.Parameters.AddWithValue("@HeSoNBMoi", _HeSoNBMoi);
            else
                cm.Parameters.AddWithValue("@HeSoNBMoi", DBNull.Value);
            if (_loaiNhanVienCu != 0)
                cm.Parameters.AddWithValue("@LoaiNhanVienCu", _loaiNhanVienCu);
            else
                cm.Parameters.AddWithValue("@LoaiNhanVienCu", DBNull.Value);
            if (_loaiNhanVienMoi != 0)
                cm.Parameters.AddWithValue("@LoaiNhanVienMoi", _loaiNhanVienMoi);
            else
                cm.Parameters.AddWithValue("@LoaiNhanVienMoi", DBNull.Value);
            cm.Parameters.AddWithValue("@CapNhatSau", _capNhatSau);
            if (_mocNangLuong != null & _mocNangLuong != DateTime.MinValue)
                cm.Parameters.AddWithValue("@MocNangLuong", _mocNangLuong);
            else
                cm.Parameters.AddWithValue("@MocNangLuong", DBNull.Value);
            if (_mocNangLuongBH != null & _mocNangLuongBH != DateTime.MinValue)
                cm.Parameters.AddWithValue("@MocNangLuongBH", _mocNangLuongBH);
            else
                cm.Parameters.AddWithValue("@MocNangLuongBH", DBNull.Value);

            cm.Parameters["@MaQuyetDinh"].Direction = ParameterDirection.Output;

        }
		#endregion //Data Access - Insert

		#region Data Access - Update
		internal void Update(SqlTransaction tr, QuyetDinhNangLuongList parent)
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

		private void ExecuteUpdate(SqlTransaction tr, QuyetDinhNangLuongList parent)
		{
            try
            {
                using (SqlCommand cm = tr.Connection.CreateCommand())
                {
                    cm.Transaction = tr;
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_UpdatetblnsQuyetDinhNangLuong";

                    AddUpdateParameters(cm, parent);

                    cm.ExecuteNonQuery();

                }//using
            }
            catch (Exception ex)
            {
                throw ex;
            }
		}

		private void AddUpdateParameters(SqlCommand cm, QuyetDinhNangLuongList parent)
		{

            cm.Parameters.AddWithValue("@MaQuyetDinh", _maQuyetDinh);
            cm.Parameters.AddWithValue("@SoQuyetDinh", _soQuyetDinh);
            cm.Parameters.AddWithValue("@MaNhanVien", _maNhanVien);
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
            if (_maQLNhanVien.Length > 0)
                cm.Parameters.AddWithValue("@MaQLNhanVien", _maQLNhanVien);
            else
                cm.Parameters.AddWithValue("@MaQLNhanVien", DBNull.Value);
            if (_maNhomBaoHiemNgach != 0)
                cm.Parameters.AddWithValue("@MaNhomBaoHiemNgach", _maNhomBaoHiemNgach);
            else
                cm.Parameters.AddWithValue("@MaNhomBaoHiemNgach", DBNull.Value);
            if (_maNgachBaoHiemCu != 0)
                cm.Parameters.AddWithValue("@MaNgachBaoHiemCu", _maNgachBaoHiemCu);
            else
                cm.Parameters.AddWithValue("@MaNgachBaoHiemCu", DBNull.Value);
            if (_tenNgachBaoHiemCu.Length > 0)
                cm.Parameters.AddWithValue("@TenNgachBaoHiemCu", _tenNgachBaoHiemCu);
            else
                cm.Parameters.AddWithValue("@TenNgachBaoHiemCu", DBNull.Value);
            if (_maBacBaoHiemCu != 0)
                cm.Parameters.AddWithValue("@MaBacBaoHiemCu", _maBacBaoHiemCu);
            else
                cm.Parameters.AddWithValue("@MaBacBaoHiemCu", DBNull.Value);
            if (_heSoBaoHiemCu != 0)
                cm.Parameters.AddWithValue("@HeSoBaoHiemCu", _heSoBaoHiemCu);
            else
                cm.Parameters.AddWithValue("@HeSoBaoHiemCu", DBNull.Value);
            if (_tenBacBaoHiemCu.Length > 0)
                cm.Parameters.AddWithValue("@TenBacBaoHiemCu", _tenBacBaoHiemCu);
            else
                cm.Parameters.AddWithValue("@TenBacBaoHiemCu", DBNull.Value);
            if (_maNgachBaoHiemMoi != 0)
                cm.Parameters.AddWithValue("@MaNgachBaoHiemMoi", _maNgachBaoHiemMoi);
            else
                cm.Parameters.AddWithValue("@MaNgachBaoHiemMoi", DBNull.Value);
            if (_tenNgachBaoHiemMoi.Length > 0)
                cm.Parameters.AddWithValue("@TenNgachBaoHiemMoi", _tenNgachBaoHiemMoi);
            else
                cm.Parameters.AddWithValue("@TenNgachBaoHiemMoi", DBNull.Value);
            if (_maBacBaoHiemMoi != 0)
                cm.Parameters.AddWithValue("@MaBacBaoHiemMoi", _maBacBaoHiemMoi);
            else
                cm.Parameters.AddWithValue("@MaBacBaoHiemMoi", DBNull.Value);
            if (_heSoBaoHiemMoi != 0)
                cm.Parameters.AddWithValue("@HeSoBaoHiemMoi", _heSoBaoHiemMoi);
            else
                cm.Parameters.AddWithValue("@HeSoBaoHiemMoi", DBNull.Value);
            if (_tenBacBaoHiemMoi.Length > 0)
                cm.Parameters.AddWithValue("@TenBacBaoHiemMoi", _tenBacBaoHiemMoi);
            else
                cm.Parameters.AddWithValue("@TenBacBaoHiemMoi", DBNull.Value);
            cm.Parameters.AddWithValue("@NgayHieuLuc", _ngayHieuLuc.DBValue);
            cm.Parameters.AddWithValue("@MocThoiGianNangBac", _mocThoiGianNangBac.DBValue);
            cm.Parameters.AddWithValue("@MocThoiGianNangBacMoi", _mocThoiGianNangBacMoi.DBValue);
            if (_maNguoiLap != 0)
                cm.Parameters.AddWithValue("@MaNguoiLap", _maNguoiLap);
            else
                cm.Parameters.AddWithValue("@MaNguoiLap", DBNull.Value);
            cm.Parameters.AddWithValue("@NgayLap", _ngayLap.DBValue);
            if (_hSPCCu != 0)
                cm.Parameters.AddWithValue("@HSPCCu", _hSPCCu);
            else
                cm.Parameters.AddWithValue("@HSPCCu", DBNull.Value);
            if (_hSPCMoi != 0)
                cm.Parameters.AddWithValue("@HSPCMoi", _hSPCMoi);
            else
                cm.Parameters.AddWithValue("@HSPCMoi", DBNull.Value);
            if (_hSVKCu != 0)
                cm.Parameters.AddWithValue("@HSVKCu", _hSVKCu);
            else
                cm.Parameters.AddWithValue("@HSVKCu", DBNull.Value);
            if (_hSVKMoi != 0)
                cm.Parameters.AddWithValue("@HSVKMoi", _hSVKMoi);
            else
                cm.Parameters.AddWithValue("@HSVKMoi", DBNull.Value);

            if (_hSVKBHCu != 0)
                cm.Parameters.AddWithValue("@HSVKBHCu", _hSVKBHCu);
            else
                cm.Parameters.AddWithValue("@HSVKBHCu", DBNull.Value);
            if (_hSVKBHMoi != 0)
                cm.Parameters.AddWithValue("@HSVKBHMoi", _hSVKBHMoi);
            else
                cm.Parameters.AddWithValue("@HSVKBHMoi", DBNull.Value);

            cm.Parameters.AddWithValue("@NgayDenHan", _ngayDenHan.DBValue);
            cm.Parameters.AddWithValue("@NgayDenHanMoi", _ngayDenHanMoi.DBValue);
            if (_thoiGiaNangBacCu != 0)
                cm.Parameters.AddWithValue("@ThoiGiaNangBacCu", _thoiGiaNangBacCu);
            else
                cm.Parameters.AddWithValue("@ThoiGiaNangBacCu", DBNull.Value);
            if (_thoiGianNangBacMoi != 0)
                cm.Parameters.AddWithValue("@ThoiGianNangBacMoi", _thoiGianNangBacMoi);
            else
                cm.Parameters.AddWithValue("@ThoiGianNangBacMoi", DBNull.Value);
            if (_maNgachCoBanCu != 0)
                cm.Parameters.AddWithValue("@MaNgachCoBanCu", _maNgachCoBanCu);
            else
                cm.Parameters.AddWithValue("@MaNgachCoBanCu", DBNull.Value);
            if (_maBacLuongCoBanCu != 0)
                cm.Parameters.AddWithValue("@MaBacLuongCoBanCu", _maBacLuongCoBanCu);
            else
                cm.Parameters.AddWithValue("@MaBacLuongCoBanCu", DBNull.Value);
            if (_maNgachLuongCoBanMoi != 0)
                cm.Parameters.AddWithValue("@MaNgachLuongCoBanMoi", _maNgachLuongCoBanMoi);
            else
                cm.Parameters.AddWithValue("@MaNgachLuongCoBanMoi", DBNull.Value);
            if (_maBacLuongCoBanMoi != 0)
                cm.Parameters.AddWithValue("@MaBacLuongCoBanMoi", _maBacLuongCoBanMoi);
            else
                cm.Parameters.AddWithValue("@MaBacLuongCoBanMoi", DBNull.Value);
            if (_heSoLuongMoi != 0)
                cm.Parameters.AddWithValue("@HeSoLuongMoi", _heSoLuongMoi);
            else
                cm.Parameters.AddWithValue("@HeSoLuongMoi", DBNull.Value);
            if (_heSoLuongCu != 0)
                cm.Parameters.AddWithValue("@HeSoLuongCu", _heSoLuongCu);
            else
                cm.Parameters.AddWithValue("@HeSoLuongCu", DBNull.Value);
            if (_maNhomNgachCoBan != 0)
                cm.Parameters.AddWithValue("@MaNhomNgachCoBan", _maNhomNgachCoBan);
            else
                cm.Parameters.AddWithValue("@MaNhomNgachCoBan", DBNull.Value);
            if (_kieuNangLuong != 0)
                cm.Parameters.AddWithValue("@KieuNangLuong", _kieuNangLuong);
            else
                cm.Parameters.AddWithValue("@KieuNangLuong", DBNull.Value);
            if (_HeSoNBCu != 0)
                cm.Parameters.AddWithValue("@HeSoNBCu", _HeSoNBCu);
            else
                cm.Parameters.AddWithValue("@HeSoNBCu", DBNull.Value);
            if (_HeSoNBMoi != 0)
                cm.Parameters.AddWithValue("@HeSoNBMoi", _HeSoNBMoi);
            else
                cm.Parameters.AddWithValue("@HeSoNBMoi", DBNull.Value);
            if (_loaiNhanVienCu != 0)
                cm.Parameters.AddWithValue("@LoaiNhanVienCu", _loaiNhanVienCu);
            else
                cm.Parameters.AddWithValue("@LoaiNhanVienCu", DBNull.Value);
            if (_loaiNhanVienMoi != 0)
                cm.Parameters.AddWithValue("@LoaiNhanVienMoi", _loaiNhanVienMoi);
            else
                cm.Parameters.AddWithValue("@LoaiNhanVienMoi", DBNull.Value);
            if (_mocNangLuong != null & _mocNangLuong != DateTime.MinValue)
                cm.Parameters.AddWithValue("@MocNangLuong", _mocNangLuong);
            else
                cm.Parameters.AddWithValue("@MocNangLuong", DBNull.Value);
            if (_mocNangLuongBH != null & _mocNangLuongBH != DateTime.MinValue)
                cm.Parameters.AddWithValue("@MocNangLuongBH", _mocNangLuongBH);
            else
                cm.Parameters.AddWithValue("@MocNangLuongBH", DBNull.Value);
            cm.Parameters.AddWithValue("@CapNhatSau", _capNhatSau);
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

			ExecuteDelete(tr, new Criteria(_maQuyetDinh));
			MarkNew();
		}
		#endregion //Data Access - Delete
		#endregion //Data Access
	}
}
