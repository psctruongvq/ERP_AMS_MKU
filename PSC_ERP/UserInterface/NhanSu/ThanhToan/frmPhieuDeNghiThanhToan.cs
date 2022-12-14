using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PSC_ERP.ThanhToan
{
    public partial class frmPhieuDeNghiThanhToan : Form
    {
        private bool isLoadData = false;

        private ERP_Library.ThanhToan.DeNghiThanhToanList _data;
        private string MaPhanHe = "NhanSu";//thay đổi mã này để load các dữ liệu tùy theo phân hệ, chú ý : form edit, form chọn loại chứng từ gốc sẽ tự thay đổi theo

        public frmPhieuDeNghiThanhToan()
        {
            InitializeComponent();
        }

        private void tlClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tlThem_Click(object sender, EventArgs e)
        {
            frmPhieuDeNghiThanhToan_Edit f = new frmPhieuDeNghiThanhToan_Edit();
            f.MaPhanHe = MaPhanHe;
            ERP_Library.ThanhToan.DeNghiThanhToan newdata = _data.AddNew();
            newdata.So = newdata.SoPhieuMoi();
            if (!f.EditData(newdata))
                _data.Remove(newdata);
            else
                _data.Save();
        }

        private void frmPhieuDeNghiThanhToan_Load(object sender, EventArgs e)
        {
            txtTuNgay.DateTime = DateTime.Today;
            txtDenNgay.Value = DateTime.Today;
            foreach (ERP_Library.BoPhan item in ERP_Library.BoPhanList.GetBoPhanList())
            {
                grdData.DisplayLayout.ValueLists["BoPhan"].ValueListItems.Add(item.MaBoPhan, item.TenBoPhan);
            }
            foreach (ERP_Library.NhanVienComboListChild item in ERP_Library.NhanVienComboList.GetNhanVienAll())
            {
                grdData.DisplayLayout.ValueLists["NhanVien"].ValueListItems.Add(item.MaNhanVien, item.TenNhanVien);
            }
            isLoadData = true;
            LoadData();
        }

        private void LoadData()
        {
            if (isLoadData)
            {
                _data = ERP_Library.ThanhToan.DeNghiThanhToanList.GetDeNghiThanhToanList(txtTuNgay.DateTime, txtDenNgay.DateTime, MaPhanHe);
                bdData.DataSource = _data;
            }
        }

        private void NgayChanged(object sender, EventArgs e)
        {
            LoadData();
        }

        private void tlSua_Click(object sender, EventArgs e)
        {
            if (grdData.ActiveRow != null)
            {
                frmPhieuDeNghiThanhToan_Edit f = new frmPhieuDeNghiThanhToan_Edit();
                f.MaPhanHe = MaPhanHe;               
                if (f.EditData((ERP_Library.ThanhToan.DeNghiThanhToan)grdData.ActiveRow.ListObject))
                    _data.Save();
            }
        }

        private void grdData_DoubleClickRow(object sender, Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs e)
        {
            if (e.Row.IsDataRow)
                tlSua.PerformClick();
        }

        private void tlXoa_Click(object sender, EventArgs e)
        {
            grdData.DeleteSelectedRows();
            _data.Save();
        }

        private void grdData_BeforeRowsDeleted(object sender, Infragistics.Win.UltraWinGrid.BeforeRowsDeletedEventArgs e)
        {
            e.DisplayPromptMsg = false;
            e.Cancel = MessageBox.Show("Bạn có muốn xóa phiếu đề nghị này không?", "Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No;
        }

        private void tlUndo_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void tlIn_Click(object sender, EventArgs e)
        {
            if (grdData.ActiveRow != null && grdData.ActiveRow.IsDataRow)
            {
                long id = Convert.ToInt64(grdData.ActiveRow.Cells["MaPhieu"].Value);
                frmXemIn f = new frmXemIn();
                Microsoft.Reporting.WinForms.LocalReport rpt = f.rptView.LocalReport;
                rpt.ReportEmbeddedResource = "PSC_ERP.Report.rptDeNghiThanhToan.rdlc";
                //rpt.ReportPath = @"D:\Hien Trung\HTV\PSC_ERP\Report\rptDeNghiThanhToan.rdlc";
                rpt.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("ERP_Library_Report_DeNghiThanhToanList", ERP_Library.Report.DeNghiThanhToanList.GetDeNghiThanhToanList(id)));
                rpt.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter[] { new Microsoft.Reporting.WinForms.ReportParameter("BangChu", ERP_Library.HamDungChung.DocTien(Convert.ToDecimal(grdData.ActiveRow.Cells["SoTien"].Value))) });
                f.ShowDialog();
            }
        }
    }
}