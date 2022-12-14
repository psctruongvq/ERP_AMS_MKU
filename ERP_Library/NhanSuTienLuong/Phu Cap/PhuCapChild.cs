
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{
    [Serializable()]
    public class PhuCapChild : Csla.BusinessBase<PhuCapChild>
    {
        #region Business Properties and Methods

        //declare members
        private int _maPhuCap = 0;
        private string _maQLPhuCap = string.Empty;
        private string _tenPhuCap = string.Empty;
        private int _maLoaiPhuCap = 0;
        private string _dieuKien = string.Empty;
        private string _congThuc = string.Empty;
        private string _ghiChu = string.Empty;
        private bool _TinhThueTNCN = false;
        private string _tenLoaiPhuCap = "";//sử dụng cho tính phụ cấp để insert vào table bangluong_phucap

        //declare child member(s)
        private DieuKienPhuCapList _congThucDieuKien = DieuKienPhuCapList.NewDieuKienPhuCapList();

        [System.ComponentModel.DataObjectField(true, true)]
        public int MaPhuCap
        {
            get
            {
                CanReadProperty("MaPhuCap", true);
                return _maPhuCap;

            }
        }

        public string TenLoaiPhuCap
        {
            get
            {
                return _tenLoaiPhuCap;
            }
        }
        
        public string MaQLPhuCap
        {
            get
            {
                CanReadProperty("MaQLPhuCap", true);
                return _maQLPhuCap;
            }
            set
            {
                CanWriteProperty("MaQLPhuCap", true);
                if (value == null) value = string.Empty;
                if (!_maQLPhuCap.Equals(value))
                {
                    _maQLPhuCap = value;
                    PropertyHasChanged("MaQLPhuCap");
                }
            }
        }

        public string TenPhuCap
        {
            get
            {
                CanReadProperty("TenPhuCap", true);
                return _tenPhuCap;
            }
            set
            {
                CanWriteProperty("TenPhuCap", true);
                if (value == null) value = string.Empty;
                if (!_tenPhuCap.Equals(value))
                {
                    _tenPhuCap = value;
                    PropertyHasChanged("TenPhuCap");
                }
            }
        }

        public int MaLoaiPhuCap
        {
            get
            {
                CanReadProperty("MaLoaiPhuCap", true);
                return _maLoaiPhuCap;
            }
            set
            {
                CanWriteProperty("MaLoaiPhuCap", true);
                if (!_maLoaiPhuCap.Equals(value))
                {
                    _maLoaiPhuCap = value;
                    PropertyHasChanged("MaLoaiPhuCap");
                }
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

        public string CongThuc
        {
            get
            {
                CanReadProperty("CongThuc", true);
                return _congThuc;
            }
            set
            {
                CanWriteProperty("CongThuc", true);
                if (value == null) value = string.Empty;
                if (!_congThuc.Equals(value))
                {
                    _congThuc = value;
                    PropertyHasChanged("CongThuc");
                }
            }
        }

        public string GhiChu
        {
            get
            {
                CanReadProperty("GhiChu", true);
                return _ghiChu;
            }
            set
            {
                CanWriteProperty("GhiChu", true);
                if (value == null) value = string.Empty;
                if (!_ghiChu.Equals(value))
                {
                    _ghiChu = value;
                    PropertyHasChanged("GhiChu");
                }
            }
        }

        public bool TinhThueTNCN
        {
            get
            {
                CanReadProperty("TinhThueTNCN", true);
                return _TinhThueTNCN;
            }
            set
            {
                CanWriteProperty("TinhThueTNCN", true);
                if (!_TinhThueTNCN.Equals(value))
                {
                    _TinhThueTNCN = value;
                    PropertyHasChanged("TinhThueTNCN");
                }
            }
        }

        public DieuKienPhuCapList CongThucDieuKien
        {
            get
            {
                CanReadProperty("CongThucDieuKien", true);
                return _congThucDieuKien;
            }
        }

        public override bool IsValid
        {
            get { return base.IsValid && _congThucDieuKien.IsValid; }
        }

        public override bool IsDirty
        {
            get { return base.IsDirty || _congThucDieuKien.IsDirty; }
        }

        protected override object GetIdValue()
        {
            return _maPhuCap;
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
            // MaQLPhuCap
            //
            //alidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("MaQLPhuCap", 50));
            //
            // TenPhuCap
            //
            ValidationRules.AddRule(CommonRulesEx.ValueRequire, new CommonRulesEx.RequireArgs("TenPhuCap", "Chưa nhập tên phụ cấp"));
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("TenPhuCap", 4000));
            //
            // CongThuc
            //
            ValidationRules.AddRule(CommonRulesEx.ValueRequire, new CommonRulesEx.RequireArgs("CongThuc", "Chưa nhập công thức tính số tiền phụ cấp"));
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("CongThuc", 4000));
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
            //TODO: Define authorization rules in PhuCapChild
            //AuthorizationRules.AllowRead("CongThucDieuKien", "PhuCapChildReadGroup");
            //AuthorizationRules.AllowRead("MaPhuCap", "PhuCapChildReadGroup");
            //AuthorizationRules.AllowRead("MaQLPhuCap", "PhuCapChildReadGroup");
            //AuthorizationRules.AllowRead("TenPhuCap", "PhuCapChildReadGroup");
            //AuthorizationRules.AllowRead("MaLoaiPhuCap", "PhuCapChildReadGroup");
            //AuthorizationRules.AllowRead("DieuKien", "PhuCapChildReadGroup");
            //AuthorizationRules.AllowRead("CongThuc", "PhuCapChildReadGroup");
            //AuthorizationRules.AllowRead("GhiChu", "PhuCapChildReadGroup");

            //AuthorizationRules.AllowWrite("MaQLPhuCap", "PhuCapChildWriteGroup");
            //AuthorizationRules.AllowWrite("TenPhuCap", "PhuCapChildWriteGroup");
            //AuthorizationRules.AllowWrite("MaLoaiPhuCap", "PhuCapChildWriteGroup");
            //AuthorizationRules.AllowWrite("DieuKien", "PhuCapChildWriteGroup");
            //AuthorizationRules.AllowWrite("CongThuc", "PhuCapChildWriteGroup");
            //AuthorizationRules.AllowWrite("GhiChu", "PhuCapChildWriteGroup");
        }

        #endregion //Authorization Rules

        #region Factory Methods
        internal static PhuCapChild NewPhuCapChild()
        {
            return new PhuCapChild();
        }

        internal static PhuCapChild GetPhuCapChild(SafeDataReader dr)
        {
            return new PhuCapChild(dr);
        }

        public PhuCapChild()
        {
            _congThucDieuKien._parent = this;
            ValidationRules.CheckRules();
            MarkAsChild();
        }

        private PhuCapChild(SafeDataReader dr)
        {
            MarkAsChild();
            Fetch(dr);
            _congThucDieuKien._parent = this;
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
            _maPhuCap = dr.GetInt32("MaPhuCap");
            _maQLPhuCap = dr.GetString("MaQLPhuCap");
            _tenPhuCap = dr.GetString("TenPhuCap");
            _maLoaiPhuCap = dr.GetInt32("MaLoaiPhuCap");
            _dieuKien = dr.GetString("DieuKien");
            _congThuc = dr.GetString("CongThuc");
            _ghiChu = dr.GetString("GhiChu");
            _TinhThueTNCN = dr.GetBoolean("TinhThueTNCN");
            _tenLoaiPhuCap = dr.GetString("TenLoaiPhuCap");
        }

        private void FetchChildren(SafeDataReader dr)
        {
            //dr.NextResult();
            //_congThucDieuKien = DieuKienPhuCapList.GetDieuKienPhuCapList(dr);
            _congThucDieuKien = DieuKienPhuCapList.GetDieuKienPhuCapByMaPhuCap(_maPhuCap);
        }
        #endregion //Data Access - Fetch

        #region Data Access - Insert
        internal void Insert(SqlTransaction tr)
        {
            if (!IsDirty) return;
            ExecuteInsert(tr);
            MarkOld();

            //update child object(s)
            UpdateChildren(tr);
        }

        private void ExecuteInsert(SqlTransaction tr)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_Insert_PhuCapChild";

                AddInsertParameters(cm);

                cm.ExecuteNonQuery();

                _maPhuCap = (int)cm.Parameters["@MaPhuCap"].Value;
            }//using
        }

        private void AddInsertParameters(SqlCommand cm)
        {
            if (_maQLPhuCap.Length > 0)
                cm.Parameters.AddWithValue("@MaQLPhuCap", _maQLPhuCap);
            else
                cm.Parameters.AddWithValue("@MaQLPhuCap", DBNull.Value);
            cm.Parameters.AddWithValue("@TenPhuCap", _tenPhuCap);
            cm.Parameters.AddWithValue("@MaLoaiPhuCap", _maLoaiPhuCap);
            cm.Parameters.AddWithValue("@DieuKien", _dieuKien);
            cm.Parameters.AddWithValue("@CongThuc", _congThuc);
            cm.Parameters.AddWithValue("@TinhThueTNCN", _TinhThueTNCN);
            if (_ghiChu.Length > 0)
                cm.Parameters.AddWithValue("@GhiChu", _ghiChu);
            else
                cm.Parameters.AddWithValue("@GhiChu", DBNull.Value);
            cm.Parameters.AddWithValue("@MaPhuCap", _maPhuCap);
            cm.Parameters["@MaPhuCap"].Direction = ParameterDirection.Output;
        }
        #endregion //Data Access - Insert

        #region Data Access - Update
        internal void Update(SqlTransaction tr)
        {
            if (!IsDirty) return;

            if (base.IsDirty)
            {
                ExecuteUpdate(tr);
                MarkOld();
            }

            //update child object(s)
            UpdateChildren(tr);
        }

        private void ExecuteUpdate(SqlTransaction tr)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_Update_PhuCapChild";

                AddUpdateParameters(cm);

                cm.ExecuteNonQuery();

            }//using
        }

        private void AddUpdateParameters(SqlCommand cm)
        {
            cm.Parameters.AddWithValue("@MaPhuCap", _maPhuCap);
            if (_maQLPhuCap.Length > 0)
                cm.Parameters.AddWithValue("@MaQLPhuCap", _maQLPhuCap);
            else
                cm.Parameters.AddWithValue("@MaQLPhuCap", DBNull.Value);
            cm.Parameters.AddWithValue("@TenPhuCap", _tenPhuCap);
            cm.Parameters.AddWithValue("@MaLoaiPhuCap", _maLoaiPhuCap);
            cm.Parameters.AddWithValue("@DieuKien", _dieuKien);
            cm.Parameters.AddWithValue("@CongThuc", _congThuc);
            if (_ghiChu.Length > 0)
                cm.Parameters.AddWithValue("@GhiChu", _ghiChu);
            else
                cm.Parameters.AddWithValue("@GhiChu", DBNull.Value);
            cm.Parameters.AddWithValue("@TinhThueTNCN", _TinhThueTNCN);
        }

        private void UpdateChildren(SqlTransaction tr)
        {
            _congThucDieuKien.Update(tr, this);
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
                cm.CommandText = "spd_Delete_PhuCapChild";

                cm.Parameters.AddWithValue("@MaPhuCap", this._maPhuCap);

                cm.ExecuteNonQuery();
            }//using
        }
        #endregion //Data Access - Delete
        #endregion //Data Access
    }
}
