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
    public partial class frmSapXepBoPhan : Form
    {

        BoPhanList _boPhanListCha;
        LoaiBoPhanList _loaiBoPhanList;
        int maBoPhanCha = 0;
        int maLoaiBoPhan = 0;
        public frmSapXepBoPhan()
        {
            
            InitializeComponent();
        }

        private void frmDinhViBoPhan_Load(object sender, EventArgs e)
        {
            _boPhanListCha = BoPhanList.GetBoPhanListBy_All();
            BoPhan itemAdd = BoPhan.NewBoPhan("Không Có");
            _boPhanListCha.Insert(0, itemAdd);
            _loaiBoPhanList = LoaiBoPhanList.GetLoaiBoPhanList();   
         
            bindingSource1_BoPhanCha.DataSource = _boPhanListCha;
            bindingSource1_LoaiBoPhan.DataSource = _loaiBoPhanList;
        }

        private void ultraButton1_Click(object sender, EventArgs e)
        {
           
            if (maLoaiBoPhan == 0)
            {
                MessageBox.Show("Chưa Chọn Loại Bộ Phận ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }           
            if (frmBoPhan.maBoPhan != maBoPhanCha)
            {
                BoPhan.DinhViBoPhan(frmBoPhan.maBoPhan, maBoPhanCha, maLoaiBoPhan);
                MessageBox.Show("Sắp xếp lại bộ phận thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            this.Close();
        }

        private void ultraButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbBoPhanCha_ValueChanged(object sender, EventArgs e)
        {
            if (cbBoPhanCha.Value != null)
            {
                maBoPhanCha = Convert.ToInt32(cbBoPhanCha.Value);  
            }
        }

        private void cbLoaiBP_ValueChanged(object sender, EventArgs e)
        {
            if (cbLoaiBP.Value != null)
            {
                maLoaiBoPhan = Convert.ToInt32(cbLoaiBP.Value);
            }
           
        }
    }
}