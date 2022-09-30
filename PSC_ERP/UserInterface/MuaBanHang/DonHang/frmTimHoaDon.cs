using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ERP_Library;
using Infragistics.Win;
using Infragistics.Shared;
using Infragistics.Win.UltraWinGrid;

namespace PSC_ERP
{
    public partial class frmTimHoaDon : Form
    {
        private byte _quyTrinh;
        private byte _loai;
        public HoaDon _hoaDon;

        #region Contructors
        public frmTimHoaDon()
        {
            InitializeComponent();
        }

        public frmTimHoaDon(byte quyTrinh, byte loai, HoaDonList hoaDonList, string chuoiTimKiem)
        {
            InitializeComponent();
            txt_ThongTinTimKiem.Text = chuoiTimKiem;
            _quyTrinh = quyTrinh;
            _loai = loai;
            hoaDonListBindingSource.DataSource = hoaDonList;
        }
        #endregion

        #region grdu_HoaDon_InitializeLayout
        private void grdu_HoaDon_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            this.grdu_HoaDon.DisplayLayout.Override.HeaderStyle = HeaderStyle.WindowsXPCommand;
            this.grdu_HoaDon.DisplayLayout.Override.HeaderAppearance.BackColor = System.Drawing.Color.SteelBlue;
            foreach (UltraGridColumn col in this.grdu_HoaDon.DisplayLayout.Bands[0].Columns)
            {
                col.Hidden = true;
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;//x =  //= System.Drawing.w;//RoyalBlue
            }

            grdu_HoaDon.DisplayLayout.Bands[0].Columns["SoSerial"].Hidden = false;
            grdu_HoaDon.DisplayLayout.Bands[0].Columns["SoSerial"].Header.Caption = "Số Serial";
            grdu_HoaDon.DisplayLayout.Bands[0].Columns["SoHoaDon"].Hidden = false;
            grdu_HoaDon.DisplayLayout.Bands[0].Columns["SoHoaDon"].Header.Caption = "Số Hóa Đơn";
            grdu_HoaDon.DisplayLayout.Bands[0].Columns["TongTien"].Hidden = false;
            grdu_HoaDon.DisplayLayout.Bands[0].Columns["TongTien"].Header.Caption = "Tổng Tiền";
            grdu_HoaDon.DisplayLayout.Bands[0].Columns["NgayLap"].Hidden = false;
            grdu_HoaDon.DisplayLayout.Bands[0].Columns["NgayLap"].Header.Caption = "Ngày Lập";

            grdu_HoaDon.DisplayLayout.Bands[0].Columns["TenDoiTac"].Header.Caption = "Tên Đối Tác";
            grdu_HoaDon.DisplayLayout.Bands[0].Columns["TenDoiTac"].Header.VisiblePosition = 8;
            grdu_HoaDon.DisplayLayout.Bands[0].Columns["TenDoiTac"].Hidden = false;

            grdu_HoaDon.DisplayLayout.Bands[0].Columns["MaQLDoiTac"].Header.Caption = "Mã Đối Tác";
            grdu_HoaDon.DisplayLayout.Bands[0].Columns["MaQLDoiTac"].Header.VisiblePosition = 9;
            grdu_HoaDon.DisplayLayout.Bands[0].Columns["MaQLDoiTac"].Hidden = false;

            grdu_HoaDon.DisplayLayout.Bands[0].Columns["CMND"].Header.Caption = "Số CMND";
            grdu_HoaDon.DisplayLayout.Bands[0].Columns["CMND"].Header.VisiblePosition = 10;
            grdu_HoaDon.DisplayLayout.Bands[0].Columns["CMND"].Hidden = false;

        }
        #endregion

        #region txt_ThongTinTimKiem_KeyDown
        private void txt_ThongTinTimKiem_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                if (_loai == 0)
                {                    
                    hoaDonListBindingSource.DataSource = HoaDonList.GetHoaDonList(1, 1, false, 0,txt_ThongTinTimKiem.Text);
                }
                else if (_loai == 1)
                {                    
                    hoaDonListBindingSource.DataSource = HoaDonList.GetHoaDonList(3, 1, false, 0,txt_ThongTinTimKiem.Text);
                }
                else if (_loai == 2)
                {                    
                     hoaDonListBindingSource.DataSource = HoaDonList.GetHoaDonList(0, 1, false, 0,txt_ThongTinTimKiem.Text);
                }
                else if (_loai == 3)
                {
                     hoaDonListBindingSource.DataSource = HoaDonList.GetHoaDonList(2, 1, false,0,txt_ThongTinTimKiem.Text);
                }

            }
        }
        #endregion

        #region grdu_HoaDon_KeyDown
        private void grdu_HoaDon_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (grdu_HoaDon.ActiveRow != null)
                {
                    _hoaDon = (HoaDon)(hoaDonListBindingSource.Current);
                }
                else if(grdu_HoaDon.Rows.Count != 0 )
                {
                    grdu_HoaDon.ActiveRow = grdu_HoaDon.Rows[0];
                }
                this.Close();
            }

        }
        #endregion 

        #region grdu_HoaDon_DoubleClickRow
        private void grdu_HoaDon_DoubleClickRow(object sender, DoubleClickRowEventArgs e)
        {
            _hoaDon = (HoaDon)(hoaDonListBindingSource.Current);
            this.Close();
        }
        #endregion

    }
}