
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library.Report
{
    [Serializable()]
    public class InChiTietLuong_NhanVienList : Csla.ReadOnlyListBase<InChiTietLuong_NhanVienList, InChiTietLuong_NhanVienChild>
    {
        //static public DateTime TuNgay, DenNgay;
        #region Factory Methods
        private InChiTietLuong_NhanVienList()
        { /* require use of factory method */ }

        public static InChiTietLuong_NhanVienList GetInChiTietLuong_NhanVienList(long maNhanVien, int MaBoPhan, int MaKyTinhLuong,int TinhTrang, bool IsNew)
        {
            //return DataPortal.Fetch<InChiTietLuong_NhanVienList>(new FilterCriteria(maNhanVien, MaBoPhan, MaKyTinhLuong));
            return DataPortal.Fetch<InChiTietLuong_NhanVienList>(new FilterCriteria(maNhanVien, MaBoPhan, MaKyTinhLuong, TinhTrang, IsNew));
        }
        public static InChiTietLuong_NhanVienList GetInChiTietLuong_NhanVienListCTV(long maNhanVien, int MaBoPhan, int MaKyTinhLuong, int TinhTrang, bool IsNew)
        {
            //return DataPortal.Fetch<InChiTietLuong_NhanVienList>(new FilterCriteria(maNhanVien, MaBoPhan, MaKyTinhLuong));
            return DataPortal.Fetch<InChiTietLuong_NhanVienList>(new FilterCriteriaCTV(maNhanVien, MaBoPhan, MaKyTinhLuong, TinhTrang, IsNew));
        }
        #endregion //Factory Methods

        #region Data Access

        #region Filter Criteria
        [Serializable()]
        private class FilterCriteria
        {
            public long MaNhanVien;
            public int MaBoPhan, MaKyTinhLuong, TinhTrang;
            public bool IsNew = false;
            
                         
            public FilterCriteria(long maNhanVien, int maBoPhan, int maKyTinhLuong,int tinhTrang, bool isNew)
            {
                this.MaNhanVien = maNhanVien;
                MaBoPhan = maBoPhan;
                MaKyTinhLuong = maKyTinhLuong;
                TinhTrang = tinhTrang;
                IsNew = isNew;
            }
        }

        private class FilterCriteriaCTV
        {
            public long MaNhanVien;
            public int MaBoPhan, MaKyTinhLuong, TinhTrang;
            public bool IsNew = false;


            public FilterCriteriaCTV(long maNhanVien, int maBoPhan, int maKyTinhLuong, int tinhTrang, bool isNew)
            {
                this.MaNhanVien = maNhanVien;
                MaBoPhan = maBoPhan;
                MaKyTinhLuong = maKyTinhLuong;
                TinhTrang = tinhTrang;
                IsNew = isNew;
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
               
                if (criteria is FilterCriteria)
                {
                    cm.Transaction = tr;
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandTimeout = 0;
                    cm.CommandText = "spd_Report_InChiTietLuong_NhanVien";
                    cm.Parameters.AddWithValue("@UserID", Security.CurrentUser.Info.UserID);
                    cm.Parameters.AddWithValue("@MaBoPhan", ((FilterCriteria)criteria).MaBoPhan);
                    cm.Parameters.AddWithValue("@MaNhanVien", ((FilterCriteria)criteria).MaNhanVien);
                    cm.Parameters.AddWithValue("@TinhTrang", ((FilterCriteria)criteria).TinhTrang);

                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                        {
                            this.Add(InChiTietLuong_NhanVienChild.GetInChiTietLuong_NhanVienChild(dr, ((FilterCriteria)criteria).MaKyTinhLuong, ((FilterCriteria)criteria).IsNew));
                        }
                    }
                }
                else
                {
                    cm.Transaction = tr;
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandTimeout = 0;
                    cm.CommandText = "spd_Report_InChiTietLuong_CTV";
                    cm.Parameters.AddWithValue("@UserID", Security.CurrentUser.Info.UserID);
                    cm.Parameters.AddWithValue("@MaBoPhan", ((FilterCriteriaCTV)criteria).MaBoPhan);
                    cm.Parameters.AddWithValue("@MaNhanVien", ((FilterCriteriaCTV)criteria).MaNhanVien);
                    cm.Parameters.AddWithValue("@TinhTrang", ((FilterCriteriaCTV)criteria).TinhTrang);

                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                        {
                            this.Add(InChiTietLuong_NhanVienChild.GetInChiTietLuong_NhanVienChild(dr, ((FilterCriteriaCTV)criteria).MaKyTinhLuong, ((FilterCriteriaCTV)criteria).IsNew));
                        }
                    }
                }
                //cm.CommandText = "spd_Report_InChiTietLuong_HTV";
               
            }//using
        }
        #endregion //Data Access - Fetch
        #endregion //Data Access
    }
}
