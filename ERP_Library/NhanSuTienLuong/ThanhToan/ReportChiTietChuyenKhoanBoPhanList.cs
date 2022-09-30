
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library.Report
{
    [Serializable()]
    public class ChiTietChuyenKhoanBoPhanList : Csla.ReadOnlyListBase<ChiTietChuyenKhoanBoPhanList, ChiTietChuyenKhoanBoPhanChild>
    {

        #region Factory Methods
        private ChiTietChuyenKhoanBoPhanList()
        { /* require use of factory method */ }

        public static ChiTietChuyenKhoanBoPhanList GetChiTietChuyenKhoanBoPhanList(DateTime TuNgay, DateTime DenNgay, int MaNganHang, int MaBoPhan)
        {
            return DataPortal.Fetch<ChiTietChuyenKhoanBoPhanList>(new FilterCriteria(TuNgay, DenNgay, MaNganHang, MaBoPhan));
        }

        public static ChiTietChuyenKhoanBoPhanList GetChiTietChuyenByNhanVienKhongHopLe(int MaKyTinhLuong)
        {
            return DataPortal.Fetch<ChiTietChuyenKhoanBoPhanList>(new FilterCriteriaByNVKhongHopLe(MaKyTinhLuong));
        }
        #endregion //Factory Methods

        #region Data Access

        #region Filter Criteria
        [Serializable()]
        private class FilterCriteria
        {
            public DateTime TuNgay, DenNgay;
            public int MaNganHang;
            public int MaBoPhan;
            public FilterCriteria(DateTime tuNgay, DateTime denNgay, int maNganHang, int maBoPhan)
            {
                TuNgay = tuNgay;
                DenNgay = denNgay;
                MaNganHang = maNganHang;
                MaBoPhan = maBoPhan;
            }
        }

        [Serializable()]
        private class FilterCriteriaByNVKhongHopLe
        {   
            public int MaKyTinhLuong;            
            public FilterCriteriaByNVKhongHopLe(int maKyTinhLuong)
            {
                MaKyTinhLuong = maKyTinhLuong;
                
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
                    cm.CommandText = "spd_Report_ChiTietChuyenKhoanBoPhan";
                    cm.CommandTimeout = 0;
                    cm.Parameters.AddWithValue("@TuNgay", ((FilterCriteria)criteria).TuNgay);
                    cm.Parameters.AddWithValue("@DenNgay", ((FilterCriteria)criteria).DenNgay);
                    cm.Parameters.AddWithValue("@MaNganHang", ((FilterCriteria)criteria).MaNganHang);
                    cm.Parameters.AddWithValue("@MaBoPhan", ((FilterCriteria)criteria).MaBoPhan);
                    cm.Parameters.AddWithValue("@UserID", Security.CurrentUser.Info.UserID);
                }
                else if (criteria is FilterCriteriaByNVKhongHopLe)
                {
                    cm.CommandText = "spd_DanhSachChuyenKhoanKhongHopLe";
                    cm.CommandTimeout = 0;
                    cm.Parameters.AddWithValue("@MaKyTinhLuong", ((FilterCriteriaByNVKhongHopLe)criteria).MaKyTinhLuong);
                    cm.Parameters.AddWithValue("@UserID", Security.CurrentUser.Info.UserID);
                }

                using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                {
                    while (dr.Read())
                        this.Add(ChiTietChuyenKhoanBoPhanChild.GetChiTietChuyenKhoanBoPhanChild(dr));
                }
            }//using
        }
        #endregion //Data Access - Fetch
        #endregion //Data Access
    }
}
