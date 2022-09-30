
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{
    [Serializable()]
    public class XuatDuLieuList : Csla.BusinessListBase<XuatDuLieuList, XuatDuLieu>
    {

        #region Authorization Rules

        public static bool CanGetObject()
        {
            //TODO: Define CanGetObject permission in XuatDuLieuList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("XuatDuLieuListViewGroup"))
            //	return true;
            //return false;
        }

        public static bool CanAddObject()
        {
            //TODO: Define CanAddObject permission in XuatDuLieuList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("XuatDuLieuListAddGroup"))
            //	return true;
            //return false;
        }

        public static bool CanEditObject()
        {
            //TODO: Define CanEditObject permission in XuatDuLieuList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("XuatDuLieuListEditGroup"))
            //	return true;
            //return false;
        }

        public static bool CanDeleteObject()
        {
            //TODO: Define CanDeleteObject permission in XuatDuLieuList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("XuatDuLieuListDeleteGroup"))
            //	return true;
            //return false;
        }
        #endregion //Authorization Rules

        #region Factory Methods
        private XuatDuLieuList()
        { /* require use of factory method */ }

        public static XuatDuLieuList NewXuatDuLieuList()
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a XuatDuLieuList");
            return new XuatDuLieuList();
        }


        public static XuatDuLieuList GetXuatDuLieuList(DateTime tuNgay, DateTime denNgay, int maBoPhan, int userID)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a XuatDuLieuList");
            return DataPortal.Fetch<XuatDuLieuList>(new FilterCriteria(tuNgay, denNgay, maBoPhan, userID));
        }

        public static XuatDuLieuList GetXuatDuLieuListByNgayLap(DateTime tuNgay, DateTime denNgay, int maBoPhan)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a XuatDuLieuList");
            return DataPortal.Fetch<XuatDuLieuList>(new FilterCriteriaByNgayLap(tuNgay, denNgay, maBoPhan));
        }

        public static XuatDuLieuList GetXuatDuLieuListByChuongTrinh(DateTime tuNgay, DateTime denNgay, int maBoPhan, int userID)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a XuatDuLieuList");
            return DataPortal.Fetch<XuatDuLieuList>(new FilterCriteriaByChuongTrinh(tuNgay, denNgay, maBoPhan, userID));
        }

        public static XuatDuLieuList LaySoTaiKhoan()
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a XuatDuLieuList");
            return DataPortal.Fetch<XuatDuLieuList>(new FilterCriteriaLaySoTaiKhoan());
        }

        public static XuatDuLieuList LayDanhSachKetChuyen_BangTam()
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a XuatDuLieuList");
            return DataPortal.Fetch<XuatDuLieuList>(new FilterCriteriaLayDanhSachKetChuyen_BangTam());
        }

        public static XuatDuLieuList LayDanhSachChiThuLao_BangTam()
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a XuatDuLieuList");
            return DataPortal.Fetch<XuatDuLieuList>(new FilterCriteriaLayDanhSachChiThuLao_BangTam());
        }

        public static XuatDuLieuList LayDanhSachChiPhiThucHien_BangTam()
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a XuatDuLieuList");
            return DataPortal.Fetch<XuatDuLieuList>(new FilterCriteriaLayDanhSachChiPhiThucHien_BangTam());
        }

        public static XuatDuLieuList GetXuatDuLieuListByKetChuyenChiPhi(DateTime tuNgay, DateTime denNgay, int maBoPhan, int userID, int maChuongTrinh, int maTaiKhoanNo, int maTieuMucNganSach, int maMucNganSach)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a XuatDuLieuList");
            return DataPortal.Fetch<XuatDuLieuList>(new FilterCriteriaByKetChuyenChiPhi(tuNgay, denNgay, maBoPhan, userID ,maChuongTrinh, maTaiKhoanNo, maTieuMucNganSach, maMucNganSach));
        }

        public static XuatDuLieuList GetXuatDuLieuListByKetChuyenChiPhi_New(DateTime tuNgay, DateTime denNgay, int maBoPhan, int userID, int maChuongTrinh, int maTaiKhoanNo, int maTieuMucNganSach, int maMucNganSach)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a XuatDuLieuList");
            return DataPortal.Fetch<XuatDuLieuList>(new FilterCriteriaByKetChuyenChiPhi_New(tuNgay, denNgay, maBoPhan, userID, maChuongTrinh, maTaiKhoanNo, maTieuMucNganSach, maMucNganSach));
        }

        public static XuatDuLieuList KiemTraSoLieuCacBan(DateTime tuNgay, DateTime denNgay, int maBoPhan, int userID)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a XuatDuLieuList");
            return DataPortal.Fetch<XuatDuLieuList>(new FilterCriteriaKiemTraSoLieuCacBan(tuNgay, denNgay, maBoPhan, userID));
        }
        #endregion //Factory Methods

        #region Data Access

        #region Filter Criteria
        [Serializable()]
        private class FilterCriteriaKiemTraSoLieuCacBan
        {
            public DateTime TuNgay;
            public DateTime DenNgay;
            public int MaBoPhan;
            public int UserID;

            public FilterCriteriaKiemTraSoLieuCacBan(DateTime tuNgay, DateTime denNgay, int maBoPhan, int userID)
            {
                this.TuNgay = tuNgay;
                this.DenNgay = denNgay;
                this.MaBoPhan = maBoPhan;
                this.UserID = userID;
            }
        }

        private class FilterCriteriaLayDanhSachKetChuyen_BangTam
        {
            public FilterCriteriaLayDanhSachKetChuyen_BangTam()
            {

            }

        }

        private class FilterCriteriaLayDanhSachChiPhiThucHien_BangTam
        {
            public FilterCriteriaLayDanhSachChiPhiThucHien_BangTam()
            {

            }
        }

        private class FilterCriteriaLayDanhSachChiThuLao_BangTam
        {
            public FilterCriteriaLayDanhSachChiThuLao_BangTam()
            {

            }
        }
        private class FilterCriteriaLaySoTaiKhoan
        {
            public FilterCriteriaLaySoTaiKhoan()
            {

            }
        }
        private class FilterCriteria
        {
            public DateTime TuNgay;
            public DateTime DenNgay;
            public int MaBoPhan;
            public int UserID;

            public FilterCriteria( DateTime tuNgay, DateTime denNgay, int maBoPhan, int userID)
            {
                this.TuNgay=tuNgay;
                this.DenNgay = denNgay;
                this.MaBoPhan= maBoPhan;
                this.UserID = userID;
            }
        }

        private class FilterCriteriaByNgayLap
        {
            public DateTime TuNgay;
            public DateTime DenNgay;
            public int MaBoPhan;

            public FilterCriteriaByNgayLap(DateTime tuNgay, DateTime denNgay, int maBoPhan)
            {
                this.TuNgay = tuNgay;
                this.DenNgay = denNgay;
                this.MaBoPhan = maBoPhan;
            }
        }

        private class FilterCriteriaByChuongTrinh
        {
            public DateTime TuNgay;
            public DateTime DenNgay;
            public int MaBoPhan;
            public int UserID;

            public FilterCriteriaByChuongTrinh(DateTime tuNgay, DateTime denNgay, int maBoPhan, int userID)
            {
                this.TuNgay = tuNgay;
                this.DenNgay = denNgay;
                this.MaBoPhan = maBoPhan;
                this.UserID = userID;
            }
        }

        private class FilterCriteriaByKetChuyenChiPhi
        {
            public DateTime TuNgay;
            public DateTime DenNgay;
            public int MaBoPhan;
            public int UserID;
            public int MaChuongTrinh;
            public int MaTaiKhoanNo;
            public int MaTieuMucNganSach;
            public int MaMucNganSach;

            public FilterCriteriaByKetChuyenChiPhi(DateTime tuNgay, DateTime denNgay, int maBoPhan, int userID, int maChuongTrinh, int maTaiKhoanNo, int maTieuMucNganSach, int maMucNganSach)
            {
                this.TuNgay = tuNgay;
                this.DenNgay = denNgay;
                this.MaBoPhan = maBoPhan;
                this.UserID = userID;
                this.MaChuongTrinh = maChuongTrinh;
                this.MaTaiKhoanNo = maTaiKhoanNo;
                this.MaTieuMucNganSach = maTieuMucNganSach;
                this.MaMucNganSach = maMucNganSach;
            }
        }

        private class FilterCriteriaByKetChuyenChiPhi_New
        {
            public DateTime TuNgay;
            public DateTime DenNgay;
            public int MaBoPhan;
            public int UserID;
            public int MaChuongTrinh;
            public int MaTaiKhoanNo;
            public int MaTieuMucNganSach;
            public int MaMucNganSach;

            public FilterCriteriaByKetChuyenChiPhi_New(DateTime tuNgay, DateTime denNgay, int maBoPhan, int userID, int maChuongTrinh, int maTaiKhoanNo, int maTieuMucNganSach, int maMucNganSach)
            {
                this.TuNgay = tuNgay;
                this.DenNgay = denNgay;
                this.MaBoPhan = maBoPhan;
                this.UserID = userID;
                this.MaChuongTrinh = maChuongTrinh;
                this.MaTaiKhoanNo = maTaiKhoanNo;
                this.MaTieuMucNganSach = maTieuMucNganSach;
                this.MaMucNganSach = maMucNganSach;
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

        private void ExecuteFetch(SqlTransaction tr, Object criteria)
        {

            if (criteria is FilterCriteria)
            {
                using (SqlCommand cm = tr.Connection.CreateCommand())
                {
                    cm.Transaction = tr;
                    cm.CommandType = CommandType.StoredProcedure;
                    //cm.CommandText = "spd_KiemTraSoLieuCacBan";
                    cm.CommandText = "spd_KiemTraSoLieuCacBan_1";
                    cm.CommandTimeout = 360;
                    cm.Parameters.AddWithValue("@TuNgay", ((FilterCriteria)criteria).TuNgay);
                    cm.Parameters.AddWithValue("@DenNgay", ((FilterCriteria)criteria).DenNgay);
                    cm.Parameters.AddWithValue("@MaBoPhan", ((FilterCriteria)criteria).MaBoPhan);
                    cm.Parameters.AddWithValue("@UserID", ((FilterCriteria)criteria).UserID);

                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(XuatDuLieu.GetXuatDuLieu(dr));
                    }
                }//using
            }
            else if (criteria is FilterCriteriaByNgayLap)
            {
                using (SqlCommand cm = tr.Connection.CreateCommand())
                {
                    cm.Transaction = tr;
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_DanhSachChungTuByNgayLap_KiemTraSoTienBuToanAndMuc";
                    cm.CommandTimeout = 90;
                    cm.Parameters.AddWithValue("@TuNgay", ((FilterCriteriaByNgayLap)criteria).TuNgay);
                    cm.Parameters.AddWithValue("@DenNgay", ((FilterCriteriaByNgayLap)criteria).DenNgay);
                    cm.Parameters.AddWithValue("@MaBoPhan", ((FilterCriteriaByNgayLap)criteria).MaBoPhan);

                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(XuatDuLieu.GetXuatDuLieu(dr,3));
                    }
                }//using
            }
           else if (criteria is FilterCriteriaByChuongTrinh)
            {
                using (SqlCommand cm = tr.Connection.CreateCommand())
                {
                    cm.Transaction = tr;
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "[spd_KiemTraSoLieuCacBanNew]";
                    cm.CommandTimeout = 90;
                    cm.Parameters.AddWithValue("@TuNgay", ((FilterCriteriaByChuongTrinh)criteria).TuNgay);
                    cm.Parameters.AddWithValue("@DenNgay", ((FilterCriteriaByChuongTrinh)criteria).DenNgay);
                    cm.Parameters.AddWithValue("@MaBoPhan", ((FilterCriteriaByChuongTrinh)criteria).MaBoPhan);
                    cm.Parameters.AddWithValue("@UserID", ((FilterCriteriaByChuongTrinh)criteria).UserID);

                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(XuatDuLieu.GetXuatDuLieuKiemTraCacBanByChuongTrinh(dr));
                    }
                }//using
            }

            else  if (criteria is FilterCriteriaLaySoTaiKhoan)
            {
                using (SqlCommand cm = tr.Connection.CreateCommand())
                {
                    cm.Transaction = tr;
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_LayTaiKhoanCoByKetChuyenChungTuTam";
                    cm.CommandTimeout = 0;

                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(XuatDuLieu.GetXuatDuLieu(dr,1));
                    }
                }//using
            }
            else if (criteria is FilterCriteriaLayDanhSachKetChuyen_BangTam)
            {
                using (SqlCommand cm = tr.Connection.CreateCommand())
                {
                    cm.Transaction = tr;
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "Spd_LayDanhSachKetChuyen_BangTam";
                    cm.CommandTimeout = 0;

                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(XuatDuLieu.GetXuatDuLieu(dr, 1));
                    }
                }//using
            }

            else if (criteria is FilterCriteriaLayDanhSachChiThuLao_BangTam)
            {
                using (SqlCommand cm = tr.Connection.CreateCommand())
                {
                    cm.Transaction = tr;
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "Spd_LayDanhSachChiThuLao_BangTam";
                    cm.CommandTimeout = 0;

                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(XuatDuLieu.GetXuatDuLieu(dr, 1));
                    }
                }//using
            }

            else if (criteria is FilterCriteriaLayDanhSachChiPhiThucHien_BangTam)
            {
                using (SqlCommand cm = tr.Connection.CreateCommand())
                {
                    cm.Transaction = tr;
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "Spd_LayDanhSachChiPhiThucHien_BangTam";
                    cm.CommandTimeout = 0;

                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(XuatDuLieu.GetXuatDuLieu(dr, 1));
                    }
                }//using
            }
            else if (criteria is FilterCriteriaByKetChuyenChiPhi)
            {
                using (SqlCommand cm = tr.Connection.CreateCommand())
                {
                    cm.Transaction = tr;
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_DanhSachChungTuListByKetChuyenChiPhi";
                    cm.CommandTimeout = 0;
                    cm.Parameters.AddWithValue("@TuNgay", ((FilterCriteriaByKetChuyenChiPhi)criteria).TuNgay);
                    cm.Parameters.AddWithValue("@DenNgay", ((FilterCriteriaByKetChuyenChiPhi)criteria).DenNgay);
                    cm.Parameters.AddWithValue("@MaBoPhan", ((FilterCriteriaByKetChuyenChiPhi)criteria).MaBoPhan);
                    cm.Parameters.AddWithValue("@UserID", ((FilterCriteriaByKetChuyenChiPhi)criteria).UserID);
                    cm.Parameters.AddWithValue("@MaChuongTrinh", ((FilterCriteriaByKetChuyenChiPhi)criteria).MaChuongTrinh);
                    cm.Parameters.AddWithValue("@MaTaiKhoanNo", ((FilterCriteriaByKetChuyenChiPhi)criteria).MaTaiKhoanNo);
                    cm.Parameters.AddWithValue("@MaTieuMucNganSach", ((FilterCriteriaByKetChuyenChiPhi)criteria).MaTieuMucNganSach);
                    cm.Parameters.AddWithValue("@MaMucNganSach", ((FilterCriteriaByKetChuyenChiPhi)criteria).MaMucNganSach);

                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(XuatDuLieu.GetXuatDuLieu(dr,1));
                    }
                }//using
            }

            else if (criteria is FilterCriteriaByKetChuyenChiPhi_New)
            {
                using (SqlCommand cm = tr.Connection.CreateCommand())
                {
                    cm.Transaction = tr;
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_DanhSachChungTuListByKetChuyenChiPhi_New";
                    cm.CommandTimeout = 0;
                    cm.Parameters.AddWithValue("@TuNgay", ((FilterCriteriaByKetChuyenChiPhi_New)criteria).TuNgay);
                    cm.Parameters.AddWithValue("@DenNgay", ((FilterCriteriaByKetChuyenChiPhi_New)criteria).DenNgay);
                    cm.Parameters.AddWithValue("@MaBoPhan", ((FilterCriteriaByKetChuyenChiPhi_New)criteria).MaBoPhan);
                    cm.Parameters.AddWithValue("@UserID", ((FilterCriteriaByKetChuyenChiPhi_New)criteria).UserID);
                    cm.Parameters.AddWithValue("@MaChuongTrinh", ((FilterCriteriaByKetChuyenChiPhi_New)criteria).MaChuongTrinh);
                    cm.Parameters.AddWithValue("@MaTaiKhoanNo", ((FilterCriteriaByKetChuyenChiPhi_New)criteria).MaTaiKhoanNo);
                    cm.Parameters.AddWithValue("@MaTieuMucNganSach", ((FilterCriteriaByKetChuyenChiPhi_New)criteria).MaTieuMucNganSach);
                    cm.Parameters.AddWithValue("@MaMucNganSach", ((FilterCriteriaByKetChuyenChiPhi_New)criteria).MaMucNganSach);

                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(XuatDuLieu.GetXuatDuLieu(dr, 2));
                    }
                }//using
            }
            else if(criteria is FilterCriteriaKiemTraSoLieuCacBan)
            {
                using (SqlCommand cm = tr.Connection.CreateCommand())
                {
                    cm.Transaction = tr;
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_DoiChieuSoLieuCacBan";
                    cm.CommandTimeout = 0;
                    cm.Parameters.AddWithValue("@TuNgay", ((FilterCriteriaKiemTraSoLieuCacBan)criteria).TuNgay);
                    cm.Parameters.AddWithValue("@DenNgay", ((FilterCriteriaKiemTraSoLieuCacBan)criteria).DenNgay);
                    cm.Parameters.AddWithValue("@MaBoPhan", ((FilterCriteriaKiemTraSoLieuCacBan)criteria).MaBoPhan);
                    cm.Parameters.AddWithValue("@UserID", ((FilterCriteriaKiemTraSoLieuCacBan)criteria).UserID);

                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(XuatDuLieu.GetXuatDuLieuKiemTraCacBan(dr));
                    }
                }//using
            
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
                    foreach (XuatDuLieu deletedChild in DeletedList)
                        deletedChild.DeleteSelf(tr);
                    DeletedList.Clear();

                    // loop through each non-deleted child object
                    foreach (XuatDuLieu child in this)
                    {
                        if (child.IsNew)
                            child.Insert(tr,this);
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
