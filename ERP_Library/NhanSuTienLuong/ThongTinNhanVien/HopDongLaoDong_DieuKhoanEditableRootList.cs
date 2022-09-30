


using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{
    [Serializable()]
    public class HopDongLaoDong_DieuKhoanList : Csla.BusinessListBase<HopDongLaoDong_DieuKhoanList, HopDongLaoDong_DieuKhoan>
    {

        #region Authorization Rules

        public static bool CanGetObject()
        {
            //TODO: Define CanGetObject permission in HopDongLaoDong_DieuKhoanList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("HopDongLaoDong_DieuKhoanListViewGroup"))
            //	return true;
            //return false;
        }

        public static bool CanAddObject()
        {
            //TODO: Define CanAddObject permission in HopDongLaoDong_DieuKhoanList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("HopDongLaoDong_DieuKhoanListAddGroup"))
            //	return true;
            //return false;
        }

        public static bool CanEditObject()
        {
            //TODO: Define CanEditObject permission in HopDongLaoDong_DieuKhoanList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("HopDongLaoDong_DieuKhoanListEditGroup"))
            //	return true;
            //return false;
        }

        public static bool CanDeleteObject()
        {
            //TODO: Define CanDeleteObject permission in HopDongLaoDong_DieuKhoanList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("HopDongLaoDong_DieuKhoanListDeleteGroup"))
            //	return true;
            //return false;
        }
        #endregion //Authorization Rules

        #region Factory Methods
        private HopDongLaoDong_DieuKhoanList()
        { /* require use of factory method */ }

        public static HopDongLaoDong_DieuKhoanList NewHopDongLaoDong_DieuKhoanList()
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a HopDongLaoDong_DieuKhoanList");
            return new HopDongLaoDong_DieuKhoanList();
        }

        public static HopDongLaoDong_DieuKhoanList GetHopDongLaoDong_DieuKhoanListByKyMoi()
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a HopDongLaoDong_DieuKhoanList");
            return DataPortal.Fetch<HopDongLaoDong_DieuKhoanList>(new FilterCriteria());
        }

        public static HopDongLaoDong_DieuKhoanList GetHopDongLaoDong_DieuKhoanListByGiaHan()
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a HopDongLaoDong_DieuKhoanList");
            return DataPortal.Fetch<HopDongLaoDong_DieuKhoanList>(new FilterCriteriaByGiaHan());
        }

        public static HopDongLaoDong_DieuKhoanList GetHopDongLaoDong_DieuKhoanListByHocViecThuViec()
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a HopDongLaoDong_DieuKhoanList");
            return DataPortal.Fetch<HopDongLaoDong_DieuKhoanList>(new FilterCriteriaByHoCViecThuViec());
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
        private class FilterCriteriaByGiaHan
        {

            public FilterCriteriaByGiaHan()
            {

            }
        }

        private class FilterCriteriaByHoCViecThuViec
        {

            public FilterCriteriaByHoCViecThuViec()
            {

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
                    cm.CommandText = "spd_SelecttblnsHopDongLaoDong_DieuKhoansAllKyMoi";
                }
                else if (criteria is FilterCriteriaByGiaHan)
                {
                    cm.CommandText = "spd_SelecttblnsHopDongLaoDong_DieuKhoansAllGiaHan";
                }
                else if (criteria is FilterCriteriaByHoCViecThuViec)
                {
                    cm.CommandText = "spd_SelecttblnsHopDongLaoDong_DieuKhoansAllHoCViecThuViec";
                }
                using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                {
                    while (dr.Read())
                        this.Add(HopDongLaoDong_DieuKhoan.GetHopDongLaoDong_DieuKhoan(dr));
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
                    foreach (HopDongLaoDong_DieuKhoan deletedChild in DeletedList)
                        deletedChild.DeleteSelf(tr);
                    DeletedList.Clear();

                    // loop through each non-deleted child object
                    foreach (HopDongLaoDong_DieuKhoan child in this)
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
