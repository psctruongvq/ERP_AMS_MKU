
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library.Report
{
    [Serializable()]
    public class DeNghiThanhToanList : Csla.ReadOnlyListBase<DeNghiThanhToanList, DeNghiThanhToanChild>
    {

        #region Factory Methods
        private DeNghiThanhToanList()
        { /* require use of factory method */ }

        public static DeNghiThanhToanList GetDeNghiThanhToanList(long MaPhieu)
        {
            return DataPortal.Fetch<DeNghiThanhToanList>(new FilterCriteria(MaPhieu));
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
                MaPhieu = maPhieu;
            }
        }
        #endregion //Filter Criteria

        #region Data Access - Fetch
        private void DataPortal_Fetch(FilterCriteria criteria)
        {
            RaiseListChangedEvents = false;
            IsReadOnly = false;

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

            IsReadOnly = true;
            RaiseListChangedEvents = true;
        }

        private void ExecuteFetch(SqlTransaction tr, FilterCriteria criteria)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_Report_DeNghiThanhToan";
                cm.Parameters.AddWithValue("@MaPhieu", criteria.MaPhieu);

                using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                {
                    while (dr.Read())
                        this.Add(DeNghiThanhToanChild.GetDeNghiThanhToanChild(dr));
                }
            }//using
        }
        #endregion //Data Access - Fetch
        #endregion //Data Access
    }
}
