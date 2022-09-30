
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
namespace ERP_Library.Report
{
    [Serializable()]
    public class DanhSachThuTienNhanVienList : Csla.ReadOnlyListBase<DanhSachThuTienNhanVienList, DanhSachThuTienNhanVienChild>
    {

        #region Factory Methods
        private DanhSachThuTienNhanVienList()
        { /* require use of factory method */ }

        public static DanhSachThuTienNhanVienList GetDanhSachThuTienNhanVienList(int MaKyTinhLuong)
        {
            return DataPortal.Fetch<DanhSachThuTienNhanVienList>(new FilterCriteria(MaKyTinhLuong));
        }

        public static DanhSachThuTienNhanVienList GetTongHopThuTienNhanVienList(int MaKyTinhLuong)
        {
            return DataPortal.Fetch<DanhSachThuTienNhanVienList>(new FilterTongHop(MaKyTinhLuong));
        }
        #endregion //Factory Methods

        #region Data Access

        #region Filter Criteria
        [Serializable()]
        private class FilterCriteria
        {
            public int MaKyTinhLuong;
            public FilterCriteria(int maKyTinhLuong)
            {
                MaKyTinhLuong = maKyTinhLuong;
            }
        }

        private class FilterTongHop : FilterCriteria
        {
            public FilterTongHop(int maKyTinhLuong) : base(maKyTinhLuong) { }
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
                if (criteria is FilterTongHop)
                {
                    cm.CommandText = "spd_Report_TongHopDanhSachThuTienNhanVien";
                    cm.Parameters.AddWithValue("@MaKyTinhLuong", (criteria as FilterTongHop).MaKyTinhLuong);
                    cm.Parameters.AddWithValue("@UserID", ERP_Library.Security.CurrentUser.Info.UserID);
                }
                else
                {
                    cm.CommandText = "spd_Report_DanhSachThuTienNhanVien";
                    cm.Parameters.AddWithValue("@MaKyTinhLuong", (criteria as FilterCriteria).MaKyTinhLuong);
                    cm.Parameters.AddWithValue("@UserID", ERP_Library.Security.CurrentUser.Info.UserID);
                }

                using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                {
                    while (dr.Read())
                        this.Add(DanhSachThuTienNhanVienChild.GetDanhSachThuTienNhanVienChild(dr));
                }
            }//using
        }
        #endregion //Data Access - Fetch
        #endregion //Data Access
    }
}
