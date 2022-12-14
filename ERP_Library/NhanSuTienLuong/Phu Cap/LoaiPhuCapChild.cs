using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{
    [Serializable()]
    public class LoaiPhuCapChild : Csla.BusinessBase<LoaiPhuCapChild>
    {
        #region Business Properties and Methods

        //declare members
        private int _maLoaiPhuCap = 0;
        private string _maQLLoaiPhuCap = string.Empty;
        private string _tenLoaiPhuCap = string.Empty;
        private bool _khongDuyet = false;
        private int _maNhom = 0;
        private int _ptThuNhapTinhThue = 100;
        private byte _phanLoai = 0;

        [System.ComponentModel.DataObjectField(true, true)]
        public int MaNhom
        {
            get
            {
                CanReadProperty("MaNhom", true);
                return _maNhom;
            }
            set
            {
                if (!_maNhom.Equals(value))
                {
                    _maNhom = value;

                    PropertyHasChanged();
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
        }

        public string MaQLLoaiPhuCap
        {
            get
            {
                CanReadProperty("MaQLLoaiPhuCap", true);
                return _maQLLoaiPhuCap;

            }
            set
            {
                CanWriteProperty("MaQLLoaiPhuCap", true);
                if (value == null) value = string.Empty;
                if (!_maQLLoaiPhuCap.Equals(value))
                {
                    _maQLLoaiPhuCap = value;
                    PropertyHasChanged("MaQLLoaiPhuCap");
                }
            }
        }

        public string TenLoaiPhuCap
        {
            get
            {
                CanReadProperty("TenLoaiPhuCap", true);
                return _tenLoaiPhuCap;
            }
            set
            {
                CanWriteProperty("TenLoaiPhuCap", true);
                if (value == null) value = string.Empty;
                if (!_tenLoaiPhuCap.Equals(value))
                {
                    _tenLoaiPhuCap = value;
                    PropertyHasChanged("TenLoaiPhuCap");
                }
            }
        }

        public bool KhongDuyet
        {
            get
            {
                return _khongDuyet;
            }
            set
            {
                if (!_khongDuyet.Equals(value))
                {
                    _khongDuyet = value;
                    PropertyHasChanged();
                }
            }
        }

        public int PTThuNhapTinhThue
        {
            get
            {
                return _ptThuNhapTinhThue;
            }
            set
            {
                if (!_ptThuNhapTinhThue.Equals(value))
                {
                    _ptThuNhapTinhThue = value;
                    PropertyHasChanged();
                }
            }
        }

        public byte PhanLoai
        {
            get
            {
                CanReadProperty("PhanLoai", true);
                return _phanLoai;
            }
            set
            {
                if (!_phanLoai.Equals(value))
                {
                    _phanLoai = value;

                    PropertyHasChanged();
                }
            }

        }

        protected override object GetIdValue()
        {
            return _maLoaiPhuCap;
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
            // MaQLLoaiPhuCap
            //
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("MaQLLoaiPhuCap", 50));
            //
            // TenLoaiPhuCap
            //
            ValidationRules.AddRule(CommonRulesEx.ValueRequire, new CommonRulesEx.RequireArgs("TenLoaiPhuCap","Chưa nhập tên loại phụ cấp"));
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("TenLoaiPhuCap", 100));
          //  ValidationRules.AddRule(CommonRulesEx.ValueRequire, new CommonRulesEx.RequireArgs("TenNhom", "Tên nhóm tính phụ cấp hoặc thưởng chưa nhập"));
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
            //TODO: Define authorization rules in LoaiPhuCapChild
            //AuthorizationRules.AllowRead("MaLoaiPhuCap", "LoaiPhuCapChildReadGroup");
            //AuthorizationRules.AllowRead("MaQLLoaiPhuCap", "LoaiPhuCapChildReadGroup");
            //AuthorizationRules.AllowRead("TenLoaiPhuCap", "LoaiPhuCapChildReadGroup");

            //AuthorizationRules.AllowWrite("MaQLLoaiPhuCap", "LoaiPhuCapChildWriteGroup");
            //AuthorizationRules.AllowWrite("TenLoaiPhuCap", "LoaiPhuCapChildWriteGroup");
        }

        #endregion //Authorization Rules

        #region Factory Methods
        internal static LoaiPhuCapChild NewLoaiPhuCapChild()
        {
            return new LoaiPhuCapChild();
        }
        public static LoaiPhuCapChild NewLoaiPhuCapChild(string tenLoai)
        {
            LoaiPhuCapChild item = new LoaiPhuCapChild();
            item._tenLoaiPhuCap = tenLoai;
            return item;
        }
        internal static LoaiPhuCapChild GetLoaiPhuCapChild(SafeDataReader dr)
        {
            return new LoaiPhuCapChild(dr);
        }

        public LoaiPhuCapChild()
        {
            ValidationRules.CheckRules();
            MarkAsChild();
        }

        private LoaiPhuCapChild(SafeDataReader dr)
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
            _maLoaiPhuCap = dr.GetInt32("MaLoaiPhuCap");
            _maQLLoaiPhuCap = dr.GetString("MaQLLoaiPhuCap");
            _tenLoaiPhuCap = dr.GetString("TenLoaiPhuCap");
            _khongDuyet = dr.GetBoolean("KhongDuyet");
            _maNhom = dr.GetInt32("MaNhom");
            _ptThuNhapTinhThue = dr.GetInt32("PTThuNhapTinhThue");
            _phanLoai = dr.GetByte("PhanLoai");
        }

        private void FetchChildren(SafeDataReader dr)
        {
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
                cm.CommandText = "spd_Insert_LoaiPhuCapChild";

                AddInsertParameters(cm);

                cm.ExecuteNonQuery();

                _maLoaiPhuCap = (int)cm.Parameters["@MaLoaiPhuCap"].Value;
            }//using
        }

        private void AddInsertParameters(SqlCommand cm)
        {
            if (_maQLLoaiPhuCap.Length > 0)
                cm.Parameters.AddWithValue("@MaQLLoaiPhuCap", _maQLLoaiPhuCap);
            else
                cm.Parameters.AddWithValue("@MaQLLoaiPhuCap", DBNull.Value);
            cm.Parameters.AddWithValue("@TenLoaiPhuCap", _tenLoaiPhuCap);
            cm.Parameters.AddWithValue("@MaLoaiPhuCap", _maLoaiPhuCap);

            if (_maNhom == 0)
                cm.Parameters.AddWithValue("@MaNhom", DBNull.Value);
            else
                cm.Parameters.AddWithValue("@MaNhom", _maNhom);
            cm.Parameters["@MaLoaiPhuCap"].Direction = ParameterDirection.Output;
            cm.Parameters.AddWithValue("@KhongDuyet", _khongDuyet);
            cm.Parameters.AddWithValue("@PTThuNhapTinhThue", _ptThuNhapTinhThue);
            if (_phanLoai == 0)
                cm.Parameters.AddWithValue("@PhanLoai", DBNull.Value);
            else
                cm.Parameters.AddWithValue("@PhanLoai", _phanLoai);
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
                cm.CommandText = "spd_Update_LoaiPhuCapChild";

                AddUpdateParameters(cm);

                cm.ExecuteNonQuery();

            }//using
        }

        private void AddUpdateParameters(SqlCommand cm)
        {
            cm.Parameters.AddWithValue("@MaLoaiPhuCap", _maLoaiPhuCap);
            if (_maQLLoaiPhuCap.Length > 0)
                cm.Parameters.AddWithValue("@MaQLLoaiPhuCap", _maQLLoaiPhuCap);
            else
                cm.Parameters.AddWithValue("@MaQLLoaiPhuCap", DBNull.Value);
            cm.Parameters.AddWithValue("@TenLoaiPhuCap", _tenLoaiPhuCap);

            if (_maNhom == 0)
                cm.Parameters.AddWithValue("@MaNhom", DBNull.Value);
            else
                cm.Parameters.AddWithValue("@MaNhom", _maNhom);
            cm.Parameters.AddWithValue("@KhongDuyet", _khongDuyet);
            cm.Parameters.AddWithValue("@PTThuNhapTinhThue", _ptThuNhapTinhThue);
            if (_phanLoai == 0)
                cm.Parameters.AddWithValue("@PhanLoai", DBNull.Value);
            else
                cm.Parameters.AddWithValue("@PhanLoai", _phanLoai);
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
                cm.CommandText = "spd_Delete_LoaiPhuCapChild";

                cm.Parameters.AddWithValue("@MaLoaiPhuCap", this._maLoaiPhuCap);

                cm.ExecuteNonQuery();
            }//using
        }
        #endregion //Data Access - Delete
        #endregion //Data Access

        public int CopyPhuCap(string TenNew)
        {
            int tmp = 0;
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                SqlCommand cm = cn.CreateCommand();
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_CopyPhuCap";
                cm.Parameters.AddWithValue("@MaLoaiPhuCap", _maLoaiPhuCap);
                cm.Parameters.AddWithValue("@TenPhuCap", TenNew);
                cm.Parameters.AddWithValue("@NewID", 0);
                cm.Parameters["@NewID"].Direction = ParameterDirection.Output;

                cm.ExecuteNonQuery();
                tmp = Convert.ToInt32(cm.Parameters["@NewID"].Value);
                cn.Close();
            }
            return tmp;
        }
    }
}
