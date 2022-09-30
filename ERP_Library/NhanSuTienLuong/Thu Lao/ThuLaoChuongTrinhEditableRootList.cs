
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using System.Collections;


namespace ERP_Library
{
    [Serializable()]
    public class ThuLaoChuongTrinhList : Csla.BusinessListBase<ThuLaoChuongTrinhList, ThuLaoChuongTrinh>
    {

        #region Authorization Rules
        protected override object AddNewCore()
        {
            ThuLaoChuongTrinh item = ThuLaoChuongTrinh.NewThuLaoChuongTrinh();

            this.Add(item);
            return item;
        }
        //protected override void RemoveItem(int index)
        //{
        //    base.RemoveItem(index);
        //}
        //protected override void RemoveItem(int index)
        //{
        //    base.RemoveItem(index);
        //}
        public static bool CanGetObject()
        {
            //TODO: Define CanGetObject permission in ThuLaoChuongTrinhList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("ThuLaoChuongTrinhListViewGroup"))
            //	return true;
            //return false;
        }

        public static bool CanAddObject()
        {
            //TODO: Define CanAddObject permission in ThuLaoChuongTrinhList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("ThuLaoChuongTrinhListAddGroup"))
            //	return true;
            //return false;
        }

        public static bool CanEditObject()
        {
            //TODO: Define CanEditObject permission in ThuLaoChuongTrinhList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("ThuLaoChuongTrinhListEditGroup"))
            //	return true;
            //return false;
        }

        public static bool CanDeleteObject()
        {
            //TODO: Define CanDeleteObject permission in ThuLaoChuongTrinhList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("ThuLaoChuongTrinhListDeleteGroup"))
            //	return true;
            //return false;
        }
        #endregion //Authorization Rules


        #region Factory Methods
        private ThuLaoChuongTrinhList()

        { /* require use of factory method */ }

        public static ThuLaoChuongTrinhList NewThuLaoChuongTrinhList()
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a ThuLaoChuongTrinhList");
            return new ThuLaoChuongTrinhList();
        }

        public static ThuLaoChuongTrinhList GetThuLaoChuongTrinhListByNgayLap(DateTime tuNgay, DateTime denNgay, bool thanhToan, bool PhieuChiMoi)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a ThuLaoChuongTrinhList");
            return DataPortal.Fetch<ThuLaoChuongTrinhList>(new FilterCriteriaByTuNgayDenNgay(tuNgay, denNgay, thanhToan, PhieuChiMoi));
        }
        public static ThuLaoChuongTrinhList GetThuLaoChuongTrinhListChuaChuyenKhoan(DateTime tuNgay, DateTime denNgay, bool group)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a ThuLaoChuongTrinhList");
            return DataPortal.Fetch<ThuLaoChuongTrinhList>(new FilterCriteriaByChuaChuyenKhoan(tuNgay, denNgay, group));
        }
        public static ThuLaoChuongTrinhList GetThuLaoChuongTrinhListChuaChuyenKhoan_Modify(DateTime tuNgay, DateTime denNgay, bool group)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a ThuLaoChuongTrinhList");
            return DataPortal.Fetch<ThuLaoChuongTrinhList>(new FilterCriteriaByChuaChuyenKhoan_Modify(tuNgay, denNgay, group));
        }
        public static ThuLaoChuongTrinhList GetThuLaoChuongTrinhList()
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a ThuLaoChuongTrinhList");
            return DataPortal.Fetch<ThuLaoChuongTrinhList>(new FilterCriteria());
        }
        public static ThuLaoChuongTrinhList GetThuLaoChuongTrinhList(long MaChungTu)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a ThuLaoChuongTrinhList");
            return DataPortal.Fetch<ThuLaoChuongTrinhList>(new FilterCriteria_ByMaChungTu(MaChungTu));
        }

        public static ThuLaoChuongTrinhList GetThuLaoChuongTrinhListByBoPhan_NgayLap(int maBoPhan, DateTime ngayLap, int maKyTinhLuong, int maChuongTrinh)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a ThuLaoChuongTrinhList");
            return DataPortal.Fetch<ThuLaoChuongTrinhList>(new FilterCriteria_ByBoPhan_NgayLap(maBoPhan, ngayLap, maKyTinhLuong, maChuongTrinh));
        }

        public static ThuLaoChuongTrinhList GetThuLaoChuongTrinhList(int maBoPhan, int maChuongTrinh, int maKyTinhLuong, int maGiayXacNhan, string MaPhieuChi, DateTime ngayLap, bool tinhDangPhi, bool thanhToan)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a ThuLaoChuongTrinhList");
            return DataPortal.Fetch<ThuLaoChuongTrinhList>(new FilterCriteriaByMaGiayXacNhanMaKyTinhLuong(maBoPhan, maChuongTrinh, maKyTinhLuong, maGiayXacNhan, MaPhieuChi, ngayLap, tinhDangPhi, thanhToan));
        }
        public static ThuLaoChuongTrinhList GetThuLaoChuongTrinhList_ByChuongTrinh(long maChuongTrinh, int maKy, DateTime tuNgay, DateTime denNgay)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a ThuLaoChuongTrinhList");
            return DataPortal.Fetch<ThuLaoChuongTrinhList>(new FilterCriteriaByChuongTrinh(maChuongTrinh, maKy, tuNgay, denNgay));
        }
        /// <summary>
        /// Dung Truong Hop Thanh Toan Bang Tien Mat, su dung MaPhieuChi
        /// </summary>
        /// <param name="maBoPhan"></param>
        /// <param name="maChuongTrinh"></param>
        /// <param name="maKyTinhLuong"></param>
        /// <param name="maPhieuChi"></param>
        /// <returns></returns>
        public static ThuLaoChuongTrinhList GetThuLaoChuongTrinhList(int maBoPhan, int maChuongTrinh, int maKyTinhLuong, string maPhieuChi, bool tinhDangPhi, long maChiThuLao, int maChiTietGiayXacNhan, DateTime ngayLap)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a ThuLaoChuongTrinhList");
            return DataPortal.Fetch<ThuLaoChuongTrinhList>(new FilterCriteriaByPhieuChi(maBoPhan, maChuongTrinh, maKyTinhLuong, maPhieuChi, tinhDangPhi, maChiThuLao, maChiTietGiayXacNhan, ngayLap));
        }
        /// <summary>
        /// Trường hợp thanh toán bằng tiền mặt Old và New. Phương thức này ko có điều kiện Đảng Phí. Sẽ lấy all thù lao theo các điều kiện trên 
        /// </summary>
        /// <param name="maBoPhan"></param>
        /// <param name="maChuongTrinh"></param>
        /// <param name="maKyTinhLuong"></param>
        /// <param name="maPhieuChi"></param>
        /// <param name="maChiThuLao"></param>
        /// <param name="maChiTietGiayXacNhan"></param>
        /// <returns></returns>
        public static ThuLaoChuongTrinhList GetThuLaoChuongTrinhList(int maBoPhan, int maChuongTrinh, int maKyTinhLuong, string maPhieuChi, long maChiThuLao, int maChiTietGiayXacNhan)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a ThuLaoChuongTrinhList");
            return DataPortal.Fetch<ThuLaoChuongTrinhList>(new FilterCriteriaByPhieuChi1(maBoPhan, maChuongTrinh, maKyTinhLuong, maPhieuChi, maChiThuLao, maChiTietGiayXacNhan));
        }
        public static ThuLaoChuongTrinhList GetThuLaoChuongTrinhListByChuyenKhoan(int maChuongTrinh, int maKyTinhLuong, int maChiTietGiayXacNhan, int nguoiLap, bool tinhDangPhi, DateTime ngayLap, long maChiThuLao)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a ThuLaoChuongTrinhList");
            return DataPortal.Fetch<ThuLaoChuongTrinhList>(new FilterCriteriaByChuyenKhoan(maChuongTrinh, maKyTinhLuong, maChiTietGiayXacNhan, nguoiLap, tinhDangPhi, ngayLap, maChiThuLao));
        }
        public static ThuLaoChuongTrinhList GetThuLaoChuongTrinhListByCopy(int maChuongTrinh, int maKyTinhLuong, int maChiTietGiayXacNhan, int nguoiLap, bool tinhDangPhi, DateTime ngayLap, long maChiThuLao)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a ThuLaoChuongTrinhList");
            return DataPortal.Fetch<ThuLaoChuongTrinhList>(new FilterCriteriaByCopy(maChuongTrinh, maKyTinhLuong, maChiTietGiayXacNhan, nguoiLap, tinhDangPhi, ngayLap, maChiThuLao));
        }
        public static ThuLaoChuongTrinhList GetThuLaoChuongTrinhListByCopyTienMat(int maBoPhan, int maChuongTrinh, int maKyTinhLuong, string maPhieuChi, bool tinhDangPhi, long maChiThuLao, int maChiTietGiayXacNhan, DateTime ngayLap)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a ThuLaoChuongTrinhList");
            return DataPortal.Fetch<ThuLaoChuongTrinhList>(new FilterCriteriaByCopyTienMat(maBoPhan, maChuongTrinh, maKyTinhLuong, maPhieuChi, tinhDangPhi, maChiThuLao, maChiTietGiayXacNhan, ngayLap));
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

        private class FilterCriteria_ByMaChungTu
        {
            public long MaChungTu = 0;
            public FilterCriteria_ByMaChungTu(long maChungTu)
            {
                this.MaChungTu = maChungTu;
            }
        }

        private class FilterCriteria_ByBoPhan_NgayLap
        {
            public int _maBoPhan;
            public DateTime _ngayLap;
            public int _maKyTinhLuong;
            public int _maChuongTrinh;

            public FilterCriteria_ByBoPhan_NgayLap(int maBoPhan, DateTime ngayLap, int maKyTinhLuong, int maChuongTrinh)
            {
                this._maBoPhan = maBoPhan;
                this._ngayLap = ngayLap;
                this._maKyTinhLuong = maKyTinhLuong;
                this._maChuongTrinh = maChuongTrinh;
            }
        }

        private class FilterCriteriaByChuongTrinh
        {
            public long MaChuongTrinh = 0;
            public int MaKyTinhLuong = 0;
            public DateTime TuNgay;
            public DateTime DenNgay;
            public FilterCriteriaByChuongTrinh(long maChuongTrinh, int maKyTinhLuong, DateTime tuNgay, DateTime denNgay)
            {
                this.MaChuongTrinh = maChuongTrinh;
                this.MaKyTinhLuong = maKyTinhLuong;
                this.TuNgay = tuNgay;
                this.DenNgay = denNgay;
            }
        }

        private class FilterCriteriaByChuyenKhoan
        {

            public int MaChuongTrinh;
            public int MaKyTinhLuong;
            public int MaChiTietGiayXacNhan;
            public int NguoiLap;
            public bool TinhDangPhi;
            public DateTime NgayLap;
            public long MaChiThuLao;
            public FilterCriteriaByChuyenKhoan(int maChuongTrinh, int maKyTinhLuong, int maChiTietGiayXacNhan, int nguoiLap, bool tinhDangPhi, DateTime ngayLap, long maChiThuLao)
            {
                this.MaChuongTrinh = maChuongTrinh;
                this.MaKyTinhLuong = maKyTinhLuong;
                this.MaChiTietGiayXacNhan = maChiTietGiayXacNhan;
                this.NguoiLap = nguoiLap;
                this.TinhDangPhi = tinhDangPhi;
                this.NgayLap = ngayLap;
                this.MaChiThuLao = maChiThuLao;
            }
        }
        private class FilterCriteriaByCopy
        {

            public int MaChuongTrinh;
            public int MaKyTinhLuong;
            public int MaChiTietGiayXacNhan;
            public int NguoiLap;
            public bool TinhDangPhi;
            public DateTime NgayLap;
            public long MaChiThuLao;
            public FilterCriteriaByCopy(int maChuongTrinh, int maKyTinhLuong, int maChiTietGiayXacNhan, int nguoiLap, bool tinhDangPhi, DateTime ngayLap, long maChiThuLao)
            {
                this.MaChuongTrinh = maChuongTrinh;
                this.MaKyTinhLuong = maKyTinhLuong;
                this.MaChiTietGiayXacNhan = maChiTietGiayXacNhan;
                this.NguoiLap = nguoiLap;
                this.TinhDangPhi = tinhDangPhi;
                this.NgayLap = ngayLap;
                this.MaChiThuLao = maChiThuLao;
            }
        }
        private class FilterCriteriaByPhieuChi1
        {
            public int maBoPhan;
            public int maChuongTrinh;
            public int maKyTinhLuong;
            public string maPhieuChi;

            public long MaChiThuLao;
            public int MaChiTietGiayXacNhan;
            public FilterCriteriaByPhieuChi1(int _maBoPhan, int _maChuongTrinh, int _maKyTinhLuong, string _maPhieuChi, long maChiThuLao, int maChiTietGiayXacNhan)
            {
                this.maBoPhan = _maBoPhan;
                this.maChuongTrinh = _maChuongTrinh;
                this.maKyTinhLuong = _maKyTinhLuong;
                this.maPhieuChi = _maPhieuChi;

                this.MaChiThuLao = maChiThuLao;
                this.MaChiTietGiayXacNhan = maChiTietGiayXacNhan;

            }
        }

        private class FilterCriteriaByPhieuChi
        {
            public int maBoPhan;
            public int maChuongTrinh;
            public int maKyTinhLuong;
            public string maPhieuChi;
            public bool TinhDangPhi;
            public long MaChiThuLao;
            public int MaChiTietGiayXacNhan;
            public DateTime NgayLap;
            public FilterCriteriaByPhieuChi(int _maBoPhan, int _maChuongTrinh, int _maKyTinhLuong, string _maPhieuChi, bool tinhDangPhi, long maChiThuLao, int maChiTietGiayXacNhan, DateTime ngayLap)
            {
                this.maBoPhan = _maBoPhan;
                this.maChuongTrinh = _maChuongTrinh;
                this.maKyTinhLuong = _maKyTinhLuong;
                this.maPhieuChi = _maPhieuChi;
                this.TinhDangPhi = tinhDangPhi;
                this.MaChiThuLao = maChiThuLao;
                this.MaChiTietGiayXacNhan = maChiTietGiayXacNhan;
                this.NgayLap = ngayLap;
            }
        }
        private class FilterCriteriaByCopyTienMat
        {
            public int maBoPhan;
            public int maChuongTrinh;
            public int maKyTinhLuong;
            public string maPhieuChi;
            public bool TinhDangPhi;
            public long MaChiThuLao;
            public int MaChiTietGiayXacNhan;
            public DateTime NgayLap;
            public FilterCriteriaByCopyTienMat(int _maBoPhan, int _maChuongTrinh, int _maKyTinhLuong, string _maPhieuChi, bool tinhDangPhi, long maChiThuLao, int maChiTietGiayXacNhan, DateTime ngayLap)
            {
                this.maBoPhan = _maBoPhan;
                this.maChuongTrinh = _maChuongTrinh;
                this.maKyTinhLuong = _maKyTinhLuong;
                this.maPhieuChi = _maPhieuChi;
                this.TinhDangPhi = tinhDangPhi;
                this.MaChiThuLao = maChiThuLao;
                this.MaChiTietGiayXacNhan = maChiTietGiayXacNhan;
                this.NgayLap = ngayLap;
            }
        }
        private class FilterCriteriaByChuaChuyenKhoan
        {
            public DateTime TuNgay;
            public DateTime DenNgay;
            public bool Group;
            public FilterCriteriaByChuaChuyenKhoan(DateTime tuNgay, DateTime denNgay, bool group)
            {
                this.TuNgay = tuNgay;
                this.DenNgay = denNgay;
                this.Group = group;
            }
        }
        private class FilterCriteriaByChuaChuyenKhoan_Modify
        {
            public DateTime TuNgay;
            public DateTime DenNgay;
            public bool Group;
            public FilterCriteriaByChuaChuyenKhoan_Modify(DateTime tuNgay, DateTime denNgay, bool group)
            {
                this.TuNgay = tuNgay;
                this.DenNgay = denNgay;
                this.Group = group;
            }
        }
        private class FilterCriteriaByTuNgayDenNgay
        {
            public DateTime TuNgay;
            public DateTime DenNgay;
            public bool ThanhToan;
            public bool PhieuChiMoi;
            public FilterCriteriaByTuNgayDenNgay(DateTime tuNgay, DateTime denNgay, bool thanhToan, bool phieuChiMoi)
            {
                this.TuNgay = tuNgay;
                this.DenNgay = denNgay;
                this.ThanhToan = thanhToan;
                this.PhieuChiMoi = phieuChiMoi;
            }
        }
        [Serializable()]
        private class FilterCriteriaByMaGiayXacNhanMaKyTinhLuong
        {
            public int maBoPhan;
            public int maChuongTrinh;
            public int maKyTinhLuong;
            public int MaChiTietGiayXacNhan;
            public string MaPhieuChi;
            public DateTime ngayLap;
            public bool TinhDangPhi;
            public bool ThanhToan;
            public FilterCriteriaByMaGiayXacNhanMaKyTinhLuong(int _maBoPhan, int _maChuongTrinh, int _maKyTinhLuong, int maChiTietGiayXacNhan, string maPhieuChi, DateTime ngayLap, bool tinhDangPhi, bool thanhToan)
            {
                this.maBoPhan = _maBoPhan;
                this.maChuongTrinh = _maChuongTrinh;
                this.maKyTinhLuong = _maKyTinhLuong;
                this.MaChiTietGiayXacNhan = maChiTietGiayXacNhan;
                this.MaPhieuChi = maPhieuChi;
                this.ngayLap = ngayLap;
                this.TinhDangPhi = tinhDangPhi;
                this.ThanhToan = thanhToan;
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
                catch (Exception ex)
                {

                    throw ex;
                }
            }//using

            RaiseListChangedEvents = true;
        }

        private void ExecuteFetch(SqlTransaction tr, object criteria)
        {
            int userID = 0;
            //if (Security.CurrentUser.IsAdmin == true && Security.CurrentUser.Info.MaCongTy==1)
            //    userID = 0;
            //else
            userID = Security.CurrentUser.Info.UserID;
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandTimeout = 0;

                if (criteria is FilterCriteriaByTuNgayDenNgay)
                {

                    cm.CommandText = "spd_DanhSachThuLao";
                    cm.Parameters.AddWithValue("@TuNgay", ((FilterCriteriaByTuNgayDenNgay)criteria).TuNgay);
                    cm.Parameters.AddWithValue("@DenNgay", ((FilterCriteriaByTuNgayDenNgay)criteria).DenNgay);
                    cm.Parameters.AddWithValue("@ThanhToan", ((FilterCriteriaByTuNgayDenNgay)criteria).ThanhToan);
                    cm.Parameters.AddWithValue("@PhieuChiMoi", ((FilterCriteriaByTuNgayDenNgay)criteria).PhieuChiMoi);
                    cm.Parameters.AddWithValue("@NguoiLap", userID);
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())//
                            this.Add(ThuLaoChuongTrinh.GetThuLaoChuongTrinhByNgayLap(dr));
                    }
                }
                else if (criteria is FilterCriteriaByMaGiayXacNhanMaKyTinhLuong)
                {

                    cm.CommandText = "spd_SelecttblnsThuLaoChuongTrinh_ByMaBoPhanKyLuongCT";
                    cm.Parameters.AddWithValue("@MaBoPhan", ((FilterCriteriaByMaGiayXacNhanMaKyTinhLuong)criteria).maBoPhan);
                    cm.Parameters.AddWithValue("@MaChuongTrinh", ((FilterCriteriaByMaGiayXacNhanMaKyTinhLuong)criteria).maChuongTrinh);
                    cm.Parameters.AddWithValue("@MaKyTinhLuong", ((FilterCriteriaByMaGiayXacNhanMaKyTinhLuong)criteria).maKyTinhLuong);
                    cm.Parameters.AddWithValue("@MaChiTietGiayXacNhan", ((FilterCriteriaByMaGiayXacNhanMaKyTinhLuong)criteria).MaChiTietGiayXacNhan);
                    cm.Parameters.AddWithValue("@MaPhieuChi", ((FilterCriteriaByMaGiayXacNhanMaKyTinhLuong)criteria).MaPhieuChi);
                    cm.Parameters.AddWithValue("@TinhDangPhi", ((FilterCriteriaByMaGiayXacNhanMaKyTinhLuong)criteria).TinhDangPhi);
                    cm.Parameters.AddWithValue("@ThanhToan", ((FilterCriteriaByMaGiayXacNhanMaKyTinhLuong)criteria).ThanhToan);
                    cm.Parameters.AddWithValue("@MaNguoiLap", userID);
                    cm.Parameters.AddWithValue("@NgayLap", ((FilterCriteriaByMaGiayXacNhanMaKyTinhLuong)criteria).ngayLap);
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(ThuLaoChuongTrinh.GetThuLaoChuongTrinh(dr));
                    }
                }
                else if (criteria is FilterCriteriaByPhieuChi)
                {

                    cm.CommandText = "spd_SelecttblnsThuLaoChuongTrinh_ByThanhToanTienMat";
                    cm.Parameters.AddWithValue("@MaBoPhan", ((FilterCriteriaByPhieuChi)criteria).maBoPhan);
                    cm.Parameters.AddWithValue("@MaChuongTrinh", ((FilterCriteriaByPhieuChi)criteria).maChuongTrinh);
                    cm.Parameters.AddWithValue("@MaKyTinhLuong", ((FilterCriteriaByPhieuChi)criteria).maKyTinhLuong);
                    cm.Parameters.AddWithValue("@MaPhieuChi", ((FilterCriteriaByPhieuChi)criteria).maPhieuChi);
                    cm.Parameters.AddWithValue("@TinhDangPhi", ((FilterCriteriaByPhieuChi)criteria).TinhDangPhi);
                    cm.Parameters.AddWithValue("@MaChiThuLao", ((FilterCriteriaByPhieuChi)criteria).MaChiThuLao);
                    cm.Parameters.AddWithValue("@MaChiTietGiayXacNhan", ((FilterCriteriaByPhieuChi)criteria).MaChiTietGiayXacNhan);
                    cm.Parameters.AddWithValue("@NgayLap", ((FilterCriteriaByPhieuChi)criteria).NgayLap.Date);
                    cm.Parameters.AddWithValue("@MaNguoiLap", userID);
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(ThuLaoChuongTrinh.GetThuLaoChuongTrinhByPhieuChi(dr));
                    }
                }
                else if (criteria is FilterCriteriaByCopyTienMat)
                {

                    cm.CommandText = "spd_SelecttblnsThuLaoChuongTrinh_ByThanhToanTienMat";
                    cm.Parameters.AddWithValue("@MaBoPhan", ((FilterCriteriaByCopyTienMat)criteria).maBoPhan);
                    cm.Parameters.AddWithValue("@MaChuongTrinh", ((FilterCriteriaByCopyTienMat)criteria).maChuongTrinh);
                    cm.Parameters.AddWithValue("@MaKyTinhLuong", ((FilterCriteriaByCopyTienMat)criteria).maKyTinhLuong);
                    cm.Parameters.AddWithValue("@MaPhieuChi", ((FilterCriteriaByCopyTienMat)criteria).maPhieuChi);
                    cm.Parameters.AddWithValue("@TinhDangPhi", ((FilterCriteriaByCopyTienMat)criteria).TinhDangPhi);
                    cm.Parameters.AddWithValue("@MaChiThuLao", ((FilterCriteriaByCopyTienMat)criteria).MaChiThuLao);
                    cm.Parameters.AddWithValue("@MaChiTietGiayXacNhan", ((FilterCriteriaByCopyTienMat)criteria).MaChiTietGiayXacNhan);
                    cm.Parameters.AddWithValue("@NgayLap", ((FilterCriteriaByCopyTienMat)criteria).NgayLap.Date);
                    cm.Parameters.AddWithValue("@MaNguoiLap", userID);
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(ThuLaoChuongTrinh.GetThuLaoChuongTrinhByCopyTienMat(dr));
                    }
                }
                else if (criteria is FilterCriteriaByPhieuChi1)
                {

                    cm.CommandText = "spd_SelecttblnsThuLaoChuongTrinh_ByTienMat";
                    cm.Parameters.AddWithValue("@MaBoPhan", ((FilterCriteriaByPhieuChi1)criteria).maBoPhan);
                    cm.Parameters.AddWithValue("@MaChuongTrinh", ((FilterCriteriaByPhieuChi1)criteria).maChuongTrinh);
                    cm.Parameters.AddWithValue("@MaKyTinhLuong", ((FilterCriteriaByPhieuChi1)criteria).maKyTinhLuong);
                    cm.Parameters.AddWithValue("@MaPhieuChi", ((FilterCriteriaByPhieuChi1)criteria).maPhieuChi);
                    //cm.Parameters.AddWithValue("@TinhDangPhi", ((FilterCriteriaByPhieuChi1)criteria).TinhDangPhi);
                    cm.Parameters.AddWithValue("@MaChiThuLao", ((FilterCriteriaByPhieuChi1)criteria).MaChiThuLao);
                    cm.Parameters.AddWithValue("@MaChiTietGiayXacNhan", ((FilterCriteriaByPhieuChi1)criteria).MaChiTietGiayXacNhan);
                    cm.Parameters.AddWithValue("@MaNguoiLap", userID);
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(ThuLaoChuongTrinh.GetThuLaoChuongTrinhByPhieuChi(dr));
                    }
                }
                else if (criteria is FilterCriteria)
                {
                    cm.CommandText = "spd_SelecttblnsThuLaoChuongTrinhesAll";
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(ThuLaoChuongTrinh.GetThuLaoChuongTrinh(dr));
                    }
                }
                else if (criteria is FilterCriteria_ByMaChungTu)
                {
                    cm.CommandText = "spd_SelecttblnsThuLaoChuongTrinh_ByMaChungTu";
                    cm.Parameters.AddWithValue("@MaChungTu", ((FilterCriteria_ByMaChungTu)criteria).MaChungTu);
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(ThuLaoChuongTrinh.GetThuLaoChuongTrinh(dr));
                    }
                }

                else if (criteria is FilterCriteria_ByBoPhan_NgayLap)
                {
                    cm.CommandText = "spd_SelecttblnsThuLaoChuongTrinh_ByBoPhan_NgayLap";
                    cm.Parameters.AddWithValue("@MaBoPhan", ((FilterCriteria_ByBoPhan_NgayLap)criteria)._maBoPhan);
                    cm.Parameters.AddWithValue("@NgayLap", ((FilterCriteria_ByBoPhan_NgayLap)criteria)._ngayLap);
                    cm.Parameters.AddWithValue("@MaKyTinhLuong", ((FilterCriteria_ByBoPhan_NgayLap)criteria)._maKyTinhLuong);
                    cm.Parameters.AddWithValue("@MaChuongTrinh", ((FilterCriteria_ByBoPhan_NgayLap)criteria)._maChuongTrinh);

                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(ThuLaoChuongTrinh.GetThuLaoChuongTrinh(dr));
                    }
                }
                else if (criteria is FilterCriteriaByChuongTrinh)
                {
                    cm.CommandText = "spd_SelecttblnsThuLaoChuongTrinh_ByMaChuongTrinh";
                    cm.Parameters.AddWithValue("@MaChuongTrinh", ((FilterCriteriaByChuongTrinh)criteria).MaChuongTrinh);
                    cm.Parameters.AddWithValue("@MaKyTinhLuong", ((FilterCriteriaByChuongTrinh)criteria).MaKyTinhLuong);
                    cm.Parameters.AddWithValue("@TuNgay", ((FilterCriteriaByChuongTrinh)criteria).TuNgay);
                    cm.Parameters.AddWithValue("@DenNgay", ((FilterCriteriaByChuongTrinh)criteria).DenNgay);
                    cm.Parameters.AddWithValue("@UserId", ERP_Library.Security.CurrentUser.Info.UserID);

                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(ThuLaoChuongTrinh.GetThuLaoChuongTrinh(dr));
                    }
                }
                else if (criteria is FilterCriteriaByMaGiayXacNhanMaKyTinhLuong)
                {
                    cm.CommandText = "spd_SelecttblnsThuLaoChuongTrinh_ByMaBoPhanKyLuongCT";
                    cm.Parameters.AddWithValue("@MaBoPhan", ((FilterCriteriaByMaGiayXacNhanMaKyTinhLuong)criteria).maBoPhan);
                    cm.Parameters.AddWithValue("@MaChuongTrinh", ((FilterCriteriaByMaGiayXacNhanMaKyTinhLuong)criteria).maChuongTrinh);
                    cm.Parameters.AddWithValue("@MaKyTinhLuong", ((FilterCriteriaByMaGiayXacNhanMaKyTinhLuong)criteria).maKyTinhLuong);
                    cm.Parameters.AddWithValue("@MaChiTietGiayXacNhan", ((FilterCriteriaByMaGiayXacNhanMaKyTinhLuong)criteria).MaChiTietGiayXacNhan);
                    cm.Parameters.AddWithValue("@MaPhieuChi", ((FilterCriteriaByMaGiayXacNhanMaKyTinhLuong)criteria).MaPhieuChi);
                    cm.Parameters.AddWithValue("@MaNguoiLap", userID);
                    cm.Parameters.AddWithValue("@NgayLap", ((FilterCriteriaByMaGiayXacNhanMaKyTinhLuong)criteria).ngayLap);
                    cm.Parameters.AddWithValue("@TinhDangPhi", ((FilterCriteriaByMaGiayXacNhanMaKyTinhLuong)criteria).TinhDangPhi);
                    cm.Parameters.AddWithValue("@ThanhToan", ((FilterCriteriaByMaGiayXacNhanMaKyTinhLuong)criteria).ThanhToan);
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(ThuLaoChuongTrinh.GetThuLaoChuongTrinh(dr));
                    }
                }
                else if (criteria is FilterCriteriaByPhieuChi)
                {
                    try
                    {
                        cm.CommandText = "spd_SelecttblnsThuLaoChuongTrinh_ByThanhToanTienMat";
                        cm.Parameters.AddWithValue("@MaBoPhan", ((FilterCriteriaByPhieuChi)criteria).maBoPhan);
                        cm.Parameters.AddWithValue("@MaChuongTrinh", ((FilterCriteriaByPhieuChi)criteria).maChuongTrinh);
                        cm.Parameters.AddWithValue("@MaKyTinhLuong", ((FilterCriteriaByPhieuChi)criteria).maKyTinhLuong);
                        cm.Parameters.AddWithValue("@MaPhieuChi", ((FilterCriteriaByPhieuChi)criteria).maPhieuChi);
                        cm.Parameters.AddWithValue("@TinhDangPhi", ((FilterCriteriaByPhieuChi)criteria).TinhDangPhi);
                        cm.Parameters.AddWithValue("@NgayLap", ((FilterCriteriaByPhieuChi)criteria).NgayLap.Date);

                        cm.Parameters.AddWithValue("@MaNguoiLap", userID);
                        using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                        {
                            while (dr.Read())
                                this.Add(ThuLaoChuongTrinh.GetThuLaoChuongTrinhByPhieuChi(dr));
                        }
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
                else if (criteria is FilterCriteriaByTuNgayDenNgay)
                {

                    cm.CommandText = "spd_DanhSachThuLao";
                    cm.Parameters.AddWithValue("@TuNgay", ((FilterCriteriaByTuNgayDenNgay)criteria).TuNgay);
                    cm.Parameters.AddWithValue("@DenNgay", ((FilterCriteriaByTuNgayDenNgay)criteria).DenNgay);
                    cm.Parameters.AddWithValue("@ThanhToan", ((FilterCriteriaByTuNgayDenNgay)criteria).ThanhToan);
                    cm.Parameters.AddWithValue("@PhieuChiMoi", ((FilterCriteriaByTuNgayDenNgay)criteria).PhieuChiMoi);
                    cm.Parameters.AddWithValue("@NguoiLap", userID);

                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(ThuLaoChuongTrinh.GetThuLaoChuongTrinhByNgayLap(dr));
                    }
                }
                else if (criteria is FilterCriteriaByChuyenKhoan)
                {
                    cm.CommandText = "spd_SelecttblnsThuLaoChuongTrinh_ByChuyenKhoan";
                    cm.Parameters.AddWithValue("@MaChuongTrinh", ((FilterCriteriaByChuyenKhoan)criteria).MaChuongTrinh);
                    cm.Parameters.AddWithValue("@MaKyTinhLuong", ((FilterCriteriaByChuyenKhoan)criteria).MaKyTinhLuong);
                    cm.Parameters.AddWithValue("@MaChiTietGiayXacNhan", ((FilterCriteriaByChuyenKhoan)criteria).MaChiTietGiayXacNhan);
                    cm.Parameters.AddWithValue("@NguoiLap", userID);
                    cm.Parameters.AddWithValue("@TinhDangPhi", ((FilterCriteriaByChuyenKhoan)criteria).TinhDangPhi);
                    cm.Parameters.AddWithValue("@NgayLap", ((FilterCriteriaByChuyenKhoan)criteria).NgayLap);
                    cm.Parameters.AddWithValue("@MaChiThuLao", ((FilterCriteriaByChuyenKhoan)criteria).MaChiThuLao);
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(ThuLaoChuongTrinh.GetThuLaoChuongTrinh(dr));
                    }
                }
                else if (criteria is FilterCriteriaByCopy)
                {
                    cm.CommandText = "spd_SelecttblnsThuLaoChuongTrinh_ByChuyenKhoan";
                    cm.Parameters.AddWithValue("@MaChuongTrinh", ((FilterCriteriaByCopy)criteria).MaChuongTrinh);
                    cm.Parameters.AddWithValue("@MaKyTinhLuong", ((FilterCriteriaByCopy)criteria).MaKyTinhLuong);
                    cm.Parameters.AddWithValue("@MaChiTietGiayXacNhan", ((FilterCriteriaByCopy)criteria).MaChiTietGiayXacNhan);
                    cm.Parameters.AddWithValue("@NguoiLap", userID);
                    cm.Parameters.AddWithValue("@TinhDangPhi", ((FilterCriteriaByCopy)criteria).TinhDangPhi);
                    cm.Parameters.AddWithValue("@NgayLap", ((FilterCriteriaByCopy)criteria).NgayLap);
                    cm.Parameters.AddWithValue("@MaChiThuLao", ((FilterCriteriaByCopy)criteria).MaChiThuLao);
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(ThuLaoChuongTrinh.GetThuLaoChuongTrinhByNew(dr));
                    }
                }
                else if (criteria is FilterCriteriaByChuaChuyenKhoan)
                {

                    cm.CommandText = "spd_DanhSachThuLaoChuaChuyenKhoan";
                    cm.Parameters.AddWithValue("@TuNgay", ((FilterCriteriaByChuaChuyenKhoan)criteria).TuNgay);
                    cm.Parameters.AddWithValue("@DenNgay", ((FilterCriteriaByChuaChuyenKhoan)criteria).DenNgay);
                    cm.Parameters.AddWithValue("@group", ((FilterCriteriaByChuaChuyenKhoan)criteria).Group);
                    cm.Parameters.AddWithValue("@UserID", userID);
                    if (((FilterCriteriaByChuaChuyenKhoan)criteria).Group == true)
                    {

                        using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                        {
                            while (dr.Read())
                                this.Add(ThuLaoChuongTrinh.GetThuLaoChuongTrinhByNgayLap(dr));
                        }
                    }
                    else
                    {
                        using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                        {
                            while (dr.Read())
                                this.Add(ThuLaoChuongTrinh.GetThuLaoChuongTrinh(dr));
                        }

                    }
                }
                else if (criteria is FilterCriteriaByChuaChuyenKhoan_Modify)
                {
                    cm.CommandText = "spd_DanhSachThuLaoChuaChuyenKhoan_Modify";
                    cm.Parameters.AddWithValue("@TuNgay", ((FilterCriteriaByChuaChuyenKhoan_Modify)criteria).TuNgay);
                    cm.Parameters.AddWithValue("@DenNgay", ((FilterCriteriaByChuaChuyenKhoan_Modify)criteria).DenNgay);
                    cm.Parameters.AddWithValue("@group", ((FilterCriteriaByChuaChuyenKhoan_Modify)criteria).Group);
                    cm.Parameters.AddWithValue("@UserID", userID);
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        if (((FilterCriteriaByChuaChuyenKhoan_Modify)criteria).Group == true)
                        {
                            while (dr.Read())
                                this.Add(ThuLaoChuongTrinh.GetThuLaoChuongTrinhByNgayLap(dr));
                        }
                        else
                        {
                            while (dr.Read())
                                this.Add(ThuLaoChuongTrinh.GetThuLaoChuongTrinh(dr));
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
                    foreach (ThuLaoChuongTrinh deletedChild in DeletedList)
                        deletedChild.DeleteSelf(tr);
                    DeletedList.Clear();

                    // loop through each non-deleted child object
                    foreach (ThuLaoChuongTrinh child in this)
                    {
                        if (child.IsNew)
                            child.Insert(tr, this);
                        else
                            child.Update(tr, this);
                    }

                    tr.Commit();
                }
                catch (Exception ex)
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
