
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{
    [Serializable()]
    public class DanhMucMauHoaDonList : Csla.BusinessListBase<DanhMucMauHoaDonList, DanhMucMauHoaDon>
    {
        #region BindingList Overrides
        protected override object AddNewCore()
        {
            DanhMucMauHoaDon item = DanhMucMauHoaDon.NewDanhMucMauHoaDon();
            this.Add(item);
            return item;
        }
        #endregion //BindingList Overrides

        #region Authorization Rules

        public static bool CanGetObject()
        {
            return true;
        }

        public static bool CanAddObject()
        {
            return true;

        }

        public static bool CanEditObject()
        {
            return true;
        }

        public static bool CanDeleteObject()
        {
            return true;
        }
        #endregion //Authorization Rules

        #region Factory Methods
        private DanhMucMauHoaDonList()
        { /* require use of factory method */
          
        }

        public static DanhMucMauHoaDonList NewDanhMucMauHoaDonList()
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a DanhMucMauHoaDonList");
            return new DanhMucMauHoaDonList();
        }

        public static DanhMucMauHoaDonList GetDanhMucMauHoaDonList()
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a LuuTruCapPhatHoaDonList");
            return DataPortal.Fetch<DanhMucMauHoaDonList>(new FilterCriteria());
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

        private void ExecuteFetch(SqlTransaction tr, FilterCriteria criteria)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_SelecttblDanhMucMauHoaDonsAll";


                using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                {
                    while (dr.Read())
                        this.Add(DanhMucMauHoaDon.GetDanhMucMauHoaDon(dr));
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
                    foreach (DanhMucMauHoaDon deletedChild in DeletedList)
                        deletedChild.DeleteSelf(tr);
                    DeletedList.Clear();

                    // loop through each non-deleted child object
                    foreach (DanhMucMauHoaDon child in this)
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
