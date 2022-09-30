using System;
using System.Collections.Generic;
using System.Text;
using Csla;
using Csla.Data;
using System.Data.SqlClient;
using System.Data;
//111 456
namespace ERP_Library

{
    public class ButToan:BusinessBase<ButToan>
    {
        private bool _idSet; 
        protected override object GetIdValue()
        {
            return _MaButToan;
        }

        #region Khai Bao Bien
        private int _maSoQuy = 0;

        public int MaSoQuy
        {
            get { return _maSoQuy; }
            set { _maSoQuy = value; PropertyHasChanged(); }
        }
        private int _maCongThuc = 0;
        public int MaCongThuc
        {
            get
            {
                CanReadProperty("MaCongThuc", true);
                return _maCongThuc;
            }
            set
            {
                CanWriteProperty("MaCongThuc", true);
                if (!_maCongThuc.Equals(value))
                {
                    _maCongThuc = value;
                    PropertyHasChanged("MaCongThuc");
                }
            }
        }
        int _MaButToan;
        public int MaButToan
        {
            get
            {
                CanReadProperty(true);
                return _MaButToan;
            }
            set
            {
                CanWriteProperty(true);
                if (!_MaButToan.Equals(value))
                {                   
                    _MaButToan = value;
                    PropertyHasChanged();
                }
            }
        }
        int _NoTaiKhoan;
        public int NoTaiKhoan
        {
            get
            {
                CanReadProperty(true);
                return _NoTaiKhoan;
            }
            set
            {
                CanWriteProperty(true);
                if (!_NoTaiKhoan.Equals(value))
                {
                    _NoTaiKhoan = value;
                   // _SoHieuTKNo = HeThongTaiKhoan1.GetHeThongTaiKhoan1(_NoTaiKhoan).SoHieuTK;
                    PropertyHasChanged();
                }
            }
        }
        string _SoHieuTKNo =  string.Empty;
        public String SoHieuTKNo
        {
            get
            {
                CanReadProperty(true);
                return _SoHieuTKNo;
            }
            set
            {
                CanWriteProperty(true);
                if (!_SoHieuTKNo.Equals(value))
                {
                    _SoHieuTKNo = value;
                    PropertyHasChanged();
                }
            }
        }

        string _TenTaiKhoanNo =  string.Empty;
        public String TenTaiKhoanNo
        {
            get
            {
                CanReadProperty(true);
                return _TenTaiKhoanNo;
            }
            set
            {
                CanWriteProperty(true);
                if (!_TenTaiKhoanNo.Equals(value))
                {
                    _TenTaiKhoanNo = value;
                    PropertyHasChanged();
                }
            }
        }

        int _CoTaiKhoan=0;
        public int CoTaiKhoan
        {
            get
            {
                CanReadProperty(true);
                return _CoTaiKhoan;
            }
            set
            {
                CanWriteProperty(true);
                if (!_CoTaiKhoan.Equals(value))
                {
                    _CoTaiKhoan = value;
                    PropertyHasChanged();
                }
            }
        }
        string _SoHieuTKCo=string.Empty;
        public String SoHieuTKCo
        {
            get
            {
                CanReadProperty(true);
                return _SoHieuTKCo;
            }
            set
            {
                CanWriteProperty(true);
                if (!_SoHieuTKCo.Equals(value))
                {
                    _SoHieuTKCo = value;
                    PropertyHasChanged();
                }
            }
        }

        string _TenTaiKhoanCo = string.Empty;
        public String TenTaiKhoanCo
        {
            get
            {
                CanReadProperty(true);
                return _TenTaiKhoanCo;
            }
            set
            {
                CanWriteProperty(true);
                if (!_TenTaiKhoanCo.Equals(value))
                {
                    _TenTaiKhoanCo = value;
                    PropertyHasChanged();
                }
            }
        }
        Decimal _SoTien;
        public Decimal SoTien
        {
            get
            {
                CanReadProperty(true);
                return _SoTien;
            }
            set
            {
                CanWriteProperty(true);
                if (!_SoTien.Equals(value))
                {
                    _SoTien = value;
                    PropertyHasChanged();
                }
            }
        }

        Decimal _SoTienNgoaiTe;
        public Decimal SoTienNgoaiTe
        {
            get
            {
                CanReadProperty(true);
                return _SoTienNgoaiTe;
            }
            set
            {
                CanWriteProperty(true);
                if (!_SoTienNgoaiTe.Equals(value))
                {
                    _SoTienNgoaiTe = value;
                    PropertyHasChanged();
                }
            }
        }

        String _DienGiai;
        public String DienGiai
        {
            get
            {
                CanReadProperty(true);
                return _DienGiai;
            }
            set
            {
                CanWriteProperty(true);
                if (!_DienGiai.Equals(value))
                {
                    _DienGiai = value;
                    PropertyHasChanged();
                }
            }
        }

        long _DoiTuongNo;
        public long DoiTuongNo
        {
            get
            {
                CanReadProperty(true);
                return _DoiTuongNo;
            }
            set
            {
                CanWriteProperty(true);
                if (!_DoiTuongNo.Equals(value))
                {
                    _DoiTuongNo = value;
                    PropertyHasChanged();
                }
            }
        }

        long _maNhanVien;
        public long MaNhanVien
        {
            get
            {
                CanReadProperty(true);
                return _maNhanVien;
            }
            set
            {
                CanWriteProperty(true);
                if (!_maNhanVien.Equals(value))
                {
                    _maNhanVien = value;
                    PropertyHasChanged();
                }
            }
        }
        
        long _DoiTuongCo;
        public long DoiTuongCo
        {
            get
            {
                CanReadProperty(true);
                return _DoiTuongCo;
            }
            set
            {
                CanWriteProperty(true);
                if (!_DoiTuongCo.Equals(value))
                {
                    _DoiTuongCo = value;
                    PropertyHasChanged();
                }
            }
        }

        long _maHopDong;
        public long MaHopDong
        {
            get
            {
                CanReadProperty(true);
                return _maHopDong;
            }
            set
            {
                CanWriteProperty(true);
                if (!_maHopDong.Equals(value))
                {
                    _maHopDong = value;
                    PropertyHasChanged();
                }
            }
        }

        int _IDKhoanMuc;
        public int IDKhoanMuc
        {
            get
            {
                CanReadProperty(true);
                return _IDKhoanMuc;
            }
            set
            {
                CanWriteProperty(true);
                if (!_IDKhoanMuc.Equals(value))
                {
                    _IDKhoanMuc = value;
                    PropertyHasChanged();
                }
            }
        }

        int _MaDonVi;
        public int MaDonVi
        {
            get
            {
                CanReadProperty(true);
                return _MaDonVi;
            }
            set
            {
                CanWriteProperty(true);
                if (!_MaDonVi.Equals(value))
                {
                    _MaDonVi = value;
                    PropertyHasChanged();
                }
            }
        }

        private Guid _oidMaBienLai = Guid.Empty;
        private Guid _oidChiTietBienLai = Guid.Empty;
        private int _iDBienLai = 0;
        private long _iDChiTietBienLai = 0;
        private byte _KieuThuPhi = 0;

        public Guid OidMaBienLai
        {
            get
            {
                CanReadProperty("OidMaBienLai", true);
                return _oidMaBienLai;
            }
            set
            {
                CanWriteProperty("OidMaBienLai", true);
                if (!_oidMaBienLai.Equals(value))
                {
                    _oidMaBienLai = value;
                    PropertyHasChanged("OidMaBienLai");
                }
            }
        }

        public Guid OidChiTietBienLai
        {
            get
            {
                CanReadProperty("OidChiTietBienLai", true);
                return _oidChiTietBienLai;
            }
            set
            {
                CanWriteProperty("OidChiTietBienLai", true);
                if (!_oidChiTietBienLai.Equals(value))
                {
                    _oidChiTietBienLai = value;
                    PropertyHasChanged("OidChiTietBienLai");
                }
            }
        }

        public int IDBienLai
        {
            get
            {
                CanReadProperty("IDBienLai", true);
                return _iDBienLai;
            }
            set
            {
                CanWriteProperty("IDBienLai", true);
                if (!_iDBienLai.Equals(value))
                {
                    _iDBienLai = value;
                    PropertyHasChanged("IDBienLai");
                }
            }
        }

        public long IDChiTietBienLai
        {
            get
            {
                CanReadProperty("IDChiTietBienLai", true);
                return _iDChiTietBienLai;
            }
            set
            {
                CanWriteProperty("IDChiTietBienLai", true);
                if (!_iDChiTietBienLai.Equals(value))
                {
                    _iDChiTietBienLai = value;
                    PropertyHasChanged("IDChiTietBienLai");
                }
            }
        }

        public byte KieuThuPhi
        {
            get
            {
                CanReadProperty("KieuThuPhi", true);
                return _KieuThuPhi;
            }
            set
            {
                CanWriteProperty("KieuThuPhi", true);
                if (!_KieuThuPhi.Equals(value))
                {
                    _KieuThuPhi = value;
                    PropertyHasChanged("KieuThuPhi");
                }
            }
        }

        string _soHoaDonThamChieu = string.Empty;
        public String SoHoaDonThamChieu
        {
            get
            {
                CanReadProperty(true);
                return _soHoaDonThamChieu;
            }
            set
            {
                CanWriteProperty(true);
                if (!_soHoaDonThamChieu.Equals(value))
                {
                    _soHoaDonThamChieu = value;
                    PropertyHasChanged();
                }
            }
        }

        ChungTu_ChiPhiSanXuatList _chungTu_ChiPhiSanXuatList = ChungTu_ChiPhiSanXuatList.NewChungTu_ChiPhiSanXuatList();
        public ChungTu_ChiPhiSanXuatList ChungTuChiPhiSanXuatList
        {
            get
            {
                CanReadProperty(true);
                return _chungTu_ChiPhiSanXuatList;
            }
            set
            {
                CanWriteProperty(true);
                if (!_chungTu_ChiPhiSanXuatList.Equals(value))
                {
                    _chungTu_ChiPhiSanXuatList = value;
                    PropertyHasChanged();
                }
            }
        }
        ButtoanMucNganSachList _MucNganSach = ButtoanMucNganSachList.NewButtoanMucNganSachList();
        public ButtoanMucNganSachList MucNganSach
        {
            get
            {
                CanReadProperty(true);
                return _MucNganSach;
            }
            set
            {
                CanWriteProperty(true);
                if (!_MucNganSach.Equals(value))
                {
                    _MucNganSach = value;
                    PropertyHasChanged();
                }
            }
        }

        ChiTietButToanList _ChiTietButToanList = ChiTietButToanList.NewChiTietButToanList();
        public ChiTietButToanList ChiTietButToanList
        {
            get
            {
                CanReadProperty(true);
                return _ChiTietButToanList;
            }
            set
            {
                CanWriteProperty(true);
                if (!_ChiTietButToanList.Equals(value))
                {
                    _ChiTietButToanList = value;
                    PropertyHasChanged();
                }
            }
        }
        ButToan_ChiPhiHD _butToanChiPhiHD = ButToan_ChiPhiHD.NewButToan_ChiPhiHD();

        public ButToan_ChiPhiHD ButToanChiPhiHD
        {
            get { CanReadProperty(true); return _butToanChiPhiHD; }
            set { _butToanChiPhiHD = value; PropertyHasChanged(); }
        }

        ChungTu_HoaDonList _ChungTu_HoaDonList = ChungTu_HoaDonList.NewChungTu_HoaDonList();
        public ChungTu_HoaDonList ChungTu_HoaDonList
        {
            get
            {
                CanReadProperty(true);
                return _ChungTu_HoaDonList;
            }
            set
            {
                CanWriteProperty(true);
                if (!_ChungTu_HoaDonList.Equals(value))
                {
                    _ChungTu_HoaDonList = value;
                    PropertyHasChanged();
                }
            }
        }
        #endregion       

        #region Constructor

        private ButToan( int maButToan)
        {
            _CoTaiKhoan = 0;
            _NoTaiKhoan = 0;
            _DienGiai = String.Empty;
            //_DinhKhoan = 0;
            _DoiTuongCo = 0;
            _DoiTuongNo = 0;
            _MaButToan = maButToan;
            _SoTien = 0;
            ValidationRules.CheckRules();
            MarkAsChild();
        }

        private ButToan()
        {
            _CoTaiKhoan = 0;
            _NoTaiKhoan = 0;
            _DienGiai = String.Empty;
            _DoiTuongCo = 0;
            _DoiTuongNo = 0;
            _SoTien = 0;
            ValidationRules.CheckRules();
            MarkAsChild();
        }
       
        #endregion     

        #region Override
        public override bool IsDirty
        {
            get
            {
                return base.IsDirty || _MucNganSach.IsDirty||_butToanChiPhiHD.IsDirty||_chungTu_ChiPhiSanXuatList.IsDirty
                                    || _ChungTu_HoaDonList.IsDirty;
            }
        }
        public override bool IsValid
        {
            get
            {
                return base.IsValid && _MucNganSach.IsValid ||_butToanChiPhiHD.IsValid||_chungTu_ChiPhiSanXuatList.IsValid
                    && _ChungTu_HoaDonList.IsValid;
            }
        }
        #endregion

        #region Static Methods
        public override ButToan Save()
        {
            return base.Save();
        }

        public void DeleteSelf(SqlTransaction tr)
        {
            DataPortal_Delete(tr);
        }
        public void Insert(SqlTransaction tr)
        {
            //if (!IsDirty) return;
            DataPortal_Insert(tr);
        }

        public void Update(SqlTransaction tr)
        {
            //if (!IsDirty) return;

            //if (base.IsDirty)
            //{
                DataPortal_Update(tr);				
			//}
          
        }

        private ButToan(SafeDataReader dr ,int loai)
        {
            try
            {
                MarkAsChild();
                if (loai == 1)
                    _MaButToan = dr.GetInt32("MaButToan");
                else
                {
                    _DienGiai = dr.GetString("DienGiai");
                }
                MarkOld();
            }
            catch (Exception ee)
            {
                throw ee;
            }
        }
      
        private ButToan(SafeDataReader dr)
        {
            try
            {
                MarkAsChild();
                _MaButToan = dr.GetInt32("MaButToan");
                _NoTaiKhoan = dr.GetInt32("NoTaiKhoan");
                _CoTaiKhoan = dr.GetInt32("CoTaiKhoan");
                _SoTien = dr.GetDecimal("SoTien");
                _DienGiai = dr.GetString("DienGiai");
                _DoiTuongNo = dr.GetInt64("MaDoiTuongNo");
                _DoiTuongCo = dr.GetInt64("MaDoiTuongCo");
                _SoHieuTKCo = dr.GetString("SoHieuTKCo");
                _TenTaiKhoanCo = dr.GetString("TenTaiKhoanCo");
                _SoHieuTKNo = dr.GetString("SoHieuTKNo");
                _TenTaiKhoanNo = dr.GetString("TenTaiKhoanNo");
                _maHopDong = dr.GetInt64("MaHopDong");
                _IDKhoanMuc = dr.GetInt32("IDKhoanMuc");
                _MaDonVi = dr.GetInt32("MaDonVi");

                _oidMaBienLai = dr.GetGuid("OidMaBienLai");
                _oidChiTietBienLai = dr.GetGuid("OidChiTietBienLai");
                _iDBienLai = dr.GetInt32("IDBienLai");
                _iDChiTietBienLai = dr.GetInt64("IDChiTietBienLai");
                _KieuThuPhi = dr.GetByte("KieuThuPhi");

                _maNhanVien = dr.GetInt64("MaNhanVien");
                _SoTienNgoaiTe = dr.GetDecimal("SoTienNgoaiTe");
                _soHoaDonThamChieu = dr.GetString("SoHoaDonThamChieu");

                FetchChildren(this._MaButToan);
                _idSet = true;
                //_DinhKhoan = dr.GetInt32("MaDinhKhoan");                

                MarkOld();
            }
            catch (Exception ee)
            {
                throw ee;
            }
        }

        private ButToan(SafeDataReader dr, bool ghiMucNganSach, int loai)
        {
            try
            {
                MarkAsChild();
                _MaButToan = dr.GetInt32("MaButToan");
                _NoTaiKhoan = dr.GetInt32("NoTaiKhoan");
                _CoTaiKhoan = dr.GetInt32("CoTaiKhoan");
                _SoTien = dr.GetDecimal("SoTien");
                _DienGiai = dr.GetString("DienGiai");
                _DoiTuongNo = dr.GetInt64("MaDoiTuongNo");
                _DoiTuongCo = dr.GetInt64("MaDoiTuongCo");
                _SoHieuTKCo = dr.GetString("SoHieuTKCo");
                _TenTaiKhoanCo = dr.GetString("TenTaiKhoanCo");
                _SoHieuTKNo = dr.GetString("SoHieuTKNo");
                _TenTaiKhoanNo = dr.GetString("TenTaiKhoanNo");
                _maHopDong = dr.GetInt64("MaHopDong");
                _IDKhoanMuc = dr.GetInt32("IDKhoanMuc");
                _MaDonVi = dr.GetInt32("MaDonVi");

                _oidMaBienLai = dr.GetGuid("OidMaBienLai");
                _oidChiTietBienLai = dr.GetGuid("OidChiTietBienLai");
                _iDBienLai = dr.GetInt32("IDBienLai");
                _iDChiTietBienLai = dr.GetInt64("IDChiTietBienLai");
                _KieuThuPhi = dr.GetByte("KieuThuPhi");

                _maNhanVien = dr.GetInt64("MaNhanVien");
                _SoTienNgoaiTe = dr.GetDecimal("SoTienNgoaiTe");
                _soHoaDonThamChieu = dr.GetString("SoHoaDonThamChieu");

                FetchChildren(this._MaButToan, ghiMucNganSach);
                _idSet = true;
                //_DinhKhoan = dr.GetInt32("MaDinhKhoan");                

                MarkOld();
            }
            catch (Exception ee)
            {
                throw ee;
            }
        }

        private ButToan(SafeDataReader dr,bool edit)
        {
            try
            {
                MarkAsChild();
                _MaButToan = dr.GetInt32("MaButToan");
                _NoTaiKhoan = dr.GetInt32("NoTaiKhoan");
                _CoTaiKhoan = dr.GetInt32("CoTaiKhoan");
                _SoTien = dr.GetDecimal("SoTien");
                _DienGiai = dr.GetString("DienGiai");
                _DoiTuongNo = dr.GetInt64("MaDoiTuongNo");
                _DoiTuongCo = dr.GetInt64("MaDoiTuongCo");
                _SoHieuTKCo = dr.GetString("SoHieuTKCo");
                _TenTaiKhoanCo = dr.GetString("TenTaiKhoanCo");
                _SoHieuTKNo = dr.GetString("SoHieuTKNo");
                _TenTaiKhoanNo = dr.GetString("TenTaiKhoanNo");
                _maHopDong = dr.GetInt64("MaHopDong");
                _IDKhoanMuc = dr.GetInt32("IDKhoanMuc");
                _MaDonVi = dr.GetInt32("MaDonVi");

                _oidMaBienLai = dr.GetGuid("OidMaBienLai");
                _oidChiTietBienLai = dr.GetGuid("OidChiTietBienLai");
                _iDBienLai = dr.GetInt32("IDBienLai");
                _iDChiTietBienLai = dr.GetInt64("IDChiTietBienLai");
                _KieuThuPhi = dr.GetByte("KieuThuPhi");
                _maNhanVien = dr.GetInt64("MaNhanVien");
                _SoTienNgoaiTe = dr.GetDecimal("SoTienNgoaiTe");
                _soHoaDonThamChieu = dr.GetString("SoHoaDonThamChieu");

                FetchChildrenByLoc(this._MaButToan);
                _idSet = true;
                //_DinhKhoan = dr.GetInt32("MaDinhKhoan");                

                MarkOld();
            }
            catch (Exception ee)
            {
                throw ee;
            }
        }


        private ButToan(TaiKhoanKetChuyen _taiKhoanKetChuyen)
        {
            _SoTien = _taiKhoanKetChuyen.SoTien;
            if (_taiKhoanKetChuyen.KetChuyenNoCo == 1)
            {
                _NoTaiKhoan = _taiKhoanKetChuyen.MaTaiKhoanKC;
                _CoTaiKhoan = _taiKhoanKetChuyen.MaTaiKhoanNhanKC;
            }
            else if (_taiKhoanKetChuyen.KetChuyenNoCo == 2)
            {
                _CoTaiKhoan = _taiKhoanKetChuyen.MaTaiKhoanKC;
                _NoTaiKhoan = _taiKhoanKetChuyen.MaTaiKhoanNhanKC;
            }
            else if (_taiKhoanKetChuyen.KetChuyenNoCo == 3)
            {
                if (_taiKhoanKetChuyen.SoTien > 0)
                {
                    _CoTaiKhoan = _taiKhoanKetChuyen.MaTaiKhoanKC;
                    _NoTaiKhoan = _taiKhoanKetChuyen.MaTaiKhoanNhanKC;
                }
                else
                {
                    _NoTaiKhoan = _taiKhoanKetChuyen.MaTaiKhoanKC;
                    _CoTaiKhoan = _taiKhoanKetChuyen.MaTaiKhoanNhanKC;
                    _SoTien = -_taiKhoanKetChuyen.SoTien;
                }

            }
            else
            {

            }
            _maCongThuc = _taiKhoanKetChuyen.MaCongThucKC;
            _DienGiai = String.Empty;
            MarkAsChild();
        }


        public static ButToan NewButToan(int maButToan)
        {
            return new ButToan(maButToan);
        }

        public static ButToan NewButToan()
        {
            return new ButToan();
        }

        public static ButToan NewButToan( int noTaiKhoan, int coTaiKhoan, 
            Decimal soTien, String  dienGiai, long doiTuongNo, long doiTuongCo)
        {
            ButToan bt = new ButToan(0);            
            bt.NoTaiKhoan = noTaiKhoan;
            bt.CoTaiKhoan = coTaiKhoan;
            bt.SoTien = soTien;
            bt.DoiTuongNo = doiTuongNo;
            bt.DoiTuongCo = doiTuongCo;
            bt.DienGiai = dienGiai;
            //bt.DinhKhoan = dinhKhoan;
            bt.MarkNew();            
            return bt;
        }

        public static ButToan NewButToan(TaiKhoanKetChuyen _taiKhoanKetChuyen)
        {
            return new ButToan(_taiKhoanKetChuyen);
        }

        public static ButToan GetButToanByMaChungTu(long maChungTu)
        {
            return (ButToan)DataPortal.Fetch<ButToan>(new CriteriaByMaChungTu(maChungTu));
        }

        public static ButToan GetButToan(int maButToan)
        {
            return (ButToan)DataPortal.Fetch<ButToan>(new Criteria(maButToan));
        }

        internal static ButToan GetButToan(SafeDataReader dr)
        {
            return new ButToan(dr);            
        }

        internal static ButToan GetButToan_New(SafeDataReader dr, bool ghiMucNganSach)
        {
            return new ButToan(dr, ghiMucNganSach,1);
        }

        internal static ButToan GetButToan(SafeDataReader dr, int loai)
        {
            return new ButToan(dr,loai);
        }

        internal static ButToan GetButToanByLoc(SafeDataReader dr,bool edit)
        {
            return new ButToan(dr,true);
        }
        internal static ButToan GetButToanBySoQuy(SafeDataReader dr)
        {
            ButToan child = ButToan.NewButToan(0);
            child._MaButToan = dr.GetInt32("MaButToan");
            child._NoTaiKhoan = dr.GetInt32("NoTaiKhoan");
            child._CoTaiKhoan = dr.GetInt32("CoTaiKhoan");
            child._SoTien = dr.GetDecimal("SoTien");
            child._DienGiai = dr.GetString("DienGiai");
            child._DoiTuongNo = dr.GetInt64("MaDoiTuongNo");
            child._DoiTuongCo = dr.GetInt64("MaDoiTuongCo");
            child._SoHieuTKCo = dr.GetString("SoHieuTKCo");
            child._TenTaiKhoanCo = dr.GetString("TenTaiKhoanCo");
            child._SoHieuTKNo = dr.GetString("SoHieuTKNo");
            child._TenTaiKhoanNo = dr.GetString("TenTaiKhoanNo");
            child._maSoQuy = dr.GetInt32("MaSoQuy");
            child._maHopDong = dr.GetInt64("MaHopDong");
            child._IDKhoanMuc = dr.GetInt32("IDKhoanMuc");
            child._MaDonVi = dr.GetInt32("MaDonVi");

            child._oidMaBienLai = dr.GetGuid("OidMaBienLai");
            child._oidChiTietBienLai = dr.GetGuid("OidChiTietBienLai");
            child._iDBienLai = dr.GetInt32("IDBienLai");
            child._iDChiTietBienLai = dr.GetInt64("IDChiTietBienLai");
            child._KieuThuPhi = dr.GetByte("KieuThuPhi");
            child._soHoaDonThamChieu = dr.GetString("SoHoaDonThamChieu");

            child.MarkOld();
            //child.MarkOld();
            return child;
        }
        public static void DeleteButToan(int maButToan)
        {
            DataPortal.Delete(new Criteria(maButToan));
        }
        
        #endregion

        #region Criteria

        [Serializable()]
        private class Criteria
        {
            // Add criteria here
            public int MaButToan;

            public Criteria(int maButToan)
            {
                MaButToan = maButToan;
            }            

        }
        private class CriteriaByMaChungTu
        {
            // Add criteria here
            public long MaChungTu;

            public CriteriaByMaChungTu(long maChungTu)
            {
                MaChungTu = maChungTu;
            }

        }
        #endregion

        #region Data Access
        public void UpdateButToanSoQuy(int maButToan, int maSoQuy)
        {
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spdUpdateButToan_SoQuy";
                    cm.Parameters.AddWithValue("@MaButToan", maButToan);
                    if (maSoQuy != 0)
                        cm.Parameters.AddWithValue("@MaSoQuy", maSoQuy);
                    else
                        cm.Parameters.AddWithValue("@MaSoQuy", DBNull.Value);
                    cm.ExecuteNonQuery();
                }
            }

        }
        protected override void DataPortal_Fetch(object criteria)
        {

            // Load object data from database

            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    if (criteria is Criteria)
                    {
                        cm.CommandType = CommandType.StoredProcedure;
                        cm.CommandText = "spd_LoadMaCaBiet_ButToan";
                        cm.Parameters.AddWithValue("@MaButToan", ((Criteria)criteria).MaButToan);

                        using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                        {
                            while (dr.Read())
                            {
                                _MaButToan = dr.GetInt32("MaButToan");
                                _NoTaiKhoan = dr.GetInt32("NoTaiKhoan");
                                _CoTaiKhoan = dr.GetInt32("CoTaiKhoan");
                                _SoTien = dr.GetDecimal("SoTien");
                                _DienGiai = dr.GetString("DienGiai");
                                _DoiTuongNo = dr.GetInt32("MaDoiTuongNo");
                                _DoiTuongCo = dr.GetInt32("MaDoiTuongCo");
                                _soHoaDonThamChieu = dr.GetString("soHoaDonThamChieu");
                                //_DinhKhoan = dr.GetInt32("MaDinhKhoan");                                               

                                // load child objects
                                FetchChildren(this.MaButToan);
                                dr.NextResult();
                                _idSet = true;
                            }
                        }

                        
                    }
                    else if (criteria is CriteriaByMaChungTu)
                    {
                        cm.CommandType = CommandType.StoredProcedure;
                        cm.CommandText = "spd_LoadButToanListByMaChungTu";
                        cm.Parameters.AddWithValue("@MaChungTu", ((CriteriaByMaChungTu)criteria).MaChungTu);

                        using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                        {
                            while (dr.Read())
                            {
                                _MaButToan = dr.GetInt32("MaButToan");
                                _NoTaiKhoan = dr.GetInt32("NoTaiKhoan");
                                _CoTaiKhoan = dr.GetInt32("CoTaiKhoan");
                                _SoTien = dr.GetDecimal("SoTien");
                                _DienGiai = dr.GetString("DienGiai");
                                _soHoaDonThamChieu = dr.GetString("soHoaDonThamChieu");
                                //_DoiTuongNo = dr.GetInt32("MaDoiTuongNo");
                                //_DoiTuongCo = dr.GetInt32("MaDoiTuongCo");
                            }
                        }
                    }
                    MarkOld();
                }
            }
        }
        private void FetchChildren(int MaButToan)
        {
             _MucNganSach = ButtoanMucNganSachList.GetButtoanMucNganSachListByMaButToan(MaButToan);          
            //_ChiTietButToanList = ChiTietButToanList.GetChiTietButToanList(MaButToan);
            _butToanChiPhiHD = ButToan_ChiPhiHD.GetButToan_ChiPhiHDByButToan(MaButToan);
            _chungTu_ChiPhiSanXuatList = ChungTu_ChiPhiSanXuatList.GetChungTu_ChiPhiSanXuatByButToanList(MaButToan);
            _ChungTu_HoaDonList = ERP_Library.ChungTu_HoaDonList.GetChungTu_HoaDonList(MaButToan);

        }
        private void FetchChildren(int MaButToan,bool ghiMucNganSach)
        {
            if (ghiMucNganSach == true)
            {
                _MucNganSach = ButtoanMucNganSachList.GetButtoanMucNganSachListByMaButToan(MaButToan);
            }
            //_ChiTietButToanList = ChiTietButToanList.GetChiTietButToanList(MaButToan);
            _butToanChiPhiHD = ButToan_ChiPhiHD.GetButToan_ChiPhiHDByButToan(MaButToan);
            _chungTu_ChiPhiSanXuatList = ChungTu_ChiPhiSanXuatList.GetChungTu_ChiPhiSanXuatByButToanList(MaButToan);
            _ChungTu_HoaDonList = ERP_Library.ChungTu_HoaDonList.GetChungTu_HoaDonList(MaButToan);

        }
        private void FetchChildrenByLoc(int MaButToan)
        {
            //_MucNganSach = ButtoanMucNganSachList.GetButtoanMucNganSachListByMaButToan(MaButToan);
            //_ChiTietButToanList = ChiTietButToanList.GetChiTietButToanList(MaButToan);
            //_butToanChiPhiHD = ButToan_ChiPhiHD.GetButToan_ChiPhiHDByButToan(MaButToan);
            //_chungTu_ChiPhiSanXuatList = ChungTu_ChiPhiSanXuatList.GetChungTu_ChiPhiSanXuatByButToanList(MaButToan);
            _ChungTu_HoaDonList = ERP_Library.ChungTu_HoaDonList.GetChungTu_HoaDonList(MaButToan);

        }
        //[Transactional(TransactionalTypes.TransactionScope)]
        protected void DataPortal_Insert( SqlTransaction tr)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                try
                {
                    _SoHieuTKNo = HeThongTaiKhoan1.GetHeThongTaiKhoan1(_NoTaiKhoan).SoHieuTK;
                    _SoHieuTKCo = HeThongTaiKhoan1.GetHeThongTaiKhoan1(_CoTaiKhoan).SoHieuTK;
                    cm.Transaction = tr;

                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_Insert_Buttoan";
                    cm.Parameters.AddWithValue("@MaButToan", 0).Direction = ParameterDirection.Output;
                    if (_NoTaiKhoan ==0)
                    {
                        cm.Parameters.AddWithValue("@NoTaiKhoan", DBNull.Value);
                    }
                    else
                    {
                        cm.Parameters.AddWithValue("@NoTaiKhoan", _NoTaiKhoan);
                    }
                    if (_CoTaiKhoan == 0)
                    {
                        cm.Parameters.AddWithValue("@CoTaiKhoan", DBNull.Value); ;
                    }
                    else
                    {
                        cm.Parameters.AddWithValue("@CoTaiKhoan", _CoTaiKhoan); ;
                    }

                    cm.Parameters.AddWithValue("@SoTien", _SoTien);

                    if (_SoTienNgoaiTe != 0)
                        cm.Parameters.AddWithValue("@SoTienNgoaiTe", _SoTienNgoaiTe);
                    else
                        cm.Parameters.AddWithValue("@SoTienNgoaiTe", DBNull.Value);

                    cm.Parameters.AddWithValue("@DienGiai", _DienGiai);

                    if (_DoiTuongNo == 0)
                    {
                        cm.Parameters.AddWithValue("@MaDoiTuongNo", DBNull.Value); ;
                    }
                    else
                    {
                        cm.Parameters.AddWithValue("@MaDoiTuongNo", _DoiTuongNo);
                    }
                    if (_DoiTuongCo == 0)
                    {
                        cm.Parameters.AddWithValue("@MaDoiTuongCo", DBNull.Value);
                    }
                    else cm.Parameters.AddWithValue("@MaDoiTuongCo", _DoiTuongCo);
                    if (_maHopDong != 0)
                        cm.Parameters.AddWithValue("@MaHopDong", _maHopDong);
                    else
                        cm.Parameters.AddWithValue("@MaHopDong", DBNull.Value);

                    if (_IDKhoanMuc != 0)
                        cm.Parameters.AddWithValue("@IDKhoanMuc", _IDKhoanMuc);
                    else
                        cm.Parameters.AddWithValue("@IDKhoanMuc", DBNull.Value);

                    if (_MaDonVi != 0)
                        cm.Parameters.AddWithValue("@MaDonVi", _MaDonVi);
                    else
                        cm.Parameters.AddWithValue("@MaDonVi", DBNull.Value);

                    if (_oidMaBienLai != Guid.Empty)
                        cm.Parameters.AddWithValue("@OidMaBienLai", _oidMaBienLai);
                    else
                        cm.Parameters.AddWithValue("@OidMaBienLai", DBNull.Value);
                    if (_oidChiTietBienLai != Guid.Empty)
                        cm.Parameters.AddWithValue("@OidChiTietBienLai", _oidChiTietBienLai);
                    else
                        cm.Parameters.AddWithValue("@OidChiTietBienLai", DBNull.Value);
                    if (_iDBienLai != 0)
                        cm.Parameters.AddWithValue("@IDBienLai", _iDBienLai);
                    else
                        cm.Parameters.AddWithValue("@IDBienLai", DBNull.Value);
                    if (_iDChiTietBienLai != 0)
                        cm.Parameters.AddWithValue("@IDChiTietBienLai", _iDChiTietBienLai);
                    else
                        cm.Parameters.AddWithValue("@IDChiTietBienLai", DBNull.Value);
                    if (_KieuThuPhi != 0)
                        cm.Parameters.AddWithValue("@KieuThuPhi", _KieuThuPhi);
                    else
                        cm.Parameters.AddWithValue("@KieuThuPhi", DBNull.Value);
                    if (_maNhanVien != 0)
                        cm.Parameters.AddWithValue("@MaNhanVien", _maNhanVien);
                    else
                        cm.Parameters.AddWithValue("@MaNhanVien", DBNull.Value);

                    if (_soHoaDonThamChieu.Length > 0)
                        cm.Parameters.AddWithValue("@soHoaDonThamChieu", _soHoaDonThamChieu);
                    else
                        cm.Parameters.AddWithValue("@soHoaDonThamChieu", DBNull.Value);

                    cm.Parameters.AddWithValue("@MaDinhKhoan", ((ButToanList)this.Parent)._MaDinhKhoan);
                    cm.Parameters.AddWithValue("@MaCongTy", ERP_Library.Security.CurrentUser.Info.MaCongTy);
                    cm.ExecuteNonQuery();
                    _MaButToan = (int)cm.Parameters["@MaButToan"].Value;
                    _MucNganSach._MaButToan = _MaButToan;                                       
                    UpdateChildren(tr);
                    this.MarkOld();
                    _idSet = true;
                    _butToanChiPhiHD.Insert(tr, this);
                    _chungTu_ChiPhiSanXuatList.DataPortal_Update(tr,0,string.Empty,_MaButToan);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

            }
        }

        protected  void DataPortal_Update(SqlTransaction tr)
        {   
            using (SqlCommand cm =  tr.Connection.CreateCommand())
            {
                try
                {
                    cm.Transaction = tr;
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_Update_Buttoan";
                    cm.Parameters.AddWithValue("@MaButToan", _MaButToan);
                    if (_NoTaiKhoan == 0)
                    {
                        cm.Parameters.AddWithValue("@NoTaiKhoan", DBNull.Value);
                    }
                    else
                    {
                        cm.Parameters.AddWithValue("@NoTaiKhoan", _NoTaiKhoan);
                    }
                    if (_CoTaiKhoan == 0)
                    {
                        cm.Parameters.AddWithValue("@CoTaiKhoan", DBNull.Value);
                    }
                    else
                    {
                        cm.Parameters.AddWithValue("@CoTaiKhoan", _CoTaiKhoan);
                    }

                    cm.Parameters.AddWithValue("@SoTien", _SoTien);
                    if (_SoTienNgoaiTe != 0)
                        cm.Parameters.AddWithValue("@SoTienNgoaiTe", _SoTienNgoaiTe);
                    else
                        cm.Parameters.AddWithValue("@SoTienNgoaiTe", DBNull.Value);
                    cm.Parameters.AddWithValue("@DienGiai", _DienGiai);
                    if (_DoiTuongNo == 0)
                    {
                        cm.Parameters.AddWithValue("@MaDoiTuongNo", DBNull.Value);
                    }
                    else
                    {
                        cm.Parameters.AddWithValue("@MaDoiTuongNo", _DoiTuongNo);
                    }
                    if (_DoiTuongCo == 0)
                    {
                        cm.Parameters.AddWithValue("@MaDoiTuongCo", DBNull.Value);
                    }
                    else cm.Parameters.AddWithValue("@MaDoiTuongCo", _DoiTuongCo);
                    cm.Parameters.AddWithValue("@MaDinhKhoan", ((ButToanList)this.Parent)._MaDinhKhoan);
                    if(_maHopDong != 0)
                        cm.Parameters.AddWithValue("@MaHopDong", _maHopDong);
                    else
                        cm.Parameters.AddWithValue("@MaHopDong", DBNull.Value);
                    if (_IDKhoanMuc != 0)
                        cm.Parameters.AddWithValue("@IDKhoanMuc", _IDKhoanMuc);
                    else
                        cm.Parameters.AddWithValue("@IDKhoanMuc", DBNull.Value);

                    if (_MaDonVi != 0)
                        cm.Parameters.AddWithValue("@MaDonVi", _MaDonVi);
                    else
                        cm.Parameters.AddWithValue("@MaDonVi", DBNull.Value);

                    if (_oidMaBienLai != Guid.Empty)
                        cm.Parameters.AddWithValue("@OidMaBienLai", _oidMaBienLai);
                    else
                        cm.Parameters.AddWithValue("@OidMaBienLai", DBNull.Value);
                    if (_oidChiTietBienLai != Guid.Empty)
                        cm.Parameters.AddWithValue("@OidChiTietBienLai", _oidChiTietBienLai);
                    else
                        cm.Parameters.AddWithValue("@OidChiTietBienLai", DBNull.Value);
                    if (_iDBienLai != 0)
                        cm.Parameters.AddWithValue("@IDBienLai", _iDBienLai);
                    else
                        cm.Parameters.AddWithValue("@IDBienLai", DBNull.Value);
                    if (_iDChiTietBienLai != 0)
                        cm.Parameters.AddWithValue("@IDChiTietBienLai", _iDChiTietBienLai);
                    else
                        cm.Parameters.AddWithValue("@IDChiTietBienLai", DBNull.Value);
                    if (_KieuThuPhi != 0)
                        cm.Parameters.AddWithValue("@KieuThuPhi", _KieuThuPhi);
                    else
                        cm.Parameters.AddWithValue("@KieuThuPhi", DBNull.Value);
                    if (_maNhanVien != 0)
                        cm.Parameters.AddWithValue("@MaNhanVien", _maNhanVien);
                    else
                        cm.Parameters.AddWithValue("@MaNhanVien", DBNull.Value);

                    if (_soHoaDonThamChieu.Length > 0)
                        cm.Parameters.AddWithValue("@soHoaDonThamChieu", _soHoaDonThamChieu);
                    else
                        cm.Parameters.AddWithValue("@soHoaDonThamChieu", DBNull.Value);

                    cm.ExecuteNonQuery();

                    _MucNganSach._MaButToan = _MaButToan;
                    //_MucNganSach.ApplyEdit();
                    //_MucNganSach.DataPortal_Update(tr);                    
                    //_MucNganSach.Save();
                    UpdateChildren(tr);
                    this.MarkOld();
                    //_ChungTu_HoaDonList = ChungTu_HoaDonList.GetChungTu_HoaDonList(_MaButToan);
                    //if ((SoHieuTKCo.Contains("3113") == false || SoHieuTKNo.Contains("3113") == false) && _ChungTu_HoaDonList.Count != 0)
                   // {
                    //    foreach (ChungTu_HoaDon cthd in _ChungTu_HoaDonList)
                    //    {
                    //        cthd.Delete();
                    //    }
                    //}
                    _butToanChiPhiHD.Update(tr, this);
                    _chungTu_ChiPhiSanXuatList.DataPortal_Update(tr, 0, string.Empty, _MaButToan);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        private void UpdateChildren(SqlTransaction tr)
        {
            _MucNganSach.DataPortal_Update(tr);
            _ChiTietButToanList.Update(tr, this);
            _ChungTu_HoaDonList.Update(tr, this);
        }


        protected void DataPortal_Delete(SqlTransaction tr)
        {
            
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {                
                _ChiTietButToanList.Clear();
                _MucNganSach.DataPortal_Delete(tr); ;
                _chungTu_ChiPhiSanXuatList.DataPortal_Delete(tr);
                _ChungTu_HoaDonList.Clear();
               UpdateChildren(tr);
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_Delete_ButToan";
                cm.Parameters.AddWithValue("@MaButToan", this.MaButToan);
                cm.ExecuteNonQuery();
             
            }
        }

        protected override void DataPortal_DeleteSelf()
        {
           
            DataPortal_Delete(new Criteria(_MaButToan));
        }     

        #endregion
    }

}
