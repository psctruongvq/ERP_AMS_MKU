
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{
    [Serializable()]
    public class XeList : Csla.BusinessListBase<XeList, Xe>
    {
        #region BindingList Overrides
        protected override object AddNewCore()
        {
            Xe item = Xe.NewXe();
            this.Add(item);
            return item;
        }
        #endregion //BindingList Overrides

        #region Authorization Rules

        public static bool CanGetObject()
        {
            //TODO: Define CanGetObject permission in XeList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("XeListViewGroup"))
            //	return true;
            //return false;
        }

        public static bool CanAddObject()
        {
            //TODO: Define CanAddObject permission in XeList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("XeListAddGroup"))
            //	return true;
            //return false;
        }

        public static bool CanEditObject()
        {
            //TODO: Define CanEditObject permission in XeList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("XeListEditGroup"))
            //	return true;
            //return false;
        }

        public static bool CanDeleteObject()
        {
            //TODO: Define CanDeleteObject permission in XeList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("XeListDeleteGroup"))
            //	return true;
            //return false;
        }
        #endregion //Authorization Rules

        #region Factory Methods
        private XeList()
        { /* require use of factory method */ }

        public static XeList NewXeList()
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a XeList");
            return new XeList();
        }

        public static XeList GetXeList(int maBoPhan)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a XeList");
            return DataPortal.Fetch<XeList>(new FilterCriteria(maBoPhan));
        }
        public static XeList GetXeList()
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a XeList");
            return DataPortal.Fetch<XeList>(new FilterCriteria());
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
                if (criteria.MaBoPhan == 0)
                {
                    cm.CommandText = "spd_SelecttblXesAll";
                }
                else if (criteria.MaBoPhan != 0)
                {
                    cm.CommandText = "spd_SelecttblXesAllbyBoPhan";
                    cm.Parameters.AddWithValue("@MaBoPhan", criteria.MaBoPhan);
                }

                using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                {
                    while (dr.Read())
                        this.Add(Xe.GetXe(dr));
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
                    foreach (Xe deletedChild in DeletedList)
                        deletedChild.DeleteSelf(tr);
                    DeletedList.Clear();

                    // loop through each non-deleted child object
                    foreach (Xe child in this)
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
