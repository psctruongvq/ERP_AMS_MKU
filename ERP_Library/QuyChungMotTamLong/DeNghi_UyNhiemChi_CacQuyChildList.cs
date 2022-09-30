
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{
    [Serializable()]
    public class DeNghi_UyNhiemChi_CacQuyList : Csla.BusinessListBase<DeNghi_UyNhiemChi_CacQuyList, DeNghi_UyNhiemChi_CacQuy>
    {
        #region BindingList Overrides
        protected override object AddNewCore()
        {
            DeNghi_UyNhiemChi_CacQuy item = DeNghi_UyNhiemChi_CacQuy.NewDeNghi_UyNhiemChi_CacQuy();
            this.Add(item);
            return item;
        }
        #endregion //BindingList Overrides

        #region Factory Methods
        internal static DeNghi_UyNhiemChi_CacQuyList NewDeNghi_UyNhiemChi_CacQuyList()
        {
            return new DeNghi_UyNhiemChi_CacQuyList();
        }

        internal static DeNghi_UyNhiemChi_CacQuyList GetDeNghi_UyNhiemChi_CacQuyList(SafeDataReader dr)
        {
            return new DeNghi_UyNhiemChi_CacQuyList(dr);
        }

        public static DeNghi_UyNhiemChi_CacQuyList GetDeNghi_UyNhiemChi_CacQuyList(long maUyNhiemChi)
        {
            return DataPortal.Fetch<DeNghi_UyNhiemChi_CacQuyList>(new FilterCriteria(maUyNhiemChi));
        }

        private DeNghi_UyNhiemChi_CacQuyList()
        {
            MarkAsChild();
        }

        private DeNghi_UyNhiemChi_CacQuyList(SafeDataReader dr)
        {
            MarkAsChild();
            Fetch(dr);
        }
        #endregion //Factory Methods


        #region Data Access
        #region Filter Criteria
        [Serializable()]
        private class FilterCriteria
        {
            public long MaUyNhiemChi;

            public FilterCriteria(long maUyNhiemChi)
            {
                this.MaUyNhiemChi = maUyNhiemChi;
            }
        }
        #endregion //Filter Criteria

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
                cm.CommandText = "spd_SelecttblDeNghi_UyNhiemChi_CacQuiesByMaUyNhiemChi";
                cm.Parameters.AddWithValue("@MaUyNhiemChi", criteria.MaUyNhiemChi);

                using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                {
                    while (dr.Read())
                        this.Add(DeNghi_UyNhiemChi_CacQuy.GetDeNghi_UyNhiemChi_CacQuy(dr));
                }
            }//using
        }

        private void Fetch(SafeDataReader dr)
        {
            RaiseListChangedEvents = false;

            while (dr.Read())
                this.Add(DeNghi_UyNhiemChi_CacQuy.GetDeNghi_UyNhiemChi_CacQuy(dr));

            RaiseListChangedEvents = true;
        }

        internal void Update(SqlTransaction tr, UyNhiemChi_CacQuy parent)
        {
            RaiseListChangedEvents = false;

            // loop through each deleted child object
            foreach (DeNghi_UyNhiemChi_CacQuy deletedChild in DeletedList)
                deletedChild.DeleteSelf(tr);
            DeletedList.Clear();

            // loop through each non-deleted child object
            foreach (DeNghi_UyNhiemChi_CacQuy child in this)
            {
                if (child.IsNew)
                    child.Insert(tr, parent);
                else
                    child.Update(tr, parent);
            }

            RaiseListChangedEvents = true;
        }
        #endregion //Data Access

    }
}
