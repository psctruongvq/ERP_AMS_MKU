
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library.Report
{
    [Serializable()]
    public class TongHopChuyenKhoanBoPhanList : Csla.ReadOnlyListBase<TongHopChuyenKhoanBoPhanList, TongHopChuyenKhoanBoPhanChild>
    {

        #region Factory Methods
        private TongHopChuyenKhoanBoPhanList()
        { /* require use of factory method */ }

        public static TongHopChuyenKhoanBoPhanList GetTongHopChuyenKhoanBoPhanList(DateTime TuNgay, DateTime DenNgay, int MaNganHang)
        {
            return DataPortal.Fetch<TongHopChuyenKhoanBoPhanList>(new FilterCriteria(TuNgay, DenNgay, MaNganHang));
        }
        #endregion //Factory Methods

        #region Data Access

        #region Filter Criteria
        [Serializable()]
        private class FilterCriteria
        {
            public DateTime TuNgay, DenNgay;
            public int MaNganHang;
            public FilterCriteria(DateTime tuNgay, DateTime denNgay, int maNganHang)
            {
                TuNgay = tuNgay;
                DenNgay = denNgay;
                MaNganHang = maNganHang;
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
                cm.CommandText = "spd_Report_TongHopChuyenKhoanBoPhan";
                cm.CommandTimeout = 0;
                cm.Parameters.AddWithValue("@TuNgay", criteria.TuNgay);
                cm.Parameters.AddWithValue("@DenNgay", criteria.DenNgay);
                cm.Parameters.AddWithValue("@MaNganHang", criteria.MaNganHang);
                cm.Parameters.AddWithValue("@UserID", Security.CurrentUser.Info.UserID);

                using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                {
                    while (dr.Read())
                        this.Add(TongHopChuyenKhoanBoPhanChild.GetTongHopChuyenKhoanBoPhanChild(dr));
                }
            }//using
        }
        #endregion //Data Access - Fetch
        #endregion //Data Access
    }
}
