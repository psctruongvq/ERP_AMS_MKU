
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{
    [Serializable()]
    public class LoaiDocHai : Csla.BusinessBase<LoaiDocHai>
    {
        #region Business Properties and Methods

        //declare members
        internal int _maDocHai = 0;
        private string _ma = string.Empty;
        private string _ten = string.Empty;

        [System.ComponentModel.DataObjectField(true, true)]
        public int MaDocHai
        {
            get
            {
                return _maDocHai;
            }
        }

        public string Ma
        {
            get
            {
                return _ma;
            }
            set
            {
                if (value == null) value = string.Empty;
                if (!_ma.Equals(value))
                {
                    _ma = value;
                    PropertyHasChanged("Ma");
                }
            }
        }

        public string Ten
        {
            get
            {
                return _ten;
            }
            set
            {
                if (value == null) value = string.Empty;
                if (!_ten.Equals(value))
                {
                    _ten = value;
                    PropertyHasChanged("Ten");
                }
            }
        }

        protected override object GetIdValue()
        {
            return _maDocHai;
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
            // Ma
            //
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("Ma", 50));
            //
            // Ten
            //
            ValidationRules.AddRule(CommonRules.StringRequired, "Ten");
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("Ten", 100));
        }

        protected override void AddBusinessRules()
        {
            AddCommonRules();
            AddCustomRules();
        }
        #endregion //Validation Rules

        #region Factory Methods
        public LoaiDocHai()
        { /* require use of factory method */ }

        public static LoaiDocHai NewLoaiDocHai()
        {
            return DataPortal.Create<LoaiDocHai>();
        }

        public static LoaiDocHai GetLoaiDocHai(int maDocHai)
        {
            return DataPortal.Fetch<LoaiDocHai>(new Criteria(maDocHai));
        }

        public static void DeleteLoaiDocHai(int maDocHai)
        {
            DataPortal.Delete(new Criteria(maDocHai));
        }

        #endregion //Factory Methods

        #region Child Factory Methods
        internal static LoaiDocHai NewLoaiDocHaiChild()
        {
            LoaiDocHai child = new LoaiDocHai();
            child.ValidationRules.CheckRules();
            child.MarkAsChild();
            return child;
        }

        internal static LoaiDocHai GetLoaiDocHai(SafeDataReader dr)
        {
            LoaiDocHai child = new LoaiDocHai();
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
            public int MaDocHai;

            public Criteria(int maDocHai)
            {
                this.MaDocHai = maDocHai;
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
                cm.CommandText = "spd_Select_LoaiDocHai";

                cm.Parameters.AddWithValue("@MaDocHai", criteria.MaDocHai);

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
                    ExecuteInsert(tr);

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
                        ExecuteUpdate(tr);
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
            DataPortal_Delete(new Criteria(_maDocHai));
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
                cm.CommandText = "spd_Delete_LoaiDocHai";

                cm.Parameters.AddWithValue("@MaDocHai", criteria.MaDocHai);

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
            _maDocHai = dr.GetInt32("MaDocHai");
            _ma = dr.GetString("Ma");
            _ten = dr.GetString("Ten");
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
                cm.CommandText = "spd_Insert_LoaiDocHai";

                AddInsertParameters(cm);

                cm.ExecuteNonQuery();

                _maDocHai = (int)cm.Parameters["@MaDocHai"].Value;
            }//using
        }

        private void AddInsertParameters(SqlCommand cm)
        {
            if (_ma.Length > 0)
                cm.Parameters.AddWithValue("@Ma", _ma);
            else
                cm.Parameters.AddWithValue("@Ma", DBNull.Value);
            cm.Parameters.AddWithValue("@Ten", _ten);
            cm.Parameters.AddWithValue("@MaDocHai", _maDocHai);
            cm.Parameters["@MaDocHai"].Direction = ParameterDirection.Output;
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
                cm.CommandText = "spd_Update_LoaiDocHai";

                AddUpdateParameters(cm);

                cm.ExecuteNonQuery();

            }//using
        }

        private void AddUpdateParameters(SqlCommand cm)
        {
            cm.Parameters.AddWithValue("@MaDocHai", _maDocHai);
            if (_ma.Length > 0)
                cm.Parameters.AddWithValue("@Ma", _ma);
            else
                cm.Parameters.AddWithValue("@Ma", DBNull.Value);
            cm.Parameters.AddWithValue("@Ten", _ten);
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

            ExecuteDelete(tr, new Criteria(_maDocHai));
            MarkNew();
        }
        #endregion //Data Access - Delete
        #endregion //Data Access
    }
}
