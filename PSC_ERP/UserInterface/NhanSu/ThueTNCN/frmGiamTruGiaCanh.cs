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
    public partial class frmGiamTruGiaCanh : Form
    {
       
        GiamTruGiaCanhList _giamTruGiaCanhList;
        Util util=new Util();        
        public frmGiamTruGiaCanh()
        {
            InitializeComponent();
        }

        private void GiamTruGiaCanh_Load(object sender, EventArgs e)
        {
            this._giamTruGiaCanhList = GiamTruGiaCanhList.GetGiamTruGiaCanhList();
            this.bindingSource1_GiamTruGiaCanh.DataSource = _giamTruGiaCanhList;
        }

        private void ultragrdChuyenMonNghiepVu_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            HamDungChung t = new HamDungChung();
            t.ultragrdEmail_InitializeLayout(sender, e);
        }

        private void tlslblLuu_Click(object sender, EventArgs e)
        {
            GiamTruGiaCanh _giamTruGiaCanh;
            for (int i = 0; i < _giamTruGiaCanhList.Count; i++)
            {
                _giamTruGiaCanh = _giamTruGiaCanhList[i];
                if (_giamTruGiaCanh.MaQLGiaCanh == string.Empty)
                {
                    MessageBox.Show(this, "Vui Lòng Nhập Mã Quản Lý", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    ultragrdChuyenMonNghiepVu.ActiveRow = ultragrdChuyenMonNghiepVu.Rows[i + 1];
                    ultragrdChuyenMonNghiepVu.Focus();
                    return;
                }
                else if (_giamTruGiaCanh.TenGiaCanh == string.Empty)
                {
                    MessageBox.Show(this, "Vui Lòng Nhập Tên Gia Cảnh", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    ultragrdChuyenMonNghiepVu.ActiveRow = ultragrdChuyenMonNghiepVu.Rows[i + 1];
                    ultragrdChuyenMonNghiepVu.Focus();
                    return;
                }
                else if (_giamTruGiaCanh.SoTienGiamTru < 0)
                {
                    MessageBox.Show(this, "Vui Lòng Nhập Đúng Số Tiền", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    ultragrdChuyenMonNghiepVu.ActiveRow = ultragrdChuyenMonNghiepVu.Rows[i + 1];
                    ultragrdChuyenMonNghiepVu.Focus();
                    return;
                }
            }

            try
            {
                ultragrdChuyenMonNghiepVu.UpdateData();
                _giamTruGiaCanhList.ApplyEdit();
                _giamTruGiaCanhList.Save();
                MessageBox.Show(util.thanhcong, util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(util.thatbai, util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void ultragrdChuyenMonNghiepVu_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ultragrdChuyenMonNghiepVu.UpdateData();
            }
        }

        private void tlslblXoa_Click(object sender, EventArgs e)
        {
            if (ultragrdChuyenMonNghiepVu.Selected.Rows.Count == 0)
            {
                MessageBox.Show(util.chodongcanxoa, util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            ultragrdChuyenMonNghiepVu.DeleteSelectedRows();
        }

        private void tlslblUndo_Click(object sender, EventArgs e)
        {
            this._giamTruGiaCanhList = GiamTruGiaCanhList.GetGiamTruGiaCanhList();
            this.bindingSource1_GiamTruGiaCanh.DataSource = _giamTruGiaCanhList;
        }

        private void tlslblThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tlslblExportExcel_Click(object sender, EventArgs e)
        {
            HamDungChung.ExportToExcel(ultragrdChuyenMonNghiepVu);
        }
    }
}