using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using ERP_Library;
using Infragistics.Win;
using Infragistics.Win.UltraWinEditors;
using Infragistics.Win.UltraWinGrid;
using System.Data.SqlClient;
using CrystalDecisions.CrystalReports.Engine;
using System.Text.RegularExpressions;
using System.Diagnostics;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Columns;
using System.IO;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using PSC_ERP_Business.Main.Model;
using PSC_ERP_Business.Main.Factory;
using PSC_ERP_Common;

namespace PSC_ERP
{
    public enum KieuDuLieu { Null, Tien, Ngay, So, KhoiLuong, Vang, NgayGio, TuoiVang, TienLe, NullCanhGiua }
    public class HamDungChung
    {

      
        /// <summary>
        /// (đây là phiên bản cũ - không nên xài)
        /// Nếu tạo mới xài hàm HamDungChung.EditThemDongMoi(UltraGrid ultraGrid1)
        /// Dùng ngay trong Form_Load() hay khởi tạo form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void ultragrdEmail_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            e.Layout.Override.AllowColMoving = AllowColMoving.WithinBand;
            e.Layout.Override.AllowColSwapping = AllowColSwapping.WithinBand;
            e.Layout.Override.FilterUIType = FilterUIType.FilterRow;
            e.Layout.Override.FilterOperatorDefaultValue = FilterOperatorDefaultValue.Contains;
            //e.Layout.Override.AllowAddNew = AllowAddNew.Yes;
            e.Layout.Override.AllowAddNew = AllowAddNew.FixedAddRowOnTop;
            e.Layout.Override.RowFilterMode = RowFilterMode.AllRowsInBand;
            e.Layout.Override.HeaderClickAction = HeaderClickAction.SortMulti;
         
            e.Layout.Override.CellClickAction = CellClickAction.EditAndSelectText;
           
            e.Layout.Override.SortComparisonType = SortComparisonType.CaseInsensitive;
            e.Layout.Override.AllowRowFiltering = DefaultableBoolean.True;
            e.Layout.Override.SpecialRowSeparator = SpecialRowSeparator.TemplateAddRow;
           

            e.Layout.Override.TemplateAddRowPrompt = "Thêm Dòng Mới...";
           
           

            e.Layout.Override.TemplateAddRowPromptAppearance.FontData.Bold = DefaultableBoolean.True;
            e.Layout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.RowIndex;
            e.Layout.Override.RowSelectors =DefaultableBoolean.True;
            e.Layout.Override.RowSelectorHeaderStyle = RowSelectorHeaderStyle.SeparateElement;
        }
        public static void Combobox_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {

          
            e.Layout.Override.AllowColMoving = AllowColMoving.WithinBand;
            e.Layout.Override.AllowColSwapping = AllowColSwapping.WithinBand;
            e.Layout.Override.FilterUIType = FilterUIType.FilterRow;
            e.Layout.Override.FilterOperatorDefaultValue = FilterOperatorDefaultValue.Contains;
            e.Layout.Override.AllowAddNew = AllowAddNew.FixedAddRowOnTop;
            e.Layout.Override.RowFilterMode = RowFilterMode.AllRowsInBand;
            e.Layout.Override.HeaderClickAction = HeaderClickAction.SortMulti;
            e.Layout.Override.TemplateAddRowAppearance.BackColor = Color.Orange;
            e.Layout.Override.TemplateAddRowAppearance.ForeColor = SystemColors.HighlightText;
            e.Layout.Override.CellClickAction = CellClickAction.EditAndSelectText;
            e.Layout.Override.AddRowAppearance.BackColor = Color.LightYellow;
            e.Layout.Override.AddRowAppearance.ForeColor = Color.Orange;
            e.Layout.Override.SortComparisonType = SortComparisonType.CaseInsensitive;
            //e.Layout.Override.AllowRowFiltering = DefaultableBoolean.True;
            e.Layout.Override.SpecialRowSeparator = SpecialRowSeparator.TemplateAddRow;
            e.Layout.Override.SpecialRowSeparatorAppearance.BackColor = SystemColors.Menu;          
            e.Layout.Override.TemplateAddRowPromptAppearance.ForeColor = Color.Orange;
            e.Layout.Override.TemplateAddRowPromptAppearance.FontData.Bold = DefaultableBoolean.True;
        }

        #region DocTien
        public static string DocTien(decimal NumCurrency)
        {
            string SoRaChu = "";
            NumCurrency = Math.Abs(NumCurrency);
            if (NumCurrency == 0)
            {
                SoRaChu = "Không đồng";
                return SoRaChu;
            }

            string[] CharVND = new string[10] { "không", "một", "hai", "ba", "bốn", "năm", "sáu", "bảy", "tám", "chín" };
            string BangChu;
            int I;
            //As String, BangChu As String, I As Integer
            int SoLe = (int)((NumCurrency - (Int64)NumCurrency) * 100);
            string PhanChan = ((Int64)NumCurrency).ToString().Trim();
            const string DonViLe = "xu";
            int NganTy, Ty, Trieu, Ngan;
            int Dong;

            int SoDoi = 0;
            int Muoi = 0;
            int Tram = 0;
            int DonVi = 0;

            string Ten = "";
            //Dim SoLe, SoDoi As Integer, PhanChan, Ten As String
            //Dim DonViTien As String, DonViLe As String
            //Dim NganTy As Integer, Ty As Integer, Trieu As Integer, Ngan As Integer
            //Dim Dong As Integer, Tram As Integer, Muoi As Integer, DonVi As Integer

            const string DonViTien = "đồng"; //'2 kí so^' le?

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
                BangChu = string.Format("không {0} ", DonViTien);
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
                        Ten = "ngàn tỷ";
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
                        Ten = "ngàn";
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
                    BangChu = BangChu.Trim() + (BangChu.Length == 0 ? "" : " ") + (Tram != 0 ? CharVND[Tram].Trim() + " trăm " : "");
                    // if (Muoi == 0 & Tram != 0 & DonVi != 0)

                    //if (Tram != 0 & Muoi == 0 & DonVi == 0 & BangChu != "")
                    //    BangChu = BangChu + " trăm ";
                    if (Muoi == 0 & Tram == 0 & DonVi != 0 & BangChu != "")
                        BangChu = BangChu + "không trăm lẽ ";
                    else if (Muoi != 0 & Tram == 0 & (DonVi == 0 || DonVi != 0) & BangChu != "")
                        BangChu = BangChu + "không trăm ";
                    else if (Muoi == 0 & Tram != 0 & DonVi != 0 & BangChu != "")
                        BangChu = BangChu + "lẽ ";
                    if (Muoi != 0 & Muoi > 0)
                        BangChu = BangChu + ((Muoi != 0 & Muoi != 1) ? CharVND[Muoi].Trim() + " mươi " : "mười ");

                    if (Muoi != 0 & DonVi == 5)
                        BangChu = string.Format("{0}lăm {1} ", BangChu, Ten);
                    else if (Muoi > 1 & DonVi == 1)
                        BangChu = string.Format("{0}mốt {1} ", BangChu, Ten);
                    else
                        BangChu = BangChu + ((DonVi != 0) ? string.Format("{0} {1} ", CharVND[DonVi].Trim(), Ten) : Ten + " ");
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

        #region DocTienEnglish
        public static string DocTienEngLish(int number)
        {
            if (number == 0)
                return "zero";

            if (number < 0)
                return "minus " + DocTienEngLish(Math.Abs(number));

            string words = "";

            if ((number / 1000000) > 0)
            {
                words += DocTienEngLish(number / 1000000) + " million ";
                number %= 1000000;
            }

            if ((number / 1000) > 0)
            {
                words += DocTienEngLish(number / 1000) + " thousand ";
                number %= 1000;
            }

            if ((number / 100) > 0)
            {
                words += DocTienEngLish(number / 100) + " hundred ";
                number %= 100;
            }

            if (number > 0)
            {
                if (words != "")
                    words += "and ";

                var unitsMap = new[] { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen" };
                var tensMap = new[] { "zero", "ten", "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety" };

                if (number < 20)
                {
                    words += unitsMap[number];
                }
                else
                {
                    words += tensMap[number / 10];
                    if ((number % 10) > 0)
                        words += "-" + unitsMap[number % 10];
                }
            }

            return words;
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
                        Ten = "ngàn tỷ";
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
                        Ten = "ngàn";
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
            int SoLe = (int)((NumCurrency - (Int64)NumCurrency) * 100);
            string PhanChan = ((Int64)NumCurrency).ToString().Trim();
            string DonViTien = TienChan;
            int NganTy, Ty, Trieu, Ngan;
            int Dong;

            int SoDoi = 0;
            int Muoi = 0;
            int Tram = 0;
            int DonVi = 0;

            string Ten = "";
            //Dim SoLe, SoDoi As Integer, PhanChan, Ten As String
            //Dim DonViTien As String, DonViLe As String
            //Dim NganTy As Integer, Ty As Integer, Trieu As Integer, Ngan As Integer
            //Dim Dong As Integer, Tram As Integer, Muoi As Integer, DonVi As Integer
            string DonViLe = TienLe; //'2 kí so^' le?

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
                BangChu = string.Format("không {0} ", DonViTien);
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
                        Ten = "ngàn tỷ";
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
                        Ten = "ngàn";
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
                        BangChu = string.Format("{0}lăm {1} ", BangChu, Ten);
                    else if (Muoi > 1 & DonVi == 1)
                        BangChu = string.Format("{0}mốt {1} ", BangChu, Ten);
                    else
                        BangChu = BangChu + ((DonVi != 0) ? string.Format("{0} {1} ", CharVND[DonVi].Trim(), Ten) : Ten + " ");
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



        /// <summary>
        /// khoi tao ultragrid chinh
        /// </summary>
        /// <param name="ultraGrid1">luoi can khoi tao</param>
        public static void EditRootGrid(UltraGrid ultraGrid1)
        {
            EditAllGrid(ultraGrid1);
            EditThemDongMoi(ultraGrid1);

            ultraGrid1.DisplayLayout.Override.CellClickAction = CellClickAction.RowSelect;
            ultraGrid1.DisplayLayout.Override.AllowDelete = DefaultableBoolean.False;
        }
        /// <summary>
        /// khoi tao ultragrid phu
        /// </summary>
        /// <param name="ultraGrid1">luoi can khoi tao</param>
        public static void EditChilGrid(UltraGrid ultraGrid1)
        {
            EditAllGrid(ultraGrid1);

            ultraGrid1.DisplayLayout.Override.CellClickAction = CellClickAction.EditAndSelectText;
            ultraGrid1.DisplayLayout.Override.AllowAddNew = AllowAddNew.No;
        }
        /// <summary>
        /// khởi tao chung cho tất cả UltraGrid
        /// </summary>
        /// <param name="ultraGrid1"> lưới cần khởi tạo</param>
        public static void EditAllGrid(UltraGrid ultraGrid1)
        {
            ultraGrid1.DisplayLayout.GroupByBox.Hidden = true;
            for (int i = 1; i < ultraGrid1.DisplayLayout.Bands.Count; i++)
                ultraGrid1.DisplayLayout.Bands[i].Hidden = true;

            ultraGrid1.DisplayLayout.Override.RowSelectors = DefaultableBoolean.True;
            ultraGrid1.DisplayLayout.Override.HeaderStyle = HeaderStyle.WindowsXPCommand;
            ultraGrid1.DisplayLayout.Override.HeaderAppearance.BackColor = Color.SteelBlue;

            ////foreach (UltraGridBand band in ultraGrid1.DisplayLayout.Bands)
            //for (int i = 0; i < ultraGrid1.DisplayLayout.Bands.Count; i++)
            //    //using (UltraGridBand band = ultraGrid1.DisplayLayout.Bands[i])
            //        //foreach (UltraGridColumn col in band.Columns)
            //        for (int k = 0; k < ultraGrid1.DisplayLayout.Bands[i].Columns.Count; k++)
            //            //using (UltraGridColumn col = ultraGrid1.DisplayLayout.Bands[i].Columns[k])
            //            {
            //                //bool a = band.Columns.Disposed;
            //                //bool b = col.Disposed;
            //                //ultraGrid1.DisplayLayout.Bands[i].Columns[k].Hidden = true;//col.Disposed 
            //                ultraGrid1.DisplayLayout.Bands[i].Columns[k].Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
            //                ultraGrid1.DisplayLayout.Bands[i].Columns[k].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
            //                ultraGrid1.DisplayLayout.Bands[i].Columns[k].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            //                ultraGrid1.DisplayLayout.Bands[i].Columns[k].Header.Appearance.ForeColor = System.Drawing.Color.Navy;//x =  //= System.Drawing.w;//RoyalBlue
            //            }
        }
        /// <summary>
        /// thêm chức năng "thêm dòng mới" cho lưới UltraGrid
        /// </summary>
        /// <param name="ultraGrid1">lưới cần thêm chức năng</param>
        public static void EditThemDongMoi( UltraGrid ultraGrid1)
        {
            ultraGrid1.DisplayLayout.Override.AllowAddNew = AllowAddNew.FixedAddRowOnTop;

            ultraGrid1.DisplayLayout.Override.TemplateAddRowAppearance.BackColor = Color.FromArgb(245, 250, 255);
            ultraGrid1.DisplayLayout.Override.TemplateAddRowAppearance.ForeColor = SystemColors.GrayText;

            ultraGrid1.DisplayLayout.Override.AddRowAppearance.BackColor = Color.LightYellow;
            ultraGrid1.DisplayLayout.Override.AddRowAppearance.ForeColor = Color.Blue;

            ultraGrid1.DisplayLayout.Override.SpecialRowSeparator = SpecialRowSeparator.TemplateAddRow;
            ultraGrid1.DisplayLayout.Override.SpecialRowSeparatorAppearance.BackColor = SystemColors.Control;

            ultraGrid1.DisplayLayout.Override.TemplateAddRowPrompt = "Thêm Dòng Mới...";
            ultraGrid1.DisplayLayout.Override.TemplateAddRowPromptAppearance.ForeColor = Color.Maroon;
            ultraGrid1.DisplayLayout.Override.TemplateAddRowPromptAppearance.FontData.Bold = DefaultableBoolean.True;
        }

        /// <summary>
        /// Edit cac cot cua 1 band
        /// </summary>
        /// <param name="ultraGridBand">Band cần edit</param>
        /// <param name="colNames">Mảng Tên (tên nguyên thủy - thứ tự là thứ tự muốn xuất hiện) </param>
        /// <param name="colCaptions">Mang Captions (tên hiện lên)</param>
        /// <param name="doRongCot">Mang Chieu rong cac cot</param>
        /// <param name="controls">Mang Control gan vao moi cot</param>
        /// <param name="kieuDuLieu">Mang Kieu du lieu</param>
        /// <param name="duocEdit">Mang Cho phep edit</param>
        public static void EditNhieuCot(UltraGrid ultraGrid, int sstBand, string[] colNames, string[] colCaptions, int[] doRongCot, Control[] controls, KieuDuLieu[] kieuDuLieu, bool[] duocEdit)
        {
            ultraGrid.DisplayLayout.Bands[sstBand].Hidden = false;

            for (int i = 0; i < ultraGrid.DisplayLayout.Bands[sstBand].Columns.Count; i++)
            {
                ultraGrid.DisplayLayout.Bands[sstBand].Columns[i].Hidden = true;
                //ultraGrid.DisplayLayout.Bands[sstBand].Columns[i].Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                //ultraGrid.DisplayLayout.Bands[sstBand].Columns[i].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                //ultraGrid.DisplayLayout.Bands[sstBand].Columns[i].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                //ultraGrid.DisplayLayout.Bands[sstBand].Columns[i].Header.Appearance.ForeColor = System.Drawing.Color.Navy;//x =  //= System.Drawing.w;//RoyalBlue
            }

            int soCot = colNames.Length;
            if (!(soCot > 0 && soCot == colCaptions.Length && soCot == doRongCot.Length && soCot == controls.Length && soCot == kieuDuLieu.Length && soCot == duocEdit.Length))
                return;
            for (int i = 0; i < soCot; i++)
            {
                //using (UltraGridColumn col = ultraGrid.DisplayLayout.Bands[sstBand].Columns[colNames[i]])
                //{
                ultraGrid.DisplayLayout.Bands[sstBand].Columns[colNames[i]].Hidden = false;

                ultraGrid.DisplayLayout.Bands[sstBand].Columns[colNames[i]].Header.Appearance.FontData.Bold = DefaultableBoolean.True;
                ultraGrid.DisplayLayout.Bands[sstBand].Columns[colNames[i]].Header.Appearance.TextHAlign = HAlign.Center;
                ultraGrid.DisplayLayout.Bands[sstBand].Columns[colNames[i]].CellAppearance.TextHAlign = HAlign.Right;
                ultraGrid.DisplayLayout.Bands[sstBand].Columns[colNames[i]].Header.Appearance.ForeColor = Color.Navy;//x =  //= System.Drawing.w;//RoyalBlue
                ultraGrid.DisplayLayout.Bands[sstBand].Columns[colNames[i]].Header.VisiblePosition = i;
                ultraGrid.DisplayLayout.Bands[sstBand].Columns[colNames[i]].Header.Caption = colCaptions[i];

                ultraGrid.DisplayLayout.Bands[sstBand].Columns[colNames[i]].Width = doRongCot[i];
                if (duocEdit[i])
                    ultraGrid.DisplayLayout.Bands[sstBand].Columns[colNames[i]].CellActivation = Activation.AllowEdit;
                else
                    ultraGrid.DisplayLayout.Bands[sstBand].Columns[colNames[i]].CellActivation = Activation.ActivateOnly;
                switch (kieuDuLieu[i])
                {
                    case KieuDuLieu.Ngay:
                        ultraGrid.DisplayLayout.Bands[sstBand].Columns[colNames[i]].MaskInput = "{LOC}dd/mm/yyyy";
                        break;
                    case KieuDuLieu.So:
                        ultraGrid.DisplayLayout.Bands[sstBand].Columns[colNames[i]].MaskInput = "nnnnnnnnn";
                        break;
                    case KieuDuLieu.Tien:
                        ultraGrid.DisplayLayout.Bands[sstBand].Columns[colNames[i]].MaskInput = "{LOC} nnn,nnn,nnn,nnn.nn";
                        ultraGrid.DisplayLayout.Bands[sstBand].Columns[colNames[i]].MaskInput = "###,###,###,###";
                        break;
                    default:
                        ultraGrid.DisplayLayout.Bands[sstBand].Columns[colNames[i]].MaskInput = string.Empty;
                        break;
                }
                //}
                ultraGrid.DisplayLayout.Bands[sstBand].Columns[colNames[i]].EditorComponent = controls[i];
            }
        }

        /// <summary>
        /// Edit cac cot cua 1 band
        /// </summary>
        /// <param name="ultraGridBand">Band cần edit</param>
        /// <param name="colNames">Mảng Tên (tên nguyên thủy - thứ tự là thứ tự muốn xuất hiện) </param>
        /// <param name="colCaptions">Mang Captions (tên hiện lên)</param>
        /// <param name="doRongCot">Mang Chieu rong cac cot</param>
        /// <param name="controls">Mang Control gan vao moi cot</param>
        /// <param name="kieuDuLieu">Mang Kieu du lieu</param>
        /// <param name="duocEdit">Mang Cho phep edit</param>
        public static void EditBand(UltraGridBand Band, string[] colNames, string[] colCaptions, int[] doRongCot, Control[] controls, KieuDuLieu[] kieuDuLieu, bool[] duocEdit)
        {
            Band.Hidden = false;

            for (int i = 0; i < Band.Columns.Count; i++)
            {
                Band.Columns[i].Hidden = true;
                Band.Columns[i].Header.Appearance.FontData.Bold = DefaultableBoolean.True;
                Band.Columns[i].Header.Appearance.TextHAlign = HAlign.Center;
                Band.Columns[i].CellAppearance.TextHAlign = HAlign.Left;
                Band.Columns[i].Header.Appearance.ForeColor = Color.Navy;//x =  //= System.Drawing.w;//RoyalBlue
            }

            int soCot = colNames.Length;
            if (!(soCot > 0 && soCot == colCaptions.Length && soCot == doRongCot.Length && soCot == controls.Length && soCot == kieuDuLieu.Length && soCot == duocEdit.Length))
                return;
            for (int i = 0; i < soCot; i++)
            {
                //using (UltraGridColumn col = Band.Columns[colNames[i]])
                //{
                Band.Columns[colNames[i]].Hidden = false;

                Band.Columns[colNames[i]].Header.Appearance.FontData.Bold = DefaultableBoolean.True;
                Band.Columns[colNames[i]].Header.Appearance.TextHAlign = HAlign.Center;
                Band.Columns[colNames[i]].Header.Appearance.ForeColor = Color.Navy;//x =  //= System.Drawing.w;//RoyalBlue
                Band.Columns[colNames[i]].Header.VisiblePosition = i;
                Band.Columns[colNames[i]].Header.Caption = colCaptions[i];

                Band.Columns[colNames[i]].Width = doRongCot[i];
                if (duocEdit[i])
                    Band.Columns[colNames[i]].CellActivation = Activation.AllowEdit;
                else
                    Band.Columns[colNames[i]].CellActivation = Activation.ActivateOnly;
                switch (kieuDuLieu[i])
                {
                    case KieuDuLieu.Ngay:
                        Band.Columns[colNames[i]].MaskInput = "{LOC}dd/mm/yyyy";
                        Band.Columns[colNames[i]].Format = "dd/MM/yyyy";
                        Band.Columns[colNames[i]].CellAppearance.TextHAlign = HAlign.Center;
                        break;
                    case KieuDuLieu.NgayGio:
                        Band.Columns[colNames[i]].MaskInput = "{LOC}dd/mm/yyyy hh:mm:ss";
                        Band.Columns[colNames[i]].CellAppearance.TextHAlign = HAlign.Center;
                        break;
                    case KieuDuLieu.So:
                        Band.Columns[colNames[i]].MaskInput = "-nnn,nnn,nnn";
                        Band.Columns[colNames[i]].CellAppearance.TextHAlign = HAlign.Right;
                        //Band.Columns[colNames[i]].Format = "###,###,###";
                        break;
                    case KieuDuLieu.KhoiLuong:
                        Band.Columns[colNames[i]].MaskInput = "-nnn,nnn,nnn.nnnn";
                        Band.Columns[colNames[i]].CellAppearance.TextHAlign = HAlign.Right;
                        Band.Columns[colNames[i]].Format = "###,###,##0.###0";
                        break;
                    case KieuDuLieu.TuoiVang:
                        Band.Columns[colNames[i]].MaskInput = "nnn.nn";
                        //Band.Columns[colNames[i]].Format = "##.##";
                        Band.Columns[colNames[i]].CellAppearance.TextHAlign = HAlign.Center;
                        break;
                    case KieuDuLieu.Tien:
                        Band.Columns[colNames[i]].MaskInput = "-nnn,nnn,nnn,nnn,nnn,nnn";
                        Band.Columns[colNames[i]].Format = "###,###,###,###,###,##0";
                        Band.Columns[colNames[i]].CellAppearance.TextHAlign = HAlign.Right;
                        break;
                    case KieuDuLieu.TienLe:
                        Band.Columns[colNames[i]].MaskInput = "-nnn,nnn,nnn,nnn,nnn,nnn.nn";
                        Band.Columns[colNames[i]].Format = "###,###,###,###,###,##0.##";
                        Band.Columns[colNames[i]].CellAppearance.TextHAlign = HAlign.Right;
                        break;
                    case KieuDuLieu.NullCanhGiua:
                        Band.Columns[colNames[i]].MaskInput = string.Empty;
                        Band.Columns[colNames[i]].CellAppearance.TextHAlign = HAlign.Center;
                        break;
                    default:
                        Band.Columns[colNames[i]].MaskInput = string.Empty;
                        Band.Columns[colNames[i]].CellAppearance.TextHAlign = HAlign.Left;
                        break;
                }
                //}
                Band.Columns[colNames[i]].EditorComponent = controls[i];
            }
        }

        public static void EditMotCot(UltraGridColumn ultraColumn, string tenCot, int doRongCot, Control editControl, KieuDuLieu kieuDuLieu, bool duocEdit)
        {
            ultraColumn.Header.Appearance.FontData.Bold = DefaultableBoolean.True;
            ultraColumn.Header.Appearance.TextHAlign = HAlign.Center;
            ultraColumn.CellAppearance.TextHAlign = HAlign.Right;
            ultraColumn.Header.Appearance.ForeColor = Color.Navy;//x =  //= System.Drawing.w;//RoyalBlue

            ultraColumn.Hidden = false;
            //ultraColumn.Header.VisiblePosition = i;
            ultraColumn.Header.Caption = tenCot;
            ultraColumn.Width = doRongCot;
            if (duocEdit)
                ultraColumn.CellActivation = Activation.AllowEdit;
            else
                ultraColumn.CellActivation = Activation.ActivateOnly;
            switch (kieuDuLieu)
            {
                case KieuDuLieu.Ngay:
                    ultraColumn.MaskInput = "{LOC}dd/mm/yyyy";
                    break;
                case KieuDuLieu.So:
                    ultraColumn.MaskInput = "nnnnnnnnn";
                    break;
                case KieuDuLieu.Tien:
                    ultraColumn.MaskInput = "{LOC} nnn,nnn,nnn,nnn.nn";
                    break;
                default:
                    ultraColumn.MaskInput = string.Empty;
                    break;
            }
            ultraColumn.EditorComponent = editControl;
        }

        public static void EditCombo(UltraComboEditor cbm,float start,float end,float index)
        {
            for (float i = start; i <= end; i += index)
                cbm.Items.Add(i.ToString("#,###.000"));
        }
         /// <summary>
        /// Thực thi Stored Procedure có Parameter(s)
        /// </summary>
        /// <param name="spParameters">Các Parameter của Stored Procedured</param>
        /// <param name="spName">Tên của Stored Procedure</param>
        /// <param name="connectionString">Tên chuỗi kết nối cơ sở dữ liệu</param>
        public DataTable ExecStoredProcedure( SqlParameter[] spParameters, string spName,string connectionString)
        {
            //int outputCount = 0;
            SqlCommand command = new SqlCommand() { CommandType = CommandType.StoredProcedure, CommandText = spName, Connection = new SqlConnection(connectionString) };
            for (int i = 0; i < spParameters.Length; i++)
            {
                command.Parameters.AddWithValue(spParameters[i].ParameterName, spParameters[i].Value);
                //if (spParameters[i].Direction == ParameterDirection.Output)
                //    outputCount++;
            }
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            table.TableName = spName + ";1";//+outputCount;
            return table;  

        }
        /// <summary>
        /// Thực thi Stored Procedure không có Parameter
        /// </summary>
        /// </summary>
        /// <param name="spName">Tên của Stored Procedure</param>
        /// <param name="connectionString">Tên chuỗi kết nối cơ sở dữ liệu</param>
        public DataTable ExecStoredProcedure( string spName, string connectionString)
        {

            SqlCommand command = new SqlCommand() { CommandType = CommandType.StoredProcedure, CommandText = spName, Connection = new SqlConnection(connectionString) };
           
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            table.TableName = spName+";1";
            return table;

        }
        /// <summary>
        /// Định dạng ngày giờ mà hiện tại User đang dùng
        /// </summary>
        public enum CurrentDateFormat
        {
            ThangNgayNam ,
            NgayThangNam   
        }
        /// <summary>
        /// Chuẩn hóa chuỗi thành dạng ngày 2 chữ số, tháng 2 chữ số, năm 4 chữ số
        /// </summary>
        /// <param name="ChuoiCanChuanHoa">Chuỗi ngày cần chuẩn hóa</param>
        /// <param name="dateFormat">Định dạng ngày giờ hiện tại mà User đang dùng</param>
        public string NormalizingString(string ChuoiCanChuanHoa, CurrentDateFormat dateFormat)
        {
            string []tempS=ChuoiCanChuanHoa.Split(Char.Parse("/"));
            if (tempS[0].Length == 1)
                tempS[0] = "0" + tempS[0];
            else
            {
                if (dateFormat == CurrentDateFormat.NgayThangNam)
                    if (Convert.ToInt32(tempS[0]) > 31)
                    {
                        MessageBox.Show("Ngày không được lớn hơn 31");
                        return "";
                    }
                if (dateFormat == CurrentDateFormat.ThangNgayNam)
                    if (Convert.ToInt32(tempS[0]) > 12)
                    {
                        MessageBox.Show("Tháng không được lớn hơn 12");
                        return "";
                    }
            }
            if (tempS[1].Length == 1)
                tempS[1] = "0" + tempS[1];
            else
            {
                if (dateFormat == CurrentDateFormat.NgayThangNam)
                    if (Convert.ToInt32(tempS[1]) > 12)
                    {
                        MessageBox.Show("Tháng không được lớn hơn 12");
                        return "";
                    }
                if (dateFormat == CurrentDateFormat.ThangNgayNam)
                    if (Convert.ToInt32(tempS[1]) > 31)
                    {
                        MessageBox.Show("Ngày không được lớn hơn 31");
                        return "";
                    }
            }

            string resultS = string.Format("{0}/{1}/{2}", tempS[0], tempS[1], tempS[2]);
            return resultS;
        }
        /// <summary>
        /// Chuyển chuỗi thành dạng ngày/tháng/năm
        /// </summary>
        /// <param name="dateString">Chuỗi ngày cần chuyển đổi</param>
        /// <param name="dateFormat">Định dạng ngày hiện tại mà User đang dùng</param>
        public string ConvertToddMMyyyy(string dateString,CurrentDateFormat dateFormat)
        {
            string formatted = "";
            dateString = NormalizingString(dateString,dateFormat);
            if (dateString == "")
                return "";
            try
            {
                if (dateFormat == CurrentDateFormat.NgayThangNam)
                {
                    try
                    {
                        formatted = DateTime.ParseExact(dateString, "dd/MM/yyyy", null).ToString("dd/MM/yyyy");
                    }
                    catch
                    {
                        formatted = DateTime.ParseExact(dateString, "dd/MM/yy", null).ToString("dd/MM/yyyy");
                    }
                }
                else if (dateFormat == CurrentDateFormat.ThangNgayNam)
                    try
                    {
                        formatted = DateTime.ParseExact(dateString, "MM/dd/yyyy", null).ToString("dd/MM/yyyy");
                    }
                    catch
                    {
                        formatted = DateTime.ParseExact(dateString, "MM/dd/yy", null).ToString("dd/MM/yyyy");
                    }
            }
            catch
            {
                MessageBox.Show("Chuỗi ngày không đúng ");
            }
            
            return formatted;
        }
        /// <summary>
        /// Hiển thị report
        /// </summary>
        /// <param name="dataset">Dataset chứa các bảng của Report</param>
        /// <param name="rpDoc">Report Document cần hiển thị</param>
        /// <param name="frm">Form hiển thị Report</param>
        /// <param name="ShowDialog">Hiển thị form theo Dialog hay không</param>
        /// <summary>
        public void ShowReport(string[] spNames,string connectionString, ReportDocument rpDoc, frmHienThiReport frm, bool ShowDialog)
        {
            DataTable[] dataTable =new DataTable[spNames.Length];
            int j = 0;
            foreach (string spName in spNames)
            {
                dataTable[j] = ExecStoredProcedure(spName, connectionString);
                j++;
            }
            DataSet dataSet=new DataSet();
            for (int i = 0; i < j; i++)
                dataSet.Tables.Add(dataTable[i]);
            ReportDocument Report = rpDoc;
            Report.SetDataSource(dataSet);
            frm = new frmHienThiReport();
            frm.crytalView_HienThiReport.ReportSource = Report;
            if (ShowDialog)
                frm.ShowDialog();
            else
                frm.Show();
        }
        /// Dùng cho UltraComboEditor, ComboBox; sự kiện KeyPress. blnLimitToList = false: để search items trong List và tránh lỗi nhập dliệu.
        /// </summary>
        /// <param name="cb"></param>
        /// <param name="e"></param>
        /// <param name="blnLimitToList"></param>
        public static void AutoComplete_KeyPress(UltraComboEditor cb, KeyPressEventArgs e, bool blnLimitToList)
        {
            string strFindStr = "";

            if (e.KeyChar == (char)8)
            {
                if (cb.SelectionStart <= 1)
                {
                    cb.Text = "";
                    return;
                }

                if (cb.SelectionLength == 0)
                    strFindStr = cb.Text.Substring(0, cb.Text.Length - 1);
                else
                    strFindStr = cb.Text.Substring(0, cb.SelectionStart - 1);
            }
            else
            {
                if (cb.SelectionLength == 0)
                    strFindStr = cb.Text + e.KeyChar;
                else
                    strFindStr = cb.Text.Substring(0, cb.SelectionStart) + e.KeyChar;
            }

            int intIdx = -1;

            // Search the string in the ComboBox list.

            intIdx = cb.FindString(strFindStr);

            if (intIdx != -1)
            {
                cb.SelectedText = "";
                cb.SelectedIndex = intIdx;
                cb.SelectionStart = strFindStr.Length;
                cb.SelectionLength = cb.Text.Length;
                e.Handled = true;
            }
            else
            {
                e.Handled = blnLimitToList;
            }

        }
        #region kiểm tra địa chỉ Email
        public  bool KiemTraDiaChiEmail(string text)
        {
            const string temp = @"^([a-zA-Z0-9_\-])([a-zA-Z0-9_\-\.]*)@(\[((25[0-5]|2[0-4][0-9]|1[0-9][0-9]|[1-9][0-9]|[0-9])\.){3}|((([a-zA-Z0-9\-]+)\.)+))([a-zA-Z]{2,}|(25[0-5]|2[0-4][0-9]|1[0-9][0-9]|[1-9][0-9]|[0-9])\])$";
            Regex regexTest = new Regex(temp);
            return regexTest.IsMatch(text);

        }
        #endregion
        public static bool KiemTraLaSo(string s)
        {
            
            for (int i = 0; i < s.Length; i++)
            {
                if (!char.IsWhiteSpace(s[i]))
                {
                    if (!char.IsDigit(s[i]))
                        return false;
                }
            }
            return true;
        }
        public static bool KiemTraLaKyTu(string s)
        {
            if (s.Length > 0)
            {
                for (int i = 0; i < s.Length; i++)
                {
                    if (!char.IsWhiteSpace(s[i]))
                    {
                        if (!char.IsLetter(s[i]))
                            return false;
                    }
                }
            }
            return true;
        }
        public static bool KiemTraKyTuDacBiet(string s)
        {
            for (int i = 0; i < s.Length; i++)
            {
                if (!char.IsWhiteSpace(s[i]))
                {
                    if (!char.IsLetterOrDigit(s[i]))
                        return false;
                }
            }
            return true;
        }
        #region Các event của lưới
        /// <summary> Các Sự kiện của lưới: Error,...
        /// Các Sự kiện của lưới: Error,...
        /// </summary>
        /// <param name="_ultraGrid"></param>
        public void EventGrid(UltraGrid _ultraGrid)
        {
            //_ultraGrid.Error += new  ErrorEventHandler(_ultraGrid_Error);
            _ultraGrid.Error += new Infragistics.Win.UltraWinGrid.ErrorEventHandler(_ultraGrid_Error);
            // _ultraGrid.KeyDown +=new KeyEventHandler(_ultraGrid_KeyDown);

        }

        //void _ultraGrid_KeyDown(object sender, KeyEventArgs e)
        //{
        //    throw new Exception("The method or operation is not implemented.");
        //}

        void _ultraGrid_Error(object sender,Infragistics.Win.UltraWinGrid.ErrorEventArgs e)
        {
            if (e.ErrorType == ErrorType.Data)
            {
                e.ErrorText = "Kiểu dữ liệu không hợp lệ";
                return;
            }
        }

        #endregion 

        #region Cac event của Form
        /// <summary>Các Sự kiện của Form: KeyDown,...
        /// Các Sự kiện của Form: KeyDown,...
        /// </summary>
        /// <param name="_form"></param>
        public void EventForm(Form _form)
        {

            _form.KeyDown += new KeyEventHandler(_form_KeyDown);
            _form.KeyUp += new KeyEventHandler(_form_KeyUp);
            foreach (Control col in _form.Controls)
            {
                col.BackColor = Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(223)))), ((int)(((byte)(247))))); ;
                //ControlSetFocus(col);
                //ControlSelect(col);

                if (!(col is Button) && !(col is Infragistics.Win.Misc.UltraButton))
                {
                    col.GotFocus += new EventHandler(col_GotFocus);
                    foreach (Control col1 in col.Controls)
                    {
                        col1.BackColor = Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(223)))), ((int)(((byte)(247)))));
                        //ControlSetFocus(col1);
                        //ControlSelect(col1);
                        if (!(col1 is Button) && !(col1 is Infragistics.Win.Misc.UltraButton))
                            col1.GotFocus += new EventHandler(col_GotFocus);
                        //foreach (Control col2 in col1.Controls) // Không nhất thiết phải xuống lưới
                        //{
                        //    col2.GotFocus += new EventHandler(col_GotFocus);
                        //}
                    }
                }
                if (col is TextBox)
                {
                    ((TextBox)col).Focus();
                    ((TextBox)col).Select();
                    ((TextBox)col).SelectAll();
                }
                if (col is Infragistics.Win.UltraWinEditors.UltraCurrencyEditor)
                {
                    ((Infragistics.Win.UltraWinEditors.UltraCurrencyEditor)col).Focus();
                    ((Infragistics.Win.UltraWinEditors.UltraCurrencyEditor)col).Select();
                    ((Infragistics.Win.UltraWinEditors.UltraCurrencyEditor)col).SelectAll();
                }
                if (col is Infragistics.Win.UltraWinEditors.UltraDateTimeEditor)
                {
                    ((Infragistics.Win.UltraWinEditors.UltraDateTimeEditor)col).Focus();
                    ((Infragistics.Win.UltraWinEditors.UltraDateTimeEditor)col).Select();
                    ((Infragistics.Win.UltraWinEditors.UltraDateTimeEditor)col).SelectAll();
                }
            }
        }

        void _form_KeyUp(object sender, KeyEventArgs e)
        {

        }

        public void ControlSetFocus(Control control)
        {
            // Set focus to the control, if it can receive focus.
            if (control.CanFocus)
            {
                control.Focus();
            }
        }
        public void ControlSelect(Control control)
        {
            // Select the control, if it can be selected.
            if (control.CanSelect)
            {
                control.Select();
            }
        }

        void col_GotFocus(object sender, EventArgs e)
        {
            if ((sender is TextBox) || (sender is Infragistics.Win.UltraWinEditors.UltraCurrencyEditor))
            {
                if (sender is TextBox)
                {
                    ((TextBox)sender).Focus();
                    ((TextBox)sender).Select();
                    ((TextBox)sender).SelectAll();
                }
                if (sender is Infragistics.Win.UltraWinEditors.UltraCurrencyEditor)
                {
                    ((Infragistics.Win.UltraWinEditors.UltraCurrencyEditor)sender).Focus();
                    ((Infragistics.Win.UltraWinEditors.UltraCurrencyEditor)sender).Select();
                    ((Infragistics.Win.UltraWinEditors.UltraCurrencyEditor)sender).SelectAll();
                }
            }
            else
                SendKeys.Send("%{DOWN}");
        }

        void _form_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SendKeys.Send("{TAB}");
        }

        public void EventsControl(Control ctr)
        {
            ctr.GotFocus += new EventHandler(ctr_GotFocus);
        }

        void ctr_GotFocus(object sender, EventArgs e)
        {
            SendKeys.Send("%{DOWN}");
        }

        #endregion 
        #region hàm dùng để chình layout của nhiều lười

        public void EditUltraGrid(UltraGrid grid)
        {
            foreach (UltraGridBand band in grid.DisplayLayout.Bands)
            {
                foreach (UltraGridColumn col in band.Columns)
                {

                    col.Header.Appearance.FontData.Bold = DefaultableBoolean.True;
                    col.Header.Appearance.TextHAlign = HAlign.Center;
                    col.Header.Appearance.ForeColor = Color.Navy;//x =  //= System.Drawing.w;//RoyalBlue
                }
            }
            grid.DisplayLayout.Override.HeaderAppearance.BackColor = Color.SteelBlue;
            grid.DisplayLayout.Override.HeaderStyle = HeaderStyle.WindowsXPCommand;
        }

          #endregion

        /// <summary>
        /// Cài đặt các cột cần hiển thị trong khung lưới
        /// </summary>
        /// <param name="band">Band chứa các column</param>
        /// <param name="col">Tên các column (key, field) cần hiển thị</param>
        public static void VisibleColumn(UltraGridBand band, params string[] col)
        {
            bool b;
            foreach (UltraGridColumn c in band.Columns)
            {
                b = false;
                foreach (string s in col)
                    if (s == c.Key) b = true;
                c.Hidden = !b;
            }
        }
        public static void ExportToExcel(UltraGrid grid)
        {
            try
            {
                SaveFileDialog sf = new SaveFileDialog() { Filter = "Excel files |*.xls" };
                sf.ShowDialog();
                
                Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter exporter = new Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter();
                string filePath = sf.FileName; //opf.FileName;
                if (filePath.Length > 0)
                {
                    exporter.Export(grid, filePath);
                    MessageBox.Show("Export thành công!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Process.Start(filePath);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //By Loc xu ly truong hop cac hoa don dich vu so tu tang
        public static int LaySoHoaDon(ref string _sokh, ref string _sohd)
        {
            int _tuso = 0, _denso = 0, _kiemtra = 0;
            CapPhatHoaDonList _caphd = CapPhatHoaDonList.GetCapPhatHoaDonList();
            if (_caphd.Count != 0)
            {
                _tuso = _caphd[0].TuSo;
                _denso = _caphd[0].DenSo;
            }
            object _obj;
            using (SqlConnection cn = new SqlConnection(ERP_Library.Database.ERP_Connection))
            {
                cn.Open();
                {
                    using (SqlCommand cm = cn.CreateCommand())
                    {
                        cm.CommandType = CommandType.StoredProcedure;
                        cm.CommandText = "spd_GetSoHoaDonLonNhatAll";
                        _obj = cm.ExecuteScalar();
                    }
                }
            }
            // kiem tra cac truong hop cua hoa don tu tang 
            bool isnum;
            int Num;
            isnum = int.TryParse(_obj.ToString(), out Num);
            if (isnum)
            {
                if (Convert.ToInt32(_obj) > _denso || Convert.ToInt32(_obj) < _tuso)
                    _kiemtra = 1; // Nam ngoai khoang so hoa don duoc cap.
                // 1 So hoa don tang khong nam trong khoang tang             
                if (_caphd.Count != 0)
                    _sokh = _caphd[0].KyHieu;
                _sohd = Convert.ToString(Convert.ToInt32(_obj.ToString()) + 1);

                if (_sohd.Length < 6)
                    for (int i = 0; i <= 6 - _sohd.Length; i++)
                    {
                        _sohd = "0" + _sohd;
                    }
            }
            else
            {
                _sohd = "";
            }
            return _kiemtra;
        }
        
        // hàm nay dùng để chuyển tiêng việt sang tiếng anh
        public static string ConvertToUnSign(string text)
        {

            for (int i = 33; i < 48; i++)
            {

                text = text.Replace(((char)i).ToString(), "");

            }



            for (int i = 58; i < 65; i++)
            {

                text = text.Replace(((char)i).ToString(), "");

            }



            for (int i = 91; i < 97; i++)
            {

                text = text.Replace(((char)i).ToString(), "");

            }

            for (int i = 123; i < 127; i++)
            {

                text = text.Replace(((char)i).ToString(), "");

            }

            text = text.Replace(" ", " ");

            Regex regex = new Regex(@"\p{IsCombiningDiacriticalMarks}+");

            string strFormD = text.Normalize(System.Text.NormalizationForm.FormD);

            return regex.Replace(strFormD, String.Empty).Replace('\u0111', 'd').Replace('\u0110', 'D');

        }

        public static void CopyCell(GridView grid, KeyEventArgs e)
        {
            if (e.Modifiers == Keys.Control && e.KeyCode == Keys.V)
            {
                IDataObject iData = Clipboard.GetDataObject();
                if (iData.GetDataPresent(DataFormats.UnicodeText))
                {
                    string text = (string)iData.GetData(DataFormats.UnicodeText);
                    Array.ForEach(grid.GetSelectedCells(), cell =>
                    {
                        try
                        {
                            cell.Column.View.SetRowCellValue(cell.RowHandle, cell.Column, text);
                            cell.Column.View.RefreshData();
                        }
                        catch { return; }
                    });
                }
            }
        }

        #region Devexpress

        public static void InitGridViewDev(GridView grid, bool autoFilter, bool multiSelect,
            GridMultiSelectMode selectMode, bool detailButton, bool groupPanel,
            bool showAutoFilterRow, bool showFooter)
        {
            grid.CopyToClipboard();
            //Show filter
            grid.OptionsView.ShowAutoFilterRow = autoFilter;
            //Show multi select
            grid.OptionsSelection.MultiSelect = multiSelect;
            //Show multi select mode
            grid.OptionsSelection.MultiSelectMode = selectMode;
            //Show detail button
            grid.OptionsView.ShowDetailButtons = detailButton;
            //Show group panel
            grid.OptionsView.ShowGroupPanel = groupPanel;
            //Show auto filter row
            grid.OptionsView.ShowAutoFilterRow = showAutoFilterRow;
            //Show footer
            grid.OptionsView.ShowFooter = showFooter;

            for (int i = 0; i < grid.Columns.Count; i++)
                grid.Columns[i].Visible = false;
            
        }//End InitGridView

        public static void ShowFieldGridViewDev(GridView grid, string[] fieldName, string[] caption, int[] width)
        {
            for (int i = 0; i < grid.Columns.Count; i++)
                grid.Columns[i].Visible = false;

            grid.OptionsView.ColumnAutoWidth = true;
            for (int i = 0; i < fieldName.Length; i++)
            {
                grid.Columns[fieldName[i]].VisibleIndex = i;
                grid.Columns[fieldName[i]].Visible = true;
                grid.Columns[fieldName[i]].Caption = caption[i];
                grid.Columns[fieldName[i]].Width = width[i];
                grid.Columns[fieldName[i]].OptionsFilter.AutoFilterCondition = AutoFilterCondition.Contains;
            }
        }
        public static void ShowFieldGridViewDev2(GridView grid, string[] fieldName, string[] caption, int[] width, bool autoWidth)
        {
            for (int i = 0; i < grid.Columns.Count; i++)
                grid.Columns[i].Visible = false;

            grid.OptionsView.ColumnAutoWidth = autoWidth;
            for (int i = 0; i < fieldName.Length; i++)
            {
                grid.Columns[fieldName[i]].VisibleIndex = i;
                grid.Columns[fieldName[i]].Visible = true;
                grid.Columns[fieldName[i]].Caption = caption[i];
                grid.Columns[fieldName[i]].Width = width[i];
                grid.Columns[fieldName[i]].OptionsFilter.AutoFilterCondition = AutoFilterCondition.Contains;
            }
        }
        public static void ShowFieldGridViewDev_Modify(GridView grid, string[] fieldName, string[] caption, int[] width, bool autoWidth)
        {
            grid.Columns.Clear();
            grid.OptionsView.ColumnAutoWidth = autoWidth;
            for (int i = 0; i < fieldName.Length; i++)
            {
                GridColumn col = new DevExpress.XtraGrid.Columns.GridColumn();
                col.Caption = "Tên";
                col.FieldName = fieldName[i];
                col.Name = "col" + fieldName[i];

                col.VisibleIndex = i;
                col.Visible = true;
                col.Caption = caption[i];
                col.Width = width[i];
                col.OptionsFilter.AutoFilterCondition = AutoFilterCondition.Contains;
                grid.Columns.Add(col);
            }
        }

        public static void FormatNumberTypeofColumnGridViewDev(GridView grid, string[] fieldName)
        {
            for (int i = 0; i < fieldName.Length; i++)
            {
                grid.Columns[fieldName[i]].DisplayFormat.FormatString = "#,###";
                grid.Columns[fieldName[i]].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            }

        }

        public static void FormatNumberTypeofColumnGridViewDev2(GridView grid, string[] fieldName,string S_format)
        {
            for (int i = 0; i < fieldName.Length; i++)
            {
                grid.Columns[fieldName[i]].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                grid.Columns[fieldName[i]].DisplayFormat.FormatString = S_format;
            }

        }

        public static void ShowSummaryFooterofColumnGridViewDev(GridView grid, string[] fieldName)
        {
            for (int i = 0; i < fieldName.Length; i++)
            {
                grid.Columns[fieldName[i]].Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, fieldName[i], "{0:N0}")});
            }
        }

        public static void ShowSummaryFooterofColumnGridViewDev2(GridView grid, string[] fieldName, string S_format)
        {
            for (int i = 0; i < fieldName.Length; i++)
            {
                grid.Columns[fieldName[i]].Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, fieldName[i], S_format)});
            }
        }

        public static void ReadOnlyColumnGridViewDev(GridView grid)
        {
            for (int i = 0; i < grid.Columns.Count; i++)
                grid.Columns[i].OptionsColumn.AllowEdit = false;
        }

        public static void AllowEditColumnGridViewDev(GridView grid)
        {
            for (int i = 0; i < grid.Columns.Count; i++)
                grid.Columns[i].OptionsColumn.AllowEdit = true;
        }

        public static void ReadOnlyColumnChoseGridViewDev(GridView grid, string[] fieldName)
        {
            for (int i = 0; i < fieldName.Length; i++)
            {
                grid.Columns[fieldName[i]].OptionsColumn.AllowEdit = false;
            }
        }

        public static void AllowEditColumnChooseGridViewDev(GridView grid, string[] fieldName)
        {
            for (int i = 0; i < fieldName.Length; i++)
            {
                grid.Columns[fieldName[i]].OptionsColumn.AllowEdit = true;
            }
        }

        public static void AlignHeaderColumnGridViewDev(GridView grid, string[] fieldName, DevExpress.Utils.HorzAlignment align)
        {
            for (int i = 0; i < fieldName.Length; i++)
                grid.Columns[fieldName[i]].AppearanceHeader.TextOptions.HAlignment = align;
        }

        public static void NewRowGridViewDev(GridView grid)
        {
            grid.Appearance.Row.Font = new Font("Times New Roman", 11F);
            grid.Appearance.Row.Options.UseFont = true;
            grid.Appearance.TopNewRow.Options.UseTextOptions = true;
            grid.Appearance.TopNewRow.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            grid.Appearance.ViewCaption.Font = new Font("Times New Roman", 11F);
            grid.Appearance.ViewCaption.Options.UseFont = true;
            grid.NewItemRowText = "Thêm dòng mới";
            grid.OptionsView.NewItemRowPosition = NewItemRowPosition.Top;

        }

        public static void NewRowGridViewDev(GridView grid, NewItemRowPosition position)
        {
            grid.Appearance.Row.Font = new Font("Times New Roman", 11F);
            grid.Appearance.Row.Options.UseFont = true;
            grid.Appearance.TopNewRow.Options.UseTextOptions = true;
            grid.Appearance.TopNewRow.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            grid.Appearance.ViewCaption.Font = new Font("Times New Roman", 11F);
            grid.Appearance.ViewCaption.Options.UseFont = true;
            grid.NewItemRowText = "Thêm dòng mới";
            grid.OptionsView.NewItemRowPosition = position;

        }

        public static void AddColumnToGridViewDev(GridView grid, string[] fieldName, string[] caption, string S_format)
        {
            GridColumn[] gridColumList = new GridColumn[fieldName.Length];
            //int index=indexStart;
            for (int i = 0; i < fieldName.Length; i++)
            {
                //index+=1;
                gridColumList[i].FieldName = fieldName[i];
                gridColumList[i].Caption = caption[i];
                //gridColumList[i].VisibleIndex = index;
                gridColumList[i].Visible = true;
                gridColumList[i].DisplayFormat.FormatString = S_format;
                gridColumList[i].OptionsFilter.AutoFilterCondition = AutoFilterCondition.Contains;
                grid.Columns.Add(gridColumList[i]);
            }
        }
        public static void HideOrShowColumnofGridViewDev(GridView grid, string[] fieldName, bool[] show)
        {
           
            for (int i = 0; i < fieldName.Length; i++)
            {
                grid.Columns[fieldName[i]].Visible = show[i];
            }
        }

        /// <summary>
        /// Delete data
        /// </summary>
        /// <param name="grid"></param>
        /// <param name="e"></param>
        public static bool DeleteSelectedRowsGridViewDev(GridView grid, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                if (grid.RowCount > 0)
                {
                    if (grid.GetSelectedRows().Length > 0)
                    {
                        if (XtraMessageBox.Show(String.Format("Bạn có chắc muốn xóa {0} dòng đang chọn ?", grid.GetSelectedRows().Length), "Xác Nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            grid.DeleteSelectedRows();
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// Delete data
        /// </summary>
        /// <param name="grid"></param>
        public static bool DeleteSelectedRowsGridViewDev(GridView grid)
        {
            if (grid.RowCount > 0)
            {
                if (grid.GetSelectedRows().Length > 0)
                {
                    if (XtraMessageBox.Show(String.Format("Bạn có muốn xóa {0} dòng được chọn không?", grid.GetSelectedRows().Length), "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        grid.DeleteSelectedRows();
                        return true;
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// Attach control RepositoryItem
        /// </summary>
        /// <param name="grid"></param>
        /// <param name="fieldName"></param>
        /// <param name="item"></param>
        public static void RegisterControlFieldGridViewDev(GridView grid, string fieldName, RepositoryItem item)
        {
            grid.Columns[fieldName].ColumnEdit = item;
        }

        /// <summary>
        /// Attach control RepositoryItem
        /// </summary>
        /// <param name="grid"></param>
        /// <param name="fieldName"></param>
        /// <param name="item"></param>
        public static void RegisterControlFieldGridViewDev(GridView grid, string fieldName, RepositoryItemDateEdit item)
        {
            grid.Columns[fieldName].ColumnEdit = item;
        }

        /// <summary>
        /// Attach control RepositoryItem
        /// </summary>
        /// <param name="grid"></param>
        /// <param name="fieldName"></param>
        /// <param name="item"></param>
        public static void RegisterControlFieldGridViewDev(GridView grid, string fieldName, RepositoryItemTextEdit item)
        {
            grid.Columns[fieldName].ColumnEdit = item;
        }

        /// <summary>
        /// Attach control RepositoryItem
        /// </summary>
        /// <param name="grid"></param>
        /// <param name="fieldName"></param>
        /// <param name="item"></param>
        public static void RegisterControlFieldGridViewDev(GridView grid, string fieldName, RepositoryItemGridLookUpEdit item)
        {
            grid.Columns[fieldName].ColumnEdit = item;
        }

        /// <summary>
        /// Init
        /// </summary>
        /// <param name="grid"></param>
        /// <param name="autoFilter"></param>
        public static void InitGridLookUpDev(GridLookUpEdit grid, bool autoFilter, TextEditStyles textEditStyle)
        {
            //Show filter
            grid.Properties.View.OptionsView.ShowAutoFilterRow = autoFilter;
            grid.Properties.TextEditStyle = textEditStyle;
            grid.Properties.PopupFilterMode = PopupFilterMode.Contains;
            //grid.Properties.BestFitMode = BestFitMode.BestFit;
            for (int i = 0; i < grid.Properties.View.Columns.Count; i++)
                grid.Properties.View.Columns[i].Visible = false;
        }

        public static void InitGridLookUpDev2(GridLookUpEdit grid, object datasource, string displaymember, string valuemember, string nulltext, bool autoFilter, bool autoPopup, TextEditStyles textEditStyle)
        {
            grid.Properties.DataSource = datasource;
            grid.Properties.DisplayMember = displaymember;
            grid.Properties.ValueMember = valuemember;
            grid.Properties.NullText = nulltext;
            //Show filter
            //grid.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains;//
            //grid.View.OptionsBehavior.AutoPopulateColumns = false;//
            //grid.View.OptionsView.ShowAutoFilterRow = true;//

            
            grid.Properties.PopupFilterMode = PopupFilterMode.Contains;
            grid.Properties.View.OptionsBehavior.AutoPopulateColumns = false;
            grid.Properties.View.OptionsView.ShowAutoFilterRow = autoFilter;
            grid.Properties.TextEditStyle = textEditStyle;
            grid.Properties.ImmediatePopup = autoPopup;
            //grid.Properties.BestFitMode = BestFitMode.BestFit;
            for (int i = 0; i < grid.Properties.View.Columns.Count; i++)
                grid.Properties.View.Columns[i].Visible = false;
        }

        /// <summary>
        /// Show field
        /// </summary>
        /// <param name="grid"></param>
        /// <param name="fieldName"></param>
        /// <param name="caption"></param>
        /// <param name="width"></param>
        /// 
        public static void ShowFieldGridLookUpDev(GridLookUpEdit grid, string[] fieldName, string[] caption, int[] width)
        {
            grid.Properties.View.OptionsView.ColumnAutoWidth = false;
            for (int i = 0; i < fieldName.Length; i++)
            {
                grid.Properties.View.Columns.AddField(fieldName[i]);
                grid.Properties.View.Columns[fieldName[i]].Visible = true;
                grid.Properties.View.Columns[fieldName[i]].Caption = caption[i];
                grid.Properties.View.Columns[fieldName[i]].Width = width[i];
                grid.Properties.View.Columns[fieldName[i]].OptionsFilter.AutoFilterCondition = AutoFilterCondition.Contains;
            }
        }

        public static void ShowFieldGridLookUpDev2(GridLookUpEdit grid, string[] fieldName, string[] caption, int[] width, bool columnAutoWidth)
        {
            grid.Properties.View.OptionsView.ColumnAutoWidth = columnAutoWidth;
            for (int i = 0; i < fieldName.Length; i++)
            {
                grid.Properties.View.Columns.AddField(fieldName[i]);
                grid.Properties.View.Columns[fieldName[i]].Visible = true;
                grid.Properties.View.Columns[fieldName[i]].Caption = caption[i];
                grid.Properties.View.Columns[fieldName[i]].Width = width[i];
                grid.Properties.View.Columns[fieldName[i]].OptionsFilter.AutoFilterCondition = AutoFilterCondition.Contains;
            }
        }

        /// <summary>
        /// Hiden field
        /// </summary>
        /// <param name="grid"></param>
        /// <param name="fieldName"></param>
        public static void HideFieldGridLookUpDev(GridLookUpEdit grid, string[] fieldName)
        {
            for (int i = 0; i < fieldName.Length; i++)
                grid.Properties.View.Columns[fieldName[i]].Visible = false;
        }

        /// <summary>
        /// Initialize for RepositoryItemGridLookUp
        /// </summary>
        /// <param name="grid"></param>
        /// <param name="autoFilter"></param>
        /// <param name="autoPopup"></param>
        /// <param name="textEditStyle"></param>
        public static void InitRepositoryItemGridLookUpDev(RepositoryItemGridLookUpEdit grid, bool autoPopup, TextEditStyles textEditStyle)
        {
            //Show filter
            grid.View.OptionsView.ShowAutoFilterRow = true;
            grid.View.OptionsSelection.EnableAppearanceFocusedCell = false;
            grid.View.OptionsView.ShowGroupPanel = false;
            grid.View.FocusRectStyle = DrawFocusRectStyle.CellFocus;
            grid.TextEditStyle = textEditStyle;
            grid.ImmediatePopup = autoPopup;
            grid.PopupFilterMode = PopupFilterMode.Default; //contains: filter cột DisplayMember; //Default: filter all cột
            grid.NullText = "";
            //grid.BestFitMode = BestFitMode.BestFit;
            for (int i = 0; i < grid.View.Columns.Count; i++)
                grid.View.Columns[i].Visible = false;
        }

        public static void InitRepositoryItemGridLookUpDev2(RepositoryItemGridLookUpEdit grid, object datasource, string displaymember, string valuemember, string nulltext, bool autoPopup, TextEditStyles textEditStyle)
        {
            grid.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains;//
            grid.View.OptionsBehavior.AutoPopulateColumns = false;//
            grid.DataSource = datasource;
            grid.DisplayMember = displaymember;
            grid.ValueMember = valuemember;

            //Show filter
            grid.View.OptionsView.ShowAutoFilterRow = true;//
            //grid.View.OptionsSelection.EnableAppearanceFocusedCell = false;
            //grid.View.OptionsView.ShowGroupPanel = false;
            //grid.View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.CellFocus;
            grid.TextEditStyle = textEditStyle;
            grid.ImmediatePopup = autoPopup;//
            //grid.PopupFilterMode = PopupFilterMode.Default; //contains: filter cột DisplayMember; //Default: filter all cột
            grid.NullText = nulltext;
            //grid.BestFitMode = BestFitMode.BestFit;
            for (int i = 0; i < grid.View.Columns.Count; i++)
                grid.View.Columns[i].Visible = false;
        }

        public static void InitRepositoryItemTreeListLookUpEdit(RepositoryItemTreeListLookUpEdit grid, object datasource, string displaymember, string valuemember,string parentFieldName, string nulltext, bool autoPopup, TextEditStyles textEditStyle)
        {
            grid.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains;//
            grid.TreeList.OptionsBehavior.AutoPopulateColumns = false;
            grid.DataSource = datasource;
            grid.DisplayMember = displaymember;
            grid.ValueMember = valuemember;
            grid.TreeList.ParentFieldName = parentFieldName;
            grid.TreeList.KeyFieldName = valuemember;
            //Show filter
            grid.TreeList.OptionsView.ShowAutoFilterRow = true;//
            //grid.View.OptionsSelection.EnableAppearanceFocusedCell = false;
            //grid.View.OptionsView.ShowGroupPanel = false;
            //grid.View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.CellFocus;
            grid.TextEditStyle = textEditStyle;
            grid.ImmediatePopup = autoPopup;//
            //grid.PopupFilterMode = PopupFilterMode.Default; //contains: filter cột DisplayMember; //Default: filter all cột
            grid.NullText = nulltext;
            //grid.BestFitMode = BestFitMode.BestFit;
            for (int i = 0; i < grid.TreeList.Columns.Count; i++)
                grid.TreeList.Columns[i].Visible = false;
        }

        /// <summary>
        /// Show field with caption, width
        /// </summary>
        /// <param name="grid"></param>
        /// <param name="fieldName"></param>
        /// <param name="caption"></param>
        /// <param name="width"></param>
        public static void ShowFieldRepositoryItemGridLookUpDev(RepositoryItemGridLookUpEdit grid, string[] fieldName, string[] caption, int[] width, bool autoWidth)
        {
            grid.View.OptionsView.ColumnAutoWidth = autoWidth;
            for (int i = 0; i < fieldName.Length; i++)
            {
                grid.View.Columns.AddField(fieldName[i]);
                grid.View.Columns[fieldName[i]].Visible = true;
                grid.View.Columns[fieldName[i]].Caption = caption[i];
                grid.View.Columns[fieldName[i]].Width = width[i];
                grid.View.Columns[fieldName[i]].OptionsFilter.AutoFilterCondition = AutoFilterCondition.Contains;
            }
        }

        public static void ShowFieldRepositoryItemTreeListLookUpEdit(RepositoryItemTreeListLookUpEdit grid, string[] fieldName, string[] caption, int[] width, bool autoWidth)
        {
            grid.TreeList.OptionsView.AutoWidth = autoWidth;
            grid.TreeList.OptionsFilter.FilterMode = DevExpress.XtraTreeList.FilterMode.Smart;
            grid.TreeList.OptionsBehavior.EnableFiltering = true;
            grid.TreeList.OptionsBehavior.PopulateServiceColumns = true;
            for (int i = 0; i < fieldName.Length; i++)
            {
                grid.TreeList.Columns.AddField(fieldName[i]);
                grid.TreeList.Columns[fieldName[i]].Visible = true;
                grid.TreeList.Columns[fieldName[i]].Caption = caption[i];
                grid.TreeList.Columns[fieldName[i]].Width = width[i];
                grid.TreeList.Columns[fieldName[i]].OptionsFilter.AutoFilterCondition = DevExpress.XtraTreeList.Columns.AutoFilterCondition.Contains;
                
            }
        }

        public static void AddButtonForRepositoryItemGridLookUpDev(RepositoryItemGridLookUpEdit grid)
        {
            grid.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            //new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo),
            new DevExpress.XtraEditors.Controls.EditorButton(ButtonPredefines.Undo)});
        }

        public static void ExportToExcelFromGridViewDev(GridView grid)
        {
            SaveFileDialog dlg = new SaveFileDialog() { Filter = "Excel File (*.xls)|.xls|All file (*.*)|.*" };
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                grid.ExportToXls(dlg.FileName);
                OpenFile(dlg.FileName);
            }

        }

        private static void OpenFile(string filePath)
        {
            string fileName = Path.GetFileName(filePath);
            if (MessageBox.Show(string.Format("Bạn có muốn mở file '{0}' không?", fileName), "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                Process.Start(filePath);
            }
        }
        #region Treelist
        #endregion//Treelist

        #endregion//Devexpress

        public static void KiemTraKhoaTaiKhoan(tblButToan butToan, GridLookUpEdit gridLUED, tblTaiKhoan taiKhoan, DateTime ngay, int userID, bool laNo)
        {
             Int64 maTaiKhoanCu;
             if (laNo)
                 maTaiKhoanCu = butToan.NoTaiKhoan ?? 0;
             else
                 maTaiKhoanCu = butToan.CoTaiKhoan ?? 0;
            if (taiKhoan != null)
            {
                tblKy ky = Ky_Factory.New().XacDinhKy_ByNgay(ngay);
                if (TaiKhoan_Factory.New().DaKhoaTaiKhoan(ky.MaKy, userID, taiKhoan.MaTaiKhoan))
                {
                    DialogUtil.ShowWarning("Tài khoản đã được khóa trong kỳ!\nVui lòng liên hệ người khóa tài khoản để thực hiện tiếp nghiệp vụ", "Cảnh báo");
                    gridLUED.EditValue = maTaiKhoanCu;
                }
            }
        }
        #region ReadNumeric
        public static string ReadNumeric(decimal NumCurrency)
        {
            string SoRaChu = "";
            NumCurrency = Math.Abs(NumCurrency);
            if (NumCurrency == 0)
            {
                SoRaChu = "Không";
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

            DonViTien = "";
            DonViLe = "";


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
                        Ten = "ngàn tỷ";
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
                        Ten = "ngàn";
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
                    BangChu = BangChu.Trim() + (BangChu.Length == 0 ? "" : " ") + (Tram != 0 ? CharVND[Tram].Trim() + " trăm " : "");
                    // if (Muoi == 0 & Tram != 0 & DonVi != 0)

                    //if (Tram != 0 & Muoi == 0 & DonVi == 0 & BangChu != "")
                    //    BangChu = BangChu + " trăm ";
                    if (Muoi == 0 & Tram == 0 & DonVi != 0 & BangChu != "")
                        BangChu = BangChu + "không trăm ";
                    else if (Muoi != 0 & Tram == 0 & (DonVi == 0 || DonVi != 0) & BangChu != "")
                        BangChu = BangChu + "không trăm ";
                    else if (Muoi == 0 & Tram != 0 & DonVi != 0 & BangChu != "")
                        BangChu = BangChu + " ";
                    if (Muoi != 0 & Muoi > 0)
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
    }
}
