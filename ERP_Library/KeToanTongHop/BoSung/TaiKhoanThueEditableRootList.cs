using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{
    [Serializable()]
    public class TaiKhoanThueHList : Csla.BusinessListBase<TaiKhoanThueHList, TaiKhoanThueH>
    {
        #region BindingList Overrides
        protected override object AddNewCore()
        {
            TaiKhoanThueH item = TaiKhoanThueH.NewTaiKhoanThueH();
            this.Add(item);
            return item;
        }
        #endregion //BindingList Overrides

        #region Authorization Rules

        public static bool CanGetObject()
        {
            //TODO: Define CanGetObject permission in TaiKhoanThueHList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("TaiKhoanThueHListViewGroup"))
            //	return true;
            //return false;
        }

        public static bool CanAddObject()
        {
            //TODO: Define CanAddObject permission in TaiKhoanThueHList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("TaiKhoanThueHListAddGroup"))
            //	return true;
            //return false;
        }

        public static bool CanEditObject()
        {
            //TODO: Define CanEditObject permission in TaiKhoanThueHList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("TaiKhoanThueHListEditGroup"))
            //	return true;
            //return false;
        }

        public static bool CanDeleteObject()
        {
            //TODO: Define CanDeleteObject permission in TaiKhoanThueHList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("TaiKhoanThueHListDeleteGroup"))
            //	return true;
            //return false;
        }
        #endregion //Authorization Rules

        #region Factory Methods
        private TaiKhoanThueHList()
        { /* require use of factory method */ }

        public static TaiKhoanThueHList NewTaiKhoanThueHList()
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a TaiKhoanThueHList");
            return new TaiKhoanThueHList();
        }

        public static TaiKhoanThueHList GetTaiKhoanThueHList()
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a TaiKhoanThueHList");
            return DataPortal.Fetch<TaiKhoanThueHList>(new FilterCriteria());
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
                cm.CommandText = "spd_GetTaiKhoanThueHList";

                using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                {
                    while (dr.Read())
                        this.Add(TaiKhoanThueH.GetTaiKhoanThueH(dr));
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
                foreach (TaiKhoanThueH deletedChild in DeletedList)
                    deletedChild.DeleteSelf(cn);
                DeletedList.Clear();

                // loop through each non-deleted child object
                foreach (TaiKhoanThueH child in this)
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
