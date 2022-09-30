
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{
    [Serializable()]
    public class PhuCapList : Csla.BusinessListBase<PhuCapList, PhuCapChild>
    {
        #region BindingList Overrides
        protected override object AddNewCore()
        {
            PhuCapChild item = PhuCapChild.NewPhuCapChild();
            this.Add(item);
            return item;

        }
        #endregion //BindingList Overrides

        #region Authorization Rules

        public static bool CanGetObject()
        {
            //TODO: Define CanGetObject permission in PhuCapList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("PhuCapListViewGroup"))
            //	return true;
            //return false;

        }

        public static bool CanAddObject()
        {
            //TODO: Define CanAddObject permission in PhuCapList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("PhuCapListAddGroup"))
            //	return true;
            //return false;
        }

        public static bool CanEditObject()
        {
            //TODO: Define CanEditObject permission in PhuCapList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("PhuCapListEditGroup"))
            //	return true;
            //return false;
        }

        public static bool CanDeleteObject()
        {
            //TODO: Define CanDeleteObject permission in PhuCapList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("PhuCapListDeleteGroup"))
            //	return true;
            //return false;
        }
        #endregion //Authorization Rules

        #region Factory Methods
        private PhuCapList()
        { /* require use of factory method */ }

        public static PhuCapList NewPhuCapList()
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a PhuCapList");
            return new PhuCapList();
        }

        public static PhuCapList GetPhuCapListByLoaiPhuCap(int maLoaiPhuCap)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a PhuCapList");
            return DataPortal.Fetch<PhuCapList>(new FilterCriteria(maLoaiPhuCap));
        }

        public static PhuCapList GetPhuCapListByMaPhuCap(int maPhuCap)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a PhuCapList");
            return DataPortal.Fetch<PhuCapList>(new FilterCriteriabyMaPhuCap(maPhuCap));
        }

        public static PhuCapList GetPhuCapListAll()
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a PhuCapList");
            return DataPortal.Fetch<PhuCapList>(new FilterAll());
        }

        #endregion //Factory Methods

        #region Data Access

        #region Filter Criteria
        [Serializable()]
        private class FilterCriteria
        {
            public int MaLoaiPhuCap;

            public FilterCriteria(int maLoaiPhuCap)
            {
                this.MaLoaiPhuCap = maLoaiPhuCap;
            }
        }
        [Serializable()]
        private class FilterCriteriabyMaPhuCap
        {
            public int MaPhuCap;

            public FilterCriteriabyMaPhuCap(int maPhuCap)
            {
                this.MaPhuCap = maPhuCap;
            }
        }
        [Serializable()]
        private class FilterAll
        {
        }
        [Serializable()]
        private class FilterNhomPhuCap
        {
            public int MaNhom;

            public FilterNhomPhuCap(int maNhom)
            {
                MaNhom = maNhom;
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
                if (criteria is FilterAll)
                {
                    cm.CommandText = "spd_Select_PhuCapListAll";
                    cm.Parameters.AddWithValue("@UserID", Security.CurrentUser.Info.UserID);
                }
                else if (criteria is FilterCriteria)
                {
                    cm.CommandText = "spd_Select_PhuCapList";
                    cm.Parameters.AddWithValue("@MaLoaiPhuCap", ((FilterCriteria)criteria).MaLoaiPhuCap);
                }
                else if (criteria is FilterCriteriabyMaPhuCap)
                {
                    cm.CommandText = "spd_Select_PhuCapListByMaPhuCap";
                    cm.Parameters.AddWithValue("@MaPhuCap", ((FilterCriteriabyMaPhuCap)criteria).MaPhuCap);
                }
                else if (criteria is FilterNhomPhuCap)
                {
                    cm.CommandText = "spd_Select_PhuCapListByMaNhom";
                    cm.Parameters.AddWithValue("@MaNhom", ((FilterNhomPhuCap)criteria).MaNhom);
                }

                using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                {
                    while (dr.Read())
                        this.Add(PhuCapChild.GetPhuCapChild(dr));
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
                    foreach (PhuCapChild deletedChild in DeletedList)
                        deletedChild.DeleteSelf(tr);
                    DeletedList.Clear();

                    // loop through each non-deleted child object
                    foreach (PhuCapChild child in this)
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

        public static global::ERP_Library.PhuCapList GetPhuCapListByNhomPhuCap(int MaNhom)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a PhuCapList");
            return DataPortal.Fetch<PhuCapList>(new FilterNhomPhuCap(MaNhom));           
        }
    }
}
