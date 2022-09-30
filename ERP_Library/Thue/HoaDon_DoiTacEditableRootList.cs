
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{
    [Serializable()]
    public class HoaDon_DoiTacList : Csla.BusinessListBase<HoaDon_DoiTacList, HoaDon_DoiTac>
    {
        #region BindingList Overrides
        protected override object AddNewCore()
        {
            HoaDon_DoiTac item = HoaDon_DoiTac.NewHoaDon_DoiTac();
            this.Add(item);
            return item;
        }
        #endregion //BindingList Overrides

        #region Authorization Rules

        public static bool CanGetObject()
        {
            //TODO: Define CanGetObject permission in HoaDon_DoiTacList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("HoaDon_DoiTacListViewGroup"))
            //	return true;
            //return false;
        }

        public static bool CanAddObject()
        {
            //TODO: Define CanAddObject permission in HoaDon_DoiTacList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("HoaDon_DoiTacListAddGroup"))
            //	return true;
            //return false;
        }

        public static bool CanEditObject()
        {
            //TODO: Define CanEditObject permission in HoaDon_DoiTacList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("HoaDon_DoiTacListEditGroup"))
            //	return true;
            //return false;
        }

        public static bool CanDeleteObject()
        {
            //TODO: Define CanDeleteObject permission in HoaDon_DoiTacList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("HoaDon_DoiTacListDeleteGroup"))
            //	return true;
            //return false;
        }
        #endregion //Authorization Rules

        #region Factory Methods
        private HoaDon_DoiTacList()
        { /* require use of factory method */ }

        public static HoaDon_DoiTacList NewHoaDon_DoiTacList()
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a HoaDon_DoiTacList");
            return new HoaDon_DoiTacList();
        }

        public static HoaDon_DoiTacList GetHoaDon_DoiTacList()
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a HoaDon_DoiTacList");
            return DataPortal.Fetch<HoaDon_DoiTacList>(new FilterCriteria());
        }

        public static HoaDon_DoiTacList GetHoaDon_DoiTacList(DateTime tungay, DateTime denngay, int mabophan)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a HoaDon_DoiTacList");
            return DataPortal.Fetch<HoaDon_DoiTacList>(new FilterCriteriaBYNgay(tungay, denngay, mabophan));
        }

        public static HoaDon_DoiTacList GetHoaDon_DoiTacList(long mahoadon)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a HoaDon_DoiTacList");
            return DataPortal.Fetch<HoaDon_DoiTacList>(new FilterCriteriaBYHD( mahoadon));
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
        private class FilterCriteriaBYNgay
        {
            public DateTime tungay;
            public DateTime denngay;
            public int mabophan;
            public FilterCriteriaBYNgay(DateTime tungay, DateTime denngay, int mabophan)
            {
                this.denngay = denngay;
                this.tungay = tungay;
                this.mabophan = mabophan;
            }
        }
        private class FilterCriteriaBYHD
        {
            public long mahoadon;
            public FilterCriteriaBYHD( long mahoadon)
            {
                this.mahoadon = mahoadon;
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
                    cm.CommandText = "GetHoaDon_DoiTacList";
                }
                else if (criteria is FilterCriteriaBYNgay)
                {
                    cm.CommandText = "spd_SelectHoaDon_DoiTacListByNgay";
                    cm.Parameters.AddWithValue("@tungay", ((FilterCriteriaBYNgay)criteria).tungay);
                    cm.Parameters.AddWithValue("@denngay", ((FilterCriteriaBYNgay)criteria).denngay);
                    cm.Parameters.AddWithValue("@mabophan", ((FilterCriteriaBYNgay)criteria).mabophan);
                }
                else if (criteria is FilterCriteriaBYHD)
                {
                    cm.CommandText = "spd_SelectHoaDon_DoiTacListByHD";
                    cm.Parameters.AddWithValue("@mahoadon", ((FilterCriteriaBYHD)criteria).mahoadon);
                }

                using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                {
                    while (dr.Read())
                        this.Add(HoaDon_DoiTac.GetHoaDon_DoiTac(dr));
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
                    foreach (HoaDon_DoiTac deletedChild in DeletedList)
                        deletedChild.DeleteSelf(tr);
                    DeletedList.Clear();

                    // loop through each non-deleted child object
                    foreach (HoaDon_DoiTac child in this)
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
