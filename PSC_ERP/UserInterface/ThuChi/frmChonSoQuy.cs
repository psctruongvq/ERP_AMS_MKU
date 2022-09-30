using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ERP_Library;
using Infragistics.Win.UltraWinGrid;
namespace PSC_ERP
{
    public partial class frmChonSoQuy : Form
    {
        SoQuyList _list;
        public static int MaSoQuy = 0;
     
        public static bool IsCheck = false;
        public frmChonSoQuy()
        {
            InitializeComponent();
        }

        private void frmChonChiPhi_Load(object sender, EventArgs e)
        {
            _list = SoQuyList.GetSoQuyList();
            bdSoQuy.DataSource = _list;

        }

        private void cbChiPhi_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            HamDungChung h = new HamDungChung();
            h.ultragrdEmail_InitializeLayout(sender, e);
            foreach (UltraGridColumn col in this.cbSoQuy.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;
                col.Hidden = true;
            }
         
            cbSoQuy.DisplayLayout.Bands[0].Columns["TenSoQuy"].Hidden = false;
            cbSoQuy.DisplayLayout.Bands[0].Columns["TenSoQuy"].Header.Caption = "Tên Sổ Quỹ";
            cbSoQuy.DisplayLayout.Bands[0].Columns["TenSoQuy"].Width = 300;
            cbSoQuy.DisplayLayout.Bands[0].Columns["TenSoQuy"].Header.VisiblePosition = 0;
        }

        private void cbChiPhi_ValueChanged(object sender, EventArgs e)
        {
            if (cbSoQuy.ActiveRow != null)
            {
                MaSoQuy = (int)cbSoQuy.Value;
            }
        }

        

        private void ultraButton1_Click(object sender, EventArgs e)
        {
            if (cbSoQuy.ActiveRow != null)
            {
                MaSoQuy = (int)cbSoQuy.Value;
            }
         
            IsCheck = true;
            this.Close();
        }

        private void ultraButton2_Click(object sender, EventArgs e)
        {
            IsCheck = false;
            this.Close();
        }
    }
}
