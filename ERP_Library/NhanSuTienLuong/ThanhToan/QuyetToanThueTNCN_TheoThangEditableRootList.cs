
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{
    [Serializable()]
    public class QuyetToanThueTNCN_TheoThangList : Csla.BusinessListBase<QuyetToanThueTNCN_TheoThangList, QuyetToanThueTNCN_TheoThang>
    {

        #region Authorization Rules

        public static bool CanGetObject()
        {
            //TODO: Define CanGetObject permission in QuyetToanThueTNCN_TheoThangList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("QuyetToanThueTNCN_TheoThangListViewGroup"))
            //	return true;
            //return false;
        }
        #endregion //Authorization Rules

        #region Factory Methods
        private QuyetToanThueTNCN_TheoThangList()
        { /* require use of factory method */ }

        public static QuyetToanThueTNCN_TheoThangList NewQuyetToanThueTNCN_TheoThangList()
        {
            QuyetToanThueTNCN_TheoThangList rs = new QuyetToanThueTNCN_TheoThangList();
            return rs;
        }

        public static QuyetToanThueTNCN_TheoThangList GetQuyetToanThueTNCN_TheoThangList(int Thang, int Nam, Boolean  CoQuanThue)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a QuyetToanThueTNCN_TheoThangList");
            return DataPortal.Fetch<QuyetToanThueTNCN_TheoThangList>(new FilterCriteria(Thang, Nam, CoQuanThue));
        }

        public static QuyetToanThueTNCN_TheoThangList GetQuyetToanThueTNCNCuoiNamList(int Thang, int Nam)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a QuyetToanThueTNCN_TheoThangList");
            return DataPortal.Fetch<QuyetToanThueTNCN_TheoThangList>(new FilterCriteriaCuoiNam(Thang, Nam));
        }
        #endregion //Factory Methods

        #region Data Access

        #region Filter Criteria
        [Serializable()]
        private class FilterCriteria
        {
            public int Thang;
            public int Nam;
            public Boolean CoQuanThue;
            public FilterCriteria(int thang, int nam, Boolean coQuanThue)
            {
                this.Thang = thang;
                this.Nam = nam;
                this.CoQuanThue = coQuanThue;
            }
        }

        private class FilterCriteriaCuoiNam
        {
            public int Thang;
            public int Nam;
            public FilterCriteriaCuoiNam(int thang, int nam)
            {
                this.Thang = thang;
                this.Nam = nam;
            }
        }

        #endregion //Filter Criteria

        #region Data Access - Fetch
        private void DataPortal_Fetch(object criteria)
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

        private void ExecuteFetch(SqlTransaction tr, object criteria)                                
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                if (criteria is FilterCriteria)
                {
                    cm.CommandText = "spd_SelecttblQuyetToanThueCuoiThang";
                    cm.Parameters.AddWithValue("@Thang", ((FilterCriteria)criteria).Thang);
                    cm.Parameters.AddWithValue("@Nam", ((FilterCriteria)criteria).Nam);
                    cm.Parameters.AddWithValue("@CoQuanThue", ((FilterCriteria)criteria).CoQuanThue);
                    cm.Parameters.AddWithValue("@UserId", ERP_Library.Security.CurrentUser.Info.UserID);
                }
                if (criteria is FilterCriteriaCuoiNam)
                {
                    cm.CommandText = "spd_SelecttblQuyetToanThueCuoiNam";
                    cm.Parameters.AddWithValue("@Thang", ((FilterCriteriaCuoiNam)criteria).Thang);
                    cm.Parameters.AddWithValue("@Nam", ((FilterCriteriaCuoiNam)criteria).Nam);
                    cm.Parameters.AddWithValue("@UserId", ERP_Library.Security.CurrentUser.Info.UserID);
                }

                using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                {
                    while (dr.Read())
                        this.Add(QuyetToanThueTNCN_TheoThang.GetQuyetToanThueTNCN_TheoThang(dr));
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
                    foreach (QuyetToanThueTNCN_TheoThang deletedChild in DeletedList)
                        deletedChild.DeleteSelf(tr);
                    DeletedList.Clear();

                    // loop through each non-deleted child object
                    foreach (QuyetToanThueTNCN_TheoThang child in this)
                    {
                        if (child.IsNew)
                            child.Insert(tr, this);
                        else
                            child.Update(tr, this);
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
