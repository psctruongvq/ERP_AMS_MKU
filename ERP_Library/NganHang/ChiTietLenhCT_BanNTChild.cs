
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{
    [Serializable()]
    public class ChiTietLenhCT_BanNTChild : Csla.BusinessBase<ChiTietLenhCT_BanNTChild>
    {
        #region Business Properties and Methods

        //declare members
        private long _maChiTiet = 0;
        private long _maLenhCT = 0;
        private long _maPhieu = 0;
        private decimal _soTien = 0;
        private string _soChungTu = string.Empty;
        private int _loaiTien = 0;
        private decimal _tyGia = 0;

        [System.ComponentModel.DataObjectField(true, true)]
        public long MaChiTiet
        {
            get
            {
                CanReadProperty("MaChiTiet", true);
                return _maChiTiet;
            }
        }

        public long MaLenhCT
        {
            get
            {
                CanReadProperty("MaLenhCT", true);
                return _maLenhCT;
            }
            set
            {
                CanWriteProperty("MaLenhCT", true);
                if (!_maLenhCT.Equals(value))
                {
                    _maLenhCT = value;
                    PropertyHasChanged("MaLenhCT");
                }
            }
        }

        public long MaPhieu
        {
            get
            {
                CanReadProperty("MaPhieu", true);
                return _maPhieu;
            }
            set
            {
                CanWriteProperty("MaPhieu", true);
                if (!_maPhieu.Equals(value))
                {
                    _maPhieu = value;
                    PropertyHasChanged("MaPhieu");
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

        public string SoChungTu
        {
            get
            {
                CanReadProperty("SoChungTu", true);
                return _soChungTu;
            }
            set
            {
                CanWriteProperty("SoChungTu", true);
                if (value == null) value = string.Empty;
                if (!_soChungTu.Equals(value))
                {
                    _soChungTu = value;
                    PropertyHasChanged("SoChungTu");
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
                    PropertyHasChanged("TyGia");
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
            // SoChungTu
            //
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("SoChungTu", 50));
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
            //TODO: Define authorization rules in ChiTietLenhCT_BanNTChild
            //AuthorizationRules.AllowRead("MaChiTiet", "ChiTietLenhCT_BanNTChildReadGroup");
            //AuthorizationRules.AllowRead("MaLenhCT", "ChiTietLenhCT_BanNTChildReadGroup");
            //AuthorizationRules.AllowRead("MaPhieu", "ChiTietLenhCT_BanNTChildReadGroup");
            //AuthorizationRules.AllowRead("SoTien", "ChiTietLenhCT_BanNTChildReadGroup");
            //AuthorizationRules.AllowRead("SoChungTu", "ChiTietLenhCT_BanNTChildReadGroup");
            //AuthorizationRules.AllowRead("LoaiTien", "ChiTietLenhCT_BanNTChildReadGroup");
            //AuthorizationRules.AllowRead("TyGia", "ChiTietLenhCT_BanNTChildReadGroup");

            //AuthorizationRules.AllowWrite("MaLenhCT", "ChiTietLenhCT_BanNTChildWriteGroup");
            //AuthorizationRules.AllowWrite("MaPhieu", "ChiTietLenhCT_BanNTChildWriteGroup");
            //AuthorizationRules.AllowWrite("SoTien", "ChiTietLenhCT_BanNTChildWriteGroup");
            //AuthorizationRules.AllowWrite("SoChungTu", "ChiTietLenhCT_BanNTChildWriteGroup");
            //AuthorizationRules.AllowWrite("LoaiTien", "ChiTietLenhCT_BanNTChildWriteGroup");
            //AuthorizationRules.AllowWrite("TyGia", "ChiTietLenhCT_BanNTChildWriteGroup");
        }

        #endregion //Authorization Rules

        #region Factory Methods
        internal static ChiTietLenhCT_BanNTChild NewChiTietLenhCT_BanNTChild()
        {
            return new ChiTietLenhCT_BanNTChild();
        }

        internal static ChiTietLenhCT_BanNTChild GetChiTietLenhCT_BanNTChild(SafeDataReader dr)
        {
            return new ChiTietLenhCT_BanNTChild(dr);
        }

        private ChiTietLenhCT_BanNTChild()
        {

            ValidationRules.CheckRules();
            MarkAsChild();
        }

        private ChiTietLenhCT_BanNTChild(SafeDataReader dr)
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
            _maLenhCT = dr.GetInt64("MaLenhCT");
            _maPhieu = dr.GetInt64("MaPhieu");
            _soTien = dr.GetDecimal("SoTien");
            _soChungTu = dr.GetString("SoChungTu");
            _loaiTien = dr.GetInt32("LoaiTien");
            _tyGia = dr.GetDecimal("TyGia");
        }

        private void FetchChildren(SafeDataReader dr)
        {
        }
        #endregion //Data Access - Fetch

        #region Data Access - Insert
        internal void Insert(SqlTransaction tr, GiayBanNgoaiTe parent)
        {
            if (!IsDirty) return;

            ExecuteInsert(tr, parent);
            MarkOld();

            //update child object(s)
            UpdateChildren(tr);
        }

        private void ExecuteInsert(SqlTransaction tr, GiayBanNgoaiTe parent)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_InserttblChuyenTien_BanNgoaiTe";

                AddInsertParameters(cm, parent);

                cm.ExecuteNonQuery();

                _maChiTiet = (long)cm.Parameters["@MaChiTiet"].Value;
            }//using
        }

        private void AddInsertParameters(SqlCommand cm, GiayBanNgoaiTe parent)
        {
            //TODO: if parent use identity key, fix fk member with value from parent
            if (_maLenhCT != 0)
                cm.Parameters.AddWithValue("@MaLenhCT", _maLenhCT);
            else
                cm.Parameters.AddWithValue("@MaLenhCT", DBNull.Value);
            if (parent.MaPhieu != 0)
                cm.Parameters.AddWithValue("@MaPhieu", parent.MaPhieu);
            else
                cm.Parameters.AddWithValue("@MaPhieu", DBNull.Value);
            if (_soTien != 0)
                cm.Parameters.AddWithValue("@SoTien", _soTien);
            else
                cm.Parameters.AddWithValue("@SoTien", DBNull.Value);
            if (_soChungTu.Length > 0)
                cm.Parameters.AddWithValue("@SoChungTu", _soChungTu);
            else
                cm.Parameters.AddWithValue("@SoChungTu", DBNull.Value);
            if (_loaiTien != 0)
                cm.Parameters.AddWithValue("@LoaiTien", _loaiTien);
            else
                cm.Parameters.AddWithValue("@LoaiTien", DBNull.Value);
            if (_tyGia != 0)
                cm.Parameters.AddWithValue("@TyGia", _tyGia);
            else
                cm.Parameters.AddWithValue("@TyGia", DBNull.Value);
            cm.Parameters.AddWithValue("@MaChiTiet", _maChiTiet);
            cm.Parameters["@MaChiTiet"].Direction = ParameterDirection.Output;
        }
        #endregion //Data Access - Insert

        #region Data Access - Update
        internal void Update(SqlTransaction tr, GiayBanNgoaiTe parent)
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

        private void ExecuteUpdate(SqlTransaction tr, GiayBanNgoaiTe parent)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_UpdatetblChuyenTien_BanNgoaiTe";

                AddUpdateParameters(cm, parent);

                cm.ExecuteNonQuery();

            }//using
        }

        private void AddUpdateParameters(SqlCommand cm, GiayBanNgoaiTe parent)
        {
            cm.Parameters.AddWithValue("@MaChiTiet", _maChiTiet);
            if (_maLenhCT != 0)
                cm.Parameters.AddWithValue("@MaLenhCT", _maLenhCT);
            else
                cm.Parameters.AddWithValue("@MaLenhCT", DBNull.Value);
            if (parent.MaPhieu != 0)
                cm.Parameters.AddWithValue("@MaPhieu", parent.MaPhieu);
            else
                cm.Parameters.AddWithValue("@MaPhieu", DBNull.Value);
            if (_soTien != 0)
                cm.Parameters.AddWithValue("@SoTien", _soTien);
            else
                cm.Parameters.AddWithValue("@SoTien", DBNull.Value);
            if (_soChungTu.Length > 0)
                cm.Parameters.AddWithValue("@SoChungTu", _soChungTu);
            else
                cm.Parameters.AddWithValue("@SoChungTu", DBNull.Value);
            if (_loaiTien != 0)
                cm.Parameters.AddWithValue("@LoaiTien", _loaiTien);
            else
                cm.Parameters.AddWithValue("@LoaiTien", DBNull.Value);
            if (_tyGia != 0)
                cm.Parameters.AddWithValue("@TyGia", _tyGia);
            else
                cm.Parameters.AddWithValue("@TyGia", DBNull.Value);
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
                cm.CommandText = "spd_DeletetblChuyenTien_BanNgoaiTe";

                cm.Parameters.AddWithValue("@MaChiTiet", this._maChiTiet);

                cm.ExecuteNonQuery();
            }//using
        }
        #endregion //Data Access - Delete
        #endregion //Data Access
    }
}
