
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;
//16/7/2014
namespace ERP_Library
{
    [Serializable()]
    public class CT_PhieuNhapBQ : Csla.BusinessBase<CT_PhieuNhapBQ>
    {
        #region Business Properties and Methods

        //declare members
        private int _maChiTietPhieuNhap = 0;
        private long _maPhieuNhap = 0;
        private int _maHangHoa = 0;
        private int _maChuongTrinhCon = 0;//M Ban Quyen
        private decimal _donGia = 0;
        private decimal _thanhTien = 0;
        private decimal _soLuong = 0;
        private int _maDonViTinh = 0;
        private decimal _thoiLuong = 0;
        private string _dienGiai = string.Empty;
        private decimal _soLuongXuat = 0;
        private decimal _soLuongConLai = 0;
        //private SmartDate _ngayNghiemThu = new SmartDate(DateTime.Today);
        private string _ngayNghiemThu = string.Empty;
        private int _maNguon = 0;
        private int _maChuongTrinh = 0;
        private int _maChuongTrinhCha = 0;
        //Me
        private bool _checkChon;
        [System.ComponentModel.DataObjectField(true, true)]
        public int MaChiTietPhieuNhap
        {
            get
            {
                CanReadProperty("MaChiTietPhieuNhap", true);
                return _maChiTietPhieuNhap;
            }
        }

        public long MaPhieuNhap
        {
            get
            {
                CanReadProperty("MaPhieuNhap", true);
                return _maPhieuNhap;
            }
            set
            {
                CanWriteProperty("MaPhieuNhap", true);
                if (!_maPhieuNhap.Equals(value))
                {
                    _maPhieuNhap = value;
                    PropertyHasChanged("MaPhieuNhap");
                }
            }
        }

        public int MaHangHoa
        {
            get
            {
                CanReadProperty("MaHangHoa", true);
                return _maHangHoa;
            }
            set
            {
                CanWriteProperty("MaHangHoa", true);
                if (!_maHangHoa.Equals(value))
                {
                    _maHangHoa = value;
                    PropertyHasChanged("MaHangHoa");
                }
            }
        }
        public int MaChuongTrinhCon//M Ban Quyen
        {
            get
            {
                CanReadProperty("MaChuongTrinhCon", true);
                return _maChuongTrinhCon;
            }
            set
            {
                CanWriteProperty("MaChuongTrinhCon", true);
                if (!_maChuongTrinhCon.Equals(value))
                {
                    _maChuongTrinhCon = value;
                    PropertyHasChanged("MaChuongTrinhCon");
                }
            }
        }

        public decimal DonGia
        {
            get
            {
                CanReadProperty("DonGia", true);
                return _donGia;
            }
            set
            {
                CanWriteProperty("DonGia", true);
                if (!_donGia.Equals(value))
                {
                    _donGia = value;
                    PropertyHasChanged("DonGia");
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
                    if (_soLuong != 0)
                        //_donGia = Math.Round(_thanhTien / (decimal)_soLuong);
                        _donGia = Math.Floor((_thanhTien / SoLuong));
                    PropertyHasChanged("ThanhTien");
                }
            }
        }

        public decimal SoLuong
        {
            get
            {
                CanReadProperty("SoLuong", true);
                return _soLuong;
            }
            set
            {
                CanWriteProperty("SoLuong", true);
                if (!_soLuong.Equals(value))
                {
                    _soLuong = value;
                    if (_soLuong != 0)
                        //_donGia = Math.Round(_thanhTien / (decimal)_soLuong, 0, MidpointRounding.AwayFromZero);
                        _donGia = Math.Floor((_thanhTien / SoLuong));
                    PropertyHasChanged("SoLuong");
                    _soLuongXuat = 0;//New 19112013
                    _soLuongConLai = 0;//New 19112013
                }
            }
        }

        public int MaDonViTinh
        {
            get
            {
                CanReadProperty("MaDonViTinh", true);
                return _maDonViTinh;
            }
            set
            {
                CanWriteProperty("MaDonViTinh", true);
                if (!_maDonViTinh.Equals(value))
                {
                    _maDonViTinh = value;
                    PropertyHasChanged("MaDonViTinh");
                }
            }
        }

        public decimal ThoiLuong
        {
            get
            {
                CanReadProperty("ThoiLuong", true);
                return _thoiLuong;
            }
            set
            {
                CanWriteProperty("ThoiLuong", true);
                if (!_thoiLuong.Equals(value))
                {
                    _thoiLuong = value;
                    PropertyHasChanged("ThoiLuong");
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

        public decimal SoLuongXuat
        {
            get
            {
                CanReadProperty("SoLuongXuat", true);
                return _soLuongXuat;
            }
            set
            {
                CanWriteProperty("SoLuongXuat", true);
                if (!_soLuongXuat.Equals(value))
                {
                    _soLuongXuat = value;
                    PropertyHasChanged("SoLuongXuat");
                }
            }
        }

        public decimal SoLuongConLai
        {
            get
            {
                CanReadProperty("SoLuongConLai", true);
                //return _soLuongConLai;
                return (_soLuong - _soLuongXuat);
            }
            set
            {
                CanWriteProperty("SoLuongConLai", true);
                if (!_soLuongConLai.Equals(value))
                {
                    _soLuongConLai = value;
                    PropertyHasChanged("SoLuongConLai");
                }
            }
        }
        public string NgayNghiemThu
        {
            get
            {
                CanReadProperty("NgayNghiemThu", true);
                return _ngayNghiemThu;
            }
            set
            {
                CanWriteProperty("NgayNghiemThu", true);
                if (!_ngayNghiemThu.Equals(value))
                {
                    _ngayNghiemThu = value;
                    PropertyHasChanged("NgayNghiemThu");
                }
            }
        }
        public int MaNguon
        {
            get
            {
                CanReadProperty("MaNguon", true);
                return _maNguon;
            }
            set
            {
                CanWriteProperty("MaNguon", true);
                if (!_maNguon.Equals(value))
                {
                    _maNguon = value;
                    PropertyHasChanged("MaNguon");
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
                if (!_maChuongTrinh.Equals(value))
                {
                    _maChuongTrinh = value;
                    PropertyHasChanged("MaChuongTrinh");
                }
            }
        }

        public int MaChuongTrinhCha
        {
            get
            {
                CanReadProperty("MaChuongTrinhCha", true);
                return _maChuongTrinhCha;
            }
            set
            {
                CanWriteProperty("MaChuongTrinhCha", true);
                if (!_maChuongTrinhCha.Equals(value))
                {
                    _maChuongTrinhCha = value;
                    PropertyHasChanged("MaChuongTrinhCha");
                }
            }
        }
        //Me
        public bool CheckChon
        {
            get { return _checkChon; }
            set { _checkChon = value; }
        }

        //Me
        protected override object GetIdValue()
        {
            return _maChiTietPhieuNhap;
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
            // DienGiai
            //
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("DienGiai", 1000));
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
            //TODO: Define authorization rules in CT_PhieuNhap
            //AuthorizationRules.AllowRead("MaChiTietPhieuNhap", "CT_PhieuNhapReadGroup");
            //AuthorizationRules.AllowRead("MaPhieuNhap", "CT_PhieuNhapReadGroup");
            //AuthorizationRules.AllowRead("MaHangHoa", "CT_PhieuNhapReadGroup");
            //AuthorizationRules.AllowRead("DonGia", "CT_PhieuNhapReadGroup");
            //AuthorizationRules.AllowRead("ThanhTien", "CT_PhieuNhapReadGroup");
            //AuthorizationRules.AllowRead("SoLuong", "CT_PhieuNhapReadGroup");
            //AuthorizationRules.AllowRead("MaDonViTinh", "CT_PhieuNhapReadGroup");
            //AuthorizationRules.AllowRead("ThoiLuong", "CT_PhieuNhapReadGroup");
            //AuthorizationRules.AllowRead("DienGiai", "CT_PhieuNhapReadGroup");
            //AuthorizationRules.AllowRead("SoLuongXuat", "CT_PhieuNhapReadGroup");
            //AuthorizationRules.AllowRead("SoLuongConLai", "CT_PhieuNhapReadGroup");

            //AuthorizationRules.AllowWrite("MaPhieuNhap", "CT_PhieuNhapWriteGroup");
            //AuthorizationRules.AllowWrite("MaHangHoa", "CT_PhieuNhapWriteGroup");
            //AuthorizationRules.AllowWrite("DonGia", "CT_PhieuNhapWriteGroup");
            //AuthorizationRules.AllowWrite("ThanhTien", "CT_PhieuNhapWriteGroup");
            //AuthorizationRules.AllowWrite("SoLuong", "CT_PhieuNhapWriteGroup");
            //AuthorizationRules.AllowWrite("MaDonViTinh", "CT_PhieuNhapWriteGroup");
            //AuthorizationRules.AllowWrite("ThoiLuong", "CT_PhieuNhapWriteGroup");
            //AuthorizationRules.AllowWrite("DienGiai", "CT_PhieuNhapWriteGroup");
            //AuthorizationRules.AllowWrite("SoLuongXuat", "CT_PhieuNhapWriteGroup");
            //AuthorizationRules.AllowWrite("SoLuongConLai", "CT_PhieuNhapWriteGroup");
        }

        #endregion //Authorization Rules

        #region Factory Methods
        internal static CT_PhieuNhapBQ NewCT_PhieuNhap()
        {
            return new CT_PhieuNhapBQ();
        }

        internal static CT_PhieuNhapBQ GetCT_PhieuNhap(SafeDataReader dr)
        {
            return new CT_PhieuNhapBQ(dr);
        }

        private CT_PhieuNhapBQ()
        {

            ValidationRules.CheckRules();
            MarkAsChild();
        }

        public CT_PhieuNhapBQ(CT_PhieuNhapBQ _ct_PhieuNhap)
        {
            _maChuongTrinhCon = _ct_PhieuNhap.MaChuongTrinhCon;
            _maHangHoa = _ct_PhieuNhap.MaHangHoa;
            _donGia = _ct_PhieuNhap.DonGia;
            //_thanhTien = _ct_PhieuNhap.ThanhTien;
            _soLuong = _ct_PhieuNhap.SoLuong;
            _maDonViTinh = _ct_PhieuNhap.MaDonViTinh;
            _thoiLuong = _ct_PhieuNhap.ThoiLuong;
            _ngayNghiemThu = _ct_PhieuNhap.NgayNghiemThu;
            _dienGiai = _ct_PhieuNhap.DienGiai;
            _maNguon = _ct_PhieuNhap.MaNguon;
            _maChuongTrinh = _ct_PhieuNhap.MaChuongTrinh;
            if (_maChuongTrinh != 0)
            {
                //Lay Chuong Trinh Cha
                {
                    int maCtCha = ChuongTrinh_New.GetChuongTrinh_New(_maChuongTrinh).MaChuongTrinhCha;
                    if (maCtCha != 0)
                    {
                        _maChuongTrinhCha = maCtCha;
                    }
                    else
                    {
                        _maChuongTrinhCha = _maChuongTrinh;
                    }
                }
            }
            //
            ValidationRules.CheckRules();
            MarkAsChild();
        }

        public CT_PhieuNhapBQ(CT_PhieuNhapBQ _ct_PhieuNhap,decimal soLuong, decimal thanhTien)
        {
            _maChuongTrinhCon = _ct_PhieuNhap.MaChuongTrinhCon;
            _maHangHoa = _ct_PhieuNhap.MaHangHoa;
            _thanhTien = thanhTien;//
            _soLuong = soLuong;//
            if (_soLuong != 0)
                _donGia = _thanhTien / _soLuong;
            _maDonViTinh = _ct_PhieuNhap.MaDonViTinh;
            _thoiLuong = _ct_PhieuNhap.ThoiLuong;
            _ngayNghiemThu = _ct_PhieuNhap.NgayNghiemThu;
            _dienGiai = _ct_PhieuNhap.DienGiai;
            _maNguon = _ct_PhieuNhap.MaNguon;
            _maChuongTrinh = _ct_PhieuNhap.MaChuongTrinh;
            if (_maChuongTrinh != 0)
            {
                //Lay Chuong Trinh Cha
                {
                    int maCtCha = ChuongTrinh_New.GetChuongTrinh_New(_maChuongTrinh).MaChuongTrinhCha;
                    if (maCtCha != 0)
                    {
                        _maChuongTrinhCha = maCtCha;
                    }
                    else
                    {
                        _maChuongTrinhCha = _maChuongTrinh;
                    }
                }
            }
            //
            ValidationRules.CheckRules();
            MarkAsChild();
        }

        private CT_PhieuNhapBQ(SafeDataReader dr)
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
            _maChiTietPhieuNhap = dr.GetInt32("MaChiTietPhieuNhap");
            _maPhieuNhap = dr.GetInt64("MaPhieuNhap");
            _maHangHoa = dr.GetInt32("MaHangHoa");
            _maChuongTrinhCon = dr.GetInt32("MaChuongTrinhCon");//M Ban Quyen
            _donGia = dr.GetDecimal("DonGia");
            _thanhTien = dr.GetDecimal("ThanhTien");
            _soLuong = dr.GetDecimal("SoLuong");
            _maDonViTinh = dr.GetInt32("MaDonViTinh");
            _thoiLuong = dr.GetDecimal("ThoiLuong");
            _dienGiai = dr.GetString("DienGiai");
            _soLuongXuat = dr.GetDecimal("SoLuongXuat");
            //_soLuongConLai = dr.GetDecimal("SoLuongConLai");
            _soLuongConLai = _soLuong - _soLuongXuat;
            //_ngayNghiemThu = dr.GetSmartDate("NgayNghiemThu", _ngayNghiemThu.EmptyIsMin);
            _ngayNghiemThu = dr.GetString("NgayNghiemThu");
            _maNguon = dr.GetInt32("MaNguon");
            _maChuongTrinh = dr.GetInt32("MaChuongTrinh");
            if (_maChuongTrinh != 0)
            {
                //Lay Chuong Trinh Cha
                {
                    int maCtCha = ChuongTrinh_New.GetChuongTrinh_New(_maChuongTrinh).MaChuongTrinhCha;
                    if (maCtCha != 0)
                    {
                        _maChuongTrinhCha = maCtCha;
                    }
                    else
                    {
                        _maChuongTrinhCha = _maChuongTrinh;
                    }
                }
            }
        }

        private void FetchChildren(SafeDataReader dr)
        {
        }
        #endregion //Data Access - Fetch

        #region Data Access - Insert
        internal void Insert(SqlTransaction tr, PhieuNhapXuatBQ parent)
        {
            if (!IsDirty) return;

            ExecuteInsert(tr, parent);
            MarkOld();

            //update child object(s)
            UpdateChildren(tr);
        }

        private void ExecuteInsert(SqlTransaction tr, PhieuNhapXuatBQ parent)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_InserttblCT_PhieuNhap_BQ";

                AddInsertParameters(cm, parent);

                cm.ExecuteNonQuery();

                _maChiTietPhieuNhap = (int)cm.Parameters["@MaChiTietPhieuNhap"].Value;
            }//using
        }

        private void AddInsertParameters(SqlCommand cm, PhieuNhapXuatBQ parent)
        {
            //TODO: if parent use identity key, fix fk member with value from parent
            _maPhieuNhap = parent.MaPhieuNhapXuat;
            cm.Parameters.AddWithValue("@MaPhieuNhap", _maPhieuNhap);
            cm.Parameters.AddWithValue("@DonGia", _donGia);
            cm.Parameters.AddWithValue("@ThanhTien", _thanhTien);
            cm.Parameters.AddWithValue("@SoLuong", _soLuong);
            if (_maDonViTinh != 0)
                cm.Parameters.AddWithValue("@MaDonViTinh", _maDonViTinh);
            else
                cm.Parameters.AddWithValue("@MaDonViTinh", DBNull.Value);
            if (_thoiLuong != 0)
                cm.Parameters.AddWithValue("@ThoiLuong", _thoiLuong);
            else
                cm.Parameters.AddWithValue("@ThoiLuong", DBNull.Value);
            if (_dienGiai.Length > 0)
                cm.Parameters.AddWithValue("@DienGiai", _dienGiai);
            else
                cm.Parameters.AddWithValue("@DienGiai", DBNull.Value);
            cm.Parameters.AddWithValue("@SoLuongXuat", _soLuongXuat);
            cm.Parameters.AddWithValue("@SoLuongConLai", _soLuong - _soLuongXuat);
            if (_ngayNghiemThu.Length > 0)
                cm.Parameters.AddWithValue("@NgayNghiemThu", _ngayNghiemThu);
            else
                cm.Parameters.AddWithValue("@NgayNghiemThu", DBNull.Value);
            if (_maNguon != 0)
                cm.Parameters.AddWithValue("@MaNguon", _maNguon);
            else
                cm.Parameters.AddWithValue("@MaNguon", DBNull.Value);

            if (_maChuongTrinh != 0)
                cm.Parameters.AddWithValue("@MaChuongTrinh", _maChuongTrinh);
            else
                cm.Parameters.AddWithValue("@MaChuongTrinh", DBNull.Value);

            cm.Parameters.AddWithValue("@MaChiTietPhieuNhap", _maChiTietPhieuNhap);
            cm.Parameters["@MaChiTietPhieuNhap"].Direction = ParameterDirection.Output;
        }
        #endregion //Data Access - Insert

        #region Data Access - Update
        internal void Update(SqlTransaction tr, PhieuNhapXuatBQ parent)
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

        private void ExecuteUpdate(SqlTransaction tr, PhieuNhapXuatBQ parent)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_UpdatetblCT_PhieuNhap_BQ";

                AddUpdateParameters(cm, parent);

                cm.ExecuteNonQuery();

            }//using
        }

        private void AddUpdateParameters(SqlCommand cm, PhieuNhapXuatBQ parent)
        {
            cm.Parameters.AddWithValue("@MaChiTietPhieuNhap", _maChiTietPhieuNhap);
            cm.Parameters.AddWithValue("@MaPhieuNhap", _maPhieuNhap);
            cm.Parameters.AddWithValue("@DonGia", _donGia);
            cm.Parameters.AddWithValue("@ThanhTien", _thanhTien);
            cm.Parameters.AddWithValue("@SoLuong", _soLuong);
            if (_maDonViTinh != 0)
                cm.Parameters.AddWithValue("@MaDonViTinh", _maDonViTinh);
            else
                cm.Parameters.AddWithValue("@MaDonViTinh", DBNull.Value);
            if (_thoiLuong != 0)
                cm.Parameters.AddWithValue("@ThoiLuong", _thoiLuong);
            else
                cm.Parameters.AddWithValue("@ThoiLuong", DBNull.Value);
            if (_dienGiai.Length > 0)
                cm.Parameters.AddWithValue("@DienGiai", _dienGiai);
            else
                cm.Parameters.AddWithValue("@DienGiai", DBNull.Value);
            cm.Parameters.AddWithValue("@SoLuongXuat", _soLuongXuat);
            cm.Parameters.AddWithValue("@SoLuongConLai", _soLuong - _soLuongXuat);
            if (_ngayNghiemThu.Length > 0)
                cm.Parameters.AddWithValue("@NgayNghiemThu", _ngayNghiemThu);
            else
                cm.Parameters.AddWithValue("@NgayNghiemThu", DBNull.Value);
            if (_maNguon != 0)
                cm.Parameters.AddWithValue("@MaNguon", _maNguon);
            else
                cm.Parameters.AddWithValue("@MaNguon", DBNull.Value);

            if (_maChuongTrinh != 0)
                cm.Parameters.AddWithValue("@MaChuongTrinh", _maChuongTrinh);
            else
                cm.Parameters.AddWithValue("@MaChuongTrinh", DBNull.Value);

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
                cm.CommandText = "spd_DeletetblCT_PhieuNhap";

                cm.Parameters.AddWithValue("@MaChiTietPhieuNhap", this._maChiTietPhieuNhap);

                cm.ExecuteNonQuery();
            }//using
        }
        #endregion //Data Access - Delete
        #endregion //Data Access

    }
}
