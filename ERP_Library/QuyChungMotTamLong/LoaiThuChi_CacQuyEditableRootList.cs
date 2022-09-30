
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{
    [Serializable()]
    public class LoaiThuChi_CacQuyList : Csla.BusinessListBase<LoaiThuChi_CacQuyList, LoaiThuChi_CacQuy>
    {
        #region BindingList Overrides
        protected override object AddNewCore()
        {
            LoaiThuChi_CacQuy item = LoaiThuChi_CacQuy.NewLoaiThuChi_CacQuy();
            this.Add(item);
            return item;
        }
        #endregion //BindingList Overrides

        #region Authorization Rules

        public static bool CanGetObject()
        {
            //TODO: Define CanGetObject permission in LoaiThuChi_CacQuyList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("LoaiThuChi_CacQuyListViewGroup"))
            //	return true;
            //return false;
        }

        public static bool CanAddObject()
        {
            //TODO: Define CanAddObject permission in LoaiThuChi_CacQuyList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("LoaiThuChi_CacQuyListAddGroup"))
            //	return true;
            //return false;
        }

        public static bool CanEditObject()
        {
            //TODO: Define CanEditObject permission in LoaiThuChi_CacQuyList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("LoaiThuChi_CacQuyListEditGroup"))
            //	return true;
            //return false;
        }

        public static bool CanDeleteObject()
        {
            //TODO: Define CanDeleteObject permission in LoaiThuChi_CacQuyList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("LoaiThuChi_CacQuyListDeleteGroup"))
            //	return true;
            //return false;
        }
        #endregion //Authorization Rules

        #region Factory Methods
        private LoaiThuChi_CacQuyList()
        { /* require use of factory method */ }

        public static LoaiThuChi_CacQuyList NewLoaiThuChi_CacQuyList()
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a LoaiThuChi_CacQuyList");
            return new LoaiThuChi_CacQuyList();
        }

        public static LoaiThuChi_CacQuyList GetLoaiThuChi_CacQuyList()
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a LoaiThuChi_CacQuyList");
            return DataPortal.Fetch<LoaiThuChi_CacQuyList>(new FilterCriteria());
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
        #endregion //Filter Criteria

        #region Data Access - Fetch
        private void DataPortal_Fetch(FilterCriteria criteria)
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

        private void ExecuteFetch(SqlTransaction tr, FilterCriteria criteria)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_SelecttblLoaiThuChi_CacQuiesAll";


                using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                {
                    while (dr.Read())
                        this.Add(LoaiThuChi_CacQuy.GetLoaiThuChi_CacQuy(dr));
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
                    foreach (LoaiThuChi_CacQuy deletedChild in DeletedList)
                        deletedChild.DeleteSelf(tr);
                    DeletedList.Clear();

                    // loop through each non-deleted child object
                    foreach (LoaiThuChi_CacQuy child in this)
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
