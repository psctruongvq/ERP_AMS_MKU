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
    public partial class frmChonChiPhi : Form
    {
        ChiPhiHoatDongList _list;
        public static int MaChiPhi = 0;
        public static bool LoaiThu = false;
        public static bool IsCheck = false;
        public frmChonChiPhi()
        {
            InitializeComponent();
        }

        private void frmChonChiPhi_Load(object sender, EventArgs e)
        {
            _list = ChiPhiHoatDongList.GetChiPhiHoatDongList();
            bdChiPhiHoatDong.DataSource = _list;

        }

        private void cbChiPhi_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            HamDungChung h = new HamDungChung();
            h.ultragrdEmail_InitializeLayout(sender, e);
            foreach (UltraGridColumn col in this.cbChiPhi.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;
                col.Hidden = true;
            }
            cbChiPhi.DisplayLayout.Bands[0].Columns["MaChiPhiHDQL"].Hidden = false;
            cbChiPhi.DisplayLayout.Bands[0].Columns["MaChiPhiHDQL"].Header.Caption = "Mã Quản Lý";
            cbChiPhi.DisplayLayout.Bands[0].Columns["MaChiPhiHDQL"].Width = 100;
            cbChiPhi.DisplayLayout.Bands[0].Columns["MaChiPhiHDQL"].Header.VisiblePosition = 0;

            cbChiPhi.DisplayLayout.Bands[0].Columns["TenChiPhiHD"].Hidden = false;
            cbChiPhi.DisplayLayout.Bands[0].Columns["TenChiPhiHD"].Header.Caption = "Tên Chi Phí";
            cbChiPhi.DisplayLayout.Bands[0].Columns["TenChiPhiHD"].Width = 200;
            cbChiPhi.DisplayLayout.Bands[0].Columns["TenChiPhiHD"].Header.VisiblePosition = 1;
        }

        private void cbChiPhi_ValueChanged(object sender, EventArgs e)
        {
            if (cbChiPhi.ActiveRow != null)
            {
                MaChiPhi = (int)cbChiPhi.Value;
            }
        }

        private void cbLoaiThu_CheckedChanged(object sender, EventArgs e)
        {
            LoaiThu = (bool)cbLoaiThu.Checked;
        }

        private void ultraButton1_Click(object sender, EventArgs e)
        {
            if (cbChiPhi.ActiveRow != null)
            {
                MaChiPhi = (int)cbChiPhi.Value;
            }
            LoaiThu = (bool)cbLoaiThu.Checked;
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
