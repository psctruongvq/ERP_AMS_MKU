using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms; 
using ERP_Library;
using Infragistics.Shared;
using Infragistics.Win;
using Infragistics.Win.UltraWinGrid;

namespace PSC_ERP
{
    public partial class frmDanhSachDonHangBanCanTraHang : Form
    {
        private DonHangBan DonHangBan = DonHangBan.NewDonHangBan(0);
        public CT_DonNhanHangTra ct_DonNhanHangTra = CT_DonNhanHangTra.NewCT_DonNhanHangTra() ;
        int MaHangHoa;

        #region Contructors
        public frmDanhSachDonHangBanCanTraHang()
        {
            InitializeComponent();
        }

        public frmDanhSachDonHangBanCanTraHang(DonHangBanList donHangBanList, int tinhTrang, int maHangHoa)
        {
            InitializeComponent();
            KhoiTao(donHangBanList, tinhTrang, maHangHoa);
        }
        #endregion 

        #region Khởi Tạo
        private void KhoiTao(DonHangBanList donHangBanList, int tinhTrang, int maHangHoa)
        {
            donHangBanListBindingSource.DataSource = donHangBanList;
            MaHangHoa = maHangHoa;
        }
        #endregion 

        #region grdu_DanhSachDonHangBan_InitializeLayout
        private void grdu_DanhSachDonHangBan_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            this.grdu_DanhSachDonHangBan.DisplayLayout.Override.HeaderStyle = HeaderStyle.WindowsXPCommand;
            this.grdu_DanhSachDonHangBan.DisplayLayout.Override.HeaderAppearance.BackColor = System.Drawing.Color.SteelBlue;
            foreach (UltraGridColumn col in this.grdu_DanhSachDonHangBan.DisplayLayout.Bands[0].Columns)
            {
                col.Hidden = true;
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;//x =  //= System.Drawing.w;//RoyalBlue
            }

            grdu_DanhSachDonHangBan.DisplayLayout.Bands[0].Columns["NgayLap"].Hidden = false;
            grdu_DanhSachDonHangBan.DisplayLayout.Bands[0].Columns["NgayLap"].Header.Caption = "Ngày Lập";
            grdu_DanhSachDonHangBan.DisplayLayout.Bands[0].Columns["NgayLap"].Format = "dd/MM/yyyy";
            grdu_DanhSachDonHangBan.DisplayLayout.Bands[0].Columns["NgayLap"].MaskInput = "{LOC}dd/mm/yyyy";

            grdu_DanhSachDonHangBan.DisplayLayout.Bands[0].Columns["TongTien"].Hidden = false;
            grdu_DanhSachDonHangBan.DisplayLayout.Bands[0].Columns["TongTien"].Header.Caption = "Tổng Tiền";
            grdu_DanhSachDonHangBan.DisplayLayout.Bands[0].Columns["TongTien"].MaskInput = "{LOC}nnn,nnn,nnn,nnn,nnn.nn";
            grdu_DanhSachDonHangBan.DisplayLayout.Bands[0].Columns["TongTien"].Format = "###,###,###,###,###";
            grdu_DanhSachDonHangBan.DisplayLayout.Bands[0].Columns["TongTien"].CellAppearance.TextHAlign = HAlign.Right;

            grdu_DanhSachDonHangBan.DisplayLayout.Bands[0].Columns["SoDonHang"].Hidden = false;
            grdu_DanhSachDonHangBan.DisplayLayout.Bands[0].Columns["SoDonHang"].Header.Caption = "Số Đơn Hàng";

            grdu_DanhSachDonHangBan.DisplayLayout.Bands[0].Columns["NgayGiaoHang"].Header.Caption = "Ngày Nhận Hàng";
            grdu_DanhSachDonHangBan.DisplayLayout.Bands[0].Columns["NgayGiaoHang"].Hidden = false;

            grdu_DanhSachDonHangBan.DisplayLayout.Bands[0].Columns["NhapXuat"].Header.Caption = "Nhập Xuất";
            grdu_DanhSachDonHangBan.DisplayLayout.Bands[0].Columns["NhapXuat"].Hidden = false;

              grdu_DanhSachDonHangBan.DisplayLayout.Bands[0].Columns["NhapXuat"].Hidden = true;
                grdu_DanhSachDonHangBan.DisplayLayout.Bands[0].Columns["HangTraLai"].Header.Caption = "Trả Lại Hàng";
                grdu_DanhSachDonHangBan.DisplayLayout.Bands[0].Columns["HangTraLai"].Hidden = false;
                this.grdu_DanhSachDonHangBan.DisplayLayout.Bands["CT_DonHangBanList"].Hidden = false;
                foreach (UltraGridColumn col in this.grdu_DanhSachDonHangBan.DisplayLayout.Bands["CT_DonHangBanList"].Columns)
                {
                    col.Hidden = true;
                    col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                    col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                    col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;//x =  //= System.Drawing.w;//RoyalBlue
                }
                grdu_DanhSachDonHangBan.DisplayLayout.Bands["CT_DonHangBanList"].Columns["HangTraLai"].Hidden = false;
                grdu_DanhSachDonHangBan.DisplayLayout.Bands["CT_DonHangBanList"].Columns["HangTraLai"].Header.Caption = "Hàng Trả Lại";
                grdu_DanhSachDonHangBan.DisplayLayout.Bands["CT_DonHangBanList"].Columns["HangTraLai"].Header.VisiblePosition = 1;

                grdu_DanhSachDonHangBan.DisplayLayout.Bands["CT_DonHangBanList"].Columns["TenHangHoa"].Hidden = false;
                grdu_DanhSachDonHangBan.DisplayLayout.Bands["CT_DonHangBanList"].Columns["TenHangHoa"].Header.Caption = "Hàng Hóa";
                grdu_DanhSachDonHangBan.DisplayLayout.Bands["CT_DonHangBanList"].Columns["TenHangHoa"].Header.VisiblePosition = 2;

                grdu_DanhSachDonHangBan.DisplayLayout.Bands["CT_DonHangBanList"].Columns["SoLuong"].Hidden = false;
                grdu_DanhSachDonHangBan.DisplayLayout.Bands["CT_DonHangBanList"].Columns["SoLuong"].Header.Caption = "Số Lượng";
                grdu_DanhSachDonHangBan.DisplayLayout.Bands["CT_DonHangBanList"].Columns["SoLuong"].Header.VisiblePosition = 3;

                grdu_DanhSachDonHangBan.DisplayLayout.Bands["CT_DonHangBanList"].Columns["TenDonViTinh"].Hidden = false;
                grdu_DanhSachDonHangBan.DisplayLayout.Bands["CT_DonHangBanList"].Columns["TenDonViTinh"].Header.Caption = "Đơn Vị Tính";
                grdu_DanhSachDonHangBan.DisplayLayout.Bands["CT_DonHangBanList"].Columns["TenDonViTinh"].Header.VisiblePosition = 4;

                grdu_DanhSachDonHangBan.DisplayLayout.Bands["CT_DonHangBanList"].Columns["KhoiLuongVang"].Hidden = false;
                grdu_DanhSachDonHangBan.DisplayLayout.Bands["CT_DonHangBanList"].Columns["KhoiLuongVang"].Header.Caption = "Khối Lượng";
                grdu_DanhSachDonHangBan.DisplayLayout.Bands["CT_DonHangBanList"].Columns["KhoiLuongVang"].Header.VisiblePosition = 5;

                grdu_DanhSachDonHangBan.DisplayLayout.Bands["CT_DonHangBanList"].Columns["TenDonViKhoiLuong"].Hidden = false;
                grdu_DanhSachDonHangBan.DisplayLayout.Bands["CT_DonHangBanList"].Columns["TenDonViKhoiLuong"].Header.Caption = "Đơn Vị Tính KL";
                grdu_DanhSachDonHangBan.DisplayLayout.Bands["CT_DonHangBanList"].Columns["TenDonViKhoiLuong"].Header.VisiblePosition = 6;

                grdu_DanhSachDonHangBan.DisplayLayout.Bands["CT_DonHangBanList"].Columns["DonGia"].Hidden = false;
                grdu_DanhSachDonHangBan.DisplayLayout.Bands["CT_DonHangBanList"].Columns["DonGia"].Header.Caption = "Đơn Giá";
                grdu_DanhSachDonHangBan.DisplayLayout.Bands["CT_DonHangBanList"].Columns["DonGia"].Header.VisiblePosition = 7;

                grdu_DanhSachDonHangBan.DisplayLayout.Bands["CT_DonHangBanList"].Columns["DGTienCong"].Hidden = false;
                grdu_DanhSachDonHangBan.DisplayLayout.Bands["CT_DonHangBanList"].Columns["DGTienCong"].Header.Caption = "ĐG Tiền Công";
                grdu_DanhSachDonHangBan.DisplayLayout.Bands["CT_DonHangBanList"].Columns["DGTienCong"].Header.VisiblePosition = 8;

                grdu_DanhSachDonHangBan.DisplayLayout.Bands["CT_DonHangBanList"].Columns["DGTienDa"].Hidden = false;
                grdu_DanhSachDonHangBan.DisplayLayout.Bands["CT_DonHangBanList"].Columns["DGTienDa"].Header.Caption = "ĐG Tiền Đá";
                grdu_DanhSachDonHangBan.DisplayLayout.Bands["CT_DonHangBanList"].Columns["DGTienDa"].Header.VisiblePosition = 9;

                grdu_DanhSachDonHangBan.DisplayLayout.Bands["CT_DonHangBanList"].Columns["SoTien"].Hidden = false;
                grdu_DanhSachDonHangBan.DisplayLayout.Bands["CT_DonHangBanList"].Columns["SoTien"].Header.Caption = "Số Tiền";
                grdu_DanhSachDonHangBan.DisplayLayout.Bands["CT_DonHangBanList"].Columns["SoTien"].Header.VisiblePosition = 10;

                grdu_DanhSachDonHangBan.DisplayLayout.Bands["CT_DonHangBanList"].Columns["ChietKhau"].Hidden = false;
                grdu_DanhSachDonHangBan.DisplayLayout.Bands["CT_DonHangBanList"].Columns["ChietKhau"].Header.Caption = "Chiết Khấu";
                grdu_DanhSachDonHangBan.DisplayLayout.Bands["CT_DonHangBanList"].Columns["ChietKhau"].Header.VisiblePosition = 11;

                grdu_DanhSachDonHangBan.DisplayLayout.Bands["CT_DonHangBanList"].Columns["SoTienChietKhau"].Hidden = false;
                grdu_DanhSachDonHangBan.DisplayLayout.Bands["CT_DonHangBanList"].Columns["SoTienChietKhau"].Header.Caption = "Số Tiền CK";
                grdu_DanhSachDonHangBan.DisplayLayout.Bands["CT_DonHangBanList"].Columns["SoTienChietKhau"].Header.VisiblePosition = 12;

           
           
                //this.grdu_DanhSachDonHangBan.DisplayLayout.Bands["CT_DonHangBanList"].Hidden = true;
        }
        #endregion 

        #region grdu_DanhSachDonHangBan_DoubleClick

        private void grdu_DanhSachDonHangBan_DoubleClick(object sender, EventArgs e)
        {
            if (donHangBanListBindingSource.Current != null)
            {
                DonHangBan _donHangBan = (DonHangBan)(donHangBanListBindingSource.Current);

                foreach (CT_DonHangBan ct_DonHangBan in _donHangBan.CT_DonHangBanList)
                {
                    if (ct_DonHangBan.MaHangHoa == MaHangHoa)
                    {
                        ct_DonNhanHangTra = CT_DonNhanHangTra.NewCT_DonNhanHangTra(ct_DonHangBan);
                        ct_DonNhanHangTra.MaDonHangBan = _donHangBan.MaDonHang;
                        break;
                    }
                }
            }
            this.Close();
        }

        #endregion 

        #region grdu_DanhSachDonHangBan_KeyDown
        private void grdu_DanhSachDonHangBan_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (donHangBanListBindingSource.Current != null)
                {
                    DonHangBan _donHangBan = (DonHangBan)(donHangBanListBindingSource.Current);

                    foreach (CT_DonHangBan ct_DonHangBan in _donHangBan.CT_DonHangBanList)
                    {
                        if (ct_DonHangBan.MaHangHoa == MaHangHoa)
                        {
                            ct_DonNhanHangTra = CT_DonNhanHangTra.NewCT_DonNhanHangTra(ct_DonHangBan);
                            ct_DonNhanHangTra.MaDonHangBan = _donHangBan.MaDonHang;
                            break;
                        }
                    }
                }
            }
        }
        #endregion 
    }
}