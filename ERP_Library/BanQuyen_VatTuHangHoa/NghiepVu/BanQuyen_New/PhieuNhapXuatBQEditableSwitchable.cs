
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;
using System.Windows.Forms;
using System.Text;
//12_04_2013
///
namespace ERP_Library
{
    [Serializable()]
    public class PhieuNhapXuatBQ : Csla.BusinessBase<PhieuNhapXuatBQ>
    {
        #region Business Properties and Methods

        //declare members
        private long _maPhieuNhapXuat = 0;
        private string _soPhieu = string.Empty;
        private short _loai = 0;
        private bool _laNhap = false;
        private SmartDate _ngayHT = new SmartDate(DateTime.Today);
        private SmartDate _ngayNX = new SmartDate(DateTime.Today);
        private int _maNguoiLap = 0;
        private int _maKho = 0;
        private long _maDoiTac = 0;
        private decimal _giaTriKho = 0;
        private string _dienGiai = string.Empty;
        private int _maDinhKhoan = 0;
        private byte _tinhTrang = 0;
        private byte _quyTrinh = 0;
        private string _vietBangChu = string.Empty;
        private bool _khoaSo = false;
        private byte _phuongPhapNX = 1;
        private long _maNguoiNhapXuat = 0;
        private long _maNguoiDaiDienBenGiao = 0;
        private int _maPhongBan = 0;
        private long _maPhieuNhapXuatThamChieu = 0;
        private SmartDate _ngayXacNhan = new SmartDate(DateTime.Today);
        private bool _xacNhan = false;
        private int _soCTKemTheo = 1;//M
        //M
        private bool _checkChon;
        private StringBuilder _dsHHkhongduxuat = new StringBuilder("");//Check So luong Xuat
        private bool _khongDuXuat = false;//Check So luong Xuat
        public StringBuilder DsHHkhongduxuat
        {
            get { return _dsHHkhongduxuat; }
        }
        public bool KhongDuXuat
        {
            get { return _khongDuXuat; }
        }
        //declare child member(s)
        private CT_PhieuNhapBQList _cT_PhieuNhapList = CT_PhieuNhapBQList.NewCT_PhieuNhapList();
        private CT_PhieuXuatBQList _cT_PhieuXuatList = CT_PhieuXuatBQList.NewCT_PhieuXuatList();
        private DinhKhoanNhapXuatBQ _dinhKhoanNhapXuat = DinhKhoanNhapXuatBQ.NewDinhKhoanNhapXuat();
        private ButToanPhieuNhapXuatBQList _butToanPhieuNhapXuatList = ButToanPhieuNhapXuatBQList.NewButToanPhieuNhapXuatList();
        private HoaDon_NhapXuatList _hoaDon_NhapXuatList = HoaDon_NhapXuatList.NewHoaDon_NhapXuatList();
        private NhapXuat_HopDongList _nhapXuat_HopDongList = NhapXuat_HopDongList.NewNhapXuat_HopDongList();

        [System.ComponentModel.DataObjectField(true, true)]
        public long MaPhieuNhapXuat
        {
            get
            {
                CanReadProperty("MaPhieuNhapXuat", true);
                return _maPhieuNhapXuat;
            }
        }

        public string SoPhieu
        {
            get
            {
                CanReadProperty("SoPhieu", true);
                return _soPhieu;
            }
            set
            {
                CanWriteProperty("SoPhieu", true);
                if (value == null) value = string.Empty;
                if (!_soPhieu.Equals(value))
                {
                    _soPhieu = value;
                    PropertyHasChanged("SoPhieu");
                }
            }
        }

        public short Loai
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

        public bool LaNhap
        {
            get
            {
                CanReadProperty("LaNhap", true);
                return _laNhap;
            }
            set
            {
                CanWriteProperty("LaNhap", true);
                if (!_laNhap.Equals(value))
                {
                    _laNhap = value;
                    PropertyHasChanged("LaNhap");
                }
            }
        }

        public DateTime NgayHT
        {
            get
            {
                CanReadProperty("NgayHT", true);
                return _ngayHT.Date;
            }
        }

        public string NgayHTString
        {
            get
            {
                CanReadProperty("NgayHTString", true);
                return _ngayHT.Text;
            }
            set
            {
                CanWriteProperty("NgayHTString", true);
                if (value == null) value = string.Empty;
                if (!_ngayHT.Equals(value))
                {
                    _ngayHT.Text = value;
                    PropertyHasChanged("NgayHTString");
                }
            }
        }

        public DateTime NgayNX
        {
            get
            {
                CanReadProperty("NgayNX", true);
                return _ngayNX.Date;
            }
            set
            {

                CanWriteProperty("NgayNX", true);
                _ngayNX = new SmartDate(value);
                PropertyHasChanged("NgayNX");
            }
        }

        public string NgayNXString
        {
            get
            {
                CanReadProperty("NgayNXString", true);
                return _ngayNX.Text;
            }
            set
            {
                CanWriteProperty("NgayNXString", true);
                if (value == null) value = string.Empty;
                if (!_ngayNX.Equals(value))
                {
                    _ngayNX.Text = value;
                    PropertyHasChanged("NgayNXString");
                }
            }
        }

        public int MaNguoiLap
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

        public int MaKho
        {
            get
            {
                CanReadProperty("MaKho", true);
                return _maKho;
            }
            set
            {
                CanWriteProperty("MaKho", true);
                if (!_maKho.Equals(value))
                {
                    _maKho = value;
                    PropertyHasChanged("MaKho");
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

        public decimal GiaTriKho
        {
            get
            {
                CanReadProperty("GiaTriKho", true);
                return _giaTriKho;
            }
            set
            {
                CanWriteProperty("GiaTriKho", true);
                if (!_giaTriKho.Equals(value))
                {
                    _giaTriKho = value;
                    if (_giaTriKho < 0)//M
                    {
                        _vietBangChu = HamDungChung.DocTien(-(_giaTriKho));//M
                    }
                    else
                    {
                        _vietBangChu = HamDungChung.DocTien(_giaTriKho);
                    }
                    PropertyHasChanged("GiaTriKho");
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

        public int MaDinhKhoan
        {
            get
            {
                CanReadProperty("MaDinhKhoan", true);
                return _maDinhKhoan;
            }
            set
            {
                CanWriteProperty("MaDinhKhoan", true);
                if (!_maDinhKhoan.Equals(value))
                {
                    _maDinhKhoan = value;
                    PropertyHasChanged("MaDinhKhoan");
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

        public byte QuyTrinh
        {
            get
            {
                CanReadProperty("QuyTrinh", true);
                return _quyTrinh;
            }
            set
            {
                CanWriteProperty("QuyTrinh", true);
                if (!_quyTrinh.Equals(value))
                {
                    _quyTrinh = value;
                    PropertyHasChanged("QuyTrinh");
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

        public bool KhoaSo
        {
            get
            {
                CanReadProperty("KhoaSo", true);
                return _khoaSo;
            }
            set
            {
                CanWriteProperty("KhoaSo", true);
                if (!_khoaSo.Equals(value))
                {
                    _khoaSo = value;
                    PropertyHasChanged("KhoaSo");
                }
            }
        }

        public byte PhuongPhapNX
        {
            get
            {
                CanReadProperty("PhuongPhapNX", true);
                return _phuongPhapNX;
            }
            set
            {
                CanWriteProperty("PhuongPhapNX", true);
                if (!_phuongPhapNX.Equals(value))
                {
                    _phuongPhapNX = value;
                    PropertyHasChanged("PhuongPhapNX");
                }
            }
        }

        public long MaNguoiNhapXuat
        {
            get
            {
                CanReadProperty("MaNguoiNhapXuat", true);
                return _maNguoiNhapXuat;
            }
            set
            {
                CanWriteProperty("MaNguoiNhapXuat", true);
                if (!_maNguoiNhapXuat.Equals(value))
                {
                    _maNguoiNhapXuat = value;
                    PropertyHasChanged("MaNguoiNhapXuat");
                }
            }
        }
        public long MaNguoiDaiDienBenGiao
        {
            get
            {
                CanReadProperty("MaNguoiDaiDienBenGiao", true);
                return _maNguoiDaiDienBenGiao;
            }
            set
            {
                CanWriteProperty("MaNguoiDaiDienBenGiao", true);
                if (!_maNguoiDaiDienBenGiao.Equals(value))
                {
                    _maNguoiDaiDienBenGiao = value;
                    PropertyHasChanged("MaNguoiDaiDienBenGiao");
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

        public long MaPhieuNhapXuatThamChieu
        {
            get
            {
                CanReadProperty("MaPhieuNhapXuatThamChieu", true);
                return _maPhieuNhapXuatThamChieu;
            }
            set
            {
                CanWriteProperty("MaPhieuNhapXuatThamChieu", true);
                if (!_maPhieuNhapXuatThamChieu.Equals(value))
                {
                    _maPhieuNhapXuatThamChieu = value;
                    PropertyHasChanged("MaPhieuNhapXuatThamChieu");
                }
            }
        }

        public DateTime NgayXacNhan
        {
            get
            {
                CanReadProperty("NgayXacNhan", true);
                return _ngayXacNhan.Date;
            }
            set
            {
                CanWriteProperty("NgayXacNhan", true);
                _ngayXacNhan = new SmartDate(value);
                PropertyHasChanged("NgayXacNhan");
            }
        }

        public string NgayXacNhanString
        {
            get
            {
                CanReadProperty("NgayXacNhanString", true);
                return _ngayXacNhan.Text;
            }
            set
            {
                CanWriteProperty("NgayXacNhanString", true);
                if (value == null) value = string.Empty;
                if (!_ngayXacNhan.Equals(value))
                {
                    _ngayXacNhan.Text = value;
                    PropertyHasChanged("NgayXacNhanString");
                }
            }
        }

        public bool XacNhan
        {
            get
            {
                CanReadProperty("XacNhan", true);
                return _xacNhan;
            }
            set
            {
                CanWriteProperty("XacNhan", true);
                if (!_xacNhan.Equals(value))
                {
                    _xacNhan = value;
                    if (_xacNhan)
                        _ngayXacNhan = new SmartDate(DateTime.Today);
                    else
                        _ngayXacNhan = new SmartDate(false);
                    PropertyHasChanged("XacNhan");
                }
            }
        }
        public int SoCTKemTheo
        {
            get
            {
                CanReadProperty("SoCTKemTheo", true);
                return _soCTKemTheo;
            }
            set
            {
                CanWriteProperty("SoCTKemTheo", true);
                if (!_soCTKemTheo.Equals(value))
                {
                    _soCTKemTheo = value;
                    PropertyHasChanged("SoCTKemTheo");
                }
            }
        }

      

        public CT_PhieuNhapBQList CT_PhieuNhapList
        {
            get
            {
                CanReadProperty("CT_PhieuNhapList", true);
                return _cT_PhieuNhapList;
            }
        }

        public CT_PhieuXuatBQList CT_PhieuXuatList
        {
            get
            {
                CanReadProperty("CT_PhieuXuatList", true);
                return _cT_PhieuXuatList;
            }
        }

        public DinhKhoanNhapXuatBQ DinhKhoanNhapXuat
        {
            get
            {
                CanReadProperty("DinhKhoanNhapXuat", true);
                return _dinhKhoanNhapXuat;
            }
        }

        public ButToanPhieuNhapXuatBQList ButToanPhieuNhapXuatList
        {
            get
            {
                CanReadProperty("ButToanPhieuNhapXuatList", true);
                return _butToanPhieuNhapXuatList;
            }
        }

        public HoaDon_NhapXuatList HoaDon_NhapXuatList
        {
            get
            {
                CanReadProperty("HoaDon_NhapXuatList", true);
                return _hoaDon_NhapXuatList;
            }
            set
            {
                CanWriteProperty("HoaDon_NhapXuatList", true);

                _hoaDon_NhapXuatList = value;
                PropertyHasChanged("HoaDon_NhapXuatList");

            }
        }

        public NhapXuat_HopDongList NhapXuat_HopDongList
        {
            get
            {
                CanReadProperty("NhapXuat_HopDongList", true);
                return _nhapXuat_HopDongList;
            }
            set
            {
                CanWriteProperty("NhapXuat_HopDongList", true);

                _nhapXuat_HopDongList = value;
                PropertyHasChanged("NhapXuat_HopDongList");

            }
        }

        public override bool IsValid
        {
            get { return base.IsValid && _cT_PhieuNhapList.IsValid && _cT_PhieuXuatList.IsValid && _dinhKhoanNhapXuat.IsValid && _butToanPhieuNhapXuatList.IsValid && _hoaDon_NhapXuatList.IsValid && _nhapXuat_HopDongList.IsValid ; }
        }

        public override bool IsDirty
        {
            get { return base.IsDirty  || _cT_PhieuNhapList.IsDirty || _cT_PhieuXuatList.IsDirty || _dinhKhoanNhapXuat.IsDirty || _butToanPhieuNhapXuatList.IsDirty || _hoaDon_NhapXuatList.IsDirty || _nhapXuat_HopDongList.IsDirty ; }
        }

        protected override object GetIdValue()
        {
            return _maPhieuNhapXuat;
        }
        //Me
        public bool CheckChon
        {
            get { return _checkChon; }
            set { _checkChon = value; }
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
            // SoPhieu
            //
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("SoPhieu", 50));
            //
            // NgayHT
            //
            ValidationRules.AddRule(CommonRules.StringRequired, "NgayHTString");
            //
            // NgayNX
            //
            ValidationRules.AddRule(CommonRules.StringRequired, "NgayNXString");
            //
            // DienGiai
            //
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("DienGiai", 500));
            //
            // VietBangChu
            //
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("VietBangChu", 1024));
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
            //TODO: Define authorization rules in PhieuNhapXuat
            //AuthorizationRules.AllowRead("CT_PhieuNXList", "PhieuNhapXuatReadGroup");
            //AuthorizationRules.AllowRead("CT_PhieuNhapList", "PhieuNhapXuatReadGroup");
            //AuthorizationRules.AllowRead("CT_PhieuXuatList", "PhieuNhapXuatReadGroup");
            //AuthorizationRules.AllowRead("DinhKhoanNhapXuat", "PhieuNhapXuatReadGroup");
            //AuthorizationRules.AllowRead("ButToanPhieuNhapXuatList", "PhieuNhapXuatReadGroup");
            //AuthorizationRules.AllowRead("MaPhieuNhapXuat", "PhieuNhapXuatReadGroup");
            //AuthorizationRules.AllowRead("SoPhieu", "PhieuNhapXuatReadGroup");
            //AuthorizationRules.AllowRead("Loai", "PhieuNhapXuatReadGroup");
            //AuthorizationRules.AllowRead("LaNhap", "PhieuNhapXuatReadGroup");
            //AuthorizationRules.AllowRead("NgayHT", "PhieuNhapXuatReadGroup");
            //AuthorizationRules.AllowRead("NgayHTString", "PhieuNhapXuatReadGroup");
            //AuthorizationRules.AllowRead("NgayNX", "PhieuNhapXuatReadGroup");
            //AuthorizationRules.AllowRead("NgayNXString", "PhieuNhapXuatReadGroup");
            //AuthorizationRules.AllowRead("MaNguoiLap", "PhieuNhapXuatReadGroup");
            //AuthorizationRules.AllowRead("MaKho", "PhieuNhapXuatReadGroup");
            //AuthorizationRules.AllowRead("MaDoiTac", "PhieuNhapXuatReadGroup");
            //AuthorizationRules.AllowRead("GiaTriKho", "PhieuNhapXuatReadGroup");
            //AuthorizationRules.AllowRead("DienGiai", "PhieuNhapXuatReadGroup");
            //AuthorizationRules.AllowRead("MaDinhKhoan", "PhieuNhapXuatReadGroup");
            //AuthorizationRules.AllowRead("TinhTrang", "PhieuNhapXuatReadGroup");
            //AuthorizationRules.AllowRead("QuyTrinh", "PhieuNhapXuatReadGroup");
            //AuthorizationRules.AllowRead("VietBangChu", "PhieuNhapXuatReadGroup");
            //AuthorizationRules.AllowRead("KhoaSo", "PhieuNhapXuatReadGroup");
            //AuthorizationRules.AllowRead("PhuongPhapNX", "PhieuNhapXuatReadGroup");
            //AuthorizationRules.AllowRead("MaNguoiNhapXuat", "PhieuNhapXuatReadGroup");
            //AuthorizationRules.AllowRead("MaPhongBan", "PhieuNhapXuatReadGroup");
            //AuthorizationRules.AllowRead("MaPhieuNhapXuatThamChieu", "PhieuNhapXuatReadGroup");
            //AuthorizationRules.AllowRead("NgayXacNhan", "PhieuNhapXuatReadGroup");
            //AuthorizationRules.AllowRead("NgayXacNhanString", "PhieuNhapXuatReadGroup");
            //AuthorizationRules.AllowRead("XacNhan", "PhieuNhapXuatReadGroup");

            //AuthorizationRules.AllowWrite("SoPhieu", "PhieuNhapXuatWriteGroup");
            //AuthorizationRules.AllowWrite("Loai", "PhieuNhapXuatWriteGroup");
            //AuthorizationRules.AllowWrite("LaNhap", "PhieuNhapXuatWriteGroup");
            //AuthorizationRules.AllowWrite("NgayHTString", "PhieuNhapXuatWriteGroup");
            //AuthorizationRules.AllowWrite("NgayNXString", "PhieuNhapXuatWriteGroup");
            //AuthorizationRules.AllowWrite("MaNguoiLap", "PhieuNhapXuatWriteGroup");
            //AuthorizationRules.AllowWrite("MaKho", "PhieuNhapXuatWriteGroup");
            //AuthorizationRules.AllowWrite("MaDoiTac", "PhieuNhapXuatWriteGroup");
            //AuthorizationRules.AllowWrite("GiaTriKho", "PhieuNhapXuatWriteGroup");
            //AuthorizationRules.AllowWrite("DienGiai", "PhieuNhapXuatWriteGroup");
            //AuthorizationRules.AllowWrite("MaDinhKhoan", "PhieuNhapXuatWriteGroup");
            //AuthorizationRules.AllowWrite("TinhTrang", "PhieuNhapXuatWriteGroup");
            //AuthorizationRules.AllowWrite("QuyTrinh", "PhieuNhapXuatWriteGroup");
            //AuthorizationRules.AllowWrite("VietBangChu", "PhieuNhapXuatWriteGroup");
            //AuthorizationRules.AllowWrite("KhoaSo", "PhieuNhapXuatWriteGroup");
            //AuthorizationRules.AllowWrite("PhuongPhapNX", "PhieuNhapXuatWriteGroup");
            //AuthorizationRules.AllowWrite("MaNguoiNhapXuat", "PhieuNhapXuatWriteGroup");
            //AuthorizationRules.AllowWrite("MaPhongBan", "PhieuNhapXuatWriteGroup");
            //AuthorizationRules.AllowWrite("MaPhieuNhapXuatThamChieu", "PhieuNhapXuatWriteGroup");
            //AuthorizationRules.AllowWrite("NgayXacNhanString", "PhieuNhapXuatWriteGroup");
            //AuthorizationRules.AllowWrite("XacNhan", "PhieuNhapXuatWriteGroup");
        }

        public static bool CanGetObject()
        {
            //TODO: Define CanGetObject permission in PhieuNhapXuat
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("PhieuNhapXuatViewGroup"))
            //	return true;
            //return false;
        }

        public static bool CanAddObject()
        {
            //TODO: Define CanAddObject permission in PhieuNhapXuat
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("PhieuNhapXuatAddGroup"))
            //	return true;
            //return false;
        }

        public static bool CanEditObject()
        {
            //TODO: Define CanEditObject permission in PhieuNhapXuat
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("PhieuNhapXuatEditGroup"))
            //	return true;
            //return false;
        }

        public static bool CanDeleteObject()
        {
            //TODO: Define CanDeleteObject permission in PhieuNhapXuat
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("PhieuNhapXuatDeleteGroup"))
            //	return true;
            //return false;
        }
        #endregion //Authorization Rules

        #region Factory Methods
        private PhieuNhapXuatBQ()
        { /* require use of factory method */ }

        public static PhieuNhapXuatBQ NewPhieuNhapXuat()
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a PhieuNhapXuat");
            return DataPortal.Create<PhieuNhapXuatBQ>();
        }

        public static PhieuNhapXuatBQ NewPhieuNhapXuat(PhieuNhapXuatBQ phieuNhapXuat)
        {
            PhieuNhapXuatBQ _phieuNhapXuat = new PhieuNhapXuatBQ();
            _phieuNhapXuat._maKho = phieuNhapXuat._maKho;
            _phieuNhapXuat._maNguoiNhapXuat = phieuNhapXuat._maNguoiNhapXuat;
            _phieuNhapXuat._maPhieuNhapXuatThamChieu = phieuNhapXuat._maPhieuNhapXuat;
            _phieuNhapXuat._giaTriKho = phieuNhapXuat._giaTriKho;
            _phieuNhapXuat._vietBangChu = phieuNhapXuat._vietBangChu;
            // _phieuNhapXuat.NgayNXString = phieuNhapXuat.NgayNX.ToString();M
            _phieuNhapXuat._phuongPhapNX = phieuNhapXuat._phuongPhapNX;
            _phieuNhapXuat._maPhongBan = phieuNhapXuat._maPhongBan;
            _phieuNhapXuat.MaDoiTac = phieuNhapXuat.MaDoiTac;
            _phieuNhapXuat._dsHHkhongduxuat = new StringBuilder("Số lượng xuất \"");//Check So luong Xuat
            _phieuNhapXuat._khongDuXuat = false;//Check So luong Xuat
            foreach (CT_PhieuNhapBQ ct_PhieuNhap in phieuNhapXuat._cT_PhieuNhapList)
            {
                if (phieuNhapXuat.PhuongPhapNX == 2)
                {
                    if (ct_PhieuNhap.SoLuong - ct_PhieuNhap.SoLuongXuat > HangHoaBQ_VT.GetSoLuongHangHoaNhapThang(_phieuNhapXuat._maKho, ct_PhieuNhap.MaHangHoa, _phieuNhapXuat.NgayNX))
                    {
                        HangHoaBQ_VT _hangHoaBQ_VT = HangHoaBQ_VT.GetHangHoaBQ_VT(ct_PhieuNhap.MaHangHoa);
                        _phieuNhapXuat._dsHHkhongduxuat.Append(String.Format("{0}, ", _hangHoaBQ_VT.TenHangHoa));
                        _phieuNhapXuat._khongDuXuat = true;
                        //MessageBox.Show("Số lượng xuất \"" + _hangHoaBQ_VT.TenHangHoa + "\" vượt quá số lượng tồn!\n Không thể xuất!");
                    }
                    else
                    {
                        //
                        _phieuNhapXuat._cT_PhieuXuatList.Add(new CT_PhieuXuatBQ(ct_PhieuNhap, _phieuNhapXuat._maKho, _phieuNhapXuat.NgayNX));
                        //
                    }
                }
                else
                {
                    if (ct_PhieuNhap.SoLuong - ct_PhieuNhap.SoLuongXuat > HangHoaBQ_VT.GetSoLuongHangHoaBinhQuan(0, _phieuNhapXuat._maKho, ct_PhieuNhap.MaHangHoa, _phieuNhapXuat.NgayNX))
                    {
                        HangHoaBQ_VT _hangHoaBQ_VT = HangHoaBQ_VT.GetHangHoaBQ_VT(ct_PhieuNhap.MaHangHoa);
                        _phieuNhapXuat._dsHHkhongduxuat.Append(String.Format("{0}, ", _hangHoaBQ_VT.TenHangHoa));
                        _phieuNhapXuat._khongDuXuat = true;
                        //MessageBox.Show("Số lượng xuất \"" + _hangHoaBQ_VT.TenHangHoa + "\" vượt quá số lượng tồn!\n Không thể xuất!");
                    }
                    else
                    {
                        //
                        _phieuNhapXuat._cT_PhieuXuatList.Add(new CT_PhieuXuatBQ(ct_PhieuNhap, _phieuNhapXuat._maKho, _phieuNhapXuat.NgayNX));
                        //
                    }
                }
            }
            _phieuNhapXuat._dsHHkhongduxuat = _phieuNhapXuat._dsHHkhongduxuat.Remove(_phieuNhapXuat._dsHHkhongduxuat.Length - 1, 1);
            if (_phieuNhapXuat._khongDuXuat)
            {
                MessageBox.Show(_phieuNhapXuat.DsHHkhongduxuat + "\" vượt quá số lượng tồn!\n Không thể xuất!");
            }
            return _phieuNhapXuat;
        }
        //M
        
        public static PhieuNhapXuatBQ NewPhieuXuatBanQuen(PhieuNhapXuatBQ phieuNhapXuat, int loai)//Ban Quyen (lap Phieu xuat tu Phieu Nhap)
        {
            PhieuNhapXuatBQ _phieuNhapXuat = new PhieuNhapXuatBQ();
            _phieuNhapXuat._maKho = phieuNhapXuat._maKho;
            _phieuNhapXuat._maNguoiNhapXuat = phieuNhapXuat._maNguoiNhapXuat;
            _phieuNhapXuat._maPhieuNhapXuatThamChieu = phieuNhapXuat._maPhieuNhapXuat;
            _phieuNhapXuat._giaTriKho = phieuNhapXuat._giaTriKho;
            _phieuNhapXuat._vietBangChu = phieuNhapXuat._vietBangChu;
            _phieuNhapXuat._phuongPhapNX = phieuNhapXuat._phuongPhapNX;
            _phieuNhapXuat._maPhongBan = phieuNhapXuat._maPhongBan;
            _phieuNhapXuat.MaDoiTac = phieuNhapXuat.MaDoiTac;

            long maHopDong = 0;
            NhapXuat_HopDongList nx_HopDongList = NhapXuat_HopDongList.GetNhapXuat_HopDongList(phieuNhapXuat.MaPhieuNhapXuat);
            if (nx_HopDongList.Count != 0)
                maHopDong = nx_HopDongList[0].MaHopDong;

            foreach (CT_PhieuNhapBQ ct_PhieuNhap in phieuNhapXuat._cT_PhieuNhapList)
            {
                //
                _phieuNhapXuat._cT_PhieuXuatList.Add(new CT_PhieuXuatBQ(ct_PhieuNhap, phieuNhapXuat.MaPhongBan, phieuNhapXuat.MaKho, 2, maHopDong, _phieuNhapXuat.NgayNX));
                //
            }
            return _phieuNhapXuat;
        }

        public static PhieuNhapXuatBQ NewPhieuNhapXuat(PhieuNhapXuatBQ phieuNhapXuat, DateTime _ngayLap)//M
        {

            PhieuNhapXuatBQ _phieuNhapXuat = new PhieuNhapXuatBQ();
            _phieuNhapXuat._maKho = phieuNhapXuat._maKho;
            _phieuNhapXuat._maNguoiNhapXuat = phieuNhapXuat._maNguoiNhapXuat;
            _phieuNhapXuat._maPhieuNhapXuatThamChieu = phieuNhapXuat._maPhieuNhapXuatThamChieu;
            //_phieuNhapXuat._giaTriKho = phieuNhapXuat._giaTriKho;
            _phieuNhapXuat._vietBangChu = phieuNhapXuat._vietBangChu;
            _phieuNhapXuat._phuongPhapNX = phieuNhapXuat._phuongPhapNX;
            _phieuNhapXuat._maPhongBan = phieuNhapXuat._maPhongBan;
            _phieuNhapXuat.MaDoiTac = phieuNhapXuat.MaDoiTac;
            _phieuNhapXuat.DinhKhoanNhapXuat.NoCo = true;
            if (phieuNhapXuat.LaNhap)
            {
                foreach (CT_PhieuNhapBQ ct_PhieuNhap in phieuNhapXuat._cT_PhieuNhapList)
                {
                    _phieuNhapXuat._cT_PhieuNhapList.Add(new CT_PhieuNhapBQ(ct_PhieuNhap));
                }
            }

            //foreach (ButToanPhieuNhapXuat butToanPhieuNhapXuat in phieuNhapXuat.ButToanPhieuNhapXuatList)
            //{
            //    _phieuNhapXuat.ButToanPhieuNhapXuatList.Add(new ButToanPhieuNhapXuat(butToanPhieuNhapXuat));
            //}
            return _phieuNhapXuat;
        }

        

        

        

        public static PhieuNhapXuatBQ GetPhieuNhapXuat(long maPhieuNhapXuat)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a PhieuNhapXuat");
            return DataPortal.Fetch<PhieuNhapXuatBQ>(new Criteria(maPhieuNhapXuat));
        }

        public static void DeletePhieuNhapXuat(long maPhieuNhapXuat)
        {
            if (!CanDeleteObject())
                throw new System.Security.SecurityException("User not authorized to remove a PhieuNhapXuat");
            DataPortal.Delete(new Criteria(maPhieuNhapXuat));
        }

        public override PhieuNhapXuatBQ Save()
        {
            if (IsDeleted && !CanDeleteObject())
                throw new System.Security.SecurityException("User not authorized to remove a PhieuNhapXuat");
            else if (IsNew && !CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a PhieuNhapXuat");
            else if (!CanEditObject())
                throw new System.Security.SecurityException("User not authorized to update a PhieuNhapXuat");

            return base.Save();
        }
        #region Get Max Ma Phieu Nhap Xuat
        public static long GetMaxMaPhieuNhapXuat()
        {
            long _maxMaPhieuNhapXuat = 0;
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "Spd_GetMaxMaPhieuNhapXuat";
                    SqlParameter prmGiaTriTraVe = new SqlParameter("@GiaTriTraVe", SqlDbType.BigInt, 16);
                    prmGiaTriTraVe.Direction = ParameterDirection.Output;
                    cm.Parameters.Add(prmGiaTriTraVe);
                    cm.ExecuteNonQuery();
                    _maxMaPhieuNhapXuat = (long)prmGiaTriTraVe.Value;
                }
            }//us
            return _maxMaPhieuNhapXuat;
        }

        public static long KiemTraPhieu(long maPhieuNhapXuat)
        {
            long _count = 0;
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "Spd_KiemTraPhieuNhapXuatThang";
                    cm.Parameters.AddWithValue("@MaPhieuNhapXuat", maPhieuNhapXuat);
                    SqlParameter prmGiaTriTraVe = new SqlParameter("@GiaTriTraVe", SqlDbType.BigInt, 16);
                    prmGiaTriTraVe.Direction = ParameterDirection.Output;
                    cm.Parameters.Add(prmGiaTriTraVe);
                    cm.ExecuteNonQuery();
                    _count = (long)prmGiaTriTraVe.Value;
                }
            }//us
            return _count;
        }
        public static bool KiemTraPhieuNhapDaXuatThang(long maPhieuNhapXuat)
        {
            bool _kq = false;
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "Spd_KiemTraPhieuNhapDaXuatThang";
                    cm.Parameters.AddWithValue("@MaPhieuNhapXuat", maPhieuNhapXuat);
                    SqlParameter prmGiaTriTraVe = new SqlParameter("@GiaTriTraVe", SqlDbType.Bit, 16);
                    prmGiaTriTraVe.Direction = ParameterDirection.Output;
                    cm.Parameters.Add(prmGiaTriTraVe);
                    cm.ExecuteNonQuery();
                    _kq = (bool)prmGiaTriTraVe.Value;
                }
            }//us
            return _kq;
        }
        public static bool KiemTraPhieuXuatThangTuPhieuNhap(long maPhieuNhapXuat)
        {
            bool _kq = false;
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "Spd_KiemTraPhieuXuatThangTuPhieuNhap";
                    cm.Parameters.AddWithValue("@MaPhieuNhapXuat", maPhieuNhapXuat);
                    SqlParameter prmGiaTriTraVe = new SqlParameter("@GiaTriTraVe", SqlDbType.Bit, 16);
                    prmGiaTriTraVe.Direction = ParameterDirection.Output;
                    cm.Parameters.Add(prmGiaTriTraVe);
                    cm.ExecuteNonQuery();
                    _kq = (bool)prmGiaTriTraVe.Value;
                }
            }//us
            return _kq;
        }
        public static bool KiemTraPhieuXuatTuDSPhieuDeNghiLinh(long maPhieuNhapXuat)
        {
            bool _kq = false;
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "Spd_KiemTraPhieuXuatTuDSPhieuDeNghiLinh";
                    cm.Parameters.AddWithValue("@MaPhieuNhapXuat", maPhieuNhapXuat);
                    SqlParameter prmGiaTriTraVe = new SqlParameter("@GiaTriTraVe", SqlDbType.Bit, 16);
                    prmGiaTriTraVe.Direction = ParameterDirection.Output;
                    cm.Parameters.Add(prmGiaTriTraVe);
                    cm.ExecuteNonQuery();
                    _kq = (bool)prmGiaTriTraVe.Value;
                }
            }//us
            return _kq;
        }
        #endregion//END Get Max Ma Phieu Nhap Xuat

        #region Set So Phieu
        //public static string SetSoPhieuNhapXuat(short _loai, bool _laNhap, DateTime _ngayLap)
        //{
        //    string strSoMoi = string.Empty;
        //    using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
        //    {
        //        cn.Open();
        //        SqlCommand cm = cn.CreateCommand();
        //        cm.CommandType = System.Data.CommandType.Text;
        //        cm.CommandText = "select (isnull(Max(Left(SoPhieu,4)),0)+1) as SoCTMax from tblPhieuNhapXuat where LaNhap=@laNhap and  year(NgayNX)=year(@NgayLap) and MaPhongBan=@MaBoPhan ";
        //        cm.Parameters.AddWithValue("@MaBoPhan", ERP_Library.Security.CurrentUser.Info.MaBoPhan);
        //        cm.Parameters.AddWithValue("@laNhap", _laNhap);
        //        cm.Parameters.AddWithValue("@Loai", _loai);
        //        cm.Parameters.AddWithValue("@NgayLap", _ngayLap);


        //        strSoMoi = Convert.ToString(cm.ExecuteScalar());
        //        if (strSoMoi == "")
        //        {
        //            strSoMoi = "1";
        //        }
        //        cn.Close();
        //    }
        //    int len = strSoMoi.Length;
        //    string nam = _ngayLap.Year.ToString();//DateTime.Today.Year.ToString();
        //    while (len < 4)
        //    {
        //        strSoMoi = "0" + strSoMoi;
        //        len = strSoMoi.Length;
        //    }
        //    if (_laNhap == true && _loai !=1)
        //        strSoMoi = strSoMoi + "N/" + ERP_Library.Security.CurrentUser.Info.MaQLUser + "/" + (BoPhan.GetBoPhan(ERP_Library.Security.CurrentUser.Info.MaBoPhan)).MaBoPhanQL.Substring(0, 4);
        //    else if (_laNhap == false && _loai != 1)
        //        strSoMoi = strSoMoi + "X/" + ERP_Library.Security.CurrentUser.Info.MaQLUser + "/" + (BoPhan.GetBoPhan(ERP_Library.Security.CurrentUser.Info.MaBoPhan)).MaBoPhanQL.Substring(0, 4);
        //    //Ban Quyen
        //    else if (_laNhap == true && _loai == 1)
        //        strSoMoi = strSoMoi + "NBQ/" + ERP_Library.Security.CurrentUser.Info.MaQLUser + "/" + (BoPhan.GetBoPhan(ERP_Library.Security.CurrentUser.Info.MaBoPhan)).MaBoPhanQL.Substring(0, 4);
        //    else if (_laNhap == false && _loai == 1)
        //        strSoMoi = strSoMoi + "XBQ/" + ERP_Library.Security.CurrentUser.Info.MaQLUser + "/" + (BoPhan.GetBoPhan(ERP_Library.Security.CurrentUser.Info.MaBoPhan)).MaBoPhanQL.Substring(0, 4);

        //    return strSoMoi + "/" + _ngayLap.Year.ToString();
        //}

        public static string SetSoPhieuNhapXuat(short _loai, bool _laNhap, DateTime _ngayLap)
        {
            int _userId = ERP_Library.Security.CurrentUser.Info.UserID;
            int _maBoPhan = ERP_Library.Security.CurrentUser.Info.MaBoPhan;
            string _soPhieuNhapXuat = "";
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "Spd_SetSoPhieuNhapXuat";
                    cm.Parameters.AddWithValue("@Loai", _loai);
                    cm.Parameters.AddWithValue("@LaNhap", _laNhap);
                    cm.Parameters.AddWithValue("@NgayLap", _ngayLap);
                    cm.Parameters.AddWithValue("@UserID", _userId);
                    cm.Parameters.AddWithValue("@MaBoPhan", _maBoPhan);
                    SqlParameter prmGiaTriTraVe = new SqlParameter("@GiaTriTraVe", SqlDbType.VarChar, 50);
                    prmGiaTriTraVe.Direction = ParameterDirection.Output;
                    cm.Parameters.Add(prmGiaTriTraVe);
                    cm.ExecuteNonQuery();
                    _soPhieuNhapXuat = (string)prmGiaTriTraVe.Value;
                }
            }//us
            return _soPhieuNhapXuat;

        }

        public static string LaySoPhieu(long maPhieuNhapXuat)
        {
            string soPhieu = "";
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "Spd_GetSoPhieuOfPhieuNhapXuat";
                    cm.Parameters.AddWithValue("@MaPhieuNhapXuat", maPhieuNhapXuat);
                    SqlParameter prmGiaTriTraVe = new SqlParameter("@GiaTriTraVe", SqlDbType.VarChar, 50);
                    prmGiaTriTraVe.Direction = ParameterDirection.Output;
                    cm.Parameters.Add(prmGiaTriTraVe);
                    cm.ExecuteNonQuery();
                    if (prmGiaTriTraVe.Value != null)
                        soPhieu = (string)prmGiaTriTraVe.Value;
                }
            }//us
            return soPhieu;
        }

        public static int CheckSoPhieuNhapXuat(long _maPhieuNhapXuat, string _soPhieu)
        {
            int _isOld;
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "Spd_CheckSoPhieuNhapXuat";
                    cm.Parameters.AddWithValue("@MaPhieuNhapXuat", _maPhieuNhapXuat);
                    cm.Parameters.AddWithValue("@SoPhieu", _soPhieu);
                    SqlParameter isOld = new SqlParameter("@isOld", SqlDbType.Int);
                    isOld.Direction = ParameterDirection.Output;
                    cm.Parameters.Add(isOld);
                    cm.ExecuteNonQuery();
                    _isOld = (int)isOld.Value;
                }
            }//us
            return _isOld;

        }


        public static bool CheckSoPhieuNhapXuat(long _maPhieuNhapXuat, string _soPhieu, bool _laMoi)
        {
            bool Kt = false;
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "Spd_KiemTraSoPhieuTrung";
                    cm.Parameters.AddWithValue("@MaPhieuNhapXuat", _maPhieuNhapXuat);
                    cm.Parameters.AddWithValue("@SoPhieu", _soPhieu);
                    cm.Parameters.AddWithValue("@LaMoi", _laMoi);
                    SqlParameter prmGiaTriTraVe = new SqlParameter("@GiaTriTraVe", SqlDbType.Bit);
                    prmGiaTriTraVe.Direction = ParameterDirection.Output;
                    cm.Parameters.Add(prmGiaTriTraVe);
                    cm.ExecuteNonQuery();
                    Kt = (bool)prmGiaTriTraVe.Value;
                }
            }//us
            return Kt;

        }

        public static bool KiemTraTrungSoChungTuNhapXuat(long maPhieuNhapXuat, string soChungTu)
        {
            bool result = false;
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "Spd_CheckSoChungTuNhapXuat";
                    cm.Parameters.AddWithValue("@MaPhieuNhapXuat", maPhieuNhapXuat);
                    cm.Parameters.AddWithValue("@SoChungTu", soChungTu);
                    SqlParameter outPara = new SqlParameter("@TrungSoChungTu", SqlDbType.Bit);
                    outPara.Direction = ParameterDirection.Output;
                    cm.Parameters.Add(outPara);
                    cm.ExecuteNonQuery();
                    result = (bool)outPara.Value;
                }
            }//end using
            return result;
        }//end function

        public static string Get_NextSoChungTuNhapXuatCongCuDungCu(bool laNhap, int maBoPhan, int year, String maQLUser, int size = 4)
        {

            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {

                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_MaxSoTTChungTuNhapXuatCCDC";
                    cm.Parameters.AddWithValue("@LaNhap", laNhap);
                    cm.Parameters.AddWithValue("@Size", size);
                    cm.Parameters.AddWithValue("@Nam", year.ToString());
                    SqlParameter outPara = new SqlParameter("@SoTTChungTu", SqlDbType.VarChar, 20);
                    outPara.Direction = ParameterDirection.Output;
                    cm.Parameters.Add(outPara);
                    cm.ExecuteNonQuery();

                    BoPhan bp = BoPhan.GetBoPhan(maBoPhan);
                    String loai = "";
                    if (laNhap)
                    {
                        loai = "NCC";
                    }
                    else
                    {
                        loai = "XCC";
                    }
                    String doanCuoi = String.Format(@"{0}/{1}/{2}/", loai, maQLUser, bp.MaBoPhanQL) + year.ToString();
                    string maMoi = String.Format("{0}1{1}", new String('0', size - 1), doanCuoi);
                    if (outPara.SqlValue.ToString() != "Null")
                    {
                        String maxSoTTString = outPara.SqlValue.ToString();
                        int max = int.Parse(maxSoTTString);
                        int soMoi = max + 1;
                        maMoi = new String('0', size - soMoi.ToString().Length) + soMoi.ToString() + doanCuoi;
                    }
                    return maMoi;
                }
            }
        }
        public static string Get_NextSoChungTuThanhLyHoacDieuDieuChuyenNgoaiCongCuDungCu(int loaiNghiepVu, int maBoPhan, int year, String maQLUser, int size = 4)
        {

            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {

                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_MaxSoTTChungThanhLyHoacDieuChuyenNgoaiCCDC";
                    cm.Parameters.AddWithValue("@LoaiNghiepVu", loaiNghiepVu);
                    cm.Parameters.AddWithValue("@Size", size);
                    cm.Parameters.AddWithValue("@Nam", year.ToString());
                    SqlParameter outPara = new SqlParameter("@SoTTChungTu", SqlDbType.VarChar, 20);
                    outPara.Direction = ParameterDirection.Output;
                    cm.Parameters.Add(outPara);
                    cm.ExecuteNonQuery();

                    BoPhan bp = BoPhan.GetBoPhan(maBoPhan);
                    String loaiStr = "";
                    if (loaiNghiepVu == 7)//thanh ly ccdc
                    {
                        loaiStr = "TLCC";
                    }
                    else if (loaiNghiepVu == 8)//dieu chuyen ngoai ccdc
                    {
                        loaiStr = "DCNCC";
                    }
                    String doanCuoi = String.Format(@"{0}/{1}/{2}/", loaiStr, maQLUser, bp.MaBoPhanQL) + year.ToString();
                    string maMoi = String.Format("{0}1{1}", new String('0', size - 1), doanCuoi);
                    if (outPara.SqlValue.ToString() != "Null")
                    {
                        String maxSoTTString = outPara.SqlValue.ToString();
                        int max = int.Parse(maxSoTTString);
                        int soMoi = max + 1;
                        maMoi = new String('0', size - soMoi.ToString().Length) + soMoi.ToString() + doanCuoi;
                    }
                    return maMoi;
                }
            }
        }
        #endregion//End So Phieu
        #endregion //Factory Methods

        #region Child Factory Methods
        #region Khoi tao PhieuXuat tu PhieuNhap
        //tu DS Phieu Nhap
        public PhieuNhapXuatBQ(PhieuNhapXuatBQList _phieuNhapList)
        {
            foreach (PhieuNhapXuatBQ _phieuNhap in _phieuNhapList)
            {
                foreach (CT_PhieuNhapBQ ct_PhieuNhap in _phieuNhap._cT_PhieuNhapList)
                {
                    if (ct_PhieuNhap.SoLuong > ct_PhieuNhap.SoLuongXuat)
                    {
                        CT_PhieuXuatBQ ct_PhieuXuat = CT_PhieuXuatBQ.NewCT_PhieuXuat(ct_PhieuNhap, _phieuNhap.Loai);
                        this.CT_PhieuXuatList.Add(ct_PhieuXuat);
                    }
                }
            }
            ValidationRules.CheckRules();

        }

        public PhieuNhapXuatBQ(PhieuNhapXuatBQ _phieuNhapXuat)
        {
            foreach (CT_PhieuNhapBQ ct_PhieuNhap in _phieuNhapXuat._cT_PhieuNhapList)
            {

                CT_PhieuXuatBQ ct_PhieuXuat = CT_PhieuXuatBQ.NewCT_PhieuXuat(ct_PhieuNhap, _phieuNhapXuat.Loai);
                this.CT_PhieuXuatList.Add(ct_PhieuXuat);
            }
            ValidationRules.CheckRules();
        }
        //TU DS CT_PHIEUNHAP
        public PhieuNhapXuatBQ(CT_PhieuNhapBQList _ct_PhieuNhapList, int _makhoT, DateTime _ngayNXT)
        {

            foreach (CT_PhieuNhapBQ ct_PhieuNhap in _ct_PhieuNhapList)
            {
                if (ct_PhieuNhap.SoLuong - ct_PhieuNhap.SoLuongXuat > HangHoaBQ_VT.GetSoLuongHangHoaBinhQuan(0, _makhoT, ct_PhieuNhap.MaHangHoa, _ngayNXT))
                {
                    HangHoaBQ_VT _hangHoaBQ_VT = HangHoaBQ_VT.GetHangHoaBQ_VT(ct_PhieuNhap.MaHangHoa);
                    MessageBox.Show("Số lượng xuất \"" + _hangHoaBQ_VT.TenHangHoa + "\" vượt quá số lượng tồn!\n Không thể xuất!");
                }
                else
                {
                    //
                    if (ct_PhieuNhap.SoLuong > ct_PhieuNhap.SoLuongXuat)
                    {
                        CT_PhieuXuatBQ ct_PhieuXuat = CT_PhieuXuatBQ.NewCT_PhieuXuat(ct_PhieuNhap, _makhoT, _ngayNXT);
                        this.CT_PhieuXuatList.Add(ct_PhieuXuat);
                    }
                    else
                    {
                        HangHoaBQ_VT _hangHoaBQ_VT = HangHoaBQ_VT.GetHangHoaBQ_VT(ct_PhieuNhap.MaHangHoa);
                        MessageBox.Show("Chi tiết của \"" + _hangHoaBQ_VT.TenHangHoa + "\" đã xuất hết!");
                    }

                    //
                }
            }

            ValidationRules.CheckRules();
        }


        //cho Xuat Ban Quyen(BInh Quan, Xuat Thang)
        public PhieuNhapXuatBQ(CT_PhieuNhapBQList _ct_PhieuNhapList, int maBoPhan, int phuongPhapNX, int _makhoT, DateTime _ngayNXT)//cho Xuat Ban Quyen(BInh Quan, Xuat Thang)
        {
            foreach (CT_PhieuNhapBQ ct_PhieuNhap in _ct_PhieuNhapList)
            {
                long maHopDong = 0;
                NhapXuat_HopDongList nx_HopDongList = NhapXuat_HopDongList.GetNhapXuat_HopDongList(ct_PhieuNhap.MaPhieuNhap);
                if (nx_HopDongList.Count != 0)
                    maHopDong = nx_HopDongList[0].MaHopDong;
                //cho t/h Binh Quan & Xuat Thang
                if (ct_PhieuNhap.SoLuong > ct_PhieuNhap.SoLuongXuat)
                {
                    CT_PhieuXuatBQ ct_PhieuXuat = new CT_PhieuXuatBQ(ct_PhieuNhap, maBoPhan, _makhoT, phuongPhapNX, maHopDong, _ngayNXT);
                    this.CT_PhieuXuatList.Add(ct_PhieuXuat);
                }
                else
                {
                    HangHoaBQ_VT _hangHoaBQ_VT = HangHoaBQ_VT.GetHangHoaBQ_VT(ct_PhieuNhap.MaHangHoa);
                    MessageBox.Show("Chi tiết của \"" + _hangHoaBQ_VT.TenHangHoa + "\" đã xuất hết!");
                }
            }
            ValidationRules.CheckRules();
        }//cho Xuat Ban Quyen(BInh Quan, Xuat Thang)
        #endregion//Khoi tao PhieuXuat tu PhieuNhap
        internal static PhieuNhapXuatBQ GetPhieuNhapXuat(SafeDataReader dr)
        {
            PhieuNhapXuatBQ child = new PhieuNhapXuatBQ();
            child.MarkAsChild();
            child.Fetch(dr);
            return child;
        }

        internal static PhieuNhapXuatBQ GetPhieuNhapXuatKhongChild(SafeDataReader dr)
        {
            PhieuNhapXuatBQ child = new PhieuNhapXuatBQ();
            child.MarkAsChild();
            child.FetchKhongChild(dr);
            return child;
        }

        internal static PhieuNhapXuatBQ NewPhieuNhapXuatChild()
        {
            PhieuNhapXuatBQ child = new PhieuNhapXuatBQ();
            child.ValidationRules.CheckRules();
            child.MarkAsChild();
            return child;
        }

        #endregion //Child Factory Methods
        #region
        public static void DeletePhieuNhapXuat(PhieuNhapXuatBQ phieuNhapXuat)
        {//B
            SqlTransaction tr;
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                tr = cn.BeginTransaction();
                try
                {
                    phieuNhapXuat._cT_PhieuNhapList.Clear();
                    phieuNhapXuat._cT_PhieuNhapList.Update(tr, phieuNhapXuat);
                    phieuNhapXuat._cT_PhieuXuatList.Clear();
                    phieuNhapXuat._cT_PhieuXuatList.Update(tr, phieuNhapXuat);
                    phieuNhapXuat._butToanPhieuNhapXuatList.Clear();
                    phieuNhapXuat._butToanPhieuNhapXuatList.Update(tr, phieuNhapXuat);
                    phieuNhapXuat._hoaDon_NhapXuatList.Clear();
                    phieuNhapXuat._hoaDon_NhapXuatList.Update(tr, phieuNhapXuat);
                    phieuNhapXuat._nhapXuat_HopDongList.Clear();
                    phieuNhapXuat._nhapXuat_HopDongList.Update(tr, phieuNhapXuat);

                    using (SqlCommand cm = tr.Connection.CreateCommand())
                    {
                        cm.Transaction = tr;
                        cm.CommandType = CommandType.StoredProcedure;
                        cm.CommandText = "spd_DeletetblPhieuNhapXuat";

                        cm.Parameters.AddWithValue("@MaPhieuNhapXuat", phieuNhapXuat.MaPhieuNhapXuat);

                        cm.ExecuteNonQuery();
                    }//using
                    phieuNhapXuat._dinhKhoanNhapXuat.DeleteSelf(tr);
                    tr.Commit();
                }
                catch (SqlException ex)
                {
                    tr.Rollback();
                    throw ex;
                }
            }

        }//E
        #endregion

        #region Data Access

        #region Criteria

        [Serializable()]
        private class Criteria
        {
            public long MaPhieuNhapXuat;

            public Criteria(long maPhieuNhapXuat)
            {
                this.MaPhieuNhapXuat = maPhieuNhapXuat;
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
                cm.CommandText = "spd_SelecttblPhieuNhapXuat";

                cm.Parameters.AddWithValue("@MaPhieuNhapXuat", criteria.MaPhieuNhapXuat);

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
                    _dinhKhoanNhapXuat.Insert(tr, this);
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
            DataPortal_Delete(new Criteria(_maPhieuNhapXuat));
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
                    _cT_PhieuNhapList.Clear();
                    _cT_PhieuNhapList.Update(tr, this);
                    _cT_PhieuXuatList.Clear();
                    _cT_PhieuXuatList.Update(tr, this);
                    _butToanPhieuNhapXuatList.Clear();
                    _butToanPhieuNhapXuatList.Update(tr, this);
                    _hoaDon_NhapXuatList.Clear();
                    _hoaDon_NhapXuatList.Update(tr, this);
                    _nhapXuat_HopDongList.Clear();
                    _nhapXuat_HopDongList.Update(tr, this);
                    ExecuteDelete(tr, criteria);
                    _dinhKhoanNhapXuat.DeleteSelf(tr);
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
                cm.CommandText = "spd_DeletetblPhieuNhapXuat";

                cm.Parameters.AddWithValue("@MaPhieuNhapXuat", criteria.MaPhieuNhapXuat);

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

        private void FetchKhongChild(SafeDataReader dr)
        {
            FetchObject(dr);
            MarkOld();
            ValidationRules.CheckRules();
        }

        private void FetchObject(SafeDataReader dr)
        {
            _maPhieuNhapXuat = dr.GetInt64("MaPhieuNhapXuat");
            _soPhieu = dr.GetString("SoPhieu");
            _loai = dr.GetInt16("Loai");
            _laNhap = dr.GetBoolean("LaNhap");
            _ngayHT = dr.GetSmartDate("NgayHT", _ngayHT.EmptyIsMin);
            _ngayNX = dr.GetSmartDate("NgayNX", _ngayNX.EmptyIsMin);
            _maNguoiLap = dr.GetInt32("MaNguoiLap");
            _maKho = dr.GetInt32("MaKho");
            _maDoiTac = dr.GetInt64("MaDoiTac");
            _giaTriKho = dr.GetDecimal("GiaTriKho");
            _dienGiai = dr.GetString("DienGiai");
            _maDinhKhoan = dr.GetInt32("MaDinhKhoan");
            _tinhTrang = dr.GetByte("TinhTrang");
            _quyTrinh = dr.GetByte("QuyTrinh");
            _vietBangChu = dr.GetString("VietBangChu");
            _khoaSo = dr.GetBoolean("KhoaSo");
            _phuongPhapNX = dr.GetByte("PhuongPhapNX");
            _maNguoiNhapXuat = dr.GetInt64("MaNguoiNhapXuat");
            _maNguoiDaiDienBenGiao = dr.GetInt64("MaNguoiDaiDienBenGiao");
            _maPhongBan = dr.GetInt32("MaPhongBan");
            _maPhieuNhapXuatThamChieu = dr.GetInt64("MaPhieuNhapXuatThamChieu");
            _ngayXacNhan = dr.GetSmartDate("NgayXacNhan", _ngayXacNhan.EmptyIsMin);
            _xacNhan = dr.GetBoolean("XacNhan");
            _soCTKemTheo = dr.GetInt32("SoCTKemTheo");//M
        }

        private void FetchChildren(SafeDataReader dr)
        {
            _cT_PhieuNhapList = CT_PhieuNhapBQList.GetCT_PhieuNhapList(this.MaPhieuNhapXuat);
            _cT_PhieuXuatList = CT_PhieuXuatBQList.GetCT_PhieuXuatList(this.MaPhieuNhapXuat);
            _dinhKhoanNhapXuat = DinhKhoanNhapXuatBQ.GetDinhKhoanNhapXuat(this.MaDinhKhoan);
            _butToanPhieuNhapXuatList = ButToanPhieuNhapXuatBQList.GetButToanPhieuNhapXuatList(this.MaDinhKhoan);
            _nhapXuat_HopDongList = NhapXuat_HopDongList.GetNhapXuat_HopDongList(this.MaPhieuNhapXuat);
            _hoaDon_NhapXuatList = HoaDon_NhapXuatList.GetHoaDon_NhapXuatList(this.MaPhieuNhapXuat);
            

        }
        #endregion //Data Access - Fetch

        #region Data Access - Insert
        internal void Insert(SqlTransaction tr)
        {
            if (!IsDirty) return;
            _dinhKhoanNhapXuat.Insert(tr, this);
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
                cm.CommandText = "spd_InserttblPhieuNhapXuat";

                AddInsertParameters(cm);

                cm.ExecuteNonQuery();

                _maPhieuNhapXuat = (long)cm.Parameters["@MaPhieuNhapXuat"].Value;
            }//using
        }

        private void AddInsertParameters(SqlCommand cm)
        {
            _maDinhKhoan = _dinhKhoanNhapXuat.MaDinhKhoan;
            if (_soPhieu.Length > 0)
                cm.Parameters.AddWithValue("@SoPhieu", _soPhieu);
            else
                cm.Parameters.AddWithValue("@SoPhieu", DBNull.Value);
            if (_loai != 0)
                cm.Parameters.AddWithValue("@Loai", _loai);
            else
                cm.Parameters.AddWithValue("@Loai", DBNull.Value);
            cm.Parameters.AddWithValue("@LaNhap", _laNhap);
            cm.Parameters.AddWithValue("@NgayHT", _ngayHT.DBValue);
            cm.Parameters.AddWithValue("@NgayNX", _ngayNX.DBValue);
            cm.Parameters.AddWithValue("@MaNguoiLap", Security.CurrentUser.Info.UserID);
            if (_maKho != 0)
                cm.Parameters.AddWithValue("@MaKho", _maKho);
            else
                cm.Parameters.AddWithValue("@MaKho", DBNull.Value);
            if (_maDoiTac != 0)
                cm.Parameters.AddWithValue("@MaDoiTac", _maDoiTac);
            else
                cm.Parameters.AddWithValue("@MaDoiTac", DBNull.Value);
            if (_giaTriKho != 0)
                cm.Parameters.AddWithValue("@GiaTriKho", _giaTriKho);
            else
                cm.Parameters.AddWithValue("@GiaTriKho", DBNull.Value);
            if (_dienGiai.Length > 0)
                cm.Parameters.AddWithValue("@DienGiai", _dienGiai);
            else
                cm.Parameters.AddWithValue("@DienGiai", DBNull.Value);
            if (_maDinhKhoan != 0)
                cm.Parameters.AddWithValue("@MaDinhKhoan", _dinhKhoanNhapXuat.MaDinhKhoan);
            else
                cm.Parameters.AddWithValue("@MaDinhKhoan", DBNull.Value);
            cm.Parameters.AddWithValue("@TinhTrang", _tinhTrang);
            cm.Parameters.AddWithValue("@QuyTrinh", _quyTrinh);
            if (_vietBangChu.Length > 0)
                cm.Parameters.AddWithValue("@VietBangChu", _vietBangChu);
            else
                cm.Parameters.AddWithValue("@VietBangChu", DBNull.Value);
            if (_khoaSo != false)
                cm.Parameters.AddWithValue("@KhoaSo", _khoaSo);
            else
                cm.Parameters.AddWithValue("@KhoaSo", DBNull.Value);
            if (_phuongPhapNX != 0)
                cm.Parameters.AddWithValue("@PhuongPhapNX", _phuongPhapNX);
            else
                cm.Parameters.AddWithValue("@PhuongPhapNX", DBNull.Value);
            //
            if (_maNguoiNhapXuat != 0)
                cm.Parameters.AddWithValue("@MaNguoiNhapXuat", _maNguoiNhapXuat);
            else
                cm.Parameters.AddWithValue("@MaNguoiNhapXuat", DBNull.Value);
            //
            if (_maNguoiDaiDienBenGiao != 0)
                cm.Parameters.AddWithValue("@MaNguoiDaiDienBenGiao", _maNguoiDaiDienBenGiao);
            else
                cm.Parameters.AddWithValue("@MaNguoiDaiDienBenGiao", DBNull.Value);
            //
            if (_maPhongBan != 0)
                cm.Parameters.AddWithValue("@MaPhongBan", _maPhongBan);
            else
                cm.Parameters.AddWithValue("@MaPhongBan", DBNull.Value);
            if (_maPhieuNhapXuatThamChieu != 0)
                cm.Parameters.AddWithValue("@MaPhieuNhapXuatThamChieu", _maPhieuNhapXuatThamChieu);
            else
                cm.Parameters.AddWithValue("@MaPhieuNhapXuatThamChieu", DBNull.Value);
            if (_ngayXacNhan.Date != DateTime.MinValue)
            {
                cm.Parameters.AddWithValue("@NgayXacNhan", _ngayXacNhan.DBValue);
            }
            else
                cm.Parameters.AddWithValue("@NgayXacNhan", DBNull.Value);

            if (_xacNhan != false)
                cm.Parameters.AddWithValue("@XacNhan", _xacNhan);
            else
                cm.Parameters.AddWithValue("@XacNhan", DBNull.Value);
            cm.Parameters.AddWithValue("@SoCTKemTheo", _soCTKemTheo);//M
            cm.Parameters.AddWithValue("@MaPhieuNhapXuat", _maPhieuNhapXuat);
            cm.Parameters["@MaPhieuNhapXuat"].Direction = ParameterDirection.Output;
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
                cm.CommandText = "spd_UpdatetblPhieuNhapXuat";

                AddUpdateParameters(cm);

                cm.ExecuteNonQuery();

            }//using
        }

        private void AddUpdateParameters(SqlCommand cm)
        {
            cm.Parameters.AddWithValue("@MaPhieuNhapXuat", _maPhieuNhapXuat);
            if (_soPhieu.Length > 0)
                cm.Parameters.AddWithValue("@SoPhieu", _soPhieu);
            else
                cm.Parameters.AddWithValue("@SoPhieu", DBNull.Value);
            if (_loai != 0)
                cm.Parameters.AddWithValue("@Loai", _loai);
            else
                cm.Parameters.AddWithValue("@Loai", DBNull.Value);
            cm.Parameters.AddWithValue("@LaNhap", _laNhap);
            cm.Parameters.AddWithValue("@NgayHT", _ngayHT.DBValue);
            cm.Parameters.AddWithValue("@NgayNX", _ngayNX.DBValue);
            //cm.Parameters.AddWithValue("@MaNguoiLap", Security.CurrentUser.Info.UserID);
            if (_maNguoiLap != 0)
                cm.Parameters.AddWithValue("@MaNguoiLap", _maNguoiLap);
            else
                cm.Parameters.AddWithValue("@MaNguoiLap", Security.CurrentUser.Info.UserID);
            if (_maKho != 0)
                cm.Parameters.AddWithValue("@MaKho", _maKho);
            else
                cm.Parameters.AddWithValue("@MaKho", DBNull.Value);
            if (_maDoiTac != 0)
                cm.Parameters.AddWithValue("@MaDoiTac", _maDoiTac);
            else
                cm.Parameters.AddWithValue("@MaDoiTac", DBNull.Value);
            if (_giaTriKho != 0)
                cm.Parameters.AddWithValue("@GiaTriKho", _giaTriKho);
            else
                cm.Parameters.AddWithValue("@GiaTriKho", DBNull.Value);
            if (_dienGiai.Length > 0)
                cm.Parameters.AddWithValue("@DienGiai", _dienGiai);
            else
                cm.Parameters.AddWithValue("@DienGiai", DBNull.Value);
            if (_maDinhKhoan != 0)
                cm.Parameters.AddWithValue("@MaDinhKhoan", _maDinhKhoan);
            else
                cm.Parameters.AddWithValue("@MaDinhKhoan", DBNull.Value);
            cm.Parameters.AddWithValue("@TinhTrang", _tinhTrang);
            cm.Parameters.AddWithValue("@QuyTrinh", _quyTrinh);
            if (_vietBangChu.Length > 0)
                cm.Parameters.AddWithValue("@VietBangChu", _vietBangChu);
            else
                cm.Parameters.AddWithValue("@VietBangChu", DBNull.Value);
            if (_khoaSo != false)
                cm.Parameters.AddWithValue("@KhoaSo", _khoaSo);
            else
                cm.Parameters.AddWithValue("@KhoaSo", DBNull.Value);
            if (_phuongPhapNX != 0)
                cm.Parameters.AddWithValue("@PhuongPhapNX", _phuongPhapNX);
            else
                cm.Parameters.AddWithValue("@PhuongPhapNX", DBNull.Value);
            //
            if (_maNguoiNhapXuat != 0)
                cm.Parameters.AddWithValue("@MaNguoiNhapXuat", _maNguoiNhapXuat);
            else
                cm.Parameters.AddWithValue("@MaNguoiNhapXuat", DBNull.Value);
            //
            if (_maNguoiDaiDienBenGiao != 0)
                cm.Parameters.AddWithValue("@MaNguoiDaiDienBenGiao", _maNguoiDaiDienBenGiao);
            else
                cm.Parameters.AddWithValue("@MaNguoiDaiDienBenGiao", DBNull.Value);
            //
            if (_maPhongBan != 0)
                cm.Parameters.AddWithValue("@MaPhongBan", _maPhongBan);
            else
                cm.Parameters.AddWithValue("@MaPhongBan", DBNull.Value);
            if (_maPhieuNhapXuatThamChieu != 0)
                cm.Parameters.AddWithValue("@MaPhieuNhapXuatThamChieu", _maPhieuNhapXuatThamChieu);
            else
                cm.Parameters.AddWithValue("@MaPhieuNhapXuatThamChieu", DBNull.Value);
            cm.Parameters.AddWithValue("@NgayXacNhan", _ngayXacNhan.DBValue);
            if (_xacNhan != false)
                cm.Parameters.AddWithValue("@XacNhan", _xacNhan);
            else
                cm.Parameters.AddWithValue("@XacNhan", DBNull.Value);
            cm.Parameters.AddWithValue("@SoCTKemTheo", _soCTKemTheo);//M
        }

        private void UpdateChildren(SqlTransaction tr)
        {
            _cT_PhieuNhapList.Update(tr, this);
            _cT_PhieuXuatList.Update(tr, this);
            if (_dinhKhoanNhapXuat.IsNew)
                _dinhKhoanNhapXuat.Insert(tr, this);
            else _dinhKhoanNhapXuat.Update(tr, this);
            _butToanPhieuNhapXuatList.Update(tr, this);
            _hoaDon_NhapXuatList.Update(tr, this);
            _nhapXuat_HopDongList.Update(tr, this);
        }
        #endregion //Data Access - Update

        #region Data Access - Delete
        internal void DeleteSelf(SqlTransaction tr)
        {
            if (!IsDirty) return;
            if (IsNew) return;
            _cT_PhieuNhapList.Clear();
            _cT_PhieuNhapList.Update(tr, this);
            _cT_PhieuXuatList.Clear();
            _cT_PhieuXuatList.Update(tr, this);
            _butToanPhieuNhapXuatList.Clear();
            _butToanPhieuNhapXuatList.Update(tr, this);
            _hoaDon_NhapXuatList.Clear();
            _hoaDon_NhapXuatList.Update(tr, this);
            _nhapXuat_HopDongList.Clear();
            _nhapXuat_HopDongList.Update(tr, this);
            ExecuteDelete(tr, new Criteria(_maPhieuNhapXuat));
            _dinhKhoanNhapXuat.DeleteSelf(tr);
            MarkNew();
        }
        #endregion //Data Access - Delete
        #endregion //Data Access
    }
}
