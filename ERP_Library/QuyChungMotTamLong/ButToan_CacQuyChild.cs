
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{
    [Serializable()]
    public class ButToan_CacQuy : Csla.BusinessBase<ButToan_CacQuy>
    {
        #region Business Properties and Methods

        //declare members
        private long _maButToanCacQuy = 0;
        private int _noTaiKhoan = 0;
        private int _coTaiKhoan = 0;
        private decimal _soTien = 0;
        private string _dienGiai = string.Empty;
        private long _maDoiTuongNo = 0;
        private long _maDoiTuongCo = 0;
        private long _machungtuCacquy = 0;

        [System.ComponentModel.DataObjectField(true, true)]
        public long MaButToanCacQuy
        {
            get
            {
                CanReadProperty("MaButToanCacQuy", true);
                return _maButToanCacQuy;
            }
        }

        public int NoTaiKhoan
        {
            get
            {
                CanReadProperty("NoTaiKhoan", true);
                return _noTaiKhoan;
            }
            set
            {
                CanWriteProperty("NoTaiKhoan", true);
                if (!_noTaiKhoan.Equals(value))
                {
                    _noTaiKhoan = value;
                    PropertyHasChanged("NoTaiKhoan");
                }
            }
        }

        public int CoTaiKhoan
        {
            get
            {
                CanReadProperty("CoTaiKhoan", true);
                return _coTaiKhoan;
            }
            set
            {
                CanWriteProperty("CoTaiKhoan", true);
                if (!_coTaiKhoan.Equals(value))
                {
                    _coTaiKhoan = value;
                    PropertyHasChanged("CoTaiKhoan");
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

        public long MaDoiTuongNo
        {
            get
            {
                CanReadProperty("MaDoiTuongNo", true);
                return _maDoiTuongNo;
            }
            set
            {
                CanWriteProperty("MaDoiTuongNo", true);
                if (!_maDoiTuongNo.Equals(value))
                {
                    _maDoiTuongNo = value;
                    PropertyHasChanged("MaDoiTuongNo");
                }
            }
        }

        public long MaDoiTuongCo
        {
            get
            {
                CanReadProperty("MaDoiTuongCo", true);
                return _maDoiTuongCo;
            }
            set
            {
                CanWriteProperty("MaDoiTuongCo", true);
                if (!_maDoiTuongCo.Equals(value))
                {
                    _maDoiTuongCo = value;
                    PropertyHasChanged("MaDoiTuongCo");
                }
            }
        }

        public long MachungtuCacquy
        {
            get
            {
                CanReadProperty("MachungtuCacquy", true);
                return _machungtuCacquy;
            }
            set
            {
                CanWriteProperty("MachungtuCacquy", true);
                if (!_machungtuCacquy.Equals(value))
                {
                    _machungtuCacquy = value;
                    PropertyHasChanged("MachungtuCacquy");
                }
            }
        }

        protected override object GetIdValue()
        {
            return _maButToanCacQuy;
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
            // SoTien
            //
            //ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("SoTien", 10));
            //
            // DienGiai
            //
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("DienGiai", 4000));
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
            //TODO: Define authorization rules in ButToan_CacQuy
            //AuthorizationRules.AllowRead("MaButToanCacQuy", "ButToan_CacQuyReadGroup");
            //AuthorizationRules.AllowRead("NoTaiKhoan", "ButToan_CacQuyReadGroup");
            //AuthorizationRules.AllowRead("CoTaiKhoan", "ButToan_CacQuyReadGroup");
            //AuthorizationRules.AllowRead("SoTien", "ButToan_CacQuyReadGroup");
            //AuthorizationRules.AllowRead("DienGiai", "ButToan_CacQuyReadGroup");
            //AuthorizationRules.AllowRead("MaDoiTuongNo", "ButToan_CacQuyReadGroup");
            //AuthorizationRules.AllowRead("MaDoiTuongCo", "ButToan_CacQuyReadGroup");
            //AuthorizationRules.AllowRead("MachungtuCacquy", "ButToan_CacQuyReadGroup");

            //AuthorizationRules.AllowWrite("NoTaiKhoan", "ButToan_CacQuyWriteGroup");
            //AuthorizationRules.AllowWrite("CoTaiKhoan", "ButToan_CacQuyWriteGroup");
            //AuthorizationRules.AllowWrite("SoTien", "ButToan_CacQuyWriteGroup");
            //AuthorizationRules.AllowWrite("DienGiai", "ButToan_CacQuyWriteGroup");
            //AuthorizationRules.AllowWrite("MaDoiTuongNo", "ButToan_CacQuyWriteGroup");
            //AuthorizationRules.AllowWrite("MaDoiTuongCo", "ButToan_CacQuyWriteGroup");
            //AuthorizationRules.AllowWrite("MachungtuCacquy", "ButToan_CacQuyWriteGroup");
        }

        #endregion //Authorization Rules

        #region Factory Methods
        internal static ButToan_CacQuy NewButToan_CacQuy()
        {
            return new ButToan_CacQuy();
        }

        internal static ButToan_CacQuy GetButToan_CacQuy(SafeDataReader dr)
        {
            return new ButToan_CacQuy(dr);
        }

        private ButToan_CacQuy()
        {

            ValidationRules.CheckRules();
            MarkAsChild();
        }

        private ButToan_CacQuy(SafeDataReader dr)
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
            _maButToanCacQuy = dr.GetInt64("MaButToanCacQuy");
            _noTaiKhoan = dr.GetInt32("NoTaiKhoan");
            _coTaiKhoan = dr.GetInt32("CoTaiKhoan");
            _soTien = dr.GetDecimal("SoTien");
            _dienGiai = dr.GetString("DienGiai");
            _maDoiTuongNo = dr.GetInt64("MaDoiTuongNo");
            _maDoiTuongCo = dr.GetInt64("MaDoiTuongCo");
            _machungtuCacquy = dr.GetInt64("MaChungTu_CacQuy");
        }

        private void FetchChildren(SafeDataReader dr)
        {
        }
        #endregion //Data Access - Fetch

        #region Data Access - Insert
        internal void Insert(SqlTransaction tr, ChungTu_CacLoaiQuy parent)
        {
            if (!IsDirty) return;

            ExecuteInsert(tr, parent);
            MarkOld();

            //update child object(s)
            UpdateChildren(tr);
        }

        private void ExecuteInsert(SqlTransaction tr, ChungTu_CacLoaiQuy parent)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_InserttblButToan_CacQuy";

                AddInsertParameters(cm, parent);

                cm.ExecuteNonQuery();

                _maButToanCacQuy = (long)cm.Parameters["@MaButToanCacQuy"].Value;
            }//using
        }

        private void AddInsertParameters(SqlCommand cm, ChungTu_CacLoaiQuy parent)
        {
            //TODO: if parent use identity key, fix fk member with value from parent
            if (_noTaiKhoan != 0)
                cm.Parameters.AddWithValue("@NoTaiKhoan", _noTaiKhoan);
            else
                cm.Parameters.AddWithValue("@NoTaiKhoan", DBNull.Value);
            if (_coTaiKhoan != 0)
                cm.Parameters.AddWithValue("@CoTaiKhoan", _coTaiKhoan);
            else
                cm.Parameters.AddWithValue("@CoTaiKhoan", DBNull.Value);
            if (_soTien != 0)
                cm.Parameters.AddWithValue("@SoTien", _soTien);
            else
                cm.Parameters.AddWithValue("@SoTien", DBNull.Value);
            if (_dienGiai.Length > 0)
                cm.Parameters.AddWithValue("@DienGiai", _dienGiai);
            else
                cm.Parameters.AddWithValue("@DienGiai", DBNull.Value);
            if (_maDoiTuongNo != 0)
                cm.Parameters.AddWithValue("@MaDoiTuongNo", _maDoiTuongNo);
            else
                cm.Parameters.AddWithValue("@MaDoiTuongNo", DBNull.Value);
            if (_maDoiTuongCo != 0)
                cm.Parameters.AddWithValue("@MaDoiTuongCo", _maDoiTuongCo);
            else
                cm.Parameters.AddWithValue("@MaDoiTuongCo", DBNull.Value);
            if (parent.MachungtuCacquy != 0)
                cm.Parameters.AddWithValue("@MaChungTu_CacQuy", parent.MachungtuCacquy);
            else
                cm.Parameters.AddWithValue("@MaChungTu_CacQuy", DBNull.Value);
            cm.Parameters.AddWithValue("@MaButToanCacQuy", _maButToanCacQuy);
            cm.Parameters["@MaButToanCacQuy"].Direction = ParameterDirection.Output;
        }
        #endregion //Data Access - Insert

        #region Data Access - Update
        internal void Update(SqlTransaction tr, ChungTu_CacLoaiQuy parent)
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

        private void ExecuteUpdate(SqlTransaction tr, ChungTu_CacLoaiQuy parent)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_UpdatetblButToan_CacQuy";

                AddUpdateParameters(cm, parent);

                cm.ExecuteNonQuery();

            }//using
        }

        private void AddUpdateParameters(SqlCommand cm, ChungTu_CacLoaiQuy parent)
        {
            cm.Parameters.AddWithValue("@MaButToanCacQuy", _maButToanCacQuy);
            if (_noTaiKhoan != 0)
                cm.Parameters.AddWithValue("@NoTaiKhoan", _noTaiKhoan);
            else
                cm.Parameters.AddWithValue("@NoTaiKhoan", DBNull.Value);
            if (_coTaiKhoan != 0)
                cm.Parameters.AddWithValue("@CoTaiKhoan", _coTaiKhoan);
            else
                cm.Parameters.AddWithValue("@CoTaiKhoan", DBNull.Value);
            if (_soTien != 0)
                cm.Parameters.AddWithValue("@SoTien", _soTien);
            else
                cm.Parameters.AddWithValue("@SoTien", DBNull.Value);
            if (_dienGiai.Length > 0)
                cm.Parameters.AddWithValue("@DienGiai", _dienGiai);
            else
                cm.Parameters.AddWithValue("@DienGiai", DBNull.Value);
            if (_maDoiTuongNo != 0)
                cm.Parameters.AddWithValue("@MaDoiTuongNo", _maDoiTuongNo);
            else
                cm.Parameters.AddWithValue("@MaDoiTuongNo", DBNull.Value);
            if (_maDoiTuongCo != 0)
                cm.Parameters.AddWithValue("@MaDoiTuongCo", _maDoiTuongCo);
            else
                cm.Parameters.AddWithValue("@MaDoiTuongCo", DBNull.Value);
            if (parent.MachungtuCacquy != 0)
                cm.Parameters.AddWithValue("@MaChungTu_CacQuy", parent.MachungtuCacquy);
            else
                cm.Parameters.AddWithValue("@MaChungTu_CacQuy", DBNull.Value);
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
                cm.CommandText = "spd_DeletetblButToan_CacQuy";

                cm.Parameters.AddWithValue("@MaButToanCacQuy", this._maButToanCacQuy);

                cm.ExecuteNonQuery();
            }//using
        }
        #endregion //Data Access - Delete
        #endregion //Data Access
    }
}
