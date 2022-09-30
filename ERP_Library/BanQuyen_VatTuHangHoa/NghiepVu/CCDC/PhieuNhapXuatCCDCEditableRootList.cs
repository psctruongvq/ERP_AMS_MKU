
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
//23_04_2013

namespace ERP_Library//05012016
{
    [Serializable()]
    public class PhieuNhapXuatCCDCList : Csla.BusinessListBase<PhieuNhapXuatCCDCList, PhieuNhapXuatCCDC>
    {
        #region BindingList Overrides
        protected override object AddNewCore()
        {
            PhieuNhapXuatCCDC item = PhieuNhapXuatCCDC.NewPhieuNhapXuat();
            this.Add(item);
            return item;
        }
        #endregion //BindingList Overrides

        #region Authorization Rules

        public static bool CanGetObject()
        {
            //TODO: Define CanGetObject permission in PhieuNhapXuatList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("PhieuNhapXuatListViewGroup"))
            //	return true;
            //return false;
        }

        public static bool CanAddObject()
        {
            //TODO: Define CanAddObject permission in PhieuNhapXuatList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("PhieuNhapXuatListAddGroup"))
            //	return true;
            //return false;
        }

        public static bool CanEditObject()
        {
            //TODO: Define CanEditObject permission in PhieuNhapXuatList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("PhieuNhapXuatListEditGroup"))
            //	return true;
            //return false;
        }

        public static bool CanDeleteObject()
        {
            //TODO: Define CanDeleteObject permission in PhieuNhapXuatList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("PhieuNhapXuatListDeleteGroup"))
            //	return true;
            //return false;
        }
        #endregion //Authorization Rules

        #region Factory Methods
        private PhieuNhapXuatCCDCList()
        { /* require use of factory method */ }

        public static PhieuNhapXuatCCDCList NewPhieuNhapXuatList()
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a PhieuNhapXuatList");
            return new PhieuNhapXuatCCDCList();
        }

        public static PhieuNhapXuatCCDCList GetPhieuNhapXuatList(int maNguoiLap, int maKho, long maDoiTac, int maDinhKhoan, long maNguoiNhapXuat, int maPhongBan, long maPhieuNhapXuatThamChieu)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a PhieuNhapXuatList");
            return DataPortal.Fetch<PhieuNhapXuatCCDCList>(new FilterCriteria(maNguoiLap, maKho, maDoiTac, maDinhKhoan, maNguoiNhapXuat, maPhongBan, maPhieuNhapXuatThamChieu));
        }
        public static PhieuNhapXuatCCDCList GetPhieuNhapXuatList(int _maKho, long _maDoiTac, long _maNguoiNhapXuat, int _maPhongBan, byte _phuongPhapNX, bool _laNhap, int _loaiPhieu, int _userID)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a PhieuNhapXuatList");
            return DataPortal.Fetch<PhieuNhapXuatCCDCList>(new FilterCriteriaByTim(_maKho, _maDoiTac, _maNguoiNhapXuat, _maPhongBan, _phuongPhapNX, _laNhap, _loaiPhieu, _userID));
        }

        public static PhieuNhapXuatCCDCList GetPhieuNhapXuatList(int _maKho, long _maDoiTac, long _maNguoiNhapXuat, int _maPhongBan, byte _phuongPhapNX, DateTime _tuNgay, DateTime _denNgay, bool _laNhap, int _loaiPhieu, int _userID)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a PhieuNhapXuatList");
            return DataPortal.Fetch<PhieuNhapXuatCCDCList>(new FilterCriteriaByTimTheoNgay(_maKho, _maDoiTac, _maNguoiNhapXuat, _maPhongBan, _phuongPhapNX, _tuNgay, _denNgay, _laNhap, _loaiPhieu, _userID));
        }
        //M
        public static PhieuNhapXuatCCDCList GetPhieuNhapXuatList(int _maKho, DateTime _ngayNX)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a PhieuNhapXuatList");
            return DataPortal.Fetch<PhieuNhapXuatCCDCList>(new FilterCriteriaByMaKho(_maKho, _ngayNX));
        }
        public static PhieuNhapXuatCCDCList GetDSPhieuNhapThangChuaXuatHetTheoMaKho(int maKho)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a PhieuNhapXuatList");
            return DataPortal.Fetch<PhieuNhapXuatCCDCList>(new FilterCriteriaDSPhieuNhapThangChuaXuatHetTheoMaKho(maKho));
        }
        public static PhieuNhapXuatCCDCList GetPhieuNhapXuatList(int _loai, bool _laNhap)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a PhieuNhapXuatList");
            return DataPortal.Fetch<PhieuNhapXuatCCDCList>(new FilterCriteriaByLoaiVaLaNhap(_loai, _laNhap));
        }
        public static PhieuNhapXuatCCDCList GetPhieuNhapXuatList(int _maKho, int _maBoPhan)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a PhieuNhapXuatList");
            return DataPortal.Fetch<PhieuNhapXuatCCDCList>(new FilterCriteriaByMaKhoAndMaBoPhan(_maKho, _maBoPhan));
        }
        public static PhieuNhapXuatCCDCList GetPhieuNhapXuatList(int _maKho, int _maBoPhan, int _phuongPhapNX, DateTime _ngayNX)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a PhieuNhapXuatList");
            return DataPortal.Fetch<PhieuNhapXuatCCDCList>(new FilterCriteriaByMaKhoAndMaBoPhanAndPhuongPhapNX(_maKho, _maBoPhan, _phuongPhapNX, _ngayNX));
        }

        public static PhieuNhapXuatCCDCList GetPhieuNhapXuatList(int _maKho, long _maNguoiNhapXuat, int _maPhongBan, byte _phuongPhapNX, DateTime _tuNgay, DateTime _denNgay, bool _laNhap)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a PhieuNhapXuatList");
            return DataPortal.Fetch<PhieuNhapXuatCCDCList>(new FilterCriteriaByXacNhanTimTheoNgay(_maKho, _maNguoiNhapXuat, _maPhongBan, _phuongPhapNX, _tuNgay, _denNgay, _laNhap));
        }
        public static PhieuNhapXuatCCDCList GetPhieuNhapXuatList(int _maKho, long _maNguoiNhapXuat, int _maPhongBan, byte _phuongPhapNX, bool _laNhap)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a PhieuNhapXuatList");
            return DataPortal.Fetch<PhieuNhapXuatCCDCList>(new FilterCriteriaByXacNhanAll(_maKho, _maNguoiNhapXuat, _maPhongBan, _phuongPhapNX, _laNhap));
        }
        //End M

        public static PhieuNhapXuatCCDCList GetPhieuNhapXuatList()
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a PhieuNhapXuatList");
            return DataPortal.Fetch<PhieuNhapXuatCCDCList>(new FilterCriteria());
        }

        public static PhieuNhapXuatCCDCList GetPhieuNhapXuatList_TimTheoLoaiVaNgay(int loai, DateTime ngay, DateTime denNgay)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a PhieuNhapXuatList");
            return DataPortal.Fetch<PhieuNhapXuatCCDCList>(new FilterCriteria_TimTheoLoaiVaNgay(loai, ngay, denNgay));
        }
        public static PhieuNhapXuatCCDCList GetPhieuNhapXuatList_TimTheoLoaiVaSoChungTu(int loai, string soChungTu, string phepToanSoSanh)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a PhieuNhapXuatList");
            return DataPortal.Fetch<PhieuNhapXuatCCDCList>(new FilterCriteria_TimTheoLoaiVaSoChungTu(loai, soChungTu, phepToanSoSanh));
        }
        public static PhieuNhapXuatCCDCList GetPhieuNhapXuatList_TimTheoLoaiVaSoTien(int loai, decimal soTien, string phepToanSoSanh)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a PhieuNhapXuatList");
            return DataPortal.Fetch<PhieuNhapXuatCCDCList>(new FilterCriteria_TimTheoLoaiVaSoTien(loai, soTien, phepToanSoSanh));
        }

        #region Tim Kiem DS Chuong Trinh Nhap Xuat Ban Quyen Theo Hop Dong
        public static DataTable DanhSachChuongTrinhNhapBQTheoHopDong(long maHopDong)
        {
            //
            DataTable kqTbl = new DataTable();
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                // @TuNgay datatime, @DenNgay datatime, @MaBoPhan int, @ChuongTrinh int, @DienGiai nvarchar(max)
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandTimeout = 1800;
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "Spd_TimDanhSachChuongTrinhNhapBQTheoHopDong";
                    cm.Parameters.AddWithValue("@MaHopDong", maHopDong);
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

        public static DataTable DanhSachChuongTrinhXuatBQTheoHopDong(long maHopDong)
        {
            //
            DataTable kqTbl = new DataTable();
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                // @TuNgay datatime, @DenNgay datatime, @MaBoPhan int, @ChuongTrinh int, @DienGiai nvarchar(max)
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandTimeout = 1800;
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "Spd_TimDanhSachChuongTrinhXuatBQTheoHopDong";
                    cm.Parameters.AddWithValue("@MaHopDong", maHopDong);
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
        #endregion//Tim Kiem DS Chuong Trinh Nhap Xuat Ban Quyen Theo Hop Dong
        #endregion //Factory Methods

        #region Data Access

        #region Filter Criteria
        [Serializable()]
        private class FilterCriteria
        {
            public int MaNguoiLap;
            public int MaKho;
            public long MaDoiTac;
            public int MaDinhKhoan;
            public long MaNguoiNhapXuat;
            public int MaPhongBan;
            public long MaPhieuNhapXuatThamChieu;

            public FilterCriteria()
            { }
            public FilterCriteria(int maNguoiLap, int maKho, long maDoiTac, int maDinhKhoan, long maNguoiNhapXuat, int maPhongBan, long maPhieuNhapXuatThamChieu)
            {
                this.MaNguoiLap = maNguoiLap;
                this.MaKho = maKho;
                this.MaDoiTac = maDoiTac;
                this.MaDinhKhoan = maDinhKhoan;
                this.MaNguoiNhapXuat = maNguoiNhapXuat;
                this.MaPhongBan = maPhongBan;
                this.MaPhieuNhapXuatThamChieu = maPhieuNhapXuatThamChieu;

            }
        }
        [Serializable()]
        private class FilterCriteria_TimTheoLoaiVaNgay
        {
            public int Loai = 0;
            public DateTime Ngay;
            public DateTime DenNgay;
            public FilterCriteria_TimTheoLoaiVaNgay(int loai, DateTime ngay, DateTime denNgay)
            {
                this.Loai = loai;
                this.Ngay = ngay;
                this.DenNgay = denNgay;
            }
        }
        [Serializable()]
        private class FilterCriteria_TimTheoLoaiVaSoChungTu
        {
            public int Loai = 0;
            public String SoChungTu = null;
            public string PhepToanSoSanh = "";
            public FilterCriteria_TimTheoLoaiVaSoChungTu(int loai, string soChungTu, string phepToanSoSanh)
            {
                this.Loai = loai;
                this.SoChungTu = soChungTu;
                this.PhepToanSoSanh = phepToanSoSanh;
            }
        }

        [Serializable()]
        private class FilterCriteria_TimTheoLoaiVaSoTien
        {
            public int Loai = 0;
            public decimal SoTien = 0;
            public string PhepToanSoSanh = "";
            public FilterCriteria_TimTheoLoaiVaSoTien(int loai, decimal soTien, string phepToanSoSanh)
            {
                this.Loai = loai;
                this.SoTien = soTien;
                this.PhepToanSoSanh = phepToanSoSanh;
            }
        }
        private class FilterCriteriaByTim
        {
            public int MaKho = 0;
            public long MaDoiTac = 0;
            public long MaNguoiNhapXuat = 0;
            public int MaPhongBan = 0;
            public byte PhuongPhapNX = 0;
            public bool LaNhap = false;
            public int LoaiPhieu = 0;
            public int UserID = 0;

            public FilterCriteriaByTim(int _maKho, long _maDoiTac, long _maNguoiNhapXuat, int _maPhongBan, byte _phuongPhapNX, bool _laNhap, int _loaiPhieu, int _userID)
            {
                MaKho = _maKho;
                MaDoiTac = _maDoiTac;
                MaNguoiNhapXuat = _maNguoiNhapXuat;
                MaPhongBan = _maPhongBan;
                PhuongPhapNX = _phuongPhapNX;
                LaNhap = _laNhap;
                LoaiPhieu = _loaiPhieu;
                UserID = _userID;
            }
        }

        private class FilterCriteriaByTimTheoNgay
        {
            public int MaKho = 0;
            public long MaDoiTac = 0;
            public long MaNguoiNhapXuat = 0;
            public int MaPhongBan = 0;
            public byte PhuongPhapNX = 0;
            public DateTime TuNgay;
            public DateTime DenNgay;
            public bool LaNhap = false;
            public int LoaiPhieu = 0;
            public int UserID = 0;

            public FilterCriteriaByTimTheoNgay(int _maKho, long _maDoiTac, long _maNguoiNhapXuat, int _maPhongBan, byte _phuongPhapNX, DateTime _tuNgay, DateTime _denNgay, bool _laNhap, int _loaiPhieu, int _userID)
            {
                MaKho = _maKho;
                MaDoiTac = _maDoiTac;
                MaNguoiNhapXuat = _maNguoiNhapXuat;
                MaPhongBan = _maPhongBan;
                PhuongPhapNX = _phuongPhapNX;
                TuNgay = _tuNgay;
                DenNgay = _denNgay;
                LaNhap = _laNhap;
                LoaiPhieu = _loaiPhieu;
                UserID = _userID;
            }

        }
        //M
        private class FilterCriteriaByMaKho
        {
            public int MaKho = 0;
            public DateTime NgayNX;
            public FilterCriteriaByMaKho(int _maKho, DateTime _ngayNX)
            {
                MaKho = _maKho;
                NgayNX = _ngayNX;
            }
        }

        private class FilterCriteriaDSPhieuNhapThangChuaXuatHetTheoMaKho
        {
            public int MaKho = 0;
            public FilterCriteriaDSPhieuNhapThangChuaXuatHetTheoMaKho(int maKho)
            {
                MaKho = maKho;
            }
        }
        private class FilterCriteriaByLoaiVaLaNhap
        {
            public int Loai = 0;
            public bool LaNhap = false;
            public FilterCriteriaByLoaiVaLaNhap(int _loai, bool _laNhap)
            {
                Loai = _loai;
                LaNhap = _laNhap;
            }
        }
        private class FilterCriteriaByMaKhoAndMaBoPhan
        {
            public int MaKho = 0;
            public int MaBoPhan = 0;
            public FilterCriteriaByMaKhoAndMaBoPhan(int _maKho, int _maBoPhan)
            {
                MaKho = _maKho;
                MaBoPhan = _maBoPhan;
            }
        }
        private class FilterCriteriaByMaKhoAndMaBoPhanAndPhuongPhapNX
        {
            public int MaKho = 0;
            public int MaBoPhan = 0;
            public int PhuongPhapNX = 0;
            public DateTime NgayNX;
            public FilterCriteriaByMaKhoAndMaBoPhanAndPhuongPhapNX(int _maKho, int _maBoPhan, int _phuongPhapNX, DateTime _ngayNX)
            {
                MaKho = _maKho;
                MaBoPhan = _maBoPhan;
                PhuongPhapNX = _phuongPhapNX;
                NgayNX = _ngayNX;
            }
        }

        private class FilterCriteriaByXacNhanTimTheoNgay
        {
            public int MaKho = 0;
            public long MaNguoiNhapXuat = 0;
            public int MaPhongBan = 0;
            public byte PhuongPhapNX = 0;
            public DateTime TuNgay;
            public DateTime DenNgay;
            public bool LaNhap = false;

            public FilterCriteriaByXacNhanTimTheoNgay(int _maKho, long _maNguoiNhapXuat, int _maPhongBan, byte _phuongPhapNX, DateTime _tuNgay, DateTime _denNgay, bool _laNhap)
            {
                MaKho = _maKho;
                MaNguoiNhapXuat = _maNguoiNhapXuat;
                MaPhongBan = _maPhongBan;
                PhuongPhapNX = _phuongPhapNX;
                TuNgay = _tuNgay;
                DenNgay = _denNgay;
                LaNhap = _laNhap;

            }

        }
        private class FilterCriteriaByXacNhanAll
        {
            public int MaKho = 0;
            public long MaNguoiNhapXuat = 0;
            public int MaPhongBan = 0;
            public byte PhuongPhapNX = 0;
            public bool LaNhap = false;

            public FilterCriteriaByXacNhanAll(int _maKho, long _maNguoiNhapXuat, int _maPhongBan, byte _phuongPhapNX, bool _laNhap)
            {
                MaKho = _maKho;
                MaNguoiNhapXuat = _maNguoiNhapXuat;
                MaPhongBan = _maPhongBan;
                PhuongPhapNX = _phuongPhapNX;
                LaNhap = _laNhap;

            }

        }
        //End M

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
                    cm.CommandText = "spd_SelecttblPhieuNhapXuatsAll";
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(PhieuNhapXuatCCDC.GetPhieuNhapXuat(dr));
                    }
                }
                else if (criteria is FilterCriteria_TimTheoLoaiVaNgay)
                {
                    cm.CommandText = "spd_GetPhieuNhapXuatList_TimTheoLoaiVaNgay";
                    cm.Parameters.AddWithValue("@Loai", ((FilterCriteria_TimTheoLoaiVaNgay)criteria).Loai);

                    if (((FilterCriteria_TimTheoLoaiVaNgay)criteria).Ngay != DateTime.MinValue)
                        cm.Parameters.AddWithValue("@Ngay", ((FilterCriteria_TimTheoLoaiVaNgay)criteria).Ngay);
                    else
                        cm.Parameters.AddWithValue("@Ngay", DBNull.Value);

                    if (((FilterCriteria_TimTheoLoaiVaNgay)criteria).DenNgay != DateTime.MinValue)
                        cm.Parameters.AddWithValue("@DenNgay", ((FilterCriteria_TimTheoLoaiVaNgay)criteria).DenNgay);
                    else
                        cm.Parameters.AddWithValue("@DenNgay", DBNull.Value);

                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(PhieuNhapXuatCCDC.GetPhieuNhapXuat(dr));
                    }

                }
                else if (criteria is FilterCriteria_TimTheoLoaiVaSoChungTu)
                {
                    cm.CommandText = "spd_GetPhieuNhapXuatList_TimTheoLoaiVaSoChungTu";
                    cm.Parameters.AddWithValue("@Loai", ((FilterCriteria_TimTheoLoaiVaSoChungTu)criteria).Loai);
                    cm.Parameters.AddWithValue("@SoChungTu", ((FilterCriteria_TimTheoLoaiVaSoChungTu)criteria).SoChungTu);
                    cm.Parameters.AddWithValue("@PhepToanSoSanh", ((FilterCriteria_TimTheoLoaiVaSoChungTu)criteria).PhepToanSoSanh);
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(PhieuNhapXuatCCDC.GetPhieuNhapXuat(dr));
                    }
                }
                else if (criteria is FilterCriteria_TimTheoLoaiVaSoTien)
                {
                    cm.CommandText = "spd_GetPhieuNhapXuatList_TimTheoLoaiVaSoTien";
                    cm.Parameters.AddWithValue("@Loai", ((FilterCriteria_TimTheoLoaiVaSoTien)criteria).Loai);
                    cm.Parameters.AddWithValue("@SoTien", ((FilterCriteria_TimTheoLoaiVaSoTien)criteria).SoTien);
                    cm.Parameters.AddWithValue("@PhepToanSoSanh", ((FilterCriteria_TimTheoLoaiVaSoTien)criteria).PhepToanSoSanh);
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(PhieuNhapXuatCCDC.GetPhieuNhapXuat(dr));
                    }

                }
                else if (criteria is FilterCriteriaByTim)
                {
                    if (((FilterCriteriaByTim)criteria).LoaiPhieu == 0)
                    {
                        cm.CommandText = "spd_SelecttblPhieuXuatVatTu_NhienLieusTim";//Danh Sach Phieu Xuat Vat Tu _Nhien Lieu
                    }
                    else
                    {
                        cm.CommandText = "spd_SelecttblPhieuNhapXuatsTim";//Danh Sach Phieu Xuat Vat Tu
                    }
                    cm.Parameters.AddWithValue("@MaKho", ((FilterCriteriaByTim)criteria).MaKho);
                    cm.Parameters.AddWithValue("@MaDoiTac", ((FilterCriteriaByTim)criteria).MaDoiTac);
                    cm.Parameters.AddWithValue("@LaNhap", ((FilterCriteriaByTim)criteria).LaNhap);
                    cm.Parameters.AddWithValue("@LoaiPhieu", ((FilterCriteriaByTim)criteria).LoaiPhieu);
                    cm.Parameters.AddWithValue("@MaNguoiNhapXuat", ((FilterCriteriaByTim)criteria).MaNguoiNhapXuat);
                    cm.Parameters.AddWithValue("@MaPhongBan", ((FilterCriteriaByTim)criteria).MaPhongBan);
                    cm.Parameters.AddWithValue("@PhuongPhapNX", ((FilterCriteriaByTim)criteria).PhuongPhapNX);
                    cm.Parameters.AddWithValue("@UserID", ((FilterCriteriaByTim)criteria).UserID);
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            //this.Add(PhieuNhapXuat.GetPhieuNhapXuat(dr));//Old
                            //this.Add(PhieuNhapXuatCCDC.GetPhieuNhapXuatKhongChild(dr));//New
                            this.Add(PhieuNhapXuatCCDC.GetPhieuNhapXuat_SoHoaDon(dr));//New
                    }
                }
                else if (criteria is FilterCriteriaByTimTheoNgay)
                {
                    if (((FilterCriteriaByTimTheoNgay)criteria).LoaiPhieu == 0)
                    {
                        cm.CommandText = "spd_SelecttblPhieuXuatVatTu_NhienLieusTimTheoNgay";//Xuat Phieu Xuat Vat Tu Va Nhien Lieu
                    }
                    else
                    {
                        cm.CommandText = "spd_SelecttblPhieuNhapXuatsTimTheoNgay";//Xuat Phieu Xuat Vat Tu
                    }
                    cm.Parameters.AddWithValue("@MaKho", ((FilterCriteriaByTimTheoNgay)criteria).MaKho);
                    cm.Parameters.AddWithValue("@MaDoiTac", ((FilterCriteriaByTimTheoNgay)criteria).MaDoiTac);
                    cm.Parameters.AddWithValue("@LaNhap", ((FilterCriteriaByTimTheoNgay)criteria).LaNhap);
                    cm.Parameters.AddWithValue("@LoaiPhieu", ((FilterCriteriaByTimTheoNgay)criteria).LoaiPhieu);
                    cm.Parameters.AddWithValue("@MaNguoiNhapXuat", ((FilterCriteriaByTimTheoNgay)criteria).MaNguoiNhapXuat);
                    cm.Parameters.AddWithValue("@MaPhongBan", ((FilterCriteriaByTimTheoNgay)criteria).MaPhongBan);
                    cm.Parameters.AddWithValue("@PhuongPhapNX", ((FilterCriteriaByTimTheoNgay)criteria).PhuongPhapNX);
                    cm.Parameters.AddWithValue("@TuNgay", ((FilterCriteriaByTimTheoNgay)criteria).TuNgay);
                    cm.Parameters.AddWithValue("@DenNgay", ((FilterCriteriaByTimTheoNgay)criteria).DenNgay);
                    cm.Parameters.AddWithValue("@UserID", ((FilterCriteriaByTimTheoNgay)criteria).UserID);
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                        {
                            //this.Add(PhieuNhapXuat.GetPhieuNhapXuat(dr));//Old
                            //this.Add(PhieuNhapXuatCCDC.GetPhieuNhapXuatKhongChild(dr));//New
                            this.Add(PhieuNhapXuatCCDC.GetPhieuNhapXuat_SoHoaDon(dr));
                        }
                    }

                }
                //M
                else if (criteria is FilterCriteriaByMaKho)
                {
                    cm.CommandText = "spd_SelecttblPhieuNhapByMaKho";
                    cm.Parameters.AddWithValue("@MaKho", ((FilterCriteriaByMaKho)criteria).MaKho);
                    cm.Parameters.AddWithValue("@NgayNX", ((FilterCriteriaByMaKho)criteria).NgayNX);
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(PhieuNhapXuatCCDC.GetPhieuNhapXuat(dr));
                    }
                }
                else if (criteria is FilterCriteriaDSPhieuNhapThangChuaXuatHetTheoMaKho)
                {
                    cm.CommandText = "spd_GetDSPhieuNhapThangChuaXuatHetTheoMaKho";
                    cm.Parameters.AddWithValue("@MaKho", ((FilterCriteriaDSPhieuNhapThangChuaXuatHetTheoMaKho)criteria).MaKho);
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(PhieuNhapXuatCCDC.GetPhieuNhapXuat(dr));
                    }
                }
                else if (criteria is FilterCriteriaByLoaiVaLaNhap)
                {
                    cm.CommandText = "spd_SelecttblPhieuNhapByLoaiVaLaNhap";
                    cm.Parameters.AddWithValue("@Loai", ((FilterCriteriaByLoaiVaLaNhap)criteria).Loai);
                    cm.Parameters.AddWithValue("@LaNhap", ((FilterCriteriaByLoaiVaLaNhap)criteria).LaNhap);
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(PhieuNhapXuatCCDC.GetPhieuNhapXuatKhongChild(dr));
                    }
                }
                else if (criteria is FilterCriteriaByMaKhoAndMaBoPhan)
                {
                    cm.CommandText = "spd_SelecttblPhieuNhapByMaKhoAndMaBoPhan";
                    cm.Parameters.AddWithValue("@MaKho", ((FilterCriteriaByMaKhoAndMaBoPhan)criteria).MaKho);
                    cm.Parameters.AddWithValue("@MaBoPhan", ((FilterCriteriaByMaKhoAndMaBoPhan)criteria).MaBoPhan);
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(PhieuNhapXuatCCDC.GetPhieuNhapXuat(dr));
                    }
                }
                else if (criteria is FilterCriteriaByMaKhoAndMaBoPhanAndPhuongPhapNX)
                {
                    cm.CommandText = "spd_SelecttblPhieuNhapByMaKhoAndMaBoPhanAndPhuongPhapNX";
                    cm.Parameters.AddWithValue("@MaKho", ((FilterCriteriaByMaKhoAndMaBoPhanAndPhuongPhapNX)criteria).MaKho);
                    cm.Parameters.AddWithValue("@MaBoPhan", ((FilterCriteriaByMaKhoAndMaBoPhanAndPhuongPhapNX)criteria).MaBoPhan);
                    cm.Parameters.AddWithValue("@PhuongPhapNX", ((FilterCriteriaByMaKhoAndMaBoPhanAndPhuongPhapNX)criteria).PhuongPhapNX);
                    cm.Parameters.AddWithValue("@NgayNX", ((FilterCriteriaByMaKhoAndMaBoPhanAndPhuongPhapNX)criteria).NgayNX);
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(PhieuNhapXuatCCDC.GetPhieuNhapXuat(dr));
                    }
                }

                else if (criteria is FilterCriteriaByXacNhanTimTheoNgay)
                {
                    cm.CommandText = "spd_SelecttblPhieuNhapXuatsXacNhanTimTheoNgay";
                    cm.Parameters.AddWithValue("@MaKho", ((FilterCriteriaByXacNhanTimTheoNgay)criteria).MaKho);
                    cm.Parameters.AddWithValue("@LaNhap", ((FilterCriteriaByXacNhanTimTheoNgay)criteria).LaNhap);
                    cm.Parameters.AddWithValue("@MaNguoiNhapXuat", ((FilterCriteriaByXacNhanTimTheoNgay)criteria).MaNguoiNhapXuat);
                    cm.Parameters.AddWithValue("@MaPhongBan", ((FilterCriteriaByXacNhanTimTheoNgay)criteria).MaPhongBan);
                    cm.Parameters.AddWithValue("@PhuongPhapNX", ((FilterCriteriaByXacNhanTimTheoNgay)criteria).PhuongPhapNX);
                    cm.Parameters.AddWithValue("@TuNgay", ((FilterCriteriaByXacNhanTimTheoNgay)criteria).TuNgay);
                    cm.Parameters.AddWithValue("@DenNgay", ((FilterCriteriaByXacNhanTimTheoNgay)criteria).DenNgay);
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(PhieuNhapXuatCCDC.GetPhieuNhapXuat(dr));
                    }

                }
                else if (criteria is FilterCriteriaByXacNhanAll)
                {
                    cm.CommandText = "spd_SelecttblPhieuNhapXuatsXacNhanAll";
                    cm.Parameters.AddWithValue("@MaKho", ((FilterCriteriaByXacNhanAll)criteria).MaKho);
                    cm.Parameters.AddWithValue("@LaNhap", ((FilterCriteriaByXacNhanAll)criteria).LaNhap);
                    cm.Parameters.AddWithValue("@MaNguoiNhapXuat", ((FilterCriteriaByXacNhanAll)criteria).MaNguoiNhapXuat);
                    cm.Parameters.AddWithValue("@MaPhongBan", ((FilterCriteriaByXacNhanAll)criteria).MaPhongBan);
                    cm.Parameters.AddWithValue("@PhuongPhapNX", ((FilterCriteriaByXacNhanAll)criteria).PhuongPhapNX);
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(PhieuNhapXuatCCDC.GetPhieuNhapXuat(dr));
                    }

                }
                //END M

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
                    foreach (PhieuNhapXuatCCDC deletedChild in DeletedList)
                        deletedChild.DeleteSelf(tr);
                    DeletedList.Clear();

                    // loop through each non-deleted child object
                    foreach (PhieuNhapXuatCCDC child in this)
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
