
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{
    [Serializable()]
    public class SoDuDauKy_NganHangList : Csla.BusinessListBase<SoDuDauKy_NganHangList, SoDuDauKy_NganHang>
    {
        #region BindingList Overrides
        protected override object AddNewCore()
        {
            SoDuDauKy_NganHang item = SoDuDauKy_NganHang.NewSoDuDauKy_NganHang();
            this.Add(item);
            return item;
        }
        #endregion //BindingList Overrides

        #region Authorization Rules

        public static bool CanGetObject()
        {
            //TODO: Define CanGetObject permission in SoDuDauKy_NganHangList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("SoDuDauKy_NganHangListViewGroup"))
            //	return true;
            //return false;
        }

        public static bool CanAddObject()
        {
            //TODO: Define CanAddObject permission in SoDuDauKy_NganHangList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("SoDuDauKy_NganHangListAddGroup"))
            //	return true;
            //return false;
        }

        public static bool CanEditObject()
        {
            //TODO: Define CanEditObject permission in SoDuDauKy_NganHangList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("SoDuDauKy_NganHangListEditGroup"))
            //	return true;
            //return false;
        }

        public static bool CanDeleteObject()
        {
            //TODO: Define CanDeleteObject permission in SoDuDauKy_NganHangList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("SoDuDauKy_NganHangListDeleteGroup"))
            //	return true;
            //return false;
        }
        #endregion //Authorization Rules

        #region Factory Methods
        private SoDuDauKy_NganHangList()
        { /* require use of factory method */ }

        public static SoDuDauKy_NganHangList NewSoDuDauKy_NganHangList()
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a SoDuDauKy_NganHangList");
            return new SoDuDauKy_NganHangList();
        }

        public static SoDuDauKy_NganHangList GetSoDuDauKy_NganHangList()
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a SoDuDauKy_NganHangList");
            return DataPortal.Fetch<SoDuDauKy_NganHangList>(new FilterCriteria());
        }

        public static SoDuDauKy_NganHangList GetSoDuDauKy_NganHangList(int iMaKy)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a SoDuDauKy_NganHangList");
            return DataPortal.Fetch<SoDuDauKy_NganHangList>(new FilterCriteria_ByKy(iMaKy));
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

        private class FilterCriteria_ByKy
        {
            public int _iMaKy = 0;
            public FilterCriteria_ByKy(int iMaKy)
            {
                this._iMaKy = iMaKy;
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
                    cm.CommandText = "spd_SelecttblSoDuDauKy_NganHangsAll";
                }
                else if (criteria is FilterCriteria_ByKy)
                {
                    cm.CommandText = "spd_SelecttblSoDuDauKy_NganHangsByMaKy";
                    cm.Parameters.Add("@MaKy", ((FilterCriteria_ByKy)criteria)._iMaKy);
                    cm.Parameters.Add("@MaCongTy", Security.CurrentUser.Info.MaCongTy);
                }

                using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                {
                    while (dr.Read())
                        this.Add(SoDuDauKy_NganHang.GetSoDuDauKy_NganHang(dr));
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
                    foreach (SoDuDauKy_NganHang deletedChild in DeletedList)
                        deletedChild.DeleteSelf(tr);
                    DeletedList.Clear();

                    // loop through each non-deleted child object
                    foreach (SoDuDauKy_NganHang child in this)
                    {
                        if (child.IsNew)
                            child.Insert(tr,this);
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
