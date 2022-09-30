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
    public partial class frmSoDuDauNam : Form
    {
        public frmSoDuDauNam()
        {
            InitializeComponent();
            KhoiTao();
        }

        #region Khởi Tạo
        TaiKhoanList _ListTaiKhoan;
        SoDuDauKyList _SoDuDauKyList;       
        private void KhoiTao()
        {
            _ListTaiKhoan = TaiKhoanList.GetTaiKhoanList();
            TaiKhoanBindingSource.DataSource = _ListTaiKhoan;
            _SoDuDauKyList = SoDuDauKyList.GetSoDuDauKyList();
            SoDuDauKyListBindingSource.DataSource = _SoDuDauKyList;
        }

        #endregion

        #region Sự Kiện
        private void ubtLuu_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Ban Có Muốn Save Dữ Liệu Không", "Thông Báo", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                _ListTaiKhoan.ApplyEdit();
                _ListTaiKhoan.Save();
                _SoDuDauKyList.Save();

                KhoiTao();
                MessageBox.Show(this, "Cập Nhật Thành Công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void ubtKhongLuu_Click(object sender, EventArgs e)
        {
            KhoiTao();
        }

        private void ubtThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ubtIn_Click(object sender, EventArgs e)
        {

        }
        #endregion

    }
}