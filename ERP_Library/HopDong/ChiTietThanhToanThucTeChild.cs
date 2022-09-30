using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{
    [Serializable()]
    public class ChiTietThanhToanThucTe : Csla.BusinessBase<ChiTietThanhToanThucTe>
    {
        #region Business Properties and Methods

        //declare members
        private int _maChiTiet = 0;
        private SmartDate _ngayThanhToan = new SmartDate(DateTime.Today);
        private decimal _soTien = 0;
        private int _maLoaiTien = 0;
        private decimal _phanTramThanhToan = 0;
        private long _maHopDong = 0;
        private string _ghiChu = string.Empty;
        private decimal _tienThue = 0;
        private decimal _tienPhat = 0;
        private decimal _thueNhaThau = 0;
        private decimal _tienCoThue = 0;
        private double _thueSuat = 0;
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

        public DateTime? NgayThanhToan
        {
            get
            {
                CanReadProperty("NgayThanhToan", true);
                if (_ngayThanhToan.Date == DateTime.MinValue)
                    return null;
                return _ngayThanhToan.Date;
            }
            set
            {
                CanWriteProperty("NgayThanhToan", true);
                if (value == null)
                    _ngayThanhToan = new SmartDate(DateTime.MinValue);
                else
                    _ngayThanhToan = new SmartDate(value.Value.Date);

                PropertyHasChanged("NgayThanhToan");
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
            //TODO: Define authorization rules in ChiTietThanhToanThucTe
            //AuthorizationRules.AllowRead("MaChiTiet", "ChiTietThanhToanThucTeReadGroup");
            //AuthorizationRules.AllowRead("NgayThanhToan", "ChiTietThanhToanThucTeReadGroup");
            //AuthorizationRules.AllowRead("NgayThanhToanString", "ChiTietThanhToanThucTeReadGroup");
            //AuthorizationRules.AllowRead("SoTien", "ChiTietThanhToanThucTeReadGroup");
            //AuthorizationRules.AllowRead("MaLoaiTien", "ChiTietThanhToanThucTeReadGroup");
            //AuthorizationRules.AllowRead("PhanTramThanhToan", "ChiTietThanhToanThucTeReadGroup");
            //AuthorizationRules.AllowRead("MaHopDong", "ChiTietThanhToanThucTeReadGroup");
            //AuthorizationRules.AllowRead("GhiChu", "ChiTietThanhToanThucTeReadGroup");
            //AuthorizationRules.AllowRead("TienThue", "ChiTietThanhToanThucTeReadGroup");
            //AuthorizationRules.AllowRead("TienPhat", "ChiTietThanhToanThucTeReadGroup");
            //AuthorizationRules.AllowRead("ThueNhaThau", "ChiTietThanhToanThucTeReadGroup");
            //AuthorizationRules.AllowRead("TienCoThue", "ChiTietThanhToanThucTeReadGroup");
            //AuthorizationRules.AllowRead("ThueSuat", "ChiTietThanhToanThucTeReadGroup");

            //AuthorizationRules.AllowWrite("NgayThanhToanString", "ChiTietThanhToanThucTeWriteGroup");
            //AuthorizationRules.AllowWrite("SoTien", "ChiTietThanhToanThucTeWriteGroup");
            //AuthorizationRules.AllowWrite("MaLoaiTien", "ChiTietThanhToanThucTeWriteGroup");
            //AuthorizationRules.AllowWrite("PhanTramThanhToan", "ChiTietThanhToanThucTeWriteGroup");
            //AuthorizationRules.AllowWrite("MaHopDong", "ChiTietThanhToanThucTeWriteGroup");
            //AuthorizationRules.AllowWrite("GhiChu", "ChiTietThanhToanThucTeWriteGroup");
            //AuthorizationRules.AllowWrite("TienThue", "ChiTietThanhToanThucTeWriteGroup");
            //AuthorizationRules.AllowWrite("TienPhat", "ChiTietThanhToanThucTeWriteGroup");
            //AuthorizationRules.AllowWrite("ThueNhaThau", "ChiTietThanhToanThucTeWriteGroup");
            //AuthorizationRules.AllowWrite("TienCoThue", "ChiTietThanhToanThucTeWriteGroup");
            //AuthorizationRules.AllowWrite("ThueSuat", "ChiTietThanhToanThucTeWriteGroup");
        }

        #endregion //Authorization Rules

        #region Factory Methods
        internal static ChiTietThanhToanThucTe NewChiTietThanhToanThucTe()
        {
            return new ChiTietThanhToanThucTe();
        }

        internal static ChiTietThanhToanThucTe GetChiTietThanhToanThucTe(SafeDataReader dr)
        {
            return new ChiTietThanhToanThucTe(dr);
        }

        private ChiTietThanhToanThucTe()
        {

            ValidationRules.CheckRules();
            MarkAsChild();
        }

        public ChiTietThanhToanThucTe(ChiTietThanhToanThucTe ct)
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
            _tiGiaQuyDoi = ct.TiGiaQuyDoi;
            _maChiTietHopDong = ct.MaChiTietHopDong;

            if (ct.NgayThanhToan == null)
                _ngayThanhToan = new SmartDate(DateTime.MinValue);
            else
                _ngayThanhToan = new SmartDate(ct.NgayThanhToan.Value.Date);

            ValidationRules.CheckRules();
            MarkAsChild();
        }

        private ChiTietThanhToanThucTe(SafeDataReader dr)
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
            _ngayThanhToan = dr.GetSmartDate("NgayThanhToan", _ngayThanhToan.EmptyIsMin);
            _soTien = dr.GetDecimal("SoTien");
            _maLoaiTien = dr.GetInt32("MaLoaiTien");
            _phanTramThanhToan = dr.GetDecimal("PhanTramThanhToan");
            _maHopDong = dr.GetInt64("MaHopDong");
            _ghiChu = dr.GetString("GhiChu");
            _tienThue = dr.GetDecimal("TienThue");
            _tienPhat = dr.GetDecimal("TienPhat");
            _thueNhaThau = dr.GetDecimal("ThueNhaThau");
            _tienCoThue = dr.GetDecimal("TienCoThue");
            _thueSuat = dr.GetDouble("ThueSuat");
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
                cm.CommandText = "usp_InserttblChiTietThanhToanThucTe";

                AddInsertParameters(cm, parent);

                cm.ExecuteNonQuery();

                _maChiTiet = (int)cm.Parameters["@MaChiTiet"].Value;
            }//using
        }

        private void AddInsertParameters(SqlCommand cm, HopDongThuChi parent)
        {
            //TODO: if parent use identity key, fix fk member with value from parent
            cm.Parameters.AddWithValue("@NgayThanhToan", _ngayThanhToan.DBValue);
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
            cm.Parameters.AddWithValue("@MaHopDong", parent.MaHopDong);
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
                cm.CommandText = "usp_UpdatetblChiTietThanhToanThucTe";

                AddUpdateParameters(cm, parent);

                cm.ExecuteNonQuery();

            }//using
        }

        private void AddUpdateParameters(SqlCommand cm, HopDongThuChi parent)
        {
            cm.Parameters.AddWithValue("@MaChiTiet", _maChiTiet);
            cm.Parameters.AddWithValue("@NgayThanhToan", _ngayThanhToan.DBValue);
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
            cm.Parameters.AddWithValue("@MaHopDong", parent.MaHopDong);
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
                cm.CommandText = "usp_DeletetblChiTietThanhToanThucTe";

                cm.Parameters.AddWithValue("@MaChiTiet", this._maChiTiet);

                cm.ExecuteNonQuery();
            }//using
        }
        #endregion //Data Access - Delete
        #endregion //Data Access
    }
}
