using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using ERP_Library;

namespace PSC_ERP
{
    public partial class frmBoPhan_NgayPhep : Form
    {
        private ERP_Library.BoPhan_NgayPhepList _data;
        private ERP_Library.BoPhanList _bophan;
        public frmBoPhan_NgayPhep()
        {
            InitializeComponent();
        }

        private void tlslblThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmBoPhan_NgayPhep_Load(object sender, EventArgs e)
        {
            _data = ERP_Library.BoPhan_NgayPhepList.GetBoPhan_NgayPhepList();
            boPhanNgayPhepBindingSource.DataSource = _data;

            _bophan = BoPhanList.GetBoPhanList();
            //_bophan = ERP_Library.BoPhanList.GetBoPhanList();
            foreach (ERP_Library.BoPhan tmp in _bophan)
            {
                grdData.DisplayLayout.ValueLists["BoPhan"].ValueListItems.Add(tmp.MaBoPhan, tmp.TenBoPhan);
            }
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
            MessageBox.Show("Lưu dữ liệu thành công!", "Lưu", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void tlslblUndo_Click(object sender, EventArgs e)
        {
            _data = ERP_Library.BoPhan_NgayPhepList.GetBoPhan_NgayPhepList();
            boPhanNgayPhepBindingSource.DataSource = _data;
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
    }
}