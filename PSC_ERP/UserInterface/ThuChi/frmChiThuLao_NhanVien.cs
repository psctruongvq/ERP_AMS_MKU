using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ERP_Library;
using System.Collections.Generic;
using System.ComponentModel;
using Infragistics.Shared;
using Infragistics.Win;
using Infragistics.Win.UltraWinGrid;
namespace PSC_ERP
{
    public partial class frmChiThuLao_NhanVien : Form
    {
        ChiThuLao_NhanVienList _ThuLaoNhanVienList = ChiThuLao_NhanVienList.NewChiThuLao_NhanVien();
        TTNhanVienRutGonList _nhanVienList = TTNhanVienRutGonList.NewTTNhanVienRutGonList();
        BoPhan _boPhan = BoPhan.NewBoPhan();
        int mabophan = 0;
        
        ChiThuLao_NhanVien _ThuLaoNhanVien;
        public frmChiThuLao_NhanVien()
        {
            InitializeComponent();
            NhanVienBindingSource.DataSource = typeof(TTNhanVienRutGonList);
            ChiThuLaoBindingSource.DataSource = typeof(ChiThuLao_NhanVienList);
        }
        public frmChiThuLao_NhanVien(ChiThuLao _chiTL)
        {
            InitializeComponent();
        
         
            _ThuLaoNhanVienList = _chiTL.ChiThuLaoNhanVienList;
           
            mabophan = _chiTL.MaBoPhanNhan;
            _boPhan = BoPhan.GetBoPhan(mabophan);
            KhoiTao();
           
        }
        void KhoiTao()
        {
            ChiThuLaoBindingSource.DataSource =_ThuLaoNhanVienList;
            _nhanVienList = TTNhanVienRutGonList.GetNhanVienListBoPhanTrongNgoai(0);
            NhanVienBindingSource.DataSource = _nhanVienList;
        }
        private void ultraChiThuLao_NhanVien_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            HamDungChung h = new HamDungChung();
            h.ultragrdEmail_InitializeLayout(sender, e);
            //e.Layout.Override.AllowAddNew = AllowAddNew.No;
            foreach (UltraGridColumn col in this.ultraChiThuLao_NhanVien.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;
                col.Hidden = true;
            }
            ultraChiThuLao_NhanVien.DisplayLayout.Bands[0].Columns["MaNhanVien"].Hidden = false;
            ultraChiThuLao_NhanVien.DisplayLayout.Bands[0].Columns["MaNhanVien"].EditorComponent = cbNhanVien;
            ultraChiThuLao_NhanVien.DisplayLayout.Bands[0].Columns["MaNhanVien"].Header.Caption = "Nhân viên";
            ultraChiThuLao_NhanVien.DisplayLayout.Bands[0].Columns["MaNhanVien"].Header.VisiblePosition = 0;
            ultraChiThuLao_NhanVien.DisplayLayout.Bands[0].Columns["MaNhanVien"].Width = 250;

            ultraChiThuLao_NhanVien.DisplayLayout.Bands[0].Columns["SoTien"].Hidden = false;
            ultraChiThuLao_NhanVien.DisplayLayout.Bands[0].Columns["SoTien"].Header.Caption = "Số Tiền";
            ultraChiThuLao_NhanVien.DisplayLayout.Bands[0].Columns["SoTien"].Header.VisiblePosition = 1;
            ultraChiThuLao_NhanVien.DisplayLayout.Bands[0].Columns["SoTien"].Width = 150;
            ultraChiThuLao_NhanVien.DisplayLayout.Bands[0].Columns["SoTien"].Format = "###,###,###,###,###,###";
            ultraChiThuLao_NhanVien.DisplayLayout.Bands[0].Columns["SoTien"].CellAppearance.TextHAlign = HAlign.Right;
            //
            UltraGridColumn columnToSummarize2 = e.Layout.Bands[0].Columns["SoTien"];
            SummarySettings summary2 = ultraChiThuLao_NhanVien.DisplayLayout.Bands[0].Summaries.Add("SoTien", SummaryType.Sum, columnToSummarize2);
            summary2.SummaryPosition = SummaryPosition.Left;
            summary2.DisplayFormat = "Tông Tiền = {0:###,###,###,###,###,###}";
            summary2.Appearance.TextHAlign = HAlign.Right;
            e.Layout.Override.SummaryDisplayArea = SummaryDisplayAreas.BottomFixed;
            ultraChiThuLao_NhanVien.DisplayLayout.Bands[0].Override.SummaryFooterCaptionVisible = DefaultableBoolean.False;

           
        }

        private void ultraChiThuLao_NhanVien_AfterRowInsert(object sender, RowEventArgs e)
        {
           
            
        }

        private void tlslblLuu_Click(object sender, EventArgs e)
        {
         
           
            foreach (ChiThuLao_NhanVien tlnv in _ThuLaoNhanVienList)
            {
                tlnv.MabophanNv = mabophan;
                tlnv.TenBoPhan = _boPhan.TenBoPhan;
            }
            this.Close();
        }

        private void ultraChiThuLao_NhanVien_AfterRowUpdate(object sender, RowEventArgs e)
        {

            _ThuLaoNhanVien = (ChiThuLao_NhanVien)ChiThuLaoBindingSource.Current;
            if (_ThuLaoNhanVien != null)
            {
                _ThuLaoNhanVien.MabophanNv = _boPhan.MaBoPhan;
                _ThuLaoNhanVien.TenBoPhan = _boPhan.TenBoPhan;
             //   _ThuLaoNhanVien.TenNhanVien = cbNhanVien.Text;
            }
                }

        private void tlslblThoat_Click(object sender, EventArgs e)
        {
          
            this.Close();
        }

        private void ultraChiThuLao_NhanVien_Error(object sender, ErrorEventArgs e)
        {
            if (e.ErrorType == ErrorType.Data)
                e.ErrorText = "Kiểu dữ liệu không hợp lệ";
        }

        private void frmChiThuLao_NhanVien_Load(object sender, EventArgs e)
        {

        }

        private void cbNhanVien_ValueChanged(object sender, EventArgs e)
        {
            if (cbNhanVien.ActiveRow != null)
            {
                _ThuLaoNhanVien = (ChiThuLao_NhanVien)ChiThuLaoBindingSource.Current;
                _ThuLaoNhanVien.LoaiNV = Convert.ToByte(cbNhanVien.ActiveRow.Cells["LoaiNV"].Value);
                _ThuLaoNhanVien.TenNhanVien = Convert.ToString(cbNhanVien.ActiveRow.Cells["TenNhanVien"].Value);
            }
        }

        private void cbNhanVien_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            HamDungChung.Combobox_InitializeLayout(sender, e);
            FilterCombo f = new FilterCombo(ultraChiThuLao_NhanVien, "MaNhanVien", "TenNhanVien");
        }

        private void tlslblIn_Click(object sender, EventArgs e)
        {
            HamDungChung.ExportToExcel(ultraChiThuLao_NhanVien);
        }

      
    }
}
