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
    public partial class frmTimDonHang : Form
    {
        #region properties
        private byte _quyTrinh;
        private byte _loai;
        private string _chuoiTimKiem;
        private bool _nhapXuat;
        private byte _loaiDonHang;

        public DonHangMua _donHangMua;
        public DonHangBan _donHangBan;
        public DonNhanHangTra _donNhanHangTra;
        public DonTraHangMua _donTraHangMua;
        #endregion 

        #region contructors
        public frmTimDonHang()
        {
            InitializeComponent();
        }

        public frmTimDonHang(byte quyTrinh, byte loai, string chuoiTimKiem, bool nhapXuat)
        {
            InitializeComponent();
            txt_ThongTinTimKiem.Text = chuoiTimKiem;
            _quyTrinh = quyTrinh;
            _loai = loai;
            _chuoiTimKiem = chuoiTimKiem;
            _nhapXuat = nhapXuat;
            KhoiTao(quyTrinh, loai);
        }
        #endregion

        #region KhoiTao
        private void KhoiTao(byte quyTrinh, byte loai)
        {
            _loaiDonHang = loai;


            if (_nhapXuat == true && (loai == 0 || loai ==1))
            {
                KhoiTaoDonHangMua();
            }
            else if (_nhapXuat == true && loai == 2)
            {
                KhoiTaoNhanHangTra();

            }
            else if (_nhapXuat == false && (loai == 0  || loai == 1))
            {
                KhoiTaoDonHangBan();
            }
            else if (_nhapXuat == false && loai == 2)
            {
                KhoiTaoDonTraHangMua();
            }
        }
        #endregion

        #region KhoiTaoDonHangMua()
        private void KhoiTaoDonHangMua()
        {
            grdu_DonHang.DataSource = donHangMuaBindingSource;
            donHangMuaBindingSource.DataSource = DonHangMuaList.GetDonHangMuaList(false,_quyTrinh,_loaiDonHang,_chuoiTimKiem,_loai);

            this.grdu_DonHang.DisplayLayout.Override.HeaderStyle = HeaderStyle.WindowsXPCommand;
            this.grdu_DonHang.DisplayLayout.Override.HeaderAppearance.BackColor = System.Drawing.Color.SteelBlue;
            foreach (UltraGridColumn col in this.grdu_DonHang.DisplayLayout.Bands[0].Columns)
            {
                col.Hidden = true;
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;//x =  //= System.Drawing.w;//RoyalBlue
            }

            grdu_DonHang.DisplayLayout.Bands[0].Columns["NgayLap"].Hidden = false;
            grdu_DonHang.DisplayLayout.Bands[0].Columns["NgayLap"].Header.Caption = "Ngày Lập";
            grdu_DonHang.DisplayLayout.Bands[0].Columns["TongTien"].Hidden = false;
            grdu_DonHang.DisplayLayout.Bands[0].Columns["TongTien"].Header.Caption = "Tổng Tiền";

            grdu_DonHang.DisplayLayout.Bands[0].Columns["SoDonHang"].Hidden = false;
            grdu_DonHang.DisplayLayout.Bands[0].Columns["SoDonHang"].Header.Caption = "Số Đơn Hàng";

            grdu_DonHang.DisplayLayout.Bands[0].Columns["NgayNhanHang"].Hidden = false;
            grdu_DonHang.DisplayLayout.Bands[0].Columns["NgayNhanHang"].Header.Caption = "Ngày Nhận Hàng";

            grdu_DonHang.DisplayLayout.Bands[0].Columns["NhapXuat"].Hidden = false;
            grdu_DonHang.DisplayLayout.Bands[0].Columns["NhapXuat"].Header.Caption = "Nhập Xuất";

            grdu_DonHang.DisplayLayout.Bands[0].Columns["TenDoiTac"].Header.Caption = "Tên Đối Tác";
            grdu_DonHang.DisplayLayout.Bands[0].Columns["TenDoiTac"].Header.VisiblePosition = 8;
            grdu_DonHang.DisplayLayout.Bands[0].Columns["TenDoiTac"].Hidden = false;

            grdu_DonHang.DisplayLayout.Bands[0].Columns["MaQLDoiTac"].Header.Caption = "Mã Đối Tác";
            grdu_DonHang.DisplayLayout.Bands[0].Columns["MaQLDoiTac"].Header.VisiblePosition = 9;
            grdu_DonHang.DisplayLayout.Bands[0].Columns["MaQLDoiTac"].Hidden = false;

            grdu_DonHang.DisplayLayout.Bands[0].Columns["CMND"].Header.Caption = "Số CMND";
            grdu_DonHang.DisplayLayout.Bands[0].Columns["CMND"].Header.VisiblePosition = 10;
            grdu_DonHang.DisplayLayout.Bands[0].Columns["CMND"].Hidden = false;
            
            this.grdu_DonHang.DisplayLayout.Bands["CT_DonHangBanList"].Hidden = true;


        }
        #endregion

        #region KhoiTaoNhanHangTra()
        private void KhoiTaoNhanHangTra()
        {
            grdu_DonHang.DataSource = donNhanHangTraBindingSource;
            donNhanHangTraBindingSource.DataSource = DonNhanHangTraList.GetDonNhanHangTraList(false, _chuoiTimKiem);

            this.grdu_DonHang.DisplayLayout.Override.HeaderStyle = HeaderStyle.WindowsXPCommand;
            this.grdu_DonHang.DisplayLayout.Override.HeaderAppearance.BackColor = System.Drawing.Color.SteelBlue;
            foreach (UltraGridColumn col in this.grdu_DonHang.DisplayLayout.Bands[0].Columns)
            {
                col.Hidden = true;
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;//x =  //= System.Drawing.w;//RoyalBlue
            }

            grdu_DonHang.DisplayLayout.Bands[0].Columns["NgayLap"].Hidden = false;
            grdu_DonHang.DisplayLayout.Bands[0].Columns["NgayLap"].Header.Caption = "Ngày Lập";
            grdu_DonHang.DisplayLayout.Bands[0].Columns["TongTien"].Hidden = false;
            grdu_DonHang.DisplayLayout.Bands[0].Columns["TongTien"].Header.Caption = "Tổng Tiền";

            grdu_DonHang.DisplayLayout.Bands[0].Columns["SoDonHang"].Hidden = false;
            grdu_DonHang.DisplayLayout.Bands[0].Columns["SoDonHang"].Header.Caption = "Số Đơn Hàng";

            grdu_DonHang.DisplayLayout.Bands[0].Columns["NhapXuat"].Hidden = false;
            grdu_DonHang.DisplayLayout.Bands[0].Columns["NhapXuat"].Header.Caption = "Nhập Xuất";
            grdu_DonHang.DisplayLayout.Bands[0].Columns["NhapXuat"].Header.VisiblePosition = 0;

            grdu_DonHang.DisplayLayout.Bands[0].Columns["TenDoiTac"].Header.Caption = "Tên Đối Tác";
            grdu_DonHang.DisplayLayout.Bands[0].Columns["TenDoiTac"].Header.VisiblePosition = 8;
            grdu_DonHang.DisplayLayout.Bands[0].Columns["TenDoiTac"].Hidden = false;

            grdu_DonHang.DisplayLayout.Bands[0].Columns["MaQLDoiTac"].Header.Caption = "Mã Đối Tác";
            grdu_DonHang.DisplayLayout.Bands[0].Columns["MaQLDoiTac"].Header.VisiblePosition = 9;
            grdu_DonHang.DisplayLayout.Bands[0].Columns["MaQLDoiTac"].Hidden = false;

            grdu_DonHang.DisplayLayout.Bands[0].Columns["CMND"].Header.Caption = "Số CMND";
            grdu_DonHang.DisplayLayout.Bands[0].Columns["CMND"].Header.VisiblePosition = 10;
            grdu_DonHang.DisplayLayout.Bands[0].Columns["CMND"].Hidden = false;

            this.grdu_DonHang.DisplayLayout.Bands["CT_DonNhanHangTraList"].Hidden = true;

        }
        #endregion

        #region KhoiTaoDonTraHangMua()
        private void KhoiTaoDonTraHangMua()
        {
            grdu_DonHang.DataSource = donTraHangMuaBindingSource;
            donTraHangMuaBindingSource.DataSource = DonTraHangMuaList.GetDonTraHangMuaList(false, _chuoiTimKiem);

            this.grdu_DonHang.DisplayLayout.Override.HeaderStyle = HeaderStyle.WindowsXPCommand;
            this.grdu_DonHang.DisplayLayout.Override.HeaderAppearance.BackColor = System.Drawing.Color.SteelBlue;
            foreach (UltraGridColumn col in this.grdu_DonHang.DisplayLayout.Bands[0].Columns)
            {
                col.Hidden = true;
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;//x =  //= System.Drawing.w;//RoyalBlue
            }


            grdu_DonHang.DisplayLayout.Bands[0].Columns["NgayLap"].Hidden = false;
            grdu_DonHang.DisplayLayout.Bands[0].Columns["NgayLap"].Header.Caption = "Ngày Lập";
            grdu_DonHang.DisplayLayout.Bands[0].Columns["TongTien"].Hidden = false;
            grdu_DonHang.DisplayLayout.Bands[0].Columns["TongTien"].Header.Caption = "Tổng Tiền";
            grdu_DonHang.DisplayLayout.Bands[0].Columns["SoDonHang"].Hidden = false;
            grdu_DonHang.DisplayLayout.Bands[0].Columns["SoDonHang"].Header.Caption = "Số Đơn Hàng";
            grdu_DonHang.DisplayLayout.Bands[0].Columns["NhapXuat"].Hidden = false;
            grdu_DonHang.DisplayLayout.Bands[0].Columns["NhapXuat"].Header.Caption = "Nhập Xuất";
            grdu_DonHang.DisplayLayout.Bands[0].Columns["NhapXuat"].Header.VisiblePosition = 0;

            grdu_DonHang.DisplayLayout.Bands[0].Columns["TenDoiTac"].Header.Caption = "Tên Đối Tác";
            grdu_DonHang.DisplayLayout.Bands[0].Columns["TenDoiTac"].Header.VisiblePosition = 8;
            grdu_DonHang.DisplayLayout.Bands[0].Columns["TenDoiTac"].Hidden = false;

            grdu_DonHang.DisplayLayout.Bands[0].Columns["MaQLDoiTac"].Header.Caption = "Mã Đối Tác";
            grdu_DonHang.DisplayLayout.Bands[0].Columns["MaQLDoiTac"].Header.VisiblePosition = 9;
            grdu_DonHang.DisplayLayout.Bands[0].Columns["MaQLDoiTac"].Hidden = false;

            grdu_DonHang.DisplayLayout.Bands[0].Columns["CMND"].Header.Caption = "Số CMND";
            grdu_DonHang.DisplayLayout.Bands[0].Columns["CMND"].Header.VisiblePosition = 10;
            grdu_DonHang.DisplayLayout.Bands[0].Columns["CMND"].Hidden = false;

            this.grdu_DonHang.DisplayLayout.Bands["CT_DonTraHangMuaList"].Hidden = true;
        }
        #endregion

        #region KhoiTaoDonHangBan()
        private void KhoiTaoDonHangBan()
        {
            grdu_DonHang.DataSource = donHangBanBindingSource;
            donHangBanBindingSource.DataSource = DonHangBanList.GetDonHangBanList(false, _quyTrinh, _loaiDonHang, _chuoiTimKiem, _loai);

            this.grdu_DonHang.DisplayLayout.Override.HeaderStyle = HeaderStyle.WindowsXPCommand;
            this.grdu_DonHang.DisplayLayout.Override.HeaderAppearance.BackColor = System.Drawing.Color.SteelBlue;
            foreach (UltraGridColumn col in this.grdu_DonHang.DisplayLayout.Bands[0].Columns)
            {
                col.Hidden = true;
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;//x =  //= System.Drawing.w;//RoyalBlue
            }

            grdu_DonHang.DisplayLayout.Bands[0].Columns["NgayLap"].Hidden = false;
            grdu_DonHang.DisplayLayout.Bands[0].Columns["NgayLap"].Header.Caption = "Ngày Lập";

            grdu_DonHang.DisplayLayout.Bands[0].Columns["TongTien"].Hidden = false;
            grdu_DonHang.DisplayLayout.Bands[0].Columns["TongTien"].Header.Caption = "Tổng Tiền";

            grdu_DonHang.DisplayLayout.Bands[0].Columns["SoDonHang"].Hidden = false;
            grdu_DonHang.DisplayLayout.Bands[0].Columns["SoDonHang"].Header.Caption = "Số Đơn Hàng";

            grdu_DonHang.DisplayLayout.Bands[0].Columns["NgayGiaoHang"].Header.Caption = "Ngày Nhận Hàng";
            grdu_DonHang.DisplayLayout.Bands[0].Columns["NgayGiaoHang"].Hidden = false;

            grdu_DonHang.DisplayLayout.Bands[0].Columns["NhapXuat"].Header.Caption = "Nhập Xuất";
            grdu_DonHang.DisplayLayout.Bands[0].Columns["NhapXuat"].Hidden = false;

            grdu_DonHang.DisplayLayout.Bands[0].Columns["TenDoiTac"].Header.Caption = "Tên Đối Tác";
            grdu_DonHang.DisplayLayout.Bands[0].Columns["TenDoiTac"].Header.VisiblePosition = 8;
            grdu_DonHang.DisplayLayout.Bands[0].Columns["TenDoiTac"].Hidden = false;

            grdu_DonHang.DisplayLayout.Bands[0].Columns["MaQLDoiTac"].Header.Caption = "Mã Đối Tác";
            grdu_DonHang.DisplayLayout.Bands[0].Columns["MaQLDoiTac"].Header.VisiblePosition = 9;
            grdu_DonHang.DisplayLayout.Bands[0].Columns["MaQLDoiTac"].Hidden = false;

            grdu_DonHang.DisplayLayout.Bands[0].Columns["CMND"].Header.Caption = "Số CMND";
            grdu_DonHang.DisplayLayout.Bands[0].Columns["CMND"].Header.VisiblePosition = 10;
            grdu_DonHang.DisplayLayout.Bands[0].Columns["CMND"].Hidden = false;

            this.grdu_DonHang.DisplayLayout.Bands["CT_DonHangBanList"].Hidden = true;
            
        }
        #endregion              

        #region txt_ThongTinTimKiem_KeyDown
        private void txt_ThongTinTimKiem_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                if (_nhapXuat == true && (_loai == 0 || _loai == 1 || _loai == 2 || _loai == 3 || _loai == 11 || _loai == 12 || _loai == 14 || _loai == 15 || _loai == 16))
                {
                    donHangMuaBindingSource.DataSource = DonHangMuaList.GetDonHangMuaList(false, _quyTrinh, _loaiDonHang, _chuoiTimKiem, _loai);
                }
                else if (_nhapXuat == true && _loai == 13)
                {
                    donNhanHangTraBindingSource.DataSource = DonNhanHangTraList.GetDonNhanHangTraList(false, txt_ThongTinTimKiem.Text);
                }
                else if (_nhapXuat == false && (_loai == 0 || _loai == 1 || _loai == 2 || _loai == 3 || _loai == 11 || _loai == 12 || _loai == 14 || _loai == 15 || _loai == 16))
                {
                    donHangBanBindingSource.DataSource = DonHangBanList.GetDonHangBanList(false, _quyTrinh, _loaiDonHang, txt_ThongTinTimKiem.Text, _loai);
                }
                else if (_nhapXuat == false && _loai == 13)
                {                    
                    donTraHangMuaBindingSource.DataSource = DonTraHangMuaList.GetDonTraHangMuaList(false, txt_ThongTinTimKiem.Text);
                }   
            }
        }
        #endregion

        #region grdu_DonHang_KeyDown
        private void grdu_DonHang_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (_loai == 0)
                {
                    _donHangMua = (DonHangMua)(donHangMuaBindingSource.Current);
                }

                else if (_loai == 1)
                {
                    _donNhanHangTra = (DonNhanHangTra)(donNhanHangTraBindingSource.Current);
                }

                else if (_loai == 2)
                {
                    _donHangBan = (DonHangBan)(donHangBanBindingSource.Current);
                }
                else if (_loai == 3)
                {
                    _donTraHangMua = (DonTraHangMua)(donTraHangMuaBindingSource.Current);
                }
                this.Close();
            }
        }
        #endregion

        #region grdu_DonHang_DoubleClickRow
        private void grdu_DonHang_DoubleClickRow(object sender, DoubleClickRowEventArgs e)
        {
            if (_nhapXuat == true && (_loai == 0 || _loai == 1 ))
            {
                _donHangMua = (DonHangMua)(donHangMuaBindingSource.Current);
            }

            else if (_nhapXuat == true && _loai == 2)
            {
                _donNhanHangTra = (DonNhanHangTra)(donNhanHangTraBindingSource.Current);
            }

            else if (_nhapXuat == false && (_loai == 0 || _loai == 1  ))
            {
                _donHangBan = (DonHangBan)(donHangBanBindingSource.Current);
            }
            else if (_nhapXuat == false && _loai == 2)
            {
                _donTraHangMua = (DonTraHangMua)(donTraHangMuaBindingSource.Current);
            }
            this.Close();
        }
        #endregion 
    }
}