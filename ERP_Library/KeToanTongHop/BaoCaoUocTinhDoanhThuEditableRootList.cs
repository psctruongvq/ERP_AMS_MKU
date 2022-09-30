
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
namespace ERP_Library
{
    [Serializable()]
    public class BaoCaoUocTinhDoanhThuList : Csla.BusinessListBase<BaoCaoUocTinhDoanhThuList, BaoCaoUocTinhDoanhThu>
    {
        #region BindingList Overrides
        protected override object AddNewCore()
        {
            BaoCaoUocTinhDoanhThu item = BaoCaoUocTinhDoanhThu.NewBaoCaoUocTinhDoanhThu();
            this.Add(item);
            return item;
        }
        #endregion //BindingList Overrides

        #region Authorization Rules

        public static bool CanGetObject()
        {
            //TODO: Define CanGetObject permission in BaoCaoUocTinhDoanhThuList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("BaoCaoUocTinhDoanhThuListViewGroup"))
            //	return true;
            //return false;
        }

        public static bool CanAddObject()
        {
            //TODO: Define CanAddObject permission in BaoCaoUocTinhDoanhThuList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("BaoCaoUocTinhDoanhThuListAddGroup"))
            //	return true;
            //return false;
        }

        public static bool CanEditObject()
        {
            //TODO: Define CanEditObject permission in BaoCaoUocTinhDoanhThuList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("BaoCaoUocTinhDoanhThuListEditGroup"))
            //	return true;
            //return false;
        }

        public static bool CanDeleteObject()
        {
            //TODO: Define CanDeleteObject permission in BaoCaoUocTinhDoanhThuList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("BaoCaoUocTinhDoanhThuListDeleteGroup"))
            //	return true;
            //return false;
        }
        #endregion //Authorization Rules

        #region Factory Methods
        private BaoCaoUocTinhDoanhThuList()
        { /* require use of factory method */ }

        public static BaoCaoUocTinhDoanhThuList NewBaoCaoUocTinhDoanhThuList()
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a BaoCaoUocTinhDoanhThuList");
            return new BaoCaoUocTinhDoanhThuList();
        }

        public static BaoCaoUocTinhDoanhThuList GetBaoCaoUocTinhDoanhThuList()
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a BaoCaoUocTinhDoanhThuList");
            return DataPortal.Fetch<BaoCaoUocTinhDoanhThuList>(new FilterCriteria());
        }


        public static BaoCaoUocTinhDoanhThuList GetBaoCaoUocTinhDoanhThuListByMaKy(int maKy)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a BaoCaoUocTinhDoanhThuList");
            return DataPortal.Fetch<BaoCaoUocTinhDoanhThuList>(new FilterCriteriaByMaKy(maKy));
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

        [Serializable()]
        private class FilterCriteriaByMaKy
        {
            public int MaKy = 0;
            public FilterCriteriaByMaKy( int _maKy)
            {
                MaKy = _maKy;
            }
        }
        #endregion //Filter Criteria

        #region Data Access - Fetch
        private void DataPortal_Fetch(Object criteria)
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

        private void ExecuteFetch(SqlTransaction tr, Object criteria)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                if (criteria is FilterCriteria)
                {
                    cm.CommandText = "spd_SelecttblBaoCaoUocTinhDoanhThusAll";
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(BaoCaoUocTinhDoanhThu.GetBaoCaoUocTinhDoanhThu(dr, true));
                    }
                }
                else if (criteria is FilterCriteriaByMaKy)
                {
                    int count;
                    count = BaoCaoUocTinhDoanhThu.KiemTraKyBaoCao(((FilterCriteriaByMaKy)criteria).MaKy);

                    cm.CommandText = "spd_SelecttblBaoCaoUocTinhDoanhThusByMaKy";
                    cm.Parameters.AddWithValue("@MaKy", ((FilterCriteriaByMaKy)criteria).MaKy);
                    if (count > 0)
                    {
                        using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                        {
                            while (dr.Read())
                                this.Add(BaoCaoUocTinhDoanhThu.GetBaoCaoUocTinhDoanhThu(dr, true));
                        }
                    }
                    else
                    {
                        using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                        {
                            while (dr.Read())
                                this.Add(BaoCaoUocTinhDoanhThu.GetBaoCaoUocTinhDoanhThu(dr, false));
                        }
                    }
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
                    foreach (BaoCaoUocTinhDoanhThu deletedChild in DeletedList)
                        deletedChild.DeleteSelf(tr);
                    DeletedList.Clear();

                    // loop through each non-deleted child object
                    foreach (BaoCaoUocTinhDoanhThu child in this)
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

