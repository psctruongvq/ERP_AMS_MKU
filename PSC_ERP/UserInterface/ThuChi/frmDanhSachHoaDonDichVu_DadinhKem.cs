using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ERP_Library;
using Infragistics.Shared;
using Infragistics.Win;
using Infragistics.Win.UltraWinGrid;
using System.Runtime.InteropServices;
//



namespace PSC_ERP
{
    public partial class frmDanhSachHoaDonDichVu_DadinhKem : Form
    {        
        long MaDangNhap = ERP_Library.Security.CurrentUser.Info.UserID;
        public bool IsSave = false;
        public ChungTu_HoaDonList ct_hdList=ChungTu_HoaDonList.NewChungTu_HoaDonList();
        ButToan _bt;
        ChungTu _ct=ChungTu.NewChungTu();

        #region Load
        public frmDanhSachHoaDonDichVu_DadinhKem()
        {
            InitializeComponent();
            this.bdCT_HoaDon.DataSource = typeof(ChungTu_HoaDonList);
        }
        public frmDanhSachHoaDonDichVu_DadinhKem(ChungTu ct, ButToan bt) // true no false co
        {
            InitializeComponent();            
            _ct = ct;
            _bt = bt;
            if (_bt.MaButToan != 0)
            {
                bdCT_HoaDon.DataSource = _bt.ChungTu_HoaDonList;
            }   
        }      
        private void grdu_DSHoaDon_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            foreach (UltraGridColumn col in this.grdu_DSHoaDon.DisplayLayout.Bands[0].Columns)
            {
                col.Hidden = true;
                if (col.DataType.ToString() == "System.DateTime")
                {
                    col.CellAppearance.TextHAlign = HAlign.Right;
                    col.Format = "dd/MM/yyyy";
                }
                if (col.DataType.ToString() == "System.Decimal")
                {
                    //col.MaskInput = "{LOC}nnn,nnn,nnn,nnn,nnn,nnn";
                    col.Format = "#,###";
                    col.CellAppearance.TextHAlign = HAlign.Right;
                }
                col.CellActivation = Activation.NoEdit;
            }

            grdu_DSHoaDon.DisplayLayout.Bands[0].Columns["SoHoaDon"].Hidden = false;
            grdu_DSHoaDon.DisplayLayout.Bands[0].Columns["SoHoaDon"].Header.Caption = "Số Hóa Đơn";
            grdu_DSHoaDon.DisplayLayout.Bands[0].Columns["SoHoaDon"].Header.VisiblePosition = 0;

            grdu_DSHoaDon.DisplayLayout.Bands[0].Columns["MauHoaDon"].Hidden = false;
            grdu_DSHoaDon.DisplayLayout.Bands[0].Columns["MauHoaDon"].Header.Caption = "Mẫu Hóa Đơn";
            grdu_DSHoaDon.DisplayLayout.Bands[0].Columns["MauHoaDon"].Header.VisiblePosition = 5;
            grdu_DSHoaDon.DisplayLayout.Bands[0].Columns["MauHoaDon"].Width = 55;

            grdu_DSHoaDon.DisplayLayout.Bands[0].Columns["KyHieuMauHoaDon"].Hidden = false;
            grdu_DSHoaDon.DisplayLayout.Bands[0].Columns["KyHieuMauHoaDon"].Header.Caption = "Ký Hiệu Mẫu HĐ";
            grdu_DSHoaDon.DisplayLayout.Bands[0].Columns["KyHieuMauHoaDon"].Header.VisiblePosition = 6;
            grdu_DSHoaDon.DisplayLayout.Bands[0].Columns["KyHieuMauHoaDon"].Width = 55;


            grdu_DSHoaDon.DisplayLayout.Bands[0].Columns["SoTienSeThanhToan"].CellActivation = Activation.AllowEdit;
            grdu_DSHoaDon.DisplayLayout.Bands[0].Columns["SoTienSeThanhToan"].Hidden = false;
            grdu_DSHoaDon.DisplayLayout.Bands[0].Columns["SoTienSeThanhToan"].Header.Caption = "Tiền Thanh Toán";
            grdu_DSHoaDon.DisplayLayout.Bands[0].Columns["SoTienSeThanhToan"].Header.VisiblePosition = 1;


            grdu_DSHoaDon.DisplayLayout.Bands[0].Columns["SoChungTu"].Hidden = false;
            grdu_DSHoaDon.DisplayLayout.Bands[0].Columns["SoChungTu"].Header.Caption = "Số Chứng Từ";
            grdu_DSHoaDon.DisplayLayout.Bands[0].Columns["SoChungTu"].Header.VisiblePosition = 2;


            grdu_DSHoaDon.DisplayLayout.Bands[0].Columns["NgayLap"].Hidden = false;
            grdu_DSHoaDon.DisplayLayout.Bands[0].Columns["NgayLap"].Header.Caption = "Ngày Kèm Hóa Đơn";
            grdu_DSHoaDon.DisplayLayout.Bands[0].Columns["NgayLap"].Header.VisiblePosition = 3;


            UltraGridColumn columnToSummarize2 = e.Layout.Bands[0].Columns["SoTien"];
            SummarySettings summary2 = grdu_DSHoaDon.DisplayLayout.Bands[0].Summaries.Add("SoTien", SummaryType.Sum, columnToSummarize2);
            summary2.SummaryPosition = SummaryPosition.UseSummaryPositionColumn;
            summary2.DisplayFormat = "Tổng={0:###,###,###,###,###,###}";
            summary2.Appearance.TextHAlign = HAlign.Right;
            summary2.SummaryType = SummaryType.Sum;
            summary2.SummaryPositionColumn = columnToSummarize2;

            UltraGridColumn columnToSummarize3 = e.Layout.Bands[0].Columns["SoTienDaThanhToan"];
            SummarySettings summary3 = grdu_DSHoaDon.DisplayLayout.Bands[0].Summaries.Add("SoTienDaThanhToan", SummaryType.Sum, columnToSummarize3);
            summary3.SummaryPosition = SummaryPosition.UseSummaryPositionColumn;
            summary3.DisplayFormat = "Tổng={0:###,###,###,###,###,###}";
            summary3.Appearance.TextHAlign = HAlign.Right;
            summary3.SummaryType = SummaryType.Sum;
            summary3.SummaryPositionColumn = columnToSummarize3;


            UltraGridColumn columnToSummarize4 = e.Layout.Bands[0].Columns["SoTienConLai"];
            SummarySettings summary4 = grdu_DSHoaDon.DisplayLayout.Bands[0].Summaries.Add("SoTienConLai", SummaryType.Sum, columnToSummarize4);
            summary4.SummaryPosition = SummaryPosition.UseSummaryPositionColumn;
            summary4.DisplayFormat = "Tổng={0:###,###,###,###,###,###}";
            summary4.Appearance.TextHAlign = HAlign.Right;
            summary4.SummaryType = SummaryType.Sum;
            summary4.SummaryPositionColumn = columnToSummarize4;

            UltraGridColumn columnToSummarize5 = e.Layout.Bands[0].Columns["SoTienSeThanhToan"];
            SummarySettings summary5 = grdu_DSHoaDon.DisplayLayout.Bands[0].Summaries.Add("SoTienSeThanhToan", SummaryType.Sum, columnToSummarize5);
            summary5.SummaryPosition = SummaryPosition.UseSummaryPositionColumn;
            summary5.DisplayFormat = "Tổng={0:###,###,###,###,###,###}";
            summary5.Appearance.TextHAlign = HAlign.Right;
            summary5.SummaryType = SummaryType.Sum;
            summary5.SummaryPositionColumn = columnToSummarize5;

            e.Layout.Override.SummaryDisplayArea = SummaryDisplayAreas.TopFixed;

            e.Layout.Override.SummaryFooterCaptionVisible = DefaultableBoolean.False;
        }
        
        #endregion

        #region Event
        private void tlslblLuu_Click(object sender, EventArgs e)
        {           
            Save();
        }                                
        private void tlslblThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }      
        
                  
        #endregion
       
        #region Process
        private void Save()
        {
            try
            {
                KhoaSo_UserList khoa = KhoaSo_UserList.GetKhoaSo_UserListByNgayLap(Convert.ToDateTime(_ct.NgayLap));
                if (khoa.Count > 0)
                {
                    if (khoa[0].KhoaSo == true)
                    {
                        MessageBox.Show(this, "Đã khóa sổ,xin vui lòng kiểm tra lại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
                _bt.ChungTu_HoaDonList._Update();
                MessageBox.Show("Cập nhật thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            { MessageBox.Show(ex.ToString()); } 
        }
        #endregion     

        private void tlsxoa_Click(object sender, EventArgs e)
        {
            if (grdu_DSHoaDon.ActiveRow != null)
            {
                KhoaSo_UserList khoa = KhoaSo_UserList.GetKhoaSo_UserListByNgayLap(Convert.ToDateTime(_ct.NgayLap));
                if (khoa.Count > 0)
                {
                    if (khoa[0].KhoaSo == true)
                    {
                        MessageBox.Show(this, "Đã khóa sổ,xin vui lòng kiểm tra lại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
                grdu_DSHoaDon.DeleteSelectedRows();
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            HamDungChung.ExportToExcel(grdu_DSHoaDon);
        }

        private void grdu_DSHoaDon_DoubleClick(object sender, EventArgs e)
        {
            if (grdu_DSHoaDon.ActiveRow != null)
            {
                if (grdu_DSHoaDon.ActiveRow.IsFilterRow != true)
                { 
                    HoaDon hd=HoaDon.GetHoaDon( Convert.ToInt32( grdu_DSHoaDon.ActiveRow.Cells["MaHoaDon"].Value));

                    frmHoaDonDichVuMuaVao frmHoaDon = new frmHoaDonDichVuMuaVao(_ct, hd);
                    frmHoaDon.Show();
                    
                }
            }
        }
    }
}