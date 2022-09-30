using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace PSC_ERP
{
    public partial class XtraFrm_Menu1 : DevExpress.XtraEditors.XtraForm
    {
        public XtraFrm_Menu1()
        {
            InitializeComponent();
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            XtraFrm_HangHoa frm = new XtraFrm_HangHoa();
            frm.Show();
            frm.WindowState = FormWindowState.Maximized;
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            XtraFrm_NhomHangHoa frm = new XtraFrm_NhomHangHoa();
            frm.Show();
            frm.WindowState = FormWindowState.Maximized;
        }

        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            
            //XtraFrm_LoaiVatTuHH frm=new XtraFrm_LoaiVatTuHH();
            XtraFrm_LoaiVatTuHH frm = new XtraFrm_LoaiVatTuHH();
            frm.Show();
            frm.WindowState = FormWindowState.Maximized;

        }

        private void barButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            XtraFrm_LoaiKho frm = new XtraFrm_LoaiKho();
            frm.Show();
            frm.WindowState = FormWindowState.Maximized;

        }

        private void barButtonItem5_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            XtraFrm_Kho frm = new XtraFrm_Kho();
            frm.Show();
            frm.WindowState = FormWindowState.Maximized;
        }
    }
}