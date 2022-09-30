
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library.Report
{
    [Serializable()]
    public class BangLuongTongHopKy1List : Csla.ReadOnlyListBase<BangLuongTongHopKy1List, BangLuongTongHopKy1Child>
    {

        #region Factory Methods
        private BangLuongTongHopKy1List()
        { /* require use of factory method */ }

        public static BangLuongTongHopKy1List GetBangLuongTongHopKy1List(int MaKyTinhLuong, string LoaiNV, string HinhThuc, int MaNganHang)
        {
            return DataPortal.Fetch<BangLuongTongHopKy1List>(new FilterCriteria(MaKyTinhLuong, LoaiNV, HinhThuc, MaNganHang));
        }
        public static BangLuongTongHopKy1List GetBangLuongTongHopKy1List_KTL(int MaKyTinhLuong, string LoaiNV, string HinhThuc, int MaNganHang)
        {
            return DataPortal.Fetch<BangLuongTongHopKy1List>(new FilterCriteriaKTL(MaKyTinhLuong, LoaiNV, HinhThuc, MaNganHang));
        }

        public static BangLuongTongHopKy1List GetBangLuongNganHangKy1List(int MaKyTinhLuong, string LoaiNV, string HinhThuc)
        {
            return DataPortal.Fetch<BangLuongTongHopKy1List>(new FilterNganHang(MaKyTinhLuong, LoaiNV, HinhThuc));
        }
        public static BangLuongTongHopKy1List GetBangLuongNganHangKy1List_KTL(int MaKyTinhLuong, string LoaiNV, string HinhThuc)
        {
            return DataPortal.Fetch<BangLuongTongHopKy1List>(new FilterNganHangKTL(MaKyTinhLuong, LoaiNV, HinhThuc));
        }
        #endregion //Factory Methods

        #region Data Access

        #region Filter Criteria
        [Serializable()]
        private class FilterCriteria
        {
            public int MaKyTinhLuong;
            public string LoaiNV, HinhThuc;
            public int MaNganHang;

            public FilterCriteria(int maKyTinhLuong, string loaiNV, string hinhThuc, int maNganHang)
            {
                MaKyTinhLuong = maKyTinhLuong;
                LoaiNV = loaiNV;
                HinhThuc = hinhThuc;
                MaNganHang = maNganHang;
            }
        }

        [Serializable()]
        private class FilterCriteriaKTL
        {
            public int MaKyTinhLuong;
            public string LoaiNV, HinhThuc;
            public int MaNganHang;

            public FilterCriteriaKTL(int maKyTinhLuong, string loaiNV, string hinhThuc, int maNganHang)
            {
                MaKyTinhLuong = maKyTinhLuong;
                LoaiNV = loaiNV;
                HinhThuc = hinhThuc;
                MaNganHang = maNganHang;
            }
        }

        [Serializable()]
        private class FilterNganHang
        {
           public int MaKyTinhLuong;
            public string LoaiNV, HinhThuc;

            public FilterNganHang(int maKyTinhLuong, string loaiNV, string hinhThuc)
            {
                MaKyTinhLuong = maKyTinhLuong;
                LoaiNV = loaiNV;
                HinhThuc = hinhThuc;
            }
        }

        [Serializable()]
        private class FilterNganHangKTL
        {
            public int MaKyTinhLuong;
            public string LoaiNV, HinhThuc;

            public FilterNganHangKTL(int maKyTinhLuong, string loaiNV, string hinhThuc)
            {
                MaKyTinhLuong = maKyTinhLuong;
                LoaiNV = loaiNV;
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
                    cm.CommandText = "spd_Report_TongHopLuongKy1";
                    cm.Parameters.AddWithValue("@MaKyTinhLuong", ((FilterCriteria)criteria).MaKyTinhLuong);
                    cm.Parameters.AddWithValue("@LoaiNV", ((FilterCriteria)criteria).LoaiNV);
                    cm.Parameters.AddWithValue("@HinhThuc", ((FilterCriteria)criteria).HinhThuc);
                    cm.Parameters.AddWithValue("@MaNganHang", ((FilterCriteria)criteria).MaNganHang);
                    cm.Parameters.AddWithValue("@UserID", Security.CurrentUser.Info.UserID);
                }
                if (criteria is FilterCriteriaKTL)
                {
                    cm.CommandText = "spd_Report_TongHopLuongKy1_KTL";
                    cm.Parameters.AddWithValue("@MaKyTinhLuong", ((FilterCriteriaKTL)criteria).MaKyTinhLuong);
                    cm.Parameters.AddWithValue("@LoaiNV", ((FilterCriteriaKTL)criteria).LoaiNV);
                    cm.Parameters.AddWithValue("@HinhThuc", ((FilterCriteriaKTL)criteria).HinhThuc);
                    cm.Parameters.AddWithValue("@MaNganHang", ((FilterCriteriaKTL)criteria).MaNganHang);
                    cm.Parameters.AddWithValue("@UserID", Security.CurrentUser.Info.UserID);
                }
                else if (criteria is FilterNganHang)
                {
                    cm.CommandText = "spd_Report_NganHangLuongKy1";
                    cm.Parameters.AddWithValue("@MaKyTinhLuong", ((FilterNganHang)criteria).MaKyTinhLuong);
                    cm.Parameters.AddWithValue("@LoaiNV", ((FilterNganHang)criteria).LoaiNV);
                    cm.Parameters.AddWithValue("@HinhThuc", ((FilterNganHang)criteria).HinhThuc);
                    cm.Parameters.AddWithValue("@UserID", Security.CurrentUser.Info.UserID);
                }
                else if (criteria is FilterNganHangKTL)
                {
                    cm.CommandText = "spd_Report_NganHangLuongKy1_KTL";
                    cm.Parameters.AddWithValue("@MaKyTinhLuong", ((FilterNganHangKTL)criteria).MaKyTinhLuong);
                    cm.Parameters.AddWithValue("@LoaiNV", ((FilterNganHangKTL)criteria).LoaiNV);
                    cm.Parameters.AddWithValue("@HinhThuc", ((FilterNganHangKTL)criteria).HinhThuc);
                    cm.Parameters.AddWithValue("@UserID", Security.CurrentUser.Info.UserID);
                }

                using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                {
                    while (dr.Read())
                        this.Add(BangLuongTongHopKy1Child.GetBangLuongTongHopKy1Child(dr));
                }
            }//using
        }
        #endregion //Data Access - Fetch
        #endregion //Data Access
    }
}
