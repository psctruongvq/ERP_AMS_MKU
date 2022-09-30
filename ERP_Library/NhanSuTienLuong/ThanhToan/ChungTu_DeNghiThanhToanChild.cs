
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library.ThanhToan
{
    [Serializable()]
    public class ChungTu_DeNghiThanhToanChild : Csla.BusinessBase<ChungTu_DeNghiThanhToanChild>
    {
        #region Business Properties and Methods

        //declare members
        private long _maCTDNTT = 0;
        private long _maCT = 0;
        private long _maDNTT = 0;
        private decimal _soTien = 0;
        private string _soChungTu = string.Empty;

        public string SoChungTu
        {
            get {
                CanReadProperty("SoChungTu", true);
                return ChungTu.GetChungTu(_maCT).SoChungTu;
            }
           
        }
        [System.ComponentModel.DataObjectField(true, true)]
        public long MaCTDNTT
        {
            get
            {
                CanReadProperty("MaCTDNTT", true);
                return _maCTDNTT;
            }
        }

        public long MaCT
        {
            get
            {
                CanReadProperty("MaCT", true);
                return _maCT;
            }
            set
            {
                CanWriteProperty("MaCT", true);
                if (!_maCT.Equals(value))
                {
                    _maCT = value;
                    PropertyHasChanged("MaCT");
                }
            }
        }

        public long MaDNTT
        {
            get
            {
                CanReadProperty("MaDNTT", true);
                return _maDNTT;
            }
            set
            {
                CanWriteProperty("MaDNTT", true);
                if (!_maDNTT.Equals(value))
                {
                    _maDNTT = value;
                    PropertyHasChanged("MaDNTT");
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

        protected override object GetIdValue()
        {
            return _maCTDNTT;
        }

        #endregion //Business Properties and Methods

        #region Validation Rules
        private void AddCustomRules()
        {
            //add custom/non-generated rules here...
        }

        private void AddCommonRules()
        {

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
            //TODO: Define authorization rules in ChungTu_DeNghiThanhToanChild
            //AuthorizationRules.AllowRead("MaCTDNTT", "ChungTu_DeNghiThanhToanChildReadGroup");
            //AuthorizationRules.AllowRead("MaCT", "ChungTu_DeNghiThanhToanChildReadGroup");
            //AuthorizationRules.AllowRead("MaDNTT", "ChungTu_DeNghiThanhToanChildReadGroup");
            //AuthorizationRules.AllowRead("SoTien", "ChungTu_DeNghiThanhToanChildReadGroup");

            //AuthorizationRules.AllowWrite("MaCT", "ChungTu_DeNghiThanhToanChildWriteGroup");
            //AuthorizationRules.AllowWrite("MaDNTT", "ChungTu_DeNghiThanhToanChildWriteGroup");
            //AuthorizationRules.AllowWrite("SoTien", "ChungTu_DeNghiThanhToanChildWriteGroup");
        }

        #endregion //Authorization Rules

        #region Factory Methods
        internal static ChungTu_DeNghiThanhToanChild NewChungTu_DeNghiThanhToanChild()
        {
            return new ChungTu_DeNghiThanhToanChild();
        }
        public static ChungTu_DeNghiThanhToanChild NewChungTu_DeNghiThanhToanChild(long maDNTT,decimal soTien)
        {
            return new ChungTu_DeNghiThanhToanChild(maDNTT,soTien);
        }
        internal static ChungTu_DeNghiThanhToanChild GetChungTu_DeNghiThanhToanChild(SafeDataReader dr)
        {
            return new ChungTu_DeNghiThanhToanChild(dr);
        }

        private ChungTu_DeNghiThanhToanChild()
        {

            ValidationRules.CheckRules();
            MarkAsChild();
        }
        private ChungTu_DeNghiThanhToanChild(long maDNTT,decimal soTien)
        {
            this.MaDNTT = maDNTT;
            this.SoTien = soTien;

            MarkAsChild();
        }
        private ChungTu_DeNghiThanhToanChild(SafeDataReader dr)
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
            _maCTDNTT = dr.GetInt64("MaCTDNTT");
            _maCT = dr.GetInt64("MaCT");
            _maDNTT = dr.GetInt64("MaDNTT");
            _soTien = dr.GetDecimal("SoTien");
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
                cm.CommandText = "sp_InserttblChungTu_DeNghiThanhToan";

                AddInsertParameters(cm, parent);

                cm.ExecuteNonQuery();

                _maCTDNTT = (long)cm.Parameters["@MaCTDNTT"].Value;
            }//using
        }

        private void AddInsertParameters(SqlCommand cm, ChungTu parent)
        {
            _maCT = parent.MaChungTu;
            //TODO: if parent use identity key, fix fk member with value from parent
            cm.Parameters.AddWithValue("@MaCT", _maCT);
            cm.Parameters.AddWithValue("@MaDNTT", _maDNTT);
            cm.Parameters.AddWithValue("@SoTien", _soTien);
            cm.Parameters.AddWithValue("@MaCTDNTT", _maCTDNTT);
            cm.Parameters["@MaCTDNTT"].Direction = ParameterDirection.Output;
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
                cm.CommandText = "sp_UpdatetblChungTu_DeNghiThanhToan";

                AddUpdateParameters(cm, parent);

                cm.ExecuteNonQuery();

            }//using
        }

        private void AddUpdateParameters(SqlCommand cm, ChungTu parent)
        {
           
            cm.Parameters.AddWithValue("@MaCTDNTT", _maCTDNTT);
            cm.Parameters.AddWithValue("@MaCT", _maCT);
            cm.Parameters.AddWithValue("@MaDNTT", _maDNTT);
            cm.Parameters.AddWithValue("@SoTien", _soTien);
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
                cm.CommandText = "sp_DeletetblChungTu_DeNghiThanhToan";

                cm.Parameters.AddWithValue("@MaCTDNTT", this._maCTDNTT);

                cm.ExecuteNonQuery();
            }//using
        }
        #endregion //Data Access - Delete
        #endregion //Data Access
    }
}
