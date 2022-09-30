﻿
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{
    [Serializable()]
    public class DonViTinhBQ_VTList : Csla.BusinessListBase<DonViTinhBQ_VTList, DonViTinhBQ_VT>
    {
        #region BindingList Overrides
        protected override object AddNewCore()
        {
            DonViTinhBQ_VT item = DonViTinhBQ_VT.NewDonViTinhBQ_VT();
            this.Add(item);
            return item;
        }
        #endregion //BindingList Overrides

        #region Authorization Rules

        public static bool CanGetObject()
        {
            //TODO: Define CanGetObject permission in DonViTinhBQ_VTList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("DonViTinhBQ_VTListViewGroup"))
            //	return true;
            //return false;
        }

        public static bool CanAddObject()
        {
            //TODO: Define CanAddObject permission in DonViTinhBQ_VTList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("DonViTinhBQ_VTListAddGroup"))
            //	return true;
            //return false;
        }

        public static bool CanEditObject()
        {
            //TODO: Define CanEditObject permission in DonViTinhBQ_VTList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("DonViTinhBQ_VTListEditGroup"))
            //	return true;
            //return false;
        }

        public static bool CanDeleteObject()
        {
            //TODO: Define CanDeleteObject permission in DonViTinhBQ_VTList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("DonViTinhBQ_VTListDeleteGroup"))
            //	return true;
            //return false;
        }
        #endregion //Authorization Rules

        #region Factory Methods
        private DonViTinhBQ_VTList()
        { /* require use of factory method */ }

        public static DonViTinhBQ_VTList NewDonViTinhBQ_VTList()
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a DonViTinhBQ_VTList");
            return new DonViTinhBQ_VTList();
        }

        public static DonViTinhBQ_VTList GetDonViTinhBQ_VTList()
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a DonViTinhBQ_VTList");
            return DataPortal.Fetch<DonViTinhBQ_VTList>(new FilterCriteria());
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
                cm.CommandText = "spd_SelecttblDonViTinhsAll";


                using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                {
                    while (dr.Read())
                        this.Add(DonViTinhBQ_VT.GetDonViTinhBQ_VT(dr));
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
                    foreach (DonViTinhBQ_VT deletedChild in DeletedList)
                        deletedChild.DeleteSelf(tr);
                    DeletedList.Clear();

                    // loop through each non-deleted child object
                    foreach (DonViTinhBQ_VT child in this)
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
