
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{
    [Serializable()]
    public class PhuCapTayNgheList : Csla.BusinessListBase<PhuCapTayNgheList, PhuCapTayNghe>
    {
        #region BindingList Overrides
        protected override object AddNewCore()
        {
            PhuCapTayNghe item = PhuCapTayNghe.NewPhuCapTayNghe();
            this.Add(item);
            return item;
        }
        #endregion //BindingList Overrides

        #region Authorization Rules

        public static bool CanGetObject()
        {
            //TODO: Define CanGetObject permission in PhuCapTayNgheList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("PhuCapTayNgheListViewGroup"))
            //	return true;
            //return false;
        }

        public static bool CanAddObject()
        {
            //TODO: Define CanAddObject permission in PhuCapTayNgheList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("PhuCapTayNgheListAddGroup"))
            //	return true;
            //return false;
        }

        public static bool CanEditObject()
        {
            //TODO: Define CanEditObject permission in PhuCapTayNgheList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("PhuCapTayNgheListEditGroup"))
            //	return true;
            //return false;
        }

        public static bool CanDeleteObject()
        {
            //TODO: Define CanDeleteObject permission in PhuCapTayNgheList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("PhuCapTayNgheListDeleteGroup"))
            //	return true;
            //return false;
        }
        #endregion //Authorization Rules

        #region Factory Methods
        private PhuCapTayNgheList()
        { /* require use of factory method */ }

        public static PhuCapTayNgheList NewPhuCapTayNgheList()
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a PhuCapTayNgheList");
            return new PhuCapTayNgheList();
        }

        public static PhuCapTayNgheList GetPhuCapTayNgheList()
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a PhuCapTayNgheList");
            return DataPortal.Fetch<PhuCapTayNgheList>(new FilterCriteria());
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
               }
               catch (SqlException ex)
               {
                   HamDungChung.ThongBaoLoi(ex);
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
                cm.CommandText = "Spd_SelecttblnsPhucapTaynghesAll";
                using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                {
                    while (dr.Read())
                        this.Add(PhuCapTayNghe.GetPhuCapTayNghe(dr));
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
                    foreach (PhuCapTayNghe deletedChild in DeletedList)
                        deletedChild.DeleteSelf(tr);
                    DeletedList.Clear();

                    // loop through each non-deleted child object
                    foreach (PhuCapTayNghe child in this)
                    {
                        if (child.IsNew)
                            child.Insert(tr);
                        else
                            child.Update(tr);
                    }

                    tr.Commit();
                }
                catch (SqlException ex)
                {
                    tr.Rollback();
                    HamDungChung.ThongBaoLoi(ex);
                }
            }//using SqlConnection

            RaiseListChangedEvents = true;
        }
        #endregion //Data Access - Update
        #endregion //Data Access
    }
}
