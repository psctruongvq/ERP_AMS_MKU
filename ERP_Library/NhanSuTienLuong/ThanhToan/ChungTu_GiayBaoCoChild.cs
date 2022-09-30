
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{
    [Serializable()]
    public class ChungTu_GiayBaoCo : Csla.BusinessBase<ChungTu_GiayBaoCo>
    {
        #region Business Properties and Methods

        //declare members
        private long _mactGbc = 0;
        private long _maChungTu = 0;
        private int _maGiayBaoCo = 0;
        private decimal _soTien = 0;
        private string _soChungTu = string.Empty;
        private string _lyDo = string.Empty;

        [System.ComponentModel.DataObjectField(true, true)]
        public long MactGbc
        {
            get
            {
                CanReadProperty("MactGbc", true);
                return _mactGbc;
            }
        }

        public long MaChungTu
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

        public int MaGiayBaoCo
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
            return _mactGbc;
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
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("SoChungTu", 200));
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
            //TODO: Define authorization rules in ChungTu_GiayBaoCo
            //AuthorizationRules.AllowRead("MactGbc", "ChungTu_GiayBaoCoReadGroup");
            //AuthorizationRules.AllowRead("MaChungTu", "ChungTu_GiayBaoCoReadGroup");
            //AuthorizationRules.AllowRead("MaGiayBaoCo", "ChungTu_GiayBaoCoReadGroup");
            //AuthorizationRules.AllowRead("SoTien", "ChungTu_GiayBaoCoReadGroup");
            //AuthorizationRules.AllowRead("SoChungTu", "ChungTu_GiayBaoCoReadGroup");
            //AuthorizationRules.AllowRead("LyDo", "ChungTu_GiayBaoCoReadGroup");

            //AuthorizationRules.AllowWrite("MaChungTu", "ChungTu_GiayBaoCoWriteGroup");
            //AuthorizationRules.AllowWrite("MaGiayBaoCo", "ChungTu_GiayBaoCoWriteGroup");
            //AuthorizationRules.AllowWrite("SoTien", "ChungTu_GiayBaoCoWriteGroup");
            //AuthorizationRules.AllowWrite("SoChungTu", "ChungTu_GiayBaoCoWriteGroup");
            //AuthorizationRules.AllowWrite("LyDo", "ChungTu_GiayBaoCoWriteGroup");
        }

        #endregion //Authorization Rules

        #region Factory Methods
        internal static ChungTu_GiayBaoCo NewChungTu_GiayBaoCo()
        {
            return new ChungTu_GiayBaoCo();
        }

        internal static ChungTu_GiayBaoCo GetChungTu_GiayBaoCo(SafeDataReader dr)
        {
            return new ChungTu_GiayBaoCo(dr);
        }

        public static ChungTu_GiayBaoCo NewChungTu_GiayBaoCo(int maGBC, decimal soTien, int LoaiCT, string SoChungTu, string LyDo)
        {
            return new ChungTu_GiayBaoCo(maGBC, soTien, SoChungTu, LyDo);
        }

        private ChungTu_GiayBaoCo()
        {

            ValidationRules.CheckRules();
            MarkAsChild();
        }

        private ChungTu_GiayBaoCo(int maGBC, decimal soTien)
        {
            this.MaGiayBaoCo = maGBC;
            this.SoTien = soTien;

            MarkAsChild();
        }

        private ChungTu_GiayBaoCo(int maGBC, decimal soTien, string soChungTu, string lyDo)
        {
            this.LyDo = lyDo;
            this.SoChungTu = soChungTu;
            this.MaGiayBaoCo = maGBC;
            this.SoTien = soTien;
            MarkAsChild();
        }

        private ChungTu_GiayBaoCo(SafeDataReader dr)
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
            _mactGbc = dr.GetInt64("MaCT_GBC");
            _maChungTu = dr.GetInt64("MaChungTu");
            _maGiayBaoCo = dr.GetInt32("MaGiayBaoCo");
            _soTien = dr.GetDecimal("SoTien");
            _soChungTu = dr.GetString("SoChungTu");
            _lyDo = dr.GetString("LyDo");
        }

        private void FetchChildren(SafeDataReader dr)
        {
        }
        #endregion //Data Access - Fetch

        #region Data Access - Insert
        internal void Insert(SqlTransaction tr, ChungTu parent)
        {
            if (!IsDirty) return;

            ExecuteInsert(tr, parent);
            MarkOld();

            //update child object(s)
            UpdateChildren(tr);
        }

        private void ExecuteInsert(SqlTransaction tr, ChungTu parent)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_InserttblChungTu_GiayBaoCo";

                AddInsertParameters(cm, parent);

                cm.ExecuteNonQuery();

                _mactGbc = (long)cm.Parameters["@MaCT_GBC"].Value;
            }//using
        }

        private void AddInsertParameters(SqlCommand cm, ChungTu parent)
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
            if (_soTien != 0)
                cm.Parameters.AddWithValue("@SoTien", _soTien);
            else
                cm.Parameters.AddWithValue("@SoTien", DBNull.Value);
            if (_soChungTu.Length > 0)
                cm.Parameters.AddWithValue("@SoChungTu", _soChungTu);
            else
                cm.Parameters.AddWithValue("@SoChungTu", DBNull.Value);
            if (_lyDo.Length > 0)
                cm.Parameters.AddWithValue("@LyDo", _lyDo);
            else
                cm.Parameters.AddWithValue("@LyDo", DBNull.Value);
            cm.Parameters.AddWithValue("@MaCT_GBC", _mactGbc);
            cm.Parameters["@MaCT_GBC"].Direction = ParameterDirection.Output;
        }
        #endregion //Data Access - Insert

        #region Data Access - Update
        internal void Update(SqlTransaction tr, ChungTu parent)
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

        private void ExecuteUpdate(SqlTransaction tr, ChungTu parent)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_UpdatetblChungTu_GiayBaoCo";

                AddUpdateParameters(cm, parent);

                cm.ExecuteNonQuery();
            }//using
        }

        private void AddUpdateParameters(SqlCommand cm, ChungTu parent)
        {
            cm.Parameters.AddWithValue("@MaCT_GBC", _mactGbc);
            if (parent.MaChungTu != 0)
                cm.Parameters.AddWithValue("@MaChungTu", parent.MaChungTu);
            else
                cm.Parameters.AddWithValue("@MaChungTu", DBNull.Value);
            if (_maGiayBaoCo != 0)
                cm.Parameters.AddWithValue("@MaGiayBaoCo", _maGiayBaoCo);
            else
                cm.Parameters.AddWithValue("@MaGiayBaoCo", DBNull.Value);
            if (_soTien != 0)
                cm.Parameters.AddWithValue("@SoTien", _soTien);
            else
                cm.Parameters.AddWithValue("@SoTien", DBNull.Value);
            if (_soChungTu.Length > 0)
                cm.Parameters.AddWithValue("@SoChungTu", _soChungTu);
            else
                cm.Parameters.AddWithValue("@SoChungTu", DBNull.Value);
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
                cm.CommandText = "spd_DeletetblChungTu_GiayBaoCo";

                cm.Parameters.AddWithValue("@MaCT_GBC", this._mactGbc);

                cm.ExecuteNonQuery();
            }//using
        }
        #endregion //Data Access - Delete
        #endregion //Data Access
    }
}
