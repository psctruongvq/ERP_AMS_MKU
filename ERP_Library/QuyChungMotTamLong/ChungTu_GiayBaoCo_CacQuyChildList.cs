
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{
    [Serializable()]
    public class ChungTu_GiayBaoCo_CacQuyList : Csla.BusinessListBase<ChungTu_GiayBaoCo_CacQuyList, ChungTu_GiayBaoCo_CacQuy>
    {
        #region BindingList Overrides
        protected override object AddNewCore()
        {
            ChungTu_GiayBaoCo_CacQuy item = ChungTu_GiayBaoCo_CacQuy.NewChungTu_GiayBaoCo_CacQuy();
            this.Add(item);
            return item;
        }
        #endregion //BindingList Overrides

        #region Factory Methods
        internal static ChungTu_GiayBaoCo_CacQuyList NewChungTu_GiayBaoCo_CacQuyList()
        {
            return new ChungTu_GiayBaoCo_CacQuyList();
        }

        internal static ChungTu_GiayBaoCo_CacQuyList GetChungTu_GiayBaoCo_CacQuyList(SafeDataReader dr)
        {
            return new ChungTu_GiayBaoCo_CacQuyList(dr);
        }

        public static ChungTu_GiayBaoCo_CacQuyList GetChungTu_GiayBaoCo_CacQuyList(long maChungTu)
        {
            return DataPortal.Fetch<ChungTu_GiayBaoCo_CacQuyList>(new FilterCriteria(maChungTu));
        }

        private ChungTu_GiayBaoCo_CacQuyList()
        {
            MarkAsChild();
        }

        private ChungTu_GiayBaoCo_CacQuyList(SafeDataReader dr)
        {
            MarkAsChild();
            Fetch(dr);
        }
        #endregion //Factory Methods

        #region Filter Criteria
        [Serializable()]
        private class FilterCriteria
        {
            public long MaChungTu;

            public FilterCriteria(long maChungTu)
            {
                this.MaChungTu = maChungTu;
            }
        }
        #endregion //Filter Criteria

        #region Data Access
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
                cm.CommandText = "spd_SelecttblChungTu_GiayBaoCo_CacQuiesByMaChungTu";
                cm.Parameters.AddWithValue("@MaChungTu", criteria.MaChungTu);

                using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                {
                    while (dr.Read())
                        this.Add(ChungTu_GiayBaoCo_CacQuy.GetChungTu_GiayBaoCo_CacQuy(dr));
                }
            }//using
        }
        #endregion //Data Access - Fetch

        private void Fetch(SafeDataReader dr)
        {
            RaiseListChangedEvents = false;

            while (dr.Read())
                this.Add(ChungTu_GiayBaoCo_CacQuy.GetChungTu_GiayBaoCo_CacQuy(dr));

            RaiseListChangedEvents = true;
        }

        internal void Update(SqlTransaction tr, ChungTu_CacLoaiQuy parent)
        {
            RaiseListChangedEvents = false;

            // loop through each deleted child object
            foreach (ChungTu_GiayBaoCo_CacQuy deletedChild in DeletedList)
                deletedChild.DeleteSelf(tr);
            DeletedList.Clear();

            // loop through each non-deleted child object
            foreach (ChungTu_GiayBaoCo_CacQuy child in this)
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
