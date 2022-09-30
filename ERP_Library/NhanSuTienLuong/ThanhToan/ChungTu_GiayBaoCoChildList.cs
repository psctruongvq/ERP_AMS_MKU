
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{
    [Serializable()]
    public class ChungTu_GiayBaoCoList : Csla.BusinessListBase<ChungTu_GiayBaoCoList, ChungTu_GiayBaoCo>
    {

        #region Factory Methods
        internal static ChungTu_GiayBaoCoList NewChungTu_GiayBaoCoList()
        {
            return new ChungTu_GiayBaoCoList();
        }

        internal static ChungTu_GiayBaoCoList GetChungTu_GiayBaoCoList(SafeDataReader dr)
        {
            return new ChungTu_GiayBaoCoList(dr);
        }

        public static ChungTu_GiayBaoCoList GetChungTu_GiayBaoCoList(long maChungTu)
        {
            return DataPortal.Fetch<ChungTu_GiayBaoCoList>(new FilterCriteriaByChungTu(maChungTu));
        }


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

        private class FilterCriteriaByChungTu
        {
            public long MaChungTu;

            public FilterCriteriaByChungTu(long maChungTu)
            {
                this.MaChungTu = maChungTu;
            }
        }
        #endregion //Filter Criteria

        private ChungTu_GiayBaoCoList()
        {
            MarkAsChild();
        }

        private ChungTu_GiayBaoCoList(SafeDataReader dr)
        {
            MarkAsChild();
            Fetch(dr);
        }
        #endregion //Factory Methods


        #region Data Access

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
                if (criteria is FilterCriteriaByChungTu)
                {
                    cm.CommandText = "spd_SelecttblChungTu_GiayBaoCosByAndMaChungTu";
                    cm.Parameters.AddWithValue("@MaChungTu", ((FilterCriteriaByChungTu)criteria).MaChungTu);
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(ChungTu_GiayBaoCo.GetChungTu_GiayBaoCo(dr));
                    }
                }
             
            }//using
        }
        #endregion

        private void Fetch(SafeDataReader dr)
        {
            RaiseListChangedEvents = false;

            while (dr.Read())
                this.Add(ChungTu_GiayBaoCo.GetChungTu_GiayBaoCo(dr));

            RaiseListChangedEvents = true;
        }

        internal void Update(SqlTransaction tr, ChungTu parent)
        {
            RaiseListChangedEvents = false;

            // loop through each deleted child object
            foreach (ChungTu_GiayBaoCo deletedChild in DeletedList)
                deletedChild.DeleteSelf(tr);
            DeletedList.Clear();

            // loop through each non-deleted child object
            foreach (ChungTu_GiayBaoCo child in this)
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
            foreach (ChungTu_GiayBaoCo child in this)
            {
                child.DeleteSelf(tr);
            }
        }
        #endregion //Data Access

    }
}
