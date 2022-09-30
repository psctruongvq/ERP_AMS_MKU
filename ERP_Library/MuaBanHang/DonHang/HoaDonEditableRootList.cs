
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
//tai sao loi


namespace ERP_Library
{

    [Serializable()]
    public class HoaDonList : Csla.BusinessListBase<HoaDonList, HoaDon>
    {
        public long _MaChungTu = 0;

        #region BindingList Overrides
        protected override object AddNewCore()
        {
            HoaDon item = HoaDon.NewHoaDon();
            this.Add(item);
            return item;
        }
        #endregion //BindingList Overrides

        #region Authorization Rules

        public static bool CanGetObject()
        {
            //TODO: Define CanGetObject permission in HoaDonList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("HoaDonListViewGroup"))
            //	return true;
            //return false;

        }

        public static bool CanAddObject()
        {
            //TODO: Define CanAddObject permission in HoaDonList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("HoaDonListAddGroup"))
            //	return true;
            //return false;
        }

        public static bool CanEditObject()
        {
            //TODO: Define CanEditObject permission in HoaDonList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("HoaDonListEditGroup"))
            //	return true;
            //return false;
        }

        public static bool CanDeleteObject()
        {
            //TODO: Define CanDeleteObject permission in HoaDonList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("HoaDonListDeleteGroup"))
            //	return true;
            //return false;
        }
        #endregion //Authorization Rules

        #region Factory Methods
        public static HoaDonList GetHoaDonList(SafeDataReader dr)
        {
            return new HoaDonList(dr);
        }

        private HoaDonList()
        { /* require use of factory method */ }

        private HoaDonList(SafeDataReader dr)
        {
            RaiseListChangedEvents = false;
            while (dr.Read())
                this.Add(HoaDon.GetHoaDon(dr));
            RaiseListChangedEvents = true;
        }

        public static HoaDonList NewHoaDonList()
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a HoaDonList");
            return new HoaDonList();
        }

        public static HoaDonList GetHoaDonList()
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a HoaDonList");
            return DataPortal.Fetch<HoaDonList>(new FilterCriteria());
        }


        public static HoaDonList GetHoaDonBanQuyenList(long maDoiTac, byte tinhTrang)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a HoaDonList");
            return DataPortal.Fetch<HoaDonList>(new FilterCriteriaBanQuyenLapPhieu(maDoiTac, tinhTrang));
        }
        public static HoaDonList GetHoaDonBanQuyenListforLapChungTu(long maDoiTac, byte tinhTrang)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a HoaDonList");
            return DataPortal.Fetch<HoaDonList>(new FilterCriteriaHoaDonBanQuyenLapChungTu(maDoiTac, tinhTrang));
        }

        public static HoaDonList GetHoaDonList(int LoaiHoaDon, byte QuyTrinh, bool NhapXuat, byte DoiTuongMuaBan, string ChuoiTimKiem)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a HoaDonList");
            return DataPortal.Fetch<HoaDonList>(new FilterCriteriaByNhapXuat(LoaiHoaDon, QuyTrinh, NhapXuat, DoiTuongMuaBan, ChuoiTimKiem));
        }

        public static HoaDonList GetHoaDonList(byte LoaiHoaDon, byte QuyTrinh, DateTime TuNgay, DateTime DenNgay, int mabophan)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a HoaDonList");
            return DataPortal.Fetch<HoaDonList>(new FilterCriteriaByNgayLap(TuNgay, DenNgay, LoaiHoaDon, QuyTrinh, mabophan));
        }

        public static HoaDonList GetHoaDonListByLoaiNgayLap(byte LoaiHoaDon, DateTime TuNgay, DateTime DenNgay)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a HoaDonList");
            return DataPortal.Fetch<HoaDonList>(new FilterCriteriaByLoaiNgayLap(TuNgay, DenNgay, LoaiHoaDon));
        }
        public static HoaDonList GetHoaDonListByCT(byte LoaiHoaDon, byte QuyTrinh, DateTime TuNgay, DateTime DenNgay)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a HoaDonList");
            return DataPortal.Fetch<HoaDonList>(new FilterCriteriaByNgayLapCT(TuNgay, DenNgay, LoaiHoaDon, QuyTrinh));
        }

        public static HoaDonList GetHoaDonListChuaTT(byte LoaiHoaDon, byte QuyTrinh, DateTime TuNgay, DateTime DenNgay, int mabophan)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a HoaDonList");
            return DataPortal.Fetch<HoaDonList>(new FilterCriteriaByNgayLapChuaTT(TuNgay, DenNgay, LoaiHoaDon, QuyTrinh, mabophan));
        }

        public static HoaDonList GetHoaDonMuaBanList(byte LoaiHoaDon, byte QuyTrinh, DateTime TuNgay, DateTime DenNgay, byte DoiTuongMuaBan)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a HoaDonList");
            return DataPortal.Fetch<HoaDonList>(new FilterCriteriaHDMBByNgayLap(TuNgay, DenNgay, LoaiHoaDon, QuyTrinh, DoiTuongMuaBan));
        }

        public static HoaDonList GetHoaDonMuaBanList(byte LoaiHoaDon, byte QuyTrinh, DateTime TuNgay, DateTime DenNgay, byte DoiTuongMuaBan, string ChuoiTimKiem, string ChuoiHHDV)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a HoaDonList");
            return DataPortal.Fetch<HoaDonList>(new FilterCriteriaHDMBByFull(TuNgay, DenNgay, LoaiHoaDon, QuyTrinh, DoiTuongMuaBan, ChuoiTimKiem, ChuoiHHDV));
        }

        public static HoaDonList GetHoaDonList(long MaDonHang)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a HoaDonList");
            return DataPortal.Fetch<HoaDonList>(new FilterCriteriaByMaDonHang(MaDonHang));
        }
        /// <summary>
        /// Lấy hóa đơn theo đối tác,loại hóa đơn và tình trạng
        /// </summary>
        /// <param name="MaDoiTac"></param>
        /// <param name="LoaiHoaDon"></param>
        /// <param name="tinhTrang">0:Chua Thanh Toán; 1 Đã Thanh Toán ; 2: Đã Thanh Toán 1 Phần; 3: Đã bị hủy</param>
        /// <returns></returns>
        public static HoaDonList GetHoaDonList_byHoaDonDichVu(long MaDoiTac, int tinhTrang, bool tatToan)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a HoaDonList");
            return DataPortal.Fetch<HoaDonList>(new FilterCriteriaByLoaiHoaDonDichVu(MaDoiTac, tinhTrang, tatToan));
        }

        // Load nhung hoa don khong nam trong danh sach hoa don theo chung tu
        public static HoaDonList GetHoaDonList_byHoaDonDichVu_ChungTu(long MaDoiTac, int tinhTrang, bool tatToan, long machungtu, int mabutoan)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a HoaDonList");
            return DataPortal.Fetch<HoaDonList>(new FilterCriteriaByLoaiHoaDonDichVu_ChungTu(MaDoiTac, tinhTrang, tatToan, machungtu, mabutoan));
        }

        public static HoaDonList GetHoaDonList_byHoaDonDichVu_ChungTubyLoaiHoaDon(int loaiHoaDon, long MaDoiTac, int tinhTrang, bool tatToan, long machungtu, int mabutoan)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a HoaDonList");
            return DataPortal.Fetch<HoaDonList>(new FilterCriteriaByLoaiHoaDonDichVu_ChungTubyLoaiHoaDon(loaiHoaDon, MaDoiTac, tinhTrang, tatToan, machungtu, mabutoan));
        }
        public static HoaDonList GetHoaDonList_byHoaDonDichVu_ChungTu_NguoiLap(long MaDoiTac, int tinhTrang, bool tatToan, long machungtu, int mabutoan, long manguoilap)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a HoaDonList");
            return DataPortal.Fetch<HoaDonList>(new FilterCriteriaByLoaiHoaDonDichVu_ChungTu_NguoiLap(MaDoiTac, tinhTrang, tatToan, machungtu, mabutoan, manguoilap));
        }

        public static HoaDonList GetHoaDonLisForLapChungTu_HoaDon(int maloaiCT, long MaDoiTac)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a HoaDonList");
            return DataPortal.Fetch<HoaDonList>(new FilterCriteriaForLapChungTu_HoaDon(maloaiCT,MaDoiTac));
        }

        public static HoaDonList GetHoaDonListChuaThanhToan(long MaDoiTac, int LoaiHoaDon)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a HoaDonList");
            return DataPortal.Fetch<HoaDonList>(new FilterCriteriaByLoaiHoaDonChuaThanToan(LoaiHoaDon, MaDoiTac));
        }

        public static HoaDonList GetHoaDonListLapPhieu(long MaDoiTac, int LoaiHoaDon, byte TinhTrang)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a HoaDonList");
            return DataPortal.Fetch<HoaDonList>(new FilterCriteriaByLapPhieu(LoaiHoaDon, MaDoiTac, TinhTrang));
        }

        public static HoaDonList GetHoaDonListByMaPhieuNhapXuat(long maPhieuNhapXuat)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a HoaDonList");
            return DataPortal.Fetch<HoaDonList>(new FilterCriteriaByMaPhieuNhapXuat(maPhieuNhapXuat));
        }


        public static HoaDonList GetHoaDonListChuaThanhToan_LoaiKhachHang(long MaDoiTac, int LoaiHoaDon, int LoaiKhachHang)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a HoaDonList");
            return DataPortal.Fetch<HoaDonList>(new FilterCriteriaByLoaiHoaDonChuaThanToan_LoaiKhachHang(LoaiHoaDon, MaDoiTac, LoaiKhachHang));
        }

        public static HoaDonList GetHoaDonList_TatToan(int loaiHoaDon, long maHopDong, bool tatToan)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a HoaDonList");
            return DataPortal.Fetch<HoaDonList>(new FilterCriteriaByTatToan(loaiHoaDon, maHopDong, tatToan));
        }

        public static HoaDonList GetHoaDonList_ChuyenKhoan(int loaiHoaDon, long MaKhachHang)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a HoaDonList");
            return DataPortal.Fetch<HoaDonList>(new FilterCriteria_ChuyenKhoan(loaiHoaDon, MaKhachHang));
        }

        public static decimal LayTongTienNoHoaDonTheoKhachHang(long MaKhachHang, int MaDoiTuongThuChi)
        {
            decimal tongtien = 0;
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                try
                {
                    using (SqlCommand cm = cn.CreateCommand())
                    {
                        cm.CommandType = CommandType.StoredProcedure;
                        cm.CommandText = "LayTongTienNoHoaDonTheoKhachHang";
                        cm.Parameters.AddWithValue("@MaKhachHang", MaKhachHang);
                        cm.Parameters.AddWithValue("@MaDoiTuongThuChi", MaDoiTuongThuChi);
                        cm.Parameters.AddWithValue("@TongTien", Convert.ToDecimal(0));
                        cm.Parameters["@TongTien"].Direction = ParameterDirection.Output;

                        cm.ExecuteNonQuery();

                        tongtien = (decimal)cm.Parameters["@TongTien"].Value;
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return tongtien;
            }//using
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

        private class FilterCriteriaBanQuyenLapPhieu
        {
            public long maDoiTac;
            public byte tinhTrang;

            public FilterCriteriaBanQuyenLapPhieu(long _maDoiTac, byte _tinhTrang)
            {
                maDoiTac = _maDoiTac;
                tinhTrang = _tinhTrang;
            }
        }
        private class FilterCriteriaHoaDonBanQuyenLapChungTu
        {
            public long maDoiTac;
            public byte tinhTrang;

            public FilterCriteriaHoaDonBanQuyenLapChungTu(long _maDoiTac, byte _tinhTrang)
            {
                maDoiTac = _maDoiTac;
                tinhTrang = _tinhTrang;
            }
        }

        private class FilterCriteriaByMaPhieuNhapXuat
        {
            public long MaPhieuNhapXuat;
            public FilterCriteriaByMaPhieuNhapXuat(long maPhieuNhapXuat)
            {
                MaPhieuNhapXuat = maPhieuNhapXuat;
            }
        }

        private class FilterCriteriaByNhapXuat
        {
            public int Loai;
            public byte QuyTrinh;
            public bool NhapXuat;
            public byte DoiTuongMuaBan;
            public string ChuoiTimKiem;
            public FilterCriteriaByNhapXuat(int _loai, byte _quyTrinh, bool _nhapXuat, byte _doiTuongMuaBan, string _chuoiTimKiem)
            {
                Loai = _loai;
                QuyTrinh = _quyTrinh;
                NhapXuat = _nhapXuat;
                DoiTuongMuaBan = _doiTuongMuaBan;
                ChuoiTimKiem = _chuoiTimKiem;
            }
        }

        private class FilterCriteria_ChuyenKhoan
        {
            public int LoaiHoaDon;
            public long MaKhachHang;
            public FilterCriteria_ChuyenKhoan(int loaiHoaDon, long maKhachHang)
            {
                this.LoaiHoaDon = loaiHoaDon;
                this.MaKhachHang = maKhachHang;
            }
        }

        private class FilterCriteriaByNgayLap
        {
            public DateTime TuNgay;
            public DateTime DenNgay;
            public byte LoaiHoaDon;
            public byte QuyTrinh;
            public int mabophan;
            public FilterCriteriaByNgayLap(DateTime _tuNgay, DateTime _denNgay, byte _loaiHoaDon, byte _quyTrinh, int mabophan)
            {
                this.TuNgay = _tuNgay;
                this.DenNgay = _denNgay;
                this.LoaiHoaDon = _loaiHoaDon;
                this.QuyTrinh = _quyTrinh;
                this.mabophan = mabophan;
            }
        }
        private class FilterCriteriaByLoaiNgayLap
        {
            public DateTime TuNgay;
            public DateTime DenNgay;
            public byte LoaiHoaDon;
            public FilterCriteriaByLoaiNgayLap(DateTime _tuNgay, DateTime _denNgay, byte _loaiHoaDon)
            {
                this.TuNgay = _tuNgay;
                this.DenNgay = _denNgay;
                this.LoaiHoaDon = _loaiHoaDon;
            }
        }

        private class FilterCriteriaByNgayLapCT
        {
            public DateTime TuNgay;
            public DateTime DenNgay;
            public byte LoaiHoaDon;
            public byte QuyTrinh;
            public FilterCriteriaByNgayLapCT(DateTime _tuNgay, DateTime _denNgay, byte _loaiHoaDon, byte _quyTrinh)
            {
                this.TuNgay = _tuNgay;
                this.DenNgay = _denNgay;
                this.LoaiHoaDon = _loaiHoaDon;
                this.QuyTrinh = _quyTrinh;
            }
        }
        private class FilterCriteriaByNgayLapChuaTT
        {
            public DateTime TuNgay;
            public DateTime DenNgay;
            public byte LoaiHoaDon;
            public byte QuyTrinh;
            public int mabophan;
            public FilterCriteriaByNgayLapChuaTT(DateTime _tuNgay, DateTime _denNgay, byte _loaiHoaDon, byte _quyTrinh, int mabophan)
            {
                this.TuNgay = _tuNgay;
                this.DenNgay = _denNgay;
                this.LoaiHoaDon = _loaiHoaDon;
                this.QuyTrinh = _quyTrinh;
                this.mabophan = mabophan;
            }
        }

        private class FilterCriteriaHDMBByNgayLap
        {
            public DateTime TuNgay;
            public DateTime DenNgay;
            public byte LoaiHoaDon;
            public byte QuyTrinh;
            public byte DoiTuongMuaBan;
            public FilterCriteriaHDMBByNgayLap(DateTime _tuNgay, DateTime _denNgay, byte _loaiHoaDon, byte _quyTrinh, byte _doiTuongMuaBan)
            {
                TuNgay = _tuNgay;
                DenNgay = _denNgay;
                LoaiHoaDon = _loaiHoaDon;
                QuyTrinh = _quyTrinh;
                DoiTuongMuaBan = _doiTuongMuaBan;
            }
        }

        private class FilterCriteriaByMaDonHang
        {
            public long MaDonHang;

            public FilterCriteriaByMaDonHang(long _maDonHang)
            {
                MaDonHang = _maDonHang;
            }
        }

        private class FilterCriteriaByTatToan
        {
            public long maHopDong;
            public int loaiHoaDon;
            public bool tatToan;

            public FilterCriteriaByTatToan(int _loaiHoaDon, long _maHopDong, bool _tatToan)
            {
                loaiHoaDon = _loaiHoaDon;
                maHopDong = _maHopDong;
                tatToan = _tatToan;
            }
        }

        private class FilterCriteriaByLoaiHoaDonDichVu
        {
            public long maDoiTac;

            public int TinhTrang;
            public bool TatToan;
            public FilterCriteriaByLoaiHoaDonDichVu(long _maDoiTac, int _tinhTrang, bool tatToan)
            {
                maDoiTac = _maDoiTac;
                this.TinhTrang = _tinhTrang;
                this.TatToan = tatToan;
            }
        }

        private class FilterCriteriaByLoaiHoaDonDichVu_ChungTu
        {
            public long maDoiTac;
            public int TinhTrang;
            public bool TatToan;

            public long machungtu;
            public int mabuttoan;
            public FilterCriteriaByLoaiHoaDonDichVu_ChungTu(long _maDoiTac, int _tinhTrang, bool tatToan, long machungtu, int mabuttoan)
            {
                maDoiTac = _maDoiTac;
                this.TinhTrang = _tinhTrang;
                this.TatToan = tatToan;
                this.machungtu = machungtu;
                this.mabuttoan = mabuttoan;

            }
        }

        private class FilterCriteriaByLoaiHoaDonDichVu_ChungTubyLoaiHoaDon
        {
            public int LoaiHoaDon;
            public long maDoiTac;
            public int TinhTrang;
            public bool TatToan;

            public long machungtu;
            public int mabuttoan;
            public FilterCriteriaByLoaiHoaDonDichVu_ChungTubyLoaiHoaDon(int loaiHoaDon, long _maDoiTac, int _tinhTrang, bool tatToan, long machungtu, int mabuttoan)
            {
                this.LoaiHoaDon = loaiHoaDon;
                maDoiTac = _maDoiTac;
                this.TinhTrang = _tinhTrang;
                this.TatToan = tatToan;
                this.machungtu = machungtu;
                this.mabuttoan = mabuttoan;

            }
        }

        private class FilterCriteriaByLoaiHoaDonDichVu_ChungTu_NguoiLap
        {
            public long maDoiTac;
            public int TinhTrang;
            public bool TatToan;
            public long manguoilap;
            public long machungtu;
            public int mabuttoan;
            public FilterCriteriaByLoaiHoaDonDichVu_ChungTu_NguoiLap(long _maDoiTac, int _tinhTrang, bool tatToan, long machungtu, int mabuttoan, long manguoilap)
            {
                maDoiTac = _maDoiTac;
                this.TinhTrang = _tinhTrang;
                this.TatToan = tatToan;
                this.machungtu = machungtu;
                this.mabuttoan = mabuttoan;
                this.manguoilap = manguoilap;

            }
        }

        private class FilterCriteriaForLapChungTu_HoaDon
        {
            public int MaLoaiChungTu;
            public long MaDoiTac;
            public FilterCriteriaForLapChungTu_HoaDon(int maLoaiChungTu, long maDoiTac)
            {
                MaLoaiChungTu = maLoaiChungTu;
                MaDoiTac = maDoiTac;
            }
        }

        private class FilterCriteriaByLoaiHoaDonChuaThanToan
        {
            public long maDoiTac;
            public int loaiHoaDon;

            public FilterCriteriaByLoaiHoaDonChuaThanToan(int _loaihoaDon, long _maDoiTac)
            {
                maDoiTac = _maDoiTac;
                loaiHoaDon = _loaihoaDon;
            }
        }

        private class FilterCriteriaByLapPhieu
        {
            public long maDoiTac;
            public int loaiHoaDon;
            public byte tinhTrang;

            public FilterCriteriaByLapPhieu(int _loaihoaDon, long _maDoiTac, byte _tinhTrang)
            {
                maDoiTac = _maDoiTac;
                loaiHoaDon = _loaihoaDon;
                tinhTrang = _tinhTrang;
            }
        }

        private class FilterCriteriaByLoaiHoaDonChuaThanToan_LoaiKhachHang
        {
            public long maDoiTac;
            public int loaiHoaDon;
            public int loaiKhachHang;

            public FilterCriteriaByLoaiHoaDonChuaThanToan_LoaiKhachHang(int _loaihoaDon, long _maDoiTac, int _loaiKhachHang)
            {
                this.maDoiTac = _maDoiTac;
                this.loaiHoaDon = _loaihoaDon;
                this.loaiKhachHang = _loaiKhachHang;
            }
        }

        private class FilterCriteriaHDMBByFull
        {
            public DateTime TuNgay;
            public DateTime DenNgay;
            public byte LoaiHoaDon;
            public byte QuyTrinh;
            public byte DoiTuongMuaBan;
            public string ChuoiTimKiem;
            public string ChuoiHHDV;
            public FilterCriteriaHDMBByFull(DateTime _tuNgay, DateTime _denNgay, byte _loaiHoaDon, byte _quyTrinh, byte _doiTuongMuaBan, string _chuoiTimKiem, string _chuoiHHDV)
            {
                TuNgay = _tuNgay;
                DenNgay = _denNgay;
                LoaiHoaDon = _loaiHoaDon;
                QuyTrinh = _quyTrinh;
                DoiTuongMuaBan = _doiTuongMuaBan;
                ChuoiTimKiem = _chuoiTimKiem;
                ChuoiHHDV = _chuoiHHDV;
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
                catch (Exception ex)
                {
                    tr.Rollback();
                    throw ex;
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
                    cm.CommandText = "spd_SelecttblHoaDonsAll";

                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(HoaDon.GetHoaDon(dr));
                    }
                }
            }
            else if (criteria is FilterCriteriaByNhapXuat)
            {
                using (SqlCommand cm = tr.Connection.CreateCommand())
                {
                    cm.Transaction = tr;
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_SelecttblHoaDonsByNhapXuat";
                    cm.Parameters.AddWithValue("@LoaiHoaDon", ((FilterCriteriaByNhapXuat)criteria).Loai);
                    cm.Parameters.AddWithValue("@QuyTrinh", ((FilterCriteriaByNhapXuat)criteria).QuyTrinh);
                    cm.Parameters.AddWithValue("@NhapXuat", ((FilterCriteriaByNhapXuat)criteria).NhapXuat);
                    cm.Parameters.AddWithValue("@DoiTuongMuaBan", ((FilterCriteriaByNhapXuat)criteria).DoiTuongMuaBan);
                    cm.Parameters.AddWithValue("@ChuoiTimKiem", ((FilterCriteriaByNhapXuat)criteria).ChuoiTimKiem);
                    cm.Parameters.AddWithValue("@MaNguoiDung", ERP_Library.Security.CurrentUser.Info.UserID);
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(HoaDon.GetHoaDon(dr));
                    }
                }
            }

            else if (criteria is FilterCriteriaByNgayLap)
            {
                using (SqlCommand cm = tr.Connection.CreateCommand())
                {
                    cm.Transaction = tr;
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_SelecttblHoaDonsByNgayNhap";
                    cm.Parameters.AddWithValue("@LoaiHoaDon", ((FilterCriteriaByNgayLap)criteria).LoaiHoaDon);
                    cm.Parameters.AddWithValue("@QuyTrinh", ((FilterCriteriaByNgayLap)criteria).QuyTrinh);
                    cm.Parameters.AddWithValue("@TuNgay", ((FilterCriteriaByNgayLap)criteria).TuNgay);
                    cm.Parameters.AddWithValue("@DenNgay", ((FilterCriteriaByNgayLap)criteria).DenNgay);
                    cm.Parameters.AddWithValue("@mabophan", ((FilterCriteriaByNgayLap)criteria).mabophan);
                    cm.Parameters.AddWithValue("@UserID", ERP_Library.Security.CurrentUser.Info.UserID);
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(HoaDon.GetHoaDon_New(dr));
                    }
                }
            }
            else if (criteria is FilterCriteriaByLoaiNgayLap)
            {
                using (SqlCommand cm = tr.Connection.CreateCommand())
                {
                    cm.Transaction = tr;
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_SelecttblHoaDonsByLoaiNgayNhap";
                    cm.Parameters.AddWithValue("@LoaiHoaDon", ((FilterCriteriaByLoaiNgayLap)criteria).LoaiHoaDon);
                    cm.Parameters.AddWithValue("@TuNgay", ((FilterCriteriaByLoaiNgayLap)criteria).TuNgay);
                    cm.Parameters.AddWithValue("@DenNgay", ((FilterCriteriaByLoaiNgayLap)criteria).DenNgay);
                    cm.Parameters.AddWithValue("@UserID", ERP_Library.Security.CurrentUser.Info.UserID);
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(HoaDon.GetHoaDon_New(dr));
                    }
                }
            }
            else if (criteria is FilterCriteriaByNgayLapCT)
            {
                using (SqlCommand cm = tr.Connection.CreateCommand())
                {
                    cm.Transaction = tr;
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_SelecttblHoaDonsByNgayNhapCT";
                    cm.Parameters.AddWithValue("@LoaiHoaDon", ((FilterCriteriaByNgayLapCT)criteria).LoaiHoaDon);
                    cm.Parameters.AddWithValue("@QuyTrinh", ((FilterCriteriaByNgayLapCT)criteria).QuyTrinh);
                    cm.Parameters.AddWithValue("@TuNgay", ((FilterCriteriaByNgayLapCT)criteria).TuNgay);
                    cm.Parameters.AddWithValue("@DenNgay", ((FilterCriteriaByNgayLapCT)criteria).DenNgay);
                    cm.Parameters.AddWithValue("@manguoilap", ERP_Library.Security.CurrentUser.Info.UserID);
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(HoaDon.GetHoaDon(dr));
                    }
                }
            }
            else if (criteria is FilterCriteriaByNgayLapChuaTT)
            {
                using (SqlCommand cm = tr.Connection.CreateCommand())
                {
                    cm.Transaction = tr;
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_SelecttblHoaDonsByNgayNhapChuaTT";
                    cm.Parameters.AddWithValue("@LoaiHoaDon", ((FilterCriteriaByNgayLapChuaTT)criteria).LoaiHoaDon);
                    cm.Parameters.AddWithValue("@QuyTrinh", ((FilterCriteriaByNgayLapChuaTT)criteria).QuyTrinh);
                    cm.Parameters.AddWithValue("@TuNgay", ((FilterCriteriaByNgayLapChuaTT)criteria).TuNgay);
                    cm.Parameters.AddWithValue("@DenNgay", ((FilterCriteriaByNgayLapChuaTT)criteria).DenNgay);
                    cm.Parameters.AddWithValue("@mabophan", ((FilterCriteriaByNgayLapChuaTT)criteria).mabophan);
                    cm.Parameters.AddWithValue("@manguoilap", ERP_Library.Security.CurrentUser.Info.UserID);
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(HoaDon.GetHoaDon(dr));
                    }
                }
            }

            else if (criteria is FilterCriteriaHDMBByNgayLap)
            {
                using (SqlCommand cm = tr.Connection.CreateCommand())
                {
                    cm.Transaction = tr;
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_SelecttblHoaDonsMuaBanByNgayNhap";
                    cm.Parameters.AddWithValue("@LoaiHoaDon", ((FilterCriteriaHDMBByNgayLap)criteria).LoaiHoaDon);
                    cm.Parameters.AddWithValue("@QuyTrinh", ((FilterCriteriaHDMBByNgayLap)criteria).QuyTrinh);
                    cm.Parameters.AddWithValue("@TuNgay", ((FilterCriteriaHDMBByNgayLap)criteria).TuNgay);
                    cm.Parameters.AddWithValue("@DenNgay", ((FilterCriteriaHDMBByNgayLap)criteria).DenNgay);
                    cm.Parameters.AddWithValue("@MaNguoiDung", ERP_Library.Security.CurrentUser.Info.UserID);
                    cm.Parameters.AddWithValue("@DoiTuongMuaBan", ((FilterCriteriaHDMBByNgayLap)criteria).DoiTuongMuaBan);
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(HoaDon.GetHoaDon(dr));
                    }
                }
            }

            else if (criteria is FilterCriteriaByLoaiHoaDonChuaThanToan)
            {
                using (SqlCommand cm = tr.Connection.CreateCommand())
                {
                    cm.Transaction = tr;
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_SelecttblHoaDonsByLoaiHoaDon";
                    cm.Parameters.AddWithValue("@MaKhachHang", ((FilterCriteriaByLoaiHoaDonChuaThanToan)criteria).maDoiTac);
                    cm.Parameters.AddWithValue("@LoaiHoaDon", ((FilterCriteriaByLoaiHoaDonChuaThanToan)criteria).loaiHoaDon);
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(HoaDon.GetHoaDon(dr));
                    }
                }
            }

            else if (criteria is FilterCriteriaByLoaiHoaDonChuaThanToan_LoaiKhachHang)
            {
                using (SqlCommand cm = tr.Connection.CreateCommand())
                {
                    cm.Transaction = tr;
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_SelecttblHoaDonsByLoaiHoaDon_ChuaThanhToan_LoaiKhachHang";
                    cm.Parameters.AddWithValue("@MaKhachHang", ((FilterCriteriaByLoaiHoaDonChuaThanToan_LoaiKhachHang)criteria).maDoiTac);
                    cm.Parameters.AddWithValue("@LoaiHoaDon", ((FilterCriteriaByLoaiHoaDonChuaThanToan_LoaiKhachHang)criteria).loaiHoaDon);
                    cm.Parameters.AddWithValue("@LoaiKhachHang", ((FilterCriteriaByLoaiHoaDonChuaThanToan_LoaiKhachHang)criteria).loaiKhachHang);
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(HoaDon.GetHoaDon(dr));
                    }
                }
            }
            else if (criteria is FilterCriteriaByTatToan)
            {
                using (SqlCommand cm = tr.Connection.CreateCommand())
                {
                    cm.Transaction = tr;
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_SelecttblHoaDonsByTatToan";
                    cm.Parameters.AddWithValue("@LoaiHoaDon", ((FilterCriteriaByTatToan)criteria).loaiHoaDon);
                    cm.Parameters.AddWithValue("@MaHopDong", ((FilterCriteriaByTatToan)criteria).maHopDong);
                    cm.Parameters.AddWithValue("@TatToan", ((FilterCriteriaByTatToan)criteria).tatToan);
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(HoaDon.GetHoaDon(dr));
                    }
                }
            }

            else if (criteria is FilterCriteria_ChuyenKhoan)
            {
                using (SqlCommand cm = tr.Connection.CreateCommand())
                {
                    cm.Transaction = tr;
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_SelecttblHoaDonsByLoaiHoaDon_ChuyenKhoan";
                    cm.Parameters.AddWithValue("@LoaiHoaDon", ((FilterCriteria_ChuyenKhoan)criteria).LoaiHoaDon);
                    cm.Parameters.AddWithValue("@MaKhachHang", ((FilterCriteria_ChuyenKhoan)criteria).MaKhachHang);

                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(HoaDon.GetHoaDon(dr));
                    }
                }
            }

            else if (criteria is FilterCriteriaHDMBByFull)
            {
                using (SqlCommand cm = tr.Connection.CreateCommand())
                {
                    cm.Transaction = tr;
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_SelecttblHoaDonsMuaBanByTimKiemFull";
                    cm.Parameters.AddWithValue("@LoaiHoaDon", ((FilterCriteriaHDMBByFull)criteria).LoaiHoaDon);
                    cm.Parameters.AddWithValue("@QuyTrinh", ((FilterCriteriaHDMBByFull)criteria).QuyTrinh);
                    if (((FilterCriteriaHDMBByFull)criteria).TuNgay != DateTime.MinValue)
                        cm.Parameters.AddWithValue("@TuNgay", ((FilterCriteriaHDMBByFull)criteria).TuNgay);
                    else cm.Parameters.AddWithValue("@TuNgay", DBNull.Value);
                    if (((FilterCriteriaHDMBByFull)criteria).DenNgay != DateTime.MinValue)
                        cm.Parameters.AddWithValue("@DenNgay", ((FilterCriteriaHDMBByFull)criteria).DenNgay);
                    else cm.Parameters.AddWithValue("@DenNgay", DBNull.Value);
                    cm.Parameters.AddWithValue("@MaNguoiDung", ERP_Library.Security.CurrentUser.Info.UserID);
                    cm.Parameters.AddWithValue("@DoiTuongMuaBan", ((FilterCriteriaHDMBByFull)criteria).DoiTuongMuaBan);
                    cm.Parameters.AddWithValue("@ChuoiTimKiem", ((FilterCriteriaHDMBByFull)criteria).ChuoiTimKiem);
                    cm.Parameters.AddWithValue("@ChuoiHHDV", ((FilterCriteriaHDMBByFull)criteria).ChuoiHHDV);
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(HoaDon.GetHoaDon(dr));
                    }
                }
            }
            else if (criteria is FilterCriteriaByLoaiHoaDonDichVu)
            {
                using (SqlCommand cm = tr.Connection.CreateCommand())
                {
                    cm.Transaction = tr;
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_SelecttblHoaDonsByHoaDonDichVu";
                    cm.Parameters.AddWithValue("@MaKhachHang", ((FilterCriteriaByLoaiHoaDonDichVu)criteria).maDoiTac);
                    cm.Parameters.AddWithValue("@TinhTrang", ((FilterCriteriaByLoaiHoaDonDichVu)criteria).TinhTrang);
                    cm.Parameters.AddWithValue("@TatToan", ((FilterCriteriaByLoaiHoaDonDichVu)criteria).TatToan);
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(HoaDon.GetHoaDon(dr));
                    }
                }
            }
            else if (criteria is FilterCriteriaByLoaiHoaDonDichVu_ChungTu)
            {
                using (SqlCommand cm = tr.Connection.CreateCommand())
                {
                    cm.Transaction = tr;
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_SelecttblHoaDonsByHoaDonDichVu_ChungTu";
                    cm.Parameters.AddWithValue("@MaKhachHang", ((FilterCriteriaByLoaiHoaDonDichVu_ChungTu)criteria).maDoiTac);
                    cm.Parameters.AddWithValue("@TinhTrang", ((FilterCriteriaByLoaiHoaDonDichVu_ChungTu)criteria).TinhTrang);
                    cm.Parameters.AddWithValue("@TatToan", ((FilterCriteriaByLoaiHoaDonDichVu_ChungTu)criteria).TatToan);
                    cm.Parameters.AddWithValue("@MaChungTu", ((FilterCriteriaByLoaiHoaDonDichVu_ChungTu)criteria).machungtu);
                    cm.Parameters.AddWithValue("@MAButToan", ((FilterCriteriaByLoaiHoaDonDichVu_ChungTu)criteria).mabuttoan);
                    cm.Parameters.AddWithValue("@mabophan", Security.CurrentUser.Info.MaBoPhan);
                    cm.Parameters.AddWithValue("@manguoilap", Security.CurrentUser.Info.UserID);

                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(HoaDon.GetHoaDon(dr));
                    }
                }
            }
            else if (criteria is FilterCriteriaByLoaiHoaDonDichVu_ChungTubyLoaiHoaDon)
            {
                using (SqlCommand cm = tr.Connection.CreateCommand())
                {
                    cm.Transaction = tr;
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_SelecttblHoaDonsByHoaDonDichVu_ChungTubyLoaiHoaDon";
                    cm.Parameters.AddWithValue("@LoaiHoaDon", ((FilterCriteriaByLoaiHoaDonDichVu_ChungTubyLoaiHoaDon)criteria).LoaiHoaDon);
                    cm.Parameters.AddWithValue("@MaKhachHang", ((FilterCriteriaByLoaiHoaDonDichVu_ChungTubyLoaiHoaDon)criteria).maDoiTac);
                    cm.Parameters.AddWithValue("@TinhTrang", ((FilterCriteriaByLoaiHoaDonDichVu_ChungTubyLoaiHoaDon)criteria).TinhTrang);
                    cm.Parameters.AddWithValue("@TatToan", ((FilterCriteriaByLoaiHoaDonDichVu_ChungTubyLoaiHoaDon)criteria).TatToan);
                    cm.Parameters.AddWithValue("@MaChungTu", ((FilterCriteriaByLoaiHoaDonDichVu_ChungTubyLoaiHoaDon)criteria).machungtu);
                    cm.Parameters.AddWithValue("@MAButToan", ((FilterCriteriaByLoaiHoaDonDichVu_ChungTubyLoaiHoaDon)criteria).mabuttoan);
                    cm.Parameters.AddWithValue("@mabophan", Security.CurrentUser.Info.MaBoPhan);
                    cm.Parameters.AddWithValue("@manguoilap", Security.CurrentUser.Info.UserID);

                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(HoaDon.GetHoaDon(dr));
                    }
                }
            }
            else if (criteria is FilterCriteriaByLoaiHoaDonDichVu_ChungTu_NguoiLap)
            {
                using (SqlCommand cm = tr.Connection.CreateCommand())
                {
                    cm.Transaction = tr;
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_SelecttblHoaDonsByHoaDonDichVu_ChungTu_NguoiLap";
                    cm.Parameters.AddWithValue("@MaKhachHang", ((FilterCriteriaByLoaiHoaDonDichVu_ChungTu_NguoiLap)criteria).maDoiTac);
                    cm.Parameters.AddWithValue("@TinhTrang", ((FilterCriteriaByLoaiHoaDonDichVu_ChungTu_NguoiLap)criteria).TinhTrang);
                    cm.Parameters.AddWithValue("@TatToan", ((FilterCriteriaByLoaiHoaDonDichVu_ChungTu_NguoiLap)criteria).TatToan);
                    cm.Parameters.AddWithValue("@MaChungTu", ((FilterCriteriaByLoaiHoaDonDichVu_ChungTu_NguoiLap)criteria).machungtu);
                    cm.Parameters.AddWithValue("@MAButToan", ((FilterCriteriaByLoaiHoaDonDichVu_ChungTu_NguoiLap)criteria).mabuttoan);
                    cm.Parameters.AddWithValue("@MaNguoilap", ((FilterCriteriaByLoaiHoaDonDichVu_ChungTu_NguoiLap)criteria).manguoilap);
                    cm.Parameters.AddWithValue("@mabophan", Security.CurrentUser.Info.MaBoPhan);
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(HoaDon.GetHoaDon(dr));
                    }
                }
            }
            else if (criteria is FilterCriteriaForLapChungTu_HoaDon)
            {
                using (SqlCommand cm = tr.Connection.CreateCommand())
                {
                    cm.Transaction = tr;
                    cm.CommandType = CommandType.StoredProcedure;
                    //cm.CommandText = "spd_SelecttblHoaDonsForLapChungTu_HoaDon";
                    cm.CommandText = "spd_SelecttblHoaDonsForLapChungTu_HoaDonThanhToan";
                    cm.Parameters.AddWithValue("@MaKhachHang", ((FilterCriteriaForLapChungTu_HoaDon)criteria).MaDoiTac);
                    cm.Parameters.AddWithValue("@MaLoaiChungTu", ((FilterCriteriaForLapChungTu_HoaDon)criteria).MaLoaiChungTu);
                    cm.Parameters.AddWithValue("@MaNguoilap", Security.CurrentUser.Info.UserID);
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(HoaDon.GetHoaDonWithoutChild(dr));
                    }
                }
            }
            else if (criteria is FilterCriteriaByLapPhieu)
            {
                using (SqlCommand cm = tr.Connection.CreateCommand())
                {
                    cm.Transaction = tr;
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_SelecttblHoaDonsByLapPhieu";
                    cm.Parameters.AddWithValue("@MaDoiTac", ((FilterCriteriaByLapPhieu)criteria).maDoiTac);
                    cm.Parameters.AddWithValue("@LoaiHoaDon", ((FilterCriteriaByLapPhieu)criteria).loaiHoaDon);
                    cm.Parameters.AddWithValue("@TinhTrang", ((FilterCriteriaByLapPhieu)criteria).tinhTrang);
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(HoaDon.GetHoaDonWithoutChild(dr));
                    }
                }
            }
            else if (criteria is FilterCriteriaBanQuyenLapPhieu)
            {
                using (SqlCommand cm = tr.Connection.CreateCommand())
                {
                    cm.Transaction = tr;
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_SelecttblHoaDonsBanQuyenLapPhieu";
                    cm.Parameters.AddWithValue("@MaDoiTac", ((FilterCriteriaBanQuyenLapPhieu)criteria).maDoiTac);
                    cm.Parameters.AddWithValue("@TinhTrang", ((FilterCriteriaBanQuyenLapPhieu)criteria).tinhTrang);
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(HoaDon.GetHoaDonWithoutChild(dr));
                    }
                }
            }
            else if (criteria is FilterCriteriaHoaDonBanQuyenLapChungTu)
            {
                using (SqlCommand cm = tr.Connection.CreateCommand())
                {
                    cm.Transaction = tr;
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_SelecttblHoaDonsBanQuyenLapChungTu";
                    cm.Parameters.AddWithValue("@MaDoiTac", ((FilterCriteriaHoaDonBanQuyenLapChungTu)criteria).maDoiTac);
                    cm.Parameters.AddWithValue("@TinhTrang", ((FilterCriteriaHoaDonBanQuyenLapChungTu)criteria).tinhTrang);
                    cm.Parameters.AddWithValue("@MaNguoilap", ERP_Library.Security.CurrentUser.Info.UserID);
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(HoaDon.GetHoaDonWithoutChild(dr));
                    }
                }
            }

            else if (criteria is FilterCriteriaByMaPhieuNhapXuat)
            {
                using (SqlCommand cm = tr.Connection.CreateCommand())
                {
                    cm.Transaction = tr;
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_SelecttblHoaDonsByMaPhieuNhapXuat";
                    cm.Parameters.AddWithValue("@MaPhieuNhapxuat", ((FilterCriteriaByMaPhieuNhapXuat)criteria).MaPhieuNhapXuat);

                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(HoaDon.GetHoaDon(dr));
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
                    foreach (HoaDon deletedChild in DeletedList)
                    {                      
                        deletedChild.DeleteSelf(tr);
                        //HoaDon obj = HoaDon.GetHoaDon(deletedChild.MaHoaDon);
                        //obj.DeleteSelf(tr);
                    }
                    DeletedList.Clear();

                    // loop through each non-deleted child object
                    foreach (HoaDon child in this)
                    {
                        if (child.IsNew)
                            child.Insert(tr, this);
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

        public void DataPortal_Update(SqlTransaction tr)
        {
            RaiseListChangedEvents = false;
            try
            {
                // loop through each deleted child object
                foreach (HoaDon deletedChild in DeletedList)
                    deletedChild.DeleteSelf(tr);
                DeletedList.Clear();

                // loop through each non-deleted child object
                foreach (HoaDon child in this)
                {
                    if (child.IsNew)
                        child.Insert(tr, this);
                    else
                        child.Update(tr, this);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            RaiseListChangedEvents = true;
        }
        #endregion //Data Access - Update
        #endregion //Data Access
    }
}
