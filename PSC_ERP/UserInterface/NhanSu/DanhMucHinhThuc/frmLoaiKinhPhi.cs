using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PSC_ERP
{
    public partial class frmLoaiKinhPhi : Form
    {
        private ERP_Library.LoaiKinhPhiList _data;
        public frmLoaiKinhPhi()
        {
            InitializeComponent();
        }

        private void tlslblThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmLoaiKinhPhi_Load(object sender, EventArgs e)
        {
            _data = ERP_Library.LoaiKinhPhiList.GetLoaiKinhPhiList();
            bdLoaiKinhPhi.DataSource = _data;
        }

        private void tlslblLuu_Click(object sender, EventArgs e)
        {
            grdData.UpdateData();
            try
            {
                _data.Save();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Dữ liệu không hợp lệ!\n" + ex.Message, "Lỗi");
            }
        }

        private void tlslblUndo_Click(object sender, EventArgs e)
        {
            _data = ERP_Library.LoaiKinhPhiList.GetLoaiKinhPhiList();
            bdLoaiKinhPhi.DataSource = _data;
        }

        private void tlslblXoa_Click(object sender, EventArgs e)
        {
            grdData.DeleteSelectedRows();
        }

        private void grdData_BeforeRowsDeleted(object sender, Infragistics.Win.UltraWinGrid.BeforeRowsDeletedEventArgs e)
        {
            e.DisplayPromptMsg = false;
            e.Cancel = MessageBox.Show("Bạn có muốn xóa ngày phép bộ phận này không?", "Xóa", MessageBoxButtons.YesNo) == DialogResult.No;
        }

        private void tlslblExportExcel_Click(object sender, EventArgs e)
        {
            HamDungChung.ExportToExcel(grdData);
        }
    }
}