
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;
using ERP_Library.ThanhToan;

namespace ERP_Library
{
    [Serializable()]
    public class TKPhu_NganHang : Csla.BusinessBase<TKPhu_NganHang>
    {
        #region Business Properties and Methods

        //declare members
        private int _maTKPhu = 0;
        private string _soTaiKhoan = string.Empty;
        private int _maNganHang = 0;
        private long _maDoiTac = 0;
        private int _maTinhThanh = 0;
        private string _tenNganHang = string.Empty;
        private string _tenDoiTacPhu = string.Empty;

        [System.ComponentModel.DataObjectField(true, true)]
        public int MaTKPhu
        {
            get
            {
                CanReadProperty("MaTKPhu", true);
                return _maTKPhu;
            }
        }

        public string SoTaiKhoan
        {
            get
            {
                CanReadProperty("SoTaiKhoan", true);
                return _soTaiKhoan;
            }
            set
            {
                CanWriteProperty("SoTaiKhoan", true);
                if (value == null) value = string.Empty;
                if (!_soTaiKhoan.Equals(value))
                {
                    _soTaiKhoan = value;
                    PropertyHasChanged("SoTaiKhoan");
                }
            }
        }

        public int MaNganHang
        {
            get
            {
                CanReadProperty("MaNganHang", true);
                return _maNganHang;
            }
            set
            {
                CanWriteProperty("MaNganHang", true);
                if (!_maNganHang.Equals(value))
                {
                    _maNganHang = value;
                    PropertyHasChanged("MaNganHang");
                }
            }
        }

        public long MaDoiTac
        {
            get
            {
                CanReadProperty("MaDoiTac", true);
                return _maDoiTac;
            }
            set
            {
                CanWriteProperty("MaDoiTac", true);
                if (!_maDoiTac.Equals(value))
                {
                    _maDoiTac = value;
                    PropertyHasChanged("MaDoiTac");
                }
            }
        }

        public int MaTinhThanh
        {
            get
            {
                CanReadProperty("MaTinhThanh", true);
                return _maTinhThanh;
            }
            set
            {
                CanWriteProperty("MaTinhThanh", true);
                if (!_maTinhThanh.Equals(value))
                {
                    _maTinhThanh = value;
                    PropertyHasChanged("MaTinhThanh");
                }
            }
        }

        public string TenNganHang
        {
            get
            {
                CanReadProperty("TenNganHang", true);
                return _tenNganHang;
            }
            set
            {
                CanWriteProperty("TenNganHang", true);
                if (value == null) value = string.Empty;
                if (!_tenNganHang.Equals(value))
                {
                    _tenNganHang = value;
                    PropertyHasChanged("TenNganHang");
                }
            }
        }

        public string TenDoiTacPhu
        {
            get
            {
                CanReadProperty("TenDoiTacPhu", true);
                return _tenDoiTacPhu;
            }
            set
            {
                CanWriteProperty("TenDoiTacPhu", true);
                if (value == null) value = string.Empty;
                if (!_tenDoiTacPhu.Equals(value))
                {
                    _tenDoiTacPhu = value;
                    PropertyHasChanged("TenDoiTacPhu");
                }
            }
        }

        protected override object GetIdValue()
        {
            return _maTKPhu;
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
            // SoTaiKhoan
            //
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("SoTaiKhoan", 50));
            //
            // TenNganHang
            //
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("TenNganHang", 500));
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
            //TODO: Define authorization rules in TKPhu_NganHang
            //AuthorizationRules.AllowRead("MaTKPhu", "TKPhu_NganHangReadGroup");
            //AuthorizationRules.AllowRead("SoTaiKhoan", "TKPhu_NganHangReadGroup");
            //AuthorizationRules.AllowRead("MaNganHang", "TKPhu_NganHangReadGroup");
            //AuthorizationRules.AllowRead("MaDoiTac", "TKPhu_NganHangReadGroup");
            //AuthorizationRules.AllowRead("MaTinhThanh", "TKPhu_NganHangReadGroup");
            //AuthorizationRules.AllowRead("TenNganHang", "TKPhu_NganHangReadGroup");

            //AuthorizationRules.AllowWrite("SoTaiKhoan", "TKPhu_NganHangWriteGroup");
            //AuthorizationRules.AllowWrite("MaNganHang", "TKPhu_NganHangWriteGroup");
            //AuthorizationRules.AllowWrite("MaDoiTac", "TKPhu_NganHangWriteGroup");
            //AuthorizationRules.AllowWrite("MaTinhThanh", "TKPhu_NganHangWriteGroup");
            //AuthorizationRules.AllowWrite("TenNganHang", "TKPhu_NganHangWriteGroup");
        }

        #endregion //Authorization Rules

        #region Factory Methods
        internal static TKPhu_NganHang NewTKPhu_NganHang()
        {
            return new TKPhu_NganHang();
        }

        internal static TKPhu_NganHang GetTKPhu_NganHang(SafeDataReader dr)
        {
            return new TKPhu_NganHang(dr);
        }

        public static TKPhu_NganHang GetTKPhu_NganHang(long maTKPhu)
        {
            return DataPortal.Fetch<TKPhu_NganHang>(new Criteria(maTKPhu));
        }

        private TKPhu_NganHang()
        {
            ValidationRules.CheckRules();
            MarkAsChild();
        }

        private TKPhu_NganHang(SafeDataReader dr)
        {
            MarkAsChild();
            Fetch(dr);
        }
        #endregion //Factory Methods


        #region Data Access

        #region Data Access - Fetch
                #region Criteria

        [Serializable()]
        private class Criteria
        {
            public long _maTKPhu;

            public Criteria(long MaTKPhu)
            {
                this._maTKPhu = MaTKPhu;
            }
        }

        #endregion //Criteria

        private void DataPortal_Fetch(Criteria criteria)
        {
            SqlTransaction tr;

            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();

                tr = cn.BeginTransaction();
                try
                {
                    ExecuteFetch(tr, criteria);

                    tr.Commit();
                }
                catch
                {
                    tr.Rollback();
                    throw;
                }
            }//using
        }

        private void ExecuteFetch(SqlTransaction tr, Criteria criteria)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_SelecttblTKPhu_NganHang";

                cm.Parameters.AddWithValue("@maTKPhu", criteria._maTKPhu);

                using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                {
                    if (dr.Read())
                    {
                        FetchObject(dr);
                        ValidationRules.CheckRules();

                        //load child object(s)
                        FetchChildren(dr);
                    }
                }
            }//using
        }


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
            _maTKPhu = dr.GetInt32("maTKPhu");
            _soTaiKhoan = dr.GetString("SoTaiKhoan");
            _maNganHang = dr.GetInt32("MaNganHang");
            _maDoiTac = dr.GetInt64("MaDoiTac");
            _maTinhThanh = dr.GetInt32("MaTinhThanh");
            _tenNganHang = dr.GetString("TenNganHang");
            _tenDoiTacPhu = dr.GetString("TenDoiTacPhu");
        }

        private void FetchChildren(SafeDataReader dr)
        {
        }
        #endregion //Data Access - Fetch

        #region Data Access - Insert
        internal void Insert(SqlTransaction tr, DoiTac parent)
        {
            if (!IsDirty) return;

            ExecuteInsert(tr, parent);
            MarkOld();

            //update child object(s)
            UpdateChildren(tr);
        }

        private void ExecuteInsert(SqlTransaction tr, DoiTac parent)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_InserttblTKPhu_NganHang";

                AddInsertParameters(cm, parent);

                cm.ExecuteNonQuery();

                _maTKPhu = (int)cm.Parameters["@maTKPhu"].Value;
            }//using
        }

        private void AddInsertParameters(SqlCommand cm, DoiTac parent)
        {
            //TODO: if parent use identity key, fix fk member with value from parent
            if (_soTaiKhoan.Length > 0)
                cm.Parameters.AddWithValue("@SoTaiKhoan", _soTaiKhoan);
            else
                cm.Parameters.AddWithValue("@SoTaiKhoan", DBNull.Value);
            if (_maNganHang != 0)
                cm.Parameters.AddWithValue("@MaNganHang", _maNganHang);
            else
                cm.Parameters.AddWithValue("@MaNganHang", DBNull.Value);
            if (parent.MaDoiTac != 0)
                cm.Parameters.AddWithValue("@MaDoiTac", parent.MaDoiTac);
            else
                cm.Parameters.AddWithValue("@MaDoiTac", DBNull.Value);
            if (_maTinhThanh != 0)
                cm.Parameters.AddWithValue("@MaTinhThanh", _maTinhThanh);
            else
                cm.Parameters.AddWithValue("@MaTinhThanh", DBNull.Value);
            if (_tenNganHang.Length > 0)
                cm.Parameters.AddWithValue("@TenNganHang", _tenNganHang);
            else
                cm.Parameters.AddWithValue("@TenNganHang", DBNull.Value);
            if (_tenDoiTacPhu.Length > 0)
                cm.Parameters.AddWithValue("@TenDoiTacPhu", _tenDoiTacPhu);
            else
                cm.Parameters.AddWithValue("@TenDoiTacPhu", DBNull.Value);
            cm.Parameters.AddWithValue("@maTKPhu", _maTKPhu);
            cm.Parameters["@maTKPhu"].Direction = ParameterDirection.Output;
        }
        #endregion //Data Access - Insert

        #region Data Access - Update
        internal void Update(SqlTransaction tr, DoiTac parent)
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

        private void ExecuteUpdate(SqlTransaction tr, DoiTac parent)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_UpdatetblTKPhu_NganHang";

                AddUpdateParameters(cm, parent);

                cm.ExecuteNonQuery();

            }//using
        }

        private void AddUpdateParameters(SqlCommand cm, DoiTac parent)
        {
            cm.Parameters.AddWithValue("@maTKPhu", _maTKPhu);
            if (_soTaiKhoan.Length > 0)
                cm.Parameters.AddWithValue("@SoTaiKhoan", _soTaiKhoan);
            else
                cm.Parameters.AddWithValue("@SoTaiKhoan", DBNull.Value);
            if (_maNganHang != 0)
                cm.Parameters.AddWithValue("@MaNganHang", _maNganHang);
            else
                cm.Parameters.AddWithValue("@MaNganHang", DBNull.Value);
            if (parent.MaDoiTac != 0)
                cm.Parameters.AddWithValue("@MaDoiTac", parent.MaDoiTac);
            else
                cm.Parameters.AddWithValue("@MaDoiTac", DBNull.Value);
            if (_maTinhThanh != 0)
                cm.Parameters.AddWithValue("@MaTinhThanh", _maTinhThanh);
            else
                cm.Parameters.AddWithValue("@MaTinhThanh", DBNull.Value);
            if (_tenNganHang.Length > 0)
                cm.Parameters.AddWithValue("@TenNganHang", _tenNganHang);
            else
                cm.Parameters.AddWithValue("@TenNganHang", DBNull.Value);
            if (_tenDoiTacPhu.Length > 0)
                cm.Parameters.AddWithValue("@TenDoiTacPhu", _tenDoiTacPhu);
            else
                cm.Parameters.AddWithValue("@TenDoiTacPhu", DBNull.Value);
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
                cm.CommandText = "spd_DeletetblTKPhu_NganHang";

                cm.Parameters.AddWithValue("@maTKPhu", this._maTKPhu);

                cm.ExecuteNonQuery();
            }//using
        }
        #endregion //Data Access - Delete
        #endregion //Data Access
    }
}
