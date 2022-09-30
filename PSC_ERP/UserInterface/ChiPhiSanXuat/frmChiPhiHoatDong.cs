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
    public partial class frmChiPhiHoatDong : Form
    {
        ChiPhiHoatDongList _list;
        public frmChiPhiHoatDong()
        {
            InitializeComponent();
        }

        private void frmLoaiChiPhiSanXuat_Load(object sender, EventArgs e)
        {
            _list = ChiPhiHoatDongList.GetChiPhiHoatDongList();
            this.bdLoaiKinhPhi.DataSource = _list;
        }

        private void tlslblLuu_Click(object sender, EventArgs e)
        {
            bdLoaiKinhPhi.EndEdit();
            grdData.UpdateData();
            _list.ApplyEdit();
            _list.Save();
            MessageBox.Show("Cập nhật thành công","Thông Báo",MessageBoxButtons.OK,MessageBoxIcon.Information);
            _list = ChiPhiHoatDongList.GetChiPhiHoatDongList();
            this.bdLoaiKinhPhi.DataSource = _list;

        }

        private void tlslblXoa_Click(object sender, EventArgs e)
        {
            grdData.DeleteSelectedRows();
        }

        private void tlslblUndo_Click(object sender, EventArgs e)
        {
            _list = ChiPhiHoatDongList.GetChiPhiHoatDongList();
            this.bdLoaiKinhPhi.DataSource = _list;
        }

        private void tlslblThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void grdData_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            HamDungChung h = new HamDungChung();
            h.ultragrdEmail_InitializeLayout(sender, e);
            foreach (UltraGridColumn col in this.grdData.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;
                col.Hidden = true;
            }
            grdData.DisplayLayout.Bands[0].Columns["MaChiPhiHDQL"].Hidden = false;
            grdData.DisplayLayout.Bands[0].Columns["MaChiPhiHDQL"].Header.Caption = "Mã Quản Lý";
            grdData.DisplayLayout.Bands[0].Columns["MaChiPhiHDQL"].Width = 100;
            grdData.DisplayLayout.Bands[0].Columns["MaChiPhiHDQL"].Header.VisiblePosition = 0;

            grdData.DisplayLayout.Bands[0].Columns["TenChiPhiHD"].Hidden = false;
            grdData.DisplayLayout.Bands[0].Columns["TenChiPhiHD"].Header.Caption = "Tên Chi Phí";
            grdData.DisplayLayout.Bands[0].Columns["TenChiPhiHD"].Width = 200;
            grdData.DisplayLayout.Bands[0].Columns["TenChiPhiHD"].Header.VisiblePosition = 1;

            grdData.DisplayLayout.Bands[0].Columns["SuDung"].Hidden = false;
            grdData.DisplayLayout.Bands[0].Columns["SuDung"].Header.Caption = "Sử Dụng";
            grdData.DisplayLayout.Bands[0].Columns["SuDung"].Width = 100;
            grdData.DisplayLayout.Bands[0].Columns["SuDung"].Header.VisiblePosition = 2;
        }
    }
}
