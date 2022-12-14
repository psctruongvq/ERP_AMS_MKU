using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library.Security
{
    [Serializable()]
    public class UserList : Csla.BusinessListBase<UserList, UserItem>
    {
        #region BindingList Overrides
        private int iddef = -1;
        protected override object AddNewCore()
        {
            UserItem item = UserItem.NewUserItemChild();
            item._userID = iddef--;
            this.Add(item);
            return item;
        }
        #endregion //BindingList Overrides

        #region Factory Methods
        private UserList()
        { /* require use of factory method */ }


        public static UserList NewUserList()
        {
            return new UserList();
        }

        public static UserList GetUserList()
        {
            return DataPortal.Fetch<UserList>(new FilterCriteria());
        }
        public static UserList GetUserListChooseChild(bool boPhanChild, bool phuCapChild, bool thulaoChild, bool userChildListChild)
        {
            return DataPortal.Fetch<UserList>(new FilterCriteriaChooseChild(boPhanChild,  phuCapChild,  thulaoChild,  userChildListChild));
        }
        public static UserList GetUserList_GBC()
        {
            return DataPortal.Fetch<UserList>(new FilterCriteriaAll_ForGiayNhanNo());
        }

        public static UserList GetUserList( int maBoPhan)
        {
            return DataPortal.Fetch<UserList>(new FilterCriteriaBoPhan(maBoPhan));
        }
        public static UserList GetUserKeToanTapDoan(int groupID, int maCongTy)
        {
            return DataPortal.Fetch<UserList>(new FilterCriteriaKeToanTapDoan(groupID, maCongTy));
        }
        /// <summary>
        /// Danh sách những users chưa được phân quyền kỳ kế toán
        /// </summary>
        /// <param name="maKy"></param>
        /// <returns></returns>
        public static UserList GetUserListChuaPhanQuyenKyKeToan(int maKy)
        {
            return DataPortal.Fetch<UserList>(new FilterCriteriaChuaPhanQuyenKyKeToan(maKy));
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
        private class FilterCriteriaChooseChild
        {
            public bool boPhanChild, phuCapChild, thulaoChild, userChildListChild;
            public FilterCriteriaChooseChild(bool boPhanChild, bool phuCapChild, bool thulaoChild, bool userChildListChild)
            {
                this.boPhanChild = boPhanChild;
                this.phuCapChild = phuCapChild;
                this.thulaoChild = thulaoChild;
                this.userChildListChild = userChildListChild;
            }
        }
        [Serializable()]
        private class FilterCriteriaAll_ForGiayNhanNo
        {
            public FilterCriteriaAll_ForGiayNhanNo()
            {
            }
        }
        [Serializable()]
        private class FilterCriteriaChuaPhanQuyenKyKeToan
        {
            public int MaKy;
            public FilterCriteriaChuaPhanQuyenKyKeToan(int maKy)
            {
                this.MaKy = maKy;
            }
        }
        [Serializable()]
        private class FilterCriteriaBoPhan
        {
            public int MaBoPhan;
            public FilterCriteriaBoPhan(int maBoPhan)
            {
                this.MaBoPhan = maBoPhan;
            }
        }
        [Serializable()]
        private class FilterCriteriaKeToanTapDoan
        {
            public int GroupID;
            public int MaCongTy;
            public FilterCriteriaKeToanTapDoan(int groupID, int maCongTy)
            {
                this.GroupID = groupID;
                this.MaCongTy = maCongTy;
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
                if (criteria is FilterCriteria)
                {
                    cm.CommandText = "app_Select_UserList";
                }
               else if (criteria is FilterCriteriaChooseChild)
                {
                    cm.CommandText = "app_Select_UserList";
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(UserItem.GetUserItemChooseChild(dr, tr,
                                ((FilterCriteriaChooseChild)criteria).boPhanChild,
                                ((FilterCriteriaChooseChild)criteria).phuCapChild,
                                ((FilterCriteriaChooseChild)criteria).thulaoChild,
                                ((FilterCriteriaChooseChild)criteria).userChildListChild
                                ));
                    }
                    return;
                }
                else if (criteria is FilterCriteriaAll_ForGiayNhanNo)
                {
                    cm.CommandText = "app_Select_UserList_ForGiayNhanNo";
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(UserItem.GetUserItem_GBC(dr, tr));
                    }
                    return;
                }
                else if (criteria is FilterCriteriaChuaPhanQuyenKyKeToan)
                {
                    cm.CommandText = "app_Select_UserListNotInKhoaSoUser";
                    cm.Parameters.AddWithValue("@MaKy", ((FilterCriteriaChuaPhanQuyenKyKeToan)criteria).MaKy);
                }
                else if (criteria is FilterCriteriaBoPhan)
                {
                    cm.CommandText = "app_Select_UserListByBoPhan";
                    cm.Parameters.AddWithValue("@MaBoPhan", ((FilterCriteriaBoPhan)criteria).MaBoPhan);
                }
                else if (criteria is FilterCriteriaKeToanTapDoan)
                {
                    cm.CommandText = "app_Select_UserListByGroupID_MaCongTy";
                    cm.Parameters.AddWithValue("@GroupID", ((FilterCriteriaKeToanTapDoan)criteria).GroupID);
                    cm.Parameters.AddWithValue("@MaCongTy", ((FilterCriteriaKeToanTapDoan)criteria).MaCongTy);
                }
                using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                {
                    while (dr.Read())
                        this.Add(UserItem.GetUserItem(dr, tr));
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
                    foreach (UserItem deletedChild in DeletedList)
                        deletedChild.DeleteSelf(tr);
                    DeletedList.Clear();

                    // loop through each non-deleted child object
                    foreach (UserItem child in this)
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

        /// <summary>
        /// Kiểm tra trong danh sách phải tồn tại ít nhất 1 user thuộc group Admin
        /// </summary>
        /// <returns>True : hợp lệ, False : không</returns>
        public bool KiemTra1Admin()
        {
            //tìm group id admin
            int GroupIDAdmin = 0;
            foreach (GroupItem item in GroupList.GetGroupList())
            {
                if (item.TenChucNang.ToLower() == "admin")
                {
                    GroupIDAdmin = item.GroupID;
                    break;
                }
            }

            foreach (UserItem item in this)
            {
                if (item.GroupID == GroupIDAdmin)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
