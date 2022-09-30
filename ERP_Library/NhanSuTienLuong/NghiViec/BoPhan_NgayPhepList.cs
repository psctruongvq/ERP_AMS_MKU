
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{
    [Serializable()]
    public class BoPhan_NgayPhepList : Csla.BusinessListBase<BoPhan_NgayPhepList, BoPhan_NgayPhep>
    {
        #region BindingList Overrides
        protected override object AddNewCore()
        {
            BoPhan_NgayPhep item = BoPhan_NgayPhep.NewBoPhan_NgayPhep();
            this.Add(item);
            return item;
        }
        #endregion //BindingList Overrides

        #region Authorization Rules

        public static bool CanGetObject()
        {
            //TODO: Define CanGetObject permission in BoPhan_NgayPhepList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("BoPhan_NgayPhepListViewGroup"))
            //	return true;
            //return false;
        }

        public static bool CanAddObject()
        {
            //TODO: Define CanAddObject permission in BoPhan_NgayPhepList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("BoPhan_NgayPhepListAddGroup"))
            //	return true;
            //return false;
        }

        public static bool CanEditObject()
        {
            //TODO: Define CanEditObject permission in BoPhan_NgayPhepList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("BoPhan_NgayPhepListEditGroup"))
            //	return true;
            //return false;
        }

        public static bool CanDeleteObject()
        {
            //TODO: Define CanDeleteObject permission in BoPhan_NgayPhepList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("BoPhan_NgayPhepListDeleteGroup"))
            //	return true;
            //return false;
        }
        #endregion //Authorization Rules

        #region Factory Methods
        private BoPhan_NgayPhepList()
        { /* require use of factory method */ }

        public static BoPhan_NgayPhepList NewBoPhan_NgayPhepList()
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a BoPhan_NgayPhepList");
            return new BoPhan_NgayPhepList();
        }

        public static BoPhan_NgayPhepList GetBoPhan_NgayPhepList()
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a BoPhan_NgayPhepList");
            BoPhan_NgayPhepList t=null;
            try
            {
                t = DataPortal.Fetch<BoPhan_NgayPhepList>(new FilterCriteria(0));
            }
            catch (System.Exception ex)
            {
            }
            return t;
        }
        #endregion //Factory Methods

        #region Data Access

        #region Filter Criteria
        [Serializable()]
        private class FilterCriteria
        {
            public int MaBoPhan;

            public FilterCriteria(int maBoPhan)
            {
                this.MaBoPhan = maBoPhan;
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
                cm.CommandText = "sp_GetBoPhan_NgayPhepList";
                //cm.Parameters.AddWithValue("@MaBoPhan", criteria.MaBoPhan);

                using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                {
                    while (dr.Read())
                        this.Add(BoPhan_NgayPhep.GetBoPhan_NgayPhep(dr));
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
                    foreach (BoPhan_NgayPhep deletedChild in DeletedList)
                        deletedChild.DeleteSelf(tr);
                    DeletedList.Clear();

                    // loop through each non-deleted child object
                    foreach (BoPhan_NgayPhep child in this)
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
