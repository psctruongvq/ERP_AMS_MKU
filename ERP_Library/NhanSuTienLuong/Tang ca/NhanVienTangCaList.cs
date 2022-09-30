
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{
    [Serializable()]
    public class NhanVienTangCaList : Csla.ReadOnlyListBase<NhanVienTangCaList, NhanVienTangCaListChild>
    {

        #region Authorization Rules

        public static bool CanGetObject()
        {
            //TODO: Define CanGetObject permission in NhanVienTangCaList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("NhanVienTangCaListViewGroup"))
            //	return true;
            //return false;
        }
        #endregion //Authorization Rules

        #region Factory Methods
        private NhanVienTangCaList()
        { /* require use of factory method */ }

        public static NhanVienTangCaList GetNhanVienTangCaList(DateTime TuNgay, DateTime DenNgay, Nullable<int> maBoPhan, Nullable<long> maNhanVien)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a NhanVienTangCaList");
            if (maNhanVien.HasValue)
                return DataPortal.Fetch<NhanVienTangCaList>(new FilterCriteria(TuNgay, DenNgay, null, maNhanVien));
            else
                return DataPortal.Fetch<NhanVienTangCaList>(new FilterCriteria(TuNgay, DenNgay, maBoPhan, null));
        }
        #endregion //Factory Methods

        #region Data Access

        #region Filter Criteria
        [Serializable()]
        private class FilterCriteria
        {
            public DateTime TuNgay, DenNgay;
            public Nullable<int> MaBoPhan;
            public Nullable<long> MaNhanVien;

            public FilterCriteria(DateTime tuNgay, DateTime denNgay, Nullable<int> maBoPhan, Nullable<long> maNhanVien)
            {
                this.TuNgay = tuNgay;
                this.DenNgay = denNgay;
                this.MaBoPhan = maBoPhan;
                this.MaNhanVien = maNhanVien;
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
                cm.CommandText = "spd_Select_NhanVienTangCaList";
                cm.Parameters.AddWithValue("@TuNgay", criteria.TuNgay);
                cm.Parameters.AddWithValue("@DenNgay", criteria.DenNgay);
                if (criteria.MaBoPhan.HasValue)
                    cm.Parameters.AddWithValue("@MaBoPhan", criteria.MaBoPhan);
                else
                    cm.Parameters.AddWithValue("@MaBoPhan", DBNull.Value);
                if (criteria.MaNhanVien.HasValue)
                    cm.Parameters.AddWithValue("@MaNhanVien", criteria.MaNhanVien);
                else
                    cm.Parameters.AddWithValue("@MaNhanVien", DBNull.Value);

                using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                {
                    while (dr.Read())
                        this.Add(NhanVienTangCaListChild.GetNhanVienTangCaListChild(dr));
                }
            }//using
        }
        #endregion //Data Access - Fetch
        #endregion //Data Access
    }
}
