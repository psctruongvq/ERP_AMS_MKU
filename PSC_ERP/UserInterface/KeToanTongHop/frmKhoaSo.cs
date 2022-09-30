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
    public partial class frmKhoaSo : Form
    {
        KyList _KyList;
        public static int MaKy;
        public frmKhoaSo()
        {
            InitializeComponent();
            _KyList = KyList.GetKyList();
            KyBindingSource.DataSource = _KyList;   
        }


        private void ubtThucHien_Click(object sender, EventArgs e)
        {
            foreach (Ky ky in _KyList)
            {
                if (Convert.ToInt32(ultraCombo_Ky.Text) == ky.MaKy)
                {
                    if (ky.KhoaSo == true)
                    {
                        MessageBox.Show(this, "Kỳ Này Đã Khóa Sổ Rồi!!!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }          
                }
            }
            MaKy = Convert.ToInt32(ultraCombo_Ky.Text);
            frmThoiGianKhoaSo frmThoiGianKhoaSo = new frmThoiGianKhoaSo();
            frmThoiGianKhoaSo.Show(this);
            Ky.KhoaSoKeToan(Convert.ToInt32(ultraCombo_Ky.Value));
           // MessageBox.Show(this, "Khóa Số Kế Toán Thành Công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        
        private void KyBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            MaKy = ((Ky)KyBindingSource.Current).MaKy; //Convert.ToInt32(ultraCombo_Ky.Value);
        }

        private void ubtThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       
    }
}