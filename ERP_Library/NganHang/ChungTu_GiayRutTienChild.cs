
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{
    [Serializable()]
    public class ChungTu_GiayRutTienChild : Csla.BusinessBase<ChungTu_GiayRutTienChild>
    {
        #region Business Properties and Methods

        //declare members
        private long _mactGiayruttien = 0;
        private long _maChungTu = 0;
        private long _maGiayRutTien = 0;
        private string _soChungTu = string.Empty;
        private decimal _soTien = 0;
        private string _lyDo = string.Empty;

        [System.ComponentModel.DataObjectField(true, true)]
        public long MactGiayruttien
        {
            get
            {
                CanReadProperty("MactGiayruttien", true);
                return _mactGiayruttien;
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

        public long MaGiayRutTien
        {
            get
            {
                CanReadProperty("MaGiayRutTien", true);
                return _maGiayRutTien;
            }
            set
            {
                CanWriteProperty("MaGiayRutTien", true);
                if (!_maGiayRutTien.Equals(value))
                {
                    _maGiayRutTien = value;
                    PropertyHasChanged("MaGiayRutTien");
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
            return _mactGiayruttien;
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
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("SoChungTu", 500));
            //
            // LyDo
            //
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("LyDo", 500));
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
            //TODO: Define authorization rules in ChungTu_GiayRutTienChild
            //AuthorizationRules.AllowRead("MactGiayruttien", "ChungTu_GiayRutTienChildReadGroup");
            //AuthorizationRules.AllowRead("MaChungTu", "ChungTu_GiayRutTienChildReadGroup");
            //AuthorizationRules.AllowRead("MaGiayRutTien", "ChungTu_GiayRutTienChildReadGroup");
            //AuthorizationRules.AllowRead("SoChungTu", "ChungTu_GiayRutTienChildReadGroup");
            //AuthorizationRules.AllowRead("SoTien", "ChungTu_GiayRutTienChildReadGroup");
            //AuthorizationRules.AllowRead("LyDo", "ChungTu_GiayRutTienChildReadGroup");

            //AuthorizationRules.AllowWrite("MaChungTu", "ChungTu_GiayRutTienChildWriteGroup");
            //AuthorizationRules.AllowWrite("MaGiayRutTien", "ChungTu_GiayRutTienChildWriteGroup");
            //AuthorizationRules.AllowWrite("SoChungTu", "ChungTu_GiayRutTienChildWriteGroup");
            //AuthorizationRules.AllowWrite("SoTien", "ChungTu_GiayRutTienChildWriteGroup");
            //AuthorizationRules.AllowWrite("LyDo", "ChungTu_GiayRutTienChildWriteGroup");
        }

        #endregion //Authorization Rules

        #region Factory Methods
        internal static ChungTu_GiayRutTienChild NewChungTu_GiayRutTienChild()
        {
            return new ChungTu_GiayRutTienChild();
        }

        internal static ChungTu_GiayRutTienChild GetChungTu_GiayRutTienChild(SafeDataReader dr)
        {
            return new ChungTu_GiayRutTienChild(dr);
        }

        public static ChungTu_GiayRutTienChild NewChungTu_GiayRutTienChild(int maGiayRutTien, decimal soTien, int LoaiCT, string SoChungTu, string LyDo)
        {
            return new ChungTu_GiayRutTienChild(maGiayRutTien, soTien, SoChungTu, LyDo);
        }

        private ChungTu_GiayRutTienChild(int maGiayRutTien, decimal soTien, string soChungTu, string lyDo)
        {
            this.LyDo = lyDo;
            this.SoChungTu = soChungTu;
            this.MaGiayRutTien = maGiayRutTien;
            this.SoTien = soTien;
            MarkAsChild();
        }

        private ChungTu_GiayRutTienChild()
        {

            ValidationRules.CheckRules();
            MarkAsChild();
        }

        private ChungTu_GiayRutTienChild(SafeDataReader dr)
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
            _mactGiayruttien = dr.GetInt64("MaCT_GiayRutTien");
            _maChungTu = dr.GetInt64("MaChungTu");
            _maGiayRutTien = dr.GetInt64("MaGiayRutTien");
            _soChungTu = dr.GetString("SoChungTu");
            _soTien = dr.GetDecimal("SoTien");
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
                cm.CommandText = "spd_InserttblChungTu_GiayRutTien";

                AddInsertParameters(cm, parent);

                cm.ExecuteNonQuery();

                _mactGiayruttien = (long)cm.Parameters["@MaCT_GiayRutTien"].Value;
            }//using
        }

        private void AddInsertParameters(SqlCommand cm, ChungTu parent)
        {
            //TODO: if parent use identity key, fix fk member with value from parent
            if (parent.MaChungTu != 0)
                cm.Parameters.AddWithValue("@MaChungTu", parent.MaChungTu);
            else
                cm.Parameters.AddWithValue("@MaChungTu", DBNull.Value);
            if (_maGiayRutTien != 0)
                cm.Parameters.AddWithValue("@MaGiayRutTien", _maGiayRutTien);
            else
                cm.Parameters.AddWithValue("@MaGiayRutTien", DBNull.Value);
            if (_soChungTu.Length > 0)
                cm.Parameters.AddWithValue("@SoChungTu", _soChungTu);
            else
                cm.Parameters.AddWithValue("@SoChungTu", DBNull.Value);
            if (_soTien != 0)
                cm.Parameters.AddWithValue("@SoTien", _soTien);
            else
                cm.Parameters.AddWithValue("@SoTien", DBNull.Value);
            if (_lyDo.Length > 0)
                cm.Parameters.AddWithValue("@LyDo", _lyDo);
            else
                cm.Parameters.AddWithValue("@LyDo", DBNull.Value);
            cm.Parameters.AddWithValue("@MaCT_GiayRutTien", _mactGiayruttien);
            cm.Parameters["@MaCT_GiayRutTien"].Direction = ParameterDirection.Output;
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
                cm.CommandText = "spd_UpdatetblChungTu_GiayRutTien";

                AddUpdateParameters(cm, parent);

                cm.ExecuteNonQuery();

            }//using
        }

        private void AddUpdateParameters(SqlCommand cm, ChungTu parent)
        {
            cm.Parameters.AddWithValue("@MaCT_GiayRutTien", _mactGiayruttien);
            if (parent.MaChungTu != 0)
                cm.Parameters.AddWithValue("@MaChungTu", parent.MaChungTu);
            else
                cm.Parameters.AddWithValue("@MaChungTu", DBNull.Value);
            if (_maGiayRutTien != 0)
                cm.Parameters.AddWithValue("@MaGiayRutTien", _maGiayRutTien);
            else
                cm.Parameters.AddWithValue("@MaGiayRutTien", DBNull.Value);
            if (_soChungTu.Length > 0)
                cm.Parameters.AddWithValue("@SoChungTu", _soChungTu);
            else
                cm.Parameters.AddWithValue("@SoChungTu", DBNull.Value);
            if (_soTien != 0)
                cm.Parameters.AddWithValue("@SoTien", _soTien);
            else
                cm.Parameters.AddWithValue("@SoTien", DBNull.Value);
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
                cm.CommandText = "spd_DeletetblChungTu_GiayRutTien";

                cm.Parameters.AddWithValue("@MaCT_GiayRutTien", this._mactGiayruttien);

                cm.ExecuteNonQuery();
            }//using
        }
        #endregion //Data Access - Delete
        #endregion //Data Access
    }
}
