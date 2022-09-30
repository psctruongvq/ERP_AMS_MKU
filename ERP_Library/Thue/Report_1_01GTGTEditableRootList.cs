
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{
    [Serializable()]
    public class ReportThue01_2GTGTList : Csla.BusinessListBase<ReportThue01_2GTGTList, ReportThue01_2GTGT>
    {

        #region Authorization Rules

        public static bool CanGetObject()
        {
            //TODO: Define CanGetObject permission in ReportThue01_2GTGTList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("ReportThue01_2GTGTListViewGroup"))
            //	return true;
            //return false;
        }

        public static bool CanAddObject()
        {
            //TODO: Define CanAddObject permission in ReportThue01_2GTGTList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("ReportThue01_2GTGTListAddGroup"))
            //	return true;
            //return false;
        }

        public static bool CanEditObject()
        {
            //TODO: Define CanEditObject permission in ReportThue01_2GTGTList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("ReportThue01_2GTGTListEditGroup"))
            //	return true;
            //return false;
        }

        public static bool CanDeleteObject()
        {
            //TODO: Define CanDeleteObject permission in ReportThue01_2GTGTList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("ReportThue01_2GTGTListDeleteGroup"))
            //	return true;
            //return false;
        }
        #endregion //Authorization Rules

        #region Factory Methods
        private ReportThue01_2GTGTList()
        { /* require use of factory method */ }

        public static ReportThue01_2GTGTList NewReportThue01_2GTGTList()
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a ReportThue01_2GTGTList");
            return new ReportThue01_2GTGTList();
        }

        public static ReportThue01_2GTGTList GetReportThue01_2GTGTList(int maky)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a ReportThue01_2GTGTList");
            return DataPortal.Fetch<ReportThue01_2GTGTList>(new FilterCriteria(maky));
        }

        public static ReportThue01_2GTGTList GetReportThue01_1GTGTList(int maky)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a ReportThue01_2GTGTList");
            return DataPortal.Fetch<ReportThue01_2GTGTList>(new FilterCriteria_By1(maky));
        }

        public static ReportThue01_2GTGTList GetList_ChonBaoCao_HoaDonMuaVao(int maky)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a ReportThue01_2GTGTList");
            return DataPortal.Fetch<ReportThue01_2GTGTList>(new FilterCriteria_ChonBaoCao_HoaDonMuaVao(maky));
        }

        public static void Delete_Insert_tblDSHoaDonDichVu(int maky,int loai,ReportThue01_2GTGTList list)
        {
            //loai = 1:hoa don mua vao; 2:hoa don dich vu
            SqlTransaction tr;

            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();

                tr = cn.BeginTransaction();
                try
                {
                    using (SqlCommand cm = tr.Connection.CreateCommand())
                    {
                        cm.Transaction = tr;
                        cm.CommandType = CommandType.StoredProcedure;
                        cm.CommandText = "spDelete_tblDSHoaDonDichVu";
                        cm.Parameters.AddWithValue("@MaKy", maky);
                        cm.Parameters.AddWithValue("@loai", loai);
                        cm.ExecuteNonQuery();

                        foreach(ReportThue01_2GTGT obj in list)
                        {
                            if (obj.check == true)
                            {
                                obj.Insert(tr);
                            }
                        }
                    }//using

                    tr.Commit();
                }
                catch
                {
                    tr.Rollback();
                    throw;
                }
            }//using
        }

        #endregion //Factory Methods

        #region Data Access

        #region Filter Criteria
        [Serializable()]
        private class FilterCriteria
        {
            public int maky;
            public FilterCriteria(int maky)
            {
                this.maky=maky;
            }
        }
        private class FilterCriteria_By1
        {
            public int maky;
            public FilterCriteria_By1(int maky)
            {
                this.maky = maky;
            }
        }
        private class FilterCriteria_ChonBaoCao_HoaDonMuaVao
        {
            public int maky;
            public FilterCriteria_ChonBaoCao_HoaDonMuaVao(int maky)
            {
                this.maky = maky;
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
                {
                    cm.CommandText = "spd_reportThue01_2GTGT";
                    cm.Parameters.AddWithValue("@maky", ((FilterCriteria)criteria).maky);
                }
                else if (criteria is FilterCriteria_By1)
                {
                    cm.CommandText = "spd_reportThue01_1GTGT";
                    cm.Parameters.AddWithValue("@maky", ((FilterCriteria_By1)criteria).maky);

                }
                else if (criteria is FilterCriteria_ChonBaoCao_HoaDonMuaVao)
                {
                    cm.CommandText = "spChonHoaDonBaoCao_ThueGTGTMuaVao";
                    cm.Parameters.AddWithValue("@maky", ((FilterCriteria_ChonBaoCao_HoaDonMuaVao)criteria).maky);
                    cm.Parameters.AddWithValue("@userID", Security.CurrentUser.Info.UserID);

                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(ReportThue01_2GTGT.GetObject_ChonBaoCao_HoaDonMuaVao(dr));
                    }
                    return;
                }
                using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                {
                    while (dr.Read())
                        this.Add(ReportThue01_2GTGT.GetReportThue01_2GTGT(dr));
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
                    foreach (ReportThue01_2GTGT deletedChild in DeletedList)
                        deletedChild.DeleteSelf(tr);
                    DeletedList.Clear();

                    // loop through each non-deleted child object
                    foreach (ReportThue01_2GTGT child in this)
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
