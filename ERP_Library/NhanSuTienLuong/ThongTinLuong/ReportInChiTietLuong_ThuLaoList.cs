
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library.Report
{
    [Serializable()]
    public class InChiTietLuong_ThuLaoList : Csla.ReadOnlyListBase<InChiTietLuong_ThuLaoList, InChiTietLuong_ThuLaoChild>
    {

        #region Factory Methods
        private InChiTietLuong_ThuLaoList()
        { /* require use of factory method */ }
        internal InChiTietLuong_ThuLaoList(SafeDataReader dr)
        {
            Fetch(dr);
        }

        public static InChiTietLuong_ThuLaoList GetInChiTietLuong_ThuLaoList(long MaNhanVien, int MaKyTinhLuong)
        {
            return DataPortal.Fetch<InChiTietLuong_ThuLaoList>(new FilterCriteria(MaNhanVien, MaKyTinhLuong));
        }
        #endregion //Factory Methods

        #region Data Access

        #region Filter Criteria
        [Serializable()]
        private class FilterCriteria
        {
            public long MaNhanVien;
            public int MaKyTinhLuong;

            public FilterCriteria(long maNhanVien, int maKyTinhLuong)
            {
                MaNhanVien = maNhanVien;
                MaKyTinhLuong = maKyTinhLuong;
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
                cm.CommandText = "spd_Report_InChiTietLuong";
                cm.Parameters.AddWithValue("@MaNhanVien", criteria.MaNhanVien);
                cm.Parameters.AddWithValue("@MaKyTinhLuong", criteria.MaKyTinhLuong);

                using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                {
                    dr.NextResult();

                    while (dr.Read())
                        this.Add(InChiTietLuong_ThuLaoChild.GetInChiTietLuong_ThuLaoChild(dr));
                }
            }//using
        }
        #endregion //Data Access - Fetch
        #endregion //Data Access

        internal void Fetch(SafeDataReader dr)
        {
            IsReadOnly = false;
            RaiseListChangedEvents = false;
            while (dr.Read())
                this.Add(InChiTietLuong_ThuLaoChild.GetInChiTietLuong_ThuLaoChild(dr));
            IsReadOnly = true;
            RaiseListChangedEvents = true;
        }
    }
}
