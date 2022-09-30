
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{
    [Serializable()]
    public class ThuLaoNhanVienNgoaiDaiList : Csla.BusinessListBase<ThuLaoNhanVienNgoaiDaiList, ThuLaoNhanVienNgoaiDai>
    {
        #region BindingList Overrides
        protected override object AddNewCore()
        {
            ThuLaoNhanVienNgoaiDai item = ThuLaoNhanVienNgoaiDai.NewThuLaoNhanVienNgoaiDai();
            this.Add(item);
            return item;
        }
        #endregion //BindingList Overrides
        #region Factory Methods
        private ThuLaoNhanVienNgoaiDaiList()
        { /* require use of factory method */ }
        public static ThuLaoNhanVienNgoaiDaiList NewThuLaoNhanVienNgoaiDaiList()
        {
            return new ThuLaoNhanVienNgoaiDaiList();
        }

        public static ThuLaoNhanVienNgoaiDaiList GetThuLaoNhanVienNgoaiDaiList()
        {
            return DataPortal.Fetch<ThuLaoNhanVienNgoaiDaiList>(new FilterCriteria());
        }
        public static ThuLaoNhanVienNgoaiDaiList GetThuLaoChuongTrinhListByPhieuChi(int maBoPhan, int maChuongTrinh, int maKyTinhLuong, string maPhieuChi, long maChiThuLao, int maChiTietGiayXacNhan, bool thanhToan, DateTime ngayLap)
        {
            return DataPortal.Fetch<ThuLaoNhanVienNgoaiDaiList>(new FilterCriteriaByPhieuChi(maBoPhan, maChuongTrinh, maKyTinhLuong, maPhieuChi, maChiThuLao, maChiTietGiayXacNhan, thanhToan, ngayLap));
        }

        public static ThuLaoNhanVienNgoaiDaiList GetThuLaoChuongTrinhList_MaPhieuChi(long maPhieuChi)
        {
            return DataPortal.Fetch<ThuLaoNhanVienNgoaiDaiList>(new FilterCriteriaByPhieuChi_MaPhieuChi(maPhieuChi));
        }

        public static ThuLaoNhanVienNgoaiDaiList GetThuLaoChuongTrinhListByNgayLap(DateTime dateTime, DateTime dateTime_2, bool thanhToan)
        {
            return DataPortal.Fetch<ThuLaoNhanVienNgoaiDaiList>(new FilterCriteriaByTheoNgay(dateTime, dateTime_2, thanhToan));
        }
        public static ThuLaoNhanVienNgoaiDaiList GetThuLaoChuongTrinhListByNgayLap_MaLoaiChi(DateTime dateTime, DateTime dateTime_2, bool thanhToan, int maLoaiChi)
        {
            return DataPortal.Fetch<ThuLaoNhanVienNgoaiDaiList>(new FilterCriteriaByTheoNgay_MaLoaiChi(dateTime, dateTime_2, thanhToan, maLoaiChi));
        }
        public static ThuLaoNhanVienNgoaiDaiList GetTacQuyenListByNgayLap(DateTime dateTime, DateTime dateTime_2, bool thanhToan)
        {
            return DataPortal.Fetch<ThuLaoNhanVienNgoaiDaiList>(new FilterCriteriaTacQuyenByTheoNgay(dateTime, dateTime_2, thanhToan));
        }

        public static ThuLaoNhanVienNgoaiDaiList GetLoaiKhacListByNgayLap(DateTime dateTime, DateTime dateTime_2, bool thanhToan)
        {
            return DataPortal.Fetch<ThuLaoNhanVienNgoaiDaiList>(new FilterCriteriaLoaiKhacByTheoNgay(dateTime, dateTime_2, thanhToan));
        }
        public static ThuLaoNhanVienNgoaiDaiList GetKhenThuongListByNgayLap(DateTime dateTime, DateTime dateTime_2, bool thanhToan)
        {
            return DataPortal.Fetch<ThuLaoNhanVienNgoaiDaiList>(new FilterCriteriaKhenThuongByTheoNgay(dateTime, dateTime_2, thanhToan));
        }
        public static ThuLaoNhanVienNgoaiDaiList GetThuLaoChuongTrinhListByChuaChuyenKhoan(DateTime tuNgay, DateTime denNgay, bool group)
        {
            return DataPortal.Fetch<ThuLaoNhanVienNgoaiDaiList>(new FilterCriteriaByChuaChuyenKhoan(tuNgay, denNgay, group));
        }
        public static ThuLaoNhanVienNgoaiDaiList GetThuLaoChuongTrinhListByChuaChuyenKhoan_Modify(DateTime tuNgay, DateTime denNgay, bool group)
        {
            return DataPortal.Fetch<ThuLaoNhanVienNgoaiDaiList>(new FilterCriteriaByChuaChuyenKhoan_Modify(tuNgay, denNgay, group));
        }
        public static ThuLaoNhanVienNgoaiDaiList GetThuLaoChuongTrinhNgoaiDaiListByCopy(int maBoPhan, int maChuongTrinh, int maKyTinhLuong, string maPhieuChi, long maChiThuLao, int maChiTietGiayXacNhan, DateTime ngayLap)
        {

            return DataPortal.Fetch<ThuLaoNhanVienNgoaiDaiList>(new FilterCriteriaByCopyTienMat(maBoPhan, maChuongTrinh, maKyTinhLuong, maPhieuChi, maChiThuLao, maChiTietGiayXacNhan, ngayLap));
        }

        public static ThuLaoNhanVienNgoaiDaiList GetThuLaoChuongTrinhListByBoPhan_NgayLap(int maBoPhan, DateTime ngayLap, int maKyTinhLuong, int maChuongTrinh)
        {
            return DataPortal.Fetch<ThuLaoNhanVienNgoaiDaiList>(new FilterCriteria_ByBoPhan_NgayLap(maBoPhan, ngayLap, maKyTinhLuong, maChuongTrinh));
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

        private class FilterCriteriaByTheoNgay
        {
            public DateTime Tungay;
            public DateTime DenNgay;
            public bool ThanhToan;
            public FilterCriteriaByTheoNgay(DateTime tuNgay, DateTime denNgay, bool thanhToan)
            {
                this.Tungay = tuNgay;
                this.DenNgay = denNgay;
                this.ThanhToan = thanhToan;
            }
        }

        private class FilterCriteriaByTheoNgay_MaLoaiChi
        {
            public DateTime Tungay;
            public DateTime DenNgay;
            public bool ThanhToan;
            public int MaLoaiChi;
            public FilterCriteriaByTheoNgay_MaLoaiChi(DateTime tuNgay, DateTime denNgay, bool thanhToan, int maLoaiChi)
            {
                this.Tungay = tuNgay;
                this.DenNgay = denNgay;
                this.ThanhToan = thanhToan;
                this.MaLoaiChi = maLoaiChi;
            }
        }

        private class FilterCriteriaTacQuyenByTheoNgay
        {
            public DateTime Tungay;
            public DateTime DenNgay;
            public bool ThanhToan;
            public FilterCriteriaTacQuyenByTheoNgay(DateTime tuNgay, DateTime denNgay, bool thanhToan)
            {
                this.Tungay = tuNgay;
                this.DenNgay = denNgay;
                this.ThanhToan = thanhToan;
            }
        }

        private class FilterCriteriaLoaiKhacByTheoNgay
        {
            public DateTime Tungay;
            public DateTime DenNgay;
            public bool ThanhToan;
            public FilterCriteriaLoaiKhacByTheoNgay(DateTime tuNgay, DateTime denNgay, bool thanhToan)
            {
                this.Tungay = tuNgay;
                this.DenNgay = denNgay;
                this.ThanhToan = thanhToan;
            }
        }

        private class FilterCriteriaKhenThuongByTheoNgay
        {
            public DateTime Tungay;
            public DateTime DenNgay;
            public bool ThanhToan;
            public FilterCriteriaKhenThuongByTheoNgay(DateTime tuNgay, DateTime denNgay, bool thanhToan)
            {
                this.Tungay = tuNgay;
                this.DenNgay = denNgay;
                this.ThanhToan = thanhToan;
            }
        }

        private class FilterCriteriaByPhieuChi
        {
            public int maBoPhan;
            public int maChuongTrinh;
            public int maKyTinhLuong;
            public string maPhieuChi;
            public long MaChiThuLao;
            public int MaChiTietGiayXacNhan;
            public bool ThanhToan;
            public DateTime NgayLap;
            public FilterCriteriaByPhieuChi(int _maBoPhan, int _maChuongTrinh, int _maKyTinhLuong, string _maPhieuChi, long maChiThuLao, int maChiTietGiayXacNhan, bool thanhToan, DateTime ngayLap)
            {
                this.maBoPhan = _maBoPhan;
                this.maChuongTrinh = _maChuongTrinh;
                this.maKyTinhLuong = _maKyTinhLuong;
                this.maPhieuChi = _maPhieuChi;
                this.MaChiThuLao = maChiThuLao;
                this.MaChiTietGiayXacNhan = maChiTietGiayXacNhan;
                this.ThanhToan = thanhToan;
                this.NgayLap = ngayLap;
            }
        }

        private class FilterCriteriaByPhieuChi_MaPhieuChi
        {
            public long MaPhieuChi;
            public FilterCriteriaByPhieuChi_MaPhieuChi(long maPhieuChi)
            {
                this.MaPhieuChi = maPhieuChi;
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
            public FilterCriteriaByCopyTienMat(int _maBoPhan, int _maChuongTrinh, int _maKyTinhLuong, string _maPhieuChi, long maChiThuLao, int maChiTietGiayXacNhan, DateTime ngayLap)
            {
                this.maBoPhan = _maBoPhan;
                this.maChuongTrinh = _maChuongTrinh;
                this.maKyTinhLuong = _maKyTinhLuong;
                this.maPhieuChi = _maPhieuChi;
                this.MaChiThuLao = maChiThuLao;
                this.MaChiTietGiayXacNhan = maChiTietGiayXacNhan;
                this.NgayLap = ngayLap;
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
                cm.CommandTimeout = 90;
                cm.CommandType = CommandType.StoredProcedure;
                if (criteria is FilterCriteria)
                {
                    cm.CommandText = "GetThuLaoNhanVienNgoaiDaiList";
                }
                else if (criteria is FilterCriteriaByPhieuChi)
                {
                    cm.CommandText = "spd_SelecttblnsThuLaoNgoaiDaiTienMat";
                    cm.Parameters.AddWithValue("@MaBoPhan", ((FilterCriteriaByPhieuChi)criteria).maBoPhan);
                    cm.Parameters.AddWithValue("@MaChuongTrinh", ((FilterCriteriaByPhieuChi)criteria).maChuongTrinh);
                    cm.Parameters.AddWithValue("@MaKyTinhLuong", ((FilterCriteriaByPhieuChi)criteria).maKyTinhLuong);
                    cm.Parameters.AddWithValue("@MaPhieuChi", ((FilterCriteriaByPhieuChi)criteria).maPhieuChi);
                    cm.Parameters.AddWithValue("@ThanhToan", ((FilterCriteriaByPhieuChi)criteria).ThanhToan);
                    cm.Parameters.AddWithValue("@MaChiThuLao", ((FilterCriteriaByPhieuChi)criteria).MaChiThuLao);
                    cm.Parameters.AddWithValue("@MaChiTietGiayXacNhan", ((FilterCriteriaByPhieuChi)criteria).MaChiTietGiayXacNhan);
                    cm.Parameters.AddWithValue("@MaNguoiLap", ERP_Library.Security.CurrentUser.Info.UserID);
                    cm.Parameters.AddWithValue("@NgayLap", ((FilterCriteriaByPhieuChi)criteria).NgayLap);
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(ThuLaoNhanVienNgoaiDai.GetThuLaoNhanVienNgoaiDai(dr));
                    }
                }

                else if (criteria is FilterCriteriaByPhieuChi_MaPhieuChi)
                {
                    cm.CommandText = "spd_SelecttblnsThuLaoNgoaiDaiTienMatbyMaPhieuChi";
                    cm.Parameters.AddWithValue("@MaPhieuChi", ((FilterCriteriaByPhieuChi_MaPhieuChi)criteria).MaPhieuChi);
                    cm.Parameters.AddWithValue("@MaNguoiLap", ERP_Library.Security.CurrentUser.Info.UserID);
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(ThuLaoNhanVienNgoaiDai.GetThuLaoNhanVienNgoaiDai(dr));
                    }
                }

                else if (criteria is FilterCriteria_ByBoPhan_NgayLap)
                {
                    cm.CommandText = "spd_SelecttblnsThuLaoNhanVienNgoaiDai_ByBoPhan_NgayLap";
                    cm.Parameters.AddWithValue("@MaBoPhan", ((FilterCriteria_ByBoPhan_NgayLap)criteria)._maBoPhan);
                    cm.Parameters.AddWithValue("@NgayLap", ((FilterCriteria_ByBoPhan_NgayLap)criteria)._ngayLap);
                    cm.Parameters.AddWithValue("@MaKyTinhLuong", ((FilterCriteria_ByBoPhan_NgayLap)criteria)._maKyTinhLuong);
                    cm.Parameters.AddWithValue("@MaChuongTrinh", ((FilterCriteria_ByBoPhan_NgayLap)criteria)._maChuongTrinh);
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(ThuLaoNhanVienNgoaiDai.GetThuLaoNhanVienNgoaiDai(dr));
                    }
                }
                else if (criteria is FilterCriteriaByTheoNgay)
                {
                    cm.CommandText = "spd_DanhSachThuLaoNgoaiDai";
                    cm.Parameters.AddWithValue("@TuNgay", ((FilterCriteriaByTheoNgay)criteria).Tungay);
                    cm.Parameters.AddWithValue("@DenNgay", ((FilterCriteriaByTheoNgay)criteria).DenNgay);
                    cm.Parameters.AddWithValue("@ThanhToan", ((FilterCriteriaByTheoNgay)criteria).ThanhToan);
                    cm.Parameters.AddWithValue("@NguoiLap", ERP_Library.Security.CurrentUser.Info.UserID);
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(ThuLaoNhanVienNgoaiDai.GetThuLaoChuongTrinhByNgayLap(dr));
                    }
                }

                else if (criteria is FilterCriteriaByTheoNgay_MaLoaiChi)
                {
                    cm.CommandText = "spd_DanhSachThuLaoNgoaiDai_MaLoaiChi";
                    cm.Parameters.AddWithValue("@TuNgay", ((FilterCriteriaByTheoNgay_MaLoaiChi)criteria).Tungay);
                    cm.Parameters.AddWithValue("@DenNgay", ((FilterCriteriaByTheoNgay_MaLoaiChi)criteria).DenNgay);
                    cm.Parameters.AddWithValue("@ThanhToan", ((FilterCriteriaByTheoNgay_MaLoaiChi)criteria).ThanhToan);
                    cm.Parameters.AddWithValue("@MaLoaiChi", ((FilterCriteriaByTheoNgay_MaLoaiChi)criteria).MaLoaiChi);
                    cm.Parameters.AddWithValue("@NguoiLap", ERP_Library.Security.CurrentUser.Info.UserID);
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(ThuLaoNhanVienNgoaiDai.GetThuLaoChuongTrinhByNgayLap(dr));
                    }
                }

                else if (criteria is FilterCriteriaTacQuyenByTheoNgay)
                {
                    cm.CommandText = "spd_DanhSachTacQuyen";
                    cm.Parameters.AddWithValue("@TuNgay", ((FilterCriteriaTacQuyenByTheoNgay)criteria).Tungay);
                    cm.Parameters.AddWithValue("@DenNgay", ((FilterCriteriaTacQuyenByTheoNgay)criteria).DenNgay);
                    cm.Parameters.AddWithValue("@ThanhToan", ((FilterCriteriaTacQuyenByTheoNgay)criteria).ThanhToan);
                    cm.Parameters.AddWithValue("@NguoiLap", ERP_Library.Security.CurrentUser.Info.UserID);
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(ThuLaoNhanVienNgoaiDai.GetThuLaoChuongTrinhByNgayLap(dr));
                    }
                }

                else if (criteria is FilterCriteriaLoaiKhacByTheoNgay)
                {
                    cm.CommandText = "spd_DanhSachLoaiKhac";
                    cm.Parameters.AddWithValue("@TuNgay", ((FilterCriteriaLoaiKhacByTheoNgay)criteria).Tungay);
                    cm.Parameters.AddWithValue("@DenNgay", ((FilterCriteriaLoaiKhacByTheoNgay)criteria).DenNgay);
                    cm.Parameters.AddWithValue("@ThanhToan", ((FilterCriteriaLoaiKhacByTheoNgay)criteria).ThanhToan);
                    cm.Parameters.AddWithValue("@NguoiLap", ERP_Library.Security.CurrentUser.Info.UserID);
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(ThuLaoNhanVienNgoaiDai.GetThuLaoChuongTrinhByNgayLap(dr));
                    }
                }
                else if (criteria is FilterCriteriaKhenThuongByTheoNgay)
                {
                    cm.CommandText = "spd_DanhSachKhenThuong";
                    cm.Parameters.AddWithValue("@TuNgay", ((FilterCriteriaKhenThuongByTheoNgay)criteria).Tungay);
                    cm.Parameters.AddWithValue("@DenNgay", ((FilterCriteriaKhenThuongByTheoNgay)criteria).DenNgay);
                    cm.Parameters.AddWithValue("@ThanhToan", ((FilterCriteriaKhenThuongByTheoNgay)criteria).ThanhToan);
                    cm.Parameters.AddWithValue("@NguoiLap", ERP_Library.Security.CurrentUser.Info.UserID);
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(ThuLaoNhanVienNgoaiDai.GetThuLaoChuongTrinhByNgayLap(dr));
                    }
                }
                else if (criteria is FilterCriteriaByCopyTienMat)
                {
                    cm.CommandText = "spd_SelecttblnsThuLaoChuongTrinh_ByThanhToanNgoaiDai";
                    cm.Parameters.AddWithValue("@MaBoPhan", ((FilterCriteriaByCopyTienMat)criteria).maBoPhan);
                    cm.Parameters.AddWithValue("@MaChuongTrinh", ((FilterCriteriaByCopyTienMat)criteria).maChuongTrinh);
                    cm.Parameters.AddWithValue("@MaKyTinhLuong", ((FilterCriteriaByCopyTienMat)criteria).maKyTinhLuong);
                    cm.Parameters.AddWithValue("@MaPhieuChi", ((FilterCriteriaByCopyTienMat)criteria).maPhieuChi);
                    cm.Parameters.AddWithValue("@MaChiThuLao", ((FilterCriteriaByCopyTienMat)criteria).MaChiThuLao);
                    cm.Parameters.AddWithValue("@MaChiTietGiayXacNhan", ((FilterCriteriaByCopyTienMat)criteria).MaChiTietGiayXacNhan);
                    cm.Parameters.AddWithValue("@NgayLap", ((FilterCriteriaByCopyTienMat)criteria).NgayLap.Date);
                    cm.Parameters.AddWithValue("@MaNguoiLap", ERP_Library.Security.CurrentUser.Info.UserID);
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(ThuLaoNhanVienNgoaiDai.GetThuLaoNgoaiDaiByCopyTienMat(dr));
                    }
                }
                else if (criteria is FilterCriteriaByChuaChuyenKhoan_Modify)
                {
                    cm.CommandText = "spd_DanhSachThuLaoCTVChuaChuyenKhoan_Modify";
                    cm.Parameters.AddWithValue("@TuNgay", ((FilterCriteriaByChuaChuyenKhoan_Modify)criteria).TuNgay);
                    cm.Parameters.AddWithValue("@DenNgay", ((FilterCriteriaByChuaChuyenKhoan_Modify)criteria).DenNgay);
                    cm.Parameters.AddWithValue("@group", ((FilterCriteriaByChuaChuyenKhoan_Modify)criteria).Group);
                    cm.Parameters.AddWithValue("@UserID", ERP_Library.Security.CurrentUser.Info.UserID);
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        if (((FilterCriteriaByChuaChuyenKhoan_Modify)criteria).Group == true)
                        {
                            while (dr.Read())
                                this.Add(ThuLaoNhanVienNgoaiDai.GetThuLaoChuongTrinhByNgayLap(dr));
                        }
                        else
                        {
                            while (dr.Read())
                                this.Add(ThuLaoNhanVienNgoaiDai.GetThuLaoNhanVienNgoaiDai(dr));
                        }
                    }
                }
                else if (criteria is FilterCriteriaByChuaChuyenKhoan)
                {
                    if (((FilterCriteriaByChuaChuyenKhoan)criteria).Group == true)
                    {
                        cm.CommandText = "spd_DanhSachThuLaoCTVChuaChuyenKhoanLong";
                        cm.Parameters.AddWithValue("@TuNgay", ((FilterCriteriaByChuaChuyenKhoan)criteria).TuNgay);
                        cm.Parameters.AddWithValue("@DenNgay", ((FilterCriteriaByChuaChuyenKhoan)criteria).DenNgay);
                        cm.Parameters.AddWithValue("@group", ((FilterCriteriaByChuaChuyenKhoan)criteria).Group);
                        cm.Parameters.AddWithValue("@UserID", ERP_Library.Security.CurrentUser.Info.UserID);
                        using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                        {
                            while (dr.Read())
                                this.Add(ThuLaoNhanVienNgoaiDai.GetThuLaoChuongTrinhByNgayLap(dr));
                        }
                    }
                    else
                    {
                        cm.CommandText = "spd_DanhSachThuLaoCTVChuaChuyenKhoanLong";
                        cm.Parameters.AddWithValue("@TuNgay", ((FilterCriteriaByChuaChuyenKhoan)criteria).TuNgay);
                        cm.Parameters.AddWithValue("@DenNgay", ((FilterCriteriaByChuaChuyenKhoan)criteria).DenNgay);
                        cm.Parameters.AddWithValue("@group", ((FilterCriteriaByChuaChuyenKhoan)criteria).Group);
                        cm.Parameters.AddWithValue("@UserID", ERP_Library.Security.CurrentUser.Info.UserID);
                        using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                        {
                            while (dr.Read())
                                this.Add(ThuLaoNhanVienNgoaiDai.GetThuLaoNhanVienNgoaiDai(dr));
                        }

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
                    foreach (ThuLaoNhanVienNgoaiDai deletedChild in DeletedList)
                        deletedChild.DeleteSelf(tr);
                    DeletedList.Clear();

                    // loop through each non-deleted child object
                    foreach (ThuLaoNhanVienNgoaiDai child in this)
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
                    throw ex;
                }
            }//using SqlConnection

            RaiseListChangedEvents = true;
        }
        #endregion //Data Access - Update
        #endregion //Data Access


    }
}
