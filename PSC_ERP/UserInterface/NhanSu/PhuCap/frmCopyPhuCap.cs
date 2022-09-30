using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PSC_ERP
{
    public partial class frmCopyPhuCap : Form
    {
        private bool OK = false;
        private ERP_Library.LoaiPhuCapChild _loai;
        public int NewID = 0;

        public frmCopyPhuCap()
        {
            InitializeComponent();
        }

        private void btnKhong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public bool ShowCopy(ERP_Library.LoaiPhuCapChild loai)
        {
            _loai = loai;
            lblPhuCap.Text = loai.TenLoaiPhuCap;
            this.ShowDialog();
            return OK;
        }

        private void btnDongY_Click(object sender, EventArgs e)
        {
            if (txtNew.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập tên phụ cấp mới", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            NewID = _loai.CopyPhuCap(txtNew.Text);
            OK = true;
            this.Close();
        }
    }
}
