using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ERP_Library;
using ERP_Library.ThanhToan;


namespace PSC_ERP
{
    public partial class frmUyNhiemChi_CacQuy_Edit : Form
    {
        private bool OK = false;
        private ERP_Library.UyNhiemChi_CacQuy _data;
        private ERP_Library.DeNghi_UyNhiemChi_CacQuyList _ChiTietList;
        private int _iLoaiDeNghi = 0;
        int OldMaTaiKhoan = 0;

        public frmUyNhiemChi_CacQuy_Edit()
        {
            InitializeComponent();
        }

        public frmUyNhiemChi_CacQuy_Edit(int iLoaiDeNghi)
        {
            InitializeComponent();
            _iLoaiDeNghi = iLoaiDeNghi;
        }

        private void btnDongY_Click(object sender, EventArgs e)
        {
            bdData.EndEdit();
            if (txtDienGiai.Text == "")
            {
                MessageBox.Show("Diễn giải không được để trống", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (cmbTaiKhoan.Value == null || (int)cmbTaiKhoan.Value == 0)
            {
                MessageBox.Show("Ngân hàng không được để trống", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            TinhLai();
            OK = true;
            this.Close();
        }

        private void btnKhong_Click(object sender, EventArgs e)
        {
            OK = false;
            this.Close();
        }

        public bool ShowEdit(ERP_Library.UyNhiemChi_CacQuy data)
        {
            data.LoaiDeNghi = _iLoaiDeNghi;
            _data = data;
            bdData.DataSource = _data;
            cmbTaiKhoan.DataSource = TaiKhoanNganHangCongTyList.GetTaiKhoanNganHangCongTyList();
            cmb_LoaiTien.DataSource = LoaiTienList.GetLoaiTienList();
            _ChiTietList = _data.DeNghi_UNC_CacQuyList;
            bdChiTiet.DataSource = _ChiTietList;
            lblHoanTat.Visible = _data.HoanTat;
            btnDongY.Enabled = !_data.HoanTat;
            OldMaTaiKhoan = _data.MaNganHang;
            this.ShowDialog();
            return OK;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (cmbTaiKhoan.Value == null || (int)cmbTaiKhoan.Value == 0)
            {
                MessageBox.Show("Ngân hàng không được để trống", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            frmUyNhiemChi_CacQuy_ChuaDuyet f = new frmUyNhiemChi_CacQuy_ChuaDuyet(_iLoaiDeNghi);
            f._data = _data;
            _data.SoTien = 0;
            _data.DienGiai = string.Empty;

            if (f.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                _data.SoTaiKhoanChuyen = cmbTaiKhoan.Text;
                _data.TenNganHang = txtNganHang.Text;

                if (f._data.DeNghi_UNC_CacQuyList.Count != 0)
                {
                    _ChiTietList = _data.DeNghi_UNC_CacQuyList;
                    bdChiTiet.DataSource = _ChiTietList;
                }
            }
            TinhLai();
        }

        private void TinhLai()
        {
            _data.SoTien = 0;
            foreach (DeNghi_UyNhiemChi_CacQuy item in _data.DeNghi_UNC_CacQuyList)
            {
                _data.SoTien += item.SoTien * item.TyGia;
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            grd_ChiTiet.DeleteSelectedRows();
            grd_ChiTiet.UpdateData();
            TinhLai();
        }

        private void grdChungTu_BeforeRowsDeleted(object sender, Infragistics.Win.UltraWinGrid.BeforeRowsDeletedEventArgs e)
        {
            e.DisplayPromptMsg = false;
            e.Cancel = MessageBox.Show("Bạn có muốn xóa chuyển khoản đề nghị này không?", "Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No;
        }

        private void cmbTaiKhoan_ValueChanged(object sender, EventArgs e)
        {
            if (cmbTaiKhoan.SelectedRow != null)
            {
                txtNganHang.Text = ((ERP_Library.ThanhToan.TaiKhoanNganHangCongTyChild)cmbTaiKhoan.SelectedRow.ListObject).TenNganHang;
            }
            else
                txtNganHang.Text = "";
        }

        private void cmbTaiKhoan_Validating(object sender, CancelEventArgs e)
        {
            if (grd_ChiTiet.Rows.Count > 0 && !cmbTaiKhoan.Value.Equals(OldMaTaiKhoan))
            {
                MessageBox.Show("Không thể thay đổi sau khi đã chọn chứng từ gốc.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Cancel = true;
                return;
            }
            OldMaTaiKhoan = (int)cmbTaiKhoan.Value;
        }

        private void ultraButton_Export_Click(object sender, EventArgs e)
        {
            HamDungChung.ExportToExcel(grd_ChiTiet);
        }


        private void grd_ChiTiet_AfterCellUpdate(object sender, Infragistics.Win.UltraWinGrid.CellEventArgs e)
        {
            grd_ChiTiet.UpdateData();
            bdChiTiet.EndEdit();
            TinhLai();
        }

        private void ultraButton1_Click(object sender, EventArgs e)
        {
            HamDungChung.ExportToExcel(grd_ChiTiet);
        }
    }
}