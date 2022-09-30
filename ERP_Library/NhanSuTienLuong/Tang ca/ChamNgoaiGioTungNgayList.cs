
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library.Report
{
    [Serializable()]
    public class ChamNgoaiGioTungNgayList : Csla.ReadOnlyListBase<ChamNgoaiGioTungNgayList, ChamNgoaiGioTungNgayChild>
    {

        #region Factory Methods
        private ChamNgoaiGioTungNgayList()
        { /* require use of factory method */ }

        public static ChamNgoaiGioTungNgayList GetChamNgoaiGioTungNgayList(int MaKyTinhLuong, int MaKyChamCong, int MaBoPhan, int MaLoai)
        {
            return DataPortal.Fetch<ChamNgoaiGioTungNgayList>(new FilterCriteria(MaKyTinhLuong, MaKyChamCong, MaBoPhan, MaLoai));
        }
        #endregion //Factory Methods

        #region Data Access

        #region Filter Criteria
        [Serializable()]
        private class FilterCriteria
        {
            public int MaKyTinhLuong, MaKyChamCong, MaBoPhan, MaLoai;
            public FilterCriteria(int maKyTinhLuong, int maKyChamCong, int maBoPhan, int maLoai)
            {
                MaKyTinhLuong = maKyTinhLuong;
                MaKyChamCong = maKyChamCong;
                MaBoPhan = maBoPhan;
                MaLoai = maLoai;
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
                cm.CommandText = "spd_Report_ChamNgoaiGioTungNgay";
                cm.Parameters.AddWithValue("@MaKyTinhLuong", criteria.MaKyTinhLuong);
                cm.Parameters.AddWithValue("@MaKyChamCong", criteria.MaKyChamCong);
                cm.Parameters.AddWithValue("@MaBoPhan", criteria.MaBoPhan);
                cm.Parameters.AddWithValue("@MaLoai", criteria.MaLoai);

                using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                {
                    while (dr.Read())
                        this.Add(ChamNgoaiGioTungNgayChild.GetChamNgoaiGioTungNgayChild(dr));
                }
            }//using
        }
        #endregion //Data Access - Fetch
        #endregion //Data Access
    }
}
