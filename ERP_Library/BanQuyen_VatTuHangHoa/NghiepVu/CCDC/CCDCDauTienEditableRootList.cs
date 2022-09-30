using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{
    [Serializable()]
    public class CCDCDauTienEditableRootList : Csla.BusinessListBase<CCDCDauTienEditableRootList, CCDCDauTienEditableSwitchable>
    {

        #region Authorization Rules

        public static bool CanGetObject()
        {
            //TODO: Define CanGetObject permission in CCDCDauTienEditableRootList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("CCDCDauTienEditableRootListViewGroup"))
            //	return true;
            //return false;
        }

        public static bool CanAddObject()
        {
            //TODO: Define CanAddObject permission in CCDCDauTienEditableRootList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("CCDCDauTienEditableRootListAddGroup"))
            //	return true;
            //return false;
        }

        public static bool CanEditObject()
        {
            //TODO: Define CanEditObject permission in CCDCDauTienEditableRootList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("CCDCDauTienEditableRootListEditGroup"))
            //	return true;
            //return false;
        }

        public static bool CanDeleteObject()
        {
            //TODO: Define CanDeleteObject permission in CCDCDauTienEditableRootList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("CCDCDauTienEditableRootListDeleteGroup"))
            //	return true;
            //return false;
        }
        #endregion //Authorization Rules

        #region Factory Methods
        private CCDCDauTienEditableRootList()
        { /* require use of factory method */ }

        public static CCDCDauTienEditableRootList NewCCDCDauTienEditableRootList()
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a CCDCDauTienEditableRootList");
            return new CCDCDauTienEditableRootList();
        }

        public static CCDCDauTienEditableRootList GetCCDCDauTienEditableRootList()
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a CCDCDauTienEditableRootList");
            return DataPortal.Fetch<CCDCDauTienEditableRootList>(new FilterCriteria());
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
        private void DataPortal_Fetch(FilterCriteria criteria)
        {
            RaiseListChangedEvents = false;

            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();

                ExecuteFetch(cn, criteria);
            }//using

            RaiseListChangedEvents = true;
        }

        private void ExecuteFetch(SqlConnection cn, FilterCriteria criteria)
        {
            using (SqlCommand cm = cn.CreateCommand())
            {
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_SelecttblCCDCDauTiensAll";
                //cm.Parameters.AddWithValue("@MaBoPhan", criteria.MaBoPhan);


                using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                {
                    while (dr.Read())
                        this.Add(CCDCDauTienEditableSwitchable.GetCCDCDauTienEditableSwitchable(dr));
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
                foreach (CCDCDauTienEditableSwitchable deletedChild in DeletedList)
                    deletedChild.DeleteSelf(cn);
                DeletedList.Clear();

                // loop through each non-deleted child object
                foreach (CCDCDauTienEditableSwitchable child in this)
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
