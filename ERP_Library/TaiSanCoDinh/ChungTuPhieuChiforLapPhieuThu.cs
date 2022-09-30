using Csla;
using Csla.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace ERP_Library
{
    public class ChungTuPhieuChiforLapPhieuThu
    {
        // Fields...
        public long MaChungTu{get;set;}

        [DisplayName("Chọn")]
        public bool Check { get; set; }

        [DisplayName("Số chứng từ")]
        public string SoChungTu { get; set; }

        [DisplayName("Ngày lập")]
        public DateTime NgayLap { get; set; }

        [DisplayName("Giá trị")]
        public decimal GiaTriPhieuChi { get; set; }

        [DisplayName("Tiền thuế")]
        public decimal TienThue { get; set; }


        public ChungTuPhieuChiforLapPhieuThu(string sochungtu)
        {
            this.Check = false;
            this.MaChungTu = 0;
            this.SoChungTu = sochungtu;
        }

        public ChungTuPhieuChiforLapPhieuThu(long maChungTu, string soChungTu,DateTime ngayLap,decimal giaTriPhieuChi,decimal tienThue )
        {
            this.Check = false;
            this.MaChungTu = maChungTu;
            this.SoChungTu = soChungTu;
            this.NgayLap = ngayLap;
            this.GiaTriPhieuChi = giaTriPhieuChi;
            this.TienThue = tienThue;
            
        }

        public ChungTuPhieuChiforLapPhieuThu(long maChungTu, string soChungTu, DateTime ngayLap)
        {
            this.Check = false;
            this.MaChungTu = maChungTu;
            this.SoChungTu = soChungTu;
            this.NgayLap = ngayLap;

        }

        public static List<ChungTuPhieuChiforLapPhieuThu> CreatChungTuPhieuChiforLapPhieuThuList(long maChungTuPhieuThu)
        {
            List<ChungTuPhieuChiforLapPhieuThu> listResult = new List<ChungTuPhieuChiforLapPhieuThu>();
            //listResult.Add(new ChungTuPhieuChiforLapPhieuThu("<Không chọn>"));
            try
            {
                using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
                {
                    cn.Open();
                    using (SqlCommand cm = cn.CreateCommand())
                    {
                        cm.CommandType = CommandType.StoredProcedure;
                        cm.CommandText = "spd_SelectChungTuPhieuChiListforLapPhieuThu";
                        cm.Parameters.AddWithValue("@MaChungTuPhieuThu", maChungTuPhieuThu);
                        cm.Parameters.AddWithValue("@MaCongTy", ERP_Library.Security.CurrentUser.Info.MaCongTy);
                        using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                        {
                            while (dr.Read())
                            {
                                long machungtu = dr.GetInt64("MaChungTu");
                                string sochungtu = dr.GetString("SoChungTu");
                                DateTime ngaylap = dr.GetDateTime("NgayLap");
                                decimal giatriphieuchi = dr.GetDecimal("GiaTriPhieuChi");
                                decimal tienthue = dr.GetDecimal("TienThue");
                                listResult.Add(new ChungTuPhieuChiforLapPhieuThu(machungtu, sochungtu, ngaylap, giatriphieuchi, tienthue));
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return listResult;
        }

        public static List<ChungTuPhieuChiforLapPhieuThu> CreatChungTuPhieuChiListforCapNhatThueCTVTienMat(DateTime tuNgay,DateTime denNgay)
        {
            List<ChungTuPhieuChiforLapPhieuThu> listResult = new List<ChungTuPhieuChiforLapPhieuThu>();
            listResult.Add(new ChungTuPhieuChiforLapPhieuThu("<Tất cả>"));
            try
            {
                using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
                {
                    cn.Open();
                    using (SqlCommand cm = cn.CreateCommand())
                    {
                        cm.CommandType = CommandType.StoredProcedure;
                        cm.CommandText = "spd_SelectChungTuPhieuChiListforCapNhatThueCTVTienMat";
                        cm.Parameters.AddWithValue("@MaCongTy", ERP_Library.Security.CurrentUser.Info.MaCongTy);
                        cm.Parameters.AddWithValue("@TuNgay", tuNgay);
                        cm.Parameters.AddWithValue("@DenNgay", denNgay);
                        using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                        {
                            while (dr.Read())
                            {
                                long machungtu = dr.GetInt64("MaChungTu");
                                string sochungtu = dr.GetString("SoChungTu");
                                DateTime ngaylap = dr.GetDateTime("NgayLap");
                                listResult.Add(new ChungTuPhieuChiforLapPhieuThu(machungtu, sochungtu, ngaylap));
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return listResult;
        }

        public static List<ChungTuPhieuChiforLapPhieuThu> CreatChungTuPhieuChiListforBaoCaoThueCTVTienMat(DateTime tuNgay, DateTime denNgay)
        {
            List<ChungTuPhieuChiforLapPhieuThu> listResult = new List<ChungTuPhieuChiforLapPhieuThu>();
            listResult.Add(new ChungTuPhieuChiforLapPhieuThu("<Tất cả>"));
            try
            {
                using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
                {
                    cn.Open();
                    using (SqlCommand cm = cn.CreateCommand())
                    {
                        cm.CommandType = CommandType.StoredProcedure;
                        cm.CommandText = "spd_SelectChungTuPhieuChiListforBaoCaoThueCTVTienMat";
                        cm.Parameters.AddWithValue("@MaCongTy", ERP_Library.Security.CurrentUser.Info.MaCongTy);
                        cm.Parameters.AddWithValue("@TuNgay", tuNgay);
                        cm.Parameters.AddWithValue("@DenNgay", denNgay);
                        using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                        {
                            while (dr.Read())
                            {
                                long machungtu = dr.GetInt64("MaChungTu");
                                string sochungtu = dr.GetString("SoChungTu");
                                DateTime ngaylap = dr.GetDateTime("NgayLap");
                                listResult.Add(new ChungTuPhieuChiforLapPhieuThu(machungtu, sochungtu, ngaylap));
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return listResult;
        }

        public static void InsertIntotblThueCongTacVienbyMaChungTuPC(DateTime tuNgay, DateTime denNgay,long maChungTuPC)
        {
            using (SqlConnection cn = new SqlConnection(ERP_Library.Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_InsertIntotblThueCongTacVienbyMaChungTuPC";
                    cm.Parameters.AddWithValue("@TuNgay", tuNgay);
                    cm.Parameters.AddWithValue("@DenNgay", denNgay);
                    cm.Parameters.AddWithValue("@MaChungTuPC", maChungTuPC);
                    cm.Parameters.AddWithValue("@userID", ERP_Library.Security.CurrentUser.Info.UserID);
                    cm.Parameters.AddWithValue("@MaCongTy", ERP_Library.Security.CurrentUser.Info.MaCongTy);

                    cm.ExecuteNonQuery();
                }
            }//using
        }

        public static void DeleteblThueCongTacVienbyMaChungTuPC(DateTime tuNgay, DateTime denNgay, long maChungTuPC)
        {
            using (SqlConnection cn = new SqlConnection(ERP_Library.Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_DeletetblThueThuNhapCaNhanbyMaChungTuPC";
                    cm.Parameters.AddWithValue("@TuNgay", tuNgay);
                    cm.Parameters.AddWithValue("@DenNgay", denNgay);
                    cm.Parameters.AddWithValue("@MaChungTuPC", maChungTuPC);
                    cm.Parameters.AddWithValue("@userID", ERP_Library.Security.CurrentUser.Info.UserID);
                    cm.Parameters.AddWithValue("@MaCongTy", ERP_Library.Security.CurrentUser.Info.MaCongTy);

                    cm.ExecuteNonQuery();
                }
            }//using
        }

        public static bool KiemTraThueCTVDaIN(DateTime tuNgay, DateTime denNgay, long maChungTuPC)
        {
            bool result = false;
            using (SqlConnection cn = new SqlConnection(ERP_Library.Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_KiemTraThueCongTacVienDaIn";
                    cm.Parameters.AddWithValue("@TuNgay", tuNgay);
                    cm.Parameters.AddWithValue("@DenNgay", denNgay);
                    cm.Parameters.AddWithValue("@MaChungTuPC", maChungTuPC);
                    cm.Parameters.AddWithValue("@userID", ERP_Library.Security.CurrentUser.Info.UserID);
                    cm.Parameters.AddWithValue("@MaCongTy", ERP_Library.Security.CurrentUser.Info.MaCongTy);
                    SqlParameter prmGiaTriTraVe = new SqlParameter("@ketqua", SqlDbType.Bit);
                    prmGiaTriTraVe.Direction = ParameterDirection.Output;
                    cm.Parameters.Add(prmGiaTriTraVe);
                    cm.ExecuteNonQuery();
                    result = (bool)prmGiaTriTraVe.Value;

                    cm.ExecuteNonQuery();
                }
            }
            //using
            return result;
        }

        public static decimal GetTienThueConLai(long maPhieuChi, long maPhieuThu)
        {
            decimal Result = 0;
            try
            {
                using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
                {
                    cn.Open();
                    using (SqlCommand cm = cn.CreateCommand())
                    {
                        cm.CommandType = CommandType.StoredProcedure;
                        cm.CommandText = "spd_GetTienThueConLaicuaPhieuChi";
                        cm.Parameters.AddWithValue("@MaPhieuChi", maPhieuChi);
                        cm.Parameters.AddWithValue("@MaPhieuThu", maPhieuThu);
                        SqlParameter prmGiaTriTraVe = new SqlParameter("@result", SqlDbType.Decimal,18);
                        prmGiaTriTraVe.Precision = 18;
                        prmGiaTriTraVe.Scale = 3;
                        prmGiaTriTraVe.Direction = ParameterDirection.Output;
                        cm.Parameters.Add(prmGiaTriTraVe);
                        cm.ExecuteNonQuery();
                        Result =(decimal) prmGiaTriTraVe.Value;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Result;
        }
        
        
        
    }
}
