
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{
    [Serializable()]
    public class HangHoaBQ_VTList : Csla.BusinessListBase<HangHoaBQ_VTList, HangHoaBQ_VT>
    {
        #region BindingList Overrides
        protected override object AddNewCore()
        {
            HangHoaBQ_VT item = HangHoaBQ_VT.NewHangHoaBQ_VT();
            this.Add(item);
            return item;
        }
        #endregion //BindingList Overrides

        #region Authorization Rules

        public static bool CanGetObject()
        {
            //TODO: Define CanGetObject permission in HangHoaBQ_VTList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("HangHoaBQ_VTListViewGroup"))
            //	return true;
            //return false;
        }

        public static bool CanAddObject()
        {
            //TODO: Define CanAddObject permission in HangHoaBQ_VTList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("HangHoaBQ_VTListAddGroup"))
            //	return true;
            //return false;
        }

        public static bool CanEditObject()
        {
            //TODO: Define CanEditObject permission in HangHoaBQ_VTList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("HangHoaBQ_VTListEditGroup"))
            //	return true;
            //return false;
        }

        public static bool CanDeleteObject()
        {
            //TODO: Define CanDeleteObject permission in HangHoaBQ_VTList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("HangHoaBQ_VTListDeleteGroup"))
            //	return true;
            //return false;
        }
        #endregion //Authorization Rules

        #region Factory Methods
        private HangHoaBQ_VTList()
        { /* require use of factory method */ }

        public static HangHoaBQ_VTList NewHangHoaBQ_VTList()
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a HangHoaBQ_VTList");
            return new HangHoaBQ_VTList();
        }

        public static HangHoaBQ_VTList GetHangHoaBQ_VTList()
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a HangHoaBQ_VTList");
            return DataPortal.Fetch<HangHoaBQ_VTList>(new FilterCriteria());
        }

        public static HangHoaBQ_VTList GetHangHoaVatTuHangHoaList()
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a HangHoaBQ_VTList");
            return DataPortal.Fetch<HangHoaBQ_VTList>(new FilterCriteriaByVatTuHangHoa());
        }

        public static HangHoaBQ_VTList GetHangHoaVatTuHangHoaList_2018(DateTime Ngay)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a HangHoaBQ_VTList");
            return DataPortal.Fetch<HangHoaBQ_VTList>(new FilterCriteriaByVatTuHangHoa_2018(Ngay));
        }

        public static HangHoaBQ_VTList GetHangHoaBQ_VTList(int maLoaiVatTu)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a HangHoaBQ_VTList");
            return DataPortal.Fetch<HangHoaBQ_VTList>(new FilterCriteriaByMaLoaiVatTu(maLoaiVatTu));
        }
        
        public static HangHoaBQ_VTList GetHangHoaBQ_VTListByMaNhom(int maNhomHangHoa)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a HangHoaBQ_VTList");
            return DataPortal.Fetch<HangHoaBQ_VTList>(new FilterCriteriaByMaNhomHangHoa(maNhomHangHoa));
        }

        public static HangHoaBQ_VTList GetHangHoaBQ_VTList_BoPhanDangSuDung(int maBoPhan)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a HangHoaBQ_VTList");
            return DataPortal.Fetch<HangHoaBQ_VTList>(new FilterCriteria_BoPhanDangSuDung(maBoPhan));
        }

        public static HangHoaBQ_VTList GetHangHoaCongCuDungCuList()
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a HangHoaBQ_VTList");
            return DataPortal.Fetch<HangHoaBQ_VTList>(new FilterCriteriaHangHoaCongCuDungCu());
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
        private class FilterCriteriaHangHoaCongCuDungCu
        {

            public FilterCriteriaHangHoaCongCuDungCu()
            {

            }
        }
        private class FilterCriteriaByMaNhomHangHoa
        {

            public int MaNhomHangHoa;
            public FilterCriteriaByMaNhomHangHoa(int maNhomHangHoa)
            {
                MaNhomHangHoa = maNhomHangHoa;
            }
        }

        private class FilterCriteria_BoPhanDangSuDung
        {

            public int MaBoPhan;
            public FilterCriteria_BoPhanDangSuDung(int maBoPhan)
            {
                MaBoPhan = maBoPhan;
            }
        }

        private class FilterCriteriaByMaLoaiVatTu
        {

            public int MaLoaiVatTu;
            public FilterCriteriaByMaLoaiVatTu(int maLoaiVatTu)
            {
                MaLoaiVatTu = maLoaiVatTu;
            }
        }

        private class FilterCriteriaByVatTuHangHoa
        {
            public int MaLoaiVatTu;
            public FilterCriteriaByVatTuHangHoa()
            {

            }
        }

        private class FilterCriteriaByVatTuHangHoa_2018
        {
            public DateTime Ngay;
            public FilterCriteriaByVatTuHangHoa_2018(DateTime ngay)
            {
                this.Ngay = ngay;
            }
        }

        #endregion //Filter Criteria

        #region Data Access - Fetch
        private void DataPortal_Fetch(Object criteria)
        {
            RaiseListChangedEvents = false;
            if (criteria is FilterCriteria_BoPhanDangSuDung)
            {
                SqlTransaction tr;

                using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
                {
                    cn.Open();

                    tr = cn.BeginTransaction();
                    try
                    {
                        ExecuteFetch_BoPhanDangSuDung(tr, criteria as FilterCriteria_BoPhanDangSuDung);

                        tr.Commit();
                    }
                    catch
                    {
                        tr.Rollback();
                        throw;
                    }
                }//using
            }
            else
            {
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
            }
            RaiseListChangedEvents = true;
        }
        private void ExecuteFetch_BoPhanDangSuDung(SqlTransaction tr, FilterCriteria_BoPhanDangSuDung criteria)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandTimeout = 900;
                cm.CommandText = "spd_GetHangHoaList_BoPhanDangSuDung";
                cm.Parameters.AddWithValue("@MaBoPhan", ((FilterCriteria_BoPhanDangSuDung)criteria).MaBoPhan);

                using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                {
                    while (dr.Read())
                        this.Add(HangHoaBQ_VT.GetHangHoaBQ_VT(dr));
                }
            }//using
        }
        private void ExecuteFetch(SqlTransaction tr, Object criteria)
        {
            int maCongTy = ERP_Library.Security.CurrentUser.Info.MaCongTy;
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandTimeout = 900;
                if (criteria is FilterCriteria)
                {
                    cm.CommandText = "spd_SelecttblHangHoasAll";
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(HangHoaBQ_VT.GetHangHoaBQ_VT(dr));
                    }
                }
                else if (criteria is FilterCriteriaByMaLoaiVatTu)
                {
                    cm.CommandText = "spd_SelecttblHangHoaByMaLoaiVatTu";
                    cm.Parameters.AddWithValue("@MaLoaiVatTu", ((FilterCriteriaByMaLoaiVatTu)criteria).MaLoaiVatTu);
                    cm.Parameters.AddWithValue("@MaCongTy", maCongTy);
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(HangHoaBQ_VT.GetHangHoaBQ_VT(dr));
                    }
                }
                else if (criteria is FilterCriteriaByMaNhomHangHoa)
                {
                    cm.CommandText = "spd_SelecttblHangHoaByMaNhomHangHoa";
                    cm.Parameters.AddWithValue("@MaNhomHangHoa", ((FilterCriteriaByMaNhomHangHoa)criteria).MaNhomHangHoa);
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(HangHoaBQ_VT.GetHangHoaBQ_VT(dr));
                    }
                }
                else if (criteria is FilterCriteriaByVatTuHangHoa)
                {
                    cm.CommandText = "spd_SelecttblHangHoaVatTu";
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(HangHoaBQ_VT.GetHangHoaBQ_VT(dr));
                    }

                }
                else if (criteria is FilterCriteriaByVatTuHangHoa_2018)
                {
                    cm.CommandText = "spd_SelecttblHangHoaVatTu_2018";
                    cm.Parameters.AddWithValue("@Ngay", ((FilterCriteriaByVatTuHangHoa_2018)criteria).Ngay);
                    cm.Parameters.AddWithValue("@MaCongTy", maCongTy);
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(HangHoaBQ_VT.GetHangHoaBQ_VT_getHH2018(dr));
                    }

                }
                else if (criteria is FilterCriteriaHangHoaCongCuDungCu)
                {
                    cm.CommandText = "spd_SelecttblHangHoaCongCuDungCu";
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(HangHoaBQ_VT.GetHangHoaBQ_VT(dr));
                    }
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
                    foreach (HangHoaBQ_VT deletedChild in DeletedList)
                        deletedChild.DeleteSelf(tr);
                    DeletedList.Clear();

                    // loop through each non-deleted child object
                    foreach (HangHoaBQ_VT child in this)
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
