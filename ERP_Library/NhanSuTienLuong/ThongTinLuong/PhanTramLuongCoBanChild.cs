
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{
    [Serializable()]
    public class PhanTramLuongCoBanChild : Csla.BusinessBase<PhanTramLuongCoBanChild>
    {
        #region Business Properties and Methods

        //declare members
        private int _maKyTinhLuong = 0;
        private Nullable<int> _maBoPhan;
        private Nullable<long> _maNhanVien;
        private decimal _phanTram = 0;
        private string _lyDo = string.Empty;
        private decimal _phanTramV2 = 0;
        private int _maPhanTram = 0;

        private string _tenNhanVien;

        [System.ComponentModel.DataObjectField(true, false)]
        public int MaPhanTram
        {
            get
            {
                return _maPhanTram;
            }
        }
        public string  TenNhanVien
        {
            get
            {
                return _tenNhanVien;
            }
            set { _tenNhanVien = value; }
        }

        public int MaKyTinhLuong
        {
            get
            {
                CanReadProperty("MaKyTinhLuong", true);
                return _maKyTinhLuong;
            }
            set
            {
                CanWriteProperty("MaKyTinhLuong", true);
                if (!_maKyTinhLuong.Equals(value))
                {
                    _maKyTinhLuong = value;
                    PropertyHasChanged("MaKyTinhLuong");
                }
            }
        }

        public Nullable<int> MaBoPhan
        {
            get
            {
                CanReadProperty("MaBoPhan", true);
                return _maBoPhan;
            }
            set
            {
                CanWriteProperty("MaBoPhan", true);
                if (!_maBoPhan.Equals(value))
                {
                    _maBoPhan = value;
                    PropertyHasChanged("MaBoPhan");
                }
            }
        }

        [System.ComponentModel.DataObjectField(true, false)]
        public Nullable<long> MaNhanVien
        {
            get
            {
                CanReadProperty("MaNhanVien", true);
                return _maNhanVien;
            }
            set
            {
                CanWriteProperty("MaNhanVien", true);
                if (!_maNhanVien.Equals(value))
                {
                    _maNhanVien = value;
                    PropertyHasChanged("MaNhanVien");
                }
            }
        }

        public decimal PhanTram
        {
            get
            {
                CanReadProperty("PhanTram", true);
                return _phanTram;
            }
            set
            {
                CanWriteProperty("PhanTram", true);
                if (!_phanTram.Equals(value))
                {
                    _phanTram = value;
                    PropertyHasChanged("PhanTram");
                }
            }
        }

        public decimal PhanTramV2
        {
            get
            {
                return _phanTramV2;
            }
            set
            {
                if (!_phanTramV2.Equals(value))
                {
                    _phanTramV2 = value;
                    PropertyHasChanged();
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
            return _maPhanTram;
        }

        #endregion //Business Properties and Methods

        #region Validation Rules
        private void AddCustomRules()
        {
            //add custom/non-generated rules here...
        }

        private void AddCommonRules()
        {
            //ValidationRules.AddRule(CommonRulesEx.ValueRequire, new CommonRulesEx.RequireArgs("MaKyTinhLuong", "Chưa nhập kỳ tính lương"));
            //ValidationRules.AddRule(CommonRulesEx.ValueRequire, new CommonRulesEx.RequireArgs("MaBoPhan", "Chưa nhập bộ phận"));
            //ValidationRules.AddRule(CommonRulesEx.ValueRequire, new CommonRulesEx.RequireArgs("MaNhanVien", "Chưa nhập mã nhân viên"));
            //ValidationRules.AddRule(CommonRulesEx.ValueRequire, new CommonRulesEx.RequireArgs("PhanTram", "Chưa nhập % lương cơ bản được nhận"));
            //ValidationRules.AddRule(CommonRulesEx.ValueRequire, new CommonRulesEx.RequireArgs("LyDo", "Chưa nhập lý do điều chỉnh lương"));
            ////
            //// LyDo
            ////
            //ValidationRules.AddRule(CommonRules.StringRequired, "LyDo");
            //ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("LyDo", 100));
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
            //TODO: Define authorization rules in PhanTramLuongCoBanChild
            //AuthorizationRules.AllowRead("MaKyTinhLuong", "PhanTramLuongCoBanChildReadGroup");
            //AuthorizationRules.AllowRead("MaBoPhan", "PhanTramLuongCoBanChildReadGroup");
            //AuthorizationRules.AllowRead("MaNhanVien", "PhanTramLuongCoBanChildReadGroup");
            //AuthorizationRules.AllowRead("PhanTram", "PhanTramLuongCoBanChildReadGroup");
            //AuthorizationRules.AllowRead("LyDo", "PhanTramLuongCoBanChildReadGroup");

            //AuthorizationRules.AllowWrite("MaBoPhan", "PhanTramLuongCoBanChildWriteGroup");
            //AuthorizationRules.AllowWrite("PhanTram", "PhanTramLuongCoBanChildWriteGroup");
            //AuthorizationRules.AllowWrite("LyDo", "PhanTramLuongCoBanChildWriteGroup");
        }

        #endregion //Authorization Rules

        #region Factory Methods
        internal static PhanTramLuongCoBanChild NewPhanTramLuongCoBanChild()
        {
            return new PhanTramLuongCoBanChild();
        }

        internal static PhanTramLuongCoBanChild GetPhanTramLuongCoBanChild(SafeDataReader dr)
        {
            return new PhanTramLuongCoBanChild(dr);
        }

        public PhanTramLuongCoBanChild()
        {
            MarkAsChild();
        }

        private PhanTramLuongCoBanChild(SafeDataReader dr)
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
            _maKyTinhLuong = dr.GetInt32("MaKyTinhLuong");
            _maBoPhan = dr.GetInt32("MaBoPhan");
            _maNhanVien = dr.GetInt64("MaNhanVien");
            _phanTram = dr.GetDecimal("PhanTram");
            _lyDo = dr.GetString("LyDo");
            _phanTramV2 = dr.GetDecimal("PhanTramV2");
            _maPhanTram = dr.GetInt32("MaPhanTram");
            _tenNhanVien = dr.GetString("TenNhanVien");
        }

        private void FetchChildren(SafeDataReader dr)
        {
        }
        #endregion //Data Access - Fetch

        #region Data Access - Insert
        internal void Insert(SqlTransaction tr, int MaKyTinhLuong)
        {
            if (!IsDirty) return;
            _maKyTinhLuong = MaKyTinhLuong;
            ValidationRules.CheckRules();
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
                cm.CommandText = "spd_Insert_PhanTramLuongCoBanChild";

                AddInsertParameters(cm);

                cm.ExecuteNonQuery();
                _maPhanTram = Convert.ToInt32(cm.Parameters["@MaPhanTram"].Value);

            }//using
        }

        private void AddInsertParameters(SqlCommand cm)
        {
            cm.Parameters.AddWithValue("@MaKyTinhLuong", _maKyTinhLuong);
            cm.Parameters.AddWithValue("@MaBoPhan", _maBoPhan);
            cm.Parameters.AddWithValue("@MaNhanVien", _maNhanVien);
            cm.Parameters.AddWithValue("@PhanTram", _phanTram);
            cm.Parameters.AddWithValue("@PhanTramV2", _phanTramV2);
            cm.Parameters.AddWithValue("@LyDo", _lyDo);
            cm.Parameters.AddWithValue("@MaPhanTram", _maPhanTram);
            cm.Parameters["@MaPhanTram"].Direction = ParameterDirection.InputOutput;
        }
        #endregion //Data Access - Insert

        #region Data Access - Update
        internal void Update(SqlTransaction tr)
        {
            if (!IsDirty) return;
            ValidationRules.CheckRules();
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
                cm.CommandText = "spd_Update_PhanTramLuongCoBanChild";

                AddUpdateParameters(cm);

                cm.ExecuteNonQuery();

            }//using
        }

        private void AddUpdateParameters(SqlCommand cm)
        {
            cm.Parameters.AddWithValue("@MaKyTinhLuong", _maKyTinhLuong);
            cm.Parameters.AddWithValue("@MaBoPhan", _maBoPhan);
            cm.Parameters.AddWithValue("@MaNhanVien", _maNhanVien);
            cm.Parameters.AddWithValue("@PhanTram", _phanTram);
            cm.Parameters.AddWithValue("@PhanTramV2", _phanTramV2);
            cm.Parameters.AddWithValue("@LyDo", _lyDo);
            cm.Parameters.AddWithValue("@MaPhanTram", _maPhanTram);
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
                cm.CommandText = "spd_Delete_PhanTramLuongCoBanChild";

                cm.Parameters.AddWithValue("@MaPhanTram", _maPhanTram);

                cm.ExecuteNonQuery();
            }//using
        }
        #endregion //Data Access - Delete
        #endregion //Data Access
    }
}
