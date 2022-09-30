
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library.Report
{
    [Serializable()]
    public class BangKeThueTNCN_NVList : Csla.ReadOnlyListBase<BangKeThueTNCN_NVList, BangKeThueTNCN_NVChild>
    {

        #region Factory Methods
        private BangKeThueTNCN_NVList()
        { /* require use of factory method */ }

        public static BangKeThueTNCN_NVList GetBangKeThueTNCN_NVList(int MaKyTinhLuong, int MaBoPhan,int namTinh)
        {
            return DataPortal.Fetch<BangKeThueTNCN_NVList>(new FilterCriteria(MaKyTinhLuong, MaBoPhan,namTinh));
        }
        #endregion //Factory Methods

        #region Data Access

        #region Filter Criteria
        [Serializable()]
        private class FilterCriteria
        {
            public int MaKyTinhLuong, MaBoPhan;
            public int NamTinh;
            public FilterCriteria(int maKyTinhLuong, int maBoPhan, int namTinh)
            {
                MaKyTinhLuong = maKyTinhLuong;
                MaBoPhan = maBoPhan;
                this.NamTinh = namTinh;
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
                cm.CommandText = "spd_Report_BangKeThueTNCN_NV";
                cm.Parameters.AddWithValue("@MaKyTinhLuong", criteria.MaKyTinhLuong);
                cm.Parameters.AddWithValue("@MaBoPhan", criteria.MaBoPhan);
                cm.Parameters.AddWithValue("@NamTinh", criteria.NamTinh);
                cm.Parameters.AddWithValue("@UserID", Security.CurrentUser.Info.UserID);

                using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                {
                    while (dr.Read())
                        this.Add(BangKeThueTNCN_NVChild.GetBangKeThueTNCN_NVChild(dr));
                }
            }//using
        }
        #endregion //Data Access - Fetch
        #endregion //Data Access
    }
}
