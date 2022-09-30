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
    public partial class frmHoatDong : Form
    {
        HoatDongList _list;
        public frmHoatDong()
        {
            InitializeComponent();
        }

        private void frmLoaiChiPhiSanXuat_Load(object sender, EventArgs e)
        {
            _list = HoatDongList.GetHoatDongList();
            this.bdHoatDong.DataSource = _list;
        }

        private void tlslblLuu_Click(object sender, EventArgs e)
        {
            bdHoatDong.EndEdit();
            grdData.UpdateData();
            _list.ApplyEdit();
            _list.Save();
            MessageBox.Show("Cập nhật thành công","Thông Báo",MessageBoxButtons.OK,MessageBoxIcon.Information);

        }

        private void tlslblXoa_Click(object sender, EventArgs e)
        {
            grdData.DeleteSelectedRows();
        }

        private void tlslblUndo_Click(object sender, EventArgs e)
        {
            _list = HoatDongList.GetHoatDongList();
            this.bdHoatDong.DataSource = _list;
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
            grdData.DisplayLayout.Bands[0].Columns["MaQLHoatDong"].Hidden = false;
            grdData.DisplayLayout.Bands[0].Columns["MaQLHoatDong"].Header.Caption = "Mã Quản Lý";
            grdData.DisplayLayout.Bands[0].Columns["MaQLHoatDong"].Width = 100;
            grdData.DisplayLayout.Bands[0].Columns["MaQLHoatDong"].Header.VisiblePosition = 0;

            grdData.DisplayLayout.Bands[0].Columns["TenHoatDong"].Hidden = false;
            grdData.DisplayLayout.Bands[0].Columns["TenHoatDong"].Header.Caption = "Tên Loại Hoạt Động";
            grdData.DisplayLayout.Bands[0].Columns["TenHoatDong"].Width = 200;
            grdData.DisplayLayout.Bands[0].Columns["TenHoatDong"].Header.VisiblePosition = 1;

           
        }
    }
}
