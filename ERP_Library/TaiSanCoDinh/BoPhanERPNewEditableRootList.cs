#region remove
using System.Collections;
//29/05/2013    
//namespace ERP_Library
//{
//    [Serializable()]
//    public class BoPhanERPNewList : Csla.BusinessListBase<BoPhanERPNewList, BoPhanERPNew>
//    {
//        #region BindingList Overrides
//        protected override object AddNewCore()
//        {
//            BoPhanERPNew item = BoPhanERPNew.NewBoPhanERPNew();
//            this.Add(item);
//            return item;
//        }
//        #endregion //BindingList Overrides

//        #region Authorization Rules

//        public static bool CanGetObject()
//        {
//            //TODO: Define CanGetObject permission in BoPhanERPNewList
//            return true;
//            //if (Csla.ApplicationContext.User.IsInRole("BoPhanERPNewListViewGroup"))
//            //	return true;
//            //return false;
//        }

//        public static bool CanAddObject()
//        {
//            //TODO: Define CanAddObject permission in BoPhanERPNewList
//            return true;
//            //if (Csla.ApplicationContext.User.IsInRole("BoPhanERPNewListAddGroup"))
//            //	return true;
//            //return false;
//        }

//        public static bool CanEditObject()
//        {
//            //TODO: Define CanEditObject permission in BoPhanERPNewList
//            return true;
//            //if (Csla.ApplicationContext.User.IsInRole("BoPhanERPNewListEditGroup"))
//            //	return true;
//            //return false;
//        }

//        public static bool CanDeleteObject()
//        {
//            //TODO: Define CanDeleteObject permission in BoPhanERPNewList
//            return true;
//            //if (Csla.ApplicationContext.User.IsInRole("BoPhanERPNewListDeleteGroup"))
//            //	return true;
//            //return false;
//        }
//        #endregion //Authorization Rules

//        #region Factory Methods
//        private BoPhanERPNewList()
//        { /* require use of factory method */ }

//        public static BoPhanERPNewList NewBoPhanERPNewList()
//        {
//            if (!CanAddObject())
//                throw new System.Security.SecurityException("User not authorized to add a BoPhanERPNewList");
//            return new BoPhanERPNewList();
//        }

//        public static BoPhanERPNewList GetBoPhanERPNewList(int maBoPhanERPNewCha, int maLoaiBoPhanERPNew, int maCongTy)
//        {
//            if (!CanGetObject())
//                throw new System.Security.SecurityException("User not authorized to view a BoPhanERPNewList");
//            return DataPortal.Fetch<BoPhanERPNewList>(new FilterCriteria(maBoPhanERPNewCha, maLoaiBoPhanERPNew, maCongTy));
//        }

//        public static BoPhanERPNewList GetBoPhanERPNewList()
//        {
//            if (!CanGetObject())
//                throw new System.Security.SecurityException("User not authorized to view a BoPhanERPNewList");
//            return DataPortal.Fetch<BoPhanERPNewList>(new FilterByUserID());
//        }
//        /// <summary>
//        /// Danh sách bộ phận có thêm dòng Tất cả, ID = 0
//        /// </summary>
//        /// <returns></returns>
//        public static BoPhanERPNewList GetBoPhanERPNewListAll() //có xài 
//        {
//            if (!CanGetObject())
//                throw new System.Security.SecurityException("User not authorized to view a BoPhanERPNewList");
//            ERP_Library.BoPhanERPNewList l = DataPortal.Fetch<BoPhanERPNewList>(new FilterByUserID());
//            BoPhanERPNew all = BoPhanERPNew.NewBoPhanERPNewChild();
//            all.TenBoPhan = "Không chọn";
//            l.Insert(0, all);
//            return l;
//        }
//        public static BoPhanERPNewList GetBoPhanERPNewListByAll()
//        {
//            if (!CanGetObject())
//                throw new System.Security.SecurityException("User not authorized to view a BoPhanERPNewList");
//            return DataPortal.Fetch<BoPhanERPNewList>(new FilterCriteriaCuThuLao());
//        }
//        public static BoPhanERPNewList GetBoPhanERPNewListKeCaBoPhanERPNewMoRong()
//        {
//            if (!CanGetObject())
//                throw new System.Security.SecurityException("User not authorized to view a BoPhanERPNewList");
//            return DataPortal.Fetch<BoPhanERPNewList>(new FilterCriteriaKeCaBoPhanERPNewMoRong());
//        }
//        public static BoPhanERPNewList GetBoPhanERPNewListBy_All()
//        {
//            if (!CanGetObject())
//                throw new System.Security.SecurityException("User not authorized to view a BoPhanERPNewList");
//            return DataPortal.Fetch<BoPhanERPNewList>(new FilterCriteriaByAll());
//        }
//        public static BoPhanERPNewList GetBoPhanERPNewListByPhanCap(int maPhanCap)
//        {
//            if (!CanGetObject())
//                throw new System.Security.SecurityException("User not authorized to view a BoPhanERPNewList");
//            return DataPortal.Fetch<BoPhanERPNewList>(new FilterCriteriaMaPhanCap(maPhanCap));
//        }
//        public static BoPhanERPNewList GetBoPhanERPNewList_Con(int MaPhanXuongCha)
//        {
//            if (!CanGetObject())
//                throw new System.Security.SecurityException("User not authorized to view a BoPhanERPNewList");
//            return DataPortal.Fetch<BoPhanERPNewList>(new FilterCriteriaBoPhanERPNewCon(MaPhanXuongCha));
//        }
//        public static BoPhanERPNewList GetBoPhanERPNewListCon_LoaiBoPhanERPNew(int maBoPhanERPNewCha, int maLoaiBoPhanERPNewCon)
//        {
//            if (!CanGetObject())
//                throw new System.Security.SecurityException("User not authorized to view a BoPhanERPNewList");
//            return DataPortal.Fetch<BoPhanERPNewList>(new FilterCriteriaBoPhanERPNewConLoaiBoPhanERPNew(maBoPhanERPNewCha, maLoaiBoPhanERPNewCon));
//        }
//        public static BoPhanERPNewList GetBoPhanERPNewList_ChaNull()
//        {
//            if (!CanGetObject())
//                throw new System.Security.SecurityException("User not authorized to view a BoPhanERPNewList");
//            return DataPortal.Fetch<BoPhanERPNewList>(new FilterCriteria3());
//        }

//        public static BoPhanERPNewList GetBoPhanERPNewList(int maBoPhanERPNewCha)
//        {
//            if (!CanGetObject())
//                throw new System.Security.SecurityException("User not authorized to view a BoPhanERPNewList");
//            return DataPortal.Fetch<BoPhanERPNewList>(new FilterCriteriaBoPhanERPNewCon(maBoPhanERPNewCha));
//        }

//        public static BoPhanERPNewList GetBoPhanERPNewList_LoaiBoPhanERPNew(int maLoaiBoPhanERPNew)
//        {
//            if (!CanGetObject())
//                throw new System.Security.SecurityException("User not authorized to view a BoPhanERPNewList");
//            return DataPortal.Fetch<BoPhanERPNewList>(new FilterCriteria_LoaiBoPhanERPNew(maLoaiBoPhanERPNew));
//        }

//        public static BoPhanERPNewList GetBoPhanERPNew(int maBoPhanERPNew)
//        {
//            if (!CanGetObject())
//                throw new System.Security.SecurityException("User not authorized to view a BoPhanERPNewList");
//            return DataPortal.Fetch<BoPhanERPNewList>(new FilterCriteria4(maBoPhanERPNew));
//        }
//        public static BoPhanERPNewList GetBoPhanERPNew(string maBoPhanERPNewChuoi)
//        {
//            if (!CanGetObject())
//                throw new System.Security.SecurityException("User not authorized to view a BoPhanERPNewList");
//            return DataPortal.Fetch<BoPhanERPNewList>(new FilterCriteriaChuoiMa(maBoPhanERPNewChuoi));
//        }
//        public static BoPhanERPNewList GetBoPhanERPNewListForLinhNhienLieu()//M
//        {
//            if (!CanGetObject())
//                throw new System.Security.SecurityException("User not authorized to view a BoPhanERPNewList");
//            return DataPortal.Fetch<BoPhanERPNewList>(new FilterForLinhNhienLieu());
//        }

//        #endregion //Factory Methods

//        public static BoPhanERPNewList DanhSachBoPhanERPNewTinhLuong()
//        {
//            return DataPortal.Fetch<BoPhanERPNewList>(new FilterTinhLuong());
//        }
//        public static BoPhanERPNewList GetBoPhanERPNewListByMaCongTy(int MaCongTy)
//        {
//            return DataPortal.Fetch<BoPhanERPNewList>(new FilterMaCongTy(MaCongTy));
//        }
//        public static BoPhanERPNewList GetBoPhanERPNewListByMaBoPhanERPNewChaNotNull()
//        {
//            return DataPortal.Fetch<BoPhanERPNewList>(new FilterByMaBoPhanERPNewChaNotNull());
//        }

//        public static BoPhanERPNewList GetBoPhanERPNewListByUserID()
//        {
//            return DataPortal.Fetch<BoPhanERPNewList>(new FilterByUserID());
//        }
//        #region Data Access

//        #region Filter Criteria
//        [Serializable()]
//        private class FilterByMaBoPhanERPNewChaNotNull
//        {            public FilterByMaBoPhanERPNewChaNotNull()
//            {

//            }
//        }
//        private class FilterCriteria
//        {
//            public int MaBoPhanERPNewCha;
//            public int MaLoaiBoPhanERPNew;
//            public int MaCongTy;

//            public FilterCriteria(int maBoPhanERPNewCha, int maLoaiBoPhanERPNew, int maCongTy)
//            {
//                this.MaBoPhanERPNewCha = maBoPhanERPNewCha;
//                this.MaLoaiBoPhanERPNew = maLoaiBoPhanERPNew;
//                this.MaCongTy = maCongTy;
//            }
//        }

//        [Serializable()]

//        private class FilterCriteria_LoaiBoPhanERPNew
//        {
//            public int MaLoaiBoPhanERPNew;

//            public FilterCriteria_LoaiBoPhanERPNew(int maLoaiBoPhanERPNew)
//            {
//                this.MaLoaiBoPhanERPNew = maLoaiBoPhanERPNew;
//            }
//        }
//        private class FilterCriteriaByAll
//        {
//            public FilterCriteriaByAll()
//            {

//            }
//        }
//        private class FilterCriteriaKeCaBoPhanERPNewMoRong
//        {
//            public FilterCriteriaKeCaBoPhanERPNewMoRong()
//            {

//            }
//        }
//        [Serializable()]
//        private class FilterCriteriaBoPhanERPNewCon
//        {
//            public int MaBoPhanERPNewCha;
//            public FilterCriteriaBoPhanERPNewCon(int maBoPhanERPNewCha)
//            {
//                this.MaBoPhanERPNewCha = maBoPhanERPNewCha;
//            }
//        }
//        private class FilterCriteriaBoPhanERPNewConLoaiBoPhanERPNew
//        {
//            public int MaBoPhanERPNewCha;
//            public int MaLoaiBoPhanERPNew;
//            public FilterCriteriaBoPhanERPNewConLoaiBoPhanERPNew(int maBoPhanERPNewCha, int maLoaiBoPhanERPNew)
//            {
//                this.MaBoPhanERPNewCha = maBoPhanERPNewCha;
//                this.MaLoaiBoPhanERPNew = maLoaiBoPhanERPNew;
//            }
//        }

//        private class FilterCriteriaMaPhanCap
//        {
//            public int MaPhanCap;
//            public FilterCriteriaMaPhanCap(int MaPhanCap)
//            {
//                this.MaPhanCap = MaPhanCap;
//            }
//        }

//        [Serializable()]
//        private class FilterCriteriaCuThuLao
//        {
//            public FilterCriteriaCuThuLao()
//            {
//            }
//        }
//        [Serializable()]
//        private class FilterCriteria4
//        {

//            public int maBoPhanERPNew;
//            public FilterCriteria4(int maBoPhanERPNew)
//            {
//                this.maBoPhanERPNew = maBoPhanERPNew;
//            }

//        }
//        [Serializable()]
//        private class FilterCriteriaChuoiMa
//        {

//            public string chuoimaBoPhanERPNew;
//            public FilterCriteriaChuoiMa(string maBoPhanERPNew)
//            {
//                this.chuoimaBoPhanERPNew = maBoPhanERPNew;
//            }

//        }
//        [Serializable()]
//        private class FilterCriteria3
//        {
//            public FilterCriteria3()
//            {

//            }
//        }
//        [Serializable()]
//        private class FilterTinhLuong
//        {
//        }

//        [Serializable()]
//        private class FilterByUserID
//        {
//        }

//        [Serializable()]
//        private class FilterMaCongTy
//        {
//            public int MaCongTy;
//            public FilterMaCongTy(int maCongTy)
//            {
//                MaCongTy = maCongTy;
//            }
//        }
//        [Serializable()]
//        private class FilterByUsers
//        {

//            public FilterByUsers()
//            {

//            }
//        }
//        private class FilterForLinhNhienLieu//M
//        {
//            public FilterForLinhNhienLieu()
//            {
//            }
//        }
//        #endregion //Filter Criteria

//        #region Data Access - Fetch
//        private void DataPortal_Fetch(Object criteria)
//        {
//            RaiseListChangedEvents = false;

//            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
//            {
//                cn.Open();

//                ExecuteFetch(cn, criteria);
//            }//using

//            RaiseListChangedEvents = true;
//        }

//        private void ExecuteFetch(SqlConnection cn, Object criteria)
//        {
//            using (SqlCommand cm = cn.CreateCommand())
//            {

//                if (criteria is FilterCriteriaCuThuLao)
//                {
//                    cm.CommandType = CommandType.StoredProcedure;
//                    cm.CommandText = "sp_SelecttblnsBoPhanERPNewsAll";
//                }
//                else if (criteria is FilterTinhLuong)
//                {
//                    cm.CommandType = CommandType.Text;
//                    cm.CommandText = "Select * From tblnsBoPhanERPNew Where KhongTinhLuong=0";
//                }
//                else if (criteria is FilterCriteriaByAll)
//                {
//                    cm.CommandType = CommandType.StoredProcedure;
//                    cm.CommandText = "spd_SelecttblnsBoPhanERPNewByUserID ";
//                    cm.Parameters.AddWithValue("@UserID", Security.CurrentUser.Info.UserID);
//                }
//                else if (criteria is FilterCriteriaKeCaBoPhanERPNewMoRong)
//                {
//                    cm.CommandType = CommandType.StoredProcedure;
//                    cm.CommandText = "spd_LayDSBoPhanERPNewKeCaBoPhanERPNewMoRong";
//                }
//                else if (criteria is FilterByMaBoPhanERPNewChaNotNull)
//                {
//                    cm.CommandType = CommandType.Text;
//                    cm.CommandText = "Select * From tblnsBoPhanERPNew where MaBoPhanERPNewCha is not null ";
//                }

//                else if (criteria is FilterByUserID)
//                {
//                    cm.CommandType = CommandType.StoredProcedure;
//                    cm.CommandText = "spd_SelecttblnsBoPhanERPNewByUserID";
//                    //cm.CommandType = CommandType.Text;
//                    //cm.CommandText = "Select A.* From tblnsBoPhanERPNew A Where A.MaBoPhanERPNewCha is not null and A.MaBoPhanERPNew In (Select MaBoPhanERPNew From app_UserBoPhanERPNew Where UserID = @UserID AND SuDung=1) Order by A.MaBoPhanERPNewQL, A.TenBoPhanERPNew";
//                    cm.Parameters.AddWithValue("@UserID", Security.CurrentUser.Info.UserID);
//                }
//                else if (criteria is FilterForLinhNhienLieu)//M
//                { 
//                    //cm.CommandType = CommandType.Text;
//                    //cm.CommandText = "SELECT * FROM dbo.tblnsBoPhanERPNew WHERE MaBoPhanERPNew IN (10,23)";
//                    cm.CommandType = CommandType.StoredProcedure;
//                    cm.CommandText = "SelectBoPhanERPNewForLinhNhienLieu";
//                }
//                else if (criteria is FilterCriteriaBoPhanERPNewCon)
//                {
//                    cm.CommandType = CommandType.StoredProcedure;
//                    cm.CommandText = "sp_SelecttblnsBoPhanERPNew_MaCha";
//                    cm.Parameters.AddWithValue("@MaBoPhanERPNewCha", ((FilterCriteriaBoPhanERPNewCon)criteria).MaBoPhanERPNewCha);
//                }
//                else if (criteria is FilterCriteriaBoPhanERPNewConLoaiBoPhanERPNew)
//                {
//                    cm.CommandType = CommandType.StoredProcedure;
//                    cm.CommandText = "sp_SelecttblnsBoPhanERPNew_MaChaLoaiBoPhanERPNew";
//                    cm.Parameters.AddWithValue("@MaBoPhanERPNewCha", ((FilterCriteriaBoPhanERPNewConLoaiBoPhanERPNew)criteria).MaBoPhanERPNewCha);
//                    cm.Parameters.AddWithValue("@MaLoaiBoPhanERPNew", ((FilterCriteriaBoPhanERPNewConLoaiBoPhanERPNew)criteria).MaLoaiBoPhanERPNew);
//                }
//                else if (criteria is FilterCriteria)
//                {
//                    cm.CommandType = CommandType.StoredProcedure;
//                    cm.CommandText = "sp_SelecttblnsBoPhanERPNew";
//                    cm.Parameters.AddWithValue("@MaBoPhanERPNewCha", ((FilterCriteria)criteria).MaBoPhanERPNewCha);
//                    cm.Parameters.AddWithValue("@MaLoaiBoPhanERPNew", ((FilterCriteria)criteria).MaLoaiBoPhanERPNew);
//                    cm.Parameters.AddWithValue("@MaCongTy", ((FilterCriteria)criteria).MaCongTy);

//                }
//                else if (criteria is FilterCriteria_LoaiBoPhanERPNew)
//                {
//                    cm.CommandType = CommandType.StoredProcedure;
//                    cm.CommandText = "spd_LayBoPhanERPNewTheoLoai";
//                    cm.Parameters.AddWithValue("@MaLoaiBoPhanERPNew", ((FilterCriteria_LoaiBoPhanERPNew)criteria).MaLoaiBoPhanERPNew);
//                }
//                else if (criteria is FilterCriteria3)
//                {
//                    cm.CommandType = CommandType.StoredProcedure;
//                    cm.CommandText = "sp_SelecttblnsBoPhanERPNew_MaChaNull";
//                }
//                else if (criteria is FilterCriteria4)
//                {
//                    cm.CommandType = CommandType.StoredProcedure;
//                    cm.CommandText = "sp_SelecttblnsBoPhanERPNew";
//                    cm.Parameters.AddWithValue("@MaBoPhanERPNew", ((FilterCriteria4)criteria).maBoPhanERPNew);
//                }
//                else if (criteria is FilterCriteriaChuoiMa)
//                {
//                    cm.CommandType = CommandType.StoredProcedure;
//                    cm.CommandText = "spd_TimBoPhanERPNew";
//                    cm.Parameters.AddWithValue("@MaBoPhanERPNew", ((FilterCriteriaChuoiMa)criteria).chuoimaBoPhanERPNew);

//                }
//                else if (criteria is FilterCriteriaMaPhanCap)
//                {
//                    cm.CommandType = CommandType.StoredProcedure;
//                    cm.CommandText = "sp_SelecttblnsBoPhanERPNewMaPhanCap";
//                    cm.Parameters.AddWithValue("@MaPhanCap", ((FilterCriteriaMaPhanCap)criteria).MaPhanCap);
//                }
//                else if (criteria is FilterMaCongTy)
//                {
//                    cm.CommandType = CommandType.StoredProcedure;
//                    cm.CommandText = "sp_Select_BoPhanERPNewByMaCongTy";
//                    cm.Parameters.AddWithValue("@MaCongTy", (criteria as FilterMaCongTy).MaCongTy);
//                }

//                else if (criteria is FilterByUsers)
//                {
//                    cm.CommandType = CommandType.StoredProcedure;
//                    cm.CommandText = "sp_Select_BoPhanERPNewByUser";
//                    cm.Parameters.AddWithValue("@UserID", ERP_Library.Security.CurrentUser.Info.UserID);
//                }
//                try
//                {
//                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
//                    {
//                        while (dr.Read())
//                            this.Add(BoPhanERPNew.GetBoPhanERPNew(dr));
//                    }
//                }
//                catch (Exception ex)
//                { throw ex; }
//            }//using
//        }
//        #endregion //Data Access - Fetch


//        #region Data Access - Update
//        protected override void DataPortal_Update()
//        {
//            RaiseListChangedEvents = false;

//            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
//            {
//                cn.Open();

//                // loop through each deleted child object
//                foreach (BoPhanERPNew deletedChild in DeletedList)
//                    deletedChild.DeleteSelf(cn);
//                DeletedList.Clear();

//                // loop through each non-deleted child object
//                foreach (BoPhanERPNew child in this)
//                {
//                    if (child.IsNew)
//                        child.Insert(cn, this);
//                    else
//                        child.Update(cn, this);
//                }
//            }//using SqlConnection

//            RaiseListChangedEvents = true;
//        }
//        #endregion //Data Access - Update
//        #endregion //Data Access
//    }
//}
#endregion

using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using System.Linq;

namespace ERP_Library
{
    [Serializable()]
    public class BoPhanERPNewList : Csla.BusinessListBase<BoPhanERPNewList, BoPhanERPNew>
    {
        #region BindingList Overrides
        protected override object AddNewCore()
        {
            BoPhanERPNew item = BoPhanERPNew.NewBoPhanERPNew();
            this.Add(item);
            return item;
        }
        #endregion //BindingList Overrides

        #region Authorization Rules

        public static bool CanGetObject()
        {
            //TODO: Define CanGetObject permission in BoPhanERPNewList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("BoPhanERPNewListViewGroup"))
            //	return true;
            //return false;
        }

        public static bool CanAddObject()
        {
            //TODO: Define CanAddObject permission in BoPhanERPNewList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("BoPhanERPNewListAddGroup"))
            //	return true;
            //return false;
        }

        public static bool CanEditObject()
        {
            //TODO: Define CanEditObject permission in BoPhanERPNewList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("BoPhanERPNewListEditGroup"))
            //	return true;
            //return false;
        }

        public static bool CanDeleteObject()
        {
            //TODO: Define CanDeleteObject permission in BoPhanERPNewList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("BoPhanERPNewListDeleteGroup"))
            //	return true;
            //return false;
        }
        #endregion //Authorization Rules

        #region Factory Methods
        private BoPhanERPNewList()
        { /* require use of factory method */ }

        public static BoPhanERPNewList NewBoPhanERPNewList()
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a BoPhanERPNewList");
            return new BoPhanERPNewList();
        }

        public static BoPhanERPNewList GetBoPhanERPNewList()
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a BoPhanERPNewList");
            return DataPortal.Fetch<BoPhanERPNewList>(new FilterCriteria());
        }
        public static BoPhanERPNewList GetBoPhanERPNewListAll() //có xài 
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a BoPhanERPNewList");     
            return DataPortal.Fetch<BoPhanERPNewList>(new FilterByUserID());
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
        [Serializable()]
        private class FilterByUserID
        {
            public FilterByUserID()
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

        private void ExecuteFetch(SqlTransaction tr, object criteria)
        { 
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                if (criteria is FilterCriteria)
                {
                    cm.Transaction = tr;
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_tblnsBoPhanERPNew_GetALL";
                }
                else if (criteria is FilterByUserID) //co xài 
                {
                    cm.Transaction = tr;
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_SelecttblnsBoPhanERPNewByUserID";
                    cm.Parameters.AddWithValue("@UserID", Security.CurrentUser.Info.UserID);
                 }
               

                using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                {
                    while (dr.Read())
                        this.Add(BoPhanERPNew.GetBoPhanERPNew(dr));
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
                    foreach (BoPhanERPNew deletedChild in DeletedList)
                        deletedChild.DeleteSelf(tr);
                    DeletedList.Clear();

                    // loop through each non-deleted child object
                    foreach (BoPhanERPNew child in this)
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

        #region function
        public static int GetMaBoPhanByMaBoPhanQL(BoPhanERPNewList boPhanERPNewList, string maBoPhanQL)
        {
            return boPhanERPNewList.Single(o => o.MaBoPhanQL == maBoPhanQL).MaBoPhan;
        }
        public static bool KiemTraBoPhanERPNewTonTai(BoPhanERPNewList boPhanERPNewList,string MaBoPhanQLImport)
        {
            return boPhanERPNewList.Any(o => o.MaBoPhanQL == MaBoPhanQLImport);
        }
        public static string[] SwapProperties(string Properties, string PropertiesOld)
        {
            string temp = Properties;
            PropertiesOld = Properties;
            Properties = temp;
            return new string[] { Properties, PropertiesOld };
        }     
        #endregion
    }
}
