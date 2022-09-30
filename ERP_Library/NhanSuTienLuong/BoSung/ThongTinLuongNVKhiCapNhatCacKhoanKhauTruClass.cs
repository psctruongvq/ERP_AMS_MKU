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
    public class ThongTinLuongNVKhiCapNhatCacKhoanKhauTruClass
    {
        // Fields...
        [DisplayName("STT")]
        public int SoTT { get; set; }

        public long MaNhanVien { get; set; }

        [DisplayName("Mã nhân viên")]
        public string MaQLNhanVien { get; set; }

        [DisplayName("Họ và tên")]
        public string TenNhanVien { get; set; }

        public int MaBoPhan { get; set; }

        [DisplayName("Mã BP")]
        public string MaBoPhanQL { get; set; }

        [DisplayName("Mã ngạch lương")]
        public string MaNgachLuong { get; set; }

        [DisplayName("Hệ số lương")]
        public decimal HeSoLuong { get; set; }

        [DisplayName("Hệ số phụ cấp")]
        public decimal HeSoPhuCap { get; set; }

        [DisplayName("Hệ số vượt khung")]
        public decimal HeSoVuotKhung { get; set; }

        [DisplayName("Cộng hệ số")]
        public decimal CongHeSo { get; set; }

        [DisplayName("% nhận")]
        public decimal PhanTramNhan { get; set; }

        [DisplayName("Tiền lương")]
        public decimal TienLuong { get; set; }

        [DisplayName("Thưc lãnh")]
        public decimal ThucLanh { get; set; }

        [DisplayName("Thực lãnh sau thuế")]
        public decimal ThucLanhSauThue { get; set; }

        [DisplayName("Lương cơ bản NN")]
        public decimal LuongCoBanNN { get; set; }

        [DisplayName("Trừ 1 ngày lương")]
        public decimal Tru1NgayLuong { get; set; }

        [DisplayName("Thu tiền BHXH truy lương trước hạn")]
        public decimal ThuTienBHXHTruyLuongTruocHan { get; set; }

        [DisplayName("Tổng tiền lương từ nguồn phụ cấp cải cách tiền lương")]
        public decimal TongTienLuongTuNguonPCCaiCachTienLuong { get; set; }

        [DisplayName("Số tiền còn lại")]
        public decimal SoTienConLai { get; set; }

        [DisplayName("Tình trạng NV")]
        public byte TinhTrangNV { get; set; }

        [DisplayName("BHXH trả")]
        public decimal BHXH_Luong { get; set; }

        [DisplayName("Lương cơ bản mới")]
        public decimal LuongCoBanMoi { get; set; }

        [DisplayName("Hệ số bảo hiểm")]
        public decimal HeSoBaoHiem { get; set; }

        [DisplayName("Hệ số vượt khung BH")]
        public decimal HeSoVuotKhungBH { get; set; }

        [DisplayName("Truy thu BHXH")]
        public decimal TruyThuBHXH { get; set; }

        [DisplayName("Truy thu BHYT")]
        public decimal TruyThuBHYT { get; set; }

        [DisplayName("Truy thu BHTN")]
        public decimal TruyThuBHTN { get; set; }

        public ThongTinLuongNVKhiCapNhatCacKhoanKhauTruClass
            (int stt, long maNhanVien, string maqlNhanVien, string tenNV, int maBoPhan, string mabophanQL
            , string maNgachLuong, decimal heSoLuong, decimal hesophucap, decimal hesovuotkhung
            , decimal congheso, decimal phantramnhan, decimal tienluong
            , decimal thuclanh, decimal thuclanhsauthue, decimal luongcobanNN
            , decimal tru1NgayLuong
            , decimal thutienBHXH, decimal tienluongtunguonPC, decimal sotienconlai)
        {
            this.SoTT = stt;
            this.MaNhanVien = maNhanVien;
            this.MaQLNhanVien = maqlNhanVien;
            this.TenNhanVien = tenNV;
            this.MaBoPhan = maBoPhan;
            this.MaBoPhanQL = mabophanQL;
            this.MaNgachLuong = maNgachLuong;
            this.HeSoLuong = heSoLuong;
            this.HeSoPhuCap = hesophucap;
            this.HeSoVuotKhung = hesovuotkhung;
            this.CongHeSo = congheso;
            this.PhanTramNhan = phantramnhan;
            this.TienLuong = tienluong;
            this.ThucLanh = thuclanh;
            this.ThucLanhSauThue = thuclanhsauthue;
            this.Tru1NgayLuong = tru1NgayLuong;
            this.ThuTienBHXHTruyLuongTruocHan = thutienBHXH;
            this.TongTienLuongTuNguonPCCaiCachTienLuong = tienluongtunguonPC;
            this.SoTienConLai = sotienconlai;
            this.LuongCoBanNN = luongcobanNN;
        }

        public ThongTinLuongNVKhiCapNhatCacKhoanKhauTruClass
            (int stt, long maNhanVien, string maqlNhanVien, string tenNV, int maBoPhan, string mabophanQL
            , string maNgachLuong, decimal heSoLuong, decimal hesophucap, decimal hesovuotkhung
            , decimal congheso, decimal phantramnhan, decimal tienluong
            , decimal thuclanh, decimal thuclanhsauthue, decimal luongcobanNN
            , decimal tru1NgayLuong
            , decimal thutienBHXH, decimal tienluongtunguonPC, decimal sotienconlai
            , byte tinhtrangNV
            , decimal bhxh_Luong
            , decimal luongcobanMoi

            )
        {
            this.SoTT = stt;
            this.MaNhanVien = maNhanVien;
            this.MaQLNhanVien = maqlNhanVien;
            this.TenNhanVien = tenNV;
            this.MaBoPhan = maBoPhan;
            this.MaBoPhanQL = mabophanQL;
            this.MaNgachLuong = maNgachLuong;
            this.HeSoLuong = heSoLuong;
            this.HeSoPhuCap = hesophucap;
            this.HeSoVuotKhung = hesovuotkhung;
            this.CongHeSo = congheso;
            this.PhanTramNhan = phantramnhan;
            this.TienLuong = tienluong;
            this.ThucLanh = thuclanh;
            this.ThucLanhSauThue = thuclanhsauthue;
            this.Tru1NgayLuong = tru1NgayLuong;
            this.ThuTienBHXHTruyLuongTruocHan = thutienBHXH;
            this.TongTienLuongTuNguonPCCaiCachTienLuong = tienluongtunguonPC;
            this.SoTienConLai = sotienconlai;
            this.LuongCoBanNN = luongcobanNN;
            this.TinhTrangNV = tinhtrangNV;
            this.BHXH_Luong = bhxh_Luong;
            this.LuongCoBanMoi = luongcobanMoi;
        }

        public ThongTinLuongNVKhiCapNhatCacKhoanKhauTruClass
            (int stt, long maNhanVien, string maqlNhanVien, string tenNV, int maBoPhan, string mabophanQL
            , string maNgachLuong, decimal heSoLuong, decimal hesophucap, decimal hesovuotkhung
            , decimal congheso, decimal phantramnhan, decimal tienluong
            , decimal thuclanh, decimal thuclanhsauthue, decimal luongcobanNN
            , decimal tru1NgayLuong
            , decimal thutienBHXH, decimal tienluongtunguonPC, decimal sotienconlai
            , byte tinhtrangNV
            , decimal bhxh_Luong
            , decimal luongcobanMoi
            , decimal hesobaohiem
            , decimal hesovuotkhungBH
            , decimal truythuBHXH, decimal truythuBHYT, decimal truythuBHTN
            )
        {
            this.SoTT = stt;
            this.MaNhanVien = maNhanVien;
            this.MaQLNhanVien = maqlNhanVien;
            this.TenNhanVien = tenNV;
            this.MaBoPhan = maBoPhan;
            this.MaBoPhanQL = mabophanQL;
            this.MaNgachLuong = maNgachLuong;
            this.HeSoLuong = heSoLuong;
            this.HeSoPhuCap = hesophucap;
            this.HeSoVuotKhung = hesovuotkhung;
            this.CongHeSo = congheso;
            this.PhanTramNhan = phantramnhan;
            this.TienLuong = tienluong;
            this.ThucLanh = thuclanh;
            this.ThucLanhSauThue = thuclanhsauthue;
            this.Tru1NgayLuong = tru1NgayLuong;
            this.ThuTienBHXHTruyLuongTruocHan = thutienBHXH;
            this.TongTienLuongTuNguonPCCaiCachTienLuong = tienluongtunguonPC;
            this.SoTienConLai = sotienconlai;
            this.LuongCoBanNN = luongcobanNN;
            this.TinhTrangNV = tinhtrangNV;
            this.BHXH_Luong = bhxh_Luong;
            this.LuongCoBanMoi = luongcobanMoi;
            this.HeSoBaoHiem = hesobaohiem;
            this.HeSoVuotKhungBH = hesovuotkhungBH;
            this.TruyThuBHXH = truythuBHXH;
            this.TruyThuBHYT = truythuBHYT;
            this.TruyThuBHTN = truythuBHTN;

        }

        public static List<ThongTinLuongNVKhiCapNhatCacKhoanKhauTruClass> CreatThongTinLuongNVKhiCapNhatCacKhoanKhauTruClass(int maKyTinhLuong, int mabophan)
        {
            List<ThongTinLuongNVKhiCapNhatCacKhoanKhauTruClass> listResult = new List<ThongTinLuongNVKhiCapNhatCacKhoanKhauTruClass>();
            //listResult.Add(new ThongTinLuongNVKhiCapNhatCacKhoanKhauTruClass("<Không chọn>"));
            try
            {
                using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
                {
                    cn.Open();
                    using (SqlCommand cm = cn.CreateCommand())
                    {
                        cm.CommandType = CommandType.StoredProcedure;
                        cm.CommandText = "spd_ThongTinLuongNVKForCapNhatCacKhoanKhauTru";
                        cm.Parameters.AddWithValue("@MaKyTinhLuong", maKyTinhLuong);
                        cm.Parameters.AddWithValue("@MaBoPhan", mabophan);
                        cm.Parameters.AddWithValue("@UserID", ERP_Library.Security.CurrentUser.Info.UserID);
                        using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                        {
                            int stt; long maNhanVien; string maQLNhanVien; string tenNV; int maBoPhan;
                            string mabophanQL; string maNgachLuong; decimal heSoLuong; decimal hesophucap;
                            decimal hesovuotkhung; decimal congheso; decimal phantramnhan;
                            decimal tienluong; decimal thuclanh; decimal thuclanhsauthue; decimal luongcobanNN;
                            decimal tru1NgayLuong; decimal thutienBHXH;
                            decimal tienluongtunguonPC; decimal sotienconlai;
                            while (dr.Read())
                            {
                                stt = dr.GetInt32("STT");
                                maNhanVien = dr.GetInt64("MaNhanVien");
                                maQLNhanVien = dr.GetString("MaQLNhanVien");
                                tenNV = dr.GetString("TenNhanVien");
                                maBoPhan = dr.GetInt32("MaBoPhan");
                                mabophanQL = dr.GetString("MaBoPhanQL");
                                maNgachLuong = dr.GetString("MaNgachLuong");
                                heSoLuong = dr.GetDecimal("HeSoLuong");
                                hesophucap = dr.GetDecimal("HeSoPhuCap");
                                hesovuotkhung = dr.GetDecimal("HeSoVuotKhung");
                                congheso = dr.GetDecimal("CongHeSo");
                                phantramnhan = dr.GetDecimal("PhanTramNhan");
                                tienluong = dr.GetDecimal("TienLuong");
                                thuclanh = dr.GetDecimal("ThucLanh");
                                thuclanhsauthue = dr.GetDecimal("ThucLanhSauThue");
                                luongcobanNN = dr.GetDecimal("LuongCoBanNN");
                                tru1NgayLuong = dr.GetDecimal("Tru1NgayLuong");
                                thutienBHXH = dr.GetDecimal("ThuTienBHXHTruyLuongTruocHan");
                                tienluongtunguonPC = dr.GetDecimal("TongTienLuongTuNguonPCCaiCachTienLuong");
                                sotienconlai = dr.GetDecimal("SoTienConLai");
                                listResult.Add(new ThongTinLuongNVKhiCapNhatCacKhoanKhauTruClass(stt, maNhanVien, maQLNhanVien, tenNV, maBoPhan, mabophanQL, maNgachLuong, heSoLuong, hesophucap, hesovuotkhung, congheso, phantramnhan, tienluong, thuclanh, thuclanhsauthue, luongcobanNN, tru1NgayLuong, thutienBHXH, tienluongtunguonPC, sotienconlai));
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

        public static void InsertKTLintoBangLuongPhuCap(int maKyTinhLuong, List<ThongTinLuongNVKhiCapNhatCacKhoanKhauTruClass> listnhanvien
            , int maloaiPC, byte loai, DateTime ngayLap, int SoNgayKT)
        {
            SqlTransaction tr;

            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();

                tr = cn.BeginTransaction();
                decimal phucap = 0;

                try
                {
                    foreach (ThongTinLuongNVKhiCapNhatCacKhoanKhauTruClass ttl in listnhanvien)
                    {
                        phucap = 0;
                        if (loai == 1 || loai==4)
                        {
                            phucap = ttl.Tru1NgayLuong;
                        }
                        else if (loai == 2)
                        {
                            phucap = ttl.ThuTienBHXHTruyLuongTruocHan;
                        }
                        else if (loai == 3)
                        {
                            phucap = ttl.TongTienLuongTuNguonPCCaiCachTienLuong;
                        }
                        using (SqlCommand cm = tr.Connection.CreateCommand())
                        {
                            cm.Transaction = tr;
                            cm.CommandType = CommandType.StoredProcedure;
                            cm.CommandText = "spd_Insert_PhuCapNhanVienForKhauTruLuong";
                            cm.Parameters.AddWithValue("@MaKyTinhLuong", maKyTinhLuong);
                            cm.Parameters.AddWithValue("@MaNhanVien", ttl.MaNhanVien);
                            cm.Parameters.AddWithValue("@MaLoaiPhuCap", maloaiPC);
                            cm.Parameters.AddWithValue("@PhuCap", phucap);
                            cm.Parameters.AddWithValue("@NgayLap", ngayLap);
                            cm.Parameters.AddWithValue("@SoNgayKT", SoNgayKT);
                            cm.Parameters.AddWithValue("@UserID", ERP_Library.Security.CurrentUser.Info.UserID);
                            cm.ExecuteNonQuery();
                        }
                    }//using


                    tr.Commit();
                }
                catch (Exception ex)
                {
                    tr.Rollback();
                    throw ex;
                }
            }//using
        }

        public static bool KiemTraDaLapDeNghiChuyenKhoanLuongKy1(int maKyTinhLuong, int maChiTiet,int loai)
        {
            bool result = false;
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_Select_KiemTraDaLapDeNghiChuyenKhoanLuongKy1";
                    cm.Parameters.AddWithValue("@MaKyTinhLuong", maKyTinhLuong);
                    cm.Parameters.AddWithValue("@MaChiTiet", maChiTiet);
                    cm.Parameters.AddWithValue("@Loai", loai);//--@Loai: 1: Truy thu BH; 2 Tru NgayLuong; 3 là truy lĩnh
                    cm.Parameters.AddWithValue("@UserID", ERP_Library.Security.CurrentUser.Info.UserID);
                    SqlParameter prmGiaTriTraVe = new SqlParameter("@result", SqlDbType.Bit);
                    prmGiaTriTraVe.Direction = ParameterDirection.Output;
                    cm.Parameters.Add(prmGiaTriTraVe);
                    cm.ExecuteNonQuery();
                    if (prmGiaTriTraVe.Value != null)
                        result = (bool)prmGiaTriTraVe.Value;
                }
            }//us
            return result;
        }

        public static bool CheckIsTruyLinhDoNangLuongCB(int maloaiPC)
        {
            bool result = false;
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_CheckIsTruyLinhDoNangLuongCB";
                    cm.Parameters.AddWithValue("@MaKLoaiPC", maloaiPC);
                    SqlParameter prmGiaTriTraVe = new SqlParameter("@result", SqlDbType.Bit);
                    prmGiaTriTraVe.Direction = ParameterDirection.Output;
                    cm.Parameters.Add(prmGiaTriTraVe);
                    cm.ExecuteNonQuery();
                    if (prmGiaTriTraVe.Value != null)
                        result = (bool)prmGiaTriTraVe.Value;
                }
            }//us
            return result;
        }

        public static bool CheckIsTruyThuDoNangLuongCB(int maloaiPC)
        {
            bool result = false;
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_CheckIsTruyThuDoNangLuongCB";
                    cm.Parameters.AddWithValue("@MaKLoaiPC", maloaiPC);
                    SqlParameter prmGiaTriTraVe = new SqlParameter("@result", SqlDbType.Bit);
                    prmGiaTriTraVe.Direction = ParameterDirection.Output;
                    cm.Parameters.Add(prmGiaTriTraVe);
                    cm.ExecuteNonQuery();
                    if (prmGiaTriTraVe.Value != null)
                        result = (bool)prmGiaTriTraVe.Value;
                }
            }//us
            return result;
        }

        public static bool KiemTraDaTruyThu_TruyLinh(int maKyPC, int maKyTinhLuong, int maloaiPC)
        {
            bool result = false;
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_KiemTraDaTruyThu_TruyLinh";
                    cm.Parameters.AddWithValue("@MaKyPC", maKyPC);
                    cm.Parameters.AddWithValue("@MaKyTinhLuong", maKyTinhLuong);
                    cm.Parameters.AddWithValue("@MaLoaiPC", maloaiPC);
                    cm.Parameters.AddWithValue("@UserID", ERP_Library.Security.CurrentUser.Info.UserID);
                    SqlParameter prmGiaTriTraVe = new SqlParameter("@result", SqlDbType.Bit);
                    prmGiaTriTraVe.Direction = ParameterDirection.Output;
                    cm.Parameters.Add(prmGiaTriTraVe);
                    cm.ExecuteNonQuery();
                    if (prmGiaTriTraVe.Value != null)
                        result = (bool)prmGiaTriTraVe.Value;
                }
            }//us
            return result;
        }

        public static decimal GetThucLanhSauThueOFNhanVien(int maKyTinhLuong, long maNhanVien)
        {
            decimal result = 0;
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_GetThucLanhSauThueOFNhanVien";
                    cm.Parameters.AddWithValue("@MaKyTinhLuong", maKyTinhLuong);
                    cm.Parameters.AddWithValue("@MaNhanVien", maNhanVien);
                    SqlParameter prmGiaTriTraVe = new SqlParameter("@result", SqlDbType.Decimal, 18);
                    prmGiaTriTraVe.Direction = ParameterDirection.Output;
                    cm.Parameters.Add(prmGiaTriTraVe);
                    cm.ExecuteNonQuery();
                    if (prmGiaTriTraVe.Value != null)
                        result = (decimal)prmGiaTriTraVe.Value;
                }
            }//us
            return result;
        }

        public static List<ThongTinLuongNVKhiCapNhatCacKhoanKhauTruClass> KiemTraMaQLNhanVienTonTai(string maQLnhanvien)
        {
            List<ThongTinLuongNVKhiCapNhatCacKhoanKhauTruClass> listResult = new List<ThongTinLuongNVKhiCapNhatCacKhoanKhauTruClass>();
            try
            {
                using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
                {
                    cn.Open();
                    using (SqlCommand cm = cn.CreateCommand())
                    {
                        cm.CommandType = CommandType.StoredProcedure;
                        cm.CommandText = "spd_KiemTraMaQLNhanVienTonTai";
                        cm.Parameters.AddWithValue("@MaQLNhanVien", maQLnhanvien);
                        using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                        {
                            int stt; long maNhanVien; string maQLNhanVien; string tenNV; int maBoPhan;
                            string mabophanQL; string maNgachLuong; decimal heSoLuong; decimal hesophucap;
                            decimal hesovuotkhung; decimal congheso; decimal phantramnhan;
                            decimal tienluong; decimal thuclanh; decimal thuclanhsauthue; decimal luongcobanNN;
                            decimal tru1NgayLuong; decimal thutienBHXH;
                            decimal tienluongtunguonPC; decimal sotienconlai;
                            while (dr.Read())
                            {
                                stt = dr.GetInt32("STT");
                                maNhanVien = dr.GetInt64("MaNhanVien");
                                maQLNhanVien = dr.GetString("MaQLNhanVien");
                                tenNV = dr.GetString("TenNhanVien");
                                maBoPhan = dr.GetInt32("MaBoPhan");
                                mabophanQL = dr.GetString("MaBoPhanQL");
                                maNgachLuong = dr.GetString("MaNgachLuong");
                                heSoLuong = dr.GetDecimal("HeSoLuong");
                                hesophucap = dr.GetDecimal("HeSoPhuCap");
                                hesovuotkhung = dr.GetDecimal("HeSoVuotKhung");
                                congheso = dr.GetDecimal("CongHeSo");
                                phantramnhan = dr.GetDecimal("PhanTramNhan");
                                tienluong = dr.GetDecimal("TienLuong");
                                thuclanh = dr.GetDecimal("ThucLanh");
                                thuclanhsauthue = dr.GetDecimal("ThucLanhSauThue");
                                luongcobanNN = dr.GetDecimal("LuongCoBanNN");
                                tru1NgayLuong = dr.GetDecimal("Tru1NgayLuong");
                                thutienBHXH = dr.GetDecimal("ThuTienBHXHTruyLuongTruocHan");
                                tienluongtunguonPC = dr.GetDecimal("TongTienLuongTuNguonPCCaiCachTienLuong");
                                sotienconlai = dr.GetDecimal("SoTienConLai");
                                listResult.Add(new ThongTinLuongNVKhiCapNhatCacKhoanKhauTruClass(stt, maNhanVien, maQLNhanVien, tenNV, maBoPhan, mabophanQL, maNgachLuong, heSoLuong, hesophucap, hesovuotkhung, congheso, phantramnhan, tienluong, thuclanh, thuclanhsauthue, luongcobanNN, tru1NgayLuong, thutienBHXH, tienluongtunguonPC, sotienconlai));
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

        public static List<ThongTinLuongNVKhiCapNhatCacKhoanKhauTruClass> TinhTruyThuDaoHiem(int maKyTinhLuong, int maBoPhanIP, int maKyTinhLuongThucThu)
        {
            List<ThongTinLuongNVKhiCapNhatCacKhoanKhauTruClass> listResult = new List<ThongTinLuongNVKhiCapNhatCacKhoanKhauTruClass>();
            try
            {
                using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
                {
                    cn.Open();
                    using (SqlCommand cm = cn.CreateCommand())
                    {
                        cm.CommandType = CommandType.StoredProcedure;
                        cm.CommandText = "spd_TinhTruyThuBaoHiem";
                        cm.Parameters.AddWithValue("@MaKyTinhLuong", maKyTinhLuong);
                        cm.Parameters.AddWithValue("@MaBoPhanIP", maBoPhanIP);
                        cm.Parameters.AddWithValue("@MaKyTinhLuongThucThu", maKyTinhLuongThucThu);
                        cm.Parameters.AddWithValue("@UserID", ERP_Library.Security.CurrentUser.Info.UserID);
                        using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                        {
                            int stt; long maNhanVien; string maQLNhanVien; string tenNV; int maBoPhan;
                            string mabophanQL; string maNgachLuong; decimal heSoLuong; decimal hesophucap;
                            decimal hesovuotkhung; decimal congheso; decimal phantramnhan;
                            decimal tienluong; decimal thuclanh; decimal thuclanhsauthue; decimal luongcobanNN;
                            decimal tru1NgayLuong; decimal thutienBHXH;
                            decimal tienluongtunguonPC; decimal sotienconlai;
                            byte tinhtrangNV; decimal bhxh_luong; decimal luongcobanMoi; decimal hesobaohiem; decimal hesovuotkhungBH;
                            decimal truythuBHXH; decimal truythuBHYT; decimal truythuBHTN;
                            while (dr.Read())
                            {
                                stt = dr.GetInt32("STT");
                                maNhanVien = dr.GetInt64("MaNhanVien");
                                maQLNhanVien = dr.GetString("MaQLNhanVien");
                                tenNV = dr.GetString("TenNhanVien");
                                maBoPhan = dr.GetInt32("MaBoPhan");
                                mabophanQL = dr.GetString("MaBoPhanQL");
                                maNgachLuong = dr.GetString("MaNgachLuong");
                                heSoLuong = dr.GetDecimal("HeSoLuong");
                                hesophucap = dr.GetDecimal("HeSoPhuCap");
                                hesovuotkhung = dr.GetDecimal("HeSoVuotKhung");
                                congheso = dr.GetDecimal("CongHeSo");
                                phantramnhan = dr.GetDecimal("PhanTramNhan");
                                tienluong = dr.GetDecimal("TienLuong");
                                thuclanh = dr.GetDecimal("ThucLanh");
                                thuclanhsauthue = dr.GetDecimal("ThucLanhSauThue");
                                luongcobanNN = dr.GetDecimal("LuongCoBanNN");
                                tru1NgayLuong = dr.GetDecimal("Tru1NgayLuong");
                                thutienBHXH = dr.GetDecimal("ThuTienBHXHTruyLuongTruocHan");
                                tienluongtunguonPC = dr.GetDecimal("TongTienLuongTuNguonPCCaiCachTienLuong");
                                sotienconlai = dr.GetDecimal("SoTienConLai");
                                tinhtrangNV = dr.GetByte("TinhTrangNV");
                                bhxh_luong = dr.GetDecimal("BHXH_Luong");
                                luongcobanMoi = dr.GetDecimal("LuongCoBanMoi");
                                hesobaohiem = dr.GetDecimal("HeSoBaoHiem");
                                hesovuotkhungBH = dr.GetDecimal("HeSoVuotKhungBH");

                                truythuBHXH = dr.GetDecimal("TruyThuBHXH");
                                truythuBHYT = dr.GetDecimal("TruyThuBHYT");
                                truythuBHTN = dr.GetDecimal("TruyThuBHTN");
                                listResult.Add(new ThongTinLuongNVKhiCapNhatCacKhoanKhauTruClass(stt, maNhanVien, maQLNhanVien, tenNV, maBoPhan, mabophanQL, maNgachLuong, heSoLuong, hesophucap, hesovuotkhung, congheso, phantramnhan, tienluong, thuclanh, thuclanhsauthue, luongcobanNN, tru1NgayLuong, thutienBHXH, tienluongtunguonPC, sotienconlai, tinhtrangNV, bhxh_luong, luongcobanMoi, hesobaohiem, hesovuotkhungBH, truythuBHXH, truythuBHYT, truythuBHTN));
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


        public static List<ThongTinLuongNVKhiCapNhatCacKhoanKhauTruClass> GetTruyThu(int maKyTinhLuong, int maBoPhanIP, int maKyTinhLuongThucThu, int maloaiPC)
        {
            List<ThongTinLuongNVKhiCapNhatCacKhoanKhauTruClass> listResult = new List<ThongTinLuongNVKhiCapNhatCacKhoanKhauTruClass>();
            try
            {
                using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
                {
                    cn.Open();
                    using (SqlCommand cm = cn.CreateCommand())
                    {
                        cm.CommandTimeout = 300;
                        cm.CommandType = CommandType.StoredProcedure;
                        cm.CommandTimeout = 600;
                        cm.CommandText = "spd_GetTruyThuFromBangLuongPhuCap";
                        cm.Parameters.AddWithValue("@MaKyTinhLuong", maKyTinhLuong);
                        cm.Parameters.AddWithValue("@MaBoPhanIP", maBoPhanIP);
                        cm.Parameters.AddWithValue("@MaKyTinhLuongThucThu", maKyTinhLuongThucThu);
                        cm.Parameters.AddWithValue("@MaLoaiPC", maloaiPC);
                        cm.Parameters.AddWithValue("@UserID", ERP_Library.Security.CurrentUser.Info.UserID);
                        using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                        {
                            int stt; long maNhanVien; string maQLNhanVien; string tenNV; int maBoPhan;
                            string mabophanQL; string maNgachLuong; decimal heSoLuong; decimal hesophucap;
                            decimal hesovuotkhung; decimal congheso; decimal phantramnhan;
                            decimal tienluong; decimal thuclanh; decimal thuclanhsauthue; decimal luongcobanNN;
                            decimal tru1NgayLuong; decimal thutienBHXH;
                            decimal tienluongtunguonPC; decimal sotienconlai;
                            byte tinhtrangNV; decimal bhxh_luong; decimal luongcobanMoi; decimal hesobaohiem; decimal hesovuotkhungBH;
                            decimal truythuBHXH; decimal truythuBHYT; decimal truythuBHTN;
                            while (dr.Read())
                            {
                                stt = dr.GetInt32("STT");
                                maNhanVien = dr.GetInt64("MaNhanVien");
                                maQLNhanVien = dr.GetString("MaQLNhanVien");
                                tenNV = dr.GetString("TenNhanVien");
                                maBoPhan = dr.GetInt32("MaBoPhan");
                                mabophanQL = dr.GetString("MaBoPhanQL");
                                maNgachLuong = dr.GetString("MaNgachLuong");
                                heSoLuong = dr.GetDecimal("HeSoLuong");
                                hesophucap = dr.GetDecimal("HeSoPhuCap");
                                hesovuotkhung = dr.GetDecimal("HeSoVuotKhung");
                                congheso = dr.GetDecimal("CongHeSo");
                                phantramnhan = dr.GetDecimal("PhanTramNhan");
                                tienluong = dr.GetDecimal("TienLuong");
                                thuclanh = dr.GetDecimal("ThucLanh");
                                thuclanhsauthue = dr.GetDecimal("ThucLanhSauThue");
                                luongcobanNN = dr.GetDecimal("LuongCoBanNN");
                                tru1NgayLuong = dr.GetDecimal("Tru1NgayLuong");
                                thutienBHXH = dr.GetDecimal("ThuTienBHXHTruyLuongTruocHan");
                                tienluongtunguonPC = dr.GetDecimal("TongTienLuongTuNguonPCCaiCachTienLuong");
                                sotienconlai = dr.GetDecimal("SoTienConLai");
                                tinhtrangNV = dr.GetByte("TinhTrangNV");
                                bhxh_luong = dr.GetDecimal("BHXH_Luong");
                                luongcobanMoi = dr.GetDecimal("LuongCoBanMoi");
                                hesobaohiem = dr.GetDecimal("HeSoBaoHiem");
                                hesovuotkhungBH = dr.GetDecimal("HeSoVuotKhungBH");

                                truythuBHXH = dr.GetDecimal("TruyThuBHXH");
                                truythuBHYT = dr.GetDecimal("TruyThuBHYT");
                                truythuBHTN = dr.GetDecimal("TruyThuBHTN");
                                listResult.Add(new ThongTinLuongNVKhiCapNhatCacKhoanKhauTruClass(stt, maNhanVien, maQLNhanVien, tenNV, maBoPhan, mabophanQL, maNgachLuong, heSoLuong, hesophucap, hesovuotkhung, congheso, phantramnhan, tienluong, thuclanh, thuclanhsauthue, luongcobanNN, tru1NgayLuong, thutienBHXH, tienluongtunguonPC, sotienconlai, tinhtrangNV, bhxh_luong, luongcobanMoi, hesobaohiem, hesovuotkhungBH, truythuBHXH, truythuBHYT, truythuBHTN));
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


        public static List<ThongTinLuongNVKhiCapNhatCacKhoanKhauTruClass> TinhTruyLinhNangLuongCoBan(int maKyTinhLuong, int maBoPhanIP)
        {
            List<ThongTinLuongNVKhiCapNhatCacKhoanKhauTruClass> listResult = new List<ThongTinLuongNVKhiCapNhatCacKhoanKhauTruClass>();
            try
            {
                using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
                {
                    cn.Open();
                    using (SqlCommand cm = cn.CreateCommand())
                    {
                        cm.CommandType = CommandType.StoredProcedure;
                        cm.CommandText = "spd_TinhTruyLinhNangLuongCoBan";
                        cm.Parameters.AddWithValue("@MaKyTinhLuong", maKyTinhLuong);
                        cm.Parameters.AddWithValue("@MaBoPhanIP", maBoPhanIP);
                        cm.Parameters.AddWithValue("@UserID", ERP_Library.Security.CurrentUser.Info.UserID);
                        using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                        {
                            int stt; long maNhanVien; string maQLNhanVien; string tenNV; int maBoPhan;
                            string mabophanQL; string maNgachLuong; decimal heSoLuong; decimal hesophucap;
                            decimal hesovuotkhung; decimal congheso; decimal phantramnhan;
                            decimal tienluong; decimal thuclanh; decimal thuclanhsauthue; decimal luongcobanNN;
                            decimal tru1NgayLuong; decimal thutienBHXH;
                            decimal tienluongtunguonPC; decimal sotienconlai;
                            byte tinhtrangNV; decimal bhxh_luong; decimal luongcobanMoi;
                            while (dr.Read())
                            {
                                stt = dr.GetInt32("STT");
                                maNhanVien = dr.GetInt64("MaNhanVien");
                                maQLNhanVien = dr.GetString("MaQLNhanVien");
                                tenNV = dr.GetString("TenNhanVien");
                                maBoPhan = dr.GetInt32("MaBoPhan");
                                mabophanQL = dr.GetString("MaBoPhanQL");
                                maNgachLuong = dr.GetString("MaNgachLuong");
                                heSoLuong = dr.GetDecimal("HeSoLuong");
                                hesophucap = dr.GetDecimal("HeSoPhuCap");
                                hesovuotkhung = dr.GetDecimal("HeSoVuotKhung");
                                congheso = dr.GetDecimal("CongHeSo");
                                phantramnhan = dr.GetDecimal("PhanTramNhan");
                                tienluong = dr.GetDecimal("TienLuong");
                                thuclanh = dr.GetDecimal("ThucLanh");
                                thuclanhsauthue = dr.GetDecimal("ThucLanhSauThue");
                                luongcobanNN = dr.GetDecimal("LuongCoBanNN");
                                tru1NgayLuong = dr.GetDecimal("Tru1NgayLuong");
                                thutienBHXH = dr.GetDecimal("ThuTienBHXHTruyLuongTruocHan");
                                tienluongtunguonPC = dr.GetDecimal("TongTienLuongTuNguonPCCaiCachTienLuong");
                                sotienconlai = dr.GetDecimal("SoTienConLai");
                                tinhtrangNV = dr.GetByte("TinhTrangNV");
                                bhxh_luong = dr.GetDecimal("BHXH_Luong");
                                luongcobanMoi = dr.GetDecimal("LuongCoBanMoi");
                                listResult.Add(new ThongTinLuongNVKhiCapNhatCacKhoanKhauTruClass(stt, maNhanVien, maQLNhanVien, tenNV, maBoPhan, mabophanQL, maNgachLuong, heSoLuong, hesophucap, hesovuotkhung, congheso, phantramnhan, tienluong, thuclanh, thuclanhsauthue, luongcobanNN, tru1NgayLuong, thutienBHXH, tienluongtunguonPC, sotienconlai, tinhtrangNV, bhxh_luong, luongcobanMoi));
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

        public static List<ThongTinLuongNVKhiCapNhatCacKhoanKhauTruClass> GetTruyLinh(int maKyTinhLuong, int maBoPhanIP, int maKyTinhLuongThucThu, int maloaiPC)
        {
            List<ThongTinLuongNVKhiCapNhatCacKhoanKhauTruClass> listResult = new List<ThongTinLuongNVKhiCapNhatCacKhoanKhauTruClass>();
            try
            {
                using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
                {
                    cn.Open();
                    using (SqlCommand cm = cn.CreateCommand())
                    {
                        cm.CommandType = CommandType.StoredProcedure;
                        cm.CommandText = "spd_GetTruyLinhFromBangLuongPhuCap";
                        cm.Parameters.AddWithValue("@MaKyTinhLuong", maKyTinhLuong);
                        cm.Parameters.AddWithValue("@MaBoPhanIP", maBoPhanIP);
                        cm.Parameters.AddWithValue("@MaKyTinhLuongThucThu", maKyTinhLuongThucThu);
                        cm.Parameters.AddWithValue("@MaLoaiPC", maloaiPC);
                        cm.Parameters.AddWithValue("@UserID", ERP_Library.Security.CurrentUser.Info.UserID);
                        using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                        {
                            int stt; long maNhanVien; string maQLNhanVien; string tenNV; int maBoPhan;
                            string mabophanQL; string maNgachLuong; decimal heSoLuong; decimal hesophucap;
                            decimal hesovuotkhung; decimal congheso; decimal phantramnhan;
                            decimal tienluong; decimal thuclanh; decimal thuclanhsauthue; decimal luongcobanNN;
                            decimal tru1NgayLuong; decimal thutienBHXH;
                            decimal tienluongtunguonPC; decimal sotienconlai;
                            byte tinhtrangNV; decimal bhxh_luong; decimal luongcobanMoi;
                            while (dr.Read())
                            {
                                stt = dr.GetInt32("STT");
                                maNhanVien = dr.GetInt64("MaNhanVien");
                                maQLNhanVien = dr.GetString("MaQLNhanVien");
                                tenNV = dr.GetString("TenNhanVien");
                                maBoPhan = dr.GetInt32("MaBoPhan");
                                mabophanQL = dr.GetString("MaBoPhanQL");
                                maNgachLuong = dr.GetString("MaNgachLuong");
                                heSoLuong = dr.GetDecimal("HeSoLuong");
                                hesophucap = dr.GetDecimal("HeSoPhuCap");
                                hesovuotkhung = dr.GetDecimal("HeSoVuotKhung");
                                congheso = dr.GetDecimal("CongHeSo");
                                phantramnhan = dr.GetDecimal("PhanTramNhan");
                                tienluong = dr.GetDecimal("TienLuong");
                                thuclanh = dr.GetDecimal("ThucLanh");
                                thuclanhsauthue = dr.GetDecimal("ThucLanhSauThue");
                                luongcobanNN = dr.GetDecimal("LuongCoBanNN");
                                tru1NgayLuong = dr.GetDecimal("Tru1NgayLuong");
                                thutienBHXH = dr.GetDecimal("ThuTienBHXHTruyLuongTruocHan");
                                tienluongtunguonPC = dr.GetDecimal("TongTienLuongTuNguonPCCaiCachTienLuong");
                                sotienconlai = dr.GetDecimal("SoTienConLai");
                                tinhtrangNV = dr.GetByte("TinhTrangNV");
                                bhxh_luong = dr.GetDecimal("BHXH_Luong");
                                luongcobanMoi = dr.GetDecimal("LuongCoBanMoi");
                                listResult.Add(new ThongTinLuongNVKhiCapNhatCacKhoanKhauTruClass(stt, maNhanVien, maQLNhanVien, tenNV, maBoPhan, mabophanQL, maNgachLuong, heSoLuong, hesophucap, hesovuotkhung, congheso, phantramnhan, tienluong, thuclanh, thuclanhsauthue, luongcobanNN, tru1NgayLuong, thutienBHXH, tienluongtunguonPC, sotienconlai, tinhtrangNV, bhxh_luong, luongcobanMoi));
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

        public static List<ThongTinLuongNVKhiCapNhatCacKhoanKhauTruClass> NhanVienChuaTruyThuList(int maKyTinhLuong, int maKyPC, int maLoaiPC, byte loai)
        {//@Loai: 1: Truy thu BH; 2 Tru NgayLuong
            List<ThongTinLuongNVKhiCapNhatCacKhoanKhauTruClass> listResult = new List<ThongTinLuongNVKhiCapNhatCacKhoanKhauTruClass>();
            try
            {
                using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
                {
                    cn.Open();
                    using (SqlCommand cm = cn.CreateCommand())
                    {
                        cm.CommandType = CommandType.StoredProcedure;
                        cm.CommandText = "spd_DSNhanVienChuaTruyThu";
                        cm.Parameters.AddWithValue("@MaKyTinhLuong", maKyTinhLuong);
                        cm.Parameters.AddWithValue("@MaKyPC", maKyPC);
                        cm.Parameters.AddWithValue("@MaLoaiPC", maLoaiPC);
                        cm.Parameters.AddWithValue("@Loai", loai);
                        cm.Parameters.AddWithValue("@UserID", ERP_Library.Security.CurrentUser.Info.UserID);
                        using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                        {
                            int stt; long maNhanVien; string maQLNhanVien; string tenNV; int maBoPhan;
                            string mabophanQL; string maNgachLuong; decimal heSoLuong; decimal hesophucap;
                            decimal hesovuotkhung; decimal congheso; decimal phantramnhan;
                            decimal tienluong; decimal thuclanh; decimal thuclanhsauthue; decimal luongcobanNN;
                            decimal tru1NgayLuong; decimal thutienBHXH;
                            decimal tienluongtunguonPC; decimal sotienconlai;

                            byte tinhtrangNV; decimal bhxh_luong; decimal luongcobanMoi; decimal hesobaohiem; decimal hesovuotkhungBH;
                            decimal truythuBHXH; decimal truythuBHYT; decimal truythuBHTN;
                            while (dr.Read())
                            {
                                stt = dr.GetInt32("STT");
                                maNhanVien = dr.GetInt64("MaNhanVien");
                                maQLNhanVien = dr.GetString("MaQLNhanVien");
                                tenNV = dr.GetString("TenNhanVien");
                                maBoPhan = dr.GetInt32("MaBoPhan");
                                mabophanQL = dr.GetString("MaBoPhanQL");
                                maNgachLuong = dr.GetString("MaNgachLuong");
                                heSoLuong = dr.GetDecimal("HeSoLuong");
                                hesophucap = dr.GetDecimal("HeSoPhuCap");
                                hesovuotkhung = dr.GetDecimal("HeSoVuotKhung");
                                congheso = dr.GetDecimal("CongHeSo");
                                phantramnhan = dr.GetDecimal("PhanTramNhan");
                                tienluong = dr.GetDecimal("TienLuong");
                                thuclanh = dr.GetDecimal("ThucLanh");
                                thuclanhsauthue = dr.GetDecimal("ThucLanhSauThue");
                                luongcobanNN = dr.GetDecimal("LuongCoBanNN");
                                tru1NgayLuong = dr.GetDecimal("Tru1NgayLuong");
                                thutienBHXH = dr.GetDecimal("ThuTienBHXHTruyLuongTruocHan");
                                tienluongtunguonPC = dr.GetDecimal("TongTienLuongTuNguonPCCaiCachTienLuong");
                                sotienconlai = dr.GetDecimal("SoTienConLai");

                                if (loai == 1)
                                {
                                    tinhtrangNV = dr.GetByte("TinhTrangNV");
                                    bhxh_luong = dr.GetDecimal("BHXH_Luong");
                                    luongcobanMoi = dr.GetDecimal("LuongCoBanMoi");
                                    hesobaohiem = dr.GetDecimal("HeSoBaoHiem");
                                    hesovuotkhungBH = dr.GetDecimal("HeSoVuotKhungBH");

                                    truythuBHXH = dr.GetDecimal("TruyThuBHXH");
                                    truythuBHYT = dr.GetDecimal("TruyThuBHYT");
                                    truythuBHTN = dr.GetDecimal("TruyThuBHTN");
                                    listResult.Add(new ThongTinLuongNVKhiCapNhatCacKhoanKhauTruClass(stt, maNhanVien, maQLNhanVien, tenNV, maBoPhan, mabophanQL, maNgachLuong, heSoLuong, hesophucap, hesovuotkhung, congheso, phantramnhan, tienluong, thuclanh, thuclanhsauthue, luongcobanNN, tru1NgayLuong, thutienBHXH, tienluongtunguonPC, sotienconlai, tinhtrangNV, bhxh_luong, luongcobanMoi, hesobaohiem, hesovuotkhungBH, truythuBHXH, truythuBHYT, truythuBHTN));
                                }
                                else
                                    listResult.Add(new ThongTinLuongNVKhiCapNhatCacKhoanKhauTruClass(stt, maNhanVien, maQLNhanVien, tenNV, maBoPhan, mabophanQL, maNgachLuong, heSoLuong, hesophucap, hesovuotkhung, congheso, phantramnhan, tienluong, thuclanh, thuclanhsauthue, luongcobanNN, tru1NgayLuong, thutienBHXH, tienluongtunguonPC, sotienconlai));
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

    }
}
