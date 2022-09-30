using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{
    [Serializable()]
    public class KyKeToanDevList : Csla.BusinessListBase<KyKeToanDevList, KyKeToanDev>
    {
        #region BindingList Overrides
        protected override object AddNewCore()
        {
            KyKeToanDev item = KyKeToanDev.NewKyKeToanDev();
            this.Add(item);
            return item;
        }
        #endregion //BindingList Overrides

        #region Authorization Rules

        public static bool CanGetObject()
        {
            //TODO: Define CanGetObject permission in KyKeToanDevList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("KyKeToanDevListViewGroup"))
            //	return true;
            //return false;
        }

        public static bool CanAddObject()
        {
            //TODO: Define CanAddObject permission in KyKeToanDevList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("KyKeToanDevListAddGroup"))
            //	return true;
            //return false;
        }

        public static bool CanEditObject()
        {
            //TODO: Define CanEditObject permission in KyKeToanDevList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("KyKeToanDevListEditGroup"))
            //	return true;
            //return false;
        }

        public static bool CanDeleteObject()
        {
            //TODO: Define CanDeleteObject permission in KyKeToanDevList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("KyKeToanDevListDeleteGroup"))
            //	return true;
            //return false;
        }
        #endregion //Authorization Rules

        #region Factory Methods
        private KyKeToanDevList()
        { /* require use of factory method */ }

        public static KyKeToanDevList NewKyKeToanDevList()
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a KyKeToanDevList");
            return new KyKeToanDevList();
        }

        public static KyKeToanDevList GetKyKeToanDevList()
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a KyKeToanDevList");
            return DataPortal.Fetch<KyKeToanDevList>(new FilterCriteria());
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
                cm.CommandText = "spd_SelecttblKyKeToanDevsAll";


                using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                {
                    while (dr.Read())
                        this.Add(KyKeToanDev.GetKyKeToanDev(dr));
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
                foreach (KyKeToanDev deletedChild in DeletedList)
                    deletedChild.DeleteSelf(cn);
                DeletedList.Clear();

                // loop through each non-deleted child object
                foreach (KyKeToanDev child in this)
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
