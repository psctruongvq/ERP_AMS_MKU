using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{
    [Serializable()]
    public class Default_Ngay : Csla.BusinessBase<Default_Ngay>
    {
        #region Business Properties and Methods

        //declare members
        private int _maNgay = 0;
        private double _soCongTinhChuyenCan = 0;
        private decimal _soNgayPhepNamTrongNam = 0;
        private int _soNgayLamViecTrongThang = 0;
        private double _heSoKhiLamCaDem = 0;
        private short _nghiLonHonMayNgayTruLuong = 0;
        private decimal _phanTramBHXH = 0;
        private decimal _phanTramBHYT = 0;
        private decimal _tienCongDoan = 0;
        private decimal _phuCapConNho = 0;
        private byte _tuoiConHuongPhuCap = 0;
        private double _soGioGianCa = 0;
        private decimal _tienHocViec = 0;
        private decimal _tienThuViec = 0;
        private decimal _phuCapNhaO = 0;
        private decimal _phuCapThamNien = 0;
        private decimal _phuCapThamNienTangThem1Nam = 0;
        private decimal _phucapChuyenCan = 0;
        private bool _truBaoHiemTruocKhiTinhThue = false;
        private decimal _luongCoBan = 0;
        private decimal _soGioTangCaToiDa = 0;
        private decimal _coGianTG = 0;
        private decimal _tranBHXHNamNay = 0;
        private decimal _tranBHXHNamTruoc = 0;
        private decimal _soTienGiamTruBanThan = 0;
        private decimal _luongNoiBo = 0;
        private decimal _soGioTrongNgay = 0;
        private decimal _phuCapTienAn = 0;
        private decimal _phuCapHanhChinh = 0;
        private decimal _phanTramThueThuLaoKhenThuong = 0;
        private decimal _phanTramBHTN = 0;
        private decimal _phanTramCongDoan = 0;
        private decimal _tongSoGioNgoaiGio = 0;
        private SmartDate _ngayApDung = new SmartDate(DateTime.Today);
        private decimal _soTienAnTruaKhongTinhThue = 0;

        [System.ComponentModel.DataObjectField(true, true)]
        public int MaNgay
        {
            get
            {
                CanReadProperty("MaNgay", true);
                return _maNgay;
            }
        }

        public double SoCongTinhChuyenCan
        {
            get
            {
                CanReadProperty("SoCongTinhChuyenCan", true);
                return _soCongTinhChuyenCan;
            }
            set
            {
                CanWriteProperty("SoCongTinhChuyenCan", true);
                if (!_soCongTinhChuyenCan.Equals(value))
                {
                    _soCongTinhChuyenCan = value;
                    PropertyHasChanged("SoCongTinhChuyenCan");
                }
            }
        }

        public decimal SoNgayPhepNamTrongNam
        {
            get
            {
                CanReadProperty("SoNgayPhepNamTrongNam", true);
                return _soNgayPhepNamTrongNam;
            }
            set
            {
                CanWriteProperty("SoNgayPhepNamTrongNam", true);
                if (!_soNgayPhepNamTrongNam.Equals(value))
                {
                    _soNgayPhepNamTrongNam = value;
                    PropertyHasChanged("SoNgayPhepNamTrongNam");
                }
            }
        }

        public int SoNgayLamViecTrongThang
        {
            get
            {
                CanReadProperty("SoNgayLamViecTrongThang", true);
                return _soNgayLamViecTrongThang;
            }
            set
            {
                CanWriteProperty("SoNgayLamViecTrongThang", true);
                if (!_soNgayLamViecTrongThang.Equals(value))
                {
                    _soNgayLamViecTrongThang = value;
                    PropertyHasChanged("SoNgayLamViecTrongThang");
                }
            }
        }

        public double HeSoKhiLamCaDem
        {
            get
            {
                CanReadProperty("HeSoKhiLamCaDem", true);
                return _heSoKhiLamCaDem;
            }
            set
            {
                CanWriteProperty("HeSoKhiLamCaDem", true);
                if (!_heSoKhiLamCaDem.Equals(value))
                {
                    _heSoKhiLamCaDem = value;
                    PropertyHasChanged("HeSoKhiLamCaDem");
                }
            }
        }

        public short NghiLonHonMayNgayTruLuong
        {
            get
            {
                CanReadProperty("NghiLonHonMayNgayTruLuong", true);
                return _nghiLonHonMayNgayTruLuong;
            }
            set
            {
                CanWriteProperty("NghiLonHonMayNgayTruLuong", true);
                if (!_nghiLonHonMayNgayTruLuong.Equals(value))
                {
                    _nghiLonHonMayNgayTruLuong = value;
                    PropertyHasChanged("NghiLonHonMayNgayTruLuong");
                }
            }
        }

        public decimal PhanTramBHXH
        {
            get
            {
                CanReadProperty("PhanTramBHXH", true);
                return _phanTramBHXH;
            }
            set
            {
                CanWriteProperty("PhanTramBHXH", true);
                if (!_phanTramBHXH.Equals(value))
                {
                    _phanTramBHXH = value;
                    PropertyHasChanged("PhanTramBHXH");
                }
            }
        }

        public decimal PhanTramBHYT
        {
            get
            {
                CanReadProperty("PhanTramBHYT", true);
                return _phanTramBHYT;
            }
            set
            {
                CanWriteProperty("PhanTramBHYT", true);
                if (!_phanTramBHYT.Equals(value))
                {
                    _phanTramBHYT = value;
                    PropertyHasChanged("PhanTramBHYT");
                }
            }
        }

        public decimal TienCongDoan
        {
            get
            {
                CanReadProperty("TienCongDoan", true);
                return _tienCongDoan;
            }
            set
            {
                CanWriteProperty("TienCongDoan", true);
                if (!_tienCongDoan.Equals(value))
                {
                    _tienCongDoan = value;
                    PropertyHasChanged("TienCongDoan");
                }
            }
        }

        public decimal PhuCapConNho
        {
            get
            {
                CanReadProperty("PhuCapConNho", true);
                return _phuCapConNho;
            }
            set
            {
                CanWriteProperty("PhuCapConNho", true);
                if (!_phuCapConNho.Equals(value))
                {
                    _phuCapConNho = value;
                    PropertyHasChanged("PhuCapConNho");
                }
            }
        }

        public byte TuoiConHuongPhuCap
        {
            get
            {
                CanReadProperty("TuoiConHuongPhuCap", true);
                return _tuoiConHuongPhuCap;
            }
            set
            {
                CanWriteProperty("TuoiConHuongPhuCap", true);
                if (!_tuoiConHuongPhuCap.Equals(value))
                {
                    _tuoiConHuongPhuCap = value;
                    PropertyHasChanged("TuoiConHuongPhuCap");
                }
            }
        }

        public double SoGioGianCa
        {
            get
            {
                CanReadProperty("SoGioGianCa", true);
                return _soGioGianCa;
            }
            set
            {
                CanWriteProperty("SoGioGianCa", true);
                if (!_soGioGianCa.Equals(value))
                {
                    _soGioGianCa = value;
                    PropertyHasChanged("SoGioGianCa");
                }
            }
        }

        public decimal TienHocViec
        {
            get
            {
                CanReadProperty("TienHocViec", true);
                return _tienHocViec;
            }
            set
            {
                CanWriteProperty("TienHocViec", true);
                if (!_tienHocViec.Equals(value))
                {
                    _tienHocViec = value;
                    PropertyHasChanged("TienHocViec");
                }
            }
        }

        public decimal TienThuViec
        {
            get
            {
                CanReadProperty("TienThuViec", true);
                return _tienThuViec;
            }
            set
            {
                CanWriteProperty("TienThuViec", true);
                if (!_tienThuViec.Equals(value))
                {
                    _tienThuViec = value;
                    PropertyHasChanged("TienThuViec");
                }
            }
        }

        public decimal PhuCapNhaO
        {
            get
            {
                CanReadProperty("PhuCapNhaO", true);
                return _phuCapNhaO;
            }
            set
            {
                CanWriteProperty("PhuCapNhaO", true);
                if (!_phuCapNhaO.Equals(value))
                {
                    _phuCapNhaO = value;
                    PropertyHasChanged("PhuCapNhaO");
                }
            }
        }

        public decimal PhuCapThamNien
        {
            get
            {
                CanReadProperty("PhuCapThamNien", true);
                return _phuCapThamNien;
            }
            set
            {
                CanWriteProperty("PhuCapThamNien", true);
                if (!_phuCapThamNien.Equals(value))
                {
                    _phuCapThamNien = value;
                    PropertyHasChanged("PhuCapThamNien");
                }
            }
        }

        public decimal PhuCapThamNienTangThem1Nam
        {
            get
            {
                CanReadProperty("PhuCapThamNienTangThem1Nam", true);
                return _phuCapThamNienTangThem1Nam;
            }
            set
            {
                CanWriteProperty("PhuCapThamNienTangThem1Nam", true);
                if (!_phuCapThamNienTangThem1Nam.Equals(value))
                {
                    _phuCapThamNienTangThem1Nam = value;
                    PropertyHasChanged("PhuCapThamNienTangThem1Nam");
                }
            }
        }

        public decimal PhucapChuyenCan
        {
            get
            {
                CanReadProperty("PhucapChuyenCan", true);
                return _phucapChuyenCan;
            }
            set
            {
                CanWriteProperty("PhucapChuyenCan", true);
                if (!_phucapChuyenCan.Equals(value))
                {
                    _phucapChuyenCan = value;
                    PropertyHasChanged("PhucapChuyenCan");
                }
            }
        }

        public bool TruBaoHiemTruocKhiTinhThue
        {
            get
            {
                CanReadProperty("TruBaoHiemTruocKhiTinhThue", true);
                return _truBaoHiemTruocKhiTinhThue;
            }
            set
            {
                CanWriteProperty("TruBaoHiemTruocKhiTinhThue", true);
                if (!_truBaoHiemTruocKhiTinhThue.Equals(value))
                {
                    _truBaoHiemTruocKhiTinhThue = value;
                    PropertyHasChanged("TruBaoHiemTruocKhiTinhThue");
                }
            }
        }

        public decimal LuongCoBan
        {
            get
            {
                CanReadProperty("LuongCoBan", true);
                return _luongCoBan;
            }
            set
            {
                CanWriteProperty("LuongCoBan", true);
                if (!_luongCoBan.Equals(value))
                {
                    _luongCoBan = value;
                    PropertyHasChanged("LuongCoBan");
                }
            }
        }

        public decimal SoGioTangCaToiDa
        {
            get
            {
                CanReadProperty("SoGioTangCaToiDa", true);
                return _soGioTangCaToiDa;
            }
            set
            {
                CanWriteProperty("SoGioTangCaToiDa", true);
                if (!_soGioTangCaToiDa.Equals(value))
                {
                    _soGioTangCaToiDa = value;
                    PropertyHasChanged("SoGioTangCaToiDa");
                }
            }
        }

        public decimal CoGianTG
        {
            get
            {
                CanReadProperty("CoGianTG", true);
                return _coGianTG;
            }
            set
            {
                CanWriteProperty("CoGianTG", true);
                if (!_coGianTG.Equals(value))
                {
                    _coGianTG = value;
                    PropertyHasChanged("CoGianTG");
                }
            }
        }

        public decimal TranBHXHNamNay
        {
            get
            {
                CanReadProperty("TranBHXHNamNay", true);
                return _tranBHXHNamNay;
            }
            set
            {
                CanWriteProperty("TranBHXHNamNay", true);
                if (!_tranBHXHNamNay.Equals(value))
                {
                    _tranBHXHNamNay = value;
                    PropertyHasChanged("TranBHXHNamNay");
                }
            }
        }

        public decimal TranBHXHNamTruoc
        {
            get
            {
                CanReadProperty("TranBHXHNamTruoc", true);
                return _tranBHXHNamTruoc;
            }
            set
            {
                CanWriteProperty("TranBHXHNamTruoc", true);
                if (!_tranBHXHNamTruoc.Equals(value))
                {
                    _tranBHXHNamTruoc = value;
                    PropertyHasChanged("TranBHXHNamTruoc");
                }
            }
        }

        public decimal SoTienGiamTruBanThan
        {
            get
            {
                CanReadProperty("SoTienGiamTruBanThan", true);
                return _soTienGiamTruBanThan;
            }
            set
            {
                CanWriteProperty("SoTienGiamTruBanThan", true);
                if (!_soTienGiamTruBanThan.Equals(value))
                {
                    _soTienGiamTruBanThan = value;
                    PropertyHasChanged("SoTienGiamTruBanThan");
                }
            }
        }

        public decimal LuongNoiBo
        {
            get
            {
                CanReadProperty("LuongNoiBo", true);
                return _luongNoiBo;
            }
            set
            {
                CanWriteProperty("LuongNoiBo", true);
                if (!_luongNoiBo.Equals(value))
                {
                    _luongNoiBo = value;
                    PropertyHasChanged("LuongNoiBo");
                }
            }
        }

        public decimal SoGioTrongNgay
        {
            get
            {
                CanReadProperty("SoGioTrongNgay", true);
                return _soGioTrongNgay;
            }
            set
            {
                CanWriteProperty("SoGioTrongNgay", true);
                if (!_soGioTrongNgay.Equals(value))
                {
                    _soGioTrongNgay = value;
                    PropertyHasChanged("SoGioTrongNgay");
                }
            }
        }

        public decimal PhuCapTienAn
        {
            get
            {
                CanReadProperty("PhuCapTienAn", true);
                return _phuCapTienAn;
            }
            set
            {
                CanWriteProperty("PhuCapTienAn", true);
                if (!_phuCapTienAn.Equals(value))
                {
                    _phuCapTienAn = value;
                    PropertyHasChanged("PhuCapTienAn");
                }
            }
        }

        public decimal PhuCapHanhChinh
        {
            get
            {
                CanReadProperty("PhuCapHanhChinh", true);
                return _phuCapHanhChinh;
            }
            set
            {
                CanWriteProperty("PhuCapHanhChinh", true);
                if (!_phuCapHanhChinh.Equals(value))
                {
                    _phuCapHanhChinh = value;
                    PropertyHasChanged("PhuCapHanhChinh");
                }
            }
        }

        public decimal PhanTramThueThuLaoKhenThuong
        {
            get
            {
                CanReadProperty("PhanTramThueThuLaoKhenThuong", true);
                return _phanTramThueThuLaoKhenThuong;
            }
            set
            {
                CanWriteProperty("PhanTramThueThuLaoKhenThuong", true);
                if (!_phanTramThueThuLaoKhenThuong.Equals(value))
                {
                    _phanTramThueThuLaoKhenThuong = value;
                    PropertyHasChanged("PhanTramThueThuLaoKhenThuong");
                }
            }
        }

        public decimal PhanTramBHTN
        {
            get
            {
                CanReadProperty("PhanTramBHTN", true);
                return _phanTramBHTN;
            }
            set
            {
                CanWriteProperty("PhanTramBHTN", true);
                if (!_phanTramBHTN.Equals(value))
                {
                    _phanTramBHTN = value;
                    PropertyHasChanged("PhanTramBHTN");
                }
            }
        }

        public decimal PhanTramCongDoan
        {
            get
            {
                CanReadProperty("PhanTramCongDoan", true);
                return _phanTramCongDoan;
            }
            set
            {
                CanWriteProperty("PhanTramCongDoan", true);
                if (!_phanTramCongDoan.Equals(value))
                {
                    _phanTramCongDoan = value;
                    PropertyHasChanged("PhanTramCongDoan");
                }
            }
        }

        public decimal TongSoGioNgoaiGio
        {
            get
            {
                CanReadProperty("TongSoGioNgoaiGio", true);
                return _tongSoGioNgoaiGio;
            }
            set
            {
                CanWriteProperty("TongSoGioNgoaiGio", true);
                if (!_tongSoGioNgoaiGio.Equals(value))
                {
                    _tongSoGioNgoaiGio = value;
                    PropertyHasChanged("TongSoGioNgoaiGio");
                }
            }
        }

        public DateTime NgayApDung
        {
            get
            {
                CanReadProperty("NgayApDung", true);
                return _ngayApDung.Date;
            }
            set
            {
                CanWriteProperty("NgayApDung", true);
                _ngayApDung = new SmartDate(value);
                PropertyHasChanged("NgayApDung");
            }
        }

        public decimal PhuCapAnTrua
        {
            get
            {
                CanReadProperty("SoTienAnTruaKhongTinhThue", true);
                return _soTienAnTruaKhongTinhThue;
            }
            set
            {
                CanWriteProperty("SoTienAnTruaKhongTinhThue", true);
                if (!_soTienAnTruaKhongTinhThue.Equals(value))
                {
                    _soTienAnTruaKhongTinhThue = value;
                    PropertyHasChanged("SoTienAnTruaKhongTinhThue");
                }
            }
        }

        protected override object GetIdValue()
        {
            return _maNgay;
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
            //TODO: Define authorization rules in Default_Ngay
            //AuthorizationRules.AllowRead("MaNgay", "Default_NgayReadGroup");
            //AuthorizationRules.AllowRead("SoCongTinhChuyenCan", "Default_NgayReadGroup");
            //AuthorizationRules.AllowRead("SoNgayPhepNamTrongNam", "Default_NgayReadGroup");
            //AuthorizationRules.AllowRead("SoNgayLamViecTrongThang", "Default_NgayReadGroup");
            //AuthorizationRules.AllowRead("HeSoKhiLamCaDem", "Default_NgayReadGroup");
            //AuthorizationRules.AllowRead("NghiLonHonMayNgayTruLuong", "Default_NgayReadGroup");
            //AuthorizationRules.AllowRead("PhanTramBHXH", "Default_NgayReadGroup");
            //AuthorizationRules.AllowRead("PhanTramBHYT", "Default_NgayReadGroup");
            //AuthorizationRules.AllowRead("TienCongDoan", "Default_NgayReadGroup");
            //AuthorizationRules.AllowRead("PhuCapConNho", "Default_NgayReadGroup");
            //AuthorizationRules.AllowRead("TuoiConHuongPhuCap", "Default_NgayReadGroup");
            //AuthorizationRules.AllowRead("SoGioGianCa", "Default_NgayReadGroup");
            //AuthorizationRules.AllowRead("TienHocViec", "Default_NgayReadGroup");
            //AuthorizationRules.AllowRead("TienThuViec", "Default_NgayReadGroup");
            //AuthorizationRules.AllowRead("PhuCapNhaO", "Default_NgayReadGroup");
            //AuthorizationRules.AllowRead("PhuCapThamNien", "Default_NgayReadGroup");
            //AuthorizationRules.AllowRead("PhuCapThamNienTangThem1Nam", "Default_NgayReadGroup");
            //AuthorizationRules.AllowRead("PhucapChuyenCan", "Default_NgayReadGroup");
            //AuthorizationRules.AllowRead("TruBaoHiemTruocKhiTinhThue", "Default_NgayReadGroup");
            //AuthorizationRules.AllowRead("LuongCoBan", "Default_NgayReadGroup");
            //AuthorizationRules.AllowRead("SoGioTangCaToiDa", "Default_NgayReadGroup");
            //AuthorizationRules.AllowRead("CoGianTG", "Default_NgayReadGroup");
            //AuthorizationRules.AllowRead("TranBHXHNamNay", "Default_NgayReadGroup");
            //AuthorizationRules.AllowRead("TranBHXHNamTruoc", "Default_NgayReadGroup");
            //AuthorizationRules.AllowRead("SoTienGiamTruBanThan", "Default_NgayReadGroup");
            //AuthorizationRules.AllowRead("LuongNoiBo", "Default_NgayReadGroup");
            //AuthorizationRules.AllowRead("SoGioTrongNgay", "Default_NgayReadGroup");
            //AuthorizationRules.AllowRead("PhuCapTienAn", "Default_NgayReadGroup");
            //AuthorizationRules.AllowRead("PhuCapHanhChinh", "Default_NgayReadGroup");
            //AuthorizationRules.AllowRead("PhanTramThueThuLaoKhenThuong", "Default_NgayReadGroup");
            //AuthorizationRules.AllowRead("PhanTramBHTN", "Default_NgayReadGroup");
            //AuthorizationRules.AllowRead("PhanTramCongDoan", "Default_NgayReadGroup");
            //AuthorizationRules.AllowRead("TongSoGioNgoaiGio", "Default_NgayReadGroup");
            //AuthorizationRules.AllowRead("NgayApDung", "Default_NgayReadGroup");
            //AuthorizationRules.AllowRead("NgayApDungString", "Default_NgayReadGroup");
            //AuthorizationRules.AllowRead("SoTienAnTruaKhongTinhThue", "Default_NgayReadGroup");

            //AuthorizationRules.AllowWrite("SoCongTinhChuyenCan", "Default_NgayWriteGroup");
            //AuthorizationRules.AllowWrite("SoNgayPhepNamTrongNam", "Default_NgayWriteGroup");
            //AuthorizationRules.AllowWrite("SoNgayLamViecTrongThang", "Default_NgayWriteGroup");
            //AuthorizationRules.AllowWrite("HeSoKhiLamCaDem", "Default_NgayWriteGroup");
            //AuthorizationRules.AllowWrite("NghiLonHonMayNgayTruLuong", "Default_NgayWriteGroup");
            //AuthorizationRules.AllowWrite("PhanTramBHXH", "Default_NgayWriteGroup");
            //AuthorizationRules.AllowWrite("PhanTramBHYT", "Default_NgayWriteGroup");
            //AuthorizationRules.AllowWrite("TienCongDoan", "Default_NgayWriteGroup");
            //AuthorizationRules.AllowWrite("PhuCapConNho", "Default_NgayWriteGroup");
            //AuthorizationRules.AllowWrite("TuoiConHuongPhuCap", "Default_NgayWriteGroup");
            //AuthorizationRules.AllowWrite("SoGioGianCa", "Default_NgayWriteGroup");
            //AuthorizationRules.AllowWrite("TienHocViec", "Default_NgayWriteGroup");
            //AuthorizationRules.AllowWrite("TienThuViec", "Default_NgayWriteGroup");
            //AuthorizationRules.AllowWrite("PhuCapNhaO", "Default_NgayWriteGroup");
            //AuthorizationRules.AllowWrite("PhuCapThamNien", "Default_NgayWriteGroup");
            //AuthorizationRules.AllowWrite("PhuCapThamNienTangThem1Nam", "Default_NgayWriteGroup");
            //AuthorizationRules.AllowWrite("PhucapChuyenCan", "Default_NgayWriteGroup");
            //AuthorizationRules.AllowWrite("TruBaoHiemTruocKhiTinhThue", "Default_NgayWriteGroup");
            //AuthorizationRules.AllowWrite("LuongCoBan", "Default_NgayWriteGroup");
            //AuthorizationRules.AllowWrite("SoGioTangCaToiDa", "Default_NgayWriteGroup");
            //AuthorizationRules.AllowWrite("CoGianTG", "Default_NgayWriteGroup");
            //AuthorizationRules.AllowWrite("TranBHXHNamNay", "Default_NgayWriteGroup");
            //AuthorizationRules.AllowWrite("TranBHXHNamTruoc", "Default_NgayWriteGroup");
            //AuthorizationRules.AllowWrite("SoTienGiamTruBanThan", "Default_NgayWriteGroup");
            //AuthorizationRules.AllowWrite("LuongNoiBo", "Default_NgayWriteGroup");
            //AuthorizationRules.AllowWrite("SoGioTrongNgay", "Default_NgayWriteGroup");
            //AuthorizationRules.AllowWrite("PhuCapTienAn", "Default_NgayWriteGroup");
            //AuthorizationRules.AllowWrite("PhuCapHanhChinh", "Default_NgayWriteGroup");
            //AuthorizationRules.AllowWrite("PhanTramThueThuLaoKhenThuong", "Default_NgayWriteGroup");
            //AuthorizationRules.AllowWrite("PhanTramBHTN", "Default_NgayWriteGroup");
            //AuthorizationRules.AllowWrite("PhanTramCongDoan", "Default_NgayWriteGroup");
            //AuthorizationRules.AllowWrite("TongSoGioNgoaiGio", "Default_NgayWriteGroup");
            //AuthorizationRules.AllowWrite("NgayApDungString", "Default_NgayWriteGroup");
            //AuthorizationRules.AllowWrite("SoTienAnTruaKhongTinhThue", "Default_NgayWriteGroup");
        }


        public static bool CanGetObject()
        {
            //TODO: Define CanGetObject permission in Default_Ngay
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("Default_NgayViewGroup"))
            //	return true;
            //return false;
        }

        public static bool CanAddObject()
        {
            //TODO: Define CanAddObject permission in Default_Ngay
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("Default_NgayAddGroup"))
            //	return true;
            //return false;
        }

        public static bool CanEditObject()
        {
            //TODO: Define CanEditObject permission in Default_Ngay
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("Default_NgayEditGroup"))
            //	return true;
            //return false;
        }

        public static bool CanDeleteObject()
        {
            //TODO: Define CanDeleteObject permission in Default_Ngay
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("Default_NgayDeleteGroup"))
            //	return true;
            //return false;
        }
        #endregion //Authorization Rules

        #region Factory Methods
        private Default_Ngay()
        { /* require use of factory method */ }

        public static Default_Ngay NewDefault_Ngay()
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a Default_Ngay");
            return DataPortal.Create<Default_Ngay>();
        }

        public static Default_Ngay GetDefault_Ngay(int maNgay)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a Default_Ngay");
            return DataPortal.Fetch<Default_Ngay>(new Criteria(maNgay));
        }

        public static Default_Ngay GetDefault_Ngay()
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a Default_Ngay");
            return DataPortal.Fetch<Default_Ngay>(new CriteriaGetMax());
        }

        public static void DeleteDefault_Ngay(int maNgay)
        {
            if (!CanDeleteObject())
                throw new System.Security.SecurityException("User not authorized to remove a Default_Ngay");
            DataPortal.Delete(new Criteria(maNgay));
        }

        public override Default_Ngay Save()
        {
            if (IsDeleted && !CanDeleteObject())
                throw new System.Security.SecurityException("User not authorized to remove a Default_Ngay");
            else if (IsNew && !CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a Default_Ngay");
            else if (!CanEditObject())
                throw new System.Security.SecurityException("User not authorized to update a Default_Ngay");

            return base.Save();
        }

        #endregion //Factory Methods

        #region Child Factory Methods
        internal static Default_Ngay NewDefault_NgayChild()
        {
            Default_Ngay child = new Default_Ngay();
            child.ValidationRules.CheckRules();
            child.MarkAsChild();
            return child;
        }

        internal static Default_Ngay GetDefault_Ngay(SafeDataReader dr)
        {
            Default_Ngay child = new Default_Ngay();
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
            public int MaNgay;

            public Criteria(int maNgay)
            {
                this.MaNgay = maNgay;
            }
        }

        [Serializable()]
        private class CriteriaGetMax
        {
            public CriteriaGetMax()
            {
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
        private void DataPortal_Fetch(object criteria)
        {
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();

                ExecuteFetch(cn, criteria);
            }//using
        }

        private void ExecuteFetch(SqlConnection cn, object criteria)
        {
            using (SqlCommand cm = cn.CreateCommand())
            {
                cm.CommandType = CommandType.StoredProcedure;
                if (criteria is CriteriaGetMax)
                {
                    cm.CommandText = "spd_SelecttblnsDefault_Ngay_GetMax";
                }
                else
                {
                    cm.CommandText = "spd_SelecttblnsDefault_Ngay";

                    cm.Parameters.AddWithValue("@MaNgay", ((Criteria)criteria).MaNgay);
                }

                using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                {
                    dr.Read();
                    FetchObject(dr);
                    ValidationRules.CheckRules();

                    //load child object(s)
                    FetchChildren(dr);
                }
            }//using
        }

        #endregion //Data Access - Fetch

        #region Data Access - Insert
        protected override void DataPortal_Insert()
        {
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();

                ExecuteInsert(cn);

                //update child object(s)
                UpdateChildren(cn);
            }//using

        }

        #endregion //Data Access - Insert

        #region Data Access - Update
        protected override void DataPortal_Update()
        {
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();

                if (base.IsDirty)
                {
                    ExecuteUpdate(cn);
                }

                //update child object(s)
                UpdateChildren(cn);
            }//using

        }

        #endregion //Data Access - Update

        #region Data Access - Delete
        protected override void DataPortal_DeleteSelf()
        {
            DataPortal_Delete(new Criteria(_maNgay));
        }

        private void DataPortal_Delete(Criteria criteria)
        {
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();

                ExecuteDelete(cn, criteria);

            }//using

        }

        private void ExecuteDelete(SqlConnection cn, Criteria criteria)
        {
            using (SqlCommand cm = cn.CreateCommand())
            {
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_DeletetblnsDefault_Ngay";

                cm.Parameters.AddWithValue("@MaNgay", criteria.MaNgay);

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
            _maNgay = dr.GetInt32("MaNgay");
            _soCongTinhChuyenCan = dr.GetDouble("SoCongTinhChuyenCan");
            _soNgayPhepNamTrongNam = dr.GetDecimal("SoNgayPhepNamTrongNam");
            _soNgayLamViecTrongThang = dr.GetInt32("SoNgayLamViecTrongThang");
            _heSoKhiLamCaDem = dr.GetDouble("HeSoKhiLamCaDem");
            _nghiLonHonMayNgayTruLuong = dr.GetInt16("NghiLonHonMayNgayTruLuong");
            _phanTramBHXH = dr.GetDecimal("PhanTramBHXH");
            _phanTramBHYT = dr.GetDecimal("PhanTramBHYT");
            _tienCongDoan = dr.GetDecimal("TienCongDoan");
            _phuCapConNho = dr.GetDecimal("PhuCapConNho");
            _tuoiConHuongPhuCap = dr.GetByte("TuoiConHuongPhuCap");
            _soGioGianCa = dr.GetDouble("SoGioGianCa");
            _tienHocViec = dr.GetDecimal("TienHocViec");
            _tienThuViec = dr.GetDecimal("TienThuViec");
            _phuCapNhaO = dr.GetDecimal("PhuCapNhaO");
            _phuCapThamNien = dr.GetDecimal("PhuCapThamNien");
            _phuCapThamNienTangThem1Nam = dr.GetDecimal("PhuCapThamNienTangThem1Nam");
            _phucapChuyenCan = dr.GetDecimal("PhucapChuyenCan");
            _truBaoHiemTruocKhiTinhThue = dr.GetBoolean("TruBaoHiemTruocKhiTinhThue");
            _luongCoBan = dr.GetDecimal("LuongCoBan");
            _soGioTangCaToiDa = dr.GetDecimal("SoGioTangCaToiDa");
            _coGianTG = dr.GetDecimal("CoGianTG");
            _tranBHXHNamNay = dr.GetDecimal("TranBHXHNamNay");
            _tranBHXHNamTruoc = dr.GetDecimal("TranBHXHNamTruoc");
            _soTienGiamTruBanThan = dr.GetDecimal("SoTienGiamTruBanThan");
            _luongNoiBo = dr.GetDecimal("LuongNoiBo");
            _soGioTrongNgay = dr.GetDecimal("SoGioTrongNgay");
            _phuCapTienAn = dr.GetDecimal("PhuCapTienAn");
            _phuCapHanhChinh = dr.GetDecimal("PhuCapHanhChinh");
            _phanTramThueThuLaoKhenThuong = dr.GetDecimal("PhanTramThueThuLaoKhenThuong");
            _phanTramBHTN = dr.GetDecimal("PhanTramBHTN");
            _phanTramCongDoan = dr.GetDecimal("PhanTramCongDoan");
            _tongSoGioNgoaiGio = dr.GetDecimal("TongSoGioNgoaiGio");
            _ngayApDung = dr.GetSmartDate("NgayApDung", _ngayApDung.EmptyIsMin);
            _soTienAnTruaKhongTinhThue = dr.GetDecimal("SoTienAnTruaKhongTinhThue");
        }

        private void FetchChildren(SafeDataReader dr)
        {
        }
        #endregion //Data Access - Fetch

        #region Data Access - Insert
        internal void Insert(SqlConnection cn)
        {
            if (!IsDirty) return;

            ExecuteInsert(cn);
            MarkOld();

            //update child object(s)
            UpdateChildren(cn);
        }

        private void ExecuteInsert(SqlConnection cn)
        {
            using (SqlCommand cm = cn.CreateCommand())
            {
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_InserttblnsDefault_Ngay";

                AddInsertParameters(cm);

                cm.ExecuteNonQuery();

                _maNgay = (int)cm.Parameters["@MaNgay"].Value;
            }//using
        }

        private void AddInsertParameters(SqlCommand cm)
        {
            if (_soCongTinhChuyenCan != 0)
                cm.Parameters.AddWithValue("@SoCongTinhChuyenCan", _soCongTinhChuyenCan);
            else
                cm.Parameters.AddWithValue("@SoCongTinhChuyenCan", DBNull.Value);
            if (_soNgayPhepNamTrongNam != 0)
                cm.Parameters.AddWithValue("@SoNgayPhepNamTrongNam", _soNgayPhepNamTrongNam);
            else
                cm.Parameters.AddWithValue("@SoNgayPhepNamTrongNam", DBNull.Value);
            if (_soNgayLamViecTrongThang != 0)
                cm.Parameters.AddWithValue("@SoNgayLamViecTrongThang", _soNgayLamViecTrongThang);
            else
                cm.Parameters.AddWithValue("@SoNgayLamViecTrongThang", DBNull.Value);
            if (_heSoKhiLamCaDem != 0)
                cm.Parameters.AddWithValue("@HeSoKhiLamCaDem", _heSoKhiLamCaDem);
            else
                cm.Parameters.AddWithValue("@HeSoKhiLamCaDem", DBNull.Value);
            if (_nghiLonHonMayNgayTruLuong != 0)
                cm.Parameters.AddWithValue("@NghiLonHonMayNgayTruLuong", _nghiLonHonMayNgayTruLuong);
            else
                cm.Parameters.AddWithValue("@NghiLonHonMayNgayTruLuong", DBNull.Value);
            if (_phanTramBHXH != 0)
                cm.Parameters.AddWithValue("@PhanTramBHXH", _phanTramBHXH);
            else
                cm.Parameters.AddWithValue("@PhanTramBHXH", DBNull.Value);
            if (_phanTramBHYT != 0)
                cm.Parameters.AddWithValue("@PhanTramBHYT", _phanTramBHYT);
            else
                cm.Parameters.AddWithValue("@PhanTramBHYT", DBNull.Value);
            if (_tienCongDoan != 0)
                cm.Parameters.AddWithValue("@TienCongDoan", _tienCongDoan);
            else
                cm.Parameters.AddWithValue("@TienCongDoan", DBNull.Value);
            if (_phuCapConNho != 0)
                cm.Parameters.AddWithValue("@PhuCapConNho", _phuCapConNho);
            else
                cm.Parameters.AddWithValue("@PhuCapConNho", DBNull.Value);
            if (_tuoiConHuongPhuCap != 0)
                cm.Parameters.AddWithValue("@TuoiConHuongPhuCap", _tuoiConHuongPhuCap);
            else
                cm.Parameters.AddWithValue("@TuoiConHuongPhuCap", DBNull.Value);
            if (_soGioGianCa != 0)
                cm.Parameters.AddWithValue("@SoGioGianCa", _soGioGianCa);
            else
                cm.Parameters.AddWithValue("@SoGioGianCa", DBNull.Value);
            if (_tienHocViec != 0)
                cm.Parameters.AddWithValue("@TienHocViec", _tienHocViec);
            else
                cm.Parameters.AddWithValue("@TienHocViec", DBNull.Value);
            if (_tienThuViec != 0)
                cm.Parameters.AddWithValue("@TienThuViec", _tienThuViec);
            else
                cm.Parameters.AddWithValue("@TienThuViec", DBNull.Value);
            if (_phuCapNhaO != 0)
                cm.Parameters.AddWithValue("@PhuCapNhaO", _phuCapNhaO);
            else
                cm.Parameters.AddWithValue("@PhuCapNhaO", DBNull.Value);
            if (_phuCapThamNien != 0)
                cm.Parameters.AddWithValue("@PhuCapThamNien", _phuCapThamNien);
            else
                cm.Parameters.AddWithValue("@PhuCapThamNien", DBNull.Value);
            if (_phuCapThamNienTangThem1Nam != 0)
                cm.Parameters.AddWithValue("@PhuCapThamNienTangThem1Nam", _phuCapThamNienTangThem1Nam);
            else
                cm.Parameters.AddWithValue("@PhuCapThamNienTangThem1Nam", DBNull.Value);
            if (_phucapChuyenCan != 0)
                cm.Parameters.AddWithValue("@PhucapChuyenCan", _phucapChuyenCan);
            else
                cm.Parameters.AddWithValue("@PhucapChuyenCan", DBNull.Value);
            if (_truBaoHiemTruocKhiTinhThue != false)
                cm.Parameters.AddWithValue("@TruBaoHiemTruocKhiTinhThue", _truBaoHiemTruocKhiTinhThue);
            else
                cm.Parameters.AddWithValue("@TruBaoHiemTruocKhiTinhThue", DBNull.Value);
            if (_luongCoBan != 0)
                cm.Parameters.AddWithValue("@LuongCoBan", _luongCoBan);
            else
                cm.Parameters.AddWithValue("@LuongCoBan", DBNull.Value);
            if (_soGioTangCaToiDa != 0)
                cm.Parameters.AddWithValue("@SoGioTangCaToiDa", _soGioTangCaToiDa);
            else
                cm.Parameters.AddWithValue("@SoGioTangCaToiDa", DBNull.Value);
            if (_coGianTG != 0)
                cm.Parameters.AddWithValue("@CoGianTG", _coGianTG);
            else
                cm.Parameters.AddWithValue("@CoGianTG", DBNull.Value);
            if (_tranBHXHNamNay != 0)
                cm.Parameters.AddWithValue("@TranBHXHNamNay", _tranBHXHNamNay);
            else
                cm.Parameters.AddWithValue("@TranBHXHNamNay", DBNull.Value);
            if (_tranBHXHNamTruoc != 0)
                cm.Parameters.AddWithValue("@TranBHXHNamTruoc", _tranBHXHNamTruoc);
            else
                cm.Parameters.AddWithValue("@TranBHXHNamTruoc", DBNull.Value);
            if (_soTienGiamTruBanThan != 0)
                cm.Parameters.AddWithValue("@SoTienGiamTruBanThan", _soTienGiamTruBanThan);
            else
                cm.Parameters.AddWithValue("@SoTienGiamTruBanThan", DBNull.Value);
            if (_luongNoiBo != 0)
                cm.Parameters.AddWithValue("@LuongNoiBo", _luongNoiBo);
            else
                cm.Parameters.AddWithValue("@LuongNoiBo", DBNull.Value);
            if (_soGioTrongNgay != 0)
                cm.Parameters.AddWithValue("@SoGioTrongNgay", _soGioTrongNgay);
            else
                cm.Parameters.AddWithValue("@SoGioTrongNgay", DBNull.Value);
            if (_phuCapTienAn != 0)
                cm.Parameters.AddWithValue("@PhuCapTienAn", _phuCapTienAn);
            else
                cm.Parameters.AddWithValue("@PhuCapTienAn", DBNull.Value);
            if (_phuCapHanhChinh != 0)
                cm.Parameters.AddWithValue("@PhuCapHanhChinh", _phuCapHanhChinh);
            else
                cm.Parameters.AddWithValue("@PhuCapHanhChinh", DBNull.Value);
            if (_phanTramThueThuLaoKhenThuong != 0)
                cm.Parameters.AddWithValue("@PhanTramThueThuLaoKhenThuong", _phanTramThueThuLaoKhenThuong);
            else
                cm.Parameters.AddWithValue("@PhanTramThueThuLaoKhenThuong", DBNull.Value);
            if (_phanTramBHTN != 0)
                cm.Parameters.AddWithValue("@PhanTramBHTN", _phanTramBHTN);
            else
                cm.Parameters.AddWithValue("@PhanTramBHTN", DBNull.Value);
            if (_phanTramCongDoan != 0)
                cm.Parameters.AddWithValue("@PhanTramCongDoan", _phanTramCongDoan);
            else
                cm.Parameters.AddWithValue("@PhanTramCongDoan", DBNull.Value);
            if (_tongSoGioNgoaiGio != 0)
                cm.Parameters.AddWithValue("@TongSoGioNgoaiGio", _tongSoGioNgoaiGio);
            else
                cm.Parameters.AddWithValue("@TongSoGioNgoaiGio", DBNull.Value);
            cm.Parameters.AddWithValue("@NgayApDung", _ngayApDung.DBValue);
            if (_soTienAnTruaKhongTinhThue != 0)
                cm.Parameters.AddWithValue("@SoTienAnTruaKhongTinhThue", _soTienAnTruaKhongTinhThue);
            else
                cm.Parameters.AddWithValue("@SoTienAnTruaKhongTinhThue", DBNull.Value);
            cm.Parameters.AddWithValue("@MaNgay", _maNgay);
            cm.Parameters["@MaNgay"].Direction = ParameterDirection.Output;
        }
        #endregion //Data Access - Insert

        #region Data Access - Update
        internal void Update(SqlConnection cn)
        {
            if (!IsDirty) return;

            if (base.IsDirty)
            {
                ExecuteUpdate(cn);
                MarkOld();
            }

            //update child object(s)
            UpdateChildren(cn);
        }

        private void ExecuteUpdate(SqlConnection cn)
        {
            using (SqlCommand cm = cn.CreateCommand())
            {
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_UpdatetblnsDefault_Ngay";

                AddUpdateParameters(cm);

                cm.ExecuteNonQuery();

            }//using
        }

        private void AddUpdateParameters(SqlCommand cm)
        {
            cm.Parameters.AddWithValue("@MaNgay", _maNgay);
            if (_soCongTinhChuyenCan != 0)
                cm.Parameters.AddWithValue("@SoCongTinhChuyenCan", _soCongTinhChuyenCan);
            else
                cm.Parameters.AddWithValue("@SoCongTinhChuyenCan", DBNull.Value);
            if (_soNgayPhepNamTrongNam != 0)
                cm.Parameters.AddWithValue("@SoNgayPhepNamTrongNam", _soNgayPhepNamTrongNam);
            else
                cm.Parameters.AddWithValue("@SoNgayPhepNamTrongNam", DBNull.Value);
            if (_soNgayLamViecTrongThang != 0)
                cm.Parameters.AddWithValue("@SoNgayLamViecTrongThang", _soNgayLamViecTrongThang);
            else
                cm.Parameters.AddWithValue("@SoNgayLamViecTrongThang", DBNull.Value);
            if (_heSoKhiLamCaDem != 0)
                cm.Parameters.AddWithValue("@HeSoKhiLamCaDem", _heSoKhiLamCaDem);
            else
                cm.Parameters.AddWithValue("@HeSoKhiLamCaDem", DBNull.Value);
            if (_nghiLonHonMayNgayTruLuong != 0)
                cm.Parameters.AddWithValue("@NghiLonHonMayNgayTruLuong", _nghiLonHonMayNgayTruLuong);
            else
                cm.Parameters.AddWithValue("@NghiLonHonMayNgayTruLuong", DBNull.Value);
            if (_phanTramBHXH != 0)
                cm.Parameters.AddWithValue("@PhanTramBHXH", _phanTramBHXH);
            else
                cm.Parameters.AddWithValue("@PhanTramBHXH", DBNull.Value);
            if (_phanTramBHYT != 0)
                cm.Parameters.AddWithValue("@PhanTramBHYT", _phanTramBHYT);
            else
                cm.Parameters.AddWithValue("@PhanTramBHYT", DBNull.Value);
            if (_tienCongDoan != 0)
                cm.Parameters.AddWithValue("@TienCongDoan", _tienCongDoan);
            else
                cm.Parameters.AddWithValue("@TienCongDoan", DBNull.Value);
            if (_phuCapConNho != 0)
                cm.Parameters.AddWithValue("@PhuCapConNho", _phuCapConNho);
            else
                cm.Parameters.AddWithValue("@PhuCapConNho", DBNull.Value);
            if (_tuoiConHuongPhuCap != 0)
                cm.Parameters.AddWithValue("@TuoiConHuongPhuCap", _tuoiConHuongPhuCap);
            else
                cm.Parameters.AddWithValue("@TuoiConHuongPhuCap", DBNull.Value);
            if (_soGioGianCa != 0)
                cm.Parameters.AddWithValue("@SoGioGianCa", _soGioGianCa);
            else
                cm.Parameters.AddWithValue("@SoGioGianCa", DBNull.Value);
            if (_tienHocViec != 0)
                cm.Parameters.AddWithValue("@TienHocViec", _tienHocViec);
            else
                cm.Parameters.AddWithValue("@TienHocViec", DBNull.Value);
            if (_tienThuViec != 0)
                cm.Parameters.AddWithValue("@TienThuViec", _tienThuViec);
            else
                cm.Parameters.AddWithValue("@TienThuViec", DBNull.Value);
            if (_phuCapNhaO != 0)
                cm.Parameters.AddWithValue("@PhuCapNhaO", _phuCapNhaO);
            else
                cm.Parameters.AddWithValue("@PhuCapNhaO", DBNull.Value);
            if (_phuCapThamNien != 0)
                cm.Parameters.AddWithValue("@PhuCapThamNien", _phuCapThamNien);
            else
                cm.Parameters.AddWithValue("@PhuCapThamNien", DBNull.Value);
            if (_phuCapThamNienTangThem1Nam != 0)
                cm.Parameters.AddWithValue("@PhuCapThamNienTangThem1Nam", _phuCapThamNienTangThem1Nam);
            else
                cm.Parameters.AddWithValue("@PhuCapThamNienTangThem1Nam", DBNull.Value);
            if (_phucapChuyenCan != 0)
                cm.Parameters.AddWithValue("@PhucapChuyenCan", _phucapChuyenCan);
            else
                cm.Parameters.AddWithValue("@PhucapChuyenCan", DBNull.Value);
            if (_truBaoHiemTruocKhiTinhThue != false)
                cm.Parameters.AddWithValue("@TruBaoHiemTruocKhiTinhThue", _truBaoHiemTruocKhiTinhThue);
            else
                cm.Parameters.AddWithValue("@TruBaoHiemTruocKhiTinhThue", DBNull.Value);
            if (_luongCoBan != 0)
                cm.Parameters.AddWithValue("@LuongCoBan", _luongCoBan);
            else
                cm.Parameters.AddWithValue("@LuongCoBan", DBNull.Value);
            if (_soGioTangCaToiDa != 0)
                cm.Parameters.AddWithValue("@SoGioTangCaToiDa", _soGioTangCaToiDa);
            else
                cm.Parameters.AddWithValue("@SoGioTangCaToiDa", DBNull.Value);
            if (_coGianTG != 0)
                cm.Parameters.AddWithValue("@CoGianTG", _coGianTG);
            else
                cm.Parameters.AddWithValue("@CoGianTG", DBNull.Value);
            if (_tranBHXHNamNay != 0)
                cm.Parameters.AddWithValue("@TranBHXHNamNay", _tranBHXHNamNay);
            else
                cm.Parameters.AddWithValue("@TranBHXHNamNay", DBNull.Value);
            if (_tranBHXHNamTruoc != 0)
                cm.Parameters.AddWithValue("@TranBHXHNamTruoc", _tranBHXHNamTruoc);
            else
                cm.Parameters.AddWithValue("@TranBHXHNamTruoc", DBNull.Value);
            if (_soTienGiamTruBanThan != 0)
                cm.Parameters.AddWithValue("@SoTienGiamTruBanThan", _soTienGiamTruBanThan);
            else
                cm.Parameters.AddWithValue("@SoTienGiamTruBanThan", DBNull.Value);
            if (_luongNoiBo != 0)
                cm.Parameters.AddWithValue("@LuongNoiBo", _luongNoiBo);
            else
                cm.Parameters.AddWithValue("@LuongNoiBo", DBNull.Value);
            if (_soGioTrongNgay != 0)
                cm.Parameters.AddWithValue("@SoGioTrongNgay", _soGioTrongNgay);
            else
                cm.Parameters.AddWithValue("@SoGioTrongNgay", DBNull.Value);
            if (_phuCapTienAn != 0)
                cm.Parameters.AddWithValue("@PhuCapTienAn", _phuCapTienAn);
            else
                cm.Parameters.AddWithValue("@PhuCapTienAn", DBNull.Value);
            if (_phuCapHanhChinh != 0)
                cm.Parameters.AddWithValue("@PhuCapHanhChinh", _phuCapHanhChinh);
            else
                cm.Parameters.AddWithValue("@PhuCapHanhChinh", DBNull.Value);
            if (_phanTramThueThuLaoKhenThuong != 0)
                cm.Parameters.AddWithValue("@PhanTramThueThuLaoKhenThuong", _phanTramThueThuLaoKhenThuong);
            else
                cm.Parameters.AddWithValue("@PhanTramThueThuLaoKhenThuong", DBNull.Value);
            if (_phanTramBHTN != 0)
                cm.Parameters.AddWithValue("@PhanTramBHTN", _phanTramBHTN);
            else
                cm.Parameters.AddWithValue("@PhanTramBHTN", DBNull.Value);
            if (_phanTramCongDoan != 0)
                cm.Parameters.AddWithValue("@PhanTramCongDoan", _phanTramCongDoan);
            else
                cm.Parameters.AddWithValue("@PhanTramCongDoan", DBNull.Value);
            if (_tongSoGioNgoaiGio != 0)
                cm.Parameters.AddWithValue("@TongSoGioNgoaiGio", _tongSoGioNgoaiGio);
            else
                cm.Parameters.AddWithValue("@TongSoGioNgoaiGio", DBNull.Value);
            cm.Parameters.AddWithValue("@NgayApDung", _ngayApDung.DBValue);
            if (_soTienAnTruaKhongTinhThue != 0)
                cm.Parameters.AddWithValue("@SoTienAnTruaKhongTinhThue", _soTienAnTruaKhongTinhThue);
            else
                cm.Parameters.AddWithValue("@SoTienAnTruaKhongTinhThue", DBNull.Value);
        }

        private void UpdateChildren(SqlConnection cn)
        {
        }
        #endregion //Data Access - Update

        #region Data Access - Delete
        internal void DeleteSelf(SqlConnection cn)
        {
            if (!IsDirty) return;
            if (IsNew) return;

            ExecuteDelete(cn, new Criteria(_maNgay));
            MarkNew();
        }
        #endregion //Data Access - Delete
        #endregion //Data Access
    }
}
