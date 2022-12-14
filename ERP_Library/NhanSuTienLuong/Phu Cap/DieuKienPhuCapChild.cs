
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{
    [Serializable()]
    public class DieuKienPhuCapChild : Csla.BusinessBase<DieuKienPhuCapChild>
    {
        #region Business Properties and Methods

        //declare members
        internal int _maDieuKien = 0;
        private string _dieuKien = string.Empty;
        private string _giaTri = string.Empty;
        private int _maPhuCap = 0;
        private string _CongThuc = "";

        [System.ComponentModel.DataObjectField(true, true)]
        public int MaDieuKien
        {
            get
            {
                CanReadProperty("MaDieuKien", true);
                return _maDieuKien;
            }
        }

        public string DieuKien
        {
            get
            {
                CanReadProperty("DieuKien", true);
                return _dieuKien;
            }
            set
            {
                CanWriteProperty("DieuKien", true);
                if (value == null) value = string.Empty;
                if (!_dieuKien.Equals(value))
                {
                    _dieuKien = value;
                    PropertyHasChanged("DieuKien");
                }
            }
        }

        public string GiaTri
        {
            get
            {
                CanReadProperty("GiaTri", true);
                return _giaTri;
            }
            set
            {
                CanWriteProperty("GiaTri", true);
                if (value == null) value = string.Empty;
                if (!_giaTri.Equals(value))
                {
                    _giaTri = value;
                    PropertyHasChanged("GiaTri");
                }
            }
        }

        public string CongThuc
        {
            get
            {
                CanReadProperty("CongThuc", true);
                return _CongThuc;
            }
            set
            {
                CanWriteProperty("CongThuc", true);
                if (!_CongThuc.Equals(value))
                {
                    _CongThuc = value;
                    PropertyHasChanged("CongThuc");
                }
            }
        }

        public int MaPhuCap
        {
            get
            {
                CanReadProperty("MaPhuCap", true);
                return _maPhuCap;
            }
            set
            {
                CanWriteProperty("MaPhuCap", true);
                if (!_maPhuCap.Equals(value))
                {
                    _maPhuCap = value;
                    PropertyHasChanged("MaPhuCap");
                }
            }
        }

        protected override object GetIdValue()
        {
            return _maDieuKien;
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
            // DieuKien
            //
            ValidationRules.AddRule(CommonRulesEx.ValueRequire, new CommonRulesEx.RequireArgs("DieuKien", "Chưa nhập điều kiện tính phụ cấp"));
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("DieuKien", 4000));
            //
            // GiaTri
            //
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("GiaTri", 4000));
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
            //TODO: Define authorization rules in DieuKienPhuCapChild
            //AuthorizationRules.AllowRead("MaDieuKien", "DieuKienPhuCapChildReadGroup");
            //AuthorizationRules.AllowRead("DieuKien", "DieuKienPhuCapChildReadGroup");
            //AuthorizationRules.AllowRead("GiaTri", "DieuKienPhuCapChildReadGroup");
            //AuthorizationRules.AllowRead("MaPhuCap", "DieuKienPhuCapChildReadGroup");

            //AuthorizationRules.AllowWrite("DieuKien", "DieuKienPhuCapChildWriteGroup");
            //AuthorizationRules.AllowWrite("GiaTri", "DieuKienPhuCapChildWriteGroup");
            //AuthorizationRules.AllowWrite("MaPhuCap", "DieuKienPhuCapChildWriteGroup");
        }

        #endregion //Authorization Rules

        #region Factory Methods
        internal static DieuKienPhuCapChild NewDieuKienPhuCapChild()
        {
            return new DieuKienPhuCapChild();
        }

        internal static DieuKienPhuCapChild GetDieuKienPhuCapChild(SafeDataReader dr)
        {
            return new DieuKienPhuCapChild(dr);
        }

        public DieuKienPhuCapChild()
        {
            ValidationRules.CheckRules();
            MarkAsChild();
        }

        private DieuKienPhuCapChild(SafeDataReader dr)
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

            //load child object(s)
            FetchChildren(dr);
        }

        private void FetchObject(SafeDataReader dr)
        {
            _maDieuKien = dr.GetInt32("MaDieuKien");
            _dieuKien = dr.GetString("DieuKien");
            _giaTri = dr.GetString("GiaTri");
            _CongThuc = dr.GetString("CongThuc");
            _maPhuCap = dr.GetInt32("MaPhuCap");
        }

        private void FetchChildren(SafeDataReader dr)
        {
        }
        #endregion //Data Access - Fetch

        #region Data Access - Insert
        internal void Insert(SqlTransaction tr, PhuCapChild parent)
        {
            if (!IsDirty) return;
            ExecuteInsert(tr, parent);
            MarkOld();

            //update child object(s)
            UpdateChildren(tr);
        }

        private void ExecuteInsert(SqlTransaction tr, PhuCapChild parent)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_Insert_DieuKienPhuCapChild";

                AddInsertParameters(cm, parent);

                cm.ExecuteNonQuery();

                _maDieuKien = (int)cm.Parameters["@MaDieuKien"].Value;
            }//using
        }

        private void AddInsertParameters(SqlCommand cm, PhuCapChild parent)
        {
            _maPhuCap = parent.MaPhuCap;
            cm.Parameters.AddWithValue("@DieuKien", _dieuKien);
            cm.Parameters.AddWithValue("@GiaTri", _giaTri);
            cm.Parameters.AddWithValue("@CongThuc", _CongThuc);
            cm.Parameters.AddWithValue("@MaPhuCap", _maPhuCap);
            cm.Parameters.AddWithValue("@MaDieuKien", _maDieuKien);
            cm.Parameters["@MaDieuKien"].Direction = ParameterDirection.Output;
        }
        #endregion //Data Access - Insert

        #region Data Access - Update
        internal void Update(SqlTransaction tr, PhuCapChild parent)
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

        private void ExecuteUpdate(SqlTransaction tr, PhuCapChild parent)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_Update_DieuKienPhuCapChild";

                AddUpdateParameters(cm, parent);

                cm.ExecuteNonQuery();

            }//using
        }

        private void AddUpdateParameters(SqlCommand cm, PhuCapChild parent)
        {
            cm.Parameters.AddWithValue("@MaDieuKien", _maDieuKien);
            cm.Parameters.AddWithValue("@DieuKien", _dieuKien);
            cm.Parameters.AddWithValue("@GiaTri", _giaTri);
            cm.Parameters.AddWithValue("@CongThuc", _CongThuc);
            cm.Parameters.AddWithValue("@MaPhuCap", _maPhuCap);
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
                cm.CommandText = "spd_Delete_DieuKienPhuCapChild";

                cm.Parameters.AddWithValue("@MaDieuKien", this._maDieuKien);

                cm.ExecuteNonQuery();
            }//using
        }
        #endregion //Data Access - Delete
        #endregion //Data Access
    }
}
