using System;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using PSC_ERPNew.Main;

namespace PSC_ERP.Main
{
    public partial class frmDangNhap : XtraForm
    {
        public frmDangNhap()
        {
            InitializeComponent();
        }

        private void btnLogIn_Click(object sender, EventArgs e)
        {
            if (txtUser.Text == "")
            {
                MessageBox.Show("Chưa nhập tên đăng nhập", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtPass.Text == "")
            {
                MessageBox.Show("Chưa nhập mật khẩu", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (ERP_Library.Security.CurrentUser.LogIn(txtUser.Text, txtPass.Text))
            {
                //cấu hình thông tin đăng nhập cho hệ thống mới
                BasicInfo.CopyDuLieuDangNhapTuHeThongCuSangHeThongMoi();
                this.DialogResult = DialogResult.OK;
            }
            else
                MessageBox.Show("Đăng nhập không hợp lệ", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
    }
}