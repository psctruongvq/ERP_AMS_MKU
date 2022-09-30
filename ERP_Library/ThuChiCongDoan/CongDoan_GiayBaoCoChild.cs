
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{
    [Serializable()]
    public class CongDoan_GiayBaoCo : Csla.BusinessBase<CongDoan_GiayBaoCo>
    {
        #region Business Properties and Methods

        //declare members
        private long _maChiTiet = 0;
        private int _maChungTu = 0;
        private long _maGiayBaoCo = 0;
        private string _soChungTu = string.Empty;
        private decimal _soTien = 0;
        private int _loaiDeNghi = 0;
        private string _lyDo = string.Empty;

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

        public long MaGiayBaoCo
        {
            get
            {
                CanReadProperty("MaGiayBaoCo", true);
                return _maGiayBaoCo;
            }
            set
            {
                CanWriteProperty("MaGiayBaoCo", true);
                if (!_maGiayBaoCo.Equals(value))
                {
                    _maGiayBaoCo = value;
                    PropertyHasChanged("MaGiayBaoCo");
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

        public int LoaiDeNghi
        {
            get
            {
                CanReadProperty("LoaiDeNghi", true);
                return _loaiDeNghi;
            }
            set
            {
                CanWriteProperty("LoaiDeNghi", true);
                if (!_loaiDeNghi.Equals(value))
                {
                    _loaiDeNghi = value;
                    PropertyHasChanged("LoaiDeNghi");
                }
            }
        }

        public string LyDo
        {
            get
            {
                CanReadProperty("LyDo", true);
                return _lyDo;
            }
            set
            {
                CanWriteProperty("LyDo", true);
                if (value == null) value = string.Empty;
                if (!_lyDo.Equals(value))
                {
                    _lyDo = value;
                    PropertyHasChanged("LyDo");
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
            //
            // LyDo
            //
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("LyDo", 4000));
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
            //TODO: Define authorization rules in CongDoan_GiayBaoCo
            //AuthorizationRules.AllowRead("MaChiTiet", "CongDoan_GiayBaoCoReadGroup");
            //AuthorizationRules.AllowRead("MaChungTu", "CongDoan_GiayBaoCoReadGroup");
            //AuthorizationRules.AllowRead("MaGiayBaoCo", "CongDoan_GiayBaoCoReadGroup");
            //AuthorizationRules.AllowRead("SoChungTu", "CongDoan_GiayBaoCoReadGroup");
            //AuthorizationRules.AllowRead("SoTien", "CongDoan_GiayBaoCoReadGroup");
            //AuthorizationRules.AllowRead("LoaiDeNghi", "CongDoan_GiayBaoCoReadGroup");
            //AuthorizationRules.AllowRead("LyDo", "CongDoan_GiayBaoCoReadGroup");

            //AuthorizationRules.AllowWrite("MaChungTu", "CongDoan_GiayBaoCoWriteGroup");
            //AuthorizationRules.AllowWrite("MaGiayBaoCo", "CongDoan_GiayBaoCoWriteGroup");
            //AuthorizationRules.AllowWrite("SoChungTu", "CongDoan_GiayBaoCoWriteGroup");
            //AuthorizationRules.AllowWrite("SoTien", "CongDoan_GiayBaoCoWriteGroup");
            //AuthorizationRules.AllowWrite("LoaiDeNghi", "CongDoan_GiayBaoCoWriteGroup");
            //AuthorizationRules.AllowWrite("LyDo", "CongDoan_GiayBaoCoWriteGroup");
        }

        #endregion //Authorization Rules

        #region Factory Methods
        internal static CongDoan_GiayBaoCo NewCongDoan_GiayBaoCo()
        {
            return new CongDoan_GiayBaoCo();
        }

        internal static CongDoan_GiayBaoCo GetCongDoan_GiayBaoCo(SafeDataReader dr)
        {
            return new CongDoan_GiayBaoCo(dr);
        }

        public static CongDoan_GiayBaoCo NewCongDoan_GiayBaoCo(int maGBC, decimal soTien, string SoChungTu, string LyDo)
        {
            return new CongDoan_GiayBaoCo(maGBC, soTien, SoChungTu, LyDo);
        }

        private CongDoan_GiayBaoCo()
        {

            ValidationRules.CheckRules();
            MarkAsChild();
        }

        private CongDoan_GiayBaoCo(long maGBC, decimal SoTien, string SoChungTu, string LyDo)
        {
            this.MaGiayBaoCo = maGBC;
            this.SoTien = SoTien;
            this.SoChungTu = SoChungTu;
            this.LyDo = LyDo;
            this.MarkAsChild();
        }

        private CongDoan_GiayBaoCo(SafeDataReader dr)
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
            _maGiayBaoCo = dr.GetInt64("MaGiayBaoCo");
            _soChungTu = dr.GetString("SoChungTu");
            _soTien = dr.GetDecimal("SoTien");
            _loaiDeNghi = dr.GetInt32("LoaiDeNghi");
            _lyDo = dr.GetString("LyDo");
        }

        private void FetchChildren(SafeDataReader dr)
        {
        }
        #endregion //Data Access - Fetch

        #region Data Access - Insert
        internal void Insert(SqlTransaction tr, CongDoan_ChungTu parent)
        {
            if (!IsDirty) return;

            ExecuteInsert(tr, parent);
            MarkOld();

            //update child object(s)
            UpdateChildren(tr);
        }

        private void ExecuteInsert(SqlTransaction tr, CongDoan_ChungTu parent)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_InserttblCongDoan_GiayBaoCo";

                AddInsertParameters(cm, parent);

                cm.ExecuteNonQuery();

                _maChiTiet = (long)cm.Parameters["@MaChiTiet"].Value;
            }//using
        }

        private void AddInsertParameters(SqlCommand cm, CongDoan_ChungTu parent)
        {
            //TODO: if parent use identity key, fix fk member with value from parent
            if (parent.MaChungTu != 0)
                cm.Parameters.AddWithValue("@MaChungTu", parent.MaChungTu);
            else
                cm.Parameters.AddWithValue("@MaChungTu", DBNull.Value);
            if (_maGiayBaoCo != 0)
                cm.Parameters.AddWithValue("@MaGiayBaoCo", _maGiayBaoCo);
            else
                cm.Parameters.AddWithValue("@MaGiayBaoCo", DBNull.Value);
            if (_soChungTu.Length > 0)
                cm.Parameters.AddWithValue("@SoChungTu", _soChungTu);
            else
                cm.Parameters.AddWithValue("@SoChungTu", DBNull.Value);
            if (_soTien != 0)
                cm.Parameters.AddWithValue("@SoTien", _soTien);
            else
                cm.Parameters.AddWithValue("@SoTien", DBNull.Value);
            if (_loaiDeNghi != 0)
                cm.Parameters.AddWithValue("@LoaiDeNghi", _loaiDeNghi);
            else
                cm.Parameters.AddWithValue("@LoaiDeNghi", DBNull.Value);
            if (_lyDo.Length > 0)
                cm.Parameters.AddWithValue("@LyDo", _lyDo);
            else
                cm.Parameters.AddWithValue("@LyDo", DBNull.Value);
            cm.Parameters.AddWithValue("@MaChiTiet", _maChiTiet);
            cm.Parameters["@MaChiTiet"].Direction = ParameterDirection.Output;
        }
        #endregion //Data Access - Insert

        #region Data Access - Update
        internal void Update(SqlTransaction tr, CongDoan_ChungTu parent)
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

        private void ExecuteUpdate(SqlTransaction tr, CongDoan_ChungTu parent)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_UpdatetblCongDoan_GiayBaoCo";

                AddUpdateParameters(cm, parent);

                cm.ExecuteNonQuery();

            }//using
        }

        private void AddUpdateParameters(SqlCommand cm, CongDoan_ChungTu parent)
        {
            cm.Parameters.AddWithValue("@MaChiTiet", _maChiTiet);
            if (parent.MaChungTu != 0)
                cm.Parameters.AddWithValue("@MaChungTu", parent.MaChungTu);
            else
                cm.Parameters.AddWithValue("@MaChungTu", DBNull.Value);
            if (_maGiayBaoCo != 0)
                cm.Parameters.AddWithValue("@MaGiayBaoCo", _maGiayBaoCo);
            else
                cm.Parameters.AddWithValue("@MaGiayBaoCo", DBNull.Value);
            if (_soChungTu.Length > 0)
                cm.Parameters.AddWithValue("@SoChungTu", _soChungTu);
            else
                cm.Parameters.AddWithValue("@SoChungTu", DBNull.Value);
            if (_soTien != 0)
                cm.Parameters.AddWithValue("@SoTien", _soTien);
            else
                cm.Parameters.AddWithValue("@SoTien", DBNull.Value);
            if (_loaiDeNghi != 0)
                cm.Parameters.AddWithValue("@LoaiDeNghi", _loaiDeNghi);
            else
                cm.Parameters.AddWithValue("@LoaiDeNghi", DBNull.Value);
            if (_lyDo.Length > 0)
                cm.Parameters.AddWithValue("@LyDo", _lyDo);
            else
                cm.Parameters.AddWithValue("@LyDo", DBNull.Value);
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
                cm.CommandText = "spd_DeletetblCongDoan_GiayBaoCo";

                cm.Parameters.AddWithValue("@MaChiTiet", this._maChiTiet);

                cm.ExecuteNonQuery();
            }//using
        }
        #endregion //Data Access - Delete
        #endregion //Data Access
    }
}
