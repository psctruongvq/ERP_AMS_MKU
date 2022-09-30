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
    public partial class frmNhanVienTangCaList : Form
    {
        public frmNhanVienTangCaList()
        {
            InitializeComponent();
        }

        private void frmNhanVienTangCaList_Load(object sender, EventArgs e)
        {
            txtTuNgay.Value = DateTime.Today;
            txtDenNgay.Value = DateTime.Today;
            cmbBoPhan.DataSource = BoPhanList.GetBoPhanList(); 
            bdData.DataSource = ERP_Library.NhanVienTangCaList.GetNhanVienTangCaList(txtTuNgay.Value, txtDenNgay.Value, null, null);
        }

        private void cmbBoPhan_ValueChanged(object sender, EventArgs e)
        {
            if (cmbBoPhan.Value == null)
                cmbNhanVien.LoadDataByBoPhan(0);
            else
                cmbNhanVien.LoadDataByBoPhan((int)cmbBoPhan.Value);
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            bdData.DataSource = ERP_Library.NhanVienTangCaList.GetNhanVienTangCaList(txtTuNgay.Value, txtDenNgay.Value, (Nullable<int>)cmbBoPhan.Value, (Nullable<long>)cmbNhanVien.Value);
        }

        private void tlslblThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void toolNew_Click(object sender, EventArgs e)
        {
            frmNhanVienTangCaEdit f = new frmNhanVienTangCaEdit();
            if (f.NewTangCa())
                btnFind.PerformClick();
        }

        private void grdData_DoubleClickRow(object sender, Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs e)
        {
            frmNhanVienTangCaEdit f = new frmNhanVienTangCaEdit();
            if (f.EditTangCa((int)e.Row.Cells["MaBangTangCa"].Value))
                btnFind.PerformClick();
        }
    }
}