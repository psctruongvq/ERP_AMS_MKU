using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
//long test
namespace ERP_Library
{
    [Serializable()]

    public class BoPhanMoRong_NhanVienList : Csla.BusinessListBase<BoPhanMoRong_NhanVienList, BoPhanMoRong_NhanVien>
    {

        #region Authorization Rules

        public static bool CanGetObject()
        {
            //TODO: Define CanGetObject permission in BoPhanMoRong_NhanVienList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("BoPhanMoRong_NhanVienListViewGroup"))
            //	return true;
            //return false;
        }

        public static bool CanAddObject()
        {
            //TODO: Define CanAddObject permission in BoPhanMoRong_NhanVienList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("BoPhanMoRong_NhanVienListAddGroup"))
            //	return true;
            //return false;
        }

        public static bool CanEditObject()
        {
            //TODO: Define CanEditObject permission in BoPhanMoRong_NhanVienList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("BoPhanMoRong_NhanVienListEditGroup"))
            //	return true;
            //return false;
        }

        public static bool CanDeleteObject()
        {
            //TODO: Define CanDeleteObject permission in BoPhanMoRong_NhanVienList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("BoPhanMoRong_NhanVienListDeleteGroup"))
            //	return true;
            //return false;
        }
        #endregion //Authorization Rules

        #region Factory Methods
        private BoPhanMoRong_NhanVienList()
        { /* require use of factory method */ }

        public static BoPhanMoRong_NhanVienList NewBoPhanMoRong_NhanVienList()
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a BoPhanMoRong_NhanVienList");
            return new BoPhanMoRong_NhanVienList();
        }
        public static BoPhanMoRong_NhanVienList GetBoPhanMoRong_NhanVienList(int maBoPhanMoRong)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a BoPhanMoRong_NhanVienList");
            return DataPortal.Fetch<BoPhanMoRong_NhanVienList>(new FilterCriteria_NhanVienThuocBoPhanMoRong(maBoPhanMoRong));
        }
        public static BoPhanMoRong_NhanVienList GetBoPhanMoRong_NhanVienList()
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a BoPhanMoRong_NhanVienList");
            return DataPortal.Fetch<BoPhanMoRong_NhanVienList>(new FilterCriteria());
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
        private class FilterCriteria_NhanVienThuocBoPhanMoRong
        {
            public int MaBoPhanMoRong;

            public FilterCriteria_NhanVienThuocBoPhanMoRong(int maBoPhanMoRong)
            {
                this.MaBoPhanMoRong = maBoPhanMoRong;
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
                    cm.CommandText = "spd_SelectnsBoPhanMoRong_NhanVienListAll";
                }
                else if (criteria is FilterCriteria_NhanVienThuocBoPhanMoRong)
                {
                    cm.CommandText = "spd_SelectnsBoPhanMoRong_NhanVienList_byMaBoPhanMoRong";
                    cm.Parameters.AddWithValue("@MaBoPhanMoRong", (criteria as FilterCriteria_NhanVienThuocBoPhanMoRong).MaBoPhanMoRong);
                }
                using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                {
                    while (dr.Read())
                        this.Add(BoPhanMoRong_NhanVien.GetBoPhanMoRong_NhanVien(dr));
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
                    foreach (BoPhanMoRong_NhanVien deletedChild in DeletedList)
                        deletedChild.DeleteSelf(tr);
                    DeletedList.Clear();

                    // loop through each non-deleted child object
                    foreach (BoPhanMoRong_NhanVien child in this)
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
