
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{
    [Serializable()]
    public class TongHopPhuCapAT_HC_TNKVQLList : Csla.ReadOnlyListBase<TongHopPhuCapAT_HC_TNKVQLList, TongHopPhuCapAT_HC_TNKVQLChild>
    {

        #region Factory Methods
        private TongHopPhuCapAT_HC_TNKVQLList()
        { /* require use of factory method */ }

        public static TongHopPhuCapAT_HC_TNKVQLList GetTongHopPhuCapAT_HC_TNKVQLList(int MaKyTinhLuong, int MaKyPhuCap, int LoaiNV)
        {
            return DataPortal.Fetch<TongHopPhuCapAT_HC_TNKVQLList>(new FilterCriteria(MaKyTinhLuong, MaKyPhuCap, LoaiNV));
        }
        #endregion //Factory Methods

        #region Data Access

        #region Filter Criteria
        [Serializable()]
        private class FilterCriteria
        {
            public int MaKyTinhLuong, MaKyPhuCap;
            public int LoaiNV;
            public FilterCriteria(int maKyTinhLuong, int maKyPhuCap, int loaiNV)
            {
                MaKyTinhLuong = maKyTinhLuong;
                MaKyPhuCap = maKyPhuCap;
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
                cm.CommandText = "spd_Report_PC_TongHopAnTruaHanhChinhTNKVQL";
                cm.Parameters.AddWithValue("@MaKyTinhLuong", criteria.MaKyTinhLuong);
                cm.Parameters.AddWithValue("@MaKyPhuCap", criteria.MaKyPhuCap);
                cm.Parameters.AddWithValue("@LoaiNV", criteria.LoaiNV);
                cm.Parameters.AddWithValue("@UserID", ERP_Library.Security.CurrentUser.Info.UserID);

                using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                {
                    while (dr.Read())
                        this.Add(TongHopPhuCapAT_HC_TNKVQLChild.GetTongHopPhuCapAT_HC_TNKVQLChild(dr));
                }
            }//using
        }
        #endregion //Data Access - Fetch
        #endregion //Data Access
    }
}
