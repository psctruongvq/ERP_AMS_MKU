
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{ 
	[Serializable()] 
	public class HoatDongXaHoi : Csla.BusinessBase<HoatDongXaHoi>
	{
        #region Business Properties and Methods

        //declare members
        #region Prope
        private int _maHoatDongXH = 0;
        private long _maNhanVien = 0;
        private string _soTheCongDoan = string.Empty;
        //private string _CoQuanTuyenDungCongChuc = string.Empty;
        private Nullable<DateTime> _ngayThamGia =null;
        private Nullable<DateTime> _ngayKetThucCD = null;
        private int _maChucVuCongDoan = 0;
        private string _soTheDoan = string.Empty;
        private Nullable<DateTime> _ngayKetNapDoan = null;
        private Nullable<DateTime> _ngayKetThucDoan = null;
        private int _maChucVuDoan = 0;
        private string _nhiemVu = string.Empty;
        private int _maQuanHam = 0;
        private string _donVi = string.Empty;
        private Nullable<DateTime> _ngayNhapNgu = null;
        private Nullable<DateTime> _ngayXuatNgu = null;
        private int _maChucVuQuanDoi = 0;
        private Nullable<DateTime> _ngayThamGiaCM = null;
        private string _toChuc = string.Empty;
        private int _maChucVuCachMang = 0;
        private string _soTheDang = string.Empty;
        private Nullable<DateTime> _ngayVaoDang = null;
        private Nullable<DateTime> _ngayChinhThuc = null;
        private Nullable<DateTime> _ngayRaKhoiDang = null;
        private int _maChucVuDang = 0;
        private int _maKiemNhiem = 0;
        private string _noiSinhHoatDang = string.Empty;
        private string _diaChiNoiSH = string.Empty;
        private string _chiboNgayvaodang = string.Empty;
        private string _chiboNgayvaochinhthuc = string.Empty;
        private string _chucvuNguoigioithieu2 = string.Empty;
        private string _chucvuNguoigioithieu1 = string.Empty;
        private string _nguoiGioiThieu1 = string.Empty;
        private string _nguoiGioiThieu2 = string.Empty;
        private string _ngheNghiepKhiVaoDang = string.Empty;
        private string _conViecChinhDangLam = string.Empty;
        private Nullable<DateTime> _ngayTDLamCongChuc = null;
        private string _thamGiaCacHoatDongKhac = string.Empty;
        private string _quaTrinhHoatDongVaCongTac = string.Empty;
        private string _dacDiemLichSuBanThan = string.Empty;
        private string _quanHeGiaDinh = string.Empty;
        private string _hoanCanhKinhTeBanThan = string.Empty;
        private string _kyLuat = string.Empty;
        private string _danhHieuDuocPhong = string.Empty;
        private string _soHuyHieuDang = string.Empty;
        private string _khenThuong = string.Empty;
        private Nullable<DateTime> _ngayVaoDangLan2 = null;
        private string _chiboDdbt = string.Empty;
        private string _nguoigioithieu1Ddbt = string.Empty;
        private string _chucvuDdbtNguoigioithieu1 = string.Empty;
        private string _nguoigioithieu2Ddbt = string.Empty;
        private string _chucvuDdbtNguoigioithieu2 = string.Empty;
        private Nullable<DateTime> _ngaychinhthuclan2Ddbt = null;
        private string _chiboNgaychinhthuc2Ddbt = string.Empty;
        private Nullable<DateTime> _ngayMienCongTacVaSHD = null;
        private string _ChiBo_KhoiPhucDangTich = string.Empty;
        //private SmartDate _NgayKhoiPhucDangTich = new SmartDate(false);
        private string _coQuanTuyenDungCongChuc = string.Empty;
        private Nullable<DateTime> _ngayKhoiPhucDangTich = null;
        private string _chiboKhoiphucdangtich = string.Empty;
        private int _maLoaiDangVien = 0;
        private bool _thamGiaQuanDoi = false;
        private int _maTruongDaoTao = 0;
        #endregion Prope
        [System.ComponentModel.DataObjectField(true, true)]
        public int MaHoatDongXH
        {
            get
            {
                CanReadProperty("MaHoatDongXH", true);
                return _maHoatDongXH;
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
        public bool ThamGiaQuanDoi
        {
            get
            {
                CanReadProperty("ThamGiaQuanDoi", true);
                return _thamGiaQuanDoi;
            }
            set
            {
                CanWriteProperty("ThamGiaQuanDoi", true);
                if (!_thamGiaQuanDoi.Equals(value))
                {
                    _thamGiaQuanDoi = value;
                    PropertyHasChanged("ThamGiaQuanDoi");
                }
            }
        }
        public string ChiBo_KhoiPhucDangTich
        {
            get
            {
                CanReadProperty("ChiBo_KhoiPhucDangTich", true);
                return _ChiBo_KhoiPhucDangTich;
            }
            set
            {
                CanWriteProperty("ChiBo_KhoiPhucDangTich", true);
                if (value == null) value = string.Empty;
                if (!_ChiBo_KhoiPhucDangTich.Equals(value))
                {
                    _ChiBo_KhoiPhucDangTich = value;
                    PropertyHasChanged("ChiBo_KhoiPhucDangTich");
                }
            }
        }

        public Nullable<DateTime> NgayKhoiPhucDangTich
        {
            get
            {
                CanReadProperty("NgayKhoiPhucDangTich", true);
                return _ngayKhoiPhucDangTich;
            }
            set
            {
                CanWriteProperty(true);
                if (!_ngayKhoiPhucDangTich.Equals(value))
                {
                    _ngayKhoiPhucDangTich = value;
                    PropertyHasChanged("NgayKhoiPhucDangTich");
                }
            }
        }
        public string SoTheCongDoan
        {
            get
            {
                CanReadProperty("SoTheCongDoan", true);
                return _soTheCongDoan;
            }
            set
            {
                CanWriteProperty("SoTheCongDoan", true);
                if (value == null) value = string.Empty;
                if (!_soTheCongDoan.Equals(value))
                {
                    _soTheCongDoan = value;
                    PropertyHasChanged("SoTheCongDoan");
                }
            }
        }

        public Nullable<DateTime> NgayThamGia
        {
            get
            {
                CanReadProperty("NgayThamGia", true);
                return _ngayThamGia;
            }
            set
            {
                CanWriteProperty(true);
                if (!_ngayThamGia.Equals(value))
                {
                    _ngayThamGia = value;
                    PropertyHasChanged("NgayThamGia");
                }
            }
        }

        public string CoQuanTuyenDungCongChuc
        {
            get
            {
                CanReadProperty("CoQuanTuyenDungCongChuc", true);
                return _coQuanTuyenDungCongChuc;
            }
            set
            {
                CanWriteProperty("CoQuanTuyenDungCongChuc", true);
                if (value == null) value = string.Empty;
                if (!_coQuanTuyenDungCongChuc.Equals(value))
                {
                    _coQuanTuyenDungCongChuc = value;
                    PropertyHasChanged("CoQuanTuyenDungCongChuc");
                }
            }
        }

        public Nullable<DateTime> NgayKetThucCD
        {
            get
            {
                CanReadProperty("NgayKetThucCD", true);
                return _ngayKetThucCD;
            }
            set
            {
                CanWriteProperty(true);
                if (!_ngayKetThucCD.Equals(value))
                {
                    _ngayKetThucCD =value;
                    PropertyHasChanged("NgayKetThucCD");
                }
            }
        }

       

        public int MaChucVuCongDoan
        {
            get
            {
                CanReadProperty("MaChucVuCongDoan", true);
                return _maChucVuCongDoan;
            }
            set
            {
                CanWriteProperty("MaChucVuCongDoan", true);
                if (!_maChucVuCongDoan.Equals(value))
                {
                    _maChucVuCongDoan = value;
                    PropertyHasChanged("MaChucVuCongDoan");
                }
            }
        }

        public string SoTheDoan
        {
            get
            {
                CanReadProperty("SoTheDoan", true);
                return _soTheDoan;
            }
            set
            {
                CanWriteProperty("SoTheDoan", true);
                if (value == null) value = string.Empty;
                if (!_soTheDoan.Equals(value))
                {
                    _soTheDoan = value;
                    PropertyHasChanged("SoTheDoan");
                }
            }
        }

        public Nullable<DateTime> NgayKetNapDoan
        {
            get
            {
                CanReadProperty("NgayKetNapDoan", true);
                return _ngayKetNapDoan;
            }
            set
            {
                CanWriteProperty(true);
                if (!_ngayKetNapDoan.Equals(value))
                {
                    _ngayKetNapDoan = value;
                    PropertyHasChanged("NgayKetNapDoan");
                }
            }
        }



        public Nullable<DateTime> NgayKetThucDoan
        {
            get
            {
                CanReadProperty("NgayKetThucDoan", true);
                return _ngayKetThucDoan;
            }
            set
            {
                CanWriteProperty(true);
                if (!_ngayKetThucDoan.Equals(value))
                {
                    _ngayKetThucDoan =null;
                    PropertyHasChanged("NgayKetThucDoan");
                }
            }
        }

    

        public int MaChucVuDoan
        {
            get
            {
                CanReadProperty("MaChucVuDoan", true);
                return _maChucVuDoan;
            }
            set
            {
                CanWriteProperty("MaChucVuDoan", true);
                if (!_maChucVuDoan.Equals(value))
                {
                    _maChucVuDoan = value;
                    PropertyHasChanged("MaChucVuDoan");
                }
            }
        }

        public string NhiemVu
        {
            get
            {
                CanReadProperty("NhiemVu", true);
                return _nhiemVu;
            }
            set
            {
                CanWriteProperty("NhiemVu", true);
                if (value == null) value = string.Empty;
                if (!_nhiemVu.Equals(value))
                {
                    _nhiemVu = value;
                    PropertyHasChanged("NhiemVu");
                }
            }
        }

        public int MaQuanHam
        {
            get
            {
                CanReadProperty("MaQuanHam", true);
                return _maQuanHam;
            }
            set
            {
                CanWriteProperty("MaQuanHam", true);
                if (!_maQuanHam.Equals(value))
                {
                    _maQuanHam = value;
                    PropertyHasChanged("MaQuanHam");
                }
            }
        }

        public string DonVi
        {
            get
            {
                CanReadProperty("DonVi", true);
                return _donVi;
            }
            set
            {
                CanWriteProperty("DonVi", true);
                if (value == null) value = string.Empty;
                if (!_donVi.Equals(value))
                {
                    _donVi = value;
                    PropertyHasChanged("DonVi");
                }
            }
        }

        public Nullable<DateTime> NgayNhapNgu
        {
            get
            {
                CanReadProperty("NgayNhapNgu", true);
                return _ngayNhapNgu;
            }
            set
            {
                CanWriteProperty(true);
                if (!_ngayNhapNgu.Equals(value))
                {
                    _ngayNhapNgu = value;
                    PropertyHasChanged("NgayNhapNgu");
                }
            }
        }



        public Nullable<DateTime> NgayXuatNgu
        {
            get
            {
                CanReadProperty("NgayXuatNgu", true);
                return _ngayXuatNgu;
            }
            set
            {
                CanWriteProperty(true);
                if (!_ngayXuatNgu.Equals(value))
                {
                    _ngayXuatNgu =value;
                    PropertyHasChanged("NgayXuatNgu");
                }
            }
        }

     
        public int MaChucVuQuanDoi
        {
            get
            {
                CanReadProperty("MaChucVuQuanDoi", true);
                return _maChucVuQuanDoi;
            }
            set
            {
                CanWriteProperty("MaChucVuQuanDoi", true);
                if (!_maChucVuQuanDoi.Equals(value))
                {
                    _maChucVuQuanDoi = value;
                    PropertyHasChanged("MaChucVuQuanDoi");
                }
            }
        }

        public Nullable<DateTime> NgayThamGiaCM
        {
            get
            {
                CanReadProperty("NgayThamGiaCM", true);
                return _ngayThamGiaCM;
            }
            set
            {
                CanWriteProperty(true);
                if (!_ngayThamGiaCM.Equals(value))
                {
                    _ngayThamGiaCM = value;
                    PropertyHasChanged("NgayThamGiaCM");
                }
            }
        }

      

        public string ToChuc
        {
            get
            {
                CanReadProperty("ToChuc", true);
                return _toChuc;
            }
            set
            {
                CanWriteProperty("ToChuc", true);
                if (value == null) value = string.Empty;
                if (!_toChuc.Equals(value))
                {
                    _toChuc = value;
                    PropertyHasChanged("ToChuc");
                }
            }
        }

        public int MaChucVuCachMang
        {
            get
            {
                CanReadProperty("MaChucVuCachMang", true);
                return _maChucVuCachMang;
            }
            set
            {
                CanWriteProperty("MaChucVuCachMang", true);
                if (!_maChucVuCachMang.Equals(value))
                {
                    _maChucVuCachMang = value;
                    PropertyHasChanged("MaChucVuCachMang");
                }
            }
        }

        public string SoTheDang
        {
            get
            {
                CanReadProperty("SoTheDang", true);
                return _soTheDang;
            }
            set
            {
                CanWriteProperty("SoTheDang", true);
                if (value == null) value = string.Empty;
                if (!_soTheDang.Equals(value))
                {
                    _soTheDang = value;
                    PropertyHasChanged("SoTheDang");
                }
            }
        }

        public Nullable<DateTime> NgayVaoDang
        {
            get
            {
                CanReadProperty("NgayVaoDang", true);
                return _ngayVaoDang;
            }
            set
            {
                CanWriteProperty(true);
                if (!_ngayVaoDang.Equals(value))
                {
                    _ngayVaoDang = value;
                    PropertyHasChanged("NgayVaoDang");
                }
            }
        }



        public Nullable<DateTime> NgayChinhThuc
        {
            get
            {
                CanReadProperty("NgayChinhThuc", true);
                return _ngayChinhThuc;
            }
            set
            {
                CanWriteProperty(true);
                if (!_ngayChinhThuc.Equals(value))
                {
                    _ngayChinhThuc =value;
                    PropertyHasChanged("NgayChinhThuc");
                }
            }
        }


        public Nullable<DateTime> NgayRaKhoiDang
        {
            get
            {
                CanReadProperty("NgayRaKhoiDang", true);
                return _ngayRaKhoiDang;
            }
            set
            {
                CanWriteProperty(true);
                if (!_ngayRaKhoiDang.Equals(value))
                {
                    _ngayRaKhoiDang = value;
                    PropertyHasChanged("NgayRaKhoiDang");
                }
            }
        }

      

        public int MaChucVuDang
        {
            get
            {
                CanReadProperty("MaChucVuDang", true);
                return _maChucVuDang;
            }
            set
            {
                CanWriteProperty("MaChucVuDang", true);
                if (!_maChucVuDang.Equals(value))
                {
                    _maChucVuDang = value;
                    PropertyHasChanged("MaChucVuDang");
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

        public string NoiSinhHoatDang
        {
            get
            {
                CanReadProperty("NoiSinhHoatDang", true);
                return _noiSinhHoatDang;
            }
            set
            {
                CanWriteProperty("NoiSinhHoatDang", true);
                if (value == null) value = string.Empty;
                if (!_noiSinhHoatDang.Equals(value))
                {
                    _noiSinhHoatDang = value;
                    PropertyHasChanged("NoiSinhHoatDang");
                }
            }
        }

        public string DiaChiNoiSH
        {
            get
            {
                CanReadProperty("DiaChiNoiSH", true);
                return _diaChiNoiSH;
            }
            set
            {
                CanWriteProperty("DiaChiNoiSH", true);
                if (value == null) value = string.Empty;
                if (!_diaChiNoiSH.Equals(value))
                {
                    _diaChiNoiSH = value;
                    PropertyHasChanged("DiaChiNoiSH");
                }
            }
        }

        public string ChiboNgayvaodang
        {
            get
            {
                CanReadProperty("ChiboNgayvaodang", true);
                return _chiboNgayvaodang;
            }
            set
            {
                CanWriteProperty("ChiboNgayvaodang", true);
                if (value == null) value = string.Empty;
                if (!_chiboNgayvaodang.Equals(value))
                {
                    _chiboNgayvaodang = value;
                    PropertyHasChanged("ChiboNgayvaodang");
                }
            }
        }

        public string ChiboNgayvaochinhthuc
        {
            get
            {
                CanReadProperty("ChiboNgayvaochinhthuc", true);
                return _chiboNgayvaochinhthuc;
            }
            set
            {
                CanWriteProperty("ChiboNgayvaochinhthuc", true);
                if (value == null) value = string.Empty;
                if (!_chiboNgayvaochinhthuc.Equals(value))
                {
                    _chiboNgayvaochinhthuc = value;
                    PropertyHasChanged("ChiboNgayvaochinhthuc");
                }
            }
        }

        public string ChucvuNguoigioithieu2
        {
            get
            {
                CanReadProperty("ChucvuNguoigioithieu2", true);
                return _chucvuNguoigioithieu2;
            }
            set
            {
                CanWriteProperty("ChucvuNguoigioithieu2", true);
                if (value == null) value = string.Empty;
                if (!_chucvuNguoigioithieu2.Equals(value))
                {
                    _chucvuNguoigioithieu2 = value;
                    PropertyHasChanged("ChucvuNguoigioithieu2");
                }
            }
        }

        public string ChucvuNguoigioithieu1
        {
            get
            {
                CanReadProperty("ChucvuNguoigioithieu1", true);
                return _chucvuNguoigioithieu1;
            }
            set
            {
                CanWriteProperty("ChucvuNguoigioithieu1", true);
                if (value == null) value = string.Empty;
                if (!_chucvuNguoigioithieu1.Equals(value))
                {
                    _chucvuNguoigioithieu1 = value;
                    PropertyHasChanged("ChucvuNguoigioithieu1");
                }
            }
        }

        public string NguoiGioiThieu1
        {
            get
            {
                CanReadProperty("NguoiGioiThieu1", true);
                return _nguoiGioiThieu1;
            }
            set
            {
                CanWriteProperty("NguoiGioiThieu1", true);
                if (value == null) value = string.Empty;
                if (!_nguoiGioiThieu1.Equals(value))
                {
                    _nguoiGioiThieu1 = value;
                    PropertyHasChanged("NguoiGioiThieu1");
                }
            }
        }

        public string NguoiGioiThieu2
        {
            get
            {
                CanReadProperty("NguoiGioiThieu2", true);
                return _nguoiGioiThieu2;
            }
            set
            {
                CanWriteProperty("NguoiGioiThieu2", true);
                if (value == null) value = string.Empty;
                if (!_nguoiGioiThieu2.Equals(value))
                {
                    _nguoiGioiThieu2 = value;
                    PropertyHasChanged("NguoiGioiThieu2");
                }
            }
        }

        public string NgheNghiepKhiVaoDang
        {
            get
            {
                CanReadProperty("NgheNghiepKhiVaoDang", true);
                return _ngheNghiepKhiVaoDang;
            }
            set
            {
                CanWriteProperty("NgheNghiepKhiVaoDang", true);
                if (value == null) value = string.Empty;
                if (!_ngheNghiepKhiVaoDang.Equals(value))
                {
                    _ngheNghiepKhiVaoDang = value;
                    PropertyHasChanged("NgheNghiepKhiVaoDang");
                }
            }
        }

        public string ConViecChinhDangLam
        {
            get
            {
                CanReadProperty("ConViecChinhDangLam", true);
                return _conViecChinhDangLam;
            }
            set
            {
                CanWriteProperty("ConViecChinhDangLam", true);
                if (value == null) value = string.Empty;
                if (!_conViecChinhDangLam.Equals(value))
                {
                    _conViecChinhDangLam = value;
                    PropertyHasChanged("ConViecChinhDangLam");
                }
            }
        }

        public Nullable<DateTime> NgayTDLamCongChuc
        {
            get
            {
                CanReadProperty("NgayTDLamCongChuc", true);
                return _ngayTDLamCongChuc;
            }
            set
            {
                CanWriteProperty(true);
                if (!_ngayTDLamCongChuc.Equals(value))
                {
                    _ngayTDLamCongChuc =value;
                    PropertyHasChanged("NgayTDLamCongChuc");
                }
            }
        }

     

        public string ThamGiaCacHoatDongKhac
        {
            get
            {
                CanReadProperty("ThamGiaCacHoatDongKhac", true);
                return _thamGiaCacHoatDongKhac;
            }
            set
            {
                CanWriteProperty("ThamGiaCacHoatDongKhac", true);
                if (value == null) value = string.Empty;
                if (!_thamGiaCacHoatDongKhac.Equals(value))
                {
                    _thamGiaCacHoatDongKhac = value;
                    PropertyHasChanged("ThamGiaCacHoatDongKhac");
                }
            }
        }

        public string QuaTrinhHoatDongVaCongTac
        {
            get
            {
                CanReadProperty("QuaTrinhHoatDongVaCongTac", true);
                return _quaTrinhHoatDongVaCongTac;
            }
            set
            {
                CanWriteProperty("QuaTrinhHoatDongVaCongTac", true);
                if (value == null) value = string.Empty;
                if (!_quaTrinhHoatDongVaCongTac.Equals(value))
                {
                    _quaTrinhHoatDongVaCongTac = value;
                    PropertyHasChanged("QuaTrinhHoatDongVaCongTac");
                }
            }
        }

        public string DacDiemLichSuBanThan
        {
            get
            {
                CanReadProperty("DacDiemLichSuBanThan", true);
                return _dacDiemLichSuBanThan;
            }
            set
            {
                CanWriteProperty("DacDiemLichSuBanThan", true);
                if (value == null) value = string.Empty;
                if (!_dacDiemLichSuBanThan.Equals(value))
                {
                    _dacDiemLichSuBanThan = value;
                    PropertyHasChanged("DacDiemLichSuBanThan");
                }
            }
        }

        public string QuanHeGiaDinh
        {
            get
            {
                CanReadProperty("QuanHeGiaDinh", true);
                return _quanHeGiaDinh;
            }
            set
            {
                CanWriteProperty("QuanHeGiaDinh", true);
                if (value == null) value = string.Empty;
                if (!_quanHeGiaDinh.Equals(value))
                {
                    _quanHeGiaDinh = value;
                    PropertyHasChanged("QuanHeGiaDinh");
                }
            }
        }

        public string HoanCanhKinhTeBanThan
        {
            get
            {
                CanReadProperty("HoanCanhKinhTeBanThan", true);
                return _hoanCanhKinhTeBanThan;
            }
            set
            {
                CanWriteProperty("HoanCanhKinhTeBanThan", true);
                if (value == null) value = string.Empty;
                if (!_hoanCanhKinhTeBanThan.Equals(value))
                {
                    _hoanCanhKinhTeBanThan = value;
                    PropertyHasChanged("HoanCanhKinhTeBanThan");
                }
            }
        }

        public string KyLuat
        {
            get
            {
                CanReadProperty("KyLuat", true);
                return _kyLuat;
            }
            set
            {
                CanWriteProperty("KyLuat", true);
                if (value == null) value = string.Empty;
                if (!_kyLuat.Equals(value))
                {
                    _kyLuat = value;
                    PropertyHasChanged("KyLuat");
                }
            }
        }

        public string DanhHieuDuocPhong
        {
            get
            {
                CanReadProperty("DanhHieuDuocPhong", true);
                return _danhHieuDuocPhong;
            }
            set
            {
                CanWriteProperty("DanhHieuDuocPhong", true);
                if (value == null) value = string.Empty;
                if (!_danhHieuDuocPhong.Equals(value))
                {
                    _danhHieuDuocPhong = value;
                    PropertyHasChanged("DanhHieuDuocPhong");
                }
            }
        }

        public string SoHuyHieuDang
        {
            get
            {
                CanReadProperty("SoHuyHieuDang", true);
                return _soHuyHieuDang;
            }
            set
            {
                CanWriteProperty("SoHuyHieuDang", true);
                if (value == null) value = string.Empty;
                if (!_soHuyHieuDang.Equals(value))
                {
                    _soHuyHieuDang = value;
                    PropertyHasChanged("SoHuyHieuDang");
                }
            }
        }

        public string KhenThuong
        {
            get
            {
                CanReadProperty("KhenThuong", true);
                return _khenThuong;
            }
            set
            {
                CanWriteProperty("KhenThuong", true);
                if (value == null) value = string.Empty;
                if (!_khenThuong.Equals(value))
                {
                    _khenThuong = value;
                    PropertyHasChanged("KhenThuong");
                }
            }
        }

        public Nullable<DateTime> NgayVaoDangLan2
        {
            get
            {
                CanReadProperty("NgayVaoDangLan2", true);
                return _ngayVaoDangLan2;
            }
            set
            {
                CanWriteProperty(true);
                if (!_ngayVaoDangLan2.Equals(value))
                {
                    _ngayVaoDangLan2 = value;
                    PropertyHasChanged("NgayVaoDangLan2");
                }
            }
        }

   
        public string ChiboDdbt
        {
            get
            {
                CanReadProperty("ChiboDdbt", true);
                return _chiboDdbt;
            }
            set
            {
                CanWriteProperty("ChiboDdbt", true);
                if (value == null) value = string.Empty;
                if (!_chiboDdbt.Equals(value))
                {
                    _chiboDdbt = value;
                    PropertyHasChanged("ChiboDdbt");
                }
            }
        }

        public string Nguoigioithieu1Ddbt
        {
            get
            {
                CanReadProperty("Nguoigioithieu1Ddbt", true);
                return _nguoigioithieu1Ddbt;
            }
            set
            {
                CanWriteProperty("Nguoigioithieu1Ddbt", true);
                if (value == null) value = string.Empty;
                if (!_nguoigioithieu1Ddbt.Equals(value))
                {
                    _nguoigioithieu1Ddbt = value;
                    PropertyHasChanged("Nguoigioithieu1Ddbt");
                }
            }
        }

        public string ChucvuDdbtNguoigioithieu1
        {
            get
            {
                CanReadProperty("ChucvuDdbtNguoigioithieu1", true);
                return _chucvuDdbtNguoigioithieu1;
            }
            set
            {
                CanWriteProperty("ChucvuDdbtNguoigioithieu1", true);
                if (value == null) value = string.Empty;
                if (!_chucvuDdbtNguoigioithieu1.Equals(value))
                {
                    _chucvuDdbtNguoigioithieu1 = value;
                    PropertyHasChanged("ChucvuDdbtNguoigioithieu1");
                }
            }
        }

        public string Nguoigioithieu2Ddbt
        {
            get
            {
                CanReadProperty("Nguoigioithieu2Ddbt", true);
                return _nguoigioithieu2Ddbt;
            }
            set
            {
                CanWriteProperty("Nguoigioithieu2Ddbt", true);
                if (value == null) value = string.Empty;
                if (!_nguoigioithieu2Ddbt.Equals(value))
                {
                    _nguoigioithieu2Ddbt = value;
                    PropertyHasChanged("Nguoigioithieu2Ddbt");
                }
            }
        }

        public string ChucvuDdbtNguoigioithieu2
        {
            get
            {
                CanReadProperty("ChucvuDdbtNguoigioithieu2", true);
                return _chucvuDdbtNguoigioithieu2;
            }
            set
            {
                CanWriteProperty("ChucvuDdbtNguoigioithieu2", true);
                if (value == null) value = string.Empty;
                if (!_chucvuDdbtNguoigioithieu2.Equals(value))
                {
                    _chucvuDdbtNguoigioithieu2 = value;
                    PropertyHasChanged("ChucvuDdbtNguoigioithieu2");
                }
            }
        }

        public Nullable<DateTime> Ngaychinhthuclan2Ddbt
        {
            get
            {
                CanReadProperty("Ngaychinhthuclan2Ddbt", true);
                return _ngaychinhthuclan2Ddbt;
            }
            set
            {
                CanWriteProperty(true);
                if (!_ngaychinhthuclan2Ddbt.Equals(value))
                {
                    _ngaychinhthuclan2Ddbt =value;
                    PropertyHasChanged("Ngaychinhthuclan2Ddbt");
                }
            }
        }

    

        public string ChiboNgaychinhthuc2Ddbt
        {
            get
            {
                CanReadProperty("ChiboNgaychinhthuc2Ddbt", true);
                return _chiboNgaychinhthuc2Ddbt;
            }
            set
            {
                CanWriteProperty("ChiboNgaychinhthuc2Ddbt", true);
                if (value == null) value = string.Empty;
                if (!_chiboNgaychinhthuc2Ddbt.Equals(value))
                {
                    _chiboNgaychinhthuc2Ddbt = value;
                    PropertyHasChanged("ChiboNgaychinhthuc2Ddbt");
                }
            }
        }

        public Nullable<DateTime> NgayMienCongTacVaSHD
        {
            get
            {
                CanReadProperty("NgayMienCongTacVaSHD", true);
                return _ngayMienCongTacVaSHD;
            }
            set
            {
                CanWriteProperty(true);
                if (!_ngayMienCongTacVaSHD.Equals(value))
                {
                    _ngayMienCongTacVaSHD = value;
                    PropertyHasChanged("NgayMienCongTacVaSHD");
                }
            }
        }


       
        public string ChiboKhoiphucdangtich
        {
            get
            {
                CanReadProperty("ChiboKhoiphucdangtich", true);
                return _chiboKhoiphucdangtich;
            }
            set
            {
                CanWriteProperty("ChiboKhoiphucdangtich", true);
                if (value == null) value = string.Empty;
                if (!_chiboKhoiphucdangtich.Equals(value))
                {
                    _chiboKhoiphucdangtich = value;
                    PropertyHasChanged("ChiboKhoiphucdangtich");
                }
            }
        }
        public int MaLoaiDangVien
        {
            get
            {
                CanReadProperty("MaLoaiDangVien", true);
                return _maLoaiDangVien;
            }
            set
            {
                CanWriteProperty("MaLoaiDangVien", true);
                if (!_maLoaiDangVien.Equals(value))
                {
                    _maLoaiDangVien = value;
                    PropertyHasChanged("MaLoaiDangVien");
                }
            }
        }
        public int MaTruongDaoTao
        {
            get
            {
                CanReadProperty("MaTruongDaoTao", true);
                return _maTruongDaoTao;
            }
            set
            {
                CanWriteProperty("MaTruongDaoTao", true);
                if (!_maTruongDaoTao.Equals(value))
                {
                    _maTruongDaoTao = value;
                    PropertyHasChanged("MaTruongDaoTao");
                }
            }
        }
        protected override object GetIdValue()
        {
            return _maHoatDongXH;
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
			//AddCommonRules();
			//AddCustomRules();
		}
		#endregion //Validation Rules
  
		#region Authorization Rules
		protected override void AddAuthorizationRules()
		{
			//TODO: Define authorization rules in HoatDongXaHoi
			//AuthorizationRules.AllowRead("MaHoatDongXH", "HoatDongXaHoiReadGroup");
			//AuthorizationRules.AllowRead("MaNhanVien", "HoatDongXaHoiReadGroup");
			//AuthorizationRules.AllowRead("SoTheCongDoan", "HoatDongXaHoiReadGroup");
			//AuthorizationRules.AllowRead("NgayThamGia", "HoatDongXaHoiReadGroup");
			//AuthorizationRules.AllowRead("NgayThamGiaString", "HoatDongXaHoiReadGroup");
			//AuthorizationRules.AllowRead("NgayKetThucCD", "HoatDongXaHoiReadGroup");
			//AuthorizationRules.AllowRead("NgayKetThucCDString", "HoatDongXaHoiReadGroup");
			//AuthorizationRules.AllowRead("SoTheDoan", "HoatDongXaHoiReadGroup");
			//AuthorizationRules.AllowRead("NgayKetNapDoan", "HoatDongXaHoiReadGroup");
			//AuthorizationRules.AllowRead("NgayKetNapDoanString", "HoatDongXaHoiReadGroup");
			//AuthorizationRules.AllowRead("NgayKetThucDoan", "HoatDongXaHoiReadGroup");
			//AuthorizationRules.AllowRead("NgayKetThucDoanString", "HoatDongXaHoiReadGroup");
			//AuthorizationRules.AllowRead("MaQuanHam", "HoatDongXaHoiReadGroup");
			//AuthorizationRules.AllowRead("DonVi", "HoatDongXaHoiReadGroup");
			//AuthorizationRules.AllowRead("NgayNhapNgu", "HoatDongXaHoiReadGroup");
			//AuthorizationRules.AllowRead("NgayNhapNguString", "HoatDongXaHoiReadGroup");
			//AuthorizationRules.AllowRead("NgayXuatNgu", "HoatDongXaHoiReadGroup");
			//AuthorizationRules.AllowRead("NgayXuatNguString", "HoatDongXaHoiReadGroup");
			//AuthorizationRules.AllowRead("MaChucVuQuanDoi", "HoatDongXaHoiReadGroup");
			//AuthorizationRules.AllowRead("NgayThamGiaCM", "HoatDongXaHoiReadGroup");
			//AuthorizationRules.AllowRead("NgayThamGiaCMString", "HoatDongXaHoiReadGroup");
			//AuthorizationRules.AllowRead("ToChuc", "HoatDongXaHoiReadGroup");
			//AuthorizationRules.AllowRead("MaChucVuCachMang", "HoatDongXaHoiReadGroup");
			//AuthorizationRules.AllowRead("SoTheDang", "HoatDongXaHoiReadGroup");
			//AuthorizationRules.AllowRead("NgayVaoDang", "HoatDongXaHoiReadGroup");
			//AuthorizationRules.AllowRead("NgayVaoDangString", "HoatDongXaHoiReadGroup");
			//AuthorizationRules.AllowRead("NgayChinhThuc", "HoatDongXaHoiReadGroup");
			//AuthorizationRules.AllowRead("NgayChinhThucString", "HoatDongXaHoiReadGroup");
			//AuthorizationRules.AllowRead("NgayRaKhoiDang", "HoatDongXaHoiReadGroup");
			//AuthorizationRules.AllowRead("NgayRaKhoiDangString", "HoatDongXaHoiReadGroup");
			//AuthorizationRules.AllowRead("MaChucVuDang", "HoatDongXaHoiReadGroup");
			//AuthorizationRules.AllowRead("MaKiemNhiem", "HoatDongXaHoiReadGroup");
            //AuthorizationRules.AllowRead("MaChucVuDoan", "HoatDongXaHoiReadGroup");
            //AuthorizationRules.AllowRead("MaChucVuCongDoan", "HoatDongXaHoiReadGroup");

			//AuthorizationRules.AllowWrite("MaNhanVien", "HoatDongXaHoiWriteGroup");
			//AuthorizationRules.AllowWrite("SoTheCongDoan", "HoatDongXaHoiWriteGroup");
			//AuthorizationRules.AllowWrite("NgayThamGiaString", "HoatDongXaHoiWriteGroup");
			//AuthorizationRules.AllowWrite("NgayKetThucCDString", "HoatDongXaHoiWriteGroup");
			//AuthorizationRules.AllowWrite("SoTheDoan", "HoatDongXaHoiWriteGroup");
			//AuthorizationRules.AllowWrite("NgayKetNapDoanString", "HoatDongXaHoiWriteGroup");
			//AuthorizationRules.AllowWrite("NgayKetThucDoanString", "HoatDongXaHoiWriteGroup");
			//AuthorizationRules.AllowWrite("MaQuanHam", "HoatDongXaHoiWriteGroup");
			//AuthorizationRules.AllowWrite("DonVi", "HoatDongXaHoiWriteGroup");
			//AuthorizationRules.AllowWrite("NgayNhapNguString", "HoatDongXaHoiWriteGroup");
			//AuthorizationRules.AllowWrite("NgayXuatNguString", "HoatDongXaHoiWriteGroup");
			//AuthorizationRules.AllowWrite("MaChucVuQuanDoi", "HoatDongXaHoiWriteGroup");
			//AuthorizationRules.AllowWrite("NgayThamGiaCMString", "HoatDongXaHoiWriteGroup");
			//AuthorizationRules.AllowWrite("ToChuc", "HoatDongXaHoiWriteGroup");
			//AuthorizationRules.AllowWrite("MaChucVuCachMang", "HoatDongXaHoiWriteGroup");
			//AuthorizationRules.AllowWrite("SoTheDang", "HoatDongXaHoiWriteGroup");
			//AuthorizationRules.AllowWrite("NgayVaoDangString", "HoatDongXaHoiWriteGroup");
			//AuthorizationRules.AllowWrite("NgayChinhThucString", "HoatDongXaHoiWriteGroup");
			//AuthorizationRules.AllowWrite("NgayRaKhoiDangString", "HoatDongXaHoiWriteGroup");
			//AuthorizationRules.AllowWrite("MaChucVuDang", "HoatDongXaHoiWriteGroup");
			//AuthorizationRules.AllowWrite("MaKiemNhiem", "HoatDongXaHoiWriteGroup");
            //AuthorizationRules.AllowWrite("MaChucVuDoan", "HoatDongXaHoiWriteGroup");
            //AuthorizationRules.AllowWrite("MaChucVuCongDoan", "HoatDongXaHoiWriteGroup");
		}

		#endregion //Authorization Rules

		#region Factory Methods
		public static HoatDongXaHoi NewHoatDongXaHoi()
		{
			return new HoatDongXaHoi();
		}

		public static HoatDongXaHoi GetHoatDongXaHoi(SafeDataReader dr)
		{
            HoatDongXaHoi child = new HoatDongXaHoi();
            child._maHoatDongXH = dr.GetInt32("MaHoatDongXH");
            child._maNhanVien = dr.GetInt64("MaNhanVien");
            child._soTheCongDoan = dr.GetString("SoTheCongDoan");
            object ngayThamGia = dr.GetValue("NgayThamGia");
            if (ngayThamGia != null)
                child._ngayThamGia = (DateTime)ngayThamGia;
            else
                child._ngayThamGia = null;

            object ngayKetThucCD = dr.GetValue("NgayKetThucCD");
            if (ngayKetThucCD != null)
                child._ngayKetThucCD = (DateTime)ngayKetThucCD;
            else
                child._ngayKetThucCD = null;
            
            child._maChucVuCongDoan = dr.GetInt32("MaChucVuCongDoan");
            child._soTheDoan = dr.GetString("SoTheDoan");

            object ngayKetNapDoan = dr.GetValue("NgayKetNapDoan");
            if (ngayKetNapDoan != null)
                child._ngayKetNapDoan = (DateTime)ngayKetNapDoan;
            else
                child._ngayKetNapDoan = null;

            object ngayKetThucDoan = dr.GetValue("NgayKetThucDoan");
            if (ngayKetThucDoan != null)
                child._ngayKetThucDoan = (DateTime)ngayKetThucDoan;
            else
                child._ngayKetThucDoan = null;

          
            child._maChucVuDoan = dr.GetInt32("MaChucVuDoan");
            child._nhiemVu = dr.GetString("NhiemVu");
            child._maQuanHam = dr.GetInt32("MaQuanHam");
            child._donVi = dr.GetString("DonVi");

            object ngayNhapNgu = dr.GetValue("NgayNhapNgu");
            if (ngayNhapNgu != null)
                child._ngayNhapNgu = (DateTime)ngayNhapNgu;
            else
                child._ngayNhapNgu = null;

            object ngayXuatNgu = dr.GetValue("NgayXuatNgu");
            if (ngayXuatNgu != null)
                child._ngayXuatNgu = (DateTime)ngayXuatNgu;
            else
                child._ngayXuatNgu = null;
            
            child._maChucVuQuanDoi = dr.GetInt32("MaChucVuQuanDoi");

            object ngayThamGiaCM = dr.GetValue("NgayThamGiaCM");
            if (ngayThamGiaCM != null)
                child._ngayThamGiaCM = (DateTime)ngayThamGiaCM;
            else
                child._ngayThamGiaCM = null;

            child._toChuc = dr.GetString("ToChuc");
            child._maChucVuCachMang = dr.GetInt32("MaChucVuCachMang");
            child._soTheDang = dr.GetString("SoTheDang");

            object ngayVaoDang = dr.GetValue("NgayVaoDang");
            if (ngayVaoDang != null)
                child._ngayVaoDang = (DateTime)ngayVaoDang;
            else
                child._ngayVaoDang = null;

            object ngayChinhThuc = dr.GetValue("NgayChinhThuc");
            if (ngayChinhThuc != null)
                child._ngayChinhThuc = (DateTime)ngayChinhThuc;
            else
                child._ngayChinhThuc = null;

            object ngayRaKhoiDang = dr.GetValue("NgayRaKhoiDang");
            if (ngayRaKhoiDang != null)
                child._ngayRaKhoiDang = (DateTime)ngayRaKhoiDang;
            else
                child._ngayRaKhoiDang = null;
           
            child._maChucVuDang = dr.GetInt32("MaChucVuDang");
            child._maKiemNhiem = dr.GetInt32("MaKiemNhiem");
            child._noiSinhHoatDang = dr.GetString("NoiSinhHoatDang");
            child._diaChiNoiSH = dr.GetString("DiaChiNoiSH");
            child._chiboNgayvaodang = dr.GetString("ChiBo_NgayVaoDang");
            child._chiboNgayvaochinhthuc = dr.GetString("ChiBo_NgayVaoChinhThuc");
            child._chucvuNguoigioithieu2 = dr.GetString("ChucVu_NguoiGioiThieu2");
            child._chucvuNguoigioithieu1 = dr.GetString("ChucVu_NguoiGioiThieu1");
            child._nguoiGioiThieu1 = dr.GetString("NguoiGioiThieu1");
            child._nguoiGioiThieu2 = dr.GetString("NguoiGioiThieu2");
            child._ngheNghiepKhiVaoDang = dr.GetString("NgheNghiepKhiVaoDang");
            child._conViecChinhDangLam = dr.GetString("ConViecChinhDangLam");
            object ngayTDLamCongChuc = dr.GetValue("NgayTDLamCongChuc");
            if (ngayTDLamCongChuc != null)
                child._ngayTDLamCongChuc = (DateTime)ngayTDLamCongChuc;
            else
                child._ngayTDLamCongChuc = null;
            
            child._thamGiaCacHoatDongKhac = dr.GetString("ThamGiaCacHoatDongKhac");
            child._quaTrinhHoatDongVaCongTac = dr.GetString("QuaTrinhHoatDongVaCongTac");
            child._dacDiemLichSuBanThan = dr.GetString("DacDiemLichSuBanThan");
            child._quanHeGiaDinh = dr.GetString("QuanHeGiaDinh");
            child._hoanCanhKinhTeBanThan = dr.GetString("HoanCanhKinhTeBanThan");
            child._kyLuat = dr.GetString("KyLuat");
            child._danhHieuDuocPhong = dr.GetString("DanhHieuDuocPhong");
            child._soHuyHieuDang = dr.GetString("soHuyHieuDang");
            child._khenThuong = dr.GetString("KhenThuong");

            object ngayVaoDangLan2 = dr.GetValue("NgayVaoDangLan2");
            if (ngayVaoDangLan2 != null)
                child._ngayVaoDangLan2 = (DateTime)ngayVaoDangLan2;
            else
                child._ngayVaoDangLan2 = null;
                       
            child._chiboDdbt = dr.GetString("ChiBo_DDBT");
            child._nguoigioithieu1Ddbt = dr.GetString("NguoiGioiThieu1_DDBT");
            child._chucvuDdbtNguoigioithieu1 = dr.GetString("ChucVu_DDBT_NguoiGioiThieu1");
            child._nguoigioithieu2Ddbt = dr.GetString("NguoiGioiThieu2_DDBT");
            child._chucvuDdbtNguoigioithieu2 = dr.GetString("ChucVu_DDBT_NguoiGioiThieu2");

            object ngaychinhthuclan2Ddbt = dr.GetValue("NgayChinhThucLan2_DDBT");
            if (ngaychinhthuclan2Ddbt != null)
                child._ngaychinhthuclan2Ddbt = (DateTime)ngaychinhthuclan2Ddbt;
            else
                child._ngaychinhthuclan2Ddbt = null;
                       
            child._chiboNgaychinhthuc2Ddbt = dr.GetString("ChiBo_NgayChinhThuc2_DDBT");

            object ngayMienCongTacVaSHD = dr.GetValue("NgayMienCongTacVaSHD");
            if (ngayMienCongTacVaSHD != null)
                child._ngayMienCongTacVaSHD = (DateTime)ngayMienCongTacVaSHD;
            else
                child._ngayMienCongTacVaSHD = null;
         
            child._coQuanTuyenDungCongChuc = dr.GetString("CoQuanTuyenDungCongChuc");

            object ngayKhoiPhucDangTich = dr.GetValue("NgayKhoiPhucDangTich");
            if (ngayKhoiPhucDangTich != null)
                child._ngayKhoiPhucDangTich = (DateTime)ngayKhoiPhucDangTich;
            else
                child._ngayKhoiPhucDangTich = null;
           
            child._ChiBo_KhoiPhucDangTich = dr.GetString("ChiBo_KhoiPhucDangTich");
            child._maLoaiDangVien = dr.GetInt32("MaLoaiDangVien");
            child._maTruongDaoTao = dr.GetInt32("MaTruongDaoTao");
            child.MarkOld();
            return child;
		}

		private HoatDongXaHoi()
		{

			//ValidationRules.CheckRules();
			MarkAsChild();
		}

		private HoatDongXaHoi(SafeDataReader dr)
		{
			MarkAsChild();
			Fetch(dr);
		}
		#endregion //Factory Methods

		#region Data Access

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
            _maHoatDongXH = dr.GetInt32("MaHoatDongXH");
            _maNhanVien = dr.GetInt64("MaNhanVien");
            _soTheCongDoan = dr.GetString("SoTheCongDoan");
            object ngayThamGia = dr.GetValue("NgayThamGia");
            if (ngayThamGia != null)
                _ngayThamGia = (DateTime)ngayThamGia;
            else
                _ngayThamGia = null;

            object ngayKetThucCD = dr.GetValue("NgayKetThucCD");
            if (ngayKetThucCD != null)
                _ngayKetThucCD = (DateTime)ngayKetThucCD;
            else
                _ngayKetThucCD = null;

            _maChucVuCongDoan = dr.GetInt32("MaChucVuCongDoan");
            _soTheDoan = dr.GetString("SoTheDoan");

            object ngayKetNapDoan = dr.GetValue("NgayKetNapDoan");
            if (ngayKetNapDoan != null)
                _ngayKetNapDoan = (DateTime)ngayKetNapDoan;
            else
                _ngayKetNapDoan = null;

            object ngayKetThucDoan = dr.GetValue("NgayKetThucDoan");
            if (ngayKetThucDoan != null)
                _ngayKetThucDoan = (DateTime)ngayKetThucDoan;
            else
                _ngayKetThucDoan = null;


            _maChucVuDoan = dr.GetInt32("MaChucVuDoan");
            _nhiemVu = dr.GetString("NhiemVu");
            _maQuanHam = dr.GetInt32("MaQuanHam");
            _donVi = dr.GetString("DonVi");

            object ngayNhapNgu = dr.GetValue("NgayNhapNgu");
            if (ngayNhapNgu != null)
                _ngayNhapNgu = (DateTime)ngayNhapNgu;
            else
                _ngayNhapNgu = null;

            object ngayXuatNgu = dr.GetValue("NgayXuatNgu");
            if (ngayXuatNgu != null)
                _ngayXuatNgu = (DateTime)ngayXuatNgu;
            else
                _ngayXuatNgu = null;

            _maChucVuQuanDoi = dr.GetInt32("MaChucVuQuanDoi");

            object ngayThamGiaCM = dr.GetValue("NgayThamGiaCM");
            if (ngayThamGiaCM != null)
                _ngayThamGiaCM = (DateTime)ngayThamGiaCM;
            else
                _ngayThamGiaCM = null;

            _toChuc = dr.GetString("ToChuc");
            _maChucVuCachMang = dr.GetInt32("MaChucVuCachMang");
            _soTheDang = dr.GetString("SoTheDang");

            object ngayVaoDang = dr.GetValue("NgayVaoDang");
            if (ngayVaoDang != null)
                _ngayVaoDang = (DateTime)ngayVaoDang;
            else
                _ngayVaoDang = null;

            object ngayChinhThuc = dr.GetValue("NgayChinhThuc");
            if (ngayChinhThuc != null)
                _ngayChinhThuc = (DateTime)ngayChinhThuc;
            else
                _ngayChinhThuc = null;

            object ngayRaKhoiDang = dr.GetValue("NgayRaKhoiDang");
            if (ngayRaKhoiDang != null)
                _ngayRaKhoiDang = (DateTime)ngayRaKhoiDang;
            else
                _ngayRaKhoiDang = null;

            _maChucVuDang = dr.GetInt32("MaChucVuDang");
            _maKiemNhiem = dr.GetInt32("MaKiemNhiem");
            _noiSinhHoatDang = dr.GetString("NoiSinhHoatDang");
            _diaChiNoiSH = dr.GetString("DiaChiNoiSH");
            _chiboNgayvaodang = dr.GetString("ChiBo_NgayVaoDang");
            _chiboNgayvaochinhthuc = dr.GetString("ChiBo_NgayVaoChinhThuc");
            _chucvuNguoigioithieu2 = dr.GetString("ChucVu_NguoiGioiThieu2");
            _chucvuNguoigioithieu1 = dr.GetString("ChucVu_NguoiGioiThieu1");
            _nguoiGioiThieu1 = dr.GetString("NguoiGioiThieu1");
            _nguoiGioiThieu2 = dr.GetString("NguoiGioiThieu2");
            _ngheNghiepKhiVaoDang = dr.GetString("NgheNghiepKhiVaoDang");
            _conViecChinhDangLam = dr.GetString("ConViecChinhDangLam");
            object ngayTDLamCongChuc = dr.GetValue("NgayTDLamCongChuc");
            if (ngayTDLamCongChuc != null)
                _ngayTDLamCongChuc = (DateTime)ngayTDLamCongChuc;
            else
                _ngayTDLamCongChuc = null;

            _thamGiaCacHoatDongKhac = dr.GetString("ThamGiaCacHoatDongKhac");
            _quaTrinhHoatDongVaCongTac = dr.GetString("QuaTrinhHoatDongVaCongTac");
            _dacDiemLichSuBanThan = dr.GetString("DacDiemLichSuBanThan");
            _quanHeGiaDinh = dr.GetString("QuanHeGiaDinh");
            _hoanCanhKinhTeBanThan = dr.GetString("HoanCanhKinhTeBanThan");
            _kyLuat = dr.GetString("KyLuat");
            _danhHieuDuocPhong = dr.GetString("DanhHieuDuocPhong");
            _soHuyHieuDang = dr.GetString("soHuyHieuDang");
            _khenThuong = dr.GetString("KhenThuong");

            object ngayVaoDangLan2 = dr.GetValue("NgayVaoDangLan2");
            if (ngayVaoDangLan2 != null)
                _ngayVaoDangLan2 = (DateTime)ngayVaoDangLan2;
            else
                _ngayVaoDangLan2 = null;

            _chiboDdbt = dr.GetString("ChiBo_DDBT");
            _nguoigioithieu1Ddbt = dr.GetString("NguoiGioiThieu1_DDBT");
            _chucvuDdbtNguoigioithieu1 = dr.GetString("ChucVu_DDBT_NguoiGioiThieu1");
            _nguoigioithieu2Ddbt = dr.GetString("NguoiGioiThieu2_DDBT");
            _chucvuDdbtNguoigioithieu2 = dr.GetString("ChucVu_DDBT_NguoiGioiThieu2");

            object ngaychinhthuclan2Ddbt = dr.GetValue("NgayChinhThucLan2_DDBT");
            if (ngaychinhthuclan2Ddbt != null)
                _ngaychinhthuclan2Ddbt = (DateTime)ngaychinhthuclan2Ddbt;
            else
                _ngaychinhthuclan2Ddbt = null;

            _chiboNgaychinhthuc2Ddbt = dr.GetString("ChiBo_NgayChinhThuc2_DDBT");

            object ngayMienCongTacVaSHD = dr.GetValue("NgayMienCongTacVaSHD");
            if (ngayMienCongTacVaSHD != null)
                _ngayMienCongTacVaSHD = (DateTime)ngayMienCongTacVaSHD;
            else
                _ngayMienCongTacVaSHD = null;

            _coQuanTuyenDungCongChuc = dr.GetString("CoQuanTuyenDungCongChuc");

            object ngayKhoiPhucDangTich = dr.GetValue("NgayKhoiPhucDangTich");
            if (ngayKhoiPhucDangTich != null)
                _ngayKhoiPhucDangTich = (DateTime)ngayKhoiPhucDangTich;
            else
                _ngayKhoiPhucDangTich = null;

            _ChiBo_KhoiPhucDangTich = dr.GetString("ChiBo_KhoiPhucDangTich");
            _maLoaiDangVien = dr.GetInt32("MaLoaiDangVien");
            _maTruongDaoTao = dr.GetInt32("MaTruongDaoTao");
		}

		private void FetchChildren(SafeDataReader dr)
		{
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
                cm.CommandText = "spd_InserttblnsHoatDongXaHoi";

				AddInsertParameters(cm, parent);

				cm.ExecuteNonQuery();

				_maHoatDongXH = (int)cm.Parameters["@MaHoatDongXH"].Value;
			}//using
		}

		private void AddInsertParameters(SqlCommand cm, NhanVien parent)
		{
            //TODO: if parent use identity key, fix fk member with value from parent
            cm.Parameters.AddWithValue("@MaNhanVien", parent.MaNhanVien);
            
            if (_soTheCongDoan.Length > 0)
                cm.Parameters.AddWithValue("@SoTheCongDoan", _soTheCongDoan);
            else
                cm.Parameters.AddWithValue("@SoTheCongDoan", DBNull.Value);
            if(_ngayThamGia==null)
                cm.Parameters.AddWithValue("@NgayThamGia", DBNull.Value);
            else
                cm.Parameters.AddWithValue("@NgayThamGia", _ngayThamGia);
            if (_ngayKetThucCD == null)
                cm.Parameters.AddWithValue("@NgayKetThucCD", DBNull.Value);
            else
                cm.Parameters.AddWithValue("@NgayKetThucCD", _ngayKetThucCD);
          
            if (_maChucVuCongDoan != 0)
                cm.Parameters.AddWithValue("@MaChucVuCongDoan", _maChucVuCongDoan);
            else
                cm.Parameters.AddWithValue("@MaChucVuCongDoan", DBNull.Value);
            if (_soTheDoan.Length > 0)
                cm.Parameters.AddWithValue("@SoTheDoan", _soTheDoan);
            else
                cm.Parameters.AddWithValue("@SoTheDoan", DBNull.Value);
            if (_ngayKetNapDoan == null)
                cm.Parameters.AddWithValue("@NgayKetNapDoan", DBNull.Value);
            else
                cm.Parameters.AddWithValue("@NgayKetNapDoan", _ngayKetNapDoan);
            if (_ngayKetThucDoan == null)
                cm.Parameters.AddWithValue("@NgayKetThucDoan", DBNull.Value);
            else
                cm.Parameters.AddWithValue("@NgayKetThucDoan", _ngayKetThucDoan);
         
            if (_maChucVuDoan != 0)
                cm.Parameters.AddWithValue("@MaChucVuDoan", _maChucVuDoan);
            else
                cm.Parameters.AddWithValue("@MaChucVuDoan", DBNull.Value);
            if (_nhiemVu.Length > 0)
                cm.Parameters.AddWithValue("@NhiemVu", _nhiemVu);
            else
                cm.Parameters.AddWithValue("@NhiemVu", DBNull.Value);
            if (_maQuanHam != 0)
                cm.Parameters.AddWithValue("@MaQuanHam", _maQuanHam);
            else
                cm.Parameters.AddWithValue("@MaQuanHam", DBNull.Value);
            if (_donVi.Length > 0)
                cm.Parameters.AddWithValue("@DonVi", _donVi);
            else
                cm.Parameters.AddWithValue("@DonVi", DBNull.Value);
            if (_ngayNhapNgu == null)
                cm.Parameters.AddWithValue("@NgayNhapNgu", DBNull.Value);
            else
                cm.Parameters.AddWithValue("@NgayNhapNgu", _ngayNhapNgu);
            if (_ngayXuatNgu == null)
                cm.Parameters.AddWithValue("@NgayXuatNgu", DBNull.Value);
            else
                cm.Parameters.AddWithValue("@NgayXuatNgu", _ngayXuatNgu);
            
            if (_maChucVuQuanDoi != 0)
                cm.Parameters.AddWithValue("@MaChucVuQuanDoi", _maChucVuQuanDoi);
            else
                cm.Parameters.AddWithValue("@MaChucVuQuanDoi", DBNull.Value);
            if (_ngayThamGiaCM == null)
                cm.Parameters.AddWithValue("@NgayThamGiaCM", DBNull.Value);
            else
                cm.Parameters.AddWithValue("@NgayThamGiaCM", _ngayThamGiaCM);
         
            if (_toChuc.Length > 0)
                cm.Parameters.AddWithValue("@ToChuc", _toChuc);
            else
                cm.Parameters.AddWithValue("@ToChuc", DBNull.Value);
            if (_maChucVuCachMang != 0)
                cm.Parameters.AddWithValue("@MaChucVuCachMang", _maChucVuCachMang);
            else
                cm.Parameters.AddWithValue("@MaChucVuCachMang", DBNull.Value);
            if (_soTheDang.Length > 0)
                cm.Parameters.AddWithValue("@SoTheDang", _soTheDang);
            else
                cm.Parameters.AddWithValue("@SoTheDang", DBNull.Value);
            if (_ngayVaoDang == null)
                cm.Parameters.AddWithValue("@NgayVaoDang", DBNull.Value);
            else
                cm.Parameters.AddWithValue("@NgayVaoDang", _ngayVaoDang);
            if (_ngayChinhThuc == null)
                cm.Parameters.AddWithValue("@NgayChinhThuc", DBNull.Value);
            else
                cm.Parameters.AddWithValue("@NgayChinhThuc", _ngayChinhThuc);
            if (_ngayRaKhoiDang == null)
                cm.Parameters.AddWithValue("@NgayRaKhoiDang", DBNull.Value);
            else
                cm.Parameters.AddWithValue("@NgayRaKhoiDang", _ngayRaKhoiDang);
          
            if (_maChucVuDang != 0)
                cm.Parameters.AddWithValue("@MaChucVuDang", _maChucVuDang);
            else
                cm.Parameters.AddWithValue("@MaChucVuDang", DBNull.Value);
            if (_maKiemNhiem != 0)
                cm.Parameters.AddWithValue("@MaKiemNhiem", _maKiemNhiem);
            else
                cm.Parameters.AddWithValue("@MaKiemNhiem", DBNull.Value);
            if (_noiSinhHoatDang.Length > 0)
                cm.Parameters.AddWithValue("@NoiSinhHoatDang", _noiSinhHoatDang);
            else
                cm.Parameters.AddWithValue("@NoiSinhHoatDang", DBNull.Value);
            if (_diaChiNoiSH.Length > 0)
                cm.Parameters.AddWithValue("@DiaChiNoiSH", _diaChiNoiSH);
            else
                cm.Parameters.AddWithValue("@DiaChiNoiSH", DBNull.Value);
            if (_chiboNgayvaodang.Length > 0)
                cm.Parameters.AddWithValue("@ChiBo_NgayVaoDang", _chiboNgayvaodang);
            else
                cm.Parameters.AddWithValue("@ChiBo_NgayVaoDang", DBNull.Value);
            if (_chiboNgayvaochinhthuc.Length > 0)
                cm.Parameters.AddWithValue("@ChiBo_NgayVaoChinhThuc", _chiboNgayvaochinhthuc);
            else
                cm.Parameters.AddWithValue("@ChiBo_NgayVaoChinhThuc", DBNull.Value);
            if (_chucvuNguoigioithieu2.Length > 0)
                cm.Parameters.AddWithValue("@ChucVu_NguoiGioiThieu2", _chucvuNguoigioithieu2);
            else
                cm.Parameters.AddWithValue("@ChucVu_NguoiGioiThieu2", DBNull.Value);
            if (_chucvuNguoigioithieu1.Length > 0)
                cm.Parameters.AddWithValue("@ChucVu_NguoiGioiThieu1", _chucvuNguoigioithieu1);
            else
                cm.Parameters.AddWithValue("@ChucVu_NguoiGioiThieu1", DBNull.Value);
            if (_nguoiGioiThieu1.Length > 0)
                cm.Parameters.AddWithValue("@NguoiGioiThieu1", _nguoiGioiThieu1);
            else
                cm.Parameters.AddWithValue("@NguoiGioiThieu1", DBNull.Value);
            if (_nguoiGioiThieu2.Length > 0)
                cm.Parameters.AddWithValue("@NguoiGioiThieu2", _nguoiGioiThieu2);
            else
                cm.Parameters.AddWithValue("@NguoiGioiThieu2", DBNull.Value);
            if (_ngheNghiepKhiVaoDang.Length > 0)
                cm.Parameters.AddWithValue("@NgheNghiepKhiVaoDang", _ngheNghiepKhiVaoDang);
            else
                cm.Parameters.AddWithValue("@NgheNghiepKhiVaoDang", DBNull.Value);
            if (_conViecChinhDangLam.Length > 0)
                cm.Parameters.AddWithValue("@ConViecChinhDangLam", _conViecChinhDangLam);
            else
                cm.Parameters.AddWithValue("@ConViecChinhDangLam", DBNull.Value);
            if (_ngayTDLamCongChuc == null)
                cm.Parameters.AddWithValue("@NgayTDLamCongChuc", DBNull.Value);
            else
                cm.Parameters.AddWithValue("@NgayTDLamCongChuc", _ngayTDLamCongChuc);
           
            if (_thamGiaCacHoatDongKhac.Length > 0)
                cm.Parameters.AddWithValue("@ThamGiaCacHoatDongKhac", _thamGiaCacHoatDongKhac);
            else
                cm.Parameters.AddWithValue("@ThamGiaCacHoatDongKhac", DBNull.Value);
            if (_quaTrinhHoatDongVaCongTac.Length > 0)
                cm.Parameters.AddWithValue("@QuaTrinhHoatDongVaCongTac", _quaTrinhHoatDongVaCongTac);
            else
                cm.Parameters.AddWithValue("@QuaTrinhHoatDongVaCongTac", DBNull.Value);
            if (_dacDiemLichSuBanThan.Length > 0)
                cm.Parameters.AddWithValue("@DacDiemLichSuBanThan", _dacDiemLichSuBanThan);
            else
                cm.Parameters.AddWithValue("@DacDiemLichSuBanThan", DBNull.Value);
            if (_quanHeGiaDinh.Length > 0)
                cm.Parameters.AddWithValue("@QuanHeGiaDinh", _quanHeGiaDinh);
            else
                cm.Parameters.AddWithValue("@QuanHeGiaDinh", DBNull.Value);
            if (_hoanCanhKinhTeBanThan.Length > 0)
                cm.Parameters.AddWithValue("@HoanCanhKinhTeBanThan", _hoanCanhKinhTeBanThan);
            else
                cm.Parameters.AddWithValue("@HoanCanhKinhTeBanThan", DBNull.Value);
            if (_kyLuat.Length > 0)
                cm.Parameters.AddWithValue("@KyLuat", _kyLuat);
            else
                cm.Parameters.AddWithValue("@KyLuat", DBNull.Value);
            if (_danhHieuDuocPhong.Length > 0)
                cm.Parameters.AddWithValue("@DanhHieuDuocPhong", _danhHieuDuocPhong);
            else
                cm.Parameters.AddWithValue("@DanhHieuDuocPhong", DBNull.Value);
            if (_soHuyHieuDang.Length > 0)
                cm.Parameters.AddWithValue("@soHuyHieuDang", _soHuyHieuDang);
            else
                cm.Parameters.AddWithValue("@soHuyHieuDang", DBNull.Value);
            if (_khenThuong.Length > 0)
                cm.Parameters.AddWithValue("@KhenThuong", _khenThuong);
            else
                cm.Parameters.AddWithValue("@KhenThuong", DBNull.Value);
            if (_ngayVaoDangLan2 == null)
                cm.Parameters.AddWithValue("@NgayVaoDangLan2", DBNull.Value);
            else
                cm.Parameters.AddWithValue("@NgayVaoDangLan2", _ngayVaoDangLan2);
          
            if (_chiboDdbt.Length > 0)
                cm.Parameters.AddWithValue("@ChiBo_DDBT", _chiboDdbt);
            else
                cm.Parameters.AddWithValue("@ChiBo_DDBT", DBNull.Value);
            if (_nguoigioithieu1Ddbt.Length > 0)
                cm.Parameters.AddWithValue("@NguoiGioiThieu1_DDBT", _nguoigioithieu1Ddbt);
            else
                cm.Parameters.AddWithValue("@NguoiGioiThieu1_DDBT", DBNull.Value);
            if (_chucvuDdbtNguoigioithieu1.Length > 0)
                cm.Parameters.AddWithValue("@ChucVu_DDBT_NguoiGioiThieu1", _chucvuDdbtNguoigioithieu1);
            else
                cm.Parameters.AddWithValue("@ChucVu_DDBT_NguoiGioiThieu1", DBNull.Value);
            if (_nguoigioithieu2Ddbt.Length > 0)
                cm.Parameters.AddWithValue("@NguoiGioiThieu2_DDBT", _nguoigioithieu2Ddbt);
            else
                cm.Parameters.AddWithValue("@NguoiGioiThieu2_DDBT", DBNull.Value);
            if (_chucvuDdbtNguoigioithieu2.Length > 0)
                cm.Parameters.AddWithValue("@ChucVu_DDBT_NguoiGioiThieu2", _chucvuDdbtNguoigioithieu2);
            else
                cm.Parameters.AddWithValue("@ChucVu_DDBT_NguoiGioiThieu2", DBNull.Value);
            if (_ngaychinhthuclan2Ddbt == null)
                cm.Parameters.AddWithValue("@NgayChinhThucLan2_DDBT", DBNull.Value);
            else
                cm.Parameters.AddWithValue("@NgayChinhThucLan2_DDBT", _ngaychinhthuclan2Ddbt);
           
            if (_chiboNgaychinhthuc2Ddbt.Length > 0)
                cm.Parameters.AddWithValue("@ChiBo_NgayChinhThuc2_DDBT", _chiboNgaychinhthuc2Ddbt);
            else
                cm.Parameters.AddWithValue("@ChiBo_NgayChinhThuc2_DDBT", DBNull.Value);
            if (_ngayMienCongTacVaSHD == null)
                cm.Parameters.AddWithValue("@NgayMienCongTacVaSHD", DBNull.Value);
            else
                cm.Parameters.AddWithValue("@NgayMienCongTacVaSHD", _ngayMienCongTacVaSHD);
           
            if (_coQuanTuyenDungCongChuc.Length > 0)
                cm.Parameters.AddWithValue("@CoQuanTuyenDungCongChuc", _coQuanTuyenDungCongChuc);
            else
                cm.Parameters.AddWithValue("@CoQuanTuyenDungCongChuc", DBNull.Value);
            if (_ngayKhoiPhucDangTich == null)
                cm.Parameters.AddWithValue("@NgayKhoiPhucDangTich", DBNull.Value);
            else
                cm.Parameters.AddWithValue("@NgayKhoiPhucDangTich", _ngayKhoiPhucDangTich);
           
            if (_chiboKhoiphucdangtich.Length > 0)
                cm.Parameters.AddWithValue("@ChiBo_KhoiPhucDangTich", _chiboKhoiphucdangtich);
            else
                cm.Parameters.AddWithValue("@ChiBo_KhoiPhucDangTich", DBNull.Value);
            cm.Parameters.AddWithValue("@MaHoatDongXH", _maHoatDongXH);
            cm.Parameters.AddWithValue("@MaLoaiDangVien", _maLoaiDangVien);
            cm.Parameters.AddWithValue("@MaTruongDaoTao", _maTruongDaoTao);
            cm.Parameters["@MaHoatDongXH"].Direction = ParameterDirection.Output;
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
                cm.CommandText = "spd_UpdatetblnsHoatDongXaHoi";

				AddUpdateParameters(cm, parent);

				cm.ExecuteNonQuery();

			}//using
		}

		private void AddUpdateParameters(SqlCommand cm, NhanVien parent)
		{
            cm.Parameters.AddWithValue("@MaNhanVien", parent.MaNhanVien);

            if (_soTheCongDoan.Length > 0)
                cm.Parameters.AddWithValue("@SoTheCongDoan", _soTheCongDoan);
            else
                cm.Parameters.AddWithValue("@SoTheCongDoan", DBNull.Value);
            if (_ngayThamGia == null)
                cm.Parameters.AddWithValue("@NgayThamGia", DBNull.Value);
            else
                cm.Parameters.AddWithValue("@NgayThamGia", _ngayThamGia);
            if (_ngayKetThucCD == null)
                cm.Parameters.AddWithValue("@NgayKetThucCD", DBNull.Value);
            else
                cm.Parameters.AddWithValue("@NgayKetThucCD", _ngayKetThucCD);

            if (_maChucVuCongDoan != 0)
                cm.Parameters.AddWithValue("@MaChucVuCongDoan", _maChucVuCongDoan);
            else
                cm.Parameters.AddWithValue("@MaChucVuCongDoan", DBNull.Value);
            if (_soTheDoan.Length > 0)
                cm.Parameters.AddWithValue("@SoTheDoan", _soTheDoan);
            else
                cm.Parameters.AddWithValue("@SoTheDoan", DBNull.Value);
            if (_ngayKetNapDoan == null)
                cm.Parameters.AddWithValue("@NgayKetNapDoan", DBNull.Value);
            else
                cm.Parameters.AddWithValue("@NgayKetNapDoan", _ngayKetNapDoan);
            if (_ngayKetThucDoan == null)
                cm.Parameters.AddWithValue("@NgayKetThucDoan", DBNull.Value);
            else
                cm.Parameters.AddWithValue("@NgayKetThucDoan", _ngayKetThucDoan);

            if (_maChucVuDoan != 0)
                cm.Parameters.AddWithValue("@MaChucVuDoan", _maChucVuDoan);
            else
                cm.Parameters.AddWithValue("@MaChucVuDoan", DBNull.Value);
            if (_nhiemVu.Length > 0)
                cm.Parameters.AddWithValue("@NhiemVu", _nhiemVu);
            else
                cm.Parameters.AddWithValue("@NhiemVu", DBNull.Value);
            if (_maQuanHam != 0)
                cm.Parameters.AddWithValue("@MaQuanHam", _maQuanHam);
            else
                cm.Parameters.AddWithValue("@MaQuanHam", DBNull.Value);
            if (_donVi.Length > 0)
                cm.Parameters.AddWithValue("@DonVi", _donVi);
            else
                cm.Parameters.AddWithValue("@DonVi", DBNull.Value);
            if (_ngayNhapNgu == null)
                cm.Parameters.AddWithValue("@NgayNhapNgu", DBNull.Value);
            else
                cm.Parameters.AddWithValue("@NgayNhapNgu", _ngayNhapNgu);
            if (_ngayXuatNgu == null)
                cm.Parameters.AddWithValue("@NgayXuatNgu", DBNull.Value);
            else
                cm.Parameters.AddWithValue("@NgayXuatNgu", _ngayXuatNgu);

            if (_maChucVuQuanDoi != 0)
                cm.Parameters.AddWithValue("@MaChucVuQuanDoi", _maChucVuQuanDoi);
            else
                cm.Parameters.AddWithValue("@MaChucVuQuanDoi", DBNull.Value);
            if (_ngayThamGiaCM == null)
                cm.Parameters.AddWithValue("@NgayThamGiaCM", DBNull.Value);
            else
                cm.Parameters.AddWithValue("@NgayThamGiaCM", _ngayThamGiaCM);

            if (_toChuc.Length > 0)
                cm.Parameters.AddWithValue("@ToChuc", _toChuc);
            else
                cm.Parameters.AddWithValue("@ToChuc", DBNull.Value);
            if (_maChucVuCachMang != 0)
                cm.Parameters.AddWithValue("@MaChucVuCachMang", _maChucVuCachMang);
            else
                cm.Parameters.AddWithValue("@MaChucVuCachMang", DBNull.Value);
            if (_soTheDang.Length > 0)
                cm.Parameters.AddWithValue("@SoTheDang", _soTheDang);
            else
                cm.Parameters.AddWithValue("@SoTheDang", DBNull.Value);
            if (_ngayVaoDang == null)
                cm.Parameters.AddWithValue("@NgayVaoDang", DBNull.Value);
            else
                cm.Parameters.AddWithValue("@NgayVaoDang", _ngayVaoDang);
            if (_ngayChinhThuc == null)
                cm.Parameters.AddWithValue("@NgayChinhThuc", DBNull.Value);
            else
                cm.Parameters.AddWithValue("@NgayChinhThuc", _ngayChinhThuc);
            if (_ngayRaKhoiDang == null)
                cm.Parameters.AddWithValue("@NgayRaKhoiDang", DBNull.Value);
            else
                cm.Parameters.AddWithValue("@NgayRaKhoiDang", _ngayRaKhoiDang);

            if (_maChucVuDang != 0)
                cm.Parameters.AddWithValue("@MaChucVuDang", _maChucVuDang);
            else
                cm.Parameters.AddWithValue("@MaChucVuDang", DBNull.Value);
            if (_maKiemNhiem != 0)
                cm.Parameters.AddWithValue("@MaKiemNhiem", _maKiemNhiem);
            else
                cm.Parameters.AddWithValue("@MaKiemNhiem", DBNull.Value);
            if (_noiSinhHoatDang.Length > 0)
                cm.Parameters.AddWithValue("@NoiSinhHoatDang", _noiSinhHoatDang);
            else
                cm.Parameters.AddWithValue("@NoiSinhHoatDang", DBNull.Value);
            if (_diaChiNoiSH.Length > 0)
                cm.Parameters.AddWithValue("@DiaChiNoiSH", _diaChiNoiSH);
            else
                cm.Parameters.AddWithValue("@DiaChiNoiSH", DBNull.Value);
            if (_chiboNgayvaodang.Length > 0)
                cm.Parameters.AddWithValue("@ChiBo_NgayVaoDang", _chiboNgayvaodang);
            else
                cm.Parameters.AddWithValue("@ChiBo_NgayVaoDang", DBNull.Value);
            if (_chiboNgayvaochinhthuc.Length > 0)
                cm.Parameters.AddWithValue("@ChiBo_NgayVaoChinhThuc", _chiboNgayvaochinhthuc);
            else
                cm.Parameters.AddWithValue("@ChiBo_NgayVaoChinhThuc", DBNull.Value);
            if (_chucvuNguoigioithieu2.Length > 0)
                cm.Parameters.AddWithValue("@ChucVu_NguoiGioiThieu2", _chucvuNguoigioithieu2);
            else
                cm.Parameters.AddWithValue("@ChucVu_NguoiGioiThieu2", DBNull.Value);
            if (_chucvuNguoigioithieu1.Length > 0)
                cm.Parameters.AddWithValue("@ChucVu_NguoiGioiThieu1", _chucvuNguoigioithieu1);
            else
                cm.Parameters.AddWithValue("@ChucVu_NguoiGioiThieu1", DBNull.Value);
            if (_nguoiGioiThieu1.Length > 0)
                cm.Parameters.AddWithValue("@NguoiGioiThieu1", _nguoiGioiThieu1);
            else
                cm.Parameters.AddWithValue("@NguoiGioiThieu1", DBNull.Value);
            if (_nguoiGioiThieu2.Length > 0)
                cm.Parameters.AddWithValue("@NguoiGioiThieu2", _nguoiGioiThieu2);
            else
                cm.Parameters.AddWithValue("@NguoiGioiThieu2", DBNull.Value);
            if (_ngheNghiepKhiVaoDang.Length > 0)
                cm.Parameters.AddWithValue("@NgheNghiepKhiVaoDang", _ngheNghiepKhiVaoDang);
            else
                cm.Parameters.AddWithValue("@NgheNghiepKhiVaoDang", DBNull.Value);
            if (_conViecChinhDangLam.Length > 0)
                cm.Parameters.AddWithValue("@ConViecChinhDangLam", _conViecChinhDangLam);
            else
                cm.Parameters.AddWithValue("@ConViecChinhDangLam", DBNull.Value);
            if (_ngayTDLamCongChuc == null)
                cm.Parameters.AddWithValue("@NgayTDLamCongChuc", DBNull.Value);
            else
                cm.Parameters.AddWithValue("@NgayTDLamCongChuc", _ngayTDLamCongChuc);

            if (_thamGiaCacHoatDongKhac.Length > 0)
                cm.Parameters.AddWithValue("@ThamGiaCacHoatDongKhac", _thamGiaCacHoatDongKhac);
            else
                cm.Parameters.AddWithValue("@ThamGiaCacHoatDongKhac", DBNull.Value);
            if (_quaTrinhHoatDongVaCongTac.Length > 0)
                cm.Parameters.AddWithValue("@QuaTrinhHoatDongVaCongTac", _quaTrinhHoatDongVaCongTac);
            else
                cm.Parameters.AddWithValue("@QuaTrinhHoatDongVaCongTac", DBNull.Value);
            if (_dacDiemLichSuBanThan.Length > 0)
                cm.Parameters.AddWithValue("@DacDiemLichSuBanThan", _dacDiemLichSuBanThan);
            else
                cm.Parameters.AddWithValue("@DacDiemLichSuBanThan", DBNull.Value);
            if (_quanHeGiaDinh.Length > 0)
                cm.Parameters.AddWithValue("@QuanHeGiaDinh", _quanHeGiaDinh);
            else
                cm.Parameters.AddWithValue("@QuanHeGiaDinh", DBNull.Value);
            if (_hoanCanhKinhTeBanThan.Length > 0)
                cm.Parameters.AddWithValue("@HoanCanhKinhTeBanThan", _hoanCanhKinhTeBanThan);
            else
                cm.Parameters.AddWithValue("@HoanCanhKinhTeBanThan", DBNull.Value);
            if (_kyLuat.Length > 0)
                cm.Parameters.AddWithValue("@KyLuat", _kyLuat);
            else
                cm.Parameters.AddWithValue("@KyLuat", DBNull.Value);
            if (_danhHieuDuocPhong.Length > 0)
                cm.Parameters.AddWithValue("@DanhHieuDuocPhong", _danhHieuDuocPhong);
            else
                cm.Parameters.AddWithValue("@DanhHieuDuocPhong", DBNull.Value);
            if (_soHuyHieuDang.Length > 0)
                cm.Parameters.AddWithValue("@soHuyHieuDang", _soHuyHieuDang);
            else
                cm.Parameters.AddWithValue("@soHuyHieuDang", DBNull.Value);
            if (_khenThuong.Length > 0)
                cm.Parameters.AddWithValue("@KhenThuong", _khenThuong);
            else
                cm.Parameters.AddWithValue("@KhenThuong", DBNull.Value);
            if (_ngayVaoDangLan2 == null)
                cm.Parameters.AddWithValue("@NgayVaoDangLan2", DBNull.Value);
            else
                cm.Parameters.AddWithValue("@NgayVaoDangLan2", _ngayVaoDangLan2);

            if (_chiboDdbt.Length > 0)
                cm.Parameters.AddWithValue("@ChiBo_DDBT", _chiboDdbt);
            else
                cm.Parameters.AddWithValue("@ChiBo_DDBT", DBNull.Value);
            if (_nguoigioithieu1Ddbt.Length > 0)
                cm.Parameters.AddWithValue("@NguoiGioiThieu1_DDBT", _nguoigioithieu1Ddbt);
            else
                cm.Parameters.AddWithValue("@NguoiGioiThieu1_DDBT", DBNull.Value);
            if (_chucvuDdbtNguoigioithieu1.Length > 0)
                cm.Parameters.AddWithValue("@ChucVu_DDBT_NguoiGioiThieu1", _chucvuDdbtNguoigioithieu1);
            else
                cm.Parameters.AddWithValue("@ChucVu_DDBT_NguoiGioiThieu1", DBNull.Value);
            if (_nguoigioithieu2Ddbt.Length > 0)
                cm.Parameters.AddWithValue("@NguoiGioiThieu2_DDBT", _nguoigioithieu2Ddbt);
            else
                cm.Parameters.AddWithValue("@NguoiGioiThieu2_DDBT", DBNull.Value);
            if (_chucvuDdbtNguoigioithieu2.Length > 0)
                cm.Parameters.AddWithValue("@ChucVu_DDBT_NguoiGioiThieu2", _chucvuDdbtNguoigioithieu2);
            else
                cm.Parameters.AddWithValue("@ChucVu_DDBT_NguoiGioiThieu2", DBNull.Value);
            if (_ngaychinhthuclan2Ddbt == null)
                cm.Parameters.AddWithValue("@NgayChinhThucLan2_DDBT", DBNull.Value);
            else
                cm.Parameters.AddWithValue("@NgayChinhThucLan2_DDBT", _ngaychinhthuclan2Ddbt);

            if (_chiboNgaychinhthuc2Ddbt.Length > 0)
                cm.Parameters.AddWithValue("@ChiBo_NgayChinhThuc2_DDBT", _chiboNgaychinhthuc2Ddbt);
            else
                cm.Parameters.AddWithValue("@ChiBo_NgayChinhThuc2_DDBT", DBNull.Value);
            if (_ngayMienCongTacVaSHD == null)
                cm.Parameters.AddWithValue("@NgayMienCongTacVaSHD", DBNull.Value);
            else
                cm.Parameters.AddWithValue("@NgayMienCongTacVaSHD", _ngayMienCongTacVaSHD);

            if (_coQuanTuyenDungCongChuc.Length > 0)
                cm.Parameters.AddWithValue("@CoQuanTuyenDungCongChuc", _coQuanTuyenDungCongChuc);
            else
                cm.Parameters.AddWithValue("@CoQuanTuyenDungCongChuc", DBNull.Value);
            if (_ngayKhoiPhucDangTich == null)
                cm.Parameters.AddWithValue("@NgayKhoiPhucDangTich", DBNull.Value);
            else
                cm.Parameters.AddWithValue("@NgayKhoiPhucDangTich", _ngayKhoiPhucDangTich);

            if (_chiboKhoiphucdangtich.Length > 0)
                cm.Parameters.AddWithValue("@ChiBo_KhoiPhucDangTich", _chiboKhoiphucdangtich);
            else
                cm.Parameters.AddWithValue("@ChiBo_KhoiPhucDangTich", DBNull.Value);
            cm.Parameters.AddWithValue("@MaHoatDongXH", _maHoatDongXH);
            cm.Parameters.AddWithValue("@MaLoaiDangVien", _maLoaiDangVien);
            cm.Parameters.AddWithValue("@MaTruongDaoTao", _maTruongDaoTao);
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

			ExecuteDelete(tr);
			MarkNew();
		}

		private void ExecuteDelete(SqlTransaction tr)
		{
			using (SqlCommand cm = tr.Connection.CreateCommand())
			{
				cm.Transaction = tr;
				cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_DeletetblnsHoatDongXaHoi";

				cm.Parameters.AddWithValue("@MaHoatDongXH", this._maHoatDongXH);

				cm.ExecuteNonQuery();
			}//using
		}
		#endregion //Data Access - Delete
		#endregion //Data Access
	}
}
