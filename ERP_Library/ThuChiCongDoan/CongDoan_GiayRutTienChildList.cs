
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{
    [Serializable()]
    public class CongDoan_GiayRutTienList : Csla.BusinessListBase<CongDoan_GiayRutTienList, CongDoan_GiayRutTien>
    {
        #region BindingList Overrides
        protected override object AddNewCore()
        {
            CongDoan_GiayRutTien item = CongDoan_GiayRutTien.NewCongDoan_GiayRutTien();
            this.Add(item);
            return item;
        }
        #endregion //BindingList Overrides

        #region Factory Methods
        internal static CongDoan_GiayRutTienList NewCongDoan_GiayRutTienList()
        {
            return new CongDoan_GiayRutTienList();
        }

        internal static CongDoan_GiayRutTienList GetCongDoan_GiayRutTienList(SafeDataReader dr)
        {
            return new CongDoan_GiayRutTienList(dr);
        }

        public static CongDoan_GiayRutTienList GetCongDoan_GiayRutTienList(int maChungTu)
        {
            return DataPortal.Fetch<CongDoan_GiayRutTienList>(new FilterCriteria(maChungTu));
        }

        private CongDoan_GiayRutTienList()
        {
            MarkAsChild();
        }

        private CongDoan_GiayRutTienList(SafeDataReader dr)
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
            public long MaGiayRutTien;

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
                cm.CommandText = "spd_SelecttblCongDoan_GiayRutTiensByMaChungTu";
                cm.Parameters.AddWithValue("@MaChungTu", criteria.MaChungTu);

                using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                {
                    while (dr.Read())
                        this.Add(CongDoan_GiayRutTien.GetCongDoan_GiayRutTien(dr));
                }
            }//using
        }

        private void Fetch(SafeDataReader dr)
        {
            RaiseListChangedEvents = false;

            while (dr.Read())
                this.Add(CongDoan_GiayRutTien.GetCongDoan_GiayRutTien(dr));

            RaiseListChangedEvents = true;
        }

        internal void Update(SqlTransaction tr, CongDoan_ChungTu parent)
        {
            RaiseListChangedEvents = false;

            // loop through each deleted child object
            foreach (CongDoan_GiayRutTien deletedChild in DeletedList)
                deletedChild.DeleteSelf(tr);
            DeletedList.Clear();

            // loop through each non-deleted child object
            foreach (CongDoan_GiayRutTien child in this)
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
