using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using ERP_Library;

namespace PSC_ERP
{
    public partial class frmGiayNghiPhepList : Form
    {
        private ERP_Library.GiayNghiPhepList _Data;
        public frmGiayNghiPhepList()
        {
            InitializeComponent();
        }

        private void frmGiayNghiPhepList_Load(object sender, EventArgs e)
        {
            txtDenNgay.Value = DateTime.Today;
            txtTuNgay.Value = new DateTime(txtDenNgay.Value.Year, txtDenNgay.Value.Month, 1);
            _Data = ERP_Library.GiayNghiPhepList.GetGiayNghiPhepList(txtTuNgay.Value,txtDenNgay.Value);
            giayNghiPhepListBindingSource.DataSource = _Data;
            cmbKyLuong.DataSource = ERP_Library.KyTinhLuongList.GetKyTinhLuongList();
            cmbBoPhan.DataSource = BoPhanList.GetBoPhanList();            
            cmbBoPhan.DisplayMember = "TenBoPhan";
            cmbBoPhan.ValueMember = "MaBoPhan";
            HamDungChung.VisibleColumn(cmbBoPhan.DisplayLayout.Bands[0], "MaBoPhanQL", "TenBoPhan");
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            if (cmbNhanVien.Value == null)
            {
                if (cmbBoPhan.Value == null)
                    _Data = ERP_Library.GiayNghiPhepList.GetGiayNghiPhepList(txtTuNgay.Value, txtDenNgay.Value);
                else
                    _Data = ERP_Library.GiayNghiPhepList.GetGiayNghiPhepListByBoPhan(txtTuNgay.Value, txtDenNgay.Value, (int)cmbBoPhan.Value);
            }
            else
                _Data = ERP_Library.GiayNghiPhepList.GetGiayNghiPhepListByNhanVien(txtTuNgay.Value, txtDenNgay.Value, (long)cmbNhanVien.Value);

            giayNghiPhepListBindingSource.DataSource = _Data;
        }

        private void tlslblThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void toolNew_Click(object sender, EventArgs e)
        {
            frmGiayNghiPhepEdit f = new frmGiayNghiPhepEdit();
            if (f.NewGiayPhep())
                btnFind.PerformClick();
        }

        private void grdData_DoubleClickRow(object sender, Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs e)
        {
            frmGiayNghiPhepEdit f = new frmGiayNghiPhepEdit();
            if (f.EditGiayPhep((int)e.Row.Cells["MaNghiPhep"].Value))
                btnFind.PerformClick();
        }

        private void cmbBoPhan_ValueChanged(object sender, EventArgs e)
        {
            int id = 0;
            try
            {
                id = (int)cmbBoPhan.Value;
            }
            catch { }
            cmbNhanVien.LoadDataByBoPhan(id);
            
        }

        private void tlslblIn_Click(object sender, EventArgs e)
        {
            if (grdData.ActiveRow == null) return;
            frmXemIn f = new frmXemIn();
            f.rptView.LocalReport.ReportEmbeddedResource = "PSC_ERP.Report.rptGiayNghiPhep.rdlc";
            f.rptView.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("ERP_Library_Report_GiayNghiPhepList", ERP_Library.Report.GiayNghiPhepList.GetGiayNghiPhepTrongNuoc((int)grdData.ActiveRow.Cells["MaNghiPhep"].Value)));
            f.ShowDialog();
        }
    }
}