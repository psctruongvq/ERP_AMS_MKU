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


    public partial class frmTheoDoiChungTuChiTiet : Form
    {
       public ChungTu_TheoDoiChiTietList _list;
        ChungTu_TheoDoi _chungTuTheoDoi;
       private int MaTheoDoi = 0;
      
        public bool IsSave = false;
        private long MaChungTu = 0;
        public frmTheoDoiChungTuChiTiet()
        {
            InitializeComponent();


            this.bindingSource1_ChiTietTheoDoi.DataSource = typeof(ChungTu_TheoDoiChiTietList);            
          
        }
        public frmTheoDoiChungTuChiTiet(ChungTu_TheoDoi chungTuTheoDoi)
        {
            InitializeComponent();
            this.bindingSource1_ChiTietTheoDoi.DataSource = typeof(ChungTu_TheoDoiChiTietList);

            _chungTuTheoDoi = chungTuTheoDoi;
            this.MaTheoDoi = _chungTuTheoDoi.MaTheoDoi;
            this.MaChungTu = _chungTuTheoDoi.MaChungTu;
            tbSoChungTu.Text = _chungTuTheoDoi.SoChungTu;
            tbSoTien.Value = _chungTuTheoDoi.SoTienChungTu;
            _list = ChungTu_TheoDoiChiTietList.GetChungTu_TheoDoiChiTietList(MaTheoDoi);
            this.bindingSource1_ChiTietTheoDoi.DataSource = _list;

        }
         private void frmTamUng_Load(object sender, EventArgs e)
        {
            _list = ChungTu_TheoDoiChiTietList.GetChungTu_TheoDoiChiTietList(MaTheoDoi);
            this.bindingSource1_ChiTietTheoDoi.DataSource = _list;
        }   
        private void grdData_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            HamDungChung h = new HamDungChung();
            h.ultragrdEmail_InitializeLayout(sender, e);
         
            foreach (UltraGridColumn col in this.grdData.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;
                col.Hidden = true;
            }

            grdData.DisplayLayout.Bands[0].Columns["SoTienThanhToan"].Hidden = false;
            grdData.DisplayLayout.Bands[0].Columns["SoTienThanhToan"].Header.Caption = "Số Tiền  Thanh Toán";
            grdData.DisplayLayout.Bands[0].Columns["SoTienThanhToan"].Header.VisiblePosition = 0;
            grdData.DisplayLayout.Bands[0].Columns["SoTienThanhToan"].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            grdData.DisplayLayout.Bands[0].Columns["SoTienThanhToan"].Format = "###,###,###,###,###";

            //grdData.DisplayLayout.Bands[0].Columns["SoTienConLai"].Hidden = false;
            //grdData.DisplayLayout.Bands[0].Columns["SoTienConLai"].Header.Caption = "Số Tiền Sẽ Thanh Toán";
            //grdData.DisplayLayout.Bands[0].Columns["SoTienConLai"].Header.VisiblePosition = 3;
            //grdData.DisplayLayout.Bands[0].Columns["SoTienConLai"].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            //grdData.DisplayLayout.Bands[0].Columns["SoTienConLai"].Format = "###,###,###,###,###";

            grdData.DisplayLayout.Bands[0].Columns["DienGiai"].Hidden = false;
            grdData.DisplayLayout.Bands[0].Columns["DienGiai"].Header.Caption = "Diễn Giải";
            grdData.DisplayLayout.Bands[0].Columns["DienGiai"].Header.VisiblePosition = 4;
            grdData.DisplayLayout.Bands[0].Columns["DienGiai"].Width = 300;

            UltraGridColumn columnToSummarize2 = e.Layout.Bands[0].Columns["SoTienThanhToan"];
            SummarySettings summary2 = grdData.DisplayLayout.Bands[0].Summaries.Add("SoTienThanhToan", SummaryType.Sum, columnToSummarize2);
            summary2.SummaryPosition = SummaryPosition.UseSummaryPositionColumn;
            summary2.DisplayFormat = "Tổng={0:###,###,###,###,###,###}";
            summary2.Appearance.TextHAlign = HAlign.Right;
            summary2.SummaryType = SummaryType.Sum;
            summary2.SummaryPositionColumn = columnToSummarize2;
            e.Layout.Override.SummaryDisplayArea = SummaryDisplayAreas.TopFixed;
            e.Layout.Override.SummaryFooterCaptionVisible = DefaultableBoolean.False;

          
           

        }


        private void tlslblLuu_Click(object sender, EventArgs e)
        {
            Save();
            this.Close();
        }
        private void Save()
        {
            this.bindingSource1_ChiTietTheoDoi.EndEdit();
            grdData.UpdateData();
            decimal soTienThanhToan = 0;
            foreach (ChungTu_TheoDoiChiTiet ct in _list)
            {
                ct.NgayLap = DateTime.Today.Date;
                ct.MaTheoDoi = MaTheoDoi;
                soTienThanhToan += ct.SoTienThanhToan;
            }
            if (soTienThanhToan > _chungTuTheoDoi.SoTienChungTu)
            {
                MessageBox.Show("Số Tiền thanh toán không được lớn hơn số tiền Chứng từ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            _list.ApplyEdit();
            _list.Save();
            MessageBox.Show("Cập nhật thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            _list = ChungTu_TheoDoiChiTietList.GetChungTu_TheoDoiChiTietList(MaTheoDoi);
            this.bindingSource1_ChiTietTheoDoi.DataSource = _list;
            
   
        }
        private void tlslblXoa_Click(object sender, EventArgs e)
        {
            grdData.DeleteSelectedRows();
        }

        private void tlslblUndo_Click(object sender, EventArgs e)
        {
            _list = ChungTu_TheoDoiChiTietList.GetChungTu_TheoDoiChiTietList(MaTheoDoi);
            this.bindingSource1_ChiTietTheoDoi.DataSource = _list;
        }

        private void tlslblIn_Click(object sender, EventArgs e)
        {

        }
        private void tlslblThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void grdData_AfterRowInsert(object sender, RowEventArgs e)
        {
            decimal soTienDaNhap = 0;
            foreach (ChungTu_TheoDoiChiTiet ct in _list)
            {
                soTienDaNhap += ct.SoTienThanhToan;
            }
            ((ChungTu_TheoDoiChiTiet)bindingSource1_ChiTietTheoDoi.Current).SoTienChungTu = _chungTuTheoDoi.SoTienChungTu;
            ((ChungTu_TheoDoiChiTiet)bindingSource1_ChiTietTheoDoi.Current).SoTienDaThanhToan = 0;
            ((ChungTu_TheoDoiChiTiet)bindingSource1_ChiTietTheoDoi.Current).SoTienThanhToan = _chungTuTheoDoi.SoTienChungTu-soTienDaNhap;
            ((ChungTu_TheoDoiChiTiet)bindingSource1_ChiTietTheoDoi.Current).SoTienConLai = 0;
            ((ChungTu_TheoDoiChiTiet)bindingSource1_ChiTietTheoDoi.Current).DienGiai = _chungTuTheoDoi.DienGiaiChungTu;     

        }

        private void frmTheoDoiChungTuChiTiet_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_list.IsDirty == true)
            {
                if (MessageBox.Show("Dữ liệu đã thay đổi. Bạn muốn lưu lại?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Save();
                }
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            Save();
        }

    }
}
