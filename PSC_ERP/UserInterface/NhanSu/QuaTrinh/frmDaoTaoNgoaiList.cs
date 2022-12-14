
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PSC_ERP
{
    public partial class frmDaoTaoNgoaiList : Form
    {
        private ERP_Library.DaoTaoNgoaiList _Data;
        public frmDaoTaoNgoaiList()
        {
            InitializeComponent();
        }

        private void frmDaoTaoNgoaiList_Load(object sender, EventArgs e)
        {
            _Data = ERP_Library.DaoTaoNgoaiList.GetDaoTaoNgoaiList();
            daoTaoNgoaiListBindingSource.DataSource = _Data;
        }

        private void tlslblThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void toolNew_Click(object sender, EventArgs e)
        {
            frmDaoTaoNgoaiEdit f = new frmDaoTaoNgoaiEdit();
            if (f.NewDaoTao())
            {
                _Data = ERP_Library.DaoTaoNgoaiList.GetDaoTaoNgoaiList();
                daoTaoNgoaiListBindingSource.DataSource = _Data;
            }
        }

        private void grdData_DoubleClickRow(object sender, Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs e)
        {
            frmDaoTaoNgoaiEdit f = new frmDaoTaoNgoaiEdit();
            if (f.EditDaoTao((int)e.Row.Cells["MaDTNgoai"].Value))
            {
                _Data = ERP_Library.DaoTaoNgoaiList.GetDaoTaoNgoaiList();
                daoTaoNgoaiListBindingSource.DataSource = _Data;
            }
        }
    }
}