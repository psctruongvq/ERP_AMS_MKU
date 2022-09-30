
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{
    [Serializable()]
    public class LoaiChiPhiSanXuatChuongTrinh : Csla.BusinessBase<LoaiChiPhiSanXuatChuongTrinh>
    {
        #region Business Properties and Methods

        //declare members
        private int _maLoaiChiPhi = 0;
        private string _maQuanLy = string.Empty;
        private string _tenLoaiChiPhi = string.Empty;
        private string _ghiChu = string.Empty;

        [System.ComponentModel.DataObjectField(true, true)]
        public int MaLoaiChiPhi
        {
            get
            {
                return _maLoaiChiPhi;
            }
        }

        public string MaQuanLy
        {
            get
            {
                return _maQuanLy;
            }
            set
            {
                if (value == null) value = string.Empty;
                if (!_maQuanLy.Equals(value))
                {
                    _maQuanLy = value;
                    PropertyHasChanged("MaQuanLy");
                }
            }
        }

        public string TenLoaiChiPhi
        {
            get
            {
                return _tenLoaiChiPhi;
            }
            set
            {
                if (value == null) value = string.Empty;
                if (!_tenLoaiChiPhi.Equals(value))
                {
                    _tenLoaiChiPhi = value;
                    PropertyHasChanged("TenLoaiChiPhi");
                }
            }
        }

        public string GhiChu
        {
            get
            {
                return _ghiChu;
            }
            set
            {
                if (value == null) value = string.Empty;
                if (!_ghiChu.Equals(value))
                {
                    _ghiChu = value;
                    PropertyHasChanged("GhiChu");
                }
            }
        }

        protected override object GetIdValue()
        {
            return _maLoaiChiPhi;
        }

        #endregion //Business Properties and Methods

        #region Validation Rules
        private void AddCustomRules()
        {
            //add custom/non-generated rules here...
        }

        private void AddCommonRules()
        {
            ////
            //// MaQuanLy
            ////
            //ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("MaQuanLy", 50));
            ////
            //// TenLoaiChiPhi
            ////
            //ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("TenLoaiChiPhi", 50));
            ////
            //// GhiChu
            ////
            //ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("GhiChu", 50));
        }

        protected override void AddBusinessRules()
        {
            AddCommonRules();
            AddCustomRules();
        }
        #endregion //Validation Rules

        #region Factory Methods
        private LoaiChiPhiSanXuatChuongTrinh()
        { /* require use of factory method */ }

        public static LoaiChiPhiSanXuatChuongTrinh NewLoaiChiPhiSanXuatChuongTrinh()
        {
            LoaiChiPhiSanXuatChuongTrinh item = new LoaiChiPhiSanXuatChuongTrinh();
            item.MarkAsChild();
            return item;
        }
        public static LoaiChiPhiSanXuatChuongTrinh NewLoaiChiPhiSanXuatChuongTrinh(string tenLoai)
        {
            LoaiChiPhiSanXuatChuongTrinh item = new LoaiChiPhiSanXuatChuongTrinh();
            item.MarkAsChild();
            item.TenLoaiChiPhi = tenLoai;
            return item;
        }

        public static LoaiChiPhiSanXuatChuongTrinh GetLoaiChiPhiSanXuatChuongTrinh(int maLoaiChiPhi)
        {
            return DataPortal.Fetch<LoaiChiPhiSanXuatChuongTrinh>(new Criteria(maLoaiChiPhi));
        }

        public static void DeleteLoaiChiPhiSanXuatChuongTrinh(int maLoaiChiPhi)
        {
            DataPortal.Delete(new Criteria(maLoaiChiPhi));
        }

        #endregion //Factory Methods

        #region Child Factory Methods
        internal static LoaiChiPhiSanXuatChuongTrinh NewLoaiChiPhiSanXuatChuongTrinhChild()
        {
            LoaiChiPhiSanXuatChuongTrinh child = new LoaiChiPhiSanXuatChuongTrinh();
            child.ValidationRules.CheckRules();
            child.MarkAsChild();
            return child;
        }

        internal static LoaiChiPhiSanXuatChuongTrinh GetLoaiChiPhiSanXuatChuongTrinh(SafeDataReader dr)
        {
            LoaiChiPhiSanXuatChuongTrinh child = new LoaiChiPhiSanXuatChuongTrinh();
            child.MarkAsChild();
            child.Fetch(dr);
            return child;
        }
        #endregion //Child Factory Methods

        #region Data Access

        #region Criteria

        [Serializable()]
        private class Criteria
        {
            public int MaLoaiChiPhi;

            public Criteria(int maLoaiChiPhi)
            {
                this.MaLoaiChiPhi = maLoaiChiPhi;
            }
        }

        #endregion //Criteria

        #region Data Access - Create
        [RunLocal]
        protected override void DataPortal_Create()
        {
            ValidationRules.CheckRules();
        }

        #endregion //Data Access - Create

        #region Data Access - Fetch
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
                cm.CommandText = "SelecttblLoaiChiPhiSanXuatChuongTrinh";

                cm.Parameters.AddWithValue("@MaLoaiChiPhi", criteria.MaLoaiChiPhi);

                using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                {
                    dr.Read();
                    FetchObject(dr);
                    ValidationRules.CheckRules();

                    //load child object(s)
                    FetchChildren(dr);
                }
            }//using
        }

        #endregion //Data Access - Fetch

        #region Data Access - Insert
        protected override void DataPortal_Insert()
        {
            SqlTransaction tr;

            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();

                tr = cn.BeginTransaction();
                try
                {
                    ExecuteInsert(tr, null);

                    //update child object(s)
                    UpdateChildren(tr);

                    tr.Commit();
                }
                catch
                {
                    tr.Rollback();
                    throw;
                }
            }//using

        }

        #endregion //Data Access - Insert

        #region Data Access - Update
        protected override void DataPortal_Update()
        {
            SqlTransaction tr;

            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();

                tr = cn.BeginTransaction();
                try
                {
                    if (base.IsDirty)
                    {
                        ExecuteUpdate(tr, null);
                    }

                    //update child object(s)
                    UpdateChildren(tr);

                    tr.Commit();
                }
                catch
                {
                    tr.Rollback();
                    throw;
                }
            }//using

        }

        #endregion //Data Access - Update

        #region Data Access - Delete
        protected override void DataPortal_DeleteSelf()
        {
            DataPortal_Delete(new Criteria(_maLoaiChiPhi));
        }

        private void DataPortal_Delete(Criteria criteria)
        {
            SqlTransaction tr;

            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();

                tr = cn.BeginTransaction();
                try
                {
                    ExecuteDelete(tr, criteria);

                    tr.Commit();
                }
                catch
                {
                    tr.Rollback();
                    throw;
                }
            }//using

        }

        private void ExecuteDelete(SqlTransaction tr, Criteria criteria)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "DeletetblLoaiChiPhiSanXuatChuongTrinh";

                cm.Parameters.AddWithValue("@MaLoaiChiPhi", criteria.MaLoaiChiPhi);

                cm.ExecuteNonQuery();
            }//using
        }
        #endregion //Data Access - Delete

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
            _maLoaiChiPhi = dr.GetInt32("MaLoaiChiPhi");
            _maQuanLy = dr.GetString("MaQuanLy");
            _tenLoaiChiPhi = dr.GetString("TenLoaiChiPhi");
            _ghiChu = dr.GetString("GhiChu");
        }

        private void FetchChildren(SafeDataReader dr)
        {
        }
        #endregion //Data Access - Fetch

        #region Data Access - Insert
        internal void Insert(SqlTransaction tr, LoaiChiPhiSanXuatChuongTrinhList parent)
        {
            if (!IsDirty) return;

            ExecuteInsert(tr, parent);
            MarkOld();

            //update child object(s)
            UpdateChildren(tr);
        }

        private void ExecuteInsert(SqlTransaction tr, LoaiChiPhiSanXuatChuongTrinhList parent)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "InserttblLoaiChiPhiSanXuatChuongTrinh";

                AddInsertParameters(cm, parent);

                cm.ExecuteNonQuery();

                _maLoaiChiPhi = (int)cm.Parameters["@MaLoaiChiPhi"].Value;
            }//using
        }

        private void AddInsertParameters(SqlCommand cm, LoaiChiPhiSanXuatChuongTrinhList parent)
        {
            //TODO: if parent use identity key, fix fk member with value from parent
            if (_maQuanLy.Length > 0)
                cm.Parameters.AddWithValue("@MaQuanLy", _maQuanLy);
            else
                cm.Parameters.AddWithValue("@MaQuanLy", DBNull.Value);
            if (_tenLoaiChiPhi.Length > 0)
                cm.Parameters.AddWithValue("@TenLoaiChiPhi", _tenLoaiChiPhi);
            else
                cm.Parameters.AddWithValue("@TenLoaiChiPhi", DBNull.Value);
            if (_ghiChu.Length > 0)
                cm.Parameters.AddWithValue("@GhiChu", _ghiChu);
            else
                cm.Parameters.AddWithValue("@GhiChu", DBNull.Value);
            cm.Parameters.AddWithValue("@MaLoaiChiPhi", _maLoaiChiPhi);
            cm.Parameters["@MaLoaiChiPhi"].Direction = ParameterDirection.Output;
        }
        #endregion //Data Access - Insert

        #region Data Access - Update
        internal void Update(SqlTransaction tr, LoaiChiPhiSanXuatChuongTrinhList parent)
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

        private void ExecuteUpdate(SqlTransaction tr, LoaiChiPhiSanXuatChuongTrinhList parent)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "UpdatetblLoaiChiPhiSanXuatChuongTrinh";

                AddUpdateParameters(cm, parent);

                cm.ExecuteNonQuery();

            }//using
        }

        private void AddUpdateParameters(SqlCommand cm, LoaiChiPhiSanXuatChuongTrinhList parent)
        {
            cm.Parameters.AddWithValue("@MaLoaiChiPhi", _maLoaiChiPhi);
            if (_maQuanLy.Length > 0)
                cm.Parameters.AddWithValue("@MaQuanLy", _maQuanLy);
            else
                cm.Parameters.AddWithValue("@MaQuanLy", DBNull.Value);
            if (_tenLoaiChiPhi.Length > 0)
                cm.Parameters.AddWithValue("@TenLoaiChiPhi", _tenLoaiChiPhi);
            else
                cm.Parameters.AddWithValue("@TenLoaiChiPhi", DBNull.Value);
            if (_ghiChu.Length > 0)
                cm.Parameters.AddWithValue("@GhiChu", _ghiChu);
            else
                cm.Parameters.AddWithValue("@GhiChu", DBNull.Value);
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

            ExecuteDelete(tr, new Criteria(_maLoaiChiPhi));
            MarkNew();
        }
        #endregion //Data Access - Delete
        #endregion //Data Access
    }
}
