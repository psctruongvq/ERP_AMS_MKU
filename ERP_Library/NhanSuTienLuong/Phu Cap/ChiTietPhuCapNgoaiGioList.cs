
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library.Report
{
    [Serializable()]
    public class ChiTietPhuCapNgoaiGioList : Csla.ReadOnlyListBase<ChiTietPhuCapNgoaiGioList, ChiTietPhuCapNgoaiGioChild>
    {
        private int _socot = 0;

        #region Factory Methods
        private ChiTietPhuCapNgoaiGioList()
        { /* require use of factory method */ }

        public static ChiTietPhuCapNgoaiGioList GetChiTietPhuCapNgoaiGioList(int MaKyTinhLuong, int MaKyPhuCap, int MaBoPhan, int MaNganHang, int MaNhomPhuCap, int LoaiNV)
        {
            return DataPortal.Fetch<ChiTietPhuCapNgoaiGioList>(new FilterCriteria(MaKyTinhLuong, MaKyPhuCap, MaBoPhan, MaNganHang, MaNhomPhuCap, LoaiNV));
        }
        #endregion //Factory Methods

        #region Data Access

        #region Filter Criteria
        [Serializable()]
        private class FilterCriteria
        {
            public int MaKyTinhLuong,MaKyPhuCap, MaBoPhan, MaNganHang;
            public int MaNhomPhuCap, LoaiNV;
            public FilterCriteria(int maKyTinhLuong, int maKyPhuCap, int maBoPhan, int maNganHang, int maNhomPhuCap, int loaiNV)
            {
                MaKyTinhLuong = maKyTinhLuong;
                MaKyPhuCap = maKyPhuCap;
                MaBoPhan = maBoPhan;
                MaNganHang = maNganHang;
                MaNhomPhuCap = maNhomPhuCap;
                LoaiNV = loaiNV;
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
                cm.CommandText = "spd_Report_ChiTietPhuCapNgoaiGio";
                cm.Parameters.AddWithValue("@MaKyTinhLuong", criteria.MaKyTinhLuong);
                cm.Parameters.AddWithValue("@MaKyPhuCap", criteria.MaKyPhuCap);
                cm.Parameters.AddWithValue("@MaBoPhan", criteria.MaBoPhan);
                cm.Parameters.AddWithValue("@MaNganHang", criteria.MaNganHang);
                cm.Parameters.AddWithValue("@MaNhomPhuCap", criteria.MaNhomPhuCap);
                cm.Parameters.AddWithValue("@LoaiNV", criteria.LoaiNV);
                cm.Parameters.AddWithValue("@UserID", ERP_Library.Security.CurrentUser.Info.UserID);
                cm.Parameters.Add("@SoCot", SqlDbType.Int);
                cm.Parameters["@SoCot"].Direction = ParameterDirection.Output;

                using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                {
                    while (dr.Read())
                        this.Add(ChiTietPhuCapNgoaiGioChild.GetChiTietPhuCapNgoaiGioChild(dr));
                }
                _socot = Convert.ToInt32(cm.Parameters["@SoCot"].Value);
            }//using
        }
        #endregion //Data Access - Fetch
        #endregion //Data Access

        public int SoCot
        {
            get
            {
                return _socot;
            }
        }
    }
}
