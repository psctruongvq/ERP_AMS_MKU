
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{
    [Serializable()]
    public class DieuChinhBoSungList : Csla.BusinessListBase<DieuChinhBoSungList, DieuChinhBoSung>
    {
        #region BindingList Overrides
        protected override object AddNewCore()
        {
            DieuChinhBoSung item = DieuChinhBoSung.NewDieuChinhBoSung();
            this.Add(item);
            return item;
        }
        #endregion //BindingList Overrides

        #region Authorization Rules

        public static bool CanGetObject()
        {
            //TODO: Define CanGetObject permission in DieuChinhBoSungList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("DieuChinhBoSungListViewGroup"))
            //	return true;
            //return false;
        }

        public static bool CanAddObject()
        {
            //TODO: Define CanAddObject permission in DieuChinhBoSungList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("DieuChinhBoSungListAddGroup"))
            //	return true;
            //return false;
        }

        public static bool CanEditObject()
        {
            //TODO: Define CanEditObject permission in DieuChinhBoSungList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("DieuChinhBoSungListEditGroup"))
            //	return true;
            //return false;
        }

        public static bool CanDeleteObject()
        {
            //TODO: Define CanDeleteObject permission in DieuChinhBoSungList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("DieuChinhBoSungListDeleteGroup"))
            //	return true;
            //return false;
        }
        #endregion //Authorization Rules

        #region Factory Methods
        private DieuChinhBoSungList()
        { /* require use of factory method */ }

        public static DieuChinhBoSungList NewDieuChinhBoSungList()
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a DieuChinhBoSungList");
            return new DieuChinhBoSungList();
        }

        public static DieuChinhBoSungList GetDieuChinhBoSungList(int Nam)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not autha DieuChinhBoSungList");
            return DataPortal.Fetch<DieuChinhBoSungList>(new FilterCriteria(Nam));
        }
        #endregion //Factory Methods

        #region Data Access

        #region Filter Criteria
        [Serializable()]
        private class FilterCriteria
        {
            public int Nam;

            public FilterCriteria(int nam)
            {
                this.Nam = nam;
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
                cm.CommandText = "spd_SelecttblDieuChinhBoSungsAll";
                cm.Parameters.AddWithValue("@Nam", criteria.Nam);
                cm.Parameters.AddWithValue("@UserID", ERP_Library.Security.CurrentUser.Info.UserID);

                using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                {
                    while (dr.Read())
                        this.Add(DieuChinhBoSung.GetDieuChinhBoSung(dr));
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
                    foreach (DieuChinhBoSung deletedChild in DeletedList)
                        deletedChild.DeleteSelf(tr);
                    DeletedList.Clear();

                    // loop through each non-deleted child object
                    foreach (DieuChinhBoSung child in this)
                    {
                        if (child.IsNew)
                            child.Insert(tr, this);
                        else
                            child.Update(tr, this);
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
