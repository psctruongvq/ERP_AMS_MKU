using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PSC_ERP
{
    public partial class frmChamNgoaiGioChuaDuyet : Form
    {
        public bool OK = false;
        public int MaKyTinhLuong, MaKyChamCong, MaBoPhan;

        public frmChamNgoaiGioChuaDuyet()
        {
            InitializeComponent();
            grdData.DoubleClickRow += new Infragistics.Win.UltraWinGrid.DoubleClickRowEventHandler(grdData_DoubleClickRow);
        }

        void grdData_DoubleClickRow(object sender, Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs e)
        {
            OK = true;
            MaKyTinhLuong = (int)e.Row.Cells["MaKyTinhLuong"].Value;
            MaKyChamCong = (int)e.Row.Cells["MaKyChamCong"].Value;
            MaBoPhan = (int)e.Row.Cells["MaBoPhan"].Value;
            this.Close();
        }

        private void frmChamNgoaiGioChuaDuyet_Load(object sender, EventArgs e)
        {
            bdData.DataSource = ERP_Library.ChamNgoaiGioChuaDuyetList.GetChamNgoaiGioChuaDuyetList();
        }
    }
}