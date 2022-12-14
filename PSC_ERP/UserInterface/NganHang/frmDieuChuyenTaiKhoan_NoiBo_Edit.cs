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
    public partial class frmDieuChuyenTaiKhoan_NoiBo_Edit : Form
    {
        #region Properties
        private bool OK = false;
        private ERP_Library.ChungTuNganHang _data;
        private int OldMaTaiKhoan;
        private bool _isNew = false;
        #endregion

        #region Loads
        public frmDieuChuyenTaiKhoan_NoiBo_Edit()
        {
            InitializeComponent();
        }

        public frmDieuChuyenTaiKhoan_NoiBo_Edit(bool IsNew)
        {
            InitializeComponent();
            _isNew = IsNew;
        }
        #endregion

        #region Process
        public bool ShowEdit(ERP_Library.ChungTuNganHang data)
        {
            //Loại chứng từ = 301 : Chứng từ điều chuyển nội bộ
            data.LoaiChungTu = 301;
            _data = data;
            bdData.DataSource = _data;
            cmbTaiKhoanChuyen.DataSource = ERP_Library.ThanhToan.TaiKhoanNganHangCongTyList.GetTaiKhoanNganHangCongTyList();
            cmbTaiKhoanNhan.DataSource = ERP_Library.ThanhToan.TaiKhoanNganHangCongTyList.GetTaiKhoanNganHangCongTyList();

            if (ChungTuNganHang.KiemTraChungTu(_data.MaChungTu))
            {
                btnDongY.Enabled = _isNew;
                lblHoanTat.Visible = !_isNew;
            }

            this.ShowDialog();
            return OK;
        }
        #endregion

        #region Events
        private void btnDongY_Click(object sender, EventArgs e)
        {
            bdData.EndEdit();
            if (txtDienGiai.Text == "")
            {
                MessageBox.Show("Diễn giải không được để trống", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (cmbTaiKhoanChuyen.Value == null || (int)cmbTaiKhoanChuyen.Value == 0)
            {
                MessageBox.Show("Ngân hàng chuyển không được để trống", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (cmbTaiKhoanNhan.Value == null || (int)cmbTaiKhoanNhan.Value == 0)
            {
                MessageBox.Show("Ngân hàng nhận không được để trống", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            OK = true;
            this.Close();
        }

        private void btnKhong_Click(object sender, EventArgs e)
        {
            OK = false;
            this.Close();
        }
        
        private void cmbTaiKhoanChuyen_ValueChanged(object sender, EventArgs e)
        {
            if (cmbTaiKhoanChuyen.ActiveRow != null)
            {
                txtNganHangChuyen.Text = ((ERP_Library.ThanhToan.TaiKhoanNganHangCongTyChild)cmbTaiKhoanChuyen.SelectedRow.ListObject).TenNganHang;
            }
            else
                txtNganHangChuyen.Text = "";
        }

        private void cmbTaiKhoanNhan_ValueChanged(object sender, EventArgs e)
        {
            if (cmbTaiKhoanNhan.ActiveRow != null)
            {
                _data.TaiKhoanNhan = (int)cmbTaiKhoanNhan.Value;
                txtNganHangNhan.Text = ((ERP_Library.ThanhToan.TaiKhoanNganHangCongTyChild)cmbTaiKhoanNhan.SelectedRow.ListObject).TenNganHang;
            }
            else
                txtNganHangNhan.Text = "";
        }
        #endregion
    }
}