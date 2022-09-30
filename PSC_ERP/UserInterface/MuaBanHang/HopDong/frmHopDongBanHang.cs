using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PSC_ERP.UserInterface.HopDong
{
    public partial class frmHopDongBanHang : Form
    {
        public frmHopDongBanHang()
        {
            InitializeComponent();
        }

        private void frmHopDongBanHang_Load(object sender, EventArgs e)
        {

        }

        private void ultradteTuNgay_ValueChanged(object sender, EventArgs e)
        {

        }

        private void tlslblIn_Click(object sender, EventArgs e)
        {

        }

        private void frmHopDongBanHang_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                Main.frmMain.LoadHelp(this, "Hop Dong", "Help_BanHang.chm");
            }
        }

        private void tlslblTroGiup_Click(object sender, EventArgs e)
        {
            Main.frmMain.LoadHelp(this, "Hop Dong", "Help_BanHang.chm");
        }
    }
}