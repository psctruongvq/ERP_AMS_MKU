
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{
    [Serializable()]
    public class ChungTu_LenhChuyenTienNNChild : Csla.BusinessBase<ChungTu_LenhChuyenTienNNChild>
    {
        #region Business Properties and Methods

        //declare members
        private long _mactLenhct = 0;
        private long _maChungTu = 0;
        private long _maLenhCT = 0;
        private decimal _soTien = 0;
        private string _soChungTu = string.Empty;
        private string _lyDo = string.Empty;

        [System.ComponentModel.DataObjectField(true, true)]
        public long MactLenhct
        {
            get
            {
                CanReadProperty("MactLenhct", true);
                return _mactLenhct;
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
            return _mactLenhct;
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
            //TODO: Define authorization rules in ChungTu_LenhChuyenTienNNChild
            //AuthorizationRules.AllowRead("MactLenhct", "ChungTu_LenhChuyenTienNNChildReadGroup");
            //AuthorizationRules.AllowRead("MaChungTu", "ChungTu_LenhChuyenTienNNChildReadGroup");
            //AuthorizationRules.AllowRead("MaLenhCT", "ChungTu_LenhChuyenTienNNChildReadGroup");
            //AuthorizationRules.AllowRead("SoTien", "ChungTu_LenhChuyenTienNNChildReadGroup");
            //AuthorizationRules.AllowRead("SoChungTu", "ChungTu_LenhChuyenTienNNChildReadGroup");
            //AuthorizationRules.AllowRead("LyDo", "ChungTu_LenhChuyenTienNNChildReadGroup");

            //AuthorizationRules.AllowWrite("MaChungTu", "ChungTu_LenhChuyenTienNNChildWriteGroup");
            //AuthorizationRules.AllowWrite("MaLenhCT", "ChungTu_LenhChuyenTienNNChildWriteGroup");
            //AuthorizationRules.AllowWrite("SoTien", "ChungTu_LenhChuyenTienNNChildWriteGroup");
            //AuthorizationRules.AllowWrite("SoChungTu", "ChungTu_LenhChuyenTienNNChildWriteGroup");
            //AuthorizationRules.AllowWrite("LyDo", "ChungTu_LenhChuyenTienNNChildWriteGroup");
        }

        #endregion //Authorization Rules

        #region Factory Methods
        internal static ChungTu_LenhChuyenTienNNChild NewChungTu_LenhChuyenTienNNChild()
        {
            return new ChungTu_LenhChuyenTienNNChild();
        }

        internal static ChungTu_LenhChuyenTienNNChild GetChungTu_LenhChuyenTienNNChild(SafeDataReader dr)
        {
            return new ChungTu_LenhChuyenTienNNChild(dr);
        }

        public static ChungTu_LenhChuyenTienNNChild NewChungTu_LenhChuyenTienNNChild(int maLenhCT, decimal soTien, int LoaiCT, string SoChungTu, string LyDo)
        {
            return new ChungTu_LenhChuyenTienNNChild(maLenhCT, soTien, SoChungTu, LyDo);
        }

        private ChungTu_LenhChuyenTienNNChild()
        {

            ValidationRules.CheckRules();
            MarkAsChild();
        }

        private ChungTu_LenhChuyenTienNNChild(SafeDataReader dr)
        {
            MarkAsChild();
            Fetch(dr);
        }

        private ChungTu_LenhChuyenTienNNChild(int maLenhCT, decimal soTien, string soChungTu, string lyDo)
        {
            this.LyDo = lyDo;
            this.SoChungTu = soChungTu;
            this.MaLenhCT = maLenhCT;
            this.SoTien = soTien;
            MarkAsChild();
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
            _mactLenhct = dr.GetInt64("MaCT_LenhCT");
            _maChungTu = dr.GetInt64("MaChungTu");
            _maLenhCT = dr.GetInt64("MaLenhCT");
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
                cm.CommandText = "spd_InserttblChungTu_LenhChuyenTien";

                AddInsertParameters(cm, parent);

                cm.ExecuteNonQuery();

                _mactLenhct = (long)cm.Parameters["@MaCT_LenhCT"].Value;
            }//using
        }

        private void AddInsertParameters(SqlCommand cm, ChungTu parent)
        {
            //TODO: if parent use identity key, fix fk member with value from parent
            if (parent.MaChungTu != 0)
                cm.Parameters.AddWithValue("@MaChungTu", parent.MaChungTu);
            else
                cm.Parameters.AddWithValue("@MaChungTu", DBNull.Value);
            if (_maLenhCT != 0)
                cm.Parameters.AddWithValue("@MaLenhCT", _maLenhCT);
            else
                cm.Parameters.AddWithValue("@MaLenhCT", DBNull.Value);
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
            cm.Parameters.AddWithValue("@MaCT_LenhCT", _mactLenhct);
            cm.Parameters["@MaCT_LenhCT"].Direction = ParameterDirection.Output;
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
                cm.CommandText = "spd_UpdatetblChungTu_LenhChuyenTien";

                AddUpdateParameters(cm, parent);

                cm.ExecuteNonQuery();

            }//using
        }

        private void AddUpdateParameters(SqlCommand cm, ChungTu parent)
        {
            cm.Parameters.AddWithValue("@MaCT_LenhCT", _mactLenhct);
            if (parent.MaChungTu != 0)
                cm.Parameters.AddWithValue("@MaChungTu", parent.MaChungTu);
            else
                cm.Parameters.AddWithValue("@MaChungTu", DBNull.Value);
            if (_maLenhCT != 0)
                cm.Parameters.AddWithValue("@MaLenhCT", _maLenhCT);
            else
                cm.Parameters.AddWithValue("@MaLenhCT", DBNull.Value);
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
                cm.CommandText = "spd_DeletetblChungTu_LenhChuyenTien";

                cm.Parameters.AddWithValue("@MaCT_LenhCT", this._mactLenhct);

                cm.ExecuteNonQuery();
            }//using
        }
        #endregion //Data Access - Delete
        #endregion //Data Access
    }
}
