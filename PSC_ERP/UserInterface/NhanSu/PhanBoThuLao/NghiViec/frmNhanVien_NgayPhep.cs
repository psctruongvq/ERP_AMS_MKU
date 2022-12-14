using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
namespace PSC_ERP
{
    public partial class frmNhanVien_NgayPhep : Form
    {
        private ERP_Library.NhanVien_NgayPhepList _data;
        public frmNhanVien_NgayPhep()
        {
            InitializeComponent();
        }

        private void tlslblThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tlslblUndo_Click(object sender, EventArgs e)
        {
            _data = ERP_Library.NhanVien_NgayPhepList.GetNhanVien_NgayPhepList();
            nhanVienNgayPhepBindingSource.DataSource = _data;
        }

        private void frmNhanVien_NgayPhep_Load(object sender, EventArgs e)
        {
            try
            {
                _data = ERP_Library.NhanVien_NgayPhepList.GetNhanVien_NgayPhepList();
                nhanVienNgayPhepBindingSource.DataSource = _data;
                ERP_Library.NhanVienComboList nv = ERP_Library.NhanVienComboList.GetNhanVienAll();
                foreach (ERP_Library.NhanVienComboListChild tmp in nv)
                {
                    grdData.DisplayLayout.ValueLists["NhanVien"].ValueListItems.Add(tmp.MaNhanVien, tmp.TenNhanVien);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
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
    }
}