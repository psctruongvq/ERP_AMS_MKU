
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library.Report
{
    [Serializable()]
    public class BangKeThueTNCN_CTVList : Csla.ReadOnlyListBase<BangKeThueTNCN_CTVList, BangKeThueTNCN_CTVChild>
    {

        #region Factory Methods
        private BangKeThueTNCN_CTVList()
        { /* require use of factory method */ }

        public static BangKeThueTNCN_CTVList GetBangKeThueTNCN_CTV_TinhThueList(int MaKyTinhLuong, int MaBoPhan,int namTinh, int tienThue)
        {
            return DataPortal.Fetch<BangKeThueTNCN_CTVList>(new FilterCriteriaCoThue(MaKyTinhLuong, MaBoPhan, true,namTinh,tienThue));
        }
        public static BangKeThueTNCN_CTVList GetBangKeThueTNCN_CTV_KhongThueList(int MaKyTinhLuong, int MaBoPhan,int namTinh, int tienThue)
        {
            return DataPortal.Fetch<BangKeThueTNCN_CTVList>(new FilterCriteria(MaKyTinhLuong, MaBoPhan, false, namTinh, tienThue));
        }

        public static BangKeThueTNCN_CTVList GetBangKeThueTNCN_CTVChiTiet (int MaKyTinhLuong, int MaBoPhan, int namTinh, int tienThue)
        {
            return DataPortal.Fetch<BangKeThueTNCN_CTVList>(new FilterCriteriaChiTiet(MaKyTinhLuong, MaBoPhan, false, namTinh, tienThue));
        }

        public static BangKeThueTNCN_CTVList GetBangKeThueTNCN_CTVChiTietByThuong(int MaKyTinhLuong, int MaBoPhan, int namTinh, int tienThue)
        {
            return DataPortal.Fetch<BangKeThueTNCN_CTVList>(new FilterCriteriaChiTietByThuong(MaKyTinhLuong, MaBoPhan, false, namTinh, tienThue));
        }
        #endregion //Factory Methods

        #region Data Access

        #region Filter Criteria
        [Serializable()]
        private class FilterCriteria
        {
            public int MaKyTinhLuong, MaBoPhan;
            public bool TinhThue;
            public int NamTinh;
            public int TienThue;
            public FilterCriteria(int maKyTinhLuong, int maBoPhan, bool tinhThue,int namTinh, int tienThue)
            {
                MaKyTinhLuong = maKyTinhLuong;
                MaBoPhan = maBoPhan;
                TinhThue = tinhThue;
                this.NamTinh = namTinh;
                this.TienThue = tienThue;
            }
        }

        private class FilterCriteriaCoThue
        {
            public int MaKyTinhLuong, MaBoPhan;
            public bool TinhThue;
            public int NamTinh;
            public int TienThue;
            public FilterCriteriaCoThue(int maKyTinhLuong, int maBoPhan, bool tinhThue, int namTinh, int tienThue)
            {
                MaKyTinhLuong = maKyTinhLuong;
                MaBoPhan = maBoPhan;
                TinhThue = tinhThue;
                this.NamTinh = namTinh;
                this.TienThue = tienThue;
            }
        }
        
        private class FilterCriteriaChiTietByThuong
        {
            public int MaKyTinhLuong, MaBoPhan;
            public bool TinhThue;
            public int NamTinh;
            public int TienThue;
            public FilterCriteriaChiTietByThuong(int maKyTinhLuong, int maBoPhan, bool tinhThue, int namTinh, int tienThue)
            {
                MaKyTinhLuong = maKyTinhLuong;
                MaBoPhan = maBoPhan;
                TinhThue = tinhThue;
                this.NamTinh = namTinh;
                this.TienThue = tienThue;
            }
        }

        private class FilterCriteriaChiTiet
        {
            public int MaKyTinhLuong, MaBoPhan;
            public bool TinhThue;
            public int NamTinh;
            public int TienThue;
            public FilterCriteriaChiTiet(int maKyTinhLuong, int maBoPhan, bool tinhThue, int namTinh, int tienThue)
            {
                MaKyTinhLuong = maKyTinhLuong;
                MaBoPhan = maBoPhan;
                TinhThue = tinhThue;
                this.NamTinh = namTinh;
                this.TienThue = tienThue;
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

        private void ExecuteFetch(SqlTransaction tr, Object criteria)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandTimeout = 0;
                if (criteria is FilterCriteria)
                {
                    cm.CommandText = "[spd_Report_BangKeThueTNCN_CongTacVienKhongThue]";
                    cm.Parameters.AddWithValue("@MaKyTinhLuong", ((FilterCriteria)criteria).MaKyTinhLuong);
                    cm.Parameters.AddWithValue("@MaBoPhan", ((FilterCriteria)criteria).MaBoPhan);
                    cm.Parameters.AddWithValue("@UserID", Security.CurrentUser.Info.UserID);
                    cm.Parameters.AddWithValue("@TinhThue", ((FilterCriteria)criteria).TinhThue);
                    cm.Parameters.AddWithValue("@NamTinh", ((FilterCriteria)criteria).NamTinh);
                    cm.Parameters.AddWithValue("@TienThue", ((FilterCriteria)criteria).TienThue);
                }
                if (criteria is FilterCriteriaCoThue)
                {
                    cm.CommandText = "spd_Report_BangKeThueTNCN_CongTacVien";
                    cm.Parameters.AddWithValue("@MaKyTinhLuong", ((FilterCriteriaCoThue)criteria).MaKyTinhLuong);
                    cm.Parameters.AddWithValue("@MaBoPhan", ((FilterCriteriaCoThue)criteria).MaBoPhan);
                    cm.Parameters.AddWithValue("@UserID", Security.CurrentUser.Info.UserID);
                    cm.Parameters.AddWithValue("@TinhThue", ((FilterCriteriaCoThue)criteria).TinhThue);
                    cm.Parameters.AddWithValue("@NamTinh", ((FilterCriteriaCoThue)criteria).NamTinh);
                    cm.Parameters.AddWithValue("@TienThue", ((FilterCriteriaCoThue)criteria).TienThue);
                }
                if (criteria is FilterCriteriaChiTiet)
                {
                    cm.CommandText = "spd_Report_BangKeThueTNCNChiTiet";
                    cm.Parameters.AddWithValue("@MaKyTinhLuong", ((FilterCriteriaChiTiet)criteria).MaKyTinhLuong);
                    cm.Parameters.AddWithValue("@MaBoPhan", ((FilterCriteriaChiTiet)criteria).MaBoPhan);
                    cm.Parameters.AddWithValue("@UserID", Security.CurrentUser.Info.UserID);
                    cm.Parameters.AddWithValue("@TinhThue", ((FilterCriteriaChiTiet)criteria).TinhThue);
                    cm.Parameters.AddWithValue("@NamTinh", ((FilterCriteriaChiTiet)criteria).NamTinh);
                    cm.Parameters.AddWithValue("@TienThue", ((FilterCriteriaChiTiet)criteria).TienThue);
                }
                if (criteria is FilterCriteriaChiTietByThuong)
                {
                    cm.CommandText = "[spd_Report_BangKeThueTNCN_CongTacVienThuong]";
                    cm.Parameters.AddWithValue("@MaKyTinhLuong", ((FilterCriteriaChiTietByThuong)criteria).MaKyTinhLuong);
                    cm.Parameters.AddWithValue("@MaBoPhan", ((FilterCriteriaChiTietByThuong)criteria).MaBoPhan);
                    cm.Parameters.AddWithValue("@UserID", Security.CurrentUser.Info.UserID);
                    cm.Parameters.AddWithValue("@TinhThue", ((FilterCriteriaChiTietByThuong)criteria).TinhThue);
                    cm.Parameters.AddWithValue("@NamTinh", ((FilterCriteriaChiTietByThuong)criteria).NamTinh);
                    cm.Parameters.AddWithValue("@TienThue", ((FilterCriteriaChiTietByThuong)criteria).TienThue);
                }

                using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                {
                    while (dr.Read())
                        this.Add(BangKeThueTNCN_CTVChild.GetBangKeThueTNCN_CTVChild(dr));
                }
            }//using
        }
        #endregion //Data Access - Fetch
        #endregion //Data Access
    }
}
