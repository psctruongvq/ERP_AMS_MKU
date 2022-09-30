
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{
    [Serializable()]
    public class BHXH02List : Csla.BusinessListBase<BHXH02List, BHXH02>
    {
        #region BindingList Overrides
        protected override object AddNewCore()
        {
            BHXH02 item = BHXH02.NewBHXH02();
            this.Add(item);
            return item;
        }
        #endregion //BindingList Overrides

        #region Authorization Rules

        public static bool CanGetObject()
        {
            //TODO: Define CanGetObject permission in BiaHoSoList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("BiaHoSoListViewGroup"))
            //	return true;
            //return false;
        }

        public static bool CanAddObject()
        {
            //TODO: Define CanAddObject permission in BiaHoSoList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("BiaHoSoListAddGroup"))
            //	return true;
            //return false;
        }

        public static bool CanEditObject()
        {
            //TODO: Define CanEditObject permission in BiaHoSoList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("BiaHoSoListEditGroup"))
            //	return true;
            //return false;
        }

        public static bool CanDeleteObject()
        {
            //TODO: Define CanDeleteObject permission in BiaHoSoList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("BiaHoSoListDeleteGroup"))
            //	return true;
            //return false;
        }
        #endregion //Authorization Rules

        #region Factory Methods
        private BHXH02List()
        { /* require use of factory method */ }

        public static BHXH02List NewBHXH02List()
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a BiaHoSoList");
            return new BHXH02List();
        }

        public static BHXH02List GetBHXH02ListByThangNam(int thang, int nam)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a BiaHoSoList");
            return DataPortal.Fetch<BHXH02List>(new FilterCriteria(thang,nam));
        }
        #endregion //Factory Methods

        #region Data Access

        #region Filter Criteria
        [Serializable()]
        private class FilterCriteria
        {
            public int thang;
            public int nam;
            public FilterCriteria(int thang, int nam )
            {
                this.thang = thang;
                this.nam = nam;
            }
        }
        #endregion //Filter Criteria

        #region Data Access - Fetch
        private void DataPortal_Fetch(object criteria)
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
                catch (Exception ex)
                {
                    tr.Rollback();
                    HamDungChung.ThongBaoLoi(ex);
                }
            }//using

            RaiseListChangedEvents = true;
        }

        private void ExecuteFetch(SqlTransaction tr, object criteria)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                if (criteria is FilterCriteria)
                cm.CommandText = "spd_SelecttblnsBHCH02ByThang";
                cm.Parameters.AddWithValue("@Thang", ((FilterCriteria)criteria).thang);
                cm.Parameters.AddWithValue("@nam", ((FilterCriteria)criteria).nam);
                

                using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                {
                    while (dr.Read())
                        this.Add(BHXH02.GetBHXH02(dr));
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
                    foreach (BHXH02 deletedChild in DeletedList)
                        deletedChild.DeleteSelf(tr);
                    DeletedList.Clear();

                    // loop through each non-deleted child object
                    foreach (BHXH02 child in this)
                    {
                        if (child.IsNew)
                            child.Insert(tr);
                        else
                            child.Update(tr);
                    }

                    tr.Commit();
                }
                catch (SqlException ex)
                {
                    tr.Rollback();
                    HamDungChung.ThongBaoLoi(ex);
                }
            }//using SqlConnection

            RaiseListChangedEvents = true;
        }
        #endregion //Data Access - Update
        #endregion //Data Access
    }
}
