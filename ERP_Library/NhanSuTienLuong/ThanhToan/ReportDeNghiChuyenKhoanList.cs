
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library.Report
{
    [Serializable()]
    public class DeNghiChuyenKhoanList : Csla.ReadOnlyListBase<DeNghiChuyenKhoanList, DeNghiChuyenKhoanChild>
    {

        #region Factory Methods
        private DeNghiChuyenKhoanList()
        { /* require use of factory method */ }

        public static DeNghiChuyenKhoanList GetDeNghiChuyenKhoanList(long MaPhieu)
        {
            return DataPortal.Fetch<DeNghiChuyenKhoanList>(new FilterCriteria(MaPhieu));
        }

        public static DeNghiChuyenKhoanList GetDeNghiChuyenKhoanList_ByHDDV(long MaPhieu)
        {
            return DataPortal.Fetch<DeNghiChuyenKhoanList>(new FilterCriteria_ByHDDV(MaPhieu));
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

        private class FilterCriteria_ByHDDV
        {
            public long MaPhieu;
            public FilterCriteria_ByHDDV(long maPhieu)
            {
                MaPhieu = maPhieu;
            }
        }
        #endregion //Filter Criteria

        #region Data Access - Fetch
        private void DataPortal_Fetch(object criteria)
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

        private void ExecuteFetch(SqlTransaction tr, object criteria)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                if (criteria is FilterCriteria)
                {
                    cm.CommandText = "spd_Report_DeNghiChuyenKhoan";
                    cm.Parameters.AddWithValue("@MaPhieu", ((FilterCriteria)criteria).MaPhieu);

                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(DeNghiChuyenKhoanChild.GetDeNghiChuyenKhoanChild(dr));
                    }
                }
                else if (criteria is FilterCriteria_ByHDDV)
                {
                    cm.CommandText = "spd_Report_DeNghiChuyenKhoan_HDDV";
                    cm.Parameters.AddWithValue("@MaPhieu", ((FilterCriteria_ByHDDV)criteria).MaPhieu);

                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(DeNghiChuyenKhoanChild.GetDeNghiChuyenKhoanChild_New(dr));
                    }
                }
            }//using
        }
        #endregion //Data Access - Fetch
        #endregion //Data Access
    }
}
