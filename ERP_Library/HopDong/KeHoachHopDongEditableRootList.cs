
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{
    [Serializable()]
    public class KeHoachHopDongList : Csla.BusinessListBase<KeHoachHopDongList, KeHoachHopDong>
    {
        #region BindingList Overrides
        protected override object AddNewCore()
        {
            KeHoachHopDong item = KeHoachHopDong.NewKeHoachHopDong();
            this.Add(item);
            return item;
        }
        #endregion //BindingList Overrides

        #region Authorization Rules

        public static bool CanGetObject()
        {
            //TODO: Define CanGetObject permission in KeHoachHopDongList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("KeHoachHopDongListViewGroup"))
            //	return true;
            //return false;
        }

        public static bool CanAddObject()
        {
            //TODO: Define CanAddObject permission in KeHoachHopDongList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("KeHoachHopDongListAddGroup"))
            //	return true;
            //return false;
        }

        public static bool CanEditObject()
        {
            //TODO: Define CanEditObject permission in KeHoachHopDongList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("KeHoachHopDongListEditGroup"))
            //	return true;
            //return false;
        }

        public static bool CanDeleteObject()
        {
            //TODO: Define CanDeleteObject permission in KeHoachHopDongList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("KeHoachHopDongListDeleteGroup"))
            //	return true;
            //return false;
        }
        #endregion //Authorization Rules

        #region Factory Methods
        private KeHoachHopDongList()
        { /* require use of factory method */ }

        public static KeHoachHopDongList NewKeHoachHopDongList()
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a KeHoachHopDongList");
            return new KeHoachHopDongList();
        }

        public static KeHoachHopDongList GetKeHoachHopDongList()
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a KeHoachHopDongList");
            return DataPortal.Fetch<KeHoachHopDongList>(new FilterCriteria());
        }

        public static KeHoachHopDongList GetKeHoachHopDongList(int maBoPhan)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a KeHoachHopDongList");
            return DataPortal.Fetch<KeHoachHopDongList>(new FilterCriteria(maBoPhan));
        }
        #endregion //Factory Methods

        #region Data Access

        #region Filter Criteria
        [Serializable()]
        private class FilterCriteria
        {
            public int MaBoPhan;

            public FilterCriteria()
            {

            }
            public FilterCriteria(int maBoPhan)
            {
                MaBoPhan = maBoPhan;
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
                if (criteria.MaBoPhan == 0)
                {
                    cm.CommandText = "spd_SelecttblKeHoachHopDongsAll";
                }
                else
                {
                    cm.CommandText = "spd_SelecttblKeHoachHopDongsAll_byMaBoPhan";
                    cm.Parameters.AddWithValue("@MaBoPhan", criteria.MaBoPhan);
                }


                using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                {
                    while (dr.Read())
                        this.Add(KeHoachHopDong.GetKeHoachHopDong(dr));
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
                    foreach (KeHoachHopDong deletedChild in DeletedList)
                        deletedChild.DeleteSelf(tr);
                    DeletedList.Clear();

                    // loop through each non-deleted child object
                    foreach (KeHoachHopDong child in this)
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
