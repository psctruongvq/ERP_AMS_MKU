
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{
    [Serializable()]
    public class GiaHanHopDongList : Csla.BusinessListBase<GiaHanHopDongList, GiaHanHopDong>
    {
        #region BindingList Overrides
        protected override object AddNewCore()
        {
            GiaHanHopDong item = GiaHanHopDong.NewGiaHanHopDong();
            this.Add(item);
            return item;
        }
        #endregion //BindingList Overrides

        #region Authorization Rules

        public static bool CanGetObject()
        {
            //TODO: Define CanGetObject permission in GiaHanHopDongList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("GiaHanHopDongListViewGroup"))
            //	return true;
            //return false;
        }

        public static bool CanAddObject()
        {
            //TODO: Define CanAddObject permission in GiaHanHopDongList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("GiaHanHopDongListAddGroup"))
            //	return true;
            //return false;
        }

        public static bool CanEditObject()
        {
            //TODO: Define CanEditObject permission in GiaHanHopDongList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("GiaHanHopDongListEditGroup"))
            //	return true;
            //return false;
        }

        public static bool CanDeleteObject()
        {
            //TODO: Define CanDeleteObject permission in GiaHanHopDongList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("GiaHanHopDongListDeleteGroup"))
            //	return true;
            //return false;
        }
        #endregion //Authorization Rules

        #region Factory Methods
        private GiaHanHopDongList()
        { /* require use of factory method */ }

        public static GiaHanHopDongList NewGiaHanHopDongList()
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a GiaHanHopDongList");
            return new GiaHanHopDongList();
        }

        public static GiaHanHopDongList GetGiaHanHopDongList(long maHopDongLaoDong)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a GiaHanHopDongList");
            return DataPortal.Fetch<GiaHanHopDongList>(new FilterCriteria(maHopDongLaoDong));
        }

        public static GiaHanHopDongList GetGiaHanHopDongByBoPhan(int mabophan)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a GiaHanHopDongList");
            return DataPortal.Fetch<GiaHanHopDongList>(new FilterCriteriaByBoPhan(mabophan));
        }
        public static GiaHanHopDongList GetGiaHanHopDongByNhanVien(long manhanvien)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a GiaHanHopDongList");
            return DataPortal.Fetch<GiaHanHopDongList>(new FilterCriteriaByNhanVien(manhanvien));
        }
        #endregion //Factory Methods

        #region Data Access

        #region Filter Criteria
        [Serializable()]
        private class FilterCriteria
        {
            public long MaHopDongLaoDong;

            public FilterCriteria(long maHopDongLaoDong)
            {
                this.MaHopDongLaoDong = maHopDongLaoDong;
            }
        }
        private class FilterCriteriaByBoPhan
        {
            public int Mabophan;

            public FilterCriteriaByBoPhan(int Mabophan)
            {
                this.Mabophan = Mabophan;
            }
        }
        private class FilterCriteriaByNhanVien
        {
            public long manhanvien;
            public FilterCriteriaByNhanVien(long manhanvien)
            {
                this.manhanvien = manhanvien;
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
                    cm.CommandText = "spd_SelecttblnsGiaHanHopDongsAll";
                    cm.Parameters.AddWithValue("@MaHopDongLaoDong", ((FilterCriteria)criteria).MaHopDongLaoDong);
                }
                if (criteria is FilterCriteriaByBoPhan)
                {
                    cm.CommandText = "spd_SelecttblnsGiaHanHopDongsAllByBoPhan";
                    cm.Parameters.AddWithValue("@Mabophan", ((FilterCriteriaByBoPhan)criteria).Mabophan);
                }
                if (criteria is FilterCriteriaByNhanVien)
                {
                    cm.CommandText = "spd_SelecttblnsGiaHanHopDongsAllByNhanVien";
                    cm.Parameters.AddWithValue("@Manhanvien", ((FilterCriteriaByNhanVien)criteria).manhanvien);
                }
                using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                {
                    while (dr.Read())
                        this.Add(GiaHanHopDong.GetGiaHanHopDong(dr));
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
                    foreach (GiaHanHopDong deletedChild in DeletedList)
                        deletedChild.DeleteSelf(tr);
                    DeletedList.Clear();

                    // loop through each non-deleted child object
                    foreach (GiaHanHopDong child in this)
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
