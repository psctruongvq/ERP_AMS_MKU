
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{
    [Serializable()]
    public class ChungTu_GiayRutTien_CacQuyList : Csla.BusinessListBase<ChungTu_GiayRutTien_CacQuyList, ChungTu_GiayRutTien_CacQuy>
    {
        #region BindingList Overrides
        protected override object AddNewCore()
        {
            ChungTu_GiayRutTien_CacQuy item = ChungTu_GiayRutTien_CacQuy.NewChungTu_GiayRutTien_CacQuy();
            this.Add(item);
            return item;
        }
        #endregion //BindingList Overrides

        #region Factory Methods
        internal static ChungTu_GiayRutTien_CacQuyList NewChungTu_GiayRutTien_CacQuyList()
        {
            return new ChungTu_GiayRutTien_CacQuyList();
        }

        internal static ChungTu_GiayRutTien_CacQuyList GetChungTu_GiayRutTien_CacQuyList(SafeDataReader dr)
        {
            return new ChungTu_GiayRutTien_CacQuyList(dr);
        }

        public static ChungTu_GiayRutTien_CacQuyList GetChungTu_GiayBaoCo_CacQuyList(long maGiayRutTien)
        {
            return DataPortal.Fetch<ChungTu_GiayRutTien_CacQuyList>(new FilterCriteria(maGiayRutTien));
        }

        public static ChungTu_GiayRutTien_CacQuyList GetChungTu_GiayBaoCo_CacQuyList_ByMaChungTu(long maChungTu)
        {
            return DataPortal.Fetch<ChungTu_GiayRutTien_CacQuyList>(new FilterCriteria_ByChungTu(maChungTu));
        }

        private ChungTu_GiayRutTien_CacQuyList()
        {
            MarkAsChild();
        }

        private ChungTu_GiayRutTien_CacQuyList(SafeDataReader dr)
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

        private class FilterCriteria_ByChungTu
        {
            public long MaChungTu;

            public FilterCriteria_ByChungTu(long maChungTu)
            {
                this.MaChungTu = maChungTu;
            }
        }
        #endregion //Filter Criteria

        #region Data Access
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
                    cm.CommandText = "spd_SelecttblChungTu_GiayRutTien_CacQuiesByMaGiayRutTien";
                    cm.Parameters.AddWithValue("@MaGiayRutTien", ((FilterCriteria)criteria).MaGiayRutTien);
                }
                else if (criteria is FilterCriteria_ByChungTu)
                {
                    cm.CommandText = "spd_SelecttblChungTu_GiayRutTien_CacQuiesByMaChungTu";
                    cm.Parameters.AddWithValue("@MaChungTu", ((FilterCriteria_ByChungTu)criteria).MaChungTu);
                }

                using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                {
                    while (dr.Read())
                        this.Add(ChungTu_GiayRutTien_CacQuy.GetChungTu_GiayRutTien_CacQuy(dr));
                }
            }//using
        }

        private void Fetch(SafeDataReader dr)
        {
            RaiseListChangedEvents = false;

            while (dr.Read())
                this.Add(ChungTu_GiayRutTien_CacQuy.GetChungTu_GiayRutTien_CacQuy(dr));

            RaiseListChangedEvents = true;
        }

        internal void Update(SqlTransaction tr, ChungTu_CacLoaiQuy parent)
        {
            RaiseListChangedEvents = false;

            // loop through each deleted child object
            foreach (ChungTu_GiayRutTien_CacQuy deletedChild in DeletedList)
                deletedChild.DeleteSelf(tr);
            DeletedList.Clear();

            // loop through each non-deleted child object
            foreach (ChungTu_GiayRutTien_CacQuy child in this)
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
