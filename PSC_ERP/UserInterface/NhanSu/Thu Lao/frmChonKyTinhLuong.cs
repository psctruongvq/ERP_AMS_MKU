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
    public partial class frmChonKyTinhLuong : Form
    {
       public static int maKyTinhLuongTuKy = 0;
        public static int maKyTinhLuongDenKy = 0;
      
        public frmChonKyTinhLuong()
        {
            InitializeComponent();
        }

        private void frmChonKyTinhLuong_Load(object sender, EventArgs e)
        {
            KyTinhLuongList _kyTinhLuongList = KyTinhLuongList.GetKyTinhLuongList();
            this.bindingSource1_KyTinhLuong.DataSource = _kyTinhLuongList;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (cbKyTinhLuong.Value != null &&cbDenKy.Value!=null)
            {
                maKyTinhLuongTuKy = Convert.ToInt32(cbKyTinhLuong.Value);
                maKyTinhLuongDenKy = Convert.ToInt32(cbDenKy.Value);               
                this.Close();
            }
        }

        private void cbKyTinhLuong_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            foreach (UltraGridColumn col in this.cbKyTinhLuong.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;//x =  //= System.Drawing.w;//Navy
                col.Hidden = true;
            }
            cbKyTinhLuong.DisplayLayout.Bands[0].Columns["TenKy"].Hidden = false;
            cbKyTinhLuong.DisplayLayout.Bands[0].Columns["TenKy"].Header.Caption = "Tên Kỳ";
        }

        private void cbDenKy_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            foreach (UltraGridColumn col in this.cbDenKy.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;//x =  //= System.Drawing.w;//Navy
                col.Hidden = true;
            }
            cbDenKy.DisplayLayout.Bands[0].Columns["TenKy"].Hidden = false;
            cbDenKy.DisplayLayout.Bands[0].Columns["TenKy"].Header.Caption = "Tên Kỳ";
        }
    }
}