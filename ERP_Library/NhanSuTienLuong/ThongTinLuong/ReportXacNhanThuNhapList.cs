
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library.Report
{
    [Serializable()]
    public class XacNhanThuNhapList : Csla.ReadOnlyListBase<XacNhanThuNhapList, XacNhanThuNhapChild>
    {

        #region Factory Methods
        private XacNhanThuNhapList()
        { /* require use of factory method */ }

        public static XacNhanThuNhapList GetXacNhanThuNhapList(int MaXacNhan)
        {
            return DataPortal.Fetch<XacNhanThuNhapList>(new FilterCriteria(MaXacNhan));
        }
        #endregion //Factory Methods

        #region Data Access

        #region Filter Criteria
        [Serializable()]
        private class FilterCriteria
        {
            public int MaXacNhan;
            public FilterCriteria(int maXacNhan)
            {
                MaXacNhan = maXacNhan;
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
                cm.CommandText = "spd_Report_XacNhanThuNhap";
                cm.Parameters.AddWithValue("@MaXacNhan", criteria.MaXacNhan);

                using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                {
                    while (dr.Read())
                        this.Add(XacNhanThuNhapChild.GetXacNhanThuNhapChild(dr));
                }
            }//using
        }
        #endregion //Data Access - Fetch
        #endregion //Data Access
    }
}
