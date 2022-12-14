
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{
    [Serializable()]
    public class DaoTaoNgoai_ChiTietListChild : Csla.BusinessBase<DaoTaoNgoai_ChiTietListChild>
    {
        #region Business Properties and Methods

        //declare members
        internal int _maDTNgoaiChiTiet = 0;
        private int _maDTNgoai = 0;
        private string _hocVien = string.Empty;
        private string _ngaySinh = string.Empty;
        private bool _gioiTinh = false;
        private string _diaChi = string.Empty;
        private string _dienThoai = string.Empty;
        private Nullable<int> _queQuan = null;

        [System.ComponentModel.DataObjectField(true, true)]
        public int MaDTNgoaiChiTiet
        {
            get
            {
                CanReadProperty("MaDTNgoaiChiTiet", true);
                return _maDTNgoaiChiTiet;
            }
        }

        public int MaDTNgoai
        {
            get
            {
                CanReadProperty("MaDTNgoai", true);
                return _maDTNgoai;
            }
            set
            {
                CanWriteProperty("MaDTNgoai", true);
                if (!_maDTNgoai.Equals(value))
                {
                    _maDTNgoai = value;
                    PropertyHasChanged("MaDTNgoai");
                }
            }
        }

        public string HocVien
        {
            get
            {
                CanReadProperty("HocVien", true);
                return _hocVien;
            }
            set
            {
                CanWriteProperty("HocVien", true);
                if (value == null) value = string.Empty;
                if (!_hocVien.Equals(value))
                {
                    _hocVien = value;
                    PropertyHasChanged("HocVien");
                }
            }
        }

        public string NgaySinh
        {
            get
            {
                CanReadProperty("NgaySinh", true);
                return _ngaySinh;
            }
            set
            {
                CanWriteProperty("NgaySinh", true);
                if (value == null) value = string.Empty;
                if (!_ngaySinh.Equals(value))
                {
                    _ngaySinh = value;
                    PropertyHasChanged("NgaySinh");
                }
            }
        }

        public bool GioiTinh
        {
            get
            {
                CanReadProperty("GioiTinh", true);
                return _gioiTinh;
            }
            set
            {
                CanWriteProperty("GioiTinh", true);
                if (!_gioiTinh.Equals(value))
                {
                    _gioiTinh = value;
                    PropertyHasChanged("GioiTinh");
                }
            }
        }

        public string DiaChi
        {
            get
            {
                CanReadProperty("DiaChi", true);
                return _diaChi;
            }
            set
            {
                CanWriteProperty("DiaChi", true);
                if (value == null) value = string.Empty;
                if (!_diaChi.Equals(value))
                {
                    _diaChi = value;
                    PropertyHasChanged("DiaChi");
                }
            }
        }

        public string DienThoai
        {
            get
            {
                CanReadProperty("DienThoai", true);
                return _dienThoai;
            }
            set
            {
                CanWriteProperty("DienThoai", true);
                if (value == null) value = string.Empty;
                if (!_dienThoai.Equals(value))
                {
                    _dienThoai = value;
                    PropertyHasChanged("DienThoai");
                }
            }
        }

        public Nullable<int> QueQuan
        {
            get
            {
                CanReadProperty("QueQuan", true);
                return _queQuan;
            }
            set
            {
                CanWriteProperty("QueQuan", true);
                if (!_queQuan.Equals(value))
                {
                    _queQuan = value;
                    PropertyHasChanged("QueQuan");
                }
            }
        }

        protected override object GetIdValue()
        {
            return _maDTNgoaiChiTiet;
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
            // HocVien
            //
            ValidationRules.AddRule(CommonRulesEx.ValueRequire, new CommonRulesEx.RequireArgs("HocVien", "Chưa nhập tên học viên"));
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("HocVien", 50));
            //
            // NgaySinh
            //
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("NgaySinh", 10));
            //
            // DienThoai
            //
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("DienThoai", 50));
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
            //TODO: Define authorization rules in DaoTaoNgoai_ChiTietListChild
            //AuthorizationRules.AllowRead("MaDTNgoaiChiTiet", "DaoTaoNgoai_ChiTietListChildReadGroup");
            //AuthorizationRules.AllowRead("MaDTNgoai", "DaoTaoNgoai_ChiTietListChildReadGroup");
            //AuthorizationRules.AllowRead("HocVien", "DaoTaoNgoai_ChiTietListChildReadGroup");
            //AuthorizationRules.AllowRead("NgaySinh", "DaoTaoNgoai_ChiTietListChildReadGroup");
            //AuthorizationRules.AllowRead("GioiTinh", "DaoTaoNgoai_ChiTietListChildReadGroup");
            //AuthorizationRules.AllowRead("DiaChi", "DaoTaoNgoai_ChiTietListChildReadGroup");
            //AuthorizationRules.AllowRead("DienThoai", "DaoTaoNgoai_ChiTietListChildReadGroup");
            //AuthorizationRules.AllowRead("QueQuan", "DaoTaoNgoai_ChiTietListChildReadGroup");

            //AuthorizationRules.AllowWrite("MaDTNgoai", "DaoTaoNgoai_ChiTietListChildWriteGroup");
            //AuthorizationRules.AllowWrite("HocVien", "DaoTaoNgoai_ChiTietListChildWriteGroup");
            //AuthorizationRules.AllowWrite("NgaySinh", "DaoTaoNgoai_ChiTietListChildWriteGroup");
            //AuthorizationRules.AllowWrite("GioiTinh", "DaoTaoNgoai_ChiTietListChildWriteGroup");
            //AuthorizationRules.AllowWrite("DiaChi", "DaoTaoNgoai_ChiTietListChildWriteGroup");
            //AuthorizationRules.AllowWrite("DienThoai", "DaoTaoNgoai_ChiTietListChildWriteGroup");
            //AuthorizationRules.AllowWrite("QueQuan", "DaoTaoNgoai_ChiTietListChildWriteGroup");
        }

        #endregion //Authorization Rules

        #region Factory Methods
        internal static DaoTaoNgoai_ChiTietListChild NewDaoTaoNgoai_ChiTietListChild()
        {
            return new DaoTaoNgoai_ChiTietListChild();
        }

        internal static DaoTaoNgoai_ChiTietListChild GetDaoTaoNgoai_ChiTietListChild(SafeDataReader dr)
        {
            return new DaoTaoNgoai_ChiTietListChild(dr);
        }

        public DaoTaoNgoai_ChiTietListChild()
        {

            ValidationRules.CheckRules();
            MarkAsChild();
        }

        private DaoTaoNgoai_ChiTietListChild(SafeDataReader dr)
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
            _maDTNgoaiChiTiet = dr.GetInt32("MaDTNgoaiChiTiet");
            _maDTNgoai = dr.GetInt32("MaDTNgoai");
            _hocVien = dr.GetString("HocVien");
            _ngaySinh = dr.GetString("NgaySinh");
            _gioiTinh = dr.GetBoolean("GioiTinh");
            _diaChi = dr.GetString("DiaChi");
            _dienThoai = dr.GetString("DienThoai");
            _queQuan = (Nullable<int>)dr.GetValue("QueQuan");
        }

        private void FetchChildren(SafeDataReader dr)
        {
        }
        #endregion //Data Access - Fetch

        #region Data Access - Insert
        internal void Insert(SqlTransaction tr, DaoTaoNgoai parent)
        {
            if (!IsDirty) return;

            ExecuteInsert(tr, parent);
            MarkOld();

            //update child object(s)
            UpdateChildren(tr);
        }

        private void ExecuteInsert(SqlTransaction tr, DaoTaoNgoai parent)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_Insert_DaoTaoNgoai_ChiTietListChild";

                AddInsertParameters(cm, parent);

                cm.ExecuteNonQuery();

                _maDTNgoaiChiTiet = (int)cm.Parameters["@MaDTNgoaiChiTiet"].Value;
            }//using
        }

        private void AddInsertParameters(SqlCommand cm, DaoTaoNgoai parent)
        {
            _maDTNgoai = parent.MaDTNgoai;
            cm.Parameters.AddWithValue("@MaDTNgoai", _maDTNgoai);
            cm.Parameters.AddWithValue("@HocVien", _hocVien);
            if (_ngaySinh.Length > 0)
                cm.Parameters.AddWithValue("@NgaySinh", _ngaySinh);
            else
                cm.Parameters.AddWithValue("@NgaySinh", DBNull.Value);
            cm.Parameters.AddWithValue("@GioiTinh", _gioiTinh);
            if (_diaChi.Length > 0)
                cm.Parameters.AddWithValue("@DiaChi", _diaChi);
            else
                cm.Parameters.AddWithValue("@DiaChi", DBNull.Value);
            if (_dienThoai.Length > 0)
                cm.Parameters.AddWithValue("@DienThoai", _dienThoai);
            else
                cm.Parameters.AddWithValue("@DienThoai", DBNull.Value);
            if (_queQuan.HasValue)
                cm.Parameters.AddWithValue("@QueQuan", _queQuan);
            else
                cm.Parameters.AddWithValue("@QueQuan", DBNull.Value);
            cm.Parameters.AddWithValue("@MaDTNgoaiChiTiet", _maDTNgoaiChiTiet);
            cm.Parameters["@MaDTNgoaiChiTiet"].Direction = ParameterDirection.Output;
        }
        #endregion //Data Access - Insert

        #region Data Access - Update
        internal void Update(SqlTransaction tr, DaoTaoNgoai parent)
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

        private void ExecuteUpdate(SqlTransaction tr, DaoTaoNgoai parent)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_Update_DaoTaoNgoai_ChiTietListChild";

                AddUpdateParameters(cm, parent);

                cm.ExecuteNonQuery();

            }//using
        }

        private void AddUpdateParameters(SqlCommand cm, DaoTaoNgoai parent)
        {
            cm.Parameters.AddWithValue("@MaDTNgoaiChiTiet", _maDTNgoaiChiTiet);
            cm.Parameters.AddWithValue("@MaDTNgoai", _maDTNgoai);
            cm.Parameters.AddWithValue("@HocVien", _hocVien);
            if (_ngaySinh.Length > 0)
                cm.Parameters.AddWithValue("@NgaySinh", _ngaySinh);
            else
                cm.Parameters.AddWithValue("@NgaySinh", DBNull.Value);
            cm.Parameters.AddWithValue("@GioiTinh", _gioiTinh);
            if (_diaChi.Length > 0)
                cm.Parameters.AddWithValue("@DiaChi", _diaChi);
            else
                cm.Parameters.AddWithValue("@DiaChi", DBNull.Value);
            if (_dienThoai.Length > 0)
                cm.Parameters.AddWithValue("@DienThoai", _dienThoai);
            else
                cm.Parameters.AddWithValue("@DienThoai", DBNull.Value);
            if (_queQuan.HasValue)
                cm.Parameters.AddWithValue("@QueQuan", _queQuan);
            else
                cm.Parameters.AddWithValue("@QueQuan", DBNull.Value);
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
                cm.CommandText = "spd_Delete_DaoTaoNgoai_ChiTietListChild";

                cm.Parameters.AddWithValue("@MaDTNgoaiChiTiet", this._maDTNgoaiChiTiet);

                cm.ExecuteNonQuery();
            }//using
        }
        #endregion //Data Access - Delete
        #endregion //Data Access
    }
}
