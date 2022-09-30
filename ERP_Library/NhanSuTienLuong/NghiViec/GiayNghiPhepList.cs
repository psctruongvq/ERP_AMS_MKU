
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{
    [Serializable()]
    public class GiayNghiPhepList : Csla.ReadOnlyListBase<GiayNghiPhepList, GiayNghiPhepListChild>
    {

        #region Authorization Rules

        public static bool CanGetObject()
        {
            //TODO: Define CanGetObject permission in GiayNghiPhepList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("GiayNghiPhepListViewGroup"))
            //	return true;
            //return false;
        }
        #endregion //Authorization Rules

        #region Factory Methods
        private GiayNghiPhepList()
        { /* require use of factory method */ }

        public static GiayNghiPhepList GetGiayNghiPhepList(DateTime TuNgay, DateTime DenNgay)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a GiayNghiPhepList");
            return DataPortal.Fetch<GiayNghiPhepList>(new FilterByNgay(TuNgay, DenNgay));
        }
        public static GiayNghiPhepList GetGiayNghiPhepListByNhanVien(DateTime TuNgay, DateTime DenNgay, long MaNhanVien)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a GiayNghiPhepList");
            return DataPortal.Fetch<GiayNghiPhepList>(new FilterByNgay_NhanVien(TuNgay,DenNgay,MaNhanVien));
        }
        public static GiayNghiPhepList GetGiayNghiPhepListByBoPhan(DateTime TuNgay, DateTime DenNgay, int MaBoPhan)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a GiayNghiPhepList");
            return DataPortal.Fetch<GiayNghiPhepList>(new FilterByNgay_BoPhan(TuNgay,DenNgay,MaBoPhan));
        }

        #endregion //Factory Methods

        #region Data Access

        #region Filter Criteria
        [Serializable()]
        private class FilterByNgay
        {
            public DateTime _TuNgay, _DenNgay;
            public FilterByNgay(DateTime TuNgay, DateTime DenNgay)
            {
                _TuNgay = TuNgay;
                _DenNgay = DenNgay;
            }
        }
        [Serializable()]
        private class FilterByNgay_BoPhan
        {
            public DateTime _TuNgay;
            public DateTime _DenNgay;
            public int _MaBoPhan;
            public FilterByNgay_BoPhan(DateTime TuNgay, DateTime DenNgay, int MaBoPhan)
            {
                _TuNgay = TuNgay;
                _DenNgay = DenNgay;
                _MaBoPhan = MaBoPhan;
            }
        }
        [Serializable()]
        private class FilterByNgay_NhanVien
        {
            public DateTime _TuNgay, _DenNgay;
            public long _MaNhanVien;
            public FilterByNgay_NhanVien(DateTime TuNgay, DateTime DenNgay, long MaNhanVien)
            {
                _TuNgay = TuNgay;
                _DenNgay = DenNgay;
                _MaNhanVien = MaNhanVien;
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
                    cm.CommandText = "sp_GetGiayNghiPhepListByNgay";
                    cm.Parameters.AddWithValue("@TuNgay", ((FilterByNgay) criteria)._TuNgay);
                    cm.Parameters.AddWithValue("@DenNgay", ((FilterByNgay)criteria)._DenNgay);
                }
                else if(criteria is FilterByNgay_BoPhan)
                {
                    cm.CommandText = "sp_GetGiayNghiPhepListByMaBoPhan";
                    cm.Parameters.AddWithValue("@TuNgay", ((FilterByNgay_BoPhan)criteria)._TuNgay);
                    cm.Parameters.AddWithValue("@DenNgay", ((FilterByNgay_BoPhan)criteria)._DenNgay);
                    cm.Parameters.AddWithValue("@MaBoPhan", ((FilterByNgay_BoPhan)criteria)._MaBoPhan);
                }
                else if (criteria is FilterByNgay_NhanVien)
                {
                    cm.CommandText = "sp_GetGiayNghiPhepListByMaNhanVien";
                    cm.Parameters.AddWithValue("@TuNgay", ((FilterByNgay_NhanVien)criteria)._TuNgay);
                    cm.Parameters.AddWithValue("@DenNgay", ((FilterByNgay_NhanVien)criteria)._DenNgay);
                    cm.Parameters.AddWithValue("@MaNhanVien", ((FilterByNgay_NhanVien)criteria)._MaNhanVien);
                }
                
                using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                {
                    while (dr.Read())
                        this.Add(GiayNghiPhepListChild.GetGiayNghiPhepListChild(dr));
                }

            }//using
        }
        #endregion //Data Access - Fetch
        #endregion //Data Access
    }
}
