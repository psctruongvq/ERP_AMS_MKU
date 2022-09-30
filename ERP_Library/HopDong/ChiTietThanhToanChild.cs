
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{
    [Serializable()]
    public class ChiTietThanhToan : Csla.BusinessBase<ChiTietThanhToan>
    {
        #region Business Properties and Methods

        //declare members
        private int _maChiTiet = 0;
        private DateTime _ngayThanhToan = DateTime.Today;
        private decimal _soTien = 0;
        private int _maLoaiTien = 0;
        private long _maHopDong = 0;
        private long _maHoaDon = 0;
        private string _ghiChu = string.Empty;
        private decimal _phanTramThanhToan = 0;
        private decimal _tienThue = 0;
        private decimal _tienPhat = 0;

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
        public static ChiTietThanhToan NewChiTietThanhToan()
        {
            return new ChiTietThanhToan();
        }

        internal static ChiTietThanhToan GetChiTietThanhToan(SafeDataReader dr)
        {
            return new ChiTietThanhToan(dr);
        }

        public ChiTietThanhToan()
        {

            ValidationRules.CheckRules();
            MarkAsChild();
        }

        private ChiTietThanhToan(SafeDataReader dr)
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
                cm.CommandText = "spd_InserttblChiTietThanhToan";

                AddInsertParameters(cm, parent);

                cm.ExecuteNonQuery();

                _maChiTiet = (int)cm.Parameters["@MaChiTiet"].Value;
            }//using
        }

        private void AddInsertParameters(SqlCommand cm, HopDongMuaBan parent)
        {
            //TODO: if parent use identity key, fix fk member with value from parent
            cm.Parameters.AddWithValue("@NgayThanhToan", _ngayThanhToan);
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
                cm.CommandText = "spd_UpdatetblChiTietThanhToan";

                AddUpdateParameters(cm, parent);

                cm.ExecuteNonQuery();

            }//using
        }

        private void AddUpdateParameters(SqlCommand cm, HopDongMuaBan parent)
        {
            cm.Parameters.AddWithValue("@MaChiTiet", _maChiTiet);
            cm.Parameters.AddWithValue("@NgayThanhToan", _ngayThanhToan);
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
