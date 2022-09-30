
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{
    [Serializable()]
    public class NghiViecKhongPhepList : Csla.BusinessListBase<NghiViecKhongPhepList, NghiViecKhongPhepChild>
    {
        #region BindingList Overrides
        private int _IDDefault = -1;
        protected override object AddNewCore()
        {
            NghiViecKhongPhepChild item = NghiViecKhongPhepChild.NewNghiViecKhongPhepChildAsChild();
            item._maNghiViec = _IDDefault;
            _IDDefault--;
            this.Add(item);
            return item;
        }
        #endregion //BindingList Overrides

        #region Authorization Rules

        public static bool CanGetObject()
        {
            //TODO: Define CanGetObject permission in NghiViecKhongPhepList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("NghiViecKhongPhepListViewGroup"))
            //	return true;
            //return false;
        }

        public static bool CanAddObject()
        {
            //TODO: Define CanAddObject permission in NghiViecKhongPhepList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("NghiViecKhongPhepListAddGroup"))
            //	return true;
            //return false;
        }

        public static bool CanEditObject()
        {
            //TODO: Define CanEditObject permission in NghiViecKhongPhepList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("NghiViecKhongPhepListEditGroup"))
            //	return true;
            //return false;
        }

        public static bool CanDeleteObject()
        {
            //TODO: Define CanDeleteObject permission in NghiViecKhongPhepList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("NghiViecKhongPhepListDeleteGroup"))
            //	return true;
            //return false;
        }
        #endregion //Authorization Rules

        #region Factory Methods
        private NghiViecKhongPhepList()
        { /* require use of factory method */ }

        public static NghiViecKhongPhepList NewNghiViecKhongPhepList()
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a NghiViecKhongPhepList");
            return new NghiViecKhongPhepList();
        }

        public static NghiViecKhongPhepList GetNghiViecKhongPhepList(long MaNhanVien, int Thang, int Nam)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a NghiViecKhongPhepList");
            return DataPortal.Fetch<NghiViecKhongPhepList>(new FilterCriteria(MaNhanVien, Thang, Nam));
        }
        #endregion //Factory Methods

        #region Data Access

        #region Filter Criteria
        [Serializable()]
        private class FilterCriteria
        {
            public long _MaNhanVien;
            public int _Thang, _Nam;
            public FilterCriteria(long MaNhanVien, int Thang, int Nam)
            {
                _MaNhanVien = MaNhanVien;
                _Thang = Thang;
                _Nam = Nam;
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
                cm.CommandText = "spd_Select_NghiViecKhongPhepList";
                cm.Parameters.AddWithValue("@MaNhanVien", criteria._MaNhanVien);
                cm.Parameters.AddWithValue("@Thang", criteria._Thang);
                cm.Parameters.AddWithValue("@Nam", criteria._Nam);

                using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                {
                    while (dr.Read())
                        this.Add(NghiViecKhongPhepChild.GetNghiViecKhongPhepChild(dr));
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
                    foreach (NghiViecKhongPhepChild deletedChild in DeletedList)
                        deletedChild.DeleteSelf(tr);
                    DeletedList.Clear();

                    // loop through each non-deleted child object
                    foreach (NghiViecKhongPhepChild child in this)
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
