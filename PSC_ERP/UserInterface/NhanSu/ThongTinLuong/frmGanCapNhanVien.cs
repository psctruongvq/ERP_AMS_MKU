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
    public partial class frmGanCapNhanVien : Form
    {
        static int maLoaiBoPhan = 0;
        static int maBoPhan = 0;
        static int maKy = 0;
        BoPhanList _boPhanList;
        KyTinhLuongList _kyTinhLuongList,_kyTinhLuongSearch;
        LoaiBoPhanList _loaiBoPhanList;
        GhepCongNhanList _ghepCongNhanList;
        TTNhanVienRutGonList _ttNVChinh,_ttNVPhu;
        public frmGanCapNhanVien()
        {
            InitializeComponent();
        }

        private void frmGanCapNhanVien_Load(object sender, EventArgs e)
        {
            _loaiBoPhanList = LoaiBoPhanList.GetLoaiBoPhanList();
            this.bindingSource1_LoaiBoPhan.DataSource = _loaiBoPhanList;
            _boPhanList = BoPhanList.GetBoPhanList();
            this.bindingSource1_BoPhan.DataSource = _boPhanList;
            _kyTinhLuongList = KyTinhLuongList.GetKyTinhLuongList();
            this.bindingSource1_KyTinhLuong.DataSource = _kyTinhLuongList;
            _kyTinhLuongSearch = KyTinhLuongList.GetKyTinhLuongList();
            this.bindingSource1_KyTinhLuongSearch.DataSource = _kyTinhLuongSearch;
        }

        private void cbLoaiBoPhan_ValueChanged(object sender, EventArgs e)
        {
            maLoaiBoPhan = Convert.ToInt32(cbLoaiBoPhan.Value);
            _boPhanList = BoPhanList.GetBoPhanList_LoaiBoPhan(maLoaiBoPhan);
            this.bindingSource1_BoPhan.DataSource = _boPhanList;
        }
        private void TimKiem()
        {
            maBoPhan = Convert.ToInt32(cbBoPhan.Value);
            maKy = Convert.ToInt32(cbKyTinhLuongSearch.Value);
            _ttNVChinh = TTNhanVienRutGonList.GetNhanVienListBoPhan(maBoPhan);
            _ttNVPhu = _ttNVChinh;
            this.bindingSource_NhanVienChinh.DataSource = _ttNVChinh;
            this.bindingSource1_NhanVienPhu.DataSource = _ttNVPhu;
            _ghepCongNhanList = GhepCongNhanList.GetGhepCongNhanListByMaKy(maKy);
            this.bindingSource1GanCapNhanVien.DataSource = _ghepCongNhanList;
            if (_ghepCongNhanList.Count == 0)
            { MessageBox.Show("Không Tìm Thấy Dữ Liệu", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            TimKiem();
        }

        private void ultragrdDanToc_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            HamDungChung h = new HamDungChung();
            h.ultragrdEmail_InitializeLayout(sender, e);
            ultragrdDanToc.DisplayLayout.Bands[0].Columns["MaKyTinhLuong"].EditorComponent = cbKyTinhLuong;
            ultragrdDanToc.DisplayLayout.Bands[0].Columns["MaNhanVienChinh"].EditorComponent = cbNhanVienChinh;
            ultragrdDanToc.DisplayLayout.Bands[0].Columns["MaNhanVienPhu"].EditorComponent = cbNhanVienPhu;

        }

        private void tlslblLuu_Click(object sender, EventArgs e)
        {
            try
            {
                _ghepCongNhanList.ApplyEdit();
                _ghepCongNhanList.Save();
                MessageBox.Show("Cập nhật thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Cập nhật thất bại","Thông Báo",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void ultragrdDanToc_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ultragrdDanToc.UpdateData();
            }
        }

        private void tlslblXoa_Click(object sender, EventArgs e)
        {
            if (ultragrdDanToc.Selected.Rows.Count == 0)
            {
                MessageBox.Show("Chọn dòng cần xóa", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            ultragrdDanToc.DeleteSelectedRows();
        }

        private void tlslblUndo_Click(object sender, EventArgs e)
        {
            _ghepCongNhanList = GhepCongNhanList.GetGhepCongNhanListByMaKy(maKy);
            this.bindingSource1GanCapNhanVien.DataSource = _ghepCongNhanList;
        }

        private void tlslblTim_Click(object sender, EventArgs e)
        {
            TimKiem();
        }

        private void tlslblThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}