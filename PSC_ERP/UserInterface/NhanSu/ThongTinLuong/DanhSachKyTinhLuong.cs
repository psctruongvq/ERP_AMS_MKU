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
    public partial class frmKyTinhLuong_BoPhan : Form
    {
        
        Util util = new Util();        
        BoPhanList _boPhanList;
        BoPhan_KyTinhLuongList _boPhan_KyTinhLuongList;
        KyTinhLuongList _kyTinhLuongList;
        public frmKyTinhLuong_BoPhan()
        {
            InitializeComponent();
        }


        private void frmKyTinhLuong_BoPhan_Load(object sender, EventArgs e)
        {
            _boPhanList = BoPhanList.GetBoPhanList();
            this.bindingSource1_BoPhan.DataSource = _boPhanList;
            _boPhan_KyTinhLuongList = BoPhan_KyTinhLuongList.GetBoPhan_KyTinhLuongListByKyTinhLuong(frmKyTinhLuong.maKyTinhLuong);
            this.bindingSource1_BoPhanKyTinhLuong.DataSource = _boPhan_KyTinhLuongList;
            cbKyTinhLuong.Value = (object)frmKyTinhLuong.maKyTinhLuong;
            _kyTinhLuongList = KyTinhLuongList.GetKyTinhLuongList();
            this.bindingSource1_KyTinhLuong.DataSource = _kyTinhLuongList;
        }

        private void ultragrdDanToc_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            HamDungChung h = new HamDungChung();
            h.ultragrdEmail_InitializeLayout(sender, e);
            ultragrdDanToc.DisplayLayout.Bands[0].Columns["MaBoPhan"].EditorComponent = cbBoPhan;
            ultragrdDanToc.DisplayLayout.Bands[0].Columns["MaKyTinhLuong"].EditorComponent = cbKyTinhLuong;
        }

        private void tlslblLuu_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < _boPhan_KyTinhLuongList.Count; i++)
                {
                    if (_boPhan_KyTinhLuongList[i].MaBoPhan == 0)
                    {
                        MessageBox.Show("Bộ Phận Chưa Chính Xác", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    if (_boPhan_KyTinhLuongList[i].SoNgayLVTT <= 0 || _boPhan_KyTinhLuongList[i].SoNgayLVTT>31)
                    {
                        MessageBox.Show("Ngày Làm Việc Thực Tế Chưa Chính Xác", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    if (_boPhan_KyTinhLuongList[i].SoCongTinhChuyenCan <= 0 || _boPhan_KyTinhLuongList[i].SoCongTinhChuyenCan > 31)
                    {
                        MessageBox.Show("Số Công Tính Chuyên Cần Chưa Chính Xác", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    _boPhan_KyTinhLuongList[i].MaKyTinhLuong = frmKyTinhLuong.maKyTinhLuong;

                }
                _boPhan_KyTinhLuongList.ApplyEdit();
                _boPhan_KyTinhLuongList.Save();
                MessageBox.Show(this, util.thanhcong, util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, util.thatbai, util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ultragrdDanToc_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ultragrdDanToc.UpdateData();
            }
        }

        private void cbKyTinhLuong_ValueChanged(object sender, EventArgs e)
        {
            cbKyTinhLuong.SetInitialValue(frmKyTinhLuong.maKyTinhLuong, KyTinhLuong.GetKyTinhLuong(frmKyTinhLuong.maKyTinhLuong).TenKy);
        }

        private void tlslblXoa_Click(object sender, EventArgs e)
        {
            if (ultragrdDanToc.Selected.Rows.Count == 0)
            {
                MessageBox.Show(util.chodongcanxoa, util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            ultragrdDanToc.DeleteSelectedRows();
        }

        private void tlslblUndo_Click(object sender, EventArgs e)
        {
            _boPhanList = BoPhanList.GetBoPhanList();
            this.bindingSource1_BoPhan.DataSource = _boPhanList;
            _boPhan_KyTinhLuongList = BoPhan_KyTinhLuongList.GetBoPhan_KyTinhLuongListByKyTinhLuong(frmKyTinhLuong.maKyTinhLuong);
            this.bindingSource1_BoPhanKyTinhLuong.DataSource = _boPhan_KyTinhLuongList;
            // cbKyTinhLuong.Value = (object)frmKyTinhLuong.maKyTinhLuong;
            _kyTinhLuongList = KyTinhLuongList.GetKyTinhLuongList();
            this.bindingSource1_KyTinhLuong.DataSource = _kyTinhLuongList;
        }

        private void tlslblThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}