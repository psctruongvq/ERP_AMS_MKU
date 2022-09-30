
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{
    [Serializable()]
    public class ChungTu_GiayRutTienChildList : Csla.BusinessListBase<ChungTu_GiayRutTienChildList, ChungTu_GiayRutTienChild>
    {
        #region BindingList Overrides
        protected override object AddNewCore()
        {
            ChungTu_GiayRutTienChild item = ChungTu_GiayRutTienChild.NewChungTu_GiayRutTienChild();
            this.Add(item);
            return item;
        }
        #endregion //BindingList Overrides

        #region Factory Methods
        internal static ChungTu_GiayRutTienChildList NewChungTu_GiayRutTienChildList()
        {
            return new ChungTu_GiayRutTienChildList();
        }

        internal static ChungTu_GiayRutTienChildList GetChungTu_GiayRutTienChildList(SafeDataReader dr)
        {
            return new ChungTu_GiayRutTienChildList(dr);
        }

        public static ChungTu_GiayRutTienChildList GetChungTu_GiayRutTienChildList(long maChungTu)
        {
            return DataPortal.Fetch<ChungTu_GiayRutTienChildList>(new FilterCriteria_ByChungTu(maChungTu));
        }

        public static ChungTu_GiayRutTienChildList GetChungTu_GiayRutTienChildList_ByPhieu(long maPhieu)
        {
            return DataPortal.Fetch<ChungTu_GiayRutTienChildList>(new FilterCriteria_ByPhieu(maPhieu));
        }

        private ChungTu_GiayRutTienChildList()
        {
            MarkAsChild();
        }

        private ChungTu_GiayRutTienChildList(SafeDataReader dr)
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
            public long MaPhieu;

            public FilterCriteria(long maPhieu)
            {
                this.MaPhieu = maPhieu;
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

        private class FilterCriteria_ByPhieu
        {
            public long MaPhieu;

            public FilterCriteria_ByPhieu(long maPhieu)
            {
                this.MaPhieu = maPhieu;
            }
        }
        #endregion //Filter Criteria

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
                    cm.CommandText = "spd_SelecttblCT_GiayRutTiensAll";
                }
                else if (criteria is FilterCriteria_ByChungTu)
                {
                    cm.CommandText = "spd_SelecttblChungTu_GiayRutTiensByMaChungTu";
                    cm.Parameters.AddWithValue("@MaChungTu", ((FilterCriteria_ByChungTu)criteria).MaChungTu);
                }
                else if (criteria is FilterCriteria_ByPhieu)
                {
                    cm.CommandText = "spd_SelecttblCT_GiayRutTiensByMaGiayRutTien";
                    cm.Parameters.AddWithValue("@MaGiayRutTien", ((FilterCriteria_ByPhieu)criteria).MaPhieu);
                }

                using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                {
                    while (dr.Read())
                        this.Add(ChungTu_GiayRutTienChild.GetChungTu_GiayRutTienChild(dr));
                }
            }//using
        }

        private void Fetch(SafeDataReader dr)
        {
            RaiseListChangedEvents = false;

            while (dr.Read())
                this.Add(ChungTu_GiayRutTienChild.GetChungTu_GiayRutTienChild(dr));

            RaiseListChangedEvents = true;
        }

        internal void Update(SqlTransaction tr, ChungTu parent)
        {
            RaiseListChangedEvents = false;

            // loop through each deleted child object
            foreach (ChungTu_GiayRutTienChild deletedChild in DeletedList)
                deletedChild.DeleteSelf(tr);
            DeletedList.Clear();

            // loop through each non-deleted child object
            foreach (ChungTu_GiayRutTienChild child in this)
            {
                if (child.IsNew)
                    child.Insert(tr, parent);
                else
                    child.Update(tr, parent);
            }

            RaiseListChangedEvents = true;
        }

        public void DataPortal_Delete(SqlTransaction tr)
        {
            foreach (ChungTu_GiayRutTienChild child in this)
            {
                child.DeleteSelf(tr);
            }
        }
        #endregion //Data Access

    }
}
