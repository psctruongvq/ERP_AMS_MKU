using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ERP_Library;
using System.Collections;

namespace PSC_ERP
{
    public partial class frmGiayNghiPhepNuocNgoaiList : Form
    {
        private ERP_Library.GiayNghiPhepNuocNgoaiList _Data;
        public frmGiayNghiPhepNuocNgoaiList()
        {
            InitializeComponent();
        }

        private void frmGiayNghiPhepNuocNgoaiList_Load(object sender, EventArgs e)
        {
            txtDenNgay.Value = DateTime.Today;
            txtTuNgay.Value = new DateTime(txtDenNgay.Value.Year, txtDenNgay.Value.Month, 1);
            _Data = ERP_Library.GiayNghiPhepNuocNgoaiList.GetGiayNghiPhepNuocNgoaiList(txtTuNgay.Value, txtDenNgay.Value);
            giayNghiPhepListBindingSource.DataSource = _Data;
            cmbBoPhan.DataSource = BoPhanList.GetBoPhanList();
            cmbKyLuong.DataSource = ERP_Library.KyTinhLuongList.GetKyTinhLuongList();
            HamDungChung.VisibleColumn(cmbBoPhan.DisplayLayout.Bands[0], "MaBoPhanQL", "TenBoPhan");
            //ArrayList permit = DangNhap.arrRoleID;
            //for (int i = 0; i < permit.Count; i++)
            //{
            //    if ((int)permit[i] == 1 || (int)permit[i] == 2)//Quan Tri He Thong
            //    {
            //        cmbBoPhan.DataSource = BoPhanList.GetBoPhanList();
            //    }
            //    else
            //    {
            //        cmbBoPhan.DataSource = BoPhanList.GetBoPhan(Security.CurrentUser.Info.MaBoPhan);
            //    }
            //}
            
            cmbBoPhan.DisplayMember = "TenBoPhan";
            cmbBoPhan.ValueMember = "MaBoPhan";
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            if (cmbNhanVien.Value == null)
            {
                if (cmbBoPhan.Value == null)
                    _Data = ERP_Library.GiayNghiPhepNuocNgoaiList.GetGiayNghiPhepNuocNgoaiList(txtTuNgay.Value, txtDenNgay.Value);
                else
                    _Data = ERP_Library.GiayNghiPhepNuocNgoaiList.GetGiayNghiPhepNuocNgoaiListByBoPhan(txtTuNgay.Value, txtDenNgay.Value, (int)cmbBoPhan.Value);
            }
            else
                _Data = ERP_Library.GiayNghiPhepNuocNgoaiList.GetGiayNghiPhepNuocNgoaiListByNhanVien(txtTuNgay.Value, txtDenNgay.Value, (long)cmbNhanVien.Value);

            giayNghiPhepListBindingSource.DataSource = _Data;
        }

        private void tlslblThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void toolNew_Click(object sender, EventArgs e)
        {
            frmGiayNghiPhepNuocNgoaiEdit f = new frmGiayNghiPhepNuocNgoaiEdit();
            if (f.NewGiayPhep())
                btnFind.PerformClick();
        }

        private void grdData_DoubleClickRow(object sender, Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs e)
        {
            frmGiayNghiPhepNuocNgoaiEdit f = new frmGiayNghiPhepNuocNgoaiEdit();
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
            f.rptView.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("ERP_Library_Report_GiayNghiPhepList", ERP_Library.Report.GiayNghiPhepList.GetGiayNghiPhepNgoaiNuoc((int)grdData.ActiveRow.Cells["MaNghiPhep"].Value)));
            f.ShowDialog();
        }
    }
}