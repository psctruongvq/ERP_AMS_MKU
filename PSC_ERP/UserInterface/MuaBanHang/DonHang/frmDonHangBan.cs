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
using CrystalDecisions.CrystalReports.Engine;
using System.Data.SqlClient;


namespace PSC_ERP
{
    public partial class frmDonHangBan : Form
    {
        #region Khai Báo properties

        DonHangBan _donHangBan;      
        Util util = new Util();
        HamDungChung hamDungChung = new HamDungChung();
        HopDongMuaBanList _HopDongMuaBanList;
        HangHoaList _HangHoaList =  HangHoaList.NewHangHoaList();
        DonViTinhList _DonViTinhKhoiLuongList = DonViTinhList.NewDonViTinhList();
        DonViTinhList _DonViTinhList = DonViTinhList.NewDonViTinhList();
        byte _quyTrinh = 0;
        byte _loai = 0;
        byte _loaiHopDong = 0;
        HopDongMuaBan _hopDongMuaBan = HopDongMuaBan.NewHopDongMuaBan();
        DoiTacList _doiTacList;
        HangHoa _hangHoa;
        int flag = 0;

        #endregion

        #region Contructor
        public frmDonHangBan()
        {
            InitializeComponent(); 
            KhaiBaoSuKien();
        }

        public frmDonHangBan(byte quyTrinh, byte loai)
        {
            InitializeComponent();    
            KhaiBaoSuKien();
            _quyTrinh = quyTrinh;           
            KhoiTao(quyTrinh, loai);
            Invisible();
        }       


        public frmDonHangBan(DonHangBan _donHangBan)
        {
            InitializeComponent();
            KhaiBaoSuKien();
            KhoiTao(_donHangBan);
            Invisible();

        }

        #endregion

        #region Khai Báo Sư Kiện Form
        private void KhaiBaoSuKien()
        {
            hamDungChung.EventForm(this);
            hamDungChung.EventGrid(grdu_ChiTietHangHoa);
            hamDungChung.EventsControl(ultraCbKhachHang);
            hamDungChung.EventsControl(cmbu_KhoHangGiao);            
            hamDungChung.EventsControl(cmbu_DotGiaoHang);            
            hamDungChung.EventsControl(ultracmbNguoiLienLac);                       
            hamDungChung.EventsControl(ultracmbChietKhau);
            hamDungChung.EventsControl(ultracmbDiaChiGH);
            hamDungChung.EventsControl(ultracmbDiaChiHD);
            hamDungChung.EventsControl(ultracmbDienThoai);

        }

        #endregion

        #region Khởi Tạo

        private void KhoiTao(byte quyTrinh, byte loai)
        {
            _donHangBan = DonHangBan.NewDonHangBan(quyTrinh);

            _loai = loai;

            doiTacListbindingSource.DataSource = DoiTacList.GetDoiTacList(false);

            khoListbindingSource.DataSource = KhoList.GetKhoList_LoaiKho(0);            

            hopDongMuaBanListbindingSource.DataSource = _HopDongMuaBanList;      
            
            loaiTienBindingSource.DataSource = LoaiTienList.GetLoaiTienList();
           
            donHangBanbindingSource.DataSource = _donHangBan;

            cTDonHangBanListBindingSource.DataSource = _donHangBan.CT_DonHangBanList;            

            _donHangBan.Loai = loai;
            if (_loai == 0)
                _loaiHopDong = 2;
            else if (_loai == 3)
                _loaiHopDong = 3;
            else if (_loai == 5)
                _loaiHopDong = 8;
            if (_loai == 4 || _loai == 5)
            {
                khoListBindingSource1.DataSource = KhoList.GetKhoList_KhoDaiLy();
            }
            //if (_donHangBan.Loai == 0)
            //{
            //    _doiTacList = DoiTacList.GetDoiTacListTheoLoaiKhachHang(2);

            //}
            //else _doiTacList = DoiTacList.GetDoiTacListTheoLoaiKhachHang(_donHangBan.Loai);
            _doiTacList = DoiTacList.GetDoiTacList();
            DoiTac doiTac = DoiTac.NewDoiTac(0, "Thêm Mới......");
            _doiTacList.Insert(0, doiTac);
            doiTacListbindingSource.DataSource = _doiTacList;

            _HangHoaList = HangHoaList.GetHangHoaList();
            HangHoa _hangHoa = HangHoa.NewHangHoa("Thêm Mới", 0);
            _HangHoaList.Insert(0, _hangHoa);
            hangHoaListBindingSource.DataSource = _HangHoaList;

            txt_HopDong.Text = "";
           
        }

        private void KhoiTao(DonHangBan DonHangBan)
        {          

            _donHangBan = DonHangBan;

            _quyTrinh = _donHangBan.QuyTrinh;

            _loai = _donHangBan.Loai;
            
            doiTacListbindingSource.DataSource = DoiTacList.GetDoiTacList(false);

            khoListbindingSource.DataSource = KhoList.GetKhoList_LoaiKho(0);

            if (_loai == 4 || _loai == 5)
            {
                khoListBindingSource1.DataSource = KhoList.GetKhoList_KhoDaiLy();
            }

            _hopDongMuaBan = HopDongMuaBan.GetHopDongMuaBan(_donHangBan.MaHopDongBan);

            dotGiaoHangListbindingSource.DataSource = _hopDongMuaBan.DotGiaoHangHDMBList;

            txt_HopDong.Text = _hopDongMuaBan.SoHopDong;

            //loaiHangHoaListBindingSource.DataSource = LoaiHangHoaList.GetLoaiHangHoaList(0);

            hangHoaListBindingSource.DataSource = HangHoaList.GetHangHoaList();

            loaiTienBindingSource.DataSource = LoaiTienList.GetLoaiTienList();

            donHangBanbindingSource.DataSource = _donHangBan;

            cTDonHangBanListBindingSource.DataSource = _donHangBan.CT_DonHangBanList;

            _doiTacList = DoiTacList.GetDoiTacList();
            //if (_donHangBan.Loai == 0)
            //{
            //    _doiTacList = DoiTacList.GetDoiTacListTheoLoaiKhachHang(2);

            //}
            //else _doiTacList = DoiTacList.GetDoiTacListTheoLoaiKhachHang(_donHangBan.Loai);
            DoiTac doiTac = DoiTac.NewDoiTac(0, "Thêm Mới......");
            _doiTacList.Insert(0, doiTac);
            doiTacListbindingSource.DataSource = _doiTacList;
        }

        #endregion

        #region Invisible Button
        private void Invisible()
        {
            //tlslblXoa.Available = false;
            //tlslblUndo.Available = false;            
            //tlslblTroGiup.Available = false;
            if (_quyTrinh == 0)
                tlslbLapHoaDon.Visible = false;
            else
                tlslbLapHoaDon.Visible = true;
            if (_loai == 4 || _loai == 5)
            {
                cbu_KhoDaiLy.Visible = true;
                lbDaiLy.Visible = true;
            }
            else
            {
                cbu_KhoDaiLy.Visible = false;
                lbDaiLy.Visible = false;
            }
            if (_loai == 1 || _loai == 2 || _loai == 4 )
            {
                _donHangBan.MaHopDongBan = 0;
                txt_HopDong.Enabled = false;
                cmbu_DotGiaoHang.Enabled = false;
                

            }
            else
            {
                txt_HopDong.Enabled = true;
                cmbu_DotGiaoHang.Enabled = true;
               
            }
        }
        #endregion 

        #region Kiểm Tra Dữ Liệu Trước Khi Lưu

        private bool KiemTraDuLieu()
        {
            bool kq = true;
            
            //if (_donHangBan.MaKho == 0)
            //{
            //    MessageBox.Show(this, "Vui Lòng Chọn Kho Hàng Bán", util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    cmbu_KhoHangGiao.Focus();
            //    return false;
            //}
            if (_donHangBan.MaKhoDaiLy == 0 && (_loai == 4 || _loai == 5))
            {
                MessageBox.Show(this, "Vui Lòng Chọn Kho Đại Lý", util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbu_KhoDaiLy.Focus();
                return false;
            }
            else if (_donHangBan.MaDotGiao != 0 && _donHangBan.IsNew == true && DotGiaoHangHDMB.GetDotGiaoHangHDMB(_donHangBan.MaDotGiao).DaGiaoHang == true)
            {
                MessageBox.Show(this, "Đợt Giao Hàng Đã Được Thực Hiện. Vui Lòng Chọn Đợt Giao Hàng Khác", util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbu_DotGiaoHang.Focus();
                return false;
            }
            if (_donHangBan.MaDoiTac == 0)
            {
                MessageBox.Show(this, "Vui Lòng Chọn Đối Tác", util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ultraCbKhachHang.Focus();
                return false;
            }

            else if (_donHangBan.CT_DonHangBanList.Count == 0)
            {
                MessageBox.Show(this, "Vui Lòng Nhập Chi Tiết Trước Khi Lưu", util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_SoDonHang.Focus();
                return false;
            }
            return kq;
        }

        #endregion

        #region Kiểm Tra Hàng Hóa Bị Trùng
        private Boolean KiemTraHangHoaBiTrung()
        {
            for (int i = 0; i < _donHangBan.CT_DonHangBanList.Count; i++)
            {
                for (int j = 0; j < _donHangBan.CT_DonHangBanList.Count; j++)
                {
                    if (i != j)
                    {
                        if (_donHangBan.CT_DonHangBanList[i].MaHangHoa == _donHangBan.CT_DonHangBanList[j].MaHangHoa)
                        {
                            HangHoa hangHoa = HangHoa.GetHangHoa(_donHangBan.CT_DonHangBanList[i].MaHangHoa);
                            MessageBox.Show(this, "Hàng hóa" + hangHoa.TenHangHoa.ToString() + " bị trùng", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            grdu_ChiTietHangHoa.ActiveRow = grdu_ChiTietHangHoa.Rows[i];
                            grdu_ChiTietHangHoa.Focus();
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
                if (_donHangBan.IsNew)
                {
                    _donHangBan.SoDonHang = DonHangBan.SoDonHangTuDongTang(_donHangBan.Loai, _donHangBan.NgayLap);
                    donHangBanbindingSource.EndEdit();
                    _donHangBan.Save();
                    if (_quyTrinh == 0)
                    {
                        LenhNhapXuatMuaBan _LenhNhapXuatMuaBan = LenhNhapXuatMuaBan.NewLenhNhapXuatMuaBan(_donHangBan, false, _loai);
                        _LenhNhapXuatMuaBan.Save();
                    }
                }
                else
                {
                    if (_donHangBan.IsDirty)
                    {
                        donHangBanbindingSource.EndEdit();
                        _donHangBan.Save();
                        if (_quyTrinh == 0)
                        {
                            LenhNhapXuatMuaBanList _LenhNhapXuatMuaBanList = LenhNhapXuatMuaBanList.GetLenhNhapXuatMuaBanListByDonHang(_donHangBan.MaDonHang);
                            _LenhNhapXuatMuaBanList.Clear();
                            _LenhNhapXuatMuaBanList.Save();
                            LenhNhapXuatMuaBan _lenhNhapXuatMuaBan = LenhNhapXuatMuaBan.NewLenhNhapXuatMuaBan(_donHangBan, false, _loai);
                            _lenhNhapXuatMuaBan.Save();
                        }
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
            KhoiTao(_quyTrinh, _loai);
        }
        #endregion

        #region tlslblLuu_Click

        private void tlslblLuu_Click(object sender, EventArgs e)
        {
            decimal _tongTien = 0;            
            foreach (CT_DonHangBan _ct_donHangBan in _donHangBan.CT_DonHangBanList)
            {
                _tongTien = _ct_donHangBan.SoTien + _tongTien;
            }
            _donHangBan.ThanhTien = _tongTien;
            donHangBanbindingSource.EndEdit();
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
                      //  else MessageBox.Show(this, "Cập Nhật Không Thành Công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
        }

        #endregion

        #region InitializeLayout

        #region ultragrdDSChiTietHangHoa_InitializeLayout
        private void ultragrdDSChiTietHangHoa_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {

            grdu_ChiTietHangHoa.DisplayLayout.Bands[0].Columns["MaChiTiet"].Hidden = true;
            grdu_ChiTietHangHoa.DisplayLayout.Bands[0].Columns["MaDonHang"].Hidden = true;
            grdu_ChiTietHangHoa.DisplayLayout.Bands[0].Columns["MaHangHoa"].Hidden = true;
            grdu_ChiTietHangHoa.DisplayLayout.Bands[0].Columns["HangTraLai"].Hidden = true;
            grdu_ChiTietHangHoa.DisplayLayout.Bands[0].Columns["SoTienChietKhau"].Hidden = true;
            grdu_ChiTietHangHoa.DisplayLayout.Bands[0].Columns["ChietKhau"].Hidden = true;
            grdu_ChiTietHangHoa.DisplayLayout.Bands[0].Columns["KhoiLuongVang"].Hidden = true;
            
            grdu_ChiTietHangHoa.DisplayLayout.Bands[0].Columns["TenLoaiHangHoa"].Hidden = true;            

            grdu_ChiTietHangHoa.DisplayLayout.Bands[0].Columns["TenHangHoa"].Header.Caption = "Thể Loại";
            grdu_ChiTietHangHoa.DisplayLayout.Bands[0].Columns["TenHangHoa"].Header.VisiblePosition = 1;
            grdu_ChiTietHangHoa.DisplayLayout.Bands[0].Columns["TenHangHoa"].EditorComponent = ultraCbHangHoa;

            grdu_ChiTietHangHoa.DisplayLayout.Bands[0].Columns["DienGiai"].Header.Caption = "Hàng Hóa/Dịch Vụ";
            grdu_ChiTietHangHoa.DisplayLayout.Bands[0].Columns["DienGiai"].Header.VisiblePosition = 2;

            grdu_ChiTietHangHoa.DisplayLayout.Bands[0].Columns["MaDonViTinh"].Hidden = true;
            grdu_ChiTietHangHoa.DisplayLayout.Bands[0].Columns["SoLuong"].Header.Caption = "Số Lượng";
            grdu_ChiTietHangHoa.DisplayLayout.Bands[0].Columns["SoLuong"].Header.VisiblePosition = 3;
            grdu_ChiTietHangHoa.DisplayLayout.Bands[0].Columns["SoLuong"].MaskInput = "nnnnnnnnn";

            grdu_ChiTietHangHoa.DisplayLayout.Bands[0].Columns["TenDonViTinh"].Header.Caption = "Đơn Vị Tính";
            grdu_ChiTietHangHoa.DisplayLayout.Bands[0].Columns["TenDonViTinh"].Header.VisiblePosition = 4;
            grdu_ChiTietHangHoa.DisplayLayout.Bands[0].Columns["TenDonViTinh"].EditorComponent = ultraCbDonViTinh;            

            grdu_ChiTietHangHoa.DisplayLayout.Bands[0].Columns["DonGia"].Header.Caption = "Đơn Giá";
            grdu_ChiTietHangHoa.DisplayLayout.Bands[0].Columns["DonGia"].Header.VisiblePosition = 9;
            grdu_ChiTietHangHoa.DisplayLayout.Bands[0].Columns["DonGia"].MaskInput = "{LOC}nnn,nnn,nnn,nnn,nnn.nn";
            grdu_ChiTietHangHoa.DisplayLayout.Bands[0].Columns["DonGia"].Format = "###,###,###,###,###";
            grdu_ChiTietHangHoa.DisplayLayout.Bands[0].Columns["DonGia"].CellAppearance.TextHAlign = HAlign.Right;
            
            grdu_ChiTietHangHoa.DisplayLayout.Bands[0].Columns["SoTien"].Header.Caption = "Thành Tiền";
            grdu_ChiTietHangHoa.DisplayLayout.Bands[0].Columns["SoTien"].Header.VisiblePosition = 12;
            grdu_ChiTietHangHoa.DisplayLayout.Bands[0].Columns["SoTien"].MaskInput = "{LOC}nnn,nnn,nnn,nnn,nnn.nn";
            grdu_ChiTietHangHoa.DisplayLayout.Bands[0].Columns["SoTien"].Format = "###,###,###,###,###";
            grdu_ChiTietHangHoa.DisplayLayout.Bands[0].Columns["SoTien"].CellAppearance.TextHAlign = HAlign.Right;

            

            this.grdu_ChiTietHangHoa.DisplayLayout.Override.HeaderStyle = HeaderStyle.WindowsXPCommand;
            this.grdu_ChiTietHangHoa.DisplayLayout.Override.HeaderAppearance.BackColor = System.Drawing.Color.SteelBlue;
            foreach (UltraGridColumn col in this.grdu_ChiTietHangHoa.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;//x =  //= System.Drawing.w;//RoyalBlue
            }
            hamDungChung.ultragrdEmail_InitializeLayout(sender, e);
        }
        #endregion     

        #region ultracmbDotGiaoHang_InitializeLayout
        private void ultracmbDotGiaoHang_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            cmbu_DotGiaoHang.DisplayLayout.Bands[0].Columns["MaChiTiet"].Hidden = true;
            cmbu_DotGiaoHang.DisplayLayout.Bands[0].Columns["MaHopDongMuaBan"].Hidden = true;
            cmbu_DotGiaoHang.DisplayLayout.Bands[0].Columns["MaPhuongThucGiaoNhan"].Hidden = true;
            cmbu_DotGiaoHang.DisplayLayout.Bands[0].Columns["NgayGiao"].Header.Caption = "Ngày Giao";
            cmbu_DotGiaoHang.DisplayLayout.Bands[0].Columns["NgayGiao"].Header.VisiblePosition = 1;
            cmbu_DotGiaoHang.DisplayLayout.Bands[0].Columns["MaDiaChi"].Hidden = true;
            cmbu_DotGiaoHang.DisplayLayout.Bands[0].Columns["MaDiaChiHD"].Hidden = true;
            cmbu_DotGiaoHang.DisplayLayout.Bands[0].Columns["DaGiaoHang"].Header.Caption = "Đã Giao Hàng";
            cmbu_DotGiaoHang.DisplayLayout.Bands[0].Columns["DaGiaoHang"].Header.VisiblePosition = 2;
            cmbu_DotGiaoHang.DisplayLayout.Bands[0].Columns["NoiDung"].Header.Caption = "Nội Dung";
            cmbu_DotGiaoHang.DisplayLayout.Bands[0].Columns["NoiDung"].Header.VisiblePosition = 3;
            this.cmbu_DotGiaoHang.DisplayLayout.Override.HeaderStyle = HeaderStyle.WindowsXPCommand;
            this.cmbu_DotGiaoHang.DisplayLayout.Override.HeaderAppearance.BackColor = System.Drawing.Color.SteelBlue;
            foreach (UltraGridColumn col in this.cmbu_DotGiaoHang.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;//x =  //= System.Drawing.w;//RoyalBlue
                if (col.DataType.ToString() == "System.DateTime")
                {
                    col.MaskInput = "{LOC}dd/mm/yyyy";
                    col.Format = "dd/MM/yyyy";
                }
            }

        }
        #endregion

        #region ultracmbKhoHangGiao_InitializeLayout
        private void ultracmbKhoHangGiao_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            this.cmbu_KhoHangGiao.DisplayLayout.Override.HeaderStyle = HeaderStyle.WindowsXPCommand;
            this.cmbu_KhoHangGiao.DisplayLayout.Override.HeaderAppearance.BackColor = System.Drawing.Color.SteelBlue;
            foreach (UltraGridColumn col in this.cmbu_KhoHangGiao.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;
                col.Hidden = true;
                //x =  //= System.Drawing.w;//RoyalBlue
            }            
            cmbu_KhoHangGiao.DisplayLayout.Bands[0].Columns["MaQuanLy"].Header.Caption = "Mã Kho";
            cmbu_KhoHangGiao.DisplayLayout.Bands[0].Columns["MaQuanLy"].Header.VisiblePosition = 1;
            cmbu_KhoHangGiao.DisplayLayout.Bands[0].Columns["MaQuanLy"].Hidden = false;
            cmbu_KhoHangGiao.DisplayLayout.Bands[0].Columns["TenKho"].Header.Caption = "Tên Kho";
            cmbu_KhoHangGiao.DisplayLayout.Bands[0].Columns["TenKho"].Header.VisiblePosition = 2;
            cmbu_KhoHangGiao.DisplayLayout.Bands[0].Columns["TenKho"].Hidden = false;
            

            

           
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

        #region ultracmbDiaChiGH_InitializeLayout

        private void ultracmbDiaChiGH_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {

            this.ultracmbDiaChiGH.DisplayLayout.Override.HeaderStyle = HeaderStyle.WindowsXPCommand;
            this.ultracmbDiaChiGH.DisplayLayout.Override.HeaderAppearance.BackColor = System.Drawing.Color.SteelBlue;
            foreach (UltraGridColumn col in this.ultracmbDiaChiGH.DisplayLayout.Bands[0].Columns)
            {
                col.Hidden = true;
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;//x =  //= System.Drawing.w;//RoyalBlue
            }
            ultracmbDiaChiGH.DisplayLayout.Bands[0].Columns["TenDiaChiChung"].Hidden = false;
            ultracmbDiaChiGH.DisplayLayout.Bands[0].Columns["TenDiaChiChung"].Header.Caption = " Địa Chỉ";
            ultracmbDiaChiGH.DisplayLayout.Bands[0].Columns["TenDiaChiChung"].Header.VisiblePosition = 1;
            ultracmbDiaChiGH.DisplayLayout.Bands[0].Columns["TenDiaChiChung"].Width = 250;
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

            ultraCbDonViTinh.DisplayLayout.Override.HeaderAppearance.BackColor = Color.SteelBlue;
            this.ultraCbDonViTinh.DisplayLayout.Override.HeaderStyle = HeaderStyle.WindowsXPCommand;

            foreach (UltraGridColumn col in this.ultraCbDonViTinh.DisplayLayout.Bands[0].Columns)
            {
                col.Hidden = true;
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = Color.Navy;
            }

            ultraCbDonViTinh.DisplayLayout.Bands[0].Columns["MaQuanLy"].Hidden = false;
            ultraCbDonViTinh.DisplayLayout.Bands[0].Columns["MaQuanLy"].Header.Caption = "Mã DVT";
            ultraCbDonViTinh.DisplayLayout.Bands[0].Columns["MaQuanLy"].Header.VisiblePosition = 0;

            ultraCbDonViTinh.DisplayLayout.Bands[0].Columns["TenDonViTinh"].Hidden = false;
            ultraCbDonViTinh.DisplayLayout.Bands[0].Columns["TenDonViTinh"].Header.Caption = "Tên Đơn Vị Tính";
            ultraCbDonViTinh.DisplayLayout.Bands[0].Columns["TenDonViTinh"].Header.VisiblePosition = 1;
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

        #region ultracmbDiaChiHD_InitializeLayout
        private void ultracmbDiaChiHD_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {

            this.ultracmbDiaChiHD.DisplayLayout.Override.HeaderStyle = HeaderStyle.WindowsXPCommand;
            this.ultracmbDiaChiHD.DisplayLayout.Override.HeaderAppearance.BackColor = System.Drawing.Color.SteelBlue;
            foreach (UltraGridColumn col in this.ultracmbDiaChiHD.DisplayLayout.Bands[0].Columns)
            {
                col.Hidden = true;
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;//x =  //= System.Drawing.w;//RoyalBlue
            }
            ultracmbDiaChiHD.DisplayLayout.Bands[0].Columns["TenDiaChiChung"].Hidden = false;
            ultracmbDiaChiHD.DisplayLayout.Bands[0].Columns["TenDiaChiChung"].Header.Caption = "Địa Chỉ";
            ultracmbDiaChiHD.DisplayLayout.Bands[0].Columns["TenDiaChiChung"].Header.VisiblePosition = 1;
            ultracmbDiaChiHD.DisplayLayout.Bands[0].Columns["TenDiaChiChung"].Width = 250;
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

        #region ultCbLoaiHang_InitializeLayout
        private void ultCbLoaiHang_InitializeLayout(object sender, InitializeLayoutEventArgs e)
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
            DoiTac _doiTac = new DoiTac();
            if (ultraCbKhachHang.Value != null && Convert.ToInt64(ultraCbKhachHang.Value) != 0)
            {
                //_doiTac = DoiTac.GetDoiTac(Convert.ToInt64(ultraCbKhachHang.ActiveRow.Cells["MaDoiTac"].Value));
                _doiTac = DoiTac.GetDoiTac(Convert.ToInt64(ultraCbKhachHang.Value));
                nguoiLienLacListbindingSource.DataSource = _doiTac.NguoiLienLacList;
                diaChi_DoiTacListbindingSource.DataSource = _doiTac.DiaChi_DoiTacList;
                doiTac_DienThoaiListbindingSource.DataSource = _doiTac.DoiTac_DienThoai_FaxList;
                diaChiDoiTacListBindingSource.DataSource = _doiTac.DiaChi_DoiTacList;
                ultratxtMaSoThue.Text = _doiTac.MaSoThue;
                if (_loai == 4 || _loai == 5)
                {
                    khoListBindingSource1.DataSource = KhoList.GetKhoList_KhoDaiLyByMaDaiLy(_doiTac.MaDoiTac);
                }
                else khoListBindingSource1.DataSource = KhoList.NewKhoList();
            }
            else
            {
                ultratxtMaSoThue.Text = string.Empty;
                nguoiLienLacListbindingSource.DataSource = NguoiLienLacList.NewNguoiLienLacList();
                diaChi_DoiTacListbindingSource.DataSource = DiaChi_DoiTacList.NewDiaChi_DoiTacList();
                diaChiDoiTacListBindingSource.DataSource = DiaChi_DoiTacList.NewDiaChi_DoiTacList();
                doiTac_DienThoaiListbindingSource.DataSource = DoiTac_DienThoai_FaxList.NewDoiTac_DienThoai_FaxList();
                khoListBindingSource1.DataSource = KhoList.NewKhoList();
               
            }
        }
        #endregion              

        #region cmbu_DotGiaoHang_ValueChanged
        private void cmbu_DotGiaoHang_ValueChanged(object sender, EventArgs e)
        {           
            if (cmbu_DotGiaoHang.ActiveRow != null && _donHangBan.IsNew )
            {                
                DotGiaoHangHDMB dotGiaoHangHDMB = (DotGiaoHangHDMB)dotGiaoHangListbindingSource.Current;                      
                _donHangBan = DonHangBan.NewDonHangBan(dotGiaoHangHDMB, _hopDongMuaBan, _quyTrinh);
                _donHangBan.Loai = _loai;
            }            
          
            donHangBanbindingSource.DataSource = _donHangBan;
            cTDonHangBanListBindingSource.DataSource = _donHangBan.CT_DonHangBanList;            
        }
        #endregion           

        #region cTDonHangBanListBindingSource_CurrentChanged

        private void cTDonHangBanListBindingSource_CurrentChanged(object sender, EventArgs e)
        {          
            decimal _tongTien = 0;
            foreach (CT_DonHangBan _ct_donHangBan in _donHangBan.CT_DonHangBanList)
            {
                _tongTien = _ct_donHangBan.SoTien + _tongTien;
            }

            _donHangBan.TongTien= _tongTien;           
        }

        #endregion

        #region ultraCbHangHoa_ValueChanged
        private void ultraCbHangHoa_ValueChanged(object sender, EventArgs e)
        {
            DonViTinh _donViTinh = DonViTinh.NewDonViTinh();
            _donViTinh.TenDonViTinh = "None";

            DonViTinh _donViTinh1 = DonViTinh.NewDonViTinh();
            _donViTinh1.TenDonViTinh = "None";
            //HangHoa _hangHoa ;
            if (ultraCbHangHoa.ActiveRow != null)
            {
                if(cmbu_KhoHangGiao.ActiveRow != null)
                    _hangHoa = HangHoa.GetHangHoa((int)ultraCbHangHoa.ActiveRow.Cells["MaHangHoa"].Value, Convert.ToInt32( cmbu_KhoHangGiao.ActiveRow.Cells["MaKho"].Value ));
                else 
                    _hangHoa = HangHoa.GetHangHoa((int)ultraCbHangHoa.ActiveRow.Cells["MaHangHoa"].Value, 0);
                ((CT_DonHangBan)(cTDonHangBanListBindingSource.Current)).MaHangHoa = _hangHoa.MaHangHoa;

                _DonViTinhList = _hangHoa.DanhSachDVT;
                _DonViTinhList.Insert(0, _donViTinh);
                donViTinhListBindingSource.DataSource = _DonViTinhList;

                _DonViTinhKhoiLuongList= _hangHoa.DanhSachDVKL;
                _DonViTinhKhoiLuongList.Insert(0, _donViTinh1);
                donViTinhListBindingSource1.DataSource = _DonViTinhKhoiLuongList;
                hangHoaBindingSource.DataSource = _hangHoa;
                txtTenSanPham.Text = _hangHoa.TenHangHoa;
                numeu_SoLuong.Value = _hangHoa.SoLuongTon;
            }
        }
        #endregion              

        #region ultraCbDonViTinh_ValueChanged
        private void ultraCbDonViTinh_ValueChanged(object sender, EventArgs e)
        {
            if (ultraCbDonViTinh.ActiveRow != null)
            {
                ((CT_DonHangBan)(cTDonHangBanListBindingSource.Current)).MaDonViTinh = (int)ultraCbDonViTinh.ActiveRow.Cells["MaDonViTinh"].Value;
            }
        }
        #endregion

        #region cmbu_LoaiHangHoa_ValueChanged
        private void cmbu_LoaiHangHoa_ValueChanged(object sender, EventArgs e)
        {
            //HangHoa _hangHoa = HangHoa.NewHangHoa();
            //_hangHoa.TenHangHoa = "None";
            //if (cmbu_LoaiHangHoa.ActiveRow != null)
            //{
            //    // _HangHoaList.Clear();
            //    _HangHoaList = HangHoaList.GetHangHoaList((int)cmbu_LoaiHangHoa.ActiveRow.Cells["MaLoaiHangHoa"].Value, 0);
            //    _HangHoaList.Insert(0, _hangHoa);
            //}

            //hangHoaListBindingSource.DataSource = _HangHoaList;

        }
        #endregion       
      
        #endregion     
       
        #region tlslblIn_Click
        private void tlslblIn_Click(object sender, EventArgs e)
        {
            if (_donHangBan.IsNew == false)
            {
                ReportDocument Report = new Report.Report_MuaBan.Report_DonHangBan();

                SqlCommand command = new SqlCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "spd_Report_DonHangBan";
                command.Parameters.AddWithValue("@MaDonHang", _donHangBan.MaDonHang);
                command.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable table = new DataTable();
                adapter.Fill(table);
                table.TableName = "spd_Report_DonHangBan;1";

                SqlCommand command1 = new SqlCommand();
                command1.CommandType = CommandType.StoredProcedure;
                command1.CommandText = "spd_Report_ReportHeader";
                command1.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);

                SqlDataAdapter adapter1 = new SqlDataAdapter(command1);
                DataTable table1 = new DataTable();
                adapter1.Fill(table1);
                table1.TableName = "spd_Report_ReportHeader;1";

                DataSet myDataSet = new DataSet();
                myDataSet.Tables.Add(table);
                myDataSet.Tables.Add(table1);
                Report.SetDataSource(myDataSet);      

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

        #region ultragrdDSChiTietHangHoa_AfterSelectChange
        private void ultragrdDSChiTietHangHoa_AfterSelectChange(object sender, AfterSelectChangeEventArgs e)
        {          
            if (grdu_ChiTietHangHoa.ActiveRow != null)
            {
                if (cTDonHangBanListBindingSource.Current != null)
                {
                    if (cmbu_KhoHangGiao.ActiveRow != null)
                        _hangHoa = HangHoa.GetHangHoa(((CT_DonHangBan)(cTDonHangBanListBindingSource.Current)).MaHangHoa, Convert.ToInt32(cmbu_KhoHangGiao.ActiveRow.Cells["MaKho"].Value));
                    else _hangHoa = HangHoa.GetHangHoa(((CT_DonHangBan)(cTDonHangBanListBindingSource.Current)).MaHangHoa, 0);
                    txtTenSanPham.Text = _hangHoa.TenHangHoa;
                    numeu_SoLuong.Value = _hangHoa.SoLuongTon;
                }         
            }

        }
        #endregion

        #region ultragrdDSChiTietHangHoa_Leave
        private void ultragrdDSChiTietHangHoa_Leave(object sender, EventArgs e)
        {
            grdu_ChiTietHangHoa.UpdateData();
            decimal _tongTien = 0;
          
            foreach (CT_DonHangBan _ct_donHangBan in _donHangBan.CT_DonHangBanList)
            {
                _tongTien = _ct_donHangBan.SoTien + _tongTien;                
            }
            _donHangBan.ThanhTien = _tongTien;            

           // KiemTraHangHoaBiTrung();
        }
        #endregion

        #region ultragrdDSChiTietHangHoa_KeyDown
        private void ultragrdDSChiTietHangHoa_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                grdu_ChiTietHangHoa.UpdateData();
                decimal _tongTien = 0;               
                foreach (CT_DonHangBan _ct_donHangBan in _donHangBan.CT_DonHangBanList)
                {
                    _tongTien = _ct_donHangBan.SoTien + _tongTien;
                }
                _donHangBan.ThanhTien = _tongTien;    
            }
        }
        #endregion

        #region tlslblLapHoaDon_Click
        private void tlslblLapHoaDon_Click(object sender, EventArgs e)
        {
            if (_donHangBan.IsNew != true)
            {
                if (_donHangBan.TinhTrang == 0)
                {
                    frmHoaDonTuDonHang dlg = new frmHoaDonTuDonHang(_donHangBan);                    
                    if (dlg.ShowDialog() != DialogResult.OK)
                    {
                        _donHangBan = DonHangBan.GetDonHangBan(_donHangBan.MaDonHang);
                    }
                }
                else
                {
                    HoaDon _hoaDon = HoaDon.GetHoaDonByMaDonHang(_donHangBan.MaDonHang);
                    frmHoaDonTuDonHang dlg = new frmHoaDonTuDonHang(_hoaDon, _donHangBan);
                    if (dlg.ShowDialog() != DialogResult.OK)
                    {
                        _donHangBan = DonHangBan.GetDonHangBan(_donHangBan.MaDonHang);
                    }
                    
                }
            }
            else
            {
                MessageBox.Show(this, "Vui Lòng Cập Nhật Đơn Hàng Trước Khi Lập Hóa Đơn", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        #endregion

        #region txt_HopDong_KeyDown
        private void txt_HopDong_KeyDown(object sender, KeyEventArgs e)
        {
            HopDongMuaBanList _hopDongMuaBanList;
            
            if (e.KeyCode == Keys.Enter)
            {
                _hopDongMuaBanList = HopDongMuaBanList.GetHopDongMuaBanList(_loaiHopDong, txt_HopDong.Text, true);
                frmTimHopDong dlg = new frmTimHopDong(_hopDongMuaBanList, txt_HopDong.Text, _loaiHopDong);
                if (dlg.ShowDialog() != DialogResult.OK)
                {
                    _hopDongMuaBan = dlg.HopDongMuaBan;                                       
                    dotGiaoHangListbindingSource.DataSource = _hopDongMuaBan.DotGiaoHangHDMBList;                 
                    if(_hopDongMuaBan.MaHopDong == 0)
                    {
                        _donHangBan.CT_DonHangBanList = CT_DonHangBanList.NewCT_DonHangBanList();
                        cTDonHangBanListBindingSource.DataSource = _donHangBan.CT_DonHangBanList;
                    }                    
                }                
                txt_HopDong.Text = _hopDongMuaBan.SoHopDong;                             
            }
        }
        #endregion

        #region ultragrdDSChiTietHangHoa_AfterCellUpdate
        private void ultragrdDSChiTietHangHoa_AfterCellUpdate(object sender, CellEventArgs e)
        {
            grdu_ChiTietHangHoa.UpdateData();
            decimal _soTienChietKhau = 0;
            if(grdu_ChiTietHangHoa.ActiveCell == grdu_ChiTietHangHoa.ActiveRow.Cells["TenHangHoa"])
            {
                KiemTraHangHoaBiTrung();
            }
            else if (grdu_ChiTietHangHoa.ActiveCell == grdu_ChiTietHangHoa.ActiveRow.Cells["ChietKhau"])
            {
                foreach (CT_DonHangBan _ct_donHangBan in _donHangBan.CT_DonHangBanList)
                {                    
                    _soTienChietKhau = _ct_donHangBan.SoTienChietKhau + _soTienChietKhau;
                }                
                _donHangBan.SoTienUuDai = _soTienChietKhau; 

            }
            if (grdu_ChiTietHangHoa.ActiveCell == grdu_ChiTietHangHoa.ActiveRow.Cells["SoLuong"])
            {
                if (((CT_DonHangBan)cTDonHangBanListBindingSource.Current).SoLuong > _hangHoa.SoLuongTon)
                { 
                    MessageBox.Show(this,"Hàng Hóa Không Đủ Số Lượng Bán","Thông Báo",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                }               
            }

            if (grdu_ChiTietHangHoa.ActiveCell == grdu_ChiTietHangHoa.ActiveRow.Cells["KhoiLuongVang"])
            {
                if (((CT_DonHangBan)cTDonHangBanListBindingSource.Current).KhoiLuongVang > _hangHoa.KhoiLuongTon)
                {
                    MessageBox.Show(this, "Hàng Hóa Không Đủ Khối Lượng Bán", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
        #endregion 

        #region cmbeu_LoaiDonHang_Leave
        private void cmbeu_LoaiDonHang_Leave(object sender, EventArgs e)
        {
            //if (cmbeu_LoaiDonHang.Value != null)
            //{
            //    if (_donHangBan.Loai == 0)
            //    {
            //        _doiTacList = DoiTacList.GetDoiTacListTheoLoaiKhachHang(6);

            //    }
            //    else _doiTacList = DoiTacList.GetDoiTacListTheoLoaiKhachHang(_donHangBan.Loai);
            //    DoiTac doiTac = DoiTac.NewDoiTac(0, "Thêm Mới.....");
            //    _doiTacList.Insert(0, doiTac);
            //    doiTacListbindingSource.DataSource = _doiTacList;
            //}
        }
        #endregion 

        #region ultraCbKhachHang_AfterCloseUp
        private void ultraCbKhachHang_AfterCloseUp(object sender, EventArgs e)
        {
            if (ultraCbKhachHang.ActiveRow != null)
            {
                if ( Convert.ToInt32(ultraCbKhachHang.Value) == 0 && flag != 0)
                {
                    frmKhachHang dlg = new frmKhachHang();                    
                    if (dlg.ShowDialog() != DialogResult.OK)
                    {
                        _doiTacList = DoiTacList.GetDoiTacList();
                        DoiTac doiTac = DoiTac.NewDoiTac(0, "Thêm Mới......");
                        _doiTacList.Insert(0, doiTac);
                        doiTacListbindingSource.DataSource = _doiTacList;
                    }
                }               
            }
            flag++; 
        }
        #endregion 

        #region tlslbl_InMau2_Click
        private void tlslbl_InMau2_Click(object sender, EventArgs e)
        {
            if (_donHangBan.IsNew == false)
            {
                ReportDocument Report = new Report.Report_MuaBan.Report_DonHangBan_XiNghiep();

                SqlCommand command = new SqlCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "spd_Report_DonHangBan_XiNghiep";
                command.Parameters.AddWithValue("@MaDonHang", _donHangBan.MaDonHang);
                command.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable table = new DataTable();
                adapter.Fill(table);
                table.TableName = "spd_Report_DonHangBan_XiNghiep;1";

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
                Report.SetParameterValue("@MaDonHang", _donHangBan.MaDonHang); 

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

        #region grdu_ChiTietHangHoa_Error
        private void grdu_ChiTietHangHoa_Error(object sender, ErrorEventArgs e)
        {
            if(e.ErrorType == ErrorType.Data)
                 e.ErrorText = "Kiểu dữ liệu không hợp lệ";
        }
        #endregion       

        private void frmDonHangBan_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                Main.frmMain.LoadHelp(this, "Don Hang", "Help_BanHang.chm");
            }
        }

        private void frmDonHangBan_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                Main.frmMain.LoadHelp(this, "Don Hang", "Help_BanHang.chm");
            }
        }

        #region ultraCbHangHoa_AfterCloseUp
        private void ultraCbHangHoa_AfterCloseUp(object sender, EventArgs e)
        {
            if (ultraCbHangHoa.ActiveRow != null)
            {
                if (ultraCbHangHoa.ActiveRow.Index == 0)
                {
                    frmHangHoa frm = new frmHangHoa();
                    if (frm.ShowDialog() != DialogResult.OK)
                    {
                        _HangHoaList = HangHoaList.GetHangHoaList();
                        HangHoa _hangHoa = HangHoa.NewHangHoa("Thêm Mới", 0);
                        _HangHoaList.Insert(0, _hangHoa);
                        hangHoaListBindingSource.DataSource = _HangHoaList;
                    }
                }
            }
            return;
        }
        #endregion 
    }
}

