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
    public partial class frmHoatDong_ChiPhiHoatDong : Form
    {
        ChiTietHoatDongList _chiTietHoatDongList;
        ChiPhiHoatDongList _chiPhiHoatDongList;
        HoatDong_ChiPhiHoatDongList _list;
        public frmHoatDong_ChiPhiHoatDong()
        {
            InitializeComponent();
            bdChiTietHoatDong.DataSource = typeof(ChiTietHoatDongList);
            bdChiPhiHoatDong.DataSource = typeof(ChiPhiHoatDongList);
        }

        private void frmLoaiChiPhiSanXuat_Load(object sender, EventArgs e)
        {
            _chiTietHoatDongList = ChiTietHoatDongList.GetChiTietHoatDongList();
            this.bdChiTietHoatDong.DataSource = _chiTietHoatDongList;
            
            _chiPhiHoatDongList = ChiPhiHoatDongList.GetChiPhiHoatDongList();
            this.bdChiPhiHoatDong.DataSource = _chiPhiHoatDongList;
       
            _list = HoatDong_ChiPhiHoatDongList.GetHoatDong_ChiPhiHoatDongList();
            bdHoatDong_ChiPhi.DataSource = _list;
        }

        private void tlslblLuu_Click(object sender, EventArgs e)
        {
            bdHoatDong_ChiPhi.EndEdit();
            grdData.UpdateData();
            _list.ApplyEdit();
            _list.Save();
            MessageBox.Show("Cập nhật thành công","Thông Báo",MessageBoxButtons.OK,MessageBoxIcon.Information);
            _list = HoatDong_ChiPhiHoatDongList.GetHoatDong_ChiPhiHoatDongList();
            bdHoatDong_ChiPhi.DataSource = _list;
        }

        private void tlslblXoa_Click(object sender, EventArgs e)
        {
            grdData.DeleteSelectedRows();
        }

        private void tlslblUndo_Click(object sender, EventArgs e)
        {
            _chiTietHoatDongList = ChiTietHoatDongList.NewChiTietHoatDongList();
            this.bdChiTietHoatDong.DataSource = _chiTietHoatDongList;
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

            grdData.DisplayLayout.Bands[0].Columns["MaChiHoatDong"].Hidden = false;
            grdData.DisplayLayout.Bands[0].Columns["MaChiHoatDong"].Header.Caption = "Chi Phí Hoạt Động";
            grdData.DisplayLayout.Bands[0].Columns["MaChiHoatDong"].Width = 200;
            grdData.DisplayLayout.Bands[0].Columns["MaChiHoatDong"].Header.VisiblePosition = 0;
            grdData.DisplayLayout.Bands[0].Columns["MaChiHoatDong"].EditorComponent = cbChiPhiHoatDong;

            grdData.DisplayLayout.Bands[0].Columns["MaChiTietHoatDong"].Hidden = false;
            grdData.DisplayLayout.Bands[0].Columns["MaChiTietHoatDong"].Header.Caption = "Chi Tiết Hoạt Động";
            grdData.DisplayLayout.Bands[0].Columns["MaChiTietHoatDong"].Width = 200;
            grdData.DisplayLayout.Bands[0].Columns["MaChiTietHoatDong"].EditorComponent = cbChiTietHoatDong;
            grdData.DisplayLayout.Bands[0].Columns["MaChiTietHoatDong"].Header.VisiblePosition = 2;

           
        }

        private void cbHoatDong_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
         HamDungChung h = new HamDungChung();
            h.ultragrdEmail_InitializeLayout(sender, e);
            foreach (UltraGridColumn col in this.cbChiPhiHoatDong.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;
                col.Hidden = true;
            }
            cbChiPhiHoatDong.DisplayLayout.Bands[0].Columns["MaChiPhiHDQL"].Hidden = false;
            cbChiPhiHoatDong.DisplayLayout.Bands[0].Columns["MaChiPhiHDQL"].Header.Caption = "Mã Quản Lý";
            cbChiPhiHoatDong.DisplayLayout.Bands[0].Columns["MaChiPhiHDQL"].Width = 100;
            cbChiPhiHoatDong.DisplayLayout.Bands[0].Columns["MaChiPhiHDQL"].Header.VisiblePosition = 0;

            cbChiPhiHoatDong.DisplayLayout.Bands[0].Columns["TenChiPhiHD"].Hidden = false;
            cbChiPhiHoatDong.DisplayLayout.Bands[0].Columns["TenChiPhiHD"].Header.Caption = "Tên Chi Phí";
            cbChiPhiHoatDong.DisplayLayout.Bands[0].Columns["TenChiPhiHD"].Width = 200;
            cbChiPhiHoatDong.DisplayLayout.Bands[0].Columns["TenChiPhiHD"].Header.VisiblePosition = 1;

        }

        private void cbChiTietHoatDong_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {

            HamDungChung h = new HamDungChung();
            h.ultragrdEmail_InitializeLayout(sender, e);
            foreach (UltraGridColumn col in this.cbChiTietHoatDong.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;
                col.Hidden = true;
            }
            cbChiTietHoatDong.DisplayLayout.Bands[0].Columns["MaChiTietHoatDongQL"].Hidden = false;
            cbChiTietHoatDong.DisplayLayout.Bands[0].Columns["MaChiTietHoatDongQL"].Header.Caption = "Mã Quản Lý";
            cbChiTietHoatDong.DisplayLayout.Bands[0].Columns["MaChiTietHoatDongQL"].Width = 100;
            cbChiTietHoatDong.DisplayLayout.Bands[0].Columns["MaChiTietHoatDongQL"].Header.VisiblePosition = 0;

            cbChiTietHoatDong.DisplayLayout.Bands[0].Columns["TenChiTietHoatDong"].Hidden = false;
            cbChiTietHoatDong.DisplayLayout.Bands[0].Columns["TenChiTietHoatDong"].Header.Caption = "Chi Tiết Hoạt Động";
            cbChiTietHoatDong.DisplayLayout.Bands[0].Columns["TenChiTietHoatDong"].Width = 200;
            cbChiTietHoatDong.DisplayLayout.Bands[0].Columns["TenChiTietHoatDong"].Header.VisiblePosition = 1;

        }
    }
}
