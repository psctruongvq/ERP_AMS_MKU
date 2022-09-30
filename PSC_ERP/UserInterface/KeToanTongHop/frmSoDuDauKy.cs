using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ERP_Library;
using Infragistics.Win.UltraWinGrid;
using Infragistics.Win;
//long

namespace PSC_ERP
{
    public partial class frmSoDuDauKy : Form
    {
        SoDuDauKyList _SoDuDauKyList;
        SoDuDauKy _SoDuDauKy;
        int _maKy = 0;

        
        public frmSoDuDauKy()
        {
            InitializeComponent();
            KhoiTao();
        }

        private void KhoiTao()
        {
            kyListBindingSource.DataSource = KyList.GetKyList();           
        }        

        private void ubtLuu_Click(object sender, EventArgs e)
        {
            _SoDuDauKyList.ApplyEdit();
            _SoDuDauKyList.Save();
            MessageBox.Show(this, "Cập Nhật Thành Công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void bt_NhapSoDu_Click(object sender, EventArgs e)
        {
            if (cbu_KyKetChuyen.Value != null)
                _maKy = Convert.ToInt32(cbu_KyKetChuyen.Value);
            _SoDuDauKyList = SoDuDauKyList.GetSoDuDauKyListByMaKy(_maKy, ERP_Library.Security.CurrentUser.Info.MaBoPhan);
            SoDuDauKyListBindingSource.DataSource = _SoDuDauKyList;

        
        }

        private void ultraGrid_SoDuDauKy_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            foreach (UltraGridBand band in this.ultraGrid_SoDuDauKy.DisplayLayout.Bands)
            {
                foreach (UltraGridColumn column in band.Columns)
                {
                    if (column.DataType.ToString() == "System.Decimal")
                    {
                        column.CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                        column.Format = "###,###,###";
                    }
                }
            }
        }

        private void ubtThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbu_KyKetChuyen_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            this.cbu_KyKetChuyen.DisplayLayout.Override.HeaderStyle = HeaderStyle.WindowsXPCommand;
            this.cbu_KyKetChuyen.DisplayLayout.Override.HeaderAppearance.BackColor = System.Drawing.Color.SteelBlue;
            foreach (UltraGridColumn col in this.cbu_KyKetChuyen.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;
                col.Hidden = true;
                //x =  //= System.Drawing.w;//RoyalBlue
            }
            cbu_KyKetChuyen.DisplayLayout.Bands[0].Columns["MaKy"].Header.Caption = "Mã Kỳ";
            cbu_KyKetChuyen.DisplayLayout.Bands[0].Columns["MaKy"].Header.VisiblePosition = 1;
            cbu_KyKetChuyen.DisplayLayout.Bands[0].Columns["MaKy"].Hidden = false;

            cbu_KyKetChuyen.DisplayLayout.Bands[0].Columns["TenKy"].Header.Caption = "Tên Kỳ";
            cbu_KyKetChuyen.DisplayLayout.Bands[0].Columns["TenKy"].Header.VisiblePosition = 2;
            cbu_KyKetChuyen.DisplayLayout.Bands[0].Columns["TenKy"].Hidden = false;

            cbu_KyKetChuyen.DisplayLayout.Bands[0].Columns["NgayBatDau"].Header.Caption = "Ngày Bắt Đầu";
            cbu_KyKetChuyen.DisplayLayout.Bands[0].Columns["NgayBatDau"].Header.VisiblePosition = 3;
            cbu_KyKetChuyen.DisplayLayout.Bands[0].Columns["NgayBatDau"].Hidden = false;

            cbu_KyKetChuyen.DisplayLayout.Bands[0].Columns["NgayKetThuc"].Header.Caption = "Ngày Kết Thúc";
            cbu_KyKetChuyen.DisplayLayout.Bands[0].Columns["NgayKetThuc"].Header.VisiblePosition = 4;
            cbu_KyKetChuyen.DisplayLayout.Bands[0].Columns["NgayKetThuc"].Hidden = false;
        }

        private void ubtKhongLuu_Click(object sender, EventArgs e)
        {

        }

        private void ultraGrid_SoDuDauKy_InitializeLayout_1(object sender, InitializeLayoutEventArgs e)
        {
            foreach (UltraGridBand ban in this.ultraGrid_SoDuDauKy.DisplayLayout.Bands)
            {
                ban.Hidden = true;
            } 
            ultraGrid_SoDuDauKy.DisplayLayout.Bands[0].Hidden = false;
            foreach (UltraGridColumn col in this.ultraGrid_SoDuDauKy.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;
                col.Header.Appearance.BackColor = System.Drawing.Color.White;
                col.Hidden = true;
                if (col.DataType.ToString() == "System.DateTime")
                {
                    col.Format = "dd/MM/yyyy";
                }
                if (col.DataType.ToString() == "System.Decimal")
                {
                    //col.MaskInput = "{LOC}nnn,nnn,nnn,nnn,nnn.nn";
                    col.Format = "#,###.##";
                    col.CellAppearance.TextHAlign = HAlign.Right;
                }
            }

            //e.Layout.Override.AllowAddNew = AllowAddNew.TemplateOnTop;
            //e.Layout.Override.TemplateAddRowPrompt = "Click vào đây để thêm dòng mới";
            e.Layout.Override.TemplateAddRowAppearance.BackColor = Color.FromArgb(245, 250, 255);
            e.Layout.Override.TemplateAddRowAppearance.ForeColor = SystemColors.GrayText;
            e.Layout.Override.AddRowAppearance.BackColor = Color.LightYellow;
            e.Layout.Override.AddRowAppearance.ForeColor = Color.Blue;
            e.Layout.Override.SpecialRowSeparator = SpecialRowSeparator.TemplateAddRow;
            e.Layout.Override.SpecialRowSeparatorAppearance.BackColor = SystemColors.Control;
            e.Layout.Override.TemplateAddRowPromptAppearance.ForeColor = Color.Maroon;
            e.Layout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.True;

            //ultraGrid_SoDuDauKy.DisplayLayout.Bands[1].Hidden = true;
            //ultraGrid_SoDuDauKy.DisplayLayout.Bands[2].Hidden = true;


            ultraGrid_SoDuDauKy.DisplayLayout.Bands[0].Columns["MaTaiKhoan"].Hidden = true;
            ultraGrid_SoDuDauKy.DisplayLayout.Bands[0].Columns["MaBoPhan"].Hidden = true;
            ultraGrid_SoDuDauKy.DisplayLayout.Bands[0].Columns["Ky"].Hidden = true;

            ultraGrid_SoDuDauKy.DisplayLayout.Bands[0].Columns["SoHieuTK"].Hidden = false;
            ultraGrid_SoDuDauKy.DisplayLayout.Bands[0].Columns["SoHieuTK"].Header.Caption = "Số hiệu TK";
            ultraGrid_SoDuDauKy.DisplayLayout.Bands[0].Columns["SoHieuTK"].Header.VisiblePosition = 0;
            //ultraGrid_SoDuDauKy.DisplayLayout.Bands[0].Columns["SoHieuTK"].EditorComponent = ultraCombo_NoTaiKhoan;
            ultraGrid_SoDuDauKy.DisplayLayout.Bands[0].Columns["SoHieuTK"].Width = 100;

            ultraGrid_SoDuDauKy.DisplayLayout.Bands[0].Columns["TenTaiKhoan"].Hidden = false;
            ultraGrid_SoDuDauKy.DisplayLayout.Bands[0].Columns["TenTaiKhoan"].Header.Caption = "Tên Tài Khoản";
            ultraGrid_SoDuDauKy.DisplayLayout.Bands[0].Columns["TenTaiKhoan"].Header.VisiblePosition = 1;
            //ugrButToan.DisplayLayout.Bands[0].Columns["TenTaiKhoan"].EditorComponent = ultraCombo_CoTaiKhoan;
            ultraGrid_SoDuDauKy.DisplayLayout.Bands[0].Columns["TenTaiKhoan"].Width = 200;

            ultraGrid_SoDuDauKy.DisplayLayout.Bands[0].Columns["SoDuDauKyNo"].Hidden = false;
            ultraGrid_SoDuDauKy.DisplayLayout.Bands[0].Columns["SoDuDauKyNo"].Header.Caption = "Đầu kỳ nợ";
            ultraGrid_SoDuDauKy.DisplayLayout.Bands[0].Columns["SoDuDauKyNo"].Width = 100;
            ultraGrid_SoDuDauKy.DisplayLayout.Bands[0].Columns["SoDuDauKyNo"].Header.VisiblePosition = 2;
            ultraGrid_SoDuDauKy.DisplayLayout.Bands[0].Columns["SoDuDauKyNo"].PromptChar = ' ';

            ultraGrid_SoDuDauKy.DisplayLayout.Bands[0].Columns["SoDuDauKyCo"].Hidden = false;
            ultraGrid_SoDuDauKy.DisplayLayout.Bands[0].Columns["SoDuDauKyCo"].Header.Caption = "Đầu kỳ có";
            ultraGrid_SoDuDauKy.DisplayLayout.Bands[0].Columns["SoDuDauKyCo"].Width = 100;
            ultraGrid_SoDuDauKy.DisplayLayout.Bands[0].Columns["SoDuDauKyCo"].Header.VisiblePosition = 3;
            ultraGrid_SoDuDauKy.DisplayLayout.Bands[0].Columns["SoDuDauKyCo"].PromptChar = ' ';

            ultraGrid_SoDuDauKy.DisplayLayout.Bands[0].Columns["PhatSinhTrongKyNo"].Hidden = false;
            ultraGrid_SoDuDauKy.DisplayLayout.Bands[0].Columns["PhatSinhTrongKyNo"].Header.Caption = "Phát sinh nợ";
            ultraGrid_SoDuDauKy.DisplayLayout.Bands[0].Columns["PhatSinhTrongKyNo"].Width = 100;
            ultraGrid_SoDuDauKy.DisplayLayout.Bands[0].Columns["PhatSinhTrongKyNo"].Header.VisiblePosition = 4;
            ultraGrid_SoDuDauKy.DisplayLayout.Bands[0].Columns["PhatSinhTrongKyNo"].PromptChar = ' ';

            ultraGrid_SoDuDauKy.DisplayLayout.Bands[0].Columns["PhatSinhTrongKyCo"].Hidden = false;
            ultraGrid_SoDuDauKy.DisplayLayout.Bands[0].Columns["PhatSinhTrongKyCo"].Header.Caption = "Phát sinh có";
            ultraGrid_SoDuDauKy.DisplayLayout.Bands[0].Columns["PhatSinhTrongKyCo"].Width = 100;
            ultraGrid_SoDuDauKy.DisplayLayout.Bands[0].Columns["PhatSinhTrongKyCo"].Header.VisiblePosition = 5;
            ultraGrid_SoDuDauKy.DisplayLayout.Bands[0].Columns["PhatSinhTrongKyCo"].PromptChar = ' ';

            ultraGrid_SoDuDauKy.DisplayLayout.Bands[0].Columns["LuyKeNo"].Hidden = false;
            ultraGrid_SoDuDauKy.DisplayLayout.Bands[0].Columns["LuyKeNo"].Header.Caption = "Lũy kế nợ";
            ultraGrid_SoDuDauKy.DisplayLayout.Bands[0].Columns["LuyKeNo"].Width = 100;
            ultraGrid_SoDuDauKy.DisplayLayout.Bands[0].Columns["LuyKeNo"].Header.VisiblePosition = 6;
            ultraGrid_SoDuDauKy.DisplayLayout.Bands[0].Columns["LuyKeNo"].PromptChar = ' ';

            ultraGrid_SoDuDauKy.DisplayLayout.Bands[0].Columns["LuyKeCo"].Hidden = false;
            ultraGrid_SoDuDauKy.DisplayLayout.Bands[0].Columns["LuyKeCo"].Header.Caption = "Lũy kế có";
            ultraGrid_SoDuDauKy.DisplayLayout.Bands[0].Columns["LuyKeCo"].Width = 100;
            ultraGrid_SoDuDauKy.DisplayLayout.Bands[0].Columns["LuyKeCo"].Header.VisiblePosition = 7;
            ultraGrid_SoDuDauKy.DisplayLayout.Bands[0].Columns["LuyKeCo"].PromptChar = ' ';

            //ultraGrid_SoDuDauKy.DisplayLayout.Bands[1].Hidden = true;
            //ultraGrid_SoDuDauKy.DisplayLayout.Bands[0].Override.RowSelectors = DefaultableBoolean.True;

            UltraGridColumn columnToSummarize2 = e.Layout.Bands[0].Columns["SoDuDauKyNo"];
            SummarySettings summary2 = ultraGrid_SoDuDauKy.DisplayLayout.Bands[0].Summaries.Add("SoDuDauKyNo", SummaryType.Sum, columnToSummarize2);
            summary2.SummaryPosition = SummaryPosition.Left;
            summary2.DisplayFormat = "Đầu kỳ Nợ = {0:###,###,###,###,###,###.##}";
            summary2.Appearance.TextHAlign = HAlign.Right;

            UltraGridColumn columnToSummarize3 = e.Layout.Bands[0].Columns["SoDuDauKyCo"];
            SummarySettings summary3 = ultraGrid_SoDuDauKy.DisplayLayout.Bands[0].Summaries.Add("SoDuDauKyCo", SummaryType.Sum, columnToSummarize3);
            summary3.SummaryPosition = SummaryPosition.Left;
            summary3.DisplayFormat = "Đầu kỳ Có = {0:###,###,###,###,###,###.##}";
            summary3.Appearance.TextHAlign = HAlign.Right;


            e.Layout.Override.SummaryDisplayArea = SummaryDisplayAreas.BottomFixed;
            ultraGrid_SoDuDauKy.DisplayLayout.Bands[0].Override.SummaryFooterCaptionVisible = DefaultableBoolean.False;
        }
    }
}