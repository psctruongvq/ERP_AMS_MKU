using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

//oooooooooooo
namespace ERP_Library
{
    public static class HamDungChung
    {
        #region DocTien
        public static string DocTien(decimal NumCurrency)
        {
            string SoRaChu = "";
            if (NumCurrency == 0)
            {
                SoRaChu = "Không đồng";
                return SoRaChu;
            }

            string[] CharVND = new string[10] { "không", "một", "hai", "ba", "bốn", "năm", "sáu", "bảy", "tám", "chín" };
            string BangChu;
            int I;
            //As String, BangChu As String, I As Integer
            int SoLe, SoDoi;
            string PhanChan, Ten;
            string DonViTien, DonViLe;
            int NganTy, Ty, Trieu, Ngan;
            int Dong, Tram, Muoi, DonVi;

            SoDoi = 0;
            Muoi = 0;
            Tram = 0;
            DonVi = 0;

            Ten = "";
            //Dim SoLe, SoDoi As Integer, PhanChan, Ten As String
            //Dim DonViTien As String, DonViLe As String
            //Dim NganTy As Integer, Ty As Integer, Trieu As Integer, Ngan As Integer
            //Dim Dong As Integer, Tram As Integer, Muoi As Integer, DonVi As Integer

            DonViTien = "đồng";
            DonViLe = "xu";


            SoLe = (int)((NumCurrency - (Int64)NumCurrency) * 100); //'2 kí so^' le?
            PhanChan = ((Int64)NumCurrency).ToString().Trim();
            PhanChan = PhanChan.Replace("-", "");
            int khoangtrang = 15 - PhanChan.Length;
            for (int i = 0; i < khoangtrang; i++)
                PhanChan = "0" + PhanChan;
            //PhanChan = Space(15 - PhanChan.Length) + PhanChan;

            NganTy = int.Parse(PhanChan.Substring(0, 3));
            Ty = int.Parse(PhanChan.Substring(3, 3));
            Trieu = int.Parse(PhanChan.Substring(6, 3));
            Ngan = int.Parse(PhanChan.Substring(9, 3));
            Dong = int.Parse(PhanChan.Substring(12, 3));
            //Ty = Val(Mid$(PhanChan, 4, 3))
            //Trieu = Val(Mid$(PhanChan, 7, 3))
            //Ngan = Val(Mid$(PhanChan, 10, 3))
            //Dong = Val(Mid$(PhanChan, 13, 3))

            if (NganTy == 0 & Ty == 0 & Trieu == 0 & Ngan == 0 & Dong == 0)
            {
                BangChu = "không " + DonViTien + " ";
                I = 5;
            }
            else
            {
                BangChu = "";
                I = 0;
            }

            while (I <= 5)
            {
                switch (I)
                {
                    case 0:
                        SoDoi = NganTy;
                        Ten = "nghìn tỷ";
                        break;
                    case 1:
                        SoDoi = Ty;
                        Ten = "tỷ";
                        break;
                    case 2:
                        SoDoi = Trieu;
                        Ten = "triệu";
                        break;
                    case 3:
                        SoDoi = Ngan;
                        Ten = "nghìn";
                        break;
                    case 4:
                        SoDoi = Dong;
                        Ten = DonViTien;
                        break;
                    case 5:
                        SoDoi = SoLe;
                        Ten = DonViLe;
                        break;
                }

                if (SoDoi != 0)
                {
                    Tram = (int)(SoDoi / 100);
                    Muoi = (int)((SoDoi - Tram * 100) / 10);
                    DonVi = (SoDoi - Tram * 100) - Muoi * 10;
                    BangChu = BangChu.Trim() + (BangChu.Length == 0 ? "" : ", ") + (Tram != 0 ? CharVND[Tram].Trim() + " trăm " : "");
                    if (Muoi == 0 & Tram != 0 & DonVi != 0)
                        BangChu = BangChu + "lẻ ";
                    else if (Muoi != 0)
                        BangChu = BangChu + ((Muoi != 0 & Muoi != 1) ? CharVND[Muoi].Trim() + " mươi " : "mười ");

                    if (Muoi != 0 & DonVi == 5)
                        BangChu = BangChu + "lăm " + Ten + " ";
                    else if (Muoi > 1 & DonVi == 1)
                        BangChu = BangChu + "mốt " + Ten + " ";
                    else
                        BangChu = BangChu + ((DonVi != 0) ? CharVND[DonVi].Trim() + " " + Ten + " " : Ten + " ");
                }
                else
                    BangChu = BangChu + ((I == 4) ? DonViTien + " " : "");

                I = I + 1;
            }
            if (SoLe == 0)
                BangChu = BangChu + "chẵn";

            BangChu = BangChu[0].ToString().ToUpper() + BangChu.Substring(1);
            SoRaChu = BangChu;
            return SoRaChu;
        }
        #endregion

        #region DocTienDo
        public static string DocTienDo(decimal NumCurrency)
        {
            string SoRaChu = "";
            if (NumCurrency == 0)
            {
                SoRaChu = "Không đôla";
                return SoRaChu;
            }

            string[] CharVND = new string[10] { "không", "một", "hai", "ba", "bốn", "năm", "sáu", "bảy", "tám", "chín" };
            string BangChu;
            int I;
            //As String, BangChu As String, I As Integer
            int SoLe, SoDoi;
            string PhanChan, Ten;
            string DonViTien, DonViLe;
            int NganTy, Ty, Trieu, Ngan;
            int Dong, Tram, Muoi, DonVi;

            SoDoi = 0;
            Muoi = 0;
            Tram = 0;
            DonVi = 0;

            Ten = "";
            //Dim SoLe, SoDoi As Integer, PhanChan, Ten As String
            //Dim DonViTien As String, DonViLe As String
            //Dim NganTy As Integer, Ty As Integer, Trieu As Integer, Ngan As Integer
            //Dim Dong As Integer, Tram As Integer, Muoi As Integer, DonVi As Integer

            DonViTien = "đôla";
            DonViLe = "xen";


            SoLe = (int)((NumCurrency - (Int64)NumCurrency) * 100); //'2 kí so^' le?
            PhanChan = ((Int64)NumCurrency).ToString().Trim();

            int khoangtrang = 15 - PhanChan.Length;
            for (int i = 0; i < khoangtrang; i++)
                PhanChan = "0" + PhanChan;
            //PhanChan = Space(15 - PhanChan.Length) + PhanChan;

            NganTy = int.Parse(PhanChan.Substring(0, 3));
            Ty = int.Parse(PhanChan.Substring(3, 3));
            Trieu = int.Parse(PhanChan.Substring(6, 3));
            Ngan = int.Parse(PhanChan.Substring(9, 3));
            Dong = int.Parse(PhanChan.Substring(12, 3));
            //Ty = Val(Mid$(PhanChan, 4, 3))
            //Trieu = Val(Mid$(PhanChan, 7, 3))
            //Ngan = Val(Mid$(PhanChan, 10, 3))
            //Dong = Val(Mid$(PhanChan, 13, 3))

            if (NganTy == 0 & Ty == 0 & Trieu == 0 & Ngan == 0 & Dong == 0)
            {
                BangChu = "không " + DonViTien + " ";
                I = 5;
            }
            else
            {
                BangChu = "";
                I = 0;
            }

            while (I <= 5)
            {
                switch (I)
                {
                    case 0:
                        SoDoi = NganTy;
                        Ten = "nghìn tỷ";
                        break;
                    case 1:
                        SoDoi = Ty;
                        Ten = "tỷ";
                        break;
                    case 2:
                        SoDoi = Trieu;
                        Ten = "triệu";
                        break;
                    case 3:
                        SoDoi = Ngan;
                        Ten = "nghìn";
                        break;
                    case 4:
                        SoDoi = Dong;
                        Ten = DonViTien;
                        break;
                    case 5:
                        SoDoi = SoLe;
                        Ten = DonViLe;
                        break;
                }

                if (SoDoi != 0)
                {
                    Tram = (int)(SoDoi / 100);
                    Muoi = (int)((SoDoi - Tram * 100) / 10);
                    DonVi = (SoDoi - Tram * 100) - Muoi * 10;
                    BangChu = BangChu.Trim() + (BangChu.Length == 0 ? "" : ", ") + (Tram != 0 ? CharVND[Tram].Trim() + " trăm " : "");
                    if (Muoi == 0 & Tram != 0 & DonVi != 0)
                        BangChu = BangChu + "lẽ ";
                    else if (Muoi != 0)
                        BangChu = BangChu + ((Muoi != 0 & Muoi != 1) ? CharVND[Muoi].Trim() + " mươi " : "mười ");

                    if (Muoi != 0 & DonVi == 5)
                        BangChu = BangChu + "lăm " + Ten + " ";
                    else if (Muoi > 1 & DonVi == 1)
                        BangChu = BangChu + "mốt " + Ten + " ";
                    else
                        BangChu = BangChu + ((DonVi != 0) ? CharVND[DonVi].Trim() + " " + Ten + " " : Ten + " ");
                }
                else
                    BangChu = BangChu + ((I == 4) ? DonViTien + " " : "");

                I = I + 1;
            }
            if (SoLe == 0)
                BangChu = BangChu + "";

            BangChu = BangChu[0].ToString().ToUpper() + BangChu.Substring(1);
            SoRaChu = BangChu;
            return SoRaChu;
        }
        #endregion

        #region DocTienKhac
        public static string DocTienNgoaiTe(decimal NumCurrency, string TienChan, string TienLe)
        {
            string SoRaChu = "";
            if (NumCurrency == 0)
            {
                SoRaChu = "Không " + TienChan;
                return SoRaChu;
            }

            string[] CharVND = new string[10] { "không", "một", "hai", "ba", "bốn", "năm", "sáu", "bảy", "tám", "chín" };
            string BangChu;
            int I;
            //As String, BangChu As String, I As Integer
            int SoLe, SoDoi;
            string PhanChan, Ten;
            string DonViTien, DonViLe;
            int NganTy, Ty, Trieu, Ngan;
            int Dong, Tram, Muoi, DonVi;

            SoDoi = 0;
            Muoi = 0;
            Tram = 0;
            DonVi = 0;

            Ten = "";
            //Dim SoLe, SoDoi As Integer, PhanChan, Ten As String
            //Dim DonViTien As String, DonViLe As String
            //Dim NganTy As Integer, Ty As Integer, Trieu As Integer, Ngan As Integer
            //Dim Dong As Integer, Tram As Integer, Muoi As Integer, DonVi As Integer

            DonViTien = TienChan;
            DonViLe = TienLe;


            SoLe = (int)((NumCurrency - (Int64)NumCurrency) * 100); //'2 kí so^' le?
            PhanChan = ((Int64)NumCurrency).ToString().Trim();

            int khoangtrang = 15 - PhanChan.Length;
            for (int i = 0; i < khoangtrang; i++)
                PhanChan = "0" + PhanChan;
            //PhanChan = Space(15 - PhanChan.Length) + PhanChan;

            NganTy = int.Parse(PhanChan.Substring(0, 3));
            Ty = int.Parse(PhanChan.Substring(3, 3));
            Trieu = int.Parse(PhanChan.Substring(6, 3));
            Ngan = int.Parse(PhanChan.Substring(9, 3));
            Dong = int.Parse(PhanChan.Substring(12, 3));
            //Ty = Val(Mid$(PhanChan, 4, 3))
            //Trieu = Val(Mid$(PhanChan, 7, 3))
            //Ngan = Val(Mid$(PhanChan, 10, 3))
            //Dong = Val(Mid$(PhanChan, 13, 3))

            if (NganTy == 0 & Ty == 0 & Trieu == 0 & Ngan == 0 & Dong == 0)
            {
                BangChu = "không " + DonViTien + " ";
                I = 5;
            }
            else
            {
                BangChu = "";
                I = 0;
            }

            while (I <= 5)
            {
                switch (I)
                {
                    case 0:
                        SoDoi = NganTy;
                        Ten = "nghìn tỷ";
                        break;
                    case 1:
                        SoDoi = Ty;
                        Ten = "tỷ";
                        break;
                    case 2:
                        SoDoi = Trieu;
                        Ten = "triệu";
                        break;
                    case 3:
                        SoDoi = Ngan;
                        Ten = "nghìn";
                        break;
                    case 4:
                        SoDoi = Dong;
                        Ten = DonViTien;
                        break;
                    case 5:
                        SoDoi = SoLe;
                        Ten = DonViLe;
                        break;
                }

                if (SoDoi != 0)
                {
                    Tram = (int)(SoDoi / 100);
                    Muoi = (int)((SoDoi - Tram * 100) / 10);
                    DonVi = (SoDoi - Tram * 100) - Muoi * 10;
                    BangChu = BangChu.Trim() + (BangChu.Length == 0 ? "" : ", ") + (Tram != 0 ? CharVND[Tram].Trim() + " trăm " : "");
                    if (Muoi == 0 & Tram != 0 & DonVi != 0)
                        BangChu = BangChu + "lẻ ";
                    else if (Muoi != 0)
                        BangChu = BangChu + ((Muoi != 0 & Muoi != 1) ? CharVND[Muoi].Trim() + " mươi " : "mười ");

                    if (Muoi != 0 & DonVi == 5)
                        BangChu = BangChu + "lăm " + Ten + " ";
                    else if (Muoi > 1 & DonVi == 1)
                        BangChu = BangChu + "mốt " + Ten + " ";
                    else
                        BangChu = BangChu + ((DonVi != 0) ? CharVND[DonVi].Trim() + " " + Ten + " " : Ten + " ");
                }
                else
                    BangChu = BangChu + ((I == 4) ? DonViTien + " " : "");

                I = I + 1;
            }
            if (SoLe == 0)
                BangChu = BangChu + "";

            BangChu = BangChu[0].ToString().ToUpper() + BangChu.Substring(1);
            SoRaChu = BangChu;
            return SoRaChu;
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

        #region KiemTraLaSo
        /// <summary>
        /// Kiểm tra một chuổi có phải là số hay không
        /// </summary>
        /// <param name="s">Chuổi cần kiểm tra</param>
        /// <returns>True nếu là số, False nếu không phải là số</returns>

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

        #region Hàm Thông Báo Lỗi
        public static void ThongBaoLoi(Exception ex)
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
                    throw new ApplicationException("Lổi Hệ Thống Khác ");
                //  thongbao = "Lổi Hệ Thống Khác ";
            }
            // return thongbao;

        }
        #endregion

        public static int GetMonthsDiff(DateTime startDate, DateTime endDate)
        {
            int monthsApart = 12 * (startDate.Year - endDate.Year) + startDate.Month - endDate.Month;
            return Math.Abs(monthsApart);
        }


        #region Định nghĩa Kiểu DateTime
        public static DateTime ToStartDate(this DateTime date)
        {
            return new DateTime(date.Year, date.Month, date.Day, 0, 0, 0);
        }

        public static DateTime ToEndDate(this DateTime date)
        {
            return new DateTime(date.Year, date.Month, date.Day, 23, 59, 59);
        }
        #endregion//Định nghĩa Kiẻu DateTime

    }
}
