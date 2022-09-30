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
    public class CCDCHienOPhongBan
    {
        // Fields...

        [DisplayName("Chọn")]
        public bool Check { get; set; }

        public int MaCCDC { get; set; }

        [DisplayName("Mã CCDC")]
        public string MaQLCCDC { get; set; }

        [DisplayName("Số Serial")]
        public string SoSerial { get; set; }

        [DisplayName("Tên CCDC")]
        public string TenCCDC { get; set; }

        public int MaBoPhan { get; set; }

        [DisplayName("Tên Bộ Phận")]
        public string TenBoPhan { get; set; }

        [DisplayName("Nguyên Giá")]
        public decimal NguyenGia { get; set; }

        [DisplayName("Ngày nhận")]
        public DateTime NgayNhan { get; set; }

        [DisplayName("SoChungTu")]
        public string SoChungTu { get; set; }

        [DisplayName("Năm BĐ hoạt động")]
        public int NamHoatDong { get; set; }




        public CCDCHienOPhongBan(int maccdc,string maqlccdc,string soserial, string tenccdc,int mabophan, string tenbophan, decimal nguyengia ,DateTime ngaynhan,int namhoatdong, string sochungtu)
        {
            this.Check = false;
            this.MaCCDC = maccdc;
            this.MaQLCCDC = maqlccdc;
            this.SoSerial = soserial;
            this.TenCCDC = tenccdc;
            this.MaBoPhan = mabophan;
            this.TenBoPhan = tenbophan;
            this.NguyenGia = nguyengia;
            this.NgayNhan = ngaynhan;
            this.SoChungTu = sochungtu;
            this.NamHoatDong = namhoatdong;
            
        }


        public static List<CCDCHienOPhongBan> CreatCCDCHienOPhongBanList(int mabophanIP, int mahanghoaIP,DateTime denNgay)
        {
            int maccdc; string maqlccdc; string soserial; string tenccdc; int mabophan; string tenbophan; decimal nguyengia;
            DateTime ngaynhan; string sochungtu;
            int namhoatdong;
            List<CCDCHienOPhongBan> listResult = new List<CCDCHienOPhongBan>();
            //listResult.Add(new CCDCHienOPhongBan("<Không chọn>"));
            try
            {
                using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
                {
                    cn.Open();
                    using (SqlCommand cm = cn.CreateCommand())
                    {
                        cm.CommandType = CommandType.StoredProcedure;
                        cm.CommandText = "spd_GetCongCuDungCuListHienDangOPhongBan";
                        cm.Parameters.AddWithValue("@MaBoPhanIP", mabophanIP);
                        cm.Parameters.AddWithValue("@MaHangHoaIP", mahanghoaIP);
                        cm.Parameters.AddWithValue("@DenNgay", denNgay);
                        using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                        {
                            while (dr.Read())
                            {
                                maccdc = dr.GetInt32("MaCCDC");
                                maqlccdc = dr.GetString("MaQLCCDC");
                                soserial = dr.GetString("SoSerial");
                                tenccdc = dr.GetString("TenCCDC");
                                mabophan = dr.GetInt32("MaBoPhan");
                                tenbophan=dr.GetString("TenBoPhan");
                                nguyengia = dr.GetDecimal("NguyenGia");
                                ngaynhan = dr.GetDateTime("NgayNhan");
                                namhoatdong = dr.GetInt32("NamHoatDong");
                                sochungtu = dr.GetString("SoChungTu");

                                listResult.Add(new CCDCHienOPhongBan(maccdc,maqlccdc,soserial,tenccdc,mabophan,tenbophan,nguyengia,ngaynhan,namhoatdong,sochungtu));
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
