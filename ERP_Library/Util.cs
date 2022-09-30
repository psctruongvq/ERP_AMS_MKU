

using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

namespace ERP_Library
{
    [Serializable()]
    public class Util
    {
        #region Khai Báo
        public string thongbao = UtilText.thongbao;
        public string thaoTac = UtilText.thaoTac;
        public string thanhcong =  UtilText.thanhcong;
        public string thatbai =  UtilText.thatbai;
        public string coloiphatsinh =  UtilText.coloiphatsinh;
        public string nhapmaloaikinh =  UtilText.nhapmaloaikinh;
        public string xoadong =  UtilText.xoadong;
        public string xoacacdong =  UtilText.xoacacdong;
        public string dongyxoacacdong =  UtilText.dongyxoacacdong;
        public string dongyxoa =  UtilText.dongyxoa;
        public string dongnaykhong =  UtilText.dongnaykhong;
        public string chodongcanxoa =  UtilText.chodongcanxoa;
        public string nhapmanhanvien =  UtilText.nhapmanhanvien;
        public string nhapdienthoai =  UtilText.nhapdienthoai;
        public string nhapsoluong =  UtilText.nhapsoluong;
        public string nhapmaphieu =  UtilText.nhapmaphieu;
        public string ngaylon =  UtilText.ngaylon;
        public string emailkhonghople = UtilText.emailkhonghople;
        public string nhaptennhanvien = UtilText.nhaptennhanvien;
        public string khongcodulieu = UtilText.khongcodulieu;
        public string phieunaykhongduocsua= UtilText.phieunaykhongduocsua;
        public string luudulieu = UtilText.luudulieu;
        public string soluongtranhohonsoluongxuat = UtilText.soluongtranhohonsoluongxuat;
        public string nhapgiaban= UtilText.nhapgiaban;
        public string khongcoquyensua = UtilText.Khongcoquyensuabaocao;
        public string nhaptaptincansaoluu = UtilText.nhaptaptincansaoluu;
        public string chonduongdancansaoluu = UtilText.chonduongdancansaoluu;
        public string saoluuthanhcong= UtilText.saoluuthanhcong;
        public string saoluuthatbai = UtilText.saoluuthatbai;
        public string chuanhapduongdan  = UtilText.chuanhapduongdan;
        public string phuhoithanhcong = UtilText.phuchoithanhcong;
        public string chonduongdancanphuchoi = UtilText.chonduongdancanphuchoi;
        public string saimatkhau = UtilText.saimatkhau;
        public string khongtimthaytennguoidung  = UtilText.khongtimthaytennguoidung;
        public string loidangnhap = UtilText.loidangnhap;
        public string matkhaukhonghople = UtilText.matkhaukhonghople;
        public string khongtruycapduocdulieu = UtilText.khongtruycapduocdulieu;
        public string dangnhapthanhcong = UtilText.dangnhapthanhcong;
        public string dangnhaphethong = UtilText.dangnhaphethong;
        public string chuanhapdulieucantim = UtilText.chuanhapdulieucantim;
        public string nhapmakhachhang = UtilText.nhapmakhachhang;
        public string nhaptenkhachhang = UtilText.nhaptenkhachhang;
        public string nhapmanhacungcap = UtilText.nhapmanhacungcap;
        public string nhaptennhacungcap = UtilText.nhaptennhacungcap;
        public string chonnhomkhachhang = UtilText.chonnhomkhachhang;
        public string mabitrung = UtilText.mabitrung;
        public string luuthanhcong = UtilText.luuthanhcong;
        public string luuthatbai = UtilText.luuthatbai;
        public string nhapsosotk = UtilText.nhapsosotk;
        public string sosobitrung = UtilText.sosobitrung;
        public string chuachonngay = UtilText.chuachonngay;
        public string ngaycantimkhonghople = UtilText.ngaycantimkhonghople;
        public string sohopdongbitrung = UtilText.sohopdongbitrung;
        public string sophieubitrung = UtilText.sophieubitrung;
        public string chuanhapsophieu = UtilText.chuanhapsophieu;
        public string thoigiancamkhonghople = UtilText.thoigiancamkhonghople;
        public string chuachonmanhanvien = UtilText.chuachonmanhanvien;
        public string sobienbanbitrung = UtilText.sobienbanbitrung;
        public string chuachonduthongtin = UtilText.chuachonduthongtin;
        public string chuachonnhanviencantaolich = UtilText.chuachonnhanviencantaolich;
        
        //Trang lam
        public string vuilongchonngachluong = UtilText.vuilongchongachluongcoban;
        public string vuilongnhaphesoluong = UtilText.vuilongnhaphesoluong;
        public string vuilongnhapbacluong = UtilText.vuilongnhapbacluong;
        public string vuilongnhapthoigiannangbac = UtilText.vuilongnhapthoigiannangbac;
        public string vuilongnhapdonvithoigian = UtilText.vuilongnhapdonvithoigian;
        public string vuilongchonhesodieuchinhnhan = UtilText.vuilongchonhesodieuchinhnhan;
        public string vuilongnhapma = UtilText.vuilongnhapma;
        public string vuilongnhaptenloaiphucap = UtilText.vuilongnhaptenloaiphucap;
        public string vuilongchoncongthuctinh = UtilText.vuilongchoncongthuctinh;
        public string vuilongnhaptenloaiphucaptx = UtilText.vuilongnhaptenloaiphucaptx;
        public string vuilongchonthang = UtilText.vuilongchonthang;
        public string vuilongchonnam = UtilText.vuilongchonnam;
        public string vuilongnhaptongtien = UtilText.vuilongnhaptongtien;
        public string vuilongnhaphesophucap = UtilText.vuilongnhaphesophucap;
        public string vuilongnhapngaytrichnop = UtilText.vuilongnhapngaytrichnop;
        public string vuilongnhapmatrichnop = UtilText.vuilongnhapmatrichnop;
        public string nhapsodonhang = UtilText.nhapsodonhang;
        public string sodonhangkohople = UtilText.sodonhangkohople;
        public string random = UtilText.random;
        public string KhongChoRanDom = UtilText.KhongChoRanDom;
        public string nhaptenky = UtilText.tenky;
        public string nhapnam = UtilText.nhapnam;
        public string nhapthang = UtilText.nhapthang;
        public string nhapmaloaidieuchinhluong = UtilText.nhapmaloaidieuchinhluong;
        public string nhaptenloaidieuchinhluong = UtilText.nhaptenloaidieuchinhluong;
        public string nhapmucthuetoithieu = UtilText.nhapmucthuetoithieu;
        public string nhapmucthuetoida = UtilText.nhapmucthuetoida;
        public string nhapphantramthuethunhap = UtilText.nhapphantramthuethunhap;
        public string sohoadon = UtilText.sohoadon;
        public string soserial = UtilText.soserial;
        public string chonNhomChucVu = UtilText.chonNhomChucVu;
        public string nhapMaHocHam = UtilText.nhapMaHocHam;
        public string nhapTenHocHam = UtilText.nhapTenHocHam;
        public string LoaiHopDong = UtilText.LoaiHopDong;
        public string SoHopDong = UtilText.SoHopDong;

        public string tes = string.Empty;
        #endregion

        #region kiểm tra địa chỉ Email
        public static Boolean KiemTraDiaChiEmail(string text)
        {
            string temp = @"^([a-zA-Z0-9_\-])([a-zA-Z0-9_\-\.]*)@(\[((25[0-5]|2[0-4][0-9]|1[0-9][0-9]|[1-9][0-9]|[0-9])\.){3}|((([a-zA-Z0-9\-]+)\.)+))([a-zA-Z]{2,}|(25[0-5]|2[0-4][0-9]|1[0-9][0-9]|[1-9][0-9]|[0-9])\])$";
            Regex regexTest = new Regex(temp);
            return regexTest.IsMatch(text);

        }
        #endregion

        #region đọc tiền
        
        public static string ReadMoney(string Money)
        {
            //kiểm tra xem chuỗi có hợp lệ không
            if (Money.Trim(new char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' }) != "")
                return "giá trị nhập vào không phải là số!!!.";

            string[] DonViCap0 = new string[] { "", " một", " hai", " ba", " bốn", " năm", " sáu", " bảy", " tám", " chín" };
            string[] DonViCap1 = new string[] { "", " mươi", " trăm" };
            string[] DonViCap2 = new string[] { "", " nghìn", " triệu", " tỷ" };

            //Thực hiện đảo chuỗi tiền
            string nMoney = "";
            for (int i = 0; i < Money.Length; i++)
                nMoney = Money[i].ToString() + nMoney;

            string Result = "";
            string mGiaTriCap2 = "";

            for (int i = 0; i < nMoney.Length; i++)
            {
                if (nMoney[i] == '0' && i % 3 != 0)
                {
                    if (i > 0)
                        if (nMoney[i - 1] != '0')
                            Result = " lẻ" + Result;
                }

                string GiaTriCap0 = DonViCap0[int.Parse(nMoney[i].ToString())];
                string GiaTriCap1 = "";

                if (GiaTriCap0 != "")
                    GiaTriCap1 = DonViCap1[i % 3];

                string GiaTriCap2 = "";

                if (i % 3 == 0 && i > 0)
                {
                    int tmp1 = i / 3;
                    while (tmp1 > 2)
                    {
                        tmp1 -= 3;
                        GiaTriCap2 += " tỷ";
                    }

                    if (Result.StartsWith(mGiaTriCap2))
                    {
                        Result = Result.TrimStart(mGiaTriCap2.ToCharArray());
                    }
                    GiaTriCap2 = DonViCap2[tmp1] + GiaTriCap2 + ",";
                    mGiaTriCap2 = GiaTriCap2;
                }

                Result = GiaTriCap0 + GiaTriCap1 + GiaTriCap2 + Result;
            }

            Result = Result.Replace("một mươi", "mười");
            Result = Result.TrimEnd(',').TrimStart(' ');
            Result = Result.Substring(0, 1).ToUpper() + Result.Substring(1);

            return Result + " đồng.";
        }
        #endregion 

        #region đọc Vàng
        public static string ReadGold(string Gold)
        {

            string[] DonViCap0int = new string[] { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };
            string[] DonViCap0 = new string[] { "", " một", " hai", " ba", " bốn", " năm", " sáu", " bảy", " tám", " chín" };
            string[] DonViCap1 = new string[] { "", " mươi", " trăm" };
            string[] DonViCap2 = new string[] { "", " nghìn", " triệu", " tỷ" };

            try
            {
                //Tách chuỗi bắt đầu cho đến dấu "."
                int index = Gold.IndexOf(".");

                //Thực hiện đảo chuỗi tiền
                string nMoney = "";
                for (int i = 0; i < index; i++)
                {
                    nMoney = Gold[i].ToString() + nMoney;
                }
                //đọc phần thập phân
                string chi = "";
                string phan = "";
                string ly = "";
                string zem = "";
                chi = Gold.Substring(index + 1, 1);
                phan = Gold.Substring(index + 2, 1);
                ly = Gold.Substring(index + 3, 1);
                zem = Gold.Substring(index + 4, 1);
                for (int i = 0; i < 10; i++)
                {
                    if (chi == DonViCap0int[i].ToString())
                    {
                        chi = DonViCap0[i].ToString();

                    }
                    if (phan == DonViCap0int[i].ToString())
                    {
                        phan = DonViCap0[i].ToString();

                    }
                    if (ly == DonViCap0int[i].ToString())
                    {
                        ly = DonViCap0[i].ToString();

                    }
                    if (zem == DonViCap0int[i].ToString())
                    {
                        zem = DonViCap0[i].ToString();
                    }

                }
                string thapPhan = "";
                string Result = "";
                if (chi == "")
                    chi = " không";
                if (phan == "")
                    phan = " không";
                if (ly == "")
                    ly = " không";
                if (zem == "")
                    zem = "không";
                if (nMoney == "0")
                    Result = "không";


                thapPhan = chi + " chỉ" + "," + phan + " phân" + "," + ly + " li" + "," + zem + " zem";


                string mGiaTriCap2 = "";

                for (int i = 0; i < nMoney.Length; i++)
                {
                    if (nMoney[i] == '0' && i % 3 != 0)
                    {
                        if (i > 0)
                            if (nMoney[i - 1] != '0')
                                Result = " lẻ" + Result;
                    }

                    string GiaTriCap0 = DonViCap0[int.Parse(nMoney[i].ToString())];
                    string GiaTriCap1 = "";

                    if (GiaTriCap0 != "")
                        GiaTriCap1 = DonViCap1[i % 3];

                    string GiaTriCap2 = "";

                    if (i % 3 == 0 && i > 0)
                    {
                        int tmp1 = i / 3;
                        while (tmp1 > 2)
                        {
                            tmp1 -= 3;
                            GiaTriCap2 += " tỷ";
                        }

                        if (Result.StartsWith(mGiaTriCap2))
                        {
                            Result = Result.TrimStart(mGiaTriCap2.ToCharArray());
                        }
                        GiaTriCap2 = DonViCap2[tmp1] + GiaTriCap2 + ",";
                        mGiaTriCap2 = GiaTriCap2;
                    }

                    Result = GiaTriCap0 + GiaTriCap1 + GiaTriCap2 + Result;
                }

                Result = Result.Replace("một mươi", "mười");
                Result = Result.TrimEnd(',').TrimStart(' ');
                Result = Result.Substring(0, 1).ToUpper() + Result.Substring(1);

                return Result + " lượng, " + thapPhan;
            }
            catch (Exception ex) { throw ex; }
        }
        #endregion

        #region Hàm Thông Báo Lỗi
        public void ThongBao(Exception ex)
        {
            // string thongbao = "";
            if (ex is SqlException)
            {
                if (((System.Data.SqlClient.SqlException)(ex)).Number == 547)
                    throw new ApplicationException("Dữ Liệu Này Đã Được Sử Dụng Không Được Xóa Hoặc Sửa");
                // thongbao="Dữ Liệu Này Đã Được Sử Dụng Không Được Xóa Hoặc Sửa";
                if (((System.Data.SqlClient.SqlException)(ex)).Number == 2)
                    throw new ApplicationException("Không Kết Nói Được Cơ Dữ Liệu");
                //thongbao= "Không Kết Nói Được Cơ Dữ Liệu";
                if (((System.Data.SqlClient.SqlException)(ex)).Number == 208)
                    throw new ApplicationException("DaTaBase Không Hợp Lệ Vui Lòng Chọn Lại");
                // thongbao = "DaTaBase Không Hợp Lệ Vui Lòng Chọn Lại";
                else
                    throw ex;
                //  thongbao = "Lổi Hệ Thống Khác ";
            }
            // return thongbao;
        }

        #endregion
       
        #region kiểm tra là số
        public static Boolean KiemTraLaSo(string s)
        {

            for (int i = 0; i < s.Length; i++)
            {
                if (char.IsNumber(char.Parse(s[i].ToString())) == false)
                    return false;
            }
            return true;

        }
        #endregion

    }
}
