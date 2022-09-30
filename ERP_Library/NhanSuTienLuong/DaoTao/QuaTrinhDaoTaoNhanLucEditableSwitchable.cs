using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;
using System.ComponentModel;
//20/10/2014
namespace ERP_Library
{
    [Serializable()]
    public class QuaTrinhDaoTaoNhanLuc : Csla.BusinessBase<QuaTrinhDaoTaoNhanLuc>
    {
        #region Business Properties and Methods

        //declare members
        private int _maQuaTrinhDaoTao = 0;
        private long _maNhanVien = 0;
        private int _namTotNghiep = 0;
        private string _xepLoai = string.Empty;
        private SmartDate _ngayCap = new SmartDate(DateTime.MinValue);
        private byte _vanbangChungchi = 0;
        private string _tenvanbangChungchi = string.Empty;
        private string _nguoiKy = string.Empty;
        private string _sovanbangChungchi = string.Empty;
        private string _ghiChu = string.Empty;
        private int _maNguoiLap = 0;
        private SmartDate _ngayLap = new SmartDate(DateTime.Today);
        private int _loaiVanBang = 0;
        private int _maQuocGiaCap = 0;
        private int _maTruongDaoTao = 0;
        private bool _daNopBang = false;
        private bool _chuyenTTNhanVien = false;
        private int _maChuyenNganhDaoTao = 0;
        private byte _trongnuocNgoainuoc = 0;
        private int _maChiTietDeCu = 0;
        private int _maDonViDaoTao = 0;
        private SmartDate _ngayHeThong = new SmartDate(DateTime.Today);

        LopHoc _lopHoc;

        private byte _ketQuaDaoTao = 0;
        #region BoSung ngoai
        private string _tenNhanVien = string.Empty;
        private string _maQLNhanVien = string.Empty;
        private string _boPhanNhanVien = string.Empty;
        private string _vanbangChungchiString = string.Empty;
        private string _loaiVanBangString = string.Empty;
        private string _quocGiaCapString = string.Empty;
        private string _truongDaoTaostring = string.Empty;
        private string _daNopBangString = string.Empty;
        private string _chuyenNganhDaoTaoString = string.Empty;
        private string _trongnuocNgoainuocString = string.Empty;
        private string _ketQuaDaoTaoString = string.Empty;
        private string _tenDonViDaoTao = string.Empty;
        private string _tenLoaiLop = string.Empty;
        private SmartDate _ngayBatDauChinhThuc = new SmartDate(DateTime.MinValue);
        private SmartDate _ngayKetThucChinhThuc = new SmartDate(DateTime.MinValue);
        #endregion

        [System.ComponentModel.DataObjectField(true, true)]
        public int MaQuaTrinhDaoTao
        {
            get
            {
                CanReadProperty("MaQuaTrinhDaoTao", true);
                return _maQuaTrinhDaoTao;
            }
        }


        public bool Chon { get; set; }


        [DisplayName("Nhân viên")]
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
                    if (_maNhanVien != 0)
                    {
                        _tenNhanVien = ThongTinNhanVienTongHop.GetThongTinNhanVienTongHop(_maNhanVien).TenNhanVien;
                        _maQLNhanVien = ThongTinNhanVienTongHop.GetThongTinNhanVienTongHop(_maNhanVien).MaQLNhanVien;
                        _boPhanNhanVien = ThongTinNhanVienTongHop.GetThongTinNhanVienTongHop(_maNhanVien).TenBoPhan;
                    }
                    PropertyHasChanged("MaNhanVien");
                }
            }
        }

        [DisplayName("Năm tốt nghiệp")]
        public int NamTotNghiep
        {
            get
            {
                CanReadProperty("NamTotNghiep", true);
                return _namTotNghiep;
            }
            set
            {
                CanWriteProperty("NamTotNghiep", true);
                if (!_namTotNghiep.Equals(value))
                {
                    _namTotNghiep = value;
                    PropertyHasChanged("NamTotNghiep");
                }
            }
        }

        [DisplayName("Xếp loại")]
        public string XepLoai
        {
            get
            {
                CanReadProperty("XepLoai", true);
                return _xepLoai;
            }
            set
            {
                CanWriteProperty("XepLoai", true);
                if (value == null) value = string.Empty;
                if (!_xepLoai.Equals(value))
                {
                    _xepLoai = value;
                    PropertyHasChanged("XepLoai");
                }
            }
        }

        [DisplayName("Ngày cấp")]
        public DateTime? NgayCap
        {
            get
            {
                CanReadProperty("NgayCap", true);
                if (_ngayCap.Date == DateTime.MinValue)
                    return null;
                return _ngayCap.Date;
            }
            set
            {
                CanWriteProperty("NgayCap", true);
                if (!_ngayCap.Equals(value))
                {
                    if (value == null)
                        _ngayCap = new SmartDate(DateTime.MinValue);
                    else
                    {
                        _ngayCap = new SmartDate(value.Value.Date);
                        _namTotNghiep = _ngayCap.Date.Year;
                    }
                    PropertyHasChanged();
                }
            }
        }

        [DisplayName("Văn bằng/ Chứng chỉ")]
        public byte VanbangChungchi
        {
            get
            {
                CanReadProperty("VanbangChungchi", true);
                return _vanbangChungchi;
            }
            set
            {
                CanWriteProperty("VanbangChungchi", true);
                if (!_vanbangChungchi.Equals(value))
                {
                    _vanbangChungchi = value;
                    if (_vanbangChungchi == 1)
                        _vanbangChungchiString = "Văn bằng";
                    else if (_vanbangChungchi == 2)
                        _vanbangChungchiString = "Chứng chỉ";
                    PropertyHasChanged("VanbangChungchi");
                }
            }
        }

        [DisplayName("Tên Văn bằng/ Chứng chỉ")]
        public string TenvanbangChungchi
        {
            get
            {
                //return _lopHoc.TenvanbangChungchi;
                return _tenvanbangChungchi;
                //CanReadProperty("TenvanbangChungchi", true);
                //return _tenvanbangChungchi;
            }
            //set
            //{
            //    CanWriteProperty("TenvanbangChungchi", true);
            //    if (value == null) value = string.Empty;
            //    if (!_tenvanbangChungchi.Equals(value))
            //    {
            //        _tenvanbangChungchi = value;
            //        PropertyHasChanged("TenvanbangChungchi");
            //    }
            //}
        }

        [DisplayName("Người ký")]
        public string NguoiKy
        {
            get
            {
                CanReadProperty("NguoiKy", true);
                return _nguoiKy;
            }
            set
            {
                CanWriteProperty("NguoiKy", true);
                if (value == null) value = string.Empty;
                if (!_nguoiKy.Equals(value))
                {
                    _nguoiKy = value;
                    PropertyHasChanged("NguoiKy");
                }
            }
        }

        [DisplayName("Số Văn bằng/ Chứng chỉ")]
        public string SovanbangChungchi
        {
            get
            {
                CanReadProperty("SovanbangChungchi", true);
                return _sovanbangChungchi;
            }
            set
            {
                CanWriteProperty("SovanbangChungchi", true);
                if (value == null) value = string.Empty;
                if (!_sovanbangChungchi.Equals(value))
                {
                    _sovanbangChungchi = value;
                    PropertyHasChanged("SovanbangChungchi");
                }
            }
        }

        [DisplayName("Ghi chú")]
        public string GhiChu
        {
            get
            {
                CanReadProperty("GhiChu", true);
                return _ghiChu;
            }
            set
            {
                CanWriteProperty("GhiChu", true);
                if (value == null) value = string.Empty;
                if (!_ghiChu.Equals(value))
                {
                    _ghiChu = value;
                    PropertyHasChanged("GhiChu");
                }
            }
        }

        [DisplayName("Người lập")]
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

        [DisplayName("Ngày lập")]
        public DateTime? NgayLap
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
                    if (value == null)
                        _ngayLap = new SmartDate(DateTime.MinValue);
                    else
                        _ngayLap = new SmartDate(value.Value.Date);
                    PropertyHasChanged();
                }
            }
        }

        public DateTime? NgayHeThong
        {
            get
            {
                CanReadProperty("NgayHeThong", true);
                return _ngayHeThong.Date;
            }
            set
            {
                CanWriteProperty("NgayHeThong", true);
                if (!_ngayHeThong.Equals(value))
                {
                    if (value == null)
                        _ngayHeThong = new SmartDate(DateTime.MinValue);
                    else
                        _ngayHeThong = new SmartDate(value.Value.Date);
                    PropertyHasChanged();
                }
            }
        }


        [DisplayName("Loại Văn bằng/Chứng chỉ")]
        public int LoaiVanBang
        {
            get
            {
                CanReadProperty("LoaiVanBang", true);
                return _loaiVanBang;
            }
            set
            {
                CanWriteProperty("LoaiVanBang", true);
                if (!_loaiVanBang.Equals(value))
                {
                    _loaiVanBang = value;
                    if (_loaiVanBang != 0)
                        _loaiVanBangString = TrinhDoHocVanClass.GetTrinhDoHocVanClass(_loaiVanBang).TrinhDoHocVan;
                    PropertyHasChanged("LoaiVanBang");
                }
            }
        }

        [DisplayName("Quốc gia cấp")]
        public int MaQuocGiaCap
        {
            get
            {
                CanReadProperty("MaQuocGiaCap", true);
                return _maQuocGiaCap;
            }
            set
            {
                CanWriteProperty("MaQuocGiaCap", true);
                if (!_maQuocGiaCap.Equals(value))
                {
                    _maQuocGiaCap = value;
                    if (_maQuocGiaCap != 0)
                        _quocGiaCapString = QuocGia.GetQuocGia(_maQuocGiaCap).TenQuocGia;
                    PropertyHasChanged("MaQuocGiaCap");
                }
            }
        }

        [DisplayName("Trường đào tạo")]
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
                    if (_maTruongDaoTao != 0)
                        _truongDaoTaostring = TruongDaoTao.GetTruongDaoTao(_maTruongDaoTao).TenTruongDaoTao;
                    PropertyHasChanged("MaTruongDaoTao");
                }
            }
        }

        [DisplayName("Đã nộp bằng")]
        public bool DaNopBang
        {
            get
            {
                CanReadProperty("DaNopBang", true);
                return _daNopBang;
            }
            set
            {
                CanWriteProperty("DaNopBang", true);
                if (!_daNopBang.Equals(value))
                {
                    _daNopBang = value;
                    if (_daNopBang)
                        _daNopBangString = "Đã nộp bằng";
                    else _daNopBangString = "Chưa nộp bằng";
                    //set Ket qua dao tao
                    if (_daNopBang)
                        _ketQuaDaoTao = 2;//Dat
                    //else
                    //    _ketQuaDaoTao = 1;//Khong Dat
                    PropertyHasChanged("DaNopBang");
                }
            }
        }

        public bool ChuyenTTNhanVien
        {
            get
            {
                CanReadProperty("ChuyenTTNhanVien", true);
                return _chuyenTTNhanVien;
            }
            set
            {
                CanWriteProperty("ChuyenTTNhanVien", true);
                if (!_chuyenTTNhanVien.Equals(value))
                {
                    _chuyenTTNhanVien = value;
                    PropertyHasChanged("ChuyenTTNhanVien");
                }
            }
        }

        [DisplayName("Ngành đào tạo")]
        public int MaChuyenNganhDaoTao
        {
            get
            {
                CanReadProperty("MaChuyenNganhDaoTao", true);
                return _maChuyenNganhDaoTao;
            }
            set
            {
                CanWriteProperty("MaChuyenNganhDaoTao", true);
                if (!_maChuyenNganhDaoTao.Equals(value))
                {
                    _maChuyenNganhDaoTao = value;
                    if (_maChuyenNganhDaoTao != 0)
                        _chuyenNganhDaoTaoString = ChuyenNganhDaoTaoClass.GetChuyenNganhDaoTaoClass(_maChuyenNganhDaoTao).ChuyenNganhDaoTao;
                    PropertyHasChanged("MaChuyenNganhDaoTao");
                }
            }
        }

        [DisplayName("Đào tạo Trong nước/ Ngoài nước")]
        public byte TrongnuocNgoainuoc
        {
            get
            {
                CanReadProperty("TrongnuocNgoainuoc", true);
                return _trongnuocNgoainuoc;
            }
            set
            {
                CanWriteProperty("TrongnuocNgoainuoc", true);
                if (!_trongnuocNgoainuoc.Equals(value))
                {
                    _trongnuocNgoainuoc = value;
                    if (_trongnuocNgoainuoc == 1)
                        _trongnuocNgoainuocString = "Trong nước";
                    else if (_trongnuocNgoainuoc == 2)
                        _trongnuocNgoainuocString = "Ngoài nước";
                    PropertyHasChanged("TrongnuocNgoainuoc");
                }
            }
        }

        public byte KetQuaDaoTao
        {
            get
            {
                CanReadProperty("KetQuaDaoTao", true);
                return _ketQuaDaoTao;
            }
            set
            {
                CanWriteProperty("KetQuaDaoTao", true);
                if (!_ketQuaDaoTao.Equals(value))
                {
                    _ketQuaDaoTao = value;
                    if (_ketQuaDaoTao == 1)
                        _ketQuaDaoTaoString = "Không đạt";
                    else if (_ketQuaDaoTao == 2)
                        _ketQuaDaoTaoString = "Đạt";
                    ////Set Da nop bang
                    if (_ketQuaDaoTao == 1 || _ketQuaDaoTao == 0)//khong Dat,<Chua co>
                    {
                        _daNopBang = false;
                        _daNopBangString = "Chưa nộp bằng";
                    }
                    //else if (_ketQuaDaoTao == 2)//Dat
                    //    _daNopBang = true;
                    PropertyHasChanged("KetQuaDaoTao");
                }
            }
        }

        [DisplayName("Chi Tiết Đề Cử")]
        public int MaChiTietDeCu
        {
            get
            {
                CanReadProperty("MaChiTietDeCu", true);
                return _maChiTietDeCu;
            }
            set
            {
                CanWriteProperty("MaChiTietDeCu", true);
                if (!_maChiTietDeCu.Equals(value))
                {
                    _maChiTietDeCu = value;
                    PropertyHasChanged("MaChiTietDeCu");
                }
            }
        }

        public int MaDonViDaoTao
        {
            get
            {
                CanReadProperty("MaDonViDaoTao", true);
                return _maDonViDaoTao;
            }
            set
            {
                CanWriteProperty("MaDonViDaoTao", true);
                if (!_maDonViDaoTao.Equals(value))
                {
                    _maDonViDaoTao = value;
                    if (_maDonViDaoTao != 0)
                        _tenDonViDaoTao = DonViDaoTao.GetDonViDaoTao(_maDonViDaoTao).TenDonViDaoTao;
                    PropertyHasChanged("MaDonViDaoTao");
                }
            }
        }

        #region Bo Sung Ngoai

        public string TenNhanVien
        {
            get
            {
                return _tenNhanVien;
            }
        }
        public string MaQLNhanVien
        {
            get
            {
                return _maQLNhanVien;
            }
        }
        public string BoPhanNhanVien
        {
            get
            {
                return _boPhanNhanVien;
            }
        }
        public string VanbangChungchiString
        {
            get
            {
                //return _lopHoc.VanbangChungChiString;
                return _vanbangChungchiString;
            }
        }
        public string LoaiVanBangString
        {
            get
            {
                //return _lopHoc.LoaiVanBangString;
                return _loaiVanBangString;
            }
        }
        public string QuocGiaCapString
        {
            get
            {
                //return _lopHoc.QuocGiaCap;
                return _quocGiaCapString;
            }
        }
        public string TruongDaoTaostring
        {
            get
            {
                //return _lopHoc.TenTruongDaoTao;
                return _truongDaoTaostring;
            }
        }
        public string DaNopBangString
        {
            get
            {
                return _daNopBangString;
            }
            set
            {
                _daNopBangString = value;
            }
        }
        public string ChuyenNganhDaoTaoString
        {
            get
            {
                //return _lopHoc.TenChuyenNganhDaoTao;
                return _chuyenNganhDaoTaoString;
            }
        }
        public string TrongnuocNgoainuocString
        {
            get
            {
                //return _lopHoc.TrongnuocNgoainuocString;
                return _trongnuocNgoainuocString;
            }
        }

        public string KetQuaDaoTaoString
        {
            get
            {
                return _ketQuaDaoTaoString;
            }
        }

        public decimal SoGioHoc
        {
            get
            {
                if (_maChiTietDeCu != 0)
                {
                    int maDeCu = GetMaDeCu(_maChiTietDeCu);
                    if (maDeCu != 0)
                    {
                        return DeCu.GetDeCuWithLichHoc(maDeCu).SoGioHoc;
                    }
                }
                return 0;
            }
        }

        public decimal SoNgayHoc
        {
            get
            {
                if (_maChiTietDeCu != 0)
                {
                    int maDeCu = GetMaDeCu(_maChiTietDeCu);
                    if (maDeCu != 0)
                    {
                        return DeCu.GetDeCuWithLichHoc(maDeCu).SoNgayHoc;
                    }
                }
                return 0;
            }
        }

        public string TenLoaiLop
        {
            get
            {
                return _tenLoaiLop;
                //if (_lopHoc != null)
                //    return _lopHoc.TenLoaiLop;
                //return "";
            }
        }

        public DateTime? NgayBatDauChinhThuc
        {
            get
            {
                CanReadProperty("NgayBatDauChinhThuc", true);
                if (_ngayBatDauChinhThuc.Date == DateTime.MinValue)
                    return null;
                return _ngayBatDauChinhThuc.Date;

                //if (_lopHoc != null)
                //    return _lopHoc.NgayBatDauChinhThuc;
                //return null;
            }
        }

        public DateTime? NgayKetThucChinhThuc
        {
            get
            {
                CanReadProperty("NgayKetThucChinhThuc", true);
                if (_ngayKetThucChinhThuc.Date == DateTime.MinValue)
                    return null;
                return _ngayKetThucChinhThuc.Date;

                //if (_lopHoc != null)
                //    return _lopHoc.NgayKetThucChinhThuc;
                //return null;
            }
        }

        public string TenDonViDaoTao
        {
            get
            {
                //return _lopHoc.TenDonViDaoTao;
                return _tenDonViDaoTao;
            }
        }
        #endregion

        protected override object GetIdValue()
        {
            return _maQuaTrinhDaoTao;
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
            // XepLoai
            //
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("XepLoai", 50));
            //
            // TenvanbangChungchi
            //
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("TenvanbangChungchi", 500));
            //
            // NguoiKy
            //
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("NguoiKy", 100));
            //
            // SovanbangChungchi
            //
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("SovanbangChungchi", 50));
            //
            // GhiChu
            //
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("GhiChu", 500));
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
            //TODO: Define authorization rules in QuaTrinhDaoTaoNhanLuc
            //AuthorizationRules.AllowRead("MaQuaTrinhDaoTao", "QuaTrinhDaoTaoNhanLucReadGroup");
            //AuthorizationRules.AllowRead("MaNhanVien", "QuaTrinhDaoTaoNhanLucReadGroup");
            //AuthorizationRules.AllowRead("NamTotNghiep", "QuaTrinhDaoTaoNhanLucReadGroup");
            //AuthorizationRules.AllowRead("XepLoai", "QuaTrinhDaoTaoNhanLucReadGroup");
            //AuthorizationRules.AllowRead("NgayCap", "QuaTrinhDaoTaoNhanLucReadGroup");
            //AuthorizationRules.AllowRead("NgayCapString", "QuaTrinhDaoTaoNhanLucReadGroup");
            //AuthorizationRules.AllowRead("VanbangChungchi", "QuaTrinhDaoTaoNhanLucReadGroup");
            //AuthorizationRules.AllowRead("TenvanbangChungchi", "QuaTrinhDaoTaoNhanLucReadGroup");
            //AuthorizationRules.AllowRead("NguoiKy", "QuaTrinhDaoTaoNhanLucReadGroup");
            //AuthorizationRules.AllowRead("SovanbangChungchi", "QuaTrinhDaoTaoNhanLucReadGroup");
            //AuthorizationRules.AllowRead("GhiChu", "QuaTrinhDaoTaoNhanLucReadGroup");
            //AuthorizationRules.AllowRead("MaNguoiLap", "QuaTrinhDaoTaoNhanLucReadGroup");
            //AuthorizationRules.AllowRead("NgayLap", "QuaTrinhDaoTaoNhanLucReadGroup");
            //AuthorizationRules.AllowRead("NgayLapString", "QuaTrinhDaoTaoNhanLucReadGroup");
            //AuthorizationRules.AllowRead("LoaiVanBang", "QuaTrinhDaoTaoNhanLucReadGroup");
            //AuthorizationRules.AllowRead("MaQuocGiaCap", "QuaTrinhDaoTaoNhanLucReadGroup");
            //AuthorizationRules.AllowRead("MaTruongDaoTao", "QuaTrinhDaoTaoNhanLucReadGroup");
            //AuthorizationRules.AllowRead("DaNopBang", "QuaTrinhDaoTaoNhanLucReadGroup");
            //AuthorizationRules.AllowRead("ChuyenTTNhanVien", "QuaTrinhDaoTaoNhanLucReadGroup");
            //AuthorizationRules.AllowRead("MaChuyenNganhDaoTao", "QuaTrinhDaoTaoNhanLucReadGroup");
            //AuthorizationRules.AllowRead("TrongnuocNgoainuoc", "QuaTrinhDaoTaoNhanLucReadGroup");

            //AuthorizationRules.AllowWrite("MaNhanVien", "QuaTrinhDaoTaoNhanLucWriteGroup");
            //AuthorizationRules.AllowWrite("NamTotNghiep", "QuaTrinhDaoTaoNhanLucWriteGroup");
            //AuthorizationRules.AllowWrite("XepLoai", "QuaTrinhDaoTaoNhanLucWriteGroup");
            //AuthorizationRules.AllowWrite("NgayCapString", "QuaTrinhDaoTaoNhanLucWriteGroup");
            //AuthorizationRules.AllowWrite("VanbangChungchi", "QuaTrinhDaoTaoNhanLucWriteGroup");
            //AuthorizationRules.AllowWrite("TenvanbangChungchi", "QuaTrinhDaoTaoNhanLucWriteGroup");
            //AuthorizationRules.AllowWrite("NguoiKy", "QuaTrinhDaoTaoNhanLucWriteGroup");
            //AuthorizationRules.AllowWrite("SovanbangChungchi", "QuaTrinhDaoTaoNhanLucWriteGroup");
            //AuthorizationRules.AllowWrite("GhiChu", "QuaTrinhDaoTaoNhanLucWriteGroup");
            //AuthorizationRules.AllowWrite("MaNguoiLap", "QuaTrinhDaoTaoNhanLucWriteGroup");
            //AuthorizationRules.AllowWrite("NgayLapString", "QuaTrinhDaoTaoNhanLucWriteGroup");
            //AuthorizationRules.AllowWrite("LoaiVanBang", "QuaTrinhDaoTaoNhanLucWriteGroup");
            //AuthorizationRules.AllowWrite("MaQuocGiaCap", "QuaTrinhDaoTaoNhanLucWriteGroup");
            //AuthorizationRules.AllowWrite("MaTruongDaoTao", "QuaTrinhDaoTaoNhanLucWriteGroup");
            //AuthorizationRules.AllowWrite("DaNopBang", "QuaTrinhDaoTaoNhanLucWriteGroup");
            //AuthorizationRules.AllowWrite("ChuyenTTNhanVien", "QuaTrinhDaoTaoNhanLucWriteGroup");
            //AuthorizationRules.AllowWrite("MaChuyenNganhDaoTao", "QuaTrinhDaoTaoNhanLucWriteGroup");
            //AuthorizationRules.AllowWrite("TrongnuocNgoainuoc", "QuaTrinhDaoTaoNhanLucWriteGroup");
        }


        public static bool CanGetObject()
        {
            //TODO: Define CanGetObject permission in QuaTrinhDaoTaoNhanLuc
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("QuaTrinhDaoTaoNhanLucViewGroup"))
            //	return true;
            //return false;
        }

        public static bool CanAddObject()
        {
            //TODO: Define CanAddObject permission in QuaTrinhDaoTaoNhanLuc
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("QuaTrinhDaoTaoNhanLucAddGroup"))
            //	return true;
            //return false;
        }

        public static bool CanEditObject()
        {
            //TODO: Define CanEditObject permission in QuaTrinhDaoTaoNhanLuc
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("QuaTrinhDaoTaoNhanLucEditGroup"))
            //	return true;
            //return false;
        }

        public static bool CanDeleteObject()
        {
            //TODO: Define CanDeleteObject permission in QuaTrinhDaoTaoNhanLuc
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("QuaTrinhDaoTaoNhanLucDeleteGroup"))
            //	return true;
            //return false;
        }
        #endregion //Authorization Rules

        #region Factory Methods
        private QuaTrinhDaoTaoNhanLuc()
        { /* require use of factory method */ }

        public static QuaTrinhDaoTaoNhanLuc NewQuaTrinhDaoTaoNhanLuc()
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a QuaTrinhDaoTaoNhanLuc");
            return DataPortal.Create<QuaTrinhDaoTaoNhanLuc>();
        }

        public static QuaTrinhDaoTaoNhanLuc NewQuaTrinhDaoTaoNhanLuc(ChiTietDeCuNhanVien ctdc)
        {
            return new QuaTrinhDaoTaoNhanLuc(ctdc);
        }

        private QuaTrinhDaoTaoNhanLuc(ChiTietDeCuNhanVien ctdc)
        {
            _maChiTietDeCu = ctdc.MaChiTiet;
            if (_maChiTietDeCu != 0)
            {
                int malophoc = GetMaLopHoc(_maChiTietDeCu);
                if (malophoc != 0)
                {
                    _lopHoc = LopHoc.GetLopHoc(malophoc);
                }
            }
            _maNhanVien = ctdc.MaNhanVien;
            _tenNhanVien = ctdc.TenNhanVien;//
            _maQLNhanVien = ctdc.MaQLNhanVien;//

            #region BoSung
            _loaiVanBang = _lopHoc.LoaiVanBang;
            _loaiVanBangString = _lopHoc.LoaiVanBangString;//
            _maChuyenNganhDaoTao = _lopHoc.MaChuyenNganhDaoTao;
            _chuyenNganhDaoTaoString = _lopHoc.TenChuyenNganhDaoTao;//
            _maQuocGiaCap = _lopHoc.MaQuocGiaCap;
            _quocGiaCapString = _lopHoc.QuocGiaCap;//
            _maTruongDaoTao = _lopHoc.MaTruongDaoTao;
            _truongDaoTaostring = _lopHoc.TenTruongDaoTao;//
            _tenvanbangChungchi = _lopHoc.TenvanbangChungchi;
            _vanbangChungchi = _lopHoc.VanbangChungChi;
            _vanbangChungchiString = _lopHoc.VanbangChungChiString;//
            _trongnuocNgoainuoc = _lopHoc.TrongnuocNgoainuoc;
            _trongnuocNgoainuocString = _lopHoc.TrongnuocNgoainuocString;//
            _maDonViDaoTao = _lopHoc.MaDonViDaoTao;
            _tenDonViDaoTao = _lopHoc.TenDonViDaoTao;//
            _tenLoaiLop = _lopHoc.TenLoaiLop;
            _ngayBatDauChinhThuc = new SmartDate(_lopHoc.NgayBatDauChinhThuc.Value.Date);
            _ngayKetThucChinhThuc = new SmartDate(_lopHoc.NgayKetThucChinhThuc.Value.Date);
            #endregion//End BoSung

            _ghiChu = ctdc.GhiChu;

           

            ValidationRules.CheckRules();
            MarkAsChild();
        }

        public static QuaTrinhDaoTaoNhanLuc GetQuaTrinhDaoTaoNhanLuc(int maQuaTrinhDaoTao)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a QuaTrinhDaoTaoNhanLuc");
            return DataPortal.Fetch<QuaTrinhDaoTaoNhanLuc>(new Criteria(maQuaTrinhDaoTao));
        }

        public static void DeleteQuaTrinhDaoTaoNhanLuc(int maQuaTrinhDaoTao)
        {
            if (!CanDeleteObject())
                throw new System.Security.SecurityException("User not authorized to remove a QuaTrinhDaoTaoNhanLuc");
            DataPortal.Delete(new Criteria(maQuaTrinhDaoTao));
        }

        #region Bosung
        public static void DeleteQuaTrinhDaoTaoNhanLuc(QuaTrinhDaoTaoNhanLuc quaTrinhDaoTaoNhanLuc)
        {//B
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
                        cm.CommandText = "spd_DeletetblnsQuaTrinhDaoTaoNhanSu";

                        cm.Parameters.AddWithValue("@MaQuaTrinhDaoTao", quaTrinhDaoTaoNhanLuc.MaQuaTrinhDaoTao);

                        cm.ExecuteNonQuery();
                    }//using
                    tr.Commit();
                }
                catch (SqlException ex)
                {
                    tr.Rollback();
                    throw ex;
                }
            }

        }//E

        public static void UpdateVanBangChungChiSangNhanSu(int maQuaTrinhDaoTao)
        {//B
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
                        cm.CommandText = "spd_UpdateVanBangChungChiSangNhanSu";

                        cm.Parameters.AddWithValue("@MaQuaTrinhDaoTao", maQuaTrinhDaoTao);

                        cm.ExecuteNonQuery();
                    }//using
                    tr.Commit();
                }
                catch (SqlException ex)
                {
                    tr.Rollback();
                    throw ex;
                }
            }

        }//E

        public static DataTable GetDSThoiDoiNopVanBang(int maLopHoc, int loaiVanBang, int maQuocGiaCap, int maTruongDaoTao, int maChuyenNganhDaoTao, byte trongnuocNgoainuoc, byte phuongThucTim, int nam, int maDonViDaoTao)
        {//phuongThucTim 1:DaQuaHanNopBang; 2:DaNopBang; 3: ChuaNopBang; 4: TatCa
            DataTable dt = new DataTable();
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {

                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandTimeout = 1800;
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "Spd_GetDSThoiDoiNopVanBang";
                    cm.Parameters.AddWithValue("@MaLopHoc", maLopHoc);
                    cm.Parameters.AddWithValue("@LoaiVanBang", loaiVanBang);
                    cm.Parameters.AddWithValue("@MaQuocGiaCap", maQuocGiaCap);
                    cm.Parameters.AddWithValue("@MaTruongDaoTao", maTruongDaoTao);
                    cm.Parameters.AddWithValue("@MaChuyenNganhDaoTao", maChuyenNganhDaoTao);
                    cm.Parameters.AddWithValue("@TrongnuocNgoainuoc", trongnuocNgoainuoc);
                    cm.Parameters.AddWithValue("@PhuongThucTim", phuongThucTim);
                    cm.Parameters.AddWithValue("@NgayHienTai", DateTime.Today.Date);
                    cm.Parameters.AddWithValue("@Nam", nam);
                    cm.Parameters.AddWithValue("@MaDonViDaoTao", maDonViDaoTao);
                    using (SqlDataAdapter da = new SqlDataAdapter(cm))
                    {
                        DataSet ds = new DataSet();
                        da.Fill(ds);

                        if (ds != null && ds.Tables.Count > 0)
                            dt = ds.Tables[0];
                    }
                }
            }//us
            return dt;
        }

        public static int GetMaDeCu(int maChiTietDeCu)
        {
            int result;
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "Spd_GetMaDeCubyMaChiTietDeCu";
                    cm.Parameters.AddWithValue("@MaChiTietDeCu", maChiTietDeCu);
                    SqlParameter outPara = new SqlParameter("@MaDeCu", SqlDbType.Int);
                    outPara.Direction = ParameterDirection.Output;
                    cm.Parameters.Add(outPara);
                    cm.ExecuteNonQuery();
                    result = (int)outPara.Value;
                }
            }//end using

            return result;
        }

        #region XuLy t/h CapNhatTrinhDoHocVan khi ChuyenNganhChinh thay doi
        public static int GetTrinhDoChuyenMon(int maNhanVien_ChuyenNganh)
        {
            int result;
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "Spd_GetTrinhDoChuyenMon";
                    cm.Parameters.AddWithValue("@MaNhanVien_ChuyenNganh", maNhanVien_ChuyenNganh);
                    SqlParameter outPara = new SqlParameter("@MaTrinhDoChuyenNganh", SqlDbType.Int);
                    outPara.Direction = ParameterDirection.Output;
                    cm.Parameters.Add(outPara);
                    cm.ExecuteNonQuery();
                    result = (int)outPara.Value;
                }
            }//end using

            return result;
        }
        #endregion//XuLy t/h CapNhatTrinhDoHocVan khi ChuyenNganhChinh thay doi

        public static int GetMaLopHoc(int maChiTietDeCu)
        {
            int result;
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "Spd_GetMaLopHocbyMaChiTietDeCu";
                    cm.Parameters.AddWithValue("@MaChiTietDeCu", maChiTietDeCu);
                    SqlParameter outPara = new SqlParameter("@MaLopHoc", SqlDbType.Int);
                    outPara.Direction = ParameterDirection.Output;
                    cm.Parameters.Add(outPara);
                    cm.ExecuteNonQuery();
                    result = (int)outPara.Value;
                }
            }//end using

            return result;
        }
        #endregion

        public override QuaTrinhDaoTaoNhanLuc Save()
        {
            if (IsDeleted && !CanDeleteObject())
                throw new System.Security.SecurityException("User not authorized to remove a QuaTrinhDaoTaoNhanLuc");
            else if (IsNew && !CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a QuaTrinhDaoTaoNhanLuc");
            else if (!CanEditObject())
                throw new System.Security.SecurityException("User not authorized to update a QuaTrinhDaoTaoNhanLuc");

            return base.Save();
        }

        #endregion //Factory Methods

        #region Child Factory Methods
        internal static QuaTrinhDaoTaoNhanLuc NewQuaTrinhDaoTaoNhanLucChild()
        {
            QuaTrinhDaoTaoNhanLuc child = new QuaTrinhDaoTaoNhanLuc();
            child.ValidationRules.CheckRules();
            child.MarkAsChild();
            return child;
        }

        internal static QuaTrinhDaoTaoNhanLuc GetQuaTrinhDaoTaoNhanLuc(SafeDataReader dr)
        {
            QuaTrinhDaoTaoNhanLuc child = new QuaTrinhDaoTaoNhanLuc();
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
            public int MaQuaTrinhDaoTao;

            public Criteria(int maQuaTrinhDaoTao)
            {
                this.MaQuaTrinhDaoTao = maQuaTrinhDaoTao;
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
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();

                ExecuteFetch(cn, criteria);
            }//using
        }

        private void ExecuteFetch(SqlConnection cn, Criteria criteria)
        {
            using (SqlCommand cm = cn.CreateCommand())
            {
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_SelecttblnsQuaTrinhDaoTaoNhanSu";

                cm.Parameters.AddWithValue("@MaQuaTrinhDaoTao", criteria.MaQuaTrinhDaoTao);

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
            DataPortal_Delete(new Criteria(_maQuaTrinhDaoTao));
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
                cm.CommandText = "spd_DeletetblnsQuaTrinhDaoTaoNhanSu";

                cm.Parameters.AddWithValue("@MaQuaTrinhDaoTao", criteria.MaQuaTrinhDaoTao);

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
            _maQuaTrinhDaoTao = dr.GetInt32("MaQuaTrinhDaoTao");
            _maNhanVien = dr.GetInt64("MaNhanVien");
            _tenNhanVien = dr.GetString("TenNhanVien");
            _maQLNhanVien = dr.GetString("MaQLNhanVien");
            _boPhanNhanVien = dr.GetString("BoPhanNhanVien");
            //if (_maNhanVien != 0)
            //{
            //    _tenNhanVien = ThongTinNhanVienTongHop.GetThongTinNhanVienTongHop(_maNhanVien).TenNhanVien;
            //    _maQLNhanVien = ThongTinNhanVienTongHop.GetThongTinNhanVienTongHop(_maNhanVien).MaQLNhanVien;
            //    _boPhanNhanVien = ThongTinNhanVienTongHop.GetThongTinNhanVienTongHop(_maNhanVien).TenBoPhan;
            //}
            _namTotNghiep = dr.GetInt32("NamTotNghiep");
            _xepLoai = dr.GetString("XepLoai");
            _ngayCap = dr.GetSmartDate("NgayCap", _ngayCap.EmptyIsMin);
            _vanbangChungchi = dr.GetByte("VanBang_ChungChi");
            //if (_vanbangChungchi == 1)
            //    _vanbangChungchiString = "Văn bằng";
            //else if (_vanbangChungchi == 2)
            //    _vanbangChungchiString = "Chứng chỉ";
            //_tenvanbangChungchi = dr.GetString("TenVanBang_ChungChi");
            _nguoiKy = dr.GetString("NguoiKy");
            //_sovanbangChungchi = dr.GetString("SoVanBang_ChungChi");
            _ghiChu = dr.GetString("GhiChu");
            _maNguoiLap = dr.GetInt32("MaNguoiLap");
            _ngayLap = dr.GetSmartDate("NgayLap", _ngayLap.EmptyIsMin);
            _ngayHeThong = dr.GetSmartDate("NgayHeThong", _ngayHeThong.EmptyIsMin);
            _loaiVanBang = dr.GetInt32("LoaiVanBang");
            //if (_loaiVanBang != 0)
            //    _loaiVanBangString = TrinhDoHocVanClass.GetTrinhDoHocVanClass(_loaiVanBang).TrinhDoHocVan;
            _maQuocGiaCap = dr.GetInt32("MaQuocGiaCap");
            //if (_maQuocGiaCap != 0)
            //    _quocGiaCapString = QuocGia.GetQuocGia(_maQuocGiaCap).TenQuocGia;
            _maTruongDaoTao = dr.GetInt32("MaTruongDaoTao");
            //if (_maTruongDaoTao != 0)
            //    _truongDaoTaostring = TruongDaoTao.GetTruongDaoTao(_maTruongDaoTao).TenTruongDaoTao;
            _daNopBang = dr.GetBoolean("DaNopBang");
            if (_daNopBang)
                _daNopBangString = "Đã nộp bằng";
            else _daNopBangString = "Chưa nộp bằng";
            _chuyenTTNhanVien = dr.GetBoolean("ChuyenTTNhanVien");
            _maChuyenNganhDaoTao = dr.GetInt32("MaChuyenNganhDaoTao");
            //if (_maChuyenNganhDaoTao != 0)
            //    _chuyenNganhDaoTaoString = ChuyenNganhDaoTaoClass.GetChuyenNganhDaoTaoClass(_maChuyenNganhDaoTao).ChuyenNganhDaoTao;
            _trongnuocNgoainuoc = dr.GetByte("TrongNuoc_NgoaiNuoc");
            //if (_trongnuocNgoainuoc == 1)
            //    _trongnuocNgoainuocString = "Trong nước";
            //else if (_trongnuocNgoainuoc == 2)
            //    _trongnuocNgoainuocString = "Ngoài nước";

            _ketQuaDaoTao = dr.GetByte("KetQuaDaoTao");
            if (_ketQuaDaoTao == 1)
                _ketQuaDaoTaoString = "Không đạt";
            else if (_ketQuaDaoTao == 2)
                _ketQuaDaoTaoString = "Đạt";

            _maChiTietDeCu = dr.GetInt32("MaChiTietDeCu");

            //if (_maChiTietDeCu != 0)
            //{
            //    int malophoc = GetMaLopHoc(_maChiTietDeCu);
            //    if (malophoc != 0)
            //    {
            //        _lopHoc = LopHoc.GetLopHoc(malophoc);
            //    }
            //}
            //_lopHoc.TenvanbangChungchi
            // _lopHoc.LoaiVanBangString
            //_lopHoc.QuocGiaCap
            //_lopHoc.TenTruongDaoTao
            //_lopHoc.TenChuyenNganhDaoTao
            //_lopHoc.TrongnuocNgoainuocString
            //_lopHoc.TenLoaiLop
            //_lopHoc.NgayBatDauChinhThuc
            //_lopHoc.NgayKetThucChinhThuc
            // _lopHoc.TenDonViDaoTao
            _tenvanbangChungchi = dr.GetString("TenvanbangChungchi2");
            _loaiVanBangString = dr.GetString("LoaiVanBangString");
            _quocGiaCapString = dr.GetString("QuocGiaCapString");
            _truongDaoTaostring = dr.GetString("TruongDaoTaostring");
            _chuyenNganhDaoTaoString = dr.GetString("ChuyenNganhDaoTaoString");
            _trongnuocNgoainuocString = dr.GetString("TrongnuocNgoainuocString");
            _tenLoaiLop = dr.GetString("TenLoaiLop");
            _ngayBatDauChinhThuc = dr.GetSmartDate("NgayBatDauChinhThuc", _ngayCap.EmptyIsMin);
            _ngayKetThucChinhThuc = dr.GetSmartDate("NgayKetThucChinhThuc", _ngayCap.EmptyIsMin);
            _tenDonViDaoTao = dr.GetString("TenDonViDaoTao");



            //_maDonViDaoTao = dr.GetInt32("MaDonViDaoTao");
            //if (_maDonViDaoTao != 0)
            //    _tenDonViDaoTao = DonViDaoTao.GetDonViDaoTao(_maDonViDaoTao).TenDonViDaoTao;

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
                cm.CommandText = "spd_InserttblnsQuaTrinhDaoTaoNhanSu";

                AddInsertParameters(cm);

                cm.ExecuteNonQuery();

                _maQuaTrinhDaoTao = (int)cm.Parameters["@MaQuaTrinhDaoTao"].Value;
            }//using
        }

        private void AddInsertParameters(SqlCommand cm)
        {
            cm.Parameters.AddWithValue("@MaNhanVien", _maNhanVien);
            if (_namTotNghiep != 0)
                cm.Parameters.AddWithValue("@NamTotNghiep", _namTotNghiep);
            else
                cm.Parameters.AddWithValue("@NamTotNghiep", DBNull.Value);
            if (_xepLoai.Length > 0)
                cm.Parameters.AddWithValue("@XepLoai", _xepLoai);
            else
                cm.Parameters.AddWithValue("@XepLoai", DBNull.Value);
            cm.Parameters.AddWithValue("@NgayCap", _ngayCap.DBValue);
            if (_vanbangChungchi != 0)
                cm.Parameters.AddWithValue("@VanBang_ChungChi", _vanbangChungchi);
            else
                cm.Parameters.AddWithValue("@VanBang_ChungChi", DBNull.Value);
            if (_tenvanbangChungchi.Length > 0)
                cm.Parameters.AddWithValue("@TenVanBang_ChungChi", _tenvanbangChungchi);
            else
                cm.Parameters.AddWithValue("@TenVanBang_ChungChi", DBNull.Value);
            if (_nguoiKy.Length > 0)
                cm.Parameters.AddWithValue("@NguoiKy", _nguoiKy);
            else
                cm.Parameters.AddWithValue("@NguoiKy", DBNull.Value);
            if (_sovanbangChungchi.Length > 0)
                cm.Parameters.AddWithValue("@SoVanBang_ChungChi", _sovanbangChungchi);
            else
                cm.Parameters.AddWithValue("@SoVanBang_ChungChi", DBNull.Value);
            if (_ghiChu.Length > 0)
                cm.Parameters.AddWithValue("@GhiChu", _ghiChu);
            else
                cm.Parameters.AddWithValue("@GhiChu", DBNull.Value);
            if (_maNguoiLap != 0)
                cm.Parameters.AddWithValue("@MaNguoiLap", _maNguoiLap);
            else
                cm.Parameters.AddWithValue("@MaNguoiLap", ERP_Library.Security.CurrentUser.Info.UserID);
            cm.Parameters.AddWithValue("@NgayLap", _ngayLap.DBValue);
            cm.Parameters.AddWithValue("@NgayHeThong", _ngayHeThong.DBValue);
            if (_loaiVanBang != 0)
                cm.Parameters.AddWithValue("@LoaiVanBang", _loaiVanBang);
            else
                cm.Parameters.AddWithValue("@LoaiVanBang", DBNull.Value);
            if (_maQuocGiaCap != 0)
                cm.Parameters.AddWithValue("@MaQuocGiaCap", _maQuocGiaCap);
            else
                cm.Parameters.AddWithValue("@MaQuocGiaCap", DBNull.Value);
            if (_maTruongDaoTao != 0)
                cm.Parameters.AddWithValue("@MaTruongDaoTao", _maTruongDaoTao);
            else
                cm.Parameters.AddWithValue("@MaTruongDaoTao", DBNull.Value);
            if (_daNopBang != false)
                cm.Parameters.AddWithValue("@DaNopBang", _daNopBang);
            else
                cm.Parameters.AddWithValue("@DaNopBang", DBNull.Value);
            if (_chuyenTTNhanVien != false)
                cm.Parameters.AddWithValue("@ChuyenTTNhanVien", _chuyenTTNhanVien);
            else
                cm.Parameters.AddWithValue("@ChuyenTTNhanVien", DBNull.Value);
            if (_maChuyenNganhDaoTao != 0)
                cm.Parameters.AddWithValue("@MaChuyenNganhDaoTao", _maChuyenNganhDaoTao);
            else
                cm.Parameters.AddWithValue("@MaChuyenNganhDaoTao", DBNull.Value);
            if (_trongnuocNgoainuoc != 0)
                cm.Parameters.AddWithValue("@TrongNuoc_NgoaiNuoc", _trongnuocNgoainuoc);
            else
                cm.Parameters.AddWithValue("@TrongNuoc_NgoaiNuoc", DBNull.Value);
            if (_maChiTietDeCu != 0)
                cm.Parameters.AddWithValue("@MaChiTietDeCu", _maChiTietDeCu);
            else
                cm.Parameters.AddWithValue("@MaChiTietDeCu", DBNull.Value);

            if (_ketQuaDaoTao != 0)
                cm.Parameters.AddWithValue("@KetQuaDaoTao", _ketQuaDaoTao);
            else
                cm.Parameters.AddWithValue("@KetQuaDaoTao", DBNull.Value);

            if (_maDonViDaoTao != 0)
                cm.Parameters.AddWithValue("@MaDonViDaoTao", _maDonViDaoTao);
            else
                cm.Parameters.AddWithValue("@MaDonViDaoTao", DBNull.Value);

            cm.Parameters.AddWithValue("@MaQuaTrinhDaoTao", _maQuaTrinhDaoTao);
            cm.Parameters["@MaQuaTrinhDaoTao"].Direction = ParameterDirection.Output;
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
                cm.CommandText = "spd_UpdatetblnsQuaTrinhDaoTaoNhanSu";

                AddUpdateParameters(cm);

                cm.ExecuteNonQuery();

            }//using
        }

        private void AddUpdateParameters(SqlCommand cm)
        {
            cm.Parameters.AddWithValue("@MaQuaTrinhDaoTao", _maQuaTrinhDaoTao);
            cm.Parameters.AddWithValue("@MaNhanVien", _maNhanVien);
            if (_namTotNghiep != 0)
                cm.Parameters.AddWithValue("@NamTotNghiep", _namTotNghiep);
            else
                cm.Parameters.AddWithValue("@NamTotNghiep", DBNull.Value);
            if (_xepLoai.Length > 0)
                cm.Parameters.AddWithValue("@XepLoai", _xepLoai);
            else
                cm.Parameters.AddWithValue("@XepLoai", DBNull.Value);
            cm.Parameters.AddWithValue("@NgayCap", _ngayCap.DBValue);
            if (_vanbangChungchi != 0)
                cm.Parameters.AddWithValue("@VanBang_ChungChi", _vanbangChungchi);
            else
                cm.Parameters.AddWithValue("@VanBang_ChungChi", DBNull.Value);
            if (_tenvanbangChungchi.Length > 0)
                cm.Parameters.AddWithValue("@TenVanBang_ChungChi", _tenvanbangChungchi);
            else
                cm.Parameters.AddWithValue("@TenVanBang_ChungChi", DBNull.Value);
            if (_nguoiKy.Length > 0)
                cm.Parameters.AddWithValue("@NguoiKy", _nguoiKy);
            else
                cm.Parameters.AddWithValue("@NguoiKy", DBNull.Value);
            if (_sovanbangChungchi.Length > 0)
                cm.Parameters.AddWithValue("@SoVanBang_ChungChi", _sovanbangChungchi);
            else
                cm.Parameters.AddWithValue("@SoVanBang_ChungChi", DBNull.Value);
            if (_ghiChu.Length > 0)
                cm.Parameters.AddWithValue("@GhiChu", _ghiChu);
            else
                cm.Parameters.AddWithValue("@GhiChu", DBNull.Value);
            if (_maNguoiLap != 0)
                cm.Parameters.AddWithValue("@MaNguoiLap", _maNguoiLap);
            else
                cm.Parameters.AddWithValue("@MaNguoiLap", ERP_Library.Security.CurrentUser.Info.UserID);
            cm.Parameters.AddWithValue("@NgayLap", _ngayLap.DBValue);
            cm.Parameters.AddWithValue("@NgayHeThong", _ngayHeThong.DBValue);
            if (_loaiVanBang != 0)
                cm.Parameters.AddWithValue("@LoaiVanBang", _loaiVanBang);
            else
                cm.Parameters.AddWithValue("@LoaiVanBang", DBNull.Value);
            if (_maQuocGiaCap != 0)
                cm.Parameters.AddWithValue("@MaQuocGiaCap", _maQuocGiaCap);
            else
                cm.Parameters.AddWithValue("@MaQuocGiaCap", DBNull.Value);
            if (_maTruongDaoTao != 0)
                cm.Parameters.AddWithValue("@MaTruongDaoTao", _maTruongDaoTao);
            else
                cm.Parameters.AddWithValue("@MaTruongDaoTao", DBNull.Value);
            if (_daNopBang != false)
                cm.Parameters.AddWithValue("@DaNopBang", _daNopBang);
            else
                cm.Parameters.AddWithValue("@DaNopBang", DBNull.Value);
            if (_chuyenTTNhanVien != false)
                cm.Parameters.AddWithValue("@ChuyenTTNhanVien", _chuyenTTNhanVien);
            else
                cm.Parameters.AddWithValue("@ChuyenTTNhanVien", DBNull.Value);
            if (_maChuyenNganhDaoTao != 0)
                cm.Parameters.AddWithValue("@MaChuyenNganhDaoTao", _maChuyenNganhDaoTao);
            else
                cm.Parameters.AddWithValue("@MaChuyenNganhDaoTao", DBNull.Value);
            if (_trongnuocNgoainuoc != 0)
                cm.Parameters.AddWithValue("@TrongNuoc_NgoaiNuoc", _trongnuocNgoainuoc);
            else
                cm.Parameters.AddWithValue("@TrongNuoc_NgoaiNuoc", DBNull.Value);
            if (_maChiTietDeCu != 0)
                cm.Parameters.AddWithValue("@MaChiTietDeCu", _maChiTietDeCu);
            else
                cm.Parameters.AddWithValue("@MaChiTietDeCu", DBNull.Value);

            if (_ketQuaDaoTao != 0)
                cm.Parameters.AddWithValue("@KetQuaDaoTao", _ketQuaDaoTao);
            else
                cm.Parameters.AddWithValue("@KetQuaDaoTao", DBNull.Value);

            if (_maDonViDaoTao != 0)
                cm.Parameters.AddWithValue("@MaDonViDaoTao", _maDonViDaoTao);
            else
                cm.Parameters.AddWithValue("@MaDonViDaoTao", DBNull.Value);
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

            ExecuteDelete(cn, new Criteria(_maQuaTrinhDaoTao));
            MarkNew();
        }
        #endregion //Data Access - Delete
        #endregion //Data Access
    }
}
