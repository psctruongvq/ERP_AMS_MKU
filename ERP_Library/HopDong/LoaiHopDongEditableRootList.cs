
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{
    [Serializable()]
    public class LoaiHopDongList : Csla.BusinessListBase<LoaiHopDongList, LoaiHopDong>
    {
        #region BindingList Overrides
        protected override object AddNewCore()
        {
            LoaiHopDong item = LoaiHopDong.NewLoaiHopDong();
            this.Add(item);
            return item;
        }
        #endregion //BindingList Overrides

        #region Authorization Rules

        public static bool CanGetObject()
        {
            //TODO: Define CanGetObject permission in LoaiHopDongList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("LoaiHopDongListViewGroup"))
            //	return true;
            //return false;
        }

        public static bool CanAddObject()
        {
            //TODO: Define CanAddObject permission in LoaiHopDongList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("LoaiHopDongListAddGroup"))
            //	return true;
            //return false;
        }

        public static bool CanEditObject()
        {
            //TODO: Define CanEditObject permission in LoaiHopDongList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("LoaiHopDongListEditGroup"))
            //	return true;
            //return false;
        }

        public static bool CanDeleteObject()
        {
            //TODO: Define CanDeleteObject permission in LoaiHopDongList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("LoaiHopDongListDeleteGroup"))
            //	return true;
            //return false;
        }
        #endregion //Authorization Rules

        #region Factory Methods
        private LoaiHopDongList()
        { /* require use of factory method */ }

        public static LoaiHopDongList NewLoaiHopDongList()
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a LoaiHopDongList");
            return new LoaiHopDongList();
        }

        public static LoaiHopDongList GetLoaiHopDongList()
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a LoaiHopDongList");
            return DataPortal.Fetch<LoaiHopDongList>(new FilterCriteria());
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
                cm.CommandText = "spd_SelectAll_LoaiHopDong";


                using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                {
                    while (dr.Read())
                        this.Add(LoaiHopDong.GetLoaiHopDong(dr));
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
                    foreach (LoaiHopDong deletedChild in DeletedList)
                        deletedChild.DeleteSelf(tr);
                    DeletedList.Clear();

                    // loop through each non-deleted child object
                    foreach (LoaiHopDong child in this)
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

