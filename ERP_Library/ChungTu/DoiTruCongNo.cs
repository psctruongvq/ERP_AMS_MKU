
using Csla.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace ERP_Library
{
    public class GetNCCConNo
    {
        public bool Check { get; set; }
        public long MaChungTu { get; set; }
        public DateTime NgayLap { get; set; }
        public int MaButToan { get; set; }
        public long MaDoiTuong { get; set; }
        public long MaDoiTuongNo { get; set; }
        public string SoChungTu { get; set; }
        public string TenDoiTac { get; set; }
        public decimal SoTien { get; set; }
        public decimal SoTienHDTT { get; set; }
        public decimal SoTienChuaDoiTru { get; set; }
        public bool CheckDaTraNo { get; set; }
        public int MaLoaiChungTu { get; set; }
        public string DienGiai { get; set; }

        public static List<GetNCCConNo> LoadGetNCCConNo(int MaDoiTuong, DateTime TuNgay, DateTime DenNgay)
        {
            List<GetNCCConNo> ctkhauhao = new List<GetNCCConNo>();
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandTimeout = 3600;
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_GetNCCCoNo";
                    cm.Parameters.AddWithValue("@MaDoiTuong", MaDoiTuong);
                    cm.Parameters.AddWithValue("@TuNgay", TuNgay);
                    cm.Parameters.AddWithValue("@DenNgay", DenNgay);
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                        {
                            GetNCCConNo ctkh = new GetNCCConNo();

                            ctkh.MaChungTu = dr.GetInt64("MaChungTu");
                            ctkh.NgayLap = dr.GetDateTime("NgayLap");
                            ctkh.MaButToan = dr.GetInt32("MaButToan");
                            ctkh.MaDoiTuong = dr.GetInt64("MaDoiTuong");
                            ctkh.MaDoiTuongNo = dr.GetInt64("MaDoiTuongNo");
                            ctkh.SoChungTu = dr.GetString("SoChungTu");
                            ctkh.TenDoiTac = dr.GetString("TenDoiTac");
                            ctkh.SoTien = dr.GetDecimal("SoTien");
                            //ctkh.SoTienHDTT = dr.GetDecimal("SoTienHDTT");
                            ctkh.SoTienChuaDoiTru = dr.GetDecimal("SoTienChuaDoiTru");
                            ctkh.MaLoaiChungTu = dr.GetInt32("MaLoaiChungTu");
                            ctkh.DienGiai = dr.GetString("DienGiai");
                            ctkhauhao.Add(ctkh);
                        }
                    }
                }
            }
            return ctkhauhao;
        }
    }

    public class GetHocSinhDoiTru
    {
        public bool Check { get; set; }
        public long MaChungTu { get; set; }
        public DateTime NgayLap { get; set; }
        public int MaButToan { get; set; }
        public long MaDoiTuong { get; set; }
        public long MaDoiTuongNo { get; set; }
        public string SoChungTu { get; set; }
        public string TenDoiTac { get; set; }
        public decimal SoTien { get; set; }
        public decimal SoTienHDTT { get; set; }
        public decimal SoTienChuaDoiTru { get; set; }
        public bool CheckDaTraNo { get; set; }
        public string DienGiai { get; set; }
        public int MaLoaiChungTu { get; set; }


        public static List<GetHocSinhDoiTru> LoadGetHocSinhDoiTru(int MaDoiTuong)
        {
            List<GetHocSinhDoiTru> ctkhauhao = new List<GetHocSinhDoiTru>();
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandTimeout = 3600;
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_GetHocSinhDoiTru";
                    cm.Parameters.AddWithValue("@MaDoiTac", MaDoiTuong);
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                        {
                            GetHocSinhDoiTru ctkh = new GetHocSinhDoiTru();

                            ctkh.MaChungTu = dr.GetInt64("MaChungTu");
                            ctkh.NgayLap = dr.GetDateTime("NgayLap");
                            ctkh.MaButToan = dr.GetInt32("MaButToan");
                            ctkh.MaDoiTuong = dr.GetInt64("MaDoiTuong");
                            ctkh.MaDoiTuongNo = dr.GetInt64("MaDoiTuongNo");
                            ctkh.SoChungTu = dr.GetString("SoChungTu");
                            ctkh.TenDoiTac = dr.GetString("TenDoiTac");
                            ctkh.SoTien = dr.GetDecimal("SoTien");
                            //ctkh.SoTienHDTT = dr.GetDecimal("SoTienHDTT");
                            ctkh.SoTienChuaDoiTru = dr.GetDecimal("SoTienChuaDoiTru");
                            ctkh.DienGiai = dr.GetString("DienGiai");
                            ctkh.MaLoaiChungTu = dr.GetInt32("MaLoaiChungTu");
                            ctkhauhao.Add(ctkh);
                        }

                    }
                }
            }
            return ctkhauhao;
        }
    }

    public class GetHDChuaTTOrTTChuaHetForHocSinh
    {
        public bool Check { get; set; }
        public long MaHoaDon { get; set; }
        public long MaChungTu { get; set; }
        public long MaPhieuNhapXuat { get; set; }
        public decimal TongTien { get; set; }
        public int MaButToan { get; set; }
        public string SoHoaDon { get; set; }
        public DateTime NgayLap { get; set; }
        public decimal SoTienHDDaTT { get; set; }
        public decimal SoTienConNo { get; set; }
        public decimal ThueVAT { get; set; }
        public bool checkDaTT { get; set; }
        public string DienGiai { get; set; }

        public static List<GetHDChuaTTOrTTChuaHetForHocSinh> LoadGetHDChuaTTOrTTChuaHetForHocSinh(int MaDoiTac)
        {
            List<GetHDChuaTTOrTTChuaHetForHocSinh> ctkhauhao = new List<GetHDChuaTTOrTTChuaHetForHocSinh>();
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandTimeout = 3600;
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_GetHDTTForHocSinh";
                    cm.Parameters.AddWithValue("@MaDoiTac", MaDoiTac);
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                        {
                            GetHDChuaTTOrTTChuaHetForHocSinh ctkh = new GetHDChuaTTOrTTChuaHetForHocSinh();

                            ctkh.MaHoaDon = dr.GetInt64("MaHoaDon");
                            //ctkh.MaChungTu = dr.GetInt64("MaChungTu");
                            ctkh.SoHoaDon = dr.GetString("SoHoaDon");
                            ctkh.NgayLap = dr.GetDateTime("NgayLap");
                            ctkh.TongTien = dr.GetDecimal("TongTien");
                            //ctkh.MaButToan = dr.GetInt32("MaButToan");
                            ctkh.SoTienHDDaTT = dr.GetDecimal("SoTienDaThanhToan");
                            ctkh.SoTienConNo = dr.GetDecimal("SoTienConLai");
                            ctkh.MaPhieuNhapXuat = dr.GetInt64("MaPhieuNhapXuat");
                            ctkh.ThueVAT = dr.GetDecimal("TienThue");
                            ctkh.DienGiai = dr.GetString("DienGiai");
                            ctkhauhao.Add(ctkh);
                        }

                    }
                }
            }
            return ctkhauhao;
        }

    }

    public class GetHDChuaTTOrTTChuaHet
    {
        public bool Check { get; set; }
        public long MaHoaDon { get; set; }
        public long MaChungTu { get; set; }
        public long MaPhieuNhapXuat { get; set; }
        public decimal TongTien { get; set; }
        public int MaButToan { get; set; }
        public string SoHoaDon { get; set; }
        public DateTime NgayLap { get; set; }
        public decimal SoTienHDDaTT { get; set; }
        public decimal SoTienConNo { get; set; }
        public decimal ThueVAT { get; set; }
        public bool checkDaTT { get; set; }
        public string GhiChu { get; set; }

        public static List<GetHDChuaTTOrTTChuaHet> LoadGetHDChuaTTOrTTChuaHet(int MaDoiTac, DateTime TuNgay, DateTime DenNgay)
        {
            List<GetHDChuaTTOrTTChuaHet> ctkhauhao = new List<GetHDChuaTTOrTTChuaHet>();
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandTimeout = 3600;
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_GetHDTT";
                    cm.Parameters.AddWithValue("@MaDoiTac", MaDoiTac);
                    cm.Parameters.AddWithValue("@TuNgay", TuNgay);
                    cm.Parameters.AddWithValue("@DenNgay", DenNgay);
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                        {
                            GetHDChuaTTOrTTChuaHet ctkh = new GetHDChuaTTOrTTChuaHet();

                            ctkh.MaHoaDon = dr.GetInt64("MaHoaDon");
                            //ctkh.MaChungTu = dr.GetInt64("MaChungTu");
                            ctkh.SoHoaDon = dr.GetString("SoHoaDon");
                            ctkh.NgayLap = dr.GetDateTime("NgayLap");
                            ctkh.TongTien = dr.GetDecimal("TongTien");
                            //ctkh.MaButToan = dr.GetInt32("MaButToan");
                            //ctkh.SoTienHDDaTT = dr.GetDecimal("SoTienHDDaTT");
                            ctkh.SoTienConNo = dr.GetDecimal("SoTienConNo");
                            ctkh.MaPhieuNhapXuat = dr.GetInt64("MaPhieuNhapXuat");
                            ctkh.ThueVAT = dr.GetDecimal("ThueVAT");
                            ctkh.GhiChu = dr.GetString("GhiChu");
                            ctkhauhao.Add(ctkh);
                        }

                    }
                }
            }
            return ctkhauhao;
        }

    }

    public class GetButToanTheoDoiTuongvaTaiKhoan
    {
        public bool Check { get; set; }
        public long MaChungTu { get; set; }
        public DateTime NgayLap { get; set; }
        public int MaButToan { get; set; }
        public long MaDoiTuong { get; set; }
        public long MaDoiTuongNo { get; set; }
        public string SoChungTu { get; set; }
        public string TenDoiTac { get; set; }
        public decimal SoTien { get; set; }
        public decimal SoTienHDTT { get; set; }
        public decimal SoTienChuaDoiTru { get; set; }
        public bool CheckDaTraNo { get; set; }
        public int MaLoaiChungTu { get; set; }
        public string DienGiai { get; set; }
        public int maTaiKhoan { get; set; }

        public static List<GetButToanTheoDoiTuongvaTaiKhoan> LoadGetButToanTheoDoiTuongvaTaiKhoan(int MaDoiTuong, DateTime TuNgay, DateTime DenNgay, int maTaiKhoan, Boolean isNoCo)
        {
            List<GetButToanTheoDoiTuongvaTaiKhoan> danhSachButToan = new List<GetButToanTheoDoiTuongvaTaiKhoan>();
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandTimeout = 3600;
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_GetButToanTheoDoiTuongVaTaiKhoan";
                    cm.Parameters.AddWithValue("@MaDoiTuong", MaDoiTuong);
                    cm.Parameters.AddWithValue("@TuNgay", TuNgay);
                    cm.Parameters.AddWithValue("@DenNgay", DenNgay);
                    cm.Parameters.AddWithValue("@MaTaiKhoan", maTaiKhoan);
                    cm.Parameters.AddWithValue("@IsNoCo", isNoCo);
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                        {
                            GetButToanTheoDoiTuongvaTaiKhoan butToan = new GetButToanTheoDoiTuongvaTaiKhoan();

                            butToan.MaChungTu = dr.GetInt64("MaChungTu");
                            butToan.NgayLap = dr.GetDateTime("NgayLap");
                            butToan.MaButToan = dr.GetInt32("MaButToan");
                            butToan.MaDoiTuong = dr.GetInt64("MaDoiTuong");
                            butToan.MaDoiTuongNo = dr.GetInt64("MaDoiTuongNo");
                            butToan.SoChungTu = dr.GetString("SoChungTu");
                            butToan.TenDoiTac = dr.GetString("TenDoiTac");
                            butToan.SoTien = dr.GetDecimal("SoTien");
                            //ctkh.SoTienHDTT = dr.GetDecimal("SoTienHDTT");
                            butToan.SoTienChuaDoiTru = dr.GetDecimal("SoTienChuaDoiTru");
                            butToan.MaLoaiChungTu = dr.GetInt32("MaLoaiChungTu");
                            butToan.DienGiai = dr.GetString("DienGiai");
                            danhSachButToan.Add(butToan);
                        }
                    }
                }
            }
            return danhSachButToan;
        }
    }

}
