
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{
    //Thành
    [Serializable()]
    public class HopDongThuChiList : Csla.BusinessListBase<HopDongThuChiList, HopDongThuChi>
    {
        #region BindingList Overrides
        protected override object AddNewCore()
        {
            HopDongThuChi item = HopDongThuChi.NewHopDongMuaBan();
            this.Add(item);
            return item;
        }
        #endregion //BindingList Overrides

        #region Authorization Rules

        public static bool CanGetObject()
        {
            //TODO: Define CanGetObject permission in HopDongThuChiList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("HopDongThuChiListViewGroup"))
            //	return true;
            //return false;
        }

        public static bool CanAddObject()
        {
            //TODO: Define CanAddObject permission in HopDongThuChiList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("HopDongThuChiListAddGroup"))
            //	return true;
            //return false;
        }

        public static bool CanEditObject()
        {
            //TODO: Define CanEditObject permission in HopDongThuChiList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("HopDongThuChiListEditGroup"))
            //	return true;
            //return false;
        }

        public static bool CanDeleteObject()
        {
            //TODO: Define CanDeleteObject permission in HopDongThuChiList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("HopDongThuChiListDeleteGroup"))
            //	return true;
            //return false;
        }
        #endregion //Authorization Rules

        #region Factory Methods
        private HopDongThuChiList()
        { /* require use of factory method */ }

        public static HopDongThuChiList NewHopDongMuaBanList()
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a HopDongThuChiList");
            return new HopDongThuChiList();
        }

        public static HopDongThuChiList GetHopDongMuaBanList()
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a HopDongThuChiList");
            return DataPortal.Fetch<HopDongThuChiList>(new FilterCriteria());
        }

        public static HopDongThuChiList GetHopDongMuaBanList(DateTime TuNgay, DateTime DenNgay)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a HopDongThuChiList");
            return DataPortal.Fetch<HopDongThuChiList>(new FilterCriteriabyNgayLap(TuNgay, DenNgay));
        }

        public static HopDongThuChiList GetHopDongMuaBanList_ChuaLapDeNghi()
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a HopDongThuChiList");
            return DataPortal.Fetch<HopDongThuChiList>(new FilterCriteriaby_ChuaLapDeNghi());
        }

        public static HopDongThuChiList GetHopDongMuaBanList_TheoDoiTac(long maDoiTac)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a HopDongThuChiList");
            return DataPortal.Fetch<HopDongThuChiList>(new FilterCriteriaby_TheoDoiTac(maDoiTac));
        }

        public static HopDongThuChiList GetHopDongMuaBanList(short Loai)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a HopDongThuChiList");
            return DataPortal.Fetch<HopDongThuChiList>(new FilterCriteriaByLoai(Loai));
        }

        public static HopDongThuChiList GetHopDongMuaBanList(short Loai, string ChuoiTimKiem, bool MuaBan)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a HopDongThuChiList");
            return DataPortal.Fetch<HopDongThuChiList>(new FilterCriteriaByTimHopDong(Loai, ChuoiTimKiem, MuaBan));
        }

        public static HopDongThuChiList GetHopDongMuaBanList(short Loai, string ChuoiTimKiem, bool MuaBan, string ChuoiHHDV, DateTime tuNgay, DateTime denNgay)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a HopDongThuChiList");
            return DataPortal.Fetch<HopDongThuChiList>(new FilterCriteriaByFull(Loai, ChuoiTimKiem, MuaBan, ChuoiHHDV, tuNgay, denNgay));
        }
        //M
        public static HopDongThuChiList GetHopDongMuaBanList(int loaiHopDong, long maDoiTac, byte TinhTrang)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a HopDongThuChiList");
            return DataPortal.Fetch<HopDongThuChiList>(new FilterCriteriaByLapPhieu(loaiHopDong, maDoiTac, TinhTrang));
        }
        public static HopDongThuChiList GetHopDongMuaBanList(long maPhieuNhapXuat)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a HopDongThuChiList");
            return DataPortal.Fetch<HopDongThuChiList>(new FilterCriteriaByMaPhieuNhapXuat(maPhieuNhapXuat));
        }
        //END M

        public static HopDongThuChiList GetHopDongMuaBanTaiSanList(short Loai, string ChuoiTimKiem)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a HopDongThuChiList");
            return DataPortal.Fetch<HopDongThuChiList>(new FilterCriteriaByTimHopDongTaiSan(Loai, ChuoiTimKiem));
        }

        public static HopDongThuChiList GetHopDongMuaBanByUserID()
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a HopDongThuChiList");
            return DataPortal.Fetch<HopDongThuChiList>(new FilterCriteriaByUserID());
        }
        public static HopDongThuChiList GetHopDongMuaBanByMaDoiTac_MaCongTy(long madoitac)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a HopDongThuChiList");
            return DataPortal.Fetch<HopDongThuChiList>(new FilterCriteriaByMaCongTy_MaDoiTac(madoitac));
        }

        public static HopDongThuChiList GetHopDongMuaBanByUserID_MaLoaiHopDong(int maLoaiHopDong)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a HopDongThuChiList");
            return DataPortal.Fetch<HopDongThuChiList>(new FilterCriteriaByUserID_MaLoaiHopDong(maLoaiHopDong));
        }

        public static HopDongThuChiList GetHopDongMuaBanByNgayKy(DateTime _tuNgay, DateTime _denNgay,int _maLoaiHopDong, int _maPhanLoaiHD, long _maDoiTac, int _maDonViChuQuan, int _maDinhKhoan)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a HopDongThuChiList");
            return DataPortal.Fetch<HopDongThuChiList>(new FilterCriteriaSearchByNgayKy(_tuNgay, _denNgay,_maLoaiHopDong, _maPhanLoaiHD, _maDoiTac, _maDonViChuQuan, _maDinhKhoan));
        }
        public static HopDongThuChiList GetHopDongMuaBanByWithoutNgayKy(int _maLoaiHopDong, int _maPhanLoaiHD, long _maDoiTac, int _maDonViChuQuan, int _maDinhKhoan)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a HopDongThuChiList");
            return DataPortal.Fetch<HopDongThuChiList>(new FilterCriteriaSearchByWithoutNgayKy(_maLoaiHopDong,_maPhanLoaiHD, _maDoiTac, _maDonViChuQuan, _maDinhKhoan));
        }

        public static HopDongThuChiList GetDanhDachSoHopDongPhatSinh(bool _timTheoNgay, DateTime _tuNgay, DateTime _denNgay, long _maDoiTac, int _maDonViChuQuan,Byte _loai)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a HopDongThuChiList");
            return DataPortal.Fetch<HopDongThuChiList>(new FilterCriteriaSearchSoHopDongPhatSinhByNgayKy(_timTheoNgay, _tuNgay, _denNgay, _maDoiTac, _maDonViChuQuan,_loai));
        }
        public static HopDongThuChiList GetHopDongMuaBan_PhuLucByMaHopDong(long maHopDong)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a HopDongThuChiList");
            return DataPortal.Fetch<HopDongThuChiList>(new FilterCriteriaSearchByMaHopDong(maHopDong));
        }

        public static HopDongThuChiList GetHopDongMuaBanTuFileExcelNam2014()
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a HopDongThuChiList");
            return DataPortal.Fetch<HopDongThuChiList>(new FilterCriteriaSearchHopDongExcelNam2014());
        }
        #endregion //Factory Methods

        #region Data Access

        #region Filter Criteria
        [Serializable()]
        private class FilterCriteria
        {


            public FilterCriteria()//long maHopDong
            {

            }
        }

        private class FilterCriteriaby_ChuaLapDeNghi
        {
            public FilterCriteriaby_ChuaLapDeNghi()//long maHopDong
            {

            }
        }

        private class FilterCriteriaby_TheoDoiTac
        {
            public long _maDoiTac = 0;
            public FilterCriteriaby_TheoDoiTac(long MaDoiTac)//long maHopDong
            {
                this._maDoiTac = MaDoiTac;
            }
        }

        private class FilterCriteriabyNgayLap
        {
            public DateTime TuNgay;
            public DateTime DenNgay;
            //public int Loai;
            //public bool MuaBan;

            public FilterCriteriabyNgayLap(DateTime _tuNgay, DateTime _denNgay)
            {
                this.TuNgay = _tuNgay;
                this.DenNgay = _denNgay;
                //this.Loai = _loai;
                //this.MuaBan = _muaBan;
            }
        }
        private class FilterCriteriaByLoai
        {
            public short Loai;

            public FilterCriteriaByLoai(short _loai)//long maHopDong
            {
                Loai = _loai;
            }
        }

        private class FilterCriteriaByTimHopDong
        {
            public short Loai;
            public string ChuoiTimKiem;
            public bool MuaBan;

            public FilterCriteriaByTimHopDong(short _loai, string _chuoiTimKiem, bool _muaBan)//long maHopDong
            {
                Loai = _loai;
                ChuoiTimKiem = _chuoiTimKiem;
                MuaBan = _muaBan;
            }
        }

        private class FilterCriteriaByTimHopDongTaiSan
        {
            public short Loai;
            public string ChuoiTimKiem;

            public FilterCriteriaByTimHopDongTaiSan(short _loai, string _chuoiTimKiem)//long maHopDong
            {
                Loai = _loai;
                ChuoiTimKiem = _chuoiTimKiem;
            }
        }

        private class FilterCriteriaByFull
        {
            public DateTime TuNgay;
            public DateTime DenNgay;
            public string ChuoiHangHoaDV;
            public string ChuoiTimKiemHDKH;
            public bool MuaBan;
            public short Loai;

            public FilterCriteriaByFull(short _loai, string _chuoiTimKiemHDKH, bool _muaBan, string _chuoiHangHoaDV, DateTime _tuNgay, DateTime _denNgay)
            {
                Loai = _loai;
                ChuoiTimKiemHDKH = _chuoiTimKiemHDKH;
                MuaBan = _muaBan;
                ChuoiHangHoaDV = _chuoiHangHoaDV;
                TuNgay = _tuNgay;
                DenNgay = _denNgay;
            }
        }

        private class FilterCriteriaByLapPhieu//Theo Ma Doi Tac ===M
        {
            public long maDoiTac;
            public int loaiHopDong;
            public byte tinhTrang;

            public FilterCriteriaByLapPhieu(int _loaihopDong, long _maDoiTac, byte _tinhTrang)
            {
                maDoiTac = _maDoiTac;
                loaiHopDong = _loaihopDong;
                tinhTrang = _tinhTrang;
            }
        }
        private class FilterCriteriaByMaPhieuNhapXuat//Theo Ma Phieu Nhap Xuat ===M
        {
            public long MaPhieuNhapXuat;
            public FilterCriteriaByMaPhieuNhapXuat(long maPhieuNhapXuat)
            {
                MaPhieuNhapXuat = maPhieuNhapXuat;
            }
        }
        private class FilterCriteriaByUserID
        {
            public FilterCriteriaByUserID()
            {
            }
        }

        private class FilterCriteriaByMaCongTy_MaDoiTac
        {
            public long MaDoiTac;
            public FilterCriteriaByMaCongTy_MaDoiTac(long madoitac)
            {
                MaDoiTac = madoitac;
            }
        }

        private class FilterCriteriaByUserID_MaLoaiHopDong
        {
            public int MaLoaiHopDong;
            public FilterCriteriaByUserID_MaLoaiHopDong(int maLoaiHopDong)
            {
                this.MaLoaiHopDong=maLoaiHopDong;
            }
        }

        private class FilterCriteriaSearchByNgayKy//Theo Ma Doi Tac ===M
        {
            public DateTime TuNgay;
            public DateTime DenNgay;
            public int MaLoaiHopDong;
            public int MaPhanLoaiHD;
            public long MaDoiTac;
            public int MaDonViChuQuan;
            public int MaDinhKhoan;

            public FilterCriteriaSearchByNgayKy(DateTime _tuNgay, DateTime _denNgay, int _maLoaiHopDong, int _maPhanLoaiHD, long _maDoiTac, int _maDonViChuQuan, int _maDinhKhoan)
            {
                TuNgay = _tuNgay;
                DenNgay = _denNgay;
                MaLoaiHopDong = _maLoaiHopDong;
                MaDoiTac = _maDoiTac;
                MaPhanLoaiHD = _maPhanLoaiHD;
                MaDonViChuQuan = _maDonViChuQuan;
                MaDinhKhoan = _maDinhKhoan;
            }
        }

        private class FilterCriteriaSearchSoHopDongPhatSinhByNgayKy//Theo Ma Doi Tac ===M
        {
            public bool TimTheoNgay;
            public DateTime TuNgay;
            public DateTime DenNgay;
            public long MaDoiTac;
            public int MaDonViChuQuan;
            public byte Loai;

            public FilterCriteriaSearchSoHopDongPhatSinhByNgayKy(bool _timTheoNgay, DateTime _tuNgay, DateTime _denNgay, long _maDoiTac, int _maDonViChuQuan,byte _loai)
            {
                TimTheoNgay = _timTheoNgay;
                TuNgay = _tuNgay;
                DenNgay = _denNgay;
                MaDoiTac = _maDoiTac;
                MaDonViChuQuan = _maDonViChuQuan;
                Loai = _loai;
            }
        }

        private class FilterCriteriaSearchByWithoutNgayKy//Theo Ma Doi Tac ===M
        {
            public int MaLoaiHopDong;
            public int MaPhanLoaiHD;
            public long MaDoiTac;
            public int MaDonViChuQuan;
            public int MaDinhKhoan;

            public FilterCriteriaSearchByWithoutNgayKy(int _maLoaiHopDong, int _maPhanLoaiHD, long _maDoiTac, int _maDonViChuQuan, int _maDinhKhoan)
            {
                MaLoaiHopDong = _maLoaiHopDong;
                MaDoiTac = _maDoiTac;
                MaPhanLoaiHD = _maPhanLoaiHD;
                MaDonViChuQuan = _maDonViChuQuan;
                MaDinhKhoan = _maDinhKhoan;
            }
        }
        private class FilterCriteriaSearchByMaHopDong//Theo Ma Doi Tac ===M
        {
            public long MaHopDong;

            public FilterCriteriaSearchByMaHopDong(long maHopDong)
            {
                this.MaHopDong = maHopDong;
            }
        }

        private class FilterCriteriaSearchHopDongExcelNam2014//Theo Ma Doi Tac ===M
        {

            public FilterCriteriaSearchHopDongExcelNam2014()
            {
            }
        }
        #endregion //Filter Criteria

        #region Data Access - Fetch
        protected override void DataPortal_Fetch(Object criteria)
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
                    tr.Rollback();
                    throw ex;
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
                    cm.CommandText = "spd_SelecttblHopDongMuaBansAll";
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(HopDongThuChi.GetHopDongMuaBan(dr));
                    }
                }
                else if (criteria is FilterCriteriaby_ChuaLapDeNghi)
                {
                    cm.CommandText = "spd_SelecttblHopDongMuaBan_ChuaLapDeNghi";
                    cm.Parameters.AddWithValue("@MaNguoiDung", ERP_Library.Security.CurrentUser.Info.UserID);
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(HopDongThuChi.GetHopDongMuaBan(dr));
                    }
                }
                else if (criteria is FilterCriteriaby_TheoDoiTac)
                {
                    cm.CommandText = "spd_SelecttblHopDongMuaBan_TheoDoiTac";
                    cm.Parameters.AddWithValue("@MaDoiTac", ((FilterCriteriaby_TheoDoiTac)criteria)._maDoiTac);
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(HopDongThuChi.GetHopDongMuaBan(dr));
                    }
                }
                else if (criteria is FilterCriteriabyNgayLap)
                {
                    cm.CommandText = "spd_SelecttblHopDongMuaBansByNgayLap";
                    cm.Parameters.AddWithValue("@TuNgay", ((FilterCriteriabyNgayLap)criteria).TuNgay);
                    cm.Parameters.AddWithValue("@DenNgay", ((FilterCriteriabyNgayLap)criteria).DenNgay);
                    cm.Parameters.AddWithValue("@MaNguoiDung", ERP_Library.Security.CurrentUser.Info.UserID);
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(HopDongThuChi.GetHopDongMuaBan(dr));
                    }
                }
                else if (criteria is FilterCriteriaByLoai)
                {
                    cm.CommandText = "spd_SelecttblHopDongMuaBansByLoai";
                    cm.Parameters.AddWithValue("@Loai", ((FilterCriteriaByLoai)criteria).Loai);
                    cm.Parameters.AddWithValue("@MaNguoiDung", ERP_Library.Security.CurrentUser.Info.UserID);
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(HopDongThuChi.GetHopDongMuaBan(dr));
                    }
                }
                else if (criteria is FilterCriteriaByTimHopDong)
                {
                    cm.CommandText = "spd_SelecttblTimHopDongLapDonHang";
                    cm.Parameters.AddWithValue("@Loai", ((FilterCriteriaByTimHopDong)criteria).Loai);
                    cm.Parameters.AddWithValue("@ChuoiTimKiem", ((FilterCriteriaByTimHopDong)criteria).ChuoiTimKiem);
                    cm.Parameters.AddWithValue("@MuaBan", ((FilterCriteriaByTimHopDong)criteria).MuaBan);
                    cm.Parameters.AddWithValue("@MaNguoiDung", ERP_Library.Security.CurrentUser.Info.UserID);
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(HopDongThuChi.GetHopDongMuaBan(dr));
                    }
                }
                else if (criteria is FilterCriteriaByFull)
                {
                    cm.CommandText = "spd_SelecttblTimHopDongDieuKienFull";
                    if (((FilterCriteriaByFull)criteria).TuNgay != DateTime.MinValue)
                        cm.Parameters.AddWithValue("@TuNgay", ((FilterCriteriaByFull)criteria).TuNgay);
                    else cm.Parameters.AddWithValue("@TuNgay", DBNull.Value);
                    if (((FilterCriteriaByFull)criteria).DenNgay != DateTime.MinValue)
                        cm.Parameters.AddWithValue("@DenNgay", ((FilterCriteriaByFull)criteria).DenNgay);
                    else cm.Parameters.AddWithValue("@DenNgay", DBNull.Value);
                    cm.Parameters.AddWithValue("@Loai", ((FilterCriteriaByFull)criteria).Loai);
                    cm.Parameters.AddWithValue("@MuaBan", ((FilterCriteriaByFull)criteria).MuaBan);
                    cm.Parameters.AddWithValue("@ChuoiHangHoaDV", ((FilterCriteriaByFull)criteria).ChuoiHangHoaDV);
                    cm.Parameters.AddWithValue("@ChuoiTimKiemHDKH", ((FilterCriteriaByFull)criteria).ChuoiTimKiemHDKH);
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(HopDongThuChi.GetHopDongMuaBan(dr));
                    }
                }
                else if (criteria is FilterCriteriaByLapPhieu)//M1
                {
                    cm.CommandText = "spd_SelecttblHopDongsByLapPhieu";
                    cm.Parameters.AddWithValue("@MaDoiTac", ((FilterCriteriaByLapPhieu)criteria).maDoiTac);
                    cm.Parameters.AddWithValue("@TinhTrang", ((FilterCriteriaByLapPhieu)criteria).tinhTrang);
                    cm.Parameters.AddWithValue("@LoaiHopDong", ((FilterCriteriaByLapPhieu)criteria).loaiHopDong);
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(HopDongThuChi.GetHopDongMuaBan(dr));
                    }
                }//END M1
                else if (criteria is FilterCriteriaByMaPhieuNhapXuat)//M2
                {
                    cm.Transaction = tr;
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_SelecttblHopDongsByMaPhieuNhapXuat";
                    cm.Parameters.AddWithValue("@MaPhieuNhapxuat", ((FilterCriteriaByMaPhieuNhapXuat)criteria).MaPhieuNhapXuat);
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(HopDongThuChi.GetHopDongMuaBan(dr));
                    }
                }//END M2
                else if (criteria is FilterCriteriaByUserID)
                {
                    cm.Transaction = tr;
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_SelecttblHopDongsByUserID";
                    cm.Parameters.AddWithValue("@UserID", ERP_Library.Security.CurrentUser.Info.UserID);
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(HopDongThuChi.GetHopDongMuaBanWithoutChild(dr));
                    }

                }
                else if (criteria is FilterCriteriaByMaCongTy_MaDoiTac)
                {
                    cm.Transaction = tr;
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_SelecttblHopDongsByMaDoiTac_CongTy";
                    cm.Parameters.AddWithValue("@MaDoiTac",((FilterCriteriaByMaCongTy_MaDoiTac)criteria).MaDoiTac);
                    cm.Parameters.AddWithValue("@MaCongTy", ERP_Library.Security.CurrentUser.Info.MaCongTy);
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(HopDongThuChi.GetHopDongMuaBanWithoutChild(dr));
                    }

                }
                else if (criteria is FilterCriteriaByUserID_MaLoaiHopDong)
                {
                    cm.Transaction = tr;
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_SelecttblHopDongsByUserID_MaLoaiHopDong";
                    cm.Parameters.AddWithValue("@UserID", ERP_Library.Security.CurrentUser.Info.UserID);
                    cm.Parameters.AddWithValue("@MaLoaiHopDong", ((FilterCriteriaByUserID_MaLoaiHopDong)criteria).MaLoaiHopDong);
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(HopDongThuChi.GetHopDongMuaBanWithoutChild(dr));
                    }

                }
                else if (criteria is FilterCriteriaSearchByNgayKy)
                {
                    cm.CommandText = "spd_SearchtblHopDongThuChisByNgayky";
                    cm.Parameters.AddWithValue("@TuNgay", ((FilterCriteriaSearchByNgayKy)criteria).TuNgay);
                    cm.Parameters.AddWithValue("@DenNgay", ((FilterCriteriaSearchByNgayKy)criteria).DenNgay);
                    cm.Parameters.AddWithValue("@MaLoaiHopDong", ((FilterCriteriaSearchByNgayKy)criteria).MaLoaiHopDong);
                    cm.Parameters.AddWithValue("@MaPhanLoaiHD", ((FilterCriteriaSearchByNgayKy)criteria).MaPhanLoaiHD);
                    cm.Parameters.AddWithValue("@MaDoiTac", ((FilterCriteriaSearchByNgayKy)criteria).MaDoiTac);
                    cm.Parameters.AddWithValue("@MaPhongBan", ((FilterCriteriaSearchByNgayKy)criteria).MaDonViChuQuan);
                    cm.Parameters.AddWithValue("@MaTaiKhoan", ((FilterCriteriaSearchByNgayKy)criteria).MaDinhKhoan);
                    cm.Parameters.AddWithValue("@UserID", ERP_Library.Security.CurrentUser.Info.UserID);
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(HopDongThuChi.GetHopDongMuaBanWithoutChild(dr));
                    }
                }
                else if (criteria is FilterCriteriaSearchByWithoutNgayKy)
                {
                    cm.CommandText = "spd_SearchtblHopDongThuChisByWithoutNgayky";
                    cm.Parameters.AddWithValue("@MaLoaiHopDong", ((FilterCriteriaSearchByWithoutNgayKy)criteria).MaLoaiHopDong);
                    cm.Parameters.AddWithValue("@MaPhanLoaiHD", ((FilterCriteriaSearchByWithoutNgayKy)criteria).MaPhanLoaiHD);
                    cm.Parameters.AddWithValue("@MaDoiTac", ((FilterCriteriaSearchByWithoutNgayKy)criteria).MaDoiTac);
                    cm.Parameters.AddWithValue("@MaPhongBan", ((FilterCriteriaSearchByWithoutNgayKy)criteria).MaDonViChuQuan);
                    cm.Parameters.AddWithValue("@MaTaiKhoan", ((FilterCriteriaSearchByWithoutNgayKy)criteria).MaDinhKhoan);
                    cm.Parameters.AddWithValue("@UserID", ERP_Library.Security.CurrentUser.Info.UserID);
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(HopDongThuChi.GetHopDongMuaBanWithoutChild(dr));
                    }
                }
                else if (criteria is FilterCriteriaSearchSoHopDongPhatSinhByNgayKy)
                {
                    if (((FilterCriteriaSearchSoHopDongPhatSinhByNgayKy)criteria).Loai == 0)
                    {
                        cm.CommandText = "spd_SearchtblHopDongThuChis_SoHopDongPhatSinh_Admin";
                    }
                    else
                    {
                        cm.CommandText = "spd_SearchtblHopDongThuChis_SoHopDongPhatSinhByNgayky";
                    }

                    cm.Parameters.AddWithValue("@TimTheoNgay", ((FilterCriteriaSearchSoHopDongPhatSinhByNgayKy)criteria).TimTheoNgay);
                    cm.Parameters.AddWithValue("@TuNgay", ((FilterCriteriaSearchSoHopDongPhatSinhByNgayKy)criteria).TuNgay);
                    cm.Parameters.AddWithValue("@DenNgay", ((FilterCriteriaSearchSoHopDongPhatSinhByNgayKy)criteria).DenNgay);
                    cm.Parameters.AddWithValue("@MaDoiTac", ((FilterCriteriaSearchSoHopDongPhatSinhByNgayKy)criteria).MaDoiTac);
                    cm.Parameters.AddWithValue("@MaPhongBan", ((FilterCriteriaSearchSoHopDongPhatSinhByNgayKy)criteria).MaDonViChuQuan);
                    cm.Parameters.AddWithValue("@UserID", ERP_Library.Security.CurrentUser.Info.UserID);
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(HopDongThuChi.GetHopDongMuaBanWithoutChild(dr));
                    }
                }
                else if (criteria is FilterCriteriaSearchByMaHopDong)
                {
                    cm.CommandText = "spd_SearchtblHopDongThuChisByMaHopDong";
                    cm.Parameters.AddWithValue("@MaHopDong", ((FilterCriteriaSearchByMaHopDong)criteria).MaHopDong);
                    cm.Parameters.AddWithValue("@UserID", ERP_Library.Security.CurrentUser.Info.UserID);
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(HopDongThuChi.GetHopDongMuaBanWithoutChild(dr));
                    }
                }
                else if (criteria is FilterCriteriaSearchHopDongExcelNam2014)
                {
                    cm.CommandText = "spd_SearchtblHopDongThuChistuFileExcelNam2014";
                    cm.Parameters.AddWithValue("@UserID", ERP_Library.Security.CurrentUser.Info.UserID);
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(HopDongThuChi.GetHopDongMuaBanWithoutChild(dr));
                    }
                }
                //using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                //{
                //    while (dr.Read())
                //        this.Add(HopDongThuChi.GetHopDongMuaBan(dr));
                //}
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
                    foreach (HopDongThuChi deletedChild in DeletedList)
                        deletedChild.DeleteSelf(tr);
                    DeletedList.Clear();

                    // loop through each non-deleted child object
                    foreach (HopDongThuChi child in this)
                    {
                        if (child.IsNew)
                            child.Insert(tr);
                        else
                            child.Update(tr);
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
        #region Function
        public static DataTable Table_TheoDoiHopDong(bool timTheoNgay, DateTime tuNgay, DateTime denNgay, int maLoaiHopDong, int maPhanLoaiHD,long maDoiTac)
        {
            //
            DataTable kqTbl = new DataTable();
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandTimeout = 1800;
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "Spd_TheoDoiHopDong";
                    cm.Parameters.AddWithValue("@TimTheoNgay", timTheoNgay);
                    cm.Parameters.AddWithValue("@TuNgay", tuNgay);
                    cm.Parameters.AddWithValue("@DenNgay", denNgay);
                    cm.Parameters.AddWithValue("@MaLoaiHopDong", maLoaiHopDong);
                    cm.Parameters.AddWithValue("@MaPhanLoaiHD", maPhanLoaiHD);
                    cm.Parameters.AddWithValue("@MaDoiTac", maDoiTac);
                    cm.Parameters.AddWithValue("@UserID", ERP_Library.Security.CurrentUser.Info.UserID);
                    using (SqlDataAdapter da = new SqlDataAdapter(cm))
                    {
                        DataSet ds = new DataSet();
                        da.Fill(ds);

                        if (ds != null && ds.Tables.Count > 0)
                            kqTbl = ds.Tables[0];
                    }
                }
            }//us
            return kqTbl;
        }
        #endregion
    }
}
