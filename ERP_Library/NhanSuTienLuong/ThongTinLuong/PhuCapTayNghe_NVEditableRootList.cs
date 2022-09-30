
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{
    [Serializable()]
    public class PhuCapTayNghe_NVList : Csla.BusinessListBase<PhuCapTayNghe_NVList, PhuCapTayNghe_NV>
    {
        #region BindingList Overrides
        protected override object AddNewCore()
        {
            PhuCapTayNghe_NV item = PhuCapTayNghe_NV.NewPhuCapTayNghe_NV();
            this.Add(item);
            return item;
        }
        #endregion //BindingList Overrides

        #region Authorization Rules

        public static bool CanGetObject()
        {
            //TODO: Define CanGetObject permission in PhuCapTayNghe_NVList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("PhuCapTayNghe_NVListViewGroup"))
            //	return true;
            //return false;
        }

        public static bool CanAddObject()
        {
            //TODO: Define CanAddObject permission in PhuCapTayNghe_NVList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("PhuCapTayNghe_NVListAddGroup"))
            //	return true;
            //return false;
        }

        public static bool CanEditObject()
        {
            //TODO: Define CanEditObject permission in PhuCapTayNghe_NVList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("PhuCapTayNghe_NVListEditGroup"))
            //	return true;
            //return false;
        }

        public static bool CanDeleteObject()
        {
            //TODO: Define CanDeleteObject permission in PhuCapTayNghe_NVList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("PhuCapTayNghe_NVListDeleteGroup"))
            //	return true;
            //return false;
        }
        #endregion //Authorization Rules

        #region Factory Methods
        private PhuCapTayNghe_NVList()
        { /* require use of factory method */ }

        public static PhuCapTayNghe_NVList NewPhuCapTayNghe_NVList()
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a PhuCapTayNghe_NVList");
            return new PhuCapTayNghe_NVList();
        }

        public static PhuCapTayNghe_NVList GetPhuCapTayNghe_NVList()
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a PhuCapTayNghe_NVList");
            return DataPortal.Fetch<PhuCapTayNghe_NVList>(new FilterCriteria());
        }
        public static PhuCapTayNghe_NVList GetPhuCapTayNghe_NVListbybophan(int mabophan,int makyluong)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a PhuCapTayNghe_NVList");
            return DataPortal.Fetch<PhuCapTayNghe_NVList>(new FilterCriteriabybophan(mabophan,makyluong));
        }

        public static PhuCapTayNghe_NVList GetPhuCapTayNghe_NVListbyNhanVien(int mabophan, int makyluong, string DKTim)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a PhuCapTayNghe_NVList");
            return DataPortal.Fetch<PhuCapTayNghe_NVList>(new FilterCriteriabyNhanVien(mabophan, makyluong,DKTim));
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
        private class FilterCriteriabybophan
        {   
            public int mabophan;
            public int makyluong;
            public FilterCriteriabybophan(int mabophan,int makyluong)
            {
                this.mabophan=mabophan;
                this.makyluong = makyluong;
            }
        }
        private class FilterCriteriabyNhanVien
        {
            public int mabophan;
            public int makyluong;
            public string DkTim;
            public FilterCriteriabyNhanVien(int mabophan, int makyluong, string DkTim)
            {
                this.mabophan = mabophan;
                this.makyluong = makyluong;
                this.DkTim = DkTim;
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
                catch (SqlException ex)
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
                {
                    cm.CommandText = "spd_SelecttblnsPhuCapTayNghe_NVsAll";
                }
                else if (criteria is FilterCriteriabybophan)
                {
                    cm.CommandText = "spd_SelecttblnsPhuCapTayNghe_NVbybophan";
                    cm.Parameters.AddWithValue("@mabophan", ((FilterCriteriabybophan)criteria).mabophan);
                    cm.Parameters.AddWithValue("@makyluong", ((FilterCriteriabybophan)criteria).makyluong);
                }
                else if (criteria is FilterCriteriabyNhanVien)
                {
                    cm.CommandText = "spd_SelecttblnsPhuCapTayNghe_NVbyNhanVien";
                    cm.Parameters.AddWithValue("@mabophan", ((FilterCriteriabyNhanVien)criteria).mabophan);
                    cm.Parameters.AddWithValue("@makyluong", ((FilterCriteriabyNhanVien)criteria).makyluong);
                    cm.Parameters.AddWithValue("@DKTim", ((FilterCriteriabyNhanVien)criteria).DkTim);
                }


                using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                {
                    while (dr.Read())
                        this.Add(PhuCapTayNghe_NV.GetPhuCapTayNghe_NV(dr));
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
                    foreach (PhuCapTayNghe_NV deletedChild in DeletedList)
                        deletedChild.DeleteSelf(tr);
                    DeletedList.Clear();

                    // loop through each non-deleted child object
                    foreach (PhuCapTayNghe_NV child in this)
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

