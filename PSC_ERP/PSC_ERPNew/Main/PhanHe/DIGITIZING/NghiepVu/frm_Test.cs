using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PSC_ERPNew.Main.PhanHe.DIGITIZING;

namespace PSC_ERP.TSCD.Main.PhanHe.DIGITIZING.NghiepVu
{
    public partial class frm_Test : Form
    {
        public frm_Test()
        {
            InitializeComponent();
        }

        private void simpleButton_ChungTu_Click(object sender, EventArgs e)
        {
            frmDigitizing.ShowFile_BangKe(90231, false, this);
        }

        private void simpleButton_PhieuNhap_Click(object sender, EventArgs e)
        {
            frmDigitizing.ShowFile_PhieuNhapXuat(26, true, this);
        }

        private void simpleButton_PhieuXuat_Click(object sender, EventArgs e)
        {
            frmDigitizing.ShowFile_PhieuNhapXuat(26, false, this);
        }

        private void simpleButton_HopDongNoiBo_Click(object sender, EventArgs e)
        {
            frmDigitizing.ShowFile_HopDong(613, true, this);
        }  


       
    }
}
