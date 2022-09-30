
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library.Report
{
    [Serializable()]
    public class TongHopPhuCapTrichNgangList : Csla.ReadOnlyListBase<TongHopPhuCapTrichNgangList, TongHopPhuCapTrichNgangChild>
    {
        private int _socot = 0;
        #region Factory Methods
        private TongHopPhuCapTrichNgangList()
        { /* require use of factory method */ }

        public static TongHopPhuCapTrichNgangList GetTongHopPhuCapTrichNgangList(int MaKyTinhLuong, int MaKyPhuCap, int MaNhom, int MaNganHang, int ThanhToan)
        {
            return DataPortal.Fetch<TongHopPhuCapTrichNgangList>(new FilterCriteria(MaKyTinhLuong, MaKyPhuCap, MaNhom, MaNganHang, ThanhToan));
        }
        public static TongHopPhuCapTrichNgangList GetTongHopPhuCapTrichNgangTrong200GioList(int MaKyTinhLuong, int MaKyPhuCap, int MaNhom, int MaNganHang, int ThanhToan)
        {
            return DataPortal.Fetch<TongHopPhuCapTrichNgangList>(new FilterCriteriaTrong200Gio(MaKyTinhLuong, MaKyPhuCap, MaNhom, MaNganHang, ThanhToan));
        }
        public static TongHopPhuCapTrichNgangList GetTongHopPhuCapTrichNgangLonHon200GioList(int MaKyTinhLuong, int MaKyPhuCap, int MaNhom, int MaNganHang, int ThanhToan)
        {
            return DataPortal.Fetch<TongHopPhuCapTrichNgangList>(new FilterCriteriaLonHon200Gio(MaKyTinhLuong, MaKyPhuCap, MaNhom, MaNganHang, ThanhToan));
        }
        #endregion //Factory Methods

        #region Data Access

        #region Filter Criteria
        [Serializable()]
        private class FilterCriteria
        {
            public int MaNhom, MaKyTinhLuong, MaKyPhuCap, MaNganHang;
            public int ThanhToan;
            public FilterCriteria(int maKyTinhLuong, int maKyPhuCap, int maNhom, int maNganHang, int thanhToan)
            {
                MaNhom = maNhom;
                MaKyTinhLuong = maKyTinhLuong;
                MaKyPhuCap = maKyPhuCap;
                MaNganHang = maNganHang;
                this.ThanhToan = thanhToan;
            }
        }

        private class FilterCriteriaTrong200Gio
        {
           public int MaNhom, MaKyTinhLuong, MaKyPhuCap, MaNganHang;
           public int ThanhToan;
           public FilterCriteriaTrong200Gio(int maKyTinhLuong, int maKyPhuCap, int maNhom, int maNganHang, int thanhToan)
            {
                MaNhom = maNhom;
                MaKyTinhLuong = maKyTinhLuong;
                MaKyPhuCap = maKyPhuCap;
                MaNganHang = maNganHang;
                this.ThanhToan = thanhToan;
            }
        }

        private class FilterCriteriaLonHon200Gio
        {
            public int MaNhom, MaKyTinhLuong, MaKyPhuCap, MaNganHang;
            public int ThanhToan;
            public FilterCriteriaLonHon200Gio(int maKyTinhLuong, int maKyPhuCap, int maNhom, int maNganHang, int thanhToan)
            {
                MaNhom = maNhom;
                MaKyTinhLuong = maKyTinhLuong;
                MaKyPhuCap = maKyPhuCap;
                MaNganHang = maNganHang;
                this.ThanhToan = thanhToan;
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
                    cm.CommandText = "spd_Report_TongHopPhuCapTrichNgang";
                    cm.Parameters.AddWithValue("@MaKyTinhLuong", ((FilterCriteria)criteria).MaKyTinhLuong);
                    cm.Parameters.AddWithValue("@MaKyPhuCap", ((FilterCriteria)criteria).MaKyPhuCap);
                    cm.Parameters.AddWithValue("@MaNhom", ((FilterCriteria)criteria).MaNhom);
                    cm.Parameters.AddWithValue("@MaNganHang", ((FilterCriteria)criteria).MaNganHang);
                    cm.Parameters.AddWithValue("@UserID", ERP_Library.Security.CurrentUser.Info.UserID);
                    cm.Parameters.AddWithValue("@ThanhToan", ((FilterCriteria)criteria).ThanhToan);
                    cm.Parameters.Add("@SoCot", SqlDbType.Int);
                    cm.Parameters["@SoCot"].Direction = ParameterDirection.Output;
                }
                if (criteria is FilterCriteriaTrong200Gio)
                {
                    cm.CommandText = "[spd_Report_TongHopPhuCapTrichNgangTrong200Gio]";
                    cm.Parameters.AddWithValue("@MaKyTinhLuong", ((FilterCriteriaTrong200Gio)criteria).MaKyTinhLuong);
                    cm.Parameters.AddWithValue("@MaKyPhuCap", ((FilterCriteriaTrong200Gio)criteria).MaKyPhuCap);
                    cm.Parameters.AddWithValue("@MaNhom", ((FilterCriteriaTrong200Gio)criteria).MaNhom);
                    cm.Parameters.AddWithValue("@MaNganHang", ((FilterCriteriaTrong200Gio)criteria).MaNganHang);
                    cm.Parameters.AddWithValue("@UserID", ERP_Library.Security.CurrentUser.Info.UserID);
                    cm.Parameters.AddWithValue("@ThanhToan", ((FilterCriteriaTrong200Gio)criteria).ThanhToan);
                    cm.Parameters.Add("@SoCot", SqlDbType.Int);
                    cm.Parameters["@SoCot"].Direction = ParameterDirection.Output;
                }
                if (criteria is FilterCriteriaLonHon200Gio)
                {
                    cm.CommandText = "[spd_Report_TongHopPhuCapTrichNgangLonHon200Gio]";
                    cm.Parameters.AddWithValue("@MaKyTinhLuong", ((FilterCriteriaLonHon200Gio)criteria).MaKyTinhLuong);
                    cm.Parameters.AddWithValue("@MaKyPhuCap", ((FilterCriteriaLonHon200Gio)criteria).MaKyPhuCap);
                    cm.Parameters.AddWithValue("@MaNhom", ((FilterCriteriaLonHon200Gio)criteria).MaNhom);
                    cm.Parameters.AddWithValue("@MaNganHang", ((FilterCriteriaLonHon200Gio)criteria).MaNganHang);
                    cm.Parameters.AddWithValue("@UserID", ERP_Library.Security.CurrentUser.Info.UserID);
                    cm.Parameters.AddWithValue("@ThanhToan", ((FilterCriteriaLonHon200Gio)criteria).ThanhToan);
                    cm.Parameters.Add("@SoCot", SqlDbType.Int);
                    cm.Parameters["@SoCot"].Direction = ParameterDirection.Output;
                }
                using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                {
                    while (dr.Read())
                        this.Add(TongHopPhuCapTrichNgangChild.GetTongHopPhuCapTrichNgangChild(dr));
                }
                _socot = Convert.ToInt32(cm.Parameters["@SoCot"].Value);
            }//using
        }
        #endregion //Data Access - Fetch
        #endregion //Data Access

        public int SoCot
        {
            get
            {
                return _socot;
            }
        }

    }
}
