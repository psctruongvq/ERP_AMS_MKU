
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{
    [Serializable()]
    public class BangLuongKyIList : Csla.BusinessListBase<BangLuongKyIList, BangLuongKyI>
    {
        #region BindingList Overrides
        protected override object AddNewCore()
        {
            BangLuongKyI item = BangLuongKyI.NewBangLuongKyI();
            this.Add(item);
            return item;
        }
        #endregion //BindingList Overrides

        #region Authorization Rules

        public static bool CanGetObject()
        {
            //TODO: Define CanGetObject permission in BangLuongKyIList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("BangLuongKyIListViewGroup"))
            //	return true;
            //return false;
        }

        public static bool CanAddObject()
        {
            //TODO: Define CanAddObject permission in BangLuongKyIList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("BangLuongKyIListAddGroup"))
            //	return true;
            //return false;
        }

        public static bool CanEditObject()
        {
            //TODO: Define CanEditObject permission in BangLuongKyIList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("BangLuongKyIListEditGroup"))
            //	return true;
            //return false;
        }

        public static bool CanDeleteObject()
        {
            //TODO: Define CanDeleteObject permission in BangLuongKyIList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("BangLuongKyIListDeleteGroup"))
            //	return true;
            //return false;
        }
        #endregion //Authorization Rules

        #region Factory Methods
        private BangLuongKyIList()
        { /* require use of factory method */ }

        public static BangLuongKyIList NewBangLuongKyIList()
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a BangLuongKyIList");
            return new BangLuongKyIList();
        }

        public static BangLuongKyIList GetBangLuongKyIList(int maKyTinhLuong)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a BangLuongKyIList");
            return DataPortal.Fetch<BangLuongKyIList>(new FilterCriteria(maKyTinhLuong));
        }

        public static BangLuongKyIList GetBangLuongKyIList(int maKyTinhLuong, int maBoPhan)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a BangLuongKyIIList");
            return DataPortal.Fetch<BangLuongKyIList>(new FilterCriteria_ByKyTinhAndBoPhan(maKyTinhLuong, maBoPhan));
        }

        public static BangLuongKyIList GetBangLuongKyIList(long MaChungTu)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a BangLuongKyIIList");
            return DataPortal.Fetch<BangLuongKyIList>(new FilterCriteria_ByMaChungTu(MaChungTu));
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
                    cm.CommandText = "spd_SelecttblnsBangLuong_Ky1sByMaKyAndBoPhan";
                    cm.Parameters.AddWithValue("@MaKyTinhLuong", ((FilterCriteria_ByKyTinhAndBoPhan)criteria).MaKyTinhLuong);
                    cm.Parameters.AddWithValue("@MaBoPhan", ((FilterCriteria_ByKyTinhAndBoPhan)criteria).MaBoPhan);
                }
                else if (criteria is FilterCriteria_ByMaChungTu)
                {
                    cm.CommandText = "spd_SelecttblnsBangLuong_Ky1sByMaChungTu";
                    cm.Parameters.AddWithValue("@MaChungTu", ((FilterCriteria_ByMaChungTu)criteria).MaChungTu);
                }


                using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                {
                    while (dr.Read())
                        this.Add(BangLuongKyI.GetBangLuongKyI(dr));
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
                    foreach (BangLuongKyI deletedChild in DeletedList)
                        deletedChild.DeleteSelf(tr);
                    DeletedList.Clear();

                    // loop through each non-deleted child object
                    foreach (BangLuongKyI child in this)
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
