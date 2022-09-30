
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{
    [Serializable()]
    public class DeNghi_UyNhiemChi_CacQuy : Csla.BusinessBase<DeNghi_UyNhiemChi_CacQuy>
    {
        #region Business Properties and Methods

        //declare members
        private long _maChiTiet = 0;
        private long _maDeNghi = 0;
        private long _maUyNhiemChi = 0;
        private string _soChungTu = string.Empty;
        private decimal _soTien = 0;
        private decimal _tyGia = 0;
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

        public long MaUyNhiemChi
        {
            get
            {
                CanReadProperty("MaUyNhiemChi", true);
                return _maUyNhiemChi;
            }
            set
            {
                CanWriteProperty("MaUyNhiemChi", true);
                if (!_maUyNhiemChi.Equals(value))
                {
                    _maUyNhiemChi = value;
                    PropertyHasChanged("MaUyNhiemChi");
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
            //TODO: Define authorization rules in DeNghi_UyNhiemChi_CacQuy
            //AuthorizationRules.AllowRead("MaChiTiet", "DeNghi_UyNhiemChi_CacQuyReadGroup");
            //AuthorizationRules.AllowRead("MaDeNghi", "DeNghi_UyNhiemChi_CacQuyReadGroup");
            //AuthorizationRules.AllowRead("MaUyNhiemChi", "DeNghi_UyNhiemChi_CacQuyReadGroup");
            //AuthorizationRules.AllowRead("SoChungTu", "DeNghi_UyNhiemChi_CacQuyReadGroup");
            //AuthorizationRules.AllowRead("SoTien", "DeNghi_UyNhiemChi_CacQuyReadGroup");
            //AuthorizationRules.AllowRead("TyGia", "DeNghi_UyNhiemChi_CacQuyReadGroup");
            //AuthorizationRules.AllowRead("LoaiTien", "DeNghi_UyNhiemChi_CacQuyReadGroup");

            //AuthorizationRules.AllowWrite("MaDeNghi", "DeNghi_UyNhiemChi_CacQuyWriteGroup");
            //AuthorizationRules.AllowWrite("MaUyNhiemChi", "DeNghi_UyNhiemChi_CacQuyWriteGroup");
            //AuthorizationRules.AllowWrite("SoChungTu", "DeNghi_UyNhiemChi_CacQuyWriteGroup");
            //AuthorizationRules.AllowWrite("SoTien", "DeNghi_UyNhiemChi_CacQuyWriteGroup");
            //AuthorizationRules.AllowWrite("TyGia", "DeNghi_UyNhiemChi_CacQuyWriteGroup");
            //AuthorizationRules.AllowWrite("LoaiTien", "DeNghi_UyNhiemChi_CacQuyWriteGroup");
        }

        #endregion //Authorization Rules

        #region Factory Methods
        internal static DeNghi_UyNhiemChi_CacQuy NewDeNghi_UyNhiemChi_CacQuy()
        {
            return new DeNghi_UyNhiemChi_CacQuy();
        }

        internal static DeNghi_UyNhiemChi_CacQuy GetDeNghi_UyNhiemChi_CacQuy(SafeDataReader dr)
        {
            return new DeNghi_UyNhiemChi_CacQuy(dr);
        }

        public static DeNghi_UyNhiemChi_CacQuy NewDeNghi_UyNhiemChi_CacQuy(long maDeNghi, string SoChungTu, decimal soTien, int loaiTien)
        {
            DeNghi_UyNhiemChi_CacQuy child = DeNghi_UyNhiemChi_CacQuy.NewDeNghi_UyNhiemChi_CacQuy();
            child.MarkAsChild();
            child.MaDeNghi = maDeNghi;
            child.SoChungTu = SoChungTu;
            child.SoTien = soTien;
            child.LoaiTien = loaiTien;
            child.TyGia = Convert.ToDecimal(ERP_Library.LoaiTien.GetLoaiTien(loaiTien).TiGiaQuyDoi);
            return child;
        }


        private DeNghi_UyNhiemChi_CacQuy()
        {

            ValidationRules.CheckRules();
            MarkAsChild();
        }

        private DeNghi_UyNhiemChi_CacQuy(SafeDataReader dr)
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
            _maDeNghi = dr.GetInt64("MaDeNghi");
            _maUyNhiemChi = dr.GetInt64("MaUyNhiemChi");
            _soChungTu = dr.GetString("SoChungTu");
            _soTien = dr.GetDecimal("SoTien");
            _tyGia = dr.GetDecimal("TyGia");
            _loaiTien = dr.GetInt32("LoaiTien");
            _thanhTien = _soTien * _tyGia;
        }

        private void FetchChildren(SafeDataReader dr)
        {
        }
        #endregion //Data Access - Fetch

        #region Data Access - Insert
        internal void Insert(SqlTransaction tr, UyNhiemChi_CacQuy parent)
        {
            if (!IsDirty) return;

            ExecuteInsert(tr, parent);
            MarkOld();

            //update child object(s)
            UpdateChildren(tr);
        }

        private void ExecuteInsert(SqlTransaction tr, UyNhiemChi_CacQuy parent)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_InserttblDeNghi_UyNhiemChi_CacQuy";

                AddInsertParameters(cm, parent);

                cm.ExecuteNonQuery();

                _maChiTiet = (long)cm.Parameters["@MaChiTiet"].Value;
            }//using
        }

        private void AddInsertParameters(SqlCommand cm, UyNhiemChi_CacQuy parent)
        {
            //TODO: if parent use identity key, fix fk member with value from parent
            cm.Parameters.AddWithValue("@MaDeNghi", _maDeNghi);
            cm.Parameters.AddWithValue("@MaUyNhiemChi", parent.MaUyNhiemChi);
            if (_soChungTu.Length > 0)
                cm.Parameters.AddWithValue("@SoChungTu", _soChungTu);
            else
                cm.Parameters.AddWithValue("@SoChungTu", DBNull.Value);
            if (_soTien != 0)
                cm.Parameters.AddWithValue("@SoTien", _soTien);
            else
                cm.Parameters.AddWithValue("@SoTien", DBNull.Value);
            if (_tyGia != 0)
                cm.Parameters.AddWithValue("@TyGia", _tyGia);
            else
                cm.Parameters.AddWithValue("@TyGia", DBNull.Value);
            if (_loaiTien != 0)
                cm.Parameters.AddWithValue("@LoaiTien", _loaiTien);
            else
                cm.Parameters.AddWithValue("@LoaiTien", DBNull.Value);
            cm.Parameters.AddWithValue("@MaChiTiet", _maChiTiet);
            cm.Parameters["@MaChiTiet"].Direction = ParameterDirection.Output;
        }
        #endregion //Data Access - Insert

        #region Data Access - Update
        internal void Update(SqlTransaction tr, UyNhiemChi_CacQuy parent)
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

        private void ExecuteUpdate(SqlTransaction tr, UyNhiemChi_CacQuy parent)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_UpdatetblDeNghi_UyNhiemChi_CacQuy";

                AddUpdateParameters(cm, parent);

                cm.ExecuteNonQuery();

            }//using
        }

        private void AddUpdateParameters(SqlCommand cm, UyNhiemChi_CacQuy parent)
        {
            cm.Parameters.AddWithValue("@MaChiTiet", _maChiTiet);
            cm.Parameters.AddWithValue("@MaDeNghi", _maDeNghi);
            cm.Parameters.AddWithValue("@MaUyNhiemChi", parent.MaUyNhiemChi);
            if (_soChungTu.Length > 0)
                cm.Parameters.AddWithValue("@SoChungTu", _soChungTu);
            else
                cm.Parameters.AddWithValue("@SoChungTu", DBNull.Value);
            if (_soTien != 0)
                cm.Parameters.AddWithValue("@SoTien", _soTien);
            else
                cm.Parameters.AddWithValue("@SoTien", DBNull.Value);
            if (_tyGia != 0)
                cm.Parameters.AddWithValue("@TyGia", _tyGia);
            else
                cm.Parameters.AddWithValue("@TyGia", DBNull.Value);
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
                cm.CommandText = "spd_DeletetblDeNghi_UyNhiemChi_CacQuy";

                cm.Parameters.AddWithValue("@MaChiTiet", this._maChiTiet);

                cm.ExecuteNonQuery();
            }//using
        }
        #endregion //Data Access - Delete
        #endregion //Data Access
    }
}
