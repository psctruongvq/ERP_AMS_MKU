
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{
    [Serializable()]
    public class NhomNganHangList : Csla.BusinessListBase<NhomNganHangList, NhomNganHang>
    {
        #region BindingList Overrides
        protected override object AddNewCore()
        {
            NhomNganHang item = NhomNganHang.NewNhomNganHang();
            this.Add(item);
            return item;
        }
        #endregion //BindingList Overrides

        #region Authorization Rules

        public static bool CanGetObject()
        {
            //TODO: Define CanGetObject permission in NhomNganHangList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("NhomNganHangListViewGroup"))
            //	return true;
            //return false;
        }

        public static bool CanAddObject()
        {
            //TODO: Define CanAddObject permission in NhomNganHangList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("NhomNganHangListAddGroup"))
            //	return true;
            //return false;
        }

        public static bool CanEditObject()
        {
            //TODO: Define CanEditObject permission in NhomNganHangList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("NhomNganHangListEditGroup"))
            //	return true;
            //return false;
        }

        public static bool CanDeleteObject()
        {
            //TODO: Define CanDeleteObject permission in NhomNganHangList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("NhomNganHangListDeleteGroup"))
            //	return true;
            //return false;
        }
        #endregion //Authorization Rules

        #region Factory Methods
        private NhomNganHangList()
        { /* require use of factory method */ }

        public static NhomNganHangList NewNhomNganHangList()
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a NhomNganHangList");
            return new NhomNganHangList();
        }

        public static NhomNganHangList GetNhomNganHangList()
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a NhomNganHangList");
            return DataPortal.Fetch<NhomNganHangList>(new FilterCriteria());
        }

        public NhomNganHangList GetNhomNganHangList(string ten)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a NhomNganHangList");
            return DataPortal.Fetch<NhomNganHangList>(new FilterCriteriaTen(ten));
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

        private class FilterCriteriaTen
        {
            public string Ten = "";

            public FilterCriteriaTen(string ten)
            {
                Ten = ten;

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
                {
                    cm.CommandText = "spd_SelecttblnsNhomNganHangsAll";
                }

                if (criteria is FilterCriteriaTen)
                {
                    cm.CommandText = "spd_SelecttblnsNhomNganHangsByTen";
                    cm.Parameters.AddWithValue("@ten", ((FilterCriteriaTen)criteria).Ten);
                }

                using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                {
                    while (dr.Read())
                        this.Add(NhomNganHang.GetNhomNganHang(dr));
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
                    foreach (NhomNganHang deletedChild in DeletedList)
                        deletedChild.DeleteSelf(tr);
                    DeletedList.Clear();

                    // loop through each non-deleted child object
                    foreach (NhomNganHang child in this)
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
