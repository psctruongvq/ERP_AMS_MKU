
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{
    [Serializable()]
    public class ChiTiet_GiayRutTien_CacQuyList : Csla.BusinessListBase<ChiTiet_GiayRutTien_CacQuyList, ChiTiet_GiayRutTien_CacQuy>
    {
        #region BindingList Overrides
        protected override object AddNewCore()
        {
            ChiTiet_GiayRutTien_CacQuy item = ChiTiet_GiayRutTien_CacQuy.NewChiTiet_GiayRutTien_CacQuy();
            this.Add(item);
            return item;
        }
        #endregion //BindingList Overrides

        #region Factory Methods
        internal static ChiTiet_GiayRutTien_CacQuyList NewChiTiet_GiayRutTien_CacQuyList()
        {
            return new ChiTiet_GiayRutTien_CacQuyList();
        }

        internal static ChiTiet_GiayRutTien_CacQuyList GetChiTiet_GiayRutTien_CacQuyList(SafeDataReader dr)
        {
            return new ChiTiet_GiayRutTien_CacQuyList(dr);
        }

        public static ChiTiet_GiayRutTien_CacQuyList GetChiTiet_GiayRutTien_CacQuyList(long maGiayRutTien)
        {
            return DataPortal.Fetch<ChiTiet_GiayRutTien_CacQuyList>(new FilterCriteria(maGiayRutTien));
        }
        private ChiTiet_GiayRutTien_CacQuyList()
        {
            MarkAsChild();
        }

        private ChiTiet_GiayRutTien_CacQuyList(SafeDataReader dr)
        {
            MarkAsChild();
            Fetch(dr);
        }
        #endregion //Factory Methods

        #region Filter Criteria
        [Serializable()]
        private class FilterCriteria
        {
            public long MaGiayRutTien;

            public FilterCriteria(long maGiayRutTien)
            {
                this.MaGiayRutTien = maGiayRutTien;
            }
        }
        #endregion //Filter Criteria

        #region Data Access
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
                cm.CommandText = "spd_SelecttblCT_GiayRutTien_CacQuiesByMaGiayRutTien";
                cm.Parameters.AddWithValue("@MaGiayRutTien", criteria.MaGiayRutTien);

                using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                {
                    while (dr.Read())
                        this.Add(ChiTiet_GiayRutTien_CacQuy.GetChiTiet_GiayRutTien_CacQuy(dr));
                }
            }//using
        }

        private void Fetch(SafeDataReader dr)
        {
            RaiseListChangedEvents = false;

            while (dr.Read())
                this.Add(ChiTiet_GiayRutTien_CacQuy.GetChiTiet_GiayRutTien_CacQuy(dr));

            RaiseListChangedEvents = true;
        }

        internal void Update(SqlTransaction tr, GiayRutTien_CacQuy parent)
        {
            RaiseListChangedEvents = false;

            // loop through each deleted child object
            foreach (ChiTiet_GiayRutTien_CacQuy deletedChild in DeletedList)
                deletedChild.DeleteSelf(tr);
            DeletedList.Clear();

            // loop through each non-deleted child object
            foreach (ChiTiet_GiayRutTien_CacQuy child in this)
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
