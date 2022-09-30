
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{
    [Serializable()]
    public class KhoiSanXuatList : Csla.BusinessListBase<KhoiSanXuatList, KhoiSanXuat>
    {
        #region BindingList Overrides
        protected override object AddNewCore()
        {
            KhoiSanXuat item = KhoiSanXuat.NewKhoiSanXuat();
            this.Add(item);
            return item;
        }
        #endregion //BindingList Overrides

        #region Authorization Rules

        public static bool CanGetObject()
        {
            //TODO: Define CanGetObject permission in KhoiSanXuatList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("KhoiSanXuatListViewGroup"))
            //	return true;
            //return false;
        }

        public static bool CanAddObject()
        {
            //TODO: Define CanAddObject permission in KhoiSanXuatList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("KhoiSanXuatListAddGroup"))
            //	return true;
            //return false;
        }

        public static bool CanEditObject()
        {
            //TODO: Define CanEditObject permission in KhoiSanXuatList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("KhoiSanXuatListEditGroup"))
            //	return true;
            //return false;
        }

        public static bool CanDeleteObject()
        {
            //TODO: Define CanDeleteObject permission in KhoiSanXuatList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("KhoiSanXuatListDeleteGroup"))
            //	return true;
            //return false;
        }
        #endregion //Authorization Rules

        #region Factory Methods
        private KhoiSanXuatList()
        { /* require use of factory method */ }

        public static KhoiSanXuatList NewKhoiSanXuatList()
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a KhoiSanXuatList");
            return new KhoiSanXuatList();
        }

        public static KhoiSanXuatList GetKhoiSanXuatList()
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a KhoiSanXuatList");
            return DataPortal.Fetch<KhoiSanXuatList>(new FilterCriteria());
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
                cm.CommandText = "spd_SelecttblnsKhoiSanxuatAll";


                using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                {
                    while (dr.Read())
                        this.Add(KhoiSanXuat.GetKhoiSanXuat(dr));
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
                    foreach (KhoiSanXuat deletedChild in DeletedList)
                        deletedChild.DeleteSelf(tr);
                    DeletedList.Clear();

                    // loop through each non-deleted child object
                    foreach (KhoiSanXuat child in this)
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
