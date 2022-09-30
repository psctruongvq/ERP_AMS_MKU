
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{
    [Serializable()]
    public class NhomVanBanList : Csla.BusinessListBase<NhomVanBanList, NhomVanBan>
    {
        #region BindingList Overrides
        protected override object AddNewCore()
        {
            NhomVanBan item = NhomVanBan.NewNhomVanBan();
            this.Add(item);
            return item;
        }
        #endregion //BindingList Overrides

        #region Authorization Rules

        public static bool CanGetObject()
        {
            //TODO: Define CanGetObject permission in NhomVanBanList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("NhomVanBanListViewGroup"))
            //	return true;
            //return false;
        }

        public static bool CanAddObject()
        {
            //TODO: Define CanAddObject permission in NhomVanBanList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("NhomVanBanListAddGroup"))
            //	return true;
            //return false;
        }

        public static bool CanEditObject()
        {
            //TODO: Define CanEditObject permission in NhomVanBanList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("NhomVanBanListEditGroup"))
            //	return true;
            //return false;
        }

        public static bool CanDeleteObject()
        {
            //TODO: Define CanDeleteObject permission in NhomVanBanList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("NhomVanBanListDeleteGroup"))
            //	return true;
            //return false;
        }
        #endregion //Authorization Rules

        #region Factory Methods
        private NhomVanBanList()
        { /* require use of factory method */ }

        public static NhomVanBanList NewNhomVanBanList()
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a NhomVanBanList");
            return new NhomVanBanList();
        }

        public static NhomVanBanList GetNhomVanBanList()
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a NhomVanBanList");
            return DataPortal.Fetch<NhomVanBanList>(new FilterCriteria());
        }

        public static NhomVanBanList GetNhomVanBanList(long maNhomCha)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a NhomVanBanList");
            return DataPortal.Fetch<NhomVanBanList>(new FilterCriteriaByNhomCha(maNhomCha));
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

        private class FilterCriteriaByNhomCha
        {
            public long MaNhomCha;

            public FilterCriteriaByNhomCha(long maNhomCha)
            {
                this.MaNhomCha = maNhomCha;
            }
        }
        #endregion //Filter Criteria

        #region Data Access - Fetch
        private void DataPortal_Fetch(Object criteria)
        {
            RaiseListChangedEvents = false;

            SqlTransaction tr;

            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection_Digital))
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

        private void ExecuteFetch(SqlTransaction tr, object criteria)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                if (criteria is FilterCriteria)
                {
                    cm.CommandText = "spd_SelecttblNhomVanBansAll";
                }
                else if (criteria is FilterCriteriaByNhomCha)
                {
                    cm.CommandText = "spd_SelecttblNhomVanBansByAndMaNhomCha";
                    cm.Parameters.AddWithValue("@MaNhomCha", ((FilterCriteriaByNhomCha)criteria).MaNhomCha);
                }

                using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                {
                    while (dr.Read())
                        this.Add(NhomVanBan.GetNhomVanBan(dr));
                }
            }//using
        }
        #endregion //Data Access - Fetch


        #region Data Access - Update
        protected override void DataPortal_Update()
        {
            RaiseListChangedEvents = false;

            SqlTransaction tr;

            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection_Digital))
            {
                cn.Open();

                tr = cn.BeginTransaction();
                try
                {
                    // loop through each deleted child object
                    foreach (NhomVanBan deletedChild in DeletedList)
                        deletedChild.DeleteSelf(tr);
                    DeletedList.Clear();

                    // loop through each non-deleted child object
                    foreach (NhomVanBan child in this)
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
