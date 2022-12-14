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
    public partial class frmDanhSachCongNhan : Form
    {
        #region Properties
        TenNhanVienList _TenNhanVienList;
        Util util = new Util();
        LoaiBoPhanList _LoaiBoPhanList;
        BoPhanList _BoPhanList;
        
        #endregion

        #region Contructor
        public frmDanhSachCongNhan()
        {
            InitializeComponent();
            KhoiTao();

            tlslblTim.Visible = false;
            toolStripSeparator4.Visible = false;

            tlslblLuu.Visible = false;
            toolStripSeparator2.Visible = false;

            tlslblXoa.Visible = false;
            toolStripSeparator3.Visible = false;

            tlslblIn.Visible = false;
            toolStripLabel1.Visible = false;
        }
        #endregion

        #region KhoiTao
        public void KhoiTao()
        {
            try
            {
                _LoaiBoPhanList = LoaiBoPhanList.GetLoaiBoPhanList();
                LoaiBoPhan_BindingSource.DataSource = _LoaiBoPhanList;
            }
            catch (ApplicationException)
            {

            }
        }
        #endregion

        #region Events 
        private void tlslblThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tlslblLamTuoi_Click(object sender, EventArgs e)
        {
            KhoiTao();
        }

        private void tlslblThem_Click(object sender, EventArgs e)
        {
            frmThongTinNhanVien f = new frmThongTinNhanVien();
            f.Show();
        }

        private void grdu_ThongTinNghiPhepNam_DoubleClick(object sender, EventArgs e)
        {
            NhanVien _NhanVien = NhanVien.GetNhanVien((long)grdu_ThongTinNghiPhepNam.ActiveRow.Cells["MaNhanVien"].Value);
            frmThongTinNhanVien _frmThongTinNhanVien = new frmThongTinNhanVien(_NhanVien);
            if (_frmThongTinNhanVien.ShowDialog(this) != DialogResult.OK)
            {
                if (_NhanVien != null)
                {
                    KhoiTao();
                }
            }
        }
        #endregion

        #region grdu_ThongTinNghiPhepNam_InitializeLayout
        private void grdu_ThongTinNghiPhepNam_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            //ti??u ????? Kh??ch H??ng
            grdu_ThongTinNghiPhepNam.DisplayLayout.Bands[0].Columns["CardID"].Hidden = true;
            grdu_ThongTinNghiPhepNam.DisplayLayout.Bands[0].Columns["MaChucVu"].Hidden = true;
            grdu_ThongTinNghiPhepNam.DisplayLayout.Bands[0].Columns["MaBoPhan"].Hidden = true;
            grdu_ThongTinNghiPhepNam.DisplayLayout.Bands[0].Columns["MaNoiCap"].Hidden = true;
            grdu_ThongTinNghiPhepNam.DisplayLayout.Bands[0].Columns["MaKiemNhiem"].Hidden = true;
            grdu_ThongTinNghiPhepNam.DisplayLayout.Bands[0].Columns["MaChucDanh"].Hidden = true;
            grdu_ThongTinNghiPhepNam.DisplayLayout.Bands[0].Columns["MaNoiSinh"].Hidden = true;
            grdu_ThongTinNghiPhepNam.DisplayLayout.Bands[0].Columns["MaTinhThanhQueQuan"].Hidden = true;
            grdu_ThongTinNghiPhepNam.DisplayLayout.Bands[0].Columns["QuocTich"].Hidden = true;
            grdu_ThongTinNghiPhepNam.DisplayLayout.Bands[0].Columns["MaDanToc"].Hidden = true;
            grdu_ThongTinNghiPhepNam.DisplayLayout.Bands[0].Columns["MaTonGiao"].Hidden = true;
            grdu_ThongTinNghiPhepNam.DisplayLayout.Bands[0].Columns["MaThanhPhanGD"].Hidden = true;
            grdu_ThongTinNghiPhepNam.DisplayLayout.Bands[0].Columns["ChieuCao"].Hidden = true;
            grdu_ThongTinNghiPhepNam.DisplayLayout.Bands[0].Columns["NhomMau"].Hidden = true;
            grdu_ThongTinNghiPhepNam.DisplayLayout.Bands[0].Columns["CanNang"].Hidden = true;
            grdu_ThongTinNghiPhepNam.DisplayLayout.Bands[0].Columns["MaUuTienGD"].Hidden = true;
            grdu_ThongTinNghiPhepNam.DisplayLayout.Bands[0].Columns["MaUuTienBanThan"].Hidden = true;
            grdu_ThongTinNghiPhepNam.DisplayLayout.Bands[0].Columns["MaNguoiLap"].Hidden = true;
            grdu_ThongTinNghiPhepNam.DisplayLayout.Bands[0].Columns["MaNganHang"].Hidden = true;
            grdu_ThongTinNghiPhepNam.DisplayLayout.Bands[0].Columns["TinhTrang"].Hidden = true;
            grdu_ThongTinNghiPhepNam.DisplayLayout.Bands[0].Columns["LoaiNV"].Hidden = true;
            grdu_ThongTinNghiPhepNam.DisplayLayout.Bands[0].Columns["MaQuanHuyenNoiSinh"].Hidden = true;
            grdu_ThongTinNghiPhepNam.DisplayLayout.Bands[0].Columns["MaQuanHuyenQueQuan"].Hidden = true;
            grdu_ThongTinNghiPhepNam.DisplayLayout.Bands[0].Columns["TenKiemNhiem"].Hidden = true;
            grdu_ThongTinNghiPhepNam.DisplayLayout.Bands[0].Columns["MaNhanVien"].Hidden = true;
            grdu_ThongTinNghiPhepNam.DisplayLayout.Bands[0].Columns["GioiTinh"].Hidden = true;
            grdu_ThongTinNghiPhepNam.DisplayLayout.Bands[0].Columns["MaCongViec"].Hidden = true;
            grdu_ThongTinNghiPhepNam.DisplayLayout.Bands[0].Columns["MaThangLuong"].Hidden = true;

            grdu_ThongTinNghiPhepNam.DisplayLayout.Bands[0].Columns["MaQLNhanVien"].Header.Caption = "M?? Nh??n Vi??n";
            grdu_ThongTinNghiPhepNam.DisplayLayout.Bands[0].Columns["TenNhanVien"].Header.Caption = "T??n Nh??n Vi??n";
            grdu_ThongTinNghiPhepNam.DisplayLayout.Bands[0].Columns["TenBoPhan"].Header.Caption = "T??n B??? Ph???n";
            grdu_ThongTinNghiPhepNam.DisplayLayout.Bands[0].Columns["TenChucVu"].Header.Caption = "T??n Ch???c V???";
            grdu_ThongTinNghiPhepNam.DisplayLayout.Bands[0].Columns["TenGioiTinh"].Header.Caption = "Gi???i T??nh";
            grdu_ThongTinNghiPhepNam.DisplayLayout.Bands[0].Columns["Cmnd"].Header.Caption = "CMND";
            grdu_ThongTinNghiPhepNam.DisplayLayout.Bands[0].Columns["NgayCap"].Header.Caption = "Ng??y C???p";
            grdu_ThongTinNghiPhepNam.DisplayLayout.Bands[0].Columns["NgaySinh"].Header.Caption = "Ng??y Sinh";
            grdu_ThongTinNghiPhepNam.DisplayLayout.Bands[0].Columns["NgayVaoNganh"].Header.Caption = "Ng??y V??o Ng??nh";
            grdu_ThongTinNghiPhepNam.DisplayLayout.Bands[0].Columns["NgayTinhThamNien"].Header.Caption = "Ng??nh T??nh Th??m Ni??n";
            grdu_ThongTinNghiPhepNam.DisplayLayout.Bands[0].Columns["LoaiSucKhoe"].Header.Caption = "Lo???i S???c Kh???e";
            grdu_ThongTinNghiPhepNam.DisplayLayout.Bands[0].Columns["NgayLap"].Header.Caption = "Ng??y L???p";
            grdu_ThongTinNghiPhepNam.DisplayLayout.Bands[0].Columns["SoTaiKhoan"].Header.Caption = "S??? T??i Kho???n";
            grdu_ThongTinNghiPhepNam.DisplayLayout.Bands[0].Columns["ThangLuong"].Header.Caption = "L????ng";

            grdu_ThongTinNghiPhepNam.DisplayLayout.Bands[0].Columns["MaQLNhanVien"].Header.VisiblePosition = 0;
            grdu_ThongTinNghiPhepNam.DisplayLayout.Bands[0].Columns["TenNhanVien"].Header.VisiblePosition = 1;
            grdu_ThongTinNghiPhepNam.DisplayLayout.Bands[0].Columns["TenBoPhan"].Header.VisiblePosition = 2;
            grdu_ThongTinNghiPhepNam.DisplayLayout.Bands[0].Columns["TenChucVu"].Header.VisiblePosition = 3;
            grdu_ThongTinNghiPhepNam.DisplayLayout.Bands[0].Columns["TenGioiTinh"].Header.VisiblePosition = 4;
            grdu_ThongTinNghiPhepNam.DisplayLayout.Bands[0].Columns["Cmnd"].Header.VisiblePosition = 5;
            grdu_ThongTinNghiPhepNam.DisplayLayout.Bands[0].Columns["NgayCap"].Header.VisiblePosition = 6;
            grdu_ThongTinNghiPhepNam.DisplayLayout.Bands[0].Columns["NgaySinh"].Header.VisiblePosition = 7;
            grdu_ThongTinNghiPhepNam.DisplayLayout.Bands[0].Columns["NgayVaoNganh"].Header.VisiblePosition = 8;
            grdu_ThongTinNghiPhepNam.DisplayLayout.Bands[0].Columns["NgayTinhThamNien"].Header.VisiblePosition = 9;
            grdu_ThongTinNghiPhepNam.DisplayLayout.Bands[0].Columns["LoaiSucKhoe"].Header.VisiblePosition = 10;
            grdu_ThongTinNghiPhepNam.DisplayLayout.Bands[0].Columns["NgayLap"].Header.VisiblePosition = 11;
            grdu_ThongTinNghiPhepNam.DisplayLayout.Bands[0].Columns["SoTaiKhoan"].Header.VisiblePosition = 12;
            grdu_ThongTinNghiPhepNam.DisplayLayout.Bands[0].Columns["ThangLuong"].Header.VisiblePosition = 13;

            grdu_ThongTinNghiPhepNam.DisplayLayout.Bands[0].Columns["MaQLNhanVien"].Width = 80;

            //m??u v?? font ch???
            foreach (UltraGridColumn col in this.grdu_ThongTinNghiPhepNam.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;
                col.CellActivation = Activation.NoEdit;
                if (col.DataType.ToString() == "System.DateTime")
                {
                    col.Format = "dd/MM/yyyy";
                }
            }

            //m??u n???n
            //this.grdu_ThongTinNghiPhepNam.DisplayLayout.Override.HeaderAppearance.BackColor = System.Drawing.Color.SteelBlue;
            //this.grdu_ThongTinNghiPhepNam.DisplayLayout.Override.HeaderStyle = HeaderStyle.WindowsXPCommand;
        }
        #endregion

        private void btn_Xem_Click(object sender, EventArgs e)
        {
            int MaBoPhan = 0;
            if (cmbu_BoPhan.Value != null)
            {
                if ((int)cmbu_BoPhan.Value != 0)
                {
                    MaBoPhan = (int)cmbu_BoPhan.Value;
                }
            }
            try
            {
                _TenNhanVienList = TenNhanVienList.GetTenNhanVienList_BoPhan(MaBoPhan);
                TenNhanVien_BindingSource.DataSource = _TenNhanVienList;
            }
            catch (ApplicationException)
            {

            }
            lbl_TongSo.Text = "S??? l?????ng c??ng nh??n: " + _TenNhanVienList.Count;
            if (_TenNhanVienList.Count == 0)
            {
                MessageBox.Show("Kh??ng c?? d??? li???u.", util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void cmbu_LoaiBoPhan_ValueChanged(object sender, EventArgs e)
        {
            int MaLoaiBoPhan = 0;
            if (cmbu_LoaiBoPhan.Value != null)
            {
                MaLoaiBoPhan = (int)cmbu_LoaiBoPhan.Value;
                _BoPhanList = BoPhanList.GetBoPhanList_LoaiBoPhan(MaLoaiBoPhan);
                BoPhan_BindingSource.DataSource = _BoPhanList;
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {

        }

        private void tlslblTim_Click(object sender, EventArgs e)
        {

        }
    }
}