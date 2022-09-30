
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{
    [Serializable()]
    public class BaoCaoTruyLuongList : Csla.ReadOnlyListBase<BaoCaoTruyLuongList, BaoCaoTruyLuongChild>
    {

        #region Factory Methods
        private BaoCaoTruyLuongList()
        { /* require use of factory method */ }

        public static BaoCaoTruyLuongList GetBaoCaoTruyLuongList(int MaKyTinhLuong, string LoaiNV, int MaBoPhan)
        {
            return DataPortal.Fetch<BaoCaoTruyLuongList>(new FilterCriteria(MaKyTinhLuong, LoaiNV, MaBoPhan));
        }
        #endregion //Factory Methods

        #region Data Access

        #region Filter Criteria
        [Serializable()]
        private class FilterCriteria
        {
            public int MaKyTinhLuong, MaBoPhan;
            public string LoaiNV;

            public FilterCriteria(int maKyTinhLuong, string loaiNV, int maBoPhan)
            {
                MaKyTinhLuong = maKyTinhLuong;
                LoaiNV = loaiNV;
                MaBoPhan = maBoPhan;
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
                cm.CommandText = "spd_Report_TruyLuongNhanVien";
                cm.Parameters.AddWithValue("@MaKyTinhLuong", criteria.MaKyTinhLuong);
                cm.Parameters.AddWithValue("@LoaiNV", criteria.LoaiNV);
                cm.Parameters.AddWithValue("@MaBoPhan", criteria.MaBoPhan);
                cm.Parameters.AddWithValue("@UserID", ERP_Library.Security.CurrentUser.Info.UserID);

                using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                {
                    while (dr.Read())
                        this.Add(BaoCaoTruyLuongChild.GetBaoCaoTruyLuongChild(dr));
                }
            }//using
        }
        #endregion //Data Access - Fetch
        #endregion //Data Access
    }
}
