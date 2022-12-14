using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PSC_ERP
{
    public partial class frmLoaiDocHai : Form
    {
        private ERP_Library.LoaiDocHaiList _data;
        public frmLoaiDocHai()
        {
            InitializeComponent();
        }

        private void tlslblThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmLoaiDocHai_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            _data = ERP_Library.LoaiDocHaiList.GetLoaiDocHaiList();
            bdData.DataSource = _data;
        }

        private void tlslblLuu_Click(object sender, EventArgs e)
        {
            try
            {
                grdData.UpdateData();
                _data.Save();
                MessageBox.Show("Đã lưu dữ liệu thành công!", "Lưu", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                frmThongBaoLoiDuLieu.ThongBaoLoi(ex, _data);
            }
        }

        private void tlslblXoa_Click(object sender, EventArgs e)
        {
            grdData.DeleteSelectedRows();
        }

        private void tlslblUndo_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void grdData_BeforeRowsDeleted(object sender, Infragistics.Win.UltraWinGrid.BeforeRowsDeletedEventArgs e)
        {
            e.Cancel = MessageBox.Show("Bạn có muốn xóa loại độc hại này không?", "Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No;
            e.DisplayPromptMsg = false;
        }

        private void tlslblExportExcel_Click(object sender, EventArgs e)
        {
            HamDungChung.ExportToExcel(grdData);
        }
    }
}