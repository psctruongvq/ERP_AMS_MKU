using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PSC_ERP_Common
{
    public static class PriceToStringUtil
    {
        static class PriceToString_Helper
        {
            const string Linh = "linh";
            const string Lăm = "lăm";
            const string Mười = "mười";
            const string Mươi = "mươi";
            const string Mốt = "mốt";
            const string Trăm = "trăm";
            readonly static string[] numbers = { "không", "một", "hai", "ba", "bốn", "năm", "sáu", "bảy", "tám", "chín" };
            //private static string[] smallUnits = { STR_Linh, STR_Lăm, STR_Mười, STR_Mươi, STR_Mốt, STR_Trăm };
            readonly static string[] bigUnits = { "", "ngàn", "triệu", "tỷ" };

            private static string Lenght1(string input)
            {
                return numbers[int.Parse(input)];
            }
            private static string Lenght2(string input)
            {
                if (input.Substring(0, 1) == "0")
                    return String.Format("{0} {1}", Linh, Lenght1(input.Substring(1, 1)));
                else if (input.Substring(0, 1) == "1")
                {
                    if (input.Substring(1, 1) == "5")
                        return String.Format("{0} {1}", Mười, Lăm);
                    else if (input.Substring(1, 1) == "0")
                        return Mười;
                    else
                        return String.Format("{0} {1}", Mười, Lenght1(input.Substring(1, 1)));
                }
                else
                {
                    if (input.Substring(1, 1) == "5")
                        return String.Format("{0} {1} {2}", Lenght1(input.Substring(0, 1)), Mươi, Lăm);
                    else if (input.Substring(1, 1) == "0")
                        return String.Format("{0} {1}", Lenght1(input.Substring(0, 1)), Mươi);
                    else if (input.Substring(1, 1) == "1")
                        return String.Format("{0} {1} {2}", Lenght1(input.Substring(0, 1)), Mươi, Mốt);
                    else
                        return String.Format("{0} {1} {2}", Lenght1(input.Substring(0, 1)), Mươi, Lenght1(input.Substring(1, 1)));
                }
            }
            private static string Lenght3(string strA)
            {
                if ((strA.Substring(0, 3) == "000"))
                    return null;
                else if ((strA.Substring(1, 2) == "00"))
                    return String.Format("{0} {1}", Lenght1(strA.Substring(0, 1)), Trăm);
                else
                    return String.Format("{0} {1} {2}", Lenght1(strA.Substring(0, 1)), Trăm, Lenght2(strA.Substring(1, strA.Length - 1)));
            }
            /////////////////////
            private static string FullLenght(string strSend)
            {
                string[] strMainGroup;
                string[] strSubGroup;

                bool boKTNull = false;
                string strKQ = "";
                string strA = strSend.Trim();
                int iIndex = strA.Length - 9;
                int iPreIndex = 0;

                if (strSend.Trim() == "")
                    return Lenght1("0");
                //tra ve khong neu la khong
                for (int i = 0; i < strA.Length; i++)
                {
                    if (strA.Substring(i, 1) != "0")
                        break;
                    else if (i == strA.Length - 1)
                        return numbers[0];
                }
                int k = 0;
                while (strSend.Trim().Substring(k++, 1) == "0")
                    strA = strA.Remove(0, 1);
                //
                if (strA.Length < 9)
                    iPreIndex = strA.Length;
                //
                if ((strA.Length % 9) != 0)
                    strMainGroup = new string[strA.Length / 9 + 1];
                else
                    strMainGroup = new string[strA.Length / 9];
                //nguoc
                for (int i = strMainGroup.Length - 1; i >= 0; i--)
                {
                    if (iIndex >= 0)
                    {
                        iPreIndex = iIndex;
                        strMainGroup[i] = strA.Substring(iIndex, 9);
                        iIndex -= 9;
                    }
                    else
                        strMainGroup[i] = strA.Substring(0, iPreIndex);
                }
                /////////////////////////////////
                //tach moi maingroup thanh nhieu subgroup
                //xuoi
                for (int j = 0; j < strMainGroup.Length; j++)
                {
                    //gan lai gia tri
                    iIndex = strMainGroup[j].Length - 3;
                    if (strMainGroup[j].Length < 3)
                        iPreIndex = strMainGroup[j].Length;
                    ///
                    if ((strMainGroup[j].Length % 3) != 0)
                        strSubGroup = new string[strMainGroup[j].Length / 3 + 1];
                    else
                        strSubGroup = new string[strMainGroup[j].Length / 3];
                    for (int i = strSubGroup.Length - 1; i >= 0; i--)
                    {
                        if (iIndex >= 0)
                        {
                            iPreIndex = iIndex;
                            strSubGroup[i] = strMainGroup[j].Substring(iIndex, 3);
                            iIndex -= 3;
                        }
                        else
                            strSubGroup[i] = strMainGroup[j].Substring(0, iPreIndex);
                    }
                    //duyet subgroup de lay string
                    for (int i = 0; i < strSubGroup.Length; i++)
                    {
                        boKTNull = false;//phai de o day
                        if ((j == strMainGroup.Length - 1) && (i == strSubGroup.Length - 1))
                        {
                            if (strSubGroup[i].Length < 3)
                            {
                                if (strSubGroup[i].Length == 1)
                                    strKQ += Lenght1(strSubGroup[i]);
                                else
                                    strKQ += Lenght2(strSubGroup[i]);
                            }
                            else
                                strKQ += Lenght3(strSubGroup[i]);
                        }
                        else
                        {
                            if (strSubGroup[i].Length < 3)
                            {
                                if (strSubGroup[i].Length == 1)
                                    strKQ += Lenght1(strSubGroup[i]) + " ";
                                else
                                    strKQ += Lenght2(strSubGroup[i]) + " ";
                            }
                            else
                            {
                                if (Lenght3(strSubGroup[i]) == null)
                                    boKTNull = true;
                                else
                                    strKQ += Lenght3(strSubGroup[i]) + " ";
                            }
                        }
                        //dung
                        if (!boKTNull)
                        {
                            if (strSubGroup.Length - 1 - i != 0)
                                strKQ += bigUnits[strSubGroup.Length - 1 - i] + ". ";
                            else
                                strKQ += bigUnits[strSubGroup.Length - 1 - i] + " ";

                        }
                    }
                    //dung
                    if (j != strMainGroup.Length - 1)
                    {
                        if (!boKTNull)
                            strKQ = String.Format("{0}{1}. ", strKQ.Substring(0, strKQ.Length - 1), bigUnits[3]);
                        else
                            strKQ = String.Format("{0} {1}. ", strKQ.Substring(0, strKQ.Length - 1), bigUnits[3]);
                    }
                }
                //xoa ky tu trang
                strKQ = strKQ.Trim();
                //xoa dau , neu co
                if (strKQ.Substring(strKQ.Length - 1, 1) == ".")
                    strKQ = strKQ.Remove(strKQ.Length - 1, 1);
                return strKQ;

                ////////////////////////////////////


            }
            internal static string Convert(string inputString, char decimalPoint = '.', string decimalPointName = "phẩy")
            {
                if (String.IsNullOrWhiteSpace(inputString))
                {
                    return Lenght1("0");
                }

                string[] leftPart = new string[2];
                try
                {

                    leftPart = inputString.Split(decimalPoint);
                    string strTmpRight = leftPart[1];
                    for (int i = strTmpRight.Length - 1; i >= 0; i--)
                    {
                        if (strTmpRight.Substring(i, 1) == "0")
                            strTmpRight = strTmpRight.Remove(i, 1);
                        else
                            break;
                    }
                    if (strTmpRight != "")
                    {
                        string rightPart = "";
                        for (int i = 0; i < strTmpRight.Length; i++)
                            rightPart += Lenght1(strTmpRight.Substring(i, 1)) + " ";


                        return String.Format("{0} {1} {2}", FullLenght(leftPart[0]), decimalPointName, rightPart.TrimEnd());
                    }
                    else
                        return FullLenght(leftPart[0]);
                }
                catch
                {
                    return FullLenght(leftPart[0]);
                }

            }
        }

        public static String Convert(string inputString, char decimalPoint = '.', string decimalPointName = "phẩy")
        {
            String str = inputString;
            String prefix = "";
            if (String.IsNullOrWhiteSpace(str))
                str = "0";
            Decimal giaTri = Decimal.Parse(str);
            if (giaTri < 0)
            {
                prefix = "Âm ";
                str = Math.Abs(giaTri).ToString();
                if (String.IsNullOrWhiteSpace(str))
                    str = "0";
            }
            return prefix + PriceToString_Helper.Convert(str, decimalPoint, decimalPointName);
        }
    }
}
