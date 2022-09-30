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
    public partial class frmDonMuaHang : Form
    {

        #region Properties
        Util util = new Util();
        HamDungChung hamDungChung = new HamDungChung();
        DonHangMua _donHangMua;
        DotGiaoHangHDMBList _dotGiaoHangHDMBList;
        HopDongMuaBanList _HopDongMuaBanList;
        HangHoaList _HangHoaList = HangHoaList.NewHangHoaList();
        DonViTinhList _DonViTinhKhoiLuongList = DonViTinhList.NewDonViTinhList();
        DonViTinhList _DonViTinhList = DonViTinhList.NewDonViTinhList();
        HopDongMuaBan _hopDongMuaBan = HopDongMuaBan.NewHopDongMuaBan();
        DoiTacList _doiTacList;
        HangHoa _HangHoa;
        byte _loai = 0;
        byte _loaiHopDong = 0;
        int flag = 0;
        byte _quyTrinh = 0;

        #endregion

        #region Contructor
        public frmDonMuaHang()
        {
            InitializeComponent();
            KhaiBaoSuKienForm();
            KhoiTao();
            Invisible();
        }    

        public frmDonMuaHang(byte loai, byte quyTrinh)
        {
            InitializeComponent();
            KhaiBaoSuKienForm();
            KhoiTao(loai, quyTrinh);
            Invisible();
        }       
        public frmDonMuaHang(DonHangMua donHangMua)
        {
            InitializeComponent();
            KhaiBaoSuKienForm();
            KhoiTao(donHangMua);
            Invisible();
        }
        #endregion

        #region Khai Báo Sự Kiện Form
        private void KhaiBaoSuKienForm()
        {
            hamDungChung.EventForm(this);
            hamDungChung.EventGrid(grdu_DSChiTietHangHoa);
            hamDungChung.EventsControl(cmbu_KhoHangGiao);
            hamDungChung.EventsControl(ultraCbKhachHang);
            hamDungChung.EventsControl(ultraCbLoaiTien);
            hamDungChung.EventsControl(ultracmbDienThoai);
            hamDungChung.EventsControl(ultracmbDotGiaoHang);
            hamDungChung.EventsControl(ultracmbNguoiLienLac);            

        }
        #endregion 

        #region Khởi Tạo

        private void KhoiTao()
        {
            _donHangMua = DonHangMua.NewDonHangMua(0);            

            donHangMuabindingSource.DataSource = _donHangMua;

            cTDonHangMuaListBindingSource.DataSource = _donHangMua.CT_DonHangBanList;

            doiTacListBindingSource.DataSource = DoiTacList.GetDoiTacListTheoLoaiKhachHang(5);

            khoListBindingSource.DataSource = KhoList.GetKhoList_LoaiKho(0);

            donViTinhListBindingSource.DataSource = DonViTinhList.GetDonViTinhList();            

            loaiTienListBindingSource.DataSource = LoaiTienList.GetLoaiTienList();

            hangHoaListBindingSource.DataSource = HangHoaList.GetHangHoaList();

             if (_donHangMua.Loai == 0)
            {
                _doiTacList = DoiTacList.GetDoiTacListTheoLoaiKhachHang(2);                
                
            }
            else _doiTacList= DoiTacList.GetDoiTacListTheoLoaiKhachHang(_donHangMua.Loai);
            DoiTac doiTac = DoiTac.NewDoiTac(0, "Thêm Mới.....");
            _doiTacList.Insert(0, doiTac);
            doiTacListBindingSource.DataSource = _doiTacList;


         
        }

        private void KhoiTao(byte loai, byte quyTrinh)
        {
            _donHangMua = DonHangMua.NewDonHangMua(0);

            _donHangMua.Loai = loai;
            _donHangMua.QuyTrinh = quyTrinh;
            _loai = loai;
            _quyTrinh = quyTrinh;

            donHangMuabindingSource.DataSource = _donHangMua;

            cTDonHangMuaListBindingSource.DataSource = _donHangMua.CT_DonHangBanList;
           
           // doiTacListBindingSource.DataSource = DoiTacList.GetDoiTacListTheoLoaiKhachHang(5);

            khoListBindingSource.DataSource = KhoList.GetKhoList_LoaiKho(0);        

            donViTinhListBindingSource.DataSource = DonViTinhList.GetDonViTinhList();            

            loaiTienListBindingSource.DataSource = LoaiTienList.GetLoaiTienList();

            _doiTacList = DoiTacList.GetDoiTacList();

            //if (_donHangMua.Loai == 0)
            //{
            //    _doiTacList = DoiTacList.GetDoiTacListTheoLoaiKhachHang(2);

            //}
            //else _doiTacList= DoiTacList.GetDoiTacListTheoLoaiKhachHang(_donHangMua.Loai);
            DoiTac doiTac = DoiTac.NewDoiTac(0, "Thêm Mới......");
            _doiTacList.Insert(0, doiTac);
            doiTacListBindingSource.DataSource = _doiTacList;
            _HangHoaList = HangHoaList.GetHangHoaList();
            HangHoa _HangHoa = HangHoa.NewHangHoa("Thêm Mới", 0);
            _HangHoaList.Insert(0, _HangHoa);
            hangHoaListBindingSource.DataSource = _HangHoaList;

            if (_loai == 0)
                _loaiHopDong = 0;
            else if (_loai == 3)
                _loaiHopDong = 1;
            else if (_loai == 5)
                _loaiHopDong = 7;
            
         
        }

        private void KhoiTao(DonHangMua donHangMua)
        {
            _donHangMua = donHangMua;

            _loai = _donHangMua.Loai;

            _quyTrinh = _donHangMua.QuyTrinh;

            donHangMuabindingSource.DataSource = _donHangMua;

            donViTinhListBindingSource.DataSource = DonViTinhList.GetDonViTinhList();

            hangHoaListBindingSource.DataSource = HangHoaList.GetHangHoaList();

            loaiTienListBindingSource.DataSource = LoaiTienList.GetLoaiTienList();           

            khoListBindingSource.DataSource = KhoList.GetKhoList_LoaiKho(0);

            _hopDongMuaBan = HopDongMuaBan.GetHopDongMuaBan(_donHangMua.MaHopDongMua);

            txt_HopDong.Text = _hopDongMuaBan.SoHopDong;

            dotGiaoHangHDMBListBindingSource.DataSource = _hopDongMuaBan.DotGiaoHangHDMBList;           

            cTDonHangMuaListBindingSource.DataSource = _donHangMua.CT_DonHangBanList;

            _doiTacList = DoiTacList.GetDoiTacList();
            //if (_donHangMua.Loai == 0)
            //{
            //    _doiTacList = DoiTacList.GetDoiTacListTheoLoaiKhachHang(2);

            //}
            //else _doiTacList = DoiTacList.GetDoiTacListTheoLoaiKhachHang(_donHangMua.Loai);
            DoiTac doiTac = DoiTac.NewDoiTac(0, "Thêm Mới.....");
            _doiTacList.Insert(0, doiTac);
            doiTacListBindingSource.DataSource = _doiTacList;

            if (_loai == 0)
                _loaiHopDong = 0;
            else if (_loai == 3)
                _loaiHopDong = 1;
            else if (_loai == 5)
                _loaiHopDong = 7;
           
          
        }

        #endregion

        #region Invisible Button
        private void Invisible()
        {
            //tlslblXoa.Available = false;
            //tlslblUndo.Available = false;
            //tlslblTim.Available = false;
            //tlslblTroGiup.Available = false;
            cmbeu_LoaiDonHang.Enabled = true;
            if (_quyTrinh == 0)
                tlslblLapHoaDon.Visible = false;
            else
                tlslblLapHoaDon.Visible = true;

            if (_loai == 1 || _loai == 2 || _loai == 4 )
            {
                _donHangMua.MaHopDongMua = 0;
                txt_HopDong.Enabled = false;
                ultracmbDotGiaoHang.Enabled = false;
                gb_UuDai.Visible = false;
            }
            else
            {
                txt_HopDong.Enabled = true;
                ultracmbDotGiaoHang.Enabled = true;
                gb_UuDai.Visible = true;
            }
        }
        #endregion 

        #region Kiểm Tra Dữ Liệu Trước Khi Lưu

        private bool KiemTraDuLieu()
        {
            bool kq = true;
            //if (ultratxtSoDonHang.Text == string.Empty)
            //{
            //   MessageBox.Show(this, util.nhapsodonhang, util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    ultratxtSoDonHang.Focus();
            //    return false;
            //}
            //if (_donHangMua.IsNew == true && DonHangMua.KiemTraSoDonHangTonTai(ultratxtSoDonHang.Text.Trim()) == false)
            //{
            //    MessageBox.Show(this, util.sodonhangkohople, util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    ultratxtSoDonHang.Focus();
            //    return false;
            //}
             if (_donHangMua.MaDotNhanHang != 0 && _donHangMua.IsNew == true && DotGiaoHangHDMB.GetDotGiaoHangHDMB(_donHangMua.MaDotNhanHang).DaGiaoHang == true)
            {
                MessageBox.Show(this, "Đợt Nhận Hàng Đã Được Thực Hiện. Vui Lòng Chọn Đợt Nhận Hàng Khác", util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ultracmbDotGiaoHang.Focus();
                return false;
            }
            //else if (_donHangMua.MaKho == 0)
            //{
            //    MessageBox.Show(this, "Vui Lòng Chọn Kho Hàng Mua", util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    cmbu_KhoHangGiao.Focus();
            //    return false;
            //}
            else if (_donHangMua.MaDoiTac == 0)
            {
                MessageBox.Show(this, "Vui Lòng Chọn Đối Tác", util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ultraCbKhachHang.Focus();
                return false;
            }           
            else if (_donHangMua.CT_DonHangBanList.Count == 0)
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
            for (int i = 0; i < _donHangMua.CT_DonHangBanList.Count; i++)
            {
                for (int j = 0; j < _donHangMua.CT_DonHangBanList.Count; j++)
                {
                    if (i != j)
                    {
                        if (_donHangMua.CT_DonHangBanList[i].MaHangHoa == _donHangMua.CT_DonHangBanList[j].MaHangHoa)
                        {
                            HangHoa hangHoa = HangHoa.GetHangHoa(_donHangMua.CT_DonHangBanList[i].MaHangHoa);
                            MessageBox.Show(this, "Hàng hóa" + hangHoa.TenHangHoa.ToString() + " bị trùng", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            //grdu_DSChiTietHangHoa.ActiveRow = grdu_DSChiTietHangHoa.Rows[i];
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
                if (_donHangMua.IsNew)
                {
                    _donHangMua.SoDonHang = DonHangMua.SoDonHangTuDongTang(_donHangMua.Loai, _donHangMua.NgayLap);
                    donHangMuabindingSource.EndEdit();
                    _donHangMua.Save();
                    if (_quyTrinh == 0)
                    {
                        LenhNhapXuatMuaBan _lenhNhapXuatMuaBan = LenhNhapXuatMuaBan.NewLenhNhapXuatMuaBan(_donHangMua, true, _loai);
                        _lenhNhapXuatMuaBan.Save();
                    }
                }
                else
                {
                    if (_donHangMua.IsDirty)
                    {
                        donHangMuabindingSource.EndEdit();
                        _donHangMua.Save();
                        if (_quyTrinh == 0)
                        {
                            LenhNhapXuatMuaBanList _LenhNhapXuatMuaBanList = LenhNhapXuatMuaBanList.GetLenhNhapXuatMuaBanListByDonHang(_donHangMua.MaDonHang);
                            _LenhNhapXuatMuaBanList.Clear();
                            _LenhNhapXuatMuaBanList.Save();
                            LenhNhapXuatMuaBan _lenhNhapXuatMuaBan = LenhNhapXuatMuaBan.NewLenhNhapXuatMuaBan(_donHangMua, true, _loai);
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

        #region tlslblLuu_Click

        private void tlslblLuu_Click(object sender, EventArgs e)
        {

            grdu_DSChiTietHangHoa.UpdateData();
            decimal _tongTien = 0;              
            foreach (CT_DonHangMua _ct_donHangMua in _donHangMua.CT_DonHangBanList)
            {
                _tongTien = _ct_donHangMua.ThanhTien + _tongTien;                    
            }
            _donHangMua.ThanhTien = _tongTien;
            donHangMuabindingSource.EndEdit();
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
                        //else MessageBox.Show(this, "Cập Nhật Không Thành Công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
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
            if (MessageBox.Show(this, util.thaoTac, util.thongbao, MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
                this.Close();
        }
        #endregion

        #region InitializeLayout

        #region ultragrdDSChiTietHangHoa_InitializeLayout
        private void ultragrdDSChiTietHangHoa_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            //grdu_DSChiTietHangHoa.DisplayLayout.Bands[0].Columns["TenLoaiHangHoa"].Header.VisiblePosition = 1;
            //grdu_DSChiTietHangHoa.DisplayLayout.Bands[0].Columns["TenLoaiHangHoa"].Header.Caption = "Loại Hàng Hóa";
            //grdu_DSChiTietHangHoa.DisplayLayout.Bands[0].Columns["TenLoaiHangHoa"].EditorComponent = ultCbLoaiHang;
            grdu_DSChiTietHangHoa.DisplayLayout.Bands[0].Columns["TenLoaiHangHoa"].Hidden = true;
            grdu_DSChiTietHangHoa.DisplayLayout.Bands[0].Columns["KhoiLuongVang"].Hidden = true;

            grdu_DSChiTietHangHoa.DisplayLayout.Bands[0].Columns["MaChiTiet"].Hidden = true;
            grdu_DSChiTietHangHoa.DisplayLayout.Bands[0].Columns["MaDonHang"].Hidden = true;
            grdu_DSChiTietHangHoa.DisplayLayout.Bands[0].Columns["HangTraLai"].Hidden = true;
            grdu_DSChiTietHangHoa.DisplayLayout.Bands[0].Columns["MaHangHoa"].Hidden = true;
            grdu_DSChiTietHangHoa.DisplayLayout.Bands[0].Columns["SoTienChietKhau"].Hidden = true;
            grdu_DSChiTietHangHoa.DisplayLayout.Bands[0].Columns["ChietKhau"].Hidden = true;

            grdu_DSChiTietHangHoa.DisplayLayout.Bands[0].Columns["TenHangHoa"].Header.Caption = "Thể Loại";
            grdu_DSChiTietHangHoa.DisplayLayout.Bands[0].Columns["TenHangHoa"].Header.VisiblePosition = 1;
            grdu_DSChiTietHangHoa.DisplayLayout.Bands[0].Columns["TenHangHoa"].EditorComponent = ultraCbHangHoa;

            grdu_DSChiTietHangHoa.DisplayLayout.Bands[0].Columns["DienGiai"].Header.Caption = "Hàng Hóa/Dịch Vụ";
            grdu_DSChiTietHangHoa.DisplayLayout.Bands[0].Columns["DienGiai"].Header.VisiblePosition = 2;

            grdu_DSChiTietHangHoa.DisplayLayout.Bands[0].Columns["SoLuong"].Header.Caption = "Số Lượng";
            grdu_DSChiTietHangHoa.DisplayLayout.Bands[0].Columns["SoLuong"].Header.VisiblePosition = 3;
            grdu_DSChiTietHangHoa.DisplayLayout.Bands[0].Columns["SoLuong"].MaskInput = "nnnnnnnnn";

            grdu_DSChiTietHangHoa.DisplayLayout.Bands[0].Columns["MaDonViTinh"].Hidden = true;
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
            grdu_DSChiTietHangHoa.DisplayLayout.Bands[0].Columns["ThanhTien"].CellActivation = Activation.NoEdit;

            
            
            this.grdu_DSChiTietHangHoa.DisplayLayout.Override.HeaderStyle = HeaderStyle.WindowsXPCommand;
            this.grdu_DSChiTietHangHoa.DisplayLayout.Override.HeaderAppearance.BackColor = System.Drawing.Color.SteelBlue;
            foreach (UltraGridColumn col in this.grdu_DSChiTietHangHoa.DisplayLayout.Bands[0].Columns)
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
            ultracmbDotGiaoHang.DisplayLayout.Bands[0].Columns["MaChiTiet"].Hidden = true;
            ultracmbDotGiaoHang.DisplayLayout.Bands[0].Columns["MaHopDongMuaBan"].Hidden = true;
            ultracmbDotGiaoHang.DisplayLayout.Bands[0].Columns["MaPhuongThucGiaoNhan"].Hidden = true;
            ultracmbDotGiaoHang.DisplayLayout.Bands[0].Columns["NgayGiao"].Header.Caption = "Ngày Giao";
            ultracmbDotGiaoHang.DisplayLayout.Bands[0].Columns["NgayGiao"].Header.VisiblePosition = 1;
            ultracmbDotGiaoHang.DisplayLayout.Bands[0].Columns["NgayGiao"].MaskInput = "{LOC}dd/mm/yyyy";
            ultracmbDotGiaoHang.DisplayLayout.Bands[0].Columns["MaDiaChi"].Hidden = true;
            ultracmbDotGiaoHang.DisplayLayout.Bands[0].Columns["NoiDung"].Header.Caption = "Nội Dung";
            ultracmbDotGiaoHang.DisplayLayout.Bands[0].Columns["NoiDung"].Header.VisiblePosition = 3;
            ultracmbDotGiaoHang.DisplayLayout.Bands[0].Columns["DaGiaoHang"].Header.Caption = "Đã Giao Hàng";
            ultracmbDotGiaoHang.DisplayLayout.Bands[0].Columns["DaGiaoHang"].Header.VisiblePosition = 2;
            this.ultracmbDotGiaoHang.DisplayLayout.Override.HeaderStyle = HeaderStyle.WindowsXPCommand;
            this.ultracmbDotGiaoHang.DisplayLayout.Override.HeaderAppearance.BackColor = System.Drawing.Color.SteelBlue;
            foreach (UltraGridColumn col in this.ultracmbDotGiaoHang.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;//x =  //= System.Drawing.w;//RoyalBlue
            }
        }
        #endregion

        #region ultracmbKhoHangGiao_InitializeLayout
        private void ultracmbKhoHangGiao_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            cmbu_KhoHangGiao.DisplayLayout.Bands[0].Columns["MaKho"].Hidden = true;
            cmbu_KhoHangGiao.DisplayLayout.Bands[0].Columns["MaNhanCong"].Hidden = true;
            cmbu_KhoHangGiao.DisplayLayout.Bands[0].Columns["KhoDaiLy"].Hidden = true;
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
            cmbu_KhoHangGiao.DisplayLayout.Bands[0].Columns["MaDoiTac"].Hidden = true;

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

        #region ultraCbLoaiTien_InitializeLayout
        private void ultraCbLoaiTien_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            ultraCbLoaiTien.DisplayLayout.Bands[0].Columns["MaLoaiTien"].Hidden = true;
            ultraCbLoaiTien.DisplayLayout.Bands[0].Columns["TiGiaQuyDoi"].Header.Caption = "Tỷ Giá Quy Đổi";
            ultraCbLoaiTien.DisplayLayout.Bands[0].Columns["TiGiaQuyDoi"].Header.VisiblePosition = 3;
            ultraCbLoaiTien.DisplayLayout.Bands[0].Columns["TenLoaiTien"].Header.Caption = "Tên Loại Tiền";
            ultraCbLoaiTien.DisplayLayout.Bands[0].Columns["TenLoaiTien"].Header.VisiblePosition = 2;
            ultraCbLoaiTien.DisplayLayout.Bands[0].Columns["MaLoaiQuanLy"].Header.Caption = "Mã Quản Lý";
            ultraCbLoaiTien.DisplayLayout.Bands[0].Columns["MaLoaiQuanLy"].Header.VisiblePosition = 1;
            this.ultraCbLoaiTien.DisplayLayout.Override.HeaderStyle = HeaderStyle.WindowsXPCommand;
            this.ultraCbLoaiTien.DisplayLayout.Override.HeaderAppearance.BackColor = System.Drawing.Color.SteelBlue;
            foreach (UltraGridColumn col in this.ultraCbLoaiTien.DisplayLayout.Bands[0].Columns)
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
            ultraCbDonViTinh.DisplayLayout.Bands[0].Columns["MaQuanLy"].Header.VisiblePosition = 1;
            ultraCbDonViTinh.DisplayLayout.Bands[0].Columns["MaQuanLy"].Header.Caption = "Mã DVT";
            ultraCbDonViTinh.DisplayLayout.Bands[0].Columns["DienGiai"].Hidden = true;
            ultraCbDonViTinh.DisplayLayout.Bands[0].Columns["TenDonViTinh"].Header.VisiblePosition = 2;
            ultraCbDonViTinh.DisplayLayout.Bands[0].Columns["TenDonViTinh"].Header.Caption = "Tên Đơn Vị Tính";
            this.ultraCbDonViTinh.DisplayLayout.Override.HeaderStyle = HeaderStyle.WindowsXPCommand;
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

            //ultraCbHangHoa.DisplayLayout.Bands[0].Columns["DonGiaBanKL"].Header.Caption = "Đơn Giá";
            //ultraCbHangHoa.DisplayLayout.Bands[0].Columns["DonGiaBanKL"].Header.VisiblePosition = 3;
            //ultraCbHangHoa.DisplayLayout.Bands[0].Columns["DonGiaBanKL"].Hidden = false;

        }
        #endregion

        #region ultCbLoaiHang_InitializeLayout
        private void ultCbLoaiHang_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            this.ultCbLoaiHang.DisplayLayout.Override.HeaderStyle = HeaderStyle.WindowsXPCommand;
            this.ultCbLoaiHang.DisplayLayout.Override.HeaderAppearance.BackColor = System.Drawing.Color.SteelBlue;
            foreach (UltraGridColumn col in this.ultCbLoaiHang.DisplayLayout.Bands[0].Columns)
            {
                col.Hidden = true;
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;//x =  //= System.Drawing.w;//RoyalBlue
            }
            ultCbLoaiHang.DisplayLayout.Bands[0].Columns["MaQuanLy"].Hidden = false;
            ultCbLoaiHang.DisplayLayout.Bands[0].Columns["MaQuanLy"].Header.Caption = "Mã Loại Hàng";
            ultCbLoaiHang.DisplayLayout.Bands[0].Columns["MaQuanLy"].Header.VisiblePosition = 0;

            ultCbLoaiHang.DisplayLayout.Bands[0].Columns["TenLoaiHangHoa"].Hidden = false;
            ultCbLoaiHang.DisplayLayout.Bands[0].Columns["TenLoaiHangHoa"].Header.Caption = "Tên Loại Hàng Hóa";
            ultCbLoaiHang.DisplayLayout.Bands[0].Columns["TenLoaiHangHoa"].Header.VisiblePosition = 1;
        }
        #endregion

     
        #endregion

        #region ValueChanged

        #region ultraCbKhachHang_ValueChanged
        private void ultraCbKhachHang_ValueChanged(object sender, EventArgs e)
        {
            DoiTac _doiTac = new DoiTac();
            if (ultraCbKhachHang.Value != null)
            {
               // _doiTac = DoiTac.GetDoiTac((long)ultraCbKhachHang.ActiveRow.Cells["MaDoiTac"].Value);
                _doiTac = DoiTac.GetDoiTac((long)ultraCbKhachHang.Value);
                nguoiLienLacListBindingSource.DataSource = _doiTac.NguoiLienLacList;                
                doiTacDienThoaiFaxListBindingSource.DataSource = _doiTac.DoiTac_DienThoai_FaxList;
                ultratxtMaSoThue.Value = _doiTac.MaSoThue;
            }
            else
            {
                ultratxtMaSoThue.Value = String.Empty;
                nguoiLienLacListBindingSource.DataSource = NguoiLienLacList.NewNguoiLienLacList();
                doiTacDienThoaiFaxListBindingSource.DataSource = DoiTac_DienThoai_FaxList.NewDoiTac_DienThoai_FaxList();
            }
        }
        #endregion                    

        #region ultracmbDotGiaoHang_ValueChanged
        private void ultracmbDotGiaoHang_ValueChanged(object sender, EventArgs e)
        {           
           
                if (ultracmbDotGiaoHang.ActiveRow != null)
                {
                    decimal tongTien = 0;
                    DotGiaoHangHDMB _dotGiaoHangHDMB = DotGiaoHangHDMB.NewDotGiaoHangHDMB();
                    _donHangMua.MaDotNhanHang = Convert.ToInt32(ultracmbDotGiaoHang.Value);
                    _donHangMua.CT_DonHangBanList.Clear();
                    CT_DotGiaoHangHDMBList ctDotGiaoHangHDMBList = CT_DotGiaoHangHDMBList.NewCT_DotGiaoHangHDMBList();
                    _dotGiaoHangHDMB= ((DotGiaoHangHDMB)dotGiaoHangHDMBListBindingSource.Current);
                    ctDotGiaoHangHDMBList = _dotGiaoHangHDMB.CT_DotGiaoHangHDMBList;
                    _donHangMua.ChiPhiVanChuyen = _dotGiaoHangHDMB.ChiPhiVanChuyen;
                    foreach (CT_DotGiaoHangHDMB ctDotGiaoHangHDMB in ctDotGiaoHangHDMBList)
                    {
                        _donHangMua.CT_DonHangBanList.Add(CT_DonHangMua.NewCT_DonHangMua(ctDotGiaoHangHDMB));
                        tongTien = tongTien + ctDotGiaoHangHDMB.ThanhTien;                      
                    }
                    _donHangMua.ThanhTien = tongTien;
                }
                //else
                //{
                //    _donHangMua.CT_DonHangBanList = CT_DonHangMuaList.NewCT_DonHangMuaList();                    
                //}
           
            cTDonHangMuaListBindingSource.DataSource = _donHangMua.CT_DonHangBanList;
        }
        #endregion

      
        #region ultraCbDonViTinh_ValueChanged
        private void ultraCbDonViTinh_ValueChanged(object sender, EventArgs e)
        {
            if (ultraCbDonViTinh.ActiveRow != null)
            {
                ((CT_DonHangMua)(cTDonHangMuaListBindingSource.Current)).MaDonViTinh = (int)ultraCbDonViTinh.ActiveRow.Cells["MaDonViTinh"].Value;
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
                ((CT_DonHangMua)(cTDonHangMuaListBindingSource.Current)).MaHangHoa = _hangHoa.MaHangHoa;

                _DonViTinhList = _hangHoa.DanhSachDVT;
                _DonViTinhList.Insert(0, _donViTinh);
                donViTinhListBindingSource.DataSource = _DonViTinhList;

                _DonViTinhKhoiLuongList = _hangHoa.DanhSachDVKL;
                _DonViTinhKhoiLuongList.Insert(0, _donViTinh1);
                donViTinhListBindingSource1.DataSource = _DonViTinhKhoiLuongList;               
            }
        }
        #endregion

        #region ultCbLoaiHang_ValueChanged
        private void ultCbLoaiHang_ValueChanged(object sender, EventArgs e)
        {
            //HangHoa _hangHoa = HangHoa.NewHangHoa();
            //_hangHoa.TenHangHoa = "None";
            //if (ultCbLoaiHang.ActiveRow != null)
            //{
               
            //    _HangHoaList = HangHoaList.GetHangHoaList((int)ultCbLoaiHang.ActiveRow.Cells["MaLoaiHangHoa"].Value, 0);
            //    _HangHoaList.Insert(0, _hangHoa);
            //}

            //hangHoaListBindingSource.DataSource = _HangHoaList;
        }
        #endregion

        #region cmbeu_LoaiDonHang_ValueChanged
        private void cmbeu_LoaiDonHang_ValueChanged(object sender, EventArgs e)
        {
            //DoiTacList doiTacList = DoiTacList.NewDoiTacList(); 
            //if (cmbeu_LoaiDonHang.Value != null)
            //{
            //    int i = Convert.ToInt32(cmbeu_LoaiDonHang.Value);
            //    if (i == 1 && i== 2 && i == 4 && i == 5)
            //    {
            //        _donHangMua.MaHopDongMua = 0;                    
            //        txt_HopDong.Enabled = false;
            //        ultracmbDotGiaoHang.Enabled = false;
            //        gb_UuDai.Visible = false;

            //    }               
            //    else
            //    {                    
            //        txt_HopDong.Enabled = true;
            //        ultracmbDotGiaoHang.Enabled = true;
            //        gb_UuDai.Visible = true;
            //    }
            //}          
        }
        #endregion

        #endregion 

        #region tlslblIn_Click
        private void tlslblIn_Click(object sender, EventArgs e)
        {
            if (_donHangMua.IsNew == false)
            {
                ReportDocument Report = new Report.Report_MuaBan.Report_DonHangMua();

                SqlCommand command = new SqlCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "spd_Report_DonHangMua";
                command.Parameters.AddWithValue("@MaDonHang", _donHangMua.MaDonHang);
                command.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable table = new DataTable();
                adapter.Fill(table);
                table.TableName = "spd_Report_DonHangMua;1";

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
        
        #region ultragrdDSChiTietHangHoa_KeyDown
        private void ultragrdDSChiTietHangHoa_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                grdu_DSChiTietHangHoa.UpdateData();
                decimal _tongTien = 0;              
                foreach (CT_DonHangMua _ct_donHangMua in _donHangMua.CT_DonHangBanList)
                {
                    _tongTien = _ct_donHangMua.ThanhTien + _tongTien;                    
                }
                _donHangMua.ThanhTien = _tongTien;                
            }
        }
        #endregion

        #region ultragrdDSChiTietHangHoa_Leave
        private void ultragrdDSChiTietHangHoa_Leave(object sender, EventArgs e)
        {
            grdu_DSChiTietHangHoa.UpdateData();
            decimal _tongTien = 0;
            foreach (CT_DonHangMua _ct_donHangMua in _donHangMua.CT_DonHangBanList)
            {
                _tongTien = _ct_donHangMua.ThanhTien + _tongTien;
            }
            _donHangMua.ThanhTien = _tongTien;
           // KiemTraHangHoaBiTrung();

        }
        #endregion

        #region txt_HopDong_KeyDown
        private void txt_HopDong_KeyDown(object sender, KeyEventArgs e)
        {
            HopDongMuaBanList _hopDongMuaBanList;
           
            if (e.KeyCode == Keys.Enter)
            {
                _hopDongMuaBanList = HopDongMuaBanList.GetHopDongMuaBanList(_loaiHopDong, txt_HopDong.Text, false);
                frmTimHopDong dlg = new frmTimHopDong(_hopDongMuaBanList,txt_HopDong.Text,_loaiHopDong);
                if (dlg.ShowDialog() != DialogResult.OK)
                {
                    _hopDongMuaBan = dlg.HopDongMuaBan;                    
                    _donHangMua.MaHopDongMua = _hopDongMuaBan.MaHopDong;
                    dotGiaoHangHDMBListBindingSource.DataSource = _hopDongMuaBan.DotGiaoHangHDMBList;
                    _donHangMua.MaDoiTac = _hopDongMuaBan.MaDoiTac;                    
                    _donHangMua.MaNguoiLienLac = Convert.ToInt32(_hopDongMuaBan.NguoiLienLac);
                    if (_hopDongMuaBan.MaHopDong == 0)
                    {
                        _donHangMua.CT_DonHangBanList = CT_DonHangMuaList.NewCT_DonHangMuaList();
                        cTDonHangMuaListBindingSource.DataSource = _donHangMua.CT_DonHangBanList;
                    }
                }
                txt_HopDong.Text = _hopDongMuaBan.SoHopDong;
            }
        }
        #endregion

        #region ultragrdDSChiTietHangHoa_AfterCellUpdate
        private void ultragrdDSChiTietHangHoa_AfterCellUpdate(object sender, CellEventArgs e)
        {
            grdu_DSChiTietHangHoa.UpdateData();
            decimal _soTienUuDai = 0;
            if (grdu_DSChiTietHangHoa.ActiveCell == grdu_DSChiTietHangHoa.ActiveRow.Cells["TenHangHoa"])
            {
                KiemTraHangHoaBiTrung();
            }
            else if (grdu_DSChiTietHangHoa.ActiveCell == grdu_DSChiTietHangHoa.ActiveRow.Cells["ChietKhau"])
            {
                foreach (CT_DonHangMua _ct_donHangMua in _donHangMua.CT_DonHangBanList)
                {
                    _soTienUuDai= _ct_donHangMua.SoTienChietKhau+ _soTienUuDai;
                }
                _donHangMua.SoTienUuDai= _soTienUuDai;  
            }

        }
        #endregion 

        #region cTDonHangMuaListBindingSource_CurrentChanged
        private void cTDonHangMuaListBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            decimal _tongTien = 0;
            foreach (CT_DonHangMua _ct_donHangMua in _donHangMua.CT_DonHangBanList)
            {
                _tongTien = _ct_donHangMua.ThanhTien + _tongTien;
            }
            _donHangMua.TongTien = _tongTien;
        }
        #endregion       

        #region cmbeu_LoaiDonHang_Leave
        private void cmbeu_LoaiDonHang_Leave(object sender, EventArgs e)
        {
            //if (cmbeu_LoaiDonHang.Value != null)
            //{
            //    if (_donHangMua.Loai == 0)
            //    {
            //        _doiTacList = DoiTacList.GetDoiTacListTheoLoaiKhachHang(6);

            //    }
            //    else _doiTacList = DoiTacList.GetDoiTacListTheoLoaiKhachHang(_donHangMua.Loai);
            //    DoiTac doiTac = DoiTac.NewDoiTac(0, "Thêm Mới......");
            //    _doiTacList.Insert(0, doiTac);
            //    doiTacListBindingSource.DataSource = _doiTacList;
            //}
        }
        #endregion 

        #region ultraCbKhachHang_AfterCloseUp
        private void ultraCbKhachHang_AfterCloseUp(object sender, EventArgs e)
        {
            if (ultraCbKhachHang.ActiveRow != null)
            {
                if (Convert.ToInt32(ultraCbKhachHang.Value) == 0 && flag !=0)
                {
                    frmKhachHang dlg = new frmKhachHang();
                    if (dlg.ShowDialog() != DialogResult.OK)
                    {
                        //if (_donHangMua.Loai == 0)
                        //{
                        //    _doiTacList = DoiTacList.GetDoiTacListTheoLoaiKhachHang(2);

                        //}
                        //else _doiTacList = DoiTacList.GetDoiTacListTheoLoaiKhachHang(_donHangMua.Loai);
                        _doiTacList = DoiTacList.GetDoiTacList();
                        DoiTac doiTac = DoiTac.NewDoiTac(0, "Thêm Mới....");
                        _doiTacList.Insert(0, doiTac);
                        doiTacListBindingSource.DataSource = _doiTacList;
                    }

                }
            }
            flag++; 
        }
        #endregion 

        #region grdu_DSChiTietHangHoa_Error
        private void grdu_DSChiTietHangHoa_Error(object sender, ErrorEventArgs e)
        {
            if(e.ErrorType == ErrorType.Data)
                 e.ErrorText = "Kiểu dữ liệu không hợp lệ";
        }
        #endregion 

        private void frmDonMuaHang_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                Main.frmMain.LoadHelp(this, "Don Mua Hang MHNK", "Help_BanHang.chm");
            }
        }

        #region tlslblLapHoaDon_Click
        private void tlslblLapHoaDon_Click(object sender, EventArgs e)
        {
            if (_donHangMua.IsNew != true)
            {
                if (_donHangMua.TinhTrang == 0)
                {
                    frmHoaDonTuDonHang dlg = new frmHoaDonTuDonHang(_donHangMua);
                    if (dlg.ShowDialog() != DialogResult.OK)
                    {
                        _donHangMua = DonHangMua.GetDonHangMua(_donHangMua.MaDonHang);
                    }
                }
                else
                {
                    HoaDon _hoaDon = HoaDon.GetHoaDonByMaDonHang(_donHangMua.MaDonHang);
                    frmHoaDonTuDonHang dlg = new frmHoaDonTuDonHang(_hoaDon, _donHangMua);
                    if (dlg.ShowDialog() != DialogResult.OK)
                    {
                        _donHangMua = DonHangMua.GetDonHangMua(_donHangMua.MaDonHang);
                    }
                }
            }
            else
            {
                MessageBox.Show(this, "Vui Lòng Cập Nhật Đơn Hàng Trước Khi Lập Hóa Đơn", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        #endregion 

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
                        HangHoa _HangHoa = HangHoa.NewHangHoa("Thêm Mới", 0);
                        _HangHoaList.Insert(0, _HangHoa);
                        hangHoaListBindingSource.DataSource = _HangHoaList;
                    }
                }
            }
            return;
        }
        #endregion 
    }
}
