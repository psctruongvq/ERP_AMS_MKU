
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{
    [Serializable()]
    public class InLoatHDLDList : Csla.BusinessListBase<InLoatHDLDList, InLoatHDLD>
    {
        #region BindingList Overrides
        protected override object AddNewCore()
        {
            InLoatHDLD item = InLoatHDLD.NewInLoatHDLD();
            this.Add(item);
            return item;
        }
        #endregion //BindingList Overrides

        #region Authorization Rules

        public static bool CanGetObject()
        {
            //TODO: Define CanGetObject permission in InLoatHDLDList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("InLoatHDLDListViewGroup"))
            //	return true;
            //return false;
        }

        public static bool CanAddObject()
        {
            //TODO: Define CanAddObject permission in InLoatHDLDList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("InLoatHDLDListAddGroup"))
            //	return true;
            //return false;
        }

        public static bool CanEditObject()
        {
            //TODO: Define CanEditObject permission in InLoatHDLDList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("InLoatHDLDListEditGroup"))
            //	return true;
            //return false;
        }

        public static bool CanDeleteObject()
        {
            //TODO: Define CanDeleteObject permission in InLoatHDLDList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("InLoatHDLDListDeleteGroup"))
            //	return true;
            //return false;
        }
        #endregion //Authorization Rules

        #region Factory Methods
        private InLoatHDLDList()
        { /* require use of factory method */ }

        public static InLoatHDLDList NewInLoatHDLDList()
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a InLoatHDLDList");
            return new InLoatHDLDList();
        }

        public static InLoatHDLDList GetInLoatHDLDList()
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a InLoatHDLDList");
            return DataPortal.Fetch<InLoatHDLDList>(new FilterCriteria());
        }
        public static InLoatHDLDList GetInLoatHDLDListbybophan(int mabophan)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a InLoatHDLDList");
            return DataPortal.Fetch<InLoatHDLDList>(new FilterCriteriabybophan(mabophan));
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
        private class FilterCriteriabybophan
        {
            public int mabophan;
            public FilterCriteriabybophan(int mabophan)
            {
                this.mabophan = mabophan;
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
                catch (SqlException ex)
                {
                    tr.Rollback();
                    HamDungChung.ThongBaoLoi(ex);
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
                {
                    cm.CommandText = "spd_SelecttblnsInLoatHDLDsAll";
                }
                else if (criteria is FilterCriteriabybophan)
                {
                    cm.CommandText = "spd_SelecttblnsInLoatHDLDbybophan";
                    cm.Parameters.AddWithValue("@mabophan", ((FilterCriteriabybophan)criteria).mabophan);
                }

                using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                {
                    while (dr.Read())
                        this.Add(InLoatHDLD.GetInLoatHDLD(dr));
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
                    foreach (InLoatHDLD deletedChild in DeletedList)
                        deletedChild.DeleteSelf(tr);
                    DeletedList.Clear();

                    // loop through each non-deleted child object
                    foreach (InLoatHDLD child in this)
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
