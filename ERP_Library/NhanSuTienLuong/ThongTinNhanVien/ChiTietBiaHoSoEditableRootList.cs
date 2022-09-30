
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{
    [Serializable()]
    public class ChiTietBiaHoSoList : Csla.BusinessListBase<ChiTietBiaHoSoList, ChiTietBiaHoSo>
    {
        #region BindingList Overrides
        protected override object AddNewCore()
        {
            ChiTietBiaHoSo item = ChiTietBiaHoSo.NewChiTietBiaHoSo();
            this.Add(item);
            return item;
        }
        #endregion //BindingList Overrides

        #region Authorization Rules

        public static bool CanGetObject()
        {
            //TODO: Define CanGetObject permission in ChiTietBiaHoSoList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("ChiTietBiaHoSoListViewGroup"))
            //	return true;
            //return false;
        }

        public static bool CanAddObject()
        {
            //TODO: Define CanAddObject permission in ChiTietBiaHoSoList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("ChiTietBiaHoSoListAddGroup"))
            //	return true;
            //return false;
        }

        public static bool CanEditObject()
        {
            //TODO: Define CanEditObject permission in ChiTietBiaHoSoList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("ChiTietBiaHoSoListEditGroup"))
            //	return true;
            //return false;
        }

        public static bool CanDeleteObject()
        {
            //TODO: Define CanDeleteObject permission in ChiTietBiaHoSoList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("ChiTietBiaHoSoListDeleteGroup"))
            //	return true;
            //return false;
        }
        #endregion //Authorization Rules

        #region Factory Methods
        private ChiTietBiaHoSoList()
        { /* require use of factory method */ }

        public static ChiTietBiaHoSoList NewChiTietBiaHoSoList()
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a ChiTietBiaHoSoList");
            return new ChiTietBiaHoSoList();
        }

        public static ChiTietBiaHoSoList GetChiTietBiaHoSoList(long maNhanVien)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a ChiTietBiaHoSoList");
            return DataPortal.Fetch<ChiTietBiaHoSoList>(new FilterCriteria(maNhanVien));
        }
        public static ChiTietBiaHoSoList GetChiTietBiaHoSoListByBoPhan(int mabophan)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a ChiTietBiaHoSoList");
            return DataPortal.Fetch<ChiTietBiaHoSoList>(new FilterCriteriaByBoPhan(mabophan));
        }
        public static ChiTietBiaHoSoList GetChiTietBiaHoSoListByBiaHoSo(int mabiahoso)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a ChiTietBiaHoSoList");
            return DataPortal.Fetch<ChiTietBiaHoSoList>(new FilterCriteriaByBiaHoSo(mabiahoso));
        }
        #endregion //Factory Methods

        #region Data Access

        #region Filter Criteria
        [Serializable()]
        private class FilterCriteria
        {
            public long MaNhanVien;

            public FilterCriteria(long maNhanVien)
            {
                this.MaNhanVien = maNhanVien;
            }
        }
        private class FilterCriteriaByBoPhan
        {
            public int mabophan;

            public FilterCriteriaByBoPhan(int mabophan)
            {
                this.mabophan = mabophan;
            }
        }
   
        private class FilterCriteriaByBiaHoSo
        {
            public int mabiahoso;

            public FilterCriteriaByBiaHoSo(int mabiahoso)
            {
                this.mabiahoso = mabiahoso;
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
                    //cm.CommandText = "spd_ChiTietBiaHoSoList";
                    //cm.Parameters.AddWithValue("@MaNhanVien", criteria.MaNhanVien);
                }
                else if (criteria is FilterCriteriaByBoPhan)
                {
                    cm.CommandText = "spd_SelecttblnsChiTietBiaHoSoListByBophan";
                    cm.Parameters.AddWithValue("@mabophan", ((FilterCriteriaByBoPhan)criteria).mabophan);
                }
                else if (criteria is FilterCriteriaByBiaHoSo)
                {
                    cm.CommandText = "spd_SelecttblnsChiTietBiaHoSoByBiaHoSo";
                    cm.Parameters.AddWithValue("@mabiahoso", ((FilterCriteriaByBiaHoSo)criteria).mabiahoso);                    

                }
                using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                {
                    while (dr.Read())
                        this.Add(ChiTietBiaHoSo.GetChiTietBiaHoSo(dr));
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
                    foreach (ChiTietBiaHoSo deletedChild in DeletedList)
                        deletedChild.DeleteSelf(tr);
                    DeletedList.Clear();

                    // loop through each non-deleted child object
                    foreach (ChiTietBiaHoSo child in this)
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
