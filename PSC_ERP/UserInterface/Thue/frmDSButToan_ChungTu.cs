using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ERP_Library;

namespace PSC_ERP
{
    
    public partial class frmDSButToan_ChungTu : Form
    {
        public int _mabt = 0;
        public decimal _sotien = 0;
        ChungTu _ct;
        public ButToan _bt;
        public frmDSButToan_ChungTu(ChungTu ct)
        {
            InitializeComponent();
            bind_buttoan.DataSource = typeof(ERP_Library.ButToanList);
            _ct = ct;
            bind_buttoan.DataSource = ct.DinhKhoan.ButToan;
            grd_buttoan.DataSource =bind_buttoan ;
        }

        private void grd_buttoan_DoubleClickRow(object sender, Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs e)
        {
            if (grd_buttoan.ActiveRow != null)
            {
                this._mabt = (int)grd_buttoan.ActiveRow.Cells["MaButToan"].Value;
                this._sotien = (decimal)grd_buttoan.ActiveRow.Cells["SoTien"].Value;
                _bt=((ButToan)bind_buttoan.Current);              
                this.Close();
            }
        }

        private void grd_buttoan_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            grd_buttoan.DisplayLayout.Bands[0].Columns["MaButtoan"].Hidden = true;
            grd_buttoan.DisplayLayout.Bands[0].Columns["NoTaiKhoan"].Hidden = true;
            grd_buttoan.DisplayLayout.Bands[0].Columns["TentaikhoanNo"].Hidden = true;
            grd_buttoan.DisplayLayout.Bands[0].Columns["CoTaiKhoan"].Hidden = true;

            grd_buttoan.DisplayLayout.Bands[0].Columns["TentaikhoanCo"].Hidden = true;
            grd_buttoan.DisplayLayout.Bands[0].Columns["DienGiai"].Hidden = true;
            grd_buttoan.DisplayLayout.Bands[0].Columns["ButToanChiPhiHD"].Hidden = true;
            grd_buttoan.DisplayLayout.Bands[0].Columns["Chon"].Hidden = true;
            grd_buttoan.DisplayLayout.Bands[0].Columns["Doituongno"].Hidden = true;
            grd_buttoan.DisplayLayout.Bands[0].Columns["Doituongco"].Hidden = true;
            if (_ct.DinhKhoan.LaMotNoNhieuCo)
            {
                grd_buttoan.DisplayLayout.Bands[0].Columns["SoHIeuTkNo"].Hidden = true;
                grd_buttoan.DisplayLayout.Bands[0].Columns["SoHIeuTkCo"].Header.Caption = "Tài Khoản Có";
            }
            else
            {
                grd_buttoan.DisplayLayout.Bands[0].Columns["SoHIeuTkNo"].Header.Caption = "Tài Khoản Có";
                grd_buttoan.DisplayLayout.Bands[0].Columns["SoHIeuTkCo"].Hidden = true;

            }
            grd_buttoan.DisplayLayout.Bands[0].Columns["SoHIeuTkNo"].Width = 50;
            grd_buttoan.DisplayLayout.Bands[0].Columns["SoHIeuTkCo"].Width = 50;
            grd_buttoan.DisplayLayout.Bands[0].Columns["Sotien"].Header.Caption = "Số Tiền";
            grd_buttoan.DisplayLayout.Bands[0].Columns["Sotien"].Format = "#,###";
        }
    }
}
