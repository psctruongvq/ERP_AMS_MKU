using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Infragistics.Shared;
using Infragistics.Win;
using Infragistics.Win.UltraWinGrid;
using ERP_Library;
using CrystalDecisions.CrystalReports.Engine;
using System.Data.SqlClient;
namespace PSC_ERP
{
    public partial class frmHoaDonDichVu : Form
    {
        
        #region Properties
        HoaDon _hoaDon;
        NguoiLienLacList _NguoiLienLacList;
        DoiTacList _DoiTacList;
        DoiTac_DienThoai_FaxList _DoiTac_DienThoai_FaxList;
        DiaChi_DoiTacList _DiaChi_DoiTacList;
        private HamDungChung hamDungChung = new HamDungChung();
        private Util util = new Util();
        Decimal _tongTien = 0;
        int _loai = 0;
        long _maHopDong = 0;
        long _maSoTK = 0;
        bool _loaiCD_CV = false;
        bool _layDS = false;
        long maDoiTac = 0;
        HoaDonList _hoaDonList = HoaDonList.NewHoaDonList();
        public HoaDonList _HoaDonListDichVu = HoaDonList.NewHoaDonList();

        #endregion

        #region contructors
        public frmHoaDonDichVu()
        {
            InitializeComponent();
            KhaiBaoSuKien();
            KhoiTao();
            ThemMoi();
            Invisible();
        }
        public frmHoaDonDichVu(long _maDoiTac)
        {
            maDoiTac = _maDoiTac;
            InitializeComponent();
            KhaiBaoSuKien();
            KhoiTao(_maDoiTac);
            ThemMoi();
            Invisible();
        }
        public frmHoaDonDichVu(int loai)
        {

            InitializeComponent();
            KhaiBaoSuKien();
            KhoiTao();
            ThemMoi(loai);
            Invisible();
        }

        public frmHoaDonDichVu(HoaDon hd)
        {
            InitializeComponent();
            KhaiBaoSuKien();
            _layDS = true;
            KhoiTao(hd);
        }

        #region Khai Báo Sự Kiện
        private void KhaiBaoSuKien()
        {
            hamDungChung.EventForm(this);
            hamDungChung.EventGrid(grdu_ChiTietHoaDon);
        }
        #endregion 

        #region Hóa Đơn Chi Tiền Hoa Hồng
        public frmHoaDonDichVu(int loai, byte doiTuongLap)
        {
            InitializeComponent();
            KhoiTao(loai, doiTuongLap);
        }
        #endregion 

        
        #endregion      

        #region Invisible Button
        private void Invisible()
        {
            //tlslblXoa.Available = false;
            //tlslblUndo.Available = false;
            //tlslblTim.Available = false;
            //tlslblTroGiup.Available = false;
        }
        #endregion      

        #region Khởi tạo hóa đơn chi tiền hoa hồng
        private void KhoiTao(int loai, byte doiTuongLap)
        {
            ThemMoi();
            phuongThucThanhToanListBindingSource.DataSource = PhuongThucThanhToanList.GetPhuongThucThanhToanList();
            doiTacListBindingSource.DataSource = DoiTacList.GetDoiTacListTheoKhachHangDaiLy(doiTuongLap);
            kyListBindingSource.DataSource = KyList.GetKyList();
            _hoaDon.LoaiHoaDon = loai;
            cmbu_LoaiHoaDon.Enabled = false;            
            pn_HoaDonHoaHong.Visible = true;
        }
        #endregion 

        #region KhoiTao từ hóa đơn
        public void KhoiTao(HoaDon hd)
        {
            _hoaDon = hd;
            phuongThucThanhToanListBindingSource.DataSource = PhuongThucThanhToanList.GetPhuongThucThanhToanList();
            doiTacListBindingSource.DataSource = DoiTacList.GetDoiTacList(_hoaDon.MaDoiTac);
            hoaDonbindingSource.DataSource = _hoaDon;
                   _loai = 4;
                KhoiTaoHoaDonMuaHangDichVu();
            
            
        }
        #endregion

        #region InitializeLayout

        #region ultraCbKhachHang_InitializeLayout

        private void cmbu_KhachHang_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
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

        #region cmbu_NguoiLienLac_InitializeLayout
        private void cmbu_NguoiLienLac_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {

            cmbu_NguoiLienLac.DisplayLayout.Bands[0].Columns["MaNguoiLienLac"].Hidden = true;
            cmbu_NguoiLienLac.DisplayLayout.Bands[0].Columns["TenNguoiLienLac"].Header.Caption = "Tên Người Liên Lạc";
            cmbu_NguoiLienLac.DisplayLayout.Bands[0].Columns["TenNguoiLienLac"].Header.VisiblePosition = 1;
            cmbu_NguoiLienLac.DisplayLayout.Bands[0].Columns["DienThoai"].Header.Caption = "Điện Thoại";
            cmbu_NguoiLienLac.DisplayLayout.Bands[0].Columns["DienThoai"].Header.VisiblePosition = 2;
            cmbu_NguoiLienLac.DisplayLayout.Bands[0].Columns["Email"].Header.Caption = "Email";
            cmbu_NguoiLienLac.DisplayLayout.Bands[0].Columns["Email"].Header.VisiblePosition = 3;
            cmbu_NguoiLienLac.DisplayLayout.Bands[0].Columns["MaDoiTac"].Hidden = true;
            this.cmbu_NguoiLienLac.DisplayLayout.Override.HeaderStyle = HeaderStyle.WindowsXPCommand;
            this.cmbu_NguoiLienLac.DisplayLayout.Override.HeaderAppearance.BackColor = System.Drawing.Color.SteelBlue;
            foreach (UltraGridColumn col in this.cmbu_NguoiLienLac.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;//x =  //= System.Drawing.w;//RoyalBlue
            }
        }
        #endregion      

        #region grdu_ChiTietHoaDon_InitializeLayout
        private void grdu_ChiTietHoaDon_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            hamDungChung.ultragrdEmail_InitializeLayout(sender, e);
        }
        #endregion

        #region cmbu_DonViTinh_InitializeLayout
        private void cmbu_DonViTinh_InitializeLayout(object sender, InitializeLayoutEventArgs e)
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

        #endregion 

        #region KhoiTao không tham số
        private void KhoiTao()
        {
            phuongThucThanhToanListBindingSource.DataSource = PhuongThucThanhToanList.GetPhuongThucThanhToanList();
            doiTacListBindingSource.DataSource = DoiTacList.GetDoiTacList(false);            
            donViTinhListBindingSource.DataSource = DonViTinhList.GetDonViTinhList();
        }
        private void KhoiTao(long maDoiTac)
        {
            phuongThucThanhToanListBindingSource.DataSource = PhuongThucThanhToanList.GetPhuongThucThanhToanList();
            _DoiTacList = DoiTacList.GetDoiTacList(maDoiTac);
            doiTacListBindingSource.DataSource = _DoiTacList;

            donViTinhListBindingSource.DataSource = DonViTinhList.GetDonViTinhList();
            cmbu_KhachHang.Value = maDoiTac;
        }    
        private void ThemMoi()
        {
            _hoaDon = HoaDon.NewHoaDon();
            hoaDonbindingSource.DataSource = _hoaDon;
            cTHoaDonDichVuListBindingSource.DataSource = _hoaDon.CT_HoaDonDichVuList;
            KhoiTaoHoaDonMuaHangDichVu();
        }

        private void ThemMoi(int loai)
        {
            _hoaDon = HoaDon.NewHoaDon();
            _hoaDon.LoaiHoaDon = loai;
            hoaDonbindingSource.DataSource = _hoaDon;
            cTHoaDonDichVuListBindingSource.DataSource = _hoaDon.CT_HoaDonDichVuList;
            KhoiTaoHoaDonMuaHangDichVu();
        }
      
        #endregion

        #region Kiểm Tra Dữ Liệu
        private bool KiemTraDuLieu()
        {
            bool kq = true;
            if (_hoaDon.SoHoaDon == string.Empty)
            {
                MessageBox.Show(this, util.sohoadon, util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_SoHoaDon.Focus();
                kq = false;
            }

            else if (_hoaDon.SoSerial == string.Empty)
            {
                MessageBox.Show(this, util.soserial, util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_SoSerial.Focus();
                kq = false;
            }
            else if (_hoaDon.MaDoiTac == 0)
            {
                MessageBox.Show(this, util.nhaptenkhachhang, util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_SoSerial.Focus();
                kq = false;
            }
            else if (cmb_HinhThucTT.Text == "")
            {
                MessageBox.Show(this, "Chưa Chọn Phương Thức Thanh Toán", util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmb_HinhThucTT.Focus();
                kq = false;
            }
            return kq;
        }
        #endregion       

        #region Lưu Dữ Liệu
        private bool LuuDuLieu()
        {
            bool kq = true;
            try
            {
                _hoaDon.ApplyEdit();
                _hoaDon.Save();
                _HoaDonListDichVu.Add(_hoaDon);     
                if (_hoaDonList.Count != 0)
                {
                    _hoaDonList.ApplyEdit();
                    _hoaDonList.Save();
                    bt_DanhSachHoaDon.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                kq = false;                
            }
            return kq;
        }
        #endregion                        

        #region KhoiTaoHoaDonMuaHangDichVu
        public void KhoiTaoHoaDonMuaHangDichVu()
        {
            grdu_ChiTietHoaDon.DisplayLayout.Bands[0].Columns["MaChiTiet"].Hidden = true;
            grdu_ChiTietHoaDon.DisplayLayout.Bands[0].Columns["MaHoaDon"].Hidden = true;
            grdu_ChiTietHoaDon.DisplayLayout.Bands[0].Columns["TienPhat"].Hidden = true;
            grdu_ChiTietHoaDon.DisplayLayout.Bands[0].Columns["TienPhuThu"].Hidden = true;

            grdu_ChiTietHoaDon.DisplayLayout.Bands[0].Columns["TenHangHoaDichVu"].Header.Caption = "Hàng Hóa";
            grdu_ChiTietHoaDon.DisplayLayout.Bands[0].Columns["TenHangHoaDichVu"].Header.VisiblePosition = 1;
            grdu_ChiTietHoaDon.DisplayLayout.Bands[0].Columns["TenHangHoaDichVu"].Width = 200;

            grdu_ChiTietHoaDon.DisplayLayout.Bands[0].Columns["SoLuong"].Header.Caption = "Số Lượng";
            grdu_ChiTietHoaDon.DisplayLayout.Bands[0].Columns["SoLuong"].MaskInput = "{LOC}nnn,nnn,nnn,nnn,nnn.nnnn";
            grdu_ChiTietHoaDon.DisplayLayout.Bands[0].Columns["SoLuong"].Header.VisiblePosition = 2;

            grdu_ChiTietHoaDon.DisplayLayout.Bands[0].Columns["MaDonViTinh"].Hidden = true;
            grdu_ChiTietHoaDon.DisplayLayout.Bands[0].Columns["MaDonViTinh"].Header.VisiblePosition = 3;
            grdu_ChiTietHoaDon.DisplayLayout.Bands[0].Columns["MaDonViTinh"].EditorComponent = cmbu_DonViTinh;

            grdu_ChiTietHoaDon.DisplayLayout.Bands[0].Columns["DonGia"].Header.Caption = "Đơn Giá";
            grdu_ChiTietHoaDon.DisplayLayout.Bands[0].Columns["DonGia"].Width = 150;
            grdu_ChiTietHoaDon.DisplayLayout.Bands[0].Columns["DonGia"].Header.VisiblePosition = 4;
            grdu_ChiTietHoaDon.DisplayLayout.Bands[0].Columns["DonGia"].MaskInput = "{LOC}nnn,nnn,nnn,nnn,nnn";
            grdu_ChiTietHoaDon.DisplayLayout.Bands[0].Columns["DonGia"].Format = "###,###,###,###,###";

            grdu_ChiTietHoaDon.DisplayLayout.Bands[0].Columns["ThanhTien"].Header.Caption = "Tổng Tiền";
            grdu_ChiTietHoaDon.DisplayLayout.Bands[0].Columns["ThanhTien"].Width = 200;
            grdu_ChiTietHoaDon.DisplayLayout.Bands[0].Columns["ThanhTien"].Header.VisiblePosition = 5;
            grdu_ChiTietHoaDon.DisplayLayout.Bands[0].Columns["ThanhTien"].CellActivation = Activation.AllowEdit;
            grdu_ChiTietHoaDon.DisplayLayout.Bands[0].Columns["ThanhTien"].MaskInput = "{LOC}nnn,nnn,nnn,nnn,nnn";
            grdu_ChiTietHoaDon.DisplayLayout.Bands[0].Columns["ThanhTien"].Format = "###,###,###,###,###";

            this.grdu_ChiTietHoaDon.DisplayLayout.Override.HeaderStyle = HeaderStyle.WindowsXPCommand;
            this.grdu_ChiTietHoaDon.DisplayLayout.Override.HeaderAppearance.BackColor = System.Drawing.Color.SteelBlue;
            foreach (UltraGridColumn col in this.grdu_ChiTietHoaDon.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;//x =  //= System.Drawing.w;//RoyalBlue
            }
        }
        #endregion
               
        #region luuToolStripMenuItem_Click
        private void luuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            grdu_ChiTietHoaDon.UpdateData();
            if (KiemTraDuLieu() == true)
            {
                if (MessageBox.Show(this, util.luudulieu, util.thongbao, MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
                {                
                    if (LuuDuLieu() == true)
                    {
                        MessageBox.Show(this, util.thanhcong, util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                   // else MessageBox.Show(this, util.luuthatbai, util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
        #endregion

        #region thêmToolStripMenuItem_Click
        private void thêmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ThemMoi();
        }
        #endregion

        #region grdu_ChiTietHoaDon_KeyDown
        private void grdu_ChiTietHoaDon_KeyDown(object sender, KeyEventArgs e)
        {            
            if (e.KeyCode == Keys.Enter)
            {
                _tongTien = 0;
                grdu_ChiTietHoaDon.UpdateData();             
                foreach (CT_HoaDonDichVu ct_HoaDonDichVu in _hoaDon.CT_HoaDonDichVuList)
                {
                    _tongTien = _tongTien + ct_HoaDonDichVu.ThanhTien;
                }
                _hoaDon.ThanhTien = _tongTien;
             }                                    
        }
        #endregion

        #region grdu_ChiTietHoaDon_AfterCellUpdate
        private void grdu_ChiTietHoaDon_AfterCellUpdate(object sender, CellEventArgs e)
        {
            Decimal _tongTien = 0;

            if (grdu_ChiTietHoaDon.ActiveRow.Cells["SoLuong"].IsActiveCell == true || grdu_ChiTietHoaDon.ActiveRow.Cells["DonGia"].IsActiveCell == true)
            {
                if (_hoaDon.LoaiHoaDon == 4 || _hoaDon.LoaiHoaDon == 5)
                {
                    grdu_ChiTietHoaDon.ActiveRow.Cells["ThanhTien"].Value = Convert.ToInt32(grdu_ChiTietHoaDon.ActiveRow.Cells["SoLuong"].Value) * Convert.ToDecimal(grdu_ChiTietHoaDon.ActiveRow.Cells["DonGia"].Value);
                    
                        foreach (CT_HoaDonDichVu ct_HoaDonDichVu in _hoaDon.CT_HoaDonDichVuList)
                        {
                            _tongTien = _tongTien + ct_HoaDonDichVu.ThanhTien;
                        }
                   
                    _hoaDon.ThanhTien = _tongTien; 
                }

            }
            if (grdu_ChiTietHoaDon.ActiveRow.Cells["ThanhTien"].IsActiveCell == true)
            {
                foreach (CT_HoaDonDichVu ct_HoaDonDichVu in _hoaDon.CT_HoaDonDichVuList)
                {
                    _tongTien = _tongTien +  ct_HoaDonDichVu.ThanhTien;
                }
            }
            _hoaDon.ThanhTien = _tongTien;   
        }
        #endregion
       
        #region cmbu_DonViTinh_ValueChanged
        private void cmbu_DonViTinh_ValueChanged(object sender, EventArgs e)
        {
            //if (cmbu_DonViTinh.ActiveRow != null)
            //{
            //    ((CT_HoaDonDichVu)(cTHoaDonDichVuListBindingSource.Current)).MaDonViTinh = (int)cmbu_DonViTinh.ActiveRow.Cells["MaDonViTinh"].Value;
            //}
        }
        #endregion

        #region cmbeu_TinhTrang_ValueChanged
        private void cmbeu_TinhTrang_ValueChanged(object sender, EventArgs e)
        {
            if (cmbeu_TinhTrang.Value != null)
            {
                //chưa thanh tóan
                if (Convert.ToInt32(cmbeu_TinhTrang.Value) == 0)
                {
                    num_SoTienDaThanhToan.Focus();
                    num_SoTienDaThanhToan.Value = 0;
                    _hoaDon.TinhTrang = 0;
                }
                //thanh toán đủ
                else if (Convert.ToInt32(cmbeu_TinhTrang.Value) == 1)
                {
                    if (_tongTien != 0)
                    {
                        num_SoTienDaThanhToan.Value = _tongTien;                        
                    }
                    else
                    {
                        num_SoTienDaThanhToan.Value = _hoaDon.TongTien;
                        _hoaDon.SoTienDaThanhToan = _hoaDon.TongTien;
                    }
                    _hoaDon.TinhTrang = 1;
                }
                //thanh toán 1 phần
                else //if (Convert.ToInt32(cmbeu_TinhTrang.Value) == 2)
                {
                    num_SoTienDaThanhToan.Focus();
                    num_SoTienDaThanhToan.Value = 0;                    
                    _hoaDon.TinhTrang = 2;
                }
            }
        }
        #endregion

        #region inToolStripMenuItem_Click
        private void inToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, util.thaoTac, util.thongbao, MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                this.Close();
            }
        }
        #endregion

        #region cmbe_ThueVAT_ValueChanged
        private void cmbe_ThueVAT_ValueChanged(object sender, EventArgs e)
        {
            if (cmbe_ThueVAT.Value != null)
            {
                if (Convert.ToInt32(cmbe_ThueVAT.Value) != 0)
                {
                    if (Convert.ToInt64(numeu_ThanhTien.Value) != 0)
                    {
                        numeu_TongTien.Value = Convert.ToInt64(numeu_ThanhTien.Value) + (Convert.ToInt64(cmbe_ThueVAT.Value) * Convert.ToInt64(numeu_ThanhTien.Value)) / 100;
                        if (txt_VietBangChua.Text != "")
                        {
                            txt_VietBangChua.Text = Util.ReadMoney(numeu_TongTien.Value.ToString());
                        }
                    }                   
                }
                else if (Convert.ToInt64(cmbe_ThueVAT.Value) == 0)
                {
                    numeu_TongTien.Value = numeu_ThanhTien.Value;
                    if (txt_VietBangChua.Text != "")
                    {
                        txt_VietBangChua.Text = Util.ReadMoney(numeu_ThanhTien.Value.ToString());
                    }
                }
            }
        }
        #endregion                                         
       
        #region bt_DanhSachHoaDon_Click
        private void bt_DanhSachHoaDon_Click(object sender, EventArgs e)
        {            
            long maDaiLy = 0;      
            decimal tienHoaHong =0;
            if (cmbu_KhachHang.ActiveRow != null)            
                maDaiLy = Convert.ToInt64(cmbu_KhachHang.Value);           
            Ky ky = (Ky)(cb_Ky.SelectedItem);
        
            _hoaDon.ThanhTien = tienHoaHong;
        }
        #endregion               

        #region tlslblThoat_Click
        private void tlslblThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        private void cmbu_KhachHang_ValueChanged(object sender, EventArgs e)
        {

        }

      

    }
}
  
