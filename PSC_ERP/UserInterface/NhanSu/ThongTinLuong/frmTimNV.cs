using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ERP_Library;
using Infragistics.Win.UltraWinGrid;
using Infragistics.Shared;
using Infragistics.Win;
using System.Collections;





namespace PSC_ERP
{
    public partial class frmTimNV : Form
    {
        public static ThongTinNhanVienTongHop _nhanVien;

        #region frmTimNV(TenNV nhanVien, string chuoi)

        //public frmTimNV( string chuoi)
        //{
        //    InitializeComponent();
                  
        //    thongTinNhanVienTongHopListBindingSource.DataSource = ThongTinNhanVienTongHopList.GetThongTinNhanVienTongHopList(chuoi.Trim());
        //}
        public frmTimNV(ArrayList chuoi)
        {
            InitializeComponent();

            //thongTinNhanVienTongHopListBindingSource.DataSource = ThongTinNhanVienTongHopList.GetThongTinNhanVienTongHopList(chuoi);
        }
        public frmTimNV()
        {
            InitializeComponent();
        }
        #endregion

        #region grdu_NhanVien_InitializeLayout
        private void grdu_NhanVien_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            grdu_NhanVien.DisplayLayout.Bands[0].Columns["MaNhanVien"].Hidden = true;
            grdu_NhanVien.DisplayLayout.Bands[0].Columns["MaChucVu"].Hidden = true;
            grdu_NhanVien.DisplayLayout.Bands[0].Columns["TenChucVu"].Hidden = true;
            grdu_NhanVien.DisplayLayout.Bands[0].Columns["MaPhongBan"].Hidden = true;
            grdu_NhanVien.DisplayLayout.Bands[0].Columns["TenPhongBan"].Hidden = true;
            grdu_NhanVien.DisplayLayout.Bands[0].Columns["NgachLuong"].Hidden = true;
            grdu_NhanVien.DisplayLayout.Bands[0].Columns["PhanTramBHXH"].Hidden = true;
            grdu_NhanVien.DisplayLayout.Bands[0].Columns["TienBHXH"].Hidden = true;
            grdu_NhanVien.DisplayLayout.Bands[0].Columns["PhanTramBHYT"].Hidden = true;
            grdu_NhanVien.DisplayLayout.Bands[0].Columns["TienBHYT"].Hidden = true;
            grdu_NhanVien.DisplayLayout.Bands[0].Columns["PhanTramCongDoan"].Hidden = true;
            grdu_NhanVien.DisplayLayout.Bands[0].Columns["PhanTramDanhGiaCB"].Hidden = true;
            grdu_NhanVien.DisplayLayout.Bands[0].Columns["PhanTramDanhGiaKD"].Hidden = true;
            grdu_NhanVien.DisplayLayout.Bands[0].Columns["SoTienCongDoan"].Hidden = true;
            grdu_NhanVien.DisplayLayout.Bands[0].Columns["TienNopThue"].Hidden = true;

            grdu_NhanVien.DisplayLayout.Bands[0].Columns["SoNgayCong"].Hidden = true;
            grdu_NhanVien.DisplayLayout.Bands[0].Columns["SoNgayLamViec"].Hidden = true;
            grdu_NhanVien.DisplayLayout.Bands[0].Columns["TienThucLanh"].Hidden = true;
            grdu_NhanVien.DisplayLayout.Bands[0].Columns["TienThucLanhTron"].Hidden = true;
            grdu_NhanVien.DisplayLayout.Bands[0].Columns["PhiDoan"].Hidden = true;
            grdu_NhanVien.DisplayLayout.Bands[0].Columns["PhiDang"].Hidden = true;

            grdu_NhanVien.DisplayLayout.Bands[0].Columns["PhanTramLCB"].Hidden = true;
            grdu_NhanVien.DisplayLayout.Bands[0].Columns["PhanTramLKD"].Hidden = true;
            grdu_NhanVien.DisplayLayout.Bands[0].Columns["LuongCB"].Hidden = true;
            grdu_NhanVien.DisplayLayout.Bands[0].Columns["HeSoLuongCB"].Hidden = true;
            grdu_NhanVien.DisplayLayout.Bands[0].Columns["NgayVaoLam"].Hidden = true;
            grdu_NhanVien.DisplayLayout.Bands[0].Columns["SoTienHSCB"].Hidden = true;
            grdu_NhanVien.DisplayLayout.Bands[0].Columns["LuongKD"].Hidden = true;
            grdu_NhanVien.DisplayLayout.Bands[0].Columns["HeSoLuongKD"].Hidden = true;
            grdu_NhanVien.DisplayLayout.Bands[0].Columns["SoTienHSKD"].Hidden = true;
            grdu_NhanVien.DisplayLayout.Bands[0].Columns["TenChiNhanh"].Hidden = true;
            grdu_NhanVien.DisplayLayout.Bands[0].Columns["GioiTinh"].Hidden = true;
            grdu_NhanVien.DisplayLayout.Bands[0].Columns["CMND"].Hidden = true;

            grdu_NhanVien.DisplayLayout.Bands[0].Columns["MaChucDanh"].Hidden = true;
            grdu_NhanVien.DisplayLayout.Bands[0].Columns["MaBacLuongCB"].Hidden = true;
            grdu_NhanVien.DisplayLayout.Bands[0].Columns["MaBacLuongKD"].Hidden = true;
            grdu_NhanVien.DisplayLayout.Bands[0].Columns["MaNgachLuongCB"].Hidden = true;
            grdu_NhanVien.DisplayLayout.Bands[0].Columns["MaNgachLuongCB"].Hidden = true;

            grdu_NhanVien.DisplayLayout.Bands[0].Columns["MaQLNhanVien"].Header.Caption = "Mã Nhân Viên";
            grdu_NhanVien.DisplayLayout.Bands[0].Columns["MaQLNhanVien"].Header.VisiblePosition = 0;
            grdu_NhanVien.DisplayLayout.Bands[0].Columns["MaQLNhanVien"].Width = 80;

            grdu_NhanVien.DisplayLayout.Bands[0].Columns["TenNhanVien"].Header.Caption = "Tên Nhân Viên";
            grdu_NhanVien.DisplayLayout.Bands[0].Columns["TenNhanVien"].Header.VisiblePosition = 1;
            grdu_NhanVien.DisplayLayout.Bands[0].Columns["TenNhanVien"].Width = 200;

            grdu_NhanVien.DisplayLayout.Bands[0].Columns["CardID"].Header.Caption = "Card ID";
            grdu_NhanVien.DisplayLayout.Bands[0].Columns["CardID"].Header.VisiblePosition = 2;
            grdu_NhanVien.DisplayLayout.Bands[0].Columns["CardID"].Width = 150;

            grdu_NhanVien.DisplayLayout.Override.HeaderAppearance.BackColor = Color.SteelBlue;
            this.grdu_NhanVien.DisplayLayout.Override.HeaderStyle = HeaderStyle.WindowsXPCommand;

            foreach (UltraGridColumn col in this.grdu_NhanVien.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = Color.Navy;
            }
        }
        #endregion 

        private void grdu_NhanVien_DoubleClickRow(object sender, DoubleClickRowEventArgs e)
        {
            _nhanVien = ((ThongTinNhanVienTongHop)(thongTinNhanVienTongHopListBindingSource.Current));
            this.Close();
        }

        private void grdu_NhanVien_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                _nhanVien = ((ThongTinNhanVienTongHop)(thongTinNhanVienTongHopListBindingSource.Current));
                this.Close();
            }
        }
    }
}