
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{
    [Serializable()]
    public class DonViTinhList : Csla.BusinessListBase<DonViTinhList, DonViTinh>
    {
        #region BindingList Overrides
        protected override object AddNewCore()
        {
            DonViTinh item = DonViTinh.NewDonViTinh();
            this.Add(item);
            return item;
        }
        #endregion //BindingList Overrides

        #region Authorization Rules

        public static bool CanGetObject()
        {
            //TODO: Define CanGetObject permission in DonViTinhList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("DonViTinhListViewGroup"))
            //	return true;
            //return false;
        }

        public static bool CanAddObject()
        {
            //TODO: Define CanAddObject permission in DonViTinhList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("DonViTinhListAddGroup"))
            //	return true;
            //return false;
        }

        public static bool CanEditObject()
        {
            //TODO: Define CanEditObject permission in DonViTinhList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("DonViTinhListEditGroup"))
            //	return true;
            //return false;
        }

        public static bool CanDeleteObject()
        {
            //TODO: Define CanDeleteObject permission in DonViTinhList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("DonViTinhListDeleteGroup"))
            //	return true;
            //return false;
        }
        #endregion //Authorization Rules

        #region Factory Methods
        private DonViTinhList()
        { /* require use of factory method */ }

        public static DonViTinhList NewDonViTinhList()
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a DonViTinhList");
            return new DonViTinhList();
        }

        public static DonViTinhList GetDonViTinhList()
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a DonViTinhList");
            return DataPortal.Fetch<DonViTinhList>(new FilterCriteria());
        }

        public static DonViTinhList GetDonViTinh_QuiDoi()
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a DonViTinhList");
            return DataPortal.Fetch<DonViTinhList>(new FilterCriteria_QuiDoi());
        }

        public static DonViTinhList GetDonViTinhList(int maDonViTinh)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a DonViTinhList");
            return DataPortal.Fetch<DonViTinhList>(new FilterCriteria_DVT(maDonViTinh));
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
        }//

        private class FilterCriteria_QuiDoi
        {
            public FilterCriteria_QuiDoi()
            {

            }
        }

        [Serializable()]
        private class FilterCriteria_DVT
        {
            public int MaDonViTinh;

            public FilterCriteria_DVT(int maDonViTinh)
            {
                this.MaDonViTinh = maDonViTinh;
            }

        }
        #endregion //Filter Criteria

        #region Data Access - Fetch
        protected override void DataPortal_Fetch(object criteria)
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
                catch(SqlException ex)
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
                    cm.CommandText = "spd_SelecttblDonViTinhList";
                else if (criteria is FilterCriteria_QuiDoi)
                {
                    cm.CommandText = "spd_SelecttblDonViTinh_QuiDoi";
                }
                else if (criteria is FilterCriteria_DVT)
                {
                    cm.CommandText = "spd_SelecttblDonViTinhList_DVT";
                    cm.Parameters.AddWithValue("MaDonViTinh", ((FilterCriteria_DVT)criteria).MaDonViTinh);
                }

                using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                {
                    while (dr.Read())
                        this.Add(DonViTinh.GetDonViTinh(dr));
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
                    foreach (DonViTinh deletedChild in DeletedList)
                        deletedChild.DeleteSelf(tr);
                    DeletedList.Clear();

                    // loop through each non-deleted child object
                    foreach (DonViTinh child in this)
                    {
                        if (child.IsNew)
                            child.Insert(tr);
                        else
                            child.Update(tr);
                    }

                    tr.Commit();
                }
                catch(SqlException ex)
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
