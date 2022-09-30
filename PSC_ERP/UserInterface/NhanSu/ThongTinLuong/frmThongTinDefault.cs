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
    public partial class frmThongTinDefault : Form
    {
        Default_NgayList _Default_NgayList;
        Util _Util = new Util();

        public frmThongTinDefault()
        {
            InitializeComponent();
            LayDuLieu();
        }

        private void LayDuLieu()
        {
            _Default_NgayList = Default_NgayList.GetDefault_NgayList();
            ThongTinChung_BindingSource.DataSource = _Default_NgayList[0];
        }

        private void btn_CapNhat_Click(object sender, EventArgs e)
        {
            try
            {
                ThongTinChung_BindingSource.EndEdit();
                if (_Default_NgayList != null)
                {
                    _Default_NgayList.ApplyEdit();
                    _Default_NgayList.Save();
                    MessageBox.Show(this, _Util.thanhcong, _Util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LayDuLieu();
                }
                else
                {
                    MessageBox.Show(this, _Util.khongcodulieu, _Util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}