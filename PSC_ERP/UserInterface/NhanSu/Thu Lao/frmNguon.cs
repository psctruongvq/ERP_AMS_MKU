using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ERP_Library;
using Infragistics.Win.UltraWinGrid;
namespace PSC_ERP.UserInterface.NhanSu.Thu_Lao
{
    public partial class frmNguon : Form
    {
        NguonList _nguonList;
        HoatDongList _hoatDongList;
        public frmNguon()
        {
            InitializeComponent();
            this.Nguon_bindingSource.DataSource = typeof(NguonList);
        }

        private void frmNguon_Load(object sender, EventArgs e)
        {
            _nguonList = NguonList.GetNguonList();
            this.Nguon_bindingSource.DataSource = _nguonList;
            _hoatDongList = HoatDongList.GetHoatDongList();
            bdHoatDong.DataSource = _hoatDongList;
        }

        private void tlslblLuu_Click(object sender, EventArgs e)
        {
            ultragrdChucVu.UpdateData();            
            this.Nguon_bindingSource.EndEdit();
            _nguonList.ApplyEdit();
            _nguonList.Save();
            MessageBox.Show("Cập nhật thành công","Thông Báo",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }

        private void tlslblXoa_Click(object sender, EventArgs e)
        {
            ultragrdChucVu.DeleteSelectedRows();
        }

        private void tlslblUndo_Click(object sender, EventArgs e)
        {
            _nguonList = NguonList.GetNguonList();
            this.Nguon_bindingSource.DataSource = _nguonList;
        }

        private void tlslblThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ultragrdChucVu_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            HamDungChung h = new HamDungChung();
            h.ultragrdEmail_InitializeLayout(sender, e);
            foreach (UltraGridColumn col in this.ultragrdChucVu.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;
                col.Hidden = true;
            }
            ultragrdChucVu.DisplayLayout.Bands[0].Columns["MaNguonQuanLy"].Hidden = false;
            ultragrdChucVu.DisplayLayout.Bands[0].Columns["MaNguonQuanLy"].Header.Caption = "Mã Nguồn Quản Lý";
            ultragrdChucVu.DisplayLayout.Bands[0].Columns["MaNguonQuanLy"].Width = 120;
            ultragrdChucVu.DisplayLayout.Bands[0].Columns["MaNguonQuanLy"].Header.VisiblePosition = 0;

            ultragrdChucVu.DisplayLayout.Bands[0].Columns["TenNguon"].Hidden = false;
            ultragrdChucVu.DisplayLayout.Bands[0].Columns["TenNguon"].Header.Caption = "Tên Nguồn";
            ultragrdChucVu.DisplayLayout.Bands[0].Columns["TenNguon"].Width = 120;
            ultragrdChucVu.DisplayLayout.Bands[0].Columns["TenNguon"].Header.VisiblePosition = 1;

            ultragrdChucVu.DisplayLayout.Bands[0].Columns["MaHoatDong"].Hidden = false;
            ultragrdChucVu.DisplayLayout.Bands[0].Columns["MaHoatDong"].Header.Caption = "Hoạt Động";
            ultragrdChucVu.DisplayLayout.Bands[0].Columns["MaHoatDong"].Width = 170;
            ultragrdChucVu.DisplayLayout.Bands[0].Columns["MaHoatDong"].EditorComponent = cbHoatDong;
            ultragrdChucVu.DisplayLayout.Bands[0].Columns["MaHoatDong"].Header.VisiblePosition = 2;
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