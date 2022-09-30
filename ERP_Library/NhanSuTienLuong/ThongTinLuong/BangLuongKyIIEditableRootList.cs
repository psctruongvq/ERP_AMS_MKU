
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{
    [Serializable()]
    public class BangLuongKyIIList : Csla.BusinessListBase<BangLuongKyIIList, BangLuongKyII>
    {
        #region BindingList Overrides
        protected override object AddNewCore()
        {
            BangLuongKyII item = BangLuongKyII.NewBangLuongKyII();
            this.Add(item);
            return item;
        }
        #endregion //BindingList Overrides

        #region Authorization Rules

        public static bool CanGetObject()
        {
            //TODO: Define CanGetObject permission in BangLuongKyIIList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("BangLuongKyIIListViewGroup"))
            //	return true;
            //return false;
        }

        public static bool CanAddObject()
        {
            //TODO: Define CanAddObject permission in BangLuongKyIIList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("BangLuongKyIIListAddGroup"))
            //	return true;
            //return false;
        }

        public static bool CanEditObject()
        {
            //TODO: Define CanEditObject permission in BangLuongKyIIList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("BangLuongKyIIListEditGroup"))
            //	return true;
            //return false;
        }

        public static bool CanDeleteObject()
        {
            //TODO: Define CanDeleteObject permission in BangLuongKyIIList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("BangLuongKyIIListDeleteGroup"))
            //	return true;
            //return false;
        }
        #endregion //Authorization Rules

        #region Factory Methods
        private BangLuongKyIIList()
        { /* require use of factory method */ }

        public static BangLuongKyIIList NewBangLuongKyIIList()
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a BangLuongKyIIList");
            return new BangLuongKyIIList();
        }

        public static BangLuongKyIIList GetBangLuongKyIIList(int maKyTinhLuong)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a BangLuongKyIIList");
            return DataPortal.Fetch<BangLuongKyIIList>(new FilterCriteria(maKyTinhLuong));
        }

        public static BangLuongKyIIList GetBangLuongKyIIList(int maKyTinhLuong, int maBoPhan)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a BangLuongKyIIList");
            return DataPortal.Fetch<BangLuongKyIIList>(new FilterCriteria_ByKyTinhAndBoPhan(maKyTinhLuong, maBoPhan));
        }

        public static BangLuongKyIIList GetBangLuongKyIIList(long MaChungTu)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a BangLuongKyIIList");
            return DataPortal.Fetch<BangLuongKyIIList>(new FilterCriteria_ByMaChungTu(MaChungTu));
        }
        #endregion //Factory Methods

        #region Data Access

        #region Filter Criteria
        [Serializable()]
        private class FilterCriteria
        {
            public int MaKyTinhLuong;

            public FilterCriteria(int maKyTinhLuong)
            {
                this.MaKyTinhLuong = maKyTinhLuong;
            }
        }

        private class FilterCriteria_ByKyTinhAndBoPhan
        {
            public int MaKyTinhLuong;
            public int MaBoPhan;

            public FilterCriteria_ByKyTinhAndBoPhan(int maKyTinhLuong, int maBoPhan)
            {
                this.MaKyTinhLuong = maKyTinhLuong;
                this.MaBoPhan = maBoPhan;
            }
        }

        private class FilterCriteria_ByMaChungTu
        {
            public long MaChungTu;

            public FilterCriteria_ByMaChungTu(long maChungTu)
            {
                this.MaChungTu = maChungTu;
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
                    cm.CommandText = "spd_SelecttblBangLuongKyIIList";
                    cm.Parameters.AddWithValue("@MaKyTinhLuong", ((FilterCriteria)criteria).MaKyTinhLuong);
                }
                else if (criteria is FilterCriteria_ByKyTinhAndBoPhan)
                {
                    cm.CommandText = "spd_SelecttblnsBangLuong_Ky2sByMaKyAndBoPhan";
                    cm.Parameters.AddWithValue("@MaKyTinhLuong", ((FilterCriteria_ByKyTinhAndBoPhan)criteria).MaKyTinhLuong);
                    cm.Parameters.AddWithValue("@MaBoPhan", ((FilterCriteria_ByKyTinhAndBoPhan)criteria).MaBoPhan);
                }
                else if (criteria is FilterCriteria_ByMaChungTu)
                {
                    cm.CommandText = "spd_SelecttblnsBangLuong_Ky2sByMaChungTu";
                    cm.Parameters.AddWithValue("@MaChungTu", ((FilterCriteria_ByMaChungTu)criteria).MaChungTu);
                }

                using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                {
                    while (dr.Read())
                        this.Add(BangLuongKyII.GetBangLuongKyII(dr));
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
                    foreach (BangLuongKyII deletedChild in DeletedList)
                        deletedChild.DeleteSelf(tr);
                    DeletedList.Clear();

                    // loop through each non-deleted child object
                    foreach (BangLuongKyII child in this)
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
