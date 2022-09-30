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
    public partial class frmTheoDoiSoTienChungTu : Form
    {       
        XuatDuLieuList _xuatDuLieuList;
        int _maboPhan = ERP_Library.Security.CurrentUser.Info.MaBoPhan;

        public frmTheoDoiSoTienChungTu()
        {
            InitializeComponent();

            //Set ngày mặc định
            dateTuNgay.Value = DateTime.Now.Date;
            dateDenNgay.Value = DateTime.Now.Date;
        }
        private void TimChungTu()
        {
            if (dateTuNgay.Value == null || dateDenNgay.Value == null)
            {
                MessageBox.Show("Vui lòng chọn dữ liệu.","Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            _xuatDuLieuList = XuatDuLieuList.GetXuatDuLieuListByNgayLap(dateTuNgay.Value, dateDenNgay.Value, _maboPhan);
            this.TheoDoiSoChungTu_BindingSource.DataSource = _xuatDuLieuList;
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

            grData.DisplayLayout.Bands[0].Columns["SoChungTu"].Hidden = false;
            grData.DisplayLayout.Bands[0].Columns["SoChungTu"].Header.Caption = "Số Chứng Từ";
            grData.DisplayLayout.Bands[0].Columns["SoChungTu"].Header.VisiblePosition = 1;
            grData.DisplayLayout.Bands[0].Columns["SoChungTu"].Width = 120;

            grData.DisplayLayout.Bands[0].Columns["NgayLap"].Hidden = false;
            grData.DisplayLayout.Bands[0].Columns["NgayLap"].Header.Caption = "Ngày Lập";
            grData.DisplayLayout.Bands[0].Columns["NgayLap"].Header.VisiblePosition = 2;
            grData.DisplayLayout.Bands[0].Columns["NgayLap"].Format = "dd/MM/yyyy";
            grData.DisplayLayout.Bands[0].Columns["NgayLap"].Width = 100;
        
            grData.DisplayLayout.Bands[0].Columns["SoTienBT"].Hidden = false;
            grData.DisplayLayout.Bands[0].Columns["SoTienBT"].Header.Caption = "Tiền Bút Toán";
            grData.DisplayLayout.Bands[0].Columns["SoTienBT"].Header.VisiblePosition = 3;
            grData.DisplayLayout.Bands[0].Columns["SoTienBT"].Format = "###,###,###,###";
            grData.DisplayLayout.Bands[0].Columns["SoTienBT"].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            grData.DisplayLayout.Bands[0].Columns["SoTienBT"].Width = 150;

            grData.DisplayLayout.Bands[0].Columns["SoTienMucNganSach"].Hidden = false;
            grData.DisplayLayout.Bands[0].Columns["SoTienMucNganSach"].Header.Caption = "Tiền Ngân Sách";
            grData.DisplayLayout.Bands[0].Columns["SoTienMucNganSach"].Header.VisiblePosition = 4;
            grData.DisplayLayout.Bands[0].Columns["SoTienMucNganSach"].Format = "###,###,###,###";
            grData.DisplayLayout.Bands[0].Columns["SoTienMucNganSach"].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            grData.DisplayLayout.Bands[0].Columns["SoTienMucNganSach"].Width = 150;

            grData.DisplayLayout.Bands[0].Columns["GhiMucNganSach"].Hidden = false;
            grData.DisplayLayout.Bands[0].Columns["GhiMucNganSach"].Header.Caption = "Khác Nhau";
            grData.DisplayLayout.Bands[0].Columns["GhiMucNganSach"].Header.VisiblePosition = 5;
            grData.DisplayLayout.Bands[0].Columns["GhiMucNganSach"].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
            grData.DisplayLayout.Bands[0].Columns["GhiMucNganSach"].Width = 100;  
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            //
            TimChungTu();
        }

        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            //
            HamDungChung.ExportToExcel(grData);
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
