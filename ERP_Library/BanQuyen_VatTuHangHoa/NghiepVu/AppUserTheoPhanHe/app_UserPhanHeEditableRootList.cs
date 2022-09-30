using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{
    [Serializable()]
    public class app_UserPhanHeEditableRootList : Csla.BusinessListBase<app_UserPhanHeEditableRootList, app_UserPhanHeEditableSwitchable>
    {
        #region BindingList Overrides
        protected override object AddNewCore()
        {
            app_UserPhanHeEditableSwitchable item = app_UserPhanHeEditableSwitchable.Newapp_UserPhanHeEditableSwitchable();
            this.Add(item);
            return item;
        }
        #endregion //BindingList Overrides

        #region Authorization Rules

        public static bool CanGetObject()
        {
            //TODO: Define CanGetObject permission in app_UserPhanHeEditableRootList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("app_UserPhanHeEditableRootListViewGroup"))
            //	return true;
            //return false;
        }

        public static bool CanAddObject()
        {
            //TODO: Define CanAddObject permission in app_UserPhanHeEditableRootList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("app_UserPhanHeEditableRootListAddGroup"))
            //	return true;
            //return false;
        }

        public static bool CanEditObject()
        {
            //TODO: Define CanEditObject permission in app_UserPhanHeEditableRootList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("app_UserPhanHeEditableRootListEditGroup"))
            //	return true;
            //return false;
        }

        public static bool CanDeleteObject()
        {
            //TODO: Define CanDeleteObject permission in app_UserPhanHeEditableRootList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("app_UserPhanHeEditableRootListDeleteGroup"))
            //	return true;
            //return false;
        }
        #endregion //Authorization Rules

        #region Factory Methods
        private app_UserPhanHeEditableRootList()
        { /* require use of factory method */ }

        public static app_UserPhanHeEditableRootList Newapp_UserPhanHeEditableRootList()
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a app_UserPhanHeEditableRootList");
            return new app_UserPhanHeEditableRootList();
        }

        public static app_UserPhanHeEditableRootList Getapp_UserPhanHeEditableRootList(int maPhanHe, int userID)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a app_UserPhanHeEditableRootList");
            return DataPortal.Fetch<app_UserPhanHeEditableRootList>(new FilterCriteria(maPhanHe, userID));
        }
        #endregion //Factory Methods

        #region Data Access

        #region Filter Criteria
        [Serializable()]
        private class FilterCriteria
        {
            public int MaPhanHe;
            public int UserID;

            public FilterCriteria(int maPhanHe, int userID)
            {
                this.MaPhanHe = maPhanHe;
                this.UserID = userID;
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
                cm.CommandText = "spd_Selectapp_UserPhanHesAll";
                cm.Parameters.AddWithValue("@MaPhanHe", criteria.MaPhanHe);
                cm.Parameters.AddWithValue("@UserID", criteria.UserID);

                using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                {
                    while (dr.Read())
                        this.Add(app_UserPhanHeEditableSwitchable.Getapp_UserPhanHeEditableSwitchable(dr));
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
                foreach (app_UserPhanHeEditableSwitchable deletedChild in DeletedList)
                    deletedChild.DeleteSelf(cn);
                DeletedList.Clear();

                // loop through each non-deleted child object
                foreach (app_UserPhanHeEditableSwitchable child in this)
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
