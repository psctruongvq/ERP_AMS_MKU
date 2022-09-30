
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{
    [Serializable()]
    public class Report_HeaderList : Csla.BusinessListBase<Report_HeaderList, Report_Header>
    {

        #region Authorization Rules

        public static bool CanGetObject()
        {
            //TODO: Define CanGetObject permission in Report_HeaderList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("Report_HeaderListViewGroup"))
            //	return true;
            //return false;
        }

        public static bool CanAddObject()
        {
            //TODO: Define CanAddObject permission in Report_HeaderList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("Report_HeaderListAddGroup"))
            //	return true;
            //return false;
        }

        public static bool CanEditObject()
        {
            //TODO: Define CanEditObject permission in Report_HeaderList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("Report_HeaderListEditGroup"))
            //	return true;
            //return false;
        }

        public static bool CanDeleteObject()
        {
            //TODO: Define CanDeleteObject permission in Report_HeaderList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("Report_HeaderListDeleteGroup"))
            //	return true;
            //return false;
        }
        #endregion //Authorization Rules

        #region Factory Methods
        private Report_HeaderList()
        { /* require use of factory method */ }

        public static Report_HeaderList NewReport_HeaderList()
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a Report_HeaderList");
            return new Report_HeaderList();
        }

        public static Report_HeaderList GetReport_HeaderList(int macongty)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a Report_HeaderList");
            return DataPortal.Fetch<Report_HeaderList>(new FilterCriteria(macongty));
        }
        #endregion //Factory Methods

        #region Data Access

        #region Filter Criteria
        [Serializable()]
        private class FilterCriteria
        {
            public int maky;
            public FilterCriteria(int maky)
            {
                this.maky=maky;
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
                cm.CommandText = "spd_REPORT_ReportHeader";
                cm.Parameters.AddWithValue("@macongty", criteria.maky);

                using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                {
                    while (dr.Read())
                        this.Add(Report_Header.GetReport_Header(dr));
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
                    foreach (Report_Header deletedChild in DeletedList)
                        deletedChild.DeleteSelf(tr);
                    DeletedList.Clear();

                    // loop through each non-deleted child object
                    foreach (Report_Header child in this)
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
        #endregion //Data Access - Update
        #endregion //Data Access
    }
}
