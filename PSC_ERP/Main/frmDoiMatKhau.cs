using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;


namespace PSC_ERP.Main
{
    public partial class frmDoiMatKhau : Form
    {
        private ERP_Library.Security.UserItem _data;
        public frmDoiMatKhau()
        {
            InitializeComponent();
        }

        private void ultraButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmDoiMatKhau_Load(object sender, EventArgs e)
        {
            _data = ERP_Library.Security.UserItem.GetUserItem(ERP_Library.Security.CurrentUser.Info.UserID);
        }

        private void txtMKCu_TextChanged(object sender, EventArgs e)
        {
            if (txtMKCu.Text == _data.MatKhau)
            {
                txtMKMoi.Enabled = true;
                txtKiemTra.Enabled = true;
                txtMKMoi.Focus();
                txtMKCu.Enabled = false;
            }
        }

        private void HopLe(object sender, EventArgs e)
        {
            btnDongY.Enabled = txtMKMoi.Text == txtKiemTra.Text;
        }

        private void btnDongY_Click(object sender, EventArgs e)
        {
            _data.MatKhau = txtMKMoi.Text;
            _data.Save();
            this.Close();
        }
    }
}