using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{
    [Serializable()]
    public class ChungTuImportFromExcelList : Csla.BusinessListBase<ChungTuImportFromExcelList, ChungTuImportFromExcel>
    {
        #region BindingList Overrides
        protected override object AddNewCore()
        {
            ChungTuImportFromExcel item = ChungTuImportFromExcel.NewChungTuImportFromExcel();
            this.Add(item);
            return item;
        }
        #endregion //BindingList Overrides

        #region Authorization Rules

        public static bool CanGetObject()
        {
            //TODO: Define CanGetObject permission in ChungTuImportFromExcelList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("ChungTuImportFromExcelListViewGroup"))
            //	return true;
            //return false;
        }

        public static bool CanAddObject()
        {
            //TODO: Define CanAddObject permission in ChungTuImportFromExcelList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("ChungTuImportFromExcelListAddGroup"))
            //	return true;
            //return false;
        }

        public static bool CanEditObject()
        {
            //TODO: Define CanEditObject permission in ChungTuImportFromExcelList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("ChungTuImportFromExcelListEditGroup"))
            //	return true;
            //return false;
        }

        public static bool CanDeleteObject()
        {
            //TODO: Define CanDeleteObject permission in ChungTuImportFromExcelList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("ChungTuImportFromExcelListDeleteGroup"))
            //	return true;
            //return false;
        }
        #endregion //Authorization Rules

        #region Factory Methods
        private ChungTuImportFromExcelList()
        { /* require use of factory method */ }

        public static ChungTuImportFromExcelList NewChungTuImportFromExcelList()
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a ChungTuImportFromExcelList");
            return new ChungTuImportFromExcelList();
        }

        public static ChungTuImportFromExcelList GetChungTuImportFromExcelList(DateTime tungay, DateTime denngay)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a ChungTuImportFromExcelList");
            return DataPortal.Fetch<ChungTuImportFromExcelList>(new FilterCriteria(tungay, denngay));
        }
        #endregion //Factory Methods

        #region Data Access

        #region Filter Criteria
        [Serializable()]
        private class FilterCriteria
        {
            public DateTime TuNgay;
            public DateTime DenNgay;

            public FilterCriteria(DateTime tungay, DateTime denNgay)
            {
                TuNgay = tungay;
                DenNgay = denNgay;
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
                cm.CommandText = "spd_SelecttblChungTuImportFromExcelsAll";
                cm.Parameters.AddWithValue("@MaCongTy", ERP_Library.Security.CurrentUser.Info.MaCongTy);
                cm.Parameters.AddWithValue("@UserID", ERP_Library.Security.CurrentUser.Info.UserID);
                cm.Parameters.AddWithValue("@TuNgay", criteria.TuNgay);
                cm.Parameters.AddWithValue("@DenNgay", criteria.DenNgay);


                using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                {
                    while (dr.Read())
                        this.Add(ChungTuImportFromExcel.GetChungTuImportFromExcel(dr));
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
                    foreach (ChungTuImportFromExcel deletedChild in DeletedList)
                        deletedChild.DeleteSelf(cn);
                    DeletedList.Clear();

                    // loop through each non-deleted child object
                    foreach (ChungTuImportFromExcel child in this)
                    {
                        if (child.IsNew)
                            child.Insert(tr);
                        else
                            child.Update(tr);
                    }
                    PublicClass.ImportChungTuFromExcel(tr);
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
