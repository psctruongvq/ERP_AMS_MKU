using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;


namespace PSC_ERP.UserInterface.NhanSu.ThanhToan
{
    public partial class frmChungTuNganHang_Edit : Form
    {
        private bool OK = false;
        private ERP_Library.ChungTuNganHang _data;
        private int OldMaTaiKhoan;
        private bool Loai;

        public frmChungTuNganHang_Edit()
        {
            InitializeComponent();
        }

        public frmChungTuNganHang_Edit(bool LoaiTruyen)
        {
            InitializeComponent();
            Loai = LoaiTruyen;
        
        }

        private void btnDongY_Click(object sender, EventArgs e)
        {
            bdData.EndEdit();
            //if (txtSo.Text == "")
            //{
            //    MessageBox.Show("Số chứng từ không được để trống", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return;
            //}
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
            CapNhatTong();
            OK = true;
            this.Close();
        }

        private void btnKhong_Click(object sender, EventArgs e)
        {
            OK = false;
            this.Close();
        }

        public bool ShowEdit(ERP_Library.ChungTuNganHang data)
        {
            _data = data;
            bdData.DataSource = _data;
            cmbTaiKhoan.DataSource = ERP_Library.ThanhToan.TaiKhoanNganHangCongTyList.GetTaiKhoanNganHangCongTyList();
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

            frmChungTuNganHang_DeNghiChuaDuyet f = new frmChungTuNganHang_DeNghiChuaDuyet(Loai);
            f._chungtu = _data;
            f.ShowDialog();
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            grdChungTu.DeleteSelectedRows();
        }

        private void grdChungTu_BeforeRowsDeleted(object sender, Infragistics.Win.UltraWinGrid.BeforeRowsDeletedEventArgs e)
        {
            e.DisplayPromptMsg = false;
            e.Cancel = MessageBox.Show("Bạn có muốn xóa chuyển khoản đề nghị này không?", "Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No;
        }

        private void CapNhatTong()
        {
            int sp = 0;
            decimal tong = 0;
            foreach (ERP_Library.ChungTuNganHang_DeNghi item in _data.DeNghi)
            {
                sp++;
                tong += item.SoTien;
            }
            _data.SoDeNghi = sp;
            _data.SoTien = tong;
        }

        private void frmChungTuNganHang_Edit_Load(object sender, EventArgs e)
        {
            foreach (ERP_Library.DatabaseNumberChild item in ERP_Library.DatabaseNumberList.GetDatabaseNumberList())
            {
                grdChungTu.DisplayLayout.ValueLists["DatabaseNumber"].ValueListItems.Add(item.DatabaseNumber, item.Ten);
            }
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
            if (grdChungTu.Rows.Count > 0 && !cmbTaiKhoan.Value.Equals(OldMaTaiKhoan))
            {
                MessageBox.Show("Không thể thay đổi sau khi đã chọn chứng từ gốc.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Cancel = true;
                return;
            }
            OldMaTaiKhoan = (int)cmbTaiKhoan.Value;
        }

        private void ultraButton_Export_Click(object sender, EventArgs e)
        {
            HamDungChung.ExportToExcel(grdChungTu);
        }
    }
}