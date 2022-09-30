
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{
    [Serializable()]
    public class PhanQuyenSuDungForm : Csla.ReadOnlyBase<PhanQuyenSuDungForm>
    {
        #region Business Properties and Methods

        //declare members
        private int _userID = 0;
        private bool _them;
        private bool _sua;
        private bool _xoa;

        [System.ComponentModel.DataObjectField(true, false)]
        public int UserID
        {
            get
            {
                return _userID;
            }
        }

        public bool Them
        {
            get
            {
                return _them;
            }
        }
        public bool Sua
        {
            get
            {
                return _sua;
            }
        }
        public bool Xoa
        {
            get
            {
                return _xoa;
            }
        }

        protected override object GetIdValue()
        {
            return _userID;
        }

        #endregion //Business Properties and Methods

        #region Factory Methods
        private PhanQuyenSuDungForm()
        { /* require use of factory method */ }

        public static PhanQuyenSuDungForm GetQuyenSuDungFormTheoUser(int userID, string tenForm)
        {
            return DataPortal.Fetch<PhanQuyenSuDungForm>(new Criteria(userID, tenForm));
        }
        #endregion //Factory Methods


        #region Data Access

        #region Criteria

        [Serializable()]
        private class Criteria
        {
            public int UserID;
            public string TenForm;
            public Criteria(int userID, string tenForm)
            {
                this.UserID = userID;
                TenForm = tenForm;
            }
        }

        #endregion //Criteria

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
                cm.CommandText = "spd_Select_GetPhanQuyenCuaFormChoUser";
                cm.CommandTimeout = 900;
                cm.Parameters.AddWithValue("@UserID", criteria.UserID);
                cm.Parameters.AddWithValue("@TenForm", criteria.TenForm);
                using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                {
                    while (dr.Read())
                    {
                        FetchObject(dr);
                    }
                    //load child object(s)
                    //FetchChildren(dr);
                }
            }//using
        }

        private void FetchObject(SafeDataReader dr)
        {
            _userID = dr.GetInt32("UserID");
            _them = dr.GetBoolean("Them");
            _xoa = dr.GetBoolean("Xoa");
            _sua = dr.GetBoolean("Sua");

        }

        private void FetchChildren(SafeDataReader dr)
        {
        }
        #endregion //Data Access - Fetch
        #endregion //Data Access
    }
}