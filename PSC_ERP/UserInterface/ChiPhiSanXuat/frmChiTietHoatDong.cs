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
    public partial class frmChiTietHoatDong : Form
    {
        ChiTietHoatDongList _list;
        HoatDongList _hoatDongList;
        public frmChiTietHoatDong()
        {
            InitializeComponent();
            bdChiTietHoatDong.DataSource = typeof(ChiTietHoatDongList);
            bdHoatDong.DataSource = typeof(HoatDongList);
        }

        private void frmLoaiChiPhiSanXuat_Load(object sender, EventArgs e)
        {
            _list = ChiTietHoatDongList.GetChiTietHoatDongList();
            this.bdChiTietHoatDong.DataSource = _list;
            _hoatDongList = HoatDongList.GetHoatDongList();
            this.bdHoatDong.DataSource = _hoatDongList;
        }

        private void tlslblLuu_Click(object sender, EventArgs e)
        {
            bdChiTietHoatDong.EndEdit();
            grdData.UpdateData();
            _list.ApplyEdit();
            _list.Save();
            MessageBox.Show("Cập nhật thành công","Thông Báo",MessageBoxButtons.OK,MessageBoxIcon.Information);
            _list = ChiTietHoatDongList.GetChiTietHoatDongList();
            this.bdChiTietHoatDong.DataSource = _list;
        }

        private void tlslblXoa_Click(object sender, EventArgs e)
        {
            grdData.DeleteSelectedRows();
        }

        private void tlslblUndo_Click(object sender, EventArgs e)
        {
            _list = ChiTietHoatDongList.NewChiTietHoatDongList();
            this.bdChiTietHoatDong.DataSource = _list;
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
            grdData.DisplayLayout.Bands[0].Columns["MaChiTietHoatDongQL"].Hidden = false;
            grdData.DisplayLayout.Bands[0].Columns["MaChiTietHoatDongQL"].Header.Caption = "Mã Quản Lý";
            grdData.DisplayLayout.Bands[0].Columns["MaChiTietHoatDongQL"].Width = 100;
            grdData.DisplayLayout.Bands[0].Columns["MaChiTietHoatDongQL"].Header.VisiblePosition = 0;

            grdData.DisplayLayout.Bands[0].Columns["TenChiTietHoatDong"].Hidden = false;
            grdData.DisplayLayout.Bands[0].Columns["TenChiTietHoatDong"].Header.Caption = "Chi Tiết Chi Phí";
            grdData.DisplayLayout.Bands[0].Columns["TenChiTietHoatDong"].Width = 200;
            grdData.DisplayLayout.Bands[0].Columns["TenChiTietHoatDong"].Header.VisiblePosition = 1;

            grdData.DisplayLayout.Bands[0].Columns["MaHoatDong"].Hidden = false;
            grdData.DisplayLayout.Bands[0].Columns["MaHoatDong"].Header.Caption = "Hoạt Động";
            grdData.DisplayLayout.Bands[0].Columns["MaHoatDong"].EditorComponent = cbHoatDong;
            grdData.DisplayLayout.Bands[0].Columns["MaHoatDong"].Header.VisiblePosition = 2;
            grdData.DisplayLayout.Bands[0].Columns["MaHoatDong"].Width = 200;

           
        }

        private void cbHoatDong_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
         HamDungChung h = new HamDungChung();
            h.ultragrdEmail_InitializeLayout(sender, e);
            foreach (UltraGridColumn col in this.cbHoatDong.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;
                col.Hidden = true;
            }
            cbHoatDong.DisplayLayout.Bands[0].Columns["MaQLHoatDong"].Hidden = false;
            cbHoatDong.DisplayLayout.Bands[0].Columns["MaQLHoatDong"].Header.Caption = "Mã Quản Lý";
            cbHoatDong.DisplayLayout.Bands[0].Columns["MaQLHoatDong"].Width = 100;
            cbHoatDong.DisplayLayout.Bands[0].Columns["MaQLHoatDong"].Header.VisiblePosition = 0;

            cbHoatDong.DisplayLayout.Bands[0].Columns["TenHoatDong"].Hidden = false;
            cbHoatDong.DisplayLayout.Bands[0].Columns["TenHoatDong"].Header.Caption = "Tên Loại Chi Phí";
            cbHoatDong.DisplayLayout.Bands[0].Columns["TenHoatDong"].Width = 200;
            cbHoatDong.DisplayLayout.Bands[0].Columns["TenHoatDong"].Header.VisiblePosition = 1;

        }
    }
}
