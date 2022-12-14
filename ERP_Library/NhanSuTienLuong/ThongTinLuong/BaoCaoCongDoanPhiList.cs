
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{
    [Serializable()]
    public class BaoCaoCongDoanPhiList : Csla.ReadOnlyListBase<BaoCaoCongDoanPhiList, BaoCaoCongDoanPhiChild>
    {

        #region Factory Methods
        private BaoCaoCongDoanPhiList()
        { /* require use of factory method */ }

        public static BaoCaoCongDoanPhiList GetBaoCaoCongDoanPhiList(int Qui, int Nam, int MaBoPhan, string LoaiNV)
        {
            return DataPortal.Fetch<BaoCaoCongDoanPhiList>(new FilterCriteria(Qui, Nam, MaBoPhan, LoaiNV));
        }

        public static BaoCaoCongDoanPhiList GetBaoCaoTongHopCongDoan(int Qui, int Nam, string LoaiNV)
        {
            return DataPortal.Fetch<BaoCaoCongDoanPhiList>(new FilterTongHop(Qui, Nam, LoaiNV));
        }

        #endregion //Factory Methods

        #region Data Access

        #region Filter Criteria
        [Serializable()]
        private class FilterCriteria
        {
            public int Qui, Nam;
            public int MaBoPhan;
            public string LoaiNV;
            public FilterCriteria(int qui, int nam, int maBoPhan, string loaiNV)
            {
                Qui = qui;
                Nam = nam;
                MaBoPhan = maBoPhan;
                LoaiNV = loaiNV;
            }
        }
        [Serializable()]
        private class FilterTongHop
        {
            public int Qui, Nam;
            public string LoaiNV;
            public FilterTongHop(int qui, int nam, string loaiNV)
            {
                Qui = qui;
                Nam = nam;
                LoaiNV = loaiNV;
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
                //tìm 3 kỳ lương tiếp theo để sử dụng cho báo cáo quí
                int Qui, Nam;
                if (criteria is FilterCriteria) Qui = ((FilterCriteria)criteria).Qui;
                else Qui = ((FilterTongHop)criteria).Qui;
                if (criteria is FilterCriteria) Nam = ((FilterCriteria)criteria).Nam;
                else Nam = ((FilterTongHop)criteria).Nam;

                cm.Transaction = tr;
                cm.CommandType = CommandType.Text;
                cm.CommandText = "Select NgayBatDau From tblnsKyTinhLuong Where Month(NgayKetThuc) = @Thang AND Year(NgayKetThuc) = @Nam AND MaKyChinh IS NULL";
                DateTime BD;
                BD = new DateTime(Nam, (Qui - 1) * 3 + 1, 1);
                //BD = BD.AddMonths(-1);

                //BD = new DateTime(Nam, Qui , 1);
                //BD = BD.Month;
                cm.Parameters.AddWithValue("@Thang", BD.Month);
                cm.Parameters.AddWithValue("@Nam", BD.Year);
                try
                {
                    BD = (DateTime)cm.ExecuteScalar();
                }
                catch
                {
                    //Không có dữ liệu để báo cáo
                    return;
                }
                DateTime KT = BD.AddMonths(2);
                cm.CommandText = "Select TOP 3 MaKy From tblnsKyTinhLuong Where NgayBatDau >= @BatDau AND NgayBatDau<=@KetThuc AND MaKyChinh IS NULL ORDER BY NgayBatDau";
                cm.Parameters.Clear();
                cm.Parameters.AddWithValue("@BatDau", BD);
                cm.Parameters.AddWithValue("@KetThuc", KT);
                int Ky1, Ky2, Ky3;
                Ky1 = Ky2 = Ky3 = 0;
                SafeDataReader ky = new SafeDataReader(cm.ExecuteReader());
                if (ky.Read())
                {
                    Ky1 = ky.GetInt32("MaKy");
                    if (ky.Read())
                    {
                        Ky2 = ky.GetInt32("MaKy");
                        if (ky.Read())
                            Ky3 = ky.GetInt32("MaKy");
                    }
                }
                ky.Close();

                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandTimeout = 0;
                cm.Parameters.Clear();
                if (criteria is FilterCriteria)
                {
                    cm.CommandText = "spd_Report_DanhSachCongDoanPhi";
                    cm.Parameters.AddWithValue("@Ky1", Ky1);
                    cm.Parameters.AddWithValue("@Ky2", Ky2);
                    cm.Parameters.AddWithValue("@Ky3", Ky3);
                    cm.Parameters.AddWithValue("@MaBoPhan", ((FilterCriteria)criteria).MaBoPhan);
                    cm.Parameters.AddWithValue("@LoaiNV", ((FilterCriteria)criteria).LoaiNV);
                    cm.Parameters.AddWithValue("@UserID", ERP_Library.Security.CurrentUser.Info.UserID);
                    
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(BaoCaoCongDoanPhiChild.GetBaoCaoCongDoanPhiChild(dr));
                    }
                }
                else
                {
                    cm.CommandText = "spd_Report_TongHopCongDoanPhi";
                    cm.Parameters.AddWithValue("@Ky1", Ky1);
                    cm.Parameters.AddWithValue("@Ky2", Ky2);
                    cm.Parameters.AddWithValue("@Ky3", Ky3);
                    cm.Parameters.AddWithValue("@LoaiNV", ((FilterTongHop)criteria).LoaiNV);
                    cm.Parameters.AddWithValue("@UserID", ERP_Library.Security.CurrentUser.Info.UserID);

                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(BaoCaoCongDoanPhiChild.GetBaoCaoTongHop(dr));
                    }
                }
            }//using
        }
        #endregion //Data Access - Fetch
        #endregion //Data Access
    }
}
