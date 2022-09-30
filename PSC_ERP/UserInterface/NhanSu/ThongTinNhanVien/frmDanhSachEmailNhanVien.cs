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
    public partial class frmDanhSachEmailNhanVien : Form
    {
        public NhanVien_EmailList _NhanVien_EmailList;

        public frmDanhSachEmailNhanVien(NhanVien_EmailList emailList)
        {
            InitializeComponent();
            _NhanVien_EmailList = emailList;
            for (int i = 0; i < _NhanVien_EmailList.Count; i++ )
            {
                if (_NhanVien_EmailList[i].DiaChi == "")
                {
                    _NhanVien_EmailList.RemoveAt(i);
                }
            }
            DSEmail_BindingSource.DataSource = _NhanVien_EmailList;
        }

        private void grd_DSEmailNhanVien_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            HamDungChung t = new HamDungChung();
            t.ultragrdEmail_InitializeLayout(sender, e);

            grd_DSEmailNhanVien.DisplayLayout.Override.HeaderAppearance.BackColor = Color.SteelBlue;
            grd_DSEmailNhanVien.DisplayLayout.Override.HeaderStyle = HeaderStyle.WindowsXPCommand;

            grd_DSEmailNhanVien.DisplayLayout.Bands[0].Columns["MaChiTiet"].Hidden = true;
            grd_DSEmailNhanVien.DisplayLayout.Bands[0].Columns["MaDiaChiWebsite"].Hidden = true;
            grd_DSEmailNhanVien.DisplayLayout.Bands[0].Columns["MaNhanVien"].Hidden = true;
            grd_DSEmailNhanVien.DisplayLayout.Bands[0].Columns["Loai"].Hidden = true;
            
            grd_DSEmailNhanVien.DisplayLayout.Bands[0].Columns["DiaChi"].Header.Caption = "Địa Chỉ Email";
            grd_DSEmailNhanVien.DisplayLayout.Bands[0].Columns["DiaChi"].Width = 350;

            foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn col in grd_DSEmailNhanVien.DisplayLayout.Bands[0].Columns)
            {
                col.SortIndicator = SortIndicator.Ascending;
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = Color.Navy;
            }
        }

        private void frmDanhSachEmailNhanVien_FormClosed(object sender, FormClosedEventArgs e)
        {
            grd_DSEmailNhanVien.UpdateData();
        }
    }
}