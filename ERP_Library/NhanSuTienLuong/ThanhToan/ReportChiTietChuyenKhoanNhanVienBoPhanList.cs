
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library.Report
{
    [Serializable()]
    public class ChiTietChuyenKhoanNhanVienBoPhanList : Csla.ReadOnlyListBase<ChiTietChuyenKhoanNhanVienBoPhanList, ChiTietChuyenKhoanNhanVienBoPhanChild>
    {

        #region Factory Methods
        private ChiTietChuyenKhoanNhanVienBoPhanList()
        { /* require use of factory method */ }

        public static ChiTietChuyenKhoanNhanVienBoPhanList GetChiTietChuyenKhoanNhanVienBoPhanList(DateTime TuNgay, DateTime DenNgay, int MaNganHang, int MaBoPhan, long MaNhanVien)
        {
            return DataPortal.Fetch<ChiTietChuyenKhoanNhanVienBoPhanList>(new FilterCriteria(TuNgay, DenNgay, MaNganHang, MaBoPhan, MaNhanVien));
        }
        public static ChiTietChuyenKhoanNhanVienBoPhanList GetTongHopChuyenKhoanNhanvien(DateTime TuNgay, DateTime DenNgay, int MaNganHang, int MaBoPhan, long MaNhanVien)
        {
            return DataPortal.Fetch<ChiTietChuyenKhoanNhanVienBoPhanList>(new FilterTongHopNhanVien(TuNgay, DenNgay, MaNganHang, MaBoPhan, MaNhanVien));
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
            public long MaNhanVien;
            public FilterCriteria(DateTime tuNgay, DateTime denNgay, int maNganHang, int maBoPhan, long maNhanVien)
            {
                TuNgay = tuNgay;
                DenNgay = denNgay;
                MaNganHang = maNganHang;
                MaBoPhan = maBoPhan;
                MaNhanVien = maNhanVien;
            }
        }

        [Serializable]
        private class FilterTongHopNhanVien : FilterCriteria
        {
            public FilterTongHopNhanVien(DateTime tuNgay, DateTime denNgay, int maNganHang, int maBoPhan, long maNhanVien)
                : base(tuNgay, denNgay, maNganHang, maBoPhan, maNhanVien)
            { }
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
                cm.CommandTimeout = 0;
                if (criteria is FilterTongHopNhanVien)
                    cm.CommandText = "spd_Report_TongHopChuyenKhoanNhanVien";
                else
                    cm.CommandText = "spd_Report_ChiTietChuyenKhoanNhanVienBoPhan";
                cm.Parameters.AddWithValue("@TuNgay", criteria.TuNgay);
                cm.Parameters.AddWithValue("@DenNgay", criteria.DenNgay);
                cm.Parameters.AddWithValue("@MaNganHang", criteria.MaNganHang);
                cm.Parameters.AddWithValue("@MaBoPhan", criteria.MaBoPhan);
                cm.Parameters.AddWithValue("@MaNhanVien", criteria.MaNhanVien);
                cm.Parameters.AddWithValue("@UserID", Security.CurrentUser.Info.UserID);

                using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                {
                    while (dr.Read())
                        this.Add(ChiTietChuyenKhoanNhanVienBoPhanChild.GetChiTietChuyenKhoanNhanVienBoPhanChild(dr));
                }
            }//using
        }
        #endregion //Data Access - Fetch
        #endregion //Data Access
    }
}
