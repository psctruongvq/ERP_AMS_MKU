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
    public partial class frmTaiKhoanNguon : Form
    {
        NguonList _nguonList;
        TaiKhoan_NguonList _taiKhoanNguonList;
        HeThongTaiKhoan1List _taiKhoanList;
        public frmTaiKhoanNguon()
        {
            InitializeComponent();
            bdData.DataSource = typeof(TaiKhoan_NguonList);            
            bdTaiKhoan.DataSource = typeof(HeThongTaiKhoan1List);
            this.Nguon_bindingSource.DataSource = typeof(NguonList);
        }

        private void frmNguon_Load(object sender, EventArgs e)
        {
            _taiKhoanNguonList = TaiKhoan_NguonList.GetTaiKhoan_NguonList();
            this.bdData.DataSource = _taiKhoanNguonList;
            _taiKhoanList = HeThongTaiKhoan1List.GetHeThongTaiKhoan1List();
            bdTaiKhoan.DataSource = _taiKhoanList;
            _nguonList = NguonList.GetNguonList();
            this.Nguon_bindingSource.DataSource = _nguonList;
        }

        private void tlslblLuu_Click(object sender, EventArgs e)
        {
            this.bdData.EndEdit();
            this.grData.UpdateData();
            _taiKhoanNguonList.ApplyEdit();          
            _taiKhoanNguonList.Save();
            MessageBox.Show("Cập nhật thành công","Thông Báo",MessageBoxButtons.OK,MessageBoxIcon.Information);
            _taiKhoanNguonList = TaiKhoan_NguonList.GetTaiKhoan_NguonList();
            this.bdData.DataSource = _taiKhoanNguonList;
        }

        private void tlslblXoa_Click(object sender, EventArgs e)
        {
            grData.DeleteSelectedRows();
        }

        private void tlslblUndo_Click(object sender, EventArgs e)
        {
            _taiKhoanNguonList = TaiKhoan_NguonList.GetTaiKhoan_NguonList();
            this.bdData.DataSource = _taiKhoanNguonList;
        }

        private void tlslblThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ultragrdChucVu_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            HamDungChung h = new HamDungChung();
            h.ultragrdEmail_InitializeLayout(sender, e);
            foreach (UltraGridColumn col in this.cbNguon.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;
                col.Hidden = true;
            }
            cbNguon.DisplayLayout.Bands[0].Columns["MaNguonQuanLy"].Hidden = false;
            cbNguon.DisplayLayout.Bands[0].Columns["MaNguonQuanLy"].Header.Caption = "Mã Nguồn Quản Lý";
            cbNguon.DisplayLayout.Bands[0].Columns["MaNguonQuanLy"].Width = 120;
            cbNguon.DisplayLayout.Bands[0].Columns["MaNguonQuanLy"].Header.VisiblePosition = 0;

            cbNguon.DisplayLayout.Bands[0].Columns["TenNguon"].Hidden = false;
            cbNguon.DisplayLayout.Bands[0].Columns["TenNguon"].Header.Caption = "Tên Nguồn";
            cbNguon.DisplayLayout.Bands[0].Columns["TenNguon"].Width = 120;
            cbNguon.DisplayLayout.Bands[0].Columns["TenNguon"].Header.VisiblePosition = 1;
        }

        private void grData_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            HamDungChung h = new HamDungChung();
            h.ultragrdEmail_InitializeLayout(sender, e);
            foreach (UltraGridColumn col in this.grData.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.RoyalBlue;
                col.Hidden = true;
            }
            grData.DisplayLayout.Bands[0].Columns["MaNguon"].Hidden = false;
            grData.DisplayLayout.Bands[0].Columns["MaNguon"].Header.Caption = "Tên Nguồn";
            grData.DisplayLayout.Bands[0].Columns["MaNguon"].Header.VisiblePosition = 0;
            grData.DisplayLayout.Bands[0].Columns["MaNguon"].EditorComponent = cbNguon;
            grData.DisplayLayout.Bands[0].Columns["MaNguon"].Width = cbNguon.Width;

            grData.DisplayLayout.Bands[0].Columns["MaTaiKhoan"].Hidden = false;
            grData.DisplayLayout.Bands[0].Columns["MaTaiKhoan"].Header.Caption = "Tài Khoản";
            grData.DisplayLayout.Bands[0].Columns["MaTaiKhoan"].Header.VisiblePosition = 1;
            grData.DisplayLayout.Bands[0].Columns["MaTaiKhoan"].EditorComponent = cbTaiKhoan;
            grData.DisplayLayout.Bands[0].Columns["MaTaiKhoan"].Width = cbTaiKhoan.Width;

            grData.DisplayLayout.Bands[0].Columns["NoCo"].Hidden = false;
            grData.DisplayLayout.Bands[0].Columns["NoCo"].Header.Caption = "Nợ-Có";
            grData.DisplayLayout.Bands[0].Columns["NoCo"].Header.VisiblePosition = 2;
            grData.DisplayLayout.Bands[0].Columns["NoCo"].EditorComponent = cbNoCo;
            grData.DisplayLayout.Bands[0].Columns["NoCo"].Width = cbNoCo.Width;
            
        }

        private void cbTaiKhoan_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            foreach (UltraGridColumn col in this.cbTaiKhoan.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.RoyalBlue;
                col.Hidden = true;
            }
            cbTaiKhoan.DisplayLayout.Bands[0].Columns["SoHieuTK"].Hidden = false;
            cbTaiKhoan.DisplayLayout.Bands[0].Columns["SoHieuTK"].Header.Caption = "Số Hiệu TK";
            cbTaiKhoan.DisplayLayout.Bands[0].Columns["SoHieuTK"].Header.VisiblePosition = 0;
            cbTaiKhoan.DisplayLayout.Bands[0].Columns["TenTaiKhoan"].Hidden = false;
            cbTaiKhoan.DisplayLayout.Bands[0].Columns["TenTaiKhoan"].Header.Caption = "Tên Tài Khoản";
            cbTaiKhoan.DisplayLayout.Bands[0].Columns["TenTaiKhoan"].Width = 200;
            cbTaiKhoan.DisplayLayout.Bands[0].Columns["TenTaiKhoan"].Header.VisiblePosition = 1;
   
        }

        private void tlslblIn_Click(object sender, EventArgs e)
        {
            HamDungChung.ExportToExcel(grData);
        }
    }
}