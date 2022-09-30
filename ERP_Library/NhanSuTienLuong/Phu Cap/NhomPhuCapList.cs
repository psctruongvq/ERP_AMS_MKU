
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{
    [Serializable()]
    public class NhomPhuCapList : Csla.BusinessListBase<NhomPhuCapList, NhomPhuCap>
    {
        #region BindingList Overrides

        private int iddef = -1;
        protected override object AddNewCore()
        {
            NhomPhuCap item = NhomPhuCap.NewNhomPhuCapChild();
            item._maNhom = iddef--;
            this.Add(item);
            return item;
        }
        #endregion //BindingList Overrides

        #region Authorization Rules

        public static bool CanGetObject()
        {
            //TODO: Define CanGetObject permission in NhomPhuCapList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("NhomPhuCapListViewGroup"))
            //	return true;
            //return false;
        }

        public static bool CanAddObject()
        {
            //TODO: Define CanAddObject permission in NhomPhuCapList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("NhomPhuCapListAddGroup"))
            //	return true;
            //return false;
        }

        public static bool CanEditObject()
        {
            //TODO: Define CanEditObject permission in NhomPhuCapList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("NhomPhuCapListEditGroup"))
            //	return true;
            //return false;
        }

        public static bool CanDeleteObject()
        {
            //TODO: Define CanDeleteObject permission in NhomPhuCapList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("NhomPhuCapListDeleteGroup"))
            //	return true;
            //return false;
        }
        #endregion //Authorization Rules

        #region Factory Methods
        private NhomPhuCapList()
        { /* require use of factory method */ }

        public static NhomPhuCapList NewNhomPhuCapList()
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a NhomPhuCapList");
            return new NhomPhuCapList();
        }

        public static NhomPhuCapList GetNhomPhuCapList()
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a NhomPhuCapList");
            return DataPortal.Fetch<NhomPhuCapList>(new FilterCriteria());
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
                cm.CommandText = "sp_NhomPCSelecttblnsPC_NhomPhuCapsAll";
                cm.Parameters.AddWithValue("@UserID", Security.CurrentUser.Info.UserID);

                using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                {
                    while (dr.Read())
                        this.Add(NhomPhuCap.GetNhomPhuCap(dr));
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
                    foreach (NhomPhuCap deletedChild in DeletedList)
                        deletedChild.DeleteSelf(tr);
                    DeletedList.Clear();

                    // loop through each non-deleted child object
                    foreach (NhomPhuCap child in this)
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
