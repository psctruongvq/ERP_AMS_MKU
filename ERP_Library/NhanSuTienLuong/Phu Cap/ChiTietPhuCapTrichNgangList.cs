
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library.Report
{
    [Serializable()]
    public class ChiTietPhuCapTrichNgangList : Csla.ReadOnlyListBase<ChiTietPhuCapTrichNgangList, ChiTietPhuCapTrichNgangChild>
    {
        private int _socot = 0;
        #region Factory Methods
        private ChiTietPhuCapTrichNgangList()
        { /* require use of factory method */ }

        public static ChiTietPhuCapTrichNgangList GetChiTietPhuCapTrichNgangList(int MaKyTinhLuong, int MaKyPhuCap, int MaNhomPhuCap, int MaBoPhan, int LoaiNV, int MaNganHang)
        {
            return DataPortal.Fetch<ChiTietPhuCapTrichNgangList>(new FilterCriteria(MaKyTinhLuong, MaKyPhuCap, MaNhomPhuCap, MaBoPhan, LoaiNV, MaNganHang));
        }
        public static ChiTietPhuCapTrichNgangList GetChiTietPhuCapTrichNgangTrong200GioList(int MaKyTinhLuong, int MaKyPhuCap, int MaNhomPhuCap, int MaBoPhan, int LoaiNV, int MaNganHang)
        {
            return DataPortal.Fetch<ChiTietPhuCapTrichNgangList>(new FilterCriteriaTrong200Gio(MaKyTinhLuong, MaKyPhuCap, MaNhomPhuCap, MaBoPhan, LoaiNV, MaNganHang));
        }
        public static ChiTietPhuCapTrichNgangList GetChiTietPhuCapTrichNgangLonHon200GioList(int MaKyTinhLuong, int MaKyPhuCap, int MaNhomPhuCap, int MaBoPhan, int LoaiNV, int MaNganHang)
        {
            return DataPortal.Fetch<ChiTietPhuCapTrichNgangList>(new FilterCriteriaLonHon200Gio(MaKyTinhLuong, MaKyPhuCap, MaNhomPhuCap, MaBoPhan, LoaiNV, MaNganHang));
        }
        #endregion //Factory Methods

        #region Data Access

        #region Filter Criteria
        [Serializable()]
        private class FilterCriteria
        {
            public int MaKyTinhLuong, MaKyPhuCap, MaNhomPhuCap, MaNganHang, MaBoPhan, LoaiNV;
            public FilterCriteria(int maKyTinhLuong, int maKyPhuCap, int maNhomPhuCap, int maBoPhan, int loaiNV, int maNganHang)
            {
                MaKyTinhLuong = maKyTinhLuong;
                MaKyPhuCap = maKyPhuCap;
                MaNhomPhuCap = maNhomPhuCap;
                MaBoPhan = maBoPhan;
                LoaiNV = loaiNV;
                MaNganHang = maNganHang;
            }
        }

        private class FilterCriteriaTrong200Gio
        {
            public int MaKyTinhLuong, MaKyPhuCap, MaNhomPhuCap, MaNganHang, MaBoPhan, LoaiNV;
            public FilterCriteriaTrong200Gio(int maKyTinhLuong, int maKyPhuCap, int maNhomPhuCap, int maBoPhan, int loaiNV, int maNganHang)
            {
                MaKyTinhLuong = maKyTinhLuong;
                MaKyPhuCap = maKyPhuCap;
                MaNhomPhuCap = maNhomPhuCap;
                MaBoPhan = maBoPhan;
                LoaiNV = loaiNV;
                MaNganHang = maNganHang;
            }
        }

        private class FilterCriteriaLonHon200Gio
        {
            public int MaKyTinhLuong, MaKyPhuCap, MaNhomPhuCap, MaNganHang, MaBoPhan, LoaiNV;
            public FilterCriteriaLonHon200Gio(int maKyTinhLuong, int maKyPhuCap, int maNhomPhuCap, int maBoPhan, int loaiNV, int maNganHang)
            {
                MaKyTinhLuong = maKyTinhLuong;
                MaKyPhuCap = maKyPhuCap;
                MaNhomPhuCap = maNhomPhuCap;
                MaBoPhan = maBoPhan;
                LoaiNV = loaiNV;
                MaNganHang = maNganHang;
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
                    cm.CommandText = "spd_Report_ChiTietPhuCapTrichNgang";
                    cm.Parameters.AddWithValue("@MaKyTinhLuong", ((FilterCriteria)criteria).MaKyTinhLuong);
                    cm.Parameters.AddWithValue("@MaKyPhuCap", ((FilterCriteria)criteria).MaKyPhuCap);
                    cm.Parameters.AddWithValue("@MaNhom", ((FilterCriteria)criteria).MaNhomPhuCap);
                    cm.Parameters.AddWithValue("@MaBoPhan", ((FilterCriteria)criteria).MaBoPhan);
                    cm.Parameters.AddWithValue("@LoaiNV", ((FilterCriteria)criteria).LoaiNV);
                    cm.Parameters.AddWithValue("@MaNganHang", ((FilterCriteria)criteria).MaNganHang);
                    cm.Parameters.AddWithValue("@UserID", ERP_Library.Security.CurrentUser.Info.UserID);
                    cm.Parameters.Add("@SoCot", SqlDbType.Int);
                    cm.Parameters["@SoCot"].Direction = ParameterDirection.Output;
                }
                else if (criteria is FilterCriteriaTrong200Gio)
                {
                    cm.CommandText = "[spd_Report_ChiTietPhuCapTrichNgangTrong200Gio]";
                    cm.Parameters.AddWithValue("@MaKyTinhLuong", ((FilterCriteriaTrong200Gio)criteria).MaKyTinhLuong);
                    cm.Parameters.AddWithValue("@MaKyPhuCap", ((FilterCriteriaTrong200Gio)criteria).MaKyPhuCap);
                    cm.Parameters.AddWithValue("@MaNhom", ((FilterCriteriaTrong200Gio)criteria).MaNhomPhuCap);
                    cm.Parameters.AddWithValue("@MaBoPhan", ((FilterCriteriaTrong200Gio)criteria).MaBoPhan);
                    cm.Parameters.AddWithValue("@LoaiNV", ((FilterCriteriaTrong200Gio)criteria).LoaiNV);
                    cm.Parameters.AddWithValue("@MaNganHang", ((FilterCriteriaTrong200Gio)criteria).MaNganHang);
                    cm.Parameters.AddWithValue("@UserID", ERP_Library.Security.CurrentUser.Info.UserID);
                    cm.Parameters.Add("@SoCot", SqlDbType.Int);
                    cm.Parameters["@SoCot"].Direction = ParameterDirection.Output;
                }
                else if (criteria is FilterCriteriaLonHon200Gio)
                {
                    cm.CommandText = "[spd_Report_ChiTietPhuCapTrichNgangTrongLonHon200Gio]";
                    cm.Parameters.AddWithValue("@MaKyTinhLuong", ((FilterCriteriaLonHon200Gio)criteria).MaKyTinhLuong);
                    cm.Parameters.AddWithValue("@MaKyPhuCap", ((FilterCriteriaLonHon200Gio)criteria).MaKyPhuCap);
                    cm.Parameters.AddWithValue("@MaNhom", ((FilterCriteriaLonHon200Gio)criteria).MaNhomPhuCap);
                    cm.Parameters.AddWithValue("@MaBoPhan", ((FilterCriteriaLonHon200Gio)criteria).MaBoPhan);
                    cm.Parameters.AddWithValue("@LoaiNV", ((FilterCriteriaLonHon200Gio)criteria).LoaiNV);
                    cm.Parameters.AddWithValue("@MaNganHang", ((FilterCriteriaLonHon200Gio)criteria).MaNganHang);
                    cm.Parameters.AddWithValue("@UserID", ERP_Library.Security.CurrentUser.Info.UserID);
                    cm.Parameters.Add("@SoCot", SqlDbType.Int);
                    cm.Parameters["@SoCot"].Direction = ParameterDirection.Output;
                }

                using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                {
                    while (dr.Read())
                        this.Add(ChiTietPhuCapTrichNgangChild.GetChiTietPhuCapTrichNgangChild(dr));
                }
                _socot = (int)cm.Parameters["@SoCot"].Value;
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
