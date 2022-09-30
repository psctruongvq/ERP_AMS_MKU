
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{
    [Serializable()]
    public class CapPhatHoaDonList : Csla.BusinessListBase<CapPhatHoaDonList, CapPhatHoaDon>
    {
        #region BindingList Overrides
        protected override object AddNewCore()
        {
            CapPhatHoaDon item = CapPhatHoaDon.NewCapPhatHoaDon();
            this.Add(item);
            return item;
        }
        #endregion //BindingList Overrides

        #region Authorization Rules

        public static bool CanGetObject()
        {
            //TODO: Define CanGetObject permission in CapPhatHoaDonList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("CapPhatHoaDonListViewGroup"))
            //	return true;
            //return false;
        }

        public static bool CanAddObject()
        {
            //TODO: Define CanAddObject permission in CapPhatHoaDonList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("CapPhatHoaDonListAddGroup"))
            //	return true;
            //return false;
        }

        public static bool CanEditObject()
        {
            //TODO: Define CanEditObject permission in CapPhatHoaDonList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("CapPhatHoaDonListEditGroup"))
            //	return true;
            //return false;
        }

        public static bool CanDeleteObject()
        {
            //TODO: Define CanDeleteObject permission in CapPhatHoaDonList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("CapPhatHoaDonListDeleteGroup"))
            //	return true;
            //return false;
        }
        #endregion //Authorization Rules

        #region Factory Methods
        private CapPhatHoaDonList()
        { /* require use of factory method */ }

        public static CapPhatHoaDonList NewCapPhatHoaDonList()
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a CapPhatHoaDonList");
            return new CapPhatHoaDonList();
        }

        public static CapPhatHoaDonList GetCapPhatHoaDonList()
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a CapPhatHoaDonList");
            return DataPortal.Fetch<CapPhatHoaDonList>(new FilterCriteria());
        }
        public static CapPhatHoaDonList GetCapPhatHoaDonList(int mabophancap)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a CapPhatHoaDonList");
            return DataPortal.Fetch<CapPhatHoaDonList>(new FilterCriteriaByBoPhanCap(mabophancap));
        }
        public static CapPhatHoaDonList GetCapPhatHoaDonListMoiNhat(int mabophanduoccap)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a CapPhatHoaDonList");
            return DataPortal.Fetch<CapPhatHoaDonList>(new FilterCriteriaByBoPhanCapMoiNhat(mabophanduoccap));
        }
        public static CapPhatHoaDonList GetCapPhatHoaDonListSuDungMoiNhat(int mabophancap)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a CapPhatHoaDonList");
            return DataPortal.Fetch<CapPhatHoaDonList>(new FilterCriteriaByBoPhanCapSuDungMoiNhat(mabophancap));
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
        private class FilterCriteriaByBoPhanCap
        {
            public int mabophan;
            public FilterCriteriaByBoPhanCap(int mabophan)
            {
                this.mabophan = mabophan;
            }
        }
        private class FilterCriteriaByBoPhanCapMoiNhat
        {
            public int mabophan;
            public FilterCriteriaByBoPhanCapMoiNhat(int mabophan)
            {
                this.mabophan = mabophan;
            }
        }
        private class FilterCriteriaByBoPhanCapSuDungMoiNhat
        {
            public int mabophan;
            public FilterCriteriaByBoPhanCapSuDungMoiNhat(int mabophan)
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
                    cm.CommandText = "[spd_SelecttblCapSoHoaDonsAll]";
                }
                if (criteria is FilterCriteriaByBoPhanCap)
                {
                    cm.CommandText = "[spd_SelecttblCapSoHoaDonsAllByBoPhanCap]";
                    cm.Parameters.AddWithValue("@mabophancap", ((FilterCriteriaByBoPhanCap)criteria).mabophan);
                }
                if (criteria is FilterCriteriaByBoPhanCapMoiNhat)
                {
                    cm.CommandText = "[spd_SelecttblCapSoHoaDonsAllByBoPhanCapMoiNhat]";
                    cm.Parameters.AddWithValue("@mabophanduoccap", ((FilterCriteriaByBoPhanCapMoiNhat)criteria).mabophan);
                } if (criteria is FilterCriteriaByBoPhanCapSuDungMoiNhat)
                {
                    cm.CommandText = "[spd_SelecttblCapSoHoaDonsAllByBoPhanCapSuDungMoiNhat]";
                    cm.Parameters.AddWithValue("@mabophanduoccap", ((FilterCriteriaByBoPhanCapSuDungMoiNhat)criteria).mabophan);
                }
                using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                {
                    while (dr.Read())
                        this.Add(CapPhatHoaDon.GetCapPhatHoaDon(dr));
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
                    foreach (CapPhatHoaDon deletedChild in DeletedList)
                        deletedChild.DeleteSelf(tr);
                    DeletedList.Clear();

                    // loop through each non-deleted child object
                    foreach (CapPhatHoaDon child in this)
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
