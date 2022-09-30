
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{
    [Serializable()]
    public class ThongTinNhanVienTinhLuongChild : Csla.ReadOnlyBase<ThongTinNhanVienTinhLuongChild>
    {
        #region Business Properties and Methods

        //declare members
        private long _maNhanVien = 0;
        private int _maBoPhan = 0;
        private DateTime _ngayTinhThamNien;
        private int _loaiNV = 0;
        private int _maCongViec = 0;
        private decimal _heSoLuongBaoHiem = 0;
        private short _cachTinhThueTNCN = 0;            
        private decimal _heSoLuongNoiBo = 0;
        private decimal _heSoLuongBoSung = 0;
        private decimal _heSoPhuCapChucVu = 0;
        private decimal _heSoVuotKhung = 0;
        private decimal _heSoBu = 0;
        private decimal _heSoDocHai = 0;
        private bool _phuCapHC = false;
        private string _maQLNhanVien = string.Empty;
        private string _tenNhanVien = string.Empty;
        private string _tenBoPhan = string.Empty;
        private int _maChucVu = 0;
        private string _tenChucVu = string.Empty;
        private int _maChucDanh = 0;
        private string _tenChucDanh = string.Empty;
        private string _tenNgachLuongCoBan = string.Empty;
        private string _tenNgachLuongNoiBo = string.Empty;
        private decimal _HeSoLuong = 0;
        private bool _TraLuongQuaTK = false;
        private int _MaNganHang = 0;
        private string _MaQLBoPhan = "";
        private decimal _LuongKhoan = 0;
        private string _SoTaiKhoan = "";
        private string _CMND = "";
        private decimal _HeSoBoSung = 0;
        private decimal _heSoVuotKhungBH = 0;
        private string _tenGioiTinh = string.Empty;
        private bool _gioiTinh = false;

        private bool _traThuLao = false;
        private bool _traPhuCap = false;
        private bool _traKhenThuong = false;
        private bool _traLuongV1 = false;
        private bool _traLuongV2 = false;
        private bool _khongTinhBaoHiem = false;

        public bool KhongTinhBaoHiem
        {
            get { return _khongTinhBaoHiem; }
            set { _khongTinhBaoHiem = value; }
        }
        public bool TraThuLao
        {
            get { return _traThuLao; }
            set { _traThuLao = value; }
        }
        public bool TraPhuCap
        {
            get { return _traPhuCap; }
            set { _traPhuCap = value; }
        }
        public bool TraKhenThuong
        {
            get { return _traKhenThuong; }
            set { _traKhenThuong = value; }
        }
        public bool TraLuongV1
        {
            get { return _traLuongV1; }
            set { _traLuongV1 = value; }
        }
        public bool TraLuongV2
        {
            get { return _traLuongV2; }
            set { _traLuongV2 = value; }
        }

             

        public bool GioiTinh
        {
            get { return _gioiTinh; }
            set { _gioiTinh = value; }
        }
        public string TenGioiTinh
        {
            get {
                if (_gioiTinh == false)
                    _tenGioiTinh = "Nữ";
                else
                    _tenGioiTinh = "Nam";
                return _tenGioiTinh; }
            
        }
        [System.ComponentModel.DataObjectField(true, false)]
        public long MaNhanVien
        {
            get
            {
                CanReadProperty("MaNhanVien", true);
                return _maNhanVien;
            }
        }

        [System.ComponentModel.DataObjectField(true, false)]
        public int MaBoPhan
        {
            get
            {
                CanReadProperty("MaBoPhan", true);
                return _maBoPhan;
            }
        }

        public DateTime NgayTinhThamNien
        {
            get
            {
                CanReadProperty("NgayTinhThamNien", true);
                return _ngayTinhThamNien;
            }
        }

        public int LoaiNV
        {
            get
            {
                CanReadProperty("LoaiNV", true);
                return _loaiNV;
            }
        }

        public int MaCongViec
        {
            get
            {
                CanReadProperty("MaCongViec", true);
                return _maCongViec;
            }
        }

        public decimal HeSoLuongBaoHiem
        {
            get
            {
                CanReadProperty("HeSoLuongBaoHiem", true);
                return _heSoLuongBaoHiem;
            }
        }

        public short CachTinhThueTNCN
        {
            get
            {
                CanReadProperty("CachTinhThueTNCN", true);
                return _cachTinhThueTNCN;
            }
        }

        public decimal HeSoLuongNoiBo
        {
            get
            {
                CanReadProperty("HeSoLuongNoiBo", true);
                return _heSoLuongNoiBo;
            }
        }

        public decimal HeSoLuongBoSung
        {
            get
            {
                CanReadProperty("HeSoLuongBoSung", true);
                return _heSoLuongBoSung;
            }
        }

        public decimal HeSoPhuCapChucVu
        {
            get
            {
                CanReadProperty("HeSoPhuCapChucVu", true);
                return _heSoPhuCapChucVu;
            }
        }

        public decimal HeSoVuotKhung
        {
            get
            {
                CanReadProperty("HeSoVuotKhung", true);
                return _heSoVuotKhung;
            }
        }

        public decimal HeSoVuotKhungBH
        {
            get
            {
                CanReadProperty("HeSoVuotKhungBH", true);
                return _heSoVuotKhungBH;
            }
        }

        public decimal HeSoBu
        {
            get
            {
                CanReadProperty("HeSoBu", true);
                return _heSoBu;
            }
        }

        public decimal HeSoDocHai
        {
            get
            {
                CanReadProperty("HeSoDocHai", true);
                return _heSoDocHai;
            }
        }

        public bool PhuCapHC
        {
            get
            {
                CanReadProperty("PhuCapHC", true);
                return _phuCapHC;
            }
        }

        public string MaQLNhanVien
        {
            get
            {
                CanReadProperty("MaQLNhanVien", true);
                return _maQLNhanVien;
            }
        }

        public string TenNhanVien
        {
            get
            {
                CanReadProperty("TenNhanVien", true);
                return _tenNhanVien;
            }
        }

        public string TenBoPhan
        {
            get
            {
                CanReadProperty("TenBoPhan", true);
                return _tenBoPhan;
            }
        }

        public int MaChucVu
        {
            get
            {
                CanReadProperty("MaChucVu", true);
                return _maChucVu;
            }
        }

        public string TenChucVu
        {
            get
            {
                CanReadProperty("TenChucVu", true);
                return _tenChucVu;
            }
        }

        public int MaChucDanh
        {
            get
            {
                CanReadProperty("MaChucDanh", true);
                return _maChucDanh;
            }
        }

        public string TenChucDanh
        {
            get
            {
                CanReadProperty("TenChucDanh", true);
                return _tenChucDanh;
            }
        }


        public string TenNgachLuongCoBan
        {
            get
            {
                CanReadProperty("TenNgachLuongCoBan", true);
                return _tenNgachLuongCoBan;
            }
        }

        public string TenNgachLuongNoiBo
        {
            get
            {
                CanReadProperty("TenNgachLuongNoiBo", true);
                return _tenNgachLuongNoiBo;
            }
        }

        public decimal HeSoLuong
        {
            get
            {
                CanReadProperty("HeSoLuong", true);
                return _HeSoLuong;
            }
        }

        public bool TraLuongQuaTK
        {
            get
            {
                CanReadProperty("TraLuongQuaTK", true);
                return _TraLuongQuaTK;
            }
        }

        public int MaNganHang
        {
            get
            {
                CanReadProperty("MaNganHang", true);
                return _MaNganHang;
            }
        }

        public decimal LuongKhoan
        {
            get
            {
                CanReadProperty();
                return _LuongKhoan;
            }
        }

        public string MaQLBoPhan
        {
            get
            {
                CanReadProperty("MaQLBoPhan", true);
                return _MaQLBoPhan;
            }
        }

        public string SoTaiKhoan
        {
            get
            {
                return _SoTaiKhoan;
            }
        }

        public string CMND
        {
            get
            {
                return _CMND;
            }
        }

        public decimal HeSoBoSung
        {
            get
            {
                return _HeSoBoSung;
            }
        }

        protected override object GetIdValue()
        {
            return string.Format("{0}:{1}", _maNhanVien, _maBoPhan);
        }

        #endregion //Business Properties and Methods

        #region Authorization Rules
        protected override void AddAuthorizationRules()
        {
            //TODO: Define authorization rules in ThongTinNhanVienTinhLuongChild
            //AuthorizationRules.AllowRead("MaNhanVien", "ThongTinNhanVienTinhLuongChildReadGroup");
            //AuthorizationRules.AllowRead("MaBoPhan", "ThongTinNhanVienTinhLuongChildReadGroup");
            //AuthorizationRules.AllowRead("NgayTinhThamNien", "ThongTinNhanVienTinhLuongChildReadGroup");
            //AuthorizationRules.AllowRead("LoaiNV", "ThongTinNhanVienTinhLuongChildReadGroup");
            //AuthorizationRules.AllowRead("MaCongViec", "ThongTinNhanVienTinhLuongChildReadGroup");
            //AuthorizationRules.AllowRead("HeSoLuongBaoHiem", "ThongTinNhanVienTinhLuongChildReadGroup");
            //AuthorizationRules.AllowRead("CachTinhThueTNCN", "ThongTinNhanVienTinhLuongChildReadGroup");
            //AuthorizationRules.AllowRead("HeSoLuongNoiBo", "ThongTinNhanVienTinhLuongChildReadGroup");
            //AuthorizationRules.AllowRead("HeSoLuongBoSung", "ThongTinNhanVienTinhLuongChildReadGroup");
            //AuthorizationRules.AllowRead("HeSoPhuCapChucVu", "ThongTinNhanVienTinhLuongChildReadGroup");
            //AuthorizationRules.AllowRead("HeSoVuotKhung", "ThongTinNhanVienTinhLuongChildReadGroup");
            //AuthorizationRules.AllowRead("HeSoBu", "ThongTinNhanVienTinhLuongChildReadGroup");
            //AuthorizationRules.AllowRead("HeSoDocHai", "ThongTinNhanVienTinhLuongChildReadGroup");
            //AuthorizationRules.AllowRead("PhuCapHC", "ThongTinNhanVienTinhLuongChildReadGroup");
            //AuthorizationRules.AllowRead("MaQLNhanVien", "ThongTinNhanVienTinhLuongChildReadGroup");
            //AuthorizationRules.AllowRead("TenNhanVien", "ThongTinNhanVienTinhLuongChildReadGroup");
            //AuthorizationRules.AllowRead("TenBoPhan", "ThongTinNhanVienTinhLuongChildReadGroup");
            //AuthorizationRules.AllowRead("MaChucVu", "ThongTinNhanVienTinhLuongChildReadGroup");
            //AuthorizationRules.AllowRead("TenChucVu", "ThongTinNhanVienTinhLuongChildReadGroup");
            //AuthorizationRules.AllowRead("TenNgachLuongCoBan", "ThongTinNhanVienTinhLuongChildReadGroup");
            //AuthorizationRules.AllowRead("TenNgachLuongNoiBo", "ThongTinNhanVienTinhLuongChildReadGroup");

        }

        #endregion //Authorization Rules

        #region Factory Methods
        internal static ThongTinNhanVienTinhLuongChild GetThongTinNhanVienTinhLuongChild(SafeDataReader dr)
        {
            return new ThongTinNhanVienTinhLuongChild(dr);
        }

        private ThongTinNhanVienTinhLuongChild(SafeDataReader dr)
        {
            Fetch(dr);
        }
        #endregion //Factory Methods


        #region Data Access

        #region Data Access - Fetch
        private void Fetch(SafeDataReader dr)
        {
            FetchObject(dr);

            //load child object(s)
            FetchChildren(dr);
        }

        private void FetchObject(SafeDataReader dr)
        {
            _maNhanVien = dr.GetInt64("MaNhanVien");
            _maBoPhan = dr.GetInt32("MaBoPhan");
            _ngayTinhThamNien = dr.GetDateTime("NgayVaoNganh");
            _loaiNV = dr.GetInt32("LoaiNV");
            _maCongViec = dr.GetInt32("MaCongViec");
            _heSoLuongBaoHiem = dr.GetDecimal("HeSoLuongBaoHiem");
            _cachTinhThueTNCN = dr.GetInt16("CachTinhThueTNCN");
            _heSoLuongNoiBo = dr.GetDecimal("HeSoLuongNoiBo");
            _heSoLuongBoSung = dr.GetDecimal("HeSoLuongBoSung");
            _heSoPhuCapChucVu = dr.GetDecimal("HeSoPhuCapChucVu");
            _heSoVuotKhung = dr.GetDecimal("HeSoVuotKhung");
            _heSoVuotKhungBH = dr.GetDecimal("HeSoVuotKhungBH");
            _heSoBu = dr.GetDecimal("HeSoBu");
            _heSoDocHai = dr.GetDecimal("HeSoDocHai");
            _phuCapHC = dr.GetBoolean("PhuCapHC");
            _maQLNhanVien = dr.GetString("MaQLNhanVien");
            _tenNhanVien = dr.GetString("TenNhanVien");
            _tenBoPhan = dr.GetString("TenBoPhan");
            _maChucVu = dr.GetInt32("MaChucVu");
            _tenChucVu = dr.GetString("TenChucVu");
            _tenNgachLuongCoBan = dr.GetString("TenNgachLuongCoBan");
            _tenNgachLuongNoiBo = dr.GetString("TenNgachLuongNoiBo");
            _HeSoLuong = dr.GetDecimal("HeSoLuong");
            _TraLuongQuaTK = dr.GetBoolean("TraLuongQuaTK");
            _MaNganHang = dr.GetInt32("MaNganHang");
            _MaQLBoPhan = dr.GetString("MaBoPhanQL");
            _LuongKhoan = dr.GetDecimal("LuongKhoan");
            _SoTaiKhoan = dr.GetString("SoTaiKhoan");
            _CMND = dr.GetString("CMND");
            _HeSoBoSung = dr.GetDecimal("HeSoLuongBoSung");
            _gioiTinh = dr.GetBoolean("GioiTinh");
            _maChucDanh = dr.GetInt32("MaChucDanh");
            _tenChucDanh = dr.GetString("TenChucDanh");
            //_traThuLao = dr.GetBoolean("ThuLao");
            //_traPhuCap = dr.GetBoolean("PhuCap");
            //_traKhenThuong = dr.GetBoolean("KhenThuong");
            //_traLuongV1 = dr.GetBoolean("LuongV2");
            //_traLuongV2 = dr.GetBoolean("LuongV2");
            _khongTinhBaoHiem = dr.GetBoolean("KhongTinhBaoHiem");
        }

        private void FetchChildren(SafeDataReader dr)
        {
        }
        #endregion //Data Access - Fetch
        #endregion //Data Access
    }
}
