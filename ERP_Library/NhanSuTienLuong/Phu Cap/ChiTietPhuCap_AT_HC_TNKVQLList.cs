
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{
    [Serializable()]
    public class ChiTietPhuCapAT_HC_TNKVQLList : Csla.ReadOnlyListBase<ChiTietPhuCapAT_HC_TNKVQLList, ChiTietPhuCapAT_HC_TNKVQLChild>
    {

        #region Factory Methods
        private ChiTietPhuCapAT_HC_TNKVQLList()
        { /* require use of factory method */ }

        public static ChiTietPhuCapAT_HC_TNKVQLList GetChiTietPhuCapAT_HC_TNKVQLList(int MaKyTinhLuong, int MaKyPhuCap, int LoaiNV, int MaBoPhan, int MaNganHang)
        {
            return DataPortal.Fetch<ChiTietPhuCapAT_HC_TNKVQLList>(new FilterCriteria(MaKyTinhLuong, MaKyPhuCap, LoaiNV, MaBoPhan, MaNganHang));
        }
        #endregion //Factory Methods

        #region Data Access

        #region Filter Criteria
        [Serializable()]
        private class FilterCriteria
        {
            public int MaKyTinhLuong, MaKyPhuCap, MaBoPhan, MaNganHang, LoaiNV;
            public FilterCriteria(int maKyTinhLuong, int maKyPhuCap, int loaiNV, int maBoPhan, int maNganHang)
            {
                MaKyTinhLuong = maKyTinhLuong;
                MaKyPhuCap = maKyPhuCap;
                MaBoPhan = maBoPhan;
                MaNganHang = maNganHang;
                LoaiNV = loaiNV;
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
                cm.CommandText = "spd_Report_PC_ChiTietAnTruaHanhChinhTNKVQL";
                cm.Parameters.AddWithValue("@MaKyTinhLuong", criteria.MaKyTinhLuong);
                cm.Parameters.AddWithValue("@MaKyPhuCap", criteria.MaKyPhuCap);
                if (criteria.MaBoPhan == 0)
                    cm.Parameters.AddWithValue("@MaBoPhan", DBNull.Value);
                else
                    cm.Parameters.AddWithValue("@MaBoPhan", criteria.MaBoPhan);
                cm.Parameters.AddWithValue("@MaNganHang", criteria.MaNganHang);
                cm.Parameters.AddWithValue("@LoaiNV", criteria.LoaiNV);
                cm.Parameters.AddWithValue("@UserID", ERP_Library.Security.CurrentUser.Info.UserID);

                using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                {
                    while (dr.Read())
                        this.Add(ChiTietPhuCapAT_HC_TNKVQLChild.GetChiTietPhuCapAT_HC_TNKVQLChild(dr));
                }
            }//using
        }
        #endregion //Data Access - Fetch
        #endregion //Data Access
    }
}
