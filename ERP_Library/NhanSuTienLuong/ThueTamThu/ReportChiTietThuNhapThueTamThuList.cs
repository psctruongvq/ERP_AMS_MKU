
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library.Report
{
    [Serializable()]
    public class ChiTietThuNhapThueTamThuList : Csla.ReadOnlyListBase<ChiTietThuNhapThueTamThuList, ChiTietThuNhapThueTamThuChild>
    {

        #region Factory Methods
        private ChiTietThuNhapThueTamThuList()
        { /* require use of factory method */ }

        public static ChiTietThuNhapThueTamThuList GetChiTietThuNhapThueTamThuList(DateTime TuNgay, DateTime DenNgay)
        {
            return DataPortal.Fetch<ChiTietThuNhapThueTamThuList>(new FilterCriteria(TuNgay, DenNgay));
        }
        #endregion //Factory Methods

        #region Data Access

        #region Filter Criteria
        [Serializable()]
        private class FilterCriteria
        {
            public DateTime TuNgay, DenNgay;
            public FilterCriteria(DateTime tuNgay, DateTime denNgay)
            {
                TuNgay = tuNgay;
                DenNgay = denNgay;
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
                cm.CommandText = "spd_Report_ChiTietThuNhap_ThueTamThu";
                cm.Parameters.AddWithValue("@TuNgay", criteria.TuNgay);
                cm.Parameters.AddWithValue("@DenNgay", criteria.DenNgay);
                cm.Parameters.AddWithValue("@UserID", Security.CurrentUser.Info.UserID);

                using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                {
                    while (dr.Read())
                        this.Add(ChiTietThuNhapThueTamThuChild.GetChiTietThuNhapThueTamThuChild(dr));
                }
            }//using
        }
        #endregion //Data Access - Fetch
        #endregion //Data Access
    }
}
