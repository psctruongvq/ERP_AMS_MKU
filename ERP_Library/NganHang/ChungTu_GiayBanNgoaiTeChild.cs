
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{
    [Serializable()]
    public class ChungTu_GiayBanNgoaiTeChild : Csla.BusinessBase<ChungTu_GiayBanNgoaiTeChild>
    {
        #region Business Properties and Methods

        //declare members
        private long _mactGbnt = 0;
        private long _maChungTu = 0;
        private long _maPhieu = 0;
        private decimal _soTien = 0;
        private string _soChungTu = string.Empty;
        private string _lyDo = string.Empty;

        [System.ComponentModel.DataObjectField(true, true)]
        public long MactGbnt
        {
            get
            {
                CanReadProperty("MactGbnt", true);
                return _mactGbnt;
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
            return _mactGbnt;
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
            //TODO: Define authorization rules in ChungTu_GiayBanNgoaiTeChild
            //AuthorizationRules.AllowRead("MactGbnt", "ChungTu_GiayBanNgoaiTeChildReadGroup");
            //AuthorizationRules.AllowRead("MaChungTu", "ChungTu_GiayBanNgoaiTeChildReadGroup");
            //AuthorizationRules.AllowRead("MaPhieu", "ChungTu_GiayBanNgoaiTeChildReadGroup");
            //AuthorizationRules.AllowRead("SoTien", "ChungTu_GiayBanNgoaiTeChildReadGroup");
            //AuthorizationRules.AllowRead("SoChungTu", "ChungTu_GiayBanNgoaiTeChildReadGroup");
            //AuthorizationRules.AllowRead("LyDo", "ChungTu_GiayBanNgoaiTeChildReadGroup");

            //AuthorizationRules.AllowWrite("MaChungTu", "ChungTu_GiayBanNgoaiTeChildWriteGroup");
            //AuthorizationRules.AllowWrite("MaPhieu", "ChungTu_GiayBanNgoaiTeChildWriteGroup");
            //AuthorizationRules.AllowWrite("SoTien", "ChungTu_GiayBanNgoaiTeChildWriteGroup");
            //AuthorizationRules.AllowWrite("SoChungTu", "ChungTu_GiayBanNgoaiTeChildWriteGroup");
            //AuthorizationRules.AllowWrite("LyDo", "ChungTu_GiayBanNgoaiTeChildWriteGroup");
        }

        #endregion //Authorization Rules

        #region Factory Methods
        internal static ChungTu_GiayBanNgoaiTeChild NewChungTu_GiayBanNgoaiTeChild()
        {
            return new ChungTu_GiayBanNgoaiTeChild();
        }

        internal static ChungTu_GiayBanNgoaiTeChild GetChungTu_GiayBanNgoaiTeChild(SafeDataReader dr)
        {
            return new ChungTu_GiayBanNgoaiTeChild(dr);
        }

        public static ChungTu_GiayBanNgoaiTeChild NewChungTu_GiayBanNgoaiTeChild(int maBNT, decimal soTien, int LoaiCT, string SoChungTu, string LyDo)
        {
            return new ChungTu_GiayBanNgoaiTeChild(maBNT, soTien, SoChungTu, LyDo);
        }

        private ChungTu_GiayBanNgoaiTeChild()
        {

            ValidationRules.CheckRules();
            MarkAsChild();
        }

        private ChungTu_GiayBanNgoaiTeChild(int maBNT, decimal soTien, string soChungTu, string lyDo)
        {
            this.LyDo = lyDo;
            this.SoChungTu = soChungTu;
            this.MaPhieu = maBNT;
            this.SoTien = soTien;
            MarkAsChild();
        }

        private ChungTu_GiayBanNgoaiTeChild(SafeDataReader dr)
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
            _mactGbnt = dr.GetInt64("MaCT_GBNT");
            _maChungTu = dr.GetInt64("MaChungTu");
            _maPhieu = dr.GetInt64("MaPhieu");
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
                cm.CommandText = "spd_InserttblChungTu_GiayBanNT";

                AddInsertParameters(cm, parent);

                cm.ExecuteNonQuery();

                _mactGbnt = (long)cm.Parameters["@MaCT_GBNT"].Value;
            }//using
        }

        private void AddInsertParameters(SqlCommand cm, ChungTu parent)
        {
            //TODO: if parent use identity key, fix fk member with value from parent
            if (parent.MaChungTu != 0)
                cm.Parameters.AddWithValue("@MaChungTu", parent.MaChungTu);
            else
                cm.Parameters.AddWithValue("@MaChungTu", DBNull.Value);
            if (_maPhieu != 0)
                cm.Parameters.AddWithValue("@MaPhieu", _maPhieu);
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
            if (_lyDo.Length > 0)
                cm.Parameters.AddWithValue("@LyDo", _lyDo);
            else
                cm.Parameters.AddWithValue("@LyDo", DBNull.Value);
            cm.Parameters.AddWithValue("@MaCT_GBNT", _mactGbnt);
            cm.Parameters["@MaCT_GBNT"].Direction = ParameterDirection.Output;
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
                cm.CommandText = "spd_UpdatetblChungTu_GiayBanNT";

                AddUpdateParameters(cm, parent);

                cm.ExecuteNonQuery();

            }//using
        }

        private void AddUpdateParameters(SqlCommand cm, ChungTu parent)
        {
            cm.Parameters.AddWithValue("@MaCT_GBNT", _mactGbnt);
            if (parent.MaChungTu != 0)
                cm.Parameters.AddWithValue("@MaChungTu", parent.MaChungTu);
            else
                cm.Parameters.AddWithValue("@MaChungTu", DBNull.Value);
            if (_maPhieu != 0)
                cm.Parameters.AddWithValue("@MaPhieu", _maPhieu);
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
                cm.CommandText = "spd_DeletetblChungTu_GiayBanNT";

                cm.Parameters.AddWithValue("@MaCT_GBNT", this._mactGbnt);

                cm.ExecuteNonQuery();
            }//using
        }
        #endregion //Data Access - Delete
        #endregion //Data Access
    }
}
