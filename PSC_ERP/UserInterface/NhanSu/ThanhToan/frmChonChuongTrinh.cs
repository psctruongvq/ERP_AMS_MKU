using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PSC_ERP.ThanhToan
{
    public partial class frmChonChuongTrinh : frmChungTuGoc
    {
        private PSC_ERP.FilterCombo fChuongTrinh;
        public frmChonChuongTrinh()
        {
            InitializeComponent();
        }

        private void frmChonChuongTrinh_Load(object sender, EventArgs e)
        {
            bdChuongTrinh.DataSource = ERP_Library.ChuongTrinhList.GetChuongTrinhList(true);
            fChuongTrinh = new FilterCombo(cmbChuongTrinh, "TenChuongTrinh");
            if (!IsNew)
            {
                cmbChuongTrinh.Value = _dataset.Tables["ChonChuongTrinh"].Rows[0]["MaChuongTrinh"];
                txtNguoiNhan.Text = _dataset.Tables["ChonChuongTrinh"].Rows[0]["NguoiNhan"].ToString();
            }
        }

        private void frmChonChuongTrinh_CreateXMLData(object sender, EventArgs e)
        {
            DataTable tbl = _dataset.Tables.Add("ChonChuongTrinh");
            tbl.Columns.Add("MaChuongTrinh", typeof(int));
            tbl.Columns.Add("NguoiNhan", typeof(string));
            tbl.Rows.Add(0, "");
        }

        private void frmChonChuongTrinh_SaveXMLData(object sender, CancelEventArgs e)
        {
            if (Convert.ToDecimal(txtSoTien.Value) == 0)
            {
                MessageBox.Show("Bạn chưa nhập số tiền", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Cancel = true;
                return;
            }
            if (cmbChuongTrinh.Value != null)
            {
                _dataset.Tables["ChonChuongTrinh"].Rows[0]["MaChuongTrinh"] = cmbChuongTrinh.Value;
            }
            else
            {
                _dataset.Tables["ChonChuongTrinh"].Rows[0]["MaChuongTrinh"] = 0;
            }
            _dataset.Tables["ChonChuongTrinh"].Rows[0]["NguoiNhan"] = txtNguoiNhan.Text;
        }
    }
}