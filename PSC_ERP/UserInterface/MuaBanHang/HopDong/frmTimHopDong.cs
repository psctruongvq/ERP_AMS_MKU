using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Infragistics.Win;
using Infragistics.Shared;
using Infragistics.Win.UltraWinGrid;
using CrystalDecisions.CrystalReports.Engine;
using System.Data.SqlClient;
using ERP_Library;



namespace PSC_ERP
{
    public partial class frmTimHopDong : Form
    {
        public  HopDongMuaBan HopDongMuaBan = HopDongMuaBan.NewHopDongMuaBan();
        private byte _loai;
        private bool _muaBan;

        #region Contructors
        public frmTimHopDong()
        {
            InitializeComponent();
        }
        
        public frmTimHopDong(byte loaiHopDong)
        {
            InitializeComponent();
            _loai = loaiHopDong;
        }

        public frmTimHopDong(HopDongMuaBanList _hopDongMuaBanList , string  chuoiTimKiem, byte loai)
        {
            InitializeComponent();
            _loai = loai;
            txt_ThongTinTimKiem.Text = chuoiTimKiem;
            hopDongMuaBanListBindingSource.DataSource = _hopDongMuaBanList;
        }
        #endregion

        #region grdu_DanhSachHopDong_InitializeLayout
        private void grdu_DanhSachHopDong_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            foreach (UltraGridColumn col in this.grdu_DanhSachHopDong.DisplayLayout.Bands[0].Columns)
            {
                col.Hidden = true;
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;//x =  //= System.Drawing.w;//RoyalBlue
            }
            grdu_DanhSachHopDong.DisplayLayout.Bands[0].Columns["SoHopDong"].Header.Caption = "Số Hợp Đồng";
            grdu_DanhSachHopDong.DisplayLayout.Bands[0].Columns["SoHopDong"].Header.VisiblePosition = 1;
            grdu_DanhSachHopDong.DisplayLayout.Bands[0].Columns["SoHopDong"].Hidden = false;

            grdu_DanhSachHopDong.DisplayLayout.Bands[0].Columns["TenHopDong"].Header.Caption = "Tên Hợp Đồng";
            grdu_DanhSachHopDong.DisplayLayout.Bands[0].Columns["TenHopDong"].Header.VisiblePosition = 2;
            grdu_DanhSachHopDong.DisplayLayout.Bands[0].Columns["TenHopDong"].Hidden = false;

            grdu_DanhSachHopDong.DisplayLayout.Bands[0].Columns["NgayLap"].Header.Caption = "Ngày Lập";
            grdu_DanhSachHopDong.DisplayLayout.Bands[0].Columns["NgayLap"].Header.VisiblePosition = 3;
            grdu_DanhSachHopDong.DisplayLayout.Bands[0].Columns["NgayLap"].Hidden = false;

            grdu_DanhSachHopDong.DisplayLayout.Bands[0].Columns["NgayKy"].Header.Caption = "Ngày Ký";
            grdu_DanhSachHopDong.DisplayLayout.Bands[0].Columns["NgayKy"].Header.VisiblePosition = 4;
            grdu_DanhSachHopDong.DisplayLayout.Bands[0].Columns["NgayKy"].Hidden = false;

            grdu_DanhSachHopDong.DisplayLayout.Bands[0].Columns["TongTien"].Header.Caption = "Tổng Tiền";
            grdu_DanhSachHopDong.DisplayLayout.Bands[0].Columns["TongTien"].Header.VisiblePosition = 5;
            grdu_DanhSachHopDong.DisplayLayout.Bands[0].Columns["TongTien"].Hidden = false;
            grdu_DanhSachHopDong.DisplayLayout.Bands[0].Columns["TongTien"].MaskInput = "{LOC}nnn,nnn,nnn,nnn,nnn.nn";
            grdu_DanhSachHopDong.DisplayLayout.Bands[0].Columns["TongTien"].Format = "###,###,###,###,###";

            grdu_DanhSachHopDong.DisplayLayout.Bands[0].Columns["NgayHetHan"].Header.Caption = "Ngày Hết Hạn";
            grdu_DanhSachHopDong.DisplayLayout.Bands[0].Columns["NgayHetHan"].Header.VisiblePosition = 6;
            grdu_DanhSachHopDong.DisplayLayout.Bands[0].Columns["NgayHetHan"].Hidden = false;

            grdu_DanhSachHopDong.DisplayLayout.Bands[0].Columns["GhiChu"].Header.Caption = "Ghi Chú";
            grdu_DanhSachHopDong.DisplayLayout.Bands[0].Columns["GhiChu"].Header.VisiblePosition = 7;
            grdu_DanhSachHopDong.DisplayLayout.Bands[0].Columns["GhiChu"].Hidden = false;

            grdu_DanhSachHopDong.DisplayLayout.Bands[0].Columns["TenDoiTac"].Header.Caption = "Tên Đối Tác";
            grdu_DanhSachHopDong.DisplayLayout.Bands[0].Columns["TenDoiTac"].Header.VisiblePosition = 8;
            grdu_DanhSachHopDong.DisplayLayout.Bands[0].Columns["TenDoiTac"].Hidden = false;

            grdu_DanhSachHopDong.DisplayLayout.Bands[0].Columns["MaQLDoiTac"].Header.Caption = "Mã Đối Tác";
            grdu_DanhSachHopDong.DisplayLayout.Bands[0].Columns["MaQLDoiTac"].Header.VisiblePosition = 9;
            grdu_DanhSachHopDong.DisplayLayout.Bands[0].Columns["MaQLDoiTac"].Hidden = false;

            grdu_DanhSachHopDong.DisplayLayout.Bands[0].Columns["CMND"].Header.Caption = "Số CMND";
            grdu_DanhSachHopDong.DisplayLayout.Bands[0].Columns["CMND"].Header.VisiblePosition = 10;
            grdu_DanhSachHopDong.DisplayLayout.Bands[0].Columns["CMND"].Hidden = false;

        }
        #endregion

        #region grdu_DanhSachHopDong_KeyDown
        private void grdu_DanhSachHopDong_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (grdu_DanhSachHopDong.ActiveRow != null)
                {
                    HopDongMuaBan = ((HopDongMuaBan)hopDongMuaBanListBindingSource.Current); 
                }
                this.Close();
            }
        }
        #endregion

        #region txtThongTinTimKiem_KeyDown
        private void txtThongTinTimKiem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter )
            {
                hopDongMuaBanListBindingSource.DataSource = HopDongMuaBanList.GetHopDongMuaBanList(_loai, txt_ThongTinTimKiem.Text,_muaBan);
            }
            
        }
        #endregion

        #region grdu_DanhSachHopDong_DoubleClickRow
        private void grdu_DanhSachHopDong_DoubleClickRow(object sender, DoubleClickRowEventArgs e)
        {
            if (grdu_DanhSachHopDong.ActiveRow != null)
            {
                HopDongMuaBan = ((HopDongMuaBan)hopDongMuaBanListBindingSource.Current);
            }
            this.Close();
        }
        #endregion
    }
}