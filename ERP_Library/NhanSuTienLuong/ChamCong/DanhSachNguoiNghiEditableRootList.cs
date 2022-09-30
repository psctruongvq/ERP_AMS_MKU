
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{
    [Serializable()]
    public class DanhSachNghiLamList : Csla.BusinessListBase<DanhSachNghiLamList, DanhSachNghiLam>
    {

        #region Authorization Rules

        public static bool CanGetObject()
        {
            //TODO: Define CanGetObject permission in DanhSachNghiLamList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("DanhSachNghiLamListViewGroup"))
            //	return true;
            //return false;
        }

        public static bool CanAddObject()
        {
            //TODO: Define CanAddObject permission in DanhSachNghiLamList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("DanhSachNghiLamListAddGroup"))
            //	return true;
            //return false;
        }

        public static bool CanEditObject()
        {
            //TODO: Define CanEditObject permission in DanhSachNghiLamList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("DanhSachNghiLamListEditGroup"))
            //	return true;
            //return false;
        }

        public static bool CanDeleteObject()
        {
            //TODO: Define CanDeleteObject permission in DanhSachNghiLamList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("DanhSachNghiLamListDeleteGroup"))
            //	return true;
            //return false;
        }
        #endregion //Authorization Rules

        #region Factory Methods
        private DanhSachNghiLamList()
        { /* require use of factory method */ }

        public static DanhSachNghiLamList NewDanhSachNghiLamList()
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a DanhSachNghiLamList");
            return new DanhSachNghiLamList();
        }

        public static DanhSachNghiLamList GetDanhSachNghiLamList(int maBoPhan, int thang, int nam)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a DanhSachNghiLamList");
            return DataPortal.Fetch<DanhSachNghiLamList>(new FilterCriteria(maBoPhan, thang, nam));
        }
        #endregion //Factory Methods

        #region Data Access

        #region Filter Criteria
        [Serializable()]
        private class FilterCriteria
        {
            public int MaBoPhan = 0;
            public int Thang = 0;
            public int Nam = 0;
            public FilterCriteria(int maBoPhan, int thang, int nam)
            {
                this.MaBoPhan = maBoPhan;
                this.Thang = thang;
                this.Nam = nam;
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
                cm.CommandText = "spd_DanhSachNghiTrongThang";
                cm.Parameters.AddWithValue("@MaBoPhan", criteria.MaBoPhan);
                cm.Parameters.AddWithValue("@Thang", criteria.Thang);
                cm.Parameters.AddWithValue("@Nam", criteria.Nam);


                using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                {
                    while (dr.Read())
                        this.Add(DanhSachNghiLam.GetDanhSachNghiLam(dr));
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
                    foreach (DanhSachNghiLam deletedChild in DeletedList)
                        deletedChild.DeleteSelf(tr);
                    DeletedList.Clear();

                    // loop through each non-deleted child object
                    foreach (DanhSachNghiLam child in this)
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
