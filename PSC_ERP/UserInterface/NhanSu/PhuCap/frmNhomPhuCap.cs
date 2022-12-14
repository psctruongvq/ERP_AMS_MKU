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
    public partial class frmNhomPhuCap : Form
    {
        public frmNhomPhuCap()
        {
            InitializeComponent();
        }
        NhomPhuCapList _Data;
        private void tlslblLuu_Click(object sender, EventArgs e)
        {
            SaveData();
        }
        private void SaveData()
        {
            try
            {
                grdData.UpdateData();
                _Data.Save();
                MessageBox.Show("Dữ liệu lưu thành công!", "Lưu", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                frmThongBaoLoiDuLieu.ThongBaoLoi(ex, _Data);
            }
        }
        private void tlslblThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tlslblTroGiup_Click(object sender, EventArgs e)
        {

        }

        private void frmNhomPhuCap_Load(object sender, EventArgs e)
        {
            _Data = NhomPhuCapList.GetNhomPhuCapList();
            bdData.DataSource = _Data;
        }

        private void tlslblXoa_Click(object sender, EventArgs e)
        {
            grdData.DeleteSelectedRows();
        }

        private void tlslblUndo_Click(object sender, EventArgs e)
        {
            _Data = NhomPhuCapList.GetNhomPhuCapList();
            bdData.DataSource = _Data;
        }

        private void grdData_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            //HamDungChung t = new HamDungChung();
            //t.ultragrdEmail_InitializeLayout(sender, e);
        }

        private void tlslblExportExcel_Click(object sender, EventArgs e)
        {
            HamDungChung.ExportToExcel(grdData);
        }
    }
}