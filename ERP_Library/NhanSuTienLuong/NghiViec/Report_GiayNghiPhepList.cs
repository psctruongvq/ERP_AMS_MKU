
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library.Report
{
    [Serializable()]
    public class GiayNghiPhepList : Csla.ReadOnlyListBase<GiayNghiPhepList, GiayNghiPhepChild>
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

        public static GiayNghiPhepList GetGiayNghiPhepTrongNuoc(int MaNghiPhep)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a GiayNghiPhepList");
            return DataPortal.Fetch<GiayNghiPhepList>(new FilterCriteria(MaNghiPhep));
        }
        public static GiayNghiPhepList GetGiayNghiPhepNgoaiNuoc(int MaNghiPhep)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a GiayNghiPhepList");
            return DataPortal.Fetch<GiayNghiPhepList>(new FilterNgoaiNuoc(MaNghiPhep));
        }
        #endregion //Factory Methods

        #region Data Access

        #region Filter Criteria
        [Serializable()]
        private class FilterCriteria
        {
            public int MaNghiPhep;
            public FilterCriteria(int maNghiPhep)
            {
                MaNghiPhep = maNghiPhep;
            }
        }
        private class FilterNgoaiNuoc : FilterCriteria
        {
            public FilterNgoaiNuoc(int MaNghiPhep)
                : base(MaNghiPhep)
            {
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

                if (criteria is FilterNgoaiNuoc)
                {
                    cm.CommandText = "spd_Report_GiayNghiPhepNgoaiNuoc";
                }
                else
                {
                    cm.CommandText = "spd_Report_GiayNghiPhepTrongNuoc";
                }
                cm.Parameters.AddWithValue("@MaNghiPhep", criteria.MaNghiPhep);

                using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                {
                    while (dr.Read())
                        this.Add(GiayNghiPhepChild.GetGiayNghiPhepChild(dr));
                }
            }//using
        }
        #endregion //Data Access - Fetch
        #endregion //Data Access
    }
}
