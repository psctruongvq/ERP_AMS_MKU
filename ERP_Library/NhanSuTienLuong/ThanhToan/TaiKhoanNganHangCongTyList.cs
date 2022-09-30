
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library.ThanhToan
{
    [Serializable()]
    public class TaiKhoanNganHangCongTyList : Csla.BusinessListBase<TaiKhoanNganHangCongTyList, TaiKhoanNganHangCongTyChild>
    {

        #region Factory Methods
        public static TaiKhoanNganHangCongTyList NewTaiKhoanNganHangCongTyList()
        {
            return new TaiKhoanNganHangCongTyList();
        }
        private TaiKhoanNganHangCongTyList()
        { /* require use of factory method */ }

        public static TaiKhoanNganHangCongTyList GetTaiKhoanNganHangCongTyList()
        {
            return DataPortal.Fetch<TaiKhoanNganHangCongTyList>(new FilterCriteria());
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
            //IsReadOnly = false;

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

            //IsReadOnly = true;
            RaiseListChangedEvents = true;
        }

        private void ExecuteFetch(SqlTransaction tr, FilterCriteria criteria)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_Select_TaiKhoanNganHangCongTy";
                cm.Parameters.AddWithValue("@MaCongTy", ERP_Library.Security.CurrentUser.Info.MaCongTy);

                using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                {
                    while (dr.Read())
                        this.Add(TaiKhoanNganHangCongTyChild.GetTaiKhoanNganHangCongTyChild(dr));
                }
            }//using
        }
        #endregion //Data Access - Fetch
        #endregion //Data Access
    }
}
