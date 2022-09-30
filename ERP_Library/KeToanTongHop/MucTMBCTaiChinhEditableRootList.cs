
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{
    [Serializable()]
    public class MucTMBCTaiChinhList : Csla.BusinessListBase<MucTMBCTaiChinhList, MucTMBCTaiChinh>
    {

        #region Authorization Rules

        public static bool CanGetObject()
        {
            //TODO: Define CanGetObject permission in MucTMBCTaiChinhList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("MucTMBCTaiChinhListViewGroup"))
            //	return true;
            //return false;
        }

        public static bool CanAddObject()
        {
            //TODO: Define CanAddObject permission in MucTMBCTaiChinhList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("MucTMBCTaiChinhListAddGroup"))
            //	return true;
            //return false;
        }

        public static bool CanEditObject()
        {
            //TODO: Define CanEditObject permission in MucTMBCTaiChinhList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("MucTMBCTaiChinhListEditGroup"))
            //	return true;
            //return false;
        }

        public static bool CanDeleteObject()
        {
            //TODO: Define CanDeleteObject permission in MucTMBCTaiChinhList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("MucTMBCTaiChinhListDeleteGroup"))
            //	return true;
            //return false;
        }
        #endregion //Authorization Rules

        #region Factory Methods
        private MucTMBCTaiChinhList()
        { /* require use of factory method */ }

        public static MucTMBCTaiChinhList NewMucTMBCTaiChinhList()
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a MucTMBCTaiChinhList");
            return new MucTMBCTaiChinhList();
        }

        public static MucTMBCTaiChinhList GetMucTMBCTaiChinhList()
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a MucTMBCTaiChinhList");
            return DataPortal.Fetch<MucTMBCTaiChinhList>(new FilterCriteria());
        }

        public static MucTMBCTaiChinhList GetMucTMBCTaiChinhListbyMaThongTu(int maThongTu,byte isNHNN)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a MucTMBCTaiChinhList");
            return DataPortal.Fetch<MucTMBCTaiChinhList>(new FilterCriteriabyThongTu(maThongTu,isNHNN));
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
        private class FilterCriteriabyThongTu
        {
            public int MaThongTu = 0;
            public byte IsNHNN = 0;
            public FilterCriteriabyThongTu(int maThongTu, byte isNHNN)
            {
                MaThongTu = maThongTu;
                IsNHNN = isNHNN;
            }
        }
        #endregion //Filter Criteria

        #region Data Access - Fetch
        private void DataPortal_Fetch(object criteria)
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
                    cm.CommandText = "spd_SelecttblMucTMBCTaiChinhesAll";
                else
                {
                    cm.CommandText = "spd_SelecttblMucTMBCTaiChinhesbyThongTu";
                    cm.Parameters.AddWithValue("@MaThongTu",((FilterCriteriabyThongTu)criteria).MaThongTu);
                    cm.Parameters.AddWithValue("@isNHNN", ((FilterCriteriabyThongTu)criteria).IsNHNN);
                }


                using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                {
                    while (dr.Read())
                        this.Add(MucTMBCTaiChinh.GetMucTMBCTaiChinh(dr));
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
                    foreach (MucTMBCTaiChinh deletedChild in DeletedList)
                        deletedChild.DeleteSelf(tr);
                    DeletedList.Clear();

                    // loop through each non-deleted child object
                    foreach (MucTMBCTaiChinh child in this)
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
