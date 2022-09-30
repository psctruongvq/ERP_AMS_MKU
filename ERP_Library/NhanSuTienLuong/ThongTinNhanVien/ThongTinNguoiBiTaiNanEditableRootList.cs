
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{
    [Serializable()]
    public class ThongTinNguoiBiTaiNanList : Csla.BusinessListBase<ThongTinNguoiBiTaiNanList, ThongTinNguoiBiTaiNan>
    {
        #region BindingList Overrides
        protected override object AddNewCore()
        {
            ThongTinNguoiBiTaiNan item = ThongTinNguoiBiTaiNan.NewThongTinNguoiBiTaiNanChild();
            this.Add(item);
            return item;
        }
        #endregion //BindingList Overrides

        #region Authorization Rules

        public static bool CanGetObject()
        {
            //TODO: Define CanGetObject permission in ThongTinNguoiBiTaiNanList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("ThongTinNguoiBiTaiNanListViewGroup"))
            //	return true;
            //return false;
        }

        public static bool CanAddObject()
        {
            //TODO: Define CanAddObject permission in ThongTinNguoiBiTaiNanList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("ThongTinNguoiBiTaiNanListAddGroup"))
            //	return true;
            //return false;
        }

        public static bool CanEditObject()
        {
            //TODO: Define CanEditObject permission in ThongTinNguoiBiTaiNanList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("ThongTinNguoiBiTaiNanListEditGroup"))
            //	return true;
            //return false;
        }

        public static bool CanDeleteObject()
        {
            //TODO: Define CanDeleteObject permission in ThongTinNguoiBiTaiNanList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("ThongTinNguoiBiTaiNanListDeleteGroup"))
            //	return true;
            //return false;
        }
        #endregion //Authorization Rules

        #region Factory Methods
        private ThongTinNguoiBiTaiNanList()
        { /* require use of factory method */
            MarkAsChild();
        }

        public static ThongTinNguoiBiTaiNanList NewThongTinNguoiBiTaiNanList()
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a ThongTinNguoiBiTaiNanList");
            return new ThongTinNguoiBiTaiNanList();
        }

        public static ThongTinNguoiBiTaiNanList GetThongTinNguoiBiTaiNanList(int MaTaiNan)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a ThongTinNguoiBiTaiNanList");
            return DataPortal.Fetch<ThongTinNguoiBiTaiNanList>(new FilterCriteria(MaTaiNan));
        }
        #endregion //Factory Methods

        #region Data Access

        #region Filter Criteria
        [Serializable()]
        private class FilterCriteria
        {
            public int MaTaiNan;

            public FilterCriteria(int maTaiNan)
            {
                this.MaTaiNan = maTaiNan;
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
                cm.CommandText = "[spd_SelecttblnsThongTinNguoiBiTaiNansAll]";
                cm.Parameters.AddWithValue("@MaTaiNan", criteria.MaTaiNan);

                using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                {
                    while (dr.Read())
                        this.Add(ThongTinNguoiBiTaiNan.GetThongTinNguoiBiTaiNan(dr));
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
                    foreach (ThongTinNguoiBiTaiNan deletedChild in DeletedList)
                        deletedChild.DeleteSelf(tr);
                    DeletedList.Clear();

                    // loop through each non-deleted child object
                    foreach (ThongTinNguoiBiTaiNan child in this)
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
        public void UpdateData(SqlTransaction tr, ThongTinTaiNan Parent)
        {
            RaiseListChangedEvents = false;
            try
            {
                // loop through each deleted child object
                foreach (ThongTinNguoiBiTaiNan deletedChild in DeletedList)
                    deletedChild.DeleteSelf(tr);
                DeletedList.Clear();

                // loop through each non-deleted child object
                foreach (ThongTinNguoiBiTaiNan child in this)
                {
                    if (child.IsNew)
                        child.Insert(tr,Parent);
                    else
                        child.Update(tr,Parent);
                }
            }
            catch
            {
                throw;
            }      
            RaiseListChangedEvents = true;
        }
        #endregion //Data Access - Update
        #endregion //Data Access
    }
}
