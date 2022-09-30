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
    public partial class frmMoSo : Form
    {
        KyList _KyList;
        public static int MaKy;

        public frmMoSo()
        {
            InitializeComponent();
             _KyList = KyList.GetKyListByKhoaSo();
            KyBindingSource.DataSource = _KyList;
        }        
        
        private void ubtThucHien_Click(object sender, EventArgs e)
        {
            Ky.MoSoKeToan(Convert.ToInt32(ultraCombo_Ky.Value));
            frmThoiGianMoSo frmThoiGian = new frmThoiGianMoSo();
            frmThoiGian.Show(this);
        }

        private void KyBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            MaKy = ((Ky)KyBindingSource.Current).MaKy;
        }

        private void ubtThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}