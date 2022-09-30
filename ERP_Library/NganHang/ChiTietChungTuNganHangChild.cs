
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{
    [Serializable()]
    public class ChiTietChungTuNganHang : Csla.BusinessBase<ChiTietChungTuNganHang>
    {
        #region Business Properties and Methods

        //declare members
        private long _maChiTiet = 0;
        private int _maChungTu = 0;
        private long _maDeNghi = 0;
        private decimal _soTien = 0;
        private decimal _tyGia = 0;
        private string _soDeNghi = string.Empty;
        private int _loaiTien = 0;
        private decimal _thanhTien = 0;

        [System.ComponentModel.DataObjectField(true, true)]
        public long MaChiTiet
        {
            get
            {
                CanReadProperty("MaChiTiet", true);
                return _maChiTiet;
            }
        }

        public int MaChungTu
        {
            get
            {
                CanReadProperty("MaChungTu", true);
                return _maChungTu;
            }
            set
            {
                CanWriteProperty("MaChungTu", true);
                if (!_maChungTu.Equals(value))
                {
                    _maChungTu = value;
                    PropertyHasChanged("MaChungTu");
                }
            }
        }

        public long MaDeNghi
        {
            get
            {
                CanReadProperty("MaDeNghi", true);
                return _maDeNghi;
            }
            set
            {
                CanWriteProperty("MaDeNghi", true);
                if (!_maDeNghi.Equals(value))
                {
                    _maDeNghi = value;
                    PropertyHasChanged("MaDeNghi");
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
                    _thanhTien = _soTien * _tyGia;
                    PropertyHasChanged("SoTien");
                }
            }
        }

        public decimal TyGia
        {
            get
            {
                CanReadProperty("TyGia", true);
                return _tyGia;
            }
            set
            {
                CanWriteProperty("TyGia", true);
                if (!_tyGia.Equals(value))
                {
                    _tyGia = value;
                    _thanhTien = _soTien * _tyGia;
                    PropertyHasChanged("TyGia");
                }
            }
        }

        public string SoDeNghi
        {
            get
            {
                CanReadProperty("SoDeNghi", true);
                return _soDeNghi;
            }
            set
            {
                CanWriteProperty("SoDeNghi", true);
                if (value == null) value = string.Empty;
                if (!_soDeNghi.Equals(value))
                {
                    _soDeNghi = value;
                    PropertyHasChanged("SoDeNghi");
                }
            }
        }

        public int LoaiTien
        {
            get
            {
                CanReadProperty("LoaiTien", true);
                return _loaiTien;
            }
            set
            {
                CanWriteProperty("LoaiTien", true);
                if (!_loaiTien.Equals(value))
                {
                    _loaiTien = value;
                    PropertyHasChanged("LoaiTien");
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
            // SoDeNghi
            //
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("SoDeNghi", 50));
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
            //TODO: Define authorization rules in ChiTietChungTuNganHang
            //AuthorizationRules.AllowRead("MaChiTiet", "ChiTietChungTuNganHangReadGroup");
            //AuthorizationRules.AllowRead("MaChungTu", "ChiTietChungTuNganHangReadGroup");
            //AuthorizationRules.AllowRead("MaDeNghi", "ChiTietChungTuNganHangReadGroup");
            //AuthorizationRules.AllowRead("SoTien", "ChiTietChungTuNganHangReadGroup");
            //AuthorizationRules.AllowRead("TyGia", "ChiTietChungTuNganHangReadGroup");
            //AuthorizationRules.AllowRead("SoDeNghi", "ChiTietChungTuNganHangReadGroup");

            //AuthorizationRules.AllowWrite("MaChungTu", "ChiTietChungTuNganHangWriteGroup");
            //AuthorizationRules.AllowWrite("MaDeNghi", "ChiTietChungTuNganHangWriteGroup");
            //AuthorizationRules.AllowWrite("SoTien", "ChiTietChungTuNganHangWriteGroup");
            //AuthorizationRules.AllowWrite("TyGia", "ChiTietChungTuNganHangWriteGroup");
            //AuthorizationRules.AllowWrite("SoDeNghi", "ChiTietChungTuNganHangWriteGroup");
        }

        #endregion //Authorization Rules

        #region Factory Methods
        internal static ChiTietChungTuNganHang NewChiTietChungTuNganHang()
        {
            return new ChiTietChungTuNganHang();
        }

        internal static ChiTietChungTuNganHang GetChiTietChungTuNganHang(SafeDataReader dr)
        {
            return new ChiTietChungTuNganHang(dr);
        }

        private ChiTietChungTuNganHang()
        {

            ValidationRules.CheckRules();
            MarkAsChild();
        }

        private ChiTietChungTuNganHang(SafeDataReader dr)
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
            _maChungTu = dr.GetInt32("MaChungTu");
            _maDeNghi = dr.GetInt64("MaDeNghi");
            _soTien = dr.GetDecimal("SoTien");
            _tyGia = dr.GetDecimal("TyGia");
            _soDeNghi = dr.GetString("SoDeNghi");
            _loaiTien = dr.GetInt32("LoaiTien");
            _thanhTien = _soTien * _tyGia;
        }

        private void FetchChildren(SafeDataReader dr)
        {
        }
        #endregion //Data Access - Fetch

        #region Data Access - Insert
        internal void Insert(SqlTransaction tr, ChungTuNganHang parent)
        {
            if (!IsDirty) return;

            ExecuteInsert(tr, parent);
            MarkOld();

            //update child object(s)
            UpdateChildren(tr);
        }

        private void ExecuteInsert(SqlTransaction tr, ChungTuNganHang parent)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_InserttblChiTietChungTuNganHang";

                AddInsertParameters(cm, parent);

                cm.ExecuteNonQuery();

                _maChiTiet = (long)cm.Parameters["@MaChiTiet"].Value;
            }//using
        }

        private void AddInsertParameters(SqlCommand cm, ChungTuNganHang parent)
        {
            //TODO: if parent use identity key, fix fk member with value from parent
            if (parent.MaChungTu != 0)
                cm.Parameters.AddWithValue("@MaChungTu", parent.MaChungTu);
            else
                cm.Parameters.AddWithValue("@MaChungTu", DBNull.Value);
            if (_maDeNghi != 0)
                cm.Parameters.AddWithValue("@MaDeNghi", _maDeNghi);
            else
                cm.Parameters.AddWithValue("@MaDeNghi", DBNull.Value);
            if (_soTien != 0)
                cm.Parameters.AddWithValue("@SoTien", _soTien);
            else
                cm.Parameters.AddWithValue("@SoTien", DBNull.Value);
            if (_tyGia != 0)
                cm.Parameters.AddWithValue("@TyGia", _tyGia);
            else
                cm.Parameters.AddWithValue("@TyGia", DBNull.Value);
            if (_soDeNghi.Length > 0)
                cm.Parameters.AddWithValue("@SoDeNghi", _soDeNghi);
            else
                cm.Parameters.AddWithValue("@SoDeNghi", DBNull.Value);
            if (_loaiTien != 0)
                cm.Parameters.AddWithValue("@LoaiTien", _loaiTien);
            else
                cm.Parameters.AddWithValue("@LoaiTien", DBNull.Value);
            cm.Parameters.AddWithValue("@MaChiTiet", _maChiTiet);
            cm.Parameters["@MaChiTiet"].Direction = ParameterDirection.Output;
        }
        #endregion //Data Access - Insert

        #region Data Access - Update
        internal void Update(SqlTransaction tr, ChungTuNganHang parent)
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

        private void ExecuteUpdate(SqlTransaction tr, ChungTuNganHang parent)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_UpdatetblChiTietChungTuNganHang";

                AddUpdateParameters(cm, parent);

                cm.ExecuteNonQuery();

            }//using
        }

        private void AddUpdateParameters(SqlCommand cm, ChungTuNganHang parent)
        {
            cm.Parameters.AddWithValue("@MaChiTiet", _maChiTiet);
            if (parent.MaChungTu != 0)
                cm.Parameters.AddWithValue("@MaChungTu", parent.MaChungTu);
            else
                cm.Parameters.AddWithValue("@MaChungTu", DBNull.Value);
            if (_maDeNghi != 0)
                cm.Parameters.AddWithValue("@MaDeNghi", _maDeNghi);
            else
                cm.Parameters.AddWithValue("@MaDeNghi", DBNull.Value);
            if (_soTien != 0)
                cm.Parameters.AddWithValue("@SoTien", _soTien);
            else
                cm.Parameters.AddWithValue("@SoTien", DBNull.Value);
            if (_tyGia != 0)
                cm.Parameters.AddWithValue("@TyGia", _tyGia);
            else
                cm.Parameters.AddWithValue("@TyGia", DBNull.Value);
            if (_soDeNghi.Length > 0)
                cm.Parameters.AddWithValue("@SoDeNghi", _soDeNghi);
            else
                cm.Parameters.AddWithValue("@SoDeNghi", DBNull.Value);
            if (_loaiTien != 0)
                cm.Parameters.AddWithValue("@LoaiTien", _loaiTien);
            else
                cm.Parameters.AddWithValue("@LoaiTien", DBNull.Value);
        }

        private void UpdateChildren(SqlTransaction tr)
        {
        }
        #endregion //Data Access - Update

        #region Data Access - Delete
        internal void DeleteSelf(SqlTransaction tr)
        {
            //if (!IsDirty) return;
            //if (IsNew) return;

            ExecuteDelete(tr);
            //MarkNew();
        }

        private void ExecuteDelete(SqlTransaction tr)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_DeletetblChiTietChungTuNganHang";

                cm.Parameters.AddWithValue("@MaChiTiet", this._maChiTiet);

                cm.ExecuteNonQuery();
            }//using
        }
        #endregion //Data Access - Delete
        #endregion //Data Access
    }
}
