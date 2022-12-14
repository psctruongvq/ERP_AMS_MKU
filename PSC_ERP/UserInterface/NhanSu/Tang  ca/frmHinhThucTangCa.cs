using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PSC_ERP
{
    public partial class frmHinhThucTangCa : Form
    {
        private ERP_Library.HinhThucTangCaList _Data;

        public frmHinhThucTangCa()
        {
            InitializeComponent();
            this.FormClosing += new FormClosingEventHandler(frmHinhThucTangCa_FormClosing);
        }

        void frmHinhThucTangCa_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_Data != null && _Data.IsDirty)
                if (MessageBox.Show("Dữ liệu đã thay đổi. Bạn có muốn lưu lại không?", "Lưu dữ liệu", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    SaveData();
        }

        private void tlslblThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmHinhThucTangCa_Load(object sender, EventArgs e)
        {
            cmbNhomPC.DataSource = ERP_Library.NhomPhuCapList.GetNhomPhuCapList();
            _Data = ERP_Library.HinhThucTangCaList.GetHinhThucTangCaList();
            bdData.DataSource = _Data;
        }

        private void tlslblXoa_Click(object sender, EventArgs e)
        {
            grdData.DeleteSelectedRows();
        }

        private void grdData_BeforeRowsDeleted(object sender, Infragistics.Win.UltraWinGrid.BeforeRowsDeletedEventArgs e)
        {
            e.DisplayPromptMsg = false;
            e.Cancel = MessageBox.Show("Bạn có muốn xóa hình thức tăng ca này không?", "Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No;
        }

        private void SaveData()
        {
            try
            {
                bdData.EndEdit();
                _Data.Save();
                MessageBox.Show("Đã lưu dữ liệu thành công", "Lưu", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                frmThongBaoLoiDuLieu.ThongBaoLoi(ex, _Data);
            }
        }

        private void tlslblLuu_Click(object sender, EventArgs e)
        {
            SaveData();
        }

        private void tlslblThem_Click(object sender, EventArgs e)
        {
            _Data.AddNew();
            grdData.ActiveRow = grdData.Rows[grdData.Rows.Count - 1];
            grdData.ActiveRow.Selected = true;
        }

        private void tlslblUndo_Click(object sender, EventArgs e)
        {
            _Data = ERP_Library.HinhThucTangCaList.GetHinhThucTangCaList();
            bdData.DataSource = _Data;
        }

        private void cmbNhomPC_ValueChanged(object sender, EventArgs e)
        {
            if (cmbNhomPC.Value != null)
                cmbLoaiPC.DataSource = ERP_Library.LoaiPhuCapList.GetLoaiPhuCapByMaNhom((int)cmbNhomPC.Value);
        }

        private void tlslblExportExcel_Click(object sender, EventArgs e)
        {
            HamDungChung.ExportToExcel(grdData);
        }
    }
}