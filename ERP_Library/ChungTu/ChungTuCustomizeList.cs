using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{
    [Serializable()]
    public class ChungTuCustomizeList : Csla.BusinessListBase<ChungTuCustomizeList, ChungTuCustomize>
    {
        #region BindingList Overrides
        protected override object AddNewCore()
        {
            ChungTuCustomize item = ChungTuCustomize.NewChungTuCustomize();
            this.Add(item);
            return item;
        }
        #endregion //BindingList Overrides

        #region Authorization Rules

        public static bool CanGetObject()
        {
            //TODO: Define CanGetObject permission in ChungTuCustomizeList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("ChungTuCustomizeListViewGroup"))
            //	return true;
            //return false;
        }

        public static bool CanAddObject()
        {
            //TODO: Define CanAddObject permission in ChungTuCustomizeList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("ChungTuCustomizeListAddGroup"))
            //	return true;
            //return false;
        }

        public static bool CanEditObject()
        {
            //TODO: Define CanEditObject permission in ChungTuCustomizeList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("ChungTuCustomizeListEditGroup"))
            //	return true;
            //return false;
        }

        public static bool CanDeleteObject()
        {
            //TODO: Define CanDeleteObject permission in ChungTuCustomizeList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("ChungTuCustomizeListDeleteGroup"))
            //	return true;
            //return false;
        }
        #endregion //Authorization Rules

        #region Factory Methods
        private ChungTuCustomizeList()
        { /* require use of factory method */ }

        public static ChungTuCustomizeList NewChungTuCustomizeList()
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a ChungTuCustomizeList");
            return new ChungTuCustomizeList();
        }

        public static ChungTuCustomizeList GetChungTuCustomizeList(DateTime tungay, DateTime denngay)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a ChungTuCustomizeList");
            return DataPortal.Fetch<ChungTuCustomizeList>(new FilterCriteria(tungay,denngay));
        }

        public static ChungTuCustomizeList GetChungTuCustomizeListForTheoDoi(int maLoaiCT, DateTime tungay, DateTime denngay)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a ChungTuCustomizeList");
            return DataPortal.Fetch<ChungTuCustomizeList>(new FilterCriteriaTheoDoi(maLoaiCT,tungay, denngay));
        }
        #endregion //Factory Methods

        #region Data Access

        #region Filter Criteria
        [Serializable()]
        private class FilterCriteria
        {
            public DateTime TuNgay;
            public DateTime DenNgay;

            public FilterCriteria(DateTime tungay, DateTime denNgay)
            {
                TuNgay = tungay;
                DenNgay = denNgay;
            }
        }

        private class FilterCriteriaTheoDoi
        {

            public int MaLoaiCT;
            public DateTime TuNgay;
            public DateTime DenNgay;

            public FilterCriteriaTheoDoi(int maloaiCT, DateTime tungay, DateTime denNgay)
            {
                MaLoaiCT = maloaiCT;
                TuNgay = tungay;
                DenNgay = denNgay;
            }
        }

        private class FilterCriteriaHoTro1
        {

            public int MaLoaiCT;
            public DateTime TuNgay;
            public DateTime DenNgay;

            public FilterCriteriaHoTro1(int maloaiCT, DateTime tungay, DateTime denNgay)
            {
                MaLoaiCT = maloaiCT;
                TuNgay = tungay;
                DenNgay = denNgay;
            }
        }
        #endregion //Filter Criteria

        #region Data Access - Fetch
        private void DataPortal_Fetch(object criteria)
        {
            RaiseListChangedEvents = false;

            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();

                ExecuteFetch(cn, criteria);
            }//using

            RaiseListChangedEvents = true;
        }

        private void ExecuteFetch(SqlConnection cn, object criteria)
        {
            using (SqlCommand cm = cn.CreateCommand())
            {
                if (criteria is FilterCriteriaTheoDoi)
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_SelecttblChungTuCustomizeListForTheoDoi";
                    cm.Parameters.AddWithValue("@MaCongTy", ERP_Library.Security.CurrentUser.Info.MaCongTy);
                    cm.Parameters.AddWithValue("@UserID", ERP_Library.Security.CurrentUser.Info.UserID);
                    cm.Parameters.AddWithValue("@MaLoaiCT", ((FilterCriteriaTheoDoi)criteria).MaLoaiCT);
                    cm.Parameters.AddWithValue("@TuNgay", ((FilterCriteriaTheoDoi)criteria).TuNgay);
                    cm.Parameters.AddWithValue("@DenNgay", ((FilterCriteriaTheoDoi)criteria).DenNgay);
                }
                else if (criteria is FilterCriteriaHoTro1)
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_SelecttblChungTuCustomizeListForTheoDoi";
                    cm.Parameters.AddWithValue("@MaCongTy", ERP_Library.Security.CurrentUser.Info.MaCongTy);
                    cm.Parameters.AddWithValue("@UserID", ERP_Library.Security.CurrentUser.Info.UserID);
                    cm.Parameters.AddWithValue("@MaLoaiCT", ((FilterCriteriaHoTro1)criteria).MaLoaiCT);
                    cm.Parameters.AddWithValue("@TuNgay", ((FilterCriteriaHoTro1)criteria).TuNgay);
                    cm.Parameters.AddWithValue("@DenNgay", ((FilterCriteriaHoTro1)criteria).DenNgay);
                }
                else if (criteria is FilterCriteria)
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_SelecttblChungTuCustomizeList";
                    cm.Parameters.AddWithValue("@MaCongTy", ERP_Library.Security.CurrentUser.Info.MaCongTy);
                    cm.Parameters.AddWithValue("@UserID", ERP_Library.Security.CurrentUser.Info.UserID);
                    cm.Parameters.AddWithValue("@TuNgay", ((FilterCriteria)criteria).TuNgay);
                    cm.Parameters.AddWithValue("@DenNgay", ((FilterCriteria)criteria).DenNgay);
                }


                using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                {
                    while (dr.Read())
                        this.Add(ChungTuCustomize.GetChungTuCustomize(dr));
                }
            }//using
        }
        #endregion //Data Access - Fetch


        #region Data Access - Update
        protected override void DataPortal_Update()
        {
            RaiseListChangedEvents = false;

            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();

                // loop through each deleted child object
                foreach (ChungTuCustomize deletedChild in DeletedList)
                    deletedChild.DeleteSelf(cn);
                DeletedList.Clear();

                // loop through each non-deleted child object
                foreach (ChungTuCustomize child in this)
                {
                    if (child.IsNew)
                        child.Insert(cn);
                    else
                        child.Update(cn);
                }
            }//using SqlConnection

            RaiseListChangedEvents = true;
        }
        #endregion //Data Access - Update
        #endregion //Data Access
    }
}
