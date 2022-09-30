using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{
    [Serializable()]
    public class InBienLaiNhanVienTuQuyetToanRootList : Csla.BusinessListBase<InBienLaiNhanVienTuQuyetToanRootList, InBienLaiNhanVienTuQuyetToan>
    {
        #region BindingList Overrides
        protected override object AddNewCore()
        {
            InBienLaiNhanVienTuQuyetToan item = InBienLaiNhanVienTuQuyetToan.NewInBienLaiNhanVienTuQuyetToan();
            this.Add(item);
            return item;
        }
        #endregion //BindingList Overrides

        #region Authorization Rules

        public static bool CanGetObject()
        {
            //TODO: Define CanGetObject permission in InBienLaiNhanVienTuQuyetToanRootList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("InBienLaiNhanVienTuQuyetToanRootListViewGroup"))
            //	return true;
            //return false;
        }

        public static bool CanAddObject()
        {
            //TODO: Define CanAddObject permission in InBienLaiNhanVienTuQuyetToanRootList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("InBienLaiNhanVienTuQuyetToanRootListAddGroup"))
            //	return true;
            //return false;
        }

        public static bool CanEditObject()
        {
            //TODO: Define CanEditObject permission in InBienLaiNhanVienTuQuyetToanRootList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("InBienLaiNhanVienTuQuyetToanRootListEditGroup"))
            //	return true;
            //return false;
        }

        public static bool CanDeleteObject()
        {
            //TODO: Define CanDeleteObject permission in InBienLaiNhanVienTuQuyetToanRootList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("InBienLaiNhanVienTuQuyetToanRootListDeleteGroup"))
            //	return true;
            //return false;
        }
        #endregion //Authorization Rules

        #region Factory Methods
        private InBienLaiNhanVienTuQuyetToanRootList()
        { /* require use of factory method */ }

        public static InBienLaiNhanVienTuQuyetToanRootList NewInBienLaiNhanVienTuQuyetToanRootList()
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a InBienLaiNhanVienTuQuyetToanRootList");
            return new InBienLaiNhanVienTuQuyetToanRootList();
        }

        public static InBienLaiNhanVienTuQuyetToanRootList GetInBienLaiNhanVienTuQuyetToanRootList(int maKyQuyetToan)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a InBienLaiNhanVienTuQuyetToanRootList");
            return DataPortal.Fetch<InBienLaiNhanVienTuQuyetToanRootList>(new FilterCriteria(maKyQuyetToan));
        }
        #endregion //Factory Methods

        #region Data Access

        #region Filter Criteria
        [Serializable()]
        private class FilterCriteria
        {
            public int MaKyQuyetToan = 0;
            public FilterCriteria(int makyqt)
            {
                MaKyQuyetToan = makyqt;
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
                cm.CommandText = "spd_SelecttblInBienLaiNhanVienTuQuyetToansAll";
                cm.Parameters.AddWithValue("@MaKyQuyetToan", criteria.MaKyQuyetToan);
                cm.Parameters.AddWithValue("@UserID", ERP_Library.Security.CurrentUser.Info.UserID);
                using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                {
                    while (dr.Read())
                        this.Add(InBienLaiNhanVienTuQuyetToan.GetInBienLaiNhanVienTuQuyetToan(dr));
                }
            }//using
        }
        #endregion //Data Access - Fetch


        #region Data Access - Update
        protected override void DataPortal_Update()
        {
            RaiseListChangedEvents = false;

            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();

                // loop through each deleted child object
                foreach (InBienLaiNhanVienTuQuyetToan deletedChild in DeletedList)
                    deletedChild.DeleteSelf(cn);
                DeletedList.Clear();

                // loop through each non-deleted child object
                foreach (InBienLaiNhanVienTuQuyetToan child in this)
                {
                    if (child.IsNew)
                        child.Insert(cn);
                    else
                        child.Update(cn);
                }
            }//using SqlConnection

            RaiseListChangedEvents = true;
        }
        #endregion //Data Access - Update
        #endregion //Data Access
    }
}
