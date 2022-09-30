using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ERP_Library;
using Infragistics.Win.UltraWinGrid;
namespace PSC_ERP
{
    public partial class frmDanhSachGiayXacNhan : Form
    {
        GiayXacNhanChuongTrinhList _giayXacNhanList=GiayXacNhanChuongTrinhList.NewGiayXacNhanChuongTrinhList();
        Boolean _loaiGiayXacNhan = false;
        public frmDanhSachGiayXacNhan()
        {
            InitializeComponent();

        }
        public frmDanhSachGiayXacNhan(Boolean loaiGiayXacNhan)
        {
            InitializeComponent();
            _loaiGiayXacNhan = loaiGiayXacNhan;
        }
        public void ShowGiayXacNhanChuongTrinh()
        {
            this.GiayXacNhanChuongTrinh_bindingSource.DataSource = typeof(GiayXacNhanChuongTrinhList);
            this.Show();
        }

        public void ShowGiayXacNhanTrucTiep()
        {
            _loaiGiayXacNhan = true;// Giấy xác nhận trực tiếp
            this.GiayXacNhanChuongTrinh_bindingSource.DataSource = typeof(GiayXacNhanChuongTrinhList);

            this.Text = "Danh sách giấy xác nhận trực tiếp";
            this.Show();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            _giayXacNhanList=GiayXacNhanChuongTrinhList.GetGiayXacNhanChuongTrinhListByNgayLap(Convert.ToDateTime(dateTuNgay.Value),Convert.ToDateTime(dateDenNgay.Value),cbIsDeleted.Checked, _loaiGiayXacNhan);
            this.GiayXacNhanChuongTrinh_bindingSource.DataSource = _giayXacNhanList;
        }

        private void ultraGrid1_DoubleClick(object sender, EventArgs e)
        {
            if (ultraGrid1.ActiveRow != null)
            {
                if (ultraGrid1.ActiveRow.IsFilterRow != true)
                {
                    int maGiayXacNhan = (int)ultraGrid1.ActiveRow.Cells["MaGiayXacNhan"].Value;
                    frmGiayXacNhanChuongTrinhNew f = new frmGiayXacNhanChuongTrinhNew(maGiayXacNhan,_loaiGiayXacNhan);
                    f.Show();
                }
            }
        }

        private void tlslblThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tlslblLuu_Click(object sender, EventArgs e)
        {
            _giayXacNhanList.ApplyEdit();
            _giayXacNhanList.Save();
            MessageBox.Show("Cập nhật thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            
        }

        private void tlslblXoa_Click(object sender, EventArgs e)
        {
            ultraGrid1.DeleteSelectedRows();
        }

        private void tlslblIn_Click(object sender, EventArgs e)
        {
            if (ultraGrid1.ActiveRow != null)
            {
                if (ultraGrid1.Selected.Rows.Count != 1)
                {
                    MessageBox.Show("Chọn một dòng để In", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                int maGiayXacNhan = (int)ultraGrid1.ActiveRow.Cells["MaGiayXacNhan"].Value;
                //if (!_loaiGiayXacNhan)
                //{
                frmGiayXacNhanChuongTrinhNew.InGiayXacNhanChuongTrinh(maGiayXacNhan, _loaiGiayXacNhan);
                //}
                //else
                //{
                //    frmGiayXacNhanChuongTrinhNew.InGiayXacNhanTrucTiep(maGiayXacNhan, _loaiGiayXacNhan);
                //}
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            HamDungChung.ExportToExcel(ultraGrid1);
        }

        private void ultraGrid1_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            HamDungChung h = new HamDungChung();
            h.ultragrdEmail_InitializeLayout(sender, e);
            e.Layout.Override.AllowAddNew = AllowAddNew.No;
        }
    }
}