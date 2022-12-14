using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PSC_ERP
{
    public partial class frmChamTangCaTongHop : Form
    {
        private bool OK = false;
        private ERP_Library.NhanVienComboList _Data;
        private ERP_Library.BoPhan _BoPhan;
        private ERP_Library.KyTinhLuong _KyLuong;

        public frmChamTangCaTongHop()
        {
            InitializeComponent();
        }

        private void frmChamTangCaHangLoat_Load(object sender, EventArgs e)
        {
        }

        public bool ChamTangCa(ERP_Library.KyTinhLuong KyLuong, ERP_Library.BoPhan BoPhan)
        {
            _BoPhan = BoPhan;
            _KyLuong = KyLuong;
            radBoPhan.Text += " " + _BoPhan.TenBoPhan;
            radNhanVien.Text += " " + _BoPhan.TenBoPhan;
            this.ShowDialog();
            return OK;
        }

        private void radNhanVien_CheckedChanged(object sender, EventArgs e)
        {
            if (_Data == null && radNhanVien.Checked)
            {
                _Data = ERP_Library.NhanVienComboList.GetNhanVienByMaBoPhan(_BoPhan.MaBoPhan);
                grdData.DataSource = _Data;
            }
            grdData.Enabled = radNhanVien.Checked;
        }

        private void btnKhong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDongY_Click(object sender, EventArgs e)
        {
            Nullable<decimal> ngaythuong = null;
            Nullable<decimal> ngayle = null;
            Nullable<decimal> thu7cn = null;

            try
            {
                if (chkNgayThuong.Checked)
                    ngaythuong = Convert.ToDecimal(txtNgayThuong.Value);
                if (chkT7CN.Checked)
                    thu7cn = Convert.ToDecimal(txtT7CN.Value);
                if (chkNgayLe.Checked)
                    ngayle = Convert.ToDecimal(txtNgayLe.Value);
            }
            catch { }

            if (!ngaythuong.HasValue && !thu7cn.HasValue && !ngayle.HasValue)
            {
                MessageBox.Show("Bạn chưa nhập số giờ tăng ca", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            ChamTangCaNhanVien(ngaythuong, thu7cn, ngayle);
            OK = true;
            this.Close();
        }

        private void ChamTangCaNhanVien(Nullable<decimal> NgayThuong, Nullable<decimal> T7CN, Nullable<decimal> NgayLe)
        {
            if (radTatCa.Checked)
                ERP_Library.BangTangCaNhanVienList.ChamTongHopTatCa(_KyLuong.MaKy, NgayThuong, T7CN, NgayLe);
            else if (radBoPhan.Checked)
                ERP_Library.BangTangCaNhanVienList.ChamTongHopBoPhan(_KyLuong.MaKy, (int)_BoPhan.MaBoPhan, NgayThuong, T7CN, NgayLe);
            else
            {
                foreach (Infragistics.Win.UltraWinGrid.UltraGridRow r in grdData.Rows)
                    if ((bool)r.Cells["Chon"].Value)
                        ERP_Library.BangTangCaNhanVienList.ChamTongHopNhanVien(_KyLuong.MaKy, (long)r.Cells["MaNhanVien"].Value, NgayThuong, T7CN, NgayLe);
            }
            MessageBox.Show("Đã chấm tăng ca cho nhân viên", "Tăng ca", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void grdData_AfterCellUpdate(object sender, Infragistics.Win.UltraWinGrid.CellEventArgs e)
        {
            int tong = 0;
            foreach (Infragistics.Win.UltraWinGrid.UltraGridRow r in grdData.Rows)
                if ((bool)r.Cells["Chon"].Value)
                    tong++;
            txtSoNV.Text = tong.ToString("#,###");
        }

        private void grdData_CellChange(object sender, Infragistics.Win.UltraWinGrid.CellEventArgs e)
        {
            if (e.Cell.Column.Key == "Chon")
                e.Cell.Row.Update();
        }

        private void chkNgayThuong_CheckedChanged(object sender, EventArgs e)
        {
            txtNgayThuong.Enabled = chkNgayThuong.Checked;
        }

        private void chkT7CN_CheckedChanged(object sender, EventArgs e)
        {
            txtT7CN.Enabled = chkT7CN.Checked;
        }

        private void chkNgayLe_CheckedChanged(object sender, EventArgs e)
        {
            txtNgayLe.Enabled = chkNgayLe.Checked;
        }
    }
}