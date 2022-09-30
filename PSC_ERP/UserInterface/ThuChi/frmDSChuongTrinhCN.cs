using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ERP_Library;
using Infragistics.Win.UltraWinGrid;
using CrystalDecisions.CrystalReports.Engine;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Infragistics.Shared;
using Infragistics.Win;
namespace PSC_ERP
{
    public partial class frmDSChuongTrinhCN : Form
    {
        ChuongTrinhList _ChuongTrinhList = ChuongTrinhList.NewChuongTrinhList();
        decimal SoTien = 0;
        public ChungTu_ChuongTrinhList _ChungTu_ChuongTrinhList = ChungTu_ChuongTrinhList.NewChungTu_ChuongTrinhList();
        public bool Luu = false;

        public frmDSChuongTrinhCN()
        {
            InitializeComponent();
        }
        public frmDSChuongTrinhCN(decimal _soTien,ChungTu_ChuongTrinhList _chungTu_ChuongTrinh)
        {
            InitializeComponent();
            _ChungTu_ChuongTrinhList = _chungTu_ChuongTrinh;
            SoTien = _soTien;
            if (_ChungTu_ChuongTrinhList.Count != 0)
            {
                foreach (ChungTu_ChuongTrinh ct in _ChungTu_ChuongTrinhList)
                {
                    _soTien -= ct.SoTien;
                }
            }
            txtSoTien.Value = _soTien;
            KhoiTao();
        }
        private void frmDSChuongTrinh_Load(object sender, EventArgs e)
        {

        }
        void KhoiTao()
        {
            ChungTu_ChuongTrinh_BindingSource.DataSource = _ChungTu_ChuongTrinhList;
            _ChuongTrinhList = ChuongTrinhList.GetChuongTrinhList(false);
            ChuongTrinh_bindingSourceList.DataSource = _ChuongTrinhList;
 
        }
        private void tlslblLuu_Click(object sender, EventArgs e)
        {

            Luu = true;
            this.Close();
        }

        private void tlslblThoat_Click(object sender, EventArgs e)
        {

            this.Close();
        }

        private void grdu_DSChungTU_ChuongTrinh_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            HamDungChung h = new HamDungChung();
            h.ultragrdEmail_InitializeLayout(sender, e);
            //e.Layout.Override.AllowAddNew = AllowAddNew.Yes;
            foreach (UltraGridColumn col in this.grdu_DSChungTU_ChuongTrinh.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;
                if (col.DataType.ToString() == "System.DateTime")
                {
                    col.Format = "dd/MM/yyyy";
                }
                if (col.DataType.ToString() == "System.Decimal")
                {
                    col.MaskInput = "{LOC}-nnn,nnn,nnn,nnn,nnn.nn";
                    col.Format = "###,###,###,###,###,###.##";
                }
                col.Hidden = true;
            }
            grdu_DSChungTU_ChuongTrinh.DisplayLayout.Bands[0].Columns["MaChuongTrinh"].Hidden = false;
            grdu_DSChungTU_ChuongTrinh.DisplayLayout.Bands[0].Columns["MaChuongTrinh"].EditorComponent = cmbu_Chuongtrinh;
            grdu_DSChungTU_ChuongTrinh.DisplayLayout.Bands[0].Columns["MaChuongTrinh"].Header.Caption = "Chương trình";
            grdu_DSChungTU_ChuongTrinh.DisplayLayout.Bands[0].Columns["MaChuongTrinh"].Header.VisiblePosition = 0;
            grdu_DSChungTU_ChuongTrinh.DisplayLayout.Bands[0].Columns["MaChuongTrinh"].Width = 250;


            grdu_DSChungTU_ChuongTrinh.DisplayLayout.Bands[0].Columns["SoTien"].Hidden = false;
            grdu_DSChungTU_ChuongTrinh.DisplayLayout.Bands[0].Columns["SoTien"].Header.Caption = "Số Tiền";
            grdu_DSChungTU_ChuongTrinh.DisplayLayout.Bands[0].Columns["SoTien"].Header.VisiblePosition = 2;
             grdu_DSChungTU_ChuongTrinh.DisplayLayout.Bands[0].Columns["SoTien"].Width = 150;

           ///
            UltraGridColumn columnToSummarize2 = e.Layout.Bands[0].Columns["SoTien"];
            SummarySettings summary2 = grdu_DSChungTU_ChuongTrinh.DisplayLayout.Bands[0].Summaries.Add("SoTien", SummaryType.Sum, columnToSummarize2);
            summary2.SummaryPosition = SummaryPosition.Left;
            summary2.DisplayFormat = "Tông Tiền = {0:###,###,###,###,###,###}";
            summary2.Appearance.TextHAlign = HAlign.Right;
            e.Layout.Override.SummaryDisplayArea = SummaryDisplayAreas.BottomFixed;
            grdu_DSChungTU_ChuongTrinh.DisplayLayout.Bands[0].Override.SummaryFooterCaptionVisible = DefaultableBoolean.False;
        }

        private void grdu_DSChungTU_ChuongTrinh_AfterRowInsert(object sender, RowEventArgs e)
        {
            decimal tien = 0;
            foreach (ChungTu_ChuongTrinh ct in _ChungTu_ChuongTrinhList)
            {
                //tien += ct.SoTien;
                //tien += tl.SoTien;
                if (SoTien != ct.SoTien)
                    SoTien -= ct.SoTien;
                else if (SoTien == ct.SoTien)
                    SoTien = 0;
            }
            //if (tien < SoTien)
            //{
            //    grdu_DSChungTU_ChuongTrinh.ActiveRow.Cells["SoTien"].Value = SoTien - tien;
            //    txtSoTien.Value = SoTien - tien;
            //}
            //else
            //{
            //    grdu_DSChungTU_ChuongTrinh.ActiveRow.Cells["SoTien"].Value = 0;
            //    txtSoTien.Value = 0;
            //}
        }

        private void grdu_DSChungTU_ChuongTrinh_Error(object sender, ErrorEventArgs e)
        {
            if (e.ErrorType == ErrorType.Data)
                e.ErrorText = "Kiểu dữ liệu không hợp lệ";
        }

        private void grdu_DSChungTU_ChuongTrinh_KeyDown(object sender, KeyEventArgs e)
        {
            //grdu_DSChungTU_ChuongTrinh.UpdateData();
        }

        private void cmbu_Chuongtrinh_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            //HamDungChung.Combobox_InitializeLayout(sender, e);
            FilterCombo f = new FilterCombo(grdu_DSChungTU_ChuongTrinh, "MaChuongTrinh", "TenChuongTrinh");
        }
    }
}
