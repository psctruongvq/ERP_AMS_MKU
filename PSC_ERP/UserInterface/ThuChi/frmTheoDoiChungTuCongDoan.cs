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
namespace PSC_ERP
{
    public partial class frmTheoDoiChungTuCongDoan : Form
    {
        
        CongDoanChungTu_TheoDoiList _chungTuTheoDoiList;
        DateTime tuNgay = DateTime.Today.AddMonths(-3).Date;
        DateTime denNgay = DateTime.Today.Date;
        public frmTheoDoiChungTuCongDoan()
        {
            InitializeComponent();
         //   this.bindingSource1_ChungTuTheoDoi.DataSource = typeof(ChungTu_TheoDoiList);
        }

        private void frmTheoDoiChungTu_Load(object sender, EventArgs e)
        {
           ComboChanged();
          
           
        }
        private void ComboChanged()
        {
            _chungTuTheoDoiList = CongDoanChungTu_TheoDoiList.GetCongDoanChungTu_TheoDoiList(tuNgay, denNgay);
            this.bindingSource1_TheoDoiChungTu.DataSource = _chungTuTheoDoiList;
        }
        private void grdData_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            HamDungChung h = new HamDungChung();
            h.ultragrdEmail_InitializeLayout(sender, e);
            e.Layout.Override.AllowAddNew = AllowAddNew.No;
            foreach (UltraGridColumn col in this.grData.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;
                col.Hidden = true;
                col.CellActivation = Activation.NoEdit;
                
            }

            grData.DisplayLayout.Bands[0].Columns["HoanTat"].Hidden = false;
            grData.DisplayLayout.Bands[0].Columns["HoanTat"].Header.Caption = "Hoàn Tất";
            grData.DisplayLayout.Bands[0].Columns["HoanTat"].Header.VisiblePosition = 0;
            grData.DisplayLayout.Bands[0].Columns["HoanTat"].CellActivation = Activation.AllowEdit;
            grData.DisplayLayout.Bands[0].Columns["HoanTat"].Width = 80;

            grData.DisplayLayout.Bands[0].Columns["TenDoiTuong"].Hidden = false;
            grData.DisplayLayout.Bands[0].Columns["TenDoiTuong"].Header.Caption = "Đối Tượng";
            grData.DisplayLayout.Bands[0].Columns["TenDoiTuong"].Header.VisiblePosition = 1;
            grData.DisplayLayout.Bands[0].Columns["TenDoiTuong"].CellActivation = Activation.AllowEdit;


            grData.DisplayLayout.Bands[0].Columns["NgayLapChungTu"].Hidden = false;
            grData.DisplayLayout.Bands[0].Columns["NgayLapChungTu"].Header.Caption = "Ngày Lập CT";
            grData.DisplayLayout.Bands[0].Columns["NgayLapChungTu"].Header.VisiblePosition = 2;
            grData.DisplayLayout.Bands[0].Columns["NgayLapChungTu"].Format = "dd/MM/yyyy";


            grData.DisplayLayout.Bands[0].Columns["PhieuThu"].Hidden = false;
            grData.DisplayLayout.Bands[0].Columns["PhieuThu"].Header.Caption = "Phiếu Thu";
            grData.DisplayLayout.Bands[0].Columns["PhieuThu"].Header.VisiblePosition = 3;

            grData.DisplayLayout.Bands[0].Columns["PhieuChi"].Hidden = false;
            grData.DisplayLayout.Bands[0].Columns["PhieuChi"].Header.Caption = "Phiếu Chi";
            grData.DisplayLayout.Bands[0].Columns["PhieuChi"].Header.VisiblePosition = 4;           
        
            grData.DisplayLayout.Bands[0].Columns["SoTienChungTu"].Hidden = false;
            grData.DisplayLayout.Bands[0].Columns["SoTienChungTu"].Header.Caption = "Số Tiền CT";
            grData.DisplayLayout.Bands[0].Columns["SoTienChungTu"].Header.VisiblePosition = 5;
            grData.DisplayLayout.Bands[0].Columns["SoTienChungTu"].Format = "###,###,###,###";
            grData.DisplayLayout.Bands[0].Columns["SoTienChungTu"].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;

            grData.DisplayLayout.Bands[0].Columns["SoTienDaChi"].Hidden = false;
            grData.DisplayLayout.Bands[0].Columns["SoTienDaChi"].Header.Caption = "Tiền Đã Chi";
            grData.DisplayLayout.Bands[0].Columns["SoTienDaChi"].Header.VisiblePosition = 6;
            grData.DisplayLayout.Bands[0].Columns["SoTienDaChi"].Format = "###,###,###,###";
            grData.DisplayLayout.Bands[0].Columns["SoTienDaChi"].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;

            grData.DisplayLayout.Bands[0].Columns["SoTienDaThu"].Hidden = false;
            grData.DisplayLayout.Bands[0].Columns["SoTienDaThu"].Header.Caption = "Tiền Đã Thu";
            grData.DisplayLayout.Bands[0].Columns["SoTienDaThu"].Header.VisiblePosition = 7;
            grData.DisplayLayout.Bands[0].Columns["SoTienDaThu"].Format = "###,###,###,###";
            grData.DisplayLayout.Bands[0].Columns["SoTienDaThu"].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;

            grData.DisplayLayout.Bands[0].Columns["SoTienConLai"].Hidden = false;
            grData.DisplayLayout.Bands[0].Columns["SoTienConLai"].Header.Caption = "Số Tiền Còn Lại";
            grData.DisplayLayout.Bands[0].Columns["SoTienConLai"].Header.VisiblePosition = 8;
            grData.DisplayLayout.Bands[0].Columns["SoTienConLai"].Format = "###,###,###,###";
            grData.DisplayLayout.Bands[0].Columns["SoTienConLai"].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;

            grData.DisplayLayout.Bands[0].Columns["ChiTiet"].Hidden = false;
            grData.DisplayLayout.Bands[0].Columns["ChiTiet"].Header.Caption = "Chi Tiết Thanh Toán";
            grData.DisplayLayout.Bands[0].Columns["ChiTiet"].Header.VisiblePosition = 9;
            grData.DisplayLayout.Bands[0].Columns["ChiTiet"].EditorComponent = tEChiPhi;
            grData.DisplayLayout.Bands[0].Columns["ChiTiet"].ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.Always;
            grData.DisplayLayout.Bands[0].Columns["ChiTiet"].CellActivation = Activation.AllowEdit;


            grData.DisplayLayout.Bands[0].Columns["LoaiThuChi"].Hidden = false;
            grData.DisplayLayout.Bands[0].Columns["LoaiThuChi"].Header.Caption = "Loại Thu Chi";
            grData.DisplayLayout.Bands[0].Columns["LoaiThuChi"].Header.VisiblePosition = 10;

            grData.DisplayLayout.Bands[0].Columns["NgayChiTien"].Hidden = false;
            grData.DisplayLayout.Bands[0].Columns["NgayChiTien"].Header.Caption = "Ngày Thu/Chi";
            grData.DisplayLayout.Bands[0].Columns["NgayChiTien"].Header.VisiblePosition = 11;
            grData.DisplayLayout.Bands[0].Columns["NgayChiTien"].CellActivation = Activation.AllowEdit;



            grData.DisplayLayout.Bands[0].Columns["DienGiaiChungTu"].Hidden = false;
            grData.DisplayLayout.Bands[0].Columns["DienGiaiChungTu"].Header.Caption = "Diễn Giải CT";
            grData.DisplayLayout.Bands[0].Columns["DienGiaiChungTu"].Header.VisiblePosition =11;

            grData.DisplayLayout.Bands[0].Columns["GhiChu"].Hidden = false;
            grData.DisplayLayout.Bands[0].Columns["GhiChu"].Header.Caption = "Diễn Giải";
            grData.DisplayLayout.Bands[0].Columns["GhiChu"].Header.VisiblePosition = 12;
            grData.DisplayLayout.Bands[0].Columns["GhiChu"].CellActivation = Activation.AllowEdit;


            UltraGridColumn columnToSummarize1 = e.Layout.Bands[0].Columns["SoTienDaChi"];
            SummarySettings summary1 = grData.DisplayLayout.Bands[0].Summaries.Add("SoTienDaChi", SummaryType.Sum, columnToSummarize1);
            summary1.SummaryPosition = SummaryPosition.UseSummaryPositionColumn;
            summary1.DisplayFormat = "Tổng={0:###,###,###,###,###,###}";
            summary1.Appearance.TextHAlign = HAlign.Right;
            summary1.SummaryType = SummaryType.Sum;
            summary1.SummaryPositionColumn = columnToSummarize1;

            UltraGridColumn columnToSummarize2 = e.Layout.Bands[0].Columns["SoTienChungTu"];
            SummarySettings summary2 = grData.DisplayLayout.Bands[0].Summaries.Add("SoTienChungTu", SummaryType.Sum, columnToSummarize2);
            summary2.SummaryPosition = SummaryPosition.UseSummaryPositionColumn;
            summary2.DisplayFormat = "Tổng={0:###,###,###,###,###,###}";
            summary2.Appearance.TextHAlign = HAlign.Right;
            summary2.SummaryType = SummaryType.Sum;
            summary2.SummaryPositionColumn = columnToSummarize2;

            UltraGridColumn columnToSummarize3 = e.Layout.Bands[0].Columns["SoTienDaThu"];
            SummarySettings summary3 = grData.DisplayLayout.Bands[0].Summaries.Add("SoTienDaThu", SummaryType.Sum, columnToSummarize3);
            summary3.SummaryPosition = SummaryPosition.UseSummaryPositionColumn;
            summary3.DisplayFormat = "Tổng={0:###,###,###,###,###,###}";
            summary3.Appearance.TextHAlign = HAlign.Right;
            summary3.SummaryType = SummaryType.Sum;
            summary3.SummaryPositionColumn = columnToSummarize3;


            UltraGridColumn columnToSummarize4 = e.Layout.Bands[0].Columns["SoTienConLai"];
            SummarySettings summary4 = grData.DisplayLayout.Bands[0].Summaries.Add("SoTienConLai", SummaryType.Sum, columnToSummarize4);
            summary4.SummaryPosition = SummaryPosition.UseSummaryPositionColumn;
            summary4.DisplayFormat = "Tổng={0:###,###,###,###,###,###}";
            summary4.Appearance.TextHAlign = HAlign.Right;
            summary4.SummaryType = SummaryType.Sum;
            summary4.SummaryPositionColumn = columnToSummarize4;

            e.Layout.Override.SummaryDisplayArea = SummaryDisplayAreas.BottomFixed;
            e.Layout.Override.SummaryFooterCaptionVisible = DefaultableBoolean.False;
           
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            tuNgay = Convert.ToDateTime(dateTuNgay.Value);
            ComboChanged();
        }

        private void dateDenNgay_ValueChanged(object sender, EventArgs e)
        {
            denNgay = Convert.ToDateTime(dateDenNgay.Value);
            ComboChanged();
        }

        private void tlslblLuu_Click(object sender, EventArgs e)
        {
            this.bindingSource1_TheoDoiChungTu.EndEdit();
            this.grData.UpdateData();
            foreach (CongDoanChungTu_TheoDoi theoDoi in _chungTuTheoDoiList)
            {
                if (theoDoi.SoTienConLai == 0)
                    theoDoi.HoanTat = true;
                else
                    theoDoi.HoanTat = false;
            }
            _chungTuTheoDoiList.ApplyEdit();
            _chungTuTheoDoiList.Save();
            MessageBox.Show("Cập nhật thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ComboChanged();
        }

        private void tlslblThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tlslblIn_Click(object sender, EventArgs e)
        {
            HamDungChung.ExportToExcel(grData);
        }

   
        private void tlslblUndo_Click(object sender, EventArgs e)
        {
            ComboChanged();
        }

        private void grData_AfterCellUpdate(object sender, CellEventArgs e)
        {
          
        }

        private void tEChiPhi_EditorButtonClick(object sender, Infragistics.Win.UltraWinEditors.EditorButtonEventArgs e)
        {
            int maTheoDoi = (int)grData.ActiveRow.Cells["MaTheoDoi"].Value;
            int maChungTu = (int)grData.ActiveRow.Cells["MaChungTu"].Value;
            if (maTheoDoi != 0)
            {
                frmTheoDoiChungTuCongDoanChiTiet f = new frmTheoDoiChungTuCongDoanChiTiet((CongDoanChungTu_TheoDoi)bindingSource1_TheoDoiChungTu.Current);
                f.FormClosed += new FormClosedEventHandler(f_FormClosed);
                f.ShowDialog(this);
            }

            ComboChanged();
            foreach (CongDoanChungTu_TheoDoi theoDoi in _chungTuTheoDoiList)
            {
                if (theoDoi.SoTienConLai == 0)
                    theoDoi.HoanTat = true;
                else
                    theoDoi.HoanTat = false;
            }
            _chungTuTheoDoiList.ApplyEdit();
            _chungTuTheoDoiList.Save();
            this.bindingSource1_TheoDoiChungTu.DataSource = _chungTuTheoDoiList;
        }

        void f_FormClosed(object sender, FormClosedEventArgs e)
        {
            ComboChanged();
        }

        private void grData_CellChange(object sender, CellEventArgs e)
        {
            if (e.Cell == grData.ActiveRow.Cells["HoanTat"])
            {
                if (((ChungTu_TheoDoi)bindingSource1_TheoDoiChungTu.Current).SoTienConLai != 0 && (bool)grData.ActiveRow.Cells["HoanTat"].Value==false)
                {
                    DialogResult result = MessageBox.Show("Số tiền còn lại chưa hết. Bạn có muốn hoàn tất giấy xác nhận?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.No)
                    {
                        if ((bool)grData.ActiveRow.Cells["HoanTat"].Value  == true)
                        {
                            grData.ActiveRow.Cells["HoanTat"].Value = false;
                        }

                        return;
                    }
                }
                
            }
        }

        private void grData_BeforeRowsDeleted(object sender, BeforeRowsDeletedEventArgs e)
        {
            e.Cancel = true;
        }
        
    }
}
