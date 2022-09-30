using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{
    [Serializable()]
    public class CTNhapXuatImportFromExcelList : Csla.BusinessListBase<CTNhapXuatImportFromExcelList, CTNhapXuatImportFromExcel>
    {
        #region BindingList Overrides
        protected override object AddNewCore()
        {
            CTNhapXuatImportFromExcel item = CTNhapXuatImportFromExcel.NewCTNhapXuatImportFromExcel();
            this.Add(item);
            return item;
        }
        #endregion //BindingList Overrides

        #region Authorization Rules

        public static bool CanGetObject()
        {
            //TODO: Define CanGetObject permission in CTNhapXuatImportFromExcelList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("CTNhapXuatImportFromExcelListViewGroup"))
            //	return true;
            //return false;
        }

        public static bool CanAddObject()
        {
            //TODO: Define CanAddObject permission in CTNhapXuatImportFromExcelList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("CTNhapXuatImportFromExcelListAddGroup"))
            //	return true;
            //return false;
        }

        public static bool CanEditObject()
        {
            //TODO: Define CanEditObject permission in CTNhapXuatImportFromExcelList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("CTNhapXuatImportFromExcelListEditGroup"))
            //	return true;
            //return false;
        }

        public static bool CanDeleteObject()
        {
            //TODO: Define CanDeleteObject permission in CTNhapXuatImportFromExcelList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("CTNhapXuatImportFromExcelListDeleteGroup"))
            //	return true;
            //return false;
        }
        #endregion //Authorization Rules

        #region Factory Methods
        private CTNhapXuatImportFromExcelList()
        { /* require use of factory method */ }

        public static CTNhapXuatImportFromExcelList NewCTNhapXuatImportFromExcelList()
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a CTNhapXuatImportFromExcelList");
            return new CTNhapXuatImportFromExcelList();
        }

        public static CTNhapXuatImportFromExcelList GetCTNhapXuatImportFromExcelList(DateTime tungay, DateTime denngay)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a CTNhapXuatImportFromExcelList");
            return DataPortal.Fetch<CTNhapXuatImportFromExcelList>(new FilterCriteria(tungay,denngay));
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
            SqlTransaction tr;
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                tr = cn.BeginTransaction();
                ExecuteFetch(tr, criteria);
            }//using

            RaiseListChangedEvents = true;
        }

        private void ExecuteFetch(SqlTransaction tr, FilterCriteria criteria)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_SelecttblCTNhapXuatImportFromExcelsAll";
                cm.Parameters.AddWithValue("@MaCongTy", ERP_Library.Security.CurrentUser.Info.MaCongTy);
                cm.Parameters.AddWithValue("@UserID", ERP_Library.Security.CurrentUser.Info.UserID);
                cm.Parameters.AddWithValue("@TuNgay", criteria.TuNgay);
                cm.Parameters.AddWithValue("@DenNgay", criteria.DenNgay);

                using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                {
                    while (dr.Read())
                        this.Add(CTNhapXuatImportFromExcel.GetCTNhapXuatImportFromExcel(dr));
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
                    foreach (CTNhapXuatImportFromExcel deletedChild in DeletedList)
                        deletedChild.DeleteSelf(tr);
                    DeletedList.Clear();

                    // loop through each non-deleted child object
                    foreach (CTNhapXuatImportFromExcel child in this)
                    {
                        if (child.IsNew)
                            child.Insert(tr);
                        else
                            child.Update(tr);
                    }
                    PublicClass.ImportChiTietNhapXuatFormExcel(tr);
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
