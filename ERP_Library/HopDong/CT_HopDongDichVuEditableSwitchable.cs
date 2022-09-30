
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{
    [Serializable()]
    public class CT_HopDongDichVu : Csla.BusinessBase<CT_HopDongDichVu>
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
        private DateTime _ngayApDung = DateTime.Today.Date;
        private DateTime _ngayHetHanPS = DateTime.Today.Date;
        private int _soThangTrongHan = 0;
        private int _soLanPhatSong = 0;

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

        public DateTime NgayApDung
        {
            get
            {
                CanReadProperty("NgayApDung", true);
                return _ngayApDung;
            }
            set
            {
                CanWriteProperty("NgayApDung", true);
                if (!_ngayApDung.Equals(value))
                {
                    _ngayApDung = value;
                    _ngayHetHanPS = _ngayApDung.AddMonths(_soThangTrongHan);
                    PropertyHasChanged("NgayApDung");
                }
            }
        }

        public DateTime NgayHetHanPS
        {
            get
            {
                CanReadProperty("NgayHetHan", true);
                return _ngayHetHanPS;
            }
            set
            {
                CanWriteProperty("NgayHetHan", true);
                if (!_ngayHetHanPS.Equals(value))
                {
                    _ngayHetHanPS = value;
                    PropertyHasChanged("NgayHetHan");
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
                    _ngayHetHanPS = _ngayApDung.AddMonths(_soThangTrongHan);
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
        internal static CT_HopDongDichVu NewCT_HopDongDichVu()
        {
            return new CT_HopDongDichVu();
        }

        internal static CT_HopDongDichVu GetCT_HopDongDichVu(SafeDataReader dr)
        {
            return new CT_HopDongDichVu(dr);
        }

        private CT_HopDongDichVu()
        {

            ValidationRules.CheckRules();
            MarkAsChild();
        }

        private CT_HopDongDichVu(SafeDataReader dr)
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
            _ngayApDung = dr.GetDateTime("NgayApDung");
            _ngayHetHanPS = dr.GetDateTime("NgayHetHanPS");
            _soThangTrongHan = dr.GetInt32("SoThangTrongHan");
            _soLanPhatSong = dr.GetInt32("SoLanPhatSong");
        }

        private void FetchChildren(SafeDataReader dr)
        {
        }
        #endregion //Data Access - Fetch

        #region Data Access - Insert
        internal void Insert(SqlTransaction tr, HopDongMuaBan parent)
        {
            if (!IsDirty) return;

            ExecuteInsert(tr, parent);
            MarkOld();

            //update child object(s)
            UpdateChildren(tr);
        }

        private void ExecuteInsert(SqlTransaction tr, HopDongMuaBan parent)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_InserttblCT_HopDongDichVu";

                AddInsertParameters(cm, parent);

                cm.ExecuteNonQuery();

                _maChiTiet = (long)cm.Parameters["@MaChiTiet"].Value;
            }//using
        }

        private void AddInsertParameters(SqlCommand cm, HopDongMuaBan parent)
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
            if (_ngayApDung != DateTime.MinValue)
                cm.Parameters.AddWithValue("@NgayApDung", _ngayApDung);
            else
                cm.Parameters.AddWithValue("@NgayApDung", DBNull.Value);
            if (_ngayHetHanPS != DateTime.MinValue)
                cm.Parameters.AddWithValue("@NgayHetHanPS", _ngayHetHanPS);
            else
                cm.Parameters.AddWithValue("@NgayHetHanPS", DBNull.Value);
            cm.Parameters.AddWithValue("@SoThangTrongHan", _soThangTrongHan);
            cm.Parameters.AddWithValue("@SoLanPhatSong", _soLanPhatSong);
            cm.Parameters.AddWithValue("@MaChiTiet", _maChiTiet);
            cm.Parameters["@MaChiTiet"].Direction = ParameterDirection.Output;
        }
        #endregion //Data Access - Insert

        #region Data Access - Update
        internal void Update(SqlTransaction tr, HopDongMuaBan parent)
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

        private void ExecuteUpdate(SqlTransaction tr, HopDongMuaBan parent)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_UpdatetblCT_HopDongDichVu";

                AddUpdateParameters(cm, parent);

                cm.ExecuteNonQuery();

            }//using
        }

        private void AddUpdateParameters(SqlCommand cm, HopDongMuaBan parent)
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
            if (_ngayApDung != DateTime.MinValue)
                cm.Parameters.AddWithValue("@NgayApDung", _ngayApDung);
            else
                cm.Parameters.AddWithValue("@NgayApDung", DBNull.Value);
            if (_ngayHetHanPS != DateTime.MinValue)
                cm.Parameters.AddWithValue("@NgayHetHanPS", _ngayHetHanPS);
            else
                cm.Parameters.AddWithValue("@NgayHetHanPS", DBNull.Value);
            cm.Parameters.AddWithValue("@SoThangTrongHan", _soThangTrongHan);
            cm.Parameters.AddWithValue("@SoLanPhatSong", _soLanPhatSong);
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
    }
}
