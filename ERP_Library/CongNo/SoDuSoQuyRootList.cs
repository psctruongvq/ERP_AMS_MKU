
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{
    //long
    [Serializable()]
    public class SoDuSoQuyList : Csla.BusinessListBase<SoDuSoQuyList, SoDuSoQuy>
    {

        #region Factory Methods
        private SoDuSoQuyList()
        { /* require use of factory method */ }

        public static SoDuSoQuyList NewSoDuSoQuyList()
        {
            return new SoDuSoQuyList();
        }


        public static SoDuSoQuyList GetSoDuSoQuyList()
        {
            return DataPortal.Fetch<SoDuSoQuyList>(new FilterCriteria());
        }

        public static SoDuSoQuyList GetSoDuSoQuyBySoQuy(int maSoQuy, int maBoPhan, int nam)
        {
            return DataPortal.Fetch<SoDuSoQuyList>(new FilterCriteriaByMaSoQuy(maSoQuy, maBoPhan, nam));
        }

        public static SoDuSoQuyList GetSoDuSoQuyByNam(int maBoPhan, int nam)
        {
            return DataPortal.Fetch<SoDuSoQuyList>(new FilterCriteriaByNam(maBoPhan, nam));
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

        [Serializable()]
        private class FilterCriteriaByMaSoQuy
        {
            private int maSoQuy;
            private int maBoPhan;
            private int nam;

            public int MaSoQuy
            {
                get { return this.maSoQuy; }
            }
            public int MaBoPhan
            {
                get { return this.maBoPhan; }
            }
            public int Nam
            {
                get { return this.nam; }
            }

            public FilterCriteriaByMaSoQuy(int maSoQuy, int maBoPhan, int nam)
            {
                this.maSoQuy = maSoQuy;
                this.maBoPhan = maBoPhan;
                this.nam = nam;
            }
        }

        [Serializable()]
        private class FilterCriteriaByNam
        {            
            private int maBoPhan;
            private int nam;

            public int MaBoPhan
            {
                get { return this.maBoPhan; }
            }
            public int Nam
            {
                get { return this.nam; }
            }

            public FilterCriteriaByNam(int maBoPhan, int nam)
            {
                this.maBoPhan = maBoPhan;
                this.nam = nam;
            }
        }
        #endregion //Filter Criteria

        #region Data Access - Fetch
        private new void DataPortal_Fetch(object criteria)
        {
            RaiseListChangedEvents = false;

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

            RaiseListChangedEvents = true;
        }

        private void ExecuteFetch(SqlTransaction tr, object criteria)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;

                if (criteria is FilterCriteria)
                {
                    cm.CommandText = "spd_SelecttblSoDuSoQuysAll";
                }
                else if (criteria is FilterCriteriaByMaSoQuy)
                {
                    cm.CommandText = "spd_SelecttblSoDuSoQuyByMaSoQuy";

                    cm.Parameters.AddWithValue("@MaSoQuy", ((FilterCriteriaByMaSoQuy)criteria).MaSoQuy);
                    cm.Parameters.AddWithValue("@MaBoPhan", ((FilterCriteriaByMaSoQuy)criteria).MaBoPhan);
                    cm.Parameters.AddWithValue("@Nam", ((FilterCriteriaByMaSoQuy)criteria).Nam);
                }
                else if (criteria is FilterCriteriaByNam)
                {
                    cm.CommandText = "spd_SelecttblSoDuSoQuyByNam";

                    cm.Parameters.AddWithValue("@Nam", ((FilterCriteriaByNam)criteria).Nam);
                    cm.Parameters.AddWithValue("@MaBoPhan", ((FilterCriteriaByNam)criteria).MaBoPhan);
                }

                using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                {
                    while (dr.Read())
                        this.Add(SoDuSoQuy.GetSoDuSoQuy(dr));
                }
            }//using
        }
        #endregion //Data Access - Fetch


        #region Data Access - Update
        protected override void DataPortal_Update()
        {
            RaiseListChangedEvents = false;

            SqlTransaction tr;

            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();

                tr = cn.BeginTransaction();
                try
                {
                    // loop through each deleted child object
                    foreach (SoDuSoQuy deletedChild in DeletedList)
                        deletedChild.DeleteSelf(tr);
                    DeletedList.Clear();

                    // loop through each non-deleted child object
                    foreach (SoDuSoQuy child in this)
                    {
                        if (child.IsNew)
                            child.Insert(tr);
                        else
                            child.Update(tr);
                    }

                    tr.Commit();
                }
                catch
                {
                    tr.Rollback();
                    throw;
                }
            }//using SqlConnection

            RaiseListChangedEvents = true;
        }
        #endregion //Data Access - Update
        #endregion //Data Access
    }
}
