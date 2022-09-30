using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{
    [Serializable()]
    public class DinhKhoanTuDongList : Csla.BusinessListBase<DinhKhoanTuDongList, DinhKhoanTuDong>
    {
        #region BindingList Overrides
        protected override object AddNewCore()
        {
            DinhKhoanTuDong item = DinhKhoanTuDong.NewDinhKhoanTuDong();
            this.Add(item);
            return item;
        }
        #endregion //BindingList Overrides

        #region Authorization Rules

        public static bool CanGetObject()
        {
            //TODO: Define CanGetObject permission in DinhKhoanTuDongList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("DinhKhoanTuDongListViewGroup"))
            //	return true;
            //return false;
        }

        public static bool CanAddObject()
        {
            //TODO: Define CanAddObject permission in DinhKhoanTuDongList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("DinhKhoanTuDongListAddGroup"))
            //	return true;
            //return false;
        }

        public static bool CanEditObject()
        {
            //TODO: Define CanEditObject permission in DinhKhoanTuDongList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("DinhKhoanTuDongListEditGroup"))
            //	return true;
            //return false;
        }

        public static bool CanDeleteObject()
        {
            //TODO: Define CanDeleteObject permission in DinhKhoanTuDongList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("DinhKhoanTuDongListDeleteGroup"))
            //	return true;
            //return false;
        }
        #endregion //Authorization Rules

        #region Factory Methods
        private DinhKhoanTuDongList()
        { /* require use of factory method */ }

        public static DinhKhoanTuDongList NewDinhKhoanTuDongList()
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a DinhKhoanTuDongList");
            return new DinhKhoanTuDongList();
        }

        public static DinhKhoanTuDongList GetDinhKhoanTuDongList()
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a DinhKhoanTuDongList");
            return DataPortal.Fetch<DinhKhoanTuDongList>(new FilterCriteria());
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
                cm.CommandText = "spd_SelecttblDinhKhoanTuDongsAll";
                cm.Parameters.AddWithValue("@MaCongTy", ERP_Library.Security.CurrentUser.Info.MaCongTy);


                using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                {
                    while (dr.Read())
                        this.Add(DinhKhoanTuDong.GetDinhKhoanTuDong(dr));
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
                foreach (DinhKhoanTuDong deletedChild in DeletedList)
                    deletedChild.DeleteSelf(cn);
                DeletedList.Clear();

                // loop through each non-deleted child object
                foreach (DinhKhoanTuDong child in this)
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
