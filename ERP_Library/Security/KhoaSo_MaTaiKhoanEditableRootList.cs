using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{
    [Serializable()]
    public class KhoaSo_MaTaiKhoanRootList : Csla.BusinessListBase<KhoaSo_MaTaiKhoanRootList, KhoaSo_MaTaiKhoan>
    {
        #region BindingList Overrides
        protected override object AddNewCore()
        {
            KhoaSo_MaTaiKhoan item = KhoaSo_MaTaiKhoan.NewKhoaSo_MaTaiKhoan();
            this.Add(item);
            return item;
        }
        #endregion //BindingList Overrides

        #region Authorization Rules

        public static bool CanGetObject()
        {
            //TODO: Define CanGetObject permission in KhoaSo_MaTaiKhoanRootList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("KhoaSo_MaTaiKhoanRootListViewGroup"))
            //	return true;
            //return false;
        }

        public static bool CanAddObject()
        {
            //TODO: Define CanAddObject permission in KhoaSo_MaTaiKhoanRootList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("KhoaSo_MaTaiKhoanRootListAddGroup"))
            //	return true;
            //return false;
        }

        public static bool CanEditObject()
        {
            //TODO: Define CanEditObject permission in KhoaSo_MaTaiKhoanRootList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("KhoaSo_MaTaiKhoanRootListEditGroup"))
            //	return true;
            //return false;
        }

        public static bool CanDeleteObject()
        {
            //TODO: Define CanDeleteObject permission in KhoaSo_MaTaiKhoanRootList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("KhoaSo_MaTaiKhoanRootListDeleteGroup"))
            //	return true;
            //return false;
        }
        #endregion //Authorization Rules

        #region Factory Methods
        private KhoaSo_MaTaiKhoanRootList()
        { /* require use of factory method */ }

        public static KhoaSo_MaTaiKhoanRootList NewKhoaSo_MaTaiKhoanRootList()
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a KhoaSo_MaTaiKhoanRootList");
            return new KhoaSo_MaTaiKhoanRootList();
        }

        public static KhoaSo_MaTaiKhoanRootList GetKhoaSo_MaTaiKhoanRootList(int maKy, int maTaiKhoan)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a KhoaSo_MaTaiKhoanRootList");
            return DataPortal.Fetch<KhoaSo_MaTaiKhoanRootList>(new FilterCriteria(maKy, maTaiKhoan));
        }
        public static KhoaSo_MaTaiKhoanRootList GetKhoaSo_MaTaiKhoanRootList(int userID, int maTaiKhoan,DateTime ngayLap)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a KhoaSo_MaTaiKhoanRootList");
            return DataPortal.Fetch<KhoaSo_MaTaiKhoanRootList>(new FilterCriteriabyUsermaTaiKhoanNgayLap(userID, maTaiKhoan,ngayLap));
        }

        public static KhoaSo_MaTaiKhoanRootList NewKhoaSo_MaTaiKhoanRootList(int maKy, int maTaiKhoan)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a KhoaSo_MaTaiKhoanRootList");
            return DataPortal.Fetch<KhoaSo_MaTaiKhoanRootList>(new FilterCriteriaNew(maKy, maTaiKhoan));
        }

        public static KhoaSo_MaTaiKhoanRootList GetKhoaSo_MaTaiKhoanListByMaKy(int maKy)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a KhoaSo_MaTaiKhoanRootList");
            return DataPortal.Fetch<KhoaSo_MaTaiKhoanRootList>(new ObjectByMaKy(maKy));
        }

        #region Bosung
        public static bool KiemTraTonTaiKhoaSoTaiKhoanListtheoKy_MaTaiKhoan(int MaKy,int maTaiKhoan)
        {
            bool giaTriTraVe = false;
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_KiemTraTonTaiKhoaMaTaiKhoanListtheoKyMaTaiKhoan";
                    cm.Parameters.AddWithValue("@maKy", MaKy);
                    cm.Parameters.AddWithValue("@maTaiKhoan", maTaiKhoan);
                    SqlParameter prmGiaTriTraVe = new SqlParameter("@GiaTriTraVe", SqlDbType.Bit);
                    prmGiaTriTraVe.Direction = ParameterDirection.Output;
                    cm.Parameters.Add(prmGiaTriTraVe);
                    cm.ExecuteNonQuery();
                    giaTriTraVe = (bool)prmGiaTriTraVe.Value;
                }
            }//us
            return giaTriTraVe;
        }
        #endregion
        #endregion //Factory Methods

        #region Data Access

        #region Filter Criteria
        [Serializable()]
        private class FilterCriteria
        {
            public int MaKy;
            public int MaTaiKhoan;

            public FilterCriteria(int maKy, int maTaiKhoan)
            {
                this.MaKy = maKy;
                this.MaTaiKhoan = maTaiKhoan;
            }
        }

        [Serializable()]
        private class FilterCriteriabyUsermaTaiKhoanNgayLap
        {
            public int UserID;
            public int MaTaiKhoan;
            public DateTime NgayLap;

            public FilterCriteriabyUsermaTaiKhoanNgayLap(int userID, int maTaiKhoan,DateTime ngayLap)
            {
                this.UserID = userID;
                this.MaTaiKhoan = maTaiKhoan;
                this.NgayLap = ngayLap;
            }
        }

        private class ObjectByMaKy
        {
            public int maKy;
           
            public ObjectByMaKy(int _maKy)
            {
                this.maKy = _maKy;
            }
        }

        [Serializable()]
        private class FilterCriteriaNew
        {
            public int MaKy;
            public int MaTaiKhoan;

            public FilterCriteriaNew(int maKy, int maTaiKhoan)
            {
                this.MaKy = maKy;
                this.MaTaiKhoan = maTaiKhoan;
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
            using (SqlCommand cm = cn.CreateCommand())
            {
                cm.CommandType = CommandType.StoredProcedure;
                if (criteria is FilterCriteria)
                {
                    cm.CommandText = "spd_SelecttblKhoaSo_MaTaiKhoanByMaKy_User";
                    cm.Parameters.AddWithValue("@MaKy", ((FilterCriteria)criteria).MaKy);
                    cm.Parameters.AddWithValue("@MaTaiKhoan", ((FilterCriteria)criteria).MaTaiKhoan);

                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(KhoaSo_MaTaiKhoan.GetKhoaSo_MaTaiKhoan(dr));
                    }
                }
                if (criteria is FilterCriteriabyUsermaTaiKhoanNgayLap)
                {
                    cm.CommandText = "spd_SelecttblKhoaSo_MaTaiKhoanByUserMaTaiKhoanNgayLap";
                    cm.Parameters.AddWithValue("@UserID", ((FilterCriteriabyUsermaTaiKhoanNgayLap)criteria).UserID);
                    cm.Parameters.AddWithValue("@MaTaiKhoan", ((FilterCriteriabyUsermaTaiKhoanNgayLap)criteria).MaTaiKhoan);
                    cm.Parameters.AddWithValue("@NgayLap", ((FilterCriteriabyUsermaTaiKhoanNgayLap)criteria).NgayLap);

                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(KhoaSo_MaTaiKhoan.GetKhoaSo_MaTaiKhoan(dr));
                    }
                }
                else if (criteria is FilterCriteriaNew)
                {
                    cm.CommandText = "spd_SelecttblKhoaSo_MaTaiKhoanForNew";
                    cm.Parameters.AddWithValue("@MaKy", ((FilterCriteriaNew)criteria).MaKy);
                    cm.Parameters.AddWithValue("@MaTaiKhoan", ((FilterCriteriaNew)criteria).MaTaiKhoan);

                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(KhoaSo_MaTaiKhoan.GetKhoaSo_MaTaiKhoanForNew(dr));
                    }
                }
                else if (criteria is ObjectByMaKy)
                {
                    cm.CommandText = "spd_SelecttblKhoaSo_MaTaiKhoanByMaKy";
                    cm.Parameters.AddWithValue("@MaKy", ((ObjectByMaKy)criteria).maKy);
                    
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(KhoaSo_MaTaiKhoan.GetKhoaSo_MaTaiKhoanByMaKy(dr));
                    }
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
                foreach (KhoaSo_MaTaiKhoan deletedChild in DeletedList)
                    deletedChild.DeleteSelf(cn);
                DeletedList.Clear();

                // loop through each non-deleted child object
                foreach (KhoaSo_MaTaiKhoan child in this)
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
