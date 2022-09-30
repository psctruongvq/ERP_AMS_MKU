using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{
    [Serializable()]
    public class TuyChinhSetSoChungTuList : Csla.BusinessListBase<TuyChinhSetSoChungTuList, TuyChinhSetSoChungTu>
    {
        #region BindingList Overrides
        protected override object AddNewCore()
        {
            TuyChinhSetSoChungTu item = TuyChinhSetSoChungTu.NewTuyChinhSetSoChungTu();
            this.Add(item);
            return item;
        }
        #endregion //BindingList Overrides

        #region Authorization Rules

        public static bool CanGetObject()
        {
            //TODO: Define CanGetObject permission in TuyChinhSetSoChungTuList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("TuyChinhSetSoChungTuListViewGroup"))
            //	return true;
            //return false;
        }

        public static bool CanAddObject()
        {
            //TODO: Define CanAddObject permission in TuyChinhSetSoChungTuList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("TuyChinhSetSoChungTuListAddGroup"))
            //	return true;
            //return false;
        }

        public static bool CanEditObject()
        {
            //TODO: Define CanEditObject permission in TuyChinhSetSoChungTuList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("TuyChinhSetSoChungTuListEditGroup"))
            //	return true;
            //return false;
        }

        public static bool CanDeleteObject()
        {
            //TODO: Define CanDeleteObject permission in TuyChinhSetSoChungTuList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("TuyChinhSetSoChungTuListDeleteGroup"))
            //	return true;
            //return false;
        }
        #endregion //Authorization Rules

        #region Factory Methods
        private TuyChinhSetSoChungTuList()
        { /* require use of factory method */ }

        public static TuyChinhSetSoChungTuList NewTuyChinhSetSoChungTuList()
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a TuyChinhSetSoChungTuList");
            return new TuyChinhSetSoChungTuList();
        }

        public static TuyChinhSetSoChungTuList GetTuyChinhSetSoChungTuList(int userLap)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a TuyChinhSetSoChungTuList");
            return DataPortal.Fetch<TuyChinhSetSoChungTuList>(new FilterCriteria(userLap));
        }
        #endregion //Factory Methods

        #region Data Access

        #region Filter Criteria
        [Serializable()]
        private class FilterCriteria
        {
            public int UserLap;

            public FilterCriteria(int userLap)
            {
                this.UserLap = userLap;
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
                cm.CommandText = "spd_SelecttblTuyChinhSetSoChungTusAll";
                cm.Parameters.AddWithValue("@UserLap", criteria.UserLap);

                using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                {
                    while (dr.Read())
                        this.Add(TuyChinhSetSoChungTu.GetTuyChinhSetSoChungTu(dr));
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
                foreach (TuyChinhSetSoChungTu deletedChild in DeletedList)
                    deletedChild.DeleteSelf(cn);
                DeletedList.Clear();

                // loop through each non-deleted child object
                foreach (TuyChinhSetSoChungTu child in this)
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
