using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ERP_Library;
using System.Diagnostics;

namespace PSC_ERP.UserInterface.KhachHang
{
    public partial class frmDanhSachHocSinh : DevExpress.XtraEditors.XtraForm
    {
        DoiTacList _doiTacList = DoiTacList.NewDoiTacList();
        public frmDanhSachHocSinh()
        {
            InitializeComponent();
        }

        private void frmDanhSachHocSinh_Load(object sender, EventArgs e)
        {
            _doiTacList = DoiTacList.GetHocSinhList();
            bindingSource_HocSinh.DataSource = _doiTacList;
            gridControl1.DataSource = bindingSource_HocSinh;
        }

        private void btnExcel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = "Excel File (*.xls)|.xls|All file (*.*)|.*";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                gridControl1.ExportToXls(dlg.FileName);
                MessageBox.Show("Đã xuất dữ liệu thành công", "Xuất dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Process.Start(dlg.FileName);
            }
        }

        private void btnThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void btnSearch_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DoiTacList.GetDoiTacList_Refresh();
        }
    }
}