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

namespace PSC_ERP
{
    public partial class frmBangBaoGia : Form
    {
        #region Properties
        DoiTacList _DoiTacList;
        BangBaoGia _BangBaoGia;
        BangBaoGiaList _BangBaoGiaList;
        HangHoaList _HangHoaList;
        DonViTinhList _DonViTinhList;
        #endregion

        #region Events
        public frmBangBaoGia()
        {
            InitializeComponent();
        }

        private void LayDuLieuLenLuoi()
        {
            _DoiTacList = DoiTacList.GetDoiTacList(false);
            DoiTacBindingSource.DataSource = _DoiTacList;
            _BangBaoGia = BangBaoGia.NewBangBaoGia();
            BangBaoGiaBindingSource.DataSource = _BangBaoGia;
            CT_BaoGiaBindingSource.DataSource = _BangBaoGia.CT_BaoGiaList;
            _HangHoaList = HangHoaList.GetHangHoaList(0,0);
            HangHoaBindingSource.DataSource = _HangHoaList;
            _DonViTinhList = DonViTinhList.GetDonViTinhList();
            DonViTinhBindingSource.DataSource = _DonViTinhList;
            ultracmbKhachHang.Text = "Chọn khách hàng";
            _BangBaoGiaList = BangBaoGiaList.GetBangBaoGiaList();
            BangBaoGiaListBindingSource.DataSource = _BangBaoGiaList;
        }

        private void frmBangBaoGia_Load(object sender, EventArgs e)
        {
            LayDuLieuLenLuoi();
        }

        private void Them_Click(object sender, EventArgs e)
        {
            _BangBaoGia = BangBaoGia.NewBangBaoGia();
            BangBaoGiaBindingSource.DataSource = _BangBaoGia;
        }

        private void Luu_Click(object sender, EventArgs e)
        {
            _BangBaoGia.ApplyEdit();
            
            _BangBaoGia.Save();
            MessageBox.Show(this, "Cập Nhật Thành Công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            BangBaoGiaListBindingSource.DataSource = _BangBaoGiaList;
        }

        private void ultragrdDSBangbaoGia_DoubleClick(object sender, EventArgs e)
        {
            _BangBaoGia = (BangBaoGia)BangBaoGiaListBindingSource.Current;
            BangBaoGiaBindingSource.DataSource = _BangBaoGia;
            CT_BaoGiaBindingSource.DataSource = _BangBaoGia.CT_BaoGiaList;
            tabControl_BangBaoGia.SelectedIndex = 0;
        }
        #endregion

        #region InitializeLayout
        private void ultragrdBangBaoGia_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            HamDungChung q = new HamDungChung();
            q.ultragrdEmail_InitializeLayout(sender, e);

            ultragrdBangBaoGia.DisplayLayout.Bands[0].Columns["MaBangBaoGia"].Hidden = true;
            ultragrdBangBaoGia.DisplayLayout.Bands[0].Columns["MactBaoGia"].Hidden = true;

            ultragrdBangBaoGia.DisplayLayout.Bands[0].Columns["MaHangHoa"].Header.Caption = "Hàng Hóa";
            ultragrdBangBaoGia.DisplayLayout.Bands[0].Columns["MaHangHoa"].Width = 340;
            ultragrdBangBaoGia.DisplayLayout.Bands[0].Columns["MaHangHoa"].EditorComponent = ultracmbHangHoa;

            ultragrdBangBaoGia.DisplayLayout.Bands[0].Columns["MaDonViTinh"].Header.Caption = "Đơn Vị Tính";
            ultragrdBangBaoGia.DisplayLayout.Bands[0].Columns["MaDonViTinh"].Width = 120;
            ultragrdBangBaoGia.DisplayLayout.Bands[0].Columns["MaDonViTinh"].EditorComponent = ultracmbDonViTinh;

            ultragrdBangBaoGia.DisplayLayout.Bands[0].Columns["DonGia"].Header.Caption = "Đơn Giá";
            ultragrdBangBaoGia.DisplayLayout.Bands[0].Columns["DonGia"].Width = 120;

            ultragrdBangBaoGia.DisplayLayout.Bands[0].Columns["Vat"].Header.Caption = "VAT";
            ultragrdBangBaoGia.DisplayLayout.Bands[0].Columns["Vat"].Width = 95;

            this.ultragrdBangBaoGia.DisplayLayout.Override.HeaderAppearance.BackColor = System.Drawing.Color.SteelBlue;//appearance17;

            foreach (UltraGridColumn col in this.ultragrdBangBaoGia.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;//x =  //= System.Drawing.w;//RoyalBlue
            }
        }

        private void ultracmbKhachHang_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            ultracmbKhachHang.DisplayLayout.Bands[0].Columns["MaDoiTac"].Hidden = true;
            ultracmbKhachHang.DisplayLayout.Bands[0].Columns["KhachHang"].Hidden = true;
            ultracmbKhachHang.DisplayLayout.Bands[0].Columns["NhaCungCap"].Hidden = true;
            ultracmbKhachHang.DisplayLayout.Bands[0].Columns["LoaiDoitac"].Hidden = true;
            ultracmbKhachHang.DisplayLayout.Bands[0].Columns["DienGiai"].Hidden = true;
            ultracmbKhachHang.DisplayLayout.Bands[0].Columns["TinhTrang"].Hidden = true;
            ultracmbKhachHang.DisplayLayout.Bands[0].Columns["MaQLDoiTac"].Header.Caption = "Mã Khách Hàng";
            ultracmbKhachHang.DisplayLayout.Bands[0].Columns["TenDoitac"].Header.Caption = "Tên Khách Hàng";
            ultracmbKhachHang.DisplayLayout.Bands[0].Columns["TenVietTat"].Header.Caption = "Tên Viết Tắt";
            ultracmbKhachHang.DisplayLayout.Bands[0].Columns["MaSoThue"].Header.Caption= "Mã Số Thuế";

            this.ultracmbKhachHang.DisplayLayout.Override.HeaderAppearance.BackColor = System.Drawing.Color.SteelBlue;//appearance17;
            this.ultragrdBangBaoGia.DisplayLayout.Override.HeaderStyle = HeaderStyle.WindowsXPCommand;
            foreach (UltraGridColumn col in this.ultracmbKhachHang.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = Color.Navy;//x =  //= System.Drawing.w;//RoyalBlue
            }
        }

        private void ultracmbHangHoa_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            ultracmbHangHoa.DisplayLayout.Bands[0].Columns["MaHangHoa"].Hidden = true;
            ultracmbHangHoa.DisplayLayout.Bands[0].Columns["MaLoaiHangHoa"].Hidden = true;
            ultracmbHangHoa.DisplayLayout.Bands[0].Columns["MaDonViTinh"].Hidden = true;
            ultracmbHangHoa.DisplayLayout.Bands[0].Columns["MaXuatXu"].Hidden = true;
            ultracmbHangHoa.DisplayLayout.Bands[0].Columns["MaThuocTinh"].Hidden = true;
            ultracmbHangHoa.DisplayLayout.Bands[0].Columns["MaMucThue"].Hidden = true;
            ultracmbHangHoa.DisplayLayout.Bands[0].Columns["DienGiai"].Hidden = true;
            ultracmbHangHoa.DisplayLayout.Bands[0].Columns["Active"].Hidden = true;

            ultracmbHangHoa.DisplayLayout.Bands[0].Columns["MaQLHangHoa"].Header.Caption = "Mã Hàng Hóa";
            ultracmbHangHoa.DisplayLayout.Bands[0].Columns["TenHangHoa"].Header.Caption = "Tên Hàng Hóa";
            ultracmbHangHoa.DisplayLayout.Bands[0].Columns["GiaHienTai"].Header.Caption = "Giá Hiện tại";

            ultracmbHangHoa.DisplayLayout.Override.HeaderAppearance.BackColor = Color.SteelBlue;
            this.ultracmbHangHoa.DisplayLayout.Override.HeaderStyle = HeaderStyle.WindowsXPCommand;
            foreach (UltraGridColumn col in this.ultracmbHangHoa.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = Color.Navy;//x =  //= System.Drawing.w;//RoyalBlue
            }
        }

        private void ultracmbDonViTinh_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            ultracmbDonViTinh.DisplayLayout.Bands[0].Columns["MaDonViTinh"].Hidden = true;
            ultracmbDonViTinh.DisplayLayout.Bands[0].Columns["MaDVTQL"].Header.Caption = "Mã Đơn Vị Tính";
            ultracmbDonViTinh.DisplayLayout.Bands[0].Columns["TenDonViTinh"].Header.Caption = "Tên Đơn Vị Tính";

            ultracmbDonViTinh.DisplayLayout.Override.HeaderAppearance.BackColor = Color.SteelBlue;
            this.ultracmbDonViTinh.DisplayLayout.Override.HeaderStyle = HeaderStyle.WindowsXPCommand;

            foreach (UltraGridColumn col in this.ultracmbDonViTinh.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = Color.Navy;//x =  //= System.Drawing.w;//RoyalBlue
            }
        }
        
        private void ultragrdDSBangbaoGia_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            ultragrdDSBangbaoGia.DisplayLayout.Bands[1].Hidden = true;
            ultragrdDSBangbaoGia.DisplayLayout.Bands[0].Columns["MaBangBaoGia"].Hidden = true;
            ultragrdDSBangbaoGia.DisplayLayout.Bands[0].Columns["MaKhachHang"].Hidden = true;
            ultragrdDSBangbaoGia.DisplayLayout.Bands[0].Columns["TenKhachHang"].Header.Caption = "Khách Hàng";
            ultragrdDSBangbaoGia.DisplayLayout.Bands[0].Columns["TenKhachHang"].Width = 250;
            ultragrdDSBangbaoGia.DisplayLayout.Bands[0].Columns["NoiDung"].Header.Caption = "Tên Bảng Báo Giá";
            ultragrdDSBangbaoGia.DisplayLayout.Bands[0].Columns["NoiDung"].Width = 250;
            ultragrdDSBangbaoGia.DisplayLayout.Bands[0].Columns["NgayLap"].Header.Caption = "Ngày Lập";
            ultragrdDSBangbaoGia.DisplayLayout.Bands[0].Columns["NgayLap"].Width = 95;

            this.ultragrdDSBangbaoGia.DisplayLayout.Override.HeaderAppearance.BackColor = Color.SteelBlue;
            this.ultragrdDSBangbaoGia.DisplayLayout.Override.HeaderStyle = HeaderStyle.WindowsXPCommand;
            foreach (UltraGridColumn col in this.ultragrdDSBangbaoGia.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;
            }
        }
        #endregion
    }
}
