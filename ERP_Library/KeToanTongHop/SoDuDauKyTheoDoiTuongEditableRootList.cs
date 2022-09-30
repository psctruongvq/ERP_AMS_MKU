
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{
    [Serializable()]
    public class SoDuDauKyTheoDoiTuongList : Csla.BusinessListBase<SoDuDauKyTheoDoiTuongList, SoDuDauKyTheoDoiTuong>
    {
        #region BindingList Overrides
        protected override object AddNewCore()
        {
            SoDuDauKyTheoDoiTuong item = SoDuDauKyTheoDoiTuong.NewSoDuDauKyTheoDoiTuong();
            this.Add(item);
            return item;
        }
        #endregion //BindingList Overrides

        #region Authorization Rules

        public static bool CanGetObject()
        {
            //TODO: Define CanGetObject permission in SoDuDauKyTheoDoiTuongList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("SoDuDauKyTheoDoiTuongListViewGroup"))
            //	return true;
            //return false;
        }

        public static bool CanAddObject()
        {
            //TODO: Define CanAddObject permission in SoDuDauKyTheoDoiTuongList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("SoDuDauKyTheoDoiTuongListAddGroup"))
            //	return true;
            //return false;
        }

        public static bool CanEditObject()
        {
            //TODO: Define CanEditObject permission in SoDuDauKyTheoDoiTuongList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("SoDuDauKyTheoDoiTuongListEditGroup"))
            //	return true;
            //return false;
        }

        public static bool CanDeleteObject()
        {
            //TODO: Define CanDeleteObject permission in SoDuDauKyTheoDoiTuongList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("SoDuDauKyTheoDoiTuongListDeleteGroup"))
            //	return true;
            //return false;
        }
        #endregion //Authorization Rules

        #region Factory Methods
        private SoDuDauKyTheoDoiTuongList()
        { /* require use of factory method */ }

        public static SoDuDauKyTheoDoiTuongList NewSoDuDauKyTheoDoiTuongList()
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a SoDuDauKyTheoDoiTuongList");
            return new SoDuDauKyTheoDoiTuongList();
        }

        public static SoDuDauKyTheoDoiTuongList GetSoDuDauKyTheoDoiTuongList()
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a SoDuDauKyTheoDoiTuongList");
            return DataPortal.Fetch<SoDuDauKyTheoDoiTuongList>(new FilterCriteria());
        }

        public static SoDuDauKyTheoDoiTuongList GetSoDuDauKyTheoDoiTuongList(int maKy, int maBoPhan)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a SoDuDauKyTheoDoiTuongList");
            return DataPortal.Fetch<SoDuDauKyTheoDoiTuongList>(new FilterCriteriabyMaKy(maKy, maBoPhan));
        }
        public static SoDuDauKyTheoDoiTuongList GetSoDuDauKyTheoDoiTuongList(int maKy, int maBoPhan, int maLoaiDoituong)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a SoDuDauKyTheoDoiTuongList");
            return DataPortal.Fetch<SoDuDauKyTheoDoiTuongList>(new FilterCriteriabyMaKyLoaiDoiTuong(maKy, maBoPhan, maLoaiDoituong));
        }
        public static SoDuDauKyTheoDoiTuongList GetSoDuDauKyTheoDoiTuongList_MaTaiKhoan(int maKy, int maBoPhan, int maTaiKhoan)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a SoDuDauKyTheoDoiTuongList");
            return DataPortal.Fetch<SoDuDauKyTheoDoiTuongList>(new FilterCriteriabyMaKy_MaTaiKhoan(maKy, maBoPhan, maTaiKhoan));
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

        private class FilterCriteriabyMaKy
        {
            public int MaKy;
            public int MaBoPhan;
            public FilterCriteriabyMaKy(int _maKy, int _maBoPhan)
            {
                this.MaKy = _maKy;
                this.MaBoPhan = _maBoPhan;
            }
        }

        private class FilterCriteriabyMaKyLoaiDoiTuong
        {
            public int MaKy;
            public int MaBoPhan;
            public int MaLoaiDoiTuong;
            public FilterCriteriabyMaKyLoaiDoiTuong(int maKy, int maBoPhan, int maloaidoituong)
            {
                this.MaKy = maKy;
                this.MaBoPhan = maBoPhan;
                this.MaLoaiDoiTuong = maloaidoituong;
            }
        }

        private class FilterCriteriabyMaKy_MaTaiKhoan
        {
            public int MaKy;
            public int MaBoPhan;
            public int MaTaiKhoan;
            public FilterCriteriabyMaKy_MaTaiKhoan(int maKy, int maBoPhan, int maTaiKhoan)
            {
                this.MaKy = maKy;
                this.MaBoPhan = maBoPhan;
                this.MaTaiKhoan = maTaiKhoan;
            }
        }

        #endregion //Filter Criteria

        #region Data Access - Fetch
        private void DataPortal_Fetch(Object criteria)
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

        private void ExecuteFetch(SqlTransaction tr, Object criteria)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                if (criteria is FilterCriteria)
                {
                    cm.CommandText = "spd_SelecttblSoDuDauKyTheoDoiTuongsAll";
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(SoDuDauKyTheoDoiTuong.GetSoDuDauKyTheoDoiTuong(dr, true));
                    }
                }
                else if (criteria is FilterCriteriabyMaKy)
                {
                    FilterCriteriabyMaKy crit = (FilterCriteriabyMaKy)criteria;
                    int count;
                    count = SoDuDauKyTheoDoiTuong.KiemTraKyKetChuyen(crit.MaKy, crit.MaBoPhan);

                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_LaySoDuDauTaiKhoanTheoDoiTuong";
                    cm.Parameters.AddWithValue("@MaKy", crit.MaKy);
                    cm.Parameters.AddWithValue("@MaBoPhan", crit.MaBoPhan);
                    cm.Parameters.AddWithValue("@UserID", ERP_Library.Security.CurrentUser.Info.UserID);
                    if (count > 0)
                    {
                        using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                        {
                            while (dr.Read())
                            {
                                this.Add(SoDuDauKyTheoDoiTuong.GetSoDuDauKyTheoDoiTuong(dr, true));
                            }
                        }
                    }

                    else
                    {
                        using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                        {
                            while (dr.Read())
                            {
                                this.Add(SoDuDauKyTheoDoiTuong.GetSoDuDauKyTheoDoiTuong(dr, false));
                            }
                        }
                    }
                }
                else if (criteria is FilterCriteriabyMaKyLoaiDoiTuong)
                {
                    FilterCriteriabyMaKyLoaiDoiTuong crit = (FilterCriteriabyMaKyLoaiDoiTuong)criteria;
                    int count;
                    count = SoDuDauKyTheoDoiTuong.KiemTraKyKetChuyen(crit.MaKy, crit.MaBoPhan);

                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_LaySoDuDauTaiKhoanTheoDoiTuong_Modify";
                    cm.Parameters.AddWithValue("@MaKy", crit.MaKy);
                    cm.Parameters.AddWithValue("@MaLoaiDoiTuong", crit.MaLoaiDoiTuong);
                    cm.Parameters.AddWithValue("@MaBoPhan", crit.MaBoPhan);
                    cm.Parameters.AddWithValue("@UserID", ERP_Library.Security.CurrentUser.Info.UserID);
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                        {
                            this.Add(SoDuDauKyTheoDoiTuong.GetSoDuDauKyTheoDoiTuong(dr));
                        }
                    }
                }
                else if (criteria is FilterCriteriabyMaKy_MaTaiKhoan)
                {
                    FilterCriteriabyMaKy_MaTaiKhoan crit = (FilterCriteriabyMaKy_MaTaiKhoan)criteria;
                    int count;
                    count = SoDuDauKyTheoDoiTuong.KiemTraKyKetChuyen(crit.MaKy, crit.MaBoPhan);

                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_LaySoDuDauTaiKhoanTheoDoiTuong_Modify";
                    cm.Parameters.AddWithValue("@MaKy", crit.MaKy);
                    cm.Parameters.AddWithValue("@MaLoaiDoiTuong", 0);
                    cm.Parameters.AddWithValue("@MaBoPhan", crit.MaBoPhan);
                    cm.Parameters.AddWithValue("@UserID", ERP_Library.Security.CurrentUser.Info.UserID);
                    cm.Parameters.AddWithValue("@MaTaiKhoan", crit.MaTaiKhoan);
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                        {
                            this.Add(SoDuDauKyTheoDoiTuong.GetSoDuDauKyTheoDoiTuong(dr));
                        }
                    }
                }

            }
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
                    foreach (SoDuDauKyTheoDoiTuong deletedChild in DeletedList)
                        deletedChild.DeleteSelf(tr);
                    DeletedList.Clear();

                    // loop through each non-deleted child object
                    foreach (SoDuDauKyTheoDoiTuong child in this)
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
