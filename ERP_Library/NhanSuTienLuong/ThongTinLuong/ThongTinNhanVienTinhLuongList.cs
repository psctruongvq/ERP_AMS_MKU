
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{
    [Serializable()]
    public class ThongTinNhanVienTinhLuongList : Csla.ReadOnlyListBase<ThongTinNhanVienTinhLuongList, ThongTinNhanVienTinhLuongChild>
    {
        #region Authorization Rules

        public static bool CanGetObject()
        {
            //TODO: Define CanGetObject permission in ThongTinNhanVienTinhLuongList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("ThongTinNhanVienTinhLuongListViewGroup"))
            //	return true;
            //return false;
        }
        #endregion //Authorization Rules

        #region Factory Methods
        private ThongTinNhanVienTinhLuongList()
        { /* require use of factory method */ }

        public static ThongTinNhanVienTinhLuongList GetThongTinNhanVienTinhLuongList(int maBoPhan, long maNhanVien, int Kieu)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a ThongTinNhanVienTinhLuongList");
            return DataPortal.Fetch<ThongTinNhanVienTinhLuongList>(new FilterCriteria(maBoPhan, maNhanVien, Kieu));
        }
                            
        public static ThongTinNhanVienTinhLuongList GetThongTinNhanVienTinhPhuCap(int MaBoPhan, long MaNhanVien, int MaKyTinhLuong)
        {
            return DataPortal.Fetch<ThongTinNhanVienTinhLuongList>(new FilterTinhPhuCap(MaBoPhan, MaNhanVien));
        }
        #endregion //Factory Methods


        #region Data Access

        #region Filter Criteria
        [Serializable()]
        private class FilterCriteria
        {
            public long MaNhanVien;
            public int MaBoPhan;
            public int Kieu;
            public FilterCriteria(int maBoPhan, long maNhanVien, int kieu)
            {
                this.MaNhanVien = maNhanVien;
                this.MaBoPhan = maBoPhan;
                this.Kieu = kieu;

            }
        }
        [Serializable()]
        private class FilterTinhPhuCap
        {
            public int MaBoPhan;
            public long MaNhanVien;
            public FilterTinhPhuCap(int maBoPhan, long maNhanVien)
            {
                MaBoPhan = maBoPhan;
                MaNhanVien = maNhanVien;
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
                    if (ERP_Library.Security.CurrentUser.IsAdminNhanSu)
                    {
                        cm.CommandText = "spd_Select_ThongTinNhanVien_TinhLuong";
                        cm.Parameters.AddWithValue("@MaNhanVien", (criteria as FilterCriteria).MaNhanVien);
                        cm.Parameters.AddWithValue("@MaBoPhan", (criteria as FilterCriteria).MaBoPhan);
                        cm.Parameters.AddWithValue("@UserID", ERP_Library.Security.CurrentUser.Info.UserID);
                        cm.Parameters.AddWithValue("@Kieu", (criteria as FilterCriteria).Kieu);
                    }
                    else
                    {
                        cm.CommandText = "spd_Select_ThongTinNhanVien_TinhLuongKhoan";
                        cm.Parameters.AddWithValue("@MaNhanVien", (criteria as FilterCriteria).MaNhanVien);
                        cm.Parameters.AddWithValue("@UserID", ERP_Library.Security.CurrentUser.Info.UserID);
                    }
                }
                else if (criteria is FilterTinhPhuCap)
                {
                    cm.CommandText = "spd_Select_ThongTinNhanVien_TinhPhuCap";
                    cm.Parameters.AddWithValue("@MaBoPhan", ((FilterTinhPhuCap)criteria).MaBoPhan);
                    cm.Parameters.AddWithValue("@MaNhanVien", ((FilterTinhPhuCap)criteria).MaNhanVien);
                    cm.Parameters.AddWithValue("@UserID", ERP_Library.Security.CurrentUser.Info.UserID);
                }


                using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                {
                    while (dr.Read())
                        this.Add(ThongTinNhanVienTinhLuongChild.GetThongTinNhanVienTinhLuongChild(dr));
                }
            }//using
        }
        #endregion //Data Access - Fetch
        #endregion //Data Access
    }
}
