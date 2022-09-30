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
    public partial class frmDonNhanHangTra : Form
    {

        #region Properties
        HamDungChung hamDungChung = new HamDungChung();
        Util util = new Util();
        DonNhanHangTra _DonNhanHangTra;
        HangHoaList _HangHoaList = HangHoaList.NewHangHoaList();
        DonViTinhList _DonViTinhKhoiLuongList = DonViTinhList.NewDonViTinhList();
        DonViTinhList _DonViTinhList = DonViTinhList.NewDonViTinhList();
        DonHangBanList _DonHangBanList = DonHangBanList.NewDonHangBanList();
        byte _quyTrinh;
        byte _loai;
        #endregion

        #region Contructors
        public frmDonNhanHangTra()
        {
            InitializeComponent();
            KhaiBaoSuKien();
            KhoiTao();
            Invisible();
        }

        public frmDonNhanHangTra(DonNhanHangTra donNhanHangTra)
        {
            InitializeComponent();
            KhaiBaoSuKien();
            KhoiTao(donNhanHangTra);
            Invisible();
        }

        public frmDonNhanHangTra(byte quyTrinh, byte loai)
        {
            InitializeComponent();
            KhaiBaoSuKien();
            KhoiTao(quyTrinh, loai);
            Invisible();
        }
        #endregion

        #region Khai Báo Sự Kiện Form
        private void KhaiBaoSuKien()
        {
            hamDungChung.EventForm(this);
            hamDungChung.EventGrid(grdu_DSChiTietHangHoa );
            hamDungChung.EventsControl(ultraCbKhachHang);
            hamDungChung.EventsControl(ultracmbDienThoai);
            hamDungChung.EventsControl(ultracmbNguoiLienLac);
            hamDungChung.EventsControl(ultraComboLoaiTien);
            hamDungChung.EventsControl(cbu_KhoDaiLy);
            hamDungChung.EventsControl(cmbu_KhoHangGiao);
            
        }
        #endregion 

        #region Invisible Button
        private void Invisible()
        {
            //tlslblXoa.Available = false;
            //tlslblUndo.Available = false;
            //tlslblTim.Available = false;
            //tlslblTroGiup.Available = false;
            if (_loai == 5 || _loai == 4)
            {
                txtu_TimDonHang.Visible = false;
                lb_TimDonHangBan.Visible = false;
                //btTim.Visible = false;
            }
            if (_loai == 1 || _loai == 2 || _loai == 4)
            {
                lbDaiLy.Visible = false;
                cbu_KhoDaiLy.Visible = false;
            }
        }
        #endregion 

        #region Kiểm Tra Dữ Liệu Trước Khi Lưu

        private bool KiemTraDuLieu()
        {          
           
            bool kq = true;

            //if (_DonNhanHangTra.IsNew == true && DonNhanHangTra.KiemTraSoDonHangTonTai(ultratxtSoDonHang.Text.Trim()) == false)
            //{
            //    MessageBox.Show(this, util.sodonhangkohople, util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    ultratxtSoDonHang.Focus();
            //    return false;
            //}
            if (_DonNhanHangTra.MaKho == 0)
            {
                MessageBox.Show(this, "Vui Lòng Chọn Kho Hàng", util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbu_KhoHangGiao.Focus();
                return false;
            }
            else if (_DonNhanHangTra.MaDoiTac == 0)
            {
                MessageBox.Show(this, "Vui Lòng Chọn Đối Tác", util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ultraCbKhachHang.Focus();
                return false;
            }
            else if (_DonNhanHangTra.CT_DonNhanHangTraList.Count == 0)
            {
                MessageBox.Show(this, "Vui Lòng Nhập Chi Tiết Đơn Hàng", util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                
                return false;
            }
            return kq;
        }

        #endregion

        #region Kiểm Tra Hàng Hóa Bị Trùng
        private Boolean KiemTraHangHoaBiTrung()
        {
            for (int i = 0; i < _DonNhanHangTra.CT_DonNhanHangTraList.Count; i++)
            {
                for (int j = 0; j < _DonNhanHangTra.CT_DonNhanHangTraList.Count; j++)
                {
                    if (i != j)
                    {
                        if (_DonNhanHangTra.CT_DonNhanHangTraList[i].MaHangHoa == _DonNhanHangTra.CT_DonNhanHangTraList[j].MaHangHoa)
                        {
                            HangHoa hangHoa = HangHoa.GetHangHoa(_DonNhanHangTra.CT_DonNhanHangTraList[i].MaHangHoa);
                            MessageBox.Show(this, "Hàng hóa" + hangHoa.TenHangHoa.ToString() + " bị trùng", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            grdu_DSChiTietHangHoa.ActiveRow = grdu_DSChiTietHangHoa.Rows[i];
                            grdu_DSChiTietHangHoa.Focus();
                            return false;

                        }
                    }
                }
            }
            return true;
        }
        #endregion

        #region Lưu Dữ Liệu

        private bool LuuDuLieu()
        {
            bool kq = true;
            try
            {
                if (_DonNhanHangTra.IsNew)
                {
                    _DonNhanHangTra.SoDonHang = DonNhanHangTra.SoDonHangTuDongTang(_DonNhanHangTra.Loai, _DonNhanHangTra.NgayLap);
                    donNhanHangTrabindingSource.EndEdit();
                    _DonNhanHangTra.Save();
                    LenhNhapXuatMuaBan _LenhNhapXuatMuaBan = LenhNhapXuatMuaBan.NewLenhNhapXuatMuaBan(_DonNhanHangTra, true, 2, 0);
                    _LenhNhapXuatMuaBan.Save();
                }
                else
                {
                    if (_DonNhanHangTra.IsDirty)
                    {
                        donNhanHangTrabindingSource.EndEdit();
                        _DonNhanHangTra.Save();                      
                        LenhNhapXuatMuaBanList _LenhNhapXuatMuaBanList = LenhNhapXuatMuaBanList.GetLenhNhapXuatMuaBanListByDonHang(_DonNhanHangTra.MaDonHang);
                        _LenhNhapXuatMuaBanList.Clear();
                        _LenhNhapXuatMuaBanList.Save();
                        LenhNhapXuatMuaBan _LenhNhapXuatMuaBan = LenhNhapXuatMuaBan.NewLenhNhapXuatMuaBan(_DonNhanHangTra, true, 2, 0);
                        _LenhNhapXuatMuaBan.Save();                        
                    }
                }
            }
            catch (ApplicationException ex)
            {
                kq = false;
            }
            return kq;
        }

        #endregion

        #region KhoiTao
        private void KhoiTao()
        {
            _DonNhanHangTra = DonNhanHangTra.NewDonNhanHangTra(0);
           
            donNhanHangTrabindingSource.DataSource = _DonNhanHangTra;

            cTDonNhanHangTraListBindingSource.DataSource = _DonNhanHangTra.CT_DonNhanHangTraList;

            doiTacListBindingSource.DataSource = DoiTacList.GetDoiTacList(false);

            khoListBindingSource.DataSource = KhoList.GetKhoList_LoaiKho(0);

            loaiTienListBindingSource.DataSource = LoaiTienList.GetLoaiTienList();

            donViTinhListBindingSource.DataSource = DonViTinhList.GetDonViTinhList();          

            loaiHangHoaListBindingSource.DataSource = LoaiHangHoaList.GetLoaiHangHoaList(0);

        }
        private void KhoiTao(byte quyTrinh, byte loai)
        {
            _quyTrinh = quyTrinh;
            _loai = loai;
            _DonNhanHangTra = DonNhanHangTra.NewDonNhanHangTra(quyTrinh,loai);
            
            donNhanHangTrabindingSource.DataSource = _DonNhanHangTra;
            cTDonNhanHangTraListBindingSource.DataSource = _DonNhanHangTra.CT_DonNhanHangTraList;

            doiTacListBindingSource.DataSource = DoiTacList.GetDoiTacList(false);

            khoListBindingSource.DataSource = KhoList.GetKhoList_LoaiKho(0);         

            donViTinhListBindingSource.DataSource = DonViTinhList.GetDonViTinhList();            

            loaiHangHoaListBindingSource.DataSource = LoaiHangHoaList.GetLoaiHangHoaList(0);

            loaiTienListBindingSource.DataSource = LoaiTienList.GetLoaiTienList();
        }

        private void KhoiTao(DonNhanHangTra donNhanHangTra)
        {
            _DonNhanHangTra = donNhanHangTra;
            _loai = (byte)donNhanHangTra.Loai;
            donNhanHangTrabindingSource.DataSource = _DonNhanHangTra;

            cTDonNhanHangTraListBindingSource.DataSource = _DonNhanHangTra.CT_DonNhanHangTraList;

            doiTacListBindingSource.DataSource = DoiTacList.GetDoiTacList(false);

            khoListBindingSource.DataSource = KhoList.GetKhoList_LoaiKho(0);

            hoaDonListBindingSource.DataSource = HoaDonList.GetHoaDonList();

            donViTinhListBindingSource.DataSource = DonViTinhList.GetDonViTinhList();
            
            loaiTienListBindingSource.DataSource = LoaiTienList.GetLoaiTienList();

            loaiHangHoaListBindingSource.DataSource = LoaiHangHoaList.GetLoaiHangHoaList(0);
           
        }
        #endregion       

        #region InitializeLayout

        #region ultraCbKhachHang_InitializeLayout
        private void ultraCbKhachHang_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            ultraCbKhachHang.DisplayLayout.Bands[0].Columns["MaDoiTac"].Hidden = true;
            ultraCbKhachHang.DisplayLayout.Bands[0].Columns["MaQLDoiTac"].Header.Caption = "Mã Số";
            ultraCbKhachHang.DisplayLayout.Bands[0].Columns["MaQLDoiTac"].Header.VisiblePosition = 1;
            ultraCbKhachHang.DisplayLayout.Bands[0].Columns["TenDoiTac"].Header.Caption = "Họ Tên";
            ultraCbKhachHang.DisplayLayout.Bands[0].Columns["TenDoiTac"].Header.VisiblePosition = 2;
            ultraCbKhachHang.DisplayLayout.Bands[0].Columns["TenVietTat"].Header.Caption = "Tên Viết Tắt";
            ultraCbKhachHang.DisplayLayout.Bands[0].Columns["TenVietTat"].Header.VisiblePosition = 3;
            ultraCbKhachHang.DisplayLayout.Bands[0].Columns["MaSoThue"].Hidden = true;
            ultraCbKhachHang.DisplayLayout.Bands[0].Columns["TinhTrang"].Hidden = true;
            ultraCbKhachHang.DisplayLayout.Bands[0].Columns["LoaiDoiTac"].Hidden = true;
            ultraCbKhachHang.DisplayLayout.Bands[0].Columns["DienGiai"].Header.Caption = "Nội Dung";
            ultraCbKhachHang.DisplayLayout.Bands[0].Columns["DienGiai"].Header.VisiblePosition = 4;
            this.ultraCbKhachHang.DisplayLayout.Override.HeaderStyle = HeaderStyle.WindowsXPCommand;
            this.ultraCbKhachHang.DisplayLayout.Override.HeaderAppearance.BackColor = System.Drawing.Color.SteelBlue;
            foreach (UltraGridColumn col in this.ultraCbKhachHang.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;//x =  //= System.Drawing.w;//RoyalBlue
            }
        }
        #endregion

        #region ultracmbNguoiLienLac_InitializeLayout
        private void ultracmbNguoiLienLac_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            ultracmbNguoiLienLac.DisplayLayout.Bands[0].Columns["MaNguoiLienLac"].Hidden = true;
            ultracmbNguoiLienLac.DisplayLayout.Bands[0].Columns["TenNguoiLienLac"].Header.Caption = "Tên Người Liên Lạc";
            ultracmbNguoiLienLac.DisplayLayout.Bands[0].Columns["TenNguoiLienLac"].Header.VisiblePosition = 1;
            ultracmbNguoiLienLac.DisplayLayout.Bands[0].Columns["DienThoai"].Header.Caption = "Điện Thoại";
            ultracmbNguoiLienLac.DisplayLayout.Bands[0].Columns["DienThoai"].Header.VisiblePosition = 2;
            ultracmbNguoiLienLac.DisplayLayout.Bands[0].Columns["Email"].Header.Caption = "Email";
            ultracmbNguoiLienLac.DisplayLayout.Bands[0].Columns["Email"].Header.VisiblePosition = 3;
            ultracmbNguoiLienLac.DisplayLayout.Bands[0].Columns["MaDoiTac"].Hidden = true;
            this.ultracmbNguoiLienLac.DisplayLayout.Override.HeaderStyle = HeaderStyle.WindowsXPCommand;
            this.ultracmbNguoiLienLac.DisplayLayout.Override.HeaderAppearance.BackColor = System.Drawing.Color.SteelBlue;
            foreach (UltraGridColumn col in this.ultracmbNguoiLienLac.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;//x =  //= System.Drawing.w;//RoyalBlue
            }
        }
        #endregion

        #region ultracmbDienThoai_InitializeLayout
        private void ultracmbDienThoai_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            ultracmbDienThoai.DisplayLayout.Bands[0].Columns["MaChiTiet"].Hidden = true;
            ultracmbDienThoai.DisplayLayout.Bands[0].Columns["MaDoiTac"].Hidden = true;
            ultracmbDienThoai.DisplayLayout.Bands[0].Columns["MaDienThoaiFax"].Hidden = true;
            ultracmbDienThoai.DisplayLayout.Bands[0].Columns["SoDTFax"].Header.VisiblePosition = 1;
            ultracmbDienThoai.DisplayLayout.Bands[0].Columns["SoDTFax"].Header.Caption = "Số Liên Lạc";
            ultracmbDienThoai.DisplayLayout.Bands[0].Columns["Loai"].Header.Caption = "Điện Thoại/Fax";
            ultracmbDienThoai.DisplayLayout.Bands[0].Columns["Loai"].Header.VisiblePosition = 2;
            this.ultracmbDienThoai.DisplayLayout.Override.HeaderStyle = HeaderStyle.WindowsXPCommand;
            this.ultracmbDienThoai.DisplayLayout.Override.HeaderAppearance.BackColor = System.Drawing.Color.SteelBlue;
            foreach (UltraGridColumn col in this.ultracmbDienThoai.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;//x =  //= System.Drawing.w;//RoyalBlue
            }
        }
        #endregion

        #region ultraCbDonViTinh_InitializeLayout
        private void ultraCbDonViTinh_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {

            ultraCbDonViTinh.DisplayLayout.Bands[0].Columns["MaDonViTinh"].Hidden = true;
            ultraCbDonViTinh.DisplayLayout.Bands[0].Columns["MaQuanLy"].Header.Caption = "Mã Số";
            ultraCbDonViTinh.DisplayLayout.Bands[0].Columns["MaQuanLy"].Header.VisiblePosition = 1;
            ultraCbDonViTinh.DisplayLayout.Bands[0].Columns["TenDonViTinh"].Header.Caption = "Tên Đơn Vị Tính";
            ultraCbDonViTinh.DisplayLayout.Bands[0].Columns["TenDonViTinh"].Header.VisiblePosition = 2;
            ultraCbDonViTinh.DisplayLayout.Bands[0].Columns["MaTinhTrang"].Hidden = true;
            ultraCbDonViTinh.DisplayLayout.Bands[0].Columns["DienGiai"].Hidden = true;

            this.ultraCbHangHoa.DisplayLayout.Override.HeaderStyle = HeaderStyle.WindowsXPCommand;
            this.ultraCbDonViTinh.DisplayLayout.Override.HeaderAppearance.BackColor = System.Drawing.Color.SteelBlue;
            foreach (UltraGridColumn col in this.ultraCbDonViTinh.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;//x =  //= System.Drawing.w;//RoyalBlue
            }
        }
        #endregion

        #region ultraCbHangHoa_InitializeLayout
        private void ultraCbHangHoa_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            this.ultraCbHangHoa.DisplayLayout.Override.HeaderStyle = HeaderStyle.WindowsXPCommand;
            this.ultraCbHangHoa.DisplayLayout.Override.HeaderAppearance.BackColor = System.Drawing.Color.SteelBlue;
            foreach (UltraGridColumn col in this.ultraCbHangHoa.DisplayLayout.Bands[0].Columns)
            {
                col.Hidden = true;
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;//x =  //= System.Drawing.w;//RoyalBlue
            }

            ultraCbHangHoa.DisplayLayout.Bands[0].Columns["MaQuanLy"].Header.Caption = "Mã Hàng";
            ultraCbHangHoa.DisplayLayout.Bands[0].Columns["MaQuanLy"].Header.VisiblePosition = 1;
            ultraCbHangHoa.DisplayLayout.Bands[0].Columns["MaQuanLy"].Hidden = false;

            ultraCbHangHoa.DisplayLayout.Bands[0].Columns["TenHangHoa"].Header.Caption = "Tên Hàng Hóa";
            ultraCbHangHoa.DisplayLayout.Bands[0].Columns["TenHangHoa"].Header.VisiblePosition = 2;
            ultraCbHangHoa.DisplayLayout.Bands[0].Columns["TenHangHoa"].Hidden = false;

            //ultraCbHangHoa.DisplayLayout.Bands[0].Columns["GiaMuaLe"].Header.Caption = "Đơn Giá";
            //ultraCbHangHoa.DisplayLayout.Bands[0].Columns["GiaMuaLe"].Header.VisiblePosition = 3;
            //ultraCbHangHoa.DisplayLayout.Bands[0].Columns["GiaMuaLe"].Hidden = false;
        }
        #endregion

        #region ultragrdDSChiTietHangHoa_InitializeLayout
        private void ultragrdDSChiTietHangHoa_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            grdu_DSChiTietHangHoa.DisplayLayout.Bands[0].Columns["MaCTDonNhanHangTra"].Hidden = true;
            grdu_DSChiTietHangHoa.DisplayLayout.Bands[0].Columns["MaDonNhanHangTra"].Hidden = true;
            grdu_DSChiTietHangHoa.DisplayLayout.Bands[0].Columns["MaDonHangBan"].Hidden = true;
            grdu_DSChiTietHangHoa.DisplayLayout.Bands[0].Columns["ChuaBan"].Hidden = true;
            grdu_DSChiTietHangHoa.DisplayLayout.Bands[0].Columns["PhanTramChietKhau"].Hidden = true;
            grdu_DSChiTietHangHoa.DisplayLayout.Bands[0].Columns["SoTienChietKhau"].Hidden = true;
            grdu_DSChiTietHangHoa.DisplayLayout.Bands[0].Columns["TenLoaiHangHoa"].Hidden = true;    

            //grdu_DSChiTietHangHoa.DisplayLayout.Bands[0].Columns["TenLoaiHangHoa"].Header.Caption = "Loại Hàng Hóa";
            //grdu_DSChiTietHangHoa.DisplayLayout.Bands[0].Columns["TenLoaiHangHoa"].Header.VisiblePosition = 0;
            //grdu_DSChiTietHangHoa.DisplayLayout.Bands[0].Columns["TenLoaiHangHoa"].EditorComponent = cmbu_LoaiHangHoa;

            grdu_DSChiTietHangHoa.DisplayLayout.Bands[0].Columns["TenHangHoa"].Header.Caption = "Thể Loại";
            grdu_DSChiTietHangHoa.DisplayLayout.Bands[0].Columns["TenHangHoa"].Header.VisiblePosition = 1;
            grdu_DSChiTietHangHoa.DisplayLayout.Bands[0].Columns["TenHangHoa"].EditorComponent = ultraCbHangHoa;
            grdu_DSChiTietHangHoa.DisplayLayout.Bands[0].Columns["MaHangHoa"].Hidden = true;

            grdu_DSChiTietHangHoa.DisplayLayout.Bands[0].Columns["DienGiai"].Header.Caption = "Hàng Hóa/Dịch Vụ";
            grdu_DSChiTietHangHoa.DisplayLayout.Bands[0].Columns["DienGiai"].Header.VisiblePosition = 2;
            

            grdu_DSChiTietHangHoa.DisplayLayout.Bands[0].Columns["SoLuong"].Header.Caption = "Số Lượng";
            grdu_DSChiTietHangHoa.DisplayLayout.Bands[0].Columns["SoLuong"].Header.VisiblePosition = 3;
            grdu_DSChiTietHangHoa.DisplayLayout.Bands[0].Columns["SoLuong"].MaskInput = "nnnnnnnnn";

            grdu_DSChiTietHangHoa.DisplayLayout.Bands[0].Columns["TenDonViTinh"].Header.Caption = "Đơn Vị Tính";
            grdu_DSChiTietHangHoa.DisplayLayout.Bands[0].Columns["TenDonViTinh"].Header.VisiblePosition = 3;
            grdu_DSChiTietHangHoa.DisplayLayout.Bands[0].Columns["TenDonViTinh"].EditorComponent = ultraCbDonViTinh;
            grdu_DSChiTietHangHoa.DisplayLayout.Bands[0].Columns["MaDonViTinh"].Hidden = true;

            grdu_DSChiTietHangHoa.DisplayLayout.Bands[0].Columns["KhoiLuongVang"].Hidden = true;
            grdu_DSChiTietHangHoa.DisplayLayout.Bands[0].Columns["KhoiLuongVang"].Header.VisiblePosition = 4;
            grdu_DSChiTietHangHoa.DisplayLayout.Bands[0].Columns["KhoiLuongVang"].MaskInput = "nnnnnnnnn.nnnn";                                    

            grdu_DSChiTietHangHoa.DisplayLayout.Bands[0].Columns["DonGia"].Header.Caption = "Đơn Giá";
            grdu_DSChiTietHangHoa.DisplayLayout.Bands[0].Columns["DonGia"].Header.VisiblePosition = 7;
            
            grdu_DSChiTietHangHoa.DisplayLayout.Bands[0].Columns["ThanhTien"].Header.Caption = "Thành Tiền";           
            grdu_DSChiTietHangHoa.DisplayLayout.Bands[0].Columns["ThanhTien"].Header.VisiblePosition = 10;

            

            this.grdu_DSChiTietHangHoa.DisplayLayout.Override.HeaderStyle = HeaderStyle.WindowsXPCommand;
            this.grdu_DSChiTietHangHoa.DisplayLayout.Override.HeaderAppearance.BackColor = System.Drawing.Color.SteelBlue;
            foreach (UltraGridColumn col in this.grdu_DSChiTietHangHoa.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;
                if (col.DataType.ToString() == "System.Decimal")
                {
                    col.MaskInput = "{LOC}nnn,nnn,nnn,nnn.nn";
                    col.Format = "###,###,###,###,###";
                    col.CellAppearance.TextHAlign = HAlign.Right;
                }
                //x =  //= System.Drawing.w;//RoyalBlue
            }
            hamDungChung.ultragrdEmail_InitializeLayout(sender, e);
        }
        #endregion      

        #region ultracmbKhoHangGiao_InitializeLayout
        private void ultracmbKhoHangGiao_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            cmbu_KhoHangGiao.DisplayLayout.Bands[0].Columns["MaKho"].Hidden = true;
            cmbu_KhoHangGiao.DisplayLayout.Bands[0].Columns["MaQuanLy"].Header.Caption = "Mã Kho";
            cmbu_KhoHangGiao.DisplayLayout.Bands[0].Columns["MaQuanLy"].Header.VisiblePosition = 1;
            cmbu_KhoHangGiao.DisplayLayout.Bands[0].Columns["TenKho"].Header.Caption = "Tên Kho";
            cmbu_KhoHangGiao.DisplayLayout.Bands[0].Columns["TenKho"].Header.VisiblePosition = 2;
            cmbu_KhoHangGiao.DisplayLayout.Bands[0].Columns["MaTaiKhoan"].Hidden = true;
            cmbu_KhoHangGiao.DisplayLayout.Bands[0].Columns["MaLoaiKho"].Hidden = true;
            cmbu_KhoHangGiao.DisplayLayout.Bands[0].Columns["DienGiai"].Header.VisiblePosition = 4;
            cmbu_KhoHangGiao.DisplayLayout.Bands[0].Columns["MaDiaChi"].Header.Caption = "Địa Chỉ";
            cmbu_KhoHangGiao.DisplayLayout.Bands[0].Columns["MaDiaChi"].Header.VisiblePosition = 5;
            cmbu_KhoHangGiao.DisplayLayout.Bands[0].Columns["MaTinhTrang"].Hidden = true;

            this.cmbu_KhoHangGiao.DisplayLayout.Override.HeaderStyle = HeaderStyle.WindowsXPCommand;
            this.cmbu_KhoHangGiao.DisplayLayout.Override.HeaderAppearance.BackColor = System.Drawing.Color.SteelBlue;

            foreach (UltraGridColumn col in this.cmbu_KhoHangGiao.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;//x =  //= System.Drawing.w;//RoyalBlue
            }
        }
        #endregion

        #region ultCbLoaiHang_InitializeLayout
        private void cmbu_LoaiHangHoa_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            this.cmbu_LoaiHangHoa.DisplayLayout.Override.HeaderStyle = HeaderStyle.WindowsXPCommand;
            this.cmbu_LoaiHangHoa.DisplayLayout.Override.HeaderAppearance.BackColor = System.Drawing.Color.SteelBlue;
            foreach (UltraGridColumn col in this.cmbu_LoaiHangHoa.DisplayLayout.Bands[0].Columns)
            {
                col.Hidden = true;
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;//x =  //= System.Drawing.w;//RoyalBlue
            }


            cmbu_LoaiHangHoa.DisplayLayout.Bands[0].Columns["MaQuanLy"].Hidden = false;
            cmbu_LoaiHangHoa.DisplayLayout.Bands[0].Columns["MaQuanLy"].Header.Caption = "Mã Loại Hàng";
            cmbu_LoaiHangHoa.DisplayLayout.Bands[0].Columns["MaQuanLy"].Header.VisiblePosition = 0;

            cmbu_LoaiHangHoa.DisplayLayout.Bands[0].Columns["TenLoaiHangHoa"].Hidden = false;
            cmbu_LoaiHangHoa.DisplayLayout.Bands[0].Columns["TenLoaiHangHoa"].Header.Caption = "Tên Loại Hàng Hóa";
            cmbu_LoaiHangHoa.DisplayLayout.Bands[0].Columns["TenLoaiHangHoa"].Header.VisiblePosition = 1;
        }
        #endregion

        #region ultraComboLoaiTien_InitializeLayout
        private void ultraComboLoaiTien_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            ultraComboLoaiTien.DisplayLayout.Bands[0].Columns["MaLoaiTien"].Hidden = true;
            ultraComboLoaiTien.DisplayLayout.Bands[0].Columns["TiGiaQuyDoi"].Header.Caption = "Tỷ Giá Quy Đổi";
            ultraComboLoaiTien.DisplayLayout.Bands[0].Columns["TiGiaQuyDoi"].Header.VisiblePosition = 3;
            ultraComboLoaiTien.DisplayLayout.Bands[0].Columns["TenLoaiTien"].Header.Caption = "Tên Loại Tiền";
            ultraComboLoaiTien.DisplayLayout.Bands[0].Columns["TenLoaiTien"].Header.VisiblePosition = 2;
            ultraComboLoaiTien.DisplayLayout.Bands[0].Columns["MaLoaiQuanLy"].Header.Caption = "Mã Quản Lý";
            ultraComboLoaiTien.DisplayLayout.Bands[0].Columns["MaLoaiQuanLy"].Header.VisiblePosition = 1;
            this.ultraComboLoaiTien.DisplayLayout.Override.HeaderStyle = HeaderStyle.WindowsXPCommand;
            this.ultraComboLoaiTien.DisplayLayout.Override.HeaderAppearance.BackColor = System.Drawing.Color.SteelBlue;
            foreach (UltraGridColumn col in this.ultraComboLoaiTien.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;//x =  //= System.Drawing.w;//RoyalBlue
            }
        }
        #endregion 

        #region cbu_KhoDaiLy_InitializeLayout
        private void cbu_KhoDaiLy_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            this.cbu_KhoDaiLy.DisplayLayout.Override.HeaderStyle = HeaderStyle.WindowsXPCommand;
            this.cbu_KhoDaiLy.DisplayLayout.Override.HeaderAppearance.BackColor = System.Drawing.Color.SteelBlue;
            foreach (UltraGridColumn col in this.cbu_KhoDaiLy.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;
                col.Hidden = true;
                //x =  //= System.Drawing.w;//RoyalBlue
            }
            cbu_KhoDaiLy.DisplayLayout.Bands[0].Columns["MaQuanLy"].Header.Caption = "Mã Kho";
            cbu_KhoDaiLy.DisplayLayout.Bands[0].Columns["MaQuanLy"].Header.VisiblePosition = 1;
            cbu_KhoDaiLy.DisplayLayout.Bands[0].Columns["MaQuanLy"].Hidden = false;
            cbu_KhoDaiLy.DisplayLayout.Bands[0].Columns["TenKho"].Header.Caption = "Tên Kho";
            cbu_KhoDaiLy.DisplayLayout.Bands[0].Columns["TenKho"].Header.VisiblePosition = 2;
            cbu_KhoDaiLy.DisplayLayout.Bands[0].Columns["TenKho"].Hidden = false;
        }
        #endregion 

        #endregion       

        #region ValueChanged

        #region ultraCbKhachHang_ValueChanged
        private void ultraCbKhachHang_ValueChanged(object sender, EventArgs e)
        {
            DoiTac _doiTac = DoiTac.NewDoiTac();
            _doiTac = DoiTac.GetDoiTac((long)ultraCbKhachHang.ActiveRow.Cells["MaDoiTac"].Value);
            nguoiLienLacListBindingSource.DataSource = _doiTac.NguoiLienLacList;
            doiTacDienThoaiFaxListBindingSource.DataSource = _doiTac.DoiTac_DienThoai_FaxList;
            //khoListBindingSource1.DataSource = KhoList.GetKhoList_KhoDaiLyByMaDaiLy(_doiTac.MaDoiTac);

        }
        #endregion        

        #region ultraCbDonViTinh_ValueChanged
        private void ultraCbDonViTinh_ValueChanged(object sender, EventArgs e)
        {
            if (ultraCbDonViTinh.ActiveRow != null)
            {
                ((CT_DonNhanHangTra)(cTDonNhanHangTraListBindingSource.Current)).MaDonViTinh = (int)ultraCbDonViTinh.ActiveRow.Cells["MaDonViTinh"].Value;
            }
        }
        #endregion

        #region ultraCbHangHoa_ValueChanged
        private void ultraCbHangHoa_ValueChanged(object sender, EventArgs e)
        {
            DonViTinh _donViTinh = DonViTinh.NewDonViTinh();
            _donViTinh.TenDonViTinh = "None";

            DonViTinh _donViTinh1 = DonViTinh.NewDonViTinh();
            _donViTinh1.TenDonViTinh = "None";

            if (ultraCbHangHoa.ActiveRow != null)
            {

                HangHoa _hangHoa = HangHoa.GetHangHoa((int)ultraCbHangHoa.ActiveRow.Cells["MaHangHoa"].Value);
                ((CT_DonNhanHangTra)(cTDonNhanHangTraListBindingSource.Current)).MaHangHoa = _hangHoa.MaHangHoa;

                _DonViTinhList = _hangHoa.DanhSachDVT;
                _DonViTinhList.Insert(0, _donViTinh);
                donViTinhListBindingSource.DataSource = _DonViTinhList;

                _DonViTinhKhoiLuongList = _hangHoa.DanhSachDVKL;
                _DonViTinhKhoiLuongList.Insert(0, _donViTinh1);
                donViTinhListBindingSource1.DataSource = _DonViTinhKhoiLuongList;
            }
        }
        #endregion

        #region cmbu_LoaiHangHoa_ValueChanged
        private void cmbu_LoaiHangHoa_ValueChanged(object sender, EventArgs e)
        {
            HangHoa _hangHoa = HangHoa.NewHangHoa();
            _hangHoa.TenHangHoa = "None";
            if (cmbu_LoaiHangHoa.ActiveRow != null)
            {
                // _HangHoaList.Clear();
                _HangHoaList = HangHoaList.GetHangHoaList((int)cmbu_LoaiHangHoa.ActiveRow.Cells["MaLoaiHangHoa"].Value, 0);
                _HangHoaList.Insert(0, _hangHoa);
            }

            hangHoaListBindingSource.DataSource = _HangHoaList;
        }
        #endregion

        #endregion 
        
        #region cTDonHangBanListBindingSource_CurrentChanged

        private void cTDonHangBanListBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            decimal _tongTien = 0;
            foreach (CT_DonNhanHangTra _ct_donNhanHangTra in _DonNhanHangTra.CT_DonNhanHangTraList)
            {
                _tongTien = _ct_donNhanHangTra.ThanhTien + _tongTien;
            }

            _DonNhanHangTra.TongTien = _tongTien;
        }

        #endregion

        #region tlslblThoat_Click
        private void tlslblThoat_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show(this, util.thaoTac, util.thongbao, MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
                this.Close();
        }
        #endregion

        #region tlslblThem_Click

        private void tlslblThem_Click(object sender, EventArgs e)
        {
            KhoiTao();
        }
        #endregion

        #region tlslblLuu_Click

        private void tlslblLuu_Click(object sender, EventArgs e)
        {
             grdu_DSChiTietHangHoa.UpdateData();
            decimal _tongTien = 0;
            foreach (CT_DonNhanHangTra _ct_donNhanHangTra in _DonNhanHangTra.CT_DonNhanHangTraList)
            {
                _tongTien = _ct_donNhanHangTra.ThanhTien + _tongTien;
            }

            _DonNhanHangTra.TongTien = _tongTien;

            if (KiemTraDuLieu() == true)
            {
                if (KiemTraHangHoaBiTrung() == true)
                {
                    if (MessageBox.Show(this, "Bạn Muốn Lưu Dữ Liệu", "Thông Báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
                    {
                        if (LuuDuLieu() == true)
                        {
                            MessageBox.Show(this, "Cập Nhật Thành Công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            
                        }
                       // else MessageBox.Show(this, "Cập Nhật Không Thành Công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
        }

        #endregion

        #region ultragrdDSChiTietHangHoa_KeyDown
        private void ultragrdDSChiTietHangHoa_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {

                grdu_DSChiTietHangHoa.UpdateData();
                decimal _tongTien = 0;
                foreach (CT_DonNhanHangTra _ct_donNhanHangTra in _DonNhanHangTra.CT_DonNhanHangTraList)
                {
                    _tongTien = _ct_donNhanHangTra.ThanhTien + _tongTien;
                }

                _DonNhanHangTra.TongTien = _tongTien;
            }
        }
        #endregion

        #region ultragrdDSChiTietHangHoa_Leave

        private void ultragrdDSChiTietHangHoa_Leave(object sender, EventArgs e)
        {
            decimal _tongTien = 0;
            foreach (CT_DonNhanHangTra _ct_donNhanHangTra in _DonNhanHangTra.CT_DonNhanHangTraList)
            {
                _tongTien = _ct_donNhanHangTra.ThanhTien + _tongTien;
            }

            _DonNhanHangTra.TongTien = _tongTien;

           // KiemTraHangHoaBiTrung();
        }
        #endregion

        #region grdu_DSChiTietHangHoa_AfterCellUpdate
        private void grdu_DSChiTietHangHoa_AfterCellUpdate(object sender, CellEventArgs e)
        {
            grdu_DSChiTietHangHoa.UpdateData();
            if (grdu_DSChiTietHangHoa.ActiveCell == grdu_DSChiTietHangHoa.ActiveRow.Cells["TenHangHoa"])
            {
                KiemTraHangHoaBiTrung();
            }
        }
        #endregion                

        #region txtu_TimDonHang_KeyDown
        private void txtu_TimDonHang_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                frmDonHangLamLenhNhap dlg = new frmDonHangLamLenhNhap(_loai, 2, txtu_TimDonHang.Text);
                CT_DonNhanHangTraList ct_DonNhanHangTraList;
                if (dlg.ShowDialog() != DialogResult.OK)
                {
                    ct_DonNhanHangTraList = dlg.ct_DonNhanHangTraList;
                    _DonNhanHangTra.MaDoiTac = dlg._maDoiTac;
                    foreach (CT_DonNhanHangTra ct_DonNhanHangTra in ct_DonNhanHangTraList)
                    {
                        _DonNhanHangTra.CT_DonNhanHangTraList.Add(ct_DonNhanHangTra);
                    }
                }
            }
        }
        #endregion 

        #region grdu_DSChiTietHangHoa_Error
        private void grdu_DSChiTietHangHoa_Error(object sender, ErrorEventArgs e)
        {
            if(e.ErrorType == ErrorType.Data)
                 e.ErrorText = "Kiểu dữ liệu không hợp lệ";
         }
        #endregion 

         #region tlslblIn_Click
         private void tlslblIn_Click(object sender, EventArgs e)
        {
            if (_DonNhanHangTra.IsNew == false)
            {
                ReportDocument Report = new Report.Report_MuaBan.Report_DonNhanHangTraLai_XiNghiep();

                SqlCommand command = new SqlCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "spd_Report_DonNhanHangTra_XiNghiep";
                command.Parameters.AddWithValue("@MaDonHang", _DonNhanHangTra.MaDonHang);
                command.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable table = new DataTable();
                adapter.Fill(table);
                table.TableName = "spd_Report_DonNhanHangTra_XiNghiep;1";

                SqlCommand command1 = new SqlCommand();
                command1.CommandType = CommandType.StoredProcedure;
                command1.CommandText = "spd_REPORT_ReportHeader";

                command1.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);

                SqlDataAdapter adapter1 = new SqlDataAdapter(command1);
                DataTable table1 = new DataTable();
                adapter1.Fill(table1);
                table1.TableName = "spd_REPORT_ReportHeader;1";

                DataSet dataSet = new DataSet();
                dataSet.Tables.Add(table);
                dataSet.Tables.Add(table1);

                Report.SetDataSource(dataSet);
                Report.SetParameterValue("@MaDonHang", _DonNhanHangTra.MaDonHang);

                frmHienThiReport dlg = new frmHienThiReport();
                dlg.crytalView_HienThiReport.ReportSource = Report;
                dlg.Show();
            }
            else
            {
                MessageBox.Show(this, "Vui Lòng Cập Nhật Đơn Hàng Trước Khi In", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        #endregion

        private void frmDonNhanHangTra_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                Main.frmMain.LoadHelp(this, "Don Nhan Hang Tra", "Help_BanHang.chm");
            }
        }
    }
}