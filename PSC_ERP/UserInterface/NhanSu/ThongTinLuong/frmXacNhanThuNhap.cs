using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PSC_ERP
{
    public partial class frmXacNhanThuNhap : Form
    {
        private ERP_Library.XacNhanThuNhapList _data;
        public frmXacNhanThuNhap()
        {
            InitializeComponent();
            grdData.BeforeRowsDeleted += new Infragistics.Win.UltraWinGrid.BeforeRowsDeletedEventHandler(grdData_BeforeRowsDeleted);
            grdData.DoubleClickRow += new Infragistics.Win.UltraWinGrid.DoubleClickRowEventHandler(grdData_DoubleClickRow);
        }

        void grdData_DoubleClickRow(object sender, Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs e)
        {
            frmXacNhanThuNhapEdit f = new frmXacNhanThuNhapEdit();
            f.EditData((ERP_Library.XacNhanThuNhap)e.Row.ListObject, _data);
        }

        void grdData_BeforeRowsDeleted(object sender, Infragistics.Win.UltraWinGrid.BeforeRowsDeletedEventArgs e)
        {
            e.DisplayPromptMsg = false;
            e.Cancel = MessageBox.Show("Bạn có muốn xóa bảng xác nhận này không?", "Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No;
        }

        private void frmXacNhanThuNhap_Load(object sender, EventArgs e)
        {
            foreach (ERP_Library.BoPhan item in ERP_Library.BoPhanList.GetBoPhanList())
                grdData.DisplayLayout.ValueLists["BoPhan"].ValueListItems.Add(item.MaBoPhan, item.TenBoPhan);
            foreach (ERP_Library.NhanVienComboListChild item in ERP_Library.NhanVienComboList.GetNhanVienAll())
                grdData.DisplayLayout.ValueLists["NhanVien"].ValueListItems.Add(item.MaNhanVien, item.TenNhanVien);
            LoadData();
        }

        private void LoadData()
        {
            _data = ERP_Library.XacNhanThuNhapList.GetXacNhanThuNhapList();
            bdData.DataSource = _data;
        }

        private void tlslblUndo_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void tlslblThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tlslblXoa_Click(object sender, EventArgs e)
        {
            grdData.DeleteSelectedRows();
        }

        private void tlslblThem_Click(object sender, EventArgs e)
        {
            frmXacNhanThuNhapEdit f = new frmXacNhanThuNhapEdit();
            f.NewData(_data);
        }

        private void tlslblSua_Click(object sender, EventArgs e)
        {
            if (bdData.Current != null)
            {
                frmXacNhanThuNhapEdit f = new frmXacNhanThuNhapEdit();
                f.EditData((ERP_Library.XacNhanThuNhap)bdData.Current,_data);
            }
        }

        private void tlslblIn_Click(object sender, EventArgs e)
        {
            if (grdData.ActiveRow == null) return;
            int MaXacNhan = (int)grdData.ActiveRow.Cells["MaXacNhan"].Value;
            frmXemIn f = new frmXemIn();
            Microsoft.Reporting.WinForms.LocalReport rpt = f.rptView.LocalReport;
            //rpt.ReportPath = @"D:\Hien Trung\NhanSu HTV\PSC_ERP\PSC_ERP\Report\rptXacNhanThuNhap.rdlc";
            rpt.ReportEmbeddedResource = "PSC_ERP.Report.rptXacNhanThuNhap.rdlc";
            ERP_Library.Report.XacNhanThuNhapList data = ERP_Library.Report.XacNhanThuNhapList.GetXacNhanThuNhapList(MaXacNhan);
            rpt.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("ERP_Library_Report_XacNhanThuNhapList", data));
            rpt.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("ERP_Library_Report_XacNhanThuNhapChiTietChild", data[0].ChiTiet));
            f.SetNguoiKyXacNhanThuNhap(3, data[0].NgayLap);
            f.ShowDialog();
        }

    }
}