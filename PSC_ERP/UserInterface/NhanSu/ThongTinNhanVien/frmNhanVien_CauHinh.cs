using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PSC_ERP
{
    public partial class frmNhanVien_CauHinh : Form
    {
        private ERP_Library.NhanVien_CauHinhList _data;
        public frmNhanVien_CauHinh()
        {
            InitializeComponent();
        }

        private void tlslblThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmNhanVien_CauHinh_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                _data = ERP_Library.NhanVien_CauHinhList.GetNhanVien_CauHinhList();
                bdData.DataSource = _data;
            }
            catch (Exception ex)
            {
                frmThongBaoLoiDuLieu.ThongBaoLoi(ex, _data);
            }
        }

        private void SaveData()
        {
            try
            {
                grdData.UpdateData();
                _data.Save();
                MessageBox.Show("Dữ liệu đã lưu thành công!", "Lưu dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                frmThongBaoLoiDuLieu.ThongBaoLoi(ex, _data);
            }
        }

        private void tlslblUndo_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void tlslblXoa_Click(object sender, EventArgs e)
        {
            grdData.DeleteSelectedRows();
        }

        private void tlslblLuu_Click(object sender, EventArgs e)
        {
            SaveData();
        }

        private void frmNhanVien_CauHinh_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_data != null && _data.IsDirty)
                if (MessageBox.Show("Dữ liệu đã thay đổi. Bạn có muốn lưu lại không?", "Lưu dữ liệu", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    SaveData();
        }
    }
}