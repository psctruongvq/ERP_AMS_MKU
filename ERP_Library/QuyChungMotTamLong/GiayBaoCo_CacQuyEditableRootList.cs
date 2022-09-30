
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{
    [Serializable()]
    public class GiayBaoCo_CacQuyList : Csla.BusinessListBase<GiayBaoCo_CacQuyList, GiayBaoCo_CacQuy>
    {
        #region BindingList Overrides
        protected override object AddNewCore()
        {
            GiayBaoCo_CacQuy item = GiayBaoCo_CacQuy.NewGiayBaoCo_CacQuy();
            this.Add(item);
            return item;
        }
        #endregion //BindingList Overrides

        #region Authorization Rules

        public static bool CanGetObject()
        {
            //TODO: Define CanGetObject permission in GiayBaoCo_CacQuyList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("GiayBaoCo_CacQuyListViewGroup"))
            //	return true;
            //return false;
        }

        public static bool CanAddObject()
        {
            //TODO: Define CanAddObject permission in GiayBaoCo_CacQuyList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("GiayBaoCo_CacQuyListAddGroup"))
            //	return true;
            //return false;
        }

        public static bool CanEditObject()
        {
            //TODO: Define CanEditObject permission in GiayBaoCo_CacQuyList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("GiayBaoCo_CacQuyListEditGroup"))
            //	return true;
            //return false;
        }

        public static bool CanDeleteObject()
        {
            //TODO: Define CanDeleteObject permission in GiayBaoCo_CacQuyList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("GiayBaoCo_CacQuyListDeleteGroup"))
            //	return true;
            //return false;
        }
        #endregion //Authorization Rules

        #region Factory Methods
        private GiayBaoCo_CacQuyList()
        { /* require use of factory method */ }

        public static GiayBaoCo_CacQuyList NewGiayBaoCo_CacQuyList()
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a GiayBaoCo_CacQuyList");
            return new GiayBaoCo_CacQuyList();
        }

        public static GiayBaoCo_CacQuyList GetGiayBaoCo_CacQuyList()
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a GiayBaoCo_CacQuyList");
            return DataPortal.Fetch<GiayBaoCo_CacQuyList>(new FilterCriteria());
        }

        public static GiayBaoCo_CacQuyList GetGiayBaoCo_CacQuyList(DateTime TuNgay, DateTime DenNgay, int LoaiGBC, int LoaiDeNghi)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a GiayBaoCo_CacQuyList");
            return DataPortal.Fetch<GiayBaoCo_CacQuyList>(new FilterCriteria_ByNgay(TuNgay, DenNgay, LoaiGBC, LoaiDeNghi));
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
            public DateTime _tuNgay;
            public DateTime _denNgay;
            public int _loaiGBC;
            public int _loaiDenghi;
            public FilterCriteria_ByNgay(DateTime TuNgay, DateTime DenNgay, int LoaiGBC, int LoaiDeNghi)
            {
                this._tuNgay = TuNgay;
                this._denNgay = DenNgay;
                this._loaiGBC = LoaiGBC;
                this._loaiDenghi = LoaiDeNghi;
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
                    cm.CommandText = "spd_SelecttblGiayBaoCo_CacQuiesAll";
                }
                else if (criteria is FilterCriteria_ByNgay)
                {
                    cm.CommandText = "spd_SelecttblGiayBaoCo_CacQuies_ByNgay";
                    cm.Parameters.AddWithValue("@TuNgay", ((FilterCriteria_ByNgay)criteria)._tuNgay);
                    cm.Parameters.AddWithValue("@DenNgay", ((FilterCriteria_ByNgay)criteria)._denNgay);
                    cm.Parameters.AddWithValue("@LoaiGBC", ((FilterCriteria_ByNgay)criteria)._loaiGBC);
                    cm.Parameters.AddWithValue("@LoaiDeNghi", ((FilterCriteria_ByNgay)criteria)._loaiDenghi);
                    cm.Parameters.AddWithValue("@UserID", Security.CurrentUser.Info.UserID);
                }

                using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                {
                    while (dr.Read())
                        this.Add(GiayBaoCo_CacQuy.GetGiayBaoCo_CacQuy(dr));
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
                    foreach (GiayBaoCo_CacQuy deletedChild in DeletedList)
                        deletedChild.DeleteSelf(tr);
                    DeletedList.Clear();

                    // loop through each non-deleted child object
                    foreach (GiayBaoCo_CacQuy child in this)
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
