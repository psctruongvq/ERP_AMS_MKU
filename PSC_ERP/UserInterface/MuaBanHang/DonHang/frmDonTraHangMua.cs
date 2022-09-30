using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ERP_Library;
using Infragistics.Win.UltraWinGrid;
using Infragistics.Win;
using Infragistics.Shared;
using CrystalDecisions.CrystalReports.Engine;
using System.Data.SqlClient;

namespace PSC_ERP
{
    public partial class frmDonTraHangMua : Form
    {
        
        #region Properties
        HamDungChung hamDungChung = new HamDungChung();
        Util util = new Util();
        DonTraHangMua _DonTraHangMua;

        HangHoaList _HangHoaList = HangHoaList.NewHangHoaList();
        DonViTinhList _DonViTinhKhoiLuongList = DonViTinhList.NewDonViTinhList();
        DonViTinhList _DonViTinhList = DonViTinhList.NewDonViTinhList();
        byte _quyTrinh; 
        #endregion

        #region Contructors
        public frmDonTraHangMua()
        {
            InitializeComponent();
            KhoiTao();
            Invisible();
        }

        public frmDonTraHangMua(DonTraHangMua donTraHangMua)
        {
            InitializeComponent();
            KhoiTao(donTraHangMua);
            Invisible();
        }
        public frmDonTraHangMua(byte quyTrinh)
        {
            InitializeComponent();
            KhoiTao(quyTrinh);
            Invisible();
        } 

        #endregion

        #region Khai Báo Sự Kiện
        private void KhaiBaoSuKien()
        {
            hamDungChung.EventForm(this);
            hamDungChung.EventGrid(grdu_DSChiTietHangHoa);
            hamDungChung.EventsControl(cmbu_KhoHangGiao);
            hamDungChung.EventsControl(ultraCbKhachHang);
            hamDungChung.EventsControl(ultracmbDienThoai);
            hamDungChung.EventsControl(ultracmbNguoiLienLac);
            hamDungChung.EventsControl(ultraComboLoaiTien);            
        }

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

        #region Kiểm Tra Dữ Liệu Trước Khi Lưu

        private bool KiemTraDuLieu()
        {          
           
            bool kq = true;

            //if (_DonTraHangMua.IsNew == true && DonTraHangMua.KiemTraSoDonHangTonTai(ultratxtSoDonHang.Text.Trim()) == false)
            //{
            //    MessageBox.Show(this, util.sodonhangkohople, util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    ultratxtSoDonHang.Focus();
            //    return false;
            //}
             if (_DonTraHangMua.CT_DonTraHangMuaList.Count== 0)
            {
                MessageBox.Show(this, "Vui Lòng Nhập Chi Tiết Đơn Hàng", util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                
                return false;
            }
            if (_DonTraHangMua.MaKho == 0)
            {
                MessageBox.Show(this, "Vui Lòng Chọn Kho Hàng", util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbu_KhoHangGiao.Focus();
                return false;
            }
            if (_DonTraHangMua.MaDoiTac == 0)
            {
                MessageBox.Show(this, "Vui Lòng Chọn Đối Tác", util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ultraCbKhachHang.Focus();
                return false;
            }
            return kq;
        }

        #endregion

        #region Kiểm Tra Hàng Hóa Bị Trùng
        private Boolean KiemTraHangHoaBiTrung()
        {
            for (int i = 0; i < _DonTraHangMua.CT_DonTraHangMuaList.Count; i++)
            {
                for (int j = 0; j < _DonTraHangMua.CT_DonTraHangMuaList.Count; j++)
                {
                    if (i != j)
                    {
                        if (_DonTraHangMua.CT_DonTraHangMuaList[i].MaHangHoa == _DonTraHangMua.CT_DonTraHangMuaList[j].MaHangHoa)
                        {
                            HangHoa hangHoa = HangHoa.GetHangHoa(_DonTraHangMua.CT_DonTraHangMuaList[i].MaHangHoa);
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
                if (_DonTraHangMua.IsNew)
                {
                    _DonTraHangMua.SoDonHang = DonTraHangMua.SoDonHangTuDongTang(_DonTraHangMua.NgayLap);
                    donTraHangMuabindingSource.EndEdit();
                    _DonTraHangMua.Save();
                    LenhNhapXuatMuaBan _LenhNhapXuatMuaBan = LenhNhapXuatMuaBan.NewLenhNhapXuatMuaBan(_DonTraHangMua, false, 2);
                    _LenhNhapXuatMuaBan.Save();
                }
                else
                {
                    if (_DonTraHangMua.IsDirty)
                    {
                        donTraHangMuabindingSource.EndEdit();
                        _DonTraHangMua.Save();
                        LenhNhapXuatMuaBanList _LenhNhapXuatMuaBanList = LenhNhapXuatMuaBanList.GetLenhNhapXuatMuaBanListByDonHang(_DonTraHangMua.MaDonHang);
                        _LenhNhapXuatMuaBanList.Clear();
                        _LenhNhapXuatMuaBanList.Save();
                        LenhNhapXuatMuaBan _LenhNhapXuatMuaBan = LenhNhapXuatMuaBan.NewLenhNhapXuatMuaBan(_DonTraHangMua, false, 2);
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
            _DonTraHangMua = DonTraHangMua.NewDonTraHangMua(0);
            //_DonTraHangMua.SoDonHang = DonTraHangMua.SoDonHangTuDong();
            donTraHangMuabindingSource.DataSource = _DonTraHangMua;

            cTDonTraHangMuaListBindingSource.DataSource = _DonTraHangMua.CT_DonTraHangMuaList;

            doiTacListBindingSource.DataSource = DoiTacList.GetDoiTacList(false);

            khoListBindingSource.DataSource = KhoList.GetKhoList_LoaiKho(0);
         

            donViTinhListBindingSource.DataSource = DonViTinhList.GetDonViTinhList();

            loaiTienListBindingSource.DataSource = LoaiTienList.GetLoaiTienList();

            loaiHangHoaListBindingSource.DataSource = LoaiHangHoaList.GetLoaiHangHoaList(0);

         
        }

        private void KhoiTao(byte quyTrinh)
        {
            _quyTrinh = quyTrinh;

            _DonTraHangMua = DonTraHangMua.NewDonTraHangMua(quyTrinh);          

            donTraHangMuabindingSource.DataSource = _DonTraHangMua;

            cTDonTraHangMuaListBindingSource.DataSource = _DonTraHangMua.CT_DonTraHangMuaList;

            doiTacListBindingSource.DataSource = DoiTacList.GetDoiTacList(false);

            khoListBindingSource.DataSource = KhoList.GetKhoList_LoaiKho(0);            

            donViTinhListBindingSource.DataSource = DonViTinhList.GetDonViTinhList();

            loaiHangHoaListBindingSource.DataSource = LoaiHangHoaList.GetLoaiHangHoaList(0);

            loaiTienListBindingSource.DataSource = LoaiTienList.GetLoaiTienList();
        }


        private void KhoiTao(DonTraHangMua donTraHangMua)
        {
            _DonTraHangMua = donTraHangMua;
            donTraHangMuabindingSource.DataSource = _DonTraHangMua;

            cTDonTraHangMuaListBindingSource.DataSource = _DonTraHangMua.CT_DonTraHangMuaList;

            doiTacListBindingSource.DataSource = DoiTacList.GetDoiTacList(false);

            khoListBindingSource .DataSource = KhoList.GetKhoList_LoaiKho(0);

            hoaDonListBindingSource.DataSource = HoaDonList.GetHoaDonList();

            donViTinhListBindingSource.DataSource = DonViTinhList.GetDonViTinhList();

            loaiTienListBindingSource.DataSource = LoaiTienList.GetLoaiTienList();

            loaiHangHoaListBindingSource.DataSource = LoaiHangHoaList.GetLoaiHangHoaList(0);

           
        }
        #endregion

        #region  InitializeLayout

        #region ultracmbHoaDon_InitializeLayout
        private void ultracmbHoaDon_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
           
            //this.ultracmbHoaDon.DisplayLayout.Override.HeaderStyle = HeaderStyle.WindowsXPCommand;
            //this.ultracmbHoaDon.DisplayLayout.Override.HeaderAppearance.BackColor = System.Drawing.Color.SteelBlue;
            //foreach (UltraGridColumn col in this.ultracmbHoaDon.DisplayLayout.Bands[0].Columns)
            //{
            //    col.Hidden = true;
            //    col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
            //    col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
            //    col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;//x =  //= System.Drawing.w;//RoyalBlue
            //}

            
            //ultracmbHoaDon.DisplayLayout.Bands[0].Columns["SoSerial"].Hidden = false;
            //ultracmbHoaDon.DisplayLayout.Bands[0].Columns["SoSerial"].Header.Caption = "Số Serial";
            //ultracmbHoaDon.DisplayLayout.Bands[0].Columns["SoSerial"].Header.VisiblePosition = 1;

            //ultracmbHoaDon.DisplayLayout.Bands[0].Columns["SoHoaDon"].Header.Caption = "Số Hóa Đơn";
            //ultracmbHoaDon.DisplayLayout.Bands[0].Columns["SoHoaDon"].Header.VisiblePosition = 2;
            //ultracmbHoaDon.DisplayLayout.Bands[0].Columns["SoHoaDon"].Hidden = false;

            //ultracmbHoaDon.DisplayLayout.Bands[0].Columns["ThanhTien"].Header.Caption = "Thành Tiền";
            //ultracmbHoaDon.DisplayLayout.Bands[0].Columns["ThanhTien"].Header.VisiblePosition = 4;
            //ultracmbHoaDon.DisplayLayout.Bands[0].Columns["ThanhTien"].Hidden = false;            
            
            //ultracmbHoaDon.DisplayLayout.Bands[0].Columns["NgayLap"].Hidden = false;
            //ultracmbHoaDon.DisplayLayout.Bands[0].Columns["NgayLap"].Header.Caption = "Ngày Lập";
            //ultracmbHoaDon.DisplayLayout.Bands[0].Columns["NgayLap"].Header.VisiblePosition = 3;


        }
        #endregion

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

            //ultraCbHangHoa.DisplayLayout.Bands[0].Columns["GiaBanLe"].Header.Caption = "Đơn Giá";
            //ultraCbHangHoa.DisplayLayout.Bands[0].Columns["GiaBanLe"].Header.VisiblePosition = 3;
            //ultraCbHangHoa.DisplayLayout.Bands[0].Columns["GiaBanLe"].Hidden = false;
        }
        #endregion

        #region ultragrdDSChiTietHangHoa_InitializeLayout
        private void ultragrdDSChiTietHangHoa_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            grdu_DSChiTietHangHoa.DisplayLayout.Bands[0].Columns["MaCTDonTraHang"].Hidden = true;
            grdu_DSChiTietHangHoa.DisplayLayout.Bands[0].Columns["MaDonTraHang"].Hidden = true;
            grdu_DSChiTietHangHoa.DisplayLayout.Bands[0].Columns["MaHangHoa"].Hidden = true;
            grdu_DSChiTietHangHoa.DisplayLayout.Bands[0].Columns["MaDonViTinh"].Hidden = true;
            grdu_DSChiTietHangHoa.DisplayLayout.Bands[0].Columns["KhoiLuong"].Hidden = true;
            grdu_DSChiTietHangHoa.DisplayLayout.Bands[0].Columns["TenLoaiHangHoa"].Hidden = true;

            //grdu_DSChiTietHangHoa.DisplayLayout.Bands[0].Columns["TenLoaiHangHoa"].Header.Caption = "Loại Hàng Hóa";
            //grdu_DSChiTietHangHoa.DisplayLayout.Bands[0].Columns["TenLoaiHangHoa"].Header.VisiblePosition = 0;
            //grdu_DSChiTietHangHoa.DisplayLayout.Bands[0].Columns["TenLoaiHangHoa"].EditorComponent = cmbu_LoaiHangHoa;            

            grdu_DSChiTietHangHoa.DisplayLayout.Bands[0].Columns["TenHangHoa"].Header.Caption = "Hàng Hóa";
            grdu_DSChiTietHangHoa.DisplayLayout.Bands[0].Columns["TenHangHoa"].Header.VisiblePosition = 1;
            grdu_DSChiTietHangHoa.DisplayLayout.Bands[0].Columns["TenHangHoa"].EditorComponent = ultraCbHangHoa;

            grdu_DSChiTietHangHoa.DisplayLayout.Bands[0].Columns["DienGiai"].Header.Caption = "Hàng Hóa/Dịch Vụ";
            grdu_DSChiTietHangHoa.DisplayLayout.Bands[0].Columns["DienGiai"].Header.VisiblePosition = 2;

            grdu_DSChiTietHangHoa.DisplayLayout.Bands[0].Columns["SoLuong"].Header.Caption = "Số Lượng";
            grdu_DSChiTietHangHoa.DisplayLayout.Bands[0].Columns["SoLuong"].Header.VisiblePosition = 3;
            grdu_DSChiTietHangHoa.DisplayLayout.Bands[0].Columns["SoLuong"].MaskInput = "nnnnnnnnn";

            grdu_DSChiTietHangHoa.DisplayLayout.Bands[0].Columns["TenDonViTinh"].Header.Caption = "Đơn Vị Tính";
            grdu_DSChiTietHangHoa.DisplayLayout.Bands[0].Columns["TenDonViTinh"].Header.VisiblePosition = 4;
            grdu_DSChiTietHangHoa.DisplayLayout.Bands[0].Columns["TenDonViTinh"].EditorComponent = ultraCbDonViTinh;

            grdu_DSChiTietHangHoa.DisplayLayout.Bands[0].Columns["DonGia"].Header.Caption = "Đơn Giá";
            grdu_DSChiTietHangHoa.DisplayLayout.Bands[0].Columns["DonGia"].Header.VisiblePosition = 9;
            grdu_DSChiTietHangHoa.DisplayLayout.Bands[0].Columns["DonGia"].MaskInput = "{LOC}nnn,nnn,nnn,nnn,nnn.nn";
            grdu_DSChiTietHangHoa.DisplayLayout.Bands[0].Columns["DonGia"].Format = "###,###,###,###,###";
            grdu_DSChiTietHangHoa.DisplayLayout.Bands[0].Columns["DonGia"].CellAppearance.TextHAlign = HAlign.Right;

            grdu_DSChiTietHangHoa.DisplayLayout.Bands[0].Columns["ThanhTien"].Header.Caption = "Thành Tiền";
            grdu_DSChiTietHangHoa.DisplayLayout.Bands[0].Columns["ThanhTien"].Header.VisiblePosition = 12;
            grdu_DSChiTietHangHoa.DisplayLayout.Bands[0].Columns["ThanhTien"].MaskInput = "{LOC}nnn,nnn,nnn,nnn,nnn.nn";
            grdu_DSChiTietHangHoa.DisplayLayout.Bands[0].Columns["ThanhTien"].Format = "###,###,###,###,###";
            grdu_DSChiTietHangHoa.DisplayLayout.Bands[0].Columns["ThanhTien"].CellAppearance.TextHAlign = HAlign.Right;

            

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
                }//x =  //= System.Drawing.w;//RoyalBlue
            }
            hamDungChung.ultragrdEmail_InitializeLayout(sender, e);
        }
        #endregion

        #region ultracmbKhoHang_InitializeLayout
        private void ultracmbKhoHang_InitializeLayout(object sender, InitializeLayoutEventArgs e)
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

        #region cmbu_LoaiHangHoa_InitializeLayout
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

        #endregion 

        #region ultraCbKhachHang_ValueChanged
        private void ultraCbKhachHang_ValueChanged(object sender, EventArgs e)
        {
            DoiTac _doiTac;
            if (ultraCbKhachHang.ActiveRow != null)
            {
                _doiTac = DoiTac.GetDoiTac((long)ultraCbKhachHang.ActiveRow.Cells["MaDoiTac"].Value);
                nguoiLienLacListBindingSource.DataSource = _doiTac.NguoiLienLacList;
                doiTacDienThoaiFaxListBindingSource.DataSource = _doiTac.DoiTac_DienThoai_FaxList;
            }
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
            foreach (CT_DonTraHangMua _ct_donTraHangMua in _DonTraHangMua.CT_DonTraHangMuaList)
            {
                _tongTien = _ct_donTraHangMua.ThanhTien + _tongTien;
            }

            _DonTraHangMua.TongTien = _tongTien;

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

        #region ultraCbDonViTinh_ValueChanged
        private void ultraCbDonViTinh_ValueChanged(object sender, EventArgs e)
        {
            if (ultraCbDonViTinh.ActiveRow != null)
            {
                ((CT_DonTraHangMua)(cTDonTraHangMuaListBindingSource.Current)).MaDonViTinh = (int)ultraCbDonViTinh.ActiveRow.Cells["MaDonViTinh"].Value;
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
            HangHoa _hangHoa;
            if (ultraCbHangHoa.ActiveRow != null)
            {
                if (cmbu_KhoHangGiao.ActiveRow != null)
                    _hangHoa = HangHoa.GetHangHoa((int)ultraCbHangHoa.ActiveRow.Cells["MaHangHoa"].Value, Convert.ToInt32(cmbu_KhoHangGiao.ActiveRow.Cells["MaKho"].Value));
                else _hangHoa = HangHoa.GetHangHoa((int)ultraCbHangHoa.ActiveRow.Cells["MaHangHoa"].Value, 0);
                ((CT_DonTraHangMua)(cTDonTraHangMuaListBindingSource.Current)).MaHangHoa = _hangHoa.MaHangHoa;

                ultratxtTenHangHoa.Text = _hangHoa.TenHangHoa;
                ultrate_SoLongTon.Value = _hangHoa.SoLuongTon_DatHang;

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

        #region cTDonHangBanListBindingSource_CurrentChanged

        private void cTDonTraHangMuaListBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            decimal _tongTien = 0;
            foreach (CT_DonTraHangMua _ct_donTraHangMua in _DonTraHangMua.CT_DonTraHangMuaList)
            {
                _tongTien = _ct_donTraHangMua.ThanhTien + _tongTien;
            }

            _DonTraHangMua.TongTien = _tongTien;
        }

        #endregion

        #region ultragrdDSChiTietHangHoa_KeyDown
        private void ultragrdDSChiTietHangHoa_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {

                grdu_DSChiTietHangHoa.UpdateData();
                decimal _tongTien = 0;
                foreach (CT_DonTraHangMua _ct_donTraHangMua in _DonTraHangMua.CT_DonTraHangMuaList)
                {
                    _tongTien = _ct_donTraHangMua.ThanhTien + _tongTien;
                }

                _DonTraHangMua.TongTien = _tongTien;
            }
        }
        #endregion

        #region ultragrdDSChiTietHangHoa_Leave
        private void ultragrdDSChiTietHangHoa_Leave(object sender, EventArgs e)
        {
            grdu_DSChiTietHangHoa.UpdateData();
            decimal _tongTien = 0;
            foreach (CT_DonTraHangMua _ct_donTraHangMua in _DonTraHangMua.CT_DonTraHangMuaList)
            {
                _tongTien = _ct_donTraHangMua.ThanhTien + _tongTien;
            }

            _DonTraHangMua.TongTien = _tongTien;
         //   KiemTraHangHoaBiTrung();
        }
        #endregion

        #region ultragrdDSChiTietHangHoa_AfterSelectChange
        private void ultragrdDSChiTietHangHoa_AfterSelectChange(object sender, AfterSelectChangeEventArgs e)
        {
            HangHoa _hangHoa;
            if (grdu_DSChiTietHangHoa.ActiveRow != null)
            {
                if (cTDonTraHangMuaListBindingSource.Current != null)
                {
                    if (cmbu_KhoHangGiao.ActiveRow != null)
                        _hangHoa = HangHoa.GetHangHoa(((CT_DonTraHangMua)(cTDonTraHangMuaListBindingSource.Current)).MaHangHoa, Convert.ToInt32(cmbu_KhoHangGiao.ActiveRow.Cells["MaKho"].Value));
                    else _hangHoa = HangHoa.GetHangHoa(((CT_DonTraHangMua)(cTDonTraHangMuaListBindingSource.Current)).MaHangHoa, 0);
                    ultratxtTenHangHoa.Text = _hangHoa.TenHangHoa;
                    ultrate_SoLongTon.Value = _hangHoa.SoLuongTon_DatHang;
                }
            }
        }
        #endregion

        #region ultragrdDSChiTietHangHoa_AfterCellUpdate
        private void ultragrdDSChiTietHangHoa_AfterCellUpdate(object sender, CellEventArgs e)
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
                frmDonHangLamLenhNhap dlg = new frmDonHangLamLenhNhap(0, 0, txtu_TimDonHang.Text);
                CT_DonTraHangMuaList ct_DonTraHangMuaList;
                if (dlg.ShowDialog() != DialogResult.OK)
                {
                    ct_DonTraHangMuaList = dlg.ct_DonTraHangMuaList;
                    _DonTraHangMua.MaDoiTac = dlg._maDoiTac;
                    foreach (CT_DonTraHangMua ct_DonTraHangMua  in ct_DonTraHangMuaList)
                    {
                        _DonTraHangMua.CT_DonTraHangMuaList.Add(ct_DonTraHangMua);
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
            if (_DonTraHangMua.IsNew == false)
            {
                ReportDocument Report = new Report.Report_MuaBan.Report_DonTraLaiHang_XiNghiep();

                SqlCommand command = new SqlCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "spd_Report_DonTraHang_XiNghiep";
                command.Parameters.AddWithValue("@MaDonHang", _DonTraHangMua.MaDonHang);
                command.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable table = new DataTable();
                adapter.Fill(table);
                table.TableName = "spd_Report_DonTraHang_XiNghiep;1";

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
                Report.SetParameterValue("@MaDonHang", _DonTraHangMua.MaDonHang);

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

        #region frmDonTraHangMua_KeyDown
        private void frmDonTraHangMua_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                Main.frmMain.LoadHelp(this, "Don Hang Tra", "Help_BanHang.chm");
            }
        }
        #endregion 

    }
}