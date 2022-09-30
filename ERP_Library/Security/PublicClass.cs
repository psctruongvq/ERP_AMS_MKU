using Csla.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace ERP_Library
{
    #region Other type

    public class LoaiHoaDonClass
    {
        public int Ma { get; set; }
        public string TenLoaiHoaDon { get; set; }
        public LoaiHoaDonClass(byte ma, string tenloai)
        {
            Ma = ma;
            TenLoaiHoaDon = tenloai;
        }
        public static List<LoaiHoaDonClass> CreateListLoaiHoaDon()
        {
            List<LoaiHoaDonClass> listRS = new List<LoaiHoaDonClass>();
            listRS.Add(new LoaiHoaDonClass(4, "Hóa Đơn Mua Hàng Dịch Vụ"));
            listRS.Add(new LoaiHoaDonClass(26, "Hóa đơn chi tiền hoa hồng"));
            return listRS;
        }

    }
    public enum LoaiHoaDonEnum
    {
        HoaDonMuaHangDichVu = 4
        ,
        HoaDonBanHangDichVu = 5
    }
    //==================================

    public class LoaiKetChuyenXacDinhKetQuaHoatDongKinhDoanh
    {
        public byte Ma { get; set; }
        public string Ten { get; set; }
        public LoaiKetChuyenXacDinhKetQuaHoatDongKinhDoanh(byte ma, string ten)
        {
            Ma = ma;
            Ten = ten;
        }

        public static List<LoaiKetChuyenXacDinhKetQuaHoatDongKinhDoanh> CreateListLoaiKetChuyenXacDinhKetQuaHoatDongKinhDoanh()
        {
            List<LoaiKetChuyenXacDinhKetQuaHoatDongKinhDoanh> listRS = new List<LoaiKetChuyenXacDinhKetQuaHoatDongKinhDoanh>();
            listRS.Add(new LoaiKetChuyenXacDinhKetQuaHoatDongKinhDoanh(1, "Kết chuyển Nợ"));
            listRS.Add(new LoaiKetChuyenXacDinhKetQuaHoatDongKinhDoanh(2, "Kết chuyển Có"));
            listRS.Add(new LoaiKetChuyenXacDinhKetQuaHoatDongKinhDoanh(3, "Kết chuyển theo số dư"));
            return listRS;
        }
    }

    public class MaLoaiKetChuyenXacDinhKetQuaHoatDongKinhDoanh
    {
        //MaLoaiKetChuyen,TenLoaiKetChuyen
        public int MaLoaiKetChuyen { get; set; }
        public string TenLoaiKetChuyen { get; set; }

        public static List<MaLoaiKetChuyenXacDinhKetQuaHoatDongKinhDoanh> CreateListMaLoaiKetChuyenXacDinhKetQuaHoatDongKinhDoanh()
        {
            List<MaLoaiKetChuyenXacDinhKetQuaHoatDongKinhDoanh> listRS = new List<MaLoaiKetChuyenXacDinhKetQuaHoatDongKinhDoanh>();
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_SelecttblLoaiKetChuyensAll";
                    cm.CommandTimeout = 900;
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                        {
                            MaLoaiKetChuyenXacDinhKetQuaHoatDongKinhDoanh mlkc = new MaLoaiKetChuyenXacDinhKetQuaHoatDongKinhDoanh();
                            mlkc.MaLoaiKetChuyen = dr.GetInt32("MaLoaiKetChuyen");
                            mlkc.TenLoaiKetChuyen = dr.GetString("TenLoaiKetChuyen");
                            listRS.Add(mlkc);
                        }
                    }
                }
            }
            return listRS;
        }

    }

    public class LoaiNghiepVu
    {
        public byte Ma { get; set; }
        public string Ten { get; set; }
        public LoaiNghiepVu(byte ma, string ten)
        {
            Ma = ma;
            Ten = ten;
        }

        public static List<LoaiNghiepVu> CreateListLoaiNghiepVu()
        {
            List<LoaiNghiepVu> listRS = new List<LoaiNghiepVu>();
            listRS.Add(new LoaiNghiepVu(0, "<<None>>"));
            listRS.Add(new LoaiNghiepVu(1, "Tạm ứng đã cấp dự toán"));
            listRS.Add(new LoaiNghiepVu(2, "Tạm ứng chưa cấp dự toán"));
            listRS.Add(new LoaiNghiepVu(3, "Thực chi"));

            listRS.Add(new LoaiNghiepVu(4, "Ghi thu - Ghi chi"));
            listRS.Add(new LoaiNghiepVu(5, "Giảm chi - Thực chi"));
            listRS.Add(new LoaiNghiepVu(6, "Giảm chi - Tạm ứng"));
            listRS.Add(new LoaiNghiepVu(7, "Nộp trả - Thực chi"));
            listRS.Add(new LoaiNghiepVu(8, "Nộp trả - Tạm ứng"));
            listRS.Add(new LoaiNghiepVu(9, "Bổ sung"));
            listRS.Add(new LoaiNghiepVu(10, "Khôi phục - Thực chi"));
            listRS.Add(new LoaiNghiepVu(11, "Khôi phục - Tạm ứng"));
            listRS.Add(new LoaiNghiepVu(12, "Xuất toán"));
            listRS.Add(new LoaiNghiepVu(13, "Giảm thu"));
            listRS.Add(new LoaiNghiepVu(14, "Điều chỉnh tăng thuế GTGT"));
            listRS.Add(new LoaiNghiepVu(15, "Điều chỉnh giảm thuế GTGT"));
            listRS.Add(new LoaiNghiepVu(16, "Hủy dự toán"));
            listRS.Add(new LoaiNghiepVu(17, "Điều chỉnh"));
            return listRS;
        }

    }

    public class BoSungHeThongTaiKhoan
    {
        public int MaTaiKhoan { get; set; }
        public string SoHieuTK { get; set; }
        public string TenTK { get; set; }
        public int LoaiSoDu { get; set; }
        public bool Nguon { get; set; }
        public bool LoaiKhoan { get; set; }
        public bool Muc { get; set; }
        public bool TieuMuc { get; set; }
        public bool TKNH_KB { get; set; }
        public bool LoaiQuy { get; set; }
        public bool DuAn { get; set; }
        public bool HoatDong { get; set; }
        public bool HTCP { get; set; }
        public bool Chuong { get; set; }
        public bool VTHH { get; set; }
        public bool CTMT_DA { get; set; }
        public bool CoDoiTuongTheoDoiC { get; set; }

        public static BoSungHeThongTaiKhoan GetBoSungHeThongTaiKhoan(int mataikhoan)
        {
            BoSungHeThongTaiKhoan tk = new BoSungHeThongTaiKhoan();
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_GetBoSungHeThongTaiKhoanByMaTaiKhoan";
                    cm.CommandTimeout = 900;
                    cm.Parameters.AddWithValue("@MaTaiKhoan", mataikhoan);
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                        {
                            tk.MaTaiKhoan = dr.GetInt32("MaTaiKhoan");
                            tk.SoHieuTK = dr.GetString("SoHieuTK");
                            tk.TenTK = dr.GetString("TenTK");
                            tk.LoaiSoDu = dr.GetInt32("LoaiSoDu");
                            tk.Nguon = dr.GetBoolean("Nguon");
                            tk.LoaiKhoan = dr.GetBoolean("LoaiKhoan");
                            tk.Muc = dr.GetBoolean("Muc");
                            tk.TieuMuc = dr.GetBoolean("TieuMuc");
                            tk.TKNH_KB = dr.GetBoolean("TKNH_KB");
                            tk.LoaiQuy = dr.GetBoolean("LoaiQuy");
                            tk.DuAn = dr.GetBoolean("DuAn");
                            tk.HoatDong = dr.GetBoolean("HoatDong");
                            tk.HTCP = dr.GetBoolean("HTCP");
                            tk.Chuong = dr.GetBoolean("Chuong");
                            tk.VTHH = dr.GetBoolean("VTHH");
                            tk.CTMT_DA = dr.GetBoolean("CTMT_DA");
                            tk.CoDoiTuongTheoDoiC = dr.GetBoolean("CoDoiTuongTheoDoiC");
                        }
                    }
                }
            }
            return tk;
        }
    }

    public class DoiTuongGiaoDich
    {
        public long MaDoiTuong { get; set; }
        public string MaQLDoiTuong { get; set; }
        public string TenDoiTuong { get; set; }
        public string MaSoThue { get; set; }
        public string DiaChi { get; set; }
        public List<TaiKhoanNganHangTheoDoiTac> TaiKhoanNganHangList { get; set; }
        public static DoiTuongGiaoDich GetDoiTuongGiaoDichByMaDoiTuong(long maDoiTuong)
        {
            DoiTuongGiaoDich dtrs = new DoiTuongGiaoDich();
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandTimeout = 1800;
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_SelectALLDoiTuong";
                    cm.Parameters.AddWithValue("@MaDoiTuong", maDoiTuong);
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                        {
                            //Fetch DoiTuong

                            dtrs.MaDoiTuong = dr.GetInt64("MaDoiTuong");
                            dtrs.MaQLDoiTuong = dr.GetString("MaQLDoiTuong");
                            dtrs.TenDoiTuong = dr.GetString("TenDoiTuong");
                            dtrs.MaSoThue = dr.GetString("MaSoThue");
                            dtrs.DiaChi = dr.GetString("DiaChi");

                            //Fetch Children TaiKhoanNganHangList
                            dtrs.TaiKhoanNganHangList = TaiKhoanNganHangTheoDoiTac.GetTaiKhoanNganHangListTheoDoiTac(maDoiTuong);
                        }
                    }
                }
            }//us
            return dtrs;
        }
    }

    public class TaiKhoanNganHangTheoDoiTac
    {
        public int MaTKNganHang { get; set; }
        public string SoTK { get; set; }
        public int MaNganHang { get; set; }
        public long MaDoiTac { get; set; }
        public string TenDoiTac { get; set; }
        public string TenNganHang { get; set; }

        public static TaiKhoanNganHangTheoDoiTac GetTaiKhoanNganHangByMaTKNganHang(int maTKNganHang)
        {
            TaiKhoanNganHangTheoDoiTac tkrs = new TaiKhoanNganHangTheoDoiTac();
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandTimeout = 1800;
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_GetTaiKhoanNganHangByMaTKNganHang";
                    cm.Parameters.AddWithValue("@MaTKNganHang", maTKNganHang);
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                        {
                            tkrs.MaTKNganHang = dr.GetInt32("MaTKNganHang");
                            tkrs.SoTK = dr.GetString("SoTK");
                            tkrs.MaNganHang = dr.GetInt32("MaNganHang");
                            tkrs.MaDoiTac = dr.GetInt64("MaDoiTac");
                            tkrs.TenDoiTac = dr.GetString("TenDoiTac");
                            tkrs.TenNganHang = dr.GetString("TenNganHang");
                        }
                    }
                }
            }//us
            return tkrs;
        }

        public static TaiKhoanNganHangTheoDoiTac GetTaiKhoanNganHangCuaDoiTacByMaTKNganHang(long maDoiTuong, int maTKNganHang)
        {
            TaiKhoanNganHangTheoDoiTac tkrs = new TaiKhoanNganHangTheoDoiTac();
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandTimeout = 1800;
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_GetTaiKhoanNganHangCuaDoiTacByMaTKNganHang";
                    cm.Parameters.AddWithValue("@MaDoiTac", maDoiTuong);
                    cm.Parameters.AddWithValue("@MaTKNganHang", maTKNganHang);
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                        {
                            tkrs.MaTKNganHang = dr.GetInt32("MaTKNganHang");
                            tkrs.SoTK = dr.GetString("SoTK");
                            tkrs.MaNganHang = dr.GetInt32("MaNganHang");
                            tkrs.MaDoiTac = dr.GetInt64("MaDoiTac");
                            tkrs.TenDoiTac = dr.GetString("TenDoiTac");
                            tkrs.TenNganHang = dr.GetString("TenNganHang");
                        }
                    }
                }
            }//us
            return tkrs;
        }

        public static List<TaiKhoanNganHangTheoDoiTac> GetTaiKhoanNganHangListTheoDoiTac(long madoitac)
        {
            List<TaiKhoanNganHangTheoDoiTac> listRS = new List<TaiKhoanNganHangTheoDoiTac>();

            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandTimeout = 900;
                    cm.CommandText = "spd_GetTaiKhoanNganHangListByMaDoiTac";
                    cm.Parameters.AddWithValue("@MaDoiTac", madoitac);
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                        {
                            TaiKhoanNganHangTheoDoiTac tk = new TaiKhoanNganHangTheoDoiTac();
                            tk.MaTKNganHang = dr.GetInt32("MaTKNganHang");
                            tk.SoTK = dr.GetString("SoTK");
                            tk.MaNganHang = dr.GetInt32("MaNganHang");
                            tk.MaDoiTac = dr.GetInt64("MaDoiTac");
                            tk.TenDoiTac = dr.GetString("TenDoiTac");
                            tk.TenNganHang = dr.GetString("TenNganHang");
                            listRS.Add(tk);
                        }
                    }
                }
            }
            return listRS;
        }
    }

    public class KyBaoCaoKeToan
    {
        public string Ma { get; set; }
        public string MoTa { get; set; }
        public DateTime TuNgay { get; set; }
        public DateTime DenNgay { get; set; }
        public KyBaoCaoKeToan()
        {
        }
        public KyBaoCaoKeToan(string ma, string mota, DateTime tuNgay, DateTime denNgay)
        {
            Ma = ma;
            MoTa = mota;
            TuNgay = tuNgay;
            DenNgay = denNgay;
        }
        public static KyBaoCaoKeToan GetKyBaoCaoKeToanByMa(string ma)
        {
            DateTime currentDate = DateTime.Now.Date;
            KyBaoCaoKeToan rs = new KyBaoCaoKeToan();
            if (ma == "HomNay")
            {
                rs = new KyBaoCaoKeToan("HomNay", "Hôm nay", currentDate, currentDate);
            }
            else if (ma == "TuanNay")
            {
                rs = new KyBaoCaoKeToan("TuanNay", "Tuần này", PublicClass.StartOfWeek(currentDate, DayOfWeek.Monday), PublicClass.LastOfWeek(currentDate, DayOfWeek.Monday));
            }
            else if (ma == "DauTuanNayDenHienTai")
            {
                rs = new KyBaoCaoKeToan("DauTuanNayDenHienTai", "Đầu tuần này đến hiện tại", PublicClass.StartOfWeek(currentDate, DayOfWeek.Monday), currentDate);
            }
            else if (ma == "ThangNay")
            {
                rs = new KyBaoCaoKeToan("ThangNay", "Tháng này", PublicClass.GetFirstDayInMonth(currentDate.Year, currentDate.Month), PublicClass.GetLastDayInMonth(currentDate.Year, currentDate.Month));
            }
            else if (ma == "DauThangNayDenHienTai")
            {
                rs = new KyBaoCaoKeToan("DauThangNayDenHienTai", "Đầu tháng này đến hiện tại", PublicClass.GetFirstDayInMonth(currentDate.Year, currentDate.Month), currentDate);
            }
            else if (ma == "QuyNay")
            {
                rs = new KyBaoCaoKeToan("QuyNay", "Quý này", PublicClass.GetFirstDayInQuarterOfYear(currentDate.Year, currentDate.Month), PublicClass.GetLastDayInQuarterOfYear(currentDate.Year, currentDate.Month));
            }
            else if (ma == "DauQuyNayDenHienTai")
            {
                rs = new KyBaoCaoKeToan("DauQuyNayDenHienTai", "Đầu quý này đến hiện tại", PublicClass.GetFirstDayInQuarterOfYear(currentDate.Year, currentDate.Month), currentDate);
            }
            else if (ma == "NamNay")
            {
                //rs = new KyBaoCaoKeToan("NamNay", "Năm nay", new DateTime(currentDate.Year, 1, 1), new DateTime(currentDate.Year, 12, 31));                
                if (currentDate.Month > 7)
                {
                    rs = new KyBaoCaoKeToan("NamNay", "Năm nay", new DateTime(currentDate.Year, 7, 1), new DateTime(currentDate.Year + 1, 6, 30));
                }
                else
                {
                    rs = new KyBaoCaoKeToan("NamNay", "Năm nay", new DateTime(currentDate.Year - 1, 7, 1), new DateTime(currentDate.Year, 6, 30));
                }
            }
            else if (ma == "Thang1")
            {
                rs = new KyBaoCaoKeToan("Thang1", "Tháng 1", PublicClass.GetFirstDayInMonth(currentDate.Year, 1), PublicClass.GetLastDayInMonth(currentDate.Year, 1));
            }
            else if (ma == "Thang2")
            {
                rs = new KyBaoCaoKeToan("Thang2", "Tháng 2", PublicClass.GetFirstDayInMonth(currentDate.Year, 2), PublicClass.GetLastDayInMonth(currentDate.Year, 2));
            }
            else if (ma == "Thang3")
            {
                rs = new KyBaoCaoKeToan("Thang3", "Tháng 3", PublicClass.GetFirstDayInMonth(currentDate.Year, 3), PublicClass.GetLastDayInMonth(currentDate.Year, 3));
            }
            else if (ma == "Thang4")
            {
                rs = new KyBaoCaoKeToan("Thang4", "Tháng 4", PublicClass.GetFirstDayInMonth(currentDate.Year, 4), PublicClass.GetLastDayInMonth(currentDate.Year, 4));
            }
            else if (ma == "Thang5")
            {
                rs = new KyBaoCaoKeToan("Thang5", "Tháng 5", PublicClass.GetFirstDayInMonth(currentDate.Year, 5), PublicClass.GetLastDayInMonth(currentDate.Year, 5));
            }
            else if (ma == "Thang6")
            {
                rs = new KyBaoCaoKeToan("Thang6", "Tháng 6", PublicClass.GetFirstDayInMonth(currentDate.Year, 6), PublicClass.GetLastDayInMonth(currentDate.Year, 6));
            }
            else if (ma == "Thang7")
            {
                rs = new KyBaoCaoKeToan("Thang7", "Tháng 7", PublicClass.GetFirstDayInMonth(currentDate.Year, 7), PublicClass.GetLastDayInMonth(currentDate.Year, 7));
            }
            else if (ma == "Thang8")
            {
                rs = new KyBaoCaoKeToan("Thang8", "Tháng 8", PublicClass.GetFirstDayInMonth(currentDate.Year, 8), PublicClass.GetLastDayInMonth(currentDate.Year, 8));
            }
            else if (ma == "Thang9")
            {
                rs = new KyBaoCaoKeToan("Thang9", "Tháng 9", PublicClass.GetFirstDayInMonth(currentDate.Year, 9), PublicClass.GetLastDayInMonth(currentDate.Year, 9));
            }
            else if (ma == "Thang10")
            {
                rs = new KyBaoCaoKeToan("Thang10", "Tháng 10", PublicClass.GetFirstDayInMonth(currentDate.Year, 10), PublicClass.GetLastDayInMonth(currentDate.Year, 10));
            }
            else if (ma == "Thang11")
            {
                rs = new KyBaoCaoKeToan("Thang11", "Tháng 11", PublicClass.GetFirstDayInMonth(currentDate.Year, 11), PublicClass.GetLastDayInMonth(currentDate.Year, 11));
            }
            else if (ma == "Thang12")
            {
                rs = new KyBaoCaoKeToan("Thang12", "Tháng 12", PublicClass.GetFirstDayInMonth(currentDate.Year, 12), PublicClass.GetLastDayInMonth(currentDate.Year, 12));
            }
            else if (ma == "Quy1")
            {
                rs = new KyBaoCaoKeToan("Quy1", "Quý I", PublicClass.GetFirstDayInMonth(currentDate.Year, 1), PublicClass.GetLastDayInMonth(currentDate.Year, 3));
            }
            else if (ma == "Quy2")
            {
                rs = new KyBaoCaoKeToan("Quy2", "Quý II", PublicClass.GetFirstDayInMonth(currentDate.Year, 4), PublicClass.GetLastDayInMonth(currentDate.Year, 6));
            }
            else if (ma == "Quy3")
            {
                rs = new KyBaoCaoKeToan("Quy3", "Quý III", PublicClass.GetFirstDayInMonth(currentDate.Year, 7), PublicClass.GetLastDayInMonth(currentDate.Year, 9));
            }
            else if (ma == "Quy4")
            {
                rs = new KyBaoCaoKeToan("Quy4", "Quý IV", PublicClass.GetFirstDayInMonth(currentDate.Year, 10), PublicClass.GetLastDayInMonth(currentDate.Year, 12));
            }
            else if (ma == "ThangTruoc")
            {
                rs = new KyBaoCaoKeToan("ThangTruoc", "Tháng trước", PublicClass.GetFirstDayInLastMonth(currentDate.Year, currentDate.Month), PublicClass.GetLastDayInLastMonth(currentDate.Year, currentDate.Month));
            }
            else if (ma == "QuyTruoc")
            {
                rs = new KyBaoCaoKeToan("QuyTruoc", "Quý trước", PublicClass.GetFirstDayInLastQuarterOfYear(currentDate.Year, currentDate.Month), PublicClass.GetLastDayInLastQuarterOfYear(currentDate.Year, currentDate.Month));
            }
            else if (ma == "NamTruoc")
            {
                //rs = new KyBaoCaoKeToan("NamTruoc", "Năm trước", new DateTime(currentDate.Year - 1, 1, 1), new DateTime(currentDate.Year - 1, 12, 31));
                rs = new KyBaoCaoKeToan("NamTruoc", "Năm trước", new DateTime(currentDate.Year - 1, 7, 1), new DateTime(currentDate.Year, 6, 30));
            }
            else if (ma == "TuyChon")
            {
                rs = new KyBaoCaoKeToan("TuyChon", "Tùy chọn", currentDate, currentDate);
            }

            return rs;
        }
        //        Hôm nay,Tuần Này,Đầu tuần này đến hiện tại,Tháng này,Đầu tháng này đến hiện tại
        //Quý này,Đầu quý này đến hiện tại,Tháng 1,Tháng 2,Tháng 3,Tháng 4,Tháng 5,Tháng 6,Tháng 7,Tháng 8,Tháng 9,Tháng 10
        //Tháng 11,Tháng12,Quý I,Quý II,Quý III,Quý IV,Tuần trước,Tháng trước,Quý trước,Năm trước
        //Tuần sau,Bốn tuần sau,Tháng sau,Quý sau,Năm Sau,Tự chọn
        public static List<KyBaoCaoKeToan> CreateListKyBaoCaoKeToan()
        {
            DateTime currentDate = DateTime.Now.Date;
            List<KyBaoCaoKeToan> listRS = new List<KyBaoCaoKeToan>();
            listRS.Add(new KyBaoCaoKeToan("HomNay", "Hôm nay", currentDate, currentDate));
            listRS.Add(new KyBaoCaoKeToan("TuanNay", "Tuần này", currentDate, currentDate));
            listRS.Add(new KyBaoCaoKeToan("DauTuanNayDenHienTai", "Đầu tuần này đến hiện tại", currentDate, currentDate));
            listRS.Add(new KyBaoCaoKeToan("ThangNay", "Tháng này", currentDate, currentDate));
            listRS.Add(new KyBaoCaoKeToan("DauThangNayDenHienTai", "Đầu tháng này đến hiện tại", currentDate, currentDate));
            listRS.Add(new KyBaoCaoKeToan("QuyNay", "Quý này", currentDate, currentDate));
            listRS.Add(new KyBaoCaoKeToan("DauQuyNayDenHienTai", "Đầu quý này đến hiện tại", currentDate, currentDate));
            listRS.Add(new KyBaoCaoKeToan("NamNay", "Năm nay", currentDate, currentDate));
            listRS.Add(new KyBaoCaoKeToan("Thang1", "Tháng 1", currentDate, currentDate));
            listRS.Add(new KyBaoCaoKeToan("Thang2", "Tháng 2", currentDate, currentDate));
            listRS.Add(new KyBaoCaoKeToan("Thang3", "Tháng 3", currentDate, currentDate));
            listRS.Add(new KyBaoCaoKeToan("Thang4", "Tháng 4", currentDate, currentDate));
            listRS.Add(new KyBaoCaoKeToan("Thang5", "Tháng 5", currentDate, currentDate));
            listRS.Add(new KyBaoCaoKeToan("Thang6", "Tháng 6", currentDate, currentDate));
            listRS.Add(new KyBaoCaoKeToan("Thang7", "Tháng 7", currentDate, currentDate));
            listRS.Add(new KyBaoCaoKeToan("Thang8", "Tháng 8", currentDate, currentDate));
            listRS.Add(new KyBaoCaoKeToan("Thang9", "Tháng 9", currentDate, currentDate));
            listRS.Add(new KyBaoCaoKeToan("Thang10", "Tháng 10", currentDate, currentDate));
            listRS.Add(new KyBaoCaoKeToan("Thang11", "Tháng 11", currentDate, currentDate));
            listRS.Add(new KyBaoCaoKeToan("Thang12", "Tháng 12", currentDate, currentDate));
            listRS.Add(new KyBaoCaoKeToan("Quy1", "Quý I", currentDate, currentDate));
            listRS.Add(new KyBaoCaoKeToan("Quy2", "Quý II", currentDate, currentDate));
            listRS.Add(new KyBaoCaoKeToan("Quy3", "Quý III", currentDate, currentDate));
            listRS.Add(new KyBaoCaoKeToan("Quy4", "Quý IV", currentDate, currentDate));
            listRS.Add(new KyBaoCaoKeToan("ThangTruoc", "Tháng trước", currentDate, currentDate));
            listRS.Add(new KyBaoCaoKeToan("QuyTruoc", "Quý trước", currentDate, currentDate));
            listRS.Add(new KyBaoCaoKeToan("NamTruoc", "Năm trước", currentDate, currentDate));
            listRS.Add(new KyBaoCaoKeToan("TuyChon", "Tùy chọn", currentDate, currentDate));

            return listRS;
        }

    }

    public class LoaiNganHangKhoBac
    {
        public int ID { get; set; }
        public string MaQL { get; set; }
        public string TenLoaiNganHang { get; set; }

        public static LoaiNganHangKhoBac GetLoaiNganHangByMaLoai(int ID)
        {
            LoaiNganHangKhoBac loaiNHKB = new LoaiNganHangKhoBac();
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_GetLoaiNganHangByMaLoaiNganHang";
                    cm.Parameters.AddWithValue("@ID", ID);
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                        {
                            loaiNHKB.ID = dr.GetInt32("ID");
                            loaiNHKB.MaQL = dr.GetString("MaQL");
                            loaiNHKB.TenLoaiNganHang = dr.GetString("TenLoaiNganHang");
                        }
                    }
                }
            }
            return loaiNHKB;
        }

        public static LoaiNganHangKhoBac GetLoaiNganHangByMaQuanLy(string maql)
        {
            LoaiNganHangKhoBac loaiNHKB = new LoaiNganHangKhoBac();
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_GetLoaiNganHangByMaQL";
                    cm.CommandTimeout = 900;
                    cm.Parameters.AddWithValue("@MaQL", maql);
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                        {
                            loaiNHKB.ID = dr.GetInt32("ID");
                            loaiNHKB.MaQL = dr.GetString("MaQL");
                            loaiNHKB.TenLoaiNganHang = dr.GetString("TenLoaiNganHang");
                        }
                    }
                }
            }
            return loaiNHKB;
        }

        public static List<LoaiNganHangKhoBac> CreateListLoaiNganHangKhoBac()
        {
            List<LoaiNganHangKhoBac> listRS = new List<LoaiNganHangKhoBac>();
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_GetLoaiNganHangList";
                    cm.CommandTimeout = 900;
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                        {
                            LoaiNganHangKhoBac lnh = new LoaiNganHangKhoBac();
                            lnh.ID = dr.GetInt32("ID");
                            lnh.MaQL = dr.GetString("MaQL");
                            lnh.TenLoaiNganHang = dr.GetString("TenLoaiNganHang");
                            listRS.Add(lnh);
                        }
                    }
                }
            }
            return listRS;
        }

    }

    public class NamKeToan
    {
        public int Nam { get; set; }
        public string MoTa { get; set; }

        public NamKeToan(int nam, string mota)
        {
            Nam = nam;
            MoTa = mota;
        }

        public static List<NamKeToan> CreateListNamKeToan()
        {
            List<NamKeToan> listRS = new List<NamKeToan>();
            for (int i = 2017; i <= 2050; i++)
            {
                listRS.Add(new NamKeToan(i, string.Format("Năm {0}", i)));
            }
            return listRS;
        }

    }

    public class ChungTuChiThuNhapNhanVienTienMat
    {
        //MaChungTu,SoTien, SoChungTu,NgayLap,NguoiLap,  MaLoaiKinhPhi
        public long MaChungTu { get; set; }
        public string SoChungTu { get; set; }
        public DateTime NgayLapCT { get; set; }
        public decimal SoTien { get; set; }
        public int NguoiLap { get; set; }
        public int MaLoaiChi { get; set; }
        public int MaButToan { get; set; }
        public string DienGiai { get; set; }

        public ChungTuChiThuNhapNhanVienTienMat()
        {
        }

        public ChungTuChiThuNhapNhanVienTienMat(string sochungtu)
        {
            SoChungTu = sochungtu;
        }

        public static decimal SoTienConLaiPhieuChi(int mabuttoan)
        {
            decimal soTienConLai = 0;
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                try
                {
                    cn.Open();
                    SqlCommand cm = cn.CreateCommand();
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandTimeout = 900;
                    cm.CommandText = "spd_SoTienConLaiPhieuChiForChiThuNhapNhanVien";
                    cm.Parameters.AddWithValue("@MaButToan", mabuttoan);
                    cm.Parameters.AddWithValue("@SoTienConLai", soTienConLai);
                    cm.Parameters["@SoTienConLai"].Direction = ParameterDirection.Output;
                    cm.ExecuteNonQuery();
                    soTienConLai = (decimal)cm.Parameters["@SoTienConLai"].Value;
                }
                catch (Exception ex)
                {
                    soTienConLai = 0;
                }

            }
            return soTienConLai;
        }

        public static List<ChungTuChiThuNhapNhanVienTienMat> CreateListChungTuChiThuNhapNhanVienTienMat(int userid, int mabuttoan, int maloaichi)
        {
            List<ChungTuChiThuNhapNhanVienTienMat> listRS = new List<ChungTuChiThuNhapNhanVienTienMat>();
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandTimeout = 900;
                    cm.CommandText = "spd_SelectChungTuChiThuNhapNhanVienTienMatList";
                    cm.Parameters.AddWithValue("@UserID", userid);
                    cm.Parameters.AddWithValue("@MaButToan", mabuttoan);
                    cm.Parameters.AddWithValue("@MaLoaiChi", maloaichi);
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                        {
                            ChungTuChiThuNhapNhanVienTienMat ct = new ChungTuChiThuNhapNhanVienTienMat();
                            ct.MaChungTu = dr.GetInt64("MaChungTu");
                            ct.SoChungTu = dr.GetString("SoChungTu");
                            ct.NgayLapCT = dr.GetDateTime("NgayLapCT");
                            ct.SoTien = dr.GetDecimal("SoTien");
                            ct.NguoiLap = dr.GetInt32("NguoiLap");
                            ct.MaLoaiChi = dr.GetInt32("MaLoaiChi");
                            ct.MaButToan = dr.GetInt32("MaButToan");
                            ct.DienGiai = dr.GetString("DienGiai");
                            listRS.Add(ct);
                        }
                    }
                }
            }
            return listRS;
        }
    }

    public class TaiKhoanThue
    {
        public string SoHieuTKThueKhauTru;
        public string SoHieuTKThuePhaiNop;
        public string SoHieuTKTamUng;
        public string MauHoaDon;
        public string KyHieuHoaDon;
        public static List<TaiKhoanThue> TaiKhoanThueList;
        public static void LoadTaiKhoanThueList(int maCongTy)
        {
            TaiKhoanThueList = new List<TaiKhoanThue>();
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_LoadTaiKhoanThue";
                    cm.CommandTimeout = 900;
                    cm.Parameters.AddWithValue("@MaCongTy", maCongTy);
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                        {
                            TaiKhoanThue tk = new TaiKhoanThue();
                            tk.SoHieuTKThueKhauTru = dr.GetString("SoHieuTKThue");
                            tk.SoHieuTKThuePhaiNop = dr.GetString("SoHieuTKThuePhaiNop");
                            tk.SoHieuTKTamUng = dr.GetString("SoHieuTKTamUng");
                            tk.MauHoaDon = dr.GetString("MauHoaDon");
                            tk.KyHieuHoaDon = dr.GetString("KyHieuHoaDon");
                            TaiKhoanThueList.Add(tk);
                        }

                    }
                }
            }
        }
    }

    #region BienLai
    public class ChiTietBienLaiFromOtherDB
    {
        public bool Check { get; set; }
        public Guid MaChiTiet { get; set; }
        public long MaChiTietInt { get; set; }
        //BS Thong Tin BienLai
        public Guid MaBienLai { get; set; }
        public int MaBienLaiInt { get; set; }
        public string SoBienLai { get; set; }
        public Guid MaDoiTuong { get; set; }
        public long MaDoiTuongInt { get; set; }
        public string MaQLDoiTuong { get; set; }
        public string TenDoiTuong { get; set; }
        public DateTime NgayLap { get; set; }
        //
        public int KieuThuPhi { get; set; }
        public string DienGiai { get; set; }
        public string GhiChu { get; set; }
        public int SoLuong { get; set; }
        public decimal DonGia { get; set; }
        public decimal SoTien { get; set; }
        public decimal TienPos { get; set; }
        public int HinhThucThanhToan { get; set; }
        public string TenHinhThucThanhToan { get; set; }
        public string MaDonViCongTy { get; set; }
        //SoTaiKhoan NVARCHAR(max),TenNganHang NVARCHAR(max)--TenLop, TenKhoi, TenHe, TenTruong
        public string SoTaiKhoan { get; set; }
        public string TenNganHang { get; set; }
        public string TenLop { get; set; }
        public string TenKhoi { get; set; }
        public string TenHe { get; set; }
        public string TenTruong { get; set; }
        public string MaTruongHocSinh { get; set; }
        public byte KieuThuPhiFNC { get; set; }
        //        ,NULL AS PhanTramPhiPOS
        //,NULL AS TienPOSHoaDon
        public decimal PhanTramPhiPOS { get; set; }
        public decimal TienPOSHoaDon { get; set; }
        public string SoSeri { get; set; }
        public string TenGoiPhi { get; set; }
        public string NamHoc { get; set; }
        public string NoiDungThu { get; set; }
        public decimal TongTienNgoaiTe { get; set; }
        public decimal TienNgoaiTe { get; set; }
        public decimal TyGia { get; set; }
        public string MaNgoaiTe { get; set; }
        public static List<ChiTietBienLaiFromOtherDB> LoadChiTietBienLaiFromOtherDBList(string tenDoiTuong, int hinhthucthanhtoan, byte kieulap)//1 LapChungTu, 2 Lập Hóa đơn
        {
            List<ChiTietBienLaiFromOtherDB> ctbienlailist = new List<ChiTietBienLaiFromOtherDB>();
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandTimeout = 3600;
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_LoadChiTietBienLaiFromOtherDBList";
                    cm.Parameters.AddWithValue("@TenDoiTuong", tenDoiTuong);
                    cm.Parameters.AddWithValue("@HinhThucThanhToan", hinhthucthanhtoan);
                    cm.Parameters.AddWithValue("@Kieu", kieulap);
                    cm.Parameters.AddWithValue("@MaCongTy", ERP_Library.Security.CurrentUser.Info.MaCongTy);
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                        {
                            ChiTietBienLaiFromOtherDB ctbl = new ChiTietBienLaiFromOtherDB();
                            ctbl.MaChiTiet = dr.GetGuid("MaChiTiet");
                            ctbl.MaChiTietInt = dr.GetInt64("MaChiTietInt");
                            //BS Thong Tin BienLai
                            ctbl.MaBienLai = dr.GetGuid("MaBienLai");
                            ctbl.MaBienLaiInt = dr.GetInt32("MaBienLaiInt");
                            ctbl.SoBienLai = dr.GetString("SoBienLai");
                            ctbl.MaDoiTuong = dr.GetGuid("MaDoiTuong");
                            ctbl.MaDoiTuongInt = dr.GetInt64("MaDoiTuongInt");
                            ctbl.MaQLDoiTuong = dr.GetString("MaQLDoiTuong");
                            ctbl.TenDoiTuong = dr.GetString("TenDoiTuong");
                            ctbl.NgayLap = dr.GetDateTime("NgayLap");
                            //
                            ctbl.KieuThuPhi = dr.GetInt32("KieuThuPhi");
                            ctbl.DienGiai = dr.GetString("DienGiai");
                            ctbl.GhiChu = dr.GetString("GhiChu");
                            ctbl.SoLuong = dr.GetInt32("SoLuong");
                            ctbl.DonGia = dr.GetDecimal("DonGia");
                            ctbl.SoTien = dr.GetDecimal("SoTien");
                            ctbl.TienPos = dr.GetDecimal("tienpos");
                            ctbl.HinhThucThanhToan = dr.GetInt32("HinhThucThanhToan");
                            ctbl.TenHinhThucThanhToan = dr.GetString("TenHinhThucThanhToan");
                            ctbl.MaDonViCongTy = dr.GetString("MaDonViCongTy");

                            ctbl.SoTaiKhoan = dr.GetString("SoTaiKhoan");
                            ctbl.TenNganHang = dr.GetString("TenNganHang");

                            ctbl.TenLop = dr.GetString("TenLop");
                            ctbl.TenKhoi = dr.GetString("TenKhoi");
                            ctbl.TenHe = dr.GetString("TenHe");
                            ctbl.TenTruong = dr.GetString("TenTruong");
                            ctbl.MaTruongHocSinh = dr.GetString("MaTruongHocSinh");
                            ctbl.KieuThuPhiFNC = dr.GetByte("KieuThuPhiFNC");

                            ctbl.PhanTramPhiPOS = dr.GetDecimal("PhanTramPhiPOS");
                            ctbl.TienPOSHoaDon = dr.GetDecimal("TienPOSHoaDon");
                            ctbl.SoSeri = dr.GetString("SoSeri");
                            ctbl.TenGoiPhi = dr.GetString("TenGoiPhi");
                            ctbl.NamHoc = dr.GetString("NamHoc");
                            ctbl.NoiDungThu = dr.GetString("NoiDungThu");
                            ctbl.TongTienNgoaiTe = dr.GetDecimal("TongTienNgoaiTe");
                            ctbl.TienNgoaiTe = dr.GetDecimal("TienNgoaiTe");
                            ctbl.TyGia = dr.GetDecimal("TyGia");
                            ctbl.MaNgoaiTe = dr.GetString("MaNgoaiTe");
                            ctbienlailist.Add(ctbl);
                        }
                    }
                }
            }
            return ctbienlailist;
        }
    }

    public class BienLaiFromOtherDB
    {
        public bool Check { get; set; }
        public Guid MaBienLai { get; set; }
        public int MaBienLaiInt { get; set; }
        public string SoBienLai { get; set; }
        public Guid MaDoiTuong { get; set; }
        public int MaDoiTuongInt { get; set; }
        public string TenDoiTuong { get; set; }
        public string NoiDungBienLai { get; set; }
        public decimal SoTienThucThu { get; set; }
        public DateTime NgayLap { get; set; }
        public List<ChiTietBienLaiFromOtherDB> ChiTietBienLaiList = new List<ChiTietBienLaiFromOtherDB>();
        public static List<BienLaiFromOtherDB> LoadBienLaiFromOtherDBList()
        {
            List<BienLaiFromOtherDB> bienlailist = new List<BienLaiFromOtherDB>();
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_LoadBienLaiFromOtherDBList";
                    cm.CommandTimeout = 900;
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                        {
                            BienLaiFromOtherDB bl = new BienLaiFromOtherDB();
                            bl.MaBienLai = dr.GetGuid("MaBienLai");
                            bl.MaBienLaiInt = dr.GetInt32("MaBienLaiInt");
                            bl.SoBienLai = dr.GetString("SoBienLai");
                            bl.MaDoiTuong = dr.GetGuid("MaDoiTuong");
                            bl.MaDoiTuongInt = dr.GetInt32("MaDoiTuongInt");
                            bl.TenDoiTuong = dr.GetString("TenDoiTuong");
                            bl.NoiDungBienLai = dr.GetString("NoiDungBienLai");
                            bl.SoTienThucThu = dr.GetDecimal("SoTienThucThu");
                            bl.NgayLap = dr.GetDateTime("NgayLap");
                            bienlailist.Add(bl);
                        }
                    }
                }
            }
            return bienlailist;
        }
    }
    #endregion//BienLai

    #region GoiPhiThamGia
    public class GoiPhiThamGiaHocSinhFromOtherDB
    {
        public bool Check { get; set; }
        public Guid MaDoiTuong { get; set; }
        public long MaDoiTuongInt { get; set; }
        public string MaQLDoiTuong { get; set; }
        public string TenDoiTuong { get; set; }
        public string NamHoc { get; set; }
        public string MaGoiPhi { get; set; }
        public string TenGoiPhi { get; set; }
        public decimal SoTienCuaGoi { get; set; }
        public decimal PhaiThu { get; set; }
        public decimal DaDong { get; set; }
        public decimal SoTienConLai { get; set; }
        public string TenLop { get; set; }
        public string TenKhoi { get; set; }
        public string TenHe { get; set; }
        public string TenTruong { get; set; }

        public int MaTaiKhoan { get; set; }
        public string SoHieuTK { get; set; }
        public string TenTaiKhoan { get; set; }
        public static List<GoiPhiThamGiaHocSinhFromOtherDB> LoadGoiPhiThamGiaHocSinhFromOtherDBList()
        {
            List<GoiPhiThamGiaHocSinhFromOtherDB> goiphithamgialist = new List<GoiPhiThamGiaHocSinhFromOtherDB>();
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandTimeout = 3600;
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_LoadGoiPhiThamGiaHocSinhFromOtherDBList";
                    cm.Parameters.AddWithValue("@MaCongTy", ERP_Library.Security.CurrentUser.Info.MaCongTy);
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                        {

                            GoiPhiThamGiaHocSinhFromOtherDB gptg = new GoiPhiThamGiaHocSinhFromOtherDB();
                            gptg.MaDoiTuong = dr.GetGuid("MaDoiTuong");
                            gptg.MaDoiTuongInt = dr.GetInt64("MaDoiTuongInt");
                            gptg.MaQLDoiTuong = dr.GetString("MaQLDoiTuong");
                            gptg.TenDoiTuong = dr.GetString("TenDoiTuong");
                            //     NULL AS MaDoiTuong,doitacERp.MaDoiTuong AS MaDoiTuongInt
                            //,viewdata.MaHocSinh AS MaQLDoiTuong,viewdata.Ten AS TenDoiTuong
                            //,viewdata.NamHoc,viewdata.MaGoi AS MaGoiPhi,viewdata.TenGoi AS TenGoiPhi
                            //,viewdata.SoTienCuaGoi,viewdata.PhaiThu,viewdata.DaDong
                            //,viewdata.ConNo AS SoTienConLai
                            //,viewdata.TenLop, viewdata.TenKhoi, viewdata.TenHe, viewdata.TenTruong
                            gptg.NamHoc = dr.GetString("NamHoc");
                            gptg.MaGoiPhi = dr.GetString("MaGoiPhi");
                            gptg.TenGoiPhi = dr.GetString("TenGoiPhi");
                            gptg.SoTienCuaGoi = dr.GetDecimal("SoTienCuaGoi");
                            gptg.PhaiThu = dr.GetDecimal("PhaiThu");
                            gptg.DaDong = dr.GetDecimal("DaDong");
                            gptg.SoTienConLai = dr.GetDecimal("SoTienConLai");
                            gptg.TenLop = dr.GetString("TenLop");
                            gptg.TenKhoi = dr.GetString("TenKhoi");
                            gptg.TenHe = dr.GetString("TenHe");
                            gptg.TenTruong = dr.GetString("TenTruong");

                            gptg.MaTaiKhoan = dr.GetInt32("MaTaiKhoan");
                            gptg.SoHieuTK = dr.GetString("SoHieuTK");
                            gptg.TenTaiKhoan = dr.GetString("TenTaiKhoan");
                            goiphithamgialist.Add(gptg);
                        }

                    }
                }
            }
            return goiphithamgialist;
        }

        public static List<GoiPhiThamGiaHocSinhFromOtherDB> LoadGoiPhiThamGiaHocSinhFromOtherDBList_MaKy(int MaKy)
        {
            List<GoiPhiThamGiaHocSinhFromOtherDB> goiphithamgialist = new List<GoiPhiThamGiaHocSinhFromOtherDB>();
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandTimeout = 3600;
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_LoadGoiPhiThamGiaHocSinhFromOtherDBList_MaKy";
                    cm.Parameters.AddWithValue("@MaCongTy", ERP_Library.Security.CurrentUser.Info.MaCongTy);
                    cm.Parameters.AddWithValue("@MaKy", MaKy);
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                        {

                            GoiPhiThamGiaHocSinhFromOtherDB gptg = new GoiPhiThamGiaHocSinhFromOtherDB();
                            gptg.MaDoiTuong = dr.GetGuid("MaDoiTuong");
                            gptg.MaDoiTuongInt = dr.GetInt64("MaDoiTuongInt");
                            gptg.MaQLDoiTuong = dr.GetString("MaQLDoiTuong");
                            gptg.TenDoiTuong = dr.GetString("TenDoiTuong");
                            //     NULL AS MaDoiTuong,doitacERp.MaDoiTuong AS MaDoiTuongInt
                            //,viewdata.MaHocSinh AS MaQLDoiTuong,viewdata.Ten AS TenDoiTuong
                            //,viewdata.NamHoc,viewdata.MaGoi AS MaGoiPhi,viewdata.TenGoi AS TenGoiPhi
                            //,viewdata.SoTienCuaGoi,viewdata.PhaiThu,viewdata.DaDong
                            //,viewdata.ConNo AS SoTienConLai
                            //,viewdata.TenLop, viewdata.TenKhoi, viewdata.TenHe, viewdata.TenTruong
                            gptg.NamHoc = dr.GetString("NamHoc");
                            gptg.MaGoiPhi = dr.GetString("MaGoiPhi");
                            gptg.TenGoiPhi = dr.GetString("TenGoiPhi");
                            gptg.SoTienCuaGoi = dr.GetDecimal("SoTienCuaGoi");
                            gptg.PhaiThu = dr.GetDecimal("PhaiThu");
                            gptg.DaDong = dr.GetDecimal("DaDong");
                            gptg.SoTienConLai = dr.GetDecimal("SoTienConLai");
                            gptg.TenLop = dr.GetString("TenLop");
                            gptg.TenKhoi = dr.GetString("TenKhoi");
                            gptg.TenHe = dr.GetString("TenHe");
                            gptg.TenTruong = dr.GetString("TenTruong");

                            gptg.MaTaiKhoan = dr.GetInt32("MaTaiKhoan");
                            gptg.SoHieuTK = dr.GetString("SoHieuTK");
                            gptg.TenTaiKhoan = dr.GetString("TenTaiKhoan");
                            goiphithamgialist.Add(gptg);
                        }

                    }
                }
            }
            return goiphithamgialist;
        }
    }
    #endregion GoiPhiThamGia


    #region XuatKho
    public class ChiTietXuatKhoFromOtherDB
    {
        //        NULL AS MaChiTiet ,CONVERT(BIGINT, viewdata.RelativeTransactionID) AS MaChiTietInt,NULL AS MaBienLai,viewdata.billId AS MaBienLaiInt
        //, viewdata.BillNumber AS SoBienLai
        //,NULL AS MaDoiTuong,doitacERp.MaDoiTuong AS MaDoiTuongInt
        //,viewdata.StudentId AS MaQLDoiTuong,hs.HoTen AS TenDoiTuong
        //,viewdata.BillDate AS NgayLap
        //,viewdata.FeeDetailTypeID AS KieuThuPhi,viewdata.FeeDetailTypeName AS DienGiai, NULL AS GhiChu
        //,viewdata.DonViTinh,viewdata.SoLuong AS SoLuong,viewdata.DonGia AS DonGia,viewdata.SoTien AS SoTien
        //,viewdata.HinhThucThanhToan, viewdata.TenHinhThucThanhToan AS TenHinhThucThanhToan
        //,viewdata.MaQuanLy AS MaDonViCongTy
        //,viewdata.SoTaiKhoan ,viewdata.TenNganHang
        //,viewdata.TenLop, viewdata.TenKhoi, viewdata.TenHe, viewdata.TenTruong
        //,bp.MaQuanLy AS MaTruongHocSinh
        public bool Check { get; set; }
        public Guid MaChiTiet { get; set; }
        public long MaChiTietInt { get; set; }
        public Guid MaBienLai { get; set; }
        public int MaBienLaiInt { get; set; }
        public string SoBienLai { get; set; }
        public Guid MaDoiTuong { get; set; }
        public long MaDoiTuongInt { get; set; }
        public string MaQLDoiTuong { get; set; }
        public string TenDoiTuong { get; set; }
        public DateTime NgayLap { get; set; }
        public int KieuThuPhi { get; set; }
        public string DienGiai { get; set; }
        public string GhiChu { get; set; }
        public string DonViTinh { get; set; }
        public decimal SoLuong { get; set; }
        public decimal DonGia { get; set; }
        public decimal SoTien { get; set; }
        public int HinhThucThanhToan { get; set; }
        public string TenHinhThucThanhToan { get; set; }
        public string MaDonViCongTy { get; set; }
        public string SoTaiKhoan { get; set; }
        public string TenNganHang { get; set; }
        public string TenLop { get; set; }
        public string TenKhoi { get; set; }
        public string TenHe { get; set; }
        public string TenTruong { get; set; }
        public string MaTruongHocSinh { get; set; }
        public string TenMonHoc { get; set; }
        public string GioiTinh { get; set; }

        public static List<ChiTietXuatKhoFromOtherDB> LoadChiTietXuatKhoFromOtherDBList(string tenDoiTuong)
        {
            List<ChiTietXuatKhoFromOtherDB> ctbienlailist = new List<ChiTietXuatKhoFromOtherDB>();
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandTimeout = 3600;
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_LoadChiTietXuatKhoFromOtherDBList";
                    cm.Parameters.AddWithValue("@TenDoiTuong", tenDoiTuong);
                    cm.Parameters.AddWithValue("@MaCongTy", Security.CurrentUser.Info.MaCongTy);
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                        {
                            ChiTietXuatKhoFromOtherDB ctbl = new ChiTietXuatKhoFromOtherDB();
                            ctbl.MaChiTiet = dr.GetGuid("MaChiTiet");
                            ctbl.MaChiTietInt = dr.GetInt64("MaChiTietInt");
                            ctbl.MaBienLai = dr.GetGuid("MaBienLai");
                            ctbl.MaBienLaiInt = dr.GetInt32("MaBienLaiInt");
                            ctbl.SoBienLai = dr.GetString("SoBienLai");
                            ctbl.MaDoiTuong = dr.GetGuid("MaDoiTuong");
                            ctbl.MaDoiTuongInt = dr.GetInt64("MaDoiTuongInt");
                            ctbl.MaQLDoiTuong = dr.GetString("MaQLDoiTuong");
                            ctbl.TenDoiTuong = dr.GetString("TenDoiTuong");
                            ctbl.NgayLap = dr.GetDateTime("NgayLap");
                            ctbl.KieuThuPhi = dr.GetInt32("KieuThuPhi");
                            ctbl.DienGiai = dr.GetString("DienGiai");
                            ctbl.GhiChu = dr.GetString("GhiChu");
                            ctbl.DonViTinh = dr.GetString("DonViTinh");
                            ctbl.SoLuong = dr.GetDecimal("SoLuong");
                            ctbl.DonGia = dr.GetDecimal("DonGia");
                            ctbl.SoTien = dr.GetDecimal("SoTien");
                            ctbl.HinhThucThanhToan = dr.GetInt32("HinhThucThanhToan");
                            ctbl.TenHinhThucThanhToan = dr.GetString("TenHinhThucThanhToan");
                            ctbl.MaDonViCongTy = dr.GetString("MaDonViCongTy");

                            ctbl.SoTaiKhoan = dr.GetString("SoTaiKhoan");
                            ctbl.TenNganHang = dr.GetString("TenNganHang");

                            ctbl.TenLop = dr.GetString("TenLop");
                            ctbl.TenKhoi = dr.GetString("TenKhoi");
                            ctbl.TenHe = dr.GetString("TenHe");
                            ctbl.TenTruong = dr.GetString("TenTruong");
                            ctbl.MaTruongHocSinh = dr.GetString("MaTruongHocSinh");
                            ctbienlailist.Add(ctbl);
                        }
                    }
                }
            }
            return ctbienlailist;
        }

        public static List<ChiTietXuatKhoFromOtherDB> GetChiTietXuatBanDongPhucFromOtherDBList(int BillId)
        {
            List<ChiTietXuatKhoFromOtherDB> ctbienlailist = new List<ChiTietXuatKhoFromOtherDB>();
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandTimeout = 3600;
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_GetChiTietXuatBanDongPhucFromOtherDBList";
                    cm.Parameters.AddWithValue("@MaCongTy", ERP_Library.Security.CurrentUser.Info.MaCongTy);
                    cm.Parameters.AddWithValue("@BillId", BillId);
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                        {
                            ChiTietXuatKhoFromOtherDB ctbl = new ChiTietXuatKhoFromOtherDB();
                            ctbl.MaChiTiet = dr.GetGuid("MaChiTiet");
                            ctbl.MaChiTietInt = dr.GetInt64("MaChiTietInt");
                            ctbl.MaBienLai = dr.GetGuid("MaBienLai");
                            ctbl.MaBienLaiInt = dr.GetInt32("MaBienLaiInt");
                            ctbl.SoBienLai = dr.GetString("SoBienLai");
                            ctbl.MaDoiTuong = dr.GetGuid("MaDoiTuong");
                            ctbl.MaDoiTuongInt = dr.GetInt64("MaDoiTuongInt");
                            ctbl.MaQLDoiTuong = dr.GetString("MaQLDoiTuong");
                            ctbl.TenDoiTuong = dr.GetString("TenDoiTuong");
                            ctbl.NgayLap = dr.GetDateTime("NgayLap");
                            ctbl.KieuThuPhi = dr.GetInt32("KieuThuPhi");
                            ctbl.DienGiai = dr.GetString("DienGiai");
                            ctbl.GhiChu = dr.GetString("GhiChu");
                            ctbl.DonViTinh = dr.GetString("DonViTinh");
                            ctbl.SoLuong = dr.GetDecimal("SoLuong");
                            ctbl.DonGia = dr.GetDecimal("DonGia");
                            ctbl.SoTien = dr.GetDecimal("SoTien");
                            ctbl.HinhThucThanhToan = dr.GetInt32("HinhThucThanhToan");
                            ctbl.TenHinhThucThanhToan = dr.GetString("TenHinhThucThanhToan");
                            ctbl.MaDonViCongTy = dr.GetString("MaDonViCongTy");

                            ctbl.SoTaiKhoan = dr.GetString("SoTaiKhoan");
                            ctbl.TenNganHang = dr.GetString("TenNganHang");

                            ctbl.TenLop = dr.GetString("TenLop");
                            ctbl.TenKhoi = dr.GetString("TenKhoi");
                            ctbl.TenHe = dr.GetString("TenHe");
                            ctbl.TenTruong = dr.GetString("TenTruong");
                            ctbl.MaTruongHocSinh = dr.GetString("MaTruongHocSinh");
                            ctbienlailist.Add(ctbl);
                        }
                    }
                }
            }
            return ctbienlailist;
        }

        public static List<ChiTietXuatKhoFromOtherDB> GetChiTietXuatCapPhatDongPhucFromOtherDBList(string MaQLHocSinh,string Truong)
        {
            List<ChiTietXuatKhoFromOtherDB> ctbienlailist = new List<ChiTietXuatKhoFromOtherDB>();
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandTimeout = 3600;
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "AccountsFee.dbo.sp_psc_vw_tbl_StudentTatCaGiaoDichDetail_GetByXacNhan";
                    cm.Parameters.AddWithValue("@BillId", MaQLHocSinh);
                    cm.Parameters.AddWithValue("@truong", Truong);
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                        {
                            ChiTietXuatKhoFromOtherDB ctbl = new ChiTietXuatKhoFromOtherDB();
                            ctbl.TenMonHoc = dr.GetString("TenMonHoc");
                            ctbl.SoLuong = dr.GetInt32("SoBan");
                            ctbl.DonViTinh = dr.GetString("DonViTinh");
                            ctbl.TenLop = dr.GetString("CourseName");
                            //ctbl.TenLop = dr.GetInt32("CourseName").ToString();
                            ctbl.GioiTinh = dr.GetString("Gender");
                            ctbienlailist.Add(ctbl);
                        }
                    }
                }
            }
            return ctbienlailist;
        }

        public static List<ChiTietXuatKhoFromOtherDB> LoadChiTietXuatBanDongPhucKhoFromOtherDBList(string tenDoiTuong)
        {
            List<ChiTietXuatKhoFromOtherDB> ctbienlailist = new List<ChiTietXuatKhoFromOtherDB>();
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandTimeout = 3600;
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_LoadChiTietXuatBanDongPhucFromOtherDBList";
                    cm.Parameters.AddWithValue("@TenDoiTuong", tenDoiTuong);
                    cm.Parameters.AddWithValue("@MaCongTy", Security.CurrentUser.Info.MaCongTy);
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                        {
                            ChiTietXuatKhoFromOtherDB ctbl = new ChiTietXuatKhoFromOtherDB();
                            //ctbl.MaChiTiet = dr.GetGuid("MaChiTiet");
                            //ctbl.MaChiTietInt = dr.GetInt64("MaChiTietInt");
                            //ctbl.MaBienLai = dr.GetGuid("MaBienLai");
                            ctbl.MaBienLaiInt = dr.GetInt32("MaBienLaiInt");
                            ctbl.SoBienLai = dr.GetString("SoBienLai");
                            //ctbl.MaDoiTuong = dr.GetGuid("MaDoiTuong");
                            ctbl.MaDoiTuongInt = dr.GetInt64("MaDoiTuongInt");
                            ctbl.MaQLDoiTuong = dr.GetString("MaQLDoiTuong");
                            ctbl.TenDoiTuong = dr.GetString("TenDoiTuong");
                            ctbl.NgayLap = dr.GetDateTime("NgayLap");
                            //ctbl.KieuThuPhi = dr.GetInt32("KieuThuPhi");
                            //ctbl.DienGiai = dr.GetString("DienGiai");
                            //ctbl.GhiChu = dr.GetString("GhiChu");
                            //ctbl.DonViTinh = dr.GetString("DonViTinh");
                            //ctbl.SoLuong = dr.GetDecimal("SoLuong");
                            ctbl.DonGia = dr.GetDecimal("DonGia");
                            ctbl.SoTien = dr.GetDecimal("SoTien");
                            ctbl.HinhThucThanhToan = dr.GetInt32("HinhThucThanhToan");
                            ctbl.TenHinhThucThanhToan = dr.GetString("TenHinhThucThanhToan");
                            ctbl.MaDonViCongTy = dr.GetString("MaDonViCongTy");

                            ctbl.SoTaiKhoan = dr.GetString("SoTaiKhoan");
                            ctbl.TenNganHang = dr.GetString("TenNganHang");

                            ctbl.TenLop = dr.GetString("TenLop");
                            ctbl.TenKhoi = dr.GetString("TenKhoi");
                            ctbl.TenHe = dr.GetString("TenHe");
                            ctbl.TenTruong = dr.GetString("TenTruong");
                            ctbl.MaTruongHocSinh = dr.GetString("MaTruongHocSinh");
                            ctbienlailist.Add(ctbl);
                        }
                    }
                }
            }
            return ctbienlailist;
        }

    }

    #endregion//XuatKho

    public class ThuPhiListFromOtherDB
    {
        public string FeeDetailTypeName { get; set; }
        public static List<ThuPhiListFromOtherDB> LoadThuPhiListFromOtherDBList()
        {
            List<ThuPhiListFromOtherDB> thuPhiListFromOtherDBList = new List<ThuPhiListFromOtherDB>();
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_LoadThuPhiListFromOtherDB";
                    cm.CommandTimeout = 900;
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                        {
                            ThuPhiListFromOtherDB tp = new ThuPhiListFromOtherDB();
                            tp.FeeDetailTypeName = dr.GetString("FeeDetailTypeName");
                            thuPhiListFromOtherDBList.Add(tp);
                        }
                    }
                }
            }
            return thuPhiListFromOtherDBList;
        }
    }

    public class LoaiDoiTacKhachHang
    {
        public int Ma { get; set; }
        public string TenLoai { get; set; }
        public LoaiDoiTacKhachHang(int ma, string tenLoai)
        {
            Ma = ma;
            TenLoai = tenLoai;
        }

        public static List<LoaiDoiTacKhachHang> CreateListLoaiDoiTacKhachHang()
        {
            List<LoaiDoiTacKhachHang> listRS = new List<LoaiDoiTacKhachHang>();
            listRS.Add(new LoaiDoiTacKhachHang(1, "Nhà cung cấp"));
            listRS.Add(new LoaiDoiTacKhachHang(2, "Khách hàng"));
            listRS.Add(new LoaiDoiTacKhachHang(3, "Nhà cung cấp và Khách Hàng"));
            return listRS;
        }
    }

    public class LoaiThueSuatVAT
    {
        public int ThueSuat { get; set; }
        public string MoTa { get; set; }
        public LoaiThueSuatVAT(int thuesuat, string mota)
        {
            ThueSuat = thuesuat;
            MoTa = mota;
        }

        public static List<LoaiThueSuatVAT> CreateListLoaiThueSuatVAT()
        {
            List<LoaiThueSuatVAT> listRS = new List<LoaiThueSuatVAT>();
            listRS.Add(new LoaiThueSuatVAT(0, "0"));
            listRS.Add(new LoaiThueSuatVAT(5, "5"));
            listRS.Add(new LoaiThueSuatVAT(10, "10"));
            listRS.Add(new LoaiThueSuatVAT(-1, "Không chịu thuế"));
            return listRS;
        }
        public static List<LoaiThueSuatVAT> CreateListPhanTramThueSuatVAT()
        {
            List<LoaiThueSuatVAT> listRS = new List<LoaiThueSuatVAT>();
            listRS.Add(new LoaiThueSuatVAT(0, "0"));
            listRS.Add(new LoaiThueSuatVAT(5, "5"));
            listRS.Add(new LoaiThueSuatVAT(10, "10"));           
            return listRS;
        }
    }

    //public class NhomHHDVMuaVao
    //{
    //    public byte MaNhom { get; set; }
    //    public string MoTa { get; set; }

    //    public NhomHHDVMuaVao(byte manhom, string mota)
    //    {
    //        MaNhom = manhom;
    //        MoTa = mota;
    //    }

    //    public static List<NhomHHDVMuaVao> CreateListNhomHHDVMuaVao()
    //    {
    //        List<NhomHHDVMuaVao> listRS = new List<NhomHHDVMuaVao>();
    //        listRS.Add(new NhomHHDVMuaVao(0, ""));
    //        listRS.Add(new NhomHHDVMuaVao(1, "1 - Hàng hóa, dịch vụ dùng riêng cho SXKD chịu thuế GTGT và sử dụng cho các hoạt động cung cấp hàng hóa,dịch vụ không kê khai, nộp thuế GTGT đủ điều kiện khấu trừ thuế"));
    //        listRS.Add(new NhomHHDVMuaVao(2, "2 - Hàng hóa, dịch vụ dùng chung cho SXKD chịu thuế và không chịu thuế đủ điều kiện khấu trừ thuế"));
    //        listRS.Add(new NhomHHDVMuaVao(3, "3 - Hàng hóa, dịch vụ dùng cho dự án đầu tư đủ điều kiện khấu trừ thuế"));
    //        listRS.Add(new NhomHHDVMuaVao(4, "4 - Hàng hóa, dịch vụ không đủ điều kiện khấu trừ"));
    //        listRS.Add(new NhomHHDVMuaVao(3, "5 - Hàng hóa, dịch vụ không phải tổng hợp trên tờ khai 01/GTGT"));
    //        return listRS;
    //    }
    //}

    public class LoaiDoiTuongModify
    {
        public int MaLoai { get; set; }
        public string MoTa { get; set; }

        public LoaiDoiTuongModify(int maloai, string mota)
        {
            MaLoai = maloai;
            MoTa = mota;
        }

        public static List<LoaiDoiTuongModify> CreateListLoaiDoiTuong()
        {
            List<LoaiDoiTuongModify> listRS = new List<LoaiDoiTuongModify>();
            listRS.Add(new LoaiDoiTuongModify(0, "<<Tất cả>>"));
            listRS.Add(new LoaiDoiTuongModify(3, "Đối tác"));
            listRS.Add(new LoaiDoiTuongModify(5, "Nhân viên"));
            listRS.Add(new LoaiDoiTuongModify(10, "Học sinh"));
            return listRS;
        }
    }


    public class ButToanThuePhaiNopForHoaDonBanRa
    {
        //        ct.SoChungTu,ct.NgayLap AS NgayChungTu
        //,bt.MaButToan,bt.SoTien AS TienThue,tien.ThanhTien AS TienSauThue
        public bool Check { get; set; }
        public string SoChungTu { get; set; }
        public DateTime NgayChungTu { get; set; }
        public int MaButToan { get; set; }
        public string TenDoiTuong { get; set; }
        public string DienGiai { get; set; }
        public decimal TienThue { get; set; }
        public decimal TienSauThue { get; set; }
        public int MaPhuongThucThanhToan { get; set; }
        public string PhuongThucThanhToanString { get; set; }
        public List<ButToanThuePhaiNopForHoaDonBanRa> ChiTietBienLaiList = new List<ButToanThuePhaiNopForHoaDonBanRa>();
        public static List<ButToanThuePhaiNopForHoaDonBanRa> LoadBienLaiFromOtherDBList()
        {
            List<ButToanThuePhaiNopForHoaDonBanRa> buttoanThuePhaiNoplist = new List<ButToanThuePhaiNopForHoaDonBanRa>();
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_LoadButToanThuePhaiNopForHoaDonBanHangList";
                    cm.CommandTimeout = 900;
                    cm.Parameters.AddWithValue("@MaCongTy", ERP_Library.Security.CurrentUser.Info.UserID);
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                        {
                            ButToanThuePhaiNopForHoaDonBanRa bt = new ButToanThuePhaiNopForHoaDonBanRa();
                            bt.SoChungTu = dr.GetString("SoChungTu");
                            bt.NgayChungTu = dr.GetDateTime("NgayChungTu");
                            bt.MaButToan = dr.GetInt32("MaButToan");
                            bt.TenDoiTuong = dr.GetString("TenDoiTuong");
                            bt.DienGiai = dr.GetString("DienGiai");
                            bt.TienThue = dr.GetDecimal("TienThue");
                            bt.TienSauThue = dr.GetDecimal("TienSauThue");
                            bt.MaPhuongThucThanhToan = dr.GetInt32("MaPhuongThucThanhToan");
                            bt.PhuongThucThanhToanString = dr.GetString("PhuongThucThanhToanString");
                            buttoanThuePhaiNoplist.Add(bt);
                        }
                    }
                }
            }
            return buttoanThuePhaiNoplist;
        }
    }

    public class ChungTuForHoaDonBanRa
    {
        //        ct.SoChungTu,ct.NgayLap AS NgayChungTu
        //,bt.MaButToan,bt.SoTien AS TienThue,tien.ThanhTien AS TienSauThue
        public bool Check { get; set; }
        public long MaChungTu { get; set; }
        public string SoChungTu { get; set; }
        public DateTime NgayChungTu { get; set; }
        public string TenDoiTuong { get; set; }
        public string DienGiai { get; set; }
        public decimal SoTienChungTu { get; set; }
        public int MaPhuongThucThanhToan { get; set; }
        public string PhuongThucThanhToanString { get; set; }
        public int MaButToan { get; set; }
        public decimal SoTienButToan { get; set; }
        public string DienGiaiButToan { get; set; }
        public long MaDoiTuong { get; set; }
        public int IDKhoanMuc { get; set; }
        public int MaLoaiChungTu { get; set; }
        public List<ChungTuForHoaDonBanRa> ChiTietBienLaiList = new List<ChungTuForHoaDonBanRa>();
        public static List<ChungTuForHoaDonBanRa> LoadChungTuForHoaDonBanRaList()
        {
            List<ChungTuForHoaDonBanRa> chungTuForHoaDonBanRalist = new List<ChungTuForHoaDonBanRa>();
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_LoadChungTuForHoaDonBanHangList";
                    cm.CommandTimeout = 900;
                    cm.Parameters.AddWithValue("@MaCongTy", Security.CurrentUser.Info.MaCongTy);
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                        {
                            ChungTuForHoaDonBanRa bt = new ChungTuForHoaDonBanRa();
                            bt.MaChungTu = dr.GetInt64("MaChungTu");
                            bt.SoChungTu = dr.GetString("SoChungTu");
                            bt.NgayChungTu = dr.GetDateTime("NgayChungTu");
                            bt.TenDoiTuong = dr.GetString("TenDoiTuong");
                            bt.DienGiai = dr.GetString("DienGiai");
                            bt.SoTienChungTu = dr.GetDecimal("SoTienChungTu");
                            bt.MaPhuongThucThanhToan = dr.GetInt32("MaPhuongThucThanhToan");
                            bt.PhuongThucThanhToanString = dr.GetString("PhuongThucThanhToanString");
                            bt.MaDoiTuong = dr.GetInt64("MaDoiTuong");
                            bt.MaButToan = dr.GetInt32("MaButToan");
                            bt.SoTienButToan = dr.GetDecimal("SoTienButToan");
                            bt.DienGiaiButToan = dr.GetString("DienGiaiButToan");
                            bt.IDKhoanMuc = dr.GetInt32("IDKhoanMuc");
                            bt.MaLoaiChungTu = dr.GetInt32("MaLoaiChungTu");
                            chungTuForHoaDonBanRalist.Add(bt);
                        }
                    }
                }
            }
            return chungTuForHoaDonBanRalist;
        }
    }

    #region Không sử dụng 
    //public class BoPhanModify
    //{
    //    public int MaBoPhan { get; set; }
    //    public string MaBoPhanQL { get; set; }
    //    public string TenBoPhan { get; set; }
    //    public int MaBoPhanCha { get; set; }
    //    public string TenBoPhanCha { get; set; }
    //    public string TaiKhoanKHHM { get; set; }
    //    public string TaiKhoanPBCP { get; set; }
    //    public Guid OidHRM { get; set; }
    //    public bool NgungSuDung { get; set; }
    //    public static List<BoPhanModify> LoadBoPhanModifyList(int macongty)
    //    {
    //        List<BoPhanModify> boPhanModifyList = new List<BoPhanModify>();
    //        using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
    //        {
    //            cn.Open();
    //            using (SqlCommand cm = cn.CreateCommand())
    //            {
    //                cm.CommandType = CommandType.StoredProcedure;
    //                cm.CommandText = "spd_LoadBophanListModify";
    //                cm.CommandTimeout = 900;
    //                cm.Parameters.AddWithValue("@UserID", Security.CurrentUser.Info.UserID);
    //                using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
    //                {
    //                    while (dr.Read())
    //                    {
    //                        BoPhanModify bp = new BoPhanModify();
    //                        bp.MaBoPhan = dr.GetInt32("MaBoPhan");
    //                        bp.MaBoPhanQL = dr.GetString("MaBoPhanQL");
    //                        bp.TenBoPhan = dr.GetString("TenBoPhan");
    //                        bp.MaBoPhanCha = dr.GetInt32("MaBoPhanCha");
    //                        bp.TenBoPhanCha = dr.GetString("TenBoPhanCha");
    //                        bp.TaiKhoanKHHM = dr.GetString("TaiKhoanKHHM");
    //                        bp.TaiKhoanPBCP = dr.GetString("TaiKhoanPBCP"); // bo sung ngay 05/11/2020
    //                        bp.OidHRM = dr.GetGuid("OidHRM");
    //                        bp.NgungSuDung = dr.GetBoolean("NgungSuDung");
    //                        boPhanModifyList.Add(bp);
    //                    }
    //                }
    //            }
    //        }
    //        return boPhanModifyList;
    //    }
    //}
    #endregion

    public class ChungTuReference
    {
        public bool Check { get; set; }
        public long MaChungTu { get; set; }
        public string SoChungTu { get; set; }
        public DateTime NgayChungTu { get; set; }
        public long MaDoiTuong { get; set; }
        public string TenDoiTuong { get; set; }
        public int MaLoaiTien { get; set; }
        public string TenLoaiTien { get; set; }
        public decimal SoTien { get; set; }
        public decimal TyGiaQuyDoi { get; set; }
        public decimal ThanhTien { get; set; }
        public string NoiDung { get; set; }
        public static List<ChungTuReference> LoadChungTuReferenceList(int maloaichungtu, long madoituong, byte refType)
        {
            List<ChungTuReference> chungTuReferenceList = new List<ChungTuReference>();
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_ChungTuReferenceList";
                    cm.CommandTimeout = 900;
                    cm.Parameters.AddWithValue("@MaLoaiChungTu", maloaichungtu);
                    cm.Parameters.AddWithValue("@MaDoiTuong", madoituong);
                    cm.Parameters.AddWithValue("@RefType", refType);
                    cm.Parameters.AddWithValue("@UserID", Security.CurrentUser.Info.UserID);
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                        {
                            ChungTuReference ct = new ChungTuReference();
                            ct.MaChungTu = dr.GetInt64("MaChungTu");
                            ct.SoChungTu = dr.GetString("SoChungTu");
                            ct.NgayChungTu = dr.GetDateTime("NgayChungTu");
                            ct.MaDoiTuong = dr.GetInt64("MaDoiTuong");
                            ct.TenDoiTuong = dr.GetString("TenDoiTuong");
                            ct.MaLoaiTien = dr.GetInt32("MaLoaiTien");
                            ct.TenLoaiTien = dr.GetString("TenLoaiTien");
                            ct.SoTien = dr.GetDecimal("SoTien");
                            ct.TyGiaQuyDoi = dr.GetDecimal("TyGiaQuyDoi");
                            ct.ThanhTien = dr.GetDecimal("ThanhTien");
                            ct.NoiDung = dr.GetString("NoiDung");
                            chungTuReferenceList.Add(ct);
                        }
                    }
                }
            }
            return chungTuReferenceList;
        }
    }

    #endregion
    public class PublicClass
    {

        public static string SetSoChungTuByMaLoaiChungTu(int maloaiChungTu, DateTime ngayLap)
        {
            string soChungTu = "";
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "Spd_SetSoChungTuByMaLoaiChungTu_1";
                    cm.CommandTimeout = 900;
                    cm.Parameters.AddWithValue("@MaLoaiChungTu", maloaiChungTu);
                    cm.Parameters.AddWithValue("@NgayLap", ngayLap);
                    cm.Parameters.AddWithValue("@UserID", Security.CurrentUser.Info.UserID);
                    SqlParameter prmGiaTriTraVe = new SqlParameter("@GiaTriTraVe", SqlDbType.VarChar, 50);
                    prmGiaTriTraVe.Direction = ParameterDirection.Output;
                    cm.Parameters.Add(prmGiaTriTraVe);
                    cm.ExecuteNonQuery();
                    soChungTu = (string)prmGiaTriTraVe.Value;
                }
            }//us
            return soChungTu;

        }

        public static long GetMaChungTuByBangKeThanhToanTamUng(int maBangKe)
        {
            long machungtu = 0;
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandTimeout = 900;
                    cm.CommandText = "Spd_GetMaChungTuByBangKeThanhToanTamUng";
                    cm.Parameters.AddWithValue("@MaBangKe", maBangKe);
                    SqlParameter prmGiaTriTraVe = new SqlParameter("@GiaTriTraVe", SqlDbType.BigInt, 50);
                    prmGiaTriTraVe.Direction = ParameterDirection.Output;
                    cm.Parameters.Add(prmGiaTriTraVe);
                    cm.ExecuteNonQuery();
                    machungtu = (long)prmGiaTriTraVe.Value;
                }
            }//us
            return machungtu;

        }

        public static bool KiemTraDeNghiChuyenKhoanDaLapUNC(long maDeNghiCK)
        {
            bool rs = false;
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "Spd_KiemTraDeNghiChuyenKhoanDaLapUNC";
                    cm.CommandTimeout = 900;
                    cm.Parameters.AddWithValue("@MaDeNghiCK", maDeNghiCK);
                    SqlParameter prmGiaTriTraVe = new SqlParameter("@GiaTriTraVe", SqlDbType.Bit, 50);
                    prmGiaTriTraVe.Direction = ParameterDirection.Output;
                    cm.Parameters.Add(prmGiaTriTraVe);
                    cm.ExecuteNonQuery();
                    rs = (bool)prmGiaTriTraVe.Value;
                }
            }//us
            return rs;

        }
        public static bool KiemTraChungTuButToanDaLapDSChi(long machungtu, int mabuttoan)
        {
            bool rs = false;
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "Spd_KiemTraChungTuButToanDaLapDSChi";
                    cm.CommandTimeout = 900;
                    cm.Parameters.AddWithValue("@MaChungTu", machungtu);
                    cm.Parameters.AddWithValue("@MaButToan", mabuttoan);
                    SqlParameter prmGiaTriTraVe = new SqlParameter("@GiaTriTraVe", SqlDbType.Bit, 50);
                    prmGiaTriTraVe.Direction = ParameterDirection.Output;
                    cm.Parameters.Add(prmGiaTriTraVe);
                    cm.ExecuteNonQuery();
                    rs = (bool)prmGiaTriTraVe.Value;
                }
            }//us
            return rs;
        }

        public static DateTime StartOfWeek(DateTime dt, DayOfWeek startOfWeek)
        {
            int diff = dt.DayOfWeek - startOfWeek;
            if (diff < 0)
            {
                diff += 7;
            }
            return dt.AddDays(-1 * diff).Date;
        }

        public static DateTime LastOfWeek(DateTime dt, DayOfWeek startOfWeek)
        {
            DateTime ldowDate = (StartOfWeek(dt, startOfWeek)).AddDays(6);
            return ldowDate;
        }

        public static DateTime GetFirstDayInMonth(int year, int month)
        {
            DateTime aDateTime = new DateTime(year, month, 1);
            return aDateTime;
        }

        public static DateTime GetLastDayInMonth(int year, int month)
        {
            DateTime aDateTime = new DateTime(year, month, 1);
            // Cộng thêm 1 tháng và trừ đi một ngày.
            DateTime retDateTime = aDateTime.AddMonths(1).AddDays(-1);
            return retDateTime;
        }

        public static DateTime GetFirstDayInLastMonth(int year, int month)
        {
            DateTime aDateTime = new DateTime(year, month, 1);
            DateTime rsDateTime = aDateTime.AddMonths(-1);
            return rsDateTime;
        }

        public static DateTime GetLastDayInLastMonth(int year, int month)
        {
            DateTime aDateTime = new DateTime(year, month, 1);
            DateTime retDateTime = (aDateTime.AddMonths(-1)).AddMonths(1).AddDays(-1);
            return retDateTime;
        }

        public static DateTime GetFirstDayInQuarterOfYear(int year, int month)
        {
            DateTime rSDateTime = new DateTime();
            if (month >= 1 && month <= 3)
            {
                rSDateTime = GetFirstDayInMonth(year, 1);
            }
            else if (month >= 4 && month <= 6)
            {
                rSDateTime = GetFirstDayInMonth(year, 4);
            }
            else if (month >= 7 && month <= 9)
            {
                rSDateTime = GetFirstDayInMonth(year, 7);
            }
            else if (month >= 10 && month <= 12)
            {
                rSDateTime = GetFirstDayInMonth(year, 10);
            }
            return rSDateTime;
        }

        public static DateTime GetLastDayInQuarterOfYear(int year, int month)
        {
            DateTime rSDateTime = new DateTime();
            if (month >= 1 && month <= 3)
            {
                rSDateTime = GetLastDayInMonth(year, 3);
            }
            else if (month >= 4 && month <= 6)
            {
                rSDateTime = GetLastDayInMonth(year, 6);
            }
            else if (month >= 7 && month <= 9)
            {
                rSDateTime = GetLastDayInMonth(year, 9);
            }
            else if (month >= 10 && month <= 12)
            {
                rSDateTime = GetLastDayInMonth(year, 12);
            }
            return rSDateTime;
        }

        public static DateTime GetFirstDayInLastQuarterOfYear(int year, int month)
        {
            DateTime rSDateTime = new DateTime();
            if (month >= 1 && month <= 3)
            {
                rSDateTime = GetFirstDayInMonth(year - 1, 10);
            }
            else if (month >= 4 && month <= 6)
            {
                rSDateTime = GetFirstDayInMonth(year, 1);
            }
            else if (month >= 7 && month <= 9)
            {
                rSDateTime = GetFirstDayInMonth(year, 4);
            }
            else if (month >= 10 && month <= 12)
            {
                rSDateTime = GetFirstDayInMonth(year, 7);
            }
            return rSDateTime;
        }

        public static DateTime GetLastDayInLastQuarterOfYear(int year, int month)
        {
            DateTime rSDateTime = new DateTime();
            if (month >= 1 && month <= 3)
            {
                rSDateTime = GetLastDayInMonth(year - 1, 12);
            }
            else if (month >= 4 && month <= 6)
            {
                rSDateTime = GetLastDayInMonth(year, 3);
            }
            else if (month >= 7 && month <= 9)
            {
                rSDateTime = GetLastDayInMonth(year, 6);
            }
            else if (month >= 10 && month <= 12)
            {
                rSDateTime = GetLastDayInMonth(year, 9);
            }
            return rSDateTime;
        }

        public static DateTime GetFirstDayInYear(int year)
        {
            DateTime rSDateTime = new DateTime(year, 1, 1);
            return rSDateTime;
        }

        public static DateTime GetLastDayInYear(int year)
        {
            DateTime rSDateTime = new DateTime(year, 12, 31);
            return rSDateTime;
        }

        public static bool KiemTraLaTaiKhoanThueKhauTru(string sohieuTK)
        {
            foreach (TaiKhoanThue tkThue in TaiKhoanThue.TaiKhoanThueList)
            {
                if (tkThue.SoHieuTKThueKhauTru != "" && sohieuTK.StartsWith(tkThue.SoHieuTKThueKhauTru)) return true;
                //if (tkThue.SoHieuTKThue.StartsWith(sohieuTK)) return true;
            }
            return false;
        }

        public static bool KiemTraLaTaiKhoanThuePhaiNop(string sohieuTK)
        {
            foreach (TaiKhoanThue tkThue in TaiKhoanThue.TaiKhoanThueList)
            {
                if (tkThue.SoHieuTKThuePhaiNop != "" && sohieuTK.StartsWith(tkThue.SoHieuTKThuePhaiNop)) return true;
                //if (tkThue.SoHieuTKThue.StartsWith(sohieuTK)) return true;
            }
            return false;
        }

        public static bool KiemTraLaTaiKhoanTamUng(string sohieuTK)
        {
            foreach (TaiKhoanThue tkThue in TaiKhoanThue.TaiKhoanThueList)
            {
                if (tkThue.SoHieuTKTamUng != "" && sohieuTK.StartsWith(tkThue.SoHieuTKTamUng)) return true;
            }
            return false;
        }

        public static bool KiemTraChungTuDaLapHoaDon(long machungtu, int mabuttoan)
        {
            bool rs = false;
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandTimeout = 900;
                    cm.CommandText = "Spd_KiemTraChungTuDaLapHoaDon";
                    cm.Parameters.AddWithValue("@MaChungTu", machungtu);
                    cm.Parameters.AddWithValue("@MaButToan", mabuttoan);
                    SqlParameter prmGiaTriTraVe = new SqlParameter("@GiaTriTraVe", SqlDbType.Bit, 50);
                    prmGiaTriTraVe.Direction = ParameterDirection.Output;
                    cm.Parameters.Add(prmGiaTriTraVe);
                    cm.ExecuteNonQuery();
                    rs = (bool)prmGiaTriTraVe.Value;
                }
            }//us
            return rs;
        }

        public static long KiemTraHoaDonDaLapChungTuKeToan(long maHoaDon)
        {
            long rs = 0;
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "Spd_KiemTraHoaDonDaLapChungTuKeToan";
                    cm.CommandTimeout = 900;
                    cm.Parameters.AddWithValue("@MaHoaDon", maHoaDon);
                    cm.Parameters.AddWithValue("@UserID", Security.CurrentUser.Info.UserID);
                    SqlParameter prmGiaTriTraVe = new SqlParameter("@MaChungTuTraVe", SqlDbType.BigInt, 50);
                    prmGiaTriTraVe.Direction = ParameterDirection.Output;
                    cm.Parameters.Add(prmGiaTriTraVe);
                    cm.ExecuteNonQuery();
                    rs = (long)prmGiaTriTraVe.Value;
                }
            }//us
            return rs;
        }

        public static bool KiemTraIsHoaDonBiHuy(long maHoaDon)
        {
            bool rs = false;
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "Spd_KiemTraIsHoaDonBiHuy";
                    cm.CommandTimeout = 900;
                    cm.Parameters.AddWithValue("@MaHoaDon", maHoaDon);
                    cm.Parameters.AddWithValue("@UserID", Security.CurrentUser.Info.UserID);
                    SqlParameter prmGiaTriTraVe = new SqlParameter("@GiaTriTraVe", SqlDbType.Bit, 50);
                    prmGiaTriTraVe.Direction = ParameterDirection.Output;
                    cm.Parameters.Add(prmGiaTriTraVe);
                    cm.ExecuteNonQuery();
                    rs = (bool)prmGiaTriTraVe.Value;
                }
            }//us
            return rs;

        }

        public static void ImportChungTuFromExcel(SqlTransaction tr)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandTimeout = 3600;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_ImportChungTuDataFromExcel";                
                cm.Parameters.AddWithValue("@MaCongTy", Security.CurrentUser.Info.MaCongTy);
                cm.Parameters.AddWithValue("@UserID", Security.CurrentUser.Info.UserID);
                cm.Parameters.AddWithValue("@NgayImport", DateTime.Today.Date);

                cm.ExecuteNonQuery();
            }//using
        }

        public static void ImportChiTietNhapXuatFormExcel(SqlTransaction tr)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandTimeout = 3600;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_ImportChiTietNhapXuatFormExcel";
                cm.Parameters.AddWithValue("@MaCongTy", Security.CurrentUser.Info.MaCongTy);
                cm.Parameters.AddWithValue("@UserID", Security.CurrentUser.Info.UserID);
                cm.Parameters.AddWithValue("@NgayImport", DateTime.Today.Date);

                cm.ExecuteNonQuery();
            }//using
        }

        public static decimal GetSoTienHoanUng(long maChungTu, long maChungTuRef, long maDoiTuong)
        {
            decimal rs = 0;
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    //@MaChungTu BIGINT,@MaChungTuRef BIGINT, @MaDoiTuong BIGINT,@UserID INT,@SoTien DECIMAL  output 
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandTimeout = 900;
                    cm.CommandText = "Spd_GetSoTienHoanUng";
                    cm.Parameters.AddWithValue("@MaChungTu", maChungTu);
                    cm.Parameters.AddWithValue("@MaChungTuRef", maChungTuRef);
                    cm.Parameters.AddWithValue("@MaDoiTuong", maDoiTuong);
                    cm.Parameters.AddWithValue("@UserID", ERP_Library.Security.CurrentUser.Info.UserID);
                    SqlParameter prmGiaTriTraVe = new SqlParameter("@SoTien", SqlDbType.Decimal, 50);
                    prmGiaTriTraVe.Direction = ParameterDirection.Output;
                    cm.Parameters.Add(prmGiaTriTraVe);
                    cm.ExecuteNonQuery();
                    rs = (decimal)prmGiaTriTraVe.Value;
                }
            }//us
            return rs;
        }

        public static bool KiemTraDaPhatSinhNghiepVuTrongKyHoacSauKy(int kyKeToan)
        {
            bool Kt = false;
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "Spd_KiemTraDaPhatSinhNghiepVuTrongKyHoacSauKy";
                    cm.CommandTimeout = 900;
                    cm.Parameters.AddWithValue("@KyKeToan", kyKeToan);
                    SqlParameter prmGiaTriTraVe = new SqlParameter("@GiaTriTraVe", SqlDbType.Bit);
                    prmGiaTriTraVe.Direction = ParameterDirection.Output;
                    cm.Parameters.Add(prmGiaTriTraVe);
                    cm.ExecuteNonQuery();
                    Kt = (bool)prmGiaTriTraVe.Value;
                }
            }//us
            return Kt;

        }

        public static decimal LayGiaNhapGanNhat(int MaHangHoa, DateTime Ngay)
        {
            decimal rs = 0;
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    //@MaChungTu BIGINT,@MaChungTuRef BIGINT, @MaDoiTuong BIGINT,@UserID INT,@SoTien DECIMAL  output 
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_LayGiaNhapGanNhat";
                    cm.CommandTimeout = 900;
                    cm.Parameters.AddWithValue("@MaHangHoa", MaHangHoa);
                    cm.Parameters.AddWithValue("@Ngay", Ngay);
                    cm.Parameters.AddWithValue("@UserID", Security.CurrentUser.Info.UserID);
                    SqlParameter prmGiaTriTraVe = new SqlParameter("@SoTien", SqlDbType.Decimal, 50);
                    prmGiaTriTraVe.Direction = ParameterDirection.Output;
                    cm.Parameters.Add(prmGiaTriTraVe);
                    cm.ExecuteNonQuery();
                    rs = (decimal)prmGiaTriTraVe.Value;
                }
            }//us
            return rs;
        }

        public static string KiemTraTichHopFast(int tuKy, int maCongTy)
        {
            string rs = "";
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_KiemTra_TichHopFAST";
                    cm.CommandTimeout = 3000;
                    cm.Parameters.AddWithValue("@tuKy", tuKy);
                    cm.Parameters.AddWithValue("@maCongTy", maCongTy);

                    DataSet ds = new DataSet();
                    DataTable dt;
                    SqlDataAdapter da = new SqlDataAdapter(cm);
                    da.Fill(ds);
                    dt = ds.Tables[0];

                    rs = dt.Rows[0][0] + "";
                }
            }//us
            return rs;
        }


    }
}
