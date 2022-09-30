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
using ERP_Library;

namespace PSC_ERP
{
    public partial class frmThanhToanTienHangTuDaiLy : Form
    {
        long MaDoiTac = 0 ;
        DonHangBanList donHangBanList = DonHangBanList.NewDonHangBanList();

        #region Contructors
        public frmThanhToanTienHangTuDaiLy()
        {
            InitializeComponent();
            KhoiTao();
        }
        #endregion

        #region Khởi Tạo
        private void KhoiTao()
        {
            doiTacListBindingSource.DataSource = DoiTacList.GetDoiTacListTheoLoaiKhachHang(5);
            donHangBanListBindingSource.DataSource = donHangBanList;
            if (cb_DaiLy.SelectedItem != null)
            {
                MaDoiTac = ((DoiTac)(cb_DaiLy.SelectedItem)).MaDoiTac;
                khoListBindingSource.DataSource = KhoList.GetKhoList_KhoDaiLyByMaDaiLy(MaDoiTac);
            }
        }
        #endregion 

        #region grdu_DanhSachDonHangBan_InitializeLayout
        private void grdu_DanhSachDonHangBan_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
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
            //grdu_DanhSachDonHangBan.DisplayLayout.Bands[0].Columns["HangTraLai"].Header.Caption = "Trả Lại Hàng";
            //grdu_DanhSachDonHangBan.DisplayLayout.Bands[0].Columns["HangTraLai"].Hidden = false;
            this.grdu_DanhSachDonHangBan.DisplayLayout.Bands["CT_DonHangBanList"].Hidden = false;
            foreach (UltraGridColumn col in this.grdu_DanhSachDonHangBan.DisplayLayout.Bands["CT_DonHangBanList"].Columns)
            {
                col.Hidden = true;
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;//x =  //= System.Drawing.w;//RoyalBlue
            }
            //grdu_DanhSachDonHangBan.DisplayLayout.Bands["CT_DonHangBanList"].Columns["HangTraLai"].Hidden = false;
            //grdu_DanhSachDonHangBan.DisplayLayout.Bands["CT_DonHangBanList"].Columns["HangTraLai"].Header.Caption = "Hàng Trả Lại";
            //grdu_DanhSachDonHangBan.DisplayLayout.Bands["CT_DonHangBanList"].Columns["HangTraLai"].Header.VisiblePosition = 1;

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
        }
        #endregion 

        #region cb_DaiLy_SelectedValueChanged
        private void cb_DaiLy_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cb_DaiLy.SelectedItem != null)
            {
                MaDoiTac = ((DoiTac)(cb_DaiLy.SelectedItem)).MaDoiTac;
                khoListBindingSource.DataSource = KhoList.GetKhoList_KhoDaiLyByMaDaiLy(MaDoiTac);
            }
        }
        #endregion 

        #region crcyu_SoTien_KeyDown
        private void crcyu_SoTien_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (crcyu_SoTien.Value != 0)
                {
                    donHangBanList = DonHangBanList.GetDonHangBanBySoTienThanhToanList(Convert.ToDecimal(crcyu_SoTien.Value));
                }
                donHangBanListBindingSource.DataSource = donHangBanList;
            }
        }
        #endregion 

        #region tlslblLuu_Click
        private void tlslblLuu_Click(object sender, EventArgs e)
        {
            foreach (DonHangBan donHangBan in donHangBanList)
            {
                donHangBan.ThanhToan = 1;
            }
            try
            {
                donHangBanList.ApplyEdit();
                donHangBanList.Save();
                MessageBox.Show(this, "Cập nhật thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "Cập nhật không thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        #endregion 

        #region tlslblThem_Click
        private void tlslblThem_Click(object sender, EventArgs e)
        {
            KhoiTao();
        }
        #endregion 

        #region tlslblThoat_Click
        private void tlslblThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion 
    }
}