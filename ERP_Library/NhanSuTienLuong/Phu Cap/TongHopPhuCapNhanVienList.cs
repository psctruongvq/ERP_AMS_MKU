
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library.Report
{
    [Serializable()]
    public class TongHopPhuCapNhanVienList : Csla.ReadOnlyListBase<TongHopPhuCapNhanVienList, TongHopPhuCapNhanVienChild>
    {

        #region Factory Methods
        private TongHopPhuCapNhanVienList()
        { /* require use of factory method */ }

        public static TongHopPhuCapNhanVienList GetTongHopPhuCapNhanVienList(int MaKyTinhLuong, int MaKyPhuCap, int MaNhomPhuCap, int MaLoaiPhuCap, int LoaiNV)
        {
            return DataPortal.Fetch<TongHopPhuCapNhanVienList>(new FilterCriteria(MaKyTinhLuong, MaKyPhuCap, MaNhomPhuCap, MaLoaiPhuCap, LoaiNV));
        }

        public static TongHopPhuCapNhanVienList GetTongHopPhuCapNganHang(int MaKyTinhLuong, int MaKyPhuCap, int MaNhomPhuCap, int MaLoaiPhuCap, int LoaiNV, int MaBoPhan)
        {
            return DataPortal.Fetch<TongHopPhuCapNhanVienList>(new FilterNganHang(MaKyTinhLuong, MaKyPhuCap, MaNhomPhuCap, MaLoaiPhuCap, LoaiNV, MaBoPhan));
        }
        public static TongHopPhuCapNhanVienList GetTongHopNganHang(int MaKyTinhLuong, int MaKyPhuCap, int MaNhomPhuCap, int MaLoaiPhuCap, int LoaiNV)
        {
            return DataPortal.Fetch<TongHopPhuCapNhanVienList>(new FilterTongHopNganHang(MaKyTinhLuong, MaKyPhuCap, MaNhomPhuCap, MaLoaiPhuCap, LoaiNV));
        }

        #endregion //Factory Methods

        #region Data Access

        #region Filter Criteria
        [Serializable()]
        private class FilterCriteria
        {
            public int MaKyTinhLuong, MaKyPhuCap, MaNhomPhuCap, MaLoaiPhuCap, LoaiNV;
            public FilterCriteria(int maKyTinhLuong, int maKyPhuCap, int maNhomPhuCap, int maLoaiPhuCap, int loaiNV)
            {
                MaKyTinhLuong = maKyTinhLuong;
                MaKyPhuCap = maKyPhuCap;
                MaLoaiPhuCap = maLoaiPhuCap;
                LoaiNV = loaiNV;
                MaNhomPhuCap = maNhomPhuCap;
            }
        }

        [Serializable()]
        private class FilterNganHang: FilterCriteria
        {
            public int MaBoPhan;
            public FilterNganHang(int maKyTinhLuong, int maKyPhuCap, int maNhomPhuCap, int maLoaiPhuCap, int loaiNV, int maBoPhan)
                : base(maKyTinhLuong, maKyPhuCap, maNhomPhuCap, maLoaiPhuCap, loaiNV)
            {
                MaBoPhan = maBoPhan;
            }
        }
        [Serializable()]
        private class FilterTongHopNganHang : FilterCriteria
        {
            public FilterTongHopNganHang(int maKyTinhLuong, int maKyPhuCap, int maNhomPhuCap, int maLoaiPhuCap, int loaiNV)
                : base(maKyTinhLuong, maKyPhuCap, maNhomPhuCap, maLoaiPhuCap, loaiNV)
            {
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
                if (criteria is FilterNganHang)
                {
                    cm.CommandText = "spd_Report_PC_TongHopPhuCapNganHang";
                    cm.Parameters.AddWithValue("@MaKyTinhLuong", ((FilterNganHang)criteria).MaKyTinhLuong);
                    cm.Parameters.AddWithValue("@MaKyPhuCap", ((FilterNganHang)criteria).MaKyPhuCap);
                    cm.Parameters.AddWithValue("@MaLoaiPhuCap", ((FilterNganHang)criteria).MaLoaiPhuCap);
                    cm.Parameters.AddWithValue("@MaNhomPhuCap", ((FilterCriteria)criteria).MaNhomPhuCap);
                    cm.Parameters.AddWithValue("@LoaiNV", ((FilterNganHang)criteria).LoaiNV);
                    cm.Parameters.AddWithValue("@MaBoPhan", ((FilterNganHang)criteria).MaBoPhan);
                    cm.Parameters.AddWithValue("@UserID", ERP_Library.Security.CurrentUser.Info.UserID);
                }
                else
                {
                    if (criteria is FilterTongHopNganHang)
                        cm.CommandText = "spd_Report_PC_TongHopNganHang";
                    else
                        cm.CommandText = "spd_Report_PC_TongHopPhuCap";
                    cm.Parameters.AddWithValue("@MaKyTinhLuong", ((FilterCriteria)criteria).MaKyTinhLuong);
                    cm.Parameters.AddWithValue("@MaKyPhuCap", ((FilterCriteria)criteria).MaKyPhuCap);
                    cm.Parameters.AddWithValue("@MaNhomPhuCap", ((FilterCriteria)criteria).MaNhomPhuCap);
                    cm.Parameters.AddWithValue("@MaLoaiPhuCap", ((FilterCriteria)criteria).MaLoaiPhuCap);
                    cm.Parameters.AddWithValue("@LoaiNV", ((FilterCriteria)criteria).LoaiNV);
                    cm.Parameters.AddWithValue("@UserID", ERP_Library.Security.CurrentUser.Info.UserID);
                }
                using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                {
                    while (dr.Read())
                        if (criteria is FilterTongHopNganHang)
                            this.Add(TongHopPhuCapNhanVienChild.GetTongHopNganHangChild(dr));
                        else
                            this.Add(TongHopPhuCapNhanVienChild.GetTongHopPhuCapNhanVienChild(dr));
                }
            }//using
        }
        #endregion //Data Access - Fetch
        #endregion //Data Access
    }
}
