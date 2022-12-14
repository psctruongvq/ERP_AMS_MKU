using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PSC_ERP
{
    public partial class frmChamTangCaHangLoat : Form
    {
        private bool OK = false;
        private ERP_Library.NhanVienComboList _Data;
        private ERP_Library.BoPhan _BoPhan;
        private ERP_Library.KyTinhLuong _KyLuong;

        public frmChamTangCaHangLoat()
        {
            InitializeComponent();
        }

        private void frmChamTangCaHangLoat_Load(object sender, EventArgs e)
        {
            txtNgay.Value = DateTime.Today;
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
            if (txtNgay.DateTime < _KyLuong.NgayBatDau || txtNgay.DateTime > _KyLuong.NgayKetThuc)
            {
                MessageBox.Show("Bạn chọn ngày chấm tăng ca vượt ngoài kỳ tính lương", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            decimal so = 0;
            try
            {
                so = Convert.ToDecimal(txtSoGio.Value);
            }
            catch { }
            if (so<=0 || so >8 )
            {
                MessageBox.Show("Số giờ tăng ca không hợp lệ 1 -> 8", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }


            ChamTangCaNhanVien();
            OK = true;
            this.Close();
        }

        private void ChamTangCaNhanVien()
        {
            if (radTatCa.Checked)
                ERP_Library.BangTangCaNhanVienList.ChamTangCaTatCa(_KyLuong.MaKy, txtNgay.DateTime, Convert.ToDecimal(txtSoGio.Value));
            else if (radBoPhan.Checked)
                ERP_Library.BangTangCaNhanVienList.ChamTangCaBoPhan(_KyLuong.MaKy, txtNgay.DateTime, Convert.ToDecimal(txtSoGio.Value), _BoPhan.MaBoPhan);
            else
            {
                foreach (Infragistics.Win.UltraWinGrid.UltraGridRow r in grdData.Rows)
                    if ((bool)r.Cells["Chon"].Value)
                        ERP_Library.BangTangCaNhanVienList.ChamTangCaNhanVien(_KyLuong.MaKy, txtNgay.DateTime, Convert.ToDecimal(txtSoGio.Value), (long)r.Cells["MaNhanVien"].Value);
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
    }
}