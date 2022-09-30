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
    public partial class frmChungTuGiamTruGiaCanh : Form
    {
        public frmChungTuGiamTruGiaCanh()
        {
            InitializeComponent();
        }
        ChungTuGiamTruGiaCanhList _list;
        private void frmChungTuGiamTruGiaCanh_Load(object sender, EventArgs e)
        {
            _list = ChungTuGiamTruGiaCanhList.GetChungTuGiamTruGiaCanhList();
            this.ChungTu_bindingSource.DataSource = _list;
        }

        private void tlslblLuu_Click(object sender, EventArgs e)
        {
            this.ultragrdChucVu.UpdateData();
            this.ChungTu_bindingSource.EndEdit();
            _list.ApplyEdit();
            _list.Save();
            MessageBox.Show("Cập nhật thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            _list = ChungTuGiamTruGiaCanhList.GetChungTuGiamTruGiaCanhList();
            this.ChungTu_bindingSource.DataSource = _list;
        }

        private void tlslblUndo_Click(object sender, EventArgs e)
        {
            _list = ChungTuGiamTruGiaCanhList.GetChungTuGiamTruGiaCanhList();
            this.ChungTu_bindingSource.DataSource = _list;
        }

        private void tlslblXoa_Click(object sender, EventArgs e)
        {
            ultragrdChucVu.DeleteSelectedRows();
        }

        private void tlslblThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ultragrdChucVu_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            HamDungChung h = new HamDungChung();
            h.ultragrdEmail_InitializeLayout(sender, e);
        }

        private void tlslblExportExcel_Click(object sender, EventArgs e)
        {
            HamDungChung.ExportToExcel(ultragrdChucVu);
        }
    }
}