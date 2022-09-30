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
    public partial class frmNhomNgachLuongBaoHiem : Form
    {
        NhomNgachLuongBaoHiemList _nhomNgachList;
        public frmNhomNgachLuongBaoHiem()
        {
            InitializeComponent();
        }

        private void ultragrdNgachLuongCoBan_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            HamDungChung h = new HamDungChung();
            h.ultragrdEmail_InitializeLayout(sender, e);
        }

        private void frmNhomNgachLuongBaoHiem_Load(object sender, EventArgs e)
        {
            _nhomNgachList = NhomNgachLuongBaoHiemList.GetNhomNgachLuongBaoHiemList();
            this.bindingSource1_NhomNgachLuongBaoHiem.DataSource = _nhomNgachList;
        }

        private void tlslblLuu_Click(object sender, EventArgs e)
        {
            try
            {
                _nhomNgachList.ApplyEdit();
                _nhomNgachList.Save();
                MessageBox.Show("Cập nhật thành công","Thông Báo",MessageBoxButtons.OK,MessageBoxIcon.Information);
                _nhomNgachList = NhomNgachLuongBaoHiemList.GetNhomNgachLuongBaoHiemList();
                this.bindingSource1_NhomNgachLuongBaoHiem.DataSource = _nhomNgachList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void tlslblXoa_Click(object sender, EventArgs e)
        {
            ultragrdNgachLuongCoBan.DeleteSelectedRows();
        }

        private void tlslblUndo_Click(object sender, EventArgs e)
        {
            _nhomNgachList = NhomNgachLuongBaoHiemList.GetNhomNgachLuongBaoHiemList();
            this.bindingSource1_NhomNgachLuongBaoHiem.DataSource = _nhomNgachList;
        }

        private void tlslblThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ultragrdNgachLuongCoBan_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ultragrdNgachLuongCoBan.UpdateData();
            }
        }

        private void tlslblExportExcel_Click(object sender, EventArgs e)
        {
            HamDungChung.ExportToExcel(ultragrdNgachLuongCoBan);
        }
    }
}