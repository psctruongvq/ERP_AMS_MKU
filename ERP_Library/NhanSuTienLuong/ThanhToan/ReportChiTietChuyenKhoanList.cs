
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
//long

namespace ERP_Library.Report
{
    [Serializable()]
    public class ChiTietChuyenKhoanList : Csla.ReadOnlyListBase<ChiTietChuyenKhoanList, ChiTietChuyenKhoanChild>
    {

        #region Factory Methods
        private ChiTietChuyenKhoanList()
        { /* require use of factory method */ }

        public static ChiTietChuyenKhoanList GetChiTietChuyenKhoanList(long MaDeNghi)
        {
            return DataPortal.Fetch<ChiTietChuyenKhoanList>(new FilterCriteria(MaDeNghi));
        }

        public static ChiTietChuyenKhoanList GetChiTietChuyenKhoanListByThue(string MaDeNghi)
        {
            return DataPortal.Fetch<ChiTietChuyenKhoanList>(new FilterCriteriaByThue(MaDeNghi));
        }
        public static ChiTietChuyenKhoanList GetChiTietChuyenKhoanListByNganHang(int MaChungTu)
        {
            return DataPortal.Fetch<ChiTietChuyenKhoanList>(new FilterNganHang(MaChungTu));
        }
        public static ChiTietChuyenKhoanList GetChiTietChuyenKhoanListByNganHangConLaiKhac0(int MaChungTu)
        {
            return DataPortal.Fetch<ChiTietChuyenKhoanList>(new FilterNganHangTruThueKhac0(MaChungTu));
        }
        public static ChiTietChuyenKhoanList GetChiTietChuyenKhoanListByNganHangTruThue(int MaChungTu)
        {
            return DataPortal.Fetch<ChiTietChuyenKhoanList>(new FilterNganHangTruThue(MaChungTu));
        }
        public static ChiTietChuyenKhoanList GetChiTietChuyenKhoanListByNganHangTruThueHTVC(int MaChungTu)
        {
            return DataPortal.Fetch<ChiTietChuyenKhoanList>(new FilterNganHangTruThueHTVC(MaChungTu));
        }
        public static ChiTietChuyenKhoanList GetTongHopChuyenKhoan(int MaChungTu)
        {
            return DataPortal.Fetch<ChiTietChuyenKhoanList>(new FilterNganHangTongHop(MaChungTu));
        }

        public static ChiTietChuyenKhoanList GetTongHopChuyenKhoanByKyTinhLuong(int Thang, int Nam)
        {
            return DataPortal.Fetch<ChiTietChuyenKhoanList>(new FilterNganHangTongHopTheoKyTinhLuong(Thang, Nam));
        }

        public static ChiTietChuyenKhoanList GetChiTietChuyenKhoanListByNganHangTruThue_PhieuChi(int MaChungTu)
        {
            return DataPortal.Fetch<ChiTietChuyenKhoanList>(new FilterNganHangTruThue(MaChungTu));
        }
        public static ChiTietChuyenKhoanList GetChiTietChuyenKhoanListByNganHangInTruThue(int MaChungTu, DateTime Tungay, DateTime DenNgay, int MaBoPhan, int UserID)
        {
            return DataPortal.Fetch<ChiTietChuyenKhoanList>(new FilterNganHangInTruTheu(MaChungTu, Tungay, DenNgay, MaBoPhan, UserID));
        }
        #endregion //Factory Methods

        #region Data Access

        #region Filter Criteria
        [Serializable()]
        private class FilterCriteria
        {
            public long MaDeNghi;
            public FilterCriteria(long maDeNghi)
            {
                MaDeNghi = maDeNghi;
            }
        }

        private class FilterCriteriaByThue
        {
           public string  MaDeNghi;
            public FilterCriteriaByThue(string maDeNghi)
            {
                this.MaDeNghi = maDeNghi;
            }
        }

        [Serializable()]
        private class FilterNganHang
        {
            public int MaChungTu;
            public FilterNganHang(int maChungTu)
            {
                MaChungTu = maChungTu;
            }
        }

        [Serializable()]
        private class FilterNganHangTruThue
        {
            public int MaChungTu;
            public FilterNganHangTruThue(int maChungTu)
            {
                MaChungTu = maChungTu;
            }
        }


        [Serializable()]
        private class FilterNganHangTruThueHTVC
        {
            public int MaChungTu;
            public FilterNganHangTruThueHTVC(int maChungTu)
            {
                MaChungTu = maChungTu;
            }
        }

        [Serializable()]
        private class FilterNganHangTongHop
        {
            public int MaChungTu;
            public FilterNganHangTongHop(int maChungTu)
            {
                MaChungTu = maChungTu;
            }
        }

        [Serializable()]
        private class FilterNganHangTongHopTheoKyTinhLuong
        {
            public int Thang;
            public int Nam;
            public FilterNganHangTongHopTheoKyTinhLuong(int thang, int nam)
            {
                Thang = thang;
                Nam = nam;
            }
        }

        [Serializable()]
        private class FilterNganHangTruThueKhac0
        {
            public int MaChungTu;
            public FilterNganHangTruThueKhac0(int maChungTu)
            {
                MaChungTu = maChungTu;
            }
        }

        private class FilterNganHangTruThue_PhieuChi
        {
            public int MaChungTu;
            public string SoChungTu;
            public FilterNganHangTruThue_PhieuChi(int maChungTu, string soChungTu)
            {
                MaChungTu = maChungTu;
                this.SoChungTu = soChungTu;
            }
        }

        [Serializable()]
        private class FilterNganHangInTruTheu
        {
            public int MaChungTu;
            public DateTime TuNgay;
            public DateTime DenNgay;
            public int MaBoPhan;
            public int UserID;
            public FilterNganHangInTruTheu(int maChungTu, DateTime tuNgay, DateTime denNgay, int maBoPhan, int userID)
            {
                this.MaChungTu = maChungTu;
                this.TuNgay = tuNgay;
                this.DenNgay = denNgay;
                this.MaBoPhan = maBoPhan;
                this.UserID = userID;
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
                cm.CommandTimeout = 0;
                cm.CommandType = CommandType.StoredProcedure;
                if (criteria is FilterCriteria)
                {
                    cm.CommandText = "spd_Report_ChiTietChuyenKhoanByDeNghi";
                    cm.Parameters.AddWithValue("@MaDeNghi", (criteria as FilterCriteria).MaDeNghi);
                }
                else if (criteria is FilterNganHangTruThue)
                {
                    cm.CommandText = "spd_Report_ChiTietChuyenKhoanByNganHangCoTruThue";
                    cm.Parameters.AddWithValue("@MaChungTu", (criteria as FilterNganHangTruThue).MaChungTu);
                }
                else if (criteria is FilterNganHangTruThueHTVC)
                {
                    cm.CommandText = "spd_Report_ChiTietChuyenKhoanByNganHangCoTruThueHTVC";
                    cm.Parameters.AddWithValue("@MaChungTu", (criteria as FilterNganHangTruThueHTVC).MaChungTu);
                }
                else if (criteria is FilterNganHangTongHop)
                {
                    cm.CommandText = "spd_Report_TongHopChuyenKhoanByNganHangTruThue";
                    cm.Parameters.AddWithValue("@MaChungTu", (criteria as FilterNganHangTongHop).MaChungTu);
                }
                else if (criteria is FilterNganHangTongHopTheoKyTinhLuong)
                {
                    cm.CommandText = "spd_Report_TongHopChuyenKhoanByNganHangTheoThang";
                    cm.Parameters.AddWithValue("@Thang", (criteria as FilterNganHangTongHopTheoKyTinhLuong).Thang);
                    cm.Parameters.AddWithValue("@Nam", (criteria as FilterNganHangTongHopTheoKyTinhLuong).Nam);
                    cm.Parameters.AddWithValue("@UserID", ERP_Library.Security.CurrentUser.Info.UserID);
                }
                else if (criteria is FilterNganHangTruThueKhac0)
                {
                    cm.CommandText = "spd_Report_ChiTietChuyenKhoanByNganHangCoTruThueKhac0";
                    cm.Parameters.AddWithValue("@MaChungTu", (criteria as FilterNganHangTruThueKhac0).MaChungTu);
                }
                else if (criteria is FilterNganHangTruThue_PhieuChi)
                {
                    cm.CommandText = "spd_Report_ChiTietChuyenKhoanByNganHangCoTruThue";
                    cm.Parameters.AddWithValue("@MaChungTu", (criteria as FilterNganHangTruThue_PhieuChi).MaChungTu);
                    cm.Parameters.AddWithValue("@SoChungTu", (criteria as FilterNganHangTruThue_PhieuChi).SoChungTu);
                }
                else if (criteria is FilterNganHangInTruTheu)
                {
                    cm.CommandText = "spd_Report_ChiTietUNCTruThueTNCN";
                    cm.Parameters.AddWithValue("@MaChungTu", (criteria as FilterNganHangInTruTheu).MaChungTu);
                    cm.Parameters.AddWithValue("@TuNgay", (criteria as FilterNganHangInTruTheu).TuNgay);
                    cm.Parameters.AddWithValue("@DenNgay", (criteria as FilterNganHangInTruTheu).DenNgay);
                    cm.Parameters.AddWithValue("@MaBoPhan", (criteria as FilterNganHangInTruTheu).MaBoPhan);
                    cm.Parameters.AddWithValue("@UserID", (criteria as FilterNganHangInTruTheu).UserID);
                }
                else if (criteria is FilterNganHang)
                {
                    cm.CommandText = "spd_Report_ChiTietChuyenKhoanByNganHang";
                    cm.Parameters.AddWithValue("@MaChungTu", (criteria as FilterNganHang).MaChungTu);
                }
                else if (criteria is FilterCriteriaByThue)
                {
                    cm.CommandText = "[spd_ThueTheoTungLanChuyenKhoan]";
                    cm.Parameters.AddWithValue("@MaDeNghi", (criteria as FilterCriteriaByThue).MaDeNghi);
                }

                using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                {
                    while (dr.Read())
                        this.Add(ChiTietChuyenKhoanChild.GetChiTietChuyenKhoanChild(dr));
                }
            }//using
        }
        #endregion //Data Access - Fetch
        #endregion //Data Access
    }
}
