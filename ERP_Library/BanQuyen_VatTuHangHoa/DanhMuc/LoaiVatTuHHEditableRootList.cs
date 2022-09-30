
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;


namespace ERP_Library
{
    [Serializable()]
    public class LoaiVatTuHHBQ_VTList : Csla.BusinessListBase<LoaiVatTuHHBQ_VTList, LoaiVatTuHHBQ_VT>
    {
        #region BindingList Overrides
        protected override object AddNewCore()
        {
            LoaiVatTuHHBQ_VT item = LoaiVatTuHHBQ_VT.NewLoaiVatTuHHBQ_VT();
            this.Add(item);
            return item;
        }
        #endregion //BindingList Overrides

        #region Authorization Rules

        public static bool CanGetObject()
        {
            //TODO: Define CanGetObject permission in LoaiVatTuHHBQ_VTList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("LoaiVatTuHHBQ_VTListViewGroup"))
            //	return true;
            //return false;
        }

        public static bool CanAddObject()
        {
            //TODO: Define CanAddObject permission in LoaiVatTuHHBQ_VTList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("LoaiVatTuHHBQ_VTListAddGroup"))
            //	return true;
            //return false;
        }

        public static bool CanEditObject()
        {
            //TODO: Define CanEditObject permission in LoaiVatTuHHBQ_VTList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("LoaiVatTuHHBQ_VTListEditGroup"))
            //	return true;
            //return false;
        }

        public static bool CanDeleteObject()
        {
            //TODO: Define CanDeleteObject permission in LoaiVatTuHHBQ_VTList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("LoaiVatTuHHBQ_VTListDeleteGroup"))
            //	return true;
            //return false;
        }
        #endregion //Authorization Rules

        #region Factory Methods
        private LoaiVatTuHHBQ_VTList()
        { /* require use of factory method */ }

        public static LoaiVatTuHHBQ_VTList NewLoaiVatTuHHBQ_VTList()
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a LoaiVatTuHHBQ_VTList");
            return new LoaiVatTuHHBQ_VTList();
        }

        public static LoaiVatTuHHBQ_VTList GetLoaiVatTuHHBQ_VTList()
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a LoaiVatTuHHBQ_VTList");
            return DataPortal.Fetch<LoaiVatTuHHBQ_VTList>(new FilterCriteria());
        }

        public static LoaiVatTuHHBQ_VTList GetLoaiVatTuHHBanQuyenList()
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a LoaiVatTuHHBQ_VTList");
            return DataPortal.Fetch<LoaiVatTuHHBQ_VTList>(new FilterCriteriaBQ());
        }

        public static LoaiVatTuHHBQ_VTList GetLoaiVatTuHHList()
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a LoaiVatTuHHBQ_VTList");
            return DataPortal.Fetch<LoaiVatTuHHBQ_VTList>(new FilterCriteriaVTHH());
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

        private class FilterCriteriaBQ
        {
            public FilterCriteriaBQ()
            {

            }
        }

        private class FilterCriteriaVTHH
        {
            public FilterCriteriaVTHH()
            {

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
            int maCongTy = ERP_Library.Security.CurrentUser.Info.MaCongTy;
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                if (criteria is FilterCriteria)
                {
                    cm.CommandText = "spd_SelecttblLoaiVatTuHHsAll";
                    cm.Parameters.AddWithValue("@MaCongTy", maCongTy);
                }
                else if (criteria is FilterCriteriaBQ)
                {
                    cm.CommandText = "spd_SelecttblLoaiVatTuHHBanQuyen";
                    cm.Parameters.AddWithValue("@MaCongTy", maCongTy);
                }
                else if (criteria is FilterCriteriaVTHH)
                {
                    cm.CommandText = "spd_SelecttblLoaiVatTuHHTheoVTHH";
                    cm.Parameters.AddWithValue("@MaCongTy", maCongTy);
                }
                using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                {
                    while (dr.Read())
                        this.Add(LoaiVatTuHHBQ_VT.GetLoaiVatTuHHBQ_VT(dr));
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
                    foreach (LoaiVatTuHHBQ_VT deletedChild in DeletedList)
                        deletedChild.DeleteSelf(tr);
                    DeletedList.Clear();

                    // loop through each non-deleted child object
                    foreach (LoaiVatTuHHBQ_VT child in this)
                    {
                        if (child.IsNew)
                            child.Insert(tr,this);
                        else
                            child.Update(tr,this);
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
