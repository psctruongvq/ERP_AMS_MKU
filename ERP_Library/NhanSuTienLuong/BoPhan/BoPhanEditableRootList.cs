using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

//29/05/2013    
namespace ERP_Library
{
    [Serializable()]
    public class BoPhanList : Csla.BusinessListBase<BoPhanList, BoPhan>
    {
        #region BindingList Overrides
        protected override object AddNewCore()
        {
            BoPhan item = BoPhan.NewBoPhan();
            this.Add(item);
            return item;
        }
        #endregion //BindingList Overrides

        #region Authorization Rules

        public static bool CanGetObject()
        {
            //TODO: Define CanGetObject permission in BoPhanList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("BoPhanListViewGroup"))
            //	return true;
            //return false;
        }

        public static bool CanAddObject()
        {
            //TODO: Define CanAddObject permission in BoPhanList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("BoPhanListAddGroup"))
            //	return true;
            //return false;
        }

        public static bool CanEditObject()
        {
            //TODO: Define CanEditObject permission in BoPhanList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("BoPhanListEditGroup"))
            //	return true;
            //return false;
        }

        public static bool CanDeleteObject()
        {
            //TODO: Define CanDeleteObject permission in BoPhanList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("BoPhanListDeleteGroup"))
            //	return true;
            //return false;
        }
        #endregion //Authorization Rules

        #region Factory Methods
        private BoPhanList()
        { /* require use of factory method */ }

        public static BoPhanList NewBoPhanList()
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a BoPhanList");
            return new BoPhanList();
        }

        public static BoPhanList GetBoPhanList(int maBoPhanCha, int maLoaiBoPhan, int maCongTy)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a BoPhanList");
            return DataPortal.Fetch<BoPhanList>(new FilterCriteria(maBoPhanCha, maLoaiBoPhan, maCongTy));
        }

        public static BoPhanList GetBoPhanList()
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a BoPhanList");
            return DataPortal.Fetch<BoPhanList>(new FilterByUserID(Security.CurrentUser.Info.UserID));
        }
        /// <summary>
        /// Danh sách bộ phận có thêm dòng Tất cả, ID = 0
        /// </summary>
        /// <returns></returns>
        public static BoPhanList GetBoPhanListAll(int userID)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a BoPhanList");
            BoPhanList l = DataPortal.Fetch<BoPhanList>(new FilterByUserID(userID));
            BoPhan all = BoPhan.NewBoPhanChild();
            all.TenBoPhan = "Tất cả";
            l.Insert(0, all);
            return l;
        }
        public static BoPhanList GetBoPhanAll_New()
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a BoPhanList");
            return DataPortal.Fetch<BoPhanList>(new FilterCriteriaGetBoPhanAll_New());
        }
        public static BoPhanList GetBoPhanAll_ByMaCongTy()
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a BoPhanList");
            return DataPortal.Fetch<BoPhanList>(new FilterCriteriaMaCongTy());
        }
        public static BoPhanList GetBoPhanListByAll()
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a BoPhanList");
            return DataPortal.Fetch<BoPhanList>(new FilterCriteriaCuThuLao());
        }
        public static BoPhanList GetBoPhanListKeCaBoPhanMoRong()
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a BoPhanList");
            return DataPortal.Fetch<BoPhanList>(new FilterCriteriaKeCaBoPhanMoRong());
        }
        public static BoPhanList GetBoPhanListBy_All()
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a BoPhanList");
            return DataPortal.Fetch<BoPhanList>(new FilterCriteriaByAll());
        }
        public static BoPhanList GetBoPhanListByPhanCap(int maPhanCap)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a BoPhanList");
            return DataPortal.Fetch<BoPhanList>(new FilterCriteriaMaPhanCap(maPhanCap));
        }
        public static BoPhanList GetBoPhanList_Con(int MaPhanXuongCha)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a BoPhanList");
            return DataPortal.Fetch<BoPhanList>(new FilterCriteriaBoPhanCon(MaPhanXuongCha));
        }
        public static BoPhanList GetBoPhanListCon_LoaiBoPhan(int maBoPhanCha, int maLoaiBoPhanCon)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a BoPhanList");
            return DataPortal.Fetch<BoPhanList>(new FilterCriteriaBoPhanConLoaiBoPhan(maBoPhanCha, maLoaiBoPhanCon));
        }
        public static BoPhanList GetBoPhanList_ChaNull()
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a BoPhanList");
            return DataPortal.Fetch<BoPhanList>(new FilterCriteria3());
        }

        public static BoPhanList GetBoPhanList(int maBoPhanCha)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a BoPhanList");
            return DataPortal.Fetch<BoPhanList>(new FilterCriteriaBoPhanCon(maBoPhanCha));
        }

        public static BoPhanList GetBoPhanList_LoaiBoPhan(int maLoaiBoPhan)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a BoPhanList");
            return DataPortal.Fetch<BoPhanList>(new FilterCriteria_LoaiBoPhan(maLoaiBoPhan));
        }

        public static BoPhanList GetBoPhan(int maBoPhan)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a BoPhanList");
            return DataPortal.Fetch<BoPhanList>(new FilterCriteria4(maBoPhan));
        }
        public static BoPhanList GetBoPhan(string maBoPhanChuoi)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a BoPhanList");
            return DataPortal.Fetch<BoPhanList>(new FilterCriteriaChuoiMa(maBoPhanChuoi));
        }
        public static BoPhanList GetBoPhanListForLinhNhienLieu()//M
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a BoPhanList");
            return DataPortal.Fetch<BoPhanList>(new FilterForLinhNhienLieu());
        }
        public static BoPhanList GetDSTruong()
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a BoPhanList");
            return DataPortal.Fetch<BoPhanList>(new FilterCriteriaDSTruong());
        }

        #endregion //Factory Methods

        public static BoPhanList DanhSachBoPhanTinhLuong()
        {
            return DataPortal.Fetch<BoPhanList>(new FilterTinhLuong());
        }
        public static BoPhanList GetBoPhanListByMaCongTy(int MaCongTy)
        {
            return DataPortal.Fetch<BoPhanList>(new FilterMaCongTy(MaCongTy));
        }
        public static BoPhanList GetBoPhanListByMaBoPhanChaNotNull()
        {
            return DataPortal.Fetch<BoPhanList>(new FilterByMaBoPhanChaNotNull());
        }

        public static BoPhanList GetBoPhanListByUserID(int userID)
        {
            return DataPortal.Fetch<BoPhanList>(new FilterByUserID(userID));
        }
        #region Data Access

        #region Filter Criteria
        [Serializable()]
        private class FilterCriteriaMaCongTy
        {
            public FilterCriteriaMaCongTy()
            {
            }
        }
        [Serializable()]
        private class FilterCriteriaGetBoPhanAll_New
        {
            public FilterCriteriaGetBoPhanAll_New()
            {
            }
        }

        [Serializable()]
        private class FilterByMaBoPhanChaNotNull
        {
            public FilterByMaBoPhanChaNotNull()
            {
            }
        }
        [Serializable()]
        private class FilterCriteria
        {
            public int MaBoPhanCha;
            public int MaLoaiBoPhan;
            public int MaCongTy;

            public FilterCriteria(int maBoPhanCha, int maLoaiBoPhan, int maCongTy)
            {
                this.MaBoPhanCha = maBoPhanCha;
                this.MaLoaiBoPhan = maLoaiBoPhan;
                this.MaCongTy = maCongTy;
            }
        }

        [Serializable()]
        private class FilterCriteria_LoaiBoPhan
        {
            public int MaLoaiBoPhan;

            public FilterCriteria_LoaiBoPhan(int maLoaiBoPhan)
            {
                this.MaLoaiBoPhan = maLoaiBoPhan;
            }
        }
        [Serializable()]
        private class FilterCriteriaByAll
        {
            public FilterCriteriaByAll()
            {

            }
        }
        [Serializable()]
        private class FilterCriteriaKeCaBoPhanMoRong
        {
            public FilterCriteriaKeCaBoPhanMoRong()
            {

            }
        }
        [Serializable()]
        private class FilterCriteriaBoPhanCon
        {
            public int MaBoPhanCha;
            public FilterCriteriaBoPhanCon(int maBoPhanCha)
            {
                this.MaBoPhanCha = maBoPhanCha;
            }
        }
        [Serializable()]
        private class FilterCriteriaBoPhanConLoaiBoPhan
        {
            public int MaBoPhanCha;
            public int MaLoaiBoPhan;
            public FilterCriteriaBoPhanConLoaiBoPhan(int maBoPhanCha, int maLoaiBoPhan)
            {
                this.MaBoPhanCha = maBoPhanCha;
                this.MaLoaiBoPhan = maLoaiBoPhan;
            }
        }
        [Serializable()]
        private class FilterCriteriaMaPhanCap
        {
            public int MaPhanCap;
            public FilterCriteriaMaPhanCap(int MaPhanCap)
            {
                this.MaPhanCap = MaPhanCap;
            }
        }

        [Serializable()]
        private class FilterCriteriaCuThuLao
        {
            public FilterCriteriaCuThuLao()
            {
            }
        }
        [Serializable()]
        private class FilterCriteria4
        {

            public int maBoPhan;
            public FilterCriteria4(int maBoPhan)
            {
                this.maBoPhan = maBoPhan;
            }

        }
        [Serializable()]
        private class FilterCriteriaChuoiMa
        {

            public string chuoimaBoPhan;
            public FilterCriteriaChuoiMa(string maBoPhan)
            {
                this.chuoimaBoPhan = maBoPhan;
            }

        }
        [Serializable()]
        private class FilterCriteria3
        {
            public FilterCriteria3()
            {

            }
        }
        [Serializable()]
        private class FilterTinhLuong
        {
        }

        [Serializable()]
        private class FilterByUserID
        {
            public int userID;
            public FilterByUserID(int userid)
            {
                userID = userid;
            }
        }

        [Serializable()]
        private class FilterMaCongTy
        {
            public int MaCongTy;
            public FilterMaCongTy(int maCongTy)
            {
                MaCongTy = maCongTy;
            }
        }
        [Serializable()]
        private class FilterByUsers
        {
            public FilterByUsers()
            {
            }
        }
        [Serializable()]
        private class FilterCriteriaDSTruong
        {

            public FilterCriteriaDSTruong()
            {

            }
        }
        [Serializable()]
        private class FilterForLinhNhienLieu//M
        {
            public FilterForLinhNhienLieu()
            {
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
                if (criteria is FilterCriteriaMaCongTy)
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_tblnsBoPhan_GetBoPhanAll_ByMaCongTy";
                    cm.Parameters.AddWithValue("@MaCongTy", Security.CurrentUser.Info.MaCongTy);                 
                    cm.Parameters.AddWithValue("@UserID", Security.CurrentUser.Info.UserID);
                }
               else if (criteria is FilterCriteriaCuThuLao)
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "sp_SelecttblnsBoPhansAll";
                }
               else if (criteria is FilterCriteriaGetBoPhanAll_New)
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_tblnsBoPhan_GetBoPhanAll_New";
                }
                else if (criteria is FilterTinhLuong)
                {
                    cm.CommandType = CommandType.Text;
                    cm.CommandText = "Select * From tblnsBoPhan Where KhongTinhLuong=0";
                }
                else if (criteria is FilterCriteriaByAll)
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_SelecttblnsBoPhanByUserID ";
                    cm.Parameters.AddWithValue("@UserID", Security.CurrentUser.Info.UserID);
                }
                else if (criteria is FilterCriteriaKeCaBoPhanMoRong)
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_LayDSBoPhanKeCaBoPhanMoRong";
                }
                else if (criteria is FilterByMaBoPhanChaNotNull)
                {
                    cm.CommandType = CommandType.Text;
                    cm.CommandText = "Select * From tblnsBoPhan where MaBoPhanCha is not null ";
                }

                else if (criteria is FilterByUserID)
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_SelecttblnsBoPhanByUserID";
                    cm.Parameters.AddWithValue("@UserID", ((FilterByUserID)criteria).userID);
                }
                else if (criteria is FilterForLinhNhienLieu)//M
                { 
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "SelectBoPhanForLinhNhienLieu";
                }
                else if (criteria is FilterCriteriaBoPhanCon)
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "sp_SelecttblnsBoPhan_MaCha";
                    cm.Parameters.AddWithValue("@MaBoPhanCha", ((FilterCriteriaBoPhanCon)criteria).MaBoPhanCha);
                }
                else if (criteria is FilterCriteriaBoPhanConLoaiBoPhan)
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "sp_SelecttblnsBoPhan_MaChaLoaiBoPhan";
                    cm.Parameters.AddWithValue("@MaBoPhanCha", ((FilterCriteriaBoPhanConLoaiBoPhan)criteria).MaBoPhanCha);
                    cm.Parameters.AddWithValue("@MaLoaiBoPhan", ((FilterCriteriaBoPhanConLoaiBoPhan)criteria).MaLoaiBoPhan);
                }
                else if (criteria is FilterCriteria)
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "sp_SelecttblnsBoPhan";
                    cm.Parameters.AddWithValue("@MaBoPhanCha", ((FilterCriteria)criteria).MaBoPhanCha);
                    cm.Parameters.AddWithValue("@MaLoaiBoPhan", ((FilterCriteria)criteria).MaLoaiBoPhan);
                    cm.Parameters.AddWithValue("@MaCongTy", ((FilterCriteria)criteria).MaCongTy);

                }
                else if (criteria is FilterCriteria_LoaiBoPhan)
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_LayBoPhanTheoLoai";
                    cm.Parameters.AddWithValue("@MaLoaiBoPhan", ((FilterCriteria_LoaiBoPhan)criteria).MaLoaiBoPhan);
                }
                else if (criteria is FilterCriteria3)
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "sp_SelecttblnsBoPhan_MaChaNull";
                }
                else if (criteria is FilterCriteria4)
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "sp_SelecttblnsBoPhan";
                    cm.Parameters.AddWithValue("@MaBoPhan", ((FilterCriteria4)criteria).maBoPhan);
                }
                else if (criteria is FilterCriteriaChuoiMa)
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_TimBoPhan";
                    cm.Parameters.AddWithValue("@MaBoPhan", ((FilterCriteriaChuoiMa)criteria).chuoimaBoPhan);

                }
                else if (criteria is FilterCriteriaMaPhanCap)
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "sp_SelecttblnsBoPhanMaPhanCap";
                    cm.Parameters.AddWithValue("@MaPhanCap", ((FilterCriteriaMaPhanCap)criteria).MaPhanCap);
                }
                else if (criteria is FilterMaCongTy)
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "sp_Select_BoPhanByMaCongTy";
                    cm.Parameters.AddWithValue("@MaCongTy", (criteria as FilterMaCongTy).MaCongTy);
                }

                else if (criteria is FilterByUsers)
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "sp_Select_BoPhanByUser";
                    cm.Parameters.AddWithValue("@UserID", ERP_Library.Security.CurrentUser.Info.UserID);
                }
                else if (criteria is FilterCriteriaDSTruong)
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_LayDSTruong";
                }
                try
                {
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(BoPhan.GetBoPhan(dr));
                    }
                }
                catch (Exception ex)
                { throw ex; }
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
                foreach (BoPhan deletedChild in DeletedList)
                    deletedChild.DeleteSelf(cn);
                DeletedList.Clear();

                // loop through each non-deleted child object
                foreach (BoPhan child in this)
                {
                    if (child.IsNew)
                        child.Insert(cn, this);
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
