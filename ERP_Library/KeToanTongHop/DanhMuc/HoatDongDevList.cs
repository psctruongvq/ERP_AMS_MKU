using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{
    [Serializable()]
    public class HoatDongDevList : Csla.BusinessListBase<HoatDongDevList, HoatDongDev>
    {
        #region BindingList Overrides
        protected override object AddNewCore()
        {
            HoatDongDev item = HoatDongDev.NewHoatDongDev();
            this.Add(item);
            return item;
        }
        #endregion //BindingList Overrides

        #region Authorization Rules

        public static bool CanGetObject()
        {
            //TODO: Define CanGetObject permission in HoatDongDevList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("HoatDongDevListViewGroup"))
            //	return true;
            //return false;
        }

        public static bool CanAddObject()
        {
            //TODO: Define CanAddObject permission in HoatDongDevList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("HoatDongDevListAddGroup"))
            //	return true;
            //return false;
        }

        public static bool CanEditObject()
        {
            //TODO: Define CanEditObject permission in HoatDongDevList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("HoatDongDevListEditGroup"))
            //	return true;
            //return false;
        }

        public static bool CanDeleteObject()
        {
            //TODO: Define CanDeleteObject permission in HoatDongDevList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("HoatDongDevListDeleteGroup"))
            //	return true;
            //return false;
        }
        #endregion //Authorization Rules

        #region Factory Methods
        private HoatDongDevList()
        { /* require use of factory method */ }

        public static HoatDongDevList NewHoatDongDevList()
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a HoatDongDevList");
            return new HoatDongDevList();
        }

        public static HoatDongDevList GetHoatDongDevList(int maCongTy)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a HoatDongDevList");
            return DataPortal.Fetch<HoatDongDevList>(new FilterCriteria(maCongTy));
        }
        #endregion //Factory Methods

        #region Data Access

        #region Filter Criteria
        [Serializable()]
        private class FilterCriteria
        {
            public int MaCongTy;
            public FilterCriteria(int maCongTy)
            {
                MaCongTy = maCongTy;
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
                cm.CommandText = "spd_SelecttblHoatDongDevsAll";
                cm.Parameters.AddWithValue("@MaCongTy", criteria.MaCongTy);

                using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                {
                    while (dr.Read())
                        this.Add(HoatDongDev.GetHoatDongDev(dr));
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
                foreach (HoatDongDev deletedChild in DeletedList)
                    deletedChild.DeleteSelf(cn);
                DeletedList.Clear();

                // loop through each non-deleted child object
                foreach (HoatDongDev child in this)
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
