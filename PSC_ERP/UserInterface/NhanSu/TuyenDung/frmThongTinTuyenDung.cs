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
    public partial class frmThongTinTuyenDung : Form
    {
        public static long maTuyenDung = 0;
        ThongTinTuyenDungList _thongTinTuyenDungList;
        ThongTinTuyenDung _thongTinTuyenDung;
        CongViecList _congViecList;
        BoPhanList _boPhanList;
        public frmThongTinTuyenDung()
        {
            InitializeComponent();
        }

        private void frmThongTinTuyenDung_Load(object sender, EventArgs e)
        {
            _congViecList = CongViecList.GetCongViecList();
            this.bindingSource1_CongViec.DataSource = _congViecList;
            _boPhanList = BoPhanList.GetBoPhanList();
            this.bindingSource1_BoPhan.DataSource = _boPhanList;
            GridLoad();
        }
        private void GridLoad()
        {
            _thongTinTuyenDungList = ThongTinTuyenDungList.GetThongTinTuyenDungList();
            this.bindingSource1_ThongTinTuyenDung.DataSource = _thongTinTuyenDungList;
        }
        private void tlslblLuu_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < _thongTinTuyenDungList.Count; i++)
                {
                    if (_thongTinTuyenDungList[i].MaViTri <= 0)
                    {
                        MessageBox.Show("Công việc chưa chính xác", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    if (_thongTinTuyenDungList[i].MaBoPhan <= 0)
                    {
                        MessageBox.Show("Bộ phận chưa chính xác", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    if (_thongTinTuyenDungList[i].SoLuongTuyen <= 0)
                    {
                        MessageBox.Show("Số Lượng chưa chính xác", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    if (_thongTinTuyenDungList[i].TenTuyenDung == "")
                    {
                        MessageBox.Show("Tên tuyển dụng chưa chính xác", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
                _thongTinTuyenDungList.ApplyEdit();
                _thongTinTuyenDungList.Save();
                MessageBox.Show("Cập nhật thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                GridLoad();
            }
            catch (Exception ex)
            { 
                MessageBox.Show("Cập nhật thất bại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                GridLoad();
                return;
            }

        }

        private void tlslblThem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < _thongTinTuyenDungList.Count; i++)
            {
                if (_thongTinTuyenDungList[i].MaTuyenDung == 0)
                    return;
            }
            _thongTinTuyenDung = ThongTinTuyenDung.NewThongTinTuyenDung();
            _thongTinTuyenDungList.Add(_thongTinTuyenDung);
            this.ultragrdDanToc.ActiveRow = ultragrdDanToc.Rows[_thongTinTuyenDungList.Count - 1];

        }

        private void tlslblXoa_Click(object sender, EventArgs e)
        {
            if (this.ultragrdDanToc.Selected.Rows.Count == 0)
            {
                MessageBox.Show("Chọn Dòng Cần Xóa","Thông Báo",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return;
            }
            ultragrdDanToc.DeleteSelectedRows();
        }

        private void ultragrdDanToc_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            ultragrdDanToc.DisplayLayout.Bands[0].Columns["MaViTri"].EditorComponent = cbCongViec;
            ultragrdDanToc.DisplayLayout.Bands[0].Columns["MaBoPhan"].EditorComponent = cbBophan;
        }

        private void tlslblUndo_Click(object sender, EventArgs e)
        {
            GridLoad();
        }

        private void ultragrdDanToc_DoubleClickRow(object sender, Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs e)
        {
            maTuyenDung = Convert.ToInt64(ultragrdDanToc.ActiveRow.Cells["MaTuyenDung"].Value);
            frmThongTinUngVien ttUV = new frmThongTinUngVien();
            ttUV.Show();
        }

        private void tlslblThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
    }
}