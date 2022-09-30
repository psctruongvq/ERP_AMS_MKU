using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{
    [Serializable()]
    public class PhieuThutuPhieuChiEditableChild : Csla.BusinessBase<PhieuThutuPhieuChiEditableChild>
    {
        #region Business Properties and Methods

        //declare members
        private long _id = 0;
        private long _maPhieuThu = 0;
        private long _maPhieuChi = 0;
        private string _soChungTuPhieuChi = string.Empty;
        private decimal _soTien = 0;

        [System.ComponentModel.DataObjectField(true, true)]
        public long Id
        {
            get
            {
                CanReadProperty("Id", true);
                return _id;
            }
        }

        public long MaPhieuThu
        {
            get
            {
                CanReadProperty("MaPhieuThu", true);
                return _maPhieuThu;
            }
            set
            {
                CanWriteProperty("MaPhieuThu", true);
                if (!_maPhieuThu.Equals(value))
                {
                    _maPhieuThu = value;
                    PropertyHasChanged("MaPhieuThu");
                }
            }
        }

        public long MaPhieuChi
        {
            get
            {
                CanReadProperty("MaPhieuChi", true);
                return _maPhieuChi;
            }
            set
            {
                CanWriteProperty("MaPhieuChi", true);
                if (!_maPhieuChi.Equals(value))
                {
                    _maPhieuChi = value;
                    PropertyHasChanged("MaPhieuChi");
                }
            }
        }

        public string SoChungTuPhieuChi
        {
            get
            {
                CanReadProperty("SoChungTuPhieuChi", true);
                return _soChungTuPhieuChi;
            }
            set
            {
                CanWriteProperty("SoChungTuPhieuChi", true);
                if (value == null) value = string.Empty;
                if (!_soChungTuPhieuChi.Equals(value))
                {
                    _soChungTuPhieuChi = value;
                    PropertyHasChanged("SoChungTuPhieuChi");
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
            return _id;
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
            // SoChungTuPhieuChi
            //
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("SoChungTuPhieuChi", 50));
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
            //TODO: Define authorization rules in PhieuThutuPhieuChiEditableChild
            //AuthorizationRules.AllowRead("Id", "PhieuThutuPhieuChiEditableChildReadGroup");
            //AuthorizationRules.AllowRead("MaPhieuThu", "PhieuThutuPhieuChiEditableChildReadGroup");
            //AuthorizationRules.AllowRead("MaPhieuChi", "PhieuThutuPhieuChiEditableChildReadGroup");
            //AuthorizationRules.AllowRead("SoChungTuPhieuChi", "PhieuThutuPhieuChiEditableChildReadGroup");

            //AuthorizationRules.AllowWrite("MaPhieuThu", "PhieuThutuPhieuChiEditableChildWriteGroup");
            //AuthorizationRules.AllowWrite("MaPhieuChi", "PhieuThutuPhieuChiEditableChildWriteGroup");
            //AuthorizationRules.AllowWrite("SoChungTuPhieuChi", "PhieuThutuPhieuChiEditableChildWriteGroup");
        }

        #endregion //Authorization Rules

        #region Factory Methods
        internal static PhieuThutuPhieuChiEditableChild NewPhieuThutuPhieuChiEditableChild()
        {
            return new PhieuThutuPhieuChiEditableChild();
        }

        public static PhieuThutuPhieuChiEditableChild NewPhieuThutuPhieuChiEditableChild(long maPhieuChi, string soChungTuPhieuChi, decimal soTien)
        {
            return new PhieuThutuPhieuChiEditableChild(maPhieuChi, soChungTuPhieuChi, soTien);
        }

        internal static PhieuThutuPhieuChiEditableChild GetPhieuThutuPhieuChiEditableChild(SafeDataReader dr)
        {
            return new PhieuThutuPhieuChiEditableChild(dr);
        }

        private PhieuThutuPhieuChiEditableChild()
        {

            ValidationRules.CheckRules();
            MarkAsChild();
        }

        private PhieuThutuPhieuChiEditableChild(long maPhieuChi, string soChungTuPhieuChi, decimal soTien)
        {
            _maPhieuChi = maPhieuChi;
            _soChungTuPhieuChi = soChungTuPhieuChi;
            _soTien = soTien;
            ValidationRules.CheckRules();
            MarkAsChild();
        }

        private PhieuThutuPhieuChiEditableChild(SafeDataReader dr)
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
            _id = dr.GetInt64("id");
            _maPhieuThu = dr.GetInt64("MaPhieuThu");
            _maPhieuChi = dr.GetInt64("MaPhieuChi");
            _soChungTuPhieuChi = dr.GetString("SoChungTuPhieuChi");
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
                cm.CommandText = "spd_InserttblPhieuThutuPhieuChi";

                AddInsertParameters(cm, parent);

                cm.ExecuteNonQuery();

                _id = (long)cm.Parameters["@id"].Value;

            }//using
        }

        private void AddInsertParameters(SqlCommand cm, ChungTu parent)
        {
            _maPhieuThu = parent.MaChungTu;//
            //TODO: if parent use identity key, fix fk member with value from parent
            if (_maPhieuThu != 0)
                cm.Parameters.AddWithValue("@MaPhieuThu", _maPhieuThu);
            else
                cm.Parameters.AddWithValue("@MaPhieuThu", DBNull.Value);
            if (_maPhieuChi != 0)
                cm.Parameters.AddWithValue("@MaPhieuChi", _maPhieuChi);
            else
                cm.Parameters.AddWithValue("@MaPhieuChi", DBNull.Value);
            if (_soChungTuPhieuChi.Length > 0)
                cm.Parameters.AddWithValue("@SoChungTuPhieuChi", _soChungTuPhieuChi);
            else
                cm.Parameters.AddWithValue("@SoChungTuPhieuChi", DBNull.Value);
            if (_soTien != 0)
                cm.Parameters.AddWithValue("@SoTien", _soTien);
            else
                cm.Parameters.AddWithValue("@SoTien", DBNull.Value);
            cm.Parameters.AddWithValue("@id", _id);
            cm.Parameters["@id"].Direction = ParameterDirection.Output;
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
                cm.CommandText = "spd_UpdatetblPhieuThutuPhieuChi";

                AddUpdateParameters(cm, parent);

                cm.ExecuteNonQuery();

            }//using

        }

        private void AddUpdateParameters(SqlCommand cm, ChungTu parent)
        {
            cm.Parameters.AddWithValue("@id", _id);
            _maPhieuThu = parent.MaChungTu;//
            if (_maPhieuThu != 0)
                cm.Parameters.AddWithValue("@MaPhieuThu", _maPhieuThu);
            else
                cm.Parameters.AddWithValue("@MaPhieuThu", DBNull.Value);
            if (_maPhieuChi != 0)
                cm.Parameters.AddWithValue("@MaPhieuChi", _maPhieuChi);
            else
                cm.Parameters.AddWithValue("@MaPhieuChi", DBNull.Value);
            if (_soChungTuPhieuChi.Length > 0)
                cm.Parameters.AddWithValue("@SoChungTuPhieuChi", _soChungTuPhieuChi);
            else
                cm.Parameters.AddWithValue("@SoChungTuPhieuChi", DBNull.Value);
            if (_soTien != 0)
                cm.Parameters.AddWithValue("@SoTien", _soTien);
            else
                cm.Parameters.AddWithValue("@SoTien", DBNull.Value);
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
                cm.CommandText = "spd_DeletetblPhieuThutuPhieuChi";

                cm.Parameters.AddWithValue("@id", this._id);

                cm.ExecuteNonQuery();

            }//using
        }
        #endregion //Data Access - Delete
        #endregion //Data Access
    }
}
