
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{
    [Serializable()]
    public class KhoBQ_VTList : Csla.BusinessListBase<KhoBQ_VTList, KhoBQ_VT>
    {
        #region BindingList Overrides
        protected override object AddNewCore()
        {
            KhoBQ_VT item = KhoBQ_VT.NewKhoBQ_VT();
            this.Add(item);
            return item;
        }
        #endregion //BindingList Overrides

        #region Authorization Rules

        public static bool CanGetObject()
        {
            //TODO: Define CanGetObject permission in KhoBQ_VTList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("KhoBQ_VTListViewGroup"))
            //	return true;
            //return false;
        }

        public static bool CanAddObject()
        {
            //TODO: Define CanAddObject permission in KhoBQ_VTList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("KhoBQ_VTListAddGroup"))
            //	return true;
            //return false;
        }

        public static bool CanEditObject()
        {
            //TODO: Define CanEditObject permission in KhoBQ_VTList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("KhoBQ_VTListEditGroup"))
            //	return true;
            //return false;
        }

        public static bool CanDeleteObject()
        {
            //TODO: Define CanDeleteObject permission in KhoBQ_VTList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("KhoBQ_VTListDeleteGroup"))
            //	return true;
            //return false;
        }
        #endregion //Authorization Rules

        #region Factory Methods
        private KhoBQ_VTList()
        { /* require use of factory method */ }

        public static KhoBQ_VTList NewKhoBQ_VTList()
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a KhoBQ_VTList");
            return new KhoBQ_VTList();
        }

        public static KhoBQ_VTList GetKhoBQ_VTList(int maLoaiKho)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a KhoBQ_VTList");
            return DataPortal.Fetch<KhoBQ_VTList>(new FilterCriteriaByLoaiKho(maLoaiKho));
        }

        public static KhoBQ_VTList GetKhoBQ_VTList()
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a KhoBQ_VTList");
            return DataPortal.Fetch<KhoBQ_VTList>(new FilterCriteria());
        }

        public static KhoBQ_VTList GetKhoVatTuList()
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a KhoBQ_VTList");
            return DataPortal.Fetch<KhoBQ_VTList>(new FilterCriteriaByKhoVatTu());
        }
        #endregion //Factory Methods

        #region Data Access

        #region Filter Criteria
        [Serializable()]
        private class FilterCriteriaByLoaiKho
        {
            public int MaLoaiKho;

            public FilterCriteriaByLoaiKho(int maLoaiKho)
            {
                this.MaLoaiKho = maLoaiKho;
            }
        }
        private class FilterCriteria
        {

            public FilterCriteria()
            {
              
            }
        }

        private class FilterCriteriaByKhoVatTu
        {

            public FilterCriteriaByKhoVatTu()
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
            int maBoPhan = ERP_Library.Security.CurrentUser.Info.MaBoPhan;
            int userID = ERP_Library.Security.CurrentUser.Info.UserID;
            int maCongTy = ERP_Library.Security.CurrentUser.Info.MaCongTy;
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                if (criteria is FilterCriteria)
                {
                    cm.CommandText = "spd_SelecttblKhosAll";
                    cm.Parameters.AddWithValue("@MaBoPhan", maBoPhan);
                    cm.Parameters.AddWithValue("@UserID", userID);
                    cm.Parameters.AddWithValue("@MaCongTy", maCongTy);
                }
                else if (criteria is FilterCriteriaByLoaiKho)
                {
                    cm.CommandText = "spd_SelecttblKhoByMaLoaiKho";
                    cm.Parameters.AddWithValue("@MaLoaiKho", ((FilterCriteriaByLoaiKho)criteria).MaLoaiKho);
                    cm.Parameters.AddWithValue("@MaBoPhan", maBoPhan);
                    cm.Parameters.AddWithValue("@UserID", userID);
                    cm.Parameters.AddWithValue("@MaCongTy", maCongTy);
                }
                else if (criteria is FilterCriteriaByKhoVatTu)
                {
                    cm.CommandText = "spd_SelecttblKhoByKhoVatTu";
                    cm.Parameters.AddWithValue("@MaBoPhan", maBoPhan);
                    cm.Parameters.AddWithValue("@UserID", userID);
                    cm.Parameters.AddWithValue("@MaCongTy", maCongTy);
                }

                using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                {
                    while (dr.Read())
                        this.Add(KhoBQ_VT.GetKhoBQ_VT(dr));
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
                    foreach (KhoBQ_VT deletedChild in DeletedList)
                        deletedChild.DeleteSelf(tr);
                    DeletedList.Clear();

                    // loop through each non-deleted child object
                    foreach (KhoBQ_VT child in this)
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
