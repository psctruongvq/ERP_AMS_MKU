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
    public partial class frmHienThiLuoi_ThueNTNN : Form
    {
        private int _maKy = 0;
        private Report_ThueNTNNList _listThue;
        public frmHienThiLuoi_ThueNTNN()
        {
            InitializeComponent();
            Load_Form();
        }
        public frmHienThiLuoi_ThueNTNN(int MaKy)
        {
            InitializeComponent();
            _maKy = MaKy;
            Load_Form();
        }
        private void Load_Form()
        {
            _listThue = Report_ThueNTNNList.GetReport_ThueNTNNList(_maKy, ERP_Library.Security.CurrentUser.Info.UserID, ERP_Library.Security.CurrentUser.Info.MaBoPhan);
            reportThueNTNNListBindingSource.DataSource = _listThue;
        }

        private void tlslblXuatExcel_Click(object sender, EventArgs e)
        {
            HamDungChung.ExportToExcel(grid_ThueNTNN);
        }

        private void tlslblThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void grid_ThueNTNN_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            HamDungChung.EditBand(grid_ThueNTNN.DisplayLayout.Bands[0],
              new string[14] { "NoiDung", "MaSoThue", "SoHopDong", "SoTienThanhToan", "NgayThanhToan", "DoanhThuTinhThueGTGT", "TyLeGTGT", "ThueSuatGTGT", "ThueGTGTPhaiNop", "DoanhThuTinhThueTNDN", "TyLeThueTNDN", "ThueMienGiam", "ThueTNDNPhaiNop", "TongSoThueNopVaoNSNN" },
              new string[14] { "Nội dung", "Mã số thuế", "Số hợp đồng", "Số tiền thanh toán","Ngày Thanh toán","DT Tính Thuế GTGT", "Tỷ lệ GTGT", "Thuế suất GTGT", "Thuế GTGT phải nộp","DT Tính Thuế TNDN", "Tỷ lệ thuế TNDN", "Thuế miễn giảm", "Thuế TNDN phải nộp", "Tổng Số Thuế"},
              new int[14] { 150, 50, 50, 100, 100, 100,50 ,50,100, 100, 50, 100,100,100 },
              new Control[14] { null, null, null, null, null, null, null, null, null, null, null , null, null, null},
              new KieuDuLieu[14] { KieuDuLieu.Null, KieuDuLieu.Null, KieuDuLieu.Null, KieuDuLieu.Tien, KieuDuLieu.Ngay,KieuDuLieu.Tien ,KieuDuLieu.So, KieuDuLieu.So, KieuDuLieu.Tien,KieuDuLieu.Tien,KieuDuLieu.So, KieuDuLieu.Tien,KieuDuLieu.Tien, KieuDuLieu.Tien },
              new bool[14] { false, false, false, false, false, false, false, false, false, false,false,false, false, false });
            //màu và font chữ
            foreach (UltraGridColumn col in this.grid_ThueNTNN.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;//x =  //= System.Drawing.w;//RoyalBlue
            }
            //màu nền
            this.grid_ThueNTNN.DisplayLayout.Override.HeaderAppearance.BackColor = System.Drawing.Color.White;
            this.grid_ThueNTNN.DisplayLayout.Override.HeaderStyle = HeaderStyle.WindowsXPCommand;

            //UltraGridColumn columnToSummarize = e.Layout.Bands[0].Columns["MatHang"];
            //SummarySettings summary = grid_ThueNTNN.DisplayLayout.Bands[0].Summaries.Add("MatHang", SummaryType.Sum, columnToSummarize, SummaryPosition.UseSummaryPositionColumn);
            //summary.DisplayFormat = "Tổng cộng: ";
            //summary.Appearance.TextHAlign = HAlign.Right;

            //UltraGridColumn columnToSummarize1 = e.Layout.Bands[0].Columns["SoTien"];
            //SummarySettings summary1 = grid_ThueNTNN.DisplayLayout.Bands[0].Summaries.Add("SoTien", SummaryType.Sum, columnToSummarize1, SummaryPosition.UseSummaryPositionColumn);
            //summary1.DisplayFormat = "{0:###,###,###}";
            //summary1.Appearance.TextHAlign = HAlign.Right;

            //UltraGridColumn columnToSummarize2 = e.Layout.Bands[0].Columns["TienThue"];
            //SummarySettings summary2 = grid_ThueNTNN.DisplayLayout.Bands[0].Summaries.Add("TienThue", SummaryType.Sum, columnToSummarize2, SummaryPosition.UseSummaryPositionColumn);
            //summary2.DisplayFormat = "{0:###,###,###}";
            //summary2.Appearance.TextHAlign = HAlign.Right;

            //Save
            e.Layout.Override.SummaryDisplayArea = SummaryDisplayAreas.BottomFixed;
            grid_ThueNTNN.DisplayLayout.Bands[0].Override.SummaryFooterCaptionVisible = DefaultableBoolean.False;
        }

    }
}
