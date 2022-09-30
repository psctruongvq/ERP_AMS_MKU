using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{
    [Serializable()]
    public class ThongTuApDung1List : Csla.BusinessListBase<ThongTuApDung1List, ThongTuApDung1>
    {
        #region BindingList Overrides
        protected override object AddNewCore()
        {
            ThongTuApDung1 item = ThongTuApDung1.NewThongTuApDung1();
            this.Add(item);
            return item;
        }
        #endregion //BindingList Overrides

        #region Authorization Rules

        public static bool CanGetObject()
        {
            //TODO: Define CanGetObject permission in ThongTuApDung1List
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("ThongTuApDung1ListViewGroup"))
            //	return true;
            //return false;
        }

        public static bool CanAddObject()
        {
            //TODO: Define CanAddObject permission in ThongTuApDung1List
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("ThongTuApDung1ListAddGroup"))
            //	return true;
            //return false;
        }

        public static bool CanEditObject()
        {
            //TODO: Define CanEditObject permission in ThongTuApDung1List
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("ThongTuApDung1ListEditGroup"))
            //	return true;
            //return false;
        }

        public static bool CanDeleteObject()
        {
            //TODO: Define CanDeleteObject permission in ThongTuApDung1List
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("ThongTuApDung1ListDeleteGroup"))
            //	return true;
            //return false;
        }
        #endregion //Authorization Rules

        #region Factory Methods
        private ThongTuApDung1List()
        { /* require use of factory method */ }

        public static ThongTuApDung1List NewThongTuApDung1List()
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a ThongTuApDung1List");
            return new ThongTuApDung1List();
        }

        public static ThongTuApDung1List GetThongTuApDung1List()
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a ThongTuApDung1List");
            return DataPortal.Fetch<ThongTuApDung1List>(new FilterCriteria());
        }

        #endregion //Factory Methods

        #region Data Access

        #region Filter Criteria
        [Serializable()]
        private class FilterCriteria
        {
            public FilterCriteria()
            {

            }
        }
        #endregion //Filter Criteria

        #region Data Access - Fetch
        private void DataPortal_Fetch(object criteria)
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

        private void ExecuteFetch(SqlTransaction tr, object criteria)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                if (criteria is FilterCriteria)
                {
                    cm.CommandText = "spd_GetThongTuApDung1List";
                }


                using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                {
                    while (dr.Read())
                        this.Add(ThongTuApDung1.GetThongTuApDung1(dr));
                }
            }//using
        }

        #endregion //Data Access - Fetch


        #region Data Access - Update
        protected override void DataPortal_Update()
        {
            RaiseListChangedEvents = false;

            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();

                // loop through each deleted child object
                foreach (ThongTuApDung1 deletedChild in DeletedList)
                    deletedChild.DeleteSelf(cn);
                DeletedList.Clear();

                // loop through each non-deleted child object
                foreach (ThongTuApDung1 child in this)
                {
                    if (child.IsNew)
                        child.Insert(cn);
                    else
                        child.Update(cn);
                }
            }//using SqlConnection

            RaiseListChangedEvents = true;
        }
        #endregion //Data Access - Update
        #endregion //Data Access
    }
}
