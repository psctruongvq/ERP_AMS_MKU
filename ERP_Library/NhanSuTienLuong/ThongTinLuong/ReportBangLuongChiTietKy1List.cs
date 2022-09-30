
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library.Report
{
    [Serializable()]
    public class BangLuongChiTietKy1List : Csla.ReadOnlyListBase<BangLuongChiTietKy1List, BangLuongChiTietKy1Child>
    {

        #region Factory Methods
        private BangLuongChiTietKy1List()
        { /* require use of factory method */ }

        public static BangLuongChiTietKy1List GetBangLuongChiTietKy1List(int maKyTinhLuong, int maBoPhan, int maNganHang, string loaiNV, string hinhThuc)
        {
            return DataPortal.Fetch<BangLuongChiTietKy1List>(new FilterCriteria(maKyTinhLuong, maBoPhan, maNganHang, loaiNV, hinhThuc));
        }

        public static BangLuongChiTietKy1List GetBangLuongChiTietKy1List_KTL(int maKyTinhLuong, int maBoPhan, int maNganHang, string loaiNV, string hinhThuc)
        {
            return DataPortal.Fetch<BangLuongChiTietKy1List>(new FilterCriteriaKTL(maKyTinhLuong, maBoPhan, maNganHang, loaiNV, hinhThuc));
        }
        #endregion //Factory Methods

        #region Data Access

        #region Filter Criteria
        [Serializable()]
        private class FilterCriteria
        {
            public int MaKyTinhLuong;
            public int MaBoPhan;
            public int MaNganHang;
            public string LoaiNV, HinhThuc;

            public FilterCriteria(int maKyTinhLuong, int maBoPhan, int maNganHang, string loaiNV, string hinhThuc)
            {
                this.MaKyTinhLuong = maKyTinhLuong;
                this.MaBoPhan = maBoPhan;
                this.MaNganHang = maNganHang;
                this.LoaiNV = loaiNV;
                HinhThuc = hinhThuc;
            }
        }

        [Serializable()]
        private class FilterCriteriaKTL
        {
            public int MaKyTinhLuong;
            public int MaBoPhan;
            public int MaNganHang;
            public string LoaiNV, HinhThuc;

            public FilterCriteriaKTL(int maKyTinhLuong, int maBoPhan, int maNganHang, string loaiNV, string hinhThuc)
            {
                this.MaKyTinhLuong = maKyTinhLuong;
                this.MaBoPhan = maBoPhan;
                this.MaNganHang = maNganHang;
                this.LoaiNV = loaiNV;
                HinhThuc = hinhThuc;
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
                    cm.CommandText = "spd_Report_ChiTietLuongKy1";
                    cm.Parameters.AddWithValue("@MaKyTinhLuong", ((FilterCriteria)criteria).MaKyTinhLuong);
                    cm.Parameters.AddWithValue("@MaBoPhan", ((FilterCriteria)criteria).MaBoPhan);
                    cm.Parameters.AddWithValue("@MaNganHang", ((FilterCriteria)criteria).MaNganHang);
                    cm.Parameters.AddWithValue("@LoaiNV", ((FilterCriteria)criteria).LoaiNV);
                    cm.Parameters.AddWithValue("@HinhThuc", ((FilterCriteria)criteria).HinhThuc);
                    cm.Parameters.AddWithValue("@UserID", Security.CurrentUser.Info.UserID);
                }
                else if (criteria is FilterCriteriaKTL)
                {
                    cm.CommandText = "spd_Report_ChiTietLuongKy1_KTL";
                    cm.Parameters.AddWithValue("@MaKyTinhLuong", ((FilterCriteriaKTL)criteria).MaKyTinhLuong);
                    cm.Parameters.AddWithValue("@MaBoPhan", ((FilterCriteriaKTL)criteria).MaBoPhan);
                    cm.Parameters.AddWithValue("@MaNganHang", ((FilterCriteriaKTL)criteria).MaNganHang);
                    cm.Parameters.AddWithValue("@LoaiNV", ((FilterCriteriaKTL)criteria).LoaiNV);
                    cm.Parameters.AddWithValue("@HinhThuc", ((FilterCriteriaKTL)criteria).HinhThuc);
                    cm.Parameters.AddWithValue("@UserID", Security.CurrentUser.Info.UserID);
                }

                using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                {
                    while (dr.Read())
                        this.Add(BangLuongChiTietKy1Child.GetBangLuongChiTietKy1Child(dr));
                }
            }//using
        }
        #endregion //Data Access - Fetch
        #endregion //Data Access
    }
}
