
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{
    [Serializable()]
    public class LoaiNhanVienList : Csla.BusinessListBase<LoaiNhanVienList, LoaiNhanVienChild>
    {

        #region Factory Methods
        private LoaiNhanVienList()
        { /* require use of factory method */ }

        public static LoaiNhanVienList NewLoaiNhanVienChildList()
        {
            return new LoaiNhanVienList();
        }

        public static LoaiNhanVienList GetLoaiNhanVienList()
        {
            return DataPortal.Fetch<LoaiNhanVienList>(new FilterCriteria());
        }
        #endregion //Factory Methods

        #region Data Access

        #region Filter Criteria
        [Serializable()]
        private class FilterCriteria
        {

            public FilterCriteria()
            {

            }
        }
        #endregion //Filter Criteria

        #region Data Access - Fetch
        private void DataPortal_Fetch(FilterCriteria criteria)
        {
            RaiseListChangedEvents = false;

            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();

                ExecuteFetch(cn, criteria);
            }//using

            RaiseListChangedEvents = true;
        }

        private void ExecuteFetch(SqlConnection cn, FilterCriteria criteria)
        {
            using (SqlCommand cm = cn.CreateCommand())
            {
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_Select_LoaiNhanVienList";


                using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                {
                    while (dr.Read())
                        this.Add(LoaiNhanVienChild.GetLoaiNhanVienChild(dr));
                }
            }//using
        }
        #endregion //Data Access - Fetch


        #endregion //Data Access
    }
}
