
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library.Security
{
    [Serializable()]
    public class MenuList : Csla.BusinessListBase<MenuList, MenuItem>
    {

        #region BindingList Overrides
        protected override object AddNewCore()
        {
            //tìm số id max, và stt
            int idmax = 0;
            foreach (MenuItem i in this)
                if (idmax <= i.MaChucNang)
                    idmax = i.MaChucNang + 1;
            MenuItem item = MenuItem.NewMenuItemChild(idmax);
            this.Add(item);
            return item;
        }
        #endregion //BindingList Overrides

        #region Factory Methods
        private MenuList()
        { /* require use of factory method */ }

        public static MenuList NewMenuList()
        {
            return new MenuList();
        }

        public static MenuList GetMenuList()
        {
            return DataPortal.Fetch<MenuList>(new FilterCriteria());
        }

        public static MenuList GetMenuUser(int UserID)
        {
            return DataPortal.Fetch<MenuList>(new FilterUserID(UserID));
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
        private class FilterUserID
        {
            public int UserID;
            public FilterUserID(int userID)
            {
                UserID = userID;
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
                    cm.CommandText = "app_Select_MenuList";
                else
                {
                    cm.CommandText = "app_Select_MenuUser";
                    cm.Parameters.AddWithValue("@UserID", ((FilterUserID)criteria).UserID);
                }

                using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                {
                    while (dr.Read())
                        this.Add(MenuItem.GetMenuItem(dr));
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
                    foreach (MenuItem deletedChild in DeletedList)
                        deletedChild.DeleteSelf(tr);
                    DeletedList.Clear();

                    // loop through each non-deleted child object
                    foreach (MenuItem child in this)
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
