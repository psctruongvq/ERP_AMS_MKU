
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{
    [Serializable()]
    public class GiayNghiPhepNuocNgoaiList : Csla.ReadOnlyListBase<GiayNghiPhepNuocNgoaiList, GiayNghiPhepNuocNgoaiListChild>
    {

        #region Authorization Rules

        public static bool CanGetObject()
        {
            //TODO: Define CanGetObject permission in GiayNghiPhepNuocNgoaiList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("GiayNghiPhepNuocNgoaiListViewGroup"))
            //	return true;
            //return false;
        }
        #endregion //Authorization Rules

        #region Factory Methods
        private GiayNghiPhepNuocNgoaiList()
        { /* require use of factory method */ }

        public static GiayNghiPhepNuocNgoaiList GetGiayNghiPhepNuocNgoaiList(DateTime TuNgay, DateTime DenNgay)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a GiayNghiPhepNuocNgoaiList");
            return DataPortal.Fetch<GiayNghiPhepNuocNgoaiList>(new FilterByNgay(TuNgay, DenNgay));
        }
        public static GiayNghiPhepNuocNgoaiList GetGiayNghiPhepNuocNgoaiListByNhanVien(DateTime TuNgay, DateTime DenNgay, long MaNhanVien)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a GiayNghiPhepNuocNgoaiList");
            return DataPortal.Fetch<GiayNghiPhepNuocNgoaiList>(new FilterByMaNhanVien(TuNgay, DenNgay, MaNhanVien));
        }
        public static GiayNghiPhepNuocNgoaiList GetGiayNghiPhepNuocNgoaiListByBoPhan(DateTime TuNgay, DateTime DenNgay, int MaBoPhan)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a GiayNghiPhepNuocNgoaiList");
            return DataPortal.Fetch<GiayNghiPhepNuocNgoaiList>(new FilterByMaBoPhan(TuNgay, DenNgay, MaBoPhan));
        }
        #endregion //Factory Methods

        #region Data Access

        #region Filter Criteria
        [Serializable()]
        private class FilterByNgay
        {
            public DateTime _TuNgay;
            public DateTime _DenNgay;

            public FilterByNgay(DateTime TuNgay, DateTime DenNgay)
            {
                _TuNgay = TuNgay;
                _DenNgay = DenNgay;
            }
        }
        [Serializable()]
        private class FilterByMaNhanVien
        {
            public long _MaNhanVien;
            public DateTime _TuNgay, _DenNgay;
            public FilterByMaNhanVien(DateTime TuNgay, DateTime DenNgay, long MaNhanVien)
            {
                _TuNgay = TuNgay;
                _DenNgay = DenNgay;
                _MaNhanVien = MaNhanVien;
            }
        }

        [Serializable()]
        private class FilterByMaBoPhan
        {
            public DateTime _TuNgay, _DenNgay;
            public int _MaBoPhan;
            public FilterByMaBoPhan(DateTime TuNgay, DateTime DenNgay, int MaBoPhan)
            {
                _TuNgay = TuNgay;
                _DenNgay = DenNgay;
                _MaBoPhan = MaBoPhan;
            }
        }
        #endregion //Filter Criteria

        #region Data Access - Fetch
        private void DataPortal_Fetch(Object criteria)
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
                if (criteria is FilterByNgay)
                {
                    cm.CommandText = "sp_GetGiayNghiPhepNuocNgoaiListByNgay";
                    cm.Parameters.AddWithValue("@TuNgay", ((FilterByNgay)criteria)._TuNgay);
                    cm.Parameters.AddWithValue("@DenNgay", ((FilterByNgay)criteria)._DenNgay);
                }
                else if (criteria is FilterByMaNhanVien)
                {
                    cm.CommandText = "sp_GetGiayNghiPhepNuocNgoaiListByMaNhanVien";
                    cm.Parameters.AddWithValue("@TuNgay", ((FilterByMaNhanVien)criteria)._TuNgay);
                    cm.Parameters.AddWithValue("@DenNgay", ((FilterByMaNhanVien)criteria)._DenNgay);
                    cm.Parameters.AddWithValue("@MaNhanVien", ((FilterByMaNhanVien)criteria)._MaNhanVien);
                }
                else
                {
                    cm.CommandText = "sp_GetGiayNghiPhepNuocNgoaiListByMaBoPhan";
                    cm.Parameters.AddWithValue("@TuNgay", ((FilterByMaBoPhan)criteria)._TuNgay);
                    cm.Parameters.AddWithValue("@DenNgay", ((FilterByMaBoPhan)criteria)._DenNgay);
                    cm.Parameters.AddWithValue("@MaBoPhan", ((FilterByMaBoPhan)criteria)._MaBoPhan);
                }
                using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                {
                    while (dr.Read())
                        this.Add(GiayNghiPhepNuocNgoaiListChild.GetGiayNghiPhepNuocNgoaiListChild(dr));
                }
            }//using
        }
        #endregion //Data Access - Fetch
        #endregion //Data Access
    }
}
