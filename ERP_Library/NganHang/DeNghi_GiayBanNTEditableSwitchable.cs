
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{
    [Serializable()]
    public class DeNghi_GiayBanNgoaiTe : Csla.BusinessBase<DeNghi_GiayBanNgoaiTe>
    {
        #region Business Properties and Methods

        //declare members
        private long _maChiTiet = 0;
        private long _maDeNghi = 0;
        private long _maPhieu = 0;
        private string _soChungTu = string.Empty;
        private decimal _sotien = 0;
        private decimal _tyGia = 0;
        private int _loaiTien = 0;

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

        public decimal Sotien
        {
            get
            {
                CanReadProperty("Sotien", true);
                return _sotien;
            }
            set
            {
                CanWriteProperty("Sotien", true);
                if (!_sotien.Equals(value))
                {
                    _sotien = value;
                    PropertyHasChanged("Sotien");
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
            //TODO: Define authorization rules in DeNghi_GiayBanNgoaiTe
            //AuthorizationRules.AllowRead("MaChiTiet", "DeNghi_GiayBanNgoaiTeReadGroup");
            //AuthorizationRules.AllowRead("MaDeNghi", "DeNghi_GiayBanNgoaiTeReadGroup");
            //AuthorizationRules.AllowRead("MaPhieu", "DeNghi_GiayBanNgoaiTeReadGroup");
            //AuthorizationRules.AllowRead("SoChungTu", "DeNghi_GiayBanNgoaiTeReadGroup");
            //AuthorizationRules.AllowRead("Sotien", "DeNghi_GiayBanNgoaiTeReadGroup");
            //AuthorizationRules.AllowRead("TyGia", "DeNghi_GiayBanNgoaiTeReadGroup");

            //AuthorizationRules.AllowWrite("MaDeNghi", "DeNghi_GiayBanNgoaiTeWriteGroup");
            //AuthorizationRules.AllowWrite("MaPhieu", "DeNghi_GiayBanNgoaiTeWriteGroup");
            //AuthorizationRules.AllowWrite("SoChungTu", "DeNghi_GiayBanNgoaiTeWriteGroup");
            //AuthorizationRules.AllowWrite("Sotien", "DeNghi_GiayBanNgoaiTeWriteGroup");
            //AuthorizationRules.AllowWrite("TyGia", "DeNghi_GiayBanNgoaiTeWriteGroup");
        }

        #endregion //Authorization Rules

        #region Factory Methods
        internal static DeNghi_GiayBanNgoaiTe NewDeNghi_GiayBanNgoaiTe()
        {
            return new DeNghi_GiayBanNgoaiTe();
        }

        internal static DeNghi_GiayBanNgoaiTe GetDeNghi_GiayBanNgoaiTe(SafeDataReader dr)
        {
            return new DeNghi_GiayBanNgoaiTe(dr);
        }

        public static DeNghi_GiayBanNgoaiTe NewDeNghi_GiayBanNgoaiTe(long maDeNghi, string SoDeNghi, decimal soTien, int LoaiTien)
        {
            DeNghi_GiayBanNgoaiTe child = DeNghi_GiayBanNgoaiTe.NewDeNghi_GiayBanNgoaiTe();
            child.MarkAsChild();
            child.MaDeNghi = maDeNghi;
            child.SoChungTu = SoDeNghi;
            child.Sotien = soTien;
            child.LoaiTien = LoaiTien;
            return child;
        }

        private DeNghi_GiayBanNgoaiTe()
        {

            ValidationRules.CheckRules();
            MarkAsChild();
        }

        private DeNghi_GiayBanNgoaiTe(SafeDataReader dr)
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
            _maPhieu = dr.GetInt64("MaPhieu");
            _soChungTu = dr.GetString("SoChungTu");
            _sotien = dr.GetDecimal("Sotien");
            _tyGia = dr.GetDecimal("TyGia");
            _loaiTien = dr.GetInt32("LoaiTien");
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
                cm.CommandText = "spd_InserttblDeNghi_GiayBanNgoaiTe";

                AddInsertParameters(cm, parent);

                cm.ExecuteNonQuery();

                _maChiTiet = (long)cm.Parameters["@MaChiTiet"].Value;
            }//using
        }

        private void AddInsertParameters(SqlCommand cm, GiayBanNgoaiTe parent)
        {
            //TODO: if parent use identity key, fix fk member with value from parent
            if (_maDeNghi != 0)
                cm.Parameters.AddWithValue("@MaDeNghi", _maDeNghi);
            else
                cm.Parameters.AddWithValue("@MaDeNghi", DBNull.Value);
            if (parent.MaPhieu != 0)
                cm.Parameters.AddWithValue("@MaPhieu", parent.MaPhieu);
            else
                cm.Parameters.AddWithValue("@MaPhieu", DBNull.Value);
            if (_soChungTu.Length > 0)
                cm.Parameters.AddWithValue("@SoChungTu", _soChungTu);
            else
                cm.Parameters.AddWithValue("@SoChungTu", DBNull.Value);
            if (_sotien != 0)
                cm.Parameters.AddWithValue("@Sotien", _sotien);
            else
                cm.Parameters.AddWithValue("@Sotien", DBNull.Value);
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
                cm.CommandText = "spd_UpdatetblDeNghi_GiayBanNgoaiTe";

                AddUpdateParameters(cm, parent);

                cm.ExecuteNonQuery();

            }//using
        }

        private void AddUpdateParameters(SqlCommand cm, GiayBanNgoaiTe parent)
        {
            cm.Parameters.AddWithValue("@MaChiTiet", _maChiTiet);
            if (parent.MaPhieu != 0)
                cm.Parameters.AddWithValue("@MaDeNghi", _maDeNghi);
            else
                cm.Parameters.AddWithValue("@MaDeNghi", DBNull.Value);
            if (parent.MaPhieu != 0)
                cm.Parameters.AddWithValue("@MaPhieu", parent.MaPhieu);
            else
                cm.Parameters.AddWithValue("@MaPhieu", DBNull.Value);
            if (_soChungTu.Length > 0)
                cm.Parameters.AddWithValue("@SoChungTu", _soChungTu);
            else
                cm.Parameters.AddWithValue("@SoChungTu", DBNull.Value);
            if (_sotien != 0)
                cm.Parameters.AddWithValue("@Sotien", _sotien);
            else
                cm.Parameters.AddWithValue("@Sotien", DBNull.Value);
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
                cm.CommandText = "spd_DeletetblDeNghi_GiayBanNgoaiTe";

                cm.Parameters.AddWithValue("@MaChiTiet", this._maChiTiet);

                cm.ExecuteNonQuery();
            }//using
        }
        #endregion //Data Access - Delete
        #endregion //Data Access
    }
}
