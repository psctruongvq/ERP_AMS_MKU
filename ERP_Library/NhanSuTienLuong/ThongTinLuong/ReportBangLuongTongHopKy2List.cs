
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library.Report
{
    [Serializable()]
    public class BangLuongTongHopKy2List : Csla.ReadOnlyListBase<BangLuongTongHopKy2List, BangLuongTongHopKy2Child>
    {

        #region Factory Methods
        private BangLuongTongHopKy2List()
        { /* require use of factory method */ }

        public static BangLuongTongHopKy2List GetBangLuongTongHopKy2List(int MaKyTinhLuong, string LoaiNV, string HinhThuc, int MaNganHang, int DieuKien,int Loai)
        {
            return DataPortal.Fetch<BangLuongTongHopKy2List>(new FilterCriteria(MaKyTinhLuong, LoaiNV, HinhThuc, MaNganHang, DieuKien, Loai));
        }
        public static BangLuongTongHopKy2List GetBangLuongNganHangKy2List(int MaKyTinhLuong, string LoaiNV, int DieuKien, int Loai)
        {
            return DataPortal.Fetch<BangLuongTongHopKy2List>(new FilterNganHang(MaKyTinhLuong, LoaiNV, DieuKien, Loai));
        }
        #endregion //Factory Methods

        #region Data Access

        #region Filter Criteria
        [Serializable()]
        private class FilterCriteria
        {
            public int MaKyTinhLuong;
            public string LoaiNV, HinhThuc;
            public int MaNganHang, DieuKien;
            public int Loai;

            public FilterCriteria(int maKyTinhLuong, string loaiNV, string hinhThuc, int maNganHang, int dieuKien, int loai)
            {
                MaKyTinhLuong = maKyTinhLuong;
                LoaiNV = loaiNV;
                HinhThuc = hinhThuc;
                MaNganHang = maNganHang;
                DieuKien = dieuKien;
                this.Loai = loai;
            }
        }

        [Serializable()]
        private class FilterNganHang
        {
            public int MaKyTinhLuong;
            public string LoaiNV;
            public int DieuKien;
            public int Loai;
            public FilterNganHang(int maKyTinhLuong, string loaiNV, int dieuKien, int loai)
            {
                MaKyTinhLuong = maKyTinhLuong;
                LoaiNV = loaiNV;
                DieuKien = dieuKien;
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
                    cm.CommandText = "spd_Report_TongHopLuongKy2";
                    cm.Parameters.AddWithValue("@MaKyTinhLuong", ((FilterCriteria)criteria).MaKyTinhLuong);
                    cm.Parameters.AddWithValue("@LoaiNV", ((FilterCriteria)criteria).LoaiNV);
                    cm.Parameters.AddWithValue("@HinhThuc", ((FilterCriteria)criteria).HinhThuc);
                    cm.Parameters.AddWithValue("@MaNganHang", ((FilterCriteria)criteria).MaNganHang);
                    cm.Parameters.AddWithValue("@DieuKien", ((FilterCriteria)criteria).DieuKien);
                    cm.Parameters.AddWithValue("@UserID", Security.CurrentUser.Info.UserID);
                    cm.Parameters.AddWithValue("@Loai", ((FilterCriteria)criteria).Loai);
                }
                else
                {
                    cm.CommandText = "spd_Report_NganHangLuongKy2";
                    cm.Parameters.AddWithValue("@MaKyTinhLuong", ((FilterNganHang)criteria).MaKyTinhLuong);
                    cm.Parameters.AddWithValue("@LoaiNV", ((FilterNganHang)criteria).LoaiNV);
                    cm.Parameters.AddWithValue("@DieuKien", ((FilterNganHang)criteria).DieuKien);
                    cm.Parameters.AddWithValue("@UserID", Security.CurrentUser.Info.UserID);
                    cm.Parameters.AddWithValue("@Loai", ((FilterNganHang)criteria).Loai);
                }
                using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                {
                    while (dr.Read())
                        this.Add(BangLuongTongHopKy2Child.GetBangLuongTongHopKy2Child(dr));
                }
            }//using
        }
        #endregion //Data Access - Fetch
        #endregion //Data Access
    }
}
