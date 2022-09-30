
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library.Report
{
    [Serializable()]
    public class ReportDeNghiChuyenKhoan_CacQuyList : Csla.ReadOnlyListBase<ReportDeNghiChuyenKhoan_CacQuyList, ReportDeNghiChuyenKhoan_CacQuy>
    {

        #region Factory Methods
        private ReportDeNghiChuyenKhoan_CacQuyList()
        { /* require use of factory method */ }

        public static ReportDeNghiChuyenKhoan_CacQuyList GetDeNghiChuyenKhoanList(long MaPhieu)
        {
            return DataPortal.Fetch<ReportDeNghiChuyenKhoan_CacQuyList>(new FilterCriteria(MaPhieu));
        }

        public static ReportDeNghiChuyenKhoan_CacQuyList GetDeNghiChuyenKhoanList_CacQuy(long MaPhieu)
        {
            return DataPortal.Fetch<ReportDeNghiChuyenKhoan_CacQuyList>(new FilterCriteria_CacQuy(MaPhieu));
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

        private class FilterCriteria_CacQuy
        {
            public long MaPhieu;
            public FilterCriteria_CacQuy(long maPhieu)
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
                            this.Add(ReportDeNghiChuyenKhoan_CacQuy.GetDeNghiChuyenKhoanChild(dr));
                    }
                }
                else if (criteria is FilterCriteria_CacQuy)
                {
                    cm.CommandText = "spd_Report_DeNghiChuyenKhoan_CacQuy";
                    cm.Parameters.AddWithValue("@MaPhieu", ((FilterCriteria_CacQuy)criteria).MaPhieu);

                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(ReportDeNghiChuyenKhoan_CacQuy.GetDeNghiChuyenKhoanChild_New(dr));
                    }
                }
            }//using
        }
        #endregion //Data Access - Fetch
        #endregion //Data Access
    }
}
