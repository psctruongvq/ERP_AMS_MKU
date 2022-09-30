using ERP_Library;
using PSC_ERP_Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PSC_ERP.UserInterface.SoHoaDuLieu
{
    public partial class frmChonNhomVanBan : Form
    {
        NhomVanBanList _nhomVanBanList = NhomVanBanList.NewNhomVanBanList();
        Boolean _doiNhomVanBan = false;
        public frmChonNhomVanBan()
        {
            InitializeComponent();
            //bindingSource_NhomVanBan.DataSource = _nhomVanBanList;
        }

        private void frmChonNhomVanBan_Load(object sender, EventArgs e)
        {
            _nhomVanBanList = NhomVanBanList.GetNhomVanBanList();
            bindingSource_NhomVanBan.DataSource = _nhomVanBanList;
        }

        private void btn_DongY_Click(object sender, EventArgs e)
        {
            if (cmb_NhomVanBan.GetSelectedDataRow() == null)
            {
                DialogUtil.ShowWarning("Chưa chọn nhóm văn bản cần chuyển \nVui lòng chọn nhóm văn bản cần chuyển");
            }
            else
            {
                _doiNhomVanBan = true;
                this.Close();
            }
        }

        private void frmChonNhomVanBan_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (_doiNhomVanBan)
                this.DialogResult = DialogResult.OK;
            else
                this.DialogResult = DialogResult.No;
        }

        private void btn_HuyBo_Click(object sender, EventArgs e)
        {
            _doiNhomVanBan = false;
            this.Close();
        }
    }
}
