
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{
    [Serializable()]
    public class DoiTuongThuChiList : Csla.BusinessListBase<DoiTuongThuChiList, DoiTuongThuChi>
    {
        #region BindingList Overrides
        protected override object AddNewCore()
        {
            DoiTuongThuChi item = DoiTuongThuChi.NewDoiTuongThuChi();
            this.Add(item);
            return item;
        }
        #endregion //BindingList Overrides

        #region Authorization Rules

        public static bool CanGetObject()
        {
            //TODO: Define CanGetObject permission in DoiTuongThuChiList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("DoiTuongThuChiListViewGroup"))
            //	return true;
            //return false;
        }

        public static bool CanAddObject()
        {
            //TODO: Define CanAddObject permission in DoiTuongThuChiList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("DoiTuongThuChiListAddGroup"))
            //	return true;
            //return false;
        }

        public static bool CanEditObject()
        {
            //TODO: Define CanEditObject permission in DoiTuongThuChiList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("DoiTuongThuChiListEditGroup"))
            //	return true;
            //return false;
        }

        public static bool CanDeleteObject()
        {
            //TODO: Define CanDeleteObject permission in DoiTuongThuChiList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("DoiTuongThuChiListDeleteGroup"))
            //	return true;
            //return false;
        }
        #endregion //Authorization Rules

        #region Factory Methods
        private DoiTuongThuChiList()
        { /* require use of factory method */ }

        public static DoiTuongThuChiList NewDoiTuongThuChiList()
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a DoiTuongThuChiList");
            return new DoiTuongThuChiList();
        }

        public static DoiTuongThuChiList GetDoiTuongThuChiList(int MaCongTy)// lay nhung cai chi su dung
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a DoiTuongThuChiList");
            return DataPortal.Fetch<DoiTuongThuChiList>(new FilterCriteria(MaCongTy));
        }
        public static DoiTuongThuChiList GetDoiTuongThuChiListAll(int MaCongTy)// lay tat ca
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a DoiTuongThuChiList");
            return DataPortal.Fetch<DoiTuongThuChiList>(new FilterCriteriaAll(MaCongTy));
        }
        #endregion //Factory Methods

        #region Data Access

        #region Filter Criteria
        [Serializable()]
        private class FilterCriteria
        {
            public int MaCongTy;
            public FilterCriteria(int macongty)
            {
                MaCongTy = macongty;
            }
        }
        private class FilterCriteriaAll
        {
            public int MaCongTy;
            public FilterCriteriaAll(int macongty)
            {
                MaCongTy = macongty;
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
                if (criteria is FilterCriteria)
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_SelecttblcnLoaiDoiTuongsAll"; // lay chi nhung ma su dung
                    cm.Parameters.AddWithValue("@MaCongTy", ((FilterCriteria)criteria).MaCongTy);
                }
                else if (criteria is FilterCriteriaAll)
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_SelecttblcnLoaiDoiTuongsAllByMaCongTy"; // lay tat ca de chinh sua tren form

                    cm.Parameters.AddWithValue("@MaCongTy", ((FilterCriteriaAll)criteria).MaCongTy);

                }

                using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                {
                    while (dr.Read())
                        this.Add(DoiTuongThuChi.GetDoiTuongThuChi(dr));
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
                    foreach (DoiTuongThuChi deletedChild in DeletedList)
                        deletedChild.DeleteSelf(tr);
                    DeletedList.Clear();

                    // loop through each non-deleted child object
                    foreach (DoiTuongThuChi child in this)
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
