using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PSC_ERP.Security
{
    public partial class frmUserThuLao : Form
    {
        ERP_Library.Security.UserThuLaoList _data;
        public frmUserThuLao()
        {
            InitializeComponent();
        }

        public void EditData(ERP_Library.Security.UserThuLaoList data)
        {
            _data = data;
            bdNguoiLap.DataSource = data;
            //kiểm tra check all
            bool all = true;
            foreach (ERP_Library.Security.UserThuLaoChild item in data)
            {
                if (!item.Chon)
                {
                    all = false;
                    break;
                }
            }
            chkALL.Checked = all;
            this.ShowDialog();
            grdNguoiLap.UpdateData();
        }

        private void chkALL_CheckedChanged(object sender, EventArgs e)
        {
            bool all = chkALL.Checked;
            foreach (ERP_Library.Security.UserThuLaoChild item in _data)
            {
                item.Chon = all;
            }
        }
    }
}
