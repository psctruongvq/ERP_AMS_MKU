
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{
    [Serializable()]
    public class PhuCapTrachNhiemList : Csla.BusinessListBase<PhuCapTrachNhiemList, PhuCapTrachNhiem>
    {

        #region Authorization Rules

        public static bool CanGetObject()
        {
            //TODO: Define CanGetObject permission in PhuCapTrachNhiemList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("PhuCapTrachNhiemListViewGroup"))
            //	return true;
            //return false;
        }

        public static bool CanAddObject()
        {
            //TODO: Define CanAddObject permission in PhuCapTrachNhiemList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("PhuCapTrachNhiemListAddGroup"))
            //	return true;
            //return false;
        }

        public static bool CanEditObject()
        {
            //TODO: Define CanEditObject permission in PhuCapTrachNhiemList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("PhuCapTrachNhiemListEditGroup"))
            //	return true;
            //return false;
        }

        public static bool CanDeleteObject()
        {
            //TODO: Define CanDeleteObject permission in PhuCapTrachNhiemList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("PhuCapTrachNhiemListDeleteGroup"))
            //	return true;
            //return false;
        }
        #endregion //Authorization Rules

        #region Factory Methods
        private PhuCapTrachNhiemList()
        { /* require use of factory method */ }

        public static PhuCapTrachNhiemList NewPhuCapTrachNhiemList()
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a PhuCapTrachNhiemList");
            return new PhuCapTrachNhiemList();
        }
        public static PhuCapTrachNhiemList GetPhuCapTrachNhiemList()
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a PhuCapTrachNhiemList");
            return DataPortal.Fetch<PhuCapTrachNhiemList>(new FilterCriteria());
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
                catch (SqlException ex)
                {
                    tr.Rollback();
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
                cm.CommandText = "spd_selecttblnsphucaptrachnhiemsAll";      

                using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                {
                    while (dr.Read())
                        this.Add(PhuCapTrachNhiem.GetPhuCapTrachNhiem(dr));
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
                    foreach (PhuCapTrachNhiem deletedChild in DeletedList)
                        deletedChild.DeleteSelf(tr);
                    DeletedList.Clear();

                    // loop through each non-deleted child object
                    foreach (PhuCapTrachNhiem child in this)
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
