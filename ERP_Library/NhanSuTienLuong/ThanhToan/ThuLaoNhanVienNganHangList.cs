
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library.Report
{
    [Serializable()]
    public class ThuLaoNhanVienNganHangList : Csla.ReadOnlyListBase<ThuLaoNhanVienNganHangList, ThuLaoNhanVienNganHangChild>
    {

        #region Factory Methods
        private ThuLaoNhanVienNganHangList()
        { /* require use of factory method */ }

        public static ThuLaoNhanVienNganHangList GetThuLaoNhanVienNganHangList(int MaKyTinhLuong, int MaBoPhan, int MaNganHang, DateTime TuNgay, DateTime DenNgay)
        {
            return DataPortal.Fetch<ThuLaoNhanVienNganHangList>(new FilterCriteria(MaKyTinhLuong, MaBoPhan, MaNganHang, TuNgay, DenNgay));
        }
        #endregion //Factory Methods

        #region Data Access

        #region Filter Criteria
        [Serializable()]
        private class FilterCriteria
        {
            public int MaBoPhan, MaKyTinhLuong, MaNganHang;
            public DateTime TuNgay, DenNgay;
            public FilterCriteria(int maKyTinhLuong, int maBoPhan, int maNganHang, DateTime tuNgay, DateTime denNgay)
            {
                MaKyTinhLuong = maKyTinhLuong;
                MaBoPhan = maBoPhan;
                MaNganHang = maNganHang;
                TuNgay = tuNgay;
                DenNgay = denNgay;
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
                cm.CommandText = "spd_Report_ThuLaoNhanVienNganHang";
                cm.Parameters.AddWithValue("@MaKyTinhLuong", criteria.MaKyTinhLuong);
                cm.Parameters.AddWithValue("@MaBoPhan", criteria.MaBoPhan);
                cm.Parameters.AddWithValue("@MaNganHang", criteria.MaNganHang);
                cm.Parameters.AddWithValue("@TuNgay", criteria.TuNgay);
                cm.Parameters.AddWithValue("@DenNgay", criteria.DenNgay);
                cm.Parameters.AddWithValue("@UserID", ERP_Library.Security.CurrentUser.Info.UserID);
                using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                {
                    while (dr.Read())
                        this.Add(ThuLaoNhanVienNganHangChild.GetThuLaoNhanVienNganHangChild(dr));
                }
            }//using
        }
        #endregion //Data Access - Fetch
        #endregion //Data Access
    }
}
