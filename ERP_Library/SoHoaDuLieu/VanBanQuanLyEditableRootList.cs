using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{
    [Serializable()]
    public class VanBanQuanLyList : Csla.BusinessListBase<VanBanQuanLyList, VanBanQuanLy>
    {
        #region BindingList Overrides
        protected override object AddNewCore()
        {
            VanBanQuanLy item = VanBanQuanLy.NewVanBanQuanLy();
            this.Add(item);
            return item;
        }
        #endregion //BindingList Overrides

        #region Authorization Rules

        public static bool CanGetObject()
        {
            //TODO: Define CanGetObject permission in VanBanQuanLyList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("VanBanQuanLyListViewGroup"))
            //	return true;
            //return false;
        }

        public static bool CanAddObject()
        {
            //TODO: Define CanAddObject permission in VanBanQuanLyList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("VanBanQuanLyListAddGroup"))
            //	return true;
            //return false;
        }

        public static bool CanEditObject()
        {
            //TODO: Define CanEditObject permission in VanBanQuanLyList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("VanBanQuanLyListEditGroup"))
            //	return true;
            //return false;
        }

        public static bool CanDeleteObject()
        {
            //TODO: Define CanDeleteObject permission in VanBanQuanLyList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("VanBanQuanLyListDeleteGroup"))
            //	return true;
            //return false;
        }
        #endregion //Authorization Rules

        #region Factory Methods
        private VanBanQuanLyList()
        { /* require use of factory method */ }

        public static VanBanQuanLyList NewVanBanQuanLyList()
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a VanBanQuanLyList");
            return new VanBanQuanLyList();
        }

        public static VanBanQuanLyList GetVanBanQuanLyList()
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a VanBanQuanLyList");
            return DataPortal.Fetch<VanBanQuanLyList>(new FilterCriteria());
        }

        public static VanBanQuanLyList GetVanBanQuanLyList(int iNhomVanBan)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a VanBanQuanLyList");
            return DataPortal.Fetch<VanBanQuanLyList>(new FilterCriteriaByNhomVanBan(iNhomVanBan));
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

        private class FilterCriteriaByNhomVanBan
        {
            public int iNhomVanBan = 0;
            public FilterCriteriaByNhomVanBan(int _iNhomVanBan)
            {
                this.iNhomVanBan = _iNhomVanBan;
            }
        }
        #endregion //Filter Criteria

        #region Data Access - Fetch
        protected override void  DataPortal_Fetch(object criteria)
        {
            RaiseListChangedEvents = false;

            SqlTransaction tr;

            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection_Digital))
            {
                cn.Open();

                tr = cn.BeginTransaction();
                try
                {
                    ExecuteFetch(tr, criteria);
                    tr.Commit();
                }
                catch (SqlException ex)
                {
                    tr.Rollback();
                    HamDungChung.ThongBaoLoi(ex);
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
                if(criteria is FilterCriteria)
                    cm.CommandText = "spd_SelectVanBanQuanLiesAll";
                else if (criteria is FilterCriteriaByNhomVanBan)
                {
                    cm.CommandText = "spd_SelectVanBanQuanLiesByNhomVanban";
                    cm.Parameters.AddWithValue("@NhomVanban", ((FilterCriteriaByNhomVanBan)criteria).iNhomVanBan);
                }

                using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                {
                    while (dr.Read())
                        this.Add(VanBanQuanLy.GetVanBanQuanLy(dr));
                }
            }//using
        }
        #endregion //Data Access - Fetch


        #region Data Access - Update
        protected override void DataPortal_Update()
        {
            RaiseListChangedEvents = false;

            SqlTransaction tr;

            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection_Digital))
            {
                cn.Open();

                tr = cn.BeginTransaction();
                try
                {
                    // loop through each deleted child object
                    foreach (VanBanQuanLy deletedChild in DeletedList)
                        deletedChild.DeleteSelf(tr);
                    DeletedList.Clear();

                    // loop through each non-deleted child object
                    foreach (VanBanQuanLy child in this)
                    {
                        if (child.IsNew)
                            child.Insert(tr, null);
                        else
                            child.Update(tr, null);
                    }
                    tr.Commit();
                }
                catch (SqlException ex)
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
