
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{
    [Serializable()]
    public class ChungTu_ChuongTrinhList : Csla.BusinessListBase<ChungTu_ChuongTrinhList, ChungTu_ChuongTrinh>
    {
        #region BindingList Overrides
        protected override object AddNewCore()
        {
            ChungTu_ChuongTrinh item = ChungTu_ChuongTrinh.NewChungTu_ChuongTrinh();
            this.Add(item);
            return item;
        }
        #endregion //BindingList Overrides

        #region Authorization Rules

        public static bool CanGetObject()
        {
            //TODO: Define CanGetObject permission in ChungTu_ChuongTrinhList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("ChungTu_ChuongTrinhListViewGroup"))
            //	return true;
            //return false;
        }

        public static bool CanAddObject()
        {
            //TODO: Define CanAddObject permission in ChungTu_ChuongTrinhList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("ChungTu_ChuongTrinhListAddGroup"))
            //	return true;
            //return false;
        }

        public static bool CanEditObject()
        {
            //TODO: Define CanEditObject permission in ChungTu_ChuongTrinhList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("ChungTu_ChuongTrinhListEditGroup"))
            //	return true;
            //return false;
        }

        public static bool CanDeleteObject()
        {
            //TODO: Define CanDeleteObject permission in ChungTu_ChuongTrinhList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("ChungTu_ChuongTrinhListDeleteGroup"))
            //	return true;
            //return false;
        }
        #endregion //Authorization Rules

        #region Factory Methods
        private ChungTu_ChuongTrinhList()
        { /* require use of factory method */ }

        public static ChungTu_ChuongTrinhList NewChungTu_ChuongTrinhList()
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a ChungTu_ChuongTrinhList");
            return new ChungTu_ChuongTrinhList();
        }

        public static ChungTu_ChuongTrinhList GetChungTu_ChuongTrinhList(long MaChungTu)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a ChungTu_ChuongTrinhList");
            return DataPortal.Fetch<ChungTu_ChuongTrinhList>(new FilterCriteria(MaChungTu));
        }
        #endregion //Factory Methods

        #region Data Access

        #region Filter Criteria
        [Serializable()]
        private class FilterCriteria
        {
            public long MaChungTu;
            public FilterCriteria(long machungtu)
            {
                MaChungTu = machungtu;
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
                cm.CommandText = "spd_SelecttblChungTu_ChuongTrinhesAll";
                cm.Parameters.AddWithValue("@MaChungTu", criteria.MaChungTu);

                using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                {
                    while (dr.Read())
                        this.Add(ChungTu_ChuongTrinh.GetChungTu_ChuongTrinh(dr));
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
                    foreach (ChungTu_ChuongTrinh deletedChild in DeletedList)
                        deletedChild.DeleteSelf(tr);
                    DeletedList.Clear();

                    // loop through each non-deleted child object
                    foreach (ChungTu_ChuongTrinh child in this)
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
        public void DataPortal_Update(  SqlTransaction tr,long MaChungTu)
        {
            RaiseListChangedEvents = false;

            

            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();

                try
                {
                    // loop through each deleted child object
                    foreach (ChungTu_ChuongTrinh deletedChild in DeletedList)
                        deletedChild.DeleteSelf(tr);
                    DeletedList.Clear();

                    // loop through each non-deleted child object
                    foreach (ChungTu_ChuongTrinh child in this)
                    {
                        child.MaChungTu = MaChungTu;
                        if (child.IsNew)
                            child.Insert(tr);
                        else
                            child.Update(tr);
                    }

                  
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
