
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{
    [Serializable()]
    public class GiayBanNgoaiTeList : Csla.BusinessListBase<GiayBanNgoaiTeList, GiayBanNgoaiTe>
    {
        #region BindingList Overrides
        protected override object AddNewCore()
        {
            GiayBanNgoaiTe item = GiayBanNgoaiTe.NewGiayBanNgoaiTe();
            this.Add(item);
            return item;
        }
        #endregion //BindingList Overrides

        #region Authorization Rules

        public static bool CanGetObject()
        {
            //TODO: Define CanGetObject permission in GiayBanNgoaiTeList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("GiayBanNgoaiTeListViewGroup"))
            //	return true;
            //return false;
        }

        public static bool CanAddObject()
        {
            //TODO: Define CanAddObject permission in GiayBanNgoaiTeList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("GiayBanNgoaiTeListAddGroup"))
            //	return true;
            //return false;
        }

        public static bool CanEditObject()
        {
            //TODO: Define CanEditObject permission in GiayBanNgoaiTeList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("GiayBanNgoaiTeListEditGroup"))
            //	return true;
            //return false;
        }

        public static bool CanDeleteObject()
        {
            //TODO: Define CanDeleteObject permission in GiayBanNgoaiTeList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("GiayBanNgoaiTeListDeleteGroup"))
            //	return true;
            //return false;
        }
        #endregion //Authorization Rules

        #region Factory Methods
        private GiayBanNgoaiTeList()
        { /* require use of factory method */ }

        public static GiayBanNgoaiTeList NewGiayBanNgoaiTeList()
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a GiayBanNgoaiTeList");
            return new GiayBanNgoaiTeList();
        }

        public static GiayBanNgoaiTeList GetGiayBanNgoaiTeList()
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a GiayBanNgoaiTeList");
            return DataPortal.Fetch<GiayBanNgoaiTeList>(new FilterCriteria());
        }

        public static GiayBanNgoaiTeList GetGiayBanNgoaiTeList(DateTime dtTuNgay, DateTime dtDenNgay)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a GiayBanNgoaiTeList");
            return DataPortal.Fetch<GiayBanNgoaiTeList>(new FilterCriteria_ByNgay(dtTuNgay, dtDenNgay));
        }

        public static GiayBanNgoaiTeList GetGiayBanNgoaiTeList_ByNganHang(int nganHangBan, int userID)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a GiayBanNgoaiTeList");
            return DataPortal.Fetch<GiayBanNgoaiTeList>(new FilterCriteria_ByNganHang(nganHangBan, userID));
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
            public DateTime _dtTuNgay;
            public DateTime _dtDenNgay;
            public FilterCriteria_ByNgay(DateTime dtTuNgay, DateTime dtDenNgay)
            {
                this._dtTuNgay = dtTuNgay;
                this._dtDenNgay = dtDenNgay;
            }
        }

        private class FilterCriteria_ByNganHang
        {
            public int NganHangBan;
            public int UserID;

            public FilterCriteria_ByNganHang(int nganHangBan, int userID)
            {
                this.NganHangBan = nganHangBan;
                this.UserID = userID;
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

        private void ExecuteFetch(SqlTransaction tr, Object criteria)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                if (criteria is FilterCriteria)
                {
                    cm.CommandText = "spd_SelecttblGiayBanNgoaiTesAll";
                }
                else if (criteria is FilterCriteria_ByNgay)
                {
                    cm.CommandText = "spd_SelecttblGiayBanNgoaiTe_ByNgay";
                    cm.Parameters.AddWithValue("@TuNgay", ((FilterCriteria_ByNgay)criteria)._dtTuNgay);
                    cm.Parameters.AddWithValue("@DenNgay", ((FilterCriteria_ByNgay)criteria)._dtDenNgay);
                    cm.Parameters.AddWithValue("@UserID", Security.CurrentUser.Info.UserID);
                }
 
                using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                {
                    while (dr.Read())
                        this.Add(GiayBanNgoaiTe.GetGiayBanNgoaiTe(dr));
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
                    foreach (GiayBanNgoaiTe deletedChild in DeletedList)
                        deletedChild.DeleteSelf(tr);
                    DeletedList.Clear();

                    // loop through each non-deleted child object
                    foreach (GiayBanNgoaiTe child in this)
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
