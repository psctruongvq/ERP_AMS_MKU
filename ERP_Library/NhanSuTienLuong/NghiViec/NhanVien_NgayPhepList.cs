
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{
    [Serializable()]
    public class NhanVien_NgayPhepList : Csla.BusinessListBase<NhanVien_NgayPhepList, NhanVien_NgayPhep>
    {
        #region BindingList Overrides
        protected override object AddNewCore()
        {
            NhanVien_NgayPhep item = NhanVien_NgayPhep.NewNhanVien_NgayPhep();
            this.Add(item);
            return item;
        }
        #endregion //BindingList Overrides

        #region Authorization Rules

        public static bool CanGetObject()
        {
            //TODO: Define CanGetObject permission in NhanVien_NgayPhepList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("NhanVien_NgayPhepListViewGroup"))
            //	return true;
            //return false;
        }

        public static bool CanAddObject()
        {
            //TODO: Define CanAddObject permission in NhanVien_NgayPhepList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("NhanVien_NgayPhepListAddGroup"))
            //	return true;
            //return false;
        }

        public static bool CanEditObject()
        {
            //TODO: Define CanEditObject permission in NhanVien_NgayPhepList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("NhanVien_NgayPhepListEditGroup"))
            //	return true;
            //return false;
        }

        public static bool CanDeleteObject()
        {
            //TODO: Define CanDeleteObject permission in NhanVien_NgayPhepList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("NhanVien_NgayPhepListDeleteGroup"))
            //	return true;
            //return false;
        }
        #endregion //Authorization Rules

        #region Factory Methods
        private NhanVien_NgayPhepList()
        { /* require use of factory method */ }

        public static NhanVien_NgayPhepList NewNhanVien_NgayPhepList()
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a NhanVien_NgayPhepList");
            return new NhanVien_NgayPhepList();
        }

        public static NhanVien_NgayPhepList GetNhanVien_NgayPhepList()
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a NhanVien_NgayPhepList");
            return DataPortal.Fetch<NhanVien_NgayPhepList>(new FilterCriteria());
        }
        #endregion //Factory Methods

        #region Data Access

        #region Filter Criteria
        [Serializable()]
        private class FilterCriteria
        {
            public long MaNhanVien;

            public FilterCriteria(long maNhanVien)
            {
                this.MaNhanVien = maNhanVien;
            }
            public FilterCriteria() { }
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
                cm.CommandText = "sp_GetNhanVien_NgayPhepList";

                using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                {
                    while (dr.Read())
                        this.Add(NhanVien_NgayPhep.GetNhanVien_NgayPhep(dr));
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
                    foreach (NhanVien_NgayPhep deletedChild in DeletedList)
                        deletedChild.DeleteSelf(tr);
                    DeletedList.Clear();

                    // loop through each non-deleted child object
                    foreach (NhanVien_NgayPhep child in this)
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
