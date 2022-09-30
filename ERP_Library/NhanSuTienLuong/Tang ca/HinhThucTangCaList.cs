
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{
    [Serializable()]
    public class HinhThucTangCaList : Csla.BusinessListBase<HinhThucTangCaList, HinhThucTangCaChild>
    {
        private int _IDDefault = -1;
        #region BindingList Overrides
        protected override object AddNewCore()
        {
            HinhThucTangCaChild item = HinhThucTangCaChild.NewHinhThucTangCaChild();
            item._maLoaiTangCa = _IDDefault;
            _IDDefault--;
            item.AsChild();
            this.Add(item);
            return item;
        }
        #endregion //BindingList Overrides

        #region Authorization Rules

        public static bool CanGetObject()
        {
            //TODO: Define CanGetObject permission in HinhThucTangCaList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("HinhThucTangCaListViewGroup"))
            //	return true;
            //return false;
        }

        public static bool CanAddObject()
        {
            //TODO: Define CanAddObject permission in HinhThucTangCaList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("HinhThucTangCaListAddGroup"))
            //	return true;
            //return false;
        }

        public static bool CanEditObject()
        {
            //TODO: Define CanEditObject permission in HinhThucTangCaList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("HinhThucTangCaListEditGroup"))
            //	return true;
            //return false;
        }

        public static bool CanDeleteObject()
        {
            //TODO: Define CanDeleteObject permission in HinhThucTangCaList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("HinhThucTangCaListDeleteGroup"))
            //	return true;
            //return false;
        }
        #endregion //Authorization Rules

        #region Factory Methods
        private HinhThucTangCaList()
        { /* require use of factory method */ }

        public static HinhThucTangCaList NewHinhThucTangCaList()
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a HinhThucTangCaList");
            return new HinhThucTangCaList();
        }

        public static HinhThucTangCaList GetHinhThucTangCaList()
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a HinhThucTangCaList");
            return DataPortal.Fetch<HinhThucTangCaList>(new FilterCriteria());
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
                cm.CommandText = "spd_SelectAll_HinhThucTangCaList";


                using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                {
                    while (dr.Read())
                        this.Add(HinhThucTangCaChild.GetHinhThucTangCaChild(dr));
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
                    foreach (HinhThucTangCaChild deletedChild in DeletedList)
                        deletedChild.DeleteSelf(tr);
                    DeletedList.Clear();

                    // loop through each non-deleted child object
                    foreach (HinhThucTangCaChild child in this)
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
