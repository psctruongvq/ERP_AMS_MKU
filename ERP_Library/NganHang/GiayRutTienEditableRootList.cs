
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{
    [Serializable()]
    public class GiayRutTienList : Csla.BusinessListBase<GiayRutTienList, GiayRutTien>
    {
        #region BindingList Overrides
        protected override object AddNewCore()
        {
            GiayRutTien item = GiayRutTien.NewGiayRutTien();
            this.Add(item);
            return item;
        }
        #endregion //BindingList Overrides

        #region Authorization Rules

        public static bool CanGetObject()
        {
            //TODO: Define CanGetObject permission in GiayRutTienList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("GiayRutTienListViewGroup"))
            //	return true;
            //return false;
        }

        public static bool CanAddObject()
        {
            //TODO: Define CanAddObject permission in GiayRutTienList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("GiayRutTienListAddGroup"))
            //	return true;
            //return false;
        }

        public static bool CanEditObject()
        {
            //TODO: Define CanEditObject permission in GiayRutTienList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("GiayRutTienListEditGroup"))
            //	return true;
            //return false;
        }

        public static bool CanDeleteObject()
        {
            //TODO: Define CanDeleteObject permission in GiayRutTienList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("GiayRutTienListDeleteGroup"))
            //	return true;
            //return false;
        }
        #endregion //Authorization Rules

        #region Factory Methods
        private GiayRutTienList()
        { /* require use of factory method */ }

        public static GiayRutTienList NewGiayRutTienList()
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a GiayRutTienList");
            return new GiayRutTienList();
        }

        public static GiayRutTienList GetGiayRutTienList()
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a GiayRutTienList");
            return DataPortal.Fetch<GiayRutTienList>(new FilterCriteria());
        }

        public static GiayRutTienList GetGiayRutTienList(DateTime dtTuNgay, DateTime dtDenNgay)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a GiayRutTienList");
            return DataPortal.Fetch<GiayRutTienList>(new FilterCriteria_ByNgay(dtTuNgay, dtDenNgay));
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
                    cm.CommandText = "spd_SelecttblGiayRutTiensAll";
                }
                else if (criteria is FilterCriteria_ByNgay)
                {
                    cm.CommandText = "spd_SelecttblGiayRutTiensAll_ByNgay";
                    cm.Parameters.AddWithValue("@TuNgay", ((FilterCriteria_ByNgay)criteria)._dtTuNgay);
                    cm.Parameters.AddWithValue("@DenNgay", ((FilterCriteria_ByNgay)criteria)._dtDenNgay);
                }
                
                using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                {
                    while (dr.Read())
                        this.Add(GiayRutTien.GetGiayRutTien(dr));
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
                    foreach (GiayRutTien deletedChild in DeletedList)
                        deletedChild.DeleteSelf(tr);
                    DeletedList.Clear();

                    // loop through each non-deleted child object
                    foreach (GiayRutTien child in this)
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
