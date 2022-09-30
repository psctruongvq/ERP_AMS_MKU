using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PSC_ERP.UserInterface.NhanSu.ThongTinNhanVien
{
    public partial class frmNguoiKyTen : Form
    {
        public frmNguoiKyTen()
        {
            InitializeComponent();
        }

        private void btnKhong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmNguoiKyTen_Load(object sender, EventArgs e)
        {
            bdData.DataSource = ERP_Library.NguoiKyTen.GetNguoiKyTen(ERP_Library.Security.CurrentUser.Info.UserID);
        }

        private void btnDongY_Click(object sender, EventArgs e)
        {
            bdData.EndEdit();
            (bdData.DataSource as ERP_Library.NguoiKyTen).ApplyEdit();
            (bdData.DataSource as ERP_Library.NguoiKyTen).Save();
            this.Close();
        }
    }
}
