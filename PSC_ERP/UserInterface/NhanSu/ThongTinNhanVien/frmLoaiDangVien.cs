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
    public partial class frmLoaiDangVien : Form
    {
        LoaiDangVienList _list;
        public frmLoaiDangVien()
        {
            InitializeComponent();
        }

        private void frmLoaiDangVien_Load(object sender, EventArgs e)
        {
            _list = LoaiDangVienList.GetLoaiDangVienList();
            this.LoaiDangVien_bindingSource.DataSource = _list;
        }

        private void tlslblLuu_Click(object sender, EventArgs e)
        {
            try {
                _list.ApplyEdit();
                _list.Save();
                MessageBox.Show("Cập nhật thành công","Thông Báo",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
            catch (Exception ex) { throw ex; }
        }

        private void tlslblUndo_Click(object sender, EventArgs e)
        {
            _list = LoaiDangVienList.GetLoaiDangVienList();
            this.LoaiDangVien_bindingSource.DataSource = _list;
        }

        private void tlslblThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tlslblXoa_Click(object sender, EventArgs e)
        {
            this.grdu_LoaiDangVien.DeleteSelectedRows();
        }

        private void tlslblExportExcel_Click(object sender, EventArgs e)
        {
            HamDungChung.ExportToExcel(grdu_LoaiDangVien);
        }

        private void grdu_LoaiDangVien_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            HamDungChung h = new HamDungChung();
            h.ultragrdEmail_InitializeLayout(sender, e);
        }
    }
}