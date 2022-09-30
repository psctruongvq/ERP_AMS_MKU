
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{
    [Serializable()]
    public class UyNhiemChi_CacQuyList : Csla.BusinessListBase<UyNhiemChi_CacQuyList, UyNhiemChi_CacQuy>
    {
        #region BindingList Overrides
        protected override object AddNewCore()
        {
            UyNhiemChi_CacQuy item = UyNhiemChi_CacQuy.NewUyNhiemChi_CacQuy();
            this.Add(item);
            return item;
        }
        #endregion //BindingList Overrides

        #region Authorization Rules

        public static bool CanGetObject()
        {
            //TODO: Define CanGetObject permission in UyNhiemChi_CacQuyList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("UyNhiemChi_CacQuyListViewGroup"))
            //	return true;
            //return false;
        }

        public static bool CanAddObject()
        {
            //TODO: Define CanAddObject permission in UyNhiemChi_CacQuyList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("UyNhiemChi_CacQuyListAddGroup"))
            //	return true;
            //return false;
        }

        public static bool CanEditObject()
        {
            //TODO: Define CanEditObject permission in UyNhiemChi_CacQuyList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("UyNhiemChi_CacQuyListEditGroup"))
            //	return true;
            //return false;
        }

        public static bool CanDeleteObject()
        {
            //TODO: Define CanDeleteObject permission in UyNhiemChi_CacQuyList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("UyNhiemChi_CacQuyListDeleteGroup"))
            //	return true;
            //return false;
        }
        #endregion //Authorization Rules

        #region Factory Methods
        private UyNhiemChi_CacQuyList()
        { /* require use of factory method */ }

        public static UyNhiemChi_CacQuyList NewUyNhiemChi_CacQuyList()
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a UyNhiemChi_CacQuyList");
            return new UyNhiemChi_CacQuyList();
        }

        public static UyNhiemChi_CacQuyList GetUyNhiemChi_CacQuyList()
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a UyNhiemChi_CacQuyList");
            return DataPortal.Fetch<UyNhiemChi_CacQuyList>(new FilterCriteria());
        }

        public static UyNhiemChi_CacQuyList GetUyNhiemChi_CacQuyList(DateTime TuNgay, DateTime DenNgay, int LoaiDeNghi)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a UyNhiemChi_CacQuyList");
            return DataPortal.Fetch<UyNhiemChi_CacQuyList>(new FilterCriteria_ByNgay(TuNgay, DenNgay, LoaiDeNghi));
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

        private class FilterCriteria_ByNgay
        {
            public DateTime _tuNgay;
            public DateTime _denNgay;
            public int _loaiDeNghi;

            public FilterCriteria_ByNgay(DateTime TuNgay, DateTime DenNgay, int LoaiDeNghi)
            {
                this._tuNgay = TuNgay;
                this._denNgay = DenNgay;
                this._loaiDeNghi = LoaiDeNghi;
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
                    cm.CommandText = "spd_SelecttblUyNhiemChi_CacQuiesAll";

                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(UyNhiemChi_CacQuy.GetUyNhiemChi_CacQuy(dr));
                    }
                }
                else if (criteria is FilterCriteria_ByNgay)
                {
                    cm.CommandText = "spd_SelecttblUyNhiemChi_CacQuies_ByNgay";
                    cm.Parameters.AddWithValue("@TuNgay", ((FilterCriteria_ByNgay)criteria)._tuNgay);
                    cm.Parameters.AddWithValue("@DenNgay", ((FilterCriteria_ByNgay)criteria)._denNgay);
                    cm.Parameters.AddWithValue("@LoaiDeNghi", ((FilterCriteria_ByNgay)criteria)._loaiDeNghi);
                    cm.Parameters.AddWithValue("@UserId", Security.CurrentUser.Info.UserID);

                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(UyNhiemChi_CacQuy.GetUyNhiemChi_CacQuy_New(dr));
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
                    foreach (UyNhiemChi_CacQuy deletedChild in DeletedList)
                        deletedChild.DeleteSelf(tr);
                    DeletedList.Clear();

                    // loop through each non-deleted child object
                    foreach (UyNhiemChi_CacQuy child in this)
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
