
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{
    [Serializable()]
    public class PhuCapFieldList : Csla.ReadOnlyListBase<PhuCapFieldList, PhuCapFieldChild>
    {

        #region Authorization Rules

        public static bool CanGetObject()
        {
            //TODO: Define CanGetObject permission in PhuCapFieldList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("PhuCapFieldListViewGroup"))
            //	return true;
            //return false;
        }
        #endregion //Authorization Rules

        #region Factory Methods
        private PhuCapFieldList()
        { /* require use of factory method */ 
        }

        public static PhuCapFieldList GetPhuCapFieldList()
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a PhuCapFieldList");
            return DataPortal.Fetch<PhuCapFieldList>(new FilterCriteria(0));
        }
        public static PhuCapFieldList GetPhuCapFieldListDieuKien()
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a PhuCapFieldList");
            return DataPortal.Fetch<PhuCapFieldList>(new FilterCriteria(1));
        }
        public static PhuCapFieldList GetPhuCapFieldListCongThuc()
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a PhuCapFieldList");
            return DataPortal.Fetch<PhuCapFieldList>(new FilterCriteria(2));
        }
        #endregion //Factory Methods

        #region Data Access

        #region Filter Criteria
        [Serializable()]
        private class FilterCriteria
        {
            public int Loai = 0;//0:tất cả; 1:điều kiện; 2:công thức
            public FilterCriteria(int loai)
            {
                Loai = loai;
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
                switch (criteria.Loai)
                {
                    case 0:
                        cm.CommandText = "spd_Select_PhuCapFieldList";
                        break;
                    case 1:
                        cm.CommandText = "spd_Select_PhuCapFieldListDieuKien";
                        break;
                    case 2:
                        cm.CommandText = "spd_Select_PhuCapFieldListCongThuc";
                        break;
                }


                using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                {
                    while (dr.Read())
                        this.Add(PhuCapFieldChild.GetPhuCapFieldChild(dr));
                }
            }//using
        }
        #endregion //Data Access - Fetch
        #endregion //Data Access
    }
}
