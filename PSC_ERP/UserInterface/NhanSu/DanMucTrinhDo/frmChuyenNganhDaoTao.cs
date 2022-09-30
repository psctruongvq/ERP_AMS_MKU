using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ERP_Library;
namespace PSC_ERP
{
    public partial class frmChuyenNganhDaoTao : Form
    {
        ChuyenNganhDaoTaoClassList _list;
        public delegate void PassData(ChuyenNganhDaoTaoClassList value);
        public PassData getData;       

        public frmChuyenNganhDaoTao()
        {
            InitializeComponent();
        }

        private void ultragrdChuyenMonNghiepVu_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            HamDungChung hdc = new HamDungChung();
            hdc.ultragrdEmail_InitializeLayout(sender, e);
        }

        private void tlslblLuu_Click(object sender, EventArgs e)
        {
            try
            {
                _list.ApplyEdit();
                _list.Save();
                MessageBox.Show("Cập Nhật Thành Công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (getData != null)
                {
                    getData(_list);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Cập Nhật Thất Bại","Thông Báo",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void frmChuyenNganhDaoTao_Load(object sender, EventArgs e)
        {
            _list = ChuyenNganhDaoTaoClassList.GetChuyenNganhDaoTaoClassList();
            this.ChuyenNganhDaoTao_bindingSource.DataSource = _list;
        }

        private void tlslblXoa_Click(object sender, EventArgs e)
        {
            if (ultragrdChuyenMonNghiepVu.Selected.Rows.Count == 0)
            {
                MessageBox.Show("Chọn dòng cần xóa", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            ultragrdChuyenMonNghiepVu.DeleteSelectedRows();

        }

        private void tlslblUndo_Click(object sender, EventArgs e)
        {
            _list = ChuyenNganhDaoTaoClassList.GetChuyenNganhDaoTaoClassList();
            this.ChuyenNganhDaoTao_bindingSource.DataSource = _list;
        }

        private void tlslblThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ultragrdChuyenMonNghiepVu_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //ultragrdChuyenMonNghiepVu.UpdateData();
            }
        }

        private void tlslblExportExcel_Click(object sender, EventArgs e)
        {
            HamDungChung.ExportToExcel(ultragrdChuyenMonNghiepVu);
        }
    }
}