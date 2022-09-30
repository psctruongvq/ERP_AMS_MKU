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
    public partial class frmDSNhanVienNghiViec : Form
    {
        DateTime tuNgay = DateTime.Today.Date;
        DateTime denNgay = DateTime.Today.Date;
        public frmDSNhanVienNghiViec()
        {
            InitializeComponent();
        }

        private void dateTuNgay_ValueChanged(object sender, EventArgs e)
        {
            tuNgay = Convert.ToDateTime(dateTuNgay.Value);
            NhanVienNghiViecList list = NhanVienNghiViecList.GetNhanVienNghiViecList(tuNgay, denNgay);
            this.bindingSource1_DSnhanVienNghiViec.DataSource = list;

        }

        private void dateDenNgay_ValueChanged(object sender, EventArgs e)
        {
            denNgay = Convert.ToDateTime(dateDenNgay.Value);
            NhanVienNghiViecList list = NhanVienNghiViecList.GetNhanVienNghiViecList(tuNgay, denNgay);
            this.bindingSource1_DSnhanVienNghiViec.DataSource = list;
        }

        private void frmDanhSachNhanVienNghiViec_Load(object sender, EventArgs e)
        {
            NhanVienNghiViecList list = NhanVienNghiViecList.GetNhanVienNghiViecList(tuNgay, denNgay);
            this.bindingSource1_DSnhanVienNghiViec.DataSource = list;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            HamDungChung.ExportToExcel(gridData);
        }

        private void gridData_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            HamDungChung h = new HamDungChung();
            h.ultragrdEmail_InitializeLayout(sender, e);
            e.Layout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No;
        }
    }
}