
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{
    [Serializable()]
    public class ChungTu_UNCChild : Csla.BusinessBase<ChungTu_UNCChild>
    {
        #region Business Properties and Methods

        //declare members
        private long _mactUnc = 0;
        private long _maChungTu = 0;
        private int _maUNC = 0;
        private decimal _soTien = 0;
        private string _soChungTu = string.Empty;
        private string _lyDo = string.Empty;

        [System.ComponentModel.DataObjectField(true, true)]
        public long MactUnc
        {
            get
            {
                CanReadProperty("MactUnc", true);
                return _mactUnc;
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

        public int MaUNC
        {
            get
            {
                CanReadProperty("MaUNC", true);
                return _maUNC;
            }
            set
            {
                CanWriteProperty("MaUNC", true);
                if (!_maUNC.Equals(value))
                {
                    _maUNC = value;
                    PropertyHasChanged("MaUNC");
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
            return _mactUnc;
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
            //TODO: Define authorization rules in ChungTu_UNCChild
            //AuthorizationRules.AllowRead("MactUnc", "ChungTu_UNCChildReadGroup");
            //AuthorizationRules.AllowRead("MaChungTu", "ChungTu_UNCChildReadGroup");
            //AuthorizationRules.AllowRead("MaUNC", "ChungTu_UNCChildReadGroup");
            //AuthorizationRules.AllowRead("SoTien", "ChungTu_UNCChildReadGroup");
            //AuthorizationRules.AllowRead("SoChungTu", "ChungTu_UNCChildReadGroup");
            //AuthorizationRules.AllowRead("LyDo", "ChungTu_UNCChildReadGroup");

            //AuthorizationRules.AllowWrite("MaChungTu", "ChungTu_UNCChildWriteGroup");
            //AuthorizationRules.AllowWrite("MaUNC", "ChungTu_UNCChildWriteGroup");
            //AuthorizationRules.AllowWrite("SoTien", "ChungTu_UNCChildWriteGroup");
            //AuthorizationRules.AllowWrite("SoChungTu", "ChungTu_UNCChildWriteGroup");
            //AuthorizationRules.AllowWrite("LyDo", "ChungTu_UNCChildWriteGroup");
        }

        #endregion //Authorization Rules

        #region Factory Methods
        internal static ChungTu_UNCChild NewChungTu_UNCChild()
        {
            return new ChungTu_UNCChild();
        }

        internal static ChungTu_UNCChild GetChungTu_UNCChild(SafeDataReader dr)
        {
            return new ChungTu_UNCChild(dr);
        }

        public static ChungTu_UNCChild NewChungTu_GiayRutTienChild(int MaUNC, decimal soTien, int LoaiCT, string SoChungTu, string LyDo)
        {
            return new ChungTu_UNCChild(MaUNC, soTien, SoChungTu, LyDo);
        }

        private ChungTu_UNCChild(int MaUNC, decimal soTien, string soChungTu, string lyDo)
        {
            this.LyDo = lyDo;
            this.SoChungTu = soChungTu;
            this.MaUNC = MaUNC;
            this.SoTien = soTien;
            MarkAsChild();
        }

        private ChungTu_UNCChild()
        {

            ValidationRules.CheckRules();
            MarkAsChild();
        }

        private ChungTu_UNCChild(SafeDataReader dr)
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
            _mactUnc = dr.GetInt64("MaCT_UNC");
            _maChungTu = dr.GetInt64("MaChungTu");
            _maUNC = dr.GetInt32("MaUNC");
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
                cm.CommandText = "spd_InserttblChungTu_UyNhiemChi";

                AddInsertParameters(cm, parent);

                cm.ExecuteNonQuery();

                _mactUnc = (long)cm.Parameters["@MaCT_UNC"].Value;
            }//using
        }

        private void AddInsertParameters(SqlCommand cm, ChungTu parent)
        {
            //TODO: if parent use identity key, fix fk member with value from parent
            if (parent.MaChungTu != 0)
                cm.Parameters.AddWithValue("@MaChungTu", parent.MaChungTu);
            else
                cm.Parameters.AddWithValue("@MaChungTu", DBNull.Value);
            if (_maUNC != 0)
                cm.Parameters.AddWithValue("@MaUNC", _maUNC);
            else
                cm.Parameters.AddWithValue("@MaUNC", DBNull.Value);
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
            cm.Parameters.AddWithValue("@MaCT_UNC", _mactUnc);
            cm.Parameters["@MaCT_UNC"].Direction = ParameterDirection.Output;
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
                cm.CommandText = "spd_UpdatetblChungTu_UyNhiemChi";

                AddUpdateParameters(cm, parent);

                cm.ExecuteNonQuery();

            }//using
        }

        private void AddUpdateParameters(SqlCommand cm, ChungTu parent)
        {
            cm.Parameters.AddWithValue("@MaCT_UNC", _mactUnc);
            if (parent.MaChungTu != 0)
                cm.Parameters.AddWithValue("@MaChungTu", parent.MaChungTu);
            else
                cm.Parameters.AddWithValue("@MaChungTu", DBNull.Value);
            if (_maUNC != 0)
                cm.Parameters.AddWithValue("@MaUNC", _maUNC);
            else
                cm.Parameters.AddWithValue("@MaUNC", DBNull.Value);
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
                cm.CommandText = "spd_DeletetblChungTu_UyNhiemChi";

                cm.Parameters.AddWithValue("@MaCT_UNC", this._mactUnc);

                cm.ExecuteNonQuery();
            }//using
        }
        #endregion //Data Access - Delete
        #endregion //Data Access
    }
}
