
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library.Report
{
    [Serializable()]
    public class ChiTietDangPhiNhanVienList : Csla.ReadOnlyListBase<ChiTietDangPhiNhanVienList, ChiTietDangPhiNhanVien>
    {

        #region Factory Methods
        private ChiTietDangPhiNhanVienList()
        { /* require use of factory method */ }

        public static ChiTietDangPhiNhanVienList GetChiTietDangPhiNhanVienList(int MaKyTinhLuong, long MaNhanVien)
        {
            return DataPortal.Fetch<ChiTietDangPhiNhanVienList>(new FilterCriteria(MaKyTinhLuong, MaNhanVien));
        }
        #endregion //Factory Methods

        #region Data Access

        #region Filter Criteria
        [Serializable()]
        private class FilterCriteria
        {
            public int MaKyTinhLuong;
            public long MaNhanVien;
            public FilterCriteria(int maKyTinhLuong, long maNhanVien)
            {
                MaKyTinhLuong = maKyTinhLuong;
                MaNhanVien = maNhanVien;
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
                cm.CommandText = "spd_Select_ChiTietThuNhapDangPhi";
                cm.Parameters.AddWithValue("@MaKyTinhLuong", criteria.MaKyTinhLuong);
                cm.Parameters.AddWithValue("@MaNhanVien", criteria.MaNhanVien);

                using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                {
                    while (dr.Read())
                        this.Add(ChiTietDangPhiNhanVien.GetChiTietDangPhiNhanVien(dr));
                }
            }//using
        }
        #endregion //Data Access - Fetch
        #endregion //Data Access
    }
}
