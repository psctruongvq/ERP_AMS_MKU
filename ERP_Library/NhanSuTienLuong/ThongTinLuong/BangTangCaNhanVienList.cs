
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{
    [Serializable()]
    public class BangTangCaNhanVienList : Csla.ReadOnlyListBase<BangTangCaNhanVienList, BangTangCaNhanVienChild>
    {

        #region Authorization Rules

        public static bool CanGetObject()
        {
            //TODO: Define CanGetObject permission in BangTangCaNhanVienList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("BangTangCaNhanVienListViewGroup"))
            //	return true;
            //return false;
        }
        #endregion //Authorization Rules

        #region Factory Methods
        private BangTangCaNhanVienList()
        { /* require use of factory method */ }

        public static BangTangCaNhanVienList GetBangTangCaNhanVienList(int MaKyTinhLuong)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a BangTangCaNhanVienList");
            return DataPortal.Fetch<BangTangCaNhanVienList>(new FilterCriteria(MaKyTinhLuong));
        }
        public static BangTangCaNhanVienList GetBangTangCaNhanVienListByBoPhan(int MaKyTinhLuong, int MaBoPhan)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a BangTangCaNhanVienList");
            return DataPortal.Fetch<BangTangCaNhanVienList>(new FilterByBoPhan(MaKyTinhLuong, MaBoPhan));
        }
        public static BangTangCaNhanVienList GetBangTangCaNhanVienListByNhanVien(int MaKyTinhLuong, long MaNhanVien)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a BangTangCaNhanVienList");
            return DataPortal.Fetch<BangTangCaNhanVienList>(new FilterByNhanVien(MaKyTinhLuong, MaNhanVien));
        }

        public static void ChamTangCaTatCa(int MaKyTinhLuong, DateTime Ngay, decimal SoGio)
        {
            ChamTangCaBoPhan(MaKyTinhLuong, Ngay, SoGio, null);
        }
        public static void ChamTangCaBoPhan(int MaKyTinhLuong, DateTime Ngay, decimal SoGio, Nullable<int> MaBoPhan)
        {
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                SqlCommand cm = cn.CreateCommand();
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_TinhTangCaTatCaNhanVien";
                cm.Parameters.AddWithValue("@MaKyTinhLuong", MaKyTinhLuong);
                cm.Parameters.AddWithValue("@Ngay", Ngay);

                //phân tích ngày thường, t7, cn, ngày lễ
                decimal GioNgayThuong, GioT7CN, GioNgayLe;
                bool ngayle = false;
                GioNgayThuong = 0;
                GioNgayLe = 0;
                GioT7CN = 0;
                ERP_Library.NgayHolidayList l = ERP_Library.NgayHolidayList.GetNgayHolidayList();
                foreach (ERP_Library.NgayHoliday i in l)
                    if (i.Ngay == Ngay)
                    {
                        ngayle = true;
                        break;
                    }
                if (ngayle)
                    GioNgayLe = SoGio;
                else if (Ngay.DayOfWeek == DayOfWeek.Sunday || Ngay.DayOfWeek == DayOfWeek.Saturday)
                    GioT7CN = SoGio;
                else
                    GioNgayThuong = SoGio;

                cm.Parameters.AddWithValue("@GioNgayThuong", GioNgayThuong);
                cm.Parameters.AddWithValue("@GioT7CN", GioT7CN);
                cm.Parameters.AddWithValue("@GioNgayLe", GioNgayLe);
                if (MaBoPhan.HasValue)
                    cm.Parameters.AddWithValue("@MaBoPhan", MaBoPhan.Value);
                else
                    cm.Parameters.AddWithValue("@MaBoPhan", DBNull.Value);

                cm.ExecuteNonQuery();
            }
        }
        public static void ChamTangCaNhanVien(int MaKyTinhLuong, DateTime Ngay, decimal SoGio, long MaNhanVien)
        {
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                SqlCommand cm = cn.CreateCommand();
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_TinhTangCaNhanVien";
                cm.Parameters.AddWithValue("@MaKyTinhLuong", MaKyTinhLuong);
                cm.Parameters.AddWithValue("@Ngay", Ngay);

                //phân tích ngày thường, t7, cn, ngày lễ
                decimal GioNgayThuong, GioT7CN, GioNgayLe;
                bool ngayle = false;
                GioNgayThuong = 0;
                GioNgayLe = 0;
                GioT7CN = 0;
                ERP_Library.NgayHolidayList l = ERP_Library.NgayHolidayList.GetNgayHolidayList();
                foreach (ERP_Library.NgayHoliday i in l)
                    if (i.Ngay == Ngay)
                    {
                        ngayle = true;
                        break;
                    }
                if (ngayle)
                    GioNgayLe = SoGio;
                else if (Ngay.DayOfWeek == DayOfWeek.Sunday || Ngay.DayOfWeek == DayOfWeek.Saturday)
                    GioT7CN = SoGio;
                else
                    GioNgayThuong = SoGio;

                cm.Parameters.AddWithValue("@GioNgayThuong", GioNgayThuong);
                cm.Parameters.AddWithValue("@GioT7CN", GioT7CN);
                cm.Parameters.AddWithValue("@GioNgayLe", GioNgayLe);
                cm.Parameters.AddWithValue("@MaNhanVien", MaNhanVien);
                cm.ExecuteNonQuery();
                cn.Close();
            }
        }

        public static void ChamTongHopTatCa(int MaKyTinhLuong, Nullable<decimal> NgayThuong, Nullable<decimal> T7CN, Nullable<decimal> NgayLe)
        {
            ChamTongHopBoPhan(MaKyTinhLuong, null, NgayThuong, T7CN, NgayLe);
        }

        public static void ChamTongHopBoPhan(int MaKyTinhLuong, Nullable<int> MaBoPhan, Nullable<decimal> NgayThuong, Nullable<decimal> T7CN, Nullable<decimal> NgayLe)
        {
            //lưu số giờ tăng ca tổng cộng, nếu null thì bỏ qua
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                SqlCommand cm = cn.CreateCommand();
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_TinhTangCaTongHopBoPhan";
                cm.Parameters.AddWithValue("@MaKyTinhLuong", MaKyTinhLuong);
                if (NgayThuong.HasValue)
                    cm.Parameters.AddWithValue("@NgayThuong", NgayThuong);
                else
                    cm.Parameters.AddWithValue("@NgayThuong", DBNull.Value);
                if (T7CN.HasValue)
                    cm.Parameters.AddWithValue("@T7CN", T7CN);
                else
                    cm.Parameters.AddWithValue("@T7CN", DBNull.Value);
                if (NgayLe.HasValue)
                    cm.Parameters.AddWithValue("@NgayLe", NgayLe);
                else
                    cm.Parameters.AddWithValue("@NgayLe", DBNull.Value);
                if (MaBoPhan.HasValue)
                    cm.Parameters.AddWithValue("@MaBoPhan", MaBoPhan.Value);
                else
                    cm.Parameters.AddWithValue("@MaBoPhan", DBNull.Value);
                cm.ExecuteNonQuery();
                cn.Close();
            }
        }

        public static void ChamTongHopNhanVien(int MaKyTinhLuong, long MaNhanVien, Nullable<decimal> NgayThuong, Nullable<decimal> T7CN, Nullable<decimal> NgayLe)
        {
            //lưu số giờ tăng ca tổng cộng, nếu null thì bỏ qua
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                SqlCommand cm = cn.CreateCommand();
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_TinhTangCaTongHopNhanVien";
                cm.Parameters.AddWithValue("@MaKyTinhLuong", MaKyTinhLuong);
                cm.Parameters.AddWithValue("@MaNhanVien", MaNhanVien);
                if (NgayThuong.HasValue)
                    cm.Parameters.AddWithValue("@NgayThuong", NgayThuong);
                else
                    cm.Parameters.AddWithValue("@NgayThuong", DBNull.Value);
                if (T7CN.HasValue)
                    cm.Parameters.AddWithValue("@T7CN", T7CN);
                else
                    cm.Parameters.AddWithValue("@T7CN", DBNull.Value);
                if (NgayLe.HasValue)
                    cm.Parameters.AddWithValue("@NgayLe", NgayLe);
                else
                    cm.Parameters.AddWithValue("@NgayLe", DBNull.Value);

                cm.ExecuteNonQuery();
                cn.Close();
            }
        }

        public static void XoaTangCaBoPhan(int MaKyTinhLuong, int MaBoPhan)
        {
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                SqlCommand cm= cn.CreateCommand();
                cm.CommandType = CommandType.Text;
                cm.CommandText = "Delete From tblnsBaoCaoTangCa Where MaKyTinhLuong = @MaKyTinhLuong AND MaBoPhan = @MaBoPhan";
                cm.Parameters.AddWithValue("@MaKyTinhLuong", MaKyTinhLuong);
                cm.Parameters.AddWithValue("@MaBoPhan", MaBoPhan);
                cm.ExecuteNonQuery();
                cn.Close();
            }
        }

        public static void XoaTangCaNhanVien(int MaKyTinhLuong, long MaNhanVien)
        {
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                SqlCommand cm = cn.CreateCommand();
                cm.CommandType = CommandType.Text;
                cm.CommandText = "Delete From tblnsBaoCaoTangCa Where MaKyTinhLuong = @MaKyTinhLuong AND MaNhanVien = @MaNhanVien";
                cm.Parameters.AddWithValue("@MaKyTinhLuong", MaKyTinhLuong);
                cm.Parameters.AddWithValue("@MaNhanVien", MaNhanVien);
                cm.ExecuteNonQuery();
                cn.Close();
            }
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

        [Serializable()]
        private class FilterByBoPhan : FilterCriteria
        {
            public int MaBoPhan;
            public FilterByBoPhan(int maKyTinhLuong, int maBoPhan):base(maKyTinhLuong)
            {
                MaBoPhan = maBoPhan;
            }
        }
        [Serializable()]
        private class FilterByNhanVien : FilterCriteria
        {
            public long MaNhanVien;
            public FilterByNhanVien(int maKyTinhLuong, long maNhanVien)
                : base(maKyTinhLuong)
            {
                MaNhanVien = maNhanVien;
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
                cm.CommandText = "spd_Report_BangTangCaNhanVien";
                cm.Parameters.AddWithValue("@MaKyTinhLuong", criteria.MaKyTinhLuong);
                if (criteria is FilterByBoPhan)
                {
                    cm.Parameters.AddWithValue("@MaBoPhan", ((FilterByBoPhan)criteria).MaBoPhan);
                    cm.Parameters.AddWithValue("@MaNhanVien", DBNull.Value);
                }
                else
                    if (criteria is FilterByNhanVien)
                    {
                        cm.Parameters.AddWithValue("@MaBoPhan", DBNull.Value);
                        cm.Parameters.AddWithValue("@MaNhanVien", ((FilterByNhanVien)criteria).MaNhanVien);
                    }
                    else
                    {
                        cm.Parameters.AddWithValue("@MaBoPhan", DBNull.Value);
                        cm.Parameters.AddWithValue("@MaNhanVien", DBNull.Value);
                    }

                using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                {
                    while (dr.Read())
                        this.Add(BangTangCaNhanVienChild.GetBangTangCaNhanVienChild(dr));
                }
            }//using
        }
        #endregion //Data Access - Fetch
        #endregion //Data Access
    }
}
