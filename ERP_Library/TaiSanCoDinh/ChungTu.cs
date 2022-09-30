
using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using Csla;
using Csla.Data;
using ERP_Library.ThanhToan;



namespace ERP_Library
{
    //11-1-2010
    public class ChungTu : BusinessBase<ChungTu>
    {
        private bool _idSet;
        private int _iLoaiChungTu = 0;
        private ChungTu_DeNghiChuyenKhoanChildList _chungTu_DeNghiChuyenKhoan = new ChungTu_DeNghiChuyenKhoanChildList();
        private ChungTu_GiayBaoCoList _chungTu_GiayBaoCoList = ChungTu_GiayBaoCoList.NewChungTu_GiayBaoCoList();
        private ChungTu_GiayBanNgoaiTeChildList _chungTu_GiayBanNgoaiTeChildList = ChungTu_GiayBanNgoaiTeChildList.NewChungTu_GiayBanNgoaiTeChildList();
        private ChungTu_LenhChuyenTienNNChildList _chungTu_LenhChuyenTienNNChildList = ChungTu_LenhChuyenTienNNChildList.NewChungTu_LenhChuyenTienNNChildList();
        private ChungTu_GiayRutTienChildList _chungTu_GiayRutTienChildList = ChungTu_GiayRutTienChildList.NewChungTu_GiayRutTienChildList();
        private ChungTu_UNCChildList _chungTu_UyNhiemChiChildList = ChungTu_UNCChildList.NewChungTu_UNCChildList();

        //Phần tính lương mới (21/12/2012)
        //private ThuLaoChuongTrinhList _thuLaoChuongTrinhList = ThuLaoChuongTrinhList.NewThuLaoChuongTrinhList();
        //private PhuCapNhanVienList _phuCapNhanVienList = PhuCapNhanVienList.NewPhuCapNhanVienList();
        //private BangLuongKyIList _bangluongKy1List = BangLuongKyIList.NewBangLuongKyIList();
        //private BangLuongKyIIList _bangluongKy2List = BangLuongKyIIList.NewBangLuongKyIIList();

        protected override object GetIdValue()
        {
            return _MaChungTu;
        }

        #region Khai báo biến

        long _MaChungTu = 0;
        public long MaChungTu
        {
            get
            {
                CanReadProperty(true);
                return _MaChungTu;
            }
            set
            {
                CanWriteProperty(true);
                if (!_MaChungTu.Equals(value))
                {
                    _idSet = true;
                    _MaChungTu = value;
                    PropertyHasChanged();
                }
            }
        }

        ChungTuNganHangList _ChungTuNganHangList = ChungTuNganHangList.NewChungTuNganHangList();

        public ChungTuNganHangList ChungTuNganHangList
        {
            get { CanReadProperty(true); return _ChungTuNganHangList; }
            set { CanWriteProperty(true); _ChungTuNganHangList = value; }
        }

        int _SoTT = 0;
        public int SoTT
        {
            get
            {
                CanReadProperty(true);
                return _SoTT;
            }
            set
            {
                CanWriteProperty(true);
                if (!_SoTT.Equals(value))
                {
                    _SoTT = value;
                    PropertyHasChanged();
                }
            }
        }
        Boolean _hoanTat = false;
        public bool HoanTat
        {
            get
            {
                CanReadProperty(true);
                return _hoanTat;
            }
            set
            {
                CanWriteProperty(true);
                if (!_hoanTat.Equals(value))
                {
                    _hoanTat = value;
                    PropertyHasChanged();
                }
            }
        }
        decimal _tienThue = 0;
        public decimal TienThue
        {
            get
            {
                CanReadProperty(true);
                return _tienThue;
            }
            set
            {
                CanWriteProperty(true);
                if (!_tienThue.Equals(value))
                {
                    _tienThue = value;
                    PropertyHasChanged();
                }
            }
        }
        //nhớ bổ sung hàm lấy tát cả chứng từ gốc

        public HoaDonList _ChungTuGoc = HoaDonList.NewHoaDonList();
        public HoaDonList ChungTuGoc
        {
            get
            {
                CanReadProperty(true);
                //if (_MaChungTu != 0)
                //{
                //    _ChungTuGoc = HoaDonList.GetHoaDonList(_HopDong.MaDoiTac,6);
                //}
                return _ChungTuGoc;
            }
            set
            {
                CanWriteProperty(true);
                if (!_ChungTuGoc.Equals(value))
                {
                    _ChungTuGoc = value;
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

        //public ThuLaoChuongTrinhList ThuLaoCTList
        //{
        //    get
        //    {
        //        CanReadProperty(true);
        //        return _thuLaoChuongTrinhList;
        //    }
        //    set
        //    {
        //        CanWriteProperty(true);
        //        if (!_thuLaoChuongTrinhList.Equals(value))
        //        {
        //            _thuLaoChuongTrinhList = value;
        //            PropertyHasChanged();
        //        }
        //    }
        //}

        //public PhuCapNhanVienList PhuCapNVList
        //{
        //    get
        //    {
        //        CanReadProperty(true);
        //        return _phuCapNhanVienList;
        //    }
        //    set
        //    {
        //        CanWriteProperty(true);
        //        if (!_phuCapNhanVienList.Equals(value))
        //        {
        //            _phuCapNhanVienList = value;
        //            PropertyHasChanged();
        //        }
        //    }
        //}

        //public BangLuongKyIList BangLuongKy1List
        //{
        //    get
        //    {
        //        CanReadProperty(true);
        //        return _bangluongKy1List;
        //    }
        //    set
        //    {
        //        CanWriteProperty(true);
        //        if (!_bangluongKy1List.Equals(value))
        //        {
        //            _bangluongKy1List = value;
        //            PropertyHasChanged();
        //        }
        //    }
        //}

        //public BangLuongKyIIList BangLuongKy2List
        //{
        //    get
        //    {
        //        CanReadProperty(true);
        //        return _bangluongKy2List;
        //    }
        //    set
        //    {
        //        CanWriteProperty(true);
        //        if (!_bangluongKy2List.Equals(value))
        //        {
        //            _bangluongKy2List = value;
        //            PropertyHasChanged();
        //        }
        //    }
        //}

        public ChungTu_DeNghiChuyenKhoanChildList ChungTuDeNghiList
        {
            get
            {
                CanReadProperty(true);
                return _chungTu_DeNghiChuyenKhoan;
            }
            set
            {
                CanWriteProperty(true);
                if (!_chungTu_DeNghiChuyenKhoan.Equals(value))
                {
                    _chungTu_DeNghiChuyenKhoan = value;
                    PropertyHasChanged();
                }
            }
        }

        public ChungTu_GiayBaoCoList ChungTuGiayBaoCoList
        {
            get
            {
                CanReadProperty(true);
                return _chungTu_GiayBaoCoList;
            }
            set
            {
                CanWriteProperty(true);
                if (!_chungTu_GiayBaoCoList.Equals(value))
                {
                    _chungTu_GiayBaoCoList = value;
                    PropertyHasChanged();
                }
            }
        }

        public ChungTu_UNCChildList ChungTuUyNhiemChiList
        {
            get
            {
                CanReadProperty(true);
                return _chungTu_UyNhiemChiChildList;
            }
            set
            {
                CanWriteProperty(true);
                if (!_chungTu_UyNhiemChiChildList.Equals(value))
                {
                    _chungTu_UyNhiemChiChildList = value;
                    PropertyHasChanged();
                }
            }
        }

        public ChungTu_GiayBanNgoaiTeChildList ChungTuGiayBanNgoaiTe
        {
            get
            {
                CanReadProperty(true);
                return _chungTu_GiayBanNgoaiTeChildList;
            }
            set
            {
                CanWriteProperty(true);
                if (!_chungTu_GiayBanNgoaiTeChildList.Equals(value))
                {
                    _chungTu_GiayBanNgoaiTeChildList = value;
                    PropertyHasChanged();
                }
            }
        }

        public ChungTu_LenhChuyenTienNNChildList ChungTuLenhChuyenTienList
        {
            get
            {
                CanReadProperty(true);
                return _chungTu_LenhChuyenTienNNChildList;
            }
            set
            {
                CanWriteProperty(true);
                if (!_chungTu_LenhChuyenTienNNChildList.Equals(value))
                {
                    _chungTu_LenhChuyenTienNNChildList = value;
                    PropertyHasChanged();
                }
            }
        }

        public ChungTu_GiayRutTienChildList ChungTuGiayRutTienList
        {
            get
            {
                CanReadProperty(true);
                return _chungTu_GiayRutTienChildList;
            }
            set
            {
                CanWriteProperty(true);
                if (!_chungTu_GiayRutTienChildList.Equals(value))
                {
                    _chungTu_GiayRutTienChildList = value;
                    PropertyHasChanged();
                }
            }
        }

        private ChungTu_TheoDoi _chungTuTheoDoi = ChungTu_TheoDoi.NewChungTu_TheoDoi();


        public TamUngList _TamUngList = TamUngList.NewTamUngList();

        public TamUngList TamUngList
        {
            get
            {
                CanReadProperty(true);
                return _TamUngList;
            }
            set
            {
                CanWriteProperty(true);
                if (!_TamUngList.Equals(value))
                {
                    _TamUngList = value;
                    PropertyHasChanged();
                }
            }
        }

        private CT_ChungTuBienLaiChildList _CT_ChungTuBienLaiList = CT_ChungTuBienLaiChildList.NewCT_ChungTuBienLaiChildList();
        public CT_ChungTuBienLaiChildList CT_ChungTuBienLaiList
        {
            get
            {
                CanReadProperty(true);
                return _CT_ChungTuBienLaiList;
            }
            set
            {
                CanWriteProperty(true);
                if (!_CT_ChungTuBienLaiList.Equals(value))
                {
                    _CT_ChungTuBienLaiList = value;
                    PropertyHasChanged();
                }
            }
        }

        private ChungTu_HoaDonThanhToanChildList _chungTu_HoaDonThanhToanList = ChungTu_HoaDonThanhToanChildList.NewChungTu_HoaDonThanhToanChildList();
        public ChungTu_HoaDonThanhToanChildList ChungTu_HoaDonThanhToanList
        {
            get
            {
                CanReadProperty(true);
                return _chungTu_HoaDonThanhToanList;
            }
            set
            {
                CanWriteProperty(true);
                if (!_chungTu_HoaDonThanhToanList.Equals(value))
                {
                    _chungTu_HoaDonThanhToanList = value;
                    PropertyHasChanged();
                }
            }
        }

        private ChungTu_ChungTuChildList _ChungTu_ChungTuList = ChungTu_ChungTuChildList.NewChungTu_ChungTuChildList();
        public ChungTu_ChungTuChildList ChungTu_ChungList
        {
            get
            {
                CanReadProperty(true);
                return _ChungTu_ChungTuList;
            }
            set
            {
                CanWriteProperty(true);
                if (!_ChungTu_ChungTuList.Equals(value))
                {
                    _ChungTu_ChungTuList = value;
                    PropertyHasChanged();
                }
            }
        }


        String _SoChungTu = String.Empty;
        public String SoChungTu
        {
            get
            {
                CanReadProperty(true);
                return _SoChungTu;
            }
            set
            {
                CanWriteProperty(true);
                if (!_SoChungTu.Equals(value))
                {
                    _SoChungTu = value;
                    PropertyHasChanged();
                }
            }
        }

        SmartDate _NgayLap = new SmartDate(DateTime.Today);
        public DateTime NgayLap
        {
            get
            {
                CanReadProperty(true);
                return _NgayLap.Date;
            }
            set
            {
                CanWriteProperty(true);
                if (!_NgayLap.Equals(value))
                {
                    _NgayLap = new SmartDate(value);
                    PropertyHasChanged();
                }
            }
        }

        public string NgayLapString
        {
            get
            {
                CanReadProperty("NgayLapString", true);
                return _NgayLap.Text;
            }
            set
            {
                CanWriteProperty("NgayLapString", true);
                if (value == null) value = string.Empty;
                if (!_NgayLap.Equals(value))
                {
                    _NgayLap.Text = value;
                    PropertyHasChanged("NgayLapString");
                }
            }
        }

        //cho trường hợp bút toán cho muc ngân sách
        Boolean _GhiMucNganSach = false;
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

        SmartDate _NgayThucHien = new SmartDate(DateTime.Today);
        public DateTime NgayThucHien
        {
            get
            {
                CanReadProperty(true);
                return _NgayThucHien.Date;
            }
            set
            {
                CanWriteProperty(true);
                if (!_NgayThucHien.Equals(value))
                {
                    _NgayThucHien = new SmartDate(value);
                    PropertyHasChanged();
                }
            }
        }

        Boolean _GhiSoCai = false;
        public Boolean GhiSoCai
        {
            get
            {
                CanReadProperty(true);
                return _GhiSoCai;
            }
            set
            {
                CanWriteProperty(true);
                if (!_GhiSoCai.Equals(value))
                {
                    _GhiSoCai = value;
                    PropertyHasChanged();
                }
            }
        }

        int _Ky = 0;
        public int Ky
        {
            get
            {
                CanReadProperty(true);
                return _Ky;
            }
            set
            {
                CanWriteProperty(true);
                if (!_Ky.Equals(value))
                {
                    _Ky = _NgayLap.Date.Month;
                    PropertyHasChanged();
                }
            }
        }


        Int32 _NguoiLap = Security.CurrentUser.Info.UserID;  //
        public Int32 NguoiLap
        {
            get
            {
                CanReadProperty(true);
                return _NguoiLap;
            }
            set
            {
                CanWriteProperty(true);
                if (!_NguoiLap.Equals(value))
                {
                    _NguoiLap = value;
                    PropertyHasChanged();
                }
            }
        }

        long _MaNhanVienLap;
        public long MaNhanVienLap
        {
            get
            {
                CanReadProperty(true);
                return _MaNhanVienLap;
            }
            set
            {
                CanWriteProperty(true);
                if (!_MaNhanVienLap.Equals(value))
                {
                    _MaNhanVienLap = value;
                    PropertyHasChanged();
                }
            }
        }

        long _DoiTuong = 0;
        public long DoiTuong
        {
            get
            {
                CanReadProperty(true);
                return _DoiTuong;
            }
            set
            {
                CanWriteProperty(true);
                if (!_DoiTuong.Equals(value))
                {
                    _DoiTuong = value;
                    PropertyHasChanged();
                }
            }
        }

        int _MaDoiTuongThuChi = 0;
        public int MaDoiTuongThuChi
        {
            get
            {
                CanReadProperty(true);
                return _MaDoiTuongThuChi;
            }
            set
            {
                CanWriteProperty(true);
                if (!_MaDoiTuongThuChi.Equals(value))
                {
                    _MaDoiTuongThuChi = value;
                    PropertyHasChanged();
                }
            }
        }

        int _MaPhuongThucThanhToan = 0;
        public int MaPhuongThucThanhToan
        {
            get
            {
                CanReadProperty(true);
                return _MaPhuongThucThanhToan;
            }
            set
            {
                CanWriteProperty(true);
                if (!_MaPhuongThucThanhToan.Equals(value))
                {
                    _MaPhuongThucThanhToan = value;
                    PropertyHasChanged();
                }
            }
        }

        DinhKhoan _DinhKhoan = DinhKhoan.NewDinhKhoan();
        public DinhKhoan DinhKhoan
        {
            get
            {
                CanReadProperty(true);
                return _DinhKhoan;
            }
            set
            {
                CanWriteProperty(true);
                if (!_DinhKhoan.Equals(value))
                {
                    _DinhKhoan = value;
                    PropertyHasChanged();
                }
            }
        }

        LoaiChungTuDev _LoaiChungTu = LoaiChungTuDev.NewLoaiChungTuDev();
        public LoaiChungTuDev LoaiChungTu
        {
            get
            {
                CanReadProperty(true);
                return _LoaiChungTu;
            }
            set
            {
                CanWriteProperty(true);
                if (!_LoaiChungTu.Equals(value))
                {
                    _LoaiChungTu = value;
                    PropertyHasChanged();
                }
            }
        }

        MucNganSach _MucNganSach = MucNganSach.NewMucNganSach();
        public MucNganSach MucNganSach
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

        TienTe _Tien = TienTe.NewTienTe(0);
        public TienTe Tien
        {
            get
            {
                CanReadProperty(true);
                return _Tien;
            }
            set
            {
                CanWriteProperty(true);
                if (!_Tien.Equals(value))
                {
                    _Tien = value;

                    PropertyHasChanged();
                }
            }
        }

        BoSungChungTu _BoSungChungTu = BoSungChungTu.NewBoSungChungTu(0);
        public BoSungChungTu BoSungChungTuKT
        {
            get
            {
                CanReadProperty(true);
                return _BoSungChungTu;
            }
            set
            {
                CanWriteProperty(true);
                if (!_BoSungChungTu.Equals(value))
                {
                    _BoSungChungTu = value;

                    PropertyHasChanged();
                }
            }
        }

        ChungTu_TaiKhoan _ChungTu_TaiKhoan = ChungTu_TaiKhoan.NewChungTu_TaiKhoan(0);
        public ChungTu_TaiKhoan ChungTu_TaiKhoan
        {
            get
            {
                CanReadProperty(true);
                return _ChungTu_TaiKhoan;
            }
            set
            {
                CanWriteProperty(true);
                if (!_ChungTu_TaiKhoan.Equals(value))
                {
                    _ChungTu_TaiKhoan = value;

                    PropertyHasChanged();
                }
            }
        }

        ChungTu_DiaChi _ChungTu_DiaChi = ChungTu_DiaChi.NewChungTu_DiaChi(0);
        public ChungTu_DiaChi ChungTu_DiaChi
        {
            get
            {
                CanReadProperty(true);
                return _ChungTu_DiaChi;
            }
            set
            {
                CanWriteProperty(true);
                if (!_ChungTu_DiaChi.Equals(value))
                {
                    _ChungTu_DiaChi = value;

                    PropertyHasChanged();
                }
            }
        }

        public decimal SoTien
        {
            get
            {
                CanReadProperty(true);
                return _Tien.SoTien;
            }
            set
            {
                CanWriteProperty("SoTien", true);
                if (!_Tien.SoTien.Equals(value))
                {
                    _Tien.SoTien = value;
                    PropertyHasChanged("SoTien");
                }
            }


        }
        decimal _tyGia = 0;

        public decimal TyGia
        {
            get
            {
                CanReadProperty(true);
                return _tyGia;
            }
            set
            {
                CanWriteProperty("TyGia", true);
                if (!_tyGia.Equals(value))
                {
                    _tyGia = value;
                    PropertyHasChanged("TyGia");
                }
            }


        }
        decimal _thanhTien = 0;
        public decimal ThanhTien
        {
            get
            {
                CanReadProperty(true);
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

        Int32 _KhoaSo = 0;
        public Int32 KhoaSo
        {
            get
            {
                CanReadProperty(true);
                return _KhoaSo;
            }
            set
            {
                CanWriteProperty(true);
                if (!_KhoaSo.Equals(value))
                {
                    _KhoaSo = value;
                    PropertyHasChanged();
                }
            }
        }

        String _MaChungTuQL = String.Empty;
        public String MaChungTuQL
        {
            get
            {
                CanReadProperty(true);
                return _MaChungTuQL;
            }
            set
            {
                CanWriteProperty(true);
                if (!_MaChungTuQL.Equals(value))
                {
                    _MaChungTuQL = value;
                    PropertyHasChanged();
                }
            }
        }

        String _DienGiai = "";
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
        bool _chon = false;

        public bool Chon
        {
            get { return _chon; }
            set { _chon = value; }
        }

        int _SoChungTuKemTheo = 0;
        public int SoChungTuKemTheo
        {
            get
            {
                CanReadProperty(true);
                return _SoChungTuKemTheo;
            }
            set
            {
                CanWriteProperty(true);
                if (!_SoChungTuKemTheo.Equals(value))
                {
                    _SoChungTuKemTheo = value;
                    PropertyHasChanged();
                }
            }
        }

        string _ChungTuKemTheo = string.Empty;
        public string ChungTuKemTheo
        {
            get
            {
                CanReadProperty(true);
                return _ChungTuKemTheo;
            }
            set
            {
                CanWriteProperty(true);
                if (!_ChungTuKemTheo.Equals(value))
                {
                    _ChungTuKemTheo = value;
                    PropertyHasChanged();
                }
            }
        }

        int _MaHoatDong = 0;
        public int MaHoatDong
        {
            get
            {
                CanReadProperty(true);
                return _MaHoatDong;
            }
            set
            {
                CanWriteProperty(true);
                if (!_MaHoatDong.Equals(value))
                {
                    _MaHoatDong = value;
                    PropertyHasChanged();
                }
            }
        }


        private int _maBoPhanDangNhap = ERP_Library.Security.CurrentUser.Info.MaBoPhan;//Value luu xuống là MaBoPhan

        public int MaBoPhanDangNhap
        {
            get { return _maBoPhanDangNhap; }
            set { _maBoPhanDangNhap = value; }
        }
        private string _tenBoPhanDangNhap = string.Empty;

        public string TenBoPhanDangNhap
        {
            get { return _tenBoPhanDangNhap; }
            set { _tenBoPhanDangNhap = value; }
        }
        private int _MaCongTy = ERP_Library.Security.CurrentUser.Info.MaCongTy;//Value luu xuống là MaCongTy
        public int MaCongTy
        {
            get { return _MaCongTy; }
            set { _MaCongTy = value; }
        }

        private int _maLoaiDoiTuong = 0;

        public int MaLoaiDoiTuong
        {
            get { return _maLoaiDoiTuong; }
            set { _maLoaiDoiTuong = value; }
        }
        ButToanList _butToanList = ButToanList.NewButToanList();
        public ButToanList ButToanList
        {
            get
            {
                CanReadProperty(true);
                return _butToanList;
            }
            set
            {
                CanWriteProperty(true);
                if (!_butToanList.Equals(value))
                {
                    _butToanList = value;
                    PropertyHasChanged();
                }
            }
        }

        public int LoaiChungTuDiKem
        {
            get
            {
                CanReadProperty(true);
                return _iLoaiChungTu;
            }
            set
            {
                CanWriteProperty(true);
                if (!_iLoaiChungTu.Equals(value))
                {
                    _iLoaiChungTu = value;
                    PropertyHasChanged();
                }
            }
        }

        #region BoSung Lap PhieuThu tu PhieuChi
        private long _maChungTuPC = 0;
        public long MaChungTuPC
        {
            get
            {
                CanReadProperty(true);
                return _maChungTuPC;
            }
            set
            {
                CanWriteProperty(true);
                if (!_maChungTuPC.Equals(value))
                {
                    _maChungTuPC = value;
                    PropertyHasChanged();
                }
            }
        }

        PhieuThutuPhieuChiEditableChildList _phieuThutuPhieuChiList = PhieuThutuPhieuChiEditableChildList.NewPhieuThutuPhieuChiEditableChildList();
        public PhieuThutuPhieuChiEditableChildList PhieuThutuPhieuChiList
        {
            get
            {
                CanReadProperty(true);
                return _phieuThutuPhieuChiList;
            }
            set
            {
                CanWriteProperty(true);
                if (!_phieuThutuPhieuChiList.Equals(value))
                {
                    _phieuThutuPhieuChiList = value;
                    PropertyHasChanged();
                }
            }
        }
        #endregion//BoSung Lap PhieuThu tu PhieuChi

        #region BS ChungTu_HoaDonList
        ChungTu_HoaDonList _chungtu_HoaDonList = ChungTu_HoaDonList.NewChungTu_HoaDonList();
        public ChungTu_HoaDonList Chungtu_HoaDonList
        {
            get
            {
                CanReadProperty(true);
                return _chungtu_HoaDonList;
            }
            set
            {
                CanWriteProperty(true);
                if (!_chungtu_HoaDonList.Equals(value))
                {
                    _chungtu_HoaDonList = value;
                    PropertyHasChanged();
                }
            }
        }
        #endregion//BS ChungTu_HoaDonList

        #endregion

        #region constructor
        public ChungTu()
        {

        }
        public ChungTu(bool them)
        {
            //_ChungTuGoc = HoaDonList.NewHoaDonList();
            //_DSPhieuNhapXuatList = DSPhieuNhapXuatList.NewDSPhieuNhapXuatList();
            _DinhKhoan = DinhKhoan.NewDinhKhoan();
        }
        public ChungTu(int maLoaiChung)
        {
            if (maLoaiChung == 2 || maLoaiChung == 3)
            {
                _MaPhuongThucThanhToan = 1;
            }
            else if (maLoaiChung == 6 || maLoaiChung == 7 || maLoaiChung == 8 || maLoaiChung == 16)
            {
                _MaPhuongThucThanhToan = 2;
            }
            _LoaiChungTu = LoaiChungTuDev.GetLoaiChungTuDev(maLoaiChung);
            _Tien.MaLoaiTien = 1;
            _Tien.SoTien = Tien.ThanhTien;
        }
        #endregion

        #region Factory Methods

        internal static ChungTu NewChungTuChild()
        {
            ChungTu ct = new ChungTu();
            ct.MarkAsChild();
            return ct;
        }
        public static string LaySoChungTuMax(int maLoaiChungTu, int _nam)
        {
            string strSoMoi = string.Empty;
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                SqlCommand cm = cn.CreateCommand();
                cm.CommandType = System.Data.CommandType.Text;
                if (BoPhan.GetBoPhan(ERP_Library.Security.CurrentUser.Info.MaBoPhan).MaBoPhanQL == "DV02")
                {
                    //cm.CommandText = "select (Max(Left(SoChungTu,4))+1)as SoCTMax from tblChungTu where MaLoaiChungTu=@MaLoaiChungTu and MaBoPhanDangNhap in(2,3)";
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spdGetSoChungTuMax";
                    cm.Parameters.AddWithValue("@MaLoaiChungTu", maLoaiChungTu);
                    cm.Parameters.AddWithValue("@Nam", _nam);
                }
                else
                {
                    if (maLoaiChungTu == 2 || maLoaiChungTu == 3)
                    {
                        cm.CommandText = "select (Max(Left(SoChungTu,4))+1)as SoCTMax from tblChungTu where MaLoaiChungTu=@MaLoaiChungTu and  year(NgayLap)=@Nam and MaBoPhanDangNhap=@MaNguoiLap and NgayLap>'3/1/2010'";
                        cm.Parameters.AddWithValue("@MaNguoiLap", ERP_Library.Security.CurrentUser.Info.MaBoPhan);
                    }
                    else
                    {
                        cm.CommandText = "select (Max(Left(SoChungTu,4))+1)as SoCTMax from tblChungTu where MaLoaiChungTu=@MaLoaiChungTu and  year(NgayLap)=@Nam and MaNguoiLap=@MaNguoiLap and NgayLap>'3/1/2010'";
                        cm.Parameters.AddWithValue("@MaNguoiLap", ERP_Library.Security.CurrentUser.Info.UserID);
                    }
                    cm.Parameters.AddWithValue("@MaLoaiChungTu", maLoaiChungTu);
                    cm.Parameters.AddWithValue("@Nam", _nam);

                }
                strSoMoi = Convert.ToString(cm.ExecuteScalar());
                if (strSoMoi == "")
                {
                    strSoMoi = "1";
                }
                cn.Close();
            }
            int len = strSoMoi.Length;
            string nam = _nam.ToString();//DateTime.Today.Year.ToString();
            while (len < 4)
            {
                strSoMoi = "0" + strSoMoi;
                len = strSoMoi.Length;
            }
            if (maLoaiChungTu == 2)
                strSoMoi = strSoMoi + "T/" + ERP_Library.Security.CurrentUser.Info.MaQLUser + "/" + (BoPhan.GetBoPhan(ERP_Library.Security.CurrentUser.Info.MaBoPhan)).MaBoPhanQL.Substring(0, 4);
            else if (maLoaiChungTu == 3)
                strSoMoi = strSoMoi + "C/" + ERP_Library.Security.CurrentUser.Info.MaQLUser + "/" + (BoPhan.GetBoPhan(ERP_Library.Security.CurrentUser.Info.MaBoPhan)).MaBoPhanQL.Substring(0, 4);
            else if (maLoaiChungTu == 15)
                strSoMoi = strSoMoi + "D/" + ERP_Library.Security.CurrentUser.Info.MaQLUser + "/" + (BoPhan.GetBoPhan(ERP_Library.Security.CurrentUser.Info.MaBoPhan)).MaBoPhanQL.Substring(0, 4);
            else if (maLoaiChungTu == 16)
                strSoMoi = strSoMoi + "K/" + ERP_Library.Security.CurrentUser.Info.MaQLUser + "/" + (BoPhan.GetBoPhan(ERP_Library.Security.CurrentUser.Info.MaBoPhan)).MaBoPhanQL.Substring(0, 4);

            return strSoMoi + "/" + _nam.ToString();
        }

        public static ChungTu GetChungTuRoot(int id)
        {
            return DataPortal.Create<ChungTu>(
              new RootCriteria(id));
        }

        public string SoChungTuTuDongTang(int LoaiDoiTuong, long MaDangNhap, DateTime NgayLap)
        {
            String giaTriTraVe = string.Empty;
            //using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            //{
            //    cn.Open();
            //    using (SqlCommand cm = cn.CreateCommand())
            //    {
            //        cm.CommandType = CommandType.StoredProcedure;
            //        cm.CommandText = "spd_LaySoChungTuLonNhat";
            //        cm.Parameters.AddWithValue("@LoaiDoiTuong", LoaiDoiTuong);
            //        cm.Parameters.AddWithValue("@MaDangNhap", MaDangNhap);
            //        cm.Parameters.AddWithValue("@NgayLap", NgayLap);
            //        SqlParameter OutPut = new SqlParameter("@GiaTriTraVe", SqlDbType.VarChar, 30);
            //        OutPut.Direction = ParameterDirection.Output;
            //        cm.Parameters.Add(OutPut);
            //        cm.ExecuteNonQuery();
            //        giaTriTraVe = (String)OutPut.Value;
            //    }
            //}//us
            return giaTriTraVe;
        }

        internal static ChungTu GetChungTuChild(SafeDataReader dr)
        {
            return new ChungTu(dr);
        }

        public static void DeleteSwitchableObject(int id)
        {
            DataPortal.Delete(new RootCriteria(id));
        }


        #endregion

        #region Static Methods


        public override ChungTu Save()
        {
            return base.Save();
        }

        public void DeleteSelf()
        {
            DataPortal_Delete(new Criteria(_MaChungTu));
        }

        public void Insert()
        {
            DataPortal_Insert();
        }

        public void InsertTranSacTion(SqlTransaction tr)
        {
            DataPortal_InsertTranSacTion(tr);
        }

        public void Update()
        {

            DataPortal_Update();
        }

        public void UpdateTranSacTion(SqlTransaction tr)
        {
            DataPortal_UpdateTranSacTion(tr);
        }
        /// <summary>
        /// Constructor này dùng cho PhongBanList Load từng Phòng Ban lên
        /// </summary>
        /// <param name="dr">là SafeDataReader của PhongBanList Fetch ra</param>
        //loadct
        private ChungTu(SafeDataReader dr)
        {

            try
            {

                _maBoPhanDangNhap = dr.GetInt32("MaBoPhanDangNhap");
                _tenBoPhanDangNhap = dr.GetString("TenBoPhanDangNhap");
                _MaCongTy = dr.GetInt32("MaCongTy");
                _maLoaiDoiTuong = dr.GetInt32("MaLoaiDoiTuong");
                _MaChungTu = dr.GetInt64("MaChungTu");
                _SoTT = dr.GetInt32("SoTT");
                _SoChungTu = dr.GetString("SoChungTu");
                _NgayLap = dr.GetSmartDate("NgayLap");
                _GhiMucNganSach = dr.GetBoolean("GhiMucNganSach");
                _NgayThucHien = dr.GetSmartDate("NgayThucHien");
                _GhiSoCai = dr.GetBoolean("GhiSoCai");
                _DoiTuong = dr.GetInt64("MaDoiTuong");
                _DinhKhoan = DinhKhoan.GetDinhKhoan(dr.GetInt32("MaDinhKhoan"));
                _LoaiChungTu = LoaiChungTuDev.GetLoaiChungTuDev(dr.GetInt32("MaLoaiChungTu"));
                _KhoaSo = dr.GetByte("KhoaSo");
                _MaChungTuQL = dr.GetString("MaChungTuQL");
                _DienGiai = dr.GetString("DienGiai");
                _MaDoiTuongThuChi = dr.GetInt32("MaDoiTuongThuChi");
                _MaPhuongThucThanhToan = dr.GetInt32("MaPhuongThucThanhToan");
                _SoChungTuKemTheo = dr.GetInt32("SoChungTuKemTheo");
                _ChungTuKemTheo = dr.GetString("ChungTuKemTheo");
                _MaHoatDong = dr.GetInt32("MaHoatDong");
                _Tien = TienTe.GetTienTe(_MaChungTu);
                _BoSungChungTu = BoSungChungTu.GetBoSungChungTu(_MaChungTu);
                _tyGia = _Tien.TiGiaQuyDoi;
                _thanhTien = _Tien.ThanhTien;
                _idSet = true; //Do tự set value cho ID

                //if (_DoiTuong == 0)
                //{
                _ChungTu_DiaChi = ChungTu_DiaChi.GetChungTu_DiaChi(_MaChungTu);
                //}

                _TamUngList = ERP_Library.TamUngList.GetTamUngList(_MaChungTu);
                _chungtu_HoaDonList = ChungTu_HoaDonList.GetChungTu_HoaDonListByChungTuDev(_MaChungTu);
                _chungTuTheoDoi = ChungTu_TheoDoi.GetChungTu_TheoDoi(_MaChungTu);
                _chungTu_ChiPhiSanXuatList = ChungTu_ChiPhiSanXuatList.GetChungTu_ChiPhiSanXuatList(_MaChungTu);
                //Thành thêm 
                _chungTu_DeNghiChuyenKhoan = ChungTu_DeNghiChuyenKhoanChildList.GetChungTu_DeNghiChuyenKhoanChildListByChungTu(MaChungTu);
                _chungTu_GiayBaoCoList = ChungTu_GiayBaoCoList.GetChungTu_GiayBaoCoList(MaChungTu);
                _CT_ChungTuBienLaiList = CT_ChungTuBienLaiChildList.GetCT_ChungTuBienLaiChildList(MaChungTu);
                _chungTu_HoaDonThanhToanList = ChungTu_HoaDonThanhToanChildList.GetChungTu_HoaDonThanhToanChildListByChungTu(MaChungTu);
                _ChungTu_ChungTuList = ChungTu_ChungTuChildList.GetChungTu_ChungTuChildList(MaChungTu);
                _chungTu_GiayBanNgoaiTeChildList = ChungTu_GiayBanNgoaiTeChildList.GetChungTu_GiayBanNgoaiTeChildList(MaChungTu);
                _chungTu_LenhChuyenTienNNChildList = ChungTu_LenhChuyenTienNNChildList.GetChungTu_LenhChuyenTienNNChildList(MaChungTu);
                _chungTu_GiayRutTienChildList = ChungTu_GiayRutTienChildList.GetChungTu_GiayRutTienChildList(MaChungTu);
                _chungTu_UyNhiemChiChildList = ChungTu_UNCChildList.GetChungTu_UNCChildList(MaChungTu);

                //Get lương, thưởng, phụ cấp, thù lao
                //_thuLaoChuongTrinhList = ThuLaoChuongTrinhList.GetThuLaoChuongTrinhList(MaChungTu);
                //_phuCapNhanVienList = PhuCapNhanVienList.GetPhuCapNhanVienList(MaChungTu);
                //_bangluongKy1List = BangLuongKyIList.GetBangLuongKyIList(MaChungTu);
                //_bangluongKy2List = BangLuongKyIIList.GetBangLuongKyIIList(MaChungTu);

                _iLoaiChungTu = dr.GetInt32("LoaiChungTu");

                //
                FetchChildren(this._DinhKhoan);
                MarkOld();

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        private ChungTu(SafeDataReader dr, int loai)
        {
            try
            {
                _maBoPhanDangNhap = dr.GetInt32("MaBoPhanDangNhap");
                _tenBoPhanDangNhap = dr.GetString("TenBoPhanDangNhap");
                _MaCongTy = dr.GetInt32("MaCongTy");
                _maLoaiDoiTuong = dr.GetInt32("MaLoaiDoiTuong");
                _MaChungTu = dr.GetInt64("MaChungTu");
                _SoTT = dr.GetInt32("SoTT");
                _SoChungTu = dr.GetString("SoChungTu");
                _NgayLap = dr.GetSmartDate("NgayLap");
                _GhiMucNganSach = dr.GetBoolean("GhiMucNganSach");
                _NgayThucHien = dr.GetSmartDate("NgayThucHien");
                _GhiSoCai = dr.GetBoolean("GhiSoCai");
                _DoiTuong = dr.GetInt64("MaDoiTuong");
                _DinhKhoan = DinhKhoan.GetDinhKhoan(dr.GetInt32("MaDinhKhoan"));
                _LoaiChungTu = LoaiChungTuDev.GetLoaiChungTuDev(dr.GetInt32("MaLoaiChungTu"));
                _KhoaSo = dr.GetByte("KhoaSo");
                _MaChungTuQL = dr.GetString("MaChungTuQL");
                _DienGiai = dr.GetString("DienGiai");
                _MaDoiTuongThuChi = dr.GetInt32("MaDoiTuongThuChi");
                _MaPhuongThucThanhToan = dr.GetInt32("MaPhuongThucThanhToan");
                _SoChungTuKemTheo = dr.GetInt32("SoChungTuKemTheo");
                _ChungTuKemTheo = dr.GetString("ChungTuKemTheo");
                _MaHoatDong = dr.GetInt32("MaHoatDong");
                _MaNhanVienLap = dr.GetInt64("MaNhanVienLap");
                _Tien = TienTe.GetTienTe(_MaChungTu);
                _BoSungChungTu = BoSungChungTu.GetBoSungChungTu(_MaChungTu);
                _tyGia = _Tien.TiGiaQuyDoi;
                _thanhTien = _Tien.ThanhTien;
                _idSet = true; //Do tự set value cho ID

                //if (_DoiTuong == 0)
                //{
                _ChungTu_DiaChi = ChungTu_DiaChi.GetChungTu_DiaChi(_MaChungTu);
                //}

                _TamUngList = ERP_Library.TamUngList.GetTamUngList(_MaChungTu);
                _chungtu_HoaDonList = ChungTu_HoaDonList.GetChungTu_HoaDonListByChungTuDev(_MaChungTu);
                _chungTuTheoDoi = ChungTu_TheoDoi.GetChungTu_TheoDoi(_MaChungTu);
                _chungTu_ChiPhiSanXuatList = ChungTu_ChiPhiSanXuatList.GetChungTu_ChiPhiSanXuatList(_MaChungTu);
                //Thành thêm 
                _chungTu_DeNghiChuyenKhoan = ChungTu_DeNghiChuyenKhoanChildList.GetChungTu_DeNghiChuyenKhoanChildListByChungTu(MaChungTu);
                _chungTu_GiayBaoCoList = ChungTu_GiayBaoCoList.GetChungTu_GiayBaoCoList(MaChungTu);
                _CT_ChungTuBienLaiList = CT_ChungTuBienLaiChildList.GetCT_ChungTuBienLaiChildList(MaChungTu);
                _chungTu_HoaDonThanhToanList = ChungTu_HoaDonThanhToanChildList.GetChungTu_HoaDonThanhToanChildListByChungTu(MaChungTu);
                _ChungTu_ChungTuList = ChungTu_ChungTuChildList.GetChungTu_ChungTuChildList(MaChungTu);
                _chungTu_GiayBanNgoaiTeChildList = ChungTu_GiayBanNgoaiTeChildList.GetChungTu_GiayBanNgoaiTeChildList(MaChungTu);
                _chungTu_LenhChuyenTienNNChildList = ChungTu_LenhChuyenTienNNChildList.GetChungTu_LenhChuyenTienNNChildList(MaChungTu);
                _chungTu_GiayRutTienChildList = ChungTu_GiayRutTienChildList.GetChungTu_GiayRutTienChildList(MaChungTu);
                _chungTu_UyNhiemChiChildList = ChungTu_UNCChildList.GetChungTu_UNCChildList(MaChungTu);

                //Get lương, thưởng, phụ cấp, thù lao
                //_thuLaoChuongTrinhList = ThuLaoChuongTrinhList.GetThuLaoChuongTrinhList(MaChungTu);
                //_phuCapNhanVienList = PhuCapNhanVienList.GetPhuCapNhanVienList(MaChungTu);
                //_bangluongKy1List = BangLuongKyIList.GetBangLuongKyIList(MaChungTu);
                //_bangluongKy2List = BangLuongKyIIList.GetBangLuongKyIIList(MaChungTu);
                _iLoaiChungTu = dr.GetInt32("LoaiChungTu");
                #region Bosung LapPhieuThu tu PhieuThu
                bool _haveMaChungTuPC = false;
                for (int i = 0; i < dr.FieldCount; i++)
                {
                    if (dr.GetName(i) == "MaChungTuPC")
                    {
                        _haveMaChungTuPC = true;
                        break;
                    }
                }
                if (_haveMaChungTuPC)
                {
                    _maChungTuPC = dr.GetInt64("MaChungTuPC");
                }
                #endregion//Bosung LapPhieuThu tu PhieuThu

                FetchChildren(this._DinhKhoan, loai);
                MarkOld();

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        // By loc
        private ChungTu(SafeDataReader dr, bool edit)
        {
            try
            {
                _maBoPhanDangNhap = dr.GetInt32("MaBoPhanDangNhap");
                _tenBoPhanDangNhap = dr.GetString("TenBoPhanDangNhap");
                _MaCongTy = dr.GetInt32("MaCongTy");
                _maLoaiDoiTuong = dr.GetInt32("MaLoaiDoiTuong");
                _MaChungTu = dr.GetInt64("MaChungTu");
                _SoTT = dr.GetInt32("SoTT");
                _SoChungTu = dr.GetString("SoChungTu");
                _NgayLap = dr.GetSmartDate("NgayLap");
                _GhiMucNganSach = dr.GetBoolean("GhiMucNganSach");
                _NgayThucHien = dr.GetSmartDate("NgayThucHien");
                _GhiSoCai = dr.GetBoolean("GhiSoCai");
                _DoiTuong = dr.GetInt64("MaDoiTuong");
                _DinhKhoan = DinhKhoan.GetDinhKhoanByLoc(dr.GetInt32("MaDinhKhoan"));
                _KhoaSo = dr.GetByte("KhoaSo");
                _MaChungTuQL = dr.GetString("MaChungTuQL");
                _DienGiai = dr.GetString("DienGiai");
                _MaDoiTuongThuChi = dr.GetInt32("MaDoiTuongThuChi");
                _MaPhuongThucThanhToan = dr.GetInt32("MaPhuongThucThanhToan");
                _SoChungTuKemTheo = dr.GetInt32("SoChungTuKemTheo");
                _ChungTuKemTheo = dr.GetString("ChungTuKemTheo");
                _MaHoatDong = dr.GetInt32("MaHoatDong");
                _tyGia = _Tien.TiGiaQuyDoi;
                _thanhTien = _Tien.ThanhTien;
                _chungTu_DeNghiChuyenKhoan = ChungTu_DeNghiChuyenKhoanChildList.GetChungTu_DeNghiChuyenKhoanChildListByChungTu(MaChungTu);
                _idSet = true; //Do tự set value cho ID
                _chungTu_GiayBaoCoList = ChungTu_GiayBaoCoList.GetChungTu_GiayBaoCoList(MaChungTu);
                _CT_ChungTuBienLaiList = CT_ChungTuBienLaiChildList.GetCT_ChungTuBienLaiChildList(MaChungTu);
                _chungTu_HoaDonThanhToanList = ChungTu_HoaDonThanhToanChildList.GetChungTu_HoaDonThanhToanChildListByChungTu(MaChungTu);
                _ChungTu_ChungTuList = ChungTu_ChungTuChildList.GetChungTu_ChungTuChildList(MaChungTu);
                _chungTu_GiayBanNgoaiTeChildList = ChungTu_GiayBanNgoaiTeChildList.GetChungTu_GiayBanNgoaiTeChildList(MaChungTu);
                _chungTu_LenhChuyenTienNNChildList = ChungTu_LenhChuyenTienNNChildList.GetChungTu_LenhChuyenTienNNChildList(MaChungTu);
                _chungTu_GiayRutTienChildList = ChungTu_GiayRutTienChildList.GetChungTu_GiayRutTienChildList(MaChungTu);
                _chungTu_UyNhiemChiChildList = ChungTu_UNCChildList.GetChungTu_UNCChildList(MaChungTu);

                //Get lương, thưởng, phụ cấp, thù lao
                //_thuLaoChuongTrinhList = ThuLaoChuongTrinhList.GetThuLaoChuongTrinhList(MaChungTu);
                //_phuCapNhanVienList = PhuCapNhanVienList.GetPhuCapNhanVienList(MaChungTu);
                //_bangluongKy1List = BangLuongKyIList.GetBangLuongKyIList(MaChungTu);
                //_bangluongKy2List = BangLuongKyIIList.GetBangLuongKyIIList(MaChungTu);
                MarkOld();

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public static ChungTu NewChungTu()
        {
            return new ChungTu();
        }
        public static ChungTu NewChungTu(string p)
        {
            ChungTu ct = new ChungTu();
            ct.SoChungTu = p;
            return ct;
        }
        public static ChungTu NewChungTu(bool them)
        {
            return new ChungTu(them);
        }

        public static ChungTu NewChungTu(int maLoaiChungTu)
        {
            return new ChungTu(maLoaiChungTu);
        }

        public static ChungTu NewChungTu(int soTT, String soChungTu, SmartDate ngayLap, Boolean ghiMucNganSach, SmartDate ngayThucHien,
            Boolean ghiSoCai, Int32 nguoiLap, long maDoiTuong, int maHopDong,
            int maDinhKhoan, int maLoaiChungTu, int maTienTe, int maKy, Int16 khoaSo,
            String maChungTuQL, String dienGiai)
        {
            ChungTu chungTu = new ChungTu();
            chungTu._SoTT = soTT;
            chungTu._SoChungTu = soChungTu;
            chungTu._NgayLap = ngayLap;
            chungTu._GhiMucNganSach = ghiMucNganSach;
            chungTu._NgayThucHien = ngayThucHien;
            chungTu._GhiSoCai = ghiSoCai;
            chungTu._NguoiLap = nguoiLap;
            chungTu._DoiTuong = maDoiTuong;
            chungTu._DinhKhoan = DinhKhoan.GetDinhKhoan(maDinhKhoan);
            chungTu._Tien = TienTe.GetTienTe(maTienTe);
            chungTu._LoaiChungTu = LoaiChungTuDev.GetLoaiChungTuDev(maLoaiChungTu);
            //chungTu._Ky = Ky.GetKy( maKy);
            chungTu._KhoaSo = khoaSo;
            chungTu._MaChungTuQL = maChungTuQL;
            chungTu._DienGiai = dienGiai;
            return chungTu;
        }

        public static ChungTu GetChungTu(long maChungTu)
        {
            return (ChungTu)DataPortal.Fetch<ChungTu>(new Criteria(maChungTu));
        }

        public static ChungTu GetChungTuBySoChungTu(string soChungTu)
        {
            return (ChungTu)DataPortal.Fetch<ChungTu>(new CriteriaBySoChungTu(soChungTu));
        }
        internal static ChungTu GetChungTu(SafeDataReader dr)
        {
            return new ChungTu(dr);
        }

        internal static ChungTu GetChungTu_New(SafeDataReader dr)
        {
            return new ChungTu(dr, 1);
        }

        // by loc
        internal static ChungTu GetChungTu_ByLoc(SafeDataReader dr)
        {
            return new ChungTu(dr, true);
        }

        internal static ChungTu GetChungTuList(SafeDataReader dr)
        {
            ChungTu ct = new ChungTu();
            ct._MaChungTu = dr.GetInt64("MaChungTu");
            ct._SoTT = dr.GetInt32("SoTT");
            ct._SoChungTu = dr.GetString("SoChungTu");
            ct._NgayLap = dr.GetSmartDate("NgayLap");
            ct._GhiMucNganSach = dr.GetBoolean("GhiMucNganSach");
            ct._NgayThucHien = dr.GetSmartDate("NgayThucHien");
            ct._GhiSoCai = dr.GetBoolean("GhiSoCai");
            ct._DoiTuong = dr.GetInt64("MaDoiTuong");
            ct._DinhKhoan = DinhKhoan.GetDinhKhoan(dr.GetInt32("MaDinhKhoan"));
            ct._LoaiChungTu = LoaiChungTuDev.GetLoaiChungTuDev(dr.GetInt32("MaLoaiChungTu"));
            ct._KhoaSo = dr.GetByte("KhoaSo");
            ct._MaChungTuQL = dr.GetString("MaChungTuQL");
            ct._DienGiai = dr.GetString("DienGiai");
            ct._MaDoiTuongThuChi = dr.GetInt32("MaDoiTuongThuChi");
            ct._MaPhuongThucThanhToan = dr.GetInt32("MaPhuongThucThanhToan");
            ct._SoChungTuKemTheo = dr.GetInt32("SoChungTuKemTheo");
            ct._ChungTuKemTheo = dr.GetString("ChungTuKemTheo");
            ct._MaHoatDong = dr.GetInt32("MaHoatDong");
            ct._Tien = TienTe.GetTienTe(ct._MaChungTu);
            ct._BoSungChungTu = BoSungChungTu.GetBoSungChungTu(ct._MaChungTu);
            ct._tyGia = ct._Tien.TiGiaQuyDoi;
            ct._thanhTien = ct._Tien.ThanhTien;
            ct._maBoPhanDangNhap = dr.GetInt32("MaBoPhanDangNhap");
            ct._tenBoPhanDangNhap = dr.GetString("TenBoPhanDangNhap");
            ct._MaCongTy = dr.GetInt32("MaCongTy");
            ct._maLoaiDoiTuong = dr.GetInt32("MaLoaiDoiTuong");
            //Thành thêm (16/04/2012)
            ct._chungTu_DeNghiChuyenKhoan = ChungTu_DeNghiChuyenKhoanChildList.GetChungTu_DeNghiChuyenKhoanChildListByChungTu(ct.MaChungTu);
            ct._chungTu_GiayBaoCoList = ChungTu_GiayBaoCoList.GetChungTu_GiayBaoCoList(ct.MaChungTu);
            ct._CT_ChungTuBienLaiList = CT_ChungTuBienLaiChildList.GetCT_ChungTuBienLaiChildList(ct.MaChungTu);
            ct._chungTu_HoaDonThanhToanList = ChungTu_HoaDonThanhToanChildList.GetChungTu_HoaDonThanhToanChildListByChungTu(ct.MaChungTu);
            ct._ChungTu_ChungTuList = ChungTu_ChungTuChildList.GetChungTu_ChungTuChildList(ct.MaChungTu);
            ct._chungTu_GiayBanNgoaiTeChildList = ChungTu_GiayBanNgoaiTeChildList.GetChungTu_GiayBanNgoaiTeChildList(ct.MaChungTu);
            ct._chungTu_LenhChuyenTienNNChildList = ChungTu_LenhChuyenTienNNChildList.GetChungTu_LenhChuyenTienNNChildList(ct.MaChungTu);
            ct._chungTu_GiayRutTienChildList = ChungTu_GiayRutTienChildList.GetChungTu_GiayRutTienChildList(ct.MaChungTu);
            ct._chungTu_UyNhiemChiChildList = ChungTu_UNCChildList.GetChungTu_UNCChildList(ct.MaChungTu);
            //Get lương, thưởng, phụ cấp, thù lao
            //ct._thuLaoChuongTrinhList = ThuLaoChuongTrinhList.GetThuLaoChuongTrinhList(ct.MaChungTu);
            //ct._phuCapNhanVienList = PhuCapNhanVienList.GetPhuCapNhanVienList(ct.MaChungTu);
            //ct._bangluongKy1List = BangLuongKyIList.GetBangLuongKyIList(ct.MaChungTu);
            //ct._bangluongKy2List = BangLuongKyIIList.GetBangLuongKyIIList(ct.MaChungTu);
            ct.FetchChildren(ct._DinhKhoan);
            ct.MarkOld();

            return ct;
        }
        internal static ChungTu GetChungTuList_New(SafeDataReader dr)
        {
            ChungTu ct = new ChungTu();
            ct._MaChungTu = dr.GetInt64("MaChungTu");
            ct._SoTT = dr.GetInt32("SoTT");
            ct._SoChungTu = dr.GetString("SoChungTu");
            ct._NgayLap = dr.GetSmartDate("NgayLap");
            ct._GhiMucNganSach = dr.GetBoolean("GhiMucNganSach");
            ct._NgayThucHien = dr.GetSmartDate("NgayThucHien");
            ct._GhiSoCai = dr.GetBoolean("GhiSoCai");
            ct._DoiTuong = dr.GetInt64("MaDoiTuong");
            ct._DinhKhoan = DinhKhoan.GetDinhKhoan(dr.GetInt32("MaDinhKhoan"));
            ct._LoaiChungTu = LoaiChungTuDev.GetLoaiChungTuDev(dr.GetInt32("MaLoaiChungTu"));
            ct._KhoaSo = dr.GetByte("KhoaSo");
            ct._MaChungTuQL = dr.GetString("MaChungTuQL");
            ct._DienGiai = dr.GetString("DienGiai");
            ct._MaDoiTuongThuChi = dr.GetInt32("MaDoiTuongThuChi");
            ct._MaPhuongThucThanhToan = dr.GetInt32("MaPhuongThucThanhToan");
            ct._SoChungTuKemTheo = dr.GetInt32("SoChungTuKemTheo");
            ct._ChungTuKemTheo = dr.GetString("ChungTuKemTheo");
            ct._MaHoatDong = dr.GetInt32("MaHoatDong");
            ct._Tien = TienTe.GetTienTe(ct._MaChungTu);
            ct._BoSungChungTu = BoSungChungTu.GetBoSungChungTu(ct._MaChungTu);
            ct._tyGia = ct._Tien.TiGiaQuyDoi;
            ct._thanhTien = ct._Tien.ThanhTien;
            ct._maBoPhanDangNhap = dr.GetInt32("MaBoPhanDangNhap");
            ct._tenBoPhanDangNhap = dr.GetString("TenBoPhanDangNhap");
            ct._MaCongTy = dr.GetInt32("MaCongTy");
            ct._maLoaiDoiTuong = dr.GetInt32("MaLoaiDoiTuong");
            //Thành thêm (16/04/2012)
            ct._chungTu_DeNghiChuyenKhoan = ChungTu_DeNghiChuyenKhoanChildList.GetChungTu_DeNghiChuyenKhoanChildListByChungTu(ct.MaChungTu);
            ct._chungTu_GiayBaoCoList = ChungTu_GiayBaoCoList.GetChungTu_GiayBaoCoList(ct.MaChungTu);
            ct._CT_ChungTuBienLaiList = CT_ChungTuBienLaiChildList.GetCT_ChungTuBienLaiChildList(ct.MaChungTu);
            ct._chungTu_HoaDonThanhToanList = ChungTu_HoaDonThanhToanChildList.GetChungTu_HoaDonThanhToanChildListByChungTu(ct.MaChungTu);
            ct._ChungTu_ChungTuList = ChungTu_ChungTuChildList.GetChungTu_ChungTuChildList(ct.MaChungTu);
            ct._chungTu_GiayBanNgoaiTeChildList = ChungTu_GiayBanNgoaiTeChildList.GetChungTu_GiayBanNgoaiTeChildList(ct.MaChungTu);
            ct._chungTu_LenhChuyenTienNNChildList = ChungTu_LenhChuyenTienNNChildList.GetChungTu_LenhChuyenTienNNChildList(ct.MaChungTu);
            ct._chungTu_GiayRutTienChildList = ChungTu_GiayRutTienChildList.GetChungTu_GiayRutTienChildList(ct.MaChungTu);
            ct._chungTu_UyNhiemChiChildList = ChungTu_UNCChildList.GetChungTu_UNCChildList(ct.MaChungTu);
            //Get lương, thưởng, phụ cấp, thù lao
            //ct._thuLaoChuongTrinhList = ThuLaoChuongTrinhList.GetThuLaoChuongTrinhList(ct.MaChungTu);
            //ct._phuCapNhanVienList = PhuCapNhanVienList.GetPhuCapNhanVienList(ct.MaChungTu);
            //ct._bangluongKy1List = BangLuongKyIList.GetBangLuongKyIList(ct.MaChungTu);
            //ct._bangluongKy2List = BangLuongKyIIList.GetBangLuongKyIIList(ct.MaChungTu);
            ct.FetchChildren(ct._DinhKhoan, 1);
            ct.MarkOld();

            return ct;
        }
        internal static ChungTu GetChungTuByLoaiChungTu(SafeDataReader dr)
        {
            ChungTu ct = new ChungTu();
            ct._MaChungTu = dr.GetInt64("MaChungTu");
            ct._SoChungTu = dr.GetString("SoChungTu");
            //   TienTe _Tien = TienTe.GetTienTe(ct._MaChungTu);

            // ct.ThanhTien= _Tien.ThanhTien;
            ct.NgayLap = dr.GetDateTime("NgayLap");
            ct.DienGiai = dr.GetString("DienGiai");
            // ct.LoaiChungTu.MaLoaiCT = dr.GetInt32("MaLoaiChungTu");
            ct.MarkAsChild();
            ct.MarkOld();
            return ct;
        }
        private string _tenBoPhan = string.Empty;
        public String TenBoPhan
        {
            get
            {
                CanReadProperty(true);
                return _tenBoPhan;
            }
            set
            {
                CanWriteProperty(true);
                if (!_tenBoPhan.Equals(value))
                {
                    _tenBoPhan = value;
                    PropertyHasChanged();
                }
            }
        }

        internal static ChungTu GetChungTuByQuanTri(SafeDataReader dr)
        {
            ChungTu child = new ChungTu();
            child.MarkAsChild();
            child.FetchByQuanTri(dr);
            return child;
        }
        internal static ChungTu GetChungTuByListAll(SafeDataReader dr)
        {
            ChungTu child = new ChungTu();
            child._SoChungTu = dr.GetString("SoChungTu");
            child._NgayLap = dr.GetSmartDate("NgayLap");
            // child._thanhTien = dr.GetDecimal("SoTien");
            child._MaChungTu = dr.GetInt64("MaChungTu");
            child.MarkOld();
            return child;
        }


        private void FetchByQuanTri(SafeDataReader dr)
        {
            FetchObjectByQuanTri(dr);
            MarkOld();

            FetchChildren(this._DinhKhoan);
        }

        private void FetchObjectByQuanTri(SafeDataReader dr)
        {
            // _maDonHang = dr.GetInt64("MaDonHang");
            _MaChungTu = dr.GetInt64("MaChungTu");
            _SoChungTu = dr.GetString("SoChungTu");
            this.SoTien = dr.GetDecimal("SoTienCT");
            _NgayLap = dr.GetSmartDate("NgayLap");
            _DienGiai = dr.GetString("DienGiai");
            _tenBoPhan = dr.GetString("TenBoPhan");
            _DinhKhoan = DinhKhoan.GetDinhKhoan(dr.GetInt32("MaDinhKhoan"));

        }
        private void FetchChildren(DinhKhoan dinhkhoan)
        {
            _butToanList = ButToanList.GetButToanList_DinhKhoan(dinhkhoan.MaDinhKhoan);
            _DinhKhoan = ERP_Library.DinhKhoan.GetDinhKhoan(dinhkhoan.MaDinhKhoan);
        }

        private void FetchChildren(DinhKhoan dinhkhoan, int loai)
        {
            _butToanList = ButToanList.GetButToanList_DinhKhoan(dinhkhoan.MaDinhKhoan);
            _DinhKhoan = ERP_Library.DinhKhoan.GetDinhKhoan_New(dinhkhoan.MaDinhKhoan);

        }
        private void FetchChildrenByLoc(DinhKhoan dinhkhoan)
        {

            _butToanList = ButToanList.GetButToanList_DinhKhoanByLoc(dinhkhoan.MaDinhKhoan);
            //_DinhKhoan = ERP_Library.DinhKhoan.GetDinhKhoan(dinhkhoan.MaDinhKhoan);

        }


        public static void DeleteChungTu(long maChungTu)
        {
            DataPortal.Delete(new Criteria(maChungTu));
        }
        // deletect
        public static void DeleteChungTu(ChungTu _ct)
        {
            SqlTransaction tr;
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                tr = cn.BeginTransaction();
                try
                {
                    _ct.TamUngList.DataPortal_Delete(tr);
                    ChungTu_TheoDoi.Dataportal_Delete(tr, _ct.MaChungTu);

                    _ct.ChungTuChiPhiSanXuatList.DataPortal_Delete(tr);
                    _ct.Tien.DataPortal_Delete(tr);
                    _ct.BoSungChungTuKT.DataPortal_Delete(tr);
                    _ct.ChungTu_DiaChi.DeleteSelf(tr);
                    _ct.ChungTuDeNghiList.DataPortal_Delete(tr);
                    _ct.ChungTuGiayBaoCoList.DataPortal_Delete(tr);
                    _ct.ChungTuGiayBanNgoaiTe.DataPortal_Delete(tr);
                    _ct.ChungTuLenhChuyenTienList.DataPortal_Delete(tr);
                    _ct.ChungTuGiayRutTienList.DataPortal_Delete(tr);
                    _ct.ChungTuUyNhiemChiList.DataPortal_Delete(tr);
                    _ct.PhieuThutuPhieuChiList.DataPortal_Delete(tr);
                    _ct.CT_ChungTuBienLaiList.Clear();
                    _ct.CT_ChungTuBienLaiList.Update(tr, _ct);
                    _ct.ChungTu_HoaDonThanhToanList.Clear();
                    _ct.ChungTu_HoaDonThanhToanList.Update(tr, _ct);
                    _ct.ChungTu_ChungList.Clear();
                    _ct.ChungTu_ChungList.Update(tr, _ct);

                    //  _ct.XoaSoChungTuTienMat();

                    using (SqlCommand cm = tr.Connection.CreateCommand())
                    {
                        cm.Transaction = tr;
                        cm.CommandType = CommandType.StoredProcedure;
                        cm.CommandText = "spd_Delete_ChungTu";
                        cm.Parameters.AddWithValue("@MaChungTu", _ct.MaChungTu);
                        cm.ExecuteNonQuery();

                    }
                    _ct.DinhKhoan.DataPortal_Delete(tr);
                    tr.Commit();
                }
                catch (SqlException ex)
                {
                    tr.Rollback();
                    throw ex;
                }
            }
        }
        //
        private void DeleteChild(SqlTransaction tr, int loaiCT)
        {
            if (loaiCT == 3)
            {
                // delete chung tu de nghi thanh toan
            }
            else if (loaiCT == 6)
            {
                // delete chung tu de nghi chuyen khoan
            }


        }
        #endregion

        #region Criteria

        [Serializable()]
        private class Criteria
        {
            // Add criteria here
            public long MaChungTu;
            public Criteria(long maChungTu)
            {
                MaChungTu = maChungTu;
            }
        }
        [Serializable()]
        private class CriteriaBySoChungTu
        {
            // Add criteria here
            public string SoChungTu;
            public CriteriaBySoChungTu(string soChungTu)
            {
                SoChungTu = soChungTu;
            }
        }

        [Serializable()]
        private class RootCriteria
        {
            // Add criteria here
            public int MaChungTu;
            public RootCriteria(int maChungTu)
            {
                MaChungTu = maChungTu;
            }
        }

        [Serializable()]
        private class ChildCriteria
        { }


        #endregion

        #region Override
        public override bool IsDirty
        {
            get
            {
                return base.IsDirty || _DinhKhoan.IsDirty || _Tien.IsDirty || _DinhKhoan.ButToan.IsDirty || _TamUngList.IsDirty || _chungTu_ChiPhiSanXuatList.IsDirty || _ChungTu_DiaChi.IsDirty || _butToanList.IsDirty
               || _chungTu_DeNghiChuyenKhoan.IsDirty || _chungTu_GiayBaoCoList.IsDirty || _chungTu_GiayBanNgoaiTeChildList.IsDirty || _chungTu_LenhChuyenTienNNChildList.IsDirty || _chungTu_GiayRutTienChildList.IsDirty || _chungTu_UyNhiemChiChildList.IsDirty
               || _phieuThutuPhieuChiList.IsDirty
               || _chungtu_HoaDonList.IsDirty
               || _CT_ChungTuBienLaiList.IsDirty
               || _BoSungChungTu.IsDirty
               || _chungTu_HoaDonThanhToanList.IsDirty
               || _ChungTu_ChungTuList.IsDirty
               ;

            }
        }
        public override bool IsValid
        {
            get
            {
                return base.IsValid && _DinhKhoan.IsValid && _Tien.IsValid && _DinhKhoan.ButToan.IsValid && _TamUngList.IsValid && _chungTu_ChiPhiSanXuatList.IsValid && _butToanList.IsValid && _ChungTu_DiaChi.IsValid
                    && _chungTu_DeNghiChuyenKhoan.IsValid && _chungTu_GiayBaoCoList.IsValid && _chungTu_GiayBanNgoaiTeChildList.IsValid && _chungTu_LenhChuyenTienNNChildList.IsValid && _chungTu_GiayRutTienChildList.IsValid && _chungTu_UyNhiemChiChildList.IsValid
                    && _phieuThutuPhieuChiList.IsValid
                    && _chungtu_HoaDonList.IsValid
                    && _CT_ChungTuBienLaiList.IsValid
                    && _BoSungChungTu.IsValid
                    && _chungTu_HoaDonThanhToanList.IsValid
                    && _ChungTu_ChungTuList.IsValid
                    ;
            }
        }
        #endregion

        #region Data Access
        protected override void DataPortal_Create()
        {
            base.DataPortal_Create();
        }

        public static int GetSoTT()
        {
            int soTT = 0;
            try
            {
                using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
                {
                    cn.Open();
                    using (SqlCommand cm = cn.CreateCommand())
                    {
                        try
                        {
                            cm.CommandType = CommandType.StoredProcedure;
                            cm.CommandText = "spd_LaySoTTChungTu";
                            soTT = (int)cm.ExecuteScalar();
                        }
                        catch (Exception ex)
                        {
                            throw ex;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return soTT;
        }

        public decimal KiemTraSoQuy(long maChungTu)
        {
            decimal kiemtra = 0;
            try
            {
                using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
                {
                    cn.Open();
                    using (SqlCommand cm = cn.CreateCommand())
                    {
                        try
                        {
                            cm.CommandType = CommandType.StoredProcedure;
                            cm.CommandText = "sp_KiemTraSoQuy";
                            cm.Parameters.AddWithValue("@MaChungTu", maChungTu);
                            kiemtra = (decimal)cm.ExecuteScalar();
                        }
                        catch (Exception ex)
                        {
                            throw ex;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return kiemtra;
        }

        public decimal KiemTraNhapThuLao(string soChungTu)
        {
            decimal kiemtra = 0;
            try
            {
                using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
                {
                    cn.Open();
                    using (SqlCommand cm = cn.CreateCommand())
                    {
                        try
                        {
                            cm.CommandType = CommandType.StoredProcedure;
                            cm.CommandText = "spd_KiemTraChungTuNhapThuLao";
                            cm.Parameters.AddWithValue("@SoChungTu", soChungTu);
                            kiemtra = (decimal)cm.ExecuteScalar();
                        }
                        catch (Exception ex)
                        {
                            throw ex;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return kiemtra;
        }

        protected override void DataPortal_Fetch(object criteria)
        {
            #region Phần Cũ Đang Chạy
            if (criteria is Criteria)
            {
                Criteria crit = (Criteria)criteria;

                // Load object data from database
                using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
                {
                    cn.Open();
                    using (SqlCommand cm = cn.CreateCommand())
                    {
                        try
                        {
                            cm.CommandType = CommandType.StoredProcedure;
                            cm.CommandText = "spd_LoadMaCaBiet_ChungTu";
                            cm.Parameters.AddWithValue("@MACHUNGTU", crit.MaChungTu);

                            using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                            {
                                while (dr.Read())
                                {
                                    _maBoPhanDangNhap = dr.GetInt32("MaBoPhanDangNhap");
                                    _tenBoPhanDangNhap = dr.GetString("TenBoPhanDangNhap");
                                    _MaCongTy = dr.GetInt32("MaCongTy");
                                    _maLoaiDoiTuong = dr.GetInt32("MaLoaiDoiTuong");
                                    _MaChungTu = dr.GetInt64("MaChungTu");
                                    _SoTT = dr.GetInt32("SoTT");
                                    _SoChungTu = dr.GetString("SoChungTu");
                                    _NgayLap = dr.GetSmartDate("NgayLap");
                                    _GhiMucNganSach = dr.GetBoolean("GhiMucNganSach");
                                    _NgayThucHien = dr.GetSmartDate("NgayThucHien");
                                    _GhiSoCai = dr.GetBoolean("GhiSoCai");
                                    _NguoiLap = dr.GetInt32("MaNguoiLap");
                                    _MaNhanVienLap = dr.GetInt64("MaNhanVienLap");
                                    _DoiTuong = dr.GetInt64("MaDoiTuong");
                                    _DinhKhoan = DinhKhoan.GetDinhKhoan(dr.GetInt32("MaDinhKhoan"));
                                    _LoaiChungTu = LoaiChungTuDev.GetLoaiChungTuDev(dr.GetInt32("MaLoaiChungTu"));
                                    //_Tien = TienTe.GetTienTe( dr.GetInt32("MaTienTe"));
                                    _Tien = TienTe.GetTienTe(_MaChungTu);
                                    _BoSungChungTu = BoSungChungTu.GetBoSungChungTu(_MaChungTu);
                                    // _Ky = Ky.GetKy( dr.GetInt32("MaKy"));
                                    _KhoaSo = (Int32)dr.GetByte("KhoaSo");
                                    _MaChungTuQL = dr.GetString("MaChungTuQL");
                                    _DienGiai = dr.GetString("DienGiai");
                                    _MaDoiTuongThuChi = dr.GetInt32("MaDoiTuongThuChi");
                                    _MaPhuongThucThanhToan = dr.GetInt32("MaPhuongThucThanhToan");

                                    _chungTu_DeNghiChuyenKhoan = ChungTu_DeNghiChuyenKhoanChildList.GetChungTu_DeNghiChuyenKhoanChildListByChungTu(dr.GetInt64("MaChungTu"));

                                    _idSet = true;
                                    dr.NextResult();
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            throw ex;
                        }
                    }

                    try
                    {
                        using (SqlCommand command = cn.CreateCommand())
                        {
                            command.CommandType = CommandType.StoredProcedure;
                            command.CommandText = "spd_LoadList_ChungTu_ByChungTuGoc";
                            command.Parameters.AddWithValue("@MaChungTu", _MaChungTu);

                            using (SafeDataReader dr = new SafeDataReader(command.ExecuteReader()))
                            {
                                // _ChungTuGoc = HoaDonList.GetHoaDonList(dr);
                            }
                        }
                    }
                    catch (Exception ee)
                    {
                        string temp = ee.Message;
                    }

                    MarkOld();
                }
            }
            #endregion
        }
        //insertct
        protected override void DataPortal_Insert() //Trang Dang dung
        {
            SqlTransaction tr;
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {

                cn.Open();
                tr = cn.BeginTransaction();
                try
                {
                    using (SqlCommand cm = tr.Connection.CreateCommand())
                    {
                        _DinhKhoan.Save(tr);
                        cm.Transaction = tr;
                        cm.CommandType = CommandType.StoredProcedure;
                        cm.CommandText = "spd_Insert_ChungTu";
                        cm.Parameters.AddWithValue("@MaChungTu", _MaChungTu).Direction = ParameterDirection.Output;
                        _SoTT = GetSoTT() + 1;
                        cm.Parameters.AddWithValue("@SoTT", _SoTT);
                        cm.Parameters.AddWithValue("@SoChungTu", _SoChungTu);
                        cm.Parameters.AddWithValue("@NgayLap", _NgayLap.DBValue);
                        cm.Parameters.AddWithValue("@GhiMucNganSach", _GhiMucNganSach);
                        cm.Parameters.AddWithValue("@NgayThucHien", _NgayThucHien.DBValue);
                        cm.Parameters.AddWithValue("@GhiSoCai", _GhiSoCai);
                        cm.Parameters.AddWithValue("@MaBoPhanDangNhap", _maBoPhanDangNhap);
                        cm.Parameters.AddWithValue("@TenBoPhanDangNhap", ERP_Library.Security.CurrentUser.Info.TenBoPhan);
                        cm.Parameters.AddWithValue("@MaCongTy", _MaCongTy);
                        cm.Parameters.AddWithValue("@MaLoaiDoiTuong", _maLoaiDoiTuong);
                        cm.Parameters.AddWithValue("@LoaiChungTu", _iLoaiChungTu);

                        cm.Parameters.AddWithValue("@MaNguoiLap", _NguoiLap);
                        if (_MaNhanVienLap != 0)
                            cm.Parameters.AddWithValue("@MaNhanVienLap", _MaNhanVienLap);
                        else
                            cm.Parameters.AddWithValue("@MaNhanVienLap", DBNull.Value);

                        if (_DoiTuong != 0)
                            cm.Parameters.AddWithValue("@MaDoiTuong", _DoiTuong);
                        else
                            cm.Parameters.AddWithValue("@MaDoiTuong", DBNull.Value);
                        if (_LoaiChungTu.MaLoaiCT != 0)
                        {
                            cm.Parameters.AddWithValue("@MaLoaiChungTu", _LoaiChungTu.MaLoaiCT);
                        }
                        else
                        {
                            cm.Parameters.AddWithValue("@MaLoaiChungTu", DBNull.Value);
                        }
                        cm.Parameters.AddWithValue("@KhoaSo", _KhoaSo);

                        if (_DinhKhoan.MaDinhKhoan != 0)
                        {
                            cm.Parameters.AddWithValue("@MaDinhKhoan", _DinhKhoan.MaDinhKhoan);
                        }
                        else cm.Parameters.AddWithValue("@MaDinhKhoan", DBNull.Value);

                        cm.Parameters.AddWithValue("@MaChungTuQL", _MaChungTuQL);
                        if (_DienGiai == null)
                        {
                            cm.Parameters.AddWithValue("@DienGiai", " ");
                        }
                        else
                        {
                            cm.Parameters.AddWithValue("@DienGiai", _DienGiai);
                        }
                        if (_MaDoiTuongThuChi != 0)
                            cm.Parameters.AddWithValue("@MaDoiTuongThuChi", _MaDoiTuongThuChi);
                        else
                            cm.Parameters.AddWithValue("@MaDoiTuongThuChi", DBNull.Value);
                        if (_MaPhuongThucThanhToan != 0)
                            cm.Parameters.AddWithValue("@MaPhuongThucThanhToan", _MaPhuongThucThanhToan);
                        else cm.Parameters.AddWithValue("@MaPhuongThucThanhToan", DBNull.Value);
                        cm.Parameters.AddWithValue("@SoChungTuKemTheo", _SoChungTuKemTheo);
                        cm.Parameters.AddWithValue("@ChungTuKemTheo", _ChungTuKemTheo);
                        if (_MaHoatDong != 0)
                            cm.Parameters.AddWithValue("@MaHoatDong", _MaHoatDong);
                        else cm.Parameters.AddWithValue("@MaHoatDong", DBNull.Value);
                        _Ky = _NgayLap.Date.Month;
                        cm.Parameters.AddWithValue("@MaKy", _Ky);
                        #region BoSung Lap PhieuThu tu PhieuChi
                        if (_maChungTuPC != 0)
                            cm.Parameters.AddWithValue("@MaChungTuPC", _maChungTuPC);
                        else
                            cm.Parameters.AddWithValue("@MaChungTuPC", DBNull.Value);
                        #endregion// BoSung Lap PhieuThu tu PhieuChi
                        cm.ExecuteNonQuery();
                        _idSet = true;
                        _MaChungTu = (long)cm.Parameters["@MaChungTu"].Value;
                        _Tien.MaTienTe = _MaChungTu;
                        _ChungTu_TaiKhoan.MaChungTu = _MaChungTu;
                        _Tien.ApplyEdit();
                        _Tien.Insert(tr);

                        if (_MaPhuongThucThanhToan == 2)
                        {
                            _ChungTu_TaiKhoan.ApplyEdit();
                            _ChungTu_TaiKhoan.Insert(tr);
                        }
                        int loaiThuChi = 0;


                        for (int i = 0; i < _DinhKhoan.ButToan.Count; i++)
                        {

                            //if (HeThongTaiKhoan1.GetHeThongTaiKhoan1(_DinhKhoan.ButToan[i].NoTaiKhoan).SoHieuTK.Contains("312") && HeThongTaiKhoan1.GetHeThongTaiKhoan1(_DinhKhoan.ButToan[i].NoTaiKhoan).SoHieuTK.StartsWith("312"))
                            if (PublicClass.KiemTraLaTaiKhoanTamUng(HeThongTaiKhoan1.GetHeThongTaiKhoan1(_DinhKhoan.ButToan[i].NoTaiKhoan).SoHieuTK))
                                loaiThuChi = 2;
                            //if (HeThongTaiKhoan1.GetHeThongTaiKhoan1(_DinhKhoan.ButToan[i].CoTaiKhoan).SoHieuTK.Contains("312") && HeThongTaiKhoan1.GetHeThongTaiKhoan1(_DinhKhoan.ButToan[i].CoTaiKhoan).SoHieuTK.StartsWith("312"))
                            if (PublicClass.KiemTraLaTaiKhoanTamUng(HeThongTaiKhoan1.GetHeThongTaiKhoan1(_DinhKhoan.ButToan[i].CoTaiKhoan).SoHieuTK))
                                loaiThuChi = 3;
                        }

                        foreach (TamUng tu in _TamUngList)
                        {
                            //tu.NgayLap = this.NgayLap;
                            if (this.NgayLap.Year <= 1900)
                            {
                                tu.NgayLap = this.NgayThucHien;
                            }
                            else
                            {
                                tu.NgayLap = this.NgayLap;
                            }
                            tu.LoaiThuChi = loaiThuChi;
                        }
                        _TamUngList.DataPortal_Update(tr, _MaChungTu, _SoChungTu);

                        //foreach (ChungTu_HoaDon ct_hd in _chungtu_HoaDonList)
                        //{
                        //    ct_hd.MaChungTu = _MaChungTu;
                        //}
                        //if (_LoaiChungTu.MaLoaiCT != 16)
                        //{
                        //    _chungTuTheoDoi.Insert(tr, this);
                        //}

                        if (_LoaiChungTu.MaLoaiCTQuanLy == "PT111"
                            || _LoaiChungTu.MaLoaiCTQuanLy == "PC111"
                            //|| _LoaiChungTu.MaLoaiCTQuanLy == "PT112"
                            //|| _LoaiChungTu.MaLoaiCTQuanLy == "PC112"
                            )
                        {
                            _chungTuTheoDoi.Insert(tr, this);
                        }

                        _chungTu_ChiPhiSanXuatList.DataPortal_Update(tr, _MaChungTu, _SoChungTu, 0);
                        #region CapNhat ChungTu_DiaChi
                        #region Old
                        //if (_DoiTuong == 0)
                        //{
                        //_ChungTu_DiaChi.MaChungTu = _MaChungTu;
                        //_ChungTu_DiaChi.ApplyEdit();
                        //_ChungTu_DiaChi.Insert(tr);
                        //}
                        #endregion//Old
                        #endregion//CapNhat ChungTu_DiaChi
                        UpdateChildren(tr);
                        this.MarkOld();

                        tr.Commit();
                    }
                }
                catch (SqlException ex)
                {
                    tr.Rollback();
                    throw ex;
                }
            }
        }

        public void DataPortal_InsertTranSacTion(SqlTransaction tr)
        {
            try
            {
                using (SqlCommand cm = tr.Connection.CreateCommand())
                {
                    _DinhKhoan.Insert(tr);
                    cm.Transaction = tr;
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_Insert_ChungTu";
                    cm.Parameters.AddWithValue("@MaChungTu", _MaChungTu).Direction = ParameterDirection.Output;
                    _SoTT = GetSoTT() + 1;
                    cm.Parameters.AddWithValue("@SoTT", _SoTT);
                    cm.Parameters.AddWithValue("@MaChungTuQL", _MaChungTuQL);
                    cm.Parameters.AddWithValue("@SoChungTu", _SoChungTu);
                    cm.Parameters.AddWithValue("@NgayLap", _NgayLap.DBValue);
                    cm.Parameters.AddWithValue("@GhiMucNganSach", _GhiMucNganSach);
                    cm.Parameters.AddWithValue("@NgayThucHien", _NgayThucHien.DBValue);
                    cm.Parameters.AddWithValue("@GhiSoCai", _GhiSoCai);
                    cm.Parameters.AddWithValue("@MaBoPhanDangNhap", _maBoPhanDangNhap);
                    cm.Parameters.AddWithValue("@TenBoPhanDangNhap", ERP_Library.Security.CurrentUser.Info.TenBoPhan);
                    cm.Parameters.AddWithValue("@MaCongTy", _MaCongTy);
                    cm.Parameters.AddWithValue("@MaLoaiDoiTuong", _maLoaiDoiTuong);
                    cm.Parameters.AddWithValue("@LoaiChungTu", _iLoaiChungTu);
                    //NHỚ PHẢI SỬA

                    cm.Parameters.AddWithValue("@MaNguoiLap", _NguoiLap);
                    if (_MaNhanVienLap != 0)
                        cm.Parameters.AddWithValue("@MaNhanVienLap", _MaNhanVienLap);
                    else
                        cm.Parameters.AddWithValue("@MaNhanVienLap", DBNull.Value);

                    if (_DoiTuong == 0)
                    {
                        cm.Parameters.AddWithValue("@MaDoiTuong", DBNull.Value);
                    }
                    else
                    {
                        cm.Parameters.AddWithValue("@MaDoiTuong", _DoiTuong);
                    }
                    if (_LoaiChungTu.MaLoaiCT != 0)
                    {
                        cm.Parameters.AddWithValue("@MaLoaiChungTu", _LoaiChungTu.MaLoaiCT);
                    }
                    else
                    {
                        cm.Parameters.AddWithValue("@MaLoaiChungTu", DBNull.Value);
                    }
                    cm.Parameters.AddWithValue("@KhoaSo", _KhoaSo);

                    if (_DinhKhoan.MaDinhKhoan != 0)
                    {
                        cm.Parameters.AddWithValue("@MaDinhKhoan", _DinhKhoan.MaDinhKhoan);
                    }
                    else cm.Parameters.AddWithValue("@MaDinhKhoan", DBNull.Value);
                    if (_MaDoiTuongThuChi != 0)
                        cm.Parameters.AddWithValue("@MaDoiTuongThuChi", _MaDoiTuongThuChi);
                    else
                        cm.Parameters.AddWithValue("@MaDoiTuongThuChi", DBNull.Value);
                    if (_MaPhuongThucThanhToan != 0)
                        cm.Parameters.AddWithValue("@MaPhuongThucThanhToan", _MaPhuongThucThanhToan);
                    else cm.Parameters.AddWithValue("@MaPhuongThucThanhToan", DBNull.Value);
                    cm.Parameters.AddWithValue("@DienGiai", _DienGiai);
                    _Ky = _NgayLap.Date.Month;
                    cm.Parameters.AddWithValue("@MaKy", _Ky);
                    #region BoSung Lap PhieuThu tu PhieuChi
                    if (_maChungTuPC != 0)
                        cm.Parameters.AddWithValue("@MaChungTuPC", _maChungTuPC);
                    else
                        cm.Parameters.AddWithValue("@MaChungTuPC", DBNull.Value);
                    #endregion// BoSung Lap PhieuThu tu PhieuChi
                    cm.ExecuteNonQuery();
                    _idSet = true;
                    _MaChungTu = (long)cm.Parameters["@MaChungTu"].Value;

                    _Tien.MaTienTe = _MaChungTu;
                    _Tien.ApplyEdit();
                    _Tien.Insert(tr);
                    UpdateChildren(tr);
                    this.MarkOld();
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
        //updatect  tranxem
        protected override void DataPortal_Update()
        {
            // save data into db
            SqlTransaction tr;
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                tr = cn.BeginTransaction();
                try
                {

                    using (SqlCommand cm = tr.Connection.CreateCommand())
                    {
                        cm.Transaction = tr;
                        cm.CommandType = CommandType.StoredProcedure;
                        cm.CommandText = "spd_Update_ChungTu";
                        cm.Parameters.AddWithValue("@MaBoPhanDangNhap", _maBoPhanDangNhap);
                        cm.Parameters.AddWithValue("@TenBoPhanDangNhap", ERP_Library.Security.CurrentUser.Info.TenBoPhan);
                        cm.Parameters.AddWithValue("@MaCongTy", _MaCongTy);
                        cm.Parameters.AddWithValue("@MaLoaiDoiTuong", _maLoaiDoiTuong);

                        cm.Parameters.AddWithValue("@MaChungTu", _MaChungTu);
                        cm.Parameters.AddWithValue("@SoTT", _SoTT);
                        cm.Parameters.AddWithValue("@SoChungTu", _SoChungTu);
                        cm.Parameters.AddWithValue("@NgayLap", _NgayLap.DBValue);
                        cm.Parameters.AddWithValue("@GhiMucNganSach", _GhiMucNganSach);
                        cm.Parameters.AddWithValue("@NgayThucHien", _NgayThucHien.DBValue);
                        cm.Parameters.AddWithValue("@GhiSoCai", _GhiSoCai);
                        cm.Parameters.AddWithValue("@MaNguoiLap", _NguoiLap);
                        if (_MaNhanVienLap != 0)
                            cm.Parameters.AddWithValue("@MaNhanVienLap", _MaNhanVienLap);
                        else
                            cm.Parameters.AddWithValue("@MaNhanVienLap", DBNull.Value);

                        if (_DoiTuong != 0)
                            cm.Parameters.AddWithValue("@MaDoiTuong", _DoiTuong);
                        else
                            cm.Parameters.AddWithValue("@MaDoiTuong", DBNull.Value);
                        if (_DinhKhoan.MaDinhKhoan == 0)
                        {
                            cm.Parameters.AddWithValue("@MaDinhKhoan", DBNull.Value);
                        }
                        else
                        {
                            cm.Parameters.AddWithValue("@MaDinhKhoan", _DinhKhoan.MaDinhKhoan);
                        }
                        cm.Parameters.AddWithValue("@LoaiChungTu", _iLoaiChungTu);
                        cm.Parameters.AddWithValue("@MaChungTuQL", _MaChungTuQL);
                        cm.Parameters.AddWithValue("@KhoaSo", _KhoaSo);
                        cm.Parameters.AddWithValue("@DienGiai", _DienGiai);
                        if (_MaDoiTuongThuChi != 0)
                            cm.Parameters.AddWithValue("@MaDoiTuongThuChi", _MaDoiTuongThuChi);
                        else
                            cm.Parameters.AddWithValue("@MaDoiTuongThuChi", DBNull.Value);
                        if (_MaPhuongThucThanhToan != 0)
                            cm.Parameters.AddWithValue("@MaPhuongThucThanhToan", _MaPhuongThucThanhToan);
                        else cm.Parameters.AddWithValue("@MaPhuongThucThanhToan", DBNull.Value);
                        cm.Parameters.AddWithValue("@SoChungTuKemTheo", _SoChungTuKemTheo);
                        cm.Parameters.AddWithValue("@ChungTuKemTheo", _ChungTuKemTheo);
                        if (_MaHoatDong != 0)
                            cm.Parameters.AddWithValue("@MaHoatDong", _MaHoatDong);
                        else cm.Parameters.AddWithValue("@MaHoatDong", DBNull.Value);
                        #region BoSung Lap PhieuThu tu PhieuChi
                        if (_maChungTuPC != 0)
                            cm.Parameters.AddWithValue("@MaChungTuPC", _maChungTuPC);
                        else
                            cm.Parameters.AddWithValue("@MaChungTuPC", DBNull.Value);
                        #endregion// BoSung Lap PhieuThu tu PhieuChi
                        if (_Tien.IsDirty == true)
                        {
                            _Tien.ApplyEdit();
                            _Tien.Update(tr);
                        }

                        if (_DinhKhoan.IsDirty == true)
                        {
                            _DinhKhoan.ApplyEdit();
                            _DinhKhoan.Update(tr);
                        }
                        int loaiThuChi = 0;
                        for (int i = 0; i < _DinhKhoan.ButToan.Count; i++)
                        {
                            //if (HeThongTaiKhoan1.GetHeThongTaiKhoan1(_DinhKhoan.ButToan[i].NoTaiKhoan).SoHieuTK.Contains("312") && HeThongTaiKhoan1.GetHeThongTaiKhoan1(_DinhKhoan.ButToan[i].NoTaiKhoan).SoHieuTK.StartsWith("312"))
                            if (PublicClass.KiemTraLaTaiKhoanTamUng(HeThongTaiKhoan1.GetHeThongTaiKhoan1(_DinhKhoan.ButToan[i].NoTaiKhoan).SoHieuTK))
                                loaiThuChi = 2;
                            //if (HeThongTaiKhoan1.GetHeThongTaiKhoan1(_DinhKhoan.ButToan[i].CoTaiKhoan).SoHieuTK.Contains("312") && HeThongTaiKhoan1.GetHeThongTaiKhoan1(_DinhKhoan.ButToan[i].CoTaiKhoan).SoHieuTK.StartsWith("312"))
                            if (PublicClass.KiemTraLaTaiKhoanTamUng(HeThongTaiKhoan1.GetHeThongTaiKhoan1(_DinhKhoan.ButToan[i].CoTaiKhoan).SoHieuTK))
                                loaiThuChi = 3;
                        }
                        foreach (TamUng tu in _TamUngList)
                        {
                            tu.LoaiThuChi = loaiThuChi;
                        }
                        _TamUngList.DataPortal_Update(tr, _MaChungTu, _SoChungTu);
                        if (_LoaiChungTu.MaLoaiCT != 16)
                        {
                            _chungTuTheoDoi.Update(tr, this);
                        }
                        //foreach (ChungTu_HoaDon ct_hd in _chungtu_HoaDonList)
                        //{
                        //    ct_hd.MaChungTu = _MaChungTu;
                        //}

                        _chungTu_ChiPhiSanXuatList.DataPortal_Update(tr, _MaChungTu, _SoChungTu, 0);

                        #region CapNhat ChungTu_DiaChi
                        #region Old
                        //if (_DoiTuong == 0)
                        //{
                        ////   _ChungTu_DiaChi.Update(tr);
                        //_ChungTu_DiaChi.MaChungTu = _MaChungTu;
                        //_ChungTu_DiaChi.ApplyEdit();
                        //_ChungTu_DiaChi.Insert(tr); // neu co roi` se la` insert
                        //}
                        //else
                        //{
                        //    _ChungTu_DiaChi.DeleteSelf(tr);
                        //}
                        #endregion//Old
                        #endregion//CapNhat ChungTu_DiaChi

                        UpdateChildren(tr);
                        cm.ExecuteNonQuery();
                        MarkOld();
                        tr.Commit();
                    }
                }
                catch (SqlException ee)
                {
                    tr.Rollback();
                    throw ee;
                }
            }
        } // Trang dang dung


        public void DataPortal_UpdateTranSacTion(SqlTransaction tr)
        {
            try
            {
                using (SqlCommand cm = tr.Connection.CreateCommand())
                {
                    cm.Transaction = tr;
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_Update_ChungTu";
                    cm.Parameters.AddWithValue("@MaChungTu", _MaChungTu);

                    cm.Parameters.AddWithValue("@MaBoPhanDangNhap", _maBoPhanDangNhap);
                    cm.Parameters.AddWithValue("@TenBoPhanDangNhap", ERP_Library.Security.CurrentUser.Info.TenBoPhan);
                    cm.Parameters.AddWithValue("@MaCongTy", _MaCongTy);
                    cm.Parameters.AddWithValue("@MaLoaiDoiTuong", _maLoaiDoiTuong);

                    cm.Parameters.AddWithValue("@SoTT", _SoTT);
                    cm.Parameters.AddWithValue("@SoChungTu", _SoChungTu);
                    cm.Parameters.AddWithValue("@NgayLap", _NgayLap.DBValue);
                    cm.Parameters.AddWithValue("@GhiMucNganSach", _GhiMucNganSach);
                    cm.Parameters.AddWithValue("@NgayThucHien", _NgayThucHien.DBValue);
                    cm.Parameters.AddWithValue("@GhiSoCai", _GhiSoCai);
                    cm.Parameters.AddWithValue("@MaNguoiLap", _NguoiLap);
                    if (_MaNhanVienLap != 0)
                        cm.Parameters.AddWithValue("@MaNhanVienLap", _MaNhanVienLap);
                    else
                        cm.Parameters.AddWithValue("@MaNhanVienLap", DBNull.Value);

                    if (_DoiTuong != 0)
                        cm.Parameters.AddWithValue("@MaDoiTuong", _DoiTuong);
                    else
                        cm.Parameters.AddWithValue("@MaDoiTuong", DBNull.Value);
                    if (_DinhKhoan.MaDinhKhoan == 0)
                    {
                        cm.Parameters.AddWithValue("@MaDinhKhoan", DBNull.Value);
                    }
                    else
                    {
                        cm.Parameters.AddWithValue("@MaDinhKhoan", _DinhKhoan.MaDinhKhoan);
                    }
                    cm.Parameters.AddWithValue("@LoaiChungTu", _iLoaiChungTu);
                    cm.Parameters.AddWithValue("@MaChungTuQL", _MaChungTuQL);
                    cm.Parameters.AddWithValue("@KhoaSo", _KhoaSo);
                    cm.Parameters.AddWithValue("@DienGiai", _DienGiai);
                    if (_MaDoiTuongThuChi != 0)
                        cm.Parameters.AddWithValue("@MaDoiTuongThuChi", _MaDoiTuongThuChi);
                    else
                        cm.Parameters.AddWithValue("@MaDoiTuongThuChi", DBNull.Value);
                    if (_MaPhuongThucThanhToan != 0)
                        cm.Parameters.AddWithValue("@MaPhuongThucThanhToan", _MaPhuongThucThanhToan);
                    else cm.Parameters.AddWithValue("@MaPhuongThucThanhToan", DBNull.Value);
                    cm.Parameters.AddWithValue("@SoChungTuKemTheo", _SoChungTuKemTheo);
                    cm.Parameters.AddWithValue("@ChungTuKemTheo", _ChungTuKemTheo);
                    if (_MaHoatDong != 0)
                        cm.Parameters.AddWithValue("@MaHoatDong", _MaHoatDong);
                    else cm.Parameters.AddWithValue("@MaHoatDong", DBNull.Value);
                    #region BoSung Lap PhieuThu tu PhieuChi
                    if (_maChungTuPC != 0)
                        cm.Parameters.AddWithValue("@MaChungTuPC", _maChungTuPC);
                    else
                        cm.Parameters.AddWithValue("@MaChungTuPC", DBNull.Value);
                    #endregion// BoSung Lap PhieuThu tu PhieuChi
                    if (_Tien.IsDirty == true)
                    {
                        _Tien.ApplyEdit();
                        _Tien.Update(tr);
                    }

                    if (_butToanList.IsDirty == true)
                    {
                        _DinhKhoan.ApplyEdit();
                        _DinhKhoan.Update(tr);
                        _butToanList._MaDinhKhoan = _DinhKhoan.MaDinhKhoan;
                        _butToanList.DataPortal_Update(tr);
                    }

                    UpdateChildren(tr);
                    cm.ExecuteNonQuery();
                    MarkOld();

                }
            }
            catch (SqlException ee)
            {

                throw ee;
            }
        }

        protected override void DataPortal_Delete(object criteria)
        {
            Criteria crit = (Criteria)criteria;
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_Delete_ChungTu";
                    cm.Parameters.AddWithValue("@MaChungTu", _MaChungTu);
                    cm.ExecuteNonQuery();
                }
            }
        }

        protected override void DataPortal_DeleteSelf()
        {
            DataPortal_Delete(new Criteria(_MaChungTu));
        }

        #endregion

        private void UpdateChildren(SqlTransaction tr)
        {
            if (_BoSungChungTu.IsNew)
                _BoSungChungTu.Insert(tr, this);
            else _BoSungChungTu.Update(tr, this);

            _chungTu_DeNghiChuyenKhoan.Update(tr, this);
            _chungTu_GiayBaoCoList.Update(tr, this);
            _chungTu_GiayBanNgoaiTeChildList.Update(tr, this);
            _chungTu_LenhChuyenTienNNChildList.Update(tr, this);
            _chungTu_GiayRutTienChildList.Update(tr, this);
            _chungTu_UyNhiemChiChildList.Update(tr, this);

            //UpdateSoChungTuTienMat();
            _phieuThutuPhieuChiList.Update(tr, this);
            _CT_ChungTuBienLaiList.Update(tr, this);
            _chungTu_HoaDonThanhToanList.Update(tr, this);
            _ChungTu_ChungTuList.Update(tr, this);

            #region CapNhat ChungTu_DiaChi
            if (_ChungTu_DiaChi.IsNew)
            {
                _ChungTu_DiaChi.MaChungTu = _MaChungTu;
                _ChungTu_DiaChi.ApplyEdit();
                _ChungTu_DiaChi.Insert(tr);
            }
            else if (_ChungTu_DiaChi.IsDirty)
            {
                _ChungTu_DiaChi.ApplyEdit();
                _ChungTu_DiaChi.Update(tr);
            }

            #endregion//CapNhat ChungTu_DiaChi
        }

        #region Phuong Thuc Kiem Tra
        public static Boolean KiemTraSoChungTu(string SoChungTu, ChungTu _ChungTu)
        {
            int count = 0;
            Boolean kq = false;
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    //cm.CommandText = "select count(*) from tblChungTu where SoChungTu = '" + SoChungTu + "'";
                    cm.CommandText = "spd_KiemSoChungTu";
                    cm.Parameters.AddWithValue("@SoChungTu", SoChungTu);
                    cm.Parameters.AddWithValue("@MaChungTu", _ChungTu.MaChungTu);
                    cm.Parameters.AddWithValue("@UserID", ERP_Library.Security.CurrentUser.Info.UserID);
                    //cm.c
                    count = (int)cm.ExecuteScalar();
                }
            }
            // if (count == 1 && _ChungTu.IsNew ==true)
            if (count == 1)
            {
                kq = true;
            }
            return kq;
        }
        public static string KiemTraSoChungTuMoiNhat(int LoaiPhieu, int loaiNT, int nam)
        {

            string kq = "";
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    //cm.CommandText = "select count(*) from tblChungTu where SoChungTu = '" + SoChungTu + "'";
                    cm.CommandText = "spd_laySoChungTuMoiNhat";
                    cm.Parameters.AddWithValue("@LoaiPhieu", LoaiPhieu);
                    //if (ERP_Library.Security.CurrentUser.Info.MaBoPhan != 9)
                    //{
                    //    cm.Parameters.AddWithValue("@MaNguoiLap", ERP_Library.Security.CurrentUser.Info.UserID);
                    //}
                    //if (ERP_Library.Security.CurrentUser.Info.MaBoPhan == 9 && (LoaiPhieu == 2 || LoaiPhieu == 3))
                    //{
                    //    cm.Parameters.AddWithValue("@MaNguoiLap", ERP_Library.Security.CurrentUser.Info.UserID);
                    //}
                    //else
                    //{
                    cm.Parameters.AddWithValue("@MaNguoiLap", ERP_Library.Security.CurrentUser.Info.UserID);
                    //}
                    cm.Parameters.AddWithValue("@LoaiNT", loaiNT);
                    cm.Parameters.AddWithValue("@Nam", nam);
                    //cm.c
                    int so = 0;
                    so = (int)cm.ExecuteScalar();
                    so++;
                    kq = so.ToString();
                }
            }


            return kq;
        }


        #endregion

        #region kiem tra khoa so hay chua?
        public static Boolean KiemTraKhoaSo(DateTime _NgayLap)
        {
            Boolean khoaSo = false;
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_KiemTraKhoaSo";
                    cm.Parameters.AddWithValue("@NgayLap", _NgayLap);
                    cm.Parameters.AddWithValue("@KhoaSo", khoaSo).Direction = ParameterDirection.Output;
                    cm.ExecuteScalar();
                    khoaSo = Convert.ToBoolean(cm.Parameters["@KhoaSo"].Value);
                }
            }
            return khoaSo;
        }

        #endregion

        #region kiem tra Số chứng từ bị thiếu?
        public static string KiemTraSoChungTuBiThieu(int MaBoPhanDangNhap, int MaLoaiChungTu, int Nam)
        {
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "fnc_ChungTuBiThieu";
                    cm.Parameters.AddWithValue("@BoPhanDangNhap", MaBoPhanDangNhap);
                    cm.Parameters.AddWithValue("@MaLoaiChungTu", MaLoaiChungTu);
                    cm.Parameters.AddWithValue("@Nam", Nam);
                    cm.ExecuteNonQuery();
                }
                return "";
            }

        }

        #endregion

        #region Cập nhật số chứng từ cho Lương, Phụ Cấp, Thù Lao tiền mặt
        //private void UpdateSoChungTuTienMat()
        //{
        //    //Thù lao
        //    foreach (ThuLaoChuongTrinh item in _thuLaoChuongTrinhList)
        //    {
        //        item.MaPhieuChi = _SoChungTu;
        //        item.SoChungTu = _SoChungTu;
        //        item.MaChungTu = MaChungTu;
        //    }

        //    //Phụ cấp
        //    foreach (PhuCapNhanVien item in _phuCapNhanVienList)
        //    {
        //        item.MaPhieuChi = _SoChungTu;
        //    }

        //    //Lương kỳ 1
        //    foreach (BangLuongKyI item in _bangluongKy1List)
        //    {
        //        item.MaPhieuChi = _MaChungTu;
        //    }

        //    //Lương Kỳ 2
        //    foreach (BangLuongKyII item in _bangluongKy2List)
        //    {
        //        item.MaPhieuChi = _MaChungTu;
        //    }

        //    //Tiền lương
        //    //Lưu lại chứng từ phụ cấp và chương trình
        //    _phuCapNhanVienList.Save();
        //    _thuLaoChuongTrinhList.Save();
        //    _bangluongKy1List.Save();
        //    _bangluongKy2List.Save();
        //}

        //public void XoaSoChungTuTienMat()
        //{

        //    //Thù lao
        //    foreach (ThuLaoChuongTrinh item in _thuLaoChuongTrinhList)
        //    {
        //        item.MaPhieuChi = string.Empty;
        //        item.SoChungTu = string.Empty;
        //        item.MaChungTu = 0;
        //    }

        //    //Phụ cấp
        //    foreach (PhuCapNhanVien item in _phuCapNhanVienList)
        //    {
        //        item.MaPhieuChi = string.Empty;
        //    }

        //    //Tiền lương
        //    //Lương kỳ 1
        //    foreach (BangLuongKyI item in _bangluongKy1List)
        //    {
        //        item.MaPhieuChi = 0;
        //    }

        //    //Lương Kỳ 2
        //    foreach (BangLuongKyII item in _bangluongKy2List)
        //    {
        //        item.MaPhieuChi = 0;
        //    }
        //    //Lưu lại chứng từ phụ cấp và chương trình
        //    _phuCapNhanVienList.ApplyEdit();
        //    _thuLaoChuongTrinhList.ApplyEdit();
        //    _bangluongKy1List.ApplyEdit();
        //    _bangluongKy2List.ApplyEdit();
        //    _phuCapNhanVienList.Save();
        //    _thuLaoChuongTrinhList.Save();
        //    _bangluongKy1List.Save();
        //    _bangluongKy2List.Save();
        //}
        #endregion

        public static void CapNhapLaiSoChungTuTangLienTiepTuNgay(int maLoaiChungTu, DateTime tungay)
        {
            //if (BoPhan.GetBoPhan(ERP_Library.Security.CurrentUser.Info.MaBoPhan).MaBoPhanQL != "DV02")//Không là Trung Tâm Tin Tức
            //{
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_CapNhatSoChungTuTangLienTiepTuNgay";
                    cm.Parameters.AddWithValue("@MaLoaiChungTu", maLoaiChungTu);
                    cm.Parameters.AddWithValue("@TuNgay", tungay);
                    cm.Parameters.AddWithValue("@MaNguoiLap", ERP_Library.Security.CurrentUser.Info.UserID);
                    cm.ExecuteNonQuery();
                }
            }
            //}
        }

        //copy ra chung tu moi
        public static ChungTu DuplicateChungTu(ChungTu _chungTuCanDeCopy, int maLoaiChungTu)
        { 
            //Khởi tạo chứng từ mới           
            ChungTu chungTuMoi = ChungTu.NewChungTu();
            if (_chungTuCanDeCopy != null)
            {
                if (_chungTuCanDeCopy.MaChungTu != 0)
                {
                    //Lấy dữ liệu cho tiền tệ dựa vào chứng từ copy
                    TienTe tienTe = TienTe.GetTienTe(_chungTuCanDeCopy.MaChungTu);
                    
                    //Lấy dữ liệu cho chứng từ mới
                    chungTuMoi.MaDoiTuongThuChi = _chungTuCanDeCopy.MaDoiTuongThuChi;
                    chungTuMoi.NgayLap = DateTime.Now.Date;
                    chungTuMoi.NgayThucHien = DateTime.Now.Date;
                    //chungTuMoi.NgayLapString = (_chungTuCanDeCopy.NgayLapString + "") == "" ? "" : DateTime.Now.Date.ToString("dd/MM/yyyy");
                    if (maLoaiChungTu == 7 || maLoaiChungTu == 24 || maLoaiChungTu == 14)
                    {
                        chungTuMoi.NgayLapString = "";
                    }

                    chungTuMoi.DienGiai = _chungTuCanDeCopy.DienGiai;
                    chungTuMoi.SoChungTuKemTheo = _chungTuCanDeCopy.SoChungTuKemTheo;
                    chungTuMoi.LoaiChungTu = _chungTuCanDeCopy.LoaiChungTu;
                    chungTuMoi.DoiTuong = _chungTuCanDeCopy.DoiTuong;
                    chungTuMoi.MaPhuongThucThanhToan = _chungTuCanDeCopy.MaPhuongThucThanhToan;
                    chungTuMoi.NguoiLap = ERP_Library.Security.CurrentUser.Info.UserID;


                    chungTuMoi.ChungTu_DiaChi.Ten = _chungTuCanDeCopy.ChungTu_DiaChi.Ten;
                    chungTuMoi.ChungTu_DiaChi.DiaChi = _chungTuCanDeCopy.ChungTu_DiaChi.DiaChi;

                    chungTuMoi.BoSungChungTuKT.MaTaiKhoanNH = _chungTuCanDeCopy.BoSungChungTuKT.MaTaiKhoanNH;
                    chungTuMoi.BoSungChungTuKT.MaTaiKhoanNHDoiTac = _chungTuCanDeCopy.BoSungChungTuKT.MaTaiKhoanNHDoiTac;
                    chungTuMoi.BoSungChungTuKT.MaTaiKhoanNHGiaoDich = _chungTuCanDeCopy.BoSungChungTuKT.MaTaiKhoanNHGiaoDich;
                    chungTuMoi.BoSungChungTuKT.MaNganHangTrungGian = _chungTuCanDeCopy.BoSungChungTuKT.MaNganHangTrungGian;
                    chungTuMoi.BoSungChungTuKT.LoaiChuyenTienNN = _chungTuCanDeCopy.BoSungChungTuKT.LoaiChuyenTienNN;
                    chungTuMoi.BoSungChungTuKT.LoaiPhiChuyenTienNN = _chungTuCanDeCopy.BoSungChungTuKT.LoaiPhiChuyenTienNN;
                    chungTuMoi.BoSungChungTuKT.MucDichMuaNgoaiTe = _chungTuCanDeCopy.BoSungChungTuKT.MucDichMuaNgoaiTe;
                    chungTuMoi.BoSungChungTuKT.NDMucDichMuaNgoaiTe = _chungTuCanDeCopy.BoSungChungTuKT.NDMucDichMuaNgoaiTe;
                    chungTuMoi.BoSungChungTuKT.PhuongThucMuaNgoaiTe = _chungTuCanDeCopy.BoSungChungTuKT.PhuongThucMuaNgoaiTe;
                    chungTuMoi.BoSungChungTuKT.TenNganHang = _chungTuCanDeCopy.BoSungChungTuKT.TenNganHang;
                    chungTuMoi.BoSungChungTuKT.TenNganHangDoiTac = _chungTuCanDeCopy.BoSungChungTuKT.TenNganHangDoiTac;


                    chungTuMoi.SoChungTu = PublicClass.SetSoChungTuByMaLoaiChungTu(maLoaiChungTu, DateTime.Now.Date);
                    //--End  

                    chungTuMoi.Tien.SoTien = tienTe.SoTien;
                    chungTuMoi.Tien.ThanhTien = tienTe.ThanhTien;
                    chungTuMoi.Tien.TiGiaQuyDoi = tienTe.TiGiaQuyDoi;
                    chungTuMoi.Tien.VietBangChu = tienTe.VietBangChu;
                    chungTuMoi.Tien.MaLoaiTien = tienTe.MaLoaiTien;

                    chungTuMoi.DinhKhoan.LaMotNoNhieuCo = _chungTuCanDeCopy.DinhKhoan.LaMotNoNhieuCo;
                    chungTuMoi.DinhKhoan.NoCo = _chungTuCanDeCopy.DinhKhoan.NoCo;
                    chungTuMoi.DinhKhoan.GhiMucNganSach = _chungTuCanDeCopy.DinhKhoan.GhiMucNganSach;

                    //chung tu hoa don thanh toan
                    if (maLoaiChungTu == 9 || maLoaiChungTu == 16)
                    {
                        foreach (ChungTu_HoaDonThanhToan item in _chungTuCanDeCopy.ChungTu_HoaDonThanhToanList)
                        {
                            ChungTu_HoaDonThanhToan ct_hdtt = ChungTu_HoaDonThanhToan.NewChungTu_HoaDonThanhToan();
                            ct_hdtt.HoaDon.SoSerial = item.HoaDon.SoSerial;
                            ct_hdtt.HoaDon.GhiChu = item.HoaDon.GhiChu;
                            ct_hdtt.HoaDon.MauHoaDon = item.HoaDon.MauHoaDon;
                            ct_hdtt.HoaDon.KyHieuMauHoaDon = item.HoaDon.KyHieuMauHoaDon;
                            ct_hdtt.HoaDon.NgayLap = item.HoaDon.NgayLap;
                            ct_hdtt.HoaDon.ThueSuatVAT = item.HoaDon.ThueSuatVAT;
                            ct_hdtt.HoaDon.MaDoiTac = item.HoaDon.MaDoiTac;
                            ct_hdtt.HoaDon.KhauTruThue = item.HoaDon.KhauTruThue;
                            ct_hdtt.HoaDon.LoaiHoaDon = item.HoaDon.LoaiHoaDon;
                            ct_hdtt.HoaDon.SoHoaDon = item.HoaDon.SoHoaDon;
                            ct_hdtt.HoaDon.ThanhTien = item.HoaDon.ThanhTien;                            
                            ct_hdtt.HoaDon.TongTien = item.HoaDon.TongTien;
                            ct_hdtt.HoaDon.ThueVAT = item.HoaDon.ThueVAT;
                            ct_hdtt.HoaDon.SoTienThanhToan = item.HoaDon.SoTienThanhToan;
                            chungTuMoi.ChungTu_HoaDonThanhToanList.Add(ct_hdtt);
                        }
                    }

                    //Lấy dữ liệu bút toán mới
                    foreach (ButToan item in _chungTuCanDeCopy.DinhKhoan.ButToan)
                    {
                        ButToan butToanMoi = ButToan.NewButToan();
                        butToanMoi.NoTaiKhoan = item.NoTaiKhoan;
                        butToanMoi.CoTaiKhoan = item.CoTaiKhoan;
                        if (maLoaiChungTu == 9 || maLoaiChungTu == 16)
                        {
                            //butToanMoi.SoTien = 0;
                            butToanMoi.SoTien = item.SoTien;    //sua theo yeu cau Thuong 2019.07.16
                        }
                        else
                        {
                            butToanMoi.SoTien = item.SoTien;
                        }                        
                        butToanMoi.DienGiai = item.DienGiai;
                        butToanMoi.DoiTuongCo = item.DoiTuongCo;
                        butToanMoi.DoiTuongNo = item.DoiTuongNo;
                        butToanMoi.MaSoQuy = item.MaSoQuy;
                        butToanMoi.MaNhanVien = item.MaNhanVien;
                        butToanMoi.MaDonVi = item.MaDonVi;
                        butToanMoi.IDKhoanMuc = item.IDKhoanMuc;
                        
                        //Lấy bút toán chi phí sản xuất
                        foreach (ChungTu_ChiPhiSanXuat chungTu_ChiPhiSanXuat in item.ChungTuChiPhiSanXuatList)
                        {
                            ChungTu_ChiPhiSanXuat chungTu_ChiPhiSanXuatMoi = ChungTu_ChiPhiSanXuat.NewChungTu_ChiPhiSanXuat();
                            chungTu_ChiPhiSanXuatMoi.SoChungTu = chungTuMoi.SoChungTu;
                            chungTu_ChiPhiSanXuatMoi.MaChuongTrinh = chungTu_ChiPhiSanXuat.MaChuongTrinh;
                            chungTu_ChiPhiSanXuat.TenChuongTrinh = chungTu_ChiPhiSanXuat.TenChuongTrinh;
                            chungTu_ChiPhiSanXuatMoi.SoTien = chungTu_ChiPhiSanXuat.SoTien;
                            chungTu_ChiPhiSanXuat.MaLoaiChiPhi = chungTu_ChiPhiSanXuat.MaLoaiChiPhi;
                            chungTu_ChiPhiSanXuatMoi.MaTaiKhoan = chungTu_ChiPhiSanXuat.MaTaiKhoan;
                            chungTu_ChiPhiSanXuatMoi.IsUpdate = chungTu_ChiPhiSanXuat.IsUpdate;

                            //Lấy chi thù lao
                            foreach (ChiThuLao chiThuLao in chungTu_ChiPhiSanXuat.ChiThuLaoList)
                            {
                                ChiThuLao chiThuLaoMoi = ChiThuLao.NewChiThuLao();
                                chiThuLaoMoi.MaChungTu = chungTuMoi.MaChungTu;
                                chiThuLaoMoi.SoChungTu = chungTuMoi.SoChungTu;
                                chiThuLaoMoi.MaBoPhanGui = chiThuLao.MaBoPhanGui;
                                chiThuLaoMoi.MaBoPhanNhan = chiThuLao.MaBoPhanNhan;
                                chiThuLaoMoi.SoTien = chiThuLao.SoTien;
                                chiThuLaoMoi.GhiChu = chiThuLao.GhiChu;
                                chiThuLaoMoi.HoanTat = chiThuLao.HoanTat;
                                chiThuLaoMoi.TenBoPhanGui = chiThuLao.TenBoPhanGui;
                                chiThuLaoMoi.TenBoPhanNhan = chiThuLao.TenBoPhanNhan;
                                chiThuLaoMoi.MaChuongTrinh = chiThuLao.MaChuongTrinh;
                                chiThuLaoMoi.TenChuongTrinh = chiThuLao.TenChuongTrinh;
                                chiThuLaoMoi.SoTienDaNhap = chiThuLao.SoTienDaNhap;
                                chiThuLaoMoi.SoTienDaNhapNgoaiDai = chiThuLao.SoTienDaNhapNgoaiDai;
                                chiThuLaoMoi.SoTienConLai = chiThuLao.SoTienConLai;
                                chiThuLaoMoi.NgayLap = DateTime.Now.Date;
                                chiThuLaoMoi.SoTienSeNhap = chiThuLao.SoTienSeNhap;
                                chiThuLaoMoi.SoTienSeNhapNgoaiDai = chiThuLao.SoTienSeNhapNgoaiDai;
                                chiThuLaoMoi.NguoiLap = ERP_Library.Security.CurrentUser.Info.UserID;
                                chiThuLaoMoi.MaLoaiKinhPhi = chiThuLao.MaLoaiKinhPhi;
                                chiThuLaoMoi.SoTienSeNhapNgoaiDai = chiThuLao.SoTienSeNhapNgoaiDai;
                                chiThuLaoMoi.NgayThucHienChi = chiThuLao.NgayThucHienChi;
                                chiThuLaoMoi.MaTaiKhoan = chiThuLao.MaTaiKhoan;

                                //Lấy chi thù lao nhân viên
                                foreach (ChiThuLao_NhanVien chiThuLao_NhanVien in chiThuLao.ChiThuLaoNhanVienList)
                                {
                                    ChiThuLao_NhanVien chiThuLao_NhanVienMoi = ChiThuLao_NhanVien.NewChiThuLao_NhanVien();
                                    chiThuLao_NhanVienMoi.MabophanNv = chiThuLao_NhanVien.MabophanNv;
                                    chiThuLao_NhanVienMoi.MaNhanVien = chiThuLao_NhanVien.MaNhanVien;
                                    chiThuLao_NhanVienMoi.SoTien = chiThuLao_NhanVien.SoTien;
                                    chiThuLao_NhanVienMoi.TenBoPhan = chiThuLao_NhanVien.TenBoPhan;
                                    chiThuLao_NhanVienMoi.TenNhanVien = chiThuLao_NhanVien.TenNhanVien;
                                    chiThuLao_NhanVienMoi.LoaiNV = chiThuLao_NhanVien.LoaiNV;

                                    chiThuLaoMoi.ChiThuLaoNhanVienList.Add(chiThuLao_NhanVienMoi);

                                }
                                chungTu_ChiPhiSanXuatMoi.ChiThuLaoList.Add(chiThuLaoMoi);
                            }
                            //Lấy chi phí thực hiện
                            foreach (ChiPhiThucHien chiPhiThucHien in chungTu_ChiPhiSanXuat.ChiPhiThucHienList)
                            {
                                ChiPhiThucHien chiPhiThucHienMoi = ChiPhiThucHien.NewChiPhiThucHien();
                                chiPhiThucHienMoi.TenChungTu = chungTuMoi.SoChungTu;
                                chiPhiThucHienMoi.TenChuongTrinh = chiPhiThucHien.TenChuongTrinh;
                                chiPhiThucHienMoi.MaChuongTrinh = chiPhiThucHien.MaChuongTrinh;
                                chiPhiThucHienMoi.MaDoiTuong = chiPhiThucHien.MaDoiTuong;
                                chiPhiThucHienMoi.TenDoiTuong = chiPhiThucHien.TenDoiTuong;
                                chiPhiThucHienMoi.DiaChi = chiPhiThucHien.DiaChi;
                                chiPhiThucHienMoi.SoTien = chiPhiThucHien.SoTien;
                                chiPhiThucHienMoi.DienGiai = chiPhiThucHien.DienGiai;
                                chiPhiThucHienMoi.NgayLap = DateTime.Now.Date;
                                chiPhiThucHienMoi.NguoiLap = ERP_Library.Security.CurrentUser.Info.UserID;
                                chiPhiThucHienMoi.MaLoaiChiPhiSanXuat = chiPhiThucHien.MaLoaiChiPhiSanXuat;

                                chungTu_ChiPhiSanXuatMoi.ChiPhiThucHienList.Add(chiPhiThucHienMoi);
                            }

                            //Lấy bút toán mục ngân sách
                            foreach (ButToanMucNganSach butToanMucNganSach in chungTu_ChiPhiSanXuat.ButtoanMucNganSachList)
                            {
                                ButToanMucNganSach butToanMucNganSachMoi = ButToanMucNganSach.NewButToanMucNganSach();
                                butToanMucNganSachMoi.MaTieuMucNganSach = butToanMucNganSach.MaTieuMucNganSach;
                                butToanMucNganSachMoi.SoTien = butToanMucNganSach.SoTien;
                                butToanMucNganSachMoi.DienGiai = butToanMucNganSach.DienGiai;
                                chungTu_ChiPhiSanXuatMoi.ButtoanMucNganSachList.Add(butToanMucNganSachMoi);
                            }

                            butToanMoi.ChungTuChiPhiSanXuatList.Add(chungTu_ChiPhiSanXuatMoi);
                        }

                        //Lấy chứng từ hóa đơn
                        foreach (ChungTu_HoaDon chungTu_HoaDon in item.ChungTu_HoaDonList)
                        {
                            ChungTu_HoaDon chungTu_HoaDonMoi = ChungTu_HoaDon.NewChungTu_HoaDon();
                            chungTu_HoaDonMoi.MaHoaDon = chungTu_HoaDon.MaHoaDon;
                            chungTu_HoaDonMoi.MaPhieuNhapXuat = chungTu_HoaDon.MaPhieuNhapXuat;
                            chungTu_HoaDonMoi.SoTien = chungTu_HoaDon.SoTien;
                            chungTu_HoaDonMoi.NgayLap = DateTime.Now.Date;
                            chungTu_HoaDonMoi.NguoiLap = ERP_Library.Security.CurrentUser.Info.UserID;

                            butToanMoi.ChungTu_HoaDonList.Add(chungTu_HoaDonMoi);
                        }

                        chungTuMoi.DinhKhoan.ButToan.Add(butToanMoi);
                    }

                }
            }
            return chungTuMoi;
        }



        public static void DeleteChungTu_ByDeleteHoaDon(ChungTu _ct, SqlTransaction _tr)
        {
            SqlTransaction tr = _tr;
            try
            {
                _ct.TamUngList.DataPortal_Delete(tr);
                ChungTu_TheoDoi.Dataportal_Delete(tr, _ct.MaChungTu);

                _ct.ChungTuChiPhiSanXuatList.DataPortal_Delete(tr);
                _ct.Tien.DataPortal_Delete(tr);
                _ct.BoSungChungTuKT.DataPortal_Delete(tr);
                _ct.ChungTu_DiaChi.DeleteSelf(tr);
                _ct.ChungTuDeNghiList.DataPortal_Delete(tr);
                _ct.ChungTuGiayBaoCoList.DataPortal_Delete(tr);
                _ct.ChungTuGiayBanNgoaiTe.DataPortal_Delete(tr);
                _ct.ChungTuLenhChuyenTienList.DataPortal_Delete(tr);
                _ct.ChungTuGiayRutTienList.DataPortal_Delete(tr);
                _ct.ChungTuUyNhiemChiList.DataPortal_Delete(tr);
                _ct.PhieuThutuPhieuChiList.DataPortal_Delete(tr);
                _ct.CT_ChungTuBienLaiList.Clear();
                _ct.CT_ChungTuBienLaiList.Update(tr, _ct);
                //_ct.ChungTu_HoaDonThanhToanList.Clear();
                //_ct.ChungTu_HoaDonThanhToanList.Update(tr, _ct);
                _ct.ChungTu_ChungList.Clear();
                _ct.ChungTu_ChungList.Update(tr, _ct);

                //  _ct.XoaSoChungTuTienMat();

                using (SqlCommand cm = tr.Connection.CreateCommand())
                {
                    cm.Transaction = tr;
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_Delete_ChungTu";
                    cm.Parameters.AddWithValue("@MaChungTu", _ct.MaChungTu);
                    cm.ExecuteNonQuery();

                }
                _ct.DinhKhoan.DataPortal_Delete(tr);

            }
            catch (SqlException ex)
            {
                tr.Rollback();
                throw ex;
            }
        }


    }
}
