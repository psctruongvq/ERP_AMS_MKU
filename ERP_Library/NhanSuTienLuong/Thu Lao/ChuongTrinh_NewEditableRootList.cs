
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{
    [Serializable()]
    public class ChuongTrinh_NewList : Csla.BusinessListBase<ChuongTrinh_NewList, ChuongTrinh_New>
    {
        #region BindingList Overrides
        protected override object AddNewCore()
        {
            ChuongTrinh_New item = ChuongTrinh_New.NewChuongTrinh_New();
            this.Add(item);
            return item;
        }
        #endregion //BindingList Overrides

        #region Authorization Rules

        public static bool CanGetObject()
        {
            //TODO: Define CanGetObject permission in ChuongTrinh_NewList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("ChuongTrinh_NewListViewGroup"))
            //	return true;
            //return false;
        }

        public static bool CanAddObject()
        {
            //TODO: Define CanAddObject permission in ChuongTrinh_NewList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("ChuongTrinh_NewListAddGroup"))
            //	return true;
            //return false;
        }

        public static bool CanEditObject()
        {
            //TODO: Define CanEditObject permission in ChuongTrinh_NewList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("ChuongTrinh_NewListEditGroup"))
            //	return true;
            //return false;
        }

        public static bool CanDeleteObject()
        {
            //TODO: Define CanDeleteObject permission in ChuongTrinh_NewList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("ChuongTrinh_NewListDeleteGroup"))
            //	return true;
            //return false;
        }
        #endregion //Authorization Rules

        #region Factory Methods
        private ChuongTrinh_NewList()
        { /* require use of factory method */ }

        public static ChuongTrinh_NewList NewChuongTrinh_NewList()
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a ChuongTrinh_NewList");
            return new ChuongTrinh_NewList();
        }

        public static ChuongTrinh_NewList GetChuongTrinh_NewList()
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a ChuongTrinh_NewList");
            return DataPortal.Fetch<ChuongTrinh_NewList>(new FilterCriteria());
        }
        
        public static ChuongTrinh_NewList GetChuongTrinh_NewbyChaList(int maChuongTrinh,int kieu,int maCongTy)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a ChuongTrinh_NewList");
            return DataPortal.Fetch<ChuongTrinh_NewList>(new FilterCriteriabyCha(maChuongTrinh, kieu, maCongTy));
        }
        public static ChuongTrinh_NewList GetChuongTrinh_NewbyChaAllList(int maChuongTrinh, int kieu, int maCongTy, string tenChuongTrinhSearch, string maChuongTrinhSearch)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a ChuongTrinh_NewList");
            return DataPortal.Fetch<ChuongTrinh_NewList>(new FilterCriteriabyChaAll(maChuongTrinh, kieu, maCongTy, tenChuongTrinhSearch,maChuongTrinhSearch));
        }
        public static ChuongTrinh_NewList GetChuongTrinh_NewListbySearch(int kieu, int maCongTy, string tenChuongTrinhSearch)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a ChuongTrinh_NewList");
            return DataPortal.Fetch<ChuongTrinh_NewList>(new FilterCriteriabyChaAllSearch(kieu, maCongTy, tenChuongTrinhSearch));
        }
        public static ChuongTrinh_NewList GetChuongTrinh_NewListAll(int kieu, int maCongTy)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a ChuongTrinh_NewList");
            return DataPortal.Fetch<ChuongTrinh_NewList>(new FilterCriteriaAll(kieu, maCongTy));
        }
        public static ChuongTrinh_NewList GetChuongTrinh_NewListAllParentSearch(int kieu, int maCongTy, string tenChuongTrinhSearch)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a ChuongTrinh_NewList");
            return DataPortal.Fetch<ChuongTrinh_NewList>(new FilterCriteriaAllParentSearch(kieu, maCongTy,tenChuongTrinhSearch));
        }
        public static ChuongTrinh_NewList GetChuongTrinh_NewListAllChildSearch(int kieu, int maCongTy, string tenChuongTrinhSearch)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a ChuongTrinh_NewList");
            return DataPortal.Fetch<ChuongTrinh_NewList>(new FilterCriteriaAllChildSearch(kieu, maCongTy, tenChuongTrinhSearch));
        }

        #region BanQuyen
        public static ChuongTrinh_NewList GetChuongTrinh_NewListbyChuongTrinhCha_BQ(int maChuongTrinh, int kieu, int maCongTy)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a ChuongTrinh_NewList");
            return DataPortal.Fetch<ChuongTrinh_NewList>(new FilterCriteriabyChuongTrinhCha_BQ(maChuongTrinh, kieu, maCongTy));
        }

        public static ChuongTrinh_NewList GetChuongTrinh_NewList_BQ(int kieu, int maCongTy)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a ChuongTrinh_NewList");
            return DataPortal.Fetch<ChuongTrinh_NewList>(new FilterCriteriaAll_BQ(kieu, maCongTy));
        }
        #endregion
        public static int GetmaxMaChuongTrinh(int kieu)
        {
            int _kq = 0;
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "Spd_GetMaxMaChuongTrinh";
                    cm.Parameters.AddWithValue("@HoanTat", kieu);
                    cm.Parameters.AddWithValue("@MaCongTy", ERP_Library.Security.CurrentUser.Info.MaCongTy);
                    SqlParameter prmGiaTriTraVe = new SqlParameter("@GiaTriTraVe", SqlDbType.Int, 32);
                    prmGiaTriTraVe.Direction = ParameterDirection.Output;
                    cm.Parameters.Add(prmGiaTriTraVe);
                    cm.ExecuteNonQuery();
                    _kq = (int)prmGiaTriTraVe.Value;
                }
            }//us
            return _kq;
        }

        public static bool ExistChuongTrinhConSearch(int maChuongTrinh, ChuongTrinh_NewList chuongTrinhList)
        {
            if(chuongTrinhList.Count>0)

                foreach (ChuongTrinh_New ct in chuongTrinhList)
                {
                    if(ct.MaChuongTrinhCha==maChuongTrinh)
                        return true;
                }
            return false;
        }

        public static bool ExistChuongTrinhCon(int maChuongTrinh, int kieu, int maCongTy, string tenChuongTrinhSearch, string maChuongTrinhSearch)
        {
            bool _kq = false;
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "ExistsChildChuongTrinhes";
                    cm.Parameters.AddWithValue("@MaChuongTrinh", maChuongTrinh);
                    cm.Parameters.AddWithValue("@HoanTat", kieu);
                    cm.Parameters.AddWithValue("@MaCongTy", maCongTy);

                    if (tenChuongTrinhSearch.Length > 0)
                        cm.Parameters.AddWithValue("@TenChuongTrinhSearch", tenChuongTrinhSearch);
                    else
                        cm.Parameters.AddWithValue("@TenChuongTrinhSearch", DBNull.Value);

                    if (maChuongTrinhSearch.Length > 0)
                        cm.Parameters.AddWithValue("@MaChuongTrinhSearch", maChuongTrinhSearch);
                    else
                        cm.Parameters.AddWithValue("@MaChuongTrinhSearch", DBNull.Value);

                    SqlParameter prmGiaTriTraVe = new SqlParameter("@GiaTriTraVe", SqlDbType.Bit, 16);
                    prmGiaTriTraVe.Direction = ParameterDirection.Output;
                    cm.Parameters.Add(prmGiaTriTraVe);
                    cm.ExecuteNonQuery();
                    _kq = (bool)prmGiaTriTraVe.Value;
                }
            }//us
            return _kq;
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
        private class FilterCriteriabyCha
        {
            public int MaChuongTrinh;
            public int Kieu;
            public int MaCongTy;

            public FilterCriteriabyCha(int maChuongTrinh, int kieu,int maCongTy)
            {
                this.MaChuongTrinh = maChuongTrinh;
                this.Kieu = kieu;
                this.MaCongTy = maCongTy;
            }
        }
        private class FilterCriteriabyChaAll
        {
            public int MaChuongTrinh;
            public int Kieu;
            public int MaCongTy;
            public string TenChuongTrinhSearch;
            public string MaChuongTrinhSearch;

            public FilterCriteriabyChaAll(int maChuongTrinh, int kieu, int maCongTy, string tenChuongTrinhSearch, string maChuongTrinhSearch)
            {
                this.MaChuongTrinh = maChuongTrinh;
                this.Kieu = kieu;
                this.MaCongTy = maCongTy;
                this.TenChuongTrinhSearch = tenChuongTrinhSearch;
                this.MaChuongTrinhSearch = maChuongTrinhSearch;
            }
        }
        private class FilterCriteriabyChaAllSearch
        {
            public int Kieu;
            public int MaCongTy;
            public string TenChuongTrinhSearch;

            public FilterCriteriabyChaAllSearch(int kieu, int maCongTy, string tenChuongTrinhSearch)
            {
                this.Kieu = kieu;
                this.MaCongTy = maCongTy;
                this.TenChuongTrinhSearch = tenChuongTrinhSearch;

            }
        }
        private class FilterCriteriaAllParentSearch
        {
            public int Kieu;
            public int MaCongTy;
            public string TenChuongTrinhSearch;

            public FilterCriteriaAllParentSearch(int kieu, int maCongTy, string tenChuongTrinhSearch)
            {
                this.Kieu = kieu;
                this.MaCongTy = maCongTy;
                this.TenChuongTrinhSearch = tenChuongTrinhSearch;
            }
        }
        private class FilterCriteriaAllChildSearch
        {
            public int Kieu;
            public int MaCongTy;
            public string TenChuongTrinhSearch;

            public FilterCriteriaAllChildSearch(int kieu, int maCongTy, string tenChuongTrinhSearch)
            {
                this.Kieu = kieu;
                this.MaCongTy = maCongTy;
                this.TenChuongTrinhSearch = tenChuongTrinhSearch;
            }
        }
        private class FilterCriteriaAll
        {
            public int Kieu;
            public int MaCongTy;

            public FilterCriteriaAll(int kieu, int maCongTy)
            {
                this.Kieu = kieu;
                this.MaCongTy = maCongTy;
            }
        }

        private class FilterCriteriabyChuongTrinhCha_BQ
        {
            public int MaChuongTrinh;
            public int Kieu;
            public int MaCongTy;

            public FilterCriteriabyChuongTrinhCha_BQ(int maChuongTrinh, int kieu, int maCongTy)
            {
                this.MaChuongTrinh = maChuongTrinh;
                this.Kieu = kieu;
                this.MaCongTy = maCongTy;
            }
        }

        private class FilterCriteriaAll_BQ
        {
            public int Kieu;
            public int MaCongTy;

            public FilterCriteriaAll_BQ(int kieu, int maCongTy)
            {
                this.Kieu = kieu;
                this.MaCongTy = maCongTy;
            }
        }

        #endregion //Filter Criteria

        #region Data Access - Fetch
        private void DataPortal_Fetch(Object criteria)
        {
            RaiseListChangedEvents = false;

            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();

                ExecuteFetch(cn, criteria);
            }//using

            RaiseListChangedEvents = true;
        }

        private void ExecuteFetch(SqlConnection cn, Object criteria)
        {
            using (SqlCommand cm = cn.CreateCommand())
            {
                cm.CommandType = CommandType.StoredProcedure;
                if (criteria is FilterCriteriabyCha)
                {
                    cm.CommandText = "spd_SelecttblnsChuongTrinhesbyCha_New";
                    cm.Parameters.AddWithValue("@MaChuongTrinh", ((FilterCriteriabyCha)criteria).MaChuongTrinh);
                    cm.Parameters.AddWithValue("@HoanTat", ((FilterCriteriabyCha)criteria).Kieu);
                    cm.Parameters.AddWithValue("@MaCongTy", ((FilterCriteriabyCha)criteria).MaCongTy);
                }
                else if (criteria is FilterCriteriabyChaAll)
                {
                    //cm.CommandText = "spd_SelecttblnsChuongTrinhes_NewbyChaAll";
                    cm.CommandText = "spd_SelecttblnsChuongTrinhes_NewbyChaAllSearch";
                    cm.Parameters.AddWithValue("@MaChuongTrinh", ((FilterCriteriabyChaAll)criteria).MaChuongTrinh);
                    cm.Parameters.AddWithValue("@HoanTat", ((FilterCriteriabyChaAll)criteria).Kieu);
                    cm.Parameters.AddWithValue("@MaCongTy", ((FilterCriteriabyChaAll)criteria).MaCongTy);
                    if (((FilterCriteriabyChaAll)criteria).TenChuongTrinhSearch.Length > 0)
                        cm.Parameters.AddWithValue("@TenChuongTrinhSearch", ((FilterCriteriabyChaAll)criteria).TenChuongTrinhSearch);
                    else
                        cm.Parameters.AddWithValue("@TenChuongTrinhSearch", DBNull.Value);
                    if (((FilterCriteriabyChaAll)criteria).MaChuongTrinhSearch.Length > 0)
                        cm.Parameters.AddWithValue("@MaChuongTrinhSearch", ((FilterCriteriabyChaAll)criteria).MaChuongTrinhSearch);
                    else
                        cm.Parameters.AddWithValue("@MaChuongTrinhSearch", DBNull.Value);

                }
                else if (criteria is FilterCriteriabyChaAllSearch)
                {
                    cm.CommandText = "spd_SelecttblnsChuongTrinhes_NewbyChaAllSearch2";
                    cm.Parameters.AddWithValue("@HoanTat", ((FilterCriteriabyChaAllSearch)criteria).Kieu);
                    cm.Parameters.AddWithValue("@MaCongTy", ((FilterCriteriabyChaAllSearch)criteria).MaCongTy);
                    if (((FilterCriteriabyChaAllSearch)criteria).TenChuongTrinhSearch.Length > 0)
                        cm.Parameters.AddWithValue("@TenChuongTrinhSearch", ((FilterCriteriabyChaAllSearch)criteria).TenChuongTrinhSearch);
                    else
                        cm.Parameters.AddWithValue("@TenChuongTrinhSearch", DBNull.Value);

                }
                else if (criteria is FilterCriteriaAll)
                {
                    cm.CommandText = "spd_SelecttblnsChuongTrinhes_NewAll";
                    cm.Parameters.AddWithValue("@HoanTat", ((FilterCriteriaAll)criteria).Kieu);
                    cm.Parameters.AddWithValue("@MaCongTy", ((FilterCriteriaAll)criteria).MaCongTy);

                }
                else if (criteria is FilterCriteriaAllParentSearch)
                {
                    cm.CommandText = "spd_SelecttblnsChuongTrinhes_NewAllParentSearch";
                    cm.Parameters.AddWithValue("@HoanTat", ((FilterCriteriaAllParentSearch)criteria).Kieu);
                    cm.Parameters.AddWithValue("@MaCongTy", ((FilterCriteriaAllParentSearch)criteria).MaCongTy);
                    if (((FilterCriteriaAllParentSearch)criteria).TenChuongTrinhSearch.Length > 0)
                        cm.Parameters.AddWithValue("@TenChuongTrinhSearch", ((FilterCriteriaAllParentSearch)criteria).TenChuongTrinhSearch);
                    else
                        cm.Parameters.AddWithValue("@TenChuongTrinhSearch", DBNull.Value);

                }
                else if (criteria is FilterCriteriaAllChildSearch)
                {
                    cm.CommandText = "spd_SelecttblnsChuongTrinhes_NewAllChildSearch";
                    cm.Parameters.AddWithValue("@HoanTat", ((FilterCriteriaAllChildSearch)criteria).Kieu);
                    cm.Parameters.AddWithValue("@MaCongTy", ((FilterCriteriaAllChildSearch)criteria).MaCongTy);
                    if (((FilterCriteriaAllChildSearch)criteria).TenChuongTrinhSearch.Length > 0)
                        cm.Parameters.AddWithValue("@TenChuongTrinhSearch", ((FilterCriteriaAllChildSearch)criteria).TenChuongTrinhSearch);
                    else
                        cm.Parameters.AddWithValue("@TenChuongTrinhSearch", DBNull.Value);

                }
                else if (criteria is FilterCriteria)
                {
                    cm.CommandText = "spd_SelecttblnsChuongTrinhes_NewList";

                }
                else if (criteria is FilterCriteriabyChuongTrinhCha_BQ)
                {
                    cm.CommandText = "spd_SelecttblnsChuongTrinhesbyChuongTrinhCha_BQ";
                    cm.Parameters.AddWithValue("@MaChuongTrinh", ((FilterCriteriabyChuongTrinhCha_BQ)criteria).MaChuongTrinh);
                    cm.Parameters.AddWithValue("@HoanTat", ((FilterCriteriabyChuongTrinhCha_BQ)criteria).Kieu);
                    cm.Parameters.AddWithValue("@MaCongTy", ((FilterCriteriabyChuongTrinhCha_BQ)criteria).MaCongTy);
                }
                else if (criteria is FilterCriteriaAll_BQ)
                {
                    cm.CommandText = "spd_SelecttblnsChuongTrinhesAll_BQ";
                    cm.Parameters.AddWithValue("@HoanTat", ((FilterCriteriaAll_BQ)criteria).Kieu);
                    cm.Parameters.AddWithValue("@MaCongTy", ((FilterCriteriaAll_BQ)criteria).MaCongTy);
                }

                using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                {
                    while (dr.Read())
                        this.Add(ChuongTrinh_New.GetChuongTrinh_New(dr));
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
                foreach (ChuongTrinh_New deletedChild in DeletedList)
                    deletedChild.DeleteSelf(cn);
                DeletedList.Clear();

                // loop through each non-deleted child object
                foreach (ChuongTrinh_New child in this)
                {
                    if (child.IsNew)
                        child.Insert(cn,this);
                    else
                        child.Update(cn, this);
                }
            }//using SqlConnection

            RaiseListChangedEvents = true;
        }
        #endregion //Data Access - Update
        #endregion //Data Access
    }
}
