
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library.Report
{
    [Serializable()]
    public class BangLuongChiTietKy2List : Csla.ReadOnlyListBase<BangLuongChiTietKy2List, BangLuongChiTietKy2Child>
    {

        #region Factory Methods
        private BangLuongChiTietKy2List()
        { /* require use of factory method */ }                

        public static BangLuongChiTietKy2List GetBangLuongChiTietKy2List(int maKyTinhLuong, int maBoPhan, int maNganHang, string loaiNV, string hinhThuc, int dieuKien, int Loai)
        {
            return DataPortal.Fetch<BangLuongChiTietKy2List>(new FilterCriteria(maKyTinhLuong, maBoPhan, maNganHang, loaiNV, hinhThuc, dieuKien, Loai));
        }
        public static BangLuongChiTietKy2List GetNgayTinhLuong(int maKyTinhLuong, int maBoPhan, int Loai)
        {
            return DataPortal.Fetch<BangLuongChiTietKy2List>(new FilterCriteriaNgayTinhLuong(maKyTinhLuong, maBoPhan, Loai));
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
            public string LoaiNV;
            public string HinhThuc;
            public int DieuKien;
            public int Loai;

            public FilterCriteria(int maKyTinhLuong, int maBoPhan, int maNganHang, string loaiNV, string hinhThuc, int dieuKien, int loai)
            {
                this.MaKyTinhLuong = maKyTinhLuong;
                this.MaBoPhan = maBoPhan;
                this.MaNganHang = maNganHang;
                this.LoaiNV = loaiNV;
                HinhThuc = hinhThuc;
                DieuKien = dieuKien;
                this.Loai = loai;
            }
        }
        private class FilterCriteriaNgayTinhLuong
        {
            public int MaKyTinhLuong;
            public int MaBoPhan;
            public int Loai;
            public FilterCriteriaNgayTinhLuong(int maKyTinhLuong, int maBoPhan, int loai)
            {
                this.MaKyTinhLuong = maKyTinhLuong;
                this.MaBoPhan = maBoPhan;
                this.Loai = loai;
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
                    cm.CommandText = "spd_Report_ChiTietLuongKy2";
                    cm.Parameters.AddWithValue("@MaKyTinhLuong", ((FilterCriteria)criteria).MaKyTinhLuong);
                    cm.Parameters.AddWithValue("@MaBoPhan", ((FilterCriteria)criteria).MaBoPhan);
                    cm.Parameters.AddWithValue("@MaNganHang", ((FilterCriteria)criteria).MaNganHang);
                    cm.Parameters.AddWithValue("@LoaiNV", ((FilterCriteria)criteria).LoaiNV);
                    cm.Parameters.AddWithValue("@HinhThuc", ((FilterCriteria)criteria).HinhThuc);
                    cm.Parameters.AddWithValue("@DieuKien", ((FilterCriteria)criteria).DieuKien);
                    cm.Parameters.AddWithValue("@UserID", Security.CurrentUser.Info.UserID);
                    cm.Parameters.AddWithValue("@Loai", ((FilterCriteria)criteria).Loai);
                }
                else
                {
                    cm.CommandText = "spd_GetNgayTinhLuong";
                    cm.Parameters.AddWithValue("@MaKyTinhLuong", ((FilterCriteriaNgayTinhLuong)criteria).MaKyTinhLuong);
                    cm.Parameters.AddWithValue("@MaBoPhan", ((FilterCriteriaNgayTinhLuong)criteria).MaBoPhan);
                    cm.Parameters.AddWithValue("@UserID", Security.CurrentUser.Info.UserID);
                    cm.Parameters.AddWithValue("@Loai", ((FilterCriteriaNgayTinhLuong)criteria).Loai);
                }
                using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                {
                    while (dr.Read())
                        this.Add(BangLuongChiTietKy2Child.GetBangLuongChiTietKy2Child(dr));
                }
            }//using
        }
        #endregion //Data Access - Fetch
        #endregion //Data Access
    }
}
