using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Csla;
using Infragistics.Win.UltraWinGrid;
using Infragistics.Win.UltraDataGridView;
using Infragistics.Win;
using ERP_Library;

namespace PSC_ERP
{
    public partial class frmDanhSachSoDienThoaiNhanVien : Form
    {
        public NhanVien_DienThoai_FaxList _NhanVien_DienThoai_FaxList;

        public frmDanhSachSoDienThoaiNhanVien(NhanVien_DienThoai_FaxList dtList)
        {
            InitializeComponent();
            _NhanVien_DienThoai_FaxList = dtList;
            for (int i = 0; i < _NhanVien_DienThoai_FaxList.Count; i++)
            {
                if (_NhanVien_DienThoai_FaxList[i].SoDTFax == "")
                {
                    _NhanVien_DienThoai_FaxList.RemoveAt(i);
                }
            }
            DSSoDienThoai_bindingSource.DataSource = _NhanVien_DienThoai_FaxList;
        }

        private void grd_DSSoDienThoaiNhanVien_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            HamDungChung t = new HamDungChung();
            t.ultragrdEmail_InitializeLayout(sender, e);

            grd_DSSoDienThoaiNhanVien.DisplayLayout.Override.HeaderAppearance.BackColor = Color.SteelBlue;
            grd_DSSoDienThoaiNhanVien.DisplayLayout.Override.HeaderStyle = HeaderStyle.WindowsXPCommand;

            grd_DSSoDienThoaiNhanVien.DisplayLayout.Bands[0].Columns["MaChiTiet"].Hidden = true;
            grd_DSSoDienThoaiNhanVien.DisplayLayout.Bands[0].Columns["MaDienThoaiFax"].Hidden = true;
            grd_DSSoDienThoaiNhanVien.DisplayLayout.Bands[0].Columns["MaNhanVien"].Hidden = true;
            grd_DSSoDienThoaiNhanVien.DisplayLayout.Bands[0].Columns["Active"].Hidden = true;
            grd_DSSoDienThoaiNhanVien.DisplayLayout.Bands[0].Columns["Loai"].Hidden = true;

            grd_DSSoDienThoaiNhanVien.DisplayLayout.Bands[0].Columns["SoDTFax"].Header.Caption = "Số Điện Thoại";
            grd_DSSoDienThoaiNhanVien.DisplayLayout.Bands[0].Columns["SoDTFax"].Width = 350;

            foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn col in grd_DSSoDienThoaiNhanVien.DisplayLayout.Bands[0].Columns)
            {
                col.SortIndicator = SortIndicator.Ascending;
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = Color.Navy;
            }
        }

        private void frmDanhSachSoDienThoaiNhanVien_FormClosed(object sender, FormClosedEventArgs e)
        {
            grd_DSSoDienThoaiNhanVien.UpdateData();
        }
    }
}