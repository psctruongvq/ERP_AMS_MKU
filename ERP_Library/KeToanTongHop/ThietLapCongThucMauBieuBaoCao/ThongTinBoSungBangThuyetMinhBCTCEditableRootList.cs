using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{
    [Serializable()]
    public class ThongTinBoSungBangThuyetMinhBCTCEditableRootList : Csla.BusinessListBase<ThongTinBoSungBangThuyetMinhBCTCEditableRootList, ThongTinBoSungBangThuyetMinhBCTCEditableSwitchable>
    {
        #region BindingList Overrides
        protected override object AddNewCore()
        {
            ThongTinBoSungBangThuyetMinhBCTCEditableSwitchable item = ThongTinBoSungBangThuyetMinhBCTCEditableSwitchable.NewThongTinBoSungBangThuyetMinhBCTCEditableSwitchable();
            this.Add(item);
            return item;
        }
        #endregion //BindingList Overrides

        #region Authorization Rules

        public static bool CanGetObject()
        {
            //TODO: Define CanGetObject permission in ThongTinBoSungBangThuyetMinhBCTCEditableRootList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("ThongTinBoSungBangThuyetMinhBCTCEditableRootListViewGroup"))
            //	return true;
            //return false;
        }

        public static bool CanAddObject()
        {
            //TODO: Define CanAddObject permission in ThongTinBoSungBangThuyetMinhBCTCEditableRootList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("ThongTinBoSungBangThuyetMinhBCTCEditableRootListAddGroup"))
            //	return true;
            //return false;
        }

        public static bool CanEditObject()
        {
            //TODO: Define CanEditObject permission in ThongTinBoSungBangThuyetMinhBCTCEditableRootList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("ThongTinBoSungBangThuyetMinhBCTCEditableRootListEditGroup"))
            //	return true;
            //return false;
        }

        public static bool CanDeleteObject()
        {
            //TODO: Define CanDeleteObject permission in ThongTinBoSungBangThuyetMinhBCTCEditableRootList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("ThongTinBoSungBangThuyetMinhBCTCEditableRootListDeleteGroup"))
            //	return true;
            //return false;
        }
        #endregion //Authorization Rules

        #region Factory Methods
        private ThongTinBoSungBangThuyetMinhBCTCEditableRootList()
        { /* require use of factory method */ }

        public static ThongTinBoSungBangThuyetMinhBCTCEditableRootList NewThongTinBoSungBangThuyetMinhBCTCEditableRootList()
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a ThongTinBoSungBangThuyetMinhBCTCEditableRootList");
            return new ThongTinBoSungBangThuyetMinhBCTCEditableRootList();
        }

        public static ThongTinBoSungBangThuyetMinhBCTCEditableRootList GetThongTinBoSungBangThuyetMinhBCTCEditableRootList(int mamuc, DateTime tungay, DateTime denngay)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a ThongTinBoSungBangThuyetMinhBCTCEditableRootList");
            return DataPortal.Fetch<ThongTinBoSungBangThuyetMinhBCTCEditableRootList>(new FilterCriteria( mamuc,  tungay,  denngay));
        }
        #endregion //Factory Methods

        #region Data Access

        #region Filter Criteria
        [Serializable()]
        private class FilterCriteria
        {
            public int MaMuc;
            public DateTime TuNgay;
            public DateTime DenNgay;

            public FilterCriteria(int mamuc, DateTime tungay, DateTime denngay)
            {
                MaMuc = mamuc;
                TuNgay = tungay;
                DenNgay = denngay;
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
                cm.CommandText = "spd_GetThongTinBoSungBangThuyetMinhBCTCForCustomize";
                cm.Parameters.AddWithValue("@MaMuc",criteria.MaMuc);
                cm.Parameters.AddWithValue("@TuNgay", criteria.TuNgay);
                cm.Parameters.AddWithValue("@DenNgay", criteria.DenNgay);

                using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                {
                    while (dr.Read())
                        this.Add(ThongTinBoSungBangThuyetMinhBCTCEditableSwitchable.GetThongTinBoSungBangThuyetMinhBCTCEditableSwitchable(dr));
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
                    foreach (ThongTinBoSungBangThuyetMinhBCTCEditableSwitchable deletedChild in DeletedList)
                        deletedChild.DeleteSelf(tr);
                    DeletedList.Clear();

                    // loop through each non-deleted child object
                    foreach (ThongTinBoSungBangThuyetMinhBCTCEditableSwitchable child in this)
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
