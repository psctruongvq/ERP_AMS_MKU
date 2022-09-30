using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ERP_Library;
using Infragistics.Shared;
using Infragistics.Win.UltraWinGrid;
using Infragistics.Win;

namespace PSC_ERP
{
    public partial class frmTimLenhNhapXuat : Form
    {
        bool _LaNhap;
        byte _TinhTrang;
        byte _quyTrinh;
        byte _doiTuongNhapXuat = 0;
        Int16 _Loai;
        LenhNhapXuatMuaBanList _LenhNhapXuatMuaBanList;
        public LenhNhapXuatMuaBan _LenhNhapXuatMuaBan = LenhNhapXuatMuaBan.NewLenhNhapXuatMuaBan();

        #region Contructors
        public frmTimLenhNhapXuat()
        {
            InitializeComponent();
        }

        public frmTimLenhNhapXuat( String chuoiTimKiem, bool laNhap, byte tinhTrang, Int16 loai, byte quyTrinh, byte doiTuongNhapXuat)
        {
            InitializeComponent();
            _doiTuongNhapXuat = doiTuongNhapXuat;
            KhoiTao(chuoiTimKiem, laNhap, tinhTrang, loai, quyTrinh); 
        }
        public frmTimLenhNhapXuat(String chuoiTimKiem, bool laNhap, byte tinhTrang, Int16 loai, byte quyTrinh)
        {
            InitializeComponent();
            KhoiTao(chuoiTimKiem, laNhap, tinhTrang, loai, quyTrinh);
        }
        #endregion 

        #region Khởi Tao
        private void KhoiTao(string chuoiTimKiem, bool laNhap, byte tinhTrang, Int16 loai, byte quyTrinh)
        {
            _LaNhap = laNhap;
            _TinhTrang = tinhTrang;
            _Loai = loai;
            _quyTrinh = quyTrinh;        
            _LenhNhapXuatMuaBanList = LenhNhapXuatMuaBanList.GetLenhNhapXuatMuaBanList(_Loai, _TinhTrang, _LaNhap, chuoiTimKiem, quyTrinh, _doiTuongNhapXuat);
            lenhNhapXuatMuaBanListBindingSource.DataSource = _LenhNhapXuatMuaBanList;
        
        }
        #endregion 

        #region grdu_LenhNhapXuat_InitializeLayout
        private void grdu_LenhNhapXuat_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            this.grdu_LenhNhapXuat.DisplayLayout.Override.HeaderStyle = HeaderStyle.WindowsXPCommand;
            this.grdu_LenhNhapXuat.DisplayLayout.Override.HeaderAppearance.BackColor = System.Drawing.Color.SteelBlue;
            foreach (UltraGridColumn col in this.grdu_LenhNhapXuat.DisplayLayout.Bands["LenhNhapXuatMuaBan"].Columns)
            {
                col.Hidden = true;
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;//x =  //= System.Drawing.w;//RoyalBlue
            }

            grdu_LenhNhapXuat.DisplayLayout.Bands["LenhNhapXuatMuaBan"].Columns["DienGiai"].Hidden = false;
            grdu_LenhNhapXuat.DisplayLayout.Bands["LenhNhapXuatMuaBan"].Columns["DienGiai"].Header.Caption = "Diễn Giải";
            grdu_LenhNhapXuat.DisplayLayout.Bands["LenhNhapXuatMuaBan"].Columns["DienGiai"].Header.VisiblePosition = 3;

            grdu_LenhNhapXuat.DisplayLayout.Bands["LenhNhapXuatMuaBan"].Columns["SoBangKe"].Hidden = false;
            grdu_LenhNhapXuat.DisplayLayout.Bands["LenhNhapXuatMuaBan"].Columns["SoBangKe"].Header.Caption = "Số Biên Bản";
            grdu_LenhNhapXuat.DisplayLayout.Bands["LenhNhapXuatMuaBan"].Columns["SoBangKe"].Header.VisiblePosition = 1;

            grdu_LenhNhapXuat.DisplayLayout.Bands["LenhNhapXuatMuaBan"].Columns["TongTien"].Hidden = false;
            grdu_LenhNhapXuat.DisplayLayout.Bands["LenhNhapXuatMuaBan"].Columns["TongTien"].Header.Caption = "Tổng Tiền";
            grdu_LenhNhapXuat.DisplayLayout.Bands["LenhNhapXuatMuaBan"].Columns["TongTien"].Header.VisiblePosition = 2;
            grdu_LenhNhapXuat.DisplayLayout.Bands["LenhNhapXuatMuaBan"].Columns["TongTien"].CellAppearance.TextHAlign = HAlign.Right;
            grdu_LenhNhapXuat.DisplayLayout.Bands["LenhNhapXuatMuaBan"].Columns["TongTien"].Format = "###,###,###,###,###";
            grdu_LenhNhapXuat.DisplayLayout.Bands["LenhNhapXuatMuaBan"].Columns["TongTien"].MaskInput = "{LOC}nnn,nnn,nnn,nnn,nnn";

            grdu_LenhNhapXuat.DisplayLayout.Bands["LenhNhapXuatMuaBan"].Columns["NgayLap"].Hidden = false;
            grdu_LenhNhapXuat.DisplayLayout.Bands["LenhNhapXuatMuaBan"].Columns["NgayLap"].Header.Caption = "Ngày Lập";
            grdu_LenhNhapXuat.DisplayLayout.Bands["LenhNhapXuatMuaBan"].Columns["NgayLap"].Header.VisiblePosition = 0;
            grdu_LenhNhapXuat.DisplayLayout.Bands["LenhNhapXuatMuaBan"].Columns["NgayLap"].Format = "dd/MM/yyyy";
            grdu_LenhNhapXuat.DisplayLayout.Bands["LenhNhapXuatMuaBan"].Columns["NgayLap"].MaskInput = "{LOC}dd/mm/yyyy";


            grdu_LenhNhapXuat.DisplayLayout.Bands["CT_HoaDon_LenhNhapXuatList"].Hidden = true;
            grdu_LenhNhapXuat.DisplayLayout.Bands["CT_LenhNhapXuatList"].Hidden = true;
            grdu_LenhNhapXuat.DisplayLayout.Bands["CT_LenhNhapXuat_DonHangList"].Hidden = true;

        }
        #endregion 

        #region grdu_LenhNhapXuat_DoubleClickRow
        private void grdu_LenhNhapXuat_DoubleClickRow(object sender, DoubleClickRowEventArgs e)
        {
            _LenhNhapXuatMuaBan = (LenhNhapXuatMuaBan)(lenhNhapXuatMuaBanListBindingSource.Current);
            this.Close();
        }
        #endregion 

        #region txt_ThongTinTimKiem_KeyDown
        private void txt_ThongTinTimKiem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {

                _LenhNhapXuatMuaBanList = LenhNhapXuatMuaBanList.GetLenhNhapXuatMuaBanList(_Loai, _TinhTrang, _LaNhap, txt_ThongTinTimKiem.Text, _quyTrinh, _doiTuongNhapXuat);
                lenhNhapXuatMuaBanListBindingSource.DataSource = _LenhNhapXuatMuaBanList;
            }
        }
        #endregion 

        #region grdu_LenhNhapXuat_KeyDown
        private void grdu_LenhNhapXuat_KeyDown(object sender, KeyEventArgs e)
        {
            if (grdu_LenhNhapXuat.ActiveRow != null)
            {
                _LenhNhapXuatMuaBan = (LenhNhapXuatMuaBan)(lenhNhapXuatMuaBanListBindingSource.Current);
                this.Close();
            }
            else if (_LenhNhapXuatMuaBanList.Count !=0 )
            {
                grdu_LenhNhapXuat.ActiveRow = grdu_LenhNhapXuat.Rows[0];
            }

        }
        #endregion 
    }
}