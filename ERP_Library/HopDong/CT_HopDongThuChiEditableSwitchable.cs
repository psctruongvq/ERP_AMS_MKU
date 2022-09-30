
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{
    [Serializable()]
    public class CT_HopDongThuChi : Csla.BusinessBase<CT_HopDongThuChi>
    {
        #region Business Properties and Methods

        //declare members
        private long _maChiTiet = 0;
        private int _maDonViTinh = 0;
        private string _hangHoa = string.Empty;
        private int _soLuong = 0;
        private decimal _donGia = 0;
        private int _maLoaiTien = 0;
        private decimal _thanhTien = 0;
        private long _maHopDong = 0;
        private long _maHoaDon = 0;
        private SmartDate _ngayApDung = new SmartDate("");
        private SmartDate _ngayHetHanPS = new SmartDate("");
        private int _soThangTrongHan = 0;
        private int _soLanPhatSong = 0;
        //
        private int _nuocSX = 0;
        private int _soPhut = 0;
        private int _thoiLuong = 0;
        private string _kenhPS = string.Empty;
        private string _gioPS = string.Empty;
        private SmartDate _ngayPS = new SmartDate("");
        private long _maThamChieu = 0;

        [System.ComponentModel.DataObjectField(true, true)]
        public long MaChiTiet
        {
            get
            {
                CanReadProperty("MaChiTiet", true);
                return _maChiTiet;
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

        public string HangHoa
        {
            get
            {
                CanReadProperty("HangHoa", true);
                return _hangHoa;
            }
            set
            {
                CanWriteProperty("HangHoa", true);
                if (value == null) value = string.Empty;
                if (!_hangHoa.Equals(value))
                {
                    _hangHoa = value;
                    PropertyHasChanged("HangHoa");
                }
            }
        }

        public int SoLuong
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
                    _thanhTien = _soLuong * _donGia;
                    _thoiLuong = _soLuong * _soPhut;
                    PropertyHasChanged("SoLuong");
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
                    _thanhTien = _soLuong * _donGia;
                    PropertyHasChanged("DonGia");
                }
            }
        }

        public int MaLoaiTien
        {
            get
            {
                CanReadProperty("MaLoaiTien", true);
                return _maLoaiTien;
            }
            set
            {
                CanWriteProperty("MaLoaiTien", true);
                if (!_maLoaiTien.Equals(value))
                {
                    _maLoaiTien = value;
                    PropertyHasChanged("MaLoaiTien");
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

        public long MaHopDong
        {
            get
            {
                CanReadProperty("MaHopDong", true);
                return _maHopDong;
            }
            set
            {
                CanWriteProperty("MaHopDong", true);
                if (!_maHopDong.Equals(value))
                {
                    _maHopDong = value;
                    PropertyHasChanged("MaHopDong");
                }
            }
        }

        public long MaHoaDon
        {
            get
            {
                CanReadProperty("MaHoaDon", true);
                return _maHoaDon;
            }
            set
            {
                CanWriteProperty("MaHoaDon", true);
                if (!_maHoaDon.Equals(value))
                {
                    _maHoaDon = value;
                    PropertyHasChanged("MaHoaDon");
                }
            }
        }


        public DateTime? NgayApDung
        {
            get
            {
                CanReadProperty("NgayApDung", true);
                if (_ngayApDung.Date == DateTime.MinValue)
                    return null;
                return _ngayApDung.Date;
            }
            set
            {
                CanWriteProperty("NgayApDung", true);
                if (!_ngayApDung.Equals(value))
                {
                    if (value == null)
                        _ngayApDung = new SmartDate(DateTime.MinValue);
                    else
                        _ngayApDung = new SmartDate(value.Value.Date);

                    if (_ngayApDung.Date != DateTime.MinValue)
                        _ngayHetHanPS = new SmartDate(_ngayApDung.Date.AddMonths(_soThangTrongHan));
                    PropertyHasChanged("NgayApDung");
                }
            }
        }

        public string NgayApDungString
        {
            get
            {
                CanReadProperty("NgayApDungString", true);
                return string.Format("{0:dd/MM/yyyy}", _ngayApDung.Text);
            }
            set
            {
                CanWriteProperty("NgayApDungString", true);
                if (value == null) value = string.Empty;
                if (!_ngayApDung.Equals(value))
                {
                    _ngayApDung.Text = string.Format("{0:dd/MM/yyyy}", value);
                    if (_ngayApDung.Date != DateTime.MinValue)
                        _ngayHetHanPS.Text = string.Format("{0:dd/MM/yyyy}", new SmartDate(_ngayApDung.Date.AddMonths(_soThangTrongHan)).Text);
                    PropertyHasChanged("NgayApDungString");
                }
            }
        }



        public DateTime? NgayHetHanPS
        {
            get
            {
                CanReadProperty("NgayHetHan", true);
                if (_ngayHetHanPS.Date == DateTime.MinValue)
                    return null;
                return _ngayHetHanPS.Date;
            }
            set
            {
                CanWriteProperty("NgayHetHan", true);
                if (!_ngayHetHanPS.Equals(value))
                {
                    if (value == null)
                        _ngayHetHanPS = new SmartDate(DateTime.MinValue);
                    else
                        _ngayHetHanPS = new SmartDate(value.Value.Date);
                    PropertyHasChanged("NgayHetHan");
                }
            }
        }

        public string NgayHetHanPSString
        {
            get
            {
                CanReadProperty("NgayHetHanPSString", true);
                return string.Format("{0:dd/MM/yyyy}", _ngayHetHanPS.Text);
            }
            set
            {
                CanWriteProperty("NgayHetHanPSString", true);
                if (value == null) value = string.Empty;
                if (!_ngayHetHanPS.Equals(value))
                {
                    _ngayHetHanPS.Text = string.Format("{0:dd/MM/yyyy}", value);
                    PropertyHasChanged("NgayHetHanPSString");
                }
            }
        }

        public int SoThangTrongHan
        {
            get
            {
                CanReadProperty("SoThangTrongHan", true);
                return _soThangTrongHan;
            }
            set
            {
                CanWriteProperty("SoThangTrongHan", true);
                if (!_soThangTrongHan.Equals(value))
                {
                    _soThangTrongHan = value;
                    if (_ngayApDung.Date != DateTime.MinValue)
                        _ngayHetHanPS = new SmartDate(_ngayApDung.Date.AddMonths(_soThangTrongHan));
                    PropertyHasChanged("SoThangTrongHan");
                }
            }
        }

        public int SoLanPhatSong
        {
            get
            {
                CanReadProperty("SoLanPhatSong", true);
                return _soLanPhatSong;
            }
            set
            {
                CanWriteProperty("SoLanPhatSong", true);
                if (!_soLanPhatSong.Equals(value))
                {
                    _soLanPhatSong = value;
                    PropertyHasChanged("SoLanPhatSong");
                }
            }
        }
        //
        public int NuocSX
        {
            get
            {
                CanReadProperty("NuocSX", true);
                return _nuocSX;
            }
            set
            {
                CanWriteProperty("NuocSX", true);
                if (!_nuocSX.Equals(value))
                {
                    _nuocSX = value;
                    PropertyHasChanged("NuocSX");
                }
            }
        }

        public int SoPhut
        {
            get
            {
                CanReadProperty("SoPhut", true);
                return _soPhut;
            }
            set
            {
                CanWriteProperty("SoPhut", true);
                if (!_soPhut.Equals(value))
                {
                    _soPhut = value;
                    _thoiLuong = _soLuong * _soPhut;
                    PropertyHasChanged("SoPhut");
                }
            }
        }

        public int ThoiLuong
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

        public string KenhPS
        {
            get
            {
                CanReadProperty("KenhPS", true);
                return _kenhPS;
            }
            set
            {
                CanWriteProperty("KenhPS", true);
                if (value == null) value = string.Empty;
                if (!_kenhPS.Equals(value))
                {
                    _kenhPS = value;
                    PropertyHasChanged("KenhPS");
                }
            }
        }

        public string GioPS
        {
            get
            {
                CanReadProperty("GioPS", true);
                return _gioPS;
            }
            set
            {
                CanWriteProperty("GioPS", true);
                if (!_gioPS.Equals(value))
                {
                    _gioPS = value;
                    PropertyHasChanged("GioPS");
                }
            }
        }



        public DateTime? NgayPS
        {
            get
            {
                CanReadProperty("NgayPS", true);
                if (_ngayPS.Date == DateTime.MinValue)
                    return null;
                return _ngayPS.Date;
            }
            set
            {
                CanWriteProperty("NgayPS", true);
                if (!_ngayPS.Equals(value))
                {
                    if (value == null)
                        _ngayPS = new SmartDate(DateTime.MinValue);
                    else
                        _ngayPS = new SmartDate(value.Value.Date);
                    PropertyHasChanged("NgayPS");
                }
            }
        }

        public string NgayPSString
        {
            get
            {
                CanReadProperty("NgayPSString", true);
                return string.Format("{0:dd/MM/yyyy}", _ngayPS.Text);
            }
            set
            {
                CanWriteProperty("NgayPSString", true);
                if (value == null) value = string.Empty;
                if (!_ngayPS.Equals(value))
                {
                    _ngayPS.Text = string.Format("{0:dd/MM/yyyy}", value);
                    PropertyHasChanged("NgayPSString");
                }
            }
        }

        public long MaThamChieu
        {
            get
            {
                CanReadProperty("MaThamChieu", true);
                return _maThamChieu;
            }
            //set
            //{
            //    CanWriteProperty("MaThamChieu", true);
            //    _maThamChieu = SetMaThamChieuofCT_HopDong();
            //    PropertyHasChanged("MaDonViTinh");
            //}
        }

        protected override object GetIdValue()
        {
            return _maChiTiet;
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
            // HangHoa
            //
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("HangHoa", 2000));
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
            //TODO: Define authorization rules in CT_HopDongDichVu
            //AuthorizationRules.AllowRead("MaChiTiet", "CT_HopDongDichVuReadGroup");
            //AuthorizationRules.AllowRead("MaDonViTinh", "CT_HopDongDichVuReadGroup");
            //AuthorizationRules.AllowRead("HangHoa", "CT_HopDongDichVuReadGroup");
            //AuthorizationRules.AllowRead("SoLuong", "CT_HopDongDichVuReadGroup");
            //AuthorizationRules.AllowRead("DonGia", "CT_HopDongDichVuReadGroup");
            //AuthorizationRules.AllowRead("MaLoaiTien", "CT_HopDongDichVuReadGroup");
            //AuthorizationRules.AllowRead("ThanhTien", "CT_HopDongDichVuReadGroup");
            //AuthorizationRules.AllowRead("MaHopDong", "CT_HopDongDichVuReadGroup");
            //AuthorizationRules.AllowRead("MaHoaDon", "CT_HopDongDichVuReadGroup");

            //AuthorizationRules.AllowWrite("MaDonViTinh", "CT_HopDongDichVuWriteGroup");
            //AuthorizationRules.AllowWrite("HangHoa", "CT_HopDongDichVuWriteGroup");
            //AuthorizationRules.AllowWrite("SoLuong", "CT_HopDongDichVuWriteGroup");
            //AuthorizationRules.AllowWrite("DonGia", "CT_HopDongDichVuWriteGroup");
            //AuthorizationRules.AllowWrite("MaLoaiTien", "CT_HopDongDichVuWriteGroup");
            //AuthorizationRules.AllowWrite("ThanhTien", "CT_HopDongDichVuWriteGroup");
            //AuthorizationRules.AllowWrite("MaHopDong", "CT_HopDongDichVuWriteGroup");
            //AuthorizationRules.AllowWrite("MaHoaDon", "CT_HopDongDichVuWriteGroup");
        }

        #endregion //Authorization Rules

        #region Factory Methods
        internal static CT_HopDongThuChi NewCT_HopDongDichVu()
        {
            return new CT_HopDongThuChi();
        }
        public static CT_HopDongThuChi NewCT_HopDongDichVu(string hangHoa)
        {
            return new CT_HopDongThuChi(hangHoa);
        }

        internal static CT_HopDongThuChi GetCT_HopDongDichVu(SafeDataReader dr)
        {
            return new CT_HopDongThuChi(dr);
        }

        private CT_HopDongThuChi()
        {

            ValidationRules.CheckRules();
            MarkAsChild();
        }

        private CT_HopDongThuChi(string hangHoa)
        {
            _hangHoa = hangHoa;
        }

        public CT_HopDongThuChi(CT_HopDongThuChi ct)
        {

            _maDonViTinh = ct.MaDonViTinh;
            _hangHoa = ct.HangHoa;
            _soLuong = ct.SoLuong;
            _donGia = ct.DonGia;
            _maLoaiTien = ct.MaLoaiTien;
            _thanhTien = ct.ThanhTien;

            if (ct.NgayApDung == null)
                _ngayApDung = new SmartDate(DateTime.MinValue);
            else
                _ngayApDung = new SmartDate(ct.NgayApDung.Value.Date);

            if (ct.NgayHetHanPS == null)
                _ngayHetHanPS = new SmartDate(DateTime.MinValue);
            else
                _ngayHetHanPS = new SmartDate(ct.NgayHetHanPS.Value.Date);

            _soThangTrongHan = ct.SoThangTrongHan;
            _soLanPhatSong = ct.SoLanPhatSong;
            _nuocSX = ct.NuocSX;
            _soPhut = ct.SoPhut;
            _thoiLuong = ct.ThoiLuong;
            _kenhPS = ct.KenhPS;
            _gioPS = ct.GioPS;

            if (ct.NgayPS == null)
                _ngayPS = new SmartDate(DateTime.MinValue);
            else
                _ngayPS = new SmartDate(ct.NgayPS.Value.Date);

            _maThamChieu = ct.MaThamChieu;

            ValidationRules.CheckRules();
            MarkAsChild();
        }
        private CT_HopDongThuChi(SafeDataReader dr)
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
            _maChiTiet = dr.GetInt64("MaChiTiet");
            _maDonViTinh = dr.GetInt32("MaDonViTinh");
            _hangHoa = dr.GetString("HangHoa");
            _soLuong = dr.GetInt32("SoLuong");
            _donGia = dr.GetDecimal("DonGia");
            _maLoaiTien = dr.GetInt32("MaLoaiTien");
            _thanhTien = dr.GetDecimal("ThanhTien");
            _maHopDong = dr.GetInt64("MaHopDong");
            _maHoaDon = dr.GetInt64("MaHoaDon");
            _ngayApDung = dr.GetSmartDate("NgayApDung", _ngayApDung.EmptyIsMin);
            _ngayHetHanPS = dr.GetSmartDate("NgayHetHanPS", _ngayHetHanPS.EmptyIsMin);
            _soThangTrongHan = dr.GetInt32("SoThangTrongHan");
            _soLanPhatSong = dr.GetInt32("SoLanPhatSong");
            //
            _nuocSX = dr.GetInt32("NuocSX");
            _soPhut = dr.GetInt32("SoPhut");
            _thoiLuong = dr.GetInt32("ThoiLuong");
            _kenhPS = dr.GetString("KenhPS");
            _gioPS = dr.GetString("GioPS");
            _ngayPS = dr.GetSmartDate("NgayPS", _ngayPS.EmptyIsMin);

            _maThamChieu = dr.GetInt64("MaThamChieu");
        }

        private void FetchChildren(SafeDataReader dr)
        {
        }
        #endregion //Data Access - Fetch

        #region Data Access - Insert
        internal void Insert(SqlTransaction tr, HopDongThuChi parent)
        {
            if (!IsDirty) return;

            ExecuteInsert(tr, parent);
            MarkOld();

            //update child object(s)
            UpdateChildren(tr);
        }

        private void ExecuteInsert(SqlTransaction tr, HopDongThuChi parent)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_InserttblCT_HopDongDichVu_N";

                AddInsertParameters(cm, parent);

                cm.ExecuteNonQuery();

                _maChiTiet = (long)cm.Parameters["@MaChiTiet"].Value;
            }//using
        }

        private void AddInsertParameters(SqlCommand cm, HopDongThuChi parent)
        {
            //TODO: if parent use identity key, fix fk member with value from parent
            if (_maDonViTinh != 0)
                cm.Parameters.AddWithValue("@MaDonViTinh", _maDonViTinh);
            else
                cm.Parameters.AddWithValue("@MaDonViTinh", DBNull.Value);
            if (_hangHoa.Length > 0)
                cm.Parameters.AddWithValue("@HangHoa", _hangHoa);
            else
                cm.Parameters.AddWithValue("@HangHoa", DBNull.Value);
            if (_soLuong != 0)
                cm.Parameters.AddWithValue("@SoLuong", _soLuong);
            else
                cm.Parameters.AddWithValue("@SoLuong", DBNull.Value);
            if (_donGia != 0)
                cm.Parameters.AddWithValue("@DonGia", _donGia);
            else
                cm.Parameters.AddWithValue("@DonGia", DBNull.Value);
            if (_maLoaiTien != 0)
                cm.Parameters.AddWithValue("@MaLoaiTien", _maLoaiTien);
            else
                cm.Parameters.AddWithValue("@MaLoaiTien", DBNull.Value);
            if (_thanhTien != 0)
                cm.Parameters.AddWithValue("@ThanhTien", _thanhTien);
            else
                cm.Parameters.AddWithValue("@ThanhTien", DBNull.Value);
            if (parent.MaHopDong != 0)
                cm.Parameters.AddWithValue("@MaHopDong", parent.MaHopDong);
            else
                cm.Parameters.AddWithValue("@MaHopDong", DBNull.Value);
            if (_maHoaDon != 0)
                cm.Parameters.AddWithValue("@MaHoaDon", _maHoaDon);
            else
                cm.Parameters.AddWithValue("@MaHoaDon", DBNull.Value);
            cm.Parameters.AddWithValue("@NgayApDung", _ngayApDung.DBValue);
            cm.Parameters.AddWithValue("@NgayHetHanPS", _ngayHetHanPS.DBValue);
            cm.Parameters.AddWithValue("@SoThangTrongHan", _soThangTrongHan);
            cm.Parameters.AddWithValue("@SoLanPhatSong", _soLanPhatSong);


            if (_nuocSX != 0)
                cm.Parameters.AddWithValue("@NuocSX", _nuocSX);
            else
                cm.Parameters.AddWithValue("@NuocSX", DBNull.Value);

            if (_soPhut != 0)
                cm.Parameters.AddWithValue("@SoPhut", _soPhut);
            else
                cm.Parameters.AddWithValue("@SoPhut", DBNull.Value);

            if (_thoiLuong != 0)
                cm.Parameters.AddWithValue("@ThoiLuong", _thoiLuong);
            else
                cm.Parameters.AddWithValue("@ThoiLuong", DBNull.Value);

            if (_kenhPS.Length > 0)
                cm.Parameters.AddWithValue("@KenhPS", _kenhPS);
            else
                cm.Parameters.AddWithValue("@KenhPS", DBNull.Value);

            if (_gioPS.Length > 0)
                cm.Parameters.AddWithValue("@GioPS", _gioPS);
            else
                cm.Parameters.AddWithValue("@GioPS", DBNull.Value);

            cm.Parameters.AddWithValue("@NgayPS", _ngayPS.DBValue);

            if (_maThamChieu != 0)
                cm.Parameters.AddWithValue("@MaThamChieu", _maThamChieu);
            else
            {
                cm.Parameters.AddWithValue("@MaThamChieu", DBNull.Value);
                //long mathamchieu = SetMaThamChieuofCT_HopDong();
                //cm.Parameters.AddWithValue("@MaThamChieu", mathamchieu);
            }

            cm.Parameters.AddWithValue("@MaChiTiet", _maChiTiet);
            cm.Parameters["@MaChiTiet"].Direction = ParameterDirection.Output;


        }
        #endregion //Data Access - Insert

        #region Data Access - Update
        internal void Update(SqlTransaction tr, HopDongThuChi parent)
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

        private void ExecuteUpdate(SqlTransaction tr, HopDongThuChi parent)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_UpdatetblCT_HopDongDichVu_N";

                AddUpdateParameters(cm, parent);

                cm.ExecuteNonQuery();

            }//using
        }

        private void AddUpdateParameters(SqlCommand cm, HopDongThuChi parent)
        {
            cm.Parameters.AddWithValue("@MaChiTiet", _maChiTiet);
            if (_maDonViTinh != 0)
                cm.Parameters.AddWithValue("@MaDonViTinh", _maDonViTinh);
            else
                cm.Parameters.AddWithValue("@MaDonViTinh", DBNull.Value);
            if (_hangHoa.Length > 0)
                cm.Parameters.AddWithValue("@HangHoa", _hangHoa);
            else
                cm.Parameters.AddWithValue("@HangHoa", DBNull.Value);
            if (_soLuong != 0)
                cm.Parameters.AddWithValue("@SoLuong", _soLuong);
            else
                cm.Parameters.AddWithValue("@SoLuong", DBNull.Value);
            if (_donGia != 0)
                cm.Parameters.AddWithValue("@DonGia", _donGia);
            else
                cm.Parameters.AddWithValue("@DonGia", DBNull.Value);
            if (_maLoaiTien != 0)
                cm.Parameters.AddWithValue("@MaLoaiTien", _maLoaiTien);
            else
                cm.Parameters.AddWithValue("@MaLoaiTien", DBNull.Value);
            if (_thanhTien != 0)
                cm.Parameters.AddWithValue("@ThanhTien", _thanhTien);
            else
                cm.Parameters.AddWithValue("@ThanhTien", DBNull.Value);
            if (parent.MaHopDong != 0)
                cm.Parameters.AddWithValue("@MaHopDong", parent.MaHopDong);
            else
                cm.Parameters.AddWithValue("@MaHopDong", DBNull.Value);
            if (_maHoaDon != 0)
                cm.Parameters.AddWithValue("@MaHoaDon", _maHoaDon);
            else
                cm.Parameters.AddWithValue("@MaHoaDon", DBNull.Value);
            cm.Parameters.AddWithValue("@NgayApDung", _ngayApDung.DBValue);
            cm.Parameters.AddWithValue("@NgayHetHanPS", _ngayHetHanPS.DBValue);
            cm.Parameters.AddWithValue("@SoThangTrongHan", _soThangTrongHan);
            cm.Parameters.AddWithValue("@SoLanPhatSong", _soLanPhatSong);

            if (_nuocSX != 0)
                cm.Parameters.AddWithValue("@NuocSX", _nuocSX);
            else
                cm.Parameters.AddWithValue("@NuocSX", DBNull.Value);

            if (_soPhut != 0)
                cm.Parameters.AddWithValue("@SoPhut", _soPhut);
            else
                cm.Parameters.AddWithValue("@SoPhut", DBNull.Value);

            if (_thoiLuong != 0)
                cm.Parameters.AddWithValue("@ThoiLuong", _thoiLuong);
            else
                cm.Parameters.AddWithValue("@ThoiLuong", DBNull.Value);

            if (_kenhPS.Length > 0)
                cm.Parameters.AddWithValue("@KenhPS", _kenhPS);
            else
                cm.Parameters.AddWithValue("@KenhPS", DBNull.Value);

            if (_gioPS.Length > 0)
                cm.Parameters.AddWithValue("@GioPS", _gioPS);
            else
                cm.Parameters.AddWithValue("@GioPS", DBNull.Value);

            cm.Parameters.AddWithValue("@NgayPS", _ngayPS.DBValue);

            //if (_maThamChieu != 0)
            //    cm.Parameters.AddWithValue("@MaThamChieu", _maThamChieu);
            //else
            //    cm.Parameters.AddWithValue("@MaThamChieu", DBNull.Value);
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
                cm.CommandText = "spd_DeletetblCT_HopDongDichVu";

                cm.Parameters.AddWithValue("@MaChiTiet", this._maChiTiet);

                cm.ExecuteNonQuery();
            }//using
        }
        #endregion //Data Access - Delete
        #endregion //Data Access
        #region Function

        public static long SetMaThamChieuofCT_HopDong()
        {
            long giaTriTraVe;
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandTimeout = 1800;

                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_SetMaThamChieuofCT_HopDong";
                    SqlParameter prmGiaTriTraVe = new SqlParameter("@GiaTriTraVe", SqlDbType.BigInt);
                    prmGiaTriTraVe.Direction = ParameterDirection.Output;
                    cm.Parameters.Add(prmGiaTriTraVe);
                    cm.ExecuteNonQuery();
                    giaTriTraVe = (long)prmGiaTriTraVe.Value;
                }
            }//us
            return giaTriTraVe;
        }

        #endregion
    }
}
