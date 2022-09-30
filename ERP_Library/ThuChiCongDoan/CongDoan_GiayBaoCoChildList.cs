
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{
    [Serializable()]
    public class CongDoan_GiayBaoCoList : Csla.BusinessListBase<CongDoan_GiayBaoCoList, CongDoan_GiayBaoCo>
    {
        #region BindingList Overrides
        protected override object AddNewCore()
        {
            CongDoan_GiayBaoCo item = CongDoan_GiayBaoCo.NewCongDoan_GiayBaoCo();
            this.Add(item);
            return item;
        }
        #endregion //BindingList Overrides

        #region Factory Methods
        internal static CongDoan_GiayBaoCoList NewCongDoan_GiayBaoCoList()
        {
            return new CongDoan_GiayBaoCoList();
        }

        internal static CongDoan_GiayBaoCoList GetCongDoan_GiayBaoCoList(SafeDataReader dr)
        {
            return new CongDoan_GiayBaoCoList(dr);
        }

        public static CongDoan_GiayBaoCoList GetCongDoan_GiayBaoCoList(int maChungTu)
        {

            return DataPortal.Fetch<CongDoan_GiayBaoCoList>(new FilterCriteria(maChungTu));
        }

        private CongDoan_GiayBaoCoList()
        {
            MarkAsChild();
        }

        private CongDoan_GiayBaoCoList(SafeDataReader dr)
        {
            MarkAsChild();
            Fetch(dr);
        }
        #endregion //Factory Methods

        #region Filter Criteria
        [Serializable()]
        private class FilterCriteria
        {
            public int MaChungTu;

            public FilterCriteria(int maChungTu)
            {
                this.MaChungTu = maChungTu;
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
                cm.CommandText = "spd_SelecttblCongDoan_GiayBaoCosByMaChungTu";
                cm.Parameters.AddWithValue("@MaChungTu", criteria.MaChungTu);

                using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                {
                    while (dr.Read())
                        this.Add(CongDoan_GiayBaoCo.GetCongDoan_GiayBaoCo(dr));
                }
            }//using
        }

        private void Fetch(SafeDataReader dr)
        {
            RaiseListChangedEvents = false;

            while (dr.Read())
                this.Add(CongDoan_GiayBaoCo.GetCongDoan_GiayBaoCo(dr));

            RaiseListChangedEvents = true;
        }

        internal void Update(SqlTransaction tr, CongDoan_ChungTu parent)
        {
            RaiseListChangedEvents = false;

            // loop through each deleted child object
            foreach (CongDoan_GiayBaoCo deletedChild in DeletedList)
                deletedChild.DeleteSelf(tr);
            DeletedList.Clear();

            // loop through each non-deleted child object
            foreach (CongDoan_GiayBaoCo child in this)
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
