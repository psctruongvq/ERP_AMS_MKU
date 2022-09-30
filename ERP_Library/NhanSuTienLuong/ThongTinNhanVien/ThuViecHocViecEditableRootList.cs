
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{
    [Serializable()]
    public class ThuViecHocViecList : Csla.BusinessListBase<ThuViecHocViecList, ThuViecHocViec>
    {

        #region Authorization Rules

        public static bool CanGetObject()
        {
            //TODO: Define CanGetObject permission in ThuViecHocViecList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("ThuViecHocViecListViewGroup"))
            //	return true;
            //return false;
        }

        public static bool CanAddObject()
        {
            //TODO: Define CanAddObject permission in ThuViecHocViecList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("ThuViecHocViecListAddGroup"))
            //	return true;
            //return false;
        }

        public static bool CanEditObject()
        {
            //TODO: Define CanEditObject permission in ThuViecHocViecList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("ThuViecHocViecListEditGroup"))
            //	return true;
            //return false;
        }

        public static bool CanDeleteObject()
        {
            //TODO: Define CanDeleteObject permission in ThuViecHocViecList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("ThuViecHocViecListDeleteGroup"))
            //	return true;
            //return false;
        }
        #endregion //Authorization Rules

        #region Factory Methods
        private ThuViecHocViecList()
        { /* require use of factory method */ }

        public static ThuViecHocViecList NewThuViecHocViecList()
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a ThuViecHocViecList");
            return new ThuViecHocViecList();
        }
        public static ThuViecHocViecList GetThuViecHocViecListByNhanVien(long maNhanVien,int Loai)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a ThuViecHocViecList");
            return DataPortal.Fetch<ThuViecHocViecList>(new FilterCriteria(maNhanVien,Loai));
        }
        public static ThuViecHocViecList GetThuViecHocViecListByBoPhan(int mabophan,int Loai)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a ThuViecHocViecList");
            return DataPortal.Fetch<ThuViecHocViecList>(new FilterCriteriaByBoPhan(mabophan,Loai));
        }
        public static ThuViecHocViecList GetThuViecHocViecListByBoPhanAll(int mabophan, int Loai)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a ThuViecHocViecList");
            return DataPortal.Fetch<ThuViecHocViecList>(new FilterCriteriaByBoPhanAll(mabophan, Loai));
        }
        #endregion //Factory Methods

        #region Data Access

        #region Filter Criteria
        [Serializable()]
        private class FilterCriteria
        {
            public long MaNhanVien;
            public int Loai;
            public FilterCriteria(long maNhanVien,int Loai)
            {
                this.Loai = Loai;
                this.MaNhanVien = maNhanVien;               
            }
        }
        private class FilterCriteriaByBoPhan
        {
            public int mabophan;
            public int Loai;
            public FilterCriteriaByBoPhan(int mabophan, int Loai)
            {
                this.mabophan =mabophan;
                this.Loai = Loai;
            }
        }
        private class FilterCriteriaByBoPhanAll
        {
            public int mabophan;
            public int Loai;
            public FilterCriteriaByBoPhanAll(int mabophan, int Loai)
            {
                this.mabophan = mabophan;
                this.Loai = Loai;
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
                    cm.CommandText = "spd_SelecttblnsThuViecHocViecByNhanVien";
                    cm.Parameters.AddWithValue("@MaNhanVien", ((FilterCriteria)criteria).MaNhanVien);
                    cm.Parameters.AddWithValue("@Loai", ((FilterCriteria)criteria).Loai);                    
                }
                else if (criteria is FilterCriteriaByBoPhan)
                {
                    cm.CommandText = "spd_SelecttblnsThuViecHocViecByBophan";
                    cm.Parameters.AddWithValue("@mabophan", ((FilterCriteriaByBoPhan)criteria).mabophan);
                    cm.Parameters.AddWithValue("@Loai", ((FilterCriteriaByBoPhan)criteria).Loai);  
                }
                else if (criteria is FilterCriteriaByBoPhanAll)
                {
                    cm.CommandText = "spd_SelecttblnsThuViecHocViecByBophanAll";
                    cm.Parameters.AddWithValue("@mabophan", ((FilterCriteriaByBoPhanAll)criteria).mabophan);
                    cm.Parameters.AddWithValue("@Loai", ((FilterCriteriaByBoPhanAll)criteria).Loai);  
                }
                using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                {
                    while (dr.Read())
                        this.Add(ThuViecHocViec.GetThuViecHocViec(dr));
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
                    foreach (ThuViecHocViec deletedChild in DeletedList)
                        deletedChild.DeleteSelf(tr);
                    DeletedList.Clear();

                    // loop through each non-deleted child object
                    foreach (ThuViecHocViec child in this)
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
