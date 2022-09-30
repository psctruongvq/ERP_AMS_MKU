
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library.Report
{
    [Serializable()]
    public class ChiTietPhuCapNhanVienList : Csla.ReadOnlyListBase<ChiTietPhuCapNhanVienList, ChiTietPhuCapNhanVienChild>
    {

        #region Factory Methods
        private ChiTietPhuCapNhanVienList()
        { /* require use of factory method */ }

        public static ChiTietPhuCapNhanVienList GetChiTietPhuCapNhanVienList(int MaKyTinhLuong, int MaKyPhuCap, int MaNhomPhuCap, int MaLoaiPhuCap, int LoaiNV, int MaBoPhan, int MaNganHang)
        {
            return DataPortal.Fetch<ChiTietPhuCapNhanVienList>(new FilterCriteria(MaKyTinhLuong, MaKyPhuCap, MaNhomPhuCap, MaLoaiPhuCap, LoaiNV, MaBoPhan, MaNganHang));
        }
        public static ChiTietPhuCapNhanVienList GetBaoCaoNganHang(int MaKyTinhLuong, int MaKyPhuCap, int MaNhomPhuCap, int MaLoaiPhuCap, int LoaiNV, int MaBoPhan, int MaNganHang)
        {
            return DataPortal.Fetch<ChiTietPhuCapNhanVienList>(new FilterNganHang(MaKyTinhLuong, MaKyPhuCap, MaNhomPhuCap, MaLoaiPhuCap, LoaiNV, MaBoPhan, MaNganHang));
        }
        public static ChiTietPhuCapNhanVienList GetBaoCaoNganHang2Nhom(int MaKyTinhLuong, int MaKyPhuCap, int LoaiNV, int MaBoPhan, int MaNganHang)
        {
            return DataPortal.Fetch<ChiTietPhuCapNhanVienList>(new FilterNganHang2Nhom(MaKyTinhLuong, MaKyPhuCap, LoaiNV, MaBoPhan, MaNganHang));
        }
        #endregion //Factory Methods

        #region Data Access

        #region Filter Criteria
        [Serializable()]
        private class FilterCriteria
        {
            public int MaKyTinhLuong, MaKyPhuCap, MaNhomPhuCap, MaLoaiPhuCap, LoaiNV, MaBoPhan, MaNganHang;
            public FilterCriteria(int maKyTinhLuong, int maKyPhucap, int maNhomPhuCap, int maLoaiPhuCap, int loaiNV, int maBoPhan, int maNganHang)
            {
                MaKyTinhLuong = maKyTinhLuong;
                MaKyPhuCap = maKyPhucap;
                MaNhomPhuCap = maNhomPhuCap;
                MaLoaiPhuCap = maLoaiPhuCap;
                LoaiNV = loaiNV;
                MaBoPhan = maBoPhan;
                MaNganHang = maNganHang;
            }
        }
        [Serializable()]
        private class FilterNganHang
        {
            public int MaKyTinhLuong, MaKyPhuCap, MaNhomPhuCap, MaLoaiPhuCap, LoaiNV, MaBoPhan, MaNganHang;
            public FilterNganHang(int maKyTinhLuong, int maKyPhuCap, int maNhomPhuCap, int maLoaiPhuCap, int loaiNV, int maBoPhan, int maNganHang)
            {
                MaKyTinhLuong = maKyTinhLuong;
                MaKyPhuCap = maKyPhuCap;
                MaNhomPhuCap = maNhomPhuCap;
                MaBoPhan = maBoPhan;
                LoaiNV = loaiNV;
                MaNganHang = maNganHang;
                MaLoaiPhuCap = maLoaiPhuCap;
            }
        }
        [Serializable()]
        private class FilterNganHang2Nhom
        {
            public int MaKyTinhLuong, MaKyPhuCap, LoaiNV, MaBoPhan, MaNganHang;
            public FilterNganHang2Nhom(int maKyTinhLuong, int maKyPhuCap, int loaiNV, int maBoPhan, int maNganHang)
            {
                MaKyTinhLuong = maKyTinhLuong;
                MaKyPhuCap = maKyPhuCap;
                MaBoPhan = maBoPhan;
                LoaiNV = loaiNV;
                MaNganHang = maNganHang;
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
                cm.CommandTimeout = 0;
                if (criteria is FilterCriteria)
                {
                    cm.CommandText = "spd_Report_PC_ChiTietPhuCap";
                    cm.Parameters.AddWithValue("@MaKyTinhLuong", ((FilterCriteria)criteria).MaKyTinhLuong);
                    cm.Parameters.AddWithValue("@MaKyPhuCap", ((FilterCriteria)criteria).MaKyPhuCap);
                    cm.Parameters.AddWithValue("@MaLoaiPhuCap", ((FilterCriteria)criteria).MaLoaiPhuCap);
                    cm.Parameters.AddWithValue("@MaNhomPhuCap", ((FilterCriteria)criteria).MaNhomPhuCap);
                    cm.Parameters.AddWithValue("@LoaiNV", ((FilterCriteria)criteria).LoaiNV);
                    cm.Parameters.AddWithValue("@MaBoPhan", ((FilterCriteria)criteria).MaBoPhan);
                    cm.Parameters.AddWithValue("@MaNganHang", ((FilterCriteria)criteria).MaNganHang);
                    cm.Parameters.AddWithValue("@UserID", ERP_Library.Security.CurrentUser.Info.UserID);
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    { 
                        while (dr.Read())
                            this.Add(ChiTietPhuCapNhanVienChild.GetChiTietPhuCapNhanVienChild(dr));
                    }
                }
                else if (criteria is FilterNganHang)
                {
                    cm.CommandText = "spd_Report_ChiTietPhuCapNganHang";
                    cm.Parameters.AddWithValue("@MaKyTinhLuong", ((FilterNganHang)criteria).MaKyTinhLuong);
                    cm.Parameters.AddWithValue("@MaKyPhuCap", ((FilterNganHang)criteria).MaKyPhuCap);
                    cm.Parameters.AddWithValue("@MaNhomPhuCap", ((FilterNganHang)criteria).MaNhomPhuCap);
                    cm.Parameters.AddWithValue("@MaLoaiPhuCap", ((FilterNganHang)criteria).MaLoaiPhuCap);
                    cm.Parameters.AddWithValue("@LoaiNV", ((FilterNganHang)criteria).LoaiNV);
                    cm.Parameters.AddWithValue("@MaBoPhan", ((FilterNganHang)criteria).MaBoPhan);
                    cm.Parameters.AddWithValue("@MaNganHang", ((FilterNganHang)criteria).MaNganHang);
                    cm.Parameters.AddWithValue("@UserID", ERP_Library.Security.CurrentUser.Info.UserID);
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(ChiTietPhuCapNhanVienChild.GetChiTietPhuCapNhanVienChild(dr));
                    }
                }
                else
                {
                    cm.CommandText = "spd_Report_ChiTietPhuCapNganHang2Nhom";
                    cm.Parameters.AddWithValue("@MaKyTinhLuong", ((FilterNganHang2Nhom)criteria).MaKyTinhLuong);
                    cm.Parameters.AddWithValue("@MaKyPhuCap", ((FilterNganHang2Nhom)criteria).MaKyPhuCap);
                    cm.Parameters.AddWithValue("@LoaiNV", ((FilterNganHang2Nhom)criteria).LoaiNV);
                    cm.Parameters.AddWithValue("@MaBoPhan", ((FilterNganHang2Nhom)criteria).MaBoPhan);
                    cm.Parameters.AddWithValue("@MaNganHang", ((FilterNganHang2Nhom)criteria).MaNganHang);
                    cm.Parameters.AddWithValue("@UserID", ERP_Library.Security.CurrentUser.Info.UserID);
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(ChiTietPhuCapNhanVienChild.GetChiTietPhuCapNhanVienChild2Nhom(dr));
                    }
                }
            }//using
        }
        #endregion //Data Access - Fetch
        #endregion //Data Access
    }
}
