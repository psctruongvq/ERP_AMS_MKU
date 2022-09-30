
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
    public class DeNghiChuyenKhoan_TKPhu : Csla.BusinessBase<DeNghiChuyenKhoan_TKPhu>
    {
        #region Business Properties and Methods

        //declare members
        private long _maPhieu = 0;
        private long _maDoiTac = 0;
        private string _tenDoiTac = string.Empty;
        private string _soTaiKhoan = string.Empty;
        private long _maTKPhu = 0;
        private bool _taiKhoanPhu = false;

        [System.ComponentModel.DataObjectField(true, false)]
        public long MaPhieu
        {
            get
            {
                CanReadProperty("MaPhieu", true);
                return _maPhieu;
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

        public string TenDoiTac
        {
            get
            {
                CanReadProperty("TenDoiTac", true);
                return _tenDoiTac;
            }
            set
            {
                CanWriteProperty("TenDoiTac", true);
                if (value == null) value = string.Empty;
                if (!_tenDoiTac.Equals(value))
                {
                    _tenDoiTac = value;
                    PropertyHasChanged("TenDoiTac");
                }
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

        public long MaTKPhu
        {
            get
            {
                CanReadProperty("MaTKPhu", true);
                return _maTKPhu;
            }
            set
            {
                CanWriteProperty("MaTKPhu", true);
                if (!_maTKPhu.Equals(value))
                {
                    _maTKPhu = value;
                    PropertyHasChanged("MaTKPhu");
                }
            }
        }

        public bool IsTaiKhoanPhu
        {
            get
            {
                CanReadProperty("TaiKhoanPhu", true);
                return _taiKhoanPhu;
            }
            set
            {
                CanWriteProperty("TaiKhoanPhu", true);
                if (!_taiKhoanPhu.Equals(value))
                {
                    _taiKhoanPhu = value;
                    PropertyHasChanged("TaiKhoanPhu");
                }
            }
        }

        protected override object GetIdValue()
        {
            return _maPhieu;
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
            // TenDoiTac
            //
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("TenDoiTac", 500));
            //
            // SoTaiKhoan
            //
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("SoTaiKhoan", 50));
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
            //TODO: Define authorization rules in DeNghiChuyenKhoan_TKPhu
            //AuthorizationRules.AllowRead("MaPhieu", "DeNghiChuyenKhoan_TKPhuReadGroup");
            //AuthorizationRules.AllowRead("MaDoiTac", "DeNghiChuyenKhoan_TKPhuReadGroup");
            //AuthorizationRules.AllowRead("TenDoiTac", "DeNghiChuyenKhoan_TKPhuReadGroup");
            //AuthorizationRules.AllowRead("SoTaiKhoan", "DeNghiChuyenKhoan_TKPhuReadGroup");
            //AuthorizationRules.AllowRead("MaTKPhu", "DeNghiChuyenKhoan_TKPhuReadGroup");
            //AuthorizationRules.AllowRead("TaiKhoanPhu", "DeNghiChuyenKhoan_TKPhuReadGroup");

            //AuthorizationRules.AllowWrite("MaDoiTac", "DeNghiChuyenKhoan_TKPhuWriteGroup");
            //AuthorizationRules.AllowWrite("TenDoiTac", "DeNghiChuyenKhoan_TKPhuWriteGroup");
            //AuthorizationRules.AllowWrite("SoTaiKhoan", "DeNghiChuyenKhoan_TKPhuWriteGroup");
            //AuthorizationRules.AllowWrite("MaTKPhu", "DeNghiChuyenKhoan_TKPhuWriteGroup");
            //AuthorizationRules.AllowWrite("TaiKhoanPhu", "DeNghiChuyenKhoan_TKPhuWriteGroup");
        }

        #endregion //Authorization Rules

        #region Factory Methods
        internal static DeNghiChuyenKhoan_TKPhu NewDeNghiChuyenKhoan_TKPhu(long maPhieu)
        {
            return new DeNghiChuyenKhoan_TKPhu(maPhieu);
        }

        internal static DeNghiChuyenKhoan_TKPhu NewDeNghiChuyenKhoan_TKPhu()
        {
            return new DeNghiChuyenKhoan_TKPhu();
        }

        internal static DeNghiChuyenKhoan_TKPhu GetDeNghiChuyenKhoan_TKPhu(SafeDataReader dr)
        {
            return new DeNghiChuyenKhoan_TKPhu(dr);
        }

        internal static DeNghiChuyenKhoan_TKPhu GetDeNghiChuyenKhoan_TKPhu(long maPhieu)
        {
            return DataPortal.Fetch<DeNghiChuyenKhoan_TKPhu>(new Criteria(maPhieu));
        }

        private DeNghiChuyenKhoan_TKPhu(long maPhieu)
        {
            this._maPhieu = maPhieu;
            ValidationRules.CheckRules();
            MarkAsChild();
        }

        private DeNghiChuyenKhoan_TKPhu()
        {
            ValidationRules.CheckRules();
            MarkAsChild();
        }

        private DeNghiChuyenKhoan_TKPhu(SafeDataReader dr)
        {
            MarkAsChild();
            Fetch(dr);
        }
        #endregion //Factory Methods


        #region Data Access

        #region Data Access - Fetch
        [Serializable()]
        private class Criteria
        {
            public long MaPhieu;

            public Criteria(long maPhieu)
            {
                this.MaPhieu = maPhieu;
            }
        }

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
                cm.CommandText = "spd_SelecttblDeNghiChuyenKhoan_TKPhu";

                cm.Parameters.AddWithValue("@MaPhieu", criteria.MaPhieu);

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

        #endregion //Data Access - Fetch

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
            _maPhieu = dr.GetInt64("MaPhieu");
            _maDoiTac = dr.GetInt64("MaDoiTac");
            _tenDoiTac = dr.GetString("TenDoiTac");
            _soTaiKhoan = dr.GetString("SoTaiKhoan");
            _maTKPhu = dr.GetInt64("MaTKPhu");
            _taiKhoanPhu = dr.GetBoolean("TaiKhoanPhu");
        }

        private void FetchChildren(SafeDataReader dr)
        {
        }
        #endregion //Data Access - Fetch

        #region Data Access - Insert
        internal void Insert(SqlTransaction tr, DeNghiChuyenKhoan parent)
        {
            if (!IsDirty) return;

            ExecuteInsert(tr, parent);
            MarkOld();

            //update child object(s)
            UpdateChildren(tr);
        }

        private void ExecuteInsert(SqlTransaction tr, DeNghiChuyenKhoan parent)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_InserttblDeNghiChuyenKhoan_TKPhu";

                AddInsertParameters(cm, parent);

                cm.ExecuteNonQuery();

            }//using
        }

        private void AddInsertParameters(SqlCommand cm, DeNghiChuyenKhoan parent)
        {
            cm.Parameters.AddWithValue("@MaPhieu", parent.MaPhieu);
            //TODO: if parent use identity key, fix fk member with value from parent
            cm.Parameters.AddWithValue("@MaDoiTac", _maDoiTac);
            if (_tenDoiTac.Length > 0)
                cm.Parameters.AddWithValue("@TenDoiTac", _tenDoiTac);
            else
                cm.Parameters.AddWithValue("@TenDoiTac", DBNull.Value);
            if (_soTaiKhoan.Length > 0)
                cm.Parameters.AddWithValue("@SoTaiKhoan", _soTaiKhoan);
            else
                cm.Parameters.AddWithValue("@SoTaiKhoan", DBNull.Value);
            if (_maTKPhu != 0)
                cm.Parameters.AddWithValue("@MaTKPhu", _maTKPhu);
            else
                cm.Parameters.AddWithValue("@MaTKPhu", DBNull.Value);
            cm.Parameters.AddWithValue("@TaiKhoanPhu", _taiKhoanPhu);
        }
        #endregion //Data Access - Insert

        #region Data Access - Update
        internal void Update(SqlTransaction tr, DeNghiChuyenKhoan parent)
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

        private void ExecuteUpdate(SqlTransaction tr, DeNghiChuyenKhoan parent)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_UpdatetblDeNghiChuyenKhoan_TKPhu";

                AddUpdateParameters(cm, parent);

                cm.ExecuteNonQuery();

            }//using
        }

        private void AddUpdateParameters(SqlCommand cm, DeNghiChuyenKhoan parent)
        {
            cm.Parameters.AddWithValue("@MaPhieu", parent.MaPhieu);
            //TODO: if parent use identity key, fix fk member with value from parent
            cm.Parameters.AddWithValue("@MaDoiTac", _maDoiTac);
            if (_tenDoiTac.Length > 0)
                cm.Parameters.AddWithValue("@TenDoiTac", _tenDoiTac);
            else
                cm.Parameters.AddWithValue("@TenDoiTac", DBNull.Value);
            if (_soTaiKhoan.Length > 0)
                cm.Parameters.AddWithValue("@SoTaiKhoan", _soTaiKhoan);
            else
                cm.Parameters.AddWithValue("@SoTaiKhoan", DBNull.Value);
            if (_maTKPhu != 0)
                cm.Parameters.AddWithValue("@MaTKPhu", _maTKPhu);
            else
                cm.Parameters.AddWithValue("@MaTKPhu", DBNull.Value);
            cm.Parameters.AddWithValue("@TaiKhoanPhu", _taiKhoanPhu);
        }

        private void UpdateChildren(SqlTransaction tr)
        {
        }
        #endregion //Data Access - Update

        #region Data Access - Delete
        internal void DeleteSelf(SqlTransaction tr, DeNghiChuyenKhoan parent)
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
                cm.CommandText = "spd_DeletetblDeNghiChuyenKhoan_TKPhu";

                cm.Parameters.AddWithValue("@MaPhieu", this._maPhieu);

                cm.ExecuteNonQuery();
            }//using
        }
        #endregion //Data Access - Delete
    }
}
