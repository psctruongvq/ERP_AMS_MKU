
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{
    [Serializable()]
    public class ChiTietThanhToanHopDongThuChi : Csla.BusinessBase<ChiTietThanhToanHopDongThuChi>
    {
        #region Business Properties and Methods

        //declare members
        private int _maChiTiet = 0;
        private DateTime _ngayThanhToan = DateTime.MinValue;
        private decimal _soTien = 0;
        private int _maLoaiTien = 0;
        private long _maHopDong = 0;
        private long _maHoaDon = 0;
        private string _ghiChu = string.Empty;
        private decimal _phanTramThanhToan = 0;
        private decimal _tienThue = 0;
        private decimal _tienPhat = 0;
        private decimal _thueNhaThau = 0;
        private decimal _tienCoThue = 0;
        private double _thueSuat = 0;
        private string _phuongThucThanhToan = string.Empty;
        private double _tiGiaQuyDoi = 0;
        private long _maChiTietHopDong = 0;
        [System.ComponentModel.DataObjectField(true, true)]
        public int MaChiTiet
        {
            get
            {
                CanReadProperty("MaChiTiet", true);
                return _maChiTiet;
            }
        }

        public DateTime NgayThanhToan
        {
            get
            {
                CanReadProperty("NgayThanhToan", true);
                return _ngayThanhToan.Date;
            }
            set
            {
                CanWriteProperty("NgayThanhToan", true);
                if (!_ngayThanhToan.Equals(value))
                {
                    _ngayThanhToan = value;
                    PropertyHasChanged("NgayThanhToan");
                }
            }
        }

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

        public decimal PhanTramThanhToan
        {
            get
            {
                CanReadProperty("PhanTramThanhToan", true);
                return _phanTramThanhToan;
            }
            set
            {
                CanWriteProperty("PhanTramThanhToan", true);
                if (!_phanTramThanhToan.Equals(value))
                {
                    _phanTramThanhToan = value;
                    PropertyHasChanged("PhanTramThanhToan");
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

        public decimal TienThue
        {
            get
            {
                CanReadProperty("TienThue", true);
                return _tienThue;
            }
            set
            {
                CanWriteProperty("TienThue", true);
                if (!_tienThue.Equals(value))
                {
                    _tienThue = value;
                    _soTien = _tienCoThue - _tienThue;
                    PropertyHasChanged("TienThue");
                }
            }
        }

        public decimal TienPhat
        {
            get
            {
                CanReadProperty("TienPhat", true);
                return _tienPhat;
            }
            set
            {
                CanWriteProperty("TienPhat", true);
                if (!_tienPhat.Equals(value))
                {
                    _tienPhat = value;
                    PropertyHasChanged("TienPhat");
                }
            }
        }
        public decimal ThueNhaThau
        {
            get
            {
                CanReadProperty("ThueNhaThau", true);
                return _thueNhaThau;
            }
            set
            {
                CanWriteProperty("ThueNhaThau", true);
                if (!_thueNhaThau.Equals(value))
                {
                    _thueNhaThau = value;
                    PropertyHasChanged("ThueNhaThau");
                }
            }
        }
        public decimal TienCoThue
        {
            get
            {
                CanReadProperty("TienCoThue", true);
                return _tienCoThue;
            }
            set
            {
                CanWriteProperty("TienCoThue", true);
                if (!_tienCoThue.Equals(value))
                {
                    _tienCoThue = value;
                    _tienThue = _tienCoThue * (decimal)_thueSuat / 100;
                    _soTien = _tienCoThue - _tienThue;
                    PropertyHasChanged("TienCoThue");
                }
            }
        }
        public double ThueSuat
        {
            get
            {
                CanReadProperty("ThueSuat", true);
                return _thueSuat;
            }
            set
            {
                CanWriteProperty("ThueSuat", true);
                if (!_thueSuat.Equals(value))
                {
                    _thueSuat = value;
                    _tienThue = _tienCoThue * (decimal)_thueSuat / 100;
                    _soTien = _tienCoThue - _tienThue;
                    PropertyHasChanged("ThueSuat");
                }
            }
        }

        public string PhuongThucThanhToan
        {
            get
            {
                CanReadProperty("PhuongThucThanhToan", true);
                return _phuongThucThanhToan;
            }
            set
            {
                CanWriteProperty("PhuongThucThanhToan", true);
                if (value == null) value = string.Empty;
                if (!_phuongThucThanhToan.Equals(value))
                {
                    _phuongThucThanhToan = value;
                    PropertyHasChanged("PhuongThucThanhToan");
                }
            }
        }

        public double TiGiaQuyDoi
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

        public long MaChiTietHopDong
        {
            get
            {
                CanReadProperty("MaChiTietHopDong", true);
                return _maChiTietHopDong;
            }
            set
            {
                CanWriteProperty("MaChiTietHopDong", true);
                if (!_maChiTietHopDong.Equals(value))
                {
                    _maChiTietHopDong = value;
                    PropertyHasChanged("MaChiTietHopDong");
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
            // GhiChu
            //
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("GhiChu", 2000));
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
            //TODO: Define authorization rules in ChiTietThanhToan
            //AuthorizationRules.AllowRead("MaChiTiet", "ChiTietThanhToanReadGroup");
            //AuthorizationRules.AllowRead("NgayThanhToan", "ChiTietThanhToanReadGroup");
            //AuthorizationRules.AllowRead("NgayThanhToanString", "ChiTietThanhToanReadGroup");
            //AuthorizationRules.AllowRead("SoTien", "ChiTietThanhToanReadGroup");
            //AuthorizationRules.AllowRead("MaLoaiTien", "ChiTietThanhToanReadGroup");
            //AuthorizationRules.AllowRead("MaHopDong", "ChiTietThanhToanReadGroup");
            //AuthorizationRules.AllowRead("MaHoaDon", "ChiTietThanhToanReadGroup");
            //AuthorizationRules.AllowRead("GhiChu", "ChiTietThanhToanReadGroup");

            //AuthorizationRules.AllowWrite("NgayThanhToanString", "ChiTietThanhToanWriteGroup");
            //AuthorizationRules.AllowWrite("SoTien", "ChiTietThanhToanWriteGroup");
            //AuthorizationRules.AllowWrite("MaLoaiTien", "ChiTietThanhToanWriteGroup");
            //AuthorizationRules.AllowWrite("MaHopDong", "ChiTietThanhToanWriteGroup");
            //AuthorizationRules.AllowWrite("MaHoaDon", "ChiTietThanhToanWriteGroup");
            //AuthorizationRules.AllowWrite("GhiChu", "ChiTietThanhToanWriteGroup");
        }

        #endregion //Authorization Rules

        #region Factory Methods
        public static ChiTietThanhToanHopDongThuChi NewChiTietThanhToan()
        {
            return new ChiTietThanhToanHopDongThuChi();
        }

        internal static ChiTietThanhToanHopDongThuChi GetChiTietThanhToan(SafeDataReader dr)
        {
            return new ChiTietThanhToanHopDongThuChi(dr);
        }

        public ChiTietThanhToanHopDongThuChi()
        {

            ValidationRules.CheckRules();
            MarkAsChild();
        }
        public ChiTietThanhToanHopDongThuChi(ChiTietThanhToanHopDongThuChi ct)
        {
            _soTien = ct.SoTien;
            _maLoaiTien = ct.MaLoaiTien;
            _ghiChu = ct.GhiChu;
            _phanTramThanhToan = ct.PhanTramThanhToan;
            _tienThue = ct.TienThue;
            _tienPhat = ct.TienPhat;
            _thueNhaThau = ct.ThueNhaThau;
            _tienCoThue = ct.TienCoThue;
            _thueSuat = ct.ThueSuat;
            _phuongThucThanhToan = ct.PhuongThucThanhToan;
            _tiGiaQuyDoi = ct.TiGiaQuyDoi;
            _maChiTietHopDong = ct.MaChiTietHopDong;
            ValidationRules.CheckRules();
            MarkAsChild();
        }

        private ChiTietThanhToanHopDongThuChi(SafeDataReader dr)
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
            _maChiTiet = dr.GetInt32("MaChiTiet");
            _ngayThanhToan = dr.GetDateTime("NgayThanhToan");
            _soTien = dr.GetDecimal("SoTien");
            _maLoaiTien = dr.GetInt32("MaLoaiTien");
            _maHopDong = dr.GetInt64("MaHopDong");
            _maHoaDon = dr.GetInt64("MaHoaDon");
            _ghiChu = dr.GetString("GhiChu");
            _phanTramThanhToan = dr.GetDecimal("PhanTramThanhToan");
            _tienThue = dr.GetDecimal("TienThue");
            _tienPhat = dr.GetDecimal("TienPhat");
            _thueNhaThau = dr.GetDecimal("ThueNhaThau");
            _tienCoThue = dr.GetDecimal("TienCoThue");
            _thueSuat = dr.GetDouble("ThueSuat");
            _phuongThucThanhToan = dr.GetString("PhuongThucThanhToan");
            _tiGiaQuyDoi = dr.GetDouble("TiGiaQuyDoi");
            _maChiTietHopDong = dr.GetInt64("MaChiTietHopDong");
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
                cm.CommandText = "spd_InserttblChiTietThanhToan_N";

                AddInsertParameters(cm, parent);

                cm.ExecuteNonQuery();

                _maChiTiet = (int)cm.Parameters["@MaChiTiet"].Value;
            }//using
        }

        private void AddInsertParameters(SqlCommand cm, HopDongThuChi parent)
        {
            //TODO: if parent use identity key, fix fk member with value from parent
            if (_ngayThanhToan != DateTime.MinValue)
                cm.Parameters.AddWithValue("@NgayThanhToan", _ngayThanhToan);
            else
                cm.Parameters.AddWithValue("@NgayThanhToan", DBNull.Value);
            if (_soTien != 0)
                cm.Parameters.AddWithValue("@SoTien", _soTien);
            else
                cm.Parameters.AddWithValue("@SoTien", DBNull.Value);
            if (_maLoaiTien != 0)
                cm.Parameters.AddWithValue("@MaLoaiTien", _maLoaiTien);
            else
                cm.Parameters.AddWithValue("@MaLoaiTien", DBNull.Value);
            if (_phanTramThanhToan != 0)
                cm.Parameters.AddWithValue("@PhanTramThanhToan", _phanTramThanhToan);
            else
                cm.Parameters.AddWithValue("@PhanTramThanhToan", DBNull.Value);
            if (parent.MaHopDong != 0)
                cm.Parameters.AddWithValue("@MaHopDong", parent.MaHopDong);
            else
                cm.Parameters.AddWithValue("@MaHopDong", DBNull.Value);
            if (_maHoaDon != 0)
                cm.Parameters.AddWithValue("@MaHoaDon", _maHoaDon);
            else
                cm.Parameters.AddWithValue("@MaHoaDon", DBNull.Value);
            if (_ghiChu.Length > 0)
                cm.Parameters.AddWithValue("@GhiChu", _ghiChu);
            else
                cm.Parameters.AddWithValue("@GhiChu", DBNull.Value);
            if (_tienThue != 0)
                cm.Parameters.AddWithValue("@TienThue", _tienThue);
            else
                cm.Parameters.AddWithValue("@TienThue", DBNull.Value);
            if (_tienPhat != 0)
                cm.Parameters.AddWithValue("@TienPhat", _tienPhat);
            else
                cm.Parameters.AddWithValue("@TienPhat", DBNull.Value);

            if (_thueNhaThau != 0)
                cm.Parameters.AddWithValue("@ThueNhaThau", _thueNhaThau);
            else
                cm.Parameters.AddWithValue("@ThueNhaThau", DBNull.Value);
            if (_tienCoThue != 0)
                cm.Parameters.AddWithValue("@TienCoThue", _tienCoThue);
            else
                cm.Parameters.AddWithValue("@TienCoThue", DBNull.Value);
            if (_thueSuat != 0)
                cm.Parameters.AddWithValue("@ThueSuat", _thueSuat);
            else
                cm.Parameters.AddWithValue("@ThueSuat", DBNull.Value);
            if (_phuongThucThanhToan.Length > 0)
                cm.Parameters.AddWithValue("@PhuongThucThanhToan", _phuongThucThanhToan);
            else
                cm.Parameters.AddWithValue("@PhuongThucThanhToan", DBNull.Value);

            if (_tiGiaQuyDoi != 0)
                cm.Parameters.AddWithValue("@TiGiaQuyDoi", _tiGiaQuyDoi);
            else
                cm.Parameters.AddWithValue("@TiGiaQuyDoi", DBNull.Value);
            if (_maChiTietHopDong != 0)
                cm.Parameters.AddWithValue("@MaChiTietHopDong", _maChiTietHopDong);
            else
                cm.Parameters.AddWithValue("@MaChiTietHopDong", DBNull.Value);

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
                cm.CommandText = "spd_UpdatetblChiTietThanhToan_N";

                AddUpdateParameters(cm, parent);

                cm.ExecuteNonQuery();

            }//using
        }

        private void AddUpdateParameters(SqlCommand cm, HopDongThuChi parent)
        {
            cm.Parameters.AddWithValue("@MaChiTiet", _maChiTiet);
            if (_ngayThanhToan != DateTime.MinValue)
                cm.Parameters.AddWithValue("@NgayThanhToan", _ngayThanhToan);
            else
                cm.Parameters.AddWithValue("@NgayThanhToan", DBNull.Value);
            if (_soTien != 0)
                cm.Parameters.AddWithValue("@SoTien", _soTien);
            else
                cm.Parameters.AddWithValue("@SoTien", DBNull.Value);
            if (_maLoaiTien != 0)
                cm.Parameters.AddWithValue("@MaLoaiTien", _maLoaiTien);
            else
                cm.Parameters.AddWithValue("@MaLoaiTien", DBNull.Value);
            if (_phanTramThanhToan != 0)
                cm.Parameters.AddWithValue("@PhanTramThanhToan", _phanTramThanhToan);
            else
                cm.Parameters.AddWithValue("@PhanTramThanhToan", DBNull.Value);
            if (parent.MaHopDong != 0)
                cm.Parameters.AddWithValue("@MaHopDong", parent.MaHopDong);
            else
                cm.Parameters.AddWithValue("@MaHopDong", DBNull.Value);
            if (_maHoaDon != 0)
                cm.Parameters.AddWithValue("@MaHoaDon", _maHoaDon);
            else
                cm.Parameters.AddWithValue("@MaHoaDon", DBNull.Value);
            if (_ghiChu.Length > 0)
                cm.Parameters.AddWithValue("@GhiChu", _ghiChu);
            else
                cm.Parameters.AddWithValue("@GhiChu", DBNull.Value);
            if (_tienThue != 0)
                cm.Parameters.AddWithValue("@TienThue", _tienThue);
            else
                cm.Parameters.AddWithValue("@TienThue", DBNull.Value);
            if (_tienPhat != 0)
                cm.Parameters.AddWithValue("@TienPhat", _tienPhat);
            else
                cm.Parameters.AddWithValue("@TienPhat", DBNull.Value);
            if (_thueNhaThau != 0)
                cm.Parameters.AddWithValue("@ThueNhaThau", _thueNhaThau);
            else
                cm.Parameters.AddWithValue("@ThueNhaThau", DBNull.Value);
            if (_tienCoThue != 0)
                cm.Parameters.AddWithValue("@TienCoThue", _tienCoThue);
            else
                cm.Parameters.AddWithValue("@TienCoThue", DBNull.Value);
            if (_thueSuat != 0)
                cm.Parameters.AddWithValue("@ThueSuat", _thueSuat);
            else
                cm.Parameters.AddWithValue("@ThueSuat", DBNull.Value);
            if (_phuongThucThanhToan.Length > 0)
                cm.Parameters.AddWithValue("@PhuongThucThanhToan", _phuongThucThanhToan);
            else
                cm.Parameters.AddWithValue("@PhuongThucThanhToan", DBNull.Value);
            if (_tiGiaQuyDoi != 0)
                cm.Parameters.AddWithValue("@TiGiaQuyDoi", _tiGiaQuyDoi);
            else
                cm.Parameters.AddWithValue("@TiGiaQuyDoi", DBNull.Value);
            if (_maChiTietHopDong != 0)
                cm.Parameters.AddWithValue("@MaChiTietHopDong", _maChiTietHopDong);
            else
                cm.Parameters.AddWithValue("@MaChiTietHopDong", DBNull.Value);
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
                cm.CommandText = "spd_DeletetblChiTietThanhToan";

                cm.Parameters.AddWithValue("@MaChiTiet", this._maChiTiet);

                cm.ExecuteNonQuery();
            }//using
        }
        #endregion //Data Access - Delete
        #endregion //Data Access
    }
}
