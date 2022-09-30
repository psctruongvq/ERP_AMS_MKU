using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Infragistics.Win.UltraWinGrid;
using Infragistics.Win;
using ERP_Library;

namespace PSC_ERP
{
    public partial class frmHienThiLuoi_ThueGTGTMuaVao : Form
    {
        #region Properties
        private int _maKy = 0;
        private ReportThue01_2GTGTList _listThue;
        #endregion

        #region Loads
        public frmHienThiLuoi_ThueGTGTMuaVao()
        {
            InitializeComponent();
            Load_Form();
        }

        public frmHienThiLuoi_ThueGTGTMuaVao(int MaKy)
        {
            InitializeComponent();
            _maKy = MaKy;
            Load_Form();
        }
        #endregion

        private void grdu_DSHoaDonDichVu_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            HamDungChung.EditBand(grdu_DSThueGTGTMua.DisplayLayout.Bands[0],
              new string[12] { "MauHoaDon", "KyHieuMauHoaDon", "SoSerial",             "MaHoaDon", "NgayLapHD", "TenDoiTac", "MaSoThue", "MatHang", "SoTien", "ThueSuat", "TienThue", "GhiChu" },
              new string[12] { "Mã hóa đơn","Ký hiệu mẫu hóa đơn" , "Ký hiệu hóa đơn","Số hóa đơn", "Ngày, tháng, năm phát hành", "Họ tên người bán", "Mã số thuế", "Mặt hàng", "Doanh số bán chưa có thuế", "Thuế suất %", "Thuế GTGT", "Ghi chú" },
              new int[12] { 150, 150, 100, 100, 100, 250, 150, 150, 150, 150, 150, 150 },
              new Control[12] { null, null, null, null, null, null, null, null, null, null, null, null },
              new KieuDuLieu[12] { KieuDuLieu.Null, KieuDuLieu.Null,KieuDuLieu.Null, KieuDuLieu.Null, KieuDuLieu.Ngay, KieuDuLieu.Null, KieuDuLieu.Null, KieuDuLieu.Null, KieuDuLieu.Tien, KieuDuLieu.Null, KieuDuLieu.Tien, KieuDuLieu.Null },
              new bool[12] { false, false,false, false, false, false, false, false, false, false, false, false });
            //màu và font chữ
            foreach (UltraGridColumn col in this.grdu_DSThueGTGTMua.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;//x =  //= System.Drawing.w;//RoyalBlue
            }
            //màu nền
            this.grdu_DSThueGTGTMua.DisplayLayout.Override.HeaderAppearance.BackColor = System.Drawing.Color.White;
            this.grdu_DSThueGTGTMua.DisplayLayout.Override.HeaderStyle = HeaderStyle.WindowsXPCommand;

            UltraGridColumn columnToSummarize = e.Layout.Bands[0].Columns["MatHang"];
            SummarySettings summary = grdu_DSThueGTGTMua.DisplayLayout.Bands[0].Summaries.Add("MatHang", SummaryType.Sum, columnToSummarize, SummaryPosition.UseSummaryPositionColumn);
            summary.DisplayFormat = "Tổng cộng: ";
            summary.Appearance.TextHAlign = HAlign.Right;

            UltraGridColumn columnToSummarize1 = e.Layout.Bands[0].Columns["SoTien"];
            SummarySettings summary1 = grdu_DSThueGTGTMua.DisplayLayout.Bands[0].Summaries.Add("SoTien", SummaryType.Sum, columnToSummarize1, SummaryPosition.UseSummaryPositionColumn);
            summary1.DisplayFormat = "{0:###,###,###}";
            summary1.Appearance.TextHAlign = HAlign.Right;

            UltraGridColumn columnToSummarize2 = e.Layout.Bands[0].Columns["TienThue"];
            SummarySettings summary2 = grdu_DSThueGTGTMua.DisplayLayout.Bands[0].Summaries.Add("TienThue", SummaryType.Sum, columnToSummarize2, SummaryPosition.UseSummaryPositionColumn);
            summary2.DisplayFormat = "{0:###,###,###}";
            summary2.Appearance.TextHAlign = HAlign.Right;

            //Save
            e.Layout.Override.SummaryDisplayArea = SummaryDisplayAreas.BottomFixed;
            grdu_DSThueGTGTMua.DisplayLayout.Bands[0].Override.SummaryFooterCaptionVisible = DefaultableBoolean.False;
        }

        private void tlslblThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
        #region Process
        private void Load_Form()
        {
            //Tao bang ke mua vao
            frmBaoCaoThue frm = new frmBaoCaoThue();
            frm.Tao_bangkeMuavao();

            _listThue = ReportThue01_2GTGTList.GetReportThue01_2GTGTList(_maKy);
            Thue01_2GTGT_bindingSource.DataSource = _listThue;
        }

        #endregion

        private void tlslblXuatExcel_Click(object sender, EventArgs e)
        {
            HamDungChung.ExportToExcel(grdu_DSThueGTGTMua);
        }

        #region Events
        #endregion

 
    }
}
