
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library.ThanhToan
{
    [Serializable()]
    public class ChungTu_DeNghiThuChild : Csla.BusinessBase<ChungTu_DeNghiThuChild>
    {
        #region Business Properties and Methods

        //declare members
        private long _maCTDNThu = 0;
        private long _maCT = 0;
        private long _maDNThu = 0;
        private decimal _soTien = 0;
      

      
        [System.ComponentModel.DataObjectField(true, true)]
        public long MaCTDNThu
        {
            get
            {
                CanReadProperty("MaCTDNThu", true);
                return _maCTDNThu;
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

        public long MaDNThu
        {
            get
            {
                CanReadProperty("MaDNThu", true);
                return _maDNThu;
            }
            set
            {
                CanWriteProperty("MaDNThu", true);
                if (!_maDNThu.Equals(value))
                {
                    _maDNThu = value;
                    PropertyHasChanged("MaDNThu");
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
            return _maCTDNThu;
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
        internal static ChungTu_DeNghiThuChild NewChungTu_DeNghiThuChild()
        {
            return new ChungTu_DeNghiThuChild();
        }
        public static ChungTu_DeNghiThuChild NewChungTu_DeNghiThuChild(long MaDNThu,decimal soTien)
        {
            return new ChungTu_DeNghiThuChild(MaDNThu,soTien);
        }
        internal static ChungTu_DeNghiThuChild GetChungTu_DeNghiThuChild(SafeDataReader dr)
        {
            return new ChungTu_DeNghiThuChild(dr);
        }

        private ChungTu_DeNghiThuChild()
        {

            ValidationRules.CheckRules();
            MarkAsChild();
        }
        private ChungTu_DeNghiThuChild(long MaDNThu,decimal soTien)
        {
            this.MaDNThu = MaDNThu;
            this.SoTien = soTien;

            MarkAsChild();
        }
        private ChungTu_DeNghiThuChild(SafeDataReader dr)
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
            _maCTDNThu = dr.GetInt64("MaCTDNThu");
            _maCT = dr.GetInt64("MaCT");
            _maDNThu = dr.GetInt64("MaDNThu");
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
                cm.CommandText = "sp_InserttblChungTu_DeNghiThu";

                AddInsertParameters(cm, parent);

                cm.ExecuteNonQuery();

                _maCTDNThu = (long)cm.Parameters["@MaCTDNThu"].Value;
            }//using
        }

        private void AddInsertParameters(SqlCommand cm, ChungTu parent)
        {
            _maCT = parent.MaChungTu;
            //TODO: if parent use identity key, fix fk member with value from parent
            cm.Parameters.AddWithValue("@MaCT", _maCT);
            cm.Parameters.AddWithValue("@MaDNThu", _maDNThu);
            cm.Parameters.AddWithValue("@SoTien", _soTien);
            cm.Parameters.AddWithValue("@MaCTDNThu", _maCTDNThu);
            cm.Parameters["@MaCTDNThu"].Direction = ParameterDirection.Output;
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
                cm.CommandText = "sp_UpdatetblChungTu_DeNghiThu";

                AddUpdateParameters(cm, parent);

                cm.ExecuteNonQuery();

            }//using
        }

        private void AddUpdateParameters(SqlCommand cm, ChungTu parent)
        {
           
            cm.Parameters.AddWithValue("@MaCTDNThu", _maCTDNThu);
            cm.Parameters.AddWithValue("@MaCT", _maCT);
            cm.Parameters.AddWithValue("@MaDNThu", _maDNThu);
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
                cm.CommandText = "sp_DeletetblChungTu_DeNghiThu";

                cm.Parameters.AddWithValue("@MaCTDNThu", this._maCTDNThu);

                cm.ExecuteNonQuery();
            }//using
        }
        #endregion //Data Access - Delete
        #endregion //Data Access
    }
}
