
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{
    [Serializable()]
    public class ToKhaiThueGTGTGTList : Csla.BusinessListBase<ToKhaiThueGTGTGTList, ToKhaiThueGTGTGT>
    {

        #region Authorization Rules

        public static bool CanGetObject()
        {
            //TODO: Define CanGetObject permission in ToKhaiThueGTGTGTList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("ToKhaiThueGTGTGTListViewGroup"))
            //	return true;
            //return false;
        }

        public static bool CanAddObject()
        {
            //TODO: Define CanAddObject permission in ToKhaiThueGTGTGTList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("ToKhaiThueGTGTGTListAddGroup"))
            //	return true;
            //return false;
        }

        public static bool CanEditObject()
        {
            //TODO: Define CanEditObject permission in ToKhaiThueGTGTGTList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("ToKhaiThueGTGTGTListEditGroup"))
            //	return true;
            //return false;
        }

        public static bool CanDeleteObject()
        {
            //TODO: Define CanDeleteObject permission in ToKhaiThueGTGTGTList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("ToKhaiThueGTGTGTListDeleteGroup"))
            //	return true;
            //return false;
        }
        #endregion //Authorization Rules

        #region Factory Methods
        private ToKhaiThueGTGTGTList()
        { /* require use of factory method */ }

        public static ToKhaiThueGTGTGTList NewToKhaiThueGTGTGTList()
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a ToKhaiThueGTGTGTList");
            return new ToKhaiThueGTGTGTList();
        }

        public static ToKhaiThueGTGTGTList GetToKhaiThueGTGTGTList(int maky)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a ToKhaiThueGTGTGTList");
            return DataPortal.Fetch<ToKhaiThueGTGTGTList>(new FilterCriteria(maky));
        }
        #endregion //Factory Methods

        #region Data Access

        #region Filter Criteria
        [Serializable()]
        private class FilterCriteria
        {
            public int maky;
            public FilterCriteria(int maky)
            {
                this.maky=maky;
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
                cm.CommandText = "[spd_SelecttblToKhaiThueGTGTGianTiep]";
                cm.Parameters.AddWithValue("@maky", criteria.maky);

                using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                {
                    while (dr.Read())
                        this.Add(ToKhaiThueGTGTGT.GetToKhaiThueGTGTGT(dr));
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
                    foreach (ToKhaiThueGTGTGT deletedChild in DeletedList)
                        deletedChild.DeleteSelf(tr);
                    DeletedList.Clear();

                    // loop through each non-deleted child object
                    foreach (ToKhaiThueGTGTGT child in this)
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
