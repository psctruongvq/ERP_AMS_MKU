﻿
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library.Report
{
    [Serializable()]
    public class InChiTietLuong_TongHopList : Csla.ReadOnlyListBase<InChiTietLuong_TongHopList, InChiTietLuong_TongHopChild>
    {

        #region Factory Methods
        private InChiTietLuong_TongHopList()
        { /* require use of factory method */ }
        internal InChiTietLuong_TongHopList(SafeDataReader dr)
        {
            Fetch(dr);
        }

        public static InChiTietLuong_TongHopList GetInChiTietLuong_TongHopList(long MaNhanVien, int MaKyTinhLuong)
        {
            return DataPortal.Fetch<InChiTietLuong_TongHopList>(new FilterCriteria(MaNhanVien, MaKyTinhLuong));
        }
        #endregion //Factory Methods

        #region Data Access

        #region Filter Criteria
        [Serializable()]
        private class FilterCriteria
        {
            public long MaNhanVien;
            public int MaKyTinhLuong;

            public FilterCriteria(long maNhanVien, int maKyTinhLuong)
            {
                MaNhanVien=maNhanVien;
                MaKyTinhLuong = maKyTinhLuong;
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
                cm.CommandText = "spd_Report_InChiTietLuong";
                cm.Parameters.AddWithValue("@MaNhanVien", criteria.MaNhanVien);
                cm.Parameters.AddWithValue("@MaKyTinhLuong", criteria.MaKyTinhLuong);

                using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                {
                    while (dr.Read())
                        this.Add(InChiTietLuong_TongHopChild.GetInChiTietLuong_TongHopChild(dr));
                }
            }//using
        }
        #endregion //Data Access - Fetch
        #endregion //Data Access

        internal void Fetch(SafeDataReader dr)
        {
            RaiseListChangedEvents = false;
            IsReadOnly = false;
            while (dr.Read())
                this.Add(InChiTietLuong_TongHopChild.GetInChiTietLuong_TongHopChild(dr));
            IsReadOnly = true;
            RaiseListChangedEvents = true;
        }
    }
}
