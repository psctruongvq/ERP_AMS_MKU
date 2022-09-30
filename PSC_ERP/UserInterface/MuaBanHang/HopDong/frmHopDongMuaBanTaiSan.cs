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
using CrystalDecisions.CrystalReports.Engine;
using System.Data.SqlClient;


namespace PSC_ERP
{
    public partial class frmHopDongMuaBanTaiSan : Form
    {
        #region Properties

        DoiTacList _DoiTacList;
        DoiTac _DoiTac;           
        HopDongMuaBan _HopDongMuaBan ;
        TaiSanCoDinhList _taiSanCoDinhList=TaiSanCoDinhList.NewTaiSanCoDinhList();
        TaiSanCoDinh _taiSanCoDinh;
        DonViTinhList _DonViTinhList;       
        
        HamDungChung t = new HamDungChung();
        private short _loai;
        Util util = new Util();
        
        #endregion

        #region Contructor
        public frmHopDongMuaBanTaiSan()
        {
            InitializeComponent();
            KhaiBaoSuKien();
            Invisible();
            Them();
            KhoiTao();  
        }

         public frmHopDongMuaBanTaiSan(short loai)
        {
            InitializeComponent();
             KhaiBaoSuKien();
            Invisible();
            Them(loai);
            KhoiTao();
        }

        public frmHopDongMuaBanTaiSan(HopDongMuaBan HopDongMuaBan)
        {
            InitializeComponent();
            KhaiBaoSuKien();
            Invisible();
            KhoiTao(HopDongMuaBan);
        }
        #endregion
       
        #region Khởi Tạo

        private void KhoiTao()
        {

            tenNhanVienListBindingSource.DataSource = TenNhanVienList.GetTenNhanVienList();

            loaiTaiSanListBindingSource.DataSource = LoaiTaiSanList.GetLoaiTaiSanList();

            phuongThucThanhToanListBindingSource.DataSource = PhuongThucThanhToanList.GetPhuongThucThanhToanList();            

            doiTacListBindingSource.DataSource = DoiTacList.GetDoiTacList(false);

            loaiTienListBindingSource.DataSource = LoaiTienList.GetLoaiTienList();

            loaiTienListBindingSource1.DataSource = LoaiTienList.GetLoaiTienList();

            donViTinhListBindingSource.DataSource = DonViTinhList.GetDonViTinhList();

            loaiHopDongListBindingSource.DataSource = LoaiHopDongList.GetLoaiHopDongList();

        }

        private void Them(short loai)
        {
            _HopDongMuaBan = HopDongMuaBan.NewHopDongMuaBan();
            _HopDongMuaBan.MaLoaiHopDong = loai;
            _HopDongMuaBan.SoHopDong = HopDongMuaBan.SoHopDongTuDongTang(loai, false);
            hopDongMuaBanBindingSource.DataSource = _HopDongMuaBan;
            
            cTMuaBanTSCDListBindingSource.DataSource = _HopDongMuaBan.CT_MuaBanTSCDList;           
            dotThanhToanHDMBListBindingSource.DataSource = _HopDongMuaBan.DotThanhToanHDMBList;
            _loai = loai;         
            
        }
        private void Them()
        {
            _HopDongMuaBan = HopDongMuaBan.NewHopDongMuaBan();
            _HopDongMuaBan.MaLoaiHopDong = 6;
            _HopDongMuaBan.SoHopDong = HopDongMuaBan.SoHopDongTuDongTang(6, false);
            hopDongMuaBanBindingSource.DataSource = _HopDongMuaBan;
            cTMuaBanTSCDListBindingSource.DataSource = _HopDongMuaBan.CT_MuaBanTSCDList;            
            dotThanhToanHDMBListBindingSource.DataSource = _HopDongMuaBan.DotThanhToanHDMBList;
            
        }
        private void KhoiTao(HopDongMuaBan hopDongMuaBan)
        {
            _HopDongMuaBan = hopDongMuaBan;

            hopDongMuaBanBindingSource.DataSource = _HopDongMuaBan;

            cTMuaBanTSCDListBindingSource.DataSource = _HopDongMuaBan.CT_MuaBanTSCDList;
            
            dotThanhToanHDMBListBindingSource.DataSource = _HopDongMuaBan.DotThanhToanHDMBList;

            tenNhanVienListBindingSource.DataSource = TenNhanVienList.GetTenNhanVienList();            

            loaiTaiSanListBindingSource.DataSource = LoaiHangHoaList.GetLoaiHangHoaList(0);

            phuongThucThanhToanListBindingSource.DataSource = PhuongThucThanhToanList.GetPhuongThucThanhToanList();            

            doiTacListBindingSource.DataSource = DoiTacList.GetDoiTacList(false);
            donViTinhListBindingSource.DataSource = DonViTinhList.GetDonViTinhList();
            loaiTienListBindingSource.DataSource = LoaiTienList.GetLoaiTienList();
            loaiTienListBindingSource1.DataSource = LoaiTienList.GetLoaiTienList();
            loaiHopDongListBindingSource.DataSource = LoaiHopDongList.GetLoaiHopDongList();

        }

        #endregion       

        #region Khai Báo Sự Kiện
        private void KhaiBaoSuKien()
        {
            t.EventForm(this);
            t.EventGrid(grdu_ChiTietHopDong);
            t.EventGrid(grdu_DotThanhToan);            
        }

        #endregion 

        #region Invisible Button
        private void Invisible()
        {
            tlslblXoa.Available = false;
            tlslblUndo.Available = false;
            //tlslblTim.Available = false;
            toolStripButton1.Visible = false;
            //toolStripLabel1.Visible = false;
            toolStripSeparator3.Visible = false;
            toolStripSeparator4.Visible = false;
            tlslblTroGiup.Available = false;
        }
        #endregion 

        #region Kiểm Tra Dữ Liệu Trước Khi Lưu
        private bool KiemTraDuLieu()
        {
            bool kq = true;
            if (cmbeu_LoaiHopDong.Value == null)
            {
                MessageBox.Show(this, util.LoaiHopDong, util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbeu_LoaiHopDong.Focus();
                return false;
            }
            else if (txtu_SoHopDong.Text == string.Empty)
            {
               MessageBox.Show(this, util.SoHopDong, util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtu_SoHopDong.Focus();
                return false;
            }
            else if (_HopDongMuaBan.CT_MuaBanTSCDList.Count == 0)
            {
                MessageBox.Show(this, "Vui Lòng Nhập Chi Tiết Hợp Đồng", util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                
                return false;
            }
            
            else if (_HopDongMuaBan.MaNguoiKy == 0)
            {
                MessageBox.Show(this, "Vui Chọn Người Đại Diện", util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbu_NguoiDaiDien.Focus();
                return false;
            }
            //else if (_HopDongMuaBan.IsNew == true && HopDongMuaBan.KiemTraSoHopDongTonTai(txtu_SoHopDong.Text.Trim(), _HopDongMuaBan.Loai) == false)
            //{
            //    MessageBox.Show(this, util.sohopdongbitrung, util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    txtu_SoHopDong.Focus();
            //    return false;
            //}
            return kq;

        }
        #endregion

        #region Lưu Dữ Liệu

        private bool LuuDuLieu()
        {
            bool kq = true;
            try
            {
                _HopDongMuaBan.ApplyEdit();
                _HopDongMuaBan.Save();
            }
            catch (Exception ex)
            {
                kq = false;
            }
            return kq;
        }

        #endregion          

        #region tlslblLuu_Click
        private void tlslblLuu_Click(object sender, EventArgs e)
        {
            if (KiemTraDuLieu() == true)
            {
                //double tong = (double)(this.ultranueTongTien.Value);
                if (MessageBox.Show(this, "Bạn Muốn Lưu Dữ Liệu", "Thông Báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
                {
                    if (LuuDuLieu() == true)
                    {
                        MessageBox.Show(this, "Cập Nhật Thành Công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else MessageBox.Show(this, "Cập Nhật Không Thành Công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
           
        }
        #endregion

        #region tlslblThoat_Click
        private void tlslblThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region tlslblThem_Click
        private void tlslblThem_Click(object sender, EventArgs e)
        {
            Them(_loai);
        }
        #endregion

        #region InitiazeLayout

        #region ultracmbKhachHang_InitializeLayout
        private void ultracmbKhachHang_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            cmbu_KhachHang.DisplayLayout.Bands[0].Columns["MaDoiTac"].Hidden = true;
            cmbu_KhachHang.DisplayLayout.Bands[0].Columns["KhachHang"].Hidden = true;
            cmbu_KhachHang.DisplayLayout.Bands[0].Columns["NhaCungCap"].Hidden = true;
            cmbu_KhachHang.DisplayLayout.Bands[0].Columns["LoaiDoitac"].Hidden = true;
            cmbu_KhachHang.DisplayLayout.Bands[0].Columns["DienGiai"].Hidden = true;
            cmbu_KhachHang.DisplayLayout.Bands[0].Columns["TinhTrang"].Hidden = true;
            cmbu_KhachHang.DisplayLayout.Bands[0].Columns["MaQLDoiTac"].Header.Caption = "Mã KH";
            cmbu_KhachHang.DisplayLayout.Bands[0].Columns["MaQLDoiTac"].Width = 80;
            
            cmbu_KhachHang.DisplayLayout.Bands[0].Columns["TenDoitac"].Header.Caption = "Tên Khách Hàng";
            cmbu_KhachHang.DisplayLayout.Bands[0].Columns["TenDoitac"].Width = 150;

            cmbu_KhachHang.DisplayLayout.Bands[0].Columns["TenVietTat"].Header.Caption = "Tên Viết Tắt";
            cmbu_KhachHang.DisplayLayout.Bands[0].Columns["TenVietTat"].Width = 80;

            cmbu_KhachHang.DisplayLayout.Bands[0].Columns["MaSoThue"].Header.Caption = "Mã Số Thuế";

            this.cmbu_KhachHang.DisplayLayout.Override.HeaderAppearance.BackColor = System.Drawing.Color.SteelBlue;//appearance17;
            this.cmbu_KhachHang.DisplayLayout.Override.HeaderStyle = HeaderStyle.WindowsXPCommand;
            
            foreach (UltraGridColumn col in this.cmbu_KhachHang.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = Color.Navy;
            }
        }
        #endregion     

        #region ultracmbDonViTinh_InitializeLayout
        private void ultracmbDonViTinh_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {      
            

            cmbu_DonViTinh.DisplayLayout.Override.HeaderAppearance.BackColor = Color.SteelBlue;
            this.cmbu_DonViTinh.DisplayLayout.Override.HeaderStyle = HeaderStyle.WindowsXPCommand;

            foreach (UltraGridColumn col in this.cmbu_DonViTinh.DisplayLayout.Bands[0].Columns)
            {
                col.Hidden = true;
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = Color.Navy;
            }

            cmbu_DonViTinh.DisplayLayout.Bands[0].Columns["MaQuanLy"].Hidden = false;
            cmbu_DonViTinh.DisplayLayout.Bands[0].Columns["MaQuanLy"].Header.Caption = "Mã DVT";
            cmbu_DonViTinh.DisplayLayout.Bands[0].Columns["MaQuanLy"].Header.VisiblePosition = 0;

            cmbu_DonViTinh.DisplayLayout.Bands[0].Columns["TenDonViTinh"].Hidden = false;
            cmbu_DonViTinh.DisplayLayout.Bands[0].Columns["TenDonViTinh"].Header.Caption = "Tên Đơn Vị Tính";
            cmbu_DonViTinh.DisplayLayout.Bands[0].Columns["TenDonViTinh"].Header.VisiblePosition = 1;
        }
        #endregion
                
        #region ultragrdKyHanThanhToan_InitializeLayout
        private void ultragrdKyHanThanhToan_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            t.ultragrdEmail_InitializeLayout(sender, e);

            grdu_DotThanhToan.DisplayLayout.Bands[0].Columns["MaDotThanhToan"].Hidden = true;
            grdu_DotThanhToan.DisplayLayout.Bands[0].Columns["MaHopDongMuaBan"].Hidden = true;

            grdu_DotThanhToan.DisplayLayout.Bands[0].Columns["NgayThanhToan"].Header.Caption = "Ngày Thanh Toán";
            grdu_DotThanhToan.DisplayLayout.Bands[0].Columns["NgayThanhToan"].MaskInput = "{LOC}dd/mm/yyyy";
            grdu_DotThanhToan.DisplayLayout.Bands[0].Columns["NgayThanhToan"].Format = "dd/MM/yyyy";

            grdu_DotThanhToan.DisplayLayout.Bands[0].Columns["MaPhuongThucThanhToan"].Header.Caption = "Phương Thức Thanh Toán";
            grdu_DotThanhToan.DisplayLayout.Bands[0].Columns["MaPhuongThucThanhToan"].EditorControl = cmbu_PTThanhToan;
            grdu_DotThanhToan.DisplayLayout.Bands[0].Columns["MaPhuongThucThanhToan"].Width = 150;
            
            grdu_DotThanhToan.DisplayLayout.Bands[0].Columns["MaTaiKhoanDoiTac"].Header.Caption = "Tài Khoản Ngân Hàng";
            grdu_DotThanhToan.DisplayLayout.Bands[0].Columns["MaTaiKhoanDoiTac"].EditorControl = cmbu_TaiKhoanDoiTac;
            grdu_DotThanhToan.DisplayLayout.Bands[0].Columns["MaTaiKhoanDoiTac"].MaskInput = "nnnnnnnnn";

            grdu_DotThanhToan.DisplayLayout.Bands[0].Columns["MaLoaiTien"].Header.Caption = "Loại Tiền";
            grdu_DotThanhToan.DisplayLayout.Bands[0].Columns["MaLoaiTien"].EditorControl = cmbu_LoaiTienThanhToan;

            grdu_DotThanhToan.DisplayLayout.Bands[0].Columns["SoTien"].Header.Caption = "Số Tiền";
            grdu_DotThanhToan.DisplayLayout.Bands[0].Columns["SoTien"].MaskInput = "{LOC}nnn,nnn,nnn,nnn.nn";
            grdu_DotThanhToan.DisplayLayout.Bands[0].Columns["SoTien"].Format= "###,###,###,###,###";

            grdu_DotThanhToan.DisplayLayout.Bands[0].Columns["MaTaiKhoanCongTy"].Hidden = true;
            
            grdu_DotThanhToan.DisplayLayout.Override.HeaderAppearance.BackColor = Color.SteelBlue;
            this.grdu_DotThanhToan.DisplayLayout.Override.HeaderStyle = HeaderStyle.WindowsXPCommand;

            foreach (UltraGridColumn col in this.grdu_DotThanhToan.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = Color.Navy;
            }

        }
        #endregion
        
        #region ultracmbNguoiLienLac_InitializeLayout
        private void ultracmbNguoiLienLac_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            cmbu_NguoiLienLac.DisplayLayout.Bands[0].Columns["MaNguoiLienLac"].Hidden = true;
            cmbu_NguoiLienLac.DisplayLayout.Bands[0].Columns["MaDoitac"].Hidden = true;
            
            cmbu_NguoiLienLac.DisplayLayout.Bands[0].Columns["TenNguoiLienLac"].Header.Caption = "Tên Người Liên Lạc";
            cmbu_NguoiLienLac.DisplayLayout.Bands[0].Columns["TenNguoiLienLac"].Width = 200;

            cmbu_NguoiLienLac.DisplayLayout.Bands[0].Columns["DienThoai"].Header.Caption = "Điện Thoại";

            cmbu_NguoiLienLac.DisplayLayout.Override.HeaderAppearance.BackColor = Color.SteelBlue;
            this.cmbu_NguoiLienLac.DisplayLayout.Override.HeaderStyle = HeaderStyle.WindowsXPCommand;

            foreach (UltraGridColumn col in this.cmbu_NguoiLienLac.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = Color.Navy;
            }
        }
        #endregion         
       
        #region ultracmbPTThanhToan_InitializeLayout
        private void cmbu_PTThanhToan_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            cmbu_PTThanhToan.DisplayLayout.Bands[0].Columns["MaPhuongThucThanhToan"].Hidden = true;

            cmbu_PTThanhToan.DisplayLayout.Bands[0].Columns["MaQuanLyPTTT"].Header.Caption = "Mã Phương Thức";
            cmbu_PTThanhToan.DisplayLayout.Bands[0].Columns["MaQuanLyPTTT"].Width = 100;
            cmbu_PTThanhToan.DisplayLayout.Bands[0].Columns["MaQuanLyPTTT"].Header.VisiblePosition = 1;

            cmbu_PTThanhToan.DisplayLayout.Bands[0].Columns["TenPhuongThucThanhToan"].Header.Caption = "Tên Phương Thức";
            cmbu_PTThanhToan.DisplayLayout.Bands[0].Columns["TenPhuongThucThanhToan"].Header.VisiblePosition = 2;
            cmbu_PTThanhToan.DisplayLayout.Bands[0].Columns["TenPhuongThucThanhToan"].Width = 200;

            cmbu_PTThanhToan.DisplayLayout.Override.HeaderAppearance.BackColor = Color.SteelBlue;
            cmbu_PTThanhToan.DisplayLayout.Override.HeaderStyle = HeaderStyle.WindowsXPCommand;

            foreach (UltraGridColumn col in this.cmbu_PTThanhToan.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = Color.Navy;
            }
        }
        #endregion

        #region ultcbLoaiTien_InitializeLayout
        private void ultcbLoaiTien_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            cmbu_LoaiTien.DisplayLayout.Bands[0].Columns["MaLoaiTien"].Hidden = true;
            cmbu_LoaiTien.DisplayLayout.Bands[0].Columns["TiGiaQuyDoi"].Header.Caption = "Tỷ Giá Quy Đổi";
            cmbu_LoaiTien.DisplayLayout.Bands[0].Columns["TiGiaQuyDoi"].Header.VisiblePosition = 3;
            cmbu_LoaiTien.DisplayLayout.Bands[0].Columns["TenLoaiTien"].Header.Caption = "Tên Loại Tiền";
            cmbu_LoaiTien.DisplayLayout.Bands[0].Columns["TenLoaiTien"].Header.VisiblePosition = 2;
            cmbu_LoaiTien.DisplayLayout.Bands[0].Columns["MaLoaiQuanLy"].Header.Caption = "Mã Quản Lý";
            cmbu_LoaiTien.DisplayLayout.Bands[0].Columns["MaLoaiQuanLy"].Header.VisiblePosition = 1;
            this.cmbu_LoaiTien.DisplayLayout.Override.HeaderStyle = HeaderStyle.WindowsXPCommand;
            this.cmbu_LoaiTien.DisplayLayout.Override.HeaderAppearance.BackColor = System.Drawing.Color.SteelBlue;
            foreach (UltraGridColumn col in this.cmbu_LoaiTien.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;//x =  //= System.Drawing.w;//RoyalBlue
            }
        }
        #endregion
       
        #region ultcbLoaiTienThanhToan_InitializeLayout
        private void ultcbLoaiTienThanhToan_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {

            cmbu_LoaiTienThanhToan.DisplayLayout.Bands[0].Columns["MaLoaiTien"].Hidden = true;
            cmbu_LoaiTienThanhToan.DisplayLayout.Bands[0].Columns["TiGiaQuyDoi"].Header.Caption = "Tỷ Giá Quy Đổi";
            cmbu_LoaiTienThanhToan.DisplayLayout.Bands[0].Columns["TiGiaQuyDoi"].Header.VisiblePosition = 3;
            cmbu_LoaiTienThanhToan.DisplayLayout.Bands[0].Columns["TenLoaiTien"].Header.Caption = "Tên Loại Tiền";
            cmbu_LoaiTienThanhToan.DisplayLayout.Bands[0].Columns["TenLoaiTien"].Header.VisiblePosition = 2;
            cmbu_LoaiTienThanhToan.DisplayLayout.Bands[0].Columns["MaLoaiQuanLy"].Header.Caption = "Mã Quản Lý";
            cmbu_LoaiTienThanhToan.DisplayLayout.Bands[0].Columns["MaLoaiQuanLy"].Header.VisiblePosition = 1;
            this.cmbu_LoaiTienThanhToan.DisplayLayout.Override.HeaderStyle = HeaderStyle.WindowsXPCommand;
            this.cmbu_LoaiTienThanhToan.DisplayLayout.Override.HeaderAppearance.BackColor = System.Drawing.Color.SteelBlue;
            foreach (UltraGridColumn col in this.cmbu_LoaiTienThanhToan.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;//x =  //= System.Drawing.w;//RoyalBlue
            }
        }
        #endregion
      
        #region cmbu_NguoiDaiDien_InitializeLayout
        private void cmbu_NguoiDaiDien_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            this.cmbu_NguoiDaiDien.DisplayLayout.Override.HeaderStyle = HeaderStyle.WindowsXPCommand;
            this.cmbu_NguoiDaiDien.DisplayLayout.Override.HeaderAppearance.BackColor = System.Drawing.Color.SteelBlue;
            foreach (UltraGridColumn col in this.cmbu_NguoiDaiDien.DisplayLayout.Bands[0].Columns)
            {
                col.Hidden = true;
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;//x =  //= System.Drawing.w;//RoyalBlue
            }
            cmbu_NguoiDaiDien.DisplayLayout.Bands[0].Columns["MaQLNhanVien"].Hidden = false;
            cmbu_NguoiDaiDien.DisplayLayout.Bands[0].Columns["MaQLNhanVien"].Header.Caption = "Mã Nhân Viên";
            cmbu_NguoiDaiDien.DisplayLayout.Bands[0].Columns["MaQLNhanVien"].Header.VisiblePosition = 1;
            cmbu_NguoiDaiDien.DisplayLayout.Bands[0].Columns["TenNhanVien"].Hidden = false;
            cmbu_NguoiDaiDien.DisplayLayout.Bands[0].Columns["TenNhanVien"].Header.Caption = "Tên Nhân Viên";
            cmbu_NguoiDaiDien.DisplayLayout.Bands[0].Columns["TenNhanVien"].Header.VisiblePosition = 2;
            cmbu_NguoiDaiDien.DisplayLayout.Bands[0].Columns["TenChucVu"].Hidden = false;
            cmbu_NguoiDaiDien.DisplayLayout.Bands[0].Columns["TenChucVu"].Header.Caption = "Tên Chức Vụ";
            cmbu_NguoiDaiDien.DisplayLayout.Bands[0].Columns["TenChucVu"].Header.VisiblePosition = 3;
            //cmbu_NguoiDaiDien.DisplayLayout.Bands[0].Columns["TenPhongBan"].Hidden = false;
            //cmbu_NguoiDaiDien.DisplayLayout.Bands[0].Columns["TenPhongBan"].Header.Caption = "Tên Phòng Ban";
            //cmbu_NguoiDaiDien.DisplayLayout.Bands[0].Columns["TenPhongBan"].Header.VisiblePosition = 4;            

        }
        #endregion              

        #region cmbu_TaiKhoanDoiTac_InitializeLayout
        private void cmbu_TaiKhoanDoiTac_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            cmbu_TaiKhoanDoiTac.DisplayLayout.Override.HeaderAppearance.BackColor = Color.SteelBlue;
            this.cmbu_TaiKhoanDoiTac.DisplayLayout.Override.HeaderStyle = HeaderStyle.WindowsXPCommand;

            foreach (UltraGridColumn col in this.cmbu_TaiKhoanDoiTac.DisplayLayout.Bands[0].Columns)
            {
                col.Hidden = true;
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = Color.Navy;
            }

            cmbu_TaiKhoanDoiTac.DisplayLayout.Bands[0].Columns["SoTK"].Hidden = false;
            cmbu_TaiKhoanDoiTac.DisplayLayout.Bands[0].Columns["SoTK"].Header.Caption = "Số Tài Khoản";
            cmbu_TaiKhoanDoiTac.DisplayLayout.Bands[0].Columns["SoTK"].Width = 200;
            cmbu_TaiKhoanDoiTac.DisplayLayout.Bands[0].Columns["SoTK"].Header.VisiblePosition = 0;
        }
        #endregion 
      
        #endregion      

        #region cmbu_LoaiTaiSan_ValueChanged
        private void cmbu_LoaiTaiSan_ValueChanged(object sender, EventArgs e)
        {
            TaiSanCoDinh _taiSanCoDinh= TaiSanCoDinh.NewTaiSanCoDinh();          
            _taiSanCoDinh.TenTSCD = "None";
            if (cmbu_LoaiTaiSan.ActiveRow != null)
            {              
              
                _taiSanCoDinhList = TaiSanCoDinhList.GetTaiSanCoDinhByLoaiTaiSan((int)cmbu_LoaiTaiSan.ActiveRow.Cells["MaLoaiTaiSan"].Value);
                _taiSanCoDinhList.Insert(0, _taiSanCoDinh);
            }

            taiSanCoDinhListBindingSource.DataSource = _taiSanCoDinhList;
            cmbu_TaiSan.DataSource = taiSanCoDinhListBindingSource;
        }       
        #endregion

        #region ultracmbKhachHang_ValueChanged
        private void ultracmbKhachHang_ValueChanged(object sender, EventArgs e)
        {

            if (cmbu_KhachHang.ActiveRow != null)
            {
                _DoiTac = DoiTac.GetDoiTac((long)cmbu_KhachHang.ActiveRow.Cells["MaDoiTac"].Value);

                txtu_MaSoThue.Value = _DoiTac.MaSoThue;
                nguoiLienLacListBindingSource.DataSource = _DoiTac.NguoiLienLacList;                
                tKNganHangListBindingSource.DataSource = _DoiTac.TK_NganHangList;                
            }
            else
            {
                txtu_MaSoThue.Text = string.Empty;
                nguoiLienLacListBindingSource.DataSource = NguoiLienLacList.NewNguoiLienLacList();               
                
                tKNganHangListBindingSource.DataSource = TK_NganHangList.NewTK_NganHangList();
                
            }

        }
        #endregion
       
        #region grdu_ChiTietHopDong_KeyDown
        private void grdu_ChiTietHopDong_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
               
                Decimal _TongTien = 0;
                if (grdu_ChiTietHopDong.ActiveRow != null)
                {
                    foreach (CT_MuaBanTSCD ct_MuaBanTSCD in _HopDongMuaBan.CT_MuaBanTSCDList)
                    {
                        _TongTien = _TongTien + ct_MuaBanTSCD.ThanhTien;
                    }
                    _HopDongMuaBan.TongTien = _TongTien;
                }
                grdu_ChiTietHopDong.UpdateData();
            }
        }
        #endregion                

        #region grdu_DotThanhToan_KeyDown
        private void grdu_DotThanhToan_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            //{
            //    grdu_DotThanhToan.UpdateData();
            //}
        }
        #endregion

        #region tlslblIn_Click
        private void tlslblIn_Click(object sender, EventArgs e)
        {
            if (_HopDongMuaBan.IsNew == false)
            {
                if (_loai == 6) // Mua bán tài sản của Quân
                {
                    ReportDocument Report = new ReportDocument();
                    SqlCommand command = new SqlCommand();
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "spd_Report_HopDongMuaBanTSCD";
                    command.Parameters.AddWithValue("@MaHopDong", _HopDongMuaBan.MaHopDong);
                    command.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);

                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable table = new DataTable();
                    adapter.Fill(table);
                    table.TableName = "spd_Report_HopDongMuaBanTSCD;1";

                    SqlCommand command1 = new SqlCommand();
                    command1.CommandType = CommandType.StoredProcedure;
                    //command1.CommandText = "select * from view_Report_CTHopDongMuaBan";
                    command1.CommandText = "spd_Report_CTHopDongMuaBanTSCD";
                    command1.Parameters.AddWithValue("@MaHopDong", _HopDongMuaBan.MaHopDong);
                    command1.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);
                    DataTable table1 = new DataTable();
                    adapter = new SqlDataAdapter(command1);
                    adapter.Fill(table1);
                    ///table1.TableName = "view_Report_CTHopDongMuaBan";
                    table1.TableName = "spd_Report_CTHopDongMuaBanTSCD;1";

                    SqlCommand command2 = new SqlCommand();
                    command2.CommandType = CommandType.StoredProcedure;
                    //command2.CommandText = "select * from view_Report_DotThanhToan";
                    command2.CommandText = "spd_Report_DotThanhToan";
                    command2.Parameters.AddWithValue("@MaHopDong", _HopDongMuaBan.MaHopDong);
                    command2.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);
                    DataTable table2 = new DataTable();
                    adapter = new SqlDataAdapter(command2);
                    adapter.Fill(table2);
                    table2.TableName = "spd_Report_DotThanhToan;1";

                    SqlCommand command3 = new SqlCommand();
                    command3.CommandType = CommandType.StoredProcedure;
                    //command3.CommandText = "select * from view_Report_DotGiaoNhan";
                    command3.CommandText = "spd_Report_DotGiaoNhan";
                    command3.Parameters.AddWithValue("@MaHopDong", _HopDongMuaBan.MaHopDong);
                    command3.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);
                    DataTable table3 = new DataTable();
                    adapter = new SqlDataAdapter(command3);
                    adapter.Fill(table3);
                    //table3.TableName = "View_Report_DotGiaoNhan";
                    table3.TableName = "spd_Report_DotGiaoNhan;1";

                    DataSet _myDataset = new DataSet();

                    _myDataset.Tables.Add(table);
                    _myDataset.Tables.Add(table1);
                    _myDataset.Tables.Add(table2);
                    _myDataset.Tables.Add(table3);

                    Report.SetDataSource(_myDataset);
                    Report.SetParameterValue("@MaHopDong", _HopDongMuaBan.MaHopDong);

                    frmHienThiReport dlg = new frmHienThiReport();
                    dlg.crytalView_HienThiReport.ReportSource = Report;
                    dlg.Show();
                }
                else // Mua bán hàng của Thuyên
                {
                    ReportDocument Report = new Report.Report_MuaBan.Report_HopDongMuaBan();

                    SqlCommand command = new SqlCommand();
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "spd_Report_HopDongMuaBan";
                    command.Parameters.AddWithValue("@MaHopDong", _HopDongMuaBan.MaHopDong);
                    command.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);

                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable table = new DataTable();
                    adapter.Fill(table);
                    table.TableName = "spd_Report_HopDongMuaBan;1";

                    SqlCommand command1 = new SqlCommand();
                    command1.CommandType = CommandType.StoredProcedure;
                    //command1.CommandText = "select * from view_Report_CTHopDongMuaBan";
                    command1.CommandText = "spd_Report_CTHopDongMuaBan";
                    command1.Parameters.AddWithValue("@MaHopDong", _HopDongMuaBan.MaHopDong);
                    command1.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);
                    DataTable table1 = new DataTable();
                    adapter = new SqlDataAdapter(command1);
                    adapter.Fill(table1);
                    ///table1.TableName = "view_Report_CTHopDongMuaBan";
                    table1.TableName = "spd_Report_CTHopDongMuaBan;1";

                    SqlCommand command2 = new SqlCommand();
                    command2.CommandType = CommandType.StoredProcedure;
                    //command2.CommandText = "select * from view_Report_DotThanhToan";
                    command2.CommandText = "spd_Report_DotThanhToan";
                    command2.Parameters.AddWithValue("@MaHopDong", _HopDongMuaBan.MaHopDong);
                    command2.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);
                    DataTable table2 = new DataTable();
                    adapter = new SqlDataAdapter(command2);
                    adapter.Fill(table2);
                    table2.TableName = "spd_Report_DotThanhToan;1";

                    SqlCommand command3 = new SqlCommand();
                    command3.CommandType = CommandType.StoredProcedure;
                    //command3.CommandText = "select * from view_Report_DotGiaoNhan";
                    command3.CommandText = "spd_Report_DotGiaoNhan";
                    command3.Parameters.AddWithValue("@MaHopDong", _HopDongMuaBan.MaHopDong);
                    command3.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);
                    DataTable table3 = new DataTable();
                    adapter = new SqlDataAdapter(command3);
                    adapter.Fill(table3);
                    //table3.TableName = "View_Report_DotGiaoNhan";
                    table3.TableName = "spd_Report_DotGiaoNhan;1";


                    DataSet _myDataset = new DataSet();

                    _myDataset.Tables.Add(table);
                    _myDataset.Tables.Add(table1);
                    _myDataset.Tables.Add(table2);
                    _myDataset.Tables.Add(table3);

                    Report.SetDataSource(_myDataset);

                    Report.SetParameterValue("@MaHopDong", _HopDongMuaBan.MaHopDong);

                    frmHienThiReport dlg = new frmHienThiReport();
                    dlg.crytalView_HienThiReport.ReportSource = Report;
                    dlg.Show();
                }
            }
            else
            {
                MessageBox.Show(this, "Hợp Đồng Chưa Được Cập Nhật", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }
        #endregion      

        #region grdu_ChiTietHopDong_Leave
        private void grdu_ChiTietHopDong_Leave(object sender, EventArgs e)
        {
            grdu_ChiTietHopDong.UpdateData();

            Decimal _TongTien = 0;
            foreach (CT_MuaBanTSCD ct_MuaBanTSCD in _HopDongMuaBan.CT_MuaBanTSCDList)
            {
                _TongTien = _TongTien + ct_MuaBanTSCD.ThanhTien;
            }
            _HopDongMuaBan.TongTien = _TongTien;
        }
        #endregion

        #region cmbu_LoaiTaiSan_InitializeLayout
        private void cmbu_LoaiTaiSan_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            this.cmbu_LoaiTaiSan.DisplayLayout.Override.HeaderStyle = HeaderStyle.WindowsXPCommand;
            this.cmbu_LoaiTaiSan.DisplayLayout.Override.HeaderAppearance.BackColor = System.Drawing.Color.SteelBlue;
            foreach (UltraGridColumn col in this.cmbu_LoaiTaiSan.DisplayLayout.Bands[0].Columns)
            {
                col.Hidden = true;
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;//x =  //= System.Drawing.w;//RoyalBlue
            }
            cmbu_LoaiTaiSan.DisplayLayout.Bands[0].Columns["TenLoaiTaiSan"].Hidden = false;
            cmbu_LoaiTaiSan.DisplayLayout.Bands[0].Columns["TenLoaiTaiSan"].Header.Caption = "Tên Loại Tài Sản";
            cmbu_LoaiTaiSan.DisplayLayout.Bands[0].Columns["MaLoaiQuanLy"].Header.VisiblePosition = 1;
            cmbu_LoaiTaiSan.DisplayLayout.Bands[0].Columns["MaLoaiQuanLy"].Hidden = false;
            cmbu_LoaiTaiSan.DisplayLayout.Bands[0].Columns["MaLoaiQuanLy"].Header.Caption = "Số Hiệu";                        

        }
        #endregion

        #region grdu_DotThanhToan_AfterCellUpdate
        private void grdu_DotThanhToan_AfterCellUpdate(object sender, Infragistics.Win.UltraWinGrid.CellEventArgs e)
        {
            Decimal _TongTien = 0;
            if (grdu_DotThanhToan.ActiveCell == grdu_DotThanhToan.ActiveRow.Cells["SoTien"])
            {
                foreach (DotThanhToanHDMB dotThanhToan in _HopDongMuaBan.DotThanhToanHDMBList)
                {
                    _TongTien = _TongTien + dotThanhToan.SoTien;
                }
            }
            if (_HopDongMuaBan.TongTien < _TongTien)
            {
                MessageBox.Show(this, "Vui Lòng Nhập Số Tiền Đợt Thanh Toán Bằng Số Tiền Hợp Đồng", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        #endregion

        #region cTMuaBanTSCDListBindingSource_CurrentChanged
        private void cTMuaBanTSCDListBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            Decimal _TongTien = 0;

            foreach (CT_MuaBanTSCD ct_MuaBanTSCD in _HopDongMuaBan.CT_MuaBanTSCDList)
            {
                _TongTien = _TongTien + ct_MuaBanTSCD.ThanhTien;
            }
            _HopDongMuaBan.TongTien = _TongTien;

        }
        #endregion

        #region grdu_ChiTietHopDong_InitializeLayout
        private void grdu_ChiTietHopDong_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            t.ultragrdEmail_InitializeLayout(sender, e);

            grdu_ChiTietHopDong.DisplayLayout.Bands[0].Columns["MaChiTiet"].Hidden = true;
            grdu_ChiTietHopDong.DisplayLayout.Bands[0].Columns["MaHopDong"].Hidden = true;
            grdu_ChiTietHopDong.DisplayLayout.Bands[0].Columns["MaQuocGia"].Hidden = true;

            grdu_ChiTietHopDong.DisplayLayout.Bands[0].Columns["TenLoaiTaiSanCoDinh"].Header.Caption = "Loại Tài Sản";
            grdu_ChiTietHopDong.DisplayLayout.Bands[0].Columns["TenLoaiTaiSanCoDinh"].EditorControl = cmbu_LoaiTaiSan;
            grdu_ChiTietHopDong.DisplayLayout.Bands[0].Columns["TenLoaiTaiSanCoDinh"].Width = 180;
            grdu_ChiTietHopDong.DisplayLayout.Bands[0].Columns["TenLoaiTaiSanCoDinh"].Header.VisiblePosition = 0;

            grdu_ChiTietHopDong.DisplayLayout.Bands[0].Columns["TenTaiSanCoDinh"].Header.Caption = "Tài Sản";
            grdu_ChiTietHopDong.DisplayLayout.Bands[0].Columns["TenTaiSanCoDinh"].EditorControl = cmbu_TaiSan;
            grdu_ChiTietHopDong.DisplayLayout.Bands[0].Columns["TenTaiSanCoDinh"].Width = 160;
            grdu_ChiTietHopDong.DisplayLayout.Bands[0].Columns["TenTaiSanCoDinh"].Header.VisiblePosition = 1;

            grdu_ChiTietHopDong.DisplayLayout.Bands[0].Columns["MaTaiSanCoDinh"].Hidden = true;

            grdu_ChiTietHopDong.DisplayLayout.Bands[0].Columns["SoLuong"].Header.Caption = "Số Lượng";
            grdu_ChiTietHopDong.DisplayLayout.Bands[0].Columns["SoLuong"].Header.VisiblePosition = 2;
            grdu_ChiTietHopDong.DisplayLayout.Bands[0].Columns["SoLuong"].MaskInput = "nnnnnnnnn";
            grdu_ChiTietHopDong.DisplayLayout.Bands[0].Columns["SoLuong"].Width = 80;

            grdu_ChiTietHopDong.DisplayLayout.Bands[0].Columns["MaDonViTinh"].Hidden = false;
            grdu_ChiTietHopDong.DisplayLayout.Bands[0].Columns["MaDonViTinh"].Header.Caption = "Đơn Vị Tính";
            grdu_ChiTietHopDong.DisplayLayout.Bands[0].Columns["MaDonViTinh"].EditorControl = cmbu_DonViTinh;
            grdu_ChiTietHopDong.DisplayLayout.Bands[0].Columns["MaDonViTinh"].Width = 100;
            grdu_ChiTietHopDong.DisplayLayout.Bands[0].Columns["MaDonViTinh"].Header.VisiblePosition = 3;
            
            grdu_ChiTietHopDong.DisplayLayout.Bands[0].Columns["DongGia"].Header.Caption = "Đơn Giá";
            grdu_ChiTietHopDong.DisplayLayout.Bands[0].Columns["DongGia"].Width = 100;
            grdu_ChiTietHopDong.DisplayLayout.Bands[0].Columns["DongGia"].Header.VisiblePosition = 9;

            grdu_ChiTietHopDong.DisplayLayout.Bands[0].Columns["ThanhTien"].Header.Caption = "Thành Tiền";
            grdu_ChiTietHopDong.DisplayLayout.Bands[0].Columns["ThanhTien"].Width = 120;
            grdu_ChiTietHopDong.DisplayLayout.Bands[0].Columns["ThanhTien"].AutoEdit = false;
            grdu_ChiTietHopDong.DisplayLayout.Bands[0].Columns["ThanhTien"].Header.VisiblePosition = 10;
            

            this.grdu_ChiTietHopDong.DisplayLayout.Override.HeaderAppearance.BackColor = System.Drawing.Color.SteelBlue;//appearance17;

            foreach (UltraGridColumn col in this.grdu_ChiTietHopDong.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;
                if (col.DataType.ToString() == "System.Decimal")
                {
                    col.MaskInput = "{LOC}nnn,nnn,nnn,nnn.nn";
                    col.Format = "###,###,###,###,###";
                }
            }
        }
        #endregion 

        #region cmbu_TaiSan_InitializeLayout
        private void cmbu_TaiSan_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            this.cmbu_TaiSan.DisplayLayout.Override.HeaderStyle = HeaderStyle.WindowsXPCommand;
            this.cmbu_TaiSan.DisplayLayout.Override.HeaderAppearance.BackColor = System.Drawing.Color.SteelBlue;
            foreach (UltraGridColumn col in this.cmbu_TaiSan.DisplayLayout.Bands[0].Columns)
            {
                col.Hidden = true;
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;//x =  //= System.Drawing.w;//RoyalBlue
            }
            cmbu_TaiSan.DisplayLayout.Bands[0].Columns["TenTSCD"].Hidden = false;
            cmbu_TaiSan.DisplayLayout.Bands[0].Columns["TenTSCD"].Header.Caption = "Tên Tài Sản Cố Định";
            cmbu_TaiSan.DisplayLayout.Bands[0].Columns["SoHieu"].Header.VisiblePosition = 1;
            cmbu_TaiSan.DisplayLayout.Bands[0].Columns["SoHieu"].Hidden = false;
            cmbu_TaiSan.DisplayLayout.Bands[0].Columns["SoHieu"].Header.Caption = "Số Hiệu";                        

        }
        #endregion 

        #region cmbu_TaiSan_ValueChanged
        private void cmbu_TaiSan_ValueChanged(object sender, EventArgs e)
        {
            if (cmbu_TaiSan.ActiveRow != null)
            {
                ((CT_MuaBanTSCD)(cTMuaBanTSCDListBindingSource.Current)).MaTaiSanCoDinh = (int)(cmbu_TaiSan.ActiveRow.Cells["MaTSCD"].Value);
            }
        }
        #endregion

        #region grdu_DotThanhToan_Error
        private void grdu_DotThanhToan_Error(object sender, ErrorEventArgs e)
        {
            if (e.ErrorType == ErrorType.Data)
                e.ErrorText = "Kiểu dữ liệu không hợp lý, vui lòng kiểm tra lại.";
        }
        #endregion

        #region cmbu_TaiKhoanDoiTac_ValueChanged
        private void cmbu_TaiKhoanDoiTac_ValueChanged(object sender, EventArgs e)
        {
            if (cmbu_TaiKhoanDoiTac.ActiveRow == null)
            {
                cmbu_TaiKhoanDoiTac.Text = "0";
                cmbu_TaiKhoanDoiTac.Focus();
            }
        }
        #endregion

        private void tlslblTim_Click(object sender, EventArgs e)
        {
            frmTimHopDong frm = new frmTimHopDong(6);
            frm.ShowDialog(this);
            //if (frm.ShowDialog(this) == DialogResult.OK)
            //{
                //_HopDongMuaBan = HopDongMuaBan.NewHopDongMuaBan();
                //_HopDongMuaBan.Loai = 6;
                _HopDongMuaBan = frm.HopDongMuaBan;
                hopDongMuaBanBindingSource.DataSource = _HopDongMuaBan;

                cTMuaBanTSCDListBindingSource.DataSource = _HopDongMuaBan.CT_MuaBanTSCDList;
                dotThanhToanHDMBListBindingSource.DataSource = _HopDongMuaBan.DotThanhToanHDMBList;
            //}
        }       
    }
}