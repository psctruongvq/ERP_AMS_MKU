
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{
    [Serializable()]
    public class DoiTuongAllList : Csla.BusinessListBase<DoiTuongAllList, DoiTuongAll>
    {

        #region Authorization Rules

        public static bool CanGetObject()
        {
            //TODO: Define CanGetObject permission in DoiTuongAllList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("DoiTuongAllListViewGroup"))
            //	return true;
            //return false;
        }

        public static bool CanAddObject()
        {
            //TODO: Define CanAddObject permission in DoiTuongAllList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("DoiTuongAllListAddGroup"))
            //	return true;
            //return false;
        }

        public static bool CanEditObject()
        {
            //TODO: Define CanEditObject permission in DoiTuongAllList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("DoiTuongAllListEditGroup"))
            //	return true;
            //return false;
        }

        public static bool CanDeleteObject()
        {
            //TODO: Define CanDeleteObject permission in DoiTuongAllList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("DoiTuongAllListDeleteGroup"))
            //	return true;
            //return false;
        }
        #endregion //Authorization Rules


        #region Factory Methods
        private DoiTuongAllList()
        { /* require use of factory method */ }

        public static DoiTuongAllList NewDoiTuongAllList()
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a DoiTuongAllList");
            return new DoiTuongAllList();
        }

        public static DoiTuongAllList GetDoiTuongAllList()
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a DoiTuongAllList");
            return DataPortal.Fetch<DoiTuongAllList>(new FilterCriteria());
        }

        public static DoiTuongAllList GetDoiTuongAllListByLoai(int Loai, int BoPhan)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a DoiTuongAllList");
            return DataPortal.Fetch<DoiTuongAllList>(new FilterCriteriaByLoai(Loai, BoPhan));
        }
        public static DoiTuongAllList GetDoiTuongAllListByTaiKhoanTheoDoi()
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a DoiTuongAllList");
            return DataPortal.Fetch<DoiTuongAllList>(new FilterCriteriaByTaiKhoanTheoDoi());
        }

        public static DoiTuongAllList GetDoiTuongAllList_Tim(string dieuKienTim, int loaiDoiTuong)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a DoiTuongAllList");
            return DataPortal.Fetch<DoiTuongAllList>(new FilterCriteria_Tim(dieuKienTim, loaiDoiTuong));
        } // tim tat ca

        public static DoiTuongAllList GetDoiTuongAllListForDoiTuongTheoDou(int maTaiKhoan)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a DoiTuongAllList");
            return DataPortal.Fetch<DoiTuongAllList>(new FilterCriteriaForDoiTuongTheoDoi(maTaiKhoan));
        } // tim tat ca

        public static DoiTuongAllList GetDoiTuongAllList_Tim_KhachHang(string dieuKienTim)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a DoiTuongAllList");
            return DataPortal.Fetch<DoiTuongAllList>(new FilterCriteria_Tim_KhachHang(dieuKienTim));
        }

        public static DoiTuongAllList GetDoiTuongAllList_DangSuDung(string dieuKienTim, int maCongTy, int loaiDoiTuong)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a DoiTuongAllList");
            return DataPortal.Fetch<DoiTuongAllList>(new FilterCriteria_DangSuDung(dieuKienTim,maCongTy,loaiDoiTuong));
        }

        public static DoiTuongAllList GetDoiTuongAllList_Tim_DaiLy(string dieuKienTim)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a DoiTuongAllList");
            return DataPortal.Fetch<DoiTuongAllList>(new FilterCriteria_Tim_DaiLy(dieuKienTim));
        }

        public static DoiTuongAllList GetDoiTuongAllList_Tim_NhanVien(string dieuKienTim, int maCongTy)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a DoiTuongAllList");
            return DataPortal.Fetch<DoiTuongAllList>(new FilterCriteria_Tim_NhanVien(dieuKienTim, maCongTy));
        }
        public static DoiTuongAllList GetDoiTuongAllList_TimDoiTac(string dieuKienTim, int maCongTy, int loaiDoiTuong)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a DoiTuongAllList");
            return DataPortal.Fetch<DoiTuongAllList>(new FilterCriteria_Tim_DoiTac(dieuKienTim, maCongTy, loaiDoiTuong));
        }
        public static DoiTuongAllList GetDoiTuongAllListByMaTaiKhoan(int MaTaiKhoan)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a DoiTuongAllList");
            return DataPortal.Fetch<DoiTuongAllList>(new FilterCriteriaByMaTaiKhoan(MaTaiKhoan));

        }
        public static DoiTuongAllList GetDoiTuongAllListForKhachHang_NhaCungCap(string dieuKienTim, int maCongTy, int loaiDoiTuong)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a DoiTuongAllList");
            return DataPortal.Fetch<DoiTuongAllList>(new FilterCriteriaForKhachHang_NhaCungCap(dieuKienTim, maCongTy, loaiDoiTuong));
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
        private class FilterCriteriaByTaiKhoanTheoDoi
        {

            public FilterCriteriaByTaiKhoanTheoDoi()
            {

            }
        }

        private class FilterCriteria_Tim
        {
            public string DieuKienTim;
            public int LoaiDoiTuong;


            public FilterCriteria_Tim(string dieuKienTim, int loaiDoiTuong)
            {
                this.DieuKienTim = dieuKienTim;
                this.LoaiDoiTuong = loaiDoiTuong;
            }
        }

        private class FilterCriteria_Tim_KhachHang
        {
            public string DieuKienTim;

            public FilterCriteria_Tim_KhachHang(string dieuKienTim)
            {
                this.DieuKienTim = dieuKienTim;
            }
        }

        private class FilterCriteria_DangSuDung
        {
            public string DieuKienTim;
            public int MaCongTy;
            public int LoaiDoiTuong;
            public FilterCriteria_DangSuDung(string dieuKienTim, int maCongTy, int loaidoituong)
            {              
                this.DieuKienTim = dieuKienTim;
                this.MaCongTy = maCongTy;
                LoaiDoiTuong = loaidoituong;
            }
        }

        private class FilterCriteria_Tim_DaiLy
        {
            public string DieuKienTim;

            public FilterCriteria_Tim_DaiLy(string dieuKienTim)
            {
                this.DieuKienTim = dieuKienTim;
            }
        }

        private class FilterCriteria_Tim_NhanVien
        {
            public string DieuKienTim;
            public int MaCongTy;

            public FilterCriteria_Tim_NhanVien(string dieuKienTim, int maCongTy)
            {
                this.DieuKienTim = dieuKienTim;
                this.MaCongTy = maCongTy;
            }
        }

        private class FilterCriteria_Tim_DoiTac
        {
            public string DieuKienTim;
            public int MaCongTy;
            public int LoaiDoiTuong;

            public FilterCriteria_Tim_DoiTac(string dieuKienTim, int maCongTy, int loaidoituong)
            {
                this.DieuKienTim = dieuKienTim;
                this.MaCongTy = maCongTy;
                LoaiDoiTuong = loaidoituong;
            }
        }

        private class FilterCriteriaByLoai
        {
            public int Loai;
            public int BoPhan;

            public FilterCriteriaByLoai(int loai, int bophan)
            {
                this.Loai = loai;
                this.BoPhan = bophan;
            }
        }
        private class FilterCriteriaByMaTaiKhoan
        {
            public int MaTaiKhoan;
            public FilterCriteriaByMaTaiKhoan(int _maTaiKhoan)
            {
                MaTaiKhoan = _maTaiKhoan;
            }
        }

        private class FilterCriteriaForDoiTuongTheoDoi
        {
            public int MaTaiKhoan;
            public FilterCriteriaForDoiTuongTheoDoi(int _maTaiKhoan)
            {
                MaTaiKhoan = _maTaiKhoan;
            }
        }

        private class FilterCriteriaForKhachHang_NhaCungCap
        {
            public string DieuKienTim;
            public int MaCongTy;
            public int LoaiDoiTuong;

            public FilterCriteriaForKhachHang_NhaCungCap(string dieuKienTim, int maCongTy, int loaidoituong)
            {
                this.DieuKienTim = dieuKienTim;
                this.MaCongTy = maCongTy;
                LoaiDoiTuong = loaidoituong;
            }
        }
        #endregion //Filter Criteria

        #region Data Access - Fetch
        private void DataPortal_Fetch(FilterCriteriaByLoai criteria)
        {
            RaiseListChangedEvents = false;

            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();

                ExecuteFetchLoai(cn, criteria);
            }//using

            RaiseListChangedEvents = true;
        }

        private void DataPortal_Fetch(FilterCriteria criteria)
        {
            RaiseListChangedEvents = false;

            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();

                ExecuteFetch(cn, criteria);
            }//using

            RaiseListChangedEvents = true;
        }

        private void ExecuteFetch(SqlConnection cn, FilterCriteria criteria)
        {
            using (SqlCommand cm = cn.CreateCommand())
            {

                cm.CommandType = CommandType.Text;
                cm.CommandText = "select *from view_AllDoiTuong";


                using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                {
                    while (dr.Read())
                        this.Add(DoiTuongAll.GetDoiTuongAll(dr));
                }
            }//using
        }

        private void ExecuteFetchLoai(SqlConnection cn, FilterCriteriaByLoai criteria)
        {
            using (SqlCommand cm = cn.CreateCommand())
            {
                cm.CommandType = CommandType.StoredProcedure;

                cm.CommandText = "spd_TimTheoDoiTuong";
                cm.Parameters.AddWithValue("@Loai", 1);
                cm.Parameters.AddWithValue("@MaBoPhan", criteria.BoPhan);
                using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                {
                    while (dr.Read())
                        this.Add(DoiTuongAll.GetDoiTuongAll(dr));
                }
            }//using
        }

        private void DataPortal_Fetch(Object criteria)
        {
            RaiseListChangedEvents = false;

            SqlTransaction tr;

            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();

                tr = cn.BeginTransaction();

                ExecuteFetch(tr, criteria);

                tr.Commit();

            }//using

            RaiseListChangedEvents = true;
        }

        private void ExecuteFetch(SqlTransaction tr, Object criteria)
        {
            if (criteria is FilterCriteria_Tim)
            {
                using (SqlCommand cm = tr.Connection.CreateCommand())
                {
                    cm.Transaction = tr;
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_TimKhachHang";
                    cm.Parameters.AddWithValue("@DieuKienTim", ((FilterCriteria_Tim)criteria).DieuKienTim);
                    cm.Parameters.AddWithValue("@LoaiDoiTuong", ((FilterCriteria_Tim)criteria).LoaiDoiTuong);
                    cm.Parameters.AddWithValue("@MaCongTy", ERP_Library.Security.CurrentUser.Info.MaCongTy);
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        //while (dr.Read())
                        //    this.Add(DoiTuongAll.GetDoiTuongAll(dr));
                        while (dr.Read())
                            this.Add(DoiTuongAll.GetDoiTuongAll_CongTy(dr));
                    }
                }
            }
            else if (criteria is FilterCriteria_Tim_KhachHang)
            {
                using (SqlCommand cm = tr.Connection.CreateCommand())
                {
                    cm.Transaction = tr;
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_TimKhachHang_DoiTac";
                    cm.Parameters.AddWithValue("@DieuKienTim", ((FilterCriteria_Tim_KhachHang)criteria).DieuKienTim);
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(DoiTuongAll.GetDoiTuongAll(dr));
                    }
                }
            }
            else if (criteria is FilterCriteria_DangSuDung)
            {
                using (SqlCommand cm = tr.Connection.CreateCommand())
                {
                    cm.Transaction = tr;
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_GetDoiTac_DangSuDung";
                    cm.Parameters.AddWithValue("@DieuKienTim", ((FilterCriteria_DangSuDung)criteria).DieuKienTim);
                    cm.Parameters.AddWithValue("@LoaiDoiTuong", ((FilterCriteria_DangSuDung)criteria).LoaiDoiTuong);
                    cm.Parameters.AddWithValue("@MaCongTy", ((FilterCriteria_DangSuDung)criteria).MaCongTy);
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(DoiTuongAll.GetDoiTuongAll(dr));
                    }
                }
            }
            else if (criteria is FilterCriteria_Tim_DaiLy)
            {
                using (SqlCommand cm = tr.Connection.CreateCommand())
                {
                    cm.Transaction = tr;
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_TimKhachHang_DaiLy";
                    cm.Parameters.AddWithValue("@DieuKienTim", ((FilterCriteria_Tim_DaiLy)criteria).DieuKienTim);
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(DoiTuongAll.GetDoiTuongAll(dr));
                    }
                }
            }
            else if (criteria is FilterCriteria_Tim_NhanVien)
            {
                using (SqlCommand cm = tr.Connection.CreateCommand())
                {
                    cm.Transaction = tr;
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_TimKhachHang_NhanVien";
                    cm.Parameters.AddWithValue("@DieuKienTim", ((FilterCriteria_Tim_NhanVien)criteria).DieuKienTim);
                    cm.Parameters.AddWithValue("@MaCongty", ((FilterCriteria_Tim_NhanVien)criteria).MaCongTy);
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        //while (dr.Read())
                        //    this.Add(DoiTuongAll.GetDoiTuongAll(dr));
                        while (dr.Read())
                            this.Add(DoiTuongAll.GetDoiTuongAll_CongTy(dr));
                    }
                }
            }
            else if (criteria is FilterCriteria_Tim_DoiTac)
            {
                using (SqlCommand cm = tr.Connection.CreateCommand())
                {
                    cm.Transaction = tr;
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandTimeout = 3000;
                    cm.CommandText = "spd_TimKhachHang_DoiTac";
                    cm.Parameters.AddWithValue("@DieuKienTim", ((FilterCriteria_Tim_DoiTac)criteria).DieuKienTim);
                    cm.Parameters.AddWithValue("@MaCongty", ((FilterCriteria_Tim_DoiTac)criteria).MaCongTy);
                    cm.Parameters.AddWithValue("@LoaiDoiTuong", ((FilterCriteria_Tim_DoiTac)criteria).LoaiDoiTuong);
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        //while (dr.Read())
                        //    this.Add(DoiTuongAll.GetDoiTuongAll(dr));
                        while (dr.Read())
                            this.Add(DoiTuongAll.GetDoiTuongAll_CongTy(dr));
                    }
                }
            }
            else if (criteria is FilterCriteriaByMaTaiKhoan)
            {
                using (SqlCommand cm = tr.Connection.CreateCommand())
                {
                    cm.Transaction = tr;
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_TimKhachHangByTaiKhoan";
                    cm.Parameters.AddWithValue("@MaTaiKhoan", ((FilterCriteriaByMaTaiKhoan)criteria).MaTaiKhoan);
                    cm.Parameters.AddWithValue("@MaCongTy", ERP_Library.Security.CurrentUser.Info.MaCongTy);
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(DoiTuongAll.GetDoiTuongAllByMaTaiKhoan(dr));
                    }
                }
            }
            else if (criteria is FilterCriteriaByTaiKhoanTheoDoi)
            {
                using (SqlCommand cm = tr.Connection.CreateCommand())
                {
                    cm.Transaction = tr;
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_GetKhachHangByTaiKhoanTheoDoi";
                    cm.Parameters.AddWithValue("@UserID", ERP_Library.Security.CurrentUser.Info.MaCongTy);
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(DoiTuongAll.GetDoiTuongAllByMaTaiKhoan(dr));
                    }
                }
            }

            else if (criteria is FilterCriteriaForDoiTuongTheoDoi)
            {
                using (SqlCommand cm = tr.Connection.CreateCommand())
                {
                    cm.Transaction = tr;
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_LoadDoiTacTheoDoiTuongTheoDoi";
                    cm.Parameters.AddWithValue("@MaTaiKhoan", ((FilterCriteriaForDoiTuongTheoDoi)criteria).MaTaiKhoan);
                    cm.Parameters.AddWithValue("@MaCongTy", ERP_Library.Security.CurrentUser.Info.MaCongTy);
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(DoiTuongAll.GetDoiTuongAll(dr));
                    }
                }
            }
            else if (criteria is FilterCriteriaForKhachHang_NhaCungCap)
            {
                using (SqlCommand cm = tr.Connection.CreateCommand())
                {
                    cm.Transaction = tr;
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_TimKhachHang_NhaCungCap";                   
                    cm.Parameters.AddWithValue("@DieuKienTim", ((FilterCriteriaForKhachHang_NhaCungCap)criteria).DieuKienTim);
                    cm.Parameters.AddWithValue("@MaCongty", ((FilterCriteriaForKhachHang_NhaCungCap)criteria).MaCongTy);
                    cm.Parameters.AddWithValue("@LoaiDoiTuong", ((FilterCriteriaForKhachHang_NhaCungCap)criteria).LoaiDoiTuong);
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(DoiTuongAll.GetDoiTuongAll(dr));
                    }
                }
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
                foreach (DoiTuongAll deletedChild in DeletedList)
                    deletedChild.DeleteSelf(cn);
                DeletedList.Clear();

                // loop through each non-deleted child object
                foreach (DoiTuongAll child in this)
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
