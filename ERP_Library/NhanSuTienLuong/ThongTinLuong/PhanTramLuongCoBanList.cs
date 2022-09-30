
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{
    [Serializable()]
    public class PhanTramLuongCoBanList : Csla.BusinessListBase<PhanTramLuongCoBanList, PhanTramLuongCoBanChild>
    {
        private int MaKyTinhLuong;

        #region Authorization Rules

        public static bool CanGetObject()
        {
            //TODO: Define CanGetObject permission in PhanTramLuongCoBanList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("PhanTramLuongCoBanListViewGroup"))
            //	return true;
            //return false;
        }

        public static bool CanAddObject()
        {
            //TODO: Define CanAddObject permission in PhanTramLuongCoBanList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("PhanTramLuongCoBanListAddGroup"))
            //	return true;
            //return false;
        }

        public static bool CanEditObject()
        {
            //TODO: Define CanEditObject permission in PhanTramLuongCoBanList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("PhanTramLuongCoBanListEditGroup"))
            //	return true;
            //return false;
        }

        public static bool CanDeleteObject()
        {
            //TODO: Define CanDeleteObject permission in PhanTramLuongCoBanList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("PhanTramLuongCoBanListDeleteGroup"))
            //	return true;
            //return false;
        }
        #endregion //Authorization Rules

        #region Factory Methods
        private PhanTramLuongCoBanList()
        { /* require use of factory method */ }

        public static PhanTramLuongCoBanList NewPhanTramLuongCoBanList()
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a PhanTramLuongCoBanList");
            return new PhanTramLuongCoBanList();
        }

        public static PhanTramLuongCoBanList GetPhanTramLuongCoBanList(int maKyTinhLuong)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a PhanTramLuongCoBanList");
            return DataPortal.Fetch<PhanTramLuongCoBanList>(new FilterCriteria(maKyTinhLuong));
        }
        #endregion //Factory Methods

        #region Data Access

        #region Filter Criteria
        [Serializable()]
        private class FilterCriteria
        {
            public int MaKyTinhLuong;

            public FilterCriteria(int maKyTinhLuong)
            {
                this.MaKyTinhLuong = maKyTinhLuong;
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
                    MaKyTinhLuong = criteria.MaKyTinhLuong;
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
                cm.CommandText = "spd_Select_PhanTramLuongCoBanList";
                cm.Parameters.AddWithValue("@MaKyTinhLuong", criteria.MaKyTinhLuong);
                cm.Parameters.AddWithValue("@UserID", ERP_Library.Security.CurrentUser.Info.UserID);

                using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                {
                    while (dr.Read())
                        this.Add(PhanTramLuongCoBanChild.GetPhanTramLuongCoBanChild(dr));
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
                    foreach (PhanTramLuongCoBanChild deletedChild in DeletedList)
                        deletedChild.DeleteSelf(tr);
                    DeletedList.Clear();

                    // loop through each non-deleted child object
                    foreach (PhanTramLuongCoBanChild child in this)
                    {
                        if (child.IsNew)
                            child.Insert(tr, MaKyTinhLuong);
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