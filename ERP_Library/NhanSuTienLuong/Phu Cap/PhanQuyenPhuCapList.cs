
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{
    [Serializable()]
    public class PhanQuyenPhuCapList : Csla.BusinessListBase<PhanQuyenPhuCapList, PhanQuyenPhuCap>
    {

        #region Factory Methods
        private PhanQuyenPhuCapList()
        { /* require use of factory method */ }

        public static PhanQuyenPhuCapList NewPhanQuyenPhuCapList()
        {
            return new PhanQuyenPhuCapList();
        }

        public static PhanQuyenPhuCapList GetPhanQuyenPhuCapList(int UserID)
        {
            return DataPortal.Fetch<PhanQuyenPhuCapList>(new FilterCriteria(UserID));
        }
        #endregion //Factory Methods

        #region Data Access

        #region Filter Criteria
        [Serializable()]
        private class FilterCriteria
        {
            public int UserID;
            public FilterCriteria(int userID)
            {
                UserID = userID;
            }
        }
        #endregion //Filter Criteria

        #region Data Access - Fetch
        private void DataPortal_Fetch(FilterCriteria criteria)
        {
            RaiseListChangedEvents = false;

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

            RaiseListChangedEvents = true;
        }

        private void ExecuteFetch(SqlTransaction tr, FilterCriteria criteria)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_Select_PhanQuyenPhuCapList";
                cm.Parameters.AddWithValue("@UserID", criteria.UserID);

                using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                {
                    while (dr.Read())
                        this.Add(PhanQuyenPhuCap.GetPhanQuyenPhuCap(dr));
                }
            }//using
        }
        #endregion //Data Access - Fetch


        #region Data Access - Update
        protected override void DataPortal_Update()
        {
            RaiseListChangedEvents = false;

            SqlTransaction tr;

            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();

                tr = cn.BeginTransaction();
                try
                {
                    // loop through each deleted child object
                    foreach (PhanQuyenPhuCap deletedChild in DeletedList)
                        deletedChild.DeleteSelf(tr);
                    DeletedList.Clear();

                    // loop through each non-deleted child object
                    foreach (PhanQuyenPhuCap child in this)
                    {
                        if (child.IsNew)
                            child.Insert(tr);
                        else
                            child.Update(tr);
                    }

                    tr.Commit();
                }
                catch
                {
                    tr.Rollback();
                    throw;
                }
            }//using SqlConnection

            RaiseListChangedEvents = true;
        }

        internal void Update(SqlTransaction tr, Security.UserItem parent)
        {
            RaiseListChangedEvents = false;

            // loop through each deleted child object
            foreach (PhanQuyenPhuCap deletedChild in DeletedList)
                deletedChild.DeleteSelf(tr);
            DeletedList.Clear();

            // loop through each non-deleted child object
            foreach (PhanQuyenPhuCap child in this)
            {
                if (child.IsNew)
                    child.Insert(tr);
                else
                    child.Update(tr);
            }

            RaiseListChangedEvents = true;
        }
        #endregion //Data Access - Update
        #endregion //Data Access
    }
}
