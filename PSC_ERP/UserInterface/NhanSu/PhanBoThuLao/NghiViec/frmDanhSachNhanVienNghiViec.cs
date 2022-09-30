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
    public partial class frmDanhSachNhanVienNghiViec : Form
    {
        public frmDanhSachNhanVienNghiViec()
        {
            InitializeComponent();
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            if (cmbNhanVien.Value == null)
            {
                bdBaoCao.DataSource = ERP_Library.DanhSachNhanVienNghiViecList.GetDanhSachNhanVienNghiViecList(txtTuNgay.Value,txtDenNgay.Value,(Nullable<int>)cmbBoPhan.Value);
            }
            else
            {
                bdBaoCao.DataSource = ERP_Library.DanhSachNhanVienNghiViecList.GetDanhSachNhanVienNghiViecList(txtTuNgay.Value, txtDenNgay.Value, (Nullable<long>)cmbNhanVien.Value);
            }
        }

        private void frmDanhSachNhanVienNghiViec_Load(object sender, EventArgs e)
        {
            txtTuNgay.Value = DateTime.Today;
            txtDenNgay.Value = DateTime.Today;
            cmbBoPhan.DataSource = BoPhanList.GetBoPhanList();
            btnFind.PerformClick();
            HamDungChung.VisibleColumn(cmbBoPhan.DisplayLayout.Bands[0], "MaBoPhanQL", "TenBoPhan");
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
            cmbNhanVien.Value = null;
        }
    }
}