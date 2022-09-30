
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{
    [Serializable()]
    public class LuuTruCapPhatHoaDonList : Csla.BusinessListBase<LuuTruCapPhatHoaDonList, LuuTruCapPhatHoaDon>
    {
        #region BindingList Overrides
        protected override object AddNewCore()
        {
            LuuTruCapPhatHoaDon item = LuuTruCapPhatHoaDon.NewLuuTruCapPhatHoaDon();
            this.Add(item);
            return item;
        }
        #endregion //BindingList Overrides

        #region Authorization Rules

        public static bool CanGetObject()
        {
            //TODO: Define CanGetObject permission in LuuTruCapPhatHoaDonList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("LuuTruCapPhatHoaDonListViewGroup"))
            //	return true;
            //return false;
        }

        public static bool CanAddObject()
        {
            //TODO: Define CanAddObject permission in LuuTruCapPhatHoaDonList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("LuuTruCapPhatHoaDonListAddGroup"))
            //	return true;
            //return false;
        }

        public static bool CanEditObject()
        {
            //TODO: Define CanEditObject permission in LuuTruCapPhatHoaDonList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("LuuTruCapPhatHoaDonListEditGroup"))
            //	return true;
            //return false;
        }

        public static bool CanDeleteObject()
        {
            //TODO: Define CanDeleteObject permission in LuuTruCapPhatHoaDonList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("LuuTruCapPhatHoaDonListDeleteGroup"))
            //	return true;
            //return false;
        }
        #endregion //Authorization Rules

        #region Factory Methods
        private LuuTruCapPhatHoaDonList()
        { /* require use of factory method */ }

        public static LuuTruCapPhatHoaDonList NewLuuTruCapPhatHoaDonList()
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a LuuTruCapPhatHoaDonList");
            return new LuuTruCapPhatHoaDonList();
        }

        public static LuuTruCapPhatHoaDonList GetLuuTruCapPhatHoaDonList()
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a LuuTruCapPhatHoaDonList");
            return DataPortal.Fetch<LuuTruCapPhatHoaDonList>(new FilterCriteria());
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
                cm.CommandText = "[spd_SelecttblLuuTruHoaDonsAll]";


                using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                {
                    while (dr.Read())
                        this.Add(LuuTruCapPhatHoaDon.GetLuuTruCapPhatHoaDon(dr));
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
                    foreach (LuuTruCapPhatHoaDon deletedChild in DeletedList)
                        deletedChild.DeleteSelf(tr);
                    DeletedList.Clear();

                    // loop through each non-deleted child object
                    foreach (LuuTruCapPhatHoaDon child in this)
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
