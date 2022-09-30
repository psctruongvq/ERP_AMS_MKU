using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{
    [Serializable()]
    public class LoaiChungTuDevList : Csla.BusinessListBase<LoaiChungTuDevList, LoaiChungTuDev>
    {
        #region BindingList Overrides
        protected override object AddNewCore()
        {
            LoaiChungTuDev item = LoaiChungTuDev.NewLoaiChungTuDev();
            this.Add(item);
            return item;
        }
        #endregion //BindingList Overrides

        #region Authorization Rules

        public static bool CanGetObject()
        {
            //TODO: Define CanGetObject permission in LoaiChungTuDevList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("LoaiChungTuDevListViewGroup"))
            //	return true;
            //return false;
        }

        public static bool CanAddObject()
        {
            //TODO: Define CanAddObject permission in LoaiChungTuDevList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("LoaiChungTuDevListAddGroup"))
            //	return true;
            //return false;
        }

        public static bool CanEditObject()
        {
            //TODO: Define CanEditObject permission in LoaiChungTuDevList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("LoaiChungTuDevListEditGroup"))
            //	return true;
            //return false;
        }

        public static bool CanDeleteObject()
        {
            //TODO: Define CanDeleteObject permission in LoaiChungTuDevList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("LoaiChungTuDevListDeleteGroup"))
            //	return true;
            //return false;
        }
        #endregion //Authorization Rules

        #region Factory Methods
        private LoaiChungTuDevList()
        { /* require use of factory method */ }

        public static LoaiChungTuDevList NewLoaiChungTuDevList()
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a LoaiChungTuDevList");
            return new LoaiChungTuDevList();
        }

        public static LoaiChungTuDevList GetLoaiChungTuDevList()
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a LoaiChungTuDevList");
            return DataPortal.Fetch<LoaiChungTuDevList>(new FilterCriteria());
        }
        public static LoaiChungTuDevList GetLoaiChungTuDevListCustomize()
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a LoaiChungTuDevList");
            return DataPortal.Fetch<LoaiChungTuDevList>(new FilterCriteriaCustomize());
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
        [Serializable()]
        private class FilterCriteriaCustomize
        {

            public FilterCriteriaCustomize()
            {

            }
        }
        #endregion //Filter Criteria

        #region Data Access - Fetch
        private void DataPortal_Fetch(object criteria)
        {
            RaiseListChangedEvents = false;

            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();

                ExecuteFetch(cn, criteria);
            }//using

            RaiseListChangedEvents = true;
        }

        private void ExecuteFetch(SqlConnection cn, object criteria)
        {
            using (SqlCommand cm = cn.CreateCommand())
            {
                cm.CommandType = CommandType.StoredProcedure;
                if(criteria is FilterCriteriaCustomize)
                    cm.CommandText = "spd_SelecttblLoaiChungTuDevsAllCustomize";
                else
                    cm.CommandText = "spd_SelecttblLoaiChungTuDevsAll";


                using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                {
                    while (dr.Read())
                        this.Add(LoaiChungTuDev.GetLoaiChungTuDev(dr));
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
                foreach (LoaiChungTuDev deletedChild in DeletedList)
                    deletedChild.DeleteSelf(cn);
                DeletedList.Clear();

                // loop through each non-deleted child object
                foreach (LoaiChungTuDev child in this)
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
