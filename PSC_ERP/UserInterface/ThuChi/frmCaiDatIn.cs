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
    public partial class frmCaiDatIn : Form
    {
        CaiDatKyTen _CaiDat = CaiDatKyTen.NewCaiDatKyTen();
        public frmCaiDatIn()
        {
            InitializeComponent();
            
        }

        private void frmCaiDatIn_Load(object sender, EventArgs e)
        {
            _CaiDat = CaiDatKyTen.GetCaiDatKyTen(1);
          
            CaiDatBindingSource.DataSource = _CaiDat;
            _CaiDat.BeginEdit();

        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            _CaiDat.ApplyEdit();
            CaiDatBindingSource.EndEdit();
            try
            {
                if (_CaiDat.MaKyTenCN == 0)
                {
                   
                    _CaiDat.Insert();
                }
                else
                {
                    _CaiDat.DataPortal_UpDate();
                }
                MessageBox.Show(this, "Cập Nhật Thành Công ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Lỗi khi đang Save", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }
           
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}