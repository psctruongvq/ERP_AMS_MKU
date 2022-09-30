using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{
    [Serializable()]
    public class CauTrucDoanhThuChiPhiList : Csla.BusinessListBase<CauTrucDoanhThuChiPhiList, CauTrucDoanhThuChiPhi>
    {
        #region BindingList Overrides
        protected override object AddNewCore()
        {
            CauTrucDoanhThuChiPhi item = CauTrucDoanhThuChiPhi.NewCauTrucDoanhThuChiPhi();
            this.Add(item);
            return item;
        }
        #endregion //BindingList Overrides

        #region Authorization Rules

        public static bool CanGetObject()
        {
            //TODO: Define CanGetObject permission in CauTrucDoanhThuChiPhiList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("CauTrucDoanhThuChiPhiListViewGroup"))
            //	return true;
            //return false;
        }

        public static bool CanAddObject()
        {
            //TODO: Define CanAddObject permission in CauTrucDoanhThuChiPhiList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("CauTrucDoanhThuChiPhiListAddGroup"))
            //	return true;
            //return false;
        }

        public static bool CanEditObject()
        {
            //TODO: Define CanEditObject permission in CauTrucDoanhThuChiPhiList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("CauTrucDoanhThuChiPhiListEditGroup"))
            //	return true;
            //return false;
        }

        public static bool CanDeleteObject()
        {
            //TODO: Define CanDeleteObject permission in CauTrucDoanhThuChiPhiList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("CauTrucDoanhThuChiPhiListDeleteGroup"))
            //	return true;
            //return false;
        }
        #endregion //Authorization Rules

        #region Factory Methods
        private CauTrucDoanhThuChiPhiList()
        { /* require use of factory method */ }

        public static CauTrucDoanhThuChiPhiList NewCauTrucDoanhThuChiPhiList()
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a CauTrucDoanhThuChiPhiList");
            return new CauTrucDoanhThuChiPhiList();
        }

        public static CauTrucDoanhThuChiPhiList GetCauTrucDoanhThuChiPhiList(int macongty)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a CauTrucDoanhThuChiPhiList");
            return DataPortal.Fetch<CauTrucDoanhThuChiPhiList>(new FilterCriteria(macongty));
        }

        public static CauTrucDoanhThuChiPhiList GetCauTrucDoanhThuChiPhiDangSuDungList(int macongty)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a CauTrucDoanhThuChiPhiList");
            return DataPortal.Fetch<CauTrucDoanhThuChiPhiList>(new FilterCriteria_DangSuDung(macongty));
        }
        #endregion //Factory Methods

        #region Data Access

        #region Filter Criteria
        [Serializable()]
        private class FilterCriteria
        {
            public int MaCongTy;
            public FilterCriteria(int macongty)
            {
                MaCongTy = macongty;
            }
        }

        private class FilterCriteria_DangSuDung
        {
            public int MaCongTy;
            public FilterCriteria_DangSuDung(int macongty)
            {
                MaCongTy = macongty;
            }
        }
        #endregion //Filter Criteria

        #region Data Access - Fetch
        private void DataPortal_Fetch(object criteria)
        {
            RaiseListChangedEvents = false;

            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();

                ExecuteFetch(cn, criteria);
            }//using

            RaiseListChangedEvents = true;
        }

        private void ExecuteFetch(SqlConnection cn, object criteria)
        {
            if (criteria is FilterCriteria)
            {
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_SelecttblCauTrucDoanhThuChiPhisAll";
                    cm.Parameters.AddWithValue("@MaCongTy", ((FilterCriteria)criteria).MaCongTy);

                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(CauTrucDoanhThuChiPhi.GetCauTrucDoanhThuChiPhi(dr));
                    }
                }//using
            }
            else if (criteria is FilterCriteria_DangSuDung)
            {
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_SelecttblCauTrucDoanhThuChiPhi_DangSuDung";
                    cm.Parameters.AddWithValue("@MaCongTy", ((FilterCriteria_DangSuDung)criteria).MaCongTy);

                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(CauTrucDoanhThuChiPhi.GetCauTrucDoanhThuChiPhi(dr));
                    }
                }//using
            }

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
                foreach (CauTrucDoanhThuChiPhi deletedChild in DeletedList)
                    deletedChild.DeleteSelf(cn);
                DeletedList.Clear();

                // loop through each non-deleted child object
                foreach (CauTrucDoanhThuChiPhi child in this)
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
