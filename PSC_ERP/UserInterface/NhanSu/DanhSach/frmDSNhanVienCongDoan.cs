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
    public partial class frmDSNhanVienCongDoan : Form
    {
        DateTime tuNgay = DateTime.Today.Date;
        DateTime denNgay = DateTime.Today.Date;
        int Loai = 0;
        public frmDSNhanVienCongDoan()
        {
            InitializeComponent();
        }

        private void dateTuNgay_ValueChanged(object sender, EventArgs e)
        {
            tuNgay = Convert.ToDateTime(dateTuNgay.Value);
            ComboChanged();
         

        }

        private void dateDenNgay_ValueChanged(object sender, EventArgs e)
        {
            denNgay = Convert.ToDateTime(dateDenNgay.Value);
            ComboChanged();
        }

        private void frmDanhSachNhanVienNghiViec_Load(object sender, EventArgs e)
        {
            ComboChanged();
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

        private void rdChua_CheckedChanged(object sender, EventArgs e)
        {
            if (rdChua.Checked == true)
                Loai = 0;
            ComboChanged();
        }
        private void ComboChanged()
        {
            NhanVienCongDoanList list = NhanVienCongDoanList.GetNhanVienCongDoanList(tuNgay, denNgay, Loai);
            this.bindingSource1_DSnhanVienCongDoan.DataSource = list;
        }

        private void rdDaChuyen_CheckedChanged(object sender, EventArgs e)
        {
            if (rdDaChuyen.Checked == true)
                Loai = 1;
            ComboChanged();
        }

        private void rdTatCa_CheckedChanged(object sender, EventArgs e)
        {
            if (rdTatCa.Checked == true)
                Loai = -1;
            ComboChanged();
        }
    }
}