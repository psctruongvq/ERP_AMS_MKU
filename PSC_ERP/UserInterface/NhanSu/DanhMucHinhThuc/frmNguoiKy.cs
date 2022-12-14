using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PSC_ERP
{
    public partial class frmNguoiKy : Form
    {
        private ERP_Library.NguoiKyList _data;
        public frmNguoiKy()
        {
            InitializeComponent();
        }

        private void tlslblThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmLoaiKinhPhi_Load(object sender, EventArgs e)
        {
            _data = ERP_Library.NguoiKyList.GetNguoiKyList();
            bdData.DataSource = _data;
        }

        private void tlslblLuu_Click(object sender, EventArgs e)
        {
            grdData.UpdateData();
            try
            {
                _data.Save();
                MessageBox.Show("Đã lưu dữ liệu thành công", "Lưu", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                frmThongBaoLoiDuLieu.ThongBaoLoi(ex, _data);
            }
        }

        private void tlslblUndo_Click(object sender, EventArgs e)
        {
            _data = ERP_Library.NguoiKyList.GetNguoiKyList();
            bdData.DataSource = _data;
        }

        private void tlslblXoa_Click(object sender, EventArgs e)
        {
            grdData.DeleteSelectedRows();
        }

        private void grdData_BeforeRowsDeleted(object sender, Infragistics.Win.UltraWinGrid.BeforeRowsDeletedEventArgs e)
        {
            e.DisplayPromptMsg = false;
            e.Cancel = MessageBox.Show("Bạn có muốn xóa không?", "Xóa", MessageBoxButtons.YesNo) == DialogResult.No;
        }

        private void tlslblExportExcel_Click(object sender, EventArgs e)
        {
            HamDungChung.ExportToExcel(grdData);
        }
    }
}