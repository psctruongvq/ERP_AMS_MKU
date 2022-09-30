
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{
    [Serializable()]
    public class XuatDuLieu : Csla.BusinessBase<XuatDuLieu>
    {
        #region Business Properties and Methods

        //declare members
        private string _soChungTu = string.Empty;
        private string _soHoaDon = string.Empty;
        private DateTime _ngayLap = DateTime.Today;
        private decimal _soTien = 0;
        private decimal _tiGiaQuyDoi = 0;
        private decimal _thanhTien = 0;
        private string _dienGiai = string.Empty;
        private string _maLoaiChungTu = string.Empty;
        private string _tkno = string.Empty;
        private string _tKCo = string.Empty;
        private decimal _soTienBT = 0;
        private string _dienGiaiBT = string.Empty;
        private string _maTieuMuc = string.Empty;
        private decimal _soTienTieuMuc = 0;
        private string _dienGiaiMuc = string.Empty;
        private string _maMucNganSachQL = string.Empty;
        private string _tenDoiTuongNo = string.Empty;
        private string _tenTaiKhoan = string.Empty;
        private string _dCDoiTuongNo = string.Empty;
        private string _kHNgoai = string.Empty;
        private string _dCNgoai = string.Empty;
        private string _tenBoPhan = string.Empty;
        private string _tenDangNhap = string.Empty;
        private string _tenDoiTuongThuChi = string.Empty;
        private DateTime _ngayThucHien = DateTime.Today;
        private string _maQLDoiTuongNo = string.Empty;
        private string _maQLDoiTuongCo = string.Empty;
        private string _tenDoiTuongCo = string.Empty;
        private string _dCDoiTuongCo = string.Empty;
        private string _maQLDoiTuongCT = string.Empty;
        private string _tenDoiTuongCT = string.Empty;
        private string _tenNguoiLap = string.Empty;
        private string _dCDoiTuongCT = string.Empty;
        private long _maChungTu = 0;
        private string _tenTieuMucNganSach = string.Empty;
        private string _tenMucNganSach = string.Empty;
        private string _tenChuongTrinh = string.Empty;
        private decimal _soTienMucNganSach = 0;
        private decimal _soTienChiPhiSanXuat = 0;
        Boolean _GhiMucNganSach = false;
        private int _maMucNganSach = 0;
        private int _maTaiKhoanCo = 0;
        private int _maChuongTrinh = 0;
        private int _maButToan = 0;
        private int _maTieuMucNganSach = 0;
        private int _maButToanMucNganSach = 0;
        private int _maButToanChiPhiSanXuat = 0;
        private int _maChiThuLao = 0;
        private int _maChiPhiThucHien = 0;
        private int _maTaiKhoan = 0;
        private int _maButToanMucNganSachNew = 0;
        private bool _chon = false;
        private decimal _soTienChuongTrinh = 0;
        private string _maChuongTrinhQuanLy = string.Empty;
        private Int64 _maCT_ChiPhiSanXuat = 0;
        //=======bo sung 2018.03.09
        private int _maDonVi = 0;
        private string _maDonViQL = string.Empty;
        private string _tenDonVi = string.Empty;
        private int _idKhoanMuc = 0;
        private string _tenKhoanMuc = string.Empty;
        private string _maKhoanMucQL = string.Empty;
        private Int64 _maHopDong = 0;
        private string _soHopDong = string.Empty;
        //=======bo sung 2018.07.27
        private string _soTKNganHang = string.Empty;
        private int _intMaLoaiChungTu = 0;
        //=======bo sung 2018.12.16
        private string _billSeries = string.Empty;
        private string _soBienLai = string.Empty;
        private string _namHoc = string.Empty;

        [System.ComponentModel.DataObjectField(true, false)]
        public int MaDonVi
        {
            get
            {
                CanReadProperty("MaDonVi", true);
                return _maDonVi;
            }
            set
            {
                CanWriteProperty("MaDonVi", true);
                if (!_maDonVi.Equals(value))
                {
                    _maDonVi = value;
                    PropertyHasChanged();
                }
            }
        }

        public int IDKhoanMuc
        {
            get
            {
                CanReadProperty("IDKhoanMuc", true);
                return _idKhoanMuc;
            }
            set
            {
                CanWriteProperty("IDKhoanMuc", true);
                if (!_idKhoanMuc.Equals(value))
                {
                    _idKhoanMuc = value;
                    PropertyHasChanged();
                }
            }
        }

        public Int64 MaHopDong
        {
            get
            {
                return _maHopDong;
            }
        }

        public string MaDonViQL
        {
            get
            {
                return _maDonViQL;
            }
        }

        public string TenDonVi
        {
            get
            {
                return _tenDonVi;
            }
        }

        public string TenKhoanMuc
        {
            get
            {
                return _tenKhoanMuc;
            }
        }

        public string MaKhoanMucQL
        {
            get
            {
                return _maKhoanMucQL;
            }
        }

        public string SoHopDong
        {
            get
            {
                return _soHopDong;
            }
        }

        public string MaChuongTrinhQuanLy
        {
            get
            {
                return _maChuongTrinhQuanLy;
            }
        }
        public Int64 MaCT_ChiPhiSanXuat
        {
            get
            {
                return _maCT_ChiPhiSanXuat;
            }
        }

        public string SoChungTu
        {
            get
            {
                return _soChungTu;
            }
        }

        public string SoHoaDon
        {
            get
            {
                return _soHoaDon;
            }
        }

        public string SoTKNganHang
        {
            get
            {
                return _soTKNganHang;
            }

        }
        public int IntMaLoaiChungTu
        {
            get
            {
                return _intMaLoaiChungTu;
            }
        }
        public string BillSeries
        {
            get
            {
                return _billSeries;
            }

        }
        public string SoBienLai
        {
            get
            {
                return _soBienLai;
            }

        }
        public string NamHoc
        {
            get
            {
                return _namHoc;
            }

        }
        public int MaTaiKhoanCo
        {
            get
            {
                CanReadProperty("MaTaiKhoanCo", true);
                return _maTaiKhoanCo;
            }
            set
            {
                CanWriteProperty("MaTaiKhoanCo", true);
                if (!_maTaiKhoanCo.Equals(value))
                {
                    _maTaiKhoanCo = value;
                    PropertyHasChanged();
                }
            }
        }

        public int MaTaiKhoan
        {
            get
            {
                CanReadProperty("MaTaiKhoan", true);
                return _maTaiKhoan;
            }
            set
            {
                CanWriteProperty("MaTaiKhoan", true);
                if (!_maTaiKhoan.Equals(value))
                {
                    _maTaiKhoan = value;
                    PropertyHasChanged();
                }
            }
        }

        public int MaMucNganSach
        {
            get
            {
                CanReadProperty("MaMucNganSach", true);
                return _maMucNganSach;
            }
            set
            {
                CanWriteProperty("MaMucNganSach", true);
                if (!_maMucNganSach.Equals(value))
                {
                    _maMucNganSach = value;
                    PropertyHasChanged();
                }
            }
        }

        public int MaTieuMucNganSach
        {
            get
            {
                CanReadProperty("MaTieuMucNganSach", true);
                return _maTieuMucNganSach;
            }
            set
            {
                CanWriteProperty("MaTieuMucNganSach", true);
                if (!_maTieuMucNganSach.Equals(value))
                {
                    _maTieuMucNganSach = value;
                    PropertyHasChanged();
                }
            }
        }

        public int MaButToanMucNganSach
        {
            get
            {
                CanReadProperty("MaButToanMucNganSach", true);
                return _maButToanMucNganSach;
            }
            set
            {
                CanWriteProperty("MaButToanMucNganSach", true);
                if (!_maButToanMucNganSach.Equals(value))
                {
                    _maButToanMucNganSach = value;
                    PropertyHasChanged();
                }
            }
        }
        public int MaButToanMucNganSachNew
        {
            get
            {
                CanReadProperty("MaButToanMucNganSachNew", true);
                return _maButToanMucNganSachNew;
            }
            set
            {
                CanWriteProperty("MaButToanMucNganSachNew", true);
                if (!_maButToanMucNganSachNew.Equals(value))
                {
                    _maButToanMucNganSachNew = value;
                    PropertyHasChanged();
                }
            }
        }
        public int MaButToanChiPhiSanXuat
        {
            get
            {
                CanReadProperty("MaButToanChiPhiSanXuat", true);
                return _maButToanChiPhiSanXuat;
            }
            set
            {
                CanWriteProperty("MaButToanChiPhiSanXuat", true);
                if (!_maButToanChiPhiSanXuat.Equals(value))
                {
                    _maButToanChiPhiSanXuat = value;
                    PropertyHasChanged();
                }
            }
        }

        public int MaChiThuLao
        {
            get
            {
                CanReadProperty("MaChiThuLao", true);
                return _maChiThuLao;
            }
            set
            {
                CanWriteProperty("MaChiThuLao", true);
                if (!_maChiThuLao.Equals(value))
                {
                    _maChiThuLao = value;
                    PropertyHasChanged();
                }
            }
        }

        public int MaChiPhiThucHien
        {
            get
            {
                CanReadProperty("MaChiPhiThucHien", true);
                return _maChiPhiThucHien;
            }
            set
            {
                CanWriteProperty("MaChiPhiThucHien", true);
                if (!_maChiPhiThucHien.Equals(value))
                {
                    _maChiPhiThucHien = value;
                    PropertyHasChanged();
                }
            }
        }

        public int MaChuongTrinh
        {
            get
            {
                CanReadProperty("MaChuongTrinh", true);
                return _maChuongTrinh;
            }
            set
            {
                CanWriteProperty("MaChuongTrinh", true);
                if (!_maTaiKhoanCo.Equals(value))
                {
                    _maChuongTrinh = value;
                    PropertyHasChanged();
                }
            }
        }

        public int MaButToan
        {
            get
            {
                CanReadProperty("MaButToan", true);
                return _maButToan;
            }
            set
            {
                CanWriteProperty("MaButToan", true);
                if (!_maButToan.Equals(value))
                {
                    _maButToan = value;
                    PropertyHasChanged();
                }
            }
        }

        public Boolean Chon
        {
            get
            {
                CanReadProperty(true);
                return _chon;
            }
            set
            {
                CanWriteProperty(true);
                if (!_chon.Equals(value))
                {
                    _chon = value;
                    PropertyHasChanged();
                }
            }
        }
        public Boolean GhiMucNganSach
        {
            get
            {
                CanReadProperty(true);
                return _GhiMucNganSach;
            }
            set
            {
                CanWriteProperty(true);
                if (!_GhiMucNganSach.Equals(value))
                {
                    _GhiMucNganSach = value;
                    PropertyHasChanged();
                }
            }
        }
        [System.ComponentModel.DataObjectField(true, false)]
        public DateTime NgayLap
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
                    _ngayLap = value;
                    PropertyHasChanged("NgayLap");
                }
            }
        }

        [System.ComponentModel.DataObjectField(true, false)]


        public decimal SoTien
        {
            get
            {
                CanReadProperty("SoTien", true);
                return _soTien;
            }
            set
            {
                CanWriteProperty("SoTien", true);
                if (!_soTien.Equals(value))
                {
                    _soTien = value;
                    PropertyHasChanged("SoTien");
                }
            }
        }

        public decimal SoTienChuongTrinh
        {
            get
            {
                CanReadProperty("SoTienChuongTrinh", true);
                return _soTienChuongTrinh;
            }
            set
            {
                CanWriteProperty("SoTienChuongTrinh", true);
                if (!_soTienChuongTrinh.Equals(value))
                {
                    _soTienChuongTrinh = value;
                    PropertyHasChanged("SoTienChuongTrinh");
                }
            }
        }

        public decimal SoTienMucNganSach
        {
            get
            {
                CanReadProperty("SoTienMucNganSach", true);
                return _soTienMucNganSach;
            }
            set
            {
                CanWriteProperty("SoTienMucNganSach", true);
                if (!_soTienMucNganSach.Equals(value))
                {
                    _soTienMucNganSach = value;
                    PropertyHasChanged("SoTienMucNganSach");
                }
            }
        }

        public decimal SoTienChiPhiSanXuat
        {
            get
            {
                CanReadProperty("SoTienChiPhiSanXuat", true);
                return _soTienChiPhiSanXuat;
            }
            set
            {
                CanWriteProperty("SoTienChiPhiSanXuat", true);
                if (!_soTienChiPhiSanXuat.Equals(value))
                {
                    _soTienChiPhiSanXuat = value;
                    PropertyHasChanged("SoTienChiPhiSanXuat");
                }
            }
        }

        public long MaChungTu
        {
            get
            {
                CanReadProperty("MaChungTu", true);
                return _maChungTu;
            }
            set
            {
                CanWriteProperty("MaChungTu", true);
                if (!_soTien.Equals(value))
                {
                    _maChungTu = value;
                    PropertyHasChanged("MaChungTu");
                }
            }
        }

        public decimal TiGiaQuyDoi
        {
            get
            {
                CanReadProperty("TiGiaQuyDoi", true);
                return _tiGiaQuyDoi;
            }
            set
            {
                CanWriteProperty("TiGiaQuyDoi", true);
                if (!_tiGiaQuyDoi.Equals(value))
                {
                    _tiGiaQuyDoi = value;
                    PropertyHasChanged("TiGiaQuyDoi");
                }
            }
        }

        public decimal ThanhTien
        {
            get
            {
                CanReadProperty("ThanhTien", true);
                return _thanhTien;
            }
            set
            {
                CanWriteProperty("ThanhTien", true);
                if (!_thanhTien.Equals(value))
                {
                    _thanhTien = value;
                    PropertyHasChanged("ThanhTien");
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

        public string TenChuongTrinh
        {
            get
            {
                CanReadProperty("TenChuongTrinh", true);
                return _tenChuongTrinh;
            }
            set
            {
                CanWriteProperty("TenChuongTrinh", true);
                if (value == null) value = string.Empty;
                if (!_tenChuongTrinh.Equals(value))
                {
                    _tenChuongTrinh = value;
                    PropertyHasChanged("TenChuongTrinh");
                }
            }
        }



        public string TenMucNganSach
        {
            get
            {
                CanReadProperty("TenMucNganSach", true);
                return _tenMucNganSach;
            }
            set
            {
                CanWriteProperty("TenMucNganSach", true);
                if (value == null) value = string.Empty;
                if (!_tenMucNganSach.Equals(value))
                {
                    _tenMucNganSach = value;
                    PropertyHasChanged("TenMucNganSach");
                }
            }
        }

        public string TenTieuMucNganSach
        {
            get
            {
                CanReadProperty("TenTieuMucNganSach", true);
                return _tenTieuMucNganSach;
            }
            set
            {
                CanWriteProperty("TenTieuMucNganSach", true);
                if (value == null) value = string.Empty;
                if (!_tenTieuMucNganSach.Equals(value))
                {
                    _tenTieuMucNganSach = value;
                    PropertyHasChanged("TenTieuMucNganSach");
                }
            }
        }


        public string MaLoaiChungTu
        {
            get
            {
                CanReadProperty("MaLoaiChungTu", true);
                return _maLoaiChungTu;
            }
            set
            {
                CanWriteProperty("MaLoaiChungTu", true);
                if (value == null) value = string.Empty;
                if (!_maLoaiChungTu.Equals(value))
                {
                    _maLoaiChungTu = value;
                    PropertyHasChanged("MaLoaiChungTu");
                }
            }
        }

        public string Tkno
        {
            get
            {
                CanReadProperty("Tkno", true);
                return _tkno;
            }
            set
            {
                CanWriteProperty("Tkno", true);
                if (value == null) value = string.Empty;
                if (!_tkno.Equals(value))
                {
                    _tkno = value;
                    PropertyHasChanged("Tkno");
                }
            }
        }

        public string TKCo
        {
            get
            {
                CanReadProperty("TKCo", true);
                return _tKCo;
            }
            set
            {
                CanWriteProperty("TKCo", true);
                if (value == null) value = string.Empty;
                if (!_tKCo.Equals(value))
                {
                    _tKCo = value;
                    PropertyHasChanged("TKCo");
                }
            }
        }

        public decimal SoTienBT
        {
            get
            {
                CanReadProperty("SoTienBT", true);
                return _soTienBT;
            }
            set
            {
                CanWriteProperty("SoTienBT", true);
                if (!_soTienBT.Equals(value))
                {
                    _soTienBT = value;
                    PropertyHasChanged("SoTienBT");
                }
            }
        }

        public string DienGiaiBT
        {
            get
            {
                CanReadProperty("DienGiaiBT", true);
                return _dienGiaiBT;
            }
            set
            {
                CanWriteProperty("DienGiaiBT", true);
                if (value == null) value = string.Empty;
                if (!_dienGiaiBT.Equals(value))
                {
                    _dienGiaiBT = value;
                    PropertyHasChanged("DienGiaiBT");
                }
            }
        }

        public string MaTieuMuc
        {
            get
            {
                CanReadProperty("MaTieuMuc", true);
                return _maTieuMuc;
            }
            set
            {
                CanWriteProperty("MaTieuMuc", true);
                if (value == null) value = string.Empty;
                if (!_maTieuMuc.Equals(value))
                {
                    _maTieuMuc = value;
                    PropertyHasChanged("MaTieuMuc");
                }
            }
        }

        public decimal SoTienTieuMuc
        {
            get
            {
                CanReadProperty("SoTienTieuMuc", true);
                return _soTienTieuMuc;
            }
            set
            {
                CanWriteProperty("SoTienTieuMuc", true);
                if (!_soTienTieuMuc.Equals(value))
                {
                    _soTienTieuMuc = value;
                    PropertyHasChanged("SoTienTieuMuc");
                }
            }
        }

        public string DienGiaiMuc
        {
            get
            {
                CanReadProperty("DienGiaiMuc", true);
                return _dienGiaiMuc;
            }
            set
            {
                CanWriteProperty("DienGiaiMuc", true);
                if (value == null) value = string.Empty;
                if (!_dienGiaiMuc.Equals(value))
                {
                    _dienGiaiMuc = value;
                    PropertyHasChanged("DienGiaiMuc");
                }
            }
        }

        public string MaMucNganSachQL
        {
            get
            {
                CanReadProperty("MaMucNganSachQL", true);
                return _maMucNganSachQL;
            }
            set
            {
                CanWriteProperty("MaMucNganSachQL", true);
                if (value == null) value = string.Empty;
                if (!_maMucNganSachQL.Equals(value))
                {
                    _maMucNganSachQL = value;
                    PropertyHasChanged("MaMucNganSachQL");
                }
            }
        }

        public string TenDoiTuongNo
        {
            get
            {
                CanReadProperty("TenDoiTuongNo", true);
                return _tenDoiTuongNo;
            }
            set
            {
                CanWriteProperty("TenDoiTuongNo", true);
                if (value == null) value = string.Empty;
                if (!_tenDoiTuongNo.Equals(value))
                {
                    _tenDoiTuongNo = value;
                    PropertyHasChanged("TenDoiTuongNo");
                }
            }
        }

        public string TenTaiKhoan
        {
            get
            {
                CanReadProperty("TenTaiKhoan", true);
                return _tenTaiKhoan;
            }
            set
            {
                CanWriteProperty("TenTaiKhoan", true);
                if (value == null) value = string.Empty;
                if (!_tenTaiKhoan.Equals(value))
                {
                    _tenTaiKhoan = value;
                    PropertyHasChanged("TenTaiKhoan");
                }
            }
        }

        public string TenDoiTuongCo
        {
            get
            {
                CanReadProperty("TenDoiTuongCo", true);
                return _tenDoiTuongCo;
            }
            set
            {
                CanWriteProperty("TenDoiTuongCo", true);
                if (value == null) value = string.Empty;
                if (!_tenDoiTuongCo.Equals(value))
                {
                    _tenDoiTuongCo = value;
                    PropertyHasChanged("TenDoiTuongCo");
                }
            }
        }

        public string DCDoiTuongNo
        {
            get
            {
                CanReadProperty("DCDoiTuongNo", true);
                return _dCDoiTuongNo;
            }
            set
            {
                CanWriteProperty("DCDoiTuongNo", true);
                if (value == null) value = string.Empty;
                if (!_dCDoiTuongNo.Equals(value))
                {
                    _dCDoiTuongNo = value;
                    PropertyHasChanged("DCDoiTuongNo");
                }
            }
        }

        public string KHNgoai
        {
            get
            {
                CanReadProperty("KHNgoai", true);
                return _kHNgoai;
            }
            set
            {
                CanWriteProperty("KHNgoai", true);
                if (value == null) value = string.Empty;
                if (!_kHNgoai.Equals(value))
                {
                    _kHNgoai = value;
                    PropertyHasChanged("KHNgoai");
                }
            }
        }

        public string DCNgoai
        {
            get
            {
                CanReadProperty("DCNgoai", true);
                return _dCNgoai;
            }
            set
            {
                CanWriteProperty("DCNgoai", true);
                if (value == null) value = string.Empty;
                if (!_dCNgoai.Equals(value))
                {
                    _dCNgoai = value;
                    PropertyHasChanged("DCNgoai");
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

        public string TenDangNhap
        {
            get
            {
                CanReadProperty("TenDangNhap", true);
                return _tenDangNhap;
            }
            set
            {
                CanWriteProperty("TenDangNhap", true);
                if (value == null) value = string.Empty;
                if (!_tenDangNhap.Equals(value))
                {
                    _tenDangNhap = value;
                    PropertyHasChanged("TenDangNhap");
                }
            }
        }

        public string TenDoiTuongThuChi
        {
            get
            {
                CanReadProperty("TenDoiTuongThuChi", true);
                return _tenDoiTuongThuChi;
            }
            set
            {
                CanWriteProperty("TenDoiTuongThuChi", true);
                if (value == null) value = string.Empty;
                if (!_tenDoiTuongThuChi.Equals(value))
                {
                    _tenDoiTuongThuChi = value;
                    PropertyHasChanged("TenDoiTuongThuChi");
                }
            }
        }

        public DateTime NgayThucHien
        {
            get
            {
                CanReadProperty("NgayThucHien", true);
                return _ngayThucHien.Date;
            }
        }

        public string MaQLDoiTuongNo
        {
            get
            {
                CanReadProperty("MaQLDoiTuongNo", true);
                return _maQLDoiTuongNo;
            }
            set
            {
                CanWriteProperty("MaQLDoiTuongNo", true);
                if (value == null) value = string.Empty;
                if (!_maQLDoiTuongNo.Equals(value))
                {
                    _maQLDoiTuongNo = value;
                    PropertyHasChanged("MaQLDoiTuongNo");
                }
            }
        }

        public string MaQLDoiTuongCo
        {
            get
            {
                CanReadProperty("MaQLDoiTuongCo", true);
                return _maQLDoiTuongCo;
            }
            set
            {
                CanWriteProperty("MaQLDoiTuongCo", true);
                if (value == null) value = string.Empty;
                if (!_maQLDoiTuongCo.Equals(value))
                {
                    _maQLDoiTuongCo = value;
                    PropertyHasChanged("MaQLDoiTuongCo");
                }
            }
        }

        public string DCDoiTuongCo
        {
            get
            {
                CanReadProperty("DCDoiTuongCo", true);
                return _dCDoiTuongCo;
            }
            set
            {
                CanWriteProperty("DCDoiTuongCo", true);
                if (value == null) value = string.Empty;
                if (!_dCDoiTuongCo.Equals(value))
                {
                    _dCDoiTuongCo = value;
                    PropertyHasChanged("DCDoiTuongCo");
                }
            }
        }

        public string MaQLDoiTuongCT
        {
            get
            {
                CanReadProperty("MaQLDoiTuongCT", true);
                return _maQLDoiTuongCT;
            }
            set
            {
                CanWriteProperty("MaQLDoiTuongCT", true);
                if (value == null) value = string.Empty;
                if (!_maQLDoiTuongCT.Equals(value))
                {
                    _maQLDoiTuongCT = value;
                    PropertyHasChanged("MaQLDoiTuongCT");
                }
            }
        }

        public string TenDoiTuongCT
        {
            get
            {
                CanReadProperty("TenDoiTuongCT", true);
                return _tenDoiTuongCT;
            }
            set
            {
                CanWriteProperty("TenDoiTuongCT", true);
                if (value == null) value = string.Empty;
                if (!_tenDoiTuongCT.Equals(value))
                {
                    _tenDoiTuongCT = value;
                    PropertyHasChanged("TenDoiTuongCT");
                }
            }
        }

        public string TenNguoiLap
        {
            get
            {
                CanReadProperty("TenNguoiLap", true);
                return _tenNguoiLap;
            }
            set
            {
                CanWriteProperty("TenNguoiLap", true);
                if (value == null) value = string.Empty;
                if (!_tenNguoiLap.Equals(value))
                {
                    _tenNguoiLap = value;
                    PropertyHasChanged("TenNguoiLap");
                }
            }
        }

        public string DCDoiTuongCT
        {
            get
            {
                CanReadProperty("DCDoiTuongCT", true);
                return _dCDoiTuongCT;
            }
            set
            {
                CanWriteProperty("DCDoiTuongCT", true);
                if (value == null) value = string.Empty;
                if (!_dCDoiTuongCT.Equals(value))
                {
                    _dCDoiTuongCT = value;
                    PropertyHasChanged("DCDoiTuongCT");
                }
            }
        }

        protected override object GetIdValue()
        {
            return string.Format("{0}:{1}", _soChungTu, _ngayLap);
        }

        #endregion //Business Properties and Methods

        #region Validation Rules
        private void AddCustomRules()
        {
            //add custom/non-generated rules here...
        }

        private void AddCommonRules()
        {
            ////
            //// SoChungTu
            ////
            //ValidationRules.AddRule(CommonRules.StringRequired, "SoChungTu");
            //ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("SoChungTu", 50));
            ////
            //// NgayLap
            ////
            //ValidationRules.AddRule(CommonRules.StringRequired, "NgayLapString");
            ////
            //// DienGiai
            ////
            //ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("DienGiai", 2000));
            ////
            //// MaLoaiChungTu
            ////
            //ValidationRules.AddRule(CommonRules.StringRequired, "MaLoaiChungTu");
            //ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("MaLoaiChungTu", 9));
            ////
            //// Tkno
            ////
            //ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("Tkno", 50));
            ////
            //// TKCo
            ////
            //ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("TKCo", 50));
            ////
            //// DienGiaiBT
            ////
            //ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("DienGiaiBT", 4000));
            ////
            //// MaTieuMuc
            ////
            //ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("MaTieuMuc", 50));
            ////
            //// DienGiaiMuc
            ////
            //ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("DienGiaiMuc", 2000));
            ////
            //// MaMucNganSachQL
            ////
            //ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("MaMucNganSachQL", 50));
            ////
            //// TenDoiTuongNo
            ////
            //ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("TenDoiTuongNo", 1000));
            ////
            //// DCDoiTuongNo
            ////
            //ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("DCDoiTuongNo", 212));
            ////
            //// KHNgoai
            ////
            //ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("KHNgoai", 50));
            ////
            //// DCNgoai
            ////
            //ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("DCNgoai", 100));
            ////
            //// TenBoPhan
            ////
            //ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("TenBoPhan", 500));
            ////
            //// TenDangNhap
            ////
            //ValidationRules.AddRule(CommonRules.StringRequired, "TenDangNhap");
            //ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("TenDangNhap", 50));
            ////
            //// TenDoiTuongThuChi
            ////
            //ValidationRules.AddRule(CommonRules.StringRequired, "TenDoiTuongThuChi");
            //ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("TenDoiTuongThuChi", 500));
            ////
            //// MaQLDoiTuongNo
            ////
            //ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("MaQLDoiTuongNo", 50));
            ////
            //// MaQLDoiTuongCo
            ////
            //ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("MaQLDoiTuongCo", 50));
            ////
            //// TenDoiTuongCo
            ////
            //ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("TenDoiTuongCo", 1000));
            ////
            //// DCDoiTuongCo
            ////
            //ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("DCDoiTuongCo", 212));
            ////
            //// MaQLDoiTuongCT
            ////
            //ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("MaQLDoiTuongCT", 50));
            ////
            //// TenDoiTuongCT
            ////
            //ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("TenDoiTuongCT", 1000));
            ////
            //// DCDoiTuongCT
            ////
            //ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("DCDoiTuongCT", 212));
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
            //TODO: Define authorization rules in XuatDuLieu
            //AuthorizationRules.AllowRead("SoChungTu", "XuatDuLieuReadGroup");
            //AuthorizationRules.AllowRead("NgayLap", "XuatDuLieuReadGroup");
            //AuthorizationRules.AllowRead("NgayLapString", "XuatDuLieuReadGroup");
            //AuthorizationRules.AllowRead("SoTien", "XuatDuLieuReadGroup");
            //AuthorizationRules.AllowRead("TiGiaQuyDoi", "XuatDuLieuReadGroup");
            //AuthorizationRules.AllowRead("ThanhTien", "XuatDuLieuReadGroup");
            //AuthorizationRules.AllowRead("DienGiai", "XuatDuLieuReadGroup");
            //AuthorizationRules.AllowRead("MaLoaiChungTu", "XuatDuLieuReadGroup");
            //AuthorizationRules.AllowRead("Tkno", "XuatDuLieuReadGroup");
            //AuthorizationRules.AllowRead("TKCo", "XuatDuLieuReadGroup");
            //AuthorizationRules.AllowRead("SoTienBT", "XuatDuLieuReadGroup");
            //AuthorizationRules.AllowRead("DienGiaiBT", "XuatDuLieuReadGroup");
            //AuthorizationRules.AllowRead("MaTieuMuc", "XuatDuLieuReadGroup");
            //AuthorizationRules.AllowRead("SoTienTieuMuc", "XuatDuLieuReadGroup");
            //AuthorizationRules.AllowRead("DienGiaiMuc", "XuatDuLieuReadGroup");
            //AuthorizationRules.AllowRead("MaMucNganSachQL", "XuatDuLieuReadGroup");
            //AuthorizationRules.AllowRead("TenDoiTuongNo", "XuatDuLieuReadGroup");
            //AuthorizationRules.AllowRead("DCDoiTuongNo", "XuatDuLieuReadGroup");
            //AuthorizationRules.AllowRead("KHNgoai", "XuatDuLieuReadGroup");
            //AuthorizationRules.AllowRead("DCNgoai", "XuatDuLieuReadGroup");
            //AuthorizationRules.AllowRead("TenBoPhan", "XuatDuLieuReadGroup");
            //AuthorizationRules.AllowRead("TenDangNhap", "XuatDuLieuReadGroup");
            //AuthorizationRules.AllowRead("TenDoiTuongThuChi", "XuatDuLieuReadGroup");
            //AuthorizationRules.AllowRead("NgayThucHien", "XuatDuLieuReadGroup");
            //AuthorizationRules.AllowRead("NgayThucHienString", "XuatDuLieuReadGroup");
            //AuthorizationRules.AllowRead("MaQLDoiTuongNo", "XuatDuLieuReadGroup");
            //AuthorizationRules.AllowRead("MaQLDoiTuongCo", "XuatDuLieuReadGroup");
            //AuthorizationRules.AllowRead("TenDoiTuongCo", "XuatDuLieuReadGroup");
            //AuthorizationRules.AllowRead("DCDoiTuongCo", "XuatDuLieuReadGroup");
            //AuthorizationRules.AllowRead("MaQLDoiTuongCT", "XuatDuLieuReadGroup");
            //AuthorizationRules.AllowRead("TenDoiTuongCT", "XuatDuLieuReadGroup");
            //AuthorizationRules.AllowRead("DCDoiTuongCT", "XuatDuLieuReadGroup");

            //AuthorizationRules.AllowWrite("SoTien", "XuatDuLieuWriteGroup");
            //AuthorizationRules.AllowWrite("TiGiaQuyDoi", "XuatDuLieuWriteGroup");
            //AuthorizationRules.AllowWrite("ThanhTien", "XuatDuLieuWriteGroup");
            //AuthorizationRules.AllowWrite("DienGiai", "XuatDuLieuWriteGroup");
            //AuthorizationRules.AllowWrite("MaLoaiChungTu", "XuatDuLieuWriteGroup");
            //AuthorizationRules.AllowWrite("Tkno", "XuatDuLieuWriteGroup");
            //AuthorizationRules.AllowWrite("TKCo", "XuatDuLieuWriteGroup");
            //AuthorizationRules.AllowWrite("SoTienBT", "XuatDuLieuWriteGroup");
            //AuthorizationRules.AllowWrite("DienGiaiBT", "XuatDuLieuWriteGroup");
            //AuthorizationRules.AllowWrite("MaTieuMuc", "XuatDuLieuWriteGroup");
            //AuthorizationRules.AllowWrite("SoTienTieuMuc", "XuatDuLieuWriteGroup");
            //AuthorizationRules.AllowWrite("DienGiaiMuc", "XuatDuLieuWriteGroup");
            //AuthorizationRules.AllowWrite("MaMucNganSachQL", "XuatDuLieuWriteGroup");
            //AuthorizationRules.AllowWrite("TenDoiTuongNo", "XuatDuLieuWriteGroup");
            //AuthorizationRules.AllowWrite("DCDoiTuongNo", "XuatDuLieuWriteGroup");
            //AuthorizationRules.AllowWrite("KHNgoai", "XuatDuLieuWriteGroup");
            //AuthorizationRules.AllowWrite("DCNgoai", "XuatDuLieuWriteGroup");
            //AuthorizationRules.AllowWrite("TenBoPhan", "XuatDuLieuWriteGroup");
            //AuthorizationRules.AllowWrite("TenDangNhap", "XuatDuLieuWriteGroup");
            //AuthorizationRules.AllowWrite("TenDoiTuongThuChi", "XuatDuLieuWriteGroup");
            //AuthorizationRules.AllowWrite("NgayThucHienString", "XuatDuLieuWriteGroup");
            //AuthorizationRules.AllowWrite("MaQLDoiTuongNo", "XuatDuLieuWriteGroup");
            //AuthorizationRules.AllowWrite("MaQLDoiTuongCo", "XuatDuLieuWriteGroup");
            //AuthorizationRules.AllowWrite("TenDoiTuongCo", "XuatDuLieuWriteGroup");
            //AuthorizationRules.AllowWrite("DCDoiTuongCo", "XuatDuLieuWriteGroup");
            //AuthorizationRules.AllowWrite("MaQLDoiTuongCT", "XuatDuLieuWriteGroup");
            //AuthorizationRules.AllowWrite("TenDoiTuongCT", "XuatDuLieuWriteGroup");
            //AuthorizationRules.AllowWrite("DCDoiTuongCT", "XuatDuLieuWriteGroup");
        }


        public static bool CanGetObject()
        {
            //TODO: Define CanGetObject permission in XuatDuLieu
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("XuatDuLieuViewGroup"))
            //	return true;
            //return false;
        }

        public static bool CanAddObject()
        {
            //TODO: Define CanAddObject permission in XuatDuLieu
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("XuatDuLieuAddGroup"))
            //	return true;
            //return false;
        }

        public static bool CanEditObject()
        {
            //TODO: Define CanEditObject permission in XuatDuLieu
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("XuatDuLieuEditGroup"))
            //	return true;
            //return false;
        }

        public static bool CanDeleteObject()
        {
            //TODO: Define CanDeleteObject permission in XuatDuLieu
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("XuatDuLieuDeleteGroup"))
            //	return true;
            //return false;
        }
        #endregion //Authorization Rules

        #region Factory Methods
        private XuatDuLieu()
        { /* require use of factory method */

        }
        private XuatDuLieu(long maChungTu, string taiKhoanCo, string tenChuongTrinh, string tenTieuMuc, string tenMuc, string soChungTu, decimal soMucNganSach, decimal soTienChiPhiSanXuat, DateTime ngayLap)
        {
            MarkAsChild();
            _soChungTu = soChungTu;
            _tenChuongTrinh = tenChuongTrinh;
            _tenTieuMucNganSach = tenTieuMuc;
            _tenMucNganSach = tenMuc;
            _soTienChiPhiSanXuat = soTienChiPhiSanXuat;
            _soTienMucNganSach = SoTienMucNganSach;
            _ngayLap = ngayLap;
            _maChungTu = maChungTu;
            _tKCo = taiKhoanCo;
        }

        public static XuatDuLieu NewXuatDuLieu(string soChungTu, DateTime ngayLap)
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a XuatDuLieu");
            return DataPortal.Create<XuatDuLieu>(new Criteria(soChungTu, ngayLap));
        }

        public static XuatDuLieu NewXuatDuLieu(int maChungTu, string taiKhoanCo, string tenChuongTrinh, string tenTieuMuc, string tenMuc, string soChungTu, decimal soTienMucNganSach, decimal soTienChiPhiSanXuat, DateTime ngayLap)
        {
            return new XuatDuLieu(maChungTu, taiKhoanCo, tenChuongTrinh, tenTieuMuc, tenMuc, soChungTu, soTienMucNganSach, soTienChiPhiSanXuat, ngayLap);
        }

        public static XuatDuLieu GetXuatDuLieu(string soChungTu, DateTime ngayLap)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a XuatDuLieu");
            return DataPortal.Fetch<XuatDuLieu>(new Criteria(soChungTu, ngayLap));
        }

        public static XuatDuLieu GetXuatDuLieuByMaChungTu(int maChungTu)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a XuatDuLieu");
            return DataPortal.Fetch<XuatDuLieu>(new CriteriaByMaChungTu(maChungTu));
        }

        public static void DeleteXuatDuLieu(string soChungTu, DateTime ngayLap)
        {
            if (!CanDeleteObject())
                throw new System.Security.SecurityException("User not authorized to remove a XuatDuLieu");
            DataPortal.Delete(new Criteria(soChungTu, ngayLap));
        }

        public override XuatDuLieu Save()
        {
            if (IsDeleted && !CanDeleteObject())
                throw new System.Security.SecurityException("User not authorized to remove a XuatDuLieu");
            else if (IsNew && !CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a XuatDuLieu");
            else if (!CanEditObject())
                throw new System.Security.SecurityException("User not authorized to update a XuatDuLieu");

            return base.Save();
        }

        #endregion //Factory Methods

        #region Child Factory Methods
        private XuatDuLieu(string soChungTu, DateTime ngayLap)
        {
            this._soChungTu = soChungTu;
            this._ngayLap = ngayLap;
        }

        internal static XuatDuLieu NewXuatDuLieuChild(string soChungTu, DateTime ngayLap)
        {
            XuatDuLieu child = new XuatDuLieu(soChungTu, ngayLap);
            child.ValidationRules.CheckRules();
            child.MarkAsChild();
            return child;
        }

        internal static XuatDuLieu GetXuatDuLieu(SafeDataReader dr)
        {
            XuatDuLieu child = new XuatDuLieu();
            child.MarkAsChild();
            child.Fetch(dr);
            return child;
        }

        internal static XuatDuLieu GetXuatDuLieu(SafeDataReader dr, int loai)
        {
            XuatDuLieu child = new XuatDuLieu();
            child.MarkAsChild();
            child.Fetch(dr, loai);
            return child;
        }

        internal static XuatDuLieu GetXuatDuLieuKiemTraCacBan(SafeDataReader dr)
        {
            XuatDuLieu child = new XuatDuLieu();
            child.MarkAsChild();
            child._soChungTu = dr.GetString("SoChungTu");
            child._ngayLap = dr.GetDateTime("NgayLap");
            child._maLoaiChungTu = dr.GetString("MaLoaiChungTu");
            child._tkno = dr.GetString("TKNo");
            child._tKCo = dr.GetString("TKCo");
            child._soTienBT = dr.GetDecimal("SoTienBT");
            child._soTienTieuMuc = dr.GetDecimal("SoTienTieuMuc");
            child._soTien = dr.GetDecimal("SoTienXacNhan");
            child._thanhTien = dr.GetDecimal("SoTienDaNhap");
            child._tiGiaQuyDoi = dr.GetDecimal("SoTienConLai");
            child._dienGiaiBT = dr.GetString("DienGiaiBT");
            child._maTieuMuc = dr.GetString("MaTieuMuc");
            child._dienGiaiMuc = dr.GetString("DienGiaiMuc");
            child._maMucNganSachQL = dr.GetString("MaMucNganSachQL");
            child._tenBoPhan = dr.GetString("TenBoPhanGoi");
            child._tenDangNhap = dr.GetString("TenDangNhap");
            child._ngayThucHien = dr.GetDateTime("NgayThucHien");
            child._maTieuMuc = dr.GetString("MaTieuMuc");
            //child.Fetch(dr);
            return child;
        }

        internal static XuatDuLieu GetXuatDuLieuKiemTraCacBanByChuongTrinh(SafeDataReader dr)
        {
            XuatDuLieu child = new XuatDuLieu();
            child.MarkAsChild();
            child._soChungTu = dr.GetString("SoChungTu");
            child._ngayLap = dr.GetDateTime("NgayLap");
            child._maLoaiChungTu = dr.GetString("MaLoaiChungTu");
            child._tkno = dr.GetString("TKNO");
            child._tKCo = dr.GetString("TKCo");
            child._soTienBT = dr.GetDecimal("SoTienButToan");
            child._dienGiaiBT = dr.GetString("DienGiaiBT");
            child._maButToan = dr.GetInt32("MaButToan");
            child._maChuongTrinh = dr.GetInt32("MaChuongTrinh");
            child._maChuongTrinhQuanLy = dr.GetString("MaChuongTrinhQL");
            child._tenChuongTrinh = dr.GetString("TenChuongTrinh");
            child._maCT_ChiPhiSanXuat = dr.GetInt64("MaCT_ChiPhiSanXuat");
            child._soTienChuongTrinh = dr.GetDecimal("SoTienCPSX");
            child._maTieuMuc = dr.GetString("MaTieuMuc");
            child._soTienTieuMuc = dr.GetDecimal("SoTienTieuMuc");
            child._dienGiaiMuc = dr.GetString("DienGiaiMuc");
            child._maMucNganSachQL = dr.GetString("MaMucNganSachQL");
            //child._tenDoiTuongNo = dr.GetString("TenDoiTuongNo");
            //child._dCDoiTuongNo = dr.GetString("DCDoiTuongNo");
            //child._kHNgoai = dr.GetString("KHNgoai");
            //child._dCNgoai = dr.GetString("DCNgoai");
            //child._tenBoPhan = dr.GetString("TenBoPhan");
            child._tenDangNhap = dr.GetString("TenDangNhap");
            child._ngayThucHien = dr.GetDateTime("NgayThucHien");
            //child._tenDoiTuongThuChi = dr.GetString("TenDoiTuongThuChi");
            //child._ngayThucHien = dr.GetDateTime("NgayThucHien");
            //child._maQLDoiTuongNo = dr.GetString("MaQLDoiTuongNo");
            //child._maQLDoiTuongCo = dr.GetString("MaQLDoiTuongCo");
            //child._tenDoiTuongCo = dr.GetString("TenDoiTuongCo");
            //child._dCDoiTuongCo = dr.GetString("DCDoiTuongCo");
            //child._maQLDoiTuongCT = dr.GetString("MaQLDoiTuongCT");
            //child._tenDoiTuongCT = dr.GetString("TenDoiTuongCT");
            //child._dCDoiTuongCT = dr.GetString("DCDoiTuongCT");

            return child;
        }
        #endregion //Child Factory Methods

        #region Data Access

        #region Criteria

        [Serializable()]
        private class Criteria
        {
            public string SoChungTu;
            public DateTime NgayLap;

            public Criteria(string soChungTu, DateTime ngayLap)
            {
                this.SoChungTu = soChungTu;
                this.NgayLap = ngayLap;
            }
        }
        private class CriteriaByMaChungTu
        {
            public int MaChungTu;


            public CriteriaByMaChungTu(int maChungTu)
            {
                MaChungTu = maChungTu;
            }
        }

        #endregion //Criteria

        #region Data Access - Create
        [RunLocal]
        private void DataPortal_Create(Criteria criteria)
        {
            _soChungTu = criteria.SoChungTu;
            _ngayLap = criteria.NgayLap;
            ValidationRules.CheckRules();
        }

        #endregion //Data Access - Create

        #region Data Access - Fetch
        private void DataPortal_Fetch(object criteria)
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

        private void ExecuteFetch(SqlTransaction tr, object criteria)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                if (criteria is CriteriaByMaChungTu)
                {
                    cm.Transaction = tr;
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_SelecttblXuatDuLieuByMaChungTu";

                    cm.Parameters.AddWithValue("@MaChungTu", ((CriteriaByMaChungTu)criteria).MaChungTu);
                }



                using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                {
                    dr.Read();
                    if (criteria is CriteriaByMaChungTu)
                    {
                        FetchObject(dr, 1);
                    }
                    else
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
            DataPortal_Delete(new Criteria(_soChungTu, _ngayLap));
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
                cm.CommandText = "spd_DeletetblXuatDuLieu";

                cm.Parameters.AddWithValue("@SoChungTu", criteria.SoChungTu);
                cm.Parameters.AddWithValue("@NgayLap", criteria.NgayLap);

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
            //FetchChildren(dr);
        }

        private void Fetch(SafeDataReader dr, int loai)
        {
            FetchObject(dr, loai);
            MarkOld();
            //ValidationRules.CheckRules();

            //load child object(s)
            //FetchChildren(dr);
        }

        private void FetchObject(SafeDataReader dr, int loai)
        {
            if (loai == 1)
            {
                _maChungTu = dr.GetInt64("MaChungTu");
                _soChungTu = dr.GetString("SoChungTu");
                _ngayLap = dr.GetDateTime("NgayLap");
                _soTien = dr.GetDecimal("SoTien");
                _soTienMucNganSach = dr.GetDecimal("SoTienMucNganSach");
                _soTienChiPhiSanXuat = dr.GetDecimal("SoTienChiPhiSanXuat");
                _tenMucNganSach = dr.GetString("TenMucNganSach");
                _tenTieuMucNganSach = dr.GetString("TenTieuMucNganSach");
                _tenChuongTrinh = dr.GetString("TenChuongTrinh");
                _tKCo = dr.GetString("TKCo");
                _maTieuMucNganSach = dr.GetInt32("MaTieuMucNganSach");
                _maMucNganSach = dr.GetInt32("MaMucNganSach");
                _maChuongTrinh = dr.GetInt32("MaChuongTrinh");
                _maTaiKhoanCo = dr.GetInt32("MaTaiKhoanCo");
                _maButToan = dr.GetInt32("MaButToan");
                _maButToanChiPhiSanXuat = dr.GetInt32("MaButToanChiPhiSanXuat");
                _maButToanMucNganSach = dr.GetInt32("MaButToanMucNganSach");
                _maChiPhiThucHien = dr.GetInt32("MaChiPhiThucHien");
                _maChiThuLao = dr.GetInt32("MaChiThuLao");
                _maTaiKhoan = dr.GetInt32("MaTaiKhoan");
                _tenTaiKhoan = dr.GetString("TenTaiKhoan");
                _tenNguoiLap = dr.GetString("TenNguoiLap");
            }

            if (loai == 2)
            {
                _maChungTu = dr.GetInt64("MaChungTu");
                _soChungTu = dr.GetString("SoChungTu");
                _ngayLap = dr.GetDateTime("NgayLap");
                _soTien = dr.GetDecimal("SoTien");
                _soTienMucNganSach = dr.GetDecimal("SoTienMucNganSach");
                _soTienChiPhiSanXuat = dr.GetDecimal("SoTienChiPhiSanXuat");
                _tenMucNganSach = dr.GetString("TenMucNganSach");
                _tenTieuMucNganSach = dr.GetString("TenTieuMucNganSach");
                _tenChuongTrinh = dr.GetString("TenChuongTrinh");
                _tKCo = dr.GetString("TKCo");
                _maTieuMucNganSach = dr.GetInt32("MaTieuMucNganSach");
                _maMucNganSach = dr.GetInt32("MaMucNganSach");
                _maChuongTrinh = dr.GetInt32("MaChuongTrinh");
                _maTaiKhoanCo = dr.GetInt32("MaTaiKhoanCo");
                _maButToan = dr.GetInt32("MaButToan");
                _maButToanChiPhiSanXuat = dr.GetInt32("MaButToanChiPhiSanXuat");
                _maButToanMucNganSach = dr.GetInt32("MaButToanMucNganSach");
                _maChiPhiThucHien = dr.GetInt32("MaChiPhiThucHien");
                _maChiThuLao = dr.GetInt32("MaChiThuLao");
                _maTaiKhoan = dr.GetInt32("MaTaiKhoan");
                _tenTaiKhoan = dr.GetString("TenTaiKhoan");
                _tenNguoiLap = dr.GetString("TenNguoiLap");
                _maButToanMucNganSachNew = dr.GetInt32("MaButToanMucNganSachNew");
            }
            if (loai == 3)
            {
                _soChungTu = dr.GetString("SoChungTu");
                _ngayLap = dr.GetDateTime("NgayLap");
                _soTienBT = dr.GetDecimal("SoTienButToan");
                _soTienMucNganSach = dr.GetDecimal("SoTienMucNganSach");
                _GhiMucNganSach = dr.GetBoolean("GhiMucNganSach");
            }
        }

        private void FetchObject(SafeDataReader dr)
        {
            _soChungTu = dr.GetString("SoChungTu");
            _ngayLap = dr.GetDateTime("NgayLap");
            _soTien = dr.GetDecimal("SoTien");
            _tiGiaQuyDoi = dr.GetDecimal("TiGiaQuyDoi");
            _thanhTien = dr.GetDecimal("ThanhTien");
            _dienGiai = dr.GetString("DienGiai");
            _maLoaiChungTu = dr.GetString("MaLoaiChungTu");
            _tkno = dr.GetString("TKNO");
            _tKCo = dr.GetString("TKCo");
            _soTienBT = dr.GetDecimal("SoTienBT");
            _dienGiaiBT = dr.GetString("DienGiaiBT");
            _maTieuMuc = dr.GetString("MaTieuMuc");
            _soTienTieuMuc = dr.GetDecimal("SoTienTieuMuc");
            _dienGiaiMuc = dr.GetString("DienGiaiMuc");
            _maMucNganSachQL = dr.GetString("MaMucNganSachQL");
            _tenDoiTuongNo = dr.GetString("TenDoiTuongNo");
            _dCDoiTuongNo = dr.GetString("DCDoiTuongNo");
            _kHNgoai = dr.GetString("KHNgoai");
            _dCNgoai = dr.GetString("DCNgoai");
            _tenBoPhan = dr.GetString("TenBoPhan");
            _tenDangNhap = dr.GetString("TenDangNhap");
            _tenDoiTuongThuChi = dr.GetString("TenDoiTuongThuChi");
            _ngayThucHien = dr.GetDateTime("NgayThucHien");
            _maQLDoiTuongNo = dr.GetString("MaQLDoiTuongNo");
            _maQLDoiTuongCo = dr.GetString("MaQLDoiTuongCo");
            _tenDoiTuongCo = dr.GetString("TenDoiTuongCo");
            _dCDoiTuongCo = dr.GetString("DCDoiTuongCo");
            _maQLDoiTuongCT = dr.GetString("MaQLDoiTuongCT");
            _tenDoiTuongCT = dr.GetString("TenDoiTuongCT");
            _dCDoiTuongCT = dr.GetString("DCDoiTuongCT");
            //===============bo sung 2018.03.09
            _maDonViQL = dr.GetString("MaDonViQL");
            _tenDonVi = dr.GetString("TenDonVi");
            _maDonVi = dr.GetInt32("MaDonVi");
            _maHopDong = dr.GetInt64("MaHopDong");
            _soHopDong = dr.GetString("SoHopDong");
            _idKhoanMuc = dr.GetInt32("IDKhoanMuc");
            _maKhoanMucQL = dr.GetString("MaKhoanMucQL");
            _tenKhoanMuc = dr.GetString("TenKhoanMuc");
            _soHoaDon = dr.GetString("SoHoaDon");
            //=============bo sung 2018.07.27
            _soTKNganHang = dr.GetString("SoTKNganHang");
            _intMaLoaiChungTu = dr.GetInt32("intMaLoaiChungTu");
            _maChungTu = dr.GetInt64("MaChungTu");
            //=======bo sung 2018.12.16
            _billSeries = dr.GetString("billSeries");
            _soBienLai = dr.GetString("soBienLai");
            _namHoc = dr.GetString("namHoc");

        }

        private void FetchChildren(SafeDataReader dr)
        {
        }
        #endregion //Data Access - Fetch

        #region Data Access - Insert
        internal void Insert(SqlTransaction tr, XuatDuLieuList parent)
        {
            if (!IsDirty) return;

            ExecuteInsert(tr, parent);
            MarkOld();

            //update child object(s)
            UpdateChildren(tr);
        }

        private void ExecuteInsert(SqlTransaction tr, XuatDuLieuList parent)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_InserttblXuatDuLieu";

                AddInsertParameters(cm, parent);

                cm.ExecuteNonQuery();

            }//using
        }

        private void AddInsertParameters(SqlCommand cm, XuatDuLieuList parent)
        {
            //TODO: if parent use identity key, fix fk member with value from parent
            cm.Parameters.AddWithValue("@SoChungTu", _soChungTu);
            cm.Parameters.AddWithValue("@NgayLap", _ngayLap);
            if (_soTien != 0)
                cm.Parameters.AddWithValue("@SoTien", _soTien);
            else
                cm.Parameters.AddWithValue("@SoTien", DBNull.Value);
            if (_tiGiaQuyDoi != 0)
                cm.Parameters.AddWithValue("@TiGiaQuyDoi", _tiGiaQuyDoi);
            else
                cm.Parameters.AddWithValue("@TiGiaQuyDoi", DBNull.Value);
            if (_thanhTien != 0)
                cm.Parameters.AddWithValue("@ThanhTien", _thanhTien);
            else
                cm.Parameters.AddWithValue("@ThanhTien", DBNull.Value);
            if (_dienGiai.Length > 0)
                cm.Parameters.AddWithValue("@DienGiai", _dienGiai);
            else
                cm.Parameters.AddWithValue("@DienGiai", DBNull.Value);
            cm.Parameters.AddWithValue("@MaLoaiChungTu", _maLoaiChungTu);
            if (_tkno.Length > 0)
                cm.Parameters.AddWithValue("@TKNO", _tkno);
            else
                cm.Parameters.AddWithValue("@TKNO", DBNull.Value);
            if (_tKCo.Length > 0)
                cm.Parameters.AddWithValue("@TKCo", _tKCo);
            else
                cm.Parameters.AddWithValue("@TKCo", DBNull.Value);
            if (_soTienBT != 0)
                cm.Parameters.AddWithValue("@SoTienBT", _soTienBT);
            else
                cm.Parameters.AddWithValue("@SoTienBT", DBNull.Value);
            if (_dienGiaiBT.Length > 0)
                cm.Parameters.AddWithValue("@DienGiaiBT", _dienGiaiBT);
            else
                cm.Parameters.AddWithValue("@DienGiaiBT", DBNull.Value);
            if (_maTieuMuc.Length > 0)
                cm.Parameters.AddWithValue("@MaTieuMuc", _maTieuMuc);
            else
                cm.Parameters.AddWithValue("@MaTieuMuc", DBNull.Value);
            cm.Parameters.AddWithValue("@SoTienTieuMuc", _soTienTieuMuc);
            if (_dienGiaiMuc.Length > 0)
                cm.Parameters.AddWithValue("@DienGiaiMuc", _dienGiaiMuc);
            else
                cm.Parameters.AddWithValue("@DienGiaiMuc", DBNull.Value);
            if (_maMucNganSachQL.Length > 0)
                cm.Parameters.AddWithValue("@MaMucNganSachQL", _maMucNganSachQL);
            else
                cm.Parameters.AddWithValue("@MaMucNganSachQL", DBNull.Value);
            if (_tenDoiTuongNo.Length > 0)
                cm.Parameters.AddWithValue("@TenDoiTuongNo", _tenDoiTuongNo);
            else
                cm.Parameters.AddWithValue("@TenDoiTuongNo", DBNull.Value);
            if (_dCDoiTuongNo.Length > 0)
                cm.Parameters.AddWithValue("@DCDoiTuongNo", _dCDoiTuongNo);
            else
                cm.Parameters.AddWithValue("@DCDoiTuongNo", DBNull.Value);
            if (_kHNgoai.Length > 0)
                cm.Parameters.AddWithValue("@KHNgoai", _kHNgoai);
            else
                cm.Parameters.AddWithValue("@KHNgoai", DBNull.Value);
            if (_dCNgoai.Length > 0)
                cm.Parameters.AddWithValue("@DCNgoai", _dCNgoai);
            else
                cm.Parameters.AddWithValue("@DCNgoai", DBNull.Value);
            if (_tenBoPhan.Length > 0)
                cm.Parameters.AddWithValue("@TenBoPhan", _tenBoPhan);
            else
                cm.Parameters.AddWithValue("@TenBoPhan", DBNull.Value);
            cm.Parameters.AddWithValue("@TenDangNhap", _tenDangNhap);
            cm.Parameters.AddWithValue("@TenDoiTuongThuChi", _tenDoiTuongThuChi);
            cm.Parameters.AddWithValue("@NgayThucHien", _ngayThucHien);
            if (_maQLDoiTuongNo.Length > 0)
                cm.Parameters.AddWithValue("@MaQLDoiTuongNo", _maQLDoiTuongNo);
            else
                cm.Parameters.AddWithValue("@MaQLDoiTuongNo", DBNull.Value);
            if (_maQLDoiTuongCo.Length > 0)
                cm.Parameters.AddWithValue("@MaQLDoiTuongCo", _maQLDoiTuongCo);
            else
                cm.Parameters.AddWithValue("@MaQLDoiTuongCo", DBNull.Value);
            if (_tenDoiTuongCo.Length > 0)
                cm.Parameters.AddWithValue("@TenDoiTuongCo", _tenDoiTuongCo);
            else
                cm.Parameters.AddWithValue("@TenDoiTuongCo", DBNull.Value);
            if (_dCDoiTuongCo.Length > 0)
                cm.Parameters.AddWithValue("@DCDoiTuongCo", _dCDoiTuongCo);
            else
                cm.Parameters.AddWithValue("@DCDoiTuongCo", DBNull.Value);
            if (_maQLDoiTuongCT.Length > 0)
                cm.Parameters.AddWithValue("@MaQLDoiTuongCT", _maQLDoiTuongCT);
            else
                cm.Parameters.AddWithValue("@MaQLDoiTuongCT", DBNull.Value);
            if (_tenDoiTuongCT.Length > 0)
                cm.Parameters.AddWithValue("@TenDoiTuongCT", _tenDoiTuongCT);
            else
                cm.Parameters.AddWithValue("@TenDoiTuongCT", DBNull.Value);
            if (_dCDoiTuongCT.Length > 0)
                cm.Parameters.AddWithValue("@DCDoiTuongCT", _dCDoiTuongCT);
            else
                cm.Parameters.AddWithValue("@DCDoiTuongCT", DBNull.Value);
        }
        #endregion //Data Access - Insert

        #region Data Access - Update
        internal void Update(SqlTransaction tr, XuatDuLieuList parent)
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

        private void ExecuteUpdate(SqlTransaction tr, XuatDuLieuList parent)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_UpdatetblXuatDuLieu";

                AddUpdateParameters(cm, parent);

                cm.ExecuteNonQuery();

            }//using
        }

        private void AddUpdateParameters(SqlCommand cm, XuatDuLieuList parent)
        {
            cm.Parameters.AddWithValue("@SoChungTu", _soChungTu);
            cm.Parameters.AddWithValue("@NgayLap", _ngayLap);
            if (_soTien != 0)
                cm.Parameters.AddWithValue("@SoTien", _soTien);
            else
                cm.Parameters.AddWithValue("@SoTien", DBNull.Value);
            if (_tiGiaQuyDoi != 0)
                cm.Parameters.AddWithValue("@TiGiaQuyDoi", _tiGiaQuyDoi);
            else
                cm.Parameters.AddWithValue("@TiGiaQuyDoi", DBNull.Value);
            if (_thanhTien != 0)
                cm.Parameters.AddWithValue("@ThanhTien", _thanhTien);
            else
                cm.Parameters.AddWithValue("@ThanhTien", DBNull.Value);
            if (_dienGiai.Length > 0)
                cm.Parameters.AddWithValue("@DienGiai", _dienGiai);
            else
                cm.Parameters.AddWithValue("@DienGiai", DBNull.Value);
            cm.Parameters.AddWithValue("@MaLoaiChungTu", _maLoaiChungTu);
            if (_tkno.Length > 0)
                cm.Parameters.AddWithValue("@TKNO", _tkno);
            else
                cm.Parameters.AddWithValue("@TKNO", DBNull.Value);
            if (_tKCo.Length > 0)
                cm.Parameters.AddWithValue("@TKCo", _tKCo);
            else
                cm.Parameters.AddWithValue("@TKCo", DBNull.Value);
            if (_soTienBT != 0)
                cm.Parameters.AddWithValue("@SoTienBT", _soTienBT);
            else
                cm.Parameters.AddWithValue("@SoTienBT", DBNull.Value);
            if (_dienGiaiBT.Length > 0)
                cm.Parameters.AddWithValue("@DienGiaiBT", _dienGiaiBT);
            else
                cm.Parameters.AddWithValue("@DienGiaiBT", DBNull.Value);
            if (_maTieuMuc.Length > 0)
                cm.Parameters.AddWithValue("@MaTieuMuc", _maTieuMuc);
            else
                cm.Parameters.AddWithValue("@MaTieuMuc", DBNull.Value);
            cm.Parameters.AddWithValue("@SoTienTieuMuc", _soTienTieuMuc);
            if (_dienGiaiMuc.Length > 0)
                cm.Parameters.AddWithValue("@DienGiaiMuc", _dienGiaiMuc);
            else
                cm.Parameters.AddWithValue("@DienGiaiMuc", DBNull.Value);
            if (_maMucNganSachQL.Length > 0)
                cm.Parameters.AddWithValue("@MaMucNganSachQL", _maMucNganSachQL);
            else
                cm.Parameters.AddWithValue("@MaMucNganSachQL", DBNull.Value);
            if (_tenDoiTuongNo.Length > 0)
                cm.Parameters.AddWithValue("@TenDoiTuongNo", _tenDoiTuongNo);
            else
                cm.Parameters.AddWithValue("@TenDoiTuongNo", DBNull.Value);
            if (_dCDoiTuongNo.Length > 0)
                cm.Parameters.AddWithValue("@DCDoiTuongNo", _dCDoiTuongNo);
            else
                cm.Parameters.AddWithValue("@DCDoiTuongNo", DBNull.Value);
            if (_kHNgoai.Length > 0)
                cm.Parameters.AddWithValue("@KHNgoai", _kHNgoai);
            else
                cm.Parameters.AddWithValue("@KHNgoai", DBNull.Value);
            if (_dCNgoai.Length > 0)
                cm.Parameters.AddWithValue("@DCNgoai", _dCNgoai);
            else
                cm.Parameters.AddWithValue("@DCNgoai", DBNull.Value);
            if (_tenBoPhan.Length > 0)
                cm.Parameters.AddWithValue("@TenBoPhan", _tenBoPhan);
            else
                cm.Parameters.AddWithValue("@TenBoPhan", DBNull.Value);
            cm.Parameters.AddWithValue("@TenDangNhap", _tenDangNhap);
            cm.Parameters.AddWithValue("@TenDoiTuongThuChi", _tenDoiTuongThuChi);
            cm.Parameters.AddWithValue("@NgayThucHien", _ngayThucHien);
            if (_maQLDoiTuongNo.Length > 0)
                cm.Parameters.AddWithValue("@MaQLDoiTuongNo", _maQLDoiTuongNo);
            else
                cm.Parameters.AddWithValue("@MaQLDoiTuongNo", DBNull.Value);
            if (_maQLDoiTuongCo.Length > 0)
                cm.Parameters.AddWithValue("@MaQLDoiTuongCo", _maQLDoiTuongCo);
            else
                cm.Parameters.AddWithValue("@MaQLDoiTuongCo", DBNull.Value);
            if (_tenDoiTuongCo.Length > 0)
                cm.Parameters.AddWithValue("@TenDoiTuongCo", _tenDoiTuongCo);
            else
                cm.Parameters.AddWithValue("@TenDoiTuongCo", DBNull.Value);
            if (_dCDoiTuongCo.Length > 0)
                cm.Parameters.AddWithValue("@DCDoiTuongCo", _dCDoiTuongCo);
            else
                cm.Parameters.AddWithValue("@DCDoiTuongCo", DBNull.Value);
            if (_maQLDoiTuongCT.Length > 0)
                cm.Parameters.AddWithValue("@MaQLDoiTuongCT", _maQLDoiTuongCT);
            else
                cm.Parameters.AddWithValue("@MaQLDoiTuongCT", DBNull.Value);
            if (_tenDoiTuongCT.Length > 0)
                cm.Parameters.AddWithValue("@TenDoiTuongCT", _tenDoiTuongCT);
            else
                cm.Parameters.AddWithValue("@TenDoiTuongCT", DBNull.Value);
            if (_dCDoiTuongCT.Length > 0)
                cm.Parameters.AddWithValue("@DCDoiTuongCT", _dCDoiTuongCT);
            else
                cm.Parameters.AddWithValue("@DCDoiTuongCT", DBNull.Value);
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

            ExecuteDelete(tr, new Criteria(_soChungTu, _ngayLap));
            MarkNew();
        }
        #endregion //Data Access - Delete
        #endregion //Data Access
    }
}
