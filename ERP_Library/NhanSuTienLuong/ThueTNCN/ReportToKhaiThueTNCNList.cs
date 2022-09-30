
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library.Report
{
    [Serializable()]
    public class ToKhaiThueTNCNList : Csla.ReadOnlyListBase<ToKhaiThueTNCNList, ToKhaiThueTNCNChild>
    {

        #region Factory Methods
        private ToKhaiThueTNCNList()
        { /* require use of factory method */ }

        public static ToKhaiThueTNCNList GetToKhaiThueTNCNList(int MaKyTinhLuong, int MaBoPhan,int namTinh)
        {
            return DataPortal.Fetch<ToKhaiThueTNCNList>(new FilterCriteria(MaKyTinhLuong, MaBoPhan,namTinh));
        }
        public static ToKhaiThueTNCNList GetToKhaiThueTNCNListByThuong(int MaKyTinhLuong, int MaBoPhan, int namTinh)
        {
            return DataPortal.Fetch<ToKhaiThueTNCNList>(new FilterCriteriaByThuong(MaKyTinhLuong, MaBoPhan, namTinh));
        }
        #endregion //Factory Methods

        #region Data Access

        #region Filter Criteria
        [Serializable()]
        private class FilterCriteria
        {
            public int MaKyTinhLuong, MaBoPhan;
            public int NamTinh;
            public FilterCriteria(int maKyTinhLuong, int maBoPhan,int namTinh)
            {
                MaKyTinhLuong = maKyTinhLuong;
                MaBoPhan = maBoPhan;
                this.NamTinh = namTinh;
            }
        }
        private class FilterCriteriaByThuong
        {
            public int MaKyTinhLuong, MaBoPhan;
            public int NamTinh;
            public FilterCriteriaByThuong(int maKyTinhLuong, int maBoPhan, int namTinh)
            {
                MaKyTinhLuong = maKyTinhLuong;
                MaBoPhan = maBoPhan;
                this.NamTinh = namTinh;
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
                cm.CommandTimeout = 0;
                cm.CommandType = CommandType.StoredProcedure;
                if (criteria is FilterCriteria)
                {
                    if (KyTinhLuong.GetKyTinhLuong(((FilterCriteria)criteria).MaKyTinhLuong).Nam < 2014)
                    {
                        cm.CommandText = "spd_Report_ToKhaiThueTNCN";
                        cm.Parameters.AddWithValue("@MaKyTinhLuong", ((FilterCriteria)criteria).MaKyTinhLuong);
                        cm.Parameters.AddWithValue("@MaBoPhan", ((FilterCriteria)criteria).MaBoPhan);
                        cm.Parameters.AddWithValue("@NamTinh", ((FilterCriteria)criteria).NamTinh);
                    }
                    if (KyTinhLuong.GetKyTinhLuong(((FilterCriteria)criteria).MaKyTinhLuong).Nam >=2014)
                    {
                        cm.CommandText = "spd_Report_ToKhaiThueTNCNNew";
                        cm.Parameters.AddWithValue("@MaKyTinhLuong", ((FilterCriteria)criteria).MaKyTinhLuong);
                        cm.Parameters.AddWithValue("@MaBoPhan", ((FilterCriteria)criteria).MaBoPhan);
                        cm.Parameters.AddWithValue("@NamTinh", ((FilterCriteria)criteria).NamTinh);
                    }
                }
                else if (criteria is FilterCriteriaByThuong)
                {
                    cm.CommandText = "spd_Report_ToKhaiThueTNCNByThuong";
                    cm.Parameters.AddWithValue("@MaKyTinhLuong", ((FilterCriteriaByThuong)criteria).MaKyTinhLuong);
                    cm.Parameters.AddWithValue("@MaBoPhan", ((FilterCriteriaByThuong)criteria).MaBoPhan);
                    cm.Parameters.AddWithValue("@NamTinh", ((FilterCriteriaByThuong)criteria).NamTinh);
                }
               
                cm.Parameters.AddWithValue("@UserID", Security.CurrentUser.Info.UserID);

                using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                {
                    while (dr.Read())
                        this.Add(ToKhaiThueTNCNChild.GetToKhaiThueTNCNChild(dr));
                }
            }//using
        }
        #endregion //Data Access - Fetch
        #endregion //Data Access
    }
}
